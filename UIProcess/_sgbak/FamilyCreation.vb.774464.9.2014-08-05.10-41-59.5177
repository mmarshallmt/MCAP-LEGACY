Namespace UI.Processors


  Public Class FamilyCreation
    Inherits BaseClass



#Region " Events "


    'Events can be extended to supply necessary information to consumer along with events.
    'Information passed into event can be useful to consumer while processing the event.

    Public Event Initializing()
    Public Event Initialized()

    Public Event PreparingAdapter()
    Public Event AdapterPrepared()

    Public Event LoadingFamily()
    Public Event FamilyLoaded()
    Public Event FamilyNotFound()

    Public Event ValidatingInputs()
    Public Event InputsValidated()
    Public Event InvalidInputExist()

    Public Event InsertingFamily()
    Public Event FamilyInserted()

    Public Event SavingFamily()
    Public Event FamilySaved()

    Public Event RemovingFamily()
    Public Event FamilyRemoved()

    Public Event SynchronizingFamily()
    Public Event FamilySynchronized()


#End Region



    Private m_familyDataSet As FamilyDataSet
    Private m_vehicleAdapter As FamilyDataSetTableAdapters.vwCircularTableAdapter
    Private m_familyAdapter As FamilyDataSetTableAdapters.FamilyTableAdapter
    Private m_displayFamilyInformationAdapter As FamilyDataSetTableAdapters.DisplayFamilyInformationTableAdapter



    ''' <summary>
    ''' Gets instance of FamilyDataSet.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Data() As FamilyDataSet
      Get
        Return m_familyDataSet
      End Get
    End Property

    ''' <summary>
    ''' Gets family table adapter.
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
    ''' Gets vehicle table adapter.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property VehicleAdapter() As FamilyDataSetTableAdapters.vwCircularTableAdapter
      Get
        Return m_vehicleAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets family information to display in datagrid.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DisplayFamilyInformationAdapter() As FamilyDataSetTableAdapters.DisplayFamilyInformationTableAdapter
      Get
        Return m_displayFamilyInformationAdapter
      End Get
    End Property

    Public Function RetrieveYearMonth(ByVal _vehicleid As Integer) As String
      Dim cmd As System.Data.SqlClient.SqlCommand
      Dim obj As Object
      Dim dt As Date
      Dim FVal As String

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
    ''' Default constructor.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
      MyBase.New()
      m_familyDataSet = New FamilyDataSet()
      m_vehicleAdapter = New FamilyDataSetTableAdapters.vwCircularTableAdapter()
      m_familyAdapter = New FamilyDataSetTableAdapters.FamilyTableAdapter()
      m_displayFamilyInformationAdapter = New FamilyDataSetTableAdapters.DisplayFamilyInformationTableAdapter()
      m_vehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_familyAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_displayFamilyInformationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
    End Sub



    ''' <summary>
    ''' Initializes object of this class.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize()

      RaiseEvent Initializing()

      m_vehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_familyAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_displayFamilyInformationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

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
    ''' Gets name of the image file based on supplied vehicle Id and received order of the page.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="receivedOrder"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetImageFileName(ByVal vehicleId As Integer, ByVal receivedOrder As Integer) As String

      Return DisplayFamilyInformationAdapter.GetImageFileName(vehicleId, receivedOrder)

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
    ''' Loads families based on supplied retailer id, ad date and day range.
    ''' </summary>
    ''' <param name="adDate">Ad date</param>
    ''' <param name="mediaId">Media Id</param>
    ''' <param name="retId">Retailer Id</param>
    ''' <param name="dayRange">Number of days to match with Ad date. Default range is 3 days [-3,3].</param>
    ''' <remarks></remarks>
    Public Sub Load(ByVal adDate As DateTime, ByVal mediaId As Integer, ByVal retId As Integer, Optional ByVal dayRange As Integer = 3)

      DisplayFamilyInformationAdapter.Fill(Data.DisplayFamilyInformation, retId, mediaId, adDate, dayRange)

    End Sub


    ''' <summary>
    ''' Returns a blank DataRow associated with family DataTable.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateNew() As FamilyDataSet.FamilyRow

      Return Data.Family.NewFamilyRow()

    End Function

    ''' <summary>
    ''' Inserts record into family table in database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Add(ByVal newRow As FamilyDataSet.FamilyRow)

      Data.Family.AddFamilyRow(newRow)

    End Sub

    ''' <summary>
    ''' Save modified family information into database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save()

      RaiseEvent SynchronizingFamily()

      FamilyAdapter.Update(Data.Family)

      RaiseEvent FamilySynchronized()

    End Sub



  End Class


End Namespace