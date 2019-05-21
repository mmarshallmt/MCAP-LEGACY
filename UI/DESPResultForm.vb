Namespace UI

  Public Class DESPResultForm

    Private resultDataSet As System.Data.DataSet


    Private ReadOnly Property Result() As System.Data.DataSet
      Get
        Return resultDataSet
      End Get
    End Property


    Public Sub ShowResult(ByVal result As System.Data.DataSet)

      resultDataSet = result

      RemoveHandler resultComboBox.SelectedIndexChanged, AddressOf resultComboBox_SelectedIndexChanged

      totalresultsValueLabel.Text = Me.Result.Tables.Count.ToString()

      For i As Integer = 0 To Me.Result.Tables.Count - 1
        resultComboBox.Items.Add("Result " + (i + 1).ToString())
      Next

      AddHandler resultComboBox.SelectedIndexChanged, AddressOf resultComboBox_SelectedIndexChanged

      resultDataGridView.DataSource = Nothing
      resultComboBox.SelectedIndex = 0

        End Sub

        Private Sub resultComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles resultComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

    Private Sub resultComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles resultComboBox.SelectedIndexChanged

      If resultComboBox.SelectedIndex < 0 Then
        resultDataGridView.DataSource = Nothing
        Exit Sub
      End If

      resultDataGridView.DataSource = Me.Result.Tables(resultComboBox.SelectedIndex)

    End Sub


  End Class

End Namespace