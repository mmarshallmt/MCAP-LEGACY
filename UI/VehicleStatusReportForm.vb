Namespace UI

  Public Class VehicleStatusReportForm
    Implements IForm


    Protected Overrides Sub ClearAllInputs()
      MyBase.ClearAllInputs()

      envelopeIdLinkLabel.Text = String.Empty
      'envelopeIdLinkLabel.Links.Clear()
      senderNameLabel.Text = String.Empty
      vehicleIdValueLabel.Text = String.Empty
            VehicleIDTextBox.Text = String.Empty
      mediaValueLabel.Text = String.Empty
      marketValueLabel.Text = String.Empty
      publicationValueLabel.Text = String.Empty
      breakDtValueLabel.Text = String.Empty
      retailerValueLabel.Text = String.Empty
      tradeclassValueLabel.Text = String.Empty
      languageValueLabel.Text = String.Empty
      startDtValueLabel.Text = String.Empty
      endDtValueLabel.Text = String.Empty
      themeValueLabel.Text = String.Empty
      eventValueLabel.Text = String.Empty
      priorityValueLabel.Text = String.Empty
      couponValueLabel.Text = String.Empty
      flashValueLabel.Text = String.Empty
      spStatusValueLabel.Text = String.Empty

      createdOnValueLabel.Text = String.Empty
      indexedOnValueLabel.Text = String.Empty
      scannedOnValueLabel.Text = String.Empty
      qcedOnValueLabel.Text = String.Empty
      sizedOnValueLabel.Text = String.Empty
      ftpOnValueLabel.Text = String.Empty
      exportStatusValueLabel.Text = String.Empty
      vehicleStatusValueLabel.Text = String.Empty
            'flyerIdValueLabel.Text = String.Empty
            FlyerIDTextBox.Text = String.Empty
            subjectLabel.Text = String.Empty
            SentByLabel.Text = String.Empty
            SentFromLabel.Text = String.Empty
            DurationLabel.Text = String.Empty
            'CircularIdValueLabel.Text = String.Empty
            CircularIDTextBox.Text = String.Empty
            CoverageValueLabel.Text = String.Empty
            SubmittedTimeLabel.Text = String.Empty
            StatusChangedValueLabel.Text = String.Empty

    End Sub


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

      Me.FormState = formStatus
      searchOptionsComboBox.SelectedIndex = 0
      ClearAllInputs()
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

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
    ''' <remarks></remarks>
    Protected Sub LoadPageCropImagesInDataGridView(ByVal vehicleId As Integer, ByVal createDt As DateTime)
      Dim rowCounter As Integer
      Dim imageName As String
      Dim thumbnailImageCell As DataGridViewImageCell


      For rowCounter = 0 To pagecropDataGridView.RowCount - 1
        imageName = pagecropDataGridView.Rows(rowCounter).Cells("PageCropImageNameDataGridViewTextBoxColumn").Value.ToString()
        thumbnailImageCell = CType(pagecropDataGridView.Rows(rowCounter).Cells("CroppedImageThumbnailDataGridViewImageColumn"), DataGridViewImageCell)

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


        ''' <summary>
        ''' Loads Page image in to popup.
        ''' </summary>
        ''' <param name="createDt"></param>
        ''' <param name="vehicleId"></param>
        ''' <param name="imageName"></param>
        ''' <remarks></remarks>
        Private Function viewFullImage(ByVal createDt As DateTime, ByVal vehicleId As Integer, ByVal imageName As String) As String
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
            imagePath.Append("Unsized")
            imagePath.Append("\")
            imagePath.Append(imageName)
            imagePath.Append(".jpg")

          

            If System.IO.File.Exists(imagePath.ToString()) = False Then
                image = My.Resources.NotFound 'Not Found.
                'Return image.ToString
            Else
                Return imagePath.ToString

            End If



        End Function


#End Region


#Region " Methods for loading data from database "


    Private Sub LoadSenderInformation(ByVal senderId As Integer)
      Dim senderAdapter As StatusReportDataSetTableAdapters.SenderTableAdapter


      senderAdapter = New StatusReportDataSetTableAdapters.SenderTableAdapter
      senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      senderAdapter.Fill(Me.StatusReportDataSet.Sender, senderId)

      senderAdapter.Dispose()
      senderAdapter = Nothing
        End Sub
        Private Sub LoadAllSender()
            Dim senderAdapter As StatusReportDataSetTableAdapters.SenderTableAdapter


            senderAdapter = New StatusReportDataSetTableAdapters.SenderTableAdapter
            senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            senderAdapter.FillByAll(Me.StatusReportDataSet.Sender)

            senderAdapter.Dispose()
            senderAdapter = Nothing
        End Sub

    Private Sub LoadSenderInformationForEnvelope(ByVal envelopeId As Integer)
      Dim senderAdapter As StatusReportDataSetTableAdapters.SenderTableAdapter


      senderAdapter = New StatusReportDataSetTableAdapters.SenderTableAdapter
      senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      senderAdapter.FillByEnvelopeId(Me.StatusReportDataSet.Sender, envelopeId)

      senderAdapter.Dispose()
      senderAdapter = Nothing
    End Sub

    Private Sub ShowFlyerIdForVehicle(ByVal vehicleId As Integer)
      Dim vehicleAdapter As StatusReportDataSetTableAdapters.vwVehicleStatusReportTableAdapter


      vehicleAdapter = New StatusReportDataSetTableAdapters.vwVehicleStatusReportTableAdapter
      vehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            FlyerIDTextBox.Text = vehicleAdapter.GetFlyerId(vehicleId)
      vehicleAdapter.Dispose()
      vehicleAdapter = Nothing
        End Sub

        Private Sub ShowCoverageForVehicle(ByVal mktid As Integer, ByVal retid As Integer)

            CoverageValueLabel.Text = GetCoverage(mktid, retid)

        End Sub

        Private Function getSimrUserAndDate(ByVal _VehicleId As Integer) As DataTable

            Dim connection As System.Data.SqlClient.SqlConnection
            Dim command As System.Data.SqlClient.SqlCommand
            Dim adapter As New System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet
            Dim sql As String

            sql = "Select   v.createdt, (select s.name from sender s where s.SenderId=v.CreatedById ) as CreatedBy from Vehicle v where vehicleid =" + _VehicleId.ToString
            connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
            Try
                connection.Open()
                command = New System.Data.SqlClient.SqlCommand(sql, connection)
                adapter.SelectCommand = command
                adapter.Fill(ds)
                adapter.Dispose()
                command.Dispose()
                connection.Close()

                Return ds.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End Function


    Private Sub LoadVehicleInformation(ByVal vehicleId As Integer)
            Dim createDt, startDt, endDt As DateTime
            Dim status As String
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
          If .IsEnvelopeIdNull() = False Then
            LoadSenderInformationForEnvelope(.EnvelopeId)
          ElseIf .IsSenderIdNull() = False Then
            LoadSenderInformation(.SenderId)
          End If
                    If .IsCreateDtNull() OrElse .IsCreatedByNull() Then
                        Dim simrcreated As DataView
                        simrcreated = New DataView(getSimrUserAndDate(.VehicleId))

                        If String.IsNullOrEmpty(simrcreated(0)("createDt").ToString()) = False OrElse String.IsNullOrEmpty(simrcreated(0)("createdby").ToString()) = False Then
                            createdOnValueLabel.Text = simrcreated(0)("createDt").ToString() + " by " + simrcreated(0)("createdby").ToString
                            Dim submittedDate As DateTime = CDate(simrcreated(0)("createDt")) '.AddHours(1)
                            Try
                                'Dim est As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")
                                'Dim targetTime As DateTime = TimeZoneInfo.ConvertTime(submittedDate, est)
                                'SubmittedTimeLabel.Text = targetTime.ToString("hh:mm tt")
                                SubmittedTimeLabel.Text = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(submittedDate, "Central Standard Time", "Eastern Standard Time").ToString("hh:mm tt")

                            Catch e As TimeZoneNotFoundException
                                Console.WriteLine("The registry does not define the Eastern Standard Time zone.")
                            Catch e As InvalidTimeZoneException
                                Console.WriteLine("Registry data on the Eastern Standard Time zone has been corrupted.")
                            End Try
                        Else
                            createdOnValueLabel.Text = String.Empty
                            SubmittedTimeLabel.Text = String.Empty
                        End If
                    Else
                        createdOnValueLabel.Text = .CreateDt.ToString("MM/dd/yyyy HH:mm:ss.fff") + " by " + .CreatedBy
                        createDt = .CreateDt
                        SubmittedTimeLabel.Text = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(.CreateDt, "Central Standard Time", "Eastern Standard Time").ToString("hh:mm tt")
                        'SubmittedTimeLabel.Text = .CreateDt.ToString("hh:mm tt")

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
                    If .IsSubjectNull Then
                        subjectLabel.Text = String.Empty
                    Else
                        subjectLabel.Text = .Subject.ToString
                    End If

                    If .IsSentByNull Then
                        SentByLabel.Text = String.Empty
                    Else
                        SentByLabel.Text = .SentBy
                    End If

                    If .IsSentFromNull Then
                        SentFromLabel.Text = String.Empty
                    Else
                        SentFromLabel.Text = .SentFrom
                    End If

                    If .IsCircularIDNull Then
                        CircularIDTextBox.Text = String.Empty
                        CircularIdLabel.Visible = False
                        CircularIDTextBox.Visible = False
                    Else
                        CircularIdLabel.Visible = True
                        CircularIDTextBox.Visible = True
                        CircularIDTextBox.Text = .CircularID.ToString()
                    End If
                    If .IsStartDtNull = False And .IsEndDtNull = False Then
                        startDt = .StartDt
                        endDt = .EndDt
                        Dim DaysBetween As Integer = (endDt.Subtract(startDt).Days) + 1
                        DurationLabel.Text = DaysBetween.ToString + " Day/s"
                    Else
                        DurationLabel.Text = String.Empty
                    End If
                    If .IsStatusNull = False Then
                        status = .Status
                    Else
                        status = ""
                    End If
                    If .IsStatusChangeByNull = False And (status.ToLower = "duplicate" Or status.ToLower = "wrong version") Then
                        statusChangesLabel.Visible = True
                        StatusChangedValueLabel.Visible = True
                        StatusChangedValueLabel.Text = .StatusChangeBy
                    Else
                        statusChangesLabel.Visible = False
                        StatusChangedValueLabel.Visible = False

                    End If

                    If .IsCompareVehicleIdNull Then
                        MatchedInPaperLabel.Visible = False
                        MatchedInPaperValueLabel.Visible = False
                        MatchedInPaperValueLabel.Text = String.Empty
                    Else
                        MatchedInPaperLabel.Visible = True
                        MatchedInPaperValueLabel.Visible = True
                        MatchedInPaperValueLabel.Text = .CompareVehicleId.ToString
                    End If
                    'Coverage added
                    If .IsRetIdNull = False And .IsMktIdNull = False Then
                        ShowCoverageForVehicle(.MktId, .RetId)
                    End If

                    If .IsVersionNumberNull() Then
                        versioNumberValueLabel.Text = String.Empty
                        versioNumberValueLabel.Visible = False
                        VersionNumberLable.Visible = False
                    Else
                        versioNumberValueLabel.Visible = True
                        VersionNumberLable.Visible = True
                        versioNumberValueLabel.Text = .VersionNumber.ToString()

                    End If

                    If .IsSPReviewStatusIdNull() = False AndAlso .SPReviewStatusId = 67 Then
                        With spStatusValueLabel
                            .Font = New System.Drawing.Font(.Font, FontStyle.Bold)
                            .ForeColor = Color.Red
                        End With
                    Else
                        With spStatusValueLabel
                            .Font = New System.Drawing.Font(.Font, FontStyle.Regular)
                            .ForeColor = System.Drawing.SystemColors.WindowText
                        End With
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
      pagecropDataGridView.DataSource = Me.StatusReportDataSet.PageCrop

      ShowFlyerIdForVehicle(vehicleId)
      Me.StatusMessage = "Loading page images as thumbnail. This may take some time. Please wait..."
      LoadPageImagesInDataGridView(vehicleId, createDt)
      Me.StatusMessage = "Loading cropped page images as thumbnail. This may take some time. Please wait..."
      LoadPageCropImagesInDataGridView(vehicleId, createDt)
      Me.StatusMessage = String.Empty

    End Sub

    Private Function GetVehicleForFlyer(ByVal flyerId As String) As Integer?
      Dim vehicleId As Integer?
      Dim vehicleAdapter As StatusReportDataSetTableAdapters.vwVehicleStatusReportTableAdapter


      vehicleAdapter = New StatusReportDataSetTableAdapters.vwVehicleStatusReportTableAdapter
      vehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      vehicleId = vehicleAdapter.GetVehicleId(flyerId)
      vehicleAdapter.Dispose()
      vehicleAdapter = Nothing

      Return vehicleId

        End Function

        Private Function GetCoverage(ByVal mktID As Integer, ByVal retId As Integer) As String
            Dim Coverage As String
            Dim vehicleAdapter As StatusReportDataSetTableAdapters.vwVehicleStatusReportTableAdapter

            vehicleAdapter = New StatusReportDataSetTableAdapters.vwVehicleStatusReportTableAdapter
            vehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            Coverage = vehicleAdapter.GetCoverage(mktID, retId)
            vehicleAdapter.Dispose()
            vehicleAdapter = Nothing

            Return Coverage

        End Function

   

#End Region


    ''' <summary>
    ''' Loads vehicle and vehicle pages information.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Public Sub ShowVehicleInformation(ByVal vehicleId As Integer)

      searchTextBox.Text = vehicleId.ToString()
      searchButton.PerformClick()

    End Sub


    Private Sub searchButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchButton.Click

            If searchOptionsComboBox.SelectedIndex = 1 Then
                Dim vehicleId As Integer?

                If searchTextBox.Text.Trim().Length = 0 Then
                    MessageBox.Show("Provide valid flyer Id.", ProductName _
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                vehicleId = GetVehicleForFlyer(searchTextBox.Text)
                If vehicleId.HasValue = False Then
                    MessageBox.Show("Associated Vehicle not found for Flyer " + searchTextBox.Text + "." _
                                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                LoadVehicleInformation(vehicleId.Value)

                If Me.StatusReportDataSet.vwVehicleStatusReport.Count = 0 Then
                    MessageBox.Show("Vehicle associated with Flyer " + searchTextBox.Text + ", not found." _
                                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                Dim vehicleId As Integer

                If Integer.TryParse(searchTextBox.Text, vehicleId) = False Then
                    MessageBox.Show("Provide valid vehicle Id.", ProductName _
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                LoadVehicleInformation(vehicleId)

                If Me.StatusReportDataSet.vwVehicleStatusReport.Count = 0 Then
                    MessageBox.Show("Vehicle " + vehicleId.ToString() + " not found." _
                                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

    End Sub

    Private Sub envelopeIdLinkLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles envelopeIdLinkLabel.Click
      Dim envelopeId As Integer
      Dim envStatusForm As EnvelopeStatusReportForm


      If Integer.TryParse(envelopeIdLinkLabel.Text, envelopeId) = False Then
        MessageBox.Show("Unable to find envelope Id. Cannot load envelope status information screen." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      envStatusForm = New EnvelopeStatusReportForm()
      envStatusForm.Init(FormStateEnum.View)
      envStatusForm.ApplyUserCredentials()
      envStatusForm.LoadEnvelope(envelopeId)
      envStatusForm.ShowDialog(Me)

      envStatusForm.Dispose()
      envStatusForm = Nothing

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

        Private Sub searchGroupBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles searchGroupBox.Enter

        End Sub

        Private Sub FillToolStripButton_Click(sender As Object, e As EventArgs) Handles FillToolStripButton.Click
            Try
                Me.VwVehicleStatusReportTableAdapter.Fill(Me.StatusReportDataSet.vwVehicleStatusReport, New System.Nullable(Of Integer)(CType(EnvelopeIdToolStripTextBox.Text, Integer)))
            Catch ex As System.Exception
                System.Windows.Forms.MessageBox.Show(ex.Message)
            End Try

        End Sub

        Private Sub pagesDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles pagesDataGridView.CellContentClick
            Dim ImagePath As String
            Dim createDt As DateTime
            Dim vehicleCreateDt As Object
            Dim ImageCommand As System.Data.SqlClient.SqlCommand
            Dim vehicleid As Integer
            Try
                ImageCommand = New System.Data.SqlClient.SqlCommand
                vehicleid = CInt(VehicleIDTextBox.Text)
                With ImageCommand
                    .CommandText = "SELECT CreateDt FROM Vehicle WHERE VehicleId=" + vehicleid.ToString()
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
       
            ImagePath = viewFullImage(CDate(vehicleCreateDt), CInt(vehicleid), pagesDataGridView.CurrentRow.Cells("ImageNameDataGridViewTextBoxColumn").Value.ToString())
            Dim objImageViewer As New ImagesViewForm
            'objImageViewer.Image(ImagePath)
            objImageViewer.ImageFilePath = ImagePath
            objImageViewer.ShowDialog()
        End Sub

        Private Sub VehicleIDTextBox_Click(sender As Object, e As EventArgs) Handles VehicleIDTextBox.Click
            VehicleIDTextBox.Focus()
        End Sub

        Private Sub VehicleStatusReportForm_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If vehicleIdValueLabel.ContainsFocus And e.Control And e.KeyCode = Keys.C Then
                Clipboard.SetText(VehicleIDTextBox.Text)
            End If

        End Sub

    End Class

End Namespace