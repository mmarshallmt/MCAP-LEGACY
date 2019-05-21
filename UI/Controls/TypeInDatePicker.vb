Namespace UI.Controls


  Public Class TypeInDatePicker


    Private m_isEscaped As Boolean
    Private m_dateValue As Nullable(Of DateTime)



    Public Overrides Property ForeColor() As System.Drawing.Color
      Get
        Return MyBase.ForeColor
      End Get
      Set(ByVal value As System.Drawing.Color)
        MyBase.ForeColor = value
        Me.dateMaskedTextBox.ForeColor = value
        Me.DTPicker.CalendarForeColor = value
      End Set
    End Property

    Public Overrides Property BackColor() As System.Drawing.Color
      Get
        Return MyBase.BackColor
      End Get
      Set(ByVal value As System.Drawing.Color)
        MyBase.BackColor = value
        Me.dateMaskedTextBox.BackColor = value
        Me.DTPicker.CalendarMonthBackground = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets text value of the control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>
    ''' When Value property is Nothing, Text property returns text displayed in control.
    ''' Hence, it is not necessary that Value and Text property both returns same value.
    ''' </remarks>
    Public Overrides Property Text() As String
      Get
        Return dateMaskedTextBox.Text
      End Get
      Set(ByVal value As String)
        dateMaskedTextBox.Text = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets value displayed on control. Set Nothing to clear value. 
    ''' Similarly it returns nothing if valid date is not specified on control.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Value() As Nullable(Of DateTime)
      Get
        Return m_dateValue
      End Get
      Set(ByVal value As Nullable(Of DateTime))
        m_dateValue = value
        OnValueChanged(New System.EventArgs)
      End Set
    End Property



    ''' <summary>
    ''' Refreshes dateMaskedTextBox on control to show value stored in 
    ''' m_dateValue variable. Clears dateMaskedTextBox if m_dateValue contains
    ''' Nothing.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateDateValue(ByVal dateText As String)
      Dim tempDate As DateTime


      If DateTime.TryParse(dateText, tempDate) Then
        m_dateValue = tempDate
      Else
        m_dateValue = Nothing
      End If

    End Sub

    ''' <summary>
    ''' Assigns value of text property of this control.
    ''' </summary>
    ''' <param name="dateValue"></param>
    ''' <remarks></remarks>
    Private Sub UpdateDateText(ByVal dateValue As Nullable(Of DateTime))

      RemoveHandler dateMaskedTextBox.TextChanged, AddressOf Me.dateMaskedTextBox_TextChanged

      If dateValue.HasValue = False Then
        dateMaskedTextBox.Clear()
      Else
        dateMaskedTextBox.Text = dateValue.Value.ToString("MM/dd/yy")
      End If

      AddHandler dateMaskedTextBox.TextChanged, AddressOf Me.dateMaskedTextBox_TextChanged

    End Sub


    ''' <summary>
    ''' Clears date from control and sets Value as Nothing.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Clear()

      dateMaskedTextBox.Clear()
      m_dateValue = Nothing

    End Sub

    ''' <summary>
    ''' Selects all text in the TypeInDatePicker.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SelectAll()

      dateMaskedTextBox.SelectAll()

    End Sub

    Protected Overrides Sub OnTextChanged(ByVal eventArgs As System.EventArgs)

      UpdateDateValue(dateMaskedTextBox.Text)

    End Sub

    Protected Overridable Sub OnValueChanged(ByVal eventArgs As System.EventArgs)

      UpdateDateText(Me.Value)

    End Sub


    Private Sub DTPicker_CloseUp(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPicker.CloseUp

      Me.Value = Me.DTPicker.Value
      dateMaskedTextBox.Focus()

    End Sub

    Private Sub DTPicker_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPicker.DropDown, DTPicker.Enter

      If Me.Value.HasValue Then
                Me.DTPicker.Value = Me.Value.Value
      Else
        Me.DTPicker.Value = System.DateTime.Today
      End If

        End Sub

        Private Sub dateMaskedTextBox_GotFocus(sender As Object, e As EventArgs) Handles dateMaskedTextBox.GotFocus
            dateMaskedTextBox.SelectAll()
        End Sub

    Private Sub dateMaskedTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dateMaskedTextBox.KeyPress
      Dim cursorPos As Integer
      Dim datePartString As String
      Dim dateString As System.Text.StringBuilder


      dateString = New System.Text.StringBuilder

      dateString.Append(dateMaskedTextBox.Text)

      If e.KeyChar = "/"c Then
        If dateMaskedTextBox.SelectionStart < 2 Then
          cursorPos = 3
          datePartString = CType(dateMaskedTextBox.Text.Substring(0, 2), Integer).ToString("00")
          dateString.Remove(0, 2)
          dateString.Insert(0, datePartString)

        ElseIf dateMaskedTextBox.SelectionStart > 2 And dateMaskedTextBox.SelectionStart < 5 Then
          cursorPos = 6
          datePartString = CType(dateMaskedTextBox.Text.Substring(3, 2), Integer).ToString("00")
          dateString.Remove(3, 2)
          dateString.Insert(3, datePartString)

        Else
          cursorPos = dateMaskedTextBox.SelectionStart
        End If

        dateMaskedTextBox.Text = dateString.ToString()
        dateMaskedTextBox.SelectionStart = cursorPos
      End If

    End Sub

    Private Sub dateMaskedTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dateMaskedTextBox.KeyDown
            If e.KeyCode = Keys.Tab Then
                dateMaskedTextBox.SelectAll()
            End If

            If e.KeyCode = Keys.F4 AndAlso e.Control = False AndAlso e.Shift = False AndAlso e.Alt = False Then
                DTPicker.Focus()
                SendKeys.Send("%{Down}")
            End If

        End Sub

    Private Sub dateMaskedTextBox_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dateMaskedTextBox.TextChanged

      OnTextChanged(New System.EventArgs)

    End Sub

    Private Sub dateMaskedTextBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles dateMaskedTextBox.Validated
      Dim tempDate As DateTime


      If DateTime.TryParse(dateMaskedTextBox.Text, tempDate) Then
        m_dateValue = tempDate
      Else
        m_dateValue = Nothing
      End If

    End Sub


  End Class


End Namespace