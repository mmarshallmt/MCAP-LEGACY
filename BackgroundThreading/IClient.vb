Namespace BackgroundThreading
  Public Interface IClient
    Sub Start(ByVal Controller As Controller)
    Sub Display(ByVal Text As String)
    Sub Failed(ByVal e As Exception)
    Sub Completed(ByVal Cancelled As Boolean, ByVal partialSuccess As Boolean)
  End Interface
End Namespace

