Namespace UI.Processors


  Public Class DoubleTruckPageEventArgs
    Inherits System.EventArgs


    Private m_splitImageAt As Integer
    Private m_sourceImagePath, m_splitImagePath As String


    Sub New()
      MyBase.New()
    End Sub

    Sub New(ByVal sourceImagePath As String, ByVal splitImagePath As String, ByVal splitImageAt As Integer)
      MyBase.New()
      m_sourceImagePath = sourceImagePath
      m_splitImagePath = splitImagePath
      m_splitImageAt = splitImageAt
    End Sub


    ''' <summary>
    ''' Gets or sets absolute path of source(double truck Ad) image.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SourceImagePath() As String
      Get
        Return m_sourceImagePath
      End Get
      Set(ByVal value As String)
        m_sourceImagePath = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets absolute path to store split image.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SplitImagePath() As String
      Get
        Return m_splitImagePath
      End Get
      Set(ByVal value As String)
        m_splitImagePath = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets pixel from where the source image will get split.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SplitImageAt() As Integer
      Get
        Return m_splitImageAt
      End Get
      Set(ByVal value As Integer)
        m_splitImageAt = value
      End Set
    End Property


  End Class


End Namespace