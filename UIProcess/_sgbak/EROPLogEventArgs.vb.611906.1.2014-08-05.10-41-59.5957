Namespace UI.Processors


  Public Class EROPLogEventArgs
    Inherits System.EventArgs


    Private m_eropLogRow As eropDataSet.EROPLogRow


    Sub New()
      'Default constructor
    End Sub

    Sub New(ByVal row As eropDataSet.EROPLogRow)
      MyBase.New()
      m_eropLogRow = row
    End Sub


    Public Property Row() As eropDataSet.EROPLogRow
      Get
        Return m_eropLogRow
      End Get
      Set(ByVal value As eropDataSet.EROPLogRow)
        m_eropLogRow = value
      End Set
    End Property


  End Class


End Namespace