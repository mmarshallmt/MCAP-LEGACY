Namespace UI.Processors


  Public Class UserBase
    Inherits UI.Processors.BaseClass


#Region " Events "

    Public Event LoadingScreenList As MCAPCancellableEventHandler
    Public Event ScreenListLoaded As MCAPEventHandler

    Public Event SearchingUserInformation As MCAPCancellableEventHandler
    Public Event UserInformationFound As MCAPEventHandler
    Public Event UserInformationNotFound As MCAPEventHandler

#End Region


#Region " Member variables "

    ''' <summary>
    ''' DataAdapter to fetch role information from Database.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_roleTableAdapter As UserRolesDataSetTableAdapters.RoleTableAdapter

    ''' <summary>
    ''' DataSet stores information from users as well as other related tables.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_userDataSet As UserRolesDataSet

    ''' <summary>
    ''' DataAdapter to synchronize user-role association information between 
    ''' DataSet and Database.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_userRolesTableAdapter As UserRolesDataSetTableAdapters.UserRolesTableAdapter

    ''' <summary>
    ''' DataAdapter to synchronize user's information between DataSet and 
    ''' Database.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_userTableAdapter As UserRolesDataSetTableAdapters.UserTableAdapter

    ''' <summary>
    ''' Table adapter to fetch rows from UserScreenFunctionalityView.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_userScreenTableAdapter _
        As MCAP.UserRolesDataSetTableAdapters.UserScreensFunctionalityViewTableAdapter

#End Region



    ''' <summary>
    ''' Gets Adapter for role table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property RoleTableAdapter() As UserRolesDataSetTableAdapters.RoleTableAdapter
      Get
        Return m_roleTableAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets dataset containing tables related to user information.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UserDataSet() As UserRolesDataSet
      Get
        Return m_userDataSet
      End Get
    End Property

    ''' <summary>
    ''' Gets Adapter for user-role table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property UserRolesTableAdapter() As UserRolesDataSetTableAdapters.UserRolesTableAdapter
      Get
        Return m_userRolesTableAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets Adapter for user table. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property UserTableAdapter() As UserRolesDataSetTableAdapters.UserTableAdapter
      Get
        Return m_userTableAdapter
      End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property UserScreensTableAdapter() _
        As MCAP.UserRolesDataSetTableAdapters.UserScreensFunctionalityViewTableAdapter
      Get
        Return m_userScreenTableAdapter
      End Get
    End Property



    ''' <summary>
    ''' Default constructor
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()
      MyBase.new()
      m_userDataSet = New UserRolesDataSet
      m_roleTableAdapter = New UserRolesDataSetTableAdapters.RoleTableAdapter
      m_userRolesTableAdapter = New UserRolesDataSetTableAdapters.UserRolesTableAdapter
      m_userTableAdapter = New UserRolesDataSetTableAdapters.UserTableAdapter
      m_userScreenTableAdapter = New UserRolesDataSetTableAdapters.UserScreensFunctionalityViewTableAdapter
    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      m_userDataSet.Dispose()
      m_roleTableAdapter.Dispose()
      m_userRolesTableAdapter.Dispose()
      m_userTableAdapter.Dispose()
      m_userScreenTableAdapter.Dispose()

      m_userDataSet = Nothing
      m_roleTableAdapter = Nothing
      m_userRolesTableAdapter = Nothing
      m_userTableAdapter = Nothing
      m_userScreenTableAdapter = Nothing

      MyBase.Dispose(disposing)

    End Sub



    ''' <summary>
    ''' Prepares Select, Insert, Update and Delete command and assign it to
    ''' DataAdapter.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub PrepareDataAdapter()

      m_roleTableAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_userTableAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_userRolesTableAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_userScreenTableAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

    End Sub

    ''' <summary>
    ''' Gets user information based on supplied userId.
    ''' </summary>
    ''' <param name="userId">UserId, whose information is needed.</param>
    ''' <returns>
    ''' DataRowView containing information about supplied user name.
    ''' </returns>
    ''' <remarks></remarks>
    Protected Function GetUser(ByVal userId As Integer) As MCAP.UserRolesDataSet.UserRow
      Dim searchRow As MCAP.UserRolesDataSet.UserRow


      searchRow = UserDataSet.User.FindByUserID(userId)

      Return searchRow

    End Function

    ''' <summary>
    ''' Gets user information based on supplied user name.
    ''' </summary>
    ''' <param name="userName">User name, whose information is needed.</param>
    ''' <returns>
    ''' DataRowView containing information about supplied user name.
    ''' </returns>
    ''' <remarks></remarks>
    Protected Function GetUser(ByVal userName As String) As MCAP.UserRolesDataSet.UserRow
      Dim tempView As Data.DataView
      Dim searchRow As MCAP.UserRolesDataSet.UserRow


      tempView = New Data.DataView(UserDataSet.User)
      tempView.RowFilter = "UserName='" + userName.Replace("'", "''") + "'"

      If tempView.Count = 0 Then
        searchRow = Nothing
      Else
        searchRow = CType(tempView(0).Row, MCAP.UserRolesDataSet.UserRow)
      End If

      tempView.Dispose()
      tempView = Nothing

      Return searchRow

    End Function


    ''' <summary>
    ''' Finds user information based on supplied user name.
    ''' </summary>
    ''' <param name="userName">User name, whose information is needed.</param>
    ''' <remarks></remarks>
    Public Sub FindUser(ByVal userName As String)
      Dim searchRow As MCAP.UserRolesDataSet.UserRow
      Dim args As MCAP.UI.Processors.EventArgs
      Dim cargs As MCAP.UI.Processors.CancellableEventArgs


      cargs = New MCAP.UI.Processors.CancellableEventArgs()

      RaiseEvent SearchingUserInformation(Me, cargs)
      If cargs.Cancel Then
        cargs = Nothing
        Exit Sub
      End If

      cargs = Nothing
      args = New MCAP.UI.Processors.EventArgs()

      searchRow = Me.GetUser(userName)
      If searchRow Is Nothing Then
        args.Data.Add("UserName", userName)
        RaiseEvent UserInformationNotFound(Me, args)
      Else
        args.Data.Add("User", searchRow)
        RaiseEvent UserInformationFound(Me, args)
      End If

      searchRow = Nothing
      args.Data.Clear()
      args = Nothing
    End Sub

    ''' <summary>
    ''' Finds user information based on supplied user ID.
    ''' </summary>
    ''' <param name="userID">User information is returned based on supplied UserID.</param>
    ''' <remarks></remarks>
    Public Sub UpdateUser(ByVal userID As Integer)
      Dim searchRow As UserRolesDataSet.UserRow
      Dim args As MCAP.UI.Processors.EventArgs
      Dim cargs As MCAP.UI.Processors.CancellableEventArgs


      cargs = New MCAP.UI.Processors.CancellableEventArgs()

      RaiseEvent SearchingUserInformation(Me, cargs)
      If cargs.Cancel Then
        cargs = Nothing
        Exit Sub
      End If

      cargs = Nothing
      args = New MCAP.UI.Processors.EventArgs()

      searchRow = Me.GetUser(userID)
      If searchRow Is Nothing Then
        args.Data.Add("UserId", userID)
        RaiseEvent UserInformationNotFound(Me, args)
      Else
        args.Data.Add("User", searchRow)
        RaiseEvent UserInformationFound(Me, args)
      End If

      searchRow = Nothing
      args.Data.Clear()
      args = Nothing
    End Sub

    ''' <summary>
    ''' Loads list of screens, based on assigned role to supplied user ID.
    ''' </summary>
    ''' <param name="userID"></param>
    ''' <returns>Information about all scren available for user.</returns>
    ''' <remarks></remarks>
    Public Function GetFormListFor(ByVal userID As Integer) As MCAP.UserRolesDataSet.UserScreensFunctionalityViewDataTable

      Me.UserScreensTableAdapter.FillByUserId(UserDataSet.UserScreensFunctionalityView, userID)

      Return CType(UserDataSet.UserScreensFunctionalityView.Copy(), MCAP.UserRolesDataSet.UserScreensFunctionalityViewDataTable)

    End Function

  End Class


End Namespace