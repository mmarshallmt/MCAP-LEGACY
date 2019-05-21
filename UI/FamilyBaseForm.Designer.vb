Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class FamilyBaseForm
    Inherits UI.MDIChildFormBase

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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FamilyBaseForm))
            Me.topPanel = New System.Windows.Forms.Panel()
            Me.familyDataGridView = New System.Windows.Forms.DataGridView()
            Me.DisplayFamilyInformationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.FamilyDataSet = New MCAP.FamilyDataSet()
            Me.bottomPanel = New System.Windows.Forms.Panel()
            Me.DisplayFamilyInformationTableAdapter = New MCAP.FamilyDataSetTableAdapters.DisplayFamilyInformationTableAdapter()
            Me.FrontPageDataGridViewImageColumn = New System.Windows.Forms.DataGridViewImageColumn()
            Me.BackPageDataGridViewImageColumn = New System.Windows.Forms.DataGridViewImageColumn()
            Me.ViewFamily = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.VehicleIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.CreateDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.RetailerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.MarketDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.MediaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ThemeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.EventDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.BreakDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.StartDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.EndDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.FirstMarketDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ReviewDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.IsReviewedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ActualPageCountDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.FamilyIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.SizeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ReviewedByIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.LanguageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.VehicleStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.FlashStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.FlyerId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.HpStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.AltMasterIndRadioButtonColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.familyDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DisplayFamilyInformationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.FamilyDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'topPanel
            '
            Me.topPanel.Dock = System.Windows.Forms.DockStyle.Top
            Me.topPanel.Location = New System.Drawing.Point(0, 0)
            Me.topPanel.Name = "topPanel"
            Me.topPanel.Size = New System.Drawing.Size(921, 100)
            Me.topPanel.TabIndex = 0
            '
            'familyDataGridView
            '
            Me.familyDataGridView.AllowUserToAddRows = False
            Me.familyDataGridView.AllowUserToDeleteRows = False
            Me.familyDataGridView.AutoGenerateColumns = False
            Me.familyDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.familyDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
            Me.familyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.familyDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FrontPageDataGridViewImageColumn, Me.BackPageDataGridViewImageColumn, Me.ViewFamily, Me.VehicleIdDataGridViewTextBoxColumn, Me.CreateDtDataGridViewTextBoxColumn, Me.RetailerDataGridViewTextBoxColumn, Me.MarketDataGridViewTextBoxColumn, Me.MediaDataGridViewTextBoxColumn, Me.ThemeDataGridViewTextBoxColumn, Me.EventDataGridViewTextBoxColumn, Me.BreakDtDataGridViewTextBoxColumn, Me.StartDtDataGridViewTextBoxColumn, Me.EndDtDataGridViewTextBoxColumn, Me.FirstMarketDataGridViewTextBoxColumn, Me.ReviewDtDataGridViewTextBoxColumn, Me.IsReviewedDataGridViewTextBoxColumn, Me.ActualPageCountDataGridViewTextBoxColumn, Me.FamilyIdDataGridViewTextBoxColumn, Me.SizeDataGridViewTextBoxColumn, Me.ReviewedByIdDataGridViewTextBoxColumn, Me.LanguageDataGridViewTextBoxColumn, Me.VehicleStatus, Me.FlashStatus, Me.FlyerId, Me.HpStatus, Me.AltMasterIndRadioButtonColumn})
            Me.familyDataGridView.DataSource = Me.DisplayFamilyInformationBindingSource
            Me.familyDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.familyDataGridView.Location = New System.Drawing.Point(0, 100)
            Me.familyDataGridView.Name = "familyDataGridView"
            Me.familyDataGridView.ReadOnly = True
            Me.familyDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.familyDataGridView.Size = New System.Drawing.Size(921, 386)
            Me.familyDataGridView.TabIndex = 1
            '
            'DisplayFamilyInformationBindingSource
            '
            Me.DisplayFamilyInformationBindingSource.DataMember = "DisplayFamilyInformation"
            Me.DisplayFamilyInformationBindingSource.DataSource = Me.FamilyDataSet
            '
            'FamilyDataSet
            '
            Me.FamilyDataSet.DataSetName = "FamilyViewDataSet"
            Me.FamilyDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            '
            'bottomPanel
            '
            Me.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.bottomPanel.Location = New System.Drawing.Point(0, 486)
            Me.bottomPanel.Name = "bottomPanel"
            Me.bottomPanel.Size = New System.Drawing.Size(921, 94)
            Me.bottomPanel.TabIndex = 2
            '
            'DisplayFamilyInformationTableAdapter
            '
            Me.DisplayFamilyInformationTableAdapter.ClearBeforeFill = True
            '
            'FrontPageDataGridViewImageColumn
            '
            Me.FrontPageDataGridViewImageColumn.HeaderText = "Front Page"
            Me.FrontPageDataGridViewImageColumn.Name = "FrontPageDataGridViewImageColumn"
            Me.FrontPageDataGridViewImageColumn.ReadOnly = True
            Me.FrontPageDataGridViewImageColumn.Width = 65
            '
            'BackPageDataGridViewImageColumn
            '
            Me.BackPageDataGridViewImageColumn.HeaderText = "Back Page"
            Me.BackPageDataGridViewImageColumn.Name = "BackPageDataGridViewImageColumn"
            Me.BackPageDataGridViewImageColumn.ReadOnly = True
            Me.BackPageDataGridViewImageColumn.Width = 66
            '
            'ViewFamily
            '
            Me.ViewFamily.HeaderText = "Show Whole Family"
            Me.ViewFamily.Name = "ViewFamily"
            Me.ViewFamily.ReadOnly = True
            Me.ViewFamily.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            Me.ViewFamily.Text = "View Family"
            Me.ViewFamily.UseColumnTextForButtonValue = True
            Me.ViewFamily.Width = 114
            '
            'VehicleIdDataGridViewTextBoxColumn
            '
            Me.VehicleIdDataGridViewTextBoxColumn.DataPropertyName = "VehicleId"
            Me.VehicleIdDataGridViewTextBoxColumn.HeaderText = "Vehicle Id"
            Me.VehicleIdDataGridViewTextBoxColumn.Name = "VehicleIdDataGridViewTextBoxColumn"
            Me.VehicleIdDataGridViewTextBoxColumn.ReadOnly = True
            Me.VehicleIdDataGridViewTextBoxColumn.Width = 73
            '
            'CreateDtDataGridViewTextBoxColumn
            '
            Me.CreateDtDataGridViewTextBoxColumn.DataPropertyName = "CreateDt"
            Me.CreateDtDataGridViewTextBoxColumn.HeaderText = "Create Date"
            Me.CreateDtDataGridViewTextBoxColumn.Name = "CreateDtDataGridViewTextBoxColumn"
            Me.CreateDtDataGridViewTextBoxColumn.ReadOnly = True
            Me.CreateDtDataGridViewTextBoxColumn.Width = 82
            '
            'RetailerDataGridViewTextBoxColumn
            '
            Me.RetailerDataGridViewTextBoxColumn.DataPropertyName = "Retailer"
            Me.RetailerDataGridViewTextBoxColumn.HeaderText = "Retailer"
            Me.RetailerDataGridViewTextBoxColumn.Name = "RetailerDataGridViewTextBoxColumn"
            Me.RetailerDataGridViewTextBoxColumn.ReadOnly = True
            Me.RetailerDataGridViewTextBoxColumn.Width = 68
            '
            'MarketDataGridViewTextBoxColumn
            '
            Me.MarketDataGridViewTextBoxColumn.DataPropertyName = "Market"
            Me.MarketDataGridViewTextBoxColumn.HeaderText = "Market"
            Me.MarketDataGridViewTextBoxColumn.Name = "MarketDataGridViewTextBoxColumn"
            Me.MarketDataGridViewTextBoxColumn.ReadOnly = True
            Me.MarketDataGridViewTextBoxColumn.Width = 65
            '
            'MediaDataGridViewTextBoxColumn
            '
            Me.MediaDataGridViewTextBoxColumn.DataPropertyName = "Media"
            Me.MediaDataGridViewTextBoxColumn.HeaderText = "Media"
            Me.MediaDataGridViewTextBoxColumn.Name = "MediaDataGridViewTextBoxColumn"
            Me.MediaDataGridViewTextBoxColumn.ReadOnly = True
            Me.MediaDataGridViewTextBoxColumn.Width = 61
            '
            'ThemeDataGridViewTextBoxColumn
            '
            Me.ThemeDataGridViewTextBoxColumn.DataPropertyName = "Theme"
            Me.ThemeDataGridViewTextBoxColumn.HeaderText = "Theme"
            Me.ThemeDataGridViewTextBoxColumn.Name = "ThemeDataGridViewTextBoxColumn"
            Me.ThemeDataGridViewTextBoxColumn.ReadOnly = True
            Me.ThemeDataGridViewTextBoxColumn.Width = 65
            '
            'EventDataGridViewTextBoxColumn
            '
            Me.EventDataGridViewTextBoxColumn.DataPropertyName = "Event"
            Me.EventDataGridViewTextBoxColumn.HeaderText = "Event"
            Me.EventDataGridViewTextBoxColumn.Name = "EventDataGridViewTextBoxColumn"
            Me.EventDataGridViewTextBoxColumn.ReadOnly = True
            Me.EventDataGridViewTextBoxColumn.Width = 60
            '
            'BreakDtDataGridViewTextBoxColumn
            '
            Me.BreakDtDataGridViewTextBoxColumn.DataPropertyName = "BreakDt"
            Me.BreakDtDataGridViewTextBoxColumn.HeaderText = "Ad Date"
            Me.BreakDtDataGridViewTextBoxColumn.Name = "BreakDtDataGridViewTextBoxColumn"
            Me.BreakDtDataGridViewTextBoxColumn.ReadOnly = True
            Me.BreakDtDataGridViewTextBoxColumn.Width = 66
            '
            'StartDtDataGridViewTextBoxColumn
            '
            Me.StartDtDataGridViewTextBoxColumn.DataPropertyName = "StartDt"
            Me.StartDtDataGridViewTextBoxColumn.HeaderText = "Start Date"
            Me.StartDtDataGridViewTextBoxColumn.Name = "StartDtDataGridViewTextBoxColumn"
            Me.StartDtDataGridViewTextBoxColumn.ReadOnly = True
            Me.StartDtDataGridViewTextBoxColumn.Width = 74
            '
            'EndDtDataGridViewTextBoxColumn
            '
            Me.EndDtDataGridViewTextBoxColumn.DataPropertyName = "EndDt"
            Me.EndDtDataGridViewTextBoxColumn.HeaderText = "End Date"
            Me.EndDtDataGridViewTextBoxColumn.Name = "EndDtDataGridViewTextBoxColumn"
            Me.EndDtDataGridViewTextBoxColumn.ReadOnly = True
            Me.EndDtDataGridViewTextBoxColumn.Width = 71
            '
            'FirstMarketDataGridViewTextBoxColumn
            '
            Me.FirstMarketDataGridViewTextBoxColumn.DataPropertyName = "FirstMarket"
            Me.FirstMarketDataGridViewTextBoxColumn.HeaderText = "First Market"
            Me.FirstMarketDataGridViewTextBoxColumn.Name = "FirstMarketDataGridViewTextBoxColumn"
            Me.FirstMarketDataGridViewTextBoxColumn.ReadOnly = True
            Me.FirstMarketDataGridViewTextBoxColumn.Width = 80
            '
            'ReviewDtDataGridViewTextBoxColumn
            '
            Me.ReviewDtDataGridViewTextBoxColumn.DataPropertyName = "ReviewDt"
            Me.ReviewDtDataGridViewTextBoxColumn.HeaderText = "Review Date"
            Me.ReviewDtDataGridViewTextBoxColumn.Name = "ReviewDtDataGridViewTextBoxColumn"
            Me.ReviewDtDataGridViewTextBoxColumn.ReadOnly = True
            Me.ReviewDtDataGridViewTextBoxColumn.Width = 87
            '
            'IsReviewedDataGridViewTextBoxColumn
            '
            Me.IsReviewedDataGridViewTextBoxColumn.DataPropertyName = "IsReviewed"
            Me.IsReviewedDataGridViewTextBoxColumn.HeaderText = "Is Reviewed?"
            Me.IsReviewedDataGridViewTextBoxColumn.Name = "IsReviewedDataGridViewTextBoxColumn"
            Me.IsReviewedDataGridViewTextBoxColumn.ReadOnly = True
            Me.IsReviewedDataGridViewTextBoxColumn.Width = 89
            '
            'ActualPageCountDataGridViewTextBoxColumn
            '
            Me.ActualPageCountDataGridViewTextBoxColumn.DataPropertyName = "ActualPageCount"
            Me.ActualPageCountDataGridViewTextBoxColumn.HeaderText = "Pages"
            Me.ActualPageCountDataGridViewTextBoxColumn.Name = "ActualPageCountDataGridViewTextBoxColumn"
            Me.ActualPageCountDataGridViewTextBoxColumn.ReadOnly = True
            Me.ActualPageCountDataGridViewTextBoxColumn.Width = 62
            '
            'FamilyIdDataGridViewTextBoxColumn
            '
            Me.FamilyIdDataGridViewTextBoxColumn.DataPropertyName = "FamilyId"
            Me.FamilyIdDataGridViewTextBoxColumn.HeaderText = "FamilyId"
            Me.FamilyIdDataGridViewTextBoxColumn.Name = "FamilyIdDataGridViewTextBoxColumn"
            Me.FamilyIdDataGridViewTextBoxColumn.ReadOnly = True
            Me.FamilyIdDataGridViewTextBoxColumn.Width = 70
            '
            'SizeDataGridViewTextBoxColumn
            '
            Me.SizeDataGridViewTextBoxColumn.DataPropertyName = "Size"
            Me.SizeDataGridViewTextBoxColumn.HeaderText = "Size"
            Me.SizeDataGridViewTextBoxColumn.Name = "SizeDataGridViewTextBoxColumn"
            Me.SizeDataGridViewTextBoxColumn.ReadOnly = True
            Me.SizeDataGridViewTextBoxColumn.Width = 52
            '
            'ReviewedByIdDataGridViewTextBoxColumn
            '
            Me.ReviewedByIdDataGridViewTextBoxColumn.DataPropertyName = "ReviewedByID"
            Me.ReviewedByIdDataGridViewTextBoxColumn.HeaderText = "ReviewedByID"
            Me.ReviewedByIdDataGridViewTextBoxColumn.Name = "ReviewedByIdDataGridViewTextBoxColumn"
            Me.ReviewedByIdDataGridViewTextBoxColumn.ReadOnly = True
            Me.ReviewedByIdDataGridViewTextBoxColumn.Width = 103
            '
            'LanguageDataGridViewTextBoxColumn
            '
            Me.LanguageDataGridViewTextBoxColumn.DataPropertyName = "Language"
            Me.LanguageDataGridViewTextBoxColumn.HeaderText = "Language"
            Me.LanguageDataGridViewTextBoxColumn.Name = "LanguageDataGridViewTextBoxColumn"
            Me.LanguageDataGridViewTextBoxColumn.ReadOnly = True
            Me.LanguageDataGridViewTextBoxColumn.Width = 80
            '
            'VehicleStatus
            '
            Me.VehicleStatus.DataPropertyName = "VehicleStatus"
            Me.VehicleStatus.HeaderText = "VehicleStatus"
            Me.VehicleStatus.Name = "VehicleStatus"
            Me.VehicleStatus.ReadOnly = True
            Me.VehicleStatus.Width = 97
            '
            'FlashStatus
            '
            Me.FlashStatus.DataPropertyName = "FlashStatus"
            Me.FlashStatus.HeaderText = "FlashStatus"
            Me.FlashStatus.Name = "FlashStatus"
            Me.FlashStatus.ReadOnly = True
            Me.FlashStatus.Width = 87
            '
            'FlyerId
            '
            Me.FlyerId.DataPropertyName = "FlyerId"
            Me.FlyerId.HeaderText = "FlyerId"
            Me.FlyerId.Name = "FlyerId"
            Me.FlyerId.ReadOnly = True
            Me.FlyerId.Width = 63
            '
            'HpStatus
            '
            Me.HpStatus.DataPropertyName = "HPStatus"
            Me.HpStatus.HeaderText = "HP Status"
            Me.HpStatus.Name = "HpStatus"
            Me.HpStatus.ReadOnly = True
            Me.HpStatus.Width = 74
            '
            'AltMasterIndRadioButtonColumn
            '
            Me.AltMasterIndRadioButtonColumn.DataPropertyName = "AltMasterInd"
            Me.AltMasterIndRadioButtonColumn.FalseValue = "0"
            Me.AltMasterIndRadioButtonColumn.HeaderText = "Alt MasterInd"
            Me.AltMasterIndRadioButtonColumn.IndeterminateValue = ""
            Me.AltMasterIndRadioButtonColumn.Name = "AltMasterIndRadioButtonColumn"
            Me.AltMasterIndRadioButtonColumn.ReadOnly = True
            Me.AltMasterIndRadioButtonColumn.TrueValue = "1"
            Me.AltMasterIndRadioButtonColumn.Width = 68
            '
            'FamilyBaseForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(921, 580)
            Me.Controls.Add(Me.familyDataGridView)
            Me.Controls.Add(Me.bottomPanel)
            Me.Controls.Add(Me.topPanel)
            Me.Name = "FamilyBaseForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.StatusMessage = ""
            Me.Text = "FamilyBaseForm"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.familyDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DisplayFamilyInformationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.FamilyDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Protected WithEvents topPanel As System.Windows.Forms.Panel
        Protected WithEvents familyDataGridView As System.Windows.Forms.DataGridView
        Protected WithEvents bottomPanel As System.Windows.Forms.Panel
        Protected WithEvents DisplayFamilyInformationBindingSource As System.Windows.Forms.BindingSource
        Protected WithEvents FamilyDataSet As MCAP.FamilyDataSet
        Protected WithEvents DisplayFamilyInformationTableAdapter As MCAP.FamilyDataSetTableAdapters.DisplayFamilyInformationTableAdapter
        Friend WithEvents FrontPageDataGridViewImageColumn As System.Windows.Forms.DataGridViewImageColumn
        Friend WithEvents BackPageDataGridViewImageColumn As System.Windows.Forms.DataGridViewImageColumn
        Friend WithEvents ViewFamily As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents VehicleIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents CreateDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RetailerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents MarketDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents MediaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ThemeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents EventDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents BreakDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents StartDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents EndDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents FirstMarketDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ReviewDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents IsReviewedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ActualPageCountDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents FamilyIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents SizeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ReviewedByIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents LanguageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents VehicleStatus As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents FlashStatus As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents FlyerId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents HpStatus As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents AltMasterIndRadioButtonColumn As System.Windows.Forms.DataGridViewCheckBoxColumn

  End Class

End Namespace