Namespace BackgroundThreading

  Public Interface IController
    ReadOnly Property Running() As Boolean
    ReadOnly Property ErrorList() As ArrayList
    Sub Display(ByVal text As String)
    Sub SetPercent(ByVal percent As Integer)
    Sub SetCount(ByVal count As Integer)
    Sub Failed(ByVal e As Exception)
    Sub Completed(ByVal cancelled As Boolean, ByVal partialSuccess As Boolean)
    Sub SetInfoList(ByVal infoList As ArrayList)
    Sub SetRunningTaskType(ByVal taskType As TaskType)
    Enum TaskType
      RenameAndMoveImages
      MoveImages
      CountImages
    End Enum
  End Interface

End Namespace
