Namespace UI.Processors


  Public Class MovePublicationImagesEventArgs
    Inherits System.EventArgs


    Private m_totalDirectories, m_currentDirectoryIndex, m_totalFiles As Integer
    Private m_sourcePath, m_destinationPath As String


    Sub New()
      MyBase.New()
    End Sub

    Sub New(ByVal sourceFolderPath As String, ByVal destinationFolderPath As String, ByVal totalDirectories As Integer, ByVal currentDirectoryIndex As Integer, ByVal totalFiles As Integer)
      m_totalFiles = totalFiles
      m_sourcePath = sourceFolderPath
      m_destinationPath = destinationFolderPath
    End Sub


    ''' <summary>
    ''' Gets or sets total number of directories.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TotalDirectories() As Integer
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
    Public Property CurrentDirectoryIndex() As Integer
      Get
        Return m_currentDirectoryIndex
      End Get
      Set(ByVal value As Integer)
        m_currentDirectoryIndex = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets absolute path for source folder.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SourceFolderPath() As String
      Get
        Return m_sourcePath
      End Get
      Set(ByVal value As String)
        m_sourcePath = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets absolute path for destination folder.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DestinationFolderPath() As String
      Get
        Return m_destinationPath
      End Get
      Set(ByVal value As String)
        m_destinationPath = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets total number of files in source folder.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TotalFiles() As Integer
      Get
        Return m_totalFiles
      End Get
      Set(ByVal value As Integer)
        m_totalFiles = value
      End Set
    End Property


  End Class


End Namespace