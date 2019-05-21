Public Class DropdownOptionForm

  Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancelButton.Click

    Me.DialogResult = Windows.Forms.DialogResult.Cancel
    Me.Close()

  End Sub

  Private Sub okButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles okButton.Click
    Dim temp As Integer


    If Integer.TryParse(delayComboBox.Text, temp) = False Then
      MessageBox.Show("Please specify appropriate value. Specified value is invalid." _
                      , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
    Else
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
    End If

  End Sub

End Class
