Namespace UI.Processors

  ''' <summary>
  ''' A non-GUI class processes information about role and role-screen 
  ''' association.
  ''' </summary>
  ''' <remarks></remarks>
  Public Class Role
    Inherits MCAP.UI.Processors.BaseClass


    Public Event Initializing()
    Public Event Initialized()

    Public Event PreparingAdapter()
    Public Event AdapterPrepared()

    Public Event LoadingAllRoles()
    Public Event AllRolesLoaded()

    Public Event LoadingRoleInformation()
    Public Event RoleInformationLoaded()

    Public Event LoadingScreenListForRole()
    Public Event ScreenListLoadedForRole()

    Public Event RemovingRole()
    Public Event RoleRemoved()

    Public Event SynchronizingRolesInformation()
    Public Event RolesInformationSynchronized()

    Public Event SynchronizingScreenRolesInformation()
    Public Event ScreenRolesInformationSynchronized()


    Private m_roleTableAdapter As RoleDataSetTableAdapters.RoleTableAdapter
    Private m_screenRoleTableAdapter As RoleDataSetTableAdapters.ScreenRolesTableAdapter
    Private m_screenTableAdapter As RoleDataSetTableAdapters.ScreenTableAdapter
    Private m_roleDataSet As RoleDataSet



    ''' <summary>
    ''' Gets Adapter for Role table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property RoleTableAdapter() As RoleDataSetTableAdapters.RoleTableAdapter
      Get
        Return m_roleTableAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets Adapter for ScreenRole table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property ScreenRoleTableAdapter() As RoleDataSetTableAdapters.ScreenRolesTableAdapter
      Get
        Return m_screenRoleTableAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets Adapter for Screen table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property ScreenTableAdapter() As RoleDataSetTableAdapters.ScreenTableAdapter
      Get
        Return m_screenTableAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets dataset containing tables related to Role screen.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RoleDataSet() As RoleDataSet
      Get
        Return m_roleDataSet
      End Get
    End Property



    ''' <summary>
    ''' Default constructor.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
      m_roleDataSet = New RoleDataSet
      m_roleTableAdapter = New RoleDataSetTableAdapters.RoleTableAdapter
      m_screenRoleTableAdapter = New RoleDataSetTableAdapters.ScreenRolesTableAdapter
      m_screenTableAdapter = New RoleDataSetTableAdapters.ScreenTableAdapter
    End Sub



    ''' <summary>
    ''' Prepare and assign Select, Insert, Update and Delete commands.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PrepareDataAdapter()

      RaiseEvent PreparingAdapter()

      m_roleTableAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_screenRoleTableAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_screenTableAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      RaiseEvent AdapterPrepared()

    End Sub


    ''' <summary>
    ''' Initializes and prepares object with default values.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize()

      RaiseEvent Initializing()

      Me.PrepareDataAdapter()

      RaiseEvent Initialized()

    End Sub


    ''' <summary>
    ''' Loads list of all roles. This function does not load related information 
    ''' like, list of screens associated with each role.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadAllRoles() As Data.DataTable

      RaiseEvent LoadingAllRoles()

      Me.RoleTableAdapter.Fill(Me.RoleDataSet.Role)

      Return RoleDataSet.Role

      RaiseEvent AllRolesLoaded()

    End Function


    ''' <summary>
    ''' Returns information about supplied role name.
    ''' </summary>
    ''' <param name="roleName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRole(ByVal roleName As String) As MCAP.RoleDataSet.RoleRow
      Dim tempView As Data.DataView
      Dim searchRow As MCAP.RoleDataSet.RoleRow


      RaiseEvent LoadingRoleInformation()

      If Me.RoleDataSet.Role Is Nothing Or Me.RoleDataSet.Role.Rows.Count = 0 Then
        Me.LoadAllRoles()
      End If

      tempView = New Data.DataView(Me.RoleDataSet.Role)
      tempView.RowFilter = "Descrip='" + roleName.Replace("'", "''") + "'"

      If tempView.Count = 0 Then
        searchRow = Nothing
      Else
        searchRow = CType(tempView(0).Row, MCAP.RoleDataSet.RoleRow)
      End If

      tempView.Dispose()
      tempView = Nothing

      RaiseEvent RoleInformationLoaded()

      Return searchRow

    End Function

    ''' <summary>
    ''' Returns information about supplied role ID.
    ''' </summary>
    ''' <param name="roleID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetRole(ByVal roleID As Integer) As MCAP.RoleDataSet.RoleRow
      Dim searchRow As MCAP.RoleDataSet.RoleRow


      RaiseEvent LoadingRoleInformation()

      searchRow = Me.RoleDataSet.Role.FindByRoleId(roleID)

      RaiseEvent RoleInformationLoaded()

      Return searchRow

    End Function


    ''' <summary>
    ''' Loads list of all screens.
    ''' </summary>
    ''' <returns>DataTable containing all rows from Screens table.</returns>
    ''' <remarks></remarks>
    Public Function LoadAllForms() As Data.DataTable

      Me.ScreenTableAdapter.FillForRoles(Me.RoleDataSet.Screen)

      Return Me.RoleDataSet.Screen

    End Function


    ''' <summary>
    ''' Loads list of screenIds associated with supplied role name.
    ''' </summary>
    ''' <param name="roleName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFormIDsForRole(ByVal roleName As String) As Data.DataTable

      RaiseEvent LoadingScreenListForRole()

      Me.ScreenRoleTableAdapter.FillByRoleName(Me.RoleDataSet.ScreenRoles, roleName)

      RaiseEvent ScreenListLoadedForRole()

      Return Me.RoleDataSet.Screen

    End Function

    ''' <summary>
    ''' Loads list of screensIds associated with supplied role ID.
    ''' </summary>
    ''' <param name="roleID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFormIDsForRole(ByVal roleID As Integer) As Data.DataTable

      RaiseEvent LoadingScreenListForRole()

      Me.ScreenRoleTableAdapter.FillByRoleId(Me.RoleDataSet.ScreenRoles, roleID)

      RaiseEvent ScreenListLoadedForRole()

      Return Me.RoleDataSet.Screen

    End Function


    ''' <summary>
    ''' Loads list of screens associated with supplied role name.
    ''' </summary>
    ''' <param name="roleName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFormListForRole(ByVal roleName As String) As Data.DataTable

      RaiseEvent LoadingScreenListForRole()

      Me.ScreenRoleTableAdapter.FillByRoleName(Me.RoleDataSet.ScreenRoles, roleName)

      Me.ScreenTableAdapter.FillByRoleName(Me.RoleDataSet.Screen, roleName)

      RaiseEvent ScreenListLoadedForRole()

      Return Me.RoleDataSet.Screen

    End Function

    ''' <summary>
    ''' Loads list of screens associated with supplied role ID.
    ''' </summary>
    ''' <param name="roleID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetFormListForRole(ByVal roleID As Integer) As Data.DataTable

      RaiseEvent LoadingScreenListForRole()

      Me.ScreenRoleTableAdapter.FillByRoleId(Me.RoleDataSet.ScreenRoles, roleID)

      Me.ScreenTableAdapter.FillByRoleId(Me.RoleDataSet.Screen, roleID)

      RaiseEvent ScreenListLoadedForRole()

      Return Me.RoleDataSet.Screen

    End Function


#Region " Validation related methods "


    ''' <summary>
    ''' Returns true if descrip (role name) is unique, false otherwise.
    ''' </summary>
    ''' <param name="Descrip">Role name whose uniqueness is to be checked.</param>
    ''' <returns>Ture if unique, false otherwise.</returns>
    ''' <remarks></remarks>
    Public Function IsDescripUnique(ByVal Descrip As String) As Boolean
      Dim isUnique As Boolean
      Dim tempView As Data.DataView


      tempView = New Data.DataView(RoleDataSet.Role)
      tempView.RowFilter = "Descrip='" + Descrip.Replace("'", "''") + "'"

      isUnique = (tempView.Count = 0)

      tempView.Dispose()
      tempView = Nothing

      Return isUnique

    End Function

    ''' <summary> 
    ''' Returns true if role Id and name are unique, false otherwise. 
    ''' </summary>
    ''' <param name="roleID">Role Id</param>
    ''' <param name="Descrip">Role name</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsDescripUnique(ByVal roleID As Integer, ByVal Descrip As String) As Boolean
      Dim isUnique As Boolean
      Dim tempView As Data.DataView


      tempView = New Data.DataView(RoleDataSet.Role)
      tempView.RowFilter = "RoleId<>" + roleID.ToString() + " AND Descrip='" + Descrip.Replace("'", "''") + "'"

      isUnique = (tempView.Count = 0)

      tempView.Dispose()
      tempView = Nothing

      Return isUnique

    End Function

    ''' <summary>
    ''' Validates all columns of supplied DataRow.
    ''' </summary>
    ''' <param name="validateRow"></param>
    ''' <returns>
    ''' True if all columns contains valid inforamtion. False otherwise.
    ''' </returns>
    ''' <remarks></remarks>
    Public Function AreInputsValid(ByVal validateRow As MCAP.RoleDataSet.RoleRow) As Boolean

      If String.IsNullOrEmpty(validateRow.Descrip) Then
        validateRow.SetColumnError("Descrip", "Provide name for Role.")
      ElseIf validateRow.RowState = DataRowState.Modified _
        AndAlso (IsDescripUnique(validateRow.RoleId, validateRow.Descrip) = False) _
      Then
        validateRow.SetColumnError("Descrip", "Name already exist. Provide unique name.")
      ElseIf validateRow.RowState <> DataRowState.Modified _
        AndAlso IsDescripUnique(validateRow.Descrip) = False _
      Then
        validateRow.SetColumnError("Descrip", "Name already exist. Provide unique name.")
      Else
        validateRow.SetColumnError("Descrip", String.Empty)
      End If

      Return (Not validateRow.HasErrors)

    End Function


#End Region


    ''' <summary>
    ''' Validates all screens for Role. If any error is found, sets error text 
    ''' for that column.
    ''' </summary>
    ''' <param name="newScreens">Datatable containing inserted rows.</param>
    ''' <param name="editedScreens">Dataset containing modified rows.</param>
    ''' <returns>False if any error is found, False otherwise.</returns>
    ''' <remarks></remarks>
    Public Function AreScreensValidForRole _
        (ByVal newScreens As Data.DataTable, ByVal editedScreens As Data.DataTable) _
        As Boolean
      Dim isErrorFound As Boolean
      Dim rowCounter As Integer


      If newScreens IsNot Nothing Then
        For rowCounter = 0 To newScreens.Rows.Count - 1
          If newScreens.Rows(rowCounter).Item("RoleId") Is DBNull.Value Then
            newScreens.Rows(rowCounter).RowError = "Unable to associate screen with Role."
            isErrorFound = True
            Continue For
          End If

          If newScreens.Rows(rowCounter).Item("ScreenId") Is DBNull.Value Then
            newScreens.Rows(rowCounter).RowError = "Unable to associate Screen with role."
            isErrorFound = True
          End If
        Next
      End If

      If editedScreens IsNot Nothing Then
        For rowCounter = 0 To editedScreens.Rows.Count - 1
          If editedScreens.Rows(rowCounter).Item("RoleId") Is DBNull.Value Then
            editedScreens.Rows(rowCounter).RowError = "Unable to associate screen with Role."
            isErrorFound = True
            Continue For
          End If

          If editedScreens.Rows(rowCounter).Item("ScreenId") Is DBNull.Value Then
            editedScreens.Rows(rowCounter).RowError = "Unable to associate Screen with role."
            isErrorFound = True
          End If
        Next
      End If

      Return (Not isErrorFound)

    End Function


    ''' <summary>
    ''' Returns a blank DataRow associate with DataTable for Role.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateRole() As MCAP.RoleDataSet.RoleRow
      Dim tempRow As MCAP.RoleDataSet.RoleRow


      tempRow = Me.RoleDataSet.Role.NewRoleRow()

      Return tempRow

    End Function


    ''' <summary>
    ''' Adds supplied DataRow into DataTable for Role.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>Supplied DataRow must be the one returned by CreateRole.</remarks>
    Public Function AddRole(ByVal insertRow As MCAP.RoleDataSet.RoleRow) As MCAP.RoleDataSet.RoleRow

      If AreInputsValid(insertRow) = False Then Return insertRow

      Me.RoleDataSet.Role.AddRoleRow(insertRow)

      Return insertRow

    End Function


    ''' <summary>
    ''' Synchronizes information between DataSet and Database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save()

      RaiseEvent SynchronizingRolesInformation()

      Me.RoleTableAdapter.Update(Me.RoleDataSet.Role)

      RaiseEvent RolesInformationSynchronized()

    End Sub


    ''' <summary>
    ''' Synchronizes information between DataSet and Database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveScreensForRole()

      RaiseEvent SynchronizingScreenRolesInformation()

      Me.ScreenRoleTableAdapter.Update(Me.RoleDataSet.ScreenRoles)

      RaiseEvent ScreenRolesInformationSynchronized()

    End Sub


    ''' <summary>
    ''' Removes Role from DataTable for role based on supplied Role name.
    ''' </summary>
    ''' <param name="roleName"></param>
    ''' <remarks></remarks>
    Public Sub Remove(ByVal roleName As String)
      Dim deleteRow As MCAP.RoleDataSet.RoleRow


      RaiseEvent RemovingRole()

      deleteRow = Me.GetRole(roleName)
      Me.RoleDataSet.Role.RemoveRoleRow(deleteRow)

      RaiseEvent RoleRemoved()

    End Sub

    ''' <summary>
    ''' Removes Role from DataTable for role based on supplied Role ID.
    ''' </summary>
    ''' <param name="roleID">RoleId of the Role to be removed.</param>
    ''' <remarks></remarks>
    Public Sub Remove(ByVal roleID As Integer)
      Dim deleteRow As RoleDataSet.RoleRow


      RaiseEvent RemovingRole()

            deleteRow = RoleDataSet.Role.FindByRoleId(roleID)

            Me.RemoveUserRole(roleID)
            Me.RemoveScreenRole(roleID)

            Me.RoleTableAdapter.Delete(roleID)
      Me.RoleDataSet.Role.RemoveRoleRow(deleteRow)

      RaiseEvent RoleRemoved()

      deleteRow = Nothing

    End Sub

        Public Sub RemoveUserRole(ByVal roleID As Integer)
            Dim str As String
            str = "Delete from dbo.userRoles where roleid in(select RoleId from Role where roleid =" + roleID.ToString + ")"
            ExecNonQuery(str)
        End Sub


        Public Sub RemoveScreenRole(ByVal roleID As Integer)
              Dim str As String
            str = "Delete from dbo.ScreenRoles where roleid in(select RoleId from Role where roleid =" + roleID.ToString + ")"
            ExecNonQuery(str)

        End Sub


  End Class

End Namespace