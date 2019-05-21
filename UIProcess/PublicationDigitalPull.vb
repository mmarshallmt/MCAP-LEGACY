Namespace UI.Processors


  Public Class PublicationDigitalPull
    Inherits PublicationPull


#Region " PageImageInformation Class "

    Private Class PageImageInformation

      Public IsRequired As Boolean?
      Public ReceivedOrder As Integer
      Public ImageName As String
      Private m_sizeInPixel As System.Drawing.Size


      Public Sub New(ByVal receivedOrder As Integer, ByVal imageName As String, ByVal size As System.Drawing.Size)
        Me.ReceivedOrder = receivedOrder
        Me.ImageName = imageName
        Me.m_sizeInPixel = size
      End Sub

      ''' <summary>
      ''' Gets page size in pixels.
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public ReadOnly Property PageSize() As System.Drawing.Size
        Get
          Return m_sizeInPixel
        End Get
      End Property

      ''' <summary>
      ''' Sets page size.
      ''' </summary>
      ''' <param name="pageSize"></param>
      ''' <remarks></remarks>
      Public Sub SetPageSize(ByVal pageSize As System.Drawing.Size)
        m_sizeInPixel = pageSize
      End Sub

    End Class

#End Region


    Private m_pageInformationCollection As System.Collections.Generic.Dictionary(Of Integer, PageImageInformation)


#Region " Events "

    'Public Shadows Event LoadingVehicle As MCAPCancellableEventHandler
    'Public Shadows Event VehicleLoaded As MCAPEventHandler
    'Public Shadows Event VehicleNotFound As MCAPEventHandler
    'Public Shadows Event InvalidVehicleStatus As MCAPEventHandler

    Public Event LoadingPageInformation As MCAPCancellableEventHandler
    Public Event PageInformationLoaded As MCAPEventHandler
    Public Event PageInformationNotFound As MCAPEventHandler

#End Region


    Public Sub New()
      m_pageInformationCollection = New System.Collections.Generic.Dictionary(Of Integer, PageImageInformation)
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      m_pageInformationCollection.Clear()
      m_pageInformationCollection = Nothing
      MyBase.Dispose(disposing)
    End Sub


    ''' <summary>
    ''' List of page numbers and page image size in pixel.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property PageInformationCollection() As System.Collections.Generic.Dictionary(Of Integer, PageImageInformation)
      Get
        Return m_pageInformationCollection
      End Get
    End Property

    ''' <summary>
    ''' Gets number of image files listed in in-memory page collection.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ImageFileCount() As Integer
      Get
        Return Me.PageInformationCollection.Count
      End Get
    End Property


    ''' <summary>
    ''' Gets path to a vehicle page image file.
    ''' </summary>
    ''' <param name="pageNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Function GetPageImageFilePath(ByVal pageNumber As Integer) As String
      If Me.PageInformationCollection.Keys.Contains(pageNumber) = False Then
        Return Nothing
      End If

      Return Me.PageInformationCollection(pageNumber).ImageName
    End Function


    '''' <summary>
    '''' Loads vehicle information from database into vwPublicationEdition datatable. 
    '''' </summary>
    '''' <param name="vehicleId"></param>
    '''' <param name="formName"></param>
    '''' <remarks></remarks>
    '''' <exception cref="System.ApplicationException">Error has occurred while loading vehicle information from database.</exception>
    'Public Sub LoadVehicle(ByVal vehicleId As Integer, ByVal formName As String)
    '  Dim errorMessage As String
    '  Dim tempAdapter As PublicationPullDataSetTableAdapters.vwPublicationEditionTableAdapter


    '  Using e As MCAP.UI.Processors.CancellableEventArgs = New MCAP.UI.Processors.CancellableEventArgs()
    '    e.Data.Add("VehicleId", vehicleId)
    '    RaiseEvent LoadingVehicle(Me, e)
    '    If e.Cancel Then Exit Sub
    '  End Using

    '  tempAdapter = New PublicationPullDataSetTableAdapters.vwPublicationEditionTableAdapter()
    '  tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

    '  Try

    '    tempAdapter.Fill(Data.vwPublicationEdition, vehicleId, formName, errorMessage)
    '  Catch ex As System.Data.SqlClient.SqlException
    '    Trace.TraceError("PublicationScanQC.LoadVehicle(): Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, "FormName=", formName, ex})
    '    Throw New ApplicationException("Unable to load vehicle information from database.", ex)
    '  Catch ex As Exception
    '    Trace.TraceError("PublicationScanQC.LoadVehicle(): Unknown error. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, "FormName=", formName, ex})
    '    Throw New ApplicationException("Unable to load vehicle information from database.", ex)
    '  Finally
    '    tempAdapter.Dispose()
    '    tempAdapter = Nothing
    '  End Try

    '  If Data.vwPublicationEdition.Count = 0 And errorMessage Is Nothing Then
    '    Using e As MCAP.UI.Processors.EventArgs = New MCAP.UI.Processors.EventArgs()
    '      e.Data.Add("VehicleId", vehicleId)
    '      RaiseEvent VehicleNotFound(Me, e)
    '    End Using
    '  ElseIf Data.vwPublicationEdition.Count = 0 And errorMessage IsNot Nothing Then
    '    Using e As MCAP.UI.Processors.EventArgs = New MCAP.UI.Processors.EventArgs()
    '      e.Data.Add("VehicleId", vehicleId)
    '      e.Data.Add("ErrorMessage", errorMessage)
    '      RaiseEvent InvalidVehicleStatus(Me, e)
    '    End Using
    '  Else
    '    Using e As MCAP.UI.Processors.EventArgs = New MCAP.UI.Processors.EventArgs()
    '      e.Data.Add("VehicleId", vehicleId)
    '      e.Data.Add("ErrorMessage", errorMessage)
    '      e.Data.Add("VehicleRow", Data.vwPublicationEdition(0))
    '      RaiseEvent VehicleLoaded(Me, e)
    '    End Using
    '  End If

    'End Sub


#Region " Page Information Manipulation in Memory "


    ''' <summary>
    ''' Clears collection of image files. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearImageCollection()

      Me.PageInformationCollection.Clear()

    End Sub

    ''' <summary>
    ''' Gets PageType based on supplied page number from current Page datatable.
    ''' </summary>
    ''' <param name="pageNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPageType(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As String
      Dim pageType As String
      Dim pageInfo As System.Data.EnumerableRowCollection(Of PublicationPullDataSet.PageRow)


      pageInfo = From pi In Data.Page _
                 Where pi.VehicleId = vehicleId AndAlso pi.ReceivedOrder = pageNumber _
                 Select pi

      If pageInfo.Count() = 0 Then
        pageType = Nothing
      Else
        Select Case pageInfo(0).PageTypeId
          Case "B"
            pageType = "Base"
          Case "I"
            pageType = "Insert"
          Case "W"
            pageType = "Wrap"
          Case Else
            pageType = "Unknown"
        End Select
      End If

      pageInfo = Nothing

      Return pageType

    End Function

    ''' <summary>
    ''' Gets absolute path to vehicle image folder as per requested image size.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="createDt"></param>
    ''' <param name="imageSize"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetVehicleImageFolderPath(ByVal vehicleId As Integer, ByVal createDt As DateTime, ByVal imageSize As VehicleImageSizeEnum) As String
      Dim imageFilePath As System.Text.StringBuilder


      imageFilePath = New System.Text.StringBuilder()
      imageFilePath.Append(VehicleImageFolderPath)
      imageFilePath.Append("\")
      imageFilePath.Append(createDt.ToString("yyyyMM"))
      imageFilePath.Append("\")
      imageFilePath.Append(vehicleId.ToString())
      imageFilePath.Append("\")
      If imageSize = VehicleImageSizeEnum.Unsized Then
        imageFilePath.Append(UnsizedPageImageFolderName)
      ElseIf imageSize = VehicleImageSizeEnum.Large Then
        imageFilePath.Append(FullSizedPageImageFolderName)
      ElseIf imageSize = VehicleImageSizeEnum.Normal Then
        imageFilePath.Append(MidSizedPageImageFolderName)
      ElseIf imageSize = VehicleImageSizeEnum.Thumbnail Then
        imageFilePath.Append(ThumbSizedPageImageFolderName)
      End If

      Return imageFilePath.ToString()

    End Function

    ''' <summary>
    ''' Prepares PageSize in-memory collection containing page image path and size.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="createDt"></param>
    ''' <remarks></remarks>
    ''' <exception cref=" System.ApplicationException">Error has occurred while loading list of vehicle page image files from file system.</exception>
    Public Sub PreparePageCollection(ByVal vehicleId As Integer, ByVal createDt As DateTime)
      Dim imageCount As Integer
      Dim vehicleImageFolder, imageArray() As String
      Dim pageQuery As System.Data.EnumerableRowCollection(Of PublicationPullDataSet.PageRow)


            vehicleImageFolder = GetVehicleFolderPath(vehicleId, UserLocationId, GetPathType("Master"), VehicleImageSizeEnum.Unsized)     ' new logic that will retrieve data in the image path table
            If String.IsNullOrEmpty(vehicleImageFolder) = True Then vehicleImageFolder = GetVehicleImageFolderPath(vehicleId, createDt, VehicleImageSizeEnum.Unsized)
      If System.IO.Directory.Exists(vehicleImageFolder) = False Then
        Throw New System.ApplicationException("Unsized vehicle page image folder not found. Expected at " + vehicleImageFolder)
      End If

      Try
        imageArray = System.IO.Directory.GetFiles(vehicleImageFolder)
      Catch ex As System.IO.IOException
        Trace.TraceError("PublicationDigitalPull.PreparePageCollection(): Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, "UnsizedVehicleImageFolder=", vehicleImageFolder, ex})
        Throw New ApplicationException("Unable to load list of vehicle page image files from file system.", ex)
      Catch ex As Exception
        Trace.TraceError("PublicationDigitalPull.PreparePageCollection(): Unknown error. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, "UnsizedVehicleImageFolder=", vehicleImageFolder, ex})
        Throw New ApplicationException("Unable to load list of vehicle page image files from file system.", ex)
      End Try

      imageCount = imageArray.Count()
      Me.PageInformationCollection.Clear()

      For i As Integer = 0 To imageCount - 1
        Dim temp As PageImageInformation

        temp = New PageImageInformation(i + 1, imageArray(i), Nothing)
        pageQuery = From pg In Data.Page Where pg.ReceivedOrder = (i + 1)
        If pageQuery.Count() = 1 Then temp.IsRequired = True
        Me.PageInformationCollection.Add(i + 1, temp)
        temp = Nothing
      Next

      pageQuery = Nothing

    End Sub

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

        ''' <summary>
        ''' Gets vehicle folder path based on supplied vehicleId - New Logic.
        ''' </summary>
        ''' <param name="vehicleId">VehicleId whose image folder path is needed.</param>
        ''' <returns>Vehicle image folder path.</returns>
        ''' <exception cref="System.ApplicationException">Raises exception when CreateDt column value is null.</exception>
        ''' <remarks>If vehicle id is not found, zero length string is returned.</remarks>
        Protected Function GetVehicleFolderPath(ByVal vehicleId As Integer, ByVal LocationId As Integer, ByVal PathType As Integer, ByVal imageSize As VehicleImageSizeEnum) As String
            Dim createDt As DateTime
            Dim ImageCommand As System.Data.SqlClient.SqlCommand
            Dim ImageFolderPath As System.Text.StringBuilder
            Dim vehicleCreateDt As Object
            Dim path As String


            ImageCommand = New System.Data.SqlClient.SqlCommand
            ImageFolderPath = New System.Text.StringBuilder

            Try
                With ImageCommand
                    .CommandText = "SELECT CreateDt FROM Vehicle WHERE VehicleId=" + vehicleId.ToString()
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    vehicleCreateDt = .ExecuteScalar()
                End With

            Catch ex As System.Data.SqlClient.SqlException
                My.Application.Log.WriteException(ex)

            Finally
                If ImageCommand.Connection.State <> ConnectionState.Closed Then ImageCommand.Connection.Close()
            End Try


            If (vehicleCreateDt Is Nothing OrElse vehicleCreateDt Is DBNull.Value) Then
                Throw New System.ApplicationException("Invalid vehicle creation date found.")

            Else
                createDt = CType(vehicleCreateDt, DateTime)
                path = GetImagePath(createDt.ToString("yyyyMM"), LocationId, PathType)
                If String.IsNullOrEmpty(path) = False Then
                    ImageFolderPath.Append(path)
                    ImageFolderPath.Append(vehicleId.ToString())
                    ImageFolderPath.Append("\")
                Else
                    path = VehicleImageFolderPath
                    With ImageFolderPath
                        .Append(path)
                        .Append("\")
                        .Append(createDt.ToString("yyyyMM"))
                        .Append("\")
                        .Append(vehicleId.ToString())
                        .Append("\")
                    End With
                End If
                If imageSize = VehicleImageSizeEnum.Unsized Then
                    ImageFolderPath.Append(UnsizedPageImageFolderName)
                ElseIf imageSize = VehicleImageSizeEnum.Large Then
                    ImageFolderPath.Append(FullSizedPageImageFolderName)
                ElseIf imageSize = VehicleImageSizeEnum.Normal Then
                    ImageFolderPath.Append(MidSizedPageImageFolderName)
                ElseIf imageSize = VehicleImageSizeEnum.Thumbnail Then
                    ImageFolderPath.Append(ThumbSizedPageImageFolderName)
                End If
            End If

            ImageCommand.Dispose()
            ImageCommand = Nothing
            vehicleCreateDt = Nothing

            Return ImageFolderPath.ToString()

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


    ''' <summary>
    ''' Set page size in pixel in an in-memory list.
    ''' </summary>
    ''' <param name="pageNumber"></param>
    ''' <param name="pageSize"></param>
    ''' <remarks></remarks>
    ''' <exception cref="System.ApplicationException">PageNumber value is not found as key in collection</exception>
    Public Sub SetPageSizeInPixel(ByVal pageNumber As Integer, ByVal pageSize As System.Drawing.Size)

      If Me.PageInformationCollection.Keys.Contains(pageNumber) = False Then
        Throw New System.ApplicationException("Page number not found.")
      End If

      Me.PageInformationCollection(pageNumber).SetPageSize(pageSize)

    End Sub

    ''' <summary>
    ''' Gets string representing current acceptance status of page image of supplied page number.
    ''' </summary>
    ''' <param name="pageNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <exception cref="System.ApplicationException">Page number not found as key in collection.</exception>
    Public Function GetCurrentPageImageRequirementStatusText(ByVal pageNumber As Integer) As String
      Dim statusText As String


      If Me.PageInformationCollection.Keys.Contains(pageNumber) = False Then
        Throw New System.ApplicationException("Page number not found.")
      End If

      If Me.PageInformationCollection(pageNumber).IsRequired.HasValue = False Then
        statusText = "Unknown"
      ElseIf Me.PageInformationCollection(pageNumber).IsRequired.Value Then
        statusText = "Yes"
      Else
        statusText = "No"
      End If

      Return statusText
    End Function

    ''' <summary>
    ''' Sets current acceptance status of page image for supplied page number.
    ''' </summary>
    ''' <param name="pageNumber"></param>
    ''' <param name="status"></param>
    ''' <remarks></remarks>
    ''' <exception cref="System.ApplicationException">Page number not found as key in collection.</exception>
    Public Sub SetCurrentPageImageRequirementStatus(ByVal pageNumber As Integer, ByVal status As Boolean?)

      If Me.PageInformationCollection.Keys.Contains(pageNumber) = False Then
        Throw New System.ApplicationException("Page number not found.")
      End If

      Me.PageInformationCollection(pageNumber).IsRequired = status

    End Sub

    ''' <summary>
    ''' Returns total number of pages marked as required.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRequiredPageCount() As Integer
      Dim pageCount As Integer
      Dim pageQuery As System.Collections.Generic.IEnumerable(Of PageImageInformation)


      pageQuery = From pi In Me.PageInformationCollection.Values _
                  Where pi.IsRequired.HasValue AndAlso pi.IsRequired = True

      pageCount = pageQuery.Count()

      pageQuery = Nothing

      Return pageCount
    End Function

    ''' <summary>
    ''' Sets page size for supplied page in in-memory collection.
    ''' </summary>
    ''' <param name="pageNumber"></param>
    ''' <param name="pageSize"></param>
    ''' <remarks></remarks>
    Public Sub UpdateCurrentPageImageSizeInPixels(ByVal pageNumber As Integer, ByVal pageSize As System.Drawing.Size)

      If Me.PageInformationCollection.Keys.Contains(pageNumber) = False Then
        Throw New System.ApplicationException("Page number not found.")
      End If

      Me.PageInformationCollection(pageNumber).SetPageSize(pageSize)

    End Sub


#End Region


#Region " Page Information Manipulation with Database "


    ''' <summary>
    ''' Gets number of pages defined for supplied vehicleId in database.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <exception cref="System.ApplicationException">Error has occurred while fetching page count information from database.</exception>
    Public Function HasPagesDefined(ByVal vehicleId As Integer) As Boolean
      Dim pageCount As Integer?
      Dim tempAdapter As MCAP.PublicationPullDataSetTableAdapters.PageTableAdapter


      tempAdapter = New MCAP.PublicationPullDataSetTableAdapters.PageTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      Try
        pageCount = tempAdapter.GetPageCount(vehicleId)
      Catch ex As System.Data.SqlClient.SqlException
        Trace.TraceError("PublicationScanQC.HasPagesDefined(): Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, ex})
        Throw New ApplicationException("Unable to load vehicle page count information from database.", ex)
      Catch ex As Exception
        Trace.TraceError("PublicationScanQC.HasPagesDefined(): Unknown error. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, ex})
        Throw New ApplicationException("Unable to load vehicle page count information from database.", ex)
      Finally
        tempAdapter.Dispose()
        tempAdapter = Nothing
      End Try

      Return (pageCount.HasValue AndAlso pageCount.Value > 0)
    End Function

    ''' <summary>
    ''' Gets number of cropped pages defined for supplied vehicleId in database.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <exception cref="System.ApplicationException">Error has occurred while fetching cropped page count information from database.</exception>
    Public Function HasCroppedPagesDefined(ByVal vehicleId As Integer) As Boolean
      Dim pageCount As Integer?
      Dim tempAdapter As MCAP.PublicationPullDataSetTableAdapters.PageTableAdapter


      tempAdapter = New MCAP.PublicationPullDataSetTableAdapters.PageTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      Try
        pageCount = tempAdapter.GetCroppedPageCount(vehicleId)
      Catch ex As System.Data.SqlClient.SqlException
        Trace.TraceError("PublicationScanQC.HasCroppedPagesDefined(): Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, ex})
        Throw New ApplicationException("Unable to load cropped vehicle page count information from database.", ex)
      Catch ex As Exception
        Trace.TraceError("PublicationScanQC.HasCroppedPagesDefined(): Unknown error. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, ex})
        Throw New ApplicationException("Unable to load cropped vehicle page count information from database.", ex)
      Finally
        tempAdapter.Dispose()
        tempAdapter = Nothing
      End Try

      Return (pageCount.HasValue AndAlso pageCount.Value > 0)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    ''' <exception cref="System.ApplicationException">Error has occurred while loading vehicle page information from database.</exception>
    Public Shadows Sub LoadVehiclePagesInformation(ByVal vehicleId As Integer)
      Dim tempAdapter As MCAP.PublicationPullDataSetTableAdapters.PageTableAdapter


      tempAdapter = New MCAP.PublicationPullDataSetTableAdapters.PageTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      Try
        tempAdapter.Fill(Data.Page, vehicleId)
      Catch ex As System.Data.SqlClient.SqlException
        Trace.TraceError("PublicationScanQC.LoadVehiclePagesInformation(): Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, ex})
        Throw New ApplicationException("Unable to load vehicle information from database.", ex)
      Catch ex As Exception
        Trace.TraceError("PublicationScanQC.LoadVehiclePagesInformation(): Unknown error. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, ex})
        Throw New ApplicationException("Unable to load vehicle information from database.", ex)
      Finally
        tempAdapter.Dispose()
        tempAdapter = Nothing
      End Try

    End Sub

    ''' <summary>
    ''' Updates PullPageCount column information of vehicle and create rows in Page table.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="pageCount"></param>
    ''' <param name="formName"></param>
    ''' <remarks></remarks>
    ''' <exception cref="System.ApplicationException">Supplied vehicleId is not available in vwPublicationEdition DataTable.</exception>
    Public Sub InsertVehiclePageInformation(ByVal vehicleId As Integer, ByVal pageCount As Integer, ByVal formName As String)
      Dim tempRow As MCAP.PublicationPullDataSet.vwPublicationEditionRow
      Dim tempAdapter As MCAP.PublicationPullDataSetTableAdapters.vwPublicationEditionTableAdapter


      tempAdapter = New MCAP.PublicationPullDataSetTableAdapters.vwPublicationEditionTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      tempRow = Data.vwPublicationEdition.FindByVehicleId(vehicleId)
      If tempRow Is Nothing Then
        Throw New System.ApplicationException("Vehicle information not found.")
      End If
      tempRow.PullPageCount = pageCount
      tempAdapter.Update(Data.vwPublicationEdition)
      tempAdapter.UpdatePublicationPages(vehicleId, formName)

      tempAdapter.Dispose()
      tempAdapter = Nothing
      tempRow = Nothing
    End Sub

    ''' <summary>
    ''' Returns true indicating whether changes in Page table are done successfully for page image split, false otherwise.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="currentPage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AddSplittedPageImageInformationInDatabase(ByVal vehicleId As Integer, ByVal currentPage As Integer) As Boolean
      Dim isPageImageSplit As Boolean
      Dim tempAdapter As MCAP.PublicationPullDataSetTableAdapters.PageTableAdapter


      tempAdapter = New MCAP.PublicationPullDataSetTableAdapters.PageTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      tempAdapter.AddSplitPageImageDetail(vehicleId, currentPage, isPageImageSplit)
      tempAdapter.Dispose()
      tempAdapter = Nothing

      Return isPageImageSplit
    End Function

    Private Function GetImageFileNameForPageNumber(ByVal vehicleId As Integer, ByVal createDt As DateTime, ByVal pageNumber As Integer) As String
      Dim imageFilePath As System.Text.StringBuilder


      imageFilePath = New System.Text.StringBuilder()
      imageFilePath.Append(GetVehicleImageFolderPath(vehicleId, createDt, VehicleImageSizeEnum.Unsized))
      imageFilePath.Append("\")
      imageFilePath.Append(pageNumber.ToString("000"))
      imageFilePath.Append(ImageFileExtension)

      Return imageFilePath.ToString()
    End Function

    ''' <summary>
    ''' Updates Page image size in pixels in database.
    ''' </summary>
    ''' <param name="vehicleId">Page image belongs to this VehicleId.</param>
    ''' <param name="createDt">Ad date of the VehicleId.</param>
    ''' <remarks></remarks>
    Public Sub UpdatePageSizesInPixel(ByVal vehicleId As Integer, ByVal createDt As DateTime)
      Dim receivedOrder, pageCount As Integer
      Dim pageQuery As System.Data.EnumerableRowCollection(Of PublicationPullDataSet.PageRow)
      Dim pageAdapter As MCAP.PublicationPullDataSetTableAdapters.PageTableAdapter


      receivedOrder = 0
      pageCount = Me.PageInformationCollection.Count

      For i As Integer = 1 To pageCount
        If Me.PageInformationCollection(i).IsRequired.HasValue <> True _
          OrElse Me.PageInformationCollection(i).IsRequired <> True Then

          '' ''Dim imagePath As String = GetImageFileNameForPageNumber(vehicleId, createDt, i)
          Dim imagePath As String = Me.PageInformationCollection(i).ImageName
          If System.IO.File.Exists(imagePath) Then System.IO.File.Delete(imagePath)
          Continue For
        End If

        receivedOrder += 1

        pageQuery = From pg In Data.Page _
                    Where pg.ReceivedOrder = receivedOrder

        If pageQuery.Count() = 0 Then Continue For

        If System.IO.Path.GetFileNameWithoutExtension(Me.PageInformationCollection(i).ImageName) <> receivedOrder.ToString("000") Then
          Dim imagePath As String = GetImageFileNameForPageNumber(vehicleId, createDt, receivedOrder)
          ' '' ''If System.IO.File.Exists(imagePath) Then System.IO.File.Delete(imagePath)
          System.IO.File.Move(Me.PageInformationCollection(i).ImageName, imagePath)
          If System.IO.File.Exists(Me.PageInformationCollection(i).ImageName) Then System.IO.File.Delete(Me.PageInformationCollection(i).ImageName)

          imagePath = Nothing
        End If

        pageQuery(0).PixelHieght = Me.PageInformationCollection(i).PageSize.Height
        pageQuery(0).PixelWidth = Me.PageInformationCollection(i).PageSize.Width
      Next

      pageAdapter = New MCAP.PublicationPullDataSetTableAdapters.PageTableAdapter()
      pageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      Try
        pageAdapter.Update(Data.Page)
      Catch ex As System.Data.SqlClient.SqlException
        Trace.TraceError("PublicationDigitalPull.UpdatePageSizesInPixel(): Message=" + ex.Message, New Object() {ex})
        Throw New System.ApplicationException("Unable to update page dimension in database.", ex)
      Catch ex As System.Exception
        Trace.TraceError("PublicationDigitalPull.UpdatePageSizesInPixel(): Unknown error. Message=" + ex.Message, New Object() {ex})
        Throw New System.ApplicationException("Unable to update page dimension in database.", ex)
      Finally
        pageAdapter.Dispose()
        pageAdapter = Nothing
      End Try

    End Sub

    ''' <summary>
    ''' Marks all publications with same market, publication and ad date as No Ads.
    ''' </summary>
    ''' <param name="MarketId"></param>
    ''' <param name="publicationId"></param>
    ''' <param name="breakDt"></param>
    ''' <param name="formName"></param>
    ''' <remarks></remarks>
    Public Sub MarkWholePublicationsAsNoAds(ByVal MarketId As Integer, ByVal publicationId As Integer, ByVal breakDt As DateTime, ByVal formName As String)
      Dim tempAdapter As MCAP.PublicationPullDataSetTableAdapters.vwPublicationEditionTableAdapter


      tempAdapter = New MCAP.PublicationPullDataSetTableAdapters.vwPublicationEditionTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      tempAdapter.MarkPublicationAsNoAds(UserID, formName, MarketId, publicationId, breakDt)

      tempAdapter.Dispose()
      tempAdapter = Nothing
    End Sub

    ''' <summary>
    ''' Removes all page images, except first page, for publication.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RemoveNoAdsPublicationPageImages()
      Dim pageCount As Integer
      Dim pageQuery As System.Collections.Generic.IEnumerable(Of PageImageInformation)


      pageCount = Me.PageInformationCollection.Count
      If pageCount < 2 Then Exit Sub

      pageQuery = From i In Me.PageInformationCollection.Values _
                  Where i.ReceivedOrder > 1 _
                  Select i
      For i As Integer = 0 To pageQuery.Count() - 1
        If System.IO.File.Exists(pageQuery(i).ImageName) Then
          System.IO.File.Delete(pageQuery(i).ImageName)
        End If
      Next

      pageQuery = Nothing
    End Sub


#End Region


    ''' <summary>
    ''' Updates collection for adding splitted image information in collection.
    ''' </summary>
    ''' <param name="SplitImageIndex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function InsertSplitImageInformation(ByVal SplitImageIndex As Integer) As System.Drawing.Size
      Dim totalPages As Integer
      Dim tempFileName As String
      Dim sizeInPixel As System.Drawing.Size
      Dim tempFileInfo As System.IO.FileInfo
      Dim tempAdd As PageImageInformation


      tempAdd = New PageImageInformation(SplitImageIndex + 1, "", Nothing)

      totalPages = Me.ImageFileCount
      Me.PageInformationCollection.Add(totalPages + 1, tempAdd)
      totalPages = Me.ImageFileCount

      'Update collection details for other images, which comes after the double truck image.
      If totalPages > SplitImageIndex Then
        For i As Integer = totalPages To SplitImageIndex + 2 Step -1
          tempFileInfo = New System.IO.FileInfo(Me.PageInformationCollection(i - 1).ImageName)

          tempFileName = GetNextPageImageFileName(Me.PageInformationCollection(i - 1).ImageName, i - 1)
          tempFileInfo.MoveTo(tempFileName)
          Me.PageInformationCollection(i).ImageName = tempFileName
          Me.PageInformationCollection(i).IsRequired = Me.PageInformationCollection(i - 1).IsRequired
          Me.PageInformationCollection(i).ReceivedOrder = Me.PageInformationCollection(i - 1).ReceivedOrder + 1
          Me.PageInformationCollection(i).SetPageSize(Me.PageInformationCollection(i - 1).PageSize)

          tempFileName = Nothing
          tempFileInfo = Nothing
        Next
      End If

      tempFileName = GetNextPageImageFileName(Me.PageInformationCollection(SplitImageIndex).ImageName, SplitImageIndex)

      If System.IO.File.Exists(Me.PageInformationCollection(SplitImageIndex).ImageName) = True Then
        System.IO.File.Copy(Me.PageInformationCollection(SplitImageIndex).ImageName, tempFileName)
      End If

      sizeInPixel = New System.Drawing.Size(Me.PageInformationCollection(SplitImageIndex).PageSize.Width _
                                            , Me.PageInformationCollection(SplitImageIndex).PageSize.Height)

      Me.PageInformationCollection(SplitImageIndex).SetPageSize(Nothing)
      Me.PageInformationCollection(SplitImageIndex + 1).SetPageSize(Nothing)
      Me.PageInformationCollection(SplitImageIndex + 1).ImageName = tempFileName
      Me.PageInformationCollection(SplitImageIndex + 1).IsRequired = Me.PageInformationCollection(SplitImageIndex).IsRequired
      Me.PageInformationCollection(SplitImageIndex + 1).ReceivedOrder = Me.PageInformationCollection(SplitImageIndex).ReceivedOrder + 1

      tempFileName = Nothing

      Return sizeInPixel

    End Function

    ''' <summary>
    ''' Get next image path based on supplied image file path and page index.
    ''' </summary>
    ''' <param name="ImageFilePath"></param>
    ''' <param name="PageIndex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNextPageImageFileName(ByVal ImageFilePath As String, ByVal PageIndex As Integer) As String
      Dim lastIndexOfPath As Integer
      Dim nextImageFilePath As System.Text.StringBuilder


      lastIndexOfPath = ImageFilePath.LastIndexOf("\")
      nextImageFilePath = New System.Text.StringBuilder(ImageFilePath.Substring(0, lastIndexOfPath + 1))
      nextImageFilePath.Append((PageIndex + 1).ToString("000"))
      nextImageFilePath.Append(ImageFilePath.Substring(lastIndexOfPath + 4, 4))

      Return nextImageFilePath.ToString()

    End Function


  End Class

End Namespace