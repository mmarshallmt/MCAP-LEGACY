Namespace UI.Processors


  Public Class MoveImageEventArgs
    Inherits System.EventArgs


    Private m_rotationAngle, m_currentFileIndex As Integer
    Private m_sourceImagePath, m_destinationImagePath As String


    Sub New()
      MyBase.New()
    End Sub

    Sub New(ByVal sourceImagePath As String, ByVal destinationImagePath As String, ByVal rotationAngle As Integer, ByVal currentFileIndex As Integer)
      MyBase.New()
      m_sourceImagePath = sourceImagePath
      m_destinationImagePath = destinationImagePath
      m_rotationAngle = rotationAngle
      m_currentFileIndex = currentFileIndex
    End Sub


    ''' <summary>
    ''' Gets or sets absolute path of source image.
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
    ''' Gets or sets absolute path for destination image.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DestinationPath() As String
      Get
        Return m_destinationImagePath
      End Get
      Set(ByVal value As String)
        m_destinationImagePath = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets rotation angle for destination image.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RotationAngle() As Integer
      Get
        Return m_rotationAngle
      End Get
      Set(ByVal value As Integer)
        m_rotationAngle = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets current file index within total number of files in publication folder. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CurrentFileIndex() As Integer
      Get
        Return m_currentFileIndex
      End Get
      Set(ByVal value As Integer)
        m_currentFileIndex = value
      End Set
    End Property


  End Class


End Namespace