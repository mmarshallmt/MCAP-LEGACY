Namespace UI.Processors


  Public Class Index
    Inherits IndexBase



#Region " Events "


    Public Event Initializing()
    Public Event Initialized()

    Public Event PreparingAdapter()
    Public Event AdapterPrepared()

    Public Event LoadingData()
    Public Event DataLoaded()

    Public Event LoadingVehicle(ByVal vehicleId As Integer)
    Public Event VehicleLoaded(ByVal vehicleRow As QCDataSet.vwCircularRow)
    Public Event VehicleNotFound(ByVal vehicleId As Integer)
    Public Event InvalidVehicleStatus(ByVal statusText As String)

    Public Event LoadingMarkets()
    Public Event MarketsLoaded()

    Public Event LoadingPublications()
    Public Event PublicationsLoaded()

    Public Event LoadingRetailers()
    Public Event RetailersLoaded()

    Public Event ValidatingInputs()
    Public Event InputsValidated()
    Public Event InvalidInputExist()

    Public Event DeletingVehicle As MCAPCancellableEventHandler
    Public Event VehicleDeleted As MCAPEventHandler

    Public Event SynchronizingVehicleInformation()
    Public Event VehicleInformationSynchronized()

        Public Event LoadingEnvelopeSender As MCAPCancellableEventHandler
        Public Event EnvelopeSenderLoaded As MCAPEventHandler
        Public Event EnvelopeSenderNotFound As MCAPEventHandler

#End Region


        'Sender Association
        Protected _Sender As Integer
        Public _senderName As String
        Protected m_vehicleAdapter As QCDataSetTableAdapters.vwCircularTableAdapter
        Protected m_senderAdapter As QCDataSetTableAdapters.SenderTableAdapter



    Sub New()

            m_vehicleAdapter = New QCDataSetTableAdapters.vwCircularTableAdapter
            m_senderAdapter = New QCDataSetTableAdapters.SenderTableAdapter

    End Sub



    Protected ReadOnly Property VehicleAdapter() As QCDataSetTableAdapters.vwCircularTableAdapter
      Get
        Return m_vehicleAdapter
      End Get
    End Property



    Public Overridable Sub Initialize()

      RaiseEvent Initializing()

      SetAdaptersConnectionString()

      VehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      RaiseEvent Initialized()

    End Sub



    ''' <summary>
    ''' Loads information from database.
    ''' </summary>
    ''' <remarks></remarks>
        Public Overrides Sub LoadDataSet(ByVal _sender As Integer)

            RaiseEvent LoadingData()

            MyBase.LoadDataSet(_sender)

            RaiseEvent DataLoaded()

        End Sub


    ''' <summary>
    ''' Loads market based on sender of the supplied envelope.
    ''' </summary>
    ''' <param name="envelopeId"></param>
    ''' <remarks></remarks>
    Public Sub LoadMarket(ByVal envelopeId As Integer)

      RaiseEvent LoadingMarkets()

      LoadMarkets(envelopeId)

      RaiseEvent MarketsLoaded()

        End Sub

        ''' <summary>
        ''' Loads market based on sender of the supplied envelope.
        ''' </summary>
        ''' <param name="envelopeId"></param>
        ''' <remarks></remarks>
        Public Sub LoadMarket(ByVal senderid As Integer, ByVal vehicleid As Integer)

            RaiseEvent LoadingMarkets()

            LoadMarkets(vehicleid, senderid)

            RaiseEvent MarketsLoaded()

        End Sub

        ''' <summary>
        ''' Loads markets based on sender of supplied envelope Id.
        ''' </summary>
        ''' <param name="envelopeId">Markets are loaded based on sender of supplied  envelope Id.</param>
        ''' <remarks></remarks>
        Public Function LoadMarketsPerSenderExpectation(ByVal _sender As Integer, ByVal media As Integer) As Integer
            RaiseEvent LoadingMarkets()

            MarketAdapter.FillBySenderExpectation(Data.Mkt, media, _sender)

            If Data.Mkt.Rows.Count > 0 Then
                Return Data.Mkt.Rows.Count
            Else
                Return 0
            End If


            RaiseEvent MarketsLoaded()

        End Function
    ''' <summary>
    ''' Loads markets for media type Catalog.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadMarketsForCatalog()

      RaiseEvent LoadingMarkets()

      MarketAdapter.FillForCatalog(Data.Mkt)

      RaiseEvent MarketsLoaded()

    End Sub


    ''' <summary>
    ''' Loads publication based on supplied market id.
    ''' </summary>
    ''' <param name="marketId"></param>
    ''' <remarks></remarks>
        Public Sub LoadPublication(ByVal marketId As Integer, ByVal publicationid As Integer)

            RaiseEvent LoadingPublications()

            LoadPublications(marketId, publicationid)

            RaiseEvent PublicationsLoaded()

        End Sub

    ''' <summary>
    ''' Loads publication with NA
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadNAPublicationIndex()

      RaiseEvent LoadingPublications()

      LoadNAPublication()

      RaiseEvent PublicationsLoaded()

    End Sub


    ''' <summary>
    ''' Loads retailer based on expectation table by filtering on supplied mediaId and marketId values.
    ''' </summary>
    ''' <param name="mediaId"></param>
    ''' <param name="marketId"></param>
    ''' <remarks></remarks>
    Public Sub LoadRetailer(ByVal mediaId As Integer, ByVal marketId As Integer)

      RaiseEvent LoadingRetailers()

      LoadRetailers(mediaId, marketId)

      RaiseEvent RetailersLoaded()

        End Sub
        ''' <summary>
        ''' Loads retailers based on sender id
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Public Function LoadRetailersSenderExpectation(ByVal _sender As Integer, ByVal _mkt As Integer, ByVal _media As Integer, ByVal _senderID As Integer) As Integer

            RaiseEvent LoadingRetailers()

            RetailerAdapter.FillBySenderExpectation(Data.Ret, _media, _mkt, _senderID)

            If Data.Ret.Rows.Count > 0 Then
                Return Data.Ret.Rows.Count
            Else
                Return 0
            End If
            RaiseEvent RetailersLoaded()
        End Function

        ''' <summary>
        ''' Gets table adapter for Sender table.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected ReadOnly Property QCSenderAdapter() As QCDataSetTableAdapters.SenderTableAdapter
            Get
                Return m_senderAdapter
            End Get
        End Property

    Public Sub CopyPageInformation(ByVal sourceVehicleId As Integer, ByVal vehicleId As Integer, ByVal formName As String)
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
    ''' Loads vehicle information from vwCircular based on supplied vehicle Id.
    ''' </summary>
    ''' <param name="formName">Name of the screen. This value is used to apply 
    ''' where clause while loading vehicle information from vwCircular.</param>
    ''' <remarks></remarks>
    Public Overrides Sub LoadVehicle(ByVal vehicleId As Integer, ByVal formName As String)
      Dim errorMessage As String


      RaiseEvent LoadingVehicle(vehicleId)

      VehicleAdapter.FillByVehicleId(Data.vwCircular, vehicleId, formName, errorMessage)

      If Data.vwCircular.Count = 0 AndAlso errorMessage Is Nothing Then
        RaiseEvent VehicleNotFound(vehicleId)
      ElseIf Data.vwCircular.Count = 0 AndAlso errorMessage IsNot Nothing Then
                RaiseEvent InvalidVehicleStatus(errorMessage)
            ElseIf errorMessage = "QC Completed" Then
                RaiseEvent InvalidVehicleStatus(errorMessage)
      Else
        RaiseEvent VehicleLoaded(Data.vwCircular(0))
      End If

    End Sub
        ''' <summary>
        ''' Loads envelope sender information based on supplied envelopeID.
        ''' </summary>
        ''' <param name="envelopeID">ID of the envelope, whose information is to be loaded.</param>
        ''' <remarks></remarks>
        Public Function LoadEnvelopeSenderInfo(ByVal envelopeID As Integer) As Integer

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Cancel = False
                e.Data.Add("EnvelopeId", envelopeID)

                RaiseEvent LoadingEnvelopeSender(Me, e)
                If e.Cancel Then
                    Exit Function
                End If
            End Using

            QCSenderAdapter.Fill(Data.Sender, envelopeID)

            If Data.Sender.Count = 0 Then

                Using e As EventArgs = New EventArgs
                    e.Data.Add("EnvelopeId", envelopeID)
                    RaiseEvent EnvelopeSenderNotFound(Me, e)
                End Using
            Else
                _Sender = CInt(Data.Sender.Rows(0).Item(0).ToString)
                _senderName = Data.Sender.Rows(0).Item(1).ToString
                Using e As EventArgs = New EventArgs
                    e.Data.Add("EnvelopeId", envelopeID)
                    e.Data.Add("EnvelopeSenderRow", Data.Sender(0))
                    RaiseEvent EnvelopeSenderLoaded(Me, e)
                End Using
            End If

            Return _Sender
        End Function

    ''' <summary>
    ''' Gets number of pages defined for supplied vehicleId.
    ''' </summary>
    ''' <param name="vehicleId">Gets page count for vehicle id.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPageCount(ByVal vehicleId As Integer) As Integer
      Dim pageCount As Nullable(Of Integer)
      Dim pageAdapter As QCDataSetTableAdapters.PageTableAdapter


      pageAdapter = New QCDataSetTableAdapters.PageTableAdapter
      pageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      pageCount = pageAdapter.GetPageCount(vehicleId)
      pageAdapter.Dispose()
      pageAdapter = Nothing

      If (pageCount Is Nothing OrElse pageCount = 0) Then
        Return 0
      Else
        Return CType(pageCount, Integer)
      End If

    End Function

    ''' <summary>
    ''' Gets status whether vehicle is having page information defined in page table or not.
    ''' </summary>
    ''' <param name="vehicleId">Check page information for vehicle id.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsPageInformationAvailable(ByVal vehicleId As Integer) As Boolean
      'Dim pageCount As Nullable(Of Integer)
      'Dim pageAdapter As QCDataSetTableAdapters.PageTableAdapter


      'pageAdapter = New QCDataSetTableAdapters.PageTableAdapter
      'pageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      'pageCount = pageAdapter.GetPageCount(vehicleId)
      'pageAdapter.Dispose()
      'pageAdapter = Nothing

      'If (pageCount Is Nothing OrElse pageCount = 0) Then
      '  Return False
      'Else
      '  pageCount = Nothing
      '  Return True
      'End If

      Return (GetPageCount(vehicleId) > 0)

    End Function


#Region " Validation related methods "


#Region " Business Logic related validation methods "


    ''' <summary>
    ''' Validates all columns of supplied DataRow.
    ''' </summary>
    ''' <param name="validateRow"></param>
    ''' <returns>
    ''' True if all columns contains valid inforamtion. False otherwise.
    ''' </returns>
    ''' <remarks></remarks>
    Public Function AreDatesValid(ByVal validateRow As QCDataSet.vwCircularRow) As Boolean

      If validateRow.RetRow IsNot Nothing Then
        If validateRow.MediaRow.Descrip.ToUpper() = "ROP" _
          AndAlso validateRow.RetRow.Descrip.ToUpper() = "WALMART" _
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


    '''' <summary>
    '''' Validates start date for its duration from Ad date. 
    '''' </summary>
    '''' <param name="validateRow"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Protected Function IsStartDateValid(ByVal validateRow As EnvelopeContentDataSet.vwCircularRow) As Boolean
    '  Dim isDateValid As Boolean
    '  Dim dateDifference As Integer


    '  If validateRow.IsStartDtNull() Then
    '    validateRow.SetColumnError("StartDt", "")
    '    Return True
    '  End If

    '  isDateValid = True
    '  dateDifference = validateRow.StartDt.Subtract(validateRow.BreakDt).Days

    '  If (validateRow.MediaRow.Descrip.ToUpper() = "MAILER" _
    '    Or validateRow.MediaRow.Descrip.ToUpper() = "CATALOG") _
    '    And (dateDifference < -7 Or dateDifference > 7) _
    '  Then
    '    isDateValid = False
    '    validateRow.SetColumnError("StartDt", "Start Date needs to be within 7 days of Ad Date.")

    '  ElseIf validateRow.RetRow.TradeClassRow.Descrip.ToUpper() = "DEPT" _
    '    And (dateDifference < -14 Or dateDifference > 14) _
    '  Then
    '    isDateValid = False
    '    validateRow.SetColumnError("StartDt", "Start Date needs to be within 14 days of Ad Date.")

    '  ElseIf dateDifference < -28 Or dateDifference > 28 Then
    '    isDateValid = False
    '    validateRow.SetColumnError("StartDt", "Start Date needs to be within 28 days of Ad Date.")

    '  ElseIf dateDifference < -3 Or dateDifference > 3 Then
    '    isDateValid = False
    '    validateRow.SetColumnError("StartDt", "Start Date is not within 3 days of Ad Date.")
    '  End If


    '  Return isDateValid

    'End Function

    '''' <summary>
    '''' Validates end date for its duration from start date and ad date.
    '''' </summary>
    '''' <param name="validateRow"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Function IsEndDateValid(ByVal validateRow As EnvelopeContentDataSet.vwCircularRow) As Boolean
    '  Dim isDateValid As Boolean


    '  If validateRow.IsEndDtNull() Then
    '    validateRow.SetColumnError("EndDt", "")
    '    Return True
    '  End If

    '  isDateValid = True

    '  If validateRow.EndDt.Subtract(validateRow.StartDt).Days < 0 Then
    '    validateRow.SetColumnError("EndDt", "End date cannot be prior to Start date.")
    '    isDateValid = False
    '  ElseIf validateRow.EndDt.Subtract(validateRow.StartDt).Days > 30 Then
    '    validateRow.SetColumnError("EndDt", "End date is not within 30 days of Start date.")
    '    isDateValid = False
    '  ElseIf validateRow.BreakDt.Subtract(validateRow.EndDt).Days > 35 Then
    '    validateRow.SetColumnError("EndDt", "End date is not within 35 days of Ad date.")
    '    isDateValid = False
    '  End If


    '  Return isDateValid

    'End Function


#End Region


    ''' <summary>
    ''' Returns true if vehicle is not marked as parent for some other vehicle, false otherwise.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidChildVehicle(ByVal vehicleId As Integer) As Boolean
      Dim count As Integer?


      count = Me.VehicleAdapter.IsValidChildVehicle(vehicleId)


      Return Not (count.HasValue AndAlso count.Value > 0)

    End Function

    ''' <summary>
    ''' Returns boolean value indicating whether supplied vehicleId is a valid parent vehicleId or not.
    ''' </summary>
    ''' <param name="parentvehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidParentVehicleId(ByVal parentvehicleId As Integer) As Boolean
      Dim count As Integer?


      count = Me.VehicleAdapter.IsValidParentVehicleId(parentvehicleId)


      Return (count.HasValue AndAlso count.Value > 0)

    End Function


    ''' <summary>
    ''' Checks whether all columns contain valid values or not. Returns false if not, true otherwise.
    ''' </summary>
    ''' <param name="validateRow"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AreInputsValid(ByVal validateRow As QCDataSet.vwCircularRow) As Boolean
      Dim areAllValid As Boolean


      RaiseEvent ValidatingInputs()

      areAllValid = True

      If validateRow.IsParentVehicleIdNull() = False AndAlso IsValidChildVehicle(validateRow.VehicleId) = False Then
        areAllValid = False
        AddErrorInformation(Data.Errors, "VehicleId", "Vehicle Id", "This vehicle is marked as Parent Vehicle for other vehicle(s) and hence can not have Parent Vehicle for itself.")
      End If

      If validateRow.IsParentVehicleIdNull() = False AndAlso IsValidParentVehicleId(validateRow.ParentVehicleId) = False Then
        areAllValid = False
        AddErrorInformation(Data.Errors, "ParentVehicleId", "Parent Vehicle Id", "Invalid Parent Vehicle.")
      End If

      'If validateRow.IsBreakDtNull() Then
      '  validateRow.SetColumnError("BreakDt", "Ad date cannot be blank.")
      '  areAllValid = False
      'End If

      'If validateRow.IsNull("EnvelopeId") Then
      '  validateRow.SetColumnError("EnvelopeId", "Envelope is missing.")
      'Else
      '  validateRow.SetColumnError("EnvelopeId", "")
      'End If

      'If validateRow.IsNull("BreakDt") Then
      '  validateRow.SetColumnError("BreakDt", "Ad date is not specified.")
      'Else
      '  validateRow.SetColumnError("BreakDt", "")
      'End If

      'If validateRow.IsNull("RetId") Then
      '  validateRow.SetColumnError("RetId", "Retailer is not specified.")
      'Else
      '  validateRow.SetColumnError("RetId", "")
      'End If

      'If validateRow.IsNull("MktId") Then
      '  validateRow.SetColumnError("MktId", "Market is not specified.")
      'Else
      '  validateRow.SetColumnError("MktId", "")
      'End If

      'If validateRow.IsNull("MediaId") Then
      '  validateRow.SetColumnError("MediaId", "Media is not specified.")
      'Else
      '  validateRow.SetColumnError("MediaId", "")
      'End If


      If areAllValid Then areAllValid = AreDatesValid(validateRow)


      RaiseEvent InputsValidated()

      Return areAllValid

    End Function


#End Region


    ''' <summary>
    ''' Synchronizes changes made to vwCircular DataTable with database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub SynchronizeVehicleInformation()

      RaiseEvent SynchronizingVehicleInformation()

      VehicleAdapter.Update(Data.vwCircular)

      RaiseEvent VehicleInformationSynchronized()

    End Sub

    ''' <summary>
    ''' Synchronizes changes made to vwCircular DataTable with database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Overloads Sub SynchronizeVehicleInformation(ByVal tempRow As QCDataSet.vwCircularRow)
      Dim entryInd As Byte?
            Dim checkinPageCount, familyId, indexedById, parentVehicleId, CheckInOccurrences As Integer?
      Dim startDt, endDt, distDt As DateTime?

            Dim pageAdapter As QCDataSetTableAdapters.vwCircularTableAdapter
            pageAdapter = New QCDataSetTableAdapters.vwCircularTableAdapter
            pageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()


      RaiseEvent SynchronizingVehicleInformation()

      If tempRow.IsStartDtNull() = False Then startDt = tempRow.StartDt
      If tempRow.IsEndDtNull() = False Then endDt = tempRow.EndDt
      If tempRow.IsDistDtNull() = False Then distDt = tempRow.DistDt
      If tempRow.IsCheckInPageCountNull() = False Then checkinPageCount = tempRow.CheckInPageCount
      If tempRow.IsFamilyIdNull() = False Then familyId = tempRow.FamilyId
      If tempRow.IsIndexedByIdNull() = False Then indexedById = tempRow.IndexedById
            If tempRow.IsEntryIndNull() = False Then entryInd = tempRow.EntryInd
            If tempRow.IsCheckInOccurrencesNull() = False Then CheckInOccurrences = tempRow.CheckInOccurrences
            If tempRow.IsParentVehicleIdNull() = False Then parentVehicleId = tempRow.ParentVehicleId

            If IsVehicleQced(tempRow.VehicleId) Then
        VehicleAdapter.UpdateReIndexedVehicle(tempRow.RetId, tempRow.MktId, tempRow.BreakDt, startDt, endDt, tempRow.LanguageId, tempRow.EventId, tempRow.ThemeId, tempRow.MediaId, tempRow.PublicationId, tempRow.FlashInd, familyId, tempRow.CouponInd, tempRow.Priority, checkinPageCount, tempRow.CheckInOccurrences, pageAdapter.GetQCCompletedStatus(), tempRow.FormName, indexedById, tempRow.NationalInd, entryInd, parentVehicleId, distDt, tempRow.VehicleId)
            Else
                VehicleAdapter.UpdateIndexedVehicle(tempRow.RetId, tempRow.MktId, tempRow.BreakDt, startDt, endDt, tempRow.LanguageId, tempRow.EventId, tempRow.ThemeId, tempRow.MediaId, tempRow.PublicationId, tempRow.FlashInd, familyId, tempRow.CouponInd, tempRow.Priority, checkinPageCount, CheckInOccurrences, tempRow.StatusID, tempRow.FormName, indexedById, tempRow.NationalInd, entryInd, parentVehicleId, tempRow.DistDt, tempRow.VehicleId)
            End If


            RaiseEvent VehicleInformationSynchronized()

        End Sub
        Public Overloads Function IsVehicleQced(ByVal vehicleId As Integer) As Boolean
            'Dim isQCed As Boolean
            'Dim qcStatusId As Integer
            'Dim vehicleQuery As System.Collections.Generic.IEnumerable(Of QCDataSet.vwCircularRow)

            '' qcStatusId = 
            'vehicleQuery = From vr In Data.vwCircular.Rows.Cast(Of QCDataSet.vwCircularRow)() _
            '               Select vr _
            '               Where vr.VehicleId = vehicleId

            'If vehicleQuery.Count = 0 Then
            '    vehicleQuery = Nothing
            '    Throw New System.ApplicationException("Vehicle information not found.")
            'Else
            '    isQCed = IsVehicleQced(vehicleQuery(0))
            'End If

            'vehicleQuery = Nothing

            'Return isQCed
            Dim pageCount As Nullable(Of Integer)
            Dim pageAdapter As QCDataSetTableAdapters.vwCircularTableAdapter


            pageAdapter = New QCDataSetTableAdapters.vwCircularTableAdapter
            pageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            pageCount = CType(pageAdapter.IsVehicleQced(vehicleId), Integer?)
            pageAdapter.Dispose()
            pageAdapter = Nothing

            If (pageCount Is Nothing OrElse pageCount = 0) Then
                Return False
            Else
                Return True
            End If

        End Function

        Public Overloads Sub AutoQCProcess(ByVal _yearmonth As String, ByVal _namegenfield As String, Optional ByVal _vehicleid As Integer = 0)
            Dim obj As Object
            Dim val As Integer
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim cn As System.Data.SqlClient.SqlConnection

            cn = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
            cmd = New System.Data.SqlClient.SqlCommand

            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = "mt_proc_AutoQC"

            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ImagePath", SqlDbType.NVarChar, 100))
            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ImageNameGenField", SqlDbType.NVarChar, 100))
            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ParamVehicleId", SqlDbType.Int))
            cmd.Parameters.Add(New System.Data.SqlClient.SqlParameter("@QCResult", SqlDbType.Int))

            cmd.Parameters(0).Value = GetImagePath(_yearmonth, GetPathType("Master"))
            cmd.Parameters(1).Value = _namegenfield
            cmd.Parameters(2).Value = _vehicleid
            cmd.Parameters(3).Direction = ParameterDirection.Output

            cmd.ExecuteNonQuery()

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

        End Sub

        Public Function ValidateIfVehicleHasBeenQCed(ByVal _Vehicleid As String) As Object
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "Select count(*) from Vehicle where vehicleid = '" + _Vehicleid + "' AND StatusId = 22"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With

                If CType(obj, Integer) = 0 Then
                    obj = 0
                End If
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return obj
        End Function

        Public Function GetImagePath(ByVal YearMonth As String, ByVal PathType As Integer) As String
            Dim imgPathCommand As System.Data.SqlClient.SqlCommand
            Dim obj As Object
            Dim Path As System.Text.StringBuilder


            imgPathCommand = New System.Data.SqlClient.SqlCommand
            Path = New System.Text.StringBuilder

            Try
                With imgPathCommand
                    .CommandText = "SELECT path FROM ImagePath WHERE yearmonth=" + YearMonth + " AND LocationId=" & CDbl(UserLocationId) & " AND PathTypeid=" + PathType.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With

                Path.Append(CType(obj, String))

            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If imgPathCommand.Connection.State <> ConnectionState.Closed Then imgPathCommand.Connection.Close()
            End Try

            Return Path.ToString()
        End Function

        Public Function GetPathType(ByVal _Type As String) As Integer
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As New Object
            Dim _val As Integer

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "Select codeid from vwCode where codedescrip='" + _Type + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With
                If String.IsNullOrEmpty(CType(obj, String)) = False Then _val = CType(obj, Integer)
            Catch ex As Exception
                'Throw New ApplicationException("Unable to get the Path Type Id.", ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return _val
        End Function

    ''' <summary>
    ''' Returns true if vehicle status is set to indexed, false otherwise.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function IsVehicleIndexed(ByVal vehicleId As Integer) As Boolean
            Dim isIndexed As Boolean
            Dim indexedStatusId As Integer
            Dim vehicleQuery As System.Collections.Generic.IEnumerable(Of QCDataSet.vwCircularRow)


            indexedStatusId = GetStatusIdForIndexed()
            vehicleQuery = From vr In Data.vwCircular.Rows.Cast(Of QCDataSet.vwCircularRow)() _
                           Select vr _
                           Where vr.VehicleId = vehicleId

            If vehicleQuery.Count = 0 Then
                vehicleQuery = Nothing
                Throw New System.ApplicationException("Vehicle information not found.")
            Else
                isIndexed = IsVehicleIndexed(vehicleQuery(0))
            End If

            vehicleQuery = Nothing

            Return isIndexed


    End Function

    ''' <summary>
    ''' Deletes vehicle from database.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
        'Public Sub Delete(ByVal vehicleId As Integer)
        '  Dim rowsAffected As Integer
        '  Dim deleteQuery As System.Data.EnumerableRowCollection(Of QCDataSet.vwCircularRow)


        '  Using e As MCAP.UI.Processors.CancellableEventArgs = New MCAP.UI.Processors.CancellableEventArgs()
        '    e.Data.Add("VehicleId", vehicleId)

        '    RaiseEvent DeletingVehicle(Me, e)
        '    If e.Cancel Then
        '      Exit Sub
        '    End If
        '  End Using

        '  deleteQuery = From row In Data.vwCircular _
        '                Where row.VehicleId = vehicleId _
        '                Select row

        '  If deleteQuery.Count() > 0 Then
        '    deleteQuery(0).Delete()
        '    rowsAffected = VehicleAdapter.Update(Data.vwCircular)
        '  End If

        '  deleteQuery = Nothing

        '  Using e As MCAP.UI.Processors.EventArgs = New MCAP.UI.Processors.EventArgs()
        '    e.Data.Add("RowsAffected", rowsAffected)
        '    e.Data.Add("VehicleId", vehicleId)
        '    RaiseEvent VehicleDeleted(Me, e)
        '  End Using

        'End Sub

        Public Sub Delete(ByVal vehicleId As Integer)
            Dim rowsAffected As Integer
            Dim deleteQuery As System.Data.EnumerableRowCollection(Of QCDataSet.vwCircularRow)

            Dim cn As System.Data.SqlClient.SqlConnection

            cn = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())

            cn.Open()

            VehicleAdapter.Adapter.DeleteCommand.Connection = cn

            Using e As MCAP.UI.Processors.CancellableEventArgs = New MCAP.UI.Processors.CancellableEventArgs()
                e.Data.Add("VehicleId", vehicleId)

                RaiseEvent DeletingVehicle(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            VehicleAdapter.Adapter.DeleteCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@VehicleId", SqlDbType.Int))
            VehicleAdapter.Adapter.DeleteCommand.Parameters(0).Value = vehicleId

            VehicleAdapter.Adapter.DeleteCommand.ExecuteReader()

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

            Using e As MCAP.UI.Processors.EventArgs = New MCAP.UI.Processors.EventArgs()
                e.Data.Add("RowsAffected", rowsAffected)
                e.Data.Add("VehicleId", vehicleId)
                RaiseEvent VehicleDeleted(Me, e)
            End Using

        End Sub


  End Class


End Namespace