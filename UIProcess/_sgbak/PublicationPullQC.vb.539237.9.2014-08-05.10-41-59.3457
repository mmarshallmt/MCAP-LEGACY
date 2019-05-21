Namespace UI.Processors

  Public Class PublicationPullQC
    Inherits BaseClass


#Region " Event "

    Public Event LoadingVehicle(ByVal vehicleId As Integer)
    Public Event VehicleLoaded(ByVal vehicleRow As PublicationPullDataSet.vwPublicationEditionRow)
    Public Event VehicleNotFound(ByVal vehicleId As Integer)
    'Public Event InvalidVehicleForPullQC(ByVal vehicleId As Integer)
    Public Event InvalidVehicleStatus(ByVal vehicleId As Integer, ByVal statusText As String)

#End Region


    Private m_expectationAdapter As PublicationPullDataSetTableAdapters.RetTableAdapter
    Private m_vehicleAdapter As PublicationPullDataSetTableAdapters.vwPublicationEditionTableAdapter
    Private m_publicationPullQCAdapter As PublicationPullDataSetTableAdapters.PublicationPullQCTableAdapter
    Private m_publicationPullDataSet As PublicationPullDataSet



    ''' <summary>
    ''' Adapter for vwPublicationEdition view.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property VehicleAdapter() As PublicationPullDataSetTableAdapters.vwPublicationEditionTableAdapter
      Get
        Return m_vehicleAdapter
      End Get
    End Property

    ''' <summary>
    ''' Adapter for Ret view.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ExpectedRetailerAdapter() As PublicationPullDataSetTableAdapters.RetTableAdapter
      Get
        Return m_expectationAdapter
      End Get
    End Property

    ''' <summary>
    ''' Adapter for PublicationPullQC table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PullQCAdapter() As PublicationPullDataSetTableAdapters.PublicationPullQCTableAdapter
      Get
        Return m_publicationPullQCAdapter
      End Get
    End Property

    ''' <summary>
    ''' Instance of PublicationPullDataSet
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Data() As PublicationPullDataSet
      Get
        Return m_publicationPullDataSet
      End Get
    End Property



    Public Sub New()

      m_publicationPullDataSet = New PublicationPullDataSet
      m_expectationAdapter = New PublicationPullDataSetTableAdapters.RetTableAdapter
      m_vehicleAdapter = New PublicationPullDataSetTableAdapters.vwPublicationEditionTableAdapter
      m_publicationPullQCAdapter = New PublicationPullDataSetTableAdapters.PublicationPullQCTableAdapter

    End Sub



    Public Sub Initialize()

      m_expectationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_vehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_publicationPullQCAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

    End Sub


    Public Sub LoadDataSet()
      Dim languageAdapter As PublicationPullDataSetTableAdapters.LanguageTableAdapter
      Dim userAdapter As PublicationPullDataSetTableAdapters.UserTableAdapter


      languageAdapter = New PublicationPullDataSetTableAdapters.LanguageTableAdapter
      userAdapter = New PublicationPullDataSetTableAdapters.UserTableAdapter

      languageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      userAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      languageAdapter.Fill(Data.Language)
      userAdapter.Fill(Data.User)

      languageAdapter.Dispose()
      userAdapter.Dispose()

      languageAdapter = Nothing
      userAdapter = Nothing
    End Sub


    ''' <summary>
    ''' Loads valid markets for supplied envelope id.
    ''' </summary>
    ''' <param name="senderId"></param>
    ''' <remarks></remarks>
    Public Sub LoadMarkets(ByVal senderId As Integer)
      Dim marketAdapter As PublicationPullDataSetTableAdapters.MktTableAdapter


      marketAdapter = New PublicationPullDataSetTableAdapters.MktTableAdapter
      marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      marketAdapter.FillBySenderId(Data.Mkt, senderId)

      marketAdapter.Dispose()
      marketAdapter = Nothing
    End Sub

    ''' <summary>
    ''' Loads publications based on supplied market id.
    ''' </summary>
    ''' <param name="marketId"></param>
    ''' <remarks></remarks>
    Public Sub LoadPublicationsFor(ByVal marketId As Integer)
      Dim publicationAdapter As PublicationPullDataSetTableAdapters.PublicationTableAdapter


      publicationAdapter = New PublicationPullDataSetTableAdapters.PublicationTableAdapter

      publicationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      publicationAdapter.Fill(Data.Publication, marketId)

      publicationAdapter.Dispose()
      publicationAdapter = Nothing
    End Sub

    ''' <summary>
    ''' Loads expected retailers for supplied media and market.
    ''' </summary>
    ''' <param name="mediaId"></param>
    ''' <param name="mktId"></param>
    ''' <remarks></remarks>
    Public Sub LoadExpectedRetailers(ByVal publicationId As Integer)

      ExpectedRetailerAdapter.Fill(Data.Ret, publicationId)

    End Sub

    ''' <summary>
    ''' Loads vehicle and list of expected retailers. If vehicle is already QCed for pulled, 
    ''' also loads list of missing retailers.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Public Sub LoadVehicle(ByVal vehicleId As Integer, ByVal formName As String)
      Dim errorMessage As String


      VehicleAdapter.FillForPullQC(Data.vwPublicationEdition, vehicleId, formName, errorMessage)
      PullQCAdapter.Fill(Data.PublicationPullQC, vehicleId)

      If Data.vwPublicationEdition.Count = 0 And errorMessage Is Nothing Then
        RaiseEvent VehicleNotFound(vehicleId)
      ElseIf Data.vwPublicationEdition.Count = 0 And errorMessage IsNot Nothing Then
        RaiseEvent InvalidVehicleStatus(vehicleId, errorMessage)
        'ElseIf IsValidForPullQC(Data.vwPublicationEdition(0)) = False Then
        '  RaiseEvent InvalidVehicleForPullQC(vehicleId)
      Else
        RaiseEvent VehicleLoaded(Data.vwPublicationEdition(0))
      End If

    End Sub

    ''' <summary>
    ''' Loads week day information on which the supplied publication is published.
    ''' </summary>
    ''' <param name="publicationId">Id of the publication.</param>
    ''' <remarks></remarks>
    Public Sub LoadPublicationDays(ByVal publicationId As Integer)
      Dim publishedOnAdapter As PublicationPullDataSetTableAdapters.PublishedOnTableAdapter


      publishedOnAdapter = New PublicationPullDataSetTableAdapters.PublishedOnTableAdapter()
      publishedOnAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      publishedOnAdapter.Fill(Data.PublishedOn, publicationId)

      publishedOnAdapter.Dispose()
      publishedOnAdapter = Nothing
    End Sub

    ''' <summary>
    ''' Gets boolean flag, indicating whether supplied date is a valid publication day or not.
    ''' </summary>
    ''' <param name="publicationDate">Date to be checked for validity.</param>
    ''' <remarks></remarks>
    Public Function IsPublicationDayValid(ByVal publicationDate As DateTime) As Boolean
      Dim dowQuery As System.Collections.Generic.IEnumerable(Of PublicationPullDataSet.PublishedOnRow)


      dowQuery = From dr In Data.PublishedOn _
                 Select dr _
                 Where dr.DOW = publicationDate.DayOfWeek + 1

      IsPublicationDayValid = (dowQuery.Count > 0)

      dowQuery = Nothing

    End Function


    ''' <summary>
    ''' Sets status Id as QCed in supplied vehicle datarow.
    ''' </summary>
    ''' <param name="vehicleRow"></param>
    ''' <exception cref="System.ApplicationException">Raises exception if vehicle status with description 'QC Completed' is not found.</exception>
    ''' <remarks></remarks>
    Public Sub SetStatusIdAsQCed(ByVal vehicleRow As PublicationPullDataSet.vwPublicationEditionRow)
      Dim statusId As Nullable(Of Integer)


      statusId = VehicleAdapter.GetVehicleStatusId("Pull QCed")

      If statusId Is Nothing Then
        Throw New ApplicationException("Unable to mark vehicle as QCed for Pull.")
        Exit Sub
      End If

      vehicleRow.StatusID = CType(statusId, Integer)

      statusId = Nothing
    End Sub

    ''' <summary>
    ''' Updates information in vwPublicationEdition as per the information in supplied dataset.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateVehicle(ByVal formName As String)
      Dim tam As PublicationPullDataSetTableAdapters.TableAdapterManager
      Dim tempTable As Data.DataTable
      Dim vehicleId As Integer


      tempTable = Data.vwPublicationEdition.GetChanges(DataRowState.Added Or DataRowState.Modified)

      tam = New PublicationPullDataSetTableAdapters.TableAdapterManager
      tam.BackupDataSetBeforeUpdate = True
      tam.vwPublicationEditionTableAdapter = Me.VehicleAdapter
      tam.PublicationPullQCTableAdapter = Me.PullQCAdapter

      tam.UpdateAll(Me.Data)

      tam.Dispose()
      tam = Nothing

      If tempTable IsNot Nothing Then
        For i As Integer = 0 To tempTable.Rows.Count - 1
          vehicleId = CType(tempTable.Rows(i).Item("VehicleId").ToString(), Integer)
          VehicleAdapter.UpdatePublicationPages(vehicleId, formName)
          VehicleAdapter.UpdatePullQCDt(vehicleId)
        Next

        tempTable.Dispose()
      End If

      tempTable = Nothing

    End Sub

  End Class

End Namespace