Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class AdSearchForm
    Inherits UI.MDIChildFormBase

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
            Me.searchGroupBox = New System.Windows.Forms.GroupBox()
            Me.LanguageComboBox = New System.Windows.Forms.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.SenderComboBox = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.StatusComboBox = New System.Windows.Forms.ComboBox()
            Me.Label = New System.Windows.Forms.Label()
            Me.sldCheckBox = New System.Windows.Forms.CheckBox()
            Me.CanadaFlashCheckBox = New System.Windows.Forms.CheckBox()
            Me.newspaperLabel = New System.Windows.Forms.Label()
            Me.newspaperComboBox = New System.Windows.Forms.ComboBox()
            Me.flashCheckBox = New System.Windows.Forms.CheckBox()
            Me.closeButton = New System.Windows.Forms.Button()
            Me.resetButton = New System.Windows.Forms.Button()
            Me.searchButton = New System.Windows.Forms.Button()
            Me.addateRangeGroupBox = New System.Windows.Forms.GroupBox()
            Me.createDateRadioButton = New System.Windows.Forms.RadioButton()
            Me.fromDtLabel = New System.Windows.Forms.Label()
            Me.addateRadioButton = New System.Windows.Forms.RadioButton()
            Me.toTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.fromTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.toLabel = New System.Windows.Forms.Label()
            Me.mediaComboBox = New System.Windows.Forms.ComboBox()
            Me.mediaLabel = New System.Windows.Forms.Label()
            Me.marketComboBox = New System.Windows.Forms.ComboBox()
            Me.marketLabel = New System.Windows.Forms.Label()
            Me.retailerComboBox = New System.Windows.Forms.ComboBox()
            Me.retailerLabel = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.ResultsGroupBox = New System.Windows.Forms.GroupBox()
            Me.vehicleDataGridView = New System.Windows.Forms.DataGridView()
            Me.VehicleListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.AdSearchDataSet = New MCAP.AdSearchDataSet()
            Me.MyStatusStrip = New System.Windows.Forms.StatusStrip()
            Me.SearchLabel = New System.Windows.Forms.ToolStripStatusLabel()
            Me.VehicleListTableAdapter = New MCAP.AdSearchDataSetTableAdapters.VehicleListTableAdapter()
            Me.VehicleIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Flyerid = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CircularIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.VersionNumberTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.FamilyId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.EnvelopeId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.RetailerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.MarketDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.MediaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Subject = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.BreakDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.FlashStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.NewspaperDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.SenderDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PriorityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CreateDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ReQCedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ReQCedDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PageCountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ExportStatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CoverageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.LanguageTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.searchGroupBox.SuspendLayout()
            Me.addateRangeGroupBox.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.ResultsGroupBox.SuspendLayout()
            CType(Me.vehicleDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.VehicleListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AdSearchDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.MyStatusStrip.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
            Me.smalliconImageList.ImageSize = New System.Drawing.Size(16, 16)
            Me.smalliconImageList.ImageStream = Nothing
            '
            'searchGroupBox
            '
            Me.searchGroupBox.Controls.Add(Me.LanguageComboBox)
            Me.searchGroupBox.Controls.Add(Me.Label2)
            Me.searchGroupBox.Controls.Add(Me.SenderComboBox)
            Me.searchGroupBox.Controls.Add(Me.Label1)
            Me.searchGroupBox.Controls.Add(Me.StatusComboBox)
            Me.searchGroupBox.Controls.Add(Me.Label)
            Me.searchGroupBox.Controls.Add(Me.sldCheckBox)
            Me.searchGroupBox.Controls.Add(Me.CanadaFlashCheckBox)
            Me.searchGroupBox.Controls.Add(Me.newspaperLabel)
            Me.searchGroupBox.Controls.Add(Me.newspaperComboBox)
            Me.searchGroupBox.Controls.Add(Me.flashCheckBox)
            Me.searchGroupBox.Controls.Add(Me.closeButton)
            Me.searchGroupBox.Controls.Add(Me.resetButton)
            Me.searchGroupBox.Controls.Add(Me.searchButton)
            Me.searchGroupBox.Controls.Add(Me.addateRangeGroupBox)
            Me.searchGroupBox.Controls.Add(Me.mediaComboBox)
            Me.searchGroupBox.Controls.Add(Me.mediaLabel)
            Me.searchGroupBox.Controls.Add(Me.marketComboBox)
            Me.searchGroupBox.Controls.Add(Me.marketLabel)
            Me.searchGroupBox.Controls.Add(Me.retailerComboBox)
            Me.searchGroupBox.Controls.Add(Me.retailerLabel)
            Me.searchGroupBox.Dock = System.Windows.Forms.DockStyle.Top
            Me.searchGroupBox.Location = New System.Drawing.Point(0, 0)
            Me.searchGroupBox.Name = "searchGroupBox"
            Me.searchGroupBox.Size = New System.Drawing.Size(951, 203)
            Me.searchGroupBox.TabIndex = 0
            Me.searchGroupBox.TabStop = False
            Me.searchGroupBox.Text = "Search"
            '
            'LanguageComboBox
            '
            Me.LanguageComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.LanguageComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.LanguageComboBox.FormattingEnabled = True
            Me.LanguageComboBox.Location = New System.Drawing.Point(68, 176)
            Me.LanguageComboBox.Name = "LanguageComboBox"
            Me.LanguageComboBox.Size = New System.Drawing.Size(299, 21)
            Me.LanguageComboBox.TabIndex = 21
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(6, 178)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(58, 13)
            Me.Label2.TabIndex = 20
            Me.Label2.Text = "Language "
            '
            'SenderComboBox
            '
            Me.SenderComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.SenderComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.SenderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.SenderComboBox.FormattingEnabled = True
            Me.SenderComboBox.Location = New System.Drawing.Point(68, 121)
            Me.SenderComboBox.Name = "SenderComboBox"
            Me.SenderComboBox.Size = New System.Drawing.Size(299, 21)
            Me.SenderComboBox.TabIndex = 19
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(5, 125)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(41, 13)
            Me.Label1.TabIndex = 15
            Me.Label1.Text = "Sender"
            '
            'StatusComboBox
            '
            Me.StatusComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.StatusComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.StatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.StatusComboBox.FormattingEnabled = True
            Me.StatusComboBox.Location = New System.Drawing.Point(68, 148)
            Me.StatusComboBox.Name = "StatusComboBox"
            Me.StatusComboBox.Size = New System.Drawing.Size(299, 21)
            Me.StatusComboBox.TabIndex = 18
            '
            'Label
            '
            Me.Label.AutoSize = True
            Me.Label.Location = New System.Drawing.Point(6, 150)
            Me.Label.Name = "Label"
            Me.Label.Size = New System.Drawing.Size(37, 13)
            Me.Label.TabIndex = 17
            Me.Label.Text = "Status"
            '
            'sldCheckBox
            '
            Me.sldCheckBox.AutoSize = True
            Me.sldCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.sldCheckBox.Location = New System.Drawing.Point(593, 120)
            Me.sldCheckBox.Name = "sldCheckBox"
            Me.sldCheckBox.Size = New System.Drawing.Size(77, 17)
            Me.sldCheckBox.TabIndex = 14
            Me.sldCheckBox.Text = "Show SLD"
            Me.sldCheckBox.UseVisualStyleBackColor = True
            '
            'CanadaFlashCheckBox
            '
            Me.CanadaFlashCheckBox.AutoSize = True
            Me.CanadaFlashCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.CanadaFlashCheckBox.Location = New System.Drawing.Point(486, 121)
            Me.CanadaFlashCheckBox.Name = "CanadaFlashCheckBox"
            Me.CanadaFlashCheckBox.Size = New System.Drawing.Size(91, 17)
            Me.CanadaFlashCheckBox.TabIndex = 13
            Me.CanadaFlashCheckBox.Text = "Canada Flas&h"
            Me.CanadaFlashCheckBox.UseVisualStyleBackColor = True
            '
            'newspaperLabel
            '
            Me.newspaperLabel.AutoSize = True
            Me.newspaperLabel.Location = New System.Drawing.Point(5, 72)
            Me.newspaperLabel.Name = "newspaperLabel"
            Me.newspaperLabel.Size = New System.Drawing.Size(61, 13)
            Me.newspaperLabel.TabIndex = 4
            Me.newspaperLabel.Text = "Ne&wspaper"
            '
            'newspaperComboBox
            '
            Me.newspaperComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.newspaperComboBox.FormattingEnabled = True
            Me.newspaperComboBox.Location = New System.Drawing.Point(68, 69)
            Me.newspaperComboBox.Name = "newspaperComboBox"
            Me.newspaperComboBox.Size = New System.Drawing.Size(299, 21)
            Me.newspaperComboBox.TabIndex = 5
            '
            'flashCheckBox
            '
            Me.flashCheckBox.AutoSize = True
            Me.flashCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.flashCheckBox.Location = New System.Drawing.Point(423, 122)
            Me.flashCheckBox.Name = "flashCheckBox"
            Me.flashCheckBox.Size = New System.Drawing.Size(51, 17)
            Me.flashCheckBox.TabIndex = 9
            Me.flashCheckBox.Text = "Flas&h"
            Me.flashCheckBox.UseVisualStyleBackColor = True
            '
            'closeButton
            '
            Me.closeButton.Location = New System.Drawing.Point(765, 89)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(75, 23)
            Me.closeButton.TabIndex = 12
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'resetButton
            '
            Me.resetButton.Location = New System.Drawing.Point(765, 60)
            Me.resetButton.Name = "resetButton"
            Me.resetButton.Size = New System.Drawing.Size(75, 23)
            Me.resetButton.TabIndex = 11
            Me.resetButton.Text = "Rese&t"
            Me.resetButton.UseVisualStyleBackColor = True
            '
            'searchButton
            '
            Me.searchButton.Location = New System.Drawing.Point(765, 31)
            Me.searchButton.Name = "searchButton"
            Me.searchButton.Size = New System.Drawing.Size(75, 23)
            Me.searchButton.TabIndex = 10
            Me.searchButton.Text = "&Search"
            Me.searchButton.UseVisualStyleBackColor = True
            '
            'addateRangeGroupBox
            '
            Me.addateRangeGroupBox.Controls.Add(Me.createDateRadioButton)
            Me.addateRangeGroupBox.Controls.Add(Me.fromDtLabel)
            Me.addateRangeGroupBox.Controls.Add(Me.addateRadioButton)
            Me.addateRangeGroupBox.Controls.Add(Me.toTypeInDatePicker)
            Me.addateRangeGroupBox.Controls.Add(Me.fromTypeInDatePicker)
            Me.addateRangeGroupBox.Controls.Add(Me.toLabel)
            Me.addateRangeGroupBox.Location = New System.Drawing.Point(429, 15)
            Me.addateRangeGroupBox.Name = "addateRangeGroupBox"
            Me.addateRangeGroupBox.Size = New System.Drawing.Size(247, 99)
            Me.addateRangeGroupBox.TabIndex = 8
            Me.addateRangeGroupBox.TabStop = False
            '
            'createDateRadioButton
            '
            Me.createDateRadioButton.AutoSize = True
            Me.createDateRadioButton.Location = New System.Drawing.Point(116, 16)
            Me.createDateRadioButton.Name = "createDateRadioButton"
            Me.createDateRadioButton.Size = New System.Drawing.Size(82, 17)
            Me.createDateRadioButton.TabIndex = 43
            Me.createDateRadioButton.Text = "Create Date"
            Me.createDateRadioButton.UseVisualStyleBackColor = True
            '
            'fromDtLabel
            '
            Me.fromDtLabel.AutoSize = True
            Me.fromDtLabel.Location = New System.Drawing.Point(8, 48)
            Me.fromDtLabel.Name = "fromDtLabel"
            Me.fromDtLabel.Size = New System.Drawing.Size(30, 13)
            Me.fromDtLabel.TabIndex = 0
            Me.fromDtLabel.Text = "&From"
            '
            'addateRadioButton
            '
            Me.addateRadioButton.AutoSize = True
            Me.addateRadioButton.Checked = True
            Me.addateRadioButton.Location = New System.Drawing.Point(44, 16)
            Me.addateRadioButton.Name = "addateRadioButton"
            Me.addateRadioButton.Size = New System.Drawing.Size(64, 17)
            Me.addateRadioButton.TabIndex = 42
            Me.addateRadioButton.TabStop = True
            Me.addateRadioButton.Text = "Ad Date"
            Me.addateRadioButton.UseVisualStyleBackColor = True
            '
            'toTypeInDatePicker
            '
            Me.toTypeInDatePicker.Location = New System.Drawing.Point(44, 72)
            Me.toTypeInDatePicker.Name = "toTypeInDatePicker"
            Me.toTypeInDatePicker.Size = New System.Drawing.Size(72, 20)
            Me.toTypeInDatePicker.TabIndex = 3
            Me.toTypeInDatePicker.Value = Nothing
            '
            'fromTypeInDatePicker
            '
            Me.fromTypeInDatePicker.Location = New System.Drawing.Point(44, 45)
            Me.fromTypeInDatePicker.Name = "fromTypeInDatePicker"
            Me.fromTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.fromTypeInDatePicker.TabIndex = 1
            Me.fromTypeInDatePicker.Value = Nothing
            '
            'toLabel
            '
            Me.toLabel.AutoSize = True
            Me.toLabel.Location = New System.Drawing.Point(8, 75)
            Me.toLabel.Name = "toLabel"
            Me.toLabel.Size = New System.Drawing.Size(20, 13)
            Me.toLabel.TabIndex = 2
            Me.toLabel.Text = "&To"
            '
            'mediaComboBox
            '
            Me.mediaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.mediaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.mediaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.mediaComboBox.FormattingEnabled = True
            Me.mediaComboBox.Location = New System.Drawing.Point(68, 16)
            Me.mediaComboBox.Name = "mediaComboBox"
            Me.mediaComboBox.Size = New System.Drawing.Size(299, 21)
            Me.mediaComboBox.TabIndex = 1
            '
            'mediaLabel
            '
            Me.mediaLabel.AutoSize = True
            Me.mediaLabel.Location = New System.Drawing.Point(6, 20)
            Me.mediaLabel.Name = "mediaLabel"
            Me.mediaLabel.Size = New System.Drawing.Size(36, 13)
            Me.mediaLabel.TabIndex = 0
            Me.mediaLabel.Text = "M&edia"
            '
            'marketComboBox
            '
            Me.marketComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.marketComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.marketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.marketComboBox.FormattingEnabled = True
            Me.marketComboBox.Location = New System.Drawing.Point(68, 42)
            Me.marketComboBox.Name = "marketComboBox"
            Me.marketComboBox.Size = New System.Drawing.Size(299, 21)
            Me.marketComboBox.TabIndex = 3
            '
            'marketLabel
            '
            Me.marketLabel.AutoSize = True
            Me.marketLabel.Location = New System.Drawing.Point(6, 44)
            Me.marketLabel.Name = "marketLabel"
            Me.marketLabel.Size = New System.Drawing.Size(40, 13)
            Me.marketLabel.TabIndex = 2
            Me.marketLabel.Text = "&Market"
            '
            'retailerComboBox
            '
            Me.retailerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.retailerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.retailerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.retailerComboBox.FormattingEnabled = True
            Me.retailerComboBox.Location = New System.Drawing.Point(68, 95)
            Me.retailerComboBox.Name = "retailerComboBox"
            Me.retailerComboBox.Size = New System.Drawing.Size(299, 21)
            Me.retailerComboBox.TabIndex = 7
            '
            'retailerLabel
            '
            Me.retailerLabel.AutoSize = True
            Me.retailerLabel.Location = New System.Drawing.Point(6, 97)
            Me.retailerLabel.Name = "retailerLabel"
            Me.retailerLabel.Size = New System.Drawing.Size(43, 13)
            Me.retailerLabel.TabIndex = 6
            Me.retailerLabel.Text = "&Retailer"
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.ResultsGroupBox)
            Me.Panel2.Controls.Add(Me.MyStatusStrip)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel2.Location = New System.Drawing.Point(0, 203)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(951, 413)
            Me.Panel2.TabIndex = 3
            '
            'ResultsGroupBox
            '
            Me.ResultsGroupBox.Controls.Add(Me.vehicleDataGridView)
            Me.ResultsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ResultsGroupBox.Location = New System.Drawing.Point(0, 0)
            Me.ResultsGroupBox.Name = "ResultsGroupBox"
            Me.ResultsGroupBox.Size = New System.Drawing.Size(951, 391)
            Me.ResultsGroupBox.TabIndex = 3
            Me.ResultsGroupBox.TabStop = False
            Me.ResultsGroupBox.Text = "Vehicle Results"
            '
            'vehicleDataGridView
            '
            Me.vehicleDataGridView.AllowUserToAddRows = False
            Me.vehicleDataGridView.AllowUserToDeleteRows = False
            Me.vehicleDataGridView.AutoGenerateColumns = False
            Me.vehicleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.vehicleDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VehicleIdDataGridViewTextBoxColumn, Me.Flyerid, Me.CircularIdDataGridViewTextBoxColumn, Me.VersionNumberTextBoxColumn, Me.FamilyId, Me.EnvelopeId, Me.RetailerDataGridViewTextBoxColumn, Me.MarketDataGridViewTextBoxColumn, Me.MediaDataGridViewTextBoxColumn, Me.Subject, Me.BreakDtDataGridViewTextBoxColumn, Me.FlashStatusDataGridViewTextBoxColumn, Me.NewspaperDataGridViewTextBoxColumn, Me.SenderDataGridViewTextBoxColumn, Me.PriorityDataGridViewTextBoxColumn, Me.CreateDtDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.ReQCedByDataGridViewTextBoxColumn, Me.ReQCedDateDataGridViewTextBoxColumn, Me.PageCountDataGridViewTextBoxColumn, Me.ExportStatusDataGridViewTextBoxColumn, Me.CoverageDataGridViewTextBoxColumn, Me.LanguageTextBoxColumn})
            Me.vehicleDataGridView.DataSource = Me.VehicleListBindingSource
            Me.vehicleDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.vehicleDataGridView.Location = New System.Drawing.Point(3, 16)
            Me.vehicleDataGridView.Name = "vehicleDataGridView"
            Me.vehicleDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
            Me.vehicleDataGridView.Size = New System.Drawing.Size(945, 372)
            Me.vehicleDataGridView.TabIndex = 3
            '
            'VehicleListBindingSource
            '
            Me.VehicleListBindingSource.DataMember = "VehicleList"
            Me.VehicleListBindingSource.DataSource = Me.AdSearchDataSet
            '
            'AdSearchDataSet
            '
            Me.AdSearchDataSet.DataSetName = "AdSearchDataSet"
            Me.AdSearchDataSet.EnforceConstraints = False
            Me.AdSearchDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'MyStatusStrip
            '
            Me.MyStatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchLabel})
            Me.MyStatusStrip.Location = New System.Drawing.Point(0, 391)
            Me.MyStatusStrip.Name = "MyStatusStrip"
            Me.MyStatusStrip.Size = New System.Drawing.Size(951, 22)
            Me.MyStatusStrip.TabIndex = 2
            Me.MyStatusStrip.Text = "StatusStrip1"
            '
            'SearchLabel
            '
            Me.SearchLabel.Name = "SearchLabel"
            Me.SearchLabel.Size = New System.Drawing.Size(35, 17)
            Me.SearchLabel.Text = "Done"
            '
            'VehicleListTableAdapter
            '
            Me.VehicleListTableAdapter.ClearBeforeFill = True
            '
            'VehicleIdDataGridViewTextBoxColumn
            '
            Me.VehicleIdDataGridViewTextBoxColumn.DataPropertyName = "VehicleId"
            Me.VehicleIdDataGridViewTextBoxColumn.HeaderText = "VehicleId"
            Me.VehicleIdDataGridViewTextBoxColumn.Name = "VehicleIdDataGridViewTextBoxColumn"
            Me.VehicleIdDataGridViewTextBoxColumn.ReadOnly = True
            '
            'Flyerid
            '
            Me.Flyerid.DataPropertyName = "Flyerid"
            Me.Flyerid.HeaderText = "Flyerid"
            Me.Flyerid.Name = "Flyerid"
            Me.Flyerid.ReadOnly = True
            '
            'CircularIdDataGridViewTextBoxColumn
            '
            Me.CircularIdDataGridViewTextBoxColumn.DataPropertyName = "CircularId"
            Me.CircularIdDataGridViewTextBoxColumn.HeaderText = "CircularId"
            Me.CircularIdDataGridViewTextBoxColumn.Name = "CircularIdDataGridViewTextBoxColumn"
            Me.CircularIdDataGridViewTextBoxColumn.ReadOnly = True
            '
            'VersionNumberTextBoxColumn
            '
            Me.VersionNumberTextBoxColumn.DataPropertyName = "VersionNumber"
            Me.VersionNumberTextBoxColumn.HeaderText = "VersionNumber"
            Me.VersionNumberTextBoxColumn.Name = "VersionNumberTextBoxColumn"
            '
            'FamilyId
            '
            Me.FamilyId.DataPropertyName = "FamilyId"
            Me.FamilyId.HeaderText = "FamilyId"
            Me.FamilyId.Name = "FamilyId"
            '
            'EnvelopeId
            '
            Me.EnvelopeId.DataPropertyName = "EnvelopeId"
            Me.EnvelopeId.HeaderText = "EnvelopeId"
            Me.EnvelopeId.Name = "EnvelopeId"
            Me.EnvelopeId.ReadOnly = True
            '
            'RetailerDataGridViewTextBoxColumn
            '
            Me.RetailerDataGridViewTextBoxColumn.DataPropertyName = "Retailer"
            Me.RetailerDataGridViewTextBoxColumn.HeaderText = "Retailer"
            Me.RetailerDataGridViewTextBoxColumn.Name = "RetailerDataGridViewTextBoxColumn"
            '
            'MarketDataGridViewTextBoxColumn
            '
            Me.MarketDataGridViewTextBoxColumn.DataPropertyName = "Market"
            Me.MarketDataGridViewTextBoxColumn.HeaderText = "Market"
            Me.MarketDataGridViewTextBoxColumn.Name = "MarketDataGridViewTextBoxColumn"
            '
            'MediaDataGridViewTextBoxColumn
            '
            Me.MediaDataGridViewTextBoxColumn.DataPropertyName = "Media"
            Me.MediaDataGridViewTextBoxColumn.HeaderText = "Media"
            Me.MediaDataGridViewTextBoxColumn.Name = "MediaDataGridViewTextBoxColumn"
            '
            'Subject
            '
            Me.Subject.DataPropertyName = "Subject"
            Me.Subject.HeaderText = "Subject"
            Me.Subject.Name = "Subject"
            '
            'BreakDtDataGridViewTextBoxColumn
            '
            Me.BreakDtDataGridViewTextBoxColumn.DataPropertyName = "BreakDt"
            Me.BreakDtDataGridViewTextBoxColumn.HeaderText = "BreakDt"
            Me.BreakDtDataGridViewTextBoxColumn.Name = "BreakDtDataGridViewTextBoxColumn"
            '
            'FlashStatusDataGridViewTextBoxColumn
            '
            Me.FlashStatusDataGridViewTextBoxColumn.DataPropertyName = "FlashStatus"
            Me.FlashStatusDataGridViewTextBoxColumn.HeaderText = "FlashStatus"
            Me.FlashStatusDataGridViewTextBoxColumn.Name = "FlashStatusDataGridViewTextBoxColumn"
            Me.FlashStatusDataGridViewTextBoxColumn.ReadOnly = True
            '
            'NewspaperDataGridViewTextBoxColumn
            '
            Me.NewspaperDataGridViewTextBoxColumn.DataPropertyName = "Newspaper"
            Me.NewspaperDataGridViewTextBoxColumn.HeaderText = "Newspaper"
            Me.NewspaperDataGridViewTextBoxColumn.Name = "NewspaperDataGridViewTextBoxColumn"
            '
            'SenderDataGridViewTextBoxColumn
            '
            Me.SenderDataGridViewTextBoxColumn.DataPropertyName = "Sender"
            Me.SenderDataGridViewTextBoxColumn.HeaderText = "Sender"
            Me.SenderDataGridViewTextBoxColumn.Name = "SenderDataGridViewTextBoxColumn"
            '
            'PriorityDataGridViewTextBoxColumn
            '
            Me.PriorityDataGridViewTextBoxColumn.DataPropertyName = "Priority"
            Me.PriorityDataGridViewTextBoxColumn.HeaderText = "Priority"
            Me.PriorityDataGridViewTextBoxColumn.Name = "PriorityDataGridViewTextBoxColumn"
            '
            'CreateDtDataGridViewTextBoxColumn
            '
            Me.CreateDtDataGridViewTextBoxColumn.DataPropertyName = "CreateDt"
            Me.CreateDtDataGridViewTextBoxColumn.HeaderText = "CreateDt"
            Me.CreateDtDataGridViewTextBoxColumn.Name = "CreateDtDataGridViewTextBoxColumn"
            '
            'StatusDataGridViewTextBoxColumn
            '
            Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
            Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
            Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
            '
            'ReQCedByDataGridViewTextBoxColumn
            '
            Me.ReQCedByDataGridViewTextBoxColumn.DataPropertyName = "ReQCedBy"
            Me.ReQCedByDataGridViewTextBoxColumn.HeaderText = "ReQCedBy"
            Me.ReQCedByDataGridViewTextBoxColumn.Name = "ReQCedByDataGridViewTextBoxColumn"
            Me.ReQCedByDataGridViewTextBoxColumn.ReadOnly = True
            '
            'ReQCedDateDataGridViewTextBoxColumn
            '
            Me.ReQCedDateDataGridViewTextBoxColumn.DataPropertyName = "ReQCedDate"
            Me.ReQCedDateDataGridViewTextBoxColumn.HeaderText = "ReQCedDate"
            Me.ReQCedDateDataGridViewTextBoxColumn.Name = "ReQCedDateDataGridViewTextBoxColumn"
            '
            'PageCountDataGridViewTextBoxColumn
            '
            Me.PageCountDataGridViewTextBoxColumn.DataPropertyName = "PageCount"
            Me.PageCountDataGridViewTextBoxColumn.HeaderText = "PageCount"
            Me.PageCountDataGridViewTextBoxColumn.Name = "PageCountDataGridViewTextBoxColumn"
            Me.PageCountDataGridViewTextBoxColumn.ReadOnly = True
            '
            'ExportStatusDataGridViewTextBoxColumn
            '
            Me.ExportStatusDataGridViewTextBoxColumn.DataPropertyName = "ExportStatus"
            Me.ExportStatusDataGridViewTextBoxColumn.HeaderText = "ExportStatus"
            Me.ExportStatusDataGridViewTextBoxColumn.Name = "ExportStatusDataGridViewTextBoxColumn"
            Me.ExportStatusDataGridViewTextBoxColumn.ReadOnly = True
            '
            'CoverageDataGridViewTextBoxColumn
            '
            Me.CoverageDataGridViewTextBoxColumn.DataPropertyName = "Coverage"
            Me.CoverageDataGridViewTextBoxColumn.HeaderText = "Coverage"
            Me.CoverageDataGridViewTextBoxColumn.Name = "CoverageDataGridViewTextBoxColumn"
            Me.CoverageDataGridViewTextBoxColumn.ReadOnly = True
            '
            'LanguageTextBoxColumn
            '
            Me.LanguageTextBoxColumn.DataPropertyName = "Language"
            Me.LanguageTextBoxColumn.HeaderText = "Language"
            Me.LanguageTextBoxColumn.Name = "LanguageTextBoxColumn"
            '
            'AdSearchForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(951, 616)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.searchGroupBox)
            Me.Name = "AdSearchForm"
            Me.StatusMessage = ""
            Me.Text = "Ad Search"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.searchGroupBox.ResumeLayout(False)
            Me.searchGroupBox.PerformLayout()
            Me.addateRangeGroupBox.ResumeLayout(False)
            Me.addateRangeGroupBox.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.ResultsGroupBox.ResumeLayout(False)
            CType(Me.vehicleDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.VehicleListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AdSearchDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.MyStatusStrip.ResumeLayout(False)
            Me.MyStatusStrip.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents searchGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents retailerComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents retailerLabel As System.Windows.Forms.Label
        Friend WithEvents mediaComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents mediaLabel As System.Windows.Forms.Label
        Friend WithEvents marketComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents marketLabel As System.Windows.Forms.Label
        Friend WithEvents fromDtLabel As System.Windows.Forms.Label
        Friend WithEvents toTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents toLabel As System.Windows.Forms.Label
        Friend WithEvents fromTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents addateRangeGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents closeButton As System.Windows.Forms.Button
        Friend WithEvents resetButton As System.Windows.Forms.Button
        Friend WithEvents searchButton As System.Windows.Forms.Button
        Friend WithEvents flashCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents newspaperLabel As System.Windows.Forms.Label
        Friend WithEvents newspaperComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents CanadaFlashCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents MyStatusStrip As System.Windows.Forms.StatusStrip
        Friend WithEvents SearchLabel As System.Windows.Forms.ToolStripStatusLabel
        Friend WithEvents VehicleListBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents AdSearchDataSet As MCAP.AdSearchDataSet
        Friend WithEvents VehicleListTableAdapter As MCAP.AdSearchDataSetTableAdapters.VehicleListTableAdapter
        Friend WithEvents ResultsGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents vehicleDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents MktIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents MediaIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RetIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PublicationIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DetailsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents sldCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents StatusComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label As System.Windows.Forms.Label
        Friend WithEvents SenderComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents createDateRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents addateRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents LanguageComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents VehicleIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Flyerid As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CircularIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents VersionNumberTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents FamilyId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents EnvelopeId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RetailerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents MarketDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents MediaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Subject As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents BreakDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents FlashStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents NewspaperDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents SenderDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PriorityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CreateDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents StatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ReQCedByDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ReQCedDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PageCountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ExportStatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CoverageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents LanguageTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

  End Class

End Namespace