Namespace UI.Processors


  Public Class EnvelopeContent
    Inherits BaseClass



#Region " Events "


    Public Event Initializing() 'As MCAPCancellableEventHandler
    Public Event Initialized() 'As MCAPEventHandler

    'Public Event LoadingEnvelopeSender(ByVal envelopeId As Integer)
    'Public Event EnvelopeSenderLoaded(ByVal envelopeId As Integer, ByVal envelopeRow As EnvelopeContentDataSet.EnvelopeSenderRow)
    'Public Event EnvelopeSenderNotFound(ByVal envelopeId As Integer)
    Public Event LoadingEnvelopeSender As MCAPCancellableEventHandler
    Public Event EnvelopeSenderLoaded As MCAPEventHandler
    Public Event EnvelopeSenderNotFound As MCAPEventHandler

    Public Event LoadingMarkets As MCAPCancellableEventHandler
    Public Event MarketsLoaded As MCAPEventHandler

    Public Event LoadingRetailers As MCAPCancellableEventHandler
    Public Event RetailersLoaded As MCAPEventHandler

    Public Event LoadingExpectedRetailers As MCAPCancellableEventHandler
    Public Event ExpectedRetailersLoaded As MCAPEventHandler

    Public Event LoadingPublications As MCAPCancellableEventHandler
    Public Event PublicationsLoaded As MCAPEventHandler

    Public Event ValidatingColumnValues As MCAPCancellableEventHandler
    Public Event ColumnValuesValidated As MCAPEventHandler
    'Public Event InvalidInputExist(ByVal errors As EnvelopeContentDataSet.ErrorsDataTable, ByVal warnings As EnvelopeContentDataSet.WarningsDataTable)
    Public Event InvalidColumnValueFound As MCAPEventHandler

    Public Event NoChangesToSynchronize As MCAPEventHandler
    Public Event Synchronizing As MCAPCancellableEventHandler
    Public Event Synchronized As MCAPEventHandler

    'Public Event LoadingVehicle(ByVal vehicleId As Integer)
    'Public Event VehicleLoaded(ByVal vehicleRow As EnvelopeContentDataSet.vwCircularRow)
    'Public Event VehicleNotFound(ByVal vehicleId As Integer)
    'Public Event InvalidVehicleStatus(ByVal statusText As String)
    Public Event LoadingVehicle As MCAPCancellableEventHandler
    Public Event VehicleLoaded As MCAPEventHandler
    Public Event VehicleNotFound As MCAPEventHandler
    Public Event InvalidVehicleStatus As MCAPEventHandler

    Public Event DeletingVehicle As MCAPCancellableEventHandler
    Public Event VehicleDeleted As MCAPEventHandler

    Public Event PrintingBarcode As MCAPCancellableEventHandler
    Public Event BarcodePrinted As MCAPEventHandler


#End Region



    Private m_barcodePrinter As String
    Private m_languageAdapter As EnvelopeContentDataSetTableAdapters.LanguageTableAdapter
    Private m_marketAdapter As EnvelopeContentDataSetTableAdapters.MktTableAdapter
    Private m_mediaAdapter As EnvelopeContentDataSetTableAdapters.MediaTableAdapter
    Private m_senderAdapter As EnvelopeContentDataSetTableAdapters.EnvelopeSenderTableAdapter
    Private m_retailerAdapter As EnvelopeContentDataSetTableAdapters.RetTableAdapter
    Private m_expectedRetailerAdapter As EnvelopeContentDataSetTableAdapters.vwExpectedRetTableAdapter
    Private m_publicationAdapter As EnvelopeContentDataSetTableAdapters.PublicationTableAdapter
    Private m_vehicleAdapter As EnvelopeContentDataSetTableAdapters.vwCircularTableAdapter
    Private m_tradeclassAdapter As EnvelopeContentDataSetTableAdapters.TradeClassTableAdapter
    Private m_vehicleStatusAdapter As EnvelopeContentDataSetTableAdapters.VehicleStatusTableAdapter
        Private m_envelopeContentDataSet As EnvelopeContentDataSet
        Public counter As Integer = 0
        Public m_FilterBySenderExpectation As Boolean
        'Sender Association
        Private _Sender As Integer
        Public _tempId As Integer
        Public SenderComment As String
        Public isNewRetailer As Boolean = False
        Public newRetailerName As String

    ''' <summary>
    ''' Gets table adapter for Language table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property LanguageAdapter() As EnvelopeContentDataSetTableAdapters.LanguageTableAdapter
      Get
        Return m_languageAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets table adapter for Sender table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property SenderAdapter() As EnvelopeContentDataSetTableAdapters.EnvelopeSenderTableAdapter
      Get
        Return m_senderAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets table adapter for Mkt table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property MarketAdapter() As EnvelopeContentDataSetTableAdapters.MktTableAdapter
      Get
        Return m_marketAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets table adapter for Media table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property MediaAdapter() As EnvelopeContentDataSetTableAdapters.MediaTableAdapter
      Get
        Return m_mediaAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets table adapter for Ret table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property RetailerAdapter() As EnvelopeContentDataSetTableAdapters.RetTableAdapter
      Get
        Return m_retailerAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets table adapter for Expecttion-Ret table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property ExpectedRetailerAdapter() As EnvelopeContentDataSetTableAdapters.vwExpectedRetTableAdapter
      Get
        Return m_expectedRetailerAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets table adapter for Publication table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property PublicationAdapter() As EnvelopeContentDataSetTableAdapters.PublicationTableAdapter
      Get
        Return m_publicationAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets table adapter for Vehicle table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property VehicleAdapter() As EnvelopeContentDataSetTableAdapters.vwCircularTableAdapter
      Get
        Return m_vehicleAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets table adapter for TradeClass table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property TradeclassAdapter() As EnvelopeContentDataSetTableAdapters.TradeClassTableAdapter
      Get
        Return m_tradeclassAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets table adapter for Code table, for Vehicle Status value.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property VehicleStatusAdapter() As EnvelopeContentDataSetTableAdapters.VehicleStatusTableAdapter
      Get
        Return m_vehicleStatusAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets dataset containing tables related Envelope Content Check-In process.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Data() As EnvelopeContentDataSet
      Get
        Return m_envelopeContentDataSet
      End Get
    End Property



    ''' <summary>
    ''' Default constructor.
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()

      m_barcodePrinter = String.Empty
      m_languageAdapter = New EnvelopeContentDataSetTableAdapters.LanguageTableAdapter
      m_senderAdapter = New EnvelopeContentDataSetTableAdapters.EnvelopeSenderTableAdapter
      m_marketAdapter = New EnvelopeContentDataSetTableAdapters.MktTableAdapter
      m_mediaAdapter = New EnvelopeContentDataSetTableAdapters.MediaTableAdapter
      m_retailerAdapter = New EnvelopeContentDataSetTableAdapters.RetTableAdapter
      m_expectedRetailerAdapter = New EnvelopeContentDataSetTableAdapters.vwExpectedRetTableAdapter
      m_publicationAdapter = New EnvelopeContentDataSetTableAdapters.PublicationTableAdapter
      m_vehicleAdapter = New EnvelopeContentDataSetTableAdapters.vwCircularTableAdapter
      m_tradeclassAdapter = New EnvelopeContentDataSetTableAdapters.TradeClassTableAdapter
      m_vehicleStatusAdapter = New EnvelopeContentDataSetTableAdapters.VehicleStatusTableAdapter
      m_envelopeContentDataSet = New EnvelopeContentDataSet

    End Sub



    ''' <summary>
    ''' Initializes object of this class.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize()

      RaiseEvent Initializing()

      LanguageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      SenderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      MarketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      MediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      RetailerAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      ExpectedRetailerAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      PublicationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      VehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      TradeclassAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            VehicleStatusAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()


      RaiseEvent Initialized()

    End Sub


    ''' <summary>
    ''' Prints barcode label for Vehicle.
    ''' </summary>
    ''' <param name="barcodeRow">Information, about vehicle, to be printed on barcode label.</param>
    ''' <remarks></remarks>
    Public Sub PrintBarcode(ByVal barcodeRow As EnvelopeContentDataSet.vwCircularRow)
      Dim scanDPI As Integer
      Dim labelPrint As MCAP.VehicleLabelPrint


      labelPrint = New MCAP.VehicleLabelPrint()

      scanDPI = GetScanDPI(barcodeRow.RetId, barcodeRow.MktId, barcodeRow.MediaId)

      labelPrint.PrinterName = BarcodePrinterName
      labelPrint.AdDate = barcodeRow.BreakDt
      labelPrint.CreatedBy = GetUserInformation(barcodeRow.CreatedById).ShortName.ToString()
      labelPrint.Market = barcodeRow.MktRow.Descrip.ToString()
      labelPrint.Priority = barcodeRow.Priority
      labelPrint.Retailer = barcodeRow.RetRow.Descrip.ToString()
      labelPrint.ScanDPI = scanDPI
      labelPrint.VehicleId = barcodeRow.VehicleId

      labelPrint.Print()

      labelPrint.Dispose()
      labelPrint = Nothing
    End Sub

    ''' <summary>
    ''' Prints barcode label for new retailer.
    ''' </summary>
    ''' <param name="envelopeId"></param>
    ''' <param name="envelopeSender"></param>
    ''' <param name="retailerName"></param>
    ''' <remarks></remarks>
    Public Sub PrintBarcodeForNewRetailer(ByVal envelopeId As Integer, ByVal envelopeSender As String, ByVal retailerName As String)
      Dim labelPrint As MCAP.EnvelopeLabelPrint


      labelPrint = New MCAP.EnvelopeLabelPrint()

      labelPrint.PrinterName = BarcodePrinterName
      labelPrint.EnvelopeId = envelopeId
      labelPrint.SenderName = envelopeSender
      labelPrint.Comment = "New Ret"
      If retailerName IsNot Nothing Then labelPrint.Comment += ": " + retailerName

      labelPrint.Print()

      labelPrint.Dispose()
      labelPrint = Nothing
    End Sub

        Public Sub LoadDataSet(Optional ByVal hasVehicle As Boolean = False)

            LanguageAdapter.Fill(Data.Language)
            'MediaAdapter.Fill(Data.Media)
            If _Sender = 0 Then _Sender = _tempId
            MediaAdapter.FillBySenderExpectation(Data.Media, _Sender)
            If Data.Media.Rows.Count = 0 Or hasVehicle Then
                MediaAdapter.Fill(Data.Media)
                m_FilterBySenderExpectation = False
                'RetailerAdapter.Fill(Data.Ret)
            Else
                m_FilterBySenderExpectation = True
            End If
            'TradeclassId is foreignkey in Ret table, TradeClass DataTable has to be filled first.
            TradeclassAdapter.Fill(Data.TradeClass)
            VehicleStatusAdapter.Fill(Data.VehicleStatus)


        End Sub


        Public Sub EnableDisableFilter(ByVal En As Boolean, ByVal envID As Integer)
            If En = True Then
                MediaAdapter.Fill(Data.Media)
                'MarketAdapter.FillAllData(Data.Mkt)
                'RetailerAdapter.Fill(Data.Ret)
            Else
                LoadDataSet()
                Data.Ret.Clear()
            End If
        End Sub
    ''' <summary>
    ''' Gets boolean flag indicating whether the supplied userId is assigned a 
    ''' supervisor or an administrator role or not.
    ''' </summary>
    ''' <param name="UserID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsUserSupervisorOrAdministrator(ByVal UserID As Integer) As Boolean
      Dim userCount As Integer?
      Dim tempAdapter As MCAP.EnvelopeContentDataSetTableAdapters.UserTableAdapter


      tempAdapter = New MCAP.EnvelopeContentDataSetTableAdapters.UserTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      userCount = tempAdapter.IsUserSupervisorOrAdmin(UserID)
      tempAdapter.Dispose()
      tempAdapter = Nothing

      If userCount.HasValue AndAlso userCount.Value > 0 Then
        userCount = Nothing
        Return True
      Else
        userCount = Nothing
        Return False
      End If

    End Function

    ''' <summary>
    ''' Returns true if retailer is an expected retailer, false otherwise.
    ''' </summary>
    ''' <param name="retailerId"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' ASSUMPTION: At any point of time, vwExpected datatable contains rows for media and market, 
    ''' selected on screen.
    ''' </remarks>
    Public Function IsRetailerExpectedRetailer(ByVal retailerId As Integer) As Boolean
      Dim isRequired As Boolean
      Dim requiredQuery As System.Collections.Generic.IEnumerable(Of EnvelopeContentDataSet.vwExpectedRetRow)


      requiredQuery = From retRow In Data.vwExpectedRet Where retRow.RetId = retailerId
      If requiredQuery.Count > 0 Then isRequired = True

      requiredQuery = Nothing

      Return isRequired
    End Function

    ''' <summary>
    ''' Gets boolean value indicating whether supplied retailer and market are valid, for flash ads, or not.
    ''' </summary>
    ''' <param name="retailerId"></param>
    ''' <param name="marketId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsValidFlashRetMkt(ByVal retailerId As Integer, ByVal marketId As Integer) As Boolean
      Dim count As Object
      Dim tempAdapter As EnvelopeContentDataSetTableAdapters.RetTableAdapter


      tempAdapter = New EnvelopeContentDataSetTableAdapters.RetTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      count = tempAdapter.IsRetailerMarketValidForFlash(retailerId, marketId)
      tempAdapter.Dispose()
      tempAdapter = Nothing

      Return Not (count Is Nothing OrElse count Is DBNull.Value OrElse count.ToString() = "0")
        End Function

        Public Function IsValidSenderExpectationID(ByVal ExpectationID As Integer) As Boolean
            Dim count As Object
            Dim tempAdapter As EnvelopeContentDataSetTableAdapters.SenderExpectationTableAdapter


            tempAdapter = New EnvelopeContentDataSetTableAdapters.SenderExpectationTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            count = tempAdapter.GetValdExpectationID(ExpectationID)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            Return Not (count Is Nothing OrElse count Is DBNull.Value OrElse count.ToString() = "0")
        End Function


        Public Function IsBackupSender(ByVal ExpectationID As Integer, ByVal senderId As Integer) As Boolean
            'Dim Sender As Boolean = True
            'Dim expectedQuery As System.Collections.Generic.IEnumerable(Of EnvelopeContentDataSet.SenderExpectationRow)


            'expectedQuery = From retRow In Data.SenderExpectation Where retRow.ExpectationID = ExpectationID And retRow.SenderId = senderId
            'If expectedQuery.Count() > 0 Then
            '    Sender = False
            'End If

            'Return Sender

            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand
            con = New System.Data.SqlClient.SqlConnection

            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()

            cmd.Connection = con

            cmd.CommandType = CommandType.Text

            cmd.CommandText = "Select count(se.expectationid) FROM senderExpectation se inner join Expectation E on se.expectationid=E.Expectationid WHERE E.EndDt is null and se.expectationid =" + ExpectationID.ToString + " and se.senderid=" + senderId.ToString

            obj = cmd.ExecuteScalar

            If IsDBNull(obj) Then obj = 0

            If CType(obj, Integer) > 0 Then
                IsBackupSender = False
            ElseIf CType(obj, Integer) = 0 Then
                IsBackupSender = True
            End If

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing


        End Function

        Public Function isUnregisteredRetMktMedia(ByVal mediaid As Integer, ByVal mktid As Integer, ByVal retid As Integer) As Boolean
            Dim isValid As Boolean = False

            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim reader As System.Data.SqlClient.SqlDataReader
            Dim obj As Object
            Dim val As Boolean

            Try
                con = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                cmd = New System.Data.SqlClient.SqlCommand
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "mt_proc_GetUnRegisteredRetMktMedia"

                cmd.Parameters.AddWithValue("@retid", retid)
                cmd.Parameters.AddWithValue("@mktid", mktid)
                cmd.Parameters.AddWithValue("@mediaid", mediaid)
                cmd.Parameters.Add("@isvalid", SqlDbType.Bit).Direction = ParameterDirection.Output

                obj = cmd.ExecuteScalar()

                val = CType(obj, Boolean)
                If val = True Then
                    isValid = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return isValid
        End Function

        Public Function isUnregisteredRetMkt(ByVal mktid As Integer, ByVal retid As Integer) As Boolean
            Dim isValid As Boolean = False

            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim reader As System.Data.SqlClient.SqlDataReader
            Dim obj As Object
            Dim val As Boolean

            Try
                con = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                cmd = New System.Data.SqlClient.SqlCommand
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "mt_proc_GetUnRegisteredRetMkt"
                cmd.Parameters.AddWithValue("@retid", retid)
                cmd.Parameters.AddWithValue("@mktid", mktid)
                cmd.Parameters.Add("@isvalid", SqlDbType.Bit).Direction = ParameterDirection.Output

                obj = cmd.ExecuteScalar()

                val = CType(obj, Boolean)
                If val = True Then
                    isValid = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return isValid
        End Function
        Public Function isUnregisteredRetMktExists(ByVal MediaId As Integer, ByVal mktid As Integer, ByVal retid As Integer) As Boolean
            Dim isValid As Boolean = False

            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim reader As System.Data.SqlClient.SqlDataReader
            Dim obj As Object
            Dim val As Boolean

            Try
                con = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                cmd = New System.Data.SqlClient.SqlCommand
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "mt_proc_GetUnRegisteredRetMktExists"
                cmd.Parameters.AddWithValue("@mediaid", MediaId)
                cmd.Parameters.AddWithValue("@retid", retid)
                cmd.Parameters.AddWithValue("@mktid", mktid)
                cmd.Parameters.Add("@isvalid", SqlDbType.Bit).Direction = ParameterDirection.Output

                obj = cmd.ExecuteScalar()

                val = CType(obj, Boolean)
                If val = True Then
                    isValid = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return isValid
        End Function

        Public Function isUnregisteredRetMktMediaExists(ByVal MediaId As Integer, ByVal mktid As Integer, ByVal retid As Integer) As Boolean
            Dim isValid As Boolean = False

            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim reader As System.Data.SqlClient.SqlDataReader
            Dim obj As Object
            Dim val As Boolean

            Try
                con = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                cmd = New System.Data.SqlClient.SqlCommand
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "mt_proc_GetUnRegisteredRetMktMediaExists"
                cmd.Parameters.AddWithValue("@mediaid", MediaId)
                cmd.Parameters.AddWithValue("@retid", retid)
                cmd.Parameters.AddWithValue("@mktid", mktid)
                cmd.Parameters.Add("@isvalid", SqlDbType.Bit).Direction = ParameterDirection.Output

                obj = cmd.ExecuteScalar()

                val = CType(obj, Boolean)
                If val = True Then
                    isValid = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return isValid
        End Function


        Public Function isRequiredRetailers(ByVal senderid As Integer, ByVal mediaid As Integer, ByVal mktid As Integer, ByVal retid As Integer) As Boolean
            Dim isValid As Boolean = False

            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim reader As System.Data.SqlClient.SqlDataReader
            Dim obj As Object
            Dim val As Boolean

            Try
                con = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                cmd = New System.Data.SqlClient.SqlCommand
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "mt_proc_isRequiredRetailer"
                cmd.Parameters.AddWithValue("@Senderid", senderid)
                cmd.Parameters.AddWithValue("@retid", retid)
                cmd.Parameters.AddWithValue("@mktid", mktid)
                cmd.Parameters.AddWithValue("@mediaid", mediaid)
                cmd.Parameters.Add("@isvalid", SqlDbType.Bit).Direction = ParameterDirection.Output

                obj = cmd.ExecuteScalar()

                val = CType(obj, Boolean)
                If val = True Then
                    isValid = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return isValid
        End Function

        Public Function IsUnregisteredRetailer(ByVal retid As Integer) As Boolean
            Dim count As Object
            Dim tempAdapter As ReportsDataSetTableAdapters.UnregisteredRetTableAdapter


            tempAdapter = New ReportsDataSetTableAdapters.UnregisteredRetTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            count = tempAdapter.isUnregisteredRetailer(retid)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            Return Not (count Is Nothing OrElse count Is DBNull.Value OrElse count.ToString() = "0")
        End Function

    ''' <summary>
    ''' Gets boolean value indicating whether supplied retailer and market are valid, for flash ads, or not.
    ''' </summary>
    ''' <param name="retailerId"></param>
    ''' <param name="marketId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsValidFlashNational(ByVal retailerId As Integer) As Boolean
      Dim count As Object
      Dim tempAdapter As EnvelopeContentDataSetTableAdapters.RetTableAdapter


      tempAdapter = New EnvelopeContentDataSetTableAdapters.RetTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      count = tempAdapter.IsRetailerValidForNational(retailerId)
      tempAdapter.Dispose()
      tempAdapter = Nothing

      Return Not (count Is Nothing OrElse count Is DBNull.Value OrElse count.ToString() = "0")
    End Function

    ''' <summary>
    ''' Gets comments for retailer in expectation table, fetched from an in-memory datatable.
    ''' </summary>
    ''' <param name="retailerId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCommentForExpectedRetailer(ByVal retailerId As Integer) As String
      Dim comments As String
      Dim expectedQuery As System.Collections.Generic.IEnumerable(Of EnvelopeContentDataSet.vwExpectedRetRow)


      expectedQuery = From retRow In Data.vwExpectedRet Where retRow.RetId = retailerId
      If expectedQuery.Count() > 0 AndAlso expectedQuery(0).IsCommentsNull() = False Then
        comments = expectedQuery(0).Comments
      End If

      Return comments

        End Function

        Public Function getTempRetailer(ByVal vehicleId As Integer) As String
            Dim descrip As String
            Dim expectedQuery As System.Collections.Generic.IEnumerable(Of EnvelopeContentDataSet.TempRetRow)

            expectedQuery = From retRow In Data.TempRet Where retRow.VehicleID = vehicleId
            If expectedQuery.Count() > 0 AndAlso expectedQuery(0).IsDescripNull = False Then
                descrip = expectedQuery(0).Descrip
            End If

            Return descrip
        End Function

        Private Sub LoadTempRetDataSet()

            Dim tempAdapter As EnvelopeContentDataSetTableAdapters.TempRetTableAdapter
            Dim tempRow As BypassVehicleDataSet.vwLocationRow

            tempAdapter = New EnvelopeContentDataSetTableAdapters.TempRetTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(Data.TempRet)
            tempAdapter.Dispose()
            tempAdapter = Nothing


        End Sub

        Public Sub LoadTempRetailer(ByVal VehicleId As Integer)
            LoadTempRetDataSet()
            Dim tempAdapter As EnvelopeContentDataSetTableAdapters.RetTableAdapter()
            Dim tempRow As EnvelopeContentDataSet.RetRow


            tempRow = Data.Ret.NewRetRow
            tempRow.RetId = 0
            tempRow.Descrip = getTempRetailer(VehicleId)
            Data.Ret.AddRetRow(tempRow)
            tempRow = Nothing


        End Sub

        ''' <summary>
        ''' Gets priority for retailer in expectation table, fetched from an in-memory datatable.
        ''' </summary>
        ''' <param name="retailerId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPriorityForExpectedRetailer(ByVal retailerId As Integer) As Integer?
            Dim priority As Integer?
            Dim expectedQuery As System.Collections.Generic.IEnumerable(Of EnvelopeContentDataSet.vwExpectedRetRow)

            expectedQuery = From retRow In Data.vwExpectedRet Where retRow.RetId = retailerId
            If expectedQuery.Count() > 0 AndAlso expectedQuery(0).IsPriorityNull() = False Then
                priority = expectedQuery(0).Priority
            End If

            Return priority

        End Function

        ''' <summary>
        ''' Gets tradeclass for retailer, fetched from an in-memory datatable.
        ''' </summary>
        ''' <param name="retailerId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTradeclassOfRetailer(ByVal retailerId As Integer) As String
            Dim tradeclass As String
            Dim retailerQuery As System.Collections.Generic.IEnumerable(Of EnvelopeContentDataSet.RetRow)


            retailerQuery = From retRow In Data.Ret Where retRow.RetId = retailerId
            If retailerQuery.Count() > 0 AndAlso retailerQuery(0).TradeClassRow IsNot Nothing Then
                tradeclass = retailerQuery(0).TradeClassRow.Descrip
            End If

            Return tradeclass

        End Function

        ''' <summary>
        ''' Gets languageId for retailer, fetched from an in-memory datatable.
        ''' </summary>
        ''' <param name="retailerId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDefaultLanguageIdForRetailer(ByVal retailerId As Integer) As Integer?
            Dim languageId As Integer?
            Dim retailerQuery As System.Collections.Generic.IEnumerable(Of EnvelopeContentDataSet.RetRow)


            retailerQuery = From retRow In Data.Ret Where retRow.RetId = retailerId
            If retailerQuery.Count() > 0 AndAlso retailerQuery(0).IsLanguageIdNull() = False Then
                languageId = retailerQuery(0).LanguageId
            End If

            Return languageId

        End Function

        ''' <summary>
        ''' Returns status id for supplied status text.
        ''' </summary>
        ''' <param name="statusText"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetStatusIdFor(ByVal statusText As String) As Integer
            Dim statusId As Integer
            Dim linqQuery As System.Collections.Generic.IEnumerable(Of EnvelopeContentDataSet.VehicleStatusRow)


            linqQuery = From vsr In Data.VehicleStatus.Cast(Of EnvelopeContentDataSet.VehicleStatusRow)() _
                        Select vsr _
                        Where vsr.Descrip = statusText

            If linqQuery.Count < 1 Then
                statusId = -1
            Else
                statusId = linqQuery(0).CodeId
            End If

            linqQuery = Nothing

            Return statusId

        End Function

        ''' <summary>
        ''' Gets status id for retailers not required status.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetStatusIdForRetailerNotRequired() As Integer
            Dim statusId As Integer

            statusId = GetStatusIdFor("Not Required")

            Return statusId

        End Function

        Private Function GetStatusIdForBackupSender() As Integer
            Dim statusId As Integer


            statusId = GetStatusIdFor("Backup Sender")

            Return statusId

        End Function

        Public Function GetStatusIdForUnregisteredRetailer() As Integer
            Dim statusId As Integer


            statusId = GetStatusIdFor("Unregistered Retailer")

            Return statusId

        End Function

        Private Function GetStatusIdForUnregisteredRetMkt() As Integer
            Dim statusId As Integer


            statusId = GetStatusIdFor("Unregistered RetMkt")

            Return statusId

        End Function
        Private Function GetStatusIdForUnregisteredRetMktMedia() As Integer
            Dim statusId As Integer


            statusId = GetStatusIdFor("Unregistered RetMktMedia")

            Return statusId

        End Function

        Public Function GetStatusIdForNewRetailer() As Integer
            Dim statusId As Integer


            statusId = GetStatusIdFor("New Retailer")

            Return statusId

        End Function

        ''' <summary>
        ''' Gets boolean flag, indicating whether supplied vehicle is having status of Not Required or not.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsVehicleNotRequired(ByVal vehicleId As Integer) As Boolean
            Dim status As Boolean
            Dim statusInfo As System.Collections.Generic.IEnumerable(Of EnvelopeContentDataSet.VehicleStatusRow)


            statusInfo = From s In Data.VehicleStatus _
                         Join v In Data.vwCircular On s.CodeId Equals v.StatusID _
                         Where s.Descrip = "Not Required" _
                         Select s

            If statusInfo.Count() < 1 Then
                status = False
            Else
                status = True
            End If

            statusInfo = Nothing

            Return status

        End Function

        Public Function IsVehicleBypassSender(ByVal vehicleId As Integer) As Boolean
            Dim status As Boolean
            Dim statusInfo As System.Collections.Generic.IEnumerable(Of EnvelopeContentDataSet.VehicleStatusRow)


            statusInfo = From s In Data.VehicleStatus _
                         Join v In Data.vwCircular On s.CodeId Equals v.StatusID _
                         Where s.Descrip = "Bypass Sender" _
                         Select s

            If statusInfo.Count() < 1 Then
                status = False
            Else
                status = True
            End If

            statusInfo = Nothing

            Return status

        End Function

        Public Function IsVehicleUnregisteredRetMkt(ByVal vehicleId As Integer) As Boolean
            Dim status As Boolean
            Dim statusInfo As System.Collections.Generic.IEnumerable(Of EnvelopeContentDataSet.VehicleStatusRow)


            statusInfo = From s In Data.VehicleStatus _
                         Join v In Data.vwCircular On s.CodeId Equals v.StatusID _
                         Where s.Descrip = "Unregistered RetMkt" _
                         Select s

            If statusInfo.Count() < 1 Then
                status = False
            Else
                status = True
            End If

            statusInfo = Nothing

            Return status

        End Function

        Public Function IsVehicleUnregisteredRetailer(ByVal vehicleId As Integer) As Boolean
            Dim status As Boolean
            Dim statusInfo As System.Collections.Generic.IEnumerable(Of EnvelopeContentDataSet.VehicleStatusRow)


            statusInfo = From s In Data.VehicleStatus _
                         Join v In Data.vwCircular On s.CodeId Equals v.StatusID _
                         Where s.Descrip = "Unregistered Retailer" _
                         Select s

            If statusInfo.Count() < 1 Then
                status = False
            Else
                status = True
            End If

            statusInfo = Nothing

            Return status

        End Function



        ''' <summary>
        ''' Gets code id for Review status.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetStatusIdForReview() As Integer
            Dim statusId As Integer


            statusId = GetStatusIdFor("Review")

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
            Dim reviewStatus As Object


            reviewStatus = VehicleStatusAdapter.IsVehicleStatusReview(vehicleId)
            If reviewStatus Is Nothing Or reviewStatus Is DBNull.Value Then
                recordCount = 0
            ElseIf Integer.TryParse(reviewStatus.ToString(), recordCount) = False Then
                recordCount = 0
            End If

            reviewStatus = Nothing

            Return (recordCount > 0)

        End Function

        ''' <summary>
        ''' Gets code id for Duplicate status.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetStatusIdForDuplicate() As Integer
            Dim statusId As Integer


            statusId = GetStatusIdFor("Duplicate")

            Return statusId

        End Function


        ''' <summary>
        ''' Returns true if vehicle is having status set to Duplicate, false otherwise.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsVehicleDuplicate(ByVal vehicleId As Integer) As Boolean
            Dim recordCount As Integer
            Dim reviewStatus As Object


            reviewStatus = VehicleStatusAdapter.IsVehicleStatusDuplicate(vehicleId)
            If reviewStatus Is Nothing Or reviewStatus Is DBNull.Value Then
                recordCount = 0
            ElseIf Integer.TryParse(reviewStatus.ToString(), recordCount) = False Then
                recordCount = 0
            End If

            reviewStatus = Nothing

            Return (recordCount > 0)

        End Function

        ''' <summary>
        ''' Gets status Id for Wrong Version vehicle status.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetStatusIdForWrongVersion() As Integer
            Dim statusId As Integer


            statusId = GetStatusIdFor("Wrong Version")

            Return statusId

        End Function

        ''' <summary>
        ''' Gets name of the envelope sender. 
        ''' </summary>
        ''' <param name="envelopeID">Envelope Id, to get it's sender name.</param>
        ''' <remarks></remarks>
        Public Function GetEnvelopeSenderName(ByVal envelopeID As Integer) As String
            Dim envelopeSender As String



            SenderAdapter.Fill(Data.EnvelopeSender, envelopeID)

            If Data.EnvelopeSender.Count > 0 AndAlso Data.EnvelopeSender(0).IsNameNull() = False Then
                envelopeSender = Data.EnvelopeSender(0).Name
                _tempId = Data.EnvelopeSender(0).SenderId
                If Data.EnvelopeSender(0).IsCommentsNull = False Then
                    SenderComment = Data.EnvelopeSender(0).Comments
                End If
            End If

            Data.EnvelopeSender.Rows.Clear()

            Return envelopeSender

        End Function

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

            SenderAdapter.Fill(Data.EnvelopeSender, envelopeID)

            If Data.EnvelopeSender.Count = 0 Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("EnvelopeId", envelopeID)
                    RaiseEvent EnvelopeSenderNotFound(Me, e)
                End Using
            Else
                _Sender = CInt(Data.EnvelopeSender.Rows(0).Item(0).ToString)
                Using e As EventArgs = New EventArgs
                    e.Data.Add("EnvelopeId", envelopeID)
                    e.Data.Add("EnvelopeSenderRow", Data.EnvelopeSender(0))
                    RaiseEvent EnvelopeSenderLoaded(Me, e)
                End Using
            End If

            Return _Sender
        End Function

        ''' <summary>
        ''' Loads markets based on sender of supplied envelope Id.
        ''' </summary>
        ''' <param name="envelopeId">Markets are loaded based on sender of supplied  envelope Id.</param>
        ''' <remarks></remarks>
        Public Sub LoadMarketsForEnvelope(ByVal envelopeId As Integer)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Cancel = False
                e.Data.Add("EnvelopeId", envelopeId)

                RaiseEvent LoadingMarkets(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            MarketAdapter.Fill(Data.Mkt, envelopeId)

            Using e As EventArgs = New EventArgs
                e.Data.Add("EnvelopeId", envelopeId)
                RaiseEvent MarketsLoaded(Me, e)
            End Using

        End Sub



        ''' <summary>
        ''' Loads markets based on sender of supplied envelope Id.
        ''' </summary>
        ''' <param name="envelopeId">Markets are loaded based on sender of supplied  envelope Id.</param>
        ''' <remarks></remarks>
        Public Function LoadMarketsPerSenderExpectation(ByVal _sender As Integer, ByVal _Media As Integer) As Integer

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Cancel = False
                e.Data.Add("SenderId", _sender)

                RaiseEvent LoadingMarkets(Me, e)
                If e.Cancel Then
                    Exit Function
                End If
            End Using

            MarketAdapter.FillBySenderExpectation(Data.Mkt, _Media, _sender)


            If Data.Mkt.Rows.Count > 0 Then
                Return Data.Mkt.Rows.Count
            Else
                Return 0
            End If
            Using e As EventArgs = New EventArgs
                e.Data.Add("SenderId", _sender)
                RaiseEvent MarketsLoaded(Me, e)
            End Using

        End Function

        ''' <summary>
        ''' Loads markets, which are valid for media type Catalog.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadMarketsForCatalog()

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Cancel = False
                e.Data.Add("Media", "Catalog")

                RaiseEvent LoadingMarkets(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            MarketAdapter.FillForCatalog(Data.Mkt)

            Using e As EventArgs = New EventArgs
                e.Data.Add("Media", "Catalog")
                RaiseEvent MarketsLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Loads publication based on marketId.
        ''' </summary>
        ''' <param name="mktId"></param>
        ''' <remarks></remarks>
        Public Sub LoadPublicationFor(ByVal mktId As Integer)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Cancel = False
                e.Data.Add("MarketId", mktId)

                RaiseEvent LoadingPublications(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            PublicationAdapter.FillByMktId(Data.Publication, mktId)

            Using e As EventArgs = New EventArgs
                e.Data.Add("MarketId", mktId)
                RaiseEvent PublicationsLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Loads Just the NA publication.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadNAPublication(ByVal marketId As Integer)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Cancel = False

                RaiseEvent LoadingPublications(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            'PublicationAdapter.FillNA(Data.Publication, marketId)
            PublicationAdapter.FillNA(Data.Publication)

            Using e As EventArgs = New EventArgs
                RaiseEvent PublicationsLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Loads all retailers.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadRetailers()

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Cancel = False

                RaiseEvent LoadingRetailers(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            RetailerAdapter.Fill(Data.Ret)

            Using e As EventArgs = New EventArgs
                RaiseEvent RetailersLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Loads retailers based on supplied mediaId and marketId.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Public Sub LoadRetailers(ByVal mediaId As Integer, ByVal marketId As Integer)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Cancel = False
                e.Data.Add("MediaId", mediaId)
                e.Data.Add("MarketId", marketId)

                RaiseEvent LoadingRetailers(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            RetailerAdapter.FillByMediaIdMktId(Data.Ret, mediaId, marketId)

            Using e As EventArgs = New EventArgs
                e.Data.Add("MediaId", mediaId)
                e.Data.Add("MarketId", marketId)
                RaiseEvent PublicationsLoaded(Me, e)
            End Using

        End Sub
        ''' <summary>
        ''' Loads retailers based on Senderid mediaId and marketId.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Public Function LoadRetailersSenderExpectation(ByVal _sender As Integer, ByVal _media As Integer, ByVal _mkt As Integer) As Integer

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Cancel = False
                e.Data.Add("SenderId", _sender)

                RaiseEvent LoadingRetailers(Me, e)
                If e.Cancel Then
                    Exit Function
                End If
            End Using

            RetailerAdapter.FillBySenderExpectation(Data.Ret, _media, _mkt, _sender)

            If Data.Ret.Rows.Count > 0 Then
                Return Data.Ret.Rows.Count
            Else
                Return 0
            End If

            Using e As EventArgs = New EventArgs
                e.Data.Add("SenderId", _sender)
                RaiseEvent PublicationsLoaded(Me, e)
            End Using

        End Function

        ''' <summary>
        ''' Loads expected retailers based on supplied mediaId and marketId.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Public Sub LoadExpectedRetailers(ByVal mediaId As Integer, ByVal marketId As Integer)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Cancel = False
                e.Data.Add("MediaId", mediaId)
                e.Data.Add("MarketId", marketId)

                RaiseEvent LoadingExpectedRetailers(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            ExpectedRetailerAdapter.FillByMktIdAndMediaId(Data.vwExpectedRet, marketId, mediaId)

            Using e As EventArgs = New EventArgs
                e.Data.Add("MediaId", mediaId)
                e.Data.Add("MarketId", marketId)
                RaiseEvent ExpectedRetailersLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Loads expected retailers based on supplied mediaId and marketId.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Public Sub LoadExpectedRetailers(ByVal mediaId As Integer, ByVal marketId As Integer, ByVal senderid As Integer)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Cancel = False
                e.Data.Add("MediaId", mediaId)
                e.Data.Add("MarketId", marketId)

                RaiseEvent LoadingExpectedRetailers(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using


            ExpectedRetailerAdapter.FillBySEExpectedRet(Data.vwExpectedRet, marketId, mediaId, senderid)
            'ExpectedRetailerAdapter.FillBySenderExpectedRet(Data.vwExpectedRet, senderid)

            Using e As EventArgs = New EventArgs
                e.Data.Add("MediaId", mediaId)
                e.Data.Add("MarketId", marketId)
                RaiseEvent ExpectedRetailersLoaded(Me, e)
            End Using

        End Sub
        ''' <summary>
        ''' Retrives priority based on supplied retailer, market and media id values.
        ''' </summary>
        ''' <param name="RetId"></param>
        ''' <param name="MktId"></param>
        ''' <param name="MediaId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPriority _
            (ByVal RetId As Integer, ByVal MktId As Integer, ByVal MediaId As Integer) _
            As Integer
            Dim priorityValue As Global.System.Nullable(Of Integer)


            priorityValue = CType(ExpectedRetailerAdapter.GetPriority(RetId, MktId, MediaId), Integer?)

            If priorityValue Is Nothing Then
                Return -1
            Else
                Return CType(priorityValue, Integer)
            End If

        End Function

        ''' <summary>
        ''' Retrives value of ScanDPI column based on supplied retailer, market and media id values.
        ''' </summary>
        ''' <param name="RetId"></param>
        ''' <param name="MktId"></param>
        ''' <param name="MediaId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetScanDPI _
            (ByVal RetId As Integer, ByVal MktId As Integer, ByVal MediaId As Integer) _
            As Integer
            Dim dpiValue As Global.System.Nullable(Of Integer)


            dpiValue = ExpectedRetailerAdapter.GetScanDPI(RetId, MktId, MediaId)

            If dpiValue Is Nothing Then
                Return 0
            Else
                Return CType(dpiValue, Integer)
            End If

        End Function


        Public Function GetExpectationPerMediaMarketRet _
        (ByVal MediaId As Integer, ByVal MktId As Integer, ByVal RetId As Integer) _
        As Integer
            Dim ExpId As Integer
            Dim sql As String

            sql = "Select expectationid from expectation where enddt is null and MediaId=" & MediaId & "and mktid=" & MktId & " and retid=" & RetId

            ExpId = CInt(GetFieldValue(sql, "ExpectationID"))

            Return ExpId

        End Function

  


#Region " Validation related methods "


        ''' <summary>
        ''' If retailer is one of the rquired retailers, validates Publication and 
        ''' Page count column values and returns status accordingly. If retailer is 
        ''' not in the list of required retailers, sets Publication, start date, 
        ''' end date, page count and occurances column values to null and returns true.
        ''' </summary>
        ''' <param name="validateRow"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function ValidateRequiredRetailerInputs _
            (ByVal validateRow As EnvelopeContentDataSet.vwCircularRow) _
            As Boolean
            Dim RetailerView As Data.DataView
            Dim RetMktView As Data.DataView
            Dim senderView As Data.DataView
            Dim ExpectationID As Integer

            If validateRow.IsStatusIDNull = False Then
                If validateRow.StatusID = GetStatusIdForReview() OrElse validateRow.StatusID = GetStatusIdForDuplicate() OrElse validateRow.StatusID = GetStatusIdForWrongVersion() Then
                    Return True
                End If
            End If

            'Check whether the retailer exists in list of required retailers or not. 
            'If exist, validate publication and page count column values otherwise 
            'set Publication, start date, end date, Check-in and Occurances column 
            'values to null and return true. 
            If isRequiredRetailers(_Sender, validateRow.MediaId, validateRow.MktId, validateRow.RetId) = False Then
                ExpectationID = GetExpectationPerMediaMarketRet(validateRow.MediaId, validateRow.MktId, validateRow.RetId)
                If isNewRetailer = False Then

                    If IsValidSenderExpectationID(CInt(ExpectationID)) = True Then
                        If IsBackupSender(CInt(ExpectationID), _Sender) = True Then
                            If counter < 1 Then
                                MessageBox.Show("Vehicle Marked as Backup Sender .", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                            'validateRow.SetCheckInOccurrencesNull()
                            'validateRow.SetColumnError("CheckInOccurrences", "")
                            validateRow.StatusID = GetStatusIdForBackupSender()
                            counter = counter + 1
                            Return True
                        End If

                    End If

                    If isUnregisteredRetMktExists(validateRow.MediaId, validateRow.MktId, validateRow.RetId) = True Then
                        If counter < 1 Then
                            MessageBox.Show("Vehicle Marked as Unregistered RetMkt .", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        'validateRow.SetCheckInOccurrencesNull()
                        'validateRow.SetColumnError("CheckInOccurrences", "")
                        validateRow.StatusID = GetStatusIdForUnregisteredRetMkt()
                        counter = counter + 1
                        Return True
                    Else
                        If isUnregisteredRetMkt(validateRow.MktId, validateRow.RetId) = True Then
                            If counter < 1 Then
                                MessageBox.Show("Vehicle Marked as Unregistered RetMkt .", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                            'validateRow.SetCheckInOccurrencesNull()
                            'validateRow.SetColumnError("CheckInOccurrences", "")
                            validateRow.StatusID = GetStatusIdForUnregisteredRetMkt()
                            counter = counter + 1
                            Return True
                        End If
                    End If

                    If isUnregisteredRetMktMediaExists(validateRow.MediaId, validateRow.MktId, validateRow.RetId) = True Then

                        If counter < 1 Then
                            MessageBox.Show("Vehicle Marked as Unregistered RetMktMedia .", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        'validateRow.SetCheckInOccurrencesNull()
                        'validateRow.SetColumnError("CheckInOccurrences", "")
                        validateRow.StatusID = GetStatusIdForUnregisteredRetMktMedia()
                        counter = counter + 1
                        Return True

                    Else
                        If isUnregisteredRetMktMedia(validateRow.MediaId, validateRow.MktId, validateRow.RetId) = True Then
                            If counter < 1 Then
                                MessageBox.Show("Vehicle Marked as Unregistered RetMktMedia .", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                            'validateRow.SetCheckInOccurrencesNull()
                            'validateRow.SetColumnError("CheckInOccurrences", "")
                            validateRow.StatusID = GetStatusIdForUnregisteredRetMktMedia()
                            counter = counter + 1
                            Return True
                        End If
                    End If

                    RetailerView = New Data.DataView(Data.vwExpectedRet)
                    RetailerView.RowFilter = "RetId=" + validateRow.RetId.ToString()

                    If RetailerView.Count = 0 Or RetailerView.Count > 0 Then
                        RetailerView.Dispose()
                        RetailerView = Nothing
                        If counter < 1 Then
                            MessageBox.Show("Vehicle Marked as Backup Sender .", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        'validateRow.SetCheckInOccurrencesNull()
                        'validateRow.SetColumnError("CheckInOccurrences", "")
                        validateRow.StatusID = GetStatusIdForBackupSender()
                        counter = counter + 1
                        Return True
                    End If
                    RetailerView.Dispose()
                    RetailerView = Nothing
                Else
                    'If ifNewRetailerExist(newRetailerName) = True Then
                    '    If counter < 1 Then
                    '        Dim userResponse As DialogResult
                    '        userResponse = MessageBox.Show("Retailer Already Exist, Please review Closed Retailer.  Vehicle will be Marked as Unregistered RetMkt.  Continue ?" _
                    '                                          , "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    '        If userResponse = Windows.Forms.DialogResult.No Then Exit Function
                    '        validateRow.RetId = existingRetid(newRetailerName)
                    '    End If
                    '    validateRow.SetCheckInOccurrencesNull()
                    '    validateRow.SetColumnError("CheckInOccurrences", "")
                    '    validateRow.StatusID = GetStatusIdForUnregisteredRetMkt()
                    '    counter = counter + 1
                    '    Return True
                    'Else
                    'validateRow.SetCheckInOccurrencesNull()
                    'validateRow.SetColumnError("CheckInOccurrences", "")
                    validateRow.StatusID = GetStatusIdForNewRetailer()
                    Return True
                    'End If
                End If

            End If

            If validateRow.IsPublicationIdNull() Then
                AddErrorInformation(Data.Errors, "PublicationId", "Publication", "Publication is not specified.")
                validateRow.SetColumnError("PublicationId", "Publication is not specified.")
            Else
                RemoveErrorInformation(Data.Errors, "PublicationId")
                validateRow.SetColumnError("PublicationId", "")
            End If


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

        ''' <summary>
        ''' Validates all columns of supplied DataRow.
        ''' </summary>
        ''' <param name="validateRow"></param>
        ''' <returns>
        ''' True if all columns contains valid inforamtion. False otherwise.
        ''' </returns>
        ''' <remarks></remarks>
        Private Function AreDatesValid(ByVal validateRow As EnvelopeContentDataSet.vwCircularRow) As Boolean

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


            Return (Not validateRow.HasErrors)

        End Function


        ''' <summary>
        ''' Checks whether all columns contain valid values or not. Returns false if not, true otherwise.
        ''' </summary>
        ''' <param name="validateRow"></param>
        ''' <remarks></remarks>
        Private Sub ValidateColumnValues(ByVal validateRow As EnvelopeContentDataSet.vwCircularRow)
            Dim areAllValid As Boolean
            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Cancel = False

                RaiseEvent ValidatingColumnValues(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            areAllValid = True

            If areAllValid Then areAllValid = ValidateRequiredRetailerInputs(validateRow)
            If areAllValid Then areAllValid = AreDatesValid(validateRow)

            If areAllValid Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRow", validateRow)
                    RaiseEvent ColumnValuesValidated(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRow", validateRow)
                    e.Data.Add("Errors", Data.Errors)
                    e.Data.Add("Warnings", Data.Warnings)
                    RaiseEvent InvalidColumnValueFound(Me, e)
                End Using
                Data.Errors.Clear()
                Data.Warnings.Clear()
            End If

        End Sub


#End Region


        ''' <summary>
        ''' Validate column value of supplied row.
        ''' </summary>
        ''' <param name="validateRow"></param>
        ''' <exception cref="System.ApplicationException"></exception>
        ''' <remarks></remarks>
        Private Sub ValidateValues(ByVal validateRow As EnvelopeContentDataSet.vwCircularRow)

            ValidateColumnValues(validateRow)
            If validateRow.HasErrors Then Throw New System.ApplicationException("Invalid column values found.")

        End Sub

        ''' <summary>
        ''' Validate column value for each row in supplied table.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Private Sub ValidateValues(ByVal validateTable As EnvelopeContentDataSet.vwCircularDataTable)
            Dim validateRow As EnvelopeContentDataSet.vwCircularRow

            For i As Integer = 0 To validateTable.Count - 1
                validateRow = Data.vwCircular.FindByVehicleId(validateTable(i).VehicleId)
                If validateRow Is Nothing Then Continue For

                Using e As CancellableEventArgs = New CancellableEventArgs
                    e.Data.Add("ValidateRow", validateRow)
                    e.Cancel = False

                    RaiseEvent ValidatingColumnValues(Me, e)

                    If e.Cancel Then
                        Exit Sub
                    End If
                End Using

                ValidateColumnValues(validateRow)

                If validateRow.HasErrors Then
                    Using e As EventArgs = New EventArgs
                        e.Data.Add("ValidateRow", validateRow)
                        RaiseEvent InvalidColumnValueFound(Me, e)
                    End Using
                Else
                    Using e As EventArgs = New EventArgs
                        e.Data.Add("ValidateRow", validateRow)
                        RaiseEvent ColumnValuesValidated(Me, e)
                    End Using
                End If
            Next

        End Sub

        ''' <summary>
        ''' Returns new blank row associated with vehicle table.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateNew() As EnvelopeContentDataSet.vwCircularRow

            Return Data.vwCircular.NewvwCircularRow()

        End Function

        ''' <summary>
        ''' Inserts record into Vehicle table in dataset.
        ''' </summary>
        ''' <param name="newRow">Row containing inforamtion to be inserted into dataset.</param>
        ''' <remarks></remarks>
        Public Sub Add(ByVal newRow As EnvelopeContentDataSet.vwCircularRow)

            ValidateValues(newRow)

            If newRow.RowState = DataRowState.Detached Then
                'If newRow.IsCreateDtNull() Then newRow.CreateDt = System.DateTime.Now
                If newRow.IsCreatedByIdNull() Then newRow.CreatedById = UserID
            End If

            Data.vwCircular.AddvwCircularRow(newRow)

        End Sub

        ''' <summary>
        ''' Save vehicle information into database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Save()
            Dim rowsAffected As Integer
            Dim changesDataTable As System.Data.DataTable


            changesDataTable = Data.vwCircular.GetChanges()

            If changesDataTable Is Nothing Then
                Using e As UI.Processors.EventArgs = New UI.Processors.EventArgs
                    RaiseEvent NoChangesToSynchronize(Me, e)
                End Using
                Exit Sub
            End If

            ValidateValues(CType(changesDataTable, EnvelopeContentDataSet.vwCircularDataTable))
            If changesDataTable.HasErrors Then
                Throw New System.ApplicationException("Invalid column values found.")
            End If

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Cancel = False
                RaiseEvent Synchronizing(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            rowsAffected = VehicleAdapter.Update(Data.vwCircular)
            Data.vwCircular.AcceptChanges()
            Using e As EventArgs = New EventArgs
                e.Data.Add("RowsAffected", rowsAffected)
                e.Data.Add("SynchronizedRow", Data.vwCircular(0))
                RaiseEvent Synchronized(Me, e)
            End Using
            isNewRetailer = False
            Data.vwCircular.Clear()

        End Sub

        Public Function IsValidBypassSenderExpectationFilterUser() As Integer
            Dim validUser As Integer
            validUser = CInt(VehicleAdapter.isAllowedBypassSenderExpectationFilter(UserID)) ', formName, errorMessage)
            Return validUser ' (retailerCount.HasValue AndAlso retailerCount.Value > 0)

        End Function

        Public Function IsValidCheckInRequired() As Integer
            Dim validUser As Integer
            validUser = CInt(VehicleAdapter.isAllowedBypassRequired(UserID)) ', formName, errorMessage)
            Return validUser ' (retailerCount.HasValue AndAlso retailerCount.Value > 0)

        End Function

        Public Function IsValidCheckInNonRequired() As Integer
            Dim validUser As Integer
            validUser = CInt(VehicleAdapter.isAllowedCheckinNonRequired(UserID)) ', formName, errorMessage)
            Return validUser ' (retailerCount.HasValue AndAlso retailerCount.Value > 0)

        End Function

        ''' <summary>
        ''' Deletes vehicle from database.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <remarks></remarks>
        Public Sub Delete(ByVal vehicleId As Integer)
            Dim rowsAffected As Integer
            Dim deleteQuery As System.Data.EnumerableRowCollection(Of EnvelopeContentDataSet.vwCircularRow)


            Using e As MCAP.UI.Processors.CancellableEventArgs = New MCAP.UI.Processors.CancellableEventArgs()
                RaiseEvent DeletingVehicle(Me, e)
            End Using

            deleteQuery = From row In Data.vwCircular _
                          Where row.VehicleId = vehicleId _
                          Select row

            If deleteQuery.Count() > 0 Then
                deleteQuery(0).Delete()
                rowsAffected = VehicleAdapter.Update(Data.vwCircular)
            End If

            deleteQuery = Nothing

            Using e As MCAP.UI.Processors.EventArgs = New MCAP.UI.Processors.EventArgs()
                e.Data.Add("RowsAffected", rowsAffected)
                e.Data.Add("VehicleId", vehicleId)
                RaiseEvent VehicleDeleted(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Loads vehicle information based on supplied vehicle id.
        ''' </summary>
        ''' <param name="vehicleID">Vehicle Id to load Vehicle information</param>
        ''' <param name="formName">Name of the screen. This value is used to apply 
        ''' where clause while loading vehicle information from vwCircular.</param>
        ''' <remarks></remarks>
        Public Sub LoadVehicle(ByVal vehicleID As Integer, ByVal formName As String)
            Dim errorMessage As String


            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Cancel = False

                RaiseEvent LoadingVehicle(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            VehicleAdapter.Fill(Data.vwCircular, vehicleID, formName, errorMessage)

            If Data.vwCircular.Count = 0 AndAlso errorMessage Is Nothing Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("VehicleId", vehicleID)
                    RaiseEvent VehicleNotFound(Me, e)
                End Using

            ElseIf Data.vwCircular.Count = 0 AndAlso errorMessage IsNot Nothing Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("VehicleId", vehicleID)
                    e.Data.Add("ErrorMessage", errorMessage)
                    RaiseEvent InvalidVehicleStatus(Me, e)
                End Using

            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("VehicleRow", Data.vwCircular(0))
                    RaiseEvent VehicleLoaded(Me, e)
                End Using
            End If

        End Sub


        ''' <summary>
        ''' Gets a data row filled with user information, based on supplied userid.
        ''' </summary>
        ''' <param name="userId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUserInformation(ByVal userId As Integer) As EnvelopeContentDataSet.UserRow
            Dim userTable As EnvelopeContentDataSet.UserDataTable
            Dim userRow As EnvelopeContentDataSet.UserRow
            Dim userAdapter As EnvelopeContentDataSetTableAdapters.UserTableAdapter


            userAdapter = New EnvelopeContentDataSetTableAdapters.UserTableAdapter()
            userTable = New EnvelopeContentDataSet.UserDataTable
            userRow = Nothing

            userAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            userAdapter.Fill(userTable, userId)
            userAdapter.Dispose()
            userAdapter = Nothing

            If userTable.Count > 0 Then
                userRow = userTable(0)
            End If

            userTable.Dispose()
            userTable = Nothing

            Return userRow

        End Function

        Public Function AddTempRetailer(ByVal vehicleId As Integer, ByVal Desc As String) As Boolean
            Dim isPageImageSplit As Boolean
            Dim tempAdapter As MCAP.EnvelopeContentDataSetTableAdapters.TempRetTableAdapter


            tempAdapter = New MCAP.EnvelopeContentDataSetTableAdapters.TempRetTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.addTempRetailer(vehicleId, Desc)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            Return isPageImageSplit
        End Function


    End Class


End Namespace