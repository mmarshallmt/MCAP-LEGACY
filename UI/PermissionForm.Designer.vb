Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class PermissionForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PermissionForm))
            Me.permissionTabControl = New System.Windows.Forms.TabControl()
            Me.userTabPage = New System.Windows.Forms.TabPage()
            Me.userDataGridView = New System.Windows.Forms.DataGridView()
            Me.userBottomPanel = New System.Windows.Forms.Panel()
            Me.lineLabel = New System.Windows.Forms.Label()
            Me.activeUsersOnlyCheckBox = New System.Windows.Forms.CheckBox()
            Me.userIDValueLabel = New System.Windows.Forms.Label()
            Me.userIDLabel = New System.Windows.Forms.Label()
            Me.userButtonsGroupBox = New System.Windows.Forms.GroupBox()
            Me.userDeleteButton = New System.Windows.Forms.Button()
            Me.userSaveButton = New System.Windows.Forms.Button()
            Me.userEditButton = New System.Windows.Forms.Button()
            Me.locationComboBox = New System.Windows.Forms.ComboBox()
            Me.locationLabel = New System.Windows.Forms.Label()
            Me.lastNameTextBox = New System.Windows.Forms.TextBox()
            Me.lastNameLabel = New System.Windows.Forms.Label()
            Me.firstNameTextBox = New System.Windows.Forms.TextBox()
            Me.firstNameLabel = New System.Windows.Forms.Label()
            Me.activeIndCheckBox = New System.Windows.Forms.CheckBox()
            Me.userNameTextBox = New System.Windows.Forms.TextBox()
            Me.userNameLabel = New System.Windows.Forms.Label()
            Me.roleTabPage = New System.Windows.Forms.TabPage()
            Me.roleDataGridView = New System.Windows.Forms.DataGridView()
            Me.roleBottomPanel = New System.Windows.Forms.Panel()
            Me.roleButtonsGroupBox = New System.Windows.Forms.GroupBox()
            Me.roleDeleteButton = New System.Windows.Forms.Button()
            Me.roleSaveButton = New System.Windows.Forms.Button()
            Me.roleEditButton = New System.Windows.Forms.Button()
            Me.roleNameTextBox = New System.Windows.Forms.TextBox()
            Me.roleNameLabel = New System.Windows.Forms.Label()
            Me.roleIdValueLabel = New System.Windows.Forms.Label()
            Me.roleIdLabel = New System.Windows.Forms.Label()
            Me.rolescreenTabPage = New System.Windows.Forms.TabPage()
            Me.screensDataGridView = New System.Windows.Forms.DataGridView()
            Me.rolescreenTopPanel = New System.Windows.Forms.Panel()
            Me.rolescreenSaveButton = New System.Windows.Forms.Button()
            Me.roleComboBox = New System.Windows.Forms.ComboBox()
            Me.roleLabel = New System.Windows.Forms.Label()
            Me.userroleTabPage = New System.Windows.Forms.TabPage()
            Me.rolesDataGridView = New System.Windows.Forms.DataGridView()
            Me.userroleTopPanel = New System.Windows.Forms.Panel()
            Me.userroleSaveButton = New System.Windows.Forms.Button()
            Me.userComboBox = New System.Windows.Forms.ComboBox()
            Me.userLabel = New System.Windows.Forms.Label()
            Me.bottomPanel = New System.Windows.Forms.Panel()
            Me.closeButton = New System.Windows.Forms.Button()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewComboBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.UserIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.RoleIdDataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            Me.RoleIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.ScreenIdDataGridViewComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.permissionTabControl.SuspendLayout()
            Me.userTabPage.SuspendLayout()
            CType(Me.userDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.userBottomPanel.SuspendLayout()
            Me.userButtonsGroupBox.SuspendLayout()
            Me.roleTabPage.SuspendLayout()
            CType(Me.roleDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.roleBottomPanel.SuspendLayout()
            Me.roleButtonsGroupBox.SuspendLayout()
            Me.rolescreenTabPage.SuspendLayout()
            CType(Me.screensDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.rolescreenTopPanel.SuspendLayout()
            Me.userroleTabPage.SuspendLayout()
            CType(Me.rolesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.userroleTopPanel.SuspendLayout()
            Me.bottomPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'permissionTabControl
            '
            Me.permissionTabControl.Controls.Add(Me.userTabPage)
            Me.permissionTabControl.Controls.Add(Me.roleTabPage)
            Me.permissionTabControl.Controls.Add(Me.rolescreenTabPage)
            Me.permissionTabControl.Controls.Add(Me.userroleTabPage)
            Me.permissionTabControl.Dock = System.Windows.Forms.DockStyle.Fill
            Me.permissionTabControl.Location = New System.Drawing.Point(0, 0)
            Me.permissionTabControl.Name = "permissionTabControl"
            Me.permissionTabControl.SelectedIndex = 0
            Me.permissionTabControl.Size = New System.Drawing.Size(651, 469)
            Me.permissionTabControl.TabIndex = 0
            '
            'userTabPage
            '
            Me.userTabPage.Controls.Add(Me.userDataGridView)
            Me.userTabPage.Controls.Add(Me.userBottomPanel)
            Me.userTabPage.Location = New System.Drawing.Point(4, 22)
            Me.userTabPage.Name = "userTabPage"
            Me.userTabPage.Padding = New System.Windows.Forms.Padding(3)
            Me.userTabPage.Size = New System.Drawing.Size(643, 443)
            Me.userTabPage.TabIndex = 0
            Me.userTabPage.Text = "Users"
            Me.userTabPage.UseVisualStyleBackColor = True
            '
            'userDataGridView
            '
            Me.userDataGridView.AllowUserToAddRows = False
            Me.userDataGridView.AllowUserToDeleteRows = False
            Me.userDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.userDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.userDataGridView.Location = New System.Drawing.Point(3, 3)
            Me.userDataGridView.Name = "userDataGridView"
            Me.userDataGridView.ReadOnly = True
            Me.userDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.userDataGridView.Size = New System.Drawing.Size(637, 255)
            Me.userDataGridView.TabIndex = 0
            '
            'userBottomPanel
            '
            Me.userBottomPanel.Controls.Add(Me.lineLabel)
            Me.userBottomPanel.Controls.Add(Me.activeUsersOnlyCheckBox)
            Me.userBottomPanel.Controls.Add(Me.userIDValueLabel)
            Me.userBottomPanel.Controls.Add(Me.userIDLabel)
            Me.userBottomPanel.Controls.Add(Me.userButtonsGroupBox)
            Me.userBottomPanel.Controls.Add(Me.locationComboBox)
            Me.userBottomPanel.Controls.Add(Me.locationLabel)
            Me.userBottomPanel.Controls.Add(Me.lastNameTextBox)
            Me.userBottomPanel.Controls.Add(Me.lastNameLabel)
            Me.userBottomPanel.Controls.Add(Me.firstNameTextBox)
            Me.userBottomPanel.Controls.Add(Me.firstNameLabel)
            Me.userBottomPanel.Controls.Add(Me.activeIndCheckBox)
            Me.userBottomPanel.Controls.Add(Me.userNameTextBox)
            Me.userBottomPanel.Controls.Add(Me.userNameLabel)
            Me.userBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.userBottomPanel.Location = New System.Drawing.Point(3, 258)
            Me.userBottomPanel.Name = "userBottomPanel"
            Me.userBottomPanel.Size = New System.Drawing.Size(637, 182)
            Me.userBottomPanel.TabIndex = 1
            '
            'lineLabel
            '
            Me.lineLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.lineLabel.BackColor = System.Drawing.SystemColors.ControlText
            Me.lineLabel.Location = New System.Drawing.Point(73, 30)
            Me.lineLabel.MinimumSize = New System.Drawing.Size(0, 1)
            Me.lineLabel.Name = "lineLabel"
            Me.lineLabel.Size = New System.Drawing.Size(490, 1)
            Me.lineLabel.TabIndex = 1
            '
            'activeUsersOnlyCheckBox
            '
            Me.activeUsersOnlyCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.activeUsersOnlyCheckBox.AutoSize = True
            Me.activeUsersOnlyCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.activeUsersOnlyCheckBox.Location = New System.Drawing.Point(70, 12)
            Me.activeUsersOnlyCheckBox.Name = "activeUsersOnlyCheckBox"
            Me.activeUsersOnlyCheckBox.Size = New System.Drawing.Size(138, 17)
            Me.activeUsersOnlyCheckBox.TabIndex = 0
            Me.activeUsersOnlyCheckBox.Text = "Sho&w active users only."
            Me.activeUsersOnlyCheckBox.UseVisualStyleBackColor = True
            '
            'userIDValueLabel
            '
            Me.userIDValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.userIDValueLabel.AutoSize = True
            Me.userIDValueLabel.Location = New System.Drawing.Point(130, 47)
            Me.userIDValueLabel.Name = "userIDValueLabel"
            Me.userIDValueLabel.Size = New System.Drawing.Size(55, 13)
            Me.userIDValueLabel.TabIndex = 3
            Me.userIDValueLabel.Text = "<User ID>"
            '
            'userIDLabel
            '
            Me.userIDLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.userIDLabel.AutoSize = True
            Me.userIDLabel.Location = New System.Drawing.Point(84, 47)
            Me.userIDLabel.Name = "userIDLabel"
            Me.userIDLabel.Size = New System.Drawing.Size(43, 13)
            Me.userIDLabel.TabIndex = 2
            Me.userIDLabel.Text = "User ID"
            '
            'userButtonsGroupBox
            '
            Me.userButtonsGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.userButtonsGroupBox.Controls.Add(Me.userDeleteButton)
            Me.userButtonsGroupBox.Controls.Add(Me.userSaveButton)
            Me.userButtonsGroupBox.Controls.Add(Me.userEditButton)
            Me.userButtonsGroupBox.Location = New System.Drawing.Point(194, 123)
            Me.userButtonsGroupBox.Name = "userButtonsGroupBox"
            Me.userButtonsGroupBox.Size = New System.Drawing.Size(249, 49)
            Me.userButtonsGroupBox.TabIndex = 13
            Me.userButtonsGroupBox.TabStop = False
            '
            'userDeleteButton
            '
            Me.userDeleteButton.Location = New System.Drawing.Point(168, 20)
            Me.userDeleteButton.Name = "userDeleteButton"
            Me.userDeleteButton.Size = New System.Drawing.Size(75, 23)
            Me.userDeleteButton.TabIndex = 2
            Me.userDeleteButton.Text = "&Delete"
            Me.userDeleteButton.UseVisualStyleBackColor = True
            '
            'userSaveButton
            '
            Me.userSaveButton.Location = New System.Drawing.Point(87, 20)
            Me.userSaveButton.Name = "userSaveButton"
            Me.userSaveButton.Size = New System.Drawing.Size(75, 23)
            Me.userSaveButton.TabIndex = 1
            Me.userSaveButton.Text = "&Save"
            Me.userSaveButton.UseVisualStyleBackColor = True
            '
            'userEditButton
            '
            Me.userEditButton.Location = New System.Drawing.Point(6, 20)
            Me.userEditButton.Name = "userEditButton"
            Me.userEditButton.Size = New System.Drawing.Size(75, 23)
            Me.userEditButton.TabIndex = 0
            Me.userEditButton.Text = "&Edit"
            Me.userEditButton.UseVisualStyleBackColor = True
            '
            'locationComboBox
            '
            Me.locationComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.locationComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.locationComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.locationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.locationComboBox.Location = New System.Drawing.Point(133, 96)
            Me.locationComboBox.Name = "locationComboBox"
            Me.locationComboBox.Size = New System.Drawing.Size(176, 21)
            Me.locationComboBox.TabIndex = 11
            '
            'locationLabel
            '
            Me.locationLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.locationLabel.AutoSize = True
            Me.locationLabel.Location = New System.Drawing.Point(79, 99)
            Me.locationLabel.Name = "locationLabel"
            Me.locationLabel.Size = New System.Drawing.Size(48, 13)
            Me.locationLabel.TabIndex = 10
            Me.locationLabel.Text = "Lo&cation"
            '
            'lastNameTextBox
            '
            Me.lastNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.lastNameTextBox.Location = New System.Drawing.Point(390, 70)
            Me.lastNameTextBox.Name = "lastNameTextBox"
            Me.lastNameTextBox.Size = New System.Drawing.Size(176, 20)
            Me.lastNameTextBox.TabIndex = 9
            '
            'lastNameLabel
            '
            Me.lastNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.lastNameLabel.AutoSize = True
            Me.lastNameLabel.Location = New System.Drawing.Point(326, 73)
            Me.lastNameLabel.Name = "lastNameLabel"
            Me.lastNameLabel.Size = New System.Drawing.Size(58, 13)
            Me.lastNameLabel.TabIndex = 8
            Me.lastNameLabel.Text = "&Last Name"
            '
            'firstNameTextBox
            '
            Me.firstNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.firstNameTextBox.Location = New System.Drawing.Point(133, 70)
            Me.firstNameTextBox.Name = "firstNameTextBox"
            Me.firstNameTextBox.Size = New System.Drawing.Size(176, 20)
            Me.firstNameTextBox.TabIndex = 7
            '
            'firstNameLabel
            '
            Me.firstNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.firstNameLabel.AutoSize = True
            Me.firstNameLabel.Location = New System.Drawing.Point(70, 73)
            Me.firstNameLabel.Name = "firstNameLabel"
            Me.firstNameLabel.Size = New System.Drawing.Size(57, 13)
            Me.firstNameLabel.TabIndex = 6
            Me.firstNameLabel.Text = "&First Name"
            '
            'activeIndCheckBox
            '
            Me.activeIndCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.activeIndCheckBox.AutoSize = True
            Me.activeIndCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.activeIndCheckBox.Checked = True
            Me.activeIndCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
            Me.activeIndCheckBox.Location = New System.Drawing.Point(349, 98)
            Me.activeIndCheckBox.Name = "activeIndCheckBox"
            Me.activeIndCheckBox.Size = New System.Drawing.Size(56, 17)
            Me.activeIndCheckBox.TabIndex = 12
            Me.activeIndCheckBox.Text = "&Active"
            Me.activeIndCheckBox.UseVisualStyleBackColor = True
            '
            'userNameTextBox
            '
            Me.userNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.userNameTextBox.Location = New System.Drawing.Point(390, 44)
            Me.userNameTextBox.Name = "userNameTextBox"
            Me.userNameTextBox.Size = New System.Drawing.Size(176, 20)
            Me.userNameTextBox.TabIndex = 5
            '
            'userNameLabel
            '
            Me.userNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.userNameLabel.AutoSize = True
            Me.userNameLabel.Location = New System.Drawing.Point(324, 47)
            Me.userNameLabel.Name = "userNameLabel"
            Me.userNameLabel.Size = New System.Drawing.Size(60, 13)
            Me.userNameLabel.TabIndex = 4
            Me.userNameLabel.Text = "User &Name"
            '
            'roleTabPage
            '
            Me.roleTabPage.Controls.Add(Me.roleDataGridView)
            Me.roleTabPage.Controls.Add(Me.roleBottomPanel)
            Me.roleTabPage.Location = New System.Drawing.Point(4, 22)
            Me.roleTabPage.Name = "roleTabPage"
            Me.roleTabPage.Padding = New System.Windows.Forms.Padding(3)
            Me.roleTabPage.Size = New System.Drawing.Size(643, 443)
            Me.roleTabPage.TabIndex = 1
            Me.roleTabPage.Text = "Roles"
            Me.roleTabPage.UseVisualStyleBackColor = True
            '
            'roleDataGridView
            '
            Me.roleDataGridView.AllowUserToAddRows = False
            Me.roleDataGridView.AllowUserToDeleteRows = False
            Me.roleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.roleDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.roleDataGridView.Location = New System.Drawing.Point(3, 3)
            Me.roleDataGridView.Name = "roleDataGridView"
            Me.roleDataGridView.ReadOnly = True
            Me.roleDataGridView.Size = New System.Drawing.Size(637, 321)
            Me.roleDataGridView.TabIndex = 16
            '
            'roleBottomPanel
            '
            Me.roleBottomPanel.Controls.Add(Me.roleButtonsGroupBox)
            Me.roleBottomPanel.Controls.Add(Me.roleNameTextBox)
            Me.roleBottomPanel.Controls.Add(Me.roleNameLabel)
            Me.roleBottomPanel.Controls.Add(Me.roleIdValueLabel)
            Me.roleBottomPanel.Controls.Add(Me.roleIdLabel)
            Me.roleBottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.roleBottomPanel.Location = New System.Drawing.Point(3, 324)
            Me.roleBottomPanel.Name = "roleBottomPanel"
            Me.roleBottomPanel.Size = New System.Drawing.Size(637, 116)
            Me.roleBottomPanel.TabIndex = 17
            '
            'roleButtonsGroupBox
            '
            Me.roleButtonsGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.roleButtonsGroupBox.Controls.Add(Me.roleDeleteButton)
            Me.roleButtonsGroupBox.Controls.Add(Me.roleSaveButton)
            Me.roleButtonsGroupBox.Controls.Add(Me.roleEditButton)
            Me.roleButtonsGroupBox.Location = New System.Drawing.Point(194, 55)
            Me.roleButtonsGroupBox.Name = "roleButtonsGroupBox"
            Me.roleButtonsGroupBox.Size = New System.Drawing.Size(249, 49)
            Me.roleButtonsGroupBox.TabIndex = 19
            Me.roleButtonsGroupBox.TabStop = False
            '
            'roleDeleteButton
            '
            Me.roleDeleteButton.Location = New System.Drawing.Point(168, 20)
            Me.roleDeleteButton.Name = "roleDeleteButton"
            Me.roleDeleteButton.Size = New System.Drawing.Size(75, 23)
            Me.roleDeleteButton.TabIndex = 21
            Me.roleDeleteButton.Text = "&Delete"
            Me.roleDeleteButton.UseVisualStyleBackColor = True
            '
            'roleSaveButton
            '
            Me.roleSaveButton.Location = New System.Drawing.Point(87, 20)
            Me.roleSaveButton.Name = "roleSaveButton"
            Me.roleSaveButton.Size = New System.Drawing.Size(75, 23)
            Me.roleSaveButton.TabIndex = 20
            Me.roleSaveButton.Text = "&Save"
            Me.roleSaveButton.UseVisualStyleBackColor = True
            '
            'roleEditButton
            '
            Me.roleEditButton.Location = New System.Drawing.Point(6, 20)
            Me.roleEditButton.Name = "roleEditButton"
            Me.roleEditButton.Size = New System.Drawing.Size(75, 23)
            Me.roleEditButton.TabIndex = 19
            Me.roleEditButton.Text = "&Edit"
            Me.roleEditButton.UseVisualStyleBackColor = True
            '
            'roleNameTextBox
            '
            Me.roleNameTextBox.Location = New System.Drawing.Point(59, 29)
            Me.roleNameTextBox.Name = "roleNameTextBox"
            Me.roleNameTextBox.Size = New System.Drawing.Size(311, 20)
            Me.roleNameTextBox.TabIndex = 14
            '
            'roleNameLabel
            '
            Me.roleNameLabel.AutoSize = True
            Me.roleNameLabel.Location = New System.Drawing.Point(13, 32)
            Me.roleNameLabel.Name = "roleNameLabel"
            Me.roleNameLabel.Size = New System.Drawing.Size(35, 13)
            Me.roleNameLabel.TabIndex = 13
            Me.roleNameLabel.Text = "&Name"
            '
            'roleIdValueLabel
            '
            Me.roleIdValueLabel.AutoSize = True
            Me.roleIdValueLabel.Location = New System.Drawing.Point(59, 12)
            Me.roleIdValueLabel.Name = "roleIdValueLabel"
            Me.roleIdValueLabel.Size = New System.Drawing.Size(53, 13)
            Me.roleIdValueLabel.TabIndex = 12
            Me.roleIdValueLabel.Text = "<Role Id>"
            '
            'roleIdLabel
            '
            Me.roleIdLabel.AutoSize = True
            Me.roleIdLabel.Location = New System.Drawing.Point(12, 12)
            Me.roleIdLabel.Name = "roleIdLabel"
            Me.roleIdLabel.Size = New System.Drawing.Size(41, 13)
            Me.roleIdLabel.TabIndex = 11
            Me.roleIdLabel.Text = "Role Id"
            '
            'rolescreenTabPage
            '
            Me.rolescreenTabPage.Controls.Add(Me.screensDataGridView)
            Me.rolescreenTabPage.Controls.Add(Me.rolescreenTopPanel)
            Me.rolescreenTabPage.Location = New System.Drawing.Point(4, 22)
            Me.rolescreenTabPage.Name = "rolescreenTabPage"
            Me.rolescreenTabPage.Padding = New System.Windows.Forms.Padding(3)
            Me.rolescreenTabPage.Size = New System.Drawing.Size(643, 443)
            Me.rolescreenTabPage.TabIndex = 2
            Me.rolescreenTabPage.Text = "Role - Screen Association"
            Me.rolescreenTabPage.UseVisualStyleBackColor = True
            '
            'screensDataGridView
            '
            Me.screensDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.screensDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RoleIdDataGridViewTextBoxColumn, Me.ScreenIdDataGridViewComboBoxColumn})
            Me.screensDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.screensDataGridView.Location = New System.Drawing.Point(3, 46)
            Me.screensDataGridView.Name = "screensDataGridView"
            Me.screensDataGridView.Size = New System.Drawing.Size(637, 394)
            Me.screensDataGridView.TabIndex = 5
            '
            'rolescreenTopPanel
            '
            Me.rolescreenTopPanel.Controls.Add(Me.rolescreenSaveButton)
            Me.rolescreenTopPanel.Controls.Add(Me.roleComboBox)
            Me.rolescreenTopPanel.Controls.Add(Me.roleLabel)
            Me.rolescreenTopPanel.Dock = System.Windows.Forms.DockStyle.Top
            Me.rolescreenTopPanel.Location = New System.Drawing.Point(3, 3)
            Me.rolescreenTopPanel.Name = "rolescreenTopPanel"
            Me.rolescreenTopPanel.Size = New System.Drawing.Size(637, 43)
            Me.rolescreenTopPanel.TabIndex = 4
            '
            'rolescreenSaveButton
            '
            Me.rolescreenSaveButton.Location = New System.Drawing.Point(388, 10)
            Me.rolescreenSaveButton.Name = "rolescreenSaveButton"
            Me.rolescreenSaveButton.Size = New System.Drawing.Size(75, 23)
            Me.rolescreenSaveButton.TabIndex = 2
            Me.rolescreenSaveButton.Text = "&Save"
            Me.rolescreenSaveButton.UseVisualStyleBackColor = True
            '
            'roleComboBox
            '
            Me.roleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.roleComboBox.FormattingEnabled = True
            Me.roleComboBox.Location = New System.Drawing.Point(57, 12)
            Me.roleComboBox.Name = "roleComboBox"
            Me.roleComboBox.Size = New System.Drawing.Size(325, 21)
            Me.roleComboBox.TabIndex = 1
            '
            'roleLabel
            '
            Me.roleLabel.AutoSize = True
            Me.roleLabel.Location = New System.Drawing.Point(12, 15)
            Me.roleLabel.Name = "roleLabel"
            Me.roleLabel.Size = New System.Drawing.Size(29, 13)
            Me.roleLabel.TabIndex = 0
            Me.roleLabel.Text = "&Role"
            '
            'userroleTabPage
            '
            Me.userroleTabPage.Controls.Add(Me.rolesDataGridView)
            Me.userroleTabPage.Controls.Add(Me.userroleTopPanel)
            Me.userroleTabPage.Location = New System.Drawing.Point(4, 22)
            Me.userroleTabPage.Name = "userroleTabPage"
            Me.userroleTabPage.Padding = New System.Windows.Forms.Padding(3)
            Me.userroleTabPage.Size = New System.Drawing.Size(643, 443)
            Me.userroleTabPage.TabIndex = 3
            Me.userroleTabPage.Text = "User - Role Association"
            Me.userroleTabPage.UseVisualStyleBackColor = True
            '
            'rolesDataGridView
            '
            Me.rolesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.rolesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UserIdDataGridViewTextBoxColumn, Me.RoleIdDataGridViewComboBoxColumn})
            Me.rolesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.rolesDataGridView.Location = New System.Drawing.Point(3, 46)
            Me.rolesDataGridView.Name = "rolesDataGridView"
            Me.rolesDataGridView.Size = New System.Drawing.Size(637, 394)
            Me.rolesDataGridView.TabIndex = 3
            '
            'userroleTopPanel
            '
            Me.userroleTopPanel.Controls.Add(Me.userroleSaveButton)
            Me.userroleTopPanel.Controls.Add(Me.userComboBox)
            Me.userroleTopPanel.Controls.Add(Me.userLabel)
            Me.userroleTopPanel.Dock = System.Windows.Forms.DockStyle.Top
            Me.userroleTopPanel.Location = New System.Drawing.Point(3, 3)
            Me.userroleTopPanel.Name = "userroleTopPanel"
            Me.userroleTopPanel.Size = New System.Drawing.Size(637, 43)
            Me.userroleTopPanel.TabIndex = 2
            '
            'userroleSaveButton
            '
            Me.userroleSaveButton.Location = New System.Drawing.Point(388, 10)
            Me.userroleSaveButton.Name = "userroleSaveButton"
            Me.userroleSaveButton.Size = New System.Drawing.Size(75, 23)
            Me.userroleSaveButton.TabIndex = 5
            Me.userroleSaveButton.Text = "&Save"
            Me.userroleSaveButton.UseVisualStyleBackColor = True
            '
            'userComboBox
            '
            Me.userComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.userComboBox.FormattingEnabled = True
            Me.userComboBox.Location = New System.Drawing.Point(57, 12)
            Me.userComboBox.Name = "userComboBox"
            Me.userComboBox.Size = New System.Drawing.Size(325, 21)
            Me.userComboBox.TabIndex = 4
            '
            'userLabel
            '
            Me.userLabel.AutoSize = True
            Me.userLabel.Location = New System.Drawing.Point(12, 15)
            Me.userLabel.Name = "userLabel"
            Me.userLabel.Size = New System.Drawing.Size(29, 13)
            Me.userLabel.TabIndex = 3
            Me.userLabel.Text = "&User"
            '
            'bottomPanel
            '
            Me.bottomPanel.Controls.Add(Me.closeButton)
            Me.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.bottomPanel.Location = New System.Drawing.Point(0, 469)
            Me.bottomPanel.Name = "bottomPanel"
            Me.bottomPanel.Size = New System.Drawing.Size(651, 49)
            Me.bottomPanel.TabIndex = 1
            '
            'closeButton
            '
            Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.closeButton.Location = New System.Drawing.Point(564, 14)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(75, 23)
            Me.closeButton.TabIndex = 4
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.HeaderText = "RoleId"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.Visible = False
            '
            'DataGridViewComboBoxColumn1
            '
            Me.DataGridViewComboBoxColumn1.HeaderText = "Screen"
            Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
            Me.DataGridViewComboBoxColumn1.Sorted = True
            Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.HeaderText = "UserId"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.Visible = False
            '
            'DataGridViewComboBoxColumn2
            '
            Me.DataGridViewComboBoxColumn2.HeaderText = "Role"
            Me.DataGridViewComboBoxColumn2.Name = "DataGridViewComboBoxColumn2"
            '
            'UserIdDataGridViewTextBoxColumn
            '
            Me.UserIdDataGridViewTextBoxColumn.HeaderText = "UserId"
            Me.UserIdDataGridViewTextBoxColumn.Name = "UserIdDataGridViewTextBoxColumn"
            Me.UserIdDataGridViewTextBoxColumn.Visible = False
            '
            'RoleIdDataGridViewComboBoxColumn
            '
            Me.RoleIdDataGridViewComboBoxColumn.HeaderText = "Role"
            Me.RoleIdDataGridViewComboBoxColumn.Name = "RoleIdDataGridViewComboBoxColumn"
            '
            'RoleIdDataGridViewTextBoxColumn
            '
            Me.RoleIdDataGridViewTextBoxColumn.HeaderText = "RoleId"
            Me.RoleIdDataGridViewTextBoxColumn.Name = "RoleIdDataGridViewTextBoxColumn"
            Me.RoleIdDataGridViewTextBoxColumn.Visible = False
            '
            'ScreenIdDataGridViewComboBoxColumn
            '
            Me.ScreenIdDataGridViewComboBoxColumn.HeaderText = "Screen"
            Me.ScreenIdDataGridViewComboBoxColumn.Name = "ScreenIdDataGridViewComboBoxColumn"
            Me.ScreenIdDataGridViewComboBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
            '
            'PermissionForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(651, 518)
            Me.Controls.Add(Me.permissionTabControl)
            Me.Controls.Add(Me.bottomPanel)
            Me.Name = "PermissionForm"
            Me.StatusMessage = ""
            Me.Text = "Permissions"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.permissionTabControl.ResumeLayout(False)
            Me.userTabPage.ResumeLayout(False)
            CType(Me.userDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.userBottomPanel.ResumeLayout(False)
            Me.userBottomPanel.PerformLayout()
            Me.userButtonsGroupBox.ResumeLayout(False)
            Me.roleTabPage.ResumeLayout(False)
            CType(Me.roleDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.roleBottomPanel.ResumeLayout(False)
            Me.roleBottomPanel.PerformLayout()
            Me.roleButtonsGroupBox.ResumeLayout(False)
            Me.rolescreenTabPage.ResumeLayout(False)
            CType(Me.screensDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.rolescreenTopPanel.ResumeLayout(False)
            Me.rolescreenTopPanel.PerformLayout()
            Me.userroleTabPage.ResumeLayout(False)
            CType(Me.rolesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.userroleTopPanel.ResumeLayout(False)
            Me.userroleTopPanel.PerformLayout()
            Me.bottomPanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
    Friend WithEvents permissionTabControl As System.Windows.Forms.TabControl
    Friend WithEvents userTabPage As System.Windows.Forms.TabPage
    Friend WithEvents roleTabPage As System.Windows.Forms.TabPage
    Friend WithEvents rolescreenTabPage As System.Windows.Forms.TabPage
    Friend WithEvents userroleTabPage As System.Windows.Forms.TabPage
    Friend WithEvents userDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents userBottomPanel As System.Windows.Forms.Panel
    Friend WithEvents lineLabel As System.Windows.Forms.Label
    Friend WithEvents activeUsersOnlyCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents userIDValueLabel As System.Windows.Forms.Label
    Friend WithEvents userIDLabel As System.Windows.Forms.Label
    Friend WithEvents userButtonsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents userDeleteButton As System.Windows.Forms.Button
    Friend WithEvents userSaveButton As System.Windows.Forms.Button
    Friend WithEvents userEditButton As System.Windows.Forms.Button
    Friend WithEvents locationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents locationLabel As System.Windows.Forms.Label
    Friend WithEvents lastNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents lastNameLabel As System.Windows.Forms.Label
    Friend WithEvents firstNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents firstNameLabel As System.Windows.Forms.Label
    Friend WithEvents activeIndCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents userNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents userNameLabel As System.Windows.Forms.Label
    Friend WithEvents roleDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents roleBottomPanel As System.Windows.Forms.Panel
    Friend WithEvents roleButtonsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents roleDeleteButton As System.Windows.Forms.Button
    Friend WithEvents roleSaveButton As System.Windows.Forms.Button
    Friend WithEvents roleEditButton As System.Windows.Forms.Button
    Friend WithEvents roleNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents roleNameLabel As System.Windows.Forms.Label
    Friend WithEvents roleIdValueLabel As System.Windows.Forms.Label
    Friend WithEvents roleIdLabel As System.Windows.Forms.Label
    Friend WithEvents bottomPanel As System.Windows.Forms.Panel
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents screensDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents rolescreenTopPanel As System.Windows.Forms.Panel
    Friend WithEvents rolescreenSaveButton As System.Windows.Forms.Button
    Friend WithEvents roleComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents roleLabel As System.Windows.Forms.Label
    Friend WithEvents rolesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents userroleTopPanel As System.Windows.Forms.Panel
    Friend WithEvents userroleSaveButton As System.Windows.Forms.Button
    Friend WithEvents userComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents userLabel As System.Windows.Forms.Label
        Friend WithEvents UserIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RoleIdDataGridViewComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents RoleIdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents ScreenIdDataGridViewComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewComboBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewComboBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn

  End Class

End Namespace