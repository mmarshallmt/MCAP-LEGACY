﻿Namespace UI.Processors


  Public Class FamilyCheckIn
    Inherits BaseClass



#Region " Events "


    'Events can be extended to supply necessary information to consumer along with events.
    'Information passed into event can be useful to consumer while processing the event.

    Public Event Initializing()
    Public Event Initialized()

    Public Event LoadingRetailers()
    Public Event RetailersLoaded()

    Public Event LoadingMarketPublicationList()
    Public Event MarketPublicationListLoaded()

    Public Event LoadingVehicle(ByVal vehicleId As Integer)
    Public Event VehicleLoaded(ByVal vehicleRow As FamilyCheckInDataSet.vwCircularRow)
    Public Event VehicleNotFound(ByVal vehicleId As Integer)
    Public Event InvalidVehicleStatus(ByVal vehicleId As Integer, ByVal statusText As String)

    Public Event LoadingVehicles()
    Public Event VehiclesLoaded()

    Public Event ValidatingInputs()
    Public Event InputsValidated()

    Public Event UpdatingVehicle()
    Public Event VehicleUpdated()


#End Region



    Private m_familyCheckInDataSet As FamilyCheckInDataSet
    Private m_languageAdapter As FamilyCheckInDataSetTableAdapters.LanguageTableAdapter
    Private m_retailerAdapter As FamilyCheckInDataSetTableAdapters.RetailerTableAdapter
    Private m_marketAdapter As FamilyCheckInDataSetTableAdapters.MarketTableAdapter
    Private m_themeAdapter As FamilyCheckInDataSetTableAdapters.ThemeTableAdapter
    Private m_mediaAdapter As FamilyCheckInDataSetTableAdapters.MediaTableAdapter
    Private m_publicationAdapter As FamilyCheckInDataSetTableAdapters.PublicationTableAdapter
    Private m_eventAdapter As FamilyCheckInDataSetTableAdapters.EventTableAdapter
    Private m_vehicleStatusAdapter As FamilyCheckInDataSetTableAdapters.vwVehicleStatusTableAdapter
    Private m_vehicleAdapter As FamilyCheckInDataSetTableAdapters.vwCircularTableAdapter



    Sub New()

      m_familyCheckInDataSet = New FamilyCheckInDataSet

      m_mediaAdapter = New FamilyCheckInDataSetTableAdapters.MediaTableAdapter
      m_languageAdapter = New FamilyCheckInDataSetTableAdapters.LanguageTableAdapter
      m_retailerAdapter = New FamilyCheckInDataSetTableAdapters.RetailerTableAdapter
      m_marketAdapter = New FamilyCheckInDataSetTableAdapters.MarketTableAdapter
      m_publicationAdapter = New FamilyCheckInDataSetTableAdapters.PublicationTableAdapter
      m_eventAdapter = New FamilyCheckInDataSetTableAdapters.EventTableAdapter
      m_themeAdapter = New FamilyCheckInDataSetTableAdapters.ThemeTableAdapter
      m_vehicleStatusAdapter = New FamilyCheckInDataSetTableAdapters.vwVehicleStatusTableAdapter
      m_vehicleAdapter = New FamilyCheckInDataSetTableAdapters.vwCircularTableAdapter

    End Sub



    ''' <summary>
    ''' Gets adapter for language table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LanguageAdapter() As FamilyCheckInDataSetTableAdapters.LanguageTableAdapter
      Get
        Return m_languageAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets adapter for retailer table.
    ''' </summary>
    ''' <value></value>
    Public ReadOnly Property RetailerAdapter() As FamilyCheckInDataSetTableAdapters.RetailerTableAdapter
      Get
        Return m_retailerAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets adapter for market table.
    ''' </summary>
    ''' <value></value>
    Public ReadOnly Property MarketAdapter() As FamilyCheckInDataSetTableAdapters.MarketTableAdapter
      Get
        Return m_marketAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets adapter for theme view.
    ''' </summary>
    ''' <value></value>
    Public ReadOnly Property ThemeAdapter() As FamilyCheckInDataSetTableAdapters.ThemeTableAdapter
      Get
        Return m_themeAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets adapter for media table.
    ''' </summary>
    ''' <value></value>
    Public ReadOnly Property MediaAdapter() As FamilyCheckInDataSetTableAdapters.MediaTableAdapter
      Get
        Return m_mediaAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets adapter for publication table.
    ''' </summary>
    ''' <value></value>
    Public ReadOnly Property PublicationAdapter() As FamilyCheckInDataSetTableAdapters.PublicationTableAdapter
      Get
        Return m_publicationAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets adapter for Event view.
    ''' </summary>
    ''' <value></value>
    Public ReadOnly Property EventAdapter() As FamilyCheckInDataSetTableAdapters.EventTableAdapter
      Get
        Return m_eventAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets adapter for VehicleStatus view.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property VehicleStatusAdapter() As FamilyCheckInDataSetTableAdapters.vwVehicleStatusTableAdapter
      Get
        Return m_vehicleStatusAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets adapter for vehicle table.
    ''' </summary>
    ''' <value></value>
    Public ReadOnly Property VehicleAdapter() As FamilyCheckInDataSetTableAdapters.vwCircularTableAdapter
      Get
        Return m_vehicleAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets instance of class FamilyCheckInDataSet.
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property Data() As FamilyCheckInDataSet
      Get
        Return m_familyCheckInDataSet
      End Get
    End Property



    Public Sub Initialize()

      RaiseEvent Initializing()

      MediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      LanguageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      RetailerAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      MarketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      PublicationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      ThemeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      EventAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      VehicleStatusAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      VehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      RaiseEvent Initialized()

    End Sub


    ''' <summary>
    ''' Loads tables into dataset.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadDataSet()

      LanguageAdapter.Fill(Data.Language)
      MediaAdapter.Fill(Data.Media)
      EventAdapter.Fill(Data._Event)
      ThemeAdapter.Fill(Data.Theme)

    End Sub

    ''' <summary>
    ''' Loads Market-Publication list from vehicle table based on supplied parameters.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadMarketPublicationList(ByVal breakDt As DateTime, ByVal mediaId As Integer, _
                                         ByVal retailerId As Integer, ByVal dayRange As Integer)

      RaiseEvent LoadingMarketPublicationList()

            'MarketAdapter.FillForMktPub(Data.Market, mediaId, retailerId, breakDt, dayRange)
            MarketAdapter.FillForMktPubNoMedia(Data.Market, retailerId, breakDt, dayRange)

      RaiseEvent MarketPublicationListLoaded()

    End Sub

    ''' <summary>
    ''' Loads vehicles having supplied market in family.
    ''' </summary>
    ''' <param name="marketId">Search for existance of market in family.</param>
    ''' <param name="familyId">Search for market within family.</param>
    ''' <remarks></remarks>
    Public Sub LoadVehiclesInFamily(ByVal marketId As Integer, ByVal familyId As Integer)
      Dim tempAdapter As FamilyCheckInDataSetTableAdapters.DuplicateMarketTableTableAdapter


      tempAdapter = New FamilyCheckInDataSetTableAdapters.DuplicateMarketTableTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      tempAdapter.Fill(Data.DuplicateMarketTable, familyId, marketId)

      tempAdapter.Dispose()
      tempAdapter = Nothing
    End Sub

    ''' <summary>
    ''' Sets status id of vehicle as Duplicate.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="formName"></param>
    ''' <remarks></remarks>
    Public Sub SetVehicleStatusAsDuplicate(ByVal vehicleId As Integer, ByVal formName As String)
      Dim duplicateStatusId As Integer
      Dim tempAdapter As FamilyCheckInDataSetTableAdapters.DuplicateMarketTableTableAdapter


      duplicateStatusId = GetStatusIdForDuplicate()

      tempAdapter = New FamilyCheckInDataSetTableAdapters.DuplicateMarketTableTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      tempAdapter.UpdateVehicleStatus(duplicateStatusId, formName, vehicleId)

      tempAdapter.Dispose()
      tempAdapter = Nothing
    End Sub

    ''' <summary>
    ''' Loads market publication for supplied vehicle id.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Protected Sub LoadMarketPublicationForVehicleId(ByVal vehicleId As Integer)

      RaiseEvent LoadingMarketPublicationList()

      MarketAdapter.FillForVehicleId(Data.Market, vehicleId)

      RaiseEvent MarketPublicationListLoaded()

    End Sub

    ''' <summary>
    ''' Loads retailers based on supplied ad date and media id.
    ''' </summary>
    ''' <param name="breakDt"></param>
    ''' <param name="mediaId"></param>
    ''' <remarks></remarks>
    Public Sub LoadRetailersByAdDateAndMedia(ByVal breakDt As DateTime, ByVal mediaId As Integer)

      RaiseEvent LoadingRetailers()

      RetailerAdapter.FillByAdDateAndMedia(Data.Retailer, breakDt, mediaId)

      RaiseEvent RetailersLoaded()

    End Sub

    ''' <summary>
    ''' Loads retailers based on supplied vehicle id.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Protected Sub LoadRetailerForVehicleId(ByVal vehicleId As Integer)

      RaiseEvent LoadingRetailers()

      RetailerAdapter.FillForVehicleId(Data.Retailer, vehicleId)

      RaiseEvent RetailersLoaded()

    End Sub

    ''' <summary>
    ''' Loads vehicles from vwCircular view based on supplied parameter values.
    ''' </summary>
    ''' <param name="breakDt">Ad date</param>
    ''' <param name="mediaId">Media Id</param>
    ''' <param name="retailerId">Retailer Id</param>
    ''' <remarks></remarks>
    Public Sub LoadVehicles(ByVal breakDt As DateTime, ByVal mediaId As Integer, ByVal retailerId As Integer, ByVal dayRange As Integer)

      RaiseEvent LoadingVehicles()

            'VehicleAdapter.FillForFamilyIndex(Data.vwCircular, mediaId, retailerId, breakDt, dayRange)
            VehicleAdapter.FillByFamilyIndexNoMedia(Data.vwCircular, retailerId, breakDt, dayRange)

      RaiseEvent VehiclesLoaded()

    End Sub

    Public Function GetVehicleRow(ByVal vehicleId As Integer) As FamilyCheckInDataSet.vwCircularRow
      Dim vehicleRow As FamilyCheckInDataSet.vwCircularRow


      'VehicleAdapter.FillByVehicleId(Data.vwCircular, vehicleId)
      vehicleRow = Data.vwCircular.FindByVehicleId(vehicleId)

      Return vehicleRow

    End Function

    ''' <summary>
    ''' Returns vehicle row of the supplied vehicle id.
    ''' </summary>
    ''' <param name="vehicleId">Vehicle Id</param>
    ''' <remarks></remarks>
    Public Sub FindVehicle(ByVal vehicleId As Integer, ByVal formName As String)
      Dim errorMessage As String


      LoadRetailerForVehicleId(vehicleId)
      LoadMarketPublicationForVehicleId(vehicleId)

      RaiseEvent LoadingVehicle(vehicleId)

      VehicleAdapter.FillByVehicleId(Data.vwCircular, vehicleId, formName, errorMessage)

      If Data.vwCircular.Count = 0 AndAlso errorMessage Is Nothing Then
        RaiseEvent VehicleNotFound(vehicleId)
      ElseIf Data.vwCircular.Count = 0 AndAlso errorMessage IsNot Nothing Then
        RaiseEvent InvalidVehicleStatus(vehicleId, errorMessage)
      Else
        RaiseEvent VehicleLoaded(Data.vwCircular(0))
      End If

    End Sub

    ''' <summary>
    ''' Gets boolean flag indicating whether the supplied userId is assigned a 
    ''' supervisor or an administrator role or not.
    ''' </summary>
    ''' <param name="UserID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsUserSupervisorOrAdministrator(ByVal userID As Integer) As Boolean
      Dim tempAdapter As MCAP.FamilyCheckInDataSetTableAdapters.vwCircularTableAdapter
      Dim userCount As Integer?

      tempAdapter = New MCAP.FamilyCheckInDataSetTableAdapters.vwCircularTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      userCount = tempAdapter.IsUserAdministrator(UserID)
      tempAdapter.Dispose()
      tempAdapter = Nothing

      If userCount.HasValue And userCount.Value > 0 Then
        Return True
      Else
        Return False
      End If

    End Function


#Region " Validation related methods "


#Region " Business Logic related validations "


    ''' <summary>
    ''' Validates all columns of supplied DataRow.
    ''' </summary>
    ''' <param name="validateRow"></param>
    ''' <returns>
    ''' True if all columns contains valid inforamtion. False otherwise.
    ''' </returns>
    ''' <remarks></remarks>
    Public Function AreDatesValid(ByVal validateRow As FamilyCheckInDataSet.vwCircularRow) As Boolean

      If validateRow.RetailerRow IsNot Nothing Then
        If validateRow.MediaRow.Descrip.ToUpper() = "ROP" _
          AndAlso validateRow.RetailerRow.Retailer.ToUpper() = "WALMART" _
          AndAlso validateRow.IsStartDtNull() = False _
          AndAlso validateRow.StartDt.Subtract(validateRow.BreakDt).Days > 0 _
          AndAlso validateRow.StartDt.Subtract(DateTime.Today).Days > 0 _
        Then
          AddErrorInformation(Data.Errors, "StartDt", "Start Date", "Sale Start date is greater than Ad date," _
                              + " this is not allowed for a Walmart Ad. Please review and re-index.")
          Return False
        Else
          RemoveErrorInformation(Data.Errors, "StartDt")
        End If
      End If

      'If validateRow.HasErrors = False Then
      '  ValidateRequiredRetailerInputs(validateRow)
      '  IsStartDateValid(validateRow)
      '  IsEndDateValid(validateRow)
      'End If

      If Data.Errors.Count = 0 AndAlso validateRow.IsPriorityNull() = False Then
        If validateRow.Priority >= 0 Then
          RemoveErrorInformation(Data.Errors, "Priority")
          validateRow.SetColumnError("Priority", String.Empty)
        Else
          AddErrorInformation(Data.Errors, "Priority", "Priority", "Unexpected Market-Media-Retailer combination.")
          validateRow.SetColumnError("Priority", "Unexpected Market-Media-Retailer combination.")
          validateRow.SetPriorityNull()
        End If
      End If


      Return (Not validateRow.HasErrors)

    End Function


#End Region


    ''' <summary>
    ''' Validates all columns of supplied row.
    ''' </summary>
    ''' <param name="validateRow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AreInputsValid(ByVal validateRow As FamilyCheckInDataSet.vwCircularRow) As Boolean
      Dim areAllValid As Boolean


      RaiseEvent ValidatingInputs()

      areAllValid = True

      If areAllValid Then areAllValid = AreDatesValid(validateRow)

      RaiseEvent InputsValidated()

      Return areAllValid

    End Function


#End Region



    ''' <summary>
    ''' Gets status whether vehicle is having page information defined in page table or not.
    ''' </summary>
    ''' <param name="vehicleId">Check page information for vehicle id.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsPageInformationAvailable(ByVal vehicleId As Integer) As Boolean
      Dim pageCount As Nullable(Of Integer)


      pageCount = VehicleAdapter.GetPageCount(vehicleId)

      If (pageCount Is Nothing OrElse pageCount = 0) Then
        Return False
      Else
        pageCount = Nothing
        Return True
      End If

    End Function

    ''' <summary>
    ''' Gets status whether vehicle is having page information defined in page table or not.
    ''' </summary>
    ''' <param name="vehicleId">Check page information for vehicle id.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPageCount(ByVal vehicleId As Integer) As Integer
      Dim pageCount As Nullable(Of Integer)


      pageCount = VehicleAdapter.GetPageCount(vehicleId)

      If (pageCount Is Nothing OrElse pageCount = 0) Then
        Return 0
      Else
        Return CType(pageCount, Integer)
      End If

    End Function


    ''' <summary>
    ''' Updates vehicle information in dataset and database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateVehicle(ByVal vehicleRow As FamilyCheckInDataSet.vwCircularRow)

      RaiseEvent UpdatingVehicle()

      VehicleAdapter.Update(vehicleRow)

      RaiseEvent VehicleUpdated()

    End Sub

    ''' <summary>
    ''' Replaces page information for supplied vehicles with the page information of source vehicle.
    ''' </summary>
    ''' <param name="sourceVehicleId">Source vehicle Id.</param>
    ''' <param name="destinationVehicleIds">A xml string containing list of vehicleIds. Page information 
    ''' of these vehicle Ids will be replaced with page information of source vehicle id.</param>
    ''' <remarks></remarks>
    Public Sub CopyPageInformation(ByVal sourceVehicleId As Integer, ByVal destinationVehicleIds As String, ByVal formName As String)

      VehicleAdapter.mt_proc_CopyPageInformation(sourceVehicleId, destinationVehicleIds, formName)

    End Sub

    ''' <summary>
    ''' Copies page information for supplied vehicles with the page information of source vehicle.
    ''' </summary>
    ''' <param name="sourceVehicleId"></param>
    ''' <param name="destinationVehicleId"></param>
    ''' <remarks></remarks>
    Public Sub CopyPageInformation(ByVal sourceVehicleId As Integer, ByVal destinationVehicleId() As Integer, ByVal formName As String)
      Dim vehicleIdXMLString As System.Text.StringBuilder


      vehicleIdXMLString = New System.Text.StringBuilder()
      vehicleIdXMLString.Append("<VehicleIdList>")
      For i As Integer = 0 To destinationVehicleId.Length
        vehicleIdXMLString.Append("<VehicleId>")
        vehicleIdXMLString.Append(destinationVehicleId(i).ToString())
        vehicleIdXMLString.Append("</VehicleId>")
      Next
      vehicleIdXMLString.Append("</VehicleIdList>")

      VehicleAdapter.mt_proc_CopyPageInformation(sourceVehicleId, vehicleIdXMLString.ToString(), formName)

      vehicleIdXMLString = Nothing

    End Sub

    ''' <summary>
    ''' Copies page information for supplied vehicles with the page information of source vehicle.
    ''' </summary>
    ''' <param name="sourceVehicleId"></param>
    ''' <param name="destinationVehicleId"></param>
    ''' <remarks></remarks>
    Public Sub CopyPageInformation(ByVal sourceVehicleId As Integer, ByVal destinationVehicleId As Integer, ByVal formName As String)
      Dim vehicleIdXMLString As String


      vehicleIdXMLString = "<VehicleIdList><VehicleId>" + destinationVehicleId.ToString() + "</VehicleId></VehicleIdList>"

      VehicleAdapter.mt_proc_CopyPageInformation(sourceVehicleId, vehicleIdXMLString, formName)

      vehicleIdXMLString = Nothing

    End Sub


    ''' <summary>
    ''' Set-up the Vehicle page definitions screen with initial info
    ''' </summary>
    ''' <param name="sourceVehicleId">Source vehicle Id.</param>
    ''' <param name="vehicleId">First VehicleId</param>
    ''' <remarks></remarks>
    Public Sub DefaultPageInformation(ByVal sourceVehicleId As Integer, ByVal vehicleId As Integer, ByVal formName As String)
      Dim pageAdapter As QCDataSetTableAdapters.PageTableAdapter
      Dim vehicleIdList As String


      pageAdapter = New QCDataSetTableAdapters.PageTableAdapter
      pageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      vehicleIdList = "<VehicleIdList><VehicleId>" + vehicleId.ToString() + "</VehicleId></VehicleIdList>"
      pageAdapter.CopyVehiclePageInformation(sourceVehicleId, vehicleIdList, formName)

      pageAdapter.Dispose()
      pageAdapter = Nothing
      vehicleIdList = Nothing

    End Sub

    ''' <summary>
    ''' Gets code id for Indexed status.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetStatusIdForIndexed() As Integer
      Dim statusId As Integer
      'Dim linqQuery As System.Collections.Generic.IEnumerator(Of FamilyCheckInDataSet.vwVehicleStatusRow)


      If Integer.TryParse(VehicleStatusAdapter.GetStatusIdForIndexed().ToString(), statusId) = False Then
        statusId = -1
      End If

      Return statusId

    End Function

    ''' <summary>
    ''' Gets code id for Review status.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetStatusIdForReview() As Integer
      Dim statusId As Integer
      'Dim linqQuery As System.Collections.Generic.IEnumerator(Of FamilyCheckInDataSet.vwVehicleStatusRow)


      If Integer.TryParse(VehicleStatusAdapter.GetStatusIdForReview().ToString(), statusId) = False Then
        statusId = -1
      End If

      Return statusId

    End Function

    ''' <summary>
    ''' Gets code id for Duplicate status.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetStatusIdForDuplicate() As Integer
      Dim statusId As Integer


      If Integer.TryParse(VehicleStatusAdapter.GetStatusIdForDuplicate().ToString(), statusId) = False Then
        statusId = -1
      End If

      Return statusId

    End Function

    ''' <summary>
    ''' Returns true if vehicle is having status set to Review, false otherwise.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsVehicleReviewed(ByVal vehicleId As Integer) As Boolean
      Dim recordCount As Integer
      Dim reviewedCount As Object


      reviewedCount = VehicleStatusAdapter.IsVehicleStatusReview(vehicleId)

      If reviewedCount Is Nothing OrElse reviewedCount Is DBNull.Value Then
        recordCount = 0
      ElseIf Integer.TryParse(reviewedCount.ToString(), recordCount) = False Then
        recordCount = 0
      End If

      reviewedCount = Nothing

      Return (recordCount > 0)

    End Function

    ''' <summary>
    ''' Returns true if vehicle is having status set to  Duplicate, false otherwise.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsVehicleDuplicate(ByVal vehicleId As Integer) As Boolean
      Dim recordCount As Integer
      Dim reviewedCount As Object


      reviewedCount = VehicleStatusAdapter.IsVehicleStatusDuplicate(vehicleId)

      If reviewedCount Is Nothing OrElse reviewedCount Is DBNull.Value Then
        recordCount = 0
      ElseIf Integer.TryParse(reviewedCount.ToString(), recordCount) = False Then
        recordCount = 0
      End If

      reviewedCount = Nothing

      Return (recordCount > 0)

    End Function

    ''' <summary>
    ''' Sets status Id column value to indexed status in supplied datarow.
    ''' </summary>
    ''' <param name="vehicleRow"></param>
    ''' <remarks></remarks>
    Public Sub SetVehicleStatusAsIndexed(ByVal vehicleRow As FamilyCheckInDataSet.vwCircularRow)
      Dim indexedStatusId As Integer


      indexedStatusId = GetStatusIdForIndexed()

      vehicleRow.StatusID = indexedStatusId
      'vehicleRow.IndexDt = DateTime.Now
      vehicleRow.IndexedById = UserID

    End Sub

    ''' <summary>
    ''' Gets priority based on supplied retailer id, market id and media id.
    ''' </summary>
    ''' <param name="retId"></param>
    ''' <param name="mktId"></param>
    ''' <param name="mediaId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPriority(ByVal retId As Integer, ByVal mktId As Integer, ByVal mediaId As Integer) As Integer
      Dim priority As Nullable(Of Integer)


      priority = VehicleAdapter.GetPriority(retId, mktId, mediaId)
      If priority Is Nothing Then
        Return -1
      Else
        Return CType(priority, Integer)
      End If

    End Function


  End Class


End Namespace