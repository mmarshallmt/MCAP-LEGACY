Imports Excel = Microsoft.Office.Interop.Excel


Namespace UI

  Public Class NewspaperLogReportForm
    Implements IForm


    Private m_Processor As Processors.NewspaperLogReport


    Private ReadOnly Property Processor() As Processors.NewspaperLogReport
      Get
        Return m_Processor
      End Get
    End Property



#Region " IForm Implementation "


    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied

    Public Event InitializingForm() Implements IForm.InitializingForm
    Public Event FormInitialized() Implements IForm.FormInitialized


    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

    End Sub

    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init
      Dim curMonthIndex As Integer
      RaiseEvent InitializingForm()

      Me.SuspendLayout()

      m_Processor = New Processors.NewspaperLogReport
      Processor.Initialize()
      Processor.LoadDataSet()

      userComboBox.DisplayMember = "FullName"
      userComboBox.ValueMember = "UserId"
      userComboBox.DataSource = Processor.Data.Tables("User")
      userComboBox.SelectedValue = DBNull.Value

      'Filling Month drop down list.
      monthComboBox.BeginUpdate()
      Dim tempDate As DateTime = New DateTime(System.DateTime.Today.Year, 1, 1)
      monthComboBox.Items.Add(tempDate.ToString("MMMM"))
      For i As Integer = 1 To 11
        monthComboBox.Items.Add(tempDate.AddMonths(i).ToString("MMMM"))
        If tempDate.AddMonths(i).ToString("MMMM") = System.DateTime.Today.ToString("MMMM") Then
          curMonthIndex = i
        End If
      Next
      'monthComboBox.SelectedIndex = 0
      monthComboBox.SelectedIndex = curMonthIndex
      monthComboBox.EndUpdate()

      yearNumericUpDown.Value = System.DateTime.Today.Year
      dayComboBox.BeginUpdate()
      For i As Integer = 1 To 31
        dayComboBox.Items.Add(i)
      Next
      dayComboBox.EndUpdate()

      Me.ResumeLayout(False)

      RaiseEvent FormInitialized()

    End Sub


#End Region


    ''' <summary>
    ''' Validates inputs and returns true if all inputs are valid, false otherwise.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AreInputsValid() As Boolean
      Dim areAllValid As Boolean = True


      areAllValid = True

      If monthComboBox.SelectedIndex < 0 Then
        SetErrorProvider(monthComboBox, "Select month from drop down list.")
        areAllValid = False
      Else
        RemoveErrorProvider(monthComboBox)
      End If

      If dayComboBox.Text.Length > 0 AndAlso dayComboBox.SelectedIndex < 0 Then
        SetErrorProvider(dayComboBox, "Provide valid date value.")
        areAllValid = False
      Else
        RemoveErrorProvider(dayComboBox)
      End If

      If userComboBox.Text.Length > 0 AndAlso userComboBox.SelectedValue Is Nothing Then
        SetErrorProvider(userComboBox, "Select user from drop down list.")
        areAllValid = False
      Else
        RemoveErrorProvider(userComboBox)
      End If

      Return areAllValid

    End Function

    '''' <summary>
    '''' Returns excel column name, based on specified column index.
    '''' </summary>
    '''' <param name="columnIndex">Index of column in excel sheet. Column index starts from 1 (i.e. 1 is A).</param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Private Function GetExcelColumnName(ByVal columnIndex As Integer) As String
    '  Dim remainder, quotient As Integer
    '  Dim columnCharacter As String


    '  If columnIndex < 1 Then Return String.Empty

    '  quotient = columnIndex \ 26
    '  remainder = columnIndex Mod 26

    '  If quotient > 0 And remainder = 0 Then
    '    quotient -= 1
    '    remainder = 26
    '  End If

    '  If quotient = 0 Then
    '    columnCharacter = Convert.ToChar(64 + remainder)
    '  Else
    '    columnCharacter = Convert.ToChar(64 + quotient)
    '    columnCharacter += GetExcelColumnName(remainder)
    '  End If


    '  Return columnCharacter

    'End Function

    '''' <summary>
    '''' Formats (R) with blue and (P) with dark red color in supplied range.
    '''' </summary>
    '''' <param name="xlRange">Range to format.</param>
    '''' <remarks></remarks>
    'Private Sub FormatRangeForReceivedAndPulled(ByVal xlRange As Excel.Range)
    '  Dim charFoundAt, elementCounter As Integer
    '  Dim rangeValues As System.Array
    '  Dim rangeText As System.Text.StringBuilder
    '  Dim xlRowRange As Excel.Range


    '  rangeText = New System.Text.StringBuilder()
    '  rangeValues = CType(xlRange.Value2, System.Array)

    '  For elementCounter = 1 To rangeValues.Length
    '    If rangeValues.GetValue(elementCounter, 1) Is Nothing Then Continue For

    '    rangeText.Append(rangeValues.GetValue(elementCounter, 1).ToString())
    '    xlRowRange = CType(xlRange.Rows(elementCounter), Excel.Range)

    '    While True
    '      charFoundAt = rangeText.ToString().IndexOf("(R)", charFoundAt + 1)
    '      If charFoundAt < 0 Then Exit While
    '      'xlRowRange = CType(xlRange.Rows(elementCounter), Excel.Range)
    '      xlRowRange.Characters(charFoundAt + 1, 3).Font.ColorIndex = 5 '3
    '    End While

    '    'rangeText.Append(rangeValues.GetValue(elementCounter, 1).ToString())
    '    While True
    '      charFoundAt = rangeText.ToString().IndexOf("(P)", charFoundAt + 1)
    '      If charFoundAt < 0 Then Exit While
    '      'xlRowRange = CType(xlRange.Rows(elementCounter), Excel.Range)
    '      xlRowRange.Characters(charFoundAt + 1, 3).Font.ColorIndex = 18
    '    End While

    '    xlRowRange = Nothing
    '    rangeText = rangeText.Remove(0, rangeText.Length)
    '  Next

    '  rangeText.Remove(0, rangeText.Length)
    '  rangeText = Nothing
    '  rangeValues = Nothing
    '  xlRowRange = Nothing
    'End Sub

    '''' <summary>
    '''' Sets cell borders to specified range.
    '''' </summary>
    '''' <param name="xlRange"></param>
    '''' <remarks></remarks>
    'Private Sub SetPriorityTableBorders(ByVal xlRange As Excel.Range)

    '  xlRange.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
    '  xlRange.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone
    '  With xlRange.Borders(Excel.XlBordersIndex.xlEdgeLeft)
    '    .LineStyle = Excel.XlLineStyle.xlContinuous
    '    .Weight = Excel.XlBorderWeight.xlThin
    '    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
    '  End With
    '  With xlRange.Borders(Excel.XlBordersIndex.xlEdgeTop)
    '    .LineStyle = Excel.XlLineStyle.xlContinuous
    '    .Weight = Excel.XlBorderWeight.xlThin
    '    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
    '  End With
    '  With xlRange.Borders(Excel.XlBordersIndex.xlEdgeBottom)
    '    .LineStyle = Excel.XlLineStyle.xlContinuous
    '    .Weight = Excel.XlBorderWeight.xlThin
    '    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
    '  End With
    '  With xlRange.Borders(Excel.XlBordersIndex.xlEdgeRight)
    '    .LineStyle = Excel.XlLineStyle.xlContinuous
    '    .Weight = Excel.XlBorderWeight.xlThin
    '    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
    '  End With
    '  With xlRange.Borders(Excel.XlBordersIndex.xlInsideVertical)
    '    .LineStyle = Excel.XlLineStyle.xlContinuous
    '    .Weight = Excel.XlBorderWeight.xlThin
    '    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
    '  End With

    '  If xlRange.Rows.Count > 1 Then
    '    With xlRange.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
    '      .LineStyle = Excel.XlLineStyle.xlContinuous
    '      .Weight = Excel.XlBorderWeight.xlThin
    '      .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
    '    End With
    '  End If

    'End Sub

    '''' <summary>
    '''' Creates automation object of excel and exports and format data from dataset to excel.
    '''' </summary>
    '''' <param name="exportTable"></param>
    '''' <param name="vehicleStatus"></param>
    '''' <param name="priorityText"></param>
    '''' <remarks></remarks>
    'Private Sub ExportDataToExcel(ByVal exportTable As Data.DataTable, ByVal vehicleStatus As String, ByVal priorityText As String)
    '  Dim rowCounter, xlRowCounter, priorityCounter, alternateRowColor As Integer
    '  Dim alternateRowColorPattern As Excel.XlPattern
    '  Dim columnHeaders(), rangeStart, rangeEnd, lastColumnName As String
    '  Dim xlApp As Microsoft.Office.Interop.Excel.Application
    '  Dim xlWB As Microsoft.Office.Interop.Excel.Workbook
    '  Dim xlWS As Microsoft.Office.Interop.Excel.Worksheet
    '  Dim xlRange As Microsoft.Office.Interop.Excel.Range
    '  Dim columnQuery As System.Collections.Generic.IEnumerable(Of String)


    '  columnQuery = From c In exportTable.Columns.Cast(Of Data.DataColumn)() Select c.ColumnName
    '  columnHeaders = columnQuery.ToArray()
    '  columnQuery = Nothing

    '  lastColumnName = GetExcelColumnName(columnHeaders.Length)
    '  alternateRowColor = 15
    '  alternateRowColorPattern = Excel.XlPattern.xlPatternAutomatic

    '  'If found, attach to a running instance of an automation server, otherwise create new.
    '  Try
    '    xlApp = CType(Microsoft.VisualBasic.Interaction.GetObject(, "Excel.Application"), Excel.Application)
    '  Catch ex As Exception
    '    xlApp = New Microsoft.Office.Interop.Excel.Application
    '  Finally
    '    xlApp.Visible = False
    '  End Try

    '  xlWB = xlApp.Workbooks.Add()
    '  If xlWB.Worksheets.Count = 0 Then
    '    xlWS = CType(xlWB.Worksheets.Add(), Excel.Worksheet)
    '  Else
    '    xlWS = CType(xlWB.Worksheets(1), Excel.Worksheet)
    '  End If

    '  For priorityCounter = 1 To 4
    '    exportTable.DefaultView.RowFilter = "Priority=" + priorityCounter.ToString()
    '    If exportTable.DefaultView.Count = 0 Then Continue For

    '    'Write and Format priority level title here.
    '    xlRowCounter += 1
    '    rangeStart = "B" + xlRowCounter.ToString()
    '    rangeEnd = GetExcelColumnName(columnHeaders.Length) + xlRowCounter.ToString()
    '    xlWS.Range(rangeStart, rangeEnd).Merge()
    '    xlWS.Cells(xlRowCounter, 2) = priorityText.Replace("#Priority#", priorityCounter.ToString())
    '    xlWS.Range(rangeStart).Font.Bold = True

    '    'Write & format pivot table headers here.
    '    xlRowCounter += 1
    '    rangeStart = "A" + xlRowCounter.ToString()
    '    rangeEnd = GetExcelColumnName(columnHeaders.Length) + xlRowCounter.ToString()
    '    xlRange = xlWS.Range(rangeStart, rangeEnd)
    '    xlRange.Font.Bold = True
    '    xlRange.Font.Size = 14
    '    xlRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
    '    xlRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
    '    xlRange.NumberFormat = "@"
    '    xlRange.Value2 = columnHeaders
    '    xlRange.RowHeight = 18

    '    xlRange = xlWS.Range("B" + xlRowCounter.ToString())
    '    xlRange.Font.Italic = True
    '    xlRange.Font.Size = 10
    '    xlRange.Font.ColorIndex = 9

    '    'Fill pivote table here.
    '    'exportTable.DefaultView.RowFilter = "Priority=" + priorityCounter.ToString()
    '    xlRowCounter += 1
    '    For rowCounter = 0 To exportTable.DefaultView.Count - 1
    '      xlRange = xlWS.Range("A" + (xlRowCounter + rowCounter).ToString(), lastColumnName + (xlRowCounter + rowCounter).ToString())
    '      xlRange.NumberFormat = "@"
    '      xlRange.Value2 = exportTable.DefaultView(rowCounter).Row.ItemArray
    '      If rowCounter Mod 2 = 0 Then
    '        xlRange.Interior.ColorIndex = 15
    '        xlRange.Interior.Pattern = alternateRowColorPattern
    '      End If
    '    Next

    '    xlRange = xlWS.Range("A" + (xlRowCounter - 1).ToString(), lastColumnName + (xlRowCounter + rowCounter - 1).ToString())
    '    SetPriorityTableBorders(xlRange)

    '    xlRowCounter += rowCounter

    '  Next  'End of For priorityCounter = 1 To 4


    '  'Remove Priority column.
    '  xlRange = CType(xlWS.Columns(1), Excel.Range)
    '  xlRange.Delete()

    '  'AutoFit Newspaper column
    '  xlRange = CType(xlWS.Columns(1), Excel.Range)
    '  xlRange.Columns.AutoFit()

    '  If vehicleStatus.ToUpper() = "RECEIVED" Then
    '    'AutoFit sender column
    '    xlRange = CType(xlWS.Columns(2), Excel.Range)
    '    xlRange.Columns.AutoFit()
    '  End If

    '  If priorityText.IndexOf("Not") > 0 Then
    '    xlRange = xlWS.Range("B1:B" + xlRowCounter.ToString())
    '    xlRange.Columns.AutoFit()
    '    FormatRangeForReceivedAndPulled(xlRange)
    '  End If

    '  Array.Clear(columnHeaders, 0, columnHeaders.Length)
    '  columnHeaders = Nothing

    '  xlRange = Nothing
    '  xlWS = Nothing
    '  xlWB = Nothing
    '  xlApp.Visible = True

    'End Sub


    'Private Sub exportButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles exportButton.Click
    '  Dim filterYear, filterMonth As Integer
    '  Dim filterDay, filterUserId As Nullable(Of Integer)
    '  Dim vehicleStatus, priorityTitleText As String
    '  Dim exportDataSet As Data.DataSet


    '  If AreInputsValid() = False Then Exit Sub

    '  filterYear = CInt(yearNumericUpDown.Value)
    '  filterMonth = monthComboBox.SelectedIndex + 1

    '  If dayComboBox.SelectedIndex < 0 Then
    '    filterDay = Nothing
    '  Else
    '    filterDay = dayComboBox.SelectedIndex + 1
    '  End If

    '  If userComboBox.SelectedValue Is Nothing Then
    '    filterUserId = Nothing
    '  Else
    '    filterUserId = CInt(userComboBox.SelectedValue)
    '  End If

    '  If receivedRadioButton.Checked Then
    '    vehicleStatus = "Received"
    '  ElseIf pullRadioButton.Checked Then
    '    vehicleStatus = "Pulled"
    '  ElseIf indexQCRadioButton.Checked Then
    '    vehicleStatus = "Indexed"
    '  ElseIf missingNotPulledRadioButton.Checked Then
    '    vehicleStatus = "Pulled"  'Not Pulled
    '  Else
    '    vehicleStatus = "Indexed" 'Not Indexed
    '  End If

    '  If missingNotPulledRadioButton.Checked OrElse missingNotPublishedRadioButton.Checked Then
    '    exportDataSet = Processor.GetReportData_Missing(vehicleStatus, filterYear, filterMonth)
    '  ElseIf dayComboBox.SelectedIndex < 0 AndAlso userComboBox.SelectedValue Is Nothing Then
    '    exportDataSet = Processor.GetReportData_BreakDateWise(vehicleStatus, filterYear, filterMonth)
    '  Else
    '    exportDataSet = Processor.GetReportData_LogDateWise(vehicleStatus, filterYear, filterMonth, filterDay, filterUserId)
    '  End If

    '  If exportDataSet.Tables.Count = 0 Then
    '    MessageBox.Show("No data found with specified criteria.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    '  Else
    '    If missingNotPulledRadioButton.Checked OrElse missingNotPublishedRadioButton.Checked Then
    '      priorityTitleText = "Priority #Priority# newspapers Not " + vehicleStatus + " for month of " + monthComboBox.Text + ", " + yearNumericUpDown.Value.ToString("####")
    '    ElseIf filterUserId Is Nothing Then
    '      priorityTitleText = "Priority #Priority# newspapers " + vehicleStatus + " for month of " + monthComboBox.Text + ", " + yearNumericUpDown.Value.ToString("####")
    '    Else
    '      priorityTitleText = "Priority #Priority# newspapers " + vehicleStatus + " by " + userComboBox.Text + " for month of " + monthComboBox.Text + ", " + yearNumericUpDown.Value.ToString("####")
    '    End If

    '    ExportDataToExcel(exportDataSet.Tables(0), vehicleStatus, priorityTitleText)
    '  End If

    '  filterDay = Nothing
    '  filterUserId = Nothing
    '  exportDataSet.Tables.Clear()
    '  exportDataSet.Dispose()
    '  exportDataSet = Nothing
    '  vehicleStatus = Nothing
    'End Sub


    Private Sub ShowFileToUser(ByVal filePath As String)
      Dim pi As System.Diagnostics.ProcessStartInfo


      pi = New System.Diagnostics.ProcessStartInfo(filePath)

      Try
        If pi.Verbs.Contains("Open") Then
          pi.Verb = "Open"
          System.Diagnostics.Process.Start(pi)
        Else
          'Opens windows standard "open with..." dialog box, allowing user to choose application 
          'to open exported excel file.
          Process.Start("rundll32.exe", "shell32.dll, OpenAs_RunDLL " & filePath)
        End If

      Catch ex As System.ComponentModel.Win32Exception
        MessageBox.Show("Following error has occurred while opening exported excel file." _
                        + Environment.NewLine + ex.Message + Environment.NewLine _
                        + "File is saved successfully at " + filePath _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Catch ex As System.Exception
        MessageBox.Show("An unknown error has occurred while opening exported excel file." _
                        + Environment.NewLine + "File is saved successfully at " + filePath _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
        pi = Nothing
      End Try

    End Sub


    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
      MyBase.OnPaint(e)

      Dim startX, startY, endX, endY As Integer
      Dim linePen As System.Drawing.Pen


      startX = optionsGroupBox.Left
      startY = optionsGroupBox.Height + 30
      endX = filterByGroupBox.Left + filterByGroupBox.Width
      endY = startY

      linePen = New System.Drawing.Pen(Me.ForeColor)
      linePen.Width = 2
      e.Graphics.DrawLine(linePen, startX, startY, endX, endY)

      linePen.Dispose()
      linePen = Nothing
    End Sub


    Private Sub missingRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles missingNotPulledRadioButton.CheckedChanged, missingNotPublishedRadioButton.CheckedChanged
      Dim enableState As Boolean


      enableState = Not (CType(sender, RadioButton).Checked)

      With userComboBox
        .SelectedValue = DBNull.Value
        .SelectedIndex = -1
        .Text = String.Empty
        .Enabled = enableState
      End With

      With dayComboBox
        .SelectedValue = DBNull.Value
        .SelectedIndex = -1
        .Text = String.Empty
        .Enabled = enableState
      End With

    End Sub

    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

      Me.Close()

    End Sub

    Private Sub exportButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles exportButton.Click
      Dim filterYear, filterMonth As Integer
      Dim filterDay, filterUserId As Nullable(Of Integer)
      Dim vehicleStatus, priorityTitleText As String
      Dim exportDataSet As Data.DataSet


      If AreInputsValid() = False Then Exit Sub

      filterYear = CInt(yearNumericUpDown.Value)
      filterMonth = monthComboBox.SelectedIndex + 1

      If dayComboBox.SelectedIndex < 0 Then
        filterDay = Nothing
      Else
        filterDay = dayComboBox.SelectedIndex + 1
      End If

      If userComboBox.SelectedValue Is Nothing Then
        filterUserId = Nothing
      Else
        filterUserId = CInt(userComboBox.SelectedValue)
      End If

      If receivedRadioButton.Checked Then
        vehicleStatus = "Received"
      ElseIf pullRadioButton.Checked Then
        vehicleStatus = "Pulled"
      ElseIf indexQCRadioButton.Checked Then
        vehicleStatus = "Indexed"
      ElseIf missingNotPulledRadioButton.Checked Then
        vehicleStatus = "Pulled"  'Not Pulled
      Else
        vehicleStatus = "Indexed" 'Not Indexed
      End If

      If missingNotPulledRadioButton.Checked OrElse missingNotPublishedRadioButton.Checked Then
        exportDataSet = Processor.GetReportData_Missing(vehicleStatus, filterYear, filterMonth)
      ElseIf dayComboBox.SelectedIndex < 0 AndAlso userComboBox.SelectedValue Is Nothing Then
        exportDataSet = Processor.GetReportData_BreakDateWise(vehicleStatus, filterYear, filterMonth)
      Else
        exportDataSet = Processor.GetReportData_LogDateWise(vehicleStatus, filterYear, filterMonth, filterDay, filterUserId)
      End If

      If exportDataSet.Tables.Count = 0 Then
        MessageBox.Show("No data found with specified criteria.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Else
        If missingNotPulledRadioButton.Checked OrElse missingNotPublishedRadioButton.Checked Then
          priorityTitleText = "Priority #Priority# newspapers Not " + vehicleStatus + " for month of " + monthComboBox.Text + ", " + yearNumericUpDown.Value.ToString("####")
        ElseIf filterUserId Is Nothing Then
          priorityTitleText = "Priority #Priority# newspapers " + vehicleStatus + " for month of " + monthComboBox.Text + ", " + yearNumericUpDown.Value.ToString("####")
        Else
          priorityTitleText = "Priority #Priority# newspapers " + vehicleStatus + " by " + userComboBox.Text + " for month of " + monthComboBox.Text + ", " + yearNumericUpDown.Value.ToString("####")
        End If

        Dim exportFilePath As String = System.IO.Path.GetTempFileName()
        exportFilePath = exportFilePath.Replace(System.IO.Path.GetExtension(exportFilePath), ".xls")

        If receivedRadioButton.Checked OrElse pullRadioButton.Checked OrElse indexQCRadioButton.Checked Then
          Dim rptCreator As NPLogReportHelper = New NPLogReportHelper()
          rptCreator.PrepareReport(exportDataSet.Tables(0), priorityTitleText, exportFilePath)
          rptCreator = Nothing
        Else
          Dim rptCreator As NPMissingLogReportHelper = New NPMissingLogReportHelper()
          rptCreator.PrepareReport(exportDataSet.Tables(0), priorityTitleText, exportFilePath)
          rptCreator = Nothing
        End If

        ShowFileToUser(exportFilePath)
        exportFilePath = Nothing
      End If

      filterDay = Nothing
      filterUserId = Nothing
      exportDataSet.Tables.Clear()
      exportDataSet.Dispose()
      exportDataSet = Nothing
      vehicleStatus = Nothing
        End Sub

        Private Sub yearNumericUpDown_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles yearNumericUpDown.Validated
            If dayComboBox.Text <> "" Then
                If CDbl(dayComboBox.Text) > System.DateTime.DaysInMonth(CInt(yearNumericUpDown.Value), CInt(monthComboBox.SelectedIndex + 1)) Then
                    dayComboBox.Text = CStr(System.DateTime.DaysInMonth(CInt(yearNumericUpDown.Value), CInt(monthComboBox.SelectedIndex + 1)))
                End If
            End If
        End Sub


        Private Sub yearNumericUpDown_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles yearNumericUpDown.ValueChanged
            If IsNumeric(yearNumericUpDown.Value) = False Then
                yearNumericUpDown.Value = Date.Now.Year
            End If
            If dayComboBox.Text <> "" Then
                If CDbl(dayComboBox.Text) > System.DateTime.DaysInMonth(CInt(yearNumericUpDown.Value), CInt(monthComboBox.SelectedIndex + 1)) Then
                    dayComboBox.Text = CStr(System.DateTime.DaysInMonth(CInt(yearNumericUpDown.Value), CInt(monthComboBox.SelectedIndex + 1)))
                End If
            End If
        End Sub

        Private Sub dayComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dayComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub dayComboBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dayComboBox.Validated
            If dayComboBox.Text <> "" Then
                If CDbl(dayComboBox.Text) > System.DateTime.DaysInMonth(Date.Now.Year, CInt(monthComboBox.SelectedIndex + 1)) Then
                    dayComboBox.Text = CStr(System.DateTime.DaysInMonth(Date.Now.Year, CInt(monthComboBox.SelectedIndex + 1)))
                End If
            End If
        End Sub

        Private Sub userComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles userComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub userComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles userComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                userComboBox.SelectedValue = -1
            End If
        End Sub

        Private Sub monthComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles monthComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub


        Private Sub monthComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles monthComboBox.SelectedIndexChanged

        End Sub

        Private Sub dayComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dayComboBox.SelectedIndexChanged

        End Sub

       
    End Class


End Namespace