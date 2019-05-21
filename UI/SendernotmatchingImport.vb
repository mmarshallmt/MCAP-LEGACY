Namespace UI
    Public Class SendernotmatchingImport
        Implements IForm


#Region "Properties"
        Public AddMappingobj As New Processors.AddrMapping
        Private ACRetdt As New System.Data.DataTable()
        Private MTRetdt As New System.Data.DataTable()
        Private MTMktDT As New System.Data.DataTable()
        Private ImportTypedt As New System.Data.DataTable()

#End Region

#Region " IForm Implementation "

        Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
        Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied
        Public Event InitializingForm() Implements IForm.InitializingForm
        Public Event FormInitialized() Implements IForm.FormInitialized




#End Region

        Private m_DataSet As New CompareACImportTypeReport
        Private m_reportFilterCriteria, m_reportTitle, m_condition As String


        Private ReadOnly Property Data() As CompareACImportTypeReport
            Get
                Return m_DataSet
            End Get
        End Property

        Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials
        End Sub
        Public Sub Init(formStatus As FormStateEnum) Implements IForm.Init
        End Sub
        Private Sub SendernotmatchingImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            LoadMedia()
            LoadFilters()
        End Sub
        Private Sub LoadMedia()
            Dim tempAdapter As CompareACImportTypeReportTableAdapters.MediaTableAdapter
            tempAdapter = New CompareACImportTypeReportTableAdapters.MediaTableAdapter

            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(Data.Media)
            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub

        Private Sub LoadFilters()
            Dim dsfilter As DataSet = AddMappingobj.GetAddressFilters()
            ACRetdt = dsfilter.Tables(0)
            Dim ACRetdr As DataRow = ACRetdt.NewRow()
            ACRetdr("company_nm") = ""
            ACRetdr("retailer_i") = -1
            ACRetdt.Rows.InsertAt(ACRetdr, 0)


            MTRetdt = dsfilter.Tables(1)
            Dim MTRetdr As DataRow = MTRetdt.NewRow()
            MTRetdr("Descrip") = ""
            MTRetdr("RetID") = -1
            MTRetdt.Rows.InsertAt(MTRetdr, 0)

            With MTRetComboBox
                .DataSource = MTRetdt
                .DisplayMember = "Descrip"
                .ValueMember = "RetID"
            End With

            MTMktDT = dsfilter.Tables(2)
            Dim MTMktdr As DataRow = MTMktDT.NewRow()
            MTMktdr("Descrip") = ""
            MTMktdr("MktID") = -1
            MTMktDT.Rows.InsertAt(MTMktdr, 0)

            With MTMktComboBox
                .DataSource = MTMktDT
                .DisplayMember = "Descrip"
                .ValueMember = "MktID"
            End With

            ImportTypedt = dsfilter.Tables(3)
            With PhaseTypeComboBox
                .DataSource = ImportTypedt
                .DisplayMember = "CodeType"
                .ValueMember = "codeID"
            End With


            With MediaTypeComboBox
                .DataSource = Data.Media
                .DisplayMember = "Descrip"
                .ValueMember = "MediaID"
                .SelectedValue = 26
            End With
        End Sub



        Private Sub generateReportButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles generateReportButton.Click
            Dim reportForm As ShowReportForm


            If Not startdateTypeInDatePicker.Value.HasValue Then
                MessageBox.Show("Please selecte a start date ")
                Exit Sub
            End If
            If Not enddateTypeInDatePicker.Value.HasValue Then
                MessageBox.Show("Please selecte a End date")
                Exit Sub
            End If

            'If MediaTypeComboBox.SelectedIndex = 0 Then
            '    MessageBox.Show("Please selecte a Media type for this report")
            '    Exit Sub
            'End If

            'If PhaseTypeComboBox.SelectedIndex = -1 Or MTRetComboBox.SelectedIndex = -1 Or MTMktComboBox.SelectedIndex = -1 Then
            '    MessageBox.Show("Current selection is not available")
            '    Exit Sub
            'End If

            'If MTRetComboBox.SelectedIndex = 0 And PhaseTypeComboBox.SelectedIndex < 0 And MTMktComboBox.SelectedIndex = 0 Then
            '    MsgBox("Please select a Import Type", MsgBoxStyle.Information, "Load")
            '    PhaseTypeComboBox.Focus()
            '    Exit Sub
            'End If

            Dim tempAdapter As CompareACImportTypeReportTableAdapters.CompareACImportTypeReportTableAdapter
            tempAdapter = New CompareACImportTypeReportTableAdapters.CompareACImportTypeReportTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            ''valid required fields
            '' tempAdapter.Fill(Data._CompareACImportTypeReport, startdateTypeInDatePicker.Value, enddateTypeInDatePicker.Value, CInt(MTRetComboBox.SelectedValue), CInt(MTMktComboBox.SelectedValue), CInt(PhaseTypeComboBox.SelectedValue.ToString()), CInt(MediaTypeComboBox.SelectedValue.ToString()))
            SetAllCommandTimeouts(tempAdapter, 60000)
            tempAdapter.Fill(Data._CompareACImportTypeReport, startdateTypeInDatePicker.Value, enddateTypeInDatePicker.Value, CInt(MTRetComboBox.SelectedValue))

            tempAdapter.Dispose()
            tempAdapter = Nothing

            reportForm = New ShowReportForm()

            reportForm.ReportFileResourceName = "MCAP.SendersNotMatchingImport.rdlc"
            reportForm.DataSources.Add("CompareACImportTypeReport_CompareACImportTypeReport", Data._CompareACImportTypeReport)
            reportForm.ReportName = "Senders not matching Import Type."


            reportForm.PrepareReport()

            If screenRadioButton.Checked Then
                reportForm.RefreshReport()
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


    End Class
End Namespace