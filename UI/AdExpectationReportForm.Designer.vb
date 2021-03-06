﻿Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AdExpectationReportForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdExpectationReportForm))
            Me.reportTypeGroupBox = New System.Windows.Forms.GroupBox
            Me.notreceivedRadioButton = New System.Windows.Forms.RadioButton
            Me.receivedRadioButton = New System.Windows.Forms.RadioButton
            Me.breakDateGroupBox = New System.Windows.Forms.GroupBox
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.thisWeekRadioButton = New System.Windows.Forms.RadioButton
            Me.todayRadioButton = New System.Windows.Forms.RadioButton
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
            Me.marketComboBox = New System.Windows.Forms.ComboBox
            Me.senderComboBox = New System.Windows.Forms.ComboBox
            Me.Label2 = New System.Windows.Forms.Label
            Me.Label3 = New System.Windows.Forms.Label
            Me.TableAdapterManager1 = New MCAP.CodeDataSetTableAdapters.TableAdapterManager
            Me.priorityComboBox = New System.Windows.Forms.ComboBox
            Me.Label4 = New System.Windows.Forms.Label
            Me.entryProjectComboBox = New System.Windows.Forms.ComboBox
            Me.Label5 = New System.Windows.Forms.Label
            Me.Label6 = New System.Windows.Forms.Label
            Me.mediaComboBox = New System.Windows.Forms.ComboBox
            Me.Label7 = New System.Windows.Forms.Label
            Me.frequencyComboBox = New System.Windows.Forms.ComboBox
            Me.GroupBox2 = New System.Windows.Forms.GroupBox
            Me.AllStatusRadioButton = New System.Windows.Forms.RadioButton
            Me.InProcessRadioButton = New System.Windows.Forms.RadioButton
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.reportTypeGroupBox.SuspendLayout()
            Me.breakDateGroupBox.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.dateRangeGroupBox.SuspendLayout()
            Me.weekNoGroupBox.SuspendLayout()
            CType(Me.endweekNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.endyearNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.startweekNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.startyearNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.outputGroupBox.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
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
            Me.reportTypeGroupBox.Controls.Add(Me.notreceivedRadioButton)
            Me.reportTypeGroupBox.Controls.Add(Me.receivedRadioButton)
            Me.reportTypeGroupBox.Location = New System.Drawing.Point(12, 12)
            Me.reportTypeGroupBox.Name = "reportTypeGroupBox"
            Me.reportTypeGroupBox.Size = New System.Drawing.Size(329, 39)
            Me.reportTypeGroupBox.TabIndex = 0
            Me.reportTypeGroupBox.TabStop = False
            Me.reportTypeGroupBox.Text = "Report Type"
            '
            'notreceivedRadioButton
            '
            Me.notreceivedRadioButton.AutoSize = True
            Me.notreceivedRadioButton.Location = New System.Drawing.Point(174, 18)
            Me.notreceivedRadioButton.Name = "notreceivedRadioButton"
            Me.notreceivedRadioButton.Size = New System.Drawing.Size(112, 17)
            Me.notreceivedRadioButton.TabIndex = 1
            Me.notreceivedRadioButton.TabStop = True
            Me.notreceivedRadioButton.Text = "Ads &Not Received"
            Me.notreceivedRadioButton.UseVisualStyleBackColor = True
            '
            'receivedRadioButton
            '
            Me.receivedRadioButton.AutoSize = True
            Me.receivedRadioButton.Location = New System.Drawing.Point(6, 18)
            Me.receivedRadioButton.Name = "receivedRadioButton"
            Me.receivedRadioButton.Size = New System.Drawing.Size(92, 17)
            Me.receivedRadioButton.TabIndex = 0
            Me.receivedRadioButton.TabStop = True
            Me.receivedRadioButton.Text = "Ads &Received"
            Me.receivedRadioButton.UseVisualStyleBackColor = True
            '
            'breakDateGroupBox
            '
            Me.breakDateGroupBox.Controls.Add(Me.Panel1)
            Me.breakDateGroupBox.Controls.Add(Me.dateRangeRadioButton)
            Me.breakDateGroupBox.Controls.Add(Me.weekNoRadioButton)
            Me.breakDateGroupBox.Controls.Add(Me.dateRangeGroupBox)
            Me.breakDateGroupBox.Controls.Add(Me.weekNoGroupBox)
            Me.breakDateGroupBox.Location = New System.Drawing.Point(12, 57)
            Me.breakDateGroupBox.Name = "breakDateGroupBox"
            Me.breakDateGroupBox.Size = New System.Drawing.Size(329, 140)
            Me.breakDateGroupBox.TabIndex = 1
            Me.breakDateGroupBox.TabStop = False
            Me.breakDateGroupBox.Text = "Received Date"
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.thisWeekRadioButton)
            Me.Panel1.Controls.Add(Me.todayRadioButton)
            Me.Panel1.Location = New System.Drawing.Point(29, 121)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(281, 18)
            Me.Panel1.TabIndex = 4
            '
            'thisWeekRadioButton
            '
            Me.thisWeekRadioButton.AutoSize = True
            Me.thisWeekRadioButton.Location = New System.Drawing.Point(21, -1)
            Me.thisWeekRadioButton.Name = "thisWeekRadioButton"
            Me.thisWeekRadioButton.Size = New System.Drawing.Size(77, 17)
            Me.thisWeekRadioButton.TabIndex = 6
            Me.thisWeekRadioButton.TabStop = True
            Me.thisWeekRadioButton.Text = "This Week"
            Me.thisWeekRadioButton.UseVisualStyleBackColor = True
            '
            'todayRadioButton
            '
            Me.todayRadioButton.AutoSize = True
            Me.todayRadioButton.Location = New System.Drawing.Point(181, -1)
            Me.todayRadioButton.Name = "todayRadioButton"
            Me.todayRadioButton.Size = New System.Drawing.Size(55, 17)
            Me.todayRadioButton.TabIndex = 4
            Me.todayRadioButton.TabStop = True
            Me.todayRadioButton.Text = "Today"
            Me.todayRadioButton.UseVisualStyleBackColor = True
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
            Me.dateRangeGroupBox.Size = New System.Drawing.Size(147, 88)
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
            Me.weekNoGroupBox.Size = New System.Drawing.Size(155, 88)
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
            Me.outputGroupBox.Location = New System.Drawing.Point(12, 384)
            Me.outputGroupBox.Name = "outputGroupBox"
            Me.outputGroupBox.Size = New System.Drawing.Size(191, 70)
            Me.outputGroupBox.TabIndex = 2
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
            Me.closeButton.Location = New System.Drawing.Point(232, 429)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(108, 23)
            Me.closeButton.TabIndex = 4
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'generateReportButton
            '
            Me.generateReportButton.Location = New System.Drawing.Point(232, 400)
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
            Me.GroupBox1.Location = New System.Drawing.Point(12, 326)
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
            'marketComboBox
            '
            Me.marketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.marketComboBox.FormattingEnabled = True
            Me.marketComboBox.Location = New System.Drawing.Point(68, 267)
            Me.marketComboBox.Name = "marketComboBox"
            Me.marketComboBox.Size = New System.Drawing.Size(267, 21)
            Me.marketComboBox.TabIndex = 1
            '
            'senderComboBox
            '
            Me.senderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.senderComboBox.FormattingEnabled = True
            Me.senderComboBox.Location = New System.Drawing.Point(68, 293)
            Me.senderComboBox.Name = "senderComboBox"
            Me.senderComboBox.Size = New System.Drawing.Size(267, 21)
            Me.senderComboBox.TabIndex = 2
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(8, 270)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(40, 13)
            Me.Label2.TabIndex = 8
            Me.Label2.Text = "Market"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(9, 298)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(41, 13)
            Me.Label3.TabIndex = 9
            Me.Label3.Text = "Sender"
            '
            'TableAdapterManager1
            '
            Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
            Me.TableAdapterManager1.CodeTableAdapter = Nothing
            Me.TableAdapterManager1.CodeTypeTableAdapter = Nothing
            Me.TableAdapterManager1.Connection = Nothing
            Me.TableAdapterManager1.UpdateOrder = MCAP.CodeDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
            '
            'priorityComboBox
            '
            Me.priorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.priorityComboBox.FormattingEnabled = True
            Me.priorityComboBox.Location = New System.Drawing.Point(68, 212)
            Me.priorityComboBox.Name = "priorityComboBox"
            Me.priorityComboBox.Size = New System.Drawing.Size(89, 21)
            Me.priorityComboBox.TabIndex = 10
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(20, 218)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(38, 13)
            Me.Label4.TabIndex = 11
            Me.Label4.Text = "Priority"
            '
            'entryProjectComboBox
            '
            Me.entryProjectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.entryProjectComboBox.FormattingEnabled = True
            Me.entryProjectComboBox.Location = New System.Drawing.Point(248, 212)
            Me.entryProjectComboBox.Name = "entryProjectComboBox"
            Me.entryProjectComboBox.Size = New System.Drawing.Size(87, 21)
            Me.entryProjectComboBox.TabIndex = 12
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(175, 218)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(67, 13)
            Me.Label5.TabIndex = 13
            Me.Label5.Text = "Entry Project"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(4, 241)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(63, 13)
            Me.Label6.TabIndex = 14
            Me.Label6.Text = "Media Type"
            '
            'mediaComboBox
            '
            Me.mediaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.mediaComboBox.FormattingEnabled = True
            Me.mediaComboBox.Location = New System.Drawing.Point(68, 238)
            Me.mediaComboBox.Name = "mediaComboBox"
            Me.mediaComboBox.Size = New System.Drawing.Size(90, 21)
            Me.mediaComboBox.TabIndex = 15
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(179, 245)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(57, 13)
            Me.Label7.TabIndex = 16
            Me.Label7.Text = "Frequency"
            '
            'frequencyComboBox
            '
            Me.frequencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.frequencyComboBox.FormattingEnabled = True
            Me.frequencyComboBox.Location = New System.Drawing.Point(249, 239)
            Me.frequencyComboBox.Name = "frequencyComboBox"
            Me.frequencyComboBox.Size = New System.Drawing.Size(87, 21)
            Me.frequencyComboBox.TabIndex = 17
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.AllStatusRadioButton)
            Me.GroupBox2.Controls.Add(Me.InProcessRadioButton)
            Me.GroupBox2.Location = New System.Drawing.Point(222, 326)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(112, 68)
            Me.GroupBox2.TabIndex = 18
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Status"
            '
            'AllStatusRadioButton
            '
            Me.AllStatusRadioButton.AutoSize = True
            Me.AllStatusRadioButton.Location = New System.Drawing.Point(16, 45)
            Me.AllStatusRadioButton.Name = "AllStatusRadioButton"
            Me.AllStatusRadioButton.Size = New System.Drawing.Size(69, 17)
            Me.AllStatusRadioButton.TabIndex = 1
            Me.AllStatusRadioButton.Text = "All Status"
            Me.AllStatusRadioButton.UseVisualStyleBackColor = True
            '
            'InProcessRadioButton
            '
            Me.InProcessRadioButton.AutoSize = True
            Me.InProcessRadioButton.Checked = True
            Me.InProcessRadioButton.Location = New System.Drawing.Point(16, 18)
            Me.InProcessRadioButton.Name = "InProcessRadioButton"
            Me.InProcessRadioButton.Size = New System.Drawing.Size(75, 17)
            Me.InProcessRadioButton.TabIndex = 0
            Me.InProcessRadioButton.TabStop = True
            Me.InProcessRadioButton.Text = "In-Process"
            Me.InProcessRadioButton.UseVisualStyleBackColor = True
            '
            'AdExpectationReportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(353, 482)
            Me.Controls.Add(Me.GroupBox2)
            Me.Controls.Add(Me.frequencyComboBox)
            Me.Controls.Add(Me.Label7)
            Me.Controls.Add(Me.mediaComboBox)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.entryProjectComboBox)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.priorityComboBox)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.senderComboBox)
            Me.Controls.Add(Me.marketComboBox)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.closeButton)
            Me.Controls.Add(Me.generateReportButton)
            Me.Controls.Add(Me.outputGroupBox)
            Me.Controls.Add(Me.breakDateGroupBox)
            Me.Controls.Add(Me.reportTypeGroupBox)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AdExpectationReportForm"
            Me.StatusMessage = ""
            Me.Text = "Ad Expectation Report"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.reportTypeGroupBox.ResumeLayout(False)
            Me.reportTypeGroupBox.PerformLayout()
            Me.breakDateGroupBox.ResumeLayout(False)
            Me.breakDateGroupBox.PerformLayout()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
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
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents reportTypeGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents notreceivedRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents receivedRadioButton As System.Windows.Forms.RadioButton
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
        Friend WithEvents thisWeekRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents todayRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents marketComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents senderComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents TableAdapterManager1 As MCAP.CodeDataSetTableAdapters.TableAdapterManager
        Friend WithEvents priorityComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents entryProjectComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents mediaComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents frequencyComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents AllStatusRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents InProcessRadioButton As System.Windows.Forms.RadioButton

    End Class

End Namespace