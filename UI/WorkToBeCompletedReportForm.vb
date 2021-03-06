﻿Namespace UI

  Public Class WorkToBeCompletedReportForm
    Implements IForm



    Private m_DataSet As WorkToBeCompletedReportDataSet
        Private m_reportFilterCriteria, m_reportTitle, m_condition As String


    Private ReadOnly Property Data() As WorkToBeCompletedReportDataSet
      Get
        Return m_DataSet
      End Get
    End Property

    Private ReadOnly Property ReportTitle() As String
      Get
        Return m_reportTitle
      End Get
    End Property

    Private ReadOnly Property FilterCriteria() As String
      Get
        Return m_reportFilterCriteria
      End Get
    End Property


#Region " IForm Implementation "

    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied
    Public Event InitializingForm() Implements IForm.InitializingForm
    Public Event FormInitialized() Implements IForm.FormInitialized


    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

    End Sub

    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

      RaiseEvent InitializingForm()

      Me.SuspendLayout()

      m_DataSet = New WorkToBeCompletedReportDataSet()

      LoadDataSet()

      locationComboBox.DisplayMember = "Descrip"
      locationComboBox.ValueMember = "CodeId"
      locationComboBox.DataSource = Me.Data.vwLocation
      If User.LocationId = 58 Then
        locationComboBox.SelectedValue = 0
      Else
        locationComboBox.SelectedValue = User.LocationId
      End If

      priorityComboBox.DisplayMember = "PriorityText"
      priorityComboBox.ValueMember = "Priority"
      priorityComboBox.DataSource = Me.Data.vwPriority
            priorityComboBox.SelectedValue = DBNull.Value

            TradeclassComboBox.DisplayMember = "Descrip"
            TradeclassComboBox.ValueMember = "tradeClassId"
            TradeclassComboBox.DataSource = Me.Data.TradeClass
            TradeclassComboBox.SelectedValue = 0

            CoverageComboBox.DisplayMember = "Descrip"
            CoverageComboBox.ValueMember = "codeid"
            CoverageComboBox.DataSource = Me.Data.Coverage
            CoverageComboBox.SelectedValue = 0

      startdateTypeInDatePicker.Value = System.DateTime.Today.AddMonths(-1)
      enddateTypeInDatePicker.Value = System.DateTime.Today
      priorityGroupBox.Visible = False

      Me.ResumeLayout()

      RaiseEvent FormInitialized()

    End Sub

#End Region

        Private Sub LoadDataSet()
            Dim tempAdapter As WorkToBeCompletedReportDataSetTableAdapters.vwLocationTableAdapter
            Dim tempRow As WorkToBeCompletedReportDataSet.vwLocationRow


            tempAdapter = New WorkToBeCompletedReportDataSetTableAdapters.vwLocationTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(Data.vwLocation)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            tempRow = Data.vwLocation.NewvwLocationRow()
            tempRow.CodeId = 0
            tempRow.Descrip = "All"
            Data.vwLocation.AddvwLocationRow(tempRow)
            tempRow = Nothing


            Dim priorityAdapter As WorkToBeCompletedReportDataSetTableAdapters.vwPriorityTableAdapter
            Dim priorityRow As WorkToBeCompletedReportDataSet.vwPriorityRow

            priorityAdapter = New WorkToBeCompletedReportDataSetTableAdapters.vwPriorityTableAdapter
            priorityAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            priorityAdapter.Fill(Data.vwPriority)
            priorityAdapter.Dispose()
            priorityAdapter = Nothing

            priorityRow = Data.vwPriority.NewvwPriorityRow()
            priorityRow.SetPriorityNull()
            priorityRow.PriorityText = "All"
            Data.vwPriority.AddvwPriorityRow(priorityRow)
            Data.vwPriority.AcceptChanges()
            priorityRow = Nothing


            Dim TradeClassAdapter As WorkToBeCompletedReportDataSetTableAdapters.TradeClassTableAdapter
            Dim TradeClassRow As WorkToBeCompletedReportDataSet.TradeClassRow

            TradeClassAdapter = New WorkToBeCompletedReportDataSetTableAdapters.TradeClassTableAdapter
            TradeClassAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            TradeClassAdapter.Fill(Data.TradeClass)
            TradeClassAdapter.Dispose()
            TradeClassAdapter = Nothing

            TradeClassRow = Data.TradeClass.NewTradeClassRow
            TradeClassRow.tradeclassid = 0
            TradeClassRow.descrip = "All"
            Data.TradeClass.AddTradeClassRow(TradeClassRow)
            TradeClassRow = Nothing


            Dim CoverageAdapter As WorkToBeCompletedReportDataSetTableAdapters.CoverageTableAdapter
            Dim CoverageRow As WorkToBeCompletedReportDataSet.CoverageRow

            CoverageAdapter = New WorkToBeCompletedReportDataSetTableAdapters.CoverageTableAdapter
            CoverageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            CoverageAdapter.Fill(Data.Coverage)
            CoverageAdapter.Dispose()
            CoverageAdapter = Nothing

            CoverageRow = Data.Coverage.NewCoverageRow
            CoverageRow.CodeId = 0
            CoverageRow.descrip = "All"
            Data.Coverage.AddCoverageRow(CoverageRow)
            CoverageRow = Nothing
           
        End Sub

    Private Function AreInputsValid() As Boolean
      Dim validatedSuccessfully As Boolean = True


      If startdateTypeInDatePicker.Value.HasValue = False Then
        SetErrorProvider(startdateTypeInDatePicker, "Provide valid start date.")
        validatedSuccessfully = False
      Else
        RemoveErrorProvider(startdateTypeInDatePicker)
      End If

      If enddateTypeInDatePicker.Value.HasValue = False Then
        SetErrorProvider(enddateTypeInDatePicker, "Provide valid end date.")
        validatedSuccessfully = False
      Else
        RemoveErrorProvider(enddateTypeInDatePicker)
      End If

      If locationComboBox.SelectedValue Is Nothing Then
        SetErrorProvider(locationComboBox, "Select location from drop down list.")
        validatedSuccessfully = False
      Else
        RemoveErrorProvider(locationComboBox)
      End If

      If priorityComboBox.Visible AndAlso priorityComboBox.SelectedValue Is Nothing Then
        SetErrorProvider(priorityComboBox, "Select priority from drop down list.")
        validatedSuccessfully = False
      Else
        RemoveErrorProvider(priorityComboBox)
      End If

      Return validatedSuccessfully

    End Function

    Private Sub LoadDataForUnprocessedEnvelopes()
      Dim locationId As Integer
      Dim tempAdapter As WorkToBeCompletedReportDataSetTableAdapters.UnprocessedEnvelopeTableAdapter


      If startdateTypeInDatePicker.Value.HasValue = False _
        OrElse enddateTypeInDatePicker.Value.HasValue = False _
        OrElse locationComboBox.SelectedValue Is Nothing _
      Then
        Exit Sub
      ElseIf Integer.TryParse(locationComboBox.SelectedValue.ToString(), locationId) = False Then
        locationId = -1
      End If

      If locationId < 0 Then
        MessageBox.Show("Select location from drop down list.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      tempAdapter = New WorkToBeCompletedReportDataSetTableAdapters.UnprocessedEnvelopeTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      m_reportTitle = "Envelopes with no Vehicles"
      tempAdapter.FillByReceivedDtRangeAndReceivedAt(Data.UnprocessedEnvelope _
                                                     , startdateTypeInDatePicker.Value.Value _
                                                     , enddateTypeInDatePicker.Value.Value _
                                                     , locationId)

      tempAdapter.Dispose()
      tempAdapter = Nothing

    End Sub

    Private Sub SetReportParametersForUnprocessedEnvelopes()
      Dim filterCriteria As System.Text.StringBuilder


      filterCriteria = New System.Text.StringBuilder()

      If startdateTypeInDatePicker.Value.HasValue Then
        filterCriteria.Append("Start date: ")
        filterCriteria.Append(startdateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy"))
      End If

      If enddateTypeInDatePicker.Value.HasValue Then
        If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
        filterCriteria.Append("End date: ")
        filterCriteria.Append(enddateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy"))
      End If

      If locationComboBox.SelectedValue IsNot Nothing Then
        If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
        filterCriteria.Append("Location: ")
        filterCriteria.Append(locationComboBox.Text)
      End If

      m_reportFilterCriteria = filterCriteria.ToString()

      filterCriteria.Remove(0, filterCriteria.Length)
      filterCriteria = Nothing

        End Sub

        Private Sub SetReportParametersForCC()
            Dim filterCriteria As System.Text.StringBuilder


            filterCriteria = New System.Text.StringBuilder()

            'If reportComboBox.SelectedIndex > 1 Then

            If startdateTypeInDatePicker.Value.HasValue Then
                filterCriteria.Append("Start date: ")
                filterCriteria.Append(startdateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy"))
            End If

            If enddateTypeInDatePicker.Value.HasValue Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("End date: ")
                filterCriteria.Append(enddateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy"))
            End If

            If locationComboBox.SelectedValue IsNot Nothing Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Location: ")
                filterCriteria.Append(locationComboBox.Text)
            End If
            'Else
            '    If TaskLogsComboBox.Text <> "" And TaskLogsComboBox.SelectedValue IsNot Nothing Then
            '        filterCriteria.Append("Task Logs ID: ")
            '        filterCriteria.Append(TaskLogsComboBox.Text)
            '    End If
            '    If MissingAdComboBox.Text <> "" And MissingAdComboBox.SelectedValue IsNot Nothing Then
            '        filterCriteria.Append("Missing Ad ID: ")
            '        filterCriteria.Append(MissingAdComboBox.Text)
            '    End If

            '    If StatusComboBox.Text <> "" And StatusComboBox.SelectedValue IsNot Nothing Then
            '        If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
            '        filterCriteria.Append("Status: ")
            '        filterCriteria.Append(StatusComboBox.Text)
            '    End If

            '    If PublicationComboBox.Text <> "" And PublicationComboBox.SelectedValue IsNot Nothing Then
            '        If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
            '        filterCriteria.Append("Publication: ")
            '        filterCriteria.Append(PublicationComboBox.Text)
            '    End If

            '    If SenderComboBox.Text <> "" And SenderComboBox.SelectedValue IsNot Nothing Then
            '        If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
            '        filterCriteria.Append("Sender: ")
            '        filterCriteria.Append(SenderComboBox.Text)
            '    End If
            'End If

            m_reportFilterCriteria = filterCriteria.ToString()

            filterCriteria.Remove(0, filterCriteria.Length)
            filterCriteria = Nothing

        End Sub


        Private Sub LoadDataForStatus()
            Dim tempAdapter As WorkToBeCompletedReportDataSetTableAdapters.vwcodeTableAdapter

            tempAdapter = New WorkToBeCompletedReportDataSetTableAdapters.vwcodeTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            m_reportTitle = "CC Missing Ad Logs"
            tempAdapter.Fill(Data.vwcode)

            tempAdapter.Dispose()
            tempAdapter = Nothing
        End Sub

        Private Sub LoadDataForMissingAdLogs()
            Dim tempAdapter As WorkToBeCompletedReportDataSetTableAdapters.CCMissingAdLogsTableAdapter

            tempAdapter = New WorkToBeCompletedReportDataSetTableAdapters.CCMissingAdLogsTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            m_reportTitle = "Coverage and Collections Missing Ad Logs"
            tempAdapter.Fill(Data.CCMissingAdLogs)

            tempAdapter.Dispose()
            tempAdapter = Nothing
            'MissingAdComboBox.SelectedIndex = -1
        End Sub

        Private Sub LoadDataForMissingAdLogs(ByVal _Condition As String)
            Dim tempAdapter As WorkToBeCompletedReportDataSetTableAdapters.CCMissingAdLogsTableAdapter

            tempAdapter = New WorkToBeCompletedReportDataSetTableAdapters.CCMissingAdLogsTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            m_reportTitle = "Coverage and Collections Missing Ad Logs"
            tempAdapter.FillByWhereClause(Data.CCMissingAdLogs)

            tempAdapter.Dispose()
            tempAdapter = Nothing
            'MissingAdComboBox.SelectedIndex = -1
        End Sub


        Private Sub LoadDataForPublication()
            Dim tempAdapter As WorkToBeCompletedReportDataSetTableAdapters.PublicationTableAdapter

            tempAdapter = New WorkToBeCompletedReportDataSetTableAdapters.PublicationTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            tempAdapter.Fill(Data.Publication)

            tempAdapter.Dispose()
            tempAdapter = Nothing
        End Sub

        Private Sub LoadDataForSender()
            Dim tempAdapter As WorkToBeCompletedReportDataSetTableAdapters.SenderTableAdapter

            tempAdapter = New WorkToBeCompletedReportDataSetTableAdapters.SenderTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            tempAdapter.Fill(Data.Sender)

            tempAdapter.Dispose()
            tempAdapter = Nothing
        End Sub

        'Private Sub LoadDataForTaskLogs()
        '    Dim tempAdapter As WorkToBeCompletedReportDataSetTableAdapters.CCTaskLogsTableAdapter

        '    tempAdapter = New WorkToBeCompletedReportDataSetTableAdapters.CCTaskLogsTableAdapter
        '    tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

        '    m_reportTitle = "Coverage and Collections Task Logs"
        '    'tempAdapter.Fill(Data.CCTaskLogs)

        '    tempAdapter.Dispose()
        '    tempAdapter = Nothing

        'End Sub

        'Private Sub LoadDataForTaskLogs(ByVal _Condition As String)
        '    Dim tempAdapter As WorkToBeCompletedReportDataSetTableAdapters.CCTaskLogsTableAdapter

        '    tempAdapter = New WorkToBeCompletedReportDataSetTableAdapters.CCTaskLogsTableAdapter
        '    tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

        '    m_reportTitle = "Coverage and Collections Task Logs"
        '    'tempAdapter.FillByWhereClause(Data.CCTaskLogs)

        '    tempAdapter.Dispose()
        '    tempAdapter = Nothing

        'End Sub

    Private Sub LoadDataForUnprocessedROPs(ByVal reportId As Integer)
      Dim locationId As Integer
            Dim priority As Integer
            Dim tradeclass As Integer
      Dim startDt, endDt As DateTime
      Dim tempAdapter As WorkToBeCompletedReportDataSetTableAdapters.UnprocessedROPTableAdapter


      If priorityComboBox.SelectedValue Is DBNull.Value Then
        priority = Nothing
      Else
        priority = CType(priorityComboBox.SelectedValue, Integer)
            End If


      If Integer.TryParse(locationComboBox.SelectedValue.ToString(), locationId) = False Then
        locationId = -1
      End If

      startDt = startdateTypeInDatePicker.Value.Value
      'This is done to overcome DateTime comparision issue due to the Time part in DateTime data type. 
      '01/01/01' is less than '01/01/01 12:00:01 AM'. So, between operator always ignore time stamps
      'having date same as end date due to that time part in DateTime datatype.
      endDt = enddateTypeInDatePicker.Value.Value.AddDays(1)

      tempAdapter = New WorkToBeCompletedReportDataSetTableAdapters.UnprocessedROPTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            If reportId = 6 Then
                m_reportTitle = "Newspapers Waiting for Pulling"
                If locationId = 0 Then
                    tempAdapter.FillWaitingForPullingFromAllLocations(Data.UnprocessedROP, priority.ToString, startDt, endDt)
                Else
                    tempAdapter.FillWaitingForPulling(Data.UnprocessedROP, priority.ToString, locationId, startDt, endDt)
                End If
            ElseIf reportId = 7 Then
                m_reportTitle = "Newspapers Waiting for Scanning"
                If locationId = 0 Then
                    tempAdapter.FillWaitingForScanningFromAllLocations(Data.UnprocessedROP, priority.ToString, startDt, endDt)
                Else
                    tempAdapter.FillWaitingForScanning(Data.UnprocessedROP, priority.ToString, locationId, startDt, endDt)
                End If
            ElseIf reportId = 8 Then
                m_reportTitle = "Newspapers Waiting for Scanning - No Ads"
                If locationId = 0 Then
                    tempAdapter.FillByWaitingForScanFromAllLocNoAds(Data.UnprocessedROP, priority.ToString, startDt, endDt)
                Else
                    tempAdapter.FillByWaitingForScanNoAds(Data.UnprocessedROP, priority.ToString, locationId, startDt, endDt)
                End If
            ElseIf reportId = 9 Then
                m_reportTitle = "Newspapers Wating for Indexing"
                If locationId = 0 Then
                    tempAdapter.FillWaitingForIndexingFromAllLocations(Data.UnprocessedROP, priority.ToString, startDt, endDt)
                Else
                    tempAdapter.FillWaitingForIndexing(Data.UnprocessedROP, priority.ToString, locationId, startDt, endDt)
                End If

            ElseIf reportId = 10 Then
                m_reportTitle = "Newspapers Indexing in Progress"
                If locationId = 0 Then
                    tempAdapter.FillIndexingInProgressFromAllLocations(Data.UnprocessedROP, priority.ToString, startDt, endDt)
                Else
                    tempAdapter.FillIndexingInProgress(Data.UnprocessedROP, priority.ToString, locationId, startDt, endDt)
                End If
            ElseIf reportId = 11 Then
                m_reportTitle = "Newspapers Waiting for QC"
                If locationId = 0 Then
                    tempAdapter.FillWaitingForQCFromAllLocations(Data.UnprocessedROP, priority.ToString, startDt, endDt)
                Else
                    tempAdapter.FillWaitingForQC(Data.UnprocessedROP, priority.ToString, locationId, startDt, endDt)
                End If
            End If

      tempAdapter.Dispose()
      tempAdapter = Nothing

    End Sub

    Private Sub SetReportParametersForUnprocessedROPs(ByVal vehicleStatusId As Integer)
      Dim filterCriteria As System.Text.StringBuilder


      filterCriteria = New System.Text.StringBuilder()

      If startdateTypeInDatePicker.Value.HasValue Then
        If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
        filterCriteria.Append("Start date: ")
        filterCriteria.Append(startdateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy"))
      End If

      If enddateTypeInDatePicker.Value.HasValue Then
        If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
        filterCriteria.Append("End date: ")
        filterCriteria.Append(enddateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy"))
      End If

      If locationComboBox.SelectedValue IsNot Nothing Then
        If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
        filterCriteria.Append("Location: ")
        filterCriteria.Append(locationComboBox.Text)
      End If

      If priorityComboBox.Visible AndAlso priorityComboBox.SelectedValue IsNot Nothing Then
        If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
        filterCriteria.Append("Priority: ")
        filterCriteria.Append(priorityComboBox.Text)
      End If

      m_reportFilterCriteria = filterCriteria.ToString()

      filterCriteria.Remove(0, filterCriteria.Length)
      filterCriteria = Nothing

    End Sub

    Private Sub LoadDataForUnprocessedVehicles(ByVal reportId As Integer)
      Dim locationId As Integer
            Dim priority As Integer
            Dim tradeclass, CoverageId As Integer
      Dim startDt, endDt As DateTime
      Dim tempAdapter As WorkToBeCompletedReportDataSetTableAdapters.UnprocessedVehicleTableAdapter


      If priorityComboBox.SelectedValue Is DBNull.Value Then
        priority = Nothing
      Else
        priority = CType(priorityComboBox.SelectedValue, Integer)
      End If

      If Integer.TryParse(locationComboBox.SelectedValue.ToString(), locationId) = False Then
        locationId = -1
            End If

            If Integer.TryParse(CoverageComboBox.SelectedValue.ToString(), CoverageId) = False Then
                CoverageId = -1
            End If

            If TradeclassComboBox.SelectedValue Is DBNull.Value Then
                tradeclass = Nothing
            Else
                tradeclass = CType(TradeclassComboBox.SelectedValue, Integer)
            End If

            startDt = startdateTypeInDatePicker.Value.Value
      'This is done to overcome DateTime comparision issue due to the Time part in DateTime data type. 
      '01/01/01' is less than '01/01/01 12:00:01 AM'. So, between operator always ignore time stamps
      'having date same as end date due to that time part in DateTime datatype.
      endDt = enddateTypeInDatePicker.Value.Value.AddDays(1)

      tempAdapter = New WorkToBeCompletedReportDataSetTableAdapters.UnprocessedVehicleTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            If reportId = 1 Then
                m_reportTitle = "Vehicles Waiting for Indexing"
                If locationId = 0 Then
                    tempAdapter.FillForNotIndexedByCreateDtRange(Data.UnprocessedVehicle, startDt, endDt, tradeclass)
                Else
                    tempAdapter.FillForNotIndexedByCreateDtRangeAndLocation(Data.UnprocessedVehicle, startDt, endDt, locationId, tradeclass.ToString)
                End If
            ElseIf reportId = 2 Then
                m_reportTitle = "Vehicles Waiting for Scanning"
                If locationId = 0 Then
                    tempAdapter.FillForNotScannedByCreateDtRange(Data.UnprocessedVehicle, startDt, endDt, priority.ToString, tradeclass.ToString)
                Else
                    tempAdapter.FillForNotScannedByCreateDtRangeAndLocation(Data.UnprocessedVehicle, startDt, endDt, locationId, priority.ToString, tradeclass.ToString)
                End If
            ElseIf reportId = 3 Then
                m_reportTitle = "Vehicles Waiting for QC"
                If locationId = 0 Then
                    tempAdapter.FillForNotQCedByCreateDtRange(Data.UnprocessedVehicle, tradeclass, startDt, endDt, CoverageId.ToString)
                Else
                    tempAdapter.FillForNotQCedByCreateDtRangeAndLocation(Data.UnprocessedVehicle, startDt, endDt, locationId, tradeclass.ToString, CoverageId.ToString)
                End If
            ElseIf reportId = 4 Then
                m_reportTitle = "Vehicles Waiting for SP Review"
                If locationId = 0 Then
                    tempAdapter.FillForNotSPReviewedByCreateDtRange(Data.UnprocessedVehicle, startDt, endDt, priority.ToString)
                Else
                    tempAdapter.FillForNotSPReviewedByCreateDtRangeAndLocation(Data.UnprocessedVehicle, startDt, endDt, locationId, priority.ToString)
                End If

            ElseIf reportId = 5 Then
                m_reportTitle = "Vehicles Waiting for SIMR"
                If locationId = 0 Then
                    tempAdapter.FillForWaitingOnSimrDateRange(Data.UnprocessedVehicle, tradeclass, startDt, endDt)
                Else
                    tempAdapter.FillForWaitingOnSimrDateRangeAndLocation(Data.UnprocessedVehicle, tradeclass, startDt, endDt, locationId)
                End If
            End If

      tempAdapter.Dispose()
      tempAdapter = Nothing

    End Sub

    Private Sub SetReportParametersForUnprocessedVehicles(ByVal vehicleStatusId As Integer)
      Dim filterCriteria As System.Text.StringBuilder


      filterCriteria = New System.Text.StringBuilder()

      If startdateTypeInDatePicker.Value.HasValue Then
        If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
        filterCriteria.Append("Start date: ")
        filterCriteria.Append(startdateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy"))
      End If

      If enddateTypeInDatePicker.Value.HasValue Then
        If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
        filterCriteria.Append("End date: ")
        filterCriteria.Append(enddateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy"))
      End If

      If locationComboBox.SelectedValue IsNot Nothing Then
        If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
        filterCriteria.Append("Location: ")
        filterCriteria.Append(locationComboBox.Text)
      End If

            If TradeclassComboBox.SelectedValue IsNot Nothing Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Tradeclass: ")
                filterCriteria.Append(TradeclassComboBox.Text)
            End If

      If priorityComboBox.Visible AndAlso priorityComboBox.SelectedValue IsNot Nothing Then
        If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
        filterCriteria.Append("Priority: ")
        filterCriteria.Append(priorityComboBox.Text)
      End If

      m_reportFilterCriteria = filterCriteria.ToString()

      filterCriteria.Remove(0, filterCriteria.Length)
      filterCriteria = Nothing

    End Sub

        Private Sub SetReportParametersForUnprocessedFaMILYReview(ByVal vehicleStatusId As Integer)
            Dim filterCriteria As System.Text.StringBuilder


            filterCriteria = New System.Text.StringBuilder()

            If startdateTypeInDatePicker.Value.HasValue Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Start date: ")
                filterCriteria.Append(startdateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy"))
            End If

            If enddateTypeInDatePicker.Value.HasValue Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("End date: ")
                filterCriteria.Append(enddateTypeInDatePicker.Value.Value.ToString("MM/dd/yyyy"))
            End If

            If locationComboBox.SelectedValue IsNot Nothing Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Location: ")
                filterCriteria.Append(locationComboBox.Text)
            End If

            If priorityComboBox.Visible AndAlso priorityComboBox.SelectedValue IsNot Nothing Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Priority: ")
                filterCriteria.Append(priorityComboBox.Text)
            End If

            m_reportFilterCriteria = filterCriteria.ToString()

            filterCriteria.Remove(0, filterCriteria.Length)
            filterCriteria = Nothing

        End Sub

        Private Sub LoadDataForUnprocessedFamilyReview(ByVal reportId As Integer)
            Dim locationId As Integer
            Dim priority As Integer
            Dim startDt, endDt As DateTime
            Dim tempAdapter As WorkToBeCompletedReportDataSetTableAdapters.UnprocessedFamilyReviewTableAdapter

            If Integer.TryParse(locationComboBox.SelectedValue.ToString(), locationId) = False Then
                locationId = -1
            End If

            startDt = startdateTypeInDatePicker.Value.Value
            'This is done to overcome DateTime comparision issue due to the Time part in DateTime data type. 
            '01/01/01' is less than '01/01/01 12:00:01 AM'. So, between operator always ignore time stamps
            'having date same as end date due to that time part in DateTime datatype.
            endDt = enddateTypeInDatePicker.Value.Value.AddDays(1)

            tempAdapter = New WorkToBeCompletedReportDataSetTableAdapters.UnprocessedFamilyReviewTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            SetAllCommandTimeouts(tempAdapter, 60000)
            If reportId = 12 Then
                m_reportTitle = " Family Review  Waiting for Routing "
                If locationId = 0 Then
                    tempAdapter.FillByFamilyReviewByLocation(Data.UnprocessedFamilyReview, startDt, endDt)
                Else
                    tempAdapter.FillByWaitingForRouting(Data.UnprocessedFamilyReview, locationId, startDt, endDt)
                End If
            ElseIf reportId = 13 Then
                m_reportTitle = "Family Review Type and Distribution"
                If locationId = 0 Then
                    tempAdapter.FillByFamilyReviewTypeDistLocation(Data.UnprocessedFamilyReview, startDt, endDt)
                Else
                    tempAdapter.FillByFmilyReviewTypeDist(Data.UnprocessedFamilyReview, locationId, startDt, endDt)
                End If
            ElseIf reportId = 14 Then
                m_reportTitle = "Family Review – Not Locked"
                If locationId = 0 Then
                    tempAdapter.FillByFamilyReviewLockedLocation(Data.UnprocessedFamilyReview, startDt, endDt)
                Else
                    tempAdapter.FillByFamilyReviewLocked(Data.UnprocessedFamilyReview, locationId, startDt, endDt)
                End If

            End If

            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub
    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

      Me.Close()

        End Sub

        Private Sub reportComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles reportComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

    Private Sub reportComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles reportComboBox.SelectedIndexChanged

            'CCParameterGroupBox.Visible = (reportComboBox.SelectedIndex < 2)
            'If reportComboBox.SelectedIndex < 2 Then
            '    'status data
            '    LoadDataForStatus()
            '    StatusComboBox.DisplayMember = "codedescrip"
            '    StatusComboBox.ValueMember = "codeid"
            '    StatusComboBox.DataSource = Data.vwcode
            '    StatusComboBox.SelectedIndex = -1

            '    'Missing Ad
            '    LoadDataForMissingAdLogs()
            '    MissingAdComboBox.DisplayMember = "MissingAdId"
            '    MissingAdComboBox.ValueMember = "MissingAdId"
            '    MissingAdComboBox.DataSource = Data.CCMissingAdLogs
            '    MissingAdComboBox.SelectedIndex = -1

            '    'Publication
            '    LoadDataForPublication()
            '    PublicationComboBox.DisplayMember = "Descrip"
            '    PublicationComboBox.ValueMember = "PublicationId"
            '    PublicationComboBox.DataSource = Data.Publication
            '    PublicationComboBox.SelectedIndex = -1

            '    'Sender
            '    LoadDataForSender()
            '    SenderComboBox.DisplayMember = "Name"
            '    SenderComboBox.ValueMember = "SenderId"
            '    SenderComboBox.DataSource = Data.Sender
            '    SenderComboBox.SelectedIndex = -1

            '    'Task ID
            '    LoadDataForTaskLogs()
            '    TaskLogsComboBox.DisplayMember = "CCtaskLogsId"
            '    TaskLogsComboBox.ValueMember = "CCtaskLogsId"
            '    TaskLogsComboBox.DataSource = Data.CCTaskLogs
            '    TaskLogsComboBox.SelectedIndex = -1

            'If reportComboBox.SelectedIndex = 0 Then
            '    MissingAdComboBox.Visible = True
            '    TaskLogsComboBox.Visible = False
            '    IdLabel.Text = "Missing Ad:"
            'ElseIf reportComboBox.SelectedIndex = 1 Then
            '    MissingAdComboBox.Visible = False
            '    TaskLogsComboBox.Visible = True
            '    IdLabel.Text = "Task Log:"
            'End If

            'End If
            'If reportComboBox.SelectedIndex > 1 Then
            '    PublicationComboBox.DataSource = Nothing
            '    MissingAdComboBox.SelectedIndex = -1
            'End If
            'priorityGroupBox.Visible = (reportComboBox.SelectedIndex > 2)
            If reportComboBox.SelectedIndex = 3 Then
                CoverageGroupBox.Visible = True
            Else
                CoverageGroupBox.Visible = False
            End If

        End Sub


    Private Sub generateReportButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles generateReportButton.Click
            Dim reportForm As ShowReportForm
            Dim strCondition As System.Text.StringBuilder
            Dim PreviousVal As Integer

            strCondition = New System.Text.StringBuilder

            If reportComboBox.Text = "" Then
                MessageBox.Show("Please select the report that you want to generate.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            'If reportComboBox.SelectedIndex < 2 Then
            '    'If reportComboBox.SelectedIndex = 0 Then
            '    If MissingAdComboBox.SelectedIndex >= 0 And MissingAdComboBox.Text <> "" Then
            '        strCondition.Append("a.MissingAdId=" + MissingAdComboBox.Text)
            '        PreviousVal = CInt(MissingAdComboBox.Text)
            '    End If
            '    If TaskLogsComboBox.SelectedIndex >= 0 And TaskLogsComboBox.Text <> "" Then
            '        strCondition.Append("a.CCTaskLogsId=" + TaskLogsComboBox.Text)
            '        PreviousVal = CInt(TaskLogsComboBox.Text)
            '    End If
            '    If StatusComboBox.SelectedIndex >= 0 Then
            '        If strCondition.Length > 0 Then strCondition.Append(" AND ")
            '        strCondition.Append("a.Status=" + StatusComboBox.SelectedValue.ToString)
            '    End If
            '    If PublicationComboBox.SelectedIndex >= 0 Then
            '        If strCondition.Length > 0 Then strCondition.Append(" AND ")
            '        strCondition.Append("a.PublicationId=" + PublicationComboBox.SelectedValue.ToString)
            '    End If
            '    If SenderComboBox.SelectedIndex >= 0 Then
            '        If strCondition.Length > 0 Then strCondition.Append(" AND ")
            '        strCondition.Append("a.SenderId=" + SenderComboBox.SelectedValue.ToString)
            '    End If
            'End If

            m_Condition = strCondition.ToString
            If AreInputsValid() = False Then Exit Sub

            reportForm = New ShowReportForm()

            'If reportComboBox.SelectedIndex = 0 Then
            '    SetReportParametersForCC()
            '    If m_Condition <> "" Then
            '        LoadDataForMissingAdLogs(m_Condition)
            '    Else
            '        LoadDataForMissingAdLogs()
            '    End If
            '    MissingAdComboBox.SelectedIndex = -1
            '    reportForm.ReportFileResourceName = "MCAP.CCMissingAdLogs.rdlc"
            '    reportForm.DataSources.Add("WorkToBeCompletedReportDataSet_CCMissingAdLogs", Data.CCMissingAdLogs)
            '    reportForm.ReportName = "Missing Ad Logs"
            'ElseIf reportComboBox.SelectedIndex = 1 Then
            '    SetReportParametersForCC()
            '    If m_Condition <> "" Then
            '        LoadDataForTaskLogs(m_Condition)
            '    Else
            '        LoadDataForTaskLogs()
            '    End If
            '    TaskLogsComboBox.SelectedIndex = -1
            '    reportForm.ReportFileResourceName = "MCAP.CCTaskLogs.rdlc"
            '    reportForm.DataSources.Add("WorkToBeCompletedReportDataSet_CCTaskLogs", Data.CCTaskLogs)
            '    reportForm.ReportName = "Task Logs"
            If reportComboBox.SelectedIndex = 0 Then
                LoadDataForUnprocessedEnvelopes()
                'SetReportParametersForCC()
                SetReportParametersForUnprocessedEnvelopes()
                reportForm.ReportFileResourceName = "MCAP.UnprocessedEnvelopeReport.rdlc"
                reportForm.DataSources.Add("WorkToBeCompletedReportDataSet_UnprocessedEnvelope", Data.UnprocessedEnvelope)
                reportForm.ReportName = "Unprocessed Envelope"

            ElseIf reportComboBox.SelectedIndex > 0 AndAlso reportComboBox.SelectedIndex < 6 Then
                Me.Data.UnprocessedVehicle.Rows.Clear()
                LoadDataForUnprocessedVehicles(reportComboBox.SelectedIndex)
                SetReportParametersForUnprocessedVehicles(reportComboBox.SelectedIndex)
                reportForm.ReportFileResourceName = "MCAP.UnprocessedVehicleReport.rdlc"
                reportForm.DataSources.Add("WorkToBeCompletedReportDataSet_UnprocessedVehicle", Data.UnprocessedVehicle)
                reportForm.ReportName = "Unprocessed Vehicles"

            ElseIf reportComboBox.SelectedIndex > 5 AndAlso reportComboBox.SelectedIndex < 12 Then
                LoadDataForUnprocessedROPs(reportComboBox.SelectedIndex)
                SetReportParametersForUnprocessedROPs(reportComboBox.SelectedIndex)
                reportForm.ReportFileResourceName = "MCAP.UnprocessedROPReport.rdlc"
                reportForm.DataSources.Add("WorkToBeCompletedReportDataSet_UnprocessedROP", Data.UnprocessedROP)
                reportForm.ReportName = "Unprocessed ROPs"

            ElseIf reportComboBox.SelectedIndex > 11 AndAlso reportComboBox.SelectedIndex < 15 Then
                LoadDataForUnprocessedFamilyReview(reportComboBox.SelectedIndex)
                SetReportParametersForUnprocessedFaMILYReview(reportComboBox.SelectedIndex)
                reportForm.ReportFileResourceName = "MCAP.UnProcessFamilyReviewReport.rdlc"
                reportForm.DataSources.Add("WorkToBeCompletedReportDataSet_UnprocessedFamilyReview", Data.UnprocessedFamilyReview)
                reportForm.ReportName = "Unprocessed Family Review"

                'ElseIf reportComboBox.SelectedIndex >= 14 Then
                '    Me.Data.UnprocessedVehicle.Rows.Clear()
                '    LoadDataForUnprocessedVehicles(reportComboBox.SelectedIndex)
                '    SetReportParametersForUnprocessedVehicles(reportComboBox.SelectedIndex)
                '    reportForm.ReportFileResourceName = "MCAP.UnprocessedVehicleSimrReport.rdlc"
                '    reportForm.DataSources.Add("WorkToBeCompletedReportDataSet_UnprocessedVehicle", Data.UnprocessedVehicle)
                '    reportForm.ReportName = "Vehicles waiting for SIMR"
            End If

            reportForm.Parameters.Add("ReportTitle", ReportTitle)
            reportForm.Parameters.Add("FilterCriteria", FilterCriteria)

            If reportComboBox.SelectedIndex = 1 Then
                reportForm.Parameters.Add("DtColumnHeader", "# Days Since Check-In")
                reportForm.Parameters.Add("DtIndColumnHeader", "# Days Since Images Scanned")
                reportForm.Parameters.Add("ShowEnvDaysColumn", "True")
                reportForm.Parameters.Add("ShowSender", "True")
            ElseIf reportComboBox.SelectedIndex = 2 Then
                reportForm.Parameters.Add("DtColumnHeader", "# Days Since Indexed")
                reportForm.Parameters.Add("ShowEnvDaysColumn", "False")
                reportForm.Parameters.Add("ShowSender", "False")
            ElseIf reportComboBox.SelectedIndex = 3 Then
                reportForm.Parameters.Add("DtColumnHeader", "# Days Since Images Scanned")
                reportForm.Parameters.Add("ShowEnvDaysColumn", "False")
                reportForm.Parameters.Add("ShowSender", "True")
            ElseIf reportComboBox.SelectedIndex = 4 Then
                reportForm.Parameters.Add("DtColumnHeader", "# Days Since QCed")
                reportForm.Parameters.Add("ShowEnvDaysColumn", "False")
            ElseIf reportComboBox.SelectedIndex = 5 Then
                reportForm.Parameters.Add("DtColumnHeader", "#Days Since Checked In")
                reportForm.Parameters.Add("ShowEnvDaysColumn", "false")
            ElseIf reportComboBox.SelectedIndex = 6 Then
                reportForm.Parameters.Add("DtColumnHeader", "Create Date")
                reportForm.Parameters.Add("DaysColumnHeader", "#Days Since Checked In")
                reportForm.Parameters.Add("CheckedInByColumn", "True")
                reportForm.Parameters.Add("PulledByColumn", "False")
                reportForm.Parameters.Add("IndexedByColumn", "False")
            ElseIf reportComboBox.SelectedIndex = 7 Then
                reportForm.Parameters.Add("DtColumnHeader", "Pull Date")
                reportForm.Parameters.Add("DaysColumnHeader", "#Days Since Pulled")
            ElseIf reportComboBox.SelectedIndex = 8 Then
                reportForm.Parameters.Add("DtColumnHeader", "Pull Date")
                reportForm.Parameters.Add("DaysColumnHeader", "#Days Since Pulled")
            ElseIf reportComboBox.SelectedIndex = 9 Then
                reportForm.Parameters.Add("DtColumnHeader", "Scan Date")
                reportForm.Parameters.Add("DaysColumnHeader", "#Days Since Scanned")
                reportForm.Parameters.Add("CheckedInByColumn", "True")
                reportForm.Parameters.Add("PulledByColumn", "True")
                reportForm.Parameters.Add("IndexedByColumn", "False")
            ElseIf reportComboBox.SelectedIndex = 10 Then
                reportForm.Parameters.Add("DtColumnHeader", "Scan Date")
                reportForm.Parameters.Add("DaysColumnHeader", "#Days Since Scanned")
            ElseIf reportComboBox.SelectedIndex = 11 Then
                reportForm.Parameters.Add("DtColumnHeader", "Index Date")
                reportForm.Parameters.Add("DaysColumnHeader", "#Days Since Indexed")
                reportForm.Parameters.Add("CheckedInByColumn", "True")
                reportForm.Parameters.Add("PulledByColumn", "True")
                reportForm.Parameters.Add("IndexedByColumn", "True")
            ElseIf reportComboBox.SelectedIndex = 12 Then
                reportForm.Parameters.Add("DtColumnHeader", "Routing Date")
                reportForm.Parameters.Add("ShowEnvDaysColumn", "false")
                reportForm.Parameters.Add("ShowImageError", System.IO.Path.GetFullPath("../../Resources/notFound.jpg").ToString())
            ElseIf reportComboBox.SelectedIndex = 13 Then
                reportForm.Parameters.Add("DtColumnHeader", "adType/AdDist")
                reportForm.Parameters.Add("ShowEnvDaysColumn", "false")
                reportForm.Parameters.Add("ShowImageError", System.IO.Path.GetFullPath("../../Resources/notFound.jpg").ToString())
            ElseIf reportComboBox.SelectedIndex = 14 Then
                reportForm.Parameters.Add("DtColumnHeader", "Locked")
                reportForm.Parameters.Add("ShowEnvDaysColumn", "false")
                reportForm.Parameters.Add("ShowImageError", System.IO.Path.GetFullPath("../../Resources/notFound.jpg").ToString())

            End If
            reportForm.PrepareReport()

            If screenRadioButton.Checked Then
                reportForm.RefreshReport()
                reportForm.WindowState = FormWindowState.Maximized
                reportForm.ShowDialog(Me)

            Else
                reportForm.ExportReportToExcel(System.IO.Path.GetTempFileName())
            End If

            reportForm.Dispose()
            reportForm = Nothing
            'If reportComboBox.SelectedIndex = 0 Then
            '    LoadDataForMissingAdLogs()
            '    MissingAdComboBox.DisplayMember = "MissingAdId"
            '    MissingAdComboBox.ValueMember = "MissingAdId"
            '    MissingAdComboBox.SelectedValue = PreviousVal
            'ElseIf reportComboBox.SelectedIndex = 1 Then
            '    LoadDataForTaskLogs()
            '    TaskLogsComboBox.DisplayMember = "CCTaskLogsId"
            '    TaskLogsComboBox.ValueMember = "CCTaskLogsId"
            '    TaskLogsComboBox.SelectedValue = PreviousVal
            'End If


        End Sub

        Private Sub StatusComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub PublicationComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub SenderComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub MissingAdComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

       
       
    End Class

End Namespace