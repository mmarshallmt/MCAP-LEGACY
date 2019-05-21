Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CCSearchForm
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
            Me.vehicleDataGridView = New System.Windows.Forms.DataGridView
            Me.retailerLabel = New System.Windows.Forms.Label
            Me.retailerComboBox = New System.Windows.Forms.ComboBox
            Me.marketLabel = New System.Windows.Forms.Label
            Me.marketComboBox = New System.Windows.Forms.ComboBox
            Me.mediaLabel = New System.Windows.Forms.Label
            Me.mediaComboBox = New System.Windows.Forms.ComboBox
            Me.DateGroupBox3 = New System.Windows.Forms.GroupBox
            Me.fromDtLabel = New System.Windows.Forms.Label
            Me.AdDateToTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
            Me.AdDateFromTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
            Me.toLabel = New System.Windows.Forms.Label
            Me.searchButton = New System.Windows.Forms.Button
            Me.resetButton = New System.Windows.Forms.Button
            Me.closeButton = New System.Windows.Forms.Button
            Me.newspaperComboBox = New System.Windows.Forms.ComboBox
            Me.newspaperLabel = New System.Windows.Forms.Label
            Me.DateGroupBox2 = New System.Windows.Forms.GroupBox
            Me.DueDateToTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
            Me.DueDateFromTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
            Me.Label2 = New System.Windows.Forms.Label
            Me.Label3 = New System.Windows.Forms.Label
            Me.DateGroupBox1 = New System.Windows.Forms.GroupBox
            Me.DateDiscoveredToTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
            Me.DateDiscoveredFromTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
            Me.Label4 = New System.Windows.Forms.Label
            Me.Label5 = New System.Windows.Forms.Label
            Me.DateGroupBox4 = New System.Windows.Forms.GroupBox
            Me.DateResolvedToTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
            Me.DateResolvedFromTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
            Me.Label6 = New System.Windows.Forms.Label
            Me.Label7 = New System.Windows.Forms.Label
            Me.Label1 = New System.Windows.Forms.Label
            Me.SenderComboBox = New System.Windows.Forms.ComboBox
            Me.StatusLabel = New System.Windows.Forms.Label
            Me.StatusComboBox = New System.Windows.Forms.ComboBox
            Me.UrgencyLabel = New System.Windows.Forms.Label
            Me.RootCauseLabel = New System.Windows.Forms.Label
            Me.UrgencyComboBox = New System.Windows.Forms.ComboBox
            Me.RootCauseComboBox = New System.Windows.Forms.ComboBox
            Me.searchGroupBox = New System.Windows.Forms.GroupBox
            Me.GroupBox5 = New System.Windows.Forms.GroupBox
            Me.ANDRadioButton = New System.Windows.Forms.RadioButton
            Me.ORRadioButton = New System.Windows.Forms.RadioButton
            Me.GroupBox3 = New System.Windows.Forms.GroupBox
            Me.TaskLogRadioButton = New System.Windows.Forms.RadioButton
            Me.MissingLogRadioButton = New System.Windows.Forms.RadioButton
            Me.GroupBox2 = New System.Windows.Forms.GroupBox
            Me.Label15 = New System.Windows.Forms.Label
            Me.AssignedComboBox = New System.Windows.Forms.ComboBox
            Me.TimeComboBox = New System.Windows.Forms.ComboBox
            Me.TimeLabel = New System.Windows.Forms.Label
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.Label21 = New System.Windows.Forms.Label
            Me.LtresolutionComboBox = New System.Windows.Forms.ComboBox
            Me.Label13 = New System.Windows.Forms.Label
            Me.StresolutionComboBox = New System.Windows.Forms.ComboBox
            Me.IsFlashComboBox = New System.Windows.Forms.ComboBox
            Me.Label12 = New System.Windows.Forms.Label
            Me.ExportToExcelButton = New System.Windows.Forms.Button
            Me.UserLabel = New System.Windows.Forms.Label
            Me.GroupBox4 = New System.Windows.Forms.GroupBox
            Me.Label10 = New System.Windows.Forms.Label
            Me.PhoneTextBox = New System.Windows.Forms.TextBox
            Me.Label19 = New System.Windows.Forms.Label
            Me.PersonTextBox = New System.Windows.Forms.TextBox
            Me.Label11 = New System.Windows.Forms.Label
            Me.ActionTypeComboBox = New System.Windows.Forms.ComboBox
            Me.Label8 = New System.Windows.Forms.Label
            Me.CommentsTextBox = New System.Windows.Forms.TextBox
            Me.SpecificActionComboBox = New System.Windows.Forms.ComboBox
            Me.Label9 = New System.Windows.Forms.Label
            Me.PersonNameTextBox = New System.Windows.Forms.TextBox
            Me.PersonLabel = New System.Windows.Forms.Label
            Me.IsMissingComboBox = New System.Windows.Forms.ComboBox
            Me.Label20 = New System.Windows.Forms.Label
            Me.MissingAdComboBox = New System.Windows.Forms.ComboBox
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.vehicleDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.DateGroupBox3.SuspendLayout()
            Me.DateGroupBox2.SuspendLayout()
            Me.DateGroupBox1.SuspendLayout()
            Me.DateGroupBox4.SuspendLayout()
            Me.searchGroupBox.SuspendLayout()
            Me.GroupBox5.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox4.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
            Me.smalliconImageList.ImageSize = New System.Drawing.Size(16, 16)
            Me.smalliconImageList.ImageStream = Nothing
            '
            'vehicleDataGridView
            '
            Me.vehicleDataGridView.AllowUserToAddRows = False
            Me.vehicleDataGridView.AllowUserToDeleteRows = False
            Me.vehicleDataGridView.AllowUserToOrderColumns = True
            Me.vehicleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.vehicleDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.vehicleDataGridView.Location = New System.Drawing.Point(0, 343)
            Me.vehicleDataGridView.MultiSelect = False
            Me.vehicleDataGridView.Name = "vehicleDataGridView"
            Me.vehicleDataGridView.ReadOnly = True
            Me.vehicleDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.vehicleDataGridView.Size = New System.Drawing.Size(1078, 242)
            Me.vehicleDataGridView.TabIndex = 1
            '
            'retailerLabel
            '
            Me.retailerLabel.Location = New System.Drawing.Point(2, 104)
            Me.retailerLabel.Name = "retailerLabel"
            Me.retailerLabel.Size = New System.Drawing.Size(77, 13)
            Me.retailerLabel.TabIndex = 6
            Me.retailerLabel.Text = "&Retailer :"
            Me.retailerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'retailerComboBox
            '
            Me.retailerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.retailerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.retailerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.retailerComboBox.FormattingEnabled = True
            Me.retailerComboBox.Location = New System.Drawing.Point(85, 102)
            Me.retailerComboBox.Name = "retailerComboBox"
            Me.retailerComboBox.Size = New System.Drawing.Size(278, 21)
            Me.retailerComboBox.TabIndex = 4
            '
            'marketLabel
            '
            Me.marketLabel.Location = New System.Drawing.Point(2, 51)
            Me.marketLabel.Name = "marketLabel"
            Me.marketLabel.Size = New System.Drawing.Size(77, 13)
            Me.marketLabel.TabIndex = 2
            Me.marketLabel.Text = "&Market :"
            Me.marketLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'marketComboBox
            '
            Me.marketComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.marketComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.marketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.marketComboBox.FormattingEnabled = True
            Me.marketComboBox.Location = New System.Drawing.Point(85, 49)
            Me.marketComboBox.Name = "marketComboBox"
            Me.marketComboBox.Size = New System.Drawing.Size(278, 21)
            Me.marketComboBox.TabIndex = 2
            '
            'mediaLabel
            '
            Me.mediaLabel.Location = New System.Drawing.Point(2, 27)
            Me.mediaLabel.Name = "mediaLabel"
            Me.mediaLabel.Size = New System.Drawing.Size(77, 13)
            Me.mediaLabel.TabIndex = 0
            Me.mediaLabel.Text = "M&edia :"
            Me.mediaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'mediaComboBox
            '
            Me.mediaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.mediaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.mediaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.mediaComboBox.FormattingEnabled = True
            Me.mediaComboBox.Location = New System.Drawing.Point(85, 23)
            Me.mediaComboBox.Name = "mediaComboBox"
            Me.mediaComboBox.Size = New System.Drawing.Size(278, 21)
            Me.mediaComboBox.TabIndex = 1
            '
            'DateGroupBox3
            '
            Me.DateGroupBox3.Controls.Add(Me.fromDtLabel)
            Me.DateGroupBox3.Controls.Add(Me.AdDateToTypeInDatePicker)
            Me.DateGroupBox3.Controls.Add(Me.AdDateFromTypeInDatePicker)
            Me.DateGroupBox3.Controls.Add(Me.toLabel)
            Me.DateGroupBox3.Location = New System.Drawing.Point(383, 13)
            Me.DateGroupBox3.Name = "DateGroupBox3"
            Me.DateGroupBox3.Size = New System.Drawing.Size(124, 66)
            Me.DateGroupBox3.TabIndex = 8
            Me.DateGroupBox3.TabStop = False
            Me.DateGroupBox3.Text = "Ad Date"
            '
            'fromDtLabel
            '
            Me.fromDtLabel.AutoSize = True
            Me.fromDtLabel.Location = New System.Drawing.Point(6, 18)
            Me.fromDtLabel.Name = "fromDtLabel"
            Me.fromDtLabel.Size = New System.Drawing.Size(30, 13)
            Me.fromDtLabel.TabIndex = 0
            Me.fromDtLabel.Text = "&From"
            '
            'AdDateToTypeInDatePicker
            '
            Me.AdDateToTypeInDatePicker.Location = New System.Drawing.Point(40, 37)
            Me.AdDateToTypeInDatePicker.Name = "AdDateToTypeInDatePicker"
            Me.AdDateToTypeInDatePicker.Size = New System.Drawing.Size(72, 20)
            Me.AdDateToTypeInDatePicker.TabIndex = 18
            Me.AdDateToTypeInDatePicker.Value = Nothing
            '
            'AdDateFromTypeInDatePicker
            '
            Me.AdDateFromTypeInDatePicker.Location = New System.Drawing.Point(40, 13)
            Me.AdDateFromTypeInDatePicker.Name = "AdDateFromTypeInDatePicker"
            Me.AdDateFromTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.AdDateFromTypeInDatePicker.TabIndex = 17
            Me.AdDateFromTypeInDatePicker.Value = Nothing
            '
            'toLabel
            '
            Me.toLabel.AutoSize = True
            Me.toLabel.Location = New System.Drawing.Point(6, 39)
            Me.toLabel.Name = "toLabel"
            Me.toLabel.Size = New System.Drawing.Size(20, 13)
            Me.toLabel.TabIndex = 2
            Me.toLabel.Text = "&To"
            '
            'searchButton
            '
            Me.searchButton.Location = New System.Drawing.Point(957, 252)
            Me.searchButton.Name = "searchButton"
            Me.searchButton.Size = New System.Drawing.Size(108, 24)
            Me.searchButton.TabIndex = 32
            Me.searchButton.Text = "&Search"
            Me.searchButton.UseVisualStyleBackColor = True
            '
            'resetButton
            '
            Me.resetButton.Location = New System.Drawing.Point(957, 279)
            Me.resetButton.Name = "resetButton"
            Me.resetButton.Size = New System.Drawing.Size(109, 24)
            Me.resetButton.TabIndex = 33
            Me.resetButton.Text = "Rese&t"
            Me.resetButton.UseVisualStyleBackColor = True
            '
            'closeButton
            '
            Me.closeButton.Location = New System.Drawing.Point(984, 305)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(81, 23)
            Me.closeButton.TabIndex = 34
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'newspaperComboBox
            '
            Me.newspaperComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.newspaperComboBox.FormattingEnabled = True
            Me.newspaperComboBox.Location = New System.Drawing.Point(85, 76)
            Me.newspaperComboBox.Name = "newspaperComboBox"
            Me.newspaperComboBox.Size = New System.Drawing.Size(278, 21)
            Me.newspaperComboBox.TabIndex = 3
            '
            'newspaperLabel
            '
            Me.newspaperLabel.Location = New System.Drawing.Point(2, 79)
            Me.newspaperLabel.Name = "newspaperLabel"
            Me.newspaperLabel.Size = New System.Drawing.Size(77, 13)
            Me.newspaperLabel.TabIndex = 4
            Me.newspaperLabel.Text = "Ne&wspaper :"
            Me.newspaperLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'DateGroupBox2
            '
            Me.DateGroupBox2.Controls.Add(Me.DueDateToTypeInDatePicker)
            Me.DateGroupBox2.Controls.Add(Me.DueDateFromTypeInDatePicker)
            Me.DateGroupBox2.Controls.Add(Me.Label2)
            Me.DateGroupBox2.Controls.Add(Me.Label3)
            Me.DateGroupBox2.Location = New System.Drawing.Point(516, 13)
            Me.DateGroupBox2.Name = "DateGroupBox2"
            Me.DateGroupBox2.Size = New System.Drawing.Size(123, 66)
            Me.DateGroupBox2.TabIndex = 13
            Me.DateGroupBox2.TabStop = False
            Me.DateGroupBox2.Text = "Due Date"
            '
            'DueDateToTypeInDatePicker
            '
            Me.DueDateToTypeInDatePicker.Location = New System.Drawing.Point(41, 38)
            Me.DueDateToTypeInDatePicker.Name = "DueDateToTypeInDatePicker"
            Me.DueDateToTypeInDatePicker.Size = New System.Drawing.Size(72, 20)
            Me.DueDateToTypeInDatePicker.TabIndex = 16
            Me.DueDateToTypeInDatePicker.Value = Nothing
            '
            'DueDateFromTypeInDatePicker
            '
            Me.DueDateFromTypeInDatePicker.Location = New System.Drawing.Point(41, 15)
            Me.DueDateFromTypeInDatePicker.Name = "DueDateFromTypeInDatePicker"
            Me.DueDateFromTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.DueDateFromTypeInDatePicker.TabIndex = 15
            Me.DueDateFromTypeInDatePicker.Value = Nothing
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(5, 19)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(30, 13)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "&From"
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(6, 40)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(20, 13)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "&To"
            '
            'DateGroupBox1
            '
            Me.DateGroupBox1.Controls.Add(Me.DateDiscoveredToTypeInDatePicker)
            Me.DateGroupBox1.Controls.Add(Me.DateDiscoveredFromTypeInDatePicker)
            Me.DateGroupBox1.Controls.Add(Me.Label4)
            Me.DateGroupBox1.Controls.Add(Me.Label5)
            Me.DateGroupBox1.Location = New System.Drawing.Point(721, 252)
            Me.DateGroupBox1.Name = "DateGroupBox1"
            Me.DateGroupBox1.Size = New System.Drawing.Size(124, 78)
            Me.DateGroupBox1.TabIndex = 14
            Me.DateGroupBox1.TabStop = False
            Me.DateGroupBox1.Text = "DateDiscovered"
            '
            'DateDiscoveredToTypeInDatePicker
            '
            Me.DateDiscoveredToTypeInDatePicker.Location = New System.Drawing.Point(41, 47)
            Me.DateDiscoveredToTypeInDatePicker.Name = "DateDiscoveredToTypeInDatePicker"
            Me.DateDiscoveredToTypeInDatePicker.Size = New System.Drawing.Size(74, 20)
            Me.DateDiscoveredToTypeInDatePicker.TabIndex = 14
            Me.DateDiscoveredToTypeInDatePicker.Value = Nothing
            '
            'DateDiscoveredFromTypeInDatePicker
            '
            Me.DateDiscoveredFromTypeInDatePicker.Location = New System.Drawing.Point(41, 19)
            Me.DateDiscoveredFromTypeInDatePicker.Name = "DateDiscoveredFromTypeInDatePicker"
            Me.DateDiscoveredFromTypeInDatePicker.Size = New System.Drawing.Size(74, 22)
            Me.DateDiscoveredFromTypeInDatePicker.TabIndex = 13
            Me.DateDiscoveredFromTypeInDatePicker.Value = Nothing
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(7, 26)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(30, 13)
            Me.Label4.TabIndex = 3
            Me.Label4.Text = "&From"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(7, 53)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(20, 13)
            Me.Label5.TabIndex = 4
            Me.Label5.Text = "&To"
            '
            'DateGroupBox4
            '
            Me.DateGroupBox4.Controls.Add(Me.DateResolvedToTypeInDatePicker)
            Me.DateGroupBox4.Controls.Add(Me.DateResolvedFromTypeInDatePicker)
            Me.DateGroupBox4.Controls.Add(Me.Label6)
            Me.DateGroupBox4.Controls.Add(Me.Label7)
            Me.DateGroupBox4.Location = New System.Drawing.Point(11, 27)
            Me.DateGroupBox4.Name = "DateGroupBox4"
            Me.DateGroupBox4.Size = New System.Drawing.Size(119, 78)
            Me.DateGroupBox4.TabIndex = 15
            Me.DateGroupBox4.TabStop = False
            Me.DateGroupBox4.Text = "DateResolved"
            '
            'DateResolvedToTypeInDatePicker
            '
            Me.DateResolvedToTypeInDatePicker.Location = New System.Drawing.Point(41, 48)
            Me.DateResolvedToTypeInDatePicker.Name = "DateResolvedToTypeInDatePicker"
            Me.DateResolvedToTypeInDatePicker.Size = New System.Drawing.Size(72, 20)
            Me.DateResolvedToTypeInDatePicker.TabIndex = 20
            Me.DateResolvedToTypeInDatePicker.Value = Nothing
            '
            'DateResolvedFromTypeInDatePicker
            '
            Me.DateResolvedFromTypeInDatePicker.Location = New System.Drawing.Point(41, 17)
            Me.DateResolvedFromTypeInDatePicker.Name = "DateResolvedFromTypeInDatePicker"
            Me.DateResolvedFromTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.DateResolvedFromTypeInDatePicker.TabIndex = 19
            Me.DateResolvedFromTypeInDatePicker.Value = Nothing
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(9, 27)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(30, 13)
            Me.Label6.TabIndex = 3
            Me.Label6.Text = "&From"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(9, 54)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(20, 13)
            Me.Label7.TabIndex = 4
            Me.Label7.Text = "&To"
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(2, 130)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(77, 13)
            Me.Label1.TabIndex = 16
            Me.Label1.Text = "Sender :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'SenderComboBox
            '
            Me.SenderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.SenderComboBox.FormattingEnabled = True
            Me.SenderComboBox.Location = New System.Drawing.Point(85, 129)
            Me.SenderComboBox.Name = "SenderComboBox"
            Me.SenderComboBox.Size = New System.Drawing.Size(278, 21)
            Me.SenderComboBox.TabIndex = 5
            '
            'StatusLabel
            '
            Me.StatusLabel.Location = New System.Drawing.Point(2, 224)
            Me.StatusLabel.Name = "StatusLabel"
            Me.StatusLabel.Size = New System.Drawing.Size(77, 13)
            Me.StatusLabel.TabIndex = 19
            Me.StatusLabel.Text = "Status :"
            Me.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'StatusComboBox
            '
            Me.StatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.StatusComboBox.FormattingEnabled = True
            Me.StatusComboBox.Location = New System.Drawing.Point(85, 218)
            Me.StatusComboBox.Name = "StatusComboBox"
            Me.StatusComboBox.Size = New System.Drawing.Size(278, 21)
            Me.StatusComboBox.TabIndex = 8
            '
            'UrgencyLabel
            '
            Me.UrgencyLabel.Location = New System.Drawing.Point(2, 245)
            Me.UrgencyLabel.Name = "UrgencyLabel"
            Me.UrgencyLabel.Size = New System.Drawing.Size(77, 13)
            Me.UrgencyLabel.TabIndex = 21
            Me.UrgencyLabel.Text = "Urgency :"
            Me.UrgencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'RootCauseLabel
            '
            Me.RootCauseLabel.Location = New System.Drawing.Point(138, 71)
            Me.RootCauseLabel.Name = "RootCauseLabel"
            Me.RootCauseLabel.Size = New System.Drawing.Size(77, 13)
            Me.RootCauseLabel.TabIndex = 22
            Me.RootCauseLabel.Text = "RootCause :"
            Me.RootCauseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'UrgencyComboBox
            '
            Me.UrgencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.UrgencyComboBox.FormattingEnabled = True
            Me.UrgencyComboBox.Location = New System.Drawing.Point(85, 245)
            Me.UrgencyComboBox.Name = "UrgencyComboBox"
            Me.UrgencyComboBox.Size = New System.Drawing.Size(278, 21)
            Me.UrgencyComboBox.TabIndex = 9
            '
            'RootCauseComboBox
            '
            Me.RootCauseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.RootCauseComboBox.FormattingEnabled = True
            Me.RootCauseComboBox.Location = New System.Drawing.Point(136, 87)
            Me.RootCauseComboBox.Name = "RootCauseComboBox"
            Me.RootCauseComboBox.Size = New System.Drawing.Size(191, 21)
            Me.RootCauseComboBox.TabIndex = 10
            '
            'searchGroupBox
            '
            Me.searchGroupBox.Controls.Add(Me.GroupBox5)
            Me.searchGroupBox.Controls.Add(Me.GroupBox3)
            Me.searchGroupBox.Controls.Add(Me.GroupBox2)
            Me.searchGroupBox.Controls.Add(Me.DateGroupBox1)
            Me.searchGroupBox.Controls.Add(Me.GroupBox1)
            Me.searchGroupBox.Controls.Add(Me.ExportToExcelButton)
            Me.searchGroupBox.Controls.Add(Me.UserLabel)
            Me.searchGroupBox.Controls.Add(Me.GroupBox4)
            Me.searchGroupBox.Controls.Add(Me.DateGroupBox2)
            Me.searchGroupBox.Controls.Add(Me.closeButton)
            Me.searchGroupBox.Controls.Add(Me.resetButton)
            Me.searchGroupBox.Controls.Add(Me.searchButton)
            Me.searchGroupBox.Controls.Add(Me.DateGroupBox3)
            Me.searchGroupBox.Controls.Add(Me.MissingAdComboBox)
            Me.searchGroupBox.Dock = System.Windows.Forms.DockStyle.Top
            Me.searchGroupBox.Location = New System.Drawing.Point(0, 0)
            Me.searchGroupBox.Name = "searchGroupBox"
            Me.searchGroupBox.Size = New System.Drawing.Size(1078, 343)
            Me.searchGroupBox.TabIndex = 0
            Me.searchGroupBox.TabStop = False
            Me.searchGroupBox.Text = "Search"
            '
            'GroupBox5
            '
            Me.GroupBox5.Controls.Add(Me.ANDRadioButton)
            Me.GroupBox5.Controls.Add(Me.ORRadioButton)
            Me.GroupBox5.Location = New System.Drawing.Point(851, 252)
            Me.GroupBox5.Name = "GroupBox5"
            Me.GroupBox5.Size = New System.Drawing.Size(100, 79)
            Me.GroupBox5.TabIndex = 58
            Me.GroupBox5.TabStop = False
            Me.GroupBox5.Text = "Logical Operator"
            '
            'ANDRadioButton
            '
            Me.ANDRadioButton.Checked = True
            Me.ANDRadioButton.Location = New System.Drawing.Point(11, 13)
            Me.ANDRadioButton.Name = "ANDRadioButton"
            Me.ANDRadioButton.Size = New System.Drawing.Size(54, 33)
            Me.ANDRadioButton.TabIndex = 21
            Me.ANDRadioButton.TabStop = True
            Me.ANDRadioButton.Text = "AND"
            Me.ANDRadioButton.UseVisualStyleBackColor = True
            '
            'ORRadioButton
            '
            Me.ORRadioButton.Location = New System.Drawing.Point(11, 44)
            Me.ORRadioButton.Name = "ORRadioButton"
            Me.ORRadioButton.Size = New System.Drawing.Size(54, 32)
            Me.ORRadioButton.TabIndex = 22
            Me.ORRadioButton.Text = "OR"
            Me.ORRadioButton.UseVisualStyleBackColor = True
            '
            'GroupBox3
            '
            Me.GroupBox3.Controls.Add(Me.TaskLogRadioButton)
            Me.GroupBox3.Controls.Add(Me.MissingLogRadioButton)
            Me.GroupBox3.Location = New System.Drawing.Point(12, 18)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(365, 35)
            Me.GroupBox3.TabIndex = 57
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "Report Type"
            '
            'TaskLogRadioButton
            '
            Me.TaskLogRadioButton.AutoSize = True
            Me.TaskLogRadioButton.Checked = True
            Me.TaskLogRadioButton.Location = New System.Drawing.Point(91, 15)
            Me.TaskLogRadioButton.Name = "TaskLogRadioButton"
            Me.TaskLogRadioButton.Size = New System.Drawing.Size(87, 17)
            Me.TaskLogRadioButton.TabIndex = 21
            Me.TaskLogRadioButton.TabStop = True
            Me.TaskLogRadioButton.Text = "CC Task Log"
            Me.TaskLogRadioButton.UseVisualStyleBackColor = True
            '
            'MissingLogRadioButton
            '
            Me.MissingLogRadioButton.AutoSize = True
            Me.MissingLogRadioButton.Location = New System.Drawing.Point(204, 14)
            Me.MissingLogRadioButton.Name = "MissingLogRadioButton"
            Me.MissingLogRadioButton.Size = New System.Drawing.Size(98, 17)
            Me.MissingLogRadioButton.TabIndex = 22
            Me.MissingLogRadioButton.Text = "CC Missing Log"
            Me.MissingLogRadioButton.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.mediaComboBox)
            Me.GroupBox2.Controls.Add(Me.retailerLabel)
            Me.GroupBox2.Controls.Add(Me.retailerComboBox)
            Me.GroupBox2.Controls.Add(Me.marketLabel)
            Me.GroupBox2.Controls.Add(Me.marketComboBox)
            Me.GroupBox2.Controls.Add(Me.mediaLabel)
            Me.GroupBox2.Controls.Add(Me.Label15)
            Me.GroupBox2.Controls.Add(Me.newspaperComboBox)
            Me.GroupBox2.Controls.Add(Me.AssignedComboBox)
            Me.GroupBox2.Controls.Add(Me.newspaperLabel)
            Me.GroupBox2.Controls.Add(Me.Label1)
            Me.GroupBox2.Controls.Add(Me.TimeComboBox)
            Me.GroupBox2.Controls.Add(Me.SenderComboBox)
            Me.GroupBox2.Controls.Add(Me.TimeLabel)
            Me.GroupBox2.Controls.Add(Me.StatusLabel)
            Me.GroupBox2.Controls.Add(Me.StatusComboBox)
            Me.GroupBox2.Controls.Add(Me.UrgencyComboBox)
            Me.GroupBox2.Controls.Add(Me.UrgencyLabel)
            Me.GroupBox2.Location = New System.Drawing.Point(7, 59)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(369, 271)
            Me.GroupBox2.TabIndex = 56
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Global Parameters"
            '
            'Label15
            '
            Me.Label15.Location = New System.Drawing.Point(2, 191)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(77, 13)
            Me.Label15.TabIndex = 50
            Me.Label15.Text = "Assigned :"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'AssignedComboBox
            '
            Me.AssignedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.AssignedComboBox.FormattingEnabled = True
            Me.AssignedComboBox.Location = New System.Drawing.Point(85, 189)
            Me.AssignedComboBox.Name = "AssignedComboBox"
            Me.AssignedComboBox.Size = New System.Drawing.Size(278, 21)
            Me.AssignedComboBox.TabIndex = 7
            '
            'TimeComboBox
            '
            Me.TimeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.TimeComboBox.FormattingEnabled = True
            Me.TimeComboBox.Location = New System.Drawing.Point(85, 159)
            Me.TimeComboBox.Name = "TimeComboBox"
            Me.TimeComboBox.Size = New System.Drawing.Size(278, 21)
            Me.TimeComboBox.TabIndex = 6
            '
            'TimeLabel
            '
            Me.TimeLabel.Location = New System.Drawing.Point(2, 164)
            Me.TimeLabel.Name = "TimeLabel"
            Me.TimeLabel.Size = New System.Drawing.Size(77, 13)
            Me.TimeLabel.TabIndex = 33
            Me.TimeLabel.Text = "Time :"
            Me.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.DateGroupBox4)
            Me.GroupBox1.Controls.Add(Me.Label21)
            Me.GroupBox1.Controls.Add(Me.LtresolutionComboBox)
            Me.GroupBox1.Controls.Add(Me.Label13)
            Me.GroupBox1.Controls.Add(Me.StresolutionComboBox)
            Me.GroupBox1.Controls.Add(Me.IsFlashComboBox)
            Me.GroupBox1.Controls.Add(Me.Label12)
            Me.GroupBox1.Controls.Add(Me.RootCauseComboBox)
            Me.GroupBox1.Controls.Add(Me.RootCauseLabel)
            Me.GroupBox1.Location = New System.Drawing.Point(721, 29)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(344, 217)
            Me.GroupBox1.TabIndex = 26
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Missing Ad Logs Parameters"
            '
            'Label21
            '
            Me.Label21.Location = New System.Drawing.Point(136, 30)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(85, 13)
            Me.Label21.TabIndex = 59
            Me.Label21.Text = "Flash :"
            Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'LtresolutionComboBox
            '
            Me.LtresolutionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.LtresolutionComboBox.FormattingEnabled = True
            Me.LtresolutionComboBox.Location = New System.Drawing.Point(8, 176)
            Me.LtresolutionComboBox.Name = "LtresolutionComboBox"
            Me.LtresolutionComboBox.Size = New System.Drawing.Size(319, 21)
            Me.LtresolutionComboBox.TabIndex = 12
            '
            'Label13
            '
            Me.Label13.Location = New System.Drawing.Point(8, 160)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(85, 13)
            Me.Label13.TabIndex = 46
            Me.Label13.Text = "Lt Resolution :"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'StresolutionComboBox
            '
            Me.StresolutionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.StresolutionComboBox.FormattingEnabled = True
            Me.StresolutionComboBox.Location = New System.Drawing.Point(8, 130)
            Me.StresolutionComboBox.Name = "StresolutionComboBox"
            Me.StresolutionComboBox.Size = New System.Drawing.Size(319, 21)
            Me.StresolutionComboBox.TabIndex = 11
            '
            'IsFlashComboBox
            '
            Me.IsFlashComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.IsFlashComboBox.FormattingEnabled = True
            Me.IsFlashComboBox.Location = New System.Drawing.Point(137, 46)
            Me.IsFlashComboBox.Name = "IsFlashComboBox"
            Me.IsFlashComboBox.Size = New System.Drawing.Size(88, 21)
            Me.IsFlashComboBox.TabIndex = 57
            '
            'Label12
            '
            Me.Label12.Location = New System.Drawing.Point(8, 114)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(77, 13)
            Me.Label12.TabIndex = 44
            Me.Label12.Text = "St Resolution :"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ExportToExcelButton
            '
            Me.ExportToExcelButton.Location = New System.Drawing.Point(957, 306)
            Me.ExportToExcelButton.Name = "ExportToExcelButton"
            Me.ExportToExcelButton.Size = New System.Drawing.Size(109, 24)
            Me.ExportToExcelButton.TabIndex = 55
            Me.ExportToExcelButton.Text = "Export"
            Me.ExportToExcelButton.UseVisualStyleBackColor = True
            '
            'UserLabel
            '
            Me.UserLabel.AutoSize = True
            Me.UserLabel.Location = New System.Drawing.Point(-681, 247)
            Me.UserLabel.Name = "UserLabel"
            Me.UserLabel.Size = New System.Drawing.Size(29, 13)
            Me.UserLabel.TabIndex = 42
            Me.UserLabel.Text = "User"
            '
            'GroupBox4
            '
            Me.GroupBox4.Controls.Add(Me.Label10)
            Me.GroupBox4.Controls.Add(Me.PhoneTextBox)
            Me.GroupBox4.Controls.Add(Me.Label19)
            Me.GroupBox4.Controls.Add(Me.PersonTextBox)
            Me.GroupBox4.Controls.Add(Me.Label11)
            Me.GroupBox4.Controls.Add(Me.ActionTypeComboBox)
            Me.GroupBox4.Controls.Add(Me.Label8)
            Me.GroupBox4.Controls.Add(Me.CommentsTextBox)
            Me.GroupBox4.Controls.Add(Me.SpecificActionComboBox)
            Me.GroupBox4.Controls.Add(Me.Label9)
            Me.GroupBox4.Controls.Add(Me.PersonNameTextBox)
            Me.GroupBox4.Controls.Add(Me.PersonLabel)
            Me.GroupBox4.Controls.Add(Me.IsMissingComboBox)
            Me.GroupBox4.Controls.Add(Me.Label20)
            Me.GroupBox4.Location = New System.Drawing.Point(382, 83)
            Me.GroupBox4.Name = "GroupBox4"
            Me.GroupBox4.Size = New System.Drawing.Size(333, 247)
            Me.GroupBox4.TabIndex = 25
            Me.GroupBox4.TabStop = False
            Me.GroupBox4.Text = "Task Logs Parameters"
            '
            'Label10
            '
            Me.Label10.Location = New System.Drawing.Point(16, 20)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(76, 15)
            Me.Label10.TabIndex = 35
            Me.Label10.Text = "Phone Called :"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'PhoneTextBox
            '
            Me.PhoneTextBox.Location = New System.Drawing.Point(98, 19)
            Me.PhoneTextBox.Name = "PhoneTextBox"
            Me.PhoneTextBox.Size = New System.Drawing.Size(230, 20)
            Me.PhoneTextBox.TabIndex = 23
            '
            'Label19
            '
            Me.Label19.Location = New System.Drawing.Point(22, 154)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(69, 16)
            Me.Label19.TabIndex = 54
            Me.Label19.Text = "Comments :"
            Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'PersonTextBox
            '
            Me.PersonTextBox.Location = New System.Drawing.Point(98, 45)
            Me.PersonTextBox.Name = "PersonTextBox"
            Me.PersonTextBox.Size = New System.Drawing.Size(230, 20)
            Me.PersonTextBox.TabIndex = 24
            '
            'Label11
            '
            Me.Label11.Location = New System.Drawing.Point(16, 47)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(76, 13)
            Me.Label11.TabIndex = 37
            Me.Label11.Text = "Spoke With:"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ActionTypeComboBox
            '
            Me.ActionTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ActionTypeComboBox.FormattingEnabled = True
            Me.ActionTypeComboBox.Location = New System.Drawing.Point(99, 97)
            Me.ActionTypeComboBox.Name = "ActionTypeComboBox"
            Me.ActionTypeComboBox.Size = New System.Drawing.Size(168, 21)
            Me.ActionTypeComboBox.TabIndex = 29
            '
            'Label8
            '
            Me.Label8.Location = New System.Drawing.Point(19, 97)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(73, 17)
            Me.Label8.TabIndex = 29
            Me.Label8.Text = "Action Type :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CommentsTextBox
            '
            Me.CommentsTextBox.Location = New System.Drawing.Point(99, 151)
            Me.CommentsTextBox.Multiline = True
            Me.CommentsTextBox.Name = "CommentsTextBox"
            Me.CommentsTextBox.Size = New System.Drawing.Size(222, 89)
            Me.CommentsTextBox.TabIndex = 31
            '
            'SpecificActionComboBox
            '
            Me.SpecificActionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.SpecificActionComboBox.FormattingEnabled = True
            Me.SpecificActionComboBox.Location = New System.Drawing.Point(99, 124)
            Me.SpecificActionComboBox.Name = "SpecificActionComboBox"
            Me.SpecificActionComboBox.Size = New System.Drawing.Size(168, 21)
            Me.SpecificActionComboBox.TabIndex = 30
            '
            'Label9
            '
            Me.Label9.Location = New System.Drawing.Point(7, 124)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(84, 16)
            Me.Label9.TabIndex = 30
            Me.Label9.Text = "Specific Action :"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'PersonNameTextBox
            '
            Me.PersonNameTextBox.Location = New System.Drawing.Point(98, 71)
            Me.PersonNameTextBox.Name = "PersonNameTextBox"
            Me.PersonNameTextBox.Size = New System.Drawing.Size(159, 20)
            Me.PersonNameTextBox.TabIndex = 25
            '
            'PersonLabel
            '
            Me.PersonLabel.Location = New System.Drawing.Point(13, 69)
            Me.PersonLabel.Name = "PersonLabel"
            Me.PersonLabel.Size = New System.Drawing.Size(79, 20)
            Me.PersonLabel.TabIndex = 40
            Me.PersonLabel.Text = "Person Name :"
            Me.PersonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'IsMissingComboBox
            '
            Me.IsMissingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.IsMissingComboBox.FormattingEnabled = True
            Me.IsMissingComboBox.Location = New System.Drawing.Point(189, 172)
            Me.IsMissingComboBox.Name = "IsMissingComboBox"
            Me.IsMissingComboBox.Size = New System.Drawing.Size(88, 21)
            Me.IsMissingComboBox.TabIndex = 56
            '
            'Label20
            '
            Me.Label20.Location = New System.Drawing.Point(107, 173)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(76, 16)
            Me.Label20.TabIndex = 58
            Me.Label20.Text = "Missing Ad :"
            Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'MissingAdComboBox
            '
            Me.MissingAdComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.MissingAdComboBox.FormattingEnabled = True
            Me.MissingAdComboBox.Location = New System.Drawing.Point(1033, 203)
            Me.MissingAdComboBox.Name = "MissingAdComboBox"
            Me.MissingAdComboBox.Size = New System.Drawing.Size(32, 21)
            Me.MissingAdComboBox.TabIndex = 50
            Me.MissingAdComboBox.Visible = False
            '
            'CCSearchForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1078, 585)
            Me.Controls.Add(Me.vehicleDataGridView)
            Me.Controls.Add(Me.searchGroupBox)
            Me.Name = "CCSearchForm"
            Me.StatusMessage = ""
            Me.Text = "CC Search"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.vehicleDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.DateGroupBox3.ResumeLayout(False)
            Me.DateGroupBox3.PerformLayout()
            Me.DateGroupBox2.ResumeLayout(False)
            Me.DateGroupBox2.PerformLayout()
            Me.DateGroupBox1.ResumeLayout(False)
            Me.DateGroupBox1.PerformLayout()
            Me.DateGroupBox4.ResumeLayout(False)
            Me.DateGroupBox4.PerformLayout()
            Me.searchGroupBox.ResumeLayout(False)
            Me.searchGroupBox.PerformLayout()
            Me.GroupBox5.ResumeLayout(False)
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox3.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox4.ResumeLayout(False)
            Me.GroupBox4.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents vehicleDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents retailerLabel As System.Windows.Forms.Label
        Friend WithEvents retailerComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents marketLabel As System.Windows.Forms.Label
        Friend WithEvents marketComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents mediaLabel As System.Windows.Forms.Label
        Friend WithEvents mediaComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents DateGroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents fromDtLabel As System.Windows.Forms.Label
        Friend WithEvents AdDateToTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents AdDateFromTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents toLabel As System.Windows.Forms.Label
        Friend WithEvents searchButton As System.Windows.Forms.Button
        Friend WithEvents resetButton As System.Windows.Forms.Button
        Friend WithEvents closeButton As System.Windows.Forms.Button
        Friend WithEvents newspaperComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents newspaperLabel As System.Windows.Forms.Label
        Friend WithEvents DateGroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents DateGroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents DateGroupBox4 As System.Windows.Forms.GroupBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents SenderComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents StatusLabel As System.Windows.Forms.Label
        Friend WithEvents StatusComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents UrgencyLabel As System.Windows.Forms.Label
        Friend WithEvents RootCauseLabel As System.Windows.Forms.Label
        Friend WithEvents UrgencyComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents RootCauseComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents searchGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
        Friend WithEvents MissingLogRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents TaskLogRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents TimeComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents TimeLabel As System.Windows.Forms.Label
        Friend WithEvents SpecificActionComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents ActionTypeComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents PersonLabel As System.Windows.Forms.Label
        Friend WithEvents PersonNameTextBox As System.Windows.Forms.TextBox
        Friend WithEvents PersonTextBox As System.Windows.Forms.TextBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents PhoneTextBox As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents AssignedComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents UserLabel As System.Windows.Forms.Label
        Friend WithEvents CommentsTextBox As System.Windows.Forms.TextBox
        Friend WithEvents DueDateToTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents DueDateFromTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents DateResolvedToTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents DateResolvedFromTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents LtresolutionComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents StresolutionComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents MissingAdComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents ExportToExcelButton As System.Windows.Forms.Button
        Friend WithEvents IsFlashComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents IsMissingComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents DateDiscoveredToTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents DateDiscoveredFromTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
        Friend WithEvents ANDRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents ORRadioButton As System.Windows.Forms.RadioButton

    End Class

End Namespace