NameSpace UI
	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
	Partial Class PageDefinitionsForm

			'Form overrides dispose to clean up the component list.
			<System.Diagnostics.DebuggerNonUserCode()> _
			Protected Overrides Sub Dispose(ByVal disposing As Boolean)
					If disposing AndAlso components IsNot Nothing Then
							components.Dispose()
					End If
					MyBase.Dispose(disposing)
			End Sub

			'Required by the Windows Form Designer
			Private components As System.ComponentModel.IContainer

			'NOTE: The following procedure is required by the Windows Form Designer
			'It can be modified using the Windows Form Designer.  
			'Do not modify it using the code editor.
			<System.Diagnostics.DebuggerStepThrough()> _
			Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PageDefinitionsForm))
            Me.PageSizePlacementGroupBox = New System.Windows.Forms.GroupBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.sizeMaskedTextBox = New System.Windows.Forms.MaskedTextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.SizeComboBox = New System.Windows.Forms.ComboBox()
            Me.SizeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.PageDefinitionsDataSet = New MCAP.PageDefinitionsDataSet()
            Me.EndDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.PageOrderComboBox = New System.Windows.Forms.ComboBox()
            Me.StartDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.PageNameComboBox = New System.Windows.Forms.ComboBox()
            Me.PagesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.NextButton = New System.Windows.Forms.Button()
            Me.PrevButton = New System.Windows.Forms.Button()
            Me.CopyToNextButton = New System.Windows.Forms.Button()
            Me.CopyToAllButton = New System.Windows.Forms.Button()
            Me.OKButton = New System.Windows.Forms.Button()
            Me.CancelButton2 = New System.Windows.Forms.Button()
            Me.PageTypesGroupBox = New System.Windows.Forms.GroupBox()
            Me.BaseTextBox = New System.Windows.Forms.TextBox()
            Me.InsertsLabel = New System.Windows.Forms.Label()
            Me.BaseLabel = New System.Windows.Forms.Label()
            Me.InsertsDataGridView = New System.Windows.Forms.DataGridView()
            Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.NumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PageCountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.StartPage = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InsertsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.VehicleIDLabel = New System.Windows.Forms.Label()
            Me.VehicleIDTextBox = New System.Windows.Forms.TextBox()
            Me.SizeTableAdapter = New MCAP.PageDefinitionsDataSetTableAdapters.SizeTableAdapter()
            Me.PageListGroupBox = New System.Windows.Forms.GroupBox()
            Me.PagesDataGridView = New System.Windows.Forms.DataGridView()
            Me.PageTypeId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ReceivedOrderDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.SizeIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PageNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.SizeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.InsertNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PageNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PageStartDt = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PageEndDt = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.VehicleStartEndLabel = New System.Windows.Forms.Label()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PageSizePlacementGroupBox.SuspendLayout()
            CType(Me.SizeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PageDefinitionsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PagesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PageTypesGroupBox.SuspendLayout()
            CType(Me.InsertsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.InsertsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PageListGroupBox.SuspendLayout()
            CType(Me.PagesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'PageSizePlacementGroupBox
            '
            Me.PageSizePlacementGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.PageSizePlacementGroupBox.Controls.Add(Me.Label2)
            Me.PageSizePlacementGroupBox.Controls.Add(Me.sizeMaskedTextBox)
            Me.PageSizePlacementGroupBox.Controls.Add(Me.Label1)
            Me.PageSizePlacementGroupBox.Controls.Add(Me.SizeComboBox)
            Me.PageSizePlacementGroupBox.Controls.Add(Me.EndDatePicker)
            Me.PageSizePlacementGroupBox.Controls.Add(Me.PageOrderComboBox)
            Me.PageSizePlacementGroupBox.Controls.Add(Me.StartDatePicker)
            Me.PageSizePlacementGroupBox.Controls.Add(Me.PageNameComboBox)
            Me.PageSizePlacementGroupBox.Controls.Add(Me.NextButton)
            Me.PageSizePlacementGroupBox.Controls.Add(Me.PrevButton)
            Me.PageSizePlacementGroupBox.Controls.Add(Me.CopyToNextButton)
            Me.PageSizePlacementGroupBox.Controls.Add(Me.CopyToAllButton)
            Me.PageSizePlacementGroupBox.Location = New System.Drawing.Point(12, 333)
            Me.PageSizePlacementGroupBox.Name = "PageSizePlacementGroupBox"
            Me.PageSizePlacementGroupBox.Size = New System.Drawing.Size(339, 150)
            Me.PageSizePlacementGroupBox.TabIndex = 2
            Me.PageSizePlacementGroupBox.TabStop = False
            Me.PageSizePlacementGroupBox.Text = "Define Page Size/Placement"
            '
            'Label2
            '
            Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(171, 52)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(81, 13)
            Me.Label2.TabIndex = 16
            Me.Label2.Text = "Page Sale End:"
            '
            'sizeMaskedTextBox
            '
            Me.sizeMaskedTextBox.Enabled = False
            Me.sizeMaskedTextBox.Location = New System.Drawing.Point(6, 46)
            Me.sizeMaskedTextBox.Mask = "##.## X ##.##"
            Me.sizeMaskedTextBox.Name = "sizeMaskedTextBox"
            Me.sizeMaskedTextBox.Size = New System.Drawing.Size(137, 20)
            Me.sizeMaskedTextBox.TabIndex = 6
            '
            'Label1
            '
            Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(168, 25)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(84, 13)
            Me.Label1.TabIndex = 15
            Me.Label1.Text = "Page Sale Start:"
            '
            'SizeComboBox
            '
            Me.SizeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.SizeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.SizeComboBox.DataSource = Me.SizeBindingSource
            Me.SizeComboBox.DisplayMember = "Descrip"
            Me.SizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.SizeComboBox.Enabled = False
            Me.SizeComboBox.Location = New System.Drawing.Point(6, 46)
            Me.SizeComboBox.Name = "SizeComboBox"
            Me.SizeComboBox.Size = New System.Drawing.Size(154, 21)
            Me.SizeComboBox.TabIndex = 6
            Me.SizeComboBox.TabStop = False
            Me.SizeComboBox.ValueMember = "SizeID"
            '
            'SizeBindingSource
            '
            Me.SizeBindingSource.DataMember = "Size"
            Me.SizeBindingSource.DataSource = Me.PageDefinitionsDataSet
            '
            'PageDefinitionsDataSet
            '
            Me.PageDefinitionsDataSet.DataSetName = "PageDefinitionsDataSet"
            Me.PageDefinitionsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'EndDatePicker
            '
            Me.EndDatePicker.Enabled = False
            Me.EndDatePicker.Location = New System.Drawing.Point(254, 46)
            Me.EndDatePicker.Name = "EndDatePicker"
            Me.EndDatePicker.Size = New System.Drawing.Size(72, 20)
            Me.EndDatePicker.TabIndex = 14
            Me.EndDatePicker.Value = Nothing
            '
            'PageOrderComboBox
            '
            Me.PageOrderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.PageOrderComboBox.Enabled = False
            Me.PageOrderComboBox.FormattingEnabled = True
            Me.PageOrderComboBox.Location = New System.Drawing.Point(117, 19)
            Me.PageOrderComboBox.Name = "PageOrderComboBox"
            Me.PageOrderComboBox.Size = New System.Drawing.Size(43, 21)
            Me.PageOrderComboBox.TabIndex = 5
            '
            'StartDatePicker
            '
            Me.StartDatePicker.Enabled = False
            Me.StartDatePicker.Location = New System.Drawing.Point(254, 20)
            Me.StartDatePicker.Name = "StartDatePicker"
            Me.StartDatePicker.Size = New System.Drawing.Size(72, 20)
            Me.StartDatePicker.TabIndex = 13
            Me.StartDatePicker.Value = Nothing
            '
            'PageNameComboBox
            '
            Me.PageNameComboBox.DataSource = Me.PagesBindingSource
            Me.PageNameComboBox.DisplayMember = "PageName"
            Me.PageNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.PageNameComboBox.Enabled = False
            Me.PageNameComboBox.FormattingEnabled = True
            Me.PageNameComboBox.Location = New System.Drawing.Point(6, 19)
            Me.PageNameComboBox.Name = "PageNameComboBox"
            Me.PageNameComboBox.Size = New System.Drawing.Size(105, 21)
            Me.PageNameComboBox.TabIndex = 4
            Me.PageNameComboBox.ValueMember = "PageName"
            '
            'PagesBindingSource
            '
            Me.PagesBindingSource.DataMember = "Pages"
            Me.PagesBindingSource.DataSource = Me.PageDefinitionsDataSet
            Me.PagesBindingSource.Sort = "ReceivedOrder"
            '
            'NextButton
            '
            Me.NextButton.Enabled = False
            Me.NextButton.Location = New System.Drawing.Point(86, 71)
            Me.NextButton.Name = "NextButton"
            Me.NextButton.Size = New System.Drawing.Size(74, 21)
            Me.NextButton.TabIndex = 8
            Me.NextButton.Text = "Next"
            Me.NextButton.UseVisualStyleBackColor = True
            '
            'PrevButton
            '
            Me.PrevButton.Enabled = False
            Me.PrevButton.Location = New System.Drawing.Point(6, 71)
            Me.PrevButton.Name = "PrevButton"
            Me.PrevButton.Size = New System.Drawing.Size(74, 21)
            Me.PrevButton.TabIndex = 7
            Me.PrevButton.Text = "Prev"
            Me.PrevButton.UseVisualStyleBackColor = True
            '
            'CopyToNextButton
            '
            Me.CopyToNextButton.Enabled = False
            Me.CopyToNextButton.Location = New System.Drawing.Point(86, 98)
            Me.CopyToNextButton.Name = "CopyToNextButton"
            Me.CopyToNextButton.Size = New System.Drawing.Size(74, 40)
            Me.CopyToNextButton.TabIndex = 10
            Me.CopyToNextButton.Text = "Copy to Next"
            Me.CopyToNextButton.UseVisualStyleBackColor = True
            '
            'CopyToAllButton
            '
            Me.CopyToAllButton.Enabled = False
            Me.CopyToAllButton.Location = New System.Drawing.Point(6, 98)
            Me.CopyToAllButton.Name = "CopyToAllButton"
            Me.CopyToAllButton.Size = New System.Drawing.Size(74, 40)
            Me.CopyToAllButton.TabIndex = 9
            Me.CopyToAllButton.Text = "Copy to All"
            Me.CopyToAllButton.UseVisualStyleBackColor = True
            '
            'OKButton
            '
            Me.OKButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.OKButton.Location = New System.Drawing.Point(298, 494)
            Me.OKButton.Name = "OKButton"
            Me.OKButton.Size = New System.Drawing.Size(74, 21)
            Me.OKButton.TabIndex = 4
            Me.OKButton.Text = "OK"
            Me.OKButton.UseVisualStyleBackColor = True
            '
            'CancelButton2
            '
            Me.CancelButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.CancelButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.CancelButton2.Location = New System.Drawing.Point(378, 494)
            Me.CancelButton2.Name = "CancelButton2"
            Me.CancelButton2.Size = New System.Drawing.Size(74, 21)
            Me.CancelButton2.TabIndex = 5
            Me.CancelButton2.Text = "Cancel"
            Me.CancelButton2.UseVisualStyleBackColor = True
            '
            'PageTypesGroupBox
            '
            Me.PageTypesGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.PageTypesGroupBox.Controls.Add(Me.BaseTextBox)
            Me.PageTypesGroupBox.Controls.Add(Me.InsertsLabel)
            Me.PageTypesGroupBox.Controls.Add(Me.BaseLabel)
            Me.PageTypesGroupBox.Controls.Add(Me.InsertsDataGridView)
            Me.PageTypesGroupBox.Location = New System.Drawing.Point(12, 35)
            Me.PageTypesGroupBox.Name = "PageTypesGroupBox"
            Me.PageTypesGroupBox.Size = New System.Drawing.Size(339, 292)
            Me.PageTypesGroupBox.TabIndex = 1
            Me.PageTypesGroupBox.TabStop = False
            Me.PageTypesGroupBox.Text = "Define Page Types"
            '
            'BaseTextBox
            '
            Me.BaseTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.BaseTextBox.Location = New System.Drawing.Point(108, 19)
            Me.BaseTextBox.Name = "BaseTextBox"
            Me.BaseTextBox.Size = New System.Drawing.Size(74, 20)
            Me.BaseTextBox.TabIndex = 2
            Me.BaseTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'InsertsLabel
            '
            Me.InsertsLabel.AutoSize = True
            Me.InsertsLabel.Location = New System.Drawing.Point(10, 42)
            Me.InsertsLabel.Name = "InsertsLabel"
            Me.InsertsLabel.Size = New System.Drawing.Size(41, 13)
            Me.InsertsLabel.TabIndex = 6
            Me.InsertsLabel.Text = "Inserts:"
            '
            'BaseLabel
            '
            Me.BaseLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.BaseLabel.AutoSize = True
            Me.BaseLabel.Location = New System.Drawing.Point(68, 22)
            Me.BaseLabel.Name = "BaseLabel"
            Me.BaseLabel.Size = New System.Drawing.Size(34, 13)
            Me.BaseLabel.TabIndex = 5
            Me.BaseLabel.Text = "Base:"
            '
            'InsertsDataGridView
            '
            Me.InsertsDataGridView.AllowUserToAddRows = False
            Me.InsertsDataGridView.AllowUserToDeleteRows = False
            Me.InsertsDataGridView.AllowUserToResizeColumns = False
            Me.InsertsDataGridView.AllowUserToResizeRows = False
            Me.InsertsDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.InsertsDataGridView.AutoGenerateColumns = False
            Me.InsertsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.InsertsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewComboBoxColumn1, Me.NumberDataGridViewTextBoxColumn, Me.PageCountDataGridViewTextBoxColumn, Me.StartPage})
            Me.InsertsDataGridView.DataSource = Me.InsertsBindingSource
            Me.InsertsDataGridView.Location = New System.Drawing.Point(13, 58)
            Me.InsertsDataGridView.Name = "InsertsDataGridView"
            Me.InsertsDataGridView.RowHeadersVisible = False
            Me.InsertsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.InsertsDataGridView.Size = New System.Drawing.Size(320, 220)
            Me.InsertsDataGridView.TabIndex = 3
            '
            'DataGridViewComboBoxColumn1
            '
            Me.DataGridViewComboBoxColumn1.DataPropertyName = "PageTypeId"
            Me.DataGridViewComboBoxColumn1.DataSource = Me.PageDefinitionsDataSet
            Me.DataGridViewComboBoxColumn1.DisplayMember = "PageType.DisplayDescrip"
            Me.DataGridViewComboBoxColumn1.HeaderText = "Page Type"
            Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
            Me.DataGridViewComboBoxColumn1.ValueMember = "PageType.PageTypeId"
            Me.DataGridViewComboBoxColumn1.Width = 200
            '
            'NumberDataGridViewTextBoxColumn
            '
            Me.NumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.NumberDataGridViewTextBoxColumn.DataPropertyName = "Number"
            Me.NumberDataGridViewTextBoxColumn.HeaderText = "#"
            Me.NumberDataGridViewTextBoxColumn.Name = "NumberDataGridViewTextBoxColumn"
            Me.NumberDataGridViewTextBoxColumn.ReadOnly = True
            Me.NumberDataGridViewTextBoxColumn.Width = 20
            '
            'PageCountDataGridViewTextBoxColumn
            '
            Me.PageCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.PageCountDataGridViewTextBoxColumn.DataPropertyName = "PageCount"
            Me.PageCountDataGridViewTextBoxColumn.HeaderText = "PageCount"
            Me.PageCountDataGridViewTextBoxColumn.MinimumWidth = 66
            Me.PageCountDataGridViewTextBoxColumn.Name = "PageCountDataGridViewTextBoxColumn"
            '
            'StartPage
            '
            Me.StartPage.DataPropertyName = "StartPage"
            Me.StartPage.HeaderText = "StartPage"
            Me.StartPage.Name = "StartPage"
            Me.StartPage.Visible = False
            '
            'InsertsBindingSource
            '
            Me.InsertsBindingSource.DataMember = "Inserts"
            Me.InsertsBindingSource.DataSource = Me.PageDefinitionsDataSet
            '
            'VehicleIDLabel
            '
            Me.VehicleIDLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.VehicleIDLabel.AutoSize = True
            Me.VehicleIDLabel.Location = New System.Drawing.Point(295, 12)
            Me.VehicleIDLabel.Name = "VehicleIDLabel"
            Me.VehicleIDLabel.Size = New System.Drawing.Size(56, 13)
            Me.VehicleIDLabel.TabIndex = 4
            Me.VehicleIDLabel.Text = "VehicleID:"
            '
            'VehicleIDTextBox
            '
            Me.VehicleIDTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.VehicleIDTextBox.Location = New System.Drawing.Point(361, 9)
            Me.VehicleIDTextBox.Name = "VehicleIDTextBox"
            Me.VehicleIDTextBox.ReadOnly = True
            Me.VehicleIDTextBox.Size = New System.Drawing.Size(91, 20)
            Me.VehicleIDTextBox.TabIndex = 6
            '
            'SizeTableAdapter
            '
            Me.SizeTableAdapter.ClearBeforeFill = True
            '
            'PageListGroupBox
            '
            Me.PageListGroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PageListGroupBox.Controls.Add(Me.PagesDataGridView)
            Me.PageListGroupBox.Location = New System.Drawing.Point(357, 35)
            Me.PageListGroupBox.Name = "PageListGroupBox"
            Me.PageListGroupBox.Size = New System.Drawing.Size(384, 448)
            Me.PageListGroupBox.TabIndex = 3
            Me.PageListGroupBox.TabStop = False
            Me.PageListGroupBox.Text = "Pages"
            '
            'PagesDataGridView
            '
            Me.PagesDataGridView.AllowUserToAddRows = False
            Me.PagesDataGridView.AllowUserToDeleteRows = False
            Me.PagesDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PagesDataGridView.AutoGenerateColumns = False
            Me.PagesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.PagesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PageTypeId, Me.ReceivedOrderDataGridViewTextBoxColumn, Me.SizeIdDataGridViewTextBoxColumn, Me.PageNameDataGridViewTextBoxColumn, Me.SizeDataGridViewTextBoxColumn, Me.InsertNumber, Me.PageNumber, Me.PageStartDt, Me.PageEndDt})
            Me.PagesDataGridView.DataSource = Me.PagesBindingSource
            Me.PagesDataGridView.Location = New System.Drawing.Point(12, 17)
            Me.PagesDataGridView.Name = "PagesDataGridView"
            Me.PagesDataGridView.ReadOnly = True
            Me.PagesDataGridView.RowHeadersVisible = False
            Me.PagesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.PagesDataGridView.Size = New System.Drawing.Size(361, 415)
            Me.PagesDataGridView.TabIndex = 1
            Me.PagesDataGridView.TabStop = False
            '
            'PageTypeId
            '
            Me.PageTypeId.DataPropertyName = "PageTypeId"
            Me.PageTypeId.HeaderText = "PageTypeId"
            Me.PageTypeId.Name = "PageTypeId"
            Me.PageTypeId.ReadOnly = True
            Me.PageTypeId.Visible = False
            '
            'ReceivedOrderDataGridViewTextBoxColumn
            '
            Me.ReceivedOrderDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
            Me.ReceivedOrderDataGridViewTextBoxColumn.DataPropertyName = "ReceivedOrder"
            Me.ReceivedOrderDataGridViewTextBoxColumn.HeaderText = "#"
            Me.ReceivedOrderDataGridViewTextBoxColumn.Name = "ReceivedOrderDataGridViewTextBoxColumn"
            Me.ReceivedOrderDataGridViewTextBoxColumn.ReadOnly = True
            Me.ReceivedOrderDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
            Me.ReceivedOrderDataGridViewTextBoxColumn.Width = 20
            '
            'SizeIdDataGridViewTextBoxColumn
            '
            Me.SizeIdDataGridViewTextBoxColumn.DataPropertyName = "SizeId"
            Me.SizeIdDataGridViewTextBoxColumn.HeaderText = "SizeId"
            Me.SizeIdDataGridViewTextBoxColumn.Name = "SizeIdDataGridViewTextBoxColumn"
            Me.SizeIdDataGridViewTextBoxColumn.ReadOnly = True
            Me.SizeIdDataGridViewTextBoxColumn.Visible = False
            '
            'PageNameDataGridViewTextBoxColumn
            '
            Me.PageNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
            Me.PageNameDataGridViewTextBoxColumn.DataPropertyName = "PageName"
            Me.PageNameDataGridViewTextBoxColumn.HeaderText = "Page"
            Me.PageNameDataGridViewTextBoxColumn.Name = "PageNameDataGridViewTextBoxColumn"
            Me.PageNameDataGridViewTextBoxColumn.ReadOnly = True
            Me.PageNameDataGridViewTextBoxColumn.Width = 57
            '
            'SizeDataGridViewTextBoxColumn
            '
            Me.SizeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
            Me.SizeDataGridViewTextBoxColumn.DataPropertyName = "Size"
            Me.SizeDataGridViewTextBoxColumn.HeaderText = "Size"
            Me.SizeDataGridViewTextBoxColumn.Name = "SizeDataGridViewTextBoxColumn"
            Me.SizeDataGridViewTextBoxColumn.ReadOnly = True
            '
            'InsertNumber
            '
            Me.InsertNumber.DataPropertyName = "InsertNumber"
            Me.InsertNumber.HeaderText = "InsertNumber"
            Me.InsertNumber.Name = "InsertNumber"
            Me.InsertNumber.ReadOnly = True
            Me.InsertNumber.Visible = False
            '
            'PageNumber
            '
            Me.PageNumber.DataPropertyName = "PageNumber"
            Me.PageNumber.HeaderText = "PageNumber"
            Me.PageNumber.Name = "PageNumber"
            Me.PageNumber.ReadOnly = True
            Me.PageNumber.Visible = False
            '
            'PageStartDt
            '
            Me.PageStartDt.DataPropertyName = "PageStartDt"
            Me.PageStartDt.HeaderText = "Page Sale Start "
            Me.PageStartDt.Name = "PageStartDt"
            Me.PageStartDt.ReadOnly = True
            '
            'PageEndDt
            '
            Me.PageEndDt.DataPropertyName = "PageEndDt"
            Me.PageEndDt.HeaderText = "Page Sale End"
            Me.PageEndDt.Name = "PageEndDt"
            Me.PageEndDt.ReadOnly = True
            '
            'VehicleStartEndLabel
            '
            Me.VehicleStartEndLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.VehicleStartEndLabel.AutoSize = True
            Me.VehicleStartEndLabel.Location = New System.Drawing.Point(464, 12)
            Me.VehicleStartEndLabel.Name = "VehicleStartEndLabel"
            Me.VehicleStartEndLabel.Size = New System.Drawing.Size(0, 13)
            Me.VehicleStartEndLabel.TabIndex = 12
            '
            'PageDefinitionsForm
            '
            Me.AcceptButton = Me.OKButton
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.CancelButton = Me.CancelButton2
            Me.ClientSize = New System.Drawing.Size(753, 522)
            Me.Controls.Add(Me.VehicleStartEndLabel)
            Me.Controls.Add(Me.PageListGroupBox)
            Me.Controls.Add(Me.VehicleIDTextBox)
            Me.Controls.Add(Me.VehicleIDLabel)
            Me.Controls.Add(Me.PageTypesGroupBox)
            Me.Controls.Add(Me.CancelButton2)
            Me.Controls.Add(Me.OKButton)
            Me.Controls.Add(Me.PageSizePlacementGroupBox)
            Me.Name = "PageDefinitionsForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.StatusMessage = ""
            Me.Text = "Page Definitions"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PageSizePlacementGroupBox.ResumeLayout(False)
            Me.PageSizePlacementGroupBox.PerformLayout()
            CType(Me.SizeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PageDefinitionsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PagesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PageTypesGroupBox.ResumeLayout(False)
            Me.PageTypesGroupBox.PerformLayout()
            CType(Me.InsertsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.InsertsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PageListGroupBox.ResumeLayout(False)
            CType(Me.PagesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
    Friend WithEvents PageSizePlacementGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents SizeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents PageOrderComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents PageNameComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents PrevButton As System.Windows.Forms.Button
    Friend WithEvents CopyToNextButton As System.Windows.Forms.Button
    Friend WithEvents CopyToAllButton As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Shadows WithEvents CancelButton2 As System.Windows.Forms.Button
    Friend WithEvents PageTypesGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents InsertsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents BaseLabel As System.Windows.Forms.Label
    Friend WithEvents InsertsLabel As System.Windows.Forms.Label
    Friend WithEvents VehicleIDLabel As System.Windows.Forms.Label
    Friend WithEvents VehicleIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BaseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PageDefinitionsDataSet As MCAP.PageDefinitionsDataSet
    Friend WithEvents SizeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SizeTableAdapter As MCAP.PageDefinitionsDataSetTableAdapters.SizeTableAdapter
    Friend WithEvents PageListGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents InsertsBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents PagesBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents sizeMaskedTextBox As System.Windows.Forms.MaskedTextBox
        Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents NumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PageCountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents StartPage As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents VehicleStartEndLabel As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents EndDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents StartDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents PagesDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents PageTypeId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ReceivedOrderDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents SizeIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PageNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents SizeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents InsertNumber As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PageNumber As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PageStartDt As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PageEndDt As System.Windows.Forms.DataGridViewTextBoxColumn

	End Class
End NameSpace