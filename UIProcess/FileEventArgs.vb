Namespace UI.Processors


  Public Class FileEventArgs
    Inherits FileSystemEventArgs


    Private m_totalFiles, m_fileIndex As Integer
    Private m_filePath As String


    Sub New()
      MyBase.New()
    End Sub

    Sub New(ByVal filePath As String, ByVal fileCount As Integer, ByVal currentFile As Integer)
      MyBase.New(filePath)
      m_totalFiles = fileCount
      m_fileIndex = currentFile
    End Sub


    ''' <summary>
    ''' Gets or sets file path.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property FilePath() As String
      Get
        Return m_filePath
      End Get
      Set(ByVal value As String)
        m_filePath = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets total number of files found under DirectoryPath property.
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

    ''' <summary>
    ''' Gets or sets current directory index, of the directory, whose path is DirectoryPath.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentFileIndex() As Integer
      Get
        Return m_fileIndex
      End Get
      Set(ByVal value As Integer)
        m_fileIndex = value
      End Set
    End Property


  End Class


End Namespace