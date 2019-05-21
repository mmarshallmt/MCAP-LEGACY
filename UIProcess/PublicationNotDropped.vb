Namespace UI.Processors

  Public Class PublicationNotDropped
    Inherits BaseClass



#Region " Events "

    Public Event LoadingPublications As MCAPCancellableEventHandler
    Public Event PublicationsLoaded As MCAPEventHandler

    Public Event LoadingPublishedOnDays As MCAPCancellableEventHandler
    Public Event PublishedOnDaysLoaded As MCAPEventHandler

    Public Event ValidatingInformation As MCAPCancellableEventHandler
    Public Event InformationValidated As MCAPEventHandler
    Public Event InvalidInformationFound As MCAPEventHandler

    Public Event SavingPublicationNotDroppedInformation As MCAPCancellableEventHandler
    Public Event PublicationNotDroppedInformationSaved As MCAPEventHandler

#End Region



    Private m_dataSet As MCAP.PublicationNotDroppedDataSet



    Sub New()

      m_dataSet = New MCAP.PublicationNotDroppedDataSet()

    End Sub



    ''' <summary>
    ''' Gets dataset for publication not dropped.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Data() As MCAP.PublicationNotDroppedDataSet
      Get
        Return m_dataSet
      End Get
    End Property



    Private Sub LoadAllMarkets()
      Dim mktAdapter As MCAP.PublicationNotDroppedDataSetTableAdapters.MktTableAdapter


      mktAdapter = New MCAP.PublicationNotDroppedDataSetTableAdapters.MktTableAdapter()
      mktAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      mktAdapter.Fill(Data.Mkt)
      mktAdapter.Dispose()

    End Sub

    Private Sub LoadPublicationsForMarket(ByVal marketId As Integer)
      Dim publicationAdapter As MCAP.PublicationNotDroppedDataSetTableAdapters.PublicationTableAdapter


      publicationAdapter = New MCAP.PublicationNotDroppedDataSetTableAdapters.PublicationTableAdapter()
      publicationAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      publicationAdapter.Fill(Data.Publication, marketId)
      publicationAdapter.Dispose()

    End Sub

    Private Sub LoadPublishedOnDays(ByVal publicationId As Integer)
      Dim publishedOnAdapter As PublicationNotDroppedDataSetTableAdapters.PublishedOnTableAdapter


      publishedOnAdapter = New PublicationNotDroppedDataSetTableAdapters.PublishedOnTableAdapter()
      publishedOnAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      publishedOnAdapter.Fill(Data.PublishedOn, publicationId)
      publishedOnAdapter.Dispose()
      publishedOnAdapter = Nothing

    End Sub

    Private Sub LoadPublicationNotReceived(ByVal marketId As Integer, ByVal publicationId As Integer, ByVal breakDt As DateTime)
      Dim tempAdapter As PublicationNotDroppedDataSetTableAdapters.PublicationNotDroppedTableAdapter


      tempAdapter = New PublicationNotDroppedDataSetTableAdapters.PublicationNotDroppedTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      tempAdapter.FillByPublication(Data.PublicationNotDropped, marketId, publicationId, breakDt)
      tempAdapter.Dispose()
      tempAdapter = Nothing

    End Sub

    Private Function IsPublicationAlreadyExist(ByVal marketId As Integer, ByVal publicationId As Integer, ByVal breakDt As DateTime) As Boolean
      Dim publicationCount As Integer?
      Dim tempAdapter As PublicationNotDroppedDataSetTableAdapters.PublicationNotDroppedTableAdapter


      tempAdapter = New PublicationNotDroppedDataSetTableAdapters.PublicationNotDroppedTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      publicationCount = tempAdapter.GetPublicationCount(marketId, publicationId, breakDt)
      tempAdapter.Dispose()
      tempAdapter = Nothing

      Return (publicationCount.HasValue AndAlso publicationCount.Value > 0)

    End Function

    ''' <summary>
    ''' Returns true if publication with supplied parameters exist in vwPublicationEdition, false otherwise.
    ''' </summary>
    ''' <param name="marketId"></param>
    ''' <param name="publicationId"></param>
    ''' <param name="breakDt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsPublicationValid(ByVal marketId As Integer, ByVal publicationId As Integer, ByVal breakDt As DateTime) As Boolean
      Dim isValid As Boolean
      Dim tempAdapter As PublicationNotDroppedDataSetTableAdapters.vwPublicationEditionTableAdapter


      tempAdapter = New PublicationNotDroppedDataSetTableAdapters.vwPublicationEditionTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      tempAdapter.Fill(Data.vwPublicationEdition, marketId, publicationId, breakDt)
      isValid = (Data.vwPublicationEdition.Count = 0)
      tempAdapter.Dispose()
      tempAdapter = Nothing

      Return isValid
    End Function

    ''' <summary>
    ''' Validates column values and sets column and row error text.
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Private Sub ValidateDataRow(ByVal row As PublicationNotDroppedDataSet.PublicationNotDroppedRow)

      row.ClearErrors()

      If row.IsNull("MktId") OrElse row.MktId < 0 Then
        row.SetColumnError("MktId", "Market cannot be blank.")
      End If

      If row.IsNull("PublicationId") OrElse row.PublicationId < 0 Then
        row.SetColumnError("PublicationId", "Publication cannot be blank.")
      End If

      If row.IsNull("BreakDt") OrElse row.BreakDt > System.DateTime.Today Then
        row.SetColumnError("BreakDt", "Break date cannot be blank or a future date.")
      End If

      If IsPublicationAlreadyExist(row.MktId, row.PublicationId, row.BreakDt) Then
        row.RowError = "Publication already marked as No Drop."
      End If

      If IsPublicationValid(row.MktId, row.PublicationId, row.BreakDt) = False Then
        row.RowError = "Vehicle(s) with same publication exist."
      End If

    End Sub


    Public Function GetPublicationCheckedInByUserName(ByVal marketId As Integer, ByVal publicationId As Integer, ByVal breakDt As DateTime) As String
      Dim userName As String
      Dim tempAdapter As PublicationNotDroppedDataSetTableAdapters.PublicationNotDroppedTableAdapter


      tempAdapter = New PublicationNotDroppedDataSetTableAdapters.PublicationNotDroppedTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      userName = tempAdapter.GetCheckedInByUserName(marketId, publicationId, breakDt)
      tempAdapter.Dispose()
      tempAdapter = Nothing

      Return userName
    End Function

    Public Sub LoadDataSet()

      LoadAllMarkets()

    End Sub

    ''' <summary>
    ''' Loads publications for supplied market.
    ''' </summary>
    ''' <param name="marketId"></param>
    ''' <remarks></remarks>
    Public Sub LoadPublications(ByVal marketId As Integer)

      Using e As CancellableEventArgs = New CancellableEventArgs()
        RaiseEvent LoadingPublications(Me, e)
      End Using

      LoadPublicationsForMarket(marketId)

      Using e As EventArgs = New EventArgs()
        RaiseEvent PublicationsLoaded(Me, e)
      End Using

    End Sub

    ''' <summary>
    ''' Loads week day information on which the supplied publication is published.
    ''' </summary>
    ''' <param name="publicationId">Id of the publication.</param>
    ''' <remarks></remarks>
    Public Sub LoadPublicationDays(ByVal publicationId As Integer)

      Using e As CancellableEventArgs = New CancellableEventArgs()
        RaiseEvent LoadingPublishedOnDays(Me, e)
      End Using

      LoadPublishedOnDays(publicationId)

      Using e As CancellableEventArgs = New CancellableEventArgs()
        RaiseEvent PublishedOnDaysLoaded(Me, e)
      End Using

    End Sub

    Public Sub LoadPublicationNotDropped(ByVal marketId As Integer, ByVal publicationId As Integer, ByVal breakDt As DateTime)

      LoadPublicationNotReceived(marketId, publicationId, breakDt)

    End Sub

    ''' <summary>
    ''' Gets boolean flag, indicating whether supplied date is a valid publication day or not.
    ''' </summary>
    ''' <param name="publicationDate">Date to be checked for validity.</param>
    ''' <remarks></remarks>
    Public Function IsPublicationDayValid(ByVal publicationDate As DateTime) As Boolean
      Dim dowQuery As System.Collections.Generic.IEnumerable(Of PublicationNotDroppedDataSet.PublishedOnRow)


      dowQuery = From dr In Data.PublishedOn _
                 Select dr _
                 Where dr.DOW = publicationDate.DayOfWeek + 1

      IsPublicationDayValid = (dowQuery.Count > 0)

      dowQuery = Nothing

    End Function

    ''' <summary>
    ''' Returns true if vehicle with supplied parameters exist in vwPublicationEdition, false otherwise.
    ''' </summary>
    ''' <param name="marketId"></param>
    ''' <param name="publicationId"></param>
    ''' <param name="breakDt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsPublicationReceived(ByVal marketId As Integer, ByVal publicationId As Integer, ByVal breakDt As DateTime) As Boolean
      Dim isValid As Boolean

      isValid = IsPublicationValid(marketId, publicationId, breakDt)

      Return isValid
    End Function

    ''' <summary>
    ''' Validate column values in supplied row. In case of any error, error text is added into the 
    ''' row itself as column error or row error.
    ''' </summary>
    ''' <param name="row"></param>
    ''' <remarks></remarks>
    Public Sub Validate(ByVal row As PublicationNotDroppedDataSet.PublicationNotDroppedRow)

      Using e As CancellableEventArgs = New CancellableEventArgs()
        RaiseEvent ValidatingInformation(Me, e)
      End Using

      ValidateDataRow(row)

      If row.HasErrors Then
        Using e As CancellableEventArgs = New CancellableEventArgs()
          e.Data.Add("Row", row)
          RaiseEvent InvalidInformationFound(Me, e)
        End Using
      Else
        Using e As CancellableEventArgs = New CancellableEventArgs()
          RaiseEvent InformationValidated(Me, e)
        End Using
      End If

    End Sub

    ''' <summary>
    ''' Synchronizes row values with database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save()
      Dim rowsAffected As Integer
      Dim tempAdapter As PublicationNotDroppedDataSetTableAdapters.PublicationNotDroppedTableAdapter


      Using e As CancellableEventArgs = New CancellableEventArgs()
        RaiseEvent SavingPublicationNotDroppedInformation(Me, e)
      End Using

      tempAdapter = New PublicationNotDroppedDataSetTableAdapters.PublicationNotDroppedTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      rowsAffected = tempAdapter.Update(Data.PublicationNotDropped)
      tempAdapter.Dispose()
      tempAdapter = Nothing

      Using e As CancellableEventArgs = New CancellableEventArgs()
        e.Data.Add("RowsAffected", rowsAffected)
        RaiseEvent PublicationNotDroppedInformationSaved(Me, e)
      End Using

    End Sub


  End Class

End Namespace