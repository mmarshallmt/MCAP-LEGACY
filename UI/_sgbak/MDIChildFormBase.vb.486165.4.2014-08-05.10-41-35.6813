Namespace UI

  Public Class MDIChildFormBase


    Private m_statusMessage As String



    ''' <summary>
    ''' Gets or sets status message to be shown when form is active.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StatusMessage() As String
      Get
        Return m_statusMessage
      End Get
      Set(ByVal Value As String)
        m_statusMessage = Value
        RefreshStatus()
      End Set
    End Property



    ''' <summary>
    ''' Refreshes statusbar text. Replaces text on statusbar with the text 
    ''' stored in StatusMessage property.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub RefreshStatus()

      If Not Me.ParentForm Is Nothing Then
        Application.DoEvents()
        CType(Me.ParentForm, MDIForm).StatusStrip.Items _
            ("ToolStripStatusLabel").Text = m_statusMessage
        CType(Me.ParentForm, MDIForm).StatusStrip.Refresh()
        Application.DoEvents()
      End If

    End Sub

    ''' <summary>
    ''' Sets position of current form or forms inherited from this form in center 
    ''' of its MDI Form.
    ''' </summary>
    ''' <remarks>
    ''' If height or width of the MDI Form is smaller than current form,
    ''' displays current form in maximize state.
    ''' </remarks>
    Public Sub MoveToCenter()
      Dim leftPos, topPos As Integer


      If Me.IsMdiChild Then
        If Me.ParentForm.ClientSize.Height < Me.Height _
            Or Me.ParentForm.ClientSize.Width < Me.Width _
        Then
          Me.WindowState = FormWindowState.Maximized
        Else
          leftPos = (Me.ParentForm.ClientSize.Width - Me.Width) \ 2
          topPos = (Me.ParentForm.ClientSize.Height - Me.Height) \ 2
          Me.Location = New System.Drawing.Point(leftPos, topPos)
        End If
      End If

    End Sub



    Private Sub MDIChildFormBase_Load _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Load

      m_statusMessage = ""
      MoveToCenter()

    End Sub

    Private Sub MDIChildFormBase_Activated _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Activated

      Me.RefreshStatus()

    End Sub


  End Class

End Namespace
