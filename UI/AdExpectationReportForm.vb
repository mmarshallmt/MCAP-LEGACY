Namespace UI

    Public Class AdExpectationReportForm
        Implements IForm


        Private WithEvents m_processor As Processors.AdExpectationReport
        Private pageLoadedComplete As Boolean
        Dim mktClicked As Boolean
        Dim sndrClicked As Boolean

        Private ReadOnly Property Processor() As Processors.AdExpectationReport
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
            m_processor = New Processors.AdExpectationReport
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
            senderComboBox.SelectedIndex = -1

            Processor.LoadMarket()
            marketComboBox.DisplayMember = "Descrip"
            marketComboBox.ValueMember = "MktId"
            marketComboBox.DataSource = Processor.Data.Mkt
            marketComboBox.SelectedIndex = -1

            Processor.LoadPriority()
            priorityComboBox.DisplayMember = "Priority"
            priorityComboBox.ValueMember = "Priority"
            priorityComboBox.DataSource = Processor.Data.Priority
            priorityComboBox.SelectedIndex = -1

            Processor.LoadMedia()
            mediaComboBox.DisplayMember = "Descrip"
            mediaComboBox.ValueMember = "MediaID"
            mediaComboBox.DataSource = Processor.Data.Media
            mediaComboBox.SelectedIndex = -1

            Processor.LoadFrequency()
            frequencyComboBox.DisplayMember = "Descrip"
            frequencyComboBox.ValueMember = "CodeId"
            frequencyComboBox.DataSource = Processor.Data.vwFrequency
            frequencyComboBox.SelectedIndex = 1

            Processor.LoadEntryProject()
            entryProjectComboBox.DisplayMember = "indicatorcolumn"
            entryProjectComboBox.ValueMember = "indicatorcolumn"
            entryProjectComboBox.DataSource = Processor.Data.entryproject
            entryProjectComboBox.SelectedIndex = -1

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


        Private Function GetWeekNumber(ByVal paramDate As DateTime) As String
            Dim weekNumber As String
            'weekNumber = "12"
            Dim adapter As ExpectationReportDataSetTableAdapters.AdReceivedTableAdapter

            adapter = New ExpectationReportDataSetTableAdapters.AdReceivedTableAdapter
            adapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            weekNumber = adapter.GetWeekNoMondayStart(paramDate).ToString()

            adapter.Dispose()
            adapter = Nothing


            Return weekNumber

        End Function

        Private Sub LoadReceived _
            (ByVal dataSet As ExpectationReportDataSet, ByVal startDate As DateTime _
             , ByVal endDate As DateTime, ByVal locationId As Integer _
             , ByVal priorityId As Integer, ByVal entryProject As String _
             , ByVal senderId As Integer, ByVal marketId As Integer, ByVal todayChecked As Integer, ByVal thisWeekChecked As Integer _
             , ByVal mediaType As Integer, ByVal Frequency As Integer, ByVal Status As Integer, ByVal currentDate As DateTime)
            Dim adapter As ExpectationReportDataSetTableAdapters.AdReceivedTableAdapter

            adapter = New ExpectationReportDataSetTableAdapters.AdReceivedTableAdapter
            adapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            'adapter.Adapter.SelectCommand.CommandTimeout = My.Settings.CommandTimeout - to be updated 15
            Try
                adapter.Fill(dataSet.AdReceived, startDate, endDate, Nothing, Nothing, locationId, entryProject, priorityId, senderId, marketId, todayChecked, thisWeekChecked, mediaType, Frequency, Status, currentDate)
            Catch ex As Exception
            End Try
            adapter.Dispose()
            adapter = Nothing

        End Sub

        Private Sub LoadReceived _
            (ByVal dataSet As ExpectationReportDataSet, ByVal startWeekNo As String, ByVal endWeekNo As String, _
             ByVal locationId As Integer, ByVal priorityId As Integer, ByVal entryProject As String _
             , ByVal senderId As Integer, ByVal marketId As Integer, ByVal todayChecked As Integer, ByVal thisWeekChecked As Integer _
             , ByVal mediaType As Integer, ByVal Frequency As Integer, ByVal Status As Integer, ByVal currentDate As DateTime)

            Dim adapter As ExpectationReportDataSetTableAdapters.AdReceivedTableAdapter
            adapter = New ExpectationReportDataSetTableAdapters.AdReceivedTableAdapter
            adapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            '  adapter.Adapter.SelectCommand.CommandTimeout = My.Settings.CommandTimeout - to be updated 16
            Try
                adapter.Fill(dataSet.AdReceived, Nothing, Nothing, startWeekNo, endWeekNo, locationId, entryProject, priorityId, senderId, marketId, todayChecked, thisWeekChecked, mediaType, Frequency, Status, currentDate)
            Catch ex As Exception

            End Try
            adapter.Dispose()
            adapter = Nothing
        End Sub

        Private Sub LoadNotReceived _
            (ByVal dataSet As ExpectationReportDataSet, ByVal startDate As DateTime _
             , ByVal endDate As DateTime, ByVal forceOnePerWeek As Boolean, ByVal locationId As Integer _
             , ByVal priorityId As Integer, ByVal entryProject As String _
             , ByVal senderId As Integer, ByVal marketId As Integer, ByVal todayChecked As Integer, ByVal thisWeekChecked As Integer _
             , ByVal mediaType As Integer, ByVal Frequency As Integer, ByVal Status As Integer, ByVal currentDate As DateTime)
            Dim adapter As ExpectationReportDataSetTableAdapters.AdNotReceivedTableAdapter

            Dim tmpStartWeek As String = Format(DatePart(DateInterval.WeekOfYear, startDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1), "00")
            Dim tmpEndWeek As String = Format(DatePart(DateInterval.WeekOfYear, endDate, FirstDayOfWeek.Sunday, FirstWeekOfYear.Jan1), "00")
            Dim pStartWeek As String = CType(Year(startDate), String) + "-" + CType(tmpStartWeek, String)
            Dim pEndWeek As String = CType(Year(endDate), String) + "-" + CType(tmpEndWeek, String)


            adapter = New ExpectationReportDataSetTableAdapters.AdNotReceivedTableAdapter
            adapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            ' adapter.Adapter.SelectCommand.CommandTimeout = My.Settings.CommandTimeout - to be updated 17
            adapter.Fill(dataSet.AdNotReceived, startDate, endDate, pStartWeek, pEndWeek, locationId, entryProject, priorityId, senderId, marketId, todayChecked, thisWeekChecked, mediaType, Frequency, Status, currentDate)

            adapter.Dispose()
            adapter = Nothing
        End Sub

        Private Sub LoadNotReceived _
            (ByVal dataSet As ExpectationReportDataSet, ByVal startWeekNo As String _
             , ByVal endWeekNo As String, ByVal forceOnePerWeek As Boolean, ByVal locationId As Integer _
             , ByVal priorityId As Integer, ByVal entryProject As String _
             , ByVal senderId As Integer, ByVal marketId As Integer, ByVal todayChecked As Integer, ByVal thisWeekChecked As Integer _
             , ByVal mediaType As Integer, ByVal Frequency As Integer, ByVal Status As Integer, ByVal currentDate As DateTime)
            Dim adapter As ExpectationReportDataSetTableAdapters.AdNotReceivedTableAdapter


            adapter = New ExpectationReportDataSetTableAdapters.AdNotReceivedTableAdapter
            adapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            'adapter.Adapter.SelectCommand.CommandTimeout = My.Settings.CommandTimeout - to be updated 18
            adapter.Fill(dataSet.AdNotReceived, Nothing, Nothing, startWeekNo, endWeekNo, locationId, entryProject, priorityId, senderId, marketId, todayChecked, thisWeekChecked, mediaType, Frequency, Status, currentDate)

            adapter.Dispose()
            adapter = Nothing
        End Sub


        Private Sub GenerateReport(ByVal reportForm As UI.ShowReportForm, ByVal dataSet As ExpectationReportDataSet)
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
                    .ReportFileResourceName = "MCAP.AdExpectation_ReceivedReport.rdlc"
                    '.ReportFilePath = Application.StartupPath + "\" + PackageExpectationReceivedReportFilePath
                    .DataSources.Add("ExpectationReportDataSet_AdReceived", dataSet.AdReceived)
                    .ReportName = "Expectation Ad Received"
                Else
                    .ReportFileResourceName = "MCAP.AdExpectation_NotReceivedReport.rdlc"
                    '.ReportFilePath = Application.StartupPath + "\" + PackageExpectationNotReceivedReportFilePath
                    .DataSources.Add("ExpectationReportDataSet_AdNotReceived", dataSet.AdNotReceived)
                    .ReportName = "Expectation Not Received"
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


        Private Sub generateReportButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles generateReportButton.Click
            Dim ds As ExpectationReportDataSet
            Dim rptViewer As ShowReportForm
            Dim todaysDate As Date = Today()
            Dim pPriority As Integer
            Dim psenderId As Integer
            Dim pmarketId As Integer
            Dim ptodayVal As Integer
            Dim pweekVal As Integer
            Dim pMediaType As Integer
            Dim pEntryProject As String
            Dim pStatus As Integer
            Dim pFrequency As Integer

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

            pEntryProject = CType(entryProjectComboBox.SelectedValue, String)

            pMediaType = CType(mediaComboBox.SelectedValue, Integer)

            ' This will put a default all for the first row selected.
            If priorityComboBox.SelectedIndex = -1 Then
                pPriority = 0
            Else
                pPriority = CType(priorityComboBox.SelectedValue, Integer)
            End If

            If frequencyComboBox.SelectedValue Is "" Then
                pFrequency = 0
            Else
                pFrequency = CType(frequencyComboBox.SelectedValue, Integer)
            End If

            If AllStatusRadioButton.Checked Then
                pStatus = 1
            Else
                pStatus = 0
            End If


            If AreInputsValid() = False Then Exit Sub

            ds = New ExpectationReportDataSet


            If notreceivedRadioButton.Checked Then

                ' Not received Section
                If dateRangeRadioButton.Checked Then
                    LoadNotReceived(ds, startdateTypeInDatePicker.Value.Value, enddateTypeInDatePicker.Value.Value.AddDays(1), False, CType(locationComboBox.SelectedValue, Integer), pPriority, pEntryProject, psenderId, pmarketId, ptodayVal, pweekVal _
                                     , pMediaType, pFrequency, pStatus, todaysDate)
                Else
                    LoadNotReceived(ds, startyearNumericUpDown.Value.ToString("####") + "-" + startweekNumericUpDown.Value.ToString("00") _
                                   , endyearNumericUpDown.Value.ToString("####") + "-" + endweekNumericUpDown.Value.ToString("00") _
                                   , False, CType(locationComboBox.SelectedValue, Integer), pPriority, pEntryProject, psenderId, pmarketId, ptodayVal, pweekVal _
                                   , pMediaType, pFrequency, pStatus, todaysDate)

                End If
            Else
                If dateRangeRadioButton.Checked Then
                    LoadReceived(ds, startdateTypeInDatePicker.Value.Value, enddateTypeInDatePicker.Value.Value.AddDays(1), CType(locationComboBox.SelectedValue, Integer), pPriority, pEntryProject, psenderId, pmarketId, ptodayVal, pweekVal _
                                 , pMediaType, pFrequency, pStatus, todaysDate)
                Else
                    LoadReceived(ds, startyearNumericUpDown.Value.ToString("####") + "-" + startweekNumericUpDown.Value.ToString("00") _
                                 , endyearNumericUpDown.Value.ToString("####") + "-" + endweekNumericUpDown.Value.ToString("00"), CType(locationComboBox.SelectedValue, Integer), pPriority, pEntryProject, psenderId, pmarketId, ptodayVal, pweekVal _
                                 , pMediaType, pFrequency, pStatus, todaysDate)
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

        Private Sub senderComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles senderComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub senderComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles senderComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                senderComboBox.SelectedValue = -1
            End If
        End Sub

        Private Sub senderComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles senderComboBox.SelectedIndexChanged

            Dim dts As ExpectationReportDataSet

            If pageLoadedComplete Then

                dts = New ExpectationReportDataSet
                Dim tsenderId As Integer

                tsenderId = CType(senderComboBox.SelectedValue, Integer)
                If mktClicked = False Then
                    Processor.reLoadMarket(tsenderId)
                    sndrClicked = True
                End If

            End If

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

        Private Sub marketComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles marketComboBox.SelectedValueChanged
            Dim dts As ExpectationReportDataSet
            If pageLoadedComplete Then

                dts = New ExpectationReportDataSet
                Dim tmarketId As Integer

                tmarketId = CType(marketComboBox.SelectedValue, Integer)
                If sndrClicked = False Then
                    Processor.reLoadSender(tmarketId)
                    mktClicked = True
                End If

            End If
        End Sub

        Private Sub priorityComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles priorityComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub priorityComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles priorityComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                priorityComboBox.SelectedValue = -1
            End If
        End Sub

        Private Sub entryProjectComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles entryProjectComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub entryProjectComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles entryProjectComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                entryProjectComboBox.SelectedValue = -1
            End If
        End Sub

        Private Sub mediaComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mediaComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub mediaComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mediaComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                mediaComboBox.SelectedValue = -1
            End If
        End Sub

        Private Sub frequencyComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles frequencyComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub frequencyComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles frequencyComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                frequencyComboBox.SelectedValue = -1
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
    End Class

End Namespace