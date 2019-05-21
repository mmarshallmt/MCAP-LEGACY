Namespace UI.Processors


  Public Class ConversionEventArgs
    Inherits System.EventArgs


    Private m_totalPublications As Integer


    Sub New()
      MyBase.New()
    End Sub

    Sub New(ByVal totalPublications As Integer)
      m_totalPublications = totalPublications
    End Sub


    ''' <summary>
    ''' Gets or sets total number of publications qualify for conversion of PDF files to images.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TotalPublications() As Integer
      Get
        Return m_totalPublications
      End Get
      Set(ByVal value As Integer)
        m_totalPublications = value
      End Set
    End Property


  End Class


  Public Class PublicationConversionEventArgs
    Inherits ConversionEventArgs


    Private m_currentPublicationIndex, m_totalFiles As Integer
    Private m_publicationFolderPath As String


    Sub New()
      MyBase.New()
    End Sub

    Sub New(ByVal totalPublications As Integer, ByVal currentPublicationIndex As Integer, ByVal publicationFolderPath As String, ByVal totalFiles As Integer)
      MyBase.New(totalPublications)

      m_currentPublicationIndex = currentPublicationIndex
      m_publicationFolderPath = publicationFolderPath
      m_totalFiles = totalFiles

    End Sub


    ''' <summary>
    ''' Gets or sets current publication index within total number of publications.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentPublicationIndex() As Integer
      Get
        Return m_currentPublicationIndex
      End Get
      Set(ByVal value As Integer)
        m_currentPublicationIndex = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets absolute path for Publication, where PDF/Zip file(s) are store for the publication.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PublicationFolderPath() As String
      Get
        Return m_publicationFolderPath
      End Get
      Set(ByVal value As String)
        m_publicationFolderPath = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets total number of PDF files under publication folder.
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


  Public Class FileConversionEventArgs
    Inherits PublicationConversionEventArgs


    Private m_fileIndex, m_totalPages As Integer
    Private m_filePath As String


    Sub New()
      MyBase.New()
    End Sub

    Sub New(ByVal pcea As PublicationConversionEventArgs, ByVal fileIndex As Integer, ByVal filePath As String, ByVal totalPages As Integer)
      MyBase.New(pcea.TotalPublications, pcea.CurrentPublicationIndex, pcea.PublicationFolderPath, pcea.TotalFiles)
      m_fileIndex = fileIndex
      m_filePath = filePath
      m_totalPages = totalPages
    End Sub

    Sub New(ByVal totalPublications As Integer, ByVal currentPublicationIndex As Integer, ByVal publicationFolderPath As String, ByVal totalFiles As Integer, ByVal fileIndex As Integer, ByVal filePath As String, ByVal totalPages As Integer)
      MyBase.New(totalPublications, currentPublicationIndex, publicationFolderPath, totalFiles)
      m_fileIndex = fileIndex
      m_filePath = filePath
      m_totalPages = totalPages
    End Sub


    ''' <summary>
    ''' Sets properties of parent(i.e. PublicationConversionEventArgs).
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Friend WriteOnly Property PCEA() As PublicationConversionEventArgs
      Set(ByVal value As PublicationConversionEventArgs)
        MyBase.TotalPublications = value.TotalPublications
        MyBase.CurrentPublicationIndex = value.CurrentPublicationIndex
        MyBase.PublicationFolderPath = value.PublicationFolderPath
        MyBase.TotalFiles = value.TotalFiles
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets file index for current file within total number of files.
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

    ''' <summary>
    ''' Gets or sets absolute file path for current file.
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
    ''' Gets or sets total number of pages in current file.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TotalPages() As Integer
      Get
        Return m_totalPages
      End Get
      Set(ByVal value As Integer)
        m_totalPages = value
      End Set
    End Property


  End Class


  Public Class PageConversionEventArgs
    Inherits FileConversionEventArgs


    Private m_pageNumber, m_publicationPageNumber As Integer


    Sub New()
      MyBase.New()
    End Sub

    Sub New(ByVal fcea As FileConversionEventArgs, ByVal pageNumber As Integer, ByVal publicationPageNumber As Integer)
      MyBase.New(fcea.TotalPublications, fcea.CurrentPublicationIndex, fcea.PublicationFolderPath, fcea.TotalFiles, fcea.CurrentFileIndex, fcea.FilePath, fcea.TotalPages)
      m_pageNumber = pageNumber
      m_publicationPageNumber = publicationPageNumber
    End Sub


    ''' <summary>
    ''' Gets or sets page number of page, of the PDF file, currently under process.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PageNumber() As Integer
      Get
        Return m_pageNumber
      End Get
      Set(ByVal value As Integer)
        m_pageNumber = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets page number for publication(image name).
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PublicationPageNumber() As Integer
      Get
        Return m_publicationPageNumber
      End Get
      Set(ByVal value As Integer)
        m_publicationPageNumber = value
      End Set
    End Property


  End Class

End Namespace