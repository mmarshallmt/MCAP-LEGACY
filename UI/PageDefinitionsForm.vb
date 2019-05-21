' TODO: Add loading of existing pages records
' TODO: Saving and loading of pages dataset for current records
' TODO: How to deal with multiple Inserts

Namespace UI
  ''' <summary>
  ''' Takes a vehicle ID
  ''' </summary>
  ''' <remarks></remarks>
  Public Class PageDefinitionsForm
    Inherits MDIChildFormBase
    Implements IForm

#Region "Member Variables"
    Private WithEvents m_pageDefinitions As Processors.PageDefinitions
    Private m_inChangePage As Boolean = False
    Private m_inChangePageOrder As Boolean = False
        Private m_inChangePageSize As Boolean = False
        Private m_inChangePageStartDt As Boolean = False
        Private m_expectedPageCount As Integer
        Private IsOkClicked As Boolean = False
        Private isPreviousClicked As Boolean = False
        Private dsCapture As DataSet
        Private isClosedByButton As Boolean = False
#End Region

#Region "Properties"
        Public ReadOnly Property PageDefinitionsProcessor() As Processors.PageDefinitions
            Get
                Return m_pageDefinitions
            End Get
        End Property
        Public Property VehicleID() As Integer
            Get
                Return Me.PageDefinitionsProcessor.VehicleId
            End Get
            Set(ByVal value As Integer)
                Me.PageDefinitionsProcessor.VehicleId = value
                VehicleIDTextBox.Text = value.ToString()
                Me.PageDefinitionsProcessor.PopulateForm()
                Me.PageDefinitionsProcessor.LoadVehiclePages(Me.PageDefinitionsProcessor.VehicleId)
                Me.PagesDataGridView.Columns(Me.PageDefinitionsProcessor.PagesDataTable.PageTypeIdColumn.Ordinal).Visible = False
            End Set
        End Property
        Public Property ExpectedPageCount() As Integer
            Get
                Return m_expectedPageCount

            End Get
            Set(ByVal value As Integer)
                m_expectedPageCount = value
            End Set
        End Property
        Public Property InChangePage() As Boolean
            Get
                Return m_inChangePage
            End Get
            Set(ByVal value As Boolean)
                m_inChangePage = value
            End Set
        End Property
        Public Property InChangePageOrder() As Boolean
            Get
                Return m_inChangePageOrder
            End Get
            Set(ByVal value As Boolean)
                m_inChangePageOrder = value
            End Set
        End Property
        Public Property InChangePageSize() As Boolean
            Get
                Return m_inChangePageSize
            End Get
            Set(ByVal value As Boolean)
                m_inChangePageSize = value
            End Set
        End Property
#End Region

#Region " IForm Implementation "

    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied

    Public Event FormInitialized() Implements IForm.FormInitialized
    Public Event InitializingForm() Implements IForm.InitializingForm

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials
      'Apply User credentials here.
      Dim appUser As Processors.ApplicationUser
      Dim userScreen As UserRolesDataSet.UserScreensFunctionalityViewRow

      RaiseEvent ApplyingUserCredentials()

      appUser = New Processors.ApplicationUser
      appUser.Initialize()
      appUser.GetFunctionalityListFor(appUser.UserID, Me.Name)

      For Each userScreen In appUser.UserDataSet.UserScreensFunctionalityView
        If userScreen.IsFunctionalityNull Then
        Else
          Select Case userScreen.Functionality.ToUpper
            Case Processors.ApplicationUser.Functionality.EditOnly
            Case Processors.ApplicationUser.Functionality.ViewOnly
            Case Processors.ApplicationUser.Functionality.NewOnly
          End Select
        End If
      Next

      appUser = Nothing

      RaiseEvent UserCredentialsApplied()

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="formStatus"></param>
    ''' <remarks></remarks>
    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init
      RaiseEvent InitializingForm()

      Me.FormState = formStatus

      Me.StatusMessage = "Loading..."

      m_pageDefinitions = New Processors.PageDefinitions(Me)

      Me.PageDefinitionsProcessor.PopulateForm()

      InsertsDataGridView.DataSource = Me.PageDefinitionsProcessor.InsertsDataTable
      PagesDataGridView.DataSource = Me.PageDefinitionsProcessor.PagesDataTable
      PageNameComboBox.DataSource = Me.PageDefinitionsProcessor.PagesDataTable

      Me.StatusMessage = ""

      RaiseEvent FormInitialized()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub ClearAllInputs()
      MyBase.ClearAllInputs()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="formStatus"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub EnableDisableControls(ByVal formStatus As FormStateEnum)
      MyBase.EnableDisableControls(formStatus)
      Select Case formStatus
        Case FormStateEnum.Edit ' Enable
          Me.PageDefinitionsProcessor.SetControlsEnabled(True)
        Case FormStateEnum.View ' Disable
          Me.PageDefinitionsProcessor.SetControlsEnabled(False)
      End Select
    End Sub


#End Region


#Region "Buttons"
    ''' <summary>
    ''' Check if data has changed, prompt to save if data has
    ''' Close the form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton2.Click
            If Me.PageDefinitionsProcessor.DataChanged Then ' data changed
                If InsertsDataGridView.Rows.Count > 0 Then
                    For Each row As DataGridViewRow In InsertsDataGridView.Rows
                        If String.IsNullOrEmpty(row.Cells(0).Value.ToString) = True And (CType(row.Cells(1).Value, Integer) > 0 Or CType(row.Cells(2).Value, Integer) > 0) Then
                            MsgBox("Empty Page Type is not allowed", MsgBoxStyle.Information, "Page Definition")
                            InsertsDataGridView.Rows.Remove(InsertsDataGridView.CurrentRow)
                            Exit Sub
                        End If
                    Next
                End If
                If MessageBox.Show("Data has changed but not been saved.  Save now?", "Page Definitions Changed.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then ' Save data before exiting
                    'Ritesh (29 Sep 2008)
                    'Instead of directly calling SavePage() calling OK button's click event for PageCount check.
                    'Me.PageDefinitionsProcessor.SavePages()
                    OKButton.PerformClick()
                Else
                    Me.Close() 'user don't want to save.
                End If
            Else
                Me.Close()
            End If
    End Sub

    ''' <summary>
    ''' Check to make sure every page has a size, and the first insert page as a location is set
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
            'Debug.Print(StrDup(80, "-"))
            If PagesDataGridView.Rows.Count > 0 Then
                For Each row As DataGridViewRow In PagesDataGridView.Rows

                    If String.IsNullOrEmpty(row.Cells(7).Value.ToString) = False AndAlso CDate(row.Cells(7).Value).Subtract(CDate(row.Cells(8).Value)).Days > 0 _
            Then
                        MessageBox.Show("End Date cannot be before Start Date. Data will not be updated !", ProductName _
                                        , MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub

                    End If

            If String.IsNullOrEmpty(row.Cells(2).Value.ToString) = True Then
                MsgBox("Empty Page Size is not allowed", MsgBoxStyle.Information, "Page Definition")
                'PagesDataGridView.Rows.Remove(PagesDataGridView.CurrentRow)
                Exit Sub
            End If
                Next
            End If

            If Me.PageDefinitionsProcessor.IsValid Then
                Dim pageCount As Integer = Me.PageDefinitionsProcessor.GetPageCount()
                If pageCount <> Me.ExpectedPageCount And Me.ExpectedPageCount > 0 Then
                    If MessageBox.Show("Vehicle was checked in with " & Me.ExpectedPageCount.ToString & " pages, but you have defined " & Me.PageDefinitionsProcessor.GetPageCount.ToString & " pages." & vbCrLf & _
                                       "Are you sure that the defined pages are correct?", Me.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No _
                    Then
                        Exit Sub
                    Else
                        Me.ExpectedPageCount = pageCount  'To return back the new page count to caller form.
                    End If
                End If

                Me.PageDefinitionsProcessor.SavePages()
                For i As Integer = 0 To dsCapture.Tables(0).Rows.Count - 1
                    Me.PageDefinitionsProcessor.UpdatePageInfo(CType(dsCapture.Tables(0).Rows(i).Item(1), Integer), CType(dsCapture.Tables(0).Rows(i).Item(4), Integer), dsCapture.Tables(0).Rows(i).Item(2).ToString)
                Next

                PageDefinitionsProcessor.UpdateAllBlankImageName(VehicleID)
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                ' errors?
                ' find out what exactly isn't valid?
                MessageBox.Show("Page Definitions aren't complete." & vbCrLf & Me.PageDefinitionsProcessor.ErrorText, Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        End Sub
        Private Sub clearInputsValid()
            RemoveErrorProvider(StartDatePicker)
            RemoveErrorProvider(EndDatePicker)
        End Sub
        Private Function AreInputsValid() As Boolean


            Dim areAllValid As Boolean


            areAllValid = True

            If StartDatePicker.Text = "  /  /" And EndDatePicker.Text <> "  /  /" Then
                areAllValid = False
                SetErrorProvider(StartDatePicker, "Provide valid start date.")
            Else
                RemoveErrorProvider(StartDatePicker)
            End If
            If StartDatePicker.Text <> "  /  /" And EndDatePicker.Text = "  /  /" Then
                areAllValid = False
                SetErrorProvider(EndDatePicker, "Provide valid end date.")
            ElseIf StartDatePicker.Value.HasValue AndAlso StartDatePicker.Value.Value.Subtract(EndDatePicker.Value.Value).Days > 0 _
            Then
                MessageBox.Show("End Date cannot be before Start Date.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                areAllValid = False

            Else
                RemoveErrorProvider(EndDatePicker)
            End If

            ' MsgBox(FormatDateTime(CDate(StartDatePicker.Value), DateFormat.ShortDate) + " " + FormatDateTime(CDate(EndDatePicker.Value), DateFormat.ShortDate))
            If StartDatePicker.Value.ToString = "" Then StartDatePicker.Clear()
            If EndDatePicker.Value.ToString = "" Then EndDatePicker.Clear()

            Return areAllValid

        End Function
        Public Sub loadEntyFields()
            If PagesDataGridView.Rows.Count > 0 Then
                If PagesDataGridView.SelectedCells.Count = 7 Then

                    If String.IsNullOrEmpty(PagesDataGridView.SelectedCells.Item(7).Value.ToString) = True Then
                        StartDatePicker.Value = Nothing
                        StartDatePicker.Clear()
                    ElseIf CDate(PagesDataGridView.SelectedCells.Item(7).Value) = CDate("1/1/1900") Then
                        StartDatePicker.Value = Nothing
                        StartDatePicker.Clear()
                    ElseIf CDate(PagesDataGridView.SelectedCells.Item(7).Value) = CDate("1/1/0001") Then
                        StartDatePicker.Value = Nothing
                        StartDatePicker.Clear()
                    End If
                    Dim str As String = PagesDataGridView.SelectedCells.Item(7).Value.ToString
                
                End If
                If PagesDataGridView.SelectedCells.Count = 8 Then
                    If String.IsNullOrEmpty(PagesDataGridView.SelectedCells.Item(8).Value.ToString) = True Then
                        EndDatePicker.Value = Nothing
                        EndDatePicker.Clear()
                    ElseIf CDate(PagesDataGridView.SelectedCells.Item(8).Value) = CDate("1/1/1900") Then
                        EndDatePicker.Value = Nothing
                        EndDatePicker.Clear()
                    ElseIf CDate(PagesDataGridView.SelectedCells.Item(8).Value) = CDate("1/1/0001") Then
                        EndDatePicker.Value = Nothing
                        EndDatePicker.Clear()
                    End If
             
                End If

            End If

        End Sub
        ''' <summary>
        ''' Move a page back in the page drop down
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub PrevButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrevButton.Click
            'Debug.Print(Now.ToString & " EVENT BEGIN: PrevButton_Click")

            If AreInputsValid() = False Then Exit Sub

            Me.PageDefinitionsProcessor.MovePrevious()

            If PagesDataGridView.Rows.Count > 0 Then

                If String.IsNullOrEmpty(PagesDataGridView.SelectedCells.Item(7).Value.ToString) = True Then
                    StartDatePicker.Value = Nothing
                    StartDatePicker.Clear()
                ElseIf CDate(PagesDataGridView.SelectedCells.Item(7).Value) = CDate("1/1/1900") Then
                    StartDatePicker.Value = Nothing
                    StartDatePicker.Clear()
                ElseIf CDate(PagesDataGridView.SelectedCells.Item(7).Value) = CDate("1/1/0001") Then
                    StartDatePicker.Value = Nothing
                    StartDatePicker.Clear()
                End If
                Dim str As String = PagesDataGridView.SelectedCells.Item(7).Value.ToString


                If String.IsNullOrEmpty(PagesDataGridView.SelectedCells.Item(8).Value.ToString) = True Then
                    EndDatePicker.Value = Nothing
                    EndDatePicker.Clear()
                ElseIf CDate(PagesDataGridView.SelectedCells.Item(8).Value) = CDate("1/1/1900") Then
                    EndDatePicker.Value = Nothing
                    EndDatePicker.Clear()
                ElseIf CDate(PagesDataGridView.SelectedCells.Item(8).Value) = CDate("1/1/0001") Then
                    EndDatePicker.Value = Nothing
                    EndDatePicker.Clear()
                End If


            End If

            'Debug.Print(Now.ToString & " EVENT END: PrevButton_Click")
        End Sub

        ''' <summary>
        ''' Move a page forward in the page drop down
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub NextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextButton.Click
            'Debug.Print(Now.ToString & " EVENT BEGIN: NextButton_Click")
            If AreInputsValid() = False Then Exit Sub

            Me.PageDefinitionsProcessor.MoveNext()

            If PagesDataGridView.Rows.Count > 0 Then

                If String.IsNullOrEmpty(PagesDataGridView.SelectedCells.Item(7).Value.ToString) = True Then
                    StartDatePicker.Value = Nothing
                    StartDatePicker.Clear()
                ElseIf CDate(PagesDataGridView.SelectedCells.Item(7).Value) = CDate("1/1/1900") Then
                    StartDatePicker.Value = Nothing
                    StartDatePicker.Clear()
                ElseIf CDate(PagesDataGridView.SelectedCells.Item(7).Value) = CDate("1/1/0001") Then
                    StartDatePicker.Value = Nothing
                    StartDatePicker.Clear()
                End If
                Dim str As String = PagesDataGridView.SelectedCells.Item(7).Value.ToString


                If String.IsNullOrEmpty(PagesDataGridView.SelectedCells.Item(8).Value.ToString) = True Then
                    EndDatePicker.Value = Nothing
                    EndDatePicker.Clear()
                ElseIf CDate(PagesDataGridView.SelectedCells.Item(8).Value) = CDate("1/1/1900") Then
                    EndDatePicker.Value = Nothing
                    EndDatePicker.Clear()
                ElseIf CDate(PagesDataGridView.SelectedCells.Item(8).Value) = CDate("1/1/0001") Then
                    EndDatePicker.Value = Nothing
                    EndDatePicker.Clear()
                End If

            End If
            'Debug.Print(Now.ToString & " EVENT END: NextButton_Click")
        End Sub

        ''' <summary>
        ''' take the currently selected size and copy to all pages after confirmation.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub CopyToAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToAllButton.Click
            If AreInputsValid() = False Then Exit Sub
            'Debug.Print(Now.ToString & " EVENT BEGIN: CopyToAllButton_Click")
            Me.PageDefinitionsProcessor.CopyToAll()
            'Debug.Print(Now.ToString & " EVENT END: CopyToAllButton_Click")
        End Sub

        ''' <summary>
        ''' Take the current size, save it for the current page, and keeps the size for the next page.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub CopyToNextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToNextButton.Click
            If AreInputsValid() = False Then Exit Sub
            'Debug.Print(Now.ToString & " EVENT BEGIN: CopyToNextButton_Click")
            Me.PageDefinitionsProcessor.CopyToNext()

            If String.IsNullOrEmpty(StartDatePicker.Value.ToString) = False Then
                Me.PageDefinitionsProcessor.CopyStartDateToNext()
                Me.PageDefinitionsProcessor.ChangePageStart()
            End If
            If String.IsNullOrEmpty(EndDatePicker.Value.ToString) = False Then
                Me.PageDefinitionsProcessor.CopyEndDateToNext()
                Me.PageDefinitionsProcessor.ChangePageEnd()
            End If
            loadEntyFields()
            'Debug.Print(Now.ToString & " EVENT END: CopyToNextButton_Click")
        End Sub

#End Region

#Region " Masked Textbox Functions "

        Private Sub sizeMaskedTextBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles sizeMaskedTextBox.KeyUp
            Dim selectedIndex As Integer
            Dim inputString As System.Text.StringBuilder


            inputString = New System.Text.StringBuilder()

            inputString.Append(Me.sizeMaskedTextBox.Text)

            inputString = inputString.Replace("  X  ", "")
            inputString = inputString.Replace("  X", "")
            inputString = inputString.Replace("X  ", "")

            inputString = inputString.Replace(" . ", "")
            inputString = inputString.Replace(" .", "")
            inputString = inputString.Replace(". ", "")

            selectedIndex = SizeComboBox.FindString(inputString.ToString())

            If e.KeyCode = Keys.Back OrElse selectedIndex < 0 Then
                Select Case inputString.Length
                    Case 6, 11
                        inputString = inputString.Remove(inputString.Length - 2, 2)
                    Case Else
                        inputString = inputString.Remove(inputString.Length - 1, 1)
                End Select
            End If

            'SizeComboBox.Text = inputString.ToString()
            selectedIndex = SizeComboBox.FindString(inputString.ToString())
            If selectedIndex < 0 Then
                e.Handled = True
                Exit Sub
                'SizeComboBox.SelectedIndex = -1
                'SizeComboBox.SelectedValue = DBNull.Value
            Else
                SizeComboBox.SelectedIndex = selectedIndex
            End If

            If SizeComboBox.SelectedIndex >= 0 AndAlso inputString.Length < 13 Then
                With sizeMaskedTextBox
                    .Text = SizeComboBox.Text
                    .SelectionStart = inputString.Length
                    .SelectionLength = 13 - inputString.Length
                End With
            End If

            inputString.Remove(0, inputString.Length)
            inputString = Nothing

        End Sub

#End Region

#Region "Combo Box Functions"
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub PageNameComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageNameComboBox.SelectedIndexChanged
            'Debug.Print(Now.ToString & " EVENT BEGIN: PageNameComboBox_SelectedIndexChanged")
            If m_inChangePage Or m_inChangePageOrder Or m_inChangePageSize Then
                'Debug.Print(Now.ToString & " Nothing doing because in some other function")
                'Debug.Print(Now.ToString & " EVENT END: PageNameComboBox_SelectedIndexChanged")
                Exit Sub
            End If

            loadEntyFields()
            Me.PageDefinitionsProcessor.ChangePage()

            'Debug.Print(Now.ToString & " EVENT END: PageNameComboBox_SelectedIndexChanged")
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub SizeComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SizeComboBox.SelectedIndexChanged

            'Debug.Print(Now.ToString & " EVENT BEGIN: SizeComboBox_SelectedIndexChanged")
            If SizeComboBox.SelectedIndex > -1 Then Me.sizeMaskedTextBox.Text = SizeComboBox.Text
            If m_inChangePage Or m_inChangePageOrder Or m_inChangePageSize Then
                'Debug.Print(Now.ToString & " Nothing doing because in some other function")
                'Debug.Print(Now.ToString & " EVENT END: SizeComboBox_SelectedIndexChanged")
                Exit Sub
            End If
            Me.PageDefinitionsProcessor.ChangePageSize()
            'Debug.Print(Now.ToString & " EVENT END: SizeComboBox_SelectedIndexChanged")
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub PageOrderComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageOrderComboBox.SelectedIndexChanged
            'Debug.Print(Now.ToString & " EVENT BEGIN: PageOrderComboBox_SelectedIndexChanged")
            If m_inChangePage Or m_inChangePageOrder Or m_inChangePageSize Then
                'Debug.Print(Now.ToString & " Nothing doing because in some other function")
                'Debug.Print(Now.ToString & " EVENT END: PageOrderComboBox_SelectedIndexChanged")
                Exit Sub
            End If
            Me.PageDefinitionsProcessor.ChangePageOrder()
            'Debug.Print(Now.ToString & " EVENT END: PageOrderComboBox_SelectedIndexChanged")
        End Sub
#End Region

#Region "Text Box Validation"

        Private Sub BaseTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles BaseTextBox.Validating
            Dim b As Integer


            If Not Integer.TryParse(BaseTextBox.Text, b) Then
                MessageBox.Show("Number of Base Pages must be a positive integer.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                BaseTextBox.SelectAll()
                e.Cancel = True
            ElseIf b < 0 Then
                MessageBox.Show("Number of Base Pages must be a positive integer.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                BaseTextBox.SelectAll()
                e.Cancel = True
            End If

        End Sub

        Private Sub BaseTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles BaseTextBox.Validated

            If BaseTextBox.Text = String.Empty Then
                If Me.PageDefinitionsProcessor.IsPageCountDifferent() Then
                    Me.PageDefinitionsProcessor.PopulatePageDataTable()
                End If

                If Me.PageDefinitionsProcessor.PageCountDefined Then
                    Me.EnableDisableControls(FormStateEnum.Edit)
                Else
                    Me.EnableDisableControls(FormStateEnum.View)
                End If

                Exit Sub
            End If

            If Me.PageDefinitionsProcessor.IsPageCountDifferent() Then
                Me.PageDefinitionsProcessor.PopulatePageDataTable()
            End If
            'If Me.PageDefinitionsProcessor.PageCountDefined Then
            Me.EnableDisableControls(FormStateEnum.Edit)
            'Else
            'Me.EnableDisableControls(FormStateEnum.View)
            'End If
            'Debug.Print(Now.ToString & " EVENT END: BaseTextBox_Validated")
        End Sub

       

#End Region

#Region "Inserts Data Grid Functions"


        Private Sub AddRowInInsertDataGridView()
            Dim row As DataGridViewRow


            For Each row In InsertsDataGridView.SelectedRows
                row.Selected = False
            Next

            'Me.PageDefinitionsProcessor.InsertsDataTable.AddInsertsRow(Me.PageDefinitionsProcessor.InsertsDataTable.Rows.Count + 1, 0)
            Me.PageDefinitionsProcessor.InsertsDataTable.AddInsertsRow(0, 0)
            InsertsDataGridView.Rows(InsertsDataGridView.RowCount - 1).Selected = True

            If InsertsDataGridView.CurrentCell.RowIndex <> (InsertsDataGridView.RowCount - 1) Then
                InsertsDataGridView.CurrentCell = InsertsDataGridView.Rows(InsertsDataGridView.RowCount - 1).Cells(0)
            End If

        End Sub

        Private Sub RemoveRowFromInsertDataGridView()
            Dim i As Integer
            Dim row As DataGridViewRow
            Dim pgtypeRow As PageDefinitionsDataSet.PageTypeRow
            Dim pgRow As PageDefinitionsDataSet.InsertsRow


            If InsertsDataGridView.SelectedRows.Count > 0 Then
                For Each row In InsertsDataGridView.SelectedRows
                    InsertsDataGridView.Rows.Remove(row)
                Next

                ' Renumber inserts
                For Each pgtypeRow In Me.PageDefinitionsDataSet.PageType
                    i = 0
                    For Each pgRow In Me.PageDefinitionsProcessor.InsertsDataTable.Select("PageTypeId='" + pgtypeRow.PageTypeId + "'", "Number")
                        pgRow.Number = i + 1
                        i += 1
                    Next
                Next

                Me.PageDefinitionsProcessor.PopulatePageDataTable()
            End If

        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>Solution from http://www.issociate.de/board/post/300549/Avoid_entering_read-only_column_in_DataGridView?.html</remarks>
        Private Sub InsertsDataGridView_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles InsertsDataGridView.CellEnter
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)


            ' Check for disabled. If so the force move to next control
            If InsertsDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).ReadOnly Then
                'SendKeys.Send("{TAB}")
                SendKeys.Send(ChrW(Keys.Tab))
            End If

        End Sub

        Private Sub InsertsDataGridView_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles InsertsDataGridView.CellValidating
            Dim isValid As Boolean
            Dim insertCount As Integer
            Dim cell As System.Windows.Forms.DataGridViewCell



            If (e.ColumnIndex <> 2) Then Exit Sub

            If InsertsDataGridView.CurrentCell.RowIndex = e.RowIndex _
              AndAlso InsertsDataGridView.CurrentCell.ColumnIndex = e.ColumnIndex _
            Then
                cell = InsertsDataGridView.CurrentCell
            Else
                cell = InsertsDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)
            End If

            isValid = True

            If Integer.TryParse(cell.EditedFormattedValue.ToString(), insertCount) = False Then
                isValid = False
            ElseIf insertCount = 0 AndAlso (e.RowIndex = InsertsDataGridView.Rows.Count - 1) Then
                isValid = True
            ElseIf insertCount < 1 OrElse insertCount > 99 Then
                isValid = False
            End If

            If isValid = False Then
                MessageBox.Show("Value should be a numeric and between 1 to 99.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                e.Cancel = True
            End If

        End Sub

        Private Sub SetNumberForPageType()
            Dim pagetypeNumber As Object
            Dim tempRowArray() As System.Data.DataRow
            Dim tempRow As PageDefinitionsDataSet.InsertsRow


            tempRowArray = Me.PageDefinitionsProcessor.InsertsDataTable.Select("Number=0")

            For i As Integer = 0 To tempRowArray.Count - 1
                tempRow = CType(tempRowArray(i), PageDefinitionsDataSet.InsertsRow)

                If tempRow.IsPageTypeIdNull() = False Then
                    pagetypeNumber = Me.PageDefinitionsProcessor.InsertsDataTable.Compute("MAX(Number)", "PageTypeId='" + tempRow.PageTypeId + "'")
                End If

                If pagetypeNumber Is Nothing OrElse pagetypeNumber Is DBNull.Value Then
                    pagetypeNumber = 0
                End If

                tempRow.Number = CType(pagetypeNumber, Integer) + 1

                pagetypeNumber = Nothing
                pagetypeNumber = Me.PageDefinitionsProcessor.PagesDataTable.Compute("MAX(ReceivedOrder)", "ReceivedOrder IS NOT NULL")
                If pagetypeNumber Is Nothing OrElse pagetypeNumber Is DBNull.Value Then
                    pagetypeNumber = 0
                End If

                tempRow.StartPage = CType(pagetypeNumber, Integer) + 1

                pagetypeNumber = Nothing
            Next

        End Sub

        Private Sub InsertsDataGridView_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles InsertsDataGridView.CellValueChanged

            Me.RemoveErrorProvider(InsertsDataGridView)

            If InsertsDataGridView.Rows.Count > 0 Then
                For Each row As DataGridViewRow In InsertsDataGridView.Rows
                    If String.IsNullOrEmpty(row.Cells(0).Value.ToString) = True And (CType(row.Cells(1).Value, Integer) > 0 Or CType(row.Cells(2).Value, Integer) > 0) Then
                        MsgBox("Empty Page Type is not allowed", MsgBoxStyle.Information, "Page Definition")
                        InsertsDataGridView.Rows.Remove(InsertsDataGridView.CurrentRow)
                        Exit Sub
                    End If
                Next
            End If

            ' Populate Pages?
            If m_pageDefinitions Is Nothing Then
                Debug.Print(Now.ToString & ": m_pageDefinitions Is Nothing.")
                Exit Sub
            End If

            If Not Me.PageDefinitionsProcessor.IsInsertsDataTableNothing Then
                If e.ColumnIndex = Me.PageDefinitionsProcessor.InsertsDataTable.PageCountColumn.Ordinal Then
                    SetNumberForPageType()
                    Me.PageDefinitionsProcessor.PopulatePageDataTable()
                End If
            End If

        End Sub

        Private Sub InsertsDataGridView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertsDataGridView.Click

            If InsertsDataGridView.RowCount = 0 Then AddRowInInsertDataGridView()

        End Sub

        Private Sub InsertsDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles InsertsDataGridView.DataError

            If e.ColumnIndex = Me.PageDefinitionsProcessor.InsertsDataTable.Columns("PageCount").Ordinal Then
                m_ErrorProvider.SetError(InsertsDataGridView, "Page Count must be an integer value.")
            ElseIf e.ColumnIndex = Me.PageDefinitionsProcessor.InsertsDataTable.Columns("Number").Ordinal Then
                m_ErrorProvider.SetError(InsertsDataGridView, "Insert Number must be an integer value.")
            End If

        End Sub

        Private Sub InsertsDataGridView_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertsDataGridView.GotFocus

            If InsertsDataGridView.RowCount = 0 Then
                AddRowInInsertDataGridView()

            End If

            loadEntyFields()
        End Sub

        Private Sub InsertsDataGridView_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles InsertsDataGridView.KeyUp

            'User can delete any row in inserts grid but can add new row only when selected row is the last row in grid.
            If (e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back) _
              AndAlso Me.InsertsDataGridView.CurrentRow IsNot Nothing _
            Then
                RemoveRowFromInsertDataGridView()
            ElseIf e.KeyCode = Keys.Enter _
              AndAlso (Me.InsertsDataGridView.CurrentRow IsNot Nothing _
                        AndAlso Me.InsertsDataGridView.CurrentRow.Index = (Me.InsertsDataGridView.Rows.Count - 1)) _
            Then
                Dim insertCount As Integer

                Integer.TryParse(Me.InsertsDataGridView.CurrentRow.Cells(1).EditedFormattedValue.ToString(), insertCount)
                If insertCount < 1 Then Exit Sub

                Dim ctrPageCount As Integer = CType(Me.InsertsDataGridView.CurrentRow.Cells(2).Value, Integer)
                If ctrPageCount = 0 Then Exit Sub
                AddRowInInsertDataGridView()
            End If

            'If Me.InsertsDataGridView.CurrentRow Is Nothing _
            '  OrElse Me.InsertsDataGridView.CurrentRow.Index <> (Me.InsertsDataGridView.Rows.Count - 1) _
            'Then Exit Sub

            'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            '  RemoveRowFromInsertDataGridView()
            'ElseIf e.KeyCode = Keys.Enter Then
            '  Dim insertCount As Integer

            '  Integer.TryParse(Me.InsertsDataGridView.CurrentRow.Cells(1).EditedFormattedValue.ToString(), insertCount)
            '  If insertCount < 1 Then Exit Sub

            '  AddRowInInsertDataGridView()
            'End If

        End Sub

        Private Sub InsertsDataGridView_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles InsertsDataGridView.RowsRemoved

            If e.RowIndex = 0 Then Exit Sub

            For i As Integer = 0 To InsertsDataGridView.Rows.Count - 1
                InsertsDataGridView.Rows(i).Selected = False
            Next

            InsertsDataGridView.Rows(e.RowIndex - 1).Selected = True

        End Sub


#End Region


        Private Sub PageDefinitionsForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If e.CloseReason = CloseReason.UserClosing And IsOkClicked = False And isClosedByButton = False Then
                If (MessageBox.Show("Are you sure you want to close this form?", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                    e.Cancel = True
                End If
            Else
                IsOkClicked = False
            End If
        End Sub

        Private Sub PageDefinitionsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            dsCapture = Me.PageDefinitionsProcessor.CapturePage(VehicleID)
            'PagesDataGridView.ClearSelection()
        End Sub
        Sub validateDateInfo()

            If AreInputsValid() = True Then
                Me.PageDefinitionsProcessor.ChangePageStart()
                If CDate(PagesDataGridView.SelectedCells.Item(7).Value) = CDate("01/01/1900") Then PagesDataGridView.SelectedCells.Item(7).Value = ""
                'Debug.Print(Now.ToString & " EVENT END: SizeComboBox_SelectedIndexChanged")

                Me.PageDefinitionsProcessor.ChangePageEnd()
                If CDate(PagesDataGridView.SelectedCells.Item(8).Value) = CDate("01/01/1900") Then PagesDataGridView.SelectedCells.Item(8).Value = ""
                'Debug.Print(Now.ToString & " EVENT END: SizeComboBox_SelectedIndexChanged")

            End If

        End Sub

        Private Sub StartDatePicker_KeyUp(sender As Object, e As KeyEventArgs) Handles StartDatePicker.KeyUp
            'Debug.Print(Now.ToString & " EVENT BEGIN: SizeComboBox_SelectedIndexChanged")
            'If SizeComboBox.SelectedIndex > -1 Then Me.sizeMaskedTextBox.Text = SizeComboBox.Text
            If m_inChangePage Or m_inChangePageOrder Or m_inChangePageSize Or m_inChangePageStartDt Then
                'Debug.Print(Now.ToString & " Nothing doing because in some other function")
                'Debug.Print(Now.ToString & " EVENT END: SizeComboBox_SelectedIndexChanged")
                Exit Sub
            End If

            validateDateInfo()
          
        End Sub

        Private Sub StartDatePicker_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles StartDatePicker.Validating
            'Debug.Print(Now.ToString & " EVENT BEGIN: SizeComboBox_SelectedIndexChanged")
            'If SizeComboBox.SelectedIndex > -1 Then Me.sizeMaskedTextBox.Text = SizeComboBox.Text
            If m_inChangePage Or m_inChangePageOrder Or m_inChangePageSize Or m_inChangePageStartDt Then
                'Debug.Print(Now.ToString & " Nothing doing because in some other function")
                'Debug.Print(Now.ToString & " EVENT END: SizeComboBox_SelectedIndexChanged")
                Exit Sub
            End If

            validateDateInfo()
            'If AreInputsValid() = True Then
            '    Me.PageDefinitionsProcessor.ChangePageStart()
            '    If CDate(PagesDataGridView.SelectedCells.Item(7).Value) = CDate("01/01/1900") Then PagesDataGridView.SelectedCells.Item(7).Value = ""
            '    'Debug.Print(Now.ToString & " EVENT END: SizeComboBox_SelectedIndexChanged")

            'End If
        End Sub

        Private Sub EndDatePicker_KeyUp(sender As Object, e As KeyEventArgs) Handles EndDatePicker.KeyUp
            'Debug.Print(Now.ToString & " EVENT BEGIN: SizeComboBox_SelectedIndexChanged")
            'If SizeComboBox.SelectedIndex > -1 Then Me.sizeMaskedTextBox.Text = SizeComboBox.Text
            If m_inChangePage Or m_inChangePageOrder Or m_inChangePageSize Or m_inChangePageStartDt Then
                'Debug.Print(Now.ToString & " Nothing doing because in some other function")
                'Debug.Print(Now.ToString & " EVENT END: SizeComboBox_SelectedIndexChanged")
                Exit Sub
            End If

            validateDateInfo()
            'If AreInputsValid() = True Then
            '    Me.PageDefinitionsProcessor.ChangePageEnd()
            '    If CDate(PagesDataGridView.SelectedCells.Item(8).Value) = CDate("01/01/1900") Then PagesDataGridView.SelectedCells.Item(8).Value = ""
            '    'Debug.Print(Now.ToString & " EVENT END: SizeComboBox_SelectedIndexChanged")

            'End If
        End Sub

        Private Sub EndDatePicker_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles EndDatePicker.Validating
            'Debug.Print(Now.ToString & " EVENT BEGIN: SizeComboBox_SelectedIndexChanged")
            'If SizeComboBox.SelectedIndex > -1 Then Me.sizeMaskedTextBox.Text = SizeComboBox.Text
            If m_inChangePage Or m_inChangePageOrder Or m_inChangePageSize Or m_inChangePageStartDt Then
                'Debug.Print(Now.ToString & " Nothing doing because in some other function")
                'Debug.Print(Now.ToString & " EVENT END: SizeComboBox_SelectedIndexChanged")
                Exit Sub
            End If
            validateDateInfo()
            'If AreInputsValid() = True Then
            '    Me.PageDefinitionsProcessor.ChangePageEnd()
            '    If CDate(PagesDataGridView.SelectedCells.Item(8).Value) = CDate("01/01/1900") Then PagesDataGridView.SelectedCells.Item(8).Value = ""
            '    'Debug.Print(Now.ToString & " EVENT END: SizeComboBox_SelectedIndexChanged")


            'End If
        End Sub

        Private Sub PagesDataGridView_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles PagesDataGridView.CellMouseClick
            If AreInputsValid() = False Then Exit Sub
            If PagesDataGridView.Rows.Count > 0 Then
                Dim str As String = PagesDataGridView.SelectedCells.Item(7).Value.ToString
                If String.IsNullOrEmpty(PagesDataGridView.SelectedCells.Item(7).Value.ToString) = True Then
                    StartDatePicker.Value = Nothing
                    StartDatePicker.Clear()
                ElseIf CDate(PagesDataGridView.SelectedCells.Item(7).Value) = CDate("1/1/0001") Then
                    StartDatePicker.Value = Nothing
                    StartDatePicker.Clear()
                End If
                If String.IsNullOrEmpty(PagesDataGridView.SelectedCells.Item(8).Value.ToString) = True Then
                    EndDatePicker.Value = Nothing
                    EndDatePicker.Clear()
                ElseIf CDate(PagesDataGridView.SelectedCells.Item(8).Value) = CDate("1/1/0001") Then
                    EndDatePicker.Value = Nothing
                    EndDatePicker.Clear()
                End If
            End If
        End Sub

    End Class

End Namespace
