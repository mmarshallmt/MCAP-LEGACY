Namespace UI

  Public Class PackageExpectationReportForm
    Implements IForm


        Private WithEvents m_processor As Processors.PackageExpectationReport
        Private pageLoadedComplete As Boolean
        Dim mktClicked As Boolean
        Dim sndrClicked As Boolean

    Private ReadOnly Property Processor() As Processors.PackageExpectationReport
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

            pageLoadedComplete = False
      m_processor = New Processors.PackageExpectationReport
      Processor.Initialize()
      Processor.LoadLocation()

      locationComboBox.DisplayMember = "Descrip"
      locationComboBox.ValueMember = "CodeId"
      locationComboBox.DataSource = Processor.Data.vwLocation
      locationComboBox.SelectedValue = User.LocationId
            locationComboBox.Text = User.Location

            Processor.LoadSender()
            senderComboBox.DisplayMember = "Name"
            senderComboBox.ValueMember = "SenderId"
            senderComboBox.DataSource = Processor.Data.Sender
            SenderComboBox.SelectedValue = -1

            Processor.LoadMarket()
            marketComboBox.DisplayMember = "Descrip"
            marketComboBox.ValueMember = "MktId"
            marketComboBox.DataSource = Processor.Data.Mkt
            marketComboBox.SelectedValue = -1

            mktClicked = False
            sndrClicked = False



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
            pageLoadedComplete = True
      RaiseEvent FormInitialized()

    End Sub


#End Region
        Private Sub RestForm()
            marketComboBox.SelectedValue = -1
            SenderComboBox.SelectedValue = -1
            thisWeekRadioButton.Checked = False
            todayRadioButton.Checked = False
            receivedRadioButton.Checked = True
            notreceivedRadioButton.Checked = False

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

        Private Sub LoadReceived _
            (ByVal dataSet As PackageExpectationReportDataSet, ByVal startDate As DateTime _
             , ByVal endDate As DateTime, ByVal locationId As Integer _
             , ByVal marketId As Integer, ByVal senderId As Integer, ByVal todayChecked As Integer, _
             ByVal thisWeekChecked As Integer, ByVal currentDate As DateTime)
            Dim adapter As PackageExpectationReportDataSetTableAdapters.PackageReceivedTableAdapter

            adapter = New PackageExpectationReportDataSetTableAdapters.PackageReceivedTableAdapter
            adapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            'adapter.Adapter.SelectCommand.CommandTimeout = My.Settings.CommandTimeout - to be updated 11
            Try
                adapter.Fill(dataSet.PackageReceived, startDate, endDate, Nothing, Nothing, locationId, marketId, senderId, todayChecked, thisWeekChecked, currentDate)
            Catch ex As Exception
            End Try
            adapter.Dispose()
            adapter = Nothing

        End Sub

        Private Sub LoadReceived _
            (ByVal dataSet As PackageExpectationReportDataSet, ByVal startWeekNo As String, ByVal endWeekNo As String, _
             ByVal locationId As Integer _
             , ByVal marketId As Integer, ByVal senderId As Integer, _
             ByVal todayChecked As Integer, ByVal thisWeekChecked As Integer, ByVal currentDate As DateTime)

            Dim adapter As PackageExpectationReportDataSetTableAdapters.PackageReceivedTableAdapter
            adapter = New PackageExpectationReportDataSetTableAdapters.PackageReceivedTableAdapter
            adapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            ' adapter.Adapter.SelectCommand.CommandTimeout = My.Settings.CommandTimeout - to be updated 12
            Try
                adapter.Fill(dataSet.PackageReceived, Nothing, Nothing, startWeekNo, endWeekNo, locationId, marketId, senderId, todayChecked, thisWeekChecked, currentDate)
            Catch ex As Exception

            End Try
            adapter.Dispose()
            adapter = Nothing
        End Sub

        Private Sub LoadNotReceived _
            (ByVal dataSet As PackageExpectationReportDataSet, ByVal startDate As DateTime _
             , ByVal endDate As DateTime, ByVal forceOnePerWeek As Boolean, ByVal locationId As Integer _
             , ByVal marketId As Integer, ByVal senderId As Integer, ByVal todayChecked As Integer, _
             ByVal thisWeekChecked As Integer, ByVal currentDate As DateTime)
            Dim adapter As PackageExpectationReportDataSetTableAdapters.PackageNotReceivedTableAdapter

            Dim tmpStartWeek As String = Format(DatePart(DateInterval.WeekOfYear, startDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1), "00")
            Dim tmpEndWeek As String = Format(DatePart(DateInterval.WeekOfYear, endDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1), "00")
            Dim pStartWeek As String = CType(Year(startDate), String) + "-" + CType(tmpStartWeek, String)
            Dim pEndWeek As String = CType(Year(endDate), String) + "-" + CType(tmpEndWeek, String)


            adapter = New PackageExpectationReportDataSetTableAdapters.PackageNotReceivedTableAdapter
            adapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            '' adapter.Fill(dataSet.PackageNotReceived, startDate, endDate, pStartWeek, pEndWeek, forceOnePerWeek, locationId, marketId, senderId, todayChecked, thisWeekChecked, currentDate) 1. \\ comment by Denver 4-19-2012: Too many parameter supplied 
            'adapter.Adapter.SelectCommand.CommandTimeout = My.Settings.CommandTimeout - to be updated 13
            adapter.Fill(dataSet.PackageNotReceived, pStartWeek, pEndWeek, forceOnePerWeek, locationId, senderId, marketId, todayChecked, thisWeekChecked, currentDate)

            adapter.Dispose()
            adapter = Nothing
        End Sub

        Private Sub LoadNotReceived _
            (ByVal dataSet As PackageExpectationReportDataSet, ByVal startWeekNo As String _
             , ByVal endWeekNo As String, ByVal forceOnePerWeek As Boolean, ByVal locationId As Integer _
             , ByVal marketId As Integer, ByVal senderId As Integer, ByVal todayChecked As Integer, _
            ByVal thisWeekChecked As Integer, ByVal currentDate As DateTime)
            Dim adapter As PackageExpectationReportDataSetTableAdapters.PackageNotReceivedTableAdapter


            adapter = New PackageExpectationReportDataSetTableAdapters.PackageNotReceivedTableAdapter
            adapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            ''adapter.Fill(dataSet.PackageNotReceived, Nothing, Nothing, startWeekNo, endWeekNo, forceOnePerWeek, locationId, marketId, senderId, todayChecked, thisWeekChecked, currentDate) 2. \\  comment by Denver: Too many parameter supplied
            'adapter.Adapter.SelectCommand.CommandTimeout = My.Settings.CommandTimeout - to be update 14
            adapter.Fill(dataSet.PackageNotReceived, startWeekNo, endWeekNo, forceOnePerWeek, locationId, senderId, marketId, todayChecked, thisWeekChecked, currentDate)

            adapter.Dispose()
            adapter = Nothing
        End Sub


        Private Sub GenerateReport(ByVal reportForm As UI.ShowReportForm, ByVal dataSet As PackageExpectationReportDataSet)
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

                If receivedRadioButton.Checked Then
                    .ReportFileResourceName = "MCAP.PackageExpectation_ReceivedReport.rdlc"
                    '.ReportFilePath = Application.StartupPath + "\" + PackageExpectationReceivedReportFilePath
                    .DataSources.Add("PackageExpectationReportDataSet_PackageReceived", dataSet.PackageReceived)
                    .ReportName = "Package Expectation Received "
                Else
                    .ReportFileResourceName = "MCAP.PackageExpectation_NotReceivedReport.rdlc"
                    '.ReportFilePath = Application.StartupPath + "\" + PackageExpectationNotReceivedReportFilePath
                    .DataSources.Add("PackageExpectationReportDataSet_PackageNotReceived", dataSet.PackageNotReceived)
                    .ReportName = "Package Expectation Not Received "
                End If

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

        Private Sub notreceivedRadioButton_CheckedChanged _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles notreceivedRadioButton.CheckedChanged

            If notreceivedRadioButton.Checked Then
                weekNoRadioButton.Checked = True
                dateRangeRadioButton.Enabled = True
            Else
                dateRangeRadioButton.Enabled = True
            End If

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


        Private Sub generateReportButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles generateReportButton.Click
            Dim ds As PackageExpectationReportDataSet
            Dim rptViewer As ShowReportForm
            Dim psenderId As Integer
            Dim pmarketId As Integer
            Dim ptodayVal As Integer
            Dim pweekVal As Integer
            Dim todaysDate As Date = Today()

            If senderComboBox.SelectedValue Is Nothing Then
                psenderId = 0
            Else
                psenderId = CType(senderComboBox.SelectedValue, Integer)
            End If

            If marketComboBox.SelectedValue Is Nothing Then
                pmarketId = 0
            Else
                pmarketId = CType(marketComboBox.SelectedValue, Integer)
            End If

            If todayRadioButton.Checked Then
                Dim dayOfWeek As Integer = Weekday(todaysDate, FirstDayOfWeek.Sunday)

                ptodayVal = dayOfWeek
            Else
                ptodayVal = 0
            End If

            If thisWeekRadioButton.Checked Then
                pweekVal = DatePart(DateInterval.WeekOfYear, todaysDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1)
            Else
                pweekVal = 0
            End If


            If AreInputsValid() = False Then Exit Sub

            ds = New PackageExpectationReportDataSet


                If notreceivedRadioButton.Checked Then
                ' Not received Section
                If dateRangeRadioButton.Checked Then
                    LoadNotReceived(ds, startdateTypeInDatePicker.Value.Value, enddateTypeInDatePicker.Value.Value.AddDays(1), False, CType(locationComboBox.SelectedValue, Integer), psenderId, pmarketId, ptodayVal, pweekVal, todaysDate)
                Else
                    LoadNotReceived(ds, startyearNumericUpDown.Value.ToString("####") + "-" + startweekNumericUpDown.Value.ToString("00") _
                                   , endyearNumericUpDown.Value.ToString("####") + "-" + endweekNumericUpDown.Value.ToString("00") _
                                   , False, CType(locationComboBox.SelectedValue, Integer), psenderId, pmarketId, ptodayVal, pweekVal, todaysDate)

                End If
            Else
                If dateRangeRadioButton.Checked Then
                    LoadReceived(ds, startdateTypeInDatePicker.Value.Value, enddateTypeInDatePicker.Value.Value.AddDays(1), CType(locationComboBox.SelectedValue, Integer), psenderId, pmarketId, ptodayVal, pweekVal, todaysDate)
                Else
                    LoadReceived(ds, startyearNumericUpDown.Value.ToString("####") + "-" + startweekNumericUpDown.Value.ToString("00") _
                                 , endyearNumericUpDown.Value.ToString("####") + "-" + endweekNumericUpDown.Value.ToString("00"), CType(locationComboBox.SelectedValue, Integer), psenderId, pmarketId, ptodayVal, pweekVal, todaysDate)
                End If
            End If

            rptViewer = New ShowReportForm()
            GenerateReport(rptViewer, ds)

            If screenRadioButton.Checked Then
                rptViewer.RefreshReport()
                rptViewer.ShowDialog(Me)
            Else
                ExportReport(rptViewer)
            End If

            ds.Dispose()
            rptViewer.Dispose()

            ds = Nothing
            rptViewer = Nothing

        End Sub

        Private Sub senderComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub senderComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If e.KeyChar = Chr(Keys.Back) Then
                senderComboBox.SelectedValue = -1
            End If
        End Sub

        Private Sub senderComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

            Dim dts As PackageExpectationReportDataSet

            If pageLoadedComplete Then

                dts = New PackageExpectationReportDataSet
                Dim tsenderId As Integer

                tsenderId = CType(senderComboBox.SelectedValue, Integer)
                If mktClicked = False Then
                    Processor.reLoadMarket(tsenderId)
                    sndrClicked = True
                End If

            End If

        End Sub

        Private Sub marketComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub marketComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            If e.KeyChar = Chr(Keys.Back) Then
                marketComboBox.SelectedValue = -1
            End If
        End Sub

        Private Sub marketComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim dts As PackageExpectationReportDataSet
            If pageLoadedComplete Then

                dts = New PackageExpectationReportDataSet
                Dim tmarketId As Integer

                tmarketId = CType(marketComboBox.SelectedValue, Integer)
                If sndrClicked = False Then
                    Processor.reLoadSender(tmarketId)
                    mktClicked = True
                End If

            End If
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

        Private Sub marketComboBox_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub locationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles locationComboBox.SelectedIndexChanged

        End Sub

        Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
            RestForm()
        End Sub
    End Class

End Namespace