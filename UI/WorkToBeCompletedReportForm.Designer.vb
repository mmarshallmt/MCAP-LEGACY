Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class WorkToBeCompletedReportForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WorkToBeCompletedReportForm))
            Me.reportTypeGroupBox = New System.Windows.Forms.GroupBox()
            Me.reportComboBox = New System.Windows.Forms.ComboBox()
            Me.reportLabel = New System.Windows.Forms.Label()
            Me.dateRangeGroupBox = New System.Windows.Forms.GroupBox()
            Me.enddateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.startdateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.endDateLabel = New System.Windows.Forms.Label()
            Me.startDateLabel = New System.Windows.Forms.Label()
            Me.locationGroupBox = New System.Windows.Forms.GroupBox()
            Me.locationComboBox = New System.Windows.Forms.ComboBox()
            Me.officeLabel = New System.Windows.Forms.Label()
            Me.closeButton = New System.Windows.Forms.Button()
            Me.generateReportButton = New System.Windows.Forms.Button()
            Me.outputGroupBox = New System.Windows.Forms.GroupBox()
            Me.excelRadioButton = New System.Windows.Forms.RadioButton()
            Me.screenRadioButton = New System.Windows.Forms.RadioButton()
            Me.priorityGroupBox = New System.Windows.Forms.GroupBox()
            Me.priorityComboBox = New System.Windows.Forms.ComboBox()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.TradeclassComboBox = New System.Windows.Forms.ComboBox()
            Me.CoverageGroupBox = New System.Windows.Forms.GroupBox()
            Me.CoverageComboBox = New System.Windows.Forms.ComboBox()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.reportTypeGroupBox.SuspendLayout()
            Me.dateRangeGroupBox.SuspendLayout()
            Me.locationGroupBox.SuspendLayout()
            Me.outputGroupBox.SuspendLayout()
            Me.priorityGroupBox.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.CoverageGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'reportTypeGroupBox
            '
            Me.reportTypeGroupBox.Controls.Add(Me.reportComboBox)
            Me.reportTypeGroupBox.Controls.Add(Me.reportLabel)
            Me.reportTypeGroupBox.Location = New System.Drawing.Point(12, 12)
            Me.reportTypeGroupBox.Name = "reportTypeGroupBox"
            Me.reportTypeGroupBox.Size = New System.Drawing.Size(328, 49)
            Me.reportTypeGroupBox.TabIndex = 0
            Me.reportTypeGroupBox.TabStop = False
            Me.reportTypeGroupBox.Text = "Report Type"
            '
            'reportComboBox
            '
            Me.reportComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.reportComboBox.FormattingEnabled = True
            Me.reportComboBox.Items.AddRange(New Object() {"Envelopes with no Vehicles ", "Vehicles Waiting for Indexing ", "Vehicles Waiting for Scanning ", "Vehicles Waiting for QC ", "Vehicles Waiting for SP Review ", "Vehicles Waiting for Simr", "Newspapers Waiting for Pulling ", "Newspapers Waiting for Scanning ", "Newspapers Waiting for Scanning - No Ads", "Newspapers Wating for Indexing ", "Newspapers Indexing in Progress ", "Newspapers Waiting for QC", "Family Review Waiting for Routing", "Family Review Type and Distribution", "Family Review not locked"})
            Me.reportComboBox.Location = New System.Drawing.Point(51, 20)
            Me.reportComboBox.Name = "reportComboBox"
            Me.reportComboBox.Size = New System.Drawing.Size(271, 21)
            Me.reportComboBox.TabIndex = 1
            '
            'reportLabel
            '
            Me.reportLabel.AutoSize = True
            Me.reportLabel.Location = New System.Drawing.Point(6, 23)
            Me.reportLabel.Name = "reportLabel"
            Me.reportLabel.Size = New System.Drawing.Size(39, 13)
            Me.reportLabel.TabIndex = 0
            Me.reportLabel.Text = "&Report"
            '
            'dateRangeGroupBox
            '
            Me.dateRangeGroupBox.Controls.Add(Me.enddateTypeInDatePicker)
            Me.dateRangeGroupBox.Controls.Add(Me.startdateTypeInDatePicker)
            Me.dateRangeGroupBox.Controls.Add(Me.endDateLabel)
            Me.dateRangeGroupBox.Controls.Add(Me.startDateLabel)
            Me.dateRangeGroupBox.Location = New System.Drawing.Point(12, 67)
            Me.dateRangeGroupBox.Name = "dateRangeGroupBox"
            Me.dateRangeGroupBox.Size = New System.Drawing.Size(328, 49)
            Me.dateRangeGroupBox.TabIndex = 1
            Me.dateRangeGroupBox.TabStop = False
            Me.dateRangeGroupBox.Text = "Date Range"
            '
            'enddateTypeInDatePicker
            '
            Me.enddateTypeInDatePicker.Location = New System.Drawing.Point(250, 22)
            Me.enddateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.enddateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.enddateTypeInDatePicker.Name = "enddateTypeInDatePicker"
            Me.enddateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.enddateTypeInDatePicker.TabIndex = 3
            Me.enddateTypeInDatePicker.Value = Nothing
            '
            'startdateTypeInDatePicker
            '
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
            Me.endDateLabel.Location = New System.Drawing.Point(187, 26)
            Me.endDateLabel.Name = "endDateLabel"
            Me.endDateLabel.Size = New System.Drawing.Size(52, 13)
            Me.endDateLabel.TabIndex = 2
            Me.endDateLabel.Text = "E&nd Date"
            '
            'startDateLabel
            '
            Me.startDateLabel.AutoSize = True
            Me.startDateLabel.Location = New System.Drawing.Point(6, 26)
            Me.startDateLabel.Name = "startDateLabel"
            Me.startDateLabel.Size = New System.Drawing.Size(55, 13)
            Me.startDateLabel.TabIndex = 0
            Me.startDateLabel.Text = "S&tart Date"
            '
            'locationGroupBox
            '
            Me.locationGroupBox.Controls.Add(Me.locationComboBox)
            Me.locationGroupBox.Controls.Add(Me.officeLabel)
            Me.locationGroupBox.Location = New System.Drawing.Point(12, 175)
            Me.locationGroupBox.Name = "locationGroupBox"
            Me.locationGroupBox.Size = New System.Drawing.Size(191, 47)
            Me.locationGroupBox.TabIndex = 2
            Me.locationGroupBox.TabStop = False
            Me.locationGroupBox.Text = "Location"
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
            'closeButton
            '
            Me.closeButton.Location = New System.Drawing.Point(232, 275)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(108, 23)
            Me.closeButton.TabIndex = 6
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'generateReportButton
            '
            Me.generateReportButton.Location = New System.Drawing.Point(232, 246)
            Me.generateReportButton.Name = "generateReportButton"
            Me.generateReportButton.Size = New System.Drawing.Size(108, 23)
            Me.generateReportButton.TabIndex = 5
            Me.generateReportButton.Text = "&Generate Report"
            Me.generateReportButton.UseVisualStyleBackColor = True
            '
            'outputGroupBox
            '
            Me.outputGroupBox.Controls.Add(Me.excelRadioButton)
            Me.outputGroupBox.Controls.Add(Me.screenRadioButton)
            Me.outputGroupBox.Location = New System.Drawing.Point(12, 228)
            Me.outputGroupBox.Name = "outputGroupBox"
            Me.outputGroupBox.Size = New System.Drawing.Size(191, 70)
            Me.outputGroupBox.TabIndex = 4
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
            'priorityGroupBox
            '
            Me.priorityGroupBox.Controls.Add(Me.priorityComboBox)
            Me.priorityGroupBox.Location = New System.Drawing.Point(209, 175)
            Me.priorityGroupBox.Name = "priorityGroupBox"
            Me.priorityGroupBox.Size = New System.Drawing.Size(131, 47)
            Me.priorityGroupBox.TabIndex = 3
            Me.priorityGroupBox.TabStop = False
            Me.priorityGroupBox.Text = "Priority"
            '
            'priorityComboBox
            '
            Me.priorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.priorityComboBox.FormattingEnabled = True
            Me.priorityComboBox.Location = New System.Drawing.Point(6, 18)
            Me.priorityComboBox.Name = "priorityComboBox"
            Me.priorityComboBox.Size = New System.Drawing.Size(119, 21)
            Me.priorityComboBox.TabIndex = 0
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.TradeclassComboBox)
            Me.GroupBox1.Location = New System.Drawing.Point(12, 122)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(191, 47)
            Me.GroupBox1.TabIndex = 7
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Tradeclass"
            '
            'TradeclassComboBox
            '
            Me.TradeclassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.TradeclassComboBox.FormattingEnabled = True
            Me.TradeclassComboBox.Location = New System.Drawing.Point(51, 18)
            Me.TradeclassComboBox.Name = "TradeclassComboBox"
            Me.TradeclassComboBox.Size = New System.Drawing.Size(128, 21)
            Me.TradeclassComboBox.TabIndex = 0
            '
            'CoverageGroupBox
            '
            Me.CoverageGroupBox.Controls.Add(Me.CoverageComboBox)
            Me.CoverageGroupBox.Location = New System.Drawing.Point(209, 122)
            Me.CoverageGroupBox.Name = "CoverageGroupBox"
            Me.CoverageGroupBox.Size = New System.Drawing.Size(131, 47)
            Me.CoverageGroupBox.TabIndex = 8
            Me.CoverageGroupBox.TabStop = False
            Me.CoverageGroupBox.Text = "Coverage"
            Me.CoverageGroupBox.Visible = False
            '
            'CoverageComboBox
            '
            Me.CoverageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CoverageComboBox.FormattingEnabled = True
            Me.CoverageComboBox.Location = New System.Drawing.Point(6, 18)
            Me.CoverageComboBox.Name = "CoverageComboBox"
            Me.CoverageComboBox.Size = New System.Drawing.Size(119, 21)
            Me.CoverageComboBox.TabIndex = 0
            '
            'WorkToBeCompletedReportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(352, 306)
            Me.Controls.Add(Me.CoverageGroupBox)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.priorityGroupBox)
            Me.Controls.Add(Me.closeButton)
            Me.Controls.Add(Me.generateReportButton)
            Me.Controls.Add(Me.outputGroupBox)
            Me.Controls.Add(Me.locationGroupBox)
            Me.Controls.Add(Me.dateRangeGroupBox)
            Me.Controls.Add(Me.reportTypeGroupBox)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "WorkToBeCompletedReportForm"
            Me.StatusMessage = ""
            Me.Text = "Work To Be Completed Reports"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.reportTypeGroupBox.ResumeLayout(False)
            Me.reportTypeGroupBox.PerformLayout()
            Me.dateRangeGroupBox.ResumeLayout(False)
            Me.dateRangeGroupBox.PerformLayout()
            Me.locationGroupBox.ResumeLayout(False)
            Me.locationGroupBox.PerformLayout()
            Me.outputGroupBox.ResumeLayout(False)
            Me.outputGroupBox.PerformLayout()
            Me.priorityGroupBox.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.CoverageGroupBox.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents reportTypeGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents reportComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents reportLabel As System.Windows.Forms.Label
        Friend WithEvents dateRangeGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents enddateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents startdateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents endDateLabel As System.Windows.Forms.Label
        Friend WithEvents startDateLabel As System.Windows.Forms.Label
        Friend WithEvents locationGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents locationComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents officeLabel As System.Windows.Forms.Label
        Friend WithEvents closeButton As System.Windows.Forms.Button
        Friend WithEvents generateReportButton As System.Windows.Forms.Button
        Friend WithEvents outputGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents excelRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents screenRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents priorityGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents priorityComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents TradeclassComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents CoverageGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents CoverageComboBox As System.Windows.Forms.ComboBox

    End Class

End Namespace