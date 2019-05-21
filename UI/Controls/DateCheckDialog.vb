Namespace UI


  ''' <summary>
  ''' A dialog to display confirmation prompt while validating date(i.e. ad date, sale start and end date) values.
  ''' </summary>
  ''' <remarks></remarks>
  Public Class DateCheckDialog


    Private m_allowIgnoreKey As Boolean
    Private m_messageText As String


    ''' <summary>
    ''' Gets or sets boolean flag, indicating whether to allow ignore key combination 
    ''' to override messagebox or not.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AllowIgnoreKey() As Boolean
      Get
        Return m_allowIgnoreKey
      End Get
      Set(ByVal value As Boolean)
        m_allowIgnoreKey = value
        ignoreButton.Visible = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets message text, which will be displayed on the dialog.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MessageText() As String
      Get
        Return m_messageText
      End Get
      Set(ByVal value As String)
        m_messageText = value
        messageLabel.Text = value
      End Set
    End Property


    Private Sub DateCheckDialog_KeyUp _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles Me.KeyUp

      If Me.AllowIgnoreKey AndAlso e.Shift = False AndAlso e.Alt = False AndAlso e.Control = True AndAlso e.KeyCode = Keys.I Then
        'ignoreButton.PerformClick()
        Me.DialogResult = Windows.Forms.DialogResult.Ignore
        Me.Close()
      End If

    End Sub

    Private Sub DateCheckDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

      Me.PictureBox1.Image = My.Resources.Warning.ToBitmap()
      Me.DialogResult = Windows.Forms.DialogResult.None
      okButton.Focus()

    End Sub

    Private Sub DateCheckDialog_FormClosing _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) _
        Handles Me.FormClosing

      If Me.DialogResult = Windows.Forms.DialogResult.Cancel Then Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub ignoreButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ignoreButton.Click

      Me.DialogResult = Windows.Forms.DialogResult.Ignore
      Me.Close()

    End Sub

    Private Sub okButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles okButton.Click

      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()

    End Sub


  End Class


End Namespace