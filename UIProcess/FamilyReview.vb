Namespace UI.Processors

  Public Class FamilyReview
    Inherits BaseClass


#Region " Events "


    'Events can be extended to supply necessary information to consumer along with events.
    'Information passed into event can be useful to consumer while processing the event.

    Public Event Initializing()
    Public Event Initialized()

    Public Event LoadingFamilyInformation()
    Public Event FamilyInformationLoaded()

    Public Event ValidatingInputs()
    Public Event InputsValidated()
    Public Event InvalidInputExist()

    Public Event InsertingFamilyInformation()
    Public Event FamilyInformationInserted()

    Public Event SavingFamilyInformation()
    Public Event FamilyInformationSaved()

    Public Event RemovingFamilyInformation()
    Public Event FamilyInformationRemoved()

    Public Event SynchronizingFamilyInformation()
    Public Event FamilyInformationSynchronized()


#End Region


    Private m_familyReviewDataSet As FamilyDataSet
    Private m_priorityAdapter As FamilyDataSetTableAdapters.vwPriorityTableAdapter
    Private m_tradeclassAdapter As FamilyDataSetTableAdapters.TradeClassTableAdapter
    Private m_retailerAdapter As FamilyDataSetTableAdapters.RetTableAdapter
    Private m_mediaAdapter As FamilyDataSetTableAdapters.MediaTableAdapter
    Private m_familyAdapter As FamilyDataSetTableAdapters.FamilyTableAdapter
    Private m_displayFamilyAdapter As FamilyDataSetTableAdapters.DisplayFamilyInformationTableAdapter


    Sub New()
      m_familyReviewDataSet = New FamilyDataSet
      m_priorityAdapter = New FamilyDataSetTableAdapters.vwPriorityTableAdapter
      m_tradeclassAdapter = New FamilyDataSetTableAdapters.TradeClassTableAdapter
      m_retailerAdapter = New FamilyDataSetTableAdapters.RetTableAdapter
      m_mediaAdapter = New FamilyDataSetTableAdapters.MediaTableAdapter
      m_familyAdapter = New FamilyDataSetTableAdapters.FamilyTableAdapter
      m_displayFamilyAdapter = New FamilyDataSetTableAdapters.DisplayFamilyInformationTableAdapter
    End Sub


    ''' <summary>
    ''' Gets TableAdapter for Code/CodeType tables.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PriorityAdapter() As FamilyDataSetTableAdapters.vwPriorityTableAdapter
      Get
        Return m_priorityAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets TableAdapter for Media table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property MediaAdapter() As FamilyDataSetTableAdapters.MediaTableAdapter
      Get
        Return m_mediaAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets TableAdapter for Tradeclass.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TradeclassAdapter() As FamilyDataSetTableAdapters.TradeClassTableAdapter
      Get
        Return m_tradeclassAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets TableAdapter for Ret.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RetailerAdapter() As FamilyDataSetTableAdapters.RetTableAdapter
      Get
        Return m_retailerAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets FamilyAdapter for Family.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FamilyAdapter() As FamilyDataSetTableAdapters.FamilyTableAdapter
      Get
        Return m_familyAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets TableAdapter for DisplayFamily DataTable.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DisplayFamilyAdapter() As FamilyDataSetTableAdapters.DisplayFamilyInformationTableAdapter
      Get
        Return m_displayFamilyAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets instance of FamilyReviewDataSet.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Data() As FamilyDataSet
      Get
        Return m_familyReviewDataSet
      End Get
    End Property



    ''' <summary>
    ''' Initializes object of this class.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize()

      RaiseEvent Initializing()

      PriorityAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      MediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      TradeclassAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      RetailerAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      FamilyAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      DisplayFamilyAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      RaiseEvent Initialized()

    End Sub

    ''' <summary>
    ''' Fills media table with existing media types and adds one dummy media 'All'.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FillMedia()
            Dim tempRow As FamilyDataSet.MediaRow

            'MediaAdapter.Fill(Data.Media)

            tempRow = Data.Media.NewMediaRow()
            tempRow.MediaID = -2
            tempRow.Descrip = "All Circulars"
            Data.Media.AddMediaRow(tempRow)

            tempRow = Data.Media.NewMediaRow()
            tempRow.MediaID = 7
            tempRow.Descrip = "ROP"
            Data.Media.AddMediaRow(tempRow)

            tempRow = Data.Media.NewMediaRow()
            tempRow.MediaID = 11
            tempRow.Descrip = "ROP - Circular"
            Data.Media.AddMediaRow(tempRow)






            tempRow = Nothing


    End Sub

    ''' <summary>
    ''' Clears Ret DataTable and fills in retailer records having NULL in EndDt column.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FillRetailers()

      RetailerAdapter.Fill(Data.Ret)

    End Sub


    ''' <summary>
    ''' Clears Ret DataTable and fills in records with supplied tradeclass Id and having NULL in EndDt column.
    ''' </summary>
    ''' <param name="tradeclassId">Tradeclass Id to filter list of retailers.</param>
    ''' <remarks></remarks>
    Public Sub FilterRetailersByTradeclass(ByVal tradeclassId As Integer)

      RetailerAdapter.FillByTradeclassId(Data.Ret, tradeclassId)

    End Sub

    Public Function RetrieveYearMonth(ByVal _vehicleid As Integer) As String
      Dim cmd As System.Data.SqlClient.SqlCommand
      Dim obj As Object
      Dim dt As Date
      Dim FVal As String = ""

      cmd = New System.Data.SqlClient.SqlCommand

      Try
        With cmd
          .CommandText = "Select CreateDt from Vehicle where VehicleId = " & _vehicleid
          .CommandType = CommandType.Text
          .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
          .Connection.Open()
          obj = .ExecuteScalar()
        End With

        If obj Is Nothing Then
          obj = "NULL"
        Else
          dt = CType(obj, Date)
          FVal = dt.ToString("yyyyMM")
        End If
      Catch ex As Exception
        My.Application.Log.WriteException(ex)
      Finally
        If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
      End Try

      Return FVal
    End Function
    ''' <summary>
    ''' Gets boolean flag indicating whether vehicle page images are scanned or not.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AreVehiclePageImagesScanned(ByVal vehicleId As Integer) As Boolean
      Dim count As Integer?
      Dim tempAdapter As MCAP.FamilyDataSetTableAdapters.vwCircularTableAdapter


      tempAdapter = New MCAP.FamilyDataSetTableAdapters.vwCircularTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      count = tempAdapter.AreVehiclePagesScanned(vehicleId)
      If count.HasValue = False OrElse count.Value = 0 Then
        Return False
      Else
        Return True
      End If

    End Function

    ''' <summary>
    ''' Gets boolean flag indicating whether vehicle page images are transferred or not.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="locationId"></param>
    ''' <returns></returns>
    ''' <remarks>This boolean flag checked location of the scanned user against current application user.</remarks>
    Public Function AreVehicleImagesTransferred(ByVal vehicleId As Integer, ByVal locationId As Integer) As Boolean
      Dim count As Object
      Dim tempAdapter As MCAP.FamilyDataSetTableAdapters.vwCircularTableAdapter


      tempAdapter = New MCAP.FamilyDataSetTableAdapters.vwCircularTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      count = tempAdapter.AreVehicleImagesTransferred(locationId, vehicleId)
      If count Is Nothing OrElse count.ToString() = "0" Then
        Return True
      Else
        Return False
      End If

    End Function

    ''' <summary>
    ''' Loads records satisfying supplied parameters.
    ''' </summary>
    ''' <param name="retId"></param>
    ''' <param name="mediaId"></param>
    ''' <param name="breakDate"></param>
    ''' <param name="dayRange"></param>
    ''' <param name="showReviewed"></param>
    ''' <remarks></remarks>
        Public Sub Load(ByVal retId As Integer, ByVal mediaId As Integer, ByVal breakDate As DateTime, ByVal dayRange As Integer, ByVal showReviewed As Boolean)

            RaiseEvent LoadingFamilyInformation()

            If retId = 0 And mediaId = 0 Then
                If showReviewed Then
                    DisplayFamilyAdapter.GetTableFamilyData(Data.DisplayFamilyInformation, breakDate, dayRange)
                Else
                    DisplayFamilyAdapter.GetTableFillNonReviewed(Data.DisplayFamilyInformation, breakDate, dayRange)
                End If
            ElseIf retId = 0 And mediaId <> 0 Then
                If showReviewed Then
                    DisplayFamilyAdapter.GetTableFamilyDataByMediaId(Data.DisplayFamilyInformation, breakDate, dayRange, mediaId)
                Else
                    DisplayFamilyAdapter.GetTableFillNonReviewedByMediaId(Data.DisplayFamilyInformation, breakDate, dayRange, mediaId)
                End If
            ElseIf retId > 0 And mediaId = 0 Then
                If showReviewed Then
                    DisplayFamilyAdapter.GetTableFamilyDataByRetId(Data.DisplayFamilyInformation, breakDate, dayRange, retId)
                Else
                    DisplayFamilyAdapter.GetTableFillNonReviewedByRetId(Data.DisplayFamilyInformation, retId, breakDate, dayRange)
                End If
            Else
                If showReviewed Then
                    Try
                        DisplayFamilyAdapter.ClearBeforeFill = True
                        DisplayFamilyAdapter.Fill(Data.DisplayFamilyInformation, retId, mediaId, breakDate, dayRange)
                    Catch ex As ConstraintException
                        MsgBox(ex.ToString)
                    End Try

                Else
                    DisplayFamilyAdapter.FillNonReviewed(Data.DisplayFamilyInformation, retId, mediaId, breakDate, dayRange)
                End If
            End If

            RaiseEvent FamilyInformationLoaded()

        End Sub


    ''' <summary>
    ''' Loads records satisfying supplied parameters.
    ''' </summary>
    ''' <param name="retId"></param>
    ''' <param name="mediaId"></param>
    ''' <param name="breakDate"></param>
    ''' <param name="priorityId"></param>
    ''' <param name="dayRange"></param>
    ''' <param name="showReviewed"></param>
    ''' <remarks></remarks>
    Public Sub Load(ByVal retId As Integer, ByVal mediaId As Integer?, ByVal breakDate As DateTime, ByVal priorityId As Integer, ByVal dayRange As Integer, ByVal showReviewed As Boolean)

      RaiseEvent LoadingFamilyInformation()

      If showReviewed Then
        DisplayFamilyAdapter.FillByPriority(Data.DisplayFamilyInformation, priorityId, retId, mediaId, breakDate, dayRange)
      Else
        DisplayFamilyAdapter.FillNonReviewedByPriority(Data.DisplayFamilyInformation, priorityId, retId, mediaId, breakDate, dayRange)
      End If

      RaiseEvent FamilyInformationLoaded()

    End Sub


    ''' <summary>
    ''' Loads pages information, from page table, for supplied vehicleId.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Public Sub LoadPagesInformation(ByVal vehicleId As Integer)
      Dim tempAdapter As FamilyDataSetTableAdapters.PageTableAdapter


      tempAdapter = New FamilyDataSetTableAdapters.PageTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      tempAdapter.FillByVehicleId(Data.Page, vehicleId)

      tempAdapter.Dispose()
      tempAdapter = Nothing

    End Sub


    ''' <summary>
    ''' Gets vehicle image name from Page table based on vehicle Id and received order.
    ''' </summary>
    ''' <param name="vehicleId">Vehicle Id</param>
    ''' <param name="receivedOrder">Received Order</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetVehicleImageFileName(ByVal vehicleId As Integer, ByVal receivedOrder As Integer) As String

      Return DisplayFamilyAdapter.GetImageFileName(vehicleId, receivedOrder)

    End Function


    ''' <summary>
    ''' Updates ReviewDt and ReviewById columns in Family table for a family Id.
    ''' </summary>
    ''' <param name="familyId">Family Id to be updated.</param>
    ''' <param name="formName">Form name to be set in column.</param>
    ''' <remarks></remarks>
    Public Sub MarkFamilyAsReviewed(ByVal familyId As Integer, ByVal formName As String)

      FamilyAdapter.MarkFamilyAsReviewed(UserID, formName, familyId)

    End Sub


    ''' <summary>
    ''' Merges two families and removed one of them from database.
    ''' </summary>
    ''' <param name="familyId">Family Id</param>
    ''' <param name="removeFamilyId">Family Id to be removed from database.</param>
    ''' <remarks></remarks>
    Public Sub MergeFamilies(ByVal familyId As Integer, ByVal removeFamilyId As Integer, ByVal formName As String)

      FamilyAdapter.MergeFamilies(familyId, formName, removeFamilyId)

    End Sub

        ''' <summary>
        ''' Returns vehicle row of the supplied vehicle id.
        ''' </summary>
        ''' <param name="vehicleId">Vehicle Id</param>
        ''' <remarks></remarks>
        Public Sub FindVehicle(ByVal vehicleId As Integer, ByRef RetId As String, ByRef AdDate As String)
            Dim errorMessage As String

            'Get RetId and date from Vehicle
            'Assume we want to keep Media as All Circulars

            Dim ConnectionString As String
            Dim Connection As SqlClient.SqlConnection
            Dim Adapter As SqlClient.SqlDataAdapter
            Dim VehicleResultset As DataSet

            ConnectionString = GetConnectionStringForAppDB()


            Connection = New SqlClient.SqlConnection(ConnectionString)
            Connection.Open()

            Adapter = New SqlClient.SqlDataAdapter("select RetId, BreakDt from Vehicle where VehicleId=" + vehicleId.ToString(), ConnectionString)

            VehicleResultset = New DataSet()

            Adapter.Fill(VehicleResultset)

            If VehicleResultset.Tables(0).Rows.Count > 0 Then

                RetId = VehicleResultset.Tables(0).Rows(0).Item(0).ToString()
                AdDate = VehicleResultset.Tables(0).Rows(0).Item(1).ToString()

            End If

            If Connection.State = ConnectionState.Open Then Connection.Close()


        End Sub

  End Class

End Namespace
