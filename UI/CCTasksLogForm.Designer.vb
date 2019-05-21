Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CCTasksLogForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CCTasksLogForm))
            Me.editTableGroupBox = New System.Windows.Forms.GroupBox
            Me.DeleteButton = New System.Windows.Forms.Button
            Me.GroupBox2 = New System.Windows.Forms.GroupBox
            Me.NameTextBox = New System.Windows.Forms.TextBox
            Me.PhoneNoTextBox = New System.Windows.Forms.TextBox
            Me.PersonSpokeToTextBox = New System.Windows.Forms.TextBox
            Me.Label19 = New System.Windows.Forms.Label
            Me.Label20 = New System.Windows.Forms.Label
            Me.Label22 = New System.Windows.Forms.Label
            Me.FlashCheckBox = New System.Windows.Forms.CheckBox
            Me.LastSavedLabel = New System.Windows.Forms.Label
            Me.Button1 = New System.Windows.Forms.Button
            Me.CreatedByLabel = New System.Windows.Forms.Label
            Me.Label10 = New System.Windows.Forms.Label
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.SearchButton = New System.Windows.Forms.Button
            Me.findVehicleIdTextBox = New System.Windows.Forms.TextBox
            Me.EditButton = New System.Windows.Forms.Button
            Me.addateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
            Me.DueDateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
            Me.currentdateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
            Me.OtherContactCheckBox = New System.Windows.Forms.CheckBox
            Me.TimeComboBox = New System.Windows.Forms.ComboBox
            Me.MissingAdIdLabel = New System.Windows.Forms.Label
            Me.cancelButton = New System.Windows.Forms.Button
            Me.Label21 = New System.Windows.Forms.Label
            Me.Label18 = New System.Windows.Forms.Label
            Me.Label17 = New System.Windows.Forms.Label
            Me.Label16 = New System.Windows.Forms.Label
            Me.Label15 = New System.Windows.Forms.Label
            Me.Label14 = New System.Windows.Forms.Label
            Me.Label13 = New System.Windows.Forms.Label
            Me.Label9 = New System.Windows.Forms.Label
            Me.Label8 = New System.Windows.Forms.Label
            Me.Label7 = New System.Windows.Forms.Label
            Me.Label6 = New System.Windows.Forms.Label
            Me.Label5 = New System.Windows.Forms.Label
            Me.Label4 = New System.Windows.Forms.Label
            Me.Label3 = New System.Windows.Forms.Label
            Me.Label2 = New System.Windows.Forms.Label
            Me.Label1 = New System.Windows.Forms.Label
            Me.CreateTaskLogButton = New System.Windows.Forms.Button
            Me.CommentsTextBox = New System.Windows.Forms.TextBox
            Me.MissingAdCheckBox = New System.Windows.Forms.CheckBox
            Me.SpecificActionComboBox = New System.Windows.Forms.ComboBox
            Me.ActionTypeComboBox = New System.Windows.Forms.ComboBox
            Me.urgencyComboBox = New System.Windows.Forms.ComboBox
            Me.statusComboBox = New System.Windows.Forms.ComboBox
            Me.PublicationNameComboBox = New System.Windows.Forms.ComboBox
            Me.SenderComboBox = New System.Windows.Forms.ComboBox
            Me.MediaComboBox = New System.Windows.Forms.ComboBox
            Me.MarketComboBox = New System.Windows.Forms.ComboBox
            Me.RetailerComboBox = New System.Windows.Forms.ComboBox
            Me.AssignedComboBox = New System.Windows.Forms.ComboBox
            Me.closeButton = New System.Windows.Forms.Button
            Me.ParameterDetailsTableAdapter1 = New MCAP.DESPDataSetTableAdapters.ParameterDetailsTableAdapter
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.editTableGroupBox.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
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
            'editTableGroupBox
            '
            Me.editTableGroupBox.Controls.Add(Me.DeleteButton)
            Me.editTableGroupBox.Controls.Add(Me.GroupBox2)
            Me.editTableGroupBox.Controls.Add(Me.FlashCheckBox)
            Me.editTableGroupBox.Controls.Add(Me.LastSavedLabel)
            Me.editTableGroupBox.Controls.Add(Me.Button1)
            Me.editTableGroupBox.Controls.Add(Me.CreatedByLabel)
            Me.editTableGroupBox.Controls.Add(Me.Label10)
            Me.editTableGroupBox.Controls.Add(Me.GroupBox1)
            Me.editTableGroupBox.Controls.Add(Me.addateTypeInDatePicker)
            Me.editTableGroupBox.Controls.Add(Me.DueDateTypeInDatePicker)
            Me.editTableGroupBox.Controls.Add(Me.currentdateTypeInDatePicker)
            Me.editTableGroupBox.Controls.Add(Me.OtherContactCheckBox)
            Me.editTableGroupBox.Controls.Add(Me.TimeComboBox)
            Me.editTableGroupBox.Controls.Add(Me.MissingAdIdLabel)
            Me.editTableGroupBox.Controls.Add(Me.cancelButton)
            Me.editTableGroupBox.Controls.Add(Me.Label21)
            Me.editTableGroupBox.Controls.Add(Me.Label18)
            Me.editTableGroupBox.Controls.Add(Me.Label17)
            Me.editTableGroupBox.Controls.Add(Me.Label16)
            Me.editTableGroupBox.Controls.Add(Me.Label15)
            Me.editTableGroupBox.Controls.Add(Me.Label14)
            Me.editTableGroupBox.Controls.Add(Me.Label13)
            Me.editTableGroupBox.Controls.Add(Me.Label9)
            Me.editTableGroupBox.Controls.Add(Me.Label8)
            Me.editTableGroupBox.Controls.Add(Me.Label7)
            Me.editTableGroupBox.Controls.Add(Me.Label6)
            Me.editTableGroupBox.Controls.Add(Me.Label5)
            Me.editTableGroupBox.Controls.Add(Me.Label4)
            Me.editTableGroupBox.Controls.Add(Me.Label3)
            Me.editTableGroupBox.Controls.Add(Me.Label2)
            Me.editTableGroupBox.Controls.Add(Me.Label1)
            Me.editTableGroupBox.Controls.Add(Me.CreateTaskLogButton)
            Me.editTableGroupBox.Controls.Add(Me.CommentsTextBox)
            Me.editTableGroupBox.Controls.Add(Me.MissingAdCheckBox)
            Me.editTableGroupBox.Controls.Add(Me.SpecificActionComboBox)
            Me.editTableGroupBox.Controls.Add(Me.ActionTypeComboBox)
            Me.editTableGroupBox.Controls.Add(Me.urgencyComboBox)
            Me.editTableGroupBox.Controls.Add(Me.statusComboBox)
            Me.editTableGroupBox.Controls.Add(Me.PublicationNameComboBox)
            Me.editTableGroupBox.Controls.Add(Me.SenderComboBox)
            Me.editTableGroupBox.Controls.Add(Me.MediaComboBox)
            Me.editTableGroupBox.Controls.Add(Me.MarketComboBox)
            Me.editTableGroupBox.Controls.Add(Me.RetailerComboBox)
            Me.editTableGroupBox.Controls.Add(Me.AssignedComboBox)
            Me.editTableGroupBox.Controls.Add(Me.closeButton)
            Me.editTableGroupBox.Location = New System.Drawing.Point(12, 11)
            Me.editTableGroupBox.Name = "editTableGroupBox"
            Me.editTableGroupBox.Size = New System.Drawing.Size(786, 381)
            Me.editTableGroupBox.TabIndex = 3
            Me.editTableGroupBox.TabStop = False
            Me.editTableGroupBox.Text = "Edit Table: <Table Name>"
            '
            'DeleteButton
            '
            Me.DeleteButton.Anchor = System.Windows.Forms.AnchorStyles.Right
            Me.DeleteButton.Location = New System.Drawing.Point(614, 349)
            Me.DeleteButton.Name = "DeleteButton"
            Me.DeleteButton.Size = New System.Drawing.Size(75, 23)
            Me.DeleteButton.TabIndex = 97
            Me.DeleteButton.Text = "Delete"
            Me.DeleteButton.UseVisualStyleBackColor = True
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.Add(Me.NameTextBox)
            Me.GroupBox2.Controls.Add(Me.PhoneNoTextBox)
            Me.GroupBox2.Controls.Add(Me.PersonSpokeToTextBox)
            Me.GroupBox2.Controls.Add(Me.Label19)
            Me.GroupBox2.Controls.Add(Me.Label20)
            Me.GroupBox2.Controls.Add(Me.Label22)
            Me.GroupBox2.Location = New System.Drawing.Point(3, 264)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(377, 100)
            Me.GroupBox2.TabIndex = 96
            Me.GroupBox2.TabStop = False
            '
            'NameTextBox
            '
            Me.NameTextBox.Enabled = False
            Me.NameTextBox.Location = New System.Drawing.Point(115, 20)
            Me.NameTextBox.Name = "NameTextBox"
            Me.NameTextBox.Size = New System.Drawing.Size(250, 20)
            Me.NameTextBox.TabIndex = 10
            '
            'PhoneNoTextBox
            '
            Me.PhoneNoTextBox.Enabled = False
            Me.PhoneNoTextBox.Location = New System.Drawing.Point(115, 44)
            Me.PhoneNoTextBox.Name = "PhoneNoTextBox"
            Me.PhoneNoTextBox.Size = New System.Drawing.Size(250, 20)
            Me.PhoneNoTextBox.TabIndex = 11
            '
            'PersonSpokeToTextBox
            '
            Me.PersonSpokeToTextBox.Enabled = False
            Me.PersonSpokeToTextBox.Location = New System.Drawing.Point(115, 68)
            Me.PersonSpokeToTextBox.Name = "PersonSpokeToTextBox"
            Me.PersonSpokeToTextBox.Size = New System.Drawing.Size(250, 20)
            Me.PersonSpokeToTextBox.TabIndex = 12
            '
            'Label19
            '
            Me.Label19.Location = New System.Drawing.Point(9, 47)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(94, 13)
            Me.Label19.TabIndex = 64
            Me.Label19.Text = "Phone No Called :"
            Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label20
            '
            Me.Label20.Location = New System.Drawing.Point(3, 71)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(100, 17)
            Me.Label20.TabIndex = 65
            Me.Label20.Text = "Person spoke with :"
            Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label22
            '
            Me.Label22.Location = New System.Drawing.Point(9, 23)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(94, 13)
            Me.Label22.TabIndex = 69
            Me.Label22.Text = "Name :"
            Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'FlashCheckBox
            '
            Me.FlashCheckBox.AutoSize = True
            Me.FlashCheckBox.Location = New System.Drawing.Point(629, 159)
            Me.FlashCheckBox.Name = "FlashCheckBox"
            Me.FlashCheckBox.Size = New System.Drawing.Size(71, 17)
            Me.FlashCheckBox.TabIndex = 95
            Me.FlashCheckBox.Text = "Reminder"
            Me.FlashCheckBox.UseVisualStyleBackColor = True
            Me.FlashCheckBox.Visible = False
            '
            'LastSavedLabel
            '
            Me.LastSavedLabel.AutoSize = True
            Me.LastSavedLabel.Location = New System.Drawing.Point(423, 88)
            Me.LastSavedLabel.Name = "LastSavedLabel"
            Me.LastSavedLabel.Size = New System.Drawing.Size(161, 13)
            Me.LastSavedLabel.TabIndex = 94
            Me.LastSavedLabel.Text = "Last Saved by <person> on date"
            Me.LastSavedLabel.Visible = False
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(370, 196)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(21, 21)
            Me.Button1.TabIndex = 73
            Me.Button1.Text = ".."
            Me.Button1.UseVisualStyleBackColor = True
            '
            'CreatedByLabel
            '
            Me.CreatedByLabel.AutoSize = True
            Me.CreatedByLabel.Location = New System.Drawing.Point(521, 64)
            Me.CreatedByLabel.Name = "CreatedByLabel"
            Me.CreatedByLabel.Size = New System.Drawing.Size(45, 13)
            Me.CreatedByLabel.TabIndex = 72
            Me.CreatedByLabel.Text = "Label11"
            '
            'Label10
            '
            Me.Label10.Location = New System.Drawing.Point(415, 62)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(94, 17)
            Me.Label10.TabIndex = 71
            Me.Label10.Text = "Created By :"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label10.UseCompatibleTextRendering = True
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.SearchButton)
            Me.GroupBox1.Controls.Add(Me.findVehicleIdTextBox)
            Me.GroupBox1.Controls.Add(Me.EditButton)
            Me.GroupBox1.Location = New System.Drawing.Point(520, 13)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(251, 41)
            Me.GroupBox1.TabIndex = 70
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Searc&h on Task ID"
            '
            'SearchButton
            '
            Me.SearchButton.Location = New System.Drawing.Point(148, 13)
            Me.SearchButton.Name = "SearchButton"
            Me.SearchButton.Size = New System.Drawing.Size(95, 23)
            Me.SearchButton.TabIndex = 1
            Me.SearchButton.Text = "&Search"
            Me.SearchButton.UseVisualStyleBackColor = True
            '
            'findVehicleIdTextBox
            '
            Me.findVehicleIdTextBox.Location = New System.Drawing.Point(8, 15)
            Me.findVehicleIdTextBox.Name = "findVehicleIdTextBox"
            Me.findVehicleIdTextBox.Size = New System.Drawing.Size(135, 20)
            Me.findVehicleIdTextBox.TabIndex = 0
            '
            'EditButton
            '
            Me.EditButton.Location = New System.Drawing.Point(150, 12)
            Me.EditButton.Name = "EditButton"
            Me.EditButton.Size = New System.Drawing.Size(75, 23)
            Me.EditButton.TabIndex = 74
            Me.EditButton.Text = "Edit"
            Me.EditButton.UseVisualStyleBackColor = True
            '
            'addateTypeInDatePicker
            '
            Me.m_ErrorProvider.SetIconAlignment(Me.addateTypeInDatePicker, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.addateTypeInDatePicker.Location = New System.Drawing.Point(520, 179)
            Me.addateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.addateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.addateTypeInDatePicker.Name = "addateTypeInDatePicker"
            Me.addateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.addateTypeInDatePicker.TabIndex = 16
            Me.addateTypeInDatePicker.Value = Nothing
            '
            'DueDateTypeInDatePicker
            '
            Me.m_ErrorProvider.SetIconAlignment(Me.DueDateTypeInDatePicker, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.DueDateTypeInDatePicker.Location = New System.Drawing.Point(120, 69)
            Me.DueDateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.DueDateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.DueDateTypeInDatePicker.Name = "DueDateTypeInDatePicker"
            Me.DueDateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.DueDateTypeInDatePicker.TabIndex = 2
            Me.DueDateTypeInDatePicker.Value = Nothing
            '
            'currentdateTypeInDatePicker
            '
            Me.m_ErrorProvider.SetIconAlignment(Me.currentdateTypeInDatePicker, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.currentdateTypeInDatePicker.Location = New System.Drawing.Point(120, 21)
            Me.currentdateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.currentdateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.currentdateTypeInDatePicker.Name = "currentdateTypeInDatePicker"
            Me.currentdateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.currentdateTypeInDatePicker.TabIndex = 0
            Me.currentdateTypeInDatePicker.Value = Nothing
            '
            'OtherContactCheckBox
            '
            Me.OtherContactCheckBox.AutoSize = True
            Me.OtherContactCheckBox.Location = New System.Drawing.Point(9, 247)
            Me.OtherContactCheckBox.Name = "OtherContactCheckBox"
            Me.OtherContactCheckBox.Size = New System.Drawing.Size(92, 17)
            Me.OtherContactCheckBox.TabIndex = 9
            Me.OtherContactCheckBox.Text = "Other Contact"
            Me.OtherContactCheckBox.UseVisualStyleBackColor = True
            '
            'TimeComboBox
            '
            Me.TimeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.TimeComboBox.FormattingEnabled = True
            Me.TimeComboBox.Location = New System.Drawing.Point(120, 45)
            Me.TimeComboBox.Name = "TimeComboBox"
            Me.TimeComboBox.Size = New System.Drawing.Size(250, 21)
            Me.TimeComboBox.TabIndex = 1
            '
            'MissingAdIdLabel
            '
            Me.MissingAdIdLabel.AutoSize = True
            Me.MissingAdIdLabel.Location = New System.Drawing.Point(525, 209)
            Me.MissingAdIdLabel.Name = "MissingAdIdLabel"
            Me.MissingAdIdLabel.Size = New System.Drawing.Size(0, 13)
            Me.MissingAdIdLabel.TabIndex = 16
            '
            'cancelButton
            '
            Me.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Right
            Me.cancelButton.Location = New System.Drawing.Point(695, 349)
            Me.cancelButton.Name = "cancelButton"
            Me.cancelButton.Size = New System.Drawing.Size(75, 23)
            Me.cancelButton.TabIndex = 20
            Me.cancelButton.Text = "Ca&ncel"
            Me.cancelButton.UseVisualStyleBackColor = True
            '
            'Label21
            '
            Me.Label21.Location = New System.Drawing.Point(415, 209)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(94, 13)
            Me.Label21.TabIndex = 66
            Me.Label21.Text = "Task Log Id :"
            Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label18
            '
            Me.Label18.Location = New System.Drawing.Point(415, 280)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(94, 13)
            Me.Label18.TabIndex = 63
            Me.Label18.Text = "Comments :"
            Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label17
            '
            Me.Label17.Location = New System.Drawing.Point(415, 255)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(94, 13)
            Me.Label17.TabIndex = 62
            Me.Label17.Text = "Specific Action :"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label16
            '
            Me.Label16.Location = New System.Drawing.Point(415, 230)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(94, 13)
            Me.Label16.TabIndex = 61
            Me.Label16.Text = "Action Type :"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label15
            '
            Me.Label15.Location = New System.Drawing.Point(415, 185)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(94, 13)
            Me.Label15.TabIndex = 60
            Me.Label15.Text = "Ad Date :"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label14
            '
            Me.Label14.Location = New System.Drawing.Point(415, 138)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(94, 13)
            Me.Label14.TabIndex = 59
            Me.Label14.Text = "Urgency :"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label13
            '
            Me.Label13.Location = New System.Drawing.Point(415, 110)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(94, 13)
            Me.Label13.TabIndex = 58
            Me.Label13.Text = "Status :"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label9
            '
            Me.Label9.Location = New System.Drawing.Point(8, 219)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(100, 18)
            Me.Label9.TabIndex = 54
            Me.Label9.Text = "Publication Name :"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label8
            '
            Me.Label8.Location = New System.Drawing.Point(14, 199)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(94, 13)
            Me.Label8.TabIndex = 53
            Me.Label8.Text = "Sender :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label7
            '
            Me.Label7.Location = New System.Drawing.Point(14, 174)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(94, 13)
            Me.Label7.TabIndex = 52
            Me.Label7.Text = "Media :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.Location = New System.Drawing.Point(14, 147)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(94, 13)
            Me.Label6.TabIndex = 51
            Me.Label6.Text = "Market :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(14, 119)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(94, 13)
            Me.Label5.TabIndex = 50
            Me.Label5.Text = "Retailer :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(14, 95)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(94, 13)
            Me.Label4.TabIndex = 49
            Me.Label4.Text = "Assigned :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(14, 69)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(94, 13)
            Me.Label3.TabIndex = 48
            Me.Label3.Text = "Due Date :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(14, 45)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(94, 13)
            Me.Label2.TabIndex = 47
            Me.Label2.Text = "Time :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(14, 21)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(94, 13)
            Me.Label1.TabIndex = 46
            Me.Label1.Text = "Start Date :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'CreateTaskLogButton
            '
            Me.CreateTaskLogButton.Location = New System.Drawing.Point(533, 349)
            Me.CreateTaskLogButton.Name = "CreateTaskLogButton"
            Me.CreateTaskLogButton.Size = New System.Drawing.Size(75, 23)
            Me.CreateTaskLogButton.TabIndex = 22
            Me.CreateTaskLogButton.Text = "Create"
            Me.CreateTaskLogButton.UseVisualStyleBackColor = True
            '
            'CommentsTextBox
            '
            Me.CommentsTextBox.Location = New System.Drawing.Point(520, 279)
            Me.CommentsTextBox.Multiline = True
            Me.CommentsTextBox.Name = "CommentsTextBox"
            Me.CommentsTextBox.Size = New System.Drawing.Size(250, 67)
            Me.CommentsTextBox.TabIndex = 19
            '
            'MissingAdCheckBox
            '
            Me.MissingAdCheckBox.AutoSize = True
            Me.MissingAdCheckBox.Location = New System.Drawing.Point(521, 159)
            Me.MissingAdCheckBox.Name = "MissingAdCheckBox"
            Me.MissingAdCheckBox.Size = New System.Drawing.Size(77, 17)
            Me.MissingAdCheckBox.TabIndex = 15
            Me.MissingAdCheckBox.Text = "Missing Ad"
            Me.MissingAdCheckBox.UseVisualStyleBackColor = True
            '
            'SpecificActionComboBox
            '
            Me.SpecificActionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.SpecificActionComboBox.FormattingEnabled = True
            Me.SpecificActionComboBox.Location = New System.Drawing.Point(520, 253)
            Me.SpecificActionComboBox.Name = "SpecificActionComboBox"
            Me.SpecificActionComboBox.Size = New System.Drawing.Size(250, 21)
            Me.SpecificActionComboBox.TabIndex = 18
            '
            'ActionTypeComboBox
            '
            Me.ActionTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ActionTypeComboBox.FormattingEnabled = True
            Me.ActionTypeComboBox.Location = New System.Drawing.Point(521, 228)
            Me.ActionTypeComboBox.Name = "ActionTypeComboBox"
            Me.ActionTypeComboBox.Size = New System.Drawing.Size(250, 21)
            Me.ActionTypeComboBox.TabIndex = 17
            '
            'urgencyComboBox
            '
            Me.urgencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.urgencyComboBox.FormattingEnabled = True
            Me.urgencyComboBox.Location = New System.Drawing.Point(521, 135)
            Me.urgencyComboBox.Name = "urgencyComboBox"
            Me.urgencyComboBox.Size = New System.Drawing.Size(250, 21)
            Me.urgencyComboBox.TabIndex = 14
            '
            'statusComboBox
            '
            Me.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.statusComboBox.FormattingEnabled = True
            Me.statusComboBox.Location = New System.Drawing.Point(521, 110)
            Me.statusComboBox.Name = "statusComboBox"
            Me.statusComboBox.Size = New System.Drawing.Size(250, 21)
            Me.statusComboBox.TabIndex = 13
            '
            'PublicationNameComboBox
            '
            Me.PublicationNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.PublicationNameComboBox.FormattingEnabled = True
            Me.PublicationNameComboBox.Location = New System.Drawing.Point(120, 221)
            Me.PublicationNameComboBox.Name = "PublicationNameComboBox"
            Me.PublicationNameComboBox.Size = New System.Drawing.Size(250, 21)
            Me.PublicationNameComboBox.TabIndex = 8
            '
            'SenderComboBox
            '
            Me.SenderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.SenderComboBox.FormattingEnabled = True
            Me.SenderComboBox.Location = New System.Drawing.Point(120, 196)
            Me.SenderComboBox.Name = "SenderComboBox"
            Me.SenderComboBox.Size = New System.Drawing.Size(250, 21)
            Me.SenderComboBox.TabIndex = 7
            '
            'MediaComboBox
            '
            Me.MediaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.MediaComboBox.FormattingEnabled = True
            Me.MediaComboBox.Location = New System.Drawing.Point(120, 170)
            Me.MediaComboBox.Name = "MediaComboBox"
            Me.MediaComboBox.Size = New System.Drawing.Size(250, 21)
            Me.MediaComboBox.TabIndex = 6
            '
            'MarketComboBox
            '
            Me.MarketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.MarketComboBox.FormattingEnabled = True
            Me.MarketComboBox.Location = New System.Drawing.Point(120, 144)
            Me.MarketComboBox.Name = "MarketComboBox"
            Me.MarketComboBox.Size = New System.Drawing.Size(250, 21)
            Me.MarketComboBox.TabIndex = 5
            '
            'RetailerComboBox
            '
            Me.RetailerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.RetailerComboBox.FormattingEnabled = True
            Me.RetailerComboBox.Location = New System.Drawing.Point(120, 118)
            Me.RetailerComboBox.Name = "RetailerComboBox"
            Me.RetailerComboBox.Size = New System.Drawing.Size(250, 21)
            Me.RetailerComboBox.TabIndex = 4
            '
            'AssignedComboBox
            '
            Me.AssignedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.AssignedComboBox.FormattingEnabled = True
            Me.AssignedComboBox.Location = New System.Drawing.Point(120, 92)
            Me.AssignedComboBox.Name = "AssignedComboBox"
            Me.AssignedComboBox.Size = New System.Drawing.Size(250, 21)
            Me.AssignedComboBox.TabIndex = 3
            '
            'closeButton
            '
            Me.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Right
            Me.closeButton.Location = New System.Drawing.Point(610, 301)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(75, 23)
            Me.closeButton.TabIndex = 21
            Me.closeButton.Text = "&Close"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'ParameterDetailsTableAdapter1
            '
            Me.ParameterDetailsTableAdapter1.ClearBeforeFill = True
            '
            'CCTasksLogForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(810, 400)
            Me.Controls.Add(Me.editTableGroupBox)
            Me.Name = "CCTasksLogForm"
            Me.StatusMessage = ""
            Me.Text = "CC Tasks Log Form"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.editTableGroupBox.ResumeLayout(False)
            Me.editTableGroupBox.PerformLayout()
            Me.GroupBox2.ResumeLayout(False)
            Me.GroupBox2.PerformLayout()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents editTableGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents cancelButton As System.Windows.Forms.Button
        Friend WithEvents closeButton As System.Windows.Forms.Button
        Friend WithEvents CreateTaskLogButton As System.Windows.Forms.Button
        Friend WithEvents CommentsTextBox As System.Windows.Forms.TextBox
        Friend WithEvents MissingAdCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents SpecificActionComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents ActionTypeComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents urgencyComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents statusComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents PersonSpokeToTextBox As System.Windows.Forms.TextBox
        Friend WithEvents PhoneNoTextBox As System.Windows.Forms.TextBox
        Friend WithEvents NameTextBox As System.Windows.Forms.TextBox
        Friend WithEvents PublicationNameComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents SenderComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents MediaComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents MarketComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents RetailerComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents AssignedComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents MissingAdIdLabel As System.Windows.Forms.Label
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents TimeComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label22 As System.Windows.Forms.Label
        Friend WithEvents ParameterDetailsTableAdapter1 As MCAP.DESPDataSetTableAdapters.ParameterDetailsTableAdapter
        Friend WithEvents OtherContactCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents addateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents DueDateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents currentdateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents findVehicleIdTextBox As System.Windows.Forms.TextBox
        Friend WithEvents SearchButton As System.Windows.Forms.Button
        Friend WithEvents CreatedByLabel As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents EditButton As System.Windows.Forms.Button
        Friend WithEvents LastSavedLabel As System.Windows.Forms.Label
        Friend WithEvents FlashCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents DeleteButton As System.Windows.Forms.Button

    End Class

End Namespace