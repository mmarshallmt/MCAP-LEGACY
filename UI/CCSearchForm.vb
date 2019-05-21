Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Word

Namespace UI

    Public Class CCSearchForm
        Implements IForm

        Private Const FORM_NAME As String = "CC Search Form"
        Private _data As CoverageDataSet
        Private _dataROP As ROPVehicleSearch    'Dataset for "ROP" Media type 
        Private pageLoadedComplete As Boolean

        Private retId, mktId, mediaId, publicationId, senderId As Integer?

        Private DateDiscoveredFrom, DateDiscoveredTo As Date
        Private DueDateFrom, DueDateTo As Date
        Private AdDateFrom, AdDateTo As Date
        Private ResolvedFrom, ResolvedTo As Date
        Private ActionType, SpecificAction As Integer
        Private RootCuase, Stresolution, Ltresolution As Integer
        Private Comments1, Comments2, Comments3 As String
        Private Phone, Person, PersonName, Comments As String


        Private MissingAdId, FlashId As Integer
        Private Time As String
        Private UserId, Assigned As Integer
        Private Status, Urgency, Flash, RootCause As Integer
        Private TaskLogSelected As Boolean
        Private MissingAdSelected As Boolean
        Private m_reportFilterCriteria As String
        Private _condition As String




        Protected Overrides Sub ClearAllInputs()


            retailerComboBox.SelectedValue = DBNull.Value
            retailerComboBox.SelectedIndex = -1
            retailerComboBox.Text = String.Empty

            marketComboBox.SelectedValue = DBNull.Value
            marketComboBox.SelectedIndex = -1
            marketComboBox.Text = String.Empty

            mediaComboBox.SelectedValue = DBNull.Value
            mediaComboBox.SelectedIndex = -1
            mediaComboBox.Text = String.Empty

            newspaperComboBox.SelectedValue = DBNull.Value
            newspaperComboBox.SelectedIndex = -1
            newspaperComboBox.Text = String.Empty

            SenderComboBox.SelectedValue = DBNull.Value
            SenderComboBox.SelectedIndex = -1
            SenderComboBox.Text = String.Empty


            'IsMissingComboBox.SelectedValue = DBNull.Value
            IsMissingComboBox.SelectedIndex = -1
            IsMissingComboBox.Text = String.Empty


            'IsFlashComboBox.SelectedValue = DBNull.Value
            IsFlashComboBox.SelectedIndex = -1
            IsFlashComboBox.Text = String.Empty

            AdDateFromTypeInDatePicker.Value = Nothing ' System.DateTime.Today.AddMonths(-1)
            AdDateToTypeInDatePicker.Value = Nothing ' System.DateTime.Today
            TaskLogRadioButton.Enabled = True


        End Sub

        Private ReadOnly Property FilterCriteria() As String
            Get
                Return m_reportFilterCriteria
            End Get
        End Property

        Private Sub loadFormValues()

            Dim HourIntervalNow As Integer
            Dim MinIntervalNow As Integer
            Dim ByHourIntervalNow As String
            Dim ByHourIntervalArray(24) As String
            Dim IsMissingArray(3) As String
            Dim IsFlashArray(3) As String
            Dim ByAMPM As String
            Dim dateformat As String

            ByHourIntervalArray = New String() {"12:00AM", "12:30AM", "1:00AM", "1:30AM", "2:00AM", "2:30AM", "3:00AM", "3:30AM", "4:00AM", "4:30AM", "5:00AM", "5:30AM", "6:00AM", "6:30AM", "7:00AM", _
                                "7:30AM", "8:00AM", "8:30AM", "9:00AM", "9:30AM", "10:00AM", "10:30AM", "11:00AM", "11:30AM", "12:00PM", "12:30PM", "1:00PM", "1:30PM", "2:00PM", "2:30PM", "3:00PM", "3:30PM", "4:00PM", "4:30PM", "5:00PM", "5:30PM", "6:00PM", "6:30PM", "7:00PM", _
                                "7:30PM", "8:00PM", "8:30PM", "9:00PM", "9:30PM", "10:00PM", "10:30PM", "11:00PM", "11:30PM"}
            IsFlashArray = New String() {"NO", "YES"}
            IsMissingArray = New String() {"NO", "YES"}

            dateformat = "MMM ddd d HH:mm yyyy"
            pageLoadedComplete = False

            LoadRetailers()
            retailerComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            retailerComboBox.SelectedIndex = -1
            LoadMarkets()
            marketComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            marketComboBox.SelectedIndex = -1
            LoadMedia()
            mediaComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            mediaComboBox.SelectedIndex = -1
            LoadNewspaper()
            newspaperComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            newspaperComboBox.SelectedIndex = -1

            LoadAssignedUsers(User.LocationId)
            AssignedComboBox.DisplayMember = "FullName"
            AssignedComboBox.ValueMember = "UserId"
            AssignedComboBox.DataSource = _data.User
            AssignedComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            AssignedComboBox.SelectedIndex = -1

            'Processor.ByHourlyTime()
            TimeComboBox.DisplayMember = "intervalName"
            TimeComboBox.ValueMember = "intervalId"
            TimeComboBox.DataSource = ByHourIntervalArray 'Processor.Data.ByHourInterval
            HourIntervalNow = DateTime.Now.Hour
            MinIntervalNow = DateTime.Now.Minute
            TimeComboBox.SelectedIndex = -1
            'LoadMarket()
            'marketComboBox.DisplayMember = "Descrip"
            'marketComboBox.ValueMember = "MktId"
            'marketComboBox.DataSource = _data.Mkt
            'marketComboBox.SelectedIndex = -1
            'marketComboBox.DropDownStyle = ComboBoxStyle.DropDownList

            LoadSender()
            SenderComboBox.DisplayMember = "Name"
            SenderComboBox.ValueMember = "SenderId"
            SenderComboBox.DataSource = _data.Sender
            SenderComboBox.SelectedIndex = -1
            SenderComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            SenderComboBox.SelectedIndex = -1

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
            TimeComboBox.SelectedIndex = getArrayIndex(ByHourIntervalArray, ByHourIntervalNow + ByAMPM) - 1

            If TimeComboBox.SelectedValue Is Nothing Then
                TimeComboBox.SelectedIndex = 23
            End If
            TimeComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            TimeComboBox.SelectedIndex = -1

            LoadCCStatus("CCStatus")
            StatusComboBox.ValueMember = "codeid"
            StatusComboBox.DisplayMember = "codedescrip"
            StatusComboBox.DataSource = _data.CCStatus
            StatusComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            StatusComboBox.SelectedIndex = -1

            LoadCCUrgency("CCUrgency")
            UrgencyComboBox.ValueMember = "codeid"
            UrgencyComboBox.DisplayMember = "codedescrip"
            UrgencyComboBox.DataSource = _data.CCUrgency
            UrgencyComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            UrgencyComboBox.SelectedIndex = -1

            LoadCCActionType("CCActionType")
            ActionTypeComboBox.ValueMember = "codeid"
            ActionTypeComboBox.DisplayMember = "codedescrip"
            ActionTypeComboBox.DataSource = _data.CCActionType
            ActionTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            ActionTypeComboBox.SelectedIndex = -1

            LoadCCSpecificAction("CCSpecificAction")
            SpecificActionComboBox.ValueMember = "codeid"
            SpecificActionComboBox.DisplayMember = "Descrip"
            SpecificActionComboBox.DataSource = _data.CCSpecificAction
            SpecificActionComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            SpecificActionComboBox.SelectedIndex = -1

            LoadRootCause("CCRootCauses")
            RootCauseComboBox.DisplayMember = "codedescrip"
            RootCauseComboBox.ValueMember = "codeid"
            RootCauseComboBox.DataSource = _data.RootCause
            RootCauseComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            RootCauseComboBox.SelectedIndex = -1

            LoadLtResolution("CCLtResolution")
            StresolutionComboBox.DisplayMember = "codedescrip"
            StresolutionComboBox.ValueMember = "codeid"
            StresolutionComboBox.DataSource = _data.LtResolution
            StresolutionComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            StresolutionComboBox.SelectedIndex = -1

            LoadRtResolution("CCRtResolution")
            LtresolutionComboBox.DisplayMember = "codedescrip"
            LtresolutionComboBox.ValueMember = "codeid"
            LtresolutionComboBox.DataSource = _data.RtResolution
            LtresolutionComboBox.DropDownStyle = ComboBoxStyle.DropDownList
            LtresolutionComboBox.SelectedIndex = -1

            IsFlashComboBox.DisplayMember = "FlashName"
            IsFlashComboBox.ValueMember = "FlashId"
            IsFlashComboBox.DataSource = IsFlashArray
            IsFlashComboBox.SelectedIndex = -1

            IsMissingComboBox.DisplayMember = "MissingName"
            IsMissingComboBox.ValueMember = "MissingAd"
            IsMissingComboBox.DataSource = IsMissingArray
            IsMissingComboBox.SelectedIndex = -1

            If TaskLogRadioButton.Checked Then
                LoadMissingAdId()
            End If



        End Sub



        Private Sub loadFormOptions()
            TaskLogSelected = False
            MissingAdSelected = False

            If TaskLogRadioButton.Checked = True Then
                ' Set Date Resolved to disabled - No date resolved in CCtask log table
                TaskLogSelected = True
                MissingAdSelected = False
                DateGroupBox1.Text = "Start Date"
                DateGroupBox4.Enabled = False
                RootCauseComboBox.Enabled = False
                'Comments1TextBox.Enabled = False
                StresolutionComboBox.Enabled = False
                'Comments2TextBox.Enabled = False
                LtresolutionComboBox.Enabled = False
                'Comments3TextBox.Enabled = False
                ActionTypeComboBox.Enabled = True
                SpecificActionComboBox.Enabled = True
                'OtherContactName()
                PhoneTextBox.Enabled = True
                PersonTextBox.Enabled = True
                PersonNameTextBox.Enabled = True
                CommentsTextBox.Enabled = True
                IsFlashComboBox.Enabled = False
                IsMissingComboBox.Enabled = True


            ElseIf MissingLogRadioButton.Checked = True Then
                ' Set Date Resolved to disabled - No date resolved in CCtask log table
                TaskLogSelected = False
                MissingAdSelected = True
                DateGroupBox1.Text = "Date Discovered"
                DateGroupBox4.Enabled = True

                RootCauseComboBox.Enabled = True
                'Comments1TextBox.Enabled = True
                StresolutionComboBox.Enabled = True
                'Comments2TextBox.Enabled = True
                LtresolutionComboBox.Enabled = True
                'Comments3TextBox.Enabled = True
                ActionTypeComboBox.Enabled = False
                SpecificActionComboBox.Enabled = False
                'OtherContactName()
                PhoneTextBox.Enabled = False
                PersonTextBox.Enabled = False
                PersonNameTextBox.Enabled = False
                CommentsTextBox.Enabled = False
                IsFlashComboBox.Enabled = True
                IsMissingComboBox.Enabled = False

            End If

        End Sub

        Public Sub LoadAssignedUsers(ByVal locationId As Integer)
            Dim userAdapter As CoverageDataSetTableAdapters.UserTableAdapter
            userAdapter = New CoverageDataSetTableAdapters.UserTableAdapter
            userAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            userAdapter.Fill(_data.User, locationId)
            userAdapter.Dispose()
            userAdapter = Nothing
        End Sub

        Public Sub LoadMedia(ByVal RetailerId As Integer)

            Dim mediaAdapter As CoverageDataSetTableAdapters.MediaTableAdapter
            mediaAdapter = New CoverageDataSetTableAdapters.MediaTableAdapter
            mediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            mediaAdapter.FillByRetailer(_data.Media, RetailerId)
            mediaAdapter.Dispose()
            mediaAdapter = Nothing
        End Sub

        Private Sub LoadRetailers()
            Dim tempAdapter As CoverageDataSetTableAdapters.RetTableAdapter

            tempAdapter = New CoverageDataSetTableAdapters.RetTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.FillDflt(_data.Ret)
            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub


        Private Sub LoadMarkets()
            Dim tempAdapter As CoverageDataSetTableAdapters.MktTableAdapter
            tempAdapter = New CoverageDataSetTableAdapters.MktTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.FillByDflt(_data.Mkt)
            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub


        Private Sub LoadMedia()
            Dim tempAdapter As CoverageDataSetTableAdapters.MediaTableAdapter

            tempAdapter = New CoverageDataSetTableAdapters.MediaTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(_data.Media)
            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub

        Private Sub LoadNewspaper()
            Dim tempAdapter As CoverageDataSetTableAdapters.PublicationTableAdapter
            tempAdapter = New CoverageDataSetTableAdapters.PublicationTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.FillByDefualt(_data.Publication)
            tempAdapter.Dispose()
            tempAdapter = Nothing
        End Sub

        Public Sub LoadFrequency()
            Dim frequencyAdapter As ExpectationReportDataSetTableAdapters.vwFrequencyTableAdapter
            frequencyAdapter = New ExpectationReportDataSetTableAdapters.vwFrequencyTableAdapter
            frequencyAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            'frequencyAdapter.Fill(Data.vwFrequency)
            frequencyAdapter.Dispose()
            frequencyAdapter = Nothing
        End Sub

        Public Sub LoadCCStatus(ByVal CodeName As String)

            Dim codeAdapter As CoverageDataSetTableAdapters.CCStatusTableAdapter
            codeAdapter = New CoverageDataSetTableAdapters.CCStatusTableAdapter
            codeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            codeAdapter.Fill(_data.CCStatus, CodeName)
            codeAdapter.Dispose()
            codeAdapter = Nothing

        End Sub
        Public Sub LoadCCUrgency(ByVal CodeName As String)

            Dim codeAdapter As CoverageDataSetTableAdapters.CCUrgencyTableAdapter
            codeAdapter = New CoverageDataSetTableAdapters.CCUrgencyTableAdapter
            codeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            codeAdapter.Fill(_data.CCUrgency, CodeName)
            codeAdapter.Dispose()
            codeAdapter = Nothing

        End Sub
        Public Sub LoadCCActionType(ByVal CodeName As String)

            Dim codeAdapter As CoverageDataSetTableAdapters.CCActionTypeTableAdapter
            codeAdapter = New CoverageDataSetTableAdapters.CCActionTypeTableAdapter
            codeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            codeAdapter.Fill(_data.CCActionType, CodeName)
            codeAdapter.Dispose()
            codeAdapter = Nothing

        End Sub
        Public Sub LoadCCSpecificAction(ByVal CodeName As String)

            'Dim codeAdapter As CoverageDataSetTableAdapters.CCSpecificActionTableAdapter
            'codeAdapter = New CoverageDataSetTableAdapters.CCSpecificActionTableAdapter
            'codeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            'codeAdapter.Fill(Data.CCSpecificAction, CodeName)
            'codeAdapter.Dispose()
            'codeAdapter = Nothing

        End Sub

        Public Sub LoadSender()
            Dim senderAdapter As CoverageDataSetTableAdapters.SenderTableAdapter
            senderAdapter = New CoverageDataSetTableAdapters.SenderTableAdapter
            senderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            senderAdapter.Fill(_data.Sender)
            senderAdapter.Dispose()
            senderAdapter = Nothing
        End Sub

        Public Sub LoadLtResolution(ByVal CodeName As String)
            Dim ltResolutionAdapter As CoverageDataSetTableAdapters.LtResolutionTableAdapter
            ltResolutionAdapter = New CoverageDataSetTableAdapters.LtResolutionTableAdapter
            ltResolutionAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            ltResolutionAdapter.Fill(_data.LtResolution, CodeName)
            ltResolutionAdapter.Dispose()
            ltResolutionAdapter = Nothing
        End Sub

        Public Sub LoadRtResolution(ByVal CodeName As String)
            Dim rtResolutionAdapter As CoverageDataSetTableAdapters.RtResolutionTableAdapter
            rtResolutionAdapter = New CoverageDataSetTableAdapters.RtResolutionTableAdapter
            rtResolutionAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            rtResolutionAdapter.Fill(_data.RtResolution, CodeName)
            rtResolutionAdapter.Dispose()
            rtResolutionAdapter = Nothing
        End Sub
        Public Sub LoadMissingAdId() 'ByVal ReportType As Integer)
            ' If ReportType = 0 Then
            'Dim rootCauseAdapter As CoverageDataSetTableAdapters.RootCauseTableAdapter
            'rootCauseAdapter = New CoverageDataSetTableAdapters.RootCauseTableAdapter
            'rootCauseAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            ''rootCauseAdapter.Fill(_data.RootCause, CodeName)
            'rootCauseAdapter.Dispose()
            'rootCauseAdapter = Nothing
            ' End If
        End Sub

        Public Sub LoadRootCause(ByVal CodeName As String)
            Dim rootCauseAdapter As CoverageDataSetTableAdapters.RootCauseTableAdapter
            rootCauseAdapter = New CoverageDataSetTableAdapters.RootCauseTableAdapter
            rootCauseAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            rootCauseAdapter.Fill(_data.RootCause, CodeName)
            rootCauseAdapter.Dispose()
            rootCauseAdapter = Nothing
        End Sub
        Private Sub getPageData()

            If TimeComboBox.SelectedValue Is Nothing OrElse TimeComboBox.SelectedValue Is DBNull.Value Then
                Time = String.Empty
            Else
                Time = CType(TimeComboBox.SelectedValue, String)
            End If

            If AssignedComboBox.SelectedValue Is Nothing OrElse AssignedComboBox.SelectedValue Is DBNull.Value Then
                Assigned = 0
            Else
                Assigned = CType(AssignedComboBox.SelectedValue, Integer)
            End If

            If retailerComboBox.SelectedValue Is Nothing OrElse retailerComboBox.SelectedValue Is DBNull.Value Then
                retId = 0
            Else
                retId = CType(retailerComboBox.SelectedValue, Integer)
            End If

            If marketComboBox.SelectedValue Is Nothing OrElse marketComboBox.SelectedValue Is DBNull.Value Then
                mktId = 0
            Else
                mktId = CType(marketComboBox.SelectedValue, Integer)
            End If

            If mediaComboBox.SelectedValue Is Nothing OrElse mediaComboBox.SelectedValue Is DBNull.Value Then
                mediaId = 0
            Else
                mediaId = CType(mediaComboBox.SelectedValue, Integer)
            End If

            If newspaperComboBox.SelectedValue Is Nothing OrElse newspaperComboBox.SelectedValue Is DBNull.Value Then
                publicationId = 0
            Else
                publicationId = CType(newspaperComboBox.SelectedValue, Integer)
            End If

            If SenderComboBox.SelectedValue Is Nothing OrElse SenderComboBox.SelectedValue Is DBNull.Value Then
                senderId = 0
            Else
                senderId = CType(SenderComboBox.SelectedValue, Integer)
            End If

            If DateDiscoveredFromTypeInDatePicker.Value Is Nothing Then
                DateDiscoveredFrom = CDate("1/1/1900")
            Else
                DateDiscoveredFrom = CType(DateDiscoveredFromTypeInDatePicker.Value.Value, Date)
            End If

            If DateDiscoveredToTypeInDatePicker.Value Is Nothing Then
                DateDiscoveredTo = CDate("1/1/1900")
            Else
                DateDiscoveredTo = CType(DateDiscoveredToTypeInDatePicker.Value.Value, Date)
            End If

            If DueDateFromTypeInDatePicker.Value Is Nothing Then
                DueDateFrom = CDate("1/1/1900")
            Else
                DueDateFrom = CType(DueDateFromTypeInDatePicker.Value.Value, Date)
            End If
            If DueDateToTypeInDatePicker.Value Is Nothing Then
                DueDateTo = CDate("1/1/1900")
            Else
                DueDateTo = CType(DueDateToTypeInDatePicker.Value.Value, Date)
            End If

            If AdDateFromTypeInDatePicker.Value Is Nothing Then
                AdDateFrom = CDate("1/1/1900")
            Else
                AdDateFrom = CType(AdDateFromTypeInDatePicker.Value.Value, Date)
            End If
            If AdDateToTypeInDatePicker.Value Is Nothing Then
                AdDateTo = CDate("1/1/1900")
            Else
                AdDateTo = CType(AdDateToTypeInDatePicker.Value.Value, Date)
            End If

            If StatusComboBox.SelectedValue Is Nothing Then
                Status = 0
            Else
                Status = CType(StatusComboBox.SelectedValue, Integer)
            End If

            If UrgencyComboBox.SelectedValue Is Nothing Then
                Urgency = 0
            Else
                Urgency = CType(UrgencyComboBox.SelectedValue, Integer)
            End If

            If TaskLogSelected Then
                ActionType = CType(ActionTypeComboBox.SelectedValue, Integer)
                SpecificAction = CType(SpecificActionComboBox.SelectedValue, Integer)
                Phone = CType(PhoneTextBox.Text, String)
                Person = CType(PersonTextBox.Text, String)
                PersonName = CType(PersonNameTextBox.Text, String)
                Comments = CType(CommentsTextBox.Text, String)
                MissingAdId = CType(IsMissingComboBox.SelectedIndex, Integer)
            ElseIf MissingAdSelected Then
                RootCuase = CType(RootCauseComboBox.SelectedValue, Integer)
                Comments = CType(CommentsTextBox.Text, String)
                Stresolution = CType(StresolutionComboBox.SelectedValue, Integer)
                'Comments2 = CType(Comments2TextBox.Text, String)
                Ltresolution = CType(LtresolutionComboBox.SelectedValue, Integer)
                Flash = CType(IsFlashComboBox.SelectedIndex, Integer)

                ' Include date resolved, which is not there for default dates, only available with missing form
                If DateResolvedFromTypeInDatePicker.Value Is Nothing Then
                    ResolvedFrom = CDate("1/1/1900")
                Else
                    ResolvedFrom = CType(DateResolvedFromTypeInDatePicker.Value.Value, Date)
                End If
                If DateResolvedToTypeInDatePicker.Value Is Nothing Then
                    ResolvedTo = CDate("1/1/1900")
                Else
                    ResolvedTo = CType(DateResolvedToTypeInDatePicker.Value.Value, Date)
                End If

                FlashId = CType(IsFlashComboBox.SelectedIndex, Integer)

            End If

        End Sub
        Private Function DataParameter(ByVal LCondition As String, ByVal _alias As String) As String
            Dim param As System.Text.StringBuilder

            param = New System.Text.StringBuilder

            If mediaComboBox.SelectedIndex >= 0 Then                                                 '1*
                param.Append(_alias + "MediaId=" + mediaComboBox.SelectedValue.ToString)
            End If
            If marketComboBox.SelectedIndex >= 0 Then                   '1*
                If param.Length > 0 Then param.Append(LCondition)
                param.Append(_alias + "MarketId=" + marketComboBox.SelectedValue.ToString)
            End If
            If newspaperComboBox.SelectedIndex >= 0 Then            '3*
                If param.Length > 0 Then param.Append(LCondition)
                param.Append(_alias + "PublicationId=" + newspaperComboBox.SelectedValue.ToString)
            End If
            If retailerComboBox.SelectedIndex >= 0 Then                        '4*
                If param.Length > 0 Then param.Append(LCondition)
                param.Append(_alias + "RetailerId=" + retailerComboBox.SelectedValue.ToString)
            End If
            If SenderComboBox.SelectedIndex >= 0 Then                          '5*
                If param.Length > 0 Then param.Append(LCondition)
                param.Append(_alias + "SenderId=" + SenderComboBox.SelectedValue.ToString)
            End If
            If TimeComboBox.SelectedIndex >= 0 Then                           '6*
                If param.Length > 0 Then param.Append(LCondition)
                param.Append(_alias + "Time=" + "'" + TimeComboBox.Text + "'")
            End If
            If AssignedComboBox.SelectedIndex >= 0 Then                         '7*
                If param.Length > 0 Then param.Append(LCondition)
                param.Append(_alias + "Assigned=" + AssignedComboBox.SelectedValue.ToString)
            End If
            If StatusComboBox.SelectedIndex >= 0 Then                           '8*
                If param.Length > 0 Then param.Append(LCondition)
                param.Append(_alias + "Status=" + StatusComboBox.SelectedValue.ToString)
            End If
            If UrgencyComboBox.SelectedIndex >= 0 Then                           '9*
                If param.Length > 0 Then param.Append(LCondition)
                param.Append(_alias + "Urgency=" + UrgencyComboBox.SelectedValue.ToString)
            End If
            If String.IsNullOrEmpty(AdDateFromTypeInDatePicker.Value.ToString) = False And String.IsNullOrEmpty(AdDateToTypeInDatePicker.Value.ToString) = False Then                             '10*
                If param.Length > 0 Then param.Append(LCondition)
                param.Append("(" + _alias + "AdDate between '" + AdDateFromTypeInDatePicker.Value.ToString + "' AND '" + AdDateToTypeInDatePicker.Value.ToString + "')")
            End If
            If String.IsNullOrEmpty(DueDateFromTypeInDatePicker.Value.ToString) = False And String.IsNullOrEmpty(DueDateToTypeInDatePicker.Value.ToString) = False Then                             '12*
                If param.Length > 0 Then param.Append(LCondition)
                param.Append("(" + _alias + "DueDate between '" + DueDateFromTypeInDatePicker.Value.ToString + "' AND '" + DueDateToTypeInDatePicker.Value.ToString + "')")
            End If
            If TaskLogRadioButton.Checked = True Then
                If String.IsNullOrEmpty(PhoneTextBox.Text) = False Then                     '16
                    If param.Length > 0 Then param.Append(LCondition)
                    param.Append(_alias + "PhoneNoCalled='" + PhoneTextBox.Text + "'")
                End If
                If String.IsNullOrEmpty(PersonTextBox.Text) = False Then                                                 '17
                    If param.Length > 0 Then param.Append(LCondition)
                    param.Append(_alias + "PersonSpokeWith='" + PersonTextBox.Text + "'")
                End If
                If String.IsNullOrEmpty(PersonNameTextBox.Text) = False Then                                                '18
                    If param.Length > 0 Then param.Append(LCondition)
                    param.Append(_alias + "PersonName='" + PersonNameTextBox.Text + "'")
                End If
                If ActionTypeComboBox.SelectedIndex >= 1 Then                                              '19
                    If param.Length > 0 Then param.Append(LCondition)
                    param.Append(_alias + "ActionType=" + ActionTypeComboBox.SelectedValue.ToString)
                End If
                If SpecificActionComboBox.SelectedIndex >= 1 Then                   '19
                    If param.Length > 0 Then param.Append(LCondition)
                    param.Append(_alias + "SpecificAction=" + SpecificActionComboBox.SelectedValue.ToString)
                End If
                If String.IsNullOrEmpty(CommentsTextBox.Text) = False Then                     '19
                    If param.Length > 0 Then param.Append(LCondition)
                    param.Append(_alias + "Comments='" + CommentsTextBox.Text + "'")
                End If
                If String.IsNullOrEmpty(DateDiscoveredFromTypeInDatePicker.Value.ToString) = False And String.IsNullOrEmpty(DateDiscoveredToTypeInDatePicker.Value.ToString) = False Then                            '19
                    If param.Length > 0 Then param.Append(LCondition)
                    param.Append("(" + _alias + "Date between '" + DateDiscoveredFromTypeInDatePicker.Value.ToString + "' AND '" + DateDiscoveredToTypeInDatePicker.Value.ToString + "')")
                End If
            Else
                If String.IsNullOrEmpty(DateResolvedFromTypeInDatePicker.Value.ToString) = False And String.IsNullOrEmpty(DateResolvedToTypeInDatePicker.Value.ToString) = False Then
                    If param.Length > 0 Then param.Append(LCondition)
                    param.Append("(" + _alias + "DateResolved between '" + DateResolvedFromTypeInDatePicker.Value.ToString + "' AND '" + DateResolvedToTypeInDatePicker.Value.ToString + "')")
                End If
                If IsFlashComboBox.SelectedIndex >= 0 Then                       '19
                    If param.Length > 0 Then param.Append(LCondition)
                    param.Append(_alias + "Flash=" + IsFlashComboBox.SelectedIndex.ToString)
                End If
                If RootCauseComboBox.SelectedIndex >= 1 Then                       '19
                    If param.Length > 0 Then param.Append(LCondition)
                    param.Append(_alias + "RootCause=" + RootCauseComboBox.SelectedValue.ToString)
                End If
                If StresolutionComboBox.SelectedIndex >= 1 Then                            '19
                    If param.Length > 0 Then param.Append(LCondition)
                    param.Append(_alias + "StResolution=" + StresolutionComboBox.SelectedValue.ToString)
                End If
                If LtresolutionComboBox.SelectedIndex >= 1 Then                          '19
                    If param.Length > 0 Then param.Append(LCondition)
                    param.Append(_alias + "LtResolution=" + LtresolutionComboBox.SelectedValue.ToString)
                End If
                If String.IsNullOrEmpty(DateDiscoveredFromTypeInDatePicker.Value.ToString) = False And String.IsNullOrEmpty(DateDiscoveredToTypeInDatePicker.Value.ToString) = False Then                            '19
                    If param.Length > 0 Then param.Append(LCondition)
                    param.Append("(" + _alias + "DateDiscovered between '" + DateDiscoveredFromTypeInDatePicker.Value.ToString + "' AND '" + DateDiscoveredToTypeInDatePicker.Value.ToString + "')")
                End If
            End If

            Return param.ToString()
        End Function

        Private Sub LoadRecordsList()
            Dim _LCondition As String
            Dim _alias As String
            'getPageData()

            If ANDRadioButton.Checked = True Then
                _LCondition = " AND "
            Else
                _LCondition = " OR "
            End If

            If TaskLogRadioButton.Checked = False Then
                _alias = "CMAs."
            Else
                _alias = "CTLs."
            End If

            _condition = DataParameter(_LCondition, _alias)
            If TaskLogSelected = True Then
                _data.CCTaskLogsReports.Clear()
                Dim tempAdapter As New CoverageDataSetTableAdapters.CCTaskLogsReportsTableAdapter()
                tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

                'tempAdapter.FillByReportSP(_data.CCTaskLogsReports, Time, DateDiscoveredFrom, DateDiscoveredTo, DueDateFrom, DueDateTo, Assigned, _
                'AdDateFrom, AdDateTo, retId, mktId, mediaId, senderId, publicationId, Status, Urgency, ActionType, SpecificAction, Phone, Person, PersonName, _
                'Comments, MissingAdId, UserId)
                tempAdapter.FillByCCTLReport(_data.CCTaskLogsReports, _condition, "Task Logs")

                'PrepareTaskLogForGrid()
                vehicleDataGridView.DataSource = _data.CCTaskLogsReports
                vehicleDataGridView.Columns("PersonName").Visible = False
                vehicleDataGridView.Columns("Reminders").Visible = False
                If vehicleDataGridView.RowCount > 0 Then
                    PrepareRetailerForGrid()
                Else
                    MsgBox("No records returned from search")
                    Exit Sub
                End If
                tempAdapter.Dispose()
                tempAdapter = Nothing
            ElseIf MissingAdSelected = True Then
                _data.CCMissingAdLogsReports.Clear()
                Dim tempAdapter As New CoverageDataSetTableAdapters.CCMissingAdLogsReportsTableAdapter()
                tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
                'tempAdapter.FillByReportSP(_data.CCMissingAdLogsReports, MissingAdId, DateDiscoveredFrom, DateDiscoveredTo, Time, DueDateFrom, DueDateTo, _
                'Assigned, ResolvedFrom, ResolvedTo, AdDateFrom, AdDateTo, retId, mktId, mediaId, senderId, publicationId, Status, _
                'Urgency, Flash, RootCause, Comments, Stresolution, Ltresolution, UserId)

                tempAdapter.FillByCCMAReport(_data.CCMissingAdLogsReports, _condition, "Missing Ad Logs")

                vehicleDataGridView.DataSource = _data.CCMissingAdLogsReports
                vehicleDataGridView.Columns("RetailerId").Visible = False
                vehicleDataGridView.Columns("MarketId").Visible = False
                vehicleDataGridView.Columns("MediaId").Visible = False
                vehicleDataGridView.Columns("SenderId").Visible = False
                vehicleDataGridView.Columns("PublicationId").Visible = False
                vehicleDataGridView.Columns("MissingIdValue").Visible = False
                vehicleDataGridView.Columns("UserId").Visible = False
                If vehicleDataGridView.RowCount > 0 Then
                    PrepareRetailerForGrid()
                Else
                    MsgBox("No records returned from search")

                    Exit Sub
                End If

                tempAdapter.Dispose()
                tempAdapter = Nothing

            End If


        End Sub

        ' @Omar
        Private Sub PrepareDataGridView()
            Dim buttonColumn As System.Windows.Forms.DataGridViewButtonColumn

            'vehicleDataGridView.DataSource = _data.VehicleList

            'For i As Integer = 0 To vehicleDataGridView.ColumnCount - 1
            '    vehicleDataGridView.Columns(i).Visible = True
            'Next

            If vehicleDataGridView.Columns.Contains("RetailerId") Then
                vehicleDataGridView.Columns("RetId").Visible = False
            End If
            If vehicleDataGridView.Columns.Contains("MarketId") Then
                vehicleDataGridView.Columns("MktId").Visible = False
            End If
            If vehicleDataGridView.Columns.Contains("MediaId") Then
                vehicleDataGridView.Columns("MediaId").Visible = False
            End If
            If vehicleDataGridView.Columns.Contains("PublicationId") Then
                vehicleDataGridView.Columns("PublicationId").Visible = False
            End If

            'If vehicleDataGridView.Columns.Contains("Details") Then
            '    vehicleDataGridView.Columns.Remove(vehicleDataGridView.Columns("Details"))
            'End If

            'If vehicleDataGridView.Columns.Contains("NewsPaper") Then
            '    vehicleDataGridView.Columns("Newspaper").DisplayIndex = 5
            'End If

            buttonColumn = New System.Windows.Forms.DataGridViewButtonColumn()
            buttonColumn.Visible = True
            buttonColumn.DataPropertyName = "Details"
            buttonColumn.Width = 20
            vehicleDataGridView.Columns.Add(buttonColumn)

        End Sub

        'IF "ROP" Media type Then hide "Reta0iler" Column from Gridview (By Kapil) 
        Private Sub PrepareRetailerForGrid()
            If vehicleDataGridView.Columns.Contains("RetailerId") Then
                vehicleDataGridView.Columns("RetailerId").Visible = False
            End If
            If vehicleDataGridView.Columns.Contains("SenderId") Then
                vehicleDataGridView.Columns("SenderId").Visible = False
            End If
            If vehicleDataGridView.Columns.Contains("MarketId") Then
                vehicleDataGridView.Columns("MarketId").Visible = False
            End If
            If vehicleDataGridView.Columns.Contains("MediaId") Then
                vehicleDataGridView.Columns("MediaId").Visible = False
            End If
            If vehicleDataGridView.Columns.Contains("PublicationId") Then
                vehicleDataGridView.Columns("PublicationId").Visible = False
            End If
            If vehicleDataGridView.Columns.Contains("UserId") Then
                vehicleDataGridView.Columns("UserId").Visible = False
            End If
            If vehicleDataGridView.Columns.Contains("MissingAd") Then
                vehicleDataGridView.Columns("MissingAd").Visible = False
            End If
            If vehicleDataGridView.Columns.Contains("MissingIdValue") Then
                vehicleDataGridView.Columns("MissingIdValue").Visible = False
            End If
        End Sub

        Private Sub PrepareMissingAdLogForGrid()
        End Sub

        Private Sub PrepareTaskLogForGrid()
        End Sub

        Private Function AreInputsValid() As Boolean
            Dim validData As Boolean
            validData = True

            If DateDiscoveredFromTypeInDatePicker.Value Is Nothing And DateDiscoveredToTypeInDatePicker.Value Is Nothing Then
            Else
                If CType(DateDiscoveredFromTypeInDatePicker.Value, Date) > CType(DateDiscoveredToTypeInDatePicker.Value, Date) Then
                    validData = False
                    MsgBox("Date Discovered start date must be less than end date", MsgBoxStyle.OkOnly)
                End If
            End If
            If DueDateFromTypeInDatePicker.Value Is Nothing And DueDateToTypeInDatePicker.Value Is Nothing Then
            Else
                If CType(DueDateFromTypeInDatePicker.Value, Date) > CType(DueDateToTypeInDatePicker.Value, Date) Then
                    validData = False
                    MsgBox("Due Date start date must be less than end date", MsgBoxStyle.OkOnly)
                End If
            End If
            If DateResolvedFromTypeInDatePicker.Value Is Nothing And DateResolvedToTypeInDatePicker.Value Is Nothing Then
            Else
                If CType(DateResolvedFromTypeInDatePicker.Value, Date) > CType(DateResolvedToTypeInDatePicker.Value, Date) Then
                    validData = False
                    MsgBox("Date Resolved start date must be less than end date", MsgBoxStyle.OkOnly)
                End If
            End If
            If AdDateFromTypeInDatePicker.Value Is Nothing And AdDateToTypeInDatePicker.Value Is Nothing Then
            Else
                If CType(AdDateFromTypeInDatePicker.Value, Date) > CType(AdDateToTypeInDatePicker.Value, Date) Then
                    validData = False
                    MsgBox("Ad Date start date must be less than end date", MsgBoxStyle.OkOnly)
                End If
            End If




            Return validData

        End Function


#Region " IForm Implementation "


        Public Event FormInitialized() Implements IForm.FormInitialized
        Public Event InitializingForm() Implements IForm.InitializingForm

        Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
        Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied

        Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

        End Sub

        Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

            Me.SuspendLayout()

            RaiseEvent InitializingForm()

            _data = New CoverageDataSet()
            _dataROP = New ROPVehicleSearch()

            TaskLogSelected = True
            MissingAdSelected = False

            loadFormValues()

            retailerComboBox.DisplayMember = "Descrip"
            retailerComboBox.ValueMember = "RetId"
            retailerComboBox.DataSource = _data.Ret

            marketComboBox.DisplayMember = "Descrip"
            marketComboBox.ValueMember = "MktId"
            marketComboBox.DataSource = _data.Mkt

            mediaComboBox.DisplayMember = "Descrip"
            mediaComboBox.ValueMember = "MediaId"
            mediaComboBox.DataSource = _data.Media

            newspaperComboBox.DisplayMember = "Descrip"
            newspaperComboBox.ValueMember = "PublicationId"
            newspaperComboBox.DataSource = _data.Publication

            ClearAllInputs()
            PrepareDataGridView()

            RaiseEvent FormInitialized()

            Me.ResumeLayout()

        End Sub


#End Region

#Region "Private function"

        Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

            Me.Close()

        End Sub

        Private Sub resetButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles resetButton.Click
            'RemoveHandlerMarket()
            'RemoveHandlerNewspaper()

            LoadMarkets()
            LoadNewspaper()


            ClearAllInputs()

            'TimeComboBox.SelectedValue = DBNull.Value
            'TimeComboBox.SelectedIndex = -1
            'TimeComboBox.Text = String.Empty
            TimeComboBox.Text = String.Empty

            AssignedComboBox.SelectedValue = DBNull.Value
            AssignedComboBox.SelectedIndex = -1
            AssignedComboBox.Text = String.Empty

            DateDiscoveredFromTypeInDatePicker.Text = String.Empty
            DateDiscoveredToTypeInDatePicker.Text = String.Empty

            DueDateFromTypeInDatePicker.Text = String.Empty
            DueDateToTypeInDatePicker.Text = String.Empty

            AdDateFromTypeInDatePicker.Text = String.Empty
            AdDateToTypeInDatePicker.Text = String.Empty

            StatusComboBox.SelectedValue = DBNull.Value
            StatusComboBox.SelectedIndex = -1
            StatusComboBox.Text = String.Empty

            UrgencyComboBox.SelectedValue = DBNull.Value
            UrgencyComboBox.SelectedIndex = -1
            UrgencyComboBox.Text = String.Empty


            'If TaskLog
            ActionTypeComboBox.SelectedValue = DBNull.Value
            ActionTypeComboBox.SelectedIndex = -1
            ActionTypeComboBox.Text = String.Empty
            SpecificActionComboBox.SelectedValue = DBNull.Value
            SpecificActionComboBox.SelectedIndex = -1
            SpecificActionComboBox.Text = String.Empty
            PhoneTextBox.Text = String.Empty
            PersonTextBox.Text = String.Empty
            PersonNameTextBox.Text = String.Empty
            CommentsTextBox.Text = String.Empty

            'If Missing
            DateResolvedFromTypeInDatePicker.Text = String.Empty
            DateResolvedToTypeInDatePicker.Text = String.Empty
            RootCauseComboBox.SelectedValue = DBNull.Value
            RootCauseComboBox.SelectedIndex = -1
            RootCauseComboBox.Text = String.Empty
            StresolutionComboBox.SelectedValue = DBNull.Value
            StresolutionComboBox.SelectedIndex = -1
            StresolutionComboBox.Text = String.Empty
            LtresolutionComboBox.SelectedValue = DBNull.Value
            LtresolutionComboBox.SelectedIndex = -1
            LtresolutionComboBox.Text = String.Empty
            CommentsTextBox.Text = String.Empty
            'Comments2TextBox.Text = String.Empty
            'Comments3TextBox.Text = String.Empty
            vehicleDataGridView.DataSource = Nothing
            TimeComboBox.SelectedIndex = -1


        End Sub

        Private Sub searchButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchButton.Click

            If AreInputsValid() = False Then Exit Sub

            'MsgBox(DataParameter)
            LoadRecordsList()
            'For i As Integer = 0 To vehicleDataGridView.RowCount - 1
            '    vehicleDataGridView.Columns(0).Width = 15
            'Next
            'vehicleDataGridView.ClearSelection()
        End Sub

        Private Sub vehicleDataGridView_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles vehicleDataGridView.CellContentClick
            Dim searchId As Integer

            Dim tasklogId As Integer
            Dim missinglogId As Integer


            If vehicleDataGridView.Columns(e.ColumnIndex).HeaderText <> String.Empty Then Exit Sub

            If e.RowIndex < 0 OrElse e.RowIndex >= vehicleDataGridView.RowCount Then Exit Sub

            ' @ Omar Modified
            ' Add if/else here for report type
            If TaskLogRadioButton.Checked = True Then
                Dim vehicleStatusForm As UI.CCTasksLogForm
                If Integer.TryParse(vehicleDataGridView.Rows(e.RowIndex).Cells(vehicleDataGridView.Columns("CCTaskLogsId").Index).Value.ToString(), tasklogId) = False Then
                    tasklogId = -1
                End If

                tasklogId = CInt(vehicleDataGridView.Rows(e.RowIndex).Cells(vehicleDataGridView.Columns("CCTaskLogsId").Index).Value)
                searchId = tasklogId

                vehicleStatusForm = New UI.CCTasksLogForm()
                vehicleStatusForm.Init(FormStateEnum.View)
                vehicleStatusForm.StartPosition = FormStartPosition.CenterScreen
                vehicleStatusForm.ApplyUserCredentials()
                vehicleStatusForm.CreateTaskLogButton.Text = "Update"
                vehicleStatusForm.Show(Me)
                vehicleStatusForm.ShowVehicleInformation(searchId) ' inform
                vehicleStatusForm.Hide()
                vehicleStatusForm.ShowDialog(Me)
                vehicleStatusForm.Dispose()

                vehicleStatusForm = Nothing

            ElseIf MissingLogRadioButton.Checked = True Then
                Dim vehicleStatusForm As UI.MissingAdLogForm

                If Integer.TryParse(vehicleDataGridView.Rows(e.RowIndex).Cells(vehicleDataGridView.Columns("MissingAdId").Index).Value.ToString(), missinglogId) = False Then
                    missinglogId = -1
                End If


                missinglogId = CInt(vehicleDataGridView.Rows(e.RowIndex).Cells(vehicleDataGridView.Columns("MissingAdId").Index).Value)
                searchId = missinglogId

                vehicleStatusForm = New UI.MissingAdLogForm()
                vehicleStatusForm.Init(FormStateEnum.View)
                vehicleStatusForm.ApplyUserCredentials()
                vehicleStatusForm.CreateTaskLogButton.Text = "Update"
                vehicleStatusForm.Show(Me)
                vehicleStatusForm.ShowVehicleInformation(searchId) ' inform
                vehicleStatusForm.Hide()
                vehicleStatusForm.ShowDialog(Me)
                vehicleStatusForm.Dispose()
                vehicleStatusForm = Nothing
            End If

            LoadRecordsList()


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



#End Region


        Private Sub GenerateReport(ByVal reportForm As UI.ShowReportForm, ByVal dataSet As CoverageDataSet)
            Dim filterString As String
            filterString = " " 'Date Range: Between

            With reportForm
                .Parameters.Add("FilterString", filterString)

                If TaskLogRadioButton.Checked = True Then
                    .ReportFileResourceName = "MCAP.CCReports_TaskLogReport.rdlc"
                    '.ReportFilePath = Application.StartupPath + "\" + PackageExpectationReceivedReportFilePath
                    .DataSources.Add("CoverageDataSet_CCTaskLogsReports", dataSet.CCTaskLogsReports)
                    .ReportName = "CC Task Logs Report "
                    '.ExportReportToExcel("C:\\tempxlfile.xls")
                Else
                    .ReportFileResourceName = "MCAP.CCReports_MissingAdLogs.rdlc"
                    '.ReportFilePath = Application.StartupPath + "\" + PackageExpectationNotReceivedReportFilePath
                    .DataSources.Add("CoverageDataSet_CCMissingAdLogsReports", dataSet.CCMissingAdLogsReports)
                    .ReportName = "CC Missing Ad Log "
                    '.ExportReportToExcel("tempxlfile.xls")
                End If

                .PrepareReport()
                .RefreshReport()
                .WindowState = FormWindowState.Maximized
            End With

            Application.DoEvents()


        End Sub


        Private Sub TaskLogRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskLogRadioButton.CheckedChanged
            loadFormOptions()
        End Sub

        Private Sub MissingLogRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MissingLogRadioButton.CheckedChanged
            loadFormOptions()
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, _
            ByVal e As System.EventArgs) Handles ExportToExcelButton.Click

            Dim ds As CoverageDataSet
            Dim rptViewer As ShowReportForm
            ds = New CoverageDataSet()

            LoadRecordsList()

            'If vehicleDataGridView.RowCount < 1 Then
            '    MsgBox("Record list must be available in order to export ", MsgBoxStyle.OkOnly)
            '    Exit Sub
            'End If
            ' load dataset

            If TaskLogSelected Then
                LoadTaskLog(ds)
            Else
                LoadMissingAdLog(ds)
            End If

            'rptViewer = New ShowReportForm()
            'GenerateReport(rptViewer, ds)
            'rptViewer.PrepareReport()
            ExportReport()

            ds.Dispose()
            'rptViewer.Dispose()
            ds = Nothing
            rptViewer = Nothing

        End Sub

        Private Sub ExportReport()
            Dim temporaryFilePath As String
            Dim reportForm As ShowReportForm

            reportForm = New UI.ShowReportForm

            temporaryFilePath = System.IO.Path.GetTempFileName()
            CriteriaParameter()
            reportForm.Parameters.Add("FilterCriteria", FilterCriteria)
            If TaskLogRadioButton.Checked = True Then
                reportForm.ReportFileResourceName = "MCAP.CCSearchForm_TaskLog.rdlc"
                reportForm.DataSources.Add("CoverageDataSet_CCTaskLogsReports", _data.CCTaskLogsReports)
                reportForm.ReportName = "Coverage and Collection Task Log"
                reportForm.PrepareReport()
                reportForm.ExportReportToExcel(temporaryFilePath)
            Else
                reportForm.ReportFileResourceName = "MCAP.CCSearchForm_MissingAd.rdlc"
                reportForm.DataSources.Add("CoverageDataSet_CCMissingAdLogsReports", _data.CCMissingAdLogsReports)
                reportForm.ReportName = "Coverage and Collection Missing Ad Logs"
                reportForm.PrepareReport()
                reportForm.ExportReportToExcel(temporaryFilePath)
            End If

            temporaryFilePath = Nothing

        End Sub

        Private Sub CriteriaParameter()
            Dim filterCriteria As System.Text.StringBuilder


            filterCriteria = New System.Text.StringBuilder()


            If mediaComboBox.SelectedIndex >= 0 And mediaComboBox.Text <> "" Then
                filterCriteria.Append("Media: ")
                filterCriteria.Append(mediaComboBox.Text)
            End If
            If marketComboBox.SelectedIndex >= 0 And marketComboBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Market: ")
                filterCriteria.Append(marketComboBox.Text)
            End If
            If newspaperComboBox.SelectedIndex >= 0 And newspaperComboBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Newspaper: ")
                filterCriteria.Append(newspaperComboBox.Text)
            End If
            If retailerComboBox.SelectedIndex >= 0 And retailerComboBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Retailer: ")
                filterCriteria.Append(retailerComboBox.Text)
            End If
            If SenderComboBox.SelectedIndex >= 0 And SenderComboBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Sender: ")
                filterCriteria.Append(SenderComboBox.Text)
            End If
            If TimeComboBox.SelectedIndex >= 0 And TimeComboBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Time: ")
                filterCriteria.Append(TimeComboBox.Text)
            End If
            If AssignedComboBox.SelectedIndex >= 0 And AssignedComboBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Assigned: ")
                filterCriteria.Append(AssignedComboBox.Text)
            End If
            If StatusComboBox.SelectedIndex >= 0 And StatusComboBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Status: ")
                filterCriteria.Append(StatusComboBox.Text)
            End If
            If UrgencyComboBox.SelectedIndex >= 0 And UrgencyComboBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Urgency: ")
                filterCriteria.Append(UrgencyComboBox.Text)
            End If
            If RootCauseComboBox.SelectedIndex >= 0 And RootCauseComboBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Root Cause: ")
                filterCriteria.Append(RootCauseComboBox.Text)
            End If
            If StresolutionComboBox.SelectedIndex >= 0 And StresolutionComboBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("ST Resolution: ")
                filterCriteria.Append(StresolutionComboBox.Text)
            End If
            If LtresolutionComboBox.SelectedIndex >= 0 And LtresolutionComboBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("LT Resolution: ")
                filterCriteria.Append(LtresolutionComboBox.Text)
            End If
            If IsMissingComboBox.SelectedIndex >= 0 And IsMissingComboBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("IsMissing: ")
                filterCriteria.Append(IsMissingComboBox.Text)
            End If
            If IsFlashComboBox.SelectedIndex >= 0 And IsFlashComboBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("IsFlash: ")
                filterCriteria.Append(IsFlashComboBox.Text)
            End If
            If PhoneTextBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Phone: ")
                filterCriteria.Append(PhoneTextBox.Text)
            End If
            If PersonTextBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Person: ")
                filterCriteria.Append(PersonTextBox.Text)
            End If
            If ActionTypeComboBox.SelectedIndex >= 0 And ActionTypeComboBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Action Type: ")
                filterCriteria.Append(ActionTypeComboBox.Text)
            End If
            If SpecificActionComboBox.SelectedIndex >= 0 And SpecificActionComboBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Specific Action: ")
                filterCriteria.Append(SpecificActionComboBox.Text)
            End If
            If CommentsTextBox.Text <> "" Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Comments: ")
                filterCriteria.Append(CommentsTextBox.Text)
            End If
            If String.IsNullOrEmpty(DateDiscoveredFromTypeInDatePicker.Value.ToString) = False And String.IsNullOrEmpty(DateDiscoveredToTypeInDatePicker.Value.ToString) = False Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Date Discovered From: ")
                filterCriteria.Append(DateDiscoveredFromTypeInDatePicker.Value.ToString)
                filterCriteria.Append(" To: ")
                filterCriteria.Append(DateDiscoveredToTypeInDatePicker.Value.ToString)
            End If
            If String.IsNullOrEmpty(DueDateFromTypeInDatePicker.Value.ToString) = False And String.IsNullOrEmpty(DueDateToTypeInDatePicker.Value.ToString) = False Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Due Date From: ")
                filterCriteria.Append(DueDateFromTypeInDatePicker.Value.ToString)
                filterCriteria.Append(" To: ")
                filterCriteria.Append(DueDateToTypeInDatePicker.Value.ToString)
            End If
            If String.IsNullOrEmpty(AdDateFromTypeInDatePicker.Value.ToString) = False And String.IsNullOrEmpty(AdDateToTypeInDatePicker.Value.ToString) = False Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Ad Date From: ")
                filterCriteria.Append(AdDateFromTypeInDatePicker.Value.ToString)
                filterCriteria.Append(" To: ")
                filterCriteria.Append(AdDateToTypeInDatePicker.Value.ToString)
            End If
            If String.IsNullOrEmpty(DateResolvedFromTypeInDatePicker.Value.ToString) = False And String.IsNullOrEmpty(DateResolvedToTypeInDatePicker.Value.ToString) = False Then
                If filterCriteria.Length > 0 Then filterCriteria.Append(", ")
                filterCriteria.Append("Date Resolved: ")
                filterCriteria.Append(DateResolvedFromTypeInDatePicker.Value.ToString)
                filterCriteria.Append(" To: ")
                filterCriteria.Append(DateResolvedToTypeInDatePicker.Value.ToString)
            End If
            m_reportFilterCriteria = filterCriteria.ToString()

            filterCriteria.Remove(0, filterCriteria.Length)
            filterCriteria = Nothing

        End Sub

        Private Sub releaseObject(ByVal obj As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
                obj = Nothing
            Catch ex As Exception
                obj = Nothing
            Finally
                GC.Collect()
            End Try
        End Sub

        Private Sub LoadTaskLog(ByVal dataSet As CoverageDataSet)
            Dim adapter As CoverageDataSetTableAdapters.CCTaskLogsReportsTableAdapter
            Dim x As Integer
            adapter = New CoverageDataSetTableAdapters.CCTaskLogsReportsTableAdapter

            adapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            'x = dataSet.CCTaskLogsReports.Count
            'adapter.FillByReportSP(dataSet.CCTaskLogsReports, Time, DateDiscoveredFrom, DateDiscoveredTo, DueDateFrom, DueDateTo, Assigned, _
            'AdDateFrom, AdDateTo, retId, mktId, mediaId, senderId, publicationId, Status, Urgency, ActionType, SpecificAction, Phone, Person, PersonName, _
            'Comments, MissingAdId, UserId)

            adapter.FillByCCTLReport(dataSet.CCTaskLogsReports, _condition, "Task Logs")

            adapter.Dispose()
            adapter = Nothing
        End Sub

        Private Sub LoadMissingAdLog(ByVal dataSet As CoverageDataSet)

            Dim adapter As CoverageDataSetTableAdapters.CCMissingAdLogsReportsTableAdapter
            adapter = New CoverageDataSetTableAdapters.CCMissingAdLogsReportsTableAdapter
            adapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            'adapter.FillByReportSP(dataSet.CCMissingAdLogsReports, MissingAdId, DateDiscoveredFrom, DateDiscoveredTo, Time, DueDateFrom, DueDateTo, _
            'Assigned, ResolvedFrom, ResolvedTo, AdDateFrom, AdDateTo, retId, mktId, mediaId, senderId, publicationId, Status, _
            'Urgency, Flash, RootCause, Comments, Stresolution, Ltresolution, UserId)
            adapter.FillByCCMAReport(dataSet.CCMissingAdLogsReports, _condition, "Missing Ad Logs")
            adapter.Dispose()
            adapter = Nothing
        End Sub

        Private Sub ActionTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActionTypeComboBox.SelectedIndexChanged
            Dim actiontype As Integer

            If ActionTypeComboBox.SelectedValue Is Nothing Then
                actiontype = 0
            Else
                actiontype = CInt(ActionTypeComboBox.SelectedValue)
            End If
            OnActionTypeChanged(actiontype)
            SpecificActionComboBox.SelectedIndex = -1
        End Sub

        Protected Sub OnActionTypeChanged(ByVal actiontype As Integer)
            LoadSpecificAction(actiontype)
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Public Sub LoadSpecificAction(ByVal actiontype As Integer)

            Dim SpecificActionAdapter As CoverageDataSetTableAdapters.CCSpecificActionTableAdapter
            SpecificActionAdapter = New CoverageDataSetTableAdapters.CCSpecificActionTableAdapter
            SpecificActionAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            SpecificActionAdapter.Fill(_data.CCSpecificAction, actiontype)
            SpecificActionAdapter.Dispose()
            SpecificActionAdapter = Nothing

        End Sub

        Private Sub MarketComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles marketComboBox.KeyUp

            If e.KeyCode = Keys.Delete Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                LoadMedia()
                mediaComboBox.SelectedIndex = -1
                LoadMarkets()
                marketComboBox.SelectedIndex = -1
                LoadRetailers()
                retailerComboBox.SelectedIndex = -1
            End If

        End Sub

        Private Sub retailerComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles retailerComboBox.KeyUp

            If e.KeyCode = Keys.Delete Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                LoadMedia()
                mediaComboBox.SelectedIndex = -1
                LoadMarkets()
                marketComboBox.SelectedIndex = -1
                LoadRetailers()
                retailerComboBox.SelectedIndex = -1
            End If

        End Sub

        Private Sub MediaComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mediaComboBox.KeyUp

            If e.KeyCode = Keys.Delete Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                LoadMedia()
                mediaComboBox.SelectedIndex = -1
                LoadMarkets()
                marketComboBox.SelectedIndex = -1
                LoadRetailers()
                retailerComboBox.SelectedIndex = -1

            End If

        End Sub

        Private Sub senderComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SenderComboBox.KeyUp

            If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                LoadSender()
                SenderComboBox.SelectedIndex = -1
            End If

        End Sub

        Private Sub PublicationComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles newspaperComboBox.KeyUp

            If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                LoadNewspaper()
                newspaperComboBox.SelectedIndex = -1
            End If

        End Sub

        Private Sub StatusComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles StatusComboBox.KeyUp

            If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                LoadCCStatus("CCStatus")
                StatusComboBox.SelectedIndex = -1
            End If

        End Sub

        Private Sub UrgencyComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UrgencyComboBox.KeyUp

            If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                LoadCCUrgency("CCUrgency")
                UrgencyComboBox.SelectedIndex = -1
            End If

        End Sub

        Private Sub ActionTypeComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ActionTypeComboBox.KeyUp

            If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                LoadCCActionType("CCActionType")
                ActionTypeComboBox.SelectedIndex = -1
            End If

        End Sub

        Private Sub SpecificActionComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SpecificActionComboBox.KeyUp

            If e.KeyCode = Keys.F12 Then 'AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                'senderFilterButton.PerformClick()
                LoadCCSpecificAction("CCSpecificAction")
                SpecificActionComboBox.SelectedIndex = -1
            End If

        End Sub


        Private Sub AdDateFromTypeInDatePicker_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles AdDateFromTypeInDatePicker.Validating
            AdDateToTypeInDatePicker.Value = AdDateFromTypeInDatePicker.Value
        End Sub

        Private Sub DueDateFromTypeInDatePicker_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DueDateFromTypeInDatePicker.Validating
            DueDateToTypeInDatePicker.Value = DueDateFromTypeInDatePicker.Value
        End Sub

        Private Sub DateResolvedFromTypeInDatePicker_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateResolvedFromTypeInDatePicker.Validating
            DateResolvedToTypeInDatePicker.Value = DateResolvedFromTypeInDatePicker.Value
        End Sub

        Private Sub DateDiscoveredFromTypeInDatePicker_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DateDiscoveredFromTypeInDatePicker.Validating
            DateDiscoveredToTypeInDatePicker.Value = DateDiscoveredFromTypeInDatePicker.Value
        End Sub

        Private Sub CCSearchForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub
    End Class

End Namespace