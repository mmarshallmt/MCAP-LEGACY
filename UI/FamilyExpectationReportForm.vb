Namespace UI


  Public Class FamilyExpectationReportForm
    Implements IForm



    Private WithEvents m_processor As Processors.FamilyExpectationReport



    Private ReadOnly Property Processor() As Processors.FamilyExpectationReport
      Get
        Return m_processor
      End Get
    End Property



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
      m_processor = New Processors.FamilyExpectationReport()
      Processor.Initialize()
      Processor.LoadDataSet()

      retailerChannelComboBox.DisplayMember = "Descrip"
      retailerChannelComboBox.ValueMember = "TradeclassId"
      retailerChannelComboBox.DataSource = Processor.Data.TradeClass
      retailerChannelComboBox.SelectedValue = DBNull.Value
      retailerChannelComboBox.Text = String.Empty

      retailerComboBox.DisplayMember = "Descrip"
      retailerComboBox.ValueMember = "RetId"
      retailerComboBox.DataSource = Processor.Data.Ret
      retailerComboBox.SelectedValue = DBNull.Value
      retailerComboBox.Text = String.Empty

      marketComboBox.DisplayMember = "Descrip"
      marketComboBox.ValueMember = "MktId"
      marketComboBox.DataSource = Processor.Data.Mkt
      marketComboBox.SelectedValue = DBNull.Value
      marketComboBox.Text = String.Empty

      startyearNumericUpDown.Value = System.DateTime.Today.Year
      endyearNumericUpDown.Value = System.DateTime.Today.Year

      Dim strWeekNo As String

      strWeekNo = Processor.GetWeekNumber(DateTime.Today)
      startyearNumericUpDown.Value = CType(strWeekNo.Substring(0, 4), Integer)
      startweekNumericUpDown.Value = CType(strWeekNo.Substring(5, 2), Integer)

      If startweekNumericUpDown.Value = startweekNumericUpDown.Maximum Then
        endyearNumericUpDown.Value = startyearNumericUpDown.Value + 1
        endweekNumericUpDown.Value = endweekNumericUpDown.Minimum
      Else
        endyearNumericUpDown.Value = startyearNumericUpDown.Value
        endweekNumericUpDown.Value = startweekNumericUpDown.Value + 1
      End If

      Dim tempDate As DateTime = System.DateTime.Today

      tempDate = DateTime.Parse(tempDate.Month.ToString() + "/01/" + tempDate.Year.ToString())
      startdateTypeInDatePicker.Value = tempDate
      tempDate = tempDate.AddMonths(1)
      tempDate = tempDate.AddDays(-1)
      enddateTypeInDatePicker.Value = tempDate

      tempDate = Nothing

      Me.ResumeLayout(False)

      RaiseEvent FormInitialized()

    End Sub


#End Region


    ''' <summary>
    ''' Fetches data  from database for Drop Expectation report.
    ''' </summary>
    ''' <param name="tradeclassId"></param>
    ''' <param name="retailerId"></param>
    ''' <param name="marketId"></param>
    ''' <remarks></remarks>
    Private Sub FetchReportDataForDropExpectation(ByVal tradeclassId As Nullable(Of Integer), ByVal retailerId As Nullable(Of Integer), ByVal marketId As Nullable(Of Integer))

      If weekNoRadioButton.Checked Then
        Dim startWeekNo, endWeekNo As String

        startWeekNo = startyearNumericUpDown.Value.ToString() + "-" + startweekNumericUpDown.Value.ToString("00")
        endWeekNo = endyearNumericUpDown.Value.ToString() + "-" + endweekNumericUpDown.Value.ToString("00")

        If frequency1RadioButton.Checked Then
          Processor.LoadRetailersWithFrequency1PerWeek(startWeekNo, endWeekNo, tradeclassId, retailerId, marketId)
        Else
          Processor.LoadRetailersWithFrequencyInDB(startWeekNo, endWeekNo, tradeclassId, retailerId, marketId)
        End If
        'Else
        '  Dim startDate, endDate As DateTime

        '  startDate = startdateTypeInDatePicker.Value.Value
        '  endDate = enddateTypeInDatePicker.Value.Value

        '  If allVehiclesRadioButton.Checked Then
        '    Processor.LoadAllVehicles(startDate, endDate, tradeclassId, retailerId, marketId)
        '  Else
        '    Processor.LoadMissingVehicles(startDate, endDate, tradeclassId, retailerId, marketId)
        '  End If
      End If

    End Sub

    ''' <summary>
    ''' Fetches data  from database for Family Expectation report.
    ''' </summary>
    ''' <param name="tradeclassId"></param>
    ''' <param name="retailerId"></param>
    ''' <param name="marketId"></param>
    ''' <remarks></remarks>
    Private Sub FetchReportDataForFamilyExpectation(ByVal tradeclassId As Nullable(Of Integer), ByVal retailerId As Nullable(Of Integer), ByVal marketId As Nullable(Of Integer))

      If weekNoRadioButton.Checked Then
        Dim startWeekNo, endWeekNo As String

        startWeekNo = startyearNumericUpDown.Value.ToString() + "-" + startweekNumericUpDown.Value.ToString("00")
        endWeekNo = endyearNumericUpDown.Value.ToString() + "-" + endweekNumericUpDown.Value.ToString("00")

        If allVehiclesRadioButton.Checked Then
          Processor.LoadAllVehicles(startWeekNo, endWeekNo, tradeclassId, retailerId, marketId)
        Else
          Processor.LoadMissingVehicles(startWeekNo, endWeekNo, tradeclassId, retailerId, marketId)
        End If
      Else
        Dim startDate, endDate As DateTime

        startDate = startdateTypeInDatePicker.Value.Value
        endDate = enddateTypeInDatePicker.Value.Value

        If allVehiclesRadioButton.Checked Then
          Processor.LoadAllVehicles(startDate, endDate, tradeclassId, retailerId, marketId)
        Else
          Processor.LoadMissingVehicles(startDate, endDate, tradeclassId, retailerId, marketId)
        End If
      End If

    End Sub

    ''' <summary>
    ''' Generate and display report to user.
    ''' </summary>
    ''' <param name="reportFilePath"></param>
    ''' <param name="reportDataSource"></param>
    ''' <param name="reportTitle"></param>
    ''' <remarks></remarks>
    Private Sub GenerateReport(ByVal reportFilePath As String _
                               , ByVal reportDataSource As Microsoft.Reporting.WinForms.ReportDataSource _
                               , ByVal reportTitle As String, ByVal reportFilterText As String)

      If reportDataSource Is Nothing OrElse reportFilePath Is Nothing Then Exit Sub

      Dim rptViewer As UI.ShowReportForm
      rptViewer = New UI.ShowReportForm()

      With rptViewer
        .Parameters.Add("FilterCriteria", reportFilterText)
        .ReportFileResourceName = reportFilePath
        .DataSources.Add(reportDataSource.Name, reportDataSource.Value)

        'With .commonReportViewer
        '  .LocalReport.ReportEmbeddedResource = reportFilePath
        '  '.LocalReport.ReportPath = reportFilePath
        '  '.LocalReport.LoadReportDefinition(New System.IO.StreamReader(reportFilePath))
        '  .LocalReport.DataSources.Add(reportDataSource)

        '  Dim rpA(0) As Microsoft.Reporting.WinForms.ReportParameter
        '  rpA(0) = New Microsoft.Reporting.WinForms.ReportParameter("FilterCriteria", reportFilterText, False)
        '  .LocalReport.SetParameters(rpA)
        '  rpA = Nothing

        '  .RefreshReport()
        'End With

        .ReportName = reportTitle
        .PrepareReport()
        .RefreshReport()
        .WindowState = FormWindowState.Maximized
      End With

      Application.DoEvents()

      rptViewer.ShowDialog(Me)

      rptViewer.Dispose()
      rptViewer = Nothing

    End Sub

    ''' <summary>
    ''' Generate and exports report to excel file.
    ''' </summary>
    ''' <param name="reportFilePath"></param>
    ''' <param name="reportDataSource"></param>
    ''' <param name="reportTitle"></param>
    ''' <remarks></remarks>
    Private Sub ExportReport(ByVal reportFilePath As String _
                             , ByVal reportDataSource As Microsoft.Reporting.WinForms.ReportDataSource _
                             , ByVal reportTitle As String, ByVal reportFilterText As String)

      If reportDataSource Is Nothing OrElse reportFilePath Is Nothing Then Exit Sub

      Dim rptViewer As UI.ShowReportForm
      rptViewer = New UI.ShowReportForm()

      With rptViewer
        .Parameters.Add("FilterCriteria", reportFilterText)
        .ReportFileResourceName = reportFilePath
        .DataSources.Add(reportDataSource.Name, reportDataSource.Value)

        'With .commonReportViewer
        '  '.LocalReport.ReportEmbeddedResource = "MCAP.ErrorsCorrectedReport.rdlc"
        '  '.LocalReport.ReportPath = "M:\MCAP\MCAP\Reports\ErrorsCorrectedReport.rdlc"
        '  .LocalReport.ReportPath = reportFilePath
        '  .LocalReport.LoadReportDefinition(New System.IO.StreamReader(reportFilePath))
        '  .LocalReport.DataSources.Add(reportDataSource)

        '  Dim rpA(0) As Microsoft.Reporting.WinForms.ReportParameter
        '  rpA(0) = New Microsoft.Reporting.WinForms.ReportParameter("FilterCriteria", reportFilterText, False)
        '  .LocalReport.SetParameters(rpA)
        '  rpA = Nothing

        '  .RefreshReport()
        'End With

        .ReportName = reportTitle
        .PrepareReport()
        .RefreshReport()
      End With

      Application.DoEvents()

      rptViewer.ExportReportToExcel(System.IO.Path.GetTempFileName())

      rptViewer.Dispose()
      rptViewer = Nothing

    End Sub


    Private Sub dateRangeRadioButton_CheckedChanged _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles dateRangeRadioButton.CheckedChanged

      dateRangeGroupBox.Enabled = dateRangeRadioButton.Checked

    End Sub

    Private Sub weekNoRadioButton_CheckedChanged _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles weekNoRadioButton.CheckedChanged

      weekNoGroupBox.Enabled = weekNoRadioButton.Checked

        End Sub

        Private Sub retailerChannelComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles retailerChannelComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub retailerChannelComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles retailerChannelComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                retailerChannelComboBox.SelectedValue = -1
            End If
        End Sub

    Private Sub retailerChannelComboBox_Validated _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles retailerChannelComboBox.Validated
      Dim tradeclassId As Integer


      If retailerChannelComboBox.SelectedValue Is Nothing Then
        Processor.LoadAllRetailers()
        retailerComboBox.SelectedValue = DBNull.Value
        retailerComboBox.SelectedIndex = -1
        retailerComboBox.Text = String.Empty

        Processor.LoadAllMarkets()
        marketComboBox.SelectedValue = DBNull.Value
        marketComboBox.SelectedIndex = -1
        marketComboBox.Text = String.Empty

      ElseIf retailerChannelComboBox.SelectedValue IsNot Nothing Then
        tradeclassId = CType(retailerChannelComboBox.SelectedValue, Integer)
        Processor.LoadRetailersByTradeclass(tradeclassId)
        retailerComboBox.SelectedValue = DBNull.Value
        retailerComboBox.SelectedIndex = -1
        retailerComboBox.Text = String.Empty

        tradeclassId = CType(retailerChannelComboBox.SelectedValue, Integer)
        Processor.LoadMarketsByTradeclass(tradeclassId)
        marketComboBox.SelectedValue = DBNull.Value
        marketComboBox.SelectedIndex = -1
        marketComboBox.Text = String.Empty
      End If

        End Sub

        Private Sub retailerComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles retailerComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub retailerComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles retailerComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                retailerComboBox.SelectedValue = -1
            End If
        End Sub

    Private Sub retailerComboBox_Validated _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles retailerComboBox.Validated
      Dim retailerId As Integer


      If retailerChannelComboBox.SelectedValue Is Nothing _
        AndAlso retailerComboBox.SelectedValue Is Nothing _
      Then
        Processor.LoadAllMarkets()
        marketComboBox.SelectedValue = DBNull.Value
        marketComboBox.SelectedIndex = -1
        marketComboBox.Text = String.Empty

      ElseIf retailerComboBox.SelectedValue IsNot Nothing Then
        retailerId = CType(retailerComboBox.SelectedValue, Integer)
        Processor.LoadMarketsByRetailer(retailerId)
        marketComboBox.SelectedValue = DBNull.Value
        marketComboBox.SelectedIndex = -1
        marketComboBox.Text = String.Empty
      End If

    End Sub

    Private Sub familyExpectationRadioButton_CheckedChanged _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles familyExpectationRadioButton.CheckedChanged _
                , dropExpectationRadioButton.CheckedChanged

      showGroupBox.Visible = familyExpectationRadioButton.Checked
      frequencyGroupBox.Visible = dropExpectationRadioButton.Checked

      If dropExpectationRadioButton.Checked Then
        weekNoRadioButton.Checked = True
        dateRangeRadioButton.Enabled = False
      Else
        dateRangeRadioButton.Enabled = True
      End If

    End Sub

    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

      Me.Close()

    End Sub

    Private Function GetFilterCriteriaText() As String
      Dim filterCriteriaText As System.Text.StringBuilder


      filterCriteriaText = New System.Text.StringBuilder()

      If weekNoRadioButton.Checked Then
        filterCriteriaText.Append("Week Number Range: Between ")
        filterCriteriaText.Append(startyearNumericUpDown.Value.ToString("####"))
        filterCriteriaText.Append("-")
        filterCriteriaText.Append(startweekNumericUpDown.Value.ToString("00"))

        filterCriteriaText.Append(" and ")
        filterCriteriaText.Append(endyearNumericUpDown.Value.ToString("####"))
        filterCriteriaText.Append("-")
        filterCriteriaText.Append(endweekNumericUpDown.Value.ToString("00"))
      Else
        filterCriteriaText.Append("Date Range: Between ")
        filterCriteriaText.Append(startdateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy"))
        filterCriteriaText.Append(" and ")
        filterCriteriaText.Append(enddateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy"))
      End If

      If retailerChannelComboBox.SelectedValue IsNot Nothing Then
        If filterCriteriaText.Length > 0 Then filterCriteriaText.Append(", ")
        filterCriteriaText.Append("Retailer Channel=" + retailerChannelComboBox.Text)
      End If

      If retailerComboBox.SelectedValue IsNot Nothing Then
        If filterCriteriaText.Length > 0 Then filterCriteriaText.Append(", ")
        filterCriteriaText.Append("Retailer=" + retailerComboBox.Text)
      End If

      If marketComboBox.SelectedValue IsNot Nothing Then
        If filterCriteriaText.Length > 0 Then filterCriteriaText.Append(", ")
        filterCriteriaText.Append("Market=" + marketComboBox.Text)
      End If


      Return filterCriteriaText.ToString()

    End Function

    Private Function AreInputsValid() As Boolean
      Dim validatedSuccessfully As Boolean = True


      If dateRangeRadioButton.Checked Then
        If startdateTypeInDatePicker.Value.HasValue = False Then
          SetErrorProvider(startdateTypeInDatePicker, "Provide valid start date.")
          validatedSuccessfully = False
        Else
          RemoveErrorProvider(startdateTypeInDatePicker)
        End If
        If enddateTypeInDatePicker.Value.HasValue = False Then
          SetErrorProvider(enddateTypeInDatePicker, "Provide valid end date.")
          validatedSuccessfully = False
        Else
          RemoveErrorProvider(enddateTypeInDatePicker)
                End If
                If startdateTypeInDatePicker.Text = "  /  /" And enddateTypeInDatePicker.Text <> "  /  /" Then
                    validatedSuccessfully = False
                    SetErrorProvider(startdateTypeInDatePicker, "Provide valid start date.")
                Else
                    RemoveErrorProvider(startdateTypeInDatePicker)
                End If
                If startdateTypeInDatePicker.Text <> "  /  /" And enddateTypeInDatePicker.Text = "  /  /" Then
                    validatedSuccessfully = False
                    SetErrorProvider(enddateTypeInDatePicker, "Provide valid end date.")
                ElseIf startdateTypeInDatePicker.Value.HasValue AndAlso startdateTypeInDatePicker.Value.Value.Subtract(enddateTypeInDatePicker.Value.Value).Days > 0 _
                Then
                    MessageBox.Show("End Date cannot be before Start Date.", ProductName _
                                    , MessageBoxButtons.OK, MessageBoxIcon.Error)
                    validatedSuccessfully = False

                Else
                    RemoveErrorProvider(enddateTypeInDatePicker)
                End If
            ElseIf weekNoRadioButton.Checked Then
                If startweekNumericUpDown.Text = "" Then
                    SetErrorProvider(startweekNumericUpDown, "Provide valid week number.")
                    MsgBox("Provide valid week number.", MsgBoxStyle.Information)
                    validatedSuccessfully = False
                Else
                    RemoveErrorProvider(startweekNumericUpDown)
                End If
                If startyearNumericUpDown.Text = "" Then
                    SetErrorProvider(startyearNumericUpDown, "Provide valid year.")
                    MsgBox("Provide valid year.", MsgBoxStyle.Information)
                    validatedSuccessfully = False
                Else
                    RemoveErrorProvider(startyearNumericUpDown)
                End If
                If endweekNumericUpDown.Text = "" Then
                    SetErrorProvider(endweekNumericUpDown, "Provide valid week number.")
                    MsgBox("Provide valid week number.", MsgBoxStyle.Information)
                    validatedSuccessfully = False
                Else
                    RemoveErrorProvider(endweekNumericUpDown)
                End If
                If endyearNumericUpDown.Text = "" Then
                    SetErrorProvider(endyearNumericUpDown, "Provide valid year.")
                    MsgBox("Provide valid year.", MsgBoxStyle.Information)
                    validatedSuccessfully = False
                Else
                    RemoveErrorProvider(endyearNumericUpDown)
                End If
                If startweekNumericUpDown.Value < 1 OrElse startweekNumericUpDown.Value > 53 Then
                    SetErrorProvider(startweekNumericUpDown, "Provide valid week number.")
                    validatedSuccessfully = False
                Else
                    RemoveErrorProvider(startweekNumericUpDown)
                End If
                If startyearNumericUpDown.Value < 2000 Then
                    SetErrorProvider(startyearNumericUpDown, "Provide valid year.")
                    validatedSuccessfully = False
                Else
                    RemoveErrorProvider(startyearNumericUpDown)
                End If

                If endweekNumericUpDown.Value < 1 OrElse endweekNumericUpDown.Value > 53 Then
                    SetErrorProvider(endweekNumericUpDown, "Provide valid week number.")
                    validatedSuccessfully = False
                Else
                    RemoveErrorProvider(endweekNumericUpDown)
                End If
                If endyearNumericUpDown.Value < 2000 Then
                    SetErrorProvider(endyearNumericUpDown, "Provide valid year.")
                    validatedSuccessfully = False
                Else
                    RemoveErrorProvider(endyearNumericUpDown)
                End If
      End If


      Return validatedSuccessfully

    End Function

    Private Sub generateReportButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles generateReportButton.Click
      Dim tradeclassId, retailerId, marketId As Nullable(Of Integer)
      Dim reportFilePath, reportTitle As String
      Dim reportDataSource As Microsoft.Reporting.WinForms.ReportDataSource


      If AreInputsValid() = False Then Exit Sub

      If retailerChannelComboBox.SelectedValue Is Nothing Then
        tradeclassId = Nothing
      Else
        tradeclassId = CType(retailerChannelComboBox.SelectedValue, Integer)
      End If

      If retailerComboBox.SelectedValue Is Nothing Then
        retailerId = Nothing
      Else
        retailerId = CType(retailerComboBox.SelectedValue, Integer)
      End If

      If marketComboBox.SelectedValue Is Nothing Then
        marketId = Nothing
      Else
        marketId = CType(marketComboBox.SelectedValue, Integer)
      End If

      If familyExpectationRadioButton.Checked Then
        reportTitle = "Family Expectation"
        FetchReportDataForFamilyExpectation(tradeclassId, retailerId, marketId)
        If Processor.Data.FamilyExpectation.Count > 0 Then
                    reportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("FamilyExpectationReportDataSet_FamilyExpectation", CType(Processor.Data.FamilyExpectation, DataTable))
          'reportFilePath = Application.StartupPath + "\" + FamilyExpectationReportFilePath
          reportFilePath = "MCAP.FamilyExpectationReport.rdlc"
        End If
      Else
        reportTitle = "Drop Expectation"
        FetchReportDataForDropExpectation(tradeclassId, retailerId, marketId)
        If Processor.Data.DropExpectation.Count > 0 Then
                    reportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("FamilyExpectationReportDataSet_DropExpectation", CType(Processor.Data.DropExpectation, DataTable))
          'reportFilePath = Application.StartupPath + "\" + DropExpectationReportFilePath
          reportFilePath = "MCAP.DropExpectationReport.rdlc"
        End If
      End If

      If reportFilePath Is Nothing Then
        MessageBox.Show("There exist no data for report. Try different selection.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
      ElseIf screenRadioButton.Checked Then
        GenerateReport(reportFilePath, reportDataSource, reportTitle, GetFilterCriteriaText())
      Else
        ExportReport(reportFilePath, reportDataSource, reportTitle, GetFilterCriteriaText())
      End If


      reportFilePath = Nothing
      reportDataSource = Nothing

        End Sub

        Private Sub marketComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles marketComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub marketComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles marketComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                marketComboBox.SelectedValue = -1
            End If
        End Sub

        Private Sub retailerChannelComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles retailerChannelComboBox.SelectedIndexChanged

        End Sub

        Private Sub retailerComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles retailerComboBox.SelectedIndexChanged

        End Sub

        Private Sub marketComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles marketComboBox.SelectedIndexChanged

        End Sub
    End Class

End Namespace