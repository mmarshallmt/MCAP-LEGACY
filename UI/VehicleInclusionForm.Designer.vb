﻿Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class VehicleInclusionForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VehicleInclusionForm))
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
            Me.outputGroupBox = New System.Windows.Forms.GroupBox
            Me.excelRadioButton = New System.Windows.Forms.RadioButton
            Me.screenRadioButton = New System.Windows.Forms.RadioButton
            Me.closeButton = New System.Windows.Forms.Button
            Me.generateReportButton = New System.Windows.Forms.Button
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.locationComboBox = New System.Windows.Forms.ComboBox
            Me.Label1 = New System.Windows.Forms.Label
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.breakDateGroupBox.SuspendLayout()
            Me.dateRangeGroupBox.SuspendLayout()
            Me.weekNoGroupBox.SuspendLayout()
            CType(Me.endweekNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.endyearNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.startweekNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.startyearNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.outputGroupBox.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
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
            Me.breakDateGroupBox.Location = New System.Drawing.Point(12, 12)
            Me.breakDateGroupBox.Name = "breakDateGroupBox"
            Me.breakDateGroupBox.Size = New System.Drawing.Size(329, 110)
            Me.breakDateGroupBox.TabIndex = 1
            Me.breakDateGroupBox.TabStop = False
            Me.breakDateGroupBox.Text = "Received Date"
            '
            'dateRangeRadioButton
            '
            Me.dateRangeRadioButton.AutoSize = True
            Me.dateRangeRadioButton.Location = New System.Drawing.Point(182, 22)
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
            Me.weekNoRadioButton.Location = New System.Drawing.Point(12, 22)
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
            Me.dateRangeGroupBox.Location = New System.Drawing.Point(176, 26)
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
            Me.weekNoGroupBox.Location = New System.Drawing.Point(6, 26)
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
            'outputGroupBox
            '
            Me.outputGroupBox.Controls.Add(Me.excelRadioButton)
            Me.outputGroupBox.Controls.Add(Me.screenRadioButton)
            Me.outputGroupBox.Location = New System.Drawing.Point(12, 182)
            Me.outputGroupBox.Name = "outputGroupBox"
            Me.outputGroupBox.Size = New System.Drawing.Size(191, 70)
            Me.outputGroupBox.TabIndex = 2
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
            Me.closeButton.Location = New System.Drawing.Point(232, 227)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(108, 23)
            Me.closeButton.TabIndex = 4
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'generateReportButton
            '
            Me.generateReportButton.Location = New System.Drawing.Point(232, 198)
            Me.generateReportButton.Name = "generateReportButton"
            Me.generateReportButton.Size = New System.Drawing.Size(108, 23)
            Me.generateReportButton.TabIndex = 3
            Me.generateReportButton.Text = "&Generate Report"
            Me.generateReportButton.UseVisualStyleBackColor = True
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.locationComboBox)
            Me.GroupBox1.Controls.Add(Me.Label1)
            Me.GroupBox1.Location = New System.Drawing.Point(12, 129)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(191, 47)
            Me.GroupBox1.TabIndex = 5
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Delivery Location"
            '
            'locationComboBox
            '
            Me.locationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.locationComboBox.FormattingEnabled = True
            Me.locationComboBox.Location = New System.Drawing.Point(51, 18)
            Me.locationComboBox.Name = "locationComboBox"
            Me.locationComboBox.Size = New System.Drawing.Size(128, 21)
            Me.locationComboBox.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(13, 22)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(35, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Office"
            '
            'VehicleInclusionForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(353, 262)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.closeButton)
            Me.Controls.Add(Me.generateReportButton)
            Me.Controls.Add(Me.outputGroupBox)
            Me.Controls.Add(Me.breakDateGroupBox)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "VehicleInclusionForm"
            Me.StatusMessage = ""
            Me.Text = "Vehicle Inclusion Report"
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
            Me.outputGroupBox.ResumeLayout(False)
            Me.outputGroupBox.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.ResumeLayout(False)

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
    Friend WithEvents outputGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents excelRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents screenRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents generateReportButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents locationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

  End Class

End Namespace