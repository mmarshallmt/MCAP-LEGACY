Namespace UI.Controls


  Public Class DataGridViewCheckedListBoxColumn
    Inherits DataGridViewColumn


    Public Sub New()
      MyBase.New(New DataGridViewCheckedListBoxCell())
    End Sub


    Public Overrides Property CellTemplate() As System.Windows.Forms.DataGridViewCell
      Get
        Return MyBase.CellTemplate
      End Get
      Set(ByVal value As System.Windows.Forms.DataGridViewCell)

        ' Ensure that the cell used for the template is a CalendarCell.
        If value IsNot Nothing _
          AndAlso Not value.GetType.IsAssignableFrom(GetType(DataGridViewCheckedListBoxCell)) _
        Then
          Throw New InvalidCastException("Must be CheckedListBoxCell")
        End If

        MyBase.CellTemplate = value

      End Set
    End Property


  End Class


End Namespace