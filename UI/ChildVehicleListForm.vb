Public Class ChildVehicleListForm


  Private Const MESSAGETEXT As String = "Parent vehicle {0} is QCed successfully. Child vehicles are listed below along with their status."


  Private m_parentVehicleId As Integer
  Private m_childVehicleList As System.Collections.Generic.Dictionary(Of Integer, String)


  ''' <summary>
  ''' Gets or sets vehicle id to be treated as parent vehicle id.
  ''' </summary>
  ''' <value></value>
  ''' <returns>Parent VehicleId</returns>
  ''' <remarks></remarks>
  Public Property ParentVehicleId() As Integer
    Get
      Return m_parentVehicleId
    End Get
    Set(ByVal value As Integer)
      m_parentVehicleId = value
    End Set
  End Property

  ''' <summary>
  ''' Gets or sets list of child vehicles along with their status text.
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property ChildVehicleList() As System.Collections.Generic.Dictionary(Of Integer, String)
    Get
      Return m_childVehicleList
    End Get
    Set(ByVal value As System.Collections.Generic.Dictionary(Of Integer, String))
      m_childVehicleList = value
    End Set
  End Property


  Public Sub PrepareForm()
    Dim tempLVI As System.Windows.Forms.ListViewItem


    mainTextBox.Text = String.Format(MESSAGETEXT, Me.ParentVehicleId)

    For i As Integer = 0 To ChildVehicleList.Count - 1
      tempLVI = New System.Windows.Forms.ListViewItem()

      tempLVI.Text = Me.ChildVehicleList.Keys(i).ToString()
      tempLVI.SubItems.Add(Me.ChildVehicleList.Values(i).ToString())
      Me.vehicleListView.Items.Add(tempLVI)

      tempLVI = Nothing
    Next

  End Sub


  Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

    Me.Close()

  End Sub


End Class
