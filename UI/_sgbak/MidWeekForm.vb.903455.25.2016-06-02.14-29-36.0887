Imports System.Data.SqlClient
Imports System.Text
Imports System.Security.Permissions

Public Class MidWeekForm
    Private FilePath As String
    Private MyConnection As System.Data.OleDb.OleDbConnection
    Private DtSet As System.Data.DataSet
    Private MyCommand As System.Data.OleDb.OleDbDataAdapter

    Private processor As New UI.Processors.MidWeek

    Private Sub SelectButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectButton.Click
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

    Private Sub NextButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextButton.Click
        If MidWeekTabControl.SelectedIndex = 0 Then
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + PathTextBox.Text + "';Extended Properties=Excel 8.0;")
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [FlashAds$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Net-informations.com")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            MWDataGridView.DataSource = DtSet.Tables(0)
            MyConnection.Close()
            MidWeekTabControl.SelectedIndex = 1
            PreviousButton.Enabled = True
            NextButton.Text = "Import"

        ElseIf MidWeekTabControl.SelectedIndex = 1 Then
            ErrorTextBox.Text = String.Empty
            Dim strbldr As New System.Text.StringBuilder
            Dim messageBox As New clsMessageBox()
            'MsgBox(setDefaultZero("hello").ToString)
            ErrorTextBox.Text = String.Empty
            processor.ClearMidWeekData()
            For ctr As Integer = 0 To MWDataGridView.RowCount - 1
                Dim err As String
                Dim dateAdDateError As String
                Dim dateWeekofError As String
                Dim dateError As String
                Dim canInsert As Boolean

                If String.IsNullOrEmpty(MWDataGridView.Item(0, ctr).Value.ToString) = False Then
                    If CType(processor.ValidateFlyerIfImported(MWDataGridView.Item(0, ctr).Value.ToString), Int16) = 0 Then

                        If String.IsNullOrEmpty(MWDataGridView.Item(4, ctr).Value.ToString) = False Then
                            dateAdDateError = processor.ValidateDate(CDate(MWDataGridView.Item(4, ctr).Value))
                        End If
                        If String.IsNullOrEmpty(MWDataGridView.Item(5, ctr).Value.ToString) = False Then
                            dateWeekofError = processor.ValidateDate(CDate(MWDataGridView.Item(5, ctr).Value))
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
                            err = processor.ImportDataProcess(MWDataGridView.Item(0, ctr).Value, MWDataGridView.Item(1, ctr).Value, processor.GetTradeClass(MWDataGridView.Item(2, ctr).Value.ToString), processor.GetAdvertiserID(MWDataGridView.Item(3, ctr).Value.ToString), _
                                                        MWDataGridView.Item(4, ctr).Value, MWDataGridView.Item(5, ctr).Value, processor.GetMarket(MWDataGridView.Item(6, ctr).Value.ToString), processor.GetMedia(MWDataGridView.Item(7, ctr).Value.ToString), _
                                                       MWDataGridView.Item(8, ctr).Value)
                        End If
                        If err <> "Valid" And err IsNot Nothing Then

                            If ErrorTextBox.Text = "" Then
                                ErrorTextBox.Text = "You can fix the uploaded file and click the reload button or fix in the grid."
                                ErrorTextBox.AppendText(Environment.NewLine & "")

                                If dateAdDateError = "yes" Then
                                    ErrorTextBox.AppendText(Environment.NewLine & "")
                                    ErrorTextBox.AppendText("Flyer " & MWDataGridView.Item(0, ctr).Value.ToString & " " & dateError)
                                ElseIf dateWeekofError = "yes" Then
                                    ErrorTextBox.AppendText(Environment.NewLine & "")
                                    ErrorTextBox.AppendText("Flyer " & MWDataGridView.Item(0, ctr).Value.ToString & " " & dateError)
                                End If

                                ErrorTextBox.AppendText(Environment.NewLine & err)
                            Else
                                ErrorTextBox.AppendText(Environment.NewLine & err)
                            End If
                            For col As Integer = 0 To 8
                                MWDataGridView.Item(col, ctr).Style.BackColor = Color.LightPink
                            Next
                        End If
                    Else
                        'If MsgBox("Flyer " + CDbl(MWDataGridView.Item(0, ctr).Value).ToString() + " has already been processed, Do you want to replace the existing data?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        'mark message
                        Dim result As MessageBoxResult = messageBox.ShowMessageDialog("Flyer  " + MWDataGridView.Item(0, ctr).Value.ToString() + " has already been processed, Do you want to replace the existing data?" & vbCr & vbLf, "MCAP 1.2")
                        If result = MessageBoxResult.Yes OrElse result = MessageBoxResult.YesToAll Then

                            dateAdDateError = processor.ValidateDate(CDate(MWDataGridView.Item(4, ctr).Value))
                            dateWeekofError = processor.ValidateDate(CDate(MWDataGridView.Item(5, ctr).Value))

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
                                err = processor.ImportDataProcess(MWDataGridView.Item(0, ctr).Value, MWDataGridView.Item(1, ctr).Value, processor.GetTradeClass(MWDataGridView.Item(2, ctr).Value.ToString), processor.GetAdvertiserID(MWDataGridView.Item(3, ctr).Value.ToString), _
                                    MWDataGridView.Item(4, ctr).Value, MWDataGridView.Item(5, ctr).Value, processor.GetMarket(MWDataGridView.Item(6, ctr).Value.ToString), processor.GetMedia(MWDataGridView.Item(7, ctr).Value.ToString), _
                                   MWDataGridView.Item(8, ctr).Value)
                            End If

                            If err <> "Valid" And err IsNot Nothing Then

                                If ErrorTextBox.Text = "" Then
                                    ErrorTextBox.Text = "You can fix the uploaded file and click the reload button or fix in the grid."
                                    ErrorTextBox.AppendText(Environment.NewLine & "")

                                    If dateAdDateError = "yes" Then
                                        ErrorTextBox.AppendText(Environment.NewLine & "")
                                        ErrorTextBox.AppendText("Flyer " & MWDataGridView.Item(0, ctr).Value.ToString & " " & dateError)
                                    ElseIf dateWeekofError = "yes" Then
                                        ErrorTextBox.AppendText(Environment.NewLine & "")
                                        ErrorTextBox.AppendText("Flyer " & MWDataGridView.Item(0, ctr).Value.ToString & " " & dateError)
                                    End If
                                    ErrorTextBox.AppendText(Environment.NewLine & err)
                                Else
                                    ErrorTextBox.AppendText(Environment.NewLine & err)
                                End If
                                For col As Integer = 0 To 8
                                    MWDataGridView.Item(col, ctr).Style.BackColor = Color.LightPink
                                Next
                            End If
                        End If
                    End If
                End If
            Next
            If processor.LoadMidWeekData.Tables(0).Rows.Count = 0 Then
                MWDataGridView.DataSource = Nothing
                MsgBox("No Record(s) to process. Mid-Week Form is now closing.", MsgBoxStyle.Information)
                Me.close()
                Exit Sub
            End If
            If String.IsNullOrEmpty(ErrorTextBox.Text) Then
                MidWeekTabControl.SelectedIndex = 2
                NextButton.Enabled = False
                NextButton.Text = "Next"
            Else
                MWDataGridView.ClearSelection()
            End If
        ElseIf MidWeekTabControl.SelectedIndex = 2 Then
            MidWeekTabControl.SelectedIndex = 3
            NextButton.Enabled = False
        ElseIf NextButton.Text = "Finish" Then
            NextButton.Enabled = True
            Me.Close()
        End If
    End Sub

    Private Sub MidWeekForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If MidWeekTabControl.SelectedIndex = 0 Then
            PreviousButton.Enabled = False
        End If
        'ImagePathTextBox.Text = Global.MCAP.My.MySettings.Default.DefaultMidWeekImagePath
        'For i As Integer = 1 To 3
        '    Me.MidWeekTabControl.TabPages(i).Enabled = False
        'Next
    End Sub

    Private Sub ImagePathButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagePathButton.Click

        PathFolderBrowserDialog.ShowDialog()
        FilePath = PathFolderBrowserDialog.SelectedPath.ToString
        ImagePathTextBox.Text = FilePath

        If String.IsNullOrEmpty(ImagePathTextBox.Text) = False Then
            ValidationButton.Enabled = True
        Else
            ValidationButton.Enabled = False
        End If
    End Sub

    Private Sub ValidationButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValidationButton.Click
        Dim ds As DataSet
        Dim isInvalidPath As Boolean = False
        ds = New DataSet
        ds = processor.LoadMidWeekData()

        If ds IsNot Nothing Then

            ValidationResultTextBox.Text = "Processing..."

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                Me.SuspendLayout()

                Dim path As String = ImagePathTextBox.Text + "\" + ds.Tables(0).Rows(i).Item(0).ToString()

                If IO.Directory.Exists(path) Then

                    If processor.ValidatePageCount(path, CInt(ds.Tables(0).Rows(i).Item(1))) Then

                        If processor.ValidateImagePagesExist(path, CInt(ds.Tables(0).Rows(i).Item(1))) = "" Then
                            processor.UpdateMidWeekData(ds.Tables(0).Rows(i).Item(0).ToString())
                            ValidationResultTextBox.AppendText(Environment.NewLine & "")
                            ValidationResultTextBox.AppendText(Environment.NewLine & "FlyerId " + CDbl(ds.Tables(0).Rows(i).Item(0)).ToString() + " - Valid")
                        Else
                            isInvalidPath = True
                            ValidationResultTextBox.AppendText(Environment.NewLine & "")
                            ValidationResultTextBox.AppendText(Environment.NewLine & "FlyerId " + CDbl(ds.Tables(0).Rows(i).Item(0)).ToString() + " Missing Images " + processor.ValidateImagePagesExist(path, CInt(ds.Tables(0).Rows(i).Item(1))))
                        End If
                    Else
                        Dim gifCount As Integer = processor.GIFExist(path)
                        Dim pngCount As Integer = processor.PNGExist(path)
                        Dim bmpCount As Integer = processor.BMPExist(path)

                        If processor.PDFExist(path) Then
                            Dim isSuccessful As Boolean = processor.PDFConvertion(path + "\001.pdf", path, CInt(ds.Tables(0).Rows(i).Item(1)))
                            ValidationResultTextBox.AppendText(Environment.NewLine & "")
                            ValidationResultTextBox.AppendText(Environment.NewLine & "PDF File has been found in Flyer ID : " + CDbl(ds.Tables(0).Rows(i).Item(0)).ToString() + ", converting into jpg format...")
                            If isSuccessful Then
                                ValidationResultTextBox.AppendText(Environment.NewLine & "File has been converted to JPG format.")
                                If processor.ValidatePageCount(path, CInt(ds.Tables(0).Rows(i).Item(1))) Then
                                    processor.UpdateMidWeekData(CDbl(ds.Tables(0).Rows(i).Item(0)).ToString())
                                    ValidationResultTextBox.AppendText(Environment.NewLine & "FlyerId " + CDbl(ds.Tables(0).Rows(i).Item(0)).ToString() + " - Valid")
                                Else
                                    ValidationResultTextBox.AppendText(Environment.NewLine & "FlyerId " + CDbl(ds.Tables(0).Rows(i).Item(0)).ToString() + " does not match the expected image count, please check the image folder.")
                                End If
                            Else
                                ValidationResultTextBox.AppendText(Environment.NewLine & "An Error occured while converting the PDF file to JPG format.")
                            End If

                        ElseIf gifCount > 0 Then

                            Dim isSuccessful As Boolean = True
                            ValidationResultTextBox.AppendText(Environment.NewLine & "")
                            ValidationResultTextBox.AppendText(Environment.NewLine & "GIF File has been found in Flyer ID : " + CDbl(ds.Tables(0).Rows(i).Item(0)).ToString() + ", converting into jpg format...")
                            For ctr As Integer = 1 To gifCount
                                If processor.ConvertToJPG(Global.MCAP.My.MySettings.Default.ConverterPathSettings, path + "\" + ctr.ToString("000") + ".gif", "90", path + "\" + ctr.ToString("000") + ".jpg") = False Then
                                    'If processor.ConvertToJPG("C:\PngToJpeg.exe", path + "\" + ctr.ToString("000") + ".gif", "90", path + "\" + ctr.ToString("000") + ".jpg") = False Then
                                    isSuccessful = False
                                End If
                            Next
                            If isSuccessful Then
                                ValidationResultTextBox.AppendText(Environment.NewLine & "File has been converted to JPG format.")
                                If processor.ValidatePageCount(path, CInt(ds.Tables(0).Rows(i).Item(1))) Then
                                    processor.UpdateMidWeekData(CDbl(ds.Tables(0).Rows(i).Item(0)).ToString())
                                    ValidationResultTextBox.AppendText(Environment.NewLine & "FlyerId " + CDbl(ds.Tables(0).Rows(i).Item(0)).ToString() + " - Done")
                                Else
                                    ValidationResultTextBox.AppendText(Environment.NewLine & "FlyerId " + CDbl(ds.Tables(0).Rows(i).Item(0)).ToString() + " does not match the expected image count, please check the image folder.")
                                End If
                            Else
                                ValidationResultTextBox.AppendText(Environment.NewLine & "An Error occured while converting the PDF file to JPG format.")
                            End If

                        ElseIf pngCount > 0 Then

                            Dim isSuccessful As Boolean = True
                            ValidationResultTextBox.AppendText(Environment.NewLine & "")
                            ValidationResultTextBox.AppendText(Environment.NewLine & "PNG File has been found in Flyer ID : " + CDbl(ds.Tables(0).Rows(i).Item(0)).ToString() + " !")
                            For ctr As Integer = 1 To pngCount
                                If processor.ConvertToJPG(Global.MCAP.My.MySettings.Default.ConverterPathSettings, path + "\" + ctr.ToString("000") + ".png", " 90 ", path + "\" + ctr.ToString("000") + ".jpg") = False Then
                                    'If processor.ConvertToJPG("C:\PngToJpeg.exe", path + "\" + ctr.ToString("000") + ".png", " 90 ", path + "\" + ctr.ToString("000") + ".jpg") = False Then
                                    isSuccessful = False
                                End If
                            Next
                            If isSuccessful Then
                                ValidationResultTextBox.AppendText(Environment.NewLine & "File has been converted to JPG format.")
                                If processor.ValidatePageCount(path, CInt(ds.Tables(0).Rows(i).Item(1))) Then
                                    processor.UpdateMidWeekData(CDbl(ds.Tables(0).Rows(i).Item(0)).ToString())
                                    ValidationResultTextBox.AppendText(Environment.NewLine & "FlyerId " + CDbl(ds.Tables(0).Rows(i).Item(0)).ToString() + " - Done")
                                Else
                                    ValidationResultTextBox.AppendText(Environment.NewLine & "FlyerId " + CDbl(ds.Tables(0).Rows(i).Item(0)).ToString() + " does not match the expected image count, please check the image folder.")
                                End If
                            Else
                                ValidationResultTextBox.AppendText(Environment.NewLine & "An Error occured while converting the PDF file to JPG format.")
                            End If

                        ElseIf bmpCount > 0 Then

                            Dim isSuccessful As Boolean = True
                            ValidationResultTextBox.AppendText(Environment.NewLine & "")
                            ValidationResultTextBox.AppendText(Environment.NewLine & "BMP File has been found in Flyer ID : " + CDbl(ds.Tables(0).Rows(i).Item(0)).ToString() + " !")
                            For ctr As Integer = 1 To bmpCount
                                ValidationResultTextBox.AppendText(Environment.NewLine & "File has been converted to JPG format.")
                                If processor.ConvertToJPG(Global.MCAP.My.MySettings.Default.ConverterPathSettings, path + "\" + ctr.ToString("000") + ".bmp", " 90 ", path + "\" + ctr.ToString("000") + ".jpg") = False Then
                                    'If processor.ConvertToJPG("C:\PngToJpeg.exe", path + "\" + ctr.ToString("000") + ".bmp", " 90 ", path + "\" + ctr.ToString("000") + ".jpg") = False Then
                                    isSuccessful = False
                                End If
                            Next
                            If isSuccessful Then
                                ValidationResultTextBox.AppendText(Environment.NewLine & "File has been converted to JPG format.")
                                If processor.ValidatePageCount(path, CInt(ds.Tables(0).Rows(i).Item(1))) Then
                                    processor.UpdateMidWeekData(CDbl(ds.Tables(0).Rows(i).Item(0)).ToString())
                                    ValidationResultTextBox.AppendText(Environment.NewLine & "FlyerId " + CDbl(ds.Tables(0).Rows(i).Item(0)).ToString() + " - Done")
                                Else
                                    ValidationResultTextBox.AppendText(Environment.NewLine & "FlyerId " + CDbl(ds.Tables(0).Rows(i).Item(0)).ToString() + " does not match the expected image count, please check the image folder.")
                                End If
                            Else
                                ValidationResultTextBox.AppendText(Environment.NewLine & "An Error occured while converting the PDF file to JPG format.")
                            End If
                        End If
                        If processor.ValidatePageCount(path, CInt(ds.Tables(0).Rows(i).Item(1))) = False Then
                            isInvalidPath = True
                            ValidationResultTextBox.AppendText(Environment.NewLine & "")
                            ValidationResultTextBox.AppendText(Environment.NewLine & "FlyerId " + CDbl(ds.Tables(0).Rows(i).Item(0)).ToString() + " does not match the expected image count(" + CInt(ds.Tables(0).Rows(i).Item(1)).ToString() + "), please check the image folder.")
                        End If
                    End If
                    Me.ResumeLayout()
                Else
                    'to be checked by mark 
                    ValidationResultTextBox.AppendText(Environment.NewLine & "")
                    ValidationResultTextBox.AppendText(Environment.NewLine & "Invalid Image Path for FlyerId " + CDbl(ds.Tables(0).Rows(i).Item(0)).ToString() + Environment.NewLine + "Path does not exist " + path)
                    ValidationResultTextBox.AppendText(Environment.NewLine & "")
                    isInvalidPath = True
                End If
            Next

            If isInvalidPath = True Then Exit Sub

            Dim dsWithError As DataSet = processor.LoadMidWeekDataWithError
            Dim DataWithError As String

            If dsWithError.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To dsWithError.Tables(0).Rows.Count - 1
                    If DataWithError Is Nothing Then
                        DataWithError = CDbl(dsWithError.Tables(0).Rows(i).Item(0)).ToString()
                    Else
                        DataWithError = DataWithError + ", " + CDbl(dsWithError.Tables(0).Rows(i).Item(0)).ToString()
                    End If
                Next
                ValidationResultTextBox.AppendText(Environment.NewLine & "")
                ValidationResultTextBox.AppendText(Environment.NewLine & "The following FlyerID is Invalid, please check the image folder and run again the validation. FLYERID : " + DataWithError)

            Else
                ValidationResultTextBox.AppendText(Environment.NewLine & "")
                ValidationResultTextBox.AppendText(Environment.NewLine & "Validation is Complete.Please click next to proceed to the next process...")
                NextButton.Enabled = True
            End If

        Else
            MsgBox("No data to process.", MsgBoxStyle.Information, "Mid - Week Flash")
        End If
        NextButton.Enabled = True

    End Sub


    Private Sub PathTabPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PathTabPage.Click

    End Sub

    Private Sub ProcessButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessButton.Click
        If ProcessButton.Text <> "Copy to MW Flash Ads" Then
            Dim genEnvelopeID As Integer
            Dim genVehicleID As Integer
            Dim familyid As Integer
            Dim dsMidWeek As DataSet
            Dim oMedia As Object
            Dim oMarket As Object
            Dim ctrFiles As Integer
            Dim strbuilder As New StringBuilder

            dsMidWeek = New DataSet

            dsMidWeek = processor.LoadValidMidWeekData
            NextButton.Enabled = False
            PreviousButton.Enabled = False
            ProcessButton.Text = "Processing..."
            ProcessButton.Enabled = False
            If dsMidWeek.Tables(0).Rows.Count > 0 Then
                ResultTextBox.Text = "Processing..."
                ResultTextBox.AppendText(Environment.NewLine & "")
                genEnvelopeID = processor.CreatEnvelope()
                For i As Integer = 0 To dsMidWeek.Tables(0).Rows.Count - 1
                    familyid = processor.CreatefamilyId(CInt(dsMidWeek.Tables(0).Rows(i).Item(2)))
                    ctrFiles = ctrFiles + 1
                    'MsgBox(" " + genEnvelopeID.ToString + " " + CInt(dsMidWeek.Tables(0).Rows(i).Item(3)) + " " + dsMidWeek.Tables(0).Rows(i).Item(0).ToString + " " + dsMidWeek.Tables(0).Rows(i).Item(4).ToString() + " " + familyid)
                    genVehicleID = processor.CreateVehicle(CInt(dsMidWeek.Tables(0).Rows(i).Item(2)), genEnvelopeID, CInt(dsMidWeek.Tables(0).Rows(i).Item(3)), dsMidWeek.Tables(0).Rows(i).Item(0).ToString, dsMidWeek.Tables(0).Rows(i).Item(4).ToString(), familyid)


                    If i = 0 Then
                        strbuilder.Append(genVehicleID.ToString)
                    ElseIf i > 0 And i <> dsMidWeek.Tables(0).Rows.Count - 1 Then
                        strbuilder.Append(", ")
                        strbuilder.Append(genVehicleID.ToString)
                    End If
                    If isVehicleQCed(genVehicleID) = False Then
                        Dim pgCount As Integer
                        For pgCount = 1 To CInt(dsMidWeek.Tables(0).Rows(i).Item(1))
                            processor.CreatPage(genVehicleID, pgCount.ToString, pgCount.ToString("000"))
                        Next
                        processor.RemoveExcessPage(pgCount, genVehicleID)
                        ResultTextBox.AppendText(Environment.NewLine & "VehicleID " + genVehicleID.ToString + " has been successfully created for FlyerID " + CDbl(dsMidWeek.Tables(0).Rows(i).Item(0)).ToString())
                        Dim dt As String = processor.RetrieveYearMonth(genVehicleID)
                        'Dim serverPath = Global.MCAP.My.MySettings.Default.DefaultMidWeekImagePath.ToString()
                        Dim _path As String = processor.GetImagePath(dt, processor.GetPathType("Master"))
                        _path = _path + "\" + dt + "\" + genVehicleID.ToString + "\Unsized"
                        '_path = _path + "\" + dt + "\" + genVehicleID.ToString + "\Unsized"


                        ResultTextBox.AppendText(Environment.NewLine & processor.CopyImageToServer(_path, ImagePathTextBox.Text + "\" + dsMidWeek.Tables(0).Rows(i).Item(0).ToString()).ToString + " image(s) has been copied in " + _path)
                        ResultTextBox.AppendText(Environment.NewLine & "")
                    Else
                        ResultTextBox.AppendText(Environment.NewLine & "FlyerId" + CDbl(dsMidWeek.Tables(0).Rows(i).Item(0)).ToString() + " image(s) Were not copied. Flyer was qced.")
                        ResultTextBox.AppendText(Environment.NewLine & "")

                    End If
                Next
            Else
                ResultTextBox.Text = "No record to process..."
            End If
            'ProcessButton.Text = "Copy to MW Flash Ads"
            'ProcessButton.Enabled = True
            PreviousButton.Enabled = False
            NextButton.Text = "Finish"
            NextButton.Enabled = True

            If strbuilder.ToString IsNot Nothing Then
                Dim oExportExcelPath As String = processor.ExportDataToExcel(processor.LoadCreatedVehicle(strbuilder.ToString()), System.IO.Path.GetDirectoryName(FilePath))
                ResultTextBox.AppendText(Environment.NewLine & "")
                ResultTextBox.AppendText(Environment.NewLine & "Data has been exported into " + oExportExcelPath)
                ProcessButton.Text = "Start Process"
                If oExportExcelPath <> "" Or String.IsNullOrEmpty(oExportExcelPath) = False Then
                    Dim p As Process
                    p.Start(oExportExcelPath)
                    'p.WaitForExit()
                End If
            End If

            ResultTextBox.AppendText(Environment.NewLine & "")
            ResultTextBox.AppendText(Environment.NewLine & ctrFiles.ToString + " File(s) has been successfully processed. Click Finish button to close the form")
        Else
            MsgBox(processor.CopyToFlashAds, MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        ErrorPanel.Visible = False
    End Sub

    Private Sub PreviousButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviousButton.Click
        ValidationResultTextBox.Text = String.Empty
        ErrorTextBox.Text = String.Empty
        If MidWeekTabControl.SelectedIndex > 0 Then
            MidWeekTabControl.SelectedIndex = MidWeekTabControl.SelectedIndex - 1
        End If
        If MidWeekTabControl.SelectedIndex = 1 Then NextButton.Enabled = True
        If MidWeekTabControl.SelectedIndex = 0 Then
            PreviousButton.Enabled = False
            NextButton.Text = "Next"
        End If
    End Sub

    Private Sub MidWeekTabControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MidWeekTabControl.SelectedIndexChanged

        If MidWeekTabControl.SelectedIndex = 1 And PathTextBox.Text <> "" Then
            NextButton.Enabled = True
        End If

        If NextButton.Text = "Finish" And MidWeekTabControl.SelectedIndex <> 4 Then
            Me.SuspendLayout()
            MidWeekTabControl.SelectedIndex = 3
            Me.ResumeLayout()
        End If

        If MidWeekTabControl.SelectedIndex <> 1 And NextButton.Text <> "Finish" Then NextButton.Text = "Next"

        If MidWeekTabControl.SelectedIndex = 0 Or MidWeekTabControl.SelectedIndex = 4 Then
            PreviousButton.Enabled = False
        ElseIf (PathTextBox.Text <> "" And MidWeekTabControl.SelectedIndex = 1) Or (MWDataGridView.RowCount <> 0 And MidWeekTabControl.SelectedIndex = 2) Or ((ImagePathTextBox.Text <> "" And ImagePathTextBox.Text <> Global.MCAP.My.MySettings.Default.DefaultMidWeekImagePath) And MidWeekTabControl.SelectedIndex = 3) Then
            'ElseIf (PathTextBox.Text <> "" And MidWeekTabControl.SelectedIndex = 1) Or (MWDataGridView.RowCount <> 0 And MidWeekTabControl.SelectedIndex = 2) Or ((ImagePathTextBox.Text <> "" And ImagePathTextBox.Text <> "C:\") And MidWeekTabControl.SelectedIndex = 3) Then '--> this is just for testing
            PreviousButton.Enabled = True
        End If
    End Sub

    Private Sub ReloadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReloadButton.Click
        If PathTextBox.Text <> "" Then
            MWDataGridView.DataSource = Nothing
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + PathTextBox.Text + "';Extended Properties=Excel 8.0;")
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [FlashAds$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "Net-informations.com")
            DtSet = New System.Data.DataSet
            MyCommand.Fill(DtSet)
            MWDataGridView.DataSource = DtSet.Tables(0)
            MyConnection.Close()
            ErrorTextBox.Text = String.Empty
        End If
    End Sub

    Private Sub CopyMWAdsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyMWAdsButton.Click
        Dim VehicleID As String
        Dim flyerID As String
        Dim dsMidWeek As DataSet
        Dim isQced As Boolean
        Dim readyToCopy As Boolean

        Dim ctrFiles As Integer
        Dim strbuilder As New StringBuilder

        dsMidWeek = New DataSet

        dsMidWeek = processor.LoadValidMidWeekData
        ResultTextBoxFad.Text = ""
        If dsMidWeek.Tables(0).Rows.Count > 0 Then

            ResultTextBox.AppendText(Environment.NewLine & "")
            isQced = True
            readyToCopy = True
            For i As Integer = 0 To dsMidWeek.Tables(0).Rows.Count - 1

                flyerID = dsMidWeek.Tables(0).Rows(i).Item(0).ToString
                VehicleID = processor.vehicleIdByFlyerID(flyerID)
                isQced = isVehicleQCed(Integer.Parse(VehicleID))
                If isQced = False Then
                    ResultTextBoxFad.AppendText(Environment.NewLine & "")
                    ResultTextBoxFad.AppendText("Vehicle " & VehicleID & " Has not been Qced." & Environment.NewLine & "")
                    readyToCopy = False
                Else
                    ResultTextBoxFad.AppendText(Environment.NewLine & "")
                    ResultTextBoxFad.AppendText("Vehicle " & VehicleID & " ready to be transfered." & Environment.NewLine & "")
                End If

            Next
        End If
        If readyToCopy Then
            StatusLabel.Text = processor.CopyToFlashAds()

            If StatusLabel.Text <> "0" Then
                StatusLabel.Text = StatusLabel.Text + " file(s) has been successfully copied."
                processor.ClearMidWeekData()
                Me.MidWeekTabControl.TabPages(0).Enabled = False
                Me.MidWeekTabControl.TabPages(1).Enabled = False
                Me.MidWeekTabControl.TabPages(2).Enabled = False
                Me.MidWeekTabControl.TabPages(3).Enabled = False
                ResultTextBoxFad.AppendText(Environment.NewLine & "")
                ResultTextBoxFad.AppendText("" + StatusLabel.Text + " file(s) has been successfully copied.")
            Else
                StatusLabel.Text = "No new data to copy."
            End If
            StatusLabel.Visible = True

        End If
    End Sub

  
    Private Sub btnRemovRow_Click(sender As Object, e As EventArgs) Handles btnRemovRow.Click
        Dim dr As DataGridViewRow
        For Each dr In MWDataGridView.SelectedRows
            MWDataGridView.Rows.Remove(dr)

        Next
    End Sub
End Class