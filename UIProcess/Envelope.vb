Namespace UI.Processors


  Public Class Envelope
    Inherits BaseClass


#Region " Events "


    Public Event Initializing As MCAPCancellableEventHandler
    Public Event Initialized As MCAPEventHandler

    Public Event FindingEnvelope As MCAPCancellableEventHandler
    Public Event EnvelopeNotFound As MCAPEventHandler
    Public Event EnvelopeFound As MCAPEventHandler

    Public Event ValidatingColumnValues As MCAPCancellableEventHandler
    Public Event InvalidColumnValueFound As MCAPEventHandler
    Public Event ColumnValuesValidated As MCAPEventHandler

    Public Event InsertingEnvelope As MCAPCancellableEventHandler
    Public Event EnvelopeInserted As MCAPEventHandler

    Public Event UpdatingEnvelope As MCAPCancellableEventHandler
    Public Event EnvelopeUpdated As MCAPEventHandler

    Public Event DeletingEnvelope As MCAPCancellableEventHandler
    Public Event EnvelopeDeleted As MCAPEventHandler

    Public Event NoChangesToSynchronize As MCAPEventHandler
    Public Event SynchronizingEnvelope As MCAPCancellableEventHandler
    Public Event EnvelopeSynchronized As MCAPEventHandler

    Public Event BarcodePrinted As MCAPEventHandler
    Public Event PrintingBarcode As MCAPCancellableEventHandler


#End Region


    Private m_barcodePrinter As String
    Private m_envelopeAdapter As EnvelopeDataSetTableAdapters.EnvelopeTableAdapter
    Private m_envelopeDataSet As EnvelopeDataSet



    ''' <summary>
    ''' Gets table adapter for Envelope table.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected ReadOnly Property EnvelopeAdapter() As EnvelopeDataSetTableAdapters.EnvelopeTableAdapter
      Get
        Return m_envelopeAdapter
      End Get
    End Property

    ''' <summary>
    ''' Gets dataset containing tables related to Envelope Check-in process.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Data() As EnvelopeDataSet
      Get
        Return m_envelopeDataSet
      End Get
    End Property



    ''' <summary>
    ''' Default constructor.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

      MyBase.New()

      m_envelopeDataSet = New EnvelopeDataSet()
      m_envelopeAdapter = New EnvelopeDataSetTableAdapters.EnvelopeTableAdapter()
      m_envelopeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

    End Sub



    ''' <summary>
    ''' Initializes object of this class.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Initialize()

      Using e As CancellableEventArgs = New CancellableEventArgs()
        e.Cancel = False

        RaiseEvent Initializing(Me, e)

        If e.Cancel Then
          Exit Sub
        End If
      End Using

      m_envelopeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      Using e As EventArgs = New EventArgs()
        RaiseEvent Initialized(Me, e)
      End Using

    End Sub


    ''' <summary>
    ''' Prints barcode label for Envelope.
    ''' </summary>
    ''' <param name="barcodeRow">Information, about Envelope, to be printed on barcode label.</param>
    ''' <remarks></remarks>
    Public Sub PrintBarcodeLabel(ByVal barcodeRow As EnvelopeDataSet.EnvelopeRow)
            Dim labelPrint As MCAP.EnvelopeLabelPrint
            Dim barcodeIsNull As Boolean


            labelPrint = New MCAP.EnvelopeLabelPrint()

            labelPrint.PrinterName = BarcodePrinterName
            labelPrint.EnvelopeId = barcodeRow.EnvelopeId
            labelPrint.SenderName = barcodeRow.SenderRow.Name

            barcodeIsNull = barcodeRow.SenderRow.IsPriorityNull
            If (barcodeIsNull) Then
                labelPrint.PriorityId = String.Empty

            Else
                labelPrint.PriorityId = barcodeRow.SenderRow.Priority.ToString()

            End If

            labelPrint.Print()

            labelPrint.Dispose()
            labelPrint = Nothing
        End Sub



#Region " Validation related methods "


    ''' <summary>
    ''' Validates all columns of supplied DataRow.
    ''' </summary>
    ''' <param name="validateRow"></param>
    ''' <remarks></remarks>
    Private Sub ValidateColumnValues(ByVal validateRow As EnvelopeDataSet.EnvelopeRow)
      Dim isShippingInfoRequired, isTrackingNoRequired As Boolean


      validateRow.ClearErrors()

      If validateRow.SenderRow.IsIndNoShippingNull() OrElse (validateRow.SenderRow.IndNoShipping = 0) Then
        isShippingInfoRequired = True
      Else
        isShippingInfoRequired = False
      End If

      If validateRow.ShipperRow Is Nothing _
          OrElse validateRow.ShipperRow.IsIndNeedTrackingNoNull() _
          OrElse validateRow.ShipperRow.IndNeedTrackingNo = 0 _
      Then
        isTrackingNoRequired = False
      Else
        isTrackingNoRequired = True
      End If

      If isShippingInfoRequired = False Then
        validateRow.SetShipperIdNull()
        validateRow.SetShippingMethodIdNull()
        validateRow.SetTrackingNoNull()
        validateRow.SetListedWeightNull()
        validateRow.SetActualWeightNull()
        validateRow.SetPackageTypeIdNull()
      Else
        If isShippingInfoRequired AndAlso validateRow.IsPackageTypeIdNull() Then _
          validateRow.SetColumnError("PackageTypeId", "Package Type is not specified.")

        If isTrackingNoRequired AndAlso validateRow.IsTrackingNoNull() Then _
          validateRow.SetColumnError("TrackingNo", "Tracking number is not specified.")

        If validateRow.IsSenderIdNull() Then _
          validateRow.SetColumnError("SenderId", "Sender is not specified.")

        If validateRow.IsShipperIdNull() Then _
          validateRow.SetColumnError("ShipperId", "Shipping Company is not specified.")

        If validateRow.IsShippingMethodIdNull() Then _
          validateRow.SetColumnError("ShippingMethodId", "Shipping method is not specified.")

        If validateRow.IsListedWeightNull() Then
          validateRow.SetColumnError("ListedWeight", "Printed weight is missing.")
        ElseIf validateRow.ListedWeight < 0.0 Then
          validateRow.SetColumnError("ListedWeight", "Printed weight should be positive number.")
        End If

                'If validateRow.IsActualWeightNull() Then
                'validateRow.SetColumnError("ActualWeight", "Actual weight is missing.")
                ' ElseIf validateRow.ActualWeight < 0.0 Then
                '   validateRow.SetColumnError("ActualWeight", "Actual weight should be positive number.")
                ' End If
      End If

            'If validateRow.IsNull("PackageAssignmentId") Then _
            'validateRow.SetColumnError("PackageAssignmentId", "Package Assignment is not specified.")

    End Sub


#End Region


#Region " Loading Master tables "


    ''' <summary>
    ''' Loads all shippers.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadShipperList()
      Dim shipperAdapter As EnvelopeDataSetTableAdapters.ShipperTableAdapter


      shipperAdapter = New EnvelopeDataSetTableAdapters.ShipperTableAdapter()
      shipperAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      shipperAdapter.Fill(Data.Shipper)

      shipperAdapter.Dispose()
      shipperAdapter = Nothing
    End Sub


    ''' <summary>
    ''' Loads all senders having location same as location of application user.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadLocalSenders()
      Dim senderAdapter As EnvelopeDataSetTableAdapters.SenderTableAdapter


      senderAdapter = New EnvelopeDataSetTableAdapters.SenderTableAdapter()
      senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      senderAdapter.Fill(Data.Sender, Me.UserLocationId)

      senderAdapter.Dispose()
      senderAdapter = Nothing
    End Sub

    ''' <summary>
    ''' Loads all senders having location same as location of application user.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadSenderForEnvelope(ByVal envelopeId As Integer)
      Dim senderAdapter As EnvelopeDataSetTableAdapters.SenderTableAdapter


      senderAdapter = New EnvelopeDataSetTableAdapters.SenderTableAdapter()
      senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      senderAdapter.FillByEnvelopeId(Data.Sender, envelopeId)

      senderAdapter.Dispose()
      senderAdapter = Nothing
    End Sub


    ''' <summary>
    ''' Loads all shipping methods for supplied shipper. 
    ''' </summary>
    ''' <param name="shipperId"></param>
    ''' <remarks></remarks>
    Public Sub LoadShippingMethodList(ByVal shipperId As Integer)
      Dim shippingMethodAdapter As EnvelopeDataSetTableAdapters.vwShippingMethodTableAdapter


      shippingMethodAdapter = New EnvelopeDataSetTableAdapters.vwShippingMethodTableAdapter
      shippingMethodAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      shippingMethodAdapter.Fill(Data.vwShippingMethod, shipperId)

      shippingMethodAdapter.Dispose()
      shippingMethodAdapter = Nothing
    End Sub

    ''' <summary>
    ''' Loads shipping method for supplied envelope. 
    ''' </summary>
    ''' <param name="envelopeId"></param>
    ''' <remarks></remarks>
    Private Sub LoadShippingMethod(ByVal envelopeId As Integer)
      Dim shippingMethodAdapter As EnvelopeDataSetTableAdapters.vwShippingMethodTableAdapter


      shippingMethodAdapter = New EnvelopeDataSetTableAdapters.vwShippingMethodTableAdapter
      shippingMethodAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      shippingMethodAdapter.FillByEnvelopeId(Data.vwShippingMethod, envelopeId)

      shippingMethodAdapter.Dispose()
      shippingMethodAdapter = Nothing
    End Sub


    ''' <summary>
    ''' Loads package types for supplied shipper and shipping method.
    ''' </summary>
    ''' <param name="shipperId"></param>
    ''' <param name="shippingMethodId"></param>
    ''' <remarks></remarks>
    Public Sub LoadPackageTypes(ByVal shipperId As Integer, ByVal shippingMethodId As Integer)
      Dim pkgTypeAdapter As EnvelopeDataSetTableAdapters.vwPackageTypeTableAdapter


      pkgTypeAdapter = New EnvelopeDataSetTableAdapters.vwPackageTypeTableAdapter
      pkgTypeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      pkgTypeAdapter.Fill(Data.vwPackageType, shipperId, shippingMethodId)

      pkgTypeAdapter.Dispose()
      pkgTypeAdapter = Nothing
    End Sub

    ''' <summary>
    ''' Loads package types for supplied envelope.
    ''' </summary>
    ''' <param name="envelopeId"></param>
    ''' <remarks></remarks>
    Private Sub LoadPackageTypes(ByVal envelopeId As Integer)
      Dim pkgTypeAdapter As EnvelopeDataSetTableAdapters.vwPackageTypeTableAdapter


      pkgTypeAdapter = New EnvelopeDataSetTableAdapters.vwPackageTypeTableAdapter
      pkgTypeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      pkgTypeAdapter.FillByEnvelopeId(Data.vwPackageType, envelopeId)

      pkgTypeAdapter.Dispose()
      pkgTypeAdapter = Nothing
    End Sub


    ''' <summary>
    ''' Loads all users having location same as location of application user.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadPackageAssignmentList(ByVal locationId As Integer)
      Dim pkgAssignmentAdapter As EnvelopeDataSetTableAdapters.UserTableAdapter


      pkgAssignmentAdapter = New EnvelopeDataSetTableAdapters.UserTableAdapter
      pkgAssignmentAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      pkgAssignmentAdapter.Fill(Data.User, locationId)

      pkgAssignmentAdapter.Dispose()
      pkgAssignmentAdapter = Nothing
    End Sub


    ''' <summary>
    ''' Loads tables which are not dependent on any user inputs.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PrepareForNew()

      Data.Clear()

      LoadLocalSenders()
      LoadShipperList()
      LoadPackageAssignmentList(Me.UserLocationId)

    End Sub


#End Region


    ''' <summary>
    ''' Gets user's Full name (Fname + LName) for specified user id.
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetUserFullName(ByVal userId As Integer) As String
      Dim userFullName As Object
      Dim userAdapter As EnvelopeDataSetTableAdapters.UserTableAdapter


      userAdapter = New EnvelopeDataSetTableAdapters.UserTableAdapter
      userAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      userFullName = userAdapter.GetUserFullName(userId)

      userAdapter.Dispose()
      userAdapter = Nothing

      If userFullName Is Nothing OrElse userFullName Is DBNull.Value Then
        Return String.Empty
      Else
        Return userFullName.ToString()
      End If

    End Function

    ''' <summary>
    ''' Gets user location name for specified location id.
    ''' </summary>
    ''' <param name="locationId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLocationName(ByVal locationId As Integer) As String
      Dim locationName As String
      Dim userAdapter As EnvelopeDataSetTableAdapters.UserTableAdapter


      userAdapter = New EnvelopeDataSetTableAdapters.UserTableAdapter
      userAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      locationName = userAdapter.GetLocationName(locationId)
      userAdapter.Dispose()
      userAdapter = Nothing

      If locationName Is Nothing Then
        Return String.Empty
      Else
        Return locationName
      End If

    End Function

    ''' <summary>
    ''' Returns boolean flag, indicating whether shipping information is required or not.
    ''' </summary>
    ''' <param name="senderId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsShippingInformationNeeded(ByVal senderId As Integer) As Boolean
      Dim isShippingInfoNeeded As Boolean
      Dim tempRow As EnvelopeDataSet.SenderRow


      tempRow = Data.Sender.FindBySenderId(senderId)

      If tempRow IsNot Nothing AndAlso (tempRow.IsIndNoShippingNull() OrElse tempRow.IndNoShipping = 0) Then
        isShippingInfoNeeded = True
      Else
        isShippingInfoNeeded = False
      End If

      tempRow = Nothing

      Return isShippingInfoNeeded

        End Function

        Public Function InNeedTrackingNo(ByVal ShipperId As Integer) As Boolean
            Dim IsInNeedTrackingNo As Boolean
            Dim tempRow As EnvelopeDataSet.ShipperRow


            tempRow = Data.Shipper.FindByShipperId(ShipperId)

            If tempRow IsNot Nothing AndAlso tempRow.IndNeedTrackingNo = 1 Then
                IsInNeedTrackingNo = True
            Else
                IsInNeedTrackingNo = False
            End If

            tempRow = Nothing

            Return IsInNeedTrackingNo

        End Function

    ''' <summary>
    ''' Returns comments set for specified sender.
    ''' </summary>
    ''' <param name="senderId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCommentsForSender(ByVal senderId As Integer) As String
      Dim comments As String
      Dim tempRow As EnvelopeDataSet.SenderRow


      tempRow = Data.Sender.FindBySenderId(senderId)

      If tempRow IsNot Nothing AndAlso tempRow.IsCommentsNull() = False Then
        comments = tempRow.Comments
      Else
        comments = String.Empty
      End If

      tempRow = Nothing

      Return comments

    End Function

    ''' <summary>
    ''' Returns comments set for specified sender.
    ''' </summary>
    ''' <param name="senderId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetDefaultPackageAssignee(ByVal senderId As Integer) As Integer?
      Dim packageAssignee As Integer?
      Dim tempRow As EnvelopeDataSet.SenderRow


      tempRow = Data.Sender.FindBySenderId(senderId)

      If tempRow IsNot Nothing AndAlso tempRow.IsDefaultPkgAssigneeNull() = False Then
        packageAssignee = tempRow.DefaultPkgAssignee
      Else
        packageAssignee = Nothing
      End If

      tempRow = Nothing

      Return packageAssignee

    End Function

    ''' <summary>
    ''' Gets number of vehicles created from supplied envelope id.
    ''' </summary>
    ''' <param name="envelopeId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetVehicleCount(ByVal envelopeId As Integer) As Boolean
      Dim isExist As Boolean
      Dim vehicleCount As Integer
      Dim count As Object


      count = EnvelopeAdapter.GetVehicleCount(envelopeId)
      If count Is Nothing Then
        vehicleCount = -1
      ElseIf Integer.TryParse(count.ToString(), vehicleCount) = False Then
        vehicleCount = -1
      End If

      count = Nothing
      isExist = (vehicleCount > 1)

      Return isExist

    End Function

    ''' <summary>
    ''' Retrives envelope information from envelope data table based on supplied envelopeID.
    ''' </summary>
    ''' <param name="envelopeID">ID of the envelope, whose information is to be loaded.</param>
    ''' <remarks></remarks>
    ''' <exception cref="System.ApplicationException"></exception>
    Public Sub Load(ByVal envelopeID As Integer)
      Dim envelopeCount As Nullable(Of Integer)
      Dim locationId As Object


      envelopeCount = EnvelopeAdapter.IsEnvelopeExists(envelopeID)
      If envelopeCount.HasValue = False OrElse envelopeCount.Value = 0 Then
        Using e As EventArgs = New EventArgs
          e.Data.Add("EnvelopeId", envelopeID)
          RaiseEvent EnvelopeNotFound(Me, e)
        End Using
        Exit Sub
      End If

      locationId = EnvelopeAdapter.GetEnvelopeReceiverLocationId(envelopeID)
      If locationId Is Nothing OrElse locationId Is DBNull.Value Then
        Throw New ApplicationException("Unable to find location for envelope receiver. Cannot load envelope information.")
      End If

      Using e As CancellableEventArgs = New CancellableEventArgs
        e.Cancel = False
        e.Data.Add("EnvelopeId", envelopeID)

        RaiseEvent FindingEnvelope(Me, e)

        If e.Cancel Then
          Exit Sub
        End If
      End Using

      Data.Clear()
      If CType(locationId, Integer) = UserLocationId Then
        LoadLocalSenders()
        LoadPackageAssignmentList(Me.UserLocationId)
      Else
        LoadSenderForEnvelope(envelopeID)
        LoadPackageAssignmentList(CType(locationId, Integer))
      End If
      LoadShipperList()
      LoadShippingMethod(envelopeID)
      LoadPackageTypes(envelopeID)
      EnvelopeAdapter.FillByEnvelopeId(Data.Envelope, envelopeID)

      If Data.Envelope.Count < 1 Then
        Using e As EventArgs = New EventArgs
          e.Data.Add("EnvelopeId", envelopeID)
          RaiseEvent EnvelopeNotFound(Me, e)
        End Using
      Else
        Dim isVehiclesCreated As Boolean
        Dim locationName As String
        Dim searchRow As EnvelopeDataSet.EnvelopeRow

        searchRow = Data.Envelope.Item(0)
        locationName = GetLocationName(CType(locationId, Integer))
        isVehiclesCreated = GetVehicleCount(envelopeID)

        Using e As EventArgs = New EventArgs
          e.Data.Add("EnvelopeRow", searchRow)
          e.Data.Add("IsVehiclesCreated", isVehiclesCreated)
          e.Data.Add("EnvelopeReceiverLocation", locationName)

          RaiseEvent EnvelopeFound(Me, e)
        End Using

        locationName = Nothing
      End If

      locationId = Nothing

    End Sub

    ''' <summary>
    ''' Loads envelope sent by download sender for location where the application is running, 
    ''' received by current application user and received on current system date and time on 
    ''' database server.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadDownloadEnvelope()

      EnvelopeAdapter.FillForDownloadAd(Data.Envelope, Me.UserLocationId)

    End Sub

    ''' <summary>
    ''' Creates new envelope with sender as Download for location where the application is running
    ''' received and assigned to the user executing application and received on system date and time
    ''' on database server.
    ''' </summary>
    ''' <param name="formName">Name of the form, initiating call to this function.</param>
    ''' <remarks></remarks>
    Public Sub CreateNewDownloadAd(ByVal formName As String)
      Dim row As EnvelopeDataSet.EnvelopeRow
      Dim downloadSenderId As System.Collections.Generic.IEnumerable(Of Integer)


      LoadLocalSenders()

      downloadSenderId = From s In Data.Sender _
                         Where s.Name Like "Download*" AndAlso s.LocationId = Me.UserLocationId _
                         Select s.SenderId

      If downloadSenderId.Count() = 0 Then
        downloadSenderId = Nothing
        Exit Sub
      End If

      row = CreateNew()
      row.BeginEdit()
      row.SenderId = downloadSenderId(0)
      row.PackageAssignmentId = Me.UserID
      row.ReceivedById = Me.UserID
      row.FormName = formName
      row.EndEdit()

      Data.Envelope.AddEnvelopeRow(row)

      row = Nothing

      Save()

    End Sub

    ''' <summary>
    ''' Retrives envelope information from envelope data table based on supplied tracking number.
    ''' </summary>
    ''' <param name="trackingNumber">Tracking number for envelope, whose information is to be loaded.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadByTrackNumber(ByVal trackingNumber As String) As EnvelopeDataSet.EnvelopeRow
      Dim tempTable As EnvelopeDataSet.EnvelopeDataTable
      Dim searchRow As EnvelopeDataSet.EnvelopeRow


      tempTable = New EnvelopeDataSet.EnvelopeDataTable

      Try
        EnvelopeAdapter.FillByTrackingNo(tempTable, trackingNumber)

        If tempTable.Count = 0 Then
          searchRow = Nothing
        Else
          searchRow = tempTable(0)
        End If
      Catch ex As System.Data.SqlClient.SqlException
                Throw New System.ApplicationException("Unable to check for existance of specified tracking number in database. " + ex.Message, ex)
      Catch ex As System.Exception
                Throw New System.ApplicationException("Unknown error has occurred. Cannot check for existance of specified tracking number in database. " + ex.Message, ex)
      Finally
        tempTable.Dispose()
        tempTable = Nothing
      End Try

      Return searchRow

    End Function

    ''' <summary>
    ''' Retrives envelope information from envelope data table based on supplied tracking number.
    ''' </summary>
    ''' <param name="trackingNumber">Tracking number for envelope, whose information is to be loaded.</param>
    ''' <param name="envelopeId">Tracking number will loaded for Envelope ID other than the supplied one.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadByTrackNumber(ByVal trackingNumber As String, ByVal envelopeId As Integer) As EnvelopeDataSet.EnvelopeRow
      Dim tempTable As EnvelopeDataSet.EnvelopeDataTable
      Dim searchRow As EnvelopeDataSet.EnvelopeRow


      tempTable = New EnvelopeDataSet.EnvelopeDataTable

      Try
        EnvelopeAdapter.FillByTrackingNoAndEnvelopeId(tempTable, trackingNumber, envelopeId)

        If tempTable.Count = 0 Then
          searchRow = Nothing
        Else
          searchRow = tempTable.Item(0)
        End If
      Catch ex As System.Data.SqlClient.SqlException
        Throw New System.ApplicationException("Unable to check for existance of specified tracking number in database.", ex)
      Catch ex As System.Exception
        Throw New System.ApplicationException("Unknown error has occurred. Cannot check for existance of specified tracking number in database.", ex)
      Finally
        tempTable.Dispose()
        tempTable = Nothing
      End Try

      Return searchRow

    End Function


    ''' <summary>
    ''' Validate column value of supplied row.
    ''' </summary>
    ''' <param name="validateRow"></param>
    ''' <exception cref="System.ApplicationException"></exception>
    ''' <remarks></remarks>
    Private Sub ValidateValues(ByVal validateRow As EnvelopeDataSet.EnvelopeRow)

      ValidateColumnValues(validateRow)
      If validateRow.HasErrors Then Throw New System.ApplicationException("Invalid column values found.")

    End Sub

    ''' <summary>
    ''' Validate column value for each row in supplied table.
    ''' </summary>
    ''' <param name="validateTable"></param>
    ''' <remarks></remarks>
    Private Sub ValidateValues(ByVal validateTable As EnvelopeDataSet.EnvelopeDataTable)
      Dim validateRow As EnvelopeDataSet.EnvelopeRow


      For i As Integer = 0 To validateTable.Count - 1
        validateRow = Data.Envelope.FindByEnvelopeId(validateTable(i).EnvelopeId)
        If validateRow Is Nothing Then Continue For

        Using e As CancellableEventArgs = New CancellableEventArgs
          e.Data.Add("ValidateRow", validateRow)
          e.Cancel = False

          RaiseEvent ValidatingColumnValues(Me, e)

          If e.Cancel Then
            Exit Sub
          End If
        End Using

        ValidateColumnValues(validateRow)

        If validateRow.HasErrors Then
          Using e As EventArgs = New EventArgs
            e.Data.Add("ValidateRow", validateRow)
            RaiseEvent InvalidColumnValueFound(Me, e)
          End Using
        Else
          Using e As EventArgs = New EventArgs
            e.Data.Add("ValidateRow", validateRow)
            RaiseEvent ColumnValuesValidated(Me, e)
          End Using
        End If
      Next

    End Sub

    ''' <summary>
    ''' Returns a blank DataRow associated with envelope DataTable.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CreateNew() As EnvelopeDataSet.EnvelopeRow

      Return Data.Envelope.NewEnvelopeRow()

    End Function

    ''' <summary>
    ''' Inserts record into Envelope table in database.
    ''' </summary>
    ''' <param name="newRow"></param>
    ''' <exception cref="System.ApplicationException"></exception>
    ''' <remarks></remarks>
    Public Sub Add(ByVal newRow As EnvelopeDataSet.EnvelopeRow)

      ValidateValues(newRow)
      Data.Envelope.AddEnvelopeRow(newRow)

    End Sub

    ''' <summary>
    ''' Save modified envelope information into database.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Save()
      Dim rowsAffected As Integer
      Dim changesDataTable As System.Data.DataTable


      changesDataTable = Data.Envelope.GetChanges()

      If changesDataTable Is Nothing Then
        Using e As UI.Processors.EventArgs = New UI.Processors.EventArgs
          RaiseEvent NoChangesToSynchronize(Me, e)
        End Using
        Exit Sub
      End If

      ValidateValues(CType(changesDataTable, EnvelopeDataSet.EnvelopeDataTable))
      If changesDataTable.HasErrors Then
        Throw New System.ApplicationException("Invalid column values found.")
      End If

      Using e As CancellableEventArgs = New CancellableEventArgs
        e.Data.Add("Changes", changesDataTable.Copy())

        RaiseEvent SynchronizingEnvelope(Me, e)

        changesDataTable.Dispose()
        changesDataTable = Nothing
        If e.Cancel Then Exit Sub
      End Using

      rowsAffected = EnvelopeAdapter.Update(Data.Envelope)
      Data.Envelope.AcceptChanges()

      Using e As UI.Processors.EventArgs = New UI.Processors.EventArgs
        e.Data.Add("Changes", Data.Envelope())
        e.Data.Add("RowsAffected", rowsAffected)

        RaiseEvent EnvelopeSynchronized(Me, e)
      End Using

    End Sub

    ''' <summary>
    ''' Deletes envelope from database.
    ''' </summary>
    ''' <param name="envelopeId"></param>
    ''' <remarks></remarks>
    Public Sub Delete(ByVal envelopeId As Integer)
      Dim isVehicleCreated As Boolean
      Dim rowCount As Integer
      Dim locationName As String
      Dim locationId As Object
      Dim deleteQuery As System.Data.EnumerableRowCollection(Of EnvelopeDataSet.EnvelopeRow)


      locationId = EnvelopeAdapter.GetEnvelopeReceiverLocationId(envelopeId)
      If locationId Is Nothing OrElse locationId Is DBNull.Value Then
        Throw New ApplicationException("Unable to find location for envelope receiver. Cannot load envelope information.")
      End If
      locationName = GetLocationName(CType(locationId, Integer))
      isVehicleCreated = GetVehicleCount(envelopeId)

      deleteQuery = From row In Data.Envelope _
                    Where row.EnvelopeId = envelopeId _
                    Select row

      Using e As MCAP.UI.Processors.CancellableEventArgs = New MCAP.UI.Processors.CancellableEventArgs()
        e.Data.Add("IsVehicleCreated", isVehicleCreated)
        e.Data.Add("EnvelopeReceiverLocation", locationName)
        RaiseEvent DeletingEnvelope(Me, e)
        If e.Cancel Then Exit Sub
      End Using

      If deleteQuery.Count() > 0 Then
        deleteQuery(0).Delete()
        EnvelopeAdapter.Update(Data.Envelope)
      End If

      deleteQuery = Nothing

      Using e As MCAP.UI.Processors.EventArgs = New MCAP.UI.Processors.EventArgs()
        e.Data.Add("EnvelopeId", envelopeId)
        e.Data.Add("RowsAffected", rowCount)
        RaiseEvent EnvelopeDeleted(Me, e)
      End Using

    End Sub


  End Class


End Namespace
