Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SendernotmatchingImport
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.reportTypeGroupBox = New System.Windows.Forms.GroupBox()
            Me.MediaTypeComboBox = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.PhaseTypeComboBox = New System.Windows.Forms.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.MTMktComboBox = New System.Windows.Forms.ComboBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.MTRetComboBox = New System.Windows.Forms.ComboBox()
            Me.dateRangeGroupBox = New System.Windows.Forms.GroupBox()
            Me.enddateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.startdateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.endDateLabel = New System.Windows.Forms.Label()
            Me.startDateLabel = New System.Windows.Forms.Label()
            Me.outputGroupBox = New System.Windows.Forms.GroupBox()
            Me.excelRadioButton = New System.Windows.Forms.RadioButton()
            Me.screenRadioButton = New System.Windows.Forms.RadioButton()
            Me.closeButton = New System.Windows.Forms.Button()
            Me.generateReportButton = New System.Windows.Forms.Button()
            Me.reportTypeGroupBox.SuspendLayout()
            Me.dateRangeGroupBox.SuspendLayout()
            Me.outputGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'reportTypeGroupBox
            '
            Me.reportTypeGroupBox.Controls.Add(Me.MediaTypeComboBox)
            Me.reportTypeGroupBox.Controls.Add(Me.Label1)
            Me.reportTypeGroupBox.Controls.Add(Me.PhaseTypeComboBox)
            Me.reportTypeGroupBox.Controls.Add(Me.Label2)
            Me.reportTypeGroupBox.Controls.Add(Me.MTMktComboBox)
            Me.reportTypeGroupBox.Controls.Add(Me.Label3)
            Me.reportTypeGroupBox.Location = New System.Drawing.Point(364, 12)
            Me.reportTypeGroupBox.Name = "reportTypeGroupBox"
            Me.reportTypeGroupBox.Size = New System.Drawing.Size(62, 27)
            Me.reportTypeGroupBox.TabIndex = 1
            Me.reportTypeGroupBox.TabStop = False
            Me.reportTypeGroupBox.Text = "Report Type"
            Me.reportTypeGroupBox.Visible = False
            '
            'MediaTypeComboBox
            '
            Me.MediaTypeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.MediaTypeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.MediaTypeComboBox.FormattingEnabled = True
            Me.MediaTypeComboBox.Location = New System.Drawing.Point(85, 108)
            Me.MediaTypeComboBox.Name = "MediaTypeComboBox"
            Me.MediaTypeComboBox.Size = New System.Drawing.Size(191, 21)
            Me.MediaTypeComboBox.TabIndex = 16
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(6, 111)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(63, 13)
            Me.Label1.TabIndex = 15
            Me.Label1.Text = "Media Type"
            '
            'PhaseTypeComboBox
            '
            Me.PhaseTypeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.PhaseTypeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.PhaseTypeComboBox.FormattingEnabled = True
            Me.PhaseTypeComboBox.Location = New System.Drawing.Point(85, 81)
            Me.PhaseTypeComboBox.Name = "PhaseTypeComboBox"
            Me.PhaseTypeComboBox.Size = New System.Drawing.Size(191, 21)
            Me.PhaseTypeComboBox.TabIndex = 14
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(6, 84)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(63, 13)
            Me.Label2.TabIndex = 13
            Me.Label2.Text = "Import Type"
            '
            'MTMktComboBox
            '
            Me.MTMktComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.MTMktComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.MTMktComboBox.FormattingEnabled = True
            Me.MTMktComboBox.Location = New System.Drawing.Point(85, 49)
            Me.MTMktComboBox.Name = "MTMktComboBox"
            Me.MTMktComboBox.Size = New System.Drawing.Size(191, 21)
            Me.MTMktComboBox.TabIndex = 10
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(6, 55)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(59, 13)
            Me.Label3.TabIndex = 8
            Me.Label3.Text = "MT Market"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(18, 75)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(62, 13)
            Me.Label4.TabIndex = 7
            Me.Label4.Text = "MT Retailer"
            '
            'MTRetComboBox
            '
            Me.MTRetComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
            Me.MTRetComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.MTRetComboBox.FormattingEnabled = True
            Me.MTRetComboBox.Location = New System.Drawing.Point(81, 72)
            Me.MTRetComboBox.Name = "MTRetComboBox"
            Me.MTRetComboBox.Size = New System.Drawing.Size(191, 21)
            Me.MTRetComboBox.TabIndex = 9
            '
            'dateRangeGroupBox
            '
            Me.dateRangeGroupBox.Controls.Add(Me.enddateTypeInDatePicker)
            Me.dateRangeGroupBox.Controls.Add(Me.startdateTypeInDatePicker)
            Me.dateRangeGroupBox.Controls.Add(Me.endDateLabel)
            Me.dateRangeGroupBox.Controls.Add(Me.startDateLabel)
            Me.dateRangeGroupBox.Location = New System.Drawing.Point(12, 12)
            Me.dateRangeGroupBox.Name = "dateRangeGroupBox"
            Me.dateRangeGroupBox.Size = New System.Drawing.Size(328, 57)
            Me.dateRangeGroupBox.TabIndex = 2
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
            'outputGroupBox
            '
            Me.outputGroupBox.Controls.Add(Me.excelRadioButton)
            Me.outputGroupBox.Controls.Add(Me.screenRadioButton)
            Me.outputGroupBox.Location = New System.Drawing.Point(12, 108)
            Me.outputGroupBox.Name = "outputGroupBox"
            Me.outputGroupBox.Size = New System.Drawing.Size(191, 70)
            Me.outputGroupBox.TabIndex = 5
            Me.outputGroupBox.TabStop = False
            Me.outputGroupBox.Text = "Output"
            '
            'excelRadioButton
            '
            Me.excelRadioButton.AutoSize = True
            Me.excelRadioButton.Checked = True
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
            Me.screenRadioButton.Location = New System.Drawing.Point(7, 20)
            Me.screenRadioButton.Name = "screenRadioButton"
            Me.screenRadioButton.Size = New System.Drawing.Size(133, 17)
            Me.screenRadioButton.TabIndex = 0
            Me.screenRadioButton.Text = "Show result on &screen."
            Me.screenRadioButton.UseVisualStyleBackColor = True
            '
            'closeButton
            '
            Me.closeButton.Location = New System.Drawing.Point(232, 154)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(108, 23)
            Me.closeButton.TabIndex = 8
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'generateReportButton
            '
            Me.generateReportButton.Location = New System.Drawing.Point(232, 125)
            Me.generateReportButton.Name = "generateReportButton"
            Me.generateReportButton.Size = New System.Drawing.Size(108, 23)
            Me.generateReportButton.TabIndex = 7
            Me.generateReportButton.Text = "&Generate Report"
            Me.generateReportButton.UseVisualStyleBackColor = True
            '
            'SendernotmatchingImport
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(357, 199)
            Me.Controls.Add(Me.closeButton)
            Me.Controls.Add(Me.generateReportButton)
            Me.Controls.Add(Me.outputGroupBox)
            Me.Controls.Add(Me.dateRangeGroupBox)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.MTRetComboBox)
            Me.Controls.Add(Me.reportTypeGroupBox)
            Me.Name = "SendernotmatchingImport"
            Me.Text = "Senders Not matching Import Type"
            Me.reportTypeGroupBox.ResumeLayout(False)
            Me.reportTypeGroupBox.PerformLayout()
            Me.dateRangeGroupBox.ResumeLayout(False)
            Me.dateRangeGroupBox.PerformLayout()
            Me.outputGroupBox.ResumeLayout(False)
            Me.outputGroupBox.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        Friend WithEvents reportTypeGroupBox As GroupBox
        Friend WithEvents dateRangeGroupBox As GroupBox
        Friend WithEvents enddateTypeInDatePicker As UI.Controls.TypeInDatePicker
        Friend WithEvents startdateTypeInDatePicker As UI.Controls.TypeInDatePicker
        Friend WithEvents endDateLabel As Label
        Friend WithEvents startDateLabel As Label
        Friend WithEvents outputGroupBox As GroupBox
        Friend WithEvents excelRadioButton As RadioButton
        Friend WithEvents screenRadioButton As RadioButton
        Friend WithEvents closeButton As Button
        Friend WithEvents generateReportButton As Button
        Friend WithEvents MTMktComboBox As ComboBox
        Friend WithEvents Label4 As Label
        Friend WithEvents Label3 As Label
        Friend WithEvents MTRetComboBox As ComboBox
        Friend WithEvents PhaseTypeComboBox As ComboBox
        Friend WithEvents Label2 As Label
        Friend WithEvents MediaTypeComboBox As ComboBox
        Friend WithEvents Label1 As Label
    End Class
End Namespace
