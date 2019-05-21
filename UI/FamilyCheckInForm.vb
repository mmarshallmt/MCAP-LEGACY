﻿Namespace UI

  Public Class FamilyCheckInForm
    Implements IForm, IDuplicateCheck


    ''' <summary>
    ''' This constant is used to assigning value to FormName column.
    ''' </summary>
    ''' <remarks></remarks>
    Private Const FORM_NAME As String = "Family Indexing"


#Region " Private structure to store selected market publication "

    Private Structure SelectedMktPub
      Dim MktId, PubId, VehicleId As Integer
      Dim MarketName, PublicationName, MktPubPages, MktVehicleIdPages As String

      Sub New(ByVal marketId As Integer, ByVal mktName As String, ByVal publicationId As Integer _
              , ByVal pubName As String, ByVal mktPubPgs As String, ByVal mktVehicleIdPgs As String _
              , ByVal updateVehicleId As Integer)
        MktId = marketId
        MarketName = mktName
        publicationId = publicationId
        PublicationName = pubName
        MktPubPages = mktPubPgs
        MktVehicleIdPages = mktVehicleIdPgs
        VehicleId = updateVehicleId
      End Sub

    End Structure

#End Region


    Private m_override As Boolean
    Private m_forReview As Boolean
    Private m_Duplicate As Boolean
    Private m_isPossibleDupFound As Boolean
    Private m_RetNeedsReload As Boolean
    Private m_tempVehicleId As Integer
    Private m_searchedVehicleId As Integer
    Private m_dupcheckFormId As Integer

    Private m_selectedMarketPublication As System.Collections.Generic.Dictionary(Of String, SelectedMktPub)
    Private WithEvents m_familyCheckInProcessor As Processors.FamilyCheckIn



    ''' <summary>
    ''' Gets family check-in processor.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property Processor() As Processors.FamilyCheckIn
      Get
        Return m_familyCheckInProcessor
      End Get
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
    ''' Clears all inputs on form.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub ClearAllInputs()
      MyBase.ClearAllInputs()
      m_tempVehicleId = 0
      adDateTypeInDatePicker.Clear()
      mediaComboBox.SelectedValue = DBNull.Value
      retailerComboBox.SelectedValue = DBNull.Value
      languageComboBox.SelectedValue = DBNull.Value
      marketCheckedListBox.Items.Clear()
      selectedMktPubListBox.Items.Clear()
      m_selectedMarketPublication.Clear()
      tradeclassValueLabel.Text = String.Empty
      eventComboBox.SelectedValue = DBNull.Value
      themeComboBox.SelectedValue = DBNull.Value
      startDateTypeInDatePicker.Clear()
      endDateTypeInDatePicker.Clear()
      couponIndCheckBox.Checked = False
      gotoVehicleIdTextBox.Text = String.Empty

    End Sub


    ''' <summary>
    ''' Enables/Disables input controls based on supplied values of formStatus.
    ''' </summary>
    ''' <param name="formStatus"></param>
    ''' <remarks></remarks>
    Protected Overrides Sub EnableDisableControls(ByVal formStatus As FormStateEnum)
      MyBase.EnableDisableControls(formStatus)

      Select Case formStatus
        Case FormStateEnum.View, FormStateEnum.Insert
          adDateTypeInDatePicker.Enabled = True
          mediaComboBox.Enabled = True
          retailerComboBox.Enabled = True
          languageComboBox.Enabled = True
          marketCheckedListBox.Enabled = True
          eventComboBox.Enabled = True
          themeComboBox.Enabled = True
          startDateTypeInDatePicker.Enabled = True
          endDateTypeInDatePicker.Enabled = True
          pagesButton.Enabled = True
          couponIndCheckBox.Enabled = True
          saveButton.Enabled = True

        Case FormStateEnum.Edit
          adDateTypeInDatePicker.Enabled = False
          mediaComboBox.Enabled = False
          retailerComboBox.Enabled = False
          languageComboBox.Enabled = True
          marketCheckedListBox.Enabled = False
          eventComboBox.Enabled = True
          themeComboBox.Enabled = True
          startDateTypeInDatePicker.Enabled = True
          endDateTypeInDatePicker.Enabled = True
          pagesButton.Enabled = True
          couponIndCheckBox.Enabled = True
          saveButton.Enabled = True

      End Select

    End Sub


    ''' <summary>
    ''' Clears existing items from Market checked list box and fills in checked 
    ''' list box with supplied row.
    ''' </summary>
    ''' <param name="mktRow"></param>
    ''' <remarks></remarks>
    Private Sub FillMarketCheckedListBox(ByVal mktRow As FamilyCheckInDataSet.MarketRow)

      Me.marketCheckedListBox.Items.Clear()
      Me.marketCheckedListBox.Items.Add(mktRow.MktPubPg)
      Me.marketCheckedListBox.SelectedIndex = -1

    End Sub

    ''' <summary>
    ''' Fills list of markets based on contents of supplied market table.
    ''' </summary>
    ''' <param name="marketDataTable"></param>
    ''' <remarks></remarks>
    Private Sub FillMarketCheckedListBox(ByVal marketDataTable As FamilyCheckInDataSet.MarketDataTable)
      Dim rowCounter As Integer


      Me.marketCheckedListBox.Items.Clear()
      If showVehicleIdRadioButton.Checked Then
        For rowCounter = 0 To marketDataTable.Rows.Count - 1
          Me.marketCheckedListBox.Items.Add(marketDataTable(rowCounter).MktVehicleIdPg)
        Next
      Else
        For rowCounter = 0 To marketDataTable.Rows.Count - 1
          Me.marketCheckedListBox.Items.Add(marketDataTable(rowCounter).MktPubPg)
        Next
      End If

      Me.marketCheckedListBox.SelectedIndex = -1

    End Sub


    ''' <summary>
    ''' Removes supplied combination from list.
    ''' </summary>
    ''' <param name="combinationString">Market name, to be removed from list.</param>
    ''' <remarks></remarks>
    Private Sub RemoveMarketFromList(ByVal combinationString As String)
      Dim foundFlag As Boolean
      Dim itemIndex As Integer
      Dim tempSelectedMP As SelectedMktPub
      Dim linqQuery As System.Collections.Generic.IEnumerable(Of SelectedMktPub)


      If m_selectedMarketPublication.Count = 0 Then Exit Sub

      foundFlag = False
      itemIndex = 0
      If showVehicleIdRadioButton.Checked Then
        linqQuery = From i In m_selectedMarketPublication.Values _
                    Select i _
                    Where i.MktVehicleIdPages = combinationString

      Else
        linqQuery = From i In m_selectedMarketPublication.Values _
                    Select i _
                    Where i.MktPubPages = combinationString
      End If

      If linqQuery.Count = 0 Then Exit Sub

      itemIndex = selectedMktPubListBox.FindStringExact(combinationString)
      If itemIndex < 0 Then Exit Sub

      selectedMktPubListBox.Items.RemoveAt(itemIndex)
      m_selectedMarketPublication.Remove(combinationString)

      itemIndex = Nothing
      tempSelectedMP = Nothing

    End Sub

    Private Sub RemoveVehicleFromSelection(ByVal vehicleId As Integer)
      Dim index As Integer
      Dim mktRow As FamilyCheckInDataSet.MarketRow


      mktRow = Processor.Data.Market.FindByVehicleId(vehicleId)
      If mktRow IsNot Nothing Then
        If showVehicleIdRadioButton.Checked Then
          index = marketCheckedListBox.FindStringExact(mktRow.MktVehicleIdPg)
        Else
          index = marketCheckedListBox.FindStringExact(mktRow.MktPubPg)
        End If
      End If

      mktRow = Nothing

      If index > 0 Then
        marketCheckedListBox.SetItemChecked(index, False)
      End If

    End Sub

    Private Function IsDuplicateMarket(ByVal marketRow As MCAP.FamilyCheckInDataSet.MarketRow, ByVal familyId As Integer) As Boolean
      Dim isDuplicate As Boolean
      Dim userResponse As System.Windows.Forms.DialogResult
      Dim messageText As System.Text.StringBuilder
      Dim msgBox As MCAP.UI.Controls.MessageBoxForm


      isDuplicate = False
      userResponse = Windows.Forms.DialogResult.None

      Processor.LoadVehiclesInFamily(marketRow.MktId, familyId)

      If Processor.Data.DuplicateMarketTable.Count = 0 Then Return False

      msgBox = New MCAP.UI.Controls.MessageBoxForm()
      messageText = New System.Text.StringBuilder

      If Processor.Data.DuplicateMarketTable(0).Status.ToUpper() = "QC COMPLETED" Then
        messageText.Append(Processor.Data.DuplicateMarketTable(0).VehicleId)
        messageText.Append(" has already been QCed with market ")
        messageText.Append(marketRow.Market)
        messageText.Append(". Mark ")
        messageText.Append(Processor.Data.DuplicateMarketTable(0).VehicleId)
        messageText.Append(" as duplicate?")
      Else
        messageText.Append(Processor.Data.DuplicateMarketTable(0).VehicleId)
        messageText.Append(" has already been indexed with market ")
        messageText.Append(marketRow.Market)
        messageText.Append(". Mark ")
        messageText.Append(Processor.Data.DuplicateMarketTable(0).VehicleId)
        messageText.Append(" as duplicate?")
      End If

      msgBox = New MCAP.UI.Controls.MessageBoxForm()
      With msgBox
        .Title = ProductName
        .Message = messageText.ToString()
        .MessageIcon = MessageBoxIcon.Question
        .Buttons.Add("Yes, and Index " + marketRow.VehicleId.ToString(), Windows.Forms.DialogResult.Yes)
        .Buttons.Add("No, and mark " + marketRow.VehicleId.ToString() + " as duplicate", Windows.Forms.DialogResult.No)
        .Buttons.Add("Cancel", Windows.Forms.DialogResult.Cancel)
        .Initialize()
        .StartPosition = FormStartPosition.CenterScreen
        userResponse = .ShowDialog(Me)
      End With
      msgBox.Dispose()
      msgBox = Nothing

      If userResponse = Windows.Forms.DialogResult.Cancel Then
        isDuplicate = True
      ElseIf userResponse = Windows.Forms.DialogResult.Yes Then
        Processor.SetVehicleStatusAsDuplicate(Processor.Data.DuplicateMarketTable(0).VehicleId, FORM_NAME)
        isDuplicate = False
      ElseIf userResponse = Windows.Forms.DialogResult.No Then
        Processor.SetVehicleStatusAsDuplicate(marketRow.VehicleId, FORM_NAME)
        RemoveVehicleFromSelection(marketRow.VehicleId)
        isDuplicate = True
      End If

      messageText.Remove(0, messageText.Length)
      messageText = Nothing


      Return isDuplicate

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="vehicleArray"></param>
    ''' <remarks></remarks>
    Private Function ShowFamilyCreationScreen(ByVal vehicleArray() As Integer) As Boolean
      Dim familyId As Integer
      Dim userResponse As DialogResult
      Dim familyForm As FamilyCreationForm
      Dim tempVehicleRow As FamilyCheckInDataSet.vwCircularRow
      Dim tempRow As FamilyDataSet.DisplayFamilyInformationRow


      tempVehicleRow = Processor.GetVehicleRow(vehicleArray(0))

      familyForm = New FamilyCreationForm(tempVehicleRow.BreakDt, tempVehicleRow.MediaId, tempVehicleRow.RetId, 0, 3)
      familyForm.Init(FormStateEnum.View)
      familyForm.ApplyUserCredentials()
      familyForm.addateValueLabel.Text = tempVehicleRow.BreakDt.ToString("MM/dd/yy")
      familyForm.retailerNameLabel.Text = tempVehicleRow.RetailerRow.Retailer
      familyForm.marketNameLabel.Text = tempVehicleRow.MarketRowParent.Market
      If tempVehicleRow.IsCheckInPageCountNull() Then
        familyForm.pagesValueLabel.Text = String.Empty
      Else
        familyForm.pagesValueLabel.Text = tempVehicleRow.CheckInPageCount.ToString()
      End If
      If tempVehicleRow.IsEventIdNull() Then
        familyForm.eventNameLabel.Text = String.Empty
      Else
        familyForm.eventNameLabel.Text = tempVehicleRow.EventRow.Descrip
      End If
      If tempVehicleRow.IsThemeIdNull() Then
        familyForm.themeNameLabel.Text = String.Empty
      Else
        familyForm.themeNameLabel.Text = tempVehicleRow.ThemeRow.Descrip
      End If
      If tempVehicleRow.IsStartDtNull() Then
        familyForm.startDateValueLabel.Text = String.Empty
      Else
        familyForm.startDateValueLabel.Text = startDateTypeInDatePicker.Text
      End If
      If tempVehicleRow.IsEndDtNull() Then
        familyForm.endDateValueLabel.Text = String.Empty
      Else
        familyForm.endDateValueLabel.Text = endDateTypeInDatePicker.Text
      End If
      familyForm.Show()
      familyForm.Hide()
      familyForm.LoadPotentialFamilies()
      userResponse = familyForm.ShowDialog(Me)

      If Not (userResponse = Windows.Forms.DialogResult.OK AndAlso familyForm.FamilyId > 0) Then Return False

      familyId = familyForm.FamilyId

      If familyForm.IsNewFamily Then
        For i As Integer = 0 To vehicleArray.Length - 1
          tempVehicleRow = Processor.GetVehicleRow(vehicleArray(i))
          If tempVehicleRow IsNot Nothing Then tempVehicleRow.FamilyId = familyId
        Next

      Else  'checkFamily.joinFamilyRadioButton.Checked
        Dim isDuplicate, isSuccessful As Boolean
        Dim marketQuery As System.Data.EnumerableRowCollection(Of FamilyCheckInDataSet.MarketRow)


        tempRow = familyForm.CurrentRow

        marketQuery = From row In Processor.Data.Market _
                      Where row.VehicleId = vehicleArray(0) _
                      Select row
        If marketQuery.Count() = 0 Then Return False

        Try
          isSuccessful = False
          isDuplicate = IsDuplicateMarket(marketQuery(0), familyId)
          isSuccessful = True
        Catch ex As System.Data.SqlClient.SqlException
          Trace.TraceError("FamilyCheckInForm.ShowFamilyCreationScreen(): IsDuplicateMarket. Message=" + ex.Message, New Object() {"FamilyId=", familyId, "MktRow=", marketQuery(0), ex})
          MessageBox.Show("Unable to assign family. Error has occurred while checking for market duplication within family.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
          Trace.TraceError("FamilyCheckInForm.ShowFamilyCreationScreen(): IsDuplicateMarket. Message=" + ex.Message, New Object() {"FamilyId=", familyId, "MktRow=", marketQuery(0), ex})
          MessageBox.Show("Unable to assign family. Unknown error has occurred while checking for market duplication within family.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If isSuccessful = False OrElse (isSuccessful AndAlso isDuplicate) Then
          Me.Processor.Data.vwCircular.RejectChanges()
          familyId = -1
          Return False
        End If

        For i As Integer = 0 To vehicleArray.Length - 1
          tempVehicleRow = Processor.GetVehicleRow(vehicleArray(i))
          tempVehicleRow.EventId = tempRow.EventId
          tempVehicleRow.ThemeId = tempRow.ThemeId
          If Not tempRow.IsStartDtNull() Then
            tempVehicleRow.StartDt = tempRow.StartDt
          End If
          If Not tempRow.IsEndDtNull() Then
            tempVehicleRow.EndDt = tempRow.EndDt
          End If
          tempVehicleRow.CouponInd = tempRow.CouponInd

          Try
            Processor.CopyPageInformation(tempRow.VehicleId, tempVehicleRow.VehicleId, FORM_NAME)
          Catch ex As System.Data.SqlClient.SqlException
            Trace.TraceError("FamilyCheckInForm.ShowFamilyCreationScreen(): CopyPageInformation. Message=" + ex.Message, New Object() {"FamilyId=", familyId, "SourceVehicleId=", tempRow.VehicleId, "DestinationVehicleId=", tempVehicleRow.VehicleId, FORM_NAME, ex})
            MessageBox.Show("Unable to copy page information. Error has occurred while copying page information." + Environment.NewLine + "Please information your entry administrator about this.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
          Catch ex As Exception
            Trace.TraceError("FamilyCheckInForm.ShowFamilyCreationScreen(): CopyPageInformation. Message=" + ex.Message, New Object() {"FamilyId=", familyId, "SourceVehicleId=", tempRow.VehicleId, "DestinationVehicleId=", tempVehicleRow.VehicleId, FORM_NAME, ex})
            MessageBox.Show("Unable to copy page information. Unknown error has occurred while copying page information.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
          End Try

          tempVehicleRow.FamilyId = familyId
        Next
      End If

      familyForm.Dispose()
      familyForm = Nothing

      Return (familyId > 0)

    End Function


    ''' <summary>
    ''' Clear error providers from all input controls.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overrides Sub RemoveAllErrorProviders()
      MyBase.RemoveAllErrorProviders()

      RemoveErrorProvider(adDateTypeInDatePicker)
      RemoveErrorProvider(mediaComboBox)
      RemoveErrorProvider(retailerComboBox)
      RemoveErrorProvider(languageComboBox)
      RemoveErrorProvider(marketCheckedListBox)
      RemoveErrorProvider(selectedMktPubListBox)
      RemoveErrorProvider(eventComboBox)
      RemoveErrorProvider(themeComboBox)
      RemoveErrorProvider(startDateTypeInDatePicker)
      RemoveErrorProvider(endDateTypeInDatePicker)

    End Sub

    '''' <summary>
    '''' Showing error popup to user based on error texts assigned to each column.
    '''' </summary>
    '''' <param name="validatedRow"></param>
    '''' <remarks></remarks>
    'Private Sub ShowErrors(ByVal validatedRow As MCAP.FamilyCheckInDataSet.vwCircularRow)
    '  Dim columnCounter As Integer
    '  Dim errorMessage As System.Text.StringBuilder
    '  Dim errorCols() As Data.DataColumn


    '  If validatedRow.HasErrors = False Then Exit Sub

    '  errorMessage = New System.Text.StringBuilder

    '  If String.IsNullOrEmpty(validatedRow.RowError) = False Then
    '    errorMessage.Append(validatedRow.RowError)
    '  Else
    '    errorCols = validatedRow.GetColumnsInError()

    '    errorMessage.Append("Invalid inputs found.")
    '    errorMessage.Append(Environment.NewLine)
    '    For columnCounter = 0 To errorCols.Length - 1
    '      errorMessage.Append(Environment.NewLine)
    '      'errorMessage.Append(errorCols(columnCounter).Caption)
    '      'errorMessage.Append(" - ")
    '      errorMessage.Append((columnCounter + 1).ToString())
    '      errorMessage.Append(". ")
    '      errorMessage.Append(validatedRow.GetColumnError(errorCols(columnCounter)))
    '    Next

    '    System.Array.Clear(errorCols, 0, errorCols.Length)
    '  End If

    '  MessageBox.Show(errorMessage.ToString(), Application.ProductName, _
    '                  MessageBoxButtons.OK, MessageBoxIcon.Error)

    '  errorMessage = Nothing
    '  errorCols = Nothing

    'End Sub

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
    ''' Writes input values into vehicle datarow.
    ''' </summary>
    ''' <param name="tempVehicle"></param>
    ''' <param name="mktPubCounter"></param> 
    ''' <remarks></remarks>
    Private Sub WriteValuesInRow(ByVal tempVehicle As FamilyCheckInDataSet.vwCircularRow _
                                 , ByVal mktPubCounter As Integer _
                                 , ByVal dupcheckResponse As MCAP.UI.DuplicateCheckUserResponse)

      tempVehicle.BeginEdit()

      tempVehicle.LanguageId = CType(languageComboBox.SelectedValue, Integer)
      tempVehicle.EventId = CType(eventComboBox.SelectedValue, Integer)
      tempVehicle.ThemeId = CType(themeComboBox.SelectedValue, Integer)
      If startDateTypeInDatePicker.Text = "  /  /" Then
        tempVehicle.SetStartDtNull()
      Else
        tempVehicle.StartDt = CType(startDateTypeInDatePicker.Text, DateTime)
      End If
      If endDateTypeInDatePicker.Text = "  /  /" Then
        tempVehicle.SetEndDtNull()
      Else
        tempVehicle.EndDt = CType(endDateTypeInDatePicker.Text, DateTime)
      End If
      If couponIndCheckBox.Checked Then
        tempVehicle.CouponInd = 1
      Else
        tempVehicle.CouponInd = 0
      End If
      tempVehicle.FormName = FORM_NAME


      If dupcheckResponse = DuplicateCheckUserResponse.Duplicate Then
        tempVehicle.StatusID = Processor.GetStatusIdForDuplicate()
      ElseIf dupcheckResponse = DuplicateCheckUserResponse.Review Then
        tempVehicle.StatusID = Processor.GetStatusIdForReview()
      ElseIf dupcheckResponse = DuplicateCheckUserResponse.NoPossibleDuplidates _
          OrElse dupcheckResponse = DuplicateCheckUserResponse.Override _
      Then
        Processor.SetVehicleStatusAsIndexed(tempVehicle)
      End If

      tempVehicle.EndEdit()

    End Sub

#Region " IForm Implementation "

    Public Event InitializingForm() Implements IForm.InitializingForm
    Public Event FormInitialized() Implements IForm.FormInitialized

    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied

    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

    End Sub

    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

      RaiseEvent InitializingForm()

      Me.SuspendLayout()

      m_selectedMarketPublication = New System.Collections.Generic.Dictionary(Of String, SelectedMktPub)
      m_familyCheckInProcessor = New Processors.FamilyCheckIn

      Processor.Initialize()
      Processor.LoadDataSet()

      Me.StatusMessage = "Information loaded. Preparing to show information on window."

      mediaComboBox.DisplayMember = "Descrip"
      mediaComboBox.ValueMember = "MediaId"
      mediaComboBox.DataSource = Processor.Data.Media
      mediaComboBox.SelectedValue = DBNull.Value

      retailerComboBox.DisplayMember = "Retailer"
      retailerComboBox.ValueMember = "RetId"
      retailerComboBox.DataSource = Processor.Data.Retailer
      retailerComboBox.SelectedValue = DBNull.Value

      languageComboBox.DisplayMember = "Descrip"
      languageComboBox.ValueMember = "LanguageId"
      languageComboBox.DataSource = Processor.Data.Language
      languageComboBox.SelectedValue = DBNull.Value

      eventComboBox.DisplayMember = "Descrip"
      eventComboBox.ValueMember = "EventId"
      eventComboBox.DataSource = Processor.Data._Event
      eventComboBox.SelectedValue = DBNull.Value

      themeComboBox.DisplayMember = "Descrip"
      themeComboBox.ValueMember = "ThemeId"
      themeComboBox.DataSource = Processor.Data.Theme
      themeComboBox.SelectedValue = DBNull.Value

      ClearAllInputs()
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

      Me.ResumeLayout(False)

      RaiseEvent FormInitialized()

    End Sub

#End Region


#Region " IDuplicateCheck Implementation "


    Public ReadOnly Property Duplicate() As Boolean Implements IDuplicateCheck.MarkAsDuplicate
      Get
        Return m_Duplicate
      End Get
    End Property

    Public ReadOnly Property ForReview() As Boolean Implements IDuplicateCheck.MarkForReview
      Get
        Return m_forReview
      End Get
    End Property

    Public ReadOnly Property IsAnyPossibleDuplicateRecordsFound() As Boolean Implements IDuplicateCheck.IsAnyPossibleDuplicateRecordFound
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
      Dim adDate, startDate, endDate As DateTime
      Dim mediaList As System.Collections.Generic.List(Of String)
      Dim possibleDupVehicles As UI.DupCheckForm


      mediaList = New System.Collections.Generic.List(Of String)
      retailerId = CType(retailerComboBox.SelectedValue, Integer)
      adDate = adDateTypeInDatePicker.Value.Value
      If languageComboBox.SelectedValue Is DBNull.Value Then
        languageId = Nothing
      Else
        languageId = CType(languageComboBox.SelectedValue, Integer)
      End If

      Select Case mediaComboBox.Text.ToUpper()
        Case "FSI"
          mediaList.Clear()
          mediaList.Add("FSI")
          possibleDupVehicles = New UI.DupCheckForm(retailerId, marketId, adDate, mediaList, languageId, True, formName)
        Case "ROP"
          mediaList.Clear()
          mediaList.Add("ROP")
          possibleDupVehicles = New UI.DupCheckForm(retailerId, marketId, publicationId, adDate, mediaList, languageId, True, formName)

                Case "CATALOG", "IN-STORE", "INSERT", "MAILER", "ROP - CIRCULAR", "MONTHLY BOOKLET",
                        "PICK-UP IN-STORE", "INTERNET", "INSERT-DIGITAL", "IN-STORE-DIGITAL", "MAILER-DIGITAL",
                        "INSERT-AC PAPER", "INSERT-AC DIGITAL", "IN-STORE-AC DIGITAL"
                    mediaList.Clear()
                    mediaList.Add("Catalog")
                    mediaList.Add("In-Store")
                    mediaList.Add("Insert")
                    mediaList.Add("Mailer")
                    mediaList.Add("ROP - Circular")
                    mediaList.Add("Monthly Booklet")
                    mediaList.Add("Pick-Up In-Store")
                    mediaList.Add("Insert-Digital")
                    mediaList.Add("In-Store-Digital")
                    mediaList.Add("Mailer-Digital")
                    mediaList.Add("Insert-AC Paper")
                    mediaList.Add("Insert-AC Digital")
                    mediaList.Add("In-Store-AC Digital")

                    If DateTime.TryParse(startDateTypeInDatePicker.Text, startDate) = False Then
                        startDate = Nothing
                    End If
                    If DateTime.TryParse(endDateTypeInDatePicker.Text, endDate) = False Then
                        endDate = Nothing
                    End If
                    possibleDupVehicles = New UI.DupCheckForm(retailerId, marketId, adDate, mediaList, startDate, endDate, languageId, True, formName)
                    If mediaComboBox.Text.ToUpper() = "CATALOG" Then
                        possibleDupVehicles.dateRangeNumericUpDown.Value = 14
                    Else
                        possibleDupVehicles.dateRangeNumericUpDown.Value = 5
                    End If
        Case Else
          If DateTime.TryParse(startDateTypeInDatePicker.Text, startDate) = False Then
            startDate = Nothing
          End If
          If DateTime.TryParse(endDateTypeInDatePicker.Text, endDate) = False Then
            endDate = Nothing
          End If
          mediaList.Clear()
          mediaList.Add(mediaComboBox.Text.ToUpper())
          possibleDupVehicles = New UI.DupCheckForm(retailerId, marketId, adDate, mediaList, startDate, endDate, languageId, True, formName)
          possibleDupVehicles.dateRangeNumericUpDown.Value = 5

      End Select

      mediaList.Clear()
      mediaList = Nothing

      possibleDupVehicles.RemoveVehicle = m_tempVehicleId
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
      m_Duplicate = possibleDupVehicles.IsDuplicate
      Me.DupcheckFormLogId = possibleDupVehicles.DupcheckFormLogId

      possibleDupVehicles.Dispose()
      possibleDupVehicles = Nothing

    End Function


#End Region



    ''' <summary>
    ''' Validates inputs as per business rules.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ValidateBusinessRules() As Boolean
      Dim showMsg As Boolean
      Dim dateDifference As Integer
      Dim dateMsg As DateCheckDialog


      dateMsg = New DateCheckDialog()
      dateMsg.AllowIgnoreKey = Processor.IsUserSupervisorOrAdministrator(Processor.UserID)

      If adDateTypeInDatePicker.Value.HasValue = True _
          AndAlso startDateTypeInDatePicker.Value.HasValue = True _
      Then
        showMsg = False
        dateDifference = adDateTypeInDatePicker.Value.Value.Subtract(startDateTypeInDatePicker.Value.Value).Days

        If (dateDifference < -7 OrElse dateDifference > 7) _
          AndAlso (mediaComboBox.Text.ToUpper() = "MAILER" OrElse mediaComboBox.Text.ToUpper() = "CATALOG") _
        Then
          showMsg = True
        ElseIf (dateDifference < -14 OrElse dateDifference > 14) _
          AndAlso (tradeclassValueLabel.Text.ToUpper() = "DEPT") _
        Then
          showMsg = True
        ElseIf (dateDifference < -28 OrElse dateDifference > 28) Then
          showMsg = True
        End If

        If showMsg Then
          dateMsg.MessageText = "Sale Start Date is not close enough to Ad Date to permit entry." _
                                + " Correct one of the dates, or if they are correct set aside for" _
                                + " supervisor."
          If dateMsg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then Return False
        End If
      End If


      showMsg = False

      If endDateTypeInDatePicker.Value.HasValue Then
        showMsg = False

        If adDateTypeInDatePicker.Value.HasValue Then
          If adDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days < -40 Then _
            showMsg = True
        End If
      End If

      If showMsg = False AndAlso startDateTypeInDatePicker.Value.HasValue _
          AndAlso endDateTypeInDatePicker.Value.HasValue _
      Then
        If startDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days < -40 Then _
            showMsg = True
      End If

      If showMsg Then
        dateMsg.MessageText = "Sale End date is not close enough to Ad date or Start date to permit" _
                              + " entry. Correct one or more dates, or if they are correct set aside" _
                              + " for supervisor."
        If dateMsg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then Return False
      End If


      showMsg = False
      dateMsg.Dispose()
      dateMsg = Nothing


      Return Not showMsg

    End Function

    ''' <summary>
    ''' Validates all input controls and attach error provider if invalid input found.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function AreInputsValid() As Boolean
      Dim areAllInputsValid As Boolean
      Dim tempDate As DateTime


      areAllInputsValid = True
      Me.StatusMessage = "Validating inputs..."

      If adDateTypeInDatePicker.Value.HasValue = False Then
        SetErrorProvider(adDateTypeInDatePicker, "Invalid date.")
        areAllInputsValid = False
      Else
        RemoveErrorProvider(adDateTypeInDatePicker)
      End If

      If mediaComboBox.SelectedValue Is Nothing OrElse mediaComboBox.Text.Length = 0 Then
        SetErrorProvider(mediaComboBox, "Select media from drop down list.")
        areAllInputsValid = False
      Else
        RemoveErrorProvider(mediaComboBox)
      End If

      If retailerComboBox.SelectedValue Is Nothing OrElse retailerComboBox.Text.Length = 0 Then
        SetErrorProvider(retailerComboBox, "Select retailer from drop down list.")
        areAllInputsValid = False
      Else
        RemoveErrorProvider(retailerComboBox)
      End If

      If languageComboBox.SelectedValue Is Nothing OrElse languageComboBox.Text.Length = 0 Then
        SetErrorProvider(languageComboBox, "Select language from drop down list.")
        areAllInputsValid = False
      Else
        RemoveErrorProvider(languageComboBox)
      End If

      If selectedMktPubListBox.Items.Count = 0 Then
        SetErrorProvider(selectedMktPubListBox, "Please provide market - publication combination.")
        areAllInputsValid = False
      Else
        RemoveErrorProvider(selectedMktPubListBox)
      End If

      If eventComboBox.SelectedValue Is Nothing OrElse eventComboBox.Text.Length = 0 Then
        SetErrorProvider(eventComboBox, "Select event from drop down list.")
        areAllInputsValid = False
      Else
        RemoveErrorProvider(eventComboBox)
      End If

      If themeComboBox.SelectedValue Is Nothing OrElse themeComboBox.Text.Length = 0 Then
        SetErrorProvider(themeComboBox, "Select theme from drop down list.")
        areAllInputsValid = False
      Else
        RemoveErrorProvider(themeComboBox)
      End If

      If startDateTypeInDatePicker.Text <> "  /  /" _
        AndAlso DateTime.TryParse(startDateTypeInDatePicker.Text, tempDate) = False _
      Then
        SetErrorProvider(startDateTypeInDatePicker, "Provide valid Start Date.")
        areAllInputsValid = False
      ElseIf startDateTypeInDatePicker.Value.HasValue = False Then
        RemoveErrorProvider(startDateTypeInDatePicker)
      End If

      If endDateTypeInDatePicker.Text <> "  /  /" _
        AndAlso DateTime.TryParse(endDateTypeInDatePicker.Text, tempDate) = False _
      Then
        SetErrorProvider(endDateTypeInDatePicker, "Provide valid End Date.")
        areAllInputsValid = False
      ElseIf endDateTypeInDatePicker.Value.HasValue = False Then
        RemoveErrorProvider(endDateTypeInDatePicker)
      ElseIf adDateTypeInDatePicker.Value.HasValue _
        AndAlso adDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days > 0 _
      Then
        MessageBox.Show("End Date cannot be before Ad Date.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Error)
        areAllInputsValid = False
      ElseIf startDateTypeInDatePicker.Value.HasValue _
        AndAlso startDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days > 0 _
      Then
        MessageBox.Show("End Date cannot be before Start Date.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Error)
        areAllInputsValid = False
      ElseIf (adDateTypeInDatePicker.Value.HasValue _
              AndAlso adDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days < -35) _
        OrElse (startDateTypeInDatePicker.Value.HasValue _
              AndAlso startDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days < -30) _
      Then
        Dim userResponse As DialogResult
        userResponse = MessageBox.Show("Sale End Date is unusual compared to Sale Start Date or Ad Date." _
                                       + " Check all values. Is the sale end date correct?", ProductName _
                                       , MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If userResponse = Windows.Forms.DialogResult.No Then areAllInputsValid = False
      End If


      If areAllInputsValid Then areAllInputsValid = ValidateBusinessRules()

      Me.StatusMessage = String.Empty

      Return areAllInputsValid

    End Function


    Private Sub exitButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

      Me.Close()

    End Sub



#Region " Events related to Date validation. "

    '
    'These events are used to show error providers with specific message. 
    'If user ignores and try to save these information, a dialog with common 
    'message is shown to user. These events are very useful to provide much 
    'more understandable messages to user. 
    '

    Private Sub adDateMaskedTextBox_Validating _
        (ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles adDateTypeInDatePicker.Validating
      Dim differenceInDays As Integer
      Dim userResponse As DialogResult
      Dim tempDate As DateTime


      If adDateTypeInDatePicker.Value.HasValue Then
        tempDate = adDateTypeInDatePicker.Value.Value
        differenceInDays = CType(tempDate.Subtract(System.DateTime.Today).TotalDays, Integer)

        If differenceInDays < -365 Or differenceInDays > 365 Then
          userResponse = MessageBox.Show("Is the Ad Date correct?", ProductName, MessageBoxButtons.YesNo _
                                         , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
          If userResponse = Windows.Forms.DialogResult.No Then e.Cancel = True
        End If
      End If

    End Sub

    Private Sub startDateTypeInDatePicker_Validating _
        (ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles startDateTypeInDatePicker.Validating

      If adDateTypeInDatePicker.Value.HasValue = False _
        OrElse startDateTypeInDatePicker.Value.HasValue = False _
      Then
        RemoveErrorProvider(startDateTypeInDatePicker)
        Exit Sub
      End If

      Dim dateDifference As Integer
      Dim tempDate, adDate As DateTime


      adDate = adDateTypeInDatePicker.Value.Value
      tempDate = startDateTypeInDatePicker.Value.Value
      dateDifference = tempDate.Subtract(adDate).Days

      If (dateDifference < -7 Or dateDifference > 7) _
        AndAlso (mediaComboBox.Text.ToUpper() = "MAILER" OrElse mediaComboBox.Text.ToUpper() = "CATALOG") _
      Then
        SetErrorProvider(startDateTypeInDatePicker, "Start Date needs to be within 7 days of Ad Date.")

      ElseIf tradeclassValueLabel.Text.ToUpper() = "DEPT" _
        AndAlso (dateDifference < -14 Or dateDifference > 14) _
      Then
        SetErrorProvider(startDateTypeInDatePicker, "Start Date needs to be within 14 days of Ad Date.")

      ElseIf dateDifference < -28 Or dateDifference > 28 Then
        SetErrorProvider(startDateTypeInDatePicker, "Start Date needs to be within 28 days of Ad Date.")

      Else
        RemoveErrorProvider(startDateTypeInDatePicker)

        If (dateDifference < -3 OrElse dateDifference > 3) Then
          Dim userResponse As DialogResult
          userResponse = MessageBox.Show("Difference between Sale Start Date and Ad Date is unusually large." _
                                         + " Please Check these values. Is Sale Start Date correct?", ProductName _
                                         , MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                         , MessageBoxDefaultButton.Button2)
          If userResponse = Windows.Forms.DialogResult.No Then
            startDateTypeInDatePicker.Focus()
            Exit Sub
          End If
        End If
      End If

    End Sub

    Private Sub endDateMaskedTextBox_Validating _
        (ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles endDateTypeInDatePicker.Validating

      If endDateTypeInDatePicker.Value.HasValue = False Then
        RemoveErrorProvider(endDateTypeInDatePicker)
        Exit Sub
      End If

      Dim tempDate As DateTime = endDateTypeInDatePicker.Value.Value

      If adDateTypeInDatePicker.Value.HasValue Then
        Dim adDate As DateTime = adDateTypeInDatePicker.Value.Value

        If adDate.Subtract(tempDate).Days > 0 Then
          SetErrorProvider(endDateTypeInDatePicker, "End date cannot be prior to Ad date.")
        ElseIf adDate.Subtract(tempDate).Days < -35 Then 'i.e. adDt - endDt
          SetErrorProvider(endDateTypeInDatePicker, "End date is not within 35 days of Ad date.")
        Else
          RemoveErrorProvider(endDateTypeInDatePicker)
        End If
      End If

      If startDateTypeInDatePicker.Value.HasValue _
        AndAlso m_ErrorProvider.GetError(endDateTypeInDatePicker) = String.Empty _
      Then
        Dim startDate As DateTime = startDateTypeInDatePicker.Value.Value

        If startDate.Subtract(tempDate).Days > 0 Then 'i.e. StartDt - endDt
          SetErrorProvider(endDateTypeInDatePicker, "End date cannot be prior to Start date.")
        ElseIf startDate.Subtract(tempDate).Days < -30 Then  'i.e. StartDt - endDt
          SetErrorProvider(endDateTypeInDatePicker, "End date is not within 30 days of Start date.")
        End If
      End If

    End Sub


#End Region

        Private Sub mediaComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mediaComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub



    Private Sub AddateAndMedia_ValueChanged _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles mediaComboBox.SelectedValueChanged, adDateTypeInDatePicker.Validated
      Dim mediaId As Integer
      Dim breakDt As DateTime


      If adDateTypeInDatePicker.Text = "  /  /" Or mediaComboBox.SelectedValue Is Nothing Then
        retailerComboBox.DataSource = Nothing
        Exit Sub
      ElseIf DateTime.TryParse(adDateTypeInDatePicker.Text, breakDt) = False Then
        MessageBox.Show("Provide proper Ad Date.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        retailerComboBox.DataSource = Nothing
        Exit Sub
      ElseIf Integer.TryParse(mediaComboBox.SelectedValue.ToString(), mediaId) = False Then
        MessageBox.Show("Provide proper Media.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        retailerComboBox.DataSource = Nothing
        Exit Sub
      End If

      Try
        Processor.LoadRetailersByAdDateAndMedia(breakDt, mediaId)
      Catch ex As System.Data.SqlClient.SqlException
        Trace.TraceError("FamilyCheckInForm.AddateAndMedia_ValueChanged(): LoadRetailersByAdDateAndMedia. Message=" + ex.Message, New Object() {"AdDate=", breakDt, "MediaId=", mediaId, ex})
        MessageBox.Show("Unable to load list of retailers. Error has occurred while loading list of retailers.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch ex As Exception
        Trace.TraceError("FamilyCheckInForm.AddateAndMedia_ValueChanged(): Unknown error. LoadRetailersByAdDateAndMedia. Message=" + ex.Message, New Object() {"AdDate=", breakDt, "MediaId=", mediaId, ex})
        MessageBox.Show("Unable to load list of retailers. Unknown error has occurred while loading list of retailers.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      If retailerComboBox.DataSource Is Nothing Then
        RemoveHandler retailerComboBox.SelectedValueChanged, AddressOf retailerComboBox_SelectedValueChanged
        retailerComboBox.DisplayMember = "Retailer"
        retailerComboBox.ValueMember = "RetId"
        retailerComboBox.DataSource = Processor.Data.Retailer
        AddHandler retailerComboBox.SelectedValueChanged, AddressOf retailerComboBox_SelectedValueChanged
      End If
      retailerComboBox.SelectedValue = DBNull.Value

      m_RetNeedsReload = False
        End Sub

        Private Sub retailerComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles retailerComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

    Private Sub retailerComboBox_SelectedValueChanged _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles retailerComboBox.SelectedValueChanged
      Dim mediaId, retId As Integer
      Dim breakDt As DateTime
      Dim retRow As System.Data.EnumerableRowCollection(Of FamilyCheckInDataSet.RetailerRow)


      If adDateTypeInDatePicker.Value Is Nothing _
        OrElse mediaComboBox.SelectedValue Is Nothing _
        OrElse retailerComboBox.SelectedValue Is Nothing _
      Then
        marketCheckedListBox.Items.Clear()
        Exit Sub
      ElseIf DateTime.TryParse(adDateTypeInDatePicker.Text, breakDt) = False Then
        MessageBox.Show("Provide proper Ad Date.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        retailerComboBox.DataSource = Nothing
        Exit Sub
      ElseIf Integer.TryParse(mediaComboBox.SelectedValue.ToString(), mediaId) = False Then
        MessageBox.Show("Unable to get Media.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        retailerComboBox.DataSource = Nothing
        Exit Sub
      ElseIf Integer.TryParse(retailerComboBox.SelectedValue.ToString(), retId) = False Then
        MessageBox.Show("Unable to get Retailer.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        retailerComboBox.DataSource = Nothing
        Exit Sub
      End If


      retRow = From r In Processor.Data.Retailer _
               Where r.RetId = retId _
               Select r
      tradeclassValueLabel.Text = retRow(0).Tradeclass

      retRow = Nothing

      selectedMktPubListBox.Items.Clear()
      m_selectedMarketPublication.Clear()

      Try
        Processor.LoadVehicles(breakDt, mediaId, retId, CType(dayRangeNumericUpDown.Value, Integer))
        Processor.LoadMarketPublicationList(breakDt, mediaId, retId, CType(dayRangeNumericUpDown.Value, Integer))
      Catch ex As System.Data.SqlClient.SqlException
        Trace.TraceError("retailerComboBox_SelectedValueChanged(): LoadVehicles and LoadMarketPublicationList. Message=" + ex.Message, New Object() {"AdDate=", breakDt, "MediaId=", mediaId, "RetId=", retId, "DayRange=", dayRangeNumericUpDown.Value.ToString(), ex})
        MessageBox.Show("Unable to load list of retailers. Error has occurred while loading list of Markets.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch ex As Exception
        Trace.TraceError("retailerComboBox_SelectedValueChanged(): Unknown error. LoadVehicles and LoadMarketPublicationList. Message=" + ex.Message, New Object() {"AdDate=", breakDt, "MediaId=", mediaId, "RetId=", retId, "DayRange=", dayRangeNumericUpDown.Value.ToString(), ex})
        MessageBox.Show("Unable to load list of retailers. Unknown error has occurred while loading list of Markets.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      FillMarketCheckedListBox(Processor.Data.Market)
      marketCheckedListBox.SelectedValue = DBNull.Value

    End Sub

    Private Sub marketCheckedListBox_ItemCheck _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) _
        Handles marketCheckedListBox.ItemCheck
      Dim combinationString As String
      Dim selectedMP As SelectedMktPub
      Dim selectedRow As FamilyCheckInDataSet.MarketRow


      If e.Index < 0 Then
        MessageBox.Show("Select both Market and Publication and then click the button to add it into the list." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If

      If e.NewValue = CheckState.Unchecked Then
        RemoveMarketFromList(marketCheckedListBox.SelectedItem.ToString())
        Exit Sub
      End If

      selectedRow = Processor.Data.Market(e.Index)
      If showVehicleIdRadioButton.Checked Then
        combinationString = selectedRow.MktVehicleIdPg
      Else
        combinationString = selectedRow.MktPubPg
      End If

      If selectedMktPubListBox.FindStringExact(combinationString) >= 0 Then
        MessageBox.Show("Selected Vehicle to Index already exist in list." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      selectedMP.MktId = selectedRow.MktId
      selectedMP.MarketName = selectedRow.Market
      selectedMP.PubId = selectedRow.PublicationId
      selectedMP.PublicationName = selectedRow.Publication
      selectedMP.MktPubPages = selectedRow.MktPubPg
      selectedMP.MktVehicleIdPages = selectedRow.MktVehicleIdPg
      selectedMP.VehicleId = selectedRow.VehicleId

      m_selectedMarketPublication.Add(combinationString, selectedMP)
      selectedMktPubListBox.Items.Add(combinationString)

      selectedRow = Nothing
      selectedMP = Nothing

    End Sub

    ''' <summary>
    ''' Checks whether vehicles are having page defined or not.
    ''' </summary>
    ''' <param name="selectedMktPub"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function HasPagesDefined(ByVal selectedMktPub As System.Collections.Generic.Dictionary(Of String, SelectedMktPub)) As Boolean
      Dim isPageInfoExist As Boolean
      Dim pageCounts As Integer


      For i As Integer = 0 To selectedMktPub.Count - 1
        Try
          pageCounts = Processor.GetPageCount(selectedMktPub.Values(i).VehicleId)
        Catch ex As System.Data.SqlClient.SqlException
          Trace.TraceError("HasPagesDefined(): GetPageCount. Message=" + ex.Message, New Object() {"i=", i, "VehicleId=", selectedMktPub.Values(i).VehicleId, ex})
          MessageBox.Show("Unable to load list of retailers. Error has occurred while loading list of Markets.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
          Trace.TraceError("HasPagesDefined(): Unknown error. GetPageCount. Message=" + ex.Message, New Object() {"i=", i, "VehicleId=", selectedMktPub.Values(i).VehicleId, ex})
          MessageBox.Show("Unable to load list of retailers. Unknown error has occurred while loading list of Markets.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        isPageInfoExist = (pageCounts > 0)
        If isPageInfoExist Then Exit For
      Next

      Return isPageInfoExist

    End Function

    Private Sub pagesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles pagesButton.Click
      Dim vehicleId, mktPubCounter As Integer
      Dim userResponse As DialogResult
      Dim vehicleIdXMLList As System.Text.StringBuilder
      Dim pageInfoForm As MCAP.UI.PageDefinitionsForm
      Dim linqQuery As System.Collections.Generic.IEnumerable(Of SelectedMktPub)


      If m_selectedMarketPublication.Count = 0 Then
        MessageBox.Show("Select at least one Market to set page information." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      ElseIf HasPagesDefined(m_selectedMarketPublication) Then
        MessageBox.Show("One or more of the selected Vehicles have page information already defined." _
                        + " This will get overwritten when saving.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End If

      'Assign page information same as the vehicle used to load these information.
      'If selected vehicle is same as the one used to load information, skip 
      'copying page information step.
      linqQuery = From smp In m_selectedMarketPublication Select smp.Value
      vehicleId = linqQuery(0).VehicleId
      linqQuery = Nothing
      'Processor.DefaultPageInformation(CType(gotoVehicleIdTextBox.Text, Integer), vehicleId, FORM_NAME)
      If m_searchedVehicleId <> vehicleId Then _
          Processor.DefaultPageInformation(m_searchedVehicleId, vehicleId, FORM_NAME)

      pageInfoForm = New MCAP.UI.PageDefinitionsForm
      pageInfoForm.Init(UI.FormStateEnum.View)
      pageInfoForm.ApplyUserCredentials()
      pageInfoForm.VehicleID = vehicleId
      pageInfoForm.ExpectedPageCount = Processor.GetPageCount(vehicleId)
      userResponse = pageInfoForm.ShowDialog(Me)
      pageInfoForm.Dispose()
      pageInfoForm = Nothing

      If userResponse <> Windows.Forms.DialogResult.OK Then Exit Sub

      vehicleIdXMLList = New System.Text.StringBuilder
      linqQuery = From smp In m_selectedMarketPublication Select smp.Value

      vehicleIdXMLList.Append("<VehicleIdList>")
      For mktPubCounter = 1 To linqQuery.Count - 1
        vehicleIdXMLList.Append("<VehicleId>")
        vehicleIdXMLList.Append(linqQuery(mktPubCounter).VehicleId.ToString())
        vehicleIdXMLList.Append("</VehicleId>")
      Next
      vehicleIdXMLList.Append("</VehicleIdList>")

      Try
        Processor.CopyPageInformation(linqQuery(0).VehicleId, vehicleIdXMLList.ToString(), FORM_NAME)
      Catch ex As System.Data.SqlClient.SqlException
        Trace.TraceError("pagesButton_Click(): CopyPageInformation. Message=" + ex.Message, New Object() {"SourceVehicleId=", linqQuery(0).VehicleId, "DestinationVehicleIds=", vehicleIdXMLList.ToString(), "FormName=", FORM_NAME, ex})
        MessageBox.Show("Unable to load list of retailers. Error has occurred while copying page information.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch ex As Exception
        Trace.TraceError("pagesButton_Click(): Unknown error. CopyPageInformation. Message=" + ex.Message, New Object() {"SourceVehicleId=", linqQuery(0).VehicleId, "DestinationVehicleIds=", vehicleIdXMLList.ToString(), "FormName=", FORM_NAME, ex})
        MessageBox.Show("Unable to load list of retailers. Unknown error has occurred while copying page information.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      vehicleIdXMLList = Nothing
      linqQuery = Nothing

    End Sub

    Private Sub loadjoinFamilyButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loadjoinFamilyButton.Click
      Dim tempVehicleRow As FamilyCheckInDataSet.vwCircularRow
      Dim vehicleQuery As System.Collections.Generic.IEnumerable(Of Integer)


      If m_selectedMarketPublication.Count = 0 Then
        MessageBox.Show("Select at least one Market to join Family.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      vehicleQuery = From smp In m_selectedMarketPublication Select smp.Value.VehicleId

      ShowFamilyCreationScreen(vehicleQuery.ToArray())

      tempVehicleRow = Processor.GetVehicleRow(vehicleQuery(0))
      If tempVehicleRow IsNot Nothing AndAlso tempVehicleRow.RowState = DataRowState.Modified Then
        If tempVehicleRow.IsEventIdNull() Then
          eventComboBox.SelectedValue = DBNull.Value
        Else
          eventComboBox.SelectedValue = tempVehicleRow.EventId
        End If
        If tempVehicleRow.IsThemeIdNull() Then
          themeComboBox.SelectedValue = DBNull.Value
        Else
          themeComboBox.SelectedValue = tempVehicleRow.ThemeId
        End If
        If tempVehicleRow.IsStartDtNull() Then
          startDateTypeInDatePicker.Value = Nothing
        Else
          startDateTypeInDatePicker.Value = tempVehicleRow.StartDt
        End If
        If tempVehicleRow.IsEndDtNull() Then
          endDateTypeInDatePicker.Value = Nothing
        Else
          endDateTypeInDatePicker.Value = tempVehicleRow.EndDt
        End If
        If tempVehicleRow.IsCouponIndNull() OrElse tempVehicleRow.CouponInd = 0 Then
          couponIndCheckBox.Checked = False
        Else
          couponIndCheckBox.Checked = True
        End If
      End If

      tempVehicleRow = Nothing
      vehicleQuery = Nothing

    End Sub

    Private Sub saveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles saveButton.Click
      Dim mediaId, retailerId, familyId, pageCount As Integer
      Dim mktInfo As String
      Dim breakDt As DateTime
      Dim dupcheckResponse As DuplicateCheckUserResponse
      Dim tempVehicleRow As FamilyCheckInDataSet.vwCircularRow
      Dim linqQuery As System.Collections.Generic.IEnumerable(Of SelectedMktPub)


      If AreInputsValid() = False Then
        Exit Sub
      ElseIf Integer.TryParse(mediaComboBox.SelectedValue.ToString(), mediaId) = False Then
        MessageBox.Show("Unable to recognize Media.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      ElseIf Integer.TryParse(retailerComboBox.SelectedValue.ToString(), retailerId) = False Then
        MessageBox.Show("Unable to recognize Retailer.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If

      breakDt = adDateTypeInDatePicker.Value.Value

      familyId = -1
      linqQuery = From smp In m_selectedMarketPublication Select smp.Value

      For mktPubCounter As Integer = 0 To linqQuery.Count - 1
        tempVehicleRow = Processor.GetVehicleRow(linqQuery(mktPubCounter).VehicleId)
        m_tempVehicleId = linqQuery(mktPubCounter).VehicleId

        dupcheckResponse = CheckForDuplication(linqQuery(mktPubCounter).MktId, linqQuery(mktPubCounter).PubId, True, FORM_NAME)
        If dupcheckResponse = DuplicateCheckUserResponse.Closed Then Exit Sub

        WriteValuesInRow(tempVehicleRow, mktPubCounter, dupcheckResponse)

        'This must be checked for each market, because on check, for market duplication in family,
        'user may have selected cancel and skipped that particular market.
        'If mktPubCounter = 0 And tempVehicleRow.IsFamilyIdNull() Then
        If tempVehicleRow.IsFamilyIdNull() Then
          Dim vehicleQuery As System.Collections.Generic.IEnumerable(Of Integer)
          vehicleQuery = From i In linqQuery Select i.VehicleId
          If ShowFamilyCreationScreen(vehicleQuery.ToArray()) = False Then
            MessageBox.Show("To finish indexing, vehicle must belong to a family.", ProductName _
                            , MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
          End If
          vehicleQuery = Nothing
        End If

        Try
          pageCount = Processor.GetPageCount(tempVehicleRow.VehicleId)
        Catch ex As System.Data.SqlClient.SqlException
          Trace.TraceError("saveButton_Click(): GetPageCount. Message=" + ex.Message, New Object() {"VehicleId=", tempVehicleRow.VehicleId, ex})
          MessageBox.Show("Unable to load list of retailers. Error has occurred while validating for page count.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
          Trace.TraceError("saveButton_Click(): Unknown error. GetPageCount. Message=" + ex.Message, New Object() {"VehicleId=", tempVehicleRow.VehicleId, ex})
          MessageBox.Show("Unable to load list of retailers. Unknown error has occurred while validating for page count.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If pageCount < 1 Then
          If showVehicleIdRadioButton.Checked Then
            mktInfo = linqQuery(mktPubCounter).MktVehicleIdPages
          Else
            mktInfo = linqQuery(mktPubCounter).MktPubPages
          End If
          MessageBox.Show("Cannot index Vehicle without page information." + Environment.NewLine _
                          + "Vehicle must have pages defined. Page information not found for " _
                          + mktInfo, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
          Exit Sub
        End If

        Try
          Processor.UpdateVehicle(tempVehicleRow)
        Catch ex As System.Data.SqlClient.SqlException
          Trace.TraceError("saveButton_Click(): UpdateVehicle. Message=" + ex.Message, New Object() {"VehicleId=", tempVehicleRow.VehicleId, ex})
          MessageBox.Show("Unable to save vehicle information of a vehicle " + tempVehicleRow.VehicleId.ToString() + ". Error has occurred while saving information.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
          Trace.TraceError("saveButton_Click(): Unknown error. UpdateVehicle. Message=" + ex.Message, New Object() {"VehicleId=", tempVehicleRow.VehicleId, ex})
          MessageBox.Show("Unable to save vehicle information of a vehicle " + tempVehicleRow.VehicleId.ToString() + ". Unknown error has occurred while saving information.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        tempVehicleRow = Nothing
      Next

      tempVehicleRow = Nothing
      linqQuery = Nothing

      ClearAllInputs()
      Me.FormState = FormStateEnum.Insert
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)
      gotoVehicleIdTextBox.Focus()

    End Sub

    Private Sub showPublicationRadioButton_CheckedChanged _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles showPublicationRadioButton.CheckedChanged, showVehicleIdRadioButton.CheckedChanged
      Dim checkedIndices As System.Collections.Generic.Queue(Of Integer)


      If CType(sender, System.Windows.Forms.RadioButton).Checked = False Then Exit Sub

      checkedIndices = New System.Collections.Generic.Queue(Of Integer)

      For i As Integer = 0 To marketCheckedListBox.CheckedIndices.Count - 1
        checkedIndices.Enqueue(marketCheckedListBox.CheckedIndices(i))
      Next

      marketCheckedListBox.Items.Clear()
      selectedMktPubListBox.Items.Clear()

      If m_selectedMarketPublication Is Nothing Then
        Exit Sub
        checkedIndices = Nothing
      End If

      m_selectedMarketPublication.Clear()
      FillMarketCheckedListBox(Processor.Data.Market)

      For i As Integer = 0 To checkedIndices.Count - 1
        marketCheckedListBox.SetItemChecked(checkedIndices(i), True)
      Next

      checkedIndices = Nothing

    End Sub

    Private Sub gotoVehicleIdTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles gotoVehicleIdTextBox.KeyPress

            '3 - Copy, 22 - Paste and 24 - Cut, 8 - Backspace
            If Microsoft.VisualBasic.AscW(e.KeyChar) = 3 _
              OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 22 _
              OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 24 _
              OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 8 _
            Then
                Exit Sub 'Process as it should.
            End If

            If Microsoft.VisualBasic.AscW(e.KeyChar) = 13 Then
                'loadButton.PerformClick()
                e.Handled = True
            ElseIf Not (System.Char.IsDigit(e.KeyChar) Or Microsoft.VisualBasic.AscW(e.KeyChar) = 8) Then
                e.Handled = True
            End If

    End Sub

    Private Sub gotoButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gotoButton.Click
      Dim vehicleId As Integer


      If gotoVehicleIdTextBox.Text.Trim().Length = 0 Then
        MessageBox.Show("Provide VehicleId to search for.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        gotoVehicleIdTextBox.Focus()
        Exit Sub

      ElseIf Integer.TryParse(gotoVehicleIdTextBox.Text, vehicleId) = False Then
        MessageBox.Show("Provide proper VehicleId to search for.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        gotoVehicleIdTextBox.Focus()
        gotoVehicleIdTextBox.SelectAll()
        Exit Sub
      End If

      Try
        Processor.FindVehicle(vehicleId, FORM_NAME)
      Catch ex As System.Data.SqlClient.SqlException
        Trace.TraceError("gotoButton_Click(): FindVehicle. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, ex})
        MessageBox.Show("Unable to load information of vehicle " + vehicleId.ToString() + ". Error has occurred while saving information.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch ex As Exception
        Trace.TraceError("gotoButton_Click(): Unknown error. FindVehicle. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, ex})
        MessageBox.Show("Unable to load information of vehicle " + vehicleId.ToString() + ". Unknown error has occurred while loading information.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

    End Sub

    Private Sub clearButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clearButton.Click

      ClearAllInputs()
      RemoveAllErrorProviders()
      Me.FormState = FormStateEnum.Insert
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

      Processor.Data.Market.Clear()

    End Sub


    Private Sub m_familyCheckInProcessor_Initialized() Handles m_familyCheckInProcessor.Initialized

      Me.StatusMessage = String.Empty

    End Sub

    Private Sub m_familyCheckInProcessor_Initializing() Handles m_familyCheckInProcessor.Initializing

      Me.StatusMessage = "Loading information. This may take some time. Please wait..."

    End Sub

    Private Sub m_familyCheckInProcessor_InvalidVehicleStatus(ByVal vehicleId As Integer, ByVal statusText As String) Handles m_familyCheckInProcessor.InvalidVehicleStatus

      Me.StatusMessage = String.Empty

      ClearAllInputs()
      RemoveAllErrorProviders()

      Me.FormState = FormStateEnum.View
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

      MessageBox.Show("Vehicle cannot be loaded because it has the Status of: " + statusText _
                      , Me.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

      gotoVehicleIdTextBox.Focus()
      gotoVehicleIdTextBox.SelectAll()

    End Sub

    Private Sub m_familyCheckInProcessor_LoadingMarketPublicationList() Handles m_familyCheckInProcessor.LoadingMarketPublicationList

      Me.StatusMessage = "Loading Markets. This may take some time, please wait..."

    End Sub

    Private Sub m_familyCheckInProcessor_LoadingRetailers() Handles m_familyCheckInProcessor.LoadingRetailers

      Me.StatusMessage = "Loading Retailers. This may take some time, please wait..."

    End Sub

    Private Sub m_familyCheckInProcessor_LoadingVehicle() Handles m_familyCheckInProcessor.LoadingVehicle

      Me.StatusMessage = "Loading Vehicle information. This may take some time, please wait..."

    End Sub

    Private Sub m_familyCheckInProcessor_LoadingVehicles() Handles m_familyCheckInProcessor.LoadingVehicles

      Me.StatusMessage = "Loading Vehicles. This may take some time, please wait..."

    End Sub

    Private Sub m_familyCheckInProcessor_MarketPublicationListLoaded() Handles m_familyCheckInProcessor.MarketPublicationListLoaded

      Me.StatusMessage = String.Empty

    End Sub

    Private Sub m_familyCheckInProcessor_RetailersLoaded() Handles m_familyCheckInProcessor.RetailersLoaded

      Me.StatusMessage = String.Empty

    End Sub

    Private Sub m_familyCheckInProcessor_UpdatingVehicle() Handles m_familyCheckInProcessor.UpdatingVehicle

      Me.StatusMessage = "Updating vehicle inforamtion. This may take some time, please wait..."

    End Sub

    Private Sub m_familyCheckInProcessor_VehiclesNotFound() Handles m_familyCheckInProcessor.VehicleNotFound
      Dim vehicleId As String

      Me.StatusMessage = String.Empty
      vehicleId = gotoVehicleIdTextBox.Text

      MessageBox.Show("Specified Vehicle " & vehicleId & " not found.", ProductName _
                      , MessageBoxButtons.OK, MessageBoxIcon.Information)
      ClearAllInputs()
      RemoveAllErrorProviders()

      Me.FormState = FormStateEnum.View
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

      gotoVehicleIdTextBox.Text = vehicleId
      gotoVehicleIdTextBox.Focus()
      gotoVehicleIdTextBox.SelectAll()

    End Sub

    Private Sub m_familyCheckInProcessor_VehicleLoaded(ByVal vehicleRow As FamilyCheckInDataSet.vwCircularRow) Handles m_familyCheckInProcessor.VehicleLoaded
      m_RetNeedsReload = True


      ClearAllInputs()

      m_searchedVehicleId = vehicleRow.VehicleId
      loadjoinFamilyButton.Enabled = vehicleRow.IsFamilyIdNull()

      adDateTypeInDatePicker.Value = vehicleRow.BreakDt
      mediaComboBox.SelectedValue = vehicleRow.MediaId
      If m_RetNeedsReload Then
        AddateAndMedia_ValueChanged(Nothing, Nothing)
      End If
      If vehicleRow.IsLanguageIdNull() Then
        If vehicleRow.RetailerRow.IsLanguageIdNull Then
          languageComboBox.SelectedValue = DBNull.Value
        Else
          languageComboBox.SelectedValue = vehicleRow.RetailerRow.LanguageId
        End If
      Else
        languageComboBox.SelectedValue = vehicleRow.LanguageId
      End If
      If vehicleRow.IsEventIdNull() Then
        eventComboBox.SelectedValue = DBNull.Value
      Else
        eventComboBox.SelectedValue = vehicleRow.EventId
      End If
      If vehicleRow.IsThemeIdNull() Then
        themeComboBox.SelectedValue = DBNull.Value
      Else
        themeComboBox.SelectedValue = vehicleRow.ThemeId
      End If
      If vehicleRow.IsStartDtNull() Then
        startDateTypeInDatePicker.Clear()
      Else
        startDateTypeInDatePicker.Text = vehicleRow.StartDt.ToString("MM/dd/yy")
      End If
      If vehicleRow.IsEndDtNull() Then
        endDateTypeInDatePicker.Clear()
      Else
        endDateTypeInDatePicker.Text = vehicleRow.EndDt.ToString("MM/dd/yy")
      End If
      If vehicleRow.IsCouponIndNull() OrElse (vehicleRow.CouponInd = 0) Then
        couponIndCheckBox.Checked = False
      Else
        couponIndCheckBox.Checked = True
      End If
      retailerComboBox.Focus()

      retailerComboBox.SelectedValue = vehicleRow.RetId

      Me.FormState = FormStateEnum.Insert
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

      Me.StatusMessage = String.Empty

    End Sub

    Private Sub m_familyCheckInProcessor_VehicleUpdated() Handles m_familyCheckInProcessor.VehicleUpdated

      Me.StatusMessage = String.Empty

    End Sub

    Private Sub FamilyCheckInForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
      gotoVehicleIdTextBox.Focus()
    End Sub

    Private Sub FamilyCheckInForm_FormInitialized() Handles Me.FormInitialized

      Me.StatusMessage = String.Empty

    End Sub

    Private Sub FamilyCheckInForm_InitializingForm() Handles Me.InitializingForm

      Me.StatusMessage = "Loading information. This may take some time. Please wait..."

    End Sub


    Private Sub scanButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles scanButton.Click
      Dim userResponse As DialogResult
      Dim vehicleIdArray() As String
      Dim multiScan As UI.Controls.MultipleScanForm


      multiScan = New UI.Controls.MultipleScanForm()
      userResponse = multiScan.ShowDialog(Me)

      If userResponse = Windows.Forms.DialogResult.OK Then
        vehicleIdArray = multiScan.vehicleIdTextBox.Lines
      End If

      multiScan.Dispose()
      multiScan = Nothing

      If vehicleIdArray IsNot Nothing AndAlso vehicleIdArray.Length > 0 Then
        Dim vehicleId As Integer
        Dim vehicleQuery As System.Data.EnumerableRowCollection(Of MCAP.FamilyCheckInDataSet.MarketRow)

        For i As Integer = 0 To vehicleIdArray.Length - 1
          If Integer.TryParse(vehicleIdArray(i), vehicleId) = False Then Continue For
          vehicleQuery = From r In Processor.Data.Market _
                         Where r.VehicleId = vehicleId _
                         Select r
          If vehicleQuery.Count() = 0 Then Continue For

          Dim itemIndex As Integer

          If showVehicleIdRadioButton.Checked Then
            itemIndex = marketCheckedListBox.FindStringExact(vehicleQuery(0).MktVehicleIdPg)
          Else
            itemIndex = marketCheckedListBox.FindStringExact(vehicleQuery(0).MktPubPg)
          End If

          If itemIndex >= 0 AndAlso marketCheckedListBox.GetItemChecked(itemIndex) = False Then
            marketCheckedListBox.SetItemChecked(itemIndex, True)
          End If
        Next
      End If

    End Sub

        Private Sub gotoVehicleIdTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gotoVehicleIdTextBox.TextChanged
            If IsNumeric(gotoVehicleIdTextBox.Text) = False Then
                gotoVehicleIdTextBox.Text = ""
            End If
        End Sub

        Private Sub languageComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles languageComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub eventComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles eventComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub themeComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles themeComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub
    End Class

End Namespace
