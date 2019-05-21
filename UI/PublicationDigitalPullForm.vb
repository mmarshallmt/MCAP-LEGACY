Imports System.Drawing.Drawing2D
Imports System.IO
Namespace UI

    Public Class PublicationDigitalPullForm
        Implements IForm



        Private Const FORM_NAME As String = "Digital Publication Pull"



        Private WithEvents m_processor As UI.Processors.PublicationDigitalPull

        'Draw Objects in the Image
        Private MyRect As Rectangle
        Private MyPen As Pen


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property Processor() As UI.Processors.PublicationDigitalPull
            Get
                Return m_processor
            End Get
        End Property



        Protected Overrides Sub ShowHideControls(ByVal formStatus As FormStateEnum)

            vehiclePageCropButton.Visible = False
            imageRotationGroupBox.Visible = False
            keepRectangleButton.Visible = False
            removeRectangleButton.Visible = False
            saveImageButton.Visible = False
            refreshButton.Visible = False
            deleteImageButton.Visible = False
            resequenceButton.Visible = False

        End Sub

        Protected Overrides Sub EnableDisableControls(ByVal formStatus As FormStateEnum)

            Select Case formStatus
                Case FormStateEnum.Insert, FormStateEnum.Edit
                    Me.yesButton.Enabled = True
                    Me.noButton.Enabled = True
                    Me.completeButton.Enabled = True

                Case FormStateEnum.View
                    Me.yesButton.Enabled = False
                    Me.noButton.Enabled = False
                    Me.completeButton.Enabled = False
            End Select

        End Sub

        Protected Overrides Sub ClearAllInputs()

            Me.vehicleIdValueLabel.Text = String.Empty
            Me.marketComboBox.SelectedValue = DBNull.Value
            Me.publicationComboBox.SelectedValue = DBNull.Value
            Me.languageComboBox.SelectedValue = DBNull.Value
            Me.adDateTypeInDatePicker.Value = Nothing

            Me.currentPageLabel.Text = "0"
            Me.totalPagesLabel.Text = "0"
            Me.pageTypeValueLabel.Text = String.Empty
            Me.pageSizeLabel.Text = "00.00 X 00.00"
            Me.findImageTextBox.Clear()
            Me.currentStatusValueLabel.Text = String.Empty

            ''ClearImage()
            Processor.ClearImageCollection()
            RefreshPageInformation()

        End Sub

        Protected Overrides Sub RefreshPageInformation()
            Dim pageNumber, totalPages As Integer


            'totalPagesLabel.Text = Processor.Data.Page.Count.ToString()
            totalPagesLabel.Text = Processor.ImageFileCount.ToString()

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
            Dim imageFilePath As String


            imageFilePath = Processor.GetPageImageFilePath(pageNumber)

            Try
                ShowImage(imageFilePath)
            Catch ex As ApplicationException
                Trace.TraceError("PublicationDigitalPull.ShowImage(): Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, "PageNumber=", pageNumber, "ImageFilePath=", imageFilePath, ex})
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                Trace.TraceError("PublicationDigitalPull.ShowImage(): Unknown error. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, "PageNumber=", pageNumber, "ImageFilePath=", imageFilePath, ex})
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

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
            Dim pages As System.Data.EnumerableRowCollection(Of PublicationPullDataSet.PageRow)


            pages = From p In Processor.Data.Page _
                    Where p.VehicleId = vehicleId AndAlso p.ReceivedOrder = pageNumber _
                          AndAlso p.IsSizeIDNull() = False _
                    Select p

            If pages.Count() < 1 OrElse pages(0).IsSizeTextNull() Then Return Nothing

            pageSizeText = pages(0).SizeText

            pages = Nothing

            Return pageSizeText

        End Function

        Private Sub ShowVehicleInformation(ByVal vehicleRow As MCAP.PublicationPullDataSet.vwPublicationEditionRow)

            vehicleIdValueLabel.Text = vehicleRow.VehicleId.ToString()
            marketComboBox.SelectedValue = vehicleRow.MktId
            publicationComboBox.SelectedValue = vehicleRow.PublicationId
            languageComboBox.SelectedValue = vehicleRow.LanguageId
            adDateTypeInDatePicker.Value = vehicleRow.BreakDt

            If vehicleRow.IsPullDtNull() = False _
              AndAlso vehicleRow.IsPullPageCountNull() _
            Then
                noAdsCheckBox.Checked = True
            Else
                noAdsCheckBox.Checked = False
            End If

        End Sub

        Private Function AreInputsValid() As Boolean
            Dim areAllValid As Boolean


            areAllValid = True

            If marketComboBox.SelectedValue Is Nothing Then
                SetErrorProvider(marketComboBox, "Select market from drop down list.")
                areAllValid = False
            Else
                RemoveErrorProvider(marketComboBox)
            End If

            If publicationComboBox.SelectedValue Is Nothing Then
                SetErrorProvider(publicationComboBox, "Select newspaper from drop down list.")
                areAllValid = False
            Else
                RemoveErrorProvider(publicationComboBox)
            End If

            If languageComboBox.SelectedValue Is Nothing Then
                SetErrorProvider(languageComboBox, "Select language from drop down list.")
                areAllValid = False
            Else
                RemoveErrorProvider(languageComboBox)
            End If

            If adDateTypeInDatePicker.Value.HasValue = False Then
                SetErrorProvider(adDateLabel, "Provide validate date as ad date.")
                areAllValid = False
            Else
                RemoveErrorProvider(adDateLabel)
            End If

            Return areAllValid

        End Function


        Protected Overrides Sub OnExitClicked()

            Me.Close()

        End Sub

        Private Sub splitImageButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles splitImageButton.Click
            Dim isPageImageSplit As Boolean
            Dim currentPage, vehicleId, pixelAdjustment As Integer
            Dim croppedPageImagePath As String
            Dim userResponse As System.Windows.Forms.DialogResult
            Dim cropRectangle As System.Drawing.RectangleF
            Dim cropImageSize As System.Drawing.Size


            If vehicleIdValueLabel.Text.Trim().Length = 0 Then
                MessageBox.Show("Load vehicle to Split page image.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub

 
            ElseIf Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
                MessageBox.Show("Unable to identify current Vehicle Id.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf Integer.TryParse(Me.currentPageLabel.Text, currentPage) = False Then
                MessageBox.Show("Unable to identify current page number.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            userResponse = MessageBox.Show("Are you sure, this is a double truck page image and you want to split this image into two parts?" _
                                           , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

            croppedPageImagePath = Processor.GetPageImageFilePath(currentPage)
            If Processor.HasPagesDefined(vehicleId) Then
                isPageImageSplit = Processor.AddSplittedPageImageInformationInDatabase(vehicleId, currentPage)
            Else
                isPageImageSplit = True
            End If

            If isPageImageSplit = True Then
                'Adjust Collection control for new split image
                cropImageSize = Processor.InsertSplitImageInformation(currentPage)
                RefreshPageInformation()

                If (cropImageSize.Width Mod 2) = 0 Then
                    pixelAdjustment = 0
                Else
                    pixelAdjustment = 1
                End If

                'Copy and Save split image
                cropImageSize.Width = (cropImageSize.Width \ 2) + pixelAdjustment
                cropRectangle = New System.Drawing.RectangleF(0, 0, cropImageSize.Width, cropImageSize.Height)

                currentPage += 1
                OnNavigateToNextImage(vehicleId, currentPage)

                cropImageSize.Width = cropImageSize.Width - pixelAdjustment
                cropRectangle = New System.Drawing.RectangleF(Convert.ToSingle(cropImageSize.Width + pixelAdjustment + 1), 0, cropImageSize.Width, cropImageSize.Height)
          
                currentPage -= 1
                OnNavigateToPreviousImage(vehicleId, currentPage)

                MessageBox.Show("Image page has been split successfully.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End Sub

        Protected Overrides Sub OnFindVehicle(ByVal vehicleId As Integer, ByVal eventInitiator As EventInitiatorEnum)

            Me.FormState = FormStateEnum.View

            ClearAllInputs()
            RemoveAllErrorProviders()
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

            If Processor.HasCroppedPagesDefined(vehicleId) Then
                MessageBox.Show("Vehicle is having cropped pages. Can not pull such vehicles.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Processor.LoadVehicle(vehicleId, FORM_NAME)

        End Sub

        Protected Overrides Sub OnDrawRectangle(ByVal img As Image, ByVal xAxis As Integer, ByVal yAxis As Integer, ByVal xWidth As Integer, ByVal xHeight As Integer)
            Dim strMedia As String = mediaComboBox.Text
            Me.IsZoomedIn = False
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
            myGraphics.DrawRectangle(MyPen, MyRect)
            ImageDisplay.Image = ImageDisplay.Image
            Me.AskToSaveImage = True
        End Sub


#Region " Page Image Navigation "


        Protected Overrides Sub OnNavigateToFirstImage(ByVal vehicleId As Integer)
            Dim imageFolder As String


            ShowImage(vehicleId, 1)

            currentPageLabel.Text = "1"
            pageSizeLabel.Text = GetPageSizeText(vehicleId, 1)
            currentStatusValueLabel.Text = Processor.GetCurrentPageImageRequirementStatusText(1)
            imageFolder = Nothing
        End Sub

        Protected Overrides Sub OnNavigateToPreviousImage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            Dim imageFolder As String


            ShowImage(vehicleId, pageNumber)

            currentPageLabel.Text = pageNumber.ToString()
            pageSizeLabel.Text = GetPageSizeText(vehicleId, pageNumber)
            currentStatusValueLabel.Text = Processor.GetCurrentPageImageRequirementStatusText(pageNumber)
            imageFolder = Nothing
        End Sub

        Protected Overrides Sub OnNavigateToNextImage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            Dim imageFolder As String


            ShowImage(vehicleId, pageNumber)

            currentPageLabel.Text = pageNumber.ToString()
            pageSizeLabel.Text = GetPageSizeText(vehicleId, pageNumber)
            currentStatusValueLabel.Text = Processor.GetCurrentPageImageRequirementStatusText(pageNumber)
            imageFolder = Nothing
        End Sub

        Protected Overrides Sub OnNavigateToLastImage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            Dim imageFolder As String


            ShowImage(vehicleId, pageNumber)

            currentPageLabel.Text = pageNumber.ToString()
            pageSizeLabel.Text = GetPageSizeText(vehicleId, pageNumber)
            currentStatusValueLabel.Text = Processor.GetCurrentPageImageRequirementStatusText(pageNumber)
            imageFolder = Nothing
        End Sub

        Protected Overrides Sub OnFindPage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)
            Dim imageFolder As String


            ShowImage(vehicleId, pageNumber)

            findImageTextBox.Text = String.Empty
            currentPageLabel.Text = pageNumber.ToString()
            pageSizeLabel.Text = GetPageSizeText(vehicleId, pageNumber)
            currentStatusValueLabel.Text = Processor.GetCurrentPageImageRequirementStatusText(pageNumber)
            imageFolder = Nothing
        End Sub

#End Region


#Region " IForm Implementation "


        Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
        Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied

        Public Event InitializingForm() Implements IForm.InitializingForm
        Public Event FormInitialized() Implements IForm.FormInitialized


        Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

        End Sub

        Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

            Me.SuspendLayout()

            RaiseEvent InitializingForm()

            Me.FormState = formStatus

            m_processor = New UI.Processors.PublicationDigitalPull()
            Processor.Initialize()
            Processor.LoadDataSet()

            marketComboBox.ValueMember = "MktId"
            marketComboBox.DisplayMember = "Descrip"
            marketComboBox.DataSource = Processor.Data.Mkt

            publicationComboBox.ValueMember = "PublicationId"
            publicationComboBox.DisplayMember = "Descrip"
            publicationComboBox.DataSource = Processor.Data.Publication

            languageComboBox.ValueMember = "LanguageId"
            languageComboBox.DisplayMember = "Descrip"
            languageComboBox.DataSource = Processor.Data.Language
            languageComboBox.SelectedValue = DBNull.Value

            exitButton.Location = zoomButton.Location
            zoomButton.Location = keepRectangleButton.Location

            ShowHideControls(formStatus)
            EnableDisableControls(formStatus)
            ClearAllInputs()

            RaiseEvent FormInitialized()

            Me.ResumeLayout()

        End Sub


#End Region


        Private Sub yesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles yesButton.Click
            Dim pageNumber As Integer


            If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
                MessageBox.Show("Can not mark page. Unable to identify page number.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf pageNumber < 1 Then
                MessageBox.Show("There is no page to mark. There has to be at least one page to mark it.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Try
                Processor.SetCurrentPageImageRequirementStatus(pageNumber, True)
                currentStatusValueLabel.Text = Processor.GetCurrentPageImageRequirementStatusText(pageNumber)
            Catch ex As System.ApplicationException
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                Trace.TraceError("PublicationDigitalPullForm.yesButton_Click(): Unknown error. Message=" + ex.Message, New Object() {"PageNumber=", pageNumber})
                MessageBox.Show("Unable to mark page as required. Unknown error has occurred.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        Private Sub noButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles noButton.Click
            Dim pageNumber As Integer
            Dim userResponse As DialogResult


            If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
                MessageBox.Show("Can not mark page. Unable to identify page number.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf pageNumber < 1 Then
                MessageBox.Show("There is no page to mark. There has to be at least one page to mark it.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            userResponse = MessageBox.Show("Are you sure, this page is not required?", ProductName _
                                           , MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                           , MessageBoxDefaultButton.Button2)

            If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

            Try
                Processor.SetCurrentPageImageRequirementStatus(pageNumber, False)
                currentStatusValueLabel.Text = Processor.GetCurrentPageImageRequirementStatusText(pageNumber)
            Catch ex As System.ApplicationException
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                Trace.TraceError("PublicationDigitalPullForm.yesButton_Click(): Unknown error. Message=" + ex.Message, New Object() {"PageNumber=", pageNumber})
                MessageBox.Show("Unable to mark page as required. Unknown error has occurred.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        Private Sub completeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles completeButton.Click
            Dim pageCount, pullStatusId, vehicleId As Integer
            Dim userResponse As DialogResult
            Dim updateRow As PublicationPullDataSet.vwPublicationEditionRow


            pageCount = Processor.GetRequiredPageCount()

            If noAdsCheckBox.Checked Then
                userResponse = MessageBox.Show("Are you sure, this publication should be marked as No Ads?", ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

                If pageCount > 0 Then
                    MessageBox.Show("For No Ads publications, none of the page should be marked as required.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

            ElseIf pageCount < 1 Then
                MessageBox.Show("None of the page is marked as required. At least one page should be marked as required to mark this vehicle as pulled.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If AreInputsValid() = False Then Exit Sub

            updateRow = Processor.Data.vwPublicationEdition(0)

            If updateRow.BreakDt <> adDateTypeInDatePicker.Value.Value Then
                userResponse = MessageBox.Show("Ad date is changed from " + updateRow.BreakDt.ToString("MM/dd/yyyy") _
                                               + " to " + adDateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy") _
                                               + ". Is this correct?", ProductName, MessageBoxButtons.YesNo _
                                               , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If userResponse = Windows.Forms.DialogResult.No Then Exit Sub
            End If

            pullStatusId = Processor.GetVehicleStatusId("Pulled")
            vehicleId = updateRow.VehicleId

            updateRow.BeginEdit()
            updateRow.LanguageId = CType(languageComboBox.SelectedValue, Integer)
            updateRow.BreakDt = adDateTypeInDatePicker.Value.Value
            If noAdsCheckBox.Checked Then
                updateRow.SetPullPageCountNull()
            Else
                updateRow.PullPageCount = pageCount
            End If
            updateRow.PulledById = Processor.UserID
            updateRow.StatusID = pullStatusId
            updateRow.FormName = FORM_NAME
            updateRow.EndEdit()

            Dim statusMsg As UI.Controls.StatusMessageForm = New UI.Controls.StatusMessageForm()
            statusMsg.MessageText = "Updating Vehicle and Pages information in database. Please wait..."
            statusMsg.Show(Me)

            Try
                Processor.Synchronize(FORM_NAME)
                If noAdsCheckBox.Checked Then
                    statusMsg.MessageText = "Marking whole publication as No Ads. Please wait..."
                    Processor.MarkWholePublicationsAsNoAds(updateRow.MktId, updateRow.PublicationId, updateRow.BreakDt, FORM_NAME)
                    statusMsg.MessageText = "Removing page images(except first page) from Vehicle folder. Please wait..."
                    Processor.RemoveNoAdsPublicationPageImages()
                    statusMsg.Close()
                Else
                    Processor.LoadVehiclePagesInformation(vehicleId)
                    statusMsg.MessageText = "Updating page image file names and image file dimensions. Please wait..."
                    Processor.UpdatePageSizesInPixel(vehicleId, updateRow.CreateDt)
                    statusMsg.Close()
                End If
                MessageBox.Show("Vehicle updated successfully.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Data.SqlClient.SqlException
                Trace.TraceError("PublicationDigitalPullForm.completeButton_Click()", New Object() {ex})
                MessageBox.Show("Vehicle information is not updated. Error has occurred.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                Trace.TraceError("PublicationDigitalPullForm.completeButton_Click()", New Object() {ex})
                MessageBox.Show("Vehicle information is not updated. Unknown error has occurred.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                statusMsg.Close()
                statusMsg.Dispose()
                statusMsg = Nothing
            End Try

            Me.FormState = FormStateEnum.View
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)
            ClearAllInputs()

            Me.findVehicleIdTextBox.Focus()
            Me.findVehicleIdTextBox.SelectAll()

        End Sub

#Region " requiredRetailersDataGridView related event handlers "


        Private Sub SetAutoFilterHeader()

            ' Continue only if the data source has been set.
            If requiredRetailersDataGridView.DataSource Is Nothing Then
                Return
            End If

            ' Add the AutoFilter header cell to each column.
            For Each col As DataGridViewColumn In requiredRetailersDataGridView.Columns
                col.HeaderCell = New  _
                    DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell)
            Next

        End Sub



        ' Displays the drop-down list when the user presses 
        ' ALT+DOWN ARROW or ALT+UP ARROW.
        Private Sub requiredRetailersDataGridView_KeyDown _
            (ByVal sender As Object, ByVal e As KeyEventArgs) _
            Handles requiredRetailersDataGridView.KeyDown


            If e.Alt AndAlso (e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Up) Then

                Dim filterCell As DataGridViewAutoFilterColumnHeaderCell = _
                    TryCast(requiredRetailersDataGridView.CurrentCell.OwningColumn.HeaderCell,  _
                    DataGridViewAutoFilterColumnHeaderCell)
                If filterCell IsNot Nothing Then
                    filterCell.ShowDropDownList()
                    e.Handled = True
                End If

            End If

        End Sub

        ' Updates the filter status label. 
        Private Sub requiredRetailersDataGridView_DataBindingComplete _
            (ByVal sender As Object, ByVal e As DataGridViewBindingCompleteEventArgs) _
            Handles requiredRetailersDataGridView.DataBindingComplete


            Dim filterStatus As String = DataGridViewAutoFilterColumnHeaderCell _
                .GetFilterStatus(requiredRetailersDataGridView)


        End Sub


#End Region

        ''' <summary>
        ''' Prepares Required retailers datagrid
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub PrepareRequiredRetailersDataGridView()
            Dim columnCounter As Integer


            requiredRetailersDataGridView.SuspendLayout()

            For columnCounter = 0 To requiredRetailersDataGridView.Columns.Count - 1
                requiredRetailersDataGridView.Columns(columnCounter).Visible = False
            Next

            With Me.requiredRetailersDataGridView
                '.ColumnHeadersVisible = False
                .RowHeadersVisible = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                '.Columns("Priority").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns("Priority").Visible = True
                .Columns("Descrip").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Columns("Descrip").Visible = True
            End With

            requiredRetailersDataGridView.ResumeLayout(False)

        End Sub

        ''' <summary>
        ''' Loads list of retailers from RetPublicationCoverage table having non-priority 1, based on 
        ''' supplied market and media.
        ''' </summary>
        ''' <param name="publicationId"></param>
        ''' <remarks></remarks>
        Private Sub ShowRetailers(ByVal publicationId As Integer)

            Me.Cursor = Cursors.WaitCursor
            Me.StatusMessage = "Loading retailers. This may take some time. Please wait..."

            Processor.LoadRetailers(publicationId)

            Me.StatusMessage = String.Empty
            Me.Cursor = Cursors.Default

        End Sub

#Region " Processor EventHandlers "


        Private Sub m_processor_VehicleLoaded(ByVal vehicleRow As PublicationPullDataSet.vwPublicationEditionRow) Handles m_processor.VehicleLoaded
            Dim vehicleId As Integer


            ClearAllInputs()

            vehicleId = Processor.Data.vwPublicationEdition(0).VehicleId
            ShowVehicleInformation(Processor.Data.vwPublicationEdition(0))

            ShowRetailers(CType(publicationComboBox.SelectedValue, Integer))
            requiredRetailersDataGridView.DataSource = New BindingSource(Processor.Data, "Ret")
            SetAutoFilterHeader()
            PrepareRequiredRetailersDataGridView()

            Try
                Dim hasPages As Boolean
                hasPages = Processor.HasPagesDefined(vehicleId)
                Processor.LoadVehiclePagesInformation(vehicleId)
            Catch ex As System.Data.SqlClient.SqlException
                Trace.TraceError("PublicationDigitalPullForm.m_processor_VehicleLoaded(): Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, ex})
                MessageBox.Show("Unable to determine whether vehicle has pages defined or not.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                Trace.TraceError("PublicationDigitalPullForm.m_processor_VehicleLoaded(): Unknown error. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, ex})
                MessageBox.Show("Unable to determine whether vehicle has pages defined or not. Unknown error has occurred.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Try
                Processor.PreparePageCollection(vehicleId, Processor.Data.vwPublicationEdition(0).CreateDt)
            Catch ex As System.ApplicationException
                Trace.TraceError("PublicationDigitalPullForm.m_processor_VehicleLoaded(): Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, ex})
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                Trace.TraceError("PublicationDigitalPullForm.m_processor_VehicleLoaded(): Unknown error. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, ex})
                MessageBox.Show("Unable to get list of page image files from file system. Unknown error has occurred.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            If Processor.ImageFileCount > 0 Then OnNavigateToFirstImage(vehicleId)
            RefreshPageInformation()

            Me.FormState = FormStateEnum.Edit
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

        End Sub


#End Region


    End Class

End Namespace
