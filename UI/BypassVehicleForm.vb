Namespace UI

    Public Class BypassVehicleForm

        Implements IForm

        Private m_DataSet As MCAP.BypassVehicleDataSet
        Private m_reportFilterCriteria, m_reportTitle, m_condition As String

        Private ReadOnly Property Data() As MCAP.BypassVehicleDataSet
            Get
                Return m_DataSet
            End Get
        End Property

        Private ReadOnly Property ReportTitle() As String
            Get
                Return m_reportTitle
            End Get
        End Property

        Private ReadOnly Property FilterCriteria() As String
            Get
                Return m_reportFilterCriteria
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

            RaiseEvent InitializingForm()

            Me.SuspendLayout()

            m_DataSet = New BypassVehicleDataSet()

            LoadDataSet()

            locationComboBox.DisplayMember = "Descrip"
            locationComboBox.ValueMember = "CodeId"
            locationComboBox.DataSource = Me.Data.vwLocation
            If User.LocationId = 58 Then
                locationComboBox.SelectedValue = 0
            Else
                locationComboBox.SelectedValue = User.LocationId
            End If


            startdateTypeInDatePicker.Value = System.DateTime.Today.AddMonths(-1)
            enddateTypeInDatePicker.Value = System.DateTime.Today


            Me.ResumeLayout()

            RaiseEvent FormInitialized()

        End Sub

#End Region

        Private Sub LoadDataSet()
            Dim tempAdapter As BypassVehicleDataSetTableAdapters.vwLocationTableAdapter
            Dim tempRow As BypassVehicleDataSet.vwLocationRow


            tempAdapter = New BypassVehicleDataSetTableAdapters.vwLocationTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(Data.vwLocation)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            tempRow = Data.vwLocation.NewvwLocationRow()
            tempRow.CodeId = 0
            tempRow.Descrip = "All"
            Data.vwLocation.AddvwLocationRow(tempRow)
            tempRow = Nothing


        End Sub

        Private Function AreInputsValid() As Boolean
            Dim validatedSuccessfully As Boolean = True


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

            If locationComboBox.SelectedValue Is Nothing Then
                SetErrorProvider(locationComboBox, "Select location from drop down list.")
                validatedSuccessfully = False
            Else
                RemoveErrorProvider(locationComboBox)
            End If

            Return validatedSuccessfully

        End Function

        Private Sub LoadDataForBypassVehicle()
            Dim locationId As Integer
            Dim startDt, endDt As DateTime
            Dim tempAdapter As BypassVehicleDataSetTableAdapters.BypassVehicleTableAdapter


            If startdateTypeInDatePicker.Value.HasValue = False _
              OrElse enddateTypeInDatePicker.Value.HasValue = False _
              OrElse locationComboBox.SelectedValue Is Nothing _
            Then
                Exit Sub
            ElseIf Integer.TryParse(locationComboBox.SelectedValue.ToString(), locationId) = False Then
                locationId = -1
            End If

            If locationId < 0 Then
                MessageBox.Show("Select location from drop down list.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            startDt = startdateTypeInDatePicker.Value.Value
            'This is done to overcome DateTime comparision issue due to the Time part in DateTime data type. 
            '01/01/01' is less than '01/01/01 12:00:01 AM'. So, between operator always ignore time stamps
            'having date same as end date due to that time part in DateTime datatype.
            endDt = enddateTypeInDatePicker.Value.Value.AddDays(1)

           

            tempAdapter = New BypassVehicleDataSetTableAdapters.BypassVehicleTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            m_reportTitle = "Bypass Vehicle Report"
            If locationId = 0 Then
                tempAdapter.FillByDateRange(Data.BypassVehicle _
                                                                              , startDt _
                                                                              , endDt _
                                                                             )

            Else

                tempAdapter.FillByDateRangeLoication(Data.BypassVehicle _
                                                               , startDt _
                                                               , endDt _
                                                               , locationId)
            End If
            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub

        Private Sub SetReportParametersForBypassVehicle()
            Dim filterCriteria As System.Text.StringBuilder


            filterCriteria = New System.Text.StringBuilder()

            If startdateTypeInDatePicker.Value.HasValue Then
                filterCriteria.Append("Start date: ")
                filterCriteria.Append(startdateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy"))
            End If

            If enddateTypeInDatePicker.Value.HasValue Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("End date: ")
                filterCriteria.Append(enddateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy"))
            End If

            If locationComboBox.SelectedValue IsNot Nothing Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Location: ")
                filterCriteria.Append(locationComboBox.Text)
            End If

            m_reportFilterCriteria = filterCriteria.ToString()

            filterCriteria.Remove(0, filterCriteria.Length)
            filterCriteria = Nothing

        End Sub

        Private Sub generateReportButton_Click(sender As Object, e As EventArgs) Handles generateReportButton.Click
            Dim reportForm As ShowReportForm
            Dim strCondition As System.Text.StringBuilder
            Dim PreviousVal As Integer

            strCondition = New System.Text.StringBuilder

            m_condition = strCondition.ToString
            If AreInputsValid() = False Then Exit Sub

            reportForm = New ShowReportForm()

            LoadDataForBypassVehicle()
            SetReportParametersForBypassVehicle()

            reportForm.ReportFileResourceName = "MCAP.BypassVehicleReports.rdlc"
            reportForm.DataSources.Add("BypassVehicleDataSet_BypassVehicle", Data.BypassVehicle)
            reportForm.ReportName = "Bypass Vehicle Report"

            reportForm.Parameters.Add("ReportTitle", ReportTitle)
            reportForm.Parameters.Add("FilterCriteria", FilterCriteria)

            reportForm.PrepareReport()

            If screenRadioButton.Checked Then
                reportForm.RefreshReport()
                reportForm.WindowState = FormWindowState.Maximized
                reportForm.ShowDialog(Me)

            Else
                reportForm.ExportReportToExcel(System.IO.Path.GetTempFileName())
            End If

            reportForm.Dispose()
            reportForm = Nothing
        End Sub

        Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
            Me.Close()
        End Sub

        Private Sub BypassVehicleForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            RaiseEvent InitializingForm()

            Me.SuspendLayout()

            m_DataSet = New BypassVehicleDataSet()

            LoadDataSet()

            locationComboBox.DisplayMember = "Descrip"
            locationComboBox.ValueMember = "CodeId"
            locationComboBox.DataSource = Me.Data.vwLocation
            If User.LocationId = 58 Then
                locationComboBox.SelectedValue = 0
            Else
                locationComboBox.SelectedValue = User.LocationId
            End If


            startdateTypeInDatePicker.Value = System.DateTime.Today.AddMonths(-1)
            enddateTypeInDatePicker.Value = System.DateTime.Today


            Me.ResumeLayout()

            RaiseEvent FormInitialized()
        End Sub
    End Class

End Namespace