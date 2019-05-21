Namespace UI.Processors

  Public Class CancellableEventArgs
    Inherits UI.Processors.EventArgs


    Private _cancel As Boolean


    Sub New()

      MyBase.New()

      _cancel = False

    End Sub

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      MyBase.Dispose(disposing)
    End Sub


    ''' <summary>
    ''' Gets or sets flag indicating whether user wants to cancel current process.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Cancel() As Boolean
      Get
        Return _cancel
      End Get
      Set(ByVal value As Boolean)
        _cancel = value
      End Set
    End Property


  End Class

End Namespace