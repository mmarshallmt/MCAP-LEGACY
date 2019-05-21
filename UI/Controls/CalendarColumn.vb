Namespace UI.Controls


  ''' <summary>
  ''' 
  ''' </summary>
  ''' <remarks>
  ''' Reference URL: http://msdn.microsoft.com/en-us/library/7tas5c80.aspx
  ''' </remarks>
  Public Class CalendarColumn
    Inherits DataGridViewColumn

    Public Sub New()
      MyBase.New(New CalendarCell())
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
      Get
        Return MyBase.CellTemplate
      End Get
      Set(ByVal value As DataGridViewCell)

        ' Ensure that the cell used for the template is a CalendarCell.
        If (value IsNot Nothing) AndAlso _
            Not value.GetType().IsAssignableFrom(GetType(CalendarCell)) _
        Then
          Throw New InvalidCastException("Must be a CalendarCell")
        End If

        MyBase.CellTemplate = value

      End Set
    End Property

  End Class


End Namespace