Imports System.Data.SqlClient
Imports System.Text
Imports System.Security.Permissions
Namespace UI
    Public Class WebsiteMaintenanceForm
        Implements IForm

        Private FilePath As String
        Private MyConnection As System.Data.OleDb.OleDbConnection
        Private DtSet As System.Data.DataSet
        Private MyCommand As System.Data.OleDb.OleDbDataAdapter

        Private processor As New UI.Processors.webpageMaintenance


#Region " IForm Implementation "


        Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
        Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied

        Public Event InitializingForm() Implements IForm.InitializingForm
        Public Event FormInitialized() Implements IForm.FormInitialized


        Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

        End Sub

        Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

            RaiseEvent InitializingForm()

            ' Me.FormState = formStatus



            RaiseEvent FormInitialized()

        End Sub


#End Region


        Private Sub SelectButton_Click(sender As Object, e As EventArgs) Handles SelectButton.Click
            SelectOpenFileDialog.DefaultExt = ".xls"
            SelectOpenFileDialog.FileName = ""
            SelectOpenFileDialog.Filter = "Excel files (2003 or earlier) (*.xls)|*.xls|Excel files (2004 or later) (*.xlsx|*.xlsx"
            SelectOpenFileDialog.ShowDialog()
            FilePath = SelectOpenFileDialog.FileName
            PathTextBox.Text = FilePath

            If String.IsNullOrEmpty(PathTextBox.Text) = False Then
                LoadWorksheet()
                NextButton.Enabled = True
                workSheetComboBox.Visible = True
                wkLabel.Visible = True
            Else
                NextButton.Enabled = False
                workSheetComboBox.Visible = False
                wkLabel.Visible = False
            End If

        End Sub

        Private Sub LoadWorksheet()
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + PathTextBox.Text + "';Extended Properties=Excel 8.0;")

            'Get the Sheets in Excel WorkBook

            Dim cmdExcel As New System.Data.OleDb.OleDbCommand()
            cmdExcel.Connection = MyConnection
            MyConnection.Open()
            workSheetComboBox.DataSource = MyConnection.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, Nothing)
            workSheetComboBox.DisplayMember = "TABLE_NAME"
            workSheetComboBox.ValueMember = "TABLE_NAME"
            MyConnection.Close()
            workSheetComboBox.SelectedValue = -1
        End Sub

        Private Function ValidateWebsiteGrid() As Boolean
            ErrorTextBox.Text = String.Empty
            Dim strbldr As New System.Text.StringBuilder

            Dim orderCounter As Integer = 1
            Dim canInsert As Boolean = True
            'MsgBox(setDefaultZero("hello").ToString)
            ErrorTextBox.Text = String.Empty
            'processor.ClearMidWeekData()
            For ctr As Integer = 0 To websiteDataGridView.RowCount - 1
                Dim err As String
                Dim retailerError As String
                Dim UrlError As String
                Dim OrderError As String
                Dim dateWeekofError As String
                Dim dateError As String
                Dim errorRow As Boolean = True
                Dim retId As String
                Dim bPage, badPagePosition As String


                If String.IsNullOrEmpty(websiteDataGridView.Item(5, ctr).Value.ToString) = False Then
                    bPage = GetSubstringByString("(", ")", websiteDataGridView.Item(5, ctr).Value.ToString)
                    badPagePosition = processor.GetPagePositions(bPage).ToString

                End If

                retId = processor.GetRetailerID(websiteDataGridView.Item(0, ctr).Value.ToString()).ToString

                If String.IsNullOrEmpty(websiteDataGridView.Item(0, ctr).Value.ToString) = True Then
                    dateError = "Retailer must have a value"
                    err = "Invalid"
                    canInsert = False
                    retailerError = "Yes"
                    websiteDataGridView.Item(0, ctr).ErrorText = dateError
                    errorRow = False
                ElseIf retId = "NULL" Then
                    dateError = "Unknown Retailer"
                    err = "Invalid"
                    canInsert = False
                    retailerError = "Yes"
                    websiteDataGridView.Item(0, ctr).ErrorText = dateError
                    errorRow = False
                ElseIf String.IsNullOrEmpty(websiteDataGridView.Item(3, ctr).Value.ToString) = True Then
                    dateError = "Url must have a value"
                    err = "Invalid"
                    canInsert = False
                    UrlError = "Yes"
                    websiteDataGridView.Item(3, ctr).ErrorText = dateError
                    errorRow = False
                ElseIf websiteDataGridView.Item(2, ctr).Value.ToString <> orderCounter.ToString Then
                    dateError = "Incorrect Order Value"
                    err = "Invalid"
                    canInsert = False
                    OrderError = "Yes"
                    websiteDataGridView.Item(2, ctr).ErrorText = dateError
                    UrlError = "Yes"
                    errorRow = False
                ElseIf String.IsNullOrEmpty(websiteDataGridView.Item(5, ctr).Value.ToString) = True Then
                    dateError = "Pagetype must have a value"
                    err = "Invalid"
                    canInsert = False
                    UrlError = "Yes"
                    websiteDataGridView.Item(5, ctr).ErrorText = dateError
                    errorRow = False
                ElseIf String.IsNullOrEmpty(websiteDataGridView.Item(6, ctr).Value.ToString) = True Then
                    dateError = "Frequency must have a value"
                    err = "Invalid"
                    canInsert = False
                    UrlError = "Yes"
                    websiteDataGridView.Item(6, ctr).ErrorText = dateError
                    errorRow = False
                ElseIf bPage <> badPagePosition Then
                    dateError = "Unknown Page Position"
                    err = "Invalid"
                    canInsert = False
                    retailerError = "Yes"
                    errorRow = False
                    UrlError = "Yes"
                End If

               
                If errorRow = False Then

                    If ErrorTextBox.Text = "" Then
                        ErrorTextBox.Text = "You can fix the uploaded file and click the reload button or fix in the grid."
                        ErrorTextBox.AppendText(Environment.NewLine & "")

                        If retailerError = "Yes" Then
                            ErrorTextBox.AppendText(Environment.NewLine & "")
                            ErrorTextBox.AppendText(dateError)
                        ElseIf UrlError = "Yes" Then
                            ErrorTextBox.AppendText(Environment.NewLine & "")
                            ErrorTextBox.AppendText(" " & dateError)
                        End If

                    Else
                        ErrorTextBox.AppendText(Environment.NewLine & dateError)
                    End If
                    For col As Integer = 0 To 6
                        websiteDataGridView.Item(col, ctr).Style.BackColor = Color.LightPink
                    Next
                Else
                    For col As Integer = 0 To 6
                        websiteDataGridView.Item(col, ctr).Style.BackColor = Nothing
                    Next

                End If
                orderCounter = orderCounter + 1
            Next
            Return canInsert
        End Function

        Private Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click
            If WebsiteTabControl.SelectedIndex = 0 Then

                If workSheetComboBox.SelectedValue Is Nothing Then
                    SetErrorProvider(workSheetComboBox, "Please select a worksheet to process")
                    Exit Sub
                Else
                    RemoveErrorProvider(workSheetComboBox)
                End If


                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + PathTextBox.Text + "';Extended Properties=Excel 8.0;")
                MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" + workSheetComboBox.SelectedValue.ToString + "]", MyConnection)
                MyCommand.TableMappings.Add("Table", "Net-informations.com")
                DtSet = New System.Data.DataSet
                MyCommand.Fill(DtSet)
                websiteDataGridView.DataSource = DtSet.Tables(0)
                MyConnection.Close()
                WebsiteTabControl.SelectedIndex = 1
                PreviousButton.Enabled = True
                NextButton.Text = "Import"

            ElseIf WebsiteTabControl.SelectedIndex = 1 Then
                ErrorTextBox.Text = String.Empty
                Dim strbldr As New System.Text.StringBuilder
                Dim messageBox As New clsMessageBox()
                Dim orderCounter As Integer = 1
                Dim canInsert As Boolean
                Dim pageIDAbbr As String = ""
                'MsgBox(setDefaultZero("hello").ToString)
                ErrorTextBox.Text = String.Empty
                'processor.ClearMidWeekData()
                canInsert = ValidateWebsiteGrid()
                If canInsert = False Then Exit Sub
                For ctr As Integer = 0 To websiteDataGridView.RowCount - 1
                    Dim err As String
                    Dim retailerError As String
                    Dim UrlError As String
                    Dim OrderError As String
                    Dim dateWeekofError As String
                    Dim dateError As String

                    Dim retId As String
                    Dim bPage, badPagePosition As String

                    If String.IsNullOrEmpty(websiteDataGridView.Item(5, ctr).Value.ToString) = False Then
                        bPage = GetSubstringByString("(", ")", websiteDataGridView.Item(5, ctr).Value.ToString)
                        badPagePosition = processor.GetPagePositions(bPage).ToString
                        pageIDAbbr = processor.GetPagePageTypeidAbbr(bPage.Trim).ToString
                    End If

                    retId = processor.GetRetailerID(websiteDataGridView.Item(0, ctr).Value.ToString()).ToString


                    If canInsert Then
                        If ctr = 0 Then
                            processor.removeRetailer(CInt(processor.GetRetailerID(websiteDataGridView.Item(0, ctr).Value.ToString())))
                        End If
                        err = processor.ImportDataProcess(processor.GetRetailerID(websiteDataGridView.Item(0, ctr).Value.ToString()), websiteDataGridView.Item(1, ctr).Value, websiteDataGridView.Item(2, ctr).Value.ToString, websiteDataGridView.Item(3, ctr).Value.ToString, _
                                                websiteDataGridView.Item(4, ctr).Value.ToString, pageIDAbbr, processor.GetFrequencyID(websiteDataGridView.Item(6, ctr).Value.ToString))
                    End If
                   
                Next
                
                If String.IsNullOrEmpty(ErrorTextBox.Text) Then
                    WebsiteTabControl.SelectedIndex = 2
                    NextButton.Enabled = True
                    NextButton.Text = "Finish"

                    If ResultTextBox.Text = "" Then
                        ResultTextBox.AppendText(Environment.NewLine & "")
                        ResultTextBox.AppendText(Environment.NewLine & "")
                        ResultTextBox.Text = "        Upload Successful !"
                        ResultTextBox.AppendText(Environment.NewLine & "")
                    End If
                Else
                    websiteDataGridView.ClearSelection()
                End If
            ElseIf WebsiteTabControl.SelectedIndex = 2 Then
                WebsiteTabControl.SelectedIndex = 0
                NextButton.Enabled = True
                NextButton.Text = "Next"
                websiteDataGridView.DataSource = Nothing
            End If

        End Sub

        Private Sub ReloadButton_Click(sender As Object, e As EventArgs) Handles ReloadButton.Click
            If PathTextBox.Text <> "" Then
                websiteDataGridView.DataSource = Nothing
                MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + PathTextBox.Text + "';Extended Properties=Excel 8.0;")
                MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" + workSheetComboBox.SelectedValue.ToString + "]", MyConnection)
                MyCommand.TableMappings.Add("Table", "Net-informations.com")
                DtSet = New System.Data.DataSet
                MyCommand.Fill(DtSet)
                websiteDataGridView.DataSource = DtSet.Tables(0)
                MyConnection.Close()
                ErrorTextBox.Text = String.Empty
            End If
        End Sub

        Private Sub btnRemovRow_Click(sender As Object, e As EventArgs) Handles btnRemovRow.Click
            Dim dr As DataGridViewRow
            For Each dr In websiteDataGridView.SelectedRows
                websiteDataGridView.Rows.Remove(dr)

            Next
        End Sub

        Private Sub PreviousButton_Click(sender As Object, e As EventArgs) Handles PreviousButton.Click

            ErrorTextBox.Text = String.Empty
            If WebsiteTabControl.SelectedIndex > 0 Then
                WebsiteTabControl.SelectedIndex = WebsiteTabControl.SelectedIndex - 1
            End If
            If WebsiteTabControl.SelectedIndex = 1 Then NextButton.Enabled = True
            If WebsiteTabControl.SelectedIndex = 0 Then
                PreviousButton.Enabled = False
                NextButton.Text = "Next"
            End If
        End Sub
    End Class
End Namespace
