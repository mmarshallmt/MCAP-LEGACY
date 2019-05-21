Namespace UI.Controls


  ''' <summary>
  ''' 
  ''' </summary>
  ''' <remarks>
  ''' Reference URL: http://msdn.microsoft.com/en-us/library/7tas5c80.aspx
  ''' </remarks>
  Public Class CalendarCell
    Inherits DataGridViewTextBoxCell


    Public Sub New()
      ' Use the short date format.
      'Me.Style.Format = "d"
      Me.Style.Format = "MM/dd/yy"
    End Sub


    Public Overrides Sub InitializeEditingControl _
        (ByVal rowIndex As Integer, _
        ByVal initialFormattedValue As Object, _
        ByVal dataGridViewCellStyle As DataGridViewCellStyle)

      ' Set the value of the editing control to the current cell value.
      MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)

      Dim ctl As CalendarEditingControl = CType(DataGridView.EditingControl, CalendarEditingControl)
      ctl.BackColor = dataGridViewCellStyle.BackColor
      ctl.ForeColor = dataGridViewCellStyle.ForeColor
      If Me.Value Is Nothing OrElse Me.Value Is DBNull.Value Then
        ctl.Value = Nothing
      Else
        ctl.Value = CType(Me.Value, DateTime)
      End If

    End Sub

    Public Overrides ReadOnly Property EditType() As Type
      Get
        ' Return the type of the editing contol that CalendarCell uses.
        Return GetType(CalendarEditingControl)
      End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
      Get
        ' Return the type of the value that CalendarCell contains.
        Return GetType(DateTime)
      End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
      Get
        ' Use the current date and time as the default value.
        Return DateTime.Now
      End Get
    End Property

  End Class


End Namespace
