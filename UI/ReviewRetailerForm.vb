Imports System.Collections.Generic
Imports System.Windows.Controls
Namespace UI

    Public Class ReviewRetailerForm

        Inherits MDIChildFormBase
        Implements IForm

        ''' <summary>
        ''' This constant is used to assigning value to FormName column.
        ''' </summary>
        Private Const FORM_NAME As String = "Required Form"


        Private m_previousSelection As SearchCriteria

        Private WithEvents m_RequiredProcessor As Processors.RequiredProcess

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

            RaiseEvent InitializingForm()

            ' Me.FormState = formStatus
            m_RequiredProcessor = New Processors.RequiredProcess
            Processor.Initialize()


            Processor.TempRetAdapter.Fill(Processor.Data.TempRet)
            Dim MediaView As DataView = New DataView(Processor.Data.TempRet)
           
            Processor.RetailerAdapter.Fill(Processor.Data.Ret)
            Processor.MarketAdapter.FillAllData(Processor.Data.Mkt)
            Processor.MediaAdapter.Fill(Processor.Data.Media)
            Processor.ReviewStatus.Fill(Processor.Data.reviewStatus)
            Processor.CodeAdapter.Fill(Processor.Data.Code)
            Processor.UnregisteredRetTableAdapter.Fill(Processor.Data.UnregisteredRet)
            Processor.NewRetailerCodeAdapter.Fill(Processor.Data.NewRetailerCode)
            Processor.TradeClassAdapter.Fill(Processor.Data.TradeClassList)
            Processor.DisplayVehicleAdapter.FillByUnprocessedVehicle(Processor.Data.Vehicle)

            Dim NewRetStatus As DataView = New DataView(Processor.Data.Code)
            Dim NewSearchRetStatus As DataView = New DataView(Processor.Data.NewRetailerCode)

            'newRetailerListBox.DisplayMember = "Descrip"
            'newRetailerListBox.ValueMember = "vehicleid"
            'newRetailerListBox.DataSource = MediaView
            reviewDataGridView.DataSource = Processor.Data.Vehicle


            With RetailerComboBox
                .DisplayMember = "Descrip"
                .ValueMember = "retid"
                .DataSource = Processor.Data.Ret
                .SelectedValue = -1
            End With
            With MediaComboBox
                .DisplayMember = "Descrip"
                .ValueMember = "mediaid"
                .DataSource = Processor.Data.Media
                .SelectedValue = -1
            End With

            With marketComboBox
                .DisplayMember = "Descrip"
                .ValueMember = "mktid"
                .DataSource = Processor.Data.Mkt
                .SelectedValue = -1
            End With
            With newRetMktComboBox
                .DisplayMember = "Descrip"
                .ValueMember = "mktid"
                .DataSource = Processor.Data.Mkt
                .SelectedValue = -1
            End With

            'With tradeClassComboBox
            '    .DisplayMember = "descrip"
            '    .ValueMember = "tradeclassid"
            '    .DataSource = Processor.Data.TradeClassList
            '    .SelectedValue = -1
            'End With

            With statusListBox
                .DisplayMember = "descrip"
                .ValueMember = "codeid"
                .DataSource = Processor.Data.reviewStatus

            End With


            With retMktStatusDataGridViewComboBoxColumn
                .DataPropertyName = "statusid"
                .DisplayMember = "descrip"
                .ValueMember = "codeid"
                .DataSource = Processor.Data.Code
                .DefaultCellStyle.NullValue = "Not Reviewed"
            End With

            NewRetStatus.RowFilter = "descrip<>'Registered'"
            With retStatusDataGridViewComboBoxColumn
                .DataPropertyName = "statusid"
                .DisplayMember = "descrip"
                .ValueMember = "codeid"
                .DataSource = NewRetStatus
                .DefaultCellStyle.NullValue = "Not Reviewed"
            End With

            NewSearchRetStatus.RowFilter = "descrip<>'Registered'"
            With newReviewStatusListBox
                .DisplayMember = "descrip"
                .ValueMember = "codeid"
                .SelectedValue = -1
                .DataSource = NewSearchRetStatus

            End With

            unregisteredStartdateTypeInDatePicker.Value = System.DateTime.Today.AddMonths(-1)
            unregisteredEnddateTypeInDatePicker.Value = System.DateTime.Today.AddDays(1)
            Dim startDate As DateTime = unregisteredStartdateTypeInDatePicker.Value.Value
            Dim endDate As DateTime = unregisteredEnddateTypeInDatePicker.Value.Value
            Dim newRetMktId As Integer = 0

            'Me.retMktDataGridView.Columns("statusid").Visible = False
            retMktDataGridView.Columns("SenderNameTextBoxColumn").DisplayIndex = 0
            retMktDataGridView.Columns("MediaTextBoxColumn").DisplayIndex = 1
            retMktDataGridView.Columns("marketTextBoxColumn").DisplayIndex = 2
            retMktDataGridView.Columns("RetailerTextBoxColumn").DisplayIndex = 3
            retMktDataGridView.Columns("PublicationTextBoxColumn").DisplayIndex = 4
            retMktDataGridView.Columns("addateTextBoxColumn").DisplayIndex = 5
            retMktDataGridView.Columns("distDateTextBoxColumn").DisplayIndex = 6
            retMktDataGridView.Columns("pageCountTextBoxColumn").DisplayIndex = 7
            retMktDataGridView.Columns("vehicleStatusTextBoxColumn").DisplayIndex = 8
            'retMktDataGridView.Columns("media").DisplayIndex = 3
            'retMktDataGridView.Columns("mktid").DisplayIndex = 4
            'retMktDataGridView.Columns("retid").DisplayIndex = 5
            'retMktDataGridView.Columns("Status").DisplayIndex = 6
            statusListBox.SelectedValue = -1
            newReviewStatusListBox.SelectedValue = -1
            startdateTypeInDatePicker.Value = System.DateTime.Today.AddMonths(-1)
            enddateTypeInDatePicker.Value = System.DateTime.Today.AddDays(1)

            newRetFromTypeInDatePicker.Value = System.DateTime.Today.AddMonths(-1)
            newRetToTypeInDatePicker.Value = System.DateTime.Today.AddDays(1)

            Call fillUnRetMktDataGrid(startDate, endDate)
            Call newRetDataGrid(startDate, endDate, newRetMktId)
         
            RaiseEvent FormInitialized()

        End Sub

        Private Sub loadUnprocessVehicle(ByVal startDate As DateTime, ByVal endDate As DateTime)

            Processor.DisplayVehicleAdapter.FillByUnprocessedVehicleDate(Processor.Data.Vehicle, startDate, endDate)
            reviewDataGridView.DataSource = Processor.Data.Vehicle
        End Sub

#End Region
        Private Sub fillUnRetMktDataGrid(ByVal startDate As DateTime, ByVal endDate As DateTime)
            Processor.UnregisteredRetMktTableAdapter.Fill(Processor.Data.unRegisteredRetMkt, startDate, endDate)
            Processor.Data.unRegisteredRetMkt.Columns("SenderName").SetOrdinal(0)
            Processor.Data.unRegisteredRetMkt.Columns("Retailer").SetOrdinal(3)
            Processor.Data.unRegisteredRetMkt.Columns("Market").SetOrdinal(2)
            Processor.Data.unRegisteredRetMkt.Columns("Media").SetOrdinal(1)
            retMktDataGridView.DataSource = Processor.Data.unRegisteredRetMkt
        End Sub

        Private Sub newRetDataGrid(ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal mktid As Integer)
            Processor.Data.NewRetailers.Clear()
            Processor.Data.NewRetailers.Columns("SenderName").SetOrdinal(0)
            Processor.Data.NewRetailers.Columns("Media").SetOrdinal(1)
            Processor.Data.NewRetailers.Columns("Market").SetOrdinal(2)
            Processor.Data.NewRetailers.Columns("Retailer").SetOrdinal(3)
           
            Processor.NewRetailersTableAdapter.Fill(Processor.Data.NewRetailers, startDate, endDate, mktid)
            NewRetailerDataGridView.DataSource = Processor.Data.NewRetailers
        End Sub
        Private Sub newRetCodeIdDataGrid(ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal mktid As Integer, ByVal CodeID As String)
            Processor.NewRetailersTableAdapter.FillByCodeID(Processor.Data.NewRetailers, startDate, endDate, mktid)
            Dim newRetLoad As DataView = New DataView(Processor.Data.NewRetailers)
            Processor.Data.NewRetailers.Columns("SenderName").SetOrdinal(0)
            Processor.Data.NewRetailers.Columns("Media").SetOrdinal(1)
            Processor.Data.NewRetailers.Columns("Market").SetOrdinal(2)
            Processor.Data.NewRetailers.Columns("Retailer").SetOrdinal(3)

            newRetLoad.RowFilter = "Statusid in(" + CodeID.ToString + ") "
            NewRetailerDataGridView.DataSource = newRetLoad
        End Sub

        Private Sub cleallAllunregisteredRetInput()
            RetailerComboBox.SelectedValue = -1
            'searchUnregisteredTextBox.Text = ""
            'reviewDataGridView.DataSource = Processor.Data.UnregisteredRet
        End Sub

        Private Sub clearNewRetailer()
            newRetFromTypeInDatePicker.Value = System.DateTime.Today.AddMonths(-1)
            newRetToTypeInDatePicker.Value = System.DateTime.Today.AddDays(1)
            newRetMktComboBox.SelectedValue = -1
            newReviewStatusListBox.SelectedValue = -1
            newRetMktComboBox.SelectedValue = -1
            newRetDataGrid(newRetFromTypeInDatePicker.Value.Value, newRetToTypeInDatePicker.Value.Value, CInt(newRetMktComboBox.SelectedValue))
        End Sub


        Public Function getVehicleIdList() As String()
            Dim vehicleIdArray() As String
            Dim desc As String
            Dim vehicleIdArrayProcess() As String
            'vehicleIdArray = getTempText()
            ReDim vehicleIdArrayProcess(vehicleIdArray.Length - 1)
            For i As Integer = 0 To vehicleIdArray.Length - 1
                desc = GetFieldValue("select vehicleid from UnregisteredRetailers where descrip ='" + vehicleIdArray(i).ToString.Replace("'", "''") + "'", "vehicleid")
                vehicleIdArrayProcess(i) = desc
            Next
            Return vehicleIdArrayProcess
        End Function


        ''' <summary>
        ''' Marks vehicles in array with status as Checked In. Removes DataRows from DataTable.
        ''' </summary>
        ''' <param name="vehicleIdArray"></param>
        ''' <remarks></remarks>
        Private Sub MarkVehiclesAsCheckIn(ByVal vehicleIdArray() As Integer)
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.VehicleTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.VehicleDataTable
            Dim tempRow As MCAP.ReportsDataSet.VehicleRow

            tempAdapter = New MCAP.ReportsDataSetTableAdapters.VehicleTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempTable = CType(reviewDataGridView.DataSource, ReportsDataSet.VehicleDataTable)

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

        Private Sub MarkVehiclesAsWrongVersion(ByVal vehicleIdArray() As Integer)
            Dim statusid As Integer

            statusid = Processor.GetStatusIdForWrongVersion

            For i As Integer = 0 To vehicleIdArray.Length - 1

                Processor.UpdateVehicleStatus(vehicleIdArray(i), statusid, User.UserID)
            Next

        End Sub

        Private Sub clearButton_Click(sender As Object, e As EventArgs) Handles clearButton.Click

        End Sub


        Private Sub saveButton_Click_1(sender As Object, e As EventArgs) Handles saveButton.Click
            Dim row As DataGridViewRow
            Dim startDate As DateTime = newRetFromTypeInDatePicker.Value.Value
            Dim endDate As DateTime = newRetToTypeInDatePicker.Value.Value
            Dim mktid As Integer
            If marketComboBox.SelectedValue Is Nothing OrElse marketComboBox.SelectedValue Is DBNull.Value Then
                mktid = 0
            Else
                mktid = CType(marketComboBox.SelectedValue, Integer)
            End If

            For i As Integer = 0 To NewRetailerDataGridView.Rows.Count - 1
                row = NewRetailerDataGridView.Rows(i)

                If IsDBNull(row.Cells("retStatusDataGridViewComboBoxColumn").Value) = False Then

                    Processor.UpdateNewRetailerStatus(CType(NewRetailerDataGridView.Rows(i).Cells("retStatusDataGridViewComboBoxColumn").Value, Integer), CType(NewRetailerDataGridView.Rows(i).Cells("VehicleIdDataGridViewTextBoxColumn").Value, Integer))
                
                End If

            Next
            Call newRetDataGrid(startDate, endDate, mktid)
        End Sub

        Private Sub Button2_Click(sender As Object, e As EventArgs)
            cleallAllunregisteredRetInput()
        End Sub

        Private Sub retMktSaveButton_Click(sender As Object, e As EventArgs) Handles retMktSaveButton.Click
            Dim row As DataGridViewRow
            Dim senderid As Integer
            Dim mediaid As Integer
            Dim mktid As Integer
            Dim retid As Integer
            Dim expectationid As Integer
            Dim vehicleid As Integer
            Dim statusid As Integer

            Dim startDate As DateTime = unregisteredStartdateTypeInDatePicker.Value.Value
            Dim endDate As DateTime = unregisteredEnddateTypeInDatePicker.Value.Value
            For i As Integer = 0 To retMktDataGridView.Rows.Count - 1
                row = retMktDataGridView.Rows(i)

                If IsDBNull(row.Cells("retMktStatusDataGridViewComboBoxColumn").Value) = False Then

                    If row.Cells("retMktStatusDataGridViewComboBoxColumn").Value.ToString = "2214" Then
                        senderid = CType(retMktDataGridView.Rows(i).Cells("senderidTextBoxColumn").Value, Integer)
                        mediaid = CType(retMktDataGridView.Rows(i).Cells("mediaidTextBoxColumn").Value, Integer)
                        mktid = CType(retMktDataGridView.Rows(i).Cells("MktidTextBoxTextBoxColumn").Value, Integer)
                        retid = CType(retMktDataGridView.Rows(i).Cells("RetidTextBoxTextBoxColumn").Value, Integer)
                        vehicleid = CType(retMktDataGridView.Rows(i).Cells("vehicleIdTextBoxColumn").Value, Integer)
                        expectationid = CInt(Processor.ifExpectationExist(mediaid, mktid, retid))
                       
                        If String.IsNullOrEmpty(Processor.ifExpectationExist(mediaid, mktid, retid)) = False _
                           And Processor.ifSenderExpectationExist(senderid, expectationid) = False Then

                            MessageBox.Show("Vehicle will be moved to backup sender report.", "MCAP", MessageBoxButtons.OK)
                            statusid = Processor.GetStatusIdForBackupSender()
                            Processor.UpdateVehicleStatus(vehicleid, statusid, Nothing)
                        ElseIf String.IsNullOrEmpty(Processor.ifExpectationExist(mediaid, mktid, retid)) = False _
                            And Processor.ifSenderExpectationExist(senderid, expectationid) = True Then
                            MessageBox.Show("Vehicle will be moved to Unprocessed Vehicle report.", "MCAP", MessageBoxButtons.OK)
                            If Processor.ifRetailerExist(CType(retMktDataGridView.Rows(i).Cells("RetidTextBoxTextBoxColumn").Value, Integer), CType(retMktDataGridView.Rows(i).Cells("MktidTextBoxTextBoxColumn").Value, Integer), CType(retMktDataGridView.Rows(i).Cells("mediaidTextBoxColumn").Value, Integer)) = True Then
                                Processor.UpdateUnregisterRetailerStatus(CType(retMktDataGridView.Rows(i).Cells("retMktStatusDataGridViewComboBoxColumn").Value, Integer), CType(retMktDataGridView.Rows(i).Cells("RetidTextBoxTextBoxColumn").Value, Integer), CType(retMktDataGridView.Rows(i).Cells("MktidTextBoxTextBoxColumn").Value, Integer), CType(retMktDataGridView.Rows(i).Cells("mediaidTextBoxColumn").Value, Integer))

                            Else
                                Processor.InsertUnregisterRetailerStatus(CType(retMktDataGridView.Rows(i).Cells("retMktStatusDataGridViewComboBoxColumn").Value, Integer), CType(retMktDataGridView.Rows(i).Cells("RetidTextBoxTextBoxColumn").Value, Integer), CType(retMktDataGridView.Rows(i).Cells("MktidTextBoxTextBoxColumn").Value, Integer), CType(retMktDataGridView.Rows(i).Cells("mediaidTextBoxColumn").Value, Integer))

                            End If

                        Else

                            MessageBox.Show("Please review the Expectation and SenderExpectation for processing." + vbNewLine + _
                                            " Sender :  " + retMktDataGridView.Rows(i).Cells("SenderNameTextBoxColumn").Value.ToString + vbNewLine + _
                                            " Media : " + retMktDataGridView.Rows(i).Cells("MediaTextBoxColumn").Value.ToString + vbNewLine + _
                                            " Market : " + retMktDataGridView.Rows(i).Cells("marketTextBoxColumn").Value.ToString + vbNewLine + _
                                            " Retailer : " + retMktDataGridView.Rows(i).Cells("RetailerTextBoxColumn").Value.ToString + _
                                            "", "MCAP", MessageBoxButtons.OK)

                        End If

                    Else

                        If Processor.ifRetailerExist(CType(retMktDataGridView.Rows(i).Cells("RetidTextBoxTextBoxColumn").Value, Integer), CType(retMktDataGridView.Rows(i).Cells("MktidTextBoxTextBoxColumn").Value, Integer), CType(retMktDataGridView.Rows(i).Cells("mediaidTextBoxColumn").Value, Integer)) = True Then
                            Processor.UpdateUnregisterRetailerStatus(CType(retMktDataGridView.Rows(i).Cells("retMktStatusDataGridViewComboBoxColumn").Value, Integer), CType(retMktDataGridView.Rows(i).Cells("RetidTextBoxTextBoxColumn").Value, Integer), CType(retMktDataGridView.Rows(i).Cells("MktidTextBoxTextBoxColumn").Value, Integer), CType(retMktDataGridView.Rows(i).Cells("mediaidTextBoxColumn").Value, Integer))

                        Else
                            Processor.InsertUnregisterRetailerStatus(CType(retMktDataGridView.Rows(i).Cells("retMktStatusDataGridViewComboBoxColumn").Value, Integer), CType(retMktDataGridView.Rows(i).Cells("RetidTextBoxTextBoxColumn").Value, Integer), CType(retMktDataGridView.Rows(i).Cells("MktidTextBoxTextBoxColumn").Value, Integer), CType(retMktDataGridView.Rows(i).Cells("mediaidTextBoxColumn").Value, Integer))

                        End If

                    End If

                End If


            Next
            Call fillUnRetMktDataGrid(startDate, endDate)

        End Sub

        Private Sub searchRetMktTextBox_TextChanged(sender As Object, e As EventArgs) Handles searchRetMktTextBox.TextChanged
            Dim MediaView As DataView = New DataView(Processor.Data.unRegisteredRetMkt)

            MediaView.Sort = "retailer"
            MediaView.RowFilter = "retailer like '%" + searchRetMktTextBox.Text + "%' or market like '%" + searchRetMktTextBox.Text + "%'"

            retMktDataGridView.DataSource = MediaView
        End Sub

        Private Sub clearRetMkt()
            MediaComboBox.SelectedValue = -1
            marketComboBox.SelectedValue = -1
            RetailerComboBox.SelectedValue = -1
            statusListBox.SelectedValue = -1
            retMktDataGridView.DefaultCellStyle.BackColor = Color.Empty
            retMktDataGridView.DataSource = Processor.Data.unRegisteredRetMkt
        End Sub
        Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
            Dim RetMktView As DataView = New DataView(Processor.Data.unRegisteredRetMkt)
            Dim elements() As String
            Dim i As Integer = 0
            Dim mediaid As Integer
            Dim retid As Integer
            Dim mktid As Integer
            Dim startDate As DateTime
            Dim endDate As DateTime
            retMktDataGridView.DefaultCellStyle.BackColor = Color.Empty
            ReDim elements(statusListBox.SelectedItems.Count - 1)

            For Each Item As DataRowView In statusListBox.SelectedItems
                elements(i) = Item.Item("codeid").ToString
                i = i + 1
            Next
            Dim codeId As String = String.Join(",", elements)

            If MediaComboBox.SelectedValue Is Nothing OrElse MediaComboBox.SelectedValue Is DBNull.Value Then
                mediaId = Nothing
            Else
                mediaId = CType(MediaComboBox.SelectedValue, Integer)
            End If

            If marketComboBox.SelectedValue Is Nothing OrElse marketComboBox.SelectedValue Is DBNull.Value Then
                mktid = Nothing
            Else
                mktid = CType(marketComboBox.SelectedValue, Integer)
            End If

            If RetailerComboBox.SelectedValue Is Nothing OrElse RetailerComboBox.SelectedValue Is DBNull.Value Then
                retId = Nothing
            Else
                retId = CType(RetailerComboBox.SelectedValue, Integer)
            End If

            startDate = unregisteredStartdateTypeInDatePicker.Value.Value
            endDate = unregisteredEnddateTypeInDatePicker.Value.Value

            If statusListBox.SelectedValue Is Nothing And statusListBox.SelectedIndex = -1 Then
              

                If retid = 0 And mktid = 0 And mediaid > 0 Then

                    RetMktView.RowFilter = "mediaid =" + mediaid.ToString

                ElseIf retid > 0 And mktid = 0 And mediaid = 0 Then

                    RetMktView.RowFilter = "retid =" + retid.ToString

                ElseIf retid = 0 And mktid > 0 And mediaid = 0 Then

                    RetMktView.RowFilter = "mktid =" + mktid.ToString

                ElseIf retid = 0 And mktid > 0 And mediaid > 0 Then

                    RetMktView.RowFilter = "mediaid =" + mediaid.ToString + " and mktid=" + mktid.ToString

                ElseIf retid > 0 And mktid > 0 And mediaid > 0 Then

                    RetMktView.RowFilter = "mediaid =" + mediaid.ToString + " and mktid=" + mktid.ToString + " and retid=" + retid.ToString

                Else

                    If codeId = "" Then
                        fillUnRetMktDataGrid(startDate, endDate)
                    Else

                        RetMktView.RowFilter = "mktid =" + mktid.ToString + " and mediaid=" + mediaid.ToString + " and retid=" + retid.ToString + " and statusid in (" + codeId + ")"
                    End If
                End If

                retMktDataGridView.DataSource = RetMktView
            Else
                DetailSearch(startDate, endDate, mediaid, mktid, retid)
                RetMktView = New DataView(Processor.Data.unRegisteredRetMkt)
                RetMktView.RowFilter = "statusid in (" + codeId + ")"
                retMktDataGridView.DataSource = RetMktView
            End If
        End Sub

        Private Sub DetailSearch(ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal mediaid As Integer, ByVal mktid As Integer, ByVal retid As Integer)
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.unRegisteredRetMktTableAdapter

            tempAdapter = New MCAP.ReportsDataSetTableAdapters.unRegisteredRetMktTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.FillByDetailSearch(Processor.Data.unRegisteredRetMkt, startDate, endDate, mediaid, mktid, retid)

            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub

        Private Sub vehicletoIndexButton_Click(sender As Object, e As EventArgs) Handles vehicletoIndexButton.Click
            Dim vehicleId, selectedRowIndex As Integer
            Dim myIndexForm As New IndexForm
            Dim userResponse As DialogResult
            Dim selectedVehicleQuery As System.Collections.Generic.IEnumerable(Of Integer)
            Dim mktid As Integer
            Dim PublicationId As Integer
            Dim retid As Integer
            Dim StatusId As Integer
            Dim MediaValue As String
            Dim adDate As DateTime

            Dim objDupCheck As UI.Processors.DupCheckProcess
            Dim dupcheckResponse As DuplicateCheckUserResponse


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


            For Each SelectedRow As DataGridViewRow In reviewDataGridView.SelectedRows

                mktid = CType(SelectedRow.Cells("mktid").Value, Integer)
                PublicationId = CType(SelectedRow.Cells("PublicationId").Value, Integer)
                vehicleId = CType(SelectedRow.Cells("VehicleId").Value, Integer)
                MediaValue = (SelectedRow.Cells("media").Value.ToString)
                adDate = CType(SelectedRow.Cells("ad_Date").Value, DateTime)
                retid = CType(SelectedRow.Cells("RetId").Value, Integer)

                objDupCheck = New UI.Processors.DupCheckProcess
                objDupCheck.VehicleID = CStr(vehicleId)
                objDupCheck.FormState = FormStateEnum.Edit
                objDupCheck.Form = Me
                objDupCheck.MediaText = MediaValue.ToUpper
                objDupCheck.adVehicleDate = adDate
                objDupCheck.RetId = retid

                dupcheckResponse = objDupCheck.CheckForDuplication(mktid _
                                                          , PublicationId, True, FORM_NAME)
                If dupcheckResponse = DuplicateCheckUserResponse.Closed Then Exit Sub

                'If vehicle status is created, keep statusId as null,
                'if its not required, status id is set while validating row in processor.
                '
                If dupcheckResponse = DuplicateCheckUserResponse.Review Then
                    StatusId = Processor.GetStatusIdForReview()
                    Processor.UpdateVehicleStatus(vehicleId, StatusId, User.UserID)
                ElseIf dupcheckResponse = DuplicateCheckUserResponse.Duplicate Then
                    StatusId = Processor.GetStatusIdForDuplicate()
                    Processor.UpdateVehicleStatus(vehicleId, StatusId, User.UserID)
                Else


                    Processor.InsertBypassSenderVehicleHistory(vehicleId)


                    MarkVehiclesAsCheckIn(selectedVehicleQuery.ToArray())
                End If

            Next


            selectedVehicleQuery = Nothing
        End Sub

        Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
            Me.Close()
        End Sub

        Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
            Dim startDate As DateTime
            Dim endDate As DateTime
            Dim MediaView As DataView = New DataView(Processor.Data.Vehicle)

            startDate = startdateTypeInDatePicker.Value.Value
            endDate = enddateTypeInDatePicker.Value.Value
            loadUnprocessVehicle(startDate, endDate)

            'MediaView.RowFilter = "Ad_Date >= '" + startDate.ToString + "' AND  Ad_Date <= '" + endDate.ToString + "'"

            'reviewDataGridView.DataSource = MediaView
        End Sub

      
        Private Sub unProcessClearButton_Click(sender As Object, e As EventArgs) Handles unProcessClearButton.Click

            startdateTypeInDatePicker.Value = System.DateTime.Today.AddMonths(-1)
            enddateTypeInDatePicker.Value = System.DateTime.Today.AddDays(1)
            reviewDataGridView.DataSource = Processor.Data.Vehicle
        End Sub

        Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
            clearRetMkt()
            fillUnRetMktDataGrid(unregisteredStartdateTypeInDatePicker.Value.Value, unregisteredEnddateTypeInDatePicker.Value.Value)
        End Sub

        Private Sub ButtonRefresh_Click(sender As Object, e As EventArgs) Handles ButtonRefresh.Click
            clearRetMkt()
            fillUnRetMktDataGrid(unregisteredStartdateTypeInDatePicker.Value.Value, unregisteredEnddateTypeInDatePicker.Value.Value)
        End Sub

        Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
            Dim startdate, endDate As DateTime
            startdateTypeInDatePicker.Value = System.DateTime.Today.AddMonths(-1)
            enddateTypeInDatePicker.Value = System.DateTime.Today.AddDays(1)
            startdate = startdateTypeInDatePicker.Value.Value
            endDate = enddateTypeInDatePicker.Value.Value
            loadUnprocessVehicle(startdate, endDate)
        End Sub

        Private Sub ReviewTabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ReviewTabControl.SelectedIndexChanged
            If ReviewTabControl.SelectedIndex = 2 Then
                Dim startdate, endDate As DateTime
                startdateTypeInDatePicker.Value = System.DateTime.Today.AddMonths(-1)
                enddateTypeInDatePicker.Value = System.DateTime.Today.AddDays(1)
                startdate = startdateTypeInDatePicker.Value.Value
                endDate = enddateTypeInDatePicker.Value.Value
                loadUnprocessVehicle(startdate, endDate)
            End If
        End Sub

        Private Sub buttonExportToExcel_Click(sender As Object, e As EventArgs) Handles buttonExportToExcel.Click
            If retMktDataGridView Is Nothing OrElse retMktDataGridView.RowCount <= 0 Then
                MsgBox("Please Load Data for Export.")
                Exit Sub
            End If
            Dim FileToOpen As String
            FileToOpen = Processor.DataGridViewToExcel(retMktDataGridView)
            If String.IsNullOrEmpty(FileToOpen) = False Then
                Dim p As Process
                p.Start(FileToOpen)
            End If

        End Sub
        Private Sub loadNewRetailerForm(ByVal e As DataGridViewCellEventArgs)
            Dim vehicleId As Integer
            Dim newRetailer As String

            If e.RowIndex < 0 Then Exit Sub

            If Integer.TryParse(NewRetailerDataGridView.Rows(e.RowIndex).Cells("VehicleIdDataGridViewTextBoxColumn").Value.ToString(), vehicleId) = False Then
                MessageBox.Show("Unable to find Vehicle Id from selected row. Cannot load Vehicle status report screen." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            newRetailer = NewRetailerDataGridView.Rows(e.RowIndex).Cells("RetailerDataGridViewTextBoxColumn").Value.ToString

            Dim newRetailerForm As NewRetailerForm
            Dim startDate As DateTime
            Dim endDate As DateTime
            Dim mktid As Integer

            newRetailerForm = New NewRetailerForm()
            newRetailerForm.Init(FormStateEnum.View)
            newRetailerForm.ApplyUserCredentials()
            newRetailerForm.AddDefaultSelectValueToListBox(newRetailer)
            newRetailerForm.ShowDialog()

            startDate = newRetFromTypeInDatePicker.Value.Value
            endDate = newRetToTypeInDatePicker.Value.Value
            If newRetMktComboBox.SelectedValue Is Nothing OrElse newRetMktComboBox.SelectedValue Is DBNull.Value Then
                mktid = 0
            Else
                mktid = CType(newRetMktComboBox.SelectedValue, Integer)
            End If
            newRetDataGrid(startDate, endDate, mktid)
            fillUnRetMktDataGrid(unregisteredStartdateTypeInDatePicker.Value.Value, unregisteredEnddateTypeInDatePicker.Value.Value)

            newRetailerForm = Nothing
        End Sub

        Private Sub NewRetailerDataGridView_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles NewRetailerDataGridView.CellContentDoubleClick
   
            Me.loadNewRetailerForm(e)

        End Sub

        Private Sub newRetSearchButton_Click(sender As Object, e As EventArgs) Handles newRetSearchButton.Click
            Dim startDate As DateTime
            Dim endDate As DateTime
            Dim mktid As Integer
            Dim elements As String()
            Dim i As Integer
            Dim MediaView As DataView = New DataView(Processor.Data.NewRetailers)

            startDate = newRetFromTypeInDatePicker.Value.Value
            endDate = newRetToTypeInDatePicker.Value.Value
            ReDim elements(newReviewStatusListBox.SelectedItems.Count - 1)

            For Each Item As DataRowView In newReviewStatusListBox.SelectedItems
                elements(i) = Item.Item("codeid").ToString
                i = i + 1
            Next
            Dim codeId As String = String.Join(",", elements)

            If newRetMktComboBox.SelectedValue Is Nothing OrElse newRetMktComboBox.SelectedValue Is DBNull.Value Then
                mktid = 0
            Else
                mktid = CType(newRetMktComboBox.SelectedValue, Integer)
            End If
            If String.IsNullOrEmpty(codeId) = True Then
                newRetDataGrid(startDate, endDate, mktid)
            Else
                newRetCodeIdDataGrid(startDate, endDate, mktid, codeId)
            End If
        End Sub


        Private Sub NewRetailerDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles NewRetailerDataGridView.CellDoubleClick
        
            Me.loadNewRetailerForm(e)
           
        End Sub

        Private Sub NewRetRefreshButton_Click(sender As Object, e As EventArgs) Handles NewRetRefreshButton.Click

            Me.clearNewRetailer()
        End Sub

        Private Sub wrongVersionButton_Click(sender As Object, e As EventArgs) Handles wrongVersionButton.Click
            Dim vehicleId, selectedRowIndex As Integer
            Dim myIndexForm As New IndexForm
            Dim userResponse As DialogResult
            Dim startDate As DateTime
            Dim endDate As DateTime
            Dim MediaView As DataView = New DataView(Processor.Data.Vehicle)
            Dim selectedVehicleQuery As System.Collections.Generic.IEnumerable(Of Integer)


                userResponse = MessageBox.Show("Are you sure, you want to mark selected vehicle as Wronng Version ?" _
                                               , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)


            If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

            selectedVehicleQuery = From r In reviewDataGridView.SelectedRows.Cast(Of DataGridViewRow)() _
                                   Select CType(r.Cells("VehicleId").Value, Integer)


            MarkVehiclesAsWrongVersion(selectedVehicleQuery.ToArray())
       

            startDate = startdateTypeInDatePicker.Value.Value
            endDate = enddateTypeInDatePicker.Value.Value
            loadUnprocessVehicle(startDate, endDate)


            selectedVehicleQuery = Nothing
        End Sub
    End Class

End Namespace
