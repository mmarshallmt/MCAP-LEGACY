Namespace UI.Controls

  Public Class ProgressInformationForm


    ''' <summary>
    ''' Gets or sets text for message. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property MessageText() As String
      Get
        Return messageLabel.Text
      End Get
      Set(ByVal value As String)
        messageLabel.Text = value
        messageLabel.Refresh()
        Application.DoEvents()
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets text for progress.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property ProgressText() As String
      Get
        Return progressLabel.Text
      End Get
      Set(ByVal value As String)
        progressLabel.Text = value
        progressLabel.Refresh()
        Application.DoEvents()
      End Set
    End Property


  End Class

End Namespace