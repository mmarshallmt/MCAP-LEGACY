Namespace UI

    Public Class ReviewVehicleForm
        Implements IForm

        Private Const FORM_NAME As String = "Review Vehicle"


        ''' <summary>
        ''' Loads all vehicles marked as Review.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllVehiclesMarkedAsReview()
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.VehiclesDataTable


            tempAdapter = New MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter()
            tempTable = New MCAP.ReportsDataSet.VehiclesDataTable()

            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.FillForReview(tempTable)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            reviewDataGridView.DataSource = tempTable

            tempTable = Nothing

        End Sub

        ''' <summary>
        ''' Loads vehicles marked as Duplicate created between specified duration.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadVehiclesMarkedAsDuplicate(ByVal startDt As DateTime, ByVal endDt As DateTime)
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.VehiclesDataTable


            tempAdapter = New MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter()
            tempTable = New MCAP.ReportsDataSet.VehiclesDataTable()

            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.FillDuplicatesBySaleDt(tempTable, startDt, endDt)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            reviewDataGridView.DataSource = tempTable

            tempTable = Nothing

        End Sub

        ''' <summary>
        ''' Loads vehicle in grid.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadVehicle(ByVal vehicleId As Integer, ByVal retId As Integer, ByVal descrip As String, ByVal startDt As DateTime, ByVal endDt As DateTime)
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.VehiclesDataTable


            tempAdapter = New MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter()
            tempTable = New MCAP.ReportsDataSet.VehiclesDataTable()

            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            tempAdapter.Fill(tempTable, retId, vehicleId, descrip, startDt, endDt)

            tempAdapter.Dispose()
            tempAdapter = Nothing

            If tempTable.Count = 1 Then
                If tempTable(0).Descrip.ToString().ToUpper() = "DUPLICATE" Then
                    duplicateRadioButton.Checked = True
                Else
                    reviewRadioButton.Checked = True
                End If
            End If


            reviewDataGridView.DataSource = tempTable

            tempTable.Dispose()
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
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.VehiclesDataTable
            Dim tempRow As MCAP.ReportsDataSet.VehiclesRow


            tempAdapter = New MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempTable = CType(reviewDataGridView.DataSource, ReportsDataSet.VehiclesDataTable)

            For i As Integer = 0 To vehicleIdArray.Length - 1
                tempAdapter.UpdateVehicleStatus(FORM_NAME, vehicleIdArray(i), Nothing, Nothing)
                tempRow = tempTable.FindByVehicleId(vehicleIdArray(i))
                tempRow.Delete()
            Next
            tempTable.AcceptChanges()

            tempAdapter.Dispose()
            tempAdapter = Nothing
            tempTable = Nothing
            tempRow = Nothing
        End Sub

        ''' <summary>
        ''' Marks vehicles in array with status as Duplicate. Removes DataRows from DataTable.
        ''' </summary>
        ''' <param name="vehicleIdArray"></param>
        ''' <remarks></remarks>
        Private Sub MarkVehiclesAsDuplicate(ByVal vehicleIdArray() As Integer)
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.VehiclesDataTable
            Dim tempRow As MCAP.ReportsDataSet.VehiclesRow


            tempAdapter = New MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempTable = CType(reviewDataGridView.DataSource, ReportsDataSet.VehiclesDataTable)

            For i As Integer = 0 To vehicleIdArray.Length - 1
                tempAdapter.UpdateVehicleStatus(FORM_NAME, vehicleIdArray(i), "Duplicate", User.UserID)
                tempRow = tempTable.FindByVehicleId(vehicleIdArray(i))
                tempRow.Delete()
            Next
            tempTable.AcceptChanges()

            tempAdapter.Dispose()
            tempAdapter = Nothing
            tempTable = Nothing
            tempRow = Nothing
        End Sub

        ''' <summary>
        ''' Marks vehicles in array with status as Review. Removes DataRows from DataTable.
        ''' </summary>
        ''' <param name="vehicleIdArray"></param>
        ''' <remarks></remarks>
        Private Sub MarkVehiclesForReview(ByVal vehicleIdArray() As Integer)
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.VehiclesDataTable
            Dim tempRow As MCAP.ReportsDataSet.VehiclesRow


            tempAdapter = New MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempTable = CType(reviewDataGridView.DataSource, ReportsDataSet.VehiclesDataTable)

            For i As Integer = 0 To vehicleIdArray.Length - 1
                tempAdapter.UpdateVehicleStatus(FORM_NAME, vehicleIdArray(i), "Review", Nothing)
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

            LoadAllVehiclesMarkedAsReview()
            SetDataGridViewColumns()

            fromTypeInDatePicker.Value = System.DateTime.Today.AddDays(-7)
            toTypeInDatePicker.Value = System.DateTime.Today

            RaiseEvent FormInitialized()

            Me.ResumeLayout(False)
            getComboData()

        End Sub

#End Region


        Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

            Me.Close()

        End Sub

        Private Sub checkInButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkInButton.Click
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

            MarkVehiclesAsCheckIn(selectedVehicleQuery.ToArray())

            selectedVehicleQuery = Nothing

        End Sub

        Private Sub checkInAndIndexButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkInAndIndexButton.Click
            Dim userResponse As DialogResult
            Dim vehicleId As Integer
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
            selectedVehicleQuery = Nothing

            Dim indexFrm As UI.IndexForm = New UI.IndexForm()

            indexFrm.Init(FormStateEnum.Insert)
            indexFrm.findVehicleIdTextBox.Text = vehicleId.ToString()
            indexFrm.LoadVehicle()
            indexFrm.ShowDialog(Me)
            indexFrm.Dispose()
            indexFrm = Nothing
        End Sub

        Private Sub duplicateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles duplicateButton.Click
            Dim userResponse As DialogResult
            Dim selectedVehicleQuery As System.Collections.Generic.IEnumerable(Of Integer)


            If Me.reviewRadioButton.Checked Then
                If Me.reviewDataGridView.SelectedRows.Count <> 1 Then
                    MessageBox.Show("Select a row to mark vehicle as Duplicate.", ProductName _
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    userResponse = MessageBox.Show("Are you sure, you want to mark selected vehicle(s) as Duplicate?" _
                                                   , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                End If
            Else
                If Me.reviewDataGridView.SelectedRows.Count <> 1 Then
                    MessageBox.Show("Select a row to mark vehicle for Review.", ProductName _
                                    , MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    userResponse = MessageBox.Show("Are you sure, you want to mark selected vehicle(s) for Review?" _
                                                   , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                End If
            End If

            If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

            selectedVehicleQuery = From r In reviewDataGridView.SelectedRows.Cast(Of DataGridViewRow)() _
                                   Select CType(r.Cells("VehicleId").Value, Integer)

            If Me.reviewRadioButton.Checked Then
                MarkVehiclesAsDuplicate(selectedVehicleQuery.ToArray())
            Else
                MarkVehiclesForReview(selectedVehicleQuery.ToArray())
            End If

            selectedVehicleQuery = Nothing

        End Sub

        Private Sub duplicateRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles duplicateRadioButton.CheckedChanged
            Dim showControls As Boolean = Me.duplicateRadioButton.Checked


            reviewDataGridView.DataSource = Nothing

            Me.fromLabel.Visible = showControls
            Me.fromTypeInDatePicker.Visible = showControls
            Me.toLabel.Visible = showControls
            Me.toTypeInDatePicker.Visible = showControls

            duplicatecheckButton.Enabled = Not showControls
            checkInButton.Enabled = Not showControls
            checkInAndIndexButton.Enabled = Not showControls
            CheckInAllButton.Enabled = Not showControls

            If showControls Then
                duplicateButton.Text = "Review"
            Else
                duplicateButton.Text = "Duplicate"
            End If

        End Sub

        Private Function AreInputsValid() As Boolean
            Dim vehicleId As Integer


            If duplicateRadioButton.Checked Then
                If fromTypeInDatePicker.Value.HasValue = False OrElse toTypeInDatePicker.Value.HasValue = False Then
                    MessageBox.Show("Start and End both the dates are required to filter list of vehicles.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                ElseIf fromTypeInDatePicker.Value.Value > toTypeInDatePicker.Value.Value Then
                    MessageBox.Show("Provide proper date range to filter list of vehicles.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            End If

            If vehicleIdTextBox.Text.Trim().Length > 0 AndAlso Integer.TryParse(vehicleIdTextBox.Text, vehicleId) = False Then
                MessageBox.Show("Provide valid vehicle Id.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            If reviewRadioButton.Checked Then
                LoadAllVehiclesMarkedAsReview()
            Else
                LoadVehiclesMarkedAsDuplicate(fromTypeInDatePicker.Value.Value, toTypeInDatePicker.Value.Value)
            End If

            Me.StatusMessage = "Latest information fetched, preparing to display information on screen. This may take some time, please wait....."
            SetDataGridViewColumns()

            Me.StatusMessage = String.Empty

            statusMsgFrm.Close()
            statusMsgFrm.Dispose()
            statusMsgFrm = Nothing
        End Sub

        Private Sub duplicatecheckButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles duplicatecheckButton.Click
            Dim vehicleId As Integer
            Dim dupCheckResult As DuplicateCheckUserResponse
            Dim tempTable As ReportsDataSet.VehiclesDataTable
            Dim vehicleQuery As System.Collections.Generic.IEnumerable(Of ReportsDataSet.VehiclesRow)


            If reviewDataGridView.SelectedRows.Count <> 1 Then
                MessageBox.Show("Select one vehicle to check for possible duplication.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Integer.TryParse(reviewDataGridView.SelectedRows(0).Cells("VehicleId").Value.ToString(), vehicleId) = False Then
                MessageBox.Show("Cannot check for possible duplicate. Unable to identify vehicleId of the selected vehicle.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            tempTable = CType(reviewDataGridView.DataSource, ReportsDataSet.VehiclesDataTable)
            vehicleQuery = From v In tempTable _
                           Where v.VehicleId = vehicleId _
                           Select v

            dupCheckResult = CheckForDuplication(vehicleQuery(0))

            If dupCheckResult = DuplicateCheckUserResponse.NoPossibleDuplidates Then
                MessageBox.Show("No possible duplicate vehicle found.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf dupCheckResult = DuplicateCheckUserResponse.Duplicate Then
                MarkVehiclesAsDuplicate(New Integer() {vehicleQuery(0).VehicleId})
            ElseIf dupCheckResult = DuplicateCheckUserResponse.Closed Then
                MarkVehiclesForReview(New Integer() {vehicleQuery(0).VehicleId})
            ElseIf dupCheckResult = DuplicateCheckUserResponse.Override Then
                Dim userResponse As System.Windows.Forms.DialogResult

                userResponse = MessageBox.Show("Vehicle " + vehicleQuery(0).VehicleId.ToString() + " is going to be marked as Checked In. Do you want to Index this vehicle now?", ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If userResponse = Windows.Forms.DialogResult.No Then
                    checkInButton.PerformClick()
                Else
                    checkInAndIndexButton.PerformClick()
                End If

            End If

            tempTable = Nothing
            vehicleQuery = Nothing

        End Sub


        ''' <summary>
        ''' Checks for possible duplicate records in Vehicle table. If found shows records to user 
        ''' for further action.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckForDuplication(ByVal vehicleRow As ReportsDataSet.VehiclesRow) As DuplicateCheckUserResponse
            Dim userResponse As DialogResult
            Dim languageId As Nullable(Of Integer), startDt As DateTime, endDt As DateTime
            Dim mediaList As System.Collections.Generic.List(Of String)
            Dim possibleDupVehicles As UI.DupCheckForm


            mediaList = New System.Collections.Generic.List(Of String)
            If vehicleRow.IsLanguageIdNull() Then
                languageId = Nothing
            Else
                languageId = vehicleRow.LanguageId
            End If
            If vehicleRow.IsStart_DateNull() Then
                startDt = Nothing
            Else
                startDt = vehicleRow.Start_Date
            End If
            If vehicleRow.IsEnd_DateNull() Then
                endDt = Nothing
            Else
                endDt = vehicleRow.End_Date
            End If

      Select Case vehicleRow.Media.ToUpper()
        Case "FSI"
          mediaList.Clear()
          mediaList.Add("FSI")
          possibleDupVehicles = New UI.DupCheckForm(vehicleRow.RetId, vehicleRow.MktId, vehicleRow.Ad_Date, mediaList, languageId, True, FORM_NAME)
        Case "ROP"
          mediaList.Clear()
          mediaList.Add("ROP")
          possibleDupVehicles = New UI.DupCheckForm(vehicleRow.RetId, vehicleRow.MktId, vehicleRow.PublicationId, vehicleRow.Ad_Date, mediaList, languageId, True, FORM_NAME)

                Case "CATALOG", "IN-STORE", "INSERT", "MAILER", "ROP - CIRCULAR", "MONTHLY BOOKLET",
                    "PICK-UP IN-STORE", "INTERNET", "INSERT-DIGITAL", "IN-STORE-DIGITAL", "MAILER-DIGITAL",
                        "INSERT-AC PAPER", "INSERT-AC DIGITAL", "IN-STORE-AC DIGITAL"
                    mediaList.Clear()
                    mediaList.Add("Catalog")
                    mediaList.Add("In-Store")
                    mediaList.Add("Insert")
                    mediaList.Add("Mailer")
                    mediaList.Add("Internet")
                    mediaList.Add("ROP - Circular")
                    mediaList.Add("Monthly Booklet")
                    mediaList.Add("Pick-Up In-Store")
                    mediaList.Add("Insert-Digital")
                    mediaList.Add("In-Store-Digital")
                    mediaList.Add("Mailer-Digital")
                    mediaList.Add("Insert-AC Paper")
                    mediaList.Add("Insert-AC Digital")
                    mediaList.Add("In-Store-AC Digital")
                    possibleDupVehicles = New UI.DupCheckForm(vehicleRow.RetId, vehicleRow.MktId, vehicleRow.Ad_Date, mediaList, startDt, endDt, languageId, True, FORM_NAME)
                    If vehicleRow.Media.ToUpper() = "CATALOG" Then
                        possibleDupVehicles.dateRangeNumericUpDown.Value = 14
                    Else
                        possibleDupVehicles.dateRangeNumericUpDown.Value = 5
                    End If

        Case Else
          mediaList.Clear()
          mediaList.Add(vehicleRow.Media.ToUpper())
          possibleDupVehicles = New UI.DupCheckForm(vehicleRow.RetId, vehicleRow.MktId, vehicleRow.Ad_Date, mediaList, startDt, endDt, languageId, True, FORM_NAME)
          possibleDupVehicles.dateRangeNumericUpDown.Value = 5

      End Select

            mediaList.Clear()
            mediaList = Nothing

            possibleDupVehicles.RemoveVehicle = vehicleRow.VehicleId
            possibleDupVehicles.Init(FormStateEnum.View)
            If possibleDupVehicles.IsPossibleDuplicateRecordsFound Then
                possibleDupVehicles.ApplyUserCredentials()
                possibleDupVehicles.reviewButton.Enabled = False
                userResponse = possibleDupVehicles.ShowDialog(Me)
            Else
                userResponse = Windows.Forms.DialogResult.OK
                CheckForDuplication = DuplicateCheckUserResponse.NoPossibleDuplidates
            End If

            If userResponse = Windows.Forms.DialogResult.Cancel Then
                CheckForDuplication = DuplicateCheckUserResponse.Closed
            ElseIf possibleDupVehicles.IsOverride And userResponse = Windows.Forms.DialogResult.OK Then
                CheckForDuplication = DuplicateCheckUserResponse.Override
            ElseIf possibleDupVehicles.IsReview And userResponse = Windows.Forms.DialogResult.OK Then
                CheckForDuplication = DuplicateCheckUserResponse.Review
            ElseIf possibleDupVehicles.IsDuplicate And userResponse = Windows.Forms.DialogResult.OK Then
                CheckForDuplication = DuplicateCheckUserResponse.Duplicate
            End If

            possibleDupVehicles.Dispose()
            possibleDupVehicles = Nothing

        End Function

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
            Dim RetId As Integer
            Dim descrip As String = "all"
            Dim dt As New DataTable()

            If vehicleIdTextBox.Text.Trim().Length > 0 Or RetailerCombo.SelectedIndex >= 0 Then

                If vehicleIdTextBox.Text.Trim().Length > 0 Then
                    If Not IsNumeric(vehicleIdTextBox.Text.Trim()) Then
                        MessageBox.Show("Provide valid vehicle Id to search for.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    Else
                        Integer.TryParse(vehicleIdTextBox.Text, vehicleId)
                    End If

                Else
                    vehicleId = 0
                End If

                If RetailerCombo.SelectedIndex < 0 Then
                    RetId = 0

                Else
                    Integer.TryParse(RetailerCombo.SelectedValue.ToString(), RetId)
                    If reviewRadioButton.Checked Then
                        descrip = "Review"
                    Else
                        descrip = "Duplicate"
                    End If

                End If

                LoadVehicle(vehicleId, RetId, descrip, fromTypeInDatePicker.Value.Value, toTypeInDatePicker.Value.Value)


                'If Integer.TryParse(vehicleIdTextBox.Text, vehicleId) = False Integer.TryParse(RetailerCombo.SelectedValue.ToString(), RetId) = False Then
                '    MessageBox.Show("Provide valid vehicle Id OR Retailer to search for.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Exit Sub
                'End If
            Else
                MessageBox.Show("Provide valid vehicle Id or Retailer to search for.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub

            End If


        End Sub


        Private Sub getComboData()
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.RetTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.RetDataTable

            tempAdapter = New MCAP.ReportsDataSetTableAdapters.RetTableAdapter()
            tempTable = New MCAP.ReportsDataSet.RetDataTable()


            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(tempTable)

            tempAdapter.Dispose()
            tempAdapter = Nothing

            RetailerCombo.DataSource = tempTable
            RetailerCombo.SelectedValue = DBNull.Value

            tempTable = Nothing

        End Sub


        Private Sub CheckInAllButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckInAllButton.Click

            Dim userResponse As DialogResult
            Dim selectedVehicleQuery As System.Collections.Generic.IEnumerable(Of Integer)


            If Me.reviewDataGridView.Rows.Count < 1 Then
                MessageBox.Show("No Record available.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                userResponse = MessageBox.Show("Are you sure, you want to mark all displayed vehicle as Check-In?" _
                                               , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If

            If userResponse = Windows.Forms.DialogResult.No Then Exit Sub


            selectedVehicleQuery = From r In reviewDataGridView.Rows.Cast(Of DataGridViewRow)() _
                          Select CType(r.Cells("VehicleId").Value, Integer)

            'selectedVehicleQuery = From r In reviewDataGridView.SelectedRows.Cast(Of DataGridViewRow)() _
            '                   Select CType(r.Cells("VehicleId").Value, Integer)

            MarkVehiclesAsCheckIn(selectedVehicleQuery.ToArray())

            selectedVehicleQuery = Nothing


        End Sub

        Private Sub RetailerCombo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RetailerCombo.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub


        Private Sub RetailerCombo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetailerCombo.SelectedIndexChanged

        End Sub
    End Class



End Namespace