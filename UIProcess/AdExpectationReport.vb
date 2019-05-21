Namespace UI.Processors

    Public Class AdExpectationReport

        Private m_DataSet As ExpectationReportDataSet
        Private m_adAdapter As ExpectationReportDataSetTableAdapters.AdReceivedTableAdapter
        Private m_marketAdapter As ExpectationReportDataSetTableAdapters.MktTableAdapter
        Dim mktClicked As Boolean
        Dim sndrClicked As Boolean

        Private ReadOnly Property AdExpectationAdapter() As ExpectationReportDataSetTableAdapters.AdReceivedTableAdapter
            Get
                Return m_adAdapter
            End Get
        End Property

        Public ReadOnly Property MktAdapter() As ExpectationReportDataSetTableAdapters.MktTableAdapter
            Get
                Return m_marketAdapter
            End Get
        End Property

        ''' <summary>
        ''' DataSet
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Data() As ExpectationReportDataSet
            Get
                Return m_DataSet
            End Get
        End Property



        Public Sub New()

            m_DataSet = New ExpectationReportDataSet
            m_adAdapter = New ExpectationReportDataSetTableAdapters.AdReceivedTableAdapter
            mktClicked = False
            sndrClicked = False


        End Sub



        Public Sub Initialize()

            AdExpectationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

        End Sub
        ''' <summary>
        ''' Loads initial values into dataset.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadSender()
            Dim senderAdapter As ExpectationReportDataSetTableAdapters.SenderTableAdapter
            senderAdapter = New ExpectationReportDataSetTableAdapters.SenderTableAdapter
            senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            senderAdapter.Fill(Data.Sender)
            senderAdapter.Dispose()
            senderAdapter = Nothing
        End Sub

        Public Sub reLoadSender(ByVal marketId As Integer)

            Dim senderAdapter As ExpectationReportDataSetTableAdapters.SenderTableAdapter

            senderAdapter = New ExpectationReportDataSetTableAdapters.SenderTableAdapter
            senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            senderAdapter.FillBy(Data.Sender, marketId)
            senderAdapter.Dispose()
            senderAdapter = Nothing


        End Sub

        ''' <summary>
        ''' Loads initial values into dataset.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadMarket()
            Dim marketAdapter As ExpectationReportDataSetTableAdapters.MktTableAdapter

            marketAdapter = New ExpectationReportDataSetTableAdapters.MktTableAdapter
            marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            marketAdapter.Fill(Data.Mkt)
            marketAdapter.Dispose()
            marketAdapter = Nothing
        End Sub

        Public Sub reLoadMarket(ByVal senderId As Integer)

            Dim marketAdapter As ExpectationReportDataSetTableAdapters.MktTableAdapter

            marketAdapter = New ExpectationReportDataSetTableAdapters.MktTableAdapter
            marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            marketAdapter.FillBy(Data.Mkt, senderId)
            marketAdapter.Dispose()
            marketAdapter = Nothing

        End Sub


        ''' <summary>
        ''' Loads initial values into dataset.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadLocation()
            Dim locationAdapter As ExpectationReportDataSetTableAdapters.vwLocationTableAdapter

            locationAdapter = New ExpectationReportDataSetTableAdapters.vwLocationTableAdapter
            locationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            locationAdapter.Fill(Data.vwLocation)
            locationAdapter.Dispose()
            locationAdapter = Nothing

            'Adding dummy location for option - "Both"
            Dim tempRow As ExpectationReportDataSet.vwLocationRow


            tempRow = Data.vwLocation.NewvwLocationRow()
            tempRow.CodeId = -2 'DO NOT CHANGE THIS. This value is hardcoded in mt_proc_PackageExpectationReport_PackageReceived storedprocedure.
            tempRow.Descrip = "Both"
            Data.vwLocation.AddvwLocationRow(tempRow)
            Data.vwLocation.AcceptChanges()
        End Sub


        Public Sub LoadPriority()
            Dim priorityAdapter As ExpectationReportDataSetTableAdapters.PriorityTableAdapter
            priorityAdapter = New ExpectationReportDataSetTableAdapters.PriorityTableAdapter
            priorityAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            priorityAdapter.Fill(Data.Priority)
            priorityAdapter.Dispose()
            priorityAdapter = Nothing
        End Sub

        Public Sub LoadMedia()
            Dim mediaAdapter As ExpectationReportDataSetTableAdapters.MediaTableAdapter
            mediaAdapter = New ExpectationReportDataSetTableAdapters.MediaTableAdapter
            mediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            mediaAdapter.Fill(Data.Media)
            mediaAdapter.Dispose()
            mediaAdapter = Nothing
        End Sub

        Public Sub LoadEntryProject()
            Dim entryprojectAdapter As ExpectationReportDataSetTableAdapters.entryprojectTableAdapter
            entryprojectAdapter = New ExpectationReportDataSetTableAdapters.entryprojectTableAdapter
            entryprojectAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            entryprojectAdapter.Fill(Data.entryproject)
            entryprojectAdapter.Dispose()
            entryprojectAdapter = Nothing
        End Sub

        Public Sub LoadFrequency()
            Dim frequencyAdapter As ExpectationReportDataSetTableAdapters.vwFrequencyTableAdapter
            frequencyAdapter = New ExpectationReportDataSetTableAdapters.vwFrequencyTableAdapter
            frequencyAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            frequencyAdapter.Fill(Data.vwFrequency)
            frequencyAdapter.Dispose()
            frequencyAdapter = Nothing
        End Sub
    End Class

End Namespace
