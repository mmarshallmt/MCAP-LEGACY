﻿Namespace UI.Processors

  Public Class QCVehicleImages
    Inherits VehicleImageBase


#Region " Events "


    'Events can be extended to supply necessary information to consumer along with events.
    'Information passed into event can be useful to consumer while processing the event.

    Public Event Initializing()
    Public Event Initialized()

    Public Event LoadingData()
    Public Event DataLoaded()

    Public Event LoadingVehicle(ByVal vehicleId As Integer)
    Public Event VehicleLoaded(ByVal vehicleRow As QCDataSet.vwCircularRow, ByVal isVehicleQCed As Boolean, ByVal isParentVehicleQCed As Boolean)
    Public Event VehicleNotFound(ByVal vehicleId As Integer)
    Public Event InvalidVehicleStatus(ByVal statusText As String)
    Public Event ParentVehicleNotQCed(ByVal vehicleId As Integer, ByVal parentVehicleId As Integer)

    Public Event LoadingMarkets()
    Public Event MarketsLoaded()

    Public Event LoadingPublications()
    Public Event PublicationsLoaded()

    Public Event LoadingRetailers()
    Public Event RetailersLoaded()

    Public Event ValidatingInputs()
    Public Event InputsValidated()

    Public Event SynchronizingVehicleInformation()
    Public Event VehicleInformationSynchronized()

    Public Event LoadingFamilyThumbnailPagesInformation()
        Public Event FamilyThumbnailPagesInformationLoaded()

        Public Event UpdatingAdditionalQcInfo As MCAPCancellableEventHandler
        Public Event AdditionalQcInfoUpdated As MCAPEventHandler

        Public Event ValidatingAdditionalQcInfo As MCAPCancellableEventHandler
        Public Event InvalidAdditionalQcInfoFound As MCAPEventHandler
        Public Event AdditionalQcInfoValidated As MCAPEventHandler

        Public Event LoadingEnvelopeSender As MCAPCancellableEventHandler
        Public Event EnvelopeSenderLoaded As MCAPEventHandler
        Public Event EnvelopeSenderNotFound As MCAPEventHandler




    Public Event ChildVehicleQCProgress(ByVal parentVehicleId As Integer, ByVal childVehicleId As Integer, ByVal currentChildVehicle As Integer, ByVal totalChildVehicleCount As Integer)

#End Region


        Private m_vehicleAdapter As QCDataSetTableAdapters.vwCircularTableAdapter
        Private m_additionalqcinfoAdapter As QCDataSetTableAdapters.AdditionalQcInformationTableAdapter
        Private m_familyThumbnailAdapter As QCDataSetTableAdapters.FamilyThumbnailTableAdapter
        Protected m_senderAdapter As QCDataSetTableAdapters.SenderTableAdapter
        Public _senderID As Integer
        Public _senderName As String
        Public _RemoteStatus As FormStateEnum


        Private ReadOnly Property AddtionalQcInfoAdapter() As QCDataSetTableAdapters.AdditionalQcInformationTableAdapter
            Get
                Return m_additionalqcinfoAdapter
            End Get
        End Property

    Protected ReadOnly Property VehicleAdapter() As QCDataSetTableAdapters.vwCircularTableAdapter
      Get
        Return m_vehicleAdapter
      End Get
    End Property

    Public ReadOnly Property FamilyThumbnailAdapter() As QCDataSetTableAdapters.FamilyThumbnailTableAdapter
      Get
        Return m_familyThumbnailAdapter
      End Get
    End Property



    Sub New()
      MyBase.new()

      m_vehicleAdapter = New QCDataSetTableAdapters.vwCircularTableAdapter
            m_familyThumbnailAdapter = New QCDataSetTableAdapters.FamilyThumbnailTableAdapter
            m_additionalqcinfoAdapter = New QCDataSetTableAdapters.AdditionalQcInformationTableAdapter
            m_senderAdapter = New QCDataSetTableAdapters.SenderTableAdapter
    End Sub

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

    Public Sub Initialize()

      'RaiseEvent Initializing()

      SetAdaptersConnectionString()

      'PageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      'SizeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      'PageCropAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      FamilyThumbnailAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      VehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      'RaiseEvent Initialized()

    End Sub

        Public Function VehicleQcCompleted(ByVal VehicleId As Integer) As Integer
            Dim vehicleQced As Integer
            vehicleQced = CInt(VehicleAdapter.IsQcCompleted(VehicleId)) ', formName, errorMessage)
            Return vehicleQced ' (retailerCount.HasValue AndAlso retailerCount.Value > 0)

        End Function

        Public Function IsValidReqcUser() As Integer
            Dim validUser As Integer
            validUser = CInt(VehicleAdapter.IsReQcValidUser(UserID)) ', formName, errorMessage)
            Return validUser ' (retailerCount.HasValue AndAlso retailerCount.Value > 0)

        End Function
        Public Function IsValidBypassSenderExpectationFilterUser() As Integer
            Dim validUser As Integer
            validUser = CInt(VehicleAdapter.isAllowedBypassSenderExpectationFilter(UserID)) ', formName, errorMessage)
            Return validUser ' (retailerCount.HasValue AndAlso retailerCount.Value > 0)

        End Function

        Public Function IsAllowCacheImagesUser() As Integer
            Dim validUser As Integer
            validUser = CInt(VehicleAdapter.isAllowCacheImages(UserID)) ', formName, errorMessage)
            Return validUser ' (retailerCount.HasValue AndAlso retailerCount.Value > 0)

        End Function

    ''' <summary>
    ''' Returns user name from user table based on supplied parameters.
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <remarks></remarks>
    Public Function GetUserFullName(ByVal userId As Integer) As String
      Dim userName As String
      Dim tempAdapter As QCDataSetTableAdapters.UserTableAdapter


      tempAdapter = New QCDataSetTableAdapters.UserTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      userName = tempAdapter.GetUserFullName(userId)
      tempAdapter.Dispose()
      tempAdapter = Nothing

      Return userName

    End Function

    ''' <summary>
    ''' Loads list of sizes from database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadSizes()

      SizeAdapter.Fill(Data.Size)

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
        Public Sub LoadMarket(ByVal vehicleid As Integer, ByVal senderid As Integer)

            RaiseEvent LoadingMarkets()

            LoadMarkets(vehicleid, senderid)

            RaiseEvent MarketsLoaded()

        End Sub
        ''' <summary>
        ''' Loads markets based on sender of supplied envelope Id.
        ''' </summary>
        ''' <param name="envelopeId">Markets are loaded based on sender of supplied  envelope Id.</param>
        ''' <remarks></remarks>
        Public Function LoadMarketsPerSenderExpectation(ByVal media As Integer, ByVal _sender As Integer) As Integer
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
    ''' Loads market for media type Catalog.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadMarketsForCatalog()

      RaiseEvent LoadingMarkets()

      MarketAdapter.FillForCatalog(Data.Mkt)

      RaiseEvent MarketsLoaded()

    End Sub

    ''' <summary>
    ''' Returns true if retailer exist in FR_RetForPageCrop table, false otherwise.
    ''' </summary>
    ''' <param name="retailerId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsRetailerValidForPageCropFR(ByVal retailerId As Integer) As Boolean
      Dim retailerCount As Integer?

      retailerCount = RetailerAdapter.IsRetailerValidForPageCropFSI(retailerId)

      Return (retailerCount.HasValue AndAlso retailerCount.Value > 0)

    End Function

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
        ''' Loads publication based on sender id.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Public Function LoadPublicationExpectation() As Integer

            RaiseEvent LoadingPublications()

            PublicationAdapter.FillBySenderPublication(Data.Publication, _senderID)

            If Data.Publication.Rows.Count > 0 Then
                Return Data.Publication.Rows.Count
            Else
                Return 0
            End If
            RaiseEvent PublicationsLoaded()
        End Function
    ''' <summary>
    ''' Loads publication based on supplied market id.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadNAPublicationForQC()

      RaiseEvent LoadingPublications()

      PublicationAdapter.FillNA(Data.Publication)

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
        ''' Loads retailers based on senderid mediaId and marketId.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Public Function LoadRetailersSenderExpectation(ByVal _sender As Integer, ByVal _mkt As Integer, ByVal _media As Integer) As Integer

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
    ''' Gets priority from Expectation table based on supplied retailer, market and media.
    ''' </summary>
    ''' <param name="mediaId"></param>
    ''' <param name="marketId"></param>
    ''' <param name="retailerId"></param>
    ''' <remarks></remarks>
    Public Function GetExpectationPriority(ByVal mediaId As Integer, ByVal marketId As Integer, ByVal retailerId As Integer) As String
      Dim priority As Integer?
      Dim priorityText As String


      priority = RetailerAdapter.GetExpectationPriority(retailerId, marketId, mediaId)
      If priority.HasValue = False OrElse priority.Value < 1 Then
        priorityText = "Unkn" 'String.Empty
      Else
        priorityText = priority.Value.ToString()
      End If

      Return priorityText

        End Function


        ''' <summary>
        ''' Gets Coverage from Expectation table based on supplied retailer, market .
        ''' </summary>
        ''' <param name="marketId"></param>
        ''' <param name="retailerId"></param>
        ''' <remarks></remarks>
        Public Function GetCoverage(ByVal marketId As Integer, ByVal retailerId As Integer) As String

            Dim CoverageText As String

            CoverageText = RetailerAdapter.getCoverage(marketId, retailerId)
            If String.IsNullOrEmpty(CoverageText) = True Then
                CoverageText = "Unkn" 'String.Empty
            End If

            Return CoverageText

        End Function

    '''' <summary>
    '''' Copy scanned(unsized) image files from source vehicle folder to destionation vehicle folder. 
    '''' Fetches page definitions of both source and destionation vehicles from database. Picks page 
    '''' definition of parent one by one and matches with child page definitions. If match found, it 
    '''' copies image from source to destionation based on ImageName column name, otherwise ignore 
    '''' and does nothing.
    '''' </summary>
    '''' <param name="sourceVehicleId"></param>
    '''' <param name="destinationVehicleId"></param>
    '''' <param name="overwrite">True, if image file is to be overwrite at destination, False otherwise.</param>
    '''' <returns>Boolean. True if all destination images are copied from parent, false otherwise.</returns>
    '''' <remarks></remarks>
    'Public Function CopyPageImages(ByVal sourceVehicleId As Integer, ByVal destinationVehicleId As Integer, ByVal overwrite As Boolean) As Boolean
    '  Dim areAllImagesCopied As Boolean
    '  Dim j As Integer
    '  Dim receivedOrders As System.Collections.Generic.List(Of Integer)
    '  Dim sourceFilePath, destinationFilePath As System.Text.StringBuilder
    '  Dim sourcePages, destinationPages As QCDataSet.PageDataTable
    '  Dim pageQuery As System.Data.EnumerableRowCollection(Of QCDataSet.PageRow)


    '  receivedOrders = New System.Collections.Generic.List(Of Integer)
    '  sourceFilePath = New System.Text.StringBuilder()
    '  destinationFilePath = New System.Text.StringBuilder()

    '  sourceFilePath.Append(GetPageImageFolderPath(sourceVehicleId, Processors.VehicleImageSizeEnum.Unsized))
    '  'No need to loop through, if source vehicle image folder does not exist.
    '  If System.IO.Directory.Exists(sourceFilePath.ToString()) = False Then
    '    sourceFilePath.Remove(0, sourceFilePath.Length)
    '    sourceFilePath = Nothing
    '    Exit Function
    '  End If

    '  destinationFilePath.Append(GetPageImageFolderPath(destinationVehicleId, Processors.VehicleImageSizeEnum.Unsized))
    '  If System.IO.Directory.Exists(destinationFilePath.ToString()) = False Then
    '    System.IO.Directory.CreateDirectory(destinationFilePath.ToString())
    '  End If

    '  sourcePages = GetPageInformationForVehicle(sourceVehicleId)
    '  destinationPages = GetPageInformationForVehicle(destinationVehicleId)

    '  For i As Integer = 0 To sourcePages.Count - 1
    '    sourceFilePath.Remove(0, sourceFilePath.Length)
    '    destinationFilePath.Remove(0, destinationFilePath.Length)

    '    pageQuery = From pg In destinationPages _
    '                Where pg.PageTypeId = sourcePages(i).PageTypeId And pg.SizeID = sourcePages(i).SizeID _
    '                Order By pg.ReceivedOrder _
    '                Select pg

    '    If pageQuery.Count() = 0 Then Continue For

    '    For j = 0 To pageQuery.Count() - 1
    '      If receivedOrders.Contains(pageQuery(j).ReceivedOrder) = False Then Exit For
    '    Next j

    '    'Loop executed upto pageQuery.Count() and couldn't find any valid row. So, start looking for next page of sourcePages.
    '    If j = pageQuery.Count() Then Continue For

    '    sourceFilePath.Append(GetPageImageFilePath(sourceVehicleId, sourcePages(i).ReceivedOrder, Processors.VehicleImageSizeEnum.Unsized))
    '    destinationFilePath.Append(GetPageImageFilePath(destinationVehicleId, pageQuery(j).ReceivedOrder, Processors.VehicleImageSizeEnum.Unsized))
    '    System.IO.File.Copy(sourceFilePath.ToString(), destinationFilePath.ToString(), overwrite)
    '    sourceFilePath.Remove(0, sourceFilePath.Length)
    '    destinationFilePath.Remove(0, destinationFilePath.Length)

    '    receivedOrders.Add(pageQuery(j).ReceivedOrder)
    '  Next i

    '  sourceFilePath.Remove(0, sourceFilePath.Length)
    '  destinationFilePath.Remove(0, destinationFilePath.Length)

    '  areAllImagesCopied = (receivedOrders.Count = destinationPages.Count)

    '  pageQuery = Nothing
    '  sourceFilePath = Nothing
    '  destinationFilePath = Nothing
    '  receivedOrders.Clear()
    '  receivedOrders = Nothing
    '  sourcePages.Dispose()
    '  destinationPages.Dispose()
    '  sourcePages = Nothing
    '  destinationPages = Nothing

    '  Return areAllImagesCopied

    'End Function

    ''' <summary>
    ''' Copy scanned(unsized) image files from source vehicle folder to destionation vehicle folder. 
    ''' Fetches page definitions of both source and destionation vehicles from database. Picks page 
    ''' definition of parent one by one and matches with child page definitions. If match found, it 
    ''' copies image from source to destionation based on ImageName column name, otherwise ignore 
    ''' and does nothing.
    ''' </summary>
    ''' <param name="sourceVehicleId"></param>
    ''' <param name="destinationVehicleId"></param>
    ''' <param name="overwrite">True, if image file is to be overwrite at destination, False otherwise.</param>
    ''' <remarks></remarks>
    Public Sub CopyPageImages(ByVal sourceVehicleId As Integer, ByVal destinationVehicleId As Integer, ByVal overwrite As Boolean)
      Dim sourceFilePath, destinationFilePath As System.Text.StringBuilder
      Dim sourcePages, destinationPages As QCDataSet.PageDataTable


      sourceFilePath = New System.Text.StringBuilder()
      destinationFilePath = New System.Text.StringBuilder()

      sourceFilePath.Append(GetPageImageFolderPath(sourceVehicleId, Processors.VehicleImageSizeEnum.Unsized))
      'No need to loop through, if source vehicle image folder does not exist.
      If System.IO.Directory.Exists(sourceFilePath.ToString()) = False Then
        sourceFilePath.Remove(0, sourceFilePath.Length)
        sourceFilePath = Nothing
        Exit Sub
      End If

      destinationFilePath.Append(GetPageImageFolderPath(destinationVehicleId, Processors.VehicleImageSizeEnum.Unsized))
      If System.IO.Directory.Exists(destinationFilePath.ToString()) = False Then
        System.IO.Directory.CreateDirectory(destinationFilePath.ToString())
      End If

      sourcePages = GetPageInformationForVehicle(sourceVehicleId)
      destinationPages = GetPageInformationForVehicle(destinationVehicleId)

      For i As Integer = 0 To sourcePages.Count - 1
        sourceFilePath.Remove(0, sourceFilePath.Length)
        destinationFilePath.Remove(0, destinationFilePath.Length)

        sourceFilePath.Append(GetPageImageFilePath(sourceVehicleId, sourcePages(i).ReceivedOrder, Processors.VehicleImageSizeEnum.Unsized))
        destinationFilePath.Append(GetPageImageFilePath(destinationVehicleId, destinationPages(i).ReceivedOrder, Processors.VehicleImageSizeEnum.Unsized, False))
        System.IO.File.Copy(sourceFilePath.ToString(), destinationFilePath.ToString(), overwrite)
        sourceFilePath.Remove(0, sourceFilePath.Length)
        destinationFilePath.Remove(0, destinationFilePath.Length)
      Next i

      sourceFilePath.Remove(0, sourceFilePath.Length)
      destinationFilePath.Remove(0, destinationFilePath.Length)

      sourceFilePath = Nothing
      destinationFilePath = Nothing
      sourcePages.Dispose()
      destinationPages.Dispose()
      sourcePages = Nothing
      destinationPages = Nothing

    End Sub

    ''' <summary>
    ''' Copy page information between vehicles.
    ''' </summary>
    ''' <param name="sourceVehicleId">Use page information of this Vehicle to copy.</param>
    ''' <param name="vehicleId">Copy page information for this vehicle.</param>
    ''' <param name="formName">Name of the form used to copy page information.</param>
    ''' <remarks></remarks>
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
    ''' Gets DataTable of type QCDataSet.PageDataTable filled with page information for supplied vehicleId.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetPageInformationForVehicle(ByVal vehicleId As Integer) As QCDataSet.PageDataTable
      Dim pgTable As QCDataSet.PageDataTable


      pgTable = Me.PageAdapter.GetData(vehicleId)

            Return pgTable

    End Function

    ''' <summary>
    ''' Loads Page information from pages table based on supplied parameters.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="familyId"></param>
    ''' <remarks></remarks>
    Public Sub LoadPagesInformationForFamilyThumbnail(ByVal vehicleId As Integer, ByVal familyId As Integer, ByVal pageNumber As Integer)

      RaiseEvent LoadingFamilyThumbnailPagesInformation()

      FamilyThumbnailAdapter.Fill(Data.FamilyThumbnail, pageNumber, familyId, vehicleId)

      RaiseEvent FamilyThumbnailPagesInformationLoaded()

    End Sub


    ''' <summary>
    ''' Renames vehicle page images based on rows in Page data table. Looks for files in all page 
    ''' image folders(1=Unsized, 2=Large, 3=Normal, 4=Thumbnail). 
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks>
    ''' Displays a messagebox is vehicle page image folder is not found.
    ''' </remarks>
        Public Sub RenameVehiclePageImageFiles(ByVal vehicleId As Integer)
            Dim pageImageFolderCounter, pageImageFileCounter As Integer
            Dim pageImageFolderPath As String
            Dim pageImageFilePath As System.Text.StringBuilder


            pageImageFilePath = New System.Text.StringBuilder()

            For pageImageFolderCounter = 1 To 4
                pageImageFolderPath = Nothing
                If pageImageFolderCounter = 1 Then
                    pageImageFolderPath = GetVehicleImageFolderPath(vehicleId, VehicleImageSizeEnum.Unsized)
                ElseIf pageImageFolderCounter = 2 Then
                    pageImageFolderPath = GetVehicleImageFolderPath(vehicleId, VehicleImageSizeEnum.Large)
                ElseIf pageImageFolderCounter = 3 Then
                    pageImageFolderPath = GetVehicleImageFolderPath(vehicleId, VehicleImageSizeEnum.Normal)
                Else
                    pageImageFolderPath = GetVehicleImageFolderPath(vehicleId, VehicleImageSizeEnum.Thumbnail)
                End If

                If My.Computer.FileSystem.DirectoryExists(pageImageFolderPath) = False Then
                    'MessageBox.Show("Unable to find page image folder for vehicle " + vehicleId.ToString() _
                    '                + " at " + Environment.NewLine + pageImageFolderPath _
                    '                , My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Continue For
                End If

                For pageImageFileCounter = 0 To Data.Page.Count - 1
                    pageImageFilePath.Append(pageImageFolderPath)
                    pageImageFilePath.Append("\")
                    pageImageFilePath.Append(Data.Page(pageImageFileCounter).ReceivedOrder.ToString("000"))
                    pageImageFilePath.Append(ImageFileExtension)


                    If My.Computer.FileSystem.FileExists(pageImageFilePath.ToString()) Then
                        Dim newImageFileName As String
                        newImageFileName = Data.Page(pageImageFileCounter).ImageName + ImageFileExtension
                        My.Computer.FileSystem.RenameFile(pageImageFilePath.ToString(), newImageFileName)
                        newImageFileName = Nothing
                    End If

                    pageImageFilePath.Remove(0, pageImageFilePath.Length)
                Next
            Next

        End Sub

    ''' <summary>
    ''' Checks whether family is required for vehicle and vehicle has family assigned to it or not.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function HasValidFamilyId(ByVal vehicleRow As QCDataSet.vwCircularRow) As Boolean
      Dim isFamilyRequired As Boolean
      Dim tradeclassId As Integer


      If vehicleRow Is Nothing OrElse vehicleRow.IsRetIdNull() Then Return False

      If vehicleRow.RetRow IsNot Nothing Then
        tradeclassId = vehicleRow.RetRow.TradeClassId
      Else
        Dim tradeclassQuery As System.Data.EnumerableRowCollection(Of QCDataSet.RetRow)
        tradeclassQuery = From r In Data.Ret Select r Where r.RetId = vehicleRow.RetId
        If tradeclassQuery.Count() = 0 Then
          tradeclassId = -1
        Else
          tradeclassId = tradeclassQuery(0).TradeClassId
        End If
        tradeclassQuery = Nothing
      End If

      If tradeclassId < 0 Then Return False

      isFamilyRequired = IsTradeclassRequireFamily(tradeclassId)

      If isFamilyRequired Then
        Return (Not vehicleRow.IsFamilyIdNull())
      Else
        Return True
      End If

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


    ''' <summary>
    ''' Updates supplied vehicle based on its parent vehicle values. Updates Scan, QC, Stautus, 
    ''' SPReviewStatus parameters based on parent vehicle column values. ScannedById and QCedById 
    ''' is set to "Automatic Process" user as per location of the current application user.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="formName"></param>
    ''' <remarks></remarks>
    Private Sub UpdateChildVehicleAsQCed(ByVal vehicleId As Integer, ByVal formName As String)
      Dim tempAdapter As QCDataSetTableAdapters.ChildVehicleTableAdapter


      tempAdapter = New QCDataSetTableAdapters.ChildVehicleTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      tempAdapter.UpdateChildVehicle(vehicleId, UserLocationId)
      tempAdapter.Dispose()
      tempAdapter = Nothing

        End Sub


        Private Sub UpdateChildVehicleAsReQCed(ByVal vehicleId As Integer, ByVal formName As String)
            Dim tempAdapter As QCDataSetTableAdapters.ChildVehicleTableAdapter


            tempAdapter = New QCDataSetTableAdapters.ChildVehicleTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.UpdateChildVehicleReQc(vehicleId, UserLocationId)
            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub
        ''' <summary>
        ''' Updates vehicle status as QCed. Also updates QCDt and QCedBy columns of vehicle table.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="formName"></param>
        ''' <exception cref="System.ApplicationException">
        ''' Throws exception if vehicleId mismatch occurs or status id not found for QC Completed status.
        ''' </exception>
        ''' <remarks></remarks>
        Public Sub MarkVehicleAsQCed(ByVal vehicleId As Integer, ByVal formName As String, ByVal subjectChange As String)
            Dim nationalInd As Nullable(Of Byte)
            Dim statusId As Nullable(Of Integer)
            Dim subjectValue As String


            If Data.vwCircular(0).VehicleId <> vehicleId Then
                Throw New System.ApplicationException("Vehicle information not found.")
            End If

            'After this point if familyId is null, it is assumed that family is not required for this vehicle.
            If HasValidFamilyId(Data.vwCircular(0)) = False Then
                Throw New System.ApplicationException("Vehicle do not have valid family.")
            End If

            PageAdapter.mt_proc_UpdateVehiclePageImagesName(vehicleId, ImageNameGenerationField, formName)
            LoadVehiclePagesInformation(vehicleId)

      RenameVehiclePageImageFiles(vehicleId)

            statusId = VehicleStatusAdapter.GetStatusId("QC Completed")
            If statusId Is Nothing Then
                Throw New System.ApplicationException("Vehicle status value not found.")
            End If

            Data.vwCircular(0).BeginEdit()
            Data.vwCircular(0).QCDt = DateTime.Now
            Data.vwCircular(0).QCedById = UserID
            Data.vwCircular(0).StatusID = CType(statusId, Integer)
            Data.vwCircular(0).FormName = formName
            Data.vwCircular(0).EndEdit()

            'VehicleAdapter.Update(Data.vwCircular)
            Dim checkInPageCount, priority, familyId As Integer?
      Dim startDt, endDt, distDt As DateTime?

            If Data.vwCircular(0).IsStartDtNull() = False Then startDt = Data.vwCircular(0).StartDt
      If Data.vwCircular(0).IsEndDtNull() = False Then endDt = Data.vwCircular(0).EndDt
      If Data.vwCircular(0).IsDistDtNull() = False Then distDt = Data.vwCircular(0).DistDt
            If Data.vwCircular(0).IsCheckInPageCountNull() = False Then checkInPageCount = Data.vwCircular(0).CheckInPageCount
            If Data.vwCircular(0).IsFamilyIdNull() = False Then familyId = Data.vwCircular(0).FamilyId
            If Data.vwCircular(0).IsPriorityNull() = False Then priority = Data.vwCircular(0).Priority
            If Data.vwCircular(0).IsNationalIndNull() = False Then nationalInd = Data.vwCircular(0).NationalInd
            If Data.vwCircular(0).IsSubjectNull() = False Then subjectChange = Data.vwCircular(0).Subject
            Data.vwCircular(0).Subject = subjectChange

            With Data.vwCircular(0)
        VehicleAdapter.UpdateQCedVehicle(.RetId, .MktId, .BreakDt, startDt, endDt, .LanguageId, .EventId, .ThemeId, .MediaId, .PublicationId, .FlashInd, .QCedById, familyId, .CouponInd, priority, checkInPageCount, .CheckInOccurrences, .StatusID, .FormName, nationalInd, .Subject, distDt, .VehicleId)
            End With


            'VehicleAdapter.InsertImageLogData(DateTime.Now, CType("U", Byte?), UserID, vehicleId, ImageRotationCount, "oldValue_ImageRotationCount", "keeprectanglecount" _
            '"oldvalue_keeprectangle","RemoveRectangleCount", "oldvalue_RemoveRectangleCount", "DeleteImageCount", "oldvalue_DeleteImageCount" _
            '"ResequenceCount", "oldvalue_ResequenceCount")



        End Sub

    ''' <summary>
    ''' Process all child vehicles one by one to mark them as QCed. Picks each child vehicle and 
    ''' update their page definition with unique page image name, renames page images based on the 
    ''' unique image name set in database. Sets ScanDt, QCDt, StatusId, SPReviewStatusId same as 
    ''' of its parent vehicle.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="formName"></param>
    ''' <returns>List of vehicle Id, along with description, that are not processed.</returns>
    ''' <remarks></remarks>
    Public Function MarkChildVehiclesAsQCed(ByVal vehicleId As Integer, ByVal formName As String) As System.Collections.Generic.Dictionary(Of Integer, String)
      Dim mismatchVehicleList As System.Collections.Generic.Dictionary(Of Integer, String)
      Dim tempAdapter As QCDataSetTableAdapters.ChildVehicleTableAdapter
      Dim childPageTable As QCDataSet.PageDataTable


      mismatchVehicleList = New System.Collections.Generic.Dictionary(Of Integer, String)
      tempAdapter = New QCDataSetTableAdapters.ChildVehicleTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      tempAdapter.Fill(Data.ChildVehicle, vehicleId)
      tempAdapter.Dispose()
      tempAdapter = Nothing

      For i As Integer = 0 To Data.ChildVehicle.Count - 1
        childPageTable = Me.PageAdapter.GetData(Data.ChildVehicle(i).VehicleId)
        RaiseEvent ChildVehicleQCProgress(vehicleId, Data.ChildVehicle(i).VehicleId, (i + 1), Data.ChildVehicle.Count)
        If childPageTable.Count <> Data.Page.Count Then
          mismatchVehicleList.Add(Data.ChildVehicle(i).VehicleId, String.Format("Page count mismatch between Parent Vehicle {0} and Child Vehicle {1}. Expected page count: {2}, Exist: {3}.", vehicleId, Data.ChildVehicle(i).VehicleId, Data.Page.Count, childPageTable.Count))
          childPageTable.Rows.Clear()
          Continue For
        End If
        PageAdapter.mt_proc_UpdateVehiclePageImagesName(Data.ChildVehicle(i).VehicleId, ImageNameGenerationField, formName)
        CopyPageImages(vehicleId, Data.ChildVehicle(i).VehicleId, True)
        UpdateChildVehicleAsQCed(Data.ChildVehicle(i).VehicleId, formName)
        mismatchVehicleList.Add(Data.ChildVehicle(i).VehicleId, "QCed successfully.")
        childPageTable.Rows.Clear()
      Next

      If childPageTable IsNot Nothing Then childPageTable.Dispose()
      childPageTable = Nothing


      Return mismatchVehicleList

        End Function

        ''' <summary>
        ''' Updates vehicle status as QCed. Also updates QCDt and QCedBy columns of vehicle table.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="formName"></param>
        ''' <exception cref="System.ApplicationException">
        ''' Throws exception if vehicleId mismatch occurs or status id not found for QC Completed status.
        ''' </exception>
        ''' <remarks></remarks>
        Public Sub MarkVehicleAsWrongVersion(ByVal vehicleId As Integer, ByVal formName As String)
            Dim nationalInd As Nullable(Of Byte)
            Dim statusId As Nullable(Of Integer)
            Dim subjectValue As String

            If Data.vwCircular(0).VehicleId <> vehicleId Then
                Throw New System.ApplicationException("Vehicle information not found.")
            End If

            'After this point if familyId is null, it is assumed that family is not required for this vehicle.
            'If HasValidFamilyId(Data.vwCircular(0)) = False Then
            '    Throw New System.ApplicationException("Vehicle do not have valid family.")
            'End If

            'PageAdapter.mt_proc_UpdateVehiclePageImagesName(vehicleId, ImageNameGenerationField, formName)
            'LoadVehiclePagesInformation(vehicleId)

            'RenameVehiclePageImageFiles(vehicleId)

            statusId = VehicleStatusAdapter.GetStatusId("Wrong Version")

            If statusId Is Nothing Then
                Throw New System.ApplicationException("Vehicle status value not found.")
            End If

            Data.vwCircular(0).BeginEdit()
            Data.vwCircular(0).StatusID = CType(statusId, Integer)
            Data.vwCircular(0).FormName = formName
            Data.vwCircular(0).EndEdit()

            'VehicleAdapter.Update(Data.vwCircular)
            Dim checkInPageCount, priority, familyId As Integer?
            Dim startDt, endDt As DateTime?

            With Data.vwCircular(0)
                VehicleAdapter.UpdateAsWrongVersion(.StatusID, .VehicleId)
            End With




        End Sub


        Public Sub MarkVehicleAsDuplicate(ByVal vehicleId As Integer, ByVal formName As String)
            Dim statusId As Nullable(Of Integer)

            If Data.vwCircular(0).VehicleId <> vehicleId Then
                Throw New System.ApplicationException("Vehicle information not found.")
            End If

            statusId = VehicleStatusAdapter.GetStatusId("Duplicate")

            If statusId Is Nothing Then
                Throw New System.ApplicationException("Vehicle status value not found.")
            End If

            Data.vwCircular(0).BeginEdit()
            Data.vwCircular(0).StatusID = CType(statusId, Integer)
            Data.vwCircular(0).FormName = formName
            Data.vwCircular(0).EndEdit()

            With Data.vwCircular(0)
                VehicleAdapter.UpdateAsWrongVersion(.StatusID, .VehicleId)
            End With




        End Sub


        Public Sub MarkVehicleAsNonPromotional(ByVal vehicleId As Integer, ByVal formName As String)
            Dim statusId As Nullable(Of Integer)

            If Data.vwCircular(0).VehicleId <> vehicleId Then
                Throw New System.ApplicationException("Vehicle information not found.")
            End If

            statusId = VehicleStatusAdapter.GetStatusId("Non Promotional")

            If statusId Is Nothing Then
                Throw New System.ApplicationException("Vehicle status value not found.")
            End If

            Data.vwCircular(0).BeginEdit()
            Data.vwCircular(0).StatusID = CType(statusId, Integer)
            Data.vwCircular(0).FormName = formName
            Data.vwCircular(0).EndEdit()

            With Data.vwCircular(0)
                VehicleAdapter.UpdateAsWrongVersion(.StatusID, .VehicleId)
            End With




        End Sub


        ''' <summary>
        ''' Updates vehicle status as QCed. Also updates QCDt and QCedBy columns of vehicle table.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="formName"></param>
        ''' <exception cref="System.ApplicationException">
        ''' Throws exception if vehicleId mismatch occurs or status id not found for QC Completed status.
        ''' </exception>
        ''' <remarks></remarks>
        Public Sub MarkVehicleAsReQCed(ByVal vehicleId As Integer, ByVal formName As String, ByVal subjectChange As String)
            Dim nationalInd As Nullable(Of Byte)
            Dim statusId As Nullable(Of Integer)
            Dim subjectValue As String

            If Data.vwCircular(0).VehicleId <> vehicleId Then
                Throw New System.ApplicationException("Vehicle information not found.")
            End If

            'After this point if familyId is null, it is assumed that family is not required for this vehicle.
            If HasValidFamilyId(Data.vwCircular(0)) = False Then
                Throw New System.ApplicationException("Vehicle do not have valid family.")
            End If

            PageAdapter.mt_proc_UpdateVehiclePageImagesName(vehicleId, ImageNameGenerationField, formName)
            LoadVehiclePagesInformation(vehicleId)

            'RenameVehiclePageImageFiles(vehicleId)

            statusId = VehicleStatusAdapter.GetStatusId("QC Completed")

            If statusId Is Nothing Then
                Throw New System.ApplicationException("Vehicle status value not found.")
            End If

            Data.vwCircular(0).BeginEdit()
            Data.vwCircular(0).ReQCDt = DateTime.Now
            Data.vwCircular(0).ReQCedById = UserID
            Data.vwCircular(0).StatusID = CType(statusId, Integer)
            Data.vwCircular(0).FormName = formName
            Data.vwCircular(0).Subject = subjectChange
            Data.vwCircular(0).EndEdit()

            'VehicleAdapter.Update(Data.vwCircular)
            Dim checkInPageCount, priority, familyId As Integer?
      Dim startDt, endDt, distDt As DateTime?

            If Data.vwCircular(0).IsStartDtNull() = False Then startDt = Data.vwCircular(0).StartDt
      If Data.vwCircular(0).IsEndDtNull() = False Then endDt = Data.vwCircular(0).EndDt
      If Data.vwCircular(0).IsDistDtNull() = False Then distDt = Data.vwCircular(0).DistDt
            If Data.vwCircular(0).IsCheckInPageCountNull() = False Then checkInPageCount = Data.vwCircular(0).CheckInPageCount
            If Data.vwCircular(0).IsFamilyIdNull() = False Then familyId = Data.vwCircular(0).FamilyId
            If Data.vwCircular(0).IsPriorityNull() = False Then priority = Data.vwCircular(0).Priority
            If Data.vwCircular(0).IsNationalIndNull() = False Then nationalInd = Data.vwCircular(0).NationalInd
            If Data.vwCircular(0).IsSubjectNull() = False Then subjectValue = Data.vwCircular(0).Subject


            With Data.vwCircular(0)
        VehicleAdapter.UpdateReQCedVehicle(.RetId, .MktId, .BreakDt, startDt, endDt, .LanguageId, .EventId, .ThemeId, .MediaId, .PublicationId, .FlashInd, .QCedById, familyId, .CouponInd, priority, checkInPageCount, .CheckInOccurrences, .StatusID, .FormName, nationalInd, .ReQCDt, .ReQCedById, .Subject, DistDt, .VehicleId)
            End With




        End Sub

        Public Sub ImageLogData(ByVal vehicleId As Integer, ByVal formName As String, ByVal ImageRotationCount As Integer, _
                                ByVal keeprectanglecount As Integer, ByVal RemoveRectangleCount As Integer, _
                                ByVal DeleteImageCount As Integer, ByVal ResequenceCount As Integer)

            'Problem with ReqC Adapater here
            'VehicleAdapter.ImageLogData(DateTime.Now, CType("U", String), UserID, vehicleId, ImageRotationCount, keeprectanglecount, RemoveRectangleCount, DeleteImageCount, ResequenceCount)

        End Sub



        ''' <summary>
        ''' Process all child vehicles one by one to mark them as QCed. Picks each child vehicle and 
        ''' update their page definition with unique page image name, renames page images based on the 
        ''' unique image name set in database. Sets ScanDt, QCDt, StatusId, SPReviewStatusId same as 
        ''' of its parent vehicle.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="formName"></param>
        ''' <returns>List of vehicle Id, along with description, that are not processed.</returns>
        ''' <remarks></remarks>
        Public Function MarkChildVehiclesAsReQCed(ByVal vehicleId As Integer, ByVal formName As String) As System.Collections.Generic.Dictionary(Of Integer, String)
            Dim mismatchVehicleList As System.Collections.Generic.Dictionary(Of Integer, String)
            Dim tempAdapter As QCDataSetTableAdapters.ChildVehicleTableAdapter
            Dim childPageTable As QCDataSet.PageDataTable


            mismatchVehicleList = New System.Collections.Generic.Dictionary(Of Integer, String)
            tempAdapter = New QCDataSetTableAdapters.ChildVehicleTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(Data.ChildVehicle, vehicleId)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            For i As Integer = 0 To Data.ChildVehicle.Count - 1
                childPageTable = Me.PageAdapter.GetData(Data.ChildVehicle(i).VehicleId)
                RaiseEvent ChildVehicleQCProgress(vehicleId, Data.ChildVehicle(i).VehicleId, (i + 1), Data.ChildVehicle.Count)
                If childPageTable.Count <> Data.Page.Count Then
                    mismatchVehicleList.Add(Data.ChildVehicle(i).VehicleId, String.Format("Page count mismatch between Parent Vehicle {0} and Child Vehicle {1}. Expected page count: {2}, Exist: {3}.", vehicleId, Data.ChildVehicle(i).VehicleId, Data.Page.Count, childPageTable.Count))
                    childPageTable.Rows.Clear()
                    Continue For
                End If
                PageAdapter.mt_proc_UpdateVehiclePageImagesName(Data.ChildVehicle(i).VehicleId, ImageNameGenerationField, formName)
                CopyPageImages(vehicleId, Data.ChildVehicle(i).VehicleId, True)
                UpdateChildVehicleAsReQCed(Data.ChildVehicle(i).VehicleId, formName)
                mismatchVehicleList.Add(Data.ChildVehicle(i).VehicleId, "QCed successfully.")
                childPageTable.Rows.Clear()
            Next

            If childPageTable IsNot Nothing Then childPageTable.Dispose()
            childPageTable = Nothing


            Return mismatchVehicleList

        End Function

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
        ''' Returns qc status text to display below vehicleid label on left top corner of the QC screen.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetQCStatusText(ByVal vehicleId As Integer) As String

            Return VehicleAdapter.GetQCStatusText(vehicleId).ToString()

        End Function


        Public Function GetVehicleCommentsText(ByVal vehicleId As Integer) As String
            Dim commentValue As String
            commentValue = CType(VehicleAdapter.GetVehicleCommentText(vehicleId), String)
            Return CType(VehicleAdapter.GetVehicleCommentText(vehicleId), String)

        End Function


        Public Overrides Sub LoadDataSet(ByVal _sender As Integer)

            RaiseEvent LoadingData()

            MyBase.LoadDataSet(_sender)
            SizeAdapter.Fill(Data.Size)
            LoadAllPageTypes()

            RaiseEvent DataLoaded()

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
                _senderID = 0
                Using e As EventArgs = New EventArgs
                    e.Data.Add("EnvelopeId", envelopeID)
                    RaiseEvent EnvelopeSenderNotFound(Me, e)
                End Using
            Else
                _senderID = CInt(Data.Sender.Rows(0).Item(0).ToString)
                _senderName = Data.Sender.Rows(0).Item(1).ToString
                Using e As EventArgs = New EventArgs
                    e.Data.Add("EnvelopeId", envelopeID)
                    e.Data.Add("EnvelopeSenderRow", Data.Sender(0))
                    RaiseEvent EnvelopeSenderLoaded(Me, e)
                End Using
            End If

            Return _senderID
        End Function
        ''' <summary>
        ''' Queries into database and returns true if supplied vehicle is marked as QCed, false otherwise.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function IsVehicleQCed(ByVal vehicleId As Integer) As Boolean
            Dim count As Integer?

            count = CType(Me.VehicleAdapter.IsVehicleQced(vehicleId), Integer?)

            Return (count.HasValue AndAlso count.Value > 0)

        End Function

        Public Overrides Sub LoadVehicle(ByVal vehicleId As Integer, ByVal formName As String)
            Dim isParentVehicleQCed, isChildVehicleQCed As Boolean
            Dim errorMessage As String
            Dim _VehicleID As Integer

            RaiseEvent LoadingVehicle(vehicleId)

            VehicleAdapter.FillByVehicleId(Data.vwCircular, vehicleId, formName, errorMessage)

            If Data.vwCircular.Rows.Count > 0 Then
                If String.IsNullOrEmpty(CStr(Data.vwCircular.Rows(0).Item(21).ToString)) And _RemoteStatus = FormStateEnum.Remote Then
                    MsgBox("Cannot load vehicle because it's not yet been sized.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                _VehicleID = CInt(Data.vwCircular.Rows(0).Item(1).ToString)
                _senderID = LoadEnvelopeSenderInfo(_VehicleID)
                LoadDataSet(_senderID)
            End If

            If Data.vwCircular.Count > 0 AndAlso Data.vwCircular(0).IsParentVehicleIdNull() = False Then
                isChildVehicleQCed = IsVehicleQCed(Data.vwCircular(0).VehicleId)
                isParentVehicleQCed = IsVehicleQCed(Data.vwCircular(0).ParentVehicleId)
            End If

            If Data.vwCircular.Count = 0 AndAlso errorMessage Is Nothing Then
                RaiseEvent VehicleNotFound(vehicleId)
            ElseIf Data.vwCircular.Count = 0 AndAlso errorMessage IsNot Nothing Then
                RaiseEvent InvalidVehicleStatus(errorMessage)
            ElseIf Data.vwCircular.Count > 0 AndAlso Data.vwCircular(0).IsParentVehicleIdNull() = False AndAlso isParentVehicleQCed = False Then
                RaiseEvent ParentVehicleNotQCed(vehicleId, Data.vwCircular(0).ParentVehicleId)
            Else
                RaiseEvent VehicleLoaded(Data.vwCircular(0), isChildVehicleQCed, isParentVehicleQCed)
            End If


        End Sub


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
        ''' Checks whether all columns contain valid values or not. Returns false if not, true otherwise.
        ''' </summary>
        ''' <param name="validateRow"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function AreInputsValid(ByVal validateRow As QCDataSet.vwCircularRow) As Boolean
            Dim areAllValid As Boolean


            RaiseEvent ValidatingInputs()

            areAllValid = True

            If areAllValid Then areAllValid = AreDatesValid(validateRow)

            RaiseEvent InputsValidated()

            Return areAllValid

        End Function


#End Region


        Public Overrides Sub SynchronizeVehicleInformation()

            RaiseEvent SynchronizingVehicleInformation()


            VehicleAdapter.Update(Data.vwCircular)

            RaiseEvent VehicleInformationSynchronized()

        End Sub

        Public Sub Delete(ByVal vehicleId As Integer)
           
            Dim cn As System.Data.SqlClient.SqlConnection

            cn = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())

            cn.Open()

            VehicleAdapter.Adapter.DeleteCommand.Connection = cn


            VehicleAdapter.Adapter.DeleteCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@VehicleId", SqlDbType.Int))
            VehicleAdapter.Adapter.DeleteCommand.Parameters(0).Value = vehicleId

            VehicleAdapter.Adapter.DeleteCommand.ExecuteReader()

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If


        End Sub


        Public Function GetVehiclePageImageBackupFilePath(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As String
            Dim fileCounter As Integer
            Dim imageFileFilter, imageFiles() As String
            Dim pageImageBackupFilePath As System.Text.StringBuilder
            Dim tempPath As String
            Dim CreatedDt As Date

            pageImageBackupFilePath = New System.Text.StringBuilder
            CreatedDt = CDate(GetCreateDtByVehicleId(vehicleId))
            tempPath = GetImagePath(CreatedDt.ToString("yyyyMM"), UserLocationId, GetPathType("Backup"))    ' new logic that will retrieve data in the image path table
            If String.IsNullOrEmpty(tempPath) = False Then
                pageImageBackupFilePath.Append(tempPath)
            Else
                pageImageBackupFilePath.Append(VehicleImageBackupPath)
            End If
            If VehicleImageBackupPath.EndsWith("\") = False Then pageImageBackupFilePath.Append("\")
            pageImageBackupFilePath.Append(vehicleId.ToString())

Retry:
            imageFileFilter = pageNumber.ToString("000") + "_?" + ImageFileExtension
            imageFiles = System.IO.Directory.GetFiles(pageImageBackupFilePath.ToString(), imageFileFilter)
            pageImageBackupFilePath.Append("\")

            For fileCounter = 0 To 26
                pageImageBackupFilePath.Append(imageFileFilter)
                pageImageBackupFilePath.Replace("?", Microsoft.VisualBasic.ChrW(97 + fileCounter))

                If imageFiles.Contains(pageImageBackupFilePath.ToString()) = False Then
                    Exit For
                End If

                pageImageBackupFilePath.Remove(pageImageBackupFilePath.Length - imageFileFilter.Length, imageFileFilter.Length)
            Next

            If fileCounter = 26 Then
                Dim userResponse As DialogResult

                userResponse = MessageBox.Show("Unable to create backup file. To create backup file, remove some of the " _
                                               + "existing files and click Retry button. To proceed without saving " _
                                               + "image for backup, click Cancel button.", Application.ProductName _
                                               , MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning)
                If userResponse = DialogResult.Retry Then
                    pageImageBackupFilePath.Replace(imageFileFilter, "")
                    GoTo Retry
                Else
                    pageImageBackupFilePath.Remove(0, pageImageBackupFilePath.Length)
                End If
            End If

            Array.Clear(imageFiles, 0, imageFiles.Length)
            imageFiles = Nothing
            imageFileFilter = Nothing

            Return pageImageBackupFilePath.ToString()

        End Function

        Private Function GetPathType(ByVal _Type As String) As Integer
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
                Throw New ApplicationException("Unable to get the Path Type Id.", ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return _val
        End Function

        Private Function GetImagePath(ByVal YearMonth As String, ByVal LocationId As Integer, ByVal PathType As Integer) As String
            Dim imgPathCommand As System.Data.SqlClient.SqlCommand
            Dim obj As Object
            Dim Path As System.Text.StringBuilder


            imgPathCommand = New System.Data.SqlClient.SqlCommand
            Path = New System.Text.StringBuilder

            Try
                With imgPathCommand
                    .CommandText = "SELECT path FROM ImagePath WHERE yearmonth=" + YearMonth + " AND LocationId=" + LocationId.ToString + " AND PathTypeid=" + PathType.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With
                If String.IsNullOrEmpty(CType(obj, String)) = True Then Exit Function
                Path.Append(CType(obj, String))
                Path.Append("\")
                Path.Append(YearMonth)
                Path.Append("\")
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If imgPathCommand.Connection.State <> ConnectionState.Closed Then imgPathCommand.Connection.Close()
            End Try

            Return Path.ToString()
        End Function

        ''' <summary>
        ''' Gets URL for downloading page image based on retailer and current page.
        ''' </summary>
        ''' <param name="retailerId"></param>
        ''' <param name="pageNumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetURLForPageImageDownload(ByVal retailerId As Integer, ByVal pageNumber As Integer, ByVal vehicleid As Integer) As String
            Dim urlString As String
                urlString = PageAdapter.GetPageImageDownloadURL(retailerId, pageNumber)
            Return urlString

        End Function
        Public Function GetPageScreenShot(ByVal URL As String) As Bitmap
            Dim webobj As WebBrowser
            Dim rectangle As Rectangle
            Dim bitmap, bitmap2 As Bitmap
            Dim Height, Width As Integer
            Dim Graphic As Graphics


            webobj = New WebBrowser()
            webobj.ScrollBarsEnabled = False


            webobj.ScriptErrorsSuppressed = True
            webobj.Navigate(URL)
            


            While webobj.ReadyState <> WebBrowserReadyState.Complete
                Application.DoEvents()

            End While

            Height = webobj.Document.Body.ScrollRectangle.Height
            Width = webobj.Document.Body.ScrollRectangle.Width



            webobj.Size = New Size(Width, Height)
            bitmap = New Bitmap(Width, Height)
            webobj.DrawToBitmap(bitmap, New Rectangle(0, 0, Width, Height))
            rectangle = New Rectangle(0, 0, Width * 500, Height * 100)

            Graphic = Graphics.FromImage(bitmap)
            Graphic.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic



            webobj.Dispose()

            Return bitmap


            

        End Function
       

        Public Function GetVehicleMedia(ByVal vehicleId As Integer) As String

            Dim mediaid As String
            VehicleAdapter.Fill(Data.vwCircular, vehicleId)
            mediaid = Data.vwCircular(0)("MediaID").ToString()

            Return mediaid



        End Function

        

        Public Function GetWebPageSource(ByVal VehicleID As Integer) As String
            Dim ConnectionString As String
            Dim Connection As SqlClient.SqlConnection
            Dim Adapter As SqlClient.SqlDataAdapter
            Dim WebPageSourceResultset As DataSet

            ConnectionString = GetConnectionStringForSocialDB()
            ConnectionString = ConnectionString.Replace("SocialMedia", "MCAP")


            Connection = New SqlClient.SqlConnection(ConnectionString)
            Connection.Open()

            Adapter = New SqlClient.SqlDataAdapter("select BodyHTML from VehicleBody where VehicleId=" + VehicleID.ToString(), ConnectionString)

            WebPageSourceResultset = New DataSet()

            Adapter.Fill(WebPageSourceResultset)

            Return WebPageSourceResultset.Tables(0).Rows(0).Item(0).ToString()









        End Function






        Public Function FillSubjectForSocial(ByVal vehicleId As Integer) As String ' QCDataSet.vwCircularDataTable
            Dim pgTable As QCDataSet.vwCircularDataTable
            Dim tempAdapter As QCDataSetTableAdapters.vwCircularTableAdapter
            Dim tempRow As DataRow

            tempAdapter = New QCDataSetTableAdapters.vwCircularTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            pgTable = tempAdapter.GetDataBySocial(vehicleId)
            tempRow = pgTable.Rows(0)

            'foreach(DataRow row in YourDataTable.Rows)  {       string name = row["name"].ToString();      string description = row["description"].ToString();      string icoFileName = row["iconFile"].ToString();      string installScript = row["installScript"].ToString();   }
            tempAdapter.Dispose()
            tempAdapter = Nothing

            Return tempRow("Subject").ToString()



        End Function

        Public Function FillByDataForQc(ByVal vehicleId As Integer) As QCDataSet.QcStatusDisplayDataTable
            Dim pgTable As QCDataSet.QcStatusDisplayDataTable
            Dim tempAdapter As QCDataSetTableAdapters.QcStatusDisplayTableAdapter

            tempAdapter = New QCDataSetTableAdapters.QcStatusDisplayTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            pgTable = tempAdapter.GetData(vehicleId)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            Return pgTable

        End Function
        ' Omar additional info
        Public Function FillAdditionalQcInformation(ByVal vehicleId As Integer) As QCDataSet.AdditionalQcInformationDataTable
            Dim pgTable As QCDataSet.AdditionalQcInformationDataTable
            Dim tempAdapter As QCDataSetTableAdapters.AdditionalQcInformationTableAdapter

            tempAdapter = New QCDataSetTableAdapters.AdditionalQcInformationTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            pgTable = tempAdapter.GetDataBy(vehicleId)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            Return pgTable

        End Function

        Public Sub LoadPagesInformation(ByVal vehicleId As Integer)
            Dim tempAdapter As QCDataSetTableAdapters.PageTableAdapter


            tempAdapter = New QCDataSetTableAdapters.PageTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            tempAdapter.Fill(Data.Page, vehicleId)

            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub

        Public Function GetCreateDtByVehicleId(ByVal vehicleId As Integer) As String

            Return VehicleAdapter.GetCreateDtByVehicle(vehicleId).ToString()

        End Function
        Public Sub LoadAdditionalQcInformation()
            LoadAllAdditionalQcInformation()
        End Sub


        Private Sub LoadAllAdditionalQcInformation()

            Data.AdditionalQcInformation.LoadingTable = True
            Data.AdditionalQcInformation.BeginLoadData()
            Dim excpReslt As String
            AddtionalQcInfoAdapter.FillAddionalBy((Data.AdditionalQcInformation))
            Data.AdditionalQcInformation.EndLoadData()
            Data.AdditionalQcInformation.LoadingTable = False


        End Sub

        Public Sub UpdateAdditionalQcInformation(ByVal modifiedRows As QCDataSet.AdditionalQcInformationDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingAdditionalQcInfo(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                AddtionalQcInfoAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update additional qc info(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent AdditionalQcInfoUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Validates Sender information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidateAdditionalQcInfo(ByVal validateTable As QCDataSet.AdditionalQcInformationDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingAdditionalQcInfo(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using


            Dim addtionalqcRows As System.Data.EnumerableRowCollection(Of QCDataSet.AdditionalQcInformationRow)
            addtionalqcRows = From er In validateTable _
                              Where er.RowState <> DataRowState.Deleted AndAlso er.RowState <> DataRowState.Unchanged _
                              Select er


            addtionalqcRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidAdditionalQcInfoFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent AdditionalQcInfoValidated(Me, e)
                End Using
            End If

        End Sub

        ''' <summary>
        ''' Validates column values against database schema.
        ''' </summary>
        ''' <param name="validateTable">DataTable to validate column values.</param>
        ''' <param name="action">Action performed on the supplied row.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ValidateColumnValues _
            (ByVal validateTable As System.Data.DataTable, ByVal action As DataRowAction) _
            As Boolean
            Dim areAllValid, returnStatus As Boolean
            Dim columnName As String
            Dim tempRow As System.Data.DataRow


            areAllValid = True
            For i As Integer = 0 To validateTable.Rows.Count - 1
                tempRow = validateTable(i)

                For j As Integer = 0 To validateTable.Columns.Count - 1
                    columnName = validateTable.Columns(j).ColumnName
                    'returnStatus = Me.Data.ValidateColumnValueAgainstDatabaseSchema(columnName, tempRow(columnName), tempRow, False)
                    columnName = Nothing

                    If areAllValid Then areAllValid = returnStatus
                Next

                tempRow = Nothing
            Next

            Return areAllValid

        End Function

        '''' <summary>
        '''' Validates column values based on database schema information.
        '''' </summary>
        '''' <param name="columnName">Name of column to validated.</param>
        '''' <param name="proposedValue"></param>
        '''' <param name="row"></param>
        '''' <param name="throwException">Flag that indicates when an invalid input found, raise an exception or set column error.</param>
        '''' <returns></returns>
        '''' <remarks></remarks>
        Protected Friend Function ValidateColumnValueAgainstDatabaseSchema _
            (ByVal columnName As String, ByVal proposedValue As Object, ByVal row As System.Data.DataRow, ByVal throwException As Boolean) _
            As Boolean
            Dim returnValue As Boolean
            Dim columnQuery As System.Collections.Generic.IEnumerable(Of QCDataSet.COLUMNSRow)


            returnValue = True

            Return returnValue

        End Function


        Public Function SentFromDetails(ByVal _address As String) As String
            Dim dsDetails As DataSet
            Dim strDetails As String

            dsDetails = SiteDetails(_address)

            With dsDetails.Tables(0)
                If .Rows.Count > 0 Then
                    strDetails = .Rows(0).Item(0).ToString + ", " + .Rows(0).Item(1).ToString + ", " + .Rows(0).Item(2).ToString + ", " + .Rows(0).Item(4).ToString + ", " + .Rows(0).Item(3).ToString + ", " + .Rows(0).Item(5).ToString
                    If String.IsNullOrEmpty(.Rows(0).Item(4).ToString) Then strDetails = .Rows(0).Item(0).ToString + ", " + .Rows(0).Item(1).ToString + ", " + .Rows(0).Item(2).ToString + ", " + .Rows(0).Item(3).ToString + ", " + .Rows(0).Item(5).ToString
                Else
                    strDetails = String.Empty
                End If
            End With

            Return strDetails
        End Function

        Private Function SiteDetails(ByVal _Address As String) As DataSet
            Dim adpt As System.Data.SqlClient.SqlDataAdapter
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim ds As New DataSet

            cmd = New System.Data.SqlClient.SqlCommand
            con = New System.Data.SqlClient.SqlConnection

            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()

            cmd.Connection = con
            If cmd.Connection.State = ConnectionState.Closed Then
                cmd.Connection.Open()
            End If
            cmd.CommandType = CommandType.Text

            _Address = _Address.Replace("'", "")
            cmd.CommandText = "select s.City, s.State, s.Zip, R1.Descrip as Retailer, r2.Descrip as RetRegion, m.Descrip from Site as S LEFT JOIN Ret as R1 " + _
                              "ON r1.RetId=DefaultRetId LEFT JOIN Ret as R2 ON r2.RetId=s.RegionRetId INNER JOIN Mkt as M ON m.MktId=s.DefaultMktId where Address = '" + _Address + "'"

            adpt = New System.Data.SqlClient.SqlDataAdapter(cmd)

            adpt.Fill(ds)

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return ds
        End Function

    End Class


End Namespace