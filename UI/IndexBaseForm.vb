﻿Namespace UI


    Public Class IndexBaseForm
        Implements IDuplicateCheck


        Protected Enum EventInitiatorEnum
            Unknown = 0
            LoadButton = 1
            VehiclePageCropButton = 2
            RefreshButton = 3
        End Enum


        'Declared for DuplicateCheck.
        Private m_isPossibleDupFound, m_override, m_forReview, m_Duplicate As Boolean
        Private m_dupcheckFormId As Integer


        ''' <summary>
        ''' Gets or sets DupCheckForId to update vehicleId for new vehicles.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property DupcheckFormLogId() As Integer
            Get
                Return m_dupcheckFormId
            End Get
            Set(ByVal value As Integer)
                m_dupcheckFormId = value
            End Set
        End Property


        ''' <summary>
        ''' Updates VehicleId column of DupCheckFormLog table.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="dupcheckFormLogId"></param>
        ''' <remarks></remarks>
        Protected Sub UpdateVehicleIdForDupCheckFormLogId(ByVal vehicleId As Integer, ByVal dupcheckFormLogId As Integer)
            Dim tempAdapter As EnvelopeContentDataSetTableAdapters.vwCircularTableAdapter


            tempAdapter = New EnvelopeContentDataSetTableAdapters.vwCircularTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.UpdateVehicleIdForDupFormId(vehicleId, dupcheckFormLogId)
            tempAdapter.Dispose()
            tempAdapter = Nothing
        End Sub


#Region " Methods to show Errors / Warnings to user "


        ''' <summary>
        ''' Showing error popup to user based on error texts assigned to each column.
        ''' </summary>
        ''' <param name="errorTables"></param>
        ''' <remarks></remarks>
        Protected Sub ShowErrors(ByVal errorTables As MCAP.QCDataSet.ErrorsDataTable)
            Dim rowCounter As Integer
            Dim errorMessage As System.Text.StringBuilder
            'Dim errorQuery As System.Collections.Generic.IEnumerable(Of String)
            Dim errorQuery As System.Data.EnumerableRowCollection(Of QCDataSet.ErrorsRow)


            If errorTables.Count = 0 Then Exit Sub

            errorMessage = New System.Text.StringBuilder
            errorQuery = From er In errorTables
                         Select er

            errorMessage.Append("Invalid inputs found.")
            errorMessage.AppendLine(Environment.NewLine)  'i.e. 2 new lines
            For rowCounter = 0 To errorQuery.Count - 1
                errorMessage.Append((rowCounter + 1).ToString())
                errorMessage.Append(". ")
                errorMessage.Append(errorQuery(rowCounter).ColumnCaption)
                errorMessage.Append(" - ")
                errorMessage.AppendLine(errorQuery(rowCounter).Message)
            Next

            MessageBox.Show(errorMessage.ToString(), Application.ProductName,
                      MessageBoxButtons.OK, MessageBoxIcon.Error)

            errorMessage = Nothing

        End Sub

        ''' <summary>
        ''' Displays all warnings in a single messagebox.
        ''' </summary>
        ''' <param name="warningTable"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Function ShowWarnings(ByVal warningTable As MCAP.QCDataSet.WarningsDataTable) As System.Windows.Forms.DialogResult
            Dim warningCounter As Integer
            Dim userResponse As DialogResult
            Dim warningMessage As System.Text.StringBuilder
            Dim warningQuery As System.Collections.Generic.IEnumerable(Of String)


            warningMessage = New System.Text.StringBuilder
            warningQuery = From wr In warningTable
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

            userResponse = MessageBox.Show(warningMessage.ToString(), Application.ProductName,
                                     MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)

            warningMessage = Nothing

            Return userResponse

        End Function


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
        ''' <param name="marketId"></param>
        ''' <param name="publicationId"></param>
        ''' <param name="applyOverrideRestriction"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckForDuplication(ByVal marketId As Integer, ByVal publicationId As Integer, ByVal applyOverrideRestriction As Boolean, ByVal formName As String) _
        As DuplicateCheckUserResponse _
        Implements IDuplicateCheck.CheckForDuplication
            Dim dateRange, retailerId As Integer
            Dim userResponse As DialogResult
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
                    possibleDupVehicles = New UI.DupCheckForm(retailerId, marketId, adDate, mediaList, languageId, applyOverrideRestriction, formName)
                    dateRange = 3

                Case "ROP"
                    mediaList.Clear()
                    mediaList.Add("ROP")
                    possibleDupVehicles = New UI.DupCheckForm(retailerId, marketId, publicationId, adDate, mediaList, languageId, applyOverrideRestriction, formName)
                    dateRange = 3

                Case "CATALOG", "IN-STORE", "INSERT", "MAILER", "ROP - CIRCULAR", "MONTHLY BOOKLET",
                    "PICK-UP IN-STORE", "INTERNET", "INSERT-DIGITAL", "IN-STORE-DIGITAL", "MAILER-DIGITAL",
                        "INSERT-AC PAPER", "INSERT-AC DIGITAL", "IN-STORE-AC DIGITAL"
                    mediaList.Clear()
                    mediaList.Add("Catalog")
                    mediaList.Add("In-Store")
                    mediaList.Add("Insert")
                    mediaList.Add("Mailer")
                    mediaList.Add("Internet")
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
                    possibleDupVehicles = New UI.DupCheckForm(retailerId, marketId, adDate, mediaList, startDate, endDate, languageId, applyOverrideRestriction, formName)
                    If mediaComboBox.Text.ToUpper() = "CATALOG" Then
                        dateRange = 14
                    Else
                        dateRange = 5
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
                    possibleDupVehicles = New UI.DupCheckForm(retailerId, marketId, adDate, mediaList, startDate, endDate, languageId, applyOverrideRestriction, formName)
                    dateRange = 5

            End Select

            possibleDupVehicles.RemoveVehicle = CType("0" + vehicleIdValueLabel.Text, Integer)
            possibleDupVehicles.dateRangeNumericUpDown.Value = dateRange
            possibleDupVehicles.Init(FormStateEnum.View)
            If possibleDupVehicles.IsPossibleDuplicateRecordsFound Then
                possibleDupVehicles.ApplyUserCredentials()
                userResponse = possibleDupVehicles.ShowDialog(Me)
                m_isPossibleDupFound = True
            Else
                userResponse = Windows.Forms.DialogResult.OK
                m_isPossibleDupFound = False
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
        ''' Allows derived classes to write process for Find button's click event by overriding this method.
        ''' </summary>
        ''' <param name="vehicleId">Vehicle Id provided in FindVehicleId textbox.</param>
        ''' <param name="eventInitiator"></param>
        ''' <remarks>
        ''' -1 is supplied as VehicleId if nothing or invalid integer value is specified in findVehicleId textbox.
        ''' </remarks>
        Protected Overridable Sub OnFindVehicle(ByVal vehicleId As Integer, ByVal eventInitiator As EventInitiatorEnum)

        End Sub

        ''' <summary>
        ''' Allows derived classes to write process to be executed when SelectedValueChanged event of media combobox 
        ''' is raised.
        ''' </summary>
        ''' <param name="mediaId"></param>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Protected Overridable Sub OnMediaChanged(ByVal mediaId As Integer, ByVal marketId As Integer, ByVal naPubOnly As Boolean, ByVal IsFSI As Boolean)

        End Sub

        ''' <summary>
        ''' Allows derived classes to write process to be executed when SelectedValueChanged event of market combobox 
        ''' is raised.
        ''' </summary>
        ''' <param name="marketId"></param>
        ''' <param name="mediaId"></param>
        ''' <remarks></remarks>
        Protected Overridable Sub OnMarketChanged(ByVal marketId As Integer, ByVal mediaId As Integer, ByVal naPubOnly As Boolean)

        End Sub

        ''' <summary>
        ''' Allows derived classes to write process to be executed when SelectedValueChanged event of publication
        ''' combobox is raised.
        ''' </summary>
        ''' <param name="publicationId"></param>
        ''' <remarks></remarks>
        Protected Overridable Sub OnPublicationChanged(ByVal publicationId As Integer)

        End Sub

        ''' <summary>
        ''' Allows derived classes to write process to be executed when Validating event of ad date input.
        ''' </summary>
        ''' <param name="adDate">Ad Date</param>
        ''' <param name="Cancel">Allows user to specify to cancel the event.</param>
        ''' <remarks></remarks>
        Protected Overridable Sub OnAdDateValidating(ByVal adDate As Nullable(Of DateTime), ByRef Cancel As Boolean)

        End Sub

        ''' <summary>
        ''' Allows derived classes to write process to be executed when SelectedValueChanged event of retailer
        ''' combobox is raised.
        ''' </summary>
        ''' <param name="retailerId"></param>
        ''' <param name="tradeclassId"></param>
        ''' <param name="tradeclass"></param>
        ''' <remarks></remarks>
        Protected Overridable Sub OnRetailerChanged(ByVal retailerId As Integer, ByVal tradeclassId As Integer, ByVal tradeclass As String)

        End Sub

        ''' <summary>
        ''' Allows derived classes to write process to be executed when focus is moved out from retailer drop down
        ''' to some other control.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overridable Sub OnRetailerValidated()

        End Sub

        ''' <summary>
        ''' Allows derived classes to write process to be executed when Validating event of start date input.
        ''' </summary>
        ''' <param name="adDate">Ad Date</param>
        ''' <param name="startDate">Start Date</param>
        ''' <param name="Cancel">Allows user to specify to cancel the event.</param>
        ''' <remarks></remarks>
        Protected Overridable Sub OnStartDateValidating(ByVal adDate As Nullable(Of DateTime), ByVal startDate As Nullable(Of DateTime), ByRef Cancel As Boolean)

        End Sub

        ''' <summary>
        ''' Allows derived classes to write process to be executed when Validating event of end date input.
        ''' </summary>
        ''' <param name="adDate">Ad Date</param>
        ''' <param name="startDate">Start Date</param>
        ''' <param name="endDate">End Date</param>
        ''' <param name="Cancel">Allows user to specify to cancel the event.</param>
        ''' <remarks></remarks>
        Protected Overridable Sub OnEndDateValidating(ByVal adDate As Nullable(Of DateTime), ByVal startDate As Nullable(Of DateTime), ByVal endDate As Nullable(Of DateTime), ByRef Cancel As Boolean)

        End Sub

        ''' <summary>
        ''' Allows derived classes to write process for showing form to define vehicle pages information.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <remarks></remarks>
        Protected Overridable Sub OnDefinePages(ByVal vehicleId As Integer)

        End Sub

        ''' <summary>
        ''' Allows derived classes to write process for printing barcode label for vehicle.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <remarks></remarks>
        Protected Overridable Sub OnPrintLabel(ByVal vehicleId As Integer)

        End Sub

        Protected Sub loadButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles loadButton.Click
            Dim vehicleId As Integer


            'If findVehicleIdTextBox.Text.Trim.Length = 0 Then
            '    MessageBox.Show("Provide Vehicle Id to load Vehicle information.", ProductName _
            '                    , MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    findVehicleIdTextBox.Focus()
            '    Exit Sub
            If Integer.TryParse(findVehicleIdTextBox.Text, vehicleId) = False Or findVehicleIdTextBox.Text.Trim.Length = 0 Then
                MessageBox.Show("Please enter a valid ID.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                vehicleId = -1
                findVehicleIdTextBox.Focus()
                findVehicleIdTextBox.SelectAll()
                Exit Sub
            End If

            OnFindVehicle(vehicleId, EventInitiatorEnum.LoadButton)
            'If vehicle found and loaded successfully.
            If vehicleId.ToString() = vehicleIdValueLabel.Text Then
                ShowHideControls(Me.FormState)
                EnableDisableControls(Me.FormState)
            Else
                findVehicleIdTextBox.Text = CType(vehicleId, String)
                findVehicleIdTextBox.SelectAll()
                findVehicleIdTextBox.Focus()
            End If

        End Sub

        Private Sub mediaComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mediaComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub mediaComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mediaComboBox.SelectedValueChanged
            Dim mktId, mediaId As Integer
            Dim naPubOnly, isFSI As Boolean
            Dim mediaAdapter As EnvelopeContentDataSetTableAdapters.MediaTableAdapter
            mediaAdapter = New EnvelopeContentDataSetTableAdapters.MediaTableAdapter



            naPubOnly = False
            isFSI = False

            If mediaComboBox.SelectedValue Is Nothing _
              OrElse Integer.TryParse(mediaComboBox.SelectedValue.ToString(), mediaId) = False _
            Then
                mediaId = -1
            End If

            If marketComboBox.SelectedValue Is Nothing _
              OrElse Integer.TryParse(marketComboBox.SelectedValue.ToString(), mktId) = False _
            Then
                mktId = -1
            End If

            If mediaId < 0 Then Exit Sub


            'changed to get media
            Try
                If CType(mediaAdapter.GetIndIgnorePublication(mediaId), Integer) = 1 Then
                    naPubOnly = True
                End If
                If CType(mediaAdapter.GetIndTreatAsFSI(mediaId), Integer) = 1 Then
                    isFSI = True
                End If
            Catch ex As System.Data.SqlClient.SqlException
                MessageBox.Show("Error has occurred " + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try


            OnMediaChanged(mediaId, mktId, naPubOnly, isFSI)

        End Sub

        Private Sub marketComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles marketComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub marketComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles marketComboBox.SelectedValueChanged
            Dim mktId, mediaId As Integer
            Dim naPubOnly As Boolean = False
            Dim mediaAdapter As EnvelopeContentDataSetTableAdapters.MediaTableAdapter
            mediaAdapter = New EnvelopeContentDataSetTableAdapters.MediaTableAdapter


            If mediaComboBox.SelectedValue Is Nothing _
        OrElse Integer.TryParse(mediaComboBox.SelectedValue.ToString(), mediaId) = False _
      Then
                mediaId = -1
            End If

            If marketComboBox.SelectedValue Is Nothing _
        OrElse Integer.TryParse(marketComboBox.SelectedValue.ToString(), mktId) = False _
      Then
                mktId = -1
            End If

            If mediaId < 0 Then Exit Sub

            If CType(mediaAdapter.GetIndIgnorePublication(mediaId), Integer) = 1 Then
                naPubOnly = True
            End If

            OnMarketChanged(mktId, mediaId, naPubOnly)

        End Sub

        Private Sub publicationComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles publicationComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub publicationComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles publicationComboBox.SelectedValueChanged
            Dim publicationId As Integer


            If publicationComboBox.SelectedValue Is Nothing _
        OrElse Integer.TryParse(publicationComboBox.SelectedValue.ToString(), publicationId) = False _
      Then
                publicationId = -1
            End If

            OnPublicationChanged(publicationId)

        End Sub

        Private Sub adDateTypeInDatePicker_Validating _
            (ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles adDateTypeInDatePicker.Validating
            Dim Cancel As Boolean


            OnAdDateValidating(adDateTypeInDatePicker.Value, Cancel)

            e.Cancel = Cancel

        End Sub

        Private Sub retailerComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles retailerComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub retailerComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles retailerComboBox.SelectedValueChanged
            Dim retId, tradeclassId As Integer
            Dim tradeclass As String


            If retailerComboBox.SelectedValue Is Nothing _
          OrElse Integer.TryParse(retailerComboBox.SelectedValue.ToString(), retId) = False _
      Then
                retId = -1
                tradeclassId = -1
                tradeclass = String.Empty
            Else
                Dim tempTable As QCDataSet.RetDataTable
                Dim tempRow As QCDataSet.RetRow

                tempTable = CType(Me.retailerComboBox.DataSource, QCDataSet.RetDataTable)
                tempRow = tempTable.FindByRetId(retId)
                If tempRow.IsTradeClassIdNull() Then
                    tradeclassId = -1
                    tradeclass = String.Empty
                Else
                    tradeclassId = tempRow.TradeClassId
                    tradeclass = tempRow.TradeClassRow.Descrip
                End If
            End If

            tradeclassValueLabel.Text = tradeclass

            OnRetailerChanged(retId, tradeclassId, tradeclass)

        End Sub

        Private Sub retailerComboBox_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles retailerComboBox.Validated

            OnRetailerValidated()

        End Sub

        Private Sub startDateTypeInDatePicker_Validating _
        (ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles startDateTypeInDatePicker.Validating
            Dim Cancel As Boolean


            ' OnStartDateValidating(adDateTypeInDatePicker.Value, startDateTypeInDatePicker.Value, Cancel)

            e.Cancel = Cancel

        End Sub

        Private Sub endDateTypeInDatePicker_Validating _
        (ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles endDateTypeInDatePicker.Validating
            Dim Cancel As Boolean


            OnEndDateValidating(adDateTypeInDatePicker.Value, startDateTypeInDatePicker.Value, endDateTypeInDatePicker.Value, Cancel)

            e.Cancel = Cancel

        End Sub

        Private Sub definePagesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles definePagesButton.Click
            Dim vehicleId As Integer


            If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
                vehicleId = -1
            End If

            If vehicleId < 1 Then
                MessageBox.Show("Please load Vehicle to define its pages.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            OnDefinePages(vehicleId)

        End Sub

        Private Sub findVehicleIdTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles findVehicleIdTextBox.KeyPress

            '3 - Copy, 22 - Paste and 24 - Cut, 8 - Backspace
            If Microsoft.VisualBasic.AscW(e.KeyChar) = 3 _
        OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 22 _
        OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 24 _
        OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 8 _
      Then
                Exit Sub 'Process as it should.
            End If

            If Microsoft.VisualBasic.AscW(e.KeyChar) = 13 Then loadButton.PerformClick()

            If Char.IsDigit(e.KeyChar) = False Then e.Handled = True

        End Sub

        Private Sub findVehicleIdTextBox_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles findVehicleIdTextBox.Validating

        End Sub

        Private Sub findVehicleIdTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles findVehicleIdTextBox.TextChanged
            If IsNumeric(findVehicleIdTextBox.Text) = False Then
                findVehicleIdTextBox.Text = String.Empty
            End If
        End Sub

        Private Sub retailerComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles retailerComboBox.SelectedIndexChanged

        End Sub

        Private Sub mediaComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mediaComboBox.SelectedIndexChanged

        End Sub

        Private Sub marketComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles marketComboBox.SelectedIndexChanged

        End Sub

        Private Sub publicationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles publicationComboBox.SelectedIndexChanged

        End Sub

        Private Sub languageComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles languageComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub languageComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles languageComboBox.SelectedIndexChanged

        End Sub

        Private Sub eventComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles eventComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub eventComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eventComboBox.SelectedIndexChanged

        End Sub

        Private Sub themeComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles themeComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub themeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles themeComboBox.SelectedIndexChanged

        End Sub
    End Class


End Namespace
