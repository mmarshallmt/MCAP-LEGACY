﻿Namespace UI.Processors


  Public Class DupCheck
    Inherits BaseClass


#Region " Events "


    'Events can be extended to supply necessary information to consumer along with events.
    'Information passed into event can be useful to consumer while processing the event.

    Public Event Initializing()
    Public Event Initialized()

    Public Event PreparingAdapter()
    Public Event AdapterPrepared()

    Public Event LoadingEnvelope()
    Public Event EnvelopeLoaded()
    Public Event EnvelopeNotFound()

    Public Event ValidatingInputs()
    Public Event InputsValidated()
    Public Event InvalidInputExist()

    Public Event InsertingEnvelope()
    Public Event EnvelopeInserted()

    Public Event SavingEnvelope()
    Public Event EnvelopeSaved()

    Public Event RemovingEnvelope()
    Public Event EnvelopeRemoved()

    Public Event SynchronizingEnvelope()
    Public Event EnvelopeSynchronized()


#End Region

    Private m_dupcheckFormLogId, m_dupcheckProcessLogId As Integer

    Private m_barcodePrinter As String
    Private m_possibleDupFSI As DupCheckDataSetTableAdapters.mt_proc_GetPossibleDuplicateFSITableAdapter
    Private m_possibleDupROP As DupCheckDataSetTableAdapters.mt_proc_GetPossibleDuplicateROPTableAdapter
    Private m_possibleDupNonFSIROP As DupCheckDataSetTableAdapters.mt_proc_GetPossibleDuplicateNonFSIROPTableAdapter
    Private m_dupcheckDataSet As DupCheckDataSet


    ''' <summary>
    ''' Gets table adapter for stored procedure mt_proc_GetPossibleDuplicateFSI. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property PossibleDupFSIAdapter() As DupCheckDataSetTableAdapters.mt_proc_GetPossibleDuplicateFSITableAdapter
      Get
        Return m_possibleDupFSI
      End Get
    End Property

    ''' <summary>
    ''' Gets table adapter for stored procedure mt_proc_GetPossibleDuplicateROP.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property PossibleDupROPAdapter() As DupCheckDataSetTableAdapters.mt_proc_GetPossibleDuplicateROPTableAdapter
      Get
        Return m_possibleDupROP
      End Get
    End Property

    ''' <summary>
    ''' Gets table adapter for stored procedure mt_proc_GetPossibleDuplicateNonFSIROP.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property PossibleDupNonFSIROPAdapter() As DupCheckDataSetTableAdapters.mt_proc_GetPossibleDuplicateNonFSIROPTableAdapter
      Get
        Return m_possibleDupNonFSIROP
      End Get
    End Property

    ''' <summary>
    ''' Gets dataset for DupCheck.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DupCheckDataSet() As DupCheckDataSet
      Get
        Return m_dupcheckDataSet
      End Get
    End Property

    ''' <summary>
    ''' Gets Id created for call made to this instance.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DupcheckFormLogId() As Integer
      Get
        Return m_dupcheckFormLogId
      End Get
    End Property

    ''' <summary>
    ''' Gets Id created for Process executed to fetch possible duplicate vehicles.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property DupcheckProcessLogId() As Integer
      Get
        Return m_dupcheckProcessLogId
      End Get
    End Property


    Private Function GetScanDPI(ByVal retId As Integer, ByVal mktId As Integer, ByVal mediaId As Integer) As Integer
      Dim scanDPI As Integer?
      Dim tempAdapter As DupCheckDataSetTableAdapters.UtilityTableAdapter


      tempAdapter = New DupCheckDataSetTableAdapters.UtilityTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      scanDPI = tempAdapter.GetScanDPI(retId, mktId, mediaId)

      tempAdapter.Dispose()
      tempAdapter = Nothing

      If scanDPI.HasValue Then
        Return scanDPI.Value
      Else
        Return 0
      End If

    End Function

    Private Function GetUserShortName(ByVal userId As Integer) As String
      Dim shortName As String
      Dim tempAdapter As DupCheckDataSetTableAdapters.UtilityTableAdapter


      tempAdapter = New DupCheckDataSetTableAdapters.UtilityTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      shortName = tempAdapter.GetShortName(userId)

      tempAdapter.Dispose()
      tempAdapter = Nothing

      Return shortName

    End Function

    Private Function GetStatusIdForDuplicatePublication() As Integer
      Dim statusId As Integer?
      Dim tempAdapter As DupCheckDataSetTableAdapters.UtilityTableAdapter


      tempAdapter = New DupCheckDataSetTableAdapters.UtilityTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      statusId = tempAdapter.GetDuplicatePublicationStatusId()

      tempAdapter.Dispose()
      tempAdapter = Nothing

      If statusId.HasValue Then
        Return statusId.Value
      Else
        Return 0
      End If

    End Function

    Private Sub PrintBarcodeForNonROPVehicle(ByVal barcodeRow As Data.DataRowView)
      Dim retId, mktId, mediaId, scanDPI, createdById As Integer
      Dim shortName As String
      Dim labelPrint As MCAP.VehicleLabelPrint


      labelPrint = New MCAP.VehicleLabelPrint()

      createdById = CType(barcodeRow("CreatedById"), Integer)
      retId = CType(barcodeRow("RetId"), Integer)
      mktId = CType(barcodeRow("MktId"), Integer)
      mediaId = CType(barcodeRow("MediaId"), Integer)

      scanDPI = GetScanDPI(retId, mktId, mediaId)
      shortName = GetUserShortName(createdById)

      labelPrint.PrinterName = BarcodePrinterName
      labelPrint.AdDate = CType(barcodeRow("BreakDt"), DateTime)
      labelPrint.CreatedBy = shortName
      labelPrint.Market = barcodeRow("Market").ToString()
      labelPrint.Priority = CType("0" + barcodeRow("Priority").ToString(), Integer)
      labelPrint.Retailer = barcodeRow("Retailer").ToString()
      labelPrint.ScanDPI = scanDPI
      labelPrint.VehicleId = CType(barcodeRow("VehicleId"), Integer)

      labelPrint.Print()

      labelPrint.Dispose()
      labelPrint = Nothing
      shortName = Nothing
    End Sub

    Private Sub PrintBarcodeForROPVehicle(ByVal barcodeRow As Data.DataRowView)
      Dim duplicateStatusId, statusId As Integer
      Dim labelPrint As MCAP.PublicationLabelPrint


      duplicateStatusId = GetStatusIdForDuplicatePublication()
      statusId = CType(barcodeRow("StatusID"), Integer)

      labelPrint = New MCAP.PublicationLabelPrint()

      labelPrint.PrinterName = BarcodePrinterName
      labelPrint.IsDuplicate = (statusId = duplicateStatusId)
      labelPrint.NewspaperDate = CType(barcodeRow("BreakDt"), DateTime)
      labelPrint.Publication = barcodeRow("Publication").ToString()
      labelPrint.VehicleId = CType(barcodeRow("VehicleId"), Integer)

      labelPrint.Print()

      labelPrint.Dispose()
      labelPrint = Nothing
    End Sub

    ''' <summary>
    ''' Prints barcode label for vehicle.
    ''' </summary>
    ''' <param name="barcodeRow"></param>
    ''' <remarks></remarks>
    Public Sub PrintBarcode(ByVal barcodeRow As Data.DataRowView)

      If barcodeRow.DataView.Table.Columns.Contains("RetId") Then
        PrintBarcodeForNonROPVehicle(barcodeRow)
      Else
        PrintBarcodeForROPVehicle(barcodeRow)
      End If

    End Sub


    ''' <summary>
    ''' Default constructor.
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()
      MyBase.New()

      m_dupcheckDataSet = New DupCheckDataSet
      m_possibleDupFSI = New DupCheckDataSetTableAdapters.mt_proc_GetPossibleDuplicateFSITableAdapter
      m_possibleDupROP = New DupCheckDataSetTableAdapters.mt_proc_GetPossibleDuplicateROPTableAdapter
      m_possibleDupNonFSIROP = New DupCheckDataSetTableAdapters.mt_proc_GetPossibleDuplicateNonFSIROPTableAdapter

    End Sub


    ''' <summary>
    ''' Initializes object of this class.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize()

      RaiseEvent Initializing()

      PossibleDupFSIAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      PossibleDupROPAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      PossibleDupNonFSIROPAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      RaiseEvent Initialized()

    End Sub


#Region " Methods to Log Possible Duplicate Check Process "


    ''' <summary>
    ''' Logs form call in DupFormLog table.
    ''' </summary>
    ''' <param name="formName"></param>
    ''' <remarks></remarks>
    Public Sub LogFormCall(ByVal formName As String)
      Dim tempAdapter As DupCheckDataSetTableAdapters.DupFormLogTableAdapter
      Dim tempRow As DupCheckDataSet.DupFormLogRow


      tempAdapter = New DupCheckDataSetTableAdapters.DupFormLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      tempRow = Me.DupCheckDataSet.DupFormLog.NewDupFormLogRow()
      tempRow.BeginEdit()
      tempRow.UserId = UserID
      tempRow.Form = formName
      tempRow.CheckDt = System.DateTime.Now 'This value is not going to be inserted.
      tempRow.EndEdit()
      Me.DupCheckDataSet.DupFormLog.AddDupFormLogRow(tempRow)
      tempAdapter.Update(Me.DupCheckDataSet.DupFormLog)
      m_dupcheckFormLogId = tempRow.DupFormId
      tempRow = Nothing

      tempAdapter.Dispose()
      tempAdapter = Nothing

    End Sub

    Public Sub UpdateVehicleId(ByVal vehicleId As Integer)
      Dim tempAdapter As DupCheckDataSetTableAdapters.DupFormLogTableAdapter


      tempAdapter = New DupCheckDataSetTableAdapters.DupFormLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      tempAdapter.UpdateDupFormLog_VehicleId(vehicleId, Me.DupcheckFormLogId)

      tempAdapter.Dispose()
      tempAdapter = Nothing

    End Sub

    Public Sub UpdateActionTaken(ByVal actionTaken As String)
      Dim tempAdapter As DupCheckDataSetTableAdapters.DupFormLogTableAdapter


      tempAdapter = New DupCheckDataSetTableAdapters.DupFormLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      tempAdapter.UpdateDupFormLog_ActionTaken(Me.DupcheckFormLogId, actionTaken)

      tempAdapter.Dispose()
      tempAdapter = Nothing

    End Sub

    ''' <summary>
    ''' Logs DupCheck process execution in DupCheckLog table.
    ''' </summary>
    ''' <param name="dupFormId">DupFormLogId, that is created when this instance is created.</param>
    ''' <param name="dateRange">Number of days, set while comparision for possible duplicate vehicles.</param>
    ''' <remarks></remarks>
    Private Sub LogDupCheckProcessCall(ByVal dupFormId As Integer, ByVal dateRange As Integer)
      Dim tempAdapter As DupCheckDataSetTableAdapters.DupCheckLogTableAdapter
      Dim tempRow As DupCheckDataSet.DupCheckLogRow


      tempAdapter = New DupCheckDataSetTableAdapters.DupCheckLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      tempRow = Me.DupCheckDataSet.DupCheckLog.NewDupCheckLogRow()
      tempRow.BeginEdit()
      tempRow.DupFormId = dupFormId
      tempRow.DateRange = dateRange
      tempRow.RunDt = System.DateTime.Now 'This value is not going to insert into table.
      tempRow.EndEdit()
      Me.DupCheckDataSet.DupCheckLog.AddDupCheckLogRow(tempRow)
      tempAdapter.Update(Me.DupCheckDataSet.DupCheckLog)
      m_dupcheckProcessLogId = tempRow.DupCheckLogId
      tempRow = Nothing

      tempAdapter.Dispose()
      tempAdapter = Nothing

    End Sub

    ''' <summary>
    ''' Logs DupCheck process execution in DupCheckLog table.
    ''' </summary>
    ''' <param name="dateRange">Number of days, set while comparision for possible duplicate vehicles.</param>
    ''' <remarks></remarks>
    Public Sub LogDupCheckProcess(ByVal dateRange As Integer)

      LogDupCheckProcessCall(Me.DupcheckFormLogId, dateRange)

    End Sub

    ''' <summary>
    ''' Logs possible duplicate vehicles, found after execution of dupcheck process in DupCheckResultsLog table.
    ''' </summary>
    ''' <param name="dupcheckLogId"></param>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Private Sub LogDupCheckProcessResults(ByVal dupcheckLogId As Integer, ByVal vehicleId() As Integer)
      Dim tempAdapter As DupCheckDataSetTableAdapters.DupCheckResultsLogTableAdapter
      Dim tempRow As DupCheckDataSet.DupCheckResultsLogRow


      If vehicleId Is Nothing Then Exit Sub

      tempAdapter = New DupCheckDataSetTableAdapters.DupCheckResultsLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      For i As Integer = 0 To vehicleId.Length - 1
        tempRow = Me.DupCheckDataSet.DupCheckResultsLog.NewDupCheckResultsLogRow()
        tempRow.BeginEdit()
        tempRow.DupCheckLogId = dupcheckLogId
        tempRow.VehicleId = vehicleId(i)
        tempRow.EndEdit()
        Me.DupCheckDataSet.DupCheckResultsLog.AddDupCheckResultsLogRow(tempRow)
        tempAdapter.Update(Me.DupCheckDataSet.DupCheckResultsLog)
        tempRow = Nothing
      Next

      tempAdapter.Dispose()
      tempAdapter = Nothing

    End Sub

    ''' <summary>
    ''' Logs possible duplicate vehicles, found after execution of dupcheck process in DupCheckResultsLog table.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Public Sub LogDupCheckResults(ByVal vehicleId() As Integer)

      LogDupCheckProcessResults(Me.DupcheckProcessLogId, vehicleId)

    End Sub


#End Region


    ''' <summary>
    ''' Loads page information from page table based on supplied vehicleid.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Public Sub LoadPageImageInformation(ByVal vehicleId As Integer)
      Dim tempAdapter As DupCheckDataSetTableAdapters.PageTableAdapter


      tempAdapter = New DupCheckDataSetTableAdapters.PageTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      tempAdapter.FillByVehicleId(DupCheckDataSet.Page, vehicleId)
      tempAdapter.Dispose()
      tempAdapter = Nothing

    End Sub

    ''' <summary>
    ''' Returns true if supplied user is an administrator, false otherwise.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsApplicationUserAdministrator() As Boolean
      Dim isAdmin As Integer?
      Dim tempAdapter As DupCheckDataSetTableAdapters.UtilityTableAdapter


      tempAdapter = New DupCheckDataSetTableAdapters.UtilityTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      isAdmin = tempAdapter.IsUserAnAdministrator(Me.UserID)
      tempAdapter.Dispose()
      tempAdapter = Nothing


      Return (isAdmin.HasValue AndAlso isAdmin.Value > 0)

        End Function

        Public Function IsValidOverideNotADupUser() As Integer
            Dim tempAdapter As DupCheckDataSetTableAdapters.UtilityTableAdapter
            Dim validUser As Integer
            tempAdapter = New DupCheckDataSetTableAdapters.UtilityTableAdapter()
            validUser = CInt(tempAdapter.isAllowedOverideDup(UserID)) ', formName, errorMessage)
            Return validUser ' (retailerCount.HasValue AndAlso retailerCount.Value > 0)
            tempAdapter.Dispose()
            tempAdapter = Nothing
        End Function

        ''' <summary>
        ''' Loads data into DataSet using stored procedure mt_proc_GetPossibleDuplicateFSI based on supplied parameters.
        ''' </summary>
        ''' <param name="retId">Retailer Id</param>
        ''' <param name="mktId"></param>
        ''' <param name="adDate"></param>
        ''' <param name="mediaList">XML string containing list of Media to be included.</param>
        ''' <param name="Days">Records falling within specified day range from ad date will be considered.</param>
        ''' <remarks></remarks>
    Public Sub LoadPossibleDuplicateFSI(ByVal retId As Integer, ByVal mktId As Integer, ByVal adDate As DateTime, ByVal mediaList As String, ByVal languageId As Nullable(Of Integer), ByVal Days As Integer)

      PossibleDupFSIAdapter.Fill(DupCheckDataSet.mt_proc_GetPossibleDuplicateFSI, retId, mktId, adDate, mediaList, languageId, Days)

    End Sub

    ''' <summary>
    ''' Loads data into DataSet using stored procedure mt_proc_GetPossibleDuplicateROP based on supplied parameters.
    ''' </summary>
    ''' <param name="retId"></param>
    ''' <param name="mktId"></param>
    ''' <param name="publicationId"></param>
    ''' <param name="adDate"></param>
    ''' <param name="mediaText"></param>
    ''' <param name="Days">Records falling within specified day range from ad date will be considered.</param>
    ''' <remarks></remarks>
    Public Sub LoadPossibleDuplicateROP(ByVal retId As Integer, ByVal mktId As Integer, ByVal publicationId As Integer, ByVal adDate As DateTime, ByVal mediaText As String, ByVal languageId As Nullable(Of Integer), ByVal Days As Integer)

      PossibleDupROPAdapter.Fill(DupCheckDataSet.mt_proc_GetPossibleDuplicateROP, retId, mktId, publicationId, adDate, mediaText, languageId, Days)

    End Sub

    ''' <summary>
    ''' Loads data into DataSet using stored procedure mt_proc_GetPossibleDuplicateNonFSIROP based on supplied parameters.
    ''' </summary>
    ''' <param name="retId"></param>
    ''' <param name="mktId"></param>
    ''' <param name="adDate"></param>
    ''' <param name="mediaText"></param>
    ''' <param name="startDate"></param>
    ''' <param name="endDate"></param>
    ''' <param name="Days">Records falling within specified day range from ad date will be considered.</param>
    ''' <remarks></remarks>
    Public Sub LoadPossibleDuplicateNonFSIROP(ByVal retId As Integer, ByVal mktId As Integer, ByVal adDate As DateTime, ByVal mediaText As String, ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal languageId As Nullable(Of Integer), ByVal Days As Integer)

      If startDate = Nothing And endDate = Nothing Then
        PossibleDupNonFSIROPAdapter.Fill(DupCheckDataSet.mt_proc_GetPossibleDuplicateNonFSIROP _
                                         , retId, mktId, adDate, mediaText, Nothing, Nothing, languageId, Days)
      ElseIf startDate = Nothing Then
        PossibleDupNonFSIROPAdapter.Fill(DupCheckDataSet.mt_proc_GetPossibleDuplicateNonFSIROP _
                                         , retId, mktId, adDate, mediaText, Nothing, endDate, languageId, Days)
      ElseIf endDate = Nothing Then
        PossibleDupNonFSIROPAdapter.Fill(DupCheckDataSet.mt_proc_GetPossibleDuplicateNonFSIROP _
                                         , retId, mktId, adDate, mediaText, startDate, Nothing, languageId, Days)
      Else
        PossibleDupNonFSIROPAdapter.Fill(DupCheckDataSet.mt_proc_GetPossibleDuplicateNonFSIROP _
                                         , retId, mktId, adDate, mediaText, startDate, endDate, languageId, Days)
      End If

    End Sub



  End Class


End Namespace