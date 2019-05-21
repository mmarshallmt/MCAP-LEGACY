Namespace UI

  Public Class PublicationPullForm
    Implements IForm


    Private Const FORM_NAME As String = "Publication Pull"

        Private WithEvents m_publicationPullProcessor As Processors.PublicationPull
        Private isClosedByButton As Boolean = False



    Private ReadOnly Property Processor() As Processors.PublicationPull
      Get
        Return m_publicationPullProcessor
      End Get
    End Property


    ''' <summary>
    ''' Clears all input controls on form.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub ClearAllInputs()
      MyBase.ClearAllInputs()

      publicationEditionIdTextBox.Clear()
      marketComboBox.SelectedValue = DBNull.Value
      newspaperComboBox.SelectedValue = DBNull.Value
      languageComboBox.SelectedValue = DBNull.Value
      commentsTextBox.Text = String.Empty
      breakDtMonthCalendar.SetDate(DateTime.Today)
      noAdsCheckBox.Checked = False
      pageCountTextBox.Clear()

    End Sub

    ''' <summary>
    ''' Enables/disables input controls on form based on parameter value.
    ''' </summary>
    ''' <param name="formStatus"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub EnableDisableControls(ByVal formStatus As FormStateEnum)
      MyBase.EnableDisableControls(formStatus)

      Select Case formStatus
        Case FormStateEnum.Insert
          marketComboBox.Enabled = True
          newspaperComboBox.Enabled = True
          languageComboBox.Enabled = True
          breakDtMonthCalendar.Enabled = True
          pageCountTextBox.Enabled = Not noAdsCheckBox.Checked
          noAdsCheckBox.Enabled = True
          checkInButton.Enabled = True
          deleteButton.Enabled = False

        Case FormStateEnum.Edit
          marketComboBox.Enabled = False
          newspaperComboBox.Enabled = False
          languageComboBox.Enabled = False
          breakDtMonthCalendar.Enabled = True
          pageCountTextBox.Enabled = Not noAdsCheckBox.Checked
          noAdsCheckBox.Enabled = True
          checkInButton.Enabled = True
          deleteButton.Enabled = True

        Case Else
          marketComboBox.Enabled = False
          newspaperComboBox.Enabled = False
          languageComboBox.Enabled = False
          breakDtMonthCalendar.Enabled = False
          pageCountTextBox.Enabled = False
          noAdsCheckBox.Enabled = False
          checkInButton.Enabled = False
          deleteButton.Enabled = False
      End Select

    End Sub

    ''' <summary>
    ''' Removes error providers from all input controls.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub RemoveAllErrorProviders()
      MyBase.RemoveAllErrorProviders()

      RemoveErrorProvider(marketComboBox)
      RemoveErrorProvider(newspaperComboBox)
      RemoveErrorProvider(breakDtMonthCalendar)
      RemoveErrorProvider(pageCountTextBox)

    End Sub


    ''' <summary>
    ''' Shows column values into controls.
    ''' </summary>
    ''' <param name="viewRow"></param>
    ''' <remarks></remarks>
    Private Sub ShowColumnValues(ByVal viewRow As PublicationPullDataSet.vwPublicationEditionRow)
      Dim receivedStatusId As Integer


      receivedStatusId = Processor.GetVehicleStatusId("Received")

      marketComboBox.SelectedValue = viewRow.MktId
      newspaperComboBox.SelectedValue = viewRow.PublicationId
      If viewRow.IsLanguageIdNull() Then
        languageComboBox.SelectedValue = DBNull.Value
      Else
        languageComboBox.SelectedValue = viewRow.LanguageId
      End If
      breakDtMonthCalendar.SetDate(viewRow.BreakDt)
      If viewRow.IsPullPageCountNull() AndAlso (viewRow.StatusID = receivedStatusId) Then
        noAdsCheckBox.Checked = False
        noAdsCheckBox_CheckedChanged(noAdsCheckBox, New System.EventArgs)
      ElseIf viewRow.IsPullPageCountNull() AndAlso (viewRow.StatusID <> receivedStatusId) Then
        noAdsCheckBox.Checked = True
        noAdsCheckBox_CheckedChanged(noAdsCheckBox, New System.EventArgs)
      Else
        noAdsCheckBox.Checked = False
        noAdsCheckBox_CheckedChanged(noAdsCheckBox, New System.EventArgs)
        pageCountTextBox.Text = viewRow.PullPageCount.ToString()
      End If
      requiredRetailersDataGridView.Visible = Not (Processor.IsMediaMagazine(viewRow.MediaId))

    End Sub

    ''' <summary>
    ''' Makes valid publication dates bold, for selected publication.
    ''' </summary>
    ''' <param name="selectedDate"></param>
    ''' <remarks></remarks>
    Private Sub GiveClueForValidPublicationDates(ByVal selectedDate As DateTime)
      Dim tempDate As DateTime
      Dim dateList As System.Collections.Generic.List(Of DateTime)


      breakDtMonthCalendar.RemoveAllBoldedDates()

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
        breakDtMonthCalendar.BoldedDates = dateList.ToArray()
      End If

      dateList.Clear()
      dateList = Nothing
      tempDate = Nothing
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

      SuspendLayout()

      Me.FormState = formStatus

      m_publicationPullProcessor = New Processors.PublicationPull()
      Processor.Initialize()
      Processor.LoadDataSet()

      Me.StatusMessage = "Information loaded, preparing to show loaded information on window."

      checkedInByValueLabel.Text = Processor.UserFullName

      languageComboBox.DisplayMember = "Descrip"
      languageComboBox.ValueMember = "LanguageId"
      languageComboBox.DataSource = Processor.Data.Language
      languageComboBox.SelectedValue = DBNull.Value

      marketComboBox.DisplayMember = "Descrip"
      marketComboBox.ValueMember = "MktId"
      marketComboBox.DataSource = Processor.Data.Mkt

      newspaperComboBox.DisplayMember = "Descrip"
      newspaperComboBox.ValueMember = "PublicationId"
      newspaperComboBox.DataSource = Processor.Data.Publication

      ClearAllInputs()
      RemoveAllErrorProviders()
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

      Me.ResumeLayout(False)

      RaiseEvent FormInitialized()

    End Sub

#End Region



    ''' <summary>
    ''' Validates inputs.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AreInputsValid() As Boolean
      Dim areAllValid As Boolean
      Dim pageCount As Integer


      areAllValid = True

      If marketComboBox.SelectedValue Is Nothing Then
        SetErrorProvider(marketComboBox, "Select market from drop down list.")
        areAllValid = False
      Else
        RemoveErrorProvider(marketComboBox)
      End If

      If newspaperComboBox.SelectedValue Is Nothing Then
        SetErrorProvider(newspaperComboBox, "Select newspaper from drop down list.")
        areAllValid = False
      Else
        RemoveErrorProvider(newspaperComboBox)
      End If

      If languageComboBox.SelectedValue Is Nothing Then
        SetErrorProvider(languageComboBox, "Select language from drop down list.")
        areAllValid = False
      Else
        RemoveErrorProvider(languageComboBox)
      End If

      If breakDtMonthCalendar.SelectionRange.Start <> breakDtMonthCalendar.SelectionRange.End Then
        SetErrorProvider(adDateLabel, "Provide one ad date.")
        areAllValid = False
      Else
        RemoveErrorProvider(adDateLabel)
      End If

      If noAdsCheckBox.Checked Then
        RemoveErrorProvider(pageCountTextBox)
      Else
        If Integer.TryParse("0" + pageCountTextBox.Text, pageCount) = False Then
          SetErrorProvider(pageCountTextBox, "Provide page count.")
          areAllValid = False
        ElseIf pageCount <= 0 Then
          SetErrorProvider(pageCountTextBox, "Specify valid number of pages.")
          areAllValid = False
        Else
          RemoveErrorProvider(pageCountTextBox)
        End If
      End If

      Return areAllValid

    End Function

    ''' <summary>
    ''' Returns boolean value indicating whether user has changed ad date or not. 
    ''' Compares value in data row with value in control.
    ''' </summary>
    ''' <param name="pubEdRow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsBreakDateChanged(ByVal pubEdRow As PublicationPullDataSet.vwPublicationEditionRow) As Boolean

      Return (pubEdRow.BreakDt <> breakDtMonthCalendar.SelectionStart)

        End Function

        Private Sub newspaperComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles newspaperComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub


    Private Sub newspaperComboBox_SelectedValueChanged _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles newspaperComboBox.SelectedValueChanged
      Dim bmb As BindingManagerBase
      Dim tempRow As PublicationPullDataSet.PublicationRow


      If newspaperComboBox.SelectedValue Is Nothing Then Exit Sub

      bmb = Me.BindingContext(newspaperComboBox.DataSource)
      tempRow = CType(CType(bmb.Current, System.Data.DataRowView).Row, PublicationPullDataSet.PublicationRow)

      If tempRow.IsLanguageIDNull() Then
        'languageComboBox.SelectedValue = DBNull.Value 
      Else
        languageComboBox.SelectedValue = tempRow.LanguageID
      End If
      If tempRow.IsCommentsNull Then
        commentsTextBox.Text = String.Empty
      Else
        commentsTextBox.Text = tempRow.Comments
      End If
      GiveClueForValidPublicationDates(breakDtMonthCalendar.SelectionStart)

      tempRow = Nothing
      bmb = Nothing
    End Sub

    Private Sub pageCountTextBox_KeyPress _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles pageCountTextBox.KeyPress

      If Microsoft.VisualBasic.AscW(e.KeyChar) = 13 Then
        checkInButton.PerformClick()
      ElseIf Not (System.Char.IsDigit(e.KeyChar) Or Microsoft.VisualBasic.AscW(e.KeyChar) = 8) Then
        e.Handled = True
      End If

    End Sub

    Private Sub noAdsCheckBox_CheckedChanged _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles noAdsCheckBox.CheckedChanged

      pageCountTextBox.Clear()
      pageCountTextBox.Enabled = Not noAdsCheckBox.Checked

    End Sub

    Private Sub publicationEditionIdTextBox_KeyPress _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles publicationEditionIdTextBox.KeyPress

      '3 - Copy, 22 - Paste and 24 - Cut, 8 - Backspace
      If Microsoft.VisualBasic.AscW(e.KeyChar) = 3 _
        OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 22 _
        OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 24 _
        OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 8 _
      Then
        Exit Sub 'Process as it should.
      End If

      If Microsoft.VisualBasic.AscW(e.KeyChar) = 13 Then
        loadButton.PerformClick()
        e.Handled = True
      ElseIf Not (System.Char.IsDigit(e.KeyChar) Or Microsoft.VisualBasic.AscW(e.KeyChar) = 8) Then
        e.Handled = True
      End If

    End Sub

    Private Sub loadButton_Click _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles loadButton.Click
      Dim vehicleId As Integer


      If Integer.TryParse(publicationEditionIdTextBox.Text, vehicleId) = False Then
                MessageBox.Show("Please enter a valid ID.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
      Else
        Processor.LoadVehicle(vehicleId, FORM_NAME)
        ShowRetailers(CType(newspaperComboBox.SelectedValue, Integer))
        requiredRetailersDataGridView.DataSource = New BindingSource(Processor.Data, "Ret")
        SetAutoFilterHeader()
        PrepareRequiredRetailersDataGridView()
        requiredRetailersDataGridView.ResumeLayout(False)
        pageCountTextBox.Focus()
      End If

    End Sub

    Private Sub breakDtMonthCalendar_DateSelected _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) _
        Handles breakDtMonthCalendar.DateSelected

      breakDtMonthCalendar.RemoveAllBoldedDates()
      breakDtMonthCalendar.UpdateBoldedDates()

      If newspaperComboBox.SelectedValue Is Nothing Then Exit Sub

      If e.Start <> e.End Then
        MessageBox.Show("Multiple dates cannot be specified here.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      ElseIf Processor.IsPublicationDayValid(e.Start) = False Then
        MessageBox.Show("Selected publication is not published on " + e.Start.ToString("MM/dd/yy") _
                          , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        breakDtMonthCalendar.SelectionStart = Processor.Data.vwPublicationEdition(0).BreakDt
      End If

    End Sub

    Private Sub breakDtMonthCalendar_DateChanged _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) _
        Handles breakDtMonthCalendar.DateChanged

      breakDtMonthCalendar.RemoveAllBoldedDates()
      breakDtMonthCalendar.UpdateBoldedDates()

      If newspaperComboBox.SelectedValue Is Nothing Then Exit Sub

      GiveClueForValidPublicationDates(e.Start)

    End Sub

    Private Sub checkInButton_Click _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles checkInButton.Click
      Dim pullStatusId As Integer
      Dim updateRow As PublicationPullDataSet.vwPublicationEditionRow


      If AreInputsValid() = False Then Exit Sub

      pullStatusId = Processor.GetVehicleStatusId("Pulled")
      updateRow = Processor.Data.vwPublicationEdition(0)

      If IsBreakDateChanged(updateRow) Then
        Dim userResponse As System.Windows.Forms.DialogResult

        userResponse = MessageBox.Show("Ad date is changed from " + updateRow.BreakDt.ToString("MM/dd/yyyy") _
                                       + " to " + breakDtMonthCalendar.SelectionStart.ToString("MM/dd/yyyy") _
                                       + ". Is this correct?", ProductName, MessageBoxButtons.YesNo _
                                       , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If userResponse = Windows.Forms.DialogResult.No Then Exit Sub
      End If

      updateRow.BeginEdit()
      updateRow.LanguageId = CType(languageComboBox.SelectedValue, Integer)
      updateRow.BreakDt = breakDtMonthCalendar.SelectionRange.Start
      If noAdsCheckBox.Checked Then
        updateRow.SetPullPageCountNull()
      Else
        updateRow.PullPageCount = CType(pageCountTextBox.Text, Integer)
      End If
      updateRow.PulledById = Processor.UserID
      'updateRow.PullDt = System.DateTime.Now
      updateRow.StatusID = pullStatusId
      updateRow.FormName = FORM_NAME
      updateRow.EndEdit()

      Processor.Synchronize(FORM_NAME)

      ClearAllInputs()
      Me.FormState = FormStateEnum.Insert
      EnableDisableControls(Me.FormState)
      publicationEditionIdTextBox.Focus()

    End Sub

    Private Sub closeButton_Click _
      (ByVal sender As Object, ByVal e As System.EventArgs) _
      Handles closeButton.Click
            isClosedByButton = True
      Me.Close()

    End Sub

    Private Sub PublicationPullForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
      publicationEditionIdTextBox.Focus()
        End Sub

        Private Sub PublicationPullForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If e.CloseReason = CloseReason.UserClosing And isClosedByButton = False Then
                If (MessageBox.Show("Are you sure you want to close this form?", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                    e.Cancel = True
                End If
            End If
        End Sub


    Private Sub PublicationPullForm_FormInitialized() Handles Me.FormInitialized

      Me.StatusMessage = "Loading information, this may take some time. Please wait..."

    End Sub

    Private Sub PublicationPullForm_InitializingForm() Handles Me.InitializingForm

      Me.StatusMessage = String.Empty

    End Sub

    Private Sub m_publicationPullProcessor_InvalidVehicleStatus(ByVal vehicleId As Integer, ByVal statusText As String) Handles m_publicationPullProcessor.InvalidVehicleStatus

      Me.StatusMessage = String.Empty

      MessageBox.Show("Vehicle cannot be loaded because it has the Status of: " + statusText _
                      , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

      ClearAllInputs()
      RemoveAllErrorProviders()

      Me.FormState = FormStateEnum.View
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

      publicationEditionIdTextBox.Focus()

    End Sub

    Private Sub m_publicationPullProcessor_LoadingVehicle(ByVal vehicleId As Integer) Handles m_publicationPullProcessor.LoadingVehicle

      Me.StatusMessage = "Loading vehicle information..."

    End Sub

    Private Sub m_publicationPullProcessor_VehicleLoaded(ByVal vehicleRow As PublicationPullDataSet.vwPublicationEditionRow) Handles m_publicationPullProcessor.VehicleLoaded
      Dim vehicleId As String


      vehicleId = publicationEditionIdTextBox.Text

      ClearAllInputs()
      RemoveAllErrorProviders()

      Processor.LoadPublicationDays(vehicleRow.PublicationId)
      ShowColumnValues(vehicleRow)

      Me.FormState = FormStateEnum.Edit
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

      publicationEditionIdTextBox.Text = vehicleId

      Me.StatusMessage = String.Empty

    End Sub

    Private Sub m_publicationPullProcessor_VehicleNotFound(ByVal vehicleId As Integer) Handles m_publicationPullProcessor.VehicleNotFound

      Me.StatusMessage = String.Empty

      MessageBox.Show("Vehicle " & CType(vehicleId, String) & " not found.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

      ClearAllInputs()
      publicationEditionIdTextBox.Text = CType(vehicleId, String)
      RemoveAllErrorProviders()

      Me.FormState = FormStateEnum.View
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

      publicationEditionIdTextBox.SelectAll()
      publicationEditionIdTextBox.Focus()

    End Sub

    ''' <summary>
    ''' Prepares Required retailers datagrid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PrepareRequiredRetailersDataGridView()
      Dim columnCounter As Integer


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

    Private Sub deleteButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles deleteButton.Click
      Dim vehicleId As Integer
      Dim userResponse As DialogResult


      vehicleId = Processor.Data.vwPublicationEdition(0).VehicleId

      userResponse = MessageBox.Show("Are you sure you want to delete vehicle " + vehicleId.ToString() + "?" _
                                     , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                     , MessageBoxDefaultButton.Button2)

      If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

      Processor.Delete(vehicleId, FORM_NAME)

      Me.FormState = FormStateEnum.View
      ClearAllInputs()
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

    End Sub


        Private Sub publicationEditionIdTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles publicationEditionIdTextBox.TextChanged
            If IsNumeric(publicationEditionIdTextBox.Text) = False Then
                publicationEditionIdTextBox.Text = String.Empty
            End If
        End Sub

        Private Sub marketComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles marketComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub newspaperComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newspaperComboBox.SelectedIndexChanged

        End Sub

        Private Sub languageComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles languageComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub languageComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles languageComboBox.SelectedIndexChanged

        End Sub

        Private Sub PublicationPullForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub
    End Class

End Namespace