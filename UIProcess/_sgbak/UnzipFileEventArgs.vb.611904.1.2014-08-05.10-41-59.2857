Namespace UI.Processors


  Public Class UnzipFileEventArgs
    Inherits System.EventArgs


    Private m_zipFilePath, m_destinationFolderPath As String


    Sub New()
      'Default constructor
    End Sub

    Sub New(ByVal zipFilePath As String, ByVal destinationFolderPath As String)
      MyBase.New()
      m_zipFilePath = zipFilePath
      m_destinationFolderPath = destinationFolderPath
    End Sub


    Public ReadOnly Property ZipFilePath() As String
      Get
        Return m_zipFilePath
      End Get
    End Property

    Public ReadOnly Property DestinationFolderPath() As String
      Get
        Return m_destinationFolderPath
      End Get
    End Property

  End Class


End Namespace