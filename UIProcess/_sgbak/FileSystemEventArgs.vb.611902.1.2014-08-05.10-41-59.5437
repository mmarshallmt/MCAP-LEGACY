Namespace UI.Processors


  Public Class FileSystemEventArgs
    Inherits System.EventArgs


    Private m_path As String


    Sub New()
      MyBase.New()
    End Sub

    Sub New(ByVal FileSystemPath As String)
      MyBase.New()
      Me.m_path = FileSystemPath
    End Sub


    ''' <summary>
    ''' Absolute file-system path.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Path() As String
      Get
        Return Me.m_path
      End Get
      Set(ByVal value As String)
        Me.m_path = value
      End Set
    End Property


  End Class


End Namespace