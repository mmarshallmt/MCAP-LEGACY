Imports Microsoft.Reporting.WinForms
Namespace UI

    Public Class ErrorsCorrectedReportForm
        Implements IForm



        Private m_processor As Processors.ErrorsCorrectedReport



        ''' <summary>
        ''' Processor for Errors Corrected Reprot.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property Processor() As Processors.ErrorsCorrectedReport
            Get
                Return m_processor
            End Get
        End Property



        ''' <summary>
        ''' Validates all inputs and returns boolean status.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function AreInputsValid() As Boolean
            Dim areAllValid As Boolean


            areAllValid = True

            If dateRangeRadioButton.Checked Then
                If startdateTypeInDatePicker.Value.HasValue = False Then
                    SetErrorProvider(startdateTypeInDatePicker, "Provide start date.")
                    areAllValid = False
                ElseIf enddateTypeInDatePicker.Value.HasValue = False Then
                    SetErrorProvider(enddateTypeInDatePicker, "Provide end date.")
                    areAllValid = False
                ElseIf startdateTypeInDatePicker.Value.Value > enddateTypeInDatePicker.Value.Value Then
                    SetErrorProvider(startdateTypeInDatePicker, "Start date should be prior to end date.")
                    areAllValid = False
                End If
                If startdateTypeInDatePicker.Text = "  /  /" And enddateTypeInDatePicker.Text <> "  /  /" Then
                    areAllValid = False
                    SetErrorProvider(startdateTypeInDatePicker, "Provide valid start date.")
                Else
                    RemoveErrorProvider(startdateTypeInDatePicker)
                End If
                If startdateTypeInDatePicker.Text <> "  /  /" And enddateTypeInDatePicker.Text = "  /  /" Then
                    areAllValid = False
                    SetErrorProvider(enddateTypeInDatePicker, "Provide valid end date.")
                ElseIf startdateTypeInDatePicker.Value.HasValue AndAlso startdateTypeInDatePicker.Value.Value.Subtract(enddateTypeInDatePicker.Value.Value).Days > 0 _
                Then
                    MessageBox.Show("End Date cannot be before Start Date.", ProductName _
                                    , MessageBoxButtons.OK, MessageBoxIcon.Error)
                    areAllValid = False

                Else
                    RemoveErrorProvider(enddateTypeInDatePicker)
                End If
            End If

            If userComboBox.SelectedValue Is Nothing Then
                SetErrorProvider(userComboBox, "Select user from drop down list.")
                areAllValid = False
            Else
                RemoveErrorProvider(userComboBox)
            End If

            If areaComboBox.SelectedIndex < 0 Then
                SetErrorProvider(areaComboBox, "Select area from drop down list.")
                areAllValid = False
            Else
                RemoveErrorProvider(areaComboBox)
            End If

            If actionComboBox.SelectedIndex < 0 Then
                SetErrorProvider(actionComboBox, "Select action from drop down list.")
                areAllValid = False
            Else
                RemoveErrorProvider(actionComboBox)

            End If
            If weekNoRadioButton.Checked Then
                If startweekNumericUpDown.Text = "" Then
                    SetErrorProvider(startweekNumericUpDown, "Provide valid week number.")
                    MsgBox("Provide valid week number.", MsgBoxStyle.Information)
                    areAllValid = False
                Else
                    RemoveErrorProvider(startweekNumericUpDown)
                End If
                If startyearNumericUpDown.Text = "" Then
                    SetErrorProvider(startyearNumericUpDown, "Provide valid year.")
                    MsgBox("Provide valid year.", MsgBoxStyle.Information)
                    areAllValid = False
                Else
                    RemoveErrorProvider(startyearNumericUpDown)
                End If
                If endweekNumericUpDown.Text = "" Then
                    SetErrorProvider(endweekNumericUpDown, "Provide valid week number.")
                    MsgBox("Provide valid week number.", MsgBoxStyle.Information)
                    areAllValid = False
                Else
                    RemoveErrorProvider(endweekNumericUpDown)
                End If
                If endyearNumericUpDown.Text = "" Then
                    SetErrorProvider(endyearNumericUpDown, "Provide valid year.")
                    MsgBox("Provide valid year.", MsgBoxStyle.Information)
                    areAllValid = False
                Else
                    RemoveErrorProvider(endyearNumericUpDown)
                End If

                If startweekNumericUpDown.Value < 1 OrElse startweekNumericUpDown.Value > 53 Then
                    SetErrorProvider(startweekNumericUpDown, "Provide valid week number.")
                    areAllValid = False
                Else
                    RemoveErrorProvider(startweekNumericUpDown)
                End If
                If startyearNumericUpDown.Value < 2000 Then
                    SetErrorProvider(startyearNumericUpDown, "Provide valid year.")
                    areAllValid = False
                Else
                    RemoveErrorProvider(startyearNumericUpDown)
                End If

                If endweekNumericUpDown.Value < 1 OrElse endweekNumericUpDown.Value > 53 Then
                    SetErrorProvider(endweekNumericUpDown, "Provide valid week number.")
                    areAllValid = False
                Else
                    RemoveErrorProvider(endweekNumericUpDown)
                End If
                If endyearNumericUpDown.Value < 2000 Then
                    SetErrorProvider(endyearNumericUpDown, "Provide valid year.")
                    areAllValid = False
                Else
                    RemoveErrorProvider(endyearNumericUpDown)
                End If
            End If


            Return areAllValid

        End Function

        ''' <summary>
        ''' Loads data needed for report.
        ''' </summary>
        ''' <param name="userName"></param>
        ''' <param name="reportData"></param>
        ''' <param name="reportFilePath"></param>
        ''' <remarks></remarks>
        Private Sub LoadReportData(ByVal userName As String, ByRef reportData As Microsoft.Reporting.WinForms.ReportDataSource, ByRef reportFilePath As String)

            Select Case areaComboBox.SelectedIndex
                Case 0  'Check-In
                    Select Case actionComboBox.SelectedIndex
                        Case 0  'Fields
                            If dateRangeRadioButton.Checked Then
                                Processor.LoadReportData(userName, startdateTypeInDatePicker.Value, enddateTypeInDatePicker.Value)
                            Else
                                Processor.LoadReportData(userName, startweekNumericUpDown.Value, startyearNumericUpDown.Value, endweekNumericUpDown.Value, endyearNumericUpDown.Value)
                            End If
                            reportData = New Microsoft.Reporting.WinForms.ReportDataSource("ErrorCorrectedReportDataSet_EnvelopeErrorsCorrected", CType(Processor.Data.EnvelopeErrorsCorrected, DataTable))
                            'reportFilePath = Application.StartupPath + "\" + ErrorsCorrectedReportFilePath
                            reportFilePath = "MCAP.ErrorsCorrectedReport.rdlc"

                        Case Else
                            MessageBox.Show("Report is not available for this option.", ProductName _
                                            , MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Select  'actionComboBox.SelectedIndex

                Case Else
                    MessageBox.Show("Report is not available for this option.", ProductName _
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Select

        End Sub


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

            m_processor = New UI.Processors.ErrorsCorrectedReport

            Try
                Me.Processor.LoadDataSet()
            Catch ex As System.Data.SqlClient.SqlException
                Trace.TraceError("ErrorsCorrectedReortForm.Init(): Loading users. Message=" + ex.Message, New Object() {"ErrorClass=", ex.Class, "Procedure=", ex.Procedure, "LineNumber=", ex.LineNumber, "SQLErrorNumber=", ex.State, "ErrorNumber=", ex.Number, "Source=", ex.Source})
                MessageBox.Show("Error has occurred while loading list of users.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                Trace.TraceError("ErrorsCorrectedReortForm.Init(): Unknown error has occurred while loading user. Message=" + ex.Message)
                MessageBox.Show("Unknown error has occurred while loading list of users.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Me.userComboBox.ValueMember = "Username"  '"UserId"
            Me.userComboBox.DisplayMember = "FullName"
            Me.userComboBox.DataSource = Me.Processor.Data.User

            startyearNumericUpDown.Value = System.DateTime.Today.Year
            endyearNumericUpDown.Value = System.DateTime.Today.Year

            Dim strWeekNo As String

            Try
                strWeekNo = Processor.GetWeekNumber(DateTime.Today)
                startyearNumericUpDown.Value = CType(strWeekNo.Substring(0, 4), Integer)
                startweekNumericUpDown.Value = CType(strWeekNo.Substring(5, 2), Integer)
            Catch ex As System.Data.SqlClient.SqlException
                Trace.TraceError("ErrorsCorrectedReortForm.Init(): Calculating week number. Message=" + ex.Message, New Object() {"ErrorClass=", ex.Class, "Procedure=", ex.Procedure, "LineNumber=", ex.LineNumber, "SQLErrorNumber=", ex.State, "ErrorNumber=", ex.Number, "Source=", ex.Source})
                MessageBox.Show("Error has occurred while calculating week number.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                Trace.TraceError("ErrorsCorrectedReortForm.Init(): Unknown error has occurred while calculating week number. Message=" + ex.Message)
                MessageBox.Show("Unknown error has occurred while calculating week number.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

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

            Me.ShowHideControls(Me.FormState)
            Me.EnableDisableControls(Me.FormState)

            RaiseEvent FormInitialized()

            Me.ResumeLayout()

        End Sub

#End Region



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

        Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

            Me.Close()

        End Sub

        Private Function GetFilterCriteriaText() As String
            Dim filterCriteria As System.Text.StringBuilder


            filterCriteria = New System.Text.StringBuilder()
            filterCriteria.Append("User:")
            filterCriteria.Append(userComboBox.Text)
            filterCriteria.Append(", Area:")
            filterCriteria.Append(areaComboBox.Text)
            filterCriteria.Append(", Action:")
            filterCriteria.Append(actionComboBox.Text)
            If dateRangeRadioButton.Checked Then
                filterCriteria.Append(", Date Range: From ")
                filterCriteria.Append(startdateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy"))
                filterCriteria.Append(" To ")
                filterCriteria.Append(enddateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy"))
            Else
                filterCriteria.Append(", Week Range: From ")
                filterCriteria.Append(startweekNumericUpDown.Value.ToString("0#"))
                filterCriteria.Append("-")
                filterCriteria.Append(startyearNumericUpDown.Value.ToString("000#"))
                filterCriteria.Append(" To ")
                filterCriteria.Append(endweekNumericUpDown.Value.ToString("0#"))
                filterCriteria.Append("-")
                filterCriteria.Append(endyearNumericUpDown.Value.ToString("000#"))
            End If

            Return filterCriteria.ToString()

        End Function

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
                .ReportName = reportTitle
                .WindowState = FormWindowState.Maximized
                .PrepareReport()
                .RefreshReport()
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
                .ReportName = reportTitle
                .PrepareReport()
                .RefreshReport()
                .WindowState = FormWindowState.Maximized
            End With

            Application.DoEvents()

            rptViewer.ExportReportToExcel(System.IO.Path.GetTempFileName())

            rptViewer.Dispose()
            rptViewer = Nothing

        End Sub

        Private Sub generateReportButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles generateReportButton.Click
            Dim reportPath, userName, reportTitle, reportFilterText As String
            Dim rptDataSource As Microsoft.Reporting.WinForms.ReportDataSource


            If AreInputsValid() = False Then Exit Sub

            userName = userComboBox.SelectedValue.ToString()

            Try
                LoadReportData(userName, rptDataSource, reportPath)
            Catch ex As System.Data.SqlClient.SqlException
                Trace.TraceError("ErrorsCorrectedReportForm.generateReportButton_Click(): Unable to fetch records. Message=" + ex.Message, New Object() {"UserName=", userName, "ErrorClass=", ex.Class, "Procedure=", ex.Procedure, "LineNumber=", ex.LineNumber, "SQLErrorNumber=", ex.State, "ErrorNumber=", ex.Number, "Source=", ex.Source})
                MessageBox.Show("Error has occurred while loading information from database.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                Trace.TraceError("ErrorsCorrectedReportForm.generateReportButton_Click(): Unknown error. Message=" + ex.Message, New Object() {"UserName=", userName})
                MessageBox.Show("Unknown error has occurred while loading information from database.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            reportTitle = "Envelope Check-In Errors Corrected "
            reportFilterText = GetFilterCriteriaText()

            If rptDataSource Is Nothing OrElse reportPath Is Nothing Then Exit Sub

            If reportPath Is Nothing Then
                MessageBox.Show("There exists no data for report. Try different selection.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Try
                    If screenRadioButton.Checked Then
                        GenerateReport(reportPath, rptDataSource, reportTitle, reportFilterText)
                    Else
                        ExportReport(reportPath, rptDataSource, reportTitle, reportFilterText)
                    End If
                Catch ex As Microsoft.Reporting.WinForms.MissingDataSourceException
                    Trace.TraceError("ErrorsCorrectedReportForm.generateReportButton_Click(): Missing datasource. Message=" + ex.Message, New Object() {"On Screen=", screenRadioButton.Checked, "Path=", reportPath, "DataSource Name=", rptDataSource.Name, "Title=", reportTitle, "Filter=", reportFilterText})
                    MessageBox.Show("Error has occurred while preparing report.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Microsoft.Reporting.WinForms.MissingParameterException
                    Trace.TraceError("ErrorsCorrectedReportForm.generateReportButton_Click(): Missing parameter. Message=" + ex.Message, New Object() {"On Screen=", screenRadioButton.Checked, "Path=", reportPath, "DataSource Name=", rptDataSource.Name, "Title=", reportTitle, "Filter=", reportFilterText})
                    MessageBox.Show("Error has occurred while preparing report.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Microsoft.Reporting.WinForms.LocalProcessingException
                    Trace.TraceError("ErrorsCorrectedReportForm.generateReportButton_Click(): Error while local processing. Message=" + ex.Message, New Object() {"On Screen=", screenRadioButton.Checked, "Path=", reportPath, "DataSource Name=", rptDataSource.Name, "Title=", reportTitle, "Filter=", reportFilterText})
                    MessageBox.Show("Error has occurred while preparing report.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Microsoft.Reporting.WinForms.ReportViewerException
                    Trace.TraceError("ErrorsCorrectedReportForm.generateReportButton_Click(): Error while viewing. Message=" + ex.Message, New Object() {"On Screen=", screenRadioButton.Checked, "Path=", reportPath, "DataSource Name=", rptDataSource.Name, "Title=", reportTitle, "Filter=", reportFilterText})
                    MessageBox.Show("Error has occurred while preparing report.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    Trace.TraceError("ErrorsCorrectedReportForm.generateReportButton_Click(): Unknown error. Message=" + ex.Message, New Object() {"On Screen=", screenRadioButton.Checked, "Path=", reportPath, "DataSource Name=", rptDataSource.Name, "Title=", reportTitle, "Filter=", reportFilterText})
                    MessageBox.Show("Unknown error has occurred while preparing report.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If

            reportPath = Nothing
            rptDataSource = Nothing

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

        Private Sub areaComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles areaComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub areaComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles areaComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                areaComboBox.SelectedIndex = -1
            End If
        End Sub

        Private Sub actionComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles actionComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub actionComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles actionComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                actionComboBox.SelectedIndex = -1
            End If
        End Sub
    End Class


End Namespace