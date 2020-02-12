Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EnvelopeContentCheckInForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EnvelopeContentCheckInForm))
            Me.searchEnvelopeIdGroupBox = New System.Windows.Forms.GroupBox()
            Me.downloadAdButton = New System.Windows.Forms.Button()
            Me.senderLabel = New System.Windows.Forms.Label()
            Me.loadButton = New System.Windows.Forms.Button()
            Me.envelopeIdTextBox = New System.Windows.Forms.TextBox()
            Me.adDateLabel = New System.Windows.Forms.Label()
            Me.adDateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.marketLabel = New System.Windows.Forms.Label()
            Me.marketComboBox = New System.Windows.Forms.ComboBox()
            Me.retailerComboBox = New System.Windows.Forms.ComboBox()
            Me.retailerLabel = New System.Windows.Forms.Label()
            Me.newspaperComboBox = New System.Windows.Forms.ComboBox()
            Me.newspaperLabel = New System.Windows.Forms.Label()
            Me.flashCheckBox = New System.Windows.Forms.CheckBox()
            Me.vehicleIdLabel = New System.Windows.Forms.Label()
            Me.vehicleIdValueLabel = New System.Windows.Forms.Label()
            Me.checkInNewButton = New System.Windows.Forms.Button()
            Me.printLabelButton = New System.Windows.Forms.Button()
            Me.clearButton = New System.Windows.Forms.Button()
            Me.newRetailerButton = New System.Windows.Forms.Button()
            Me.ropCheckInButton = New System.Windows.Forms.Button()
            Me.requiredRetailersLabel = New System.Windows.Forms.Label()
            Me.requiredRetailersDataGridView = New System.Windows.Forms.DataGridView()
            Me.searchVehicleGroupBox = New System.Windows.Forms.GroupBox()
            Me.gotoButton = New System.Windows.Forms.Button()
            Me.vehicleIdTextBox = New System.Windows.Forms.TextBox()
            Me.closeButton = New System.Windows.Forms.Button()
            Me.mediaComboBox = New System.Windows.Forms.ComboBox()
            Me.mediaLabel = New System.Windows.Forms.Label()
            Me.tradeclassLabel = New System.Windows.Forms.Label()
            Me.tradeclassValueLabel = New System.Windows.Forms.Label()
            Me.checkInSameButton = New System.Windows.Forms.Button()
            Me.priorityValueLabel = New System.Windows.Forms.Label()
            Me.priorityLabel = New System.Windows.Forms.Label()
            Me.multipleOccurrencesCheckBox = New System.Windows.Forms.CheckBox()
            Me.commentsTextBox = New System.Windows.Forms.TextBox()
            Me.commentsLabel = New System.Windows.Forms.Label()
            Me.checkInNewAndIndexButton = New System.Windows.Forms.Button()
            Me.checkInSameAndIndexButton = New System.Windows.Forms.Button()
            Me.deleteButton = New System.Windows.Forms.Button()
            Me.wrongVersionButton = New System.Windows.Forms.Button()
            Me.nationalCheckBox = New System.Windows.Forms.CheckBox()
            Me.DistDateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.requiredRadioButton = New System.Windows.Forms.RadioButton()
            Me.nonRequiredRadioButton = New System.Windows.Forms.RadioButton()
            Me.ByPassCheckBox = New System.Windows.Forms.CheckBox()
            Me.PageCountTextBox = New System.Windows.Forms.TextBox()
            Me.PageCountLabel = New System.Windows.Forms.Label()
            Me.pgCountLabel = New System.Windows.Forms.Label()
            Me.SenderTextBox = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.searchEnvelopeIdGroupBox.SuspendLayout()
            CType(Me.requiredRetailersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.searchVehicleGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'searchEnvelopeIdGroupBox
            '
            Me.searchEnvelopeIdGroupBox.Controls.Add(Me.downloadAdButton)
            Me.searchEnvelopeIdGroupBox.Controls.Add(Me.senderLabel)
            Me.searchEnvelopeIdGroupBox.Controls.Add(Me.loadButton)
            Me.searchEnvelopeIdGroupBox.Controls.Add(Me.envelopeIdTextBox)
            Me.searchEnvelopeIdGroupBox.Location = New System.Drawing.Point(12, 12)
            Me.searchEnvelopeIdGroupBox.Name = "searchEnvelopeIdGroupBox"
            Me.searchEnvelopeIdGroupBox.Size = New System.Drawing.Size(638, 47)
            Me.searchEnvelopeIdGroupBox.TabIndex = 0
            Me.searchEnvelopeIdGroupBox.TabStop = False
            Me.searchEnvelopeIdGroupBox.Text = "Load from En&velope Id"
            '
            'downloadAdButton
            '
            Me.downloadAdButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.downloadAdButton.Location = New System.Drawing.Point(537, 17)
            Me.downloadAdButton.Name = "downloadAdButton"
            Me.downloadAdButton.Size = New System.Drawing.Size(95, 23)
            Me.downloadAdButton.TabIndex = 3
            Me.downloadAdButton.Text = "Download Ad"
            Me.downloadAdButton.UseVisualStyleBackColor = True
            '
            'senderLabel
            '
            Me.senderLabel.AutoSize = True
            Me.senderLabel.Location = New System.Drawing.Point(254, 22)
            Me.senderLabel.Name = "senderLabel"
            Me.senderLabel.Size = New System.Drawing.Size(84, 13)
            Me.senderLabel.TabIndex = 2
            Me.senderLabel.Text = "<Sender Name>"
            '
            'loadButton
            '
            Me.loadButton.Location = New System.Drawing.Point(173, 17)
            Me.loadButton.Name = "loadButton"
            Me.loadButton.Size = New System.Drawing.Size(75, 23)
            Me.loadButton.TabIndex = 1
            Me.loadButton.Text = "&Load"
            Me.loadButton.UseVisualStyleBackColor = True
            '
            'envelopeIdTextBox
            '
            Me.envelopeIdTextBox.Location = New System.Drawing.Point(6, 19)
            Me.envelopeIdTextBox.MaxLength = 9
            Me.envelopeIdTextBox.Name = "envelopeIdTextBox"
            Me.envelopeIdTextBox.Size = New System.Drawing.Size(161, 20)
            Me.envelopeIdTextBox.TabIndex = 0
            '
            'adDateLabel
            '
            Me.adDateLabel.AutoSize = True
            Me.adDateLabel.Location = New System.Drawing.Point(9, 201)
            Me.adDateLabel.Name = "adDateLabel"
            Me.adDateLabel.Size = New System.Drawing.Size(46, 13)
            Me.adDateLabel.TabIndex = 7
            Me.adDateLabel.Text = "&Ad Date"
            '
            'adDateTypeInDatePicker
            '
            Me.adDateTypeInDatePicker.Location = New System.Drawing.Point(79, 196)
            Me.adDateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.adDateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.adDateTypeInDatePicker.Name = "adDateTypeInDatePicker"
            Me.adDateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.adDateTypeInDatePicker.TabIndex = 9
            Me.adDateTypeInDatePicker.Value = Nothing
            '
            'marketLabel
            '
            Me.marketLabel.AutoSize = True
            Me.marketLabel.Location = New System.Drawing.Point(9, 116)
            Me.marketLabel.Name = "marketLabel"
            Me.marketLabel.Size = New System.Drawing.Size(40, 13)
            Me.marketLabel.TabIndex = 3
            Me.marketLabel.Text = "&Market"
            '
            'marketComboBox
            '
            Me.marketComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.marketComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.marketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.marketComboBox.FormattingEnabled = True
            Me.marketComboBox.Location = New System.Drawing.Point(79, 113)
            Me.marketComboBox.Name = "marketComboBox"
            Me.marketComboBox.Size = New System.Drawing.Size(289, 21)
            Me.marketComboBox.TabIndex = 4
            '
            'retailerComboBox
            '
            Me.retailerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.retailerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.retailerComboBox.FormattingEnabled = True
            Me.retailerComboBox.Location = New System.Drawing.Point(79, 224)
            Me.retailerComboBox.Name = "retailerComboBox"
            Me.retailerComboBox.Size = New System.Drawing.Size(289, 21)
            Me.retailerComboBox.TabIndex = 10
            '
            'retailerLabel
            '
            Me.retailerLabel.AutoSize = True
            Me.retailerLabel.Location = New System.Drawing.Point(9, 227)
            Me.retailerLabel.Name = "retailerLabel"
            Me.retailerLabel.Size = New System.Drawing.Size(43, 13)
            Me.retailerLabel.TabIndex = 9
            Me.retailerLabel.Text = "&Retailer"
            '
            'newspaperComboBox
            '
            Me.newspaperComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.newspaperComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.newspaperComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.newspaperComboBox.FormattingEnabled = True
            Me.newspaperComboBox.Location = New System.Drawing.Point(79, 140)
            Me.newspaperComboBox.Name = "newspaperComboBox"
            Me.newspaperComboBox.Size = New System.Drawing.Size(289, 21)
            Me.newspaperComboBox.TabIndex = 6
            '
            'newspaperLabel
            '
            Me.newspaperLabel.AutoSize = True
            Me.newspaperLabel.Location = New System.Drawing.Point(9, 143)
            Me.newspaperLabel.Name = "newspaperLabel"
            Me.newspaperLabel.Size = New System.Drawing.Size(61, 13)
            Me.newspaperLabel.TabIndex = 5
            Me.newspaperLabel.Text = "Ne&wspaper"
            '
            'flashCheckBox
            '
            Me.flashCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.flashCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.flashCheckBox.Location = New System.Drawing.Point(12, 317)
            Me.flashCheckBox.Name = "flashCheckBox"
            Me.flashCheckBox.Size = New System.Drawing.Size(61, 17)
            Me.flashCheckBox.TabIndex = 17
            Me.flashCheckBox.Text = "&FLASH"
            Me.flashCheckBox.UseVisualStyleBackColor = True
            Me.flashCheckBox.Visible = False
            '
            'vehicleIdLabel
            '
            Me.vehicleIdLabel.AutoSize = True
            Me.vehicleIdLabel.Location = New System.Drawing.Point(242, 341)
            Me.vehicleIdLabel.Name = "vehicleIdLabel"
            Me.vehicleIdLabel.Size = New System.Drawing.Size(54, 13)
            Me.vehicleIdLabel.TabIndex = 20
            Me.vehicleIdLabel.Text = "VehicleId:"
            Me.vehicleIdLabel.Visible = False
            '
            'vehicleIdValueLabel
            '
            Me.vehicleIdValueLabel.AutoSize = True
            Me.vehicleIdValueLabel.Location = New System.Drawing.Point(302, 341)
            Me.vehicleIdValueLabel.Name = "vehicleIdValueLabel"
            Me.vehicleIdValueLabel.Size = New System.Drawing.Size(66, 13)
            Me.vehicleIdValueLabel.TabIndex = 21
            Me.vehicleIdValueLabel.Text = "<Vehicle Id>"
            Me.vehicleIdValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'checkInNewButton
            '
            Me.checkInNewButton.Location = New System.Drawing.Point(12, 363)
            Me.checkInNewButton.Name = "checkInNewButton"
            Me.checkInNewButton.Size = New System.Drawing.Size(97, 23)
            Me.checkInNewButton.TabIndex = 22
            Me.checkInNewButton.Text = "C&heck In - New"
            Me.checkInNewButton.UseVisualStyleBackColor = True
            '
            'printLabelButton
            '
            Me.printLabelButton.Location = New System.Drawing.Point(12, 421)
            Me.printLabelButton.Name = "printLabelButton"
            Me.printLabelButton.Size = New System.Drawing.Size(97, 23)
            Me.printLabelButton.TabIndex = 28
            Me.printLabelButton.Text = "Print La&bel"
            Me.printLabelButton.UseVisualStyleBackColor = True
            '
            'clearButton
            '
            Me.clearButton.Location = New System.Drawing.Point(12, 479)
            Me.clearButton.Name = "clearButton"
            Me.clearButton.Size = New System.Drawing.Size(97, 23)
            Me.clearButton.TabIndex = 30
            Me.clearButton.Text = "&Clear"
            Me.clearButton.UseVisualStyleBackColor = True
            '
            'newRetailerButton
            '
            Me.newRetailerButton.Location = New System.Drawing.Point(12, 421)
            Me.newRetailerButton.Name = "newRetailerButton"
            Me.newRetailerButton.Size = New System.Drawing.Size(97, 23)
            Me.newRetailerButton.TabIndex = 26
            Me.newRetailerButton.Text = "New Re&tailer"
            Me.newRetailerButton.UseVisualStyleBackColor = True
            Me.newRetailerButton.Visible = False
            '
            'ropCheckInButton
            '
            Me.ropCheckInButton.Location = New System.Drawing.Point(115, 421)
            Me.ropCheckInButton.Name = "ropCheckInButton"
            Me.ropCheckInButton.Size = New System.Drawing.Size(178, 23)
            Me.ropCheckInButton.TabIndex = 27
            Me.ropCheckInButton.Text = "Check-&In ROP for this Envelope"
            Me.ropCheckInButton.UseVisualStyleBackColor = True
            '
            'requiredRetailersLabel
            '
            Me.requiredRetailersLabel.AutoSize = True
            Me.requiredRetailersLabel.Location = New System.Drawing.Point(385, 201)
            Me.requiredRetailersLabel.Name = "requiredRetailersLabel"
            Me.requiredRetailersLabel.Size = New System.Drawing.Size(94, 13)
            Me.requiredRetailersLabel.TabIndex = 34
            Me.requiredRetailersLabel.Text = "Required Retailers"
            '
            'requiredRetailersDataGridView
            '
            Me.requiredRetailersDataGridView.AllowUserToAddRows = False
            Me.requiredRetailersDataGridView.AllowUserToDeleteRows = False
            Me.requiredRetailersDataGridView.AllowUserToResizeColumns = False
            Me.requiredRetailersDataGridView.AllowUserToResizeRows = False
            Me.requiredRetailersDataGridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.requiredRetailersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.requiredRetailersDataGridView.Location = New System.Drawing.Point(388, 224)
            Me.requiredRetailersDataGridView.Name = "requiredRetailersDataGridView"
            Me.requiredRetailersDataGridView.ReadOnly = True
            Me.requiredRetailersDataGridView.Size = New System.Drawing.Size(262, 361)
            Me.requiredRetailersDataGridView.TabIndex = 35
            Me.requiredRetailersDataGridView.TabStop = False
            '
            'searchVehicleGroupBox
            '
            Me.searchVehicleGroupBox.Controls.Add(Me.gotoButton)
            Me.searchVehicleGroupBox.Controls.Add(Me.vehicleIdTextBox)
            Me.searchVehicleGroupBox.Location = New System.Drawing.Point(12, 519)
            Me.searchVehicleGroupBox.Name = "searchVehicleGroupBox"
            Me.searchVehicleGroupBox.Size = New System.Drawing.Size(262, 47)
            Me.searchVehicleGroupBox.TabIndex = 32
            Me.searchVehicleGroupBox.TabStop = False
            Me.searchVehicleGroupBox.Text = "Search on &Vehicle Id"
            '
            'gotoButton
            '
            Me.gotoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.gotoButton.Location = New System.Drawing.Point(173, 18)
            Me.gotoButton.Name = "gotoButton"
            Me.gotoButton.Size = New System.Drawing.Size(75, 23)
            Me.gotoButton.TabIndex = 1
            Me.gotoButton.Text = "&Search"
            Me.gotoButton.UseVisualStyleBackColor = True
            '
            'vehicleIdTextBox
            '
            Me.vehicleIdTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.vehicleIdTextBox.Location = New System.Drawing.Point(7, 20)
            Me.vehicleIdTextBox.MaxLength = 9
            Me.vehicleIdTextBox.Name = "vehicleIdTextBox"
            Me.vehicleIdTextBox.Size = New System.Drawing.Size(160, 20)
            Me.vehicleIdTextBox.TabIndex = 0
            '
            'closeButton
            '
            Me.closeButton.Location = New System.Drawing.Point(293, 535)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(75, 23)
            Me.closeButton.TabIndex = 33
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'mediaComboBox
            '
            Me.mediaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.mediaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.mediaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.mediaComboBox.FormattingEnabled = True
            Me.mediaComboBox.Location = New System.Drawing.Point(79, 86)
            Me.mediaComboBox.Name = "mediaComboBox"
            Me.mediaComboBox.Size = New System.Drawing.Size(289, 21)
            Me.mediaComboBox.TabIndex = 2
            '
            'mediaLabel
            '
            Me.mediaLabel.AutoSize = True
            Me.mediaLabel.Location = New System.Drawing.Point(9, 89)
            Me.mediaLabel.Name = "mediaLabel"
            Me.mediaLabel.Size = New System.Drawing.Size(36, 13)
            Me.mediaLabel.TabIndex = 1
            Me.mediaLabel.Text = "Me&dia"
            '
            'tradeclassLabel
            '
            Me.tradeclassLabel.AutoSize = True
            Me.tradeclassLabel.Location = New System.Drawing.Point(9, 251)
            Me.tradeclassLabel.Name = "tradeclassLabel"
            Me.tradeclassLabel.Size = New System.Drawing.Size(59, 13)
            Me.tradeclassLabel.TabIndex = 11
            Me.tradeclassLabel.Text = "Tradeclass"
            '
            'tradeclassValueLabel
            '
            Me.tradeclassValueLabel.AutoSize = True
            Me.tradeclassValueLabel.Location = New System.Drawing.Point(80, 251)
            Me.tradeclassValueLabel.Name = "tradeclassValueLabel"
            Me.tradeclassValueLabel.Size = New System.Drawing.Size(71, 13)
            Me.tradeclassValueLabel.TabIndex = 12
            Me.tradeclassValueLabel.Text = "<Tradeclass>"
            '
            'checkInSameButton
            '
            Me.checkInSameButton.Location = New System.Drawing.Point(12, 392)
            Me.checkInSameButton.Name = "checkInSameButton"
            Me.checkInSameButton.Size = New System.Drawing.Size(97, 23)
            Me.checkInSameButton.TabIndex = 24
            Me.checkInSameButton.Text = "Chec&k In - Same"
            Me.checkInSameButton.UseVisualStyleBackColor = True
            '
            'priorityValueLabel
            '
            Me.priorityValueLabel.AutoSize = True
            Me.priorityValueLabel.Location = New System.Drawing.Point(318, 251)
            Me.priorityValueLabel.Name = "priorityValueLabel"
            Me.priorityValueLabel.Size = New System.Drawing.Size(50, 13)
            Me.priorityValueLabel.TabIndex = 14
            Me.priorityValueLabel.Text = "<Priority>"
            '
            'priorityLabel
            '
            Me.priorityLabel.AutoSize = True
            Me.priorityLabel.Location = New System.Drawing.Point(271, 251)
            Me.priorityLabel.Name = "priorityLabel"
            Me.priorityLabel.Size = New System.Drawing.Size(41, 13)
            Me.priorityLabel.TabIndex = 13
            Me.priorityLabel.Text = "Priority:"
            '
            'multipleOccurrencesCheckBox
            '
            Me.multipleOccurrencesCheckBox.AutoSize = True
            Me.multipleOccurrencesCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.multipleOccurrencesCheckBox.Location = New System.Drawing.Point(12, 340)
            Me.multipleOccurrencesCheckBox.Name = "multipleOccurrencesCheckBox"
            Me.multipleOccurrencesCheckBox.Size = New System.Drawing.Size(126, 17)
            Me.multipleOccurrencesCheckBox.TabIndex = 19
            Me.multipleOccurrencesCheckBox.Text = "Multipl&e Occurrences"
            Me.multipleOccurrencesCheckBox.UseVisualStyleBackColor = True
            '
            'commentsTextBox
            '
            Me.commentsTextBox.Location = New System.Drawing.Point(79, 270)
            Me.commentsTextBox.Multiline = True
            Me.commentsTextBox.Name = "commentsTextBox"
            Me.commentsTextBox.ReadOnly = True
            Me.commentsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.commentsTextBox.Size = New System.Drawing.Size(289, 41)
            Me.commentsTextBox.TabIndex = 16
            Me.commentsTextBox.TabStop = False
            '
            'commentsLabel
            '
            Me.commentsLabel.AutoSize = True
            Me.commentsLabel.Location = New System.Drawing.Point(9, 273)
            Me.commentsLabel.Name = "commentsLabel"
            Me.commentsLabel.Size = New System.Drawing.Size(56, 13)
            Me.commentsLabel.TabIndex = 15
            Me.commentsLabel.Text = "Comments"
            '
            'checkInNewAndIndexButton
            '
            Me.checkInNewAndIndexButton.Location = New System.Drawing.Point(115, 363)
            Me.checkInNewAndIndexButton.Name = "checkInNewAndIndexButton"
            Me.checkInNewAndIndexButton.Size = New System.Drawing.Size(178, 23)
            Me.checkInNewAndIndexButton.TabIndex = 23
            Me.checkInNewAndIndexButton.Text = "Check In - New; Index Now"
            Me.checkInNewAndIndexButton.UseVisualStyleBackColor = True
            '
            'checkInSameAndIndexButton
            '
            Me.checkInSameAndIndexButton.Location = New System.Drawing.Point(115, 391)
            Me.checkInSameAndIndexButton.Name = "checkInSameAndIndexButton"
            Me.checkInSameAndIndexButton.Size = New System.Drawing.Size(178, 23)
            Me.checkInSameAndIndexButton.TabIndex = 25
            Me.checkInSameAndIndexButton.Text = "Check In - Same; Index Now"
            Me.checkInSameAndIndexButton.UseVisualStyleBackColor = True
            '
            'deleteButton
            '
            Me.deleteButton.Location = New System.Drawing.Point(196, 479)
            Me.deleteButton.Name = "deleteButton"
            Me.deleteButton.Size = New System.Drawing.Size(97, 23)
            Me.deleteButton.TabIndex = 31
            Me.deleteButton.Text = "Delete"
            Me.deleteButton.UseVisualStyleBackColor = True
            Me.deleteButton.Visible = False
            '
            'wrongVersionButton
            '
            Me.wrongVersionButton.Location = New System.Drawing.Point(115, 450)
            Me.wrongVersionButton.Name = "wrongVersionButton"
            Me.wrongVersionButton.Size = New System.Drawing.Size(178, 23)
            Me.wrongVersionButton.TabIndex = 29
            Me.wrongVersionButton.Text = "Check-in; Wrong Version"
            Me.wrongVersionButton.UseVisualStyleBackColor = True
            '
            'nationalCheckBox
            '
            Me.nationalCheckBox.AutoSize = True
            Me.nationalCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.nationalCheckBox.Enabled = False
            Me.nationalCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.nationalCheckBox.Location = New System.Drawing.Point(295, 317)
            Me.nationalCheckBox.Name = "nationalCheckBox"
            Me.nationalCheckBox.Size = New System.Drawing.Size(73, 17)
            Me.nationalCheckBox.TabIndex = 18
            Me.nationalCheckBox.Text = "&National"
            Me.nationalCheckBox.UseVisualStyleBackColor = True
            Me.nationalCheckBox.Visible = False
            '
            'DistDateTypeInDatePicker
            '
            Me.DistDateTypeInDatePicker.Location = New System.Drawing.Point(79, 168)
            Me.DistDateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.DistDateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.DistDateTypeInDatePicker.Name = "DistDateTypeInDatePicker"
            Me.DistDateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.DistDateTypeInDatePicker.TabIndex = 8
            Me.DistDateTypeInDatePicker.Value = Nothing
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(9, 173)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(54, 13)
            Me.Label1.TabIndex = 39
            Me.Label1.Text = "&Dist. Date"
            '
            'requiredRadioButton
            '
            Me.requiredRadioButton.AutoSize = True
            Me.requiredRadioButton.Enabled = False
            Me.requiredRadioButton.Location = New System.Drawing.Point(79, 63)
            Me.requiredRadioButton.Name = "requiredRadioButton"
            Me.requiredRadioButton.Size = New System.Drawing.Size(114, 17)
            Me.requiredRadioButton.TabIndex = 40
            Me.requiredRadioButton.Text = "Check-In Required"
            Me.requiredRadioButton.UseVisualStyleBackColor = True
            '
            'nonRequiredRadioButton
            '
            Me.nonRequiredRadioButton.AutoSize = True
            Me.nonRequiredRadioButton.Enabled = False
            Me.nonRequiredRadioButton.Location = New System.Drawing.Point(212, 63)
            Me.nonRequiredRadioButton.Name = "nonRequiredRadioButton"
            Me.nonRequiredRadioButton.Size = New System.Drawing.Size(137, 17)
            Me.nonRequiredRadioButton.TabIndex = 41
            Me.nonRequiredRadioButton.Text = "Check-In Non-Required"
            Me.nonRequiredRadioButton.UseVisualStyleBackColor = True
            '
            'ByPassCheckBox
            '
            Me.ByPassCheckBox.AutoSize = True
            Me.ByPassCheckBox.Enabled = False
            Me.ByPassCheckBox.Location = New System.Drawing.Point(446, 66)
            Me.ByPassCheckBox.Name = "ByPassCheckBox"
            Me.ByPassCheckBox.Size = New System.Drawing.Size(182, 17)
            Me.ByPassCheckBox.TabIndex = 36
            Me.ByPassCheckBox.Text = "ByPass Sender Expectation Filter"
            Me.ByPassCheckBox.UseVisualStyleBackColor = True
            Me.ByPassCheckBox.Visible = False
            '
            'PageCountTextBox
            '
            Me.PageCountTextBox.Enabled = False
            Me.PageCountTextBox.Location = New System.Drawing.Point(79, 315)
            Me.PageCountTextBox.MaxLength = 9
            Me.PageCountTextBox.Name = "PageCountTextBox"
            Me.PageCountTextBox.Size = New System.Drawing.Size(59, 20)
            Me.PageCountTextBox.TabIndex = 42
            Me.PageCountTextBox.Visible = False
            '
            'PageCountLabel
            '
            Me.PageCountLabel.AutoSize = True
            Me.PageCountLabel.Location = New System.Drawing.Point(7, 318)
            Me.PageCountLabel.Name = "PageCountLabel"
            Me.PageCountLabel.Size = New System.Drawing.Size(63, 13)
            Me.PageCountLabel.TabIndex = 43
            Me.PageCountLabel.Text = "Page Count"
            '
            'pgCountLabel
            '
            Me.pgCountLabel.AutoSize = True
            Me.pgCountLabel.Location = New System.Drawing.Point(7, 317)
            Me.pgCountLabel.Name = "pgCountLabel"
            Me.pgCountLabel.Size = New System.Drawing.Size(63, 13)
            Me.pgCountLabel.TabIndex = 44
            Me.pgCountLabel.Text = "Page Count"
            Me.pgCountLabel.Visible = False
            '
            'SenderTextBox
            '
            Me.SenderTextBox.Location = New System.Drawing.Point(388, 86)
            Me.SenderTextBox.Multiline = True
            Me.SenderTextBox.Name = "SenderTextBox"
            Me.SenderTextBox.ReadOnly = True
            Me.SenderTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.SenderTextBox.Size = New System.Drawing.Size(262, 112)
            Me.SenderTextBox.TabIndex = 46
            Me.SenderTextBox.TabStop = False
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(384, 66)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(93, 13)
            Me.Label2.TabIndex = 45
            Me.Label2.Text = "Sender Comments"
            '
            'EnvelopeContentCheckInForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(662, 597)
            Me.Controls.Add(Me.SenderTextBox)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.pgCountLabel)
            Me.Controls.Add(Me.PageCountLabel)
            Me.Controls.Add(Me.PageCountTextBox)
            Me.Controls.Add(Me.nonRequiredRadioButton)
            Me.Controls.Add(Me.requiredRadioButton)
            Me.Controls.Add(Me.DistDateTypeInDatePicker)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.ByPassCheckBox)
            Me.Controls.Add(Me.nationalCheckBox)
            Me.Controls.Add(Me.wrongVersionButton)
            Me.Controls.Add(Me.commentsTextBox)
            Me.Controls.Add(Me.deleteButton)
            Me.Controls.Add(Me.commentsLabel)
            Me.Controls.Add(Me.checkInSameAndIndexButton)
            Me.Controls.Add(Me.checkInNewAndIndexButton)
            Me.Controls.Add(Me.multipleOccurrencesCheckBox)
            Me.Controls.Add(Me.priorityValueLabel)
            Me.Controls.Add(Me.priorityLabel)
            Me.Controls.Add(Me.checkInSameButton)
            Me.Controls.Add(Me.tradeclassValueLabel)
            Me.Controls.Add(Me.tradeclassLabel)
            Me.Controls.Add(Me.mediaComboBox)
            Me.Controls.Add(Me.mediaLabel)
            Me.Controls.Add(Me.closeButton)
            Me.Controls.Add(Me.searchVehicleGroupBox)
            Me.Controls.Add(Me.requiredRetailersDataGridView)
            Me.Controls.Add(Me.requiredRetailersLabel)
            Me.Controls.Add(Me.ropCheckInButton)
            Me.Controls.Add(Me.clearButton)
            Me.Controls.Add(Me.printLabelButton)
            Me.Controls.Add(Me.checkInNewButton)
            Me.Controls.Add(Me.vehicleIdValueLabel)
            Me.Controls.Add(Me.vehicleIdLabel)
            Me.Controls.Add(Me.newspaperComboBox)
            Me.Controls.Add(Me.newspaperLabel)
            Me.Controls.Add(Me.retailerComboBox)
            Me.Controls.Add(Me.retailerLabel)
            Me.Controls.Add(Me.marketComboBox)
            Me.Controls.Add(Me.marketLabel)
            Me.Controls.Add(Me.adDateTypeInDatePicker)
            Me.Controls.Add(Me.adDateLabel)
            Me.Controls.Add(Me.searchEnvelopeIdGroupBox)
            Me.Controls.Add(Me.newRetailerButton)
            Me.Controls.Add(Me.flashCheckBox)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "EnvelopeContentCheckInForm"
            Me.StatusMessage = ""
            Me.Text = "Vehicle Check-In"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.searchEnvelopeIdGroupBox.ResumeLayout(False)
            Me.searchEnvelopeIdGroupBox.PerformLayout()
            CType(Me.requiredRetailersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.searchVehicleGroupBox.ResumeLayout(False)
            Me.searchVehicleGroupBox.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents searchEnvelopeIdGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents senderLabel As System.Windows.Forms.Label
        Friend WithEvents loadButton As System.Windows.Forms.Button
        Friend WithEvents envelopeIdTextBox As System.Windows.Forms.TextBox
        Friend WithEvents adDateLabel As System.Windows.Forms.Label
        Friend WithEvents adDateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents marketLabel As System.Windows.Forms.Label
        Friend WithEvents marketComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents retailerComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents retailerLabel As System.Windows.Forms.Label
        Friend WithEvents newspaperComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents newspaperLabel As System.Windows.Forms.Label
        Friend WithEvents flashCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents vehicleIdLabel As System.Windows.Forms.Label
        Friend WithEvents vehicleIdValueLabel As System.Windows.Forms.Label
        Friend WithEvents checkInNewButton As System.Windows.Forms.Button
        Friend WithEvents printLabelButton As System.Windows.Forms.Button
        Friend WithEvents clearButton As System.Windows.Forms.Button
        Friend WithEvents newRetailerButton As System.Windows.Forms.Button
        Friend WithEvents ropCheckInButton As System.Windows.Forms.Button
        Friend WithEvents requiredRetailersLabel As System.Windows.Forms.Label
        Friend WithEvents requiredRetailersDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents searchVehicleGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents gotoButton As System.Windows.Forms.Button
        Friend WithEvents vehicleIdTextBox As System.Windows.Forms.TextBox
        Friend WithEvents closeButton As System.Windows.Forms.Button
        Friend WithEvents mediaComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents mediaLabel As System.Windows.Forms.Label
        Friend WithEvents tradeclassLabel As System.Windows.Forms.Label
        Friend WithEvents tradeclassValueLabel As System.Windows.Forms.Label
        Friend WithEvents checkInSameButton As System.Windows.Forms.Button
        Friend WithEvents priorityValueLabel As System.Windows.Forms.Label
        Friend WithEvents priorityLabel As System.Windows.Forms.Label
        Friend WithEvents multipleOccurrencesCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents commentsTextBox As System.Windows.Forms.TextBox
        Friend WithEvents commentsLabel As System.Windows.Forms.Label
        Friend WithEvents checkInNewAndIndexButton As System.Windows.Forms.Button
        Friend WithEvents checkInSameAndIndexButton As System.Windows.Forms.Button
        Friend WithEvents deleteButton As System.Windows.Forms.Button
        Friend WithEvents downloadAdButton As System.Windows.Forms.Button
        Friend WithEvents wrongVersionButton As System.Windows.Forms.Button
        Friend WithEvents nationalCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents DistDateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents requiredRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents nonRequiredRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents ByPassCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents PageCountTextBox As System.Windows.Forms.TextBox
        Friend WithEvents PageCountLabel As System.Windows.Forms.Label
        Friend WithEvents pgCountLabel As System.Windows.Forms.Label
        Friend WithEvents SenderTextBox As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label

    End Class

End Namespace