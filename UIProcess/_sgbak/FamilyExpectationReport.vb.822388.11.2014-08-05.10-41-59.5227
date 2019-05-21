Namespace UI.Processors


  Public Class FamilyExpectationReport


    Private m_familyAdapter As FamilyExpectationReportDataSetTableAdapters.FamilyExpectationTableAdapter
    Private m_expectationAdapter As FamilyExpectationReportDataSetTableAdapters.DropExpectationTableAdapter
    Private m_DataSet As FamilyExpectationReportDataSet


    ''' <summary>
    ''' DataSet
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Data() As FamilyExpectationReportDataSet
      Get
        Return m_DataSet
      End Get
    End Property


    Private ReadOnly Property FamilyExpectationAdapter() As FamilyExpectationReportDataSetTableAdapters.FamilyExpectationTableAdapter
      Get
        Return m_familyAdapter
      End Get
    End Property

    Private ReadOnly Property DropExpectationAdapter() As FamilyExpectationReportDataSetTableAdapters.DropExpectationTableAdapter
      Get
        Return m_expectationAdapter
      End Get
    End Property


    Public Sub New()

      m_DataSet = New FamilyExpectationReportDataSet
      m_familyAdapter = New FamilyExpectationReportDataSetTableAdapters.FamilyExpectationTableAdapter
      m_expectationAdapter = New FamilyExpectationReportDataSetTableAdapters.DropExpectationTableAdapter

    End Sub


    Public Sub Initialize()

      FamilyExpectationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      DropExpectationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

    End Sub

    ''' <summary>
    ''' Loads initial values into dataset.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadDataSet()
      Dim tradeclassAdapter As FamilyExpectationReportDataSetTableAdapters.TradeClassTableAdapter
      Dim retailerAdapter As FamilyExpectationReportDataSetTableAdapters.RetTableAdapter
      Dim marketAdapter As FamilyExpectationReportDataSetTableAdapters.MktTableAdapter


      tradeclassAdapter = New FamilyExpectationReportDataSetTableAdapters.TradeClassTableAdapter
      tradeclassAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      tradeclassAdapter.Fill(Data.TradeClass)
      tradeclassAdapter.Dispose()
      tradeclassAdapter = Nothing

      retailerAdapter = New FamilyExpectationReportDataSetTableAdapters.RetTableAdapter
      retailerAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      retailerAdapter.Fill(Data.Ret)
      retailerAdapter.Dispose()
      retailerAdapter = Nothing

      marketAdapter = New FamilyExpectationReportDataSetTableAdapters.MktTableAdapter
      marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      marketAdapter.Fill(Data.Mkt)
      marketAdapter.Dispose()
      marketAdapter = Nothing

    End Sub


    ''' <summary>
    ''' Loads markets for supplied retailer id.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadAllRetailers()
      Dim retailerAdapter As FamilyExpectationReportDataSetTableAdapters.RetTableAdapter


      retailerAdapter = New FamilyExpectationReportDataSetTableAdapters.RetTableAdapter
      retailerAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      retailerAdapter.Fill(Data.Ret)
      retailerAdapter.Dispose()
      retailerAdapter = Nothing

    End Sub

    ''' <summary>
    ''' Loads markets for supplied retailer id.
    ''' </summary>
    ''' <param name="tradeclassId"></param>
    ''' <remarks></remarks>
    Public Sub LoadRetailersByTradeclass(ByVal tradeclassId As Integer)
      Dim retailerAdapter As FamilyExpectationReportDataSetTableAdapters.RetTableAdapter


      retailerAdapter = New FamilyExpectationReportDataSetTableAdapters.RetTableAdapter
      retailerAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      retailerAdapter.FillByTradeclassId(Data.Ret, tradeclassId)
      retailerAdapter.Dispose()
      retailerAdapter = Nothing

    End Sub

    ''' <summary>
    ''' Loads all markets.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadAllMarkets()
      Dim marketAdapter As FamilyExpectationReportDataSetTableAdapters.MktTableAdapter


      marketAdapter = New FamilyExpectationReportDataSetTableAdapters.MktTableAdapter
      marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      marketAdapter.Fill(Data.Mkt)
      marketAdapter.Dispose()
      marketAdapter = Nothing

    End Sub

    ''' <summary>
    ''' Loads markets for supplied retailer id.
    ''' </summary>
    ''' <param name="retId"></param>
    ''' <remarks></remarks>
    Public Sub LoadMarketsByRetailer(ByVal retId As Integer)
      Dim marketAdapter As FamilyExpectationReportDataSetTableAdapters.MktTableAdapter


      marketAdapter = New FamilyExpectationReportDataSetTableAdapters.MktTableAdapter
      marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      marketAdapter.FillByRetId(Data.Mkt, retId)
      marketAdapter.Dispose()
      marketAdapter = Nothing

    End Sub

    ''' <summary>
    ''' Loads markets for supplied retailers falling under supplied tradeclassId.
    ''' </summary>
    ''' <param name="tradeclassId"></param>
    ''' <remarks></remarks>
    Public Sub LoadMarketsByTradeclass(ByVal tradeclassId As Integer)
      Dim marketAdapter As FamilyExpectationReportDataSetTableAdapters.MktTableAdapter


      marketAdapter = New FamilyExpectationReportDataSetTableAdapters.MktTableAdapter
      marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      marketAdapter.FillByTradeclassId(Data.Mkt, tradeclassId)
      marketAdapter.Dispose()
      marketAdapter = Nothing

    End Sub

    Public Function GetWeekNumber(ByVal targetDate As DateTime) As String
      Dim weekNo As String
      Dim weekNoCommand As System.Data.SqlClient.SqlCommand


      weekNoCommand = New System.Data.SqlClient.SqlCommand()
      weekNoCommand.CommandText = "SELECT dbo.WeekNoMondayStart(@pDate)"
      weekNoCommand.Parameters.Add("@pDate", SqlDbType.DateTime)
      weekNoCommand.Parameters("@pDate").Value = targetDate

      weekNoCommand.Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
      Try
        weekNoCommand.Connection.Open()
        weekNo = weekNoCommand.ExecuteScalar().ToString()
      Catch ex As Exception
        MessageBox.Show("An error has occured while calculating week number." _
                        , My.Application.Info.ProductName, MessageBoxButtons.OK _
                        , MessageBoxIcon.Error)
      Finally
        If weekNoCommand.Connection.State <> ConnectionState.Closed Then weekNoCommand.Connection.Close()
      End Try

      weekNoCommand.Connection.Dispose()
      weekNoCommand.Dispose()
      weekNoCommand = Nothing

      Return weekNo

    End Function

    ''' <summary>
    ''' Loads records from database based on supplied range of week numbers.
    ''' </summary>
    ''' <param name="startWeekNo"></param>
    ''' <param name="endWeekNo"></param>
    ''' <remarks></remarks>
    Public Sub LoadAllVehicles(ByVal startWeekNo As String, ByVal endWeekNo As String, ByVal tradeclassId As Nullable(Of Integer), ByVal retailerId As Nullable(Of Integer), ByVal marketId As Nullable(Of Integer))
            'FamilyExpectationAdapter.Adapter.SelectCommand.CommandTimeout = 180 '- to be updated 6
            Dim myDataAdapter As New FamilyExpectationReportDataSetTableAdapters.FamilyExpectationTableAdapter
            'myDataAdapter.CommandTimeout = 10000
            SetAllCommandTimeouts(FamilyExpectationAdapter, 60000)
            FamilyExpectationAdapter.FillByWeekNo(Data.FamilyExpectation, startWeekNo, endWeekNo, False, tradeclassId, retailerId, marketId)

    End Sub

    ''' <summary>
    ''' Loads records from database based on supplied range of dates.
    ''' </summary>
    ''' <param name="startDate"></param>
    ''' <param name="endDate"></param>
    ''' <remarks></remarks>
    Public Sub LoadAllVehicles(ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal tradeclassId As Nullable(Of Integer), ByVal retailerId As Nullable(Of Integer), ByVal marketId As Nullable(Of Integer))
            'FamilyExpectationAdapter.Adapter.SelectCommand.CommandTimeout = My.Settings.CommandTimeout '- to be updated 1
      FamilyExpectationAdapter.FillByDate(Data.FamilyExpectation, startDate, endDate, False, tradeclassId, retailerId, marketId)

    End Sub

    ''' <summary>
    ''' Loads records missing retailers from database based on supplied range of week numbers.
    ''' </summary>
    ''' <param name="startWeekNo"></param>
    ''' <param name="endWeekNo"></param>
    ''' <remarks></remarks>
    Public Sub LoadMissingVehicles(ByVal startWeekNo As String, ByVal endWeekNo As String, ByVal tradeclassId As Nullable(Of Integer), ByVal retailerId As Nullable(Of Integer), ByVal marketId As Nullable(Of Integer))
            'FamilyExpectationAdapter.Adapter.SelectCommand.CommandTimeout = My.Settings.CommandTimeout - to be updated 2
      FamilyExpectationAdapter.FillByWeekNo(Data.FamilyExpectation, startWeekNo, endWeekNo, True, tradeclassId, retailerid, marketId)

    End Sub

    ''' <summary>
    ''' Loads missing retailers from database based on supplied range of dates.
    ''' </summary>
    ''' <param name="startDate"></param>
    ''' <param name="endDate"></param>
    ''' <remarks></remarks>
    Public Sub LoadMissingVehicles(ByVal startDate As DateTime, ByVal endDate As DateTime, ByVal tradeclassId As Nullable(Of Integer), ByVal retailerId As Nullable(Of Integer), ByVal marketId As Nullable(Of Integer))
            'FamilyExpectationAdapter.Adapter.SelectCommand.CommandTimeout = My.Settings.CommandTimeout - to be updated 3
      FamilyExpectationAdapter.FillByDate(Data.FamilyExpectation, startDate, endDate, True, tradeclassId, retailerId, tradeclassId)

    End Sub

    ''' <summary>
    ''' Loads retailers with frequency as 1 per week, for week numbers it is not received in
    ''' , for any of the market it is associated with.
    ''' </summary>
    ''' <param name="startWeekNo"></param>
    ''' <param name="endWeekNo"></param>
    ''' <param name="tradeclassId"></param>
    ''' <param name="retailerId"></param>
    ''' <param name="marketId"></param>
    ''' <remarks></remarks>
    Public Sub LoadRetailersWithFrequency1PerWeek(ByVal startWeekNo As String, ByVal endWeekNo As String, ByVal tradeclassId As Nullable(Of Integer), ByVal retailerId As Nullable(Of Integer), ByVal marketId As Nullable(Of Integer))
            'DropExpectationAdapter.Adapter.SelectCommand.CommandTimeout = My.Settings.CommandTimeout - to be updated 4
      DropExpectationAdapter.Fill(Data.DropExpectation, startWeekNo, endWeekNo, True, tradeclassId, retailerId, marketId)

    End Sub

    ''' <summary>
    ''' Loads retailers with highest frequency for it, for week numbers it is not received in
    ''' , for any of the market it is associated with.
    ''' </summary>
    ''' <param name="startWeekNo"></param>
    ''' <param name="endWeekNo"></param>
    ''' <param name="tradeclassId"></param>
    ''' <param name="retailerId"></param>
    ''' <param name="marketId"></param>
    ''' <remarks></remarks>
    Public Sub LoadRetailersWithFrequencyInDB(ByVal startWeekNo As String, ByVal endWeekNo As String, ByVal tradeclassId As Nullable(Of Integer), ByVal retailerId As Nullable(Of Integer), ByVal marketId As Nullable(Of Integer))
            'DropExpectationAdapter.Adapter.SelectCommand.CommandTimeout = My.Settings.CommandTimeout - to be updated 5
      DropExpectationAdapter.Fill(Data.DropExpectation, startWeekNo, endWeekNo, False, tradeclassId, retailerId, marketId)

    End Sub

  End Class

End Namespace