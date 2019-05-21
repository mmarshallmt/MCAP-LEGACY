Public Class canadaFrLoadForm

    Private FilePath As String
    Private MyConnection As System.Data.OleDb.OleDbConnection
    Private DtSet As System.Data.DataSet
    Private MyCommand As System.Data.OleDb.OleDbDataAdapter
    Private processor As New UI.Processors.canadaLoad


    Private Sub SelectButton_Click_1(sender As Object, e As EventArgs) Handles SelectButton.Click
        SelectOpenFileDialog.DefaultExt = ".xls"
        SelectOpenFileDialog.FileName = ""
        SelectOpenFileDialog.Filter = "Excel files (2003 or earlier) (*.xls)|*.xls|Excel files (2004 or later) (*.xlsx|*.xlsx"
        SelectOpenFileDialog.ShowDialog()
        FilePath = SelectOpenFileDialog.FileName
        PathTextBox.Text = FilePath

        If String.IsNullOrEmpty(PathTextBox.Text) = False Then
            NextButton.Enabled = True
        Else
            NextButton.Enabled = False
        End If
    End Sub

    Private Sub PreviousButton_Click(sender As Object, e As EventArgs) Handles PreviousButton.Click
        ValidationResultTextBox.Text = String.Empty
        ErrorTextBox.Text = String.Empty
        If FRLoadTabControl.SelectedIndex > 0 Then
            FRLoadTabControl.SelectedIndex = FRLoadTabControl.SelectedIndex - 1
        End If
        If FRLoadTabControl.SelectedIndex = 1 Then NextButton.Enabled = True
        If FRLoadTabControl.SelectedIndex = 0 Then
            PreviousButton.Enabled = False
            NextButton.Text = "Next"
        End If
    End Sub

    Private Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click
        If FRLoadTabControl.SelectedIndex = 0 Then
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + PathTextBox.Text + "';Extended Properties=Excel 8.0;")
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [050914Fri$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Net-informations.com")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            FRDataGridView.DataSource = DtSet.Tables(0)
            MyConnection.Close()
            FRLoadTabControl.SelectedIndex = 1
            PreviousButton.Enabled = True
            NextButton.Text = "Import"

        ElseIf FRLoadTabControl.SelectedIndex = 1 Then
            ErrorTextBox.Text = String.Empty
            Dim strbldr As New System.Text.StringBuilder
            Dim messageBox As New clsMessageBox()
            ErrorTextBox.Text = String.Empty
            processor.ClearCanadaData()
            For ctr As Integer = 0 To FRDataGridView.RowCount - 1
                Dim err As String
                Dim dateAdDateError As String
                Dim dateWeekofError As String
                Dim dateError As String
                Dim canInsert As Boolean

                If String.IsNullOrEmpty(FRDataGridView.Item(0, ctr).Value.ToString) = False Then
                    If CInt(processor.ValidateFlyerIfImported(CDbl(FRDataGridView.Item(0, ctr).Value).ToString())) = 0 Then

                        If String.IsNullOrEmpty(FRDataGridView.Item(4, ctr).Value.ToString) = False Then
                            dateAdDateError = processor.ValidateDate(CDate(FRDataGridView.Item(4, ctr).Value))
                        End If
                        If String.IsNullOrEmpty(FRDataGridView.Item(5, ctr).Value.ToString) = False Then
                            dateWeekofError = processor.ValidateDate(CDate(FRDataGridView.Item(5, ctr).Value))
                        End If

                        If dateAdDateError = "yes" Then
                            dateError = "addate Must be changes"
                            err = "Invalid"
                            canInsert = False
                        ElseIf dateWeekofError = "yes" Then
                            dateError = "WeekOf Must be changes"
                            err = "Invalid"
                            canInsert = False
                        Else
                            err = ""
                            canInsert = True
                        End If

                        If canInsert Then
                            err = processor.ImportDataProcess(FRDataGridView.Item(0, ctr).Value, FRDataGridView.Item(1, ctr).Value, FRDataGridView.Item(2, ctr).Value.ToString, FRDataGridView.Item(3, ctr).Value, _
                                                        FRDataGridView.Item(4, ctr).Value, FRDataGridView.Item(5, ctr).Value, processor.GetMarket(FRDataGridView.Item(6, ctr).Value.ToString))

                        End If
                        If err <> "Valid" And err IsNot Nothing Then

                            If ErrorTextBox.Text = "" Then
                                ErrorTextBox.Text = "You can fix the uploaded file and click the reload button or fix in the grid."
                                ErrorTextBox.AppendText(Environment.NewLine & "")

                                If dateAdDateError = "yes" Then
                                    ErrorTextBox.AppendText(Environment.NewLine & "")
                                    ErrorTextBox.AppendText("Flyer " & FRDataGridView.Item(0, ctr).Value.ToString & " " & dateError)
                                ElseIf dateWeekofError = "yes" Then
                                    ErrorTextBox.AppendText(Environment.NewLine & "")
                                    ErrorTextBox.AppendText("Flyer " & FRDataGridView.Item(0, ctr).Value.ToString & " " & dateError)
                                End If

                                ErrorTextBox.AppendText(Environment.NewLine & err)
                            Else
                                ErrorTextBox.AppendText(Environment.NewLine & err)
                            End If
                            For col As Integer = 0 To 8
                                FRDataGridView.Item(col, ctr).Style.BackColor = Color.LightPink
                            Next
                        End If
                    Else
                        'If MsgBox("Flyer " + CDbl(MWDataGridView.Item(0, ctr).Value).ToString() + " has already been processed, Do you want to replace the existing data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'mark message
                        Dim result As MessageBoxResult = messageBox.ShowMessageDialog("Flyer  " + CDbl(FRDataGridView.Item(0, ctr).Value).ToString() + " has already been processed, Do you want to replace the existing data?" & vbCr & vbLf, "MCAP 1.2")
                        If result = MessageBoxResult.Yes OrElse result = MessageBoxResult.YesToAll Then

                            dateAdDateError = processor.ValidateDate(CDate(FRDataGridView.Item(4, ctr).Value))
                            dateWeekofError = processor.ValidateDate(CDate(FRDataGridView.Item(5, ctr).Value))

                            If dateAdDateError = "yes" Then
                                dateError = "addate Must be changes"
                                err = "Invalid"
                                canInsert = False
                            ElseIf dateWeekofError = "yes" Then
                                dateError = "WeekOf Must be changes"
                                err = "Invalid"
                                canInsert = False
                            Else
                                err = ""
                                canInsert = True
                            End If

                            If canInsert Then
                                'err = processor.ImportDataProcess(FRDataGridView.Item(0, ctr).Value, FRDataGridView.Item(1, ctr).Value, processor.GetTradeClass(FRDataGridView.Item(2, ctr).Value.ToString), processor.GetAdvertiserID(FRDataGridView.Item(3, ctr).Value.ToString), _
                                '    FRDataGridView.Item(4, ctr).Value, FRDataGridView.Item(5, ctr).Value, processor.GetMarket(FRDataGridView.Item(6, ctr).Value.ToString), processor.GetMedia(FRDataGridView.Item(7, ctr).Value.ToString), _
                                '   FRDataGridView.Item(8, ctr).Value)
                            End If

                            If err <> "Valid" And err IsNot Nothing Then

                                If ErrorTextBox.Text = "" Then
                                    ErrorTextBox.Text = "You can fix the uploaded file and click the reload button or fix in the grid."
                                    ErrorTextBox.AppendText(Environment.NewLine & "")

                                    If dateAdDateError = "yes" Then
                                        ErrorTextBox.AppendText(Environment.NewLine & "")
                                        ErrorTextBox.AppendText("Flyer " & FRDataGridView.Item(0, ctr).Value.ToString & " " & dateError)
                                    ElseIf dateWeekofError = "yes" Then
                                        ErrorTextBox.AppendText(Environment.NewLine & "")
                                        ErrorTextBox.AppendText("Flyer " & FRDataGridView.Item(0, ctr).Value.ToString & " " & dateError)
                                    End If
                                    ErrorTextBox.AppendText(Environment.NewLine & err)
                                Else
                                    ErrorTextBox.AppendText(Environment.NewLine & err)
                                End If
                                For col As Integer = 0 To 8
                                    FRDataGridView.Item(col, ctr).Style.BackColor = Color.LightPink
                                Next
                            End If
                        End If
                    End If
                End If
            Next
            If processor.LoadMidWeekData.Tables(0).Rows.Count = 0 Then
                FRDataGridView.DataSource = Nothing
                MsgBox("No Record(s) to process. Mid-Week Form is now closing.", MsgBoxStyle.Information)
                Me.Close()
                Exit Sub
            End If
            If String.IsNullOrEmpty(ErrorTextBox.Text) Then
                FRLoadTabControl.SelectedIndex = 2
                NextButton.Enabled = False
                NextButton.Text = "Next"
            Else
                FRDataGridView.ClearSelection()
            End If
        ElseIf FRLoadTabControl.SelectedIndex = 2 Then
            FRLoadTabControl.SelectedIndex = 3
            NextButton.Enabled = False
        ElseIf NextButton.Text = "Finish" Then
            NextButton.Enabled = True
            Me.Close()
        End If
    End Sub

    Private Sub canadaFrLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FRLoadTabControl.SelectedIndex = 0 Then
            PreviousButton.Enabled = False
        End If
    End Sub
End Class