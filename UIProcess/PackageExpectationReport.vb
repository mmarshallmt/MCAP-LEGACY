﻿

Namespace UI.Processors

    Public Class PackageExpectationReport

        Private m_DataSet As PackageExpectationReportDataSet
        Private m_packageAdapter As PackageExpectationReportDataSetTableAdapters.PackageReceivedTableAdapter
        Private m_marketAdapter As PackageExpectationReportDataSetTableAdapters.MktTableAdapter
        Dim mktClicked As Boolean
        Dim sndrClicked As Boolean

        Private ReadOnly Property PackageExpectationAdapter() As PackageExpectationReportDataSetTableAdapters.PackageReceivedTableAdapter
            Get
                Return m_packageAdapter
            End Get
        End Property

        Public ReadOnly Property MktAdapter() As PackageExpectationReportDataSetTableAdapters.MktTableAdapter
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
        Public ReadOnly Property Data() As PackageExpectationReportDataSet
            Get
                Return m_DataSet
            End Get
        End Property



        Public Sub New()

            m_DataSet = New PackageExpectationReportDataSet
            m_packageAdapter = New PackageExpectationReportDataSetTableAdapters.PackageReceivedTableAdapter
            mktClicked = False
            sndrClicked = False


        End Sub



        Public Sub Initialize()

            PackageExpectationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

        End Sub
        ''' <summary>
        ''' Loads initial values into dataset.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadSender()
            Dim senderAdapter As PackageExpectationReportDataSetTableAdapters.SenderTableAdapter
            Dim SenderRow As PackageExpectationReportDataSet.SenderRow
            senderAdapter = New PackageExpectationReportDataSetTableAdapters.SenderTableAdapter
            senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            senderAdapter.Fill(Data.Sender)
            senderAdapter.Dispose()
            SenderRow = Data.Sender.NewSenderRow
            SenderRow.SenderId = -1
            SenderRow.Name = "All"
            Data.Sender.AddSenderRow(SenderRow)
            senderAdapter = Nothing
        End Sub

        Public Sub reLoadSender(ByVal marketId As Integer)

            Dim senderAdapter As PackageExpectationReportDataSetTableAdapters.SenderTableAdapter

            senderAdapter = New PackageExpectationReportDataSetTableAdapters.SenderTableAdapter
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
            Dim marketAdapter As PackageExpectationReportDataSetTableAdapters.MktTableAdapter

            marketAdapter = New PackageExpectationReportDataSetTableAdapters.MktTableAdapter
            Dim MarketRow As PackageExpectationReportDataSet.MktRow
            marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            marketAdapter.Fill(Data.Mkt)
            marketAdapter.Dispose()

            MarketRow = Data.Mkt.NewMktRow
            MarketRow.MktId = -1
            MarketRow.Descrip = "All"
            Data.Mkt.AddMktRow(MarketRow)

            MarketRow = Nothing
            marketAdapter = Nothing
        End Sub

        Public Sub reLoadMarket(ByVal senderId As Integer)

            Dim marketAdapter As PackageExpectationReportDataSetTableAdapters.MktTableAdapter

            marketAdapter = New PackageExpectationReportDataSetTableAdapters.MktTableAdapter
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
            Dim locationAdapter As PackageExpectationReportDataSetTableAdapters.vwLocationTableAdapter

            locationAdapter = New PackageExpectationReportDataSetTableAdapters.vwLocationTableAdapter
            locationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            locationAdapter.Fill(Data.vwLocation)
            locationAdapter.Dispose()
            locationAdapter = Nothing

            'Adding dummy location for option - "Both"
            Dim tempRow As PackageExpectationReportDataSet.vwLocationRow


            tempRow = Data.vwLocation.NewvwLocationRow()
            tempRow.CodeId = -2 'DO NOT CHANGE THIS. This value is hardcoded in mt_proc_PackageExpectationReport_PackageReceived storedprocedure.
            tempRow.Descrip = "Both"
            Data.vwLocation.AddvwLocationRow(tempRow)
            Data.vwLocation.AcceptChanges()

            tempRow = Nothing
        End Sub


    End Class

End Namespace