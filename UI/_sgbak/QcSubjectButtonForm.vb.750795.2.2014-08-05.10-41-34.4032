
Public Class QcSubjectButtonForm
    'Namespace UI
    ' Private WithEvents m_Processor As Processors.QCVehicleImages
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


    'Public Sub Initialize(ByVal dataSource As System.Data.DataView)

    Public Sub Initialize(ByVal dataToShow As String)

        Me.txtSubject.Text = dataToShow

    End Sub


    Private Sub loadVehicleData()
        'Dim linqQuery As System.Collections.Generic.IEnumerable(Of QCDataSet.vwCircularRow)


        'linqQuery = From r In Processor.Data.vwCircular.Cast(Of QCDataSet.vwCircularRow)() _
        '            Select r _
        '            Where r.VehicleId = VehicleId

        'If linqQuery.Count = 0 Then
        '    MessageBox.Show("Unable to find information about Vehicle " + VehicleId.ToString(), _
        '                    ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    linqQuery = Nothing
        '    Exit Sub
        'End If

        'Dim filterQuery As String
        'Dim datacount As Integer
        'datacount = 0


        'filterQuery = "VehicleId = " + VehicleId.ToString()
        'DataSource.RowFilter = filterQuery
        'filterQuery = Nothing
        'datacount = DataSource.Item

        '    (ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        '    Handles filterTextBox.KeyUp
        '  Dim filterQuery As String


        '  filterQuery = "[Name] Like '*" + filterTextBox.Text.ToUpper() + "*'"
        '  DataSource.RowFilter = filterQuery
        '  filterQuery = Nothing

        '  If filterTextBox.Text.Length = 0 Then
        '    filterComboBox.SelectedIndex = -1
        '    filterComboBox.Text = String.Empty
        '  End If


    End Sub

    Private Sub txtSubject_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles txtSubject.LinkClicked
        System.Diagnostics.Process.Start(e.LinkText)
    End Sub
End Class

