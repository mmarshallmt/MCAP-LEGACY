Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class SPReviewForm
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
      Me.components = New System.ComponentModel.Container
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SPReviewForm))
      Me.spreviewTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
      Me.filterButton = New System.Windows.Forms.Button
      Me.spButton = New System.Windows.Forms.Button
      Me.regularButton = New System.Windows.Forms.Button
      Me.closeButton = New System.Windows.Forms.Button
      Me.fromLabel = New System.Windows.Forms.Label
      Me.toLabel = New System.Windows.Forms.Label
      Me.fromTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
      Me.reviewedCheckBox = New System.Windows.Forms.CheckBox
      Me.toTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
      Me.reviewDataGridView = New System.Windows.Forms.DataGridView
      Me.SPReviewDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
      Me.SPReviewDataSet = New MCAP.SPReviewDataSet
      Me.SPReviewStatusIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.SPReviewDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.VehicleIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.EnvelopeIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.WeightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.SenderIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.SenderDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.MediaIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.MediaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.MktIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.MarketDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.PublicationIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.PublicationDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.RetIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.RetailerDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.LanguageIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.LanguageDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.BreakDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.StartDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.EndDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.EventIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.EventDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ThemeIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ThemeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.FamilyIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.PriorityDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.FlashIndDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.NationalIndDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.IsNationalFlashDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.CouponIndDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.CouponDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.CheckInOccurrencesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.PageCountDataGridViewButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn
      Me.CreateDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.CreatedByIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.CreatedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.PullDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.PulledByIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.PulledByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.PullQCDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.PullQCedByIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.PullQCedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.IndexDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.IndexedByIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.IndexedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ScanDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ScannedByIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.ScannedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.QCDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.QCedByIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.QCedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.CreateSizedDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.StatusIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.FTPStatusIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.FTPDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      Me.FormNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
      CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.spreviewTableLayoutPanel.SuspendLayout()
      CType(Me.reviewDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.SPReviewDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.SPReviewDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'smalliconImageList
      '
      Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
      Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
      Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
      '
      'spreviewTableLayoutPanel
      '
      Me.spreviewTableLayoutPanel.ColumnCount = 10
      Me.spreviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.spreviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.spreviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.spreviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.spreviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.spreviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.spreviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.spreviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.spreviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.spreviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.spreviewTableLayoutPanel.Controls.Add(Me.filterButton, 5, 0)
      Me.spreviewTableLayoutPanel.Controls.Add(Me.spButton, 7, 0)
      Me.spreviewTableLayoutPanel.Controls.Add(Me.regularButton, 6, 0)
      Me.spreviewTableLayoutPanel.Controls.Add(Me.closeButton, 8, 0)
      Me.spreviewTableLayoutPanel.Controls.Add(Me.fromLabel, 0, 0)
      Me.spreviewTableLayoutPanel.Controls.Add(Me.toLabel, 2, 0)
      Me.spreviewTableLayoutPanel.Controls.Add(Me.fromTypeInDatePicker, 1, 0)
      Me.spreviewTableLayoutPanel.Controls.Add(Me.reviewedCheckBox, 4, 0)
      Me.spreviewTableLayoutPanel.Controls.Add(Me.toTypeInDatePicker, 3, 0)
      Me.spreviewTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top
      Me.spreviewTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
      Me.spreviewTableLayoutPanel.Name = "spreviewTableLayoutPanel"
      Me.spreviewTableLayoutPanel.RowCount = 1
      Me.spreviewTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.spreviewTableLayoutPanel.Size = New System.Drawing.Size(921, 30)
      Me.spreviewTableLayoutPanel.TabIndex = 0
      '
      'filterButton
      '
      Me.filterButton.Location = New System.Drawing.Point(437, 3)
      Me.filterButton.Name = "filterButton"
      Me.filterButton.Size = New System.Drawing.Size(75, 23)
      Me.filterButton.TabIndex = 5
      Me.filterButton.Text = "&Filter"
      Me.filterButton.UseVisualStyleBackColor = True
      '
      'spButton
      '
      Me.spButton.Location = New System.Drawing.Point(674, 3)
      Me.spButton.Name = "spButton"
      Me.spButton.Size = New System.Drawing.Size(150, 23)
      Me.spButton.TabIndex = 7
      Me.spButton.Text = "Mark as &SP"
      Me.spButton.UseVisualStyleBackColor = True
      '
      'regularButton
      '
      Me.regularButton.Location = New System.Drawing.Point(518, 3)
      Me.regularButton.Name = "regularButton"
      Me.regularButton.Size = New System.Drawing.Size(150, 23)
      Me.regularButton.TabIndex = 6
      Me.regularButton.Text = "Mark as &Regular"
      Me.regularButton.UseVisualStyleBackColor = True
      '
      'closeButton
      '
      Me.closeButton.Location = New System.Drawing.Point(830, 3)
      Me.closeButton.Name = "closeButton"
      Me.closeButton.Size = New System.Drawing.Size(75, 23)
      Me.closeButton.TabIndex = 8
      Me.closeButton.Text = "Cl&ose"
      Me.closeButton.UseVisualStyleBackColor = True
      '
      'fromLabel
      '
      Me.fromLabel.AutoSize = True
      Me.fromLabel.Location = New System.Drawing.Point(3, 7)
      Me.fromLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
      Me.fromLabel.Name = "fromLabel"
      Me.fromLabel.Size = New System.Drawing.Size(88, 13)
      Me.fromLabel.TabIndex = 0
      Me.fromLabel.Text = "Created &between"
      '
      'toLabel
      '
      Me.toLabel.AutoSize = True
      Me.toLabel.Location = New System.Drawing.Point(175, 7)
      Me.toLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
      Me.toLabel.Name = "toLabel"
      Me.toLabel.Size = New System.Drawing.Size(25, 13)
      Me.toLabel.TabIndex = 2
      Me.toLabel.Text = "a&nd"
      '
      'fromTypeInDatePicker
      '
      Me.fromTypeInDatePicker.Location = New System.Drawing.Point(97, 5)
      Me.fromTypeInDatePicker.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
      Me.fromTypeInDatePicker.Name = "fromTypeInDatePicker"
      Me.fromTypeInDatePicker.Size = New System.Drawing.Size(72, 20)
      Me.fromTypeInDatePicker.TabIndex = 1
      Me.fromTypeInDatePicker.Value = Nothing
      '
      'reviewedCheckBox
      '
      Me.reviewedCheckBox.AutoSize = True
      Me.reviewedCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.reviewedCheckBox.Location = New System.Drawing.Point(284, 7)
      Me.reviewedCheckBox.Margin = New System.Windows.Forms.Padding(3, 7, 3, 3)
      Me.reviewedCheckBox.Name = "reviewedCheckBox"
      Me.reviewedCheckBox.Size = New System.Drawing.Size(147, 17)
      Me.reviewedCheckBox.TabIndex = 4
      Me.reviewedCheckBox.Text = "Sho&w Reviewed Vehicles"
      Me.reviewedCheckBox.UseVisualStyleBackColor = True
      '
      'toTypeInDatePicker
      '
      Me.toTypeInDatePicker.Location = New System.Drawing.Point(206, 5)
      Me.toTypeInDatePicker.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
      Me.toTypeInDatePicker.Name = "toTypeInDatePicker"
      Me.toTypeInDatePicker.Size = New System.Drawing.Size(72, 20)
      Me.toTypeInDatePicker.TabIndex = 3
      Me.toTypeInDatePicker.Value = Nothing
      '
      'reviewDataGridView
      '
      Me.reviewDataGridView.AllowUserToAddRows = False
      Me.reviewDataGridView.AllowUserToDeleteRows = False
      Me.reviewDataGridView.AllowUserToOrderColumns = True
      Me.reviewDataGridView.AutoGenerateColumns = False
      Me.reviewDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.reviewDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SPReviewStatusIdDataGridViewTextBoxColumn, Me.SPReviewDataGridViewTextBoxColumn, Me.VehicleIdDataGridViewTextBoxColumn, Me.EnvelopeIdDataGridViewTextBoxColumn, Me.WeightDataGridViewTextBoxColumn, Me.SenderIdDataGridViewTextBoxColumn, Me.SenderDataGridViewTextBoxColumn, Me.MediaIdDataGridViewTextBoxColumn, Me.MediaDataGridViewTextBoxColumn, Me.MktIdDataGridViewTextBoxColumn, Me.MarketDataGridViewTextBoxColumn, Me.PublicationIdDataGridViewTextBoxColumn, Me.PublicationDataGridViewTextBoxColumn, Me.RetIdDataGridViewTextBoxColumn, Me.RetailerDataGridViewTextBoxColumn, Me.LanguageIdDataGridViewTextBoxColumn, Me.LanguageDataGridViewTextBoxColumn, Me.BreakDtDataGridViewTextBoxColumn, Me.StartDtDataGridViewTextBoxColumn, Me.EndDtDataGridViewTextBoxColumn, Me.EventIdDataGridViewTextBoxColumn, Me.EventDataGridViewTextBoxColumn, Me.ThemeIdDataGridViewTextBoxColumn, Me.ThemeDataGridViewTextBoxColumn, Me.FamilyIdDataGridViewTextBoxColumn, Me.PriorityDataGridViewTextBoxColumn, Me.FlashIndDataGridViewTextBoxColumn, Me.NationalIndDataGridViewTextBoxColumn, Me.IsNationalFlashDataGridViewTextBoxColumn, Me.CouponIndDataGridViewTextBoxColumn, Me.CouponDataGridViewTextBoxColumn, Me.CheckInOccurrencesDataGridViewTextBoxColumn, Me.PageCountDataGridViewButtonColumn, Me.CreateDtDataGridViewTextBoxColumn, Me.CreatedByIdDataGridViewTextBoxColumn, Me.CreatedByDataGridViewTextBoxColumn, Me.PullDtDataGridViewTextBoxColumn, Me.PulledByIdDataGridViewTextBoxColumn, Me.PulledByDataGridViewTextBoxColumn, Me.PullQCDtDataGridViewTextBoxColumn, Me.PullQCedByIdDataGridViewTextBoxColumn, Me.PullQCedByDataGridViewTextBoxColumn, Me.IndexDtDataGridViewTextBoxColumn, Me.IndexedByIdDataGridViewTextBoxColumn, Me.IndexedByDataGridViewTextBoxColumn, Me.ScanDtDataGridViewTextBoxColumn, Me.ScannedByIdDataGridViewTextBoxColumn, Me.ScannedByDataGridViewTextBoxColumn, Me.QCDtDataGridViewTextBoxColumn, Me.QCedByIdDataGridViewTextBoxColumn, Me.QCedByDataGridViewTextBoxColumn, Me.CreateSizedDtDataGridViewTextBoxColumn, Me.StatusIdDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.FTPStatusIdDataGridViewTextBoxColumn, Me.FTPDtDataGridViewTextBoxColumn, Me.FormNameDataGridViewTextBoxColumn})
      Me.reviewDataGridView.DataMember = "Vehicle"
      Me.reviewDataGridView.DataSource = Me.SPReviewDataSetBindingSource
      Me.reviewDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.reviewDataGridView.Location = New System.Drawing.Point(0, 30)
      Me.reviewDataGridView.Name = "reviewDataGridView"
      Me.reviewDataGridView.ReadOnly = True
      Me.reviewDataGridView.Size = New System.Drawing.Size(921, 464)
      Me.reviewDataGridView.TabIndex = 1
      '
      'SPReviewDataSetBindingSource
      '
      Me.SPReviewDataSetBindingSource.DataSource = Me.SPReviewDataSet
      Me.SPReviewDataSetBindingSource.Position = 0
      '
      'SPReviewDataSet
      '
      Me.SPReviewDataSet.DataSetName = "SPReviewDataSet"
      Me.SPReviewDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
      '
      'SPReviewStatusIdDataGridViewTextBoxColumn
      '
      Me.SPReviewStatusIdDataGridViewTextBoxColumn.DataPropertyName = "SPReviewStatusId"
      Me.SPReviewStatusIdDataGridViewTextBoxColumn.HeaderText = "SPReviewStatusId"
      Me.SPReviewStatusIdDataGridViewTextBoxColumn.Name = "SPReviewStatusIdDataGridViewTextBoxColumn"
      Me.SPReviewStatusIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.SPReviewStatusIdDataGridViewTextBoxColumn.Visible = False
      '
      'SPReviewDataGridViewTextBoxColumn
      '
      Me.SPReviewDataGridViewTextBoxColumn.DataPropertyName = "SPReview"
      Me.SPReviewDataGridViewTextBoxColumn.HeaderText = "SP Review"
      Me.SPReviewDataGridViewTextBoxColumn.Name = "SPReviewDataGridViewTextBoxColumn"
      Me.SPReviewDataGridViewTextBoxColumn.ReadOnly = True
      '
      'VehicleIdDataGridViewTextBoxColumn
      '
      Me.VehicleIdDataGridViewTextBoxColumn.DataPropertyName = "VehicleId"
      Me.VehicleIdDataGridViewTextBoxColumn.HeaderText = "VehicleId"
      Me.VehicleIdDataGridViewTextBoxColumn.Name = "VehicleIdDataGridViewTextBoxColumn"
      Me.VehicleIdDataGridViewTextBoxColumn.ReadOnly = True
      '
      'EnvelopeIdDataGridViewTextBoxColumn
      '
      Me.EnvelopeIdDataGridViewTextBoxColumn.DataPropertyName = "EnvelopeId"
      Me.EnvelopeIdDataGridViewTextBoxColumn.HeaderText = "EnvelopeId"
      Me.EnvelopeIdDataGridViewTextBoxColumn.Name = "EnvelopeIdDataGridViewTextBoxColumn"
      Me.EnvelopeIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.EnvelopeIdDataGridViewTextBoxColumn.Visible = False
      '
      'WeightDataGridViewTextBoxColumn
      '
      Me.WeightDataGridViewTextBoxColumn.DataPropertyName = "Weight"
      Me.WeightDataGridViewTextBoxColumn.HeaderText = "Weight"
      Me.WeightDataGridViewTextBoxColumn.Name = "WeightDataGridViewTextBoxColumn"
      Me.WeightDataGridViewTextBoxColumn.ReadOnly = True
      Me.WeightDataGridViewTextBoxColumn.Visible = False
      '
      'SenderIdDataGridViewTextBoxColumn
      '
      Me.SenderIdDataGridViewTextBoxColumn.DataPropertyName = "SenderId"
      Me.SenderIdDataGridViewTextBoxColumn.HeaderText = "SenderId"
      Me.SenderIdDataGridViewTextBoxColumn.Name = "SenderIdDataGridViewTextBoxColumn"
      Me.SenderIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.SenderIdDataGridViewTextBoxColumn.Visible = False
      '
      'SenderDataGridViewTextBoxColumn
      '
      Me.SenderDataGridViewTextBoxColumn.DataPropertyName = "Sender"
      Me.SenderDataGridViewTextBoxColumn.HeaderText = "Sender"
      Me.SenderDataGridViewTextBoxColumn.Name = "SenderDataGridViewTextBoxColumn"
      Me.SenderDataGridViewTextBoxColumn.ReadOnly = True
      '
      'MediaIdDataGridViewTextBoxColumn
      '
      Me.MediaIdDataGridViewTextBoxColumn.DataPropertyName = "MediaId"
      Me.MediaIdDataGridViewTextBoxColumn.HeaderText = "MediaId"
      Me.MediaIdDataGridViewTextBoxColumn.Name = "MediaIdDataGridViewTextBoxColumn"
      Me.MediaIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.MediaIdDataGridViewTextBoxColumn.Visible = False
      '
      'MediaDataGridViewTextBoxColumn
      '
      Me.MediaDataGridViewTextBoxColumn.DataPropertyName = "Media"
      Me.MediaDataGridViewTextBoxColumn.HeaderText = "Media"
      Me.MediaDataGridViewTextBoxColumn.Name = "MediaDataGridViewTextBoxColumn"
      Me.MediaDataGridViewTextBoxColumn.ReadOnly = True
      '
      'MktIdDataGridViewTextBoxColumn
      '
      Me.MktIdDataGridViewTextBoxColumn.DataPropertyName = "MktId"
      Me.MktIdDataGridViewTextBoxColumn.HeaderText = "MktId"
      Me.MktIdDataGridViewTextBoxColumn.Name = "MktIdDataGridViewTextBoxColumn"
      Me.MktIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.MktIdDataGridViewTextBoxColumn.Visible = False
      '
      'MarketDataGridViewTextBoxColumn
      '
      Me.MarketDataGridViewTextBoxColumn.DataPropertyName = "Market"
      Me.MarketDataGridViewTextBoxColumn.HeaderText = "Market"
      Me.MarketDataGridViewTextBoxColumn.Name = "MarketDataGridViewTextBoxColumn"
      Me.MarketDataGridViewTextBoxColumn.ReadOnly = True
      '
      'PublicationIdDataGridViewTextBoxColumn
      '
      Me.PublicationIdDataGridViewTextBoxColumn.DataPropertyName = "PublicationId"
      Me.PublicationIdDataGridViewTextBoxColumn.HeaderText = "PublicationId"
      Me.PublicationIdDataGridViewTextBoxColumn.Name = "PublicationIdDataGridViewTextBoxColumn"
      Me.PublicationIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.PublicationIdDataGridViewTextBoxColumn.Visible = False
      '
      'PublicationDataGridViewTextBoxColumn
      '
      Me.PublicationDataGridViewTextBoxColumn.DataPropertyName = "Publication"
      Me.PublicationDataGridViewTextBoxColumn.HeaderText = "Publication"
      Me.PublicationDataGridViewTextBoxColumn.Name = "PublicationDataGridViewTextBoxColumn"
      Me.PublicationDataGridViewTextBoxColumn.ReadOnly = True
      '
      'RetIdDataGridViewTextBoxColumn
      '
      Me.RetIdDataGridViewTextBoxColumn.DataPropertyName = "RetId"
      Me.RetIdDataGridViewTextBoxColumn.HeaderText = "RetId"
      Me.RetIdDataGridViewTextBoxColumn.Name = "RetIdDataGridViewTextBoxColumn"
      Me.RetIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.RetIdDataGridViewTextBoxColumn.Visible = False
      '
      'RetailerDataGridViewTextBoxColumn
      '
      Me.RetailerDataGridViewTextBoxColumn.DataPropertyName = "Retailer"
      Me.RetailerDataGridViewTextBoxColumn.HeaderText = "Retailer"
      Me.RetailerDataGridViewTextBoxColumn.Name = "RetailerDataGridViewTextBoxColumn"
      Me.RetailerDataGridViewTextBoxColumn.ReadOnly = True
      '
      'LanguageIdDataGridViewTextBoxColumn
      '
      Me.LanguageIdDataGridViewTextBoxColumn.DataPropertyName = "LanguageId"
      Me.LanguageIdDataGridViewTextBoxColumn.HeaderText = "LanguageId"
      Me.LanguageIdDataGridViewTextBoxColumn.Name = "LanguageIdDataGridViewTextBoxColumn"
      Me.LanguageIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.LanguageIdDataGridViewTextBoxColumn.Visible = False
      '
      'LanguageDataGridViewTextBoxColumn
      '
      Me.LanguageDataGridViewTextBoxColumn.DataPropertyName = "Language"
      Me.LanguageDataGridViewTextBoxColumn.HeaderText = "Language"
      Me.LanguageDataGridViewTextBoxColumn.Name = "LanguageDataGridViewTextBoxColumn"
      Me.LanguageDataGridViewTextBoxColumn.ReadOnly = True
      '
      'BreakDtDataGridViewTextBoxColumn
      '
      Me.BreakDtDataGridViewTextBoxColumn.DataPropertyName = "BreakDt"
      Me.BreakDtDataGridViewTextBoxColumn.HeaderText = "Ad Date"
      Me.BreakDtDataGridViewTextBoxColumn.Name = "BreakDtDataGridViewTextBoxColumn"
      Me.BreakDtDataGridViewTextBoxColumn.ReadOnly = True
      '
      'StartDtDataGridViewTextBoxColumn
      '
      Me.StartDtDataGridViewTextBoxColumn.DataPropertyName = "StartDt"
      Me.StartDtDataGridViewTextBoxColumn.HeaderText = "Start Date"
      Me.StartDtDataGridViewTextBoxColumn.Name = "StartDtDataGridViewTextBoxColumn"
      Me.StartDtDataGridViewTextBoxColumn.ReadOnly = True
      '
      'EndDtDataGridViewTextBoxColumn
      '
      Me.EndDtDataGridViewTextBoxColumn.DataPropertyName = "EndDt"
      Me.EndDtDataGridViewTextBoxColumn.HeaderText = "End Date"
      Me.EndDtDataGridViewTextBoxColumn.Name = "EndDtDataGridViewTextBoxColumn"
      Me.EndDtDataGridViewTextBoxColumn.ReadOnly = True
      '
      'EventIdDataGridViewTextBoxColumn
      '
      Me.EventIdDataGridViewTextBoxColumn.DataPropertyName = "EventId"
      Me.EventIdDataGridViewTextBoxColumn.HeaderText = "EventId"
      Me.EventIdDataGridViewTextBoxColumn.Name = "EventIdDataGridViewTextBoxColumn"
      Me.EventIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.EventIdDataGridViewTextBoxColumn.Visible = False
      '
      'EventDataGridViewTextBoxColumn
      '
      Me.EventDataGridViewTextBoxColumn.DataPropertyName = "Event"
      Me.EventDataGridViewTextBoxColumn.HeaderText = "Event"
      Me.EventDataGridViewTextBoxColumn.Name = "EventDataGridViewTextBoxColumn"
      Me.EventDataGridViewTextBoxColumn.ReadOnly = True
      '
      'ThemeIdDataGridViewTextBoxColumn
      '
      Me.ThemeIdDataGridViewTextBoxColumn.DataPropertyName = "ThemeId"
      Me.ThemeIdDataGridViewTextBoxColumn.HeaderText = "ThemeId"
      Me.ThemeIdDataGridViewTextBoxColumn.Name = "ThemeIdDataGridViewTextBoxColumn"
      Me.ThemeIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.ThemeIdDataGridViewTextBoxColumn.Visible = False
      '
      'ThemeDataGridViewTextBoxColumn
      '
      Me.ThemeDataGridViewTextBoxColumn.DataPropertyName = "Theme"
      Me.ThemeDataGridViewTextBoxColumn.HeaderText = "Theme"
      Me.ThemeDataGridViewTextBoxColumn.Name = "ThemeDataGridViewTextBoxColumn"
      Me.ThemeDataGridViewTextBoxColumn.ReadOnly = True
      '
      'FamilyIdDataGridViewTextBoxColumn
      '
      Me.FamilyIdDataGridViewTextBoxColumn.DataPropertyName = "FamilyId"
      Me.FamilyIdDataGridViewTextBoxColumn.HeaderText = "FamilyId"
      Me.FamilyIdDataGridViewTextBoxColumn.Name = "FamilyIdDataGridViewTextBoxColumn"
      Me.FamilyIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.FamilyIdDataGridViewTextBoxColumn.Visible = False
      '
      'PriorityDataGridViewTextBoxColumn
      '
      Me.PriorityDataGridViewTextBoxColumn.DataPropertyName = "Priority"
      Me.PriorityDataGridViewTextBoxColumn.HeaderText = "Priority"
      Me.PriorityDataGridViewTextBoxColumn.Name = "PriorityDataGridViewTextBoxColumn"
      Me.PriorityDataGridViewTextBoxColumn.ReadOnly = True
      '
      'FlashIndDataGridViewTextBoxColumn
      '
      Me.FlashIndDataGridViewTextBoxColumn.DataPropertyName = "FlashInd"
      Me.FlashIndDataGridViewTextBoxColumn.HeaderText = "FlashInd"
      Me.FlashIndDataGridViewTextBoxColumn.Name = "FlashIndDataGridViewTextBoxColumn"
      Me.FlashIndDataGridViewTextBoxColumn.ReadOnly = True
      Me.FlashIndDataGridViewTextBoxColumn.Visible = False
      '
      'NationalIndDataGridViewTextBoxColumn
      '
      Me.NationalIndDataGridViewTextBoxColumn.DataPropertyName = "NationalInd"
      Me.NationalIndDataGridViewTextBoxColumn.HeaderText = "NationalInd"
      Me.NationalIndDataGridViewTextBoxColumn.Name = "NationalIndDataGridViewTextBoxColumn"
      Me.NationalIndDataGridViewTextBoxColumn.ReadOnly = True
      Me.NationalIndDataGridViewTextBoxColumn.Visible = False
      '
      'IsNationalFlashDataGridViewTextBoxColumn
      '
      Me.IsNationalFlashDataGridViewTextBoxColumn.DataPropertyName = "IsNationalFlash"
      Me.IsNationalFlashDataGridViewTextBoxColumn.HeaderText = "IsNationalFlash"
      Me.IsNationalFlashDataGridViewTextBoxColumn.Name = "IsNationalFlashDataGridViewTextBoxColumn"
      Me.IsNationalFlashDataGridViewTextBoxColumn.ReadOnly = True
      '
      'CouponIndDataGridViewTextBoxColumn
      '
      Me.CouponIndDataGridViewTextBoxColumn.DataPropertyName = "CouponInd"
      Me.CouponIndDataGridViewTextBoxColumn.HeaderText = "CouponInd"
      Me.CouponIndDataGridViewTextBoxColumn.Name = "CouponIndDataGridViewTextBoxColumn"
      Me.CouponIndDataGridViewTextBoxColumn.ReadOnly = True
      Me.CouponIndDataGridViewTextBoxColumn.Visible = False
      '
      'CouponDataGridViewTextBoxColumn
      '
      Me.CouponDataGridViewTextBoxColumn.DataPropertyName = "Coupon"
      Me.CouponDataGridViewTextBoxColumn.HeaderText = "Coupon"
      Me.CouponDataGridViewTextBoxColumn.Name = "CouponDataGridViewTextBoxColumn"
      Me.CouponDataGridViewTextBoxColumn.ReadOnly = True
      '
      'CheckInOccurrencesDataGridViewTextBoxColumn
      '
      Me.CheckInOccurrencesDataGridViewTextBoxColumn.DataPropertyName = "CheckInOccurrences"
      Me.CheckInOccurrencesDataGridViewTextBoxColumn.HeaderText = "CheckInOccurrences"
      Me.CheckInOccurrencesDataGridViewTextBoxColumn.Name = "CheckInOccurrencesDataGridViewTextBoxColumn"
      Me.CheckInOccurrencesDataGridViewTextBoxColumn.ReadOnly = True
      '
      'PageCountDataGridViewButtonColumn
      '
      Me.PageCountDataGridViewButtonColumn.DataPropertyName = "PageCount"
      Me.PageCountDataGridViewButtonColumn.HeaderText = "Pages"
      Me.PageCountDataGridViewButtonColumn.Name = "PageCountDataGridViewButtonColumn"
      Me.PageCountDataGridViewButtonColumn.ReadOnly = True
      Me.PageCountDataGridViewButtonColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.PageCountDataGridViewButtonColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
      '
      'CreateDtDataGridViewTextBoxColumn
      '
      Me.CreateDtDataGridViewTextBoxColumn.DataPropertyName = "CreateDt"
      Me.CreateDtDataGridViewTextBoxColumn.HeaderText = "Created On"
      Me.CreateDtDataGridViewTextBoxColumn.Name = "CreateDtDataGridViewTextBoxColumn"
      Me.CreateDtDataGridViewTextBoxColumn.ReadOnly = True
      '
      'CreatedByIdDataGridViewTextBoxColumn
      '
      Me.CreatedByIdDataGridViewTextBoxColumn.DataPropertyName = "CreatedById"
      Me.CreatedByIdDataGridViewTextBoxColumn.HeaderText = "CreatedById"
      Me.CreatedByIdDataGridViewTextBoxColumn.Name = "CreatedByIdDataGridViewTextBoxColumn"
      Me.CreatedByIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.CreatedByIdDataGridViewTextBoxColumn.Visible = False
      '
      'CreatedByDataGridViewTextBoxColumn
      '
      Me.CreatedByDataGridViewTextBoxColumn.DataPropertyName = "CreatedBy"
      Me.CreatedByDataGridViewTextBoxColumn.HeaderText = "Created By"
      Me.CreatedByDataGridViewTextBoxColumn.Name = "CreatedByDataGridViewTextBoxColumn"
      Me.CreatedByDataGridViewTextBoxColumn.ReadOnly = True
      '
      'PullDtDataGridViewTextBoxColumn
      '
      Me.PullDtDataGridViewTextBoxColumn.DataPropertyName = "PullDt"
      Me.PullDtDataGridViewTextBoxColumn.HeaderText = "Pulled On"
      Me.PullDtDataGridViewTextBoxColumn.Name = "PullDtDataGridViewTextBoxColumn"
      Me.PullDtDataGridViewTextBoxColumn.ReadOnly = True
      '
      'PulledByIdDataGridViewTextBoxColumn
      '
      Me.PulledByIdDataGridViewTextBoxColumn.DataPropertyName = "PulledById"
      Me.PulledByIdDataGridViewTextBoxColumn.HeaderText = "PulledById"
      Me.PulledByIdDataGridViewTextBoxColumn.Name = "PulledByIdDataGridViewTextBoxColumn"
      Me.PulledByIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.PulledByIdDataGridViewTextBoxColumn.Visible = False
      '
      'PulledByDataGridViewTextBoxColumn
      '
      Me.PulledByDataGridViewTextBoxColumn.DataPropertyName = "PulledBy"
      Me.PulledByDataGridViewTextBoxColumn.HeaderText = "Pulled By"
      Me.PulledByDataGridViewTextBoxColumn.Name = "PulledByDataGridViewTextBoxColumn"
      Me.PulledByDataGridViewTextBoxColumn.ReadOnly = True
      '
      'PullQCDtDataGridViewTextBoxColumn
      '
      Me.PullQCDtDataGridViewTextBoxColumn.DataPropertyName = "PullQCDt"
      Me.PullQCDtDataGridViewTextBoxColumn.HeaderText = "Pull QCed On"
      Me.PullQCDtDataGridViewTextBoxColumn.Name = "PullQCDtDataGridViewTextBoxColumn"
      Me.PullQCDtDataGridViewTextBoxColumn.ReadOnly = True
      '
      'PullQCedByIdDataGridViewTextBoxColumn
      '
      Me.PullQCedByIdDataGridViewTextBoxColumn.DataPropertyName = "PullQCedById"
      Me.PullQCedByIdDataGridViewTextBoxColumn.HeaderText = "PullQCedById"
      Me.PullQCedByIdDataGridViewTextBoxColumn.Name = "PullQCedByIdDataGridViewTextBoxColumn"
      Me.PullQCedByIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.PullQCedByIdDataGridViewTextBoxColumn.Visible = False
      '
      'PullQCedByDataGridViewTextBoxColumn
      '
      Me.PullQCedByDataGridViewTextBoxColumn.DataPropertyName = "PullQCedBy"
      Me.PullQCedByDataGridViewTextBoxColumn.HeaderText = "Pull QCed By"
      Me.PullQCedByDataGridViewTextBoxColumn.Name = "PullQCedByDataGridViewTextBoxColumn"
      Me.PullQCedByDataGridViewTextBoxColumn.ReadOnly = True
      '
      'IndexDtDataGridViewTextBoxColumn
      '
      Me.IndexDtDataGridViewTextBoxColumn.DataPropertyName = "IndexDt"
      Me.IndexDtDataGridViewTextBoxColumn.HeaderText = "Indexed On"
      Me.IndexDtDataGridViewTextBoxColumn.Name = "IndexDtDataGridViewTextBoxColumn"
      Me.IndexDtDataGridViewTextBoxColumn.ReadOnly = True
      '
      'IndexedByIdDataGridViewTextBoxColumn
      '
      Me.IndexedByIdDataGridViewTextBoxColumn.DataPropertyName = "IndexedById"
      Me.IndexedByIdDataGridViewTextBoxColumn.HeaderText = "IndexedById"
      Me.IndexedByIdDataGridViewTextBoxColumn.Name = "IndexedByIdDataGridViewTextBoxColumn"
      Me.IndexedByIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.IndexedByIdDataGridViewTextBoxColumn.Visible = False
      '
      'IndexedByDataGridViewTextBoxColumn
      '
      Me.IndexedByDataGridViewTextBoxColumn.DataPropertyName = "IndexedBy"
      Me.IndexedByDataGridViewTextBoxColumn.HeaderText = "Indexed By"
      Me.IndexedByDataGridViewTextBoxColumn.Name = "IndexedByDataGridViewTextBoxColumn"
      Me.IndexedByDataGridViewTextBoxColumn.ReadOnly = True
      '
      'ScanDtDataGridViewTextBoxColumn
      '
      Me.ScanDtDataGridViewTextBoxColumn.DataPropertyName = "ScanDt"
      Me.ScanDtDataGridViewTextBoxColumn.HeaderText = "Scanned On"
      Me.ScanDtDataGridViewTextBoxColumn.Name = "ScanDtDataGridViewTextBoxColumn"
      Me.ScanDtDataGridViewTextBoxColumn.ReadOnly = True
      '
      'ScannedByIdDataGridViewTextBoxColumn
      '
      Me.ScannedByIdDataGridViewTextBoxColumn.DataPropertyName = "ScannedById"
      Me.ScannedByIdDataGridViewTextBoxColumn.HeaderText = "ScannedById"
      Me.ScannedByIdDataGridViewTextBoxColumn.Name = "ScannedByIdDataGridViewTextBoxColumn"
      Me.ScannedByIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.ScannedByIdDataGridViewTextBoxColumn.Visible = False
      '
      'ScannedByDataGridViewTextBoxColumn
      '
      Me.ScannedByDataGridViewTextBoxColumn.DataPropertyName = "ScannedBy"
      Me.ScannedByDataGridViewTextBoxColumn.HeaderText = "Scanned By"
      Me.ScannedByDataGridViewTextBoxColumn.Name = "ScannedByDataGridViewTextBoxColumn"
      Me.ScannedByDataGridViewTextBoxColumn.ReadOnly = True
      '
      'QCDtDataGridViewTextBoxColumn
      '
      Me.QCDtDataGridViewTextBoxColumn.DataPropertyName = "QCDt"
      Me.QCDtDataGridViewTextBoxColumn.HeaderText = "QCed On"
      Me.QCDtDataGridViewTextBoxColumn.Name = "QCDtDataGridViewTextBoxColumn"
      Me.QCDtDataGridViewTextBoxColumn.ReadOnly = True
      '
      'QCedByIdDataGridViewTextBoxColumn
      '
      Me.QCedByIdDataGridViewTextBoxColumn.DataPropertyName = "QCedById"
      Me.QCedByIdDataGridViewTextBoxColumn.HeaderText = "QCedById"
      Me.QCedByIdDataGridViewTextBoxColumn.Name = "QCedByIdDataGridViewTextBoxColumn"
      Me.QCedByIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.QCedByIdDataGridViewTextBoxColumn.Visible = False
      '
      'QCedByDataGridViewTextBoxColumn
      '
      Me.QCedByDataGridViewTextBoxColumn.DataPropertyName = "QCedBy"
      Me.QCedByDataGridViewTextBoxColumn.HeaderText = "QCed By"
      Me.QCedByDataGridViewTextBoxColumn.Name = "QCedByDataGridViewTextBoxColumn"
      Me.QCedByDataGridViewTextBoxColumn.ReadOnly = True
      '
      'CreateSizedDtDataGridViewTextBoxColumn
      '
      Me.CreateSizedDtDataGridViewTextBoxColumn.DataPropertyName = "CreateSizedDt"
      Me.CreateSizedDtDataGridViewTextBoxColumn.HeaderText = "Sized On"
      Me.CreateSizedDtDataGridViewTextBoxColumn.Name = "CreateSizedDtDataGridViewTextBoxColumn"
      Me.CreateSizedDtDataGridViewTextBoxColumn.ReadOnly = True
      '
      'StatusIdDataGridViewTextBoxColumn
      '
      Me.StatusIdDataGridViewTextBoxColumn.DataPropertyName = "StatusId"
      Me.StatusIdDataGridViewTextBoxColumn.HeaderText = "StatusId"
      Me.StatusIdDataGridViewTextBoxColumn.Name = "StatusIdDataGridViewTextBoxColumn"
      Me.StatusIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.StatusIdDataGridViewTextBoxColumn.Visible = False
      '
      'StatusDataGridViewTextBoxColumn
      '
      Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
      Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
      Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
      Me.StatusDataGridViewTextBoxColumn.ReadOnly = True
      '
      'FTPStatusIdDataGridViewTextBoxColumn
      '
      Me.FTPStatusIdDataGridViewTextBoxColumn.DataPropertyName = "FTPStatusId"
      Me.FTPStatusIdDataGridViewTextBoxColumn.HeaderText = "FTPStatusId"
      Me.FTPStatusIdDataGridViewTextBoxColumn.Name = "FTPStatusIdDataGridViewTextBoxColumn"
      Me.FTPStatusIdDataGridViewTextBoxColumn.ReadOnly = True
      Me.FTPStatusIdDataGridViewTextBoxColumn.Visible = False
      '
      'FTPDtDataGridViewTextBoxColumn
      '
      Me.FTPDtDataGridViewTextBoxColumn.DataPropertyName = "FTPDt"
      Me.FTPDtDataGridViewTextBoxColumn.HeaderText = "FTPDt"
      Me.FTPDtDataGridViewTextBoxColumn.Name = "FTPDtDataGridViewTextBoxColumn"
      Me.FTPDtDataGridViewTextBoxColumn.ReadOnly = True
      Me.FTPDtDataGridViewTextBoxColumn.Visible = False
      '
      'FormNameDataGridViewTextBoxColumn
      '
      Me.FormNameDataGridViewTextBoxColumn.DataPropertyName = "FormName"
      Me.FormNameDataGridViewTextBoxColumn.HeaderText = "FormName"
      Me.FormNameDataGridViewTextBoxColumn.Name = "FormNameDataGridViewTextBoxColumn"
      Me.FormNameDataGridViewTextBoxColumn.ReadOnly = True
      Me.FormNameDataGridViewTextBoxColumn.Visible = False
      '
      'SPReviewForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(921, 494)
      Me.Controls.Add(Me.reviewDataGridView)
      Me.Controls.Add(Me.spreviewTableLayoutPanel)
      Me.Name = "SPReviewForm"
      Me.StatusMessage = ""
      Me.Text = "SP Review "
      CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
      Me.spreviewTableLayoutPanel.ResumeLayout(False)
      Me.spreviewTableLayoutPanel.PerformLayout()
      CType(Me.reviewDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.SPReviewDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.SPReviewDataSet, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub
    Friend WithEvents spreviewTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents reviewDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents filterButton As System.Windows.Forms.Button
    Friend WithEvents spButton As System.Windows.Forms.Button
    Friend WithEvents regularButton As System.Windows.Forms.Button
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents fromLabel As System.Windows.Forms.Label
    Friend WithEvents toLabel As System.Windows.Forms.Label
    Friend WithEvents fromTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
    Friend WithEvents reviewedCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents toTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
    Friend WithEvents SPReviewDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SPReviewDataSet As MCAP.SPReviewDataSet
    Friend WithEvents SPReviewStatusIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPReviewDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VehicleIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EnvelopeIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WeightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SenderIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SenderDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MediaIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MediaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MktIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarketDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PublicationIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PublicationDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RetIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RetailerDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LanguageIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LanguageDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BreakDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EventIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EventDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ThemeIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ThemeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FamilyIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriorityDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FlashIndDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NationalIndDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsNationalFlashDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CouponIndDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CouponDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckInOccurrencesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PageCountDataGridViewButtonColumn As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents CreateDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedByIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreatedByDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PullDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PulledByIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PulledByDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PullQCDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PullQCedByIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PullQCedByDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents StatusIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FTPStatusIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FTPDtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FormNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

  End Class

End Namespace