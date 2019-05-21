Namespace UI

  Public Class ROPStatusReportForm
    Implements IForm


    Protected Overrides Sub ClearAllInputs()

      Me.senderValueLabel.Text = String.Empty
      Me.mediaValueLabel.Text = String.Empty
      Me.marketValueLabel.Text = String.Empty
      Me.publicationValueLabel.Text = String.Empty
      Me.breakDtValueLabel.Text = String.Empty
      Me.vehicleStatusValueLabel.Text = String.Empty
      Me.createdOnValueLabel.Text = String.Empty
      Me.scannedOnValueLabel.Text = String.Empty
      Me.ftpOnValueLabel.Text = String.Empty
      Me.exportStatusValueLabel.Text = String.Empty

    End Sub


#Region " IForm Implementation "


    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied

    Public Event InitializingForm() Implements IForm.InitializingForm
    Public Event FormInitialized() Implements IForm.FormInitialized


    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

    End Sub

    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

      ClearAllInputs()

    End Sub


#End Region


    Private Sub LoadSender(ByVal senderId As Integer)
      Dim senderAdapter As MCAP.StatusReportDataSetTableAdapters.SenderTableAdapter


      senderAdapter = New MCAP.StatusReportDataSetTableAdapters.SenderTableAdapter()
      senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      senderAdapter.Fill(Me.StatusReportDataSet.Sender, senderId)
      senderAdapter.Dispose()
      senderAdapter = Nothing
    End Sub

    Private Sub LoadVehicleInformation(ByVal vehicleId As Integer)
      Dim vehicleAdapter As MCAP.StatusReportDataSetTableAdapters.vwVehicleStatusReportTableAdapter


      vehicleAdapter = New MCAP.StatusReportDataSetTableAdapters.vwVehicleStatusReportTableAdapter()
      vehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      vehicleAdapter.FillByVehicleId(Me.StatusReportDataSet.vwVehicleStatusReport, vehicleId)
      vehicleAdapter.Dispose()
      vehicleAdapter = Nothing
    End Sub

    Private Sub LoadPageInformation(ByVal vehicleId As Integer)
      Dim pageAdapter As MCAP.StatusReportDataSetTableAdapters.PageTableAdapter


      pageAdapter = New MCAP.StatusReportDataSetTableAdapters.PageTableAdapter()
      pageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      pageAdapter.Fill(Me.StatusReportDataSet.Page, vehicleId)
      pageAdapter.Dispose()
      pageAdapter = Nothing
    End Sub

    Private Sub LoadPageCropInformation(ByVal vehicleId As Integer)
      Dim pagecropAdapter As MCAP.StatusReportDataSetTableAdapters.PageCropTableAdapter


      pagecropAdapter = New MCAP.StatusReportDataSetTableAdapters.PageCropTableAdapter()
      pagecropAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      pagecropAdapter.Fill(Me.StatusReportDataSet.PageCrop, vehicleId)
      pagecropAdapter.Dispose()
      pagecropAdapter = Nothing
    End Sub


    Private Sub searchButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchButton.Click
      Dim vehicleId As Integer


      If Integer.TryParse(searchTextBox.Text, vehicleId) = False Then
        MessageBox.Show("Provide valid vehicle Id.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      Me.StatusReportDataSet.PageCrop.Rows.Clear()
      Me.StatusReportDataSet.Page.Rows.Clear()
      Me.StatusReportDataSet.vwVehicleStatusReport.Rows.Clear()
      Me.StatusReportDataSet.Sender.Rows.Clear()

      LoadVehicleInformation(vehicleId)
      If Me.StatusReportDataSet.vwVehicleStatusReport.Count = 0 Then
        MessageBox.Show("Vehicle not found.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If
      LoadPageInformation(vehicleId)
      LoadPageCropInformation(vehicleId)
      If Me.StatusReportDataSet.vwVehicleStatusReport(0).IsSenderIdNull() = False Then
        LoadSender(Me.StatusReportDataSet.vwVehicleStatusReport(0).SenderId)
      End If

    End Sub


  End Class

End Namespace