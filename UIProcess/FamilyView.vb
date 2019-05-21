Namespace UI.Processors

  Public Class FamilyView
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


    Private m_familyViewDataSet As FamilyDataSet
    Private m_familyAdapter As FamilyDataSetTableAdapters.FamilyTableAdapter
    Private m_vwCircularAdapter As FamilyDataSetTableAdapters.vwCircularTableAdapter
    Private m_displayFamilyAdapter As FamilyDataSetTableAdapters.DisplayFamilyInformationTableAdapter



    Sub New()
      m_familyViewDataSet = New FamilyDataSet
      m_familyAdapter = New FamilyDataSetTableAdapters.FamilyTableAdapter
      m_vwCircularAdapter = New FamilyDataSetTableAdapters.vwCircularTableAdapter
      m_displayFamilyAdapter = New FamilyDataSetTableAdapters.DisplayFamilyInformationTableAdapter
    End Sub



    ''' <summary>
    ''' Gets TableAdapter for family table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FamilyAdapter() As FamilyDataSetTableAdapters.FamilyTableAdapter
      Get
        Return m_familyAdapter
      End Get
    End Property
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
    ''' Gets table adapter for vehicle adapter.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property VehicleAdapter() As FamilyDataSetTableAdapters.vwCircularTableAdapter
      Get
        Return m_vwCircularAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets TableAdapter for displayFamily DataTable.
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
    ''' Gets instance of FamilyViewDataSet.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Data() As FamilyDataSet
      Get
        Return m_familyViewDataSet
      End Get
    End Property



    ''' <summary>
    ''' Initializes object of this class.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize()

      RaiseEvent Initializing()

      FamilyAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      VehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      DisplayFamilyAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      RaiseEvent Initialized()

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
    ''' Gets boolean flag indicating whether vehicle page images are scanned or not.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AreVehiclePageImagesScanned(ByVal vehicleId As Integer) As Boolean
      Dim count As Integer?


      count = VehicleAdapter.AreVehiclePagesScanned(vehicleId)
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


      count = VehicleAdapter.AreVehicleImagesTransferred(locationId, vehicleId)
      If count Is Nothing OrElse count.ToString() = "0" Then
        Return True
      Else
        Return False
      End If

    End Function

    ''' <summary>
    ''' Loads all vehicles having family same as family of the vehicle whose Id is supplied.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Public Sub Load(ByVal vehicleId As Integer)

      DisplayFamilyAdapter.FillByVehicleId(Data.DisplayFamilyInformation, vehicleId)

    End Sub

    ''' <summary>
    ''' Gets retailer name of supplied vehicle id.
    ''' </summary>
    ''' <param name="vehicleId">Vehicle Id.</param>
    ''' <remarks></remarks>
    Public Function GetRetailerName(ByVal vehicleId As Integer) As String
      Dim retailerName As Object


      retailerName = DisplayFamilyAdapter.GetRetailerName(vehicleId)

      If retailerName Is Nothing Or retailerName Is DBNull.Value Then
        Return Nothing
      Else
        Return retailerName.ToString()
      End If

    End Function

    ''' <summary>
    ''' Updates ReviewDt and ReviewedById columns of Family table for supplied FamilyId.
    ''' </summary>
    ''' <param name="familyId">Family Id to be marked as Reviewd.</param>
    ''' <param name="formName">Form name to be set in column.</param>
    ''' <remarks></remarks>
    Public Sub MarkFamilyAsReviewed(ByVal familyId As Integer, ByVal formName As String)

      FamilyAdapter.MarkFamilyAsReviewed(UserID, formName, familyId)

    End Sub

    ''' <summary>
    ''' Gets new family Id. 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetNewFamily(ByVal formName As String) As Integer
      Dim familyId As Integer
      Dim familyRow As FamilyDataSet.FamilyRow


      familyRow = Data.Family.NewFamilyRow()
      'familyRow.CreateDt = System.DateTime.Now()
      familyRow.FormName = formName
      Data.Family.AddFamilyRow(familyRow)
      FamilyAdapter.Update(Data.Family)

      familyId = familyRow.FamilyId

      familyRow = Nothing

      Return familyId

    End Function

    ''' <summary>
    ''' Sets family id to supplied vehicles.
    ''' </summary>
    ''' <param name="familyId"></param>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Public Sub SplitFamily(ByVal familyId As Integer, ByVal formName As String, ByVal vehicleId() As Integer)
      Dim vehicleCounter As Integer


      For vehicleCounter = 0 To vehicleId.Length - 1
        VehicleAdapter.SetFamilyId(familyId, formName, vehicleId(vehicleCounter))
      Next

    End Sub

        Public Function LockFamily(ByVal familyid As Integer, ByVal isLocked As Integer) As Integer
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "UPDATE Family SET LockInd = " + isLocked.ToString + " where FamilyId = " + familyid.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteNonQuery()

                    Return CType(obj, Integer)
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
                Return 0
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try
        End Function

        Public Function setAltMasterId(ByVal VehicleID As Integer, ByVal altmasterid As Integer) As Integer
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "UPDATE Vehicle SET AltMasterInd = " + altmasterid.ToString + " where vehicleId = " + VehicleID.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Function

        Public Function GetFlashInd(ByVal vehicleId As String) As Integer
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As New Object
            Dim _val As Integer

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "Select FlashInd from Vehicle where vehicleid='" + vehicleId + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With
                If String.IsNullOrEmpty(CType(obj, String)) = False Then _val = CType(obj, Integer)
            Catch ex As Exception
                Throw New ApplicationException("Unable to get the FlashInd Id.", ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return _val
        End Function

        Public Function UpdateFamily(ByVal familyid As Integer, ByVal adtypeid As Integer, ByVal addistid As Integer, ByVal durentryind As Integer, ByVal conentryind As Integer, ByVal compareind As Integer) As Integer
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "UPDATE Family SET AdTypeId = " + adtypeid.ToString + ", AdDistId = " + addistid.ToString + ", DurEntryInd = " + durentryind.ToString + ", ConEntryInd = " + conentryind.ToString + ", CompareInd = " + compareind.ToString + " where FamilyId = " + familyid.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteNonQuery()

                    Return CType(obj, Integer)
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
                Return 0
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try
        End Function

    End Class

    

End Namespace