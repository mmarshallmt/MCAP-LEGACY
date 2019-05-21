Namespace UI.Controls

  Public Class Wizard

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
      'Hide tabs by trapping the TCM_ADJUSTRECT message 
      If m.Msg = &H1328 AndAlso Not DesignMode Then
        m.Result = CType(1, IntPtr)
      Else
        MyBase.WndProc(m)
      End If
    End Sub

  End Class

End Namespace