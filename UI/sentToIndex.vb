
Namespace UI

    Public Class sentToIndex

        Implements IForm

        Private Const FORM_NAME As String = "Vehicle Send to Indexing from Report"
        Private fromDate As DateTime
        Private toDate As DateTime

        ''' <summary>
        ''' Loads all vehicles marked as Review.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllVehiclesPushtoIndex(ByVal startDate As DateTime, ByVal endDate As DateTime)
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.VehiclesDataTable


            tempAdapter = New MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter()
            tempTable = New MCAP.ReportsDataSet.VehiclesDataTable()

            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.FillForPushtoIndex(tempTable, startDate, endDate)
            tempAdapter.Dispose()
            tempAdapter = Nothing

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

            fromDate = fromTypeInDatePicker.Value.Value
            toDate = toTypeInDatePicker.Value.Value

            LoadAllVehiclesPushtoIndex(fromDate, toDate)
            SetDataGridViewColumns()

            RaiseEvent FormInitialized()

            Me.ResumeLayout(False)
            '' getComboData()

        End Sub

#End Region

        Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
            Me.Hide()
        End Sub

        Private Sub refreshButton_Click(sender As Object, e As EventArgs)
            Dim statusMsgFrm As UI.Controls.StatusMessageForm

            fromDate = fromTypeInDatePicker.Value.Value
            toDate = toTypeInDatePicker.Value.Value.AddDays(1)
            LoadAllVehiclesPushtoIndex(fromDate, toDate)


            Me.StatusMessage = "Latest information fetched, preparing to display information on screen. This may take some time, please wait....."
            SetDataGridViewColumns()



        End Sub

        Private Sub refreshButton_Click_1(sender As Object, e As EventArgs) Handles refreshButton.Click

        End Sub
    End Class

End Namespace