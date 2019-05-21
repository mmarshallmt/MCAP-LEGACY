Namespace UI

  Public Class FlashReportForm
    Implements IForm

        Private Sub Export(ByVal reportFilePath As String _
                           , ByVal reportDataSource As Microsoft.Reporting.WinForms.ReportDataSource _
                           , ByVal reportTitle As String)

            If reportDataSource Is Nothing OrElse reportFilePath Is Nothing Then Exit Sub

            Dim rptViewer As UI.ShowReportForm
            rptViewer = New UI.ShowReportForm()

            With rptViewer
                .ReportFileResourceName = reportFilePath
                .DataSources.Add(reportDataSource.Name, reportDataSource.Value)
                .ReportName = reportTitle
                .PrepareReport()
                .RefreshReport()
            End With

            Application.DoEvents()

            'rptViewer.ShowDialog(Me)
            rptViewer.ExportReportToExcel(System.IO.Path.GetTempFileName())

            rptViewer.Dispose()
            rptViewer = Nothing

        End Sub

        'Private Sub FillDataSetForFlashReport(ByVal sourceTable As FRDataSet.FlashAdsInFVFormatDataTable, ByVal flashReportDS As FRDataSet)
        '  Dim tempTable As FRDataSet.FlashAdsInFVFormatDataTable


        '  'For All Records for Report worksheet.
        '  tempTable = New FRDataSet.FlashAdsInFVFormatDataTable()
        '  tempTable.TableName = "All Records for Report"
        '  sourceTable.CopyToDataTable(tempTable, LoadOption.OverwriteChanges)

        '  For i As Integer = tempTable.Columns.Count - 1 To 0 Step -1
        '    Select Case tempTable.Columns(i).ColumnName.ToUpper()
        '      Case "VEHICLEID", "ADVERTISER", "ADDATE", "MEDIA", "MARKET", "PAGES"
        '        'DO NOTHING
        '      Case Else
        '        tempTable.Columns.RemoveAt(i)
        '    End Select
        '  Next

        '  flashReportDS.Tables.Add(tempTable)
        '  tempTable = Nothing


        '  'For Full Index Records worksheet.
        '  tempTable = New FRDataSet.FlashAdsInFVFormatDataTable()
        '  tempTable.TableName = "Full Index Records"
        '  sourceTable.CopyToDataTable(tempTable, LoadOption.OverwriteChanges)

        '  For i As Integer = tempTable.Columns.Count - 1 To 0 Step -1
        '    Select Case tempTable.Columns(i).ColumnName.ToUpper()
        '      Case "ORIGINALPUBLICATION", "ORIGINALMARKET", "FORWEEKOF", "PRIORITY", "ORIGINALIMAGE", "STANDARD" _
        '            , "FRONT PAGE", "INSIDE FRONT PAGE", "INSIDE BACK COVER", "BACK COVER", "INTERIOR PAGES" _
        '            , "WRAP", "QCCOMPLETEDBY"
        '        tempTable.Columns.RemoveAt(i)
        '    End Select
        '  Next

        '  flashReportDS.Tables.Add(tempTable)
        '  tempTable = Nothing


        '  'For Page Position worksheet.
        '  tempTable = New FRDataSet.FlashAdsInFVFormatDataTable()
        '  tempTable.TableName = "Page Position"
        '  sourceTable.CopyToDataTable(tempTable, LoadOption.OverwriteChanges)

        '  For i As Integer = tempTable.Columns.Count - 1 To 0 Step -1
        '    Select Case tempTable.Columns(i).ColumnName.ToUpper()
        '      Case "VEHICLEID", "ADVERTISER", "ADDATE", "ORIGINALPUBLICATION", "ORIGINALMARKET", "FORWEEKOF" _
        '            , "PAGES", "ORIGINALIMAGE", "STANDARD", "FRONT PAGE", "INSIDE FRONT PAGE" _
        '            , "INSIDE BACK COVER", "BACK COVER", "INTERIOR PAGES", "WRAP", "DATETIMERECORDENTERED"
        '        'DO NOTHING
        '      Case Else
        '        tempTable.Columns.RemoveAt(i)
        '    End Select
        '  Next

        '  tempTable.Columns("Advertiser").SetOrdinal(0)
        '  tempTable.Columns("AdDate").SetOrdinal(1)
        '  tempTable.Columns("VehicleId").SetOrdinal(2)
        '  tempTable.Columns("OriginalMarket").SetOrdinal(3)
        '  tempTable.Columns("OriginalPublication").SetOrdinal(4)
        '  tempTable.Columns("OriginalImage").SetOrdinal(5)
        '  tempTable.Columns("ForWeekOf").SetOrdinal(6)
        '  tempTable.Columns("Standard").SetOrdinal(7)
        '  tempTable.Columns("Front Page").SetOrdinal(8)
        '  tempTable.Columns("Inside Front Page").SetOrdinal(9)
        '  tempTable.Columns("Inside Back Cover").SetOrdinal(10)
        '  tempTable.Columns("Back Cover").SetOrdinal(11)
        '  tempTable.Columns("Interior Pages").SetOrdinal(12)
        '  tempTable.Columns("Wrap").SetOrdinal(13)
        '  tempTable.Columns("Pages").SetOrdinal(14)
        '  tempTable.Columns("DateTimeRecordEntered").SetOrdinal(15)
        '  flashReportDS.Tables.Add(tempTable)
        '  tempTable = Nothing


        '  'For Delete Records worksheet.
        '  tempTable = New FRDataSet.FlashAdsInFVFormatDataTable()
        '  tempTable.TableName = "Delete Records"
        '  sourceTable.CopyToDataTable(tempTable, LoadOption.OverwriteChanges)

        '  For i As Integer = tempTable.Columns.Count - 1 To 0 Step -1
        '    Select Case tempTable.Columns(i).ColumnName.ToUpper()
        '      Case "ORIGINALPUBLICATION", "ORIGINALMARKET", "FORWEEKOF", "PRIORITY", "ORIGINALIMAGE", "STANDARD" _
        '            , "FRONT PAGE", "INSIDE FRONT PAGE", "INSIDE BACK COVER", "BACK COVER", "INTERIOR PAGES" _
        '            , "WRAP", "QCCOMPLETEDBY", "ADVIEWSTATUSID", "ADLERTSTATUSID"
        '        tempTable.Columns.RemoveAt(i)
        '    End Select
        '  Next

        '  tempTable.Rows.Clear()  'As per sql query in MTIDE, this sheet never contain any record.
        '  flashReportDS.Tables.Add(tempTable)
        '  tempTable = Nothing


        '  flashReportDS.AcceptChanges()

        'End Sub

        'Private Sub GenerateFlashReportExcel(ByVal flashReportDS As FRDataSet, ByVal filePath As String)
        '  Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(filePath)


        '  Try
        '    ExcelHelper.ToExcel(flashReportDS, filePath, sw)

        '  Catch ex As System.IO.PathTooLongException
        '    Throw New System.ApplicationException("Unable to save flash report at: " + filePath + ". Path is too long.")
        '  Catch ex As Exception
        '    Throw New System.ApplicationException("An unknown error has occurred while exporting flash report information to excel file.")
        '  Finally
        '    sw.Close()
        '    sw.Dispose()
        '    sw = Nothing
        '  End Try

        'End Sub

        Private Sub FillDataSetForFlashReport(ByVal flashReportDS As System.Data.DataSet)
            Dim tempTable As System.Data.DataTable


            'For All Records for Report worksheet.
            tempTable = flashReportDS.Tables("Table").Copy()
            tempTable.TableName = "All Records for Report"

            For i As Integer = tempTable.Columns.Count - 1 To 0 Step -1
                Select Case tempTable.Columns(i).ColumnName.ToUpper()
                    Case "FLYERID", "ADVERTISER", "ADDATE", "MEDIA", "MARKET", "PAGES"  '"VEHICLEID" 
                        'DO NOTHING
                    Case Else
                        tempTable.Columns.RemoveAt(i)
                End Select
            Next

            flashReportDS.Tables.Add(tempTable)
            tempTable = Nothing


            'For Full Index Records worksheet.
            tempTable = flashReportDS.Tables("Table").Copy()
            tempTable.TableName = "Full Index Records"

            For i As Integer = tempTable.Columns.Count - 1 To 0 Step -1
                Select Case tempTable.Columns(i).ColumnName.ToUpper()
                    Case "ORIGINALPUBLICATION", "ORIGINALMARKET", "FORWEEKOF", "PRIORITY", "ORIGINALIMAGE", "STANDARD" _
                          , "FRONT PAGE", "INSIDE FRONT PAGE", "INSIDE BACK COVER", "BACK COVER", "INTERIOR PAGES" _
                          , "WRAP", "QCCOMPLETEDBY"
                        tempTable.Columns.RemoveAt(i)
                End Select
            Next

            flashReportDS.Tables.Add(tempTable)
            tempTable = Nothing


            'For Page Position worksheet.
            tempTable = flashReportDS.Tables("Table").Copy()
            tempTable.TableName = "Page Position"

            For i As Integer = tempTable.Columns.Count - 1 To 0 Step -1
                Select Case tempTable.Columns(i).ColumnName.ToUpper()
                    Case "FLYERID", "ADVERTISER", "ADDATE", "ORIGINALPUBLICATION", "ORIGINALMARKET", "FORWEEKOF" _
                          , "PAGES", "ORIGINALIMAGE", "STANDARD", "FRONT PAGE", "INSIDE FRONT PAGE" _
                          , "INSIDE BACK COVER", "BACK COVER", "INTERIOR PAGES", "WRAP", "DATETIMERECORDENTERED"  '"VEHICLEID"
                        'DO NOTHING
                    Case Else
                        tempTable.Columns.RemoveAt(i)
                End Select
            Next

            tempTable.Columns("Advertiser").SetOrdinal(0)
            tempTable.Columns("AdDate").SetOrdinal(1)
            tempTable.Columns("FlyerId").SetOrdinal(2)
            tempTable.Columns("OriginalMarket").SetOrdinal(3)
            tempTable.Columns("OriginalPublication").SetOrdinal(4)
            tempTable.Columns("OriginalImage").SetOrdinal(5)
            tempTable.Columns("ForWeekOf").SetOrdinal(6)
            tempTable.Columns("Standard").SetOrdinal(7)
            tempTable.Columns("Front Page").SetOrdinal(8)
            tempTable.Columns("Inside Front Page").SetOrdinal(9)
            tempTable.Columns("Inside Back Cover").SetOrdinal(10)
            tempTable.Columns("Back Cover").SetOrdinal(11)
            tempTable.Columns("Interior Pages").SetOrdinal(12)
            tempTable.Columns("Wrap").SetOrdinal(13)
            tempTable.Columns("Pages").SetOrdinal(14)
            tempTable.Columns("DateTimeRecordEntered").SetOrdinal(15)
            flashReportDS.Tables.Add(tempTable)
            tempTable = Nothing


            'For Delete Records worksheet.
            tempTable = flashReportDS.Tables("Table").Copy()
            tempTable.TableName = "Delete Records"

            For i As Integer = tempTable.Columns.Count - 1 To 0 Step -1
                Select Case tempTable.Columns(i).ColumnName.ToUpper()
                    Case "ORIGINALPUBLICATION", "ORIGINALMARKET", "FORWEEKOF", "PRIORITY", "ORIGINALIMAGE", "STANDARD" _
                          , "FRONT PAGE", "INSIDE FRONT PAGE", "INSIDE BACK COVER", "BACK COVER", "INTERIOR PAGES" _
                          , "WRAP", "QCCOMPLETEDBY", "ADVIEWSTATUSID", "ADLERTSTATUSID"
                        tempTable.Columns.RemoveAt(i)
                End Select
            Next

            tempTable.Rows.Clear()  'As per sql query in MTIDE, this sheet never contain any record.
            flashReportDS.Tables.Add(tempTable)
            tempTable = Nothing


            'Remove default source table for flash records. Move FRExport table to bottom.      
            tempTable = flashReportDS.Tables("Table1").Copy()
            tempTable.TableName = "FRExport"
            flashReportDS.Tables.Add(tempTable)
            tempTable = Nothing

            flashReportDS.Tables.Remove("Table")
            flashReportDS.Tables.Remove("Table1")

            flashReportDS.AcceptChanges()

        End Sub

        Private Sub GenerateFlashReportExcel(ByVal flashReportDS As System.Data.DataSet, ByVal filePath As String)
            Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(filePath)


            Try
                ExcelHelper.ToExcel(flashReportDS, filePath, sw)

            Catch ex As System.IO.PathTooLongException
                Throw New System.ApplicationException("Unable to save flash report at: " + filePath + ". Path is too long.")
            Catch ex As Exception
                Throw New System.ApplicationException("An unknown error has occurred while exporting flash report information to excel file.")
            Finally
                sw.Close()
                sw.Dispose()
                sw = Nothing
            End Try

        End Sub

        Private Sub ShowFlashReports(ByVal flashReports As System.Collections.Generic.List(Of String))
            Dim filePath As String
            Dim pi As System.Diagnostics.ProcessStartInfo


            For i As Integer = 0 To flashReports.Count - 1
                filePath = flashReports(i)
                pi = New System.Diagnostics.ProcessStartInfo(filePath)

                Try
                    If pi.Verbs.Contains("Open") Then
                        pi.Verb = "Open"
                        System.Diagnostics.Process.Start(pi)
                    Else
                        'Opens windows standard "open with..." dialog box, allowing user to choose application 
                        'to open exported excel file.
                        Process.Start("rundll32.exe", "shell32.dll, OpenAs_RunDLL " & filePath)
                    End If

                Catch ex As System.ComponentModel.Win32Exception
                    MessageBox.Show("Following error has occurred while opening exported excel file." _
                                    + Environment.NewLine + ex.Message + Environment.NewLine _
                                    + "File is saved successfully at " + filePath _
                                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As System.Exception
                    MessageBox.Show("An unknown error has occurred while opening exported excel file." _
                                    + Environment.NewLine + "File is saved successfully at " + filePath _
                                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Finally
                    pi = Nothing
                    filePath = Nothing
                End Try

            Next

        End Sub



#Region " IForm implementation "

        Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
        Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied

        Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

        End Sub


        Public Event InitializingForm() Implements IForm.InitializingForm
        Public Event FormInitialized() Implements IForm.FormInitialized

        Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init
            Dim weekofDate As DateTime
            Dim frstatusTable As FRDataSet.FRStatusDataTable
            Dim tempAdapter As FRDataSetTableAdapters.FRStatusTableAdapter


            tempAdapter = New FRDataSetTableAdapters.FRStatusTableAdapter()
            frstatusTable = New FRDataSet.FRStatusDataTable()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(frstatusTable)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            For i As Integer = 0 To frstatusTable.Count - 1
                descriptionCheckedListBox.Items.Add(frstatusTable(i).Descrip)
            Next

            frstatusTable.Dispose()
            frstatusTable = Nothing

            weekofDate = DateTime.Today
            weekofDate = weekofDate.AddDays(7 - weekofDate.DayOfWeek)
            Me.FRWeekTypeInDatePicker.Value = weekofDate

            Me.VwCircularTableAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            Me.VwCircularTableAdapter.Fill(Me.FRDataSet.vwCircular)

        End Sub

#End Region



        Private Sub FlashReportForm_FormClosing _
            (ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) _
            Handles Me.FormClosing

            If Me.FRDataSet.HasChanges() Then
                Dim userResponse As System.Windows.Forms.DialogResult


                userResponse = MessageBox.Show("There exist unsaved change(s). To save those changes, use Save button." _
                                               + " Do you want to continue without saving changes?", ProductName _
                                               , MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                               , MessageBoxDefaultButton.Button2)
                If userResponse = Windows.Forms.DialogResult.No Then e.Cancel = True
            End If

        End Sub

        Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

            Me.Close()

        End Sub

        Private Sub flashReportButton_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles flashReportButton.Click
            Dim center As System.Drawing.Point


            center = New System.Drawing.Point(Me.Width \ 2, Me.Height \ 2)
            center.Y = center.Y - (flashReportGroupBox.Height \ 2)
            center.X = center.X - (flashReportGroupBox.Width \ 2)

            With flashReportGroupBox
                .Location = center
                .Visible = True
                .BringToFront()
            End With

            FRWeekTypeInDatePicker.Focus()

        End Sub

        Private Sub flashReportGroupBox_Leave _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles flashReportGroupBox.Leave

            'To hide frame once input focus is moved to some other control on form.
            cancelButton.PerformClick()

        End Sub

        Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancelButton.Click

            flashReportGroupBox.Visible = False
            'forWeekOfTypeInDatePicker.Clear()
            For i As Integer = 0 To descriptionCheckedListBox.Items.Count - 1
                descriptionCheckedListBox.SetItemChecked(i, False)
            Next

        End Sub

        'Private Sub okButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles okButton.Click
        '  Dim flashDescription, filePath As String
        '  Dim flashWeek As DateTime = FRWeekTypeInDatePicker.Value.Value
        '  Dim flashReports As System.Collections.Generic.List(Of String)
        '  Dim tempAdapter As FRDataSetTableAdapters.FlashAdsInFVFormatTableAdapter
        '  Dim tempDS As FRDataSet


        '  If FRWeekTypeInDatePicker.Value.HasValue = False Then
        '    MessageBox.Show("FR Week is required to generate flash report. Please specify FR Week value." _
        '                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        '  ElseIf FRWeekTypeInDatePicker.Value.Value.DayOfWeek <> DayOfWeek.Sunday Then
        '    MessageBox.Show("FR Week has to be a sunday. Please specify valid FR Week value." _
        '                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        '  ElseIf descriptionCheckedListBox.CheckedIndices.Count = 0 Then
        '    MessageBox.Show("FR description is required to generate flash report. Please select atleast one description." _
        '                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        '  End If

        '  tempAdapter = New FRDataSetTableAdapters.FlashAdsInFVFormatTableAdapter()
        '  tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '  flashReports = New System.Collections.Generic.List(Of String)
        '  tempDS = New FRDataSet()
        '  tempDS.Relations.Clear()
        '  tempDS.Tables.Clear()

        '  Try
        '    For i As Integer = 0 To descriptionCheckedListBox.CheckedIndices.Count - 1
        '      With descriptionCheckedListBox
        '        flashDescription = .Items(.CheckedIndices(i)).ToString()
        '      End With

        '      tempAdapter.Fill(FRDataSet.FlashAdsInFVFormat, Nothing, flashWeek, flashDescription)
        '      FillDataSetForFlashReport(FRDataSet.FlashAdsInFVFormat, tempDS)
        '      filePath = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls")
        '      GenerateFlashReportExcel(tempDS, filePath)
        '      flashReports.Add(filePath)

        '      filePath = Nothing
        '      tempDS.Tables.Clear()
        '      tempDS.AcceptChanges()
        '    Next

        '  Catch ex As System.Data.SqlClient.SqlException
        '    MessageBox.Show("An error has occurred while fetching data from database. Cannot generate flash report." _
        '                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '  Catch ex As Exception
        '    MessageBox.Show("Unknown error has occurred while generating flash report. Cannot generate flash report." _
        '                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '  Finally
        '    tempDS.Dispose()
        '    tempDS = Nothing
        '    tempAdapter.Dispose()
        '    tempAdapter = Nothing
        '  End Try

        '  ShowFlashReports(flashReports)
        '  flashReports.Clear()
        '  flashReports = Nothing

        'End Sub

        Private Sub okButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles okButton.Click
            Dim flashDescription, filePath As String
            Dim flashWeek As DateTime = FRWeekTypeInDatePicker.Value.Value
            Dim flashReports As System.Collections.Generic.List(Of String)
            Dim tempAdapter As System.Data.SqlClient.SqlDataAdapter
            Dim tempCmd As System.Data.SqlClient.SqlCommand
            Dim tempDS As System.Data.DataSet


            If FRWeekTypeInDatePicker.Value.HasValue = False Then
                MessageBox.Show("FR Week is required to generate flash report. Please specify FR Week value." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf FRWeekTypeInDatePicker.Value.Value.DayOfWeek <> DayOfWeek.Sunday Then
                MessageBox.Show("FR Week has to be a sunday. Please specify valid FR Week value." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf descriptionCheckedListBox.CheckedIndices.Count = 0 Then
                MessageBox.Show("FR description is required to generate flash report. Please select atleast one description." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            flashReports = New System.Collections.Generic.List(Of String)
            tempAdapter = New System.Data.SqlClient.SqlDataAdapter()
            tempCmd = New System.Data.SqlClient.SqlCommand
            tempDS = New System.Data.DataSet("FRReport")

            With tempCmd
                .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                .CommandText = "mt_proc_GetFlashAdsInFVFormat"
                .CommandType = CommandType.StoredProcedure
                With .Parameters
                    .AddWithValue("@VehicleIdList", Nothing)
                    .AddWithValue("@FRWeek", FRWeekTypeInDatePicker.Value)
                    .Add("@FRDescription", SqlDbType.VarChar, 50)
                    .Add("@MTIDEDBServerName", SqlDbType.VarChar, 100)
                End With
                .Parameters("@MTIDEDBServerName").Value = MTIDEDBServerName
                .Prepare()
            End With
            tempAdapter.SelectCommand = tempCmd

            Try
                For i As Integer = 0 To descriptionCheckedListBox.CheckedIndices.Count - 1
                    With descriptionCheckedListBox
                        flashDescription = .Items(.CheckedIndices(i)).ToString()
                    End With

                    tempAdapter.SelectCommand.Parameters("@FRDescription").Value = flashDescription
                    tempAdapter.Fill(tempDS)
                    FillDataSetForFlashReport(tempDS)
                    filePath = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls")
                    GenerateFlashReportExcel(tempDS, filePath)
                    flashReports.Add(filePath)

                    filePath = Nothing
                    tempDS.Tables.Clear()
                    tempDS.AcceptChanges()
                Next

            Catch ex As System.Data.SqlClient.SqlException
                MessageBox.Show("An error has occurred while fetching data from database. Cannot generate flash report." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Unknown error has occurred while generating flash report. Cannot generate flash report." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                tempDS.Dispose()
                tempDS = Nothing
                tempAdapter.Dispose()
                tempAdapter = Nothing
            End Try

            ShowFlashReports(flashReports)
            flashReports.Clear()
            flashReports = Nothing

        End Sub


        Private Sub FRDataGridView_CellEndEdit _
            (ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
            Handles FRDataGridView.CellEndEdit

            FRDataGridView.Rows(e.RowIndex).ErrorText = String.Empty

        End Sub

        Private Sub FRDataGridView_CellValidating _
            (ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) _
            Handles FRDataGridView.CellValidating

            If FRDataGridView.Columns(e.ColumnIndex).HeaderText.ToUpper() <> "FLASHIND" Then Exit Sub

            If e.FormattedValue Is Nothing OrElse e.FormattedValue Is DBNull.Value Then
                MessageBox.Show("Value for Flash Indicator must be specified. Cannot have blank value." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            ElseIf e.FormattedValue.ToString() <> "0" And e.FormattedValue.ToString() <> "1" Then
                MessageBox.Show("Value for Flash Indicator can be either 0 (Not a flash) or 1 (Flash)." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
                FRDataGridView.Rows(e.RowIndex).ErrorText = "Invalid flash indicator."
            End If

        End Sub

        Private Sub searchButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchButton.Click
            Dim vehicleId As Integer


            If Integer.TryParse(vehicleIdTextBox.Text, vehicleId) = False Then
                MessageBox.Show("Specify valid vehicleId.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Me.VwCircularTableAdapter.FillByVehicleId(Me.FRDataSet.vwCircular, vehicleId)

        End Sub

        Private Sub showFlashAdsButton_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles showFlashAdsButton.Click

            Me.VwCircularTableAdapter.Fill(Me.FRDataSet.vwCircular)

        End Sub

        Private Sub saveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles saveButton.Click
            Dim userResponse As System.Windows.Forms.DialogResult


            userResponse = MessageBox.Show("This will save changes made in grid since last save." + Environment.NewLine _
                                           + "Are you sure you want to continue?", ProductName, MessageBoxButtons.YesNo _
                                           , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If userResponse = Windows.Forms.DialogResult.Yes Then
                Try
                    Me.VwCircularTableAdapter.Update(Me.FRDataSet.vwCircular)

                Catch ex As System.Data.SqlClient.SqlException
                    MessageBox.Show("An error has occurred while updating database. Not all changes are saved to database." _
                                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show("Unknown error has occurred while updating database. Not all changes are saved to database." _
                                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                showFlashAdsButton.PerformClick()
            End If

        End Sub

        Private Sub exportSelectedButton_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles exportSelectedButton.Click

            If FRDataGridView.SelectedRows.Count = 0 Then
                MessageBox.Show("Select rows to export to a excel sheet.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Dim vehicleIds As System.Collections.Generic.IEnumerable(Of Integer)
            Dim vehicleIdCSV As System.Text.StringBuilder
            Dim vehicleIdArray As Integer()

            vehicleIds = From row In FRDataGridView.SelectedRows.Cast(Of System.Windows.Forms.DataGridViewRow)() _
                         Select CType(row.Cells("VehicleIdDataGridViewAutoFilterTextBoxColumn").Value, Integer)

            vehicleIdArray = vehicleIds.ToArray()
            vehicleIdCSV = New System.Text.StringBuilder()
            vehicleIdCSV.Append("<Vehicles>")
            For i As Integer = 0 To vehicleIdArray.Length - 1
                vehicleIdCSV.Append("<Vehicle Id=""")
                vehicleIdCSV.Append(vehicleIdArray(i).ToString())
                vehicleIdCSV.Append("""/>")
            Next
            vehicleIdCSV.Append("</Vehicles>")

            Dim tempAdapter As FRDataSetTableAdapters.FlashAdsInFVFormatTableAdapter
            tempAdapter = New FRDataSetTableAdapters.FlashAdsInFVFormatTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(FRDataSet.FlashAdsInFVFormat, vehicleIdCSV.ToString(), Nothing, Nothing, MTIDEDBServerName)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            Dim tempDataSource As Microsoft.Reporting.WinForms.ReportDataSource
            tempDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("FRDataSet_FlashAdsInFVFormat", CType(FRDataSet.FlashAdsInFVFormat, DataTable))
            Export("MCAP.ExportFlashRecords.rdlc", tempDataSource, "Flash Ads (FV Format)")
            tempDataSource = Nothing

        End Sub

        Private Sub exportAllButton_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles exportAllButton.Click
            Dim tempAdapter As FRDataSetTableAdapters.FlashAdsInFVFormatTableAdapter
            Dim tempDataSource As Microsoft.Reporting.WinForms.ReportDataSource

            If FRDataGridView.RowCount <= 0 Then
                MessageBox.Show("No data to export.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
            tempAdapter = New FRDataSetTableAdapters.FlashAdsInFVFormatTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(FRDataSet.FlashAdsInFVFormat, DBNull.Value, Nothing, Nothing, MTIDEDBServerName)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            tempDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("FRDataSet_FlashAdsInFVFormat", CType(FRDataSet.FlashAdsInFVFormat, DataTable))
            Export("MCAP.ExportFlashRecords.rdlc", tempDataSource, "Flash Ads (FV Format)")
            tempDataSource = Nothing

            'Dim reportFilePath, reportTitle As String
            'Dim reportDataSource As Microsoft.Reporting.WinForms.ReportDataSource


            'reportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource("FRDataSet_vwCircular", Me.FRDataSet.vwCircular)
            'reportFilePath = "MCAP.ExportFlashRecords.rdlc"
            'reportTitle = "Export All Flash Ads"

            'Export(reportFilePath, reportDataSource, reportTitle)

        End Sub

        ''' <summary>
        ''' Gets boolean value indicating whether the supplied retailer is associated with Natioanl market in FRControl table or not.
        ''' </summary>
        ''' <param name="retailerId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function IsValidForNationalMarket(ByVal retailerId As Integer) As Boolean
            Dim count As Integer?
            Dim tempAdapter As FRDataSetTableAdapters.FRControlTableAdapter


            tempAdapter = New FRDataSetTableAdapters.FRControlTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            count = tempAdapter.GetCountForNationalMkt(retailerId)

            tempAdapter.Dispose()
            tempAdapter = Nothing

            Return (count.HasValue AndAlso count.Value > 0)

        End Function

        Private Sub markAsNationalButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles markAsNationalButton.Click

            If FRDataGridView.SelectedRows.Count = 0 Then
                MessageBox.Show("Select atleast one vehicle to mark it as National.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            Dim vehicleId, retailerId As Integer
            Dim tempRow As FRDataSet.vwCircularRow

            For i As Integer = 0 To FRDataGridView.SelectedRows.Count - 1
                With FRDataGridView.SelectedRows(i)
                    If Integer.TryParse(.Cells("VehicleIdDataGridViewAutoFilterTextBoxColumn").Value.ToString(), vehicleId) = False Then
                        vehicleId = 0
                    End If

                    If Integer.TryParse(.Cells("RetIdDataGridViewTextBoxColumn").Value.ToString(), retailerId) = False Then
                        retailerId = 0
                    End If
                End With

                If IsValidForNationalMarket(retailerId) = False Then
                    MessageBox.Show("Can not mark vehicle " + vehicleId.ToString() + " as National. Retailer" _
                                    + " is not associated with National market for FR." _
                                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Continue For
                End If

                Try
                    tempRow = FRDataSet.vwCircular.FindByVehicleId(vehicleId)
                    If tempRow Is Nothing Then
                        Throw New System.ApplicationException("Unable to find vehicle information for vehicle " _
                                                              + vehicleId.ToString() + "Cannot mark vehicle as National.")
                    End If

                    tempRow.BeginEdit()
                    tempRow.NationalInd = 1
                    tempRow.EndEdit()
                    tempRow = Nothing

                Catch ex As System.ApplicationException
                    MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show("Unable to mark vehicle " + vehicleId.ToString() + " as national." + Environment.NewLine _
                                    + "Unexpected error has occurred while marking vehicle as National." _
                                    , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Next

            Dim tempAdapter As FRDataSetTableAdapters.vwCircularTableAdapter
            tempAdapter = New FRDataSetTableAdapters.vwCircularTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Try
                vehicleId = tempAdapter.Update(FRDataSet.vwCircular)
            Catch ex As System.Data.SqlClient.SqlException
                MessageBox.Show("Unable to update vehicle " + vehicleId.ToString() + Environment.NewLine _
                                + "Database related error has occurred while marking vehicle as National." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Unable to update vehicle " + vehicleId.ToString() + Environment.NewLine _
                                + "Unexpected error has occurred while marking vehicle as National." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                tempAdapter.Dispose()
                tempAdapter = Nothing

            End Try

            MessageBox.Show(vehicleId.ToString() + " vehicle(s) marked successfully as National." _
                            , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Sub


    End Class

End Namespace