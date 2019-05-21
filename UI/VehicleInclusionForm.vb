Namespace UI

  Public Class VehicleInclusionForm
    Implements IForm


    Private m_data As ReportsDataSet


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property Data() As ReportsDataSet
      Get
        Return m_data
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

      m_data = New ReportsDataSet()
      LoadData()

      locationComboBox.DisplayMember = "Location"
      locationComboBox.ValueMember = "CodeId"
      locationComboBox.DataSource = Data.vwLocation
      locationComboBox.SelectedValue = User.LocationId
      locationComboBox.Text = User.Location


      startyearNumericUpDown.Value = System.DateTime.Today.Year
      endyearNumericUpDown.Value = System.DateTime.Today.Year

      Dim strWeekNo As String

      strWeekNo = GetWeekNumber(DateTime.Today)
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
    ''' Loads location and other required tables.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadData()
      Dim tempAdapter As ReportsDataSetTableAdapters.vwLocationTableAdapter


      tempAdapter = New ReportsDataSetTableAdapters.vwLocationTableAdapter()

      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      tempAdapter.Fill(Data.vwLocation)

      tempAdapter.Dispose()
      tempAdapter = Nothing

      'Adding dummy location for option - "Both"
      Dim tempRow As ReportsDataSet.vwLocationRow


      tempRow = Data.vwLocation.NewvwLocationRow()
      tempRow.CodeId = -2 'DO NOT CHANGE THIS. This value is hardcoded in mt_prod_VehicleInclusionReport storedprocedure.
      tempRow.Location = "Both"
      Data.vwLocation.AddvwLocationRow(tempRow)
      Data.vwLocation.AcceptChanges()

      tempRow = Nothing
    End Sub


    Private Function GetWeekNumber(ByVal paramDate As DateTime) As String
      Dim weekNumber As String
      Dim adapter As PackageExpectationReportDataSetTableAdapters.PackageReceivedTableAdapter

      adapter = New PackageExpectationReportDataSetTableAdapters.PackageReceivedTableAdapter
      adapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      weekNumber = adapter.GetWeekNoMondayStart(paramDate).ToString()

      adapter.Dispose()
      adapter = Nothing


      Return weekNumber

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
      Else
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


    Private Sub LoadReportData _
        (ByVal dataSet As ReportsDataSet.mt_proc_VehicleInclusionReportDataTable, ByVal startDate As DateTime _
         , ByVal endDate As DateTime, ByVal locationId As Integer)
      Dim adapter As ReportsDataSetTableAdapters.mt_proc_VehicleInclusionReportTableAdapter


      adapter = New ReportsDataSetTableAdapters.mt_proc_VehicleInclusionReportTableAdapter
      adapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            ' adapter.Adapter.SelectCommand.CommandTimeout = My.Settings.CommandTimeout - to be updated 9
      adapter.Fill(dataSet, startDate, endDate, Nothing, Nothing, locationId)

      adapter.Dispose()
      adapter = Nothing
    End Sub


    Private Sub LoadReportData _
        (ByVal dataSet As ReportsDataSet.mt_proc_VehicleInclusionReportDataTable, ByVal startWeekNo As String _
         , ByVal endWeekNo As String, ByVal locationId As Integer)
      Dim adapter As ReportsDataSetTableAdapters.mt_proc_VehicleInclusionReportTableAdapter


      adapter = New ReportsDataSetTableAdapters.mt_proc_VehicleInclusionReportTableAdapter
      adapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            ' adapter.Adapter.SelectCommand.CommandTimeout = My.Settings.CommandTimeout - to be updated 10
      adapter.Fill(dataSet, Nothing, Nothing, startWeekNo, endWeekNo, locationId)

      adapter.Dispose()
      adapter = Nothing
    End Sub


    Private Sub GenerateReport(ByVal reportForm As UI.ShowReportForm, ByVal dataSet As ReportsDataSet)
      Dim filterString As String


      If dateRangeRadioButton.Checked Then
        filterString = "Date Range: Between " + startdateTypeInDatePicker.Text _
                        + " and " + enddateTypeInDatePicker.Text
      Else
        filterString = "Week number Range: Between " + startyearNumericUpDown.Value.ToString("####") _
                        + "-" + startweekNumericUpDown.Value.ToString("00") _
                        + " and " + endyearNumericUpDown.Value.ToString("####") _
                        + "-" + endweekNumericUpDown.Value.ToString("00")
      End If

      With reportForm
        .Parameters.Add("FilterString", filterString)

        .ReportFileResourceName = "MCAP.VehicleInclusionReport.rdlc"
        '.ReportFilePath = Application.StartupPath + "\" + PackageExpectationReceivedReportFilePath
        .DataSources.Add("ReportsDataSet_mt_proc_VehicleInclusionReport", dataSet.mt_proc_VehicleInclusionReport)
        .ReportName = "Vehicle Inclusion "

        .PrepareReport()
        .RefreshReport()
        .WindowState = FormWindowState.Maximized
      End With

      Application.DoEvents()

    End Sub


    Private Sub ExportReport(ByVal reportForm As UI.ShowReportForm)
      Dim temporaryFilePath As String


      temporaryFilePath = System.IO.Path.GetTempFileName()

      reportForm.ExportReportToExcel(temporaryFilePath)

      temporaryFilePath = Nothing

    End Sub


    Private Sub closeButton_Click _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles closeButton.Click

      Me.Close()

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

    Private Sub generateReportButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles generateReportButton.Click
      Dim rptViewer As ShowReportForm


      If AreInputsValid() = False Then Exit Sub

      If dateRangeRadioButton.Checked Then
        LoadReportData(Data.mt_proc_VehicleInclusionReport, startdateTypeInDatePicker.Value.Value, enddateTypeInDatePicker.Value.Value, CType(locationComboBox.SelectedValue, Integer))
      Else
        LoadReportData(Data.mt_proc_VehicleInclusionReport, startyearNumericUpDown.Value.ToString("####") + "-" + startweekNumericUpDown.Value.ToString("00") _
                      , endyearNumericUpDown.Value.ToString("####") + "-" + endweekNumericUpDown.Value.ToString("00"), CType(locationComboBox.SelectedValue, Integer))
      End If

      rptViewer = New ShowReportForm()
      GenerateReport(rptViewer, Data)

      If screenRadioButton.Checked Then
        rptViewer.RefreshReport()
        rptViewer.ShowDialog(Me)
      Else
        ExportReport(rptViewer)
      End If

      rptViewer.Dispose()
      rptViewer = Nothing

        End Sub

        Private Sub locationComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles locationComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub locationComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles locationComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                locationComboBox.SelectedValue = -1
            End If
        End Sub

        Private Sub locationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles locationComboBox.SelectedIndexChanged

        End Sub
    End Class

End Namespace