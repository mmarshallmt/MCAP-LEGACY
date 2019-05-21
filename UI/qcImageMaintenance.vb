Imports MCAP.UI

Public Class qcImageMaintenance
    Implements IForm

    Dim vehicleId As Integer
    Private WithEvents m_Processor As Processors.QCVehicleImages

    Private ReadOnly Property Processor() As Processors.QCVehicleImages
        Get
            Return m_Processor
        End Get
    End Property

#Region " IForm Implementation "


    Public Event InitializingForm() Implements IForm.InitializingForm
    Public Event FormInitialized() Implements IForm.FormInitialized

    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied


    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials
        Dim appUser As Processors.ApplicationUser


        RaiseEvent ApplyingUserCredentials()

        appUser = New Processors.ApplicationUser
        appUser.Initialize()
        appUser.GetFunctionalityListFor(appUser.UserID, Me.Name)


        appUser = Nothing

        RaiseEvent UserCredentialsApplied()

    End Sub


    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

        RaiseEvent InitializingForm()

        m_Processor = New Processors.QCVehicleImages()
        Processor.Initialize()

        Me.SuspendLayout()

        Me.ResumeLayout()

        RaiseEvent FormInitialized()

    End Sub


#End Region

#Region " Image ReSizing related methods "


    ''' <summary>
    ''' If image file path is correct, returns object containing resized image. 
    ''' This does not affect actual image file.
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <param name="imageWidth"></param>
    ''' <param name="imageHeight"></param>
    ''' <param name="resizeOnlyIfWider"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' If file does not exist, returns Nothing.
    ''' Reference URL = http://www.codeproject.com/KB/grid/ImagePreviewDataGridView.aspx
    ''' </remarks>
    Public Function GetResizedImage(ByVal filePath As String, ByVal imageWidth As Integer, ByVal imageHeight As Integer, ByVal resizeOnlyIfWider As Boolean) As System.Drawing.Image

        If System.IO.File.Exists(filePath) = False Then Return Nothing

        Using image As System.Drawing.Image = System.Drawing.Image.FromFile(filePath)
            'Prevent using images internal thumbnail
            image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            image.RotateFlip(RotateFlipType.Rotate180FlipNone)

            If resizeOnlyIfWider Then
                If image.Width <= imageWidth Then imageWidth = image.Width
            End If

            Dim resizedImage As System.Drawing.Image

            resizedImage = image.GetThumbnailImage(imageWidth, imageHeight, Nothing, IntPtr.Zero)

            Return resizedImage
        End Using

    End Function

    ''' <summary>
    ''' If image file path is correct, returns object containing resized image. 
    ''' This does not affect actual image file.
    ''' </summary>
    ''' <param name="image"></param>
    ''' <param name="imageWidth"></param>
    ''' <param name="imageHeight"></param>
    ''' <param name="resizeOnlyIfWider"></param>
    ''' <returns></returns>
    ''' <remarks>If file does not exist, returns Nothing.</remarks>
    Public Function GetResizedImage(ByVal image As System.Drawing.Bitmap, ByVal imageWidth As Integer, ByVal imageHeight As Integer, ByVal resizeOnlyIfWider As Boolean) As System.Drawing.Image
        Dim resizedImage As System.Drawing.Image


        If image Is Nothing Then Return Nothing

        'Prevent using images internal thumbnail
        image.RotateFlip(RotateFlipType.Rotate180FlipNone)
        image.RotateFlip(RotateFlipType.Rotate180FlipNone)

        If resizeOnlyIfWider Then
            If image.Width <= imageWidth Then imageWidth = image.Width
        End If

        resizedImage = image.GetThumbnailImage(imageWidth, imageHeight, Nothing, IntPtr.Zero)

        Return resizedImage

    End Function

    ''' <summary>
    ''' Gets resized image object to display image in data grid. It takes care 
    ''' of maintaining image's width:height ratio based on application parameters.
    ''' </summary>
    ''' <param name="imagePath">Path to image file, which is to be displayed on grid.</param>
    ''' <returns></returns>
    ''' <remarks>If image file does not exist, returns Nothing.</remarks>
    Private Function GetResizedImageForGrid(ByVal imagePath As String) As System.Drawing.Image
        Dim resizeWidth, resizeHeight, widthDiff, heightDiff As Integer
        Dim displayImage As System.Drawing.Image


        If System.IO.File.Exists(imagePath) = False Then Return Nothing

        displayImage = System.Drawing.Image.FromFile(imagePath)

        If MaintainAspectRatioInGrid = False Then  'If resize with same scale
            resizeWidth = ImageWidthInGrid
            resizeHeight = ImageHeightInGrid
        Else
            widthDiff = Math.Abs(displayImage.Width - ImageWidthInGrid)
            heightDiff = Math.Abs(displayImage.Height - ImageHeightInGrid)

            If widthDiff > heightDiff Then
                resizeWidth = ImageWidthInGrid
                resizeHeight = CType(displayImage.Height * (resizeWidth / displayImage.Width), Integer)
            Else
                resizeHeight = ImageHeightInGrid
                resizeWidth = CType(displayImage.Width * (resizeHeight / displayImage.Height), Integer)
            End If
        End If

        displayImage.Dispose()

        displayImage = GetResizedImage(imagePath, resizeWidth, resizeHeight, Not MaintainAspectRatioInGrid)

        Return displayImage

    End Function

    ''' <summary>
    ''' Gets resized image object to display image in data grid. It takes care 
    ''' of maintaining image's width:height ratio based on application parameters.
    ''' </summary>
    ''' <param name="image">Image, which is to be displayed on grid.</param>
    ''' <returns></returns>
    ''' <remarks>If image does not exist, returns Nothing.</remarks>
    Private Function GetResizedImageForGrid(ByVal image As System.Drawing.Bitmap) As System.Drawing.Image
        Dim resizeWidth, resizeHeight, widthDiff, heightDiff As Integer
        Dim displayImage As System.Drawing.Image


        displayImage = image

        If MaintainAspectRatioInGrid = False Then  'If resize with same scale
            resizeWidth = ImageWidthInGrid
            resizeHeight = ImageHeightInGrid
        Else
            widthDiff = Math.Abs(displayImage.Width - ImageWidthInGrid)
            heightDiff = Math.Abs(displayImage.Height - ImageHeightInGrid)

            If widthDiff > heightDiff Then
                resizeWidth = ImageWidthInGrid
                resizeHeight = CType(displayImage.Height * (resizeWidth / displayImage.Width), Integer)
            Else
                resizeHeight = ImageHeightInGrid
                resizeWidth = CType(displayImage.Width * (resizeHeight / displayImage.Height), Integer)
            End If
        End If

        displayImage = Nothing

        displayImage = GetResizedImage(image, resizeWidth, resizeHeight, Not MaintainAspectRatioInGrid)

        Return displayImage

    End Function

    ''' <summary>
    ''' Loads Page image in DataGridViewImageCell.
    ''' </summary>
    ''' <param name="createDt"></param>
    ''' <param name="vehicleId"></param>
    ''' <param name="imageName"></param>
    ''' <param name="pageImageCell"></param>
    ''' <remarks></remarks>
    Private Sub LoadPageImageInCell(ByVal createDt As DateTime, ByVal vehicleId As Integer, ByVal imageName As String, ByVal pageImageCell As DataGridViewImageCell)
        Dim imagePath As System.Text.StringBuilder
        Dim image As System.Drawing.Bitmap
        Dim temppath As String

        imagePath = New System.Text.StringBuilder

        temppath = GetImagePath(createDt.ToString("yyyyMM"), User.LocationId, GetPathType("Master"))
        If String.IsNullOrEmpty(temppath) = False Then
            imagePath.Append(temppath)
        Else
            imagePath.Append(VehicleImageFolderPath)
            imagePath.Append("\")
            imagePath.Append(createDt.ToString("yyyyMM"))
            imagePath.Append("\")
        End If

        imagePath.Append(vehicleId.ToString())
        imagePath.Append("\")
        imagePath.Append(ThumbSizedPageImageFolderName)
        imagePath.Append("\")
        imagePath.Append(imageName)
        imagePath.Append(".jpg")

        If System.IO.File.Exists(imagePath.ToString()) = False Then
            imagePath = imagePath.Replace("\" + ThumbSizedPageImageFolderName + "\" + imageName + ".jpg" _
                                          , "\" + UnsizedPageImageFolderName + "\" + imageName + ".jpg")
        End If

        pageImageCell.ToolTipText = imagePath.ToString()

        If System.IO.File.Exists(imagePath.ToString()) = False Then
            'If AreVehiclePageImagesScanned(vehicleId) = False Then
            '  image = My.Resources.NotScanned 'Not Scanned.
            'ElseIf AreVehicleImagesTransferred(vehicleId, User.LocationId) = False Then
            '  image = My.Resources.NotTransferred 'Not Transferred.
            'Else
            image = My.Resources.NotFound 'Not Found.
            'End If
        End If

        Try
            If image Is Nothing Then
                pageImageCell.Value = GetResizedImageForGrid(imagePath.ToString())
            Else
                pageImageCell.Value = GetResizedImageForGrid(image)
            End If
        Catch ex As ArgumentException
            Trace.TraceError("FamilyBaseForm.LoadPageImageInCell(): Throwing new ApplicationException(Page Image not found at: imagePath). Message=" + ex.Message, New Object() {"createDt=", createDt, "VehicleId=", vehicleId, "imageName=", imageName, "ImagePath=", imagePath.ToString(), ex})
            Throw New ApplicationException("Page image not found at " + imagePath.ToString(), ex)
        Finally
            imagePath = Nothing
            imageName = Nothing
        End Try

    End Sub

    ''' <summary>
    ''' Loads image in grid. While displaying image in grid, it is resized as 
    ''' per the application parameters. If thumbnail image is not available, 
    ''' unsized scanned image is used.
    ''' </summary>
    ' ''' <remarks></remarks>
    'Protected Sub LoadPageCropImagesInDataGridView(ByVal vehicleId As Integer, ByVal createDt As DateTime)
    '    Dim rowCounter As Integer
    '    Dim imageName As String
    '    Dim thumbnailImageCell As DataGridViewImageCell


    '    For rowCounter = 0 To pagecropDataGridView.RowCount - 1
    '        imageName = pagecropDataGridView.Rows(rowCounter).Cells("PageCropImageNameDataGridViewTextBoxColumn").Value.ToString()
    '        thumbnailImageCell = CType(pagecropDataGridView.Rows(rowCounter).Cells("CroppedImageThumbnailDataGridViewImageColumn"), DataGridViewImageCell)

    '        Try
    '            LoadPageImageInCell(createDt, vehicleId, imageName, thumbnailImageCell)
    '        Catch ex As Exception
    '            Trace.TraceError("FamilyBaseForm.LoadPageImageInCell(): Message=" + ex.Message, New Object() {"createDt=", createDt, "VehicleId=", vehicleId, "Page=", 1})
    '            My.Application.Log.WriteException(ex)
    '        Finally
    '            thumbnailImageCell = Nothing
    '        End Try
    '    Next

    'End Sub

    ''' <summary>
    ''' Loads image in grid. While displaying image in grid, it is resized as 
    ''' per the application parameters. If thumbnail image is not available, 
    ''' unsized scanned image is used.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub LoadPageImagesInDataGridView(ByVal vehicleId As Integer, ByVal createDt As DateTime)
        Dim rowCounter As Integer
        Dim imageName As String
        Dim thumbnailImageCell As DataGridViewImageCell


        For rowCounter = 0 To pagesDataGridView.RowCount - 1
            imageName = pagesDataGridView.Rows(rowCounter).Cells("ImageNameDataGridViewTextBoxColumn").Value.ToString()
            thumbnailImageCell = CType(pagesDataGridView.Rows(rowCounter).Cells("ThumbnailDataGridViewImageColumn"), DataGridViewImageCell)

            Try
                LoadPageImageInCell(createDt, vehicleId, imageName, thumbnailImageCell)
            Catch ex As Exception
                Trace.TraceError("FamilyBaseForm.LoadPageImageInCell(): Message=" + ex.Message, New Object() {"createDt=", createDt, "VehicleId=", vehicleId, "Page=", 1})
                My.Application.Log.WriteException(ex)
            Finally
                thumbnailImageCell = Nothing
            End Try
        Next

    End Sub


#End Region

    Private Sub LoadVehicleInformation(ByVal vehicleId As Integer)
        Dim createDt As DateTime
        Dim vehicleAdapter As StatusReportDataSetTableAdapters.vwVehicleStatusReportTableAdapter
        Dim pageAdapter As StatusReportDataSetTableAdapters.PageTableAdapter
        Dim pagecropAdapter As StatusReportDataSetTableAdapters.PageCropTableAdapter

        vehicleAdapter = New StatusReportDataSetTableAdapters.vwVehicleStatusReportTableAdapter
        pageAdapter = New StatusReportDataSetTableAdapters.PageTableAdapter
        pagecropAdapter = New StatusReportDataSetTableAdapters.PageCropTableAdapter()

        vehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        pageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        pagecropAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

        vehicleAdapter.FillByVehicleId(Me.StatusReportDataSet.vwVehicleStatusReport, vehicleId)
        If Me.StatusReportDataSet.PageCrop.Count > 0 Then Me.StatusReportDataSet.PageCrop.Rows.Clear()
        pageAdapter.Fill(Me.StatusReportDataSet.Page, vehicleId)
        pagecropAdapter.Fill(Me.StatusReportDataSet.PageCrop, vehicleId)
        If Me.StatusReportDataSet.vwVehicleStatusReport.Count > 0 Then
            With Me.StatusReportDataSet.vwVehicleStatusReport(0)

                If .IsCreateDtNull() OrElse .IsCreatedByNull() Then
                    createdOnValueLabel.Text = String.Empty
                Else
                    createdOnValueLabel.Text = .CreateDt.ToString("MM/dd/yyyy HH:mm:ss.fff") + " by " + .CreatedBy
                    createDt = .CreateDt
                End If
                If .IsIndexDtNull() OrElse .IsIndexedByNull() Then
                    indexedOnValueLabel.Text = String.Empty
                Else
                    indexedOnValueLabel.Text = .IndexDt.ToString("MM/dd/yyyy HH:mm:ss.fff") + " by " + .IndexedBy
                End If
                If .IsScanDtNull() OrElse .IsScannedByNull() Then
                    scannedOnValueLabel.Text = String.Empty
                Else
                    scannedOnValueLabel.Text = .ScanDt.ToString("MM/dd/yyyy HH:mm:ss.fff") + " by " + .ScannedBy
                End If
                If .IsQCDtNull() OrElse .IsQCedByNull() Then
                    qcedOnValueLabel.Text = String.Empty
                Else
                    qcedOnValueLabel.Text = .QCDt.ToString("MM/dd/yyyy HH:mm:ss.fff") + " by " + .QCedBy
                End If

            End With
        End If

        vehicleAdapter.Dispose()
        pageAdapter.Dispose()
        pagecropAdapter.Dispose()
        vehicleAdapter = Nothing
        pageAdapter = Nothing
        pagecropAdapter = Nothing

        pagesDataGridView.DataSource = Me.StatusReportDataSet.Page

        LoadPageImagesInDataGridView(vehicleId, createDt)

    End Sub



    Private Sub searchButton_Click(sender As Object, e As EventArgs) Handles searchButton.Click
        Dim isQced As Boolean

        If Integer.TryParse(txtVehicleID.Text, vehicleId) = False Then
            MessageBox.Show("Provide valid vehicle Id.", ProductName _
                            , MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtVehicleID.Focus()
            Exit Sub
        End If
        'isQced = isVehicleQCed(vehicleId)
        'If isQced = False Then
        '    MessageBox.Show("Vehicle " & vehicleId & " Has not been Qced.")
        '    Exit Sub
        'End If

        LoadVehicleInformation(vehicleId)
        btnContinueQc.Enabled = True
        btnResetImages.Enabled = True
        If Me.StatusReportDataSet.vwVehicleStatusReport.Count = 0 Then
            MessageBox.Show("Vehicle " + vehicleId.ToString() + " not found." _
                            , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
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
  
    Private Sub UpdatePageImageName(ByVal _receivedorder As Integer, ByVal _pageid As Integer)
        Dim cmd As System.Data.SqlClient.SqlCommand
        Dim obj As New Object
        Dim _ImageName As String
        _ImageName = ""
        cmd = New System.Data.SqlClient.SqlCommand

        Try
            With cmd
                If _ImageName = "" Then
                    '  _ImageName = Null
                Else
                    _ImageName = "'" + _ImageName + "'"
                End If
                .CommandText = "UPDATE Page SET ImageName = Null where pageid = " + _pageid.ToString + " AND ReceivedOrder = " + _receivedorder.ToString
                .CommandType = CommandType.Text
                .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                .Connection.Open()
                .ExecuteNonQuery()
            End With

        Catch ex As Exception
            Throw New ApplicationException("Failed to restore Page Details.", ex)
        Finally
            If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
        End Try

    End Sub

    Private Sub btnResetImages_Click(sender As Object, e As EventArgs) Handles btnResetImages.Click
        If (MessageBox.Show("Are you sure you want to Reset Images?", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        End If
        Dim pageid, reorder As Integer
        Dim imageName As String
        For i As Integer = 0 To pagesDataGridView.Rows.Count - 1
            pageid = CType(pagesDataGridView.Rows(i).Cells(2).Value, Integer)
            reorder = CType(pagesDataGridView.Rows(i).Cells(5).Value, Integer)
            imageName = CType(pagesDataGridView.Rows(i).Cells(3).Value, String)

            If resetImageNames(imageName, reorder, pageid) Then
                Me.UpdatePageImageName(reorder, pageid)
            End If
        Next
        MessageBox.Show("All Images were restored Successfully.")
        Me.LoadVehicleInformation(vehicleId)
    End Sub
    Private Function resetImageNames(ByVal imageName As String, ByVal reorder As Integer, ByVal pageid As Integer) As Boolean

        Dim _success As Boolean
        _success = False

        Dim pageImageFolderCounter, pageImageFileCounter As Integer
        Dim pageImageFolderPath As String
        Dim pageImageFilePath As System.Text.StringBuilder
        Dim newImageFileName As System.Text.StringBuilder
        Dim mw As New Processors.MidWeek

        pageImageFilePath = New System.Text.StringBuilder()
        newImageFileName = New System.Text.StringBuilder()

        Dim dt As String = mw.RetrieveYearMonth(vehicleId)
        Dim _path As String = mw.GetImagePath(dt, mw.GetPathType("Master"))
        _path = _path + "\" + dt + "\" + vehicleId.ToString + "\Unsized"

        pageImageFilePath.Append(_path)
        pageImageFilePath.Append("\")
        pageImageFilePath.Append(imageName)
        pageImageFilePath.Append(ImageFileExtension)

        ' newImageFileName.Append(_path)
        ' newImageFileName.Append("\")
        newImageFileName.Append(reorder.ToString("000"))
        newImageFileName.Append(ImageFileExtension)

        If My.Computer.FileSystem.FileExists(pageImageFilePath.ToString()) Then
            If My.Computer.FileSystem.FileExists(newImageFileName.ToString()) = False Then
                'newImageFileName = Data.Page(pageImageFileCounter).ImageName + ImageFileExtension
                My.Computer.FileSystem.RenameFile(pageImageFilePath.ToString(), newImageFileName.ToString)
                newImageFileName = Nothing
                _success = True
            End If
        End If

        pageImageFilePath.Remove(0, pageImageFilePath.Length)

        Return _success
    End Function

    Public Function fileExist(ByVal pageImageFilePath As String) As Boolean
        Dim _success As Boolean
        _success = False
        If My.Computer.FileSystem.FileExists(pageImageFilePath.ToString()) Then
            _success = True

        End If
        Return _success
    End Function

    Public Sub clearForm()
        btnResetImages.Enabled = False
        btnContinueQc.Enabled = False

        txtVehicleID.Text = String.Empty
        createdOnValueLabel.Text = String.Empty
        indexedOnValueLabel.Text = String.Empty
        scannedOnValueLabel.Text = String.Empty
        qcedOnValueLabel.Text = String.Empty
        startDtValueLabel.Text = String.Empty
        retailerValueLabel.Text = String.Empty
        marketValueLabel.Text = String.Empty
        startDtValueLabel.Text = String.Empty
        DirectCast(pagesDataGridView.DataSource, DataTable).Rows.Clear()
    End Sub

    Private Sub bntContinueQc_Click(sender As Object, e As EventArgs) Handles btnContinueQc.Click

        Dim pageid, reorder As Integer
        Dim imageName As String

        Dim pageImageFolderCounter, pageImageFileCounter As Integer
        Dim pageImageFolderPath As String
        Dim pageImageFilePath As System.Text.StringBuilder
        Dim newImageFileName As System.Text.StringBuilder
        Dim mw As New Processors.MidWeek


        newImageFileName = New System.Text.StringBuilder()

        Dim dt As String = mw.RetrieveYearMonth(vehicleId)
        Dim _path As String = mw.GetImagePath(dt, mw.GetPathType("Master"))
        _path = _path + "\" + dt + "\" + vehicleId.ToString + "\Unsized"

        For i As Integer = 0 To pagesDataGridView.Rows.Count - 1
            pageid = CType(pagesDataGridView.Rows(i).Cells(2).Value, Integer)
            reorder = CType(pagesDataGridView.Rows(i).Cells(5).Value, Integer)
            imageName = CType(pagesDataGridView.Rows(i).Cells(3).Value, String)
            pageImageFilePath = New System.Text.StringBuilder()
            pageImageFilePath.Append(_path)
            pageImageFilePath.Append("\")
            pageImageFilePath.Append(imageName)
            pageImageFilePath.Append(ImageFileExtension)

            If fileExist(pageImageFilePath.ToString()) = False Then
                Me.UpdatePageImageName(reorder, pageid)
            End If
        Next
        'Dim PR = New Processors.QCVehicleImages
        'PR.RenameVehiclePageImageFiles(vehicleId)
        Me.LoadVehicleInformation(vehicleId)
        MessageBox.Show("Vehicle Images successfully Reset. Please reQC", ProductName _
                                       , MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearForm()
    End Sub

    Private Sub qcImageMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnResetImages.Enabled = False
        btnContinueQc.Enabled = False
    End Sub

End Class
