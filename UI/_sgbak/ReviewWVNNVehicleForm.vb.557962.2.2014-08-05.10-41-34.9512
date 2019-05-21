Namespace UI

    Public Class ReviewWVNNVehicleForm
        Implements IForm


        Private Const FORM_NAME As String = "Review Vehicles marked as Wrong Version/Not Required"


        ''' <summary>
        ''' Loads all vehicles marked as Review.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllVehiclesMarkedAsWrongVersion(ByVal startDt As DateTime, ByVal endDt As DateTime)
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.WVNNVehiclesTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.WVNNVehiclesDataTable


            tempAdapter = New MCAP.ReportsDataSetTableAdapters.WVNNVehiclesTableAdapter()
            tempTable = New MCAP.ReportsDataSet.WVNNVehiclesDataTable()

            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.FillWrongVersionByCreateDt(tempTable, startDt, endDt)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            reviewDataGridView.DataSource = tempTable

            tempTable = Nothing

        End Sub


        ''' <summary>
        ''' Loads all Publication vehicles marked as Wrong Version Review created between specified duration.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllVehiclesMarkedAsPublicationWrongVersion(ByVal startDt As DateTime, ByVal endDt As DateTime)
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.WVNNVehiclesTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.WVNNVehiclesDataTable


            tempAdapter = New MCAP.ReportsDataSetTableAdapters.WVNNVehiclesTableAdapter()
            tempTable = New MCAP.ReportsDataSet.WVNNVehiclesDataTable()

            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.FillPublicationWrongVersion(tempTable, startDt, endDt)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            reviewDataGridView.DataSource = tempTable

            tempTable = Nothing

        End Sub

        ''' <summary>
        ''' Loads vehicles marked as Duplicate created between specified duration.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadVehiclesMarkedAsNotRequired(ByVal startDt As DateTime, ByVal endDt As DateTime)
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.WVNNVehiclesTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.WVNNVehiclesDataTable


            tempAdapter = New MCAP.ReportsDataSetTableAdapters.WVNNVehiclesTableAdapter()
            tempTable = New MCAP.ReportsDataSet.WVNNVehiclesDataTable()

            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.FillNotRequiredByCreateDt(tempTable, startDt, endDt)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            reviewDataGridView.DataSource = tempTable

            tempTable = Nothing

        End Sub

        ''' <summary>
        ''' Loads vehicle in grid.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadVehicle(ByVal vehicleId As Integer)
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.WVNNVehiclesTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.WVNNVehiclesDataTable


            tempAdapter = New MCAP.ReportsDataSetTableAdapters.WVNNVehiclesTableAdapter()
            tempTable = New MCAP.ReportsDataSet.WVNNVehiclesDataTable()

            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.FillByVehicleID(tempTable, vehicleId)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            If tempTable.Count = 1 Then
                If tempTable(0).Descrip.ToString().ToUpper() = "NOT REQUIRED" Then
                    notrequiredRadioButton.Checked = True
                ElseIf tempTable(0).Descrip.ToString().ToUpper() = "WRONG VERSION" And tempTable(0).IsRetIdNull() Then
                    WrongVerPublicationButton.Checked = True
                Else
                    wrongVersionRadioButton.Checked = True
                End If
            End If

            reviewDataGridView.DataSource = tempTable

            tempTable = Nothing

        End Sub

        ''' <summary>
        ''' Hides columns having Id values.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetDataGridViewColumns()
            Dim columnQuery As System.Collections.Generic.IEnumerable(Of DataGridViewColumn)


            columnQuery = From c In reviewDataGridView.Columns.Cast(Of DataGridViewColumn)() _
                          Where (c.Name.EndsWith("Id") = True And c.Name.ToUpper() <> "VEHICLEID") OrElse c.Name.ToUpper() = "DESCRIP" _
                          Select c
            For i As Integer = 0 To columnQuery.Count() - 1
                columnQuery(i).Visible = False
            Next

        End Sub

        ''' <summary>
        ''' Marks vehicles in array with status as Checked In. Removes DataRows from DataTable.
        ''' </summary>
        ''' <param name="vehicleIdArray"></param>
        ''' <remarks></remarks>
        Private Sub MarkVehiclesAsCheckIn(ByVal vehicleIdArray() As Integer)
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.WVNNVehiclesTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.WVNNVehiclesDataTable
            Dim tempRow As MCAP.ReportsDataSet.WVNNVehiclesRow


            tempAdapter = New MCAP.ReportsDataSetTableAdapters.WVNNVehiclesTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempTable = CType(reviewDataGridView.DataSource, ReportsDataSet.WVNNVehiclesDataTable)

            For i As Integer = 0 To vehicleIdArray.Length - 1
                If WrongVerPublicationButton.Checked = True Then
                    tempAdapter.UpdatePublicationStatus(FORM_NAME, vehicleIdArray(i), "Received")
                Else
                    tempAdapter.UpdateVehicleStatus(FORM_NAME, vehicleIdArray(i), Nothing)
                End If

                tempRow = tempTable.FindByVehicleId(vehicleIdArray(i))
                tempRow.Delete()
            Next
            tempTable.AcceptChanges()

            tempAdapter.Dispose()
            tempAdapter = Nothing
            tempTable = Nothing
            tempRow = Nothing
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

            fromTypeInDatePicker.Value = System.DateTime.Today.AddDays(-7)
            toTypeInDatePicker.Value = System.DateTime.Today

            LoadAllVehiclesMarkedAsWrongVersion(fromTypeInDatePicker.Value.Value, toTypeInDatePicker.Value.Value)
            SetDataGridViewColumns()

            RaiseEvent FormInitialized()

            Me.ResumeLayout(False)

        End Sub

#End Region


        Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

            Me.Close()

        End Sub

        Private Sub checkInButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkInButton.Click
            Dim vehicleId As Integer
            Dim userResponse As DialogResult
            Dim selectedVehicleQuery As System.Collections.Generic.IEnumerable(Of Integer)


            If Me.reviewDataGridView.SelectedRows.Count <> 1 Then
                MessageBox.Show("Select a row to mark vehicle as Check-In.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                userResponse = MessageBox.Show("Are you sure, you want to mark selected vehicle as Check-In?" _
                                               , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If

            If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

            selectedVehicleQuery = From r In reviewDataGridView.SelectedRows.Cast(Of DataGridViewRow)() _
                                   Select CType(r.Cells("VehicleId").Value, Integer)
            vehicleId = selectedVehicleQuery(0)
            MarkVehiclesAsCheckIn(selectedVehicleQuery.ToArray())

            If WrongVerPublicationButton.Checked = True Then
                Dim publicateionCheckInFrm As UI.PublicationCheckInForm = New UI.PublicationCheckInForm()
                publicateionCheckInFrm.Init(FormStateEnum.View)
                publicateionCheckInFrm.ApplyUserCredentials()
                publicateionCheckInFrm.searchTextBox.Text = vehicleId.ToString()
                publicateionCheckInFrm.Show(Me)
                publicateionCheckInFrm.gotoButton.PerformClick()
                publicateionCheckInFrm.Hide()
                publicateionCheckInFrm.ShowDialog(Me)
                publicateionCheckInFrm.Dispose()
                publicateionCheckInFrm = Nothing

            Else
                Dim vehicleCheckInFrm As UI.EnvelopeContentCheckInForm = New UI.EnvelopeContentCheckInForm()
                vehicleCheckInFrm.Init(FormStateEnum.View)
                vehicleCheckInFrm.ApplyUserCredentials()
                vehicleCheckInFrm.vehicleIdTextBox.Text = vehicleId.ToString()
                vehicleCheckInFrm.Show(Me)
                vehicleCheckInFrm.gotoButton.PerformClick()
                vehicleCheckInFrm.Hide()
                vehicleCheckInFrm.ShowDialog(Me)
                vehicleCheckInFrm.Dispose()
                vehicleCheckInFrm = Nothing

            End If
           

            selectedVehicleQuery = Nothing

        End Sub

        Private Sub notrequiredRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles notrequiredRadioButton.CheckedChanged
            checkInButton.Text = "Load in Vehicle &Check In"
            reviewDataGridView.DataSource = Nothing

        End Sub

        Private Function AreInputsValid() As Boolean

            If fromTypeInDatePicker.Value.HasValue = False OrElse toTypeInDatePicker.Value.HasValue = False Then
                MessageBox.Show("Start and End both the dates are required to filter list of vehicles.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            ElseIf fromTypeInDatePicker.Value.Value > toTypeInDatePicker.Value.Value Then
                MessageBox.Show("Provide proper date range to filter list of vehicles.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If


            Return True

        End Function

        Private Sub refreshButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles refreshButton.Click
            Dim statusMsgFrm As UI.Controls.StatusMessageForm


            If AreInputsValid() = False Then Exit Sub

            statusMsgFrm = New UI.Controls.StatusMessageForm()
            statusMsgFrm.MessageText = "Refreshing information. This may take some time, please wait....."
            statusMsgFrm.Show(Me)

            Me.StatusMessage = "Fetching latest information from database. This may take some time, please wait....."
            If wrongVersionRadioButton.Checked Then
                LoadAllVehiclesMarkedAsWrongVersion(fromTypeInDatePicker.Value.Value, toTypeInDatePicker.Value.Value)
            ElseIf notrequiredRadioButton.Checked Then
                LoadVehiclesMarkedAsNotRequired(fromTypeInDatePicker.Value.Value, toTypeInDatePicker.Value.Value)
            ElseIf WrongVerPublicationButton.Checked Then
                LoadAllVehiclesMarkedAsPublicationWrongVersion(fromTypeInDatePicker.Value.Value, toTypeInDatePicker.Value.Value)
            End If

            Me.StatusMessage = "Latest information fetched, preparing to display information on screen. This may take some time, please wait....."
            SetDataGridViewColumns()

            Me.StatusMessage = String.Empty

            statusMsgFrm.Close()
            statusMsgFrm.Dispose()
            statusMsgFrm = Nothing
        End Sub

        Private Sub vehicleIdTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles vehicleIdTextBox.KeyPress

            If Microsoft.VisualBasic.AscW(e.KeyChar) = 13 Then
                findButton.PerformClick()
            End If

        End Sub

        'Private Sub findButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles findButton.Click
        '  Dim vehicleId As Integer
        '  Dim vehicleQuery As System.Collections.Generic.IEnumerable(Of System.Windows.Forms.DataGridViewRow)

        '  If Integer.TryParse(vehicleIdTextBox.Text, vehicleId) = False Then
        '    MessageBox.Show("Provide valid vehicleId to search.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        '  ElseIf reviewDataGridView.DataSource Is Nothing Then
        '    MessageBox.Show("There is no vehicle listed at present.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        '  End If

        '  StatusMessage = "Searching for vehicle..... Please wait."
        '  vehicleQuery = From r In reviewDataGridView.Rows.Cast(Of System.Windows.Forms.DataGridViewRow)() _
        '                 Where CType(r.Cells("VehicleId").Value, Integer) = vehicleId _
        '                 Select r
        '  If vehicleQuery.Count = 0 Then
        '    MessageBox.Show("Cannot find vehicle.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '  Else
        '    StatusMessage = "Selecting vehicle row on screen..... Please wait."
        '    For i As Integer = reviewDataGridView.SelectedRows.Count - 1 To 0 Step -1
        '      reviewDataGridView.SelectedRows(i).Selected = False
        '    Next
        '    vehicleQuery(0).Selected = True
        '  End If
        '  StatusMessage = String.Empty

        'End Sub

        Private Sub findButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles findButton.Click
            Dim vehicleId As Integer


            If Integer.TryParse(vehicleIdTextBox.Text, vehicleId) = False Then
                MessageBox.Show("Provide valid vehicle Id to search for.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            LoadVehicle(vehicleId)

        End Sub

        Private Sub WrongVerPublicationButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WrongVerPublicationButton.CheckedChanged
            reviewDataGridView.DataSource = Nothing
            checkInButton.Text = "Load in Publication Check-in"

        End Sub

        Private Sub wrongVersionRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles wrongVersionRadioButton.CheckedChanged
            reviewDataGridView.DataSource = Nothing
            checkInButton.Text = "Load in Vehicle &Check In"
        End Sub
    End Class


End Namespace