Namespace UI

    Public Class CCTasksLogForm
        Implements IForm

#Region "Events"

#End Region

        ''' <summary>
        ''' This constant is used to assigning value to FormName column.
        ''' </summary>
        ''' <remarks></remarks>
        Private Const FORM_NAME As String = "CC Tasks Log Form"
        Private WithEvents m_tasklogProcessor As Processors.CCTaskLog
        Private m_isFiltered As Boolean
        Private pageLoadedComplete As Boolean
        Private mktClicked As Boolean
        Private sndrClicked As Boolean
        Private filterHelp As CCTasksLogSenderDetailsForm
        Private saveHelp As CCFormsSubmitMessageBox
        Private TaskLogId As Integer

        Protected Enum EventInitiatorEnum
            Unknown = 0
            LoadButton = 1
            VehiclePageCropButton = 2
            RefreshButton = 3
        End Enum

        Private ReadOnly Property Processor() As Processors.CCTaskLog
            Get
                Return m_tasklogProcessor
            End Get
        End Property

        ''' <summary>
        ''' Gets true if table contains more then maximum number of rows allowed, false otherwise.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property IsFilteredTable() As Boolean
            Get
                Return m_isFiltered
            End Get
        End Property



#Region " IForm Implementation "


        Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
        Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied

        Public Event InitializingForm() Implements IForm.InitializingForm
        Public Event FormInitialized() Implements IForm.FormInitialized


        Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

        End Sub

        Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init



            Me.SuspendLayout()

            RaiseEvent InitializingForm()

            Me.FormState = formStatus

            m_tasklogProcessor = New Processors.CCTaskLog()
            Processor.Initialize()

            LoadPageData()


            RaiseEvent FormInitialized()
            Me.ResumeLayout()
            pageLoadedComplete = True

            mktClicked = False
            sndrClicked = False

            RaiseEvent FormInitialized()

        End Sub

        Private Sub LoadPageData()

            Dim HourIntervalNow As Integer
            Dim MinIntervalNow As Integer
            Dim ByHourIntervalNow As String
            Dim ByHourIntervalArray(24) As String
            Dim ByAMPM As String

            ByHourIntervalArray = New String() {"12:00AM", "12:30AM", "1:00AM", "1:30AM", "2:00AM", "2:30AM", "3:00AM", "3:30AM", "4:00AM", "4:30AM", "5:00AM", "5:30AM", "6:00AM", "6:30AM", "7:00AM", _
                                "7:30AM", "8:00AM", "8:30AM", "9:00AM", "9:30AM", "10:00AM", "10:30AM", "11:00AM", "11:30AM", "12:00PM", "12:30PM", "1:00PM", "1:30PM", "2:00PM", "2:30PM", "3:00PM", "3:30PM", "4:00PM", "4:30PM", "5:00PM", "5:30PM", "6:00PM", "6:30PM", "7:00PM", _
                                "7:30PM", "8:00PM", "8:30PM", "9:00PM", "9:30PM", "10:00PM", "10:30PM", "11:00PM", "11:30PM"}

            Dim dateformat As String
            dateformat = "MMM ddd d HH:mm yyyy"
            pageLoadedComplete = False
            editTableGroupBox.Text = String.Empty

            Processor.LoadAssignedUsers(User.LocationId)
            AssignedComboBox.DisplayMember = "FullName"
            AssignedComboBox.ValueMember = "UserId"
            AssignedComboBox.DataSource = Processor.Data.User
            AssignedComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            'Processor.ByHourlyTime()
            TimeComboBox.DisplayMember = "intervalName"
            TimeComboBox.ValueMember = "intervalId"
            TimeComboBox.DataSource = ByHourIntervalArray 'Processor.Data.ByHourInterval
            HourIntervalNow = DateTime.Now.Hour
            MinIntervalNow = DateTime.Now.Minute

            Processor.LoadMedia()
            MediaComboBox.DisplayMember = "Descrip"
            MediaComboBox.ValueMember = "MediaID"
            MediaComboBox.DataSource = Processor.Data.Media
            MediaComboBox.SelectedIndex = -1
            MediaComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            Processor.LoadRetailer()
            RetailerComboBox.DisplayMember = "Descrip"
            RetailerComboBox.ValueMember = "RetId"
            RetailerComboBox.DataSource = Processor.Data.Ret
            RetailerComboBox.SelectedIndex = -1
            RetailerComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            Processor.LoadMarket()
            MarketComboBox.DisplayMember = "Descrip"
            MarketComboBox.ValueMember = "MktId"
            MarketComboBox.DataSource = Processor.Data.Mkt
            MarketComboBox.SelectedIndex = -1
            MarketComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            Processor.LoadSender()
            SenderComboBox.DisplayMember = "Name"
            SenderComboBox.ValueMember = "SenderId"
            SenderComboBox.DataSource = Processor.Data.Sender
            SenderComboBox.SelectedIndex = -1
            SenderComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            Processor.LoadPublication()
            PublicationNameComboBox.DisplayMember = "Descrip"
            PublicationNameComboBox.ValueMember = "PublicationId"
            PublicationNameComboBox.DataSource = Processor.Data.Publication
            PublicationNameComboBox.SelectedIndex = -1
            PublicationNameComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            If HourIntervalNow > 12 Then
                HourIntervalNow = (HourIntervalNow - 12)
                ByAMPM = "PM"
            Else
                ByAMPM = "AM"
            End If

            ByHourIntervalNow = HourIntervalNow.ToString() + ":" + MinIntervalNow.ToString()
            If (MinIntervalNow > 30) Then
                MinIntervalNow = 30
                ByHourIntervalNow = HourIntervalNow.ToString() + ":" + MinIntervalNow.ToString()
            Else
                MinIntervalNow = 0
                ByHourIntervalNow = HourIntervalNow.ToString() + ":0" + MinIntervalNow.ToString()
            End If
            TimeComboBox.SelectedIndex = getArrayIndex(ByHourIntervalArray, ByHourIntervalNow + ByAMPM) '- 1

            If TimeComboBox.SelectedValue Is Nothing Then
                TimeComboBox.SelectedIndex = 23
            End If
            TimeComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            Processor.LoadCCStatus("CCStatus")
            statusComboBox.ValueMember = "codeid"
            statusComboBox.DisplayMember = "codedescrip"
            statusComboBox.DataSource = Processor.Data.CCStatus
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            Processor.LoadCCUrgency("CCUrgency")
            urgencyComboBox.ValueMember = "codeid"
            urgencyComboBox.DisplayMember = "codedescrip"
            urgencyComboBox.DataSource = Processor.Data.CCUrgency
            urgencyComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            Processor.LoadCCActionType("CCActionType")
            ActionTypeComboBox.ValueMember = "codeid"
            ActionTypeComboBox.DisplayMember = "codedescrip"
            ActionTypeComboBox.DataSource = Processor.Data.CCActionType
            ActionTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            Processor.LoadCCSpecificAction("CCSpecificAction")
            SpecificActionComboBox.ValueMember = "codeid"
            SpecificActionComboBox.DisplayMember = "Descrip"
            SpecificActionComboBox.DataSource = Processor.Data.CCSpecificAction
            SpecificActionComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            currentdateTypeInDatePicker.Value = DateTime.Today
            addateTypeInDatePicker.Value = DateTime.Today
            DueDateTypeInDatePicker.Value = DateTime.Today
            MissingAdIdLabel.Text = String.Empty ' CStr(CType(Processor.getMissingAdLabelId(), Integer) + 1)

            'OtherContactDisabled()


            CreatedByLabel.Text = User.FName.ToString() + " " + User.LName.ToString()
            CommentsTextBox.Text = String.Empty
            'enableDisableFormComponents(FormStateEnum.Insert)

        End Sub

#End Region

        Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click
            Me.Close()
        End Sub


        Private Sub OtherContactCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtherContactCheckBox.CheckedChanged

            If OtherContactCheckBox.Checked = False Then
                OtherContactDisabled()
            Else
                NameTextBox.Enabled = True
                PhoneNoTextBox.Enabled = True
                PersonSpokeToTextBox.Enabled = True

            End If
        End Sub


        Private Sub OtherContactDisabled()
            NameTextBox.Enabled = False
            PhoneNoTextBox.Enabled = False
            PersonSpokeToTextBox.Enabled = False
            NameTextBox.Text = ""
            PhoneNoTextBox.Text = ""
            PersonSpokeToTextBox.Text = ""

        End Sub


        Private Function getArrayIndex(ByVal myarray() As String, ByVal myval As String) As Integer

            Dim cntr As Integer
            Dim arryInd As Integer

            For cntr = 0 To UBound(myarray)
                If myval = myarray(cntr) Then
                    arryInd = cntr
                End If
            Next
            Return arryInd

        End Function

        Private Sub MarketComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarketComboBox.SelectedIndexChanged
            If MarketComboBox.SelectedIndex <> -1 Then RemoveErrorProvider(MarketComboBox)
            'Dim tempcount As Integer
            'Dim retailerId As Integer

            'Dim mktId, mediaId As Integer
            'Dim naPubOnly As Boolean = False
            'Dim mediaAdapter As CoverageDataSetTableAdapters.MediaTableAdapter
            'mediaAdapter = New CoverageDataSetTableAdapters.MediaTableAdapter

            'If MediaComboBox.SelectedValue Is Nothing _
            '  OrElse Integer.TryParse(MediaComboBox.SelectedValue.ToString(), mediaId) = False _
            'Then
            '    mediaId = -1
            'End If

            'If MarketComboBox.SelectedValue Is Nothing _
            '  OrElse Integer.TryParse(MarketComboBox.SelectedValue.ToString(), mktId) = False _
            'Then
            '    mktId = -1
            'End If

            'If RetailerComboBox.SelectedValue Is Nothing _
            '  OrElse Integer.TryParse(RetailerComboBox.SelectedValue.ToString(), retailerId) = False _
            'Then
            '    retailerId = -1
            'End If

            'If mktId < 0 Then
            '    Exit Sub
            'End If


            'If CType(mediaAdapter.GetIndIgnorePublication(mediaId), Integer) = 1 Then
            '    naPubOnly = True
            'End If

            'If pageLoadedComplete Then
            '    If mediaId < 0 Then
            '        Processor.LoadMktMedia(mktId)
            '        MediaComboBox.SelectedIndex = -1
            '    End If
            '    If retailerId < 0 Then

            '    End If
            '    OnMarketChanged(mktId, mediaId, naPubOnly)
            'End If
        End Sub


        Private Sub mediaComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MediaComboBox.SelectedValueChanged
            'Dim mktId, mediaId As Integer
            'Dim naPubOnly, isFSI As Boolean

            'Dim mediaAdapter As CoverageDataSetTableAdapters.MediaTableAdapter
            'mediaAdapter = New CoverageDataSetTableAdapters.MediaTableAdapter

            'If MediaComboBox.SelectedValue Is Nothing _
            '  OrElse Integer.TryParse(MediaComboBox.SelectedValue.ToString(), mediaId) = False _
            'Then
            '    mediaId = -1
            'End If

            'If MarketComboBox.SelectedValue Is Nothing _
            '  OrElse Integer.TryParse(MarketComboBox.SelectedValue.ToString(), mktId) = False _
            'Then
            '    mktId = -1
            'End If

            'If mediaId < 0 Then Exit Sub
            ''changed to get media
            'Try
            '    If CType(mediaAdapter.GetIndIgnorePublication(mediaId), Integer) = 1 Then
            '        naPubOnly = True
            '    End If
            '    If CType(mediaAdapter.GetIndTreatAsFSI(mediaId), Integer) = 1 Then
            '        isFSI = True
            '    End If
            'Catch ex As System.Data.SqlClient.SqlException
            '    MessageBox.Show("Error has occurred " + ex.Message) ', ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try

            ''changed to get media
            'OnMediaChanged(mediaId, mktId, naPubOnly, isFSI)

        End Sub


        Private Sub RetailerComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetailerComboBox.SelectedIndexChanged
            If RetailerComboBox.SelectedIndex <> -1 Then RemoveErrorProvider(RetailerComboBox)
            'Dim retId, tradeclassId As Integer
            'Dim tradeclass As String

            'If RetailerComboBox.SelectedValue Is Nothing _
            '    OrElse Integer.TryParse(RetailerComboBox.SelectedValue.ToString(), retId) = False _
            'Then
            '    retId = -1
            '    tradeclassId = -1
            '    tradeclass = String.Empty
            '    Exit Sub
            'Else
            '    If retId < 0 Then
            '        Exit Sub
            '    End If

            '    Dim tempTable As CoverageDataSet.RetDataTable
            '    Dim tempRow As CoverageDataSet.RetRow
            '    tempTable = CType(Me.RetailerComboBox.DataSource, CoverageDataSet.RetDataTable)
            '    tempRow = tempTable.FindByRetId(retId)
            '    If tempRow.IsTradeClassIdNull() Then
            '        tradeclassId = -1
            '        tradeclass = String.Empty
            '    Else
            '        tradeclassId = tempRow.TradeClassId
            '        'tradeclass = tempRow.TradeClassRow.Descrip
            '    End If
            'End If


            'OnRetailerChanged(retId, tradeclassId, tradeclass)
        End Sub

        Protected Sub OnRetailerChanged(ByVal retailerId As Integer, ByVal tradeclassId As Integer, ByVal tradeclass As String)
            If Me.FormState <> FormStateEnum.View Then
                Dim showFlashCheckBox As Boolean
                Dim mediaId, marketId As Integer

                If MediaComboBox.SelectedValue Is Nothing OrElse MediaComboBox.SelectedValue Is DBNull.Value Then
                    mediaId = -1
                ElseIf Integer.TryParse(MediaComboBox.SelectedValue.ToString(), mediaId) = False Then
                    mediaId = -1
                End If

                If MarketComboBox.SelectedValue Is Nothing OrElse MarketComboBox.SelectedValue Is DBNull.Value Then
                    marketId = -1
                ElseIf Integer.TryParse(MarketComboBox.SelectedValue.ToString(), marketId) = False Then
                    marketId = -1
                End If

                If pageLoadedComplete Then

                    If mediaId < 0 Then
                        Processor.LoadMedia(retailerId)
                        MediaComboBox.SelectedIndex = -1
                        'Else
                        '    Processor.LoadMedia(retailerId)
                        '    MediaComboBox.SelectedIndex = -1

                    End If

                    If marketId < 0 Then
                        Processor.LoadMarket(retailerId)
                        MarketComboBox.SelectedIndex = -1
                        'Else
                        '    Processor.LoadMarket(retailerId)
                        '    MarketComboBox.SelectedIndex = -1
                    End If
                    Processor.LoadPublication()
                    Processor.LoadSender()
                    PublicationNameComboBox.SelectedIndex = -1
                    SenderComboBox.SelectedIndex = -1
                End If
            End If

        End Sub


        Protected Sub OnMediaChanged(ByVal mediaId As Integer, ByVal marketId As Integer, ByVal naPubOnly As Boolean, ByVal IsFSI As Boolean)

            If Me.FormState <> FormStateEnum.View Then
                If MediaComboBox.Text.ToUpper() = "CATALOG" Then
                    ' load markets
                    If marketId < 0 Then
                        Processor.LoadMarketsForCatalog(mediaId)
                        If MarketComboBox.Items.Count = 1 Then
                            MarketComboBox.SelectedIndex = -1
                        ElseIf MarketComboBox.Items.Count > 1 Then
                            MarketComboBox.SelectedIndex = -1
                        End If
                    End If
                Else
                    ' load markets
                    If marketId < 0 Then
                        Processor.LoadMarketByMedia(mediaId)
                        If MarketComboBox.Items.Count = 1 Then
                            'MarketComboBox.SelectedIndex = 0
                        Else
                            'MarketComboBox.Text = String.Empty
                            'MarketComboBox.SelectedValue = DBNull.Value
                            'MarketComboBox.SelectedIndex = -1
                        End If
                    End If

                End If

                If MarketComboBox.SelectedValue IsNot Nothing _
                  AndAlso Integer.TryParse(MarketComboBox.SelectedValue.ToString(), marketId) = False _
                Then
                    marketId = -1
                End If

                OnMarketChanged(marketId, mediaId, naPubOnly)
                Processor.LoadPublication()
                Processor.LoadSender()
                PublicationNameComboBox.SelectedIndex = -1
                SenderComboBox.SelectedIndex = -1

            End If

        End Sub

        Protected Sub OnMarketChanged(ByVal marketId As Integer, ByVal mediaId As Integer, ByVal naPubOnly As Boolean)
            If Me.FormState <> FormStateEnum.View Then
                Dim retailerId As Integer

                If marketId < 0 Then
                    Exit Sub
                End If

                If naPubOnly Then
                    Processor.LoadNAPublicationIndex()
                Else
                    Processor.LoadPublication(marketId)
                End If
                PublicationNameComboBox.SelectedIndex = -1

                If RetailerComboBox.SelectedValue Is Nothing Then
                    retailerId = -1

                    If mediaId < 0 Then
                        Processor.LoadRetailer(marketId)
                    Else
                        Processor.LoadRetailer(mediaId, marketId)
                    End If
                Else
                    retailerId = CType(RetailerComboBox.SelectedValue, Integer)
                End If


                If retailerId < 0 Then
                    RetailerComboBox.SelectedIndex = -1
                Else
                    RetailerComboBox.SelectedValue = retailerId
                End If

                If pageLoadedComplete Then
                    If sndrClicked = False Then
                        Processor.reLoadSender(marketId)
                        mktClicked = True
                        SenderComboBox.SelectedIndex = -1
                    End If
                End If
            End If
        End Sub

        Private Sub ActionTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionTypeComboBox.SelectedIndexChanged
            Dim actiontype As Integer

            If ActionTypeComboBox.SelectedValue Is Nothing Then
                actiontype = 0
            Else
                actiontype = CInt(ActionTypeComboBox.SelectedValue)
            End If
            OnActionTypeChanged(actiontype)
        End Sub

        Protected Sub OnActionTypeChanged(ByVal actiontype As Integer)
            Processor.LoadSpecificAction(actiontype)
        End Sub

        Private Sub m_tasklogProcessor_SynchronizingTaskLog(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_tasklogProcessor.SynchronizingTaskLog
            Dim userResponse As DialogResult
            Dim changesDataTable As Data.DataTable


            If e.Data.Contains("Changes") Then
                changesDataTable = CType(e.Data("Changes"), System.Data.DataTable)

                ''If changesDataTable.Rows.Count > 0 AndAlso Me.FormState = FormStateEnum.Insert Then
                ''    userResponse = Windows.Forms.DialogResult.Yes
                ''ElseIf changesDataTable.Rows.Count > 0 AndAlso Me.FormState = FormStateEnum.Edit Then
                ''    userResponse = MessageBox.Show("Are you sure you want to update Task Log information?", ProductName _
                ''                                   , MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                ''                                   , MessageBoxDefaultButton.Button2)
                ''End If
            End If

            If userResponse = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            Else
                Me.StatusMessage = "Saving tasklog information. Please wait..."
            End If

        End Sub


        Private Sub CreateTaskLogButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateTaskLogButton.Click
            Dim ccTaskLogsID As Integer
            Dim tempRow As CoverageDataSet.CCTaskLogsRow
            Dim strMessage As String


            If AreInputsValid() = False Then Exit Sub

            If FormState = FormStateEnum.Insert Then
                tempRow = Processor.CreateNew()
            Else
                'ccTaskLogsID = CType(MissingAdIdLabel.Text, Integer) - 1
                tempRow = Processor.Data.CCTaskLogs(0)
            End If

            SetColumnValues(tempRow)

            Try
                If Me.FormState = FormStateEnum.Insert Then Processor.Add(tempRow)
                Processor.Save()
                If Me.FormState = FormStateEnum.Insert Then
                    ShowSavedDetails(tempRow)
                Else
                    strMessage = "Record Id: " + MissingAdIdLabel.Text + " has been successfully Modified"
                    MessageBox.Show(strMessage.ToString(), Application.ProductName, _
                                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadPageData()
                End If


            Catch ex As System.ApplicationException
                Trace.TraceError("CCTaskLogs.CreateTaskLogButton_Click():Saving CC Task Logs. Message=" + ex.Message, New Object() {"FormState=", Me.FormState.ToString(), "DataRow=", tempRow})
                ShowErrors(tempRow)
            Catch ex As System.Exception
                Trace.TraceError("CCTaskLogs.CreateTaskLogButton_Click():Saving CC Task Logs. Message=" + ex.Message, New Object() {"FormState=", Me.FormState.ToString(), "DataRow=", tempRow})
                If Me.FormState = FormStateEnum.Insert Then
                    MessageBox.Show("CC Task Logs record not created. Unknown error has occurred while checking-in new CC Task Logs." + ex.Message _
                          , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Changes not saved. Unknown error has occurred while saving changes." + ex.Message + ex.ToString() _
                          , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Try

            If CreateTaskLogButton.Text = "Update" And Me.FormState = FormStateEnum.Edit Then
                CreateTaskLogButton.Text = "Create"
            ElseIf Me.FormState = FormStateEnum.Edit Then
                CreateTaskLogButton.Text = "Update"
            End If
            Me.FormState = FormStateEnum.Insert
            OtherContactCheckBox.Checked = False
            MissingAdCheckBox.Checked = False
            ClearDataSource()
        End Sub

        ''' <summary>
        ''' Showing popup to user after save
        ''' </summary>
        ''' <param name="envelopeRow"></param>
        ''' <remarks></remarks>
        Private Sub ShowSavedDetails(ByVal ccTaskLogsRow As MCAP.CoverageDataSet.CCTaskLogsRow)
            Dim columnCounter As Integer
            Dim strMessage As String
            Dim strCols() As Data.DataColumn


            If ccTaskLogsRow.HasErrors = True Then Exit Sub

            ' If FormState = FormStateEnum.Insert Then
            strMessage = "New Record Created. Record Id: " + Processor.getMissingAdLabelId()
            '' Else
            'strMessage = "Values saved.  Id: " + Processor.
            'End If

            'SaveMessageBox(CInt(Processor.getMissingAdLabelId()))

            MessageBox.Show(strMessage.ToString(), Application.ProductName, _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadPageData()

            strMessage = Nothing
            strCols = Nothing

        End Sub

        Private Sub ClearDataSource()
            With Processor.Data
                .Media.Clear()
                .Mkt.Clear()
                .Ret.Clear()
                .Publication.Clear()
            End With
        End Sub

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

            'If DueDateTypeInDatePicker.Value.HasValue = True _
            '    AndAlso currentdateTypeInDatePicker.Value.HasValue = True _
            'Then
            '    showMsg = False
            '    dateDifference = currentdateTypeInDatePicker.Value.Value.Subtract(DueDateTypeInDatePicker.Value.Value).Days

            '    If (dateDifference > 0) Then
            '        showMsg = True
            '        If showMsg Then
            '            dateMsg.MessageText = "Due Date should be greater than Start Date."
            '            If dateMsg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then Return False
            '        End If
            '    End If
            'End If
            'showMsg = False

            If DueDateTypeInDatePicker.Value.HasValue = True _
                            AndAlso addateTypeInDatePicker.Value.HasValue = True _
                        Then
                showMsg = False
                dateDifference = addateTypeInDatePicker.Value.Value.Subtract(DueDateTypeInDatePicker.Value.Value).Days

                If (dateDifference > 0) Then
                    showMsg = True
                    If showMsg Then
                        dateMsg.MessageText = "Due Date should be greater than Ad Date."
                        If dateMsg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then Return False
                    End If

                End If
            End If

            showMsg = False
            dateMsg.Dispose()
            dateMsg = Nothing

            Return Not showMsg

        End Function

        ''' <summary>
        ''' Validates user inputs. 
        ''' </summary>
        ''' <returns>True if all inputs are valid, false otherwise.</returns>
        ''' <remarks>
        ''' This method validates user inputs for its values only and not against 
        ''' any kind of business rules or anything else. For example, if date
        ''' value is expected, it checks whether its valid date or not. But does 
        ''' not check whether its within valid range or not.
        ''' </remarks>
        Private Function AreInputsValid() As Boolean
            Dim areAllValid As Boolean
            areAllValid = True

            If TimeComboBox.SelectedValue Is Nothing _
              OrElse TimeComboBox.SelectedIndex < 0 _
              OrElse TimeComboBox.Text.Length = 0 _
            Then
                SetErrorProvider(TimeComboBox, "Time must not be empty.")
                areAllValid = False
            Else
                RemoveErrorProvider(TimeComboBox)
            End If

            If urgencyComboBox.SelectedValue Is Nothing _
              OrElse urgencyComboBox.SelectedIndex < 0 _
              OrElse urgencyComboBox.Text.Length = 0 _
            Then
                SetErrorProvider(urgencyComboBox, "Urgency must not be empty.")
                areAllValid = False
            Else
                RemoveErrorProvider(urgencyComboBox)
            End If

            If statusComboBox.SelectedValue Is Nothing _
              OrElse statusComboBox.SelectedIndex < 0 _
              OrElse statusComboBox.Text.Length = 0 _
            Then
                SetErrorProvider(statusComboBox, "Status must not be empty.")
                areAllValid = False
            Else
                RemoveErrorProvider(statusComboBox)
            End If

            If AssignedComboBox.SelectedValue Is Nothing _
              OrElse AssignedComboBox.SelectedIndex < 0 _
              OrElse AssignedComboBox.Text.Length = 0 _
            Then
                SetErrorProvider(AssignedComboBox, "Assigned must not be empty.")
                areAllValid = False
            Else
                RemoveErrorProvider(AssignedComboBox)
            End If

            If SenderComboBox.SelectedValue Is Nothing _
            OrElse SenderComboBox.SelectedIndex < 0 _
            OrElse SenderComboBox.Text.Length = 0 _
            Then
                SetErrorProvider(SenderComboBox, "Sender must not be empty.")
                areAllValid = False
            Else
                RemoveErrorProvider(SenderComboBox)
            End If

            If MediaComboBox.SelectedValue Is Nothing _
            OrElse MediaComboBox.SelectedIndex < 0 _
            OrElse MediaComboBox.Text.Length = 0 _
            Then
                SetErrorProvider(MediaComboBox, "Media mus not be empty.")
                areAllValid = False
            Else
                RemoveErrorProvider(MediaComboBox)
            End If

            If MarketComboBox.SelectedValue Is Nothing _
            OrElse MarketComboBox.SelectedIndex < 0 _
            OrElse MarketComboBox.Text.Length = 0 _
            Then
                SetErrorProvider(MarketComboBox, "Market must not be empty.")
                areAllValid = False
            Else
                RemoveErrorProvider(MarketComboBox)
            End If

            If RetailerComboBox.SelectedValue Is Nothing _
            OrElse RetailerComboBox.SelectedIndex < 0 _
            OrElse RetailerComboBox.Text.Length = 0 _
            Then
                SetErrorProvider(RetailerComboBox, "Retailer must not be empty.")
                areAllValid = False
            Else
                RemoveErrorProvider(RetailerComboBox)
            End If

            'If DueDateTypeInDatePicker.Value Is Nothing _
            '  OrElse DueDateTypeInDatePicker.Text.Length = 0 _
            'Then
            '    SetErrorProvider(DueDateTypeInDatePicker, "Select due date.")
            '    areAllValid = False
            'Else
            '    RemoveErrorProvider(DueDateTypeInDatePicker)
            'End If

            If areAllValid Then areAllValid = ValidateBusinessRules()
            Return areAllValid

        End Function

        ''' <summary>
        ''' Sets column values of supplied row.
        ''' </summary>
        ''' <param name="tempRow"></param>
        ''' <remarks></remarks>
        Private Sub SetColumnValues(ByVal tempRow As CoverageDataSet.CCTaskLogsRow)

            Dim saveNow As DateTime = DateTime.Now

            ' callled
            tempRow.BeginEdit()
            tempRow.CCTaskLogsId = CInt(Processor.getMissingAdLabelId())

            If Me.FormState = FormStateEnum.Insert Then

                tempRow.UserId = User.UserID

            End If

            If currentdateTypeInDatePicker.Value Is Nothing Then
            Else
                tempRow._Date = CType(currentdateTypeInDatePicker.Value, Date)
            End If

            tempRow.Time = CType(TimeComboBox.SelectedValue, String)

            If DueDateTypeInDatePicker.Value Is Nothing Then
                'tempRow.DueDate = CType("", Date)
            Else
                tempRow.DueDate = CType(DueDateTypeInDatePicker.Value, Date)
            End If

            tempRow.Assigned = CType(AssignedComboBox.SelectedValue, Integer)
            tempRow.MarketId = CType(MarketComboBox.SelectedValue, Integer)
            tempRow.MediaId = CType(MediaComboBox.SelectedValue, Integer)
            tempRow.PublicationId = CType(PublicationNameComboBox.SelectedValue, Integer)
            tempRow.RetailerId = CType(RetailerComboBox.SelectedValue, Integer)
            tempRow.SenderId = CType(SenderComboBox.SelectedValue, Integer)

            If addateTypeInDatePicker.Value Is Nothing Then
                'tempRow.DueDate = CType("", Date)

            Else
                tempRow.AdDate = CType(addateTypeInDatePicker.Value, Date)

            End If

            'tempRow.MissingAd = CType(MissingAdComboBox.SelectedValue, Integer)

            If OtherContactCheckBox.Checked = True Then
                tempRow.OtherContactName = 1
            Else
                tempRow.OtherContactName = 0
            End If

            If MissingAdCheckBox.Checked = True Then
                tempRow.MissingAd = 1
            Else
                tempRow.MissingAd = 0
            End If

            If FlashCheckBox.Checked = True Then
                tempRow.Reminders = 1
            Else
                tempRow.Reminders = 0
            End If

            tempRow.SpecificAction = CType(SpecificActionComboBox.SelectedValue, Integer)
            tempRow.ActionType = CType(ActionTypeComboBox.SelectedValue, Integer)
            tempRow.Urgency = CType(urgencyComboBox.SelectedValue, Integer)
            tempRow.Status = CType(statusComboBox.SelectedValue, Integer)
            tempRow.PersonName = CType(NameTextBox.Text, String)
            tempRow.PhoneNoCalled = CType(PhoneNoTextBox.Text, String)
            tempRow.PersonSpokeWith = CType(PersonSpokeToTextBox.Text, String)
            tempRow.Comments = CType(CommentsTextBox.Text, String)

            If Me.FormState = FormStateEnum.Edit Then
                tempRow.LastSavedDate = saveNow 'CType(CommentsTextBox.Text, Date)
                tempRow.LastSavedUser = User.UserID 'CType(CommentsTextBox.Text, Integer
            End If

            tempRow.EndEdit()

        End Sub

        ''' <summary>
        ''' Showing error popup to user based on error texts assigned to each column.
        ''' </summary>
        ''' <param name="envelopeRow"></param>
        ''' <remarks></remarks>
        Private Sub ShowErrors(ByVal ccTaskLogsRow As MCAP.CoverageDataSet.CCTaskLogsRow)
            Dim columnCounter As Integer
            Dim errorMessage As System.Text.StringBuilder
            Dim errorCols() As Data.DataColumn


            If ccTaskLogsRow.HasErrors = False Then Exit Sub

            errorMessage = New System.Text.StringBuilder

            MessageBox.Show(errorMessage.ToString(), Application.ProductName, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

            errorMessage = Nothing
            errorCols = Nothing

        End Sub

        Private Sub m_m_tasklogProcessor_ValidatingInputs(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_tasklogProcessor.ValidatingColumnValues

            Me.StatusMessage = "Validating inputs..."

        End Sub

        Private Sub m_m_tasklogProcessor_InvalidInputFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_tasklogProcessor.InvalidColumnValueFound
            Dim tempRow As CoverageDataSet.CCTaskLogsRow


            Me.StatusMessage = String.Empty

            tempRow = CType(e.Data("ValidateRow"), CoverageDataSet.CCTaskLogsRow)

            ShowErrors(tempRow)

            tempRow = Nothing
        End Sub

        Private Sub m_tasklogProcessor_InputsValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_tasklogProcessor.ColumnValuesValidated

            Me.StatusMessage = String.Empty

        End Sub


        Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click
            ClearAllInputs()
            If CreateTaskLogButton.Text = "Update" And Me.FormState = FormStateEnum.Edit Then
                CreateTaskLogButton.Text = "Create"
            ElseIf Me.FormState = FormStateEnum.Edit Then
                CreateTaskLogButton.Text = "Update"
            End If
            Me.FormState = FormStateEnum.Insert
            ClearDataSource()
        End Sub

        ''' <summary>
        ''' Clears all inputs on form.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub ClearAllInputs()

            TimeComboBox.SelectedIndex = 0
            AssignedComboBox.SelectedIndex = -1
            RetailerComboBox.SelectedIndex = -1

            SenderComboBox.SelectedIndex = -1

            MarketComboBox.SelectedIndex = -1
            MediaComboBox.SelectedIndex = -1
            PublicationNameComboBox.SelectedIndex = -1

            NameTextBox.Text = String.Empty
            PhoneNoTextBox.Text = String.Empty
            PersonSpokeToTextBox.Text = String.Empty

            OtherContactCheckBox.Checked = False
            statusComboBox.Text = String.Empty
            urgencyComboBox.Text = String.Empty
            ActionTypeComboBox.Text = String.Empty
            SpecificActionComboBox.Text = String.Empty

            addateTypeInDatePicker.Value = Date.Today
            DueDateTypeInDatePicker.Value = Date.Today
            CommentsTextBox.Text = String.Empty
            findVehicleIdTextBox.Text = String.Empty
            MissingAdIdLabel.Text = ""
            MissingAdCheckBox.Checked = False
            FlashCheckBox.Checked = True
        End Sub

        Private Sub SearchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchButton.Click
            Dim vehicleId As Integer

            If findVehicleIdTextBox.Text.Trim.Length = 0 Then
                MessageBox.Show("Provide Task log Id to load Task Log information.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                findVehicleIdTextBox.Focus()
                Exit Sub

            ElseIf Integer.TryParse(findVehicleIdTextBox.Text, vehicleId) = False Then
                MessageBox.Show("Provide Task Log Id in valid format.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                vehicleId = -1
                findVehicleIdTextBox.Focus()
                findVehicleIdTextBox.SelectAll()
                Exit Sub
            End If

            Me.FormState = FormStateEnum.Edit

            OnFindVehicle(vehicleId, EventInitiatorEnum.LoadButton)

            If Processor.Data.CCTaskLogs.Count > 0 Then
                EditButton.Enabled = True
            End If
            CreateTaskLogButton.Text = "Update"
            If NameTextBox.Text <> "" Or PhoneNoTextBox.Text <> "" Or PersonSpokeToTextBox.Text <> "" Then
                OtherContactCheckBox.Checked = True
            Else
                OtherContactCheckBox.Checked = False
            End If
        End Sub

        Protected Sub OnFindVehicle(ByVal vehicleId As Integer, ByVal eventInitiator As EventInitiatorEnum)

            'Me.FormState = FormStateEnum.View

            ClearAllInputs()
            RemoveAllErrorProviders()
            ShowHideControls(Me.FormState)
            'EnableDisableControls(Me.FormState)

            Processor.LoadVehicle(vehicleId, FORM_NAME)

        End Sub


        Private Sub m_Processor_VehicleLoaded(ByVal taskLogsRow As CoverageDataSet.CCTaskLogsRow) Handles m_tasklogProcessor.TaskLogIdLoaded
            Dim isFamilyRequired As Boolean

            ClearAllInputs()
            RemoveAllErrorProviders()

            taskLogsRow = Processor.Data.CCTaskLogs(0)
            LoadPageData()
            ShowVehicleInformation(taskLogsRow)


        End Sub

        Private Sub m_Processor_VehicleNotFound(ByVal vehicleId As Integer) Handles m_tasklogProcessor.TaskLogIdNotFound

            Me.StatusMessage = String.Empty

            ' Me.FormState = FormStateEnum.View

            ClearAllInputs()
            RemoveAllErrorProviders()
            ShowHideControls(Me.FormState)
            '  EnableDisableControls(Me.FormState)
            MessageBox.Show("Task Log Id " & CType(vehicleId, String) & " not found.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Sub

        Public Sub ShowVehicleInformation(ByVal taskLogRowId As Integer)
            Dim createDt As DateTime
            Dim _taskLogRow As CoverageDataSet.CCTaskLogsRow
            Dim i As Integer

            Dim taskLogAdapter As CoverageDataSetTableAdapters.CCTaskLogsTableAdapter
            taskLogAdapter = New CoverageDataSetTableAdapters.CCTaskLogsTableAdapter
            taskLogAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Processor.FillByTaskLogId(taskLogRowId)
            'taskLogsRow = Processor.Data.CCTaskLogs(0)
            'ShowVehicleInformation(

            If Processor.Data.CCTaskLogs.Count > 0 Then i = 0 'CoverageDataSet.CCTaskLogsRow.StatusReportDataSet.PageCrop.Rows.Clear()
            'pageAdapter.Fill(Me.StatusReportDataSet.Page, taskLogRowId)
            'pagecropAdapter.Fill(Me.StatusReportDataSet.PageCrop, taskLogRowId)
            'If Me.StatusReportDataSet.vwVehicleStatusReport.Count > 0 Then
            'With Processor.Data.CCTaskLogs(0)
            '    'With Me.StatusReportDataSet.vwVehicleStatusReport(0)
            '    If .IsAssignedNull() = False Then
            '        AssignedComboBox.SelectedValue = .Assigned.ToString() '(.EnvelopeId)
            '    End If
            '    If .Is_DateNull() = False Then
            '        'Start()
            '    End If
            '    If .IsTimeNull() Then
            '        TimeComboBox.SelectedValue = .Time
            '    Else
            '        TimeComboBox.SelectedValue = .Time
            '    End If
            'If .IsIndexDtNull() OrElse .IsIndexedByNull() Then
            '    indexedOnValueLabel.Text = String.Empty
            'Else
            '    indexedOnValueLabel.Text = .IndexDt.ToString("MM/dd/yyyy HH:mm:ss.fff") + " by " + .IndexedBy
            'End If
            'If .IsScanDtNull() OrElse .IsScannedByNull() Then
            '    scannedOnValueLabel.Text = String.Empty
            'Else
            '    scannedOnValueLabel.Text = .ScanDt.ToString("MM/dd/yyyy HH:mm:ss.fff") + " by " + .ScannedBy
            'End If
            'If .IsQCDtNull() OrElse .IsQCedByNull() Then
            '    qcedOnValueLabel.Text = String.Empty
            'Else
            '    qcedOnValueLabel.Text = .QCDt.ToString("MM/dd/yyyy HH:mm:ss.fff") + " by " + .QCedBy
            'End If
            'If .IsSPReviewStatusIdNull() = False AndAlso .SPReviewStatusId = 67 Then
            '    With spStatusValueLabel
            '        .Font = New System.Drawing.Font(.Font, FontStyle.Bold)
            '        .ForeColor = Color.Red
            '    End With
            'Else
            '    With spStatusValueLabel
            '        .Font = New System.Drawing.Font(.Font, FontStyle.Regular)
            '        .ForeColor = System.Drawing.SystemColors.WindowText
            '    End With
            'End If
            'End With
            'vehicleAdapter.Dispose()
            'pageAdapter.Dispose()
            'pagecropAdapter.Dispose()
            'vehicleAdapter = Nothing
            'pageAdapter = Nothing
            'pagecropAdapter = Nothing

            'pagesDataGridView.DataSource = Me.StatusReportDataSet.Page
            'pagecropDataGridView.DataSource = Me.StatusReportDataSet.PageCrop
            'pagesDataGridView.DataSource = Me.StatusReportDataSet.Page

            'ShowFlyerIdForVehicle(taskLogRowId)
            Me.StatusMessage = "Loading page images as thumbnail. This may take some time. Please wait..."
            'LoadPageImagesInDataGridView(taskLogRowId, createDt)
            Me.StatusMessage = "Loading cropped page images as thumbnail. This may take some time. Please wait..."
            'LoadPageCropImagesInDataGridView(taskLogRowId, createDt)
            Me.StatusMessage = String.Empty

        End Sub

        Private Sub ShowVehicleInformation(ByVal taskLogRow As CoverageDataSet.CCTaskLogsRow)

            TaskLogId = taskLogRow.CCTaskLogsId

            If taskLogRow.Is_DateNull() Then
                currentdateTypeInDatePicker.Clear()

            Else
                currentdateTypeInDatePicker.Text = taskLogRow._Date.ToString("MM/dd/yy")
            End If
            If taskLogRow.IsTimeNull() Then
                TimeComboBox.SelectedValue = DBNull.Value
            Else
                TimeComboBox.SelectedItem = taskLogRow.Time
            End If

            DueDateTypeInDatePicker.Text = "" 'DBNull.Value 'Required to load publications & retailers.
            If taskLogRow.IsDueDateNull() Then
                DueDateTypeInDatePicker.Text = "" 'DBNull.Value
            Else
                DueDateTypeInDatePicker.Text = taskLogRow.DueDate.ToString("MM/dd/yy")
            End If

            If taskLogRow.IsAdDateNull() Then
                addateTypeInDatePicker.Clear()
            Else
                addateTypeInDatePicker.Text = taskLogRow.AdDate.ToString("MM/dd/yy")
            End If


            MediaComboBox.SelectedValue = DBNull.Value 'Required to load publications & retailers.
            If taskLogRow.IsMediaIdNull() Then
                MediaComboBox.SelectedValue = DBNull.Value
            Else
                MediaComboBox.SelectedValue = taskLogRow.MediaId
            End If

            MarketComboBox.SelectedValue = DBNull.Value 'Required to load publications & retailers.
            If taskLogRow.IsMarketIdNull() Then
                MarketComboBox.SelectedValue = DBNull.Value
            Else
                MarketComboBox.SelectedValue = taskLogRow.MarketId
            End If


            RetailerComboBox.SelectedValue = DBNull.Value 'Required to load publications & retailers.
            If taskLogRow.IsRetailerIdNull() Then
                RetailerComboBox.SelectedValue = DBNull.Value
            Else
                RetailerComboBox.SelectedValue = taskLogRow.RetailerId
            End If


            SenderComboBox.SelectedValue = DBNull.Value 'Required to load publications & retailers.
            If taskLogRow.IsSenderIdNull() Then
                SenderComboBox.SelectedValue = DBNull.Value
            Else
                SenderComboBox.SelectedValue = taskLogRow.SenderId
            End If

            'If Me.IsNAPublicationsOnly Then
            '    Processor.LoadNAPublicationIndex()
            'Else
            '    Processor.LoadPublication(vehicleRow.MktId)
            'End If

            PublicationNameComboBox.SelectedValue = DBNull.Value 'Required to load publications & retailers.
            If taskLogRow.IsPublicationIdNull() Then
                PublicationNameComboBox.SelectedValue = DBNull.Value
            Else
                PublicationNameComboBox.SelectedValue = taskLogRow.PublicationId
            End If

            'If missingRow.IsPublicationIdNull() Then
            '    PublicationComboBox.SelectedValue = DBNull.Value
            'Else
            '    PublicationComboBox.SelectedValue = taskLogRow.PublicationId
            'End If

            statusComboBox.SelectedValue = DBNull.Value
            If taskLogRow.IsStatusNull() Then
                statusComboBox.SelectedIndex = -1
            Else
                statusComboBox.SelectedValue = taskLogRow.Status
            End If

            urgencyComboBox.SelectedValue = DBNull.Value
            If taskLogRow.IsUrgencyNull() Then
                urgencyComboBox.SelectedIndex = -1
            Else
                urgencyComboBox.SelectedValue = taskLogRow.Urgency
            End If

            ActionTypeComboBox.SelectedValue = DBNull.Value
            If taskLogRow.IsActionTypeNull() Then
                ActionTypeComboBox.SelectedIndex = -1
            Else
                ActionTypeComboBox.SelectedValue = taskLogRow.ActionType
            End If

            SpecificActionComboBox.SelectedValue = DBNull.Value
            If taskLogRow.IsSpecificActionNull() Then
                SpecificActionComboBox.SelectedIndex = -1
            Else
                SpecificActionComboBox.SelectedValue = taskLogRow.SpecificAction
            End If

            OtherContactCheckBox.Checked = False
            If taskLogRow.IsOtherContactNameNull() Then
                OtherContactCheckBox.Checked = False
            Else
                If taskLogRow.OtherContactName > 0 Then
                    OtherContactCheckBox.Checked = True
                Else
                    OtherContactCheckBox.Checked = False
                End If
            End If

            MissingAdCheckBox.Checked = False
            If taskLogRow.IsMissingAdNull() Then
                MissingAdCheckBox.Checked = False
            Else
                If taskLogRow.MissingAd > 0 Then
                    MissingAdCheckBox.Checked = True
                Else
                    MissingAdCheckBox.Checked = False
                End If
            End If

            If taskLogRow.IsCommentsNull() Then
                CommentsTextBox.Text = ""
            Else
                CommentsTextBox.Text = taskLogRow.Comments.ToString()
            End If

            If taskLogRow.IsPersonNameNull() Then
                NameTextBox.Text = ""
            Else
                NameTextBox.Text = taskLogRow.PersonName.ToString()
            End If

            If taskLogRow.IsPhoneNoCalledNull() Then
                PhoneNoTextBox.Text = ""
            Else
                PhoneNoTextBox.Text = taskLogRow.PhoneNoCalled.ToString()
            End If

            If taskLogRow.IsPersonSpokeWithNull() Then
                PersonSpokeToTextBox.Text = ""
            Else
                PersonSpokeToTextBox.Text = taskLogRow.PersonSpokeWith.ToString()
            End If

            If taskLogRow.IsUserIdNull() Then
                CreatedByLabel.Text = String.Empty
            Else
                CreatedByLabel.Text = Processor.getUserName(taskLogRow.UserId).ToString()
            End If

            AssignedComboBox.SelectedValue = DBNull.Value 'Required to load publications & retailers.
            If taskLogRow.IsAssignedNull() Then
                AssignedComboBox.SelectedValue = DBNull.Value
            Else
                AssignedComboBox.SelectedValue = taskLogRow.Assigned
            End If


            MissingAdIdLabel.Text = taskLogRow.CCTaskLogsId.ToString()
            ' Me.FormState = FormStateEnum.View
            pageLoadedComplete = True
            'enableDisableFormComponents(FormStateEnum.View)


        End Sub


        Private Sub m_Processor_LoadingMarkets() Handles m_tasklogProcessor.LoadingMarkets

            Me.StatusMessage = "Loading Markets..."

        End Sub

        Private Sub m_Processor_MarketsLoaded() Handles m_tasklogProcessor.MarketsLoaded

            Me.StatusMessage = String.Empty

        End Sub


        Private Sub m_Processor_LoadingRetailers() Handles m_tasklogProcessor.LoadingRetailers

            Me.StatusMessage = "Loading Retailers..."

        End Sub

        Private Sub m_Processor_RetailersLoaded() Handles m_tasklogProcessor.RetailersLoaded

            Me.StatusMessage = String.Empty

        End Sub


        Private Sub m_Processor_LoadingSenders() Handles m_tasklogProcessor.LoadingSenders

            Me.StatusMessage = "Loading Senders..."

        End Sub

        Private Sub m_Processor_SendersLoaded() Handles m_tasklogProcessor.SendersLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

            Dim statusForm As UI.Controls.StatusMessageForm
            Dim isSuccessful As Boolean
            Me.StatusMessage = "Preparing to additional sender information"
            Dim senderId As Integer
            Dim viewFamily As UI.FamilyViewForm

            If SenderComboBox.SelectedValue Is Nothing _
              OrElse Integer.TryParse(SenderComboBox.SelectedValue.ToString(), senderId) = False _
            Then
                MessageBox.Show("Please select a valid senderId." _
                                       , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            If Not filterHelp Is Nothing Then
                If filterHelp.Visible = False Then
                    filterHelp = Nothing
                End If
            End If

            'If not open, then create the object and set to open
            If filterHelp Is Nothing Then
                filterHelp = New CCTasksLogSenderDetailsForm()
            End If

            filterHelp.Initialize(senderId)

            'Make sure it's visible
            If filterHelp.Visible = False Then
                filterHelp.Show()
            Else
                filterHelp.Refresh()
            End If

        End Sub

        Private Sub enableDisableFormComponents(ByVal formStatus As FormStateEnum)
            Dim lastSavedUser As Integer
            Dim lastSavedDate As Date

            Select Case formStatus
                Case FormStateEnum.View
                    currentdateTypeInDatePicker.Enabled = False
                    DueDateTypeInDatePicker.Enabled = False
                    TimeComboBox.Enabled = False
                    AssignedComboBox.Enabled = False
                    RetailerComboBox.Enabled = False
                    SenderComboBox.Enabled = False
                    MarketComboBox.Enabled = False
                    MediaComboBox.Enabled = False
                    PublicationNameComboBox.Enabled = False
                    NameTextBox.Enabled = False
                    PhoneNoTextBox.Enabled = False
                    PersonSpokeToTextBox.Enabled = False
                    OtherContactCheckBox.Enabled = False
                    statusComboBox.Enabled = False
                    urgencyComboBox.Enabled = False
                    ActionTypeComboBox.Enabled = False
                    SpecificActionComboBox.Enabled = False
                    addateTypeInDatePicker.Enabled = False
                    CommentsTextBox.Enabled = False
                    LastSavedLabel.Text = ""
                    CreateTaskLogButton.Text = "Create"

                Case FormStateEnum.Insert
                    currentdateTypeInDatePicker.Enabled = True
                    DueDateTypeInDatePicker.Enabled = True
                    TimeComboBox.Enabled = True
                    AssignedComboBox.Enabled = True
                    RetailerComboBox.Enabled = True
                    SenderComboBox.Enabled = True
                    MarketComboBox.Enabled = True
                    MediaComboBox.Enabled = True
                    PublicationNameComboBox.Enabled = True
                    NameTextBox.Enabled = True
                    PhoneNoTextBox.Enabled = True
                    PersonSpokeToTextBox.Enabled = True
                    OtherContactCheckBox.Enabled = True
                    statusComboBox.Enabled = True
                    urgencyComboBox.Enabled = True
                    ActionTypeComboBox.Enabled = True
                    SpecificActionComboBox.Enabled = True
                    addateTypeInDatePicker.Enabled = True
                    CommentsTextBox.Enabled = True
                    LastSavedLabel.Text = ""
                    CreateTaskLogButton.Text = "Create"

                Case FormStateEnum.Edit
                    currentdateTypeInDatePicker.Enabled = True
                    DueDateTypeInDatePicker.Enabled = True
                    TimeComboBox.Enabled = True
                    AssignedComboBox.Enabled = True
                    RetailerComboBox.Enabled = True
                    SenderComboBox.Enabled = True
                    MarketComboBox.Enabled = True
                    MediaComboBox.Enabled = True
                    PublicationNameComboBox.Enabled = True
                    NameTextBox.Enabled = True
                    PhoneNoTextBox.Enabled = True
                    PersonSpokeToTextBox.Enabled = True
                    OtherContactCheckBox.Enabled = True
                    statusComboBox.Enabled = True
                    urgencyComboBox.Enabled = True
                    ActionTypeComboBox.Enabled = True
                    SpecificActionComboBox.Enabled = True
                    addateTypeInDatePicker.Enabled = True
                    CommentsTextBox.Enabled = True


                    CreateTaskLogButton.Text = "Save"

                    LastSavedLabel.Enabled = True
                    lastSavedUser = CInt(Processor.getSavedUser(TaskLogId))
                    lastSavedDate = Processor.getSavedDate(TaskLogId)

                    If lastSavedUser > 0 Then
                        LastSavedLabel.Text = "Last Saved by " + Processor.getUserName(lastSavedUser) + " on " + CStr(lastSavedDate)
                    End If



            End Select

        End Sub

        Private Sub MarketComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MarketComboBox.KeyUp

            'If e.KeyCode = Keys.Delete Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
            '    'senderFilterButton.PerformClick()
            '    Processor.LoadMedia()
            '    MediaComboBox.SelectedIndex = -1
            '    Processor.LoadMarket()
            '    MarketComboBox.SelectedIndex = -1
            '    Processor.LoadRetailer()
            '    RetailerComboBox.SelectedIndex = -1
            'End If

        End Sub

        Private Sub retailerComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RetailerComboBox.KeyUp

            'If e.KeyCode = Keys.Delete Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
            '    'senderFilterButton.PerformClick()
            '    Processor.LoadMedia()
            '    MediaComboBox.SelectedIndex = -1
            '    Processor.LoadMarket()
            '    MarketComboBox.SelectedIndex = -1
            '    Processor.LoadRetailer()
            '    RetailerComboBox.SelectedIndex = -1
            'End If

        End Sub

        Private Sub MediaComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MediaComboBox.KeyUp

            'If e.KeyCode = Keys.Delete Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
            '    'senderFilterButton.PerformClick()
            '    Processor.LoadMedia()
            '    MediaComboBox.SelectedIndex = -1
            '    Processor.LoadMarket()
            '    MarketComboBox.SelectedIndex = -1
            '    Processor.LoadRetailer()
            '    RetailerComboBox.SelectedIndex = -1

            'End If

        End Sub

        Private Sub senderComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SenderComboBox.KeyUp

            'If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
            '    'senderFilterButton.PerformClick()
            '    Processor.LoadSender()
            '    SenderComboBox.SelectedIndex = -1
            'End If

        End Sub

        Private Sub PublicationComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PublicationNameComboBox.KeyUp

            'If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
            '    'senderFilterButton.PerformClick()
            '    Processor.LoadPublication()
            '    PublicationNameComboBox.SelectedIndex = -1
            'End If

        End Sub

        Private Sub StatusComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles statusComboBox.KeyUp

            If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                Processor.LoadCCStatus("CCStatus")
                statusComboBox.SelectedIndex = -1
            End If

        End Sub

        Private Sub UrgencyComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles urgencyComboBox.KeyUp

            If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                Processor.LoadCCUrgency("CCUrgency")
                urgencyComboBox.SelectedIndex = -1
            End If

        End Sub

        Private Sub ActionTypeComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ActionTypeComboBox.KeyUp

            If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                Processor.LoadCCActionType("CCActionType")
                ActionTypeComboBox.SelectedIndex = -1
            End If

        End Sub

        Private Sub SpecificActionComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SpecificActionComboBox.KeyUp

            If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                Processor.LoadCCSpecificAction("CCSpecificAction")
                SpecificActionComboBox.SelectedIndex = -1
            End If

        End Sub


        Private Sub EditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditButton.Click
            Me.FormState = FormStateEnum.Edit
            enableDisableFormComponents(FormStateEnum.Edit)
        End Sub

        Private Sub statusComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles statusComboBox.SelectedIndexChanged
            'Private Sub ActionTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionTypeComboBox.SelectedIndexChanged
            'Dim status As String

            'If statusComboBox.SelectedText Is Nothing Then
            '    status = String.Empty
            'Else
            '    status = statusComboBox.SelectedValue.ToString()
            'End If
            'OnStatusChanged(status)
        End Sub

        Protected Sub OnStatusChanged(ByVal status As String)
            'Processor.LoadUrgency(status)
            'End Sub
        End Sub

        Protected Sub SaveMessageBox(ByVal RecordId As Integer)

            Dim statusForm As UI.Controls.StatusMessageForm
            Dim isSuccessful As Boolean
            Me.StatusMessage = "Saving Record.."
            Dim viewFamily As UI.FamilyViewForm


            If Not saveHelp Is Nothing Then
                If saveHelp.Visible = False Then
                    saveHelp = Nothing
                End If
            End If

            'If not open, then create the object and set to open
            If saveHelp Is Nothing Then
                saveHelp = New CCFormsSubmitMessageBox()
            End If

            saveHelp.Initialize(RecordId)

            'Make sure it's visible
            If saveHelp.Visible = False Then
                saveHelp.Show()
            Else
                saveHelp.Refresh()
            End If
        End Sub

        Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
            If MissingAdIdLabel.Text <> "" Then
                If Processor.DeleteTaskLog(CInt(MissingAdIdLabel.Text)) = True Then
                    ClearAllInputs()
                    Me.FormState = FormStateEnum.Insert
                    CreateTaskLogButton.Text = "Create"
                End If
            Else
                MsgBox("No Record to Delete, Please search a record first.", MsgBoxStyle.Exclamation, "MCAP")
            End If
        End Sub

        Private Sub SenderComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SenderComboBox.SelectedValueChanged
            'If Processor.Data.Mkt.Count > 0 Then Processor.Data.Mkt.Clear()
            'If Processor.Data.Publication.Count > 0 Then Processor.Data.Publication.Clear()
            'If Processor.Data.Media.Count > 0 Then Processor.Data.Media.Clear()
            'If CInt(SenderComboBox.SelectedValue) > 0 Then
            '    Processor.LoadSenderMktAssoc(CInt(SenderComboBox.SelectedValue))
            '    Processor.LoadSenderPublication(CInt(SenderComboBox.SelectedValue))
            '    Processor.LoadMediaSenderExpectation(CInt(SenderComboBox.SelectedValue))
            'End If
            'MarketComboBox.SelectedIndex = -1
            'MediaComboBox.SelectedIndex = -1
            'PublicationNameComboBox.SelectedIndex = -1
        End Sub

        Private Sub MarketComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarketComboBox.SelectedValueChanged
            'If Processor.Data.Ret.Count > 0 Then Processor.Data.Ret.Clear()
            'If CInt(MarketComboBox.SelectedValue) > 0 Then
            '    Processor.LoadRetailerByExpectation(CInt(MarketComboBox.SelectedValue), CInt(MediaComboBox.SelectedValue))
            'End If
            'RetailerComboBox.SelectedIndex = -1
        End Sub

        Private Sub SenderComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SenderComboBox.SelectedIndexChanged
            If SenderComboBox.SelectedIndex <> -1 Then RemoveErrorProvider(SenderComboBox)
        End Sub

        Private Sub MediaComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediaComboBox.SelectedIndexChanged
            If MediaComboBox.SelectedIndex <> -1 Then RemoveErrorProvider(MediaComboBox)
        End Sub
    End Class


End Namespace