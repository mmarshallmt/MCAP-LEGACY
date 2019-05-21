Namespace UI.Processors

  Public Class Resequence
    Inherits BaseClass



#Region " Events "


    'Events can be extended to supply necessary information to consumer along with events.
    'Information passed into event can be useful to consumer while processing the event.
    Public Event Initializing()
    Public Event Initialized()

    Public Event PreparingAdapter()
    Public Event AdapterPrepared()

    Public Event LoadingPageInformation()
    Public Event PageInformationLoaded()

    Public Event LoadingPageSizes()
    Public Event PageSizesLoaded()

    Public Event SynchronizingPagesInformation()
    Public Event PagesInformationSynchronized()


#End Region


    Private m_pagesAdapter As ResequenceDataSetTableAdapters.PageTableAdapter
    Private m_pageSizeAdapter As ResequenceDataSetTableAdapters.SizeTableAdapter
    Private m_resequenceDataSet As ResequenceDataSet



    Sub New()

      m_resequenceDataSet = New ResequenceDataSet
      m_pagesAdapter = New ResequenceDataSetTableAdapters.PageTableAdapter
      m_pageSizeAdapter = New ResequenceDataSetTableAdapters.SizeTableAdapter

    End Sub



    ''' <summary>
    ''' Gets instance of PageAdapter for Page table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property PageAdapter() As ResequenceDataSetTableAdapters.PageTableAdapter
      Get
        Return m_pagesAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets instance of SizeAdapter for Size table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property PageSizeAdapter() As ResequenceDataSetTableAdapters.SizeTableAdapter
      Get
        Return m_pageSizeAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets instance of resequence data set.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DataSet() As ResequenceDataSet
      Get
        Return m_resequenceDataSet
      End Get
    End Property



    ''' <summary>
    ''' Initializes this instance.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize()

      RaiseEvent Initializing()

      PageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      PageSizeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      RaiseEvent Initialized()

    End Sub


    ''' <summary>
    ''' Loads pages information for supplied vehicle id and list of all sizes from size table.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Public Sub LoadDataSet(ByVal vehicleId As Integer)

      RaiseEvent LoadingPageSizes()

      m_pageSizeAdapter.Fill(DataSet.Size)

      RaiseEvent PageSizesLoaded()

      RaiseEvent LoadingPageInformation()

      m_pagesAdapter.Fill(DataSet.Page, vehicleId)

      RaiseEvent PageInformationLoaded()

    End Sub

    ''' <summary>
    ''' Returns row from Page table having ImageName same as parameter value.
    ''' </summary>
    ''' <param name="imageName"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' If multiple rows are found with same imageName, it returns row with minimum received order.
    ''' </remarks>
    Public Function GetImageInformation(ByVal imageName As String) As ResequenceDataSet.PageRow
      Dim tempView As System.Data.DataView
      Dim pgRow As ResequenceDataSet.PageRow


      tempView = New System.Data.DataView(DataSet.Page)
      tempView.RowFilter = "ImageFileName='" + imageName.Replace("'", "''") + "'"

      If tempView.Count = 0 Then Return Nothing
      pgRow = CType(tempView(0).Row, ResequenceDataSet.PageRow)

      tempView.Dispose()
      tempView = Nothing

      Return pgRow

    End Function

    ''' <summary>
    ''' Updates receivedOrder column in Page DataTable based on images in list.
    ''' </summary>
    ''' <remarks></remarks>
        Public Sub UpdatePageSequence(ByVal resequencedImageNames() As String, ByVal originalRow() As ResequenceDataSet.PageRow)
            Dim rowCounter As Integer
            Dim tempRow As ResequenceDataSet.PageRow
            Dim tempPageName(resequencedImageNames.Length - 1) As String
            Dim tempPageTypeId(resequencedImageNames.Length - 1) As String

            'Dim originalRow As ResequenceDataSet.PageRow

            'For rowCounter = 0 To resequencedImageNames.Length - 1
            '    tempRow = GetImageInformation(resequencedImageNames(rowCounter))
            '    tempRow.BeginEdit()
            '    tempRow.ReceivedOrder = (rowCounter + 1)
            '    tempRow.EndEdit()
            '    tempRow = Nothing
            'Next

            For rowCounter = 0 To resequencedImageNames.Length - 1
                tempPageName(rowCounter) = originalRow(rowCounter).PageName.ToString()
                tempPageTypeId(rowCounter) = originalRow(rowCounter).PageTypeId.ToString()
            Next

            For rowCounter = 0 To resequencedImageNames.Length - 1
                tempRow = GetImageInformation(resequencedImageNames(rowCounter))

                tempRow.BeginEdit()
                tempRow.PageName = tempPageName(rowCounter) 'originalRow(rowCounter).PageName.ToString() '16163832 
                tempRow.ReceivedOrder = (rowCounter + 1)
                tempRow.PageTypeId = tempPageTypeId(rowCounter) 'originalRow(rowCounter).PageTypeId.ToString()
                tempRow.EndEdit()
                tempRow = Nothing
            Next


        End Sub

    ''' <summary>
    ''' Synchronizes page information in Page table based on Page datatable.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SynchronizePageInformation()

      RaiseEvent SynchronizingPagesInformation()

      PageAdapter.Update(DataSet.Page)

      RaiseEvent PagesInformationSynchronized()

    End Sub

        Public Sub UpdateAllBlankImageName(ByVal _vehicleid As Integer)


            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim adpt As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet

            cmd = New System.Data.SqlClient.SqlCommand
            con = New System.Data.SqlClient.SqlConnection

            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()

            cmd.Connection = con

            cmd.CommandType = CommandType.Text

            cmd.CommandText = "Update page Set ImageName = null where ImageName = '' and VehicleId=" + _vehicleid.ToString

            cmd.ExecuteNonQuery()

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

        End Sub
  End Class

End Namespace