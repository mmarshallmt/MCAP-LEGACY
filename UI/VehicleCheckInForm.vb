Namespace UI

  Public Class EnvelopeContentCheckInForm
    Implements UI.IForm, IDuplicateCheck



    ''' <summary>
    ''' This constant is used to assigning value to FormName column.
    ''' </summary>
    ''' <remarks></remarks>
    Private Const FORM_NAME As String = "Vehicle Check-In"



    Private m_override As Boolean
    Private m_forReview As Boolean
    Private m_isDuplicate As Boolean
    Private m_isPossibleDupFound As Boolean
    Private m_canProceedForIndexing As Boolean
    Private m_isWrongVersion As Boolean

    Private m_envelopeId As Integer
    Private m_printBarcode As Boolean
    Private m_isSame As Boolean
    Private m_dupcheckFormId As Integer

    Private WithEvents m_envelopeContentProcessor As UI.Processors.EnvelopeContent
    Private WithEvents m_envelopeProcessor As UI.Processors.Envelope
        Private _SenderID As Integer
        Private isClosedByButton As Boolean = False

    ''' <summary>
    ''' Gets envelope content processor.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property Processor() As UI.Processors.EnvelopeContent
      Get
        Return m_envelopeContentProcessor
      End Get
    End Property

    ''' <summary>
    ''' Gets envelope processor.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property EnvelopeProcessor() As UI.Processors.Envelope
      Get
        Return m_envelopeProcessor
      End Get
    End Property

    ''' <summary>
    ''' Gets or sets Envelope Id specified by user while creating vehicle.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property EnvelopeId() As Integer
      Get
        Return m_envelopeId
      End Get
      Set(ByVal value As Integer)
        m_envelopeId = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets flag to specify whether to print barcode label while saving vehicle.
    ''' This is in effect only while saving existing vehicle information.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property PrintBarcode() As Boolean
      Get
        Return m_printBarcode
      End Get
      Set(ByVal value As Boolean)
        m_printBarcode = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets flag whether user has clicked on New/Same button.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property IsSame() As Boolean
      Get
        Return m_isSame
      End Get
      Set(ByVal value As Boolean)
        m_isSame = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets boolean flag indicating whether to load indexing screen or not.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>This property is created specifically for Check-In and Index buttons.</remarks>
    Private Property CanProceedForIndexing() As Boolean
      Get
        Return m_canProceedForIndexing
      End Get
      Set(ByVal value As Boolean)
        m_canProceedForIndexing = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets boolean flag, indicating whether to mark vehicle as Wrong Version or not.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property IsWrongVersion() As Boolean
      Get
        Return m_isWrongVersion
      End Get
      Set(ByVal value As Boolean)
        m_isWrongVersion = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets DupCheckForId to update vehicleId for new vehicles.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property DupcheckFormLogId() As Integer
      Get
        Return m_dupcheckFormId
      End Get
      Set(ByVal value As Integer)
        m_dupcheckFormId = value
      End Set
    End Property



    ''' <summary>
    ''' Prints barcode label based on supplied row.
    ''' </summary>
    ''' <param name="barcodeRow"></param>
    ''' <remarks></remarks>
    Private Sub PrintBarcodeLabel(ByVal barcodeRow As EnvelopeContentDataSet.vwCircularRow)


#If DEBUG Then

      If MessageBox.Show("Do you want to print?", Application.ProductName, MessageBoxButtons.YesNo _
                         , MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No _
      Then
        Exit Sub
      End If

#End If

      Try
        Processor.PrintBarcode(barcodeRow)
      Catch ex As Exception
        Trace.TraceError("EnvelopeContentCheckInForm.PrintBarcodeLabel():Printing barcode label for envelope. Message=" + ex.Message _
                         , New Object() {"Barcode label printer=", BarcodePrinterName, "DataRow=", barcodeRow})
      End Try

    End Sub

    ''' <summary>
    ''' Clear all inputs on form.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub ClearAllInputs()

      envelopeIdTextBox.Clear()
      senderLabel.Text = String.Empty
            adDateTypeInDatePicker.Clear()
            DistDateTypeInDatePicker.Clear()
      mediaComboBox.SelectedValue = DBNull.Value
      marketComboBox.SelectedValue = DBNull.Value
      retailerComboBox.SelectedValue = DBNull.Value
      tradeclassValueLabel.Text = String.Empty
      priorityValueLabel.Text = String.Empty
      newspaperComboBox.SelectedValue = DBNull.Value
      multipleOccurrencesCheckBox.Checked = False
      flashCheckBox.Checked = False
      commentsTextBox.Clear()
      vehicleIdValueLabel.Text = String.Empty
      vehicleIdLabel.Visible = False
      vehicleIdTextBox.Clear()

            ByPassCheckBox.Enabled = False
            ByPassCheckBox.Checked = False

            m_isPossibleDupFound = False
      m_isDuplicate = False
      m_forReview = False
      m_override = False
      m_isWrongVersion = False

      EnvelopeId = -1

    End Sub

    ''' <summary>
    ''' Clears all inputs, other than ad date, media, market.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearInputsForSame()

      retailerComboBox.Text = String.Empty
      retailerComboBox.SelectedIndex = -1
      retailerComboBox.SelectedValue = DBNull.Value
      tradeclassValueLabel.Text = String.Empty
      priorityValueLabel.Text = String.Empty
      multipleOccurrencesCheckBox.Checked = False
      flashCheckBox.Checked = False
      commentsTextBox.Clear()
      vehicleIdValueLabel.Text = String.Empty
      vehicleIdLabel.Visible = False
      vehicleIdTextBox.Clear()

      m_isPossibleDupFound = False
      m_isDuplicate = False
      m_forReview = False
      m_override = False
      m_isWrongVersion = False

    End Sub

    ''' <summary>
    ''' Enables/Disables input controls based on supplied values of formStatus.
    ''' </summary>
    ''' <param name="formStatus"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub EnableDisableControls(ByVal formStatus As FormStateEnum)
      MyBase.EnableDisableControls(formStatus)

      Select Case formStatus
        Case FormStateEnum.Insert
                    Me.adDateTypeInDatePicker.Enabled = True
                    Me.DistDateTypeInDatePicker.Enabled = True
          Me.mediaComboBox.Enabled = True
          Me.marketComboBox.Enabled = True
          Me.retailerComboBox.Enabled = True
          Me.newspaperComboBox.Enabled = True
          Me.multipleOccurrencesCheckBox.Enabled = True
          Me.flashCheckBox.Enabled = True
          'Me.nationalCheckBox.Enabled = True
          Me.checkInNewButton.Enabled = True
          Me.checkInSameButton.Enabled = True
          Me.checkInNewAndIndexButton.Enabled = True
          Me.checkInSameAndIndexButton.Enabled = True
          Me.printLabelButton.Enabled = False
          Me.clearButton.Enabled = True
          Me.newRetailerButton.Enabled = True
          Me.ropCheckInButton.Enabled = True
          Me.deleteButton.Enabled = False
          Me.wrongVersionButton.Enabled = True

        Case FormStateEnum.Edit
                    Me.adDateTypeInDatePicker.Enabled = True
                    Me.DistDateTypeInDatePicker.Enabled = True
          Me.mediaComboBox.Enabled = True
          Me.marketComboBox.Enabled = True
          Me.newspaperComboBox.Enabled = True
          Me.retailerComboBox.Enabled = True
          Me.flashCheckBox.Enabled = Me.flashCheckBox.Enabled
          'Me.nationalCheckBox.Enabled = Me.flashCheckBox.Enabled
          Me.multipleOccurrencesCheckBox.Enabled = Me.flashCheckBox.Enabled
          Me.checkInNewButton.Enabled = True
          Me.checkInSameButton.Enabled = True
          Me.printLabelButton.Enabled = Me.flashCheckBox.Enabled
          Me.clearButton.Enabled = True
          Me.newRetailerButton.Enabled = Me.flashCheckBox.Enabled
          Me.ropCheckInButton.Enabled = False
          Me.deleteButton.Enabled = True
          Me.wrongVersionButton.Enabled = Me.flashCheckBox.Enabled

        Case Else
                    Me.adDateTypeInDatePicker.Enabled = False
                    Me.DistDateTypeInDatePicker.Enabled = False
          Me.mediaComboBox.Enabled = False
          Me.marketComboBox.Enabled = False
          Me.retailerComboBox.Enabled = False
          Me.newspaperComboBox.Enabled = False
          Me.multipleOccurrencesCheckBox.Enabled = False
          Me.flashCheckBox.Enabled = False
          'Me.nationalCheckBox.Enabled = False
          Me.checkInNewButton.Enabled = False
          Me.checkInSameButton.Enabled = False
          Me.checkInNewAndIndexButton.Enabled = False
          Me.checkInSameAndIndexButton.Enabled = False
          Me.printLabelButton.Enabled = False
          Me.clearButton.Enabled = False
          Me.newRetailerButton.Enabled = False
          Me.ropCheckInButton.Enabled = False
          Me.deleteButton.Enabled = False
          Me.wrongVersionButton.Enabled = False
      End Select

    End Sub

    ''' <summary>
    ''' Clear error providers from all input controls.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub RemoveAllErrorProviders()
      MyBase.RemoveAllErrorProviders()

      RemoveErrorProvider(adDateTypeInDatePicker)
      RemoveErrorProvider(mediaComboBox)
      RemoveErrorProvider(marketComboBox)
      RemoveErrorProvider(retailerComboBox)
      RemoveErrorProvider(newspaperComboBox)
      RemoveErrorProvider(multipleOccurrencesCheckBox)
      RemoveErrorProvider(vehicleIdTextBox)

    End Sub


    ''' <summary>
    ''' Showing error popup to user based on error texts assigned to each column.
    ''' </summary>
    ''' <param name="errorTables"></param>
    ''' <remarks></remarks>
    Private Sub ShowErrors(ByVal errorTables As MCAP.EnvelopeContentDataSet.ErrorsDataTable)
      Dim rowCounter As Integer
      Dim errorMessage As System.Text.StringBuilder
      Dim errorQuery As System.Collections.Generic.IEnumerable(Of String)


      If errorTables.Count = 0 Then Exit Sub

      errorMessage = New System.Text.StringBuilder
      errorQuery = From er In errorTables.Rows.Cast(Of EnvelopeContentDataSet.ErrorsRow)() _
                   Select er.ColumnCaption + " - " + er.Message

      errorMessage.Append("Invalid inputs found.")
      errorMessage.AppendLine(Environment.NewLine)  'i.e. 2 new lines
      For rowCounter = 0 To errorQuery.Count - 1
        errorMessage.Append((rowCounter + 1).ToString())
        errorMessage.Append(". ")
        errorMessage.AppendLine(errorQuery(rowCounter))
      Next

      MessageBox.Show(errorMessage.ToString(), Application.ProductName, _
                      MessageBoxButtons.OK, MessageBoxIcon.Error)

      errorMessage = Nothing

    End Sub

    ''' <summary>
    ''' Displays all warnings in a single messagebox.
    ''' </summary>
    ''' <param name="warningTable"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ShowWarnings(ByVal warningTable As MCAP.EnvelopeContentDataSet.WarningsDataTable) As System.Windows.Forms.DialogResult
      Dim warningCounter As Integer
      Dim userResponse As DialogResult
      Dim warningMessage As System.Text.StringBuilder
      Dim warningQuery As System.Collections.Generic.IEnumerable(Of String)


      warningMessage = New System.Text.StringBuilder
      warningQuery = From wr In warningTable _
                     Select wr.ColumnCaption + " - " + wr.Message

      warningMessage.Append("Possible invalid inputs found.")
      warningMessage.Append(Environment.NewLine)
      For warningCounter = 0 To warningQuery.Count - 1
        warningMessage.Append((warningCounter + 1).ToString())
        warningMessage.Append(". ")
        warningMessage.AppendLine(warningQuery(warningCounter))
      Next

      warningMessage.AppendLine(Environment.NewLine)  'i.e. 2 new lines.
      warningMessage.Append("Click OK to ignore all warnings and continue or Cancel to abort.")

      userResponse = MessageBox.Show(warningMessage.ToString(), Application.ProductName, _
                                     MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

      warningMessage = Nothing

      Return userResponse

    End Function

    ''' <summary>
    ''' Prepares Required retailers datagrid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PrepareRequiredRetailersDataGridView()
      Dim columnCounter As Integer


      For columnCounter = 0 To requiredRetailersDataGridView.Columns.Count - 1
        requiredRetailersDataGridView.Columns(columnCounter).Visible = False
      Next

      With Me.requiredRetailersDataGridView
        .RowHeadersVisible = False
        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
        .Columns("Priority").Visible = True
        .Columns("Descrip").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        .Columns("Descrip").Visible = True
      End With

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="tempRow"></param>
    ''' <param name="dupCheckResponse"></param>
    ''' <remarks></remarks>
    Private Sub SetColumnValues(ByVal tempRow As EnvelopeContentDataSet.vwCircularRow, ByVal dupCheckResponse As DuplicateCheckUserResponse)

      tempRow.BeginEdit()

      If Me.FormState = FormStateEnum.Insert Then tempRow.EnvelopeId = Me.EnvelopeId
            tempRow.BreakDt = CType(adDateTypeInDatePicker.Text, DateTime)
            tempRow.DistDt = CType(DistDateTypeInDatePicker.Text, DateTime)
      tempRow.MktId = CType(marketComboBox.SelectedValue, Integer)
      tempRow.MediaId = CType(mediaComboBox.SelectedValue, Integer)
      tempRow.PublicationId = CType(newspaperComboBox.SelectedValue, Integer)
      tempRow.RetId = CType(retailerComboBox.SelectedValue, Integer)
      tempRow.SetCheckInPageCountNull()
      If multipleOccurrencesCheckBox.Text.Trim().Length = 0 Then
        tempRow.SetCheckInOccurrencesNull()
      Else
        tempRow.CheckInOccurrences = CType(IIf(multipleOccurrencesCheckBox.Checked, 1, 0), Integer)
      End If
      If flashCheckBox.Checked Then
        tempRow.FlashInd = 1
      Else
        tempRow.FlashInd = 0
      End If
      If nationalCheckBox.Checked Then
        tempRow.NationalInd = 1
      Else
        tempRow.NationalInd = 0
      End If
      If tempRow.IsPublicationIdNull() Then
        tempRow.SetPriorityNull()
      Else
        tempRow.Priority = Processor.GetPriority(tempRow.RetId, tempRow.MktId, tempRow.MediaId)
      End If
      tempRow.FormName = FORM_NAME

      '
      'If vehicle status is created, keep statusId as null,
      'if its not required, status id is set while validating row in processor.
      '
      If dupCheckResponse = DuplicateCheckUserResponse.Review Then
        tempRow.StatusID = Processor.GetStatusIdForReview()
      ElseIf dupCheckResponse = DuplicateCheckUserResponse.Duplicate Then
        tempRow.StatusID = Processor.GetStatusIdForDuplicate()
      ElseIf Me.IsWrongVersion Then
        tempRow.StatusID = Processor.GetStatusIdForWrongVersion()
      Else
        tempRow.SetStatusIDNull()
      End If

      tempRow.EndEdit()

    End Sub

    ''' <summary>
    ''' Show column data into inputs. 
    ''' </summary>
    ''' <param name="tempEnvelopeRow"></param>
    ''' <remarks></remarks>
    Private Sub ShowRecord(ByVal tempEnvelopeRow As EnvelopeContentDataSet.vwCircularRow)
      Dim isExpectedRetailer As Boolean
      Dim senderName As String


      Me.SuspendLayout()

      Me.EnvelopeId = tempEnvelopeRow.EnvelopeId
      senderName = Processor.GetEnvelopeSenderName(tempEnvelopeRow.EnvelopeId)
      senderLabel.Text = "Loaded: " + Me.EnvelopeId.ToString() + "; Sent By: " + senderName
      senderName = Nothing

            _SenderID = Processor._tempId
            Processor.LoadDataSet(CheckVehicleId(tempEnvelopeRow.EnvelopeId))
            Processor.LoadMarketsPerSenderExpectation(_SenderID, tempEnvelopeRow.MediaId)
      marketComboBox.SelectedValue = DBNull.Value 'This is required to populate publication and vwExpectedRet.
      retailerComboBox.SelectedValue = DBNull.Value

      adDateTypeInDatePicker.Text = tempEnvelopeRow.BreakDt.ToString("MM/dd/yy")
      mediaComboBox.SelectedValue = tempEnvelopeRow.MediaId
      marketComboBox.SelectedValue = tempEnvelopeRow.MktId
      newspaperComboBox.SelectedValue = tempEnvelopeRow.PublicationId

      isExpectedRetailer = Processor.IsRetailerExpectedRetailer(tempEnvelopeRow.RetId)
      If isExpectedRetailer = False Then
        Processor.LoadRetailers()
      End If

      retailerComboBox.SelectedValue = tempEnvelopeRow.RetId
      ShowTradeclassForRetailer(tempEnvelopeRow.RetId)
      ShowCommentsForExpectedRetailer(tempEnvelopeRow.RetId)
      ShowPriorityForExpectedRetailer(tempEnvelopeRow.RetId)
      If tempEnvelopeRow.IsFlashIndNull() Then
        flashCheckBox.Checked = False
      Else
        flashCheckBox.Checked = (tempEnvelopeRow.FlashInd > 0)
      End If
      If tempEnvelopeRow.IsNationalIndNull() Then
        nationalCheckBox.Checked = False
      Else
        nationalCheckBox.Checked = (tempEnvelopeRow.NationalInd > 0)
      End If
      If tempEnvelopeRow.IsCheckInOccurrencesNull() Then
        multipleOccurrencesCheckBox.Checked = False
      Else
        multipleOccurrencesCheckBox.Checked = (tempEnvelopeRow.CheckInOccurrences = 1)
      End If
      vehicleIdLabel.Visible = True
      vehicleIdValueLabel.Text = tempEnvelopeRow.VehicleId.ToString()

      If Processor.IsVehicleDuplicate(tempEnvelopeRow.VehicleId) Then
        m_isDuplicate = True
      ElseIf Processor.IsVehicleReviewed(tempEnvelopeRow.VehicleId) Then
        m_forReview = True
      End If

      Me.ResumeLayout(False)

        End Sub

        Private Function CheckVehicleId(ByVal _envelopeid As Integer) As Boolean
            Dim ReturnVal As Boolean
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "select * from Vehicle where  EnvelopeId=" + _envelopeid.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With

                If obj IsNot Nothing Then
                    ReturnVal = True
                Else
                    ReturnVal = False
                End If

            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return ReturnVal
        End Function


#Region " IForm Implementation "

    Public Event InitializingForm() Implements IForm.InitializingForm
    Public Event FormInitialized() Implements IForm.FormInitialized

    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied


    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials
      Dim tempAdapter As EnvelopeContentDataSetTableAdapters.vwUserScreensFunctionalityTableAdapter


      tempAdapter = New EnvelopeContentDataSetTableAdapters.vwUserScreensFunctionalityTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      tempAdapter.Fill(Processor.Data.vwUserScreensFunctionality, "Index", Processor.UserID)
      If Processor.Data.vwUserScreensFunctionality.Count = 0 Then
        checkInNewAndIndexButton.Hide()
        checkInSameAndIndexButton.Hide()
      End If

      tempAdapter.Dispose()
      tempAdapter = Nothing

    End Sub

    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

      RaiseEvent InitializingForm()

      Me.SuspendLayout()

      Me.FormState = formStatus
      Me.PrintBarcode = False

      m_envelopeProcessor = New UI.Processors.Envelope
      m_envelopeContentProcessor = New UI.Processors.EnvelopeContent
      Processor.Initialize()
      Processor.LoadDataSet()

      Me.StatusMessage = "Information loaded. Preparing to show information on window."

      RemoveHandler marketComboBox.SelectedValueChanged, AddressOf marketComboBox_SelectedValueChanged
      RemoveHandler mediaComboBox.SelectedValueChanged, AddressOf mediaComboBox_SelectedValueChanged

      marketComboBox.ValueMember = "MktId"
      marketComboBox.DisplayMember = "Descrip"
      marketComboBox.DataSource = Processor.Data.Mkt
      marketComboBox.SelectedValue = DBNull.Value

      mediaComboBox.ValueMember = "MediaId"
      mediaComboBox.DisplayMember = "Descrip"
      mediaComboBox.DataSource = Processor.Data.Media
      mediaComboBox.SelectedValue = DBNull.Value

      retailerComboBox.ValueMember = "RetId"
      retailerComboBox.DisplayMember = "Descrip"
      retailerComboBox.DataSource = Processor.Data.Ret
      retailerComboBox.SelectedValue = DBNull.Value

      ClearAllInputs()
      ShowHideControls(formStatus)
      EnableDisableControls(formStatus)

      AddHandler marketComboBox.SelectedValueChanged, AddressOf marketComboBox_SelectedValueChanged
      AddHandler mediaComboBox.SelectedValueChanged, AddressOf mediaComboBox_SelectedValueChanged

      Me.ResumeLayout(False)

      RaiseEvent FormInitialized()

    End Sub

#End Region


#Region " IDuplicateCheck Implementation "


    Public ReadOnly Property MarkAsDuplicate() As Boolean Implements IDuplicateCheck.MarkAsDuplicate
      Get
        Return m_isDuplicate
      End Get
    End Property

    Public ReadOnly Property MarkForReview() As Boolean Implements IDuplicateCheck.MarkForReview
      Get
        Return m_forReview
      End Get
    End Property

    Public ReadOnly Property IsAnyPossibleDuplicateRecordFound() As Boolean Implements IDuplicateCheck.IsAnyPossibleDuplicateRecordFound
      Get
        Return m_isPossibleDupFound
      End Get
    End Property

    Public ReadOnly Property Override() As Boolean Implements IDuplicateCheck.Override
      Get
        Return m_override
      End Get
    End Property


    ''' <summary>
    ''' Checks for possible duplicate records in Vehicle table. If found shows records to user 
    ''' for further action.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckForDuplication _
        (ByVal marketId As Integer, ByVal publicationId As Integer, ByVal applyOverrideRestriction As Boolean, ByVal formName As String) _
        As DuplicateCheckUserResponse _
        Implements IDuplicateCheck.CheckForDuplication
      Dim userResponse As DialogResult
      Dim retailerId As Integer
      Dim languageId As Nullable(Of Integer)
      Dim adDate As DateTime
      Dim mediaList As System.Collections.Generic.List(Of String)
      Dim possibleDupVehicles As UI.DupCheckForm


      mediaList = New System.Collections.Generic.List(Of String)
      retailerId = CType(retailerComboBox.SelectedValue, Integer)
      adDate = adDateTypeInDatePicker.Value.Value
      languageId = Nothing  'Users can't specify language on this screen.

      Select Case mediaComboBox.Text.ToUpper()
        Case "FSI"
          mediaList.Clear()
          mediaList.Add("FSI")
          possibleDupVehicles = New UI.DupCheckForm(retailerId, marketId, adDate, mediaList, languageId, applyOverrideRestriction, formName)

        Case "ROP"
          mediaList.Clear()
          mediaList.Add("ROP")
          possibleDupVehicles = New UI.DupCheckForm(retailerId, marketId, publicationId, adDate, mediaList, languageId, applyOverrideRestriction, formName)
        Case "CATALOG", "IN-STORE", "INSERT", "MAILER", "ROP - CIRCULAR", "MONTHLY BOOKLET", "PICK-UP IN-STORE", "INTERNET"
          mediaList.Clear()
          mediaList.Add("Catalog")
          mediaList.Add("In-Store")
          mediaList.Add("Insert")
          mediaList.Add("Mailer")
          mediaList.Add("Internet")
          mediaList.Add("ROP - Circular") 'Circular ROP
          mediaList.Add("Monthly Booklet")
          mediaList.Add("Pick-Up In-Store")
          possibleDupVehicles = New UI.DupCheckForm(retailerId, marketId, adDate, mediaList, Nothing, Nothing, languageId, applyOverrideRestriction, formName)
          If mediaComboBox.Text.ToUpper() = "CATALOG" Then
            possibleDupVehicles.dateRangeNumericUpDown.Value = 14
          Else
            possibleDupVehicles.dateRangeNumericUpDown.Value = 5
          End If
        Case Else
          mediaList.Clear()
          mediaList.Add(mediaComboBox.Text.ToUpper())
          possibleDupVehicles = New UI.DupCheckForm(retailerId, marketId, adDate, mediaList, Nothing, Nothing, languageId, applyOverrideRestriction, formName)
          possibleDupVehicles.dateRangeNumericUpDown.Value = 5

      End Select

      mediaList.Clear()
      mediaList = Nothing

      If Me.FormState = FormStateEnum.Edit Then
        possibleDupVehicles.RemoveVehicle = CType(vehicleIdValueLabel.Text, Integer)
      End If
      possibleDupVehicles.Init(FormStateEnum.View)
      If possibleDupVehicles.IsPossibleDuplicateRecordsFound Then
        possibleDupVehicles.ApplyUserCredentials()
        userResponse = possibleDupVehicles.ShowDialog(Me)
        m_isPossibleDupFound = True
      Else
        m_isPossibleDupFound = False
        userResponse = Windows.Forms.DialogResult.OK
        CheckForDuplication = DuplicateCheckUserResponse.NoPossibleDuplidates
      End If

      If userResponse = Windows.Forms.DialogResult.Cancel Then
        CheckForDuplication = DuplicateCheckUserResponse.Closed
      ElseIf possibleDupVehicles.IsOverride And userResponse = Windows.Forms.DialogResult.OK Then
        CheckForDuplication = DuplicateCheckUserResponse.Override
      ElseIf possibleDupVehicles.IsReview And userResponse = Windows.Forms.DialogResult.OK Then
        CheckForDuplication = DuplicateCheckUserResponse.Review
      ElseIf possibleDupVehicles.IsDuplicate And userResponse = Windows.Forms.DialogResult.OK Then
        CheckForDuplication = DuplicateCheckUserResponse.Duplicate
      End If

      m_override = possibleDupVehicles.IsOverride
      m_forReview = possibleDupVehicles.IsReview
      m_isDuplicate = possibleDupVehicles.IsDuplicate
      Me.DupcheckFormLogId = possibleDupVehicles.DupcheckFormLogId

      possibleDupVehicles.Dispose()
      possibleDupVehicles = Nothing

    End Function


#End Region


    ''' <summary>
    ''' Validates inputs and returns true if all inputs are valid, false otherwise.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AreInputsValid() As Boolean
      Dim areAllValid As Boolean
      Dim tempDate As DateTime


      areAllValid = True

      If mediaComboBox.SelectedValue Is Nothing Then
        SetErrorProvider(mediaComboBox, "Media is not specified.")
        areAllValid = False
      Else
        RemoveErrorProvider(mediaComboBox)
      End If

      If marketComboBox.SelectedValue Is Nothing Then
        SetErrorProvider(marketComboBox, "Market is not specified.")
        areAllValid = False
      Else
        RemoveErrorProvider(marketComboBox)
      End If

      If newspaperComboBox.SelectedValue Is Nothing Then
        SetErrorProvider(newspaperComboBox, "Newspaper is not specified.")
        areAllValid = False
      Else
        RemoveErrorProvider(newspaperComboBox)
      End If

      If Date.TryParse(adDateTypeInDatePicker.Text, tempDate) = False Then
        SetErrorProvider(adDateTypeInDatePicker, "Invalid Date.")
        areAllValid = False
      Else
        RemoveErrorProvider(adDateTypeInDatePicker)
      End If

      If retailerComboBox.SelectedValue Is Nothing Then
        SetErrorProvider(retailerComboBox, "Retailer is not specified.")
        areAllValid = False
      Else
        RemoveErrorProvider(retailerComboBox)
      End If

      If tradeclassValueLabel.Text.ToUpper() = "FSI" _
          AndAlso adDateTypeInDatePicker.Value.Value.DayOfWeek <> DayOfWeek.Sunday _
      Then
        Dim userResponse As DialogResult
        userResponse = MessageBox.Show("Are you sure this date is correct?", ProductName _
                                       , MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                       , MessageBoxDefaultButton.Button2)
        If userResponse = Windows.Forms.DialogResult.Yes Then
          RemoveErrorProvider(adDateTypeInDatePicker)
        Else
          areAllValid = False
          adDateTypeInDatePicker.Focus()
        End If
      End If

      Return areAllValid

    End Function

    Private Sub ShowPriorityForExpectedRetailer(ByVal retailerId As Integer)
      Dim priority As Integer?


      priority = Processor.GetPriorityForExpectedRetailer(retailerId)
      priorityValueLabel.Text = String.Empty
      If priority.HasValue Then priorityValueLabel.Text = priority.Value.ToString()

      priority = Nothing
    End Sub

    Private Sub ShowCommentsForExpectedRetailer(ByVal retailerId As Integer)
      Dim comments As String


      comments = Processor.GetCommentForExpectedRetailer(retailerId)
      commentsTextBox.Clear()
      If comments IsNot Nothing Then commentsTextBox.Text = comments

      comments = Nothing
    End Sub

    Private Sub ShowTradeclassForRetailer(ByVal retailerId As Integer)
      Dim tradeclass As String


      tradeclass = Processor.GetTradeclassOfRetailer(retailerId)
      tradeclassValueLabel.Text = String.Empty
      If tradeclass IsNot Nothing Then tradeclassValueLabel.Text = tradeclass

      tradeclass = Nothing
    End Sub

    ''' <summary>
    ''' Updates VehicleId column of DupCheckFormLog table.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="dupcheckFormLogId"></param>
    ''' <remarks></remarks>
    Private Sub UpdateVehicleIdForDupCheckFormLogId(ByVal vehicleId As Integer, ByVal dupcheckFormLogId As Integer)
      Dim tempAdapter As EnvelopeContentDataSetTableAdapters.vwCircularTableAdapter


      tempAdapter = New EnvelopeContentDataSetTableAdapters.vwCircularTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      tempAdapter.UpdateVehicleIdForDupFormId(vehicleId, dupcheckFormLogId)
      tempAdapter.Dispose()
      tempAdapter = Nothing
    End Sub


    Private Sub closeButton_Click _
         (ByVal sender As Object, ByVal e As System.EventArgs) _
         Handles closeButton.Click
            isClosedByButton = True
      Me.Close()

    End Sub

    Private Sub clearButton_Click _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles clearButton.Click

      ClearAllInputs()
      RemoveAllErrorProviders()

      Me.FormState = FormStateEnum.Insert

      EnableDisableControls(Me.FormState)
      envelopeIdTextBox.Focus()

    End Sub

    Private Sub envelopeIdTextBox_KeyPress _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles envelopeIdTextBox.KeyPress

      '3 - Copy, 22 - Paste and 24 - Cut, 8 - Backspace
      If Microsoft.VisualBasic.AscW(e.KeyChar) = 3 _
        OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 22 _
        OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 24 _
        OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 8 _
      Then
        Exit Sub 'Process as it should.
      End If

      If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
        loadButton.PerformClick()

      ElseIf Not (e.KeyChar = Microsoft.VisualBasic.ChrW(8)) _
        AndAlso (Not (e.KeyChar > Microsoft.VisualBasic.ChrW(47) _
          And e.KeyChar < Microsoft.VisualBasic.ChrW(58))) _
      Then
        e.Handled = True
      End If

        End Sub

        Private Sub adDateTypeInDatePicker_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles adDateTypeInDatePicker.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.S And ByPassCheckBox.Checked = True Then
                checkInNewButton.Enabled = True
                checkInSameButton.Enabled = True
                checkInNewAndIndexButton.Enabled = True
                checkInSameAndIndexButton.Enabled = True
                newRetailerButton.Enabled = True
                ropCheckInButton.Enabled = True
            End If
        End Sub

    Private Sub adDateMaskedTextBox_Validating _
        (ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles adDateTypeInDatePicker.Validating
      Dim differenceInDays As Integer
      Dim userResponse As DialogResult
      Dim tempDate As DateTime

            RemoveErrorProvider(adDateTypeInDatePicker)
      If adDateTypeInDatePicker.Value.HasValue Then
        tempDate = adDateTypeInDatePicker.Value.Value
        differenceInDays = CType(tempDate.Subtract(System.DateTime.Today).TotalDays, Integer)

        If differenceInDays < -365 Or differenceInDays > 365 Then
          userResponse = MessageBox.Show("Is the Ad date correct?", ProductName, MessageBoxButtons.YesNo _
                                         , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
          If userResponse = Windows.Forms.DialogResult.No Then e.Cancel = True
                ElseIf differenceInDays < -28 Or differenceInDays > 28 Then
                    SetErrorProvider(adDateTypeInDatePicker, "Ad Date needs to be within 28 days from today's date.")
                End If
      End If

    End Sub

    Private Sub loadButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles loadButton.Click
      Dim envelopeId As Integer


            'If String.IsNullOrEmpty(envelopeIdTextBox.Text) Then
            '  MessageBox.Show("Provide a valid Envelope Id.", ProductName, _
            '                  MessageBoxButtons.OK, MessageBoxIcon.Information)
            '  Exit Sub
            'ElseIf Integer.TryParse(envelopeIdTextBox.Text, envelopeId) = False Then
            '          MessageBox.Show("Please Enter a valid ID.", ProductName, _
            '                  MessageBoxButtons.OK, MessageBoxIcon.Error)
            '  Exit Sub
            'End If
            If String.IsNullOrEmpty(envelopeIdTextBox.Text) Or Integer.TryParse(envelopeIdTextBox.Text, envelopeId) = False Then
                MessageBox.Show("Please Enter a valid ID.", ProductName, _
                              MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            Try
                _SenderID = Processor.LoadEnvelopeSenderInfo(envelopeId)
                Processor.LoadDataSet()
                ByPassCheckBox.Enabled = Processor.m_FilterBySenderExpectation
                mediaComboBox.DataSource = Processor.Data.Media
                mediaComboBox.ValueMember = "MediaId"
                mediaComboBox.DisplayMember = "Descrip"
                mediaComboBox.SelectedValue = DBNull.Value
                retailerComboBox.SelectedIndex = -1
            Catch ex As Exception
                Trace.TraceError("EnvelopeContentCheckInForm.loadButton_Click():Unable to load envelope sender information. Message=" + ex.Message, New Object() {"EnvelopeId=", envelopeId})
                MessageBox.Show("Error has occurred while loading envelope sender information. Unable to load envelope sender information." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            'If Processor.Data.EnvelopeSender.Count > 0 Then
            '  If Processor.Data.EnvelopeSender(0).IsIndNoPublicationsNull() Then
            '    ropCheckInButton.Enabled = True
            '  Else
            '    ropCheckInButton.Enabled = (Processor.Data.EnvelopeSender(0).IndNoPublications = 0)
            '  End If
            'End If
        End Sub

        Private Sub mediaComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mediaComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.S And ByPassCheckBox.Checked = True Then
                checkInNewButton.Enabled = True
                checkInSameButton.Enabled = True
                checkInNewAndIndexButton.Enabled = True
                checkInSameAndIndexButton.Enabled = True
                newRetailerButton.Enabled = True
                ropCheckInButton.Enabled = True
            End If
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

    Private Sub mediaComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mediaComboBox.SelectedValueChanged
      Dim marketId, mediaId As Integer


      Try
        If mediaComboBox.Text.ToUpper() = "CATALOG" Then
          Processor.LoadMarketsForCatalog()
        Else
                    If CInt(mediaComboBox.SelectedValue) > 0 Then
                        If Processor.LoadMarketsPerSenderExpectation(_SenderID, CInt(mediaComboBox.SelectedValue)) = 0 Then
                            Processor.LoadMarketsForEnvelope(Me.EnvelopeId)
                        End If
                    ElseIf mediaComboBox.SelectedValue IsNot Nothing Then
                        Processor.Data.Mkt.Clear()
                    End If

                    'If ByPassCheckBox.Checked = True And CInt(mediaComboBox.SelectedValue) > 0 Then
                    '    Processor.LoadMarketsForEnvelope(Me.EnvelopeId)
                    'End If
        End If
      Catch ex As Exception
        Trace.TraceError("EnvelopeContentCheckInForm.mediaComboBox_SelectedValueChanged():Unable to load markets. Message=" + ex.Message, New Object() {"Media=", mediaComboBox.Text})
        MessageBox.Show("Error has occurred while loading markets. Unable to load markets.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Processor.Data.Mkt.Rows.Clear()
      End Try

            If marketComboBox.Items.Count = 1 Then
                marketComboBox.SelectedIndex = 0
                If mediaComboBox.SelectedValue Is Nothing Then marketComboBox.SelectedValue = DBNull.Value
                If mediaComboBox.Text.ToUpper() = "CATALOG" Then adDateTypeInDatePicker.Focus()
            Else
                marketComboBox.Text = String.Empty
                marketComboBox.SelectedValue = DBNull.Value
                marketComboBox.SelectedIndex = -1
            End If

      If marketComboBox.SelectedValue Is Nothing _
        OrElse mediaComboBox.SelectedValue Is Nothing _
      Then
        requiredRetailersDataGridView.DataSource = Nothing
        Exit Sub
      ElseIf Integer.TryParse(marketComboBox.SelectedValue.ToString(), marketId) = False Then
        marketId = 0
      ElseIf Integer.TryParse(mediaComboBox.SelectedValue.ToString(), mediaId) = False Then
        mediaId = 0
      End If

      If mediaId = 0 OrElse marketId = 0 Then
        MessageBox.Show("Unable to get Market and Media information. Cannot load list of required Retailers." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Else
        marketComboBox_SelectedValueChanged(Nothing, Nothing)
      End If
            marketComboBox.SelectedIndex = -1
        End Sub

        Private Sub marketComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles marketComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.S And ByPassCheckBox.Checked = True Then
                checkInNewButton.Enabled = True
                checkInSameButton.Enabled = True
                checkInNewAndIndexButton.Enabled = True
                checkInSameAndIndexButton.Enabled = True
                newRetailerButton.Enabled = True
                ropCheckInButton.Enabled = True
            End If
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

    Private Sub marketComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles marketComboBox.SelectedValueChanged
      Dim isValidForFlash As Boolean
            Dim mediaId, marketId, retailerId As Integer
            Dim mediaName As String


      If marketComboBox.SelectedValue Is Nothing _
        OrElse mediaComboBox.SelectedValue Is Nothing _
      Then
        requiredRetailersDataGridView.DataSource = Nothing
        Exit Sub
      ElseIf Integer.TryParse(marketComboBox.SelectedValue.ToString(), marketId) = False Then
        marketId = 0
      ElseIf Integer.TryParse(mediaComboBox.SelectedValue.ToString(), mediaId) = False Then
        mediaId = 0
      End If

      If marketId = 0 Then
        MessageBox.Show("Unable to find Market. Cannot load list of Publications and required Retailers." _
                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        newspaperComboBox.DataSource = Nothing
        requiredRetailersDataGridView.DataSource = Nothing

      ElseIf mediaId = 0 OrElse marketId = 0 Then
        MessageBox.Show("Unable to find Market and Media information. Cannot load list of required Retailers." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        requiredRetailersDataGridView.DataSource = Nothing

      End If

            If mediaId = 0 OrElse marketId = 0 Then Exit Sub

            Dim mediaAdapter As EnvelopeContentDataSetTableAdapters.MediaTableAdapter
            mediaAdapter = New EnvelopeContentDataSetTableAdapters.MediaTableAdapter
            Try

                Select Case CType(mediaAdapter.GetIndIgnorePublication(mediaId), Integer)
                    Case 1
                        Processor.LoadNAPublication(marketId)
                    Case Else
                        Processor.LoadPublicationFor(marketId)
                End Select
            Catch ex As System.Data.SqlClient.SqlException
                Trace.TraceError("EnvelopeContentCheckInForm.marketComboBox_SelectedValueChanged():Unable to load publications. Message=" + ex.Message, New Object() {"MediaId=", mediaId, "MktId=", marketId, "ErrorClass=", ex.Class, "Procedure=", ex.Procedure, "LineNumber=", ex.LineNumber, "SQLErrorNumber=", ex.State, "ErrorNumber=", ex.Number, "Source=", ex.Source})
                MessageBox.Show("Error has occurred while loading Publications. Unable to load Publications." + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Processor.Data.Publication.Rows.Clear()
            Catch ex As Exception
                Trace.TraceError("EnvelopeContentCheckInForm.marketComboBox_SelectedValueChanged():Unknown error has occurred, while loading publications. Message=" + ex.Message, New Object() {"MediaId=", mediaId, "MktId=", marketId})
                MessageBox.Show("Unknown error has occurred while loading Publications. Unable to load Publications.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Processor.Data.Publication.Rows.Clear()
            End Try

      If Processor.Data.Publication.Count = 1 Then
        newspaperComboBox.SelectedIndex = 0
        adDateTypeInDatePicker.Focus()
      End If

      If retailerComboBox.SelectedValue Is Nothing Then
        retailerId = -1
      Else
        retailerId = CType(retailerComboBox.SelectedValue, Integer)
      End If

      Try
                Dim SenderExpectationCtr As Integer = Processor.LoadRetailersSenderExpectation(_SenderID, mediaId, marketId)
                If SenderExpectationCtr = 0 Then
                    Processor.LoadExpectedRetailers(mediaId, marketId)
                    Processor.LoadRetailers(mediaId, marketId)
                Else
                    Processor.LoadExpectedRetailers(mediaId, marketId, _SenderID)
                End If
      Catch ex As System.Data.SqlClient.SqlException
        Trace.TraceError("EnvelopeContentCheckInForm.marketComboBox_SelectedValueChanged():Unable to load Retailers. Message=" + ex.Message, New Object() {"MediaId=", mediaId, "MktId=", marketId, "RetId=", retailerId, "ErrorClass=", ex.Class, "Procedure=", ex.Procedure, "LineNumber=", ex.LineNumber, "SQLErrorNumber=", ex.State, "ErrorNumber=", ex.Number, "Source=", ex.Source})
        MessageBox.Show("Error has occurred while loading Retailers. Unable to load Retailers.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch ex As Exception
        Trace.TraceError("EnvelopeContentCheckInForm.marketComboBox_SelectedValueChanged():Unknown error has occurred, while loading Retailers. Message=" + ex.Message, New Object() {"MediaId=", mediaId, "MktId=", marketId, "RetId=", retailerId})
        MessageBox.Show("Unknown error has occurred while loading Retailers. Unable to load Retailers.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      retailerLabel.Text = "Retailer"
      If retailerId < 1 Then
        retailerComboBox.SelectedValue = DBNull.Value
      Else
        retailerComboBox.SelectedValue = retailerId
      End If

      isValidForFlash = Processor.IsValidFlashRetMkt(retailerId, marketId)
      If isValidForFlash = False Then flashCheckBox.Checked = isValidForFlash
      flashCheckBox.Enabled = isValidForFlash

    End Sub


#Region " requiredRetailersDataGridView related event handlers "


    Private Sub SetAutoFilterHeader()

      ' Continue only if the data source has been set.
      If requiredRetailersDataGridView.DataSource Is Nothing Then
        Return
      End If

      ' Add the AutoFilter header cell to each column.
      For Each col As DataGridViewColumn In requiredRetailersDataGridView.Columns
        col.HeaderCell = New  _
            DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell)
      Next

    End Sub


    ' Displays the drop-down list when the user presses 
    ' ALT+DOWN ARROW or ALT+UP ARROW.
    Private Sub requiredRetailersDataGridView_KeyDown _
        (ByVal sender As Object, ByVal e As KeyEventArgs) _
        Handles requiredRetailersDataGridView.KeyDown

      If e.Alt AndAlso (e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Up) Then

        Dim filterCell As DataGridViewAutoFilterColumnHeaderCell = _
            TryCast(requiredRetailersDataGridView.CurrentCell.OwningColumn.HeaderCell,  _
            DataGridViewAutoFilterColumnHeaderCell)
        If filterCell IsNot Nothing Then
          filterCell.ShowDropDownList()
          e.Handled = True
        End If

      End If

    End Sub

    ' Updates the filter status label. 
    Private Sub requiredRetailersDataGridView_DataBindingComplete _
        (ByVal sender As Object, ByVal e As DataGridViewBindingCompleteEventArgs) _
        Handles requiredRetailersDataGridView.DataBindingComplete

      Dim filterStatus As String = DataGridViewAutoFilterColumnHeaderCell.GetFilterStatus(requiredRetailersDataGridView)
      'If String.IsNullOrEmpty(filterStatus) Then
      '  showAllLabel.Visible = False
      '  filterStatusLabel.Visible = False
      'Else
      '  showAllLabel.Visible = True
      '  filterStatusLabel.Visible = True
      '  filterStatusLabel.Text = filterStatus
      'End If

    End Sub


#End Region

        Private Sub retailerComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles retailerComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.S And ByPassCheckBox.Checked = True Then
                checkInNewButton.Enabled = True
                checkInSameButton.Enabled = True
                checkInNewAndIndexButton.Enabled = True
                checkInSameAndIndexButton.Enabled = True
                newRetailerButton.Enabled = True
                ropCheckInButton.Enabled = True
            End If
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub


    Private Sub retailerComboBox_KeyUp _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles retailerComboBox.KeyUp
      Dim loadAllRetailers As Boolean?
      Dim mediaId, marketId As Integer


      If retailerComboBox.Tag Is Nothing AndAlso e.Control AndAlso e.KeyCode = Keys.R Then
        mediaId = -1 : marketId = -1 : loadAllRetailers = True
        retailerComboBox.Tag = "All"
        retailerLabel.Text = "Retailer (All)"

      ElseIf retailerComboBox.Tag IsNot Nothing AndAlso retailerComboBox.Tag.ToString().ToUpper() = "ALL" _
        AndAlso e.Control AndAlso e.KeyCode = Keys.R _
      Then
        If Integer.TryParse(mediaComboBox.SelectedValue.ToString(), mediaId) = False Then
          mediaId = -1
        ElseIf Integer.TryParse(marketComboBox.SelectedValue.ToString(), marketId) = False Then
          marketId = -1
        End If
        loadAllRetailers = False
        retailerComboBox.Tag = Nothing
        retailerLabel.Text = "Retailer"
      End If

      If loadAllRetailers.HasValue = False Then Exit Sub

      Try
        If loadAllRetailers Then
          Processor.LoadRetailers()
        Else
          Processor.LoadRetailers(mediaId, marketId)
        End If
      Catch ex As System.Data.SqlClient.SqlException
        Trace.TraceError("EnvelopeContentCheckInForm.retailerComboBox_KeyUp():Unable to load Retailers. Message=" + ex.Message, New Object() {"MediaId=", mediaId, "MktId=", marketId, "loadAllRetailers=", loadAllRetailers, "Tag=", retailerComboBox.Tag, "ControlKey=", e.Control, "KeyCode=", e.KeyCode.ToString(), "ErrorClass=", ex.Class, "Procedure=", ex.Procedure, "LineNumber=", ex.LineNumber, "SQLErrorNumber=", ex.State, "ErrorNumber=", ex.Number, "Source=", ex.Source})
        MessageBox.Show("Error has occurred while loading Retailers. Unable to load Retailers.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch ex As Exception
        Trace.TraceError("EnvelopeContentCheckInForm.retailerComboBox_KeyUp():Unknown error has occurred, while loading Retailers. Message=" + ex.Message, New Object() {"MediaId=", mediaId, "MktId=", marketId, "loadAllRetailers=", loadAllRetailers, "Tag=", retailerComboBox.Tag, "ControlKey=", e.Control, "KeyCode=", e.KeyCode.ToString()})
        MessageBox.Show("Unknown error has occurred while loading Retailers. Unable to load Retailers.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

    End Sub

    Private Sub retailerComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles retailerComboBox.SelectedValueChanged
      Dim isValidForFlash As Boolean
      Dim marketId, retailerId As Integer


      If marketComboBox.SelectedValue Is Nothing _
        OrElse Integer.TryParse(marketComboBox.SelectedValue.ToString(), marketId) = False _
      Then
        marketId = -1
      End If

      If retailerComboBox.SelectedValue Is Nothing _
        OrElse Integer.TryParse(retailerComboBox.SelectedValue.ToString(), retailerId) = False _
      Then
        retailerId = -1
      End If

      isValidForFlash = Processor.IsValidFlashRetMkt(retailerId, marketId)
      If isValidForFlash = False Then flashCheckBox.Checked = isValidForFlash
      flashCheckBox.Enabled = isValidForFlash

    End Sub

    Private Sub retailerComboBox_Validating _
        (ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles retailerComboBox.Validating
      Dim isRequired As Boolean
      Dim retailerId As Integer


      If retailerComboBox.SelectedValue Is Nothing Then Exit Sub

      retailerId = CType("0" + retailerComboBox.SelectedValue.ToString(), Integer)
      isRequired = Processor.IsRetailerExpectedRetailer(retailerId)
      ShowTradeclassForRetailer(retailerId)

      multipleOccurrencesCheckBox.Enabled = isRequired
            'checkInNewAndIndexButton.Enabled = isRequired
            'checkInSameAndIndexButton.Enabled = isRequired
      flashCheckBox.Enabled = isRequired AndAlso flashCheckBox.Enabled  'To avoid overriding valid for Flash check.
      printLabelButton.Enabled = (isRequired AndAlso Me.FormState <> FormStateEnum.Insert)
            'newRetailerButton.Enabled = isRequired
            ' ropCheckInButton.Enabled = isRequired
            'wrongVersionButton.Enabled = isRequired
            'checkInNewButton.Enabled = isRequired
            'checkInSameButton.Enabled = isRequired

      If isRequired Then
        ShowCommentsForExpectedRetailer(retailerId)
        ShowPriorityForExpectedRetailer(retailerId)
      Else
        checkInNewButton.Focus()
      End If

    End Sub

    Private Sub requiredRetailersDataGridView_CellDoubleClick _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles requiredRetailersDataGridView.CellDoubleClick
      Dim cm As CurrencyManager
      Dim tempRow As EnvelopeContentDataSet.vwExpectedRetRow


      'If user has clicked on column header for sorting
      If e.RowIndex < 0 Then Exit Sub

      cm = CType(Me.BindingContext(requiredRetailersDataGridView.DataSource), CurrencyManager)
      tempRow = CType(CType(cm.Current, System.Data.DataRowView).Row, EnvelopeContentDataSet.vwExpectedRetRow)
      cm = Nothing

      retailerComboBox.SelectedValue = tempRow.RetId
      ShowTradeclassForRetailer(tempRow.RetId)
      ShowCommentsForExpectedRetailer(tempRow.RetId)
      ShowPriorityForExpectedRetailer(tempRow.RetId)

      tempRow = Nothing

      flashCheckBox.Focus()

    End Sub

    Private Sub vehicleIdTextBox_KeyPress _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles vehicleIdTextBox.KeyPress


      '3 = Copy, 22 = Paste, 24 = Cut and 8 = Backspace
      If Microsoft.VisualBasic.AscW(e.KeyChar) = 3 _
        OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 22 _
        OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 24 _
        OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 8 _
      Then
        Exit Sub
      End If

      If Microsoft.VisualBasic.AscW(e.KeyChar) = 13 Then
        gotoButton.PerformClick()

      ElseIf Not (e.KeyChar = Microsoft.VisualBasic.ChrW(8)) _
        AndAlso (Not (e.KeyChar > Microsoft.VisualBasic.ChrW(47) _
                      AndAlso e.KeyChar < Microsoft.VisualBasic.ChrW(58))) _
      Then
        e.Handled = True
      End If

    End Sub

    Private Sub flashCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles flashCheckBox.CheckedChanged
      Dim retailerId As Integer

      If retailerComboBox.SelectedValue Is Nothing Then
        retailerId = -1
      Else
        retailerId = CType(retailerComboBox.SelectedValue, Integer)
      End If

      nationalCheckBox.Enabled = (flashCheckBox.Checked And Processor.IsValidFlashNational(retailerId))
      If flashCheckBox.Checked = False Then nationalCheckBox.Checked = False
    End Sub

    Private Sub checkInButton_Click _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles checkInNewButton.Click, checkInSameButton.Click
      Dim dupcheckResponse As DuplicateCheckUserResponse
      Dim tempRow As EnvelopeContentDataSet.vwCircularRow


      If AreInputsValid() = False Then Exit Sub

      If Me.IsWrongVersion = False Then
        dupcheckResponse = CheckForDuplication(CType(marketComboBox.SelectedValue, Integer) _
                                               , CType(newspaperComboBox.SelectedValue, Integer), True, FORM_NAME)
        If dupcheckResponse = DuplicateCheckUserResponse.Closed Then Exit Sub
      End If

      If Me.FormState = FormStateEnum.Insert Then
        tempRow = Processor.CreateNew()
      Else
        tempRow = Processor.Data.vwCircular(0)
      End If

      'Do not print barcode label, if vehicle is duplicate.
      If dupcheckResponse = DuplicateCheckUserResponse.Duplicate Then
        PrintBarcode = False
      ElseIf Me.FormState = FormStateEnum.Edit Then
        'While editing, if any of the parameters printed on barcode label has 
        'changed, barcode label should get printed automatically once record 
        'is saved successfully.
        PrintBarcode = ((tempRow.BreakDt <> CType(adDateTypeInDatePicker.Text, Date) _
                         OrElse tempRow.RetId <> CType(retailerComboBox.SelectedValue, Integer) _
                         OrElse tempRow.MktId <> CType(marketComboBox.SelectedValue, Integer)))
      Else
        Me.PrintBarcode = True
      End If

      SetColumnValues(tempRow, dupcheckResponse)
      If Me.FormState = FormStateEnum.Insert Then Processor.Add(tempRow)

      If sender Is checkInNewButton Then
        Me.IsSame = False
      Else
        Me.IsSame = True
      End If

      Me.CanProceedForIndexing = Not (dupcheckResponse = DuplicateCheckUserResponse.Duplicate _
                                      OrElse dupcheckResponse = DuplicateCheckUserResponse.Review _
                                      OrElse dupcheckResponse = DuplicateCheckUserResponse.Unknown)

      Try
        Processor.Save()
      Catch ex As System.ApplicationException
        Trace.TraceWarning("EnvelopeContentCheckInForm.checkInButton_Click():Message=" + ex.Message, New Object() {"FormState=", Me.FormState, "Row=", tempRow, "DupCheckResponse=", dupcheckResponse, "PrintBarcode=", PrintBarcode, "IsSame=", Me.IsSame, "CanProceedForIndexing=", Me.CanProceedForIndexing, "IsWrongVersion=", Me.IsWrongVersion})
            Catch ex As System.Data.SqlClient.SqlException
                MsgBox(Err.Description)
                Trace.TraceError("EnvelopeContentCheckInForm.checkInButton_Click():Unable save vehicle. Message=" + ex.Message, New Object() {"FormState=", Me.FormState, "Row=", tempRow, "DupCheckResponse=", dupcheckResponse, "PrintBarcode=", PrintBarcode, "IsSame=", Me.IsSame, "CanProceedForIndexing=", Me.CanProceedForIndexing, "IsWrongVersion=", Me.IsWrongVersion, "ErrorClass=", ex.Class, "Procedure=", ex.Procedure, "LineNumber=", ex.LineNumber, "SQLErrorNumber=", ex.State, "ErrorNumber=", ex.Number, "Source=", ex.Source})
                MessageBox.Show("Error has occurred while saving vehicle. Unable to save vehicle.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch ex As Exception
        Trace.TraceError("EnvelopeContentCheckInForm.checkInButton_Click():Unknown error has occurred, while saving vehicle. Message=" + ex.Message, New Object() {"FormState=", Me.FormState, "Row=", tempRow, "DupCheckResponse=", dupcheckResponse, "PrintBarcode=", PrintBarcode, "IsSame=", Me.IsSame, "CanProceedForIndexing=", Me.CanProceedForIndexing, "IsWrongVersion=", Me.IsWrongVersion})
        MessageBox.Show("Unknown error has occurred while saving vehicle. Unable to save vehicle.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

    End Sub

    Private Sub checkInAndIndexButton_Click _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles checkInNewAndIndexButton.Click, checkInSameAndIndexButton.Click
      Dim myIndexForm As New IndexForm


      If sender Is checkInNewAndIndexButton Then
        checkInButton_Click(checkInNewButton, e)
      Else
        checkInButton_Click(checkInSameButton, e)
      End If

      If Me.CanProceedForIndexing = False Then Exit Sub

      If vehicleIdTextBox.Text <> "" Then
        myIndexForm = New UI.IndexForm
        myIndexForm.Init(FormStateEnum.View)
        myIndexForm.ApplyUserCredentials()
        myIndexForm.Show()
        myIndexForm.Hide()
        myIndexForm.findVehicleIdTextBox.Text = vehicleIdTextBox.Text
        myIndexForm.LoadVehicle()
        myIndexForm.Show()
        myIndexForm.SetInputFocus()
        myIndexForm.Hide()
        myIndexForm.ShowDialog(Me)
        myIndexForm.Dispose()
        myIndexForm = Nothing
      End If

    End Sub

    Private Sub printLabelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles printLabelButton.Click
      Dim vehicleRow As EnvelopeContentDataSet.vwCircularRow


      If Processor.Data.vwCircular.Count = 0 Then
        MessageBox.Show("Load Vehicle information to print its label.", ProductName, _
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Else
        vehicleRow = Processor.Data.vwCircular(0)
        PrintBarcodeLabel(vehicleRow)
        vehicleRow = Nothing
      End If

    End Sub

    Private Sub ropCheckInButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ropCheckInButton.Click

      'Allow user to check-in for rop, only while creating vehicle and not while editing vehicle.
      If Me.FormState = FormStateEnum.Edit Then Exit Sub


      Dim ropCheckIn As PublicationCheckInForm = New PublicationCheckInForm()


      ropCheckIn.MdiParent = Me.MdiParent
      ropCheckIn.Init(FormStateEnum.Insert)
      ropCheckIn.ApplyUserCredentials()

      If Processor.Data.EnvelopeSender.Count > 0 Then _
        ropCheckIn.senderComboBox.SelectedValue = Processor.Data.EnvelopeSender(0).SenderId
      If marketComboBox.SelectedValue IsNot Nothing Then _
        ropCheckIn.marketComboBox.SelectedValue = marketComboBox.SelectedValue
      If newspaperComboBox.SelectedValue IsNot Nothing Then _
        ropCheckIn.newspaperComboBox.SelectedValue = newspaperComboBox.SelectedValue

      ropCheckIn.Show()

    End Sub

    Private Sub gotoButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gotoButton.Click
      Dim vehicleId As Integer


      Me.EnvelopeId = -1
      Me.PrintBarcode = False

      If Integer.TryParse(vehicleIdTextBox.Text, vehicleId) = False Then
        MessageBox.Show("Specify valid VehicleId.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Else
        Try
          Processor.LoadVehicle(vehicleId, FORM_NAME)
        Catch ex As System.Data.SqlClient.SqlException
          Trace.TraceError("EnvelopeContentCheckInForm.gotoButton_Click():Unable load vehicle. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, "FormName=", FORM_NAME, "ErrorClass=", ex.Class, "Procedure=", ex.Procedure, "LineNumber=", ex.LineNumber, "SQLErrorNumber=", ex.State, "ErrorNumber=", ex.Number, "Source=", ex.Source})
          MessageBox.Show("Error has occurred while loading vehicle. Unable to load vehicle.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
          Trace.TraceError("EnvelopeContentCheckInForm.gotoButton_Click():Unknown error has occurred, while loading vehicle. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, "FormName=", FORM_NAME})
          MessageBox.Show("Unknown error has occurred while loading vehicle. Unable to load vehicle.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
      End If

    End Sub

    Private Sub newRetailerButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles newRetailerButton.Click
      Dim envelopeSender, retailerName As String


      If senderLabel.Text.Trim.Length = 0 Then
        MessageBox.Show("Please load Envelope information.", ProductName, _
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        ClearAllInputs()
        RemoveAllErrorProviders()

        Me.FormState = FormStateEnum.View
        ShowHideControls(Me.FormState)
        EnableDisableControls(Me.FormState)
        envelopeIdTextBox.Focus()
        Exit Sub

        'ElseIf Integer.TryParse(envelopeIdTextBox.Text, envelopeId) = False Then
      ElseIf Processor.Data.EnvelopeSender.Count = 0 Then
        MessageBox.Show("Provide a valid Envelope Id.", ProductName, _
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        ClearAllInputs()
        RemoveAllErrorProviders()
        Me.FormState = FormStateEnum.View
        ShowHideControls(Me.FormState)
        EnableDisableControls(Me.FormState)
        Exit Sub
      End If


#If DEBUG Then

      If MessageBox.Show("Do you want to print?", Application.ProductName, MessageBoxButtons.YesNo _
                         , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No _
      Then
        Exit Sub
      End If

#End If


      If retailerComboBox.SelectedValue Is Nothing _
        AndAlso retailerComboBox.SelectedIndex < 0 _
        AndAlso retailerComboBox.Text.Trim().Length > 0 _
      Then
        retailerName = retailerComboBox.Text
      End If

      envelopeSender = Processor.Data.EnvelopeSender(0).Name
      Try
        Processor.PrintBarcodeForNewRetailer(Me.EnvelopeId, envelopeSender, retailerName)
      Catch ex As Exception
        Trace.TraceError("EnvelopeContentCheckInForm.newRetailerButton_Click():Unknown error has occurred, while printing barcode label. Message=" + ex.Message, New Object() {"EnvelopeId=", Me.EnvelopeId, "EnvelopeSender=", envelopeSender, "RetailerName=", retailerName})
        MessageBox.Show("Error has occurred while printing barcode label for New Retailer.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      envelopeSender = Nothing

      ClearInputsForSame()
      adDateTypeInDatePicker.Focus()
      adDateTypeInDatePicker.SelectAll()

    End Sub

    Private Sub deleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deleteButton.Click
      Dim vehicleId As Integer
      Dim userResponse As DialogResult


      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        MessageBox.Show("Load Vehicle to delete it.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      userResponse = MessageBox.Show("Are you sure you want to delete Vehicle " + vehicleId.ToString() + "?" _
                                     , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                     , MessageBoxDefaultButton.Button2)

      If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

      Try
        Processor.Delete(vehicleId)
      Catch ex As Exception
        Trace.TraceError("EnvelopeContentCheckInForm.deleteButton_Click():Unknown error has occurred, while deleting vehicle. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId})
        MessageBox.Show("Error has occurred while deleting vehicle.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        vehicleId = 0
      End Try

      If vehicleId = 0 Then
        Me.FormState = FormStateEnum.Insert
        ClearAllInputs()
        ShowHideControls(Me.FormState)
        EnableDisableControls(Me.FormState)
      End If

    End Sub

    Private Sub downloadAdButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles downloadAdButton.Click
      Dim envelopeId As Integer
      Dim envProc As Processors.Envelope


      envProc = New Processors.Envelope()
      envProc.Initialize()
      envProc.LoadDownloadEnvelope()
      If envProc.Data.Envelope.Count = 0 Then
        envProc.CreateNewDownloadAd(FORM_NAME)
      End If

      If envProc.Data.Envelope.Count = 0 Then
        MessageBox.Show("Unable to create new Envelope for Download Sender.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      envelopeId = envProc.Data.Envelope(0).EnvelopeId()

      envProc.Dispose()
      envProc = Nothing

      envelopeIdTextBox.Text = envelopeId.ToString()
      loadButton.PerformClick()

    End Sub

    Private Sub wrongVersionButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles wrongVersionButton.Click
      Dim userResponse As DialogResult


      userResponse = MessageBox.Show("Are you sure this is the wrong version?", ProductName _
                                   , MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

      Me.IsWrongVersion = True

      checkInSameButton.PerformClick()

        End Sub

        Private Sub EnvelopeContentCheckInForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If e.CloseReason = CloseReason.UserClosing And isClosedByButton = False Then
                If (MessageBox.Show("Are you sure you want to close this form?", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                    e.Cancel = True
                End If
            End If
        End Sub


    Private Sub EnvelopeContentCheckInForm_InitializingForm() Handles Me.InitializingForm

      Me.StatusMessage = "Loading information. This may take some time. Please wait..."

    End Sub

    Private Sub EnvelopeContentCheckInForm_FormInitialized() Handles Me.FormInitialized

      Me.StatusMessage = String.Empty

    End Sub


#Region " Processor Events "


    Private Sub m_envelopeContentProcessor_PrintingBarcode(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_envelopeContentProcessor.PrintingBarcode

      Me.StatusMessage = "Printing barcode label for vehicle."

    End Sub

    Private Sub m_envelopeContentProcessor_BarcodePrinted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeContentProcessor.BarcodePrinted

      Me.StatusMessage = String.Empty

    End Sub


    Private Sub m_envelopeContentProcessor_LoadingEnvelopeSender(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_envelopeContentProcessor.LoadingEnvelopeSender

      Me.StatusMessage = "Loading envelope sender information..."

    End Sub

    Private Sub m_envelopeContentProcessor_EnvelopeSenderLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeContentProcessor.EnvelopeSenderLoaded
      Dim envelopeId As Integer
      Dim senderName As String
      Dim envelopeRow As EnvelopeContentDataSet.EnvelopeSenderRow


      If e.Data.Contains("EnvelopeId") = False OrElse e.Data.Contains("EnvelopeSenderRow") = False Then
        MessageBox.Show("Envelope sender found, but unable to load sender information." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      If Integer.TryParse(e.Data("EnvelopeId").ToString(), envelopeId) = False Then
        envelopeId = 0
      End If

      envelopeRow = CType(e.Data("EnvelopeSenderRow"), EnvelopeContentDataSet.EnvelopeSenderRow)
      If envelopeRow.IsNameNull() Then
        senderName = String.Empty
      Else
        senderName = envelopeRow.Name
      End If

      'Processor.LoadMarketsForEnvelope(envelopeId) 'Markets are loaded based on media type.
      Processor.Data.Ret.Clear()
      retailerLabel.Text = "Retailer"

      ClearAllInputs()
      RemoveAllErrorProviders()
      Processor.Data.vwCircular.Clear()

      Me.FormState = FormStateEnum.Insert
      EnableDisableControls(Me.FormState)
      ShowHideControls(Me.FormState)

      Me.EnvelopeId = envelopeId
      senderLabel.Text = "Loaded: " + envelopeId.ToString() + "; Sent By: " + senderName
      senderName = Nothing

      Me.StatusMessage = String.Empty

      mediaComboBox.Focus()

    End Sub

    Private Sub m_envelopeContentProcessor_EnvelopeSenderNotFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeContentProcessor.EnvelopeSenderNotFound
      Dim messageText As System.Text.StringBuilder
      Dim tempEnvId As String


      messageText = New System.Text.StringBuilder

      Me.StatusMessage = String.Empty

      tempEnvId = envelopeIdTextBox.Text
      messageText.Append("EnvelopeId " & tempEnvId & " not found.")
      messageText.Append(" Make sure envelope exist and has a valid Sender assigned to it.")
      messageText.Append(Environment.NewLine)
      messageText.Append("If Envelope exist with a valid Sender, contact your entry administrator.")

      MessageBox.Show(messageText.ToString(), ProductName, _
                      MessageBoxButtons.OK, MessageBoxIcon.Error)
      ClearAllInputs()
      envelopeIdTextBox.Text = tempEnvId
      RemoveAllErrorProviders()
      Processor.Data.vwCircular.Clear()

      Me.FormState = FormStateEnum.View
      EnableDisableControls(Me.FormState)
      ShowHideControls(Me.FormState)

      envelopeIdTextBox.Focus()
      envelopeIdTextBox.SelectAll()

      messageText = Nothing

    End Sub


    Private Sub m_envelopeContentProcessor_LoadingExpectedRetailers(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_envelopeContentProcessor.LoadingExpectedRetailers

      Me.StatusMessage = "Loading list of expected retailers..."

      requiredRetailersDataGridView.SuspendLayout()
      requiredRetailersDataGridView.DataSource = Nothing

    End Sub

    Private Sub m_envelopeContentProcessor_ExpectedRetailersLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeContentProcessor.ExpectedRetailersLoaded

      Me.StatusMessage = "Preparing list of expected retailers for selected market and media."

      requiredRetailersDataGridView.DataSource = New BindingSource(Processor.Data, "vwExpectedRet")
      SetAutoFilterHeader()
      PrepareRequiredRetailersDataGridView()
      requiredRetailersDataGridView.ResumeLayout(False)

      Me.StatusMessage = String.Empty

    End Sub


    Private Sub m_envelopeContentProcessor_LoadingMarkets() Handles m_envelopeContentProcessor.LoadingMarkets

      Me.StatusMessage = "Loading Markets. This may take some time, please wait..."

    End Sub

    Private Sub m_envelopeContentProcessor_MarketsLoaded() Handles m_envelopeContentProcessor.MarketsLoaded

      Me.StatusMessage = String.Empty

    End Sub


    Private Sub m_envelopeContentProcessor_LoadingPublications() Handles m_envelopeContentProcessor.LoadingPublications

      Me.StatusMessage = "Loading Publications for selected market. This may take time, please wait..."

    End Sub

    Private Sub m_envelopeContentProcessor_PublicationsLoaded() Handles m_envelopeContentProcessor.PublicationsLoaded

      newspaperComboBox.ValueMember = "PublicationId"
      newspaperComboBox.DisplayMember = "Descrip"
      newspaperComboBox.DataSource = Processor.Data.Publication

      If Processor.Data.Publication.Count = 1 Then
        newspaperComboBox.SelectedValue = Processor.Data.Publication(0).PublicationId
      Else
        newspaperComboBox.SelectedValue = DBNull.Value
      End If

      Me.StatusMessage = String.Empty

    End Sub


    Private Sub m_envelopeContentProcessor_LoadingVehicle(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_envelopeContentProcessor.LoadingVehicle

      Me.StatusMessage = "Loading vehicle. This may take time, please wait..."

    End Sub

    Private Sub m_envelopeContentProcessor_InvalidVehicleStatus(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeContentProcessor.InvalidVehicleStatus

      Me.StatusMessage = String.Empty

      If e.Data.Contains("ErrorMessage") = False Then
        MessageBox.Show("Vehicle cannot be loaded because it has the status of: Unknown." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      Dim statusText As String = e.Data("ErrorMessage").ToString()

      MessageBox.Show("Vehicle cannot be loaded because it has the status of: " + statusText _
                      , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

      statusText = Nothing

    End Sub

    Private Sub m_envelopeContentProcessor_VehicleNotFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeContentProcessor.VehicleNotFound
      Dim vehicleId As String


      Me.StatusMessage = String.Empty

      vehicleId = e.Data("VehicleId").ToString()

      ClearAllInputs()
      RemoveAllErrorProviders()

      Me.FormState = FormStateEnum.View
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

      vehicleIdTextBox.Text = vehicleId
      vehicleIdTextBox.Focus()
      vehicleIdTextBox.SelectAll()

      MessageBox.Show("Vehicle " + vehicleId + " not found.", ProductName _
                      , MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub m_envelopeContentProcessor_VehicleLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeContentProcessor.VehicleLoaded
      Dim isRequiredRetailer As Boolean
      Dim vehicleRow As EnvelopeContentDataSet.vwCircularRow


      Me.StatusMessage = String.Empty

      If e.Data.Contains("VehicleRow") = False Then
        MessageBox.Show("Vehicle found but, unable to load vehicle information." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If

      vehicleRow = CType(e.Data("VehicleRow"), EnvelopeContentDataSet.vwCircularRow)

      ClearAllInputs()
      RemoveAllErrorProviders()

      ShowRecord(vehicleRow)

      'Enable/Disable controls based on whether the retailer is expected retailer or not.
      isRequiredRetailer = Processor.IsRetailerExpectedRetailer(vehicleRow.RetId)
      multipleOccurrencesCheckBox.Enabled = isRequiredRetailer
      flashCheckBox.Enabled = isRequiredRetailer
      checkInNewAndIndexButton.Enabled = isRequiredRetailer
      checkInSameAndIndexButton.Enabled = isRequiredRetailer
      newRetailerButton.Enabled = isRequiredRetailer
      printLabelButton.Enabled = (isRequiredRetailer AndAlso Me.FormState <> FormStateEnum.Insert)
      ropCheckInButton.Enabled = isRequiredRetailer
      wrongVersionButton.Enabled = isRequiredRetailer

      vehicleRow = Nothing

      Me.FormState = FormStateEnum.Edit
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

    End Sub


    Private Sub m_envelopeContentProcessor_ValidatingInputs(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_envelopeContentProcessor.ValidatingColumnValues

      Me.StatusMessage = "Validating user inputs..."

    End Sub

    Private Sub m_envelopeContentProcessor_InputsValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeContentProcessor.ColumnValuesValidated

      Me.StatusMessage = String.Empty

    End Sub

    Private Sub m_envelopeContentProcessor_InvalidInputExist(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeContentProcessor.InvalidColumnValueFound

      Me.StatusMessage = String.Empty

      If Processor.Data.Errors.Count > 0 Then
        ShowErrors(Processor.Data.Errors)
        Processor.Data.Errors.Clear()
        Exit Sub

      ElseIf Processor.Data.Warnings.Count > 0 Then
        If ShowWarnings(Processor.Data.Warnings) = Windows.Forms.DialogResult.Cancel Then
          Processor.Data.Warnings.Clear()
          Exit Sub
        End If

      End If

    End Sub


    Private Sub m_envelopeContentProcessor_VehicleDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeContentProcessor.VehicleDeleted

      MessageBox.Show("Vehicle " + e.Data("VehicleId").ToString() + " removed successfully." _
                      , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub


    Private Sub m_envelopeContentProcessor_Synchronizing(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_envelopeContentProcessor.Synchronizing

      Me.StatusMessage = "Saving information to database. This may take some time, please wait..."

    End Sub

    Private Sub m_envelopeContentProcessor_Synchronized(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeContentProcessor.Synchronized
      Dim isRequiredRetailer As Boolean
      Dim retailerId As Integer
      Dim vehicleId As String
      Dim tempRow As EnvelopeContentDataSet.vwCircularRow


      Me.StatusMessage = String.Empty

      If e.Data.Contains("SynchronizedRow") = False Then
        MessageBox.Show("Vehicle information saved successfuly but unable to supply the Vehicle" _
                        + " information to print barcode label.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If

      tempRow = CType(e.Data("SynchronizedRow"), EnvelopeContentDataSet.vwCircularRow)
      vehicleId = tempRow.VehicleId.ToString()

      UpdateVehicleIdForDupCheckFormLogId(tempRow.VehicleId, Me.DupcheckFormLogId)

      If Integer.TryParse(retailerComboBox.SelectedValue.ToString(), retailerId) = False Then
        isRequiredRetailer = flashCheckBox.Enabled
      Else
        isRequiredRetailer = Processor.IsRetailerExpectedRetailer(retailerId)
      End If

      If Me.PrintBarcode AndAlso isRequiredRetailer Then PrintBarcodeLabel(tempRow)

      Me.PrintBarcode = False

      If IsSame Then
        ClearInputsForSame()
        Me.FormState = FormStateEnum.Insert
        EnableDisableControls(Me.FormState)
        adDateTypeInDatePicker.Focus()
        adDateTypeInDatePicker.SelectAll()
      Else
        ClearAllInputs()
        Me.EnvelopeId = -1
        Me.FormState = FormStateEnum.Insert
        EnableDisableControls(Me.FormState)
        Processor.Data.Mkt.Clear()
        Processor.Data.Ret.Clear()
        envelopeIdTextBox.Focus()
      End If

      vehicleIdTextBox.Text = vehicleId

    End Sub


#End Region


        Private Sub mediaComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mediaComboBox.SelectedIndexChanged

        End Sub

        Private Sub marketComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles marketComboBox.SelectedIndexChanged

        End Sub

        Private Sub adDateTypeInDatePicker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adDateTypeInDatePicker.Load

        End Sub

        Private Sub ByPassCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ByPassCheckBox.CheckedChanged
            Dim isChecked As Boolean = True

            If ByPassCheckBox.Checked = False Then
                isChecked = False
                checkInNewButton.Enabled = True
                checkInSameButton.Enabled = True
                checkInNewAndIndexButton.Enabled = True
                checkInSameAndIndexButton.Enabled = True
                newRetailerButton.Enabled = True
                ropCheckInButton.Enabled = True
            Else
                isChecked = True
                checkInNewButton.Enabled = False
                checkInSameButton.Enabled = False
                checkInNewAndIndexButton.Enabled = False
                checkInSameAndIndexButton.Enabled = False
                newRetailerButton.Enabled = False
                ropCheckInButton.Enabled = False
            End If

            Processor.EnableDisableFilter(isChecked, EnvelopeId)
            mediaComboBox.SelectedIndex = -1
            marketComboBox.SelectedIndex = -1
            retailerComboBox.SelectedIndex = -1
            If Processor.Data.Mkt.Count > 0 Then Processor.Data.Mkt.Clear()
            If Processor.Data.Ret.Count > 0 Then Processor.Data.Ret.Clear()
        End Sub

        Private Sub newspaperComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles newspaperComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.S And ByPassCheckBox.Checked = True Then
                checkInNewButton.Enabled = True
                checkInSameButton.Enabled = True
                checkInNewAndIndexButton.Enabled = True
                checkInSameAndIndexButton.Enabled = True
                newRetailerButton.Enabled = True
                ropCheckInButton.Enabled = True
            End If
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub newspaperComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newspaperComboBox.SelectedIndexChanged

        End Sub

        Private Sub retailerComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles retailerComboBox.SelectedIndexChanged

        End Sub

        Private Sub flashCheckBox_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles flashCheckBox.Invalidated

        End Sub

        Private Sub flashCheckBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles flashCheckBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.S And ByPassCheckBox.Checked = True Then
                checkInNewButton.Enabled = True
                checkInSameButton.Enabled = True
                checkInNewAndIndexButton.Enabled = True
                checkInSameAndIndexButton.Enabled = True
                newRetailerButton.Enabled = True
                ropCheckInButton.Enabled = True
            End If
        End Sub

        Private Sub multipleOccurrencesCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles multipleOccurrencesCheckBox.CheckedChanged

        End Sub

        Private Sub multipleOccurrencesCheckBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles multipleOccurrencesCheckBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.S And ByPassCheckBox.Checked = True Then
                checkInNewButton.Enabled = True
                checkInSameButton.Enabled = True
                checkInNewAndIndexButton.Enabled = True
                checkInSameAndIndexButton.Enabled = True
                newRetailerButton.Enabled = True
                ropCheckInButton.Enabled = True
            End If
        End Sub

        Private Sub nationalCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nationalCheckBox.CheckedChanged

        End Sub

        Private Sub nationalCheckBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles nationalCheckBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.S And ByPassCheckBox.Checked = True Then
                checkInNewButton.Enabled = True
                checkInSameButton.Enabled = True
                checkInNewAndIndexButton.Enabled = True
                checkInSameAndIndexButton.Enabled = True
                newRetailerButton.Enabled = True
                ropCheckInButton.Enabled = True
            End If
        End Sub

        Private Sub ByPassCheckBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ByPassCheckBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.S And ByPassCheckBox.Checked = True Then
                checkInNewButton.Enabled = True
                checkInSameButton.Enabled = True
                checkInNewAndIndexButton.Enabled = True
                checkInSameAndIndexButton.Enabled = True
                newRetailerButton.Enabled = True
                ropCheckInButton.Enabled = True
            End If
        End Sub

        Private Sub commentsTextBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles commentsTextBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.S And ByPassCheckBox.Checked = True Then
                checkInNewButton.Enabled = True
                checkInSameButton.Enabled = True
                checkInNewAndIndexButton.Enabled = True
                checkInSameAndIndexButton.Enabled = True
                newRetailerButton.Enabled = True
                ropCheckInButton.Enabled = True
            End If
        End Sub

        Private Sub EnvelopeContentCheckInForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub
    End Class


End Namespace
