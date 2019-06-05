Imports System.ComponentModel
Namespace UI

    Public Class AddressMappingForm
        Implements IForm

#Region "Properties"
        Public AddMappingobj As New Processors.AddrMapping
        Public AddrList As New BindingList(Of Processors.AddrMapping)

        Private ACRetdt As New System.Data.DataTable()
        Private MTRetdt As New System.Data.DataTable()
        Private MTMktDT As New System.Data.DataTable()
        Private ImportTypedt As New System.Data.DataTable()
        Private dtpriority As New System.Data.DataTable()
        Private AC_MktDT As New System.Data.DataTable() 'LP430

        Private bsACRetailer As New BindingSource()
        Private bsMTRetailer As New BindingSource()
        Private bsMTMkt As New BindingSource()
        Private bsACMkt As New BindingSource()
        Private bsImportType As New BindingSource()

        Private rwAftAltered As Boolean = False
        Private rwToBeDeleted As String = ""
        Private deletedcount As Integer = 0
        Private RecUpdatecnt As Integer = 0
        Private RecEnddated As String = ""
        Private selectedCount As Integer = 0
        Private hits As Integer

#End Region

#Region "IForm Implementation:"

        Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials

        Private Property FormState As FormStateEnum

        Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

        End Sub

        Public Event FormInitialized() Implements IForm.FormInitialized

        Public Sub Init(formStatus As FormStateEnum) Implements IForm.Init
            Me.SuspendLayout()

            RaiseEvent InitializingForm()
            Processor.Initialize()

            Me.FormState = formStatus

            LoadFilters()
            AddMappingDGV.AutoGenerateColumns = False

        End Sub

        Public Event InitializingForm() Implements IForm.InitializingForm

        Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied
#End Region

        Private ReadOnly Property Processor() As Processors.AddrMapping
            Get
                Return AddMappingobj
            End Get
        End Property

        Private Sub AddressMappingForm_Load(sender As Object, e As EventArgs) Handles Me.Load
            Me.ResumeLayout(True) 'Resume the laygout that was suspended in the Init
            PopulateGrid() 'Load default combox values for new row
        End Sub

        Private Sub LoadFilters()
            Dim dsfilter As DataSet = AddMappingobj.GetAddressFilters()
            ACRetdt = dsfilter.Tables(0)
            Dim ACRetdr As DataRow = ACRetdt.NewRow()
            ACRetdr("company_nm") = ""
            ACRetdr("retailer_i") = -1
            ACRetdt.Rows.InsertAt(ACRetdr, 0)

            With ACRetComboBox
                .DataSource = ACRetdt
                .DisplayMember = "company_nm"
                .ValueMember = "retailer_i"
            End With


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
            Dim Importdr As DataRow = ImportTypedt.NewRow()
            Importdr("CodeType") = ""
            Importdr("codeID") = -1
            ImportTypedt.Rows.InsertAt(Importdr, 0)

            With PhaseTypeComboBox
                .DataSource = ImportTypedt
                .DisplayMember = "CodeType"
                .ValueMember = "codeID"
            End With
            If dsfilter.Tables.Count > 4 Then
                dtpriority = dsfilter.Tables(4) 'allow additional priority to be added
            End If
            AC_MktDT = dsfilter.Tables(5)
            Dim ACMktdr As DataRow = AC_MktDT.NewRow()
            ACMktdr("Descrip") = ""
            ACMktdr("MktID") = -1
            AC_MktDT.Rows.InsertAt(ACMktdr, 0)

        End Sub

        Private Sub PopulateGrid()
            Try
                Dim StoreID As Integer = 0
                If Not txtbxStoreID.Text = "" Then
                    StoreID = Integer.Parse(txtbxStoreID.Text)
                End If

                Dim ResultSet As DataSet = AddMappingobj.GetMappedAddress(CInt(ACRetComboBox.SelectedValue.ToString()), CInt(MTRetComboBox.SelectedValue.ToString()),
                                                                          CInt(PhaseTypeComboBox.SelectedValue.ToString()), CInt(MTMktComboBox.SelectedValue.ToString()), StoreID)

                AddrList.Clear()
                If ResultSet.Tables.Count > 0 Then

                    If ActiveAddrCheckBox.Checked Then
                        AddrList = AddMappingobj.PopulateAddrGrid(ResultSet.Tables(0))
                    Else
                        AddrList = AddMappingobj.PopulateAddrGrid(ResultSet.Tables(0).Select("EndDT is null").CopyToDataTable)
                    End If
                End If


                bsACRetailer.DataSource = ACRetdt.Copy()
                With AC_AdvertiserCol
                    .DataPropertyName = "AC_retID"
                    .DataSource = bsACRetailer
                    .DisplayMember = "company_nm"
                    .ValueMember = "retailer_i"
                    .FlatStyle = FlatStyle.Flat
                End With

                bsMTRetailer.DataSource = MTRetdt.Copy()
                With MT_AdvertiserCol
                    .DataPropertyName = "MT_RetID"
                    .DataSource = bsMTRetailer
                    .DisplayMember = "Descrip"
                    .ValueMember = "RetID"
                    .FlatStyle = FlatStyle.Flat
                End With

                bsMTMkt.DataSource = MTMktDT.Copy()
                With MT_MarketCol
                    .DataPropertyName = "MT_MktID"
                    .DataSource = bsMTMkt
                    .DisplayMember = "Descrip"
                    .ValueMember = "MktID"
                    .FlatStyle = FlatStyle.Flat
                End With


                bsACMkt.DataSource = AC_MktDT.Copy()
                With AC_MarketCol
                    .DataPropertyName = "AC_MktID"
                    AC_MarketCol.DisplayMember = "Descrip"
                    AC_MarketCol.ValueMember = "MktID"
                    .FlatStyle = FlatStyle.Flat

                    AC_MarketCol.DataSource = bsACMkt
                End With

                Dim dtImportType As New DataTable
                dtImportType = ImportTypedt.Copy()
                Dim Importdr As DataRow = dtImportType.NewRow()
                Importdr("CodeType") = ""
                Importdr("CodeId") = 0
                dtImportType.Rows.RemoveAt(0)
                dtImportType.Rows.InsertAt(Importdr, 0)
                bsImportType.DataSource = dtImportType
                With ImportTypeCol
                    .DataPropertyName = "ImportTypeID"
                    .DataSource = bsImportType
                    .DisplayMember = "CodeType"
                    .ValueMember = "CodeId"
                    .FlatStyle = FlatStyle.Flat
                End With

                Dim dtMedia As New DataTable
                dtMedia = AddMappingobj.GetMedia().Tables(0)
                Dim Mediadr As DataRow = dtMedia.NewRow()
                Mediadr("Descrip") = ""
                Mediadr("MediaID") = 0
                dtMedia.Rows.InsertAt(Mediadr, 0)

                With ImportMediaIDCol
                    .DataSource = dtMedia
                    .DataPropertyName = "ImportMediaID"
                    .ValueMember = "MediaID"
                    .DisplayMember = "Descrip"
                    .FlatStyle = FlatStyle.Flat
                End With

                Dim dtBoolValues As New DataTable
                dtBoolValues.Columns.Add("Value", GetType(String))
                dtBoolValues.Rows.Add("True")
                dtBoolValues.Rows.Add("False")
                dtBoolValues.AcceptChanges()

                With FVRequiredCol
                    '    .DataSource = dtBoolValues
                    .DataPropertyName = "FVRequired"
                    '    .ValueMember = "Value"
                    '    .DisplayMember = "Value"
                    '    .FlatStyle = FlatStyle.Flat
                End With



                With IsMarketMapCol
                    .DataSource = dtBoolValues.Copy
                    .DataPropertyName = "IsMarketMap"
                    .ValueMember = "Value"
                    .DisplayMember = "Value"
                    .FlatStyle = FlatStyle.Flat
                End With

                Dim dt As New DataTable
                If ResultSet.Tables.Count < 1 Then
                    dt = Nothing
                Else
                    dt = ResultSet.Tables(0).DefaultView.ToTable(True, "store_i")
                    dt.AcceptChanges()
                End If

                With store_iCol
                    .DataSource = dt
                    .DisplayMember = "store_i"
                    .ValueMember = "Store_i"
                    .FlatStyle = FlatStyle.Flat
                End With

                'Dim dtpriority As New DataTable
                If dtpriority.Rows.Count = 0 Then
                    dtpriority.Columns.Add("Ranking", GetType(Integer))
                    dtpriority.Rows.Add(1)
                    dtpriority.Rows.Add(2)
                    dtpriority.Rows.Add(3)
                    dtpriority.AcceptChanges()
                End If


                With DistinctionCol
                    .DataSource = dtpriority
                    .DisplayMember = "Ranking"
                    .ValueMember = "Ranking"
                    .FlatStyle = FlatStyle.Flat
                End With

                'If AddrList.Count = 0 Then
                '    AddMappingDGV.DataSource = Nothing
                'Else
                AddMappingDGV.DataSource = AddrList
                'End If

                AddMappingDGV.AutoResizeColumns()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Sub LoadStores(ByVal e As Integer)
            Try
                Using cell As DataGridViewComboBoxCell = CType(AddMappingDGV.Rows(e).Cells("store_iCol"), DataGridViewComboBoxCell)

                    Dim currVal As Object = cell.Value
                    Dim dt As New DataTable
                    Dim retid As Integer = CInt(AddMappingDGV.Rows(e).Cells("AC_AdvertiserCol").Value)
                    dt = AddMappingobj.GetRetStores(retid).Tables(0)

                    cell.DataSource = dt
                    cell.DisplayMember = "store_i"
                    cell.ValueMember = "store_i"

                    If IsNumeric(currVal) Then
                        Dim foundRow() As DataRow
                        foundRow = dt.Select("store_i = " + currVal.ToString())
                        If foundRow.Length > 0 Then
                            cell.Value = currVal
                        End If
                    End If

                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Sub SetMediaBehaviour(ByVal e As Integer)
            If Not AddMappingDGV.Rows(e).Cells("ImportTypeCol").EditedFormattedValue.ToString.Contains("MT-Scraping") Then
                AddMappingDGV.Rows(e).Cells("ImportMediaIDCol").Value = 0
                AddMappingDGV.Rows(e).Cells("ImportMediaIDCol").ReadOnly = True
            Else
                AddMappingDGV.Rows(e).Cells("ImportMediaIDCol").ReadOnly = False
            End If
        End Sub

#Region "Events"
        Private Sub AddMappingDGV_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles AddMappingDGV.CellBeginEdit
            If AddMappingDGV.Columns(e.ColumnIndex).Name = "store_iCol" Then
                LoadStores(e.RowIndex)
            End If
        End Sub

        Private Sub AddMappingDGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles AddMappingDGV.CellEndEdit
            If IsDBNull(AddMappingDGV.Rows(e.RowIndex).Cells(e.ColumnIndex).Value) Then
                Exit Sub
            End If
            '9.9.16 deactivate media cell if not MT scraping phase
            If AddMappingDGV.Columns(e.ColumnIndex).Name = "ImportTypeCol" Then
                SetMediaBehaviour(e.RowIndex)
            ElseIf AddMappingDGV.Columns(e.ColumnIndex).Name = "store_iCol" And Not Equals(AddMappingDGV.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, 0) Then 'populate the store inforamtion to the other cells 

                Using store_iCell As DataGridViewComboBoxCell = CType(AddMappingDGV.Rows(e.RowIndex).Cells("store_iCol"), DataGridViewComboBoxCell)
                    Dim dt As New DataTable
                    If store_iCell.DataSource IsNot Nothing Then

                        dt = TryCast(store_iCell.DataSource, DataTable).Copy()
                        Dim filterexpression As String = "store_i=" + store_iCell.Value.ToString
                        dt.DefaultView.RowFilter = "store_i=" + store_iCell.Value.ToString
                        Dim storedr As DataRow() = dt.Select(filterexpression)

                        If storedr.Length > 0 Then 'populate store information 
                            Using AddressCell As DataGridViewTextBoxCell = CType(AddMappingDGV.Rows(e.RowIndex).Cells("Store_AddressCol"), DataGridViewTextBoxCell)
                                AddressCell.Value = RTrim(storedr(0)(2).ToString)
                            End Using
                            Using CityCell As DataGridViewTextBoxCell = CType(AddMappingDGV.Rows(e.RowIndex).Cells("Store_CityCol"), DataGridViewTextBoxCell)
                                CityCell.Value = RTrim(storedr(0)(3).ToString)
                            End Using
                            Using StateCell As DataGridViewTextBoxCell = CType(AddMappingDGV.Rows(e.RowIndex).Cells("Store_StateCol"), DataGridViewTextBoxCell)
                                StateCell.Value = RTrim(storedr(0)(4).ToString)
                            End Using
                            Using ZipCell As DataGridViewTextBoxCell = CType(AddMappingDGV.Rows(e.RowIndex).Cells("Store_ZipCol"), DataGridViewTextBoxCell)
                                ZipCell.Value = RTrim(storedr(0)(5).ToString)
                            End Using
                            Using Market As DataGridViewComboBoxCell = CType(AddMappingDGV.Rows(e.RowIndex).Cells("IsMarketMapCol"), DataGridViewComboBoxCell)
                                Market.Value = RTrim("False")
                            End Using
                        End If
                    End If
                End Using
            ElseIf AddMappingDGV.Columns(e.ColumnIndex).Name = "IsMarketMapCol" AndAlso AddMappingDGV.Rows(e.RowIndex).Cells("IsMarketMapCol").Value.ToString = "True" Then
                Using store_iCell As DataGridViewComboBoxCell = CType(AddMappingDGV.Rows(e.RowIndex).Cells("store_iCol"), DataGridViewComboBoxCell)
                    Dim dt As New DataTable
                    If store_iCell.DataSource IsNot Nothing Then
                        store_iCell.Value = 0
                        Using AddressCell As DataGridViewTextBoxCell = CType(AddMappingDGV.Rows(e.RowIndex).Cells("Store_AddressCol"), DataGridViewTextBoxCell)
                            AddressCell.Value = ""
                        End Using
                        Using CityCell As DataGridViewTextBoxCell = CType(AddMappingDGV.Rows(e.RowIndex).Cells("Store_CityCol"), DataGridViewTextBoxCell)
                            CityCell.Value = ""
                        End Using
                        Using StateCell As DataGridViewTextBoxCell = CType(AddMappingDGV.Rows(e.RowIndex).Cells("Store_StateCol"), DataGridViewTextBoxCell)
                            StateCell.Value = ""
                        End Using
                        Using ZipCell As DataGridViewTextBoxCell = CType(AddMappingDGV.Rows(e.RowIndex).Cells("Store_ZipCol"), DataGridViewTextBoxCell)
                            ZipCell.Value = ""
                        End Using
                    End If
                End Using
            End If

            If AddMappingDGV.Columns(e.ColumnIndex).Name = "store_iCol" And Equals(AddMappingDGV.Rows(e.RowIndex).Cells("store_iCol").Value, 0) Then
                Using Market As DataGridViewComboBoxCell = CType(AddMappingDGV.Rows(e.RowIndex).Cells("IsMarketMapCol"), DataGridViewComboBoxCell)
                    Market.Value = RTrim("True")
                End Using
            End If
        End Sub
        Private Sub AddMappingDGV_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles AddMappingDGV.CurrentCellDirtyStateChanged
            Try
                Dim CurrRowIdx As Integer = AddMappingDGV.CurrentRow.Index
                Dim IsTicked As Boolean = CBool(AddMappingDGV.Rows(CurrRowIdx).Cells(0).Value)
                If (AddMappingDGV.IsCurrentRowDirty) Then

                    If Not Equals(AddMappingDGV.Rows(CurrRowIdx).Cells("EndDtCol").Value, Nothing) Then
                        RecEnddated.Replace(CStr(AddMappingDGV.Rows(CurrRowIdx).Cells("Addr_ID").Value) + ",", "")
                        RecEnddated = RecEnddated + CStr(AddMappingDGV.Rows(CurrRowIdx).Cells("Addr_ID").Value) + ","
                    Else
                        RecEnddated.Replace(CStr(AddMappingDGV.Rows(CurrRowIdx).Cells("Addr_ID").Value) + ",", "")
                    End If

                    If Not (IsTicked) Then
                        RecUpdatecnt = RecUpdatecnt + 1
                        Updatedlbl.Text = "Records to be Updated:" + CStr(RecUpdatecnt)
                        Updatedlbl.Visible = True
                    End If



                    AddMappingDGV(0, CurrRowIdx).Value = True
                    AddMappingDGV.Rows(CurrRowIdx).DefaultCellStyle.BackColor = Color.Honeydew
                    rwAftAltered = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Sub AddMappingDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles AddMappingDGV.CellClick
            If e.ColumnIndex < 0 Or e.RowIndex < 0 Then
                Exit Sub
            End If
            If AddMappingDGV.Columns(e.ColumnIndex).Name = "store_iCol" Then
                LoadStores(e.RowIndex)
            End If
            If AddMappingDGV.Columns(e.ColumnIndex).Name = "ImportMediaIDCol" Then
                SetMediaBehaviour(e.RowIndex)
            End If
        End Sub

        Private Sub AddMappingDGV_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles AddMappingDGV.DefaultValuesNeeded
            With e.Row
                .Cells("EditCol").Value = 0
                .Cells("AC_AdvertiserCol").Value = 0
                .Cells("AC_RetIDCol").Value = 0
                .Cells("MT_AdvertiserCol").Value = 0
                .Cells("MT_RetIDCol").Value = 0
                .Cells("MT_MarketCol").Value = 0
                .Cells("MT_MktIDCol").Value = 0
                .Cells("store_iCol").Value = 0
                .Cells("Store_AddressCol").Value = ""
                .Cells("Store_CityCol").Value = ""
                .Cells("Store_StateCol").Value = ""
                .Cells("Store_ZipCol").Value = ""
                .Cells("StartDtCol").Value = CType(Nothing, Date?)
                .Cells("EndDtCol").Value = CType(Nothing, Date?)
                .Cells("hold_daysCol").Value = 0
                .Cells("DistinctionCol").Value = 1
                .Cells("ImportTypeCol").Value = 0
                .Cells("ImportMediaIDCol").Value = 0
                .Cells("FVRequiredCol").Value = False
                .Cells("IsMarketMapCol").Value = False
                .Cells("Addr_ID").Value = 0
                .Cells("AC_MarketCol").Value = ""
                .Cells("AC_MktIDCol").Value = 0

            End With
        End Sub
        Private Sub AddMappingDGV_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles AddMappingDGV.DataError

            Try
                If IsDBNull(AddMappingDGV.Rows(e.RowIndex).Cells("store_iCol").Value) Then
                    Exit Sub
                End If
                If IsNothing(AddMappingDGV.CurrentCell) Then
                    Exit Sub
                End If

                If (AddMappingDGV.CurrentCell.ColumnIndex = 14 Or AddMappingDGV.CurrentCell.ColumnIndex = 15) Then
                    '  AddMappingDGV.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = DBNull.Value
                    Using DateCell As MCAP.UI.Controls.CalendarCell = CType(AddMappingDGV.CurrentCell, MCAP.UI.Controls.CalendarCell)
                        DateCell.Value = CType(Nothing, Date?)
                        Dim NewSender As Object
                        AddMappingDGV_CurrentCellDirtyStateChanged(NewSender, New EventArgs())
                    End Using
                End If
                Try
                    If e.ColumnIndex = 18 And Not IsDBNull(AddMappingDGV.Rows(e.RowIndex).Cells("store_iCol").Value) Then 'ImportTypeCol incase there exists a record with 0
                        Using ImportTypeCol As DataGridViewComboBoxCell = CType(AddMappingDGV.Rows(e.RowIndex).Cells("ImportTypeCol"), DataGridViewComboBoxCell)
                            ImportTypeCol.Value = RTrim("")
                        End Using
                        ''   If IsDBNull(AddMappingDGV.Rows(e.RowIndex).Cells("ImportTypeCol").Value) Then
                        Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Sub AddMappingDGV_KeyDown(sender As Object, e As KeyEventArgs) Handles AddMappingDGV.KeyDown
            If (e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back) And (AddMappingDGV.CurrentCell.ColumnIndex = 12 Or AddMappingDGV.CurrentCell.ColumnIndex = 13) Then
                Using DateCell As MCAP.UI.Controls.CalendarCell = CType(AddMappingDGV.CurrentCell, MCAP.UI.Controls.CalendarCell)
                    DateCell.Value = CType(Nothing, Date?)
                    Dim NewSender As Object
                    AddMappingDGV_CurrentCellDirtyStateChanged(NewSender, New EventArgs())
                End Using
            ElseIf e.KeyCode = Keys.Delete Then
                Me.hits = 0
                Me.selectedCount = Me.AddMappingDGV.SelectedRows.Count
            ElseIf e.KeyCode = Keys.V And AddMappingDGV.CurrentCell.ColumnIndex = 13 Then


            End If
        End Sub

        Private Sub AddMappingDGV_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles AddMappingDGV.UserAddedRow

            If AddMappingDGV("AC_AdvertiserCol", e.Row.Index - 1).Value IsNot Nothing AndAlso CInt(AddMappingDGV("AC_AdvertiserCol", e.Row.Index - 1).Value.ToString) = 0 And AddMappingDGV.DataSource IsNot Nothing Then
                'BIND THE NEW ROW SO WE CAN FILTER THE STORE LIST used for new rows added once a retailer is selected.
                Me.AddMappingDGV.BindingContext(Me.AddMappingDGV.DataSource, Me.AddMappingDGV.DataMember).EndCurrentEdit()
            End If
        End Sub

        Private Sub AddMappingDGV_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles AddMappingDGV.UserDeletingRow
            If Me.hits = 0 Then 'To prevent the confirmation message from popping up for each row to be deleted when deleting multiple rows
                e.Cancel = MessageBox.Show("Are you sure you wish to delete the current selection?" & vbNewLine & " If yes changes will be applied on your next save", "Delete Record", MessageBoxButtons.YesNo) <> Windows.Forms.DialogResult.Yes
                Me.hits = Me.AddMappingDGV.SelectedRows.Count
            End If

            If (e.Cancel) Then
                deletedcount = 0
                Deletedlbl.Visible = False
                Me.hits = -1 ' To prevent the confirmation message from popping out for each row to be deleted when deleting multiple rows
                e.Cancel = True
            ElseIf Me.hits >= Me.AddMappingDGV.SelectedRows.Count Then
                rwAftAltered = True
                Dim rwIndex As Integer = e.Row.Index
                rwToBeDeleted = rwToBeDeleted + CStr(AddMappingDGV.Rows(rwIndex).Cells("Addr_ID").Value) + ","
                deletedcount = deletedcount + 1
                Deletedlbl.Text = "Records to be Deleted:" + CStr(deletedcount)
                Deletedlbl.Visible = True
            Else
                e.Cancel = True
            End If

        End Sub

        Private Sub AddMappingDGV_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles AddMappingDGV.RowValidating
            Try
                If AddMappingDGV.Item("ImportTypeCol", e.RowIndex).EditedFormattedValue.ToString.Contains("Phase 2") And AddMappingDGV.Item("ImportMediaIDCol", e.RowIndex).EditedFormattedValue.ToString = "" Then
                    MsgBox("Please select a valid Media type", MsgBoxStyle.Critical, "Incorrect Media type")
                    e.Cancel = True
                    AddMappingDGV.CurrentCell = AddMappingDGV.CurrentRow.Cells("ImportMediaIDCol")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Sub LoadButton_Click(sender As Object, e As EventArgs) Handles LoadButton.Click
            Try
                If ACRetComboBox.SelectedIndex = -1 Or PhaseTypeComboBox.SelectedIndex = -1 Or MTRetComboBox.SelectedIndex = -1 Or MTMktComboBox.SelectedIndex = -1 Then
                    MessageBox.Show("Current selection is not available")
                    Exit Sub
                End If

                If ACRetComboBox.SelectedIndex = 0 And PhaseTypeComboBox.SelectedIndex = 0 And MTRetComboBox.SelectedIndex = 0 And MTMktComboBox.SelectedIndex = 0 And txtbxStoreID.Text = "" Then
                    MsgBox("Please apply a filter in order to load results", MsgBoxStyle.Information, "Load")
                    ACRetComboBox.Focus()
                End If

                If rwAftAltered = True Then
                    If (MessageBox.Show("Do you wish to discard the changes made?", "Save Changes", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes) Then
                        rwAftAltered = False
                        Deletedlbl.Visible = False
                        Updatedlbl.Visible = False
                        deletedcount = 0
                        RecUpdatecnt = 0
                        rwToBeDeleted = ""
                    Else
                        Exit Sub
                    End If
                End If
                PopulateGrid()

            Catch ex As Exception

            End Try

        End Sub
        Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            Try
                If Not String.IsNullOrEmpty(rwToBeDeleted) Then
                    'Removing Deleted rows from DB
                    Dim EndsInComa As Boolean = rwToBeDeleted.EndsWith(",")
                    If EndsInComa Then
                        rwToBeDeleted = rwToBeDeleted.Trim().Remove(rwToBeDeleted.Length - 1)
                    End If
                    AddMappingobj.DeleteMappedAddress(rwToBeDeleted.TrimEnd)
                    rwToBeDeleted = ""
                    deletedcount = 0
                End If


                For Each a As Processors.AddrMapping In AddrList
                    'check for updates with enddates
                    If a.celledit And a.AC_RetID <> 0 And a.Addr_ID > 0 And RecEnddated.Contains(a.Addr_ID.ToString()) Then
                        AddMappingobj.UpdateMappedAddress(a, 1)
                        RecUpdatecnt = 0
                        Updatedlbl.Visible = False
                    End If
                Next

                For Each a As Processors.AddrMapping In AddrList
                    'check for updates and save without enddates
                    If a.celledit And a.AC_RetID <> 0 And a.Addr_ID > 0 And Not RecEnddated.Contains(a.Addr_ID.ToString()) Then
                        AddMappingobj.UpdateMappedAddress(a, 1)
                        RecUpdatecnt = 0
                        Updatedlbl.Visible = False
                    End If
                Next
                For Each a As Processors.AddrMapping In AddrList
                    'Check for Inserts and save
                    If a.celledit And a.AC_RetID <> 0 And a.Addr_ID = 0 Then
                        AddMappingobj.UpdateMappedAddress(a, 1)
                        RecUpdatecnt = 0
                        Updatedlbl.Visible = False
                    End If
                Next


                AddMappingDGV.Rows.Clear()
                RecEnddated = ""
                rwAftAltered = False
                Deletedlbl.Visible = False
            Catch ex As Exception
                If ex.Message.Contains("expects parameter") Then
                    MsgBox("Please ensure all fields have been properly updated", MsgBoxStyle.Exclamation, "Save")
                Else
                    MsgBox(ex.Message, MsgBoxStyle.Information, "Unable to Save")
                End If

            End Try
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Sub
        Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
            AddMappingDGV.Rows.Clear()
            ACRetComboBox.SelectedIndex = 0
            MTRetComboBox.SelectedIndex = 0
            MTMktComboBox.SelectedIndex = 0
            PhaseTypeComboBox.SelectedIndex = 0
            Deletedlbl.Visible = False
            Updatedlbl.Visible = False
            rwAftAltered = False
            deletedcount = 0
            RecUpdatecnt = 0
            rwToBeDeleted = ""
            txtbxStoreID.Text = ""
        End Sub

        Private Sub ACRetComboBox_DropDown(sender As Object, e As EventArgs) Handles ACRetComboBox.DropDown
            ACRetComboBox.AutoCompleteMode = AutoCompleteMode.None
            ACRetComboBox.AutoCompleteSource = AutoCompleteSource.None
        End Sub
        Private Sub ACRetComboBox_DropDownClosed(sender As Object, e As EventArgs) Handles ACRetComboBox.DropDownClosed
            ACRetComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            ACRetComboBox.AutoCompleteSource = AutoCompleteSource.ListItems
        End Sub

        Private Sub MTRetComboBox_DropDown(sender As Object, e As EventArgs) Handles MTRetComboBox.DropDown
            MTRetComboBox.AutoCompleteMode = AutoCompleteMode.None
            MTRetComboBox.AutoCompleteSource = AutoCompleteSource.None
        End Sub
        Private Sub MTRetComboBox_DropDownClosed(sender As Object, e As EventArgs) Handles MTRetComboBox.DropDownClosed
            MTRetComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            MTRetComboBox.AutoCompleteSource = AutoCompleteSource.ListItems
        End Sub
        Private Sub MTMktComboBox_DropDown(sender As Object, e As EventArgs) Handles MTMktComboBox.DropDown
            MTMktComboBox.AutoCompleteMode = AutoCompleteMode.None
            MTMktComboBox.AutoCompleteSource = AutoCompleteSource.None
        End Sub
        Private Sub MTMktComboBox_DropDownClosed(sender As Object, e As EventArgs) Handles MTMktComboBox.DropDownClosed
            MTMktComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            MTMktComboBox.AutoCompleteSource = AutoCompleteSource.ListItems
        End Sub
        Private Sub PhaseTypeComboBox_DropDown(sender As Object, e As EventArgs) Handles PhaseTypeComboBox.DropDown
            PhaseTypeComboBox.AutoCompleteMode = AutoCompleteMode.None
            PhaseTypeComboBox.AutoCompleteSource = AutoCompleteSource.None
        End Sub
        Private Sub PhaseTypeComboBox_DropDownClosed(sender As Object, e As EventArgs) Handles PhaseTypeComboBox.DropDownClosed
            PhaseTypeComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            PhaseTypeComboBox.AutoCompleteSource = AutoCompleteSource.ListItems
        End Sub
        Private Sub ACRetComboBox_LostFocus(sender As Object, e As EventArgs) Handles ACRetComboBox.LostFocus
            ACRetComboBox.AutoCompleteSource = AutoCompleteSource.ListItems 'resets the suggestion list when user wants to key up
        End Sub
        Private Sub MTMktComboBox_LostFocus(sender As Object, e As EventArgs) Handles ACRetComboBox.LostFocus
            MTMktComboBox.AutoCompleteSource = AutoCompleteSource.ListItems
        End Sub
        Private Sub PhaseTypeComboBox_LostFocus(sender As Object, e As EventArgs) Handles ACRetComboBox.LostFocus
            PhaseTypeComboBox.AutoCompleteSource = AutoCompleteSource.ListItems
        End Sub

        Private Sub AddMappingDGV_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles AddMappingDGV.EditingControlShowing
            If AddMappingDGV.CurrentCell.ColumnIndex = 7 Or AddMappingDGV.CurrentCell.ColumnIndex = 8 Then
                Dim cb As ComboBox
                If TypeOf e.Control Is ComboBox Then
                    cb = CType(e.Control, ComboBox)
                    cb.DropDownStyle = ComboBoxStyle.DropDown
                    cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                    cb.AutoCompleteSource = AutoCompleteSource.ListItems
                End If
            End If


        End Sub
#End Region

    End Class

End Namespace

