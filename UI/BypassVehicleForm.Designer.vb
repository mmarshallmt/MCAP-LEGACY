Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BypassVehicleForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BypassVehicleForm))
            Me.dateRangeGroupBox = New System.Windows.Forms.GroupBox()
            Me.enddateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.startdateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.endDateLabel = New System.Windows.Forms.Label()
            Me.startDateLabel = New System.Windows.Forms.Label()
            Me.closeButton = New System.Windows.Forms.Button()
            Me.generateReportButton = New System.Windows.Forms.Button()
            Me.outputGroupBox = New System.Windows.Forms.GroupBox()
            Me.excelRadioButton = New System.Windows.Forms.RadioButton()
            Me.screenRadioButton = New System.Windows.Forms.RadioButton()
            Me.locationGroupBox = New System.Windows.Forms.GroupBox()
            Me.locationComboBox = New System.Windows.Forms.ComboBox()
            Me.officeLabel = New System.Windows.Forms.Label()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.dateRangeGroupBox.SuspendLayout()
            Me.outputGroupBox.SuspendLayout()
            Me.locationGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'dateRangeGroupBox
            '
            Me.dateRangeGroupBox.Controls.Add(Me.enddateTypeInDatePicker)
            Me.dateRangeGroupBox.Controls.Add(Me.startdateTypeInDatePicker)
            Me.dateRangeGroupBox.Controls.Add(Me.endDateLabel)
            Me.dateRangeGroupBox.Controls.Add(Me.startDateLabel)
            Me.dateRangeGroupBox.Location = New System.Drawing.Point(2, 12)
            Me.dateRangeGroupBox.Name = "dateRangeGroupBox"
            Me.dateRangeGroupBox.Size = New System.Drawing.Size(328, 78)
            Me.dateRangeGroupBox.TabIndex = 8
            Me.dateRangeGroupBox.TabStop = False
            Me.dateRangeGroupBox.Text = "Date Range"
            '
            'enddateTypeInDatePicker
            '
            Me.enddateTypeInDatePicker.Location = New System.Drawing.Point(220, 47)
            Me.enddateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.enddateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.enddateTypeInDatePicker.Name = "enddateTypeInDatePicker"
            Me.enddateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.enddateTypeInDatePicker.TabIndex = 3
            Me.enddateTypeInDatePicker.Value = Nothing
            '
            'startdateTypeInDatePicker
            '
            Me.startdateTypeInDatePicker.Location = New System.Drawing.Point(220, 19)
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
            Me.endDateLabel.Location = New System.Drawing.Point(120, 56)
            Me.endDateLabel.Name = "endDateLabel"
            Me.endDateLabel.Size = New System.Drawing.Size(98, 13)
            Me.endDateLabel.TabIndex = 2
            Me.endDateLabel.Text = "Checked - To Date"
            '
            'startDateLabel
            '
            Me.startDateLabel.AutoSize = True
            Me.startDateLabel.Location = New System.Drawing.Point(110, 28)
            Me.startDateLabel.Name = "startDateLabel"
            Me.startDateLabel.Size = New System.Drawing.Size(108, 13)
            Me.startDateLabel.TabIndex = 0
            Me.startDateLabel.Text = "Checked - From Date"
            '
            'closeButton
            '
            Me.closeButton.Location = New System.Drawing.Point(222, 205)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(108, 23)
            Me.closeButton.TabIndex = 14
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'generateReportButton
            '
            Me.generateReportButton.Location = New System.Drawing.Point(222, 176)
            Me.generateReportButton.Name = "generateReportButton"
            Me.generateReportButton.Size = New System.Drawing.Size(108, 23)
            Me.generateReportButton.TabIndex = 13
            Me.generateReportButton.Text = "&Generate Report"
            Me.generateReportButton.UseVisualStyleBackColor = True
            '
            'outputGroupBox
            '
            Me.outputGroupBox.Controls.Add(Me.excelRadioButton)
            Me.outputGroupBox.Controls.Add(Me.screenRadioButton)
            Me.outputGroupBox.Location = New System.Drawing.Point(2, 158)
            Me.outputGroupBox.Name = "outputGroupBox"
            Me.outputGroupBox.Size = New System.Drawing.Size(191, 70)
            Me.outputGroupBox.TabIndex = 12
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
            'locationGroupBox
            '
            Me.locationGroupBox.Controls.Add(Me.locationComboBox)
            Me.locationGroupBox.Controls.Add(Me.officeLabel)
            Me.locationGroupBox.Location = New System.Drawing.Point(2, 105)
            Me.locationGroupBox.Name = "locationGroupBox"
            Me.locationGroupBox.Size = New System.Drawing.Size(191, 47)
            Me.locationGroupBox.TabIndex = 10
            Me.locationGroupBox.TabStop = False
            Me.locationGroupBox.Text = "Deivery Location"
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
            'officeLabel
            '
            Me.officeLabel.AutoSize = True
            Me.officeLabel.Location = New System.Drawing.Point(6, 21)
            Me.officeLabel.Name = "officeLabel"
            Me.officeLabel.Size = New System.Drawing.Size(35, 13)
            Me.officeLabel.TabIndex = 0
            Me.officeLabel.Text = "O&ffice"
            '
            'BypassVehicleForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(340, 250)
            Me.Controls.Add(Me.closeButton)
            Me.Controls.Add(Me.generateReportButton)
            Me.Controls.Add(Me.outputGroupBox)
            Me.Controls.Add(Me.locationGroupBox)
            Me.Controls.Add(Me.dateRangeGroupBox)
            Me.Name = "BypassVehicleForm"
            Me.StatusMessage = ""
            Me.Text = "Bypass Vehicles Report"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.dateRangeGroupBox.ResumeLayout(False)
            Me.dateRangeGroupBox.PerformLayout()
            Me.outputGroupBox.ResumeLayout(False)
            Me.outputGroupBox.PerformLayout()
            Me.locationGroupBox.ResumeLayout(False)
            Me.locationGroupBox.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents dateRangeGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents enddateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents startdateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents endDateLabel As System.Windows.Forms.Label
        Friend WithEvents startDateLabel As System.Windows.Forms.Label
        Friend WithEvents closeButton As System.Windows.Forms.Button
        Friend WithEvents generateReportButton As System.Windows.Forms.Button
        Friend WithEvents outputGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents excelRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents screenRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents locationGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents locationComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents officeLabel As System.Windows.Forms.Label
    End Class
End Namespace
