Namespace UI

  Public Class PublicationNotDroppedForm
    Implements IForm



    Private WithEvents m_processor As UI.Processors.PublicationNotDropped



    Private ReadOnly Property Processor() As UI.Processors.PublicationNotDropped
      Get
        Return m_processor
      End Get
    End Property



    Protected Overrides Sub ClearAllInputs()

      marketComboBox.SelectedValue = DBNull.Value
      newspaperComboBox.SelectedValue = DBNull.Value
      breakDateListBox.Items.Clear()

    End Sub

    Protected Overrides Sub RemoveAllErrorProviders()

      RemoveErrorProvider(marketComboBox)
      RemoveErrorProvider(newspaperComboBox)
      RemoveErrorProvider(breakDateListBox)

    End Sub

    Protected Overrides Sub EnableDisableControls(ByVal formStatus As FormStateEnum)

      marketComboBox.Enabled = True
      newspaperComboBox.Enabled = True
      clearDatesButton.Enabled = True
      newButton.Enabled = True

      'Select Case formStatus
      '  Case FormStateEnum.Insert
      '    marketComboBox.Enabled = True
      '    newspaperComboBox.Enabled = True
      '    clearDatesButton.Enabled = True
      '    newButton.Enabled = True
      '    'deleteButton.Enabled = False

      '  Case FormStateEnum.Edit

      '  Case FormStateEnum.View
      '    marketComboBox.Enabled = False
      '    newspaperComboBox.Enabled = False
      '    clearDatesButton.Enabled = False
      '    newButton.Enabled = False
      '    'deleteButton.Enabled = True
      'End Select

    End Sub

    Protected Overrides Sub ShowHideControls(ByVal formStatus As FormStateEnum)

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

      If newspaperComboBox.SelectedValue Is Nothing Then
        checkInMonthCalendar.BoldedDates = Nothing
        Exit Sub
      End If

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

    Private Function ValidateInputs() As Boolean
      Dim isValid As Boolean


      isValid = True

      If marketComboBox.SelectedValue Is Nothing Then
        SetErrorProvider(marketComboBox, "Select market from drop down list.")
        isValid = False
      Else
        RemoveErrorProvider(marketComboBox)
      End If

      If newspaperComboBox.SelectedValue Is Nothing Then
        SetErrorProvider(newspaperComboBox, "Select publication from drop down list.")
        isValid = False
      Else
        RemoveErrorProvider(newspaperComboBox)
      End If

      If breakDateListBox.Items.Count = 0 Then
        SetErrorProvider(breakDateListBox, "Select ad date from bold dates in calendar.")
        isValid = False
      Else
        RemoveErrorProvider(breakDateListBox)
      End If

      Return isValid

    End Function

    Private Sub ShowErrors(ByVal row As PublicationNotDroppedDataSet.PublicationNotDroppedRow)
      Dim errorText As System.Text.StringBuilder


      errorText = New System.Text.StringBuilder()

      If row.GetColumnError("MktId").Length > 0 Then
        errorText.Append("Market - ")
        errorText.Append(row.GetColumnError("MktId"))
      End If

      If row.GetColumnError("PublicationId").Length > 0 Then
        If errorText.Length > 0 Then errorText.Append(Environment.NewLine)
        errorText.Append("Publication - ")
        errorText.Append(row.GetColumnError("PublicationId"))
      End If

      If row.GetColumnError("BreakDt").Length > 0 Then
        If errorText.Length > 0 Then errorText.Append(Environment.NewLine)
        errorText.Append("Ad date - ")
        errorText.Append(row.GetColumnError("BreakDt"))
      End If

      If row.RowError.Length > 0 Then
        If errorText.Length > 0 Then errorText.Append(Environment.NewLine)
        errorText.Append(row.MktRow.Descrip)
        errorText.Append(", ")
        errorText.Append(row.PublicationRow.Descrip)
        errorText.Append(", ")
        errorText.Append(row.BreakDt.ToString("MM/dd/yyyy"))
        errorText.Append(" - ")
        errorText.Append(row.RowError)
      End If

      errorText.Append(Environment.NewLine)

      MessageBox.Show(errorText.ToString(), ProductName, MessageBoxButtons.OK _
                      , MessageBoxIcon.Information)

      errorText.Remove(0, errorText.Length)
      errorText = Nothing

    End Sub


#Region " IForm implementation "

    Public Event InitializingForm() Implements IForm.InitializingForm
    Public Event FormInitialized() Implements IForm.FormInitialized
    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied


    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

    End Sub

    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

      Me.StatusMessage = "Information loaded, preparing to show loaded information on window."

      Me.SuspendLayout()

      Me.FormState = formStatus

      RaiseEvent InitializingForm()

      m_processor = New UI.Processors.PublicationNotDropped()

      Processor.LoadDataSet()

      checkedInByValueLabel.Text = Processor.UserFirstName + " " + Processor.UserLastName

      marketComboBox.DisplayMember = "Descrip"
      marketComboBox.ValueMember = "MktId"
      marketComboBox.DataSource = Processor.Data.Mkt

      newspaperComboBox.DisplayMember = "Descrip"
      newspaperComboBox.ValueMember = "PublicationId"
      newspaperComboBox.DataSource = Processor.Data.Publication

      ClearAllInputs()
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

      RaiseEvent FormInitialized()

      Me.ResumeLayout()

      Me.StatusMessage = String.Empty

    End Sub

#End Region


    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

      Me.Close()

        End Sub

        Private Sub marketComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles marketComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

    Private Sub marketComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles marketComboBox.SelectedValueChanged
      Dim marketId As Integer


      If marketComboBox.SelectedValue Is Nothing _
        OrElse Integer.TryParse(marketComboBox.SelectedValue.ToString(), marketId) = False _
      Then
        marketId = -1
      End If

      Processor.LoadPublications(marketId)

      newspaperComboBox.Text = String.Empty
      newspaperComboBox.SelectedValue = DBNull.Value
      newspaperComboBox.SelectedIndex = -1

      If newspaperComboBox.Items.Count = 1 Then newspaperComboBox.SelectedIndex = 0

        End Sub

        Private Sub newspaperComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles newspaperComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

    Private Sub newspaperComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles newspaperComboBox.SelectedValueChanged
      Dim marketId, publicationId As Integer


      If marketComboBox.SelectedValue Is Nothing _
        OrElse Integer.TryParse(marketComboBox.SelectedValue.ToString(), marketId) = False _
      Then
        marketId = -1
      End If

      If newspaperComboBox.SelectedValue Is Nothing _
        OrElse Integer.TryParse(newspaperComboBox.SelectedValue.ToString(), publicationId) = False _
      Then
        publicationId = -1
      End If

      Processor.LoadPublicationDays(publicationId)
      GiveClueForValidPublicationDates(checkInMonthCalendar.SelectionStart)

    End Sub

    Private Sub checkInMonthCalendar_DateChanged _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) _
        Handles checkInMonthCalendar.DateChanged

      GiveClueForValidPublicationDates(e.Start)

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

      If loopStartDate > Today Then
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

    Private Sub clearButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles clearButton.Click

      Me.FormState = FormStateEnum.Insert
      ClearAllInputs()
      RemoveAllErrorProviders()
      EnableDisableControls(Me.FormState)
      ShowHideControls(Me.FormState)

    End Sub

    Private Sub newButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles newButton.Click
      Dim marketId, publicationId As Integer
      Dim tempDate As DateTime
      Dim tempRow As PublicationNotDroppedDataSet.PublicationNotDroppedRow


      If validateInputs() = False Then Exit Sub

      marketId = CType(marketComboBox.SelectedValue, Integer)
      publicationId = CType(newspaperComboBox.SelectedValue, Integer)

      For i As Integer = 0 To breakDateListBox.Items.Count - 1
        tempDate = CType(breakDateListBox.Items(i), DateTime)

        tempRow = Processor.Data.PublicationNotDropped.NewPublicationNotDroppedRow()

        tempRow.BeginEdit()
        tempRow.MktId = marketId
        tempRow.PublicationId = publicationId
        tempRow.BreakDt = tempDate
        'tempRow.CreateDt = System.DateTime.Now
        tempRow.CreatedById = Processor.UserID
        tempRow.EndEdit()

        Processor.Validate(tempRow)
        If tempRow.HasErrors Then Continue For

        Processor.Data.PublicationNotDropped.AddPublicationNotDroppedRow(tempRow)
      Next

      Processor.Save()

      tempRow = Nothing

      ClearAllInputs()
      RemoveAllErrorProviders()
      EnableDisableControls(Me.FormState)
      ShowHideControls(Me.FormState)

      marketComboBox.Focus()

    End Sub

    Private Sub deleteButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles deleteButton.Click
      Dim marketId, publicationId, deleteCount As Integer
      Dim userResponse As DialogResult
      Dim userName As String
      Dim tempDate As DateTime
      Dim publicationText As System.Text.StringBuilder
      Dim tempRow As PublicationNotDroppedDataSet.PublicationNotDroppedRow


      If ValidateInputs() = False Then Exit Sub

      publicationText = New System.Text.StringBuilder()

      deleteCount = 0
      marketId = CType(marketComboBox.SelectedValue, Integer)
      publicationId = CType(newspaperComboBox.SelectedValue, Integer)

      For i As Integer = 0 To breakDateListBox.Items.Count - 1
        tempDate = CType(breakDateListBox.Items(i), DateTime)

        publicationText.Remove(0, publicationText.Length)
        publicationText.Append(" ")
        publicationText.Append(marketComboBox.Text)
        publicationText.Append(", ")
        publicationText.Append(newspaperComboBox.Text)
        publicationText.Append(", ")
        publicationText.Append(tempDate.ToString("MM/dd/yyyy"))

        Processor.LoadPublicationNotDropped(marketId, publicationId, tempDate)
        If Processor.Data.PublicationNotDropped.Count = 0 Then
          MessageBox.Show("Cannot remove publication - " + publicationText.ToString() _
                          + Environment.NewLine + "It is not marked as no drop." _
                          , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
          Continue For
        End If

        userName = Processor.GetPublicationCheckedInByUserName(marketId, publicationId, tempDate)
        publicationText.Append(" - Marked by ")
        publicationText.Append(userName)

        userResponse = MessageBox.Show("Are you sure, you want to remove publication -" _
                                       + publicationText.ToString() + "? ", ProductName _
                                       , MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        tempRow = Processor.Data.PublicationNotDropped(0)

        If userResponse = Windows.Forms.DialogResult.Yes Then
          tempRow.Delete()
          Processor.Save()
          deleteCount += 1
        End If
      Next

      If deleteCount > 0 Then
        MessageBox.Show(deleteCount.ToString() + " publication(s) removed successfully from list of" _
                        + " No Drop.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If


      ClearAllInputs()
      RemoveAllErrorProviders()
      EnableDisableControls(Me.FormState)
      ShowHideControls(Me.FormState)

      marketComboBox.Focus()

    End Sub


    Private Sub m_processor_InvalidInformationFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_processor.InvalidInformationFound
      Dim tempRow As PublicationNotDroppedDataSet.PublicationNotDroppedRow


      temprow = CType(e.Data("Row"), PublicationNotDroppedDataSet.PublicationNotDroppedRow)
      ShowErrors(tempRow)

      tempRow = Nothing
    End Sub


        Private Sub marketComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles marketComboBox.SelectedIndexChanged

        End Sub

        Private Sub newspaperComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newspaperComboBox.SelectedIndexChanged

        End Sub
    End Class

End Namespace