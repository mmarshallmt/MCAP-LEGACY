Namespace UI.Processors

  Public Class PublicationPull
    Inherits BaseClass



#Region " Events "


    Public Event LoadingVehicle(ByVal vehicleId As Integer)
    Public Event VehicleLoaded(ByVal vehicleRow As PublicationPullDataSet.vwPublicationEditionRow)
    Public Event VehicleNotFound(ByVal vehicleId As Integer)
    Public Event InvalidVehicleStatus(ByVal vehicleId As Integer, ByVal statusText As String)


#End Region


    Private m_marketAdapter As PublicationPullDataSetTableAdapters.MktTableAdapter
    Private m_publicationAdapter As PublicationPullDataSetTableAdapters.PublicationTableAdapter
    Private m_retailerAdapter As PublicationPullDataSetTableAdapters.RetTableAdapter
    Private m_vwPublicationEditionAdapter As PublicationPullDataSetTableAdapters.vwPublicationEditionTableAdapter
    Private m_publicationPullDataSet As PublicationPullDataSet



    Sub New()
      m_publicationPullDataSet = New PublicationPullDataSet
      m_marketAdapter = New PublicationPullDataSetTableAdapters.MktTableAdapter
      m_publicationAdapter = New PublicationPullDataSetTableAdapters.PublicationTableAdapter
      m_retailerAdapter = New PublicationPullDataSetTableAdapters.RetTableAdapter
      m_vwPublicationEditionAdapter = New PublicationPullDataSetTableAdapters.vwPublicationEditionTableAdapter
    End Sub



    Private ReadOnly Property MarketAdapter() As PublicationPullDataSetTableAdapters.MktTableAdapter
      Get
        Return m_marketAdapter
      End Get
    End Property

    Private ReadOnly Property PublicationAdapter() As PublicationPullDataSetTableAdapters.PublicationTableAdapter
      Get
        Return m_publicationAdapter
      End Get
    End Property

    Private ReadOnly Property RetailerAdapter() As PublicationPullDataSetTableAdapters.RetTableAdapter
      Get
        Return m_retailerAdapter
      End Get
    End Property

    Private ReadOnly Property VehicleAdapter() As PublicationPullDataSetTableAdapters.vwPublicationEditionTableAdapter
      Get
        Return m_vwPublicationEditionAdapter
      End Get
    End Property

    Public ReadOnly Property Data() As PublicationPullDataSet
      Get
        Return m_publicationPullDataSet
      End Get
    End Property



    Public Sub Initialize()
      m_marketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_publicationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_retailerAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_vwPublicationEditionAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
    End Sub



    ''' <summary>
    ''' Loads languages in Language datatable.
    ''' </summary>
    ''' <remarks></remarks>
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
    ''' Loads vehicle information vwPublicationEdition data table and other related data tables.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="formName">Name of the screen requensting for vehicle.</param>
    ''' <remarks></remarks>
    Public Sub LoadVehicle(ByVal vehicleId As Integer, ByVal formName As String)
      Dim errorMessage As String


      MarketAdapter.FillBy(Data.Mkt, vehicleId)
      PublicationAdapter.FillBy(Data.Publication, vehicleId)
      VehicleAdapter.Fill(Data.vwPublicationEdition, vehicleId, formName, errorMessage)
      If Data.vwPublicationEdition.Count = 0 And errorMessage Is Nothing Then
        RaiseEvent VehicleNotFound(vehicleId)
      ElseIf Data.vwPublicationEdition.Count = 0 And errorMessage IsNot Nothing Then
        RaiseEvent InvalidVehicleStatus(vehicleId, errorMessage)
      Else
        RaiseEvent VehicleLoaded(Data.vwPublicationEdition(0))
      End If

    End Sub

    ''' <summary>
    ''' Returns true if supplied media id is of Magazine, false otherwise.
    ''' </summary>
    ''' <param name="mediaId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsMediaMagazine(ByVal mediaId As Integer) As Boolean
      Dim magazineCount As Nullable(Of Integer)


      magazineCount = VehicleAdapter.IsMagazine(mediaId)

      If magazineCount Is Nothing OrElse magazineCount = 0 Then
        Return False
      Else
        Return True
      End If

    End Function

    ''' <summary>
    ''' Loads PT1 retailers into Ret data table, using RetPublicationCoverage table, based on 
    ''' supplied parameters.
    ''' </summary>
    ''' <param name="publicationId"></param>
    ''' <remarks></remarks>
    Public Sub LoadRetailers(ByVal publicationId As Integer)

      RetailerAdapter.Fill(Data.Ret, publicationId)

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
    ''' Returns statusId for supplied status text. Returns -1 if supplied status text not found.
    ''' </summary>
    ''' <param name="vehicleStatusText"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetVehicleStatusId(ByVal vehicleStatusText As String) As Integer
      Dim statusId As Nullable(Of Integer)


      statusId = VehicleAdapter.GetVehicleStatusId(vehicleStatusText)

      If statusId Is Nothing Then
        Return -1
      Else
        Return CType(statusId, Integer)
      End If

    End Function

    ''' <summary>
    ''' Removes vehicle from database.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="formName"></param>
    ''' <remarks></remarks>
    Public Sub Delete(ByVal vehicleId As Integer, ByVal formName As String)
      Dim vehicleQuery As System.Data.EnumerableRowCollection(Of PublicationPullDataSet.vwPublicationEditionRow)


      vehicleQuery = From r In Data.vwPublicationEdition _
                     Where r.VehicleId = vehicleId _
                     Select r

      If vehicleQuery.Count() = 1 Then
        vehicleQuery(0).Delete()
        Synchronize(formName)
      End If

      vehicleQuery = Nothing

    End Sub

    ''' <summary>
    ''' Updates vehicle information in database based on supplied vwPublicationEdition data table.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Synchronize(ByVal formName As String)
      Dim tempTable As Data.DataTable
      Dim vehicleId As Integer


      tempTable = Data.vwPublicationEdition.GetChanges(DataRowState.Added Or DataRowState.Modified)

      VehicleAdapter.Update(Data.vwPublicationEdition)

      If tempTable IsNot Nothing Then
        For i As Integer = 0 To tempTable.Rows.Count - 1
          vehicleId = CType(tempTable.Rows(i).Item("VehicleId").ToString(), Integer)
          VehicleAdapter.UpdatePublicationPages(vehicleId, formName)
          VehicleAdapter.UpdatePullDt(vehicleId)
        Next

        tempTable.Dispose()
      End If

      tempTable = Nothing

    End Sub


  End Class

End Namespace