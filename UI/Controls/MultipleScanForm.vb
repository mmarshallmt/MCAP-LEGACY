Namespace UI.Controls

  Public Class MultipleScanForm

    Private Sub MultipleScanForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      Me.DialogResult = Windows.Forms.DialogResult.None
    End Sub

    Private Sub okButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles okButton.Click
      Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancelButton.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

  End Class

End Namespace