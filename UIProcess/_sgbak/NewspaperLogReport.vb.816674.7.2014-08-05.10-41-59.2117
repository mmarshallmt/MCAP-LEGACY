Namespace UI.Processors

  Public Class NewspaperLogReport


    Private m_NewspaperLogReportData As System.Data.DataSet


    Public ReadOnly Property Data() As System.Data.DataSet
      Get
        Return m_NewspaperLogReportData
      End Get
    End Property


    Sub New()

      m_NewspaperLogReportData = New System.Data.DataSet

    End Sub


    Public Sub Initialize()

    End Sub

    ''' <summary>
    ''' Loads tables from which, during screen lifetime, all rows are required, like master tables 
    ''' or tables which doesn't need to be fetched again and again based on user action/input. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadDataSet()
      Dim userAdapter As System.Data.SqlClient.SqlDataAdapter
      Dim userCommand As System.Data.SqlClient.SqlCommand


      userAdapter = New System.Data.SqlClient.SqlDataAdapter()
            userCommand = New System.Data.SqlClient.SqlCommand("SELECT UserId, FName + ' ' + LName [FullName] FROM [User] WHERE ActiveInd=1 AND IndHideUser=0 order by fname,lname")

      userCommand.Connection = New System.Data.SqlClient.SqlConnection()
      userCommand.Connection.ConnectionString = GetConnectionStringForAppDB()
      userCommand.CommandType = CommandType.Text
      userAdapter.SelectCommand = userCommand
      userAdapter.Fill(Data, "User")

      userCommand.Connection.Dispose()
      userCommand.Dispose()
      userAdapter.Dispose()
      userCommand = Nothing
      userAdapter = Nothing
    End Sub


    ''' <summary>
    ''' Fetches data from mt_proc_NewspaperLogReport_Missing stored procedure using supplied arguments.
    ''' </summary>
    ''' <param name="vehicleStatus"></param>
    ''' <param name="filterYear"></param>
    ''' <param name="filterMonth"></param>
    ''' <returns></returns>
    Public Function GetReportData_Missing(ByVal vehicleStatus As String, ByVal filterYear As Integer, ByVal filterMonth As Integer) As System.Data.DataSet
      'Dim filterYear, filterMonth As Integer
      'Dim vehicleStatus As String
      Dim exportDataSet As Data.DataSet
      Dim fetchConn As System.Data.SqlClient.SqlConnection
      Dim selectCommand As Data.SqlClient.SqlCommand
      Dim adapter As Data.SqlClient.SqlDataAdapter


      'filterYear = 2008 : filterMonth = 6 : vehicleStatus = "Pulled"

      fetchConn = New System.Data.SqlClient.SqlConnection()
      selectCommand = New System.Data.SqlClient.SqlCommand()
      adapter = New Data.SqlClient.SqlDataAdapter()
      exportDataSet = New System.Data.DataSet("ExportData")

      fetchConn.ConnectionString = GetConnectionStringForAppDB()
      With selectCommand
        .Connection = fetchConn
        .CommandType = CommandType.StoredProcedure
        .CommandText = "mt_proc_NewspaperLogReport_Missing"
        .Parameters.Add("@pVehicleStatus", SqlDbType.VarChar, 25).Value = vehicleStatus
        .Parameters.Add("@pYear", SqlDbType.Int).Value = filterYear
        .Parameters.Add("@pMonth", SqlDbType.Int).Value = filterMonth
      End With

      adapter.SelectCommand = selectCommand

      Try
        adapter.Fill(exportDataSet)

      Catch ex As Exception
                MessageBox.Show(ex.Message)

            Finally
                If fetchConn.State <> ConnectionState.Open Then fetchConn.Close()
                fetchConn.Dispose()
                selectCommand.Dispose()
                adapter.Dispose()
                fetchConn = Nothing
                selectCommand = Nothing
                adapter = Nothing
            End Try

            Return exportDataSet

        End Function

        ''' <summary>
        ''' Fetches data from mt_proc_NewspaperLogReport_BreakDateWise stored procedure using supplied arguments.
        ''' </summary>
        ''' <param name="vehicleStatus"></param>
        ''' <param name="filterYear"></param>
        ''' <param name="filterMonth"></param>
        ''' <returns></returns>
        ''' <remarks>If there exist no data, function returns dataSet with zero tables.</remarks>
        Public Function GetReportData_BreakDateWise(ByVal vehicleStatus As String, ByVal filterYear As Integer, ByVal filterMonth As Integer) As System.Data.DataSet
            'Dim filterYear, filterMonth As Integer
            'Dim vehicleStatus As String
            Dim exportDataSet As Data.DataSet
            Dim fetchConn As System.Data.SqlClient.SqlConnection
            Dim selectCommand As Data.SqlClient.SqlCommand
            Dim adapter As Data.SqlClient.SqlDataAdapter


            'filterYear = 2008 : filterMonth = 6 : vehicleStatus = "Pulled"

            fetchConn = New System.Data.SqlClient.SqlConnection()
            selectCommand = New System.Data.SqlClient.SqlCommand()
            selectCommand.CommandTimeout = My.Settings.CommandTimeout
            adapter = New Data.SqlClient.SqlDataAdapter()
            exportDataSet = New System.Data.DataSet("ExportData")

            fetchConn.ConnectionString = GetConnectionStringForAppDB()
            With selectCommand
                .Connection = fetchConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "mt_proc_NewspaperLogReport_BreakDateWise"
                .Parameters.Add("@pVehicleStatus", SqlDbType.VarChar, 25).Value = vehicleStatus
                .Parameters.Add("@pYear", SqlDbType.Int).Value = filterYear
                .Parameters.Add("@pMonth", SqlDbType.Int).Value = filterMonth
            End With

            adapter.SelectCommand = selectCommand

            Try
                adapter.Fill(exportDataSet)

            Catch ex As Exception
                MessageBox.Show(ex.Message)

            Finally
                If fetchConn.State <> ConnectionState.Open Then fetchConn.Close()
                fetchConn.Dispose()
                selectCommand.Dispose()
                adapter.Dispose()
                fetchConn = Nothing
                selectCommand = Nothing
                adapter = Nothing
            End Try

            Return exportDataSet

        End Function

        ''' <summary>
        ''' Fetches data from mt_proc_NewspaperLogReport_LogDateWise stored procedure using supplied arguments.
        ''' </summary>
        ''' <param name="vehicleStatus"></param>
        ''' <param name="filterYear"></param>
        ''' <param name="filterMonth"></param>
        ''' <param name="filterDay"></param>
        ''' <param name="filterUserId"></param>
        ''' <returns></returns>
        ''' <remarks>If there exist no data, function returns dataSet with zero tables.</remarks>
        Public Function GetReportData_LogDateWise _
            (ByVal vehicleStatus As String, ByVal filterYear As Integer, ByVal filterMonth As Integer _
             , ByVal filterDay As Nullable(Of Integer), ByVal filterUserId As Nullable(Of Integer)) _
            As System.Data.DataSet
            'Dim filterYear, filterMonth As Integer
            'Dim filterDay, filterUserId As Nullable(Of Integer)
            'Dim vehicleStatus As String
            Dim exportDataSet As Data.DataSet
            Dim fetchConn As System.Data.SqlClient.SqlConnection
            Dim selectCommand As Data.SqlClient.SqlCommand
            Dim adapter As Data.SqlClient.SqlDataAdapter


            'filterYear = 2008 : filterMonth = 6 : filterDay = Nothing : filterUserId = 1 : vehicleStatus = "Pulled"

            fetchConn = New System.Data.SqlClient.SqlConnection()
            selectCommand = New System.Data.SqlClient.SqlCommand()
            selectCommand.CommandTimeout = My.Settings.CommandTimeout
            adapter = New Data.SqlClient.SqlDataAdapter()
            exportDataSet = New System.Data.DataSet("ExportData")

            fetchConn.ConnectionString = GetConnectionStringForAppDB()
            With selectCommand
                .Connection = fetchConn
                .CommandType = CommandType.StoredProcedure
                .CommandText = "mt_proc_NewspaperLogReport_LogDateWise"
                .Parameters.Add("@pVehicleStatus", SqlDbType.VarChar, 25).Value = vehicleStatus
                .Parameters.Add("@pYear", SqlDbType.Int).Value = filterYear
                .Parameters.Add("@pMonth", SqlDbType.Int).Value = filterMonth
                .Parameters.Add("@pDay", SqlDbType.Int).Value = filterDay
                .Parameters.Add("@pUserId", SqlDbType.Int).Value = filterUserId
            End With

            adapter.SelectCommand = selectCommand

            Try
                adapter.Fill(exportDataSet)

            Catch ex As Exception
                MessageBox.Show(ex.Message)

            Finally
                If fetchConn.State <> ConnectionState.Open Then fetchConn.Close()
                fetchConn.Dispose()
                selectCommand.Dispose()
                adapter.Dispose()
                fetchConn = Nothing
                selectCommand = Nothing
                adapter = Nothing
            End Try

            Return exportDataSet

        End Function


  End Class

End Namespace