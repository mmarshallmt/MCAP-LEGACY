
Namespace UI.Processors

    Public Class CCTaskLog
        Inherits BaseClass

#Region " Events"
        Public Event ValidatingColumnValues As MCAPCancellableEventHandler
        Public Event ColumnValuesValidated As MCAPEventHandler
        'Public Event InvalidInputExist(ByVal errors As EnvelopeContentDataSet.ErrorsDataTable, ByVal warnings As EnvelopeContentDataSet.WarningsDataTable)
        Public Event InvalidColumnValueFound As MCAPEventHandler

        Public Event NoChangesToSynchronize As MCAPEventHandler
        Public Event Synchronizing As MCAPCancellableEventHandler
        Public Event Synchronized As MCAPEventHandler

        Public Event SynchronizingTaskLog As MCAPCancellableEventHandler
        Public Event TaskLogSynchronized As MCAPEventHandler

        Public Event LoadingTaskLogId(ByVal TaskLogsId As Integer)
        Public Event TaskLogIdLoaded(ByVal taskLogsRow As CoverageDataSet.CCTaskLogsRow)
        Public Event TaskLogIdNotFound(ByVal TaskLogsId As Integer)
        Public Event InvalidTaskLogIdStatus(ByVal statusText As String)


        Public Event LoadingMarkets()
        Public Event MarketsLoaded()

        Public Event LoadingRetailers()
        Public Event RetailersLoaded()

        Public Event LoadingSenders()
        Public Event SendersLoaded()




#End Region

        Private m_DataSet As CoverageDataSet
        Private m_adAdapter As CoverageDataSetTableAdapters.CCTaskLogsTableAdapter

        Private m_retailerAdapter As CoverageDataSetTableAdapters.RetTableAdapter
        Private m_mediaAdapter As CoverageDataSetTableAdapters.MediaTableAdapter
        Private m_marketAdapter As CoverageDataSetTableAdapters.MktTableAdapter
        Private m_senderAdapter As CoverageDataSetTableAdapters.SenderTableAdapter
        Private m_ccstatusAdapter As CoverageDataSetTableAdapters.CCStatusTableAdapter
        Private m_specificactionAdapter As CoverageDataSetTableAdapters.CCSpecificActionTableAdapter
        Private m_actiontypeAdapter As CoverageDataSetTableAdapters.CCActionTypeTableAdapter
        Private m_userAdapter As CoverageDataSetTableAdapters.UserTableAdapter
        Private m_urgencyAdapter As CoverageDataSetTableAdapters.CCUrgencyTableAdapter

        Private m_publicationAdapter As CoverageDataSetTableAdapters.PublicationTableAdapter

        Dim mktClicked As Boolean
        Dim sndrClicked As Boolean

        Protected ReadOnly Property UserAdapter() As CoverageDataSetTableAdapters.UserTableAdapter
            Get
                Return m_userAdapter
            End Get
        End Property


        Protected ReadOnly Property ActionTypeAdapter() As CoverageDataSetTableAdapters.CCActionTypeTableAdapter
            Get
                Return m_actiontypeAdapter
            End Get
        End Property

        Protected ReadOnly Property SpecificActionAdapter() As CoverageDataSetTableAdapters.CCSpecificActionTableAdapter
            Get
                Return m_specificactionAdapter
            End Get
        End Property

        Private ReadOnly Property CoverageAdapter() As CoverageDataSetTableAdapters.CCTaskLogsTableAdapter
            Get
                Return m_adAdapter
            End Get
        End Property

        Protected ReadOnly Property MarketAdapter() As CoverageDataSetTableAdapters.MktTableAdapter
            Get
                Return m_marketAdapter
            End Get
        End Property


        Protected ReadOnly Property PublicationAdapter() As CoverageDataSetTableAdapters.PublicationTableAdapter
            Get
                Return m_publicationAdapter
            End Get
        End Property

        Public ReadOnly Property MktAdapter() As CoverageDataSetTableAdapters.MktTableAdapter
            Get
                Return m_marketAdapter
            End Get
        End Property

        Public ReadOnly Property RetailerAdapter() As CoverageDataSetTableAdapters.RetTableAdapter
            Get
                Return m_retailerAdapter
            End Get
        End Property
        Public ReadOnly Property MediaAdapter() As CoverageDataSetTableAdapters.MediaTableAdapter
            Get
                Return m_mediaAdapter
            End Get
        End Property
        Public ReadOnly Property vwcodeAdapter() As CoverageDataSetTableAdapters.CCStatusTableAdapter
            Get
                Return m_ccstatusAdapter
            End Get
        End Property
        Public ReadOnly Property SenderAdapter() As CoverageDataSetTableAdapters.SenderTableAdapter
            Get
                Return m_senderAdapter
            End Get
        End Property
        Public ReadOnly Property UrgencyAdapter() As CoverageDataSetTableAdapters.CCUrgencyTableAdapter
            Get
                Return m_urgencyAdapter
            End Get
        End Property


        ''' <summary>
        ''' DataSet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Data() As CoverageDataSet
            Get
                Return m_DataSet
            End Get
        End Property



        Public Sub New()

            m_DataSet = New CoverageDataSet
            m_adAdapter = New CoverageDataSetTableAdapters.CCTaskLogsTableAdapter
            ' Public Sub New()

            m_mediaAdapter = New CoverageDataSetTableAdapters.MediaTableAdapter
            m_marketAdapter = New CoverageDataSetTableAdapters.MktTableAdapter
            m_publicationAdapter = New CoverageDataSetTableAdapters.PublicationTableAdapter
            m_retailerAdapter = New CoverageDataSetTableAdapters.RetTableAdapter
            m_specificactionAdapter = New CoverageDataSetTableAdapters.CCSpecificActionTableAdapter
            m_actiontypeAdapter = New CoverageDataSetTableAdapters.CCActionTypeTableAdapter
            m_userAdapter = New CoverageDataSetTableAdapters.UserTableAdapter
            m_urgencyAdapter = New CoverageDataSetTableAdapters.CCUrgencyTableAdapter

            ' End Sub
            mktClicked = False
            sndrClicked = False

        End Sub

        Public Sub Initialize()

            CoverageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

        End Sub
        Public Sub ByHourlyTime()
            Dim byHourlyTimeAdapter As CoverageDataSetTableAdapters.ByHourIntervalTableAdapter
            byHourlyTimeAdapter = New CoverageDataSetTableAdapters.ByHourIntervalTableAdapter
            byHourlyTimeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            byHourlyTimeAdapter.Fill(Data.ByHourInterval)
            byHourlyTimeAdapter.Dispose()
            byHourlyTimeAdapter = Nothing
        End Sub

        Public Sub LoadRetailer()
            Dim retailerAdapter As CoverageDataSetTableAdapters.RetTableAdapter
            retailerAdapter = New CoverageDataSetTableAdapters.RetTableAdapter
            retailerAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            retailerAdapter.FillDflt(Data.Ret)
            retailerAdapter.Dispose()
            retailerAdapter = Nothing
        End Sub

        Public Sub LoadRetailer(ByVal marketId As Integer)
            Dim retailerAdapter As CoverageDataSetTableAdapters.RetTableAdapter
            retailerAdapter = New CoverageDataSetTableAdapters.RetTableAdapter
            retailerAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            retailerAdapter.FillByMarket(Data.Ret, marketId)
            retailerAdapter.Dispose()
            retailerAdapter = Nothing
        End Sub

        'Public Sub LoadMarket(ByVal RetailerId As Integer)
        '    Dim marketAdapter As CoverageDataSetTableAdapters.MktTableAdapter
        '    marketAdapter = New CoverageDataSetTableAdapters.MktTableAdapter
        '    marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '    marketAdapter.FillByRetailer(Data.Mkt, RetailerId)
        '    marketAdapter.Dispose()
        '    marketAdapter = Nothing
        'End Sub

        Public Sub LoadMarket()
            Dim marketAdapter As CoverageDataSetTableAdapters.MktTableAdapter
            marketAdapter = New CoverageDataSetTableAdapters.MktTableAdapter
            marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            marketAdapter.FillByDflt(Data.Mkt)
            marketAdapter.Dispose()
            marketAdapter = Nothing
        End Sub

        Public Sub LoadMarketByMedia(ByVal MediaId As Integer)
            Dim marketAdapter As CoverageDataSetTableAdapters.MktTableAdapter
            marketAdapter = New CoverageDataSetTableAdapters.MktTableAdapter
            marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            marketAdapter.FillByMedia(Data.Mkt, MediaId)
            marketAdapter.Dispose()
            marketAdapter = Nothing
        End Sub

        Public Sub LoadMedia(ByVal RetailerId As Integer, ByVal MarketId As Integer)
            Dim mediaAdapter As CoverageDataSetTableAdapters.MediaTableAdapter
            mediaAdapter = New CoverageDataSetTableAdapters.MediaTableAdapter
            mediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            mediaAdapter.FillByRetailerMarket(Data.Media, RetailerId, MarketId)
            mediaAdapter.Dispose()
            mediaAdapter = Nothing
        End Sub


        Public Sub LoadMedia()
            Dim mediaAdapter As CoverageDataSetTableAdapters.MediaTableAdapter
            mediaAdapter = New CoverageDataSetTableAdapters.MediaTableAdapter
            mediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            mediaAdapter.Fill(Data.Media)
            mediaAdapter.Dispose()
            mediaAdapter = Nothing
        End Sub

        Public Sub LoadSender()
            Dim senderAdapter As CoverageDataSetTableAdapters.SenderTableAdapter
            senderAdapter = New CoverageDataSetTableAdapters.SenderTableAdapter
            senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            senderAdapter.Fill(Data.Sender)
            senderAdapter.Dispose()
            senderAdapter = Nothing
        End Sub

        Public Sub LoadSender(ByVal retailerId As String, ByVal marketId As String)
            Dim senderAdapter As CoverageDataSetTableAdapters.SenderTableAdapter
            senderAdapter = New CoverageDataSetTableAdapters.SenderTableAdapter
            senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            'senderAdapter.Fill(Data.Sender, retailerId, marketId)
            senderAdapter.Dispose()
            senderAdapter = Nothing
        End Sub

        Public Sub reLoadSender(ByVal marketId As Integer)

            Dim senderAdapter As CoverageDataSetTableAdapters.SenderTableAdapter
            senderAdapter = New CoverageDataSetTableAdapters.SenderTableAdapter
            senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            senderAdapter.FillBy(Data.Sender, marketId)
            senderAdapter.Dispose()
            senderAdapter = Nothing
        End Sub

        Public Sub reLoadMarket(ByVal senderId As Integer)

            Dim marketAdapter As CoverageDataSetTableAdapters.MktTableAdapter
            marketAdapter = New CoverageDataSetTableAdapters.MktTableAdapter
            marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            marketAdapter.FillBy(Data.Mkt, senderId)
            marketAdapter.Dispose()
            marketAdapter = Nothing

        End Sub

        Public Sub LoadPriority()
            Dim priorityAdapter As CoverageDataSetTableAdapters.PriorityTableAdapter
            priorityAdapter = New CoverageDataSetTableAdapters.PriorityTableAdapter
            priorityAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            priorityAdapter.Fill(Data.Priority)
            priorityAdapter.Dispose()
            priorityAdapter = Nothing
        End Sub

        Public Sub LoadPublication()
            Dim publicationAdapter As CoverageDataSetTableAdapters.PublicationTableAdapter
            publicationAdapter = New CoverageDataSetTableAdapters.PublicationTableAdapter
            publicationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            publicationAdapter.FillByDefualt(Data.Publication)
            publicationAdapter.Dispose()
            publicationAdapter = Nothing
        End Sub


        Public Sub LoadAssignedUsers(ByVal locationId As Integer)
            Dim userAdapter As CoverageDataSetTableAdapters.UserTableAdapter
            userAdapter = New CoverageDataSetTableAdapters.UserTableAdapter
            userAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            userAdapter.Fill(Data.User, locationId)
            userAdapter.Dispose()
            userAdapter = Nothing
        End Sub

        Public Sub LoadMedia(ByVal RetailerId As Integer)

            Dim mediaAdapter As CoverageDataSetTableAdapters.MediaTableAdapter
            mediaAdapter = New CoverageDataSetTableAdapters.MediaTableAdapter
            mediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            Data.Media.Clear()
            mediaAdapter.FillByRetailer(Data.Media, RetailerId)
            mediaAdapter.Dispose()
            mediaAdapter = Nothing
        End Sub

        Public Sub LoadMktMedia(ByVal MarketId As Integer)
            Dim mediaAdapter As CoverageDataSetTableAdapters.MediaTableAdapter
            mediaAdapter = New CoverageDataSetTableAdapters.MediaTableAdapter
            mediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            mediaAdapter.FillByMarket(Data.Media, MarketId)
            mediaAdapter.Dispose()
            mediaAdapter = Nothing
        End Sub

        Public Sub LoadRetMedia(ByVal RetailerId As Integer)
            Dim mediaAdapter As CoverageDataSetTableAdapters.MediaTableAdapter
            mediaAdapter = New CoverageDataSetTableAdapters.MediaTableAdapter
            mediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            mediaAdapter.FillByRetailer(Data.Media, RetailerId)
            mediaAdapter.Dispose()
            mediaAdapter = Nothing
        End Sub

        'Public Sub LoadSender(ByVal d As String)
        '    Dim senderAdapter As ExpectationReportDataSetTableAdapters.SenderTableAdapter
        '    senderAdapter = New ExpectationReportDataSetTableAdapters.SenderTableAdapter
        '    senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '    'senderAdapter.Fill(Data.Sender)
        '    senderAdapter.Dispose()
        '    senderAdapter = Nothing
        'End Sub

        'Public Sub LoadMedia(ByVal d As String)
        '    Dim mediaAdapter As ExpectationReportDataSetTableAdapters.MediaTableAdapter
        '    mediaAdapter = New ExpectationReportDataSetTableAdapters.MediaTableAdapter
        '    mediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '    'mediaAdapter.Fill(Data.Media)
        '    mediaAdapter.Dispose()
        '    mediaAdapter = Nothing
        'End Sub


        Public Sub LoadFrequency()
            Dim frequencyAdapter As ExpectationReportDataSetTableAdapters.vwFrequencyTableAdapter
            frequencyAdapter = New ExpectationReportDataSetTableAdapters.vwFrequencyTableAdapter
            frequencyAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            'frequencyAdapter.Fill(Data.vwFrequency)
            frequencyAdapter.Dispose()
            frequencyAdapter = Nothing
        End Sub

        Public Sub LoadCCStatus(ByVal CodeName As String)

            Dim codeAdapter As CoverageDataSetTableAdapters.CCStatusTableAdapter
            codeAdapter = New CoverageDataSetTableAdapters.CCStatusTableAdapter
            codeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            codeAdapter.Fill(Data.CCStatus, CodeName)
            codeAdapter.Dispose()
            codeAdapter = Nothing

        End Sub
        Public Sub LoadCCUrgency(ByVal CodeName As String)

            Dim codeAdapter As CoverageDataSetTableAdapters.CCUrgencyTableAdapter
            codeAdapter = New CoverageDataSetTableAdapters.CCUrgencyTableAdapter
            codeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            codeAdapter.Fill(Data.CCUrgency, CodeName)
            codeAdapter.Dispose()
            codeAdapter = Nothing

        End Sub
        Public Sub LoadCCActionType(ByVal CodeName As String)

            Dim codeAdapter As CoverageDataSetTableAdapters.CCActionTypeTableAdapter
            codeAdapter = New CoverageDataSetTableAdapters.CCActionTypeTableAdapter
            codeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            codeAdapter.Fill(Data.CCActionType, CodeName)
            codeAdapter.Dispose()
            codeAdapter = Nothing

        End Sub
        Public Sub LoadCCSpecificAction(ByVal CodeName As String)

            'Dim codeAdapter As CoverageDataSetTableAdapters.CCSpecificActionTableAdapter
            'codeAdapter = New CoverageDataSetTableAdapters.CCSpecificActionTableAdapter
            'codeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            'codeAdapter.Fill(Data.CCSpecificAction, CodeName)
            'codeAdapter.Dispose()
            'codeAdapter = Nothing

        End Sub


        'Public Sub LoadLocation()
        '    Dim locationAdapter As ExpectationReportDataSetTableAdapters.vwLocationTableAdapter

        '    locationAdapter = New ExpectationReportDataSetTableAdapters.vwLocationTableAdapter
        '    locationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '    locationAdapter.Fill(Data.vwLocation)
        '    locationAdapter.Dispose()
        '    locationAdapter = Nothing

        '    'Adding dummy location for option - "Both"
        '    Dim tempRow As ExpectationReportDataSet.vwLocationRow


        '    tempRow = Data.vwLocation.NewvwLocationRow()
        '    tempRow.CodeId = -2 'DO NOT CHANGE THIS. This value is hardcoded in mt_proc_PackageExpectationReport_PackageReceived storedprocedure.
        '    tempRow.Descrip = "Both"
        '    Data.vwLocation.AddvwLocationRow(tempRow)
        '    Data.vwLocation.AcceptChanges()
        'End Sub


        ''' <summary>
        ''' Loads market for media type Catalog.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadMarketsForCatalog(ByVal mediaId As Integer)

            RaiseEvent LoadingMarkets()

            MarketAdapter.FillForCatalog(Data.Mkt, mediaId)

            RaiseEvent MarketsLoaded()

        End Sub

        'Public Sub LoadMarket(ByVal mediaId As Integer)

        '    'RaiseEvent LoadingMarkets()

        '    MarketAdapter.LoadMarket(Data.Mkt, mediaId)

        '    'RaiseEvent MarketsLoaded()

        'End Sub

        Public Sub LoadMarket(ByVal RetailerId As Integer)
            Dim marketAdapter As CoverageDataSetTableAdapters.MktTableAdapter
            marketAdapter = New CoverageDataSetTableAdapters.MktTableAdapter
            marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            marketAdapter.FillByRetailer(Data.Mkt, RetailerId)
            marketAdapter.Dispose()
            marketAdapter = Nothing
        End Sub

        Public Function DeleteTaskLog(ByVal Original_CCTaskLogsId As Integer) As Boolean
            Dim isDeleted As Boolean
            Try
                'If MsgBox("Do you want to delete this file? click yes to continue and no if you want to cancel.", MsgBoxStyle.YesNo, "MCAP") = MsgBoxResult.Yes Then
                If MessageBox.Show("Do you want to Delete this file?Click YES to proceed and NO to cancel", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    'CoverageAdapter.Delete(Original_CCTaskLogsId)

                    MessageBox.Show("File has been Deleted", Application.ProductName, _
                                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                    isDeleted = True
                Else
                    isDeleted = False
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Exclamation, "MCAP")
                isDeleted = False
            End Try

            Return isDeleted
        End Function

        ''' <summary>
        ''' Loads publication with NA
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadNAPublicationIndex()

            'RaiseEvent LoadingPublications()

            LoadNAPublications()

            'RaiseEvent PublicationsLoaded()

        End Sub

        ''' <summary>
        ''' Loads publication based on supplied market id.
        ''' </summary>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Public Sub LoadPublication(ByVal marketId As Integer)

            'RaiseEvent LoadingPublications()

            LoadPublications(marketId)

            ' RaiseEvent PublicationsLoaded()

        End Sub

        ''' <summary>
        ''' Loads retailer based on expectation table by filtering on supplied mediaId and marketId values.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Public Sub LoadRetailer(ByVal mediaId As Integer, ByVal marketId As Integer)

            'RaiseEvent LoadingRetailers()

            LoadRetailers(mediaId, marketId)

            'RaiseEvent RetailersLoaded()

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
        ''' Load Market from Ret table using expectation table. Rows are filtered on media and market.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Public Sub LoadMarket(ByVal mediaId As Integer, ByVal retId As Integer)

            LoadMarkets(mediaId, retId)

        End Sub

        ''' <summary>
        ''' Load Market from Ret table using expectation table. Rows are filtered on media and market.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Protected Sub LoadMarkets(ByVal mediaId As Integer, ByVal retId As Integer)

            MarketAdapter.FillByMarkets(Data.Mkt, retId)

        End Sub



        ''' <summary>
        ''' Load publications from Publication table, filtered by supplied marketId.
        ''' </summary>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Protected Sub LoadPublications(ByVal marketId As Integer)

            PublicationAdapter.Fill(Data.Publication, marketId)

        End Sub

        ''' <summary>
        ''' Load publications from Publication table, Just NA
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub LoadNAPublications()

            PublicationAdapter.FillNA(Data.Publication)

        End Sub

        ''' <summary>
        ''' Load publications from Publication table, Just NA
        ''' </summary>
        ''' <remarks></remarks>
        Protected Sub LoadNAPublication()

            PublicationAdapter.FillNA(Data.Publication)

        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Public Sub LoadSpecificAction(ByVal actiontype As Integer)

            SpecificActionAdapter.Fill(Data.CCSpecificAction, actiontype)

        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Public Sub LoadUrgency(ByVal status As String)

            UrgencyAdapter.Fill(Data.CCUrgency, status)

        End Sub

        ''' <summary>
        ''' Returns a blank DataRow associated with envelope DataTable.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateNew() As CoverageDataSet.CCTaskLogsRow

            Return Data.CCTaskLogs.NewCCTaskLogsRow()

        End Function

        ''' <summary>
        ''' Inserts record into Envelope table in database.
        ''' </summary>
        ''' <param name="newRow"></param>
        ''' <exception cref="System.ApplicationException"></exception>
        ''' <remarks></remarks>
        Public Sub Add(ByVal newRow As CoverageDataSet.CCTaskLogsRow)

            ValidateValues(newRow)
            Data.CCTaskLogs.AddCCTaskLogsRow(newRow)

        End Sub

        ''' <summary>
        ''' Validate column value of supplied row.
        ''' </summary>
        ''' <param name="validateRow"></param>
        ''' <exception cref="System.ApplicationException"></exception>
        ''' <remarks></remarks>
        Private Sub ValidateValues(ByVal validateRow As CoverageDataSet.CCTaskLogsRow)

            ValidateColumnValues(validateRow)
            If validateRow.HasErrors Then Throw New System.ApplicationException("Invalid column values found.")

        End Sub

        Private Sub ValidateValues(ByVal validateTable As CoverageDataSet.CCTaskLogsDataTable)
            ' called
            Dim validateRow As CoverageDataSet.CCTaskLogsRow


            For i As Integer = 0 To validateTable.Count - 1
                validateRow = Data.CCTaskLogs.FindByCCTaskLogsId(validateTable(i).CCTaskLogsId)
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
        ''' Validates all columns of supplied DataRow.
        ''' </summary>
        ''' <param name="validateRow"></param>
        ''' <remarks></remarks>
        Private Sub ValidateColumnValues(ByVal validateRow As CoverageDataSet.CCTaskLogsRow)
            Dim isShippingInfoRequired, isTrackingNoRequired As Boolean


            validateRow.ClearErrors()

            'If validateRow.SenderRow.IsIndNoShippingNull() OrElse (validateRow.SenderRow.IndNoShipping = 0) Then
            '    isShippingInfoRequired = True
            'Else
            '    isShippingInfoRequired = False
            'End If

            If isShippingInfoRequired = False Then
                'validateRow.SetShipperIdNull()
                'validateRow.SetShippingMethodIdNull()
                'validateRow.SetTrackingNoNull()
                'validateRow.SetListedWeightNull()
                'validateRow.SetActualWeightNull()
                'validateRow.SetPackageTypeIdNull()
            Else
                'If isShippingInfoRequired AndAlso validateRow.IsPackageTypeIdNull() Then _
                '  validateRow.SetColumnError("PackageTypeId", "Package Type is not specified.")

            End If

        End Sub

        ''' <summary>
        ''' Save modified envelope information into database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Save()
            'called
            Dim rowsAffected As Integer
            Dim changesDataTable As System.Data.DataTable
            rowsAffected = 0

            changesDataTable = Data.CCTaskLogs.GetChanges()

            If changesDataTable Is Nothing Then
                Using e As UI.Processors.EventArgs = New UI.Processors.EventArgs
                    RaiseEvent NoChangesToSynchronize(Me, e)
                End Using
                Exit Sub
            End If

            ValidateValues(CType(changesDataTable, CoverageDataSet.CCTaskLogsDataTable))
            If changesDataTable.HasErrors Then
                Throw New System.ApplicationException("Invalid column values found.")
            End If

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("Changes", changesDataTable.Copy())

                RaiseEvent SynchronizingTaskLog(Me, e)

                changesDataTable.Dispose()
                changesDataTable = Nothing
                If e.Cancel Then Exit Sub
            End Using

            Try
                rowsAffected = CoverageAdapter.Update(Data.CCTaskLogs)
                Data.CCTaskLogs.AcceptChanges()

                Using e As UI.Processors.EventArgs = New UI.Processors.EventArgs
                    e.Data.Add("Changes", Data.CCTaskLogs())
                    e.Data.Add("RowsAffected", rowsAffected)

                    RaiseEvent TaskLogSynchronized(Me, e)
                End Using

            Catch ex As Exception
            End Try



        End Sub


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

                'RaiseEvent LoadingExpectedRetailers(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            RetailerAdapter.FillByMrktMedia(Data.Ret, marketId, mediaId)

            Using e As EventArgs = New EventArgs
                e.Data.Add("MediaId", mediaId)
                e.Data.Add("MarketId", marketId)
                'RaiseEvent ExpectedRetailersLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Loads retailers based on supplied mediaId and marketId.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Public Sub LoadRetailerLists(ByVal mediaId As Integer, ByVal marketId As Integer)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Cancel = False
                e.Data.Add("MediaId", mediaId)
                e.Data.Add("MarketId", marketId)

                'RaiseEvent LoadingRetailers(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            RetailerAdapter.FillByMrktMedia(Data.Ret, mediaId, marketId)

            Using e As EventArgs = New EventArgs
                e.Data.Add("MediaId", mediaId)
                e.Data.Add("MarketId", marketId)
                'RaiseEvent PublicationsLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Gets image folder for supplied vehicle Id.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <exception cref="System.ApplicationException">Raises exception when CreateDt column value is null.</exception>
        ''' <remarks></remarks>
        Public Function getMissingAdLabelId() As String

            Return getMissingAdLabelIdValue()

        End Function

        ''' <summary>
        ''' Gets image folder for supplied vehicle Id.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <exception cref="System.ApplicationException">Raises exception when CreateDt column value is null.</exception>
        ''' <remarks></remarks>
        Public Function getSavedDate(ByVal tasklogid As Integer) As Date

            Return getSaveDate(tasklogid)

        End Function

        ''' <summary>
        ''' Gets number of records for missing ad id.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getSaveDate(ByVal tasklogid As Integer) As Date

            Dim savedDate As Nullable(Of Date)

            savedDate = CoverageAdapter.getLastSavedDate(tasklogid)

            If savedDate Is Nothing Then
                Return Nothing 'String.Empty
            Else
                Return CType(savedDate, Date)
            End If

        End Function

        ''' <summary>
        ''' Gets image folder for supplied vehicle Id.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <exception cref="System.ApplicationException">Raises exception when CreateDt column value is null.</exception>
        ''' <remarks></remarks>
        Public Function getSavedUser(ByVal _tasklogid As Integer) As String

            Return getSaveUser(_tasklogid)

        End Function

        ''' <summary>
        ''' Gets number of records for missing ad id.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getSaveUser(ByVal _tasklogid As Integer) As String

            Dim savedUser As Nullable(Of Integer)
            'Dim savedUser As String

            savedUser = CoverageAdapter.getLastSavedUser(_tasklogid)

            If savedUser Is Nothing Then
                Return Nothing 'String.Empty
            Else
                Return CType(savedUser, String)
            End If

        End Function



        ''' <summary>
        ''' Gets number of records for missing ad id.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getMissingAdLabelIdValue() As String
            Dim missingAdId As Nullable(Of Integer)


            missingAdId = CoverageAdapter.getMissingAdLabelValue()

            If missingAdId Is Nothing Then
                Return String.Empty
            Else
                Return CType(missingAdId, String)
            End If

        End Function

        Public Function getUserName(ByVal userId As Integer) As String
            Dim userName As String

            userName = UserAdapter.getSaveName(userId).ToString()

            If userName Is Nothing Then
                userName = String.Empty
            End If

            Return userName

        End Function

        Public Sub LoadVehicle(ByVal vehicleId As Integer, ByVal formName As String)
            Dim errorMessage As String


            RaiseEvent LoadingTaskLogId(vehicleId)

            CoverageAdapter.FillByTaskLogId(Data.CCTaskLogs, vehicleId)

            If Data.CCTaskLogs.Count = 0 AndAlso errorMessage Is Nothing Then
                RaiseEvent TaskLogIdNotFound(vehicleId)
            ElseIf Data.CCTaskLogs.Count = 0 AndAlso errorMessage IsNot Nothing Then
                RaiseEvent InvalidTaskLogIdStatus(errorMessage)
            Else
                RaiseEvent TaskLogIdLoaded(Data.CCTaskLogs(0))
            End If

        End Sub

        Public Sub FillByTaskLogId(ByVal taskLogId As Integer)
            Dim errorMessage As String


            RaiseEvent LoadingTaskLogId(taskLogId)

            CoverageAdapter.FillByTaskLogId(Data.CCTaskLogs, taskLogId)

            If Data.CCTaskLogs.Count = 0 AndAlso errorMessage Is Nothing Then
                RaiseEvent TaskLogIdNotFound(taskLogId)
            ElseIf Data.CCTaskLogs.Count = 0 AndAlso errorMessage IsNot Nothing Then
                RaiseEvent InvalidTaskLogIdStatus(errorMessage)
            Else
                RaiseEvent TaskLogIdLoaded(Data.CCTaskLogs(0))
            End If

        End Sub

    End Class

End Namespace
