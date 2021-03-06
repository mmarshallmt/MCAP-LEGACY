﻿Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class FamilyReviewForm
    Inherits FamilyBaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FamilyReviewForm))
            Me.mediaComboBox = New System.Windows.Forms.ComboBox()
            Me.mediaLabel = New System.Windows.Forms.Label()
            Me.searchButton = New System.Windows.Forms.Button()
            Me.includeReviewedCheckBox = New System.Windows.Forms.CheckBox()
            Me.priorityComboBox = New System.Windows.Forms.ComboBox()
            Me.priorityLabel = New System.Windows.Forms.Label()
            Me.retailerComboBox = New System.Windows.Forms.ComboBox()
            Me.retailerLabel = New System.Windows.Forms.Label()
            Me.tradeclassComboBox = New System.Windows.Forms.ComboBox()
            Me.tradeclassLabel = New System.Windows.Forms.Label()
            Me.adDateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.adDateLabel = New System.Windows.Forms.Label()
            Me.ShowWholeFamilyButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn()
            Me.closeButton = New System.Windows.Forms.Button()
            Me.familyCorrectButton = New System.Windows.Forms.Button()
            Me.mergeButton = New System.Windows.Forms.Button()
            Me.withinLabel = New System.Windows.Forms.Label()
            Me.daysNumericUpDown = New System.Windows.Forms.NumericUpDown()
            Me.daysLabel = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.SearchLabel = New System.Windows.Forms.Label()
            Me.searchGroupBox = New System.Windows.Forms.GroupBox()
            Me.gotoButton = New System.Windows.Forms.Button()
            Me.gotoVehicleIdTextBox = New System.Windows.Forms.TextBox()
            Me.topPanel.SuspendLayout()
            Me.bottomPanel.SuspendLayout()
            CType(Me.DisplayFamilyInformationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.FamilyDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.daysNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.searchGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'topPanel
            '
            Me.topPanel.Controls.Add(Me.searchGroupBox)
            Me.topPanel.Controls.Add(Me.mediaComboBox)
            Me.topPanel.Controls.Add(Me.mediaLabel)
            Me.topPanel.Controls.Add(Me.searchButton)
            Me.topPanel.Controls.Add(Me.includeReviewedCheckBox)
            Me.topPanel.Controls.Add(Me.priorityComboBox)
            Me.topPanel.Controls.Add(Me.priorityLabel)
            Me.topPanel.Controls.Add(Me.retailerComboBox)
            Me.topPanel.Controls.Add(Me.retailerLabel)
            Me.topPanel.Controls.Add(Me.tradeclassComboBox)
            Me.topPanel.Controls.Add(Me.tradeclassLabel)
            Me.topPanel.Controls.Add(Me.adDateTypeInDatePicker)
            Me.topPanel.Controls.Add(Me.adDateLabel)
            Me.topPanel.Controls.Add(Me.withinLabel)
            Me.topPanel.Controls.Add(Me.daysNumericUpDown)
            Me.topPanel.Controls.Add(Me.daysLabel)
            Me.topPanel.Size = New System.Drawing.Size(1250, 206)
            '
            'bottomPanel
            '
            Me.bottomPanel.Controls.Add(Me.Panel1)
            Me.bottomPanel.Controls.Add(Me.closeButton)
            Me.bottomPanel.Controls.Add(Me.familyCorrectButton)
            Me.bottomPanel.Controls.Add(Me.mergeButton)
            Me.bottomPanel.Location = New System.Drawing.Point(0, 648)
            Me.bottomPanel.Size = New System.Drawing.Size(1250, 54)
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'mediaComboBox
            '
            Me.mediaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.mediaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.mediaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.mediaComboBox.FormattingEnabled = True
            Me.mediaComboBox.Location = New System.Drawing.Point(77, 85)
            Me.mediaComboBox.Name = "mediaComboBox"
            Me.mediaComboBox.Size = New System.Drawing.Size(253, 21)
            Me.mediaComboBox.TabIndex = 6
            '
            'mediaLabel
            '
            Me.mediaLabel.AutoSize = True
            Me.mediaLabel.Location = New System.Drawing.Point(12, 88)
            Me.mediaLabel.Name = "mediaLabel"
            Me.mediaLabel.Size = New System.Drawing.Size(36, 13)
            Me.mediaLabel.TabIndex = 5
            Me.mediaLabel.Text = "Me&dia"
            '
            'searchButton
            '
            Me.searchButton.Location = New System.Drawing.Point(422, 165)
            Me.searchButton.Name = "searchButton"
            Me.searchButton.Size = New System.Drawing.Size(75, 23)
            Me.searchButton.TabIndex = 14
            Me.searchButton.Text = "Searc&h"
            Me.searchButton.UseVisualStyleBackColor = True
            '
            'includeReviewedCheckBox
            '
            Me.includeReviewedCheckBox.AutoSize = True
            Me.includeReviewedCheckBox.Checked = True
            Me.includeReviewedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
            Me.includeReviewedCheckBox.Location = New System.Drawing.Point(345, 144)
            Me.includeReviewedCheckBox.Name = "includeReviewedCheckBox"
            Me.includeReviewedCheckBox.Size = New System.Drawing.Size(152, 17)
            Me.includeReviewedCheckBox.TabIndex = 13
            Me.includeReviewedCheckBox.Text = "Include Revie&wed Families"
            Me.includeReviewedCheckBox.UseVisualStyleBackColor = True
            '
            'priorityComboBox
            '
            Me.priorityComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.priorityComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.priorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.priorityComboBox.FormattingEnabled = True
            Me.priorityComboBox.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"})
            Me.priorityComboBox.Location = New System.Drawing.Point(77, 167)
            Me.priorityComboBox.Name = "priorityComboBox"
            Me.priorityComboBox.Size = New System.Drawing.Size(72, 21)
            Me.priorityComboBox.TabIndex = 12
            '
            'priorityLabel
            '
            Me.priorityLabel.AutoSize = True
            Me.priorityLabel.Location = New System.Drawing.Point(12, 170)
            Me.priorityLabel.Name = "priorityLabel"
            Me.priorityLabel.Size = New System.Drawing.Size(38, 13)
            Me.priorityLabel.TabIndex = 11
            Me.priorityLabel.Text = "&Priority"
            '
            'retailerComboBox
            '
            Me.retailerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.retailerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.retailerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.retailerComboBox.FormattingEnabled = True
            Me.retailerComboBox.Location = New System.Drawing.Point(77, 140)
            Me.retailerComboBox.Name = "retailerComboBox"
            Me.retailerComboBox.Size = New System.Drawing.Size(253, 21)
            Me.retailerComboBox.TabIndex = 10
            '
            'retailerLabel
            '
            Me.retailerLabel.AutoSize = True
            Me.retailerLabel.Location = New System.Drawing.Point(12, 143)
            Me.retailerLabel.Name = "retailerLabel"
            Me.retailerLabel.Size = New System.Drawing.Size(43, 13)
            Me.retailerLabel.TabIndex = 9
            Me.retailerLabel.Text = "&Retailer"
            '
            'tradeclassComboBox
            '
            Me.tradeclassComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.tradeclassComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.tradeclassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.tradeclassComboBox.FormattingEnabled = True
            Me.tradeclassComboBox.Location = New System.Drawing.Point(77, 113)
            Me.tradeclassComboBox.Name = "tradeclassComboBox"
            Me.tradeclassComboBox.Size = New System.Drawing.Size(253, 21)
            Me.tradeclassComboBox.TabIndex = 8
            '
            'tradeclassLabel
            '
            Me.tradeclassLabel.AutoSize = True
            Me.tradeclassLabel.Location = New System.Drawing.Point(12, 116)
            Me.tradeclassLabel.Name = "tradeclassLabel"
            Me.tradeclassLabel.Size = New System.Drawing.Size(59, 13)
            Me.tradeclassLabel.TabIndex = 7
            Me.tradeclassLabel.Text = "&Tradeclass"
            '
            'adDateTypeInDatePicker
            '
            Me.adDateTypeInDatePicker.Location = New System.Drawing.Point(77, 58)
            Me.adDateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.adDateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.adDateTypeInDatePicker.Name = "adDateTypeInDatePicker"
            Me.adDateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.adDateTypeInDatePicker.TabIndex = 1
            Me.adDateTypeInDatePicker.Value = Nothing
            '
            'adDateLabel
            '
            Me.adDateLabel.AutoSize = True
            Me.adDateLabel.Location = New System.Drawing.Point(12, 61)
            Me.adDateLabel.Name = "adDateLabel"
            Me.adDateLabel.Size = New System.Drawing.Size(46, 13)
            Me.adDateLabel.TabIndex = 0
            Me.adDateLabel.Text = "&Ad Date"
            '
            'ShowWholeFamilyButtonColumn
            '
            Me.ShowWholeFamilyButtonColumn.HeaderText = "Show Whole Family"
            Me.ShowWholeFamilyButtonColumn.Name = "ShowWholeFamilyButtonColumn"
            Me.ShowWholeFamilyButtonColumn.ReadOnly = True
            Me.ShowWholeFamilyButtonColumn.Text = "View Family"
            Me.ShowWholeFamilyButtonColumn.UseColumnTextForButtonValue = True
            Me.ShowWholeFamilyButtonColumn.Width = 96
            '
            'closeButton
            '
            Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.closeButton.Location = New System.Drawing.Point(1163, 5)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(75, 23)
            Me.closeButton.TabIndex = 2
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'familyCorrectButton
            '
            Me.familyCorrectButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.familyCorrectButton.Location = New System.Drawing.Point(1042, 5)
            Me.familyCorrectButton.Name = "familyCorrectButton"
            Me.familyCorrectButton.Size = New System.Drawing.Size(115, 23)
            Me.familyCorrectButton.TabIndex = 1
            Me.familyCorrectButton.Text = "&Family Correct"
            Me.familyCorrectButton.UseVisualStyleBackColor = True
            '
            'mergeButton
            '
            Me.mergeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.mergeButton.Location = New System.Drawing.Point(13, 5)
            Me.mergeButton.Name = "mergeButton"
            Me.mergeButton.Size = New System.Drawing.Size(75, 23)
            Me.mergeButton.TabIndex = 0
            Me.mergeButton.Text = "&Merge"
            Me.mergeButton.UseVisualStyleBackColor = True
            '
            'withinLabel
            '
            Me.withinLabel.AutoSize = True
            Me.withinLabel.Location = New System.Drawing.Point(161, 61)
            Me.withinLabel.Name = "withinLabel"
            Me.withinLabel.Size = New System.Drawing.Size(34, 13)
            Me.withinLabel.TabIndex = 2
            Me.withinLabel.Text = "withi&n"
            '
            'daysNumericUpDown
            '
            Me.daysNumericUpDown.Location = New System.Drawing.Point(201, 58)
            Me.daysNumericUpDown.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
            Me.daysNumericUpDown.Name = "daysNumericUpDown"
            Me.daysNumericUpDown.Size = New System.Drawing.Size(45, 20)
            Me.daysNumericUpDown.TabIndex = 3
            Me.daysNumericUpDown.Value = New Decimal(New Integer() {3, 0, 0, 0})
            '
            'daysLabel
            '
            Me.daysLabel.AutoSize = True
            Me.daysLabel.Location = New System.Drawing.Point(252, 61)
            Me.daysLabel.Name = "daysLabel"
            Me.daysLabel.Size = New System.Drawing.Size(29, 13)
            Me.daysLabel.TabIndex = 4
            Me.daysLabel.Text = "days"
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.SearchLabel)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 31)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(1250, 23)
            Me.Panel1.TabIndex = 4
            '
            'SearchLabel
            '
            Me.SearchLabel.AutoSize = True
            Me.SearchLabel.Location = New System.Drawing.Point(5, 5)
            Me.SearchLabel.Name = "SearchLabel"
            Me.SearchLabel.Size = New System.Drawing.Size(33, 13)
            Me.SearchLabel.TabIndex = 14
            Me.SearchLabel.Text = "Done"
            '
            'searchGroupBox
            '
            Me.searchGroupBox.Controls.Add(Me.gotoButton)
            Me.searchGroupBox.Controls.Add(Me.gotoVehicleIdTextBox)
            Me.searchGroupBox.Location = New System.Drawing.Point(14, 4)
            Me.searchGroupBox.Name = "searchGroupBox"
            Me.searchGroupBox.Size = New System.Drawing.Size(257, 46)
            Me.searchGroupBox.TabIndex = 15
            Me.searchGroupBox.TabStop = False
            Me.searchGroupBox.Text = "Search based on Vehicle Id"
            '
            'gotoButton
            '
            Me.gotoButton.Location = New System.Drawing.Point(176, 17)
            Me.gotoButton.Name = "gotoButton"
            Me.gotoButton.Size = New System.Drawing.Size(75, 23)
            Me.gotoButton.TabIndex = 1
            Me.gotoButton.Text = "Filter"
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
            'FamilyReviewForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1250, 702)
            Me.Name = "FamilyReviewForm"
            Me.Text = "Family Review"
            Me.topPanel.ResumeLayout(False)
            Me.topPanel.PerformLayout()
            Me.bottomPanel.ResumeLayout(False)
            CType(Me.DisplayFamilyInformationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.FamilyDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.daysNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.searchGroupBox.ResumeLayout(False)
            Me.searchGroupBox.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
    Friend WithEvents priorityComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents priorityLabel As System.Windows.Forms.Label
    Friend WithEvents retailerComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents retailerLabel As System.Windows.Forms.Label
    Friend WithEvents tradeclassComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents tradeclassLabel As System.Windows.Forms.Label
    Friend WithEvents adDateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
    Friend WithEvents adDateLabel As System.Windows.Forms.Label
    Friend WithEvents includeReviewedCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents searchButton As System.Windows.Forms.Button
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents familyCorrectButton As System.Windows.Forms.Button
    Friend WithEvents mergeButton As System.Windows.Forms.Button
    Friend WithEvents mediaComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents mediaLabel As System.Windows.Forms.Label
    Friend WithEvents withinLabel As System.Windows.Forms.Label
    Friend WithEvents daysNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents daysLabel As System.Windows.Forms.Label
        Friend WithEvents ShowWholeFamilyButtonColumn As System.Windows.Forms.DataGridViewButtonColumn
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents SearchLabel As System.Windows.Forms.Label
        Friend WithEvents searchGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents gotoButton As System.Windows.Forms.Button
        Friend WithEvents gotoVehicleIdTextBox As System.Windows.Forms.TextBox

  End Class

End Namespace