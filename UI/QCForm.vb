﻿Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Math
Namespace UI

    Public Class QCForm
        Implements IForm


        ''' <summary>
        ''' This constant is used to assigning value to FormName column.
        ''' </summary>
        ''' <remarks></remarks>
        Private Const FORM_NAME As String = "Image QC"
        'Private WithEvents m_maintenanceProcessor As Processors.Maintenance

        Private m_MediaRectColor As System.Drawing.Color

        Private WithEvents m_Processor As Processors.QCVehicleImages
        Private WithEvents wrongID As UI.Processors.EnvelopeContent
        Private m_IsNAPublicationsOnly, m_IsFSI, m_IsMediaTypeWebsite As Boolean
        Private intImageRotationCount As Integer
        Private intKeepRectangleCount As Integer
        Private intRemoveRectangleCount As Integer
        Private intDeleteImageCount As Integer
        Private intResequenceCount As Integer
        ' boolen images click
        Private blnImageRotationChange As Boolean
        Private blnKeepRectangleChange As Boolean
        Private blnRemoveRectangleChange As Boolean
        Private blnDeleteImageChange As Boolean
        Private blnResequenceChange As Boolean
        Private blnReQcScreen As Boolean
        Private m_inReQC As Boolean
        Private m_OKtoReQC As Boolean
        Private m_formAlrdyOpened As Boolean
        Private isPageCropped As Boolean
        Private filterHelp As QcSubjectButtonForm
        Private m_isWrongVersion As Boolean

        'Draw Objects in the Image
        Private MyGraphics As Graphics
        Private MyRect As Rectangle
        Private MyPen As Pen
        Private TempImage As Image
        Private PgCropImage As Bitmap

        'Thumbnails
        Private rowIndex As Integer = 0

        Private _filePath As String
        Private temp_img As Bitmap
        Private _CurrentAngle As Integer
        Private _sender As Integer = 0
        Private isAssociated As Boolean

        'page definitions
        Private arrPageName As New List(Of String)

        Private isClosedByButton As Boolean = False
        Private m_isSIMR As Boolean = False
        Public AllowCacheImage As Boolean
        Private LocalImageFolderPath As String

        ' temporary rect storage
        Private tmpIsRectKept As Integer = -1
        ''' <summary>
        ''' Instance of class QCVehicleImages
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property Processor() As Processors.QCVehicleImages
            Get
                Return m_Processor
            End Get
        End Property

        ''' <summary>
        ''' Gets value indicating whether to load all valid publications or just NA only.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property IsNAPublicationsOnly() As Boolean
            Get
                Return m_IsNAPublicationsOnly
            End Get
        End Property

        ''' <summary>
        ''' Gets boolean value indicating whether current vehicle is created for FSI or not.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property IsFSI() As Boolean
            Get
                Return m_IsFSI
            End Get
        End Property

        ''' <summary>
        ''' Gets boolean value indicating whether current vehicle is having media type as "Website" or not.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property IsMediaTypeWebsite() As Boolean
            Get
                Return m_IsMediaTypeWebsite
            End Get
        End Property

        Private Property IsWrongVersion() As Boolean
            Get
                Return m_isWrongVersion
            End Get
            Set(ByVal value As Boolean)
                m_isWrongVersion = value
            End Set
        End Property

        Private Property IsSIMR() As Boolean
            Get
                Return m_isSIMR
            End Get
            Set(ByVal value As Boolean)
                m_isSIMR = value
            End Set
        End Property

        ''' <summary>
        ''' Clears all inputs on form.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub ClearAllInputs()

            findVehicleIdTextBox.Clear()
            flagForDetailEntryCheckBox.Checked = False
            parentVehicleIdTextBox.Clear()
            vehicleIdValueLabel.Text = String.Empty
            indexStatusTextLabel.Text = String.Empty
            qcStatusTextLabel.Text = String.Empty
      adDateTypeInDatePicker.Clear()
      DistDateTypeInDatePicker.Clear()
            mediaComboBox.SelectedValue = DBNull.Value
            marketComboBox.SelectedValue = DBNull.Value
            publicationComboBox.SelectedValue = DBNull.Value
            languageComboBox.SelectedValue = DBNull.Value
            retailerComboBox.SelectedValue = DBNull.Value
            tradeclassValueLabel.Text = String.Empty
            priorityValueLabel.Text = String.Empty
            eventComboBox.SelectedValue = DBNull.Value
            themeComboBox.SelectedValue = DBNull.Value
            startDateTypeInDatePicker.Clear()
            endDateTypeInDatePicker.Clear()
            couponCheckBox.Checked = False
            flashAdCheckBox.Checked = False
            CommentsTextBox.Text = String.Empty
            ImageDisplay.Image = Nothing
            txtSubject.Text = String.Empty
            currentPageLabel.Text = "0"
            totalPagesLabel.Text = "0"
            findImageTextBox.Clear()
            definePagesButton.Text = "Define &Pages"
            pageCropIdLabel.Text = String.Empty
            pageIdLabel.Text = String.Empty
            CoverageValueLabel.Text = String.Empty
            CircularIdLabel.Text = String.Empty
        End Sub
        Private Sub SetRectColor()
            Select Case mediaComboBox.Text.ToUpper()
                Case "SOCIAL"
                    m_MediaRectColor = Color.Red
                Case "WEBSITE"
                    m_MediaRectColor = Color.Green
                Case Else
                    m_MediaRectColor = Color.Blue
            End Select

        End Sub

        Private Sub UpdatePageImageName(ByVal _ImageName As String, ByVal _receivedorder As Integer, ByVal _vehicle As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As New Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    If _ImageName = "" Then
                        _ImageName = "Null"
                    Else
                        _ImageName = "'" + _ImageName + "'"
                    End If
          .CommandText = "UPDATE Page SET ImageName = " + _ImageName + " where VehicleId = " + _vehicle.ToString + " AND ReceivedOrder = " + _receivedorder.ToString + " and ImageName is null"
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

        Public Function isVehicleQCed(ByVal _vehicleid As Integer) As Boolean


            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim obj As Object
            Dim stat As Integer

            cmd = New System.Data.SqlClient.SqlCommand
            con = New System.Data.SqlClient.SqlConnection

            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()

            cmd.Connection = con

            cmd.CommandType = CommandType.Text

            cmd.CommandText = "Select StatusId FROM vwcircular WHERE Vehicleid =" + _vehicleid.ToString

            obj = cmd.ExecuteScalar

            If IsDBNull(obj) Then
                isVehicleQCed = False
            ElseIf CType(obj, Integer) = 22 Then
                isVehicleQCed = True
            ElseIf CType(obj, Integer) = 27 Then
                isVehicleQCed = False
            End If

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing


        End Function

        Private Function ForceQCCheck(ByVal _senderID As Integer) As Boolean


            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand
            con = New System.Data.SqlClient.SqlConnection

            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()

            cmd.Connection = con

            cmd.CommandType = CommandType.Text

            cmd.CommandText = "Select IndForceQCCheck FROM Sender WHERE senderid =" + _senderID.ToString

            obj = cmd.ExecuteScalar

            If IsDBNull(obj) Then obj = 0

            If CType(obj, Integer) = 1 Then
                ForceQCCheck = True
            ElseIf CType(obj, Integer) = 0 Then
                ForceQCCheck = False
            End If

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing


        End Function

        ''' <summary>
        ''' Clears all inputs on form.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub ClearInputs(ByVal isForSame As Boolean, ByVal clearPageImage As Boolean _
                                  , ByVal clearFamilyThumbnails As Boolean)

            If isForSame = False Then
                findVehicleIdTextBox.Clear()
                vehicleIdValueLabel.Text = String.Empty
                indexStatusTextLabel.Text = String.Empty
                qcStatusTextLabel.Text = String.Empty
        adDateTypeInDatePicker.Clear()
        DistDateTypeInDatePicker.Clear()
                mediaComboBox.SelectedValue = DBNull.Value
                marketComboBox.SelectedValue = DBNull.Value
                publicationComboBox.SelectedValue = DBNull.Value
            End If

            retailerComboBox.SelectedValue = DBNull.Value
            tradeclassValueLabel.Text = String.Empty
            priorityValueLabel.Text = String.Empty
            'languageComboBox.SelectedValue = DBNull.Value
            eventComboBox.SelectedValue = DBNull.Value
            themeComboBox.SelectedValue = DBNull.Value
            startDateTypeInDatePicker.Clear()
            endDateTypeInDatePicker.Clear()
            couponCheckBox.Checked = False
            flashAdCheckBox.Checked = False

            If clearPageImage Then
                currentPageLabel.Text = "0"
                totalPagesLabel.Text = "0"
                findImageTextBox.Clear()

            End If

        End Sub

        ''' <summary>
        ''' Checks whether all page image files, for vehicle, exist or not.
        ''' </summary>
        ''' <returns>Boolean</returns>
        ''' <remarks></remarks>
        Private Function ArePageImageFilesValid(ByVal vehicleId As Integer) As Boolean
            Dim matchCount, totalCount As Integer
            Dim vehicleImageFolderPath As String
            Dim imageFilePath As System.Text.StringBuilder
            Dim statusMsg As MCAP.UI.Controls.StatusMessageForm


            statusMsg = New MCAP.UI.Controls.StatusMessageForm()
            statusMsg.Text = "Checking page images..... Please wait."
            statusMsg.Show(Me)
            statusMsg.Refresh()

            imageFilePath = New System.Text.StringBuilder()
            vehicleImageFolderPath = Processor.GetPageImageFolderPath(vehicleId)
            totalCount = Processor.Data.Page.Count

            For i As Integer = 0 To totalCount - 1
                imageFilePath.Append(vehicleImageFolderPath)
                imageFilePath.Append("\")
                imageFilePath.Append(Processor.Data.Page(i).ImageName)
                imageFilePath.Append(".jpg")

                statusMsg.MessageText = String.Format("Processing image {0} of {1}.", i + 1, totalCount) : statusMsg.Refresh()

                If System.IO.File.Exists(imageFilePath.ToString()) Then
                    matchCount += 1
                    LoadImage(imageFilePath.ToString())
                End If

                imageFilePath.Remove(0, imageFilePath.Length)
            Next

            imageFilePath = Nothing

            statusMsg.Close()
            statusMsg.Dispose()
            statusMsg = Nothing

            Return (matchCount = totalCount)

        End Function

        Private Function LoadLocalFirstImages(ByVal RemoteLocation As String, ByVal LocalPath As String, ByVal imagename As String) As String

            Try
                LocalPath = LoadLocalFirstImage(RemoteLocation, LocalPath, imagename)
                Return LoadLocalImages(RemoteLocation, LocalPath, Processor.Data.Page)
            Catch ex As Exception
            End Try
        End Function

        Private Function LoadLocalImages(ByVal RemoteLocation As String, ByVal localPath As String, ByVal pageData As DataTable) As String

            Try

                localPath = LoadLocalImage(RemoteLocation, localPath, pageData)

                Return localPath
            Catch ex As Exception

            End Try
        End Function

        ''' <summary>
        ''' Displays image on form based on supplied image folder path and page number.
        ''' </summary>
        ''' <param name="imageFolderPath"></param>
        ''' <param name="pageNumber"></param>
        ''' <exception cref="System.ApplicationException">
        ''' When supplied page number is not found in received order column for vehicle id, raises exception
        ''' with message - "Page information not found."
        ''' </exception>
        ''' <remarks></remarks>
        Protected Overloads Sub ShowImage(ByVal imageFolderPath As String, ByVal pageNumber As Integer)
            Dim isSuccessful As Boolean
            Dim imageName As String
            Dim LocalFolder As String

            If pageNumber = 1 AndAlso mediaComboBox.Text.ToUpper = "SOCIAL" Then
                recaptureWebpageButton.Enabled = False
            End If
            

            imageName = Processor.GetPageImageName(pageNumber)
            If imageName Is Nothing Then
                Throw New System.ApplicationException("Page information not found.")
                Exit Sub
            End If

            Try
                isSuccessful = False

                REM: Test for remote User
                AllowCacheImage = CBool(Processor.IsAllowCacheImagesUser)
                isAllowCacheImage(AllowCacheImage)
                If AllowCacheImage = True Then
                    LocalFolder = Processor.LoadLocalImageFolder(CInt(vehicleIdValueLabel.Text))
                    LoadLocalFirstImages(imageFolderPath, LocalFolder, imageName)
                    'LocalImageFolderPath = LoadLocalImages(imageFolderPath, LocalFolder, Processor.Data.Page)

                End If

                ShowImage(imageFolderPath, imageName)
                isSuccessful = True
            Catch ex As ApplicationException
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                My.Application.Log.WriteException(ex)
            Catch ex As Exception
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                My.Application.Log.WriteException(ex)
            End Try

            ''If isSuccessful = False Then ''ClearImage()

            pageTypeValueLabel.Text = Processor.GetPageType(pageNumber)

            imageName = Nothing

        End Sub

        ''' <summary>
        ''' Displays image on form based on supplied vehicleId and page number.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="pageNumber"></param>
        ''' <exception cref="System.ApplicationException">
        ''' When supplied page number is not found in received order column for vehicle id, raises exception
        ''' with message - "Page information not found."
        ''' </exception>
        ''' <remarks></remarks>
        Protected Overloads Sub ShowImage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            Dim imageFolderPath, imageName As String


            If Me.FormState <> FormStateEnum.Remote Then
                imageFolderPath = Processor.GetPageImageFolderPath(vehicleId)
            Else
                imageFolderPath = Processor.GetPageImageFolderPath(vehicleId, True)
            End If

            imageName = Processor.GetPageImageName(pageNumber)
            If imageName Is Nothing Then
                Throw New System.ApplicationException("Page information not found.")
                Exit Sub
            End If

            Try
                ShowImage(imageFolderPath, imageName)
            Catch ex As ApplicationException
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                My.Application.Log.WriteException(ex)
            Catch ex As Exception
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                My.Application.Log.WriteException(ex)
            End Try

            pageTypeValueLabel.Text = Processor.GetPageType(vehicleId, pageNumber)

            imageName = Nothing

        End Sub


        Protected Overrides Sub ShowHideControls(ByVal formStatus As FormStateEnum)

            pagesLabel.Visible = Not Me.IsPageCropNavigation
            definePagesButton.Visible = Not Me.IsPageCropNavigation

            ' omar
            Select Case formStatus
                Case FormStateEnum.Insert, FormStateEnum.View ', FormStateEnum.ReQC
                    editButton.Visible = True
                    cancelButton.Visible = False
                Case FormStateEnum.Edit
                    cancelButton.Visible = True
                    editButton.Visible = False
            End Select

            recaptureWebpageButton.Visible = Me.IsMediaTypeWebsite
            'currentPageLabel.Visible = Me.IsPageCropNavigation
            'pageNameLabel.Visible = Not Me.IsPageCropNavigation

        End Sub

        ''' <summary>
        ''' Enables or disables controls on form based on supplied form state value.
        ''' </summary>
        ''' <param name="formStatus"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub EnableDisableControls(ByVal formStatus As FormStateEnum)
            Dim enableFlashCheckBox As Boolean


            If Me.IsPageCropNavigation Then
                enableFlashCheckBox = IsRetailerValidForPageCropFR()
            Else
                enableFlashCheckBox = IsValidFRRetailerMarket()
            End If

            Select Case formStatus
                Case FormStateEnum.Insert
                    flagForDetailEntryCheckBox.Enabled = True
                    parentVehicleIdTextBox.Enabled = True
          adDateTypeInDatePicker.Enabled = False
          DistDateTypeInDatePicker.Enabled = False
                    mediaComboBox.Enabled = False
                    marketComboBox.Enabled = False
                    publicationComboBox.Enabled = False
                    languageComboBox.Enabled = False  'On this screen, user can insert records for FSI - Pagecrop only.
                    retailerComboBox.Enabled = True
                    tradeclassValueLabel.Enabled = True
                    eventComboBox.Enabled = True
                    themeComboBox.Enabled = True
                    startDateTypeInDatePicker.Enabled = True
                    endDateTypeInDatePicker.Enabled = True
                    definePagesButton.Enabled = False 'On this screen, user can insert record for FSI - PageCrop only.
                    couponCheckBox.Enabled = True
                    flashAdCheckBox.Enabled = enableFlashCheckBox
                    nationalCheckBox.Enabled = False

                    sameButton.Enabled = True
                    newButton.Enabled = True
                    printButton.Enabled = False
                    deleteButton.Enabled = False
                    editButton.Enabled = False
                    addButton.Enabled = False
                    prvalButton.Enabled = True  'On this screen, user can insert record for FSI - PageCrop only.
                    resetButton.Enabled = True
                    saveButton.Enabled = False
                    qcCompletedButton.Enabled = False

                    notpromotionalButton.Visible = False

                    imageRotationGroupBox.Enabled = True
                    keepRectangleButton.Enabled = True
                    removeRectangleButton.Enabled = True
                    saveImageButton.Enabled = True
                    refreshButton.Enabled = False
                    deleteImageButton.Enabled = Not Me.IsPageCropNavigation
                    resequenceButton.Enabled = False
                    viewFamilyButton.Enabled = Not Me.IsPageCropNavigation
                    showQcData.Enabled = Not Me.IsPageCropNavigation
                    wrongVersionButton.Enabled = True
                Case FormStateEnum.Edit
                    flagForDetailEntryCheckBox.Enabled = True
                    parentVehicleIdTextBox.Enabled = Not flagForDetailEntryCheckBox.Checked
          adDateTypeInDatePicker.Enabled = True And (Not Me.IsPageCropNavigation)
          DistDateTypeInDatePicker.Enabled = True And (Not Me.IsPageCropNavigation)
                    mediaComboBox.Enabled = True And (Not Me.IsPageCropNavigation)
                    marketComboBox.Enabled = True And (Not Me.IsPageCropNavigation)
                    publicationComboBox.Enabled = True And (Not Me.IsPageCropNavigation)
                    languageComboBox.Enabled = True And (Not Me.IsPageCropNavigation)
                    retailerComboBox.Enabled = True
                    tradeclassValueLabel.Enabled = True
                    eventComboBox.Enabled = True
                    themeComboBox.Enabled = True
                    startDateTypeInDatePicker.Enabled = True
                    endDateTypeInDatePicker.Enabled = True
                    definePagesButton.Enabled = True
                    couponCheckBox.Enabled = True
                    flashAdCheckBox.Enabled = enableFlashCheckBox
                    nationalCheckBox.Enabled = flashAdCheckBox.Checked AndAlso (Me.IsPageCropNavigation = False)

                    sameButton.Enabled = False
                    newButton.Enabled = False
                    printButton.Enabled = False
                    deleteButton.Enabled = False
                    editButton.Enabled = False
                    addButton.Enabled = False
                    prvalButton.Enabled = False
                    resetButton.Enabled = False
                    saveButton.Enabled = True

                    If m_inReQC Then
                        If Processor.IsValidReqcUser() <> 1 Then
                            saveButton.Enabled = False
                        Else
                            saveButton.Enabled = True
                        End If

                    End If
                    qcCompletedButton.Enabled = False
                    If isVehicleQCed(CInt(Int(vehicleIdValueLabel.Text))) Then
                        wrongVersionButton.Enabled = False
                    Else
                        wrongVersionButton.Enabled = True
                    End If

                    imageRotationGroupBox.Enabled = True
                    keepRectangleButton.Enabled = True
                    removeRectangleButton.Enabled = True
                    saveImageButton.Enabled = True
                    refreshButton.Enabled = True
                    deleteImageButton.Enabled = Not Me.IsPageCropNavigation
                    resequenceButton.Enabled = True
                    viewFamilyButton.Enabled = Not Me.IsPageCropNavigation
                    showQcData.Enabled = Not Me.IsPageCropNavigation

                Case FormStateEnum.Remote
                    flagForDetailEntryCheckBox.Enabled = False
                    parentVehicleIdTextBox.Enabled = False
                    adDateTypeInDatePicker.Enabled = True
                    DistDateTypeInDatePicker.Enabled = True
                    mediaComboBox.Enabled = True
                    marketComboBox.Enabled = True
                    publicationComboBox.Enabled = True
                    languageComboBox.Enabled = True
                    retailerComboBox.Enabled = True
                    eventComboBox.Enabled = True
                    themeComboBox.Enabled = True
                    startDateTypeInDatePicker.Enabled = True
                    endDateTypeInDatePicker.Enabled = True
                    definePagesButton.Enabled = False
                    couponCheckBox.Enabled = Me.IsPageCropNavigation
                    flashAdCheckBox.Enabled = False
                    nationalCheckBox.Enabled = False
                    'notpromotionalButton.Visible = False


                    sameButton.Enabled = False
                    newButton.Enabled = False
                    printButton.Enabled = True
                    deleteButton.Enabled = True
                    'User can not edit while viewing record with media type Website, but user can create/edit/delete cropped pages.
                    editButton.Enabled = True And (Not (Me.IsMediaTypeWebsite AndAlso Me.IsPageCropNavigation = False))
                    If Me.IsMediaTypeWebsite Then
                        editButton.Enabled = True
                    End If
                    addButton.Enabled = (Me.IsFSI AndAlso (tradeclassValueLabel.Text.ToUpper() = "FSI" OrElse tradeclassValueLabel.Text.ToUpper() = "MAG"))
                    prvalButton.Enabled = False
                    resetButton.Enabled = False
                    saveButton.Enabled = False
                    If m_inReQC Then
                        qcCompletedButton.Enabled = Not Me.IsPageCropNavigation And m_OKtoReQC
                    Else
                        qcCompletedButton.Enabled = Not Me.IsPageCropNavigation
                    End If
                    vehiclePageCropButton.Enabled = Me.IsPageCropNavigation OrElse (Me.IsFSI AndAlso (tradeclassValueLabel.Text.ToUpper() = "FSI" OrElse tradeclassValueLabel.Text.ToUpper() = "MAG"))
                    imageRotationGroupBox.Enabled = True
                    keepRectangleButton.Enabled = True
                    removeRectangleButton.Enabled = True
                    saveImageButton.Enabled = True
                    refreshButton.Enabled = True
                    deleteImageButton.Enabled = True
                    resequenceButton.Enabled = True
                    viewFamilyButton.Enabled = True

                    keepRectangleButton.Enabled = False
                    removeRectangleButton.Enabled = False
                    DrawRectangleButton.Enabled = False
                    saveImageButton.Enabled = False
                    deleteImageButton.Enabled = False
                    resequenceButton.Enabled = False
                    refreshButton.Enabled = False
                    ViewThumbnails.Enabled = False
                    rotate90Button.Enabled = False
                    rotate180Button.Enabled = False
                    rotate270Button.Enabled = False
                    rotate90AllButton.Enabled = False
                    rotateLButton.Enabled = False
                    rotateRButton.Enabled = False
                    rotate180AllButton.Enabled = False
                    rotateByButton.Enabled = False
                    ImageDisplay.Enabled = False

                Case Else
                    flagForDetailEntryCheckBox.Enabled = False
                    parentVehicleIdTextBox.Enabled = False
                    adDateTypeInDatePicker.Enabled = True
                    DistDateTypeInDatePicker.Enabled = True
                    mediaComboBox.Enabled = True
                    marketComboBox.Enabled = True
                    publicationComboBox.Enabled = True
                    languageComboBox.Enabled = True
                    retailerComboBox.Enabled = True
                    eventComboBox.Enabled = True
                    themeComboBox.Enabled = True
                    startDateTypeInDatePicker.Enabled = True
                    endDateTypeInDatePicker.Enabled = True
                    definePagesButton.Enabled = False
                    couponCheckBox.Enabled = Me.IsPageCropNavigation
                    flashAdCheckBox.Enabled = False
                    nationalCheckBox.Enabled = False
                    'notpromotionalButton.Visible = False


                    sameButton.Enabled = False
                    newButton.Enabled = False
                    printButton.Enabled = True
                    deleteButton.Enabled = True
                    'User can not edit while viewing record with media type Website, but user can create/edit/delete cropped pages.
                    editButton.Enabled = True And (Not (Me.IsMediaTypeWebsite AndAlso Me.IsPageCropNavigation = False))
                    If Me.IsMediaTypeWebsite Then
                        editButton.Enabled = True
                    End If
                    addButton.Enabled = (Me.IsFSI AndAlso (tradeclassValueLabel.Text.ToUpper() = "FSI" OrElse tradeclassValueLabel.Text.ToUpper() = "MAG"))
                    prvalButton.Enabled = False
                    resetButton.Enabled = False
                    saveButton.Enabled = False
                    If IsSIMR = False Then
                        If m_inReQC Then
                            qcCompletedButton.Enabled = Not Me.IsPageCropNavigation And m_OKtoReQC
                        Else
                            qcCompletedButton.Enabled = Not Me.IsPageCropNavigation
                        End If
                    Else
                        qcButtonEnabledDisabled()
                    End If
                    vehiclePageCropButton.Enabled = Me.IsPageCropNavigation OrElse (Me.IsFSI AndAlso (tradeclassValueLabel.Text.ToUpper() = "FSI" OrElse tradeclassValueLabel.Text.ToUpper() = "MAG"))
                    imageRotationGroupBox.Enabled = True
                    keepRectangleButton.Enabled = True
                    removeRectangleButton.Enabled = True
                    saveImageButton.Enabled = True
                    refreshButton.Enabled = True
                    deleteImageButton.Enabled = True
                    resequenceButton.Enabled = True
                    viewFamilyButton.Enabled = True
            End Select

        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function IsValidFRRetailerMarket() As Boolean
            Dim isValidFlashRetMkt As Boolean
            Dim retailerId, marketId As Integer


            If marketComboBox.SelectedValue Is Nothing _
              OrElse Integer.TryParse(marketComboBox.SelectedValue.ToString(), marketId) = False _
            Then
                marketId = -1
            End If

            If retailerComboBox.SelectedValue Is Nothing Then
                retailerId = -1
            Else
                retailerId = CType(retailerComboBox.SelectedValue, Integer)
            End If

            isValidFlashRetMkt = Processor.IsValidFlashRetMkt(retailerId, marketId)

            Return isValidFlashRetMkt

        End Function

        ''' <summary>
        ''' Returns true if retailer is valid for cropped page flash ad.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function IsRetailerValidForPageCropFR() As Boolean
            Dim showFlashCheckbox As Boolean
            Dim retailerId As Integer

            If retailerComboBox.SelectedValue Is Nothing Then
                retailerId = 0
            ElseIf Integer.TryParse(retailerComboBox.SelectedValue.ToString(), retailerId) = False Then
                retailerId = 0
            End If

            showFlashCheckbox = Processor.IsRetailerValidForPageCropFR(retailerId)

            retailerId = Nothing

            Return showFlashCheckbox

        End Function

        ''' <summary>
        ''' Validates inputs as per business rules.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function ValidateBusinessRules() As Boolean
            Dim showMsg As Boolean
            Dim dateDifference As Integer
            Dim dateMsg As DateCheckDialog


            dateMsg = New DateCheckDialog()
            dateMsg.AllowIgnoreKey = Processor.IsUserSupervisorOrAdministrator(Processor.UserID)

            If adDateTypeInDatePicker.Value.HasValue = True _
                AndAlso startDateTypeInDatePicker.Value.HasValue = True _
            Then
                showMsg = False
                dateDifference = adDateTypeInDatePicker.Value.Value.Subtract(startDateTypeInDatePicker.Value.Value).Days

                If (dateDifference < -7 OrElse dateDifference > 7) _
                  AndAlso (mediaComboBox.Text.ToUpper() = "MAILER" OrElse mediaComboBox.Text.ToUpper() = "CATALOG") _
                Then
                    showMsg = True
                ElseIf (dateDifference < -14 OrElse dateDifference > 14) _
                  AndAlso (tradeclassValueLabel.Text.ToUpper() = "DEPT") _
                Then
                    showMsg = True
                ElseIf (dateDifference < -28 OrElse dateDifference > 28) Then
                    showMsg = True
                End If

                If showMsg Then
                    dateMsg.MessageText = "Sale Start Date is not close enough to Ad Date to permit entry." _
                                          + " Correct one of the dates, or if they are correct set aside for" _
                                          + " supervisor."
                    If dateMsg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        dateMsg.Dispose()
                        dateMsg = Nothing
                        Return False
                    End If
                End If
            End If

            showMsg = False

            If endDateTypeInDatePicker.Value.HasValue Then
                showMsg = False

                If adDateTypeInDatePicker.Value.HasValue Then
                    If adDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days < -40 Then _
                      showMsg = True
                End If
            End If

            If showMsg = False AndAlso startDateTypeInDatePicker.Value.HasValue _
                AndAlso endDateTypeInDatePicker.Value.HasValue _
            Then
                If startDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days < -40 Then _
                    showMsg = True
            End If

            If showMsg Then
                dateMsg.MessageText = "Sale End date is not close enough to Ad date or Start date to permit" _
                                      + " entry. Correct one or more dates, or if they are correct set aside" _
                                      + " for supervisor."
                If dateMsg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    dateMsg.Dispose()
                    dateMsg = Nothing
                    Return False
                End If
            End If

            showMsg = False

            dateMsg.Dispose()
            dateMsg = Nothing


            Return Not showMsg

        End Function

        ''' <summary>
        ''' Validates inputs and returns true if all inputs are valid, false otherwise.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function AreInputsValid() As Boolean
            Dim areAllValid As Boolean
            Dim tempDate As DateTime
            Dim Media As Integer = CType(mediaComboBox.SelectedValue, Integer)

            areAllValid = True

            If detailEntryOptionGroupBox.Enabled Then
                If flagForDetailEntryCheckBox.Checked = False AndAlso parentVehicleIdTextBox.Text.Trim().Length = 0 Then
                    areAllValid = False
                    SetErrorProvider(parentVehicleIdTextBox, "Parent Vehicle Id is required.")
                Else
                    RemoveErrorProvider(parentVehicleIdTextBox)
                End If
            End If

            If mediaComboBox.SelectedValue Is Nothing Then
                SetErrorProvider(mediaComboBox, "Provide media.")
                areAllValid = False
            Else
                RemoveErrorProvider(mediaComboBox)
            End If

            If marketComboBox.SelectedValue Is Nothing Then
                SetErrorProvider(marketComboBox, "Provide market.")
                areAllValid = False
            Else
                RemoveErrorProvider(marketComboBox)
            End If

            If publicationComboBox.SelectedValue Is Nothing Then
                SetErrorProvider(publicationComboBox, "Provide publication.")
                areAllValid = False
            Else
                RemoveErrorProvider(publicationComboBox)
            End If

            If adDateTypeInDatePicker.Value.HasValue = False Then
                SetErrorProvider(adDateTypeInDatePicker, "Provide Ad date.")
                areAllValid = False
            Else
                RemoveErrorProvider(adDateTypeInDatePicker)
      End If

      If DistDateTypeInDatePicker.Value.HasValue = False Then
        SetErrorProvider(DistDateTypeInDatePicker, "Provide Dist date.")
        areAllValid = False
      Else
        RemoveErrorProvider(DistDateTypeInDatePicker)
      End If

            If retailerComboBox.SelectedValue Is Nothing Then
                SetErrorProvider(retailerComboBox, "Provide retailer.")
                areAllValid = False
            Else
                RemoveErrorProvider(retailerComboBox)
            End If

            If languageComboBox.SelectedValue Is Nothing Then
                SetErrorProvider(languageComboBox, "Provide language.")
                areAllValid = False
            Else
                RemoveErrorProvider(languageComboBox)
            End If

            If eventComboBox.SelectedValue Is Nothing Then
                SetErrorProvider(eventComboBox, "Provide event.")
                areAllValid = False
            Else
                RemoveErrorProvider(eventComboBox)
            End If

            If themeComboBox.SelectedValue Is Nothing Then
                SetErrorProvider(themeComboBox, "Provide theme.")
                areAllValid = False
            Else
                RemoveErrorProvider(themeComboBox)
            End If

            If Media = 9 OrElse Media = 12 OrElse Media = 16 Then
                RemoveErrorProvider(startDateTypeInDatePicker)
            Else

                If startDateTypeInDatePicker.Text = "  /  /" _
                  OrElse DateTime.TryParse(startDateTypeInDatePicker.Text, tempDate) = False _
                Then
                    SetErrorProvider(startDateTypeInDatePicker, "Provide valid start date.")
                    areAllValid = False
                Else
                    RemoveErrorProvider(startDateTypeInDatePicker)
                End If
            End If

            If endDateTypeInDatePicker.Text <> "  /  /" _
              AndAlso DateTime.TryParse(endDateTypeInDatePicker.Text, tempDate) = False _
            Then
                SetErrorProvider(endDateTypeInDatePicker, "Provide valid end date.")
                areAllValid = False
            ElseIf endDateTypeInDatePicker.Value.HasValue = False Then
                RemoveErrorProvider(endDateTypeInDatePicker)
            ElseIf adDateTypeInDatePicker.Value.HasValue _
              AndAlso adDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days > 0 _
            Then
                MessageBox.Show("End Date cannot be before Ad Date.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                areAllValid = False
            ElseIf startDateTypeInDatePicker.Value.HasValue _
              AndAlso startDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days > 0 _
            Then
                MessageBox.Show("End Date cannot be before Start Date.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                areAllValid = False
            ElseIf (adDateTypeInDatePicker.Value.HasValue _
                    AndAlso adDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days < -35) _
              OrElse (startDateTypeInDatePicker.Value.HasValue _
                    AndAlso startDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days < -30) _
            Then
                Dim userResponse As DialogResult
                userResponse = MessageBox.Show("Sale End Date is unusual compared to Sale Start Date or Ad Date." _
                                               + " Check all values. Is the Sale End Date correct?", ProductName _
                                               , MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If userResponse = Windows.Forms.DialogResult.No Then areAllValid = False
            End If


            If areAllValid Then areAllValid = ValidateBusinessRules()

            Return areAllValid

        End Function

        Private Function HasMarketAssoc(ByVal _sender As Integer, ByVal _mktid As Integer) As Boolean
            Dim ReturnVal As Boolean
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "select * from SenderMktAssoc where endDT is null and SenderId=" + _sender.ToString + " and MktId=" + _mktid.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With

                If obj IsNot Nothing Then
                    ReturnVal = True
                Else
                    ReturnVal = False
                End If

            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return ReturnVal
        End Function

        ''' <summary>
        ''' Removes error providers from all input controls.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub RemoveAllErrorProviders()
      RemoveErrorProvider(adDateTypeInDatePicker)
      RemoveErrorProvider(DistDateTypeInDatePicker)
            RemoveErrorProvider(mediaComboBox)
            RemoveErrorProvider(marketComboBox)
            RemoveErrorProvider(publicationComboBox)
            RemoveErrorProvider(languageComboBox)
            RemoveErrorProvider(retailerComboBox)
            RemoveErrorProvider(tradeclassValueLabel)
            RemoveErrorProvider(eventComboBox)
            RemoveErrorProvider(themeComboBox)
            RemoveErrorProvider(startDateTypeInDatePicker)
            RemoveErrorProvider(endDateTypeInDatePicker)
        End Sub

        'Private Sub SaveImage(ByVal img As Image, ByVal FName As String)
        '    Try
        '        Dim FileToSave As Bitmap = New Bitmap(img)
        '        Dim ImgC As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
        '        Dim MyEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
        '        Dim myEncoderParameters As New EncoderParameters(1)
        '        Dim myEncoderParameter As EncoderParameter = New EncoderParameter(MyEncoder, 97L)

        '        myEncoderParameters.Param(0) = myEncoderParameter
        '        FileToSave.Save(FName, ImgC, myEncoderParameters)
        '        FileToSave.Dispose()
        '    Catch ex As Exception
        '        MsgBox(Err.Description)
        '    End Try
        'End Sub
        Private Sub SaveImage(ByVal img As Image, ByVal FName As String)
            Try
                If lblisRotatedBy.Text = "false" Then
                    Dim FileToSave As Bitmap = New Bitmap(img)
                    Dim ImgC As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
                    Dim MyEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
                    Dim myEncoderParameters As New EncoderParameters(1)
                    Dim myEncoderParameter As EncoderParameter = New EncoderParameter(MyEncoder, 92L)

                    myEncoderParameters.Param(0) = myEncoderParameter
                    FileToSave.Save(FName, ImgC, myEncoderParameters)
                    FileToSave.Dispose()
                Else
                    img.Save(FName)
                    lblisRotatedBy.Text = "false"
                End If
            Catch ex As Exception
                MsgBox(Err.Description)
            End Try
        End Sub

        Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo

            Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()

            Dim codec As ImageCodecInfo
            For Each codec In codecs
                If codec.FormatID = format.Guid Then
                    Return codec
                End If
            Next codec
            Return Nothing

        End Function

        Protected Overrides Function IsPageHasSizeAssigned(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As Boolean
            Dim isSizeAssigned As Boolean
            Dim pages As System.Data.EnumerableRowCollection(Of QCDataSet.PageRow)


            pages = From row In Processor.Data.Page _
                    Where row.VehicleId = vehicleId And row.ReceivedOrder = pageNumber _
                    Select row

            isSizeAssigned = Not (pages.Count = 0 OrElse pages(0).IsSizeIDNull())

            pages = Nothing

            Return isSizeAssigned

        End Function

        Protected Overrides Function GetPageImageSize(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As System.Drawing.SizeF

            Return Processor.GetPageSize(vehicleId, pageNumber)

        End Function

        Protected Overrides Function GetPageImageSize(ByVal pageId As Integer) As System.Drawing.SizeF

            Return Processor.GetPageSize(pageId)

        End Function

        ''' <summary>
        ''' Gets size information based on supplied size Id.
        ''' </summary>
        ''' <param name="pageCropId"></param>
        ''' <param name="recroppedRectangle"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Overrides Function CalculateReCroppedImageSize(ByVal pageCropId As Integer, ByVal recroppedRectangle As System.Drawing.RectangleF) As System.Drawing.SizeF
            Dim sizeId As Integer
            Dim linqQuery As System.Collections.Generic.IEnumerable(Of QCDataSet.PageCropRow)
            Dim croppedAdSize, recroppedAdSize As System.Drawing.SizeF
            Dim croppedRectangle As System.Drawing.RectangleF


            linqQuery = From p In Processor.Data.PageCrop.Rows.Cast(Of QCDataSet.PageCropRow)() _
                        Select p _
                        Where p.PageCropId = pageCropId

            If linqQuery.Count = 0 Then
                Throw New System.ApplicationException("Unable to find cropped page information.")
            ElseIf linqQuery(0).IsSizeIDNull() Then
                sizeId = linqQuery(0).SizeID
            End If

            croppedRectangle.Location = New System.Drawing.PointF(linqQuery(0).X, linqQuery(0).Y)
            croppedRectangle.Size = New System.Drawing.SizeF(linqQuery(0).X2 - linqQuery(0).X, linqQuery(0).Y2 - linqQuery(0).Y)
            croppedAdSize = Processor.GetSize(sizeId)

            If croppedAdSize = System.Drawing.SizeF.Empty Then
                Throw New System.ApplicationException("Cannot get size of the cropped image.")
            End If

            recroppedAdSize.Width = recroppedAdSize.Width * croppedAdSize.Width / croppedRectangle.Width
            recroppedAdSize.Height = recroppedAdSize.Height * croppedAdSize.Height / croppedRectangle.Height

            ' catch recrop count increases here


            Return recroppedAdSize

        End Function

        ''' <summary>
        ''' Inserts a row into PageCrop table. Returns PageCropId once record is successfully inserted into PageCrop table.
        ''' </summary>
        ''' <param name="tempRow">PageCrop datarow to be updated based on information specified on screen.</param>
        ''' <param name="pageId">Id of the Page from which the image has been cropped.</param>
        ''' <param name="adSizeId">SizeId for the cropped image size.</param>
        ''' <param name="adSizeRectangle">Cropped image rectangle. Values are in pixels.</param>
        ''' <remarks></remarks>
        Private Sub SetNewPageCropDataRow(ByVal tempRow As QCDataSet.PageCropRow, ByVal pageId As Integer, ByVal croppedImageName As String, ByVal adSizeId As Integer, ByVal adSizeRectangle As System.Drawing.RectangleF)

            tempRow.BeginEdit()

            tempRow.PageID = pageId
            tempRow.RetId = CType(retailerComboBox.SelectedValue, Integer)
            tempRow.ThemeID = CType(themeComboBox.SelectedValue, Integer)
            tempRow.EventID = CType(eventComboBox.SelectedValue, Integer)
            If startDateTypeInDatePicker.Text = "  /  /" Then
                tempRow.SetStartDtNull()
            Else
                tempRow.StartDt = CType(startDateTypeInDatePicker.Text, DateTime)
            End If
            If endDateTypeInDatePicker.Text = "  /  /" Then
                tempRow.SetEndDtNull()
            Else
                tempRow.EndDt = CType(endDateTypeInDatePicker.Text, DateTime)
            End If
            If couponCheckBox.Checked Then
                tempRow.CouponInd = 1
            Else
                tempRow.CouponInd = 0
            End If
            tempRow.CropImageName = croppedImageName
            tempRow.SizeID = adSizeId
            tempRow.X = CType(adSizeRectangle.Left, Integer)
            tempRow.Y = CType(adSizeRectangle.Top, Integer)
            tempRow.X2 = CType(adSizeRectangle.Left + adSizeRectangle.Width, Integer) 'X2 = X + Width
            tempRow.Y2 = CType(adSizeRectangle.Top + adSizeRectangle.Height, Integer) 'Y2 = Y + Height
            tempRow.FormName = FORM_NAME

            tempRow.EndEdit()

        End Sub

        ''' <summary>
        ''' Updates supplied PageCrop datarow based on specified inputs on screen.
        ''' </summary>
        ''' <param name="tempRow">PageCrop datarow to be updated based on information specified on screen.</param>
        ''' <param name="adSizeId">SizeId for the cropped image size.</param>
        ''' <param name="adSizeRectangle">Cropped image rectangle. Values are in pixels.</param>
        ''' <remarks></remarks>
        Private Sub UpdatePageCropDataRow(ByVal tempRow As QCDataSet.PageCropRow, ByVal adSizeId As Integer, ByVal adSizeRectangle As System.Drawing.RectangleF)
            Dim difference As Integer


            tempRow.BeginEdit()

            tempRow.RetId = CType(retailerComboBox.SelectedValue, Integer)
            tempRow.ThemeID = CType(themeComboBox.SelectedValue, Integer)
            tempRow.EventID = CType(eventComboBox.SelectedValue, Integer)
            If startDateTypeInDatePicker.Text = "  /  /" Then
                tempRow.SetStartDtNull()
            Else
                tempRow.StartDt = CType(startDateTypeInDatePicker.Text, DateTime)
            End If
            If endDateTypeInDatePicker.Text = "  /  /" Then
                tempRow.SetEndDtNull()
            Else
                tempRow.EndDt = CType(endDateTypeInDatePicker.Text, DateTime)
            End If
            If couponCheckBox.Checked Then
                tempRow.CouponInd = 1
            Else
                tempRow.CouponInd = 0
            End If

            If adSizeId > 0 Then tempRow.SizeID = adSizeId

            If adSizeRectangle <> System.Drawing.RectangleF.Empty Then
                'Reset cropped image co-ordinates. 
                difference = CType(adSizeRectangle.Left, Integer) - tempRow.X
                tempRow.X += difference
                difference = CType(adSizeRectangle.Top, Integer) - tempRow.Y
                tempRow.Y += difference
                difference = tempRow.X2 - CType(adSizeRectangle.Left + adSizeRectangle.Width, Integer)
                tempRow.X2 -= difference 'X2 = oldX2 - (oldX2 - newX2)
                difference = tempRow.Y2 - CType(adSizeRectangle.Top + adSizeRectangle.Height, Integer)
                tempRow.Y2 -= difference 'Y2 = oldY2 - (oldY2 - newY2)
            End If

            tempRow.FormName = FORM_NAME

            If flashAdCheckBox.Checked Then
                tempRow.FlashInd = 1
            Else
                tempRow.FlashInd = 0
            End If

            tempRow.EndEdit()

        End Sub

        ''' <summary>
        ''' Sets column values into vehicle row.
        ''' </summary>
        ''' <param name="vehicleRow"></param>
        ''' <remarks></remarks>
        ''' omar
        ''' Main collections from page area
        Private Sub SetVehicleRowValues(ByVal vehicleRow As QCDataSet.vwCircularRow, ByVal dupcheckResponse As UI.DuplicateCheckUserResponse)

            vehicleRow.BeginEdit()

            If flagForDetailEntryCheckBox.Checked Then
                vehicleRow.EntryInd = 1
            Else
                vehicleRow.SetEntryIndNull()
            End If

            If parentVehicleIdTextBox.Text.Trim().Length = 0 Then
                vehicleRow.SetParentVehicleIdNull()
            Else
                vehicleRow.ParentVehicleId = CType(parentVehicleIdTextBox.Text, Integer)
            End If

            If IsPageCropNavigation = False And mediaComboBox.Text.ToUpper() <> "FSI" Then
                vehicleRow.MediaId = CType(mediaComboBox.SelectedValue, Integer)
                vehicleRow.MktId = CType(marketComboBox.SelectedValue, Integer)
                vehicleRow.PublicationId = CType(publicationComboBox.SelectedValue, Integer)
                vehicleRow.BreakDt = adDateTypeInDatePicker.Value.Value
                vehicleRow.DistDt = DistDateTypeInDatePicker.Value.Value
            End If

            vehicleRow.RetId = CType(retailerComboBox.SelectedValue, Integer)
            vehicleRow.LanguageId = CType(languageComboBox.SelectedValue, Integer)
            vehicleRow.EventId = CType(eventComboBox.SelectedValue, Integer)
            vehicleRow.ThemeId = CType(themeComboBox.SelectedValue, Integer)
            vehicleRow.Subject = CType(txtSubject.Text, String)

            If startDateTypeInDatePicker.Value.HasValue Then
                vehicleRow.StartDt = CType(startDateTypeInDatePicker.Text, DateTime)
            Else
                vehicleRow.SetStartDtNull()
            End If

            If endDateTypeInDatePicker.Value.HasValue Then
                vehicleRow.EndDt = CType(endDateTypeInDatePicker.Text, DateTime)
            Else
                vehicleRow.SetEndDtNull()
            End If

            If couponCheckBox.Checked Then
                vehicleRow.CouponInd = 1
            Else
                vehicleRow.CouponInd = 0
            End If

            If flashAdCheckBox.Checked Then
                vehicleRow.FlashInd = 1
            Else
                vehicleRow.FlashInd = 0
            End If

            If nationalCheckBox.Checked Then
                vehicleRow.NationalInd = 1
            Else
                vehicleRow.NationalInd = 0
            End If

            If dupcheckResponse = DuplicateCheckUserResponse.Review Then
                Processor.SetVehicleStatusAsReviewed(vehicleRow)
            ElseIf dupcheckResponse = DuplicateCheckUserResponse.Duplicate Then
                Processor.SetVehicleStatusAsDuplicate(vehicleRow)
                'ElseIf dupcheckResponse = DuplicateCheckUserResponse.NoPossibleDuplidates _
                '  OrElse dupcheckResponse = DuplicateCheckUserResponse.Override _
                'Then
                '  Processor.SetVehicleStatusAsIndexed(vehicleRow)
            End If

            vehicleRow.Subject = CType(txtSubject.Text, String)

            vehicleRow.FormName = FORM_NAME
            vehicleRow.EndEdit()

        End Sub

        ''' <summary>
        ''' Displays supplied rows information in corresponding inputs.
        ''' </summary>
        ''' <param name="tempPageCropRow"></param>
        ''' <remarks></remarks>
        Private Sub ShowVehicleInformation(ByVal tempPageCropRow As QCDataSet.PageCropRow)

            vehicleIdValueLabel.Text = tempPageCropRow.PageRow.VehicleId.ToString()
            'Use tempPageRow information to load cropped images.


            pageCropIdLabel.Text = tempPageCropRow.PageCropId.ToString()
            pageIdLabel.Text = tempPageCropRow.PageID.ToString()

            If tempPageCropRow.IsRetIdNull() Then
                retailerComboBox.SelectedValue = DBNull.Value
            Else
                retailerComboBox.SelectedValue = tempPageCropRow.RetId
                tradeclassValueLabel.Text = tempPageCropRow.RetRow.TradeClassRow.Descrip
            End If

            If tempPageCropRow.IsEventIDNull() Then
                eventComboBox.SelectedValue = DBNull.Value
            Else
                eventComboBox.SelectedValue = tempPageCropRow.EventID
            End If

            If tempPageCropRow.IsThemeIDNull() Then
                themeComboBox.SelectedValue = DBNull.Value
            Else
                themeComboBox.SelectedValue = tempPageCropRow.ThemeID
            End If

            If tempPageCropRow.IsStartDtNull() Then
                startDateTypeInDatePicker.Clear()
            Else
                startDateTypeInDatePicker.Text = tempPageCropRow.StartDt.ToString("MM/dd/yy")
            End If

            If tempPageCropRow.IsEndDtNull() Then
                endDateTypeInDatePicker.Clear()
            Else
                endDateTypeInDatePicker.Text = tempPageCropRow.EndDt.ToString("MM/dd/yy")
            End If

            If tempPageCropRow.IsCouponIndNull() OrElse tempPageCropRow.CouponInd = 0 Then
                couponCheckBox.Checked = False
            Else
                couponCheckBox.Checked = True
            End If

            If tempPageCropRow.IsFlashIndNull() OrElse tempPageCropRow.FlashInd = 0 Then
                flashAdCheckBox.Checked = False
            Else
                flashAdCheckBox.Checked = True
            End If




        End Sub

        ''' <summary>
        ''' Displays supplied row information in corresponding inputs.
        ''' </summary>
        ''' <param name="vehicleRow"></param>
        ''' <remarks></remarks>
        Private Sub ShowVehicleInformation(ByVal vehicleRow As QCDataSet.vwCircularRow)

            vehicleIdValueLabel.Text = vehicleRow.VehicleId.ToString()
            indexStatusTextLabel.Text = Processor.GetIndexStatusText(vehicleRow.VehicleId)
            qcStatusTextLabel.Text = Processor.GetQCStatusText(vehicleRow.VehicleId)

            If vehicleRow.IsQCDtNull() = False AndAlso vehicleRow.IsQCedByIdNull() = False Then
                Dim userName As String = Processor.GetUserFullName(vehicleRow.QCedById)

                If userName Is Nothing Then userName = String.Empty
                MessageBox.Show("This Vehicle was QCed By " + userName + " on " _
                                + vehicleRow.QCDt.ToString("MM/dd/yyyy") + "." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                userName = Nothing
                wrongVersionButton.Enabled = False
            End If

            If vehicleRow.IsCircularIdNull() Then
                CircularIdLabel.Text = ""
            Else
                CircularIdLabel.Text = vehicleRow.CircularId.ToString()
            End If

            ' Modified to allow Subject, Sent By and Sent From
            If vehicleRow.IsSentFromNull() Then
                lblSentFrom.Text = ""
            Else
                If vehicleRow.MediaId = 12 Then
                    lblSentFrom.Text = vehicleRow.SentFrom
                Else
                    lblSentFrom.Text = vehicleRow.SentFrom + " " + Processor.SentFromDetails(vehicleRow.SentFrom)
                End If
            End If
            If vehicleRow.IsSentByNull() Then
                lblSentBy.Text = ""
            Else
                lblSentBy.Text = vehicleRow.SentBy
            End If
            If vehicleRow.IsSubjectNull() Then
                txtSubject.Text = ""
            Else
                txtSubject.Text = vehicleRow.Subject
            End If

            If (txtSubject.Text <> "") And Not filterHelp Is Nothing Then
                If filterHelp.Visible Then
                    SubjectButton_Click(Nothing, Nothing)
                End If
            End If

            '''''''''''''''''''''''''''''''''''''''''''

            If vehicleRow.IsMediaIdNull() Then
                mediaComboBox.SelectedValue = DBNull.Value
            Else
                mediaComboBox.SelectedValue = vehicleRow.MediaId
            End If

            marketComboBox.SelectedValue = DBNull.Value 'Required to load publications & retailers.
            If vehicleRow.IsMktIdNull() Then
                marketComboBox.SelectedValue = DBNull.Value
            Else
                marketComboBox.SelectedValue = vehicleRow.MktId
                If isAssociated = False AndAlso marketComboBox.Text IsNot "" Then MessageBox.Show("Sender '" + GetSenderName(vehicleRow.VehicleId) + "' is not associated with market '" + GetMarketName(vehicleRow.MktId) + "', however you are able to continue.", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            If Me.IsNAPublicationsOnly Then
                Processor.LoadNAPublicationForQC()
            Else
                Processor.LoadPublication(vehicleRow.MktId, vehicleRow.RetId)
            End If
            If vehicleRow.IsPublicationIdNull() Then
                publicationComboBox.SelectedValue = DBNull.Value
            Else
                publicationComboBox.SelectedValue = vehicleRow.PublicationId
            End If

            If vehicleRow.IsBreakDtNull() Then
                adDateTypeInDatePicker.Clear()
            Else
                adDateTypeInDatePicker.Text = vehicleRow.BreakDt.ToString("MM/dd/yy")
            End If

            If vehicleRow.IsDistDtNull() Then
                DistDateTypeInDatePicker.Clear()
            Else
                DistDateTypeInDatePicker.Text = vehicleRow.DistDt.ToString("MM/dd/yy")
            End If

            If vehicleRow.IsRetIdNull() Then
                retailerComboBox.SelectedValue = DBNull.Value
                detailEntryOptionGroupBox.Enabled = False
            Else
                retailerComboBox.SelectedValue = vehicleRow.RetId
                If vehicleRow.RetRow IsNot Nothing Then _
                    tradeclassValueLabel.Text = vehicleRow.RetRow.TradeClassRow.Descrip
                If Me.Processor.IsTradeclassMarkedForLimitedEntry(vehicleRow.RetId) Then
                    detailEntryOptionGroupBox.Enabled = True
                End If
            End If

            'Keep this blocks after retailer is set in retailer combobox.
            If vehicleRow.IsEntryIndNull() OrElse vehicleRow.EntryInd = 0 Then
                flagForDetailEntryCheckBox.Checked = False
            Else
                flagForDetailEntryCheckBox.Checked = True
            End If

            If vehicleRow.IsParentVehicleIdNull() Then
                parentVehicleIdTextBox.Clear()
            Else
                parentVehicleIdTextBox.Text = vehicleRow.ParentVehicleId.ToString()
            End If

            If vehicleRow.IsLanguageIdNull() Then
                languageComboBox.SelectedValue = DBNull.Value
            Else
                languageComboBox.SelectedValue = vehicleRow.LanguageId
            End If

            If vehicleRow.IsEventIdNull() Then
                eventComboBox.SelectedValue = DBNull.Value
            Else
                eventComboBox.SelectedValue = vehicleRow.EventId
            End If

            If vehicleRow.IsThemeIdNull() Then
                themeComboBox.SelectedValue = DBNull.Value
            Else
                themeComboBox.SelectedValue = vehicleRow.ThemeId
            End If

            If vehicleRow.IsStartDtNull() Then
                startDateTypeInDatePicker.Clear()
            Else
                startDateTypeInDatePicker.Text = vehicleRow.StartDt.ToString("MM/dd/yy")
            End If

            If vehicleRow.IsEndDtNull() Then
                endDateTypeInDatePicker.Clear()
            Else
                endDateTypeInDatePicker.Text = vehicleRow.EndDt.ToString("MM/dd/yy")
            End If

            If vehicleRow.IsActualPageCountNull() Then
                definePagesButton.Text = "Define Pages"
            Else
                definePagesButton.Text = "Define Pages (" + vehicleRow.ActualPageCount.ToString() + ")"
            End If

            If vehicleRow.IsCouponIndNull() OrElse vehicleRow.CouponInd = 0 Then
                couponCheckBox.Checked = False
            Else
                couponCheckBox.Checked = True
            End If

            If vehicleRow.IsFlashIndNull() OrElse vehicleRow.FlashInd = 0 Then
                flashAdCheckBox.Checked = False
            Else
                flashAdCheckBox.Checked = True
            End If

            If vehicleRow.IsNationalIndNull() OrElse vehicleRow.NationalInd = 0 Then
                nationalCheckBox.Checked = False
            Else
                nationalCheckBox.Checked = True
            End If

            If vehicleRow.IsCommentsNull() Then
                CommentsTextBox.Text = Processor.GetVehicleCommentsText(vehicleRow.VehicleId)
            End If

        End Sub
        Private Function GetMarketName(ByVal _mktid As Integer) As String
            Dim ReturnVal As String
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "select Descrip from Mkt where MktId=" + _mktid.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With

                If obj IsNot Nothing Then
                    ReturnVal = CType(obj, String)
                Else
                    ReturnVal = "Anonymous"
                End If

            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return ReturnVal
        End Function

        Private Function GetSenderName(ByVal _vehicleid As Integer) As String
            Dim ReturnVal As String
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "select a.Name from [sender] as a inner join Envelope as b " + _
                                    "ON a.SenderId = b.SenderId where b.EnvelopeId =(select EnvelopeId from Vehicle where VehicleId = " + _vehicleid.ToString + ")"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With

                If obj IsNot Nothing Then
                    ReturnVal = CType(obj, String)
                Else
                    ReturnVal = "Anonymous"
                End If

            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return ReturnVal
        End Function
        ''' <summary>
        ''' Returns page name based on supplied vehicleid and page number. Returns Nothing, if page 
        ''' information not found in Page data table.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="pageNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetPageName(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As String
            Dim pageName As String
            Dim pages As System.Data.EnumerableRowCollection(Of QCDataSet.PageRow)


            pages = From p In Processor.Data.Page _
                    Where p.VehicleId = vehicleId AndAlso p.ReceivedOrder = pageNumber _
                    Select p

            If pages.Count() < 1 Then Return Nothing

            pageName = pages(0).PageName

            pages = Nothing

            Return pageName

        End Function

        ''' <summary>
        ''' Returns page image size, in inches, based on supplied vehicleid and page number.
        ''' Returns Nothing, if page information not found in Page data table.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="pageNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetPageSizeText(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As String
            Dim pageSizeText As String
            Dim pages As System.Data.EnumerableRowCollection(Of QCDataSet.PageRow)


            pages = From p In Processor.Data.Page _
                    Where p.VehicleId = vehicleId AndAlso p.ReceivedOrder = pageNumber _
                          AndAlso p.IsSizeIDNull() = False _
                    Select p

            If pages.Count() < 1 OrElse pages(0).SizeRow Is Nothing Then Return Nothing

            pageSizeText = pages(0).SizeRow.Width.ToString("00.00") _
                            + " X " + pages(0).SizeRow.Height.ToString("00.00")

            pages = Nothing

            Return pageSizeText

        End Function

        Private Function GetPageStartEndDt(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As DataSet


            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim adpt As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet

            cmd = New System.Data.SqlClient.SqlCommand
            con = New System.Data.SqlClient.SqlConnection

            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()

            cmd.Connection = con

            cmd.CommandType = CommandType.Text

            cmd.CommandText = "select PageStartDt, PageEndDt from Page where VehicleId=" + vehicleId.ToString + " and ReceivedOrder=" + pageNumber.ToString

            adpt = New System.Data.SqlClient.SqlDataAdapter(cmd)

            adpt.Fill(ds)

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return ds
        End Function

        Private Function ShowFamilyCreationScreen(ByVal tempVehicleRow As QCDataSet.vwCircularRow) As Integer
            Dim familyId As Integer
            Dim userResponse As DialogResult
            Dim checkFamily As FamilyCreationForm


            '
            'While editing vehicle, if retailer is not changed then family creation screen should not to be displayed.
            '
            If Me.FormState = FormStateEnum.Edit AndAlso tempVehicleRow.HasVersion(DataRowVersion.Original) Then
                If tempVehicleRow("RetId", DataRowVersion.Original) Is tempVehicleRow("RetId", DataRowVersion.Current) Then
                    Return -1
                End If
            End If

            checkFamily = New FamilyCreationForm(tempVehicleRow.BreakDt, tempVehicleRow.MediaId _
                                                 , tempVehicleRow.RetId, 0, 3)
            checkFamily.Init(FormStateEnum.View)
            checkFamily.ApplyUserCredentials()

            checkFamily.addateValueLabel.Text = tempVehicleRow.BreakDt.ToString("MM/dd/yy")
            checkFamily.retailerNameLabel.Text = tempVehicleRow.RetRow.Descrip
            checkFamily.marketNameLabel.Text = tempVehicleRow.MktRow.Descrip
            'checkFamily.pagesValueLabel.Text = tempVehicleRow.CheckInPageCount.ToString()
            checkFamily.pagesValueLabel.Text = ""
            If tempVehicleRow.IsEventIdNull() Then
                checkFamily.eventNameLabel.Text = String.Empty
            Else
                checkFamily.eventNameLabel.Text = tempVehicleRow.EventRow.Descrip
            End If
            If tempVehicleRow.IsThemeIdNull() Then
                checkFamily.themeNameLabel.Text = String.Empty
            Else
                checkFamily.themeNameLabel.Text = tempVehicleRow.ThemeRow.Descrip
            End If
            If tempVehicleRow.IsStartDtNull() Then
                checkFamily.startDateValueLabel.Text = String.Empty
            Else
                checkFamily.startDateValueLabel.Text = startDateTypeInDatePicker.Text
            End If
            If tempVehicleRow.IsEndDtNull() Then
                checkFamily.endDateValueLabel.Text = String.Empty
            Else
                checkFamily.endDateValueLabel.Text = endDateTypeInDatePicker.Text
            End If

            checkFamily.Show()
            checkFamily.Hide()
            checkFamily.LoadPotentialFamilies()
            userResponse = checkFamily.ShowDialog(Me)
            If userResponse = Windows.Forms.DialogResult.OK AndAlso checkFamily.FamilyId > 0 Then
                familyId = checkFamily.FamilyId

                If checkFamily.IsNewFamily = False Then 'checkFamily.joinFamilyRadioButton.Checked
                    Dim tempRow As FamilyDataSet.DisplayFamilyInformationRow


                    tempRow = checkFamily.CurrentRow
                    tempVehicleRow.EventId = tempRow.EventId
                    eventComboBox.SelectedValue = tempRow.EventId
                    tempVehicleRow.ThemeId = tempRow.ThemeId
                    themeComboBox.SelectedValue = tempRow.ThemeId
                    If Not tempRow.IsStartDtNull Then
                        tempVehicleRow.StartDt = tempRow.StartDt
                        startDateTypeInDatePicker.Value = tempRow.StartDt
                    End If
                    If Not tempRow.IsEndDtNull Then
                        tempVehicleRow.EndDt = tempRow.EndDt
                        endDateTypeInDatePicker.Value = tempRow.EndDt
                    End If
                    tempVehicleRow.LanguageId = tempRow.LanguageId
                    languageComboBox.SelectedValue = tempRow.LanguageId
                    Processor.CopyPageInformation(tempRow.VehicleId, tempVehicleRow.VehicleId, FORM_NAME)
                End If

            Else
                familyId = -1
            End If

            checkFamily.Dispose()
            checkFamily = Nothing

            Return familyId

        End Function

#Region "Load thumbnail images in the Datagrid"
        Private Sub LoadThumbnailImages(ByVal _file As String, ByVal tooltip As String)
            Dim _numberPreviewImages As Integer = 100
            Dim _imageSize As Integer = 50
            Dim image As Image

            Dim numColumnsForWidth As Integer = (dgThumbnails.Width - 50) \ (_imageSize + 100)


            Dim numImagesRequired As Integer = 0
            Try

                'add image in the datagrid
                If System.IO.File.Exists(_file) = True Then
                    Image = Image.FromFile(_file)
                Else
                    Image = My.Resources.NoThumbnail
                End If

                Dim newImage As Image = Image.GetThumbnailImage(100, 200, Nothing, IntPtr.Zero)


                dgThumbnails.Rows(rowIndex).Cells(0).Value = newImage
                dgThumbnails.Rows(rowIndex).Cells(0).ToolTipText = tooltip ''GetFileName(_file(index))

                rowIndex += 1

            Catch ex As Exception
                MsgBox(Err.Description)
                Console.WriteLine(ex)
            End Try
        End Sub
#End Region
        ''' <summary>
        ''' Loads thumbnail images of recent 6 vehicles haivng same family as the vehicle being qced.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ShowFamilyThumbnails()
            Dim imageFolderPath As String
            Dim imageFilePath, tooltipStringBuilder As System.Text.StringBuilder
            Dim thumbnailRow As QCDataSet.FamilyThumbnailRow
            Dim dataGridViewColumn As New DataGridViewImageColumn()


            '' familyAxLEADImgList.Clear()  \\ Comment By Denver : 159
            dgThumbnails.Rows.Clear()
            If Processor.Data.FamilyThumbnail.Count = 0 Then Exit Sub

            ' add column
            dgThumbnails.Columns.Add(DataGridViewColumn)
            dgThumbnails.Columns(0).Width = dgThumbnails.Width - 10

            'add rows
            For index As Integer = 0 To Processor.Data.FamilyThumbnail.Count - 1
                dgThumbnails.Rows.Add()
                dgThumbnails.Rows(index).Height = 500
            Next

            imageFilePath = New System.Text.StringBuilder()
            tooltipStringBuilder = New System.Text.StringBuilder()

            For Each thumbnailRow In Processor.Data.FamilyThumbnail.Rows
                imageFolderPath = Processor.GetPageImageFolderPath(thumbnailRow.VehicleId, Processors.VehicleImageSizeEnum.Thumbnail)
                imageFilePath.Append(imageFolderPath)
                imageFilePath.Append("\")
                imageFilePath.Append(thumbnailRow.ImageName)
                imageFilePath.Append(ImageFileExtension)
                If System.IO.File.Exists(imageFilePath.ToString()) = False Then
                    imageFilePath.Remove(0, imageFilePath.Length)
                    imageFolderPath = Processor.GetPageImageFolderPath(thumbnailRow.VehicleId, Processors.VehicleImageSizeEnum.Unsized)
                    imageFilePath.Append(imageFolderPath)
                    imageFilePath.Append("\")
                    imageFilePath.Append(thumbnailRow.ImageName)
                    imageFilePath.Append(ImageFileExtension)
                End If

                ' If System.IO.File.Exists(imageFilePath.ToString()) Then
                tooltipStringBuilder.Append(thumbnailRow.VehicleId.ToString())
                tooltipStringBuilder.Append(Environment.NewLine)
                tooltipStringBuilder.Append(thumbnailRow.Market)
                tooltipStringBuilder.Append(Environment.NewLine)
                tooltipStringBuilder.Append("Pages: ")
                tooltipStringBuilder.Append(thumbnailRow.ActualPageCount.ToString())
                tooltipStringBuilder.Append(Environment.NewLine)
                If thumbnailRow.IsQCDtNull() Then
                    tooltipStringBuilder.Append("Not QCed")
                Else
                    tooltipStringBuilder.Append("QCed On: ")
                    tooltipStringBuilder.Append(thumbnailRow.QCInfo)
                End If
                'End If
                LoadThumbnailImages(imageFilePath.ToString(), tooltipStringBuilder.ToString)
                imageFolderPath = Nothing
                imageFilePath.Remove(0, imageFilePath.Length)
                tooltipStringBuilder.Remove(0, tooltipStringBuilder.Length)
            Next

            thumbnailRow = Nothing
            imageFilePath = Nothing
            rowIndex = 0

        End Sub

        ''' <summary>
        ''' Renames all image files in folder to a numeric name(e.g. 001.jpg). 
        ''' </summary>
        ''' <param name="vehicleFolderPath"></param>
        ''' <remarks>DO NOT EXECUTE THIS FUNCTION ON FOLDERS HAVING CROPPED AD IMAGES.</remarks>
        Private Sub ResequenceImageFilesName(ByVal vehicleFolderPath As String)
            Dim originalFileArray() As String
            Dim fileName, fileNewName As System.Text.StringBuilder
            Dim originalFiles, tempNameFiles As System.Collections.Generic.List(Of String)

            ' Omar
            If System.IO.Directory.Exists(vehicleFolderPath) = False Then Exit Sub

            Me.StatusMessage = "Renaming image files in vehicle folder... Please wait."

            fileName = New System.Text.StringBuilder()
            fileNewName = New System.Text.StringBuilder()
            originalFiles = New System.Collections.Generic.List(Of String)
            tempNameFiles = New System.Collections.Generic.List(Of String)

            originalFileArray = System.IO.Directory.GetFiles(vehicleFolderPath, "*" + ImageFileExtension)
            originalFiles.AddRange(originalFileArray)
            System.Array.Clear(originalFileArray, 0, originalFileArray.Length)
            originalFileArray = Nothing

            For i As Integer = 0 To originalFiles.Count - 1
                'Keep files as is if in reQC
                If Not m_inReQC Then
                    fileName.Append(System.IO.Path.GetFileName(originalFiles(i)))
                    fileNewName.Append("~_")
                    fileNewName.Append(fileName.ToString())
                    My.Computer.FileSystem.RenameFile(originalFiles(i), fileNewName.ToString())
                    tempNameFiles.Add(originalFiles(i).Replace(fileName.ToString(), fileNewName.ToString()))
                    fileName.Remove(0, fileName.Length)
                    fileNewName.Remove(0, fileNewName.Length)
                End If
            Next
            originalFiles.Clear()
            originalFiles = Nothing

            For i As Integer = 0 To tempNameFiles.Count - 1
                If Not m_inReQC Then
                    fileName.Append(System.IO.Path.GetFileName(tempNameFiles(i)))
                    fileNewName.Append((i + 1).ToString().PadLeft(3, "0"c) + ".jpg")
                    My.Computer.FileSystem.RenameFile(tempNameFiles(i), fileNewName.ToString())
                    fileName.Remove(0, fileName.Length)
                    fileNewName.Remove(0, fileNewName.Length)
                End If
            Next
            tempNameFiles.Clear()
            tempNameFiles = Nothing

            fileName = Nothing
            fileNewName = Nothing
            If Not m_inReQC Then
                Me.StatusMessage = "Image files renamed successfully."
            End If
        End Sub



#Region " IForm Implementation "

        Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
        Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied

        Public Event InitializingForm() Implements IForm.InitializingForm
        Public Event FormInitialized() Implements IForm.FormInitialized


        Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

        End Sub

        Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

            RaiseEvent InitializingForm()

            Me.SuspendLayout()

            Me.FormState = formStatus

            m_Processor = New Processors.QCVehicleImages()
            Processor.Initialize()
            Processor.LoadDataSet(_sender)

            Me.StatusMessage = "Information loaded. Preparing to show information on window."

            mediaComboBox.ValueMember = "MediaId"
            mediaComboBox.DisplayMember = "Descrip"
            mediaComboBox.DataSource = Processor.Data.Media

            marketComboBox.ValueMember = "MktId"
            marketComboBox.DisplayMember = "Descrip"
            marketComboBox.DataSource = Processor.Data.Mkt

            publicationComboBox.ValueMember = "PublicationId"
            publicationComboBox.DisplayMember = "Descrip"
            publicationComboBox.DataSource = Processor.Data.Publication

            languageComboBox.ValueMember = "LanguageId"
            languageComboBox.DisplayMember = "Descrip"
            languageComboBox.DataSource = Processor.Data.Language

            retailerComboBox.ValueMember = "RetId"
            retailerComboBox.DisplayMember = "Descrip"
            retailerComboBox.DataSource = Processor.Data.Ret

            eventComboBox.ValueMember = "EventId"
            eventComboBox.DisplayMember = "Descrip"
            eventComboBox.DataSource = Processor.Data._Event

            themeComboBox.ValueMember = "ThemeId"
            themeComboBox.DisplayMember = "Descrip"
            themeComboBox.DataSource = Processor.Data.Theme

            ClearAllInputs()
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)


            Me.ResumeLayout(False)

            RaiseEvent FormInitialized()

        End Sub

#End Region


        Protected Overrides Function HasCroppedPageImages(ByVal vehicleId As Integer) As Boolean

            If Processor.GetCroppedPageCount(vehicleId) > 0 Then
                Return True
            Else
                Return False
            End If

        End Function

        Protected Overrides Sub RefreshPageInformation()
            Dim pageNumber, totalPages As Integer


            totalPagesLabel.Text = Processor.Data.Page.Count.ToString()

            If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
                pageNumber = -1
            End If

            If Integer.TryParse(totalPagesLabel.Text, totalPages) = False Then
                totalPages = -1
            End If

            firstImageButton.Enabled = (pageNumber > 1)
            previousImageButton.Enabled = (pageNumber > 1)
            nextImageButton.Enabled = (totalPages > pageNumber)
            lastImageButton.Enabled = (totalPages > pageNumber)

        End Sub


        Protected Overrides Sub OnFindVehicle(ByVal vehicleId As Integer, ByVal eventInitiator As EventInitiatorEnum)
            ' omar start logic her
            intImageRotationCount = 0
            intKeepRectangleCount = 0
            intRemoveRectangleCount = 0
            intDeleteImageCount = 0
            intResequenceCount = 0
            blnImageRotationChange = False
            blnKeepRectangleChange = False
            blnRemoveRectangleChange = False
            blnDeleteImageChange = False
            blnResequenceChange = False
            blnReQcScreen = False
            m_OKtoReQC = False
            Dim dupcheckResponse As UI.DuplicateCheckUserResponse
            Dim tempQuery As System.Data.EnumerableRowCollection(Of QCDataSet.vwCircularRow)

            qcCompletedButton.Enabled = True
            qcCompletedButton.Text = "&QC Completed"
            m_inReQC = Processor.VehicleQcCompleted(vehicleId) = 1
            wrongVersionButton.Enabled = True

            If m_inReQC Then
                If Processor.IsValidReqcUser() = 1 Then
                    qcCompletedButton.Enabled = True
                    m_OKtoReQC = True
                Else
                    qcCompletedButton.Enabled = False
                End If
                qcCompletedButton.Text = "RE&QC"
                blnReQcScreen = True
                wrongVersionButton.Enabled = False
            End If

            Processor._RemoteStatus = Me.FormState
            Processor.LoadVehicle(vehicleId, FORM_NAME)


            tempQuery = From r In Processor.Data.vwCircular _
                       Where r.VehicleId = vehicleId _
                       Select r

            If tempQuery.Count = 0 Then
                MessageBox.Show("Vehicle information not found. If Vehicle exist, please reload it.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                tempQuery = Nothing
                Exit Sub
            End If


            'Edit dupcheck for SIMR
            If ForceQCCheck(Processor._senderID) Then

                dupcheckResponse = CheckForDuplication(CType(marketComboBox.SelectedValue, Integer) _
                                                       , CType(publicationComboBox.SelectedValue, Integer), False, FORM_NAME)
                If dupcheckResponse = DuplicateCheckUserResponse.Closed Then Exit Sub

                SetVehicleRowValues(tempQuery(0), dupcheckResponse)
                UpdateVehicleIdForDupCheckFormLogId(vehicleId, Me.DupcheckFormLogId)
                Processor.SynchronizeVehicleInformation()
                tempQuery = Nothing

                EnableSIMRControls(ForceQCCheck(Processor._senderID))

                Dim pageid As Integer
                Dim pageNumber As Integer

                If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
                    pageNumber = -1
                End If

                pageid = Processor.GetPageId(vehicleId, pageNumber)

                'loadCheckedPages(pageid)
                loadCheckedPages(pageNumber)
                IsSIMR = True
            Else
                IsSIMR = False
            End If


            _sender = 0

        End Sub

        Protected Overrides Sub OnMediaChanged(ByVal mediaId As Integer, ByVal marketId As Integer, ByVal naPubOnly As Boolean, ByVal IsFSI As Boolean)

            If mediaComboBox.Text.ToUpper() = "CATALOG" Then
                Processor.LoadMarketsForCatalog()
                If marketComboBox.Items.Count = 1 Then marketComboBox.SelectedIndex = 0
                adDateTypeInDatePicker.Focus()
            ElseIf Processor.Data.vwCircular.Count > 0 AndAlso mediaComboBox.SelectedValue IsNot Nothing Then
                isAssociated = HasMarketAssoc(Processor._senderID, Processor.Data.vwCircular.Item(0).MktId)
                'remove senderExpectation check
                'If Processor.LoadMarketsPerSenderExpectation(CInt(mediaComboBox.SelectedValue.ToString), Processor._senderID) = 0 Then
                If isAssociated Then
                    Processor.LoadMarket(Processor.Data.vwCircular(0).EnvelopeId)
                Else
                    Processor.LoadMarket(Processor.Data.vwCircular(0).VehicleId, Processor._senderID)
                End If
                'End If
                If marketComboBox.Items.Count = 1 Then
                    marketComboBox.SelectedIndex = 0
                Else
                    marketComboBox.Text = String.Empty
                    marketComboBox.SelectedValue = DBNull.Value
                    marketComboBox.SelectedIndex = -1
                End If
            End If

            If marketComboBox.SelectedValue IsNot Nothing _
              AndAlso Integer.TryParse(marketComboBox.SelectedValue.ToString(), marketId) = False _
            Then
                marketId = -1
            End If

            m_IsNAPublicationsOnly = naPubOnly
            m_IsFSI = IsFSI

            OnMarketChanged(marketId, mediaId, naPubOnly)

            If IsFSI Then
                themeComboBox.SelectedIndex = themeComboBox.FindStringExact("None")
                eventComboBox.SelectedIndex = eventComboBox.FindStringExact("None")
                startDateTypeInDatePicker.Value = Nothing
                endDateTypeInDatePicker.Value = Nothing
                'couponCheckBox.Checked = True  'Because this is enabled only for page crops.
            End If
            SetRectColor()
        End Sub

        Protected Overrides Sub OnMarketChanged(ByVal marketId As Integer, ByVal mediaId As Integer, ByVal naPubOnly As Boolean)
            Dim retailerId As Integer


            If marketId < 1 OrElse mediaId < 1 Then Exit Sub

            If retailerComboBox.SelectedValue Is Nothing Then
                retailerId = -1
            Else
                retailerId = CType(retailerComboBox.SelectedValue, Integer)
            End If

            If naPubOnly Then
                Processor.LoadNAPublicationForQC()
            Else
                Dim publicationText As String = publicationComboBox.Text
                If Processor.LoadPublicationExpectation = 0 Then
                    Processor.LoadPublication(marketId, Processor.Data.vwCircular.Item(0).PublicationId)
                End If
                publicationComboBox.SelectedIndex = publicationComboBox.FindStringExact(publicationText)
                publicationText = Nothing
            End If
            'remove expectation
            'If Processor.LoadRetailersSenderExpectation(Processor._senderID, marketId, mediaId) = 0 Then
            Processor.LoadRetailer(mediaId, marketId)
            'End If
            retailerComboBox.SelectedValue = retailerId

        End Sub

        Protected Overrides Sub OnAdDateValidating(ByVal adDate As Date?, ByRef Cancel As Boolean)
            Dim dateDifference As Integer
            Dim userResponse As DialogResult

            RemoveErrorProvider(adDateTypeInDatePicker)
            If adDate Is Nothing Then
                Cancel = False
                Exit Sub
            End If

            dateDifference = adDate.Value.Subtract(System.DateTime.Today).Days

            If dateDifference < -365 OrElse dateDifference > 365 Then
                userResponse = MessageBox.Show("Is Ad Date correct?", ProductName, MessageBoxButtons.YesNo _
                                               , MessageBoxIcon.Question)
                Cancel = (userResponse = Windows.Forms.DialogResult.No)
            ElseIf dateDifference < -28 Or dateDifference > 28 Then
                SetErrorProvider(adDateTypeInDatePicker, "Ad Date needs to be within 28 days from today's date.")
            End If

        End Sub

    Protected Sub OnDistDateValidating(ByVal DistDate As Date?, ByRef Cancel As Boolean)
      Dim dateDifference As Integer
      Dim userResponse As DialogResult

      RemoveErrorProvider(DistDateTypeInDatePicker)
      If DistDate Is Nothing Then
        Cancel = False
        Exit Sub
      End If

      dateDifference = DistDate.Value.Subtract(System.DateTime.Today).Days

      If dateDifference < -365 OrElse dateDifference > 365 Then
        userResponse = MessageBox.Show("Is Dist Date correct?", ProductName, MessageBoxButtons.YesNo _
                                       , MessageBoxIcon.Question)
        Cancel = (userResponse = Windows.Forms.DialogResult.No)
      ElseIf dateDifference < -28 Or dateDifference > 28 Then
        SetErrorProvider(DistDateTypeInDatePicker, "Dist Date needs to be within 28 days from today's date.")
      End If

    End Sub

        Protected Overrides Sub OnStartDateValidating(ByVal adDate As Date?, ByVal startDate As Date?, ByRef Cancel As Boolean)
            Dim dateDifference As Integer


            If adDate.HasValue = False OrElse startDate.HasValue = False Then
                RemoveErrorProvider(startDateTypeInDatePicker)
                Cancel = False
                Exit Sub
            End If

            dateDifference = startDate.Value.Subtract(adDate.Value).Days

            If (dateDifference < -7 Or dateDifference > 7) _
              AndAlso (mediaComboBox.Text.ToUpper() = "MAILER" OrElse mediaComboBox.Text.ToUpper() = "CATALOG") _
            Then
                SetErrorProvider(startDateTypeInDatePicker, "Start Date needs to be within 7 days of Ad Date.")

            ElseIf tradeclassValueLabel.Text.ToUpper() = "DEPT" _
              AndAlso (dateDifference < -14 Or dateDifference > 14) _
            Then
                SetErrorProvider(startDateTypeInDatePicker, "Start Date needs to be within 14 days of Ad Date.")

            ElseIf dateDifference < -28 Or dateDifference > 28 Then
                SetErrorProvider(startDateTypeInDatePicker, "Start Date needs to be within 28 days of Ad Date.")

            Else
                RemoveErrorProvider(startDateTypeInDatePicker)

                If (dateDifference < -3 OrElse dateDifference > 3) Then
                    Dim userResponse As DialogResult
                    userResponse = MessageBox.Show("Difference between Sale Start Date and Ad Date should not be more than 3 days." _
                                                   + " Is Sale Start Date correct?", ProductName _
                                                   , MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                                   , MessageBoxDefaultButton.Button2)
                    If userResponse = Windows.Forms.DialogResult.No Then
                        startDateTypeInDatePicker.Focus()
                        Exit Sub
                    End If
                End If
            End If

        End Sub


        Protected Overrides Sub OnEndDateValidating(ByVal adDate As Date?, ByVal startDate As Date?, ByVal endDate As Date?, ByRef Cancel As Boolean)
            'Dim dateDifference As Integer


            If endDate.HasValue = False Then
                RemoveErrorProvider(endDateTypeInDatePicker)
                Exit Sub
            End If

            If adDate.HasValue Then
                'dateDifference = adDate.Value.Subtract(endDate.Value).Days
                If adDate.Value.Subtract(endDate.Value).Days > 0 Then
                    SetErrorProvider(endDateTypeInDatePicker, "End Date cannot be prior to Ad Date.")
                ElseIf adDate.Value.Subtract(endDate.Value).Days < -35 Then 'i.e. adDt - endDt
                    SetErrorProvider(endDateTypeInDatePicker, "End Date is not within 35 days of AdDate.")
                Else
                    RemoveErrorProvider(endDateTypeInDatePicker)
                End If
            End If

            If startDate.HasValue AndAlso m_ErrorProvider.GetError(endDateTypeInDatePicker) = String.Empty Then
                'dateDifference = startDate.Value.Subtract(endDate.Value).Days
                If startDate.Value.Subtract(endDate.Value).Days > 0 Then 'i.e. StartDt - endDt
                    SetErrorProvider(endDateTypeInDatePicker, "End Date cannot be prior to Start Date.")
                ElseIf startDate.Value.Subtract(endDate.Value).Days < -30 Then  'i.e. StartDt - endDt
                    SetErrorProvider(endDateTypeInDatePicker, "End Date is not within 30 days of Start Date.")
                Else
                    RemoveErrorProvider(endDateTypeInDatePicker)
                End If
            End If


        End Sub


        Protected Overrides Sub OnDefinePages(ByVal vehicleId As Integer)
            Dim userResponse As DialogResult
            Dim definePgs As PageDefinitionsForm


            definePgs = New PageDefinitionsForm

            definePgs.Init(FormStateEnum.Edit)
            definePgs.ApplyUserCredentials()
            definePgs.VehicleID = vehicleId
            userResponse = definePgs.ShowDialog(Me)

            definePgs.Dispose()
            definePgs = Nothing

            If userResponse = Windows.Forms.DialogResult.OK Then
                Dim currentPage As Integer

                    Processor.LoadVehiclePagesInformation(vehicleId)

                    If Integer.TryParse(currentPageLabel.Text, currentPage) = False Then
                        currentPage = -1
                    ElseIf currentPage > Processor.Data.Page.Count Then
                        currentPage = Processor.Data.Page.Count
                    End If

                    If currentPage < 1 Then
                        ''ClearImage()
                        currentPageLabel.Text = "0"
                    Else
                        ShowImage(vehicleId, currentPage)
                        currentPageLabel.Text = currentPage.ToString()
                    End If

                    Me.AskToSaveImage = False
            End If

            RefreshPageInformation()

        End Sub


        Protected Overrides Sub OnPrintLabel(ByVal vehicleId As Integer)
            Dim linqQuery As System.Collections.Generic.IEnumerable(Of QCDataSet.vwCircularRow)


            linqQuery = From r In Processor.Data.vwCircular.Cast(Of QCDataSet.vwCircularRow)() _
                        Select r _
                        Where r.VehicleId = vehicleId

            If linqQuery.Count = 0 Then
                MessageBox.Show("Unable to find information about Vehicle " + vehicleId.ToString(), _
                                ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                linqQuery = Nothing
                Exit Sub
            End If


#If DEBUG Then

            If MessageBox.Show("Do you want to print?", Application.ProductName, MessageBoxButtons.YesNo _
                               , MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No _
            Then
                Exit Sub
            End If

#End If

            Processor.PrintBarcodeLabel(linqQuery(0))

            linqQuery = Nothing

        End Sub

        Protected Overrides Sub OnDelete(ByVal vehicleId As Integer)
            Dim isSuccessful As Boolean
            Dim q As System.Collections.Generic.IEnumerable(Of QCDataSet.vwCircularRow)


            q = From r In Processor.Data.vwCircular.Rows.Cast(Of QCDataSet.vwCircularRow)() _
                Select r _
                Where r.VehicleId = vehicleId

            If q.Count = 0 Then
                MessageBox.Show("Vehicle not found. Unable to remove it.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                q(0).Delete()
            End If

            q = Nothing

            Try
                isSuccessful = False

                Me.StatusMessage = "Removing vehicle folders..."

                Processor.RemoveVehicleFolder(vehicleId)

                Me.StatusMessage = "Vehicle folders are removed successfully. Removing vehicle information..."
                Processor.Delete(vehicleId)
                'Processor.SynchronizeVehicleInformation()

                MessageBox.Show("Vehicle is removed successfully.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                isSuccessful = True

            Catch ex As Exception
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.StatusMessage = String.Empty
            End Try

            If isSuccessful Then


                intDeleteImageCount = intDeleteImageCount + 1
                blnDeleteImageChange = True
                Me.StatusMessage = "del"


                Me.FormState = FormStateEnum.View
                ClearAllInputs()
                Me.ShowHideControls(Me.FormState)
                Me.EnableDisableControls(Me.FormState)
            End If

        End Sub

        Protected Overrides Sub OnDeletePageCrop(ByVal vehicleId As Integer, ByVal pageCropId As Integer)
            Dim q As System.Collections.Generic.IEnumerable(Of QCDataSet.PageCropRow)
            Dim croppedImagePath, errorMessage As String


            'Get path before removing record.
            croppedImagePath = Processor.GetCroppedPageImagePath(vehicleId, pageCropId)

            q = From r In Processor.Data.PageCrop.Rows.Cast(Of QCDataSet.PageCropRow)() _
                Select r _
                Where r.PageCropId = pageCropId

            If q.Count > 0 Then q(0).Delete()

            Processor.SynchronizePageCropData()

            q = Nothing

            Try
                System.IO.File.Delete(croppedImagePath)
                errorMessage = Nothing
            Catch ex As System.IO.FileNotFoundException
                errorMessage = "Cropped image file not found at location " + croppedImagePath
            Catch ex As System.IO.DriveNotFoundException
                errorMessage = "File system volume not found for image file location " + croppedImagePath
            Catch ex As System.IO.PathTooLongException
                errorMessage = "Cropped image file path is too long. Location: " + croppedImagePath
            Catch ex As System.IO.IOException
                errorMessage = "File system I/O related error has occurred. Location: " + croppedImagePath
            Catch ex As System.Security.SecurityException
                errorMessage = "Security related error has occurred while removing cropped image file at location " + croppedImagePath
            Catch ex As System.UnauthorizedAccessException
                errorMessage = "Unauthorized to remove cropped image file at location " + croppedImagePath
            Catch ex As System.Exception
                errorMessage = "Unexpected error has occurred while removing cropped image file at location " + croppedImagePath
            End Try

            If errorMessage IsNot Nothing Then
                MessageBox.Show("Unable to remove cropped page image." + Environment.NewLine + errorMessage _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

            Me.FormState = FormStateEnum.View
            If Processor.Data.PageCrop.Count = 0 Then
                Me.findVehicleIdTextBox.Text = vehicleId.ToString()
                loadButton.PerformClick()
            Else
                Dim pageNumber, totalPages As Integer

                If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
                    pageNumber = -1
                End If
                totalPages = Processor.Data.PageCrop.Count
                totalPagesLabel.Text = totalPages.ToString()

                If totalPages < pageNumber Then
                    pageNumber = totalPages
                End If
                OnFindCroppedPage(vehicleId, pageNumber)
                RefreshPageCropInformation()
            End If

        End Sub

        Protected Overrides Sub OnEdit(ByVal vehicleId As Integer)

            If Me.IsPageCropNavigation = False Then
                Dim vehicleRow As System.Data.EnumerableRowCollection(Of QCDataSet.vwCircularRow)

                vehicleRow = From vr In Processor.Data.vwCircular _
                             Where vr.VehicleId = vehicleId _
                             Select vr

                If vehicleRow.Count() = 0 Then
                    MessageBox.Show("Unable to find Vehicle information. Try reloading Vehicle information manually.", _
                                    ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                ShowVehicleInformation(vehicleRow(0))

                vehicleRow = Nothing
            End If

            Me.FormState = FormStateEnum.Edit

        End Sub

        Protected Overrides Sub OnCancel(ByVal vehicleId As Integer)
            Dim vehicleRow As System.Data.EnumerableRowCollection(Of QCDataSet.vwCircularRow)


            vehicleRow = From vr In Processor.Data.vwCircular _
                         Where vr.VehicleId = vehicleId _
                         Select vr

            If vehicleRow.Count() = 0 Then
                MessageBox.Show("Unable to find Vehicle information. Try reloading Vehicle information manually.", _
                                ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ShowVehicleInformation(vehicleRow(0))

            vehicleRow = Nothing

            Me.FormState = FormStateEnum.View

        End Sub

        ''' <summary>
        ''' Checks if media, market, publication or ad date is changed by user, displays appropriate message
        ''' and returns user's response to the message.
        ''' </summary>
        ''' <param name="tempRow"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function CheckColumnChangesAndShowWarnings(ByVal tempRow As QCDataSet.vwCircularRow) As System.Windows.Forms.DialogResult
            Dim hasPageCrops As Boolean
            Dim mediaId, marketId, publicationId As Integer
            Dim userResponse As System.Windows.Forms.DialogResult
            Dim adDate As DateTime
            Dim mediaQuery As System.Data.EnumerableRowCollection(Of QCDataSet.MediaRow)


            If tempRow.HasVersion(DataRowVersion.Current) = True _
                AndAlso tempRow.HasVersion(DataRowVersion.Original) = False _
            Then Exit Function

            mediaId = CType(tempRow("MediaId", DataRowVersion.Original), Integer)
            marketId = CType(tempRow("MktId", DataRowVersion.Original), Integer)
            publicationId = CType(tempRow("PublicationId", DataRowVersion.Original), Integer)
            adDate = CType(tempRow("BreakDt", DataRowVersion.Original), DateTime)

            If marketId <> tempRow.MktId AndAlso publicationId <> tempRow.PublicationId _
              AndAlso adDate <> tempRow.BreakDt _
            Then
                userResponse = MessageBox.Show("Changing Market/Publcation/Ad Date for this Vehicle would" _
                                               + " affect the indexed information for the pages. Do you" _
                                               + " want to proceed?", ProductName, MessageBoxButtons.YesNo _
                                               , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            End If

            If userResponse = Windows.Forms.DialogResult.No Then userResponse = Windows.Forms.DialogResult.None

            '
            'Check if the original media is FSI, and current media is different then only show warning.
            '
            mediaQuery = From m In Processor.Data.Media Where m.MediaID = mediaId Select m
            If mediaQuery.Count() < 1 OrElse mediaQuery(0).Descrip.ToUpper() <> "FSI" Then
                mediaQuery = Nothing
                Return Windows.Forms.DialogResult.None
            End If

            hasPageCrops = (Processor.GetCroppedPageCount(tempRow.VehicleId) > 0)
            If mediaId <> tempRow.MediaId AndAlso hasPageCrops Then
                userResponse = MessageBox.Show("Indexed information exists for pages with in this Vehicle" _
                                               + ", Please delete the page information before changing " _
                                               + "the Media.", ProductName, MessageBoxButtons.OK _
                                               , MessageBoxIcon.Warning)
            End If


            Return userResponse

        End Function

        Private Sub MarkVehiclesForWrongVersion(ByVal vehicleIdArray() As Integer)
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.VehiclesDataTable
            Dim tempRow As MCAP.ReportsDataSet.VehiclesRow


            tempAdapter = New MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()


            For i As Integer = 0 To vehicleIdArray.Length - 1
                tempAdapter.UpdateVehicleStatus(FORM_NAME, vehicleIdArray(i), "Wrong Version", User.UserID)

                'tempRow.Delete()
            Next
            '  tempTable.AcceptChanges()

            tempAdapter.Dispose()
            tempAdapter = Nothing
            tempTable = Nothing
            tempRow = Nothing
        End Sub


        Protected Overrides Sub OnWrongVersion(ByVal vehicleId As Integer)


            'OnSave(vehicleId)

            Dim userResponse As DialogResult


            userResponse = MessageBox.Show("Are you sure you want to mark as wrong version " + vehicleId.ToString() + "?" _
                                           , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                           , MessageBoxDefaultButton.Button2)

            If userResponse = Windows.Forms.DialogResult.No Then Exit Sub


            MarkVehiclesForWrongVersion(New Integer() {vehicleId})
            'enterButton.PerformClick()
            ClearAllInputs()
        End Sub

        Protected Overrides Sub OnSave(ByVal vehicleId As Integer)
            Dim pageNumber As Integer
            Dim pageImage As String
            Dim dupcheckResponse As UI.DuplicateCheckUserResponse
            Dim tempQuery As System.Data.EnumerableRowCollection(Of QCDataSet.vwCircularRow)


            If AreInputsValid() = False Then Exit Sub

            RemoveAllErrorProviders()

            tempQuery = From r In Processor.Data.vwCircular _
                        Where r.VehicleId = vehicleId _
                        Select r

            If tempQuery.Count = 0 Then
                MessageBox.Show("Vehicle information not found. If Vehicle exist, please reload it.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                tempQuery = Nothing
                Exit Sub
            End If

            If CheckColumnChangesAndShowWarnings(tempQuery(0)) <> Windows.Forms.DialogResult.None Then Exit Sub

            dupcheckResponse = CheckForDuplication(CType(marketComboBox.SelectedValue, Integer) _
                                                       , CType(publicationComboBox.SelectedValue, Integer), False, FORM_NAME)
                If dupcheckResponse = DuplicateCheckUserResponse.Closed Then Exit Sub

                SetVehicleRowValues(tempQuery(0), dupcheckResponse)

            tempQuery = Nothing

            If Processor.AreInputsValid(Processor.Data.vwCircular(0)) = False Then
                If Processor.Data.Errors.Count > 0 Then
                    ShowErrors(Processor.Data.Errors)
                    Processor.Data.Errors.Clear()
                    Exit Sub
                ElseIf Processor.Data.Warnings.Count > 0 Then
                    If ShowWarnings(Processor.Data.Warnings) = Windows.Forms.DialogResult.Cancel Then
                        Processor.Data.Warnings.Clear()
                        Exit Sub
                    End If
                End If
            End If

            Processor.SynchronizeVehicleInformation()

            'Save page image, if it is modified.
            If Me.AskToSaveImage Then
                If Integer.TryParse(currentPageLabel.Text, pageNumber) Then
                    pageImage = Processor.GetPageImageFilePath(vehicleId, pageNumber, Processors.VehicleImageSizeEnum.Unsized)
                    '' SaveImage(mainAxLEAD, pageImage, ImageFileFormat, BITsPerPixel, ImageCompression, 1) \\ Comment By Denver : 77

                End If
            End If

            pageImage = Nothing

            Me.FormState = FormStateEnum.View
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

        End Sub

        Protected Overrides Sub OnSavePageCrop(ByVal vehicleId As Integer, ByVal pageNumber As Integer, ByVal adSize As System.Drawing.SizeF, ByVal adRectangle As System.Drawing.RectangleF)
            Dim pageCropId, adSizeId As Integer
            Dim croppedPageImagePath As String
            Dim tempRow As QCDataSet.PageCropRow

            If AreInputsValid() = False Then Exit Sub

            pageCropId = CType(pageCropIdLabel.Text, Integer)
            If adSize = System.Drawing.SizeF.Empty Then
                adSizeId = 0
            Else
                adSizeId = Processor.GetSizeId(adSize.Width, adSize.Height)
            End If

            tempRow = Processor.Data.PageCrop.FindByPageCropId(pageCropId)

            UpdatePageCropDataRow(tempRow, adSizeId, adRectangle)

            If Processor.AreInputsValid(Processor.Data.vwCircular(0), tempRow) = False Then
                If Processor.Data.Errors.Count > 0 Then
                    ShowErrors(Processor.Data.Errors)
                    Processor.Data.Errors.Clear()
                    Exit Sub
                ElseIf Processor.Data.Warnings.Count > 0 Then
                    If ShowWarnings(Processor.Data.Warnings) = Windows.Forms.DialogResult.Cancel Then
                        Processor.Data.Warnings.Clear()
                        Exit Sub
                    End If
                End If
            End If

            Processor.SynchronizePageCropData()

            croppedPageImagePath = Processor.GetCroppedPageImagePath(vehicleId, pageCropId)
            '' SaveImage(mainAxLEAD, croppedPageImagePath, ImageFileFormat, BITsPerPixel, ImageCompression, 1)  \\ Comment By Denver : 78

            ' ************************** Omar ******************************
            ' Add keep count here based on info that keep is basically crop.
            ' **************************************************************
            intKeepRectangleCount = intKeepRectangleCount + 1
            Me.StatusMessage = "recrp2"


            Me.FormState = FormStateEnum.View
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

        End Sub

        Protected Overrides Sub OnAdd()

            'To reset cropped image size related variables.
            MyBase.OnAdd()

            Me.FormState = FormStateEnum.Insert

            ClearInputs(True, False, False)
            EnableDisableControls(FormStateEnum.Insert)
            cancelButton.Visible = True

            retailerComboBox.Focus()

        End Sub

        Protected Overrides Sub OnSame(ByVal vehicleId As Integer, ByVal pageNumber As Integer, ByVal adSize As System.Drawing.SizeF, ByVal adRectangle As System.Drawing.RectangleF, Optional ByVal isRectKept As Boolean = False, Optional ByVal isRectRemoved As Boolean = False, _
                                       Optional ByVal isRectDrawn As Boolean = False)
            Dim pageId, adSizeId As Integer
            Dim pageName, croppedPageImageFolder As String
            Dim tempRow As QCDataSet.PageCropRow


            If AreInputsValid() = False Then
                If isRectKept = True Then
                    tmpIsRectKept = 1
                Else
                    tmpIsRectKept = 0
                End If
                Exit Sub
            End If

            If tmpIsRectKept = 0 Then
                isRectKept = False
            ElseIf tmpIsRectKept = 1 Then
                isRectKept = True
            End If

            pageId = Processor.GetPageId(vehicleId, pageNumber)
            adSizeId = Processor.GetSizeId(adSize.Width, adSize.Height)
            pageName = Processor.GetNewImageName()
            tempRow = Processor.Data.PageCrop.NewPageCropRow()

            SetNewPageCropDataRow(tempRow, pageId, pageName, adSizeId, adRectangle)

            If Processor.AreInputsValid(Processor.Data.vwCircular(0), tempRow) = False Then
                If Processor.Data.Errors.Count > 0 Then
                    ShowErrors(Processor.Data.Errors)
                    Processor.Data.Errors.Clear()
                    Exit Sub
                ElseIf Processor.Data.Warnings.Count > 0 Then
                    If ShowWarnings(Processor.Data.Warnings) = Windows.Forms.DialogResult.Cancel Then
                        Processor.Data.Warnings.Clear()
                        Exit Sub
                    End If
                End If
            End If

            pageId = -1
            Processor.AddPageCropInformation(tempRow)
            Processor.SynchronizePageCropData()
            pageId = tempRow.PageCropId
            tempRow = Nothing

            If pageId < 1 Then
                MessageBox.Show("Unable to record information for cropped page image. Aborting current task." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            pageName += ImageFileExtension
            croppedPageImageFolder = Processor.GetCroppedPageImageFolderPath(vehicleId, pageId)
            System.IO.Directory.CreateDirectory(croppedPageImageFolder)
            pageName = croppedPageImageFolder + "\" + pageName

            If isRectDrawn Or isRectRemoved Then adRectangle = New RectangleF(0, 0, OutputPictureBox.Width, OutputPictureBox.Height)
            PageCropImage(New Bitmap(OutputPictureBox.Image), adRectangle, isRectKept)

            SaveImage(PgCropImage, pageName)

            'Prepare for for next page image crop.
            OnAdd()

            Dim userResponse As System.Windows.Forms.DialogResult
            If nextImageButton.Enabled = False AndAlso lastImageButton.Enabled = False Then
                MessageBox.Show("This is last page of vehicle.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                userResponse = Windows.Forms.DialogResult.Yes
            Else
                userResponse = MessageBox.Show("Do you want to work with same page image?", ProductName _
                                                 , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            End If

            If userResponse = Windows.Forms.DialogResult.Yes Then
                ShowImage(vehicleId, pageNumber)
            ElseIf userResponse = Windows.Forms.DialogResult.No Then
                If nextImageButton.Enabled Then
                    nextImageButton.PerformClick()  'Move to next page.
                ElseIf previousImageButton.Enabled Then
                    previousImageButton.PerformClick()  'Move to previous page.
                Else  'Vehicle has only one page image.
                    ShowImage(vehicleId, pageNumber)
                End If
            End If

            tmpIsRectKept = -1
        End Sub

        Protected Overrides Sub OnNew(ByVal vehicleId As Integer, ByVal pageNumber As Integer, ByVal adSize As System.Drawing.SizeF, ByVal adRectangle As System.Drawing.RectangleF, Optional ByVal isRectKept As Boolean = False, Optional ByVal isRectRemoved As Boolean = False, _
                                       Optional ByVal isRectDrawn As Boolean = False)
            Dim pageId, adSizeId As Integer
            Dim pageName, croppedPageImageFolder As String
            Dim tempRow As QCDataSet.PageCropRow


            If AreInputsValid() = False Then
                If isRectKept = True Then
                    tmpIsRectKept = 1
                Else
                    tmpIsRectKept = 0
                End If
                Exit Sub
            End If

            If tmpIsRectKept = 0 Then
                isRectKept = False
            ElseIf tmpIsRectKept = 1 Then
                isRectKept = True
            End If

            pageId = Processor.GetPageId(vehicleId, pageNumber)
            adSizeId = Processor.GetSizeId(adSize.Width, adSize.Height)
            pageName = Processor.GetNewImageName()
            tempRow = Processor.Data.PageCrop.NewPageCropRow()

            'If adlertPageNameTextBox.Visible AndAlso ValidateADlertPageName(vehicleId, pageId) = False Then Exit Sub

            SetNewPageCropDataRow(tempRow, pageId, pageName, adSizeId, adRectangle)
            'If adlertPageNameTextBox.Visible Then SetADlertPageName(vehicleId, pageId)

            If Processor.AreInputsValid(Processor.Data.vwCircular(0), tempRow) = False Then
                If Processor.Data.Errors.Count > 0 Then
                    ShowErrors(Processor.Data.Errors)
                    Processor.Data.Errors.Clear()
                    Exit Sub
                ElseIf Processor.Data.Warnings.Count > 0 Then
                    If ShowWarnings(Processor.Data.Warnings) = Windows.Forms.DialogResult.Cancel Then
                        Processor.Data.Warnings.Clear()
                        Exit Sub
                    End If
                End If
            End If

            pageId = -1
            Processor.AddPageCropInformation(tempRow)
            Processor.SynchronizePageCropData()
            'If adlertPageNameTextBox.Visible Then Processor.UpdateAllPageNames()
            pageId = tempRow.PageCropId
            tempRow = Nothing

            If pageId < 1 Then
                MessageBox.Show("Unable to record information for cropped page image. Aborting current task." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            pageName += ImageFileExtension
            croppedPageImageFolder = Processor.GetCroppedPageImageFolderPath(vehicleId, pageId)
            'System.IO.Directory.CreateDirectory(croppedPageImageFolder) - Ritesh (10 Nov 2008) stored in unsized vehicle page image folder itself.
            pageName = croppedPageImageFolder + "\" + pageName

            If isRectDrawn Or isRectRemoved Then adRectangle = New RectangleF(0, 0, OutputPictureBox.Width, OutputPictureBox.Height)
            PageCropImage(New Bitmap(OutputPictureBox.Image), adRectangle, isRectKept)

            SaveImage(PgCropImage, pageName)

            OnAdd() 'Prepare for for next page image crop.

            Dim userResponse As System.Windows.Forms.DialogResult
            If nextImageButton.Enabled = False AndAlso lastImageButton.Enabled = False Then
                MessageBox.Show("This is last page of vehicle.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                userResponse = Windows.Forms.DialogResult.Yes
            Else
                userResponse = MessageBox.Show("Do you want to work with same page image?", ProductName _
                                               , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            End If

            If userResponse = Windows.Forms.DialogResult.Yes Then
                ShowImage(vehicleId, pageNumber)
            ElseIf userResponse = Windows.Forms.DialogResult.No Then
                If nextImageButton.Enabled Then
                    nextImageButton.PerformClick()  'Move to next page.
                ElseIf previousImageButton.Enabled Then
                    previousImageButton.PerformClick()  'Move to previous page.
                Else  'Vehicle has only one page image.
                    ShowImage(vehicleId, pageNumber)
                End If
            End If

            tmpIsRectKept = -1

        End Sub

        Private Sub PageCropImage(ByVal bmp As Bitmap, ByVal rect As RectangleF, Optional ByVal isRectKept As Boolean = False)
            If (IsZoomedIn = False And isRectKept = False) Or (IsZoomedIn = True And isRectKept = False) Then
                Dim MyRect As RectangleF
                Dim RectWidth As Integer = CType(rect.Width, Integer)
                Dim RectHeight As Integer = CType(rect.Height, Integer)

                If RectWidth = 0 Then RectWidth = OutputPictureBox.Width
                If RectHeight = 0 Then RectHeight = OutputPictureBox.Height

                Dim _output As Bitmap = New Bitmap(RectWidth, RectHeight)
                MyRect = New RectangleF(CType(rect.X, Integer), CType(rect.Y, Integer), RectWidth, RectHeight)
                MyGraphics = Graphics.FromImage(_output)
                MyGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic
                MyGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality
                MyGraphics.CompositingQuality = CompositingQuality.GammaCorrected
                MyGraphics.DrawImage(bmp, 0, 0, MyRect, GraphicsUnit.Pixel)
                PgCropImage = New Bitmap(RectWidth, RectHeight)
                PgCropImage = _output
            Else
                Dim MyRect As RectangleF
                Dim RectWidth As Integer = CType(rect.Width, Integer)
                Dim RectHeight As Integer = CType(rect.Height, Integer)

                If RectWidth = 0 Then RectWidth = OutputPictureBox.Width
                If RectHeight = 0 Then RectHeight = OutputPictureBox.Height

                Dim _output As Bitmap = New Bitmap(RectWidth, RectHeight)
                MyGraphics = Graphics.FromImage(_output)
                MyGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic
                MyGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality
                MyGraphics.CompositingQuality = CompositingQuality.GammaCorrected
                MyGraphics.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height)
                PgCropImage = New Bitmap(RectWidth, RectHeight)
                PgCropImage = _output
            End If
        End Sub

        Protected Overrides Sub OnClear()

            Me.FormState = FormStateEnum.View

            ClearAllInputs()
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

            findVehicleIdTextBox.Focus()
            findVehicleIdTextBox.SelectAll()

        End Sub

        Protected Overrides Sub OnShowPreviousPageCrop(ByVal vehicleId As Integer, ByVal retailerId As Integer)

            If retailerId < 1 Then
                Processor.LoadLatestPageCropInformation(vehicleId)
            Else
                Processor.LoadLatestPageCropInformation(vehicleId, retailerId)
            End If

            If Processor.Data.PageCrop.Count > 0 Then
                ShowVehicleInformation(Processor.Data.PageCrop(0))
            Else
                MessageBox.Show("Vehicle does not have any cropped Ads.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            If languageComboBox.SelectedValue Is Nothing _
              AndAlso Processor.Data.vwCircular.Count > 0 _
              AndAlso Processor.Data.vwCircular(0).IsLanguageIdNull() = False _
            Then
                languageComboBox.SelectedValue = Processor.Data.vwCircular(0).LanguageId
            End If

            'Following load statement is required to reload all pagecrop information, for the vehicle, in dataset.
            Processor.LoadVehiclePageCropInformation(vehicleId)

            'If Me.IsPageCropNavigation = False Then
            '  Me.IsPageCropNavigation = True
            'End If

        End Sub
        'Protected Overrides Sub OnDrawImage(ByVal VehicleId As Integer)

        '    Dim newSubject As String = txtSubject.Text

        '    If newSubject Is Nothing Then
        '        newSubject = ""
        '    End If

        '    If AreInputsValid() = False Then Exit Sub
        '    'MessageBox.Show("", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        '    Me.StatusMessage = "Processing vehicle to mark it as Wrong Version. Please wait..."

        '    Try
        '        Processor.MarkVehicleAsWrongVersion(VehicleId, FORM_NAME)
        '    Catch ex As System.ApplicationException
        '        MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try


        'End Sub
        ''' <summary>
        ''' On Not Promotional
        ''' </summary>
        ''' <param name="VehicleId"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnNotPromotional(ByVal VehicleId As Integer)

            Dim newSubject As String = txtSubject.Text

            If newSubject Is Nothing Then
                newSubject = ""
            End If

            If AreInputsValid() = False Then Exit Sub
            'MessageBox.Show("", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.StatusMessage = "Processing vehicle to mark it as Non Promotional. Please wait..."

            Try
                'Update to mark vehicle as dup
                'Processor.MarkVehicleAsWrongVersion(VehicleId, FORM_NAME)
                Processor.MarkVehicleAsNonPromotional(VehicleId, FORM_NAME)

            Catch ex As System.ApplicationException
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            MessageBox.Show("Vehicle marked as no promotional activity.")
        End Sub
        ''' <summary>
        ''' omar qc complete
        ''' </summary>
        ''' <param name="VehicleId"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnQCComplete(ByVal VehicleId As Integer)
            Dim imageFolder As String
            Dim userResponse As Windows.Forms.DialogResult
            Dim childVehicleList As System.Collections.Generic.Dictionary(Of Integer, String)

            Dim newSubject As String = txtSubject.Text

            If newSubject Is Nothing Then
                newSubject = ""
            End If



            If Me.AskToSaveImage Then
                userResponse = MessageBox.Show("Do you want to save changes made to image file?" _
                                               , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If userResponse = DialogResult.Yes Then
                    SaveImage(ImageDisplay.Image, ImageDisplay.ImageLocation.ToString)
                End If
                Me.AskToSaveImage = False
            End If

            If AreInputsValid() = False Then Exit Sub
            'image folder 
            imageFolder = Processor.GetPageImageFolderPath(VehicleId, Processors.VehicleImageSizeEnum.Unsized)

            'If System.IO.Directory.Exists(imageFolder) = False Then
            '    MessageBox.Show("Unsized page image folder not found for vehicle " + VehicleId.ToString() _
            '                    + Environment.NewLine + "Expected location: " + imageFolder _
            '                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'ElseIf ArePageImageFilesValid(VehicleId) = False Then
            '    MessageBox.Show("Total number of page image files does not match specified number of pages." _
            '                    + Environment.NewLine + "Cannot mark vehicle as QCed.", ProductName _
            '                    , MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If

            ' ****************************************************************** '
            ' ****************************Omar********************************** '
            ' *****************Reqc at the top condition************************ '
            ' ****************QC at the bottom condition************************ '
            ' ****************************************************************** '
            If blnReQcScreen = True Then
                Me.StatusMessage = "Processing vehicle to mark it as Re QCed. Please wait..."
                ' Same as below except for two additional columns
                Try
                    ' Processor.UpdateSPReviewStatus(VehicleId, FORM_NAME)
                    ' * Omar add new qc process here
                    Processor.MarkVehicleAsReQCed(VehicleId, FORM_NAME, newSubject)
                    ' add function to process imnage changes in process
                    Me.StatusMessage = "Processing child vehicle(s) to mark as reQCed. Please wait..."
                    childVehicleList = Processor.MarkChildVehiclesAsQCed(VehicleId, FORM_NAME)

                    ' Log ReQc Image changes here
                    If blnImageRotationChange = True Or blnKeepRectangleChange = True Or blnRemoveRectangleChange = True Or blnDeleteImageChange = True Or blnResequenceChange = True Then
                        Processor.ImageLogData(VehicleId, FORM_NAME, intImageRotationCount, intKeepRectangleCount, intRemoveRectangleCount, intDeleteImageCount, intResequenceCount)
                        Me.StatusMessage = "Archiving changes. Please wait..."
                    End If


                    Me.StatusMessage = String.Empty
                    If childVehicleList.Count = 0 Then
                        MessageBox.Show("Vehicle marked successfully as REQC Completed.", ProductName _
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Dim childList As ChildVehicleListForm = New ChildVehicleListForm()
                        childList.ParentVehicleId = VehicleId
                        childList.ChildVehicleList = childVehicleList
                        childList.PrepareForm()
                        childList.ShowDialog(Me)

                        childList.Dispose()
                        childList = Nothing
                    End If
                    childVehicleList.Clear()
                    childVehicleList = Nothing
                    ClearAllInputs()
                    findVehicleIdTextBox.Focus()
                    Processor.RenameVehiclePageImageFiles(VehicleId)
                Catch ex As System.ApplicationException
                    MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                If AllowCacheImage = True Then
                    ClearCatchImages()
                    Processor.ClearLocalImageFolder(VehicleId)
                End If

            Else
                Me.StatusMessage = "Processing vehicle to mark it as QCed. Please wait..."

                Try
                    Processor.UpdateSPReviewStatus(VehicleId, FORM_NAME)
                    ' Omar add new qc process here
                    Processor.MarkVehicleAsQCed(VehicleId, FORM_NAME, newSubject)
                    Me.StatusMessage = "Processing child vehicle(s) to mark as QCed. Please wait..."
                    childVehicleList = Processor.MarkChildVehiclesAsQCed(VehicleId, FORM_NAME)
                    Me.StatusMessage = String.Empty
                    If childVehicleList.Count = 0 Then
                        MessageBox.Show("Vehicle marked successfully as QC Completed.", ProductName _
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Dim childList As ChildVehicleListForm = New ChildVehicleListForm()
                        childList.ParentVehicleId = VehicleId
                        childList.ChildVehicleList = childVehicleList
                        childList.PrepareForm()
                        childList.ShowDialog(Me)
                        childList.Dispose()
                        childList = Nothing
                    End If
                    childVehicleList.Clear()
                    childVehicleList = Nothing
                    ClearAllInputs()
                    findVehicleIdTextBox.Focus()
                Catch ex As System.ApplicationException
                    MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            Me.StatusMessage = String.Empty

        End Sub

        Protected Overrides Sub OnNavigateToFirstImage(ByVal vehicleId As Integer)
            'Dim imageFolder As String
            ImagePanel.SuspendLayout()
            If String.IsNullOrEmpty(ImageDisplay.ImageLocation) = False Then
                _filePath = ImageDisplay.ImageLocation.ToString
            End If
            If Me.AskToSaveImage Then
                Dim userResponse As System.Windows.Forms.DialogResult

                userResponse = PromptToSaveImage(_filePath)
                Select Case userResponse
                    Case Windows.Forms.DialogResult.Yes 'Image is saved successfully.
                    Case Windows.Forms.DialogResult.No  'User don't want to save image changes.
                    Case Windows.Forms.DialogResult.Ignore  'User want to ignore unsaved changes made to image.
                    Case Windows.Forms.DialogResult.Abort 'User want to abort navigation.
                        Exit Sub
                End Select
            End If

            ShowImage(vehicleId, 1)

            If FormState <> FormStateEnum.Remote Then
                If Processor.Data.vwCircular(0).IsFamilyIdNull() = False Then
                    Dim familyId As Integer = Processor.Data.vwCircular(0).FamilyId
                    Processor.LoadPagesInformationForFamilyThumbnail(vehicleId, familyId, 1)
                    ShowFamilyThumbnails()
                Else
                    dgThumbnails.Rows.Clear()
                End If
            End If

            currentPageLabel.Text = "1"
            pageSizeLabel.Text = GetPageSizeText(vehicleId, 1)
            Dim dsPage As DataSet = GetPageStartEndDt(vehicleId, 1)
            If dsPage.Tables(0).Rows.Count > 0 And String.IsNullOrEmpty(dsPage.Tables(0).Rows(0).Item(0).ToString) = False _
            And String.IsNullOrEmpty(dsPage.Tables(0).Rows(0).Item(1).ToString) = False Then
                PageDateLabel.Text = CType(dsPage.Tables(0).Rows(0).Item(0), Date).ToShortDateString + " - " + CType(dsPage.Tables(0).Rows(0).Item(1).ToString, Date).ToShortDateString
                PageDateLabel.Visible = True
            Else
                PageDateLabel.Visible = False
            End If
            Me.AskToSaveImage = False
            ImagePanel.ResumeLayout()
            _CurrentAngle = 0
            'SIMR Function
            Dim pageNumber As Integer
            If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
                pageNumber = -1
            End If

            loadSIMRValues(vehicleId, pageNumber)
        End Sub

        Protected Overrides Sub OnNavigateToPreviousImage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            'Dim imageFolder As String
            ImagePanel.SuspendLayout()
            If String.IsNullOrEmpty(ImageDisplay.ImageLocation) = False Then
                _filePath = ImageDisplay.ImageLocation.ToString
            End If
            If Me.AskToSaveImage Then
                Dim userResponse As System.Windows.Forms.DialogResult

                userResponse = PromptToSaveImage(_filePath)
                Select Case userResponse
                    Case Windows.Forms.DialogResult.Yes 'Image is saved successfully.
                    Case Windows.Forms.DialogResult.No  'User don't want to save image changes.
                    Case Windows.Forms.DialogResult.Ignore  'User want to ignore unsaved changes made to image.
                    Case Windows.Forms.DialogResult.Abort 'User want to abort navigation.
                        Exit Sub
                End Select
            End If

            ShowImage(vehicleId, pageNumber)

            If FormState <> FormStateEnum.Remote Then
                If Processor.Data.vwCircular(0).IsFamilyIdNull() = False Then
                    Dim familyId As Integer = Processor.Data.vwCircular(0).FamilyId
                    Processor.LoadPagesInformationForFamilyThumbnail(vehicleId, familyId, pageNumber)
                    ShowFamilyThumbnails()
                Else
                    dgThumbnails.Rows.Clear()
                End If
            End If

            currentPageLabel.Text = pageNumber.ToString()
            pageSizeLabel.Text = GetPageSizeText(vehicleId, pageNumber)
            Dim dsPage As DataSet = GetPageStartEndDt(vehicleId, pageNumber)
            If dsPage.Tables(0).Rows.Count > 0 And String.IsNullOrEmpty(dsPage.Tables(0).Rows(0).Item(0).ToString) = False _
            And String.IsNullOrEmpty(dsPage.Tables(0).Rows(0).Item(1).ToString) = False Then
                PageDateLabel.Text = CType(dsPage.Tables(0).Rows(0).Item(0), Date).ToShortDateString + " - " + CType(dsPage.Tables(0).Rows(0).Item(1).ToString, Date).ToShortDateString
                PageDateLabel.Visible = True
            Else
                PageDateLabel.Visible = False
            End If
            Me.AskToSaveImage = False
            ImagePanel.ResumeLayout()
            _CurrentAngle = 0
            'SIMR Function
            loadSIMRValues(vehicleId, pageNumber)
        End Sub

        Protected Overrides Sub OnNavigateToNextImage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            ImagePanel.SuspendLayout()



            If pageNumber = 2 AndAlso mediaComboBox.Text.ToUpper = "SOCIAL" Then
                recaptureWebpageButton.Enabled = True

            End If

            If String.IsNullOrEmpty(ImageDisplay.ImageLocation) = False Then
                _filePath = ImageDisplay.ImageLocation.ToString
            End If
            If Me.AskToSaveImage Then
                Dim userResponse As System.Windows.Forms.DialogResult

                userResponse = PromptToSaveImage(_filePath)
                Select Case userResponse
                    Case Windows.Forms.DialogResult.Yes 'Image is saved successfully.
                    Case Windows.Forms.DialogResult.No  'User don't want to save image changes.
                    Case Windows.Forms.DialogResult.Ignore  'User want to ignore unsaved changes made to image.
                    Case Windows.Forms.DialogResult.Abort 'User want to abort navigation.
                        Exit Sub
                End Select
            End If

            ShowImage(vehicleId, pageNumber)

            If FormState <> FormStateEnum.Remote Then
                If Processor.Data.vwCircular(0).IsFamilyIdNull() = False Then
                    Dim familyId As Integer = Processor.Data.vwCircular(0).FamilyId
                    Processor.LoadPagesInformationForFamilyThumbnail(vehicleId, familyId, pageNumber)
                    ShowFamilyThumbnails()
                Else
                    dgThumbnails.Rows.Clear()
                End If
            End If

            currentPageLabel.Text = pageNumber.ToString()
            pageSizeLabel.Text = GetPageSizeText(vehicleId, pageNumber)
            Dim dsPage As DataSet = GetPageStartEndDt(vehicleId, pageNumber)
            If dsPage.Tables(0).Rows.Count > 0 And String.IsNullOrEmpty(dsPage.Tables(0).Rows(0).Item(0).ToString) = False _
            And String.IsNullOrEmpty(dsPage.Tables(0).Rows(0).Item(1).ToString) = False Then
                PageDateLabel.Text = CType(dsPage.Tables(0).Rows(0).Item(0), Date).ToShortDateString + " - " + CType(dsPage.Tables(0).Rows(0).Item(1).ToString, Date).ToShortDateString
                PageDateLabel.Visible = True
            Else
                PageDateLabel.Visible = False
            End If
            Me.AskToSaveImage = False

            ImagePanel.ResumeLayout()
            _CurrentAngle = 0
            'SIMR Function
            loadSIMRValues(vehicleId, pageNumber)
        End Sub


        Protected Overrides Sub OnNavigateToLastImage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            'Dim imageFolder As String
            ImagePanel.SuspendLayout()
            If String.IsNullOrEmpty(ImageDisplay.ImageLocation) = False Then
                _filePath = ImageDisplay.ImageLocation.ToString
            End If
            If Me.AskToSaveImage Then
                Dim userResponse As System.Windows.Forms.DialogResult

                userResponse = PromptToSaveImage(_filePath)
                Select Case userResponse
                    Case Windows.Forms.DialogResult.Yes 'Image is saved successfully.
                    Case Windows.Forms.DialogResult.No  'User don't want to save image changes.
                    Case Windows.Forms.DialogResult.Ignore  'User want to ignore unsaved changes made to image.
                    Case Windows.Forms.DialogResult.Abort 'User want to abort navigation.
                        Exit Sub
                End Select
            End If

            ShowImage(vehicleId, pageNumber)

            If FormState <> FormStateEnum.Remote Then
                If Processor.Data.vwCircular(0).IsFamilyIdNull() = False Then
                    Dim familyId As Integer = Processor.Data.vwCircular(0).FamilyId
                    Processor.LoadPagesInformationForFamilyThumbnail(vehicleId, familyId, pageNumber)
                    ShowFamilyThumbnails()
                Else
                    dgThumbnails.Rows.Clear()
                End If
            End If

            currentPageLabel.Text = pageNumber.ToString()
            pageSizeLabel.Text = GetPageSizeText(vehicleId, pageNumber)
            Dim dsPage As DataSet = GetPageStartEndDt(vehicleId, pageNumber)
            If dsPage.Tables(0).Rows.Count > 0 And String.IsNullOrEmpty(dsPage.Tables(0).Rows(0).Item(0).ToString) = False _
            And String.IsNullOrEmpty(dsPage.Tables(0).Rows(0).Item(1).ToString) = False Then
                PageDateLabel.Text = CType(dsPage.Tables(0).Rows(0).Item(0), Date).ToShortDateString + " - " + CType(dsPage.Tables(0).Rows(0).Item(1).ToString, Date).ToShortDateString
                PageDateLabel.Visible = True
            Else
                PageDateLabel.Visible = False
            End If
            Me.AskToSaveImage = False
            ImagePanel.ResumeLayout()
            _CurrentAngle = 0
            'SIMR Function
            loadSIMRValues(vehicleId, pageNumber)
        End Sub

        Protected Overrides Sub OnFindPage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            If String.IsNullOrEmpty(ImageDisplay.ImageLocation.ToString) = False Then
                _filePath = ImageDisplay.ImageLocation.ToString
            End If

            If Me.AskToSaveImage Then
                Dim userResponse As System.Windows.Forms.DialogResult

                userResponse = PromptToSaveImage(_filePath)
                Select Case userResponse
                    Case Windows.Forms.DialogResult.Yes 'Image is saved successfully.
                    Case Windows.Forms.DialogResult.No  'User don't want to save image changes.
                    Case Windows.Forms.DialogResult.Ignore  'User want to ignore unsaved changes made to image.
                    Case Windows.Forms.DialogResult.Abort 'User want to abort navigation.
                        Exit Sub
                End Select
            End If

            ShowImage(vehicleId, pageNumber)

            currentPageLabel.Text = pageNumber.ToString()
            pageSizeLabel.Text = GetPageSizeText(vehicleId, pageNumber)
            Dim dsPage As DataSet = GetPageStartEndDt(vehicleId, pageNumber)
            If dsPage.Tables(0).Rows.Count > 0 And String.IsNullOrEmpty(dsPage.Tables(0).Rows(0).Item(0).ToString) = False _
            And String.IsNullOrEmpty(dsPage.Tables(0).Rows(0).Item(1).ToString) = False Then
                PageDateLabel.Text = CType(dsPage.Tables(0).Rows(0).Item(0), Date).ToShortDateString + " - " + CType(dsPage.Tables(0).Rows(0).Item(1).ToString, Date).ToShortDateString
                PageDateLabel.Visible = True
            Else
                PageDateLabel.Visible = False
            End If
            findImageTextBox.Text = String.Empty
            Me.AskToSaveImage = False
            _CurrentAngle = 0
        End Sub


        Protected Overrides Sub RefreshPageCropInformation()
            Dim pageNumber, totalPages As Integer


            totalPagesLabel.Text = Processor.Data.PageCrop.Count.ToString()

            If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
                pageNumber = -1
            End If

            If Integer.TryParse(totalPagesLabel.Text, totalPages) = False Then
                totalPages = -1
            End If

            firstImageButton.Enabled = (pageNumber > 1)
            previousImageButton.Enabled = (pageNumber > 1)
            nextImageButton.Enabled = (totalPages > pageNumber)
            lastImageButton.Enabled = (totalPages > pageNumber)

        End Sub

        ''' <summary>
        ''' Prepares path for cropped page image based on supplied arguments and loads cropped page image.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="pageCropId"></param>
        ''' <param name="pageNumber"></param>
        ''' <exception cref="System.ApplicationException">
        ''' If image file not found at prepared path, throws ApplicationException with message "Cropped page image not found."
        ''' </exception>
        ''' <remarks></remarks>
        Protected Sub ShowCroppedImage(ByVal vehicleId As Integer, ByVal pageCropId As Integer, ByVal pageNumber As Integer)
            Dim croppedImagePath As String


            croppedImagePath = Processor.GetCroppedPageImagePath(vehicleId, pageCropId)

            If System.IO.File.Exists(croppedImagePath) = False Then
                Throw New System.ApplicationException("Cropped ad image not found: " + Environment.NewLine + croppedImagePath)
            End If

            ShowImage(croppedImagePath)

            croppedImagePath = Nothing

        End Sub

        ''' <summary>
        ''' Loads rows from PageCrop table based on supplied vehicleId.
        ''' </summary>
        ''' <param name="vehicleId">PageCrop records for supplied vehicleId will be loaded.</param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnPageCropInformation(ByVal vehicleId As Integer)

            ClearAllInputs()
            Me.FormState = FormStateEnum.View

            Processor.LoadVehiclePageCropInformation(vehicleId)
            ShowVehicleInformation(Processor.Data.PageCrop(0).PageRow.vwCircularRow)
            ShowVehicleInformation(Processor.Data.PageCrop(0))

            Try
                ShowCroppedImage(vehicleId, Processor.Data.PageCrop(0).PageCropId, Nothing)
            Catch ex As ApplicationException
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            currentPageLabel.Text = "1"

        End Sub

        Protected Overrides Sub OnNavigateToFirstPageCrop(ByVal vehicleId As Integer)
            Dim tempRow As QCDataSet.PageCropRow


            If Processor.Data.PageCrop.Count = 0 Then
                MessageBox.Show("There is no cropped image information available for Vehicle " _
                                + vehicleId.ToString() + ".", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            tempRow = Processor.Data.PageCrop(0)
            ShowVehicleInformation(tempRow)

            Try
                ShowCroppedImage(vehicleId, tempRow.PageCropId, tempRow.PageRow.ReceivedOrder)
            Catch ex As Exception
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            currentPageLabel.Text = "1"

            tempRow = Nothing

        End Sub

        Protected Overrides Sub OnNavigateToPreviousPageCrop(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            Dim tempRow As QCDataSet.PageCropRow


            If Processor.Data.PageCrop.Count = 0 Then
                MessageBox.Show("There is no cropped image information available for Vehicle " _
                                + vehicleId.ToString() + ".", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            tempRow = Processor.Data.PageCrop(pageNumber - 1)
            ShowVehicleInformation(tempRow)

            Try
                ShowCroppedImage(vehicleId, tempRow.PageCropId, tempRow.PageRow.ReceivedOrder)
            Catch ex As Exception
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            currentPageLabel.Text = pageNumber.ToString()

            tempRow = Nothing

        End Sub

        Protected Overrides Sub OnNavigateToNextPageCrop(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            Dim tempRow As QCDataSet.PageCropRow


            If Processor.Data.PageCrop.Count = 0 Then
                MessageBox.Show("There is no cropped image information available for Vehicle " _
                                + vehicleId.ToString() + ".", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf Processor.Data.PageCrop.Count < pageNumber Then
                MessageBox.Show("This is the last cropped page image information for Vehicle." _
                                + vehicleId.ToString() + ".", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            tempRow = Processor.Data.PageCrop(pageNumber - 1)
            ShowVehicleInformation(tempRow)

            Try
                ShowCroppedImage(vehicleId, tempRow.PageCropId, tempRow.PageRow.ReceivedOrder)
            Catch ex As ApplicationException
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            currentPageLabel.Text = pageNumber.ToString()

            tempRow = Nothing

        End Sub

        Protected Overrides Sub OnNavigateToLastPageCrop(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            Dim tempRow As QCDataSet.PageCropRow


            If Processor.Data.PageCrop.Count = 0 Then
                MessageBox.Show("There is no cropped image information available for vehicle " _
                                + vehicleId.ToString() + ".", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf Processor.Data.PageCrop.Count < pageNumber Then
                MessageBox.Show("This is the last cropped page image information for vehicle." _
                                + vehicleId.ToString() + ".", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            tempRow = Processor.Data.PageCrop(pageNumber - 1)
            ShowVehicleInformation(tempRow)

            Try
                ShowCroppedImage(vehicleId, tempRow.PageCropId, tempRow.PageRow.ReceivedOrder)
            Catch ex As Exception
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            currentPageLabel.Text = pageNumber.ToString()

            tempRow = Nothing

        End Sub

        Protected Overrides Sub OnFindCroppedPage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            Dim tempRow As QCDataSet.PageCropRow


            tempRow = Processor.Data.PageCrop(pageNumber - 1)
            ShowVehicleInformation(tempRow)

            Try
                ShowCroppedImage(vehicleId, tempRow.PageCropId, tempRow.PageRow.ReceivedOrder)
            Catch ex As Exception
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            currentPageLabel.Text = pageNumber.ToString()
            findImageTextBox.Text = String.Empty

            tempRow = Nothing

        End Sub

#Region "Rotation by User Input Angle"
        ''' <summary>
        ''' Function for rotating an imagr by a specified rotation angle
        ''' </summary>
        ''' <param name="bmp">The image we're rotating</param>
        ''' <param name="angle">The angle to rotate it by</param>
        ''' <returns>The rotated image</returns>
        Private Function RotateImage(ByVal image As Image, ByVal angle As Single) As Bitmap
            Try

                If image Is Nothing Then
                    Throw New ArgumentNullException("image")
                End If

                Const pi2 As Double = Math.PI / 2.0


                Dim oldWidth As Double = CDbl(image.Width)
                Dim oldHeight As Double = CDbl(image.Height)


                Dim theta As Double = CDbl(angle) * Math.PI / 180.0
                Dim locked_theta As Double = theta


                While locked_theta < 0.0
                    locked_theta += 2 * Math.PI
                End While

                Dim newWidth As Double, newHeight As Double
                Dim nWidth As Integer, nHeight As Integer

                Dim adjacentTop As Double, oppositeTop As Double
                Dim adjacentBottom As Double, oppositeBottom As Double

                If (locked_theta >= 0.0 AndAlso locked_theta < pi2) OrElse (locked_theta >= Math.PI AndAlso locked_theta < (Math.PI + pi2)) Then
                    adjacentTop = Math.Abs(Math.Cos(locked_theta)) * oldWidth
                    oppositeTop = Math.Abs(Math.Sin(locked_theta)) * oldWidth

                    adjacentBottom = Math.Abs(Math.Cos(locked_theta)) * oldHeight
                    oppositeBottom = Math.Abs(Math.Sin(locked_theta)) * oldHeight
                Else
                    adjacentTop = Math.Abs(Math.Sin(locked_theta)) * oldHeight
                    oppositeTop = Math.Abs(Math.Cos(locked_theta)) * oldHeight

                    adjacentBottom = Math.Abs(Math.Sin(locked_theta)) * oldWidth
                    oppositeBottom = Math.Abs(Math.Cos(locked_theta)) * oldWidth
                End If

                newWidth = adjacentTop + oppositeBottom
                newHeight = adjacentBottom + oppositeTop

                nWidth = CInt(Math.Truncate(Math.Ceiling(newWidth)))
                nHeight = CInt(Math.Truncate(Math.Ceiling(newHeight)))

                Dim rotatedBmp As New Bitmap(nWidth, nHeight)

                Dim grpc As Graphics = Graphics.FromImage(rotatedBmp)

                Dim points As Point()

                If locked_theta >= 0.0 AndAlso locked_theta < pi2 Then

                    points = New Point() {New Point(CInt(Math.Truncate(oppositeBottom)), 0), New Point(nWidth, CInt(Math.Truncate(oppositeTop))), New Point(0, CInt(Math.Truncate(adjacentBottom)))}
                ElseIf locked_theta >= pi2 AndAlso locked_theta < Math.PI Then
                    points = New Point() {New Point(nWidth, CInt(Math.Truncate(oppositeTop))), New Point(CInt(Math.Truncate(adjacentTop)), nHeight), New Point(CInt(Math.Truncate(oppositeBottom)), 0)}
                ElseIf locked_theta >= Math.PI AndAlso locked_theta < (Math.PI + pi2) Then
                    points = New Point() {New Point(CInt(Math.Truncate(adjacentTop)), nHeight), New Point(0, CInt(Math.Truncate(adjacentBottom))), New Point(nWidth, CInt(Math.Truncate(oppositeTop)))}
                Else
                    points = New Point() {New Point(0, CInt(Math.Truncate(adjacentBottom))), New Point(CInt(Math.Truncate(oppositeBottom)), 0), New Point(CInt(Math.Truncate(adjacentTop)), nHeight)}
                End If

                grpc.DrawImage(image, points)

                Return rotatedBmp
                rotatedBmp.Dispose()
                image.Dispose()
                grpc.Dispose()



            Catch om As OutOfMemoryException

            Catch ex As Exception

            End Try
        End Function
#End Region

        Protected Overrides Sub OnRotateAt90()

            Dim statusMsg As MCAP.UI.Controls.StatusMessageForm = New MCAP.UI.Controls.StatusMessageForm()
            statusMsg.MessageText = "Rotating image at 90 degree."
            statusMsg.Show(Me)
            statusMsg.Refresh()
            Try
                If blnImageRotationChange = False Then
                    intImageRotationCount = intImageRotationCount + 1
                    blnImageRotationChange = True
                    Me.StatusMessage = "r90"
                End If

                ImageDisplay.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
                OutputPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
                ImageDisplay.Image = ImageDisplay.Image
                OutputPictureBox.Image = OutputPictureBox.Image

            Catch ex As System.ApplicationException
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Unknown error has occurred while rotating and saving rotated image.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            statusMsg.Close()
            statusMsg.Dispose()
            statusMsg = Nothing

            Me.AskToSaveImage = True

        End Sub

        Protected Overrides Sub OnRotatePagesAt180()

            Dim statusMsg As MCAP.UI.Controls.StatusMessageForm = New MCAP.UI.Controls.StatusMessageForm()
            statusMsg.MessageText = "Rotating image at 180 degree."
            statusMsg.Show(Me)
            statusMsg.Refresh()
            Try
                If blnImageRotationChange = False Then
                    intImageRotationCount = intImageRotationCount + 1
                    blnImageRotationChange = True
                    Me.StatusMessage = "r180"
                End If

                ImageDisplay.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
                OutputPictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
                ImageDisplay.Image = ImageDisplay.Image
                OutputPictureBox.Image = OutputPictureBox.Image

            Catch ex As System.ApplicationException
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Unknown error has occurred while rotating and saving rotated image.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            statusMsg.Close()
            statusMsg.Dispose()
            statusMsg = Nothing

            Me.AskToSaveImage = True

        End Sub

        Protected Overrides Sub OnRotatePagesAt270()

            Dim statusMsg As MCAP.UI.Controls.StatusMessageForm = New MCAP.UI.Controls.StatusMessageForm()
            statusMsg.MessageText = "Rotating image at 270 degree."
            statusMsg.Show(Me)
            statusMsg.Refresh()
            Try
                If blnImageRotationChange = False Then
                    intImageRotationCount = intImageRotationCount + 1
                    blnImageRotationChange = True
                    Me.StatusMessage = "r270"
                End If
                ImageDisplay.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
                OutputPictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
                ImageDisplay.Image = ImageDisplay.Image
                OutputPictureBox.Image = OutputPictureBox.Image
            Catch ex As System.ApplicationException
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Unknown error has occurred while rotating and saving rotated image.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            statusMsg.Close()
            statusMsg.Dispose()
            statusMsg = Nothing

            Me.AskToSaveImage = True

        End Sub

        Protected Overrides Function OnRotatePageAnticlockWise(ByVal rotationCounter As Integer) As Integer
            rotationCounter = -rotationCounter
            If _CurrentAngle > 0 Then
                rotationCounter = _CurrentAngle - 1
            End If

            _CurrentAngle = rotationCounter

            If blnImageRotationChange = False Then
                intImageRotationCount = intImageRotationCount + 1
                blnImageRotationChange = True
                Me.StatusMessage = "racw"
            End If

            lblisRotatedBy.Text = "true"

            _filePath = ImageDisplay.ImageLocation.ToString
            Dim bt As Bitmap = New Bitmap(_filePath)
            Dim bmp As Bitmap = New Bitmap(bt.Width, bt.Height)

            bmp = RotateImage(bt, CSng(rotationCounter / 15))
            OutputPictureBox.Image = bmp
            ImageDisplay.Image = bmp
            ImageDisplay.Image = AdjustImageToRetainRatio()

            bt.Dispose()
            _filePath = Nothing
            Me.AskToSaveImage = True

            Return _CurrentAngle
        End Function

        Protected Overrides Function OnRotatePageClockWise(ByVal rotationCounter As Integer) As Integer
            If _CurrentAngle < 0 Then
                rotationCounter = -((_CurrentAngle * -1) - 1)

            End If

            _CurrentAngle = rotationCounter


            If blnImageRotationChange = False Then
                intImageRotationCount = intImageRotationCount + 1
                blnImageRotationChange = True
                Me.StatusMessage = "racw"
            End If

            lblisRotatedBy.Text = "true"

            _filePath = ImageDisplay.ImageLocation.ToString
            Dim bt As Bitmap = New Bitmap(_filePath)
            Dim bmp As Bitmap = New Bitmap(bt.Width, bt.Height)
            'adjust here for rotation /15
            bmp = RotateImage(bt, CSng(rotationCounter / 15))
            OutputPictureBox.Image = bmp
            ImageDisplay.Image = bmp
            ImageDisplay.Image = AdjustImageToRetainRatio()

            bt.Dispose()
            _filePath = Nothing

            Me.AskToSaveImage = True
            Return _CurrentAngle
        End Function

        Private Function AdjustImageToRetainRatio() As Bitmap
            Dim _GenImage As Bitmap
            Dim ScaleInt As Integer
            Dim widthRatio As Double
            Dim heightRatio As Double

            If ImageDisplay.Width < ImagePanel.Width _
              AndAlso ImageDisplay.Height < ImagePanel.Height AndAlso IsZoomedIn = False Then

                heightRatio = OutputPictureBox.Height / ImagePanel.Height
                ScaleInt = CType((100 / heightRatio) - 0.5, Integer)
            Else
                widthRatio = OutputPictureBox.Width / ImagePanel.Width
                heightRatio = OutputPictureBox.Height / ImagePanel.Height


                If widthRatio > heightRatio Then
                    ScaleInt = CType((100 / widthRatio) - 0.5, Integer)
                Else
                    ScaleInt = CType((100 / heightRatio) - 0.5, Integer)
                End If
            End If


            _GenImage = ZoomImage(OutputPictureBox.Image, ScaleInt)

            Return _GenImage
        End Function

        Protected Overrides Sub OnRotateAllPages(ByVal rotationAngle As Integer)
            Dim imageCounter, vehicleId As Integer
            Dim userResponse As Windows.Forms.DialogResult
            Dim currentImageFilePath As String
            Dim imageFilePath As String



            If Me.AskToSaveImage Then
                userResponse = MessageBox.Show("Do you want to save changes made to image file?" _
                                               , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If userResponse = DialogResult.Yes Then
                    SaveImage(ImageDisplay.Image, ImageDisplay.ImageLocation.ToString)
                End If
                Me.AskToSaveImage = False
            End If



            vehicleId = CType(vehicleIdValueLabel.Text, Integer)


            For imageCounter = 1 To Processor.Data.Page.Count
                imageFilePath = Processor.GetPageImageFilePath(vehicleId, imageCounter _
                                                             , Processors.VehicleImageSizeEnum.Unsized)
                Dim bt As Bitmap = New Bitmap(imageFilePath)
                Dim pc As New PictureBox

                pc.Image = bt

                If rotationAngle = 9000 Then
                    pc.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
                ElseIf rotationAngle = 18000 Then
                    pc.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
                End If
                SaveImage(pc.Image, imageFilePath)

                imageFilePath = Nothing
            Next
            currentImageFilePath = ImageDisplay.ImageLocation.ToString
            If blnImageRotationChange = False Then
                intImageRotationCount = intImageRotationCount + 1
                blnImageRotationChange = True
                Me.StatusMessage = "raall"
            End If

            ShowImage(currentImageFilePath)
            Me.AskToSaveImage = False

        End Sub



        Protected Overrides Sub OnRotatePageBy(ByVal rotationAngle As Integer, ByVal isAccepted As Boolean)
            Dim userResponse As Windows.Forms.DialogResult
            Try
                If Me.AskToSaveImage Then
                    userResponse = MessageBox.Show("Do you want to save changes made to image file?" _
                                                   , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If userResponse = DialogResult.Yes Then
                        SaveImage(ImageDisplay.Image, ImageDisplay.ImageLocation.ToString)
                    End If
                    Me.AskToSaveImage = False
                End If

                Dim bt As Bitmap = New Bitmap(ImageDisplay.Image)
                _filePath = ImageDisplay.ImageLocation.ToString
                If isAccepted Then
                    temp_img = RotateImage(bt, rotationAngle)
                    ImageDisplay.Image = temp_img
                    OutputPictureBox.Image = RotateImage(OutputPictureBox.Image, rotationAngle)
                Else
                    AfterPictureBox.Image = RotateImage(OutputPictureBox.Image, rotationAngle)
                End If

                If blnImageRotationChange = False Then
                    intImageRotationCount = intImageRotationCount + 1
                    blnImageRotationChange = True
                    Me.StatusMessage = "raall"
                End If
            Catch om As OutOfMemoryException
            End Try
        End Sub


        Protected Overrides Sub OnPageImageCrop(ByVal img As Image, ByVal xAxis As Integer, ByVal yAxis As Integer, ByVal xWidth As Integer, ByVal xHeight As Integer)
            Dim MyRect As Rectangle
            Dim _output As Bitmap = New Bitmap(xWidth, xHeight)
            MyRect = New Rectangle(xAxis, yAxis, xWidth, xHeight)
            MyGraphics = Graphics.FromImage(_output)
            MyGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic
            MyGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality
            MyGraphics.CompositingQuality = CompositingQuality.GammaCorrected
            MyGraphics.DrawImage(img, 0, 0, MyRect, GraphicsUnit.Pixel)
            ImageDisplay.Image = _output


            ' ************************** Omar ******************************
            ' Add keep count here based on info that keep is basically crop.
            ' **************************************************************
            intKeepRectangleCount = intKeepRectangleCount + 1
            Me.StatusMessage = "recrp1"


            Me.AskToSaveImage = True
            isPageCropped = True

        End Sub

        Protected Overrides Sub OnPageImageCrop_Original(ByVal img As Image, ByVal xAxis As Integer, ByVal yAxis As Integer, ByVal xWidth As Integer, ByVal xHeight As Integer)
            Dim MyRect As Rectangle
            Dim _output As Bitmap = New Bitmap(xWidth, xHeight)
            MyRect = New Rectangle(xAxis, yAxis, xWidth, xHeight)
            MyGraphics = Graphics.FromImage(_output)
            MyGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic
            MyGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality
            MyGraphics.CompositingQuality = CompositingQuality.GammaCorrected
            MyGraphics.DrawImage(img, 0, 0, MyRect, GraphicsUnit.Pixel)
            OutputPictureBox.Image = _output
            If ImageDisplay.Image IsNot Nothing Then ImageDisplay.Image.Dispose()
            ImageDisplay.Image = AdjustImageToRetainRatio()

            ' ************************** Omar ******************************
            ' Add keep count here based on info that keep is basically crop.
            ' **************************************************************
            intKeepRectangleCount = intKeepRectangleCount + 1
            Me.StatusMessage = "recrp1"


            Me.AskToSaveImage = True

        End Sub

        Protected Overrides Sub OnPageImageClearSelection(ByVal img As Image, ByVal xAxis As Integer, ByVal yAxis As Integer, ByVal xWidth As Integer, ByVal xHeight As Integer)

            MyRect = New Rectangle(xAxis, yAxis, xWidth, xHeight)
            MyGraphics = Graphics.FromImage(img)
            MyGraphics.FillRectangle(Brushes.White, MyRect)
            ImageDisplay.Image = ImageDisplay.Image

            ' Remove Code
            'omar capture removal of Rectangle and storage of count to image log table
            intRemoveRectangleCount = intRemoveRectangleCount + 1
            blnRemoveRectangleChange = True
            Me.StatusMessage = "rem"
            Me.AskToSaveImage = True

        End Sub

        Protected Overrides Sub OnPageImageClearSelection_Original(ByVal img As Image, ByVal xAxis As Integer, ByVal yAxis As Integer, ByVal xWidth As Integer, ByVal xHeight As Integer)

            MyRect = New Rectangle(xAxis, yAxis, xWidth, xHeight)
            MyGraphics = Graphics.FromImage(img)
            MyGraphics.FillRectangle(Brushes.White, MyRect)
            OutputPictureBox.Image = img

            ' Remove Code
            'omar capture removal of Rectangle and storage of count to image log table
            intRemoveRectangleCount = intRemoveRectangleCount + 1
            blnRemoveRectangleChange = True
            Me.StatusMessage = "rem"
            Me.AskToSaveImage = True

        End Sub

        'Protected Overrides Sub OnPageImageSave()
        '    Dim _temp As Bitmap = New Bitmap(OutputPictureBox.Image)
        '    If IsRotationLabel.Text = "false" Then
        '        SaveImage(_temp, ImageDisplay.ImageLocation)
        '    Else
        '        _temp.Save(ImageDisplay.ImageLocation)
        '    End If
        '    Me.AskToSaveImage = False
        '    isRotationLabel.Text = "false"
        'End Sub

        Protected Overrides Sub OnPageImageSave()
            Dim _temp As Bitmap = New Bitmap(OutputPictureBox.Image, OutputPictureBox.Width, OutputPictureBox.Height)
            Dim RemotePath As String = Processor.GetPageImageFolderPath(CInt(vehicleIdValueLabel.Text))
            Dim FileToSave As String = IO.Path.GetFileName(ImageDisplay.ImageLocation)
            Dim RemoteFilePath As String = RemotePath + "\" + FileToSave

            If isRotationLabel.Text = "false" Then
                If AllowCacheImage = True Then
                    SaveImage(_temp, RemoteFilePath)
                End If
                SaveImage(_temp, ImageDisplay.ImageLocation)
            Else
                If AllowCacheImage = True Then
                    _temp.Save(RemoteFilePath)
                End If
                _temp.Save(ImageDisplay.ImageLocation)
            End If
            isRotationLabel.Text = "false"
            Me.AskToSaveImage = False
            _CurrentAngle = 0
        End Sub
        ''' <summary>
        ''' Reloads vehicle information and Page image. Useed mainly to reload main image and vehicle information
        ''' to undo last image manipulation.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnRefreshVehicleInformation(ByVal vehicleId As Integer)
            Dim pageNumber As Integer


            If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
                pageNumber = -1
            End If

            'Me.FormState = FormStateEnum.View
            OnFindVehicle(vehicleId, EventInitiatorEnum.RefreshButton)
            RefreshPageInformation()

            If pageNumber > 0 Then
                OnFindPage(vehicleId, pageNumber)
                RefreshPageInformation()
            End If

            'On this form, user can create page crop record only when it is FSI.
            If Me.FormState = FormStateEnum.Insert Then
                Me.FormState = FormStateEnum.Insert
                ClearInputs(True, False, False)
                EnableDisableControls(Me.FormState)
            End If

        End Sub

        Protected Overrides Sub OnPageImageDelete(ByVal currentPage As Integer, ByVal totalPages As Integer)
            Dim filePath As String

            filePath = ImageDisplay.ImageLocation.ToString
            If System.IO.File.Exists(filePath) = False Then
                MessageBox.Show("Unable to find image file.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                Dim userResponse As DialogResult

                userResponse = MessageBox.Show("Are you sure, you want to remove page image for page " _
                                               + currentPage.ToString() + " of " + totalPages.ToString() _
                                               + " located at " + filePath, ProductName _
                                               , MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                               , MessageBoxDefaultButton.Button2)
                If userResponse = Windows.Forms.DialogResult.No Then Exit Sub
            End If

            Me.AskToSaveImage = False
            System.IO.File.Delete(filePath)



        End Sub

        Protected Overrides Sub OnResequencePageImages(ByVal vehicleId As Integer)
            Dim userResponse As DialogResult
            Dim resequencedImages() As String
            Dim resequenceScr As ResequenceForm
            Dim ImageFolderPath As String


            resequenceScr = New ResequenceForm

            resequenceScr.Init(FormStateEnum.View)
            resequenceScr.ApplyUserCredentials()
            If AllowCacheImage = True Then
                ImageFolderPath = System.IO.Path.GetDirectoryName(ImageDisplay.ImageLocation.ToString)
                resequenceScr.PageImageFolderPath = ImageFolderPath
                resequenceScr.IsAllowedCache = AllowCacheImage
                resequenceScr.RemoteImagePath = Processor.GetPageImageFolderPath(vehicleId)
            Else
                resequenceScr.PageImageFolderPath = Processor.GetPageImageFolderPath(vehicleId)
            End If
            resequenceScr.InReQC = m_inReQC
            resequenceScr.LoadPageInformation(vehicleId)
            resequenceScr.m_VehicleId = vehicleId

            userResponse = resequenceScr.ShowDialog(Me)

            ' Response from resequence 
            If userResponse = Windows.Forms.DialogResult.OK Then
                ' display data
                Processor.LoadVehiclePagesInformation(vehicleId)
            End If

            If Processor.Data.Page.Count > 0 Then OnNavigateToFirstImage(vehicleId)

            intResequenceCount = intResequenceCount + 1
            blnResequenceChange = True
            Me.StatusMessage = "reseq"

            resequenceScr.Dispose()
            resequenceScr = Nothing
            resequencedImages = Nothing

        End Sub

        Protected Overrides Sub OnRetailerChanged(ByVal retailerId As Integer, ByVal tradeclassId As Integer, ByVal tradeclass As String)
            Dim showFlashCheckBox As Boolean
            Dim mediaId, marketId As Integer


            If mediaComboBox.SelectedValue Is Nothing OrElse mediaComboBox.SelectedValue Is DBNull.Value Then
                mediaId = -1
            ElseIf Integer.TryParse(mediaComboBox.SelectedValue.ToString(), mediaId) = False Then
                mediaId = -1
            End If

            If marketComboBox.SelectedValue Is Nothing OrElse marketComboBox.SelectedValue Is DBNull.Value Then
                marketId = -1
            ElseIf Integer.TryParse(marketComboBox.SelectedValue.ToString(), marketId) = False Then
                marketId = -1
            End If

            If retailerId < 1 Then
                detailEntryOptionGroupBox.Enabled = False
            Else
                flagForDetailEntryCheckBox.Checked = False
                parentVehicleIdTextBox.Clear()
                If Me.Processor.IsTradeclassMarkedForLimitedEntry(retailerId) Then
                    detailEntryOptionGroupBox.Enabled = True
                Else
                    detailEntryOptionGroupBox.Enabled = False
                End If
            End If

            priorityValueLabel.Text = Processor.GetExpectationPriority(mediaId, marketId, retailerId)
            CoverageValueLabel.Text = Processor.GetCoverage(marketId, retailerId)

            showFlashCheckBox = IsRetailerValidForPageCropFR()
            If showFlashCheckBox = False Then flashAdCheckBox.Checked = False
            flashAdCheckBox.Enabled = showFlashCheckBox

            If tradeclass.Trim() = "FSI" Then Me.m_IsFSI = True 'Now onwards, Tradeclass=FSI is to be treated as Media=FSI

        End Sub

        Protected Overrides Sub OnRetailerValidated()

            If Me.IsFSI Then flashAdCheckBox.Focus()

        End Sub

        Protected Overrides Sub OnExitClicked()
            Me.m_formAlrdyOpened = False
            isClosedByButton = True
            Me.Close()

        End Sub

        Private Function Sharpen(ByVal ImageToSharpen As Bitmap) As Bitmap

            Dim fpixel, secpixel As Color
            Dim NewImg As Bitmap = New Bitmap(ImageToSharpen)
            Dim CR, CB, CG As Integer
            Dim x, y As Integer

            For x = 0 To NewImg.Width - 2
                For y = 0 To NewImg.Height - 2
                    fpixel = NewImg.GetPixel(x, y)
                    secpixel = NewImg.GetPixel(x + 1, y)
                    Dim newR, newB, newG As Integer
                    newR = CInt(fpixel.R) - CInt(secpixel.R)
                    newB = CInt(fpixel.B) - CInt(secpixel.B)
                    newG = CInt(fpixel.G) - CInt(secpixel.G)
                    Dim strength As Double = -1.4
                    CR = (CInt(newR * strength) + fpixel.R)
                    CG = (CInt(newG * strength) + fpixel.G)
                    CB = (CInt(newB * strength) + fpixel.B)

                    If CR > 255 Then
                        CR = 255
                    End If
                    If CR < 0 Then
                        CR = 0

                    End If
                    If CB > 255 Then
                        CB = 255
                    End If
                    If CB < 0 Then
                        CB = 0
                    End If

                    If CG > 255 Then
                        CG = 255
                    End If

                    If CG < 0 Then
                        CG = 0
                    End If

                    NewImg.SetPixel(x, y, Color.FromArgb(CR, CG, CB))
                    NewImg.SetResolution(297500, 87500)
                Next
            Next

            Return NewImg
        End Function

        Private Sub flashAdCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles flashAdCheckBox.CheckedChanged
            Dim retailerId As Integer

            If retailerComboBox.SelectedValue Is Nothing Then
                retailerId = -1
            Else
                retailerId = CType(retailerComboBox.SelectedValue, Integer)
            End If

            nationalCheckBox.Enabled = flashAdCheckBox.Checked AndAlso (Me.IsPageCropNavigation = False) And Processor.IsValidFlashNational(retailerId)
            If flashAdCheckBox.Checked = False Then nationalCheckBox.Checked = False

        End Sub

        Private Sub flagForDetailEntryCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles flagForDetailEntryCheckBox.CheckedChanged

            If flagForDetailEntryCheckBox.Checked Then
                parentVehicleIdTextBox.Clear()
                parentVehicleIdTextBox.Enabled = False
            Else
                parentVehicleIdTextBox.Enabled = True
            End If

        End Sub

        Private Sub parentVehicleIdTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles parentVehicleIdTextBox.KeyPress

            If Not (Char.IsDigit(e.KeyChar) _
              OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 8 _
              OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 22) _
            Then
                e.Handled = True
            End If

        End Sub

        Private Sub familyButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles viewFamilyButton.Click
            Dim vehicleId As Integer
            Dim viewFamily As UI.FamilyViewForm


            If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
                vehicleId = 0
            End If

            If vehicleId < 1 Then
                MessageBox.Show("Load vehicle to see it's family.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            viewFamily = New UI.FamilyViewForm()
            viewFamily.Init(FormStateEnum.View)
            viewFamily.ApplyUserCredentials()
            viewFamily.Show()
            viewFamily.Hide()
            viewFamily.vehicleIdTextBox.Text = vehicleId.ToString()
            viewFamily.LoadVehicles()
            'viewFamily.loadVehicle(vehicleId)
            viewFamily.ShowDialog(Me)

            viewFamily.Dispose()
            viewFamily = Nothing

        End Sub

        Private Sub QCForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If e.CloseReason = CloseReason.UserClosing And isClosedByButton = False Then
                If (MessageBox.Show("Are you sure you want to close this form?", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                    e.Cancel = True
                End If
            End If
        End Sub

        Private Sub QCForm_FormInitialized() Handles Me.FormInitialized

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub QCForm_InitializingForm() Handles Me.InitializingForm

            Me.StatusMessage = "Loading information. This may take some time. Please wait..."

        End Sub



        Private Sub m_Processor_BarcodePrinted(ByVal sender As Object, ByVal e As MCAP.UI.Processors.EventArgs) Handles m_Processor.BarcodePrinted

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_DataLoaded() Handles m_Processor.DataLoaded

            Me.StatusMessage = String.Empty

        End Sub


        Private Sub m_Processor_FamilyThumbnailPagesInformationLoaded() Handles m_Processor.FamilyThumbnailPagesInformationLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_InvalidVehicleStatus(ByVal statusText As String) Handles m_Processor.InvalidVehicleStatus

            Me.StatusMessage = String.Empty

            Me.FormState = FormStateEnum.View

            Processor.Data.PageCrop.Rows.Clear()
            Processor.Data.Page.Rows.Clear()
            If Me.IsPageCropNavigation Then
                RefreshPageCropInformation()
            Else
                RefreshPageInformation()
            End If

            ClearAllInputs()
            RemoveAllErrorProviders()
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

            Me.IsPageCropNavigation = False
            vehiclePageCropButton.Text = "Vehicle"

            MessageBox.Show("Vehicle cannot be loaded because it has the Status of: " + statusText, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.findVehicleIdTextBox.Focus()
            Me.findVehicleIdTextBox.SelectAll()

        End Sub

        Private Sub m_Processor_LoadingData() Handles m_Processor.LoadingData

            Me.StatusMessage = "Loading initial information from database. This may take some time. Please wait..."

        End Sub

        Private Sub m_Processor_LoadingFamilyThumbnailPagesInformation() Handles m_Processor.LoadingFamilyThumbnailPagesInformation

            Me.StatusMessage = "Loading Family thumbnail pages information..."

        End Sub

        Private Sub m_Processor_LoadingMarkets() Handles m_Processor.LoadingMarkets

            Me.StatusMessage = "Loading Market information..."

        End Sub

        Private Sub m_Processor_LoadingPublications() Handles m_Processor.LoadingPublications

            Me.StatusMessage = "Loading Publication information..."

        End Sub

        Private Sub m_Processor_LoadingRetailers() Handles m_Processor.LoadingRetailers

            Me.StatusMessage = "Loading Retailer information..."

        End Sub

        Private Sub m_Processor_LoadingVehicle(ByVal vehicleId As Integer) Handles m_Processor.LoadingVehicle

            Me.StatusMessage = "Loading Vehicle information..."

        End Sub

        Private Sub m_Processor_LoadingVehiclePageCropInformation() Handles m_Processor.LoadingVehiclePageCropInformation

            Me.StatusMessage = "Loading cropped pages information. This may take some time. Please wait..."

        End Sub

        Private Sub m_Processor_LoadingVehiclePagesInformation() Handles m_Processor.LoadingVehiclePagesInformation

            Me.StatusMessage = "Loading Vehicle pages information..."

        End Sub

        Private Sub m_Processor_MarketsLoaded() Handles m_Processor.MarketsLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_PageCropInformationSynchronized() Handles m_Processor.PageCropInformationSynchronized

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_PageInformationSynchronized() Handles m_Processor.PageInformationSynchronized

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_PrintingBarcode(ByVal sender As Object, ByVal e As MCAP.UI.Processors.CancellableEventArgs) Handles m_Processor.PrintingBarcode

            Me.StatusMessage = "Printing barcode label..."

        End Sub

        Private Sub m_Processor_PublicationsLoaded() Handles m_Processor.PublicationsLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_RetailersLoaded() Handles m_Processor.RetailersLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_SynchronizingPageCropInformation() Handles m_Processor.SynchronizingPageCropInformation

            Me.StatusMessage = "Synchronizing cropped page image information."

        End Sub

        Private Sub m_Processor_SynchronizingPageInformation() Handles m_Processor.SynchronizingPageInformation

            Me.StatusMessage = "Synchronizing page information with database..."

        End Sub

        Private Sub m_Processor_SynchronizingVehicle() Handles m_Processor.SynchronizingVehicleInformation

            Me.StatusMessage = "Synchronizing vehicle information with database..."

        End Sub

        Private Sub m_Processor_VehicleLoaded(ByVal vehicleRow As QCDataSet.vwCircularRow, ByVal isVehicleQCed As Boolean, ByVal isParentVehicleQCed As Boolean) Handles m_Processor.VehicleLoaded
            Dim isFamilyRequired As Boolean ', renameImages As Boolean = True
            Dim vehicleId As Integer
            Dim imageFolder As String
            Dim testStatus As String

            AllowCacheImage = CBool(Processor.IsAllowCacheImagesUser)

            vehicleId = vehicleRow.VehicleId

            If vehicleRow.IsParentVehicleIdNull() = False AndAlso isParentVehicleQCed AndAlso isVehicleQCed = False Then
                Dim userResponse As DialogResult

                userResponse = MessageBox.Show(Me, "Do you want to copy images from the Parent Vehicle " + vehicleRow.ParentVehicleId.ToString() + " ?" _
                                               , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If userResponse = Windows.Forms.DialogResult.Yes Then
                    Dim parentPageCount, childPageCount As Integer

                    parentPageCount = Me.Processor.GetPageCount(vehicleRow.ParentVehicleId)
                    childPageCount = Me.Processor.GetPageCount(vehicleRow.VehicleId)
                    If parentPageCount <> childPageCount Then
                        Me.StatusMessage = String.Empty
                        MessageBox.Show(Me, String.Format("Page count of child vehicle {0} is different from Parent {1}. Can not copy page images and can not" _
                                                          + " load child vehicle {0}.", vehicleRow.VehicleId, vehicleRow.ParentVehicleId) _
                                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        Me.StatusMessage = "Copying page images from parent vehicle. Please wait..."
                        Processor.CopyPageImages(vehicleRow.ParentVehicleId, vehicleRow.VehicleId, True)
                    End If
                End If
            End If

            ''This is done to avoid renaming of vehicle images when page crop button is clicked.
            ''Whenever page crop button is clicked, this event is raised to load vehicle information.
            ''ASSUMPTION: 
            ''While viewing page crop records, user will not load same vehicle using refresh or load button.
            'If vehiclePageCropButton.Text.ToUpper() = "PAGE CROP" _
            '  AndAlso vehicleIdValueLabel.Text = vehicleId.ToString() _
            'Then
            '  renameImages = False
            'End If

            Me.StatusMessage = "Loading vehicle information. Please wait..."

            'Clear Cache Images
            If AllowCacheImage = True Then
                Processor.ClearLocalImageFolder(vehicleRow.VehicleId)
            End If

            ClearAllInputs()
            RemoveAllErrorProviders()
            Me.IsPageCropNavigation = False
            vehiclePageCropButton.Text = "Vehicle"

            ShowVehicleInformation(vehicleRow)

            Processor.LoadVehiclePagesInformation(vehicleId)
            If Processor.Data.Page.Count > 0 Then
                'Dim croppedImageCount As Integer = Processor.GetCroppedPageCount(vehicleId)

                If Me.FormState <> FormStateEnum.Remote Then
                    imageFolder = Processor.GetPageImageFolderPath(vehicleId)
                Else
                    imageFolder = Processor.GetPageImageFolderPath(vehicleId, True)
                End If
                'If renameImages AndAlso (croppedImageCount > 0) Then renameImages = False
                'If renameImages AndAlso vehicleRow.IsQCDtNull() AndAlso vehicleRow.IsQCedByIdNull() Then _
                '    ResequenceImageFilesName(imageFolder)
                ShowImage(imageFolder, 1)
                currentPageLabel.Text = "1"
                pageSizeLabel.Text = GetPageSizeText(vehicleId, 1)
                Dim dsPage As DataSet = GetPageStartEndDt(vehicleId, 1)
                If dsPage.Tables(0).Rows.Count > 0 And String.IsNullOrEmpty(dsPage.Tables(0).Rows(0).Item(0).ToString) = False _
                And String.IsNullOrEmpty(dsPage.Tables(0).Rows(0).Item(1).ToString) = False Then
                    PageDateLabel.Text = CType(dsPage.Tables(0).Rows(0).Item(0), Date).ToShortDateString + " - " + CType(dsPage.Tables(0).Rows(0).Item(1), Date).ToShortDateString
                    PageDateLabel.Visible = True
                Else
                    PageDateLabel.Visible = False
                End If
            End If
            If vehicleRow.RetRow IsNot Nothing Then
                isFamilyRequired = Processor.IsTradeclassRequireFamily(vehicleRow.RetRow.TradeClassId)
            End If


            ' UNCOMMENT
            If vehicleRow.IsFamilyIdNull() AndAlso isFamilyRequired Then
                Dim familyId As Integer

                MessageBox.Show("Please assign vehicle to a family or create a new family, in order to finish" _
                                + " QC process.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                familyId = ShowFamilyCreationScreen(vehicleRow)
                If familyId > 0 Then
                    vehicleRow.FamilyId = familyId
                    vehicleRow.FormName = FORM_NAME
                    Processor.SynchronizeVehicleInformation()
                End If
            End If

            If vehicleRow.RetRow IsNot Nothing Then
                ' Button is hidden if not Social
                testStatus = vehicleRow.MediaRow.Descrip.ToString()
            End If
            ' 
            If testStatus = "Social" Or testStatus = "Email" Or testStatus = "Website" Then
                notpromotionalButton.Visible = True
            Else
                notpromotionalButton.Visible = False
            End If
            If FormState <> FormStateEnum.Remote Then
                If vehicleRow.IsFamilyIdNull() = False Then
                    Processor.LoadPagesInformationForFamilyThumbnail(vehicleId, vehicleRow.FamilyId, 1)
                    ShowFamilyThumbnails()
                Else
                    dgThumbnails.Rows.Clear()
                End If
            End If

            vehicleRow = Nothing
            'Remove to accomodate editing website 
            m_IsMediaTypeWebsite = (mediaComboBox.Text.ToUpper() = "WEBSITE" Or mediaComboBox.Text.ToUpper() = "EMAIL" Or mediaComboBox.Text.ToUpper() = "SOCIAL")
            If mediaComboBox.Text.ToUpper() = "EMAIL" Then
                recaptureWebpageButton.Text = "Recreate Email"
            End If
            If mediaComboBox.Text.ToUpper() = "WEBSITE" Then
                recaptureWebpageButton.Text = "Recapture Current Webpage"
            End If


            ShowHideControls(Me.FormState)
            RefreshPageInformation()
            If Me.FormState <> FormStateEnum.Remote Then Me.FormState = FormStateEnum.View
            Me.AskToSaveImage = False

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_ParentVehicleNotQCed(ByVal vehicleId As Integer, ByVal parentVehicleId As Integer) Handles m_Processor.ParentVehicleNotQCed

            Me.StatusMessage = String.Empty

            Me.FormState = FormStateEnum.View

            Processor.Data.PageCrop.Rows.Clear()
            Processor.Data.Page.Rows.Clear()
            If Me.IsPageCropNavigation Then
                RefreshPageCropInformation()
            Else
                RefreshPageInformation()
            End If

            ClearAllInputs()
            RemoveAllErrorProviders()
            EnableDisableControls(Me.FormState)
            ShowHideControls(Me.FormState)

            Me.IsPageCropNavigation = False
            vehiclePageCropButton.Text = "Vehicle"

            MessageBox.Show(Me, "Parent Vehicle " + parentVehicleId.ToString() + " has not been QCed." _
                            , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.findVehicleIdTextBox.Focus()
            Me.findVehicleIdTextBox.SelectAll()

        End Sub

        Private Sub m_Processor_VehicleNotFound(ByVal vehicleId As Integer) Handles m_Processor.VehicleNotFound

            Me.StatusMessage = String.Empty

            Me.FormState = FormStateEnum.View

            Processor.Data.PageCrop.Rows.Clear()
            Processor.Data.Page.Rows.Clear()
            If Me.IsPageCropNavigation Then
                RefreshPageCropInformation()
            Else
                RefreshPageInformation()
            End If

            ClearAllInputs()
            RemoveAllErrorProviders()
            EnableDisableControls(Me.FormState)
            ShowHideControls(Me.FormState)

            Me.IsPageCropNavigation = False
            vehiclePageCropButton.Text = "Vehicle"

            MessageBox.Show("Vehicle " & CType(vehicleId, String) & " not found.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.findVehicleIdTextBox.Focus()
            Me.findVehicleIdTextBox.SelectAll()

        End Sub

        Private Sub m_Processor_VehiclePageCropInformationLoaded() Handles m_Processor.VehiclePageCropInformationLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_VehiclePagesInformationLoaded() Handles m_Processor.VehiclePagesInformationLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_VehicleSynchronized() Handles m_Processor.VehicleInformationSynchronized

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_SizeNotFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_Processor.SizeNotFound
            Dim width, height As Single


            If e.Data.Contains("Width") = False OrElse e.Data.Contains("Height") = False Then
                MessageBox.Show("Unable to determine width and height of the cropped image. Existing list of sizes does not contain cropped image size." + Environment.NewLine + "Please inform your entry administrator regarding this.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If Single.TryParse(e.Data("Width").ToString(), width) = False Then
                width = -1
            End If

            If Single.TryParse(e.Data("Height").ToString(), height) = False Then
                height = -1
            End If

            If width < 0 Or height < 0 Then
                MessageBox.Show("Existing list of sizes does not contain cropped image size." + Environment.NewLine + "Please inform your entry administrator regarding this.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Try
                Processor.CheckAndInsertSize(width, height)
                Processor.LoadSizes()
            Catch ex As System.Data.SqlClient.SqlException
                MessageBox.Show("Unable to create new size for cropped image.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Unable to create new size for cropped image. Unknown error has occurred.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '' unknown controls 
        Private Sub recaptureWebpageButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles recaptureWebpageButton.Click
            Dim vehicleadapter As QCDataSetTableAdapters.vwCircularTableAdapter
            Dim isSuccessful As Boolean
            Dim delay, retailerId, vehicleId, pageNumber As Integer
            Dim urlString, imageFilePath, imageFileBackupPath As String
            Dim userResponse As System.Windows.Forms.DialogResult
            Dim imageSize As System.Drawing.SizeF
            Dim delayPrompt As DropdownOptionForm
            Dim statusForm As UI.Controls.StatusMessageForm
            Dim webObj As WebsitesScreenshot.WebsitesScreenshot
            Dim captureResult As WebsitesScreenshot.WebsitesScreenshot.Result
            Dim imageEmailFilePath, VehicleMediaID As String
            Dim capturedimage As Bitmap




            Me.StatusMessage = "Preparing to capture page image."
            statusForm = New UI.Controls.StatusMessageForm()
            statusForm.Show(Me)
            statusForm.MessageText = "Preparing to capture page image."

            If retailerComboBox.SelectedValue Is Nothing _
              OrElse Integer.TryParse(retailerComboBox.SelectedValue.ToString(), retailerId) = False _
            Then
                retailerId = 0
            End If

            If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
                vehicleId = 0
            End If

            If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
                pageNumber = 0
            End If

            Try
                isSuccessful = False
                imageFilePath = Processor.GetPageImageFilePath(vehicleId, pageNumber, Processors.VehicleImageSizeEnum.Unsized)
                isSuccessful = True
            Catch ex As System.IO.FileNotFoundException
                MessageBox.Show("Can not download page image. Page image must exist to download newer one." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Can not download page image. Unknown error has occurred." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            If isSuccessful = False Then
                statusForm.Close()
                statusForm.Dispose()
                statusForm = Nothing
                Me.StatusMessage = String.Empty
                Exit Sub
            End If

            'imageSize = New System.Drawing.SizeF(1500, 1000) 'GetDisplayedImageSizeInPixel()

            VehicleMediaID = Processor.GetVehicleMedia(vehicleId)


            'imageFileBackupPath = Processor.GetVehiclePageImageBackupFilePath(vehicleId, pageNumber)

            delayPrompt = New DropdownOptionForm()
            For i As Integer = 0 To 30
                delayPrompt.delayComboBox.Items.Add(i)
            Next
            delayPrompt.delayComboBox.SelectedIndex = 0
            userResponse = delayPrompt.ShowDialog(Me)
            delay = 0
            If userResponse = Windows.Forms.DialogResult.OK Then
                If Integer.TryParse(delayPrompt.delayComboBox.Text, delay) = False Then
                    delay = 0
                End If
            End If
            delayPrompt.Dispose()
            delayPrompt = Nothing

            webObj = New WebsitesScreenshot.WebsitesScreenshot("Q8M810AR9FR41P0LUWAK331CU")


            webObj.ImageFormat = WebsitesScreenshot.WebsitesScreenshot.ImageFormats.JPG
            webObj.DelaySeconds = delay
            webObj.ImageWidth = 1000 'CType(imageSize.Width, Integer)

            'capturedimage = Processor.GetPageScreenShot(urlString)

            Me.StatusMessage = "Capturing page image from website. Please wait..."
            statusForm.MessageText = "Capturing page image from website. This may take some time. Please wait..."
            If VehicleMediaID = "12" Then

                Dim WebPageSource As String = Processor.GetWebPageSource(vehicleId)

                captureResult = webObj.CaptureHTML(WebPageSource)

            ElseIf VehicleMediaID = "16" Then
                Dim userinputedurl As String = InputBox("Enter Social Media URL ")
                If userinputedurl <> "" Then

                    urlString = userinputedurl

                Else
                    urlString = Processor.GetURLForPageImageDownload(retailerId, pageNumber, vehicleId)
                    captureResult = webObj.CaptureWebpage(urlString)
                End If


            Else
                urlString = Processor.GetURLForPageImageDownload(retailerId, pageNumber, vehicleId)
                captureResult = webObj.CaptureWebpage(urlString)
            End If




            If captureResult = WebsitesScreenshot.WebsitesScreenshot.Result.Captured Then
                'If System.IO.File.Exists(imageFilePath) Then
                '    Me.StatusMessage = "Taking backup of existing page image."
                '    statusForm.MessageText = String.Format("Taking backup of existing page image. {0}Backup File Path: {1}", Environment.NewLine, imageFileBackupPath)
                '    If System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(imageFileBackupPath)) = False Then
                '        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(imageFileBackupPath))
                '    End If
                '    If System.IO.File.Exists(imageFileBackupPath) Then System.IO.File.Delete(imageFileBackupPath)
                '    ''ClearImage()
                '    System.IO.File.Move(imageFilePath, imageFileBackupPath)
                'End If
                Me.StatusMessage = "Saving page image captured from website."
                statusForm.MessageText = String.Format("Saving page image captured from website at {0}", imageFilePath)
                webObj.SaveImage(imageFilePath)
                'webObj.Dispose()
                webObj = Nothing
                ShowImage(vehicleId, pageNumber)
                statusForm.Close()



                ''omar capture removal of Rectangle and storage of count to image log table
                'intRemoveRectangleCount = intRemoveRectangleCount + 1
                'blnRemoveRectangleChange = True
                'Me.StatusMessage = "rem"
            ElseIf captureResult = WebsitesScreenshot.WebsitesScreenshot.Result.Timeout Then
                statusForm.Close()
                MessageBox.Show("Image capturing operation took longer then expected. Application has aborted the operation." _
                                + Environment.NewLine + "If this happens frequently, inform your data-entry administrator." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                statusForm.Close()
                MessageBox.Show("Application failed to capture image. If this happens frequently, inform your data-entry administrator." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If




            statusForm.Dispose()
            statusForm = Nothing
            Me.StatusMessage = String.Empty



        End Sub

        Private Sub m_Processor_ChildVehicleQCProgress(ByVal parentVehicleId As Integer, ByVal childVehicleId As Integer, ByVal currentChildVehicle As Integer, ByVal totalChildVehicleCount As Integer) Handles m_Processor.ChildVehicleQCProgress

            Me.StatusMessage = String.Format("Processing child vehicle(s) ({0}/{1}) to mark as QCed. At present Processing vehicle {2}. Please wait...", currentChildVehicle, totalChildVehicleCount, childVehicleId)

        End Sub


        Private Sub showQcData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showQcData.Click

            Dim statusForm As UI.Controls.StatusMessageForm
            Dim isSuccessful As Boolean
            Me.StatusMessage = "Preparing to show Qc Data"
            Dim vehicleId As Integer
            Dim viewFamily As UI.FamilyViewForm


            If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
                vehicleId = 0
            End If

            If vehicleId < 1 Then
                MessageBox.Show("Load vehicle to see it's qc status.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim userResponse As DialogResult
            Dim filterHelp As UI.QcStatusDisplayScreen
            filterHelp = New QcStatusDisplayScreen()
            filterHelp.Text = "QC Details Screen"

            filterHelp.Initialize(New System.Data.DataView(Processor.FillByDataForQc(vehicleId)))

            userResponse = filterHelp.ShowDialog(Me)

            enableDisplaySenderInfo(vehicleId)




        End Sub

        Private Sub enableDisplaySenderInfo(ByVal vehicleId As Integer)

        End Sub

        Private Sub ViewThumbnails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewThumbnails.Click

            Dim imageFolderPath As String
            Dim thumbnailQuery As System.Collections.Generic.IEnumerable(Of String)
            Dim isThumbnailAvailable As Boolean = True
            Dim vehicleId As Integer
            Dim createDt As Date
            Dim tempPath As String

            If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
                vehicleId = 0
            End If

            If vehicleId < 1 Then
                MessageBox.Show("Load vehicle to see it's image thumbnails.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            createDt = CDate(Processor.GetCreateDtByVehicleId(vehicleId))
            tempPath = GetImagePath(createDt.ToString("yyyyMM"), Processor.UserLocationId, GetPathType("Master"))
            If String.IsNullOrEmpty(tempPath) = False Then
                imageFolderPath = tempPath _
                + vehicleId.ToString() + "\" + ThumbSizedPageImageFolderName
            Else
                imageFolderPath = VehicleImageFolderPath + "\" + createDt.ToString("yyyyMM") _
                                  + "\" + vehicleId.ToString() + "\" + ThumbSizedPageImageFolderName
            End If
            If System.IO.Directory.Exists(imageFolderPath) = False Then
                isThumbnailAvailable = False
                imageFolderPath = VehicleImageFolderPath + "\" + createDt.ToString("yyyyMM") _
                                  + "\" + vehicleId.ToString() + "\" + UnsizedPageImageFolderName
            End If

            Application.DoEvents()

            Processor.LoadPagesInformation(vehicleId)
            thumbnailQuery = From pageRow In Processor.Data.Page _
                             Select imageFolderPath + "\" + pageRow.ImageName + ".jpg"

            Dim thumbnailForm As UI.Controls.ThumbnailBrowserForm = New UI.Controls.ThumbnailBrowserForm()
            thumbnailForm.LoadThumbnails(thumbnailQuery.ToArray(), isThumbnailAvailable)
            thumbnailForm.Text += " - Vehicle " + vehicleId.ToString()
            Application.DoEvents()
            thumbnailForm.ShowDialog(Me)
            thumbnailForm.Dispose()
            thumbnailForm = Nothing

            thumbnailQuery = Nothing

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

        Private Sub m_additionalQcProcessor_ValidatingAdditionalQcInfo(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_Processor.ValidatingAdditionalQcInfo

            Me.StatusMessage = "Validating expectations..."

        End Sub


        Private Sub m_maintenanceProcessor_ExpectationValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_Processor.AdditionalQcInfoValidated

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_InvalidExpectationFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_Processor.InvalidAdditionalQcInfoFound
            Dim errorText As System.Text.StringBuilder
            Dim tempRows() As System.Data.DataRow
            Dim tempCols() As System.Data.DataColumn
            Dim tempTable As QCDataSet.AdditionalQcInformationDataTable

            Me.StatusMessage = String.Empty
            errorText = Nothing

        End Sub


        Private Sub SubjectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubjectButton.Click


            Me.StatusMessage = "Preparing to show Qc Subject Data"
            Dim vehicleId As Integer

            If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
                vehicleId = 0
            End If

            If vehicleId < 1 Then
                MessageBox.Show("Load vehicle to see it's qc status.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Not filterHelp Is Nothing Then
                If filterHelp.Visible = False Then
                    filterHelp = Nothing
                End If
            End If

            'If not open, then create the object and set to open
            If filterHelp Is Nothing Then
                filterHelp = New QcSubjectButtonForm()
            End If

            filterHelp.Initialize(Processor.FillSubjectForSocial(vehicleId))

            'Make sure it's visible
            If filterHelp.Visible = False Then
                filterHelp.Show()
            Else
                filterHelp.Refresh()
            End If

        End Sub

        Protected Overrides Sub OnDrawRectangle(ByVal img As Image, ByVal xAxis As Integer, ByVal yAxis As Integer, ByVal xWidth As Integer, ByVal xHeight As Integer)
            Dim strMedia As String = mediaComboBox.Text
            MyRect = New Rectangle(xAxis, yAxis, xWidth, xHeight)
            If IsZoomedIn = True Then
                If strMedia.ToUpper = "SOCIAL" Then
                    MyPen = New Pen(Color.Red, 3)
                ElseIf strMedia.ToUpper = "WEBSITE" Then
                    MyPen = New Pen(Color.Green, 3)
                Else
                    MyPen = New Pen(Color.Blue, 3)
                End If
            Else
                If strMedia.ToUpper = "SOCIAL" Then
                    MyPen = New Pen(Color.Red, 6)
                ElseIf strMedia.ToUpper = "WEBSITE" Then
                    MyPen = New Pen(Color.Green, 6)
                Else
                    MyPen = New Pen(Color.Blue, 6)
                End If
            End If
            MyGraphics = Graphics.FromImage(img)
            MyGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic
            MyGraphics.DrawRectangle(MyPen, MyRect)
            ImageDisplay.Image = img
            Me.AskToSaveImage = True
        End Sub

        Protected Overrides Sub OnDrawRectangle_Original(ByVal img As Image, ByVal xAxis As Integer, ByVal yAxis As Integer, ByVal xWidth As Integer, ByVal xHeight As Integer)
            Dim strMedia As String = mediaComboBox.Text

            MyRect = New Rectangle(xAxis, yAxis, xWidth, xHeight)
            If strMedia.ToUpper = "SOCIAL" Then
                MyPen = New Pen(Color.Red, 5)
                If img.Width < 500 Or img.Height < 500 Then MyPen = New Pen(Color.Red, 2)
            ElseIf strMedia.ToUpper = "WEBSITE" Then
                MyPen = New Pen(Color.Green, 5)
                If img.Width < 500 Or img.Height < 500 Then MyPen = New Pen(Color.Green, 2)
            Else
                MyPen = New Pen(Color.Blue, 5)
                If img.Width < 500 Or img.Height < 500 Then MyPen = New Pen(Color.Blue, 2)
            End If
            MyGraphics = Graphics.FromImage(img)
            MyGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic
            MyGraphics.DrawRectangle(MyPen, MyRect)
            OutputPictureBox.Image = img
            Me.AskToSaveImage = True
        End Sub

        Private Sub dgThumbnails_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgThumbnails.CellContentClick
            If Me.IsPageCropNavigation Then Exit Sub

            Dim left, top As Integer
            Dim o As UI.Controls.thumbnailToolTipForm = New UI.Controls.thumbnailToolTipForm()


            top = Cursor.Position.Y
            left = Cursor.Position.X - o.Width

            o.ToolTipText = dgThumbnails.Item(e.ColumnIndex, e.RowIndex).ToolTipText
            o.Location = New System.Drawing.Point(left, top)
            o.ShowDialog(Me)
        End Sub

        'SIMR functions

        Private Sub EnableSIMRControls(ByVal isSIMR As Boolean)
            If isSIMR Then
                simrButton.Visible = True
                scannerCheckBox.Visible = True
                CrookedCheckBox.Visible = True
                TearCheckBox.Visible = True
                BleedCheckBox.Visible = True
                BadCheckBox.Visible = True
            Else
                simrButton.Visible = False
                scannerCheckBox.Visible = False
                CrookedCheckBox.Visible = False
                TearCheckBox.Visible = False
                BleedCheckBox.Visible = False
                BadCheckBox.Visible = False
            End If
        End Sub

        Private Sub ClearSIMRControls()
           
                scannerCheckBox.Checked = False
            
                CrookedCheckBox.Checked = False
          
                TearCheckBox.Checked = False
            
                BleedCheckBox.Checked = False
            
                BadCheckBox.Checked = False

        End Sub

        Private Sub loadSIMRValues(ByVal vehicleid As Integer, ByVal pageNumber As Integer)
            If IsSIMR Then
                Dim pageid As Integer
                pageid = Processor.GetPageId(vehicleid, pageNumber)
                ' ClearSIMRControls()
                'loadCheckedPages(pageid)
                loadCheckedPages(pageNumber)
                qcButtonEnabledDisabled()
            End If
        End Sub

        Private Sub UpdateVehiclePageStatus(ByVal _scannerLines As Integer, ByVal _crooked As Integer, ByVal _pageTear As Integer, ByVal _bleedThrough As Integer, ByVal _badPages As Integer, ByVal _pageid As Integer, ByVal _enableQc As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As New Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd

                    .CommandText = "UPDATE VehiclePageStatus SET IndScannerlines = " + _scannerLines.ToString + ", IndCrooked =" + _crooked.ToString() + ", " _
                        + "IndPageTear= " + _pageTear.ToString + ", IndbleedThrough = " + _bleedThrough.ToString + ", IndbadPages=" + _badPages.ToString + " ,IndenableQc=" + _enableQc.ToString _
                       + " where ReceivedOrder = " + _pageid.ToString
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

        Private Sub insertVehiclePageStatus(ByVal _Vehicleid As Integer, ByVal _scannerLines As Integer, ByVal _crooked As Integer, ByVal _pageTear As Integer, ByVal _bleedThrough As Integer, ByVal _badPages As Integer, ByVal _pageid As Integer, ByVal _enableQc As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As New Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd

                    .CommandText = "insert into VehiclePageStatus(vehicleId,IndScannerlines,IndCrooked,IndPageTear,IndBleedThrough,IndBadPages,ReceivedOrder,IndEnableQc) values(  " + _Vehicleid.ToString + "," + _scannerLines.ToString + ", " + _crooked.ToString() + ", " _
                        + _pageTear.ToString + ", " + _bleedThrough.ToString + ", " + _badPages.ToString + "," + _pageid.ToString + "," + _enableQc.ToString + ")"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With

            Catch ex As Exception
                Throw New ApplicationException("Failed to insert Page Details.", ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub

        Public Function hasBadPageStatus(ByVal _vehicleid As Integer) As Boolean


            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand
            con = New System.Data.SqlClient.SqlConnection

            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()

            cmd.Connection = con

            cmd.CommandType = CommandType.Text

            cmd.CommandText = "Select Count(IndEnableQc)  FROM vehiclePageStatus WHERE IndEnableQc=1 and Vehicleid =" + _vehicleid.ToString

            obj = cmd.ExecuteScalar

            If IsDBNull(obj) Then obj = 0

            If CType(obj, Integer) >= 1 Then
                hasBadPageStatus = True
            ElseIf CType(obj, Integer) = 0 Then
                hasBadPageStatus = False
            End If

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing


        End Function

        Public Function IfSimrResponse(ByVal _vehicleid As Integer) As Boolean


            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand
            con = New System.Data.SqlClient.SqlConnection

            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()

            cmd.Connection = con

            cmd.CommandType = CommandType.Text

            cmd.CommandText = "Select simrResponse FROM vehiclePageStatus WHERE simrResponse=1 and Vehicleid =" + _vehicleid.ToString

            obj = cmd.ExecuteScalar

            If IsDBNull(obj) Then obj = 0

            If CType(obj, Integer) = 1 Then
                IfSimrResponse = False
            ElseIf CType(obj, Integer) = 2 Then
                IfSimrResponse = True
            Else
                IfSimrResponse = True
            End If

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing


        End Function

        Private Function ifVehiclePageExist(ByVal _PageID As Integer, ByVal _vehicleID As Integer) As Boolean


            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand
            con = New System.Data.SqlClient.SqlConnection

            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()

            cmd.Connection = con

            cmd.CommandType = CommandType.Text

            cmd.CommandText = "Select count(ReceivedOrder) FROM vehiclePageStatus WHERE ReceivedOrder =" + _PageID.ToString + " and vehicleid=" + _vehicleID.ToString

            obj = cmd.ExecuteScalar

            If IsDBNull(obj) Then obj = 0

            If CType(obj, Integer) = 1 Then
                ifVehiclePageExist = True
            ElseIf CType(obj, Integer) = 0 Then
                ifVehiclePageExist = False
            End If

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing


        End Function

        Private Function getPageStatusRecord(ByVal _pageId As Integer, ByVal _vehicleId As Integer) As DataTable

            Dim connection As System.Data.SqlClient.SqlConnection
            Dim command As System.Data.SqlClient.SqlCommand
            Dim adapter As New System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet
            Dim sql As String

            sql = "Select  * from vehiclePageStatus WHERE ReceivedOrder =" + _pageId.ToString + " and vehicleid=" + _vehicleId.ToString
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

        Private Sub loadCheckedPages(ByVal _pageID As Integer)
            Dim dv As DataView
            Dim vehicleid As Integer

            If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
                vehicleId = 0
            End If
            dv = New DataView(getPageStatusRecord(_pageID, vehicleid))
            If dv.Count = 0 Then
                ClearSIMRControls()
                Exit Sub
            End If

            If CInt(dv(0)("IndScannerLines")) = 1 Then
                scannerCheckBox.Checked = True
            Else
                scannerCheckBox.Checked = False
            End If

            If CInt(dv(0)("IndCrooked")) = 1 Then
                CrookedCheckBox.Checked = True
            Else
                CrookedCheckBox.Checked = False
            End If

            If CInt(dv(0)("IndPageTear")) = 1 Then
                TearCheckBox.Checked = True
            Else
                TearCheckBox.Checked = False
            End If

            If CInt(dv(0)("IndBleedThrough")) = 1 Then
                BleedCheckBox.Checked = True
            Else
                BleedCheckBox.Checked = False
            End If

            If CInt(dv(0)("IndBadPages")) = 1 Then
                BadCheckBox.Checked = True
            Else
                BadCheckBox.Checked = False
            End If

        End Sub

        Private Sub saveControlValues(ByVal _pageId As Integer, ByVal _vehicleId As Integer)
            Dim scannerLines, crooked, pageTear, bleedThrough, badPages, enableQc As Integer

            If scannerCheckBox.Checked = True Then
                scannerLines = 1
            Else
                scannerLines = 0
            End If
            If CrookedCheckBox.Checked = True Then
                crooked = 1
            Else
                crooked = 0
            End If
            If TearCheckBox.Checked = True Then
                pageTear = 1
            Else
                pageTear = 0
            End If
            If BleedCheckBox.Checked = True Then
                bleedThrough = 1
            Else
                bleedThrough = 0
            End If
            If BadCheckBox.Checked = True Then
                badPages = 1
            Else
                badPages = 0

            End If
            If (scannerCheckBox.Checked = True OrElse CrookedCheckBox.Checked = True OrElse TearCheckBox.Checked = True OrElse BleedCheckBox.Checked = True OrElse BadCheckBox.Checked = True) Then
                enableQc = 1
            Else
                enableQc = 0
            End If

            If ifVehiclePageExist(_pageId, _vehicleId) = True Then
                UpdateVehiclePageStatus(scannerLines, crooked, pageTear, bleedThrough, badPages, _pageId, enableQc)
            Else
                insertVehiclePageStatus(_vehicleId, scannerLines, crooked, pageTear, bleedThrough, badPages, _pageId, enableQc)
            End If


        End Sub

        Private Sub SimrCheckBox()

            Dim vehicleId As Integer
            Dim pageid As Integer
            Dim pageNumber As Integer


            If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
                pageNumber = -1
            End If

            If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
                vehicleId = 0
            End If
            pageid = Processor.GetPageId(vehicleId, pageNumber)

            'saveControlValues(pageid, vehicleId)
            saveControlValues(pageNumber, vehicleId)
        End Sub


        Private Sub scannerCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles scannerCheckBox.CheckedChanged
            'If scannerCheckBox.Checked = True Then
            '    SimrCheckBox()

            'End If

            SimrCheckBox()
            qcButtonEnabledDisabled()
        End Sub

        Private Sub CrookedCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles CrookedCheckBox.CheckedChanged
            'If CrookedCheckBox.Checked = True Then
            '    SimrCheckBox()
            'End If
            SimrCheckBox()
            qcButtonEnabledDisabled()
        End Sub

        Private Sub TearCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles TearCheckBox.CheckedChanged
            'If TearCheckBox.Checked = True Then
            '    SimrCheckBox()
            'End If
            SimrCheckBox()
            qcButtonEnabledDisabled()
        End Sub

        Private Sub BleedCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles BleedCheckBox.CheckedChanged
            'If BleedCheckBox.Checked = True Then
            '    SimrCheckBox()
            'End If
            SimrCheckBox()
            qcButtonEnabledDisabled()
        End Sub

        Private Sub BadCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles BadCheckBox.CheckedChanged
            'If BadCheckBox.Checked = True Then
            '    SimrCheckBox()
            'End If
            SimrCheckBox()
            qcButtonEnabledDisabled()
        End Sub

        Private Sub qcButtonEnabledDisabled()
            Dim allCheckBox As Boolean = True
            Dim vehicleid As Integer

            If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
                vehicleId = 0
            End If
            allCheckBox = hasBadPageStatus(vehicleid)
            enableDisableSimrControls(vehicleid)
            If (scannerCheckBox.Checked = True OrElse CrookedCheckBox.Checked = True OrElse TearCheckBox.Checked = True OrElse BleedCheckBox.Checked = True OrElse BadCheckBox.Checked = True) OrElse allCheckBox = True Then
                qcCompletedButton.Enabled = False
            Else
                qcCompletedButton.Enabled = True
            End If
        End Sub

        Private Sub enableDisableSimrControls(ByVal _Vehicleid As Integer)

            If IfSimrResponse(_Vehicleid) Then
                scannerCheckBox.Enabled = True
                CrookedCheckBox.Enabled = True
                TearCheckBox.Enabled = True
                BleedCheckBox.Enabled = True
                BadCheckBox.Enabled = True
            Else
                scannerCheckBox.Enabled = False
                CrookedCheckBox.Enabled = False
                TearCheckBox.Enabled = False
                BleedCheckBox.Enabled = False
                BadCheckBox.Enabled = False

            End If
        End Sub


        Private Sub simrButton_Click(sender As Object, e As EventArgs) Handles simrButton.Click
            Dim SimrPg As SimrPopupForm
            Dim vehicleid As Integer

            If Integer.TryParse(vehicleIdValueLabel.Text, vehicleid) = False Then
                vehicleid = 0
            End If


            SimrPg = New SimrPopupForm

            'SimrPg.Init(FormStateEnum.Edit)
            'SimrPg.ApplyUserCredentials()
            SimrPg.VehicleID = vehicleId
            SimrPg.ShowDialog(Me)

            SimrPg.Dispose()
            SimrPg = Nothing
        End Sub
    End Class
End Namespace