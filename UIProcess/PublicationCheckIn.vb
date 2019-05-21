Namespace UI.Processors

    Public Class PublicationCheckIn
        Inherits BaseClass



#Region " Events "


        'Events can be extended to supply necessary information to consumer along with events.
        'Information passed into event can be useful to consumer while processing the event.

        Public Event Initializing()
        Public Event Initialized()

        Public Event LoadingData As MCAPCancellableEventHandler
        Public Event DataLoaded As MCAPEventHandler

        Public Event LoadingSenderMarketAssociations As MCAPCancellableEventHandler
        Public Event SenderMarketAssociationsLoaded As MCAPEventHandler

        Public Event LoadingMarkets As MCAPCancellableEventHandler
        Public Event MarketsLoaded As MCAPEventHandler

        Public Event LoadingPublications As MCAPCancellableEventHandler
        Public Event PublicationsLoaded As MCAPEventHandler

        Public Event ValidatingInputs As MCAPCancellableEventHandler
        Public Event InputsValidated As MCAPEventHandler
        Public Event InvalidInputExist As MCAPEventHandler

        Public Event Synchronizing As MCAPCancellableEventHandler
        Public Event Synchronized As MCAPEventHandler

        'Public Event LoadingVehicle(ByVal vehicleId As Integer)
        'Public Event VehicleLoaded(ByVal vehicleRow As PublicationCheckInDataSet.vwPublicationEditionRow)
        'Public Event VehicleNotFound(ByVal vehicleId As Integer)
        'Public Event InvalidVehicleStatus(ByVal vehicleId As Integer, ByVal statusText As String)
        Public Event LoadingVehicle As MCAPCancellableEventHandler
        Public Event VehicleLoaded As MCAPEventHandler
        Public Event VehicleNotFound As MCAPEventHandler
        Public Event InvalidVehicleStatus As MCAPEventHandler

        Public Event PrintingBarcode As MCAPCancellableEventHandler
        Public Event BarcodePrinted As MCAPEventHandler


#End Region



        Private m_barcodePrinter As String
        Private m_publicationCheckInDataSet As PublicationCheckInDataSet
        Private m_languageAdapter As PublicationCheckInDataSetTableAdapters.LanguageTableAdapter
        Private m_senderAdapter As PublicationCheckInDataSetTableAdapters.SenderTableAdapter
        Private m_senderMktAssocAdapter As PublicationCheckInDataSetTableAdapters.SenderMktAssocTableAdapter
        Private m_marketAdapter As PublicationCheckInDataSetTableAdapters.MktTableAdapter
        Private m_publicationAdapter As PublicationCheckInDataSetTableAdapters.PublicationTableAdapter
        Private m_vwVehicleStatusAdapter As PublicationCheckInDataSetTableAdapters.vwVehicleStatusTableAdapter
        Private m_vwPublicationEdition As PublicationCheckInDataSetTableAdapters.vwPublicationEditionTableAdapter



        ''' <summary>
        ''' Default constructor.
        ''' </summary>
        ''' <remarks></remarks>
        Sub New()

            m_publicationCheckInDataSet = New PublicationCheckInDataSet
            m_languageAdapter = New PublicationCheckInDataSetTableAdapters.LanguageTableAdapter
            m_senderAdapter = New PublicationCheckInDataSetTableAdapters.SenderTableAdapter
            m_senderMktAssocAdapter = New PublicationCheckInDataSetTableAdapters.SenderMktAssocTableAdapter
            m_marketAdapter = New PublicationCheckInDataSetTableAdapters.MktTableAdapter
            m_publicationAdapter = New PublicationCheckInDataSetTableAdapters.PublicationTableAdapter
            m_vwVehicleStatusAdapter = New PublicationCheckInDataSetTableAdapters.vwVehicleStatusTableAdapter
            m_vwPublicationEdition = New PublicationCheckInDataSetTableAdapters.vwPublicationEditionTableAdapter

        End Sub



        ''' <summary>
        ''' Gets instance of PublicationCheckInDataset.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Data() As PublicationCheckInDataSet
            Get
                Return m_publicationCheckInDataSet
            End Get
        End Property

        ''' <summary>
        ''' Gets table adapter for Language table.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property LanguageAdapter() As PublicationCheckInDataSetTableAdapters.LanguageTableAdapter
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
        Private ReadOnly Property SenderAdapter() As PublicationCheckInDataSetTableAdapters.SenderTableAdapter
            Get
                Return m_senderAdapter
            End Get
        End Property

        ''' <summary>
        ''' Gets table adapter for SenderMktAssoc table.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property SenderMktAdapter() As PublicationCheckInDataSetTableAdapters.SenderMktAssocTableAdapter
            Get
                Return m_senderMktAssocAdapter
            End Get
        End Property

        ''' <summary>
        ''' Gets table adapter for Mkt table.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property MarketAdapter() As PublicationCheckInDataSetTableAdapters.MktTableAdapter
            Get
                Return m_marketAdapter
            End Get
        End Property

        ''' <summary>
        ''' Gets table adapter for Publication table.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property PublicationAdapter() As PublicationCheckInDataSetTableAdapters.PublicationTableAdapter
            Get
                Return m_publicationAdapter
            End Get
        End Property

        ''' <summary>
        ''' Gets instance of vwVehicleStaus data table adapter.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property VehicleStatusAdapter() As PublicationCheckInDataSetTableAdapters.vwVehicleStatusTableAdapter
            Get
                Return m_vwVehicleStatusAdapter
            End Get
        End Property

        ''' <summary>
        ''' Gets instance of vwPublicationEdition.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property VehicleAdapter() As PublicationCheckInDataSetTableAdapters.vwPublicationEditionTableAdapter
            Get
                Return m_vwPublicationEdition
            End Get
        End Property



        ''' <summary>
        ''' Initializes object of this class.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Initialize()

            RaiseEvent Initializing()

            m_languageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_senderMktAssocAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_publicationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_vwVehicleStatusAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_vwPublicationEdition.Connection.ConnectionString = GetConnectionStringForAppDB()

            RaiseEvent Initialized()

        End Sub


        ''' <summary>
        ''' Prints barcode label based on supplied row.
        ''' </summary>
        ''' <param name="barcodeRow"></param>
        ''' <remarks></remarks>
        Public Sub PrintBarcode(ByVal barcodeRow As PublicationCheckInDataSet.vwPublicationEditionRow)
            Dim duplicateStatusId, scanDPI As Integer
            Dim labelPrint As MCAP.PublicationLabelPrint


            duplicateStatusId = GetStatusIdForDuplicate()
            'scanDPI = Me.get

            labelPrint = New MCAP.PublicationLabelPrint()

            labelPrint.PrinterName = BarcodePrinterName
            labelPrint.IsDuplicate = (barcodeRow.StatusID = duplicateStatusId)
            labelPrint.NewspaperDate = barcodeRow.BreakDt
            labelPrint.Publication = barcodeRow.PublicationRow.Descrip
            labelPrint.ScanDPI = scanDPI

            labelPrint.VehicleId = barcodeRow.VehicleId

            If (barcodeRow.IsPriorityNull()) Then
                labelPrint.PriorityId = String.Empty
            Else
                labelPrint.PriorityId = barcodeRow.Priority.ToString()

            End If


            labelPrint.Print()

            labelPrint.Dispose()
            labelPrint = Nothing
        End Sub


        Public Function AreInputsValid(ByVal validateRow As PublicationCheckInDataSet.vwPublicationEditionRow) As Boolean

            Using e As CancellableEventArgs = New CancellableEventArgs
                RaiseEvent ValidatingInputs(Me, e)
                If e.Cancel Then
                    e.Data.Clear()
                    Exit Function
                End If
            End Using

            If validateRow.IsBreakDtNull() Then
                validateRow.SetColumnError("BreakDt", "Ad date cannot have blank value.")
            Else
                validateRow.SetColumnError("BreakDt", String.Empty)
            End If

            If validateRow.IsSenderIdNull() Then
                validateRow.SetColumnError("SenderId", "Sender cannot have blank value.")
            Else
                validateRow.SetColumnError("SenderId", String.Empty)
            End If

            If validateRow.IsMktIdNull() Then
                validateRow.SetColumnError("MktId", "Market cannot have blank value.")
            Else
                validateRow.SetColumnError("MktId", String.Empty)
            End If

            If validateRow.IsPublicationIdNull() Then
                validateRow.SetColumnError("PublicationId", "Publication cannot have blank value.")
            Else
                validateRow.SetColumnError("PublicationId", String.Empty)
            End If

            If validateRow.IsLanguageIdNull() Then
                validateRow.SetColumnError("LanguageId", "Language cannot have blank value.")
            Else
                validateRow.SetColumnError("LanguageId", String.Empty)
            End If

            If validateRow.IsWeightNull() Then
                validateRow.SetColumnError("Weight", "Weight cannot have blank value.")
            ElseIf validateRow.Weight <= 0 Then
                validateRow.SetColumnError("Weight", "Weight should be a positive value.")
            Else
                validateRow.SetColumnError("Weight", String.Empty)
            End If


            If validateRow.HasErrors Then
                Using e As EventArgs = New EventArgs
                    RaiseEvent InvalidInputExist(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    RaiseEvent InputsValidated(Me, e)
                End Using
            End If


            Return validateRow.HasErrors

        End Function



        ''' <summary>
        ''' Loads data tables required at initial stage.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadDataSet()
            Try

                Using e As CancellableEventArgs = New CancellableEventArgs
                    RaiseEvent LoadingData(Me, e)
                    If e.Cancel Then
                        Exit Sub
                    End If
                End Using

                LanguageAdapter.Fill(Data.Language)
                SenderAdapter.Fill(Data.Sender, UserLocationId)
                VehicleStatusAdapter.Fill(Data.vwVehicleStatus)

                Using e As EventArgs = New EventArgs
                    RaiseEvent DataLoaded(Me, e)
                End Using
            Catch ex As Exception

            End Try
        End Sub


        ''' <summary>
        ''' Loads rows from SenderMarketAssoc table based on supplied sender Id.
        ''' </summary>
        ''' <param name="senderId"></param>
        ''' <remarks></remarks>
        Protected Sub LoadSenderMarketAssociations(ByVal senderId As Integer)

            Using e As CancellableEventArgs = New CancellableEventArgs
                RaiseEvent LoadingSenderMarketAssociations(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            SenderMktAdapter.Fill(Data.SenderMktAssoc, senderId)

            Using e As EventArgs = New EventArgs
                RaiseEvent SenderMarketAssociationsLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Loads markets based on supplied sender id.
        ''' </summary>
        ''' <param name="senderId"></param>
        ''' <remarks></remarks>
        Protected Sub LoadMarkets(ByVal senderId As Integer)

            Using e As CancellableEventArgs = New CancellableEventArgs
                RaiseEvent LoadingMarkets(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            MarketAdapter.Fill(Data.Mkt, senderId)

            Using e As EventArgs = New EventArgs
                RaiseEvent MarketsLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Loads market based on supplied sender Id, using SenderMktAssoc table.
        ''' </summary>
        ''' <param name="senderId"></param>
        ''' <remarks></remarks>
        Public Sub LoadMarketsForSender(ByVal senderId As Integer)

            LoadSenderMarketAssociations(senderId)
            LoadMarkets(senderId)

        End Sub


        ''' <summary>
        ''' Loads publication based on supplied market id value.
        ''' </summary>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Public Sub LoadPublicationsForMarket(ByVal marketId As Integer)

            Using e As CancellableEventArgs = New CancellableEventArgs
                RaiseEvent LoadingPublications(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            PublicationAdapter.Fill(Data.Publication, marketId)

            Using e As EventArgs = New EventArgs
                RaiseEvent PublicationsLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Gets boolean value indicating whether there exist any rows with supplied parameter values.
        ''' </summary>
        ''' <param name="senderId"></param>
        ''' <param name="marketId"></param>
        ''' <param name="publicationId"></param>
        ''' <param name="breakDt"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsDuplicate(ByVal senderId As Integer, ByVal marketId As Integer, ByVal publicationId As Integer, ByVal breakDt As DateTime, ByVal vehicleId As Nullable(Of Integer)) As Boolean
            Dim recCount As Object


            recCount = VehicleAdapter.GetDupRecordCountForSameSender(senderId, marketId, publicationId, breakDt, vehicleId)

            If recCount Is Nothing OrElse recCount Is DBNull.Value OrElse recCount.ToString() = "0" Then
                recCount = Nothing
                Return False
            Else
                recCount = Nothing
                Return True
            End If

        End Function

        ''' <summary>
        ''' Gets boolean value indicating whether there exist any rows with supplied parameter values.
        ''' </summary>
        ''' <param name="marketId"></param>
        ''' <param name="publicationId"></param>
        ''' <param name="breakDt"></param>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsDuplicate(ByVal marketId As Integer, ByVal publicationId As Integer, ByVal breakDt As DateTime, ByVal vehicleId As Nullable(Of Integer)) As Boolean
            Dim recCount As Object


            recCount = VehicleAdapter.GetDupRecordCount(marketId, breakDt, publicationId, vehicleId)

            If recCount Is Nothing OrElse recCount Is DBNull.Value OrElse recCount.ToString() = "0" Then
                recCount = Nothing
                Return False
            Else
                recCount = Nothing
                Return True
            End If

        End Function

        ''' <summary>
        ''' Returns true if publication is marked as No Drop.
        ''' </summary>
        ''' <param name="marketId"></param>
        ''' <param name="publicationId"></param>
        ''' <param name="breakDt"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsMarkedAsNoDrop(ByVal marketId As Integer, ByVal publicationId As Integer, ByVal breakDt As DateTime) As Boolean
            Dim nodropCount As Integer?


            nodropCount = VehicleAdapter.GetNoDropCount(marketId, publicationId, breakDt)

            Return (nodropCount.HasValue AndAlso nodropCount.Value > 0)

        End Function


        ''' <summary>
        ''' Gets statusId column value for duplicate publication.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetStatusIdForDuplicate() As Integer
            Dim statusId As Nullable(Of Integer)


            statusId = VehicleAdapter.GetVehicleStatusId("Duplicate Publication")

            If statusId Is Nothing Then
                Return -1
            Else
                Return CType(statusId, Integer)
            End If

        End Function

        ''' <summary>
        ''' Sets statusId column value of supplied row to duplicate publication.
        ''' </summary>
        ''' <param name="tempRow"></param>
        ''' <remarks></remarks>
        Public Sub SetStatusIdForDuplicate(ByVal tempRow As PublicationCheckInDataSet.vwPublicationEditionRow)
            Dim statusId As Integer


            statusId = GetStatusIdForDuplicate()

            If statusId < 0 Then
                tempRow.SetStatusIDNull()
            Else
                tempRow.StatusID = statusId
            End If

            statusId = Nothing

        End Sub

        ''' <summary>
        ''' Gets statusId column value for status as received.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetStatusIdForReceived() As Integer
            Dim statusId As Nullable(Of Integer)


            statusId = VehicleAdapter.GetVehicleStatusId("Received")

            If statusId Is Nothing Then
                Return -1
            Else
                Return CType(statusId, Integer)
            End If

        End Function

        ''' <summary>
        ''' Gets statusId column value for status as Wrong Version.
        ''' </summary>
        ''' <remarks></remarks>
        Public Function GetStatusIdForWrongVersion() As Integer
            Dim statusId As Nullable(Of Integer)

            statusId = VehicleAdapter.GetVehicleStatusId("Wrong Version")

            If statusId Is Nothing Then
                Return -1
            Else
                Return CType(statusId, Integer)
            End If

        End Function

        ''' <summary>
        ''' Sets statusId column value of supplied row to received.
        ''' </summary>
        ''' <param name="tempRow"></param>
        ''' <remarks></remarks>
        Public Sub SetStatusIdForReceived(ByVal tempRow As PublicationCheckInDataSet.vwPublicationEditionRow)
            Dim statusId As Integer


            statusId = GetStatusIdForReceived()

            If statusId < 0 Then
                tempRow.SetStatusIDNull()
            Else
                tempRow.StatusID = statusId
            End If

            statusId = Nothing

        End Sub


        ''' <summary>
        ''' Sets statusId column value of supplied row to Wrong Version.
        ''' </summary>
        ''' <param name="tempRow"></param>
        ''' <remarks></remarks>
        Public Sub SetStatusIdForWrongVersion(ByVal tempRow As PublicationCheckInDataSet.vwPublicationEditionRow)
            Dim statusId As Integer

            statusId = GetStatusIdForWrongVersion()

            If statusId < 0 Then
                tempRow.SetStatusIDNull()
            Else
                tempRow.StatusID = statusId
            End If

            statusId = Nothing

        End Sub


        ''' <summary>
        ''' Finds and loads row having vehicle Id same as specified.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="formName">Name of the screen requesting vehicle.</param>
        ''' <remarks></remarks>
        Public Sub FindVehicle(ByVal vehicleId As Integer, ByVal formName As String)
            Dim errorMessage As String


            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Cancel = False
                e.Data.Add("VehicleId", vehicleId)
                RaiseEvent LoadingVehicle(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            VehicleAdapter.Fill(Data.vwPublicationEdition, vehicleId, formName, errorMessage)

            If Data.vwPublicationEdition.Count = 0 And errorMessage Is Nothing Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("VehicleId", vehicleId)
                    RaiseEvent VehicleNotFound(Me, e)
                End Using
            ElseIf Data.vwPublicationEdition.Count = 0 And errorMessage IsNot Nothing Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("VehicleId", vehicleId)
                    e.Data.Add("ErrorMessage", errorMessage)
                    RaiseEvent InvalidVehicleStatus(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("VehicleRow", Data.vwPublicationEdition(0))
                    RaiseEvent VehicleLoaded(Me, e)
                End Using
            End If

        End Sub

        ''' <summary>
        ''' Gets mediaId for supplied media.
        ''' </summary>
        ''' <param name="mediaText">Name of the media, whose Id is need.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetMediaId(ByVal mediaText As String) As Integer
            Dim mediaId As Nullable(Of Integer)


            mediaId = VehicleAdapter.GetMediaId(mediaText)

            If mediaId Is Nothing Then
                Return -1
            Else
                Return CType(mediaId, Integer)
            End If

        End Function

        ''' <summary>
        ''' Searches for senderId having sender name as "Mail Subscription" within sender datatable.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>If sender is not found, senderId is returned as zero.</remarks>
        Public Function GetSenderIdForMagazine() As Integer
            Dim senderId As Integer
            Dim linqQuery As System.Collections.Generic.IEnumerable(Of PublicationCheckInDataSet.SenderRow)


            linqQuery = From senderRow In Data.Sender _
                        Select senderRow _
                        Where Trim(senderRow.Name) = "Mail Subscription"

            If linqQuery.Count > 0 Then senderId = linqQuery(0).SenderId

            linqQuery = Nothing

            Return senderId

        End Function

        ''' <summary>
        ''' Loads week day information on which the supplied publication is published.
        ''' </summary>
        ''' <param name="publicationId">Id of the publication.</param>
        ''' <remarks></remarks>
        Public Sub LoadPublicationDays(ByVal publicationId As Integer)
            Dim publishedOnAdapter As PublicationCheckInDataSetTableAdapters.PublishedOnTableAdapter


            publishedOnAdapter = New PublicationCheckInDataSetTableAdapters.PublishedOnTableAdapter()
            publishedOnAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            publishedOnAdapter.Fill(Data.PublishedOn, publicationId)

            publishedOnAdapter.Dispose()
            publishedOnAdapter = Nothing
        End Sub

        ''' <summary>
        ''' Gets boolean flag, indicating whether supplied date is a valid publication day or not.
        ''' </summary>
        ''' <param name="publicationDate">Date to be checked for validity.</param>
        ''' <remarks></remarks>
        Public Function IsPublicationDayValid(ByVal publicationDate As DateTime) As Boolean
            Dim dowQuery As System.Collections.Generic.IEnumerable(Of PublicationCheckInDataSet.PublishedOnRow)


            dowQuery = From dr In Data.PublishedOn _
                       Select dr _
                       Where dr.DOW = publicationDate.DayOfWeek + 1

            IsPublicationDayValid = (dowQuery.Count > 0)

            dowQuery = Nothing

        End Function


        ''' <summary>
        ''' Creates new row of vwPublicationEdition view.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CreateNew() As PublicationCheckInDataSet.vwPublicationEditionRow

            Return Data.vwPublicationEdition.NewvwPublicationEditionRow()

        End Function

        ''' <summary>
        ''' Adds new row into vwPublicationEdition datatable.
        ''' </summary>
        ''' <param name="tempRow"></param>
        ''' <remarks></remarks>
        Public Sub Add(ByVal tempRow As PublicationCheckInDataSet.vwPublicationEditionRow)

            tempRow.CreatedById = UserID
            'tempRow.CreateDt = System.DateTime.Now
            Data.vwPublicationEdition.AddvwPublicationEditionRow(tempRow)

        End Sub

        ''' <summary>
        ''' Synchronizes changes made in vwPublicationEdition datatable with database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Synchronize()
            Dim rowsAffected As Integer

            Using e As CancellableEventArgs = New CancellableEventArgs
                RaiseEvent Synchronizing(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            rowsAffected = VehicleAdapter.Update(Data.vwPublicationEdition)

            Using e As EventArgs = New EventArgs
                RaiseEvent Synchronized(Me, e)
            End Using

        End Sub


    End Class

End Namespace