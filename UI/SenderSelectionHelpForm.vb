Namespace UI

  Public Class SenderSelectionHelpForm


    Private m_lastMouseClickTimeStamp As DateTime
    Private m_dataSource As System.Data.DataView



    ''' <summary>
    ''' Source of Data that will be used to display values for selection help.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property DataSource() As System.Data.DataView
      Get
        Return m_dataSource
      End Get
      Set(ByVal value As System.Data.DataView)
        m_dataSource = value
      End Set
    End Property


    'Public Property DataSource() As EnvelopeDataSet.SenderDataTable
    '  Get
    '    Return m_dataSource
    '  End Get
    '  Set(ByVal value As EnvelopeDataSet.SenderDataTable)
    '    m_dataSource = value
    '  End Set
    'End Property


    'Private Sub filterTextBox_KeyUp _
    '    (ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    '    Handles filterTextBox.KeyUp
    '  Dim filterQuery As System.Collections.Generic.IEnumerable(Of EnvelopeDataSet.SenderRow)


    '  filterQuery = From sr In Me.DataSource _
    '                Select sr _
    '                Where sr.Name.ToUpper() Like "*" + filterTextBox.Text.ToUpper() + "*"

    '  filterComboBox.DataSource = filterQuery.ToArray()

    '  If filterTextBox.Text.Length = 0 Then
    '    filterComboBox.SelectedIndex = -1
    '    filterComboBox.Text = String.Empty
    '  End If

    '  filterQuery = Nothing

    'End Sub

    Public Sub Initialize(ByVal dataSource As System.Data.DataView, ByVal displayMember As String, ByVal valueMember As String)

      Me.DataSource = dataSource

      Me.filterComboBox.DisplayMember = displayMember
      Me.filterComboBox.ValueMember = valueMember
      Me.filterComboBox.DataSource = Me.DataSource

    End Sub


    Private Sub filterTextBox_KeyUp _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles filterTextBox.KeyUp
      Dim filterQuery As String


      filterQuery = "[Name] Like '*" + filterTextBox.Text.ToUpper() + "*'"
      DataSource.RowFilter = filterQuery
      filterQuery = Nothing

      If filterTextBox.Text.Length = 0 Then
        filterComboBox.SelectedIndex = -1
        filterComboBox.Text = String.Empty
      End If


    End Sub

    Private Sub filterComboBox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles filterComboBox.MouseClick

      If m_lastMouseClickTimeStamp = Nothing OrElse (DateTime.Now - m_lastMouseClickTimeStamp) > TimeSpan.FromMilliseconds(250) Then
        m_lastMouseClickTimeStamp = DateTime.Now
      Else
        filterComboBox_MouseDoubleClick(sender, e)
      End If

    End Sub

    Private Sub filterComboBox_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles filterComboBox.MouseDoubleClick

      If e.Button = Windows.Forms.MouseButtons.Left Then

        If filterComboBox.SelectedValue IsNot Nothing _
            AndAlso filterComboBox.SelectedValue IsNot DBNull.Value _
        Then
          okButton.PerformClick()
        End If
      End If

    End Sub

    Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancelButton.Click

      Me.DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

    Private Sub okButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles okButton.Click

      Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub


  End Class

End Namespace