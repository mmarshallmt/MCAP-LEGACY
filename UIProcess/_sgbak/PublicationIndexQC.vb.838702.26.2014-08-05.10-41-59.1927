Namespace UI.Processors

  Public Class PublicationIndexQC
    Inherits VehicleImageBase


#Region " Events "


    'Events can be extended to supply necessary information to consumer along with events.
    'Information passed into event can be useful to consumer while processing the event.

    Public Event Initializing()
    Public Event Initialized()

    Public Event LoadingData()
    Public Event DataLoaded()

    Public Event LoadingVehicle(ByVal vehicleId As Integer, ByRef Cancel As Boolean)
    Public Event VehicleLoaded(ByVal vehicleRow As QCDataSet.vwPublicationEditionRow)
    Public Event VehicleNotFound(ByVal vehicleId As Integer)
    Public Event InvalidVehicleStatus(ByVal vehicleId As Integer, ByVal statusText As String)

    Public Event LoadingMarkets()
    Public Event MarketsLoaded()

    Public Event LoadingPublications()
    Public Event PublicationsLoaded()

    Public Event LoadingRetailers()
    Public Event RetailersLoaded()

    Public Event SynchronizingVehicleInformation()
    Public Event VehicleInformationSynchronized()


#End Region


    Private m_publicationEditionAdapter As QCDataSetTableAdapters.vwPublicationEditionTableAdapter



    Sub New()
      MyBase.new()

      m_publicationEditionAdapter = New QCDataSetTableAdapters.vwPublicationEditionTableAdapter

    End Sub



    ''' <summary>
    ''' Adapter for vwPublicationEdition view.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property VehicleAdapter() As QCDataSetTableAdapters.vwPublicationEditionTableAdapter
      Get
        Return m_publicationEditionAdapter
      End Get
    End Property



    Public Sub Initialize()

      RaiseEvent Initializing()

      SetAdaptersConnectionString()
      VehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      RaiseEvent Initialized()

    End Sub

        Public Overrides Sub LoadDataSet(ByVal _sender As Integer)

            RaiseEvent LoadingData()

            MyBase.LoadDataSet(_sender)
            LoadSizes()

            RaiseEvent DataLoaded()

        End Sub

    Public Sub LoadSizes()

      SizeAdapter.Fill(Data.Size)

    End Sub

    Public Sub LoadMarket(ByVal senderId As Integer)

      MarketAdapter.FillBySender(Data.Mkt, senderId)

    End Sub

        Public Sub LoadPublication(ByVal marketId As Integer, ByVal publicationid As Integer)

            'LoadPublications(marketId)
            PublicationAdapter.FillForPublications(Data.Publication, marketId, publicationid)

        End Sub

    ''' <summary>
    ''' Load retailers from Ret table using RetPublicationCoverage table. Rows are filtered on publication.
    ''' </summary>
    ''' <param name="publicationId"></param>
    ''' <remarks></remarks>
    Public Sub LoadRetailer(ByVal publicationId As Integer)
      Dim RetailerAdapter As QCDataSetTableAdapters.RetTableAdapter


      RetailerAdapter = New QCDataSetTableAdapters.RetTableAdapter()
      RetailerAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      RetailerAdapter.FillByPublicationId(Data.Ret, publicationId)
      RetailerAdapter.Dispose()
      RetailerAdapter = Nothing

        End Sub
        'Public Function IsValidReqcUser() As Integer
        '    Dim validUser As Integer
        '    validUser = CInt(VehicleAdapter.IsReQcValidUser(UserID)) ', formName, errorMessage)
        '    Return validUser ' (retailerCount.HasValue AndAlso retailerCount.Value > 0)

        'End Function
        ''' <summary>
        ''' Loads retailers based on senderid mediaId and marketId.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Public Function LoadRetailersSenderExpectation(ByVal _sender As Integer, ByVal _mkt As Integer, ByVal _media As Integer, ByVal _senderId As Integer) As Integer

            RaiseEvent LoadingRetailers()

            RetailerAdapter.FillBySenderExpectation(Data.Ret, _media, _mkt, _senderid)

            If Data.Ret.Rows.Count > 0 Then
                Return Data.Ret.Rows.Count
            Else
                Return 0
            End If
            RaiseEvent RetailersLoaded()
        End Function

    Public Overrides Sub LoadVehicle(ByVal vehicleId As Integer, ByVal formName As String)
      Dim Cancel As Boolean
      Dim errorMessage As String


      RaiseEvent LoadingVehicle(vehicleId, Cancel)

      If Cancel Then Exit Sub

      VehicleAdapter.Fill(Data.vwPublicationEdition, vehicleId, formName, errorMessage)

      If Data.vwPublicationEdition.Count = 0 And errorMessage Is Nothing Then
        RaiseEvent VehicleNotFound(vehicleId)
      ElseIf Data.vwPublicationEdition.Count = 0 And errorMessage IsNot Nothing Then
        RaiseEvent InvalidVehicleStatus(vehicleId, errorMessage)
      Else
        RaiseEvent VehicleLoaded(Data.vwPublicationEdition(0))
      End If

    End Sub

    ''' <summary>
    ''' Returns index status text to display below qc status label on left top corner of the QC screen.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function GetIndexStatusText(ByVal vehicleId As Integer) As String

      Return VehicleAdapter.GetIndexStatusText(vehicleId).ToString()

    End Function

    ''' <summary>
    ''' Returns true if cropped Ad exists for supplied vehicle and page.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="receivedOrder">Received order of page.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function HasCroppedAdImages(ByVal vehicleId As Integer, ByVal receivedOrder As Integer?) As Boolean
      Dim croppedAdCount As Integer?


      croppedAdCount = PageCropAdapter.GetCroppedAdCountForPage(vehicleId, receivedOrder)

      Return (croppedAdCount.HasValue AndAlso croppedAdCount.Value > 0)

    End Function

    ''' <summary>
    ''' Returns true if vehicle is marked as Indexed, false otherwise.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <exception cref="System.ApplicationException"></exception>
    Public Function IsVehicleMarkedAsIndexingComplete(ByVal vehicleId As Integer) As Boolean
      Dim statusText As String


      Try
        statusText = Me.VehicleAdapter.GetIndexStatusText(vehicleId)
      Catch ex As System.Data.SqlClient.SqlException
        Throw New System.ApplicationException("Unable check vehicle status of vehicle " + vehicleId.ToString(), ex)
      Catch ex As Exception
        Throw New System.ApplicationException("Unknown error has occurred while checking vehicle status of " _
                                              + "vehicle " + vehicleId.ToString() + ".", ex)
      End Try

      Return Not (statusText Is Nothing OrElse statusText = "Not Indexed")

    End Function

    ''' <summary>
    ''' Sets page size for all pages of vehicle to page size set for ROP for publication.
    ''' </summary>
    ''' <param name="VehicleId"></param>
    ''' <remarks></remarks>
    Public Sub SetVehiclePageSizeForROP(ByVal VehicleId As Integer, ByVal receivedOrder As Integer)

      PageAdapter.UpdatePageSizeForROP(VehicleId, receivedOrder)
      PageAdapter.Fill(Data.Page, VehicleId)

    End Sub

    ''' <summary>
    ''' Sets page size, for all pages of vehicle, to page size set for Magazine for publication
    ''' </summary>
    ''' <param name="VehicleId"></param>
    ''' <remarks></remarks>
    Public Sub SetVehiclePageSizeForMagazine(ByVal VehicleId As Integer, ByVal receivedOrder As Integer)

      PageAdapter.UpdatePageSizeForMagazine(VehicleId, receivedOrder)
      PageAdapter.Fill(Data.Page, VehicleId)

    End Sub

    ''' <summary>
    ''' Gets text based on page size of the vehicle pages. If page size matches with the size of 
    ''' rop for publication then "ROP", if page size matches with the size of magazine for 
    ''' publication then "MAG", if page size is null for publication then "BLNK" otherwise "UNKN" is returned.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="receivedOrder"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPageSizeMediaText(ByVal vehicleId As Integer, ByVal receivedOrder As Integer) As String
      Dim returnValue As Object


      returnValue = PageAdapter.GetPageSizeIdMediaText(vehicleId, receivedOrder)

      If returnValue Is Nothing Or returnValue Is DBNull.Value Then
        Return String.Empty
      Else
        Return returnValue.ToString()
      End If

    End Function

    ''' <summary>
    ''' Updates vehicle status. Marks vehicle as Indexed.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    ''' <exception cref="System.ApplicationException"></exception>
    Public Sub MarkedVehicleAsIndexingComplete(ByVal vehicleId As Integer)
      Dim vehicleCount As Integer


      Try
        vehicleCount = Me.VehicleAdapter.MarkAsIndexingComplete(UserID, vehicleId)

      Catch ex As System.Data.SqlClient.SqlException
        Throw New System.ApplicationException("Unable to mark vehicle " + vehicleId.ToString() _
                                              + " as Index Completed.", ex)
      Catch ex As Exception
        Throw New System.ApplicationException("Unknown error has occurred while marking vehicle " _
                                              + vehicleId.ToString() + " as Index Completed.", ex)
      End Try

      vehicleCount = Nothing

    End Sub

    ''' <summary>
    ''' Returns number of pages not having at least one cropped page associated with it.
    ''' </summary>
    ''' <param name="VehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPageCountWithoutCroppedPage(ByVal VehicleId As Integer) As Integer
      Dim count As Integer = 0
      Dim pageCount, cropCount As Integer?


      pageCount = PageAdapter.GetPageCount(VehicleId)
      If pageCount.HasValue = False OrElse pageCount.Value < 1 Then Return 0

      For i As Integer = 1 To pageCount.Value
        cropCount = PageCropAdapter.GetCroppedAdCountForPage(VehicleId, i)
        If cropCount.HasValue = False OrElse cropCount.Value < 1 Then
          count += 1
        End If
      Next

      Return count

    End Function

        '''' <summary>
        '''' Returns boolean value, indicating whether supplied media-market-retailer combination is retquired for ADlert or not.
        '''' </summary>
        '''' <param name="mediaId"></param>
        '''' <param name="marketId"></param>
        '''' <param name="retailerId"></param>
        '''' <returns></returns>
        '''' <remarks></remarks>
        'Public Function IsADlertRequired(ByVal mediaId As Integer, ByVal marketId As Integer, ByVal retailerId As Integer) As Boolean
        '  Dim count As Integer?
        '  Dim tempAdapter As QCDataSetTableAdapters.vwPublicationEditionTableAdapter


        '  tempAdapter = New QCDataSetTableAdapters.vwPublicationEditionTableAdapter()
        '  tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '  Try
        '    count = tempAdapter.IsADlertRequired(mediaId, marketId, retailerId)
        '  Catch ex As System.Data.SqlClient.SqlException
        '    Throw
        '  Catch ex As System.Exception
        '    Throw
        '  End Try

        '  tempAdapter.Dispose()
        '  tempAdapter = Nothing

        '  Return (count.HasValue AndAlso count.Value > 0)

        'End Function
        ''' <summary>
        ''' Returns boolean value, indicating whether supplied media-market-retailer combination is retquired for ADlert or not.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <param name="retailerId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsADlertRequired(ByVal mediaId As Integer, ByVal marketId As Integer, ByVal retailerId As Integer) As Boolean
            Dim count As Integer?
            Dim tempAdapter As QCDataSetTableAdapters.vwPublicationEditionTableAdapter


            tempAdapter = New QCDataSetTableAdapters.vwPublicationEditionTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            Try
                count = tempAdapter.IsADlertRequired(mediaId, marketId, retailerId)
            Catch ex As System.Data.SqlClient.SqlException
                Throw
            Catch ex As System.Exception
                Throw
            End Try

            tempAdapter.Dispose()
            tempAdapter = Nothing

            Return (count.HasValue AndAlso count.Value > 0)

        End Function

    ''' <summary>
    ''' Returns true when page name is having non-blank value, false otherwise.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="pageId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsPageHasPageNameAssigned(ByVal vehicleId As Integer, ByVal pageId As Integer) As Boolean
      Dim pageName As String
      Dim tempAdapter As QCDataSetTableAdapters.PageTableAdapter


      tempAdapter = New QCDataSetTableAdapters.PageTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      pageName = tempAdapter.GetPageName(vehicleId, pageId)

      tempAdapter.Dispose()
      tempAdapter = Nothing

      Return (pageName IsNot Nothing AndAlso pageName.Length > 0)

    End Function

    ''' <summary>
    ''' Sets page name based on supplied PageId and VehicleId.
    ''' </summary>
    ''' <param name="pageName"></param>
    ''' <param name="pageId"></param>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Public Sub SetPageNameAssigned(ByVal pageName As String, ByVal pageId As Integer, ByVal vehicleId As Integer)
      Dim tempAdapter As QCDataSetTableAdapters.PageTableAdapter


      tempAdapter = New QCDataSetTableAdapters.PageTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      tempAdapter.UpdatePageName(pageName, pageId, vehicleId)

      tempAdapter.Dispose()
      tempAdapter = Nothing

    End Sub

    ''' <summary>
    ''' Updates PageName column value in Page table, based on RowState property value of data rows in Page data table.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateAllPageNames()
      Dim pageQuery As System.Data.EnumerableRowCollection(Of QCDataSet.PageRow)


      pageQuery = From pr In Data.Page _
                  Where pr.RowState = DataRowState.Modified _
                  Select pr

      For i As Integer = 0 To pageQuery.Count() - 1
        SetPageNameAssigned(pageQuery(i).PageName, pageQuery(i).PageId, pageQuery(i).VehicleId)
      Next

      pageQuery = Nothing
    End Sub

    ''' <summary>
    ''' Returns QC status text to display below vehicleId label on left top corner of screen.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetQCStatusText(ByVal vehicleId As Integer) As String

      Return VehicleAdapter.GetQCStatusText(vehicleId)

    End Function

    ''' <summary>
    ''' Updates QC column values and vehicle status as QC Completed.
    ''' </summary>
    ''' <param name="VehicleId"></param>
    ''' <remarks></remarks>
    Public Sub MarkVehicleAsQCed(ByVal VehicleId As Integer)

      VehicleAdapter.MarkVehicleAsQCCompleted(UserID, VehicleId)

    End Sub

    ''' <summary>
    ''' Returns true if vehicle is marked as QC Completed, false otherwise.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsVehicleMarkedAsQCed(ByVal vehicleId As Integer) As Boolean
      Dim isQCed As Boolean
      Dim statusText As String


      statusText = VehicleAdapter.GetQCStatusText(vehicleId)
      If statusText Is Nothing OrElse statusText = "Not QCed" Then
        isQCed = False
      Else
        isQCed = True
      End If

      Return isQCed

    End Function

    ''' <summary>
    ''' Updates SPReviewStatusId column value.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="formName"></param>
    ''' <remarks></remarks>
    Public Sub UpdateSPReviewStatus(ByVal vehicleId As Integer, ByVal formName As String)

      VehicleAdapter.UpdateSPReviewStatus(formName, vehicleId)

    End Sub

    '
    'On this form users are not allowed to manipulate information of vehicle.
    '
    'Public Overrides Sub SynchronizeVehicleInformation()

    '  RaiseEvent SynchronizingVehicleInformation()

    '  RaiseEvent VehicleInformationSynchronized()

    'End Sub

  End Class

End Namespace