﻿Namespace UI

    Public Class DupCheckForm
        Implements IForm


#Region " Events "

        Public Event RefreshingPossibleDuplicateRecords()
        Public Event PossibleDuplicateRecordsRefreshed()
        Public Event OnError(ByVal sender As Object, ByVal e As System.Exception)

#End Region


        Private m_isPossibleDuplicateRecordsFound As Boolean
        Private m_isOverride As Boolean
        Private m_isReview As Boolean
        Private m_isDuplicate As Boolean

        Private m_areImagesAvailable As Boolean
        Private m_applyOverrideRestriction As Boolean

        Private m_dupcheckFormLogId As Integer
        Private m_removeVehicleId As Integer
        Private m_retId As Integer
        Private m_mktId As Integer
        Private m_pubId As Integer
        Private m_adDate As DateTime
        Private m_mediaText As String
        Private m_startDate As DateTime
        Private m_endDate As DateTime
        Private m_languageId As Nullable(Of Integer)
        Private m_thumbnailList As System.Collections.Generic.List(Of String)
        Private m_formName As String

        '' Thumbnails Variable
        Private numRows As Integer = 0
        Private columnIndex As Integer = 0
        Private rowIndex As Integer = 0
        Private _imageSize As Integer = 50


        ''' <summary>
        ''' Processor
        ''' </summary>
        ''' <remarks></remarks>
        Private WithEvents m_dupCheckProcessor As UI.Processors.DupCheck



        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property Processor() As UI.Processors.DupCheck
            Get
                Return m_dupCheckProcessor
            End Get
        End Property

        ''' <summary>
        ''' Returns true, if user has clicked Override button.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsOverride() As Boolean
            Get
                Return m_isOverride
            End Get
        End Property

        ''' <summary>
        ''' Returns true, if user has clicked Review button.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsReview() As Boolean
            Get
                Return m_isReview
            End Get
        End Property

        ''' <summary>
        ''' Returns true, if user has selected to mark vehicle as duplicate.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsDuplicate() As Boolean
            Get
                Return m_isDuplicate
            End Get
        End Property

        ''' <summary>
        ''' Return true, if no possible duplicate records found in database.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property IsPossibleDuplicateRecordsFound() As Boolean
            Get
                Return m_isPossibleDuplicateRecordsFound
            End Get
        End Property

        ''' <summary>
        ''' Removes supplied vehicle id from DataTable.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property RemoveVehicle() As Integer
            Get
                Return m_removeVehicleId
            End Get
            Set(ByVal value As Integer)
                m_removeVehicleId = value
            End Set
        End Property

        ''' <summary>
        ''' Gets boolean flag indicating whether to apply restriction for override or not.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property ApplyOverrideRestriction() As Boolean
            Get
                Return m_applyOverrideRestriction
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets flag indicating whether images are available or not.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AreImagesAvailable() As Boolean
            Get
                Return m_areImagesAvailable
            End Get
            Set(ByVal value As Boolean)
                m_areImagesAvailable = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets DupCheck.DupCheckFormId created for latest possible duplicate check process for this form.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property DupcheckFormLogId() As Integer
            Get
                Return Me.Processor.DupcheckFormLogId
            End Get
        End Property

        ''' <summary>
        ''' List of image paths displayed in list of thumbnails.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property ThumbnailList() As System.Collections.Generic.List(Of String)
            Get
                Return m_thumbnailList
            End Get
        End Property



#Region " Constructors "

        ''' <summary>
        ''' Overloaded constructor for FSI.
        ''' </summary>
        ''' <remarks></remarks>
        Sub New(ByVal retId As Integer, ByVal mktId As Integer, ByVal adDate As DateTime, ByVal mediaList As System.Collections.Generic.List(Of String), ByVal languageId As Nullable(Of Integer), ByVal applyOverrideRestriction As Boolean, ByVal formName As String)

            InitializeComponent()

            m_retId = retId
            m_mktId = mktId
            m_pubId = -1
            m_adDate = adDate
            m_mediaText = GetMediaText(mediaList)
            m_startDate = Nothing
            m_endDate = Nothing
            m_languageId = languageId
            m_thumbnailList = New System.Collections.Generic.List(Of String)

            dupcheckConditionLabel.Text = "Start date: NA, End date: NA."

            m_areImagesAvailable = True
            m_applyOverrideRestriction = applyOverrideRestriction
            m_formName = formName
        End Sub

        ''' <summary>
        ''' Overloaded constructor for ROP.
        ''' </summary>
        ''' <remarks></remarks>
        Sub New(ByVal retId As Integer, ByVal mktId As Integer, ByVal publicationId As Integer, ByVal adDate As DateTime, ByVal mediaList As System.Collections.Generic.List(Of String), ByVal languageId As Nullable(Of Integer), ByVal applyOverrideRestriction As Boolean, ByVal formName As String)

            InitializeComponent()

            m_retId = retId
            m_mktId = mktId
            m_pubId = publicationId
            m_adDate = adDate
            m_mediaText = GetMediaText(mediaList)
            m_startDate = Nothing
            m_endDate = Nothing
            m_languageId = languageId
            m_thumbnailList = New System.Collections.Generic.List(Of String)

            dupcheckConditionLabel.Text = "Start date: NA, End date: NA."

            m_areImagesAvailable = True
            m_applyOverrideRestriction = applyOverrideRestriction
            m_formName = formName
        End Sub

        ''' <summary>
        ''' Overloaded constructor for Non FSI and ROP.
        ''' </summary>
        ''' <remarks></remarks>
        Sub New(ByVal retId As Integer, ByVal mktId As Integer, ByVal adDate As DateTime, ByVal mediaList As System.Collections.Generic.List(Of String), ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal languageId As Nullable(Of Integer), ByVal applyOverrideRestriction As Boolean, ByVal formName As String)

            InitializeComponent()

            m_retId = retId
            m_mktId = mktId
            m_adDate = adDate
            m_mediaText = GetMediaText(mediaList)
            m_startDate = startDate
            m_endDate = endDate
            m_languageId = languageId
            m_thumbnailList = New System.Collections.Generic.List(Of String)

            If m_startDate = Nothing Then
                dupcheckConditionLabel.Text = "Start date: NA"
            Else
                dupcheckConditionLabel.Text = "Start date: " + m_startDate.ToString("MM/dd/yyyy")
            End If

            If m_endDate = Nothing Then
                dupcheckConditionLabel.Text += ", End date: NA."
            Else
                dupcheckConditionLabel.Text += ", End date: " + m_endDate.ToString("MM/dd/yyyy")
            End If

            m_areImagesAvailable = True
            m_applyOverrideRestriction = applyOverrideRestriction
            m_formName = formName
        End Sub

#End Region



        ''' <summary>
        ''' Loads image files in thumbnail image list.
        ''' </summary>
        ''' <param name="filesArray">String array, containing path to thumbnail page images.</param>
        ''' <param name="thumbnails">True if array contains path of thumbnails, false otherwise.</param>
        ''' <remarks></remarks>
        Private Sub ShowThumbnails(ByVal filesArray() As String, ByVal thumbnails As Boolean)
            Dim notFound, noThumbnail As String


            notFound = System.IO.Path.GetTempFileName()
            noThumbnail = System.IO.Path.GetTempFileName()

            My.Resources.NotFound.Save(notFound)
            My.Resources.NoThumbnail.Save(noThumbnail)


            'count total rows needed
            If (filesArray.Length / 5) < 1 Then
                numRows = 1
            Else
                numRows = CInt((filesArray.Length / 5)) + 1
            End If

            'add columns
            For index As Integer = 0 To 4
                Dim dataGridViewColumn As New DataGridViewImageColumn()

                dgThumbnails.Columns.Add(dataGridViewColumn)
                dgThumbnails.Columns(index).Width = 120
            Next

            'add rows
            For index As Integer = 0 To numRows - 1
                If index <> numRows - 1 Then dgThumbnails.Rows.Add()
                dgThumbnails.Rows(index).Height = 220
            Next

            rowIndex = 0
            columnIndex = 0

            For i As Integer = 0 To filesArray.Length - 1
                Try
                    If System.IO.File.Exists(filesArray(i)) = False Then
                        LoadThumbnailImages(filesArray(i))
                        Me.AreImagesAvailable = False
                    ElseIf thumbnails = False AndAlso i > 0 Then  'Display first unsized page image.
                        LoadThumbnailImages(filesArray(i))
                    Else
                        LoadThumbnailImages(filesArray(i))
                    End If

                Catch ex As Exception
                    Trace.TraceError("DupCheckForm.ShowThumbnails. Message=" + ex.Message, New Object() {"FileArrayLength=", filesArray.Length, "Thumbnails=", thumbnails.ToString(), "i=", i, "File=", filesArray(i)})
                    MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                ThumbnailList.Add(filesArray(i))
            Next

            'clear the columns with empty image
            If rowIndex <= numRows - 1 Then
                For ictr As Integer = columnIndex To 4
                    Dim bmp As Bitmap = New Bitmap(100, 200)
                    dgThumbnails.Rows(rowIndex).Cells(ictr).Value = bmp
                    dgThumbnails.Rows(rowIndex).Cells(ictr).ToolTipText = ""
                Next
            End If
            If System.IO.File.Exists(notFound) Then System.IO.File.Delete(notFound)
            If System.IO.File.Exists(noThumbnail) Then System.IO.File.Delete(noThumbnail)

            notFound = Nothing
            noThumbnail = Nothing
            filesArray = Nothing
        End Sub

#Region "Loading Thumbnails"
        Private Sub LoadThumbnailImages(ByVal _file As String)
            Dim _numberPreviewImages As Integer = 100

            Dim numColumnsForWidth As Integer = (dgThumbnails.Width - 50) \ (_imageSize + 100)
            
            Dim numImagesRequired As Integer = 0
            Try
                If rowIndex > dgThumbnails.Rows.Count - 1 Then Exit Sub
                'add image in the datagrid
                Dim image As Image = image.FromFile(_file)
                Dim newImage As Image = image.GetThumbnailImage(100, 200, Nothing, IntPtr.Zero)

                dgThumbnails.Rows(rowIndex).Cells(columnIndex).Value = newImage
                dgThumbnails.Rows(rowIndex).Cells(columnIndex).ToolTipText = _file

                If columnIndex = 4 Then
                    rowIndex += 1
                    columnIndex = 0
                Else
                    columnIndex += 1
                End If
            Catch ex As Exception
                MsgBox(Err.Description)
                Console.WriteLine(ex)
            End Try
        End Sub
#End Region

        ''' <summary>
        ''' Returns string in XML format based on supplied collection of string.
        ''' </summary>
        ''' <param name="mediaList">Collection of media types</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetMediaText(ByVal mediaList As System.Collections.Generic.List(Of String)) As String
            Dim mediaText As System.Text.StringBuilder


            mediaText = New System.Text.StringBuilder()

            mediaText.Append("<MediaList>")
            For i As Integer = 0 To mediaList.Count - 1
                mediaText.Append("<Media>")
                mediaText.Append(mediaList(i))
                mediaText.Append("</Media>")
            Next
            mediaText.Append("</MediaList>")

            Return mediaText.ToString()

        End Function

        ''' <summary>
        ''' Checks whether vehicle images are available for all vehicles.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CheckImageAvailablityOfAllVehicles() As Boolean
            Dim isImageAvailable As Boolean
            Dim vehicleId, pageCount As Integer
            Dim createDt As DateTime
            Dim fileArray() As String
            Dim imagePath As System.Text.StringBuilder


            If Me.dupCheckDataGridView.Rows.Count < 1 Then Return False

            imagePath = New System.Text.StringBuilder()
            isImageAvailable = True

            For i As Integer = 0 To Me.dupCheckDataGridView.Rows.Count - 1
                vehicleId = Me.dupCheckDataGridView.Columns("CreateDt").Index
                createDt = CType(Me.dupCheckDataGridView.Rows(i).Cells(vehicleId).Value, DateTime)
                vehicleId = Me.dupCheckDataGridView.Columns("VehicleId").Index
                vehicleId = CType(Me.dupCheckDataGridView.Rows(i).Cells(vehicleId).Value, Integer)
                If Me.dupCheckDataGridView.Columns.Contains("ActualPageCount") Then
                    pageCount = Me.dupCheckDataGridView.Columns("ActualPageCount").Index
                    pageCount = CType(Me.dupCheckDataGridView.Rows(i).Cells(pageCount).Value, Integer)
                ElseIf Me.dupCheckDataGridView.Columns.Contains("PullPageCount") Then
                    pageCount = Me.dupCheckDataGridView.Columns("PullPageCount").Index
                    If String.IsNullOrEmpty(Me.dupCheckDataGridView.Rows(i).Cells(pageCount).Value.ToString) = False Then
                        pageCount = CType(Me.dupCheckDataGridView.Rows(i).Cells(pageCount).Value, Integer)
                    Else
                        pageCount = 0
                    End If
                Else
                    pageCount = -1
                End If

                Processor.LoadPageImageInformation(vehicleId)

                Try
                    imagePath.Append(VehicleImageFolderPath)
                    imagePath.Append("\")
                    imagePath.Append(createDt.ToString("yyyyMM"))
                    imagePath.Append("\")
                    imagePath.Append(vehicleId.ToString())
                    imagePath.Append("\")
                    imagePath.Append(ThumbSizedPageImageFolderName)
                    If System.IO.Directory.Exists(imagePath.ToString()) = False Then
                        imagePath.Remove(0, imagePath.Length)
                        imagePath.Append(VehicleImageFolderPath)
                        imagePath.Append("\")
                        imagePath.Append(createDt.ToString("yyyyMM"))
                        imagePath.Append("\")
                        imagePath.Append(vehicleId.ToString())
                        imagePath.Append("\")
                        imagePath.Append(UnsizedPageImageFolderName)
                    End If
                    isImageAvailable = System.IO.Directory.Exists(imagePath.ToString())
                    If isImageAvailable = False Then Exit For

                    fileArray = System.IO.Directory.GetFiles(imagePath.ToString(), "*.jpg")

                    For j As Integer = 0 To Processor.DupCheckDataSet.Page.Count - 1
                        'isImageAvailable = System.IO.File.Exists(imagePath.ToString() + "\" + Processor.DupCheckDataSet.Page(j).ImageName + ".jpg")
                        isImageAvailable = fileArray.Contains(imagePath.ToString() + "\" + Processor.DupCheckDataSet.Page(j).ImageName + ".jpg")
                        If isImageAvailable = False Then Exit For
                    Next

                Catch ex As Exception
                    isImageAvailable = False
                    Trace.TraceError("DupCheckForm.CheckImageAvailablityOfAllVehicles. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, "CreateDt=", createDt, "RowIndex=", i})
                    MessageBox.Show("Can not load Page images. An error has occurred while loading Page images." _
                                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                If isImageAvailable = False Then Exit For
            Next


            Return isImageAvailable

        End Function


#Region " IForm Implementation "


        Public Event InitializingForm() Implements IForm.InitializingForm
        Public Event FormInitialized() Implements IForm.FormInitialized

        Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
        Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied


        Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

        End Sub

        Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

            RaiseEvent InitializingForm()

            Me.SuspendLayout()

            Me.StatusMessage = "Loading information. This may take some time. Please wait..."

            Me.FormState = formStatus
            m_isDuplicate = False
            m_isOverride = False
            m_isOverride = False

            m_dupCheckProcessor = New UI.Processors.DupCheck
            Processor.Initialize()
            Processor.LogFormCall(m_formName)

            LoadAndBindDataGridView(m_mediaText)

            Me.StatusMessage = "Information loaded. Preparing to show information on window."

            SetDataGridView()

            Me.StatusMessage = "Loading vehicle page image thumbnails."

            LoadThumbnailsForDataGridViewRow(0)

            Me.StatusMessage = "Checking for vehicle page image."

            Me.AreImagesAvailable = CheckImageAvailablityOfAllVehicles()

            If Me.ApplyOverrideRestriction Then
                Dim isAdmin As Boolean
                Dim isOvNDup As Integer

                'isAdmin = Processor.IsApplicationUserAdministrator()
                isOvNDup = Processor.IsValidOverideNotADupUser
                If isOvNDup = 1 OrElse Me.AreImagesAvailable Then
                    Me.overrideButton.Enabled = True
                Else
                    Me.overrideButton.Enabled = False
                End If
            End If

            Me.StatusMessage = String.Empty

            Me.ResumeLayout(False)

            RaiseEvent FormInitialized()

        End Sub


#End Region


        Private Sub LoadPossibleDuplicateFSI(ByVal retailerId As Integer, ByVal marketId As Integer, ByVal adDate As DateTime, ByVal mediaText As String, ByVal languageId As Integer?, ByVal dateRange As Integer)

            Try
                Processor.LoadPossibleDuplicateFSI(retailerId, marketId, adDate, mediaText, languageId, dateRange)
            Catch ex As Exception
                Trace.TraceError("DupCheckForm.LoadPossibleDuplicateFSI. Message=" + ex.Message, New Object() {"RetId=", retailerId, "MktId=", marketId, "Ad date=", adDate, "Media Text=", mediaText, "LanguageId=", languageId, "DateRange=", dateRange})
                Throw
            End Try

            If Me.RemoveVehicle > 0 Then

                Dim tempRow As DupCheckDataSet.mt_proc_GetPossibleDuplicateFSIRow

                tempRow = Processor.DupCheckDataSet.mt_proc_GetPossibleDuplicateFSI.FindByVehicleID(Me.RemoveVehicle)
                If tempRow IsNot Nothing Then
                    tempRow.Delete()
                    Processor.DupCheckDataSet.mt_proc_GetPossibleDuplicateFSI.AcceptChanges()
                End If

                tempRow = Nothing

                Processor.UpdateVehicleId(Me.RemoveVehicle)
            End If

            Processor.LogDupCheckProcess(dateRange)
            Dim queryVehicleId As System.Collections.Generic.IEnumerable(Of Integer)
            queryVehicleId = From v In Processor.DupCheckDataSet.mt_proc_GetPossibleDuplicateFSI _
                             Select v.VehicleID
            If queryVehicleId.Count() > 0 Then
                Processor.LogDupCheckResults(queryVehicleId.ToArray())
            End If
            queryVehicleId = Nothing

        End Sub

        Private Sub LoadPossibleDuplicateROP(ByVal retailerId As Integer, ByVal marketId As Integer, ByVal publicationId As Integer, ByVal adDate As DateTime, ByVal mediaText As String, ByVal languageId As Integer?, ByVal dateRange As Integer)

            Try
                Processor.LoadPossibleDuplicateROP(retailerId, marketId, publicationId, adDate, mediaText, languageId, dateRange)
            Catch ex As Exception
                Trace.TraceError("DupCheckForm.LoadPossibleDuplicateROP. Message=" + ex.Message, New Object() {"RetId=", retailerId, "MktId=", marketId, "Publication=", publicationId, "Ad date=", adDate, "Media Text=", mediaText, "LanguageId=", languageId, "DateRange=", dateRange})
                Throw
            End Try

            If Me.RemoveVehicle > 0 Then
                Dim tempRow As DupCheckDataSet.mt_proc_GetPossibleDuplicateROPRow

                tempRow = Processor.DupCheckDataSet.mt_proc_GetPossibleDuplicateROP.FindByVehicleID(Me.RemoveVehicle)
                If tempRow IsNot Nothing Then
                    tempRow.Delete()
                    Processor.DupCheckDataSet.mt_proc_GetPossibleDuplicateROP.AcceptChanges()
                End If

                tempRow = Nothing

                Processor.UpdateVehicleId(Me.RemoveVehicle)
            End If

            Processor.LogDupCheckProcess(dateRange)
            Dim queryVehicleId As System.Collections.Generic.IEnumerable(Of Integer)
            queryVehicleId = From v In Processor.DupCheckDataSet.mt_proc_GetPossibleDuplicateROP _
                             Select v.VehicleID
            If queryVehicleId.Count() > 0 Then
                Processor.LogDupCheckResults(queryVehicleId.ToArray())
            End If
            queryVehicleId = Nothing

        End Sub

        Private Sub LoadPossibleDuplicateNonFSIROP(ByVal retailerId As Integer, ByVal marketId As Integer, ByVal adDate As DateTime, ByVal mediaText As String, ByVal startDate As DateTime?, ByVal endDate As DateTime?, ByVal languageId As Integer?, ByVal dateRange As Integer)

            Try
                If startDate.HasValue = False And endDate.HasValue = False Then
                    Processor.LoadPossibleDuplicateNonFSIROP(retailerId, marketId, adDate, mediaText, Nothing, Nothing, languageId, dateRange)
                ElseIf startDate.HasValue = False Then
                    Processor.LoadPossibleDuplicateNonFSIROP(retailerId, marketId, adDate, mediaText, Nothing, endDate.Value, languageId, dateRange)
                ElseIf endDate.HasValue = False Then
                    Processor.LoadPossibleDuplicateNonFSIROP(retailerId, marketId, adDate, mediaText, startDate.Value, Nothing, languageId, dateRange)
                Else
                    Processor.LoadPossibleDuplicateNonFSIROP(retailerId, marketId, adDate, mediaText, startDate.Value, endDate.Value, languageId, dateRange)
                End If
            Catch ex As Exception
                Trace.TraceError("DupCheckForm.LoadPossibleDuplicateNonFSIROP. Message=" + ex.Message, New Object() {"RetId=", retailerId, "MktId=", marketId, "Ad date=", adDate, "Media Text=", mediaText, "Start date=", startDate, "End date=", endDate, "LanguageId=", languageId, "DateRange=", dateRange})
                Throw
            End Try

            If Me.RemoveVehicle > 0 Then
                Dim tempRow As DupCheckDataSet.mt_proc_GetPossibleDuplicateNonFSIROPRow

                tempRow = Processor.DupCheckDataSet.mt_proc_GetPossibleDuplicateNonFSIROP.FindByVehicleID(Me.RemoveVehicle)
                If tempRow IsNot Nothing Then
                    tempRow.Delete()
                    Processor.DupCheckDataSet.mt_proc_GetPossibleDuplicateNonFSIROP.AcceptChanges()
                End If

                tempRow = Nothing

                Processor.UpdateVehicleId(Me.RemoveVehicle)
            End If

            Processor.LogDupCheckProcess(dateRange)
            Dim queryVehicleId As System.Collections.Generic.IEnumerable(Of Integer)
            queryVehicleId = From v In Processor.DupCheckDataSet.mt_proc_GetPossibleDuplicateNonFSIROP _
                             Select v.VehicleID
            If queryVehicleId.Count() > 0 Then
                Processor.LogDupCheckResults(queryVehicleId.ToArray())
            End If
            queryVehicleId = Nothing

        End Sub

        Private Sub LoadAndBindDataGridView(ByVal mediaText As String)

            dupCheckDataGridView.DataSource = Nothing

            If mediaText.ToUpper().IndexOf("FSI") > 0 Then
                LoadPossibleDuplicateFSI(m_retId, m_mktId, m_adDate, m_mediaText, m_languageId, CType(dateRangeNumericUpDown.Value, Integer))
                dupCheckDataGridView.DataSource = Processor.DupCheckDataSet.mt_proc_GetPossibleDuplicateFSI
                m_isPossibleDuplicateRecordsFound = (Processor.DupCheckDataSet.mt_proc_GetPossibleDuplicateFSI.Count > 0)

            ElseIf mediaText.ToUpper().IndexOf("ROP - CIRCULAR") < 0 AndAlso mediaText.ToUpper().IndexOf("ROP") > 0 Then
                LoadPossibleDuplicateROP(m_retId, m_mktId, m_pubId, m_adDate, m_mediaText, m_languageId, CType(dateRangeNumericUpDown.Value, Integer))
                dupCheckDataGridView.DataSource = Processor.DupCheckDataSet.mt_proc_GetPossibleDuplicateROP
                m_isPossibleDuplicateRecordsFound = (Processor.DupCheckDataSet.mt_proc_GetPossibleDuplicateROP.Count > 0)

            Else
                LoadPossibleDuplicateNonFSIROP(m_retId, m_mktId, m_adDate, m_mediaText, m_startDate, m_endDate, m_languageId, CType(dateRangeNumericUpDown.Value, Integer))
                dupCheckDataGridView.DataSource = Processor.DupCheckDataSet.mt_proc_GetPossibleDuplicateNonFSIROP
                m_isPossibleDuplicateRecordsFound = (Processor.DupCheckDataSet.mt_proc_GetPossibleDuplicateNonFSIROP.Count > 0)
            End If

            'In this case, FormClosing even will not fire. Hence, have to update here only.
            If Me.IsPossibleDuplicateRecordsFound = False Then Processor.UpdateActionTaken("NoPossibleDuplicates")

        End Sub

        Private Sub SetDataGridView()
            Dim columnCounter, columnWidth As Integer

            If dupCheckDataGridView.Columns.Contains("CouponInd") Then
                dupCheckDataGridView.Columns("CouponInd").Visible = False
            End If
            dupCheckDataGridView.Columns("CreatedById").Visible = False
            dupCheckDataGridView.Columns("SizeId").Visible = False

            dupCheckDataGridView.Columns("VehicleID").HeaderText = "Vehicle ID"
            dupCheckDataGridView.Columns("VehicleStatus").HeaderText = "Status"
            dupCheckDataGridView.Columns("BreakDt").HeaderText = "Ad Date"
            dupCheckDataGridView.Columns("StartDt").HeaderText = "Start Date"
            dupCheckDataGridView.Columns("EndDt").HeaderText = "End Date"
            dupCheckDataGridView.Columns("CreateDt").HeaderText = "Create Date"
            dupCheckDataGridView.Columns("CreatedBy").HeaderText = "Created By"
            If dupCheckDataGridView.Columns.Contains("ActualPageCount") Then
                dupCheckDataGridView.Columns("ActualPageCount").HeaderText = "Pages"
            Else  'For ROP/Magazine only.
                If dupCheckDataGridView.Columns.Contains("CheckInPageCount") Then
                    dupCheckDataGridView.Columns("CheckInPageCount").HeaderText = "Pages"
                End If
            End If
            If dupCheckDataGridView.Columns.Contains("CheckInPageCount") Then
                dupCheckDataGridView.Columns("PullPageCount").HeaderText = "Pages"
            End If

                columnWidth = dupCheckDataGridView.ClientSize.Width - dupCheckDataGridView.RowHeadersWidth
                columnCounter = dupCheckDataGridView.Columns("CreatedBy").Index 'Hide all columns after this column.
                columnWidth \= columnCounter 'To avoid Id columns count.
                If columnWidth < 100 Then columnWidth = 100

                For columnCounter = 0 To columnCounter  'Hiding columns after CreatedBy
                    dupCheckDataGridView.Columns(columnCounter).Width = columnWidth
                Next

                For columnCounter = columnCounter To dupCheckDataGridView.ColumnCount - 1
                    dupCheckDataGridView.Columns(columnCounter).Visible = False
                Next

        End Sub

        Private Sub LoadVehiclePagesThumbnails(ByVal vehicleId As Integer, ByVal createDt As DateTime)
            Dim isThumbnailAvailable As Boolean = True
            Dim pageImageFolderPath As String


            ThumbnailList.Clear()

            pageImageFolderPath = VehicleImageFolderPath + "\" + createDt.ToString("yyyyMM") _
                                  + "\" + vehicleId.ToString() + "\" + ThumbSizedPageImageFolderName
            If System.IO.Directory.Exists(pageImageFolderPath) = False Then
                isThumbnailAvailable = False
                pageImageFolderPath = VehicleImageFolderPath + "\" + createDt.ToString("yyyyMM") _
                                      + "\" + vehicleId.ToString() + "\" + UnsizedPageImageFolderName
            End If

            If System.IO.Directory.Exists(pageImageFolderPath) = False Then
                imageNotAvailableLabel.Show()
                pageImageFolderPath = Nothing
                m_areImagesAvailable = False
                Exit Sub
            End If

            If imageNotAvailableLabel.Visible Then imageNotAvailableLabel.Hide()

            Dim thumbnailQuery As System.Collections.Generic.IEnumerable(Of String)
            thumbnailQuery = From pageRow In Processor.DupCheckDataSet.Page _
                             Select pageImageFolderPath + "\" + pageRow.ImageName + ".jpg"
            ShowThumbnails(thumbnailQuery.ToArray(), isThumbnailAvailable)
            thumbnailQuery = Nothing

            pageImageFolderPath = Nothing

        End Sub

        Private Sub LoadThumbnailsForDataGridViewRow(ByVal rowIndex As Integer)
            Dim vehicleId As Integer, createDt As DateTime


            If Me.dupCheckDataGridView.Rows.Count < 1 OrElse rowIndex < 0 Then Exit Sub

            vehicleId = Me.dupCheckDataGridView.Columns("CreateDt").Index
            createDt = CType(Me.dupCheckDataGridView.Rows(rowIndex).Cells(vehicleId).Value, DateTime)
            vehicleId = Me.dupCheckDataGridView.Columns("VehicleId").Index
            vehicleId = CType(Me.dupCheckDataGridView.Rows(rowIndex).Cells(vehicleId).Value, Integer)

            Try
                Processor.LoadPageImageInformation(vehicleId)
                LoadVehiclePagesThumbnails(vehicleId, createDt)

            Catch ex As System.Data.SqlClient.SqlException
                Trace.TraceError("DupCheckForm.LoadPageImageInformation. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, "RowIndex=", rowIndex, "ErrorClass=", ex.Class, "Procedure=", ex.Procedure, "LineNumber=", ex.LineNumber, "SQLErrorNumber=", ex.State, "ErrorNumber=", ex.Number, "Source=", ex.Source})
                MessageBox.Show("Can not load Page image information. An error has occurred while loading" _
                                + " Page image information from database.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                Trace.TraceError("DupCheckForm.LoadVehiclePagesThumbnails. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, "CreateDt=", createDt, "RowIndex=", rowIndex})
                MessageBox.Show("Can not load Page images. An error has occurred while loading Page images." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        Private Function PrepareURL(ByVal possibleDupRow As System.Data.DataRowView) As String
            Dim tempDate As DateTime
            Dim urlText As System.Text.StringBuilder


            urlText = New System.Text.StringBuilder()
            urlText.Append("adresultsDE.asp?Call=Dup")
            urlText.Append("&date1=")
            urlText.Append(System.Web.HttpUtility.UrlEncode(tempDate.ToString("MM/dd/yy")))
            urlText.Append("&Advertiser=")
            urlText.Append(System.Web.HttpUtility.UrlEncode(possibleDupRow("Retailer").ToString()))
            urlText.Append("&Market=")
            urlText.Append(System.Web.HttpUtility.UrlEncode(possibleDupRow("Market").ToString()))
            urlText.Append("&SDate=")
            If possibleDupRow("StartDt").ToString().Length = 0 Then
                urlText.Append(System.Web.HttpUtility.UrlEncode("__/__/__"))
            Else
                urlText.Append(System.Web.HttpUtility.UrlEncode(possibleDupRow("StartDt").ToString()))
            End If
            urlText.Append("&EDate=")
            If possibleDupRow("EndDt").ToString().Length = 0 Then
                urlText.Append(System.Web.HttpUtility.UrlEncode("__/__/__"))
            Else
                urlText.Append(System.Web.HttpUtility.UrlEncode(possibleDupRow("EndDt").ToString()))
            End If

            Return urlText.ToString()

        End Function


        Private Sub DupCheckForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If Me.IsOverride Then
                Processor.UpdateActionTaken("Override")
            ElseIf Me.IsReview Then
                Processor.UpdateActionTaken("Review")
            ElseIf Me.IsDuplicate Then
                Processor.UpdateActionTaken("Duplicate")
            ElseIf Me.IsPossibleDuplicateRecordsFound = False Then
                Processor.UpdateActionTaken("NoPossibleDuplicates")
            Else
                Processor.UpdateActionTaken("Closed")
            End If

        End Sub

        Private Sub refreshButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles refreshButton.Click

            RaiseEvent RefreshingPossibleDuplicateRecords()

            LoadAndBindDataGridView(m_mediaText)
            SetDataGridView()

            If dupCheckDataGridView.Rows.Count > 0 Then
                m_areImagesAvailable = True
                If dupCheckDataGridView.SelectedRows.Count = 0 Then dupCheckDataGridView.Rows(0).Selected = True
                LoadThumbnailsForDataGridViewRow(dupCheckDataGridView.SelectedRows(0).Index)

                Me.AreImagesAvailable = CheckImageAvailablityOfAllVehicles()

                If Me.ApplyOverrideRestriction Then
                    Dim isAdmin As Boolean
                    Dim isOvNDup As Integer

                    ' isAdmin = Processor.IsApplicationUserAdministrator()
                    isOvNDup = Processor.IsValidOverideNotADupUser
                    If isOvNDup = 1 OrElse Me.AreImagesAvailable Then
                        Me.overrideButton.Enabled = True
                    Else
                        Me.overrideButton.Enabled = False
                    End If
                End If
            End If

            RaiseEvent PossibleDuplicateRecordsRefreshed()

        End Sub

        Private Sub overrideButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles overrideButton.Click
            Dim UserResponse As System.Windows.Forms.DialogResult


            UserResponse = MessageBox.Show(Me, "I am sure this vehicle is not a duplicate record with these other" _
                                           + " records.", ProductName, MessageBoxButtons.OKCancel, _
                                           MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If UserResponse = DialogResult.OK Then
                m_isOverride = True
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If

        End Sub

        Private Sub reviewButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles reviewButton.Click
            Dim userResponse As System.Windows.Forms.DialogResult


            userResponse = MessageBox.Show(Me, "Are you sure you want to mark current vehicle as " _
                                           + "needing review?", ProductName, MessageBoxButtons.YesNo _
                                           , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If userResponse = DialogResult.Yes Then
                m_isReview = True
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If

        End Sub

        Private Sub DuplicateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles duplicateButton.Click
            Dim UserResponse As System.Windows.Forms.DialogResult


            UserResponse = MessageBox.Show(Me, "Are you sure you want to mark the current vehicle as a duplicate?" _
                                           , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                           , MessageBoxDefaultButton.Button2)

            If UserResponse = DialogResult.Yes Then
                m_isDuplicate = True
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If

        End Sub

       

        Private Sub printButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles printButton.Click
            Dim selectedVehicle As Data.DataRowView
            Dim bmb As BindingManagerBase


#If DEBUG Then

            If MessageBox.Show("Do you want to print?", Application.ProductName, MessageBoxButtons.YesNo _
                               , MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No _
            Then
                Exit Sub
            End If

#End If

            bmb = Me.BindingContext(Me.dupCheckDataGridView.DataSource)
            selectedVehicle = CType(bmb.Current, System.Data.DataRowView)
            bmb = Nothing

            Try
                Processor.PrintBarcode(selectedVehicle)
            Catch ex As Exception
                Trace.TraceError("DupCheckForm.PrintBarcode. Message=" + ex.Message, New Object() {"DataRow=", selectedVehicle})
                MessageBox.Show("An error has occurred while printing barcode label.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            selectedVehicle = Nothing
        End Sub

        Private Sub dupCheckDataGridView_RowEnter _
            (ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) _
            Handles dupCheckDataGridView.CellMouseClick

            dgThumbnails.Rows.Clear()
            dgThumbnails.Columns.Clear()
            LoadThumbnailsForDataGridViewRow(e.RowIndex)

        End Sub

        Private Sub dgThumbnails_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgThumbnails.CellContentDoubleClick
            Dim xPath As String = dgThumbnails.SelectedCells(0).ToolTipText.ToString
            Dim iViewer As New UI.Controls.ImageViewerForm()
            If dgThumbnails.SelectedCells.Count > 0 And String.IsNullOrEmpty(dgThumbnails.CurrentCell.ToolTipText) = False Then
                xPath = xPath.Replace("Thumb", "Unsized")
                iViewer.LoadImage(xPath)
                iViewer.Show()
            End If
        End Sub

        Private Sub dupCheckDataGridView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dupCheckDataGridView.CellContentClick

        End Sub

        Private Sub dgThumbnails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgThumbnails.CellContentClick

        End Sub
    End Class

End Namespace