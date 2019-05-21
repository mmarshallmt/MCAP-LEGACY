Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class FamilyViewForm
    Inherits FamilyBaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FamilyViewForm))
            Me.retailerNameLabel = New System.Windows.Forms.Label()
            Me.retailerLabel = New System.Windows.Forms.Label()
            Me.loadButton = New System.Windows.Forms.Button()
            Me.vehicleIdTextBox = New System.Windows.Forms.TextBox()
            Me.loadLabel = New System.Windows.Forms.Label()
            Me.closeButton = New System.Windows.Forms.Button()
            Me.familyButton = New System.Windows.Forms.Button()
            Me.splitFamilyButton = New System.Windows.Forms.Button()
            Me.OthersGroupBox = New System.Windows.Forms.GroupBox()
            Me.RadioButtonComparison = New System.Windows.Forms.RadioButton()
            Me.RadioButtonEntry = New System.Windows.Forms.RadioButton()
            Me.DurablesCheckBox = New System.Windows.Forms.CheckBox()
            Me.ConsumablesCheckBox = New System.Windows.Forms.CheckBox()
            Me.AdDistGroupBox = New System.Windows.Forms.GroupBox()
            Me.LocalRadioButton = New System.Windows.Forms.RadioButton()
            Me.RegionalRadioButton = New System.Windows.Forms.RadioButton()
            Me.NationalRadioButton = New System.Windows.Forms.RadioButton()
            Me.AdTypeGroupBox = New System.Windows.Forms.GroupBox()
            Me.WeeklyRadioButton = New System.Windows.Forms.RadioButton()
            Me.SupplementalRadioButton = New System.Windows.Forms.RadioButton()
            Me.SaveButton = New System.Windows.Forms.Button()
            Me.LockButton = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.SearchLabel = New System.Windows.Forms.Label()
            Me.LabelFlash = New System.Windows.Forms.Label()
            Me.topPanel.SuspendLayout()
            Me.bottomPanel.SuspendLayout()
            CType(Me.DisplayFamilyInformationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.FamilyDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.OthersGroupBox.SuspendLayout()
            Me.AdDistGroupBox.SuspendLayout()
            Me.AdTypeGroupBox.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'topPanel
            '
            Me.topPanel.Controls.Add(Me.LabelFlash)
            Me.topPanel.Controls.Add(Me.OthersGroupBox)
            Me.topPanel.Controls.Add(Me.AdDistGroupBox)
            Me.topPanel.Controls.Add(Me.AdTypeGroupBox)
            Me.topPanel.Controls.Add(Me.retailerNameLabel)
            Me.topPanel.Controls.Add(Me.retailerLabel)
            Me.topPanel.Controls.Add(Me.loadButton)
            Me.topPanel.Controls.Add(Me.vehicleIdTextBox)
            Me.topPanel.Controls.Add(Me.loadLabel)
            Me.topPanel.Size = New System.Drawing.Size(1020, 146)
            '
            'bottomPanel
            '
            Me.bottomPanel.Controls.Add(Me.Panel1)
            Me.bottomPanel.Controls.Add(Me.SaveButton)
            Me.bottomPanel.Controls.Add(Me.LockButton)
            Me.bottomPanel.Controls.Add(Me.closeButton)
            Me.bottomPanel.Controls.Add(Me.familyButton)
            Me.bottomPanel.Controls.Add(Me.splitFamilyButton)
            Me.bottomPanel.Location = New System.Drawing.Point(0, 409)
            Me.bottomPanel.Size = New System.Drawing.Size(1020, 86)
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'retailerNameLabel
            '
            Me.retailerNameLabel.AutoSize = True
            Me.retailerNameLabel.Location = New System.Drawing.Point(64, 31)
            Me.retailerNameLabel.Name = "retailerNameLabel"
            Me.retailerNameLabel.Size = New System.Drawing.Size(55, 13)
            Me.retailerNameLabel.TabIndex = 4
            Me.retailerNameLabel.Text = "<Retailer>"
            Me.retailerNameLabel.UseMnemonic = False
            '
            'retailerLabel
            '
            Me.retailerLabel.AutoSize = True
            Me.retailerLabel.Location = New System.Drawing.Point(12, 31)
            Me.retailerLabel.Name = "retailerLabel"
            Me.retailerLabel.Size = New System.Drawing.Size(46, 13)
            Me.retailerLabel.TabIndex = 3
            Me.retailerLabel.Text = "Retailer:"
            '
            'loadButton
            '
            Me.loadButton.Location = New System.Drawing.Point(267, 4)
            Me.loadButton.Name = "loadButton"
            Me.loadButton.Size = New System.Drawing.Size(75, 23)
            Me.loadButton.TabIndex = 2
            Me.loadButton.Text = "&Load"
            Me.loadButton.UseVisualStyleBackColor = True
            '
            'vehicleIdTextBox
            '
            Me.vehicleIdTextBox.Location = New System.Drawing.Point(128, 6)
            Me.vehicleIdTextBox.Name = "vehicleIdTextBox"
            Me.vehicleIdTextBox.Size = New System.Drawing.Size(133, 20)
            Me.vehicleIdTextBox.TabIndex = 1
            '
            'loadLabel
            '
            Me.loadLabel.AutoSize = True
            Me.loadLabel.Location = New System.Drawing.Point(12, 9)
            Me.loadLabel.Name = "loadLabel"
            Me.loadLabel.Size = New System.Drawing.Size(110, 13)
            Me.loadLabel.TabIndex = 0
            Me.loadLabel.Text = "Load From &Vehicle Id:"
            '
            'closeButton
            '
            Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.closeButton.Location = New System.Drawing.Point(862, 20)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(137, 23)
            Me.closeButton.TabIndex = 2
            Me.closeButton.Text = "Cl&ose - Don't Review Family"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'familyButton
            '
            Me.familyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.familyButton.Location = New System.Drawing.Point(878, 20)
            Me.familyButton.Name = "familyButton"
            Me.familyButton.Size = New System.Drawing.Size(75, 23)
            Me.familyButton.TabIndex = 1
            Me.familyButton.Text = "Family O&K"
            Me.familyButton.UseVisualStyleBackColor = True
            Me.familyButton.Visible = False
            '
            'splitFamilyButton
            '
            Me.splitFamilyButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.splitFamilyButton.Location = New System.Drawing.Point(12, 9)
            Me.splitFamilyButton.Name = "splitFamilyButton"
            Me.splitFamilyButton.Size = New System.Drawing.Size(115, 45)
            Me.splitFamilyButton.TabIndex = 0
            Me.splitFamilyButton.Text = "Split Out Selected to Separate Family"
            Me.splitFamilyButton.UseVisualStyleBackColor = True
            '
            'OthersGroupBox
            '
            Me.OthersGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.OthersGroupBox.Controls.Add(Me.RadioButtonComparison)
            Me.OthersGroupBox.Controls.Add(Me.RadioButtonEntry)
            Me.OthersGroupBox.Controls.Add(Me.DurablesCheckBox)
            Me.OthersGroupBox.Controls.Add(Me.ConsumablesCheckBox)
            Me.OthersGroupBox.Location = New System.Drawing.Point(242, 47)
            Me.OthersGroupBox.Name = "OthersGroupBox"
            Me.OthersGroupBox.Size = New System.Drawing.Size(766, 91)
            Me.OthersGroupBox.TabIndex = 18
            Me.OthersGroupBox.TabStop = False
            Me.OthersGroupBox.Visible = False
            '
            'RadioButtonComparison
            '
            Me.RadioButtonComparison.AutoSize = True
            Me.RadioButtonComparison.Location = New System.Drawing.Point(25, 56)
            Me.RadioButtonComparison.Name = "RadioButtonComparison"
            Me.RadioButtonComparison.Size = New System.Drawing.Size(120, 17)
            Me.RadioButtonComparison.TabIndex = 14
            Me.RadioButtonComparison.Text = "Comparison Eligable"
            Me.RadioButtonComparison.UseVisualStyleBackColor = True
            '
            'RadioButtonEntry
            '
            Me.RadioButtonEntry.AutoSize = True
            Me.RadioButtonEntry.Checked = True
            Me.RadioButtonEntry.Location = New System.Drawing.Point(25, 19)
            Me.RadioButtonEntry.Name = "RadioButtonEntry"
            Me.RadioButtonEntry.Size = New System.Drawing.Size(49, 17)
            Me.RadioButtonEntry.TabIndex = 13
            Me.RadioButtonEntry.TabStop = True
            Me.RadioButtonEntry.Text = "Entry"
            Me.RadioButtonEntry.UseVisualStyleBackColor = True
            '
            'DurablesCheckBox
            '
            Me.DurablesCheckBox.AutoSize = True
            Me.DurablesCheckBox.Checked = True
            Me.DurablesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
            Me.DurablesCheckBox.Location = New System.Drawing.Point(329, 19)
            Me.DurablesCheckBox.Name = "DurablesCheckBox"
            Me.DurablesCheckBox.Size = New System.Drawing.Size(131, 17)
            Me.DurablesCheckBox.TabIndex = 10
            Me.DurablesCheckBox.Text = "Durables Entry Eligible"
            Me.DurablesCheckBox.UseVisualStyleBackColor = True
            '
            'ConsumablesCheckBox
            '
            Me.ConsumablesCheckBox.AutoSize = True
            Me.ConsumablesCheckBox.Checked = True
            Me.ConsumablesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
            Me.ConsumablesCheckBox.Location = New System.Drawing.Point(161, 20)
            Me.ConsumablesCheckBox.Name = "ConsumablesCheckBox"
            Me.ConsumablesCheckBox.Size = New System.Drawing.Size(152, 17)
            Me.ConsumablesCheckBox.TabIndex = 11
            Me.ConsumablesCheckBox.Text = "Consumables Entry Eligible"
            Me.ConsumablesCheckBox.UseVisualStyleBackColor = True
            '
            'AdDistGroupBox
            '
            Me.AdDistGroupBox.Controls.Add(Me.LocalRadioButton)
            Me.AdDistGroupBox.Controls.Add(Me.RegionalRadioButton)
            Me.AdDistGroupBox.Controls.Add(Me.NationalRadioButton)
            Me.AdDistGroupBox.Location = New System.Drawing.Point(124, 47)
            Me.AdDistGroupBox.Name = "AdDistGroupBox"
            Me.AdDistGroupBox.Size = New System.Drawing.Size(112, 91)
            Me.AdDistGroupBox.TabIndex = 17
            Me.AdDistGroupBox.TabStop = False
            Me.AdDistGroupBox.Text = "Ad Distribution"
            Me.AdDistGroupBox.Visible = False
            '
            'LocalRadioButton
            '
            Me.LocalRadioButton.AutoSize = True
            Me.LocalRadioButton.Location = New System.Drawing.Point(10, 21)
            Me.LocalRadioButton.Name = "LocalRadioButton"
            Me.LocalRadioButton.Size = New System.Drawing.Size(51, 17)
            Me.LocalRadioButton.TabIndex = 7
            Me.LocalRadioButton.Text = "Local"
            Me.LocalRadioButton.UseVisualStyleBackColor = True
            '
            'RegionalRadioButton
            '
            Me.RegionalRadioButton.AutoSize = True
            Me.RegionalRadioButton.Location = New System.Drawing.Point(10, 44)
            Me.RegionalRadioButton.Name = "RegionalRadioButton"
            Me.RegionalRadioButton.Size = New System.Drawing.Size(67, 17)
            Me.RegionalRadioButton.TabIndex = 8
            Me.RegionalRadioButton.Text = "Regional"
            Me.RegionalRadioButton.UseVisualStyleBackColor = True
            '
            'NationalRadioButton
            '
            Me.NationalRadioButton.AutoSize = True
            Me.NationalRadioButton.Location = New System.Drawing.Point(10, 67)
            Me.NationalRadioButton.Name = "NationalRadioButton"
            Me.NationalRadioButton.Size = New System.Drawing.Size(64, 17)
            Me.NationalRadioButton.TabIndex = 9
            Me.NationalRadioButton.Text = "National"
            Me.NationalRadioButton.UseVisualStyleBackColor = True
            '
            'AdTypeGroupBox
            '
            Me.AdTypeGroupBox.Controls.Add(Me.WeeklyRadioButton)
            Me.AdTypeGroupBox.Controls.Add(Me.SupplementalRadioButton)
            Me.AdTypeGroupBox.Location = New System.Drawing.Point(12, 47)
            Me.AdTypeGroupBox.Name = "AdTypeGroupBox"
            Me.AdTypeGroupBox.Size = New System.Drawing.Size(106, 91)
            Me.AdTypeGroupBox.TabIndex = 16
            Me.AdTypeGroupBox.TabStop = False
            Me.AdTypeGroupBox.Text = "Ad Type"
            '
            'WeeklyRadioButton
            '
            Me.WeeklyRadioButton.AutoSize = True
            Me.WeeklyRadioButton.Location = New System.Drawing.Point(8, 32)
            Me.WeeklyRadioButton.Name = "WeeklyRadioButton"
            Me.WeeklyRadioButton.Size = New System.Drawing.Size(59, 17)
            Me.WeeklyRadioButton.TabIndex = 5
            Me.WeeklyRadioButton.TabStop = True
            Me.WeeklyRadioButton.Text = "Primary"
            Me.WeeklyRadioButton.UseVisualStyleBackColor = True
            '
            'SupplementalRadioButton
            '
            Me.SupplementalRadioButton.AutoSize = True
            Me.SupplementalRadioButton.Location = New System.Drawing.Point(8, 55)
            Me.SupplementalRadioButton.Name = "SupplementalRadioButton"
            Me.SupplementalRadioButton.Size = New System.Drawing.Size(89, 17)
            Me.SupplementalRadioButton.TabIndex = 6
            Me.SupplementalRadioButton.TabStop = True
            Me.SupplementalRadioButton.Text = "Supplemental"
            Me.SupplementalRadioButton.UseVisualStyleBackColor = True
            '
            'SaveButton
            '
            Me.SaveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.SaveButton.Location = New System.Drawing.Point(132, 9)
            Me.SaveButton.Name = "SaveButton"
            Me.SaveButton.Size = New System.Drawing.Size(115, 45)
            Me.SaveButton.TabIndex = 6
            Me.SaveButton.Text = "Save Changes"
            Me.SaveButton.UseVisualStyleBackColor = True
            '
            'LockButton
            '
            Me.LockButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.LockButton.Enabled = False
            Me.LockButton.Location = New System.Drawing.Point(253, 9)
            Me.LockButton.Name = "LockButton"
            Me.LockButton.Size = New System.Drawing.Size(115, 45)
            Me.LockButton.TabIndex = 5
            Me.LockButton.Text = "Lock"
            Me.LockButton.UseVisualStyleBackColor = True
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.SearchLabel)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 63)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(1020, 23)
            Me.Panel1.TabIndex = 7
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
            'LabelFlash
            '
            Me.LabelFlash.AutoSize = True
            Me.LabelFlash.ForeColor = System.Drawing.Color.Red
            Me.LabelFlash.Location = New System.Drawing.Point(357, 9)
            Me.LabelFlash.Name = "LabelFlash"
            Me.LabelFlash.Size = New System.Drawing.Size(84, 13)
            Me.LabelFlash.TabIndex = 19
            Me.LabelFlash.Text = "Family has Flash"
            Me.LabelFlash.Visible = False
            '
            'FamilyViewForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1020, 495)
            Me.Name = "FamilyViewForm"
            Me.Text = "View Family"
            Me.topPanel.ResumeLayout(False)
            Me.topPanel.PerformLayout()
            Me.bottomPanel.ResumeLayout(False)
            CType(Me.DisplayFamilyInformationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.FamilyDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.OthersGroupBox.ResumeLayout(False)
            Me.OthersGroupBox.PerformLayout()
            Me.AdDistGroupBox.ResumeLayout(False)
            Me.AdDistGroupBox.PerformLayout()
            Me.AdTypeGroupBox.ResumeLayout(False)
            Me.AdTypeGroupBox.PerformLayout()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
    Friend WithEvents loadLabel As System.Windows.Forms.Label
    Friend WithEvents retailerNameLabel As System.Windows.Forms.Label
    Friend WithEvents retailerLabel As System.Windows.Forms.Label
    Friend WithEvents loadButton As System.Windows.Forms.Button
    Friend WithEvents vehicleIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents familyButton As System.Windows.Forms.Button
        Friend WithEvents splitFamilyButton As System.Windows.Forms.Button
        Friend WithEvents OthersGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents DurablesCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents ConsumablesCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents AdDistGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents LocalRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents RegionalRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents NationalRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents AdTypeGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents WeeklyRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents SupplementalRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents SaveButton As System.Windows.Forms.Button
        Friend WithEvents LockButton As System.Windows.Forms.Button
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents SearchLabel As System.Windows.Forms.Label
        Friend WithEvents RadioButtonComparison As System.Windows.Forms.RadioButton
        Friend WithEvents RadioButtonEntry As System.Windows.Forms.RadioButton
        Friend WithEvents LabelFlash As System.Windows.Forms.Label

  End Class

End Namespace