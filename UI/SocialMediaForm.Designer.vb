﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SocialMediaForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tableComboBox = New System.Windows.Forms.ComboBox()
        Me.tableLabel = New System.Windows.Forms.Label()
        Me.editTableGroupBox = New System.Windows.Forms.GroupBox()
        Me.SenderExpectationPanel = New System.Windows.Forms.Panel()
        Me.SenderExpectationDataGridView = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ValueTwoComboBox = New System.Windows.Forms.ComboBox()
        Me.ValueOneComboBox = New System.Windows.Forms.ComboBox()
        Me.RemoveSEFilterButton = New System.Windows.Forms.Button()
        Me.FilterSEButton = New System.Windows.Forms.Button()
        Me.AndOrComboBox = New System.Windows.Forms.ComboBox()
        Me.FilterTwoComboBox = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FilterOneComboBox = New System.Windows.Forms.ComboBox()
        Me.RefreshButton = New System.Windows.Forms.Button()
        Me.ExpectaionIdLabel = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.UpdateListButton = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RetailerComboBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.MarketComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MediaComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SenderComboBox = New System.Windows.Forms.ComboBox()
        Me.filter2FlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.filterField2ComboBox = New System.Windows.Forms.ComboBox()
        Me.filterValue2TextBox = New System.Windows.Forms.TextBox()
        Me.filterValue2ComboBox = New System.Windows.Forms.ComboBox()
        Me.filterFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.filterFieldComboBox = New System.Windows.Forms.ComboBox()
        Me.filterValueTextBox = New System.Windows.Forms.TextBox()
        Me.filterValueComboBox = New System.Windows.Forms.ComboBox()
        Me.filterButton = New System.Windows.Forms.Button()
        Me.removeFilterButton = New System.Windows.Forms.Button()
        Me.logicalOperatorsComboBox = New System.Windows.Forms.ComboBox()
        Me.filterOnLabel = New System.Windows.Forms.Label()
        Me.maintenanceDataGridView = New System.Windows.Forms.DataGridView()
        Me.closeButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.applyButton = New System.Windows.Forms.Button()
        Me.filterValue2TypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
        Me.filterValueTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
        Me.editTableGroupBox.SuspendLayout()
        Me.SenderExpectationPanel.SuspendLayout()
        CType(Me.SenderExpectationDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.filter2FlowLayoutPanel.SuspendLayout()
        Me.filterFlowLayoutPanel.SuspendLayout()
        CType(Me.maintenanceDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tableComboBox
        '
        Me.tableComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.tableComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.tableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tableComboBox.FormattingEnabled = True
        Me.tableComboBox.Items.AddRange(New Object() {"FacebookInputdata", "TwitterInputdata"})
        Me.tableComboBox.Location = New System.Drawing.Point(51, 12)
        Me.tableComboBox.Name = "tableComboBox"
        Me.tableComboBox.Size = New System.Drawing.Size(231, 21)
        Me.tableComboBox.Sorted = True
        Me.tableComboBox.TabIndex = 3
        '
        'tableLabel
        '
        Me.tableLabel.AutoSize = True
        Me.tableLabel.Location = New System.Drawing.Point(11, 15)
        Me.tableLabel.Name = "tableLabel"
        Me.tableLabel.Size = New System.Drawing.Size(34, 13)
        Me.tableLabel.TabIndex = 2
        Me.tableLabel.Text = "&Table"
        '
        'editTableGroupBox
        '
        Me.editTableGroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.editTableGroupBox.Controls.Add(Me.SenderExpectationPanel)
        Me.editTableGroupBox.Controls.Add(Me.filter2FlowLayoutPanel)
        Me.editTableGroupBox.Controls.Add(Me.filterFlowLayoutPanel)
        Me.editTableGroupBox.Controls.Add(Me.filterButton)
        Me.editTableGroupBox.Controls.Add(Me.removeFilterButton)
        Me.editTableGroupBox.Controls.Add(Me.logicalOperatorsComboBox)
        Me.editTableGroupBox.Controls.Add(Me.filterOnLabel)
        Me.editTableGroupBox.Controls.Add(Me.maintenanceDataGridView)
        Me.editTableGroupBox.Location = New System.Drawing.Point(12, 39)
        Me.editTableGroupBox.Name = "editTableGroupBox"
        Me.editTableGroupBox.Size = New System.Drawing.Size(944, 541)
        Me.editTableGroupBox.TabIndex = 4
        Me.editTableGroupBox.TabStop = False
        Me.editTableGroupBox.Text = "Edit Table: <Table Name>"
        '
        'SenderExpectationPanel
        '
        Me.SenderExpectationPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SenderExpectationPanel.Controls.Add(Me.SenderExpectationDataGridView)
        Me.SenderExpectationPanel.Controls.Add(Me.Panel2)
        Me.SenderExpectationPanel.Location = New System.Drawing.Point(10000, 13)
        Me.SenderExpectationPanel.Name = "SenderExpectationPanel"
        Me.SenderExpectationPanel.Size = New System.Drawing.Size(932, 521)
        Me.SenderExpectationPanel.TabIndex = 7
        Me.SenderExpectationPanel.Visible = False
        '
        'SenderExpectationDataGridView
        '
        Me.SenderExpectationDataGridView.AllowUserToAddRows = False
        Me.SenderExpectationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SenderExpectationDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SenderExpectationDataGridView.Location = New System.Drawing.Point(0, 107)
        Me.SenderExpectationDataGridView.Name = "SenderExpectationDataGridView"
        Me.SenderExpectationDataGridView.ReadOnly = True
        Me.SenderExpectationDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.SenderExpectationDataGridView.Size = New System.Drawing.Size(932, 414)
        Me.SenderExpectationDataGridView.TabIndex = 13
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ValueTwoComboBox)
        Me.Panel2.Controls.Add(Me.ValueOneComboBox)
        Me.Panel2.Controls.Add(Me.RemoveSEFilterButton)
        Me.Panel2.Controls.Add(Me.FilterSEButton)
        Me.Panel2.Controls.Add(Me.AndOrComboBox)
        Me.Panel2.Controls.Add(Me.FilterTwoComboBox)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.FilterOneComboBox)
        Me.Panel2.Controls.Add(Me.RefreshButton)
        Me.Panel2.Controls.Add(Me.ExpectaionIdLabel)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.UpdateListButton)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.RetailerComboBox)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.MarketComboBox)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.MediaComboBox)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.SenderComboBox)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(932, 107)
        Me.Panel2.TabIndex = 14
        '
        'ValueTwoComboBox
        '
        Me.ValueTwoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ValueTwoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ValueTwoComboBox.FormattingEnabled = True
        Me.ValueTwoComboBox.Location = New System.Drawing.Point(654, 33)
        Me.ValueTwoComboBox.Name = "ValueTwoComboBox"
        Me.ValueTwoComboBox.Size = New System.Drawing.Size(264, 21)
        Me.ValueTwoComboBox.TabIndex = 32
        '
        'ValueOneComboBox
        '
        Me.ValueOneComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ValueOneComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ValueOneComboBox.FormattingEnabled = True
        Me.ValueOneComboBox.Location = New System.Drawing.Point(654, 10)
        Me.ValueOneComboBox.Name = "ValueOneComboBox"
        Me.ValueOneComboBox.Size = New System.Drawing.Size(264, 21)
        Me.ValueOneComboBox.TabIndex = 31
        '
        'RemoveSEFilterButton
        '
        Me.RemoveSEFilterButton.Location = New System.Drawing.Point(817, 62)
        Me.RemoveSEFilterButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
        Me.RemoveSEFilterButton.Name = "RemoveSEFilterButton"
        Me.RemoveSEFilterButton.Size = New System.Drawing.Size(101, 23)
        Me.RemoveSEFilterButton.TabIndex = 30
        Me.RemoveSEFilterButton.Text = "Remove Filter"
        Me.RemoveSEFilterButton.UseVisualStyleBackColor = True
        '
        'FilterSEButton
        '
        Me.FilterSEButton.Location = New System.Drawing.Point(710, 62)
        Me.FilterSEButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
        Me.FilterSEButton.Name = "FilterSEButton"
        Me.FilterSEButton.Size = New System.Drawing.Size(101, 23)
        Me.FilterSEButton.TabIndex = 29
        Me.FilterSEButton.Text = "Filter"
        Me.FilterSEButton.UseVisualStyleBackColor = True
        '
        'AndOrComboBox
        '
        Me.AndOrComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.AndOrComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.AndOrComboBox.FormattingEnabled = True
        Me.AndOrComboBox.Items.AddRange(New Object() {"And", "Or"})
        Me.AndOrComboBox.Location = New System.Drawing.Point(463, 33)
        Me.AndOrComboBox.Name = "AndOrComboBox"
        Me.AndOrComboBox.Size = New System.Drawing.Size(53, 21)
        Me.AndOrComboBox.TabIndex = 26
        '
        'FilterTwoComboBox
        '
        Me.FilterTwoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.FilterTwoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.FilterTwoComboBox.FormattingEnabled = True
        Me.FilterTwoComboBox.Items.AddRange(New Object() {"Media", "Market", "Retailer"})
        Me.FilterTwoComboBox.Location = New System.Drawing.Point(519, 34)
        Me.FilterTwoComboBox.Name = "FilterTwoComboBox"
        Me.FilterTwoComboBox.Size = New System.Drawing.Size(131, 21)
        Me.FilterTwoComboBox.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(466, 14)
        Me.Label6.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Filter On"
        '
        'FilterOneComboBox
        '
        Me.FilterOneComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.FilterOneComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.FilterOneComboBox.FormattingEnabled = True
        Me.FilterOneComboBox.Items.AddRange(New Object() {"Media", "Market", "Retailer"})
        Me.FilterOneComboBox.Location = New System.Drawing.Point(519, 10)
        Me.FilterOneComboBox.Name = "FilterOneComboBox"
        Me.FilterOneComboBox.Size = New System.Drawing.Size(131, 21)
        Me.FilterOneComboBox.TabIndex = 23
        '
        'RefreshButton
        '
        Me.RefreshButton.Location = New System.Drawing.Point(338, 62)
        Me.RefreshButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
        Me.RefreshButton.Name = "RefreshButton"
        Me.RefreshButton.Size = New System.Drawing.Size(101, 23)
        Me.RefreshButton.TabIndex = 22
        Me.RefreshButton.Text = "Refresh"
        Me.RefreshButton.UseVisualStyleBackColor = True
        '
        'ExpectaionIdLabel
        '
        Me.ExpectaionIdLabel.AutoSize = True
        Me.ExpectaionIdLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpectaionIdLabel.Location = New System.Drawing.Point(335, 9)
        Me.ExpectaionIdLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        Me.ExpectaionIdLabel.Name = "ExpectaionIdLabel"
        Me.ExpectaionIdLabel.Size = New System.Drawing.Size(14, 13)
        Me.ExpectaionIdLabel.TabIndex = 21
        Me.ExpectaionIdLabel.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(252, 9)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Expectation ID"
        '
        'UpdateListButton
        '
        Me.UpdateListButton.Location = New System.Drawing.Point(338, 34)
        Me.UpdateListButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
        Me.UpdateListButton.Name = "UpdateListButton"
        Me.UpdateListButton.Size = New System.Drawing.Size(101, 23)
        Me.UpdateListButton.TabIndex = 18
        Me.UpdateListButton.Text = "&Update List"
        Me.UpdateListButton.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 83)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Retailer"
        '
        'RetailerComboBox
        '
        Me.RetailerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.RetailerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.RetailerComboBox.FormattingEnabled = True
        Me.RetailerComboBox.Location = New System.Drawing.Point(72, 77)
        Me.RetailerComboBox.Name = "RetailerComboBox"
        Me.RetailerComboBox.Size = New System.Drawing.Size(243, 21)
        Me.RetailerComboBox.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 59)
        Me.Label3.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Market"
        '
        'MarketComboBox
        '
        Me.MarketComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.MarketComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.MarketComboBox.FormattingEnabled = True
        Me.MarketComboBox.Location = New System.Drawing.Point(72, 54)
        Me.MarketComboBox.Name = "MarketComboBox"
        Me.MarketComboBox.Size = New System.Drawing.Size(243, 21)
        Me.MarketComboBox.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 34)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Media"
        '
        'MediaComboBox
        '
        Me.MediaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.MediaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.MediaComboBox.FormattingEnabled = True
        Me.MediaComboBox.Location = New System.Drawing.Point(72, 29)
        Me.MediaComboBox.Name = "MediaComboBox"
        Me.MediaComboBox.Size = New System.Drawing.Size(243, 21)
        Me.MediaComboBox.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Sender"
        '
        'SenderComboBox
        '
        Me.SenderComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.SenderComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.SenderComboBox.FormattingEnabled = True
        Me.SenderComboBox.Location = New System.Drawing.Point(73, 5)
        Me.SenderComboBox.Name = "SenderComboBox"
        Me.SenderComboBox.Size = New System.Drawing.Size(155, 21)
        Me.SenderComboBox.TabIndex = 11
        '
        'filter2FlowLayoutPanel
        '
        Me.filter2FlowLayoutPanel.Controls.Add(Me.filterField2ComboBox)
        Me.filter2FlowLayoutPanel.Controls.Add(Me.filterValue2TextBox)
        Me.filter2FlowLayoutPanel.Controls.Add(Me.filterValue2ComboBox)
        Me.filter2FlowLayoutPanel.Controls.Add(Me.filterValue2TypeInDatePicker)
        Me.filter2FlowLayoutPanel.Location = New System.Drawing.Point(58, 49)
        Me.filter2FlowLayoutPanel.Name = "filter2FlowLayoutPanel"
        Me.filter2FlowLayoutPanel.Size = New System.Drawing.Size(776, 28)
        Me.filter2FlowLayoutPanel.TabIndex = 3
        '
        'filterField2ComboBox
        '
        Me.filterField2ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.filterField2ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.filterField2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.filterField2ComboBox.FormattingEnabled = True
        Me.filterField2ComboBox.Location = New System.Drawing.Point(3, 3)
        Me.filterField2ComboBox.Name = "filterField2ComboBox"
        Me.filterField2ComboBox.Size = New System.Drawing.Size(155, 21)
        Me.filterField2ComboBox.TabIndex = 0
        '
        'filterValue2TextBox
        '
        Me.filterValue2TextBox.Location = New System.Drawing.Point(164, 3)
        Me.filterValue2TextBox.Name = "filterValue2TextBox"
        Me.filterValue2TextBox.Size = New System.Drawing.Size(261, 20)
        Me.filterValue2TextBox.TabIndex = 1
        '
        'filterValue2ComboBox
        '
        Me.filterValue2ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.filterValue2ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.filterValue2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.filterValue2ComboBox.FormattingEnabled = True
        Me.filterValue2ComboBox.Location = New System.Drawing.Point(431, 3)
        Me.filterValue2ComboBox.Name = "filterValue2ComboBox"
        Me.filterValue2ComboBox.Size = New System.Drawing.Size(261, 21)
        Me.filterValue2ComboBox.TabIndex = 2
        Me.filterValue2ComboBox.Visible = False
        '
        'filterFlowLayoutPanel
        '
        Me.filterFlowLayoutPanel.Controls.Add(Me.filterFieldComboBox)
        Me.filterFlowLayoutPanel.Controls.Add(Me.filterValueTextBox)
        Me.filterFlowLayoutPanel.Controls.Add(Me.filterValueComboBox)
        Me.filterFlowLayoutPanel.Controls.Add(Me.filterValueTypeInDatePicker)
        Me.filterFlowLayoutPanel.Location = New System.Drawing.Point(58, 19)
        Me.filterFlowLayoutPanel.Name = "filterFlowLayoutPanel"
        Me.filterFlowLayoutPanel.Size = New System.Drawing.Size(776, 28)
        Me.filterFlowLayoutPanel.TabIndex = 1
        '
        'filterFieldComboBox
        '
        Me.filterFieldComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.filterFieldComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.filterFieldComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.filterFieldComboBox.FormattingEnabled = True
        Me.filterFieldComboBox.Location = New System.Drawing.Point(3, 3)
        Me.filterFieldComboBox.Name = "filterFieldComboBox"
        Me.filterFieldComboBox.Size = New System.Drawing.Size(155, 21)
        Me.filterFieldComboBox.TabIndex = 0
        '
        'filterValueTextBox
        '
        Me.filterValueTextBox.Location = New System.Drawing.Point(164, 3)
        Me.filterValueTextBox.Name = "filterValueTextBox"
        Me.filterValueTextBox.Size = New System.Drawing.Size(261, 20)
        Me.filterValueTextBox.TabIndex = 1
        '
        'filterValueComboBox
        '
        Me.filterValueComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.filterValueComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.filterValueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.filterValueComboBox.FormattingEnabled = True
        Me.filterValueComboBox.Location = New System.Drawing.Point(431, 3)
        Me.filterValueComboBox.Name = "filterValueComboBox"
        Me.filterValueComboBox.Size = New System.Drawing.Size(261, 21)
        Me.filterValueComboBox.TabIndex = 2
        Me.filterValueComboBox.Visible = False
        '
        'filterButton
        '
        Me.filterButton.Location = New System.Drawing.Point(61, 89)
        Me.filterButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 3)
        Me.filterButton.Name = "filterButton"
        Me.filterButton.Size = New System.Drawing.Size(97, 23)
        Me.filterButton.TabIndex = 4
        Me.filterButton.Text = "&Filter"
        Me.filterButton.UseVisualStyleBackColor = True
        '
        'removeFilterButton
        '
        Me.removeFilterButton.Enabled = False
        Me.removeFilterButton.Location = New System.Drawing.Point(164, 90)
        Me.removeFilterButton.Name = "removeFilterButton"
        Me.removeFilterButton.Size = New System.Drawing.Size(97, 23)
        Me.removeFilterButton.TabIndex = 5
        Me.removeFilterButton.Text = "Remove Filter"
        Me.removeFilterButton.UseVisualStyleBackColor = True
        '
        'logicalOperatorsComboBox
        '
        Me.logicalOperatorsComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.logicalOperatorsComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.logicalOperatorsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.logicalOperatorsComboBox.FormattingEnabled = True
        Me.logicalOperatorsComboBox.Items.AddRange(New Object() {"And", "Or"})
        Me.logicalOperatorsComboBox.Location = New System.Drawing.Point(9, 52)
        Me.logicalOperatorsComboBox.Name = "logicalOperatorsComboBox"
        Me.logicalOperatorsComboBox.Size = New System.Drawing.Size(43, 21)
        Me.logicalOperatorsComboBox.TabIndex = 2
        '
        'filterOnLabel
        '
        Me.filterOnLabel.AutoSize = True
        Me.filterOnLabel.Location = New System.Drawing.Point(6, 23)
        Me.filterOnLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
        Me.filterOnLabel.Name = "filterOnLabel"
        Me.filterOnLabel.Size = New System.Drawing.Size(46, 13)
        Me.filterOnLabel.TabIndex = 0
        Me.filterOnLabel.Text = "Filter &On"
        '
        'maintenanceDataGridView
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.maintenanceDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.maintenanceDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.maintenanceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.maintenanceDataGridView.Location = New System.Drawing.Point(6, 118)
        Me.maintenanceDataGridView.Name = "maintenanceDataGridView"
        Me.maintenanceDataGridView.Size = New System.Drawing.Size(932, 416)
        Me.maintenanceDataGridView.TabIndex = 6
        '
        'closeButton
        '
        Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.closeButton.Location = New System.Drawing.Point(882, 586)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(75, 23)
        Me.closeButton.TabIndex = 9
        Me.closeButton.Text = "&Close"
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'cancelButton
        '
        Me.cancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancelButton.Location = New System.Drawing.Point(801, 586)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(75, 23)
        Me.cancelButton.TabIndex = 8
        Me.cancelButton.Text = "Ca&ncel"
        Me.cancelButton.UseVisualStyleBackColor = True
        '
        'applyButton
        '
        Me.applyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.applyButton.Location = New System.Drawing.Point(720, 586)
        Me.applyButton.Name = "applyButton"
        Me.applyButton.Size = New System.Drawing.Size(75, 23)
        Me.applyButton.TabIndex = 7
        Me.applyButton.Text = "&Apply"
        Me.applyButton.UseVisualStyleBackColor = True
        '
        'filterValue2TypeInDatePicker
        '
        Me.filterValue2TypeInDatePicker.Location = New System.Drawing.Point(698, 3)
        Me.filterValue2TypeInDatePicker.Name = "filterValue2TypeInDatePicker"
        Me.filterValue2TypeInDatePicker.Size = New System.Drawing.Size(72, 20)
        Me.filterValue2TypeInDatePicker.TabIndex = 3
        Me.filterValue2TypeInDatePicker.Value = Nothing
        Me.filterValue2TypeInDatePicker.Visible = False
        '
        'filterValueTypeInDatePicker
        '
        Me.filterValueTypeInDatePicker.Location = New System.Drawing.Point(698, 3)
        Me.filterValueTypeInDatePicker.Name = "filterValueTypeInDatePicker"
        Me.filterValueTypeInDatePicker.Size = New System.Drawing.Size(72, 20)
        Me.filterValueTypeInDatePicker.TabIndex = 3
        Me.filterValueTypeInDatePicker.Value = Nothing
        Me.filterValueTypeInDatePicker.Visible = False
        '
        'SocialMediaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(968, 619)
        Me.Controls.Add(Me.closeButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.applyButton)
        Me.Controls.Add(Me.editTableGroupBox)
        Me.Controls.Add(Me.tableComboBox)
        Me.Controls.Add(Me.tableLabel)
        Me.Name = "SocialMediaForm"
        Me.Text = "Social Media Support"
        Me.editTableGroupBox.ResumeLayout(False)
        Me.editTableGroupBox.PerformLayout()
        Me.SenderExpectationPanel.ResumeLayout(False)
        CType(Me.SenderExpectationDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.filter2FlowLayoutPanel.ResumeLayout(False)
        Me.filter2FlowLayoutPanel.PerformLayout()
        Me.filterFlowLayoutPanel.ResumeLayout(False)
        Me.filterFlowLayoutPanel.PerformLayout()
        CType(Me.maintenanceDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tableComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents tableLabel As System.Windows.Forms.Label
    Friend WithEvents editTableGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents SenderExpectationPanel As System.Windows.Forms.Panel
    Friend WithEvents SenderExpectationDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ValueTwoComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ValueOneComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RemoveSEFilterButton As System.Windows.Forms.Button
    Friend WithEvents FilterSEButton As System.Windows.Forms.Button
    Friend WithEvents AndOrComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents FilterTwoComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents FilterOneComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RefreshButton As System.Windows.Forms.Button
    Friend WithEvents ExpectaionIdLabel As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents UpdateListButton As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RetailerComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MarketComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MediaComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SenderComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents filter2FlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents filterField2ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents filterValue2TextBox As System.Windows.Forms.TextBox
    Friend WithEvents filterValue2ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents filterValue2TypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
    Friend WithEvents filterFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents filterFieldComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents filterValueTextBox As System.Windows.Forms.TextBox
    Friend WithEvents filterValueComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents filterValueTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
    Friend WithEvents filterButton As System.Windows.Forms.Button
    Friend WithEvents removeFilterButton As System.Windows.Forms.Button
    Friend WithEvents logicalOperatorsComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents filterOnLabel As System.Windows.Forms.Label
    Friend WithEvents maintenanceDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents applyButton As System.Windows.Forms.Button
End Class
