Namespace UI.Processors

    ''' <summary>
    ''' This class is suppose to take care of business rules, fetch data from database and supply it 
    ''' as and when needed by screen.  This class is least concern with how data is going to be 
    ''' displayed and how its going to be stored into/synchronize with database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Maintenance
        Inherits BaseClass


#Region " Events "

        Public Event LoadingPackageTypes()
        Public Event PackageTypesLoaded()
        Public Event LoadingShippingMethods()
        Public Event ShippingMethodsLoaded()
        Public Event LoadingUserList()
        Public Event UserListLoaded()
        Public Event LoadingFrequency()
        Public Event FrequencyLoaded()
        Public Event LoadingSenderTypes()
        Public Event SenderTypesLoaded()
        Public Event LoadingLocations()
        Public Event LocationsLoaded()
        Public Event LoadingSenderList()
        Public Event SenderListLoaded()

        Public Event LoadingColumnConstraints()
        Public Event ColumnConstraintsLoaded()

#End Region


        Private WithEvents m_maintenanceData As MaintenanceDataSet
        Private WithEvents m_DESPmaintenanceData As New DESPRoleAssoc
        Private WithEvents m_SubscriptionData As New SubscriptionDataSet
        Private m_expectationAdapter As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
        Private m_DESPAdapter As New DESPRoleAssocTableAdapters.DESP_StoredProcedureRoleAssocTableAdapter
        Private m_DESPProceduresAdapter As New DESPRoleAssocTableAdapters.DESP_StoredProcedureMaintenanceTableAdapter
        Private m_expectationProjValsAdapter As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
        Private m_languageAdapter As MaintenanceDataSetTableAdapters.LanguageTableAdapter
        Private m_mediaAdapter As MaintenanceDataSetTableAdapters.MediaTableAdapter
        Private m_retAdapter As MaintenanceDataSetTableAdapters.RetTableAdapter
        Private m_mktAdapter As MaintenanceDataSetTableAdapters.MktTableAdapter
        Private m_ShippingTypecodeAdapter As New MaintenanceDataSetTableAdapters.ShippingTypeCodeTableAdapter
        Private m_SubPaymentAdapter As New MaintenanceDataSetTableAdapters.SubPaymentTableAdapter
        Private m_YesNoIndicatorAdapter As New MaintenanceDataSetTableAdapters.YesNoIndicatorTableAdapter
        Private m_SourceIdAdapter As New MaintenanceDataSetTableAdapters.SourceTableAdapter
        Private m_publicationAdapter As MaintenanceDataSetTableAdapters.PublicationTableAdapter
        'Private m_retmktCustomDescrip As MaintenanceDataSetTableAdapters.RetMktCustomDescripTableAdapter
        Private m_retpublicationCoverageAdapter As MaintenanceDataSetTableAdapters.RetPublicationCoverageTableAdapter
        Private m_senderAdapter As MaintenanceDataSetTableAdapters.SenderTableAdapter
        Private m_senderMktAssocAdapter As MaintenanceDataSetTableAdapters.SenderMktAssocTableAdapter
        Private m_senderPublicationAdapter As MaintenanceDataSetTableAdapters.SenderPublicationTableAdapter
        Private m_senderExpectationAdapter As MaintenanceDataSetTableAdapters.SenderExpectationTableAdapter
        Private m_shipperAdapter As MaintenanceDataSetTableAdapters.ShipperTableAdapter
        Private m_sizeAdapter As MaintenanceDataSetTableAdapters.SizeTableAdapter
        Private m_tradeclassAdapter As MaintenanceDataSetTableAdapters.TradeClassTableAdapter
        Private m_websiteAdapter As MaintenanceDataSetTableAdapters.WebsitePageDownloadTableAdapter
        Private m_siteAdapter As MaintenanceDataSetTableAdapters.SiteTableAdapter

        Private m_publicationsubscriptionAdapter As New SubscriptionDataSetTableAdapters.PublicationSubscriptionTableAdapter
        Private m_subscriptionpublicationAdapter As New SubscriptionDataSetTableAdapters.PublicationTableAdapter
        Private m_SubscriptionYesNoIndicatorAdapter As New SubscriptionDataSetTableAdapters.YesNoCodeTableAdapter
        Private m_SubscriptionReceipientAdapter As New SubscriptionDataSetTableAdapters.ReceipientTypeCodeTableAdapter
        Private m_SubscriptionPaidByAdapter As New SubscriptionDataSetTableAdapters.PaidByCodeTableAdapter
        Private m_SubscriptionIdAdapter As New SubscriptionDataSetTableAdapters.SubscriptionIdTableAdapter
        Private m_SubscriptionPrepaidPeriodAdapter As New SubscriptionDataSetTableAdapters.PrepaidPeriodCodeTableAdapter
        Private m_MktSubscriptionAdapter As New SubscriptionDataSetTableAdapters.MktTableAdapter
        Private m_FilteredMktSubscriptionAdapter As New SubscriptionDataSetTableAdapters.MktTableAdapter
        Private _InitCount As Integer



        Private ReadOnly Property ExpectationAdapter() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property

        Private ReadOnly Property DESPAdapter() As DESPRoleAssocTableAdapters.DESP_StoredProcedureRoleAssocTableAdapter
            Get
                Return m_DESPAdapter
            End Get
        End Property

        Private ReadOnly Property DESPProceduresAdapter() As DESPRoleAssocTableAdapters.DESP_StoredProcedureMaintenanceTableAdapter
            Get
                Return m_DESPProceduresAdapter
            End Get
        End Property

        Private ReadOnly Property LanguageAdapter() As MaintenanceDataSetTableAdapters.LanguageTableAdapter
            Get
                Return m_languageAdapter
            End Get
        End Property

        Private ReadOnly Property MediaAdapter() As MaintenanceDataSetTableAdapters.MediaTableAdapter
            Get
                Return m_mediaAdapter
            End Get
        End Property

        Private ReadOnly Property RetAdapter() As MaintenanceDataSetTableAdapters.RetTableAdapter
            Get
                Return m_retAdapter
            End Get
        End Property

        Private ReadOnly Property MktAdapter() As MaintenanceDataSetTableAdapters.MktTableAdapter
            Get
                Return m_mktAdapter
            End Get
        End Property

        Private ReadOnly Property ShippingTypecodeAdapter() As MaintenanceDataSetTableAdapters.ShippingTypeCodeTableAdapter
            Get
                Return m_ShippingTypecodeAdapter
            End Get
        End Property

        Private ReadOnly Property YesNoIndicatorAdapter() As MaintenanceDataSetTableAdapters.YesNoIndicatorTableAdapter
            Get
                Return m_YesNoIndicatorAdapter
            End Get
        End Property

        Private ReadOnly Property SourceIdAdapter() As MaintenanceDataSetTableAdapters.SourceTableAdapter
            Get
                Return m_SourceIdAdapter
            End Get
        End Property

        Private ReadOnly Property SubPaymentAdapter() As MaintenanceDataSetTableAdapters.SubPaymentTableAdapter
            Get
                Return m_SubPaymentAdapter
            End Get
        End Property

        Private ReadOnly Property PublicationAdapter() As MaintenanceDataSetTableAdapters.PublicationTableAdapter
            Get
                Return m_publicationAdapter
            End Get
        End Property

        Private ReadOnly Property SubscriptionYesNoIndicatorAdapter() As SubscriptionDataSetTableAdapters.YesNoCodeTableAdapter
            Get
                Return m_SubscriptionYesNoIndicatorAdapter
            End Get
        End Property

        Private ReadOnly Property SubscriptionReceipientAdapter() As SubscriptionDataSetTableAdapters.ReceipientTypeCodeTableAdapter
            Get
                Return m_SubscriptionReceipientAdapter
            End Get
        End Property

        Private ReadOnly Property SubscriptionPaidByAdapter() As SubscriptionDataSetTableAdapters.PaidByCodeTableAdapter
            Get
                Return m_SubscriptionPaidByAdapter
            End Get
        End Property

        Private ReadOnly Property SubscriptionIdAdapter() As SubscriptionDataSetTableAdapters.SubscriptionIdTableAdapter
            Get
                Return m_SubscriptionIdAdapter
            End Get
        End Property

        Private ReadOnly Property SubscriptionPrepaidPeriodAdapter() As SubscriptionDataSetTableAdapters.PrepaidPeriodCodeTableAdapter
            Get
                Return m_SubscriptionPrepaidPeriodAdapter
            End Get
        End Property

        Private ReadOnly Property MktSubscriptionAdapter() As SubscriptionDataSetTableAdapters.MktTableAdapter
            Get
                Return m_MktSubscriptionAdapter
            End Get
        End Property

        Private ReadOnly Property SubscriptionPublicationAdapter() As SubscriptionDataSetTableAdapters.PublicationTableAdapter
            Get
                Return m_subscriptionpublicationAdapter
            End Get
        End Property

        Private ReadOnly Property PublicationSubscriptionAdapter() As SubscriptionDataSetTableAdapters.PublicationSubscriptionTableAdapter
            Get
                Return m_publicationsubscriptionAdapter
            End Get
        End Property

        Private ReadOnly Property FilteredMktSubscriptionAdapter() As SubscriptionDataSetTableAdapters.MktTableAdapter
            Get
                Return m_FilteredMktSubscriptionAdapter
            End Get
        End Property

        'Private ReadOnly Property RetMktCustomDescripAdapter() As MaintenanceDataSetTableAdapters.RetMktCustomDescripTableAdapter
        '  Get
        '    Return m_retmktCustomDescrip
        '  End Get
        'End Property

        Private ReadOnly Property RetPublicationCoverageAdapter() As MaintenanceDataSetTableAdapters.RetPublicationCoverageTableAdapter
            Get
                Return m_retpublicationCoverageAdapter
            End Get
        End Property

        Private ReadOnly Property SenderAdapter() As MaintenanceDataSetTableAdapters.SenderTableAdapter
            Get
                Return m_senderAdapter
            End Get
        End Property

        Private ReadOnly Property SenderPublicationAdapter() As MaintenanceDataSetTableAdapters.SenderPublicationTableAdapter
            Get
                Return m_senderPublicationAdapter
            End Get
        End Property

        Private ReadOnly Property SenderExpectationAdapter() As MaintenanceDataSetTableAdapters.SenderExpectationTableAdapter
            Get
                Return m_senderExpectationAdapter
            End Get
        End Property

        Private ReadOnly Property SenderMktAssocAdapter() As MaintenanceDataSetTableAdapters.SenderMktAssocTableAdapter
            Get
                Return m_senderMktAssocAdapter
            End Get
        End Property

        Private ReadOnly Property ShipperAdapter() As MaintenanceDataSetTableAdapters.ShipperTableAdapter
            Get
                Return m_shipperAdapter
            End Get
        End Property

        Private ReadOnly Property SizeAdapter() As MaintenanceDataSetTableAdapters.SizeTableAdapter
            Get
                Return m_sizeAdapter
            End Get
        End Property
        Private ReadOnly Property FVReqInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property

        Private ReadOnly Property ADReqInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
    End Property
    Private ReadOnly Property FVEntry360Ind() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
      Get
        Return m_expectationAdapter
      End Get
    End Property

    Private ReadOnly Property ADEntry360Ind() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
      Get
        Return m_expectationAdapter
      End Get
    End Property

        Private ReadOnly Property AdDynReqInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property

        Private ReadOnly Property AdSmtReqInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property ScanReqInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property FsiInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property jaAlcInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property jaAlcMInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property jaAlcVInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property jaallInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property jaAllmInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property jaAllvInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property jaasmInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property jabevInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property jacanInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property jafrVInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property jaHSPeInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property jaHSPsInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property jalnetInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property jamassInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property
        Private ReadOnly Property jaspanInd() As MaintenanceDataSetTableAdapters.ExpectationTableAdapter
            Get
                Return m_expectationAdapter
            End Get
        End Property

        Private ReadOnly Property TradeclassAdapter() As MaintenanceDataSetTableAdapters.TradeClassTableAdapter
            Get
                Return m_tradeclassAdapter
            End Get
        End Property

        Private ReadOnly Property WebsitePageDownloadAdapter() As MaintenanceDataSetTableAdapters.WebsitePageDownloadTableAdapter
            Get
                Return m_websiteAdapter
            End Get
        End Property
        Private ReadOnly Property ForceRunInd() As MaintenanceDataSetTableAdapters.WebsitePageDownloadTableAdapter
            Get
                Return m_websiteAdapter
            End Get
        End Property

        Private ReadOnly Property ActiveInd() As MaintenanceDataSetTableAdapters.WebsitePageDownloadTableAdapter
            Get
                Return m_websiteAdapter
            End Get
        End Property

        Private ReadOnly Property SiteAdapter() As MaintenanceDataSetTableAdapters.SiteTableAdapter
            Get
                Return m_siteAdapter
            End Get
        End Property

        Private ReadOnly Property State() As MaintenanceDataSetTableAdapters.SiteTableAdapter
            Get
                Return m_siteAdapter
            End Get
        End Property
        Private ReadOnly Property Zip() As MaintenanceDataSetTableAdapters.SiteTableAdapter
            Get
                Return m_siteAdapter
            End Get
        End Property

        Public ReadOnly Property Data() As MaintenanceDataSet
            Get
                Return m_maintenanceData
            End Get
        End Property

        Public ReadOnly Property DESPData() As DESPRoleAssoc
            Get
                Return m_DESPmaintenanceData
            End Get
        End Property

        Public ReadOnly Property SubscriptionData() As SubscriptionDataSet
            Get
                Return m_SubscriptionData
            End Get
        End Property

        Public ReadOnly Property InitialCount() As Integer
            Get
                Return _InitCount
            End Get
        End Property


        Public Sub New()

            m_expectationAdapter = New MaintenanceDataSetTableAdapters.ExpectationTableAdapter()
            m_languageAdapter = New MaintenanceDataSetTableAdapters.LanguageTableAdapter()
            m_mediaAdapter = New MaintenanceDataSetTableAdapters.MediaTableAdapter()
            m_retAdapter = New MaintenanceDataSetTableAdapters.RetTableAdapter()
            m_mktAdapter = New MaintenanceDataSetTableAdapters.MktTableAdapter()
            m_publicationAdapter = New MaintenanceDataSetTableAdapters.PublicationTableAdapter()
            'm_retmktCustomDescrip = New MaintenanceDataSetTableAdapters.RetMktCustomDescripTableAdapter()
            m_retpublicationCoverageAdapter = New MaintenanceDataSetTableAdapters.RetPublicationCoverageTableAdapter()
            m_senderAdapter = New MaintenanceDataSetTableAdapters.SenderTableAdapter()
            m_senderMktAssocAdapter = New MaintenanceDataSetTableAdapters.SenderMktAssocTableAdapter()
            m_shipperAdapter = New MaintenanceDataSetTableAdapters.ShipperTableAdapter()
            m_sizeAdapter = New MaintenanceDataSetTableAdapters.SizeTableAdapter()
            m_tradeclassAdapter = New MaintenanceDataSetTableAdapters.TradeClassTableAdapter()
            m_websiteAdapter = New MaintenanceDataSetTableAdapters.WebsitePageDownloadTableAdapter
            m_siteAdapter = New MaintenanceDataSetTableAdapters.SiteTableAdapter
            m_senderPublicationAdapter = New MaintenanceDataSetTableAdapters.SenderPublicationTableAdapter
            m_senderExpectationAdapter = New MaintenanceDataSetTableAdapters.SenderExpectationTableAdapter

            m_maintenanceData = New MaintenanceDataSet()

            _InitCount = 0

        End Sub



        Public Sub Initialize()

            m_expectationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_languageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_mediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_retAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_mktAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_publicationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            'm_retmktCustomDescrip.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_retpublicationCoverageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_senderMktAssocAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_shipperAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_sizeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_tradeclassAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_websiteAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            m_siteAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

        End Sub


#Region " Loading independent master tables "


        Private Sub LoadMarketList()
            Dim marketAdapter As MaintenanceDataSetTableAdapters.MarketListTableAdapter


            marketAdapter = New MaintenanceDataSetTableAdapters.MarketListTableAdapter()
            marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Data.MarketList.BeginLoadData()
            marketAdapter.Fill(Data.MarketList)
            Data.MarketList.EndLoadData()

            marketAdapter.Dispose()
            marketAdapter = Nothing

        End Sub

        Private Sub LoadPepMarketList()
            Dim marketAdapter As MaintenanceDataSetTableAdapters.pepMarketTableAdapter


            marketAdapter = New MaintenanceDataSetTableAdapters.pepMarketTableAdapter()
            marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Data.pepMarket.BeginLoadData()
            marketAdapter.Fill(Data.pepMarket)
            Data.pepMarket.EndLoadData()

            marketAdapter.Dispose()
            marketAdapter = Nothing

        End Sub

        Private Sub LoadMediaList()
            Dim mediaAdapter As MaintenanceDataSetTableAdapters.MediaListTableAdapter


            mediaAdapter = New MaintenanceDataSetTableAdapters.MediaListTableAdapter
            mediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            mediaAdapter.Fill(Data.MediaList)

            mediaAdapter.Dispose()
            mediaAdapter = Nothing

        End Sub

        Public Sub LoadRetailerList()
            Dim RetailerAdapter As MaintenanceDataSetTableAdapters.RetailerListTableAdapter


            RetailerAdapter = New MaintenanceDataSetTableAdapters.RetailerListTableAdapter
            RetailerAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            RetailerAdapter.Fill(Data.RetailerList)

            RetailerAdapter.Dispose()
            RetailerAdapter = Nothing

        End Sub

        Public Sub LoadPepRetailerList()
            Dim RetailerAdapter As MaintenanceDataSetTableAdapters.pepRetailerTableAdapter


            RetailerAdapter = New MaintenanceDataSetTableAdapters.pepRetailerTableAdapter
            RetailerAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            RetailerAdapter.Fill(Data.pepRetailer)

            RetailerAdapter.Dispose()
            RetailerAdapter = Nothing

        End Sub

        Private Sub LoadTradeClassList()
            Dim tradeClassAdapter As MaintenanceDataSetTableAdapters.TradeClassListTableAdapter


            tradeClassAdapter = New MaintenanceDataSetTableAdapters.TradeClassListTableAdapter
            tradeClassAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            tradeClassAdapter.Fill(Data.TradeClassList)

            tradeClassAdapter.Dispose()
            tradeClassAdapter = Nothing

        End Sub

        Private Sub LoadPublicationList()
            Dim publicationAdapter As MaintenanceDataSetTableAdapters.PublicationListTableAdapter


            publicationAdapter = New MaintenanceDataSetTableAdapters.PublicationListTableAdapter()
            publicationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Data.PublicationList.BeginLoadData()
            publicationAdapter.Fill(Data.PublicationList)
            Data.PublicationList.EndLoadData()

            publicationAdapter.Dispose()
            publicationAdapter = Nothing

        End Sub

        Private Sub LoadPepPublicationList()
            Dim publicationAdapter As MaintenanceDataSetTableAdapters.pepPubliationTableAdapter


            publicationAdapter = New MaintenanceDataSetTableAdapters.pepPubliationTableAdapter()
            publicationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Data.pepPubliation.BeginLoadData()
            publicationAdapter.Fill(Data.pepPubliation)
            Data.pepPubliation.EndLoadData()

            publicationAdapter.Dispose()
            publicationAdapter = Nothing

        End Sub

        Public Sub LoadExpectationList(ByVal _media As Integer, ByVal _mkt As Integer, ByVal _ret As Integer, ByVal isFilter As Boolean)
            Dim ExpectationAdapter As MaintenanceDataSetTableAdapters.ExpectationTableAdapter

            ExpectationAdapter = New MaintenanceDataSetTableAdapters.ExpectationTableAdapter()
            ExpectationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Data.Expectation.BeginLoadData()
            If isFilter = True Then
                REM: , Date.Today
                ExpectationAdapter.FillByMediaMktRet(Data.Expectation, _ret, _mkt, _media)
            Else
                ExpectationAdapter.Fill(Data.Expectation)
            End If
            Data.Expectation.EndLoadData()

            ExpectationAdapter.Dispose()
            ExpectationAdapter = Nothing

        End Sub

        Private Sub LoadFrequencies()
            Dim frequencyAdapter As MaintenanceDataSetTableAdapters.vwFrequencyTableAdapter

            RaiseEvent LoadingFrequency()

            frequencyAdapter = New MaintenanceDataSetTableAdapters.vwFrequencyTableAdapter()
            frequencyAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Data.vwFrequency.BeginLoadData()
            frequencyAdapter.Fill(Data.vwFrequency)
            Data.vwFrequency.EndLoadData()

            frequencyAdapter.Dispose()
            frequencyAdapter = Nothing

            RaiseEvent FrequencyLoaded()

        End Sub

        Private Sub LoadSenderTypes()
            Dim senderTypeAdapter As MaintenanceDataSetTableAdapters.vwSenderTypeTableAdapter


            RaiseEvent LoadingSenderTypes()

            senderTypeAdapter = New MaintenanceDataSetTableAdapters.vwSenderTypeTableAdapter()
            senderTypeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Data.vwSenderType.BeginLoadData()
            senderTypeAdapter.Fill(Data.vwSenderType)
            Data.vwSenderType.EndLoadData()

            senderTypeAdapter.Dispose()
            senderTypeAdapter = Nothing

            RaiseEvent SenderTypesLoaded()

        End Sub

        Private Sub LoadLocations()
            Dim locationAdapter As MaintenanceDataSetTableAdapters.vwLocationTableAdapter


            RaiseEvent LoadingLocations()

            locationAdapter = New MaintenanceDataSetTableAdapters.vwLocationTableAdapter()
            locationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Data.vwLocation.BeginLoadData()
            locationAdapter.Fill(Data.vwLocation)
            Data.vwLocation.EndLoadData()

            locationAdapter.Dispose()
            locationAdapter = Nothing

            RaiseEvent LocationsLoaded()

        End Sub

        Private Sub LoadSenderList()
            Dim senderListAdapter As MaintenanceDataSetTableAdapters.SenderListTableAdapter


            RaiseEvent LoadingSenderList()

            senderListAdapter = New MaintenanceDataSetTableAdapters.SenderListTableAdapter()
            senderListAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Data.SenderList.BeginLoadData()
            senderListAdapter.Fill(Data.SenderList, UserLocationId)
            Data.SenderList.EndLoadData()

            senderListAdapter.Dispose()
            senderListAdapter = Nothing

            RaiseEvent SenderListLoaded()

        End Sub

        Private Sub LoadAllSenderList()
            Dim senderListAdapter As MaintenanceDataSetTableAdapters.SenderListTableAdapter


            RaiseEvent LoadingSenderList()

            senderListAdapter = New MaintenanceDataSetTableAdapters.SenderListTableAdapter()
            senderListAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Data.SenderList.BeginLoadData()
            senderListAdapter.FillAllSendersOrderByName(Data.SenderList)
            Data.SenderList.EndLoadData()

            senderListAdapter.Dispose()
            senderListAdapter = Nothing

            RaiseEvent SenderListLoaded()

        End Sub

        Private Sub LoadAllSenderListOrderByName()
            Dim senderListAdapter As MaintenanceDataSetTableAdapters.SenderListTableAdapter


            RaiseEvent LoadingSenderList()

            senderListAdapter = New MaintenanceDataSetTableAdapters.SenderListTableAdapter()
            senderListAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Data.SenderList.BeginLoadData()
            senderListAdapter.FillAllSendersOrderByName(Data.SenderList)
            Data.SenderList.EndLoadData()

            senderListAdapter.Dispose()
            senderListAdapter = Nothing

            RaiseEvent SenderListLoaded()

        End Sub

        Private Sub LoadUserList()
            Dim userAdapter As MaintenanceDataSetTableAdapters.UserTableAdapter


            RaiseEvent LoadingUserList()

            userAdapter = New MaintenanceDataSetTableAdapters.UserTableAdapter()
            userAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Data.User.BeginLoadData()
            userAdapter.Fill(Data.User)
            Data.User.EndLoadData()

            userAdapter.Dispose()
            userAdapter = Nothing

            RaiseEvent UserListLoaded()

        End Sub

        Private Sub LoadNonHiddenUsersList()
            Dim userAdapter As MaintenanceDataSetTableAdapters.UserTableAdapter


            RaiseEvent LoadingUserList()

            userAdapter = New MaintenanceDataSetTableAdapters.UserTableAdapter()
            userAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Data.User.BeginLoadData()
            userAdapter.FillNonHiddenUser(Data.User)
            Data.User.EndLoadData()

            userAdapter.Dispose()
            userAdapter = Nothing

            RaiseEvent UserListLoaded()

        End Sub

        Private Sub LoadCoverageList()
            Dim CoverageAdapter As MaintenanceDataSetTableAdapters.CoverageTableAdapter


            CoverageAdapter = New MaintenanceDataSetTableAdapters.CoverageTableAdapter()
            CoverageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Data.Coverage.BeginLoadData()
            CoverageAdapter.Fill(Data.Coverage)
            Data.Coverage.EndLoadData()

            CoverageAdapter.Dispose()
            CoverageAdapter = Nothing

        End Sub

        Private Sub LoadWeekdays()
            Dim weekdayArray(6) As String
            Dim tempRow As MaintenanceDataSet.WeekdaysRow


            weekdayArray = New String() {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}
            Data.Weekdays.BeginLoadData()

            For i As Integer = 0 To weekdayArray.Length - 1
                tempRow = Data.Weekdays.NewWeekdaysRow()
                tempRow.BeginEdit()
                tempRow.Weekday = weekdayArray(i)
                tempRow.EndEdit()
                Data.Weekdays.AddWeekdaysRow(tempRow)
                tempRow = Nothing
            Next

            Data.Weekdays.EndLoadData()
            Data.Weekdays.AcceptChanges()

            System.Array.Clear(weekdayArray, 0, weekdayArray.Length)
            weekdayArray = Nothing

        End Sub

        Private Sub LoadNeedTrackingNoOptions()
            Dim optionsArray(6) As String
            Dim tempRow As MaintenanceDataSet.NeedTrackingNoRow


            optionsArray = New String() {"No", "Yes"}
            Data.NeedTrackingNo.BeginLoadData()

            For i As Integer = 0 To optionsArray.Length - 1
                tempRow = Data.NeedTrackingNo.NewNeedTrackingNoRow()
                tempRow.BeginEdit()
                tempRow.CodeId = CType(i, Byte)
                tempRow.Descrip = optionsArray(i)
                tempRow.EndEdit()
                Data.NeedTrackingNo.AddNeedTrackingNoRow(tempRow)
                tempRow = Nothing
            Next

            Data.NeedTrackingNo.EndLoadData()
            Data.NeedTrackingNo.AcceptChanges()

            System.Array.Clear(optionsArray, 0, optionsArray.Length)
            optionsArray = Nothing

        End Sub

        Private Sub LoadShippingOptions()
            Dim optionsArray() As String
            Dim tempRow As MaintenanceDataSet.ShippingRow


            optionsArray = New String() {"Yes", "No"}
            Data.Shipping.BeginLoadData()

            For i As Integer = 0 To optionsArray.Length - 1
                tempRow = Data.Shipping.NewShippingRow()
                tempRow.BeginEdit()
                tempRow.CodeId = CType(i, Byte)
                tempRow.Descrip = optionsArray(i)
                tempRow.EndEdit()
                Data.Shipping.AddShippingRow(tempRow)
                tempRow = Nothing
            Next

            Data.Shipping.EndLoadData()
            Data.Shipping.AcceptChanges()

            System.Array.Clear(optionsArray, 0, optionsArray.Length)
            optionsArray = Nothing

        End Sub

        Private Sub LoadPublicationOptions()
            Dim optionsArray() As String
            Dim tempRow As MaintenanceDataSet.HasPublicationRow


            optionsArray = New String() {"Yes", "No"}
            Data.HasPublication.BeginLoadData()

            For i As Integer = 0 To optionsArray.Length - 1
                tempRow = Data.HasPublication.NewHasPublicationRow()
                tempRow.BeginEdit()
                tempRow.CodeId = CType(i, Byte)
                tempRow.Descrip = optionsArray(i)
                tempRow.EndEdit()
                Data.HasPublication.AddHasPublicationRow(tempRow)
                tempRow = Nothing
            Next

            Data.HasPublication.EndLoadData()
            Data.HasPublication.AcceptChanges()

            System.Array.Clear(optionsArray, 0, optionsArray.Length)
            optionsArray = Nothing

        End Sub

        Private Sub LoadTrueFalseOptions()
            Dim optionsArray() As String
            Dim tempRow As MaintenanceDataSet.TrueFalseOptionRow


            optionsArray = New String() {"True", "False"}
            Data.TrueFalseOption.BeginLoadData()

            For i As Integer = 0 To optionsArray.Length - 1
                tempRow = Data.TrueFalseOption.NewTrueFalseOptionRow()
                tempRow.BeginEdit()
                tempRow.CodeId = CType(i, Byte)
                tempRow.Descrip = optionsArray(i)
                tempRow.EndEdit()
                Data.TrueFalseOption.AddTrueFalseOptionRow(tempRow)
                tempRow = Nothing
            Next

            Data.TrueFalseOption.EndLoadData()
            Data.TrueFalseOption.AcceptChanges()

            System.Array.Clear(optionsArray, 0, optionsArray.Length)
            optionsArray = Nothing

        End Sub

        Private Sub LoadDPIList()
            Dim dpiAdapter As MCAP.MaintenanceDataSetTableAdapters.vwScanDPITableAdapter


            dpiAdapter = New MCAP.MaintenanceDataSetTableAdapters.vwScanDPITableAdapter()
            dpiAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            dpiAdapter.Fill(Data.vwScanDPI)

            dpiAdapter.Dispose()
            dpiAdapter = Nothing

        End Sub

        Private Sub LoadMaintainanceProjects()
            Dim mpAdapter As MCAP.MaintenanceDataSetTableAdapters.ExpectationProjectValsTableAdapter


            mpAdapter = New MCAP.MaintenanceDataSetTableAdapters.ExpectationProjectValsTableAdapter()
            mpAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            mpAdapter.Fill(Data.ExpectationProjectVals)

            mpAdapter.Dispose()
            mpAdapter = Nothing

        End Sub

        Private Sub LoadWebsiteProjects()
            ' Website other adapter
            Dim wpAdapter As MCAP.MaintenanceDataSetTableAdapters.WebsitePageDownloadValuesTableAdapter

            wpAdapter = New MCAP.MaintenanceDataSetTableAdapters.WebsitePageDownloadValuesTableAdapter()
            wpAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            wpAdapter.Fill(Data.WebsitePageDownloadValues)

            wpAdapter.Dispose()
            wpAdapter = Nothing

        End Sub

        Private Sub LoadPageDownloadFrequency()
            ' Website other adapter
            Dim wpAdapter As MCAP.MaintenanceDataSetTableAdapters.PageDownloadFrequencyTableAdapter

            wpAdapter = New MCAP.MaintenanceDataSetTableAdapters.PageDownloadFrequencyTableAdapter()
            wpAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            wpAdapter.Fill(Data.PageDownloadFrequency)

            wpAdapter.Dispose()
            wpAdapter = Nothing

        End Sub

        Private Sub LoadPageTypeIds()
            ' Website other adapter
            Dim wpAdapter As MCAP.MaintenanceDataSetTableAdapters.PageTypeTableAdapter

            wpAdapter = New MCAP.MaintenanceDataSetTableAdapters.PageTypeTableAdapter()
            wpAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            wpAdapter.Fill(Data.PageType)

            wpAdapter.Dispose()
            wpAdapter = Nothing

        End Sub
        Private Sub LoadOnlineWebsitePageTypeIds()
            ' Website other adapter
            Dim wpAdapter As MCAP.MaintenanceDataSetTableAdapters.PageTypeTableAdapter

            wpAdapter = New MCAP.MaintenanceDataSetTableAdapters.PageTypeTableAdapter()
            wpAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            wpAdapter.FillByOnlineWebsite(Data.PageType)

            wpAdapter.Dispose()
            wpAdapter = Nothing

        End Sub

        Private Sub LoadSiteRetailerList()
            Dim RetailerAdapter As MaintenanceDataSetTableAdapters.RetailerListTableAdapter


            RetailerAdapter = New MaintenanceDataSetTableAdapters.RetailerListTableAdapter
            RetailerAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            RetailerAdapter.Fill(Data.RetailerList)

            RetailerAdapter.Dispose()
            RetailerAdapter = Nothing

        End Sub

        Public Sub LoadDataSet()

            LoadWeekdays()
            LoadNeedTrackingNoOptions()
            LoadShippingOptions()
            LoadPublicationOptions()

            'LoadMediaList()
            'LoadTradeClassList()
            'LoadRetailerList()
            'LoadMarkets()
            'LoadPublicationList()
            'LoadShippingMethods()
            'LoadPackageTypes()
            'LoadFrequency()

        End Sub


#End Region


        ''' <summary>
        ''' Loads column information for table name.
        ''' </summary>
        ''' <param name="tableName">Column information will be fetched for table.</param>
        ''' <remarks></remarks>
        Public Sub LoadColumnConstraintsForTable(ByVal tableName As String)
            Dim columnsAdapter As MaintenanceDataSetTableAdapters.COLUMNSTableAdapter


            RaiseEvent LoadingColumnConstraints()

            columnsAdapter = New MaintenanceDataSetTableAdapters.COLUMNSTableAdapter
            columnsAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            columnsAdapter.ClearBeforeFill = True
            columnsAdapter.Fill(Data.COLUMNS, tableName)

            columnsAdapter.Dispose()
            columnsAdapter = Nothing

            RaiseEvent ColumnConstraintsLoaded()

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
                    returnStatus = Me.Data.ValidateColumnValueAgainstDatabaseSchema(columnName, tempRow(columnName), tempRow, False)
                    columnName = Nothing

                    If areAllValid Then areAllValid = returnStatus
                Next

                tempRow = Nothing
            Next

            Return areAllValid

        End Function



#Region " Methods for Expectation table. "


        Public Event LoadingExpectations As MCAPCancellableEventHandler
        Public Event ExpectationExceedsNonFilteredRowsLimit As MCAPEventHandler
        Public Event ExpectationsLoaded As MCAPEventHandler

        Public Event ValidatingExpectation As MCAPCancellableEventHandler
        Public Event InvalidExpectationFound As MCAPEventHandler
        Public Event ExpectationValidated As MCAPEventHandler

        Public Event InsertingExpectation As MCAPCancellableEventHandler
        Public Event ExpectationInserted As MCAPEventHandler

        Public Event UpdatingExpectation As MCAPCancellableEventHandler
        Public Event ExpectationUpdated As MCAPEventHandler

        Public Event DeletingExpectation As MCAPCancellableEventHandler
        Public Event ExpectationDeleted As MCAPEventHandler


        ''' <summary>
        ''' Gets total number of rows in expectation table.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetExpectationTableRowCount() As Integer
            Dim rowCount As Nullable(Of Integer)


            rowCount = CType(ExpectationAdapter.GetRowCount(), Integer?)
            If rowCount.HasValue Then
                Return rowCount.Value
            Else
                Return 0
            End If

        End Function

        ''' <summary>
        ''' Gets boolean value indicating whether specified retaler - market - media combination exist or not.
        ''' </summary>
        ''' <param name="retId"></param>
        ''' <param name="mktId"></param>
        ''' <param name="mediaId"></param>
        ''' <param name="expectationId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsRetailerMarketMediaCombinationUnique(ByVal retId As Integer, ByVal mktId As Integer, ByVal mediaId As Integer, ByVal expectationId As Integer) As Boolean
            Dim count As Integer?


            count = ExpectationAdapter.GetRetMktMediaCombinationCount(retId, mktId, mediaId, expectationId)

            Return (count.HasValue AndAlso count.Value = 0)

        End Function

        ''' <summary>
        ''' Loads all expectations from database, sorted by Expectation Id.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllExpectations()

            Data.Expectation.LoadingTable = True
            Data.Expectation.BeginLoadData()
            ExpectationAdapter.Fill(Data.Expectation)
            Data.Expectation.EndLoadData()
            Data.Expectation.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads expectations from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredExpectations(ByVal filterCondition As String)
            Dim FilterString As String
            FilterString = filterCondition.Replace("E.", "")
            Data.Expectation.LoadingTable = True
            Data.Expectation.BeginLoadData()
            ExpectationAdapter.FillByWhereClause(Data.Expectation, FilterString)
            Data.Expectation.EndLoadData()
            Data.Expectation.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads expectation information from database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadExpectations(Optional ByVal filterCondition As String = Nothing)
            Dim rowFilter As String = Nothing


            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False
                e.Data.Add("Filter", filterCondition)

                RaiseEvent LoadingExpectations(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                ElseIf e.Data.Contains("Filter") AndAlso e.Data("Filter") IsNot Nothing Then
                    rowFilter = e.Data("Filter").ToString()
                End If
            End Using

            If Data.MediaList.Count = 0 Then LoadMediaList()
            If Data.RetailerList.Count = 0 Then LoadRetailerList()
            If Data.MarketList.Count = 0 Then LoadMarketList()
            If Data.vwFrequency.Count = 0 Then LoadFrequencies()
            If Data.vwScanDPI.Count = 0 Then LoadDPIList()
            If Data.Coverage.Count = 0 Then LoadCoverageList()
            LoadMaintainanceProjects()

            If rowFilter Is Nothing AndAlso GetExpectationTableRowCount() > MaximumNonFilteredRowsAllowed Then
                Using e As Processors.EventArgs = New Processors.EventArgs()
                    Data.Expectation.Clear()
                    RaiseEvent ExpectationExceedsNonFilteredRowsLimit(Me, e)
                    Exit Sub
                End Using
            End If

            If rowFilter Is Nothing Then
                LoadAllExpectations()
            Else
                LoadFilteredExpectations(rowFilter)
            End If

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent ExpectationsLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Loads DESP DESP Association information from database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadDESPRoleAssoc(Optional ByVal filterCondition As String = Nothing)
            Dim rowFilter As String = Nothing


            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False
                e.Data.Add("Filter", filterCondition)

                RaiseEvent LoadingDESPRoleAssoc(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                ElseIf e.Data.Contains("Filter") AndAlso e.Data("Filter") IsNot Nothing Then
                    rowFilter = e.Data("Filter").ToString()
                End If
            End Using

            If DESPData.Role.Count = 0 Then LoadDESPRoleList()
            If DESPData.DESP_StoredProcedure.Count = 0 Then LoadDESP_SPList()

            Dim x As Integer = 100
            If rowFilter Is Nothing AndAlso GetDESPUserAssocTableRowCount() > MaximumNonFilteredRowsAllowed Then
                Using e As Processors.EventArgs = New Processors.EventArgs()
                    DESPData.DESP_StoredProcedureRoleAssoc.Clear()
                    RaiseEvent DESPRoleAssocExceedsNonFilteredRowsLimit(Me, e)
                    Exit Sub
                End Using
            End If

            If rowFilter Is Nothing Then
                LoadAllDESP_RoleAssocList()
            Else
                LoadFilteredDESPRoleAssoc(rowFilter)
            End If

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent DESPRoleAssocLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateExpectationTable(ByVal validateRows() As MaintenanceDataSet.ExpectationRow)
            Dim isUnique As Boolean
            Dim tempRow As MaintenanceDataSet.ExpectationRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow Is Nothing Then Continue For

                isUnique = IsRetailerMarketMediaCombinationUnique(tempRow.RetId, tempRow.MktId _
                                                                  , tempRow.MediaId, tempRow.ExpectationID)
                If isUnique = False Then
                    tempRow.RowError = "Retailer - Market - Media combination must be unique."
                Else
                    tempRow.RowError = String.Empty
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates row values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateExpectationRows(ByVal validateRows() As MaintenanceDataSet.ExpectationRow)
            Dim tempRow As MaintenanceDataSet.ExpectationRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow Is Nothing Then Continue For

                If tempRow.IsRetIdNull() AndAlso tempRow.Table.Columns("RetId").AllowDBNull = False Then
                    tempRow.SetColumnError("RetId", "Specify retailer.")
                Else
                    tempRow.SetColumnError("RetId", String.Empty)
                End If

                If tempRow.IsMktIdNull() AndAlso tempRow.Table.Columns("MktId").AllowDBNull = False Then
                    tempRow.SetColumnError("MktId", "Specify market.")
                Else
                    tempRow.SetColumnError("MktId", String.Empty)
                End If

                If tempRow.IsMediaIdNull() AndAlso tempRow.Table.Columns("MediaId").AllowDBNull = False Then
                    tempRow.SetColumnError("MediaId", "Specify media.")
                Else
                    tempRow.SetColumnError("MediaId", String.Empty)
                End If

                If tempRow.IsFrequencyIdNull() AndAlso tempRow.Table.Columns("FrequencyId").AllowDBNull = False Then
                    tempRow.SetColumnError("FrequencyId", "Specify frequency.")
                Else
                    tempRow.SetColumnError("FrequencyId", String.Empty)
                End If

                If tempRow.IsStartDtNull() AndAlso tempRow.Table.Columns("RetId").AllowDBNull = False Then
                    tempRow.SetColumnError("StartDt", "Specify start date.")
                Else
                    tempRow.SetColumnError("StartDt", String.Empty)
                End If

                If tempRow.IsStartDtNull() AndAlso tempRow.Table.Columns("EndDt").AllowDBNull = False Then
                    tempRow.SetColumnError("EndDt", "Specify end date.")
                Else
                    tempRow.SetColumnError("EndDt", String.Empty)
                End If

                If tempRow.IsPriorityNull() AndAlso tempRow.Table.Columns("RetId").AllowDBNull = False Then
                    tempRow.SetColumnError("Priority", "Specify priority.")
                Else
                    tempRow.SetColumnError("Priority", String.Empty)
                End If

                If tempRow.IsCommentsNull() AndAlso tempRow.Table.Columns("Comments").AllowDBNull = False Then
                    tempRow.SetColumnError("Comments", "Specify comments.")
                Else
                    tempRow.SetColumnError("Comments", String.Empty)
                End If

                If tempRow.IsFVReqIndNull() AndAlso tempRow.Table.Columns("FVReqInd").AllowDBNull = False Then
                    tempRow.SetColumnError("FVReqInd", "Specify FVReqInd.")
                Else
                    tempRow.SetColumnError("FVReqInd", String.Empty)
                End If

                If tempRow.IsADReqIndNull() AndAlso tempRow.Table.Columns("ADReqInd").AllowDBNull = False Then
                    tempRow.SetColumnError("ADReqInd", "Specify ADReqInd.")
                Else
                    tempRow.SetColumnError("ADReqInd", String.Empty)
        End If

        If tempRow.IsFVEntry360IndNull() AndAlso tempRow.Table.Columns("FVEntry360Ind").AllowDBNull = False Then
          tempRow.SetColumnError("FVEntry360Ind", "Specify FVEntry360Ind.")
        Else
          tempRow.SetColumnError("FVEntry360Ind", String.Empty)
        End If

        If tempRow.IsADEntry360IndNull() AndAlso tempRow.Table.Columns("ADEntry360Ind").AllowDBNull = False Then
          tempRow.SetColumnError("ADEntry360Ind", "Specify ADEntry360Ind.")
        Else
          tempRow.SetColumnError("ADEntry360Ind", String.Empty)
        End If

                If tempRow.IsMissingAdCommentsNull() AndAlso tempRow.Table.Columns("MissingAdComments").AllowDBNull = False Then
                    tempRow.SetColumnError("MissingAdComments", "Specify missing Ad comments.")
                Else
                    tempRow.SetColumnError("MissingAdComments", String.Empty)
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates Sender information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidateExpectationInformation(ByVal validateTable As MaintenanceDataSet.ExpectationDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingExpectation(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim expectationRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.ExpectationRow)
            expectationRows = From er In validateTable _
                              Where er.RowState <> DataRowState.Deleted AndAlso er.RowState <> DataRowState.Unchanged _
                              Select er

            'Row level validations are done here. e.g. value is not null, value should fall within certain range, etc.
            ValidateExpectationRows(expectationRows.ToArray())

            'Table level validations here. e.g. name is unique in table, etc.
            ValidateExpectationTable(expectationRows.ToArray())

            expectationRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidExpectationFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent ExpectationValidated(Me, e)
                End Using
            End If

        End Sub

        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">Expectation table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertExpectation(ByVal newrowsTable As MaintenanceDataSet.ExpectationDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingExpectation(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                ExpectationAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new expectation.", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent ExpectationInserted(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in expectation data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateExpectations(ByVal modifiedRows As MaintenanceDataSet.ExpectationDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingExpectation(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                ExpectationAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update expectation(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent ExpectationUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in expectation data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteExpectations(ByVal deletedRows As MaintenanceDataSet.ExpectationDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingExpectation(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                'ExpectationAdapter.Update(deletedRows)
                ExpectationAdapter.Update(Data.Expectation)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete expectation(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent ExpectationDeleted(Me, e)
            End Using

        End Sub


#End Region

#Region "Methods for DESP Role Assoc Table"
        Public Event LoadingDESPRoleAssoc As MCAPCancellableEventHandler
        Public Event DESPRoleAssocExceedsNonFilteredRowsLimit As MCAPEventHandler
        Public Event DESPRoleAssocLoaded As MCAPEventHandler

        Public Event ValidatingDESPRoleAssoc As MCAPCancellableEventHandler
        Public Event InvalidDESPRoleAssocFound As MCAPEventHandler
        Public Event DESPRoleAssocValidated As MCAPEventHandler

        Public Event InsertingDESPRoleAssoc As MCAPCancellableEventHandler
        Public Event DESPRoleAssocInserted As MCAPEventHandler

        Public Event UpdatingDESPRoleAssoc As MCAPCancellableEventHandler
        Public Event DESPRoleAssocUpdated As MCAPEventHandler

        Public Event DeletingDESPRoleAssoc As MCAPCancellableEventHandler
        Public Event DESPRoleAssocDeleted As MCAPEventHandler

        Private Sub LoadDESPRoleList()
            Dim RoleAdapter As DESPRoleAssocTableAdapters.RoleTableAdapter 'MaintenanceDataSetTableAdapters.MediaListTableAdapter


            RoleAdapter = New DESPRoleAssocTableAdapters.RoleTableAdapter
            RoleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            RoleAdapter.Fill(DESPData.Role)

            RoleAdapter.Dispose()
            RoleAdapter = Nothing

        End Sub

        Private Sub LoadDESP_SPList()
            Dim DESP_SPAdapter As DESPRoleAssocTableAdapters.DESP_StoredProcedureTableAdapter 'MaintenanceDataSetTableAdapters.MediaListTableAdapter


            DESP_SPAdapter = New DESPRoleAssocTableAdapters.DESP_StoredProcedureTableAdapter
            DESP_SPAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            DESP_SPAdapter.Fill(DESPData.DESP_StoredProcedure)

            DESP_SPAdapter.Dispose()
            DESP_SPAdapter = Nothing

        End Sub

        Public Function GetDESPUserAssocTableRowCount() As Integer
            Dim rowCount As Nullable(Of Integer)


            rowCount = DESPAdapter.GetRowCount()
            If rowCount.HasValue Then
                Return rowCount.Value
            Else
                Return 0
            End If

        End Function

        ''' <summary>
        ''' Loads all DESP User Assoc from database
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllDESP_RoleAssocList()

            DESPData.DESP_StoredProcedure.BeginLoadData()
            DESPAdapter.Fill(DESPData.DESP_StoredProcedureRoleAssoc)
            DESPData.DESP_StoredProcedure.EndLoadData()

        End Sub

        ''' <summary>
        ''' Loads expectations from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredDESPRoleAssoc(ByVal filterCondition As String)

            'DESPData.Expectation.LoadingTable = True
            DESPData.DESP_StoredProcedureRoleAssoc.BeginLoadData()
            DESPAdapter.FillByWhereClause(DESPData.DESP_StoredProcedureRoleAssoc, filterCondition)
            DESPData.DESP_StoredProcedureRoleAssoc.EndLoadData()
            'DESPData.Expectation.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in DESP Role Association data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteDESPRoleAssoc(ByVal deletedRows As DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingDESPRoleAssoc(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                'ExpectationAdapter.Update(deletedRows)
                DESPAdapter.Update(DESPData.DESP_StoredProcedureRoleAssoc)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete expectation(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent DESPRoleAssocDeleted(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in DESP Role Association data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateDESPRoleAssoc(ByVal modifiedRows As DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingDESPRoleAssoc(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                DESPAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update expectation(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent DESPRoleAssocUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">Expectation table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertDESPRoleAssoc(ByVal newrowsTable As DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingDESPRoleAssoc(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                DESPAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert DESP Role Association.", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent DESPRoleAssocInserted(Me, e)
            End Using

        End Sub
#End Region

#Region "Methods for DESP Procedures Table"
        Public Event LoadingDESPProcedures As MCAPCancellableEventHandler
        Public Event DESPProceduresExceedsNonFilteredRowsLimit As MCAPEventHandler
        Public Event DESPProceduresLoaded As MCAPEventHandler

        Public Event ValidatingDESPProcedures As MCAPCancellableEventHandler
        Public Event InvalidDESPProceduresFound As MCAPEventHandler
        Public Event DESPProceduresValidated As MCAPEventHandler

        Public Event InsertingDESPProcedures As MCAPCancellableEventHandler
        Public Event DESPProceduresInserted As MCAPEventHandler

        Public Event UpdatingDESPProcedures As MCAPCancellableEventHandler
        Public Event DESPProceduresUpdated As MCAPEventHandler

        Public Event DeletingDESPProcedures As MCAPCancellableEventHandler
        Public Event DESPProceduresDeleted As MCAPEventHandler

        ''' <summary>
        ''' Loads all DESP Procedures from database.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllDESPProcedures()

            DESPData.DESP_StoredProcedureMaintenance.Clear()
            DESPData.DESP_StoredProcedureMaintenance.LoadingTable = True
            DESPData.DESP_StoredProcedureMaintenance.BeginLoadData()
            DESPProceduresAdapter.Fill(DESPData.DESP_StoredProcedureMaintenance)
            DESPData.DESP_StoredProcedureMaintenance.EndLoadData()
            DESPData.DESP_StoredProcedureMaintenance.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads media types from database, sorted by media name.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadDESPProcedureList()

            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False

                RaiseEvent LoadingDESPProcedures(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                End If
            End Using

            LoadAllDESPProcedures()

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent DESPProceduresLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Loads expectations from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredDESPProcedures(ByVal filterCondition As String)

            DESPData.DESP_StoredProcedureMaintenance.LoadingTable = True
            DESPData.DESP_StoredProcedureMaintenance.BeginLoadData()
            DESPProceduresAdapter.FillByWhereClause(DESPData.DESP_StoredProcedureMaintenance, filterCondition)
            DESPData.DESP_StoredProcedureMaintenance.EndLoadData()
            DESPData.DESP_StoredProcedureMaintenance.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in DESP Role Association data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteDESPProcedures(ByVal deletedRows As DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingDESPProcedures(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                'ExpectationAdapter.Update(deletedRows)
                DESPProceduresAdapter.Update(DESPData.DESP_StoredProcedureMaintenance)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete DESP Procedure(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent DESPProceduresDeleted(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in DESP Role Association data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateDESPProcedures(ByVal modifiedRows As DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingDESPProcedures(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                DESPProceduresAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update DESP Procedure(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent DESPProceduresUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">Expectation table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertDESProcedures(ByVal newrowsTable As DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingDESPProcedures(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                DESPProceduresAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert DESP Procedures.", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent DESPProceduresInserted(Me, e)
            End Using

        End Sub
#End Region

#Region " Methods for Language table. "


        Public Event LoadingLanguages As MCAPCancellableEventHandler
        Public Event LanguagesLoaded As MCAPEventHandler

        Public Event ValidatingLanguage As MCAPCancellableEventHandler
        Public Event InvalidLanguageInformationFound As MCAPEventHandler
        Public Event LanguageValidated As MCAPEventHandler

        Public Event InsertingLanguage As MCAPCancellableEventHandler
        Public Event LanguageInserted As MCAPEventHandler

        Public Event UpdatingLanguage As MCAPCancellableEventHandler
        Public Event LanguageUpdated As MCAPEventHandler

        Public Event DeletingLanguage As MCAPCancellableEventHandler
        Public Event LanguageDeleted As MCAPEventHandler


        ''' <summary>
        ''' Loads all languages from database, sorted by language name.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllLanguages()

            Data.Language.LoadingTable = True
            Data.Language.BeginLoadData()
            LanguageAdapter.Fill(Data.Language)
            Data.Language.EndLoadData()
            Data.Language.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads expectation information from database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadLanguages()

            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False

                RaiseEvent LoadingLanguages(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                End If
            End Using

            LoadAllLanguages()

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent LanguagesLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateLanguageTable(ByVal validateRows() As MaintenanceDataSet.LanguageRow)
            Dim tempRow As MaintenanceDataSet.LanguageRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow Is Nothing Then Continue For

                If tempRow.IsDescripNull() = False Then
                    Dim datarowQuery As System.Collections.Generic.IEnumerable(Of MaintenanceDataSet.LanguageRow)

                    'If tempRow.RowState = DataRowState.Added Then
                    '  datarowQuery = From row In Data.Language _
                    '                 Select row _
                    '                 Where row.Descrip = tempRow.Descrip
                    'Else 'If tempRow.RowState = DataRowState.Modified Then
                    datarowQuery = From row In Data.Language _
                                   Select row _
                                   Where row.Descrip = tempRow.Descrip And row.LanguageID <> tempRow.LanguageID
                    'End If

                    If datarowQuery.Count > 0 Then
                        tempRow.RowError = "Language name must be unique."
                    End If

                    datarowQuery = Nothing
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates row values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateLanguageRows(ByVal validateRows() As MaintenanceDataSet.LanguageRow)
            Dim tempRow As MaintenanceDataSet.LanguageRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow Is Nothing Then Continue For

                If (tempRow.IsDescripNull() OrElse tempRow.Descrip.Trim().Length = 0) _
                  AndAlso tempRow.Table.Columns("Descrip").AllowDBNull = False _
                Then
                    tempRow.SetColumnError("Descrip", "Specify language name. Name cannot have blank value.")
                Else
                    tempRow.SetColumnError("Descrip", String.Empty)
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates language information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidateLanguageInformation(ByVal validateTable As MaintenanceDataSet.LanguageDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingLanguage(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim languageRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.LanguageRow)


            languageRows = From lr In validateTable _
                           Where lr.RowState <> DataRowState.Deleted AndAlso lr.RowState <> DataRowState.Unchanged _
                           Select lr

            'Row level validations are done here. e.g. value is not null, value should fall within certain range, etc.
            ValidateLanguageRows(languageRows.ToArray())

            'Table level validations here. e.g. name is unique in table, etc.
            ValidateLanguageTable(languageRows.ToArray())

            languageRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidLanguageInformationFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent LanguageValidated(Me, e)
                End Using
            End If

        End Sub

        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">Language table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertLanguage(ByVal newrowsTable As MaintenanceDataSet.LanguageDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingLanguage(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                LanguageAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new Language.", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent LanguageInserted(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in Language data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateLanguages(ByVal modifiedRows As MaintenanceDataSet.LanguageDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingLanguage(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                LanguageAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update Language(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent LanguageUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in Language data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteLanguages(ByVal deletedRows As MaintenanceDataSet.LanguageDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingLanguage(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                'LanguageAdapter.Update(deletedRows)
                LanguageAdapter.Update(Data.Language)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete Language(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent LanguageDeleted(Me, e)
            End Using

        End Sub


#End Region


#Region " Methods for Media table. "


        Public Event LoadingMediaTypes As MCAPCancellableEventHandler
        Public Event MediaTypesLoaded As MCAPEventHandler

        Public Event ValidatingMediaType As MCAPCancellableEventHandler
        Public Event InvalidMediaTypeFound As MCAPEventHandler
        Public Event MediaTypeValidated As MCAPEventHandler

        Public Event InsertingMediaType As MCAPCancellableEventHandler
        Public Event MediaTypeInserted As MCAPEventHandler

        Public Event UpdatingMediaType As MCAPCancellableEventHandler
        Public Event MediaTypeUpdated As MCAPEventHandler

        Public Event DeletingMediaType As MCAPCancellableEventHandler
        Public Event MediaTypeDeleted As MCAPEventHandler


        ''' <summary>
        ''' Loads all media from database, sorted by media name.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllMediaTypes()

            Data.Media.Clear()
            Data.Media.LoadingTable = True
            Data.Media.BeginLoadData()
            MediaAdapter.Fill(Data.Media)
            Data.Media.EndLoadData()
            Data.Media.LoadingTable = False

        End Sub

        Private Sub LoadAllMediaTypesforSenderExpecatation()

            Data.Media.Clear()
            Data.Media.LoadingTable = True
            Data.Media.BeginLoadData()
            'MediaAdapter.FillBySERemoved(Data.Media)
            Data.Media.EndLoadData()
            Data.Media.LoadingTable = False

        End Sub


        ''' <summary>
        ''' Loads media types from database, sorted by media name.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadMediaTypeList()

            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False

                RaiseEvent LoadingMediaTypes(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                End If
            End Using

            LoadAllMediaTypes()

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent MediaTypesLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateMediaTable(ByVal validateRows() As MaintenanceDataSet.MediaRow)
            Dim tempRow As MaintenanceDataSet.MediaRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow Is Nothing Then Continue For

                If tempRow.IsDescripNull() = False Then
                    Dim datarowQuery As System.Collections.Generic.IEnumerable(Of MaintenanceDataSet.MediaRow)

                    'If tempRow.RowState = DataRowState.Added Then
                    '  datarowQuery = From row In Data.Media _
                    '                 Select row _
                    '                 Where row.Descrip = tempRow.Descrip
                    'Else 'If tempRow.RowState = DataRowState.Modified Then
                    datarowQuery = From row In Data.Media _
                                   Select row _
                                   Where row.Descrip = tempRow.Descrip And row.MediaID <> row.MediaID
                    'End If

                    If datarowQuery.Count > 0 Then
                        tempRow.RowError = "Media name must be unique."
                    End If

                    datarowQuery = Nothing
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates row values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateMediaRows(ByVal validateRows() As MaintenanceDataSet.MediaRow)
            Dim tempRow As MaintenanceDataSet.MediaRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow Is Nothing Then Continue For

                If tempRow.IsDescripNull() OrElse tempRow.Descrip.Length = 0 Then
                    tempRow.SetColumnError("Descrip", "Specify media name. It cannot have blank value.")
                Else
                    tempRow.SetColumnError("Descrip", String.Empty)
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates media type information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidateMediaInformation(ByVal validateTable As MaintenanceDataSet.MediaDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingMediaType(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim mediaRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.MediaRow)
            mediaRows = From mr In validateTable _
                        Where mr.RowState <> DataRowState.Deleted AndAlso mr.RowState <> DataRowState.Unchanged _
                        Select mr

            'Row level validations are done here. e.g. value is not null, value should fall within certain range, etc.
            ValidateMediaRows(mediaRows.ToArray())

            'Table level validations here. e.g. name is unique in table, etc.
            ValidateMediaTable(mediaRows.ToArray())

            mediaRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidMediaTypeFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent MediaTypeValidated(Me, e)
                End Using
            End If

        End Sub

        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">Media table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertMedia(ByVal newrowsTable As MaintenanceDataSet.MediaDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingMediaType(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                MediaAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new Media.", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent MediaTypeInserted(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in Media data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateMedia(ByVal modifiedRows As MaintenanceDataSet.MediaDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingMediaType(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                MediaAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update Media(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent MediaTypeUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in Media data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteMedia(ByVal deletedRows As MaintenanceDataSet.MediaDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingMediaType(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                'MediaAdapter.Update(deletedRows)
                MediaAdapter.Update(Data.Media)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete Media(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent MediaTypeDeleted(Me, e)
            End Using

        End Sub


#End Region


#Region " Methods for Retailer table. "


        Public Event LoadingRetailers As MCAPCancellableEventHandler
        Public Event RetailersExceedsNonFilteredRowsLimit As MCAPEventHandler
        Public Event RetailersLoaded As MCAPEventHandler

        Public Event ValidatingRetailerInformation As MCAPCancellableEventHandler
        Public Event InvalidRetailerInformationFound As MCAPEventHandler
        Public Event RetailerInformationValidated As MCAPEventHandler

        Public Event InsertingRetailer As MCAPCancellableEventHandler
        Public Event RetailerInserted As MCAPEventHandler

        Public Event UpdatingRetailer As MCAPCancellableEventHandler
        Public Event RetailerUpdated As MCAPEventHandler

        Public Event DeletingRetailer As MCAPCancellableEventHandler
        Public Event RetailerDeleted As MCAPEventHandler



        ''' <summary>
        ''' Gets total number of rows in expectation table.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetRetailerTableRowCount() As Integer
            Dim rowCount As Nullable(Of Integer)


            rowCount = RetAdapter.GetRowCount()
            If rowCount.HasValue Then
                Return rowCount.Value
            Else
                Return 0
            End If

        End Function

        ''' <summary>
        ''' Loads all retailers from database, sorted by retailer name.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllRetailers()

            Data.Ret.Clear()
            Data.Ret.LoadingTable = True
            Data.Ret.BeginLoadData()
            RetAdapter.Fill(Data.Ret)
            Data.Ret.EndLoadData()
            Data.Ret.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads retailers from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredRetailers(ByVal filterCondition As String)

            Data.Ret.LoadingTable = True
            Data.Ret.BeginLoadData()
            RetAdapter.FillByWhereClause(Data.Ret, filterCondition)
            If Data.Ret.Count < 0 Then
                LoadAllRetailers()
            End If
            Data.Ret.EndLoadData()
            Data.Ret.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads retailers from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredSERetailers(ByVal _med As Integer, ByVal _mkt As Integer)

            If Data.Ret.Count > 0 Then Data.Ret.Clear()
            Data.Ret.LoadingTable = True
            Data.Ret.BeginLoadData()
            RetAdapter.FillBySenderExpectation(Data.Ret, _mkt, _med)
            Data.Ret.EndLoadData()
            Data.Ret.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads retailers from database, sorted by retailer name.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadRetailers(Optional ByVal filterCondition As String = Nothing)
            Dim rowFilter As String = Nothing


            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False
                e.Data.Add("Filter", filterCondition)

                RaiseEvent LoadingRetailers(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                ElseIf e.Data.Contains("Filter") AndAlso e.Data("Filter") IsNot Nothing Then
                    rowFilter = e.Data("Filter").ToString()
                End If
            End Using

            If Data.TradeClassList.Count = 0 Then LoadTradeClassList()
            If Data.Language.Count = 0 Then LoadLanguages()
            If Data.RetailerList.Count = 0 Then LoadRetailerList()

            If rowFilter Is Nothing AndAlso GetRetailerTableRowCount() > MaximumNonFilteredRowsAllowed Then
                Using e As Processors.EventArgs = New Processors.EventArgs()
                    Data.Ret.Clear()
                    RaiseEvent RetailersExceedsNonFilteredRowsLimit(Me, e)
                    Exit Sub
                End Using
            End If

            If rowFilter Is Nothing Then
                LoadAllRetailers()
            Else
                LoadFilteredRetailers(rowFilter)
            End If

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent RetailersLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateRetailerTable(ByVal validateRows() As MaintenanceDataSet.RetRow)
            Dim tempRow As MaintenanceDataSet.RetRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow Is Nothing Then Continue For

                If tempRow.IsDescripNull() = False Then
                    Dim datarowQuery As System.Collections.Generic.IEnumerable(Of MaintenanceDataSet.RetRow)

                    datarowQuery = From row In Data.Ret _
                                   Select row _
                                   Where row.Descrip = tempRow.Descrip And row.RetId <> row.RetId

                    If datarowQuery.Count > 0 Then
                        tempRow.RowError = "Retailer name must be unique."
                    Else
                        Dim rowCount As Integer

                        If tempRow.RowState = DataRowState.Modified Then
                            RetAdapter.IsRetailerExist(tempRow.Descrip, tempRow.RetId, rowCount)
                        Else
                            RetAdapter.IsRetailerExist(tempRow.Descrip, Nothing, rowCount)
                        End If

                        If rowCount > 0 Then tempRow.RowError = "Retaler name must be unique."
                    End If

                    datarowQuery = Nothing
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates rows values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateRetailerRows(ByVal validateRows() As MaintenanceDataSet.RetRow)
            Dim tempRow As MaintenanceDataSet.RetRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow Is Nothing Then Continue For

                If tempRow.IsDescripNull() AndAlso tempRow.Table.Columns("Descrip").AllowDBNull = False Then
                    tempRow.SetColumnError("Descrip", "Specify retailer name.")
                Else
                    tempRow.SetColumnError("Descrip", String.Empty)
                End If

                If tempRow.IsTradeClassIdNull() AndAlso tempRow.Table.Columns("TradeclassId").AllowDBNull = False Then
                    tempRow.SetColumnError("TradeclassId", "Specify tradeclass for retailer.")
                Else
                    tempRow.SetColumnError("TradeclassId", String.Empty)
                End If

                If tempRow.IsStartDtNull() AndAlso tempRow.Table.Columns("StartDt").AllowDBNull = False Then
                    tempRow.SetColumnError("StartDt", "Specify start date.")
                Else
                    tempRow.SetColumnError("StartDt", String.Empty)
                End If

                If tempRow.IsEndDtNull() AndAlso tempRow.Table.Columns("EndDt").AllowDBNull = False Then
                    tempRow.SetColumnError("EndDt", "Specify end date.")
                Else
                    tempRow.SetColumnError("EndDt", String.Empty)
                End If

                If tempRow.IsPriorityNull() AndAlso tempRow.Table.Columns("Priority").AllowDBNull = False Then
                    tempRow.SetColumnError("Priority", "Specify Priority.")
                Else
                    tempRow.SetColumnError("Priority", String.Empty)
                End If

                If tempRow.IsLanguageIdNull() AndAlso tempRow.Table.Columns("LanguageId").AllowDBNull = False Then
                    tempRow.SetColumnError("LanguageId", "Specify language.")
                Else
                    tempRow.SetColumnError("LanguageId", String.Empty)
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates Sender information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidateRetailerInformation(ByVal validateTable As MaintenanceDataSet.RetDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingRetailerInformation(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim retailerRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.RetRow)
            retailerRows = From r In validateTable _
                           Where r.RowState <> DataRowState.Deleted AndAlso r.RowState <> DataRowState.Unchanged _
                           Select r

            'Row level validations are done here. e.g. value is not null, value should fall within certain range, etc.
            ValidateRetailerRows(retailerRows.ToArray())

            'Table level validations here. e.g. name is unique in table, etc.
            ValidateRetailerTable(retailerRows.ToArray())

            retailerRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidRetailerInformationFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent RetailerInformationValidated(Me, e)
                End Using
            End If

        End Sub

        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">Ret table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertRet(ByVal newrowsTable As MaintenanceDataSet.RetDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingRetailer(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                RetAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new Retailer(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent RetailerInserted(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in Ret data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateRet(ByVal modifiedRows As MaintenanceDataSet.RetDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingRetailer(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                RetAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update Retailer(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent RetailerUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in Ret data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteRet(ByVal deletedRows As MaintenanceDataSet.RetDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingRetailer(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                'RetAdapter.Update(deletedRows)
                RetAdapter.Update(Data.Ret)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete Retailer(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent RetailerDeleted(Me, e)
            End Using

        End Sub


#End Region


#Region " Methods for Tradeclass table. "


        Public Event LoadingTradeclass As MCAPCancellableEventHandler
        Public Event TradeclassLoaded As MCAPEventHandler

        Public Event ValidatingTradeclass As MCAPCancellableEventHandler
        Public Event InvalidTradeclassInformationFound As MCAPEventHandler
        Public Event TradeclassValidated As MCAPEventHandler

        Public Event InsertingTradeclass As MCAPCancellableEventHandler
        Public Event TradeclassInserted As MCAPEventHandler

        Public Event UpdatingTradeclass As MCAPCancellableEventHandler
        Public Event TradeclassUpdated As MCAPEventHandler

        Public Event DeletingTradeclass As MCAPCancellableEventHandler
        Public Event TradeclassDeleted As MCAPEventHandler


        ''' <summary>
        ''' Returns total number of rows in tradeclass table.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTradeclassTableRowCount() As Integer
            Dim rowCount As Nullable(Of Integer)


            rowCount = TradeclassAdapter.GetRowCount()
            If rowCount.HasValue Then
                Return rowCount.Value
            Else
                Return 0
            End If

        End Function

        ''' <summary>
        ''' Loads all tradeclass from database, sorted by tradeclass name.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadAllTradeclasses()

            Data.TradeClass.LoadingTable = True
            Data.TradeClass.BeginLoadData()
            TradeclassAdapter.Fill(Data.TradeClass)
            Data.TradeClass.EndLoadData()
            Data.TradeClass.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads Tradeclasses from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredTradeclasses(ByVal filterCondition As String)

            Data.TradeClass.LoadingTable = True
            Data.TradeClass.BeginLoadData()
            TradeclassAdapter.FillByWhereClause(Data.TradeClass, filterCondition)
            Data.TradeClass.EndLoadData()
            Data.TradeClass.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads tradeclass from database, sorted by tradeclass name.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadTradeclasses(Optional ByVal filtercondtion As String = Nothing)

            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False

                RaiseEvent LoadingLanguages(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                End If
            End Using

            If filtercondtion = Nothing Then
                LoadAllTradeclasses()
            Else
                LoadFilteredTradeclasses(filtercondtion)
            End If

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent TradeclassLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateTradeclassTable(ByVal validateRows() As MaintenanceDataSet.TradeClassRow)
            Dim tempRow As MaintenanceDataSet.TradeClassRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If (tempRow.IsDescripNull() OrElse tempRow.Descrip.Trim().Length = 0) _
                  AndAlso tempRow.Table.Columns("Descrip").AllowDBNull = False _
                Then
                    tempRow.SetColumnError("Descrip", "Specify tradeclass name. It cannot have blank value.")
                Else
                    tempRow.SetColumnError("Descrip", String.Empty)
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates rows values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateTradeclassRows(ByVal validateRows() As MaintenanceDataSet.TradeClassRow)
            Dim tempRow As MaintenanceDataSet.TradeClassRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow Is Nothing Then Continue For

                If tempRow.IsDescripNull() = False Then
                    Dim datarowQuery As System.Collections.Generic.IEnumerable(Of MaintenanceDataSet.TradeClassRow)

                    'If tempRow.RowState = DataRowState.Added Then
                    '    datarowQuery = From row In Data.TradeClass _
                    '                   Select row _
                    '                   Where row.Descrip = tempRow.Descrip
                    'Else 'If tempRow.RowState = DataRowState.Modified Then
                    datarowQuery = From row In Data.TradeClass _
                                   Select row _
                                   Where row.Descrip = tempRow.Descrip And row.TradeClassId <> row.TradeClassId
                    'End If

                    If datarowQuery.Count > 0 Then
                        tempRow.RowError = "Tradeclass name must be unique."
                    End If

                    datarowQuery = Nothing
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates tradeclass information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidateTradeclassInformation(ByVal validateTable As MaintenanceDataSet.TradeClassDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingTradeclass(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim tradeclassRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.TradeClassRow)
            tradeclassRows = From tr In validateTable _
                             Where tr.RowState <> DataRowState.Deleted AndAlso tr.RowState <> DataRowState.Detached _
                             Select tr

            'Row level validations are done here. e.g. value is not null, value should fall within certain range, etc.
            ValidateTradeclassRows(tradeclassRows.ToArray())

            'Table level validations here. e.g. name is unique in table, etc.
            ValidateTradeclassTable(tradeclassRows.ToArray())

            tradeclassRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidTradeclassInformationFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent TradeclassValidated(Me, e)
                End Using
            End If

        End Sub

        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">Tradeclass table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertTradeclass(ByVal newrowsTable As MaintenanceDataSet.TradeClassDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingTradeclass(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                TradeclassAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new tradeclass.", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent TradeclassInserted(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in Tradeclass data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateTradeclass(ByVal modifiedRows As MaintenanceDataSet.TradeClassDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingTradeclass(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                TradeclassAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update tradeclass(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent TradeclassUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in Tradeclass data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteTradeclass(ByVal deletedRows As MaintenanceDataSet.TradeClassDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingTradeclass(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                'TradeclassAdapter.Update(deletedRows)
                TradeclassAdapter.Update(Data.TradeClass)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete tradeclass(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent TradeclassDeleted(Me, e)
            End Using

        End Sub


#End Region

#Region " Methods for Market table. "



        Public Event LoadingMarkets As MCAPCancellableEventHandler
        Public Event MarketsExceedsNonFilteredRowsLimit As MCAPEventHandler
        Public Event MarketsLoaded As MCAPEventHandler

        Public Event ValidatingMarketInformation As MCAPCancellableEventHandler
        Public Event InvalidMarketInformationFound As MCAPEventHandler
        Public Event MarketInformationValidated As MCAPEventHandler

        Public Event InsertingMarket As MCAPCancellableEventHandler
        Public Event MarketInserted As MCAPEventHandler

        Public Event UpdatingMarket As MCAPCancellableEventHandler
        Public Event MarketUpdated As MCAPEventHandler

        Public Event DeletingMarket As MCAPCancellableEventHandler
        Public Event MarketDeleted As MCAPEventHandler



        ''' <summary>
        ''' Returns total number of rows in Mkt table.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetMktTableRowCount() As Integer
            Dim rowCount As Object


            rowCount = MktAdapter.GetRowCount()
            If rowCount IsNot Nothing Then
                Return CType(rowCount, Integer)
            Else
                Return 0
            End If

        End Function


        ''' <summary>
        ''' Loads all Markets from database, sorted by name.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadAllMarkets()

            Data.Mkt.Clear()
            Data.Mkt.LoadingTable = True
            Data.Mkt.BeginLoadData()
            MktAdapter.Fill(Data.Mkt)
            Data.Mkt.EndLoadData()
            Data.Mkt.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads all Shipping Type from database, sorted by name.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadAllShippingType()

            Data.ShippingTypeCode.Clear()
            Data.ShippingTypeCode.BeginLoadData()
            ShippingTypecodeAdapter.Fill(Data.ShippingTypeCode)
            Data.ShippingTypeCode.EndLoadData()

        End Sub

        ''' <summary>
        ''' Loads YesNo Indicator from database, sorted by name.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadYesNoIndicator()

            Data.YesNoIndicator.Clear()
            Data.YesNoIndicator.BeginLoadData()
            YesNoIndicatorAdapter.Fill(Data.YesNoIndicator)
            Data.YesNoIndicator.EndLoadData()

        End Sub

        Public Sub LoadSourceId()

            Data.Source.Clear()
            Data.Source.BeginLoadData()
            SourceIdAdapter.Fill(Data.Source)
            Data.Source.EndLoadData()

        End Sub

        'Public Sub LoadSubscriptionYesNoIndicator()

        '    SubscriptionData.YesNoCode.Clear()
        '    SubscriptionData.YesNoCode.BeginLoadData()
        '    SubscriptionYesNoIndicatorAdapter.Fill(SubscriptionData.YesNoCode)
        '    SubscriptionData.YesNoCode.EndLoadData()

        'End Sub

        'Public Sub LoadSubscriptionPrepaidPeriod()
        '    SubscriptionData.PrepaidPeriodCode.Clear()
        '    SubscriptionData.PrepaidPeriodCode.BeginLoadData()
        '    SubscriptionPrepaidPeriodAdapter.Fill(SubscriptionData.PrepaidPeriodCode)
        '    SubscriptionData.PrepaidPeriodCode.EndLoadData()

        'End Sub

        'Public Sub LoadSubscriptionReceipientType()

        '    SubscriptionData.ReceipientTypeCode.Clear()
        '    SubscriptionData.ReceipientTypeCode.BeginLoadData()
        '    SubscriptionReceipientAdapter.Fill(SubscriptionData.ReceipientTypeCode)
        '    SubscriptionData.ReceipientTypeCode.EndLoadData()

        'End Sub


        'Public Sub LoadSubscriptionPaidby()

        '    SubscriptionData.PaidByCode.Clear()
        '    SubscriptionData.PaidByCode.BeginLoadData()
        '    SubscriptionPaidByAdapter.Fill(SubscriptionData.PaidByCode)
        '    SubscriptionData.PaidByCode.EndLoadData()

        'End Sub

        'Public Sub LoadSubscriptionId()

        '    SubscriptionData.SubscriptionId.Clear()
        '    SubscriptionData.SubscriptionId.BeginLoadData()
        '    SubscriptionIdAdapter.Fill(SubscriptionData.SubscriptionId)
        '    SubscriptionData.SubscriptionId.EndLoadData()

        'End Sub

        '''' <summary>
        '''' Loads Market in SubscriptionDataset from database, sorted by name.
        '''' </summary>
        '''' <remarks></remarks>
        'Public Sub LoadSubscriptionMarket()

        '    SubscriptionData.Mkt.Clear()
        '    SubscriptionData.Mkt.BeginLoadData()
        '    MktSubscriptionAdapter.Fill(SubscriptionData.Mkt)
        '    SubscriptionData.Mkt.EndLoadData()

        'End Sub

        ''' <summary>
        ''' Loads all Sub Payment from database, sorted by name.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadAllSubPayment()

            Data.SubPayment.Clear()
            Data.SubPayment.BeginLoadData()
            SubPaymentAdapter.Fill(Data.SubPayment)
            Data.SubPayment.EndLoadData()

        End Sub

        ''' <summary>
        ''' Loads Markets from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredMarkets(ByVal filterCondition As String)

            Data.Mkt.LoadingTable = True
            Data.Mkt.BeginLoadData()
            MktAdapter.FillByWhereClause(Data.Mkt, filterCondition)
            If Data.Mkt.Count < 0 Then
                LoadAllMarkets()
            End If
            Data.Mkt.EndLoadData()
            Data.Mkt.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads Markets from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredSEMarkets(ByVal _med As Integer)

            If Data.Mkt.Count > 0 Then Data.Mkt.Clear()
            Data.Mkt.LoadingTable = True
            Data.Mkt.BeginLoadData()
            MktAdapter.FillBySenderExpectation(Data.Mkt, _med)
            Data.Mkt.EndLoadData()
            Data.Mkt.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads Markets from database, sorted by name.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadMarkets(Optional ByVal filterCondition As String = Nothing)
            Dim rowFilter As String = Nothing


            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False
                e.Data.Add("Filter", filterCondition)

                RaiseEvent LoadingMarkets(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                ElseIf e.Data.Contains("Filter") AndAlso e.Data("Filter") IsNot Nothing Then
                    rowFilter = e.Data("Filter").ToString()
                End If
            End Using

            If Data.MarketList.Count = 0 Then LoadMarketList()

            If rowFilter Is Nothing AndAlso GetMktTableRowCount() > MaximumNonFilteredRowsAllowed Then
                Using e As Processors.EventArgs = New Processors.EventArgs()
                    Data.Mkt.Clear()
                    RaiseEvent MarketsExceedsNonFilteredRowsLimit(Me, e)
                    Exit Sub
                End Using
            End If

            If rowFilter Is Nothing Then
                LoadAllMarkets()
            Else
                LoadFilteredMarkets(rowFilter)
            End If

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent MarketsLoaded(Me, e)
            End Using

        End Sub


        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateMktTable(ByVal validateRows() As MaintenanceDataSet.MktRow)
            Dim tempRow As MaintenanceDataSet.MktRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow Is Nothing Then Continue For

                If tempRow.IsDescripNull() = False Then
                    Dim datarowQuery As System.Collections.Generic.IEnumerable(Of MaintenanceDataSet.MktRow)

                    datarowQuery = From row In Data.Mkt _
                                   Where (row.Descrip = tempRow.Descrip And row.MktId <> row.MktId) _
                                   Select row

                    If datarowQuery.Count > 0 Then
                        tempRow.RowError = "Market name must be unique."
                    Else
                        Dim rowCount As Object

                        rowCount = MktAdapter.IsMarketExist(tempRow.MktId, tempRow.Descrip)

                        If rowCount.ToString() <> "0" Then tempRow.RowError = "Market name must be unique."
                    End If

                    datarowQuery = Nothing
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates rows values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateMktRows(ByVal validateRows() As MaintenanceDataSet.MktRow)
            Dim tempRow As MaintenanceDataSet.MktRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow Is Nothing Then Continue For

                If tempRow.IsDescripNull() AndAlso tempRow.Table.Columns("Descrip").AllowDBNull = False Then
                    tempRow.SetColumnError("Descrip", "Specify Mkt name.")
                Else
                    tempRow.SetColumnError("Descrip", String.Empty)
                End If

                If tempRow.IsStartDtNull() AndAlso tempRow.Table.Columns("StartDt").AllowDBNull = False Then
                    tempRow.SetColumnError("StartDt", "Specify start date.")
                Else
                    tempRow.SetColumnError("StartDt", String.Empty)
                End If

                If tempRow.IsEndDtNull() AndAlso tempRow.Table.Columns("EndDt").AllowDBNull = False Then
                    tempRow.SetColumnError("EndDt", "Specify end date.")
                Else
                    tempRow.SetColumnError("EndDt", String.Empty)
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates Mkt information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidateMarketInformation(ByVal validateTable As MaintenanceDataSet.MktDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingMarketInformation(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim marketRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.MktRow)
            marketRows = From mr In validateTable _
                         Where mr.RowState <> DataRowState.Deleted AndAlso mr.RowState <> DataRowState.Unchanged _
                         Select mr

            'Row level validations are done here. e.g. value is not null, value should fall within certain range, etc.
            ValidateMktRows(marketRows.ToArray())

            'Table level validations here. e.g. name is unique in table, etc.
            ValidateMktTable(marketRows.ToArray())

            marketRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidMarketInformationFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent MarketInformationValidated(Me, e)
                End Using
            End If

        End Sub


        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">Mkt table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertMkt(ByVal newrowsTable As MaintenanceDataSet.MktDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingMarket(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                MktAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new Mkt(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent MarketInserted(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in Mkt data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateMkt(ByVal modifiedRows As MaintenanceDataSet.MktDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingMarket(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                MktAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update Mkt(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent MarketUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in Mkt data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteMkt(ByVal deletedRows As MaintenanceDataSet.MktDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingMarket(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                'MktAdapter.Update(deletedRows)
                MktAdapter.Update(Data.Mkt)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete markets(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent MarketDeleted(Me, e)
            End Using

        End Sub


#End Region

#Region " Methods for Publication table. "


        Public Event LoadingPublications As MCAPCancellableEventHandler
        Public Event PublicationsExceedsNonFilteredRowsLimit As MCAPEventHandler
        Public Event PublicationsLoaded As MCAPEventHandler

        Public Event ValidatingPublicationInformation As MCAPCancellableEventHandler
        Public Event InvalidPublicationInformationFound As MCAPEventHandler
        Public Event PublicationInformationValidated As MCAPEventHandler

        Public Event InsertingPublication As MCAPCancellableEventHandler
        Public Event PublicationInserted As MCAPEventHandler

        Public Event UpdatingPublication As MCAPCancellableEventHandler
        Public Event PublicationUpdated As MCAPEventHandler

        Public Event DeletingPublication As MCAPCancellableEventHandler
        Public Event PublicationDeleted As MCAPEventHandler



        ''' <summary>
        ''' Returns total number of rows in Publication table.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPublicationTableRowCount() As Integer
            Dim rowCount As Object


            rowCount = PublicationAdapter.GetRowCount()
            If rowCount IsNot Nothing Then
                Return CType(rowCount, Integer)
            Else
                Return 0
            End If

        End Function


        ''' <summary>
        ''' Loads all publication from database, sorted by name.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadAllPublications()

            Data.Publication.LoadingTable = True
            Data.Publication.BeginLoadData()
            PublicationAdapter.Fill(Data.Publication)
            Data.Publication.EndLoadData()
            Data.Publication.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads publications from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredPublications(ByVal filterCondition As String)

            Data.Publication.LoadingTable = True
            Data.Publication.BeginLoadData()
            PublicationAdapter.FillByWhereClause(Data.Publication, filterCondition)
            Data.Publication.EndLoadData()
            Data.Publication.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads publications from database, sorted by name.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadPublications(Optional ByVal filterCondition As String = Nothing)
            Dim rowFilter As String = Nothing


            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False
                e.Data.Add("Filter", filterCondition)

                RaiseEvent LoadingPublications(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                ElseIf e.Data.Contains("Filter") AndAlso e.Data("Filter") IsNot Nothing Then
                    rowFilter = e.Data("Filter").ToString()
                End If
            End Using

            If Data.MarketList.Count = 0 Then LoadMarketList()
            If Data.Size.Count = 0 Then LoadAllSizes()
            If Data.pepPubliation.Count = 0 Then LoadPepPublicationList()
            If Data.pepMarket.Count = 0 Then LoadPepMarketList()
            If Data.SenderList.Count = 0 Then LoadAllSenderList()
            'Dim tempRow As MaintenanceDataSet.SizeRow = Data.Size.NewSizeRow()
            'tempRow.BeginEdit()
            'tempRow.SetHeightNull()
            'tempRow.SetWidthNull()
            'tempRow.SetSizeTextNull()
            'tempRow.EndEdit()

            If rowFilter Is Nothing AndAlso GetPublicationTableRowCount() > MaximumNonFilteredRowsAllowed Then
                Using e As Processors.EventArgs = New Processors.EventArgs()
                    Data.Publication.Clear()
                    RaiseEvent PublicationsExceedsNonFilteredRowsLimit(Me, e)
                    Exit Sub
                End Using
            End If

            If rowFilter Is Nothing Then
                LoadAllPublications()
            Else
                LoadFilteredPublications(rowFilter)
            End If

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent PublicationsLoaded(Me, e)
            End Using

        End Sub


        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidatePublicationTable(ByVal validateRows() As MaintenanceDataSet.PublicationRow)
            Dim tempRow As MaintenanceDataSet.PublicationRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow Is Nothing Then Continue For

                If tempRow.IsDescripNull() = False Then
                    Dim datarowQuery As System.Collections.Generic.IEnumerable(Of MaintenanceDataSet.PublicationRow)

                    datarowQuery = From row In Data.Publication _
                                   Where (row.Descrip = tempRow.Descrip AndAlso row.MktId = tempRow.MktId AndAlso row.PublicationId <> tempRow.PublicationId) _
                                   Select row

                    If datarowQuery.Count > 0 Then
                        tempRow.RowError = "Publication name must be unique."
                    Else
                        Dim mktId As Integer?
                        Dim rowCount As Object


                        If tempRow.IsMktIdNull() Then
                            mktId = Nothing
                        Else
                            mktId = tempRow.MktId
                        End If

                        rowCount = PublicationAdapter.IsPublicationExist(tempRow.PublicationId, tempRow.Descrip, mktId)

                        If rowCount.ToString() <> "0" Then tempRow.RowError = "Publication already exist for market."
                    End If

                    datarowQuery = Nothing
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates rows values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidatePublicationRows(ByVal validateRows() As MaintenanceDataSet.PublicationRow)
            Dim tempRow As MaintenanceDataSet.PublicationRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow Is Nothing Then Continue For

                If tempRow.IsDescripNull() AndAlso tempRow.Table.Columns("Descrip").AllowDBNull = False Then
                    tempRow.SetColumnError("Descrip", "Specify Publication name.")
                Else
                    tempRow.SetColumnError("Descrip", String.Empty)
                End If

                If tempRow.IsMktIdNull() AndAlso tempRow.Table.Columns("MktId").AllowDBNull = False Then
                    tempRow.SetColumnError("MktId", "Specify market for publication.")
                Else
                    tempRow.SetColumnError("MktId", String.Empty)
                End If

                If tempRow.IsStartDtNull() AndAlso tempRow.Table.Columns("StartDt").AllowDBNull = False Then
                    tempRow.SetColumnError("StartDt", "Specify start date.")
                Else
                    tempRow.SetColumnError("StartDt", String.Empty)
                End If

                If tempRow.IsEndDtNull() AndAlso tempRow.Table.Columns("EndDt").AllowDBNull = False Then
                    tempRow.SetColumnError("EndDt", "Specify end date.")
                Else
                    tempRow.SetColumnError("EndDt", String.Empty)
                End If

                If tempRow.IsPriorityNull() AndAlso tempRow.Table.Columns("Priority").AllowDBNull = False Then
                    tempRow.SetColumnError("Priority", "Specify Priority.")
                Else
                    tempRow.SetColumnError("Priority", String.Empty)
                End If

                If tempRow.IsPublishedOnNull() AndAlso tempRow.Table.Columns("PublishedOn").AllowDBNull = False Then
                    tempRow.SetColumnError("PublishedOn", "Specify published on.")
                Else
                    tempRow.SetColumnError("PublishedOn", String.Empty)
                End If

                If tempRow.IsCommentsNull() AndAlso tempRow.Table.Columns("Comments").AllowDBNull = False Then
                    tempRow.SetColumnError("Comments", "Specify comments.")
                Else
                    tempRow.SetColumnError("Comments", String.Empty)
                End If

                'If tempRow.IsROPSizeIdNull() AndAlso tempRow.Table.Columns("ROPSizeId").AllowDBNull = False Then
                '  tempRow.SetColumnError("ROPSizeId", "Specify size for ROP.")
                'Else
                '  tempRow.SetColumnError("ROPSizeId", String.Empty)
                'End If

                'If tempRow.IsMagSizeIdNull() AndAlso tempRow.Table.Columns("MagSizeId").AllowDBNull = False Then
                '  tempRow.SetColumnError("MagSizeId", "Specify size for magazine.")
                'Else
                '  tempRow.SetColumnError("MagSizeId", String.Empty)
                'End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates Publication information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidatePublicationInformation(ByVal validateTable As MaintenanceDataSet.PublicationDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingPublicationInformation(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim publicationRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.PublicationRow)
            publicationRows = From pr In validateTable _
                              Where pr.RowState <> DataRowState.Deleted AndAlso pr.RowState <> DataRowState.Unchanged _
                              Select pr

            'Row level validations are done here. e.g. value is not null, value should fall within certain range, etc.
            ValidatePublicationRows(publicationRows.ToArray())

            'Table level validations here. e.g. name is unique in table, etc.
            ValidatePublicationTable(publicationRows.ToArray())

            publicationRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidPublicationInformationFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent PublicationInformationValidated(Me, e)
                End Using
            End If

        End Sub


        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">Publication table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertPublication(ByVal newrowsTable As MaintenanceDataSet.PublicationDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingPublication(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                PublicationAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new Publication(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent PublicationInserted(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in Publication data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdatePublication(ByVal modifiedRows As MaintenanceDataSet.PublicationDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingPublication(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try

                PublicationAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update Publication(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent PublicationUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in Publication data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeletePublication(ByVal deletedRows As MaintenanceDataSet.PublicationDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingPublication(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                'PublicationAdapter.Update(deletedRows)
                PublicationAdapter.Update(Data.Publication)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete Publication(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent PublicationDeleted(Me, e)
            End Using

        End Sub


#End Region

#Region " Methods for PublicationSubscription table. "


        Public Event LoadingPublicationSubscription As MCAPCancellableEventHandler
        Public Event PublicationSubscriptionExceedsNonFilteredRowsLimit As MCAPEventHandler
        Public Event PublicationSubscriptionLoaded As MCAPEventHandler

        Public Event ValidatingPublicationSubscriptionInformation As MCAPCancellableEventHandler
        Public Event InvalidPublicationSubscriptionInformationFound As MCAPEventHandler
        Public Event PublicationSubscriptionInformationValidated As MCAPEventHandler

        Public Event InsertingPublicationSubscription As MCAPCancellableEventHandler
        Public Event PublicationSubscriptionInserted As MCAPEventHandler

        Public Event UpdatingPublicationSubscription As MCAPCancellableEventHandler
        Public Event PublicationSubscriptionUpdated As MCAPEventHandler

        Public Event DeletingPublicationSubscription As MCAPCancellableEventHandler
        Public Event PublicationSubscriptionDeleted As MCAPEventHandler



        ''' <summary>
        ''' Returns total number of rows in Publication table.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPublicationSubscriptionTableRowCount() As Integer
            Dim rowCount As Object


            rowCount = PublicationSubscriptionAdapter.GetRowCount()
            If rowCount IsNot Nothing Then
                Return CType(rowCount, Integer)
            Else
                Return 0
            End If

        End Function


        Public Sub LoadSubscriptionYesNoIndicator()

            SubscriptionData.YesNoCode.Clear()
            SubscriptionData.YesNoCode.BeginLoadData()
            SubscriptionYesNoIndicatorAdapter.Fill(SubscriptionData.YesNoCode)
            SubscriptionData.YesNoCode.EndLoadData()

        End Sub

        Public Sub LoadSubscriptionPrepaidPeriod()
            SubscriptionData.PrepaidPeriodCode.Clear()
            SubscriptionData.PrepaidPeriodCode.BeginLoadData()
            SubscriptionPrepaidPeriodAdapter.Fill(SubscriptionData.PrepaidPeriodCode)
            SubscriptionData.PrepaidPeriodCode.EndLoadData()

        End Sub

        Public Sub LoadSubscriptionReceipientType()

            SubscriptionData.ReceipientTypeCode.Clear()
            SubscriptionData.ReceipientTypeCode.BeginLoadData()
            SubscriptionReceipientAdapter.Fill(SubscriptionData.ReceipientTypeCode)
            SubscriptionData.ReceipientTypeCode.EndLoadData()

        End Sub


        Public Sub LoadSubscriptionPaidby()

            SubscriptionData.PaidByCode.Clear()
            SubscriptionData.PaidByCode.BeginLoadData()
            SubscriptionPaidByAdapter.Fill(SubscriptionData.PaidByCode)
            SubscriptionData.PaidByCode.EndLoadData()

        End Sub

        Public Sub LoadSubscriptionId()

            SubscriptionData.SubscriptionId.Clear()
            SubscriptionData.SubscriptionId.BeginLoadData()
            SubscriptionIdAdapter.Fill(SubscriptionData.SubscriptionId)
            SubscriptionData.SubscriptionId.EndLoadData()

        End Sub

        Public Sub LoadSubscriptionMarket()

            SubscriptionData.Mkt.Clear()
            SubscriptionData.Mkt.BeginLoadData()
            MktSubscriptionAdapter.Fill(SubscriptionData.Mkt)
            SubscriptionData.Mkt.EndLoadData()

        End Sub

        Public Sub LoadSubscriptionPublications()


            SubscriptionData.Publication.BeginLoadData()
            SubscriptionPublicationAdapter.Fill(SubscriptionData.Publication)
            SubscriptionData.Publication.EndLoadData()


        End Sub


        ''' <summary>
        ''' Loads all publication Subscription from database.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllPublicationSubscription()

            SubscriptionData.PublicationSubscription.LoadingTable = True
            SubscriptionData.PublicationSubscription.BeginLoadData()
            PublicationSubscriptionAdapter.Fill(SubscriptionData.PublicationSubscription)
            SubscriptionData.PublicationSubscription.EndLoadData()
            SubscriptionData.PublicationSubscription.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads publications from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredPublicationSubscription(ByVal filterCondition As String)

            SubscriptionData.PublicationSubscription.LoadingTable = True
            SubscriptionData.PublicationSubscription.BeginLoadData()
            PublicationSubscriptionAdapter.FillByWhereClause(SubscriptionData.PublicationSubscription, filterCondition)
            SubscriptionData.PublicationSubscription.EndLoadData()
            SubscriptionData.PublicationSubscription.LoadingTable = False

        End Sub

        Public Function LoadFilteredMktSubscription(ByVal PublicationId As Integer, ByVal isID As Boolean) As String
            Dim _val As String

            SubscriptionData.Mkt.BeginLoadData()
            FilteredMktSubscriptionAdapter.FillByPublicationId(SubscriptionData.Mkt, PublicationId)
            SubscriptionData.Mkt.EndLoadData()

            If isID = False Then
                If SubscriptionData.Mkt.Rows.Count > 0 Then
                    _val = CType(SubscriptionData.Mkt.Rows(0).Item(1), String)
                Else
                    _val = "No Record"
                End If
            Else
                If SubscriptionData.Mkt.Rows.Count > 0 Then
                    _val = CType(SubscriptionData.Mkt.Rows(0).Item(0), String)
                Else
                    _val = "0"
                End If
            End If

            Return _val
        End Function

        Public Function isDuplicateSubscription(ByVal PublicationId As Integer, ByVal AccountNo As Integer) As Boolean
            Dim _val As Boolean
            Dim ctr As Integer

            If AccountNo > 0 Then
                ctr = CType(PublicationSubscriptionAdapter.CheckDuplicateSubscription(PublicationId, AccountNo), Integer)
            Else
                ctr = CType(PublicationSubscriptionAdapter.SubscriptionDuplicateByPubId(PublicationId), Integer)
            End If


            If ctr > 0 Then
                _val = True
            Else
                _val = False
            End If


            Return _val
        End Function
        ''' <summary>
        ''' Loads publications from database, sorted by name.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadPublicationSubscription(Optional ByVal filterCondition As String = Nothing)
            Dim rowFilter As String = Nothing


            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False
                e.Data.Add("Filter", filterCondition)

                RaiseEvent LoadingPublicationSubscription(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                ElseIf e.Data.Contains("Filter") AndAlso e.Data("Filter") IsNot Nothing Then
                    rowFilter = e.Data("Filter").ToString()
                End If
            End Using

            'If Data.MarketList.Count = 0 Then LoadMarketList()
            'If Data.Size.Count = 0 Then LoadAllSizes()
            'Dim tempRow As MaintenanceDataSet.SizeRow = Data.Size.NewSizeRow()
            'tempRow.BeginEdit()
            'tempRow.SetHeightNull()
            'tempRow.SetWidthNull()
            'tempRow.SetSizeTextNull()
            'tempRow.EndEdit()

            If rowFilter Is Nothing AndAlso GetPublicationSubscriptionTableRowCount() > MaximumNonFilteredRowsAllowed Then
                Using e As Processors.EventArgs = New Processors.EventArgs()
                    SubscriptionData.PublicationSubscription.Clear()
                    RaiseEvent PublicationSubscriptionExceedsNonFilteredRowsLimit(Me, e)
                    Exit Sub
                End Using
            End If

            If rowFilter Is Nothing Then
                LoadAllPublicationSubscription()
            Else
                LoadFilteredPublicationSubscription(rowFilter)
            End If

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent PublicationSubscriptionLoaded(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidatePublicationSubscriptionTable(ByVal validateRows() As MaintenanceDataSet.PublicationRow)
            Dim tempRow As MaintenanceDataSet.PublicationRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow Is Nothing Then Continue For

                If tempRow.IsDescripNull() = False Then
                    Dim datarowQuery As System.Collections.Generic.IEnumerable(Of MaintenanceDataSet.PublicationRow)

                    datarowQuery = From row In Data.Publication _
                                   Where (row.Descrip = tempRow.Descrip AndAlso row.PublicationId <> tempRow.PublicationId) _
                                   Select row

                    If datarowQuery.Count > 0 Then
                        tempRow.RowError = "Publication name must be unique."
                    Else
                        Dim mktId As Integer?
                        Dim rowCount As Object


                        If tempRow.IsMktIdNull() Then
                            mktId = Nothing
                        Else
                            mktId = tempRow.MktId
                        End If

                        rowCount = PublicationAdapter.IsPublicationExist(tempRow.PublicationId, tempRow.Descrip, mktId)

                        If rowCount.ToString() <> "0" Then tempRow.RowError = "Publication already exist for market."
                    End If

                    datarowQuery = Nothing
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates rows values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidatePublicationSubscriptionRows(ByVal validateRows() As MaintenanceDataSet.PublicationRow)
            Dim tempRow As MaintenanceDataSet.PublicationRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow Is Nothing Then Continue For

                If tempRow.IsDescripNull() AndAlso tempRow.Table.Columns("Descrip").AllowDBNull = False Then
                    tempRow.SetColumnError("Descrip", "Specify Publication name.")
                Else
                    tempRow.SetColumnError("Descrip", String.Empty)
                End If

                If tempRow.IsMktIdNull() AndAlso tempRow.Table.Columns("MktId").AllowDBNull = False Then
                    tempRow.SetColumnError("MktId", "Specify market for publication.")
                Else
                    tempRow.SetColumnError("MktId", String.Empty)
                End If

                If tempRow.IsStartDtNull() AndAlso tempRow.Table.Columns("StartDt").AllowDBNull = False Then
                    tempRow.SetColumnError("StartDt", "Specify start date.")
                Else
                    tempRow.SetColumnError("StartDt", String.Empty)
                End If

                If tempRow.IsEndDtNull() AndAlso tempRow.Table.Columns("EndDt").AllowDBNull = False Then
                    tempRow.SetColumnError("EndDt", "Specify end date.")
                Else
                    tempRow.SetColumnError("EndDt", String.Empty)
                End If

                If tempRow.IsPriorityNull() AndAlso tempRow.Table.Columns("Priority").AllowDBNull = False Then
                    tempRow.SetColumnError("Priority", "Specify Priority.")
                Else
                    tempRow.SetColumnError("Priority", String.Empty)
                End If

                If tempRow.IsPublishedOnNull() AndAlso tempRow.Table.Columns("PublishedOn").AllowDBNull = False Then
                    tempRow.SetColumnError("PublishedOn", "Specify published on.")
                Else
                    tempRow.SetColumnError("PublishedOn", String.Empty)
                End If

                If tempRow.IsCommentsNull() AndAlso tempRow.Table.Columns("Comments").AllowDBNull = False Then
                    tempRow.SetColumnError("Comments", "Specify comments.")
                Else
                    tempRow.SetColumnError("Comments", String.Empty)
                End If

                'If tempRow.IsROPSizeIdNull() AndAlso tempRow.Table.Columns("ROPSizeId").AllowDBNull = False Then
                '  tempRow.SetColumnError("ROPSizeId", "Specify size for ROP.")
                'Else
                '  tempRow.SetColumnError("ROPSizeId", String.Empty)
                'End If

                'If tempRow.IsMagSizeIdNull() AndAlso tempRow.Table.Columns("MagSizeId").AllowDBNull = False Then
                '  tempRow.SetColumnError("MagSizeId", "Specify size for magazine.")
                'Else
                '  tempRow.SetColumnError("MagSizeId", String.Empty)
                'End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates Publication information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidatePublicationSubscriptionInformation(ByVal validateTable As MaintenanceDataSet.PublicationDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingPublicationInformation(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim publicationRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.PublicationRow)
            publicationRows = From pr In validateTable _
                              Where pr.RowState <> DataRowState.Deleted AndAlso pr.RowState <> DataRowState.Unchanged _
                              Select pr

            'Row level validations are done here. e.g. value is not null, value should fall within certain range, etc.
            ValidatePublicationRows(publicationRows.ToArray())

            'Table level validations here. e.g. name is unique in table, etc.
            ValidatePublicationTable(publicationRows.ToArray())

            publicationRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidPublicationInformationFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent PublicationInformationValidated(Me, e)
                End Using
            End If

        End Sub


        Public Sub InsertPublicationSubscription(ByVal newrowsTable As SubscriptionDataSet.PublicationSubscriptionDataTable)

            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingPublicationSubscription(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                PublicationSubscriptionAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new Subscription.", ex)
            End Try

            Using e As Processors.EventArgs = New Processors.EventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent PublicationSubscriptionInserted(Me, e)
                Exit Sub
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in Publication data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdatePublicationSubscription(ByVal modifiedRows As SubscriptionDataSet.PublicationSubscriptionDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingPublicationSubscription(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                PublicationSubscriptionAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update Publication Subscription(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent PublicationSubscriptionUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in Publication data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeletePublicationSubscription(ByVal deletedRows As SubscriptionDataSet.PublicationSubscriptionDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingPublicationSubscription(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                'PublicationAdapter.Update(deletedRows)
                PublicationSubscriptionAdapter.Update(SubscriptionData.PublicationSubscription)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete Publication(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent PublicationSubscriptionDeleted(Me, e)
            End Using

        End Sub


#End Region

#Region " Methods for RetPublicationCoverage table. "


        Public Event LoadingRetPublicationCoverage As MCAPCancellableEventHandler
        Public Event RetPublicationCoverageExceedsNonFilteredRowsLimit As MCAPEventHandler
        Public Event RetPublicationCoverageLoaded As MCAPEventHandler

        Public Event ValidatingRetPublicationCoverage As MCAPCancellableEventHandler
        Public Event InvalidRetPublicationCoverageFound As MCAPEventHandler
        Public Event RetPublicationCoverageValidated As MCAPEventHandler

        Public Event InsertingRetPublicationCoverage As MCAPCancellableEventHandler
        Public Event RetPublicationCoverageInserted As MCAPEventHandler

        Public Event UpdatingRetPublicationCoverage As MCAPCancellableEventHandler
        Public Event RetPublicationCoverageUpdated As MCAPEventHandler

        Public Event DeletingRetPublicationCoverage As MCAPCancellableEventHandler
        Public Event RetPublicationCoverageDeleted As MCAPEventHandler



        ''' <summary>
        ''' Gets total number of rows in expectation table.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetRetPublicationCoverageTableRowCount() As Integer
            Dim rowCount As Nullable(Of Integer)


            rowCount = RetPublicationCoverageAdapter.GetRowCount()
            If rowCount.HasValue Then
                Return rowCount.Value
            Else
                Return 0
            End If

        End Function

        ''' <summary>
        ''' Loads all retailer publication coverage from database.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllRetPublicationCoverage()

            Data.RetPublicationCoverage.LoadingTable = True
            Data.RetPublicationCoverage.BeginLoadData()
            RetPublicationCoverageAdapter.Fill(Data.RetPublicationCoverage)
            Data.RetPublicationCoverage.EndLoadData()
            Data.RetPublicationCoverage.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads retailer publication coverages from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredRetPublicationCoverage(ByVal filterCondition As String)
            Dim ColumnPrefix As String = "RPC."
            If filterCondition.Contains("MKTID") Then
                filterCondition = filterCondition.Replace("MKTID", "P.MKTID")
                ''ColumnPrefix = "P."
            End If

            filterCondition = (ColumnPrefix + filterCondition).Replace("RPC.P.", "P.")

            Data.RetPublicationCoverage.LoadingTable = True
            Data.RetPublicationCoverage.BeginLoadData()
            RetPublicationCoverageAdapter.FillByWhereClause(Data.RetPublicationCoverage, filterCondition)
            Data.RetPublicationCoverage.EndLoadData()
            Data.RetPublicationCoverage.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads retailer publication coverage from database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadRetPublicationCoverage(Optional ByVal filterCondition As String = Nothing)
            Dim rowFilter As String = Nothing


            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False
                e.Data.Add("Filter", filterCondition)

                RaiseEvent LoadingRetPublicationCoverage(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                ElseIf e.Data.Contains("Filter") AndAlso e.Data("Filter") IsNot Nothing Then
                    rowFilter = e.Data("Filter").ToString()
                End If
            End Using

            If Data.RetailerList.Count = 0 Then LoadRetailerList()
            If Data.PublicationList.Count = 0 Then LoadPublicationList()
            If Data.MarketList.Count = 0 Then LoadMarketList()
            If Data.SenderList.Count = 0 Then LoadAllSenderList()
            If Data.YesNoIndicator.Count = 0 Then LoadYesNoIndicator()
            If Data.TrueFalseOption.Count = 0 Then LoadTrueFalseOptions()
            If Data.pepRetailer.Count = 0 Then LoadPepRetailerList()
            If Data.pepPubliation.Count = 0 Then LoadPepPublicationList()
            If Data.pepMarket.Count = 0 Then LoadPepMarketList()
            If Data.MediaList.Count = 0 Then LoadMediaList()

            If rowFilter Is Nothing AndAlso GetRetPublicationCoverageTableRowCount() > MaximumNonFilteredRowsAllowed Then
                Using e As Processors.EventArgs = New Processors.EventArgs()
                    Data.RetPublicationCoverage.Clear()
                    RaiseEvent RetPublicationCoverageExceedsNonFilteredRowsLimit(Me, e)
                    Exit Sub
                End Using
            End If

            If rowFilter Is Nothing Then
                LoadAllRetPublicationCoverage()
            Else
                LoadFilteredRetPublicationCoverage(rowFilter)
            End If

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent RetPublicationCoverageLoaded(Me, e)
            End Using

        End Sub


        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateRetPublicationCoverageTable(ByVal validateRows() As MaintenanceDataSet.RetPublicationCoverageRow)
            Dim tempRow As MaintenanceDataSet.RetPublicationCoverageRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates row values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateRetPublicationCoverageRows(ByVal validateRows() As MaintenanceDataSet.RetPublicationCoverageRow)
            Dim tempRow As MaintenanceDataSet.RetPublicationCoverageRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)
                If tempRow Is Nothing Then Continue For

                If tempRow.IsStartDtNull() Then
                    tempRow.SetColumnError("StartDt", "Specify start date for coverage.")
                Else
                    tempRow.SetColumnError("StartDt", "")
                End If

                If tempRow.IsPriorityNull() Then
                    tempRow.SetColumnError("Priority", "Specify Priority for coverage.")
                Else
                    tempRow.SetColumnError("Priority", "")
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates RetPublicationCoverage information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidateRetPublicationCoverageInformation(ByVal validateTable As MaintenanceDataSet.RetPublicationCoverageDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingRetPublicationCoverage(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim retpublicationCoverageRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.RetPublicationCoverageRow)
            retpublicationCoverageRows = From rpc In validateTable _
                                         Where rpc.RowState <> DataRowState.Deleted AndAlso rpc.RowState <> DataRowState.Unchanged _
                                         Select rpc

            ValidateRetPublicationCoverageRows(retpublicationCoverageRows.ToArray())
            ValidateRetPublicationCoverageTable(retpublicationCoverageRows.ToArray())

            retpublicationCoverageRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidRetPublicationCoverageFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent RetPublicationCoverageValidated(Me, e)
                End Using
            End If

        End Sub


        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">RetPublicationCoverage table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertRetPublicationCoverage(ByVal newrowsTable As MaintenanceDataSet.RetPublicationCoverageDataTable)

            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingRetPublicationCoverage(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                RetPublicationCoverageAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new Retailer-Publication coverage.", ex)
            End Try

            Using e As Processors.EventArgs = New Processors.EventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent RetPublicationCoverageInserted(Me, e)
                Exit Sub
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in RetPublicationCoverage data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateRetPublicationCoverage(ByVal modifiedRows As MaintenanceDataSet.RetPublicationCoverageDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingRetPublicationCoverage(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                RetPublicationCoverageAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update Retailer-Publication coverage(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent RetPublicationCoverageUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in RetPublicationCoverage data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteRetPublicationCoverage(ByVal deletedRows As MaintenanceDataSet.RetPublicationCoverageDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingRetPublicationCoverage(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                'RetPublicationCoverageAdapter.Update(deletedRows)
                RetPublicationCoverageAdapter.Update(Data.RetPublicationCoverage)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete Retailer-Publication coverage(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent RetPublicationCoverageDeleted(Me, e)
            End Using

        End Sub


#End Region

#Region " Methods for Sender table. "


        Public Event LoadingSenders As MCAPCancellableEventHandler
        Public Event SenderExceedsNonFilteredRowsLimit As MCAPEventHandler
        Public Event SendersLoaded As MCAPEventHandler

        Public Event ValidatingSenderInformation As MCAPCancellableEventHandler
        Public Event InvalidSenderInformationFound As MCAPEventHandler
        Public Event SenderInformationValidated As MCAPEventHandler

        Public Event InsertingSender As MCAPCancellableEventHandler
        Public Event SenderInserted As MCAPEventHandler

        Public Event UpdatingSender As MCAPCancellableEventHandler
        Public Event SenderUpdated As MCAPEventHandler

        Public Event DeletingSender As MCAPCancellableEventHandler
        Public Event SenderDeleted As MCAPEventHandler



        ''' <summary>
        ''' Returns total number of rows in expectation table.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSenderTableRowCount() As Integer
            Dim rowCount As Object


            rowCount = SenderAdapter.GetRowCount()
            If rowCount IsNot Nothing Then
                Return CType(rowCount, Integer)
            Else
                Return 0
            End If

        End Function

        ''' <summary>
        ''' Loads all senders from database, sorted by sender name.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllSenderInformation()

            Data.Sender.LoadingTable = True
            Data.Sender.BeginLoadData()
            'SenderAdapter.Fill(Data.Sender, UserLocationId)
            SenderAdapter.Fill(Data.Sender)
            Data.Sender.EndLoadData()
            Data.Sender.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads senders from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredSenderInformation(ByVal filterCondition As String)

            Data.Sender.LoadingTable = True
            Data.Sender.BeginLoadData()

            SenderAdapter.FillByWhereClause(Data.Sender, UserLocationId, filterCondition)
            Data.Sender.EndLoadData()
            Data.Sender.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads sender information from database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadSenders(Optional ByVal filterCondition As String = Nothing)
            Dim rowFilter As String = Nothing


            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False
                e.Data.Add("Filter", filterCondition)

                RaiseEvent LoadingSenders(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                ElseIf e.Data.Contains("Filter") AndAlso e.Data("Filter") IsNot Nothing Then
                    rowFilter = e.Data("Filter").ToString()
                End If
            End Using

            'TODO: What about priority?
            If Data.vwFrequency.Count = 0 Then LoadFrequencies()
            If Data.vwSenderType.Count = 0 Then LoadSenderTypes()
            If Data.RetailerList.Count = 0 Then LoadRetailerList()
            If Data.MarketList.Count = 0 Then LoadMarketList()
            'If Data.vwLocation.Count = 0 Then LoadLocations()
            Data.User.Rows.Clear()
            If Data.User.Count = 0 Then LoadNonHiddenUsersList()
            If Data.SenderList.Count = 0 Then LoadAllSenderList()
            If Data.vwLocation.Count = 0 Then
                LoadLocations()
                'Item Id: 8075. 
                Dim tempRow As MaintenanceDataSet.vwLocationRow = Data.vwLocation.NewvwLocationRow()
                tempRow.BeginEdit()
                If Data.vwLocation.Count = 0 Then
                    tempRow.SetCodeTypeIdNull()
                Else
                    tempRow.CodeTypeId = Data.vwLocation(0).CodeTypeId
                End If
                tempRow.SetCodeIdNull()
                tempRow.Descrip = "All"
                tempRow.EndEdit()
                Data.vwLocation.Rows.InsertAt(tempRow, 0)
                Data.vwLocation.AcceptChanges()
            End If

            If rowFilter Is Nothing AndAlso GetSenderTableRowCount() > MaximumNonFilteredRowsAllowed Then
                Using e As Processors.EventArgs = New Processors.EventArgs()
                    Data.Sender.Clear()
                    RaiseEvent SenderExceedsNonFilteredRowsLimit(Me, e)
                    Exit Sub
                End Using
            End If

            If rowFilter Is Nothing Then
                LoadAllSenderInformation()
            Else
                LoadFilteredSenderInformation(rowFilter)
            End If

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent SendersLoaded(Me, e)
            End Using

        End Sub


        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateSenderTable(ByVal validateRows() As MaintenanceDataSet.SenderRow)
            Dim tempRow As MaintenanceDataSet.SenderRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)


                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateSenderRows(ByVal validateRows() As MaintenanceDataSet.SenderRow)
            Dim tempRow As MaintenanceDataSet.SenderRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow.IsNameNull() AndAlso tempRow.Table.Columns("Name").AllowDBNull = False Then
                    tempRow.SetColumnError("Name", "Sender name cannot be blank.")
                Else
                    tempRow.SetColumnError("Name", String.Empty)
                End If

                If tempRow.IsStartDtNull() AndAlso tempRow.Table.Columns("StartDt").AllowDBNull = False Then
                    tempRow.SetColumnError("StartDt", "Specify start date for sender.")
                Else
                    tempRow.SetColumnError("StartDt", String.Empty)
                End If

                If tempRow.IsPriorityNull() AndAlso tempRow.Table.Columns("Priority").AllowDBNull = False Then
                    tempRow.SetColumnError("Priority", "Specify priority for sender.")
                Else
                    tempRow.SetColumnError("Priority", String.Empty)
                End If

                If tempRow.IsFrequencyIDNull() AndAlso tempRow.Table.Columns("FrequencyId").AllowDBNull = False Then
                    tempRow.SetColumnError("FrequencyId", "Specify frequency for sender.")
                Else
                    tempRow.SetColumnError("FrequencyId", String.Empty)
                End If

                If tempRow.IsTypeIdNull() AndAlso tempRow.Table.Columns("TypeId").AllowDBNull = False Then
                    tempRow.SetColumnError("TypeId", "Specify sender type for sender.")
                Else
                    tempRow.SetColumnError("TypeId", String.Empty)
                End If

                If tempRow.IsIndNoShippingNull() Then
                    tempRow.IndNoShipping = 1 'True = Shipping is not required.
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates Sender information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidateSenderInformation(ByVal validateTable As MaintenanceDataSet.SenderDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingSenderInformation(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim senderRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.SenderRow)
            senderRows = From sr In validateTable _
                         Where sr.RowState <> DataRowState.Deleted AndAlso sr.RowState <> DataRowState.Unchanged _
                         Select sr

            ValidateSenderRows(senderRows.ToArray())
            ValidateSenderTable(senderRows.ToArray())

            senderRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidSenderInformationFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent SenderInformationValidated(Me, e)
                End Using
            End If

        End Sub


        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">Sender table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertSender(ByVal newrowsTable As MaintenanceDataSet.SenderDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingSender(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                SenderAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new sender information.", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent SenderInserted(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in Sender data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateSender(ByVal modifiedRows As MaintenanceDataSet.SenderDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingSender(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try

                SenderAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update Sender(s) information.", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent SenderUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in Sender data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteSender(ByVal deletedRows As MaintenanceDataSet.SenderDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingSender(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                'SenderAdapter.Update(deletedRows)
                SenderAdapter.Update(Data.Sender)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete Sender(s) information.", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent SenderDeleted(Me, e)
            End Using

        End Sub


#End Region

#Region " Methods for SenderMktAssoc table. "


        Public Event LoadingSenderMktAssoc As MCAPCancellableEventHandler
        Public Event LoadingSenderPublication As MCAPCancellableEventHandler
        Public Event LoadingSenderExpectation As MCAPCancellableEventHandler
        Public Event SenderMktAssocExceedsNonFilteredRowsLimit As MCAPEventHandler
        Public Event SenderPublicationExceedsNonFilteredRowsLimit As MCAPEventHandler
        Public Event SenderExpectationExceedsNonFilteredRowsLimit As MCAPEventHandler
        Public Event SenderMktAssocLoaded As MCAPEventHandler
        Public Event SenderPublicationLoaded As MCAPEventHandler
        Public Event SenderExpectationLoaded As MCAPEventHandler

        Public Event ValidatingSenderMktAssoc As MCAPCancellableEventHandler
        Public Event ValidatingSenderPublication As MCAPCancellableEventHandler
        Public Event ValidatingSenderExpectation As MCAPCancellableEventHandler
        Public Event InvalidSenderMktAssocFound As MCAPEventHandler
        Public Event InvalidSenderPublicationFound As MCAPEventHandler
        Public Event InvalidSenderExpectationFound As MCAPEventHandler
        Public Event SenderMktAssocValidated As MCAPEventHandler
        Public Event SenderPublicationValidated As MCAPEventHandler
        Public Event SenderExpectationValidated As MCAPEventHandler

        Public Event InsertingSenderMktAssoc As MCAPCancellableEventHandler
        Public Event InsertingSenderPublication As MCAPCancellableEventHandler
        Public Event InsertingSenderExpectation As MCAPCancellableEventHandler
        Public Event SenderMktAssocInserted As MCAPEventHandler
        Public Event SenderPublicationInserted As MCAPEventHandler
        Public Event SenderExpectationInserted As MCAPEventHandler

        Public Event UpdatingSenderMktAssoc As MCAPCancellableEventHandler
        Public Event UpdatingSenderPublication As MCAPCancellableEventHandler
        Public Event UpdatingSenderExpectation As MCAPCancellableEventHandler
        Public Event SenderMktAssocUpdated As MCAPEventHandler
        Public Event SenderPublicationUpdated As MCAPEventHandler
        Public Event SenderExpectationUpdated As MCAPEventHandler

        Public Event DeletingSenderMktAssoc As MCAPCancellableEventHandler
        Public Event SenderMktAssocDeleted As MCAPEventHandler
        Public Event DeletingSenderPublication As MCAPCancellableEventHandler
        Public Event DeletingSenderExpectation As MCAPCancellableEventHandler
        Public Event SenderPublicationDeleted As MCAPEventHandler
        Public Event SenderExpectationDeleted As MCAPEventHandler


        ''' <summary>
        ''' Returns total number of rows in SenderPublication table.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSenderPublicationTableRowCount() As Integer
            Dim rowCount As Object


            rowCount = SenderPublicationAdapter.GetRowCount()
            If rowCount IsNot Nothing Then
                Return CType(rowCount, Integer)
            Else
                Return 0
            End If

        End Function

        ''' <summary>
        ''' Returns total number of rows in SenderExpectation table.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSenderExpectationTableRowCount() As Integer
            Dim rowCount As Object


            rowCount = SenderExpectationAdapter.GetRowCount()
            If rowCount IsNot Nothing Then
                Return CType(rowCount, Integer)
            Else
                Return 0
            End If

        End Function
        ''' <summary>
        ''' Returns total number of rows in SenderMktAssoc table.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSenderMktAssocTableRowCount() As Integer
            Dim rowCount As Object


            rowCount = SenderMktAssocAdapter.GetRowCount()
            If rowCount IsNot Nothing Then
                Return CType(rowCount, Integer)
            Else
                Return 0
            End If

        End Function
        ''' <summary>
        ''' Loads all Sender market association from database.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllSenderPublication()

            Data.SenderPublication.LoadingTable = True
            Data.SenderPublication.BeginLoadData()
            SenderPublicationAdapter.FillSenderPublication(Data.SenderPublication)
            Data.SenderPublication.EndLoadData()
            Data.SenderPublication.LoadingTable = False
            _InitCount = Data.SenderPublication.Count
        End Sub

        ''' <summary>
        ''' Loads all Sender market association from database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadAllSenderExpectation()

            Data.SenderExpectation.Clear()
            Data.SenderExpectation.LoadingTable = True
            Data.SenderExpectation.BeginLoadData()
            SenderExpectationAdapter.FillSenderExpectation(Data.SenderExpectation)
            Data.SenderExpectation.EndLoadData()
            Data.SenderExpectation.LoadingTable = False
            _InitCount = Data.SenderExpectation.Count
        End Sub

        ''' <summary>
        ''' Loads all Sender market association from database.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllSenderMktAssoc()

            Data.SenderMktAssoc.LoadingTable = True
            Data.SenderMktAssoc.BeginLoadData()
            SenderMktAssocAdapter.Fill(Data.SenderMktAssoc)
            Data.SenderMktAssoc.EndLoadData()
            Data.SenderMktAssoc.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads SenderPublication from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredSenderPublication(ByVal filterCondition As String)

            Data.SenderPublication.LoadingTable = True
            Data.SenderPublication.BeginLoadData()
            SenderPublicationAdapter.FillByWhereClause(Data.SenderPublication, UserLocationId, "SMA." + filterCondition)
            Data.SenderPublication.EndLoadData()
            Data.SenderPublication.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads SenderExpectation from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredSenderExpectation(ByVal filterCondition As String)

            Data.SenderExpectation.LoadingTable = True
            Data.SenderExpectation.BeginLoadData()
            SenderExpectationAdapter.FillByWhereClause(Data.SenderExpectation, filterCondition)
            Data.SenderExpectation.EndLoadData()
            Data.SenderExpectation.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads SenderMktAssoc from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredSenderMktAssoc(ByVal filterCondition As String)

            Data.SenderMktAssoc.LoadingTable = True
            Data.SenderMktAssoc.BeginLoadData()
            SenderMktAssocAdapter.FillByWhereClause(Data.SenderMktAssoc, UserLocationId, "SMA." + filterCondition)
            Data.SenderMktAssoc.EndLoadData()
            Data.SenderMktAssoc.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Load SenderPublication from database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadSenderPublication(Optional ByVal filterCondition As String = Nothing)
            Dim rowFilter As String = Nothing


            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False
                e.Data.Add("Filter", filterCondition)

                RaiseEvent LoadingSenderPublication(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                ElseIf e.Data.Contains("Filter") AndAlso e.Data("Filter") IsNot Nothing Then
                    rowFilter = e.Data("Filter").ToString()
                End If
            End Using

            If Data.PublicationList.Count = 0 Then LoadPublicationList()
            If Data.SenderList.Count = 0 Then LoadAllSenderListOrderByName() 'LoadSenderList()



            If rowFilter Is Nothing AndAlso GetSenderPublicationTableRowCount() > MaximumNonFilteredRowsAllowed Then
                Using e As Processors.EventArgs = New Processors.EventArgs()
                    Data.SenderPublication.Clear()
                    RaiseEvent SenderPublicationExceedsNonFilteredRowsLimit(Me, e)
                    Exit Sub
                End Using
            End If

            If rowFilter Is Nothing Then
                LoadAllSenderPublication()
            Else
                LoadFilteredSenderPublication(rowFilter)
            End If

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent SenderPublicationLoaded(Me, e)
            End Using

        End Sub


        Public Sub RefreshSenderPublication()
            LoadAllSenderPublication()
        End Sub

        Public Sub LoadFilteredMarket(ByVal _med As Integer)
            LoadFilteredSEMarkets(_med)
        End Sub


        Public Sub loadFilteredRetailer(ByVal _med As Integer, ByVal _mkt As Integer)
            LoadFilteredSERetailers(_med, _mkt)
        End Sub



        ''' <summary>
        ''' Load SenderExpectation from database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadSenderExpectation(Optional ByVal filterCondition As String = Nothing)
            Dim rowFilter As String = Nothing
            'filterCondition = "mktid =1"
            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False
                e.Data.Add("Filter", filterCondition)

                RaiseEvent LoadingSenderExpectation(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                ElseIf e.Data.Contains("Filter") AndAlso e.Data("Filter") IsNot Nothing Then
                    rowFilter = e.Data("Filter").ToString()
                End If
            End Using

            LoadAllSenderListOrderByName()
            LoadAllMediaTypes()
            ' LoadAllMediaTypesforSenderExpecatation()
            LoadAllMarkets()
            LoadAllRetailers()



            If rowFilter Is Nothing AndAlso GetSenderExpectationTableRowCount() > MaximumNonFilteredRowsAllowed Then
                Using e As Processors.EventArgs = New Processors.EventArgs()
                    Data.SenderExpectation.Clear()
                    RaiseEvent SenderExpectationExceedsNonFilteredRowsLimit(Me, e)
                    Exit Sub
                End Using
            End If

            If rowFilter Is Nothing Then
                LoadAllSenderExpectation()
            Else

                LoadFilteredSenderExpectation(rowFilter)
            End If


            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent SenderExpectationLoaded(Me, e)
            End Using

        End Sub

        Public Function GetExpectationID(ByVal _media As Integer, ByVal _mkt As Integer, ByVal _ret As Integer) As Integer
            Dim _ExpectationID As Integer = 0

            LoadExpectationList(_media, _mkt, _ret, True)
            If Data.Expectation.Count > 0 Then
                _ExpectationID = Data.Expectation.Item(0).ExpectationID
            Else
                _ExpectationID = -1
            End If

            Data.Expectation.Dispose()
            Return _ExpectationID
        End Function



        ''' <summary>
        ''' Load SenderMktAssoc from database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadSenderMktAssoc(Optional ByVal filterCondition As String = Nothing)
            Dim rowFilter As String = Nothing


            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False
                e.Data.Add("Filter", filterCondition)

                RaiseEvent LoadingSenderMktAssoc(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                ElseIf e.Data.Contains("Filter") AndAlso e.Data("Filter") IsNot Nothing Then
                    rowFilter = e.Data("Filter").ToString()
                End If
            End Using

            If Data.MarketList.Count = 0 Then LoadMarketList()
            If Data.SenderList.Count = 0 Then LoadAllSenderListOrderByName() 'LoadSenderList()

            If rowFilter Is Nothing AndAlso GetSenderMktAssocTableRowCount() > MaximumNonFilteredRowsAllowed Then
                Using e As Processors.EventArgs = New Processors.EventArgs()
                    Data.SenderMktAssoc.Clear()
                    RaiseEvent SenderMktAssocExceedsNonFilteredRowsLimit(Me, e)
                    Exit Sub
                End Using
            End If

            If rowFilter Is Nothing Then
                LoadAllSenderMktAssoc()
            Else
                LoadFilteredSenderMktAssoc(rowFilter)
            End If

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent SenderMktAssocLoaded(Me, e)
            End Using

        End Sub


        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateSenderMktAssocTable(ByVal validateRows() As MaintenanceDataSet.SenderMktAssocRow)
            Dim tempRow As MaintenanceDataSet.SenderMktAssocRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)


                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateSenderPublicationTable(ByVal validateRows() As MaintenanceDataSet.SenderPublicationRow)
            Dim tempRow As MaintenanceDataSet.SenderPublicationRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)


                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateSenderExpectationTable(ByVal validateRows() As MaintenanceDataSet.SenderExpectationRow)
            Dim tempRow As MaintenanceDataSet.SenderExpectationRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)


                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates row values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateSenderMktAssocRows(ByVal validateRows() As MaintenanceDataSet.SenderMktAssocRow)
            Dim tempRow As MaintenanceDataSet.SenderMktAssocRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)


                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates Sender information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidateSenderMktAssocInformation(ByVal validateTable As MaintenanceDataSet.SenderMktAssocDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingSenderMktAssoc(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim sendermktRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.SenderMktAssocRow)
            sendermktRows = From smr In validateTable _
                            Where smr.RowState <> DataRowState.Deleted AndAlso smr.RowState <> DataRowState.Unchanged _
                            Select smr
            ValidateSenderMktAssocTable(sendermktRows.ToArray())
            sendermktRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidSenderMktAssocFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent SenderMktAssocValidated(Me, e)
                End Using
            End If

        End Sub

        ''' <summary>
        ''' Validates Sender information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidateSenderPublicationInformation(ByVal validateTable As MaintenanceDataSet.SenderPublicationDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingSenderPublication(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim senderpubRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.SenderPublicationRow)
            senderpubRows = From smr In validateTable _
                            Where smr.RowState <> DataRowState.Deleted AndAlso smr.RowState <> DataRowState.Unchanged _
                            Select smr
            ValidateSenderPublicationTable(senderpubRows.ToArray())
            senderpubRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidSenderPublicationFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent SenderPublicationValidated(Me, e)
                End Using
            End If

        End Sub

        ''' <summary>
        ''' Validates Sender information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidateSenderExpectationInformation(ByVal validateTable As MaintenanceDataSet.SenderExpectationDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingSenderExpectation(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim senderexpRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.SenderExpectationRow)
            senderexpRows = From smr In validateTable _
                            Where smr.RowState <> DataRowState.Deleted AndAlso smr.RowState <> DataRowState.Unchanged _
                            Select smr
            ValidateSenderExpectationTable(senderexpRows.ToArray())
            senderexpRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidSenderExpectationFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent SenderExpectationValidated(Me, e) 'need to check
                End Using
            End If

        End Sub


        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">SenderMktAssoc table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertSenderMktAssoc(ByVal newrowsTable As MaintenanceDataSet.SenderMktAssocDataTable)

            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingSenderMktAssoc(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                SenderMktAssocAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new Sender-Market association.", ex)
            End Try

            Using e As Processors.EventArgs = New Processors.EventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent SenderMktAssocInserted(Me, e)
                Exit Sub
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">SenderMktAssoc table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertSenderPublication(ByVal newrowsTable As MaintenanceDataSet.SenderPublicationDataTable)


            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingSenderPublication(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                SenderPublicationAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new Sender-Market association.", ex)
            End Try

            Using e As Processors.EventArgs = New Processors.EventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent SenderPublicationInserted(Me, e)
                Exit Sub
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">SenderMktAssoc table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertSenderExpectation(ByVal newrowsTable As MaintenanceDataSet.SenderExpectationDataTable, ByVal _SenderId As Integer, ByVal _ExpectationId As Integer, ByVal _startDate As Object, ByVal _endDate As Object)

            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingSenderExpectation(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                If IsDuplicate(_SenderId, _ExpectationId) Then
                    MessageBox.Show("Duplicate Data is not allowed.", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Try
                End If
                'SenderExpectationAdapter.Update(newrowsTable)
                SenderExpectationAdapter.InsertSenderExpectation(_SenderId, _ExpectationId, CType(_startDate, Date?), CType(_endDate, Date?))
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new Sender Expectation.", ex)
            End Try

            Using e As Processors.EventArgs = New Processors.EventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent SenderExpectationInserted(Me, e)
                Exit Sub
            End Using

        End Sub

        Private Function IsDuplicate(ByVal _SenderId As Integer, ByVal _ExpectationID As Integer) As Boolean
            If GetDuplicateTableRowCount(_SenderId, _ExpectationID) > 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        ''' <summary>
        ''' Returns total number of duplicate rows in Sender Expectation.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDuplicateTableRowCount(ByVal _SenderId As Integer, ByVal _ExpectationId As Integer) As Integer
            Dim rowCount As Nullable(Of Integer)


            rowCount = SenderExpectationAdapter.GetDuplicateCount(_SenderId, _ExpectationId)
            If rowCount.HasValue Then
                Return rowCount.Value
            Else
                Return 0
            End If

        End Function
        ''' <summary>
        ''' Synchronizes modified row(s) in SenderMktAssoc data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateSenderMktAssoc(ByVal modifiedRows As MaintenanceDataSet.SenderMktAssocDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingSenderMktAssoc(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                SenderMktAssocAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update Sender-Market association(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent SenderMktAssocUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in SenderPublication data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateSenderPublication(ByVal modifiedRows As MaintenanceDataSet.SenderPublicationDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingSenderPublication(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                SenderPublicationAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update Sender-Publication association(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent SenderPublicationUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in SenderPublication data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateSenderExpectation(ByVal modifiedRows As MaintenanceDataSet.SenderExpectationDataTable, ByVal _SenderId As Integer, ByVal _startDate As Object, ByVal _endDate As Object, ByVal _ExpectationId As Integer)
            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingSenderExpectation(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                
                SenderExpectationAdapter.Update(modifiedRows)
                'SenderExpectationAdapter.UpdateSenderExpectation(_SenderId, _ExpectationId, CType(_startDate, Date?), CType(_endDate, Date?), _ExpectationId, _SenderId)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update Sender Expectation.", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent SenderExpectationUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in SenderMktAssoc data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteSenderMktAssoc(ByVal deletedRows As MaintenanceDataSet.SenderMktAssocDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingSenderMktAssoc(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                'SenderMktAssocAdapter.Update(deletedRows)
                SenderMktAssocAdapter.Update(Data.SenderMktAssoc)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete Sender-Market association(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent SenderMktAssocDeleted(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in SenderMktAssoc data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteSenderPublication(ByVal deletedRows As MaintenanceDataSet.SenderPublicationDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingSenderPublication(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                'SenderMktAssocAdapter.Update(deletedRows)
                SenderPublicationAdapter.Update(Data.SenderPublication)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete Sender-Market association(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent SenderPublicationDeleted(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in SenderExpectation data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteSenderExpectation(ByVal deletedRows As MaintenanceDataSet.SenderExpectationDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingSenderExpectation(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                SenderExpectationAdapter.Update(Data.SenderExpectation)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete Sender-Market association(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent SenderExpectationDeleted(Me, e)
            End Using

        End Sub


#End Region

#Region " Methods for Shipper table. "


        Public Event LoadingShippers As MCAPCancellableEventHandler
        Public Event ShipperExceedsNonFilteredRowsLimit As MCAPEventHandler
        Public Event ShippersLoaded As MCAPEventHandler

        Public Event ValidatingShipper As MCAPCancellableEventHandler
        Public Event InvalidShipperFound As MCAPEventHandler
        Public Event ShipperValidated As MCAPEventHandler

        Public Event InsertingShipper As MCAPCancellableEventHandler
        Public Event ShipperInserted As MCAPEventHandler

        Public Event UpdatingShipper As MCAPCancellableEventHandler
        Public Event ShipperUpdated As MCAPEventHandler

        Public Event DeletingShipper As MCAPCancellableEventHandler
        Public Event ShipperDeleted As MCAPEventHandler



        ''' <summary>
        ''' Returns total number of rows in shipper table.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetShipperTableRowCount() As Integer
            Dim rowCount As Nullable(Of Integer)


            rowCount = ShipperAdapter.GetRowCount()
            If rowCount.HasValue Then
                Return rowCount.Value
            Else
                Return 0
            End If

        End Function

        ''' <summary>
        ''' Loads all shippers from database, sorted by shipper name.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllShippers()

            Data.Shipper.LoadingTable = True
            Data.Shipper.BeginLoadData()
            ShipperAdapter.Fill(Data.Shipper)
            Data.Shipper.EndLoadData()
            Data.Shipper.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads shipper from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredShippers(ByVal filterCondition As String)

            Data.Shipper.LoadingTable = True
            Data.Shipper.BeginLoadData()
            ShipperAdapter.FillByWhereClause(Data.Shipper, filterCondition)
            Data.Shipper.EndLoadData()
            Data.Shipper.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads shippers from database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadShippers(Optional ByVal filterCondition As String = Nothing)
            Dim rowFilter As String = Nothing

            Try
                Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                    e.Cancel = False
                    e.Data.Add("Filter", filterCondition)

                    RaiseEvent LoadingShippers(Me, e)

                    If e.Cancel Then
                        e.Dispose()
                        Exit Sub
                    ElseIf e.Data.Contains("Filter") AndAlso e.Data("Filter") IsNot Nothing Then
                        rowFilter = e.Data("Filter").ToString()
                    End If
                End Using

                If rowFilter Is Nothing AndAlso GetShipperTableRowCount() > MaximumNonFilteredRowsAllowed Then
                    Using e As Processors.EventArgs = New Processors.EventArgs()
                        Data.Shipper.Clear()
                        RaiseEvent ShipperExceedsNonFilteredRowsLimit(Me, e)
                        Exit Sub
                    End Using
                End If


                If rowFilter Is Nothing Then
                    LoadAllShippers()
                Else
                    LoadFilteredShippers(rowFilter)
                End If

                Using e As Processors.EventArgs = New Processors.EventArgs()
                    RaiseEvent ShippersLoaded(Me, e)
                End Using
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End Sub

        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateShipperTable(ByVal validateRows() As MaintenanceDataSet.ShipperRow)
            Dim tempRow As MaintenanceDataSet.ShipperRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)


                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates rows values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateShipperRows(ByVal validateRows() As MaintenanceDataSet.ShipperRow)
            Dim tempRow As MaintenanceDataSet.ShipperRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow.IsDescripNull() OrElse tempRow.Descrip.Trim().Length = 0 Then
                    tempRow.SetColumnError("Descrip", "Specify shipper name. Name cannot be blank.")
                Else
                    tempRow.SetColumnError("Descrip", "")
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates Sender information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidateShipperInformation(ByVal validateTable As MaintenanceDataSet.ShipperDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingShipper(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim shipperRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.ShipperRow)
            shipperRows = From sr In validateTable _
                          Where sr.RowState <> DataRowState.Deleted AndAlso sr.RowState <> DataRowState.Unchanged _
                          Select sr

            ValidateShipperRows(shipperRows.ToArray())
            ValidateShipperTable(shipperRows.ToArray())

            shipperRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidShipperFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent ShipperValidated(Me, e)
                End Using
            End If

        End Sub


        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">Shipper table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertShipper(ByVal newrowsTable As MaintenanceDataSet.ShipperDataTable)

            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingShipper(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                ShipperAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new shipper.", ex)
            End Try

            Using e As Processors.EventArgs = New Processors.EventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent ShipperInserted(Me, e)
                Exit Sub
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in Shipper data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateShipper(ByVal modifiedRows As MaintenanceDataSet.ShipperDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingShipper(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                ShipperAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update shipper(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent ShipperUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in Shipper data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteShipper(ByVal deletedRows As MaintenanceDataSet.ShipperDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingShipper(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                'ShipperAdapter.Update(deletedRows)
                ShipperAdapter.Update(Data.Shipper)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete shipper(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent ShipperDeleted(Me, e)
            End Using

        End Sub


#End Region

#Region " Methods for Size table "


        Public Event LoadingSizes As MCAPCancellableEventHandler
        Public Event SizesExceedsNonFilteredRowsLimit As MCAPEventHandler
        Public Event SizesLoaded As MCAPEventHandler

        Public Event ValidatingSize As MCAPCancellableEventHandler
        Public Event InvalidSizeFound As MCAPEventHandler
        Public Event SizeValidated As MCAPEventHandler

        Public Event InsertingSize As MCAPCancellableEventHandler
        Public Event SizeInserted As MCAPEventHandler

        Public Event UpdatingSize As MCAPCancellableEventHandler
        Public Event SizeUpdated As MCAPEventHandler

        Public Event DeletingSize As MCAPCancellableEventHandler
        Public Event SizeDeleted As MCAPEventHandler



        ''' <summary>
        ''' Returns total number of rows in size table.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSizeTableRowCount() As Integer
            Dim rowCount As Nullable(Of Integer)


            rowCount = SizeAdapter.GetRowCount()
            If rowCount.HasValue Then
                Return rowCount.Value
            Else
                Return 0
            End If

        End Function

        ''' <summary>
        ''' Loads all sizes from database, sorted by size Id.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadAllSizes()

            Data.Size.LoadingTable = True
            Data.Size.BeginLoadData()
            SizeAdapter.Fill(Data.Size)
            Data.Size.EndLoadData()
            Data.Size.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads expectations from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredSizes(ByVal filterCondition As String)

            Data.Size.LoadingTable = True
            Data.Size.BeginLoadData()
            SizeAdapter.FillByWhereClause(Data.Size, filterCondition)
            Data.Size.EndLoadData()
            Data.Size.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads Sizes information from database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadSizes(Optional ByVal filterCondition As String = Nothing)
            Dim rowFilter As String = Nothing


            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False
                e.Data.Add("Filter", filterCondition)

                RaiseEvent LoadingSizes(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                ElseIf e.Data.Contains("Filter") AndAlso e.Data("Filter") IsNot Nothing Then
                    rowFilter = e.Data("Filter").ToString()
                End If
            End Using

            If rowFilter Is Nothing AndAlso GetSizeTableRowCount() > MaximumNonFilteredRowsAllowed Then
                Using e As Processors.EventArgs = New Processors.EventArgs()
                    Data.Size.Clear()
                    RaiseEvent SizesExceedsNonFilteredRowsLimit(Me, e)
                    Exit Sub
                End Using
            End If

            If rowFilter Is Nothing Then
                LoadAllSizes()
            Else
                LoadFilteredSizes(rowFilter)
            End If

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent SizesLoaded(Me, e)
            End Using

        End Sub


        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateSizeTable(ByVal validateRows() As MaintenanceDataSet.SizeRow)
            Dim tempRow As MaintenanceDataSet.SizeRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates rows values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateSizeRows(ByVal validateRows() As MaintenanceDataSet.SizeRow)
            Dim tempRow As MaintenanceDataSet.SizeRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                If tempRow.IsHeightNull() Then
                    tempRow.SetColumnError("Height", "Specify height. Height cannot be blank.")
                Else
                    tempRow.SetColumnError("Height", "")
                End If

                If tempRow.IsWidthNull() Then
                    tempRow.SetColumnError("Width", "Specify width. Width cannot be blank.")
                Else
                    tempRow.SetColumnError("Width", "")
                End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates Sender information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidateSizeInformation(ByVal validateTable As MaintenanceDataSet.SizeDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingSize(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim sizeRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.SizeRow)
            sizeRows = From sr In validateTable _
                       Where sr.RowState <> DataRowState.Deleted AndAlso sr.RowState <> DataRowState.Unchanged _
                       Select sr

            ValidateSizeRows(sizeRows.ToArray())
            ValidateSizeTable(sizeRows.ToArray())

            sizeRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidSizeFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent SizeValidated(Me, e)
                End Using
            End If

        End Sub


        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">Size table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertSize(ByVal newrowsTable As MaintenanceDataSet.SizeDataTable)

            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingSize(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                SizeAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new size.", ex)
            End Try

            Using e As Processors.EventArgs = New Processors.EventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent SizeInserted(Me, e)
                Exit Sub
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in Size data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateSize(ByVal modifiedRows As MaintenanceDataSet.SizeDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingSize(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                SizeAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update size(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent SizeUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in Size data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteSize(ByVal deletedRows As MaintenanceDataSet.SizeDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingSize(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                'SizeAdapter.Update(deletedRows)
                SizeAdapter.Update(Data.Size)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete size(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent SizeDeleted(Me, e)
            End Using

        End Sub


#End Region

#Region " Methods for Website table "


        Public Event LoadingWebsite As MCAPCancellableEventHandler
        Public Event WebsiteExceedsNonFilteredRowsLimit As MCAPEventHandler
        Public Event WebsiteLoaded As MCAPEventHandler

        Public Event ValidatingWebsite As MCAPCancellableEventHandler
        Public Event InvalidWebsiteFound As MCAPEventHandler
        Public Event WebsiteValidated As MCAPEventHandler

        Public Event InsertingWebsite As MCAPCancellableEventHandler
        Public Event WebsiteInserted As MCAPEventHandler

        Public Event UpdatingWebsite As MCAPCancellableEventHandler
        Public Event WebsiteUpdated As MCAPEventHandler

        Public Event DeletingWebsite As MCAPCancellableEventHandler
        Public Event WebsiteDeleted As MCAPEventHandler



        ''' <summary>
        ''' Returns total number of rows in size table.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetWebsiteTableRowCount() As Integer
            Dim rowCount As Nullable(Of Integer)


            rowCount = WebsitePageDownloadAdapter.GetRowCount()
            If rowCount.HasValue Then
                Return rowCount.Value
            Else
                Return 0
            End If


        End Function

        ''' <summary>
        ''' Loads all sizes from database, sorted by size Id.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub LoadAllWebsite()

            Data.WebsitePageDownload.LoadingTable = True
            Data.WebsitePageDownload.BeginLoadData()
            Dim excpReslt As String
            WebsitePageDownloadAdapter.FillOnlineData(Data.WebsitePageDownload)
            Data.WebsitePageDownload.EndLoadData()
            Data.WebsitePageDownload.LoadingTable = False

            'Data.Expectation.LoadingTable = True
            'Data.Expectation.BeginLoadData()
            'ExpectationAdapter.Fill(Data.Expectation)
            'Data.Expectation.EndLoadData()
            'Data.Expectation.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads expectations from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredWebsite(ByVal filterCondition As String)
            Data.WebsitePageDownload.LoadingTable = True
            Data.WebsitePageDownload.BeginLoadData()
            WebsitePageDownloadAdapter.FillByWhereClause(Data.WebsitePageDownload, filterCondition)
            'WebsitePageDownloadAdapter.FillByWhereClause(Data.WebsitePageDownload, filterCondition)removed due to filter error, uncomment when the update is done in maintenance form
            Data.WebsitePageDownload.EndLoadData()
            Data.WebsitePageDownload.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads Sizes information from database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadWebsites(Optional ByVal filterCondition As String = Nothing)
            Dim rowFilter As String = Nothing


            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False
                e.Data.Add("Filter", filterCondition)

                RaiseEvent LoadingWebsite(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                ElseIf e.Data.Contains("Filter") AndAlso e.Data("Filter") IsNot Nothing Then
                    rowFilter = e.Data("Filter").ToString()
                End If
            End Using

            If Data.RetailerList.Count = 0 Then LoadRetailerList()
            LoadWebsiteProjects()
            'LoadPageTypeIds()
            'Edited by Mark Marshall
            LoadOnlineWebsitePageTypeIds()
            LoadPageDownloadFrequency()


            If rowFilter Is Nothing AndAlso GetWebsiteTableRowCount() > MaximumNonFilteredRowsAllowed Then
                Using e As Processors.EventArgs = New Processors.EventArgs()
                    Data.WebsitePageDownload.Clear()
                    RaiseEvent WebsiteExceedsNonFilteredRowsLimit(Me, e)
                    Exit Sub
                End Using
            End If

            If rowFilter Is Nothing Then
                LoadAllWebsite()
            Else
                LoadFilteredWebsite(rowFilter)
            End If

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent WebsiteLoaded(Me, e)
            End Using

        End Sub


        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateWebsiteTable(ByVal validateRows() As MaintenanceDataSet.WebsitePageDownloadRow)
            Dim tempRow As MaintenanceDataSet.WebsitePageDownloadRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates rows values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateWebsiteRows(ByVal validateRows() As MaintenanceDataSet.WebsitePageDownloadRow)
            Dim tempRow As MaintenanceDataSet.WebsitePageDownloadRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                'If tempRow.IsHeightNull() Then
                '    tempRow.SetColumnError("Height", "Specify height. Height cannot be blank.")
                'Else
                '    tempRow.SetColumnError("Height", "")
                'End If

                'If tempRow.IsWidthNull() Then
                '    tempRow.SetColumnError("Width", "Specify width. Width cannot be blank.")
                'Else
                '    tempRow.SetColumnError("Width", "")
                'End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates Sender information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidateWebsiteInformation(ByVal validateTable As MaintenanceDataSet.WebsitePageDownloadDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingWebsite(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim websiteRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.WebsitePageDownloadRow)
            websiteRows = From sr In validateTable _
                       Where sr.RowState <> DataRowState.Deleted AndAlso sr.RowState <> DataRowState.Unchanged _
                       Select sr

            ValidateWebsiteRows(websiteRows.ToArray())
            ValidateWebsiteTable(websiteRows.ToArray())

            websiteRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidWebsiteFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent WebsiteValidated(Me, e)
                End Using
            End If

        End Sub


        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">Size table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertWebsite(ByVal newrowsTable As MaintenanceDataSet.WebsitePageDownloadDataTable)

            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingWebsite(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                WebsitePageDownloadAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new website.", ex)
            End Try

            Using e As Processors.EventArgs = New Processors.EventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent WebsiteInserted(Me, e)
                Exit Sub
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in Size data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateWebsite(ByVal modifiedRows As MaintenanceDataSet.WebsitePageDownloadDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingWebsite(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                WebsitePageDownloadAdapter.Update(modifiedRows)

            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update website(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent WebsiteUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in Size data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteWebsite(ByVal deletedRows As MaintenanceDataSet.WebsitePageDownloadDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingWebsite(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                WebsitePageDownloadAdapter.Update(Data.WebsitePageDownload)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete website(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent WebsiteDeleted(Me, e)
            End Using

        End Sub

        Public Sub RefreshSenderExpectation()
            LoadAllSenderListOrderByName()
            LoadAllMediaTypes()
            LoadAllMarkets()
            LoadAllRetailers()
            LoadAllSenderExpectation()
        End Sub


#End Region

#Region " Methods for Site table "


        Public Event LoadingSite As MCAPCancellableEventHandler
        Public Event SiteExceedsNonFilteredRowsLimit As MCAPEventHandler
        Public Event SiteLoaded As MCAPEventHandler

        Public Event ValidatingSite As MCAPCancellableEventHandler

        Public Event InvalidSiteFound As MCAPEventHandler
        Public Event SiteValidated As MCAPEventHandler

        Public Event InsertingSite As MCAPCancellableEventHandler
        Public Event SiteInserted As MCAPEventHandler

        Public Event UpdatingSite As MCAPCancellableEventHandler
        Public Event SiteUpdated As MCAPEventHandler

        Public Event DeletingSite As MCAPCancellableEventHandler
        Public Event SiteDeleted As MCAPEventHandler



        ''' <summary>
        ''' Returns total number of rows in size table.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSiteTableRowCount() As Integer
            Dim rowCount As Nullable(Of Integer)

            rowCount = SiteAdapter.GetRowCount()
            If rowCount.HasValue Then
                Return rowCount.Value
            Else
                Return 0
            End If

        End Function

        ''' <summary>
        ''' Loads all sizes from database, sorted by size Id.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadAllSite()

            Data.Site.LoadingTable = True
            Data.Site.BeginLoadData()
            Dim excpReslt As String
            SiteAdapter.FillSiteData(Data.Site)
            Data.Site.EndLoadData()
            Data.Site.LoadingTable = False


        End Sub

        ''' <summary>
        ''' Loads expectations from database satisfying specified filter condition.
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredSite(ByVal filterCondition As String)

            Data.Site.LoadingTable = True
            Data.Site.BeginLoadData()
            SiteAdapter.FillByWhereClause(Data.Site, filterCondition) 'remove due to filter error, uncomment when done in updating the maintenance form
            Data.Site.EndLoadData()
            Data.Site.LoadingTable = False

        End Sub

        ''' <summary>
        ''' Loads Sizes information from database.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadSites(Optional ByVal filterCondition As String = Nothing)
            Dim rowFilter As String = Nothing


            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Cancel = False
                e.Data.Add("Filter", filterCondition)

                RaiseEvent LoadingSite(Me, e)

                If e.Cancel Then
                    e.Dispose()
                    Exit Sub
                ElseIf e.Data.Contains("Filter") AndAlso e.Data("Filter") IsNot Nothing Then
                    rowFilter = e.Data("Filter").ToString()
                End If
            End Using

            ' Load Filters
            If Data.RetailerList.Count = 0 Then LoadSiteRetailerList()
            If Data.MarketList.Count = 0 Then LoadMarketList()
            'LoadWebsiteProjects()


            If rowFilter Is Nothing AndAlso GetSiteTableRowCount() > MaximumNonFilteredRowsAllowed Then
                Using e As Processors.EventArgs = New Processors.EventArgs()
                    Data.Site.Clear()
                    RaiseEvent SiteExceedsNonFilteredRowsLimit(Me, e)
                    Exit Sub
                End Using
            End If

            If rowFilter Is Nothing Then
                LoadAllSite()
            Else
                'Data.Site.Clear()
                LoadFilteredSite(rowFilter)
            End If

            Using e As Processors.EventArgs = New Processors.EventArgs()
                RaiseEvent SiteLoaded(Me, e)
            End Using

        End Sub


        ''' <summary>
        ''' Validates table values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateSiteTable(ByVal validateRows() As MaintenanceDataSet.SiteRow)
            Dim tempRow As MaintenanceDataSet.SiteRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates rows values.
        ''' </summary>
        ''' <param name="validateRows"></param>
        ''' <remarks></remarks>
        Private Sub ValidateSiteRows(ByVal validateRows() As MaintenanceDataSet.SiteRow)
            Dim tempRow As MaintenanceDataSet.SiteRow


            For i As Integer = 0 To validateRows.Length - 1
                tempRow = validateRows(i)

                'If tempRow.IsHeightNull() Then
                '    tempRow.SetColumnError("Height", "Specify height. Height cannot be blank.")
                'Else
                '    tempRow.SetColumnError("Height", "")
                'End If

                'If tempRow.IsWidthNull() Then
                '    tempRow.SetColumnError("Width", "Specify width. Width cannot be blank.")
                'Else
                '    tempRow.SetColumnError("Width", "")
                'End If

                tempRow = Nothing
            Next

        End Sub

        ''' <summary>
        ''' Validates Sender information.
        ''' </summary>
        ''' <param name="validateTable"></param>
        ''' <remarks></remarks>
        Public Sub ValidateSiteInformation(ByVal validateTable As MaintenanceDataSet.SiteDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ValidateRows", validateTable)
                RaiseEvent ValidatingSite(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Dim siteRows As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.SiteRow)
            siteRows = From sr In validateTable _
                       Where sr.RowState <> DataRowState.Deleted AndAlso sr.RowState <> DataRowState.Unchanged _
                       Select sr

            ValidateSiteRows(siteRows.ToArray())
            ValidateSiteTable(siteRows.ToArray())

            siteRows = Nothing

            If validateTable.HasErrors Then
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent InvalidSiteFound(Me, e)
                End Using
            Else
                Using e As EventArgs = New EventArgs
                    e.Data.Add("ValidateRows", validateTable)
                    RaiseEvent SiteValidated(Me, e)
                End Using
            End If

        End Sub


        ''' <summary>
        ''' Synchronizes new row(s) added into DataTable.
        ''' </summary>
        ''' <param name="newrowsTable">Size table containing only new row(s)</param>
        ''' <remarks></remarks>
        Public Sub InsertSite(ByVal newrowsTable As MaintenanceDataSet.SiteDataTable)

            Using e As Processors.CancellableEventArgs = New Processors.CancellableEventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent InsertingSite(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                SiteAdapter.Update(newrowsTable)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to insert new site.", ex)
            End Try

            Using e As Processors.EventArgs = New Processors.EventArgs()
                e.Data.Add("NewRows", newrowsTable)
                RaiseEvent SiteInserted(Me, e)
                Exit Sub
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes modified row(s) in Size data table with database.
        ''' </summary>
        ''' <param name="modifiedRows"></param>
        ''' <remarks></remarks>
        Public Sub UpdateSite(ByVal modifiedRows As MaintenanceDataSet.SiteDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent UpdatingSite(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                SiteAdapter.Update(modifiedRows)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to update site(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                e.Data.Add("ModifiedRows", modifiedRows)
                RaiseEvent SiteUpdated(Me, e)
            End Using

        End Sub

        ''' <summary>
        ''' Synchronizes deleted row(s) in Size data table with database.
        ''' </summary>
        ''' <param name="deletedRows"></param>
        ''' <remarks></remarks>
        Public Sub DeleteSite(ByVal deletedRows As MaintenanceDataSet.SiteDataTable)

            Using e As CancellableEventArgs = New CancellableEventArgs
                e.Data.Add("DeletedRows", deletedRows)
                RaiseEvent DeletingSite(Me, e)
                If e.Cancel Then
                    Exit Sub
                End If
            End Using

            Try
                SiteAdapter.Update(Data.Site)
            Catch ex As Exception
                Throw New System.ApplicationException("Unable to delete site(s).", ex)
            End Try

            Using e As EventArgs = New EventArgs
                RaiseEvent SiteDeleted(Me, e)
            End Using

        End Sub


#End Region
    End Class

End Namespace
