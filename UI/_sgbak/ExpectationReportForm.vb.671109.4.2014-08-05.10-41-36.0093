Namespace UI

    Public Class ExpectationReportForm
        Implements IForm


        Private reportDS As MCAP.ExpectationReportDataSet


        Private Sub LoadUsers()
            Dim userAdapter As MCAP.ExpectationReportDataSetTableAdapters.UserTableAdapter


            userAdapter = New MCAP.ExpectationReportDataSetTableAdapters.UserTableAdapter()
            userAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Try
                userAdapter.Fill(reportDS.User, User.LocationId)
            Catch ex As Exception
                Throw
            Finally
                userAdapter.Dispose()
                userAdapter = Nothing
            End Try

        End Sub

        Private Sub ShowUserOnScreen()
            Dim listItem As System.Windows.Forms.ListViewItem


            For i As Integer = 0 To reportDS.User.Count - 1
                If reportDS.User(i).IsEmailIdNull() Then Continue For

                listItem = userListView.Items.Add(reportDS.User(i).UserID.ToString(), reportDS.User(i).FullName, 0)
                listItem.SubItems.Add(reportDS.User(i).EmailId)
                If reportDS.User(i).UserID = User.UserID Then listItem.Checked = True
            Next

        End Sub

        Private Function ValidateInputs() As Boolean
            Dim areInputsValid As Boolean
            Dim checkedItems As System.Collections.Generic.IEnumerable(Of System.Windows.Forms.ListViewItem)


            areInputsValid = True

            If priorityoneCheckBox.Checked = False _
              AndAlso prioritytwoCheckBox.Checked = False _
              AndAlso priorityotherCheckBox.Checked = False _
            Then
                MessageBox.Show("Select priority for generating report.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                areInputsValid = False
            End If

            checkedItems = From i In userListView.Items.Cast(Of System.Windows.Forms.ListViewItem)() _
                           Where i.Checked = True _
                           Select i
            If checkedItems.Count() = 0 Then
                MessageBox.Show("Select recipient(s) of report.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                areInputsValid = False
            End If

            checkedItems = Nothing

            Return areInputsValid

        End Function

        Private Function GetPriorityCSV() As String
            Dim priorityCSV As System.Text.StringBuilder


            priorityCSV = New System.Text.StringBuilder()

            If priorityoneCheckBox.Checked Then priorityCSV.Append("1")

            If prioritytwoCheckBox.Checked Then
                If priorityCSV.Length > 0 Then priorityCSV.Append(",")
                priorityCSV.Append("2")
            End If

            If priorityotherCheckBox.Checked Then
                If priorityCSV.Length > 0 Then priorityCSV.Append(",")
                priorityCSV.Append("3")
            End If

            Return priorityCSV.ToString()

        End Function

        Private Function GetRecipients() As String
            Dim recipients As System.Text.StringBuilder
            Dim checkedItems As System.Collections.Generic.IEnumerable(Of System.Windows.Forms.ListViewItem)


            recipients = New System.Text.StringBuilder()
            checkedItems = From i In userListView.Items.Cast(Of System.Windows.Forms.ListViewItem)() _
                           Where i.Checked = True _
                           Select i

            For i As Integer = 0 To checkedItems.Count() - 1
                If recipients.Length > 0 Then recipients.Append("; ")
                recipients.Append(checkedItems(i).SubItems(1).Text)
            Next

            checkedItems = Nothing

            Return recipients.ToString()

        End Function


#Region " IForm implementation "


        Public Event InitializingForm() Implements IForm.InitializingForm
        Public Event FormInitialized() Implements IForm.FormInitialized

        Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
        Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied


        Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

        End Sub

        Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

            Me.SuspendLayout()

            Me.StatusMessage = "Loading information for expectation report. This may take some time, please wait."

            reportDS = New MCAP.ExpectationReportDataSet()

            Try
                LoadUsers()
            Catch ex As System.Data.SqlClient.SqlException
                Trace.TraceError("ExpectationReportForm.Init(): Loading users. Message=" + ex.Message, New Object() {"ErrorClass=", ex.Class, "Procedure=", ex.Procedure, "LineNumber=", ex.LineNumber, "SQLErrorNumber=", ex.State, "ErrorNumber=", ex.Number, "Source=", ex.Source})
                MessageBox.Show("Error has occurred while loading list of recipients.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                Trace.TraceError("ExpectationReportForm.Init(): Unknown error has occurred while loading user. Message=" + ex.Message)
                MessageBox.Show("Unknown error has occurred while loading list of recipients.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ShowUserOnScreen()

            Me.StatusMessage = "Preparing expectation report screen, please wait."

            Me.StatusMessage = String.Empty

            Me.ResumeLayout()

        End Sub


#End Region


        Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

            Me.Close()

        End Sub

        Private Sub selfRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles selfRadioButton.CheckedChanged
            Dim checkedItems As System.Collections.Generic.IEnumerable(Of System.Windows.Forms.ListViewItem)


            If selfRadioButton.Checked = False Then Exit Sub

            checkedItems = From i In userListView.Items.Cast(Of System.Windows.Forms.ListViewItem)() _
                           Where i.Checked = True _
                           Select i
            For i As Integer = checkedItems.Count() - 1 To 0 Step -1
                checkedItems(i).Checked = False
            Next

            If userListView.Items(User.UserID.ToString()) IsNot Nothing Then _
                userListView.Items(User.UserID.ToString()).Checked = True

            checkedItems = Nothing

        End Sub

        Private Sub pickfromlistRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pickfromlistRadioButton.CheckedChanged

            emailGroupBox.Enabled = pickfromlistRadioButton.Checked

        End Sub

        Private Sub requestButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles requestButton.Click
            'Dim priorityCSV, recipients As String
            'Dim tempAdapter As MCAP.ExpectationReportDataSetTableAdapters.ExpectationReportRequestTableAdapter
            'Dim tempRow As MCAP.ExpectationReportDataSet.ExpectationReportRequestRow


            'If ValidateInputs() = False Then Exit Sub

            'priorityCSV = GetPriorityCSV()
            'recipients = GetRecipients()

            'tempRow = reportDS.ExpectationReportRequest.NewExpectationReportRequestRow()
            'tempRow.Priorities = priorityCSV
            'tempRow.Recipients = recipients
            'tempRow.RequestDt = System.DateTime.Now
            'reportDS.ExpectationReportRequest.AddExpectationReportRequestRow(tempRow)

            'priorityCSV = Nothing
            'recipients = Nothing
            'tempRow = Nothing


            'tempAdapter = New MCAP.ExpectationReportDataSetTableAdapters.ExpectationReportRequestTableAdapter()
            'tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            'Try
            '    tempAdapter.Update(reportDS.ExpectationReportRequest)
            'Catch ex As System.Data.SqlClient.SqlException
            '    Trace.TraceError("ExpectationReportForm.requestButton_Click(): Error while request insertion. Message=" + ex.Message, New Object() {"PriorityCSV=", priorityCSV, "Recipients=", recipients, "RequestedOn=", System.DateTime.Now, "ErrorClass=", ex.Class, "Procedure=", ex.Procedure, "LineNumber=", ex.LineNumber, "SQLErrorNumber=", ex.State, "ErrorNumber=", ex.Number, "Source=", ex.Source})
            '    MessageBox.Show("Unable to log request for report. Error has occurred while logging request.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Catch ex As Exception
            '    Trace.TraceError("ExpectationReportForm.requestButton_Click(): Unknown error. Message=" + ex.Message, New Object() {"PriorityCSV=", priorityCSV, "Recipients=", recipients, "RequestedOn=", System.DateTime.Now})
            '    MessageBox.Show("Unable to log request for report. Unknown error has occurred while logging request.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try

            'tempAdapter.Dispose()
            'tempAdapter = Nothing

            'MessageBox.Show("Report request has been added to the queue and will be processed shortly.", ProductName _
            '                , MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

    End Class

End Namespace