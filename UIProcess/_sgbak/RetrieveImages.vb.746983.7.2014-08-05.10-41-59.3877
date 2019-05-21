Namespace UI.Processors

    Public Class RetrieveImages
        Inherits BaseClass


        Public Event SearchingForVehicle As MCAPCancellableEventHandler
        Public Event VehicleNotFound As MCAPEventHandler
        Public Event VehicleFound As MCAPEventHandler


        Private m_dataSet As QCDataSet
        Private m_vehicleId, m_pageCount As Integer
        Private m_createDt As DateTime



        Sub New()

            m_dataSet = New QCDataSet()

        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            m_dataSet.Dispose()
            m_dataSet = Nothing
            MyBase.Dispose(disposing)
        End Sub



        Private ReadOnly Property Data() As QCDataSet
            Get
                Return m_dataSet
            End Get
        End Property

        Public ReadOnly Property SearchedVehicleId() As Integer
            Get
                Return m_vehicleId
            End Get
        End Property

        Public ReadOnly Property PageCount() As Integer
            Get
                Return m_pageCount
            End Get
        End Property

        Public ReadOnly Property CreateDate() As DateTime
            Get
                Return m_createDt
            End Get
        End Property

        Public ReadOnly Property ImageFolderName() As String
            Get
                Return UnsizedPageImageFolderName
            End Get
        End Property



        Private Sub LoadVehicle(ByVal vehicleId As Integer)
            Dim vwCircularAdapter As QCDataSetTableAdapters.vwCircularTableAdapter


            vwCircularAdapter = New QCDataSetTableAdapters.vwCircularTableAdapter()
            vwCircularAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            vwCircularAdapter.Fill(Me.Data.vwCircular, vehicleId)
            vwCircularAdapter.Dispose()
            vwCircularAdapter = Nothing

            If Data.vwCircular.Count > 0 Then Exit Sub


            Dim publicationAdapter As QCDataSetTableAdapters.vwPublicationEditionTableAdapter

            publicationAdapter = New QCDataSetTableAdapters.vwPublicationEditionTableAdapter()
            publicationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            publicationAdapter.FillByVehicleId(Me.Data.vwPublicationEdition, vehicleId)
            publicationAdapter.Dispose()
            publicationAdapter = Nothing

        End Sub

        Private Function GetVehicleImageFolderPath(ByVal vehicleId As Integer, ByVal createDt As DateTime) As String
            Dim vehicleImageFolder As String
            Dim path As System.Text.StringBuilder
            Dim tempPath As String

            path = New System.Text.StringBuilder()
            tempPath = GetImagePath(createDt.ToString("yyyyMM"), UserLocationId, GetPathType("Master"))
            If String.IsNullOrEmpty(tempPath) = False Then
                path.Append(tempPath)
            Else
                path.Append(VehicleImageFolderPath)
                path.Append("\")
                path.Append(createDt.ToString("yyyyMM"))
                path.Append("\")
            End If
            path.Append(vehicleId.ToString())
            path.Append("\")
            path.Append(ImageFolderName)

            vehicleImageFolder = path.ToString()

            path.Remove(0, path.Length)
            path = Nothing

            Return vehicleImageFolder

        End Function

        Private Function GetImagePath(ByVal YearMonth As String, ByVal LocationId As Integer, ByVal PathType As Integer) As String
            Dim imgPathCommand As System.Data.SqlClient.SqlCommand
            Dim obj As Object
            Dim Path As System.Text.StringBuilder


            imgPathCommand = New System.Data.SqlClient.SqlCommand
            Path = New System.Text.StringBuilder

            Try
                With imgPathCommand
                    .CommandText = "SELECT path FROM ImagePath WHERE yearmonth=" + YearMonth + " AND LocationId=" + LocationId.ToString + " AND PathTypeid=" + PathType.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With
                If String.IsNullOrEmpty(CType(obj, String)) = True Then Exit Function
                Path.Append(CType(obj, String))
                Path.Append("\")
                Path.Append(YearMonth)
                Path.Append("\")
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If imgPathCommand.Connection.State <> ConnectionState.Closed Then imgPathCommand.Connection.Close()
            End Try

            Return Path.ToString()
        End Function

        Private Function GetPathType(ByVal _Type As String) As Integer
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As New Object
            Dim _val As Integer

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "Select codeid from vwCode where codedescrip='" + _Type + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With
                If String.IsNullOrEmpty(CType(obj, String)) = False Then _val = CType(obj, Integer)
            Catch ex As Exception
                Throw New ApplicationException("Unable to get the Path Type Id.", ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return _val
        End Function

        Private Sub CopyImageFiles(ByVal sourceFolder As String, ByVal destinationFolder As String)

            If System.IO.Directory.Exists(destinationFolder) Then System.IO.Directory.Delete(destinationFolder, True)

            My.Computer.FileSystem.CopyDirectory(sourceFolder, destinationFolder, True)

        End Sub

#Region "Load Images Based on the Received Order"
        Private Function LoadImagefiles(ByVal vehicleId As Integer) As DataTable
            Dim PageAdapter As QCDataSetTableAdapters.PageTableAdapter

            PageAdapter = New QCDataSetTableAdapters.PageTableAdapter()
            PageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            PageAdapter.FillReceivedOrderByVehicleID(Me.Data.Page, vehicleId)
            PageAdapter.Dispose()
            PageAdapter = Nothing

            Return Me.Data.Page
        End Function
#End Region

        Private Sub RenameImageFiles(ByVal folderPath As String, ByVal VehicleID As Integer)
            Dim pageImageFileCounter As Integer
            Dim filepath As String
            Dim imageName As System.Text.StringBuilder
            Dim FileOrderByReceivedOrder As New DataTable
            Dim xNew As String
            Dim IName As String

            FileOrderByReceivedOrder = LoadImagefiles(VehicleID)

            imageName = New System.Text.StringBuilder()

            For pageImageFileCounter = 0 To FileOrderByReceivedOrder.Rows.Count - 1 ' filepathArray.Length - 1
                IName = FileOrderByReceivedOrder.Rows(pageImageFileCounter).Item(2).ToString
                If String.IsNullOrEmpty(IName) = True Then IName = (pageImageFileCounter + 1).ToString("000") + ImageFileExtension
                imageName.Append((pageImageFileCounter + 1).ToString("000"))
                imageName.Append(ImageFileExtension)
                filepath = folderPath + "\" + FileOrderByReceivedOrder.Rows(pageImageFileCounter).Item(2).ToString + ImageFileExtension
                xNew = folderPath + "\" + imageName.ToString()
                If IName <> imageName.ToString() Then
                    If System.IO.File.Exists(xNew) = False Then
                        My.Computer.FileSystem.RenameFile(filepath, imageName.ToString()) '(filepathArray(pageImageFileCounter), imageName.ToString()
                    ElseIf System.IO.File.Exists(xNew) = True Then
                        System.IO.File.Delete(xNew)
                        My.Computer.FileSystem.RenameFile(filepath, imageName.ToString())
                    End If
                End If
                imageName.Remove(0, imageName.Length)
            Next

            FileOrderByReceivedOrder = Nothing
            imageName = Nothing

        End Sub


        Public Function FindVehicle(ByVal vehicleId As Integer) As Boolean
            Dim isFound As Boolean


            Me.Data.vwCircular.Rows.Clear()
            Me.Data.vwPublicationEdition.Rows.Clear()

            LoadVehicle(vehicleId)

            If Data.vwCircular.Count > 0 OrElse Data.vwPublicationEdition.Count > 0 Then
                isFound = True
                m_vehicleId = vehicleId
                If Data.vwCircular.Count > 0 Then
                    m_createDt = Data.vwCircular(0).CreateDt
                Else
                    m_createDt = Data.vwPublicationEdition(0).CreateDt
                End If
            Else
                isFound = False
                m_vehicleId = -1
                m_createDt = Nothing
            End If

            Me.Data.vwCircular.Rows.Clear()
            Me.Data.vwPublicationEdition.Rows.Clear()


            Return isFound

        End Function

        Public Function CopyImageFiles(ByVal destinationFolder As String) As Boolean
            Dim sourceFolder As String
            Dim isSuccess As Boolean

            sourceFolder = GetVehicleImageFolderPath(Me.SearchedVehicleId, Me.CreateDate)

            If System.IO.Directory.Exists(sourceFolder) = False Then
                MessageBox.Show("Cannot copy vehicle images. Vehicle image folder not found." _
                                + Environment.NewLine + "Expected location: " + sourceFolder _
                                , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                isSuccess = False
            Else

                destinationFolder += "\" + Me.SearchedVehicleId.ToString()

                CopyImageFiles(sourceFolder, destinationFolder)

                RenameImageFiles(destinationFolder, Me.SearchedVehicleId)

                isSuccess = True
            End If

            Return isSuccess
        End Function


    End Class

End Namespace