Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class NewspaperLogReportForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewspaperLogReportForm))
            Me.optionsGroupBox = New System.Windows.Forms.GroupBox()
            Me.missingNotCheckedInRadioButton = New System.Windows.Forms.RadioButton()
            Me.missingNotPublishedRadioButton = New System.Windows.Forms.RadioButton()
            Me.missingNotPulledRadioButton = New System.Windows.Forms.RadioButton()
            Me.indexQCRadioButton = New System.Windows.Forms.RadioButton()
            Me.pullRadioButton = New System.Windows.Forms.RadioButton()
            Me.receivedRadioButton = New System.Windows.Forms.RadioButton()
            Me.filterByGroupBox = New System.Windows.Forms.GroupBox()
            Me.dayComboBox = New System.Windows.Forms.ComboBox()
            Me.yearNumericUpDown = New System.Windows.Forms.NumericUpDown()
            Me.userComboBox = New System.Windows.Forms.ComboBox()
            Me.userLabel = New System.Windows.Forms.Label()
            Me.yearLabel = New System.Windows.Forms.Label()
            Me.dayLabel = New System.Windows.Forms.Label()
            Me.monthComboBox = New System.Windows.Forms.ComboBox()
            Me.monthLabel = New System.Windows.Forms.Label()
            Me.exportButton = New System.Windows.Forms.Button()
            Me.closeButton = New System.Windows.Forms.Button()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.optionsGroupBox.SuspendLayout()
            Me.filterByGroupBox.SuspendLayout()
            CType(Me.yearNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'optionsGroupBox
            '
            Me.optionsGroupBox.Controls.Add(Me.missingNotCheckedInRadioButton)
            Me.optionsGroupBox.Controls.Add(Me.missingNotPublishedRadioButton)
            Me.optionsGroupBox.Controls.Add(Me.missingNotPulledRadioButton)
            Me.optionsGroupBox.Controls.Add(Me.indexQCRadioButton)
            Me.optionsGroupBox.Controls.Add(Me.pullRadioButton)
            Me.optionsGroupBox.Controls.Add(Me.receivedRadioButton)
            Me.optionsGroupBox.Location = New System.Drawing.Point(12, 12)
            Me.optionsGroupBox.Name = "optionsGroupBox"
            Me.optionsGroupBox.Size = New System.Drawing.Size(158, 156)
            Me.optionsGroupBox.TabIndex = 0
            Me.optionsGroupBox.TabStop = False
            Me.optionsGroupBox.Text = "&Options"
            '
            'missingNotCheckedInRadioButton
            '
            Me.missingNotCheckedInRadioButton.AutoSize = True
            Me.missingNotCheckedInRadioButton.Location = New System.Drawing.Point(6, 88)
            Me.missingNotCheckedInRadioButton.Name = "missingNotCheckedInRadioButton"
            Me.missingNotCheckedInRadioButton.Size = New System.Drawing.Size(144, 17)
            Me.missingNotCheckedInRadioButton.TabIndex = 5
            Me.missingNotCheckedInRadioButton.TabStop = True
            Me.missingNotCheckedInRadioButton.Text = "Missing (Not Checked In)"
            Me.missingNotCheckedInRadioButton.UseVisualStyleBackColor = True
            '
            'missingNotPublishedRadioButton
            '
            Me.missingNotPublishedRadioButton.AutoSize = True
            Me.missingNotPublishedRadioButton.Location = New System.Drawing.Point(6, 132)
            Me.missingNotPublishedRadioButton.Name = "missingNotPublishedRadioButton"
            Me.missingNotPublishedRadioButton.Size = New System.Drawing.Size(135, 17)
            Me.missingNotPublishedRadioButton.TabIndex = 4
            Me.missingNotPublishedRadioButton.Text = "Missing (Not Published)"
            Me.missingNotPublishedRadioButton.UseVisualStyleBackColor = True
            '
            'missingNotPulledRadioButton
            '
            Me.missingNotPulledRadioButton.AutoSize = True
            Me.missingNotPulledRadioButton.Location = New System.Drawing.Point(6, 109)
            Me.missingNotPulledRadioButton.Name = "missingNotPulledRadioButton"
            Me.missingNotPulledRadioButton.Size = New System.Drawing.Size(118, 17)
            Me.missingNotPulledRadioButton.TabIndex = 3
            Me.missingNotPulledRadioButton.Text = "Missing (Not Pulled)"
            Me.missingNotPulledRadioButton.UseVisualStyleBackColor = True
            '
            'indexQCRadioButton
            '
            Me.indexQCRadioButton.AutoSize = True
            Me.indexQCRadioButton.Location = New System.Drawing.Point(6, 65)
            Me.indexQCRadioButton.Name = "indexQCRadioButton"
            Me.indexQCRadioButton.Size = New System.Drawing.Size(102, 17)
            Me.indexQCRadioButton.TabIndex = 2
            Me.indexQCRadioButton.Text = "Indexed & QCed"
            Me.indexQCRadioButton.UseMnemonic = False
            Me.indexQCRadioButton.UseVisualStyleBackColor = True
            '
            'pullRadioButton
            '
            Me.pullRadioButton.AutoSize = True
            Me.pullRadioButton.Location = New System.Drawing.Point(6, 42)
            Me.pullRadioButton.Name = "pullRadioButton"
            Me.pullRadioButton.Size = New System.Drawing.Size(42, 17)
            Me.pullRadioButton.TabIndex = 1
            Me.pullRadioButton.Text = "Pull"
            Me.pullRadioButton.UseVisualStyleBackColor = True
            '
            'receivedRadioButton
            '
            Me.receivedRadioButton.AutoSize = True
            Me.receivedRadioButton.Checked = True
            Me.receivedRadioButton.Location = New System.Drawing.Point(6, 19)
            Me.receivedRadioButton.Name = "receivedRadioButton"
            Me.receivedRadioButton.Size = New System.Drawing.Size(71, 17)
            Me.receivedRadioButton.TabIndex = 0
            Me.receivedRadioButton.TabStop = True
            Me.receivedRadioButton.Text = "Received"
            Me.receivedRadioButton.UseVisualStyleBackColor = True
            '
            'filterByGroupBox
            '
            Me.filterByGroupBox.Controls.Add(Me.dayComboBox)
            Me.filterByGroupBox.Controls.Add(Me.yearNumericUpDown)
            Me.filterByGroupBox.Controls.Add(Me.userComboBox)
            Me.filterByGroupBox.Controls.Add(Me.userLabel)
            Me.filterByGroupBox.Controls.Add(Me.yearLabel)
            Me.filterByGroupBox.Controls.Add(Me.dayLabel)
            Me.filterByGroupBox.Controls.Add(Me.monthComboBox)
            Me.filterByGroupBox.Controls.Add(Me.monthLabel)
            Me.filterByGroupBox.Location = New System.Drawing.Point(176, 12)
            Me.filterByGroupBox.Name = "filterByGroupBox"
            Me.filterByGroupBox.Size = New System.Drawing.Size(281, 156)
            Me.filterByGroupBox.TabIndex = 1
            Me.filterByGroupBox.TabStop = False
            Me.filterByGroupBox.Text = "Filter By"
            '
            'dayComboBox
            '
            Me.dayComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.dayComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.dayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.dayComboBox.FormattingEnabled = True
            Me.dayComboBox.Location = New System.Drawing.Point(50, 53)
            Me.dayComboBox.Name = "dayComboBox"
            Me.dayComboBox.Size = New System.Drawing.Size(52, 21)
            Me.dayComboBox.TabIndex = 3
            '
            'yearNumericUpDown
            '
            Me.yearNumericUpDown.Location = New System.Drawing.Point(50, 81)
            Me.yearNumericUpDown.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
            Me.yearNumericUpDown.Minimum = New Decimal(New Integer() {2005, 0, 0, 0})
            Me.yearNumericUpDown.Name = "yearNumericUpDown"
            Me.yearNumericUpDown.Size = New System.Drawing.Size(52, 20)
            Me.yearNumericUpDown.TabIndex = 5
            Me.yearNumericUpDown.Value = New Decimal(New Integer() {2005, 0, 0, 0})
            '
            'userComboBox
            '
            Me.userComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.userComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.userComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.userComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.userComboBox.FormattingEnabled = True
            Me.userComboBox.Location = New System.Drawing.Point(50, 107)
            Me.userComboBox.Name = "userComboBox"
            Me.userComboBox.Size = New System.Drawing.Size(210, 21)
            Me.userComboBox.TabIndex = 7
            '
            'userLabel
            '
            Me.userLabel.AutoSize = True
            Me.userLabel.Location = New System.Drawing.Point(7, 110)
            Me.userLabel.Name = "userLabel"
            Me.userLabel.Size = New System.Drawing.Size(29, 13)
            Me.userLabel.TabIndex = 6
            Me.userLabel.Text = "&User"
            '
            'yearLabel
            '
            Me.yearLabel.AutoSize = True
            Me.yearLabel.Location = New System.Drawing.Point(7, 83)
            Me.yearLabel.Name = "yearLabel"
            Me.yearLabel.Size = New System.Drawing.Size(29, 13)
            Me.yearLabel.TabIndex = 4
            Me.yearLabel.Text = "&Year"
            '
            'dayLabel
            '
            Me.dayLabel.AutoSize = True
            Me.dayLabel.Location = New System.Drawing.Point(7, 56)
            Me.dayLabel.Name = "dayLabel"
            Me.dayLabel.Size = New System.Drawing.Size(26, 13)
            Me.dayLabel.TabIndex = 2
            Me.dayLabel.Text = "&Day"
            '
            'monthComboBox
            '
            Me.monthComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.monthComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.monthComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.monthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.monthComboBox.FormattingEnabled = True
            Me.monthComboBox.Location = New System.Drawing.Point(50, 26)
            Me.monthComboBox.Name = "monthComboBox"
            Me.monthComboBox.Size = New System.Drawing.Size(210, 21)
            Me.monthComboBox.TabIndex = 1
            '
            'monthLabel
            '
            Me.monthLabel.AutoSize = True
            Me.monthLabel.Location = New System.Drawing.Point(7, 29)
            Me.monthLabel.Name = "monthLabel"
            Me.monthLabel.Size = New System.Drawing.Size(37, 13)
            Me.monthLabel.TabIndex = 0
            Me.monthLabel.Text = "&Month"
            '
            'exportButton
            '
            Me.exportButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.exportButton.Location = New System.Drawing.Point(302, 174)
            Me.exportButton.Name = "exportButton"
            Me.exportButton.Size = New System.Drawing.Size(75, 23)
            Me.exportButton.TabIndex = 2
            Me.exportButton.Text = "&Export"
            Me.exportButton.UseVisualStyleBackColor = True
            '
            'closeButton
            '
            Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.closeButton.Location = New System.Drawing.Point(383, 174)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(75, 23)
            Me.closeButton.TabIndex = 3
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'NewspaperLogReportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(470, 209)
            Me.Controls.Add(Me.closeButton)
            Me.Controls.Add(Me.exportButton)
            Me.Controls.Add(Me.filterByGroupBox)
            Me.Controls.Add(Me.optionsGroupBox)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "NewspaperLogReportForm"
            Me.StatusMessage = ""
            Me.Text = "Newspaper Report"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.optionsGroupBox.ResumeLayout(False)
            Me.optionsGroupBox.PerformLayout()
            Me.filterByGroupBox.ResumeLayout(False)
            Me.filterByGroupBox.PerformLayout()
            CType(Me.yearNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents optionsGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents missingNotPublishedRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents missingNotPulledRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents indexQCRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents pullRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents receivedRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents filterByGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents userComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents userLabel As System.Windows.Forms.Label
        Friend WithEvents yearLabel As System.Windows.Forms.Label
        Friend WithEvents dayLabel As System.Windows.Forms.Label
        Friend WithEvents monthComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents monthLabel As System.Windows.Forms.Label
        Friend WithEvents exportButton As System.Windows.Forms.Button
        Friend WithEvents closeButton As System.Windows.Forms.Button
        Friend WithEvents yearNumericUpDown As System.Windows.Forms.NumericUpDown
        Friend WithEvents dayComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents missingNotCheckedInRadioButton As System.Windows.Forms.RadioButton

  End Class

End Namespace