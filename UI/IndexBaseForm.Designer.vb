﻿Namespace UI


  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class IndexBaseForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IndexBaseForm))
            Me.leftPanel = New System.Windows.Forms.Panel()
            Me.findVehicleGroupBox = New System.Windows.Forms.GroupBox()
            Me.loadButton = New System.Windows.Forms.Button()
            Me.findVehicleIdTextBox = New System.Windows.Forms.TextBox()
            Me.vehicleGroupBox = New System.Windows.Forms.GroupBox()
            Me.DistDateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.DistDateLabel = New System.Windows.Forms.Label()
            Me.couponCheckBox = New System.Windows.Forms.CheckBox()
            Me.adDateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.adDateLabel = New System.Windows.Forms.Label()
            Me.definePagesButton = New System.Windows.Forms.Button()
            Me.languageComboBox = New System.Windows.Forms.ComboBox()
            Me.languageLabel = New System.Windows.Forms.Label()
            Me.pagesLabel = New System.Windows.Forms.Label()
            Me.endDateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.endDateLabel = New System.Windows.Forms.Label()
            Me.startDateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.startDateLabel = New System.Windows.Forms.Label()
            Me.themeComboBox = New System.Windows.Forms.ComboBox()
            Me.themeLabel = New System.Windows.Forms.Label()
            Me.eventComboBox = New System.Windows.Forms.ComboBox()
            Me.eventLabel = New System.Windows.Forms.Label()
            Me.tradeclassValueLabel = New System.Windows.Forms.Label()
            Me.tradeclassLabel = New System.Windows.Forms.Label()
            Me.retailerComboBox = New System.Windows.Forms.ComboBox()
            Me.retailerLabel = New System.Windows.Forms.Label()
            Me.publicationComboBox = New System.Windows.Forms.ComboBox()
            Me.publicationLabel = New System.Windows.Forms.Label()
            Me.marketComboBox = New System.Windows.Forms.ComboBox()
            Me.marketLabel = New System.Windows.Forms.Label()
            Me.mediaComboBox = New System.Windows.Forms.ComboBox()
            Me.mediaLabel = New System.Windows.Forms.Label()
            Me.vehicleIdValueLabel = New System.Windows.Forms.Label()
            Me.vehicleIdLabel = New System.Windows.Forms.Label()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.leftPanel.SuspendLayout()
            Me.findVehicleGroupBox.SuspendLayout()
            Me.vehicleGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'leftPanel
            '
            Me.leftPanel.Controls.Add(Me.findVehicleGroupBox)
            Me.leftPanel.Controls.Add(Me.vehicleGroupBox)
            Me.leftPanel.Dock = System.Windows.Forms.DockStyle.Left
            Me.leftPanel.Location = New System.Drawing.Point(0, 0)
            Me.leftPanel.Name = "leftPanel"
            Me.leftPanel.Size = New System.Drawing.Size(248, 478)
            Me.leftPanel.TabIndex = 1
            '
            'findVehicleGroupBox
            '
            Me.findVehicleGroupBox.Controls.Add(Me.loadButton)
            Me.findVehicleGroupBox.Controls.Add(Me.findVehicleIdTextBox)
            Me.findVehicleGroupBox.Location = New System.Drawing.Point(4, 12)
            Me.findVehicleGroupBox.Name = "findVehicleGroupBox"
            Me.findVehicleGroupBox.Size = New System.Drawing.Size(241, 48)
            Me.findVehicleGroupBox.TabIndex = 0
            Me.findVehicleGroupBox.TabStop = False
            Me.findVehicleGroupBox.Text = "Load from &Vehicle Id"
            '
            'loadButton
            '
            Me.loadButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.loadButton.Location = New System.Drawing.Point(160, 19)
            Me.loadButton.Name = "loadButton"
            Me.loadButton.Size = New System.Drawing.Size(75, 23)
            Me.loadButton.TabIndex = 1
            Me.loadButton.Text = "&Load"
            Me.loadButton.UseVisualStyleBackColor = True
            '
            'findVehicleIdTextBox
            '
            Me.findVehicleIdTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.findVehicleIdTextBox.Location = New System.Drawing.Point(6, 21)
            Me.findVehicleIdTextBox.MaxLength = 9
            Me.findVehicleIdTextBox.Name = "findVehicleIdTextBox"
            Me.findVehicleIdTextBox.Size = New System.Drawing.Size(148, 20)
            Me.findVehicleIdTextBox.TabIndex = 0
            '
            'vehicleGroupBox
            '
            Me.vehicleGroupBox.Controls.Add(Me.DistDateTypeInDatePicker)
            Me.vehicleGroupBox.Controls.Add(Me.DistDateLabel)
            Me.vehicleGroupBox.Controls.Add(Me.couponCheckBox)
            Me.vehicleGroupBox.Controls.Add(Me.adDateTypeInDatePicker)
            Me.vehicleGroupBox.Controls.Add(Me.adDateLabel)
            Me.vehicleGroupBox.Controls.Add(Me.definePagesButton)
            Me.vehicleGroupBox.Controls.Add(Me.languageComboBox)
            Me.vehicleGroupBox.Controls.Add(Me.languageLabel)
            Me.vehicleGroupBox.Controls.Add(Me.pagesLabel)
            Me.vehicleGroupBox.Controls.Add(Me.endDateTypeInDatePicker)
            Me.vehicleGroupBox.Controls.Add(Me.endDateLabel)
            Me.vehicleGroupBox.Controls.Add(Me.startDateTypeInDatePicker)
            Me.vehicleGroupBox.Controls.Add(Me.startDateLabel)
            Me.vehicleGroupBox.Controls.Add(Me.themeComboBox)
            Me.vehicleGroupBox.Controls.Add(Me.themeLabel)
            Me.vehicleGroupBox.Controls.Add(Me.eventComboBox)
            Me.vehicleGroupBox.Controls.Add(Me.eventLabel)
            Me.vehicleGroupBox.Controls.Add(Me.tradeclassValueLabel)
            Me.vehicleGroupBox.Controls.Add(Me.tradeclassLabel)
            Me.vehicleGroupBox.Controls.Add(Me.retailerComboBox)
            Me.vehicleGroupBox.Controls.Add(Me.retailerLabel)
            Me.vehicleGroupBox.Controls.Add(Me.publicationComboBox)
            Me.vehicleGroupBox.Controls.Add(Me.publicationLabel)
            Me.vehicleGroupBox.Controls.Add(Me.marketComboBox)
            Me.vehicleGroupBox.Controls.Add(Me.marketLabel)
            Me.vehicleGroupBox.Controls.Add(Me.mediaComboBox)
            Me.vehicleGroupBox.Controls.Add(Me.mediaLabel)
            Me.vehicleGroupBox.Controls.Add(Me.vehicleIdValueLabel)
            Me.vehicleGroupBox.Controls.Add(Me.vehicleIdLabel)
            Me.vehicleGroupBox.Location = New System.Drawing.Point(4, 66)
            Me.vehicleGroupBox.Name = "vehicleGroupBox"
            Me.vehicleGroupBox.Size = New System.Drawing.Size(241, 421)
            Me.vehicleGroupBox.TabIndex = 1
            Me.vehicleGroupBox.TabStop = False
            Me.vehicleGroupBox.Text = "Vehicle Information"
            '
            'DistDateTypeInDatePicker
            '
            Me.DistDateTypeInDatePicker.Location = New System.Drawing.Point(65, 128)
            Me.DistDateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.DistDateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.DistDateTypeInDatePicker.Name = "DistDateTypeInDatePicker"
            Me.DistDateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.DistDateTypeInDatePicker.TabIndex = 9
            Me.DistDateTypeInDatePicker.Value = Nothing
            '
            'DistDateLabel
            '
            Me.DistDateLabel.AutoSize = True
            Me.DistDateLabel.Location = New System.Drawing.Point(6, 132)
            Me.DistDateLabel.Name = "DistDateLabel"
            Me.DistDateLabel.Size = New System.Drawing.Size(54, 13)
            Me.DistDateLabel.TabIndex = 41
            Me.DistDateLabel.Text = "&Dist. Date"
            '
            'couponCheckBox
            '
            Me.couponCheckBox.AutoSize = True
            Me.couponCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.couponCheckBox.Location = New System.Drawing.Point(6, 400)
            Me.couponCheckBox.Name = "couponCheckBox"
            Me.couponCheckBox.Size = New System.Drawing.Size(75, 17)
            Me.couponCheckBox.TabIndex = 26
            Me.couponCheckBox.Text = "&Coupon    "
            Me.couponCheckBox.UseVisualStyleBackColor = True
            Me.couponCheckBox.Visible = False
            '
            'adDateTypeInDatePicker
            '
            Me.adDateTypeInDatePicker.Location = New System.Drawing.Point(66, 155)
            Me.adDateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.adDateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.adDateTypeInDatePicker.Name = "adDateTypeInDatePicker"
            Me.adDateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.adDateTypeInDatePicker.TabIndex = 10
            Me.adDateTypeInDatePicker.Value = Nothing
            '
            'adDateLabel
            '
            Me.adDateLabel.AutoSize = True
            Me.adDateLabel.Location = New System.Drawing.Point(7, 158)
            Me.adDateLabel.Name = "adDateLabel"
            Me.adDateLabel.Size = New System.Drawing.Size(44, 13)
            Me.adDateLabel.TabIndex = 8
            Me.adDateLabel.Text = "&Ad date"
            '
            'definePagesButton
            '
            Me.definePagesButton.Location = New System.Drawing.Point(65, 371)
            Me.definePagesButton.Name = "definePagesButton"
            Me.definePagesButton.Size = New System.Drawing.Size(163, 23)
            Me.definePagesButton.TabIndex = 27
            Me.definePagesButton.Text = "Define &Pages"
            Me.definePagesButton.UseVisualStyleBackColor = True
            '
            'languageComboBox
            '
            Me.languageComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.languageComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.languageComboBox.FormattingEnabled = True
            Me.languageComboBox.Location = New System.Drawing.Point(65, 232)
            Me.languageComboBox.Name = "languageComboBox"
            Me.languageComboBox.Size = New System.Drawing.Size(163, 21)
            Me.languageComboBox.TabIndex = 17
            '
            'languageLabel
            '
            Me.languageLabel.AutoSize = True
            Me.languageLabel.Location = New System.Drawing.Point(6, 235)
            Me.languageLabel.Name = "languageLabel"
            Me.languageLabel.Size = New System.Drawing.Size(55, 13)
            Me.languageLabel.TabIndex = 16
            Me.languageLabel.Text = "Lang&uage"
            '
            'pagesLabel
            '
            Me.pagesLabel.AutoSize = True
            Me.pagesLabel.Location = New System.Drawing.Point(6, 376)
            Me.pagesLabel.Name = "pagesLabel"
            Me.pagesLabel.Size = New System.Drawing.Size(37, 13)
            Me.pagesLabel.TabIndex = 26
            Me.pagesLabel.Text = "Pages"
            '
            'endDateTypeInDatePicker
            '
            Me.endDateTypeInDatePicker.Location = New System.Drawing.Point(65, 340)
            Me.endDateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.endDateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.endDateTypeInDatePicker.Name = "endDateTypeInDatePicker"
            Me.endDateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.endDateTypeInDatePicker.TabIndex = 25
            Me.endDateTypeInDatePicker.Value = Nothing
            '
            'endDateLabel
            '
            Me.endDateLabel.AutoSize = True
            Me.endDateLabel.Location = New System.Drawing.Point(6, 343)
            Me.endDateLabel.Name = "endDateLabel"
            Me.endDateLabel.Size = New System.Drawing.Size(52, 13)
            Me.endDateLabel.TabIndex = 24
            Me.endDateLabel.Text = "E&nd Date"
            '
            'startDateTypeInDatePicker
            '
            Me.startDateTypeInDatePicker.Location = New System.Drawing.Point(65, 314)
            Me.startDateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.startDateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.startDateTypeInDatePicker.Name = "startDateTypeInDatePicker"
            Me.startDateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.startDateTypeInDatePicker.TabIndex = 23
            Me.startDateTypeInDatePicker.Value = Nothing
            '
            'startDateLabel
            '
            Me.startDateLabel.AutoSize = True
            Me.startDateLabel.Location = New System.Drawing.Point(6, 317)
            Me.startDateLabel.Name = "startDateLabel"
            Me.startDateLabel.Size = New System.Drawing.Size(55, 13)
            Me.startDateLabel.TabIndex = 22
            Me.startDateLabel.Text = "&Start Date"
            '
            'themeComboBox
            '
            Me.themeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.themeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.themeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.themeComboBox.FormattingEnabled = True
            Me.themeComboBox.Location = New System.Drawing.Point(65, 286)
            Me.themeComboBox.Name = "themeComboBox"
            Me.themeComboBox.Size = New System.Drawing.Size(163, 21)
            Me.themeComboBox.TabIndex = 21
            '
            'themeLabel
            '
            Me.themeLabel.AutoSize = True
            Me.themeLabel.Location = New System.Drawing.Point(6, 289)
            Me.themeLabel.Name = "themeLabel"
            Me.themeLabel.Size = New System.Drawing.Size(40, 13)
            Me.themeLabel.TabIndex = 20
            Me.themeLabel.Text = "&Theme"
            '
            'eventComboBox
            '
            Me.eventComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.eventComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.eventComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.eventComboBox.FormattingEnabled = True
            Me.eventComboBox.Location = New System.Drawing.Point(65, 259)
            Me.eventComboBox.Name = "eventComboBox"
            Me.eventComboBox.Size = New System.Drawing.Size(163, 21)
            Me.eventComboBox.TabIndex = 19
            '
            'eventLabel
            '
            Me.eventLabel.AutoSize = True
            Me.eventLabel.Location = New System.Drawing.Point(6, 262)
            Me.eventLabel.Name = "eventLabel"
            Me.eventLabel.Size = New System.Drawing.Size(35, 13)
            Me.eventLabel.TabIndex = 18
            Me.eventLabel.Text = "&Event"
            '
            'tradeclassValueLabel
            '
            Me.tradeclassValueLabel.AutoSize = True
            Me.tradeclassValueLabel.Location = New System.Drawing.Point(62, 211)
            Me.tradeclassValueLabel.Name = "tradeclassValueLabel"
            Me.tradeclassValueLabel.Size = New System.Drawing.Size(71, 13)
            Me.tradeclassValueLabel.TabIndex = 13
            Me.tradeclassValueLabel.Text = "<Tradeclass>"
            '
            'tradeclassLabel
            '
            Me.tradeclassLabel.AutoSize = True
            Me.tradeclassLabel.Location = New System.Drawing.Point(6, 211)
            Me.tradeclassLabel.Name = "tradeclassLabel"
            Me.tradeclassLabel.Size = New System.Drawing.Size(59, 13)
            Me.tradeclassLabel.TabIndex = 12
            Me.tradeclassLabel.Text = "Tradeclass"
            '
            'retailerComboBox
            '
            Me.retailerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.retailerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.retailerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.retailerComboBox.FormattingEnabled = True
            Me.retailerComboBox.Location = New System.Drawing.Point(65, 183)
            Me.retailerComboBox.Name = "retailerComboBox"
            Me.retailerComboBox.Size = New System.Drawing.Size(163, 21)
            Me.retailerComboBox.TabIndex = 11
            '
            'retailerLabel
            '
            Me.retailerLabel.AutoSize = True
            Me.retailerLabel.Location = New System.Drawing.Point(6, 186)
            Me.retailerLabel.Name = "retailerLabel"
            Me.retailerLabel.Size = New System.Drawing.Size(43, 13)
            Me.retailerLabel.TabIndex = 10
            Me.retailerLabel.Text = "&Retailer"
            '
            'publicationComboBox
            '
            Me.publicationComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.publicationComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.publicationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.publicationComboBox.FormattingEnabled = True
            Me.publicationComboBox.Location = New System.Drawing.Point(65, 101)
            Me.publicationComboBox.Name = "publicationComboBox"
            Me.publicationComboBox.Size = New System.Drawing.Size(163, 21)
            Me.publicationComboBox.TabIndex = 7
            '
            'publicationLabel
            '
            Me.publicationLabel.AutoSize = True
            Me.publicationLabel.Location = New System.Drawing.Point(6, 104)
            Me.publicationLabel.Name = "publicationLabel"
            Me.publicationLabel.Size = New System.Drawing.Size(59, 13)
            Me.publicationLabel.TabIndex = 6
            Me.publicationLabel.Text = "Pu&blication"
            '
            'marketComboBox
            '
            Me.marketComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.marketComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.marketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.marketComboBox.FormattingEnabled = True
            Me.marketComboBox.Location = New System.Drawing.Point(65, 74)
            Me.marketComboBox.Name = "marketComboBox"
            Me.marketComboBox.Size = New System.Drawing.Size(163, 21)
            Me.marketComboBox.TabIndex = 5
            '
            'marketLabel
            '
            Me.marketLabel.AutoSize = True
            Me.marketLabel.Location = New System.Drawing.Point(6, 77)
            Me.marketLabel.Name = "marketLabel"
            Me.marketLabel.Size = New System.Drawing.Size(40, 13)
            Me.marketLabel.TabIndex = 4
            Me.marketLabel.Text = "&Market"
            '
            'mediaComboBox
            '
            Me.mediaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.mediaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.mediaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.mediaComboBox.FormattingEnabled = True
            Me.mediaComboBox.Location = New System.Drawing.Point(65, 47)
            Me.mediaComboBox.Name = "mediaComboBox"
            Me.mediaComboBox.Size = New System.Drawing.Size(163, 21)
            Me.mediaComboBox.TabIndex = 3
            '
            'mediaLabel
            '
            Me.mediaLabel.AutoSize = True
            Me.mediaLabel.Location = New System.Drawing.Point(6, 50)
            Me.mediaLabel.Name = "mediaLabel"
            Me.mediaLabel.Size = New System.Drawing.Size(36, 13)
            Me.mediaLabel.TabIndex = 2
            Me.mediaLabel.Text = "Me&dia"
            '
            'vehicleIdValueLabel
            '
            Me.vehicleIdValueLabel.AutoSize = True
            Me.vehicleIdValueLabel.Location = New System.Drawing.Point(63, 22)
            Me.vehicleIdValueLabel.Name = "vehicleIdValueLabel"
            Me.vehicleIdValueLabel.Size = New System.Drawing.Size(66, 13)
            Me.vehicleIdValueLabel.TabIndex = 1
            Me.vehicleIdValueLabel.Text = "<Vehicle Id>"
            '
            'vehicleIdLabel
            '
            Me.vehicleIdLabel.AutoSize = True
            Me.vehicleIdLabel.Location = New System.Drawing.Point(6, 22)
            Me.vehicleIdLabel.Name = "vehicleIdLabel"
            Me.vehicleIdLabel.Size = New System.Drawing.Size(54, 13)
            Me.vehicleIdLabel.TabIndex = 0
            Me.vehicleIdLabel.Text = "Vehicle Id"
            '
            'IndexBaseForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(247, 478)
            Me.Controls.Add(Me.leftPanel)
            Me.Name = "IndexBaseForm"
            Me.StatusMessage = ""
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.leftPanel.ResumeLayout(False)
            Me.findVehicleGroupBox.ResumeLayout(False)
            Me.findVehicleGroupBox.PerformLayout()
            Me.vehicleGroupBox.ResumeLayout(False)
            Me.vehicleGroupBox.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Protected WithEvents leftPanel As System.Windows.Forms.Panel
    Friend WithEvents findVehicleGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents loadButton As System.Windows.Forms.Button
        'Friend WithEvents qcreportButton As System.Windows.Forms.Button
    Friend WithEvents findVehicleIdTextBox As System.Windows.Forms.TextBox
    Protected WithEvents vehicleGroupBox As System.Windows.Forms.GroupBox
    Protected WithEvents definePagesButton As System.Windows.Forms.Button
    Protected WithEvents languageComboBox As System.Windows.Forms.ComboBox
    Protected WithEvents languageLabel As System.Windows.Forms.Label
    Protected WithEvents pagesLabel As System.Windows.Forms.Label
    Protected WithEvents endDateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
    Protected WithEvents endDateLabel As System.Windows.Forms.Label
    Protected WithEvents startDateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
    Protected WithEvents startDateLabel As System.Windows.Forms.Label
    Protected WithEvents themeComboBox As System.Windows.Forms.ComboBox
    Protected WithEvents themeLabel As System.Windows.Forms.Label
    Protected WithEvents eventComboBox As System.Windows.Forms.ComboBox
    Protected WithEvents eventLabel As System.Windows.Forms.Label
    Protected WithEvents tradeclassValueLabel As System.Windows.Forms.Label
    Protected WithEvents tradeclassLabel As System.Windows.Forms.Label
    Protected WithEvents retailerComboBox As System.Windows.Forms.ComboBox
    Protected WithEvents retailerLabel As System.Windows.Forms.Label
    Protected WithEvents publicationComboBox As System.Windows.Forms.ComboBox
    Protected WithEvents publicationLabel As System.Windows.Forms.Label
    Protected WithEvents marketComboBox As System.Windows.Forms.ComboBox
    Protected WithEvents marketLabel As System.Windows.Forms.Label
    Protected WithEvents mediaComboBox As System.Windows.Forms.ComboBox
    Protected WithEvents mediaLabel As System.Windows.Forms.Label
    Protected WithEvents vehicleIdValueLabel As System.Windows.Forms.Label
    Protected WithEvents vehicleIdLabel As System.Windows.Forms.Label
    Protected WithEvents adDateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
    Protected WithEvents adDateLabel As System.Windows.Forms.Label
        Protected WithEvents couponCheckBox As System.Windows.Forms.CheckBox
        Protected WithEvents DistDateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Protected WithEvents DistDateLabel As System.Windows.Forms.Label

  End Class


End Namespace