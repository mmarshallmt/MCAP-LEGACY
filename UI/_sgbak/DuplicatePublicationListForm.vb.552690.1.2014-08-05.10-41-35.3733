Public Class DuplicatePublicationListForm



  Private m_duplicatePublicationTable As PublicationCheckInDataSet.DuplicatePublicationDataTable



  ''' <summary>
  ''' Gets data table containing list of possible duplicate publications.
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public ReadOnly Property DuplicatePublications() As PublicationCheckInDataSet.DuplicatePublicationDataTable
    Get
      Return m_duplicatePublicationTable
    End Get
    'Set(ByVal value As PublicationCheckInDataSet.DuplicatePublicationDataTable)
    '  m_duplicatePublicationTable = value
    'End Set
  End Property



  ''' <summary>
  ''' Initialize form and all required objects. 
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub Init()

    m_duplicatePublicationTable = New PublicationCheckInDataSet.DuplicatePublicationDataTable()

  End Sub

  ''' <summary>
  ''' Loads list of possible duplicate publications already received and recorded in MCAP.
  ''' </summary>
  ''' <param name="marketId">Market for which the publication is published.</param>
  ''' <param name="publicationId">Publisher of the Publication received.</param>
  ''' <param name="breakDt">Date on which publication is recorded in MCAP.</param>
  ''' <param name="vehicleId">While updating existing publication, it's vehicle Id is supplied to avoid considering itself as duplicate publication. This parameter is ignored while recording new publication. </param>
  ''' <param name="senderId">This parameter is supplied to load possible duplicate publications received from a particular sender only.</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function LoadDuplicatePublications(ByVal marketId As Integer, ByVal publicationId As Integer, ByVal breakDt As DateTime, ByVal vehicleId As Integer?, ByVal senderId As Integer?) As Integer
    Dim duplicateRows As Integer
    Dim tempAdapter As PublicationCheckInDataSetTableAdapters.DuplicatePublicationTableAdapter


    If m_duplicatePublicationTable Is Nothing Then Init()

    tempAdapter = New PublicationCheckInDataSetTableAdapters.DuplicatePublicationTableAdapter()
    tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

    If vehicleId.HasValue = False And senderId.HasValue = False Then
      tempAdapter.FillByMktPubBreakDt(m_duplicatePublicationTable, marketId, breakDt, publicationId)
    ElseIf vehicleId.HasValue And senderId.HasValue = False Then
      tempAdapter.FillByVehicleMktPubBreakDt(m_duplicatePublicationTable, marketId, breakDt, publicationId, vehicleId.Value)
    ElseIf vehicleId.HasValue And senderId.HasValue = False Then
      tempAdapter.FillBySenderMktPubBreakDt(m_duplicatePublicationTable, senderId.Value, marketId, publicationId, breakDt)
    Else
      tempAdapter.FillByVehicleSenderMktPubBreakDt(m_duplicatePublicationTable, senderId.Value, marketId, publicationId, breakDt, vehicleId.Value)
    End If

    tempAdapter.Dispose()
    tempAdapter = Nothing

    duplicateRows = Me.DuplicatePublications.Count


    Return duplicateRows

  End Function

  ''' <summary>
  ''' Returns true if publication is received from same sender, false otherwise.
  ''' </summary>
  ''' <param name="senderId"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function IsPublicationReceivedFromSameSender(ByVal senderId As Integer) As Boolean
    Dim isPublication As Boolean
    Dim publicationQuery As System.Collections.Generic.IEnumerable(Of PublicationCheckInDataSet.DuplicatePublicationRow)


    publicationQuery = From p In Me.DuplicatePublications _
                       Select p _
                       Where p.SenderId = senderId

    isPublication = (publicationQuery.Count() > 0)

    publicationQuery = Nothing

    Return isPublication

  End Function

  ''' <summary>
  ''' Prepares data grid and display duplicate publications in data grid.
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub ShowDuplicatePublicationsInDataGridView()

    duplicateDataGridView.DataSource = Me.DuplicatePublications
    PrepareDataGridView()

  End Sub


  ''' <summary>
  ''' Clears all existing columns and recreates columns in DataGridView and set their properties.
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub PrepareDataGridView()
    Dim VehicleIdDataGridViewTextBoxColumn, SenderIdDataGridViewTextBoxColumn, SenderDataGridViewTextBoxColumn _
        , CreatedByIdDataGridViewTextBoxColumn, CreatedByDataGridViewTextBoxColumn, CreateDtDataGridViewTextBoxColumn _
        , StatusIdDataGridViewTextBoxColumn, StatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn


    duplicateDataGridView.SuspendLayout()
    duplicateDataGridView.Columns.Clear()

    VehicleIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    SenderIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    SenderDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    CreatedByIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    CreatedByDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    CreateDtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    StatusIdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
    StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

    duplicateDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                           {VehicleIdDataGridViewTextBoxColumn, SenderIdDataGridViewTextBoxColumn _
                                            , SenderDataGridViewTextBoxColumn, CreatedByIdDataGridViewTextBoxColumn _
                                            , CreatedByDataGridViewTextBoxColumn, CreateDtDataGridViewTextBoxColumn _
                                            , StatusIdDataGridViewTextBoxColumn, StatusDataGridViewTextBoxColumn})

    '
    'VehicleIdDataGridViewTextBoxColumn
    '
    VehicleIdDataGridViewTextBoxColumn.DataPropertyName = "VehicleId"
    VehicleIdDataGridViewTextBoxColumn.HeaderText = "Vehicle Id"
    VehicleIdDataGridViewTextBoxColumn.Name = "VehicleIdDataGridViewTextBoxColumn"
    VehicleIdDataGridViewTextBoxColumn.ReadOnly = True
    '
    'SenderIdDataGridViewTextBoxColumn
    '
    SenderIdDataGridViewTextBoxColumn.DataPropertyName = "SenderId"
    SenderIdDataGridViewTextBoxColumn.HeaderText = "SenderId"
    SenderIdDataGridViewTextBoxColumn.Name = "SenderIdDataGridViewTextBoxColumn"
    SenderIdDataGridViewTextBoxColumn.ReadOnly = True
    SenderIdDataGridViewTextBoxColumn.Visible = False
    '
    'SenderDataGridViewTextBoxColumn
    '
    SenderDataGridViewTextBoxColumn.DataPropertyName = "Sender"
    SenderDataGridViewTextBoxColumn.HeaderText = "Sender"
    SenderDataGridViewTextBoxColumn.Name = "SenderDataGridViewTextBoxColumn"
    SenderDataGridViewTextBoxColumn.ReadOnly = True
    SenderDataGridViewTextBoxColumn.Visible = True
    SenderDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    '
    'CreatedByIdDataGridViewTextBoxColumn
    '
    CreatedByIdDataGridViewTextBoxColumn.DataPropertyName = "CreatedById"
    CreatedByIdDataGridViewTextBoxColumn.HeaderText = "CreatedById"
    CreatedByIdDataGridViewTextBoxColumn.Name = "CreatedByIdDataGridViewTextBoxColumn"
    CreatedByIdDataGridViewTextBoxColumn.ReadOnly = True
    CreatedByIdDataGridViewTextBoxColumn.Visible = False
    '
    'CreatedByDataGridViewTextBoxColumn
    '
    CreatedByDataGridViewTextBoxColumn.DataPropertyName = "CreatedBy"
    CreatedByDataGridViewTextBoxColumn.HeaderText = "Checked-In By"
    CreatedByDataGridViewTextBoxColumn.Name = "CreatedByDataGridViewTextBoxColumn"
    CreatedByDataGridViewTextBoxColumn.ReadOnly = True
    CreatedByDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    '
    'CreateDtDataGridViewTextBoxColumn
    '
    CreateDtDataGridViewTextBoxColumn.DataPropertyName = "CreateDt"
    CreateDtDataGridViewTextBoxColumn.HeaderText = "Check-In Dt"
    CreateDtDataGridViewTextBoxColumn.Name = "CreateDtDataGridViewTextBoxColumn"
    CreateDtDataGridViewTextBoxColumn.ReadOnly = True
    CreateDtDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
    '
    'StatusIdDataGridViewTextBoxColumn
    '
    StatusIdDataGridViewTextBoxColumn.DataPropertyName = "StatusId"
    StatusIdDataGridViewTextBoxColumn.HeaderText = "StatusId"
    StatusIdDataGridViewTextBoxColumn.Name = "StatusIdDataGridViewTextBoxColumn"
    StatusIdDataGridViewTextBoxColumn.ReadOnly = True
    StatusIdDataGridViewTextBoxColumn.Visible = False
    '
    'StatusDataGridViewTextBoxColumn
    '
    StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
    StatusDataGridViewTextBoxColumn.HeaderText = "Status"
    StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
    StatusDataGridViewTextBoxColumn.ReadOnly = True
    StatusDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

    duplicateDataGridView.ResumeLayout(False)


    VehicleIdDataGridViewTextBoxColumn = Nothing
    SenderIdDataGridViewTextBoxColumn = Nothing
    SenderDataGridViewTextBoxColumn = Nothing
    CreatedByIdDataGridViewTextBoxColumn = Nothing
    CreatedByDataGridViewTextBoxColumn = Nothing
    CreateDtDataGridViewTextBoxColumn = Nothing
    StatusIdDataGridViewTextBoxColumn = Nothing
    StatusDataGridViewTextBoxColumn = Nothing

  End Sub


  Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

    m_duplicatePublicationTable.Dispose()
    m_duplicatePublicationTable = Nothing

    Me.Close()

  End Sub


End Class
