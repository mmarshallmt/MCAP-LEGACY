Imports System.IO
Imports System.ComponentModel
Imports System.Data.SqlClient

Namespace UI.Processors

    Public Class ScanTrackerRemoteQc
        Inherits BaseClass

#Region "Constants"
        Public Const XML_SOURCE_TEXTBOX As String = "strsourcetextbox"
        Private Const XML_SOURCE_DEFAULT As String = "No Source Specified."
        Private Const MSG_INVALID_FILE_SIZE As String = _
          "Image {0} has a file size of zero and will not be moved. Rescan or delete the image."
        Private Const FORM_NAME As String = "ScanTrackerRemoteQc"
#End Region

#Region "Member Variables"

        Private m_parentForm As ScanTrackerRemoteQCForm
        Private m_Source As String
        Private m_Destination As String
        Private m_overwrite As Boolean = True
        Private m_imageCount As Integer = 0
        Private m_vehicleCount As Integer = 0
        Private m_vehicleImageCount As Dictionary(Of String, Integer)
        Private m_vehiclesToMove As List(Of String)
        Private m_imageInfo As New ArrayList
        Private m_vehicleAdapter As QCDataSetTableAdapters.vwCircularTableAdapter
        Private m_vehicleROPAdapter As QCDataSetTableAdapters.vwPublicationEditionTableAdapter
        Private m_vehicleDataTable As QCDataSet.vwCircularDataTable
        Private m_vehicleROPDataTable As QCDataSet.vwPublicationEditionDataTable
        Private m_rotateDegree As Integer
        Private m_moveHistory As ArrayList
        Private m_tempFolders As ArrayList
        Private m_completeDts As Dictionary(Of Integer, DateTime)
        Private m_sessionId As Integer

        Private WithEvents m_moveWorker As System.ComponentModel.BackgroundWorker
        Private WithEvents m_countWorker As System.ComponentModel.BackgroundWorker
        Private m_DataSet As QCDataSet

        Private m_Priority As Integer
        Private m_priorityval As Integer
        Private m_frmlocation As Integer
        Private m_tolocation As Integer

#End Region

#Region "Properties"

        ''' <summary>
        ''' DataSet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Data() As QCDataSet
            Get
                Return m_DataSet
            End Get
        End Property
        ''' <summary>
        ''' Current sessionId.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property locationId() As Integer
            Get
                Return locationId
            End Get
        End Property
        ''' <summary>
        ''' Current sessionId.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property SessionId() As Integer
            Get
                Return m_sessionId
            End Get
        End Property

        Public Property Source() As String
            Get
                Return m_Source
            End Get
            Set(ByVal value As String)
                m_Source = value
                MDIForm.AppVar.SaveValue(UI.Processors.ScanTracker.XML_SOURCE_TEXTBOX, m_Source)
            End Set
        End Property

        Public Property Destination() As String
            Get
                Return m_Destination
            End Get
            Set(ByVal value As String)
                m_Destination = value
            End Set
        End Property

        Public ReadOnly Property MoveActive() As Boolean
            Get
                Return m_moveWorker.IsBusy
            End Get
        End Property

        Public ReadOnly Property CountActive() As Boolean
            Get
                Return m_countWorker.IsBusy
            End Get
        End Property

        Public Property RotateDegree() As Integer
            Get
                Return m_rotateDegree
            End Get
            Set(ByVal value As Integer)
                m_rotateDegree = value
            End Set
        End Property

        ''' <summary>
        ''' Get the Image Count variable
        ''' </summary>
        Public Property ImageCount() As Integer
            Get
                Return m_imageCount
            End Get
            Set(ByVal Value As Integer)
                m_imageCount = Value
            End Set
        End Property

        ''' <summary>
        ''' Get the Vehicle Count variable
        ''' </summary>
        Public Property VehicleCount() As Integer
            Get
                Return m_vehicleCount
            End Get
            Set(ByVal Value As Integer)
                m_vehicleCount = Value
            End Set
        End Property

        Protected ReadOnly Property VehicleAdapter() As QCDataSetTableAdapters.vwCircularTableAdapter
            Get
                Return m_vehicleAdapter
            End Get
        End Property

        Protected ReadOnly Property Vehicle() As QCDataSet.vwCircularRow
            Get
                If m_vehicleDataTable.Rows.Count = 1 Then
                    Return CType(m_vehicleDataTable.Rows(0), QCDataSet.vwCircularRow)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Protected ReadOnly Property VehicleROPAdapter() As QCDataSetTableAdapters.vwPublicationEditionTableAdapter
            Get
                Return m_vehicleROPAdapter
            End Get
        End Property

        Protected ReadOnly Property VehicleROP() As QCDataSet.vwPublicationEditionRow
            Get
                If m_vehicleROPDataTable.Rows.Count = 1 Then
                    Return CType(m_vehicleROPDataTable.Rows(0), QCDataSet.vwPublicationEditionRow)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Public Property Overwrite() As Boolean
            Get
                Return m_overwrite
            End Get
            Set(ByVal value As Boolean)
                m_overwrite = value
            End Set
        End Property
#End Region

#Region "Events"
        Public Event Initializing()
        Public Event Initialized()
        Public Event CountStarted()
        Public Event CountFinished()
        Public Event MoveStarted()
        Public Event MoveFinished()
        Public Event ProgressChanged(ByVal percent As Integer)
        Public Event ProgressIncreased()
        Public Event ProgressMovedVehicle()
        Public Event ProgressMovedImage()
        Public Event ShowMessage(ByVal mesg As String)
#End Region

#Region "Background Worker Event Handlers"
        ''' <summary>
        ''' Resets image counts, and counts images
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub countWorker_DoWork(ByVal sender As Object, _
                                       ByVal e As System.ComponentModel.DoWorkEventArgs) _
                                       Handles m_countWorker.DoWork
            Dim countWorker As BackgroundWorker = CType(sender, BackgroundWorker)
            RaiseEvent CountStarted()
            m_imageCount = 0
            m_imageInfo.Clear()
            m_vehicleCount = 0
            CountImages(e.Argument.ToString, countWorker, e)
        End Sub

        ''' <summary>
        ''' Notifies when work progresses
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub countWorker_ProgressChanged(ByVal sender As Object, _
                                                ByVal e As System.ComponentModel.ProgressChangedEventArgs) _
                                                Handles m_countWorker.ProgressChanged
            RaiseEvent ProgressIncreased()
        End Sub

        ''' <summary>
        ''' Updates image counts, enables buttons if images are available
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub countWorker_RunWorkerCompleted(ByVal sender As Object, _
                                                   ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) _
                                                   Handles m_countWorker.RunWorkerCompleted
            If (e.Error IsNot Nothing) Then
                ' RaiseEvent error
            ElseIf e.Cancelled Then
                ' cancelled
            Else
                ' count is good.
            End If
            RaiseEvent CountFinished()
        End Sub

        ''' <summary>
        ''' Moves images
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub moveWorker_DoWork(ByVal sender As Object, _
                                      ByVal e As System.ComponentModel.DoWorkEventArgs) _
                                      Handles m_moveWorker.DoWork
            RaiseEvent MoveStarted()

            Dim moveWorker As BackgroundWorker = CType(sender, BackgroundWorker)
            Dim args As Object() = DirectCast(e.Argument, Object())

            Dim srcFolder As String = CType(args(0), String)
            Dim destFolder As String = CType(args(1), String)

            MoveImages(srcFolder, destFolder, moveWorker, e)
        End Sub

        ''' <summary>
        ''' Updates progress bar
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub moveWorker_ProgressChanged(ByVal sender As Object, _
                                               ByVal e As System.ComponentModel.ProgressChangedEventArgs) _
                                               Handles m_moveWorker.ProgressChanged
            RaiseEvent ProgressChanged(e.ProgressPercentage)
        End Sub

        ''' <summary>
        ''' After move complete, redos image count
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub moveWorker_RunWorkerCompleted(ByVal sender As Object, _
                                                  ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) _
                                                  Handles m_moveWorker.RunWorkerCompleted
            If e.Cancelled Then
                Debug.WriteLine(Now.ToString & " undoing Moves because e.Cancelled")
                UndoMoves()
            End If
            DeleteTempFolders()
            RaiseEvent MoveFinished()
        End Sub
#End Region

#Region "Class"
        Public Sub New(ByRef parentForm As ScanTrackerRemoteQCForm)
            m_parentForm = parentForm
            m_vehicleAdapter = New QCDataSetTableAdapters.vwCircularTableAdapter
            m_vehicleROPAdapter = New QCDataSetTableAdapters.vwPublicationEditionTableAdapter
            m_DataSet = New QCDataSet
            m_moveWorker = New BackgroundWorker
            m_countWorker = New BackgroundWorker
            m_moveWorker.WorkerReportsProgress = True
            m_countWorker.WorkerReportsProgress = True
            m_moveWorker.WorkerSupportsCancellation = True
            m_countWorker.WorkerSupportsCancellation = True
            'm_Source = MDIForm.AppVar.LoadValue(UI.Processors.ScanTracker.XML_SOURCE_TEXTBOX, UI.Processors.ScanTracker.XML_SOURCE_DEFAULT)
            m_Destination = ScanTrackerDestination
            m_vehicleDataTable = New QCDataSet.vwCircularDataTable
            m_vehicleROPDataTable = New QCDataSet.vwPublicationEditionDataTable
        End Sub
#End Region

#Region " Subs "

        Public Overridable Sub Initialize()
            RaiseEvent Initializing()
            VehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            VehicleROPAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            RaiseEvent Initialized()
        End Sub

        Public Sub LoadLocations(ByVal locationId As Integer)

            Dim tempAdapter As QCDataSetTableAdapters.ScanLocationTableAdapter
            tempAdapter = New QCDataSetTableAdapters.ScanLocationTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(Data.ScanLocation)
            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub

        ''' <summary>
        ''' Creates new session in ScanTrackerSession table.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CreateNewSession()
            Dim tempRow As QCDataSet.ScanTrackerSessionRow
            Dim tempTable As QCDataSet.ScanTrackerSessionDataTable
            Dim tempAdapter As QCDataSetTableAdapters.ScanTrackerSessionTableAdapter


            tempTable = New QCDataSet.ScanTrackerSessionDataTable()
            tempRow = tempTable.NewScanTrackerSessionRow()
            tempRow.UserId = UserID
            tempRow.StartDt = DateTime.Now
            tempTable.AddScanTrackerSessionRow(tempRow)

            tempAdapter = New QCDataSetTableAdapters.ScanTrackerSessionTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Try
                tempAdapter.Update(tempTable)
                m_sessionId = tempRow.SessionId

            Catch ex As Exception
                MessageBox.Show("An error has occurred while creating a new session.", _
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                m_sessionId = -1
            Finally
                tempAdapter.Dispose()
                tempTable.Dispose()
            End Try

            tempRow = Nothing
            tempTable = Nothing
            tempAdapter = Nothing
        End Sub

        ''' <summary>
        ''' Records end time for current session.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub EndSession()
            Dim tempRow As QCDataSet.ScanTrackerSessionRow
            Dim tempTable As QCDataSet.ScanTrackerSessionDataTable
            Dim tempAdapter As QCDataSetTableAdapters.ScanTrackerSessionTableAdapter


            tempTable = New QCDataSet.ScanTrackerSessionDataTable()
            tempAdapter = New QCDataSetTableAdapters.ScanTrackerSessionTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Try
                tempAdapter.FillBySessionId(tempTable, Me.SessionId)
            Catch ex As Exception
                'DO NOTHING
            End Try

            If tempTable.Count = 0 Then
                MessageBox.Show("Cannot find session. Unable to update session information.", _
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            tempRow = tempTable.FindBySessionId(Me.SessionId)
            tempRow.EndDt = DateTime.Now

            Try
                tempAdapter.Update(tempTable)

            Catch ex As Exception
                MessageBox.Show("An error has occurred while updating current session information.", _
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                m_sessionId = -1
            Finally
                tempAdapter.Dispose()
                tempTable.Dispose()
            End Try

            tempRow = Nothing
            tempTable = Nothing
            tempAdapter = Nothing
        End Sub

        ''' <summary>
        ''' Adds a new row into ScanTrackerScans table.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="pageCount"></param>
        ''' <remarks></remarks>
        Public Sub AddScanInfo(ByVal vehicleId As Integer, ByVal pageCount As Integer)
            Dim tempRow As QCDataSet.ScanTrackerScansRow
            Dim tempTable As QCDataSet.ScanTrackerScansDataTable
            Dim tempAdapter As QCDataSetTableAdapters.ScanTrackerScansTableAdapter


            tempTable = New QCDataSet.ScanTrackerScansDataTable()
            tempRow = tempTable.NewScanTrackerScansRow()
            tempRow.SessionId = Me.SessionId
            tempRow.VehicleId = vehicleId
            tempRow.PageCount = pageCount
            tempRow.PostDate = DateTime.Now
            tempTable.AddScanTrackerScansRow(tempRow)

            tempAdapter = New QCDataSetTableAdapters.ScanTrackerScansTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Try
                tempAdapter.Update(tempTable)

            Catch ex As Exception
                MessageBox.Show("An error has occurred while logging scan information.", _
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                tempAdapter.Dispose()
                tempTable.Dispose()
            End Try

            tempRow = Nothing
            tempTable = Nothing
            tempAdapter = Nothing
        End Sub


        ''' <summary>
        ''' Displays review form
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Review()
            Dim reviewForm As New ScanTrackerReviewForm
            Try
                Dim images(m_imageInfo.Count - 1) As FileInfo
                m_imageInfo.CopyTo(images)
                reviewForm.PopulateListBox(images)
                reviewForm.ShowDialog()
            Catch ex As Exception
                MessageBox.Show("There was an error populating the window.", "Window Error", _
                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        ''' <summary>
        ''' handles when a user clicks on Post images button
        ''' </summary>
        ''' <param name="rotDeg"></param>
        ''' <remarks></remarks>
        Public Sub Post(ByVal rotDeg As Integer)

            If m_moveWorker.IsBusy Then
                Debug.WriteLine(Now.ToString & " Canceling Move Worker.")
                m_moveWorker.CancelAsync()
            ElseIf Not m_countWorker.IsBusy Then
                Me.RotateDegree = rotDeg
                m_moveWorker.RunWorkerAsync(New Object() {Me.Source, Me.Destination})

            Else
                MessageBox.Show("Counting images, please wait...")
            End If

        End Sub
        ''' <summary>
        ''' Saves Remote Scan Data to DB
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub setScanTrackerRemoteQc(ByVal CurrentLocationId As Integer, ByVal Location As Integer)
            m_frmlocation = CurrentLocationId
            m_tolocation = Location



        End Sub
        ''' <summary>
        ''' Handles when a user clicks on Count button
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Count()
            If m_countWorker.IsBusy Then
                Debug.WriteLine(Now.ToString & " Canceling Count Worker.")
                m_countWorker.CancelAsync()
            ElseIf Not m_moveWorker.IsBusy Then
                m_countWorker.RunWorkerAsync(Me.Source)
            Else
                MessageBox.Show("Moving images, please wait...")
            End If
        End Sub

        ''' <summary>
        ''' The actual count images procedure
        ''' </summary>
        ''' <param name="folder"></param>
        ''' <param name="worker"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub CountImages(ByVal folder As String, ByVal worker As BackgroundWorker, ByVal e As DoWorkEventArgs)
            Dim sourceDirInfo As DirectoryInfo
            Dim directories() As FileSystemInfo
            Dim imageFileList() As FileSystemInfo
            Dim dirNext As DirectoryInfo
            Dim imageFileNext As FileInfo

            sourceDirInfo = New DirectoryInfo(folder)
            ' check if current directory is a vehicle
            If ValidVehicleId(sourceDirInfo.Name) Then
                imageFileList = sourceDirInfo.GetFiles("*" & ImageFileExtension)
                ' Find number of files with the correct extension in the current directory
                m_imageCount += imageFileList.Length

                If imageFileList.Length > 0 Then
                    m_vehicleCount += 1
                End If
                ' Store file information about each of the matching files
                For Each imageFileNext In imageFileList
                    If worker.CancellationPending Then
                        e.Cancel = True
                        Exit For
                    End If
                    If imageFileNext.Length >= 1000L Then
                        worker.ReportProgress(1)
                        m_imageInfo.Add(imageFileNext)
                    Else
                        'Since we already got the number of files, just subtract the count by one
                        'for each file that has a size of 0
                        m_imageCount -= 1
                        'MessageBox.Show(String.Format(MSG_INVALID_FILE_SIZE, imageFileNext.Name), _
                        '  "Zero Image File Size", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, _
                        '    MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
                        m_parentForm.AddError(String.Format(MSG_INVALID_FILE_SIZE, sourceDirInfo.Name & "\" & imageFileNext.Name))
                    End If
                Next
            Else
                If sourceDirInfo.FullName <> m_Source Then
                    'm_parentForm.AddError(sourceDirInfo.FullName & " is not named a valid vehicle Id")
                    m_parentForm.AddInvalidVehicleId(sourceDirInfo.Name)
                End If
            End If

            ' Now report the count back to the UI
            directories = sourceDirInfo.GetDirectories()
            For Each dirNext In directories
                If worker.CancellationPending Then
                    e.Cancel = True
                    Exit For
                End If
                CountImages(dirNext.FullName, worker, e)
            Next
        End Sub

        ''' <summary>
        ''' The actual move images procedure
        ''' </summary>
        ''' <param name="srcFolder"></param>
        ''' <param name="destFolder"></param>
        ''' <param name="worker"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub MoveImages(ByVal srcFolder As String, ByVal destFolder As String, ByRef worker As BackgroundWorker, ByVal e As DoWorkEventArgs)
            Dim vehicleFolders As ArrayList
            Dim vehicleFolder As String
            m_moveHistory = New ArrayList
            m_tempFolders = New ArrayList
            m_completeDts = New Dictionary(Of Integer, DateTime)

            vehicleFolders = GetVehicleFolders()
            For Each vehicleFolder In vehicleFolders
                MoveVehicle(vehicleFolder, destFolder, worker)
                If worker.CancellationPending Then
                    e.Cancel = True
                    Exit For
                End If
            Next
            If Not e.Cancel Then
                MarkVehiclesScanDt()
            End If


        End Sub

        ''' <summary>
        ''' Loop through complete dts for vehicles that were moved, and update their scan dts
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub MarkVehiclesScanDt()
            Dim vehicleId As Integer
            For Each vehicleId In m_completeDts.Keys
                MarkVehicleScanDt(vehicleId, m_completeDts.Item(vehicleId))
            Next
        End Sub

        ''' <summary>
        ''' Update a vehicle's scanDt
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="dt"></param>
        ''' <remarks></remarks>
        Private Sub MarkVehicleScanDt(ByVal vehicleId As Integer, ByVal dt As DateTime)
            Dim appDBConn As SqlClient.SqlConnection
            Dim updateCommand As SqlClient.SqlCommand
            Dim vehicleIdParam, userIdParam, statusTextParam, formNameParam As SqlClient.SqlParameter


            vehicleIdParam = New SqlClient.SqlParameter("@VehicleId", SqlDbType.Int)
            userIdParam = New SqlClient.SqlParameter("@UserId", SqlDbType.Int)
            statusTextParam = New SqlClient.SqlParameter("@StatusText", SqlDbType.VarChar, 50)
            formNameParam = New SqlClient.SqlParameter("@FormName", SqlDbType.VarChar, 100)

            vehicleIdParam.Value = vehicleId
            userIdParam.Value = UserID
            statusTextParam.Value = "Scanned"
            formNameParam.Value = "ScanTracker"

            appDBConn = New SqlClient.SqlConnection
            updateCommand = New SqlClient.SqlCommand

            appDBConn.ConnectionString = GetConnectionStringForAppDB()

            updateCommand.Connection = appDBConn
            updateCommand.CommandType = CommandType.StoredProcedure
            updateCommand.CommandText = "mt_proc_UpdateVehicleStatus"
            updateCommand.Parameters.Add(vehicleIdParam)
            updateCommand.Parameters.Add(userIdParam)
            updateCommand.Parameters.Add(statusTextParam)
            updateCommand.Parameters.Add(formNameParam)

            Try
                appDBConn.Open()
                updateCommand.ExecuteNonQuery()
                If appDBConn.State <> ConnectionState.Closed Then appDBConn.Close()

            Catch ex As Exception
                MessageBox.Show("An error has occured while marking Vehicle as scanned.", _
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If appDBConn.State <> ConnectionState.Closed Then appDBConn.Close()
            End Try

            updateCommand.Dispose()
            appDBConn.Dispose()

            vehicleIdParam = Nothing
            userIdParam = Nothing
            statusTextParam = Nothing
            formNameParam = Nothing
            updateCommand = Nothing
            appDBConn = Nothing
        End Sub

        ''' <summary>
        ''' Undoes any moves, deletes moved images, copies original source images from temp folders to source locations
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub UndoMoves()
            Dim tempFilePath As String
            Dim oldFilePath As String
            Dim newFilePath As String
            Dim imagename As String
            Dim vehicleId As Integer
            Dim oldFileInfo As FileInfo
            Dim paths As Object()
            For Each paths In m_moveHistory
                tempFilePath = CType(paths(0), String)
                oldFilePath = CType(paths(1), String)
                newFilePath = CType(paths(2), String)
                Debug.WriteLine(Now.ToString & " undo move, copying " & tempFilePath & " to " & oldFilePath & " and deleting " & newFilePath)
                If File.Exists(tempFilePath) Then
                    If Not Directory.Exists(Path.GetDirectoryName(oldFilePath)) Then
                        Directory.CreateDirectory(Path.GetDirectoryName(oldFilePath))
                    End If
                    If Not File.Exists(oldFilePath) Then
                        File.Copy(tempFilePath, oldFilePath)
                    End If
                    If File.Exists(oldFilePath) Then
                        File.Delete(newFilePath)
                        File.Delete(tempFilePath)
                    End If
                    oldFileInfo = New FileInfo(oldFilePath)
                    imagename = oldFileInfo.Name
                    If Integer.TryParse(oldFileInfo.Directory.Name, vehicleId) Then
                        Debug.WriteLine(Now.ToString & " Unlogging " & vehicleId.ToString & ":" & imagename)
                        UnlogScanTrack(vehicleId, imagename)
                    End If
                End If
            Next
        End Sub

        ''' <summary>
        ''' Deletes all temp folders
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub DeleteTempFolders()
            Dim tempFolder As String
            For Each tempFolder In m_tempFolders
                If Directory.Exists(tempFolder) Then
                    Debug.WriteLine(Now.ToString & " deleting temp folder: " & tempFolder)
                    Try
                        Directory.Delete(tempFolder, True)
                    Catch ex As Exception
                        'Do Nothing. Ignore and continue...
                    End Try

                End If
            Next
        End Sub

        ''' <summary>
        ''' Stores database move in the database
        ''' @Omar Murray
        ''' ReUsesed for Scan Trackker Remote QC
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="imageName"></param>
        ''' <remarks></remarks>
        Private Sub LogScanTrack(ByVal vehicleFolder As String, ByVal destFolder As String, ByVal vehicleId As Integer, ByVal Priority As Integer, ByVal imageName As String)
            Dim configDBConn As SqlClient.SqlConnection
            Dim insertCommand As SqlClient.SqlCommand


            Dim vehicleIdParam As New SqlClient.SqlParameter("@vehicleId", SqlDbType.Int)
            Dim FromLocationParam As New SqlClient.SqlParameter("@FromLocation", SqlDbType.Int)
            Dim ToLocationParam As New SqlClient.SqlParameter("@ToLocation", SqlDbType.Int)
            Dim priorityIdParam As New SqlClient.SqlParameter("@priorityId", SqlDbType.Int)
            Dim CopyDtParam As New SqlClient.SqlParameter("@CopyDt", SqlDbType.DateTime)
            Dim LocalFilePathParam As New SqlClient.SqlParameter("@LocalFilePath", SqlDbType.VarChar, 50)
            Dim RemoteDirParam As New SqlClient.SqlParameter("@RemoteDir", SqlDbType.VarChar, 50)
            Dim ZipDtParam As New SqlClient.SqlParameter("@ZipDt", SqlDbType.DateTime)
            Dim TransferDtParam As New SqlClient.SqlParameter("@TransferDt", SqlDbType.DateTime)
            Dim TransferredParam As New SqlClient.SqlParameter("@Transferred", SqlDbType.Int)

            vehicleIdParam.Value = vehicleId
            FromLocationParam.Value = m_frmlocation
            ToLocationParam.Value = m_tolocation
            priorityIdParam.Value = m_priorityval
            CopyDtParam.Value = Date.Now
            LocalFilePathParam.Value = m_Source
            RemoteDirParam.Value = destFolder
            'ZipDtParam.Value = Date.Now
            'TransferDtParam.Value = Date.Now
            TransferredParam.Value = 0

            configDBConn = New SqlClient.SqlConnection
            insertCommand = New SqlClient.SqlCommand

            configDBConn.ConnectionString = GetConnectionStringForAppDB()

            insertCommand.Connection = configDBConn
            insertCommand.CommandType = CommandType.StoredProcedure
            insertCommand.CommandText = "mt_proc_ScanTrackerRemoteQcInsert"
            insertCommand.Parameters.Add(vehicleIdParam)
            insertCommand.Parameters.Add(FromLocationParam)
            insertCommand.Parameters.Add(ToLocationParam)
            insertCommand.Parameters.Add(priorityIdParam)
            insertCommand.Parameters.Add(CopyDtParam)
            insertCommand.Parameters.Add(LocalFilePathParam)
            insertCommand.Parameters.Add(RemoteDirParam)
            'insertCommand.Parameters.Add(ZipDtParam)
            'insertCommand.Parameters.Add(TransferDtParam)
            insertCommand.Parameters.Add(TransferredParam)

            Try
                configDBConn.Open()
                insertCommand.ExecuteNonQuery()
                If configDBConn.State <> ConnectionState.Closed Then configDBConn.Close()
                insertCommand.Dispose()
            Catch ex As Exception
                MessageBox.Show("An error has occured while trying to check page count.", _
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If configDBConn.State <> ConnectionState.Closed Then configDBConn.Close()
                insertCommand.Dispose()
                configDBConn.Dispose()

                insertCommand = Nothing
                configDBConn = Nothing
            End Try
        End Sub

        ''' <summary>
        ''' Removes logging of move from database when cancelling move.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="imageName"></param>
        ''' <remarks></remarks>
        Private Sub UnlogScanTrack(ByVal vehicleId As Integer, ByVal imageName As String)
            Dim configDBConn As SqlClient.SqlConnection
            Dim deleteCommand As SqlClient.SqlCommand
            Dim vehicleIdParam As New SqlClient.SqlParameter("@vehicleId", SqlDbType.Int)
            Dim imageNameParam As New SqlClient.SqlParameter("@imageName", SqlDbType.VarChar, 50)
            vehicleIdParam.Value = vehicleId
            imageNameParam.Value = imageName

            configDBConn = New SqlClient.SqlConnection
            deleteCommand = New SqlClient.SqlCommand

            configDBConn.ConnectionString = GetConnectionStringForAppDB()

            deleteCommand.Connection = configDBConn
            deleteCommand.CommandType = CommandType.StoredProcedure
            deleteCommand.CommandText = "mt_proc_ScanTrackerDelete"
            deleteCommand.Parameters.Add(vehicleIdParam)
            deleteCommand.Parameters.Add(imageNameParam)

            Try
                configDBConn.Open()
                deleteCommand.ExecuteNonQuery()
                If configDBConn.State <> ConnectionState.Closed Then configDBConn.Close()
                deleteCommand.Dispose()
            Catch ex As Exception
                MessageBox.Show("An error has occured while trying to check page count.", _
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If configDBConn.State <> ConnectionState.Closed Then configDBConn.Close()
                deleteCommand.Dispose()
                configDBConn.Dispose()

                deleteCommand = Nothing
                configDBConn = Nothing
            End Try

        End Sub
#End Region

#Region "Functions"
        ''' <summary>
        ''' Gets all vehicleFolders from previous count
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetVehicleFolders() As ArrayList
            Dim vehicleFolder As String
            Dim prevVehicleFolder As String = ""
            Dim imageInfo As FileInfo
            Dim vehicleFolders As New ArrayList
            For Each imageInfo In m_imageInfo
                vehicleFolder = imageInfo.Directory.FullName
                If vehicleFolder <> prevVehicleFolder Then
                    vehicleFolders.Add(vehicleFolder)
                End If
                prevVehicleFolder = vehicleFolder
            Next
            Return vehicleFolders
        End Function

        ''' <summary>
        ''' Gets the Number of Vehicles and creates Key/Value pair for number of
        ''' Images in each Vehicle
        ''' </summary>
        Private Function GetVehicleCount() As Integer
            Dim fileNext As System.IO.FileInfo
            Dim prevDirName As String = ""
            Dim imageCount As Integer = 0
            Dim files(m_imageInfo.Count - 1) As System.IO.FileInfo
            m_vehicleImageCount = New Dictionary(Of String, Integer)

            If m_imageInfo.Count > 0 Then
                m_imageInfo.CopyTo(files)
                For Each fileNext In files
                    If fileNext.DirectoryName <> prevDirName Then
                        If prevDirName <> "" Then
                            If Not m_vehicleImageCount.ContainsKey(prevDirName) Then _
                                m_vehicleImageCount.Add(prevDirName, imageCount)
                        End If
                        imageCount = 1
                        prevDirName = fileNext.DirectoryName
                    Else
                        imageCount += 1
                    End If
                Next
                If prevDirName <> "" Then
                    If Not m_vehicleImageCount.ContainsKey(prevDirName) Then _
                        m_vehicleImageCount.Add(prevDirName, imageCount)
                End If
            End If
            Return m_vehicleImageCount.Count
        End Function

        ''' <summary>
        ''' Gets the images from the previous count
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetVehicleImages(ByVal vehicleId As Integer) As ArrayList
            Dim imageInfos As New ArrayList
            Dim imageinfo As FileInfo
            For Each imageinfo In m_imageInfo
                If vehicleId.ToString = imageinfo.Directory.Name Then
                    imageInfos.Add(imageinfo)
                End If
            Next
            Return imageInfos
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="VehicleID"></param>
        ''' <param name="imageCount"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function IsSameVehicleImageCount(ByVal VehicleID As Integer, _
                                                     ByVal imageCount As Integer) As Boolean
            Dim configDBConn As SqlClient.SqlConnection
            Dim readerCommand As SqlClient.SqlCommand
            Dim vehicleIdParam As New SqlClient.SqlParameter("@vehicleId", SqlDbType.Int)
            Dim imageCountParam As New SqlClient.SqlParameter("@imageCount", SqlDbType.Int)
            Dim parameterReader As SqlClient.SqlDataReader
            vehicleIdParam.Value = VehicleID
            imageCountParam.Value = imageCount

            configDBConn = New SqlClient.SqlConnection
            readerCommand = New SqlClient.SqlCommand

            configDBConn.ConnectionString = GetConnectionStringForAppDB()

            readerCommand.Connection = configDBConn
            readerCommand.CommandType = CommandType.StoredProcedure
            readerCommand.CommandText = "mt_proc_ScanTracker_VerifyVehiclePageCount"
            readerCommand.Parameters.Add(vehicleIdParam)
            readerCommand.Parameters.Add(imageCountParam)

            Try
                configDBConn.Open()
                parameterReader = readerCommand.ExecuteReader(CommandBehavior.CloseConnection)

                IsSameVehicleImageCount = parameterReader.HasRows()

                parameterReader.Close()
                If configDBConn.State <> ConnectionState.Closed Then configDBConn.Close()
                readerCommand.Dispose()

            Catch ex As Exception
                MessageBox.Show("An error has occured while trying to check page count.", _
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                If configDBConn.State <> ConnectionState.Closed Then configDBConn.Close()
                readerCommand.Dispose()
                configDBConn.Dispose()

                parameterReader = Nothing
                readerCommand = Nothing
                configDBConn = Nothing

            End Try

        End Function

        Private Function VehicleExists(ByVal vehicleId As Integer) As Boolean
            VehicleAdapter.Fill(m_vehicleDataTable, vehicleId)
            VehicleROPAdapter.Fill(m_vehicleROPDataTable, vehicleId, "", "")
            Return (m_vehicleDataTable.Count = 1) Or (m_vehicleROPDataTable.Count = 1)
        End Function

        Private Function ValidVehicleId(ByVal possibleVehicleId As String) As Boolean
            Dim vehicleId As Integer
            If Integer.TryParse(possibleVehicleId, vehicleId) Then
                Return VehicleExists(vehicleId)
            Else
                Return False
            End If
        End Function

        Private Function IsDownloadedPublication(ByVal vehicleId As Integer) As Boolean
            Dim recordCount As Integer
            Dim checkCommand As System.Data.SqlClient.SqlCommand
            Dim vehicleIdParam, countParam As System.Data.SqlClient.SqlParameter


            checkCommand = New System.Data.SqlClient.SqlCommand()
            With checkCommand
                .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                .CommandType = CommandType.Text
                .CommandText = "SELECT @Count=COUNT(*) " _
                              + "FROM vwPublicationEdition PE " _
                                + "INNER JOIN (SELECT SenderId FROM Sender WHERE [Name] LIKE 'Download%' OR [Name]='E-Paper') S ON PE.SenderId = S.SenderId " _
                                + "INNER JOIN Media M ON PE.MediaId = M.MediaId AND M.Descrip IN ('ROP', 'Magazine') " _
                              + "WHERE VehicleId=@VehicleId "
                vehicleIdParam = .Parameters.Add("@VehicleId", SqlDbType.Int, 4)
                countParam = .Parameters.Add("@Count", SqlDbType.Int, 4)
            End With

            vehicleIdParam.Value = vehicleId
            countParam.Direction = ParameterDirection.Output

            Try
                checkCommand.Connection.Open()
                checkCommand.ExecuteNonQuery()
                If Integer.TryParse(countParam.Value.ToString(), recordCount) = False Then
                    recordCount = 0
                End If
            Catch ex As System.Data.SqlClient.SqlException
                Trace.TraceError("ScanTracker.IsDownloadedPublication(): Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, ex})
            Catch ex As System.Exception
                Trace.TraceError("ScanTracker.IsDownloadedPublication(): Unknown error. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, ex})
            Finally
                If checkCommand.Connection.State <> ConnectionState.Closed Then checkCommand.Connection.Close()
                checkCommand.Dispose()
                checkCommand = Nothing
            End Try


            Return (recordCount > 0)

        End Function

        Public Function VehicleRemoteQC(ByVal vehicleId As Integer) As Boolean

            LogScanTrack("", "", vehicleId, 0, "")

        End Function
        Private Function MoveVehicle(ByVal vehicleFolder As String, ByVal destFolder As String, ByRef worker As BackgroundWorker) As Boolean
            Dim errorOccurred As Boolean = False
            Dim imgMoveSuccess As Boolean = False
            Dim tempFolder As String
            Dim tempImage As String
            Dim standardizedImageName As String

            If worker.CancellationPending Then
                Return False
            End If
            If Not Directory.Exists(vehicleFolder) Then
                m_parentForm.AddError(vehicleFolder & " no longer exists.")
                Return False
            End If
            Dim vehicleDirectoryInfo As New DirectoryInfo(vehicleFolder)
            Dim vehicleId As Integer
            If Not Integer.TryParse(vehicleDirectoryInfo.Name, vehicleId) Then
                'm_parentForm.AddError(vehicleDirectoryInfo.Name & " is not a valid vehicle Id")
                m_parentForm.AddInvalidVehicleId(vehicleDirectoryInfo.Name)
                Return False
            End If

            'Dim imnas As Integer
            'imnas = getPriority(vehicleId)

            Dim imageInfos As ArrayList = GetVehicleImages(vehicleId)
            Dim imageinfo As FileInfo

            'For downloaded publications(ROP/Magazine) avoid page image count check. This is done 
            'manually by user on Digital Publication Pulling screen.
            If IsDownloadedPublication(vehicleId) = False Then
                If Not IsSameVehicleImageCount(vehicleId, imageInfos.Count) Then
                    'm_parentForm.AddError(vehicleId.ToString & " has the wrong number of images.")
                    m_parentForm.AddInvalidPageCount(vehicleId.ToString())
                    Return False
                End If
            End If

            AddScanInfo(vehicleId, imageInfos.Count)

            destFolder = GetVehicleImageFolderPath(vehicleId, VehicleImageSizeEnum.Unsized)

            If Not Directory.Exists(destFolder) Then
                Directory.CreateDirectory(destFolder)
            End If

            tempFolder = My.Computer.FileSystem.SpecialDirectories.Temp & Path.DirectorySeparatorChar & vehicleId.ToString

            If Not Directory.Exists(tempFolder) Then
                Directory.CreateDirectory(tempFolder)
            End If

            m_tempFolders.Add(tempFolder)

            For Each imageinfo In imageInfos
                imgMoveSuccess = False
                If worker.CancellationPending Then
                    Return False
                End If
                If Not File.Exists(imageinfo.FullName) Then
                    m_parentForm.AddError(imageinfo.FullName & " no longer exists.")
                    errorOccurred = True
                Else
                    ' copy to temp location
                    standardizedImageName = Right("000" & Path.GetFileNameWithoutExtension(imageinfo.FullName), 3) & Path.GetExtension(imageinfo.FullName)
                    tempImage = tempFolder & Path.DirectorySeparatorChar & standardizedImageName
                    If File.Exists(tempImage) Then
                        File.Delete(tempImage)
                    End If
                    File.Copy(imageinfo.FullName, tempImage)

                    If File.Exists(destFolder & Path.DirectorySeparatorChar & standardizedImageName) Then
                        If (Me.Overwrite) Then
                            File.Delete(destFolder & Path.DirectorySeparatorChar & standardizedImageName)
                        Else
                            m_parentForm.AddError(destFolder & Path.DirectorySeparatorChar & standardizedImageName & " already exists.  Stopped moving vehicle " & vehicleId.ToString)
                            Return False
                        End If
                    End If
                    If Me.RotateDegree > 0 Then
                        imgMoveSuccess = RotateAndMoveImage(imageinfo.FullName, destFolder & Path.DirectorySeparatorChar & standardizedImageName, Me.RotateDegree)
                    Else
                        Try
                            File.Move(imageinfo.FullName, destFolder & Path.DirectorySeparatorChar & standardizedImageName)
                            imgMoveSuccess = True
                        Catch ex As Exception
                            m_parentForm.AddError("Error moving image: " & imageinfo.FullName & ":" & ex.ToString)
                            imgMoveSuccess = False
                        End Try
                    End If
                    If imgMoveSuccess Then
                        Debug.WriteLine(Now.ToString & " moved " & imageinfo.FullName & " to " & destFolder & Path.DirectorySeparatorChar & standardizedImageName)
                        m_moveHistory.Add(New Object() {tempImage, imageinfo.FullName, destFolder & Path.DirectorySeparatorChar & standardizedImageName})
                        RaiseEvent ProgressMovedImage()
                    End If
                End If
                RaiseEvent ProgressIncreased()
            Next
            If Not errorOccurred Then
                Try
                    Directory.Delete(vehicleFolder, True)
                Catch ex As Exception
                    m_parentForm.AddError("Error removing vehicle folder: " & vehicleFolder & ":" & ex.ToString)
                End Try

                m_completeDts.Add(vehicleId, Now)

                m_Priority = getPriority(vehicleId)

                ' @name Omar T. Murray
                ' @date 14/11/11
                ' Log Scan Tracker Remote QC To DataDatabase
                LogScanTrack(vehicleFolder, destFolder, vehicleId, m_Priority, standardizedImageName)

                RaiseEvent ProgressMovedVehicle()

                'Try
                '    m_Priority = getPriority(vehicleId)
                '    ' @name Omar T. Murray
                '    ' @date 14/11/11
                '    ' Log Scan Tracker Remote QC To DataDatabase
                '    LogScanTrack(vehicleFolder, destFolder, vehicleId, m_Priority, standardizedImageName)
                'Catch ex As Exception

                'End Try
            End If
            Return (Not errorOccurred)
        End Function
        ''' <summary>
        ''' Purpose: Get Priority
        ''' Param: 
        ''' Return:
        ''' </summary>
        Private Function getPriority(ByVal VehicleId As Integer) As Integer
            Dim dr As SqlDataReader = Nothing
            Dim configDBConn As SqlClient.SqlConnection
            Dim insertCommand As SqlClient.SqlCommand
            Dim vehicleIdParam As New SqlClient.SqlParameter("@vehicleId", SqlDbType.Int)
            Dim imageNameParam As New SqlClient.SqlParameter("@imageName", SqlDbType.VarChar, 50)

            Dim vehicleCommand As SqlClient.SqlCommand

            vehicleCommand = New SqlClient.SqlCommand


            Try
                With vehicleCommand
                    .CommandText = "SELECT Priority FROM Vehicle WHERE VehicleId= + VehicleId.ToString()"
                    .CommandType = CommandType.Text
                    .Connection = New SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    dr = .ExecuteReader()
                End With

                While dr.Read()
                    m_priorityval = CInt(dr.GetValue(0))
                End While
                dr.Close()

            Catch ex As SqlClient.SqlException
                My.Application.Log.WriteException(ex)

            Finally
                If vehicleCommand.Connection.State <> ConnectionState.Closed Then vehicleCommand.Connection.Close()
            End Try

            Return m_priorityval

        End Function

        Public Function RotateAndMoveImage(ByVal srcFilePath As String, ByVal destFilePath As String, ByVal degree As Integer) As Boolean
            Dim img As System.Drawing.Image
            Try
                img = System.Drawing.Bitmap.FromFile(srcFilePath)
                Dim rotFlipType As RotateFlipType
                Select Case degree
                    Case 90
                        rotFlipType = RotateFlipType.Rotate90FlipNone
                    Case 180
                        rotFlipType = RotateFlipType.Rotate180FlipNone
                    Case 270
                        rotFlipType = RotateFlipType.Rotate270FlipNone
                End Select
                img.RotateFlip(rotFlipType)
                If File.Exists(destFilePath) Then File.Delete(destFilePath)
                img.Save(destFilePath, Imaging.ImageFormat.Jpeg)
                File.Delete(srcFilePath)
                Return True
            Catch ex As Exception
                m_parentForm.AddError("Error rotating and moving image: " & srcFilePath & " by " & degree.ToString & Chr(167) & ":" & ex.ToString)
                Return False
            End Try
        End Function

        Protected Function GetVehicleImageFolderPath _
            (ByVal vehicleId As Integer, ByVal imageSize As VehicleImageSizeEnum) _
            As String
            Dim vehicleFolder As String
            Dim imagePath As System.Text.StringBuilder

            imagePath = New System.Text.StringBuilder

            vehicleFolder = GetVehicleFolderPath(vehicleId)
            imagePath.Append(vehicleFolder)
            imagePath.Append("\")
            If imageSize = VehicleImageSizeEnum.Unsized Then
                imagePath.Append(UnsizedPageImageFolderName)
            ElseIf imageSize = VehicleImageSizeEnum.Large Then
                imagePath.Append(FullSizedPageImageFolderName)
            ElseIf imageSize = VehicleImageSizeEnum.Normal Then
                imagePath.Append(MidSizedPageImageFolderName)
            ElseIf imageSize = VehicleImageSizeEnum.Thumbnail Then
                imagePath.Append(ThumbSizedPageImageFolderName)
            End If

            vehicleFolder = Nothing

            Return imagePath.ToString()

        End Function

        Protected Function GetVehicleFolderPath(ByVal vehicleId As Integer) As String
            Dim createDt As DateTime
            Dim vehicleCommand As SqlClient.SqlCommand
            Dim vehicleFolderPath As System.Text.StringBuilder
            Dim vehicleCreateDt As Object


            vehicleCommand = New SqlClient.SqlCommand
            vehicleFolderPath = New System.Text.StringBuilder

            Try
                With vehicleCommand
                    .CommandText = "SELECT CreateDt FROM Vehicle WHERE VehicleId=" + vehicleId.ToString()
                    .CommandType = CommandType.Text
                    .Connection = New SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    vehicleCreateDt = .ExecuteScalar()
                End With

            Catch ex As SqlClient.SqlException
                My.Application.Log.WriteException(ex)

            Finally
                If vehicleCommand.Connection.State <> ConnectionState.Closed Then vehicleCommand.Connection.Close()
            End Try


            If (vehicleCreateDt Is Nothing OrElse vehicleCreateDt Is DBNull.Value) Then
                Throw New System.ApplicationException("Invalid vehicle creation date found.")

            Else
                createDt = CType(vehicleCreateDt, DateTime)
                vehicleFolderPath.Append(Me.Destination)
                vehicleFolderPath.Append("\")
                vehicleFolderPath.Append(createDt.ToString("yyyyMM"))
                vehicleFolderPath.Append("\")
                vehicleFolderPath.Append(vehicleId.ToString())
            End If

            vehicleCommand.Dispose()
            vehicleCommand = Nothing
            vehicleCreateDt = Nothing

            Return vehicleFolderPath.ToString()

        End Function
#End Region

    End Class

End Namespace