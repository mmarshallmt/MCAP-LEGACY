Namespace UI.Processors

  ''' <summary>
  ''' A non-GUI class to process information about logged on application user. 
  ''' </summary>
  ''' <remarks></remarks>
  Public Class ApplicationUser
    Inherits UI.Processors.UserBase



    Public Event Initializing()
    Public Event Initialized()

    Public Event PreparingAdapter()
    Public Event AdapterPrepared()

    Public Event LoadingFunctionalityList()
    Public Event FunctionalityListLoaded()

    Public Event LoadingUserCredentials()
    Public Event UserCredentialsLoaded()

    Public Class Functionality
      Public Const ViewOnly As String = "VIEWONLY"
      Public Const EditOnly As String = "EDITONLY"
      Public Const NewOnly As String = "NEWONLY"
    End Class

    ''' <summary>
    ''' Default constructor.
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()
      MyBase.New()
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

      RaiseEvent Initializing()

      Me.PrepareDataAdapter()

      RaiseEvent Initialized()

    End Sub


    ''' <summary>
    ''' Returns true if user name is a valid application user, false otherwise.
    ''' </summary>
    ''' <param name="userName">User name to check for validity.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsValidUser(ByVal userName As String) As Boolean
      Dim isValid As Boolean


      UserTableAdapter.FillByUserName(UserDataSet.User, userName)

      If UserDataSet.User.Count > 0 Then
        m_currentUser = UserDataSet.User(0)
        isValid = (m_currentUser.ActiveInd = 1)
      End If

      If isValid = False Then m_currentUser = Nothing

      Return isValid

    End Function

    ''' <summary>
    ''' Loads list of functionalities available on this form and its availablity 
    ''' for supplied user name and form name.
    ''' </summary>
    ''' <param name="userName">User Name</param>
    ''' <param name="formName">Form name</param>
    ''' <returns>
    ''' Information about functionality on screen and its availablity to user.
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetFunctionalityListFor(ByVal userName As String, ByVal formName As String) As UserRolesDataSet.UserScreensFunctionalityViewDataTable
      UserScreensTableAdapter.FillByUsernameFormName(UserDataSet.UserScreensFunctionalityView, userName, formName)
      Return UserDataSet.UserScreensFunctionalityView
    End Function

    ''' <summary>
    ''' Loads list of functionalities available on this form and its availablity 
    ''' for supplied user ID and form name.
    ''' </summary>
    ''' <param name="userID">Application User ID</param>
    ''' <param name="formName">Form Name</param>
    ''' <returns>
    ''' Information about functionality on screen and its availablity to user.
    ''' </returns>
    ''' <remarks></remarks>
    Public Function GetFunctionalityListFor(ByVal userID As Integer, ByVal formName As String) As UserRolesDataSet.UserScreensFunctionalityViewDataTable
      UserScreensTableAdapter.FillByUserIdFormName(UserDataSet.UserScreensFunctionalityView, userID, formName)
      Return UserDataSet.UserScreensFunctionalityView
    End Function

    ''' <summary>
    ''' Loads list of screens and available functionalities on each screen, based 
    ''' on assigned role to supplied user name.
    ''' </summary>
    ''' <param name="userName"></param>
    ''' <returns>Information about all screen available for user.</returns>
    ''' <remarks></remarks>
    Public Function GetCredentialsForUser(ByVal userName As String) As System.Data.DataTable

    End Function

    ''' <summary>
    ''' Loads list of screens and available functionalities on each screen, based 
    ''' on assigned role to supplied user ID.
    ''' </summary>
    ''' <param name="userID"></param>
    ''' <returns>Information about all scren available for user.</returns>
    ''' <remarks></remarks>
    Public Function GetCredentialsForUser(ByVal userID As Integer) As System.Data.DataTable

    End Function

  End Class


End Namespace