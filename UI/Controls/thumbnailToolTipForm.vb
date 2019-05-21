Namespace UI.Controls


  Public Class thumbnailToolTipForm


    ''' <summary>
    ''' Text to be displayed on form.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ToolTipText() As String
      Get
        Return Me.tooltipLabel.Text
      End Get
      Set(ByVal value As String)
        Me.tooltipLabel.Text = value
      End Set
    End Property


    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click
      Me.Close()
    End Sub


  End Class


End Namespace