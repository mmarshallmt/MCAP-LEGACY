Namespace UI.Controls


  ''' <summary>
  ''' 
  ''' </summary>
  ''' <remarks>
  ''' Reference URL: http://msdn.microsoft.com/en-us/library/7tas5c80.aspx
  ''' </remarks>
  Class CalendarEditingControl
    Inherits TypeInDatePicker
    Implements IDataGridViewEditingControl



    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer



    Public Sub New()

      MyBase.New()

    End Sub



    Public Property EditingControlRowIndex() As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

      Get
        Return rowIndexNum
      End Get
      Set(ByVal value As Integer)
        rowIndexNum = value
      End Set

    End Property

    Public ReadOnly Property RepositionEditingControlOnValueChange() _
        As Boolean Implements _
        IDataGridViewEditingControl.RepositionEditingControlOnValueChange

      Get
        Return False
      End Get

    End Property

    Public Property EditingControlDataGridView() As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView

      Get
        Return dataGridViewControl
      End Get
      Set(ByVal value As DataGridView)
        dataGridViewControl = value
      End Set

    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged

      Get
        Return valueIsChanged
      End Get
      Set(ByVal value As Boolean)
        valueIsChanged = value
      End Set

    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor

      Get
        Return MyBase.Cursor
      End Get

    End Property

    Public Property EditingControlFormattedValue() As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue

      Get
        If Me.Value.HasValue Then
          Return Me.Value.Value
        Else
          Return DBNull.Value
        End If
      End Get
      Set(ByVal value As Object)
        If value Is Nothing Then
          Me.Value = Nothing
        ElseIf DateTime.TryParse(value.ToString(), Me.Value.Value) = False Then
          Me.Value = Nothing
        End If
      End Set

    End Property



    Public Function GetEditingControlFormattedValue(ByVal context As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

      'Return Me.Value
      If Me.Value.HasValue Then
        Debug.WriteLine("EditingControlFormattedValue returned: " + Me.Value.Value.ToShortDateString())
        Return Me.Value.Value.ToString("MM/dd/yy")
      Else
        Debug.WriteLine("EditingControlFormattedValue returned: DBNull.Value")
        Return DBNull.Value.ToString()
      End If

    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

      Me.Font = dataGridViewCellStyle.Font
      Me.ForeColor = dataGridViewCellStyle.ForeColor
      Me.BackColor = dataGridViewCellStyle.BackColor

    End Sub

    Public Function EditingControlWantsInputKey _
        (ByVal key As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey

      ' Let the DateTimePicker handle the keys listed.
      Select Case key And Keys.KeyCode
        Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
            Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
          Return True

        Case Else
          Return Not dataGridViewWantsInputKey
      End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

      ' No preparation needs to be done.
      If selectAll Then Me.SelectAll()

    End Sub

    Protected Overrides Sub OnTextChanged(ByVal eventargs As EventArgs)

      ' Notify the DataGridView that the contents of the cell have changed.
      If Me.EditingControlDataGridView IsNot Nothing Then
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
      End If

      MyBase.OnTextChanged(eventargs)

    End Sub

    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)

      ' Notify the DataGridView that the contents of the cell have changed.
      valueIsChanged = True
      Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
      MyBase.OnValueChanged(eventargs)

    End Sub


  End Class


End Namespace