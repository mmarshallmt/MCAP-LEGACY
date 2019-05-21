﻿Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class FamilyCheckInForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FamilyCheckInForm))
            Me.adDateLabel = New System.Windows.Forms.Label()
            Me.adDateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.mediaLabel = New System.Windows.Forms.Label()
            Me.mediaComboBox = New System.Windows.Forms.ComboBox()
            Me.retailerComboBox = New System.Windows.Forms.ComboBox()
            Me.retailerLabel = New System.Windows.Forms.Label()
            Me.marketLabel = New System.Windows.Forms.Label()
            Me.mktPubLabel = New System.Windows.Forms.Label()
            Me.tradeclassLabel = New System.Windows.Forms.Label()
            Me.tradeclassValueLabel = New System.Windows.Forms.Label()
            Me.eventLabel = New System.Windows.Forms.Label()
            Me.eventComboBox = New System.Windows.Forms.ComboBox()
            Me.themeComboBox = New System.Windows.Forms.ComboBox()
            Me.themeLabel = New System.Windows.Forms.Label()
            Me.startDateLabel = New System.Windows.Forms.Label()
            Me.startDateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.endDateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.endDateLabel = New System.Windows.Forms.Label()
            Me.pagesLabel = New System.Windows.Forms.Label()
            Me.pagesButton = New System.Windows.Forms.Button()
            Me.mktPubGroupBox = New System.Windows.Forms.GroupBox()
            Me.scanButton = New System.Windows.Forms.Button()
            Me.marketCheckedListBox = New System.Windows.Forms.CheckedListBox()
            Me.showPublicationRadioButton = New System.Windows.Forms.RadioButton()
            Me.selectedMktPubListBox = New System.Windows.Forms.ListBox()
            Me.showVehicleIdRadioButton = New System.Windows.Forms.RadioButton()
            Me.saveButton = New System.Windows.Forms.Button()
            Me.closeButton = New System.Windows.Forms.Button()
            Me.searchGroupBox = New System.Windows.Forms.GroupBox()
            Me.gotoButton = New System.Windows.Forms.Button()
            Me.gotoVehicleIdTextBox = New System.Windows.Forms.TextBox()
            Me.couponIndCheckBox = New System.Windows.Forms.CheckBox()
            Me.languageComboBox = New System.Windows.Forms.ComboBox()
            Me.languageLabel = New System.Windows.Forms.Label()
            Me.clearButton = New System.Windows.Forms.Button()
            Me.dayRangeNumericUpDown = New System.Windows.Forms.NumericUpDown()
            Me.loadjoinFamilyButton = New System.Windows.Forms.Button()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.mktPubGroupBox.SuspendLayout()
            Me.searchGroupBox.SuspendLayout()
            CType(Me.dayRangeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'adDateLabel
            '
            Me.adDateLabel.AutoSize = True
            Me.adDateLabel.Location = New System.Drawing.Point(11, 68)
            Me.adDateLabel.Name = "adDateLabel"
            Me.adDateLabel.Size = New System.Drawing.Size(46, 13)
            Me.adDateLabel.TabIndex = 1
            Me.adDateLabel.Text = "&Ad Date"
            '
            'adDateTypeInDatePicker
            '
            Me.adDateTypeInDatePicker.Location = New System.Drawing.Point(72, 65)
            Me.adDateTypeInDatePicker.MaximumSize = New System.Drawing.Size(74, 22)
            Me.adDateTypeInDatePicker.MinimumSize = New System.Drawing.Size(74, 22)
            Me.adDateTypeInDatePicker.Name = "adDateTypeInDatePicker"
            Me.adDateTypeInDatePicker.Size = New System.Drawing.Size(74, 22)
            Me.adDateTypeInDatePicker.TabIndex = 2
            Me.adDateTypeInDatePicker.Value = Nothing
            '
            'mediaLabel
            '
            Me.mediaLabel.AutoSize = True
            Me.mediaLabel.Location = New System.Drawing.Point(11, 95)
            Me.mediaLabel.Name = "mediaLabel"
            Me.mediaLabel.Size = New System.Drawing.Size(36, 13)
            Me.mediaLabel.TabIndex = 4
            Me.mediaLabel.Text = "Me&dia"
            '
            'mediaComboBox
            '
            Me.mediaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.mediaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.mediaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.mediaComboBox.FormattingEnabled = True
            Me.mediaComboBox.Location = New System.Drawing.Point(72, 92)
            Me.mediaComboBox.Name = "mediaComboBox"
            Me.mediaComboBox.Size = New System.Drawing.Size(205, 21)
            Me.mediaComboBox.TabIndex = 5
            '
            'retailerComboBox
            '
            Me.retailerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.retailerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.retailerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.retailerComboBox.FormattingEnabled = True
            Me.retailerComboBox.Location = New System.Drawing.Point(72, 119)
            Me.retailerComboBox.Name = "retailerComboBox"
            Me.retailerComboBox.Size = New System.Drawing.Size(205, 21)
            Me.retailerComboBox.TabIndex = 7
            '
            'retailerLabel
            '
            Me.retailerLabel.AutoSize = True
            Me.retailerLabel.Location = New System.Drawing.Point(11, 122)
            Me.retailerLabel.Name = "retailerLabel"
            Me.retailerLabel.Size = New System.Drawing.Size(43, 13)
            Me.retailerLabel.TabIndex = 6
            Me.retailerLabel.Text = "&Retailer"
            '
            'marketLabel
            '
            Me.marketLabel.AutoSize = True
            Me.marketLabel.Location = New System.Drawing.Point(5, 16)
            Me.marketLabel.Name = "marketLabel"
            Me.marketLabel.Size = New System.Drawing.Size(40, 13)
            Me.marketLabel.TabIndex = 0
            Me.marketLabel.Text = "&Market"
            '
            'mktPubLabel
            '
            Me.mktPubLabel.AutoSize = True
            Me.mktPubLabel.Location = New System.Drawing.Point(297, 16)
            Me.mktPubLabel.Name = "mktPubLabel"
            Me.mktPubLabel.Size = New System.Drawing.Size(133, 13)
            Me.mktPubLabel.TabIndex = 3
            Me.mktPubLabel.Text = "Selected Vehicles to Index"
            '
            'tradeclassLabel
            '
            Me.tradeclassLabel.AutoSize = True
            Me.tradeclassLabel.Location = New System.Drawing.Point(297, 122)
            Me.tradeclassLabel.Name = "tradeclassLabel"
            Me.tradeclassLabel.Size = New System.Drawing.Size(59, 13)
            Me.tradeclassLabel.TabIndex = 8
            Me.tradeclassLabel.Text = "Tradeclass"
            '
            'tradeclassValueLabel
            '
            Me.tradeclassValueLabel.AutoSize = True
            Me.tradeclassValueLabel.Location = New System.Drawing.Point(362, 122)
            Me.tradeclassValueLabel.Name = "tradeclassValueLabel"
            Me.tradeclassValueLabel.Size = New System.Drawing.Size(101, 13)
            Me.tradeclassValueLabel.TabIndex = 9
            Me.tradeclassValueLabel.Text = "<Tradeclass Value>"
            '
            'eventLabel
            '
            Me.eventLabel.AutoSize = True
            Me.eventLabel.Location = New System.Drawing.Point(11, 398)
            Me.eventLabel.Name = "eventLabel"
            Me.eventLabel.Size = New System.Drawing.Size(35, 13)
            Me.eventLabel.TabIndex = 14
            Me.eventLabel.Text = "&Event"
            '
            'eventComboBox
            '
            Me.eventComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.eventComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.eventComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.eventComboBox.FormattingEnabled = True
            Me.eventComboBox.Location = New System.Drawing.Point(72, 394)
            Me.eventComboBox.Name = "eventComboBox"
            Me.eventComboBox.Size = New System.Drawing.Size(205, 21)
            Me.eventComboBox.TabIndex = 15
            '
            'themeComboBox
            '
            Me.themeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.themeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.themeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.themeComboBox.FormattingEnabled = True
            Me.themeComboBox.Location = New System.Drawing.Point(72, 421)
            Me.themeComboBox.Name = "themeComboBox"
            Me.themeComboBox.Size = New System.Drawing.Size(205, 21)
            Me.themeComboBox.TabIndex = 17
            '
            'themeLabel
            '
            Me.themeLabel.AutoSize = True
            Me.themeLabel.Location = New System.Drawing.Point(11, 424)
            Me.themeLabel.Name = "themeLabel"
            Me.themeLabel.Size = New System.Drawing.Size(40, 13)
            Me.themeLabel.TabIndex = 16
            Me.themeLabel.Text = "&Theme"
            '
            'startDateLabel
            '
            Me.startDateLabel.AutoSize = True
            Me.startDateLabel.Location = New System.Drawing.Point(11, 451)
            Me.startDateLabel.Name = "startDateLabel"
            Me.startDateLabel.Size = New System.Drawing.Size(46, 13)
            Me.startDateLabel.TabIndex = 18
            Me.startDateLabel.Text = "&Start Dt."
            '
            'startDateTypeInDatePicker
            '
            Me.startDateTypeInDatePicker.Location = New System.Drawing.Point(72, 448)
            Me.startDateTypeInDatePicker.MaximumSize = New System.Drawing.Size(74, 22)
            Me.startDateTypeInDatePicker.MinimumSize = New System.Drawing.Size(74, 22)
            Me.startDateTypeInDatePicker.Name = "startDateTypeInDatePicker"
            Me.startDateTypeInDatePicker.Size = New System.Drawing.Size(74, 22)
            Me.startDateTypeInDatePicker.TabIndex = 19
            Me.startDateTypeInDatePicker.Value = Nothing
            '
            'endDateTypeInDatePicker
            '
            Me.endDateTypeInDatePicker.Location = New System.Drawing.Point(203, 448)
            Me.endDateTypeInDatePicker.MaximumSize = New System.Drawing.Size(74, 22)
            Me.endDateTypeInDatePicker.MinimumSize = New System.Drawing.Size(74, 22)
            Me.endDateTypeInDatePicker.Name = "endDateTypeInDatePicker"
            Me.endDateTypeInDatePicker.Size = New System.Drawing.Size(74, 22)
            Me.endDateTypeInDatePicker.TabIndex = 21
            Me.endDateTypeInDatePicker.Value = Nothing
            '
            'endDateLabel
            '
            Me.endDateLabel.AutoSize = True
            Me.endDateLabel.Location = New System.Drawing.Point(154, 451)
            Me.endDateLabel.Name = "endDateLabel"
            Me.endDateLabel.Size = New System.Drawing.Size(43, 13)
            Me.endDateLabel.TabIndex = 20
            Me.endDateLabel.Text = "E&nd Dt."
            '
            'pagesLabel
            '
            Me.pagesLabel.AutoSize = True
            Me.pagesLabel.Location = New System.Drawing.Point(303, 422)
            Me.pagesLabel.Name = "pagesLabel"
            Me.pagesLabel.Size = New System.Drawing.Size(37, 13)
            Me.pagesLabel.TabIndex = 23
            Me.pagesLabel.Text = "Pages"
            '
            'pagesButton
            '
            Me.pagesButton.Location = New System.Drawing.Point(346, 417)
            Me.pagesButton.Name = "pagesButton"
            Me.pagesButton.Size = New System.Drawing.Size(134, 23)
            Me.pagesButton.TabIndex = 24
            Me.pagesButton.Text = "Define &Pages"
            Me.pagesButton.UseVisualStyleBackColor = True
            '
            'mktPubGroupBox
            '
            Me.mktPubGroupBox.Controls.Add(Me.scanButton)
            Me.mktPubGroupBox.Controls.Add(Me.marketCheckedListBox)
            Me.mktPubGroupBox.Controls.Add(Me.showPublicationRadioButton)
            Me.mktPubGroupBox.Controls.Add(Me.selectedMktPubListBox)
            Me.mktPubGroupBox.Controls.Add(Me.showVehicleIdRadioButton)
            Me.mktPubGroupBox.Controls.Add(Me.marketLabel)
            Me.mktPubGroupBox.Controls.Add(Me.mktPubLabel)
            Me.mktPubGroupBox.Location = New System.Drawing.Point(6, 175)
            Me.mktPubGroupBox.Name = "mktPubGroupBox"
            Me.mktPubGroupBox.Size = New System.Drawing.Size(551, 184)
            Me.mktPubGroupBox.TabIndex = 12
            Me.mktPubGroupBox.TabStop = False
            '
            'scanButton
            '
            Me.scanButton.Location = New System.Drawing.Point(8, 34)
            Me.scanButton.Name = "scanButton"
            Me.scanButton.Size = New System.Drawing.Size(52, 23)
            Me.scanButton.TabIndex = 1
            Me.scanButton.Text = "Scan"
            Me.scanButton.UseVisualStyleBackColor = True
            '
            'marketCheckedListBox
            '
            Me.marketCheckedListBox.FormattingEnabled = True
            Me.marketCheckedListBox.HorizontalScrollbar = True
            Me.marketCheckedListBox.Location = New System.Drawing.Point(66, 16)
            Me.marketCheckedListBox.Name = "marketCheckedListBox"
            Me.marketCheckedListBox.Size = New System.Drawing.Size(205, 139)
            Me.marketCheckedListBox.TabIndex = 2
            '
            'showPublicationRadioButton
            '
            Me.showPublicationRadioButton.AutoSize = True
            Me.showPublicationRadioButton.Location = New System.Drawing.Point(171, 161)
            Me.showPublicationRadioButton.Name = "showPublicationRadioButton"
            Me.showPublicationRadioButton.Size = New System.Drawing.Size(107, 17)
            Me.showPublicationRadioButton.TabIndex = 6
            Me.showPublicationRadioButton.Text = "Show Publication"
            Me.showPublicationRadioButton.UseVisualStyleBackColor = True
            '
            'selectedMktPubListBox
            '
            Me.selectedMktPubListBox.FormattingEnabled = True
            Me.selectedMktPubListBox.HorizontalScrollbar = True
            Me.m_ErrorProvider.SetIconAlignment(Me.selectedMktPubListBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.selectedMktPubListBox.Location = New System.Drawing.Point(300, 34)
            Me.selectedMktPubListBox.Name = "selectedMktPubListBox"
            Me.selectedMktPubListBox.Size = New System.Drawing.Size(241, 121)
            Me.selectedMktPubListBox.TabIndex = 4
            '
            'showVehicleIdRadioButton
            '
            Me.showVehicleIdRadioButton.AutoSize = True
            Me.showVehicleIdRadioButton.Checked = True
            Me.showVehicleIdRadioButton.Location = New System.Drawing.Point(66, 161)
            Me.showVehicleIdRadioButton.Name = "showVehicleIdRadioButton"
            Me.showVehicleIdRadioButton.Size = New System.Drawing.Size(99, 17)
            Me.showVehicleIdRadioButton.TabIndex = 5
            Me.showVehicleIdRadioButton.TabStop = True
            Me.showVehicleIdRadioButton.Text = "Show VehicleId"
            Me.showVehicleIdRadioButton.UseVisualStyleBackColor = True
            '
            'saveButton
            '
            Me.saveButton.Location = New System.Drawing.Point(324, 446)
            Me.saveButton.Name = "saveButton"
            Me.saveButton.Size = New System.Drawing.Size(75, 23)
            Me.saveButton.TabIndex = 25
            Me.saveButton.Text = "&Index"
            Me.saveButton.UseVisualStyleBackColor = True
            '
            'closeButton
            '
            Me.closeButton.Location = New System.Drawing.Point(486, 446)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(75, 23)
            Me.closeButton.TabIndex = 27
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'searchGroupBox
            '
            Me.searchGroupBox.Controls.Add(Me.gotoButton)
            Me.searchGroupBox.Controls.Add(Me.gotoVehicleIdTextBox)
            Me.searchGroupBox.Location = New System.Drawing.Point(14, 12)
            Me.searchGroupBox.Name = "searchGroupBox"
            Me.searchGroupBox.Size = New System.Drawing.Size(257, 46)
            Me.searchGroupBox.TabIndex = 0
            Me.searchGroupBox.TabStop = False
            Me.searchGroupBox.Text = "Search based on Vehicle Id"
            '
            'gotoButton
            '
            Me.gotoButton.Location = New System.Drawing.Point(176, 17)
            Me.gotoButton.Name = "gotoButton"
            Me.gotoButton.Size = New System.Drawing.Size(75, 23)
            Me.gotoButton.TabIndex = 1
            Me.gotoButton.Text = "Search"
            Me.gotoButton.UseVisualStyleBackColor = True
            '
            'gotoVehicleIdTextBox
            '
            Me.gotoVehicleIdTextBox.Location = New System.Drawing.Point(6, 19)
            Me.gotoVehicleIdTextBox.MaxLength = 9
            Me.gotoVehicleIdTextBox.Name = "gotoVehicleIdTextBox"
            Me.gotoVehicleIdTextBox.Size = New System.Drawing.Size(163, 20)
            Me.gotoVehicleIdTextBox.TabIndex = 0
            '
            'couponIndCheckBox
            '
            Me.couponIndCheckBox.AutoSize = True
            Me.couponIndCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.couponIndCheckBox.Location = New System.Drawing.Point(300, 397)
            Me.couponIndCheckBox.Name = "couponIndCheckBox"
            Me.couponIndCheckBox.Size = New System.Drawing.Size(84, 17)
            Me.couponIndCheckBox.TabIndex = 22
            Me.couponIndCheckBox.Text = "&Has coupon"
            Me.couponIndCheckBox.UseVisualStyleBackColor = True
            Me.couponIndCheckBox.Visible = False
            '
            'languageComboBox
            '
            Me.languageComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.languageComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.languageComboBox.FormattingEnabled = True
            Me.languageComboBox.Location = New System.Drawing.Point(72, 146)
            Me.languageComboBox.Name = "languageComboBox"
            Me.languageComboBox.Size = New System.Drawing.Size(205, 21)
            Me.languageComboBox.TabIndex = 11
            '
            'languageLabel
            '
            Me.languageLabel.AutoSize = True
            Me.languageLabel.Location = New System.Drawing.Point(11, 149)
            Me.languageLabel.Name = "languageLabel"
            Me.languageLabel.Size = New System.Drawing.Size(55, 13)
            Me.languageLabel.TabIndex = 10
            Me.languageLabel.Text = "Lang&uage"
            '
            'clearButton
            '
            Me.clearButton.Location = New System.Drawing.Point(405, 446)
            Me.clearButton.Name = "clearButton"
            Me.clearButton.Size = New System.Drawing.Size(75, 23)
            Me.clearButton.TabIndex = 26
            Me.clearButton.Text = "&Clear"
            Me.clearButton.UseVisualStyleBackColor = True
            '
            'dayRangeNumericUpDown
            '
            Me.dayRangeNumericUpDown.Location = New System.Drawing.Point(152, 65)
            Me.dayRangeNumericUpDown.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
            Me.dayRangeNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.dayRangeNumericUpDown.Name = "dayRangeNumericUpDown"
            Me.dayRangeNumericUpDown.Size = New System.Drawing.Size(46, 20)
            Me.dayRangeNumericUpDown.TabIndex = 3
            Me.dayRangeNumericUpDown.Value = New Decimal(New Integer() {3, 0, 0, 0})
            '
            'loadjoinFamilyButton
            '
            Me.loadjoinFamilyButton.Enabled = False
            Me.loadjoinFamilyButton.Location = New System.Drawing.Point(72, 365)
            Me.loadjoinFamilyButton.Name = "loadjoinFamilyButton"
            Me.loadjoinFamilyButton.Size = New System.Drawing.Size(205, 23)
            Me.loadjoinFamilyButton.TabIndex = 13
            Me.loadjoinFamilyButton.Text = "Load / Join Family"
            Me.loadjoinFamilyButton.UseVisualStyleBackColor = True
            '
            'FamilyCheckInForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(566, 476)
            Me.Controls.Add(Me.loadjoinFamilyButton)
            Me.Controls.Add(Me.dayRangeNumericUpDown)
            Me.Controls.Add(Me.clearButton)
            Me.Controls.Add(Me.languageComboBox)
            Me.Controls.Add(Me.languageLabel)
            Me.Controls.Add(Me.couponIndCheckBox)
            Me.Controls.Add(Me.searchGroupBox)
            Me.Controls.Add(Me.closeButton)
            Me.Controls.Add(Me.saveButton)
            Me.Controls.Add(Me.mktPubGroupBox)
            Me.Controls.Add(Me.pagesButton)
            Me.Controls.Add(Me.pagesLabel)
            Me.Controls.Add(Me.endDateTypeInDatePicker)
            Me.Controls.Add(Me.endDateLabel)
            Me.Controls.Add(Me.startDateTypeInDatePicker)
            Me.Controls.Add(Me.startDateLabel)
            Me.Controls.Add(Me.themeComboBox)
            Me.Controls.Add(Me.themeLabel)
            Me.Controls.Add(Me.eventComboBox)
            Me.Controls.Add(Me.eventLabel)
            Me.Controls.Add(Me.tradeclassValueLabel)
            Me.Controls.Add(Me.tradeclassLabel)
            Me.Controls.Add(Me.retailerComboBox)
            Me.Controls.Add(Me.retailerLabel)
            Me.Controls.Add(Me.mediaComboBox)
            Me.Controls.Add(Me.mediaLabel)
            Me.Controls.Add(Me.adDateTypeInDatePicker)
            Me.Controls.Add(Me.adDateLabel)
            Me.MaximizeBox = False
            Me.Name = "FamilyCheckInForm"
            Me.StatusMessage = ""
            Me.Text = "Family Indexing"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.mktPubGroupBox.ResumeLayout(False)
            Me.mktPubGroupBox.PerformLayout()
            Me.searchGroupBox.ResumeLayout(False)
            Me.searchGroupBox.PerformLayout()
            CType(Me.dayRangeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents adDateLabel As System.Windows.Forms.Label
    Friend WithEvents adDateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
    Friend WithEvents mediaLabel As System.Windows.Forms.Label
    Friend WithEvents mediaComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents retailerComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents retailerLabel As System.Windows.Forms.Label
    Friend WithEvents marketLabel As System.Windows.Forms.Label
    Friend WithEvents mktPubLabel As System.Windows.Forms.Label
    Friend WithEvents tradeclassLabel As System.Windows.Forms.Label
    Friend WithEvents tradeclassValueLabel As System.Windows.Forms.Label
    Friend WithEvents eventLabel As System.Windows.Forms.Label
    Friend WithEvents eventComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents themeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents themeLabel As System.Windows.Forms.Label
    Friend WithEvents startDateLabel As System.Windows.Forms.Label
    Friend WithEvents startDateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
    Friend WithEvents endDateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
    Friend WithEvents endDateLabel As System.Windows.Forms.Label
    Friend WithEvents pagesLabel As System.Windows.Forms.Label
    Friend WithEvents pagesButton As System.Windows.Forms.Button
    Friend WithEvents mktPubGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents saveButton As System.Windows.Forms.Button
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents searchGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents gotoButton As System.Windows.Forms.Button
    Friend WithEvents gotoVehicleIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents selectedMktPubListBox As System.Windows.Forms.ListBox
    Friend WithEvents couponIndCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents languageComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents languageLabel As System.Windows.Forms.Label
    Friend WithEvents marketCheckedListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents clearButton As System.Windows.Forms.Button
    Friend WithEvents showVehicleIdRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents showPublicationRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents dayRangeNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents loadjoinFamilyButton As System.Windows.Forms.Button
    Friend WithEvents scanButton As System.Windows.Forms.Button
  End Class

End Namespace