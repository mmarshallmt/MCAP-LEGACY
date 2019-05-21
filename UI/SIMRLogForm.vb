Namespace UI

    Public Class SIMRLogForm

        Implements IForm

        ''' <summary>
        ''' This constant is used to assigning value to FormName column.


        Private m_previousSelection As SearchCriteria
        Private WithEvents m_RequiredProcessor As Processors.RequiredProcess


        ''' <summary>
        ''' Gets processor.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property Processor() As Processors.RequiredProcess
            Get
                Return m_RequiredProcessor
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

            Me.SuspendLayout()

            RaiseEvent InitializingForm()
            ' Me.FormState = formStatus
            m_RequiredProcessor = New Processors.RequiredProcess
            Processor.Initialize()
           
            Dim retId As Integer = 0
            Dim mktid As Integer = 0
            Dim SenderId As Integer = 0

            startdateTypeInDatePicker.Value = System.DateTime.Today.AddDays(-7)
            enddateTypeInDatePicker.Value = System.DateTime.Today

            fromDate = startdateTypeInDatePicker.Value.Value
            toDate = enddateTypeInDatePicker.Value.Value

            Processor.FillMarket()
            Processor.RetailerAdapter.Fill(Processor.Data.Ret)
            Processor.SimrSenderAdapter.Fill(Processor.Data.SimrSender)

            With marketComboBox
                .DisplayMember = "Descrip"
                .ValueMember = "mktid"
                .DataSource = Processor.Data.Mkt
                .SelectedValue = -1
            End With
            With retailerComboBox
                .DisplayMember = "Descrip"
                .ValueMember = "RetId"
                .DataSource = Processor.Data.Ret
                .SelectedValue = DBNull.Value
            End With
            With SenderComboBox
                .DisplayMember = "Name"
                .ValueMember = "Senderid"
                .DataSource = Processor.Data.SimrSender
                .SelectedValue = -1
            End With

            LoadAllVehiclesFromSimr(fromDate, toDate, mktid, retId, SenderId)
            SetDataGridViewColumns()

            RaiseEvent FormInitialized()

            Me.ResumeLayout(False)
            '' getComboData()

        End Sub

#End Region

        Private Const FORM_NAME As String = "SIMR Report"
        Private fromDate As DateTime
        Private toDate As DateTime

        ''' <summary>
        ''' Loads all vehicles marked as Review.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllVehiclesFromSimr(ByVal startDate As DateTime, ByVal endDate As DateTime, mktid As Integer, retid As Integer, senderid As Integer)
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.SimrReportTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.SimrReportDataTable
            Try

                tempAdapter = New MCAP.ReportsDataSetTableAdapters.SimrReportTableAdapter
                SetAllCommandTimeouts(tempAdapter, 60000)
                tempTable = New MCAP.ReportsDataSet.SimrReportDataTable

                tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
                tempAdapter.FillSimrByDate(tempTable, startDate, endDate, mktid, retid, senderid)
                tempAdapter.Dispose()
                tempAdapter = Nothing

                reviewDataGridView.DataSource = tempTable

                tempTable = Nothing
            Catch ex As TimeoutException

            End Try

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

        Private Sub clearForm()

            startdateTypeInDatePicker.Value = System.DateTime.Today.AddDays(-7)
            enddateTypeInDatePicker.Value = System.DateTime.Today
           
            retailerComboBox.SelectedValue = -1
            marketComboBox.SelectedValue = -1
            SenderComboBox.SelectedValue = -1

            reviewDataGridView.DataSource = Nothing
        End Sub

        Private Sub searchButton_Click(sender As Object, e As EventArgs) Handles searchButton.Click

            Dim startDate As DateTime
            Dim endDate As DateTime
            Dim retId As Integer
            Dim mktid As Integer
            Dim SenderId As Integer

            'Dim cstZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")
            'Dim cstTime As DateTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone)

            If startdateTypeInDatePicker.Value.HasValue = False Then
                MessageBox.Show("Start date is mandatory to initiate search.", _
                                ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            If marketComboBox.SelectedValue Is Nothing OrElse marketComboBox.SelectedValue Is DBNull.Value Then
                mktid = 0
            Else
                mktid = CType(marketComboBox.SelectedValue, Integer)
            End If

            If retailerComboBox.SelectedValue Is Nothing OrElse retailerComboBox.SelectedValue Is DBNull.Value Then
                retId = 0
            Else
                retId = CType(retailerComboBox.SelectedValue, Integer)
            End If

            If SenderComboBox.SelectedValue Is Nothing OrElse SenderComboBox.SelectedValue Is DBNull.Value Then
                SenderId = 0
            Else
                SenderId = CType(SenderComboBox.SelectedValue, Integer)
            End If


            startDate = startdateTypeInDatePicker.Value.Value
            endDate = enddateTypeInDatePicker.Value.Value

            LoadAllVehiclesFromSimr(startDate, endDate, mktid, retId, SenderId)
        End Sub

        Private Sub resetButton_Click(sender As Object, e As EventArgs) Handles resetButton.Click
            clearForm()
        End Sub

        Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
            Me.Hide()
        End Sub
    End Class
End Namespace