﻿Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Math
Imports System.IO
Namespace UI


    Public Class PublicationIndexQCForm
        Implements IForm


        Private Const FORM_NAME As String = "Publication Indexing and QC"

        Private m_pagecropVisitLog As System.Collections.Generic.List(Of Integer)
        Private WithEvents m_publicationIndexQCProcessor As Processors.PublicationIndexQC

        'Draw Objects in the Image
        Private MyRect As Rectangle
        Private MyPen As Pen
        Private TempImage As Image

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
        Private filterHelp As QcSubjectButtonForm

        Private intImageRotationCount As Integer

        Private _filePath As String
        Private temp_img As Bitmap
        Private _CurrentAngle As Integer

        Private _sender As Integer = 0
        Private isEnabledStatus As Boolean
        Private PgCropImage As Bitmap
        Private isClosedByButton As Boolean = False

        Public ReadOnly Property Processor() As Processors.PublicationIndexQC
            Get
                Return m_publicationIndexQCProcessor
            End Get
        End Property

        Public ReadOnly Property PageCropVisitLog() As System.Collections.Generic.List(Of Integer)
            Get
                Return m_pagecropVisitLog
            End Get
        End Property



        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="croppedPageNumber"></param>
        ''' <remarks></remarks>
        Private Sub AddToPageCropVisitLog(ByVal croppedPageNumber As Integer)
            Dim logVisitQuery As System.Collections.Generic.IEnumerable(Of Integer)


            logVisitQuery = From i In Me.PageCropVisitLog _
                            Where i = croppedPageNumber _
                            Select i

            If logVisitQuery.Count() = 0 Then
                Me.PageCropVisitLog.Add(croppedPageNumber)
            End If

            logVisitQuery = Nothing

        End Sub

        Private Sub DeleteFromPageCropVisitLog(ByVal croppedPageNumber As Integer)
            Dim logVisitQuery As System.Collections.Generic.IEnumerable(Of Integer)


            logVisitQuery = From i In Me.PageCropVisitLog _
                            Where i = croppedPageNumber _
                            Select i

            If logVisitQuery.Count() = 1 Then
                Me.PageCropVisitLog.Remove(croppedPageNumber)
            End If

            For i As Integer = 0 To Me.PageCropVisitLog.Count - 1
                If Me.PageCropVisitLog(i) > croppedPageNumber Then
                    Me.PageCropVisitLog(i) -= 1
                End If
            Next

            logVisitQuery = Nothing

        End Sub


        ''' <summary>
        ''' Clears all inputs on form.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub ClearInputs(ByVal isForSame As Boolean, ByVal clearPageImage As Boolean)

            If isForSame = False Then
                findVehicleIdTextBox.Clear()
                vehicleIdValueLabel.Text = String.Empty
                indexStatusTextLabel.Text = String.Empty
                pageCropValueLabel.Text = String.Empty
                adDateTypeInDatePicker.Clear()
                mediaComboBox.SelectedValue = DBNull.Value
                marketComboBox.SelectedValue = DBNull.Value
                publicationComboBox.SelectedValue = DBNull.Value
                languageComboBox.SelectedValue = DBNull.Value
            End If

            retailerComboBox.SelectedValue = DBNull.Value
            tradeclassValueLabel.Text = String.Empty
            eventComboBox.SelectedValue = DBNull.Value
            themeComboBox.SelectedValue = DBNull.Value
            startDateTypeInDatePicker.Clear()
            endDateTypeInDatePicker.Clear()
            couponCheckBox.Checked = False

            If clearPageImage Then
                currentPageLabel.Text = "0"
                totalPagesLabel.Text = "0"
                findImageTextBox.Clear()
            End If

        End Sub

        Protected Overrides Sub ClearAllInputs()

            findVehicleIdTextBox.Clear()
            vehicleIdValueLabel.Text = String.Empty
            indexStatusTextLabel.Text = String.Empty
            qcStatusTextLabel.Text = String.Empty
            pageCropValueLabel.Text = String.Empty
            adDateTypeInDatePicker.Clear()
            mediaComboBox.SelectedValue = DBNull.Value
            marketComboBox.SelectedValue = DBNull.Value
            publicationComboBox.SelectedValue = DBNull.Value
            languageComboBox.SelectedValue = DBNull.Value
            retailerComboBox.SelectedValue = DBNull.Value
            tradeclassValueLabel.Text = String.Empty
            eventComboBox.SelectedValue = DBNull.Value
            themeComboBox.SelectedValue = DBNull.Value
            startDateTypeInDatePicker.Clear()
            endDateTypeInDatePicker.Clear()
            couponCheckBox.Checked = False
            currentPageLabel.Text = "0"
            totalPagesLabel.Text = "0"
            findImageTextBox.Clear()
            sizeIdMediaLabel.Text = String.Empty
            ImageDisplay.Image = Nothing

            pageCropIdLabel.Text = String.Empty
            pageIdLabel.Text = String.Empty


        End Sub

        ''' <summary>
        ''' Removes error providers from all input controls.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub RemoveAllErrorProviders()
            RemoveErrorProvider(adDateTypeInDatePicker)
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

        Protected Overrides Sub ShowHideControls(ByVal formStatus As FormStateEnum)

            MyBase.ShowHideControls(formStatus)
            Me.pageTypeValueLabel.Visible = Not Me.IsPageCropNavigation
            Me.pageSizeLabel.Visible = Not Me.IsPageCropNavigation
            Me.sizeIdMediaLabel.Visible = Not Me.IsPageCropNavigation
            Me.pageSizeOptionGroupBox.Visible = Not Me.IsPageCropNavigation

            If Me.IsPageCropNavigation = False Then
                Me.adlertPageNameGroupBox.Visible = False
            End If

        End Sub

        Protected Overrides Sub EnableDisableControls(ByVal formStatus As FormStateEnum)

            Select Case formStatus
                Case FormStateEnum.Insert
                    adDateTypeInDatePicker.Enabled = False
                    mediaComboBox.Enabled = False
                    marketComboBox.Enabled = False
                    publicationComboBox.Enabled = False
                    languageComboBox.Enabled = False
                    retailerComboBox.Enabled = True
                    'tradeclassValueLabel.Enabled = True
                    eventComboBox.Enabled = True
                    themeComboBox.Enabled = True
                    startDateTypeInDatePicker.Enabled = True
                    endDateTypeInDatePicker.Enabled = True
                    definePagesButton.Enabled = False
                    couponCheckBox.Enabled = True

                    sameButton.Enabled = True
                    newButton.Enabled = True
                    printButton.Enabled = False
                    deleteButton.Enabled = False
                    editButton.Enabled = False
                    addButton.Enabled = False
                    prvalButton.Enabled = True
                    resetButton.Enabled = True
                    saveButton.Enabled = False
                    indexingCompleteButton.Enabled = False
                    qcCompletedButton.Enabled = False

                    vehiclePageCropButton.Enabled = True
                    imageNavigationGroupBox.Enabled = True
                    imageSearchGroupBox.Enabled = True
                    imageRotationGroupBox.Enabled = True
                    zoomButton.Enabled = True
                    keepRectangleButton.Enabled = True
                    removeRectangleButton.Enabled = True
                    saveImageButton.Enabled = True
                    refreshButton.Enabled = True
                    deleteImageButton.Enabled = Not Me.IsPageCropNavigation
                    resequenceButton.Enabled = False
                    adlertPageNameGroupBox.Enabled = True

                Case FormStateEnum.Edit
                    adDateTypeInDatePicker.Enabled = False
                    mediaComboBox.Enabled = False
                    marketComboBox.Enabled = False
                    publicationComboBox.Enabled = False
                    languageComboBox.Enabled = False
                    retailerComboBox.Enabled = True
                    'tradeclassValueLabel.Enabled = True
                    eventComboBox.Enabled = True
                    themeComboBox.Enabled = True
                    startDateTypeInDatePicker.Enabled = True
                    endDateTypeInDatePicker.Enabled = True
                    definePagesButton.Enabled = False
                    couponCheckBox.Enabled = True

                    sameButton.Enabled = False
                    newButton.Enabled = False
                    printButton.Enabled = False
                    deleteButton.Enabled = False
                    editButton.Enabled = False
                    addButton.Enabled = False
                    prvalButton.Enabled = False
                    resetButton.Enabled = False
                    saveButton.Enabled = True
                    indexingCompleteButton.Enabled = False
                    qcCompletedButton.Enabled = False

                    vehiclePageCropButton.Enabled = False
                    imageNavigationGroupBox.Enabled = False
                    imageSearchGroupBox.Enabled = False
                    imageRotationGroupBox.Enabled = True
                    zoomButton.Enabled = True
                    keepRectangleButton.Enabled = True
                    removeRectangleButton.Enabled = True
                    saveImageButton.Enabled = True
                    'If m_inReQC Then
                    '    If Processor.IsValidReqcUser() <> 1 Then
                    '        saveButton.Enabled = False
                    '    Else
                    '        saveButton.Enabled = True
                    '    End If

                    'End If
                    refreshButton.Enabled = True
                    deleteImageButton.Enabled = False
                    resequenceButton.Enabled = False
                    adlertPageNameGroupBox.Enabled = True

                Case Else
                    adDateTypeInDatePicker.Enabled = False
                    mediaComboBox.Enabled = False
                    marketComboBox.Enabled = False
                    publicationComboBox.Enabled = False
                    languageComboBox.Enabled = False
                    retailerComboBox.Enabled = False
                    'tradeclassValueLabel.Enabled = False
                    eventComboBox.Enabled = False
                    themeComboBox.Enabled = False
                    startDateTypeInDatePicker.Enabled = False
                    endDateTypeInDatePicker.Enabled = False
                    definePagesButton.Enabled = False
                    couponCheckBox.Enabled = False

                    sameButton.Enabled = False
                    newButton.Enabled = False
                    printButton.Enabled = False
                    deleteButton.Enabled = Me.IsPageCropNavigation
                    editButton.Enabled = Me.IsPageCropNavigation
                    addButton.Enabled = Not Me.IsPageCropNavigation
                    prvalButton.Enabled = False
                    resetButton.Enabled = False
                    saveButton.Enabled = False
                    indexingCompleteButton.Enabled = Not Me.IsPageCropNavigation
                    qcCompletedButton.Enabled = Not Me.IsPageCropNavigation

                    vehiclePageCropButton.Enabled = True
                    imageNavigationGroupBox.Enabled = True
                    imageSearchGroupBox.Enabled = True
                    imageRotationGroupBox.Enabled = False
                    zoomButton.Enabled = True
                    keepRectangleButton.Enabled = False
                    removeRectangleButton.Enabled = False
                    saveImageButton.Enabled = False
                    refreshButton.Enabled = False
                    deleteImageButton.Enabled = False
                    resequenceButton.Enabled = False
                    adlertPageNameGroupBox.Enabled = False
      End Select
      DistDateLabel.Enabled = False
      DistDateTypeInDatePicker.Enabled = False
      DistDateLabel.Visible = False
      DistDateTypeInDatePicker.Visible = False
            '
            'Once vehicle is marked as QCed, it can not be edited.
            '
            Dim vehicleId As Integer
            If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then vehicleId = 0

            If Processor.IsVehicleMarkedAsIndexingComplete(vehicleId) Then
                indexingCompleteButton.Enabled = False
            Else
                qcCompletedButton.Enabled = False
            End If

            If Processor.IsVehicleMarkedAsQCed(vehicleId) Then
                If Me.IsPageCropNavigation Then
                    editButton.Enabled = False
                    deleteButton.Enabled = False
                Else
                    addButton.Enabled = False
                    indexingCompleteButton.Enabled = False
                    qcCompletedButton.Enabled = False
                End If
            End If

        End Sub

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
            Dim imageName As String


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


            imageFolderPath = Processor.GetPageImageFolderPath(vehicleId)

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
            ElseIf linqQuery(0).IsSizeIDNull() OrElse linqQuery(0).SizeID <= 0 Then
                Throw New System.ApplicationException("Invalid cropped page image size.")
            ElseIf linqQuery(0).IsSizeIDNull() = False Then
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

            Return recroppedAdSize

        End Function

        Protected Overrides Function HasCroppedPageImages(ByVal vehicleId As Integer) As Boolean

            If Processor.GetCroppedPageCount(vehicleId) > 0 Then
                Return True
            Else
                Return False
            End If

        End Function

        Protected Overrides Sub OnRetailerChanged(ByVal retailerId As Integer, ByVal tradeclassId As Integer, ByVal tradeclass As String)
            Dim mediaId, marketId, retId As Integer


            MyBase.OnRetailerChanged(retailerId, tradeclassId, tradeclass)

            If Me.IsPageCropNavigation = False AndAlso Me.FormState <> FormStateEnum.Insert Then
                adlertPageNameGroupBox.Hide()
                Exit Sub
            End If


            If mediaComboBox.SelectedValue Is Nothing OrElse mediaComboBox.SelectedValue Is DBNull.Value Then
                mediaId = 0
            ElseIf Integer.TryParse(mediaComboBox.SelectedValue.ToString(), mediaId) = False Then
                mediaId = -1
            End If

            If marketComboBox.SelectedValue Is Nothing OrElse marketComboBox.SelectedValue Is DBNull.Value Then
                marketId = 0
            ElseIf Integer.TryParse(marketComboBox.SelectedValue.ToString(), marketId) = False Then
                marketId = -1
            End If

            If retailerComboBox.SelectedValue Is Nothing OrElse retailerComboBox.SelectedValue Is DBNull.Value Then
                retId = 0
            ElseIf Integer.TryParse(retailerComboBox.SelectedValue.ToString(), retId) = False Then
                retId = -1
            End If

            If mediaId < 1 OrElse marketId < 1 OrElse retId < 1 Then
                Exit Sub
            Else
                Dim isRequired As Boolean


                Try
                    isRequired = Processor.IsADlertRequired(mediaId, marketId, retId)
                Catch ex As Exception
                    'TODO: Log this exception.
                End Try

                adlertPageNameTextBox.Clear()
                adlertPageNameGroupBox.Visible = isRequired
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

            m_pagecropVisitLog = New System.Collections.Generic.List(Of Integer)
            m_publicationIndexQCProcessor = New Processors.PublicationIndexQC()
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
            addButton.Enabled = False
            vehiclePageCropButton.Enabled = False
            imageNavigationGroupBox.Enabled = False
            imageSearchGroupBox.Enabled = False
            zoomButton.Enabled = False

            Me.ResumeLayout(False)

            RaiseEvent FormInitialized()

        End Sub


#End Region



        ''' <summary>
        ''' Displays supplied row information in corresponding inputs.
        ''' </summary>
        ''' <param name="vehicleRow"></param>
        ''' <remarks></remarks>
        Private Sub ShowVehicleInformation(ByVal vehicleRow As QCDataSet.vwPublicationEditionRow)

            vehicleIdValueLabel.Text = vehicleRow.VehicleId.ToString()
            indexStatusTextLabel.Text = Processor.GetIndexStatusText(vehicleRow.VehicleId)
            qcStatusTextLabel.Text = Processor.GetQCStatusText(vehicleRow.VehicleId)

            If vehicleRow.IsBreakDtNull() Then
                adDateTypeInDatePicker.Clear()
            Else
                adDateTypeInDatePicker.Text = vehicleRow.BreakDt.ToString("MM/dd/yy")
            End If

            If vehicleRow.IsMediaIdNull() Then
                mediaComboBox.SelectedValue = DBNull.Value
            Else
                mediaComboBox.SelectedValue = vehicleRow.MediaId
            End If

            Processor.LoadMarket(vehicleRow.SenderId)
            If vehicleRow.IsMktIdNull() Then
                marketComboBox.SelectedValue = DBNull.Value
            Else
                marketComboBox.SelectedValue = vehicleRow.MktId
            End If

            Processor.LoadPublication(vehicleRow.MktId, vehicleRow.PublicationId)
            Dim _RetId As Integer = GetRetIdFromPageCrop(vehicleRow.VehicleId)
            isEnabledStatus = RetPublicationEnableStatus(_RetId, vehicleRow.PublicationId)
            If vehicleRow.IsPublicationIdNull() Then
                publicationComboBox.SelectedValue = DBNull.Value
            Else
                If isEnabledStatus = False And _RetId <> 0 Then MsgBox("Ret/Publication was disabled but you're able to continue")
                publicationComboBox.SelectedValue = vehicleRow.PublicationId
            End If

            If vehicleRow.IsLanguageIdNull() Then
                languageComboBox.SelectedValue = DBNull.Value
            Else
                languageComboBox.SelectedValue = vehicleRow.LanguageId
            End If

            'If Processor.LoadRetailersSenderExpectation(vehicleRow.SenderId, vehicleRow.MktId, vehicleRow.MediaId, vehicleRow.SenderId) = 0 Then
            Processor.LoadRetailer(vehicleRow.PublicationId)
            'End If
            retailerComboBox.SelectedValue = DBNull.Value
            eventComboBox.SelectedValue = DBNull.Value
            themeComboBox.SelectedValue = DBNull.Value

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

        End Sub

        Private Function RetPublicationEnableStatus(ByVal _retid As Integer, ByVal _publicationid As Integer) As Boolean
            Dim ReturnVal As Boolean
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "select * from RetPublicationCoverage where  RetId=" + CType(_retid, String) + " and PublicationId=" + CType(_publicationid, String) + " AND (EndDt IS NULL or EndDt >= GetDate())"
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

        Private Function GetRetIdFromPageCrop(ByVal vehicleid As Integer) As Integer
            Dim ReturnVal As Integer
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "select a.retid from PageCrop as a INNER JOIN Ret as b ON a.retid=b.retid where PageID in(select PageID from Page where VehicleId =" + CType(vehicleid, String) + ")  AND (b.EndDt IS NULL or b.EndDt >= GetDate())"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With

                If obj IsNot Nothing Then
                    ReturnVal = CType(obj, Integer)
                Else
                    ReturnVal = 0
                End If

            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return ReturnVal
        End Function

        ''' <summary>
        ''' Displays supplied rows information in corresponding inputs.
        ''' </summary>
        ''' <param name="tempPageCropRow"></param>
        ''' <remarks></remarks>
        Private Sub ShowVehicleInformation(ByVal tempPageCropRow As QCDataSet.PageCropRow)


            vehicleIdValueLabel.Text = tempPageCropRow.PageRow.VehicleId.ToString()

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

            If tempPageCropRow.IsPageIDNull() = False _
              AndAlso tempPageCropRow.PageRow IsNot Nothing _
              AndAlso tempPageCropRow.PageRow.IsPageNameNull() = False _
            Then
                adlertPageNameTextBox.Text = tempPageCropRow.PageRow.PageName


            Else
                adlertPageNameTextBox.Clear()
            End If

        End Sub

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
                    If dateMsg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then Return False
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
                If dateMsg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then Return False
            End If

            dateMsg.Dispose()
            dateMsg = Nothing

            Return Not showMsg

        End Function

        ''' <summary>
        ''' Validates for ADlert page name. 
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="pageId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function ValidateADlertPageName(ByVal vehicleId As Integer, ByVal pageId As Integer) As Boolean

            'If Processor.IsPageHasPageNameAssigned(vehicleId, pageId) Then
            '  Dim userResponse As DialogResult

            '  userResponse = MessageBox.Show("Page is already having page name assigned to it. Do you want to overwrite it" _
            '                                 + " with new value?", ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            '  If userResponse = Windows.Forms.DialogResult.No Then adlertPageNameTextBox.Clear()
            'Else
            If adlertPageNameTextBox.TextLength = 0 Then
                SetErrorProvider(adlertPageNameTextBox, "Provide ADlert page name.")
            Else
                RemoveErrorProvider(adlertPageNameTextBox)
            End If

            Return (adlertPageNameTextBox.TextLength > 0)

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
                ElseIf startDateTypeInDatePicker.Value.HasValue = False Then
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
                MessageBox.Show("Sale cannot end before Ad date.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                areAllValid = False
            ElseIf startDateTypeInDatePicker.Value.HasValue _
              AndAlso startDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days > 0 _
            Then
                MessageBox.Show("Sale cannot end before it start.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                areAllValid = False
            ElseIf (adDateTypeInDatePicker.Value.HasValue _
                    AndAlso adDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days < -35) _
              OrElse (startDateTypeInDatePicker.Value.HasValue _
                    AndAlso startDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days < -30) _
            Then
                Dim userResponse As DialogResult
                userResponse = MessageBox.Show("Sale End Date is unusual compared to Sale Start Date or Ad Date." _
                                               + " Check all values. Is the sale end date correct?", ProductName _
                                               , MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If userResponse = Windows.Forms.DialogResult.No Then areAllValid = False
            End If


            If adlertPageNameGroupBox.Visible AndAlso adlertPageNameTextBox.Text.Trim().Length = 0 Then
                SetErrorProvider(adlertPageNameGroupBox, "Provide Page Name for ADlert.", ErrorIconAlignment.TopLeft)
                areAllValid = False
            Else
                RemoveErrorProvider(adlertPageNameTextBox)
            End If

            If areAllValid Then areAllValid = ValidateBusinessRules()


            Return areAllValid

        End Function

        ''' <summary>
        ''' Sets columns value of supplied PageCroprow. Assumes that the supplied row is a new row.
        ''' </summary>
        ''' <param name="tempRow"></param>
        ''' <param name="pageId"></param>
        ''' <param name="croppedImageName"></param>
        ''' <param name="adSizeId"></param>
        ''' <param name="adSizeRectangle"></param>
        ''' <returns>Returns PageCropId once record is successfully inserted into PageCrop table.</returns>
        ''' <remarks></remarks>
        Private Function SetNewPageCropDataRow(ByVal tempRow As QCDataSet.PageCropRow, ByVal pageId As Integer, ByVal croppedImageName As String, ByVal adSizeId As Integer, ByVal adSizeRectangle As System.Drawing.RectangleF) As Integer

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

        End Function

        ''' <summary>
        ''' Updates PageCrop data row based on values specified in controls.
        ''' </summary>
        ''' <param name="tempRow"></param>
        ''' <param name="adSizeId"></param>
        ''' <param name="adSizeRectangle"></param>
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

            tempRow.EndEdit()

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
        Private Sub ShowCroppedImage(ByVal vehicleId As Integer, ByVal pageCropId As Integer, ByVal pageNumber As Integer)
            Dim croppedImagePath As String


            croppedImagePath = Processor.GetCroppedPageImagePath(vehicleId, pageCropId)

            If System.IO.File.Exists(croppedImagePath) = False Then
                ''ClearImage()
                Throw New System.ApplicationException("Cropped ad image not found: " + Environment.NewLine + croppedImagePath)
            End If

            ShowImage(croppedImagePath)

            croppedImagePath = Nothing

        End Sub

        ''' <summary>
        ''' If vehicle is not marked as Indexed, ask user for confirmation.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns>True is user confirms, false otherwise.</returns>
        ''' <remarks></remarks>
        Private Function AskForContinueWithoutIndexingCompleted(ByVal vehicleId As Integer) As Boolean
            Dim isIndexed, returnValue As Boolean


            Try
                isIndexed = Processor.IsVehicleMarkedAsIndexingComplete(vehicleId)
            Catch ex As System.ApplicationException
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return True 'Allows user to continue without marking vehicle as indexed.
            End Try

            If isIndexed Then
                returnValue = True
            Else
                Dim userResponse As DialogResult
                userResponse = MessageBox.Show("Vehicle is not yet marked as Index Completed. Are you sure" _
                                               + " you want to continue?", ProductName, MessageBoxButtons.YesNo _
                                               , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                returnValue = (userResponse = Windows.Forms.DialogResult.Yes)
            End If

            Return returnValue

        End Function

        ''' <summary>
        ''' Displays list of missing files into separate dialog.
        ''' </summary>
        ''' <param name="missingFiles"></param>
        ''' <param name="imageFolderPath"></param>
        ''' <remarks></remarks>
        Private Sub ShowMissingFiles(ByVal missingFiles As System.Collections.Generic.List(Of QCDataSet.PageCropRow), ByVal imageFolderPath As String)
            Dim missingFilesWin As UI.MissingFilesForm
            Dim listItems As System.Collections.Generic.List(Of System.Windows.Forms.ListViewItem)
            Dim tempListItem As System.Windows.Forms.ListViewItem
            Dim subItem As System.Windows.Forms.ListViewItem.ListViewSubItem


            listItems = New System.Collections.Generic.List(Of System.Windows.Forms.ListViewItem)

            For i As Integer = 0 To missingFiles.Count - 1
                tempListItem = New System.Windows.Forms.ListViewItem

                tempListItem.Text = missingFiles(i).CropImageName + ".jpg"

                subItem = New System.Windows.Forms.ListViewItem.ListViewSubItem()
                subItem.Text = imageFolderPath
                tempListItem.SubItems.Add(subItem)
                subItem = Nothing

                subItem = New System.Windows.Forms.ListViewItem.ListViewSubItem()
                subItem.Text = missingFiles(i).PageRow.ReceivedOrder.ToString()
                tempListItem.SubItems.Add(subItem)
                subItem = Nothing

                listItems.Add(tempListItem)

                subItem = Nothing
                tempListItem = Nothing
            Next

            missingFilesWin = New UI.MissingFilesForm
            missingFilesWin.headerLabel.Text += " Cannot mark vehicle as Indexing Complete."
            missingFilesWin.filesListView.Items.AddRange(listItems.ToArray())
            missingFilesWin.ShowDialog(Me)
            missingFilesWin.Dispose()
            missingFilesWin = Nothing

            listItems.Clear()
            listItems = Nothing

        End Sub


#Region " Functionalities for buttons on left panel below vehicle information "


        Protected Overrides Sub OnExitClicked()
            isClosedByButton = True
            Me.Close()

        End Sub


        Protected Overrides Sub OnFindVehicle(ByVal vehicleId As Integer, ByVal eventInitiator As EventInitiatorEnum)
            Dim dupcheckResponse As UI.DuplicateCheckUserResponse
            Processor.LoadVehicle(vehicleId, FORM_NAME)

            If CType(marketComboBox.SelectedValue, Integer) = 147 Then
                dupcheckResponse = CheckForDuplication(CType(marketComboBox.SelectedValue, Integer) _
                                                      , CType(publicationComboBox.SelectedValue, Integer), False, FORM_NAME)
                If dupcheckResponse = DuplicateCheckUserResponse.Closed Then Exit Sub
            End If

            If eventInitiator = EventInitiatorEnum.LoadButton Then
                Me.PageCropVisitLog.Clear()
            End If

        End Sub


        Protected Overrides Sub OnAdDateValidating(ByVal adDate As Date?, ByRef Cancel As Boolean)
            Dim dateDifference As Integer
            Dim userResponse As DialogResult


            If adDate Is Nothing Then
                RemoveErrorProvider(adDateTypeInDatePicker)
                Cancel = False
                Exit Sub
            End If

            dateDifference = adDate.Value.Subtract(System.DateTime.Today).Days

            If dateDifference < -365 OrElse dateDifference > 365 Then
                userResponse = MessageBox.Show("Is Ad date correct?", ProductName, MessageBoxButtons.YesNo _
                                               , MessageBoxIcon.Question)
                Cancel = (userResponse = Windows.Forms.DialogResult.No)
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
                    userResponse = MessageBox.Show("Difference between Sale Start Date and Ad Date is unusually large." _
                                                   + " Check these values. Is sale start date correct?", ProductName _
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
                    SetErrorProvider(endDateTypeInDatePicker, "End date cannot be prior to Ad date.")
                ElseIf adDate.Value.Subtract(endDate.Value).Days < -35 Then 'i.e. adDt - endDt
                    SetErrorProvider(endDateTypeInDatePicker, "End date is not within 35 days of Ad date.")
                Else
                    RemoveErrorProvider(endDateTypeInDatePicker)
                End If
            End If

            If startDate.HasValue AndAlso m_ErrorProvider.GetError(endDateTypeInDatePicker) = String.Empty Then
                'dateDifference = startDate.Value.Subtract(endDate.Value).Days
                If startDate.Value.Subtract(endDate.Value).Days > 0 Then 'i.e. StartDt - endDt
                    SetErrorProvider(endDateTypeInDatePicker, "End date cannot be prior to Start date.")
                ElseIf startDate.Value.Subtract(endDate.Value).Days < -30 Then  'i.e. StartDt - endDt
                    SetErrorProvider(endDateTypeInDatePicker, "End date is not within 30 days of Start date.")
                Else
                    RemoveErrorProvider(endDateTypeInDatePicker)
                End If
            End If

            'If dateDifference < -30 OrElse dateDifference > 30 Then
            '  Dim userResponse As DialogResult
            '  userResponse = MessageBox.Show("Sale End Date is unusual compared to Sale Start Date or Ad Date." _
            '                                 + " Check these values. Is sale end date correct?", ProductName _
            '                                 , MessageBoxButtons.YesNo, MessageBoxIcon.Question _
            '                                 , MessageBoxDefaultButton.Button2)
            '  If userResponse = Windows.Forms.DialogResult.No Then
            '    Cancel = True
            '    Exit Sub
            '  End If
            'End If

        End Sub


        Protected Overrides Sub OnDefinePages(ByVal vehicleId As Integer)
            Dim definePgs As PageDefinitionsForm


            definePgs = New PageDefinitionsForm

            definePgs.Init(FormStateEnum.Edit)
            definePgs.ApplyUserCredentials()
            definePgs.VehicleID = vehicleId
            definePgs.ShowDialog(Me)

            definePgs.Dispose()
            definePgs = Nothing

            RefreshPageInformation()

        End Sub


        Protected Overrides Sub OnSame(ByVal vehicleId As Integer, ByVal pageNumber As Integer, ByVal adSize As System.Drawing.SizeF, ByVal adRectangle As System.Drawing.RectangleF, Optional ByVal isRectKept As Boolean = False, Optional ByVal isRectRemoved As Boolean = False, _
                                       Optional ByVal isRectDrawn As Boolean = False)
            Dim pageId, adSizeId As Integer
            Dim pageName, croppedPageImageFolder As String
            Dim tempRow As QCDataSet.PageCropRow


            If AreInputsValid() = False Then Exit Sub

            pageId = Processor.GetPageId(vehicleId, pageNumber)
            adSizeId = Processor.GetSizeId(adSize.Width, adSize.Height)
            pageName = Processor.GetNewImageName()
            tempRow = Processor.Data.PageCrop.NewPageCropRow()

            SetNewPageCropDataRow(tempRow, pageId, pageName, adSizeId, adRectangle)

            If Processor.AreInputsValid(Processor.Data.vwPublicationEdition(0), tempRow) = False Then
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

        End Sub

        ''' <summary>
        ''' Updates PageName column value in Page data table.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="pageId"></param>
        ''' <remarks></remarks>
        Private Sub SetADlertPageName(ByVal vehicleId As Integer, ByVal pageId As Integer)
            Dim pageQuery As System.Data.EnumerableRowCollection(Of QCDataSet.PageRow)


            pageQuery = From pr In Processor.Data.Page _
                        Where pr.VehicleId = vehicleId AndAlso pr.PageId = pageId

            If pageQuery.Count() > 0 Then
                pageQuery(0).PageName = adlertPageNameTextBox.Text
            End If

            pageQuery = Nothing
        End Sub

        Protected Overrides Sub OnNew(ByVal vehicleId As Integer, ByVal pageNumber As Integer, ByVal adSize As System.Drawing.SizeF, ByVal adRectangle As System.Drawing.RectangleF, Optional ByVal isRectKept As Boolean = False, Optional ByVal isRectRemoved As Boolean = False, _
                                       Optional ByVal isRectDrawn As Boolean = False)
            Dim pageId, adSizeId As Integer
            Dim pageName, croppedPageImageFolder As String
            Dim tempRow As QCDataSet.PageCropRow


            If AreInputsValid() = False Then Exit Sub

            pageId = Processor.GetPageId(vehicleId, pageNumber)
            adSizeId = Processor.GetSizeId(adSize.Width, adSize.Height)
            pageName = Processor.GetNewImageName()
            tempRow = Processor.Data.PageCrop.NewPageCropRow()

            If adlertPageNameTextBox.Visible AndAlso ValidateADlertPageName(vehicleId, pageId) = False Then Exit Sub

            SetNewPageCropDataRow(tempRow, pageId, pageName, adSizeId, adRectangle)
            If adlertPageNameTextBox.Visible Then SetADlertPageName(vehicleId, pageId)

            If Processor.AreInputsValid(Processor.Data.vwPublicationEdition(0), tempRow) = False Then
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
            If adlertPageNameTextBox.Visible Then Processor.UpdateAllPageNames()
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
                myGraphics = Graphics.FromImage(_output)
                myGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic
                myGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality
                myGraphics.CompositingQuality = CompositingQuality.GammaCorrected
                myGraphics.DrawImage(bmp, 0, 0, MyRect, GraphicsUnit.Pixel)
                PgCropImage = New Bitmap(RectWidth, RectHeight)
                PgCropImage = _output
            Else
                Dim MyRect As RectangleF
                Dim RectWidth As Integer = CType(rect.Width, Integer)
                Dim RectHeight As Integer = CType(rect.Height, Integer)

                If RectWidth = 0 Then RectWidth = OutputPictureBox.Width
                If RectHeight = 0 Then RectHeight = OutputPictureBox.Height

                Dim _output As Bitmap = New Bitmap(RectWidth, RectHeight)
                myGraphics = Graphics.FromImage(_output)
                myGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic
                myGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality
                myGraphics.CompositingQuality = CompositingQuality.GammaCorrected
                myGraphics.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height)
                PgCropImage = New Bitmap(RectWidth, RectHeight)
                PgCropImage = _output
            End If
        End Sub

        Protected Overrides Sub OnDeletePageCrop(ByVal vehicleId As Integer, ByVal pageCropId As Integer)
            Dim q As System.Collections.Generic.IEnumerable(Of QCDataSet.PageCropRow)
            Dim croppedImagePath As String


            DeleteFromPageCropVisitLog(CType("0" + currentPageLabel.Text, Integer))

            'Get path before removing record.
            croppedImagePath = Processor.GetCroppedPageImagePath(vehicleId, pageCropId)

            q = From r In Processor.Data.PageCrop.Rows.Cast(Of QCDataSet.PageCropRow)() _
                Select r _
                Where r.PageCropId = pageCropId

            If q.Count > 0 Then q(0).Delete()

            Processor.SynchronizePageCropData()

            q = Nothing

            System.IO.File.Delete(croppedImagePath)

            Me.FormState = FormStateEnum.View

            RefreshPageCropInformation()
            If nextImageButton.Enabled Then
                nextImageButton.PerformClick()
            ElseIf previousImageButton.Enabled Then
                previousImageButton.PerformClick()
            ElseIf Processor.Data.PageCrop.Count > 0 Then
                OnNavigateToFirstPageCrop(vehicleId)  'If previous & next both are disabled and pagecrop count is 1, there is only one page crop left.
            Else
                vehiclePageCropButton.PerformClick()
            End If

            Me.ShowHideControls(Me.FormState)
            Me.EnableDisableControls(Me.FormState)

        End Sub


        Protected Overrides Sub OnEdit(ByVal vehicleId As Integer)

            'User cannot edit vehicle record on this screen.
            If Me.IsPageCropNavigation Then Me.FormState = FormStateEnum.Edit

        End Sub


        Protected Overrides Sub OnAdd()

            'To reset cropped image size related variables.
            MyBase.OnAdd()

            Me.FormState = FormStateEnum.Insert

            ClearInputs(True, False)
            RemoveAllErrorProviders()

            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

            retailerComboBox.Focus()

        End Sub


        Protected Overrides Sub OnShowPreviousPageCrop(ByVal vehicleId As Integer, ByVal retailerId As Integer)

            Processor.LoadLatestPageCropInformation(vehicleId, retailerId)

            If Processor.Data.PageCrop.Count() > 0 Then
                ShowVehicleInformation(Processor.Data.PageCrop(0))
            Else
                MessageBox.Show("Vehicle does not have any cropped Ads.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'Following load statement is required to reload all pagecrop information, for the vehicle, in dataset.
            Processor.LoadVehiclePageCropInformation(vehicleId)

        End Sub


        Protected Overrides Sub OnClear()

            Me.FormState = FormStateEnum.View

            ClearAllInputs()
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

            addButton.Enabled = False
            vehiclePageCropButton.Text = "Vehicle / Page Crop"
            vehiclePageCropButton.Enabled = False
            imageNavigationGroupBox.Enabled = False
            imageSearchGroupBox.Enabled = False
            zoomButton.Enabled = False

            findVehicleIdTextBox.Focus()
            findVehicleIdTextBox.SelectAll()

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
            If adlertPageNameTextBox.Visible AndAlso ValidateADlertPageName(vehicleId, tempRow.PageID) = False Then Exit Sub
            UpdatePageCropDataRow(tempRow, adSizeId, adRectangle)
            If adlertPageNameTextBox.Visible Then SetADlertPageName(vehicleId, tempRow.PageID)

            If Processor.AreInputsValid(Processor.Data.vwPublicationEdition(0), tempRow) = False Then
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
            If adlertPageNameTextBox.Visible Then Processor.UpdateAllPageNames()

            croppedPageImagePath = Processor.GetCroppedPageImagePath(vehicleId, pageCropId)

            Me.FormState = FormStateEnum.View
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

        End Sub


#End Region


#Region " Page image navigation related methods "

        Protected Overrides Sub OnNavigateToFirstImage(ByVal vehicleId As Integer)
            _CurrentAngle = 0
            ImagePanel.SuspendLayout()
            Dim imageFolder As String

            _filePath = ImageDisplay.ImageLocation.ToString
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

            imageFolder = Processor.GetPageImageFolderPath(vehicleId)
            ShowImage(vehicleId, 1)

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
            sizeIdMediaLabel.Text = Processor.GetPageSizeMediaText(vehicleId, 1)
            Me.AskToSaveImage = False
            imageFolder = Nothing
            ImagePanel.ResumeLayout()
        End Sub

        Protected Overrides Sub OnNavigateToLastImage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            _CurrentAngle = 0
            ImagePanel.SuspendLayout()
            Dim imageFolder As String
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

            imageFolder = Processor.GetPageImageFolderPath(vehicleId)
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
            sizeIdMediaLabel.Text = Processor.GetPageSizeMediaText(vehicleId, pageNumber)
            Me.AskToSaveImage = False
            imageFolder = Nothing
            ImagePanel.ResumeLayout()
        End Sub

        Protected Overrides Sub OnNavigateToNextImage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            _CurrentAngle = 0
            ImagePanel.SuspendLayout()

            Dim imageFolder As String
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

            imageFolder = Processor.GetPageImageFolderPath(vehicleId)
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
            sizeIdMediaLabel.Text = Processor.GetPageSizeMediaText(vehicleId, pageNumber)
            Me.AskToSaveImage = False
            imageFolder = Nothing

            ImagePanel.ResumeLayout()
        End Sub

        Protected Overrides Sub OnNavigateToPreviousImage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            _CurrentAngle = 0
            ImagePanel.SuspendLayout()

            Dim imageFolder As String
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

            imageFolder = Processor.GetPageImageFolderPath(vehicleId)
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
            sizeIdMediaLabel.Text = Processor.GetPageSizeMediaText(vehicleId, pageNumber)
            Me.AskToSaveImage = False
            imageFolder = Nothing

            ImagePanel.ResumeLayout()
        End Sub

        Protected Overrides Sub OnFindPage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            _CurrentAngle = 0
            Dim imageFolder As String
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

            imageFolder = Processor.GetPageImageFolderPath(vehicleId)
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
            sizeIdMediaLabel.Text = Processor.GetPageSizeMediaText(vehicleId, pageNumber)
            findImageTextBox.Text = String.Empty
            Me.AskToSaveImage = False
            imageFolder = Nothing
        End Sub

#End Region


#Region " Image rotation related events "

#Region "Rotation by User Input Angle"
        Private Function RotateImage(ByVal image As Image, ByVal angle As Single) As Bitmap
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

            '' rotationAngle = 18000

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


        End Sub

        Protected Overrides Function OnRotatePageAnticlockWise(ByVal rotationCounter As Integer) As Integer
            rotationCounter = -rotationCounter
            If _CurrentAngle > 0 Then
                rotationCounter = _CurrentAngle - 1
            End If

            _CurrentAngle = rotationCounter

            Me.AskToSaveImage = True

            If blnImageRotationChange = False Then
                intImageRotationCount = intImageRotationCount + 1
                blnImageRotationChange = True
                Me.StatusMessage = "racw"
            End If

            lblisRotatedBy.Text = "true"

            _filePath = ImageDisplay.ImageLocation.ToString
            Dim bt As Bitmap = New Bitmap(_filePath)
            Dim bmp As Bitmap = New Bitmap(bt.Width, bt.Height)
            bmp = RotateImage(bt, CType(rotationCounter / 20, Integer))
            OutputPictureBox.Image = bmp
            ImageDisplay.Image = bmp
            ImageDisplay.Image = AdjustImageToRetainRatio()

            bt.Dispose()
            _filePath = Nothing

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

            Me.AskToSaveImage = True

            lblisRotatedBy.Text = "true"

            _filePath = ImageDisplay.ImageLocation.ToString
            Dim bt As Bitmap = New Bitmap(_filePath)
            Dim bmp As Bitmap = New Bitmap(bt.Width, bt.Height)
            bmp = RotateImage(bt, CType(rotationCounter / 20, Integer))
            OutputPictureBox.Image = bmp
            ImageDisplay.Image = bmp
            ImageDisplay.Image = AdjustImageToRetainRatio()

            bt.Dispose()
            _filePath = Nothing

            Return _CurrentAngle
        End Function

        Private Function AdjustImageToRetainRatio() As Bitmap
            Dim _GenImage As Bitmap '= New Bitmap(ImageDisplay.Image)
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

        End Sub

        Protected Overrides Sub OnRotatePageBy(ByVal rotationAngle As Integer, ByVal isAccepted As Boolean)
            Dim userResponse As Windows.Forms.DialogResult

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
            temp_img = RotateImage(bt, rotationAngle)
            If isAccepted Then
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
        End Sub

#End Region




#Region " Functionalities for buttons on right panel below image rotation "


        ''' <summary>
        ''' Loads rows from PageCrop table based on supplied vehicleId.
        ''' </summary>
        ''' <param name="vehicleId">PageCrop records for supplied vehicleId will be loaded.</param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnPageCropInformation(ByVal vehicleId As Integer)

            ClearAllInputs()
            Me.FormState = FormStateEnum.View

            Processor.LoadVehiclePageCropInformation(vehicleId)
            ShowVehicleInformation(Processor.Data.vwPublicationEdition(0))
            ShowVehicleInformation(Processor.Data.PageCrop(0))

            Try
                ShowCroppedImage(vehicleId, Processor.Data.PageCrop(0).PageCropId, Nothing)
            Catch ex As ApplicationException
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            currentPageLabel.Text = "1"

            Me.AddToPageCropVisitLog(CType(currentPageLabel.Text, Integer))

        End Sub

        Protected Overrides Sub OnNavigateToFirstPageCrop(ByVal vehicleId As Integer)
            Dim tempRow As QCDataSet.PageCropRow


            If Processor.Data.PageCrop.Count = 0 Then
                MessageBox.Show("There is no cropped image information available for vehicle " _
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

            Me.AskToSaveImage = False
            currentPageLabel.Text = "1"

            Me.AddToPageCropVisitLog(CType(currentPageLabel.Text, Integer))

            tempRow = Nothing

        End Sub

        Protected Overrides Sub OnNavigateToPreviousPageCrop(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            Dim tempRow As QCDataSet.PageCropRow


            If Processor.Data.PageCrop.Count = 0 Then
                MessageBox.Show("There is no cropped image information available for vehicle " _
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

            Me.AskToSaveImage = False
            currentPageLabel.Text = pageNumber.ToString()

            Me.AddToPageCropVisitLog(CType(currentPageLabel.Text, Integer))

            tempRow = Nothing

        End Sub

        Protected Overrides Sub OnNavigateToNextPageCrop(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
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
            Catch ex As ApplicationException
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Me.AskToSaveImage = False
            currentPageLabel.Text = pageNumber.ToString()

            Me.AddToPageCropVisitLog(CType(currentPageLabel.Text, Integer))

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

            Me.AskToSaveImage = False
            currentPageLabel.Text = pageNumber.ToString()

            Me.AddToPageCropVisitLog(CType(currentPageLabel.Text, Integer))

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
            Me.AskToSaveImage = False

            Me.AddToPageCropVisitLog(CType(currentPageLabel.Text, Integer))

            tempRow = Nothing

        End Sub


        Protected Overrides Sub OnPageImageCrop(ByVal img As Image, ByVal xAxis As Integer, ByVal yAxis As Integer, ByVal xWidth As Integer, ByVal xHeight As Integer)
            Dim MyRect As Rectangle
            Dim _output As Bitmap = New Bitmap(xWidth, xHeight)
            MyRect = New Rectangle(xAxis, yAxis, xWidth, xHeight)
            myGraphics = Graphics.FromImage(_output)
            myGraphics.InterpolationMode = InterpolationMode.HighQualityBilinear
            myGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality
            myGraphics.CompositingQuality = CompositingQuality.GammaCorrected
            myGraphics.DrawImage(img, 0, 0, MyRect, GraphicsUnit.Pixel)
            ImageDisplay.Image = _output
            Me.AskToSaveImage = True

        End Sub

        Protected Overrides Sub OnPageImageClearSelection(ByVal img As Image, ByVal xAxis As Integer, ByVal yAxis As Integer, ByVal xWidth As Integer, ByVal xHeight As Integer)


            MyRect = New Rectangle(xAxis, yAxis, xWidth, xHeight)
            myGraphics = Graphics.FromImage(img)
            myGraphics.FillRectangle(Brushes.White, MyRect)
            ImageDisplay.Image = ImageDisplay.Image

            Me.AskToSaveImage = True

        End Sub

        Protected Overrides Sub OnPageImageClearSelection_Original(ByVal img As Image, ByVal xAxis As Integer, ByVal yAxis As Integer, ByVal xWidth As Integer, ByVal xHeight As Integer)


            MyRect = New Rectangle(xAxis, yAxis, xWidth, xHeight)
            myGraphics = Graphics.FromImage(img)
            myGraphics.FillRectangle(Brushes.White, MyRect)
            ImageDisplay.Image = ImageDisplay.Image

            Me.AskToSaveImage = True

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
            Me.AskToSaveImage = True

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
            myGraphics = Graphics.FromImage(img)
            myGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic
            myGraphics.DrawRectangle(MyPen, MyRect)
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
            myGraphics = Graphics.FromImage(img)
            myGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic
            myGraphics.DrawRectangle(MyPen, MyRect)
            OutputPictureBox.Image = img
            AskToSaveImage = True
        End Sub
        'Protected Overrides Sub OnPageImageSave()
        '    Dim _temp As Bitmap = New Bitmap(OutputPictureBox.Image)
        '    If IsRotationLabel.Text = "false" Then
        '        SaveImage(_temp, ImageDisplay.ImageLocation.ToString)
        '    Else
        '        _temp.Save(ImageDisplay.ImageLocation)
        '    End If

        '    Me.AskToSaveImage = False

        'End Sub

        Protected Overrides Sub OnPageImageSave()
            Dim _temp As Bitmap = New Bitmap(OutputPictureBox.Image, OutputPictureBox.Width, OutputPictureBox.Height)
            SaveImage(_temp, ImageDisplay.ImageLocation.ToString)
            Me.AskToSaveImage = False
            _CurrentAngle = 0
        End Sub

        Protected Overrides Sub OnQCComplete(ByVal VehicleId As Integer)
            Dim userResponse As System.Windows.Forms.DialogResult
            Dim pageCount As Integer


            If AreAllPageCropsVisited() = False Then
                MessageBox.Show("Each cropped page must be visited once before marking vehicle for QC Completed.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            pageCount = Processor.GetPageCountWithoutCroppedPage(VehicleId)
            If pageCount > 0 Then
                userResponse = MessageBox.Show(pageCount.ToString() + " Page(s) do not have Retailers assigned." _
                                               + " Are you sure this is correct and want to mark as QC Completed?" _
                                               , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If userResponse = Windows.Forms.DialogResult.No Then Exit Sub
            End If

            userResponse = MessageBox.Show("After Vehicle is marked as QCed, cannot change any information related to it." _
                                           , ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)

            If userResponse = Windows.Forms.DialogResult.OK Then
                Try
                    Processor.MarkVehicleAsQCed(VehicleId)
                    ClearAllInputs()
                    Me.FormState = FormStateEnum.View
                    EnableDisableControls(Me.FormState)
                    ShowHideControls(Me.FormState)
                Catch ex As System.Data.SqlClient.SqlException
                    Trace.TraceError("PublicationIndexQCForm.OnQCComplete():Marking Vehicle as QC Completed. Message=" + ex.Message, New Object() {"VehicleId=", VehicleId, ex})
                Catch ex As Exception
                    Trace.TraceError("PublicationIndexQCForm.OnQCComplete():Marking Vehicle as QC Completed. Uknown exception. Message=" + ex.Message, New Object() {"VehicleId=", VehicleId, ex})
                End Try
            End If

        End Sub

        ''' <summary>
        ''' Reloads vehicle information and Page image. Useed mainly to reload main image and vehicle information
        ''' to undo last image manipulation.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub OnRefreshVehicleInformation(ByVal vehicleId As Integer)
            Dim clearForPageCrop As Boolean
            Dim pageNumber As Integer


            If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
                pageNumber = -1
            End If

            'User can create page crop record only when its FSI.
            If Me.FormState = FormStateEnum.Insert Then clearForPageCrop = True

            'Me.FormState = FormStateEnum.View
            OnFindVehicle(vehicleId, EventInitiatorEnum.RefreshButton)
            RefreshPageInformation()

            If pageNumber > 0 Then
                OnFindPage(vehicleId, pageNumber)
                RefreshPageInformation()
            End If

            If clearForPageCrop Then
                Me.FormState = FormStateEnum.Insert
                ClearInputs(True, False)
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
            End If

            System.IO.File.Delete(filePath)

        End Sub

        Protected Overrides Sub OnResequencePageImages(ByVal vehicleId As Integer)
            Dim userResponse As DialogResult
            Dim resequencedImages() As String
            Dim resequenceScr As ResequenceForm


            resequenceScr = New ResequenceForm

            resequenceScr.Init(FormStateEnum.View)
            resequenceScr.ApplyUserCredentials()
            resequenceScr.PageImageFolderPath = Processor.GetPageImageFolderPath(vehicleId)
            resequenceScr.LoadPageInformation(vehicleId)
            userResponse = resequenceScr.ShowDialog(Me)

            If userResponse = Windows.Forms.DialogResult.OK Then
                Processor.LoadVehiclePagesInformation(vehicleId)
            End If

            resequenceScr.Dispose()
            resequenceScr = Nothing
            resequencedImages = Nothing

        End Sub

#End Region



        Private Function AreAllPageCropsVisited() As Boolean

            Return (Me.PageCropVisitLog.Count > 0 _
                    AndAlso Processor.Data.PageCrop.Count > 0 _
                    AndAlso Me.PageCropVisitLog.Count = Processor.Data.PageCrop.Count)

        End Function

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

        Private Sub indexingCompleteButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles indexingCompleteButton.Click
            Dim vehicleId As Integer
            Dim unsizedcroppedPageImageFolderPath, imageFiles(), imageFileName As String
            Dim missingFiles As System.Collections.Generic.List(Of QCDataSet.PageCropRow)
            Dim fileNameQuery As System.Collections.Generic.IEnumerable(Of String)


            If Integer.TryParse(Me.vehicleIdValueLabel.Text, vehicleId) = False Then
                MessageBox.Show("You have to load vehicle to mark it as Indexing Complete." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'Because of change in location for croppedPage images, now croppedPageImageId doesn't matter.
            unsizedcroppedPageImageFolderPath = Processor.GetCroppedPageImageFolderPath(vehicleId, 0)
            If System.IO.Directory.Exists(unsizedcroppedPageImageFolderPath) = False Then
                MessageBox.Show("Cannot mark vehicle as Indexed. Vehicle image folder not found." _
                                + Environment.NewLine + "Expected Location: " + unsizedcroppedPageImageFolderPath _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            'User must have loaded vehicle on this screen, but just to make sure that
            'we have latest information from database.
            Try
                Processor.LoadVehiclePageCropInformation(vehicleId)
            Catch ex As System.ApplicationException
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            If Processor.Data.PageCrop.Count = 0 Then
                MessageBox.Show("Cannot mark vehicle as Indexing Completed." + Environment.NewLine _
                                + "Vehicle must have cropped page images to complete its indexing. There is no " _
                                + "cropped page image information available for vehicle " + vehicleId.ToString() _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If AreAllPageCropsVisited() = False Then
                MessageBox.Show("Each cropped page must be visited once before marking vehicle for Indexing Completed.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ''Because of change in location for croppedPage images, now croppedPageImageId doesn't matter.
            'unsizedcroppedPageImageFolderPath = Processor.GetCroppedPageImageFolderPath(vehicleId, 0)
            imageFiles = System.IO.Directory.GetFiles(unsizedcroppedPageImageFolderPath, "???????.jpg")
            'unsizedcroppedPageImageFolderPath = Nothing

            'compare file names against database.
            missingFiles = New System.Collections.Generic.List(Of QCDataSet.PageCropRow)

            For i As Integer = 0 To Processor.Data.PageCrop.Count - 1
                If i >= imageFiles.Length Then
                    missingFiles.Add(Processor.Data.PageCrop(i))
                    Continue For
                End If

                imageFileName = Processor.Data.PageCrop(i).CropImageName + ".jpg"
                fileNameQuery = From file In imageFiles _
                                Where file.ToUpper().EndsWith(imageFileName.ToUpper()) _
                                Select file

                If fileNameQuery.Count = 0 Then
                    missingFiles.Add(Processor.Data.PageCrop(i))
                End If

                fileNameQuery = Nothing
                imageFileName = Nothing
            Next

            If missingFiles.Count > 0 Then
                ShowMissingFiles(missingFiles, unsizedcroppedPageImageFolderPath)
                missingFiles.Clear()
                missingFiles = Nothing
                Exit Sub
            End If

            Try
                Processor.UpdateSPReviewStatus(vehicleId, FORM_NAME)
                Processor.MarkedVehicleAsIndexingComplete(vehicleId)
            Catch ex As System.ApplicationException
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Catch ex As Exception
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            MessageBox.Show("Vehicle is marked successfully as Indexing Complete." _
                            , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            ClearAllInputs()
            Me.FormState = FormStateEnum.View
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)
            findVehicleIdTextBox.Focus()
            findVehicleIdTextBox.Text = vehicleId.ToString()
            findVehicleIdTextBox.SelectAll()

        End Sub

        Private Sub sizeIdMediaLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sizeIdMediaLabel.Click
            Dim isROP As Boolean, vehicleId, pageNumber As Integer


            If vehicleIdValueLabel.Text.Length = 0 Then
                MessageBox.Show("No vehicle is loaded at present.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                sizeIdMediaLabel.Text = String.Empty
                Exit Sub
            ElseIf Integer.TryParse(currentPageLabel.Text, pageNumber) = False OrElse pageNumber < 1 Then
                MessageBox.Show("Unable to identify current page. Can not change page size.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            isROP = Not (sizeIdMediaLabel.Text = "ROP")
            vehicleId = CType(vehicleIdValueLabel.Text, Integer)

            If Processor.HasCroppedAdImages(vehicleId, pageNumber) Then
                MessageBox.Show("Can not set page image size for page having cropped page images." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If isROP Then
                Processor.SetVehiclePageSizeForROP(vehicleId, pageNumber)
            Else
                Processor.SetVehiclePageSizeForMagazine(vehicleId, pageNumber)
            End If

            pageSizeLabel.Text = GetPageSizeText(vehicleId, pageNumber)
            sizeIdMediaLabel.Text = Processor.GetPageSizeMediaText(vehicleId, pageNumber)

        End Sub

        Private Sub sizeIdMediaLabel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sizeIdMediaLabel.TextChanged

            sizeIdMediaLabel2.Text = sizeIdMediaLabel.Text

        End Sub

        Private Sub sizeIdMediaLabel2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sizeIdMediaLabel2.TextChanged

            Me.pageSizeROPButton.Enabled = Not (sizeIdMediaLabel.Text.ToUpper() = "ROP")
            Me.pageSizeMagazineButton.Enabled = Not (sizeIdMediaLabel.Text.ToUpper() = "MAG")

        End Sub

        Private Sub pageSizeROPButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pageSizeROPButton.Click
            Dim vehicleId, pageNumber As Integer


            If vehicleIdValueLabel.Text.Length = 0 Then
                MessageBox.Show("No vehicle is loaded at present.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                sizeIdMediaLabel.Text = String.Empty
                Exit Sub
            ElseIf Integer.TryParse(currentPageLabel.Text, pageNumber) = False OrElse pageNumber < 1 Then
                MessageBox.Show("Unable to identify current page. Can not change page size.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            vehicleId = CType(vehicleIdValueLabel.Text, Integer)

            If Processor.HasCroppedAdImages(vehicleId, pageNumber) Then
                MessageBox.Show("Can not set page image size for page having cropped page images." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Processor.SetVehiclePageSizeForROP(vehicleId, pageNumber)
            pageSizeLabel.Text = GetPageSizeText(vehicleId, pageNumber)
            sizeIdMediaLabel.Text = Processor.GetPageSizeMediaText(vehicleId, pageNumber)

        End Sub

        Private Sub pageSizeMagazineButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pageSizeMagazineButton.Click
            Dim vehicleId, pageNumber As Integer


            If vehicleIdValueLabel.Text.Length = 0 Then
                MessageBox.Show("No vehicle is loaded at present.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                sizeIdMediaLabel.Text = String.Empty
                Exit Sub
            ElseIf Integer.TryParse(currentPageLabel.Text, pageNumber) = False OrElse pageNumber < 1 Then
                MessageBox.Show("Unable to identify current page. Can not change page size.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            vehicleId = CType(vehicleIdValueLabel.Text, Integer)

            If Processor.HasCroppedAdImages(vehicleId, pageNumber) Then
                MessageBox.Show("Can not set page image size for page having cropped page images." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Processor.SetVehiclePageSizeForMagazine(vehicleId, pageNumber)
            pageSizeLabel.Text = GetPageSizeText(vehicleId, pageNumber)
            sizeIdMediaLabel.Text = Processor.GetPageSizeMediaText(vehicleId, pageNumber)

        End Sub



        Private Sub PublicationIndexQCForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

            findVehicleIdTextBox.Focus()

        End Sub

        Private Sub PublicationIndexQCForm_FormInitialized() Handles Me.FormInitialized

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub PublicationIndexQCForm_InitializingForm() Handles Me.InitializingForm

            Me.StatusMessage = "Loading information. This may take some time. Please wait..."

        End Sub

        Private Sub PublicationIndexQCForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            Dim vehicleId As Integer


            If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) Then
                e.Cancel = Not AskForContinueWithoutIndexingCompleted(vehicleId)
            Else
                If e.CloseReason = CloseReason.UserClosing And isClosedByButton = False Then
                    If (MessageBox.Show("Are you sure you want to close this form?", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                        e.Cancel = True
                    End If
                End If
            End If

        End Sub

        Private Sub m_publicationIndexQCProcessor_InvalidVehicleStatus(ByVal vehicleId As Integer, ByVal statusText As String) Handles m_publicationIndexQCProcessor.InvalidVehicleStatus

            Me.StatusMessage = String.Empty

            Me.FormState = FormStateEnum.View

            ClearAllInputs()
            RemoveAllErrorProviders()
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

            addButton.Enabled = False
            vehiclePageCropButton.Enabled = False
            imageNavigationGroupBox.Enabled = False
            imageSearchGroupBox.Enabled = False
            zoomButton.Enabled = False

            Me.IsPageCropNavigation = False
            vehiclePageCropButton.Text = "Vehicle"

            MessageBox.Show("Vehicle cannot be loaded because it has the Status of: " + statusText _
                            , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Sub

        Private Sub m_publicationIndexQCProcessor_LoadingMarkets() Handles m_publicationIndexQCProcessor.LoadingMarkets

            Me.StatusMessage = "Loading markets..."

        End Sub

        Private Sub m_publicationIndexQCProcessor_LoadingPublications() Handles m_publicationIndexQCProcessor.LoadingPublications

            Me.StatusMessage = "Loading publications..."

        End Sub

        Private Sub m_publicationIndexQCProcessor_LoadingRetailers() Handles m_publicationIndexQCProcessor.LoadingRetailers

            Me.StatusMessage = "Loading retailers..."

        End Sub

        Private Sub m_publicationIndexQCProcessor_LoadingVehicle(ByVal vehicleId As Integer, ByRef Cancel As Boolean) Handles m_publicationIndexQCProcessor.LoadingVehicle
            Dim loadedVehicleId As Integer


            If Integer.TryParse(vehicleIdValueLabel.Text, loadedVehicleId) Then
                If vehicleId <> loadedVehicleId AndAlso AskForContinueWithoutIndexingCompleted(loadedVehicleId) = False Then
                    Cancel = True
                    Exit Sub
                End If
            End If

            ClearAllInputs()
            RemoveAllErrorProviders()
            Me.IsPageCropNavigation = False
            vehiclePageCropButton.Text = "Vehicle"

            Me.StatusMessage = "Searching for vehicle information..."

        End Sub

        Private Sub m_publicationIndexQCProcessor_LoadingVehiclePageCropInformation() Handles m_publicationIndexQCProcessor.LoadingVehiclePageCropInformation

            Me.StatusMessage = "Loading cropped pages information..."

        End Sub

        Private Sub m_publicationIndexQCProcessor_LoadingVehiclePagesInformation() Handles m_publicationIndexQCProcessor.LoadingVehiclePagesInformation

            Me.StatusMessage = "Loading vehicle pages' information."

        End Sub

        Private Sub m_publicationIndexQCProcessor_MarketsLoaded() Handles m_publicationIndexQCProcessor.MarketsLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_publicationIndexQCProcessor_PublicationsLoaded() Handles m_publicationIndexQCProcessor.PublicationsLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_publicationIndexQCProcessor_RetailersLoaded() Handles m_publicationIndexQCProcessor.RetailersLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_publicationIndexQCProcessor_SizeNotFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_publicationIndexQCProcessor.SizeNotFound
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

        Private Sub m_publicationIndexQCProcessor_VehicleLoaded(ByVal vehicleRow As QCDataSet.vwPublicationEditionRow) Handles m_publicationIndexQCProcessor.VehicleLoaded
            Dim vehicleId As Integer
            Dim imageFolder As String


            vehicleId = vehicleRow.VehicleId

            If vehicleRow.IsScanDtNull() Or vehicleRow.IsScannedByIdNull() Then
                MessageBox.Show("Vehicle " + vehicleId.ToString() + " has not been scanned." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            ShowVehicleInformation(vehicleRow)

            Processor.LoadVehiclePagesInformation(vehicleId)
            If Processor.Data.Page.Count > 0 Then
                imageFolder = Processor.GetPageImageFolderPath(vehicleId)
                ShowImage(vehicleId, 1)
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
                sizeIdMediaLabel.Text = Processor.GetPageSizeMediaText(vehicleId, 1)
            End If

            RefreshPageInformation()
            pageCropValueLabel.Text = Processor.GetCroppedPageCount(vehicleId).ToString()

            Me.FormState = FormStateEnum.View
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)
            Me.AskToSaveImage = False

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_publicationIndexQCProcessor_VehicleNotFound(ByVal vehicleId As Integer) Handles m_publicationIndexQCProcessor.VehicleNotFound

            Me.StatusMessage = String.Empty

            Me.FormState = FormStateEnum.View

            ClearAllInputs()
            RemoveAllErrorProviders()
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

            addButton.Enabled = False
            vehiclePageCropButton.Enabled = False
            imageNavigationGroupBox.Enabled = False
            imageSearchGroupBox.Enabled = False
            zoomButton.Enabled = False

            Me.IsPageCropNavigation = False
            vehiclePageCropButton.Text = "Vehicle"

            MessageBox.Show("Vehicle " & CType(vehicleId, String) & " not found.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Sub

        Private Sub m_publicationIndexQCProcessor_VehiclePageCropInformationLoaded() Handles m_publicationIndexQCProcessor.VehiclePageCropInformationLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_publicationIndexQCProcessor_VehiclePagesInformationLoaded() Handles m_publicationIndexQCProcessor.VehiclePagesInformationLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub PublicationIndexQCForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

      
    End Class


End Namespace