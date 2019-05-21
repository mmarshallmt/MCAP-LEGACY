Namespace UI.Controls

  Public Class StatusMessageForm

    ''' <summary>
    ''' Message to be displayed.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MessageText() As String
      Get
        Return statusMessageLabel.Text
      End Get
      Set(ByVal value As String)
        statusMessageLabel.Text = value
      End Set
    End Property

  End Class

End Namespace
