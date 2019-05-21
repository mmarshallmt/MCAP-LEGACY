Namespace UI

  Public Class SPReviewForm
    Implements IForm


    Private Const FORM_NAME As String = "SP Review"


    Private m_data As MCAP.SPReviewDataSet


#Region " Database related functionalities "


    Private Sub LoadPendingVehiclesOnly(ByVal startDt As System.DateTime, ByVal endDt As System.DateTime)
      Dim tempAdapter As MCAP.SPReviewDataSetTableAdapters.VehicleTableAdapter


      tempAdapter = New MCAP.SPReviewDataSetTableAdapters.VehicleTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      tempAdapter.FillPendingOnly(m_data.Vehicle, startDt, endDt)
      tempAdapter.Dispose()
      tempAdapter = Nothing

    End Sub

    Private Sub LoadVehicles(ByVal startDt As System.DateTime, ByVal endDt As System.DateTime)
      Dim tempAdapter As MCAP.SPReviewDataSetTableAdapters.VehicleTableAdapter


      tempAdapter = New MCAP.SPReviewDataSetTableAdapters.VehicleTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      tempAdapter.FillReviewed(m_data.Vehicle, startDt, endDt)
      tempAdapter.Dispose()
      tempAdapter = Nothing

    End Sub

    Private Sub LoadPagesInformation(ByVal vehicleId As Integer)
      Dim tempAdapter As MCAP.SPReviewDataSetTableAdapters.PageTableAdapter


      tempAdapter = New MCAP.SPReviewDataSetTableAdapters.PageTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      tempAdapter.Fill(m_data.Page, vehicleId)
      tempAdapter.Dispose()
      tempAdapter = Nothing

    End Sub

    Private Sub RefreshGrid()
      Dim statusMsg As MCAP.UI.Controls.StatusMessageForm


      statusMsg = New MCAP.UI.Controls.StatusMessageForm()

      statusMsg.MessageText = "Refreshing information in grid..... Please wait."
      statusMsg.Show(Me)
      statusMsg.Refresh()

      If reviewedCheckBox.Checked Then
        LoadVehicles(fromTypeInDatePicker.Value.Value, toTypeInDatePicker.Value.Value)
      Else
        LoadPendingVehiclesOnly(fromTypeInDatePicker.Value.Value, toTypeInDatePicker.Value.Value)
      End If

      statusMsg.Close()
      statusMsg.Dispose()
      statusMsg = Nothing

    End Sub

    Private Sub UpdateVehicleSPReviewStatus(ByVal vehicleIdArray() As Integer, ByVal isRegular As Boolean)
      Dim vehicleQuery As System.Collections.Generic.IEnumerable(Of MCAP.SPReviewDataSet.VehicleRow)
      Dim tempAdapter As MCAP.SPReviewDataSetTableAdapters.VehicleTableAdapter


      tempAdapter = New MCAP.SPReviewDataSetTableAdapters.VehicleTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      If isRegular Then
        For i As Integer = 0 To vehicleIdArray.Length - 1
          tempAdapter.MarkVehicleAsRegular(FORM_NAME, vehicleIdArray(i))
        Next
      Else
        For i As Integer = 0 To vehicleIdArray.Length - 1
          tempAdapter.MarkVehicleAsSP(FORM_NAME, vehicleIdArray(i))
        Next
      End If

      If reviewedCheckBox.Checked Then
        RefreshGrid()
      Else
        For i As Integer = 0 To vehicleIdArray.Length - 1
          vehicleQuery = From vehicle In m_data.Vehicle _
                         Where vehicle.VehicleId = vehicleIdArray(i) _
                         Select vehicle
          If vehicleQuery.Count() > 0 Then
            vehicleQuery(0).Delete()
          End If
        Next
        m_data.Vehicle.AcceptChanges()
      End If

      tempAdapter.Dispose()
      tempAdapter = Nothing
      vehicleQuery = Nothing

    End Sub


#End Region


#Region " IForm Implementation "


    Public Event InitializingForm() Implements IForm.InitializingForm
    Public Event FormInitialized() Implements IForm.FormInitialized

    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied


    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

    End Sub

    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

      m_data = New MCAP.SPReviewDataSet()

      fromTypeInDatePicker.Value = System.DateTime.Today.AddMonths(-1)
      toTypeInDatePicker.Value = System.DateTime.Today

      reviewDataGridView.DataSource = m_data '.Vehicle

    End Sub


#End Region


    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

      Me.Close()

    End Sub

    Private Sub filterButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles filterButton.Click

      If fromTypeInDatePicker.Value.HasValue = False OrElse toTypeInDatePicker.Value.HasValue = False Then
        MessageBox.Show("Start and End both the dates are required to filter list of vehicles.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      ElseIf fromTypeInDatePicker.Value.Value > toTypeInDatePicker.Value.Value Then
        MessageBox.Show("Provide proper date range to filter list of vehicles.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      If reviewedCheckBox.Checked Then
        LoadVehicles(fromTypeInDatePicker.Value.Value, toTypeInDatePicker.Value.Value.AddDays(1))
      Else
        LoadPendingVehiclesOnly(fromTypeInDatePicker.Value.Value, toTypeInDatePicker.Value.Value.AddDays(1))
      End If

    End Sub

    Private Sub reviewDataGridView_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles reviewDataGridView.CellContentClick
      Dim isThumbnailAvailable As Boolean = True
      Dim vehicleId, columnIndex, selectedRowIndex As Integer
      Dim createDt As DateTime
      Dim imageFolderPath As String
      Dim thumbnailQuery As System.Collections.Generic.IEnumerable(Of String)


      If reviewDataGridView.Columns(e.ColumnIndex).HeaderText <> "Pages" Then Exit Sub

      If e.RowIndex < 0 AndAlso reviewDataGridView.SelectedRows.Count <> 1 Then
        MessageBox.Show("Can show only one Family at a time.", ProductName, _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      ElseIf e.RowIndex < 0 Then
        selectedRowIndex = reviewDataGridView.SelectedRows(0).Index
      Else
        selectedRowIndex = e.RowIndex
      End If

      'selectedRowIndex = reviewDataGridView.SelectedRows(0).Index
      columnIndex = reviewDataGridView.Columns("VehicleIdDataGridViewTextBoxColumn").Index
      vehicleId = CType(reviewDataGridView.Rows(selectedRowIndex).Cells(columnIndex).Value, Integer)
      columnIndex = reviewDataGridView.Columns("CreateDtDataGridViewTextBoxColumn").Index
      createDt = CType(reviewDataGridView.Rows(selectedRowIndex).Cells(columnIndex).Value, DateTime)

      imageFolderPath = VehicleImageFolderPath + "\" + createDt.ToString("yyyyMM") _
                        + "\" + vehicleId.ToString() + "\" + ThumbSizedPageImageFolderName
      If System.IO.Directory.Exists(imageFolderPath) = False Then
        isThumbnailAvailable = False
        imageFolderPath = VehicleImageFolderPath + "\" + createDt.ToString("yyyyMM") _
                          + "\" + vehicleId.ToString() + "\" + UnsizedPageImageFolderName
      End If

      LoadPagesInformation(vehicleId)
      thumbnailQuery = From pageRow In m_data.Page _
                       Select imageFolderPath + "\" + pageRow.ImageName + ".jpg"

      Dim thumbnailForm As UI.Controls.ThumbnailBrowserForm = New UI.Controls.ThumbnailBrowserForm()
      thumbnailForm.LoadThumbnails(thumbnailQuery.ToArray(), isThumbnailAvailable)
      thumbnailForm.Text += " - Vehicle " + vehicleId.ToString()
      Application.DoEvents()
      thumbnailForm.ShowDialog(Me)
      thumbnailForm.Dispose()
      thumbnailForm = Nothing

      thumbnailQuery = Nothing

    End Sub

    Private Sub regularButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles regularButton.Click
      Dim columnIndex As Integer
      Dim vehicleQuery As System.Collections.Generic.IEnumerable(Of Integer)


      If reviewDataGridView.SelectedRows.Count = 0 Then
        MessageBox.Show("Select at least one row to mark vehicle as Regular.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      columnIndex = reviewDataGridView.Columns.IndexOf(VehicleIdDataGridViewTextBoxColumn)
      vehicleQuery = From row In reviewDataGridView.SelectedRows.Cast(Of System.Windows.Forms.DataGridViewRow)() _
                     Select CType(row.Cells(columnIndex).Value, Integer)

      If vehicleQuery.Count = 0 Then
        MessageBox.Show("Can not grab any vehicle from selected rows. Unable to mark selected vehicle(s) as Regular.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      UpdateVehicleSPReviewStatus(vehicleQuery.ToArray(), True)

    End Sub

    Private Sub spButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles spButton.Click
      Dim columnIndex As Integer
      Dim vehicleQuery As System.Collections.Generic.IEnumerable(Of Integer)


      If reviewDataGridView.SelectedRows.Count = 0 Then
        MessageBox.Show("Select at least one row to mark vehicle as SP.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      columnIndex = reviewDataGridView.Columns.IndexOf(VehicleIdDataGridViewTextBoxColumn)
      vehicleQuery = From row In reviewDataGridView.SelectedRows.Cast(Of System.Windows.Forms.DataGridViewRow)() _
                     Select CType(row.Cells(columnIndex).Value, Integer)

      If vehicleQuery.Count = 0 Then
        MessageBox.Show("Can not grab any vehicle from selected rows. Unable to mark selected vehicle(s) as SP.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      UpdateVehicleSPReviewStatus(vehicleQuery.ToArray(), False)

    End Sub


  End Class

End Namespace