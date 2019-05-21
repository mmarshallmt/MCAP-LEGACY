Namespace UI.Controls

  Public Class MessageBoxForm

    Private Const MAX_WIDTH As Single = 1000
    Private Const MAX_HEIGHT As Single = 1500


    Private m_response As System.Windows.Forms.DialogResult
    Private m_iconEnum As System.Windows.Forms.MessageBoxIcon
    Private m_buttonCollection As System.Collections.Generic.Dictionary(Of String, System.Windows.Forms.DialogResult)


    ''' <summary>
    ''' Gets or sets Title text for Message box.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Title() As String
      Get
        Return Me.Text
      End Get
      Set(ByVal value As String)
        Me.Text = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets message text, to be displayed on message box.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Message() As String
      Get
        Return Me.messageLabel.Text
      End Get
      Set(ByVal value As String)
        Me.messageLabel.Text = value
      End Set
    End Property

    ''' <summary>
    ''' Gets collection of dictionary items.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Buttons() As System.Collections.Generic.Dictionary(Of String, System.Windows.Forms.DialogResult)
      Get
        Return m_buttonCollection
      End Get
    End Property

    ''' <summary>
    ''' Gets or sets icon to be displayed on messagebox. Set None to display no icon or set custom icon.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MessageIcon() As System.Windows.Forms.MessageBoxIcon
      Get
        Return m_iconEnum
      End Get
      Set(ByVal value As System.Windows.Forms.MessageBoxIcon)
        m_iconEnum = value
        SetMessageIcon(value)
      End Set
    End Property


    ''' <summary>
    ''' Sets icon on message box.
    ''' </summary>
    ''' <param name="messageIcon"></param>
    ''' <remarks></remarks>
    Private Sub SetMessageIcon(ByVal messageIcon As System.Windows.Forms.MessageBoxIcon)

      Select Case messageIcon
        Case MessageBoxIcon.Error, MessageBoxIcon.Hand, MessageBoxIcon.Stop
          iconPictureBox.Image = My.Resources._Error.ToBitmap()
        Case MessageBoxIcon.Asterisk, MessageBoxIcon.Information
          iconPictureBox.Image = My.Resources.Information.ToBitmap()
        Case MessageBoxIcon.Question
          iconPictureBox.Image = My.Resources.Question.ToBitmap()
        Case MessageBoxIcon.Exclamation, MessageBoxIcon.Warning
          iconPictureBox.Image = My.Resources.Warning.ToBitmap()
        Case Else
          iconPictureBox.Image = Nothing
      End Select

      iconPictureBox.Refresh()

    End Sub

    ''' <summary>
    ''' Sets supplied image on message box.
    ''' </summary>
    ''' <param name="customIcon"></param>
    ''' <remarks></remarks>
    Public Sub SetMessageIcon(ByVal customIcon As System.Drawing.Image)

      If Me.MessageIcon <> MessageBoxIcon.None Then Exit Sub

      Me.iconPictureBox.Image = customIcon

    End Sub


    ''' <summary>
    ''' Creates buttons based on Buttons property. 
    ''' </summary>
    ''' <param name="buttons"></param>
    ''' <remarks></remarks>
    Private Sub CreateButtons(ByVal buttons As System.Collections.Generic.Dictionary(Of String, System.Windows.Forms.DialogResult))
      Dim buttonCounter, xPos As Integer
      Dim di As System.Collections.Generic.KeyValuePair(Of String, System.Windows.Forms.DialogResult)


      buttonCounter = 0
      xPos = 0
      For Each di In m_buttonCollection
        Dim g As System.Drawing.Graphics
        Dim btnTextSize As System.Drawing.SizeF, btnSize As System.Drawing.Size
        Dim btn As System.Windows.Forms.Button = New System.Windows.Forms.Button()


        g = btn.CreateGraphics()
        btnTextSize = g.MeasureString(di.Key, btn.Font)
        g.Dispose()
        g = Nothing

        If btnTextSize.Width < btn.Width Then
          btnSize = btn.Size
        Else
          btnSize = New System.Drawing.Size(CType(btnTextSize.Width + 20, Integer), btn.Size.Height)
        End If

        buttonCounter += 1

        buttonPanel.Controls.Add(btn)
        With btn
          .Name = "Button" + buttonCounter.ToString()
          .Text = di.Key
          .Size = btnSize
          .Location = New System.Drawing.Point(xPos, sampleButton.Location.Y)
          .Visible = True
        End With
        AddHandler btn.Click, AddressOf Button_Click

        xPos = btn.Location.X + btn.Size.Width + 10
        btn = Nothing
      Next

    End Sub


    Private Function IsMessageBoxSizeSufficientForMessageText() As Boolean
      Dim lines, labelLines As Single
      Dim g As System.Drawing.Graphics
      Dim size As System.Drawing.SizeF


      g = messageLabel.CreateGraphics()
      size = g.MeasureString(messageLabel.Text, messageLabel.Font)
      lines = (size.Width / Me.messageLabel.Width) + 1
      labelLines = (messageLabel.Height / messageLabel.Font.GetHeight(g)) + 1

      size = Nothing
      g.Dispose()
      g = Nothing

      Return (lines < labelLines)

    End Function

    Private Function IsMessageBoxSizeSufficientForButtons() As Boolean
      Dim requiredWidth As Single
      Dim tempBtn As System.Windows.Forms.Button


      tempBtn = CType(Me.buttonPanel.Controls("Button" + Me.Buttons.Count.ToString()), System.Windows.Forms.Button)
      requiredWidth += tempBtn.Left + tempBtn.Width + 10
      tempBtn = Nothing

      Return (messageLabel.Width > requiredWidth)

    End Function

    Private Function IsMessageBoxSizeSufficient() As Boolean

      Return (IsMessageBoxSizeSufficientForMessageText() AndAlso IsMessageBoxSizeSufficientForButtons())

    End Function

    Private Sub IncreaseWidthOfMessageBox(ByVal maximumWidth As Single)
      Dim width As Single


      width = Me.Width

      While (IsMessageBoxSizeSufficient() = False) AndAlso (width < maximumWidth)
        Me.Width += 250
        width = Me.Width
      End While

    End Sub

    Private Sub IncreaseHeightOfMessageBox(ByVal maximumHeight As Single)
      Dim height As Single


      height = Me.Height

      While (IsMessageBoxSizeSufficient() = False) AndAlso (Width < maximumHeight)
        Me.Height += 250
        height = Me.Height
      End While

    End Sub

    Public Sub SetMessageBoxSize()

      IncreaseWidthOfMessageBox(MAX_WIDTH)

      If Me.Width >= MAX_WIDTH Then
        IncreaseHeightOfMessageBox(MAX_HEIGHT)
      End If

    End Sub


    Public Sub Initialize()

      CreateButtons(Me.Buttons)
      SetMessageBoxSize()
      SetMessageIcon(Me.MessageIcon)

    End Sub


    Private Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim buttonText As String


      buttonText = CType(sender, System.Windows.Forms.Button).Text
      m_response = m_buttonCollection(buttonText)

      buttonText = Nothing

      Me.DialogResult = m_response
      Me.Close()

    End Sub


  End Class

End Namespace