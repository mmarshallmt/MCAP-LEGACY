Namespace UI

    Public Class PublicationCheckInForm
        Implements IForm


        Private Const FORM_NAME As String = "Publication Check-In"
        Private Const MARKET_FOR_MAGAZINES As String = "N/A"


        Private m_isshippingRequired As Boolean
        Private WithEvents m_publicationCheckInProcessor As Processors.PublicationCheckIn
        Private m_isWrongVersion As Boolean
        Private isClosedByButton As Boolean = False



        Private ReadOnly Property Processor() As Processors.PublicationCheckIn
            Get
                Return m_publicationCheckInProcessor
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets flag indicating whether selected sender requires shipping information or not.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Property IsShippingRequired() As Boolean
            Get
                Return m_isshippingRequired
            End Get
            Set(ByVal value As Boolean)
                m_isshippingRequired = value
            End Set
        End Property





        ''' <summary>
        ''' Clears all inputs on form.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub ClearAllInputs()
            MyBase.ClearAllInputs()

            senderComboBox.SelectedValue = DBNull.Value
            marketComboBox.SelectedValue = DBNull.Value
            newspaperComboBox.SelectedValue = DBNull.Value
            languageComboBox.SelectedValue = DBNull.Value
            checkInMonthCalendar.SetDate(DateTime.Today)
            breakDateListBox.Items.Clear()
            weightTextBox.Clear()
            searchTextBox.Clear()

        End Sub

        ''' <summary>
        ''' Enables or Disables controls based on supplied value of formStatus.
        ''' </summary>
        ''' <param name="formStatus"></param>
        ''' <remarks></remarks>
        Protected Overrides Sub EnableDisableControls(ByVal formStatus As FormStateEnum)
            MyBase.EnableDisableControls(formStatus)

            Select Case formStatus
                Case FormStateEnum.Insert
                    senderComboBox.Enabled = True
                    marketComboBox.Enabled = True
                    newspaperComboBox.Enabled = True
                    languageComboBox.Enabled = True
                    checkInMonthCalendar.Enabled = True
                    breakDateListBox.Enabled = True
                    weightTextBox.Enabled = True
                    reprintButton.Enabled = (formStatus = FormStateEnum.Edit)
                    newButton.Enabled = True
                    sameButton.Enabled = True
                    clearDatesButton.Enabled = True
                    reprintButton.Enabled = False

                Case FormStateEnum.Edit
                    senderComboBox.Enabled = False
                    marketComboBox.Enabled = False
                    newspaperComboBox.Enabled = False
                    languageComboBox.Enabled = True
                    checkInMonthCalendar.Enabled = False
                    breakDateListBox.Enabled = False
                    weightTextBox.Enabled = False
                    newButton.Enabled = True
                    sameButton.Enabled = True
                    clearDatesButton.Enabled = False
                    reprintButton.Enabled = True

                Case Else
                    senderComboBox.Enabled = False
                    marketComboBox.Enabled = False
                    newspaperComboBox.Enabled = False
                    languageComboBox.Enabled = False
                    checkInMonthCalendar.Enabled = False
                    breakDateListBox.Enabled = False
                    weightTextBox.Enabled = False
                    newButton.Enabled = False
                    sameButton.Enabled = False
                    clearDatesButton.Enabled = False
                    reprintButton.Enabled = True
            End Select

        End Sub

        ''' <summary>
        ''' Removes all error providers from form.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub RemoveAllErrorProviders()
            MyBase.RemoveAllErrorProviders()

            RemoveErrorProvider(senderComboBox)
            RemoveErrorProvider(marketComboBox)
            RemoveErrorProvider(newspaperComboBox)
            RemoveErrorProvider(languageComboBox)
            RemoveErrorProvider(breakDateListBox)
            RemoveErrorProvider(weightTextBox)

        End Sub

        ''' <summary>
        ''' Showing error popup to user based on error texts assigned to each column.
        ''' </summary>
        ''' <param name="validatedRow"></param>
        ''' <remarks></remarks>
        Private Sub ShowErrors(ByVal validatedRow As MCAP.PublicationCheckInDataSet.vwPublicationEditionRow)
            Dim columnCounter As Integer
            Dim errorMessage As System.Text.StringBuilder
            Dim errorCols() As Data.DataColumn


            If validatedRow.HasErrors = False Then Exit Sub

            errorMessage = New System.Text.StringBuilder

            If String.IsNullOrEmpty(validatedRow.RowError) = False Then
                errorMessage.Append(validatedRow.RowError)
            Else
                errorCols = validatedRow.GetColumnsInError()

                errorMessage.Append("Invalid inputs found.")
                errorMessage.Append(Environment.NewLine)
                For columnCounter = 0 To errorCols.Length - 1
                    errorMessage.Append(Environment.NewLine)
                    'errorMessage.Append(errorCols(columnCounter).Caption)
                    'errorMessage.Append(" - ")
                    errorMessage.Append((columnCounter + 1).ToString())
                    errorMessage.Append(". ")
                    errorMessage.Append(validatedRow.GetColumnError(errorCols(columnCounter)))
                Next

                System.Array.Clear(errorCols, 0, errorCols.Length)
            End If

            MessageBox.Show(errorMessage.ToString(), Application.ProductName, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

            errorMessage = Nothing
            errorCols = Nothing

        End Sub

        ''' <summary>
        ''' Validates all inputs on form.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function AreInputsValid() As Boolean
            Dim areAllValid As Boolean = True


            'areAllValid = Me.ValidateChildren(ValidationConstraints.Visible)
            If senderComboBox.SelectedValue Is Nothing _
              OrElse senderComboBox.SelectedIndex < 0 _
            Then
                SetErrorProvider(senderComboBox, "Select sender from drop down.")
                areAllValid = False
            End If

            If marketComboBox.SelectedValue Is Nothing _
              OrElse marketComboBox.SelectedIndex < 0 _
            Then
                SetErrorProvider(marketComboBox, "Select market from drop down.")
                areAllValid = False
            End If

            If newspaperComboBox.SelectedValue Is Nothing _
              OrElse newspaperComboBox.SelectedIndex < 0 _
            Then
                SetErrorProvider(newspaperComboBox, "Select newspaper from drop down.")
                areAllValid = False
            End If

            If languageComboBox.SelectedValue Is Nothing _
              OrElse languageComboBox.SelectedIndex < 0 _
            Then
                SetErrorProvider(languageComboBox, "Select language from drop down.")
                areAllValid = False
            End If

            If breakDateListBox.Items.Count = 0 Then
                SetErrorProvider(breakDateListBox, "Provide at least one break date.")
                areAllValid = False
            End If

            'When Marke is set to N/A, the media has to be a Magazine. There is not other flag for the same.
            'For magazine sender and weight is not needed, hence no need to validate it.
            Try
                If marketComboBox.Text.ToUpper() <> "N/A" Then
                    If areAllValid AndAlso weightTextBox.Enabled AndAlso CType("0" + weightTextBox.Text, Double) <= 0 Then
                        SetErrorProvider(weightTextBox, "Weight should be a positive number.")
                        areAllValid = False
                    Else
                        RemoveErrorProvider(weightTextBox)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("Please enter a valid weight.", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                weightTextBox.Text = String.Empty
                weightTextBox.Focus()
                areAllValid = False
            End Try

            Return areAllValid

        End Function

        ''' <summary>
        ''' Assigns input values into data row of vwPublicationEdition datatable.
        ''' </summary>
        ''' <param name="tempRow"></param>
        ''' <param name="dateRowIndex"></param>
        ''' <exception cref="System.ApplicationException">Raises exception if ad date is an invalid date.</exception>
        ''' <remarks></remarks>
        Private Sub SetDataRowColumnValues _
            (ByVal tempRow As PublicationCheckInDataSet.vwPublicationEditionRow _
             , ByVal dateRowIndex As Integer)
            Dim mediaId, days As Integer
            Dim tempBreakDt As DateTime


            If DateTime.TryParse(breakDateListBox.Items(dateRowIndex).ToString(), tempBreakDt) = False Then
                Throw New System.ApplicationException("Invalid Ad date specified.")
            End If


            days = Me.breakDateListBox.Items.Count

            tempRow.BeginEdit()
            If marketComboBox.Text = "N/A" Then
                mediaId = Processor.GetMediaId("Magazine")
                tempRow.MediaId = mediaId
                tempRow.SenderId = Processor.GetSenderIdForMagazine()
                tempRow.SetWeightNull()
            Else
                mediaId = Processor.GetMediaId("ROP")
                tempRow.MediaId = mediaId
                tempRow.SenderId = CType(senderComboBox.SelectedValue, Integer)
                If weightTextBox.Enabled Then
                    tempRow.Weight = Math.Round(CType(weightTextBox.Text, Double) / days, 1)
                Else
                    tempRow.SetWeightNull()
                End If
            End If

            tempRow.MktId = CType(marketComboBox.SelectedValue, Integer)
            tempRow.PublicationId = CType(newspaperComboBox.SelectedValue, Integer)
            tempRow.LanguageId = CType(languageComboBox.SelectedValue, Integer)
            tempRow.BreakDt = tempBreakDt
            tempRow.FormName = FORM_NAME
            tempRow.Priority = tempRow.PublicationRow.Priority
            tempRow.EndEdit()

        End Sub

        Private Sub ShowRecord(ByVal viewRow As PublicationCheckInDataSet.vwPublicationEditionRow)

            searchTextBox.Text = viewRow.VehicleId.ToString()
            senderComboBox.SelectedValue = viewRow.SenderId
            marketComboBox.SelectedValue = viewRow.MktId
            newspaperComboBox.SelectedValue = viewRow.PublicationId
            If viewRow.IsLanguageIdNull() Then
                languageComboBox.SelectedValue = DBNull.Value
            Else
                languageComboBox.SelectedValue = viewRow.LanguageId
            End If
            checkInMonthCalendar.SetDate(viewRow.BreakDt)
            breakDateListBox.Items.Clear()
            breakDateListBox.Items.Add(viewRow.BreakDt.ToString("MM/dd/yy"))
            If viewRow.IsWeightNull() Then
                weightTextBox.Text = String.Empty
            Else
                weightTextBox.Text = viewRow.Weight.ToString("0.0")
            End If

        End Sub

        Private Sub PrintBarcodeLabel(ByVal barcodeRow As PublicationCheckInDataSet.vwPublicationEditionRow)


            #If DEBUG Then

                        If MessageBox.Show("Do you want to print?", Application.ProductName, MessageBoxButtons.YesNo _
                                           , MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No _
                        Then
                            Exit Sub
                        End If

            #End If

            Processor.PrintBarcode(barcodeRow)

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

            m_publicationCheckInProcessor = New Processors.PublicationCheckIn
            Processor.Initialize()
            Processor.LoadDataSet()

            Me.StatusMessage = "Information loaded, preparing to show loaded information on window."
            Me.IsShippingRequired = True

            checkedInByValueLabel.Text = Processor.UserFirstName + " " + Processor.UserLastName

            languageComboBox.DisplayMember = "Descrip"
            languageComboBox.ValueMember = "LanguageId"
            languageComboBox.DataSource = Processor.Data.Language
            languageComboBox.SelectedValue = DBNull.Value

            newspaperComboBox.DisplayMember = "Descrip"
            newspaperComboBox.ValueMember = "PublicationId"
            newspaperComboBox.DataSource = Processor.Data.Publication
            newspaperComboBox.SelectedValue = DBNull.Value

            marketComboBox.DisplayMember = "Descrip"
            marketComboBox.ValueMember = "MktId"
            marketComboBox.DataSource = Processor.Data.Mkt
            marketComboBox.SelectedValue = DBNull.Value


            senderComboBox.DisplayMember = "Name"
            senderComboBox.ValueMember = "SenderId"
            senderComboBox.SelectedValue = DBNull.Value
            senderComboBox.DataSource = Processor.Data.Sender

            senderComboBox.SelectedIndex = -1

            Me.ResumeLayout(False)

            RaiseEvent FormInitialized()

        End Sub

#End Region


        Private Sub searchTextBox_KeyPress _
            (ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
            Handles searchTextBox.KeyPress

            '3 - Copy, 22 - Paste and 24 - Cut, 8 - Backspace
            If Microsoft.VisualBasic.AscW(e.KeyChar) = 3 _
              OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 22 _
              OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 24 _
              OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 8 _
            Then
                Exit Sub 'Process as it should.
            End If

            If Microsoft.VisualBasic.AscW(e.KeyChar) = 13 Then
                gotoButton.PerformClick()
            End If

        End Sub

        Private Sub senderFilterButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles senderFilterButton.Click
            Dim userResponse As DialogResult
            Dim filterHelp As UI.SenderSelectionHelpForm


            filterHelp = New SenderSelectionHelpForm()

            filterHelp.Text = "Sender Selection Help"
            filterHelp.Initialize(New System.Data.DataView(Processor.Data.Sender.Copy()) _
                                  , senderComboBox.DisplayMember, senderComboBox.ValueMember)
            userResponse = filterHelp.ShowDialog(Me)

            If userResponse = Windows.Forms.DialogResult.OK And filterHelp.filterComboBox.SelectedValue IsNot Nothing Then
                senderComboBox.SelectedValue = filterHelp.filterComboBox.SelectedValue
            End If

            filterHelp.Dispose()
            filterHelp = Nothing

            If senderComboBox.Enabled Then
                senderComboBox.Focus()
            Else
                searchTextBox.Focus()
            End If

        End Sub

        Private Sub senderComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles senderComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub senderComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles senderComboBox.KeyUp

            If e.KeyCode = Keys.F12 AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                senderFilterButton.PerformClick()
            End If

        End Sub

        Private Sub senderComboBox_SelectedValueChanged _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles senderComboBox.SelectedValueChanged
            Dim senderId As Integer


            If senderComboBox.SelectedValue Is Nothing Then
                'marketComboBox.DataSource = Nothing
                'newspaperComboBox.DataSource = Nothing
                Exit Sub
            ElseIf Integer.TryParse(senderComboBox.SelectedValue.ToString(), senderId) = False Then
                MessageBox.Show("Unable to read sender.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim tempRow As PublicationCheckInDataSet.SenderRow
            tempRow = Processor.Data.Sender.FindBySenderId(senderId)
            If tempRow Is Nothing OrElse tempRow.IsIndNoShippingNull() OrElse tempRow.IndNoShipping <> 1 Then
                weightTextBox.Enabled = True And (Me.FormState <> FormStateEnum.View)
                Me.IsShippingRequired = True
            Else
                weightTextBox.Enabled = False
                Me.IsShippingRequired = False
            End If
            tempRow = Nothing

            Processor.LoadMarketsForSender(senderId)
            marketComboBox.SelectedValue = DBNull.Value

        End Sub

        Private Sub marketComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles marketComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub marketComboBox_SelectedValueChanged _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles marketComboBox.SelectedValueChanged
            Dim marketId As Integer


            If marketComboBox.SelectedValue Is Nothing Then
                'newspaperComboBox.DataSource = Nothing
                Exit Sub
            ElseIf Integer.TryParse(marketComboBox.SelectedValue.ToString(), marketId) = False Then
                MessageBox.Show("Unable to read market.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Processor.LoadPublicationsForMarket(marketId)
            newspaperComboBox.SelectedValue = DBNull.Value

        End Sub

        Private Sub marketComboBox_Validated _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles marketComboBox.Validated

            If marketComboBox.Text = MARKET_FOR_MAGAZINES Then
                senderComboBox.SelectedValue = Processor.GetSenderIdForMagazine()
                senderComboBox.Enabled = False
                weightTextBox.Text = String.Empty
                weightTextBox.Enabled = False
            Else
                senderComboBox.Enabled = True
                weightTextBox.Enabled = True And Me.IsShippingRequired
            End If

        End Sub

        Private Sub newspaperComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles newspaperComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub newspaperComboBox_SelectedValueChanged _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles newspaperComboBox.SelectedValueChanged
            Dim publicationId As Integer
            Dim bmb As BindingManagerBase
            Dim tempPublicationRow As System.Data.DataRowView


            If marketComboBox.SelectedValue Is Nothing Then
                languageComboBox.SelectedValue = DBNull.Value
                Exit Sub
            End If

            bmb = Me.BindingContext(newspaperComboBox.DataSource)
            If bmb.Count = 0 Then
                bmb = Nothing
                Exit Sub
            End If

            tempPublicationRow = CType(bmb.Current, System.Data.DataRowView)

            languageComboBox.SelectedValue = tempPublicationRow("LanguageId")

            publicationId = CType(newspaperComboBox.SelectedValue, Integer)
            Processor.LoadPublicationDays(publicationId)
            GiveClueForValidPublicationDates(checkInMonthCalendar.SelectionStart)

            bmb = Nothing
            tempPublicationRow = Nothing

        End Sub

        Private Sub languageComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles languageComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub ComboBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
            Handles senderComboBox.Validating, marketComboBox.Validating, newspaperComboBox.Validating _
                    , languageComboBox.Validating
            Dim tempComboBox As System.Windows.Forms.ComboBox


            tempComboBox = CType(sender, System.Windows.Forms.ComboBox)

            If tempComboBox.SelectedValue Is Nothing Then
                SetErrorProvider(tempComboBox, "Select value from drop down.")
            Else
                RemoveErrorProvider(tempComboBox)
            End If

        End Sub

        ''' <summary>
        ''' Makes valid publication dates bold, for selected publication.
        ''' </summary>
        ''' <param name="selectedDate"></param>
        ''' <remarks></remarks>
        Private Sub GiveClueForValidPublicationDates(ByVal selectedDate As DateTime)
            Dim tempDate As DateTime
            Dim dateList As System.Collections.Generic.List(Of DateTime)


            checkInMonthCalendar.RemoveAllBoldedDates()

            If newspaperComboBox.SelectedValue Is Nothing Then Exit Sub

            tempDate = New DateTime(selectedDate.Year, selectedDate.Month, 1)
            dateList = New System.Collections.Generic.List(Of DateTime)

            For i As Integer = 0 To DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month) - 1
                If Processor.IsPublicationDayValid(tempDate) Then
                    dateList.Add(tempDate)
                End If
                tempDate = tempDate.AddDays(1)
            Next

            If dateList.Count > 0 Then
                checkInMonthCalendar.BoldedDates = dateList.ToArray()
            End If

            dateList.Clear()
            dateList = Nothing
            tempDate = Nothing
        End Sub

        Private Sub checkInMonthCalendar_DateChanged _
            (ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) _
            Handles checkInMonthCalendar.DateChanged

            GiveClueForValidPublicationDates(e.Start)

            'Dim tempDate As DateTime
            'Dim dateList As System.Collections.Generic.List(Of DateTime)


            'checkInMonthCalendar.RemoveAllBoldedDates()

            'If newspaperComboBox.SelectedValue Is Nothing Then Exit Sub

            'tempDate = New DateTime(e.Start.Year, e.Start.Month, 1)
            'dateList = New System.Collections.Generic.List(Of DateTime)

            'For i As Integer = 0 To DateTime.DaysInMonth(e.Start.Year, e.Start.Month)
            '  tempDate = tempDate.AddDays(1)
            '  If Processor.IsPublicationDayValid(tempDate) Then
            '    dateList.Add(tempDate)
            '  End If
            'Next

            'If dateList.Count > 0 Then
            '  checkInMonthCalendar.BoldedDates = dateList.ToArray()
            'End If

            'dateList.Clear()
            'dateList = Nothing
            'tempDate = Nothing

        End Sub

        Private Sub checkInMonthCalendar_DateSelected _
            (ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) _
            Handles checkInMonthCalendar.DateSelected
            Dim dateDiff, dateCounter As Integer
            Dim loopStartDate As DateTime


            If newspaperComboBox.SelectedValue Is Nothing Then
                MessageBox.Show("You must specify publication before selecting publication date." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If e.Start < e.End Then
                dateDiff = e.End.Subtract(e.Start).Days
                loopStartDate = e.Start
            ElseIf e.End < e.Start Then
                dateDiff = e.Start.Subtract(e.End).Days
                loopStartDate = e.End
            Else
                loopStartDate = e.Start
            End If

            If CDate(loopStartDate.ToString("d")) > Today Then
                MessageBox.Show("Publication date cannot be a future date", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            For dateCounter = 0 To dateDiff
                If breakDateListBox.FindStringExact(loopStartDate.ToString("MM/dd/yy")) >= 0 Then
                    MessageBox.Show("Date " & loopStartDate.ToString("MM/dd/yy") + " already selected.", ProductName _
                                    , MessageBoxButtons.OK, MessageBoxIcon.Error)
                ElseIf Processor.IsPublicationDayValid(loopStartDate) = False Then
                    MessageBox.Show("Selected publication is not published on " + loopStartDate.ToString("MM/dd/yy") _
                                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim dateArray(breakDateListBox.Items.Count) As DateTime
                    Dim dateQuery As System.Collections.Generic.IEnumerable(Of DateTime)

                    For i As Integer = 0 To breakDateListBox.Items.Count - 1
                        dateArray(i) = CType(breakDateListBox.Items(i), DateTime)
                    Next
                    dateArray(breakDateListBox.Items.Count) = loopStartDate
                    dateQuery = From dt In dateArray Order By dt Select dt
                    dateArray = dateQuery.ToArray()
                    breakDateListBox.Items.Clear()
                    For i As Integer = 0 To dateArray.Length - 1
                        breakDateListBox.Items.Add(dateArray(i).ToString("MM/dd/yy"))
                    Next
                    dateArray = Nothing
                End If

                loopStartDate = loopStartDate.AddDays(1)
            Next

            checkInMonthCalendar.SetDate(e.End)

            loopStartDate = Nothing

        End Sub

        Private Sub breakDateListBox_Validating _
            (ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
            Handles breakDateListBox.Validating

            If breakDateListBox.Items.Count = 0 Then
                SetErrorProvider(breakDateListBox, "Select at least one date from calendar.")
            Else
                RemoveErrorProvider(breakDateListBox)
            End If

        End Sub

        Private Sub clearDatesButton_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles clearDatesButton.Click

            If breakDateListBox.SelectedIndex < 0 Then
                breakDateListBox.Items.Clear()
            Else
                breakDateListBox.Items.RemoveAt(breakDateListBox.SelectedIndex)
                breakDateListBox.SelectedIndex = -1
            End If

        End Sub

        Private Sub weightTextBox_KeyPress _
            (ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
            Handles weightTextBox.KeyPress

            If Not (System.Char.IsDigit(e.KeyChar) Or e.KeyChar.Equals("."c) _
                    Or Microsoft.VisualBasic.ChrW(8) = e.KeyChar) _
            Then
                e.Handled = True
            End If

        End Sub

        Private Sub weightTextBox_Validating _
            (ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
            Handles weightTextBox.Validating
            Dim tempWeight As Double


            If marketComboBox.Text = MARKET_FOR_MAGAZINES Then Exit Sub

            If Double.TryParse("0" + weightTextBox.Text, tempWeight) = False Then
                SetErrorProvider(weightTextBox, "Provide valid weight.")
            Else
                RemoveErrorProvider(weightTextBox)
                weightTextBox.Text = tempWeight.ToString("0.0")
            End If

            tempWeight = Nothing

        End Sub


        Private Sub closeButton_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles closeButton.Click
            isClosedByButton = True
            Me.Close()

        End Sub

        Private Sub clearButton_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles clearButton.Click

            ClearAllInputs()
            RemoveAllErrorProviders()
            Me.FormState = FormStateEnum.Insert
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

            senderComboBox.Focus()

        End Sub

        Private Sub gotoButton_Click _
            (ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles gotoButton.Click
            Dim vehicleId As Integer


            If Integer.TryParse(searchTextBox.Text, vehicleId) = False Then
                MessageBox.Show("Provide valid vehicle Id.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                searchTextBox.Focus()
                searchTextBox.SelectAll()
                Exit Sub
            End If

            Processor.FindVehicle(vehicleId, FORM_NAME)

        End Sub

        Private Sub reprintButton_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles reprintButton.Click
            Dim tempRow As PublicationCheckInDataSet.vwPublicationEditionRow


            tempRow = Processor.Data.vwPublicationEdition(0)

            PrintBarcodeLabel(tempRow)

            tempRow = Nothing

        End Sub

        Private Sub CheckInButton_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles newButton.Click, sameButton.Click
            Dim itemCounter, senderId, marketId As Integer
            Dim tempRow As PublicationCheckInDataSet.vwPublicationEditionRow
            Dim dupPublications As DuplicatePublicationListForm


            If AreInputsValid() = False Then Exit Sub
            RemoveAllErrorProviders()
            dupPublications = New DuplicatePublicationListForm()
            dupPublications.Init()

            If Me.FormState = FormStateEnum.Edit Then
                tempRow = Processor.Data.vwPublicationEdition(0)
                SetDataRowColumnValues(tempRow, 0)

                If sender IsNot wrongVersionButton Then
                    If dupPublications.LoadDuplicatePublications(tempRow.MktId, tempRow.PublicationId, tempRow.BreakDt, tempRow.VehicleId, Nothing) > 0 Then
                        dupPublications.ShowDuplicatePublicationsInDataGridView()
                        dupPublications.ShowDialog(Me)
                        If dupPublications.IsPublicationReceivedFromSameSender(tempRow.SenderId) Then
                            tempRow.RejectChanges()
                        ElseIf Processor.IsMarkedAsNoDrop(tempRow.MktId, tempRow.PublicationId, tempRow.BreakDt) Then
                            MessageBox.Show("Cannot receive publication. It is marked as no drop.", ProductName _
                                            , MessageBoxButtons.OK, MessageBoxIcon.Information)
                            tempRow.RejectChanges()
                        Else
                            Processor.SetStatusIdForDuplicate(tempRow)
                        End If
                    End If
                Else
                    Processor.SetStatusIdForWrongVersion(tempRow)

                End If

                Processor.Synchronize()

                'If Processor.IsDuplicate(tempRow.SenderId, tempRow.MktId, tempRow.PublicationId, tempRow.BreakDt, tempRow.VehicleId) Then
                '  MessageBox.Show("Publication is already received.", ProductName _
                '                  , MessageBoxButtons.OK, MessageBoxIcon.Information)
                '  tempRow.RejectChanges()
                'Else
                '  If Processor.IsDuplicate(tempRow.MktId, tempRow.PublicationId, tempRow.BreakDt, tempRow.VehicleId) Then
                '    MessageBox.Show("Publication is already received from different sender.", ProductName _
                '                    , MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Processor.SetStatusIdForDuplicate(tempRow)
                '  End If
                '  If Processor.IsMarkedAsNoDrop(tempRow.MktId, tempRow.PublicationId, tempRow.BreakDt) Then
                '    MessageBox.Show("Cannot receive publication. It is marked as no drop.", ProductName _
                '                    , MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    tempRow.RejectChanges()
                '  End If
                '  Processor.Synchronize()
                '  'PrintBarcodeLabel(tempRow)
                'End If

            ElseIf Me.FormState = FormStateEnum.Insert Then
                For itemCounter = 0 To breakDateListBox.Items.Count - 1
                    tempRow = Processor.CreateNew()
                    SetDataRowColumnValues(tempRow, itemCounter)

                    If sender IsNot wrongVersionButton Then
                        If dupPublications.LoadDuplicatePublications(tempRow.MktId, tempRow.PublicationId, tempRow.BreakDt, Nothing, Nothing) > 0 Then
                            dupPublications.ShowDuplicatePublicationsInDataGridView()
                            dupPublications.ShowDialog(Me)
                            Processor.SetStatusIdForDuplicate(tempRow)
                        ElseIf Processor.IsMarkedAsNoDrop(tempRow.MktId, tempRow.PublicationId, tempRow.BreakDt) Then
                            MessageBox.Show("Cannot receive publication on " + tempRow.BreakDt.ToString("MM/dd/yyyy") _
                                            + ". It is marked as no drop.", ProductName, MessageBoxButtons.OK _
                                            , MessageBoxIcon.Information)
                            tempRow = Nothing
                            Continue For
                        Else
                            Processor.SetStatusIdForReceived(tempRow)
                        End If

                    Else

                        If Processor.IsMarkedAsNoDrop(tempRow.MktId, tempRow.PublicationId, tempRow.BreakDt) Then
                            MessageBox.Show("Cannot mark publication as wrong version for " + tempRow.BreakDt.ToString("MM/dd/yyyy") _
                                            + ". It is marked as no drop.", ProductName, MessageBoxButtons.OK _
                                            , MessageBoxIcon.Information)
                            tempRow = Nothing
                            Continue For
                        Else
                            Processor.SetStatusIdForWrongVersion(tempRow)
                        End If

                    End If



                    'If Processor.IsDuplicate(tempRow.MktId, tempRow.PublicationId, tempRow.BreakDt, Nothing) Then
                    '  MessageBox.Show("Publication, with published date " + tempRow.BreakDt.ToString("MM/dd/yyyy") _
                    '                  + ", is already received.", ProductName, MessageBoxButtons.OK _
                    '                  , MessageBoxIcon.Information)
                    '  Processor.SetStatusIdForDuplicate(tempRow)
                    'ElseIf Processor.IsMarkedAsNoDrop(tempRow.MktId, tempRow.PublicationId, tempRow.BreakDt) Then
                    '  MessageBox.Show("Cannot receive publication on " + tempRow.BreakDt.ToString("MM/dd/yyyy") _
                    '                  + ". It is marked as no drop.", ProductName, MessageBoxButtons.OK _
                    '                  , MessageBoxIcon.Information)
                    '  tempRow = Nothing
                    '  Continue For
                    'Else
                    '  Processor.SetStatusIdForReceived(tempRow)
                    'End If
                    Processor.Add(tempRow)
                    Processor.Synchronize()
                    searchTextBox.Text = tempRow.VehicleId.ToString()
                    PrintBarcodeLabel(tempRow)
                    tempRow = Nothing
                Next
            End If

            If sender Is sameButton Or sender Is wrongVersionButton Then
                senderId = CType(senderComboBox.SelectedValue, Integer)
                marketId = CType(marketComboBox.SelectedValue, Integer)
            End If
            itemCounter = CType("0" + searchTextBox.Text, Integer)

            Processor.Data.vwPublicationEdition.Clear()
            Me.FormState = FormStateEnum.Insert
            ClearAllInputs()
            EnableDisableControls(Me.FormState)

            searchTextBox.Text = itemCounter.ToString()
            If sender Is sameButton Or sender Is wrongVersionButton Then
                senderComboBox.SelectedValue = senderId
                marketComboBox.SelectedValue = marketId
                newspaperComboBox.Focus()
            Else
                senderComboBox.Focus()
            End If

        End Sub

        Private Sub envelopeCheckInButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles envelopeCheckInButton.Click
            Dim weight As Single
            Dim envCheckIn As UI.EnvelopeCheckInForm


            If senderComboBox.SelectedValue Is Nothing Then
                MessageBox.Show("Select sender from drop down to Check-In envelope.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf weightTextBox.Enabled = False OrElse Single.TryParse(weightTextBox.Text, weight) = False Then
                weight = 0.0
            End If

            envCheckIn = New UI.EnvelopeCheckInForm()
            envCheckIn.Init(FormStateEnum.Insert)
            envCheckIn.ApplyUserCredentials()
            envCheckIn.senderComboBox.SelectedValue = Me.senderComboBox.SelectedValue
            'If weight > 0.0 AndAlso envCheckIn.actualWeightTextBox.Enabled Then
            '  envCheckIn.actualWeightTextBox.Focus()
            '  'envCheckIn.actualWeightTextBox.Text = weight.ToString("#0.0")
            '  envCheckIn.shippingCompanyComboBox.Enabled = False
            '  envCheckIn.shippingMethodComboBox.Enabled = False
            '  envCheckIn.trackNumberTextBox.Enabled = False
            '  envCheckIn.printedWeightTextBox.Enabled = False
            '  envCheckIn.actualWeightTextBox.Enabled = False
            '  envCheckIn.packageTypeComboBox.Enabled = False
            'End If
            envCheckIn.ShowDialog(Me)
            envCheckIn.Dispose()
            envCheckIn = Nothing

        End Sub

        Private Sub PublicationCheckInForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If e.CloseReason = CloseReason.UserClosing And isClosedByButton = False Then
                If (MessageBox.Show("Are you sure you want to close this form?", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                    e.Cancel = True
                End If
            End If
        End Sub


        Private Sub PublicationCheckInForm_FormInitialized() Handles Me.FormInitialized

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub PublicationCheckInForm_InitializingForm() Handles Me.InitializingForm

            Me.StatusMessage = "Loading information, this may take some time. Please wait..."

        End Sub

        Private Sub m_publicationCheckInProcessor_BarcodePrinted(ByVal sender As Object, ByVal e As MCAP.UI.Processors.EventArgs) Handles m_publicationCheckInProcessor.BarcodePrinted

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_publicationCheckInProcessor_DataLoaded() Handles m_publicationCheckInProcessor.DataLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_publicationCheckInProcessor_Initialized() Handles m_publicationCheckInProcessor.Initialized

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_publicationCheckInProcessor_Initializing() Handles m_publicationCheckInProcessor.Initializing

            Me.StatusMessage = "Initializing processor..."

        End Sub

        Private Sub m_publicationCheckInProcessor_InvalidVehicleStatus(ByVal sender As Object, ByVal e As MCAP.UI.Processors.EventArgs) Handles m_publicationCheckInProcessor.InvalidVehicleStatus
            Dim vehicleId As Integer
            Dim statusText As String = String.Empty


            If e.Data.Contains("VehicleId") Then
                If Integer.TryParse(e.Data("VehicleId").ToString(), vehicleId) = False Then
                    vehicleId = 0
                End If
            End If

            If e.Data.Contains("ErrorMessage") Then
                If e.Data("ErrorMessage") IsNot Nothing Then statusText = e.Data("ErrorMessage").ToString()
            End If

            Me.StatusMessage = String.Empty

            MessageBox.Show("Vehicle cannot be loaded because it has the Status of: " + statusText _
                            , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ClearAllInputs()
            RemoveAllErrorProviders()

            Me.FormState = FormStateEnum.Insert
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

            searchTextBox.Focus()

        End Sub

        Private Sub m_publicationCheckInProcessor_LoadingData() Handles m_publicationCheckInProcessor.LoadingData

            Me.StatusMessage = "Loading initial information from database. This may take some time. Please wait..."

        End Sub

        Private Sub m_publicationCheckInProcessor_LoadingMarkets() Handles m_publicationCheckInProcessor.LoadingMarkets

            Me.StatusMessage = "Loading markets..."

        End Sub

        Private Sub m_publicationCheckInProcessor_LoadingPublications() Handles m_publicationCheckInProcessor.LoadingPublications

            Me.StatusMessage = "Loading publications..."

        End Sub

        Private Sub m_publicationCheckInProcessor_LoadingVehicle(ByVal sender As Object, ByVal e As MCAP.UI.Processors.EventArgs) Handles m_publicationCheckInProcessor.LoadingVehicle
            Dim vehicleId As Integer


            If e.Data.Contains("VehicleId") Then
                If Integer.TryParse(e.Data("VehicleId").ToString(), vehicleId) Then
                    vehicleId = 0
                End If
            End If

            If vehicleId = 0 Then
                Me.StatusMessage = "Loading vehicle information..."
            Else
                Me.StatusMessage = String.Format("Loading vehicle {0} information...", vehicleId)
            End If

        End Sub

        Private Sub m_publicationCheckInProcessor_MarketsLoaded() Handles m_publicationCheckInProcessor.MarketsLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_publicationCheckInProcessor_PrintingBarcode(ByVal sender As Object, ByVal e As MCAP.UI.Processors.CancellableEventArgs) Handles m_publicationCheckInProcessor.PrintingBarcode

            Me.StatusMessage = "Printing barcode label..."

        End Sub

        Private Sub m_publicationCheckInProcessor_PublicationsLoaded() Handles m_publicationCheckInProcessor.PublicationsLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_publicationCheckInProcessor_Synchronized() Handles m_publicationCheckInProcessor.Synchronized

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_publicationCheckInProcessor_Synchronizing() Handles m_publicationCheckInProcessor.Synchronizing

            Me.StatusMessage = "Saving vehicle information changes to database."

        End Sub

        Private Sub m_publicationCheckInProcessor_VehicleLoaded(ByVal sender As Object, ByVal e As MCAP.UI.Processors.EventArgs) Handles m_publicationCheckInProcessor.VehicleLoaded
            Dim vehicleRow As PublicationCheckInDataSet.vwPublicationEditionRow


            If e.Data.Contains("VehicleRow") = False Then
                MessageBox.Show("Vehicle found but unable to get its information.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            vehicleRow = CType(e.Data("VehicleRow"), PublicationCheckInDataSet.vwPublicationEditionRow)

            Me.StatusMessage = String.Empty

            RemoveAllErrorProviders()
            ClearAllInputs()

            ShowRecord(vehicleRow)

            Me.FormState = FormStateEnum.Edit
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

            ''Disable sender and weight inputs if its a market.
            'If vehicleRow.PublicationRow IsNot Nothing AndAlso vehicleRow.PublicationRow.MktRow IsNot Nothing Then
            '  If vehicleRow.PublicationRow.MktRow.Descrip = "N/A" Then
            '    senderComboBox.Enabled = False
            '    weightTextBox.Enabled = False
            '  End If
            'End If

        End Sub

        Private Sub m_publicationCheckInProcessor_VehicleNotFound(ByVal sender As Object, ByVal e As MCAP.UI.Processors.EventArgs) Handles m_publicationCheckInProcessor.VehicleNotFound
            Dim vehicleId As Integer


            If e.Data.Contains("VehicleId") Then
                If Integer.TryParse(e.Data("VehicleId").ToString(), vehicleId) = False Then
                    vehicleId = 0
                End If
            End If

            Me.StatusMessage = String.Empty

            If vehicleId = 0 Then
                MessageBox.Show("Vehicle not found.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Vehicle " + vehicleId.ToString() + " not found.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            ClearAllInputs()
            searchTextBox.Text = CType(vehicleId, String)
            RemoveAllErrorProviders()

            Me.FormState = FormStateEnum.Insert
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

            searchTextBox.SelectAll()
            searchTextBox.Focus()

        End Sub

        Private Sub wrongVersionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wrongVersionButton.Click
            Dim userResponse As DialogResult
            If AreInputsValid() = False Then Exit Sub
            RemoveAllErrorProviders()
            userResponse = MessageBox.Show("Are you sure this is the wrong version?", ProductName _
                                         , MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

            CheckInButton_Click(sender, e)
        End Sub

        Private Sub senderComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles senderComboBox.SelectedIndexChanged

        End Sub

        Private Sub marketComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles marketComboBox.SelectedIndexChanged

        End Sub

        Private Sub newspaperComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newspaperComboBox.SelectedIndexChanged

        End Sub

        Private Sub languageComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles languageComboBox.SelectedIndexChanged

        End Sub

        Private Sub PublicationCheckInForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub
    End Class

End Namespace