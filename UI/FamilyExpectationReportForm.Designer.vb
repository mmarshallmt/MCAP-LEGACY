Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class FamilyExpectationReportForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FamilyExpectationReportForm))
            Me.breakDateGroupBox = New System.Windows.Forms.GroupBox
            Me.dateRangeRadioButton = New System.Windows.Forms.RadioButton
            Me.weekNoRadioButton = New System.Windows.Forms.RadioButton
            Me.dateRangeGroupBox = New System.Windows.Forms.GroupBox
            Me.enddateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
            Me.startdateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
            Me.endDateLabel = New System.Windows.Forms.Label
            Me.startDateLabel = New System.Windows.Forms.Label
            Me.weekNoGroupBox = New System.Windows.Forms.GroupBox
            Me.endweekNumericUpDown = New System.Windows.Forms.NumericUpDown
            Me.endyearNumericUpDown = New System.Windows.Forms.NumericUpDown
            Me.endLabel = New System.Windows.Forms.Label
            Me.startweekNumericUpDown = New System.Windows.Forms.NumericUpDown
            Me.startyearNumericUpDown = New System.Windows.Forms.NumericUpDown
            Me.startWeekNoLabel = New System.Windows.Forms.Label
            Me.retailerChannelLabel = New System.Windows.Forms.Label
            Me.retailerChannelComboBox = New System.Windows.Forms.ComboBox
            Me.retailerLabel = New System.Windows.Forms.Label
            Me.retailerComboBox = New System.Windows.Forms.ComboBox
            Me.marketComboBox = New System.Windows.Forms.ComboBox
            Me.marketLabel = New System.Windows.Forms.Label
            Me.reportTypeGroupBox = New System.Windows.Forms.GroupBox
            Me.dropExpectationRadioButton = New System.Windows.Forms.RadioButton
            Me.familyExpectationRadioButton = New System.Windows.Forms.RadioButton
            Me.showGroupBox = New System.Windows.Forms.GroupBox
            Me.justMissingRadioButton = New System.Windows.Forms.RadioButton
            Me.allVehiclesRadioButton = New System.Windows.Forms.RadioButton
            Me.frequencyGroupBox = New System.Windows.Forms.GroupBox
            Me.frequency1RadioButton = New System.Windows.Forms.RadioButton
            Me.frequencyDBRadioButton = New System.Windows.Forms.RadioButton
            Me.outputGroupBox = New System.Windows.Forms.GroupBox
            Me.excelRadioButton = New System.Windows.Forms.RadioButton
            Me.screenRadioButton = New System.Windows.Forms.RadioButton
            Me.closeButton = New System.Windows.Forms.Button
            Me.generateReportButton = New System.Windows.Forms.Button
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.breakDateGroupBox.SuspendLayout()
            Me.dateRangeGroupBox.SuspendLayout()
            Me.weekNoGroupBox.SuspendLayout()
            CType(Me.endweekNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.endyearNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.startweekNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.startyearNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.reportTypeGroupBox.SuspendLayout()
            Me.showGroupBox.SuspendLayout()
            Me.frequencyGroupBox.SuspendLayout()
            Me.outputGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'breakDateGroupBox
            '
            Me.breakDateGroupBox.Controls.Add(Me.dateRangeRadioButton)
            Me.breakDateGroupBox.Controls.Add(Me.weekNoRadioButton)
            Me.breakDateGroupBox.Controls.Add(Me.dateRangeGroupBox)
            Me.breakDateGroupBox.Controls.Add(Me.weekNoGroupBox)
            Me.breakDateGroupBox.Location = New System.Drawing.Point(12, 83)
            Me.breakDateGroupBox.Name = "breakDateGroupBox"
            Me.breakDateGroupBox.Size = New System.Drawing.Size(329, 110)
            Me.breakDateGroupBox.TabIndex = 3
            Me.breakDateGroupBox.TabStop = False
            Me.breakDateGroupBox.Text = "Break Date"
            '
            'dateRangeRadioButton
            '
            Me.dateRangeRadioButton.AutoSize = True
            Me.dateRangeRadioButton.Location = New System.Drawing.Point(180, 23)
            Me.dateRangeRadioButton.Name = "dateRangeRadioButton"
            Me.dateRangeRadioButton.Size = New System.Drawing.Size(83, 17)
            Me.dateRangeRadioButton.TabIndex = 2
            Me.dateRangeRadioButton.TabStop = True
            Me.dateRangeRadioButton.Text = "&Date Range"
            Me.dateRangeRadioButton.UseVisualStyleBackColor = True
            '
            'weekNoRadioButton
            '
            Me.weekNoRadioButton.AutoSize = True
            Me.weekNoRadioButton.Checked = True
            Me.weekNoRadioButton.Location = New System.Drawing.Point(15, 23)
            Me.weekNoRadioButton.Name = "weekNoRadioButton"
            Me.weekNoRadioButton.Size = New System.Drawing.Size(94, 17)
            Me.weekNoRadioButton.TabIndex = 0
            Me.weekNoRadioButton.TabStop = True
            Me.weekNoRadioButton.Text = "&Week Number"
            Me.weekNoRadioButton.UseVisualStyleBackColor = True
            '
            'dateRangeGroupBox
            '
            Me.dateRangeGroupBox.Controls.Add(Me.enddateTypeInDatePicker)
            Me.dateRangeGroupBox.Controls.Add(Me.startdateTypeInDatePicker)
            Me.dateRangeGroupBox.Controls.Add(Me.endDateLabel)
            Me.dateRangeGroupBox.Controls.Add(Me.startDateLabel)
            Me.dateRangeGroupBox.Enabled = False
            Me.dateRangeGroupBox.Location = New System.Drawing.Point(174, 25)
            Me.dateRangeGroupBox.Name = "dateRangeGroupBox"
            Me.dateRangeGroupBox.Size = New System.Drawing.Size(147, 78)
            Me.dateRangeGroupBox.TabIndex = 3
            Me.dateRangeGroupBox.TabStop = False
            '
            'enddateTypeInDatePicker
            '
            Me.m_ErrorProvider.SetIconAlignment(Me.enddateTypeInDatePicker, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.enddateTypeInDatePicker.Location = New System.Drawing.Point(69, 50)
            Me.enddateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.enddateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.enddateTypeInDatePicker.Name = "enddateTypeInDatePicker"
            Me.enddateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.enddateTypeInDatePicker.TabIndex = 3
            Me.enddateTypeInDatePicker.Value = Nothing
            '
            'startdateTypeInDatePicker
            '
            Me.m_ErrorProvider.SetIconAlignment(Me.startdateTypeInDatePicker, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.startdateTypeInDatePicker.Location = New System.Drawing.Point(69, 22)
            Me.startdateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.startdateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.startdateTypeInDatePicker.Name = "startdateTypeInDatePicker"
            Me.startdateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.startdateTypeInDatePicker.TabIndex = 1
            Me.startdateTypeInDatePicker.Value = Nothing
            '
            'endDateLabel
            '
            Me.endDateLabel.AutoSize = True
            Me.endDateLabel.Location = New System.Drawing.Point(6, 54)
            Me.endDateLabel.Name = "endDateLabel"
            Me.endDateLabel.Size = New System.Drawing.Size(52, 13)
            Me.endDateLabel.TabIndex = 2
            Me.endDateLabel.Text = "End Date"
            '
            'startDateLabel
            '
            Me.startDateLabel.AutoSize = True
            Me.startDateLabel.Location = New System.Drawing.Point(6, 26)
            Me.startDateLabel.Name = "startDateLabel"
            Me.startDateLabel.Size = New System.Drawing.Size(55, 13)
            Me.startDateLabel.TabIndex = 0
            Me.startDateLabel.Text = "Start Date"
            '
            'weekNoGroupBox
            '
            Me.weekNoGroupBox.Controls.Add(Me.endweekNumericUpDown)
            Me.weekNoGroupBox.Controls.Add(Me.endyearNumericUpDown)
            Me.weekNoGroupBox.Controls.Add(Me.endLabel)
            Me.weekNoGroupBox.Controls.Add(Me.startweekNumericUpDown)
            Me.weekNoGroupBox.Controls.Add(Me.startyearNumericUpDown)
            Me.weekNoGroupBox.Controls.Add(Me.startWeekNoLabel)
            Me.weekNoGroupBox.Location = New System.Drawing.Point(8, 25)
            Me.weekNoGroupBox.Name = "weekNoGroupBox"
            Me.weekNoGroupBox.Size = New System.Drawing.Size(147, 78)
            Me.weekNoGroupBox.TabIndex = 1
            Me.weekNoGroupBox.TabStop = False
            '
            'endweekNumericUpDown
            '
            Me.endweekNumericUpDown.Location = New System.Drawing.Point(104, 51)
            Me.endweekNumericUpDown.Maximum = New Decimal(New Integer() {53, 0, 0, 0})
            Me.endweekNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.endweekNumericUpDown.Name = "endweekNumericUpDown"
            Me.endweekNumericUpDown.Size = New System.Drawing.Size(35, 20)
            Me.endweekNumericUpDown.TabIndex = 5
            Me.endweekNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'endyearNumericUpDown
            '
            Me.endyearNumericUpDown.Location = New System.Drawing.Point(44, 51)
            Me.endyearNumericUpDown.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
            Me.endyearNumericUpDown.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
            Me.endyearNumericUpDown.Name = "endyearNumericUpDown"
            Me.endyearNumericUpDown.Size = New System.Drawing.Size(53, 20)
            Me.endyearNumericUpDown.TabIndex = 4
            Me.endyearNumericUpDown.Value = New Decimal(New Integer() {2000, 0, 0, 0})
            '
            'endLabel
            '
            Me.endLabel.AutoSize = True
            Me.endLabel.Location = New System.Drawing.Point(6, 53)
            Me.endLabel.Name = "endLabel"
            Me.endLabel.Size = New System.Drawing.Size(26, 13)
            Me.endLabel.TabIndex = 3
            Me.endLabel.Text = "End"
            '
            'startweekNumericUpDown
            '
            Me.startweekNumericUpDown.Location = New System.Drawing.Point(104, 25)
            Me.startweekNumericUpDown.Maximum = New Decimal(New Integer() {53, 0, 0, 0})
            Me.startweekNumericUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.startweekNumericUpDown.Name = "startweekNumericUpDown"
            Me.startweekNumericUpDown.Size = New System.Drawing.Size(35, 20)
            Me.startweekNumericUpDown.TabIndex = 2
            Me.startweekNumericUpDown.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'startyearNumericUpDown
            '
            Me.startyearNumericUpDown.Location = New System.Drawing.Point(44, 25)
            Me.startyearNumericUpDown.Maximum = New Decimal(New Integer() {2050, 0, 0, 0})
            Me.startyearNumericUpDown.Minimum = New Decimal(New Integer() {2000, 0, 0, 0})
            Me.startyearNumericUpDown.Name = "startyearNumericUpDown"
            Me.startyearNumericUpDown.Size = New System.Drawing.Size(53, 20)
            Me.startyearNumericUpDown.TabIndex = 1
            Me.startyearNumericUpDown.Value = New Decimal(New Integer() {2000, 0, 0, 0})
            '
            'startWeekNoLabel
            '
            Me.startWeekNoLabel.AutoSize = True
            Me.startWeekNoLabel.Location = New System.Drawing.Point(6, 27)
            Me.startWeekNoLabel.Name = "startWeekNoLabel"
            Me.startWeekNoLabel.Size = New System.Drawing.Size(29, 13)
            Me.startWeekNoLabel.TabIndex = 0
            Me.startWeekNoLabel.Text = "Start"
            '
            'retailerChannelLabel
            '
            Me.retailerChannelLabel.AutoSize = True
            Me.retailerChannelLabel.Location = New System.Drawing.Point(9, 202)
            Me.retailerChannelLabel.Name = "retailerChannelLabel"
            Me.retailerChannelLabel.Size = New System.Drawing.Size(85, 13)
            Me.retailerChannelLabel.TabIndex = 4
            Me.retailerChannelLabel.Text = "Retailer Channel"
            '
            'retailerChannelComboBox
            '
            Me.retailerChannelComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.retailerChannelComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.retailerChannelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.retailerChannelComboBox.FormattingEnabled = True
            Me.retailerChannelComboBox.Location = New System.Drawing.Point(100, 199)
            Me.retailerChannelComboBox.Name = "retailerChannelComboBox"
            Me.retailerChannelComboBox.Size = New System.Drawing.Size(241, 21)
            Me.retailerChannelComboBox.TabIndex = 5
            '
            'retailerLabel
            '
            Me.retailerLabel.AutoSize = True
            Me.retailerLabel.Location = New System.Drawing.Point(9, 229)
            Me.retailerLabel.Name = "retailerLabel"
            Me.retailerLabel.Size = New System.Drawing.Size(43, 13)
            Me.retailerLabel.TabIndex = 6
            Me.retailerLabel.Text = "Retailer"
            '
            'retailerComboBox
            '
            Me.retailerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.retailerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.retailerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.retailerComboBox.FormattingEnabled = True
            Me.retailerComboBox.Location = New System.Drawing.Point(100, 226)
            Me.retailerComboBox.Name = "retailerComboBox"
            Me.retailerComboBox.Size = New System.Drawing.Size(241, 21)
            Me.retailerComboBox.TabIndex = 7
            '
            'marketComboBox
            '
            Me.marketComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.marketComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.marketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.marketComboBox.FormattingEnabled = True
            Me.marketComboBox.Location = New System.Drawing.Point(100, 253)
            Me.marketComboBox.Name = "marketComboBox"
            Me.marketComboBox.Size = New System.Drawing.Size(241, 21)
            Me.marketComboBox.TabIndex = 9
            '
            'marketLabel
            '
            Me.marketLabel.AutoSize = True
            Me.marketLabel.Location = New System.Drawing.Point(9, 256)
            Me.marketLabel.Name = "marketLabel"
            Me.marketLabel.Size = New System.Drawing.Size(40, 13)
            Me.marketLabel.TabIndex = 8
            Me.marketLabel.Text = "Market"
            '
            'reportTypeGroupBox
            '
            Me.reportTypeGroupBox.Controls.Add(Me.dropExpectationRadioButton)
            Me.reportTypeGroupBox.Controls.Add(Me.familyExpectationRadioButton)
            Me.reportTypeGroupBox.Location = New System.Drawing.Point(12, 12)
            Me.reportTypeGroupBox.Name = "reportTypeGroupBox"
            Me.reportTypeGroupBox.Size = New System.Drawing.Size(132, 65)
            Me.reportTypeGroupBox.TabIndex = 0
            Me.reportTypeGroupBox.TabStop = False
            Me.reportTypeGroupBox.Text = "Report Type"
            '
            'dropExpectationRadioButton
            '
            Me.dropExpectationRadioButton.AutoSize = True
            Me.dropExpectationRadioButton.Location = New System.Drawing.Point(6, 42)
            Me.dropExpectationRadioButton.Name = "dropExpectationRadioButton"
            Me.dropExpectationRadioButton.Size = New System.Drawing.Size(107, 17)
            Me.dropExpectationRadioButton.TabIndex = 1
            Me.dropExpectationRadioButton.Text = "Drop Expectation"
            Me.dropExpectationRadioButton.UseVisualStyleBackColor = True
            '
            'familyExpectationRadioButton
            '
            Me.familyExpectationRadioButton.AutoSize = True
            Me.familyExpectationRadioButton.Checked = True
            Me.familyExpectationRadioButton.Location = New System.Drawing.Point(6, 19)
            Me.familyExpectationRadioButton.Name = "familyExpectationRadioButton"
            Me.familyExpectationRadioButton.Size = New System.Drawing.Size(113, 17)
            Me.familyExpectationRadioButton.TabIndex = 0
            Me.familyExpectationRadioButton.TabStop = True
            Me.familyExpectationRadioButton.Text = "Family Expectation"
            Me.familyExpectationRadioButton.UseVisualStyleBackColor = True
            '
            'showGroupBox
            '
            Me.showGroupBox.Controls.Add(Me.justMissingRadioButton)
            Me.showGroupBox.Controls.Add(Me.allVehiclesRadioButton)
            Me.showGroupBox.Location = New System.Drawing.Point(150, 12)
            Me.showGroupBox.Name = "showGroupBox"
            Me.showGroupBox.Size = New System.Drawing.Size(99, 65)
            Me.showGroupBox.TabIndex = 2
            Me.showGroupBox.TabStop = False
            Me.showGroupBox.Text = "Show"
            '
            'justMissingRadioButton
            '
            Me.justMissingRadioButton.AutoSize = True
            Me.justMissingRadioButton.Location = New System.Drawing.Point(6, 42)
            Me.justMissingRadioButton.Name = "justMissingRadioButton"
            Me.justMissingRadioButton.Size = New System.Drawing.Size(82, 17)
            Me.justMissingRadioButton.TabIndex = 1
            Me.justMissingRadioButton.Text = "Just Missing"
            Me.justMissingRadioButton.UseVisualStyleBackColor = True
            '
            'allVehiclesRadioButton
            '
            Me.allVehiclesRadioButton.AutoSize = True
            Me.allVehiclesRadioButton.Checked = True
            Me.allVehiclesRadioButton.Location = New System.Drawing.Point(6, 19)
            Me.allVehiclesRadioButton.Name = "allVehiclesRadioButton"
            Me.allVehiclesRadioButton.Size = New System.Drawing.Size(79, 17)
            Me.allVehiclesRadioButton.TabIndex = 0
            Me.allVehiclesRadioButton.TabStop = True
            Me.allVehiclesRadioButton.Text = "All Vehicles"
            Me.allVehiclesRadioButton.UseVisualStyleBackColor = True
            '
            'frequencyGroupBox
            '
            Me.frequencyGroupBox.Controls.Add(Me.frequency1RadioButton)
            Me.frequencyGroupBox.Controls.Add(Me.frequencyDBRadioButton)
            Me.frequencyGroupBox.Location = New System.Drawing.Point(150, 12)
            Me.frequencyGroupBox.Name = "frequencyGroupBox"
            Me.frequencyGroupBox.Size = New System.Drawing.Size(191, 65)
            Me.frequencyGroupBox.TabIndex = 1
            Me.frequencyGroupBox.TabStop = False
            Me.frequencyGroupBox.Text = "Frequency"
            Me.frequencyGroupBox.Visible = False
            '
            'frequency1RadioButton
            '
            Me.frequency1RadioButton.AutoSize = True
            Me.frequency1RadioButton.Location = New System.Drawing.Point(6, 42)
            Me.frequency1RadioButton.Name = "frequency1RadioButton"
            Me.frequency1RadioButton.Size = New System.Drawing.Size(108, 17)
            Me.frequency1RadioButton.TabIndex = 1
            Me.frequency1RadioButton.Text = "Force 1 per week"
            Me.frequency1RadioButton.UseVisualStyleBackColor = True
            '
            'frequencyDBRadioButton
            '
            Me.frequencyDBRadioButton.AutoSize = True
            Me.frequencyDBRadioButton.Checked = True
            Me.frequencyDBRadioButton.Location = New System.Drawing.Point(6, 19)
            Me.frequencyDBRadioButton.Name = "frequencyDBRadioButton"
            Me.frequencyDBRadioButton.Size = New System.Drawing.Size(177, 17)
            Me.frequencyDBRadioButton.TabIndex = 0
            Me.frequencyDBRadioButton.TabStop = True
            Me.frequencyDBRadioButton.Text = "Using frequency set in database"
            Me.frequencyDBRadioButton.UseVisualStyleBackColor = True
            '
            'outputGroupBox
            '
            Me.outputGroupBox.Controls.Add(Me.excelRadioButton)
            Me.outputGroupBox.Controls.Add(Me.screenRadioButton)
            Me.outputGroupBox.Location = New System.Drawing.Point(12, 280)
            Me.outputGroupBox.Name = "outputGroupBox"
            Me.outputGroupBox.Size = New System.Drawing.Size(191, 70)
            Me.outputGroupBox.TabIndex = 10
            Me.outputGroupBox.TabStop = False
            Me.outputGroupBox.Text = "Output"
            '
            'excelRadioButton
            '
            Me.excelRadioButton.AutoSize = True
            Me.excelRadioButton.Location = New System.Drawing.Point(7, 44)
            Me.excelRadioButton.Name = "excelRadioButton"
            Me.excelRadioButton.Size = New System.Drawing.Size(172, 17)
            Me.excelRadioButton.TabIndex = 1
            Me.excelRadioButton.TabStop = True
            Me.excelRadioButton.Text = "Show result in &excel workbook."
            Me.excelRadioButton.UseVisualStyleBackColor = True
            '
            'screenRadioButton
            '
            Me.screenRadioButton.AutoSize = True
            Me.screenRadioButton.Checked = True
            Me.screenRadioButton.Location = New System.Drawing.Point(7, 20)
            Me.screenRadioButton.Name = "screenRadioButton"
            Me.screenRadioButton.Size = New System.Drawing.Size(133, 17)
            Me.screenRadioButton.TabIndex = 0
            Me.screenRadioButton.TabStop = True
            Me.screenRadioButton.Text = "Show result on &screen."
            Me.screenRadioButton.UseVisualStyleBackColor = True
            '
            'closeButton
            '
            Me.closeButton.Location = New System.Drawing.Point(233, 327)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(108, 23)
            Me.closeButton.TabIndex = 12
            Me.closeButton.Text = "Close"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'generateReportButton
            '
            Me.generateReportButton.Location = New System.Drawing.Point(233, 298)
            Me.generateReportButton.Name = "generateReportButton"
            Me.generateReportButton.Size = New System.Drawing.Size(108, 23)
            Me.generateReportButton.TabIndex = 11
            Me.generateReportButton.Text = "Generate Report"
            Me.generateReportButton.UseVisualStyleBackColor = True
            '
            'FamilyExpectationReportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(355, 362)
            Me.Controls.Add(Me.closeButton)
            Me.Controls.Add(Me.generateReportButton)
            Me.Controls.Add(Me.frequencyGroupBox)
            Me.Controls.Add(Me.outputGroupBox)
            Me.Controls.Add(Me.showGroupBox)
            Me.Controls.Add(Me.reportTypeGroupBox)
            Me.Controls.Add(Me.marketComboBox)
            Me.Controls.Add(Me.marketLabel)
            Me.Controls.Add(Me.retailerComboBox)
            Me.Controls.Add(Me.retailerLabel)
            Me.Controls.Add(Me.retailerChannelComboBox)
            Me.Controls.Add(Me.retailerChannelLabel)
            Me.Controls.Add(Me.breakDateGroupBox)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FamilyExpectationReportForm"
            Me.StatusMessage = ""
            Me.Text = "Family Expectation / Drop Expectation Report"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.breakDateGroupBox.ResumeLayout(False)
            Me.breakDateGroupBox.PerformLayout()
            Me.dateRangeGroupBox.ResumeLayout(False)
            Me.dateRangeGroupBox.PerformLayout()
            Me.weekNoGroupBox.ResumeLayout(False)
            Me.weekNoGroupBox.PerformLayout()
            CType(Me.endweekNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.endyearNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.startweekNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.startyearNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.reportTypeGroupBox.ResumeLayout(False)
            Me.reportTypeGroupBox.PerformLayout()
            Me.showGroupBox.ResumeLayout(False)
            Me.showGroupBox.PerformLayout()
            Me.frequencyGroupBox.ResumeLayout(False)
            Me.frequencyGroupBox.PerformLayout()
            Me.outputGroupBox.ResumeLayout(False)
            Me.outputGroupBox.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
    Friend WithEvents breakDateGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents dateRangeRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents weekNoRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents dateRangeGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents enddateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
    Friend WithEvents startdateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
    Friend WithEvents endDateLabel As System.Windows.Forms.Label
    Friend WithEvents startDateLabel As System.Windows.Forms.Label
    Friend WithEvents weekNoGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents endweekNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents endyearNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents endLabel As System.Windows.Forms.Label
    Friend WithEvents startweekNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents startyearNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents startWeekNoLabel As System.Windows.Forms.Label
    Friend WithEvents retailerChannelLabel As System.Windows.Forms.Label
    Friend WithEvents retailerChannelComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents retailerLabel As System.Windows.Forms.Label
    Friend WithEvents retailerComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents marketComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents marketLabel As System.Windows.Forms.Label
    Friend WithEvents reportTypeGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents dropExpectationRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents familyExpectationRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents showGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents justMissingRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents allVehiclesRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents frequencyGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents frequency1RadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents frequencyDBRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents outputGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents excelRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents screenRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents generateReportButton As System.Windows.Forms.Button

  End Class

End Namespace
