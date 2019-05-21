Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class EnvelopeStatusReportForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EnvelopeStatusReportForm))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.envelopeStatusTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
            Me.searchGroupBox = New System.Windows.Forms.GroupBox()
            Me.searchButton = New System.Windows.Forms.Button()
            Me.searchTextBox = New System.Windows.Forms.TextBox()
            Me.envelopeIdLabel = New System.Windows.Forms.Label()
            Me.senderLabel = New System.Windows.Forms.Label()
            Me.senderNameLabel = New System.Windows.Forms.Label()
            Me.packageAssignmentLabel = New System.Windows.Forms.Label()
            Me.packageAssignedLabel = New System.Windows.Forms.Label()
            Me.receiveDateLabel = New System.Windows.Forms.Label()
            Me.receiveDateValueLabel = New System.Windows.Forms.Label()
            Me.ReceivedByLabel = New System.Windows.Forms.Label()
            Me.receivedByNameLabel = New System.Windows.Forms.Label()
            Me.vehicleDataGridView = New System.Windows.Forms.DataGridView()
            Me.StatusReportDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.StatusReportDataSet = New MCAP.StatusReportDataSet()
            Me.EnvelopeIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.VehicleIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.FlyerId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.RetIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.RetailerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.MktIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.MarketDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.PriorityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.BreakDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CreateDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CreatedByIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CreatedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IndexDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IndexedByIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IndexedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ScanDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ScannedByIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ScannedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.QCDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.QCedByIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.QCedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CreateSizedDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.StatusIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.envelopeStatusTableLayoutPanel.SuspendLayout()
            Me.searchGroupBox.SuspendLayout()
            CType(Me.vehicleDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.StatusReportDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.StatusReportDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'envelopeStatusTableLayoutPanel
            '
            Me.envelopeStatusTableLayoutPanel.ColumnCount = 4
            Me.envelopeStatusTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86.0!))
            Me.envelopeStatusTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.envelopeStatusTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117.0!))
            Me.envelopeStatusTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
            Me.envelopeStatusTableLayoutPanel.Controls.Add(Me.searchGroupBox, 0, 0)
            Me.envelopeStatusTableLayoutPanel.Controls.Add(Me.senderLabel, 0, 1)
            Me.envelopeStatusTableLayoutPanel.Controls.Add(Me.senderNameLabel, 1, 1)
            Me.envelopeStatusTableLayoutPanel.Controls.Add(Me.packageAssignmentLabel, 2, 1)
            Me.envelopeStatusTableLayoutPanel.Controls.Add(Me.packageAssignedLabel, 3, 1)
            Me.envelopeStatusTableLayoutPanel.Controls.Add(Me.receiveDateLabel, 0, 2)
            Me.envelopeStatusTableLayoutPanel.Controls.Add(Me.receiveDateValueLabel, 1, 2)
            Me.envelopeStatusTableLayoutPanel.Controls.Add(Me.ReceivedByLabel, 2, 2)
            Me.envelopeStatusTableLayoutPanel.Controls.Add(Me.receivedByNameLabel, 3, 2)
            Me.envelopeStatusTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top
            Me.envelopeStatusTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.envelopeStatusTableLayoutPanel.Name = "envelopeStatusTableLayoutPanel"
            Me.envelopeStatusTableLayoutPanel.RowCount = 3
            Me.envelopeStatusTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55.0!))
            Me.envelopeStatusTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
            Me.envelopeStatusTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
            Me.envelopeStatusTableLayoutPanel.Size = New System.Drawing.Size(763, 103)
            Me.envelopeStatusTableLayoutPanel.TabIndex = 0
            '
            'searchGroupBox
            '
            Me.envelopeStatusTableLayoutPanel.SetColumnSpan(Me.searchGroupBox, 4)
            Me.searchGroupBox.Controls.Add(Me.searchButton)
            Me.searchGroupBox.Controls.Add(Me.searchTextBox)
            Me.searchGroupBox.Controls.Add(Me.envelopeIdLabel)
            Me.searchGroupBox.Dock = System.Windows.Forms.DockStyle.Fill
            Me.searchGroupBox.Location = New System.Drawing.Point(3, 3)
            Me.searchGroupBox.Name = "searchGroupBox"
            Me.searchGroupBox.Size = New System.Drawing.Size(757, 49)
            Me.searchGroupBox.TabIndex = 0
            Me.searchGroupBox.TabStop = False
            Me.searchGroupBox.Text = "Search"
            '
            'searchButton
            '
            Me.searchButton.Location = New System.Drawing.Point(286, 17)
            Me.searchButton.Name = "searchButton"
            Me.searchButton.Size = New System.Drawing.Size(75, 23)
            Me.searchButton.TabIndex = 2
            Me.searchButton.Text = "&Search"
            Me.searchButton.UseVisualStyleBackColor = True
            '
            'searchTextBox
            '
            Me.searchTextBox.Location = New System.Drawing.Point(79, 19)
            Me.searchTextBox.Name = "searchTextBox"
            Me.searchTextBox.Size = New System.Drawing.Size(201, 20)
            Me.searchTextBox.TabIndex = 1
            '
            'envelopeIdLabel
            '
            Me.envelopeIdLabel.AutoSize = True
            Me.envelopeIdLabel.Location = New System.Drawing.Point(6, 22)
            Me.envelopeIdLabel.Name = "envelopeIdLabel"
            Me.envelopeIdLabel.Size = New System.Drawing.Size(67, 13)
            Me.envelopeIdLabel.TabIndex = 0
            Me.envelopeIdLabel.Text = "Envelope Id:"
            '
            'senderLabel
            '
            Me.senderLabel.AutoSize = True
            Me.senderLabel.Location = New System.Drawing.Point(3, 55)
            Me.senderLabel.Name = "senderLabel"
            Me.senderLabel.Size = New System.Drawing.Size(41, 13)
            Me.senderLabel.TabIndex = 1
            Me.senderLabel.Text = "Sender"
            '
            'senderNameLabel
            '
            Me.senderNameLabel.AutoSize = True
            Me.senderNameLabel.Location = New System.Drawing.Point(89, 55)
            Me.senderNameLabel.Name = "senderNameLabel"
            Me.senderNameLabel.Size = New System.Drawing.Size(84, 13)
            Me.senderNameLabel.TabIndex = 2
            Me.senderNameLabel.Text = "<Sender Name>"
            '
            'packageAssignmentLabel
            '
            Me.packageAssignmentLabel.AutoSize = True
            Me.packageAssignmentLabel.Location = New System.Drawing.Point(180, 55)
            Me.packageAssignmentLabel.Name = "packageAssignmentLabel"
            Me.packageAssignmentLabel.Size = New System.Drawing.Size(107, 13)
            Me.packageAssignmentLabel.TabIndex = 3
            Me.packageAssignmentLabel.Text = "Package Assignment"
            Me.packageAssignmentLabel.Visible = False
            '
            'packageAssignedLabel
            '
            Me.packageAssignedLabel.AutoSize = True
            Me.packageAssignedLabel.Location = New System.Drawing.Point(297, 55)
            Me.packageAssignedLabel.Name = "packageAssignedLabel"
            Me.packageAssignedLabel.Size = New System.Drawing.Size(108, 13)
            Me.packageAssignedLabel.TabIndex = 4
            Me.packageAssignedLabel.Text = "<Package Assigned>"
            Me.packageAssignedLabel.Visible = False
            '
            'receiveDateLabel
            '
            Me.receiveDateLabel.AutoSize = True
            Me.receiveDateLabel.Location = New System.Drawing.Point(3, 78)
            Me.receiveDateLabel.Name = "receiveDateLabel"
            Me.receiveDateLabel.Size = New System.Drawing.Size(76, 13)
            Me.receiveDateLabel.TabIndex = 5
            Me.receiveDateLabel.Text = "Receive Date:"
            '
            'receiveDateValueLabel
            '
            Me.receiveDateValueLabel.AutoSize = True
            Me.receiveDateValueLabel.Location = New System.Drawing.Point(89, 78)
            Me.receiveDateValueLabel.Name = "receiveDateValueLabel"
            Me.receiveDateValueLabel.Size = New System.Drawing.Size(85, 13)
            Me.receiveDateValueLabel.TabIndex = 6
            Me.receiveDateValueLabel.Text = "<Receive Date>"
            '
            'ReceivedByLabel
            '
            Me.ReceivedByLabel.AutoSize = True
            Me.ReceivedByLabel.Location = New System.Drawing.Point(180, 78)
            Me.ReceivedByLabel.Name = "ReceivedByLabel"
            Me.ReceivedByLabel.Size = New System.Drawing.Size(71, 13)
            Me.ReceivedByLabel.TabIndex = 7
            Me.ReceivedByLabel.Text = "Received By:"
            '
            'receivedByNameLabel
            '
            Me.receivedByNameLabel.AutoSize = True
            Me.receivedByNameLabel.Location = New System.Drawing.Point(297, 78)
            Me.receivedByNameLabel.Name = "receivedByNameLabel"
            Me.receivedByNameLabel.Size = New System.Drawing.Size(111, 13)
            Me.receivedByNameLabel.TabIndex = 8
            Me.receivedByNameLabel.Text = "<Received By Name>"
            '
            'vehicleDataGridView
            '
            Me.vehicleDataGridView.AllowUserToAddRows = False
            Me.vehicleDataGridView.AllowUserToDeleteRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.vehicleDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.vehicleDataGridView.AutoGenerateColumns = False
            Me.vehicleDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.vehicleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.vehicleDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.EnvelopeIdDataGridViewTextBoxColumn, Me.VehicleIdDataGridViewTextBoxColumn, Me.FlyerId, Me.RetIdDataGridViewTextBoxColumn, Me.RetailerDataGridViewTextBoxColumn, Me.MktIdDataGridViewTextBoxColumn, Me.MarketDataGridViewTextBoxColumn, Me.PriorityDataGridViewTextBoxColumn, Me.BreakDtDataGridViewTextBoxColumn, Me.CreateDtDataGridViewTextBoxColumn, Me.CreatedByIdDataGridViewTextBoxColumn, Me.CreatedByDataGridViewTextBoxColumn, Me.IndexDtDataGridViewTextBoxColumn, Me.IndexedByIdDataGridViewTextBoxColumn, Me.IndexedByDataGridViewTextBoxColumn, Me.ScanDtDataGridViewTextBoxColumn, Me.ScannedByIdDataGridViewTextBoxColumn, Me.ScannedByDataGridViewTextBoxColumn, Me.QCDtDataGridViewTextBoxColumn, Me.QCedByIdDataGridViewTextBoxColumn, Me.QCedByDataGridViewTextBoxColumn, Me.CreateSizedDtDataGridViewTextBoxColumn, Me.StatusIDDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn})
            Me.vehicleDataGridView.DataMember = "vwVehicleStatusReport"
            Me.vehicleDataGridView.DataSource = Me.StatusReportDataSetBindingSource
            Me.vehicleDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.vehicleDataGridView.Location = New System.Drawing.Point(0, 103)
            Me.vehicleDataGridView.Name = "vehicleDataGridView"
            Me.vehicleDataGridView.ReadOnly = True
            Me.vehicleDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.vehicleDataGridView.Size = New System.Drawing.Size(763, 413)
            Me.vehicleDataGridView.TabIndex = 1
            '
            'StatusReportDataSetBindingSource
            '
            Me.StatusReportDataSetBindingSource.DataSource = Me.StatusReportDataSet
            Me.StatusReportDataSetBindingSource.Position = 0
            '
            'StatusReportDataSet
            '
            Me.StatusReportDataSet.DataSetName = "StatusReportDataSet"
            Me.StatusReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'EnvelopeIdDataGridViewTextBoxColumn
            '
            Me.EnvelopeIdDataGridViewTextBoxColumn.DataPropertyName = "EnvelopeId"
            Me.EnvelopeIdDataGridViewTextBoxColumn.HeaderText = "EnvelopeId"
            Me.EnvelopeIdDataGridViewTextBoxColumn.Name = "EnvelopeIdDataGridViewTextBoxColumn"
            Me.EnvelopeIdDataGridViewTextBoxColumn.ReadOnly = True
            Me.EnvelopeIdDataGridViewTextBoxColumn.Visible = False
            Me.EnvelopeIdDataGridViewTextBoxColumn.Width = 86
            '
            'VehicleIdDataGridViewTextBoxColumn
            '
            Me.VehicleIdDataGridViewTextBoxColumn.DataPropertyName = "VehicleId"
            Me.VehicleIdDataGridViewTextBoxColumn.HeaderText = "Vehicle Id"
            Me.VehicleIdDataGridViewTextBoxColumn.Name = "VehicleIdDataGridViewTextBoxColumn"
            Me.VehicleIdDataGridViewTextBoxColumn.ReadOnly = True
            Me.VehicleIdDataGridViewTextBoxColumn.Width = 79
            '
            'FlyerId
            '
            Me.FlyerId.DataPropertyName = "FlyerId"
            Me.FlyerId.HeaderText = "FlyerId"
            Me.FlyerId.Name = "FlyerId"
            Me.FlyerId.ReadOnly = True
            Me.FlyerId.Width = 63
            '
            'RetIdDataGridViewTextBoxColumn
            '
            Me.RetIdDataGridViewTextBoxColumn.DataPropertyName = "RetId"
            Me.RetIdDataGridViewTextBoxColumn.HeaderText = "RetId"
            Me.RetIdDataGridViewTextBoxColumn.Name = "RetIdDataGridViewTextBoxColumn"
            Me.RetIdDataGridViewTextBoxColumn.ReadOnly = True
            Me.RetIdDataGridViewTextBoxColumn.Visible = False
            Me.RetIdDataGridViewTextBoxColumn.Width = 58
            '
            'RetailerDataGridViewTextBoxColumn
            '
            Me.RetailerDataGridViewTextBoxColumn.DataPropertyName = "Retailer"
            Me.RetailerDataGridViewTextBoxColumn.HeaderText = "Retailer"
            Me.RetailerDataGridViewTextBoxColumn.Name = "RetailerDataGridViewTextBoxColumn"
            Me.RetailerDataGridViewTextBoxColumn.ReadOnly = True
            Me.RetailerDataGridViewTextBoxColumn.Width = 68
            '
            'MktIdDataGridViewTextBoxColumn
            '
            Me.MktIdDataGridViewTextBoxColumn.DataPropertyName = "MktId"
            Me.MktIdDataGridViewTextBoxColumn.HeaderText = "MktId"
            Me.MktIdDataGridViewTextBoxColumn.Name = "MktIdDataGridViewTextBoxColumn"
            Me.MktIdDataGridViewTextBoxColumn.ReadOnly = True
            Me.MktIdDataGridViewTextBoxColumn.Visible = False
            Me.MktIdDataGridViewTextBoxColumn.Width = 59
            '
            'MarketDataGridViewTextBoxColumn
            '
            Me.MarketDataGridViewTextBoxColumn.DataPropertyName = "Market"
            Me.MarketDataGridViewTextBoxColumn.HeaderText = "Market"
            Me.MarketDataGridViewTextBoxColumn.Name = "MarketDataGridViewTextBoxColumn"
            Me.MarketDataGridViewTextBoxColumn.ReadOnly = True
            Me.MarketDataGridViewTextBoxColumn.Width = 65
            '
            'PriorityDataGridViewTextBoxColumn
            '
            Me.PriorityDataGridViewTextBoxColumn.DataPropertyName = "Priority"
            Me.PriorityDataGridViewTextBoxColumn.HeaderText = "Priority"
            Me.PriorityDataGridViewTextBoxColumn.Name = "PriorityDataGridViewTextBoxColumn"
            Me.PriorityDataGridViewTextBoxColumn.ReadOnly = True
            Me.PriorityDataGridViewTextBoxColumn.Width = 63
            '
            'BreakDtDataGridViewTextBoxColumn
            '
            Me.BreakDtDataGridViewTextBoxColumn.DataPropertyName = "BreakDt"
            Me.BreakDtDataGridViewTextBoxColumn.HeaderText = "Ad Date"
            Me.BreakDtDataGridViewTextBoxColumn.Name = "BreakDtDataGridViewTextBoxColumn"
            Me.BreakDtDataGridViewTextBoxColumn.ReadOnly = True
            Me.BreakDtDataGridViewTextBoxColumn.Width = 71
            '
            'CreateDtDataGridViewTextBoxColumn
            '
            Me.CreateDtDataGridViewTextBoxColumn.DataPropertyName = "CreateDt"
            Me.CreateDtDataGridViewTextBoxColumn.HeaderText = "Checked-In On"
            Me.CreateDtDataGridViewTextBoxColumn.Name = "CreateDtDataGridViewTextBoxColumn"
            Me.CreateDtDataGridViewTextBoxColumn.ReadOnly = True
            Me.CreateDtDataGridViewTextBoxColumn.Width = 96
            '
            'CreatedByIdDataGridViewTextBoxColumn
            '
            Me.CreatedByIdDataGridViewTextBoxColumn.DataPropertyName = "CreatedById"
            Me.CreatedByIdDataGridViewTextBoxColumn.HeaderText = "CreatedById"
            Me.CreatedByIdDataGridViewTextBoxColumn.Name = "CreatedByIdDataGridViewTextBoxColumn"
            Me.CreatedByIdDataGridViewTextBoxColumn.ReadOnly = True
            Me.CreatedByIdDataGridViewTextBoxColumn.Visible = False
            Me.CreatedByIdDataGridViewTextBoxColumn.Width = 90
            '
            'CreatedByDataGridViewTextBoxColumn
            '
            Me.CreatedByDataGridViewTextBoxColumn.DataPropertyName = "CreatedBy"
            Me.CreatedByDataGridViewTextBoxColumn.HeaderText = "Checked-In By"
            Me.CreatedByDataGridViewTextBoxColumn.Name = "CreatedByDataGridViewTextBoxColumn"
            Me.CreatedByDataGridViewTextBoxColumn.ReadOnly = True
            Me.CreatedByDataGridViewTextBoxColumn.Width = 94
            '
            'IndexDtDataGridViewTextBoxColumn
            '
            Me.IndexDtDataGridViewTextBoxColumn.DataPropertyName = "IndexDt"
            Me.IndexDtDataGridViewTextBoxColumn.HeaderText = "Indexed On"
            Me.IndexDtDataGridViewTextBoxColumn.Name = "IndexDtDataGridViewTextBoxColumn"
            Me.IndexDtDataGridViewTextBoxColumn.ReadOnly = True
            Me.IndexDtDataGridViewTextBoxColumn.Width = 80
            '
            'IndexedByIdDataGridViewTextBoxColumn
            '
            Me.IndexedByIdDataGridViewTextBoxColumn.DataPropertyName = "IndexedById"
            Me.IndexedByIdDataGridViewTextBoxColumn.HeaderText = "IndexedById"
            Me.IndexedByIdDataGridViewTextBoxColumn.Name = "IndexedByIdDataGridViewTextBoxColumn"
            Me.IndexedByIdDataGridViewTextBoxColumn.ReadOnly = True
            Me.IndexedByIdDataGridViewTextBoxColumn.Visible = False
            Me.IndexedByIdDataGridViewTextBoxColumn.Width = 91
            '
            'IndexedByDataGridViewTextBoxColumn
            '
            Me.IndexedByDataGridViewTextBoxColumn.DataPropertyName = "IndexedBy"
            Me.IndexedByDataGridViewTextBoxColumn.HeaderText = "Indexed By"
            Me.IndexedByDataGridViewTextBoxColumn.Name = "IndexedByDataGridViewTextBoxColumn"
            Me.IndexedByDataGridViewTextBoxColumn.ReadOnly = True
            Me.IndexedByDataGridViewTextBoxColumn.Width = 78
            '
            'ScanDtDataGridViewTextBoxColumn
            '
            Me.ScanDtDataGridViewTextBoxColumn.DataPropertyName = "ScanDt"
            Me.ScanDtDataGridViewTextBoxColumn.HeaderText = "Scanned On"
            Me.ScanDtDataGridViewTextBoxColumn.Name = "ScanDtDataGridViewTextBoxColumn"
            Me.ScanDtDataGridViewTextBoxColumn.ReadOnly = True
            Me.ScanDtDataGridViewTextBoxColumn.Width = 85
            '
            'ScannedByIdDataGridViewTextBoxColumn
            '
            Me.ScannedByIdDataGridViewTextBoxColumn.DataPropertyName = "ScannedById"
            Me.ScannedByIdDataGridViewTextBoxColumn.HeaderText = "ScannedById"
            Me.ScannedByIdDataGridViewTextBoxColumn.Name = "ScannedByIdDataGridViewTextBoxColumn"
            Me.ScannedByIdDataGridViewTextBoxColumn.ReadOnly = True
            Me.ScannedByIdDataGridViewTextBoxColumn.Visible = False
            Me.ScannedByIdDataGridViewTextBoxColumn.Width = 96
            '
            'ScannedByDataGridViewTextBoxColumn
            '
            Me.ScannedByDataGridViewTextBoxColumn.DataPropertyName = "ScannedBy"
            Me.ScannedByDataGridViewTextBoxColumn.HeaderText = "Scanned By"
            Me.ScannedByDataGridViewTextBoxColumn.Name = "ScannedByDataGridViewTextBoxColumn"
            Me.ScannedByDataGridViewTextBoxColumn.ReadOnly = True
            Me.ScannedByDataGridViewTextBoxColumn.Width = 83
            '
            'QCDtDataGridViewTextBoxColumn
            '
            Me.QCDtDataGridViewTextBoxColumn.DataPropertyName = "QCDt"
            Me.QCDtDataGridViewTextBoxColumn.HeaderText = "QCed On"
            Me.QCDtDataGridViewTextBoxColumn.Name = "QCDtDataGridViewTextBoxColumn"
            Me.QCDtDataGridViewTextBoxColumn.ReadOnly = True
            Me.QCDtDataGridViewTextBoxColumn.Width = 70
            '
            'QCedByIdDataGridViewTextBoxColumn
            '
            Me.QCedByIdDataGridViewTextBoxColumn.DataPropertyName = "QCedById"
            Me.QCedByIdDataGridViewTextBoxColumn.HeaderText = "QCedById"
            Me.QCedByIdDataGridViewTextBoxColumn.Name = "QCedByIdDataGridViewTextBoxColumn"
            Me.QCedByIdDataGridViewTextBoxColumn.ReadOnly = True
            Me.QCedByIdDataGridViewTextBoxColumn.Visible = False
            Me.QCedByIdDataGridViewTextBoxColumn.Width = 80
            '
            'QCedByDataGridViewTextBoxColumn
            '
            Me.QCedByDataGridViewTextBoxColumn.DataPropertyName = "QCedBy"
            Me.QCedByDataGridViewTextBoxColumn.HeaderText = "QCed By"
            Me.QCedByDataGridViewTextBoxColumn.Name = "QCedByDataGridViewTextBoxColumn"
            Me.QCedByDataGridViewTextBoxColumn.ReadOnly = True
            Me.QCedByDataGridViewTextBoxColumn.Width = 69
            '
            'CreateSizedDtDataGridViewTextBoxColumn
            '
            Me.CreateSizedDtDataGridViewTextBoxColumn.DataPropertyName = "CreateSizedDt"
            Me.CreateSizedDtDataGridViewTextBoxColumn.HeaderText = "Sized On"
            Me.CreateSizedDtDataGridViewTextBoxColumn.Name = "CreateSizedDtDataGridViewTextBoxColumn"
            Me.CreateSizedDtDataGridViewTextBoxColumn.ReadOnly = True
            Me.CreateSizedDtDataGridViewTextBoxColumn.Width = 69
            '
            'StatusIDDataGridViewTextBoxColumn
            '
            Me.StatusIDDataGridViewTextBoxColumn.DataPropertyName = "StatusID"
            Me.StatusIDDataGridViewTextBoxColumn.HeaderText = "StatusID"
            Me.StatusIDDataGridViewTextBoxColumn.Name = "StatusIDDataGridViewTextBoxColumn"
            Me.StatusIDDataGridViewTextBoxColumn.ReadOnly = True
            Me.StatusIDDataGridViewTextBoxColumn.Visible = False
            Me.StatusIDDataGridViewTextBoxColumn.Width = 73
            '
            'StatusDataGridViewTextBoxColumn
            '
            Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
            Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
            Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
            Me.StatusDataGridViewTextBoxColumn.ReadOnly = True
            Me.StatusDataGridViewTextBoxColumn.Width = 62
            '
            'EnvelopeStatusReportForm
            '
            Me.AcceptButton = Me.searchButton
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(763, 516)
            Me.Controls.Add(Me.vehicleDataGridView)
            Me.Controls.Add(Me.envelopeStatusTableLayoutPanel)
            Me.Name = "EnvelopeStatusReportForm"
            Me.StatusMessage = ""
            Me.Text = "Envelope Status"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.envelopeStatusTableLayoutPanel.ResumeLayout(False)
            Me.envelopeStatusTableLayoutPanel.PerformLayout()
            Me.searchGroupBox.ResumeLayout(False)
            Me.searchGroupBox.PerformLayout()
            CType(Me.vehicleDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.StatusReportDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.StatusReportDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
    Friend WithEvents envelopeStatusTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents searchGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents senderLabel As System.Windows.Forms.Label
    Friend WithEvents senderNameLabel As System.Windows.Forms.Label
    Friend WithEvents packageAssignmentLabel As System.Windows.Forms.Label
    Friend WithEvents packageAssignedLabel As System.Windows.Forms.Label
    Friend WithEvents receiveDateLabel As System.Windows.Forms.Label
    Friend WithEvents receiveDateValueLabel As System.Windows.Forms.Label
    Friend WithEvents ReceivedByLabel As System.Windows.Forms.Label
    Friend WithEvents receivedByNameLabel As System.Windows.Forms.Label
    Friend WithEvents vehicleDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents searchButton As System.Windows.Forms.Button
    Friend WithEvents searchTextBox As System.Windows.Forms.TextBox
    Friend WithEvents envelopeIdLabel As System.Windows.Forms.Label
    Friend WithEvents StatusReportDataSetBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents StatusReportDataSet As MCAP.StatusReportDataSet
        Friend WithEvents EnvelopeIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents VehicleIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents FlyerId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RetIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RetailerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents MktIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents MarketDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents PriorityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents BreakDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CreateDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CreatedByIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CreatedByDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents IndexDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents IndexedByIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents IndexedByDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ScanDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ScannedByIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ScannedByDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents QCDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents QCedByIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents QCedByDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CreateSizedDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents StatusIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents StatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

  End Class

End Namespace