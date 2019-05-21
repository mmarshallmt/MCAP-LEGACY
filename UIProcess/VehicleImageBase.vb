Namespace UI.Processors


  Public Enum VehicleImageSizeEnum
    Unsized = 1
    Large = 2
    Normal = 3
    Thumbnail = 4
  End Enum



  Public Class VehicleImageBase
    Inherits IndexBase


#Region " Events "

    'Events can be extended to supply necessary information to consumer along with events.
    'Information passed into event can be useful to consumer while processing the event.

    Public Event LoadingVehiclePagesInformation()
    Public Event VehiclePagesInformationLoaded()

    Public Event SynchronizingPageInformation()
    Public Event PageInformationSynchronized()

    Public Event LoadingVehiclePageCropInformation()
    Public Event VehiclePageCropInformationLoaded()

    Public Event ValidatingPageCropInputs()
    Public Event PageCropInputsValidated()

    Public Event SynchronizingPageCropInformation()
    Public Event PageCropInformationSynchronized()

    ''' <summary>
    ''' This event is raised whenever size is not found for supplied width and height.
    ''' </summary>
    ''' <remarks></remarks>
    Public Event SizeNotFound As MCAPEventHandler

#End Region



    Private m_pageAdapter As QCDataSetTableAdapters.PageTableAdapter
    Private m_size As QCDataSetTableAdapters.SizeTableAdapter
    Private m_pageCropInfoAdapter As QCDataSetTableAdapters.PageCropTableAdapter



    Sub New()
      MyBase.New()

      m_pageAdapter = New QCDataSetTableAdapters.PageTableAdapter
      m_size = New QCDataSetTableAdapters.SizeTableAdapter
      m_pageCropInfoAdapter = New QCDataSetTableAdapters.PageCropTableAdapter

    End Sub

  
        'Protected ReadOnly Property AdditionalQcInfo() As QCDataSetTableAdapters.AdditionalQcInfo
        '    Get
        '        Return m_additionalqcinfoAdapter
        '    End Get
        'End Property

    Protected ReadOnly Property SizeAdapter() As QCDataSetTableAdapters.SizeTableAdapter
      Get
        Return m_size
      End Get
    End Property

    Protected ReadOnly Property PageAdapter() As QCDataSetTableAdapters.PageTableAdapter
      Get
        Return m_pageAdapter
      End Get
    End Property

    Protected ReadOnly Property PageCropAdapter() As QCDataSetTableAdapters.PageCropTableAdapter
      Get
        Return m_pageCropInfoAdapter
      End Get
    End Property





    ''' <summary>
    ''' Returns index status text to display on screen.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function GetIndexStatusText(ByVal vehicleId As Integer) As String

      Return Nothing

    End Function


    '''' <summary>
    '''' Gets new image name.
    '''' </summary>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function GetNewImageName() As String
    '  Dim imageName As String
    '  Dim generateGUID As System.Guid


    '  generateGUID = System.Guid.NewGuid()
    '  imageName = generateGUID.ToString().Substring(0, 7)

    '  generateGUID = Nothing

    '  Return imageName

    'End Function

    ''' <summary>
    ''' Gets new image name.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNewImageName() As String
      Dim imageName As String
      Dim tempAdapter As QCDataSetTableAdapters.PageCropTableAdapter


      tempAdapter = New QCDataSetTableAdapters.PageCropTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      tempAdapter.mt_proc_GetNewId(ImageNameGenerationField, imageName)
      tempAdapter.Dispose()
      tempAdapter = Nothing

      Return imageName

    End Function

#Region " Vehicle image name / folder path related methods "



    ''' <summary>
    ''' Gets ImageName column value from page table based on supplied parameters.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="pageNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function GetVehicleImageName(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As String
      Dim vehicleCommand As System.Data.SqlClient.SqlCommand
      Dim commandText As System.Text.StringBuilder
      Dim imageFileName As Object


      vehicleCommand = New System.Data.SqlClient.SqlCommand
      commandText = New System.Text.StringBuilder

      commandText.Append("SELECT ISNULL(ImageName, REPLICATE('0', 3 - LEN(ReceivedOrder)) + CAST(ReceivedOrder AS VARCHAR)) FROM Page WHERE VehicleId=")
      commandText.Append(vehicleId.ToString())
      commandText.Append(" AND ReceivedOrder=")
      commandText.Append(pageNumber.ToString())

      Try
        With vehicleCommand
          .CommandText = commandText.ToString()
          .CommandType = CommandType.Text
          .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
          .Connection.Open()
          imageFileName = .ExecuteScalar()
        End With

      Catch ex As System.Data.SqlClient.SqlException
        My.Application.Log.WriteException(ex)

      Finally
        If vehicleCommand.Connection.State <> ConnectionState.Closed Then vehicleCommand.Connection.Close()
      End Try

      vehicleCommand.Dispose()
      vehicleCommand = Nothing
      commandText = Nothing

      If imageFileName Is Nothing Then
        Return Nothing
      Else
        Return imageFileName.ToString()
      End If

    End Function


    ''' <summary>
    ''' Gets vehicle folder path based on supplied vehicleId.
    ''' </summary>
    ''' <param name="vehicleId">VehicleId whose image folder path is needed.</param>
    ''' <returns>Vehicle image folder path.</returns>
    ''' <exception cref="System.ApplicationException">Raises exception when CreateDt column value is null.</exception>
    ''' <remarks>If vehicle id is not found, zero length string is returned.</remarks>
    Protected Function GetVehicleFolderPath(ByVal vehicleId As Integer) As String
      Dim createDt As DateTime
      Dim vehicleCommand As System.Data.SqlClient.SqlCommand
      Dim vehicleFolderPath As System.Text.StringBuilder
      Dim vehicleCreateDt As Object


      vehicleCommand = New System.Data.SqlClient.SqlCommand
      vehicleFolderPath = New System.Text.StringBuilder

      Try
        With vehicleCommand
          .CommandText = "SELECT CreateDt FROM Vehicle WHERE VehicleId=" + vehicleId.ToString()
          .CommandType = CommandType.Text
          .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
          .Connection.Open()
          vehicleCreateDt = .ExecuteScalar()
        End With

      Catch ex As System.Data.SqlClient.SqlException
        My.Application.Log.WriteException(ex)

      Finally
        If vehicleCommand.Connection.State <> ConnectionState.Closed Then vehicleCommand.Connection.Close()
      End Try


      If (vehicleCreateDt Is Nothing OrElse vehicleCreateDt Is DBNull.Value) Then
        Throw New System.ApplicationException("Invalid vehicle creation date found.")

      Else
        createDt = CType(vehicleCreateDt, DateTime)
        vehicleFolderPath.Append(VehicleImageFolderPath)
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

        ''' <summary>
        ''' Gets vehicle folder path based on supplied vehicleId - New Logic.
        ''' </summary>
        ''' <param name="vehicleId">VehicleId whose image folder path is needed.</param>
        ''' <returns>Vehicle image folder path.</returns>
        ''' <exception cref="System.ApplicationException">Raises exception when CreateDt column value is null.</exception>
        ''' <remarks>If vehicle id is not found, zero length string is returned.</remark>s
        Protected Function GetVehicleFolderPath(ByVal vehicleId As Integer, ByVal LocationId As Integer, ByVal PathType As Integer) As String
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
                'change 2 
                path = GetImagePath(createDt.ToString("yyyyMM"), LocationId, PathType)
                If String.IsNullOrEmpty(path) = False Then
                    ImageFolderPath.Append(path)
                    ImageFolderPath.Append(vehicleId.ToString())
                Else
                    path = VehicleImageFolderPath
                    With ImageFolderPath
                        .Append(path)
                        .Append("\")
                        .Append(createDt.ToString("yyyyMM"))
                        .Append("\")
                        .Append(vehicleId.ToString)
                    End With
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
    ''' Gets vehicle image folder path based on supplied vehicleId and image size.
    ''' </summary>
    ''' <param name="vehicleId">VehicleId whose image folder path is needed.</param>
    ''' <param name="imageSize">Image size folder is decided based on imageSize value.</param>
    ''' <returns>Vehicle image folder path.</returns>
    ''' <exception cref="System.ApplicationException">Raises exception when CreateDt column value is null.</exception>
    ''' <remarks>If vehicle id is not found, zero length string is returned.</remarks>
    Protected Function GetVehicleImageFolderPath _
        (ByVal vehicleId As Integer, ByVal imageSize As VehicleImageSizeEnum) _
        As String
      Dim vehicleFolder As String
      Dim imagePath As System.Text.StringBuilder


      imagePath = New System.Text.StringBuilder

            vehicleFolder = GetVehicleFolderPath(vehicleId, UserLocationId, GetPathType("Master"))      ' new logic that will retrieve data in the image path table
            If String.IsNullOrEmpty(vehicleFolder) = True Then vehicleFolder = GetVehicleFolderPath(vehicleId)
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
    ''' Gets image folder for supplied vehicle Id.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <exception cref="System.ApplicationException">Raises exception when CreateDt column value is null.</exception>
    ''' <remarks></remarks>
        Public Function GetPageImageFolderPath(ByVal vehicleId As Integer, Optional ByVal isRemote As Boolean = False) As String

            If isRemote = False Then
                Return GetVehicleImageFolderPath(vehicleId, VehicleImageSizeEnum.Unsized)
            Else
                If RemoteFolder = "Full" Then
                    Return GetVehicleImageFolderPath(vehicleId, VehicleImageSizeEnum.Large)
                ElseIf RemoteFolder = "Mid" Then
                    Return GetVehicleImageFolderPath(vehicleId, VehicleImageSizeEnum.Normal)
                ElseIf RemoteFolder = "Thumb" Then
                    Return GetVehicleImageFolderPath(vehicleId, VehicleImageSizeEnum.Thumbnail)
                Else
                    Return GetVehicleImageFolderPath(vehicleId, VehicleImageSizeEnum.Unsized)
                End If
            End If

        End Function

    ''' <summary>
    ''' Gets image folder for supplied vehicle Id and image size.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="imageSize"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPageImageFolderPath(ByVal vehicleId As Integer, ByVal imageSize As VehicleImageSizeEnum) As String


            Return GetVehicleImageFolderPath(vehicleId, imageSize)

    End Function

    ''' <summary>
    ''' Gets path of an image file for specified page of vehicle for specified image size.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="pageNumber"></param>
    ''' <param name="imageSize"></param>
    ''' <param name="checkFileExistance"></param>
    ''' <returns></returns>
    ''' <exception cref="System.IO.DirectoryNotFoundException">Vehicle or vehicle image folder not found.</exception>
    ''' <exception cref="System.ApplicationException">Page information not found for specified page number.</exception>
    ''' <exception cref="System.IO.FileNotFoundException">Page image not found, for specified page number.</exception>
    ''' <remarks></remarks>
    Public Function GetPageImageFilePath _
        (ByVal vehicleId As Integer, ByVal pageNumber As Integer, ByVal imageSize As VehicleImageSizeEnum _
         , Optional ByVal checkFileExistance As Boolean = True) _
        As String
      Dim tempString As String
      Dim imageFilePath As System.Text.StringBuilder


      imageFilePath = New System.Text.StringBuilder

      tempString = GetVehicleImageFolderPath(vehicleId, imageSize)
      If System.IO.Directory.Exists(tempString) = False Then
        Throw New System.IO.DirectoryNotFoundException("Vehicle or vehicle image folder not found.")
      End If

      imageFilePath.Append(tempString)
      tempString = Nothing

      tempString = GetVehicleImageName(vehicleId, pageNumber)
      If tempString Is Nothing Then
        Throw New System.ApplicationException("Page information not found for specified page number.")
      End If

      imageFilePath.Append("\")
      imageFilePath.Append(tempString)
      imageFilePath.Append(ImageFileExtension)
      tempString = Nothing

      If checkFileExistance AndAlso System.IO.File.Exists(imageFilePath.ToString()) = False Then
        Throw New System.IO.FileNotFoundException("Page image not found, for specified page number.")
      End If

      tempString = imageFilePath.ToString()
      imageFilePath = Nothing

      Return tempString

    End Function



        ''' <summary>
        ''' Gets vehicle folder path based on supplied vehicleId - New Logic.
        ''' </summary>
        ''' <param name="vehicleId">VehicleId whose image folder path is needed.</param>
        ''' <returns>Vehicle image folder path.</returns>
        ''' <exception cref="System.ApplicationException">Raises exception when CreateDt column value is null.</exception>
        ''' <remarks>If vehicle id is not found, zero length string is returned.</remark>s
        Protected Function GetVehicleLocalFolderPath(ByVal vehicleId As Integer, ByVal LocationId As Integer, ByVal PathType As Integer) As String
            Dim createDt As DateTime
            Dim ImageCommand As System.Data.SqlClient.SqlCommand
            Dim ImageFolderPath As System.Text.StringBuilder
            Dim vehicleCreateDt As Object
            Dim path As String
            Dim rootFolder As String = Global.MCAP.My.MySettings.Default.MCAPCacheImages.ToString


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
                'change 2 
                'path = GetImagePath(createDt.ToString("yyyyMM"), LocationId, PathType)
                If String.IsNullOrEmpty(path) = False Then
                    ImageFolderPath.Append(path)
                    ImageFolderPath.Append(vehicleId.ToString())
                Else
                    path = rootFolder
                    With ImageFolderPath
                        .Append(path)
                        .Append("\")
                        .Append(createDt.ToString("yyyyMM"))
                        .Append("\")
                        .Append(vehicleId.ToString)
                        .Append("\Unsized")
                    End With
                End If
            End If

            ImageCommand.Dispose()
            ImageCommand = Nothing
            vehicleCreateDt = Nothing

            Return ImageFolderPath.ToString()

        End Function

        Protected Function clearVehicleLocalFolderPath(ByVal vehicleId As Integer, ByVal LocationId As Integer, ByVal PathType As Integer) As String
            Dim createDt As DateTime
            Dim ImageCommand As System.Data.SqlClient.SqlCommand
            Dim ImageFolderPath As System.Text.StringBuilder
            Dim vehicleCreateDt As Object
            Dim path As String
            Dim rootFolder As String = Global.MCAP.My.MySettings.Default.MCAPCacheImages.ToString

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
                'change 2 
                'path = GetImagePath(createDt.ToString("yyyyMM"), LocationId, PathType)
                If String.IsNullOrEmpty(path) = False Then
                    ImageFolderPath.Append(path)
                    ImageFolderPath.Append(vehicleId.ToString())
                Else
                    path = rootFolder
                    With ImageFolderPath
                        .Append(path)
                        .Append("\")
                        '.Append(createDt.ToString("yyyyMM"))
                        '.Append("\")
                    End With
                End If
            End If

            ImageCommand.Dispose()
            ImageCommand = Nothing
            vehicleCreateDt = Nothing

            Return ImageFolderPath.ToString()

        End Function

        Public Function LoadLocalImageFolder(ByVal vehicleId As Integer) As String
            Dim vehicleFolder As String
            vehicleFolder = GetVehicleLocalFolderPath(vehicleId, UserLocationId, GetPathType("Master"))
            Return vehicleFolder
        End Function

        Public Sub ClearLocalImageFolder(ByVal vehicleId As Integer)
            Dim vehicleFolder As String
            vehicleFolder = clearVehicleLocalFolderPath(vehicleId, UserLocationId, GetPathType("Master"))
            Try
                If IO.Directory.Exists(vehicleFolder) Then

                    For Each d As String In IO.Directory.GetDirectories(vehicleFolder)
                        IO.Directory.Delete(d, True)
                    Next
                End If
            Catch ex As Exception

            End Try

        End Sub

#End Region
#Region " Drawing Image"

#End Region


#Region " Cropped vehicle page image related methods "


        ''' <summary>
        ''' Gets name of cropped image name.
        ''' </summary>
        ''' <param name="pageCropId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function GetCroppedPageImageName(ByVal pageCropId As Integer) As String
            Dim vehicleCommand As System.Data.SqlClient.SqlCommand
            Dim commandText As System.Text.StringBuilder
            Dim imageFileName As Object


            vehicleCommand = New System.Data.SqlClient.SqlCommand
            commandText = New System.Text.StringBuilder

            commandText.Append("SELECT CropImageName FROM PageCrop WHERE PageCropId=")
            commandText.Append(pageCropId.ToString())

            Try
                With vehicleCommand
                    .CommandText = commandText.ToString()
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    imageFileName = .ExecuteScalar()
                End With

            Catch ex As System.Data.SqlClient.SqlException
                My.Application.Log.WriteException(ex)

            Finally
                If vehicleCommand.Connection.State <> ConnectionState.Closed Then vehicleCommand.Connection.Close()
            End Try

            vehicleCommand.Dispose()
            vehicleCommand = Nothing
            commandText = Nothing

            If imageFileName Is Nothing Then
                Return Nothing
            Else
                Return imageFileName.ToString()
            End If

        End Function

        ''' <summary>
        ''' Gets path to cropped vehicle page image folder.
        ''' </summary>
        ''' <param name="vehicleid"></param>
        ''' <param name="pageCropId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function GetVehicleCroppedPageImageFolderPath(ByVal vehicleid As Integer, ByVal pageCropId As Integer) As String
            Dim vehicleFolderPath As String
            Dim croppedImagePath As System.Text.StringBuilder


            croppedImagePath = New System.Text.StringBuilder

            '
            'Ritesh (10 Nov 2008) - Path for the cropped page images is changed and now 
            'cropped page images are stored within the unsized page image folder itself.
            '
            vehicleFolderPath = GetVehicleFolderPath(vehicleid, UserLocationId, GetPathType("Master"))
            If String.IsNullOrEmpty(vehicleFolderPath) = True Then vehicleFolderPath = GetVehicleFolderPath(vehicleid)
            croppedImagePath.Append(vehicleFolderPath)
            'croppedImagePath.Append("\PageCrops\")
            'croppedImagePath.Append(pageCropId.ToString())
            croppedImagePath.Append("\")
            croppedImagePath.Append(UnsizedPageImageFolderName)

            vehicleFolderPath = Nothing

            Return croppedImagePath.ToString()

        End Function

        ''' <summary>
        ''' Gets path to cropped vehicle page image name.
        ''' </summary>
        ''' <param name="vehicleid"></param>
        ''' <param name="pageCropId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function GetVehicleCroppedPageImagePath(ByVal vehicleid As Integer, ByVal pageCropId As Integer) As String
            Dim cropIdFolderPath, imageName As String
            Dim croppedImagePath As System.Text.StringBuilder


            croppedImagePath = New System.Text.StringBuilder

            cropIdFolderPath = GetVehicleCroppedPageImageFolderPath(vehicleid, pageCropId)
            imageName = GetCroppedPageImageName(pageCropId)

            croppedImagePath.Append(cropIdFolderPath)
            croppedImagePath.Append("\")
            croppedImagePath.Append(imageName)
            croppedImagePath.Append(ImageFileExtension)

            cropIdFolderPath = Nothing
            imageName = Nothing

            Return croppedImagePath.ToString()

        End Function


#End Region


        Protected Overrides Sub SetAdaptersConnectionString()

            MyBase.SetAdaptersConnectionString()

            PageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            SizeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            PageCropAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

        End Sub

        ''' <summary>
        ''' Gets image name from Page table based on supplied vehicleId and page number.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="pageNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPageImageName(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As String

            Return GetVehicleImageName(vehicleId, pageNumber)

        End Function

        ''' <summary>
        ''' Gets ImageName column value based on supplied page number from current Page datatable.
        ''' </summary>
        ''' <param name="pageNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPageImageName(ByVal pageNumber As Integer) As String
            Dim imageName As String
            Dim pageInfo As System.Data.EnumerableRowCollection(Of QCDataSet.PageRow)


            imageName = Nothing
            pageInfo = From pi In Data.Page _
                       Where pi.ReceivedOrder = pageNumber _
                       Select pi

            If pageInfo.Count() > 0 Then
                If pageInfo(0).IsImageNameNull() Then
                    imageName = pageInfo(0).ReceivedOrder.ToString("000")
                Else
                    imageName = pageInfo(0).ImageName
                End If
            End If

            pageInfo = Nothing

            Return imageName

        End Function

        ''' <summary>
        ''' Returns row from Page table having ImageName same as parameter value.
        ''' </summary>
        ''' <param name="imageName"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' If multiple rows are found with same imageName, it returns row with minimum received order.
        ''' </remarks>
        Public Function GetPageImageInformation(ByVal imageName As String) As QCDataSet.PageRow
            Dim pgRow As QCDataSet.PageRow
            Dim pageRows As System.Data.EnumerableRowCollection(Of QCDataSet.PageRow)


            pageRows = From pr In Data.Page _
                       Where pr.ImageName = imageName _
                       Select pr

            If pageRows.Count() = 0 Then
                pgRow = Nothing
            Else
                pgRow = pageRows(0)
            End If

            pageRows = Nothing

            Return pgRow

        End Function

        ''' <summary>
        ''' Returns row from Page table based on supplied vehicleId and page number parameters.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="pageNumber"></param>
        ''' <returns></returns>
        ''' <remarks>
        ''' If multiple rows are found with same imageName, it returns row with minimum received order.
        ''' </remarks>
        Public Function GetPageImageInformation(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As QCDataSet.PageRow
            Dim linqQuery As System.Collections.Generic.IEnumerable(Of QCDataSet.PageRow)


            linqQuery = From pr In Data.Page.Rows.Cast(Of QCDataSet.PageRow)() _
                        Select pr _
                        Where (pr.VehicleId = vehicleId AndAlso pr.ReceivedOrder = pageNumber)

            If linqQuery.Count = 0 Then Return Nothing

            Return linqQuery(0)

        End Function

        ''' <summary>
        ''' Loads records from Page table based on supplied vehicleId.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <remarks></remarks>
        Public Sub LoadVehiclePagesInformation(ByVal vehicleId As Integer)

            RaiseEvent LoadingVehiclePagesInformation()

            PageAdapter.Fill(Data.Page, vehicleId)

            RaiseEvent VehiclePagesInformationLoaded()

        End Sub

        ''' <summary>
        ''' Gets PageId for supplied page number of supplied vehicleid. Returns -1 if page not found.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="pageNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPageId(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As Integer
            Dim pageId As Integer
            Dim tempRow As QCDataSet.PageRow


            tempRow = GetPageImageInformation(vehicleId, pageNumber)

            If tempRow Is Nothing Then
                pageId = -1
            Else
                pageId = tempRow.PageId
            End If

            tempRow = Nothing

            Return pageId

        End Function

        ''' <summary>
        ''' Updates PixelHeight and PixelWidth columns based on vehicleId and received order value.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="receivedOrder"></param>
        ''' <param name="imageSize"></param>
        ''' <remarks></remarks>
        Public Sub UpdatePageImageSizeInPixels(ByVal vehicleId As Integer, ByVal receivedOrder As Integer, ByVal imageSize As System.Drawing.SizeF)
            Dim width, height As Integer


            width = CType(imageSize.Width, Integer)
            height = CType(imageSize.Height, Integer)

            PageAdapter.UpdateSizeInPixels(height, width, vehicleId, receivedOrder)

        End Sub
        ''' <summary>
        ''' Gets PageType based on supplied vehicle Id and page number from current Page datatable.
        ''' </summary>
        ''' <param name="pageNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetQcDetails(ByVal vehicleId As Integer) As String
            Dim pageType As String
            Dim tempRow As QCDataSet.PageRow


            'tempRow = GetPageImageInformation(vehicleId, pageNumber)

            'If tempRow Is Nothing Then
            '    pageType = Nothing
            'ElseIf tempRow.PageTypeId = "B" Then
            '    pageType = "Base"
            'Else
            '    pageType = GetPageTypeDisplayName(tempRow.PageTypeId) + Environment.NewLine + "(" + tempRow.PageName + ")"
            'End If

            'tempRow = Nothing

            Return pageType

        End Function
        ''' <summary>
        ''' Gets PageType based on supplied vehicle Id and page number from current Page datatable.
        ''' </summary>
        ''' <param name="pageNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPageType(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As String
            Dim pageType As String
            Dim tempRow As QCDataSet.PageRow


            tempRow = GetPageImageInformation(vehicleId, pageNumber)

            If tempRow Is Nothing Then
                pageType = Nothing
            ElseIf tempRow.PageTypeId = "B" Then
                pageType = "Base"
            Else
                pageType = GetPageTypeDisplayName(tempRow.PageTypeId) + Environment.NewLine + "(" + tempRow.PageName + ")"
            End If

            tempRow = Nothing

            Return pageType

        End Function

        ''' <summary>
        ''' Gets PageType based on supplied page number from current Page datatable.
        ''' </summary>
        ''' <param name="pageNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPageType(ByVal pageNumber As Integer) As String
            Dim pageType As String
            Dim pageInfo As System.Data.EnumerableRowCollection(Of QCDataSet.PageRow)


            pageInfo = From pi In Data.Page _
                       Where pi.ReceivedOrder = pageNumber _
                       Select pi

            If pageInfo.Count() = 0 Then
                pageType = Nothing
            ElseIf pageInfo(0).PageTypeId = "B" Then
                pageType = "Base"
            Else
                pageType = GetPageTypeDisplayName(pageInfo(0).PageTypeId) + Environment.NewLine + "(" + pageInfo(0).PageName + ")"
            End If

            pageInfo = Nothing

            Return pageType

        End Function


        ''' <summary>
        ''' Loads all pagetypes into PageType data table.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub LoadAllPageTypes()
            Dim tempAdapter As QCDataSetTableAdapters.PageTypeTableAdapter


            tempAdapter = New QCDataSetTableAdapters.PageTypeTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(Me.Data.PageType)

            tempAdapter.Dispose()
            tempAdapter = Nothing
        End Sub

        ''' <summary>
        ''' Gets pagetype display name form PageType datatable based on supplied pagetype Id. 
        ''' </summary>
        ''' <param name="pagetypeId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetPageTypeDisplayName(ByVal pagetypeId As String) As String
            Try
                Dim returnValue As String
                Dim pagetypeQuery As System.Data.EnumerableRowCollection(Of QCDataSet.PageTypeRow)


                pagetypeQuery = From pt In Data.PageType _
                                Where pt.PageTypeId = pagetypeId _
                                Select pt

                If pagetypeId.Count() = 0 Then
                    returnValue = String.Empty
                ElseIf pagetypeQuery(0).PageTypeId = "B" Then
                    returnValue = "Base"
                Else
                    returnValue = pagetypeQuery(0).DisplayDescrip
                End If

                pagetypeQuery = Nothing

                Return returnValue
            Catch ex As Exception

            End Try

        End Function


        ''' <summary>
        ''' Gets PageSize based on supplied page number from current Page datatable.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="pageNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPageSize(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As System.Drawing.SizeF
            Dim tempRow As QCDataSet.PageRow
            Dim tempSize As System.Drawing.SizeF


            tempRow = GetPageImageInformation(vehicleId, pageNumber)
            If tempRow Is Nothing Then
                tempSize = Nothing
            Else
                tempSize.Height = CType(tempRow.SizeRow.Height, Single)
                tempSize.Width = CType(tempRow.SizeRow.Width, Single)
            End If

            tempRow = Nothing

            Return tempSize

        End Function

        ''' <summary>
        ''' Gets PageSize based on supplied page Id from current Page datatable.
        ''' </summary>
        ''' <param name="pageId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPageSize(ByVal pageId As Integer) As System.Drawing.SizeF
            Dim linqQuery As System.Collections.Generic.IEnumerable(Of QCDataSet.PageRow)
            Dim tempSize As System.Drawing.SizeF


            linqQuery = From p In Data.Page.Rows.Cast(Of QCDataSet.PageRow)() _
                        Select p _
                        Where p.PageId = pageId

            If linqQuery.Count = 0 Then
                tempSize = System.Drawing.SizeF.Empty
            Else
                tempSize.Height = CType(linqQuery(0).SizeRow.Height, Single)
                tempSize.Width = CType(linqQuery(0).SizeRow.Width, Single)
            End If

            linqQuery = Nothing

            Return tempSize

        End Function

        ''' <summary>
        ''' Checks whether supplied width and height exist in Size table or not, inserts a record if not.
        ''' </summary>
        ''' <param name="width"></param>
        ''' <param name="height"></param>
        ''' <remarks></remarks>
        Public Sub CheckAndInsertSize(ByVal width As Single, ByVal height As Single)
            Dim recordsAffected As Integer
            Dim sizeId As Integer?


            recordsAffected = SizeAdapter.CheckAndInsertSize(width, height, sizeId)

        End Sub

        ''' <summary>
        ''' Gets size Id based on supplied width and height.
        ''' </summary>
        ''' <param name="width"></param>
        ''' <param name="height"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSizeId(ByVal width As Single, ByVal height As Single) As Integer
            Dim sizeId, checkCounter As Integer
            Dim linqQuery As System.Collections.Generic.IEnumerable(Of QCDataSet.SizeRow)


CheckAgain:
            linqQuery = From sr In Data.Size.Rows.Cast(Of QCDataSet.SizeRow)() _
                        Select sr _
                        Where sr.Width = width AndAlso sr.Height = height

            If linqQuery.Count > 0 Then
                sizeId = linqQuery(0).SizeID
            Else
                Using e As MCAP.UI.Processors.EventArgs = New MCAP.UI.Processors.EventArgs()
                    e.Data.Add("Width", width)
                    e.Data.Add("Height", height)
                    RaiseEvent SizeNotFound(Me, e)
                End Using
                checkCounter += 1
                If checkCounter < 2 Then GoTo CheckAgain
            End If

            linqQuery = Nothing

            Return sizeId

        End Function

        ''' <summary>
        ''' Gets size based on supplied sizeId.
        ''' </summary>
        ''' <param name="sizeId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSize(ByVal sizeId As Integer) As System.Drawing.SizeF
            Dim linqQuery As System.Collections.Generic.IEnumerable(Of QCDataSet.SizeRow)
            Dim adSize As System.Drawing.SizeF


            linqQuery = From r In Data.Size.Rows.Cast(Of QCDataSet.SizeRow)() _
                        Select r _
                        Where r.SizeID = sizeId

            If linqQuery.Count = 0 Then
                adSize = System.Drawing.SizeF.Empty
            Else
                adSize.Width = CType(linqQuery(0).Width, Single)
                adSize.Height = CType(linqQuery(0).Height, Single)
            End If

            linqQuery = Nothing

            Return adSize

        End Function

        ''' <summary>
        ''' Gets number of records for supplied vehicleId in Page table.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPageCount(ByVal vehicleId As Integer) As Integer
            Dim pageCount As Nullable(Of Integer)


            pageCount = PageAdapter.GetPageCount(vehicleId)

            If pageCount Is Nothing Then
                Return -1
            Else
                Return CType(pageCount, Integer)
            End If

        End Function

        ''' <summary>
        ''' Synchronizes Page datatable changes with Page table in database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SynchronizePageInformation()

            RaiseEvent SynchronizingPageInformation()

            PageAdapter.Update(Data.Page)

            RaiseEvent PageInformationSynchronized()

        End Sub


        ''' <summary>
        ''' Updates vehicle status as Deleted.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <exception cref="System.ApplicationException">
        ''' Throws exception if vehicleId mismatch occurs or status id not found for QC Completed status.
        ''' </exception>
        ''' <remarks></remarks>
        Public Sub MarkVehicleAsDeleted(ByVal vehicleId As Integer)
            Dim statusId As Nullable(Of Integer)


            If Data.vwCircular(0).VehicleId <> vehicleId Then
                Throw New System.ApplicationException("Vehicle information not found.")
            End If

            statusId = VehicleStatusAdapter.GetStatusId("Deleted")
            If statusId Is Nothing Then
                Throw New System.ApplicationException("Vehicle status value not found.")
            End If

            Data.vwCircular(0).BeginEdit()
            Data.vwCircular(0).StatusID = CType(statusId, Integer)
            Data.vwCircular(0).EndEdit()

        End Sub

        ''' <summary>
        ''' Removes vehicle folder image and Subfolders (pageCrop) images.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <remarks></remarks>
        Public Sub RemoveVehicleFolder(ByVal vehicleId As Integer)
            Dim vehicleFolderPath As String


            vehicleFolderPath = GetVehicleFolderPath(vehicleId)

            If System.IO.Directory.Exists(vehicleFolderPath) = False Then
                Throw New System.ApplicationException("Vehicle folder not found.")
            End If

            Try
                System.IO.Directory.Delete(vehicleFolderPath, True)
            Catch ex As Exception
                Throw New ApplicationException("Unable to delete vehicle folder.", ex)
            End Try

            vehicleFolderPath = Nothing

        End Sub


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '
        ' PageCrop related methods.
        '
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        ''' <summary>
        ''' Gets number of records in PageCrop table.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCroppedPageCount(ByVal vehicleId As Integer) As Integer
            Dim count As Nullable(Of Integer)


            count = PageCropAdapter.GetCroppedPageCount(vehicleId)

            If count Is Nothing Then
                Return -1
            Else
                Return CType(count, Integer)
            End If

        End Function

        ''' <summary>
        ''' Loads records from PageCrop table based on supplied vehicleId created by loggedon application user.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <remarks></remarks>
        Public Sub LoadLatestPageCropInformation(ByVal vehicleId As Integer)

            RaiseEvent LoadingVehiclePageCropInformation()

            PageCropAdapter.FillLatestPageCropByVehicleId(Data.PageCrop, vehicleId, UserID)

            RaiseEvent VehiclePageCropInformationLoaded()

        End Sub

        ''' <summary>
        ''' Loads records from PageCrop table based on supplied vehicleId and retailerId created by loggedon application user.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="retailerId"></param>
        ''' <remarks></remarks>
        Public Sub LoadLatestPageCropInformation(ByVal vehicleId As Integer, ByVal retailerId As Integer)

            RaiseEvent LoadingVehiclePageCropInformation()

            PageCropAdapter.FillLatestCropBy(Data.PageCrop, vehicleId, UserID, retailerId)

            RaiseEvent VehiclePageCropInformationLoaded()

        End Sub

        ''' <summary>
        ''' Loads records from PageCrop table based on supplied vehicleId.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <remarks></remarks>
        Public Sub LoadVehiclePageCropInformation(ByVal vehicleId As Integer)

            RaiseEvent LoadingVehiclePageCropInformation()

            Try
                PageCropAdapter.FillByVehicleId(Data.PageCrop, vehicleId)

            Catch ex As System.Data.SqlClient.SqlException
                Throw New System.ApplicationException("Unable to fetch cropped pages information for vehicle " _
                                                      + vehicleId.ToString() + " from database.", ex)
            Catch ex As Exception
                Throw New System.ApplicationException("Unknown error has occurred while fetching cropped " _
                                                      + "pages information for vehicle " + vehicleId.ToString() _
                                                      + " from database.", ex)
            End Try

            RaiseEvent VehiclePageCropInformationLoaded()

        End Sub

        ''' <summary>
        ''' Returns path to folder for storing cropped page image for supplied vehicleId and pageCropId.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="pageCropId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCroppedPageImageFolderPath(ByVal vehicleId As Integer, ByVal pageCropId As Integer) As String
            Dim croppedPageImageFolder As String


            croppedPageImageFolder = GetVehicleCroppedPageImageFolderPath(vehicleId, pageCropId)

            Return croppedPageImageFolder

        End Function

        ''' <summary>
        ''' Returns path to cropped page image for supplied pageCropId.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="pageCropId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCroppedPageImagePath(ByVal vehicleId As Integer, ByVal pageCropId As Integer) As String
            Dim croppedPageImageFolder As String


            croppedPageImageFolder = GetVehicleCroppedPageImagePath(vehicleId, pageCropId)

            Return croppedPageImageFolder

        End Function



#Region " Validation related methods "


#Region " Business Logic related validation methods "


        ''' <summary>
        ''' Validates all columns of supplied DataRow.
        ''' </summary>
        ''' <param name="validateRow"></param>
        ''' <returns>
        ''' True if all columns contains valid inforamtion. False otherwise.
        ''' </returns>
        ''' <remarks></remarks>
        Public Function AreDatesValid(ByVal vehicleRow As QCDataSet.vwPublicationEditionRow, ByVal validateRow As QCDataSet.PageCropRow) As Boolean

            If validateRow.RetRow IsNot Nothing Then
                If vehicleRow.MediaRow.Descrip.ToUpper() = "ROP" _
                  AndAlso validateRow.RetRow.Descrip.ToUpper() = "WALMART" _
                  AndAlso validateRow.IsStartDtNull() = False _
                  AndAlso validateRow.StartDt.Subtract(vehicleRow.BreakDt).Days > 0 _
                  AndAlso validateRow.StartDt.Subtract(DateTime.Today).Days > 0 _
                Then
                    AddErrorInformation(Data.Errors, "StartDt", "Start Date", "Sale Start date is greater than Ad date," _
                                        + " this is not allowed for a Walmart Ad. Please review and re-index.")
                    Return False
                Else
                    RemoveErrorInformation(Data.Errors, "StartDt")
                End If
            End If

            'If validateRow.HasErrors = False Then
            '  ValidateRequiredRetailerInputs(validateRow)
            '  IsStartDateValid(validateRow)
            '  IsEndDateValid(validateRow)
            'End If

            If Data.Errors.Count = 0 AndAlso vehicleRow.IsPriorityNull() = False Then
                If vehicleRow.Priority >= 0 Then
                    RemoveErrorInformation(Data.Errors, "Priority")
                    vehicleRow.SetColumnError("Priority", String.Empty)
                Else
                    AddErrorInformation(Data.Errors, "Priority", "Priority", "Unexpected Market-Media-Retailer combination.")
                    validateRow.SetColumnError("Priority", "Unexpected Market-Media-Retailer combination.")
                    vehicleRow.SetPriorityNull()
                End If
            End If


            Return (Not validateRow.HasErrors)

        End Function


        ''' <summary>
        ''' Validates all columns of supplied DataRow.
        ''' </summary>
        ''' <param name="validateRow"></param>
        ''' <returns>
        ''' True if all columns contains valid inforamtion. False otherwise.
        ''' </returns>
        ''' <remarks></remarks>
        Public Function AreDatesValid(ByVal vehicleRow As QCDataSet.vwCircularRow, ByVal validateRow As QCDataSet.PageCropRow) As Boolean

            If validateRow.RetRow IsNot Nothing Then
                If vehicleRow.MediaRow.Descrip.ToUpper() = "ROP" _
                  AndAlso validateRow.RetRow.Descrip.ToUpper() = "WALMART" _
                  AndAlso validateRow.IsStartDtNull() = False _
                  AndAlso validateRow.StartDt.Subtract(vehicleRow.BreakDt).Days > 0 _
                  AndAlso validateRow.StartDt.Subtract(DateTime.Today).Days > 0 _
                Then
                    AddErrorInformation(Data.Errors, "StartDt", "Start Date", "Sale Start date is greater than Ad date," _
                                        + " this is not allowed for a Walmart Ad. Please review and re-index.")
                    Return False
                Else
                    RemoveErrorInformation(Data.Errors, "StartDt")
                End If
            End If

            'If validateRow.HasErrors = False Then
            '  ValidateRequiredRetailerInputs(validateRow)
            '  IsStartDateValid(validateRow)
            '  IsEndDateValid(validateRow)
            'End If


            Return (Not validateRow.HasErrors)

        End Function


        '''' <summary>
        '''' Validates start date for its duration from Ad date. 
        '''' </summary>
        '''' <param name="validateRow"></param>
        '''' <returns></returns>
        '''' <remarks></remarks>
        'Protected Function IsStartDateValid(ByVal validateRow As EnvelopeContentDataSet.vwCircularRow) As Boolean
        '  Dim isDateValid As Boolean
        '  Dim dateDifference As Integer


        '  If validateRow.IsStartDtNull() Then
        '    validateRow.SetColumnError("StartDt", "")
        '    Return True
        '  End If

        '  isDateValid = True
        '  dateDifference = validateRow.StartDt.Subtract(validateRow.BreakDt).Days

        '  If (validateRow.MediaRow.Descrip.ToUpper() = "MAILER" _
        '    Or validateRow.MediaRow.Descrip.ToUpper() = "CATALOG") _
        '    And (dateDifference < -7 Or dateDifference > 7) _
        '  Then
        '    isDateValid = False
        '    validateRow.SetColumnError("StartDt", "Start Date needs to be within 7 days of Ad Date.")

        '  ElseIf validateRow.RetRow.TradeClassRow.Descrip.ToUpper() = "DEPT" _
        '    And (dateDifference < -14 Or dateDifference > 14) _
        '  Then
        '    isDateValid = False
        '    validateRow.SetColumnError("StartDt", "Start Date needs to be within 14 days of Ad Date.")

        '  ElseIf dateDifference < -28 Or dateDifference > 28 Then
        '    isDateValid = False
        '    validateRow.SetColumnError("StartDt", "Start Date needs to be within 28 days of Ad Date.")

        '  ElseIf dateDifference < -3 Or dateDifference > 3 Then
        '    isDateValid = False
        '    validateRow.SetColumnError("StartDt", "Start Date is not within 3 days of Ad Date.")
        '  End If


        '  Return isDateValid

        'End Function

        '''' <summary>
        '''' Validates end date for its duration from start date and ad date.
        '''' </summary>
        '''' <param name="validateRow"></param>
        '''' <returns></returns>
        '''' <remarks></remarks>
        'Public Function IsEndDateValid(ByVal validateRow As EnvelopeContentDataSet.vwCircularRow) As Boolean
        '  Dim isDateValid As Boolean


        '  If validateRow.IsEndDtNull() Then
        '    validateRow.SetColumnError("EndDt", "")
        '    Return True
        '  End If

        '  isDateValid = True

        '  If validateRow.EndDt.Subtract(validateRow.StartDt).Days < 0 Then
        '    validateRow.SetColumnError("EndDt", "End date cannot be prior to Start date.")
        '    isDateValid = False
        '  ElseIf validateRow.EndDt.Subtract(validateRow.StartDt).Days > 30 Then
        '    validateRow.SetColumnError("EndDt", "End date is not within 30 days of Start date.")
        '    isDateValid = False
        '  ElseIf validateRow.BreakDt.Subtract(validateRow.EndDt).Days > 35 Then
        '    validateRow.SetColumnError("EndDt", "End date is not within 35 days of Ad date.")
        '    isDateValid = False
        '  End If


        '  Return isDateValid

        'End Function


#End Region


        ''' <summary>
        ''' Checks whether all columns contain valid values or not. Returns false if not, true otherwise.
        ''' </summary>
        ''' <param name="validateRow"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AreInputsValid(ByVal vehicleRow As QCDataSet.vwPublicationEditionRow, ByVal validateRow As QCDataSet.PageCropRow) As Boolean
            Dim areAllValid As Boolean


            RaiseEvent ValidatingPageCropInputs()

            areAllValid = True

            'If validateRow.IsBreakDtNull() Then
            '  validateRow.SetColumnError("BreakDt", "Ad date cannot be blank.")
            '  areAllValid = False
            'End If

            'If validateRow.IsNull("EnvelopeId") Then
            '  validateRow.SetColumnError("EnvelopeId", "Envelope is missing.")
            'Else
            '  validateRow.SetColumnError("EnvelopeId", "")
            'End If

            'If validateRow.IsNull("BreakDt") Then
            '  validateRow.SetColumnError("BreakDt", "Ad date is not specified.")
            'Else
            '  validateRow.SetColumnError("BreakDt", "")
            'End If

            'If validateRow.IsNull("RetId") Then
            '  validateRow.SetColumnError("RetId", "Retailer is not specified.")
            'Else
            '  validateRow.SetColumnError("RetId", "")
            'End If

            'If validateRow.IsNull("MktId") Then
            '  validateRow.SetColumnError("MktId", "Market is not specified.")
            'Else
            '  validateRow.SetColumnError("MktId", "")
            'End If

            'If validateRow.IsNull("MediaId") Then
            '  validateRow.SetColumnError("MediaId", "Media is not specified.")
            'Else
            '  validateRow.SetColumnError("MediaId", "")
            'End If

            If Data.Errors.Count = 0 AndAlso vehicleRow.IsPriorityNull() = False Then
                If vehicleRow.Priority >= 0 Then
                    RemoveErrorInformation(Data.Errors, "Priority")
                    vehicleRow.SetColumnError("Priority", String.Empty)
                Else
                    AddErrorInformation(Data.Errors, "Priority", "Priority", "Unexpected Market-Media-Retailer combination.")
                    validateRow.SetColumnError("Priority", "Unexpected Market-Media-Retailer combination.")
                    vehicleRow.SetPriorityNull()
                End If
            End If


            If areAllValid Then areAllValid = AreDatesValid(vehicleRow, validateRow)


            RaiseEvent PageCropInputsValidated()

            Return areAllValid

        End Function


        ''' <summary>
        ''' Checks whether all columns contain valid values or not. Returns false if not, true otherwise.
        ''' </summary>
        ''' <param name="validateRow"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AreInputsValid(ByVal vehicleRow As QCDataSet.vwCircularRow, ByVal validateRow As QCDataSet.PageCropRow) As Boolean
            Dim areAllValid As Boolean


            RaiseEvent ValidatingPageCropInputs()

            areAllValid = True

            'If validateRow.IsBreakDtNull() Then
            '  validateRow.SetColumnError("BreakDt", "Ad date cannot be blank.")
            '  areAllValid = False
            'End If

            'If validateRow.IsNull("EnvelopeId") Then
            '  validateRow.SetColumnError("EnvelopeId", "Envelope is missing.")
            'Else
            '  validateRow.SetColumnError("EnvelopeId", "")
            'End If

            'If validateRow.IsNull("BreakDt") Then
            '  validateRow.SetColumnError("BreakDt", "Ad date is not specified.")
            'Else
            '  validateRow.SetColumnError("BreakDt", "")
            'End If

            'If validateRow.IsNull("RetId") Then
            '  validateRow.SetColumnError("RetId", "Retailer is not specified.")
            'Else
            '  validateRow.SetColumnError("RetId", "")
            'End If

            'If validateRow.IsNull("MktId") Then
            '  validateRow.SetColumnError("MktId", "Market is not specified.")
            'Else
            '  validateRow.SetColumnError("MktId", "")
            'End If

            'If validateRow.IsNull("MediaId") Then
            '  validateRow.SetColumnError("MediaId", "Media is not specified.")
            'Else
            '  validateRow.SetColumnError("MediaId", "")
            'End If


            If areAllValid Then areAllValid = AreDatesValid(vehicleRow, validateRow)


            RaiseEvent PageCropInputsValidated()

            Return areAllValid

        End Function


#End Region



        ''' <summary>
        ''' Adds supplied DataRow into PageCrop DataTable.
        ''' </summary>
        ''' <param name="tempRow"></param>
        ''' <remarks></remarks>
        Public Sub AddPageCropInformation(ByVal tempRow As QCDataSet.PageCropRow)

            tempRow.BeginEdit()
            tempRow.IndexById = UserID
            'tempRow.IndexDt = System.DateTime.Now
            tempRow.EndEdit()

            Data.PageCrop.AddPageCropRow(tempRow)

        End Sub

        ''' <summary>
        ''' Synchronizes PageCrop datatable changes with PageCrop table in database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SynchronizePageCropData()

            RaiseEvent SynchronizingPageCropInformation()

            PageCropAdapter.Update(Data.PageCrop)

            RaiseEvent PageCropInformationSynchronized()

        End Sub


        'Public Sub temptest(ByVal vehicleId As Integer, ByVal pageNumber As Integer, ByVal adSize As System.Drawing.SizeF, ByVal adRectangle As System.Drawing.RectangleF)

        '    Dim pageNumber As Integer
        '    Dim pageImage As String

        '    Dim isPageImageSplit As Boolean
        '    Dim currentPage, vehicleId, pixelAdjustment As Integer
        '    Dim croppedPageImagePath As String
        '    Dim userResponse As System.Windows.Forms.DialogResult
        '    Dim cropRectangle As System.Drawing.RectangleF
        '    Dim cropImageSize As System.Drawing.Size

        '    'Dim tempQuery As System.Data.EnumerableRowCollection(Of QCDataSet.vwCircularRow)


        '    'If AreInputsValid() = False Then Exit Sub

        '    'RemoveAllErrorProviders()

        '    'tempQuery = From r In Processor.Data.vwCircular _
        '    '            Where r.VehicleId = vehicleId _
        '    '            Select r

        '    'If vehicleIdValueLabel.Text.Trim().Length = 0 Then
        '    '    MessageBox.Show("Load vehicle to Split page image.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    '    Exit Sub
        '    'ElseIf Me.mainAxLEAD.Bitmap = 0 Then
        '    '    MessageBox.Show("There is no image displayed", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    '    Exit Sub
        '    'ElseIf Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        '    '    MessageBox.Show("Unable to identify current Vehicle Id.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    '    Exit Sub
        '    'ElseIf Integer.TryParse(Me.currentPageLabel.Text, currentPage) = False Then
        '    '    MessageBox.Show("Unable to identify current page number.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    '    Exit Sub
        '    'End If

        '    'croppedPageImagePath = "C:\N1L3B3.JPG" 'Processor.GetPageImageFilePath(currentPage)
        '    'Try
        '    '    mainAxLEAD.AddBorder(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, False, False, 1, 1, True)
        '    '    mainAxLEAD.BackColor = System.Drawing.Color.FromArgb(CInt("&H" + ImageBorderColor))
        '    'Catch ex As Exception
        '    '    MessageBox.Show("Exception " + ex.InnerException.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    'End Try




        '    'If Integer.TryParse(currentPageLabel.Text, pageNumber) Then
        '    '    pageImage = Processor.GetPageImageFilePath(vehicleId, pageNumber, Processors.VehicleImageSizeEnum.Unsized)

        '    '    SaveImage(mainAxLEAD, pageImage, ImageFileFormat, BITsPerPixel, ImageCompression, 1)
        '    '    UpdateCurrentPageImageSizeInPixels(vehicleId, pageNumber)
        '    'End If


        '    Dim pageCropId, adSizeId As Integer
        '    'Dim croppedPageImagePath As String
        '    Dim tempRow As QCDataSet.PageCropRow


        '    If AreInputsValid() = False Then Exit Sub

        '    pageCropId = CType(pageCropIdLabel.Text, Integer)
        '    If adSize = System.Drawing.SizeF.Empty Then
        '        adSizeId = 0
        '    Else
        '        adSizeId = Processor.GetSizeId(adSize.Width, adSize.Height)
        '    End If

        '    tempRow = Processor.Data.PageCrop.FindByPageCropId(pageCropId)

        '    UpdatePageCropDataRow(tempRow, adSizeId, adRectangle)

        '    If Processor.AreInputsValid(Processor.Data.vwCircular(0), tempRow) = False Then
        '        If Processor.Data.Errors.Count > 0 Then
        '            ShowErrors(Processor.Data.Errors)
        '            Processor.Data.Errors.Clear()
        '            Exit Sub
        '        ElseIf Processor.Data.Warnings.Count > 0 Then
        '            If ShowWarnings(Processor.Data.Warnings) = Windows.Forms.DialogResult.Cancel Then
        '                Processor.Data.Warnings.Clear()
        '                Exit Sub
        '            End If
        '        End If
        '    End If

        '    Processor.SynchronizePageCropData()

        '    croppedPageImagePath = Processor.GetCroppedPageImagePath(vehicleId, pageCropId)
        '    SaveImage(mainAxLEAD, croppedPageImagePath, ImageFileFormat, BITsPerPixel, ImageCompression, 1)

        '    ' ************************** Omar ******************************
        '    ' Add keep count here based on info that keep is basically crop.
        '    ' **************************************************************
        '    intKeepRectangleCount = intKeepRectangleCount + 1
        '    Me.StatusMessage = "recrp2"


        '    Me.FormState = FormStateEnum.View
        '    ShowHideControls(Me.FormState)
        '    EnableDisableControls(Me.FormState)

        'End Sub



    End Class


End Namespace
