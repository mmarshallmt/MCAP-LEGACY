
Namespace UI.Processors

    Public Class MissingAdLog
        Inherits BaseClass

#Region " Events"
        Public Event ValidatingColumnValues As MCAPCancellableEventHandler
        Public Event ColumnValuesValidated As MCAPEventHandler
        Public Event InvalidColumnValueFound As MCAPEventHandler

        Public Event NoChangesToSynchronize As MCAPEventHandler
        Public Event Synchronizing As MCAPCancellableEventHandler
        Public Event Synchronized As MCAPEventHandler

        Public Event SynchronizingTaskLog As MCAPCancellableEventHandler
        Public Event TaskLogSynchronized As MCAPEventHandler

        Public Event LoadingMissingAd(ByVal MissingAdId As Integer)
        Public Event MissingAdLoaded(ByVal missingRow As CoverageDataSet.CCMissingAdLogsRow)
        Public Event MissingAdNotFound(ByVal MissingAdId As Integer)
        Public Event InvalidMissingAdStatus(ByVal statusText As String)

        Public Event LoadingMarkets()
        Public Event MarketsLoaded()

        Public Event LoadingRetailers()
        Public Event RetailersLoaded()

        Public Event LoadingSenders()
        Public Event SendersLoaded()



#End Region



        Private m_DataSet As CoverageDataSet
        Private m_adAdapter As CoverageDataSetTableAdapters.CCMissingAdLogsTableAdapter

        Private m_retailerAdapter As CoverageDataSetTableAdapters.RetTableAdapter
        Private m_mediaAdapter As CoverageDataSetTableAdapters.MediaTableAdapter
        Private m_marketAdapter As CoverageDataSetTableAdapters.MktTableAdapter
        Private m_senderAdapter As CoverageDataSetTableAdapters.SenderTableAdapter
        Private m_ccstatusAdapter As CoverageDataSetTableAdapters.CCStatusTableAdapter
        Private m_expectationAdapter As CoverageDataSetTableAdapters.MediaTableAdapter

        Private m_publicationAdapter As CoverageDataSetTableAdapters.PublicationTableAdapter
        Private m_userAdapter As CoverageDataSetTableAdapters.UserTableAdapter

        Dim mktClicked As Boolean
        Dim sndrClicked As Boolean
        Dim MissingAdId As Integer


        Protected ReadOnly Property UserAdapter() As CoverageDataSetTableAdapters.UserTableAdapter
            Get
                Return m_userAdapter
            End Get
        End Property

        Protected ReadOnly Property ExpectationAdapter() As CoverageDataSetTableAdapters.MediaTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property


        Private ReadOnly Property CoverageAdapter() As CoverageDataSetTableAdapters.CCMissingAdLogsTableAdapter
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
        Public ReadOnly Property SenderAdapter() As CoverageDataSetTableAdapters.SenderTableAdapter 'CoverageDataSetTableAdapters.SenderTableAdapter
            Get
                Return m_senderAdapter
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
            m_adAdapter = New CoverageDataSetTableAdapters.CCMissingAdLogsTableAdapter
            ' Public Sub New()

            m_mediaAdapter = New CoverageDataSetTableAdapters.MediaTableAdapter
            m_marketAdapter = New CoverageDataSetTableAdapters.MktTableAdapter
            m_publicationAdapter = New CoverageDataSetTableAdapters.PublicationTableAdapter
            m_retailerAdapter = New CoverageDataSetTableAdapters.RetTableAdapter
            m_senderAdapter = New CoverageDataSetTableAdapters.SenderTableAdapter
            m_userAdapter = New CoverageDataSetTableAdapters.UserTableAdapter
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

        Public Sub LoadMarket(ByVal RetailerId As Integer)
            Dim marketAdapter As CoverageDataSetTableAdapters.MktTableAdapter
            marketAdapter = New CoverageDataSetTableAdapters.MktTableAdapter
            marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            marketAdapter.FillByRetailer(Data.Mkt, RetailerId)
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

        Public Sub LoadMedia(ByVal RetailerId As Integer)
            Dim mediaAdapter As CoverageDataSetTableAdapters.MediaTableAdapter
            mediaAdapter = New CoverageDataSetTableAdapters.MediaTableAdapter
            mediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            mediaAdapter.FillByRetailer(Data.Media, RetailerId)
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

        Public Sub LoadMktMedia(ByVal MarketId As Integer)
            Dim mediaAdapter As CoverageDataSetTableAdapters.MediaTableAdapter
            mediaAdapter = New CoverageDataSetTableAdapters.MediaTableAdapter
            mediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            mediaAdapter.FillByMarket(Data.Media, MarketId)
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

        Public Sub LoadSender()
            Dim senderAdapter As CoverageDataSetTableAdapters.SenderTableAdapter
            senderAdapter = New CoverageDataSetTableAdapters.SenderTableAdapter
            senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            senderAdapter.Fill(Data.Sender)
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

        Public Sub LoadLtResolution(ByVal CodeName As String)
            Dim ltResolutionAdapter As CoverageDataSetTableAdapters.LtResolutionTableAdapter
            ltResolutionAdapter = New CoverageDataSetTableAdapters.LtResolutionTableAdapter
            ltResolutionAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            ltResolutionAdapter.Fill(Data.LtResolution, CodeName)
            ltResolutionAdapter.Dispose()
            ltResolutionAdapter = Nothing
        End Sub

        Public Sub LoadRtResolution(ByVal CodeName As String)
            Dim rtResolutionAdapter As CoverageDataSetTableAdapters.RtResolutionTableAdapter
            rtResolutionAdapter = New CoverageDataSetTableAdapters.RtResolutionTableAdapter
            rtResolutionAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            rtResolutionAdapter.Fill(Data.RtResolution, CodeName)
            rtResolutionAdapter.Dispose()
            rtResolutionAdapter = Nothing
        End Sub
        Public Sub LoadRootCause(ByVal CodeName As String)
            Dim rootCauseAdapter As CoverageDataSetTableAdapters.RootCauseTableAdapter
            rootCauseAdapter = New CoverageDataSetTableAdapters.RootCauseTableAdapter
            rootCauseAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            rootCauseAdapter.Fill(Data.RootCause, CodeName)
            rootCauseAdapter.Dispose()
            rootCauseAdapter = Nothing
        End Sub


        Public Sub LoadAssignedUsers(ByVal locationId As Integer)
            Dim userAdapter As CoverageDataSetTableAdapters.UserTableAdapter
            userAdapter = New CoverageDataSetTableAdapters.UserTableAdapter
            userAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            userAdapter.Fill(Data.User, locationId)
            userAdapter.Dispose()
            userAdapter = Nothing
        End Sub

        Public Sub LoadExpectationComments(ByVal d As String)
            Dim mediaAdapter As ExpectationReportDataSetTableAdapters.MediaTableAdapter
            mediaAdapter = New ExpectationReportDataSetTableAdapters.MediaTableAdapter
            mediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            'mediaAdapter.Fill(Data.Media)
            mediaAdapter.Dispose()
            mediaAdapter = Nothing
        End Sub

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

        Public Sub LoadPublication()
            Dim publicationAdapter As CoverageDataSetTableAdapters.PublicationTableAdapter
            publicationAdapter = New CoverageDataSetTableAdapters.PublicationTableAdapter
            publicationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            publicationAdapter.FillByDefualt(Data.Publication)
            publicationAdapter.Dispose()
            publicationAdapter = Nothing
        End Sub


        ''' <summary>
        ''' Gets image folder for supplied vehicle Id.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <exception cref="System.ApplicationException">Raises exception when CreateDt column value is null.</exception>
        ''' <remarks></remarks>
        Public Function getSavedDate(ByVal missingid As Integer) As Date

            Return getSaveDate(missingid)

        End Function

        ''' <summary>
        ''' Gets number of records for missing ad id.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getSaveDate(ByVal missingid As Integer) As Date

            Dim savedDate As Nullable(Of Date)
            Dim tempAdapter As CoverageDataSetTableAdapters.CCMissingAdLogsTableAdapter


            tempAdapter = New CoverageDataSetTableAdapters.CCMissingAdLogsTableAdapter()
            'tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Try
                savedDate = CoverageAdapter.getLastSavedDate(missingid)
            Catch Ex As Exception

            End Try


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
        Public Function getSavedUser(ByVal missingid As Integer) As String

            Return getSaveUser(missingid)

        End Function

        Public Function DeleteMissingAdLog(ByVal Original_CCMissingAdLogId As Integer) As Boolean
            Dim isDeleted As Boolean
            Try
                'If MsgBox("Do you want to delete this file? click yes to continue and no if you want to cancel.", MsgBoxStyle.YesNo, "MCAP") = MsgBoxResult.Yes Then
                If MessageBox.Show("Do you want to Delete this file?Click YES to proceed and NO to cancel", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    'CoverageAdapter.Delete(Original_CCMissingAdLogId)

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
        ''' Gets number of records for missing ad id.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getSaveUser(ByVal _missingadid As Integer) As String


            Dim savedUser As Nullable(Of Integer)
            'Dim savedUser As String
            savedUser = 0 'String.Empty
            Dim tempAdapter As CoverageDataSetTableAdapters.CCMissingAdLogsTableAdapter


            tempAdapter = New CoverageDataSetTableAdapters.CCMissingAdLogsTableAdapter()
            'tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Try
                savedUser = CoverageAdapter.getLastSavedUser(_missingadid)
            Catch Ex As Exception
            End Try

            If savedUser Is Nothing Then
                Return Nothing 'String.Empty
            Else
                Return CType(savedUser, String)
            End If

        End Function



        ''' <summary>
        ''' Loads market for media type Catalog.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadMarketsForCatalog(ByVal mediaId As Integer)

            RaiseEvent LoadingMarkets()

            MarketAdapter.FillForCatalog(Data.Mkt, mediaId)

            RaiseEvent MarketsLoaded()

        End Sub

        ''' <summary>
        ''' Loads publication with NA
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadNAPublicationIndex()

            'RaiseEvent LoadingPublications()

            LoadNAPublication()

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

            RaiseEvent LoadingRetailers()

            LoadRetailers(mediaId, marketId)

            RaiseEvent RetailersLoaded()

        End Sub

        ''' <summary>
        ''' Load retailers from Ret table using expectation table. Rows are filtered on media and market.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Protected Sub LoadRetailers(ByVal mediaId As Integer, ByVal marketId As Integer)

            RaiseEvent LoadingRetailers()

            RetailerAdapter.Fill(Data.Ret, mediaId, marketId)

            RaiseEvent RetailersLoaded()

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
        Protected Sub LoadNAPublication()

            PublicationAdapter.FillNA(Data.Publication)

        End Sub
        ''' <summary>
        ''' Gets string value for Expectation Comments.
        ''' </summary>
        ''' <param name="retailerId"></param>
        ''' <param name="marketId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getSenderComments(ByVal vehicleId As Integer, ByVal retailerId As Integer, ByVal marketId As Integer, ByVal mediaId As Integer) As String
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
        ''' Gets Comments from Expectation table based on supplied retailer, market and media.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <param name="retailerId"></param>
        ''' <remarks></remarks>
        Public Function GetSenderCommentsText(ByVal senderId As Integer, ByVal mediaId As Integer, ByVal marketId As Integer, ByVal retailerId As Integer) As String
            Dim rtrnVals As String
            Dim commentsText As String

            rtrnVals = SenderAdapter.getComments(mediaId, marketId, retailerId)
            If rtrnVals Is Nothing Then
                commentsText = String.Empty
            Else
                commentsText = rtrnVals.ToString()
            End If
            Return rtrnVals

        End Function

        ''' <summary>
        ''' Gets priority from Expectation table based on supplied retailer, market and media.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <param name="retailerId"></param>
        ''' <remarks></remarks>
        Public Function GetSenderPriority(ByVal senderId As Integer, ByVal mediaId As Integer, ByVal marketId As Integer, ByVal retailerId As Integer) As String
            Dim priority As Integer?
            Dim priorityText As String


            priority = SenderAdapter.getSenderPriority(mediaId, marketId, retailerId)
            If priority.HasValue = False OrElse priority.Value < 1 Then
                priorityText = String.Empty
            Else
                priorityText = priority.Value.ToString()
            End If

            Return priorityText

        End Function

        ''' <summary>
        ''' Gets priority from Expectation table based on supplied retailer, market and media.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <param name="retailerId"></param>
        ''' <remarks></remarks>
        Public Function GetSenderFrequency(ByVal senderId As Integer, ByVal mediaId As Integer, ByVal marketId As Integer, ByVal retailerId As Integer) As String
            Dim expectation As String
            Dim expectationText As String


            expectation = SenderAdapter.getSenderFrequency(mediaId, marketId, retailerId)
            If expectation Is Nothing Then
                expectationText = String.Empty
            Else
                expectationText = expectation.ToString()
            End If

            Return expectationText

        End Function

        ''' <summary>
        ''' Returns a blank DataRow associated with envelope DataTable.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateNew() As CoverageDataSet.CCMissingAdLogsRow

            Return Data.CCMissingAdLogs.NewCCMissingAdLogsRow()

        End Function

        ''' <summary>
        ''' Inserts record into Envelope table in database.
        ''' </summary>
        ''' <param name="newRow"></param>
        ''' <exception cref="System.ApplicationException"></exception>
        ''' <remarks></remarks>
        Public Sub Add(ByVal newRow As CoverageDataSet.CCMissingAdLogsRow)

            ValidateValues(newRow)
            Data.CCMissingAdLogs.AddCCMissingAdLogsRow(newRow)

        End Sub

        ''' <summary>
        ''' Validate column value of supplied row.
        ''' </summary>
        ''' <param name="validateRow"></param>
        ''' <exception cref="System.ApplicationException"></exception>
        ''' <remarks></remarks>
        Private Sub ValidateValues(ByVal validateRow As CoverageDataSet.CCMissingAdLogsRow)

            ValidateColumnValues(validateRow)
            If validateRow.HasErrors Then Throw New System.ApplicationException("Invalid column values found.")

        End Sub

        Private Sub ValidateValues(ByVal validateTable As CoverageDataSet.CCMissingAdLogsDataTable)
            Dim validateRow As CoverageDataSet.CCMissingAdLogsRow
            'validateRow = Data.vwCircular.FindByVehicleId(validateTable(i).VehicleId)


            For i As Integer = 0 To validateTable.Count - 1
                'validateRow = Data.CCTaskLogs.f.AddCCTaskLogs  RowFillByAdId(validateTable(i).MissingAd)
                'validateRow = Data.vwCircular.FindByVehicleId(validateTable(i).VehicleId)
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
        Private Sub ValidateColumnValues(ByVal validateRow As CoverageDataSet.CCMissingAdLogsRow)
            Dim isShippingInfoRequired, isTrackingNoRequired As Boolean


            validateRow.ClearErrors()

            'If validateRow.SenderRow.IsIndNoShippingNull() OrElse (validateRow.SenderRow.IndNoShipping = 0) Then
            '    isShippingInfoRequired = True
            'Else
            '    isShippingInfoRequired = False
            'End If

            If isShippingInfoRequired = False Then

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
            Dim rowsAffected As Integer
            Dim changesDataTable As System.Data.DataTable


            changesDataTable = Data.CCMissingAdLogs.GetChanges()

            If changesDataTable Is Nothing Then
                Using e As UI.Processors.EventArgs = New UI.Processors.EventArgs
                    RaiseEvent NoChangesToSynchronize(Me, e)
                End Using
                Exit Sub
            End If

            ValidateValues(CType(changesDataTable, CoverageDataSet.CCMissingAdLogsDataTable))
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

            rowsAffected = CoverageAdapter.Update(Data.CCMissingAdLogs)
            Data.CCTaskLogs.AcceptChanges()

            Using e As UI.Processors.EventArgs = New UI.Processors.EventArgs
                e.Data.Add("Changes", Data.CCTaskLogs())
                e.Data.Add("RowsAffected", rowsAffected)

                RaiseEvent TaskLogSynchronized(Me, e)
            End Using

        End Sub




        Function getNextAdIdNumber() As String


        End Function


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
        ''' Gets number of records for missing ad id.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getMissingAdLabelIdValue() As String
            Dim missingAdId As Nullable(Of Integer)


            missingAdId = CType(CoverageAdapter.getMissingAdLabelValue(), Integer)

            If missingAdId Is Nothing Then
                Return String.Empty
            Else
                Return CType(missingAdId, String)
            End If

        End Function

        Public Function getUserName(ByVal userId As Integer) As String
            Dim userName As String
            'Dim publicationAdapter As CoverageDataSetTableAdapters.PublicationTableAdapter
            Dim tempAdapter As CoverageDataSetTableAdapters.UserTableAdapter
            tempAdapter = New CoverageDataSetTableAdapters.UserTableAdapter

            userName = tempAdapter.getSaveName(userId).ToString()

            If userName Is Nothing Then
                userName = String.Empty
            End If

            Return userName

        End Function


        Public Sub LoadVehicle(ByVal vehicleId As Integer, ByVal formName As String)
            Dim errorMessage As String


            RaiseEvent LoadingMissingAd(vehicleId)

            CoverageAdapter.FillBy(Data.CCMissingAdLogs, vehicleId)

            If Data.CCMissingAdLogs.Count = 0 AndAlso errorMessage Is Nothing Then
                RaiseEvent MissingAdNotFound(vehicleId)
            ElseIf Data.CCMissingAdLogs.Count = 0 AndAlso errorMessage IsNot Nothing Then
                RaiseEvent InvalidMissingAdStatus(errorMessage)
            Else
                RaiseEvent MissingAdLoaded(Data.CCMissingAdLogs(0))
            End If

        End Sub

        Public Sub FillByMissingId(ByVal taskLogId As Integer)
            Dim errorMessage As String


            RaiseEvent LoadingMissingAd(taskLogId)

            CoverageAdapter.FillBy(Data.CCMissingAdLogs, taskLogId)

            If Data.CCMissingAdLogs.Count = 0 AndAlso errorMessage Is Nothing Then
                RaiseEvent MissingAdNotFound(taskLogId)
            ElseIf Data.CCMissingAdLogs.Count = 0 AndAlso errorMessage IsNot Nothing Then
                RaiseEvent InvalidMissingAdStatus(errorMessage)
            Else
                RaiseEvent MissingAdLoaded(Data.CCMissingAdLogs(0))
            End If

        End Sub

        Public Sub Load(ByVal missingAdID As Integer)
            Dim envelopeCount As Nullable(Of Integer)
            Dim locationId As Object



            locationId = Nothing

        End Sub

    End Class

End Namespace
