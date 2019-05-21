Namespace UI

  Public Class PermissionForm
    Implements IForm


    Private m_userTabFormState As UI.FormStateEnum
    Private m_roleTabFormState As UI.FormStateEnum
    Private m_rolescreenTabFormState As UI.FormStateEnum
    Private m_userroleTabFormState As UI.FormStateEnum

    Private WithEvents m_userProcessor As UI.Processors.User
    Private WithEvents m_roleProcessor As UI.Processors.Role
    Private WithEvents m_screenRolesTable As RoleDataSet.ScreenRolesDataTable
    Private WithEvents m_userRolesTable As UserRolesDataSet.UserRolesDataTable


    ''' <summary>
    ''' 
    ''' </summary>
    Private ReadOnly Property UserProcessor() As UI.Processors.User
      Get
        Return m_userProcessor
      End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    Private ReadOnly Property RoleProcessor() As UI.Processors.Role
      Get
        Return m_roleProcessor
      End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    Private Property UserTab_FormState() As UI.FormStateEnum
      Get
        Return m_userTabFormState
      End Get
      Set(ByVal value As UI.FormStateEnum)
        m_userTabFormState = value
      End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    Private Property RoleTab_FormState() As UI.FormStateEnum
      Get
        Return m_roleTabFormState
      End Get
      Set(ByVal value As UI.FormStateEnum)
        m_roleTabFormState = value
      End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    Private Property RoleScreenTab_FormState() As UI.FormStateEnum
      Get
        Return m_rolescreenTabFormState
      End Get
      Set(ByVal value As UI.FormStateEnum)
        m_rolescreenTabFormState = value
      End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    Private Property UserRoleTab_FormState() As UI.FormStateEnum
      Get
        Return m_userroleTabFormState
      End Get
      Set(ByVal value As UI.FormStateEnum)
        m_userroleTabFormState = value
      End Set
    End Property



#Region " IForm Implementation "


    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied
    Public Event InitializingForm() Implements IForm.InitializingForm
    Public Event FormInitialized() Implements IForm.FormInitialized


    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

    End Sub


    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

      m_userProcessor = New UI.Processors.User()
      m_roleProcessor = New UI.Processors.Role()

      m_userProcessor.Initialize()
      m_roleProcessor.Initialize()

      Me.UserTab_FormState = formStatus
      Me.RoleTab_FormState = formStatus
      Me.RoleScreenTab_FormState = formStatus
      Me.UserRoleTab_FormState = formStatus

    End Sub


#End Region


    Protected Overrides Sub ClearAllInputs()
      MyBase.ClearAllInputs()
    End Sub

    Protected Overrides Sub RemoveAllErrorProviders()
      MyBase.RemoveAllErrorProviders()
    End Sub

    Protected Overrides Sub ShowHideControls(ByVal formStatus As FormStateEnum)
      MyBase.ShowHideControls(formStatus)
    End Sub

    Protected Overrides Sub EnableDisableControls(ByVal formStatus As FormStateEnum)
      MyBase.EnableDisableControls(formStatus)
    End Sub


    Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click

      Me.Close()

    End Sub


#Region " User TabPage "


    Private Sub UserTab_ClearAllInputs()

      userIDValueLabel.Text = String.Empty
      userNameTextBox.Clear()
      firstNameTextBox.Clear()
      lastNameTextBox.Clear()
      activeIndCheckBox.Checked = True
      locationComboBox.Text = String.Empty
      locationComboBox.SelectedIndex = -1
      locationComboBox.SelectedValue = DBNull.Value

    End Sub

    Private Sub UserTab_RemoveAllErrorProviders()

      Me.RemoveErrorProvider(userNameTextBox)
      Me.RemoveErrorProvider(firstNameTextBox)
      Me.RemoveErrorProvider(lastNameTextBox)
      Me.RemoveErrorProvider(locationComboBox)

    End Sub

    Private Sub UserTab_ShowHideControls(ByVal formStatus As FormStateEnum)

    End Sub

    Private Sub UserTab_EnableDisableControls(ByVal formStatus As FormStateEnum)

      Select Case formStatus
        Case FormStateEnum.View
          userNameTextBox.ReadOnly = True
          firstNameTextBox.ReadOnly = True
          lastNameTextBox.ReadOnly = True
          locationComboBox.Enabled = False
          activeIndCheckBox.Enabled = False
          userEditButton.Enabled = True

        Case FormStateEnum.Edit
          userNameTextBox.ReadOnly = False
          firstNameTextBox.ReadOnly = False
          lastNameTextBox.ReadOnly = False
          locationComboBox.Enabled = True
          activeIndCheckBox.Enabled = True
          userEditButton.Enabled = False

        Case FormStateEnum.Insert
          userNameTextBox.ReadOnly = False
          firstNameTextBox.ReadOnly = False
          lastNameTextBox.ReadOnly = False
          locationComboBox.Enabled = True
          activeIndCheckBox.Enabled = True
          userEditButton.Enabled = True
      End Select

    End Sub

    ''' <summary>
    ''' Showing error popup to user based on error texts assigned to each column.
    ''' </summary>
    ''' <param name="userRow"></param>
    ''' <remarks></remarks>
    Private Sub ShowErrors(ByVal userRow As MCAP.UserRolesDataSet.UserRow)
      Dim columnCounter As Integer
      Dim errorMessage As System.Text.StringBuilder
      Dim errorCols() As Data.DataColumn


      If userRow.HasErrors = False Then Exit Sub

      errorMessage = New System.Text.StringBuilder

      If String.IsNullOrEmpty(userRow.RowError) = False Then
        errorMessage.Append(userRow.RowError)
      Else
        errorCols = userRow.GetColumnsInError()

        errorMessage.Append("Invalid inputs found.")
        errorMessage.Append(Environment.NewLine)
        For columnCounter = 0 To errorCols.Length - 1
          errorMessage.Append(Environment.NewLine)
          errorMessage.Append(errorCols(columnCounter).Caption)
          errorMessage.Append(" - ")
          errorMessage.Append(userRow.GetColumnError(errorCols(columnCounter)))
        Next

        System.Array.Clear(errorCols, 0, errorCols.Length)
      End If

      MessageBox.Show(errorMessage.ToString(), Application.ProductName, _
                      MessageBoxButtons.OK, MessageBoxIcon.Error)

      errorMessage = Nothing
      errorCols = Nothing

    End Sub

    Private Function UserTab_ValidateInputs(ByVal formStatus As FormStateEnum) As Boolean
      Dim areInputsValid As Boolean


      areInputsValid = True

      If userNameTextBox.Text.Trim().Length = 0 Then
        Me.SetErrorProvider(userNameTextBox, "User name is required.")
        areInputsValid = False
      End If

      If firstNameTextBox.Text.Trim().Length = 0 Then
                Me.SetErrorProvider(firstNameTextBox, "First name is required.")
        areInputsValid = False
      End If

      If lastNameTextBox.Text.Trim().Length = 0 Then
                Me.SetErrorProvider(lastNameTextBox, "Last name is required.")
        areInputsValid = False
      End If

      Return areInputsValid

    End Function

    Private Sub UserTab_ShowUserInformation(ByVal userRow As UserRolesDataSet.UserRow)
      Me.userIDValueLabel.Text = userRow.UserID.ToString()
      Me.userNameTextBox.Text = userRow.Username
      Me.firstNameTextBox.Text = userRow.FName
      If userRow.IsLNameNull() Then
        Me.lastNameTextBox.Text = ""
      Else
        Me.lastNameTextBox.Text = userRow.LName
      End If
      Me.locationComboBox.SelectedValue = userRow.LocationId
      If userRow.ActiveInd = 0 Then
        Me.activeIndCheckBox.Checked = False
      Else
        Me.activeIndCheckBox.Checked = True
      End If
    End Sub

    Private Sub UserTab_WriteUserInformation(ByVal userRow As UserRolesDataSet.UserRow)
      userRow.Username = Me.userNameTextBox.Text
      userRow.FName = Me.firstNameTextBox.Text
      userRow.LName = Me.lastNameTextBox.Text
      If Me.locationComboBox.SelectedValue Is Nothing Then
        userRow.SetLocationIdNull()
      Else
        userRow.LocationId = CType(Me.locationComboBox.SelectedValue, Integer)
      End If
      If Me.activeIndCheckBox.Checked Then
        userRow.ActiveInd = 1
        userRow.Active = "Yes"
      Else
        userRow.ActiveInd = 0
        userRow.Active = "No"
      End If
    End Sub


    Private Sub userTabPage_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles userTabPage.Enter

      If Me.UserTab_FormState <> FormStateEnum.View Then Exit Sub

      locationComboBox.DisplayMember = "Descrip"
      locationComboBox.ValueMember = "CodeId"
      locationComboBox.DataSource = UserProcessor.UserDataSet.vwLocation

      userDataGridView.DataSource = UserProcessor.UserDataSet.User
      With userDataGridView
        .Columns("UserId").Visible = False
        .Columns("FName").HeaderText = "First Name"
        .Columns("LName").HeaderText = "Last Name"
        .Columns("LocationId").Visible = False
        .Columns("ActiveInd").Visible = False
      End With

      If UserProcessor.UserDataSet.User.Count = 0 Then activeUsersOnlyCheckBox.Checked = True

      UserTab_ClearAllInputs()
      UserTab_FormState = FormStateEnum.Insert
      UserTab_ShowHideControls(Me.UserTab_FormState)
      UserTab_EnableDisableControls(Me.UserTab_FormState)

    End Sub

    Private Sub userDataGridView_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles userDataGridView.Resize
      Dim columnSize As Integer
      Dim columnsQuery As System.Collections.Generic.IEnumerable(Of System.Windows.Forms.DataGridViewColumn)


      columnsQuery = From col In userDataGridView.Columns.Cast(Of System.Windows.Forms.DataGridViewColumn)() _
                     Where col.Visible = True _
                     Select col

      If columnsQuery.Count() = 0 Then
        columnsQuery = Nothing
        Exit Sub
      End If

      columnSize = userDataGridView.ClientSize.Width \ columnsQuery.Count()
      If columnSize < 100 Then columnSize = 100

      For i As Integer = 0 To columnsQuery.Count() - 1
        columnsQuery(i).Width = columnSize
      Next

      columnsQuery = Nothing
    End Sub

    Private Sub userDataGridView_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles userDataGridView.RowValidated

      If Me.UserTab_FormState = FormStateEnum.Edit Then
        UserTab_ClearAllInputs()
        UserTab_RemoveAllErrorProviders()
        Me.UserTab_FormState = FormStateEnum.Insert
        UserTab_ShowHideControls(Me.UserTab_FormState)
        UserTab_EnableDisableControls(Me.UserTab_FormState)
      End If

    End Sub

    Private Sub activeUsersOnlyCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles activeUsersOnlyCheckBox.CheckedChanged

      If activeUsersOnlyCheckBox.Checked Then
        UserProcessor.LoadActiveUsersOnly()
      Else
        UserProcessor.LoadAllUsers()
      End If

    End Sub

    Private Sub userEditButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles userEditButton.Click
      Dim bmb As BindingManagerBase
      Dim tempRow As MCAP.UserRolesDataSet.UserRow


      If Me.userDataGridView.RowCount <= 0 Then Exit Sub

      bmb = Me.BindingContext(Me.userDataGridView.DataSource, Me.userDataGridView.DataMember)
      tempRow = CType(CType(bmb.Current, System.Data.DataRowView).Row, UserRolesDataSet.UserRow)
      bmb = Nothing

      If UserProcessor.GetAdministratorsCount(tempRow.UserID) < 1 Then
        MessageBox.Show("This is the only administrator available for application. Cannot modify this user.", _
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        bmb = Nothing : tempRow = Nothing
        Exit Sub
      End If

      UserTab_ClearAllInputs()
      UserTab_ShowUserInformation(tempRow)

      tempRow = Nothing

      UserTab_FormState = FormStateEnum.Edit
      UserTab_ShowHideControls(UserTab_FormState)
      UserTab_EnableDisableControls(UserTab_FormState)
    End Sub

    Private Sub userSaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles userSaveButton.Click
      Dim tempRow As MCAP.UserRolesDataSet.UserRow


      If UserTab_ValidateInputs(Me.UserTab_FormState) = False Then Exit Sub
      UserTab_RemoveAllErrorProviders()

      If UserTab_FormState = FormStateEnum.Insert Then
        tempRow = UserProcessor.CreateUser()
      Else
        Dim bmb As BindingManagerBase
        bmb = Me.BindingContext(Me.userDataGridView.DataSource, Me.userDataGridView.DataMember)
        tempRow = CType(CType(bmb.Current, System.Data.DataRowView).Row, UserRolesDataSet.UserRow)
        bmb = Nothing
      End If

      UserTab_WriteUserInformation(tempRow)

      If UserProcessor.AreInputsValid(tempRow) = False Then
        ShowErrors(tempRow)
        Exit Sub
      End If

      If Me.UserTab_FormState = FormStateEnum.Insert Then UserProcessor.AddUser(tempRow)

      UserProcessor.Save()
      tempRow = Nothing

      If activeUsersOnlyCheckBox.Checked Then
        UserProcessor.LoadActiveUsersOnly()
      Else
        UserProcessor.LoadAllUsers()
      End If

      UserTab_ClearAllInputs()
      Me.UserTab_FormState = FormStateEnum.Insert
      UserTab_ShowHideControls(Me.UserTab_FormState)
      UserTab_EnableDisableControls(Me.UserTab_FormState)
    End Sub

    Private Sub userDeleteButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles userDeleteButton.Click
      Dim bmb As BindingManagerBase
      Dim tempRow As MCAP.UserRolesDataSet.UserRow


      If Me.userDataGridView.RowCount <= 0 Then Exit Sub

      bmb = Me.BindingContext(Me.userDataGridView.DataSource, Me.userDataGridView.DataMember)
      tempRow = CType(CType(bmb.Current, System.Data.DataRowView).Row, UserRolesDataSet.UserRow)

      'If tempRow.Username.ToUpper() = Environment.UserName.ToUpper() Then
      If tempRow.Username.ToUpper() = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToUpper() Then
        MessageBox.Show("Cannot remove logged on user.", Application.ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        bmb = Nothing : tempRow = Nothing
        Exit Sub
      End If

      If UserProcessor.GetAdministratorsCount(tempRow.UserID) < 1 Then
        MessageBox.Show("This is the only administrator available for application. Cannot remove this user.", _
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        bmb = Nothing : tempRow = Nothing
        Exit Sub
      End If

      UserProcessor.Remove(tempRow.UserID)

      bmb = Nothing
      tempRow = Nothing
    End Sub


#Region " Processor Events "

    Private Sub m_userProcessor_CanNotRemove(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_userProcessor.CanNotRemove

      MessageBox.Show("Cannot remove user. Removing user at this point will make system unstable." _
                      + Environment.NewLine + "You can make user inactive. Once user is inactive " _
                      + "application will not allow assigning any task to the user and user can " _
                      + "not use this application.", ProductName, MessageBoxButtons.OK _
                      , MessageBoxIcon.Information)

    End Sub

    Private Sub m_userProcessor_Removed(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_userProcessor.Removed
      Dim userName As String


      If e.Data.Contains("UserName") Then
        userName = e.Data("UserName").ToString()
      Else
        userName = String.Empty
      End If

      MessageBox.Show("User " + userName + " removed successfully.", Me.ProductName _
                      , MessageBoxButtons.OK, MessageBoxIcon.Information)

      ClearAllInputs()
      RemoveAllErrorProviders()
      Me.FormState = FormStateEnum.Insert
      EnableDisableControls(Me.FormState)

    End Sub

    Private Sub m_userProcessor_Removing(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_userProcessor.Removing
      Dim userResponse As System.Windows.Forms.DialogResult
      Dim userName As String


      If e.Data.Contains("UserName") Then
        userName = e.Data("UserName").ToString()
      Else
        userName = String.Empty
      End If

      userResponse = MessageBox.Show("Are you sure, you want to remove user " + userName + "?", ProductName _
                                     , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

      e.Cancel = (userResponse = Windows.Forms.DialogResult.No)

    End Sub


    Private Sub m_userProcessor_UserNotFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_userProcessor.UserNotFound

      If e.Data.Contains("UserName") Then
        MessageBox.Show("User not found. Unable to remove user " + e.Data("UserName").ToString() + "." _
                        , Me.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Else
        MessageBox.Show("User not found. Unable to remove user.", Me.ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End Sub


#End Region


#End Region


#Region " Role TabPage "


    Private Sub RoleTab_ClearAllInputs()
      roleIdValueLabel.Text = String.Empty
      roleNameTextBox.Clear()
    End Sub

    Private Sub RoleTab_RemoveAllErrorProviders()
      Me.RemoveErrorProvider(roleNameTextBox)
    End Sub

    Private Sub RoleTab_ShowHideControls(ByVal formStatus As FormStateEnum)

    End Sub

    Private Sub RoleTab_EnableDisableControls(ByVal formStatus As FormStateEnum)
      Select Case formStatus
        Case FormStateEnum.View
          roleNameTextBox.ReadOnly = False
          roleEditButton.Enabled = True

        Case FormStateEnum.Edit
          roleNameTextBox.ReadOnly = False
          roleEditButton.Enabled = False

        Case FormStateEnum.Insert
          roleNameTextBox.ReadOnly = False
          roleEditButton.Enabled = True
      End Select
    End Sub

    Private Sub ShowErrors(ByVal roleRow As MCAP.RoleDataSet.RoleRow)
      Dim errorMessage As System.Text.StringBuilder
      Dim errorCols() As Data.DataColumn


      If roleRow.HasErrors = False Then Exit Sub

      errorMessage = New System.Text.StringBuilder
      errorCols = roleRow.GetColumnsInError()

      errorMessage.Append("Invalid inputs found.")
      errorMessage.Append(Environment.NewLine)
      errorMessage.Append(roleRow.GetColumnError(errorCols(0)))

      MessageBox.Show(errorMessage.ToString(), Application.ProductName, _
                      MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Sub

    Private Function RoleTab_ValidateInputs(ByVal formStatus As FormStateEnum) As Boolean
      Dim isValid As Boolean = True


      If roleNameTextBox.Text.Trim().Length = 0 Then
        Me.SetErrorProvider(roleNameTextBox, "Provide name for role.")
        isValid = False
      End If

      Return isValid

    End Function

    Private Sub RoleTab_ShowRoleInformation(ByVal roleRow As RoleDataSet.RoleRow)

      Me.roleIdValueLabel.Text = roleRow.RoleId.ToString()
      Me.roleNameTextBox.Text = roleRow.Descrip

    End Sub

    Private Sub RoleTab_WriteRoleInformation(ByVal roleRow As RoleDataSet.RoleRow)

      roleRow.Descrip = Me.roleNameTextBox.Text

    End Sub


    'Private Sub roleDataGridView_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles roleDataGridView.Resize

    '  roleDataGridView.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

    'End Sub

    Private Sub roleDataGridView_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles roleDataGridView.RowValidated

      If Me.RoleTab_FormState = FormStateEnum.Edit Then
        RoleTab_ClearAllInputs()
        RoleTab_RemoveAllErrorProviders()
        Me.RoleTab_FormState = FormStateEnum.Insert
        RoleTab_ShowHideControls(Me.RoleTab_FormState)
        RoleTab_EnableDisableControls(Me.RoleTab_FormState)
      End If

    End Sub

    Private Sub roleTabPage_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles roleTabPage.Enter

      If Me.RoleTab_FormState <> FormStateEnum.View Then Exit Sub

      RoleProcessor.LoadAllRoles()

      roleDataGridView.DataSource = RoleProcessor.RoleDataSet.Role
      roleDataGridView.Columns("RoleId").Visible = False
      roleDataGridView.Columns("Descrip").HeaderText = "Name"
      roleDataGridView.Columns("Descrip").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            roleDataGridView.Sort(roleDataGridView.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
      RoleTab_ClearAllInputs()
      Me.RoleTab_FormState = FormStateEnum.Insert
      RoleTab_ShowHideControls(Me.RoleTab_FormState)
      RoleTab_EnableDisableControls(Me.RoleTab_FormState)

    End Sub

    Private Sub roleEditButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles roleEditButton.Click
      Dim bmb As BindingManagerBase
      Dim tempRole As RoleDataSet.RoleRow


      If Me.roleDataGridView.RowCount < 1 Then Exit Sub

      RoleTab_ClearAllInputs()
      RoleTab_RemoveAllErrorProviders()

      bmb = Me.BindingContext(Me.roleDataGridView.DataSource)
      tempRole = CType(CType(bmb.Current, Data.DataRowView).Row, RoleDataSet.RoleRow)

      If tempRole.Descrip.ToUpper() = "ADMINISTRATOR" Then
        MessageBox.Show("Cannot change description for Administrator.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        bmb = Nothing : tempRole = Nothing
        Exit Sub
      End If

      RoleTab_ShowRoleInformation(tempRole)

      tempRole = Nothing
      bmb = Nothing

      Me.RoleTab_FormState = FormStateEnum.Edit
      RoleTab_ShowHideControls(Me.RoleTab_FormState)
      RoleTab_EnableDisableControls(Me.RoleTab_FormState)

    End Sub

    Private Sub roleSaveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles roleSaveButton.Click
      Dim tempRole As RoleDataSet.RoleRow


      If RoleTab_ValidateInputs(Me.RoleTab_FormState) = False Then Exit Sub

      RoleTab_RemoveAllErrorProviders()

      If Me.RoleTab_FormState = FormStateEnum.Insert Then
        tempRole = RoleProcessor.CreateRole()
      Else
        tempRole = RoleProcessor.GetRole(CType(Me.roleIdValueLabel.Text, Integer))
      End If

      RoleTab_WriteRoleInformation(tempRole)

      If RoleProcessor.AreInputsValid(tempRole) = False Then
        ShowErrors(tempRole)
        Exit Sub
      End If

      If Me.RoleTab_FormState = FormStateEnum.Insert Then RoleProcessor.AddRole(tempRole)

      RoleProcessor.Save()

      RoleTab_ClearAllInputs()
      RoleTab_FormState = FormStateEnum.Insert
      RoleTab_ShowHideControls(Me.RoleTab_FormState)
      RoleTab_EnableDisableControls(Me.RoleTab_FormState)
    End Sub

    Private Sub roleDeleteButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles roleDeleteButton.Click
      Dim userResponse As System.Windows.Forms.DialogResult
      Dim bmb As BindingManagerBase
      Dim tempRole As RoleDataSet.RoleRow


      If Me.roleDataGridView.RowCount <= 0 Then Exit Sub

      bmb = Me.BindingContext(Me.roleDataGridView.DataSource)
      tempRole = CType(CType(bmb.Current, Data.DataRowView).Row, RoleDataSet.RoleRow)

      If tempRole.Descrip.ToUpper() = "ADMINISTRATOR" Then
        MessageBox.Show("Cannot remove administrator role.", _
                        ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        bmb = Nothing : tempRole = Nothing
        Exit Sub
      End If

      userResponse = MessageBox.Show("Are you sure, you want to remove role " + tempRole.Descrip + "?", _
                                     Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      If userResponse = Windows.Forms.DialogResult.Yes Then
        RoleProcessor.Remove(tempRole.RoleId)
        RoleTab_ClearAllInputs()
        RoleTab_RemoveAllErrorProviders()
        Me.RoleTab_FormState = FormStateEnum.Insert
        RoleTab_ShowHideControls(Me.RoleTab_FormState)
        RoleTab_EnableDisableControls(Me.RoleTab_FormState)
      End If

      bmb = Nothing
      tempRole = Nothing
    End Sub


#End Region


#Region " Role-Screen Association TabPage "


    Private Sub rolescreenTabPage_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles rolescreenTabPage.Enter

      If Me.RoleScreenTab_FormState <> FormStateEnum.View Then Exit Sub

      RoleProcessor.LoadAllRoles()
      RoleProcessor.LoadAllForms()

      Me.roleComboBox.DisplayMember = "Descrip"
      Me.roleComboBox.ValueMember = "RoleID"
      Me.roleComboBox.BeginUpdate()
      Me.roleComboBox.DataSource = RoleProcessor.RoleDataSet.Role
      Me.roleComboBox.EndUpdate()

      Dim screenColumn As DataGridViewComboBoxColumn '= New DataGridViewComboBoxColumn
      screenColumn = CType(screensDataGridView.Columns("ScreenIdDataGridViewComboBoxColumn"), DataGridViewComboBoxColumn)
      screenColumn.DataPropertyName = "ScreenId"
      screenColumn.DisplayMember = "FormFunctionality"
      screenColumn.ValueMember = "ScreenId"
      screenColumn.DataSource = RoleProcessor.RoleDataSet.Screen
      'screenColumn.Name = "ScreenIdDataGridViewComboBoxColumn"
      'screenColumn.Resizable = DataGridViewTriState.True
      'screenColumn.SortMode = DataGridViewColumnSortMode.Automatic
      'screenColumn.AutoComplete = True
      'screenColumn.HeaderText = "Screen"
            screenColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            screenColumn.SortMode = DataGridViewColumnSortMode.Automatic

      Dim roleIdColumn As DataGridViewTextBoxColumn '= New DataGridViewTextBoxColumn
      roleIdColumn = CType(screensDataGridView.Columns("RoleIdDataGridViewTextBoxColumn"), DataGridViewTextBoxColumn)
      roleIdColumn.DataPropertyName = "RoleId"
      'roleIdColumn.HeaderText = "RoleId"
      'roleIdColumn.Name = "RoleIdDataGridViewTextBoxColumn"
      'roleIdColumn.Visible = False

      Me.screensDataGridView.DataSource = RoleProcessor.RoleDataSet.ScreenRoles
            'screensDataGridView.Columns("Ename").SortMode = DataGridViewColumnSortMode.Automatic
      screenColumn = Nothing
      roleIdColumn = Nothing

      m_screenRolesTable = m_roleProcessor.RoleDataSet.ScreenRoles

    End Sub

    Private Sub roleComboBox_DropDown _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles roleComboBox.DropDown
      Dim userResponse As System.Windows.Forms.DialogResult


      If m_roleProcessor.RoleDataSet.HasChanges() Then
        userResponse = MessageBox.Show("Unsaved changes exist for role " + Me.roleComboBox.Text _
                                       + ". Do you want to save those unsaved changes?", _
                                       Application.ProductName, MessageBoxButtons.YesNo, _
                                       MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If userResponse = Windows.Forms.DialogResult.Yes Then Me.rolescreenSaveButton_Click(sender, e)
      End If

    End Sub

    Private Sub roleComboBox_SelectedValueChanged _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles roleComboBox.SelectedValueChanged
      Dim roleID As Integer


      If Me.roleComboBox.SelectedValue Is Nothing Then Exit Sub

      roleID = CType(Me.roleComboBox.SelectedValue, Integer)

      m_roleProcessor.GetFormIDsForRole(roleID)

    End Sub

    Private Sub screensDataGridView_CellBeginEdit _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) _
         Handles screensDataGridView.CellBeginEdit

      If roleComboBox.Text.ToUpper() = "ADMINISTRATOR" _
        AndAlso e.RowIndex <> screensDataGridView.NewRowIndex _
      Then
        MessageBox.Show("Cannot edit screens assigned to Administrator.", Application.ProductName, _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
        e.Cancel = True
      End If

    End Sub

    Private Sub screensDataGridView_CellEndEdit _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles screensDataGridView.CellEndEdit

      Me.screensDataGridView.Rows(e.RowIndex).ErrorText = String.Empty

    End Sub

    Private Sub screensDataGridView_CellValidating _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) _
        Handles screensDataGridView.CellValidating

      If e.RowIndex <> screensDataGridView.NewRowIndex Then
        If Me.screensDataGridView.Columns(e.ColumnIndex).DataPropertyName = "ScreenId" Then
          If String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
            Me.screensDataGridView.Rows(e.RowIndex).ErrorText = "Select screen name."
            e.Cancel = True
          End If
        End If
      End If

    End Sub

    Private Sub screensDataGridView_DataError _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) _
        Handles screensDataGridView.DataError

      If TypeOf (e.Exception) Is System.Data.ConstraintException _
          And e.Context = DataGridViewDataErrorContexts.Commit _
      Then
        MessageBox.Show("Screen is already associated with role.", Application.ProductName, _
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        e.Cancel = True
      End If

    End Sub

    Private Sub screensDataGridView_UserDeletedRow _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) _
        Handles screensDataGridView.UserDeletedRow

      '
      'This is to avoid primary/unique key violation in database. A row is 
      'removed and then another row is modified to have same value as of the 
      'deleted row, while synchronizing dataset with database, constraint 
      'violation will occurs because, Insert/Update gets fired before delete 
      'command fires.
      '
      m_roleProcessor.SaveScreensForRole()

    End Sub

    Private Sub screensDataGridView_UserDeletingRow _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) _
        Handles screensDataGridView.UserDeletingRow
      Dim userResponse As System.Windows.Forms.DialogResult


      If screensDataGridView.RowCount < 1 Then Exit Sub

      If roleComboBox.Text.ToUpper() = "ADMINISTRATOR" Then
        MessageBox.Show("Cannot remove screens assigned to administrator.", Application.ProductName, _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
        e.Cancel = True
        Exit Sub
      End If

      userResponse = MessageBox.Show("Are you sure, you want to remove selected screen?", _
                                     Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      If userResponse = Windows.Forms.DialogResult.No Then e.Cancel = True

    End Sub

    Private Sub m_screenRolesTable_ColumnChanged _
        (ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) _
        Handles m_screenRolesTable.ColumnChanged

      If e.Column.ColumnName.ToUpper() = "SCREENID" Then
        e.Row("RoleId") = Me.roleComboBox.SelectedValue
      End If

    End Sub

    Private Sub rolescreenSaveButton_Click _
        (ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles rolescreenSaveButton.Click
      Dim newRowsTable, editedRowTable, deleteRowTable As Data.DataTable


      newRowsTable = m_roleProcessor.RoleDataSet.ScreenRoles.GetChanges(DataRowState.Modified)
      editedRowTable = m_roleProcessor.RoleDataSet.ScreenRoles.GetChanges(DataRowState.Added)
      deleteRowTable = m_roleProcessor.RoleDataSet.ScreenRoles.GetChanges(DataRowState.Deleted)

      If m_roleProcessor.AreScreensValidForRole(newRowsTable, editedRowTable) = False _
        AndAlso deleteRowTable Is Nothing _
      Then
        newRowsTable = Nothing
        editedRowTable = Nothing
        deleteRowTable = Nothing
        Exit Sub
      End If

      newRowsTable = Nothing
      editedRowTable = Nothing
      deleteRowTable = Nothing

      m_roleProcessor.SaveScreensForRole()

    End Sub


#End Region


#Region " User-Role Association TabPage "


    Private Sub userroleTabPage_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles userroleTabPage.Enter

      If UserRoleTab_FormState <> FormStateEnum.View Then Exit Sub

      UserProcessor.LoadActiveUsersOnly()
      RoleProcessor.LoadAllRoles()

      Me.userComboBox.DisplayMember = "Username"
      Me.userComboBox.ValueMember = "UserId"
      Me.userComboBox.DataSource = m_userProcessor.UserDataSet.User

      Dim roleColumn As DataGridViewComboBoxColumn '= New DataGridViewComboBoxColumn
      roleColumn = CType(rolesDataGridView.Columns("RoleIdDataGridViewComboBoxColumn"), DataGridViewComboBoxColumn)
      roleColumn.DataPropertyName = "RoleId"
      roleColumn.DisplayMember = "Descrip"
      roleColumn.ValueMember = "RoleId"
      roleColumn.DataSource = RoleProcessor.RoleDataSet.Role
      'roleColumn.Name = "RoleIdDataGridViewComboBoxColumn"
      'roleColumn.Resizable = DataGridViewTriState.True
            roleColumn.SortMode = DataGridViewColumnSortMode.Automatic
      'roleColumn.AutoComplete = True
      'roleColumn.HeaderText = "Role"
      roleColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

      Dim userIdColumn As DataGridViewTextBoxColumn '= New DataGridViewTextBoxColumn
      userIdColumn = CType(rolesDataGridView.Columns("UserIdDataGridViewTextBoxColumn"), DataGridViewTextBoxColumn)
      userIdColumn.DataPropertyName = "UserId"
      'userIdColumn.HeaderText = "UserId"
      'userIdColumn.Name = "UserIdDataGridViewTextBoxColumn"
            'userIdColumn.Visible = False

      Me.rolesDataGridView.DataSource = UserProcessor.UserDataSet.UserRoles
      'Me.rolesDataGridView.Columns.Clear()
      'Me.rolesDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {roleColumn})

            roleColumn = Nothing
      userIdColumn = Nothing

      m_userRolesTable = m_userProcessor.UserDataSet.UserRoles

    End Sub


    Private Sub userComboBox_DropDown _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles userComboBox.DropDown
      Dim userResponse As System.Windows.Forms.DialogResult


      If UserProcessor.UserDataSet.HasChanges() Then
        userResponse = MessageBox.Show("Unsaved changes exist for user " + Me.userComboBox.Text _
                                       + ". Do you want to save those unsaved changes?" _
                                       , Application.ProductName, MessageBoxButtons.YesNo _
                                       , MessageBoxIcon.Question)

        If userResponse = Windows.Forms.DialogResult.Yes Then Me.userroleSaveButton_Click(sender, e)
      End If

    End Sub

    Private Sub userComboBox_SelectedValueChanged _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles userComboBox.SelectedValueChanged
      Dim userID As Integer


      If userComboBox.SelectedValue Is Nothing Then Exit Sub

      userID = CType(Me.userComboBox.SelectedValue, Integer)

      UserProcessor.LoadRoles(userID)

    End Sub

    Private Sub rolesDataGridView_CellBeginEdit _
        (ByVal sender As Object, _
         ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) _
         Handles rolesDataGridView.CellBeginEdit
      Dim bmb As BindingManagerBase
      Dim tempRow As MCAP.UserRolesDataSet.UserRolesRow


      If Me.rolesDataGridView.RowCount <= 0 Or Me.rolesDataGridView.NewRowIndex = e.RowIndex Then Exit Sub

      bmb = Me.BindingContext(Me.rolesDataGridView.DataSource, Me.rolesDataGridView.DataMember)
      tempRow = CType(CType(bmb.Current, System.Data.DataRowView).Row, UserRolesDataSet.UserRolesRow)

      If UserProcessor.GetAdministratorsCount(tempRow.UserID) < 1 Then
        MessageBox.Show("This is the only administrator available for application. Cannot remove roles for this user.", _
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        e.Cancel = True
        bmb = Nothing : tempRow = Nothing
        Exit Sub
      End If

      bmb = Nothing : tempRow = Nothing

    End Sub

    Private Sub rolesDataGridView_CellEndEdit _
        (ByVal sender As Object, _
         ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles rolesDataGridView.CellEndEdit

      Me.rolesDataGridView.Rows(e.RowIndex).ErrorText = String.Empty

    End Sub

    Private Sub rolesDataGridView_CellValidating _
        (ByVal sender As Object, _
         ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) _
        Handles rolesDataGridView.CellValidating

      If e.RowIndex <> rolesDataGridView.NewRowIndex Then
        If Me.rolesDataGridView.Columns(e.ColumnIndex).DataPropertyName = "RoleId" Then
          If String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
            Me.rolesDataGridView.Rows(e.RowIndex).ErrorText = "Select role."
            e.Cancel = True
          End If
        End If
      End If

    End Sub

    Private Sub rolesDataGridView_DataError _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) _
        Handles rolesDataGridView.DataError

      If TypeOf (e.Exception) Is System.Data.ConstraintException _
          And e.Context = DataGridViewDataErrorContexts.Commit _
      Then
        MessageBox.Show("Role is already assigned to user. Press Esc key to undo this change." _
                        , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        e.Cancel = True
      End If

    End Sub

    Private Sub rolesDataGridView_UserDeletedRow _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) _
        Handles rolesDataGridView.UserDeletedRow

      '
      'This is to avoid primary/unique key violation in database. A row is 
      'removed and then another row is modified to have same value as of the 
      'deleted row, while synchronizing dataset with database, constraint 
      'violation will occurs because, Insert/Update gets fired before delete 
      'command fires.
      '
      UserProcessor.SaveRolesForUser()

    End Sub

    Private Sub rolesDataGridView_UserDeletingRow _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) _
        Handles rolesDataGridView.UserDeletingRow
      Dim userResponse As System.Windows.Forms.DialogResult
      Dim bmb As BindingManagerBase
      Dim tempRow As MCAP.UserRolesDataSet.UserRolesRow


      If Me.rolesDataGridView.RowCount <= 0 Then Exit Sub

      bmb = Me.BindingContext(Me.rolesDataGridView.DataSource, Me.rolesDataGridView.DataMember)
      tempRow = CType(CType(bmb.Current, System.Data.DataRowView).Row, UserRolesDataSet.UserRolesRow)

      If tempRow.UserId = UserProcessor.UserID Then
        MessageBox.Show("Cannot change roles for current logged on user.", _
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        e.Cancel = True
        bmb = Nothing : tempRow = Nothing
        Exit Sub
      End If

      If UserProcessor.GetAdministratorsCount(tempRow.UserID) < 1 Then
        MessageBox.Show("This is the only administrator available for application. Cannot remove roles for this user.", _
                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        e.Cancel = True
        bmb = Nothing : tempRow = Nothing
        Exit Sub
      End If

      userResponse = MessageBox.Show("Are you sure, you want to remove selected role?", Application.ProductName, _
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      If userResponse = Windows.Forms.DialogResult.No Then e.Cancel = True

    End Sub

    Private Sub m_userRolesTable_ColumnChanged _
        (ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) _
        Handles m_userRolesTable.ColumnChanged

      If e.Column.ColumnName.ToUpper() = "ROLEID" Then
        e.Row("UserId") = Me.userComboBox.SelectedValue
      End If

    End Sub

    Private Sub userroleSaveButton_Click _
        (ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles userroleSaveButton.Click

      UserProcessor.SaveRolesForUser()

    End Sub


#End Region

        Private Sub locationComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles locationComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub roleComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles roleComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub userComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles userComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

    End Class

End Namespace