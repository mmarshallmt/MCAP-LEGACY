﻿Namespace UI.Processors

    Public Class IndexBase
        Inherits BaseClass


        Public Event PrintingBarcode As MCAPCancellableEventHandler
        Public Event BarcodePrinted As MCAPEventHandler


        Private m_barcodePrinterName As String
        Private m_vehicleStatusAdapter As QCDataSetTableAdapters.vwVehicleStatusTableAdapter
        Private m_languageAdapter As QCDataSetTableAdapters.LanguageTableAdapter
        Private m_tradeclassAdapter As QCDataSetTableAdapters.TradeClassTableAdapter
        Private m_mediaAdapter As QCDataSetTableAdapters.MediaTableAdapter
        Private m_marketAdapter As QCDataSetTableAdapters.MktTableAdapter
        Private m_publicationAdapter As QCDataSetTableAdapters.PublicationTableAdapter
        Private m_retailerAdapter As QCDataSetTableAdapters.RetTableAdapter
        Private m_eventAdapter As QCDataSetTableAdapters.EventTableAdapter
        Private m_themeAdapter As QCDataSetTableAdapters.ThemeTableAdapter
        Private m_qcDataset As QCDataSet



        Public Sub New()

            m_vehicleStatusAdapter = New QCDataSetTableAdapters.vwVehicleStatusTableAdapter
            m_languageAdapter = New QCDataSetTableAdapters.LanguageTableAdapter
            m_tradeclassAdapter = New QCDataSetTableAdapters.TradeClassTableAdapter
            m_mediaAdapter = New QCDataSetTableAdapters.MediaTableAdapter
            m_marketAdapter = New QCDataSetTableAdapters.MktTableAdapter
            m_publicationAdapter = New QCDataSetTableAdapters.PublicationTableAdapter
            m_retailerAdapter = New QCDataSetTableAdapters.RetTableAdapter
            m_eventAdapter = New QCDataSetTableAdapters.EventTableAdapter
            m_themeAdapter = New QCDataSetTableAdapters.ThemeTableAdapter
            m_qcDataset = New QCDataSet

        End Sub



        ''' <summary>
        ''' Adapter to work with Language table.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected ReadOnly Property LanguageAdapter() As QCDataSetTableAdapters.LanguageTableAdapter
            Get
                Return m_languageAdapter
            End Get
        End Property

        ''' <summary>
        ''' Adapter to work with Tradeclass table.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected ReadOnly Property TradeclassAdapter() As QCDataSetTableAdapters.TradeClassTableAdapter
            Get
                Return m_tradeclassAdapter
            End Get
        End Property

        ''' <summary>
        ''' Adapter to work with Media table.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected ReadOnly Property MediaAdapter() As QCDataSetTableAdapters.MediaTableAdapter
            Get
                Return m_mediaAdapter
            End Get
        End Property

        ''' <summary>
        ''' Adapter to work with Market table.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected ReadOnly Property MarketAdapter() As QCDataSetTableAdapters.MktTableAdapter
            Get
                Return m_marketAdapter
            End Get
        End Property

        ''' <summary>
        ''' Adapter to work with Publication table.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected ReadOnly Property PublicationAdapter() As QCDataSetTableAdapters.PublicationTableAdapter
            Get
                Return m_publicationAdapter
            End Get
        End Property

        ''' <summary>
        ''' Adapter to work with Retailer table.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected ReadOnly Property RetailerAdapter() As QCDataSetTableAdapters.RetTableAdapter
            Get
                Return m_retailerAdapter
            End Get
        End Property

        ''' <summary>
        ''' Adapter to work with vwEvent view.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected ReadOnly Property EventAdapter() As QCDataSetTableAdapters.EventTableAdapter
            Get
                Return m_eventAdapter
            End Get
        End Property

        ''' <summary>
        ''' Adapter to work with vwTheme view.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected ReadOnly Property ThemeAdapter() As QCDataSetTableAdapters.ThemeTableAdapter
            Get
                Return m_themeAdapter
            End Get
        End Property

        ''' <summary>
        ''' Adapter to work with vwVehicleStatus view.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected ReadOnly Property VehicleStatusAdapter() As QCDataSetTableAdapters.vwVehicleStatusTableAdapter
            Get
                Return m_vehicleStatusAdapter
            End Get
        End Property

        ''' <summary>
        ''' Instance of QCDataSet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Data() As QCDataSet
            Get
                Return m_qcDataset
            End Get
        End Property


        ''' <summary>
        ''' Prints barcode label for Vehicle.
        ''' </summary>
        ''' <param name="barcodeRow">A row containing information to be printed on label.</param>
        ''' <remarks></remarks>
        Public Sub PrintBarcodeLabel(ByVal barcodeRow As QCDataSet.vwCircularRow)
            Dim scanDPI As Integer
            Dim labelPrint As MCAP.VehicleLabelPrint


            labelPrint = New MCAP.VehicleLabelPrint()

            scanDPI = GetScanDPI(barcodeRow.RetId, barcodeRow.MktId, barcodeRow.MediaId)

            labelPrint.PrinterName = BarcodePrinterName
            labelPrint.AdDate = barcodeRow.BreakDt
            labelPrint.CreatedBy = GetUserInformation(barcodeRow.CreatedById)
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
        ''' Sets connection string of table adapters to point to application database.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overridable Sub SetAdaptersConnectionString()

            LanguageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            TradeclassAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            MediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            MarketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            PublicationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            RetailerAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            EventAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            ThemeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            VehicleStatusAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

        End Sub


        ''' <summary>
        ''' Returns false if in-memory tradeclass table is having NoFamily indicator set to true, otherwise true.
        ''' </summary>
        ''' <param name="tradeclassId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsTradeclassRequireFamily(ByVal tradeclassId As Integer) As Boolean
            Dim isFamilyRequired As Boolean
            Dim tradeclassQuery As System.Data.EnumerableRowCollection(Of QCDataSet.TradeClassRow)


            tradeclassQuery = From tc In Data.TradeClass _
                              Where tc.TradeClassId = tradeclassId AndAlso (tc.IsNoFamilyIndNull() = False AndAlso tc.NoFamilyInd = 1)
            isFamilyRequired = (tradeclassQuery.Count() = 0)
            tradeclassQuery = Nothing

            Return isFamilyRequired
        End Function

        ''' <summary>
        ''' Retrives value of ScanDPI column based on supplied retailer, market and media id values.
        ''' </summary>
        ''' <param name="RetId"></param>
        ''' <param name="MktId"></param>
        ''' <param name="MediaId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetScanDPI(ByVal RetId As Integer, ByVal MktId As Integer, ByVal MediaId As Integer) As Integer
            Dim dpiValue As Global.System.Nullable(Of Integer)
            Dim tempAdapter As MCAP.QCDataSetTableAdapters.MediaTableAdapter


            tempAdapter = New MCAP.QCDataSetTableAdapters.MediaTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            dpiValue = CType(tempAdapter.GetScanDPI(RetId, MktId, MediaId), Integer?)

            tempAdapter.Dispose()
            tempAdapter = Nothing

            If dpiValue Is Nothing Then
                Return 0
            Else
                Return CType(dpiValue, Integer)
            End If

        End Function

        ''' <summary>
        ''' Gets short name of user, based on supplied userid.
        ''' </summary>
        ''' <param name="userId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUserInformation(ByVal userId As Integer) As String
            Dim shortName As String
            Dim userAdapter As QCDataSetTableAdapters.UserTableAdapter


            userAdapter = New QCDataSetTableAdapters.UserTableAdapter()
            userAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            shortName = userAdapter.GetShortName(userId)
            userAdapter.Dispose()
            userAdapter = Nothing

            Return shortName

        End Function

        ''' <summary>
        ''' Gets boolean flag indicating whether the supplied userId is assigned a 
        ''' supervisor or an administrator role or not.
        ''' </summary>
        ''' <param name="UserID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsUserSupervisorOrAdministrator(ByVal UserID As Integer) As Boolean
            Dim tempAdapter As MCAP.QCDataSetTableAdapters.UserTableAdapter
            Dim userRows As System.Data.EnumerableRowCollection(Of QCDataSet.UserRow)

            tempAdapter = New MCAP.QCDataSetTableAdapters.UserTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(Data.User, UserID)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            userRows = From ur In Data.User _
                       Where ur.Role.ToUpper() = "ADMINISTRATOR" OrElse ur.Role.ToUpper() = "SUPERVISOR" _
                       Select ur

            If userRows.Count() = 0 Then
                userRows = Nothing
                Return False
            Else
                userRows = Nothing
                Return True
            End If

        End Function

        ''' <summary>
        ''' Load markets from Mkt table using SenderMktAssoc table. Rows are filtered by sender of the supplied envelope.
        ''' </summary>
        ''' <param name="envelopeId"></param>
        ''' <remarks></remarks>
        Protected Sub LoadMarkets(ByVal envelopeId As Integer)

            MarketAdapter.Fill(Data.Mkt, envelopeId)

        End Sub

        ''' <summary>
        ''' Load markets from Mkt table using SenderMktAssoc table. Rows are filtered by sender of the supplied envelope.
        ''' </summary>
        ''' <param name="envelopeId"></param>
        ''' <remarks></remarks>
        Protected Sub LoadMarkets(ByVal vehicleid As Integer, ByVal senderid As Integer)

            MarketAdapter.FillWithoutMktAssoc(Data.Mkt, senderid, vehicleid)

        End Sub

        ''' <summary>
        ''' Load publications from Publication table, filtered by supplied marketId.
        ''' </summary>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Protected Sub LoadPublications(ByVal marketId As Integer, ByVal publicationid As Integer)

            PublicationAdapter.Fill(Data.Publication, marketId, publicationid)

        End Sub

        ''' <summary>
        ''' Load publications from Publication table, Just NA
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub LoadNAPublication()

            PublicationAdapter.FillNA(Data.Publication)

        End Sub

        ''' <summary>
        ''' Load retailers from Ret table using expectation table. Rows are filtered on media and market.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Protected Sub LoadRetailers(ByVal mediaId As Integer, ByVal marketId As Integer)

            RetailerAdapter.Fill(Data.Ret, mediaId, marketId)

        End Sub

        ''' <summary>
        ''' Returns statusId for review status.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function GetStatusIdForReview() As Integer
            Dim reviewStatusId As Integer
            Dim linqQuery As System.Collections.Generic.IEnumerable(Of QCDataSet.vwVehicleStatusRow)


            linqQuery = From vs In Data.vwVehicleStatus.Rows.Cast(Of QCDataSet.vwVehicleStatusRow)() _
                        Select vs _
                        Where vs.Descrip = "Review"

            If linqQuery.Count = 0 Then
                'linqQuery = Nothing
                'Throw New System.ApplicationException("Unable to find indexed status.")
                reviewStatusId = -1
            Else
                reviewStatusId = linqQuery(0).CodeId
            End If

            linqQuery = Nothing

            Return reviewStatusId

        End Function

        ''' <summary>
        ''' Returns statusId for  duplicate status.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function GetStatusIdForDuplicate() As Integer
            Dim DuplicateStatusId As Integer
            Dim linqQuery As System.Collections.Generic.IEnumerable(Of QCDataSet.vwVehicleStatusRow)


            linqQuery = From vs In Data.vwVehicleStatus.Rows.Cast(Of QCDataSet.vwVehicleStatusRow)() _
                        Select vs _
                        Where vs.Descrip = "Duplicate"

            If linqQuery.Count = 0 Then
                'linqQuery = Nothing
                'Throw New System.ApplicationException("Unable to find indexed status.")
                DuplicateStatusId = -1
            Else
                DuplicateStatusId = linqQuery(0).CodeId
            End If

            linqQuery = Nothing

            Return DuplicateStatusId

        End Function
        ''' <summary>
        ''' * Omar
        ''' Returns statusId for QC status.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function GetStatusIdForQC() As Integer
            Dim qcStatusId As Integer
            Dim linqQuery As System.Collections.Generic.IEnumerable(Of QCDataSet.vwVehicleStatusRow)


            linqQuery = From vs In Data.vwVehicleStatus.Rows.Cast(Of QCDataSet.vwVehicleStatusRow)() _
                        Select vs _
                        Where vs.Descrip = "QC Completed"

            If linqQuery.Count = 0 Then
                'linqQuery = Nothing
                'Throw New System.ApplicationException("Unable to find indexed status.")
                qcStatusId = -1
            Else
                qcStatusId = linqQuery(0).CodeId
            End If

            linqQuery = Nothing

            Return qcStatusId

        End Function

        ''' <summary>
        ''' Returns statusId for Indexed status.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function GetStatusIdForIndexed() As Integer
            Dim indexedStatusId As Integer
            Dim linqQuery As System.Collections.Generic.IEnumerable(Of QCDataSet.vwVehicleStatusRow)


            linqQuery = From vs In Data.vwVehicleStatus.Rows.Cast(Of QCDataSet.vwVehicleStatusRow)() _
                        Select vs _
                        Where vs.Descrip = "Indexed"

            If linqQuery.Count = 0 Then
                'linqQuery = Nothing
                'Throw New System.ApplicationException("Unable to find indexed status.")
                indexedStatusId = -1
            Else
                indexedStatusId = linqQuery(0).CodeId
            End If

            linqQuery = Nothing

            Return indexedStatusId

        End Function

        ''' <summary>
        ''' Gets boolean value indicating whether supplied retailer and market are valid, for flash ads, or not.
        ''' </summary>
        ''' <param name="retailerId"></param>
        ''' <param name="marketId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsValidFlashRetMkt(ByVal retailerId As Integer, ByVal marketId As Integer) As Boolean
            Dim count As Integer?
            Dim tempAdapter As QCDataSetTableAdapters.RetTableAdapter


            tempAdapter = New QCDataSetTableAdapters.RetTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            count = tempAdapter.IsRetailerMarketValidForFlash(retailerId, marketId)

            tempAdapter.Dispose()
            tempAdapter = Nothing

            Return (count.HasValue AndAlso count.Value > 0)
        End Function

        ''' <summary>
        ''' Gets string value for Expectation Comments.
        ''' </summary>
        ''' <param name="retailerId"></param>
        ''' <param name="marketId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getExpectationComments(ByVal vehicleId As Integer, ByVal retailerId As Integer, ByVal marketId As Integer, ByVal mediaId As Integer) As String
            Dim count As Integer?
            Dim ExpComments As String
            Dim tempAdapter As QCDataSetTableAdapters.vwCircularTableAdapter


            tempAdapter = New QCDataSetTableAdapters.vwCircularTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            ExpComments = tempAdapter.FillByExpCmmnt(vehicleId, retailerId, marketId, mediaId)

            tempAdapter.Dispose()
            tempAdapter = Nothing

            If ExpComments = Nothing Then
                ExpComments = ""
      End If
            Return ExpComments.ToString()
        End Function


        ''' <summary>
        ''' Gets boolean value indicating whether supplied retailer and market are valid, for flash ads, or not.
        ''' </summary>
        ''' <param name="retailerId"></param>
        ''' <param name="marketId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsValidFlashNational(ByVal retailerId As Integer) As Boolean
            Dim count As Integer?
            Dim tempAdapter As QCDataSetTableAdapters.RetTableAdapter


            tempAdapter = New QCDataSetTableAdapters.RetTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            count = tempAdapter.IsRetailerValidForNational(retailerId)

            tempAdapter.Dispose()
            tempAdapter = Nothing

            Return (count.HasValue AndAlso count.Value > 0)
        End Function
        ''' <summary>
        ''' Returns boolean value indicating whether tradeclass for supplied retailer has LimitedEntryInd set to true or false.
        ''' </summary>
        ''' <param name="retailerId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsTradeclassMarkedForLimitedEntry(ByVal retailerId As Integer) As Boolean
            Dim isMarked As Boolean
            Dim retQuery As System.Data.EnumerableRowCollection(Of QCDataSet.RetRow)


            retQuery = From r In Data.Ret _
                       Where r.RetId = retailerId AndAlso r.IsLimitedEntryIndNull() = False AndAlso r.LimitedEntryInd = 1 _
                       Select r

            If retQuery.Count() < 1 Then
                isMarked = False
            Else
                isMarked = True
            End If

            retQuery = Nothing

            Return isMarked

        End Function

        ''' <summary>
        ''' Returns true if vehicle status is set to indexed, false otherwise.
        ''' </summary>
        ''' <param name="vehicleRow"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function IsVehicleIndexed(ByVal vehicleRow As QCDataSet.vwCircularRow) As Boolean
            Dim isIndexed As Boolean
            Dim indexedStatusId As Integer


            indexedStatusId = GetStatusIdForIndexed()

            If vehicleRow.IsStatusIDNull Then
                isIndexed = False
            ElseIf vehicleRow.StatusID = indexedStatusId Then
                isIndexed = True
            Else
                isIndexed = False
            End If

            Return isIndexed

        End Function

        Protected Function IsVehicleQced(ByVal vehicleRow As QCDataSet.vwCircularRow) As Boolean
            Dim isQced As Boolean
            Dim qcStatusId As Integer


            qcStatusId = GetStatusIdForQC()

            If vehicleRow.IsStatusIDNull Then
                isQced = False
            ElseIf vehicleRow.StatusID = qcStatusId Then
                isQced = True
            Else
                isQced = False
            End If

            Return isQced

        End Function

        ''' <summary>
        ''' Sets status Id column value to reviewed status in supplied datarow.
        ''' </summary>
        ''' <param name="vehicleRow"></param>
        ''' <remarks></remarks>
        Public Sub SetVehicleStatusAsReviewed(ByVal vehicleRow As QCDataSet.vwCircularRow)
            Dim reviewStatusId As Integer


            reviewStatusId = GetStatusIdForReview()

            vehicleRow.StatusID = reviewStatusId

        End Sub

        ''' <summary>
        ''' Sets status Id column value to duplicate status in supplied datarow.
        ''' </summary>
        ''' <param name="vehicleRow"></param>
        ''' <remarks></remarks>
        Public Sub SetVehicleStatusAsDuplicate(ByVal vehicleRow As QCDataSet.vwCircularRow)
            Dim duplicateStatusId As Integer


            duplicateStatusId = GetStatusIdForDuplicate()

            vehicleRow.StatusID = duplicateStatusId
            vehicleRow.IndexedById = CInt(User.m_currentUser.UserID)
            updateVehicleStatusChangedBy(vehicleRow.VehicleId)
        End Sub

        Public Sub updateVehicleStatusChangedBy(ByVal VehicleID As Object)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "UPDATE Vehicle SET StatusChangedByID = " + User.m_currentUser.UserID.ToString + " where vehicleID = " + VehicleID.ToString + ""
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub

        ''' <summary>
        ''' Sets status Id column value to indexed status in supplied datarow.
        ''' </summary>
        ''' <param name="vehicleRow"></param>
        ''' <remarks></remarks>
        Public Sub SetVehicleStatusAsIndexed(ByVal vehicleRow As QCDataSet.vwCircularRow)
            Dim indexedStatusId As Integer


            indexedStatusId = GetStatusIdForIndexed()

            vehicleRow.StatusID = indexedStatusId
            vehicleRow.IndexDt = DateTime.Now
            vehicleRow.IndexedById = UserID

        End Sub



        ''' <summary>
        ''' Overridable method to load information from database.
        ''' </summary>
        ''' <remarks>Method body is empty and should be implemented by derived classes.</remarks>
        Public Overridable Sub LoadDataSet(ByVal _sender As Integer)

            TradeclassAdapter.Fill(Data.TradeClass)
            'MediaAdapter.FillBySenderExpectation(Data.Media, _sender)
            'If Data.Media.Rows.Count = 0 Then
            MediaAdapter.Fill(Data.Media)
            'End If
            EventAdapter.Fill(Data._Event)
            ThemeAdapter.Fill(Data.Theme)
            LanguageAdapter.Fill(Data.Language)
            VehicleStatusAdapter.Fill(Data.vwVehicleStatus)

        End Sub

        ''' <summary>
        ''' Overridable method to load vehicle from database.
        ''' </summary>
        ''' <param name="vehicleId">Id of the vehicle to be loaded from database.</param>
        ''' <param name="formName">Name of the screen. Based on screen name, limitations of status is applied.</param>
        ''' <remarks>Method body is empty and should be implemented by derived classes.</remarks>
        Public Overridable Sub LoadVehicle(ByVal vehicleId As Integer, ByVal formName As String)

        End Sub

        ''' <summary>
        ''' Overridable method to synchronize vehicle information with database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Overridable Sub SynchronizeVehicleInformation()

        End Sub

    End Class


End Namespace