Namespace UI.Processors

  ''' <summary>
  ''' A non-GUI class processes information about application users. 
  ''' </summary>
  ''' <remarks></remarks>
  Public Class User
    Inherits MCAP.UI.Processors.UserBase


#Region " Events "


    Public Event Initializing As MCAPEventHandler
    Public Event Initialized As MCAPEventHandler

    Public Event PreparingAdapter As MCAPEventHandler
    Public Event AdapterPrepared As MCAPEventHandler

    Public Event LoadingActiveUsersOnly As MCAPCancellableEventHandler
    Public Event OnlyActiveUsersLoaded As MCAPEventHandler

    Public Event LoadingAllUsers As MCAPCancellableEventHandler
    Public Event AllUsersLoaded As MCAPEventHandler

    Public Event Removing As MCAPCancellableEventHandler
    Public Event CanNotRemove As MCAPEventHandler
    Public Event UserNotFound As MCAPEventHandler
    Public Event Removed As MCAPEventHandler

    Public Event ValidatingInputs As MCAPCancellableEventHandler
    Public Event InputsValidated As MCAPEventHandler
    Public Event InvalidInputsFound As MCAPEventHandler

    Public Event UserInformationChangesNotFound As MCAPEventHandler
    Public Event SynchronizingUserInformation As MCAPCancellableEventHandler
    Public Event UserInformationSynchronized As MCAPEventHandler

    Public Event SynchronizingUserRolesInformation(ByVal changes As System.Data.DataTable, ByRef cancel As Boolean)
    Public Event UserRolesInformationChangesNotFound()
    Public Event UserRolesInformationSynchronized(ByVal changes As System.Data.DataTable, ByVal rowsAffected As Integer)


#End Region



    ''' <summary>
    ''' Default constructor.
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()
      MyBase.new()
    End Sub



    ''' <summary>
    ''' Prepares Select, Insert, Update and Delete command and assign it to
    ''' DataAdapter.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub PrepareDataAdapter()
      MyBase.PrepareDataAdapter()
    End Sub


    ''' <summary>
    ''' Initializes and prepares object with default values.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize()
      Dim args As UI.Processors.EventArgs


      args = New UI.Processors.EventArgs()
      RaiseEvent Initializing(Me, args)

      Me.PrepareDataAdapter()
      LoadLocations()

      RaiseEvent Initialized(Me, args)

    End Sub


    Private Sub LoadLocations()
      Dim tempAdapter As UserRolesDataSetTableAdapters.vwLocationTableAdapter


      tempAdapter = New UserRolesDataSetTableAdapters.vwLocationTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      tempAdapter.Fill(UserDataSet.vwLocation)
      tempAdapter.Dispose()
      tempAdapter = Nothing
    End Sub

    ''' <summary>
    ''' Loads information about active users only. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadActiveUsersOnly()
      Dim args As UI.Processors.EventArgs
      Dim cargs As UI.Processors.CancellableEventArgs


      cargs = New UI.Processors.CancellableEventArgs()
      RaiseEvent LoadingActiveUsersOnly(Me, cargs)
      If cargs.Cancel Then
        cargs = Nothing
        Exit Sub
      End If
      cargs = Nothing
      UserTableAdapter.FillActiveUsersOnly(UserDataSet.User)

      args = New UI.Processors.EventArgs()
      RaiseEvent OnlyActiveUsersLoaded(Me, args)

      args = Nothing
    End Sub

    ''' <summary>
    ''' Loads information about all users. This function does not load other
    ''' related information like, list of screens for each user.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadAllUsers()
      Dim args As UI.Processors.EventArgs
      Dim cargs As UI.Processors.CancellableEventArgs


      cargs = New UI.Processors.CancellableEventArgs()
      RaiseEvent LoadingAllUsers(Me, cargs)
      If cargs.Cancel Then
        cargs = Nothing
        Exit Sub
      End If
      cargs = Nothing

      UserTableAdapter.Fill(UserDataSet.User)

      args = New UI.Processors.EventArgs()
      RaiseEvent AllUsersLoaded(Me, args)

      args = Nothing
    End Sub


#Region " Validation related methods "


    ''' <summary>
    ''' Returns true if user name is unique, false otherwise.
    ''' </summary>
    ''' <param name="userName">User name whose uniqueness is to be checked.</param>
    ''' <returns>Ture if unique, false otherwise.</returns>
    ''' <remarks></remarks>
    Public Function IsUserNameUnique(ByVal userName As String) As Boolean
      Dim isUnique As Boolean
      Dim tempView As Data.DataView


      tempView = New Data.DataView(UserDataSet.User)
      tempView.RowFilter = "Username='" + userName.Replace("'", "''") + "'"

      isUnique = (tempView.Count = 0)

      tempView.Dispose()
      tempView = Nothing

      Return isUnique

    End Function

    ''' <summary>
    ''' Returns true if user name is unique, false otherwise. 
    ''' </summary>
    ''' <param name="userID">User Id</param>
    ''' <param name="userName">User name</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    Public Function IsUserNameUnique(ByVal userID As Integer, ByVal userName As String) As Boolean
      Dim isUnique As Boolean
      Dim tempView As Data.DataView


      tempView = New Data.DataView(UserDataSet.User)
      tempView.RowFilter = "UserId<>" + userID.ToString() + " AND Username='" _
                            + userName.Replace("'", "''") + "'"

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
    Public Function AreInputsValid(ByVal validateRow As UserRolesDataSet.UserRow) As Boolean
      Dim cargs As UI.Processors.CancellableEventArgs
      Dim args As UI.Processors.EventArgs


      cargs = New UI.Processors.CancellableEventArgs()
      RaiseEvent ValidatingInputs(Me, cargs)
      If cargs.Cancel Then
        cargs = Nothing
        Exit Function
      End If
      cargs = Nothing

      If String.IsNullOrEmpty(validateRow.Username) Then
        validateRow.SetColumnError("Username", "User name cannot be blank. Provide user name.")
      ElseIf validateRow.RowState = DataRowState.Modified _
        AndAlso (IsUserNameUnique(validateRow.UserID, validateRow.Username) = False) _
      Then
        validateRow.SetColumnError("Username", "User name already exist. Provide unique user name.")
      ElseIf validateRow.RowState <> DataRowState.Modified _
        AndAlso IsUserNameUnique(validateRow.Username) = False _
      Then
        validateRow.SetColumnError("Username", "User name already exist. Provide unique user name.")
      Else
        validateRow.SetColumnError("Username", String.Empty)
      End If

      If String.IsNullOrEmpty(validateRow.FName) Then
        validateRow.SetColumnError("FName", "First name cannot be blank. Provide first name.")
      Else
        validateRow.SetColumnError("FName", String.Empty)
      End If

      If String.IsNullOrEmpty(validateRow.FName) Then
        validateRow.SetColumnError("LName", "Last name cannot be blank. Provide last name.")
      Else
        validateRow.SetColumnError("LName", String.Empty)
      End If

      If validateRow.IsLocationIdNull() Then
        validateRow.SetColumnError("LocationId", "Location cannot be blank. Provide location.")
      Else
        validateRow.SetColumnError("LocationId", String.Empty)
      End If

      If validateRow.IsActiveIndNull() Then
        validateRow.ActiveInd = 0
      End If

      args = New UI.Processors.EventArgs
      If validateRow.HasErrors Then
        args.Data.Add("User", validateRow)
        RaiseEvent InvalidInputsFound(Me, args)
      Else
        RaiseEvent InputsValidated(Me, args)
      End If

      args = Nothing

      Return (Not validateRow.HasErrors)

    End Function


#End Region


    ''' <summary>
    ''' Returns Count of users excluding supplied user Id with Administrator role.
    ''' </summary>
    ''' <param name="userId">User Id to exclude.</param>
    ''' <returns>Integer containing number of user with Administrator role.</returns>
    ''' <remarks></remarks>
    Public Function GetAdministratorsCount(ByVal userId As Integer) As Integer
      Dim count As Integer
      Dim userCount As Object


      userCount = UserTableAdapter.GetAdministratorsCount(userId)
      If userCount Is Nothing OrElse userCount Is DBNull.Value Then
        count = -1
      Else
        count = CType(userCount.ToString(), Integer)
      End If

      userCount = Nothing

      Return count

    End Function


    ''' <summary>
    ''' Creates and returns new row object.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateUser() As UserRolesDataSet.UserRow

      Return UserDataSet.User.NewUserRow()

    End Function

    ''' <summary>
    ''' Adds supplied Data.DataRow into user data table.
    ''' </summary>
    ''' <param name="userRow"></param>
    ''' <remarks>
    ''' Supplied DataRow should be the one returned by CreateUser method.
    ''' Otherwise, method raises an exception.
    ''' </remarks>
    Public Sub AddUser(ByVal userRow As MCAP.UserRolesDataSet.UserRow)

      UserDataSet.User.AddUserRow(userRow)

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Synchronize() As Integer

      Return UserTableAdapter.Update(UserDataSet.User)

    End Function

    ''' <summary>
    ''' Synchronizes user information between DataSet to database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save()
      Dim rowsAffected As Integer
      Dim args As UI.Processors.EventArgs
      Dim cargs As UI.Processors.CancellableEventArgs
      Dim changesTable As Data.DataTable


      If Me.UserDataSet.User.GetChanges() Is Nothing Then
        RaiseEvent UserInformationChangesNotFound(Me, New UI.Processors.EventArgs())
        Exit Sub
      End If

      cargs = New UI.Processors.CancellableEventArgs
      changesTable = UserDataSet.User.GetChanges().Copy()
      cargs.Data.Add("ChangesTable", changesTable)

      RaiseEvent SynchronizingUserInformation(Me, cargs)
      If cargs.Cancel Then
        If changesTable IsNot Nothing Then changesTable.Dispose()
        changesTable = Nothing
        cargs = Nothing
        Exit Sub
      End If
      cargs = Nothing

      rowsAffected = Synchronize()

      args = New UI.Processors.EventArgs
      If changesTable IsNot Nothing Then args.Data.Add("ChangesTable", changesTable)
      args.Data.Add("RowsAffected", rowsAffected)
      RaiseEvent UserInformationSynchronized(Me, args)

      changesTable.Dispose()
      args.Data.Clear()
      changesTable = Nothing
      args = Nothing

    End Sub

    ''' <summary>
    ''' Gets boolean flag indicating whether supplied user id can be removed or not.
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CanRemoveUser(ByVal userId As Integer) As Boolean
      Dim canRemove As Nullable(Of Boolean)


      canRemove = (UserTableAdapter.GetReferencedRowCount(userId) = 0)

      If canRemove.HasValue Then
        Return canRemove.Value
      Else
        Return False
      End If

    End Function

    ''' <summary>
    ''' Removes user information from database.
    ''' </summary>
    ''' <param name="userName"></param>
    ''' <remarks></remarks>
    Public Sub Remove(ByVal userName As String)
      Dim rowsAffected As Integer
      Dim args As UI.Processors.EventArgs
      Dim deleteRow As MCAP.UserRolesDataSet.UserRow


      deleteRow = GetUser(userName)

      If deleteRow Is Nothing Then
        args = New UI.Processors.EventArgs()
        args.Data.Add("UserName", userName)
        RaiseEvent UserNotFound(Me, args)
        args = Nothing
        Exit Sub
      End If

      If CanRemoveUser(deleteRow.UserID) = False Then
        args = New UI.Processors.EventArgs()
        RaiseEvent CanNotRemove(Me, args)
        args = Nothing
        Exit Sub
      End If

      Dim cargs As UI.Processors.CancellableEventArgs = New UI.Processors.CancellableEventArgs()
      cargs.Data.Add("UserName", userName)
      RaiseEvent Removing(Me, cargs)
      If cargs.Cancel Then
        cargs.Data.Clear()
        cargs = Nothing
        Exit Sub
      End If
      cargs = Nothing

      deleteRow.Delete()
      rowsAffected = Synchronize()

      deleteRow = Nothing

      args = New UI.Processors.EventArgs()
      args.Data.Add("RowsAffected", rowsAffected)
      RaiseEvent Removed(Me, args)
      args = Nothing

    End Sub

    ''' <summary>
    ''' Removes user information from database.
    ''' </summary>
    ''' <param name="userID"></param>
    ''' <remarks></remarks>
    Public Sub Remove(ByVal userID As Integer)
      Dim rowsAffected As Integer
      Dim userName As String
      Dim args As UI.Processors.EventArgs
      Dim deleteRow As MCAP.UserRolesDataSet.UserRow


      deleteRow = GetUser(userID)

      If deleteRow Is Nothing Then
        args = New UI.Processors.EventArgs()
        args.Data.Add("UserId", userID)
        RaiseEvent UserNotFound(Me, args)
        args = Nothing
        Exit Sub
      End If

      If CanRemoveUser(deleteRow.UserID) = False Then
        args = New UI.Processors.EventArgs()
        RaiseEvent CanNotRemove(Me, args)
        args = Nothing
        Exit Sub
      End If

      Dim cargs As UI.Processors.CancellableEventArgs = New CancellableEventArgs()
      userName = deleteRow.Username
      cargs.Data.Add("UserId", userID)

      RaiseEvent Removing(Me, cargs)
      If cargs.Cancel Then
        cargs.Data.Clear()
        cargs = Nothing
        Exit Sub
      End If
      cargs = Nothing

      deleteRow.Delete()
      rowsAffected = Synchronize()

      userName = Nothing
      deleteRow = Nothing

      args = New UI.Processors.EventArgs()
      args.Data.Add("RowsAffected", rowsAffected)
      RaiseEvent Removed(Me, args)
      args = Nothing

    End Sub


    ''' <summary>
    ''' Synchronizes user-role information between DataSet to database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadRoles(ByVal userId As Integer)

      Me.UserRolesTableAdapter.FillByUserId(UserDataSet.UserRoles, userId)

    End Sub

    ''' <summary>
    ''' Synchronizes user-role information between DataSet to database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveRolesForUser()
      Dim cancel As Boolean
      Dim rowsAffected As Integer
      Dim changesTable As Data.DataTable


      If Me.UserDataSet.UserRoles.GetChanges() Is Nothing Then
        RaiseEvent UserRolesInformationChangesNotFound()
        Exit Sub
      End If

      changesTable = UserDataSet.UserRoles.GetChanges().Copy()

      RaiseEvent SynchronizingUserRolesInformation(changesTable, cancel)
      If cancel Then Exit Sub

      rowsAffected = UserRolesTableAdapter.Update(UserDataSet.UserRoles)

      RaiseEvent UserRolesInformationSynchronized(changesTable, rowsAffected)

      If changesTable Is Nothing Then changesTable.Dispose()

    End Sub


  End Class

End Namespace