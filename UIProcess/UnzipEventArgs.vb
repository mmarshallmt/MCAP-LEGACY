Namespace UI.Processors


  Public Class UnzipEventArgs
    Inherits System.EventArgs

    Private m_publicationId, m_zipFilesCount As Integer
    Private m_downloadFolderPath As String


    Sub New()
      MyBase.New()
    End Sub

    Sub New(ByVal downloadFolderPath As String, ByVal publicationId As Integer, ByVal Count As Integer)
      MyBase.New()
      m_publicationId = publicationId
      m_zipFilesCount = Count
      m_downloadFolderPath = downloadFolderPath
    End Sub


    Public ReadOnly Property DownloadFolderPath() As String
      Get
        Return m_downloadFolderPath
      End Get
    End Property

    Public ReadOnly Property PublicationId() As Integer
      Get
        Return m_publicationId
      End Get
    End Property

    Public ReadOnly Property Count() As Integer
      Get
        Return m_zipFilesCount
      End Get
    End Property


  End Class


End Namespace