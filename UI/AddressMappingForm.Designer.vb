Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AddressMappingForm
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.AddMappingDGV = New System.Windows.Forms.DataGridView()
            Me.LoadButton = New System.Windows.Forms.Button()
            Me.ACRetComboBox = New System.Windows.Forms.ComboBox()
            Me.PhaseTypeComboBox = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.ActiveAddrCheckBox = New System.Windows.Forms.CheckBox()
            Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
            Me.Updatedlbl = New System.Windows.Forms.Label()
            Me.Deletedlbl = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtbxStoreID = New System.Windows.Forms.TextBox()
            Me.ResetButton = New System.Windows.Forms.Button()
            Me.SaveButton = New System.Windows.Forms.Button()
            Me.MTMktComboBox = New System.Windows.Forms.ComboBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.MTRetComboBox = New System.Windows.Forms.ComboBox()
            Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewComboBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CalendarColumn1 = New MCAP.UI.Controls.CalendarColumn()
            Me.CalendarColumn2 = New MCAP.UI.Controls.CalendarColumn()
            Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewComboBoxColumn4 = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewComboBoxColumn5 = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.EditCol = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            Me.AC_AdvertiserCol = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.AC_RetIDCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.MT_AdvertiserCol = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.MT_RetIDCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.MT_MarketCol = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.MT_MktIDCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.store_iCol = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.AC_MarketCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AC_MktIDcol = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Store_AddressCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Store_CityCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Store_StateCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Store_ZipCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.StartDtCol = New MCAP.UI.Controls.CalendarColumn()
            Me.EndDtCol = New MCAP.UI.Controls.CalendarColumn()
            Me.hold_daysCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DistinctionCol = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.ImportTypeCol = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.ImportMediaIDCol = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.CommentCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.FVRequiredCol = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IsMarketMapCol = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.Addr_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.AddMappingDGV, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox2.SuspendLayout()
            Me.FlowLayoutPanel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'AddMappingDGV
            '
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.AddMappingDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.AddMappingDGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AddMappingDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.AddMappingDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EditCol, Me.AC_AdvertiserCol, Me.AC_RetIDCol, Me.MT_AdvertiserCol, Me.MT_RetIDCol, Me.MT_MarketCol, Me.MT_MktIDCol, Me.store_iCol, Me.AC_MarketCol, Me.AC_MktIDcol, Me.Store_AddressCol, Me.Store_CityCol, Me.Store_StateCol, Me.Store_ZipCol, Me.StartDtCol, Me.EndDtCol, Me.hold_daysCol, Me.DistinctionCol, Me.ImportTypeCol, Me.ImportMediaIDCol, Me.CommentCol, Me.FVRequiredCol, Me.IsMarketMapCol, Me.Addr_ID})
            Me.AddMappingDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.AddMappingDGV.Location = New System.Drawing.Point(12, 127)
            Me.AddMappingDGV.Name = "AddMappingDGV"
            Me.AddMappingDGV.Size = New System.Drawing.Size(1285, 560)
            Me.AddMappingDGV.TabIndex = 0
            '
            'LoadButton
            '
            Me.LoadButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LoadButton.Location = New System.Drawing.Point(1019, 80)
            Me.LoadButton.Name = "LoadButton"
            Me.LoadButton.Size = New System.Drawing.Size(75, 23)
            Me.LoadButton.TabIndex = 7
            Me.LoadButton.Text = "Load"
            Me.LoadButton.UseVisualStyleBackColor = True
            '
            'ACRetComboBox
            '
            Me.ACRetComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.ACRetComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ACRetComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ACRetComboBox.FormattingEnabled = True
            Me.ACRetComboBox.Location = New System.Drawing.Point(85, 15)
            Me.ACRetComboBox.Name = "ACRetComboBox"
            Me.ACRetComboBox.Size = New System.Drawing.Size(191, 21)
            Me.ACRetComboBox.TabIndex = 1
            Me.ACRetComboBox.Tag = ""
            '
            'PhaseTypeComboBox
            '
            Me.PhaseTypeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.PhaseTypeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.PhaseTypeComboBox.FormattingEnabled = True
            Me.PhaseTypeComboBox.Location = New System.Drawing.Point(85, 43)
            Me.PhaseTypeComboBox.Name = "PhaseTypeComboBox"
            Me.PhaseTypeComboBox.Size = New System.Drawing.Size(191, 21)
            Me.PhaseTypeComboBox.TabIndex = 2
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(6, 17)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(71, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "AC Advertiser"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(6, 46)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(63, 13)
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "Import Type"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.ActiveAddrCheckBox)
            Me.GroupBox2.Controls.Add(Me.FlowLayoutPanel1)
            Me.GroupBox2.Controls.Add(Me.Label5)
            Me.GroupBox2.Controls.Add(Me.txtbxStoreID)
            Me.GroupBox2.Controls.Add(Me.ResetButton)
            Me.GroupBox2.Controls.Add(Me.SaveButton)
            Me.GroupBox2.Controls.Add(Me.PhaseTypeComboBox)
            Me.GroupBox2.Controls.Add(Me.Label2)
            Me.GroupBox2.Controls.Add(Me.MTMktComboBox)
            Me.GroupBox2.Controls.Add(Me.LoadButton)
            Me.GroupBox2.Controls.Add(Me.Label4)
            Me.GroupBox2.Controls.Add(Me.Label3)
            Me.GroupBox2.Controls.Add(Me.Label1)
            Me.GroupBox2.Controls.Add(Me.MTRetComboBox)
            Me.GroupBox2.Controls.Add(Me.ACRetComboBox)
            Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(1285, 109)
            Me.GroupBox2.TabIndex = 13
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Filter by "
            '
            'ActiveAddrCheckBox
            '
            Me.ActiveAddrCheckBox.AutoSize = True
            Me.ActiveAddrCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.ActiveAddrCheckBox.Location = New System.Drawing.Point(282, 72)
            Me.ActiveAddrCheckBox.Name = "ActiveAddrCheckBox"
            Me.ActiveAddrCheckBox.Size = New System.Drawing.Size(108, 17)
            Me.ActiveAddrCheckBox.TabIndex = 17
            Me.ActiveAddrCheckBox.Text = "Show All Address"
            Me.ActiveAddrCheckBox.UseVisualStyleBackColor = True
            '
            'FlowLayoutPanel1
            '
            Me.FlowLayoutPanel1.Controls.Add(Me.Updatedlbl)
            Me.FlowLayoutPanel1.Controls.Add(Me.Deletedlbl)
            Me.FlowLayoutPanel1.Location = New System.Drawing.Point(7, 96)
            Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
            Me.FlowLayoutPanel1.Size = New System.Drawing.Size(876, 20)
            Me.FlowLayoutPanel1.TabIndex = 16
            '
            'Updatedlbl
            '
            Me.Updatedlbl.AutoSize = True
            Me.Updatedlbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Updatedlbl.ForeColor = System.Drawing.Color.Green
            Me.Updatedlbl.Location = New System.Drawing.Point(3, 0)
            Me.Updatedlbl.Name = "Updatedlbl"
            Me.Updatedlbl.Size = New System.Drawing.Size(110, 13)
            Me.Updatedlbl.TabIndex = 11
            Me.Updatedlbl.Text = "Records Updated:"
            Me.Updatedlbl.Visible = False
            '
            'Deletedlbl
            '
            Me.Deletedlbl.AutoSize = True
            Me.Deletedlbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Deletedlbl.ForeColor = System.Drawing.Color.Red
            Me.Deletedlbl.Location = New System.Drawing.Point(119, 0)
            Me.Deletedlbl.Name = "Deletedlbl"
            Me.Deletedlbl.Size = New System.Drawing.Size(106, 13)
            Me.Deletedlbl.TabIndex = 10
            Me.Deletedlbl.Text = "Records Deleted:"
            Me.Deletedlbl.Visible = False
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(6, 77)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(46, 13)
            Me.Label5.TabIndex = 13
            Me.Label5.Text = "Store ID"
            '
            'txtbxStoreID
            '
            Me.txtbxStoreID.Location = New System.Drawing.Point(85, 70)
            Me.txtbxStoreID.Name = "txtbxStoreID"
            Me.txtbxStoreID.Size = New System.Drawing.Size(191, 20)
            Me.txtbxStoreID.TabIndex = 12
            '
            'ResetButton
            '
            Me.ResetButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ResetButton.Location = New System.Drawing.Point(1204, 80)
            Me.ResetButton.Name = "ResetButton"
            Me.ResetButton.Size = New System.Drawing.Size(75, 23)
            Me.ResetButton.TabIndex = 9
            Me.ResetButton.Text = "Reset"
            Me.ResetButton.UseVisualStyleBackColor = True
            '
            'SaveButton
            '
            Me.SaveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SaveButton.Location = New System.Drawing.Point(1113, 80)
            Me.SaveButton.Name = "SaveButton"
            Me.SaveButton.Size = New System.Drawing.Size(75, 23)
            Me.SaveButton.TabIndex = 8
            Me.SaveButton.Text = "Save changes "
            Me.SaveButton.UseVisualStyleBackColor = True
            '
            'MTMktComboBox
            '
            Me.MTMktComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.MTMktComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.MTMktComboBox.FormattingEnabled = True
            Me.MTMktComboBox.Location = New System.Drawing.Point(361, 40)
            Me.MTMktComboBox.Name = "MTMktComboBox"
            Me.MTMktComboBox.Size = New System.Drawing.Size(191, 21)
            Me.MTMktComboBox.TabIndex = 6
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(282, 17)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(73, 13)
            Me.Label4.TabIndex = 0
            Me.Label4.Text = "MT Advertiser"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(282, 46)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(59, 13)
            Me.Label3.TabIndex = 0
            Me.Label3.Text = "MT Market"
            '
            'MTRetComboBox
            '
            Me.MTRetComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.MTRetComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.MTRetComboBox.FormattingEnabled = True
            Me.MTRetComboBox.Location = New System.Drawing.Point(361, 14)
            Me.MTRetComboBox.Name = "MTRetComboBox"
            Me.MTRetComboBox.Size = New System.Drawing.Size(191, 21)
            Me.MTRetComboBox.TabIndex = 5
            '
            'DataGridViewComboBoxColumn1
            '
            Me.DataGridViewComboBoxColumn1.DataPropertyName = "AC_Advertiser"
            Me.DataGridViewComboBoxColumn1.HeaderText = "AC_Advertiser"
            Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
            Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.DataPropertyName = "AC_Advertiser"
            Me.DataGridViewTextBoxColumn1.HeaderText = "AC_Advertiser"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.Visible = False
            '
            'DataGridViewComboBoxColumn2
            '
            Me.DataGridViewComboBoxColumn2.DataPropertyName = "MT_Advertiser"
            Me.DataGridViewComboBoxColumn2.HeaderText = "MT_Advertiser"
            Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
            Me.DataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.DataPropertyName = "MT_Advertiser"
            Me.DataGridViewTextBoxColumn2.HeaderText = "AC_RetID"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.Visible = False
            '
            'DataGridViewComboBoxColumn3
            '
            Me.DataGridViewComboBoxColumn3.DataPropertyName = "MT_Market"
            Me.DataGridViewComboBoxColumn3.HeaderText = "MT_Market"
            Me.DataGridViewComboBoxColumn3.Name = "DataGridViewComboBoxColumn3"
            Me.DataGridViewComboBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewComboBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.DataPropertyName = "MT_RetID"
            Me.DataGridViewTextBoxColumn3.HeaderText = "MT_Advertiser"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.Visible = False
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.DataPropertyName = "MT_Market"
            Me.DataGridViewTextBoxColumn4.HeaderText = "MT_RetID"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            '
            'DataGridViewTextBoxColumn5
            '
            Me.DataGridViewTextBoxColumn5.DataPropertyName = "MT_MktID"
            Me.DataGridViewTextBoxColumn5.HeaderText = "MT_Market"
            Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
            Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'DataGridViewTextBoxColumn6
            '
            Me.DataGridViewTextBoxColumn6.DataPropertyName = "Store_Address"
            Me.DataGridViewTextBoxColumn6.HeaderText = "MT_MktID"
            Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
            Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'DataGridViewTextBoxColumn7
            '
            Me.DataGridViewTextBoxColumn7.DataPropertyName = "Store_City"
            Me.DataGridViewTextBoxColumn7.HeaderText = "Store_Address"
            Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
            '
            'DataGridViewTextBoxColumn8
            '
            Me.DataGridViewTextBoxColumn8.DataPropertyName = "Store_State"
            Me.DataGridViewTextBoxColumn8.HeaderText = "Store_City"
            Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
            Me.DataGridViewTextBoxColumn8.Visible = False
            '
            'CalendarColumn1
            '
            Me.CalendarColumn1.DataPropertyName = "StartDt"
            Me.CalendarColumn1.HeaderText = "StartDt"
            Me.CalendarColumn1.Name = "CalendarColumn1"
            Me.CalendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.CalendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'CalendarColumn2
            '
            Me.CalendarColumn2.DataPropertyName = "EndDt"
            Me.CalendarColumn2.HeaderText = "EndDt"
            Me.CalendarColumn2.Name = "CalendarColumn2"
            Me.CalendarColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.CalendarColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'DataGridViewTextBoxColumn9
            '
            Me.DataGridViewTextBoxColumn9.DataPropertyName = "Store_Zip"
            Me.DataGridViewTextBoxColumn9.HeaderText = "Store_State"
            Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
            '
            'DataGridViewTextBoxColumn10
            '
            Me.DataGridViewTextBoxColumn10.DataPropertyName = "store_i"
            Me.DataGridViewTextBoxColumn10.HeaderText = "Store_Zip"
            Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
            '
            'DataGridViewComboBoxColumn4
            '
            Me.DataGridViewComboBoxColumn4.DataPropertyName = "ImportType"
            Me.DataGridViewComboBoxColumn4.HeaderText = "ImportType"
            Me.DataGridViewComboBoxColumn4.Name = "DataGridViewComboBoxColumn4"
            Me.DataGridViewComboBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewComboBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'DataGridViewTextBoxColumn11
            '
            Me.DataGridViewTextBoxColumn11.DataPropertyName = "StartDt"
            Me.DataGridViewTextBoxColumn11.HeaderText = "store_i"
            Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
            '
            'DataGridViewComboBoxColumn5
            '
            Me.DataGridViewComboBoxColumn5.DataPropertyName = "FVRequired"
            Me.DataGridViewComboBoxColumn5.HeaderText = "FVRequired"
            Me.DataGridViewComboBoxColumn5.Items.AddRange(New Object() {"0", "1"})
            Me.DataGridViewComboBoxColumn5.Name = "DataGridViewComboBoxColumn5"
            Me.DataGridViewComboBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DataGridViewComboBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'DataGridViewTextBoxColumn12
            '
            Me.DataGridViewTextBoxColumn12.DataPropertyName = "EndDt"
            Me.DataGridViewTextBoxColumn12.HeaderText = "StartDt"
            Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
            '
            'DataGridViewTextBoxColumn13
            '
            Me.DataGridViewTextBoxColumn13.DataPropertyName = "hold_days"
            Me.DataGridViewTextBoxColumn13.HeaderText = "EndDt"
            Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
            '
            'DataGridViewTextBoxColumn14
            '
            Me.DataGridViewTextBoxColumn14.DataPropertyName = "PriorityCode"
            Me.DataGridViewTextBoxColumn14.HeaderText = "hold_days"
            Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
            '
            'DataGridViewTextBoxColumn15
            '
            Me.DataGridViewTextBoxColumn15.DataPropertyName = "ImportType"
            Me.DataGridViewTextBoxColumn15.HeaderText = "Distinction"
            Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
            '
            'DataGridViewTextBoxColumn16
            '
            Me.DataGridViewTextBoxColumn16.DataPropertyName = "ImportMediaID"
            Me.DataGridViewTextBoxColumn16.HeaderText = "ImportType"
            Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
            '
            'DataGridViewTextBoxColumn17
            '
            Me.DataGridViewTextBoxColumn17.DataPropertyName = "FVRequired"
            Me.DataGridViewTextBoxColumn17.HeaderText = "ImportMediaID"
            Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
            '
            'DataGridViewTextBoxColumn18
            '
            Me.DataGridViewTextBoxColumn18.DataPropertyName = "IsMarketMap"
            Me.DataGridViewTextBoxColumn18.HeaderText = "FVRequired"
            Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
            '
            'DataGridViewTextBoxColumn19
            '
            Me.DataGridViewTextBoxColumn19.HeaderText = "IsMarketMap"
            Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
            '
            'EditCol
            '
            Me.EditCol.DataPropertyName = "celledit"
            Me.EditCol.HeaderText = "Edited"
            Me.EditCol.Name = "EditCol"
            Me.EditCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.EditCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.EditCol.Visible = False
            '
            'AC_AdvertiserCol
            '
            Me.AC_AdvertiserCol.DataPropertyName = "company_nm"
            Me.AC_AdvertiserCol.HeaderText = "PEP Advertiser"
            Me.AC_AdvertiserCol.Name = "AC_AdvertiserCol"
            Me.AC_AdvertiserCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.AC_AdvertiserCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'AC_RetIDCol
            '
            Me.AC_RetIDCol.DataPropertyName = "AC_RetID"
            Me.AC_RetIDCol.HeaderText = "AC_RetID"
            Me.AC_RetIDCol.Name = "AC_RetIDCol"
            Me.AC_RetIDCol.Visible = False
            '
            'MT_AdvertiserCol
            '
            Me.MT_AdvertiserCol.DataPropertyName = "MT_Advertiser"
            Me.MT_AdvertiserCol.HeaderText = "Legacy Advertiser"
            Me.MT_AdvertiserCol.Name = "MT_AdvertiserCol"
            Me.MT_AdvertiserCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.MT_AdvertiserCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'MT_RetIDCol
            '
            Me.MT_RetIDCol.DataPropertyName = "MT_RetID"
            Me.MT_RetIDCol.HeaderText = "MT_RetID"
            Me.MT_RetIDCol.Name = "MT_RetIDCol"
            Me.MT_RetIDCol.Visible = False
            '
            'MT_MarketCol
            '
            Me.MT_MarketCol.DataPropertyName = "MT_Market"
            Me.MT_MarketCol.HeaderText = "Legacy Market "
            Me.MT_MarketCol.Name = "MT_MarketCol"
            Me.MT_MarketCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.MT_MarketCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'MT_MktIDCol
            '
            Me.MT_MktIDCol.DataPropertyName = "MT_MktID"
            Me.MT_MktIDCol.HeaderText = "MT_MktID"
            Me.MT_MktIDCol.Name = "MT_MktIDCol"
            Me.MT_MktIDCol.Visible = False
            '
            'store_iCol
            '
            Me.store_iCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.store_iCol.DataPropertyName = "store_i"
            Me.store_iCol.HeaderText = "Store ID"
            Me.store_iCol.Name = "store_iCol"
            Me.store_iCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.store_iCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
            Me.store_iCol.Width = 66
            '
            'AC_MarketCol
            '
            Me.AC_MarketCol.DataPropertyName = "AC_Market"
            Me.AC_MarketCol.HeaderText = "PEP Major Market"
            Me.AC_MarketCol.Name = "AC_MarketCol"
            Me.AC_MarketCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'AC_MktIDcol
            '
            Me.AC_MktIDcol.DataPropertyName = "AC_MktID"
            Me.AC_MktIDcol.HeaderText = "AC_MktID"
            Me.AC_MktIDcol.Name = "AC_MktIDcol"
            Me.AC_MktIDcol.Visible = False
            '
            'Store_AddressCol
            '
            Me.Store_AddressCol.DataPropertyName = "Store_Address"
            Me.Store_AddressCol.HeaderText = "Store Address"
            Me.Store_AddressCol.Name = "Store_AddressCol"
            '
            'Store_CityCol
            '
            Me.Store_CityCol.DataPropertyName = "Store_City"
            Me.Store_CityCol.HeaderText = "City"
            Me.Store_CityCol.Name = "Store_CityCol"
            Me.Store_CityCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'Store_StateCol
            '
            Me.Store_StateCol.DataPropertyName = "Store_State"
            Me.Store_StateCol.HeaderText = "State"
            Me.Store_StateCol.Name = "Store_StateCol"
            Me.Store_StateCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'Store_ZipCol
            '
            Me.Store_ZipCol.DataPropertyName = "Store_Zip"
            Me.Store_ZipCol.HeaderText = "Zip Code"
            Me.Store_ZipCol.Name = "Store_ZipCol"
            '
            'StartDtCol
            '
            Me.StartDtCol.DataPropertyName = "StartDt"
            Me.StartDtCol.HeaderText = "Start Date"
            Me.StartDtCol.Name = "StartDtCol"
            Me.StartDtCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.StartDtCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'EndDtCol
            '
            Me.EndDtCol.DataPropertyName = "EndDt"
            Me.EndDtCol.HeaderText = "End Date"
            Me.EndDtCol.Name = "EndDtCol"
            Me.EndDtCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.EndDtCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'hold_daysCol
            '
            Me.hold_daysCol.DataPropertyName = "hold_days"
            Me.hold_daysCol.HeaderText = "# of Days Hold"
            Me.hold_daysCol.Name = "hold_daysCol"
            '
            'DistinctionCol
            '
            Me.DistinctionCol.DataPropertyName = "PriorityCode"
            Me.DistinctionCol.HeaderText = "Ranking"
            Me.DistinctionCol.Items.AddRange(New Object() {"1", "2", "3"})
            Me.DistinctionCol.Name = "DistinctionCol"
            Me.DistinctionCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.DistinctionCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'ImportTypeCol
            '
            Me.ImportTypeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.ImportTypeCol.HeaderText = "Import Type"
            Me.ImportTypeCol.Name = "ImportTypeCol"
            Me.ImportTypeCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.ImportTypeCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.ImportTypeCol.Width = 81
            '
            'ImportMediaIDCol
            '
            Me.ImportMediaIDCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.ImportMediaIDCol.DataPropertyName = "ImportMediaID"
            Me.ImportMediaIDCol.HeaderText = "Media"
            Me.ImportMediaIDCol.Name = "ImportMediaIDCol"
            Me.ImportMediaIDCol.ReadOnly = True
            Me.ImportMediaIDCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.ImportMediaIDCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.ImportMediaIDCol.Width = 61
            '
            'CommentCol
            '
            Me.CommentCol.DataPropertyName = "comments"
            Me.CommentCol.HeaderText = "Comments"
            Me.CommentCol.Name = "CommentCol"
            '
            'FVRequiredCol
            '
            Me.FVRequiredCol.DataPropertyName = "FVRequired"
            Me.FVRequiredCol.HeaderText = "Required for FV Entry"
            Me.FVRequiredCol.Name = "FVRequiredCol"
            Me.FVRequiredCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            '
            'IsMarketMapCol
            '
            Me.IsMarketMapCol.DataPropertyName = "IsMarketMap"
            Me.IsMarketMapCol.HeaderText = "Market Mapped"
            Me.IsMarketMapCol.Items.AddRange(New Object() {"0", "1"})
            Me.IsMarketMapCol.Name = "IsMarketMapCol"
            Me.IsMarketMapCol.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
            Me.IsMarketMapCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'Addr_ID
            '
            Me.Addr_ID.DataPropertyName = "Addr_ID"
            Me.Addr_ID.HeaderText = "Addr_ID"
            Me.Addr_ID.Name = "Addr_ID"
            Me.Addr_ID.Visible = False
            '
            'AddressMappingForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1300, 690)
            Me.Controls.Add(Me.AddMappingDGV)
            Me.Controls.Add(Me.GroupBox2)
            Me.Name = "AddressMappingForm"
            Me.Text = "AC to MT Address Mapping"
            CType(Me.AddMappingDGV, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.FlowLayoutPanel1.ResumeLayout(False)
            Me.FlowLayoutPanel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents AddMappingDGV As System.Windows.Forms.DataGridView
        Friend WithEvents LoadButton As System.Windows.Forms.Button
        Friend WithEvents ACRetComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents PhaseTypeComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents MTRetComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents MTMktComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents DataGridViewComboBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents CalendarColumn1 As MCAP.UI.Controls.CalendarColumn
        Friend WithEvents CalendarColumn2 As MCAP.UI.Controls.CalendarColumn
        Friend WithEvents DataGridViewComboBoxColumn4 As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents DataGridViewComboBoxColumn5 As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents SaveButton As System.Windows.Forms.Button
        Friend WithEvents ResetButton As System.Windows.Forms.Button
        Friend WithEvents Deletedlbl As System.Windows.Forms.Label
        Friend WithEvents Updatedlbl As System.Windows.Forms.Label
        Friend WithEvents Label5 As Label
        Friend WithEvents txtbxStoreID As TextBox
        Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
        Friend WithEvents ActiveAddrCheckBox As CheckBox
        Friend WithEvents EditCol As DataGridViewCheckBoxColumn
        Friend WithEvents AC_AdvertiserCol As DataGridViewComboBoxColumn
        Friend WithEvents AC_RetIDCol As DataGridViewTextBoxColumn
        Friend WithEvents MT_AdvertiserCol As DataGridViewComboBoxColumn
        Friend WithEvents MT_RetIDCol As DataGridViewTextBoxColumn
        Friend WithEvents MT_MarketCol As DataGridViewComboBoxColumn
        Friend WithEvents MT_MktIDCol As DataGridViewTextBoxColumn
        Friend WithEvents store_iCol As DataGridViewComboBoxColumn
        Friend WithEvents AC_MarketCol As DataGridViewTextBoxColumn
        Friend WithEvents AC_MktIDcol As DataGridViewTextBoxColumn
        Friend WithEvents Store_AddressCol As DataGridViewTextBoxColumn
        Friend WithEvents Store_CityCol As DataGridViewTextBoxColumn
        Friend WithEvents Store_StateCol As DataGridViewTextBoxColumn
        Friend WithEvents Store_ZipCol As DataGridViewTextBoxColumn
        Friend WithEvents StartDtCol As Controls.CalendarColumn
        Friend WithEvents EndDtCol As Controls.CalendarColumn
        Friend WithEvents hold_daysCol As DataGridViewTextBoxColumn
        Friend WithEvents DistinctionCol As DataGridViewComboBoxColumn
        Friend WithEvents ImportTypeCol As DataGridViewComboBoxColumn
        Friend WithEvents ImportMediaIDCol As DataGridViewComboBoxColumn
        Friend WithEvents CommentCol As DataGridViewTextBoxColumn
        Friend WithEvents FVRequiredCol As DataGridViewTextBoxColumn
        Friend WithEvents IsMarketMapCol As DataGridViewComboBoxColumn
        Friend WithEvents Addr_ID As DataGridViewTextBoxColumn
    End Class
End Namespace