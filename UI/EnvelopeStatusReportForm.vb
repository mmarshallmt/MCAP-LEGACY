﻿Namespace UI

  Public Class EnvelopeStatusReportForm
    Implements IForm



    Protected Overrides Sub ClearAllInputs()
      MyBase.ClearAllInputs()

      searchTextBox.Clear()
      senderNameLabel.Text = String.Empty
      packageAssignedLabel.Text = String.Empty
      receiveDateValueLabel.Text = String.Empty
      receivedByNameLabel.Text = String.Empty

      vehicleDataGridView.DataSource = Nothing

    End Sub


#Region " IForm implementation "


    Public Event InitializingForm() Implements IForm.InitializingForm
    Public Event FormInitialized() Implements IForm.FormInitialized

    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied


    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

    End Sub

    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

      RaiseEvent InitializingForm()

      Me.SuspendLayout()

      Me.FormState = formStatus
      Me.ClearAllInputs()
      Me.ShowHideControls(formStatus)
      Me.EnableDisableControls(formStatus)

      Me.ResumeLayout(False)

      RaiseEvent FormInitialized()

    End Sub


#End Region


    ''' <summary>
    ''' Loads envelope information and list of vehicles created from this envelope.
    ''' </summary>
    ''' <param name="envelopeId"></param>
    ''' <exception cref="System.Data.SqlClient.SqlException">Error has occurred while loading information from SQLServer.</exception>
    ''' <exception cref="Exception">Unknown error has occurred.</exception>
    ''' <remarks></remarks>
    Private Sub LoadEnvelopeInformation(ByVal envelopeId As Integer)
      Dim envelopeAdapter As StatusReportDataSetTableAdapters.vwEnvelopeStatusReportTableAdapter
      Dim vehicleAdapter As StatusReportDataSetTableAdapters.vwVehicleStatusReportTableAdapter


      envelopeAdapter = New StatusReportDataSetTableAdapters.vwEnvelopeStatusReportTableAdapter
      vehicleAdapter = New StatusReportDataSetTableAdapters.vwVehicleStatusReportTableAdapter

      envelopeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      vehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      Try
        envelopeAdapter.Fill(Me.StatusReportDataSet.vwEnvelopeStatusReport, envelopeId)
        vehicleAdapter.Fill(Me.StatusReportDataSet.vwVehicleStatusReport, envelopeId)
      Catch ex As System.Data.SqlClient.SqlException
        Throw
      Catch ex As Exception
        Throw
      Finally
        envelopeAdapter.Dispose()
        vehicleAdapter.Dispose()
        envelopeAdapter = Nothing
        vehicleAdapter = Nothing
      End Try

      If Me.StatusReportDataSet.vwEnvelopeStatusReport.Count > 0 Then
        With Me.StatusReportDataSet.vwEnvelopeStatusReport(0)
          senderNameLabel.Text = .Sender
                    'packageAssignedLabel.Text = .PackageAssignedTo
          receiveDateValueLabel.Text = .ReceivedDt.ToString("MM/dd/yyyy")
          receivedByNameLabel.Text = .ReceivedBy + " At " + .ReceivedAt
        End With
      End If

      vehicleDataGridView.DataSource = Me.StatusReportDataSet.vwVehicleStatusReport

    End Sub

    ''' <summary>
    ''' Loads envelope information.
    ''' </summary>
    ''' <param name="EnvelopeId"></param>
    ''' <remarks></remarks>
    Public Sub LoadEnvelope(ByVal EnvelopeId As Integer)

      searchTextBox.Text = EnvelopeId.ToString()
      searchButton.PerformClick()

    End Sub


    Private Sub searchButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchButton.Click
      Dim envelopeId As Integer


      If Integer.TryParse(searchTextBox.Text, envelopeId) = False Then
        MessageBox.Show("Provide valid Envelope Id.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      Try
        LoadEnvelopeInformation(envelopeId)
      Catch ex As System.Data.SqlClient.SqlException
        Trace.TraceError("EnvelopeStatusReportForm.LoadEnvelopeInformation(): Message=" + ex.Message, New Object() {"EnvelopeId=", envelopeId, "ErrorClass=", ex.Class, "Procedure=", ex.Procedure, "LineNumber=", ex.LineNumber, "SQLErrorNumber=", ex.State, "ErrorNumber=", ex.Number, "Source=", ex.Source})
                MessageBox.Show("Error has occurred while loading envelope information. Unable to load envelope information.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                Trace.TraceError("EnvelopeStatusReportForm.LoadEnvelopeInformation(): Unknown error. Message=" + ex.Message, New Object() {"EnvelopeId=", envelopeId})
                MessageBox.Show("Unknown error has occurred while loading envelope information. Unable to load envelope information.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      If Me.StatusReportDataSet.vwEnvelopeStatusReport.Count = 0 Then
        MessageBox.Show("Envelope " + envelopeId.ToString() + " not found.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End Sub

    Private Sub vehicleDataGridView_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles vehicleDataGridView.CellDoubleClick
      Dim vehicleId As Integer


      If e.RowIndex < 0 Then Exit Sub

      If Integer.TryParse(vehicleDataGridView.Rows(e.RowIndex).Cells("VehicleIdDataGridViewTextBoxColumn").Value.ToString(), vehicleId) = False Then
        MessageBox.Show("Unable to find Vehicle Id from selected row. Cannot load Vehicle status report screen." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If


      Dim vehicleStatusForm As VehicleStatusReportForm

      vehicleStatusForm = New VehicleStatusReportForm()
      vehicleStatusForm.MdiParent = Me.MdiParent
      vehicleStatusForm.Init(FormStateEnum.View)
      vehicleStatusForm.ApplyUserCredentials()
      vehicleStatusForm.Show()
      vehicleStatusForm.ShowVehicleInformation(vehicleId)

      vehicleStatusForm = Nothing

    End Sub


  End Class

End Namespace