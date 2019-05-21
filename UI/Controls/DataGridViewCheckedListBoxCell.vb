Namespace UI.Controls


  Public Class DataGridViewCheckedListBoxCell
    Inherits DataGridViewTextBoxCell


    Private Sub UncheckAllItems(ByVal ctl As DataGridViewCheckedListBoxEditingControl)

      For i As Integer = 0 To ctl.Items.Count - 1
        ctl.SetItemChecked(i, False)
      Next

    End Sub

    Private Sub CheckItems(ByVal value As Integer, ByVal ctl As DataGridViewCheckedListBoxEditingControl)
      Dim dow As Integer


      UncheckAllItems(ctl)

      For i As Integer = 0 To 6
        dow = CType(System.Math.Pow(2, i), Integer)
        If (dow And value) = dow Then ctl.SetItemChecked(i, True)
      Next

    End Sub


    Public Overrides Sub InitializeEditingControl _
        (ByVal rowIndex As Integer _
         , ByVal initialFormattedValue As Object _
         , ByVal dataGridViewCellStyle As System.Windows.Forms.DataGridViewCellStyle)

      MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)

      Dim ctl As DataGridViewCheckedListBoxEditingControl = CType(DataGridView.EditingControl, DataGridViewCheckedListBoxEditingControl)
      If Me.Value Is Nothing OrElse Me.Value Is DBNull.Value Then
        UncheckAllItems(ctl)
      Else
        CheckItems(CType(Me.Value, Integer), ctl)
      End If

    End Sub


    Public Overrides ReadOnly Property EditType() As System.Type
      Get
        Return GetType(DataGridViewCheckedListBoxEditingControl)
      End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As System.Type
      Get
        Return GetType(Integer)
      End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
      Get
        Return DBNull.Value  'None of the weekdays should be selected.
      End Get
    End Property


  End Class


End Namespace