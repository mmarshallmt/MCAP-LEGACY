Namespace UI.Controls


  ''' <summary>
  ''' 
  ''' </summary>
  ''' <remarks>
  ''' Reference URL: http://msdn.microsoft.com/en-us/library/7tas5c80.aspx
  ''' </remarks>
  Public Class DataGridViewCheckedListBoxEditingControl
    Inherits System.Windows.Forms.CheckedListBox
    Implements System.Windows.Forms.IDataGridViewEditingControl


    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer


    Public Sub New()

      MyBase.New()

      Me.HorizontalScrollbar = True
      Me.Items.Add(System.DayOfWeek.Sunday.ToString(), False)
      Me.Items.Add(System.DayOfWeek.Monday.ToString(), False)
      Me.Items.Add(System.DayOfWeek.Tuesday.ToString(), False)
      Me.Items.Add(System.DayOfWeek.Wednesday.ToString(), False)
      Me.Items.Add(System.DayOfWeek.Thursday.ToString(), False)
      Me.Items.Add(System.DayOfWeek.Friday.ToString(), False)
      Me.Items.Add(System.DayOfWeek.Saturday.ToString(), False)

    End Sub


    Private Function GetWeekDayName(ByVal weekdayIndex As Integer) As String
      Dim weekDay As System.DayOfWeek


      weekDay = CType(weekdayIndex, System.DayOfWeek)

      Return weekDay.ToString()

    End Function

    Private Function GetWeekDayIndex(ByVal weekdayName As String) As Integer
      Dim weekdayIndex As Integer


      Select Case weekdayName.ToUpper()
        Case "SUNDAY"
          weekdayIndex = System.DayOfWeek.Sunday
        Case "MONDAY"
          weekdayIndex = System.DayOfWeek.Monday
        Case "TUESDAY"
          weekdayIndex = System.DayOfWeek.Tuesday
        Case "WEDNESDAY"
          weekdayIndex = System.DayOfWeek.Wednesday
        Case "THURSDAY"
          weekdayIndex = System.DayOfWeek.Thursday
        Case "FRIDAY"
          weekdayIndex = System.DayOfWeek.Friday
        Case "SATURDAY"
          weekdayIndex = System.DayOfWeek.Saturday
        Case Else
          weekdayIndex = -1
      End Select

      Return weekdayIndex
    End Function

    Private Sub SetFormattedValue(ByVal value As String, ByVal ctrl As DataGridViewCheckedListBoxEditingControl)
      Dim weekdayIndex As Integer
      Dim weekdayArray() As String


      For i As Integer = 0 To ctrl.Items.Count
        ctrl.SetItemChecked(i, False)
      Next

      If value Is Nothing OrElse value.Trim().Length = 0 Then Exit Sub

      weekdayArray = value.Split(","c)
      For i As Integer = 0 To weekdayArray.Length - 1
        weekdayIndex = GetWeekDayIndex(weekdayArray(i).Trim())
        If weekdayIndex >= 0 Then ctrl.SetItemChecked(weekdayIndex, True)
      Next

      System.Array.Clear(weekdayArray, 0, weekdayArray.Length)
      weekdayArray = Nothing
    End Sub

    Private Function GetFormattedValue(ByVal ctrl As DataGridViewCheckedListBoxEditingControl) As String
      Dim formattedValue As Integer


      If ctrl.CheckedItems.Count > 0 Then
        For i As Integer = 0 To 6
          If ctrl.GetItemChecked(i) Then formattedValue += CType(System.Math.Pow(2, i), Integer)
        Next
      End If

      Return formattedValue.ToString()
    End Function



#Region " IDataGridViewEditingControl Implementation "


    Public Property EditingControlDataGridView() As System.Windows.Forms.DataGridView _
        Implements System.Windows.Forms.IDataGridViewEditingControl.EditingControlDataGridView
      Get
        Return dataGridViewControl
      End Get
      Set(ByVal value As System.Windows.Forms.DataGridView)
        dataGridViewControl = value
      End Set
    End Property

    Public Property EditingControlFormattedValue() As Object _
        Implements System.Windows.Forms.IDataGridViewEditingControl.EditingControlFormattedValue
      Get
        Return GetFormattedValue(Me)
      End Get
      Set(ByVal value As Object)
        If value Is Nothing OrElse value Is DBNull.Value Then
          SetFormattedValue("", Me)
        Else
          SetFormattedValue(value.ToString(), Me)
        End If
      End Set
    End Property

    Public Property EditingControlRowIndex() As Integer _
        Implements System.Windows.Forms.IDataGridViewEditingControl.EditingControlRowIndex
      Get
        Return rowIndexNum
      End Get
      Set(ByVal value As Integer)
        rowIndexNum = value
      End Set
    End Property

    Public Property EditingControlValueChanged() As Boolean _
        Implements System.Windows.Forms.IDataGridViewEditingControl.EditingControlValueChanged
      Get
        Return valueIsChanged
      End Get
      Set(ByVal value As Boolean)
        valueIsChanged = value
      End Set
    End Property

    Public ReadOnly Property EditingPanelCursor() As System.Windows.Forms.Cursor _
        Implements System.Windows.Forms.IDataGridViewEditingControl.EditingPanelCursor
      Get
        Return MyBase.Cursor
      End Get
    End Property

    Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean _
        Implements System.Windows.Forms.IDataGridViewEditingControl.RepositionEditingControlOnValueChange
      Get
        Return False
      End Get
    End Property


    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As System.Windows.Forms.DataGridViewCellStyle) _
        Implements System.Windows.Forms.IDataGridViewEditingControl.ApplyCellStyleToEditingControl

      Me.Font = dataGridViewCellStyle.Font
      Me.ForeColor = dataGridViewCellStyle.ForeColor
      Me.BackColor = dataGridViewCellStyle.BackColor


      Dim g As System.Drawing.Graphics = Me.CreateGraphics()
      Dim s As System.Drawing.SizeF = g.MeasureString("Wednesday", Me.Font)

      Me.dataGridViewControl.Rows(Me.rowIndexNum).Height = CType(s.Height * 7, Integer)

      g.Dispose()
      g = Nothing
      s = Nothing

    End Sub

    Public Function EditingControlWantsInputKey(ByVal keyData As System.Windows.Forms.Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements System.Windows.Forms.IDataGridViewEditingControl.EditingControlWantsInputKey

      ' Let the control handle the keys listed.
      Select Case keyData And Keys.KeyCode
        Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
            Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
          Return True

        Case Else
          Return Not dataGridViewWantsInputKey
      End Select

    End Function

    Public Function GetEditingControlFormattedValue(ByVal context As System.Windows.Forms.DataGridViewDataErrorContexts) As Object _
        Implements System.Windows.Forms.IDataGridViewEditingControl.GetEditingControlFormattedValue

      Return EditingControlFormattedValue

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
        Implements System.Windows.Forms.IDataGridViewEditingControl.PrepareEditingControlForEdit

      'Nothing to do for selection.

    End Sub


#End Region


    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)

      ' Notify the DataGridView that the contents of the cell have changed.
      If Me.EditingControlDataGridView IsNot Nothing Then
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
      End If

      MyBase.OnTextChanged(e)

    End Sub

    Protected Overrides Sub OnItemCheck(ByVal ice As System.Windows.Forms.ItemCheckEventArgs)

      ' Notify the DataGridView that the contents of the cell have changed.
      valueIsChanged = True
      Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)

      MyBase.OnItemCheck(ice)

    End Sub

    Private Sub DataGridViewCheckedListBoxEditingControl_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Validated

      Me.dataGridViewControl.Rows(Me.rowIndexNum).Height = Me.dataGridViewControl.RowTemplate.Height

    End Sub

  End Class


End Namespace