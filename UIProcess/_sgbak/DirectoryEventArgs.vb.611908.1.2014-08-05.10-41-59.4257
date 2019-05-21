Namespace UI.Processors


  Public Class DirectoryEventArgs
    Inherits FileSystemEventArgs


    Private m_totalDirectories, m_directoryIndex As Integer
    Private m_subfolderPath As String


    Sub New()
      MyBase.New()
    End Sub

    Sub New(ByVal directoryPath As String, ByVal totalDirectories As Integer, ByVal currentDirectory As Integer)
      MyBase.New(directoryPath)
      Me.TotalSubdirectories = totalDirectories
      Me.CurrentSubdirectoryIndex = currentDirectory
    End Sub


    ''' <summary>
    ''' Gets or sets directory path.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DirectoryPath() As String
      Get
        Return m_subfolderPath
      End Get
      Set(ByVal value As String)
        m_subfolderPath = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets total number of subdirectories found under DirectoryPath property.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TotalSubdirectories() As Integer
      Get
        Return m_totalDirectories
      End Get
      Set(ByVal value As Integer)
        m_totalDirectories = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets current directory index.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentSubdirectoryIndex() As Integer
      Get
        Return m_directoryIndex
      End Get
      Set(ByVal value As Integer)
        m_directoryIndex = value
      End Set
    End Property


  End Class


End Namespace