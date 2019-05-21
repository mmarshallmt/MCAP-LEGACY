Namespace UI

    Public Class MissingAdLogForm
        Implements IForm

        ''' <summary>
        ''' This constant is used to assigning value to FormName column.
        ''' </summary>
        ''' <remarks></remarks>
        Private Const FORM_NAME As String = "Missing Ad Log Form"
        Private WithEvents m_missingadlogProcessor As Processors.MissingAdLog
        Private m_isFiltered As Boolean
        Private pageLoadedComplete As Boolean
        Private filterHelp As CCTasksLogSenderDetailsForm
        Private mktClicked As Boolean
        Private sndrClicked As Boolean
        Private saveHelp As CCFormsSubmitMessageBox
        Private MissingAdId As Integer

        Protected Enum EventInitiatorEnum
            Unknown = 0
            LoadButton = 1
            VehiclePageCropButton = 2
            RefreshButton = 3
        End Enum



        Private ReadOnly Property Processor() As Processors.MissingAdLog
            Get
                Return m_missingadlogProcessor
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
            m_missingadlogProcessor = New Processors.MissingAdLog()

            Processor.Initialize()
            ''Processor.LoadDataSet()
            LoadPageData()

            RaiseEvent FormInitialized()


            Me.ResumeLayout()

        End Sub

        Private Sub LoadPageData()

            Dim HourIntervalNow As Integer
            Dim MinIntervalNow As Integer
            Dim ByHourIntervalNow As String
            Dim ByHourIntervalArray(24) As String
            Dim ByAMPM As String
            Dim dateformat As String

            ByHourIntervalArray = New String() {"12:00AM", "12:30AM", "1:00AM", "1:30AM", "2:00AM", "2:30AM", "3:00AM", "3:30AM", "4:00AM", "4:30AM", "5:00AM", "5:30AM", "6:00AM", "6:30AM", "7:00AM", _
                                "7:30AM", "8:00AM", "8:30AM", "9:00AM", "9:30AM", "10:00AM", "10:30AM", "11:00AM", "11:30AM", "12:00PM", "12:30PM", "1:00PM", "1:30PM", "2:00PM", "2:30PM", "3:00PM", "3:30PM", "4:00PM", "4:30PM", "5:00PM", "5:30PM", "6:00PM", "6:30PM", "7:00PM", _
                                "7:30PM", "8:00PM", "8:30PM", "9:00PM", "9:30PM", "10:00PM", "10:30PM", "11:00PM", "11:30PM"}

            dateformat = "MMM ddd d HH:mm yyyy"
            pageLoadedComplete = False

            Processor.LoadAssignedUsers(User.LocationId)
            AssignedComboBox.DisplayMember = "FullName"
            AssignedComboBox.ValueMember = "UserId"
            AssignedComboBox.DataSource = Processor.Data.User
            'AssignedComboBox.DropDownStyle = ComboBoxStyle.DropDownList


            TimeComboBox.DisplayMember = "intervalName"
            TimeComboBox.ValueMember = "intervalId"
            TimeComboBox.DataSource = ByHourIntervalArray 'Processor.Data.ByHourInterval
            HourIntervalNow = DateTime.Now.Hour
            MinIntervalNow = DateTime.Now.Minute

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
            If (MinIntervalNow < 10) Then
                ByHourIntervalNow = HourIntervalNow.ToString() + ":0" + MinIntervalNow.ToString()
            End If

            TimeComboBox.SelectedIndex = getArrayIndex(ByHourIntervalArray, ByHourIntervalNow + ByAMPM)
            If TimeComboBox.SelectedValue Is Nothing Then
                TimeComboBox.SelectedIndex = 23
            End If
            TimeComboBox.DropDownStyle = ComboBoxStyle.DropDownList

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
            PublicationComboBox.DisplayMember = "Descrip"
            PublicationComboBox.ValueMember = "PublicationId"
            PublicationComboBox.DataSource = Processor.Data.Publication
            PublicationComboBox.SelectedIndex = -1
            PublicationComboBox.DropDownStyle = ComboBoxStyle.DropDownList


            Processor.LoadCCStatus("CCStatus")
            statusComboBox.ValueMember = "codeid"
            statusComboBox.DisplayMember = "codedescrip"
            statusComboBox.DataSource = Processor.Data.CCStatus
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            Processor.LoadCCUrgency("CCUrgency")
            UrgencyComboBox.ValueMember = "codeid"
            UrgencyComboBox.DisplayMember = "codedescrip"
            UrgencyComboBox.DataSource = Processor.Data.CCUrgency
            UrgencyComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            Processor.LoadRootCause("CCRootCauses")
            RootCauseComboBox.DisplayMember = "codedescrip"
            RootCauseComboBox.ValueMember = "codeid"
            RootCauseComboBox.DataSource = Processor.Data.RootCause
            RootCauseComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            Processor.LoadLtResolution("CCLtResolution")
            StResolutionComboBox.DisplayMember = "codedescrip"
            StResolutionComboBox.ValueMember = "codeid"
            StResolutionComboBox.DataSource = Processor.Data.LtResolution
            StResolutionComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            Processor.LoadRtResolution("CCRtResolution")
            LtResolutionComboBox.DisplayMember = "codedescrip"
            LtResolutionComboBox.ValueMember = "codeid"
            LtResolutionComboBox.DataSource = Processor.Data.RtResolution
            LtResolutionComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            editTableGroupBox.Text = String.Empty
            startdateTypeInDatePicker.Value = DateTime.Today
            DueDateTypeInDatePicker.Value = DateTime.Today
            DateResolvedTypeInDatePicker.Value = DateTime.Today
            AdDateTypeInDatePicker.Value = DateTime.Today

            frequencyLabel.Text = String.Empty
            priorityLabel.Text = String.Empty
            CommentsLabel.Text = String.Empty

            pageLoadedComplete = True
            mktClicked = False
            sndrClicked = False

            If Not filterHelp Is Nothing Then
                If filterHelp.Visible Then
                    MoreDetailsButton_Click(Nothing, Nothing)
                End If
            End If

            Comments1TextBox.Text = String.Empty
            Comments2TextBox.Text = String.Empty
            Comments3TextBox.Text = String.Empty

            MissingAdIdLabel.Text = String.Empty
            CreatedByLabel.Text = User.FName.ToString() + " " + User.LName.ToString()


            enableDisableFormComponents(FormStateEnum.Insert)

        End Sub

#End Region

        Private Sub closeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles closeButton.Click
            Me.Close()
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

        Private Sub getSenderDetails(ByVal senderId As Integer, ByVal mediaId As Integer, ByVal marketId As Integer, ByVal retailerId As Integer)
            frequencyLabel.Text = Processor.GetSenderFrequency(senderId, mediaId, marketId, retailerId)
            priorityLabel.Text = Processor.GetSenderPriority(senderId, mediaId, marketId, retailerId)
            CommentsLabel.Text = Processor.GetSenderCommentsText(senderId, mediaId, marketId, retailerId)
        End Sub


        Private Sub SenderComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SenderComboBox.SelectedIndexChanged

            'Dim senderId As Integer
            'Dim mediaId As Integer
            'Dim marketId As Integer
            'Dim retailerId As Integer

            'If SenderComboBox.SelectedValue Is Nothing _
            '  OrElse Integer.TryParse(SenderComboBox.SelectedValue.ToString(), senderId) = False _
            'Then
            '    senderId = -1
            'End If

            'If MediaComboBox.SelectedValue Is Nothing _
            '  OrElse Integer.TryParse(MediaComboBox.SelectedValue.ToString(), mediaId) = False _
            'Then
            '    mediaId = -1
            'End If

            'If MarketComboBox.SelectedValue Is Nothing _
            '  OrElse Integer.TryParse(MarketComboBox.SelectedValue.ToString(), marketId) = False _
            'Then
            '    marketId = -1
            'End If

            'If RetailerComboBox.SelectedValue Is Nothing _
            '  OrElse Integer.TryParse(RetailerComboBox.SelectedValue.ToString(), retailerId) = False _
            'Then
            '    retailerId = -1
            'End If

            'If senderId > 0 Then
            '    getSenderDetails(senderId, mediaId, marketId, retailerId)
            'End If

        End Sub

        Private Sub MarketComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarketComboBox.SelectedIndexChanged

            'Dim tempcount As Integer
            'Dim retailerId As Integer

            'Dim mktId, mediaId As Integer
            'Dim naPubOnly As Boolean = False
            'Dim mediaAdapter As CoverageTableAdapters.MediaTableAdapter
            'mediaAdapter = New CoverageTableAdapters.MediaTableAdapter

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

            'Dim mediaAdapter As EnvelopeContentDataSetTableAdapters.MediaTableAdapter
            'mediaAdapter = New EnvelopeContentDataSetTableAdapters.MediaTableAdapter

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
            'If Me.FormState <> FormStateEnum.View Then
            '    Dim showFlashCheckBox As Boolean
            '    Dim mediaId, marketId As Integer

            '    If MediaComboBox.SelectedValue Is Nothing OrElse MediaComboBox.SelectedValue Is DBNull.Value Then
            '        mediaId = -1
            '    ElseIf Integer.TryParse(MediaComboBox.SelectedValue.ToString(), mediaId) = False Then
            '        mediaId = -1
            '    End If

            '    If MarketComboBox.SelectedValue Is Nothing OrElse MarketComboBox.SelectedValue Is DBNull.Value Then
            '        marketId = -1
            '    ElseIf Integer.TryParse(MarketComboBox.SelectedValue.ToString(), marketId) = False Then
            '        marketId = -1
            '    End If

            '    If pageLoadedComplete Then

            '        If mediaId < 0 Then
            '            Processor.LoadMedia(retailerId)
            '            MediaComboBox.SelectedIndex = -1
            '            RetailerComboBox.SelectedValue = retailerId
            '            'Else
            '            '    Processor.LoadMedia(retailerId)
            '            '    MediaComboBox.SelectedIndex = -1

            '        End If

            '        If marketId < 0 Then
            '            Processor.LoadMarket(retailerId)
            '            MarketComboBox.SelectedIndex = -1
            '            'Else
            '            '    Processor.LoadMarket(retailerId)
            '            '    MarketComboBox.SelectedIndex = -1
            '            '    RetailerComboBox.SelectedValue = retailerId

            '        End If
            '        'MarketComboBox_SelectedIndexChanged(Nothing, Nothing)
            '        Processor.LoadPublication()
            '        Processor.LoadSender()
            '        PublicationComboBox.SelectedIndex = -1
            '        SenderComboBox.SelectedIndex = -1

            '    End If
            'End If

        End Sub


        Protected Sub OnMediaChanged(ByVal mediaId As Integer, ByVal marketId As Integer, ByVal naPubOnly As Boolean, ByVal IsFSI As Boolean)
            'If Me.FormState <> FormStateEnum.View Then
            '    If MediaComboBox.Text.ToUpper() = "CATALOG" Then
            '        ' load markets
            '        If marketId < 0 Then
            '            Processor.LoadMarketsForCatalog(mediaId)
            '            If MarketComboBox.Items.Count = 1 Then
            '                MarketComboBox.SelectedIndex = -1
            '            ElseIf MarketComboBox.Items.Count > 1 Then
            '                MarketComboBox.SelectedIndex = -1
            '            End If
            '        End If
            '    Else
            '        ' load markets
            '        If marketId < 0 Then
            '            Processor.LoadMarketByMedia(mediaId)
            '            If MarketComboBox.Items.Count = 1 Then
            '                'MarketComboBox.SelectedIndex = 0
            '            Else
            '                'MarketComboBox.Text = String.Empty
            '                'MarketComboBox.SelectedValue = DBNull.Value
            '                'MarketComboBox.SelectedIndex = -1
            '            End If
            '        End If

            '    End If

            '    If MarketComboBox.SelectedValue IsNot Nothing _
            '      AndAlso Integer.TryParse(MarketComboBox.SelectedValue.ToString(), marketId) = False _
            '    Then
            '        marketId = -1
            '    End If

            '    OnMarketChanged(marketId, mediaId, naPubOnly)
            '    Processor.LoadPublication()
            '    Processor.LoadSender()
            '    PublicationComboBox.SelectedIndex = -1
            '    SenderComboBox.SelectedIndex = -1

            'End If

        End Sub

        Protected Sub OnMarketChanged(ByVal marketId As Integer, ByVal mediaId As Integer, ByVal naPubOnly As Boolean)

            'If Me.FormState <> FormStateEnum.View Then
            '    Dim retailerId As Integer

            '    If marketId < 0 Then
            '        Exit Sub
            '    End If

            '    If naPubOnly Then
            '        Processor.LoadNAPublicationIndex()
            '    Else
            '        Processor.LoadPublication(marketId)
            '    End If
            '    PublicationComboBox.SelectedIndex = -1

            '    If RetailerComboBox.SelectedValue Is Nothing Then
            '        retailerId = -1

            '        If mediaId < 0 Then
            '            Processor.LoadRetailer(marketId)
            '        Else
            '            Processor.LoadRetailer(mediaId, marketId)
            '        End If
            '    Else
            '        retailerId = CType(RetailerComboBox.SelectedValue, Integer)
            '    End If


            '    If retailerId < 0 Then
            '        RetailerComboBox.SelectedIndex = -1
            '    Else
            '        RetailerComboBox.SelectedValue = retailerId
            '    End If

            '    If pageLoadedComplete Then
            '        If sndrClicked = False Then
            '            Processor.reLoadSender(marketId)
            '            mktClicked = True
            '            SenderComboBox.SelectedIndex = -1
            '        End If
            '    End If

            'End If
        End Sub

        Private Sub publicationComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles PublicationComboBox.SelectedValueChanged
            'Dim publicationId As Integer


            'If publicationComboBox.SelectedValue Is Nothing _
            '  OrElse Integer.TryParse(publicationComboBox.SelectedValue.ToString(), publicationId) = False _
            'Then
            '    publicationId = -1
            'End If

            ''OnPublicationChanged(publicationId)

        End Sub


        Private Sub CreateTaskLogButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateTaskLogButton.Click
            Dim ccMissingAdLogsID As Integer
            Dim tempRow As CoverageDataSet.CCMissingAdLogsRow
            Dim strMessage As String

            If AreInputsValid() = False Then Exit Sub

            If FormState = FormStateEnum.Insert Then
                tempRow = Processor.CreateNew()
            Else
                'ccMissingAdLogsID = CType(MissingAdIdLabel.Text, Integer)
                tempRow = Processor.Data.CCMissingAdLogs(0)
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
                Trace.TraceError("CCMissing Ad.CreateTaskLogButton_Click():Saving CC Task Logs. Message=" + ex.Message, New Object() {"FormState=", Me.FormState.ToString(), "DataRow=", tempRow})
                ShowErrors(tempRow)
            Catch ex As System.Exception
                Trace.TraceError("CCMissing Ad.CreateTaskLogButton_Click():Saving CC Task Logs. Message=" + ex.Message, New Object() {"FormState=", Me.FormState.ToString(), "DataRow=", tempRow})
                If Me.FormState = FormStateEnum.Insert Then
                    MessageBox.Show("CC Missing Ad record not created. Unknown error has occurred while checking-in new CCMissing Ad." + ex.Message _
                          , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Changes not saved. Unknown error has occurred while saving changes." + ex.Message _
                          , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Try

            If CreateTaskLogButton.Text = "Update" And Me.FormState = FormStateEnum.Edit Then
                CreateTaskLogButton.Text = "Create"
            ElseIf Me.FormState = FormStateEnum.Edit Then
                CreateTaskLogButton.Text = "Update"
            End If
            Me.FormState = FormStateEnum.Insert
            ClearDataSource()
            FlashCheckBox.Checked = False
        End Sub

        ''' <summary>
        ''' Showing popup to user after save
        ''' </summary>
        ''' <param name="envelopeRow"></param>
        ''' <remarks></remarks>
        Private Sub ShowSavedDetails(ByVal ccTaskLogsRow As MCAP.CoverageDataSet.CCMissingAdLogsRow)
            Dim columnCounter As Integer
            Dim strMessage As String
            Dim strCols() As Data.DataColumn


            If ccTaskLogsRow.HasErrors = True Then Exit Sub

            If FormState = FormStateEnum.Insert Then
                strMessage = "New Record Created. Record Id: " + Processor.getMissingAdLabelId()
            Else
                'strMessage = "Values saved.  Id: " + Processor.
            End If

            ' SaveMessageBox(CInt(Processor.getMissingAdLabelId()))
            MessageBox.Show(strMessage.ToString(), Application.ProductName, _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            LoadPageData()

            strMessage = Nothing
            strCols = Nothing

        End Sub


        ''' <summary>
        ''' Showing error popup to user based on error texts assigned to each column.
        ''' </summary>
        ''' <param name="envelopeRow"></param>
        ''' <remarks></remarks>
        Private Sub ShowErrors(ByVal ccTaskLogsRow As MCAP.CoverageDataSet.CCMissingAdLogsRow)
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

        ''' <summary>
        ''' Sets column values of supplied row.
        ''' </summary>
        ''' <param name="tempRow"></param>
        ''' <remarks></remarks>
        Private Sub SetColumnValues(ByVal tempRow As CoverageDataSet.CCMissingAdLogsRow)

            Dim saveNow As DateTime = DateTime.Now

            tempRow.BeginEdit()

            tempRow.MissingAdId = CInt(Processor.getMissingAdLabelIdValue())
            tempRow.DateDiscovered = CType(startdateTypeInDatePicker.Value, Date)
            tempRow.Time = CType(TimeComboBox.SelectedValue, String)

            'tempRow.DueDate = CType(DueDateTypeInDatePicker.Value, Date)
            If DueDateTypeInDatePicker.Value Is Nothing Then
                'tempRow.DueDate = CType("", Date)
            Else
                tempRow.DueDate = CType(DueDateTypeInDatePicker.Value, Date)
            End If
            tempRow.Assigned = CType(AssignedComboBox.SelectedValue, Integer)
            'tempRow.DateDiscovered = CType(DateResolvedTypeInDatePicker.Value, Date)
            If DateResolvedTypeInDatePicker.Value Is Nothing Then
                'tempRow.DueDate = CType("", Date)
            Else
                tempRow.DateResolved = CType(DateResolvedTypeInDatePicker.Value, Date)
            End If
            'tempRow.AdDate = CType(AdDateTypeInDatePicker.Value, Date)

            If AdDateTypeInDatePicker.Value Is Nothing Then
                'tempRow.DueDate = CType("", Date)
            Else
                tempRow.AdDate = CType(AdDateTypeInDatePicker.Value, Date)
            End If

            tempRow.MarketId = CType(MarketComboBox.SelectedValue, Integer)
            tempRow.MediaId = CType(MediaComboBox.SelectedValue, Integer)
            tempRow.PublicationId = CType(PublicationComboBox.SelectedValue, Integer)
            tempRow.RetailerId = CType(RetailerComboBox.SelectedValue, Integer)
            tempRow.SenderId = CType(SenderComboBox.SelectedValue, Integer)

            tempRow.Urgency = CType(UrgencyComboBox.SelectedValue, Integer)
            tempRow.Status = CType(statusComboBox.SelectedValue, Integer)

            If (FlashCheckBox.Checked = True) Then
                tempRow.Flash = 1
            Else
                tempRow.Flash = 0
            End If

            'tempRow.UserId = User.UserID
            If Me.FormState = FormStateEnum.Insert Then

                tempRow.UserId = User.UserID

            End If

            tempRow.RootCause = CType(RootCauseComboBox.SelectedValue, Integer)
            tempRow.Comments1 = CType(Comments1TextBox.Text, String)
            tempRow.StResolution = CType(StResolutionComboBox.SelectedValue, Integer)
            tempRow.Comments2 = CType(Comments2TextBox.Text, String)
            tempRow.LtResolution = CType(LtResolutionComboBox.SelectedValue, Integer)
            tempRow.Comments3 = CType(Comments3TextBox.Text, String)

            If Me.FormState = FormStateEnum.Edit Then
                tempRow.LastSavedDate = saveNow 'CType(CommentsTextBox.Text, Date)
                tempRow.LastSavedUser = User.UserID 'CType(CommentsTextBox.Text, Integer)
            End If

            tempRow.EndEdit()

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

            If DueDateTypeInDatePicker.Value.HasValue = True _
                AndAlso startdateTypeInDatePicker.Value.HasValue = True _
            Then
                showMsg = False
                dateDifference = DueDateTypeInDatePicker.Value.Value.Subtract(startdateTypeInDatePicker.Value.Value).Days

                If (dateDifference > 0) Then
                    showMsg = True
                    If showMsg Then
                        dateMsg.MessageText = "Start Date should be less than due Date."
                        If dateMsg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then Return False
                    End If
                End If
            End If
            showMsg = False

            If DateResolvedTypeInDatePicker.Value.HasValue = True _
                            AndAlso AdDateTypeInDatePicker.Value.HasValue = True _
                        Then
                showMsg = False
                dateDifference = AdDateTypeInDatePicker.Value.Value.Subtract(DateResolvedTypeInDatePicker.Value.Value).Days

                If (dateDifference < 0) Then
                    showMsg = True
                    If showMsg Then
                        dateMsg.MessageText = "Date Resolved should be less than Ad Date."
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
                SetErrorProvider(TimeComboBox, "Select time.")
                areAllValid = False
            Else
                RemoveErrorProvider(TimeComboBox)
            End If

            If UrgencyComboBox.SelectedValue Is Nothing _
              OrElse UrgencyComboBox.SelectedIndex < 0 _
              OrElse UrgencyComboBox.Text.Length = 0 _
            Then
                SetErrorProvider(UrgencyComboBox, "Select urgency.")
                areAllValid = False
            Else
                RemoveErrorProvider(UrgencyComboBox)
            End If

            If statusComboBox.SelectedValue Is Nothing _
              OrElse statusComboBox.SelectedIndex < 0 _
              OrElse statusComboBox.Text.Length = 0 _
            Then
                SetErrorProvider(statusComboBox, "Select status.")
                areAllValid = False
            Else
                RemoveErrorProvider(statusComboBox)
            End If

            If AssignedComboBox.SelectedValue Is Nothing _
              OrElse AssignedComboBox.SelectedIndex < 0 _
              OrElse AssignedComboBox.Text.Length = 0 _
            Then
                SetErrorProvider(AssignedComboBox, "Select assigned.")
                areAllValid = False
            Else
                RemoveErrorProvider(AssignedComboBox)
            End If

            If areAllValid Then areAllValid = ValidateBusinessRules()

            Return areAllValid

        End Function

        Private Sub MoreDetailsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoreDetailsButton.Click

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

        Private Sub editTableGroupBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editTableGroupBox.Enter

        End Sub

        Private Sub cancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cancelButton.Click
            If CreateTaskLogButton.Text = "Update" And Me.FormState = FormStateEnum.Edit Then
                CreateTaskLogButton.Text = "Create"
            ElseIf Me.FormState = FormStateEnum.Edit Then
                CreateTaskLogButton.Text = "Update"
            End If
            ClearAllInputs()
            ClearDataSource()
        End Sub

        ''' <summary>
        ''' Clears all inputs on form.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub ClearAllInputs()

            TimeComboBox.SelectedIndex = -1
            AssignedComboBox.SelectedIndex = -1
            RetailerComboBox.SelectedIndex = -1

            SenderComboBox.SelectedIndex = -1

            MarketComboBox.SelectedIndex = -1
            MediaComboBox.SelectedIndex = -1


            statusComboBox.SelectedIndex = -1
            UrgencyComboBox.SelectedIndex = -1

            AdDateTypeInDatePicker.Value = Date.Today
            startdateTypeInDatePicker.Value = Date.Today
            DateResolvedTypeInDatePicker.Value = Date.Today
            AdDateTypeInDatePicker.Value = Date.Today
            DueDateTypeInDatePicker.Value = Date.Today
            Comments1TextBox.Text = String.Empty
            Comments2TextBox.Text = String.Empty
            Comments3TextBox.Text = String.Empty

            RootCauseComboBox.SelectedIndex = -1
            StResolutionComboBox.SelectedIndex = -1
            LtResolutionComboBox.SelectedIndex = -1
            MissingAdIdLabel.Text = ""
            findVehicleIdTextBox.Text = ""
            PublicationComboBox.SelectedIndex = -1
        End Sub

        Private Sub SearchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchButton.Click
            Dim vehicleId As Integer


            If findVehicleIdTextBox.Text.Trim.Length = 0 Then
                MessageBox.Show("Provide Missing Id to load Missing Log information.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                findVehicleIdTextBox.Focus()
                Exit Sub
            ElseIf Integer.TryParse(findVehicleIdTextBox.Text, vehicleId) = False Then
                MessageBox.Show("Provide Missing Id in valid format.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                vehicleId = -1
                findVehicleIdTextBox.Focus()
                findVehicleIdTextBox.SelectAll()
                Exit Sub
            End If

            Me.FormState = FormStateEnum.Edit

            OnFindVehicle(vehicleId, EventInitiatorEnum.LoadButton)

            If Processor.Data.CCMissingAdLogs.Count > 0 Then
                EditButton.Enabled = True
            End If
            If CreateTaskLogButton.Text = "Update" And Me.FormState = FormStateEnum.Edit Then
                CreateTaskLogButton.Text = "Create"
            ElseIf Me.FormState = FormStateEnum.Edit Then
                CreateTaskLogButton.Text = "Update"
            End If
            'Me.FormState = FormStateEnum.Insert
            'enableDisableFormComponents(FormStateEnum.View)

        End Sub

        Protected Sub OnFindVehicle(ByVal vehicleId As Integer, ByVal eventInitiator As EventInitiatorEnum)

            'Me.FormState = FormStateEnum.View

            ClearAllInputs()
            RemoveAllErrorProviders()
            ShowHideControls(Me.FormState)
            'EnableDisableControls(Me.FormState)

            Processor.LoadVehicle(vehicleId, FORM_NAME)

        End Sub


        Private Sub m_Processor_VehicleLoaded(ByVal missingRow As CoverageDataSet.CCMissingAdLogsRow) Handles m_missingadlogProcessor.MissingAdLoaded
            Dim isFamilyRequired As Boolean

            ClearAllInputs()
            RemoveAllErrorProviders()

            missingRow = Processor.Data.CCMissingAdLogs(0)
            LoadPageData()
            ShowVehicleInformation(missingRow)

        End Sub

        Private Sub m_Processor_VehicleNotFound(ByVal vehicleId As Integer) Handles m_missingadlogProcessor.MissingAdNotFound

            Me.StatusMessage = String.Empty

            'Me.FormState = FormStateEnum.View

            ClearAllInputs()
            RemoveAllErrorProviders()
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)
            MessageBox.Show("Missing Ad Id " & CType(vehicleId, String) & " not found.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Sub
        Public Sub ShowVehicleInformation(ByVal missingRowId As Integer)
            Dim createDt As DateTime
            Dim _missingIdRow As CoverageDataSet.CCTaskLogsRow
            Dim i As Integer

            Dim missingIdAdapter As CoverageDataSetTableAdapters.CCMissingAdLogsTableAdapter
            missingIdAdapter = New CoverageDataSetTableAdapters.CCMissingAdLogsTableAdapter
            missingIdAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            Processor.FillByMissingId(missingRowId)
            'taskLogsRow = Processor.Data.CCTaskLogs(0)
            'ShowVehicleInformation(

            If Processor.Data.CCMissingAdLogs.Count > 0 Then i = 0 'CoverageDataSet.CCTaskLogsRow.StatusReportDataSet.PageCrop.Rows.Clear()
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


        Private Sub ShowVehicleInformation(ByVal missingRow As CoverageDataSet.CCMissingAdLogsRow)

            MissingAdIdLabel.Text = (missingRow.MissingAdId + 1).ToString()
            MissingAdId = missingRow.MissingAdId

            startdateTypeInDatePicker.Text = "" 'DBNull.Value 'Required to load publications & retailers.
            If missingRow.IsDateDiscoveredNull() Then
                startdateTypeInDatePicker.Text = "" 'DBNull.Value
            Else
                startdateTypeInDatePicker.Text = missingRow.DateDiscovered.ToString("MM/dd/yy")
            End If

            If missingRow.IsTimeNull() Then
                TimeComboBox.SelectedValue = DBNull.Value
            Else
                TimeComboBox.SelectedItem = missingRow.Time
            End If

            DueDateTypeInDatePicker.Text = "" 'DBNull.Value 'Required to load publications & retailers.
            If missingRow.IsDueDateNull() Then
                DueDateTypeInDatePicker.Text = "" 'DBNull.Value
            Else
                DueDateTypeInDatePicker.Text = missingRow.DueDate.ToString("MM/dd/yy")
            End If

            If missingRow.IsAdDateNull() Then
                AdDateTypeInDatePicker.Clear()
            Else
                AdDateTypeInDatePicker.Text = missingRow.AdDate.ToString("MM/dd/yy")
            End If


            DateResolvedTypeInDatePicker.Text = "" 'DBNull.Value 'Required to load publications & retailers.
            If missingRow.IsAdDateNull() Then
                DateResolvedTypeInDatePicker.Text = "" 'DBNull.Value
            Else
                DateResolvedTypeInDatePicker.Text = missingRow.AdDate.ToString("MM/dd/yy")
            End If

            MediaComboBox.SelectedValue = DBNull.Value 'Required to load publications & retailers.
            If missingRow.IsMediaIdNull() Then
                MediaComboBox.SelectedValue = DBNull.Value
            Else
                MediaComboBox.SelectedValue = missingRow.MediaId
            End If

            RetailerComboBox.SelectedValue = DBNull.Value 'Required to load publications & retailers.
            If missingRow.IsRetailerIdNull() Then
                RetailerComboBox.SelectedValue = DBNull.Value
            Else
                RetailerComboBox.SelectedValue = missingRow.RetailerId
            End If

            MarketComboBox.SelectedValue = DBNull.Value 'Required to load publications & retailers.
            If missingRow.IsMarketIdNull() Then
                MarketComboBox.SelectedValue = DBNull.Value
            Else
                MarketComboBox.SelectedValue = missingRow.MarketId
            End If

            SenderComboBox.SelectedValue = DBNull.Value 'Required to load publications & retailers.
            If missingRow.IsSenderIdNull() Then
                SenderComboBox.SelectedValue = DBNull.Value
            Else
                SenderComboBox.SelectedValue = missingRow.SenderId
            End If

            'If Me.IsNAPublicationsOnly Then
            '    Processor.LoadNAPublicationIndex()
            'Else
            '    Processor.LoadPublication(vehicleRow.MktId)
            'End If

            PublicationComboBox.SelectedValue = DBNull.Value 'Required to load publications & retailers.
            If missingRow.IsPublicationIdNull() Then
                PublicationComboBox.SelectedValue = DBNull.Value
            Else
                PublicationComboBox.SelectedValue = missingRow.PublicationId
            End If

            'If missingRow.IsPublicationIdNull() Then
            '    PublicationComboBox.SelectedValue = DBNull.Value
            'Else
            '    PublicationComboBox.SelectedValue = missingRow.PublicationId
            'End If

            statusComboBox.SelectedValue = DBNull.Value
            If missingRow.IsStatusNull() Then
                statusComboBox.SelectedIndex = -1
            Else
                statusComboBox.SelectedValue = missingRow.Status
            End If

            UrgencyComboBox.SelectedValue = DBNull.Value
            If missingRow.IsUrgencyNull() Then
                UrgencyComboBox.SelectedIndex = -1
            Else
                UrgencyComboBox.SelectedValue = missingRow.Urgency
            End If

            RootCauseComboBox.SelectedValue = DBNull.Value
            If missingRow.IsRootCauseNull() Then
                RootCauseComboBox.SelectedIndex = -1
            Else
                RootCauseComboBox.SelectedValue = missingRow.RootCause
            End If

            StResolutionComboBox.SelectedValue = DBNull.Value
            If missingRow.IsStResolutionNull() Then
                StResolutionComboBox.SelectedIndex = -1
            Else
                StResolutionComboBox.SelectedValue = missingRow.StResolution
            End If

            LtResolutionComboBox.SelectedValue = DBNull.Value
            If missingRow.IsLtResolutionNull() Then
                LtResolutionComboBox.SelectedIndex = -1
            Else
                LtResolutionComboBox.SelectedValue = missingRow.LtResolution
            End If

            If missingRow.IsComments1Null() Then
                Comments1TextBox.Text = ""
            Else
                Comments1TextBox.Text = missingRow.Comments1.ToString()
            End If

            If missingRow.IsComments2Null() Then
                Comments2TextBox.Text = ""
            Else
                Comments2TextBox.Text = missingRow.Comments2.ToString()
            End If

            If missingRow.IsComments3Null() Then
                Comments3TextBox.Text = ""
            Else
                Comments3TextBox.Text = missingRow.Comments3.ToString()
            End If

            'If missingRow.IsUserIdNull() Then
            '    CreatedByLabel.Text = String.Empty
            'Else
            '    CreatedByLabel.Text = Processor.getUserName(missingRow.UserId).ToString()
            'End If

            AssignedComboBox.SelectedValue = DBNull.Value 'Required to load publications & retailers.
            If missingRow.IsAssignedNull() Then
                AssignedComboBox.SelectedValue = DBNull.Value
            Else
                AssignedComboBox.SelectedValue = missingRow.Assigned
            End If


            MissingAdIdLabel.Text = missingRow.MissingAdId.ToString()

            If missingRow.Flash = 0 Then
                FlashCheckBox.Checked = False
            Else
                FlashCheckBox.Checked = True
            End If
            ' Me.FormState = FormStateEnum.View
            pageLoadedComplete = True
            'enableDisableFormComponents(FormStateEnum.View)


        End Sub



        Private Sub m_Processor_LoadingMarkets() Handles m_missingadlogProcessor.LoadingMarkets

            Me.StatusMessage = "Loading Retailers..."

        End Sub

        Private Sub m_Processor_MarketsLoaded() Handles m_missingadlogProcessor.MarketsLoaded

            Me.StatusMessage = String.Empty

        End Sub


        Private Sub m_Processor_LoadingRetailers() Handles m_missingadlogProcessor.LoadingRetailers

            Me.StatusMessage = "Loading Retailers..."

        End Sub

        Private Sub m_Processor_RetailersLoaded() Handles m_missingadlogProcessor.RetailersLoaded

            Me.StatusMessage = String.Empty

        End Sub


        Private Sub m_Processor_LoadingSenders() Handles m_missingadlogProcessor.LoadingSenders

            Me.StatusMessage = "Loading Senders..."

        End Sub

        Private Sub m_Processor_SendersLoaded() Handles m_missingadlogProcessor.SendersLoaded

            Me.StatusMessage = String.Empty

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

        Private Sub PublicationComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PublicationComboBox.KeyUp

            'If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
            '    'senderFilterButton.PerformClick()
            '    Processor.LoadPublication()
            '    PublicationComboBox.SelectedIndex = -1
            'End If

        End Sub

        Private Sub StatusComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles statusComboBox.KeyUp

            If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                Processor.LoadCCStatus("CCStatus")
                statusComboBox.SelectedIndex = -1
            End If

        End Sub

        Private Sub UrgencyComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UrgencyComboBox.KeyUp

            If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                Processor.LoadCCUrgency("CCUrgency")
                urgencyComboBox.SelectedIndex = -1
            End If

        End Sub

        Private Sub RootCauseComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RootCauseComboBox.KeyUp

            If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                Processor.LoadRootCause("CCRootCauses")
                RootCauseComboBox.SelectedIndex = -1
            End If

        End Sub

        Private Sub StResolutionComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles StResolutionComboBox.KeyUp

            If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                Processor.LoadRtResolution("CCLtResolution")
                StResolutionComboBox.SelectedIndex = -1
            End If

        End Sub
        Private Sub LtResolutionComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LtResolutionComboBox.KeyUp

            If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                Processor.LoadLtResolution("CCRtResolution")
                LtResolutionComboBox.SelectedIndex = -1
            End If

        End Sub


        Private Sub enableDisableFormComponents(ByVal formStatus As FormStateEnum)
            Dim lastSavedUser As Integer
            Dim lastSavedDate As Date
            Select Case formStatus
                Case FormStateEnum.View
                    DueDateTypeInDatePicker.Enabled = False
                    DateResolvedTypeInDatePicker.Enabled = False
                    PublicationComboBox.Enabled = False
                    FlashCheckBox.Enabled = False

                    TimeComboBox.Enabled = False
                    AssignedComboBox.Enabled = False
                    RetailerComboBox.Enabled = False

                    SenderComboBox.Enabled = False

                    MarketComboBox.Enabled = False
                    MediaComboBox.Enabled = False


                    statusComboBox.Enabled = False
                    UrgencyComboBox.Enabled = False

                    AdDateTypeInDatePicker.Enabled = False
                    Comments1TextBox.Enabled = False
                    Comments2TextBox.Enabled = False
                    Comments3TextBox.Enabled = False

                    RootCauseComboBox.Enabled = False
                    StResolutionComboBox.Enabled = False
                    LtResolutionComboBox.Enabled = False

                    LastSavedLabel.Text = ""
                    LastSavedLabel.Visible = False


                Case FormStateEnum.Insert
                    DueDateTypeInDatePicker.Enabled = True
                    DateResolvedTypeInDatePicker.Enabled = True
                    PublicationComboBox.Enabled = True
                    FlashCheckBox.Enabled = True

                    TimeComboBox.Enabled = True
                    AssignedComboBox.Enabled = True
                    RetailerComboBox.Enabled = True

                    SenderComboBox.Enabled = True

                    MarketComboBox.Enabled = True
                    MediaComboBox.Enabled = True


                    statusComboBox.Enabled = True
                    UrgencyComboBox.Enabled = True

                    AdDateTypeInDatePicker.Enabled = True
                    Comments1TextBox.Enabled = True
                    Comments2TextBox.Enabled = True
                    Comments3TextBox.Enabled = True

                    RootCauseComboBox.Enabled = True
                    StResolutionComboBox.Enabled = True
                    LtResolutionComboBox.Enabled = True
                    LastSavedLabel.Text = ""
                    LastSavedLabel.Visible = False


                Case FormStateEnum.Edit
                    DueDateTypeInDatePicker.Enabled = True
                    DateResolvedTypeInDatePicker.Enabled = True
                    PublicationComboBox.Enabled = True
                    FlashCheckBox.Enabled = True

                    TimeComboBox.Enabled = True
                    AssignedComboBox.Enabled = True
                    RetailerComboBox.Enabled = True

                    SenderComboBox.Enabled = True

                    MarketComboBox.Enabled = True
                    MediaComboBox.Enabled = True


                    statusComboBox.Enabled = True
                    UrgencyComboBox.Enabled = True

                    AdDateTypeInDatePicker.Enabled = True
                    Comments1TextBox.Enabled = True
                    Comments2TextBox.Enabled = True
                    Comments3TextBox.Enabled = True

                    RootCauseComboBox.Enabled = True
                    StResolutionComboBox.Enabled = True
                    LtResolutionComboBox.Enabled = True
                    LastSavedLabel.Visible = True


                    lastSavedUser = CInt(Processor.getSavedUser(MissingAdId))
                    lastSavedDate = Processor.getSavedDate(MissingAdId)

                    If lastSavedUser > 0 Then
                        LastSavedLabel.Text = "Last Saved by " + Processor.getUserName(lastSavedUser) + " on " + CStr(lastSavedDate)
                    End If


                    CreateTaskLogButton.Text = "Save"
            End Select

        End Sub

        Private Sub EditButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditButton.Click
            Me.FormState = FormStateEnum.Edit
            enableDisableFormComponents(FormStateEnum.Edit)
        End Sub

        Private Sub statusComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles statusComboBox.SelectedIndexChanged

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

        Private Sub MediaComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediaComboBox.SelectedIndexChanged

        End Sub

        Private Sub PublicationComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PublicationComboBox.SelectedIndexChanged

        End Sub

        Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
            If MissingAdIdLabel.Text <> "" Then
                If Processor.DeleteMissingAdLog(CInt(MissingAdIdLabel.Text)) = True Then
                    ClearAllInputs()
                    Me.FormState = FormStateEnum.Insert
                    CreateTaskLogButton.Text = "Create"
                End If
            Else
                MsgBox("No Record to Delete, Please search a record first.", MsgBoxStyle.Exclamation, "MCAP")
            End If
            FlashCheckBox.Checked = False
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
            'PublicationComboBox.SelectedIndex = -1
        End Sub

        Private Sub MarketComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarketComboBox.SelectedValueChanged
            'If Processor.Data.Ret.Count > 0 Then Processor.Data.Ret.Clear()
            'If CInt(MarketComboBox.SelectedValue) > 0 Then
            '    Processor.LoadRetailerByExpectation(CInt(MediaComboBox.SelectedValue), CInt(MarketComboBox.SelectedValue))
            'End If
            'RetailerComboBox.SelectedIndex = -1
        End Sub

        Private Sub ClearDataSource()
            With Processor.Data
                .Media.Clear()
                .Mkt.Clear()
                .Ret.Clear()
                .Publication.Clear()
            End With
        End Sub
    End Class

End Namespace