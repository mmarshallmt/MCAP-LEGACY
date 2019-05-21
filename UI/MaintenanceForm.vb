﻿Imports System.Data.SqlClient

Namespace UI

    Public Class MaintenanceForm
        Implements IForm


        Private WithEvents m_maintenanceProcessor As Processors.Maintenance
        Private m_isFiltered As Boolean
        Private _IsLoading As Boolean = True
        Private _med As Integer = 0
        Private _mkt As Integer = 0
        Private _ret As Integer = 0
        Private _senderID As Integer = 0
        Private _MediaDesc As String
        Private _MktDesc As String
        Private _RetDesc As String
        Private _sendername As String
        Private _oSenderId As Integer
        Private _oExpectaionId As Integer
        Private _IsEdit As Boolean = False

        Private IsFilter As Boolean = False
        Private IsComboLoaded As Boolean = False

        Private _ValueOneValueMember As Integer
        Private _ValueTwoValueMember As Integer
        Private _ValueOneDisplay As String
        Private _ValueTwoDisplay As String
        Private _DataRefresh As Boolean = False
        Private _InsertStatus As Boolean = False

        Private senderIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Private expIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Private medIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Private mktIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Private retIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn

        Private orig_media As String
        Private orig_mkt As String
        Private orig_ret As String
        Private orig_sender As String
        Private previousRow As Integer
        Private IsThereANull As Boolean = False
        Private ColName As String
        Private filterConditionTemp As String
        Private currentIndex As Integer
        Private mArray As New List(Of List(Of String))

        Private ReadOnly Property Processor() As Processors.Maintenance
            Get
                Return m_maintenanceProcessor
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

            m_maintenanceProcessor = New Processors.Maintenance()
            Processor.Initialize()
            Processor.LoadDataSet()

            editTableGroupBox.Text = String.Empty
            logicalOperatorsComboBox.SelectedIndex = 0
            maintenanceDataGridView.AutoGenerateColumns = False
            RaiseEvent FormInitialized()

            Me.ResumeLayout()

        End Sub


#End Region

#Region " Methods to Prepare DataGridView for various tables. "
        Private Sub PrepareGridForSiteTable()

            'RetId (show Ret table where enddt is null.  Order by Descrip)
            'ForceRunInd(0 Or 1)
            'GetImagesManually(0 Or 1)
            'ActiveInd(0 Or 1)

            Dim SiteIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim NameTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim AddressTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim CityTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim StateTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim ZipTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim DefaultRetIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim DefaultMktIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim RegionRetIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn

            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)

            maintenanceDataGridView.SuspendLayout()

            SiteIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            NameTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            AddressTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            CityTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            StateTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            ZipTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            DefaultRetIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            DefaultMktIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            RegionRetIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                            {SiteIdTextBoxColumn, NameTextBoxColumn, _
                                                AddressTextBoxColumn, CityTextBoxColumn, _
                                                StateTextBoxColumn, ZipTextBoxColumn, _
                                                DefaultRetIdComboBoxColumn, DefaultMktIdComboBoxColumn, _
                                                RegionRetIdComboBoxColumn})
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0
            'constraintsRow = From r In Processor.Data.COLUMNS _
            '                 Where r.Column_Name.ToUpper() = "SITEID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
            '                 Select r
            With SiteIdTextBoxColumn
                .ReadOnly = False
                .HeaderText = "Site Id"
                .Name = "SiteIdTextBoxColumn"
                .DataPropertyName = "SiteId"
                '.DisplayMember = "Descrip"
                '.ValueMember = "RetId"
                '.DataSource = Processor.Data.Site
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            With NameTextBoxColumn
                .ReadOnly = False
                .HeaderText = "Name"
                .Name = "NameTextBoxColumn"
                .DataPropertyName = "Name"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            With AddressTextBoxColumn
                .ReadOnly = False
                .HeaderText = "Address"
                .Name = "AddressTextBoxColumn"
                .DataPropertyName = "Address"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            'constraintsRow = From r In Processor.Data.COLUMNS _
            '                 Where r.Column_Name.ToUpper() = "CITY" AndAlso r.Is_Nullable.ToUpper() = "NO" _
            '                 Select r
            With CityTextBoxColumn
                .ReadOnly = False
                .HeaderText = "City"
                .Name = "CityComboBoxColumn"
                .DataPropertyName = "City"
                '.DisplayMember = "Descrip"
                '.ValueMember = "RetId"
                '.DataSource = Processor.Data.RetailerList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            'constraintsRow = From r In Processor.Data.COLUMNS _
            '                 Where r.Column_Name.ToUpper() = "RETID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
            '                 Select r
            With StateTextBoxColumn
                .HeaderText = "State"
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "StateComboBoxColumn"
                .DataPropertyName = "State"
                '.DisplayMember = "Descrip"
                '.ValueMember = "RetId"
                '.DataSource = Processor.Data.RetailerList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            With ZipTextBoxColumn
                .ReadOnly = False
                .HeaderText = "Zip"
                .Name = "ZipTextBoxColumn"
                .DataPropertyName = "Zip"
                '.DisplayMember = "IdColumn"
                '.ValueMember = "IdValue"
                '.DataSource = Processor.Data.WebsitePageDownloadValues
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "RETID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With DefaultRetIdComboBoxColumn
                .ReadOnly = False
                .HeaderText = "DefaultRetId"
                .Name = "DefaultRetIdComboBoxColumn"
                .DataPropertyName = "DefaultRetId"
                .DisplayMember = "Descrip"
                .ValueMember = "RetId"
                .DataSource = Processor.Data.RetailerList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "MKTID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With DefaultMktIdComboBoxColumn
                .ReadOnly = False
                .HeaderText = "DefaultMktId"
                .Name = "DefaultMktIdComboBoxColumn"
                .DataPropertyName = "DefaultMktId"
                .DisplayMember = "Descrip"
                .ValueMember = "MktId"
                .DataSource = Processor.Data.MarketList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With


            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "RETID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With RegionRetIdComboBoxColumn
                .ReadOnly = False
                .HeaderText = "RegionRetId"
                .Name = "RegionRetIdComboBoxColumn"
                .DataPropertyName = "RegionRetId"
                .DisplayMember = "Descrip"
                .ValueMember = "RetId"
                .DataSource = Processor.Data.RetailerList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.DataSource = Processor.Data.Site

            constraintsRow = Nothing

            SiteIdTextBoxColumn = Nothing
            NameTextBoxColumn = Nothing
            AddressTextBoxColumn = Nothing
            CityTextBoxColumn = Nothing
            StateTextBoxColumn = Nothing
            ZipTextBoxColumn = Nothing
            DefaultRetIdComboBoxColumn = Nothing
            DefaultMktIdComboBoxColumn = Nothing
            RegionRetIdComboBoxColumn = Nothing


            maintenanceDataGridView.ResumeLayout(False)

        End Sub

        Private Sub PrepareGridForWebsiteTable()

            'RetId (show Ret table where enddt is null.  Order by Descrip)
            'ForceRunInd(0 Or 1)
            'GetImagesManually(0 Or 1)
            'ActiveInd(0 Or 1)

            'WebsitePageDownloadId()
            Dim PageNameTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim OrderValueTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim URLTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim ActiveIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim RetIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim lastDownloadDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim MultipleTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim DelayTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim DayRunTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim ForceRunIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim GetImagesManuallyIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim DefaultStatusIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim CaptureDelayDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim DefaultPageTypeIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim FrequencyIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim WebsitePageDownloadTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)

            maintenanceDataGridView.SuspendLayout()

            PageNameTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            OrderValueTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            URLTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            ActiveIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            RetIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            lastDownloadDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn
            MultipleTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            DelayTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            DayRunTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            'ForceRunIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            GetImagesManuallyIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            DefaultStatusIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            CaptureDelayDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn
            DefaultPageTypeIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            FrequencyIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            WebsitePageDownloadTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                            {RetIdComboBoxColumn, ActiveIndComboBoxColumn, _
                                                GetImagesManuallyIndComboBoxColumn, _
                                                PageNameTextBoxColumn, OrderValueTextBoxColumn, URLTextBoxColumn, _
                                                lastDownloadDtCalendarColumn, _
                                                MultipleTextBoxColumn, DelayTextBoxColumn, DayRunTextBoxColumn, _
                                                CaptureDelayDtCalendarColumn, DefaultStatusIdTextBoxColumn, _
                                                DefaultPageTypeIdComboBoxColumn, FrequencyIdComboBoxColumn, WebsitePageDownloadTextBoxColumn})
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0
            With PageNameTextBoxColumn
                .ReadOnly = False
                .HeaderText = "Page Name"
                .Name = "PageNameTextBoxColumn"
                .DataPropertyName = "PageName"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            With OrderValueTextBoxColumn
                .ReadOnly = False
                .HeaderText = "Order Value"
                .Name = "OrderValueTextBoxColumn"
                .DataPropertyName = "OrderValue"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            With URLTextBoxColumn
                .ReadOnly = True
                .HeaderText = "URL"
                .Name = "URLTextBoxColumn"
                .DataPropertyName = "URL"
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                '.Resizable = DataGridViewTriState.False
                '.Width = 80
                .DefaultCellStyle.NullValue = "   ...                  "
                .MaxInputLength = 100
                '.MinimumWidth = 50
                '.FillWeight = 100
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            'constraintsRow = From r In Processor.Data.COLUMNS _
            '                 Where r.Column_Name.ToUpper() = "RETID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
            '                 Select r
            'With RetIdComboBoxColumn
            '    .ReadOnly = False
            '    .HeaderText = "RetId"
            '    If constraintsRow.Count() > 0 Then _
            '    .Name = "RetIdComboBoxColumn"
            '    .DisplayMember = "Descrip"
            '    .ValueMember = "RetId"
            '    .DataSource = Processor.Data.RetailerList
            'End With
            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "RETID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With RetIdComboBoxColumn
                .HeaderText = "Retailer"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "RetIdComboBoxColumn"
                .DataPropertyName = "RetId"
                .DisplayMember = "Descrip"
                .ValueMember = "RetId"
                .DataSource = Processor.Data.RetailerList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ACTIVEIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With ActiveIndComboBoxColumn
                .ReadOnly = False
                .HeaderText = "ActiveInd"
                .Name = "ActiveIndComboBoxColumn"
                .DataPropertyName = "ActiveInd"
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.WebsitePageDownloadValues
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            With lastDownloadDtCalendarColumn
                .ReadOnly = False
                .HeaderText = "lastDownloadDt"
                .Name = "lastDownloadDtCalendarColumn"
                .DataPropertyName = "lastDownloadDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            With MultipleTextBoxColumn
                .ReadOnly = False
                .HeaderText = "Multiple"
                .Name = "MultipleTextBoxColumn"
                .DataPropertyName = "Multiple"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            With DelayTextBoxColumn
                .ReadOnly = False
                .HeaderText = "Delay"
                .Name = "DelayTextBoxColumn"
                .DataPropertyName = "Delay"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            With DayRunTextBoxColumn
                .ReadOnly = False
                .HeaderText = "DayRun"
                .Name = "DayRunTextBoxColumn"
                .DataPropertyName = "DayRun"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            'constraintsRow = From r In Processor.Data.COLUMNS _
            '                 Where r.Column_Name.ToUpper() = "FORCERUNIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
            '                 Select r

            'With ForceRunIndComboBoxColumn
            '    .ReadOnly = False
            '    .HeaderText = "ForceRunInd"
            '    .Name = "ForceRunIndComboBoxColumn"
            '    .DataPropertyName = "ForceRunInd"
            '    .DisplayMember = "IdColumn"
            '    .ValueMember = "IdValue"
            '    .DataSource = Processor.Data.WebsitePageDownloadValues
            'End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "GETIMAGESMANUALLYIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With GetImagesManuallyIndComboBoxColumn
                .ReadOnly = False
                .HeaderText = "Get Images Manually"
                .Name = "GetImagesManuallyIndComboBoxColumn"
                .DataPropertyName = "GetImagesManuallyInd"
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.WebsitePageDownloadValues
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            With DefaultStatusIdTextBoxColumn
                .ReadOnly = False
                .HeaderText = "Default Status Id"
                .Name = "DefaultStatusIdTextBoxColumn"
                .DataPropertyName = "DefaultStatusId"
                '.Visible = False
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With


            With CaptureDelayDtCalendarColumn
                .ReadOnly = False
                .HeaderText = "CaptureDelayDt"
                .Name = "CaptureDelayDtCalendarColumn"
                .DataPropertyName = "CaptureDelayDt"
                '.Visible = False
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "DEFAULTPAGETYPEID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With DefaultPageTypeIdComboBoxColumn
                .ReadOnly = False
                .HeaderText = "Default PageType"
                .Name = "DefaultPageTypeIdComboBoxColumn"
                .DataPropertyName = "DefaultPageTypeId"
                .DisplayMember = "Descrip"
                .ValueMember = "PageTypeId"
                .DataSource = Processor.Data.PageType
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "FREQUENCYID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With FrequencyIdComboBoxColumn
                .ReadOnly = False
                .HeaderText = "FrequencyId "
                .Name = "FrequencyIdComboBoxColumn"
                .DataPropertyName = "FrequencyId"
                .DisplayMember = "Descrip"
                .ValueMember = "CodeId"
                .DataSource = Processor.Data.PageDownloadFrequency
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            With WebsitePageDownloadTextBoxColumn
                .ReadOnly = False
                .HeaderText = ""
                .Name = "WebsitePageDownloadTextBoxColumn"
                .DataPropertyName = "WebsitePageDownloadId"
                .Visible = False
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            maintenanceDataGridView.DataSource = Processor.Data.WebsitePageDownload

            constraintsRow = Nothing

            PageNameTextBoxColumn = Nothing
            RetIdComboBoxColumn = Nothing
            OrderValueTextBoxColumn = Nothing
            ActiveIndComboBoxColumn = Nothing
            DelayTextBoxColumn = Nothing
            DayRunTextBoxColumn = Nothing
            ForceRunIndComboBoxColumn = Nothing
            GetImagesManuallyIndComboBoxColumn = Nothing
            DefaultStatusIdTextBoxColumn = Nothing
            lastDownloadDtCalendarColumn = Nothing
            CaptureDelayDtCalendarColumn = Nothing
            GetImagesManuallyIndComboBoxColumn = Nothing
            DefaultPageTypeIdComboBoxColumn = Nothing
            FrequencyIdComboBoxColumn = Nothing

            maintenanceDataGridView.ResumeLayout(False)

        End Sub

        Private Sub PrepareGridForExpectationTable()
            Dim expectationIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim retIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim mktIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim mediaIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim frequencyIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim startDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim endDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim priorityTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim commentsTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim missingAdCommentsTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim scandpiComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim IndAutoQCComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)

            Dim fvReqIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim adReqIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn

            Dim fventry360IndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim adentry360IndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim CoverageTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

            Dim AdDynReqIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim AdSmtReqIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn


            Dim ScanReqIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim FsiIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim jaAlcIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim jaAlcMIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim jaAlcVIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim jaallIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim jaAllMIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim jaAllVIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim jaasmIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim jabevIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim jacanIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim jafrVIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim jaHSPeIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim jaspanIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim jaHSPsIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim jalnetIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim jamassIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim emailComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim ROPPageNameIndComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            IndAutoQCComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()


            maintenanceDataGridView.SuspendLayout()

            expectationIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            retIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            mktIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            mediaIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            frequencyIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            startDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
            endDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
            priorityTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            commentsTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            missingAdCommentsTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            scandpiComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()

            fvReqIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            adReqIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            CoverageTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()

            fventry360IndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            adentry360IndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            AdDynReqIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            AdSmtReqIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            ScanReqIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            FsiIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            jaAlcIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            jaAlcMIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            jaAlcVIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            jaallIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            jaAllMIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            jaAllVIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            jaasmIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            jabevIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            jacanIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            jafrVIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            jaHSPeIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            jaspanIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            jaHSPsIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            jalnetIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            jamassIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            emailComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            ROPPageNameIndComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()


            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                          {expectationIdTextBoxColumn, retIdComboBoxColumn _
                                                          , mktIdComboBoxColumn, mediaIdComboBoxColumn _
                                                          , priorityTextBoxColumn, frequencyIdComboBoxColumn _
                                                          , startDtCalendarColumn, endDtCalendarColumn _
                                                          , commentsTextBoxColumn, missingAdCommentsTextBoxColumn _
                                                          , scandpiComboBoxColumn, fvReqIndComboBoxColumn _
                                                          , adReqIndComboBoxColumn, CoverageTextBoxColumn, fventry360IndComboBoxColumn _
                                                          , adentry360IndComboBoxColumn, AdDynReqIndComboBoxColumn _
                                                          , AdSmtReqIndComboBoxColumn, ScanReqIndComboBoxColumn _
                                                          , FsiIndComboBoxColumn, jaAlcIndComboBoxColumn _
                                                          , jaAlcMIndComboBoxColumn, jaAlcVIndComboBoxColumn _
                                                          , jaallIndComboBoxColumn, jaAllMIndComboBoxColumn _
                                                          , jaAllVIndComboBoxColumn, jaasmIndComboBoxColumn _
                                                          , jabevIndComboBoxColumn, jacanIndComboBoxColumn _
                                                          , jafrVIndComboBoxColumn, jaHSPeIndComboBoxColumn _
                                                          , jaspanIndComboBoxColumn, jaHSPsIndComboBoxColumn _
                                                          , jalnetIndComboBoxColumn, jamassIndComboBoxColumn _
                                                          , emailComboBoxColumn, ROPPageNameIndComboBoxColumn _
                                                          , IndAutoQCComboBoxColumn})



            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0

            'Try
            With expectationIdTextBoxColumn
                .ReadOnly = True
                .HeaderText = "Expectation Id"
                .Name = "ExpectationIdTextBoxColumn"
                .DataPropertyName = "ExpectationId"
                '.Visible = False
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "RETID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With retIdComboBoxColumn
                .HeaderText = "Retailer"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "RetIdComboBoxColumn"
                .DataPropertyName = "RetId"
                .DisplayMember = "Descrip"
                .ValueMember = "RetId"
                .DataSource = Processor.Data.RetailerList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "MKTID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With mktIdComboBoxColumn
                .HeaderText = "Market"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "MktIdComboBoxColumn"
                .DataPropertyName = "MktId"
                .DisplayMember = "Descrip"
                .ValueMember = "MktId"
                .DataSource = Processor.Data.MarketList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "MEDIAID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With mediaIdComboBoxColumn
                .HeaderText = "Media"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "MediaIdComboBoxColumn"
                .DataPropertyName = "MediaId"
                .DisplayMember = "Descrip"
                .ValueMember = "MediaId"
                .DataSource = Processor.Data.MediaList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "PRIORITY" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With priorityTextBoxColumn
                .HeaderText = "Priority"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "priorityTextBoxColumn"
                .DataPropertyName = "Priority"
                .MaxInputLength = 4
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "FREQUENCYID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With frequencyIdComboBoxColumn
                .HeaderText = "Frequency"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "FrequencyIdComboBoxColumn"
                .DataPropertyName = "FrequencyId"
                .DisplayMember = "Descrip"
                .ValueMember = "CodeId"
                .DataSource = Processor.Data.vwFrequency
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "STARTDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With startDtCalendarColumn
                .HeaderText = "Start Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "startDtCalendarColumn"
                .DataPropertyName = "startDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ENDDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With endDtCalendarColumn
                .HeaderText = "End Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "endDtCalendarColumn"
                .DataPropertyName = "endDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "COMMENTS" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With commentsTextBoxColumn
                .HeaderText = "Comments"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "commentsTextBoxColumn"
                .DataPropertyName = "Comments"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With
            '.MaxInputLength = Processor.Data.Expectation.CommentsColumn.MaxLength

            ' START OF OMAR CHANGES
            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "FVREQIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With fvReqIndComboBoxColumn
                .HeaderText = "Required for FV"
                If constraintsRow.Count() > 0 Then _
                .Name = "fvReqIndComboBoxColumn"
                .DataPropertyName = "FVReqInd"
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With


            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ADREQIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With adReqIndComboBoxColumn
                .HeaderText = "ADREQIND"
                If constraintsRow.Count() > 0 Then _
                .Name = "adReqIndComboBoxColumn"
                .DataPropertyName = "ADReqInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                            Where r.Column_Name.ToUpper() = "Coverage" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                            Select r
            With CoverageTextBoxColumn
                .HeaderText = "Coverage"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "CoverageTextBoxColumn"
                .DataPropertyName = "Coverage"
                .MaxInputLength = 4
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                  Where r.Column_Name.ToUpper() = "FVENTRY360IND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                  Select r
            With fventry360IndComboBoxColumn
                .HeaderText = "FVEntry360Ind"
                If constraintsRow.Count() > 0 Then _
                .Name = "fvEntry360IndComboBoxColumn"
                .DataPropertyName = "FVEntry360Ind"
                '.ValueType = System.Type.GetType("System.byte")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ADENTRY360IND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With adentry360IndComboBoxColumn
                .HeaderText = "ADEntry360IND"
                If constraintsRow.Count() > 0 Then _
                .Name = "adEntry360IndComboBoxColumn"
                .DataPropertyName = "ADEntry360Ind"
                '.ValueType = System.Type.GetType("System.byte")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "MISSINGADCOMMENTS" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With missingAdCommentsTextBoxColumn
                .HeaderText = "Missing Ad Comments"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "missingAdCommentsTextBoxColumn"
                .DataPropertyName = "MissingAdComments"
                .MaxInputLength = Processor.Data.Expectation.MissingAdCommentsColumn.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "SCANDPI" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With scandpiComboBoxColumn
                .HeaderText = "Scan DPI"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "scandpiComboBoxColumn"
                .DataPropertyName = "ScanDPI"
                .DisplayMember = "Descrip"
                .ValueMember = "Descrip"
                .DataSource = Processor.Data.vwScanDPI
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ADDYNREQIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With AdDynReqIndComboBoxColumn
                .HeaderText = "AdDynReqInd"
                If constraintsRow.Count() > 0 Then _
                .Name = "AdDynReqIndComboBoxColumn"
                .ValueType = System.Type.GetType("System.Int32")
                .DataPropertyName = "AdDynReqInd"
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ADSMTREQIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With AdSmtReqIndComboBoxColumn
                .HeaderText = "AdSmtReqInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "AdSmtReqIndColumn"
                .DataPropertyName = "AdSmtReqInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With


            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "SCANREQIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With ScanReqIndComboBoxColumn
                .HeaderText = "ScanReqInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "ScanReqIndColumn"
                .DataPropertyName = "ScanReqInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "FSIIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With FsiIndComboBoxColumn
                .HeaderText = "FSI IND"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "FsiIndColumn"
                .DataPropertyName = "FsiInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                        Where r.Column_Name.ToUpper() = "JAALCIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                        Select r
            With jaAlcIndComboBoxColumn
                .HeaderText = "jaAlcInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "jaAlcIndColumn"
                .DataPropertyName = "jaAlcInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                        Where r.Column_Name.ToUpper() = "JAALCMIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                        Select r
            With jaAlcMIndComboBoxColumn
                .HeaderText = "jaAlcMInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "jaAlcMIndColumn"
                .DataPropertyName = "jaAlcMInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                        Where r.Column_Name.ToUpper() = "JAALCVIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                        Select r
            With jaAlcVIndComboBoxColumn
                .HeaderText = "jaAlcVInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "jaAlcVIndColumn"
                .DataPropertyName = "jaAlcVInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                        Where r.Column_Name.ToUpper() = "JAALLIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                        Select r
            With jaallIndComboBoxColumn
                .HeaderText = "jaallInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "jaallIndColumn"
                .DataPropertyName = "jaallInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                        Where r.Column_Name.ToUpper() = "JACANIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                        Select r
            With jacanIndComboBoxColumn
                .HeaderText = "jacanInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "jacanIndColumn"
                .DataPropertyName = "jacanInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                        Where r.Column_Name.ToUpper() = "JAFRVIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                        Select r
            With jafrVIndComboBoxColumn
                .HeaderText = "jafRvInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "jafRvIndColumn"
                .DataPropertyName = "jafRvInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                        Where r.Column_Name.ToUpper() = "JAHSPEIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                        Select r
            With jaHSPeIndComboBoxColumn
                .HeaderText = "jaHSPeInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "jaHSPeIndColumn"
                .DataPropertyName = "jaHSPeInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                        Where r.Column_Name.ToUpper() = "JAHSPSIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                        Select r
            With jaHSPsIndComboBoxColumn
                .HeaderText = "jaHSPsInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "jaHSPsIndColumn"
                .DataPropertyName = "jaHSPsInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                        Where r.Column_Name.ToUpper() = "JALNETIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                        Select r
            With jalnetIndComboBoxColumn
                .HeaderText = "jalnetInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "jalnetIndColumn"
                .DataPropertyName = "jalnetInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                        Where r.Column_Name.ToUpper() = "JAMASSIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                        Select r
            With jamassIndComboBoxColumn
                .HeaderText = "jamassInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "jamassIndColumn"
                .DataPropertyName = "jamassInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                        Where r.Column_Name.ToUpper() = "JASPANIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                        Select r
            With jaspanIndComboBoxColumn
                .HeaderText = "jaspanInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "jaspanIndColumn"
                .DataPropertyName = "jaspanInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                        Where r.Column_Name.ToUpper() = "JAASMIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                        Select r
            With jaasmIndComboBoxColumn
                .HeaderText = "jaasMInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "jaasMIndColumn"
                .DataPropertyName = "jaasMInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                        Where r.Column_Name.ToUpper() = "JABEVIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                        Select r
            With jabevIndComboBoxColumn
                .HeaderText = "jabeVInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "jabeVIndColumn"
                .DataPropertyName = "jabeVInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                        Where r.Column_Name.ToUpper() = "JAALLMIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                        Select r
            With jaAllMIndComboBoxColumn
                .HeaderText = "jaAllMInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "jaAllMIndColumn"
                .DataPropertyName = "jaAllMInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                        Where r.Column_Name.ToUpper() = "JAALLMIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                        Select r
            With jaAllVIndComboBoxColumn
                .HeaderText = "jaAllVInd"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "jaAllVIndColumn"
                .DataPropertyName = "jaAllVInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                                        Where r.Column_Name.ToUpper() = "EMAIL" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                        Select r
            With emailComboBoxColumn
                .HeaderText = "email"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "emailColumn"
                .DataPropertyName = "email"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ROPPAGENAMEIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r

            With ROPPageNameIndComboBoxColumn
                .HeaderText = "ROPPageNameInd"
                If constraintsRow.Count() > 0 Then _
                .Name = "ROPPageNameIndComboBoxColumn"
                .DataPropertyName = "ROPPageNameInd"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                Where r.Column_Name.ToUpper() = "INDAUTOQC" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                    Select r

            With IndAutoQCComboBoxColumn
                .ReadOnly = False
                .HeaderText = "IndAutoQC"
                .DataPropertyName = "IndAutoQC"
                .Name = "IndAutoQCComboBoxColumn"
                .ValueType = System.Type.GetType("System.Int32")
                .DisplayMember = "IdColumn"
                .ValueMember = "IdValue"
                .DataSource = Processor.Data.ExpectationProjectVals
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With
            'Catch EX As Exception

            'End Try
            Processor.Data.Expectation.Columns("FVEntry360Ind").DataType = GetType(Int32)
            Processor.Data.Expectation.Columns("adEntry360Ind").DataType = GetType(Int32)
            maintenanceDataGridView.DataSource = Processor.Data.Expectation

            expectationIdTextBoxColumn = Nothing
            retIdComboBoxColumn = Nothing
            mktIdComboBoxColumn = Nothing
            mediaIdComboBoxColumn = Nothing
            frequencyIdComboBoxColumn = Nothing
            startDtCalendarColumn = Nothing
            endDtCalendarColumn = Nothing
            priorityTextBoxColumn = Nothing
            commentsTextBoxColumn = Nothing
            fvReqIndComboBoxColumn = Nothing
            adReqIndComboBoxColumn = Nothing
            CoverageTextBoxColumn = Nothing
            fventry360IndComboBoxColumn = Nothing
            adentry360IndComboBoxColumn = Nothing
            missingAdCommentsTextBoxColumn = Nothing
            scandpiComboBoxColumn = Nothing
            constraintsRow = Nothing
            AdDynReqIndComboBoxColumn = Nothing
            AdSmtReqIndComboBoxColumn = Nothing
            ScanReqIndComboBoxColumn = Nothing
            FsiIndComboBoxColumn = Nothing
            jaAlcIndComboBoxColumn = Nothing
            jaAlcMIndComboBoxColumn = Nothing
            jaAlcVIndComboBoxColumn = Nothing
            jaallIndComboBoxColumn = Nothing
            jaAllMIndComboBoxColumn = Nothing
            jaAllVIndComboBoxColumn = Nothing
            jaasmIndComboBoxColumn = Nothing
            jabevIndComboBoxColumn = Nothing
            jacanIndComboBoxColumn = Nothing
            jafrVIndComboBoxColumn = Nothing
            jaHSPeIndComboBoxColumn = Nothing
            jaHSPsIndComboBoxColumn = Nothing
            jalnetIndComboBoxColumn = Nothing
            jamassIndComboBoxColumn = Nothing
            jaspanIndComboBoxColumn = Nothing
            emailComboBoxColumn = Nothing
            ROPPageNameIndComboBoxColumn = Nothing

            maintenanceDataGridView.ResumeLayout(False)

        End Sub

        Private Sub PrepareGridForLanguageTable()
            Dim languageIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim descripTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)


            maintenanceDataGridView.SuspendLayout()

            languageIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            descripTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                        {languageIdTextBoxColumn, descripTextBoxColumn})
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0
            With languageIdTextBoxColumn
                .ReadOnly = True
                .HeaderText = "Language Id"
                .Name = "languageIdTextBoxColumn"
                .DataPropertyName = "LanguageId"
                '.Visible = False
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "DESCRIP" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With descripTextBoxColumn
                .HeaderText = "Language Name"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "descripTextBoxColumn"
                .DataPropertyName = "Descrip"
                .MaxInputLength = Processor.Data.Language.DescripColumn.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            maintenanceDataGridView.DataSource = Processor.Data.Language

            languageIdTextBoxColumn = Nothing
            descripTextBoxColumn = Nothing
            constraintsRow = Nothing

            maintenanceDataGridView.ResumeLayout(False)

        End Sub

        Private Sub PrepareGridForMediaTable()

            Dim mediaIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim descripTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim displayComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim startDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim endDtCalendarColumn As MCAP.UI.Controls.CalendarColumn

            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)


            maintenanceDataGridView.SuspendLayout()

            mediaIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            descripTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            displayComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            startDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
            endDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn()

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                        {mediaIdTextBoxColumn, descripTextBoxColumn, displayComboBoxColumn, startDtCalendarColumn, endDtCalendarColumn})
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0
            With mediaIdTextBoxColumn
                .ReadOnly = True
                .HeaderText = "Media Id"
                .Name = "mediaIdTextBoxColumn"
                .DataPropertyName = "MediaId"
                '.Visible = False
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "DESCRIP" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With descripTextBoxColumn
                .HeaderText = "Media Name"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "descripTextBoxColumn"
                .DataPropertyName = "Descrip"
                .MaxInputLength = Processor.Data.Media.DescripColumn.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                          Where r.Column_Name.ToUpper() = "IndDisplayValue" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                          Select r

            With displayComboBoxColumn
                .HeaderText = "Display"
                .Name = "displayComboBoxColumn"
                .DataPropertyName = "IndDisplayValue"
                .DisplayMember = "Descrip"
                .ValueMember = "codeid"
                .DataSource = Processor.Data.NeedTrackingNo
                '.Visible = False
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                  Where r.Column_Name.ToUpper() = "STARTDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                  Select r
            With startDtCalendarColumn
                .HeaderText = "Start Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "startDtCalendarColumn"
                .DataPropertyName = "startDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ENDDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With endDtCalendarColumn
                .HeaderText = "End Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "endDtCalendarColumn"
                .DataPropertyName = "endDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            maintenanceDataGridView.DataSource = Processor.Data.Media

            mediaIdTextBoxColumn = Nothing
            descripTextBoxColumn = Nothing
            constraintsRow = Nothing

            maintenanceDataGridView.ResumeLayout(False)

        End Sub

        Private Sub PrepareGridForRetTable()
            Dim retIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim descripTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim tradeclassIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim startDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim endDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim priorityTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim languageComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim CommentTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)


            maintenanceDataGridView.SuspendLayout()

            retIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            descripTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            tradeclassIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            priorityTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            languageComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            startDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
            endDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
            CommentTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                     {retIdTextBoxColumn, descripTextBoxColumn _
                                                      , tradeclassIdComboBoxColumn, languageComboBoxColumn _
                                                      , priorityTextBoxColumn, CommentTextBoxColumn, startDtCalendarColumn _
                                                      , endDtCalendarColumn})
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0
            With retIdTextBoxColumn
                .ReadOnly = True
                .HeaderText = "Retailer Id"
                .Name = "retIdTextBoxColumn"
                .DataPropertyName = "RetId"
                '.Visible = False
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "DESCRIP" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With descripTextBoxColumn
                .HeaderText = "Retailer Name"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "descripTextBoxColumn"
                .DataPropertyName = "Descrip"
                .MaxInputLength = Processor.Data.Ret.DescripColumn.MaxLength
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "TRADECLASSID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With tradeclassIdComboBoxColumn
                .HeaderText = "Tradeclass"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "tradeclassIdComboBoxColumn"
                .DataPropertyName = "TradeclassId"
                .DisplayMember = "Descrip"
                .ValueMember = "TradeclassId"
                .DataSource = Processor.Data.TradeClassList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "LANGUAGEID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With languageComboBoxColumn
                .HeaderText = "Language"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "languageComboBoxColumn"
                .DataPropertyName = "LanguageId"
                .DisplayMember = "Descrip"
                .ValueMember = "LanguageId"
                .DataSource = Processor.Data.Language
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "PRIORITY" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With priorityTextBoxColumn
                .HeaderText = "Priority"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "priorityTextBoxColumn"
                .DataPropertyName = "Priority"
                .MaxInputLength = 4
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                            Where r.Column_Name.ToUpper() = "COMMENT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                            Select r
            With CommentTextBoxColumn
                .HeaderText = "Comment"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "CommentTextBoxColumn"
                .DataPropertyName = "Comment"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "STARTDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With startDtCalendarColumn
                .HeaderText = "Start Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "startDtCalendarColumn"
                .DataPropertyName = "startDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ENDDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With endDtCalendarColumn
                .HeaderText = "End Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "endDtCalendarColumn"
                .DataPropertyName = "endDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            Processor.Data.Ret.Columns("LanguageId").SetOrdinal(3)
            maintenanceDataGridView.DataSource = Processor.Data.Ret

            retIdTextBoxColumn = Nothing
            descripTextBoxColumn = Nothing
            tradeclassIdComboBoxColumn = Nothing
            languageComboBoxColumn = Nothing
            priorityTextBoxColumn = Nothing
            startDtCalendarColumn = Nothing
            CommentTextBoxColumn = Nothing
            endDtCalendarColumn = Nothing
            constraintsRow = Nothing

            maintenanceDataGridView.ResumeLayout(False)

        End Sub

        Private Sub PrepareGridForMarketTable()
            Dim mktIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim descripTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim startDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim endDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)


            maintenanceDataGridView.SuspendLayout()

            mktIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            descripTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            startDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
            endDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn()

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                     {mktIdTextBoxColumn, descripTextBoxColumn _
                                                      , startDtCalendarColumn, endDtCalendarColumn})
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0
            With mktIdTextBoxColumn
                .ReadOnly = True
                .HeaderText = "Market Id"
                .Name = "mktIdTextBoxColumn"
                .DataPropertyName = "MktId"
                '.Visible = False
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "DESCRIP" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With descripTextBoxColumn
                .HeaderText = "Market Name"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "descripTextBoxColumn"
                .DataPropertyName = "Descrip"
                .MaxInputLength = Processor.Data.Ret.DescripColumn.MaxLength
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "STARTDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With startDtCalendarColumn
                .HeaderText = "Start Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "startDtCalendarColumn"
                .DataPropertyName = "StartDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ENDDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With endDtCalendarColumn
                .HeaderText = "End Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "endDtCalendarColumn"
                .DataPropertyName = "EndDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            maintenanceDataGridView.DataSource = Processor.Data.Mkt

            mktIdTextBoxColumn = Nothing
            descripTextBoxColumn = Nothing
            startDtCalendarColumn = Nothing
            endDtCalendarColumn = Nothing
            constraintsRow = Nothing

            maintenanceDataGridView.ResumeLayout(False)

        End Sub

        Private Sub PrepareGridForPublicationTable()
            Dim publicationIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim pepPublicationIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim descripTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim mktIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim startDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim endDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim priorityTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim publishedOnCheckedListBoxColumn As MCAP.UI.Controls.DataGridViewCheckedListBoxColumn
            Dim commentsTextboxcolumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim ROPSizeIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim MagSizeIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn

            Dim PEPPublicationIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim PEPMarketIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim startDtForPEPImportCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim endDtForPEPImportCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim SenderIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn


            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)


            maintenanceDataGridView.SuspendLayout()

            publicationIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            pepPublicationIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            descripTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            mktIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            startDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
            endDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
            priorityTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            publishedOnCheckedListBoxColumn = New MCAP.UI.Controls.DataGridViewCheckedListBoxColumn()
            commentsTextboxcolumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            ROPSizeIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            MagSizeIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn

            PEPPublicationIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            PEPMarketIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            startDtForPEPImportCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
            endDtForPEPImportCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
            SenderIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                     {publicationIdTextBoxColumn, pepPublicationIdTextBoxColumn, descripTextBoxColumn _
                                                       , PEPPublicationIdComboBoxColumn, mktIdComboBoxColumn, PEPMarketIdComboBoxColumn, startDtCalendarColumn _
                                                      , endDtCalendarColumn, priorityTextBoxColumn _
                                                      , publishedOnCheckedListBoxColumn, commentsTextboxcolumn _
                                                      , ROPSizeIdComboBoxColumn, MagSizeIdComboBoxColumn, startDtForPEPImportCalendarColumn, endDtForPEPImportCalendarColumn, SenderIdComboBoxColumn _
                                                    })
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0
            With publicationIdTextBoxColumn
                .ReadOnly = True
                .HeaderText = "Publication Id"
                .Name = "publicationIdTextBoxColumn"
                .DataPropertyName = "PublicationId"
                '.Visible = False
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                           Where r.Column_Name.ToUpper() = "PEPPUBLICATIONID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                           Select r

            With pepPublicationIdTextBoxColumn
                .ReadOnly = True
                .HeaderText = "PEPPublication Id"
                .Name = "pepPublicationIdTextBoxColumn"
                .DataPropertyName = "PEPPublicationId"
                '.Visible = False
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "DESCRIP" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With descripTextBoxColumn
                .HeaderText = "Publication Name"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "descripTextBoxColumn"
                .DataPropertyName = "Descrip"
                .MaxInputLength = Processor.Data.Ret.DescripColumn.MaxLength
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "MKTID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With mktIdComboBoxColumn
                .HeaderText = "Market"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "mktIdComboBoxColumn"
                .DataPropertyName = "MktId"
                .DisplayMember = "Descrip"
                .ValueMember = "MktId"
                .DataSource = Processor.Data.MarketList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "STARTDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With startDtCalendarColumn
                .HeaderText = "Start Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "startDtCalendarColumn"
                .DataPropertyName = "StartDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ENDDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With endDtCalendarColumn
                .HeaderText = "End Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "endDtCalendarColumn"
                .DataPropertyName = "EndDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "PRIORITY" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With priorityTextBoxColumn
                .HeaderText = "Priority"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "priorityTextBoxColumn"
                .DataPropertyName = "Priority"
                .MaxInputLength = 4
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "PUBLISHEDON" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With publishedOnCheckedListBoxColumn
                .MinimumWidth = 125
                .HeaderText = "Published On"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "publishedOnTextBoxColumn"
                .DataPropertyName = "publishedOn"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "COMMENTS" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With commentsTextboxcolumn
                .HeaderText = "Comments"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "commentsTextboxcolumn"
                .DataPropertyName = "Comments"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ROPSIZEID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With ROPSizeIdComboBoxColumn
                .HeaderText = "ROP Size"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "ROPSizeIdComboBoxColumn"
                .DataPropertyName = "ROPSizeId"
                .DisplayMember = "SizeText"
                .ValueMember = "SizeId"
                .DataSource = Processor.Data.Size
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "MAGSIZEID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With MagSizeIdComboBoxColumn
                .HeaderText = "Magazine Size"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "MagSizeIdComboBoxColumn"
                .DataPropertyName = "MagSizeId"
                .DisplayMember = "SizeText"
                .ValueMember = "SizeId"
                .DataSource = Processor.Data.Size
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                           Where r.Column_Name.ToUpper() = "PEPPublicationID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                           Select r
            With PEPPublicationIdComboBoxColumn
                .HeaderText = "PEP Publication"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "PEPPublicationIdComboBoxColumn"
                .DataPropertyName = "peppublicationid"
                .DisplayMember = "PUblication"
                .ValueMember = "PublicationID"
                .DataSource = Processor.Data.pepPubliation
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                            Where r.Column_Name.ToUpper() = "PEPMarket" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                            Select r
            With PEPMarketIdComboBoxColumn
                .HeaderText = "PEP Market"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "PEPMarketIdComboBoxColumn"
                .DataPropertyName = "PEPMarket"
                .DisplayMember = "Descrip"
                .ValueMember = "MktId"
                .DataSource = Processor.Data.pepMarket
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "STARTDATEFORPEPIMPORT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With startDtForPEPImportCalendarColumn
                .HeaderText = "Start Date For PEP Import"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "startDtForPEPImportCalendarColumn"
                .DataPropertyName = "StartDateForPEPImport"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                   Where r.Column_Name.ToUpper() = "ENDDATEFORPEPIMPORT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                   Select r
            With endDtForPEPImportCalendarColumn
                .HeaderText = "End Date For PEP Import"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "endDtForPEPImportCalendarColumn"
                .DataPropertyName = "endDateForPEPImport"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With


            constraintsRow = From r In Processor.Data.COLUMNS _
                Where r.Column_Name.ToUpper() = "SENDERID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                Select r
            With senderIdComboBoxColumn
                .HeaderText = "Sender"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "senderIdComboBoxColumn"
                .DataPropertyName = "senderId"
                .DisplayMember = "Name"
                .ValueMember = "SenderId"
                .DataSource = Processor.Data.SenderList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            maintenanceDataGridView.DataSource = Processor.Data.Publication

            publicationIdTextBoxColumn = Nothing
            descripTextBoxColumn = Nothing
            mktIdComboBoxColumn = Nothing
            startDtCalendarColumn = Nothing
            endDtCalendarColumn = Nothing
            priorityTextBoxColumn = Nothing
            publishedOnCheckedListBoxColumn = Nothing
            commentsTextboxcolumn = Nothing
            ROPSizeIdComboBoxColumn = Nothing
            MagSizeIdComboBoxColumn = Nothing
            startDtForPEPImportCalendarColumn = Nothing
            PEPMarketIdComboBoxColumn = Nothing
            PEPPublicationIdComboBoxColumn = Nothing

            endDtForPEPImportCalendarColumn = Nothing
            SenderIdComboBoxColumn = Nothing

            constraintsRow = Nothing

            maintenanceDataGridView.ResumeLayout(False)

        End Sub

        Private Sub PrepareGridForPublicationSubscriptionTable()
            Dim publicationSubscriptionIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim startDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim endDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim marketTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim publicationComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim accountnoTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim paidbyComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim receipienttypeComboboxcolumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim autopayComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim costTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim prepaidperiodComboboxcolumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim expirationCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim csphoneTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim urllinkTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim usernameTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim passwordTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim emailTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim phoneTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim nameTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim addressTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim commentTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim issuenotesTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim marketidTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)


            maintenanceDataGridView.SuspendLayout()

            publicationSubscriptionIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            startDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn
            endDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn
            marketTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            publicationComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            accountnoTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            paidbyComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            receipienttypeComboboxcolumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            autopayComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            costTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            prepaidperiodComboboxcolumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            expirationCalendarColumn = New MCAP.UI.Controls.CalendarColumn
            csphoneTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            urllinkTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            usernameTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            passwordTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            emailTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            phoneTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            nameTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            addressTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            commentTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            issuenotesTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            marketidTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                     {publicationSubscriptionIdTextBoxColumn, startDtCalendarColumn _
                                                      , endDtCalendarColumn, marketTextBoxColumn _
                                                      , publicationComboBoxColumn, accountnoTextBoxColumn _
                                                      , paidbyComboBoxColumn, receipienttypeComboboxcolumn _
                                                      , autopayComboBoxColumn, costTextBoxColumn _
                                                      , prepaidperiodComboboxcolumn, expirationCalendarColumn _
                                                      , csphoneTextBoxColumn, urllinkTextBoxColumn _
                                                      , usernameTextBoxColumn, passwordTextBoxColumn _
                                                      , emailTextBoxColumn, phoneTextBoxColumn _
                                                      , nameTextBoxColumn, addressTextBoxColumn _
                                                      , commentTextBoxColumn, issuenotesTextBoxColumn, marketidTextBoxColumn})
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0
            With publicationSubscriptionIdTextBoxColumn
                .ReadOnly = True
                .HeaderText = "Subscription Id"
                .Name = "publicationSubscriptionIdTextBoxColumn"
                .DataPropertyName = "PublicationSubscriptionId"
                '.Visible = False
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "STARTDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With startDtCalendarColumn
                .HeaderText = "Start Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "startDtCalendarColumn"
                .DataPropertyName = "StartDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "ENDDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                 Select r
            With endDtCalendarColumn
                .HeaderText = "End Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "endDtCalendarColumn"
                .DataPropertyName = "EndDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "MKT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            Processor.LoadSubscriptionMarket()
            With marketTextBoxColumn
                .HeaderText = "Market"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "marketTextBoxColumn"
                .DataPropertyName = "Market"
                '.DisplayMember = "Descrip"
                '.ValueMember = "MktId"
                '.ReadOnly = True
                '.DataSource = Processor.SubscriptionData.Mkt
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "PUBLICATION" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            Processor.LoadSubscriptionPublications()
            With publicationComboBoxColumn
                .HeaderText = "Publication"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "publicationComboBoxColumn"
                .DataPropertyName = "Publication"
                .DisplayMember = "Descrip"
                .ValueMember = "PublicationId"
                .DataSource = Processor.SubscriptionData.Publication
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ACCOUNTNO" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With accountnoTextBoxColumn
                .MinimumWidth = 125
                .MaxInputLength = 10
                .HeaderText = "Account #"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "accountnoTextBoxColumn"
                .DataPropertyName = "AccountNo"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "PAIDBY" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                 Select r
            Processor.LoadSubscriptionPaidby()
            With paidbyComboBoxColumn
                .HeaderText = "Paid By"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "paidbyComboBoxColumn"
                .DataPropertyName = "PaidBy"
                .DisplayMember = "Descrip"
                .ValueMember = "CodeId"
                .DataSource = Processor.SubscriptionData.PaidByCode
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
     Where r.Column_Name.ToUpper() = "RECEIPIENTTYPE" AndAlso r.Is_Nullable.ToUpper() = "NO" _
     Select r
            Processor.LoadSubscriptionReceipientType()
            With receipienttypeComboboxcolumn
                .HeaderText = "Receipient Type"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "receipienttypeComboboxcolumn"
                .DataPropertyName = "ReceipientType"
                .DisplayMember = "Descrip"
                .ValueMember = "CodeId"
                .DataSource = Processor.SubscriptionData.ReceipientTypeCode
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
Where r.Column_Name.ToUpper() = "AUTOPAY" AndAlso r.Is_Nullable.ToUpper() = "NO" _
Select r
            Processor.LoadSubscriptionYesNoIndicator()
            With autopayComboBoxColumn
                .HeaderText = "Auto Pay?"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "autopayComboBoxColumn"
                .DataPropertyName = "AutoPay"
                .DisplayMember = "Descrip"
                .ValueMember = "InternalDescrip"
                .DataSource = Processor.SubscriptionData.YesNoCode
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "COST" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With costTextBoxColumn
                .HeaderText = "Cost"
                .MaxInputLength = 10
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "costTextBoxColumn"
                .DataPropertyName = "Cost"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
Where r.Column_Name.ToUpper() = "PREPAIDPERIOD" AndAlso r.Is_Nullable.ToUpper() = "NO" _
Select r
            Processor.LoadSubscriptionPrepaidPeriod()
            With prepaidperiodComboboxcolumn
                .HeaderText = "Pre-Paid Period"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "prepaidperiodComboboxcolumn"
                .DataPropertyName = "PrepaidPeriod"
                .DisplayMember = "Descrip"
                .ValueMember = "CodeId"
                .DataSource = Processor.SubscriptionData.PrepaidPeriodCode
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            With expirationCalendarColumn
                .HeaderText = "Expiration"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "expirationCalendarColumn"
                .DataPropertyName = "ExpirationDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                            Where r.Column_Name.ToUpper() = "CSPHONE" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                            Select r
            With csphoneTextBoxColumn
                .MinimumWidth = 125
                .MaxInputLength = 50
                .HeaderText = "CS Phone"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "csphoneTextBoxColumn"
                .DataPropertyName = "CSPhone"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                Where r.Column_Name.ToUpper() = "URL" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                Select r
            With urllinkTextBoxColumn
                .MinimumWidth = 125
                .MaxInputLength = 100
                .HeaderText = "URL Link"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "urllinkTextBoxColumn"
                .DataPropertyName = "URL"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
    Where r.Column_Name.ToUpper() = "UNAME" AndAlso r.Is_Nullable.ToUpper() = "NO" _
    Select r
            With usernameTextBoxColumn
                .MinimumWidth = 125
                .MaxInputLength = 20
                .HeaderText = "Username"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "usernameTextBoxColumn"
                .DataPropertyName = "UName"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
    Where r.Column_Name.ToUpper() = "UPASS" AndAlso r.Is_Nullable.ToUpper() = "NO" _
    Select r
            With passwordTextBoxColumn
                .MinimumWidth = 125
                .MaxInputLength = 20
                .HeaderText = "Password"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "passwordTextBoxColumn"
                .DataPropertyName = "UPass"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
    Where r.Column_Name.ToUpper() = "EMAIL" AndAlso r.Is_Nullable.ToUpper() = "NO" _
    Select r
            With emailTextBoxColumn
                .MinimumWidth = 125
                .MaxInputLength = 50
                .HeaderText = "Email"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "emailTextBoxColumn"
                .DataPropertyName = "Email"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
    Where r.Column_Name.ToUpper() = "PHONE" AndAlso r.Is_Nullable.ToUpper() = "NO" _
    Select r
            With phoneTextBoxColumn
                .MaxInputLength = 20
                .MinimumWidth = 125
                .HeaderText = "Phone"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "phoneTextBoxColumn"
                .DataPropertyName = "Phone"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
    Where r.Column_Name.ToUpper() = "NAME" AndAlso r.Is_Nullable.ToUpper() = "NO" _
    Select r
            With nameTextBoxColumn
                .MinimumWidth = 125
                .HeaderText = "Name"
                .MaxInputLength = 50
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "nameTextBoxColumn"
                .DataPropertyName = "Name"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
    Where r.Column_Name.ToUpper() = "ADDRESS" AndAlso r.Is_Nullable.ToUpper() = "NO" _
    Select r
            With addressTextBoxColumn
                .MinimumWidth = 125
                .MaxInputLength = 50
                .HeaderText = "Address"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "addressTextBoxColumn"
                .DataPropertyName = "Address"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
    Where r.Column_Name.ToUpper() = "COMMENT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
    Select r
            With commentTextBoxColumn
                .MinimumWidth = 125
                .MaxInputLength = 1000
                .HeaderText = "Comment"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "commentTextBoxColumn"
                .DataPropertyName = "Comment"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
    Where r.Column_Name.ToUpper() = "ISSUENOTES" AndAlso r.Is_Nullable.ToUpper() = "NO" _
    Select r
            With issuenotesTextBoxColumn
                .MinimumWidth = 125
                .HeaderText = "Issue Notes"
                .MaxInputLength = 1000
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "issuenotesTextBoxColumn"
                .DataPropertyName = "IssueNotes"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            With marketidTextBoxColumn
                .HeaderText = "Market"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "marketIdTextBoxColumn"
                .DataPropertyName = "Mkt"
                .Visible = False
                '.DisplayMember = "Descrip"
                '.ValueMember = "MktId"
                '.ReadOnly = True
                '.DataSource = Processor.SubscriptionData.Mkt
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            maintenanceDataGridView.DataSource = Processor.SubscriptionData.PublicationSubscription

            publicationSubscriptionIdTextBoxColumn = Nothing
            startDtCalendarColumn = Nothing
            endDtCalendarColumn = Nothing
            marketTextBoxColumn = Nothing
            publicationComboBoxColumn = Nothing
            accountnoTextBoxColumn = Nothing
            paidbyComboBoxColumn = Nothing
            receipienttypeComboboxcolumn = Nothing
            autopayComboBoxColumn = Nothing
            costTextBoxColumn = Nothing
            prepaidperiodComboboxcolumn = Nothing
            expirationCalendarColumn = Nothing
            csphoneTextBoxColumn = Nothing
            urllinkTextBoxColumn = Nothing
            usernameTextBoxColumn = Nothing
            passwordTextBoxColumn = Nothing
            emailTextBoxColumn = Nothing
            phoneTextBoxColumn = Nothing
            nameTextBoxColumn = Nothing
            addressTextBoxColumn = Nothing
            commentTextBoxColumn = Nothing
            issuenotesTextBoxColumn = Nothing

            maintenanceDataGridView.ResumeLayout(False)

        End Sub

        Private Sub PrepareGridForRetMktCustomDescripTable()
            Dim retIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim mktIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim customRetDescripTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim customMktDescripTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim applicationTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)


            maintenanceDataGridView.SuspendLayout()

            retIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            mktIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            customRetDescripTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            customMktDescripTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            applicationTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                        {retIdComboBoxColumn, mktIdComboBoxColumn _
                                                         , customRetDescripTextBoxColumn, customMktDescripTextBoxColumn _
                                                         , applicationTextBoxColumn})

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "RETID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With retIdComboBoxColumn
                .HeaderText = "Retailer"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "RetIdComboBoxColumn"
                .DataPropertyName = "RetId"
                .DisplayMember = "Descrip"
                .ValueMember = "RetId"
                .DataSource = Processor.Data.RetailerList
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "MKTID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With mktIdComboBoxColumn
                .HeaderText = "Market"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "MktIdComboBoxColumn"
                .DataPropertyName = "MktId"
                .DisplayMember = "Descrip"
                .ValueMember = "MktId"
                .DataSource = Processor.Data.MarketList
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "CUSTOMRETDESCRIP" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With customRetDescripTextBoxColumn
                .HeaderText = "Custom Retailer Name"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "customRetDescripTextBoxColumn"
                .DataPropertyName = "customRetDescrip"
                .MaxInputLength = Processor.Data.RetMktCustomDescrip.CustomRetDescripColumn.MaxLength
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "CUSTOMMKTDESCRIP" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With customMktDescripTextBoxColumn
                .HeaderText = "Custom Market Name"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "customMktDescripTextBoxColumn"
                .DataPropertyName = "customMktDescrip"
                .MaxInputLength = Processor.Data.RetMktCustomDescrip.CustomMktDescripColumn.MaxLength
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "APPLICATION" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With applicationTextBoxColumn
                .HeaderText = "Application"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "applicationTextBoxColumn"
                .DataPropertyName = "Application"
                .MaxInputLength = Processor.Data.RetMktCustomDescrip.ApplicationColumn.MaxLength
            End With

            maintenanceDataGridView.DataSource = Processor.Data.RetMktCustomDescrip

            retIdComboBoxColumn = Nothing
            mktIdComboBoxColumn = Nothing
            customRetDescripTextBoxColumn = Nothing
            customMktDescripTextBoxColumn = Nothing
            applicationTextBoxColumn = Nothing
            constraintsRow = Nothing

            maintenanceDataGridView.ResumeLayout(False)

        End Sub

        Private Sub PrepareGridForRetPublicationCoverageTable()
            Dim mdaObj As List(Of DatabaseLayer.clsExpectation) = Nothing
            Dim expObj As New BusinessLayer.clsExpectationController

            Dim MediaIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim retIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim mktIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim publicationComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            'Dim PepPublicationIDTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim PepPublicationComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim priorityTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim startDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim endDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim startDtForPepImportCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim endDtForPepImportCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim commentTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)
            Dim senderIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim ReceivedFromPepComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim PepNeededForBapComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim pepRetIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim pepMktIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            maintenanceDataGridView.SuspendLayout()

            MediaIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            retIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            mktIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            publicationComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            'PepPublicationIDTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            PepPublicationComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            priorityTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            startDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
            endDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
            startDtForPepImportCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
            endDtForPepImportCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
            commentTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            senderIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            ReceivedFromPepComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            PepNeededForBapComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            pepRetIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            pepMktIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                        {MediaIdComboBoxColumn, retIdComboBoxColumn, pepRetIdComboBoxColumn, publicationComboBoxColumn _
                                                         , PepPublicationComboBoxColumn, priorityTextBoxColumn, mktIdComboBoxColumn _
                                                         , pepMktIdComboBoxColumn, senderIdComboBoxColumn, startDtCalendarColumn _
                                                        , endDtCalendarColumn, startDtForPepImportCalendarColumn, endDtForPepImportCalendarColumn _
                                                        , commentTextBoxColumn, PepNeededForBapComboBoxColumn, ReceivedFromPepComboBoxColumn})
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0

            constraintsRow = From r In Processor.Data.COLUMNS _
                           Where r.Column_Name.ToUpper() = "MEDIAID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                           Select r
            With MediaIdComboBoxColumn
                .HeaderText = "Media"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "MediaIdComboBoxColumn"
                .DataPropertyName = "MediaId"
                .DisplayMember = "Descrip"
                .ValueMember = "mediaid"
                .DataSource = Processor.Data.MediaList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "RETID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With retIdComboBoxColumn
                .HeaderText = "Retailer"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "RetIdComboBoxColumn"
                .DataPropertyName = "RetId"
                .DisplayMember = "Descrip"
                .ValueMember = "RetId"
                .DataSource = Processor.Data.RetailerList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "PUBLICATIONID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            mdaObj = expObj.fetch(7)
            With publicationComboBoxColumn
                .HeaderText = "Publication"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "publicationComboBoxColumn"
                .DataPropertyName = "PublicationId"
                .DisplayMember = "Descrip"
                .ValueMember = "PublicationId"
                .DataSource = Processor.Data.PublicationList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                            Where r.Column_Name.ToUpper() = "PEPPUBLICATIONID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                            Select r


            With PepPublicationComboBoxColumn
                .HeaderText = "PEP Publication"
                If constraintsRow.Count() > 0 Then _
                .Name = "PepPublicationComboBoxColumn"
                .DataPropertyName = "PepPublicationID"
                .DisplayMember = "Publication"
                .ValueMember = "PublicationId"
                .DataSource = Processor.Data.pepPubliation
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "PRIORITY" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With priorityTextBoxColumn
                .HeaderText = "Priority"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "priorityTextBoxColumn"
                .DataPropertyName = "Priority"
                .MaxInputLength = 4
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "STARTDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With startDtCalendarColumn
                .HeaderText = "Start Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "startDtCalendarColumn"
                .DataPropertyName = "startDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ENDDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With endDtCalendarColumn
                .HeaderText = "End Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "endDtCalendarColumn"
                .DataPropertyName = "endDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                            Where r.Column_Name.ToUpper() = "STARTDTFORPEPIMPORT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                            Select r
            With startDtForPepImportCalendarColumn
                .HeaderText = "Start Date for PEP import"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "startDtForPepImportCalendarColumn"
                .DataPropertyName = "startDateForPepImport"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With


            constraintsRow = From r In Processor.Data.COLUMNS _
                Where r.Column_Name.ToUpper() = "ENDDTFORPEPIMPORT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                Select r
            With endDtForPepImportCalendarColumn
                .HeaderText = "End Date for PEP import"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "endDtForPepImportCalendarColumn"
                .DataPropertyName = "endDateForPepImport"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With


            constraintsRow = From r In Processor.Data.COLUMNS _
                         Where r.Column_Name.ToUpper() = "MKTID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                         Select r
            With mktIdComboBoxColumn
                .HeaderText = "Market"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "mktIdTextBoxColumn"
                .DataPropertyName = "MKTID"
                .DisplayMember = "Descrip"
                .ValueMember = "MKTId"
                .DataSource = Processor.Data.MarketList
                .ReadOnly = True
                .Visible = True
                .Width = 0
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "COMMENT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With commentTextBoxColumn
                .HeaderText = "Comment"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "commentTextBoxColumn"
                .DataPropertyName = "Comment"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                            Where r.Column_Name.ToUpper() = "PEPRETID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                            Select r
            With pepRetIdComboBoxColumn
                .HeaderText = "PEP Retailer"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "pepRetIdComboBoxColumn"
                .DataPropertyName = "PEPRetId"
                .DisplayMember = "Descrip"
                .ValueMember = "RetId"
                .DataSource = Processor.Data.pepRetailer
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                        Where r.Column_Name.ToUpper() = "PEPMKTID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                        Select r
            With pepMktIdComboBoxColumn
                .HeaderText = "PEP Market"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "pepMktIdComboBoxColumn"
                .DataPropertyName = "PEPMKTID"
                .DisplayMember = "Descrip"
                .ValueMember = "MKTId"
                .DataSource = Processor.Data.pepMarket
                .Visible = True
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                  Where r.Column_Name.ToUpper() = "SENDERID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                  Select r
            With senderIdComboBoxColumn
                .HeaderText = "Sender"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "senderIdComboBoxColumn"
                .DataPropertyName = "senderId"
                .DisplayMember = "Name"
                .ValueMember = "SenderId"
                .DataSource = Processor.Data.SenderList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With


            constraintsRow = From r In Processor.Data.COLUMNS _
                Where r.Column_Name.ToUpper() = "PEPNEEDEDFORBAP" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                Select r
            
            With PepNeededForBapComboBoxColumn
                .HeaderText = "Needed For BAP"
                If constraintsRow.Count() > 0 Then _
                .Name = "PepNeededForBapComboBoxColumn"
                '.DefaultCellStyle.NullValue = "No"
                .DataPropertyName = "PepNeededForBAP"
                .DisplayMember = "Descrip"
                .ValueMember = "InternalDescrip"
                .DataSource = Processor.Data.YesNoIndicator
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "RECEIVEDFROMPEP" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                 Select r
         
            With ReceivedFromPepComboBoxColumn
                .HeaderText = "Received From Pep"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "ReceivedFromPepComboBoxColumn"
                .DataPropertyName = "PepReceivedFromPep"
                '.DisplayMember = "Descrip"
                '.ValueMember = "codeid"
                '.DataSource = Processor.Data.TrueFalseOption
                .DisplayMember = "Descrip"
                .ValueMember = "InternalDescrip"
                .DataSource = Processor.Data.YesNoIndicator
               
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            maintenanceDataGridView.DataSource = Processor.Data.RetPublicationCoverage
            'maintenanceDataGridView.Columns("MktId").Visible = False

            retIdComboBoxColumn = Nothing
            mktIdComboBoxColumn = Nothing
            publicationComboBoxColumn = Nothing
            priorityTextBoxColumn = Nothing
            startDtCalendarColumn = Nothing
            endDtCalendarColumn = Nothing
            constraintsRow = Nothing

            'New Added
            PepPublicationComboBoxColumn = Nothing
            senderIdComboBoxColumn = Nothing
            commentTextBoxColumn = Nothing
            startDtForPepImportCalendarColumn = Nothing
            ReceivedFromPepComboBoxColumn = Nothing
            PepNeededForBapComboBoxColumn = Nothing

            maintenanceDataGridView.ResumeLayout(False)

        End Sub

        Private Sub PrepareGridForSenderTable()
            Dim senderIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim nameTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim companyTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn 'new
            Dim contactnameTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn 'new
            Dim addressTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim address2TextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim cityTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim stateTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim zipcodeTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim countryTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim billingaddressTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn 'new
            Dim phoneTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim cellTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn 'new
            Dim workTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn 'new
            Dim otherphoneTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn 'new
            Dim emailTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn 'new
            Dim startDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim endDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim priorityTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim frequencyComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim expectedDayComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim typeComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim locationComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim shippingComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim shippingtypeComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn 'new
            Dim fexbulklabelComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn 'new
            Dim labelqtyTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn 'new
            Dim packageweightTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn 'new
            Dim labelnoteTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn 'new
            Dim IndNoPublicationsComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim subpaymentComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn 'new
            Dim instorenoteTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn 'new
            Dim specialsendinginstructionTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn 'new
            Dim ccnotesTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn 'new
            Dim commentsTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn 'new
            Dim defaultPkgAssigneeComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim earlysenderComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn 'new
            Dim genderTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim defaultRetIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim defaultmktIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim SourceIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn 'new
            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)

            maintenanceDataGridView.SuspendLayout()

            senderIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            nameTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            companyTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn 'new
            contactnameTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn 'new
            addressTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            address2TextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            cityTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            stateTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            zipcodeTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            countryTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            billingaddressTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn 'new
            phoneTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            cellTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn 'new
            workTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn 'new
            otherphoneTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn 'new
            emailTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn 'new
            startDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn
            endDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn
            priorityTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            frequencyComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            expectedDayComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            typeComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            locationComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            shippingComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            shippingtypeComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn 'new
            fexbulklabelComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn 'new
            labelqtyTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn 'new
            packageweightTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn 'new
            labelnoteTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn 'new
            IndNoPublicationsComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            subpaymentComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn 'new
            instorenoteTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn 'new
            specialsendinginstructionTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn 'new
            ccnotesTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn 'new
            commentsTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn 'new
            defaultPkgAssigneeComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            earlysenderComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn 'new
            genderTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            defaultRetIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            defaultmktIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
            SourceIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn 'new

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                        {senderIdTextBoxColumn, nameTextBoxColumn _
                                                         , companyTextBoxColumn, contactnameTextBoxColumn _
                                                         , addressTextBoxColumn, address2TextBoxColumn _
                                                         , cityTextBoxColumn, stateTextBoxColumn _
                                                         , zipcodeTextBoxColumn, countryTextBoxColumn _
                                                         , billingaddressTextBoxColumn, phoneTextBoxColumn _
                                                         , cellTextBoxColumn, workTextBoxColumn _
                                                         , otherphoneTextBoxColumn, emailTextBoxColumn _
                                                         , startDtCalendarColumn, endDtCalendarColumn _
                                                         , priorityTextBoxColumn, frequencyComboBoxColumn _
                                                         , expectedDayComboBoxColumn, typeComboBoxColumn _
                                                         , locationComboBoxColumn, shippingComboBoxColumn _
                                                         , shippingtypeComboBoxColumn, fexbulklabelComboBoxColumn _
                                                         , labelqtyTextBoxColumn, packageweightTextBoxColumn _
                                                         , labelnoteTextBoxColumn, IndNoPublicationsComboBoxColumn _
                                                         , subpaymentComboBoxColumn, instorenoteTextBoxColumn _
                                                         , specialsendinginstructionTextBoxColumn, ccnotesTextBoxColumn _
                                                         , commentsTextBoxColumn, defaultPkgAssigneeComboBoxColumn _
                                                         , earlysenderComboBoxColumn, genderTextBoxColumn _
                                                         , defaultRetIdComboBoxColumn, defaultmktIdComboBoxColumn _
                                                         , SourceIdComboBoxColumn})

            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0
            With senderIdTextBoxColumn
                .HeaderText = "Sender Id"
                .Name = "senderIdTextBoxColumn"
                .DataPropertyName = "SenderId"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "NAME" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With nameTextBoxColumn
                .HeaderText = "Name"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "nameTextBoxColumn"
                .DataPropertyName = "Name"
                .MaxInputLength = Processor.Data.Sender.NameColumn.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ADDRESS" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With addressTextBoxColumn
                .HeaderText = "Address"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "addressTextBoxColumn"
                .DataPropertyName = "Address"
                .MaxInputLength = Processor.Data.Sender.AddressColumn.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ADDRESS2" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With address2TextBoxColumn
                .HeaderText = "Address2"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "address2TextBoxColumn"
                .DataPropertyName = "Address2"
                .MaxInputLength = Processor.Data.Sender.Address2Column.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "CITY" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With cityTextBoxColumn
                .HeaderText = "City"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "cityTextBoxColumn"
                .DataPropertyName = "City"
                .MaxInputLength = Processor.Data.Sender.CityColumn.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "STATE" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With stateTextBoxColumn
                .HeaderText = "State"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "stateTextBoxColumn"
                .DataPropertyName = "State"
                .MaxInputLength = Processor.Data.Sender.StateColumn.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ZIPCODE" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With zipcodeTextBoxColumn
                .HeaderText = "Zip Code"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "zipcodeTextBoxColumn"
                .DataPropertyName = "ZipCode"
                .MaxInputLength = Processor.Data.Sender.ZipCodeColumn.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "COUNTRY" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With countryTextBoxColumn
                .HeaderText = "Country"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "countryTextBoxColumn"
                .DataPropertyName = "Country"
                .MaxInputLength = Processor.Data.Sender.CountryColumn.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "PHONE" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With phoneTextBoxColumn
                .HeaderText = "Phone"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "phoneTextBoxColumn"
                .DataPropertyName = "Phone"
                .MaxInputLength = Processor.Data.Sender.PhoneColumn.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "STARTDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With startDtCalendarColumn
                .HeaderText = "Start Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "startDtCalendarColumn"
                .DataPropertyName = "startDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ENDDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With endDtCalendarColumn
                .HeaderText = "End Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "endDtCalendarColumn"
                .DataPropertyName = "endDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "PRIORITY" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With priorityTextBoxColumn
                .HeaderText = "Priority"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "priorityTextBoxColumn"
                .DataPropertyName = "Priority"
                .MaxInputLength = 4
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "FREQUENCYID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With frequencyComboBoxColumn
                .HeaderText = "Frequency"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "frequencyComboBoxColumn"
                .DataPropertyName = "FrequencyId"
                .DisplayMember = "Descrip"
                .ValueMember = "CodeId"
                .DataSource = Processor.Data.vwFrequency
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "EXPECTEDRECEIVEDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With expectedDayComboBoxColumn
                .HeaderText = "Expected Weekday"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "expectedDayComboBoxColumn"
                .DataPropertyName = "ExpectedReceiveDt"
                .DisplayMember = "WeekDay"
                .ValueMember = "WeekDayId"
                .DataSource = Processor.Data.Weekdays
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "TYPEID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With typeComboBoxColumn
                .HeaderText = "Type"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "typeComboBoxColumn"
                .DataPropertyName = "TypeId"
                .DisplayMember = "Descrip"
                .ValueMember = "CodeId"
                .DataSource = Processor.Data.vwSenderType
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "LOCATIONID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With locationComboBoxColumn
                .HeaderText = "Location"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "locationComboBoxColumn"
                .DataPropertyName = "LocationId"
                .DisplayMember = "Descrip"
                .ValueMember = "CodeId"
                .DataSource = Processor.Data.vwLocation
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "INDNOSHIPPING" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With shippingComboBoxColumn
                .HeaderText = "Shipping Information"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "shippingComboBoxColumn"
                .DataPropertyName = "IndNoShipping"
                .DisplayMember = "Descrip"
                .ValueMember = "CodeId"
                .DataSource = Processor.Data.Shipping
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "INDNOPUBLICATIONS" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With IndNoPublicationsComboBoxColumn
                .HeaderText = "Has Publications"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "IndNoPublicationsComboBoxColumn"
                '.ValueType = System.Type.GetType("System.byte")
                .DataPropertyName = "IndNoPublications"
                .DisplayMember = "Descrip"
                .ValueMember = "CodeId"
                .DataSource = Processor.Data.Shipping
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With


            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "COMMENTS" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With commentsTextBoxColumn
                .HeaderText = "Comments"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "commentsTextBoxColumn"
                .DataPropertyName = "Comments"
                .MaxInputLength = Processor.Data.Sender.CommentsColumn.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "DefaultPkgAssignee".ToUpper AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With defaultPkgAssigneeComboBoxColumn
                .HeaderText = "Default Package Assignee"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "defaultPkgAssigneeComboBoxColumn"
                .DataPropertyName = "DefaultPkgAssignee"
                .DisplayMember = "FullName"
                .ValueMember = "UserId"
                .DataSource = Processor.Data.User
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "GENDER" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r


            With genderTextBoxColumn
                .HeaderText = "Gender"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "genderTextBoxColumn"
                .DataPropertyName = "Gender"
                '.MaxInputLength = Processor.Data.Sender.Address2Column.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With


            constraintsRow = From r In Processor.Data.COLUMNS _
                                         Where r.Column_Name.ToUpper() = "DEFAULTRETID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                                         Select r

            With defaultRetIdComboBoxColumn
                .ReadOnly = False
                .HeaderText = "DefaultRetId"
                .Name = "DefaultRetIdComboBoxColumn"
                .DataPropertyName = "DefaultRetId"
                .DisplayMember = "Descrip"
                .ValueMember = "RetId"
                .DataSource = Processor.Data.RetailerList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "DEFAULTMKTID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With defaultmktIdComboBoxColumn
                .ReadOnly = False
                .HeaderText = "DefaultMktId"
                .Name = "DefaultMktIdComboBoxColumn"
                .DataPropertyName = "DefaultMktId"
                .DisplayMember = "Descrip"
                .ValueMember = "MktId"
                .DataSource = Processor.Data.MarketList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '' new fields
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "COMPANY" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                 Select r
            With companyTextBoxColumn
                .HeaderText = "Company"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "companyTextBoxColumn"
                .DataPropertyName = "Company"
                '.MaxInputLength = Processor.Data.Sender.Address2Column.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "CONTACTNAME" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                 Select r
            With contactnameTextBoxColumn
                .HeaderText = "Contact Name"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "contactnameTextBoxColumn"
                .DataPropertyName = "ContactName"
                '.MaxInputLength = Processor.Data.Sender.Address2Column.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "MAILINGADDRESS" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                 Select r
            With billingaddressTextBoxColumn
                .HeaderText = "Billing/Mailing Address"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "billingaddressTextBoxColumn"
                .DataPropertyName = "MailingAddress"
                '.MaxInputLength = Processor.Data.Sender.Address2Column.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "CELL" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                 Select r
            With cellTextBoxColumn
                .HeaderText = "Cell"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "cellTextBoxColumn"
                .DataPropertyName = "Cell"
                '.MaxInputLength = Processor.Data.Sender.Address2Column.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "WORK" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                 Select r
            With workTextBoxColumn
                .HeaderText = "Work"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "workTextBoxColumn"
                .DataPropertyName = "Work"
                '.MaxInputLength = Processor.Data.Sender.Address2Column.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "PHONE2" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                 Select r
            With otherphoneTextBoxColumn
                .HeaderText = "Other Phone"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "otherphoneTextBoxColumn"
                .DataPropertyName = "Phone2"
                '.MaxInputLength = Processor.Data.Sender.Address2Column.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "EMAIL" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                 Select r
            With emailTextBoxColumn
                .HeaderText = "Email"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "emailTextBoxColumn"
                .DataPropertyName = "Email"
                '.MaxInputLength = Processor.Data.Sender.Address2Column.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "SHIPPINGTYPEID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                 Select r
            Processor.LoadAllShippingType()
            With shippingtypeComboBoxColumn
                .ReadOnly = False
                .HeaderText = "Shipping Type"
                .Name = "shippingtypeComboBoxColumn"
                .DataPropertyName = "ShippingTypeId"
                .DisplayMember = "Descrip"
                .ValueMember = "CodeId"
                .DataSource = Processor.Data.ShippingTypeCode 'table to be used is Code Table
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "BULKLABELIND" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                 Select r
            Processor.LoadYesNoIndicator()
            With fexbulklabelComboBoxColumn
                .ReadOnly = False
                .HeaderText = "Fex Bulk Label"
                .DataPropertyName = "BulkLabelInd"
                .Name = "fexbulklabelComboBoxColumn"
                .DisplayMember = "Descrip"
                .ValueMember = "CodeId"
                .DataSource = Processor.Data.Shipping
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
             Where r.Column_Name.ToUpper() = "LABELQTY" AndAlso r.Is_Nullable.ToUpper() = "NO" _
            Select r
            With labelqtyTextBoxColumn
                .HeaderText = "Label Qty"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "labelqtyTextBoxColumn"
                .DataPropertyName = "LabelQty"
                '.MaxInputLength = Processor.Data.Sender.Address2Column.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
     Where r.Column_Name.ToUpper() = "PACKAGEWEIGHT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
     Select r
            With packageweightTextBoxColumn
                .HeaderText = "Package Weight"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "packageweightTextBoxColumn"
                .DataPropertyName = "PackageWeight"
                '.MaxInputLength = Processor.Data.Sender.Address2Column.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
     Where r.Column_Name.ToUpper() = "LABELNOTE" AndAlso r.Is_Nullable.ToUpper() = "NO" _
     Select r
            With labelnoteTextBoxColumn
                .HeaderText = "Label Note"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "labelnoteTextBoxColumn"
                .DataPropertyName = "LabelNote"
                ' .MaxInputLength = Processor.Data.Sender.Address2Column.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
     Where r.Column_Name.ToUpper() = "SUBPAYMENT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
     Select r
            Processor.LoadAllSubPayment()
            With subpaymentComboBoxColumn
                .ReadOnly = False
                .HeaderText = "Sub Payment"
                .Name = "subpaymentComboBoxColumn"
                .DataPropertyName = "SubPayment"
                .DisplayMember = "Descrip"
                .ValueMember = "CodeId"
                .DataSource = Processor.Data.SubPayment 'Code Table will be used as datasource
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
Where r.Column_Name.ToUpper() = "INSTORENOTES" AndAlso r.Is_Nullable.ToUpper() = "NO" _
Select r
            With instorenoteTextBoxColumn
                .HeaderText = "In-Store Notes"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "instorenoteTextBoxColumn"
                .DataPropertyName = "InStoreNotes"
                '.MaxInputLength = Processor.Data.Sender.Address2Column.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With
            constraintsRow = From r In Processor.Data.COLUMNS _
Where r.Column_Name.ToUpper() = "SENDINGINSTRUCTIONS" AndAlso r.Is_Nullable.ToUpper() = "NO" _
Select r
            With specialsendinginstructionTextBoxColumn
                .HeaderText = "Special Sending Instruction"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "specialsendinginstructionTextBoxColumn"
                .DataPropertyName = "SendingInstructions"
                '.MaxInputLength = Processor.Data.Sender.Address2Column.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With
            constraintsRow = From r In Processor.Data.COLUMNS _
Where r.Column_Name.ToUpper() = "CCNOTES" AndAlso r.Is_Nullable.ToUpper() = "NO" _
Select r
            With ccnotesTextBoxColumn
                .HeaderText = "CC Notes"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "ccnotesTextBoxColumn"
                .DataPropertyName = "CCNotes"
                '.MaxInputLength = Processor.Data.Sender.Address2Column.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
Where r.Column_Name.ToUpper() = "EARLYSENDER" AndAlso r.Is_Nullable.ToUpper() = "NO" _
Select r
            Processor.LoadYesNoIndicator()
            With earlysenderComboBoxColumn
                .ReadOnly = False
                .HeaderText = "Early Sender"
                .Name = "earlysenderComboBoxColumn"
                .DataPropertyName = "EarlySender"
                .DisplayMember = "Descrip"
                .ValueMember = "InternalDescrip"
                .DataSource = Processor.Data.YesNoIndicator
                '.DataSource = Processor.Data.MarketList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
Where r.Column_Name.ToUpper() = "SOURCEID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
Select r
            Processor.LoadSourceId()
            With SourceIdComboBoxColumn
                .ReadOnly = False
                .HeaderText = "Source ID"
                .Name = "SourceIdComboBoxColumn"
                .DataPropertyName = "SourceId"
                .DisplayMember = "Descrip"
                .ValueMember = "SourceId"
                .DataSource = Processor.Data.Source
                '.DataSource = Processor.Data.MarketList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Processor.Data.Sender.Columns("IndNoPublications").DataType = GetType(Byte)
            Processor.Data.Sender.Columns("BulkLabelInd").DataType = GetType(Byte)
            maintenanceDataGridView.DataSource = Processor.Data.Sender

            senderIdTextBoxColumn = Nothing
            nameTextBoxColumn = Nothing
            addressTextBoxColumn = Nothing
            address2TextBoxColumn = Nothing
            cityTextBoxColumn = Nothing
            stateTextBoxColumn = Nothing
            zipcodeTextBoxColumn = Nothing
            countryTextBoxColumn = Nothing
            phoneTextBoxColumn = Nothing
            commentsTextBoxColumn = Nothing
            startDtCalendarColumn = Nothing
            endDtCalendarColumn = Nothing
            priorityTextBoxColumn = Nothing
            frequencyComboBoxColumn = Nothing
            expectedDayComboBoxColumn = Nothing
            typeComboBoxColumn = Nothing
            locationComboBoxColumn = Nothing
            shippingComboBoxColumn = Nothing
            defaultRetIdComboBoxColumn = Nothing
            defaultmktIdComboBoxColumn = Nothing

            companyTextBoxColumn = Nothing
            contactnameTextBoxColumn = Nothing
            billingaddressTextBoxColumn = Nothing
            cellTextBoxColumn = Nothing
            workTextBoxColumn = Nothing
            otherphoneTextBoxColumn = Nothing
            emailTextBoxColumn = Nothing
            shippingtypeComboBoxColumn = Nothing
            fexbulklabelComboBoxColumn = Nothing
            labelqtyTextBoxColumn = Nothing
            packageweightTextBoxColumn = Nothing
            labelnoteTextBoxColumn = Nothing
            subpaymentComboBoxColumn = Nothing
            instorenoteTextBoxColumn = Nothing
            specialsendinginstructionTextBoxColumn = Nothing
            ccnotesTextBoxColumn = Nothing
            earlysenderComboBoxColumn = Nothing
            SourceIdComboBoxColumn = Nothing

            constraintsRow = Nothing

            maintenanceDataGridView.ResumeLayout(False)
        End Sub
        Private Sub ClearSenderExpectationInfo()
            SenderComboBox.SelectedValue = -1
            MediaComboBox.SelectedValue = -1
            MarketComboBox.SelectedValue = -1
            RetailerComboBox.SelectedValue = -1
            ExpectaionIdLabel.Text = "0"
        End Sub

        Private Sub PrepareGridForSenderMktAssocTable()

            Dim senderIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim mktIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            'Dim startDateCalendarColumn As MCAP.UI.Controls.CalendarColumn()
            'Dim endDateCalendarColumn As MCAP.UI.Controls.CalendarColumn()

            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)


            maintenanceDataGridView.SuspendLayout()

            senderIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            mktIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()

            Dim startDateCalendarColumn As New MCAP.UI.Controls.CalendarColumn()
            Dim endDateCalendarColumn As New MCAP.UI.Controls.CalendarColumn()

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                        {senderIdComboBoxColumn, mktIdComboBoxColumn, startDateCalendarColumn, endDateCalendarColumn})
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0
            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "MKTID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With senderIdComboBoxColumn
                .HeaderText = "Sender"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "senderIdComboBoxColumn"
                .DataPropertyName = "senderId"
                .DisplayMember = "Name"
                .ValueMember = "SenderId"
                .DataSource = Processor.Data.SenderList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "MKTID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With mktIdComboBoxColumn
                .HeaderText = "Market"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "MktIdComboBoxColumn"
                .DataPropertyName = "MktId"
                .DisplayMember = "Descrip"
                .ValueMember = "MktId"
                .DataSource = Processor.Data.MarketList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                        Where r.Column_Name.ToUpper() = "STARTDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                        Select r
            With startDateCalendarColumn
                .HeaderText = "Start Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "startDateCalendarColumn"
                .DataPropertyName = "startDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "ENDDT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With endDateCalendarColumn
                .HeaderText = "End Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "endDateCalendarColumn"
                .DataPropertyName = "endDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With


            maintenanceDataGridView.DataSource = Processor.Data.SenderMktAssoc

            senderIdComboBoxColumn = Nothing
            mktIdComboBoxColumn = Nothing
            constraintsRow = Nothing

            maintenanceDataGridView.ResumeLayout(False)

        End Sub

        Private Sub PrepareGridForSenderPublicationTable()
            Dim senderIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim pubIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)


            maintenanceDataGridView.SuspendLayout()

            senderIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            pubIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                        {senderIdComboBoxColumn, pubIdComboBoxColumn})
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0
            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "SENDERID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With senderIdComboBoxColumn
                .HeaderText = "Sender"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "senderIdComboBoxColumn"
                .DataPropertyName = "senderId"
                .DisplayMember = "Name"
                .ValueMember = "SenderId"
                .DataSource = Processor.Data.SenderList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "PUBLICATIONID" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With pubIdComboBoxColumn
                .HeaderText = "Publication"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "pubIdComboBoxColumn"
                .DataPropertyName = "PublicationId"
                .DisplayMember = "Descrip"
                .ValueMember = "PublicationId"
                .DataSource = Processor.Data.PublicationList
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            maintenanceDataGridView.DataSource = Processor.Data.SenderPublication

            senderIdComboBoxColumn = Nothing
            pubIdComboBoxColumn = Nothing
            constraintsRow = Nothing

            maintenanceDataGridView.ResumeLayout(False)

        End Sub

        Private Sub PrepareGridForSenderExpectationTableText()
            Dim senderIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim expIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim medIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim mktIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim retIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim senderNameTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim mediaButtonColumn As New System.Windows.Forms.DataGridViewButtonColumn
            Dim startDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim endDtCalendarColumn As MCAP.UI.Controls.CalendarColumn

            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)

            maintenanceDataGridView.SuspendLayout()

            senderNameTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            medIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            expIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            mktIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            retIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            senderIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            mediaButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn()
            startDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn
            endDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                       {senderNameTextBoxColumn, medIdTextBoxColumn, mktIdTextBoxColumn, retIdTextBoxColumn, expIdTextBoxColumn, senderIdTextBoxColumn, mediaButtonColumn, startDtCalendarColumn, endDtCalendarColumn})
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0

            constraintsRow = Nothing
            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "SENDERNAME" AndAlso r.Is_Nullable.ToUpper() = "YES" _
                 Select r
            With senderNameTextBoxColumn
                .HeaderText = "SenderName"
                'If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "senderNameTextBoxColumn"
                ' .ReadOnly = True
                .DataPropertyName = "SenderName"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = Nothing
            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "MEDIAID" AndAlso r.Is_Nullable.ToUpper() = "YES" _
                 Select r

            With medIdTextBoxColumn
                .HeaderText = "Media"
                'If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "MediaIdTextBoxColumn"
                ' .ReadOnly = True
                .DataPropertyName = "Mediaid"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = Nothing
            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "MKTID" AndAlso r.Is_Nullable.ToUpper() = "YES" _
                 Select r

            With mktIdTextBoxColumn
                .HeaderText = "Market"
                'If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "mktIdTextBoxColumn"
                '.ReadOnly = True
                .DataPropertyName = "MktId"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = Nothing
            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "RETID" AndAlso r.Is_Nullable.ToUpper() = "YES" _
                 Select r

            With retIdTextBoxColumn
                .HeaderText = "Retailers"
                'If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "retIdTextBoxColumn"
                '.ReadOnly = True
                .DataPropertyName = "RetId"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = Nothing
            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "EXPECTATIONID" AndAlso r.Is_Nullable.ToUpper() = "YES" _
                 Select r

            With expIdTextBoxColumn
                .HeaderText = "ExpectationID"
                'If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "expIdTextBoxColumn"
                .ReadOnly = True
                .DataPropertyName = "ExpectationId"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "SENDERID" AndAlso r.Is_Nullable.ToUpper() = "YES" _
                 Select r
            With senderIdTextBoxColumn
                .HeaderText = "SenderId"
                'If constraintsRow.Count() > 0 Then _
                '.HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "SenderIdTextBoxColumn"
                ' .ReadOnly = True
                .DataPropertyName = "SenderId"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                        Where r.Column_Name.ToUpper() = "startDate" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                        Select r
            With startDtCalendarColumn
                .HeaderText = "Start Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "startDtCalendarColumn"
                .DataPropertyName = "startDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "endDate" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With endDtCalendarColumn
                .HeaderText = "End Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "endDtCalendarColumn"
                .DataPropertyName = "endDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            Processor.Data.SenderExpectation.Columns("senderName").SetOrdinal(0)
            Processor.Data.SenderExpectation.Columns("Mediaid").SetOrdinal(1)
            Processor.Data.SenderExpectation.Columns("mktid").SetOrdinal(2)
            Processor.Data.SenderExpectation.Columns("retid").SetOrdinal(3)
            maintenanceDataGridView.DataSource = Processor.Data.SenderExpectation


            With mediaButtonColumn
                .HeaderText = "Load ExId."
                .Text = "Fill in Media"
                'If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "mediaButtonColumn"
                ' .ReadOnly = True
                '.DataPropertyName = "Button Field"
                .UseColumnTextForButtonValue = True
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            senderIdTextBoxColumn = Nothing
            senderNameTextBoxColumn = Nothing
            expIdTextBoxColumn = Nothing
            medIdTextBoxColumn = Nothing
            mktIdTextBoxColumn = Nothing
            retIdTextBoxColumn = Nothing
            constraintsRow = Nothing

            maintenanceDataGridView.ResumeLayout(False)
            maintenanceDataGridView.Columns("senderNameTextBoxColumn").DisplayIndex = 0
            maintenanceDataGridView.Columns("MediaIdTextBoxColumn").DisplayIndex = 1
            maintenanceDataGridView.Columns("mktIdTextBoxColumn").DisplayIndex = 2
            maintenanceDataGridView.Columns("retIdTextBoxColumn").DisplayIndex = 3
            maintenanceDataGridView.Columns("expIdTextBoxColumn").DisplayIndex = 4
            maintenanceDataGridView.Columns("SenderIdTextBoxColumn").DisplayIndex = 5
            maintenanceDataGridView.Columns("mediaButtonColumn").DisplayIndex = 6
            maintenanceDataGridView.Columns("SenderIdTextBoxColumn").Visible = False


        End Sub

        Private Sub PrepareGridForSenderExpectationTable()
            Dim senderIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim expIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim medIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim mktIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim retIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim senderNameTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim mediaButtonColumn As New System.Windows.Forms.DataGridViewButtonColumn
            Dim startDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
            Dim endDtCalendarColumn As MCAP.UI.Controls.CalendarColumn


            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)

            maintenanceDataGridView.SuspendLayout()

            senderNameTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            medIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            expIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            mktIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            retIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            senderIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            mediaButtonColumn = New System.Windows.Forms.DataGridViewButtonColumn()
            startDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn
            endDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                       {senderNameTextBoxColumn, medIdTextBoxColumn, mktIdTextBoxColumn, retIdTextBoxColumn, expIdTextBoxColumn, senderIdTextBoxColumn, mediaButtonColumn, startDtCalendarColumn, endDtCalendarColumn})
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0

            constraintsRow = Nothing
            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "SENDERNAME" AndAlso r.Is_Nullable.ToUpper() = "YES" _
                 Select r
            With senderNameTextBoxColumn
                .HeaderText = "SenderName"
                'If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "senderNameTextBoxColumn"
                ' .ReadOnly = True
                .DataPropertyName = "SenderName"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = Nothing
            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "MEDIAID" AndAlso r.Is_Nullable.ToUpper() = "YES" _
                 Select r

            With medIdTextBoxColumn
                .HeaderText = "Media"
                'If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "MediaIdTextBoxColumn"
                ' .ReadOnly = True
                .DataPropertyName = "Mediaid"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = Nothing
            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "MKTID" AndAlso r.Is_Nullable.ToUpper() = "YES" _
                 Select r

            With mktIdTextBoxColumn
                .HeaderText = "Market"
                'If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "mktIdTextBoxColumn"
                '.ReadOnly = True
                .DataPropertyName = "MktId"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = Nothing
            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "RETID" AndAlso r.Is_Nullable.ToUpper() = "YES" _
                 Select r

            With retIdTextBoxColumn
                .HeaderText = "Retailers"
                'If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "retIdTextBoxColumn"
                '.ReadOnly = True
                .DataPropertyName = "RetId"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = Nothing
            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "EXPECTATIONID" AndAlso r.Is_Nullable.ToUpper() = "YES" _
                 Select r

            With expIdTextBoxColumn
                .HeaderText = "ExpectationID"
                'If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "expIdTextBoxColumn"
                .ReadOnly = True
                .DataPropertyName = "ExpectationId"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                 Where r.Column_Name.ToUpper() = "SENDERID" AndAlso r.Is_Nullable.ToUpper() = "YES" _
                 Select r
            With senderIdTextBoxColumn
                .HeaderText = "SenderId"
                'If constraintsRow.Count() > 0 Then _
                '.HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "SenderIdTextBoxColumn"
                ' .ReadOnly = True
                .DataPropertyName = "SenderId"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With
            Processor.Data.SenderExpectation.Columns("senderName").SetOrdinal(0)
            Processor.Data.SenderExpectation.Columns("Mediaid").SetOrdinal(1)
            Processor.Data.SenderExpectation.Columns("mktid").SetOrdinal(2)
            Processor.Data.SenderExpectation.Columns("retid").SetOrdinal(3)
            maintenanceDataGridView.DataSource = Processor.Data.SenderExpectation


            With mediaButtonColumn
                .HeaderText = "Load ExId."
                .Text = "Fill in Media"
                'If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "mediaButtonColumn"
                ' .ReadOnly = True
                '.DataPropertyName = "Button Field"
                .UseColumnTextForButtonValue = True
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                        Where r.Column_Name.ToUpper() = "startDate" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                        Select r
            With startDtCalendarColumn
                .HeaderText = "Start Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "startDtCalendarColumn"
                .DataPropertyName = "startDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "endDate" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With endDtCalendarColumn
                .HeaderText = "End Date"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "endDtCalendarColumn"
                .DataPropertyName = "endDt"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            senderIdTextBoxColumn = Nothing
            senderNameTextBoxColumn = Nothing
            expIdTextBoxColumn = Nothing
            medIdTextBoxColumn = Nothing
            mktIdTextBoxColumn = Nothing
            retIdTextBoxColumn = Nothing
            constraintsRow = Nothing

            maintenanceDataGridView.ResumeLayout(False)
            maintenanceDataGridView.Columns("senderNameTextBoxColumn").DisplayIndex = 0
            maintenanceDataGridView.Columns("MediaIdTextBoxColumn").DisplayIndex = 1
            maintenanceDataGridView.Columns("mktIdTextBoxColumn").DisplayIndex = 2
            maintenanceDataGridView.Columns("retIdTextBoxColumn").DisplayIndex = 3
            maintenanceDataGridView.Columns("expIdTextBoxColumn").DisplayIndex = 4
            maintenanceDataGridView.Columns("SenderIdTextBoxColumn").DisplayIndex = 5
            maintenanceDataGridView.Columns("mediaButtonColumn").DisplayIndex = 6
            maintenanceDataGridView.Columns("SenderIdTextBoxColumn").Visible = False


        End Sub

        Private Sub PrepareGridForShipperTable()
            Dim shipperIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim descripTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim needTrackingNoComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)


            maintenanceDataGridView.SuspendLayout()

            shipperIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            descripTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            needTrackingNoComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                        {shipperIdTextBoxColumn, descripTextBoxColumn _
                                                         , needTrackingNoComboBoxColumn})
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0
            With shipperIdTextBoxColumn
                .ReadOnly = True
                .HeaderText = "Shipper Id"
                .Name = "shipperIdTextBoxColumn"
                .DataPropertyName = "ShipperId"
                '.Visible = False
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "DESCRIP" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With descripTextBoxColumn
                .HeaderText = "Shipper Name"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "descripTextBoxColumn"
                .DataPropertyName = "Descrip"
                .MaxInputLength = Processor.Data.Shipper.DescripColumn.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "INDNEEDTRACKINGNO" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With needTrackingNoComboBoxColumn
                .HeaderText = "Need TrackingNo"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "needTrackingNoComboBoxColumn"
                .DataPropertyName = "IndNeedTrackingNo"
                .DisplayMember = "Descrip"
                .ValueMember = "CodeId"
                .DataSource = Processor.Data.NeedTrackingNo
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            maintenanceDataGridView.DataSource = Processor.Data.Shipper

            shipperIdTextBoxColumn = Nothing
            descripTextBoxColumn = Nothing
            needTrackingNoComboBoxColumn = Nothing
            constraintsRow = Nothing

            maintenanceDataGridView.ResumeLayout(False)

        End Sub

        Private Sub PrepareGridForSizeTable()
            Dim sizeIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim heightTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim widthTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)


            maintenanceDataGridView.SuspendLayout()

            sizeIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            heightTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
            widthTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                        {sizeIdTextBoxColumn, heightTextBoxColumn _
                                                         , widthTextBoxColumn})
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0
            With sizeIdTextBoxColumn
                .HeaderText = "Size Id"
                .Name = "sizeIdTextBoxColumn"
                .DataPropertyName = "SizeId"
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "HEIGHT" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With heightTextBoxColumn
                .HeaderText = "Height"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "heightTextBoxColumn "
                .DataPropertyName = "Height"
                .MaxInputLength = 6
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "WIDTH" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With widthTextBoxColumn
                .HeaderText = "Width"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "widthTextBoxColumn "
                .DataPropertyName = "Width"
                .MaxInputLength = 6
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            maintenanceDataGridView.DataSource = Processor.Data.Size

            sizeIdTextBoxColumn = Nothing
            heightTextBoxColumn = Nothing
            widthTextBoxColumn = Nothing
            constraintsRow = Nothing

            maintenanceDataGridView.ResumeLayout(False)

        End Sub

        Private Sub PrepareGridForTradeclassTable()
            Dim tradeclassIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim descripTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim constraintsRow As System.Data.EnumerableRowCollection(Of MaintenanceDataSet.COLUMNSRow)


            maintenanceDataGridView.SuspendLayout()

            tradeclassIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            descripTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                        {tradeclassIdTextBoxColumn, descripTextBoxColumn})
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0
            With tradeclassIdTextBoxColumn
                .ReadOnly = True
                .HeaderText = "Tradeclass Id"
                .Name = "tradeclassIdTextBoxColumn"
                .DataPropertyName = "TradeclassId"
                '.Visible = False
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            constraintsRow = From r In Processor.Data.COLUMNS _
                             Where r.Column_Name.ToUpper() = "DESCRIP" AndAlso r.Is_Nullable.ToUpper() = "NO" _
                             Select r
            With descripTextBoxColumn
                .HeaderText = "Tradeclass Name"
                If constraintsRow.Count() > 0 Then _
                .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
                .Name = "descripTextBoxColumn"
                .DataPropertyName = "Descrip"
                .MaxInputLength = Processor.Data.TradeClass.DescripColumn.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            maintenanceDataGridView.DataSource = Processor.Data.TradeClass

            tradeclassIdTextBoxColumn = Nothing
            descripTextBoxColumn = Nothing
            constraintsRow = Nothing

            maintenanceDataGridView.ResumeLayout(False)

        End Sub


#End Region


        ''' <summary>
        ''' Gets Prefix text(table alias) for filter column.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function GetFilterColumnTablePrefix() As String

            Select Case tableComboBox.Text
                Case "Expectation"
                    Return "E."
                    '  'Case 1
                    '  '  Processor.LoadFilteredLanguage(filterCondition)
                    '  'Case 2
                    '  '  Processor.LoadFilteredMedia(filterCondition)
                    'Case 3
                    '  Processor.LoadRetailers(filterCondition)
                    'Case 4
                    '  Processor.LoadMarkets(filterCondition)
                    'Case 5
                    '  Processor.LoadPublications(filterCondition)
                Case "RetPublicationCoverage"
                    Return "RPC."
                    'Case 7
                    '  Processor.LoadSenders(filterCondition)
                Case "SenderMktAssoc"
                    Return "SMA."
                    'Case 9
                    '  Processor.LoadShippers(filterCondition)
                    'Case 10
                    '  Processor.LoadSizes(filterCondition)
                    '  'Case 11
                    '  '  Processor.LoadTradeclasses(filterCondition)
                    'Case Else
                    '  Throw New System.ApplicationException("Template not defined for this selection.")
                Case "SenderExpectation"
                    Return "vwSenderExpectation."

            End Select

        End Function

        Private Function returnSubStringValue(ByVal Value As String, ByVal MaxString As Integer) As String
            Dim stringLength As Integer
            Dim NewValue As String
            stringLength = Value.Length
            NewValue = Value
            If stringLength >= MaxString Then
                NewValue = Value.Substring(0, MaxString)
                NewValue = NewValue + "  ...  "
            End If
            Return NewValue
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="filterCondition"></param>
        ''' <remarks></remarks>
        Private Sub LoadFilteredTable(ByVal filterCondition As String)

            Select Case tableComboBox.Text
                Case "Expectation"
                    Processor.LoadExpectations(filterCondition)
                    'Case 1
                    '  Processor.LoadFilteredLanguage(filterCondition)
                    'Case 2
                    '  Processor.LoadFilteredMedia(filterCondition)
                Case "Ret"
                    Processor.LoadRetailers(filterCondition)
                Case "Mkt"
                    Processor.LoadMarkets(filterCondition)
                Case "Publication"
                    Processor.LoadPublications(filterCondition)
                Case "RetPublicationCoverage"
                    Processor.LoadRetPublicationCoverage(filterCondition)
                Case "Sender"
                    Processor.LoadSenders(filterCondition)

                Case "SenderExpectation"

                    _IsLoading = True
                    Processor.LoadSenderExpectation(filterCondition)
                    _IsLoading = False

                Case "SenderMktAssoc"
                    Processor.LoadSenderMktAssoc(filterCondition)

                Case "SenderPublication"
                    Processor.LoadSenderPublication(filterCondition)
                Case "Shipper"
                    Processor.LoadShippers(filterCondition)
                Case "Size"
                    Processor.LoadSizes(filterCondition)
                Case "TradeClass"
                    Processor.LoadTradeclasses(filterCondition)
                Case "OnlineWebsite"
                    Processor.LoadWebsites(filterCondition)
                Case "Site"
                    Processor.LoadSites(filterCondition)
                Case Else
                    Throw New System.ApplicationException("Template not defined for this selection.")
            End Select

        End Sub

        ''' <summary>
        ''' Sets AutoSizeMode property of grid view columns. If total width of the 
        ''' columns is lesser than width of the client area, last column is set 
        ''' with Fill mode.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ResizeDataGridViewColumns()
            Dim visibleColumnCount As Integer
            Dim columnsQuery As System.Collections.Generic.IEnumerable(Of System.Windows.Forms.DataGridViewColumn)
            Dim totalWidthQuery As System.Collections.Generic.IEnumerable(Of Integer)


            columnsQuery = From col In maintenanceDataGridView.Columns.Cast(Of System.Windows.Forms.DataGridViewColumn)() _
                           Select col _
                           Where col.Visible = True

            visibleColumnCount = columnsQuery.Count

            For i As Integer = 0 To visibleColumnCount - 1
                columnsQuery(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

            totalWidthQuery = From col In maintenanceDataGridView.Columns.Cast(Of System.Windows.Forms.DataGridViewColumn)() _
                              Where (col.Visible = True) _
                              Select col.Width

            If totalWidthQuery.Count > 0 AndAlso maintenanceDataGridView.ClientSize.Width > totalWidthQuery.Sum() Then
                columnsQuery(visibleColumnCount - 1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            End If

            columnsQuery = Nothing
            totalWidthQuery = Nothing

        End Sub

        ''' <summary>
        ''' Resets filter controls.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub ResetFilterControls()

            filterValueComboBox.Visible = False
            filterValueTypeInDatePicker.Visible = False
            filterValueTextBox.Visible = True

            filterFieldComboBox.SelectedIndex = -1
            filterFieldComboBox.Text = String.Empty

            logicalOperatorsComboBox.SelectedIndex = 0

            filterValue2ComboBox.Visible = False
            filterValue2TypeInDatePicker.Visible = False
            filterValue2TextBox.Visible = True

            filterField2ComboBox.SelectedIndex = -1
            filterField2ComboBox.Text = String.Empty

            removeFilterButton.Enabled = False

        End Sub

        ''' <summary>
        ''' Sets control to allow user to specify filter value. Filter control is 
        ''' set based on data type of the supplied data column.
        ''' </summary>
        ''' <param name="filterColumn"></param>
        ''' <remarks></remarks>
        Private Sub SetFilterControl(ByVal filterColumn As System.Data.DataColumn)

            If filterColumn.DataType.ToString() = "System.DateTime" _
            And filterColumn.ColumnName.ToUpper() = "LASTDOWNLOADDT" _
            And filterColumn.ColumnName.ToUpper() = "CAPTUREDELAYDT" _
            Or filterColumn.ColumnName.ToUpper = "STARTDT" _
            Or filterColumn.ColumnName.ToUpper = "ENDDT" _
            Or filterColumn.ColumnName.ToUpper() = "EXPIRATIONDT" _
                Then
                filterValueComboBox.Visible = False
                filterValueTextBox.Visible = False
                filterValueTypeInDatePicker.Text = ""
                filterValueTypeInDatePicker.Value = Nothing
                filterValueTypeInDatePicker.Visible = True

            ElseIf filterColumn.ColumnName.ToUpper().EndsWith("ID") And filterColumn.ColumnName.ToUpper() <> "EXPECTATIONID" _
                  OrElse filterColumn.ColumnName.ToUpper() = "EXPECTEDRECEIVEDT" _
                  OrElse filterColumn.ColumnName.ToUpper() = "INDNEEDTRACKINGNO" _
                  OrElse filterColumn.ColumnName.ToUpper() = "SCANDPI" _
                  OrElse filterColumn.ColumnName.ToUpper() = "INDNOSHIPPING" _
                  OrElse filterColumn.ColumnName.ToUpper() = "INDNOPUBLICATIONS" _
                  OrElse filterColumn.ColumnName.ToUpper() = "ACTIVEIND" _
                  OrElse filterColumn.ColumnName.ToUpper() = "FORCERUNIND" _
                  OrElse filterColumn.ColumnName.ToUpper() = "GETIMAGESMANUALLYIND" _
                   OrElse filterColumn.ColumnName.ToUpper() = "PUBLICATIONSUBSCIPTIONID" _
                   OrElse filterColumn.ColumnName.ToUpper() = "PUBLICATION" _
                   OrElse filterColumn.ColumnName.ToUpper() = "PAIDBY" _
                   OrElse filterColumn.ColumnName.ToUpper() = "RECEIPIENTTYPE" _
                   OrElse filterColumn.ColumnName.ToUpper() = "PREPAIDPERIOD" _
                   OrElse filterColumn.ColumnName.ToUpper() = "AUTOPAY" _
                   OrElse filterColumn.ColumnName.ToUpper() = "MARKET" _
                   OrElse filterColumn.ColumnName.ToUpper() = "SUBPAYMENT" _
                   OrElse filterColumn.ColumnName.ToUpper() = "Display" _
                Then
                filterValueTypeInDatePicker.Visible = False
                filterValueTextBox.Visible = False
                filterValueComboBox.SelectedIndex = -1
                filterValueComboBox.Text = String.Empty
                filterValueComboBox.Visible = True

            Else
                filterValueTypeInDatePicker.Visible = False
                filterValueComboBox.Visible = False
                filterValueTextBox.Tag = filterColumn.DataType.ToString()
                filterValueTextBox.Text = String.Empty
                filterValueTextBox.Visible = True
            End If

        End Sub

        ''' <summary>
        ''' Sets control to allow user to specify filter value. Filter control is 
        ''' set based on data type of the supplied data column.
        ''' </summary>
        ''' <param name="filterColumn"></param>
        ''' <remarks></remarks>
        Private Sub SetFilter2Control(ByVal filterColumn As System.Data.DataColumn)

            If filterColumn.DataType.ToString() = "System.DateTime" _
            Or filterColumn.ColumnName.ToUpper = "STARTDT" _
            Or filterColumn.ColumnName.ToUpper = "ENDDT" _
            Or filterColumn.ColumnName.ToUpper() = "EXPIRATIONDT" _
            Then
                filterValue2ComboBox.Visible = False
                filterValue2TextBox.Visible = False
                filterValue2TypeInDatePicker.Text = ""
                filterValue2TypeInDatePicker.Value = Nothing
                filterValue2TypeInDatePicker.Visible = True

            ElseIf filterColumn.ColumnName.ToUpper().EndsWith("ID") And filterColumn.ColumnName.ToUpper() <> "EXPECTATIONID" _
             OrElse filterColumn.ColumnName.ToUpper() = "EXPECTEDRECEIVEDT" _
             OrElse filterColumn.ColumnName.ToUpper() = "INDNEEDTRACKINGNO" _
             OrElse filterColumn.ColumnName.ToUpper() = "SCANDPI" _
             OrElse filterColumn.ColumnName.ToUpper() = "INDNOSHIPPING" _
             OrElse filterColumn.ColumnName.ToUpper() = "INDNOPUBLICATIONS" _
             OrElse filterColumn.ColumnName.ToUpper() = "ACTIVEIND" _
             OrElse filterColumn.ColumnName.ToUpper() = "FORCERUNIND" _
             OrElse filterColumn.ColumnName.ToUpper() = "GETIMAGESMANUALLYIND" _
              OrElse filterColumn.ColumnName.ToUpper() = "PUBLICATIONSUBSCIPTIONID" _
              OrElse filterColumn.ColumnName.ToUpper() = "PUBLICATION" _
              OrElse filterColumn.ColumnName.ToUpper() = "PAIDBY" _
              OrElse filterColumn.ColumnName.ToUpper() = "RECEIPIENTTYPE" _
              OrElse filterColumn.ColumnName.ToUpper() = "PREPAIDPERIOD" _
              OrElse filterColumn.ColumnName.ToUpper() = "AUTOPAY" _
              OrElse filterColumn.ColumnName.ToUpper() = "MARKET" _
              OrElse filterColumn.ColumnName.ToUpper() = "SUBPAYMENT" _
               OrElse filterColumn.ColumnName.ToUpper() = "Display" _
           Then
                filterValue2TypeInDatePicker.Visible = False
                filterValue2TextBox.Visible = False
                filterValue2ComboBox.SelectedIndex = -1
                filterValue2ComboBox.Text = String.Empty
                filterValue2ComboBox.Visible = True

            Else
                filterValue2TypeInDatePicker.Visible = False
                filterValue2ComboBox.Visible = False
                filterValue2TextBox.Tag = filterColumn.DataType.ToString()
                filterValue2TextBox.Text = String.Empty
                filterValue2TextBox.Visible = True
            End If

        End Sub

        ''' <summary>
        ''' Sets fields drop down list as per the selected table in drop down list.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub SetFieldsDropDownList()
            Dim index As Integer
            Dim columnQuery As System.Collections.Generic.IEnumerable(Of String)


            columnQuery = From col In maintenanceDataGridView.Columns.Cast(Of DataGridViewColumn)() _
                          Where col.Visible = True And col.HeaderText <> "Password" And col.HeaderText <> "WebsitePageDownloadId" And _
                          col.HeaderText <> "Default PageType" And col.HeaderText <> "Default Status Id" And col.HeaderText <> "Load ExId." And col.HeaderText <> "ExpectationID" _
                          Order By col.HeaderText _
                          Select col.HeaderText

            filterFieldComboBox.SelectedIndex = -1
            filterFieldComboBox.Text = String.Empty
            filterFieldComboBox.Items.Clear()
            filterFieldComboBox.Items.AddRange(columnQuery.ToArray())

            filterField2ComboBox.SelectedIndex = -1
            filterField2ComboBox.Text = String.Empty
            filterField2ComboBox.Items.Clear()
            filterField2ComboBox.Items.AddRange(columnQuery.ToArray())

            columnQuery = Nothing

            'Removing exceptional columns from drop down. In select list, such 
            'column(s) should be trailing one to avoid column index issues while
            'identifying column name for search.
            index = filterFieldComboBox.FindStringExact("SizeText")
            If index > 0 Then
                filterFieldComboBox.Items.RemoveAt(index)
                filterField2ComboBox.Items.RemoveAt(index)
            End If

        End Sub

        ''' <summary>
        ''' Fills in values into filter value drop down list. Values are filled 
        ''' based on selected table and column name.
        ''' </summary>
        ''' <param name="tableName">Name of the table for which preparing the drop down list.</param>
        ''' <param name="columnName">Name of the field of the table. Drop down list will contain values for this field.</param>
        ''' <remarks></remarks>
        Private Sub SetFilterValueDropDownList(ByVal tableName As String, ByVal columnName As String)
            Dim mdaObj As List(Of DatabaseLayer.clsExpectation) = Nothing
            Dim expObj As New BusinessLayer.clsExpectationController


            filterValueComboBox.DataSource = Nothing
            Dim temp As String = columnName.ToUpper()
            Dim temp2 As String = tableName.ToUpper()


            Select Case columnName.ToUpper()
                Case "ROLEID"
                    filterValueComboBox.Enabled = True
                    filterValueTextBox.Enabled = True

                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "RoleId"
                    filterValueComboBox.DataSource = Processor.DESPData.Role

                Case "STOREDPROCEDUREID"
                    filterValueComboBox.Enabled = True
                    filterValueTextBox.Enabled = True

                    If tableName <> "DESP_StoredProcedureMaintenance" Then
                        filterValueComboBox.DisplayMember = "ProcedureDetails"
                        filterValueComboBox.ValueMember = "StoredProcedureId"
                        filterValueComboBox.DataSource = Processor.DESPData.DESP_StoredProcedure
                    Else
                        filterValueComboBox.DisplayMember = "StoredProcedureId"
                        filterValueComboBox.ValueMember = "StoredProcedureId"
                        filterValueComboBox.DataSource = Processor.DESPData.DESP_StoredProcedureMaintenance
                    End If

                Case "SITEID"
                    'If Processor.Data.Site.Rows.Count = 0 Then Processor.LoadAllSite()
                    filterValueComboBox.Enabled = True
                    filterValueTextBox.Enabled = True
                    If tableComboBox.Text <> "Site" Then
                        filterValueComboBox.DisplayMember = "Descrip"
                        filterValueComboBox.ValueMember = "SiteId"
                        filterValueComboBox.DataSource = Processor.Data.Site
                    Else
                        filterValueComboBox.DisplayMember = "SiteId"
                        filterValueComboBox.ValueMember = "SiteId"
                        filterValueComboBox.DataSource = LoadID("Site").Tables(0)
                    End If


                Case "DEFAULTRETID"
                    mdaObj = expObj.fetch(3)
                    filterValueComboBox.Enabled = True
                    filterValueTextBox.Enabled = True
                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "RetId"
                    'filterValueComboBox.DataSource = Processor.Data.RetailerList
                    filterValueComboBox.DataSource = mdaObj

                Case "DEFAULTMKTID"
                    mdaObj = expObj.fetch(2)
                    filterValueComboBox.Enabled = True
                    filterValueTextBox.Enabled = True
                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "MktId"
                    'filterValueComboBox.DataSource = Processor.Data.MarketList
                    filterValueComboBox.DataSource = mdaObj
                Case "REGIONRETID"
                    filterValueComboBox.Enabled = True
                    filterValueTextBox.Enabled = True
                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "RetId"
                    filterValueComboBox.DataSource = Processor.Data.RetailerList

                Case "RETID"
                    mdaObj = expObj.fetch(3)
                    If tableName.ToUpper() = "RET" Then
                        filterValueComboBox.DisplayMember = "RetId"
                        filterValueComboBox.ValueMember = "RetId"
                        filterValueComboBox.DataSource = Processor.Data.RetailerList.Select("", "RetId ASC")
                    ElseIf tableName.ToUpper() = "SENDEREXPECTATION" Then
                        filterValueComboBox.DisplayMember = "Descrip"
                        filterValueComboBox.ValueMember = "RetId"
                        'filterValueComboBox.DataSource = Processor.Data.Ret
                        filterValueComboBox.DataSource = mdaObj
                    Else
                        filterValueComboBox.DisplayMember = "Descrip"
                        filterValueComboBox.ValueMember = "RetId"
                        filterValueComboBox.DataSource = Processor.Data.RetailerList
                    End If
                    filterValueComboBox.Enabled = True
                    filterValueTextBox.Enabled = True
                Case "FORCERUNIND"
                    filterValueComboBox.Enabled = True
                    filterValueTextBox.Enabled = True
                    filterValueComboBox.DisplayMember = "IdColumn"
                    filterValueComboBox.ValueMember = "IdValue"
                    filterValueComboBox.DataSource = Processor.Data.WebsitePageDownloadValues
                Case "ACTIVEIND"
                    filterValueComboBox.Enabled = True
                    filterValueTextBox.Enabled = True
                    filterValueComboBox.DisplayMember = "IdColumn"
                    filterValueComboBox.ValueMember = "IdValue"
                    filterValueComboBox.DataSource = Processor.Data.WebsitePageDownloadValues
                Case "GETIMAGESMANUALLYIND"
                    filterValueComboBox.DisplayMember = "IdColumn"
                    filterValueComboBox.ValueMember = "IdValue"
                    filterValueComboBox.Enabled = True
                    filterValueTextBox.Enabled = True
                    filterValueComboBox.DataSource = Processor.Data.WebsitePageDownloadValues
                Case "MEDIAID"
                    If tableName.ToUpper() = "MEDIA" Then
                        filterValueComboBox.DisplayMember = "MediaId"
                        filterValueComboBox.ValueMember = "MediaId"
                        If Processor.Data.MediaList.Count > 0 Then
                            filterValueComboBox.DataSource = Processor.Data.MediaList.Select("", "MediaId ASC")
                        Else
                            filterValueComboBox.DataSource = Processor.Data.Media.Select("", "MediaId ASC")
                        End If
                    Else
                        filterValueComboBox.DisplayMember = "Descrip"
                        filterValueComboBox.ValueMember = "MediaId"
                        If Processor.Data.MediaList.Count > 0 Then
                            filterValueComboBox.DataSource = Processor.Data.MediaList
                        Else
                            mdaObj = expObj.fetch(1)
                            'filterValueComboBox.DataSource = Processor.Data.Media
                            filterValueComboBox.DataSource = mdaObj
                        End If
                    End If

                    filterValueComboBox.Visible = True
                    filterValueTextBox.Visible = False
                Case "TRADECLASSID"
                    If Processor.Data.TradeClassList.Rows.Count = 0 Then Processor.LoadAllTradeclasses()
                    If tableName.ToUpper() = "TRADECLASS" Then
                        filterValueComboBox.DisplayMember = "TradeclassId"
                    Else
                        filterValueComboBox.DisplayMember = "Descrip"
                    End If
                    filterValueComboBox.ValueMember = "TradeclassId"
                    If Processor.Data.TradeClassList.Rows.Count <> 0 Then
                        filterValueComboBox.DataSource = Processor.Data.TradeClassList
                    Else
                        filterValueComboBox.DataSource = Processor.Data.TradeClass
                    End If

                Case "SENDERID"
                    If tableName.ToUpper() = "SENDER" Then
                        filterValueComboBox.DisplayMember = "SenderId"
                    Else
                        filterValueComboBox.DisplayMember = "Name"
                    End If
                    filterValueComboBox.ValueMember = "SenderId"
                    filterValueComboBox.DataSource = Processor.Data.SenderList

                    filterValueComboBox.Visible = True
                    filterValueTextBox.Visible = False

                Case "MKTID"
                    If tableName.ToUpper() = "MKT" Then
                        filterValueComboBox.DisplayMember = "MktId"
                        filterValueComboBox.ValueMember = "MktId"
                        If Processor.Data.MarketList.Count > 0 Then
                            filterValueComboBox.DataSource = Processor.Data.MarketList.Select("", "MktId ASC")
                        Else
                            filterValueComboBox.DataSource = Processor.Data.Mkt.Select("", "MktId ASC")
                        End If
                    Else
                        filterValueComboBox.DisplayMember = "Descrip"
                        filterValueComboBox.ValueMember = "MktId"
                        If Processor.Data.MarketList.Count > 0 Then
                            filterValueComboBox.DataSource = Processor.Data.MarketList
                        Else
                            mdaObj = expObj.fetch(2)
                            'filterValueComboBox.DataSource = Processor.Data.Mkt
                            filterValueComboBox.DataSource = mdaObj
                        End If
                    End If

                    filterValueComboBox.Visible = True
                    filterValueTextBox.Visible = False
                Case "EXPECTATIONID"
                    'Dim tempView As System.Data.DataView
                    'If tableName.ToUpper = "SENDEREXPECTATION" Then
                    '    Processor.LoadExpectationList(0, 0, 0, False)
                    'End If

                    'tempView = New System.Data.DataView(Processor.Data.Expectation)
                    'tempView.Sort = "ExpectationId"
                    'filterValueComboBox.DisplayMember = "ExpectationId"
                    'filterValueComboBox.ValueMember = "ExpectationId"
                    'filterValueComboBox.DataSource = tempView
                    'tempView = Nothing
                    filterValueComboBox.Visible = False
                    filterValueTextBox.Visible = True
                Case "LANGUAGEID"
                    If tableName.ToUpper() = "LANGUAGE" Then
                        filterValueComboBox.DisplayMember = "LanguageId"
                        filterValueComboBox.ValueMember = "LanguageId"
                        filterValueComboBox.DataSource = Processor.Data.Language.Select("", "LanguageId ASC")
                    Else
                        filterValueComboBox.DisplayMember = "Descrip"
                        filterValueComboBox.ValueMember = "LanguageId"
                        filterValueComboBox.DataSource = Processor.Data.Language
                    End If


                Case "SHIPPERID"
                    Dim tempView As System.Data.DataView

                    tempView = New System.Data.DataView(Processor.Data.Shipper)
                    tempView.Sort = "ShipperId"
                    filterValueComboBox.DisplayMember = "ShipperId"
                    filterValueComboBox.ValueMember = "ShipperId"
                    filterValueComboBox.DataSource = tempView
                    tempView = Nothing

                Case "SIZEID", "ROPSIZEID", "MAGSIZEID"
                    Dim tempView As System.Data.DataView
                    'If Processor.Data.Size.Rows.Count = 0 Then Processor.LoadAllSizes()
                    tempView = New System.Data.DataView(Processor.Data.Size)
                    tempView.Sort = "SizeId"
                    If tableName.ToUpper() = "SIZE" Then
                        filterValueComboBox.DisplayMember = "SizeId"
                        filterValueComboBox.ValueMember = "SizeId"
                        filterValueComboBox.DataSource = LoadID("Size").Tables(0)
                    Else
                        filterValueComboBox.DisplayMember = "SizeText"
                        filterValueComboBox.ValueMember = "SizeId"
                        filterValueComboBox.DataSource = tempView
                    End If

                    tempView = Nothing

                Case "PUBLICATIONID"
                    If tableComboBox.Text <> "Publication" Then
                        filterValueComboBox.DisplayMember = "Descrip"
                        filterValueComboBox.ValueMember = "PublicationId"
                        filterValueComboBox.DataSource = Processor.Data.PublicationList
                    Else
                        filterValueComboBox.DisplayMember = "PublicationId"
                        filterValueComboBox.ValueMember = "PublicationId"
                        ' Processor.LoadAllPublications()
                        filterValueComboBox.DataSource = LoadID("Publication").Tables(0)
                    End If

                Case "FREQUENCYID"
                    If tableName.ToUpper() = "WEBSITEPAGEDOWNLOAD" Then
                        filterValueComboBox.DisplayMember = "Descrip"
                        filterValueComboBox.ValueMember = "CodeId"
                        filterValueComboBox.DataSource = Processor.Data.PageDownloadFrequency
                    Else
                        filterValueComboBox.DisplayMember = "Descrip"
                        filterValueComboBox.ValueMember = "CodeId"
                        filterValueComboBox.DataSource = Processor.Data.vwFrequency
                    End If

                Case "TYPEID" 'SenderType
                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "CodeId"
                    filterValueComboBox.DataSource = Processor.Data.vwSenderType

                Case "LOCATIONID"
                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "CodeId"
                    filterValueComboBox.DataSource = Processor.Data.vwLocation

                Case "EXPECTEDRECEIVEDT"
                    filterValueComboBox.DisplayMember = "Weekday"
                    filterValueComboBox.ValueMember = "WeekdayId"
                    filterValueComboBox.DataSource = Processor.Data.Weekdays

                Case "INDNEEDTRACKINGNO"
                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "CodeId"
                    filterValueComboBox.DataSource = Processor.Data.NeedTrackingNo

                Case "SCANDPI"
                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "Descrip"
                    filterValueComboBox.DataSource = Processor.Data.vwScanDPI

                Case "INDNOSHIPPING"
                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "CodeId"
                    filterValueComboBox.DataSource = Processor.Data.Shipping

                Case "INDNOPUBLICATIONS"
                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "CodeId"
                    filterValueComboBox.DataSource = Processor.Data.HasPublication

                Case "FREQUENCYID"
                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "CodeId"
                    filterValueComboBox.DataSource = Processor.Data.PageDownloadFrequency

                Case "PUBLICATION"
                    mdaObj = expObj.fetch(7)
                    Processor.LoadSubscriptionPublications()
                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "PublicationId"
                    filterValueComboBox.DataSource = mdaObj
                    'filterValueComboBox.DataSource = Processor.Data.PublicationList

                Case "PUBLICATIONSUBSCRIPTIONID"
                    Processor.LoadSubscriptionId()
                    filterValueComboBox.DisplayMember = "PublicationSubscriptionId"
                    filterValueComboBox.ValueMember = "PublicationSubscriptionId"
                    filterValueComboBox.DataSource = Processor.SubscriptionData.SubscriptionId

                Case "PAIDBY"
                    Processor.LoadSubscriptionPaidby()
                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "CodeId"
                    filterValueComboBox.DataSource = Processor.SubscriptionData.PaidByCode

                Case "RECEIPIENTTYPE"
                    Processor.LoadSubscriptionReceipientType()
                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "CodeId"
                    filterValueComboBox.DataSource = Processor.SubscriptionData.ReceipientTypeCode

                Case "PREPAIDPERIOD"
                    Processor.LoadSubscriptionPrepaidPeriod()
                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "CodeId"
                    filterValueComboBox.DataSource = Processor.SubscriptionData.PrepaidPeriodCode

                Case "AUTOPAY"
                    Processor.LoadSubscriptionYesNoIndicator()
                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "InternalDescrip"
                    filterValueComboBox.DataSource = Processor.SubscriptionData.YesNoCode

                Case "MARKET"
                    Processor.LoadSubscriptionMarket()
                    filterValueComboBox.DisplayMember = "Descrip"
                    filterValueComboBox.ValueMember = "MktId"
                    filterValueComboBox.DataSource = Processor.SubscriptionData.Mkt
                Case Else
                    filterValueComboBox.Items.Clear()
                    If tableName.ToUpper() = "WEBSITEPAGEDOWNLOAD" Then

                        'filterValueComboBox.Enabled = False
                        'filterValueTextBox.Enabled = False
                    End If
            End Select



        End Sub

        ''' <summary>
        ''' Fills in values into filter value drop down list. Values are filled 
        ''' based on selected table and column name.
        ''' </summary>
        ''' <param name="tableName">Name of the table for which preparing the drop down list.</param>
        ''' <param name="columnName">Name of the field of the table. Drop down list will contain values for this field.</param>
        ''' <remarks></remarks>
        Private Sub SetFilterValue2DropDownList(ByVal tableName As String, ByVal columnName As String)

            filterValue2ComboBox.DataSource = Nothing

            Select Case columnName.ToUpper()
                Case "ROLEID"
                    filterValue2ComboBox.Enabled = True
                    filterValue2ComboBox.Enabled = True

                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "RoleId"
                    filterValue2ComboBox.DataSource = Processor.DESPData.Role

                Case "STOREDPROCEDUREID"
                    filterValue2ComboBox.Enabled = True
                    filterValue2ComboBox.Enabled = True

                    If tableName <> "DESP_StoredProcedureMaintenance" Then
                        filterValue2ComboBox.DisplayMember = "ProcedureDetails"
                        filterValue2ComboBox.ValueMember = "StoredProcedureId"
                        filterValue2ComboBox.DataSource = Processor.DESPData.DESP_StoredProcedure
                    Else
                        filterValue2ComboBox.DisplayMember = "StoredProcedureId"
                        filterValue2ComboBox.ValueMember = "StoredProcedureId"
                        filterValue2ComboBox.DataSource = Processor.DESPData.DESP_StoredProcedureMaintenance
                    End If

                Case "SITEID"
                    filterValue2ComboBox.Enabled = True
                    filterValue2TextBox.Enabled = True
                    If tableComboBox.Text <> "Site" Then
                        filterValue2ComboBox.DisplayMember = "Descrip"
                        filterValue2ComboBox.ValueMember = "SiteId"
                        filterValue2ComboBox.DataSource = Processor.Data.Site
                    Else
                        filterValue2ComboBox.DisplayMember = "SiteId"
                        filterValue2ComboBox.ValueMember = "SiteId"
                        filterValue2ComboBox.DataSource = LoadID("Site").Tables(0)
                    End If


                Case "DEFAULTRETID"
                    filterValue2ComboBox.Enabled = True
                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "RetId"
                    filterValue2ComboBox.DataSource = Processor.Data.RetailerList

                Case "DEFAULTMKTID"
                    filterValue2ComboBox.Enabled = True
                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "MktId"
                    filterValue2ComboBox.DataSource = Processor.Data.MarketList
                Case "REGIONRETID"
                    filterValue2ComboBox.Enabled = True
                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "RetId"
                    filterValue2ComboBox.DataSource = Processor.Data.RetailerList
                Case "RETID"
                    If tableName.ToUpper() = "RET" Then
                        filterValue2ComboBox.DisplayMember = "RetId"
                        filterValue2ComboBox.ValueMember = "RetId"
                        If Processor.Data.RetailerList.Rows.Count > 0 Then
                            filterValue2ComboBox.DataSource = Processor.Data.RetailerList.Select("", "RetId ASC")
                        Else
                            filterValue2ComboBox.DataSource = Processor.Data.Ret.Select("", "RetId ASC")
                        End If
                    Else
                        filterValue2ComboBox.DisplayMember = "Descrip"
                        filterValue2ComboBox.ValueMember = "RetId"
                        If Processor.Data.RetailerList.Rows.Count > 0 Then
                            filterValue2ComboBox.DataSource = Processor.Data.RetailerList
                        Else
                            filterValue2ComboBox.DataSource = Processor.Data.Ret
                        End If
                    End If

                Case "MEDIAID"
                    If tableName.ToUpper() = "MEDIA" Then
                        filterValue2ComboBox.DisplayMember = "MediaId"
                        filterValue2ComboBox.ValueMember = "MediaId"
                        If Processor.Data.MediaList.Count > 0 Then
                            filterValue2ComboBox.DataSource = Processor.Data.MediaList.Select("", "MediaId ASC")
                        Else
                            filterValue2ComboBox.DataSource = Processor.Data.Media.Select("", "MediaId ASC")
                        End If
                    Else
                        filterValue2ComboBox.DisplayMember = "Descrip"
                        filterValue2ComboBox.ValueMember = "MediaId"
                        If Processor.Data.MediaList.Count > 0 Then
                            filterValue2ComboBox.DataSource = Processor.Data.MediaList
                        Else
                            filterValue2ComboBox.DataSource = Processor.Data.Media
                        End If
                    End If


                Case "TRADECLASSID"
                    If tableName.ToUpper() = "TRADECLASS" Then
                        filterValue2ComboBox.DisplayMember = "TradeclassId"
                    Else
                        filterValue2ComboBox.DisplayMember = "Descrip"
                    End If
                    filterValue2ComboBox.ValueMember = "TradeclassId"
                    filterValue2ComboBox.DataSource = Processor.Data.TradeClassList

                Case "SENDERID"
                    If tableName.ToUpper() = "SENDER" Then
                        filterValue2ComboBox.DisplayMember = "SenderId"
                    Else
                        filterValue2ComboBox.DisplayMember = "Name"
                    End If
                    filterValue2ComboBox.ValueMember = "SenderId"
                    filterValue2ComboBox.DataSource = Processor.Data.SenderList

                Case "MKTID"
                    If tableName.ToUpper() = "MKT" Then
                        filterValue2ComboBox.DisplayMember = "MktId"
                        filterValue2ComboBox.ValueMember = "MktId"
                        If Processor.Data.MarketList.Rows.Count > 0 Then
                            filterValue2ComboBox.DataSource = Processor.Data.MarketList.Select("", "MktId ASC")
                        Else
                            filterValue2ComboBox.DataSource = Processor.Data.Mkt.Select("", "MktId ASC")
                        End If
                    Else
                        filterValue2ComboBox.DisplayMember = "Descrip"
                        filterValue2ComboBox.ValueMember = "MktId"
                        If Processor.Data.MarketList.Rows.Count > 0 Then
                            filterValue2ComboBox.DataSource = Processor.Data.MarketList
                        Else
                            filterValue2ComboBox.DataSource = Processor.Data.Mkt
                        End If
                    End If


                Case "EXPECTATIONID"
                    'Dim tempView As System.Data.DataView
                    'If tableName.ToUpper = "SENDEREXPECTATION" Then
                    '    Processor.LoadExpectationList(0, 0, 0, False)
                    'End If
                    'tempView = New System.Data.DataView(Processor.Data.Expectation)
                    'tempView.Sort = "ExpectationId"
                    'filterValue2ComboBox.DisplayMember = "ExpectationId"
                    'filterValue2ComboBox.ValueMember = "ExpectationId"
                    'filterValue2ComboBox.DataSource = tempView
                    'tempView = Nothing

                Case "LANGUAGEID"
                    If tableName.ToUpper() = "LANGUAGE" Then
                        filterValue2ComboBox.DisplayMember = "LanguageId"
                        filterValue2ComboBox.ValueMember = "LanguageId"
                        filterValue2ComboBox.DataSource = Processor.Data.Language.Select("", "LanguageId ASC")
                    Else
                        filterValue2ComboBox.DisplayMember = "Descrip"
                        filterValue2ComboBox.ValueMember = "LanguageId"
                        filterValue2ComboBox.DataSource = Processor.Data.Language
                    End If


                Case "SHIPPERID"
                    Dim tempView As System.Data.DataView

                    tempView = New System.Data.DataView(Processor.Data.Shipper)
                    tempView.Sort = "ShipperId"
                    filterValue2ComboBox.DisplayMember = "ShipperId"
                    filterValue2ComboBox.ValueMember = "ShipperId"
                    filterValue2ComboBox.DataSource = tempView
                    tempView = Nothing

                Case "SIZEID", "ROPSIZEID", "MAGSIZEID"
                    Dim tempView As System.Data.DataView
                    If Processor.Data.Size.Rows.Count = 0 Then Processor.LoadAllSizes()
                    tempView = New System.Data.DataView(Processor.Data.Size)
                    tempView.Sort = "SizeId"
                    If tableName.ToUpper() = "SIZE" Then
                        filterValue2ComboBox.DisplayMember = "SizeId"
                    Else
                        filterValue2ComboBox.DisplayMember = "SizeText"
                    End If
                    filterValue2ComboBox.ValueMember = "SizeId"
                    filterValue2ComboBox.DataSource = tempView
                    tempView = Nothing

                Case "PUBLICATIONID"
                    If tableComboBox.Text <> "Publication" Then
                        Processor.LoadSubscriptionPublications()
                        filterValue2ComboBox.DisplayMember = "Descrip"
                        filterValue2ComboBox.ValueMember = "PublicationId"
                        filterValue2ComboBox.DataSource = Processor.Data.PublicationList
                        'filterValue2ComboBox.DataSource = Processor.SubscriptionData.Publication
                    Else
                        filterValue2ComboBox.DisplayMember = "PublicationId"
                        filterValue2ComboBox.ValueMember = "PublicationId"
                        filterValue2ComboBox.DataSource = LoadID("Publication").Tables(0)
                    End If

                Case "FREQUENCYID"
                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "CodeId"
                    filterValue2ComboBox.DataSource = Processor.Data.vwFrequency

                Case "TYPEID" 'SenderType
                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "CodeId"
                    filterValue2ComboBox.DataSource = Processor.Data.vwSenderType

                Case "LOCATIONID"
                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "CodeId"
                    filterValue2ComboBox.DataSource = Processor.Data.vwLocation

                Case "EXPECTEDRECEIVEDT"
                    filterValue2ComboBox.DisplayMember = "Weekday"
                    filterValue2ComboBox.ValueMember = "WeekdayId"
                    filterValue2ComboBox.DataSource = Processor.Data.Weekdays

                Case "INDNEEDTRACKINGNO"
                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "CodeId"
                    filterValue2ComboBox.DataSource = Processor.Data.NeedTrackingNo

                Case "SCANDPI"
                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "Descrip"
                    filterValue2ComboBox.DataSource = Processor.Data.vwScanDPI

                Case "INDNOSHIPPING"
                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "CodeId"
                    filterValue2ComboBox.DataSource = Processor.Data.Shipping

                Case "INDNOPUBLICATIONS"
                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "CodeId"
                    filterValue2ComboBox.DataSource = Processor.Data.HasPublication

                Case "PUBLICATION"
                    Processor.LoadSubscriptionPublications()
                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "PublicationId"
                    filterValue2ComboBox.DataSource = Processor.SubscriptionData.Publication



                Case "PUBLICATIONSUBSCRIPTIONID"
                    Processor.LoadSubscriptionId()
                    filterValue2ComboBox.DisplayMember = "PublicationSubscriptionId"
                    filterValue2ComboBox.ValueMember = "PublicationSubscriptionId"
                    filterValue2ComboBox.DataSource = Processor.SubscriptionData.SubscriptionId

                Case "PAIDBY"
                    Processor.LoadSubscriptionPaidby()
                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "CodeId"
                    filterValue2ComboBox.DataSource = Processor.SubscriptionData.PaidByCode

                Case "RECEIPIENTTYPE"
                    Processor.LoadSubscriptionReceipientType()
                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "CodeId"
                    filterValue2ComboBox.DataSource = Processor.SubscriptionData.ReceipientTypeCode

                Case "PREPAIDPERIOD"
                    Processor.LoadSubscriptionPrepaidPeriod()
                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "CodeId"
                    filterValue2ComboBox.DataSource = Processor.SubscriptionData.PrepaidPeriodCode

                Case "AUTOPAY"
                    Processor.LoadSubscriptionYesNoIndicator()
                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "InternalDescrip"
                    filterValue2ComboBox.DataSource = Processor.SubscriptionData.YesNoCode

                Case "MARKET"
                    Processor.LoadSubscriptionMarket()
                    filterValue2ComboBox.DisplayMember = "Descrip"
                    filterValue2ComboBox.ValueMember = "MktId"
                    filterValue2ComboBox.DataSource = Processor.SubscriptionData.Mkt
                Case Else
                    filterValue2ComboBox.Items.Clear()
            End Select

        End Sub

        Private Function LoadID(ByVal tablename As String) As DataSet
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim adpt As System.Data.SqlClient.SqlDataAdapter
            Dim val As DataSet


            cmd = New System.Data.SqlClient.SqlCommand
            val = New DataSet
            Try
                With cmd
                    If tablename = "Site" Then
                        .CommandText = "SELECT Siteid FROM Site Order By SiteId ASC"
                    ElseIf tablename = "Publication" Then
                        .CommandText = "SELECT PublicationId FROM Publication ORDER BY PublicationId ASC"
                    ElseIf tablename = "Size" Then
                        .CommandText = "SELECT SizeId FROM Size ORDER BY SizeId ASC"
                    End If
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                End With
                adpt = New System.Data.SqlClient.SqlDataAdapter(cmd)

                adpt.Fill(val)

            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return val
        End Function

        ''' <summary>
        ''' Deletes row from database using table adapter.
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub DeleteRowsFromDataBase()
            Dim tempTable As Data.DataTable

            If maintenanceDataGridView.DataSource Is Nothing Then Exit Sub

            tempTable = CType(maintenanceDataGridView.DataSource, Data.DataTable)
            tempTable = tempTable.GetChanges(DataRowState.Deleted)

            If tempTable Is Nothing OrElse tempTable.Rows.Count = 0 Then
                MessageBox.Show("Cannot detect any deletion(s). Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                tempTable = Nothing
                Exit Sub
            End If

            Select Case maintenanceDataGridView.DataSource.GetType.ToString().ToUpper()
                Case "MCAP.DESPROLEASSOC+DESP_STOREDPROCEDUREMAINTENANCEDATATABLE"
                    Processor.DeleteDESPProcedures(CType(tempTable, MCAP.DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable))
                Case "MCAP.DESPROLEASSOC+DESP_STOREDPROCEDUREROLEASSOCDATATABLE"
                    Processor.DeleteDESPRoleAssoc(CType(tempTable, MCAP.DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable))

                Case "MCAP.MAINTENANCEDATASET+EXPECTATIONDATATABLE"
                    Processor.DeleteExpectations(CType(tempTable, MCAP.MaintenanceDataSet.ExpectationDataTable))

                Case "MCAP.MAINTENANCEDATASET+LANGUAGEDATATABLE"
                    Processor.DeleteLanguages(CType(tempTable, MCAP.MaintenanceDataSet.LanguageDataTable))

                Case "MCAP.MAINTENANCEDATASET+MEDIADATATABLE"
                    Processor.DeleteMedia(CType(tempTable, MCAP.MaintenanceDataSet.MediaDataTable))

                Case "MCAP.MAINTENANCEDATASET+RETDATATABLE"
                    Processor.DeleteRet(CType(tempTable, MCAP.MaintenanceDataSet.RetDataTable))

                Case "MCAP.MAINTENANCEDATASET+MKTDATATABLE"
                    Processor.DeleteMkt(CType(tempTable, MCAP.MaintenanceDataSet.MktDataTable))

                Case "MCAP.MAINTENANCEDATASET+PUBLICATIONDATATABLE"
                    Processor.DeletePublication(CType(tempTable, MCAP.MaintenanceDataSet.PublicationDataTable))

                Case "MCAP.MAINTENANCEDATASET+RETPUBLICATIONCOVERAGEDATATABLE"
                    Processor.DeleteRetPublicationCoverage(CType(tempTable, MCAP.MaintenanceDataSet.RetPublicationCoverageDataTable))

                Case "MCAP.MAINTENANCEDATASET+SENDERDATATABLE"
                    Processor.DeleteSender(CType(tempTable, MCAP.MaintenanceDataSet.SenderDataTable))

                Case "MCAP.MAINTENANCEDATASET+SENDERMKTASSOCDATATABLE"
                    Processor.DeleteSenderMktAssoc(CType(tempTable, MCAP.MaintenanceDataSet.SenderMktAssocDataTable))

                Case "MCAP.MAINTENANCEDATASET+SENDERPUBLICATIONDATATABLE"
                    Processor.DeleteSenderPublication(CType(tempTable, MCAP.MaintenanceDataSet.SenderPublicationDataTable))

                Case "MCAP.MAINTENANCEDATASET+SENDEREXPECTATIONDATATABLE"
                    Processor.DeleteSenderExpectation(CType(tempTable, MCAP.MaintenanceDataSet.SenderExpectationDataTable))
                    Processor.RefreshSenderExpectation()

                Case "MCAP.MAINTENANCEDATASET+SHIPPERDATATABLE"
                    Processor.DeleteShipper(CType(tempTable, MCAP.MaintenanceDataSet.ShipperDataTable))

                Case "MCAP.MAINTENANCEDATASET+SIZEDATATABLE"
                    Processor.DeleteSize(CType(tempTable, MCAP.MaintenanceDataSet.SizeDataTable))

                Case "MCAP.MAINTENANCEDATASET+TRADECLASSDATATABLE"
                    Processor.DeleteTradeclass(CType(tempTable, MCAP.MaintenanceDataSet.TradeClassDataTable))
                    'Processor.Data.TradeClass.Merge(tempTable)
                    'Processor.Data.TradeClass.AcceptChanges()
                Case "MCAP.MAINTENANCEDATASET+WEBSITEPAGEDOWNLOADDATATABLE"
                    Processor.DeleteWebsite(CType(tempTable, MCAP.MaintenanceDataSet.WebsitePageDownloadDataTable))
                Case "MCAP.MAINTENANCEDATASET+SITEDATATABLE"
                    'Processor.DeleteWebsite(CType(tempTable, MCAP.MaintenanceDataSet.WebsitePageDownloadDataTable))
                    Processor.DeleteSite(CType(tempTable, MCAP.MaintenanceDataSet.SiteDataTable))
                Case "MCAP.SUBSCRIPTIONDATASET+PUBLICATIONSUBSCRIPTIONDATATABLE"
                    Processor.DeletePublicationSubscription(CType(tempTable, MCAP.SubscriptionDataSet.PublicationSubscriptionDataTable))

            End Select

            tempTable = Nothing

        End Sub

        Private Sub MaintenanceForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing

            If tableComboBox.Text = "SenderExpectation" Then Exit Sub
            If Processor.Data.HasChanges() Then
                Dim userResponse As System.Windows.Forms.DialogResult
                Dim confirmationMessage As String


                confirmationMessage = "Unsaved changes exist in {0}.{1}Are you sure, you will lose all unsaved changes?"

                userResponse = MessageBox.Show(String.Format(confirmationMessage, tableComboBox.Text, Environment.NewLine) _
                                               , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                               , MessageBoxDefaultButton.Button2)
                If userResponse = Windows.Forms.DialogResult.No Then e.Cancel = True
            End If

        End Sub

        Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

            Dim _media As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
            Dim _market As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
            Dim _retailer As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
            Dim _sender As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
            Dim _expid As DataGridViewTextBoxCell = New DataGridViewTextBoxCell

            _media.Value = orig_media
            If orig_media IsNot Nothing Then maintenanceDataGridView(1, previousRow) = _media
            _market.Value = orig_mkt
            If orig_mkt IsNot Nothing Then maintenanceDataGridView(2, previousRow) = _market
            _retailer.Value = orig_ret
            If orig_ret IsNot Nothing Then maintenanceDataGridView(3, previousRow) = _retailer
            _sender.Value = orig_sender
            If orig_sender IsNot Nothing Then
                _expid.Value = -1
                maintenanceDataGridView(0, previousRow) = _sender
                maintenanceDataGridView(5, previousRow) = _expid
            End If
            Me.Close()

        End Sub

        Private Sub applyButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles applyButton.Click
            Dim bmb As BindingManagerBase

            bmb = Me.BindingContext(Me.maintenanceDataGridView.DataSource, Me.maintenanceDataGridView.DataMember)
            If bmb.Count = 0 Then Exit Sub

            If bmb.Current Is Nothing Then Exit Sub
            If CType(bmb.Current, Data.DataRowView).Row.RowState = DataRowState.Added Then
                addMaintenanceTables()
            Else
                updateMaintenanceTables()
            End If

            'maintenanceDataGridView.Refresh()
        End Sub

        Private Sub updateMaintenanceTables()
            Dim tempTable As Data.DataTable

            If _InsertStatus = True Then
                _InsertStatus = False
                Exit Sub
            End If

            _DataRefresh = True
            If maintenanceDataGridView.DataSource Is Nothing Then Exit Sub

            tempTable = CType(maintenanceDataGridView.DataSource, Data.DataTable)
            tempTable = tempTable.GetChanges(DataRowState.Modified)

            If tempTable Is Nothing OrElse tempTable.Rows.Count = 0 Then
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                tempTable = Nothing
                Exit Sub
            End If

            Dim tempstr As String = maintenanceDataGridView.DataSource.GetType.ToString().ToUpper()

            Select Case maintenanceDataGridView.DataSource.GetType.ToString().ToUpper()
                Case "MCAP.DESPROLEASSOC+DESP_STOREDPROCEDUREMAINTENANCEDATATABLE"
                    Processor.UpdateDESPProcedures(Processor.DESPData.DESP_StoredProcedureMaintenance)

                Case "MCAP.DESPROLEASSOC+DESP_STOREDPROCEDUREROLEASSOCDATATABLE"
                    Processor.UpdateDESPRoleAssoc(Processor.DESPData.DESP_StoredProcedureRoleAssoc)

                Case "MCAP.MAINTENANCEDATASET+EXPECTATIONDATATABLE"
                    Processor.UpdateExpectations(Processor.Data.Expectation)

                Case "MCAP.MAINTENANCEDATASET+LANGUAGEDATATABLE"
                    Processor.UpdateLanguages(Processor.Data.Language)

                Case "MCAP.MAINTENANCEDATASET+MEDIADATATABLE"
                    Processor.UpdateMedia(Processor.Data.Media)

                Case "MCAP.MAINTENANCEDATASET+RETDATATABLE"
                    Processor.UpdateRet(Processor.Data.Ret)

                Case "MCAP.MAINTENANCEDATASET+MKTDATATABLE"
                    Processor.UpdateMkt(Processor.Data.Mkt)

                Case "MCAP.MAINTENANCEDATASET+PUBLICATIONDATATABLE"
                    Processor.UpdatePublication(Processor.Data.Publication)

                Case "MCAP.MAINTENANCEDATASET+RETPUBLICATIONCOVERAGEDATATABLE"
                    Processor.UpdateRetPublicationCoverage(Processor.Data.RetPublicationCoverage)

                Case "MCAP.MAINTENANCEDATASET+SENDERDATATABLE"
                    Processor.UpdateSender(Processor.Data.Sender)

                Case "MCAP.MAINTENANCEDATASET+SENDERMKTASSOCDATATABLE"
                    Processor.UpdateSenderMktAssoc(Processor.Data.SenderMktAssoc)

                Case "MCAP.MAINTENANCEDATASET+SHIPPERDATATABLE"
                    Processor.UpdateShipper(Processor.Data.Shipper)

                Case "MCAP.MAINTENANCEDATASET+SIZEDATATABLE"
                    Processor.UpdateSize(Processor.Data.Size)

                Case "MCAP.MAINTENANCEDATASET+TRADECLASSDATATABLE"
                    Processor.UpdateTradeclass(Processor.Data.TradeClass)
                Case "MCAP.MAINTENANCEDATASET+WEBSITEPAGEDOWNLOADDATATABLE"
                    Processor.UpdateWebsite(Processor.Data.WebsitePageDownload)
                Case "MCAP.MAINTENANCEDATASET+SITEDATATABLE"
                    Processor.UpdateSite(Processor.Data.Site)
                Case "MCAP.MAINTENANCEDATASET+SENDERPUBLICATIONDATATABLE"
                    Processor.UpdateSenderPublication(Processor.Data.SenderPublication)
                Case "MCAP.MAINTENANCEDATASET+SENDEREXPECTATIONDATATABLE"
                    If CInt(maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value) > 0 Then
                        maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value = ProcessExpectationId()
                        If CInt(maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value) = -1 Then

                            'MsgBox("Invalid ExpectationID, it's either the data is not existing in the Expectation Table or have reached the End Date.", MsgBoxStyle.Exclamation, "MCAP")
                            MsgBox("The expectation Id that you're trying to process is not valid. It's either it has reached the End Date of the record or the combination of Media, Market and Retailer are not existing in the Expectation Table.", MsgBoxStyle.Exclamation, "MCAP")
                            maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value = ""
                            Exit Sub
                        End If

                        Dim startDate As Object = Nothing
                        Dim endDate As Object = Nothing

                        If String.IsNullOrEmpty(maintenanceDataGridView.CurrentRow.Cells("startDtCalendarColumn").Value.ToString()) Then
                            startDate = Nothing
                        Else
                            startDate = CDate(maintenanceDataGridView.CurrentRow.Cells("startDtCalendarColumn").Value)
                        End If
                        If String.IsNullOrEmpty(maintenanceDataGridView.CurrentRow.Cells("endDtCalendarColumn").Value.ToString()) Then
                            endDate = Nothing
                        Else
                            endDate = CDate(maintenanceDataGridView.CurrentRow.Cells("endDtCalendarColumn").Value)
                        End If
                        Processor.UpdateSenderExpectation(Processor.Data.SenderExpectation, CInt(maintenanceDataGridView.CurrentRow.Cells(5).Value), startDate, endDate, CInt(maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value))
                        'Processor.RefreshSenderExpectation()
                        filterButton.PerformClick()

                    Else
                        MsgBox("The expectation Id that you're trying to process is not valid. It's either it has reached the End Date of the record or the combination of Media, Market and Retailer are not existing in the Expectation Table.", MsgBoxStyle.Exclamation, "MCAP")
                    End If
                Case "MCAP.SUBSCRIPTIONDATASET+PUBLICATIONSUBSCRIPTIONDATATABLE"
                    Processor.UpdatePublicationSubscription(Processor.SubscriptionData.PublicationSubscription)
            End Select
            tempTable = Nothing
            _DataRefresh = False
            IsComboLoaded = False
        End Sub

        Private Sub addMaintenanceTables()

            'Dim bmb As BindingManagerBase

            'bmb = Me.BindingContext(Me.maintenanceDataGridView.DataSource, Me.maintenanceDataGridView.DataMember)
            'If e.RowIndex = 0 AndAlso bmb.Count = 0 Then Exit Sub
            'If e.RowIndex = bmb.Count Then Exit Sub
            'If bmb.Current Is Nothing _
            '  OrElse CType(bmb.Current, Data.DataRowView).Row.RowState <> DataRowState.Added _
            'Then Exit Sub

            Dim tmpStr As String = maintenanceDataGridView.DataSource.GetType.ToString().ToUpper()
            _InsertStatus = True
            Select Case maintenanceDataGridView.DataSource.GetType.ToString().ToUpper()
                Case "MCAP.DESPROLEASSOC+DESP_STOREDPROCEDUREMAINTENANCEDATATABLE"
                    'If Processor.DESPData.DESP_StoredProcedureMaintenanceDataTable.LoadingTable Then Exit Sub
                    Dim tempTable As DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable
                    tempTable = CType(Processor.DESPData.DESP_StoredProcedureMaintenance.GetChanges(DataRowState.Added) _
                                      , DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable)
                    Processor.InsertDESProcedures(tempTable)
                Case "MCAP.DESPROLEASSOC+DESP_STOREDPROCEDUREROLEASSOCDATATABLE"
                    If Processor.DESPData.DESP_StoredProcedureRoleAssoc.LoadingTable Then Exit Sub
                    Dim tempTable As DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable
                    tempTable = CType(Processor.DESPData.DESP_StoredProcedureRoleAssoc.GetChanges(DataRowState.Added) _
                                      , DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable)
                    Processor.InsertDESPRoleAssoc(tempTable)
                Case "MCAP.MAINTENANCEDATASET+EXPECTATIONDATATABLE"
                    If Processor.Data.Expectation.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.ExpectationDataTable
                    tempTable = CType(Processor.Data.Expectation.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.ExpectationDataTable)
                    If tempTable(0).RetId > 0 And tempTable(0).MktId > 0 And tempTable(0).MediaId > 0 Then
                        Processor.InsertExpectation(tempTable)
                    End If

                Case "MCAP.MAINTENANCEDATASET+LANGUAGEDATATABLE"
                    If Processor.Data.Language.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.LanguageDataTable
                    tempTable = CType(Processor.Data.Language.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.LanguageDataTable)
                    Processor.InsertLanguage(tempTable)

                Case "MCAP.MAINTENANCEDATASET+MEDIADATATABLE"
                    If Processor.Data.Media.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.MediaDataTable
                    tempTable = CType(Processor.Data.Media.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.MediaDataTable)
                    Processor.InsertMedia(tempTable)

                Case "MCAP.MAINTENANCEDATASET+RETDATATABLE"
                    If Processor.Data.Ret.LoadingTable Then Exit Sub
                    Processor.InsertRet(Processor.Data.Ret)

                Case "MCAP.MAINTENANCEDATASET+MKTDATATABLE"
                    If Processor.Data.RetMktCustomDescrip.LoadingTable Then Exit Sub

                    Processor.InsertMkt(Processor.Data.Mkt)

                Case "MCAP.MAINTENANCEDATASET+PUBLICATIONDATATABLE"
                    If Processor.Data.RetMktCustomDescrip.LoadingTable Then Exit Sub

                    Processor.InsertPublication(Processor.Data.Publication)

                Case "MCAP.MAINTENANCEDATASET+RETPUBLICATIONCOVERAGEDATATABLE"
                    If Processor.Data.RetPublicationCoverage.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.RetPublicationCoverageDataTable
                    tempTable = CType(Processor.Data.RetPublicationCoverage.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.RetPublicationCoverageDataTable)
                    Processor.InsertRetPublicationCoverage(tempTable)

                Case "MCAP.MAINTENANCEDATASET+SENDERDATATABLE"
                    If Processor.Data.Sender.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.SenderDataTable
                    tempTable = CType(Processor.Data.Sender.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.SenderDataTable)
                    Processor.InsertSender(tempTable)

                Case "MCAP.MAINTENANCEDATASET+SENDERMKTASSOCDATATABLE"
                    If Processor.Data.SenderMktAssoc.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.SenderMktAssocDataTable
                    tempTable = CType(Processor.Data.SenderMktAssoc.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.SenderMktAssocDataTable)

                    Processor.InsertSenderMktAssoc(tempTable)

                Case "MCAP.MAINTENANCEDATASET+SENDERPUBLICATIONDATATABLE"
                    If Processor.Data.SenderPublication.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.SenderPublicationDataTable
                    tempTable = CType(Processor.Data.SenderPublication.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.SenderPublicationDataTable)
                    Processor.InsertSenderPublication(tempTable)
                    Processor.RefreshSenderPublication()

                Case "MCAP.MAINTENANCEDATASET+SENDEREXPECTATIONDATATABLE"
                    Dim StartDate, EndDate As Object
                    If Processor.Data.SenderExpectation.LoadingTable Then Exit Sub
                    If String.IsNullOrEmpty(maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value.ToString) = True Then maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value = ProcessExpectationId()
                    Dim tempTable As MaintenanceDataSet.SenderExpectationDataTable
                    tempTable = CType(Processor.Data.SenderExpectation.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.SenderExpectationDataTable)
                    If CInt(maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value) = -1 Then
                        MsgBox("The expectation Id that you're trying to process is not valid. It's either it has reached the End Date of the record or the combination of Media, Market and Retailer are not existing in the Expectation Table.", MsgBoxStyle.Exclamation, "MCAP")
                        maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value = ""
                        _med = 0
                        _mkt = 0
                        _ret = 0
                        Exit Sub
                    End If
                    If String.IsNullOrEmpty(maintenanceDataGridView.CurrentRow.Cells("startDtCalendarColumn").Value.ToString()) = True Then
                        StartDate = Nothing
                    Else
                        StartDate = CDate(maintenanceDataGridView.CurrentRow.Cells("startDtCalendarColumn").Value)
                    End If

                    If String.IsNullOrEmpty(maintenanceDataGridView.CurrentRow.Cells("endDtCalendarColumn").Value.ToString()) = True Then
                        EndDate = Nothing
                    Else
                        EndDate = CDate(maintenanceDataGridView.CurrentRow.Cells("endDtCalendarColumn").Value)
                    End If

                    Processor.InsertSenderExpectation(tempTable, CInt(maintenanceDataGridView.CurrentRow.Cells(5).Value), CInt(maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value), StartDate, EndDate)
                    Processor.RefreshSenderExpectation()
                    _med = 0
                    _mkt = 0
                    _ret = 0

                Case "MCAP.MAINTENANCEDATASET+SHIPPERDATATABLE"
                    If Processor.Data.Shipper.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.ShipperDataTable
                    tempTable = CType(Processor.Data.Shipper.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.ShipperDataTable)
                    Processor.InsertShipper(tempTable)

                Case "MCAP.MAINTENANCEDATASET+SIZEDATATABLE"
                    If Processor.Data.Size.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.SizeDataTable
                    tempTable = CType(Processor.Data.Size.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.SizeDataTable)
                    Processor.InsertSize(tempTable)

                Case "MCAP.MAINTENANCEDATASET+TRADECLASSDATATABLE"
                    If Processor.Data.TradeClass.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.TradeClassDataTable
                    tempTable = CType(Processor.Data.TradeClass.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.TradeClassDataTable)
                    Processor.InsertTradeclass(tempTable)
                    _InsertStatus = False

                Case "MCAP.MAINTENANCEDATASET+WEBSITEPAGEDOWNLOADDATATABLE"

                    If Processor.Data.WebsitePageDownload.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.WebsitePageDownloadDataTable
                    tempTable = CType(Processor.Data.WebsitePageDownload.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.WebsitePageDownloadDataTable)
                    Processor.InsertWebsite(tempTable)
                Case "MCAP.MAINTENANCEDATASET+SITEDATATABLE"

                    If Processor.Data.Site.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.SiteDataTable
                    tempTable = CType(Processor.Data.Site.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.SiteDataTable)
                    Processor.InsertSite(tempTable)


                Case "MCAP.SUBSCRIPTIONDATASET+PUBLICATIONSUBSCRIPTIONDATATABLE"
                    If Processor.SubscriptionData.PublicationSubscription.LoadingTable Then Exit Sub
                    Dim tempTable As SubscriptionDataSet.PublicationSubscriptionDataTable
                    tempTable = CType(Processor.SubscriptionData.PublicationSubscription.GetChanges(DataRowState.Added) _
                                      , SubscriptionDataSet.PublicationSubscriptionDataTable)
                    Dim acctno As Integer = 0
                    If String.IsNullOrEmpty(tempTable.Rows(0).Item(4).ToString) = False Then acctno = CType(tempTable.Rows(0).Item(4), Integer)
                    If Processor.isDuplicateSubscription(CType(tempTable.Rows(0).Item(3), Integer), acctno) = False Then
                        Processor.InsertPublicationSubscription(tempTable)
                    End If

            End Select

        End Sub

        Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancelButton.Click
            Dim rowCounter As Integer
            Dim userResponse As System.Windows.Forms.DialogResult
            Dim rowsQuery As System.Collections.Generic.IEnumerable(Of System.Data.DataRow)
            Dim tempTable As Data.DataTable
            IsComboLoaded = False

            If maintenanceDataGridView.DataSource Is Nothing Then Exit Sub

            Dim _media As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
            Dim _market As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
            Dim _retailer As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
            Dim _sender As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
            Dim _expid As DataGridViewTextBoxCell = New DataGridViewTextBoxCell


            _media.Value = orig_media
            If orig_media IsNot Nothing Then maintenanceDataGridView(1, previousRow) = _media
            _market.Value = orig_mkt
            If orig_mkt IsNot Nothing Then maintenanceDataGridView(2, previousRow) = _market
            _retailer.Value = orig_ret
            If orig_ret IsNot Nothing Then maintenanceDataGridView(3, previousRow) = _retailer
            _sender.Value = orig_sender
            If orig_sender IsNot Nothing Then
                _expid.Value = -1
                maintenanceDataGridView(0, previousRow) = _sender
                maintenanceDataGridView(5, previousRow) = _expid
            End If


            tempTable = CType(maintenanceDataGridView.DataSource, Data.DataTable)
            'tempTable = tempTable.GetChanges(DataRowState.Modified)

            rowsQuery = From r In tempTable.Rows.Cast(Of System.Data.DataRow)() _
                        Select r _
                        Where r.RowState <> DataRowState.Unchanged _
                              AndAlso r.RowState <> DataRowState.Detached

            If rowsQuery.Count = 0 Then
                MessageBox.Show("Cannot detect any unsaved changes. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'maintenanceDataGridView.DataSource = Nothing
                'tempTable.Dispose()
                'tempTable = Nothing
                rowsQuery = Nothing
                Exit Sub
            End If

            Dim messageText As String = String.Format("This will remove all unsaved changes from {0}.{1}Are you sure you want to continue?" _
                                                      , tableComboBox.Text, Environment.NewLine)
            userResponse = MessageBox.Show(messageText, ProductName, MessageBoxButtons.YesNo _
                                           , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            messageText = Nothing
            If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

            maintenanceDataGridView.SuspendLayout()

            For rowCounter = rowsQuery.Count - 1 To 0 Step -1
                rowsQuery(rowCounter).ClearErrors()
                rowsQuery(rowCounter).RejectChanges()
            Next

            If tableComboBox.Text = "SenderExpectation" Then
                Processor.RefreshSenderExpectation()
                tempTable.RejectChanges()
            End If
            maintenanceDataGridView.Refresh()
            maintenanceDataGridView.ResumeLayout(True)

        End Sub

        Private Sub tableComboBox_DropDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles tableComboBox.DropDown
            If tableComboBox.Text = "SenderExpectation" Then Exit Sub
            If Processor.Data.HasChanges() Then
                Dim userResponse As System.Windows.Forms.DialogResult
                userResponse = MessageBox.Show("Unsaved changes exist. Do you want to save unsaved changes?" _
                                               , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If userResponse = Windows.Forms.DialogResult.Yes Then
                    applyButton.PerformClick()
                Else
                    cancelButton.PerformClick()
                End If

            End If

            maintenanceDataGridView.DataSource = Nothing
            Processor.Data.SenderList.Clear()
            Processor.Data.vwLocation.Clear()

        End Sub

        Private Sub tableComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tableComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Public Sub tableComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tableComboBox.SelectedIndexChanged

            If tableComboBox.SelectedIndex < 0 Then Exit Sub

            filterValueTextBox.Text = String.Empty
            filterValue2TextBox.Text = String.Empty

            'To reset filter controls.
            removeFilterButton.PerformClick()
            m_isFiltered = False

            editTableGroupBox.Text = "Edit Table " + tableComboBox.Text
            Try
                Select Case tableComboBox.Text
                    Case "DESP Procedures"
                        Processor.LoadDESPProcedureList()

                    Case "DESP Role Association"
                        filterValueComboBox.Width = filterValueComboBox.Width + 20
                        filterValue2ComboBox.Width = filterValue2ComboBox.Width + 20
                        Processor.LoadDESPRoleAssoc()
                    Case "Expectation"
                        Processor.LoadExpectations()
                    Case "Language"
                        Processor.LoadLanguages()
                    Case "Media"
                        Processor.LoadMediaTypeList()
                    Case "Ret"
                        Processor.LoadRetailers()
                    Case "Mkt"
                        Processor.LoadMarkets()
                    Case "Publication"
                        Processor.LoadPublications()
                    Case "PublicationSubscription"
                        _IsLoading = True
                        Processor.LoadPublicationSubscription()
                        maintenanceDataGridView.ClearSelection()
                        _IsLoading = False
                    Case "RetPublicationCoverage"
                        Processor.LoadRetPublicationCoverage()
                    Case "Sender"
                        Processor.LoadSenders()
                    Case "SenderExpectation"
                        _IsLoading = True

                        Processor.LoadSenderExpectation()

                        _IsLoading = False
                    Case "SenderMktAssoc"
                        Processor.LoadSenderMktAssoc()
                    Case "SenderPublication"
                        Processor.LoadSenderPublication()
                    Case "Shipper"
                        Processor.LoadShippers()
                    Case "Size"
                        Processor.LoadSizes()
                    Case "TradeClass"
                        Processor.LoadTradeclasses()
                    Case "OnlineWebsite"
                        Processor.LoadWebsites() ' Omar added

                    Case "Site"
                        Processor.LoadSites() ' Omar added
                    Case Else
                        Throw New System.ApplicationException("Template not defined for this selection.")
                End Select

            Catch ex As System.ApplicationException
                messageLabel.Text = ex.Message
            Catch ex As Exception
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            SetFieldsDropDownList()
            ResetFilterControls()

        End Sub

        Private Sub filterFieldComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles filterFieldComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub filterFieldComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles filterFieldComboBox.SelectedIndexChanged
            Dim tempTable As System.Data.DataTable


            If filterFieldComboBox.SelectedIndex < 0 Then Exit Sub

            tempTable = CType(maintenanceDataGridView.DataSource, System.Data.DataTable)

            Dim _Filter As Object

            For Each l As List(Of String) In mArray
                If l.Contains(filterFieldComboBox.Text) Then
                    _Filter = l(1)
                    Exit For
                End If
            Next

            If filterFieldComboBox.Text = "SenderName" Then _Filter = "SenderName"

            SetFilterValueDropDownList(tempTable.TableName, CType(_Filter, String))
            Dim dt As New DataTable
            Dim rw As DataRow

            dt.Columns.Add(_Filter.ToString)

            SetFilterControl(dt.Columns(0))

            tempTable = Nothing

            filterFieldComboBox.Tag = filterFieldComboBox.SelectedIndex


        End Sub

        Private Sub filterValueTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles filterValueTextBox.KeyPress

            If Microsoft.VisualBasic.AscW(e.KeyChar) = 8 _
              OrElse filterValueTextBox.Tag Is Nothing _
            Then Exit Sub

            If Microsoft.VisualBasic.AscW(e.KeyChar) = 13 Then filterButton.PerformClick()

            If filterValueTextBox.Tag.ToString().ToUpper() = "SYSTEM.INT32" Then
                If (Microsoft.VisualBasic.AscW(e.KeyChar) < 48 OrElse Microsoft.VisualBasic.AscW(e.KeyChar) > 57) Then
                    e.Handled = True
                End If
            ElseIf filterValueTextBox.Tag.ToString().ToUpper() = "SYSTEM.DOUBLE" Then
                If (Microsoft.VisualBasic.AscW(e.KeyChar) <> 46) _
                  AndAlso (Microsoft.VisualBasic.AscW(e.KeyChar) < 48 OrElse Microsoft.VisualBasic.AscW(e.KeyChar) > 57) _
                Then
                    e.Handled = True
                End If
            End If

        End Sub

        Private Sub filterField2ComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles filterField2ComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub filterField2ComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles filterField2ComboBox.SelectedIndexChanged
            Dim tempTable As System.Data.DataTable


            If filterField2ComboBox.SelectedIndex < 0 Then Exit Sub

            tempTable = CType(maintenanceDataGridView.DataSource, System.Data.DataTable)

            Dim _Filter As Object

            For Each l As List(Of String) In mArray
                If l.Contains(filterField2ComboBox.Text) Then
                    _Filter = l(1)
                    Exit For
                End If
            Next

            If filterField2ComboBox.Text = "SenderName" Then _Filter = "SenderName"

            SetFilterValue2DropDownList(tempTable.TableName, CType(_Filter, String))
            Dim dt As New DataTable
            Dim rw As DataRow

            dt.Columns.Add(_Filter.ToString)

            SetFilter2Control(dt.Columns(0))

            tempTable = Nothing

            filterField2ComboBox.Tag = filterField2ComboBox.SelectedIndex

        End Sub

        Private Sub filterValue2TextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles filterValue2TextBox.KeyPress

            If Microsoft.VisualBasic.AscW(e.KeyChar) = 8 _
              OrElse filterValue2TextBox.Tag Is Nothing _
            Then Exit Sub

            If Microsoft.VisualBasic.AscW(e.KeyChar) = 13 Then filterButton.PerformClick()

            If filterValue2TextBox.Tag.ToString().ToUpper() = "SYSTEM.INT32" Then
                If (Microsoft.VisualBasic.AscW(e.KeyChar) < 48 OrElse Microsoft.VisualBasic.AscW(e.KeyChar) > 57) Then
                    e.Handled = True
                End If
            ElseIf filterValue2TextBox.Tag.ToString().ToUpper() = "SYSTEM.DOUBLE" Then
                If (Microsoft.VisualBasic.AscW(e.KeyChar) <> 46) _
                  AndAlso (Microsoft.VisualBasic.AscW(e.KeyChar) < 48 OrElse Microsoft.VisualBasic.AscW(e.KeyChar) > 57) _
                Then
                    e.Handled = True
                End If
            End If

        End Sub

        Private Sub filterTypeInDatePicker_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles filterValueTypeInDatePicker.Validating, filterValue2TypeInDatePicker.Validating
            Dim tempDate As System.DateTime
            Dim tempControl As MCAP.UI.Controls.TypeInDatePicker


            tempControl = CType(sender, MCAP.UI.Controls.TypeInDatePicker)

            If tempControl.Text <> "  /  /" _
              AndAlso DateTime.TryParse(tempControl.Text, tempDate) = False _
            Then
                SetErrorProvider(tempControl, "Provide valid date.")
                e.Cancel = True
            Else
                RemoveErrorProvider(tempControl)
            End If

        End Sub

        Private Sub AppendFilterCriteria(ByVal filterCondition As System.Text.StringBuilder, ByVal columnName As String, ByVal columnDataType As System.Type)
            Dim applyQuote, applyWildCard As Boolean

            If filterFieldComboBox.SelectedIndex < 0 Then Exit Sub

            filterCondition.Append(columnName)

            If (filterValueTextBox.Visible AndAlso filterValueTextBox.TextLength = 0) _
              OrElse (filterValueTypeInDatePicker.Visible AndAlso filterValueTypeInDatePicker.Value.HasValue = False) _
              OrElse (filterValueComboBox.Visible AndAlso (filterValueComboBox.SelectedValue Is Nothing OrElse filterValueComboBox.SelectedIndex < 0 OrElse filterValueComboBox.SelectedValue Is DBNull.Value)) _
            Then
                filterCondition.Append(" IS NULL")

            Else
                Select Case columnDataType.ToString()
                    Case "System.String"
                        filterCondition.Append(" LIKE '%") : applyQuote = True : applyWildCard = True
                    Case "System.DateTime"
                        filterCondition.Append(" = '") : applyQuote = True : applyWildCard = False
                    Case Else
                        filterCondition.Append(" = ") : applyQuote = False : applyWildCard = False
                End Select

                If filterValueTextBox.Visible Then
                    If filterValueTextBox.TextLength = 1 Then filterCondition = filterCondition.Replace("%", "")
                    filterCondition.Append(filterValueTextBox.Text.Replace("'", "''"))

                ElseIf filterValueTypeInDatePicker.Visible Then
                    filterCondition.Append(filterValueTypeInDatePicker.Text)

                ElseIf filterValueComboBox.Visible Then
                    If filterValueComboBox.DataSource Is Nothing Then
                        filterCondition.Append(filterValueComboBox.Text.Replace("'", "''"))
                    Else
                        If tableComboBox.Text = "SenderExpectation" And Me.IsFilteredTable = False Then
                            filterCondition.Append(filterValueComboBox.Text)
                        Else
                            filterCondition.Append(filterValueComboBox.SelectedValue.ToString())
                        End If
                    End If
                End If

                If applyWildCard Then filterCondition.Append("%")
                If applyQuote Then filterCondition.Append("'")
            End If

        End Sub

        Private Sub AppendFilter2Criteria(ByVal filterCondition As System.Text.StringBuilder, ByVal columnName As String, ByVal columnDataType As System.Type)
            Dim applyQuote, applyWildCard As Boolean


            If filterField2ComboBox.SelectedIndex < 0 Then Exit Sub

            filterCondition.Append(columnName)

            If (filterValue2TextBox.Visible AndAlso filterValue2TextBox.TextLength = 0) _
              OrElse (filterValue2TypeInDatePicker.Visible AndAlso filterValue2TypeInDatePicker.Value.HasValue = False) _
              OrElse (filterValue2ComboBox.Visible AndAlso (filterValue2ComboBox.SelectedValue Is Nothing OrElse filterValue2ComboBox.SelectedIndex < 0 OrElse filterValue2ComboBox.SelectedValue Is DBNull.Value)) _
            Then
                filterCondition.Append(" IS NULL")

            Else
                Select Case columnDataType.ToString()
                    Case "System.String"
                        filterCondition.Append(" LIKE '%") : applyQuote = True : applyWildCard = True
                    Case "System.DateTime"
                        filterCondition.Append(" = '") : applyQuote = True : applyWildCard = False
                    Case Else
                        filterCondition.Append(" = ") : applyQuote = False : applyWildCard = False
                End Select

                If filterValue2TextBox.Visible Then
                    If filterValue2TextBox.TextLength = 1 Then filterCondition = filterCondition.Replace("%", "")
                    filterCondition.Append(filterValue2TextBox.Text.Replace("'", "''"))

                ElseIf filterValue2TypeInDatePicker.Visible Then
                    filterCondition.Append(filterValue2TypeInDatePicker.Text)

                ElseIf filterValue2ComboBox.Visible Then
                    If filterValue2ComboBox.DataSource Is Nothing Then
                        filterCondition.Append(filterValue2ComboBox.Text.Replace("'", "''"))
                    Else
                        If tableComboBox.Text = "SenderExpectation" And Me.IsFilteredTable = False Then
                            filterCondition.Append(filterValue2ComboBox.Text)
                        Else
                            filterCondition.Append(filterValue2ComboBox.SelectedValue.ToString())
                        End If
                    End If
                End If

                If applyWildCard Then filterCondition.Append("%")
                If applyQuote Then filterCondition.Append("'")
            End If

        End Sub

        Public Sub filterButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles filterButton.Click
            Dim filterFieldIndex As Integer
            Dim filterColumnName As String
            Dim filterColumnDataType As System.Type
            Dim filterCondition As System.Text.StringBuilder
            Dim tempTable As System.Data.DataTable
            Dim tableAlias As String

            If filterFieldComboBox.SelectedIndex < 0 Then Exit Sub

            If filterValueTextBox.Text = "" And filterFieldComboBox.Visible = False Then Exit Sub


            tempTable = CType(maintenanceDataGridView.DataSource, System.Data.DataTable)

            If tempTable.HasErrors Then
                MessageBox.Show("Table contains error. You must fix it before applying filter." _
                                + Environment.NewLine + "Use Apply button to save changes" _
                                + Environment.NewLine + "Use Cancel button to reject changes.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf tempTable.GetChanges() IsNot Nothing AndAlso tempTable.GetChanges().Rows.Count > 0 Then
                MessageBox.Show("Table contains unsaved changes. You must discard or save those changes before applying filter." _
                                + Environment.NewLine + "Use Apply button to save those changes" _
                                + Environment.NewLine + "Use Cancel button to reject those changes.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            filterCondition = New System.Text.StringBuilder()

            tableAlias = GetFilterColumnTablePrefix()

            Dim _Filter As Object

            For Each l As List(Of String) In mArray
                If l.Contains(filterFieldComboBox.Text) Then
                    _Filter = l(1)
                    Exit For
                End If
            Next

            If filterFieldComboBox.Text = "SenderName" Then _Filter = "SenderName"
            If Me.IsFilteredTable And filterFieldComboBox.Text = "SenderName" Then
                _Filter = "Name"
            ElseIf tableComboBox.Text = "SenderExpectation" Then
                _Filter = tableAlias + _Filter.ToString
            End If
            If CStr(_Filter) = "Market" Then _Filter = "Mkt"

            filterColumnName = CType(_Filter, String)
            If filterValueTextBox.Visible = True Then
                filterColumnDataType = GetType(System.String)
                If IsNumeric(filterValueTextBox.Text) And filterValueTextBox.Visible = False Then filterColumnDataType = GetType(System.Int16)
            ElseIf filterValueTypeInDatePicker.Visible = True Then
                filterColumnDataType = GetType(System.DateTime)

            Else
                filterColumnDataType = GetType(System.Int16)
                If tableComboBox.Text = "SenderExpectation" And Me.IsFilteredTable = False Then filterColumnDataType = tempTable.Columns(Replace(filterColumnName, "vwSenderExpectation.", "")).DataType
            End If

            If filterColumnName = "ExpectationId" Then
                filterColumnDataType = GetType(System.Int16)
            End If

            AppendFilterCriteria(filterCondition, filterColumnName, filterColumnDataType)

            Dim str As String = filterCondition.ToString
            If filterField2ComboBox.SelectedIndex >= 0 Then

                If logicalOperatorsComboBox.SelectedIndex = 0 Then
                    filterCondition.Append(" AND ")
                Else
                    filterCondition.Append(" OR ")
                End If

                Dim _Filter2 As Object

                For Each l As List(Of String) In mArray
                    If l.Contains(filterField2ComboBox.Text) Then
                        _Filter2 = l(1)
                        Exit For
                    End If
                Next

                If filterField2ComboBox.Text = "SenderName" Then _Filter2 = "SenderName"
                If CStr(_Filter2) = "Market" Then _Filter2 = "Mkt"

                filterColumnName = CType(_Filter2, String)
                If filterValue2TextBox.Visible = True Then
                    filterColumnDataType = GetType(System.String)
                    If IsNumeric(filterValue2TextBox.Text) And filterValue2TextBox.Visible = False Then filterColumnDataType = GetType(System.Int16)
                Else
                    filterColumnDataType = tempTable.Columns(filterColumnName).DataType
                End If
                If filterColumnName = "ExpectationId" Then
                    filterColumnDataType = GetType(System.Int16)
                End If

                If tableComboBox.Text = "SenderExpectation" And IsFilteredTable = False Then
                    AppendFilter2Criteria(filterCondition, filterColumnName, filterColumnDataType)

                Else
                    AppendFilter2Criteria(filterCondition, tableAlias + filterColumnName, filterColumnDataType)
                End If

                tableAlias = Nothing
            End If
            Dim xtr As String = filterCondition.ToString()
            If Me.IsFilteredTable Then

                LoadFilteredTable(filterCondition.ToString())
            Else
                Dim newFilterCondition As String = filterCondition.Replace("vwSenderExpectation.", "").ToString
                tempTable.DefaultView.RowFilter = newFilterCondition
            End If
            removeFilterButton.Enabled = True
            filterConditionTemp = filterCondition.ToString
            filterCondition.Remove(0, filterCondition.Length)
            filterCondition = Nothing
            messageLabel.Text = String.Empty
            IsComboLoaded = False
        End Sub

        Private Sub removeFilterButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles removeFilterButton.Click
            Dim tempTable As System.Data.DataTable

            If maintenanceDataGridView.DataSource Is Nothing Then Exit Sub

            tempTable = CType(maintenanceDataGridView.DataSource, System.Data.DataTable)
            tempTable.DefaultView.RowFilter = String.Empty
            tempTable = Nothing

            removeFilterButton.Enabled = False

            With filterFieldComboBox
                .SelectedIndex = -1
                '.DataSource = Nothing
                filterValueComboBox.Visible = False
                filterValueTextBox.Visible = True
            End With
            With filterField2ComboBox
                .SelectedIndex = -1
                '.DataSource = Nothing
                filterValue2ComboBox.Visible = False
                filterValue2TextBox.Visible = True
            End With
            maintenanceDataGridView.Columns.Clear()

            filterValueTextBox.Text = ""
            filterValue2TextBox.Text = ""

        End Sub

        Private Sub maintenanceDataGridView_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles maintenanceDataGridView.CellClick
            Dim dgMaintenance As DataGridView
            dgMaintenance = New DataGridView
            dgMaintenance = maintenanceDataGridView

            If tableComboBox.Text = "SenderExpectation" Then
                Try
                    If String.IsNullOrEmpty(dgMaintenance.CurrentRow.Cells("senderNameTextBoxColumn").Value.ToString) = True Then
                        dgMaintenance.CurrentRow.Cells("MediaIdTextBoxColumn").ReadOnly = True
                        dgMaintenance.CurrentRow.Cells("mktIdTextBoxColumn").ReadOnly = True
                        dgMaintenance.CurrentRow.Cells("retIdTextBoxColumn").ReadOnly = True
                        'dgMaintenance.CurrentRow.Cells(0).ReadOnly = True
                        Exit Sub
                    Else
                        dgMaintenance.CurrentRow.Cells("MediaIdTextBoxColumn").ReadOnly = False
                        dgMaintenance.CurrentRow.Cells("mktIdTextBoxColumn").ReadOnly = False
                    End If

                    If String.IsNullOrEmpty(dgMaintenance.CurrentRow.Cells("MediaIdTextBoxColumn").Value.ToString) = True Then
                        dgMaintenance.CurrentRow.Cells("mktIdTextBoxColumn").ReadOnly = True
                        dgMaintenance.CurrentRow.Cells("retIdTextBoxColumn").ReadOnly = True
                        'dgMaintenance.CurrentRow.Cells(0).ReadOnly = True
                        Exit Sub
                    Else
                        dgMaintenance.CurrentRow.Cells("mktIdTextBoxColumn").ReadOnly = False
                    End If

                    If String.IsNullOrEmpty(dgMaintenance.CurrentRow.Cells("mktIdTextBoxColumn").Value.ToString) Then
                        dgMaintenance.CurrentRow.Cells("retIdTextBoxColumn").ReadOnly = True
                        dgMaintenance.CurrentRow.Cells("senderNameTextBoxColumn").ReadOnly = True
                        Exit Sub
                    Else
                        dgMaintenance.CurrentRow.Cells("retIdTextBoxColumn").ReadOnly = False
                    End If

                    If String.IsNullOrEmpty(dgMaintenance.CurrentRow.Cells("retIdTextBoxColumn").Value.ToString) Then
                        dgMaintenance.CurrentRow.Cells("senderNameTextBoxColumn").ReadOnly = True
                        Exit Sub
                    Else
                        dgMaintenance.CurrentRow.Cells("senderNameTextBoxColumn").ReadOnly = False
                    End If

                    _MediaDesc = dgMaintenance.CurrentRow.Cells("MediaIdTextBoxColumn").Value.ToString
                    _med = GetID(_MediaDesc, "Media")
                    Processor.LoadFilteredMarket(_med)
                    If String.IsNullOrEmpty(dgMaintenance.CurrentRow.Cells("mktIdTextBoxColumn").Value.ToString) = True Then Exit Sub
                    _MktDesc = dgMaintenance.CurrentRow.Cells("mktIdTextBoxColumn").Value.ToString
                    If Processor.Data.Mkt.Count <= 0 Then Exit Sub
                    _mkt = GetID(_MktDesc, "Mkt")
                    Processor.loadFilteredRetailer(_med, _mkt)
                    If String.IsNullOrEmpty(dgMaintenance.CurrentRow.Cells("retIdTextBoxColumn").Value.ToString) = True Then Exit Sub
                    _RetDesc = dgMaintenance.CurrentRow.Cells("retIdTextBoxColumn").Value.ToString
                Catch nl As NullReferenceException

                End Try
            End If

            If tableComboBox.Text = "OnlineWebsite" Then

                If String.IsNullOrEmpty(dgMaintenance.CurrentRow.Cells("OrderValueTextBoxColumn").Value.ToString) = True _
                   And String.IsNullOrEmpty(dgMaintenance.CurrentRow.Cells("PageNameTextBoxColumn").Value.ToString) = False _
                   And String.IsNullOrEmpty(dgMaintenance.CurrentRow.Cells("RetIdComboBoxColumn").Value.ToString) = False Then
                    MsgBox("Order Value is Required ", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
                Try
                    If dgMaintenance.Columns(e.ColumnIndex).Name = "URLTextBoxColumn" And e.RowIndex >= 0 Then

                       

                        Dim bmb As BindingManagerBase

                        bmb = Me.BindingContext(Me.maintenanceDataGridView.DataSource, Me.maintenanceDataGridView.DataMember)
                        If bmb.Count = 0 Then Exit Sub

                        If bmb.Current Is Nothing Then Exit Sub
                        If dgMaintenance.CurrentRow.Cells("WebsitePageDownloadTextBoxColumn").Value.ToString = "-1" Then
                            Dim userResponse As DialogResult
                            userResponse = MessageBox.Show("Data on the Main form will be saved ?" _
                                           , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                      
                        If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

                        applyButton.PerformClick()
                    Else
                        Dim tempTable As Data.DataTable
                        _DataRefresh = True
                        If maintenanceDataGridView.DataSource Is Nothing Then Exit Sub

                        tempTable = CType(maintenanceDataGridView.DataSource, Data.DataTable)
                        tempTable = tempTable.GetChanges(DataRowState.Modified)

                        Processor.UpdateWebsite(Processor.Data.WebsitePageDownload)
                    End If

                    Dim dsWebsiteURL As DataSet = GetWebsitePageDownload(CInt(dgMaintenance.CurrentRow.Cells("WebsitePageDownloadTextBoxColumn").Value))
                    Using URLInputBox As New URLInputBox()
                        URLInputBox.LoadData(dsWebsiteURL)
                        URLInputBox.StartPosition = FormStartPosition.CenterParent
                        URLInputBox.ShowDialog()
                        If URLInputBox.RefreshGrid = True Then
                            filterButton.PerformClick()
                        End If
                    End Using


                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            ElseIf tableComboBox.Text = "Sender" Then

            
                Try
                    If dgMaintenance.Columns(e.ColumnIndex).Name = "commentsTextBoxColumn" And e.RowIndex >= 0 Then



                        Dim bmb As BindingManagerBase

                        bmb = Me.BindingContext(Me.maintenanceDataGridView.DataSource, Me.maintenanceDataGridView.DataMember)
                        If bmb.Count = 0 Then Exit Sub

                        If bmb.Current Is Nothing Then Exit Sub
                        If dgMaintenance.CurrentRow.Cells("SenderIdTextBoxColumn").Value.ToString = "-1" Then
                            Dim userResponse As DialogResult
                            userResponse = MessageBox.Show("Data on the Main form will be saved ?" _
                                           , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                            If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

                            applyButton.PerformClick()
                        Else
                            Dim tempTable As Data.DataTable
                            _DataRefresh = True
                            If maintenanceDataGridView.DataSource Is Nothing Then Exit Sub

                            tempTable = CType(maintenanceDataGridView.DataSource, Data.DataTable)
                            tempTable = tempTable.GetChanges(DataRowState.Modified)

                            Processor.UpdateSender(Processor.Data.Sender)
                        End If

                        Dim dsSenderComment As DataSet = GetSenderComment(CInt(dgMaintenance.CurrentRow.Cells("SenderIdTextBoxColumn").Value))
                        Using commentBox As New inputSenderComment()
                            commentBox.LoadData(dsSenderComment)
                            commentBox.StartPosition = FormStartPosition.CenterParent
                            commentBox.ShowDialog()
                            If commentBox.RefreshGrid = True Then
                                filterButton.PerformClick()
                            End If
                        End Using


                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If
        End Sub

        Public Function GetWebsitePageDownload(ByVal id As Integer) As DataSet
            'Return a dataset representing a single Currency
            Dim conn As New SqlConnection
            conn = New SqlConnection(GetConnectionStringForAppDB)

            Try
                Dim sSql As String = "Select * from WebsitePageDownload where WebsitePageDownloadId = " & id.ToString
                Dim sa As SqlDataAdapter = New SqlDataAdapter(sSql, conn)
                Dim ds As New DataSet

                Try
                    sa.Fill(ds, "WebsitePageDownload")
                Finally
                    sa.Dispose()
                End Try
                Return ds

            Finally
                conn.Close()
                conn.Dispose()
            End Try

        End Function

        Public Function GetSenderComment(ByVal id As Integer) As DataSet
            'Return a dataset representing a single Currency
            Dim conn As New SqlConnection
            conn = New SqlConnection(GetConnectionStringForAppDB)

            Try
                Dim sSql As String = "Select * from Sender where Senderid = " & id.ToString
                Dim sa As SqlDataAdapter = New SqlDataAdapter(sSql, conn)
                Dim ds As New DataSet

                Try
                    sa.Fill(ds, "Sender")
                Finally
                    sa.Dispose()
                End Try
                Return ds

            Finally
                conn.Close()
                conn.Dispose()
            End Try

        End Function

        Private Sub CreateExpectation(ByVal SenderId As Integer, ByVal mediaID As Integer, ByVal mktID As Integer, ByVal retID As Integer)
            Dim obj As Object
            Dim val As Integer
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim cn As System.Data.SqlClient.SqlConnection

            cn = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
            cmd = New System.Data.SqlClient.SqlCommand

            cn.Open()

            cmd.Connection = cn

            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = "mt_proc_SenderExpectation"

            cmd.Parameters.Add(New SqlParameter("@SenderID", SqlDbType.Int))
            cmd.Parameters.Add(New SqlParameter("@MediaID", SqlDbType.Int))
            cmd.Parameters.Add(New SqlParameter("@MarketID", SqlDbType.Int))
            cmd.Parameters.Add(New SqlParameter("@RetMktID", SqlDbType.Int))


            cmd.Parameters(0).Value = SenderId
            cmd.Parameters(1).Value = mediaID
            cmd.Parameters(2).Value = mktID
            cmd.Parameters(3).Value = retID

            cmd.ExecuteNonQuery()


            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

        End Sub

        Private Function HasRetPublicationCoverage(ByVal _retid As Integer, ByVal _publicationId As Integer) As Boolean
            Dim ReturnVal As Boolean
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "select * from RetPublicationCoverage where retid=" + _retid.ToString + " and PublicationId=" + _publicationId.ToString
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

        Private Sub maintenanceDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles maintenanceDataGridView.CellContentClick
            If tableComboBox.Text = "SenderExpectation" Then
                Dim dgMaintenance As DataGridView
                dgMaintenance = New DataGridView
                dgMaintenance = maintenanceDataGridView
                If e.ColumnIndex = 6 Then
                    If (MessageBox.Show("Record found will be inserted, Continue ?", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                        Exit Sub
                    End If
                    _ret = GetID(_RetDesc, "Ret")
                    _senderID = CInt(dgMaintenance.CurrentRow.Cells("SenderIdTextBoxColumn").Value)
                    Call CreateExpectation(_senderID, _med, _mkt, _ret)
                    Processor.RefreshSenderExpectation()
                End If
            End If
        End Sub

        Private Sub maintenanceDataGridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles maintenanceDataGridView.CellFormatting
            Dim dgMaintenance As DataGridView
            dgMaintenance = New DataGridView
            dgMaintenance = maintenanceDataGridView

            If tableComboBox.Text = "OnlineWebsite" Then


                If dgMaintenance.Columns(e.ColumnIndex).Name = "URLTextBoxColumn" And e.RowIndex >= 0 Then

                    If e.Value IsNot Nothing Then
                        If Not IsDBNull(e.Value) Then
                            Dim stringValue As String = CType(e.Value, String)
                            stringValue = stringValue.ToLower()
                            e.Value = ""
                            e.Value = returnSubStringValue(stringValue, 100)
                        End If
                    End If
                End If

            ElseIf tableComboBox.Text = "Sender" Then
                If dgMaintenance.Columns(e.ColumnIndex).Name = "commentsTextBoxColumn" And e.RowIndex >= 0 Then

                    If e.Value IsNot Nothing Then
                        If Not IsDBNull(e.Value) Then
                            Dim stringValue As String = CType(e.Value, String)
                            stringValue = stringValue.ToLower()
                            e.Value = ""
                            e.Value = returnSubStringValue(stringValue, 100)
                        End If
                    End If
                End If
            End If
        End Sub


        Private Sub maintenanceDataGridView_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles maintenanceDataGridView.CellMouseClick
            Dim tempTable As Data.DataTable
            tempTable = CType(maintenanceDataGridView.DataSource, Data.DataTable)
            tempTable = tempTable.GetChanges(DataRowState.Modified)
            If IsComboLoaded = False Then
                If (tempTable Is Nothing OrElse tempTable.Rows.Count = 0) And tableComboBox.Text = "SenderExpectation" Then
                    IsComboLoaded = False
                    Dim _media As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
                    Dim _market As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
                    Dim _retailer As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
                    Dim _sender As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
                    Dim _senderId As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
                    Dim _ExpId As DataGridViewTextBoxCell = New DataGridViewTextBoxCell

                    _media.Value = orig_media
                    ' If orig_media IsNot Nothing Then maintenanceDataGridView(0, previousRow) = _media
                    _market.Value = orig_mkt
                    ' If orig_mkt IsNot Nothing Then maintenanceDataGridView(1, previousRow) = _market
                    _retailer.Value = orig_ret
                    ' If orig_ret IsNot Nothing Then maintenanceDataGridView(2, previousRow) = _retailer
                    _sender.Value = orig_sender
                    'If orig_sender IsNot Nothing Then maintenanceDataGridView(4, previousRow) = _sender
                    _senderId.Value = 0
                    _ExpId.Value = -1
                Else
                    IsComboLoaded = False
                End If
            End If
            If tableComboBox.Text = "SenderExpectation" And IsComboLoaded = False Then
                ProcessComboBox()


                previousRow = maintenanceDataGridView.CurrentRow.Index
                If Not maintenanceDataGridView.CurrentCell Is Nothing Then

                    Try
                        If String.IsNullOrEmpty(maintenanceDataGridView(0, currentIndex).Value.ToString) = False Then
                            orig_sender = maintenanceDataGridView(0, currentIndex).Value.ToString
                        End If
                        If String.IsNullOrEmpty(maintenanceDataGridView(1, currentIndex).Value.ToString) = False Then
                            orig_media = maintenanceDataGridView(1, currentIndex).Value.ToString
                        End If
                        If String.IsNullOrEmpty(maintenanceDataGridView(2, currentIndex).Value.ToString) = False Then
                            orig_mkt = maintenanceDataGridView(2, currentIndex).Value.ToString
                        End If
                        If String.IsNullOrEmpty(maintenanceDataGridView(3, currentIndex).Value.ToString) = False Then
                            orig_ret = maintenanceDataGridView(3, currentIndex).Value.ToString
                        End If
                    Catch nl As NullReferenceException

                    End Try
                End If
            End If


        End Sub

        Private Sub maintenanceDataGridView_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles maintenanceDataGridView.CellValidating
            '     Dim headerText As String = _
            'maintenanceDataGridView.Columns(e.ColumnIndex).HeaderText
            '     Dim dgMaintenance As DataGridView
            '     dgMaintenance = New DataGridView
            '     dgMaintenance = maintenanceDataGridView
            '     '     If tableComboBox.Text = "OnlineWebsite" Then
            '     '         ' Abort validation if cell is not in the CompanyName column. 
            '     '         If Not headerText.Equals("URL") Then Return

            '     '         'If tableComboBox.Text = "OnlineWebsite" Then
            '     '         '    If String.IsNullOrEmpty(dgMaintenance.CurrentRow.Cells("URLTextBoxColumn").Value.ToString) = True Then Exit Sub
            '     '         '    MsgBox(dgMaintenance.CurrentRow.Cells("URLTextBoxColumn").Value.ToString)
            '     '         'End If

            '     '         ' Confirm that the cell is not empty. 
            '     '         If (String.IsNullOrEmpty(e.FormattedValue.ToString()) = False) Then
            '     '             MsgBox("Order Value is Requred ", MsgBoxStyle.OkOnly, MsgBoxStyle.Information)
            '     '             e.Cancel = True
            '     '         End If
            '     '     End If
            '     If tableComboBox.Text = "RetPublicationCoverage" Then
            '         If HasRetPublicationCoverage(CInt(dgMaintenance.CurrentRow.Cells("retIdComboBoxColumn").Value), CInt(dgMaintenance.CurrentRow.Cells("publicationComboBoxColumn").Value)) Then
            '             MsgBox("Retailer Publication already EXist", MsgBoxStyle.OkOnly)
            '             Exit Sub
            '         End If
            '     End If
        End Sub

        Private Sub maintenanceDataGridView_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles maintenanceDataGridView.CellValueChanged
            Dim dgMaintenance As DataGridView
            dgMaintenance = New DataGridView
            dgMaintenance = maintenanceDataGridView
            If tableComboBox.Text = "PublicationSubscription" And _IsLoading = False Then
                If String.IsNullOrEmpty(dgMaintenance.CurrentRow.Cells("publicationComboBoxColumn").Value.ToString) = True Then Exit Sub
                dgMaintenance.CurrentRow.Cells("marketTextBoxColumn").Value = CType(Processor.LoadFilteredMktSubscription(CType(dgMaintenance.CurrentRow.Cells("publicationComboBoxColumn").Value, Integer), False), String)
                dgMaintenance.CurrentRow.Cells("marketIdTextBoxColumn").Value = CType(Processor.LoadFilteredMktSubscription(CType(dgMaintenance.CurrentRow.Cells("publicationComboBoxColumn").Value, Integer), True), Integer)
            End If

            If tableComboBox.Text <> "SenderExpectation" Then Exit Sub
            If _IsLoading = True Then Exit Sub

            If String.IsNullOrEmpty(dgMaintenance.CurrentRow.Cells("senderNameTextBoxColumn").Value.ToString) = True Then Exit Sub

            _sendername = dgMaintenance.CurrentRow.Cells("senderNameTextBoxColumn").Value.ToString
            If IsNumeric(_sendername) Then _sendername = GetDescrip(_sendername, "Sender")
            dgMaintenance.CurrentRow.Cells("senderNameTextBoxColumn").Value = _sendername
            dgMaintenance.CurrentRow.Cells("SenderIdTextBoxColumn").Value = GetID(_sendername, "Sender")
            _senderID = GetID(_sendername.Replace("'", "''"), "Sender")
            If String.IsNullOrEmpty(dgMaintenance.CurrentRow.Cells("MediaIdTextBoxColumn").Value.ToString) = True Or _DataRefresh = True Then Exit Sub
            _MediaDesc = dgMaintenance.CurrentRow.Cells("MediaIdTextBoxColumn").Value.ToString
            If IsNumeric(_MediaDesc) Then _MediaDesc = GetDescrip(_MediaDesc, "Media")
            dgMaintenance.CurrentRow.Cells("MediaIdTextBoxColumn").Value = _MediaDesc
            _med = GetID(_MediaDesc.Replace("'", "''"), "Media")

            Processor.LoadFilteredMarket(_med)
            If String.IsNullOrEmpty(dgMaintenance.CurrentRow.Cells("mktIdTextBoxColumn").Value.ToString) = True Or _DataRefresh = True Then Exit Sub
            _MktDesc = dgMaintenance.CurrentRow.Cells("mktIdTextBoxColumn").Value.ToString
            If IsNumeric(_MktDesc) Then _MktDesc = GetDescrip(_MktDesc, "Mkt")
            dgMaintenance.CurrentRow.Cells("mktIdTextBoxColumn").Value = _MktDesc
            _mkt = GetID(_MktDesc.Replace("'", "''"), "Mkt")

            Processor.loadFilteredRetailer(_med, _mkt)
            If String.IsNullOrEmpty(dgMaintenance.CurrentRow.Cells("retIdTextBoxColumn").Value.ToString) = True Then Exit Sub
            _RetDesc = dgMaintenance.CurrentRow.Cells("retIdTextBoxColumn").Value.ToString
            If IsNumeric(_RetDesc) Then _RetDesc = GetDescrip(_RetDesc, "Ret")
            dgMaintenance.CurrentRow.Cells("retIdTextBoxColumn").Value = _RetDesc
            _ret = GetID(_RetDesc.Replace("'", "''"), "Ret")

            maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value = ProcessExpectationId()


        End Sub


        Private Sub maintenanceDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles maintenanceDataGridView.DataError
            Dim dg As New DataGridView

            If tableComboBox.Text = "SenderExpectation" Then Exit Sub

            If tableComboBox.Text = "RetPublicationCoverage" Then
                Dim dgMaintenance As DataGridView
                dgMaintenance = New DataGridView
                dgMaintenance = maintenanceDataGridView
                If HasRetPublicationCoverage(CInt(dgMaintenance.CurrentRow.Cells("retIdComboBoxColumn").Value), CInt(dgMaintenance.CurrentRow.Cells("publicationComboBoxColumn").Value)) Then
                    MsgBox("Retailer Publication already Exist", MsgBoxStyle.OkOnly)
                    Exit Sub
                End If
            End If

            e.Cancel = True
            e.ThrowException = False

            MessageBox.Show(e.GetType.ToString() + e.Context.ToString() + maintenanceDataGridView.ShowCellErrors.ToString())


            If e.Exception IsNot Nothing Then
                Dim additionalInstruction As System.Text.StringBuilder

                additionalInstruction = New System.Text.StringBuilder()

                With additionalInstruction
                    .Append(Environment.NewLine)
                    .Append(Environment.NewLine)
                    .Append("Press Esc to cancel row changes.")
                    .Append(Environment.NewLine)
                    .Append("To edit cell value, select the cell and press F2 or double click on it.")
                End With

                MessageBox.Show(maintenanceDataGridView.Columns(e.ColumnIndex).HeaderText + maintenanceDataGridView.Columns(e.ColumnIndex).ValueType.ToString(), e.Exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)

                additionalInstruction.Remove(0, additionalInstruction.Length)
                additionalInstruction = Nothing
            End If

            maintenanceDataGridView.Refresh()

        End Sub


        Private Sub maintenanceDataGridView_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles maintenanceDataGridView.RowValidated
            Dim bmb As BindingManagerBase

            bmb = Me.BindingContext(Me.maintenanceDataGridView.DataSource, Me.maintenanceDataGridView.DataMember)
            If e.RowIndex = 0 AndAlso bmb.Count = 0 Then Exit Sub
            If e.RowIndex = bmb.Count Then Exit Sub
            If bmb.Current Is Nothing _
              OrElse CType(bmb.Current, Data.DataRowView).Row.RowState <> DataRowState.Added _
            Then Exit Sub

            Dim tmpStr As String = maintenanceDataGridView.DataSource.GetType.ToString().ToUpper()
            _InsertStatus = True
            Select Case maintenanceDataGridView.DataSource.GetType.ToString().ToUpper()
                Case "MCAP.DESPROLEASSOC+DESP_STOREDPROCEDUREMAINTENANCEDATATABLE"
                    'If Processor.DESPData.DESP_StoredProcedureMaintenanceDataTable.LoadingTable Then Exit Sub
                    Dim tempTable As DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable
                    tempTable = CType(Processor.DESPData.DESP_StoredProcedureMaintenance.GetChanges(DataRowState.Added) _
                                      , DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable)
                    Processor.InsertDESProcedures(tempTable)
                Case "MCAP.DESPROLEASSOC+DESP_STOREDPROCEDUREROLEASSOCDATATABLE"
                    If Processor.DESPData.DESP_StoredProcedureRoleAssoc.LoadingTable Then Exit Sub
                    Dim tempTable As DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable
                    tempTable = CType(Processor.DESPData.DESP_StoredProcedureRoleAssoc.GetChanges(DataRowState.Added) _
                                      , DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable)
                    Processor.InsertDESPRoleAssoc(tempTable)
                Case "MCAP.MAINTENANCEDATASET+EXPECTATIONDATATABLE"
                    If Processor.Data.Expectation.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.ExpectationDataTable
                    tempTable = CType(Processor.Data.Expectation.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.ExpectationDataTable)
                    If tempTable(0).RetId > 0 And tempTable(0).MktId > 0 And tempTable(0).MediaId > 0 Then
                        Processor.InsertExpectation(tempTable)
                    End If

                Case "MCAP.MAINTENANCEDATASET+LANGUAGEDATATABLE"
                    If Processor.Data.Language.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.LanguageDataTable
                    tempTable = CType(Processor.Data.Language.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.LanguageDataTable)
                    Processor.InsertLanguage(tempTable)

                Case "MCAP.MAINTENANCEDATASET+MEDIADATATABLE"
                    If Processor.Data.Media.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.MediaDataTable
                    tempTable = CType(Processor.Data.Media.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.MediaDataTable)
                    Processor.InsertMedia(tempTable)

                Case "MCAP.MAINTENANCEDATASET+RETDATATABLE"
                    If Processor.Data.Ret.LoadingTable Then Exit Sub
                    Processor.InsertRet(Processor.Data.Ret)

                Case "MCAP.MAINTENANCEDATASET+MKTDATATABLE"
                    If Processor.Data.RetMktCustomDescrip.LoadingTable Then Exit Sub

                    Processor.InsertMkt(Processor.Data.Mkt)

                Case "MCAP.MAINTENANCEDATASET+PUBLICATIONDATATABLE"
                    If Processor.Data.RetMktCustomDescrip.LoadingTable Then Exit Sub

                    Processor.InsertPublication(Processor.Data.Publication)

                Case "MCAP.MAINTENANCEDATASET+RETPUBLICATIONCOVERAGEDATATABLE"
                    If Processor.Data.RetPublicationCoverage.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.RetPublicationCoverageDataTable
                    tempTable = CType(Processor.Data.RetPublicationCoverage.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.RetPublicationCoverageDataTable)
                    Processor.InsertRetPublicationCoverage(tempTable)

                Case "MCAP.MAINTENANCEDATASET+SENDERDATATABLE"
                    'If Processor.Data.Sender.LoadingTable Then Exit Sub
                    'Dim tempTable As MaintenanceDataSet.SenderDataTable
                    'tempTable = CType(Processor.Data.Sender.GetChanges(DataRowState.Added) _
                    '                  , MaintenanceDataSet.SenderDataTable)
                    'Processor.InsertSender(tempTable)

                Case "MCAP.MAINTENANCEDATASET+SENDERMKTASSOCDATATABLE"
                    If Processor.Data.SenderMktAssoc.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.SenderMktAssocDataTable
                    tempTable = CType(Processor.Data.SenderMktAssoc.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.SenderMktAssocDataTable)

                    Processor.InsertSenderMktAssoc(tempTable)

                Case "MCAP.MAINTENANCEDATASET+SENDERPUBLICATIONDATATABLE"
                    If Processor.Data.SenderPublication.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.SenderPublicationDataTable
                    tempTable = CType(Processor.Data.SenderPublication.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.SenderPublicationDataTable)
                    Processor.InsertSenderPublication(tempTable)
                    Processor.RefreshSenderPublication()

                Case "MCAP.MAINTENANCEDATASET+SENDEREXPECTATIONDATATABLE"
                    'If Processor.Data.SenderExpectation.LoadingTable Then Exit Sub
                    'If String.IsNullOrEmpty(maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value.ToString) = True Then maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value = ProcessExpectationId()
                    'Dim tempTable As MaintenanceDataSet.SenderExpectationDataTable
                    'tempTable = CType(Processor.Data.SenderExpectation.GetChanges(DataRowState.Added) _
                    '                  , MaintenanceDataSet.SenderExpectationDataTable)
                    'If CInt(maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value) = -1 Then
                    '    MsgBox("The expectation Id that you're trying to process is not valid. It's either it has reached the End Date of the record or the combination of Media, Market and Retailer are not existing in the Expectation Table.", MsgBoxStyle.Exclamation, "MCAP")
                    '    maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value = ""
                    '    _med = 0
                    '    _mkt = 0
                    '    _ret = 0
                    '    Exit Sub
                    'End If
                    'Processor.InsertSenderExpectation(tempTable, CInt(maintenanceDataGridView.CurrentRow.Cells(5).Value), CInt(maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value))
                    'Processor.RefreshSenderExpectation()
                    '_med = 0
                    '_mkt = 0
                    '_ret = 0

                    Dim StartDate, EndDate As Object
                    If Processor.Data.SenderExpectation.LoadingTable Then Exit Sub
                    If String.IsNullOrEmpty(maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value.ToString) = True Then maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value = ProcessExpectationId()
                    Dim tempTable As MaintenanceDataSet.SenderExpectationDataTable
                    tempTable = CType(Processor.Data.SenderExpectation.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.SenderExpectationDataTable)
                    If CInt(maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value) = -1 Then
                        MsgBox("The expectation Id that you're trying to process is not valid. It's either it has reached the End Date of the record or the combination of Media, Market and Retailer are not existing in the Expectation Table.", MsgBoxStyle.Exclamation, "MCAP")
                        maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value = ""
                        _med = 0
                        _mkt = 0
                        _ret = 0
                        Exit Sub
                    End If
                    If String.IsNullOrEmpty(maintenanceDataGridView.CurrentRow.Cells("startDtCalendarColumn").Value.ToString()) = True Then
                        StartDate = Nothing
                    Else
                        StartDate = CDate(maintenanceDataGridView.CurrentRow.Cells("startDtCalendarColumn").Value)
                    End If

                    If String.IsNullOrEmpty(maintenanceDataGridView.CurrentRow.Cells("endDtCalendarColumn").Value.ToString()) = True Then
                        EndDate = Nothing
                    Else
                        EndDate = CDate(maintenanceDataGridView.CurrentRow.Cells("endDtCalendarColumn").Value)
                    End If

                    Processor.InsertSenderExpectation(tempTable, CInt(maintenanceDataGridView.CurrentRow.Cells(5).Value), CInt(maintenanceDataGridView.CurrentRow.Cells("expIdTextBoxColumn").Value), StartDate, EndDate)
                    Processor.RefreshSenderExpectation()
                    _med = 0
                    _mkt = 0
                    _ret = 0

                Case "MCAP.MAINTENANCEDATASET+SHIPPERDATATABLE"
                    If Processor.Data.Shipper.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.ShipperDataTable
                    tempTable = CType(Processor.Data.Shipper.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.ShipperDataTable)
                    Processor.InsertShipper(tempTable)

                Case "MCAP.MAINTENANCEDATASET+SIZEDATATABLE"
                    If Processor.Data.Size.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.SizeDataTable
                    tempTable = CType(Processor.Data.Size.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.SizeDataTable)
                    Processor.InsertSize(tempTable)

                Case "MCAP.MAINTENANCEDATASET+TRADECLASSDATATABLE"
                    If Processor.Data.TradeClass.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.TradeClassDataTable
                    tempTable = CType(Processor.Data.TradeClass.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.TradeClassDataTable)
                    Processor.InsertTradeclass(tempTable)
                    _InsertStatus = False

                Case "MCAP.MAINTENANCEDATASET+WEBSITEPAGEDOWNLOADDATATABLE"

                    If Processor.Data.WebsitePageDownload.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.WebsitePageDownloadDataTable
                    tempTable = CType(Processor.Data.WebsitePageDownload.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.WebsitePageDownloadDataTable)
                    Processor.InsertWebsite(tempTable)
                Case "MCAP.MAINTENANCEDATASET+SITEDATATABLE"

                    If Processor.Data.Site.LoadingTable Then Exit Sub
                    Dim tempTable As MaintenanceDataSet.SiteDataTable
                    tempTable = CType(Processor.Data.Site.GetChanges(DataRowState.Added) _
                                      , MaintenanceDataSet.SiteDataTable)
                    Processor.InsertSite(tempTable)


                Case "MCAP.SUBSCRIPTIONDATASET+PUBLICATIONSUBSCRIPTIONDATATABLE"
                    If Processor.SubscriptionData.PublicationSubscription.LoadingTable Then Exit Sub
                    Dim tempTable As SubscriptionDataSet.PublicationSubscriptionDataTable
                    tempTable = CType(Processor.SubscriptionData.PublicationSubscription.GetChanges(DataRowState.Added) _
                                      , SubscriptionDataSet.PublicationSubscriptionDataTable)
                    Dim acctno As Integer = 0
                    If String.IsNullOrEmpty(tempTable.Rows(0).Item(4).ToString) = False Then acctno = CType(tempTable.Rows(0).Item(4), Integer)
                    If Processor.isDuplicateSubscription(CType(tempTable.Rows(0).Item(3), Integer), acctno) = False Then
                        Processor.InsertPublicationSubscription(tempTable)
                    End If

            End Select
            maintenanceDataGridView.Refresh()

        End Sub


        Private Sub maintenanceDataGridView_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles maintenanceDataGridView.UserDeletedRow
            DeleteRowsFromDataBase()
            previousRow = 0
        End Sub

        Private Sub maintenanceDataGridView_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles maintenanceDataGridView.UserDeletingRow
            Dim messageText As String
            Dim userResponse As System.Windows.Forms.DialogResult


            messageText = "Once current row is deleted, it cannot be undone." + Environment.NewLine _
                          + "Are you sure, you want to delete current row from database?"
            userResponse = MessageBox.Show(messageText, ProductName, MessageBoxButtons.YesNo _
                                           , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If userResponse = Windows.Forms.DialogResult.No Then e.Cancel = True
        End Sub


#Region " EventHandlers for WebsiteDownload Table "

        Private Sub m_maintenanceProcessor_LoadingWebsite(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.LoadingWebsite

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading websites. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub


        Private Sub m_maintenanceProcessor_WebsiteExceedsNonFilteredRowsLimit(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.WebsiteExceedsNonFilteredRowsLimit

            PrepareGridForWebsiteTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()
            'Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

            messageLabel.Text = "There are too many websites. Please apply filter to load limited number of websites."
            m_isFiltered = True
            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_OnlineWebsiteLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.WebsiteLoaded

            PrepareGridForWebsiteTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()
            'Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

            Me.StatusMessage = String.Empty
        End Sub


#End Region

#Region " EventHandlers for Expectation Table "


        Private Sub m_maintenanceProcessor_LoadingExpectations(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.LoadingExpectations

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading expectation. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_ExpectationExceedsNonFilteredRowsLimit(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.ExpectationExceedsNonFilteredRowsLimit

            PrepareGridForExpectationTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()
            'Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

            messageLabel.Text = "There are too many expectations. Please apply filter to load limited number of expectations."
            m_isFiltered = True
            Me.StatusMessage = String.Empty

        End Sub


        Private Sub m_maintenanceProcessor_ExpectationsLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.ExpectationsLoaded

            PrepareGridForExpectationTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()
            'Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_ValidatingExpectation(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.ValidatingExpectation

            Me.StatusMessage = "Validating expectations..."

        End Sub

        Private Sub m_maintenanceProcessor_ExpectationValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.ExpectationValidated

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_InvalidExpectationFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.InvalidExpectationFound
            Dim errorText As System.Text.StringBuilder
            Dim tempRows() As System.Data.DataRow
            Dim tempCols() As System.Data.DataColumn
            Dim tempTable As MaintenanceDataSet.ExpectationDataTable


            Me.StatusMessage = String.Empty

            errorText = New System.Text.StringBuilder()
            errorText.AppendLine("Invalid inputs found. Cannot save changes.")

            If e.Data.Contains("ValidateRows") Then
                tempTable = CType(e.Data("ValidateRows"), MaintenanceDataSet.ExpectationDataTable)
                tempRows = tempTable.GetErrors()

                For i As Integer = 0 To tempRows.Length - 1
                    If tempRows(i).RowState <> DataRowState.Added Then
                        errorText.AppendLine()
                        errorText.Append("Expectation Id: ")
                        errorText.AppendLine(tempRows(i).Item("ExpectationId").ToString())
                    End If

                    If tempRows(i).RowError IsNot Nothing AndAlso tempRows(i).RowError.Length > 0 Then
                        errorText.AppendLine(tempRows(i).RowError)
                    End If

                    tempCols = tempRows(i).GetColumnsInError()

                    For j As Integer = 0 To tempCols.Length - 1
                        errorText.Append((j + 1).ToString())
                        errorText.Append(") ")
                        errorText.Append(tempCols(j).Caption)
                        errorText.Append(" - ")
                        errorText.AppendLine(tempRows(i).GetColumnError(tempCols(j)))
                    Next

                    System.Array.Clear(tempCols, 0, tempCols.Length)
                    tempCols = Nothing
                Next
                System.Array.Clear(tempRows, 0, tempRows.Length)
                tempRows = Nothing
            End If

            MessageBox.Show(errorText.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            errorText.Remove(0, errorText.Length)
            errorText = Nothing

        End Sub

        Private Sub m_maintenanceProcessor_InsertingExpectation(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingExpectation
            Dim tempTable As MaintenanceDataSet.ExpectationDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.ExpectationDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Add)
                Processor.ValidateExpectationInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Inserting new expectation(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_ExpectationInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.ExpectationInserted
            Dim tempTable As MaintenanceDataSet.ExpectationDataTable


            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.ExpectationDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Expectation.LoadingTable = True
            Processor.Data.Expectation.Merge(tempTable, False)
            Processor.Data.Expectation.LoadingTable = False
            Processor.Data.Expectation.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Expectation.Merge(tempTable)
            Processor.Data.Expectation.AcceptChanges()


            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingExpectation(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingExpectation
            Dim tempTable As MaintenanceDataSet.ExpectationDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.ExpectationDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateExpectationInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Updating expectation(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_ExpectationUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.ExpectationUpdated
            Dim tempTable As MaintenanceDataSet.ExpectationDataTable


            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.ExpectationDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Expectation.LoadingTable = True
            Processor.Data.Expectation.Merge(tempTable, False)
            Processor.Data.Expectation.LoadingTable = False
            Processor.Data.Expectation.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Expectation.Merge(tempTable)
            Processor.Data.Expectation.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DeletingExpectation(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingExpectation

            Me.StatusMessage = "Deleting expectation(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_ExpectationDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.ExpectationDeleted
            Dim tempTable As MaintenanceDataSet.ExpectationDataTable


            If e.Data.Contains("DeletedExpectation") Then
                tempTable = CType(e.Data("DeletedExpectation"), MaintenanceDataSet.ExpectationDataTable)
                Processor.Data.Expectation.Merge(tempTable)
                Processor.Data.Expectation.AcceptChanges()
            End If

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub


#End Region

#Region " EventHandlers for DESP_StoredProcdureAssoc Table "


        Private Sub m_maintenanceProcessor_LoadingDESPRoleAssoc(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.LoadingDESPRoleAssoc

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading DESP Role Association. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_DESPRoleAssocExceedsNonFilteredRowsLimit(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.DESPRoleAssocExceedsNonFilteredRowsLimit

            PrepareGridForDESPRoleAssocTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()
            'Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

            messageLabel.Text = "There are too many DESP Role Association. Please apply filter to load limited number of DESP Role Association."
            m_isFiltered = True
            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DESPRoleAssocLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.DESPRoleAssocLoaded

            PrepareGridForDESPRoleAssocTable()

            ResizeDataGridViewColumns()


        End Sub


        Private Sub m_maintenanceProcessor_InsertingDESPRoleAssoc(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingDESPRoleAssoc
            Dim tempTable As DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Add)
                '                Processor.ValidateDESPRoleInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Inserting new DESP Role Association(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_DESPRoleAssocInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.DESPRoleAssocInserted
            Dim tempTable As DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable


            tempTable = CType(e.Data("NewRows"), DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.DESPData.DESP_StoredProcedureRoleAssoc.LoadingTable = True
            Processor.DESPData.DESP_StoredProcedureRoleAssoc.Merge(tempTable, False)
            Processor.DESPData.DESP_StoredProcedureRoleAssoc.LoadingTable = False
            Processor.DESPData.DESP_StoredProcedureRoleAssoc.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.DESPData.DESP_StoredProcedureRoleAssoc.Merge(tempTable)
            Processor.DESPData.DESP_StoredProcedureRoleAssoc.AcceptChanges()


            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingDESPRoleAssoc(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingDESPRoleAssoc
            Dim tempTable As DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                'Processor.ValidateExpectationInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Updating DESP Role Association(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_DESPRoleAssocUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.DESPRoleAssocUpdated
            Dim tempTable As DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable


            tempTable = CType(e.Data("ModifiedRows"), DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.DESPData.DESP_StoredProcedureRoleAssoc.LoadingTable = True
            Processor.DESPData.DESP_StoredProcedureRoleAssoc.Merge(tempTable, False)
            Processor.DESPData.DESP_StoredProcedureRoleAssoc.LoadingTable = False
            Processor.DESPData.DESP_StoredProcedureRoleAssoc.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.DESPData.DESP_StoredProcedureRoleAssoc.Merge(tempTable)
            Processor.DESPData.DESP_StoredProcedureRoleAssoc.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DeletingDESPRoleAssoc(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingDESPRoleAssoc

            Me.StatusMessage = "Deleting DESP Role Association(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_DESPRoleAssocDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.DESPRoleAssocDeleted
            Dim tempTable As DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable


            If e.Data.Contains("DeletedExpectation") Then
                tempTable = CType(e.Data("DeletedExpectation"), DESPRoleAssoc.DESP_StoredProcedureRoleAssocDataTable)
                Processor.DESPData.DESP_StoredProcedureRoleAssoc.Merge(tempTable)
                Processor.DESPData.DESP_StoredProcedureRoleAssoc.AcceptChanges()
            End If

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub PrepareGridForDESPRoleAssocTable()
            Dim RoleComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
            Dim SPComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn

            maintenanceDataGridView.SuspendLayout()

            RoleComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
            SPComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                          {RoleComboBoxColumn, SPComboBoxColumn})


            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next
            Dim ctr As Integer = 0

            With RoleComboBoxColumn
                .HeaderText = "Role"
                .Name = "RoleComboBoxColumn"
                .DataPropertyName = "RoleId"
                .DisplayMember = "Descrip"
                .ValueMember = "RoleId"
                .DataSource = Processor.DESPData.Role
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            With SPComboBoxColumn
                .HeaderText = "Stored Procedure"
                .Name = "SPComboBoxColumn"
                .DataPropertyName = "StoredProcedureId"
                .DisplayMember = "ProcedureDetails"
                .ValueMember = "StoredProcedureId"
                .DataSource = Processor.DESPData.DESP_StoredProcedure
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            maintenanceDataGridView.DataSource = Processor.DESPData.DESP_StoredProcedureRoleAssoc

            maintenanceDataGridView.ResumeLayout(False)

        End Sub
#End Region

#Region " EventHandlers for DESP_StoredProcedure Table "


        Private Sub m_maintenanceProcessor_LoadingDESPProcedures(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.LoadingDESPProcedures

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading DESP Procedures. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_DESPProceduresExceedsNonFilteredRowsLimit(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.DESPProceduresExceedsNonFilteredRowsLimit

            PrepareGridForDESPProceduresMaintenanceTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()
            'Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

            messageLabel.Text = "There are too many DESP Role Association. Please apply filter to load limited number of DESP Role Association."
            m_isFiltered = True
            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DESPProceduresLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.DESPProceduresLoaded

            PrepareGridForDESPProceduresMaintenanceTable()

            ResizeDataGridViewColumns()


        End Sub


        Private Sub m_maintenanceProcessor_InsertingDESPProcedures(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingDESPProcedures
            Dim tempTable As DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Add)
                '                Processor.ValidateDESPRoleInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Inserting new DESP Procedure(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_DESPProceduresInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.DESPProceduresInserted
            Dim tempTable As DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable


            tempTable = CType(e.Data("NewRows"), DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.DESPData.DESP_StoredProcedureMaintenance.LoadingTable = True
            Processor.DESPData.DESP_StoredProcedureMaintenance.Merge(tempTable, False)
            Processor.DESPData.DESP_StoredProcedureMaintenance.LoadingTable = False
            Processor.DESPData.DESP_StoredProcedureMaintenance.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.DESPData.DESP_StoredProcedureMaintenance.Merge(tempTable)
            Processor.DESPData.DESP_StoredProcedureMaintenance.AcceptChanges()


            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingDESPProcedures(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingDESPProcedures
            Dim tempTable As DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                'Processor.ValidateExpectationInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Updating DESP Procedure(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_DESPProceduresUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.DESPProceduresUpdated
            Dim tempTable As DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable


            tempTable = CType(e.Data("ModifiedRows"), DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.DESPData.DESP_StoredProcedureMaintenance.LoadingTable = True
            Processor.DESPData.DESP_StoredProcedureMaintenance.Merge(tempTable, False)
            Processor.DESPData.DESP_StoredProcedureMaintenance.LoadingTable = False
            Processor.DESPData.DESP_StoredProcedureMaintenance.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.DESPData.DESP_StoredProcedureMaintenance.Merge(tempTable)
            Processor.DESPData.DESP_StoredProcedureMaintenance.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DeletingDESPProcedures(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingDESPProcedures

            Me.StatusMessage = "Deleting DESP Procedure(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_DESPProceduresDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.DESPProceduresDeleted
            Dim tempTable As DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable


            If e.Data.Contains("DeletedExpectation") Then
                tempTable = CType(e.Data("DeletedExpectation"), DESPRoleAssoc.DESP_StoredProcedureMaintenanceDataTable)
                Processor.DESPData.DESP_StoredProcedureMaintenance.Merge(tempTable)
                Processor.DESPData.DESP_StoredProcedureMaintenance.AcceptChanges()
            End If

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub PrepareGridForDESPProceduresMaintenanceTable()
            Dim StoredProcedureIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim ProcedureNameTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
            Dim DescripTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

            'Dim constraintsRow As System.Data.EnumerableRowCollection(Of DESPDataSet.COLUMNSRow)


            maintenanceDataGridView.SuspendLayout()

            StoredProcedureIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            ProcedureNameTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            DescripTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()

            maintenanceDataGridView.DataSource = Nothing
            maintenanceDataGridView.Columns.Clear()
            maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                        {StoredProcedureIdTextBoxColumn, ProcedureNameTextBoxColumn, DescripTextBoxColumn})
            mArray = New List(Of List(Of String))
            For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
                mArray.Add(New List(Of String))
            Next

            Dim ctr As Integer = 0
            With StoredProcedureIdTextBoxColumn
                .ReadOnly = True
                .HeaderText = "StoredProcedure Id"
                .Name = "StoredProcedureIdTextBoxColumn"
                .DataPropertyName = "StoredProcedureId"
                '.Visible = False
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            With ProcedureNameTextBoxColumn
                .HeaderText = "Procedure Name"
                .Name = "ProcedureNameTextBoxColumn"
                .DataPropertyName = "ProcedureName"
                .MaxInputLength = Processor.Data.Media.DescripColumn.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            With DescripTextBoxColumn
                .HeaderText = "Description"
                .Name = "DescripTextBoxColumn"
                .DataPropertyName = "Descrip"
                .MaxInputLength = Processor.Data.Media.DescripColumn.MaxLength
                mArray(ctr).Add(.HeaderText)
                mArray(ctr).Add(.DataPropertyName)
                ctr += 1
            End With

            maintenanceDataGridView.DataSource = Processor.DESPData.DESP_StoredProcedureMaintenance

            StoredProcedureIdTextBoxColumn = Nothing
            ProcedureNameTextBoxColumn = Nothing
            DescripTextBoxColumn = Nothing


            maintenanceDataGridView.ResumeLayout(False)

        End Sub
#End Region

#Region " EventHandlers for Language Table "


        Private Sub m_maintenanceProcessor_LoadingLanguages(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.LoadingLanguages

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading Languages. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_LanguagesLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.LanguagesLoaded

            PrepareGridForLanguageTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_ValidatingLanguage(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.ValidatingLanguage

            Me.StatusMessage = "Validating language(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_LanguageValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.LanguageValidated

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_InvalidLanguageInformationFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.InvalidLanguageInformationFound
            Dim errorText As System.Text.StringBuilder
            Dim tempRows() As System.Data.DataRow
            Dim tempCols() As System.Data.DataColumn
            Dim tempTable As MaintenanceDataSet.LanguageDataTable


            Me.StatusMessage = String.Empty

            errorText = New System.Text.StringBuilder()
            errorText.AppendLine("Invalid inputs found. Cannot save changes.")

            If e.Data.Contains("ValidateRows") Then
                tempTable = CType(e.Data("ValidateRows"), MaintenanceDataSet.LanguageDataTable)
                tempRows = tempTable.GetErrors()

                For i As Integer = 0 To tempRows.Length - 1
                    If tempRows(i).RowState <> DataRowState.Added Then
                        errorText.AppendLine()
                        errorText.Append("Language Id: ")
                        errorText.AppendLine(tempRows(i).Item("LanguageId").ToString())
                    End If

                    If tempRows(i).RowError IsNot Nothing AndAlso tempRows(i).RowError.Length > 0 Then
                        errorText.AppendLine(tempRows(i).RowError)
                    End If

                    tempCols = tempRows(i).GetColumnsInError()

                    For j As Integer = 0 To tempCols.Length - 1
                        errorText.Append((j + 1).ToString())
                        errorText.Append(") ")
                        errorText.Append(tempCols(j).Caption)
                        errorText.Append(" - ")
                        errorText.AppendLine(tempRows(i).GetColumnError(tempCols(j)))
                    Next

                    System.Array.Clear(tempCols, 0, tempCols.Length)
                    tempCols = Nothing
                Next
                System.Array.Clear(tempRows, 0, tempRows.Length)
                tempRows = Nothing
            End If

            MessageBox.Show(errorText.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            errorText.Remove(0, errorText.Length)
            errorText = Nothing

        End Sub

        Private Sub m_maintenanceProcessor_InsertingLanguage(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingLanguage
            Dim tempTable As MaintenanceDataSet.LanguageDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.LanguageDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateLanguageInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Inserting new language(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_LanguageInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.LanguageInserted
            Dim tempTable As MaintenanceDataSet.LanguageDataTable


            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.LanguageDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Language.LoadingTable = True
            Processor.Data.Language.Merge(tempTable, False)
            Processor.Data.Language.LoadingTable = False
            Processor.Data.Language.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Language.Merge(tempTable)
            Processor.Data.Language.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingLanguage(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingLanguage
            Dim tempTable As MaintenanceDataSet.LanguageDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.LanguageDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateLanguageInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Updating language(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_LanguageUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.LanguageUpdated
            Dim tempTable As MaintenanceDataSet.LanguageDataTable


            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.LanguageDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Language.LoadingTable = True
            Processor.Data.Language.Merge(tempTable, False)
            Processor.Data.Language.LoadingTable = False
            Processor.Data.Language.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Language.Merge(tempTable)
            Processor.Data.Language.AcceptChanges()

            tempTable = Nothing

        End Sub

        Private Sub m_maintenanceProcessor_DeletingLanguage(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingLanguage

            Me.StatusMessage = "Deleting language(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_LanguageDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.LanguageDeleted
            Dim tempTable As MaintenanceDataSet.LanguageDataTable


            If e.Data.Contains("DeletedLanguage") = False Then
                MessageBox.Show("Unable to find deleted language information.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                tempTable = CType(e.Data("DeletedLanguage"), MaintenanceDataSet.LanguageDataTable)
                Processor.Data.Language.Merge(tempTable)
                Processor.Data.Language.AcceptChanges()
            End If

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub


#End Region


#Region " EventHandlers for Media Table "


        Private Sub m_maintenanceProcessor_LoadingMediaTypes(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.LoadingMediaTypes

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading media list. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_MediaTypesLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.MediaTypesLoaded

            PrepareGridForMediaTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_ValidatingMediaType(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.ValidatingMediaType

            Me.StatusMessage = "Validating media type(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_MediaTypeValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.MediaTypeValidated

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_InvalidMediaTypeFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.InvalidMediaTypeFound
            Dim errorText As System.Text.StringBuilder
            Dim tempRows() As System.Data.DataRow
            Dim tempCols() As System.Data.DataColumn
            Dim tempTable As MaintenanceDataSet.MediaDataTable


            Me.StatusMessage = String.Empty

            errorText = New System.Text.StringBuilder()
            errorText.AppendLine("Invalid inputs found. Cannot save changes.")

            If e.Data.Contains("ValidateRows") Then
                tempTable = CType(e.Data("ValidateRows"), MaintenanceDataSet.MediaDataTable)
                tempRows = tempTable.GetErrors()

                For i As Integer = 0 To tempRows.Length - 1
                    If tempRows(i).RowState <> DataRowState.Added Then
                        errorText.AppendLine()
                        errorText.Append("Media Id: ")
                        errorText.AppendLine(tempRows(i).Item("MediaId").ToString())
                    End If

                    If tempRows(i).RowError IsNot Nothing AndAlso tempRows(i).RowError.Length > 0 Then
                        errorText.AppendLine(tempRows(i).RowError)
                    End If

                    tempCols = tempRows(i).GetColumnsInError()

                    For j As Integer = 0 To tempCols.Length - 1
                        errorText.Append((j + 1).ToString())
                        errorText.Append(") ")
                        errorText.Append(tempCols(j).Caption)
                        errorText.Append(" - ")
                        errorText.AppendLine(tempRows(i).GetColumnError(tempCols(j)))
                    Next

                    System.Array.Clear(tempCols, 0, tempCols.Length)
                    tempCols = Nothing
                Next
                System.Array.Clear(tempRows, 0, tempRows.Length)
                tempRows = Nothing
            End If

            MessageBox.Show(errorText.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            errorText.Remove(0, errorText.Length)
            errorText = Nothing

        End Sub

        Private Sub m_maintenanceProcessor_InsertingMediaType(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingMediaType
            Dim tempTable As MaintenanceDataSet.MediaDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.MediaDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateMediaInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Inserting new media type(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_MediaTypeInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.MediaTypeInserted
            Dim tempTable As MaintenanceDataSet.MediaDataTable


            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.MediaDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Media.LoadingTable = True
            Processor.Data.Media.Merge(tempTable, False)
            Processor.Data.Media.LoadingTable = False
            Processor.Data.Media.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Media.Merge(tempTable)
            Processor.Data.Media.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingMediaType(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingMediaType
            Dim tempTable As MaintenanceDataSet.MediaDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.MediaDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateMediaInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Updating media type(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_MediaTypeUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.MediaTypeUpdated
            Dim tempTable As MaintenanceDataSet.MediaDataTable


            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.MediaDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Media.LoadingTable = True
            Processor.Data.Media.Merge(tempTable, False)
            Processor.Data.Media.LoadingTable = False
            Processor.Data.Media.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Media.Merge(tempTable)
            Processor.Data.Media.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DeletingMediaType(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingMediaType

            Me.StatusMessage = "Deleting media type(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_MediaTypeDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.MediaTypeDeleted
            Dim tempTable As MaintenanceDataSet.MediaDataTable


            If e.Data.Contains("DeletedMedia") Then
                tempTable = CType(e.Data("DeletedMedia"), MaintenanceDataSet.MediaDataTable)
                Processor.Data.Media.Merge(tempTable)
                Processor.Data.Media.AcceptChanges()
            End If

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub


#End Region


#Region " EventHandlers for Retailers Table "


        Private Sub m_maintenanceProcessor_LoadingRetailers(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.LoadingRetailers

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading Retailers. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_RetailersExceedsNonFilteredRowsLimit(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.RetailersExceedsNonFilteredRowsLimit

            PrepareGridForRetTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            messageLabel.Text = "There are too many Retailers. Please apply filter to load limited number of Retailers."
            m_isFiltered = True

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_RetailersLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.RetailersLoaded

            PrepareGridForRetTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_ValidatingRetailerInformation(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.ValidatingRetailerInformation

            Me.StatusMessage = "Validating retailer information..."

        End Sub

        Private Sub m_maintenanceProcessor_RetailerInformationValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.RetailerInformationValidated

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_InvalidRetailerInformationFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.InvalidRetailerInformationFound
            Dim errorText As System.Text.StringBuilder
            Dim tempRows() As System.Data.DataRow
            Dim tempCols() As System.Data.DataColumn
            Dim tempTable As MaintenanceDataSet.RetDataTable


            Me.StatusMessage = String.Empty

            errorText = New System.Text.StringBuilder()
            errorText.AppendLine("Invalid inputs found. Cannot save changes.")

            If e.Data.Contains("ValidateRows") Then
                tempTable = CType(e.Data("ValidateRows"), MaintenanceDataSet.RetDataTable)
                tempRows = tempTable.GetErrors()

                For i As Integer = 0 To tempRows.Length - 1
                    If tempRows(i).RowState <> DataRowState.Added Then
                        errorText.AppendLine()
                        errorText.Append("Retailer Id: ")
                        errorText.AppendLine(tempRows(i).Item("RetId").ToString())
                    End If

                    If tempRows(i).RowError IsNot Nothing AndAlso tempRows(i).RowError.Length > 0 Then
                        errorText.AppendLine(tempRows(i).RowError)
                    End If

                    tempCols = tempRows(i).GetColumnsInError()

                    For j As Integer = 0 To tempCols.Length - 1
                        errorText.Append((j + 1).ToString())
                        errorText.Append(") ")
                        errorText.Append(tempCols(j).Caption)
                        errorText.Append(" - ")
                        errorText.AppendLine(tempRows(i).GetColumnError(tempCols(j)))
                    Next

                    System.Array.Clear(tempCols, 0, tempCols.Length)
                    tempCols = Nothing
                Next
                System.Array.Clear(tempRows, 0, tempRows.Length)
                tempRows = Nothing
            End If

            MessageBox.Show(errorText.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            errorText.Remove(0, errorText.Length)
            errorText = Nothing

        End Sub

        Private Sub m_maintenanceProcessor_InsertingRetailer(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingRetailer
            Dim tempTable As MaintenanceDataSet.RetDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.RetDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateRetailerInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Inserting new retailer(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_RetailerInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.RetailerInserted
            Dim tempTable As MaintenanceDataSet.RetDataTable


            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.RetDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Ret.LoadingTable = True
            Processor.Data.Ret.Merge(tempTable, False)
            Processor.Data.Ret.LoadingTable = False
            Processor.Data.Ret.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Ret.Merge(tempTable)
            Processor.Data.Ret.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingRetailer(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingRetailer
            Dim tempTable As MaintenanceDataSet.RetDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.RetDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateRetailerInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Updating retailer(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_RetailerUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.RetailerUpdated
            Dim tempTable As MaintenanceDataSet.RetDataTable


            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.RetDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Ret.LoadingTable = True
            Processor.Data.Ret.Merge(tempTable, False)
            Processor.Data.Ret.LoadingTable = False
            Processor.Data.Ret.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Ret.Merge(tempTable)
            Processor.Data.Ret.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DeletingRetailer(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingRetailer

            Me.StatusMessage = "Deleting retailer(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_RetailerDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.RetailerDeleted
            Dim tempTable As MaintenanceDataSet.RetDataTable


            If e.Data.Contains("DeletedRet") Then
                tempTable = CType(e.Data("DeletedRet"), MaintenanceDataSet.RetDataTable)
                Processor.Data.Ret.Merge(tempTable)
                Processor.Data.Ret.AcceptChanges()
            End If

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub


#End Region


#Region " EventHandlers for Tradeclass Table "


        Private Sub m_maintenanceProcessor_LoadingTradeclass(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.LoadingTradeclass

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading tradeclasses. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_TradeclassLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.TradeclassLoaded

            PrepareGridForTradeclassTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()      

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_ValidatingTradeclass(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.ValidatingTradeclass

            Me.StatusMessage = "Validating tradeclass..."

        End Sub

        Private Sub m_maintenanceProcessor_TradeclassValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.TradeclassValidated

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_InvalidTradeclassInformationFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.InvalidTradeclassInformationFound
            Dim errorText As System.Text.StringBuilder
            Dim tempRows() As System.Data.DataRow
            Dim tempCols() As System.Data.DataColumn
            Dim tempTable As MaintenanceDataSet.TradeClassDataTable


            Me.StatusMessage = String.Empty

            errorText = New System.Text.StringBuilder()
            errorText.AppendLine("Invalid inputs found. Cannot save changes.")

            If e.Data.Contains("ValidateRows") Then
                tempTable = CType(e.Data("ValidateRows"), MaintenanceDataSet.TradeClassDataTable)
                tempRows = tempTable.GetErrors()

                For i As Integer = 0 To tempRows.Length - 1
                    If tempRows(i).RowState <> DataRowState.Added Then
                        errorText.AppendLine()
                        errorText.Append("TradeClass Id: ")
                        errorText.AppendLine(tempRows(i).Item("TradeClassId").ToString())
                    End If

                    If tempRows(i).RowError IsNot Nothing AndAlso tempRows(i).RowError.Length > 0 Then
                        errorText.AppendLine(tempRows(i).RowError)
                    End If

                    tempCols = tempRows(i).GetColumnsInError()

                    For j As Integer = 0 To tempCols.Length - 1
                        errorText.Append((j + 1).ToString())
                        errorText.Append(") ")
                        errorText.Append(tempCols(j).Caption)
                        errorText.Append(" - ")
                        errorText.AppendLine(tempRows(i).GetColumnError(tempCols(j)))
                    Next

                    System.Array.Clear(tempCols, 0, tempCols.Length)
                    tempCols = Nothing
                Next
                System.Array.Clear(tempRows, 0, tempRows.Length)
                tempRows = Nothing
            End If

            MessageBox.Show(errorText.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            errorText.Remove(0, errorText.Length)
            errorText = Nothing

        End Sub

        Private Sub m_maintenanceProcessor_InsertingTradeclass(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingTradeclass
            Dim tempTable As MaintenanceDataSet.TradeClassDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.TradeClassDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateTradeclassInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Inserting new tradeclass(es)..."

        End Sub

        Private Sub m_maintenanceProcessor_TradeclassInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.TradeclassInserted
            Dim tempTable As MaintenanceDataSet.TradeClassDataTable


            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.TradeClassDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.TradeClass.LoadingTable = True
            Processor.Data.TradeClass.Merge(tempTable, False)
            Processor.Data.TradeClass.LoadingTable = False
            Processor.Data.TradeClass.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.TradeClass.Merge(tempTable)
            Processor.Data.TradeClass.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingTradeclass(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingTradeclass
            Dim tempTable As MaintenanceDataSet.TradeClassDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.TradeClassDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateTradeclassInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Updating tradeclass(es)..."

        End Sub

        Private Sub m_maintenanceProcessor_TradeclassUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.TradeclassUpdated
            Dim tempTable As MaintenanceDataSet.TradeClassDataTable


            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.TradeClassDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.TradeClass.LoadingTable = True
            Processor.Data.TradeClass.Merge(tempTable, False)
            Processor.Data.TradeClass.LoadingTable = False
            Processor.Data.TradeClass.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.TradeClass.Merge(tempTable)
            Processor.Data.TradeClass.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DeletingTradeclass(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingTradeclass

            Me.StatusMessage = "Deleting tradeclass(es)..."

        End Sub

        Private Sub m_maintenanceProcessor_TradeclassDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.TradeclassDeleted
            Dim tempTable As MaintenanceDataSet.TradeClassDataTable


            If e.Data.Contains("DeletedMedia") Then
                tempTable = CType(e.Data("DeletedTradeclass"), MaintenanceDataSet.TradeClassDataTable)
                Processor.Data.TradeClass.Merge(tempTable)
                Processor.Data.TradeClass.AcceptChanges()
            End If

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub


#End Region


#Region " EventHandlers for Market Table "


        Private Sub m_maintenanceProcessor_LoadingMarkets(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.LoadingMarkets

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading Markets. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_MarketsExceedsNonFilteredRowsLimit(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.MarketsExceedsNonFilteredRowsLimit

            PrepareGridForMarketTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            messageLabel.Text = "There are too many Markets. Please apply filter to load limited number of Markets."
            m_isFiltered = True

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_MarketsLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.MarketsLoaded

            PrepareGridForMarketTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_ValidatingMarketInformation(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.ValidatingMarketInformation

            Me.StatusMessage = "Validating market information..."

        End Sub

        Private Sub m_maintenanceProcessor_MarketInformationValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.MarketInformationValidated

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_InvalidMarketInformationFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.InvalidMarketInformationFound
            Dim errorText As System.Text.StringBuilder
            Dim tempRows() As System.Data.DataRow
            Dim tempCols() As System.Data.DataColumn
            Dim tempTable As MaintenanceDataSet.MktDataTable


            Me.StatusMessage = String.Empty

            errorText = New System.Text.StringBuilder()
            errorText.AppendLine("Invalid inputs found. Cannot save changes.")

            If e.Data.Contains("ValidateRows") Then
                tempTable = CType(e.Data("ValidateRows"), MaintenanceDataSet.MktDataTable)
                tempRows = tempTable.GetErrors()

                For i As Integer = 0 To tempRows.Length - 1
                    If tempRows(i).RowState <> DataRowState.Added Then
                        errorText.AppendLine()
                        errorText.Append("Market Id: ")
                        errorText.AppendLine(tempRows(i).Item("MktId").ToString())
                    End If

                    If tempRows(i).RowError IsNot Nothing AndAlso tempRows(i).RowError.Length > 0 Then
                        errorText.AppendLine(tempRows(i).RowError)
                    End If

                    tempCols = tempRows(i).GetColumnsInError()

                    For j As Integer = 0 To tempCols.Length - 1
                        errorText.Append((j + 1).ToString())
                        errorText.Append(") ")
                        errorText.Append(tempCols(j).Caption)
                        errorText.Append(" - ")
                        errorText.AppendLine(tempRows(i).GetColumnError(tempCols(j)))
                    Next

                    System.Array.Clear(tempCols, 0, tempCols.Length)
                    tempCols = Nothing
                Next
                System.Array.Clear(tempRows, 0, tempRows.Length)
                tempRows = Nothing
            End If

            MessageBox.Show(errorText.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            errorText.Remove(0, errorText.Length)
            errorText = Nothing

        End Sub

        Private Sub m_maintenanceProcessor_InsertingMarket(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingMarket
            Dim tempTable As MaintenanceDataSet.MktDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.MktDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateMarketInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Inserting new market(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_MarketInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.MarketInserted
            Dim tempTable As MaintenanceDataSet.MktDataTable


            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.MktDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Mkt.LoadingTable = True
            Processor.Data.Mkt.Merge(tempTable, False)
            Processor.Data.Mkt.LoadingTable = False
            Processor.Data.Mkt.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Mkt.Merge(tempTable)
            Processor.Data.Mkt.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingMarket(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingMarket
            Dim tempTable As MaintenanceDataSet.MktDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.MktDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateMarketInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Updating market(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_MarketUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.MarketUpdated
            Dim tempTable As MaintenanceDataSet.MktDataTable


            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.MktDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Mkt.LoadingTable = True
            Processor.Data.Mkt.Merge(tempTable, False)
            Processor.Data.Mkt.LoadingTable = False
            Processor.Data.Mkt.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Mkt.Merge(tempTable)
            Processor.Data.Mkt.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DeletingMarket(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingMarket

            Me.StatusMessage = "Deleting market(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_MarketDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.MarketDeleted
            Dim tempTable As MaintenanceDataSet.MktDataTable


            If e.Data.Contains("DeletedMkt") Then
                tempTable = CType(e.Data("DeletedMkt"), MaintenanceDataSet.MktDataTable)
                Processor.Data.Mkt.Merge(tempTable)
                Processor.Data.Mkt.AcceptChanges()
            End If

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub


#End Region


#Region " EventHandlers for Publication Table "


        Private Sub m_maintenanceProcessor_LoadingPublications(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.LoadingPublications

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading Publications. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_PublicationsExceedsNonFilteredRowsLimit(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.PublicationsExceedsNonFilteredRowsLimit

            PrepareGridForPublicationTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            messageLabel.Text = "There are too many Publications. Please apply filter to load limited number of Publications."
            m_isFiltered = True

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_PublicationsLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.PublicationsLoaded

            PrepareGridForPublicationTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_PublicationSubscriptionLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.PublicationSubscriptionLoaded

            PrepareGridForPublicationSubscriptionTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_ValidatingPublicationInformation(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.ValidatingPublicationInformation

            Me.StatusMessage = "Validating publication information..."

        End Sub

        Private Sub m_maintenanceProcessor_PublicationInformationValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.PublicationInformationValidated

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_InvalidPublicationInformationFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.InvalidPublicationInformationFound
            Dim errorText As System.Text.StringBuilder
            Dim tempRows() As System.Data.DataRow
            Dim tempCols() As System.Data.DataColumn
            Dim tempTable As MaintenanceDataSet.PublicationDataTable


            Me.StatusMessage = String.Empty

            errorText = New System.Text.StringBuilder()
            errorText.AppendLine("Invalid inputs found. Cannot save changes.")

            If e.Data.Contains("ValidateRows") Then
                tempTable = CType(e.Data("ValidateRows"), MaintenanceDataSet.PublicationDataTable)
                tempRows = tempTable.GetErrors()

                For i As Integer = 0 To tempRows.Length - 1
                    If tempRows(i).RowState <> DataRowState.Added Then
                        errorText.AppendLine()
                        errorText.Append("Publication Id: ")
                        errorText.AppendLine(tempRows(i).Item("PublicationId").ToString())
                    End If

                    If tempRows(i).RowError IsNot Nothing AndAlso tempRows(i).RowError.Length > 0 Then
                        errorText.AppendLine(tempRows(i).RowError)
                    End If

                    tempCols = tempRows(i).GetColumnsInError()

                    For j As Integer = 0 To tempCols.Length - 1
                        errorText.Append((j + 1).ToString())
                        errorText.Append(") ")
                        errorText.Append(tempCols(j).Caption)
                        errorText.Append(" - ")
                        errorText.AppendLine(tempRows(i).GetColumnError(tempCols(j)))
                    Next

                    System.Array.Clear(tempCols, 0, tempCols.Length)
                    tempCols = Nothing
                Next
                System.Array.Clear(tempRows, 0, tempRows.Length)
                tempRows = Nothing
            End If

            MessageBox.Show(errorText.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            errorText.Remove(0, errorText.Length)
            errorText = Nothing

        End Sub

        Private Sub m_maintenanceProcessor_InsertingPublication(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingPublication
            Dim tempTable As MaintenanceDataSet.PublicationDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.PublicationDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidatePublicationInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Inserting new publication(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_PublicationInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.PublicationInserted
            Dim tempTable As MaintenanceDataSet.PublicationDataTable


            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.PublicationDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Publication.LoadingTable = True
            Processor.Data.Publication.Merge(tempTable, False)
            Processor.Data.Publication.LoadingTable = False
            Processor.Data.Publication.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Publication.Merge(tempTable)
            Processor.Data.Publication.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingPublication(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingPublication
            Dim tempTable As MaintenanceDataSet.PublicationDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.PublicationDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidatePublicationInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Updating publication(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_PublicationUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.PublicationUpdated
            Dim tempTable As MaintenanceDataSet.PublicationDataTable


            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.PublicationDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Publication.LoadingTable = True
            Processor.Data.Publication.Merge(tempTable, False)
            Processor.Data.Publication.LoadingTable = False
            Processor.Data.Publication.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Publication.Merge(tempTable)
            Processor.Data.Publication.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DeletingPublication(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingPublication

            Me.StatusMessage = "Deleting publication(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_PublicationDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.PublicationDeleted
            Dim tempTable As MaintenanceDataSet.PublicationDataTable


            If e.Data.Contains("DeletedPublication") Then
                tempTable = CType(e.Data("DeletedPublication"), MaintenanceDataSet.PublicationDataTable)
                Processor.Data.Publication.Merge(tempTable)
                Processor.Data.Publication.AcceptChanges()
            End If

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub


#End Region


#Region " EventHandlers for RetPublicationCoverage Table "


        Private Sub m_maintenanceProcessor_LoadingRetPublicationCoverage(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.LoadingRetPublicationCoverage

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading Retailer Publication Coverage. This may take some time. Please wait..."
            ' RetPublicationCoverage() Changed to Add Mktid
            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_RetPublicationCoverageExceedsNonFilteredRowsLimit(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.RetPublicationCoverageExceedsNonFilteredRowsLimit

            PrepareGridForRetPublicationCoverageTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            messageLabel.Text = "There are too many Retailer Publication Coverage. Please apply filter to load limited number of Retailers Publication Coverage information."
            m_isFiltered = True
            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_RetPublicationCoverageLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.RetPublicationCoverageLoaded

            PrepareGridForRetPublicationCoverageTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_ValidatingRetPublicationCoverage(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.ValidatingRetPublicationCoverage

            Me.StatusMessage = "Validating retailer publication coverage(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_RetPublicationCoverageValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.RetPublicationCoverageValidated

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_InvalidRetPublicationCoverageFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.InvalidRetPublicationCoverageFound
            Dim errorText As System.Text.StringBuilder
            Dim tempRows() As System.Data.DataRow
            Dim tempCols() As System.Data.DataColumn
            Dim tempTable As MaintenanceDataSet.RetPublicationCoverageDataTable


            Me.StatusMessage = String.Empty

            errorText = New System.Text.StringBuilder()
            errorText.AppendLine("Invalid inputs found. Cannot save changes.")

            If e.Data.Contains("ValidateRows") Then
                tempTable = CType(e.Data("ValidateRows"), MaintenanceDataSet.RetPublicationCoverageDataTable)
                tempRows = tempTable.GetErrors()

                For i As Integer = 0 To tempRows.Length - 1
                    If tempRows(i).RowError IsNot Nothing AndAlso tempRows(i).RowError.Length > 0 Then
                        errorText.AppendLine(tempRows(i).RowError)
                    End If

                    tempCols = tempRows(i).GetColumnsInError()

                    For j As Integer = 0 To tempCols.Length - 1
                        errorText.Append((j + 1).ToString())
                        errorText.Append(") ")
                        errorText.Append(tempCols(j).Caption)
                        errorText.Append(" - ")
                        errorText.AppendLine(tempRows(i).GetColumnError(tempCols(j)))
                    Next

                    System.Array.Clear(tempCols, 0, tempCols.Length)
                    tempCols = Nothing
                Next
                System.Array.Clear(tempRows, 0, tempRows.Length)
                tempRows = Nothing
            End If

            MessageBox.Show(errorText.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            errorText.Remove(0, errorText.Length)
            errorText = Nothing

        End Sub

        Private Sub m_maintenanceProcessor_InsertingRetPublicationCoverage(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingRetPublicationCoverage
            Dim tempTable As MaintenanceDataSet.RetPublicationCoverageDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.RetPublicationCoverageDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateRetPublicationCoverageInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Inserting new retailer publication coverage(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_RetPublicationCoverageInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.RetPublicationCoverageInserted
            Dim tempTable As MaintenanceDataSet.RetPublicationCoverageDataTable


            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.RetPublicationCoverageDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.RetPublicationCoverage.LoadingTable = True
            Processor.Data.RetPublicationCoverage.Merge(tempTable, False)
            Processor.Data.RetPublicationCoverage.LoadingTable = False
            Processor.Data.RetPublicationCoverage.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.RetPublicationCoverage.Merge(tempTable)
            Processor.Data.RetPublicationCoverage.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingRetPublicationCoverage(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingRetPublicationCoverage
            Dim tempTable As MaintenanceDataSet.RetPublicationCoverageDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.RetPublicationCoverageDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateRetPublicationCoverageInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Updating retailer publication coverage(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_RetPublicationCoverageUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.RetPublicationCoverageUpdated
            Dim tempTable As MaintenanceDataSet.RetPublicationCoverageDataTable


            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.RetPublicationCoverageDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.RetPublicationCoverage.LoadingTable = True
            Processor.Data.RetPublicationCoverage.Merge(tempTable, False)
            Processor.Data.RetPublicationCoverage.LoadingTable = False
            Processor.Data.RetPublicationCoverage.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.RetPublicationCoverage.Merge(tempTable)
            Processor.Data.RetPublicationCoverage.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DeletingRetPublicationCoverage(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingRetPublicationCoverage

            Me.StatusMessage = "Deleting retailer publication coverage(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_RetPublicationCoverageDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.RetPublicationCoverageDeleted
            Dim tempTable As MaintenanceDataSet.RetPublicationCoverageDataTable


            If e.Data.Contains("DeletedRet") Then
                tempTable = CType(e.Data("DeletedRet"), MaintenanceDataSet.RetPublicationCoverageDataTable)
                Processor.Data.RetPublicationCoverage.Merge(tempTable)
                Processor.Data.RetPublicationCoverage.AcceptChanges()
            End If

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub


#End Region


#Region " EventHandlers for Sender Table "


        Private Sub m_maintenanceProcessor_LoadingSenders(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.LoadingSenders

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading senders. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_SenderExceedsNonFilteredRowsLimit(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderExceedsNonFilteredRowsLimit

            PrepareGridForSenderTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            messageLabel.Text = "There are too many senders. Please apply filter to load limited number of senders."
            m_isFiltered = True
            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_SendersLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SendersLoaded

            PrepareGridForSenderTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_ValidatingSenderInformation(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.ValidatingSenderInformation

            Me.StatusMessage = "Validating sender information..."

        End Sub

        Private Sub m_maintenanceProcessor_SenderInformationValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderInformationValidated

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_InvalidSenderInformationFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.InvalidSenderInformationFound
            Dim errorText As System.Text.StringBuilder
            Dim tempRows() As System.Data.DataRow
            Dim tempCols() As System.Data.DataColumn
            Dim tempTable As MaintenanceDataSet.SenderDataTable


            Me.StatusMessage = String.Empty

            errorText = New System.Text.StringBuilder()
            errorText.AppendLine("Invalid inputs found. Cannot save changes.")

            If e.Data.Contains("ValidateRows") Then
                tempTable = CType(e.Data("ValidateRows"), MaintenanceDataSet.SenderDataTable)
                tempRows = tempTable.GetErrors()

                For i As Integer = 0 To tempRows.Length - 1
                    If tempRows(i).RowState <> DataRowState.Added Then
                        errorText.AppendLine()
                        errorText.Append("Sender Id: ")
                        errorText.AppendLine(tempRows(i).Item("SenderId").ToString())
                    End If

                    If tempRows(i).RowError IsNot Nothing AndAlso tempRows(i).RowError.Length > 0 Then
                        errorText.AppendLine(tempRows(i).RowError)
                    End If

                    tempCols = tempRows(i).GetColumnsInError()

                    For j As Integer = 0 To tempCols.Length - 1
                        errorText.Append((j + 1).ToString())
                        errorText.Append(") ")
                        errorText.Append(tempCols(j).Caption)
                        errorText.Append(" - ")
                        errorText.AppendLine(tempRows(i).GetColumnError(tempCols(j)))
                    Next

                    System.Array.Clear(tempCols, 0, tempCols.Length)
                    tempCols = Nothing
                Next
                System.Array.Clear(tempRows, 0, tempRows.Length)
                tempRows = Nothing
            End If

            MessageBox.Show(errorText.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            errorText.Remove(0, errorText.Length)
            errorText = Nothing

        End Sub

        Private Sub m_maintenanceProcessor_InsertingSender(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingSender
            Dim tempTable As MaintenanceDataSet.SenderDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.SenderDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateSenderInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Inserting new sender(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_SenderInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderInserted
            Dim tempTable As System.Data.DataTable


            tempTable = CType(e.Data("NewRows"), System.Data.DataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Sender.LoadingTable = True
            Processor.Data.Sender.Merge(tempTable, False)
            Processor.Data.Sender.LoadingTable = False
            Processor.Data.Sender.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Sender.Merge(tempTable)
            Processor.Data.Sender.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingSender(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingSender
            Dim tempTable As MaintenanceDataSet.SenderDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.SenderDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateSenderInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Updating sender(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_SenderUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderUpdated
            Dim tempTable As System.Data.DataTable


            tempTable = CType(e.Data("ModifiedRows"), System.Data.DataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Sender.LoadingTable = True
            Processor.Data.Sender.Merge(tempTable, False)
            Processor.Data.Sender.LoadingTable = False
            Processor.Data.Sender.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Sender.Merge(tempTable)
            Processor.Data.Sender.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DeletingSender(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingSender

            Me.StatusMessage = "Deleting sender(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_SenderDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderDeleted
            Dim tempTable As MaintenanceDataSet.SenderDataTable


            If e.Data.Contains("DeletedSender") Then
                tempTable = CType(e.Data("DeletedSender"), MaintenanceDataSet.SenderDataTable)
                Processor.Data.Sender.Merge(tempTable)
                Processor.Data.Sender.AcceptChanges()
            End If

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub


#End Region


#Region " EventHandlers for Sender Association Table "


        Private Sub m_maintenanceProcessor_LoadingSenderMktAssoc(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.LoadingSenderMktAssoc

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading Sender Market association. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_LoadingSenderPublication(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.LoadingSenderPublication

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading Sender Publication association. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_LoadingSenderExpectation(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.LoadingSenderExpectation

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading Sender Expectation association. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable("vwSenderExpectation")

        End Sub

        Private Sub m_maintenanceProcessor_SenderMktAssocExceedsNonFilteredRowsLimit(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderMktAssocExceedsNonFilteredRowsLimit

            PrepareGridForSenderMktAssocTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            messageLabel.Text = "There are too many Sender Market associations. Please apply filter to load limited number of Retailers Publication Coverage information."
            m_isFiltered = True
            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_SenderPublicationExceedsNonFilteredRowsLimit(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderPublicationExceedsNonFilteredRowsLimit

            PrepareGridForSenderPublicationTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            messageLabel.Text = "There are too many Sender Market associations. Please apply filter to load limited number of Retailers Publication Coverage information."
            m_isFiltered = True
            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_SenderExpectationExceedsNonFilteredRowsLimit(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderExpectationExceedsNonFilteredRowsLimit

            PrepareGridForSenderExpectationTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            messageLabel.Text = "There are too many Sender Expectation. Please apply filter to load limited number of Sender Expectation information."
            m_isFiltered = True
            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_SenderMktAssocLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderMktAssocLoaded

            PrepareGridForSenderMktAssocTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_SenderPublicationLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderPublicationLoaded

            PrepareGridForSenderPublicationTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            Me.StatusMessage = String.Empty

        End Sub


        Private Sub m_maintenanceProcessor_SenderExpectationLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderExpectationLoaded

            PrepareGridForSenderExpectationTableText()

            ResizeDataGridViewColumns()

            'Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_ValidatingSenderMktAssoc(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.ValidatingSenderMktAssoc

            Me.StatusMessage = "Validating sender market association(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_ValidatingSenderPublication(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.ValidatingSenderPublication

            Me.StatusMessage = "Validating sender Publication association(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_ValidatingSenderExpectation(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.ValidatingSenderExpectation

            Me.StatusMessage = "Validating sender Expectation association(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_SenderMktAssocValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderMktAssocValidated

            Me.StatusMessage = String.Empty

        End Sub


        Private Sub m_maintenanceProcessor_SenderPublicationValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderPublicationValidated

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_SenderExpectationValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderPublicationValidated

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_InvalidSenderMktAssocFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.InvalidSenderMktAssocFound
            Dim errorText As System.Text.StringBuilder
            Dim tempRows() As System.Data.DataRow
            Dim tempCols() As System.Data.DataColumn
            Dim tempTable As MaintenanceDataSet.SenderMktAssocDataTable


            Me.StatusMessage = String.Empty

            errorText = New System.Text.StringBuilder()
            errorText.AppendLine("Invalid inputs found. Cannot save changes.")

            If e.Data.Contains("ValidateRows") Then
                tempTable = CType(e.Data("ValidateRows"), MaintenanceDataSet.SenderMktAssocDataTable)
                tempRows = tempTable.GetErrors()

                For i As Integer = 0 To tempRows.Length - 1
                    If tempRows(i).RowError IsNot Nothing AndAlso tempRows(i).RowError.Length > 0 Then
                        errorText.AppendLine(tempRows(i).RowError)
                    End If

                    tempCols = tempRows(i).GetColumnsInError()

                    For j As Integer = 0 To tempCols.Length - 1
                        errorText.Append((j + 1).ToString())
                        errorText.Append(") ")
                        errorText.Append(tempCols(j).Caption)
                        errorText.Append(" - ")
                        errorText.AppendLine(tempRows(i).GetColumnError(tempCols(j)))
                    Next

                    System.Array.Clear(tempCols, 0, tempCols.Length)
                    tempCols = Nothing
                Next
                System.Array.Clear(tempRows, 0, tempRows.Length)
                tempRows = Nothing
            End If

            MessageBox.Show(errorText.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            errorText.Remove(0, errorText.Length)
            errorText = Nothing

        End Sub

        Private Sub m_maintenanceProcessor_InvalidSenderPublicationFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.InvalidSenderPublicationFound
            Dim errorText As System.Text.StringBuilder
            Dim tempRows() As System.Data.DataRow
            Dim tempCols() As System.Data.DataColumn
            Dim tempTable As MaintenanceDataSet.SenderPublicationDataTable


            Me.StatusMessage = String.Empty

            errorText = New System.Text.StringBuilder()
            errorText.AppendLine("Invalid inputs found. Cannot save changes.")

            If e.Data.Contains("ValidateRows") Then
                tempTable = CType(e.Data("ValidateRows"), MaintenanceDataSet.SenderPublicationDataTable)
                tempRows = tempTable.GetErrors()

                For i As Integer = 0 To tempRows.Length - 1
                    If tempRows(i).RowError IsNot Nothing AndAlso tempRows(i).RowError.Length > 0 Then
                        errorText.AppendLine(tempRows(i).RowError)
                    End If

                    tempCols = tempRows(i).GetColumnsInError()

                    For j As Integer = 0 To tempCols.Length - 1
                        errorText.Append((j + 1).ToString())
                        errorText.Append(") ")
                        errorText.Append(tempCols(j).Caption)
                        errorText.Append(" - ")
                        errorText.AppendLine(tempRows(i).GetColumnError(tempCols(j)))
                    Next

                    System.Array.Clear(tempCols, 0, tempCols.Length)
                    tempCols = Nothing
                Next
                System.Array.Clear(tempRows, 0, tempRows.Length)
                tempRows = Nothing
            End If

            MessageBox.Show(errorText.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            errorText.Remove(0, errorText.Length)
            errorText = Nothing

        End Sub

        Private Sub m_maintenanceProcessor_InvalidSenderExpectationFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.InvalidSenderExpectationFound
            Dim errorText As System.Text.StringBuilder
            Dim tempRows() As System.Data.DataRow
            Dim tempCols() As System.Data.DataColumn
            Dim tempTable As MaintenanceDataSet.SenderExpectationDataTable


            Me.StatusMessage = String.Empty

            errorText = New System.Text.StringBuilder()
            errorText.AppendLine("Invalid inputs found. Cannot save changes.")

            If e.Data.Contains("ValidateRows") Then
                tempTable = CType(e.Data("ValidateRows"), MaintenanceDataSet.SenderExpectationDataTable)
                tempRows = tempTable.GetErrors()

                For i As Integer = 0 To tempRows.Length - 1
                    If tempRows(i).RowError IsNot Nothing AndAlso tempRows(i).RowError.Length > 0 Then
                        errorText.AppendLine(tempRows(i).RowError)
                    End If

                    tempCols = tempRows(i).GetColumnsInError()

                    For j As Integer = 0 To tempCols.Length - 1
                        errorText.Append((j + 1).ToString())
                        errorText.Append(") ")
                        errorText.Append(tempCols(j).Caption)
                        errorText.Append(" - ")
                        errorText.AppendLine(tempRows(i).GetColumnError(tempCols(j)))
                    Next

                    System.Array.Clear(tempCols, 0, tempCols.Length)
                    tempCols = Nothing
                Next
                System.Array.Clear(tempRows, 0, tempRows.Length)
                tempRows = Nothing
            End If

            MessageBox.Show(errorText.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            errorText.Remove(0, errorText.Length)
            errorText = Nothing

        End Sub

        Private Sub m_maintenanceProcessor_InsertingSenderMktAssoc(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingSenderMktAssoc
            Dim tempTable As MaintenanceDataSet.SenderMktAssocDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.SenderMktAssocDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateSenderMktAssocInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            Me.StatusMessage = "Inserting new sender market association(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_InsertingSenderPublication(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingSenderPublication
            Dim tempTable As MaintenanceDataSet.SenderPublicationDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.SenderPublicationDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateSenderPublicationInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            Me.StatusMessage = "Inserting new sender market association(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_InsertingSenderExpectation(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingSenderExpectation
            Dim tempTable As MaintenanceDataSet.SenderExpectationDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.SenderExpectationDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateSenderExpectationInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            Me.StatusMessage = "Inserting new sender market association(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_SenderMktAssocInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderMktAssocInserted
            Dim tempTable As MaintenanceDataSet.SenderMktAssocDataTable


            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.SenderMktAssocDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.SenderMktAssoc.LoadingTable = True
            Processor.Data.SenderMktAssoc.Merge(tempTable, False)
            Processor.Data.SenderMktAssoc.LoadingTable = False
            Processor.Data.SenderMktAssoc.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.SenderMktAssoc.Merge(tempTable)
            Processor.Data.SenderMktAssoc.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_SenderExpectationInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderExpectationInserted
            Dim tempTable As MaintenanceDataSet.SenderExpectationDataTable


            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.SenderExpectationDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.SenderExpectation.LoadingTable = True
            Processor.Data.SenderExpectation.Merge(tempTable, False)
            Processor.Data.SenderExpectation.LoadingTable = False
            Processor.Data.SenderExpectation.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.SenderExpectation.Merge(tempTable)
            Processor.Data.SenderExpectation.AcceptChanges()

            _InsertStatus = True
            tempTable = Nothing

            Me.StatusMessage = String.Empty
            _DataRefresh = False
        End Sub

        Private Sub m_maintenanceProcessor_UpdatingSenderMktAssoc(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingSenderMktAssoc
            Dim tempTable As MaintenanceDataSet.SenderMktAssocDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.SenderMktAssocDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateSenderMktAssocInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            Me.StatusMessage = "Updating sender market association(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingSenderPublication(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingSenderPublication
            Dim tempTable As MaintenanceDataSet.SenderPublicationDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.SenderPublicationDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateSenderPublicationInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            Me.StatusMessage = "Updating sender market association(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingSenderExpectation(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingSenderExpectation
            Dim tempTable As MaintenanceDataSet.SenderExpectationDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.SenderExpectationDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateSenderExpectationInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            Me.StatusMessage = "Updating sender market association(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_SenderMktAssocUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderMktAssocUpdated
            Dim tempTable As MaintenanceDataSet.SenderMktAssocDataTable


            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.SenderMktAssocDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.SenderMktAssoc.LoadingTable = True
            Processor.Data.SenderMktAssoc.Merge(tempTable, False)
            Processor.Data.SenderMktAssoc.LoadingTable = False
            Processor.Data.SenderMktAssoc.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.SenderMktAssoc.Merge(tempTable)
            Processor.Data.SenderMktAssoc.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_SenderPublicationUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderPublicationUpdated
            Dim tempTable As MaintenanceDataSet.SenderPublicationDataTable


            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.SenderPublicationDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.SenderPublication.LoadingTable = True
            Processor.Data.SenderPublication.Merge(tempTable, False)
            Processor.Data.SenderPublication.LoadingTable = False
            Processor.Data.SenderPublication.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.SenderPublication.Merge(tempTable)
            Processor.Data.SenderPublication.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_SenderExpectationUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderExpectationUpdated
            Dim tempTable As MaintenanceDataSet.SenderExpectationDataTable


            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.SenderExpectationDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.SenderExpectation.LoadingTable = True
            Processor.Data.SenderExpectation.Merge(tempTable, False)
            Processor.Data.SenderExpectation.LoadingTable = False
            Processor.Data.SenderExpectation.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.SenderExpectation.Merge(tempTable)
            Processor.Data.SenderExpectation.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DeletingSenderMktAssoc(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingSenderMktAssoc

            Me.StatusMessage = "Deleting sender market association(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_DeletingSenderPublication(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingSenderMktAssoc

            Me.StatusMessage = "Deleting sender Publication association(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_DeletingSenderExpectation(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingSenderMktAssoc

            Me.StatusMessage = "Deleting sender Expectation association(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_SenderMktAssocDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderMktAssocDeleted
            Dim tempTable As MaintenanceDataSet.SenderMktAssocDataTable


            If e.Data.Contains("DeletedRet") Then
                tempTable = CType(e.Data("DeletedRet"), MaintenanceDataSet.SenderMktAssocDataTable)
                Processor.Data.SenderMktAssoc.Merge(tempTable)
                Processor.Data.SenderMktAssoc.AcceptChanges()
            End If

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_SenderPublicationDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SenderPublicationDeleted
            Dim tempTable As MaintenanceDataSet.SenderPublicationDataTable


            If e.Data.Contains("DeletedRet") Then
                tempTable = CType(e.Data("DeletedRet"), MaintenanceDataSet.SenderPublicationDataTable)
                Processor.Data.SenderPublication.Merge(tempTable)
                Processor.Data.SenderPublication.AcceptChanges()
            End If

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub


#End Region


#Region " EventHandlers for Shipper Table "


        Private Sub m_maintenanceProcessor_LoadingShippers(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.LoadingShippers

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading Shipper information. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_ShipperExceedsNonFilteredRowsLimit(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.ShipperExceedsNonFilteredRowsLimit

            PrepareGridForShipperTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            messageLabel.Text = "There are too many Shippers. Please apply filter to load limited number of Shippers."
            m_isFiltered = True
            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_ShippersLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.ShippersLoaded

            PrepareGridForShipperTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_ValidatingShipper(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.ValidatingShipper

            Me.StatusMessage = "Validating shipper information..."

        End Sub

        Private Sub m_maintenanceProcessor_ShipperValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.ShipperValidated

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_InvalidShipperFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.InvalidShipperFound
            Dim errorText As System.Text.StringBuilder
            Dim tempRows() As System.Data.DataRow
            Dim tempCols() As System.Data.DataColumn
            Dim tempTable As MaintenanceDataSet.ShipperDataTable


            Me.StatusMessage = String.Empty

            errorText = New System.Text.StringBuilder()
            errorText.AppendLine("Invalid inputs found. Cannot save changes.")

            If e.Data.Contains("ValidateRows") Then
                tempTable = CType(e.Data("ValidateRows"), MaintenanceDataSet.ShipperDataTable)
                tempRows = tempTable.GetErrors()

                For i As Integer = 0 To tempRows.Length - 1
                    If tempRows(i).RowState <> DataRowState.Added Then
                        errorText.AppendLine()
                        errorText.Append("Shipper Id: ")
                        errorText.AppendLine(tempRows(i).Item("ShipperId").ToString())
                    End If

                    If tempRows(i).RowError IsNot Nothing AndAlso tempRows(i).RowError.Length > 0 Then
                        errorText.AppendLine(tempRows(i).RowError)
                    End If

                    tempCols = tempRows(i).GetColumnsInError()

                    For j As Integer = 0 To tempCols.Length - 1
                        errorText.Append((j + 1).ToString())
                        errorText.Append(") ")
                        errorText.Append(tempCols(j).Caption)
                        errorText.Append(" - ")
                        errorText.AppendLine(tempRows(i).GetColumnError(tempCols(j)))
                    Next

                    System.Array.Clear(tempCols, 0, tempCols.Length)
                    tempCols = Nothing
                Next
                System.Array.Clear(tempRows, 0, tempRows.Length)
                tempRows = Nothing
            End If

            MessageBox.Show(errorText.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            errorText.Remove(0, errorText.Length)
            errorText = Nothing

        End Sub

        Private Sub m_maintenanceProcessor_InsertingShipper(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingShipper
            Dim tempTable As MaintenanceDataSet.ShipperDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.ShipperDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateShipperInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Inserting new shipper(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_ShipperInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.ShipperInserted
            Dim tempTable As System.Data.DataTable


            tempTable = CType(e.Data("NewRows"), System.Data.DataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Shipper.LoadingTable = True
            Processor.Data.Shipper.Merge(tempTable, False)
            Processor.Data.Shipper.LoadingTable = False
            Processor.Data.Shipper.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Shipper.Merge(tempTable)
            Processor.Data.Shipper.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingShipper(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingShipper
            Dim tempTable As MaintenanceDataSet.ShipperDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.ShipperDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateShipperInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Updating shipper(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_ShipperUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.ShipperUpdated
            Dim tempTable As System.Data.DataTable


            tempTable = CType(e.Data("ModifiedRows"), System.Data.DataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Shipper.LoadingTable = True
            Processor.Data.Shipper.Merge(tempTable, False)
            Processor.Data.Shipper.LoadingTable = False
            Processor.Data.Shipper.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Shipper.Merge(tempTable)
            Processor.Data.Shipper.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DeletingShipper(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingShipper

            Me.StatusMessage = "Deleting shipper(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_ShipperDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.ShipperDeleted
            Dim tempTable As MaintenanceDataSet.ShipperDataTable


            If e.Data.Contains("DeletedShipper") Then
                tempTable = CType(e.Data("DeletedShipper"), MaintenanceDataSet.ShipperDataTable)
                Processor.Data.Shipper.Merge(tempTable)
                Processor.Data.Shipper.AcceptChanges()
            End If

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub


#End Region


#Region " EventHandlers for Size Table "


        Private Sub m_maintenanceProcessor_LoadingSizes(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.LoadingSizes

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading list of page size. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_SizesExceedsNonFilteredRowsLimit(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SizesExceedsNonFilteredRowsLimit

            PrepareGridForSizeTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            messageLabel.Text = "There are too many Sizes. Please apply filter to load limited number of Sizes."
            m_isFiltered = True
            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_SizesLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SizesLoaded

            PrepareGridForSizeTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_ValidatingSize(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.ValidatingSize

            Me.StatusMessage = "Validating size(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_SizeValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SizeValidated

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_InvalidSizeFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.InvalidSizeFound
            Dim errorText As System.Text.StringBuilder
            Dim tempRows() As System.Data.DataRow
            Dim tempCols() As System.Data.DataColumn
            Dim tempTable As MaintenanceDataSet.SizeDataTable


            Me.StatusMessage = String.Empty

            errorText = New System.Text.StringBuilder()
            errorText.AppendLine("Invalid inputs found. Cannot save changes.")

            If e.Data.Contains("ValidateRows") Then
                tempTable = CType(e.Data("ValidateRows"), MaintenanceDataSet.SizeDataTable)
                tempRows = tempTable.GetErrors()

                For i As Integer = 0 To tempRows.Length - 1
                    If tempRows(i).RowState <> DataRowState.Added Then
                        errorText.AppendLine()
                        errorText.Append("Size Id: ")
                        errorText.AppendLine(tempRows(i).Item("SizeId").ToString())
                    End If

                    If tempRows(i).RowError IsNot Nothing AndAlso tempRows(i).RowError.Length > 0 Then
                        errorText.AppendLine(tempRows(i).RowError)
                    End If

                    tempCols = tempRows(i).GetColumnsInError()

                    For j As Integer = 0 To tempCols.Length - 1
                        errorText.Append((j + 1).ToString())
                        errorText.Append(") ")
                        errorText.Append(tempCols(j).Caption)
                        errorText.Append(" - ")
                        errorText.AppendLine(tempRows(i).GetColumnError(tempCols(j)))
                    Next

                    System.Array.Clear(tempCols, 0, tempCols.Length)
                    tempCols = Nothing
                Next
                System.Array.Clear(tempRows, 0, tempRows.Length)
                tempRows = Nothing
            End If

            MessageBox.Show(errorText.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

            errorText.Remove(0, errorText.Length)
            errorText = Nothing

        End Sub

        Private Sub m_maintenanceProcessor_InsertingSize(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingSize
            Dim tempTable As MaintenanceDataSet.SizeDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.SizeDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateSizeInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Inserting new size(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_SizeInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SizeInserted
            Dim tempTable As System.Data.DataTable


            tempTable = CType(e.Data("NewRows"), System.Data.DataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Size.LoadingTable = True
            Processor.Data.Size.Merge(tempTable, False)
            Processor.Data.Size.LoadingTable = False
            Processor.Data.Size.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Size.Merge(tempTable)
            Processor.Data.Size.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingSize(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingSize
            Dim tempTable As MaintenanceDataSet.SizeDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.SizeDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateSizeInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Updating size(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_SizeUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SizeUpdated
            Dim tempTable As System.Data.DataTable


            tempTable = CType(e.Data("ModifiedRows"), System.Data.DataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Size.LoadingTable = True
            Processor.Data.Size.Merge(tempTable, False)
            Processor.Data.Size.LoadingTable = False
            Processor.Data.Size.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Size.Merge(tempTable)
            Processor.Data.Size.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DeletingSize(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingSize

            Me.StatusMessage = "Deleting size(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_SizeDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SizeDeleted
            Dim tempTable As MaintenanceDataSet.SizeDataTable


            If e.Data.Contains("DeletedSize") Then
                tempTable = CType(e.Data("DeletedSize"), MaintenanceDataSet.SizeDataTable)
                Processor.Data.Size.Merge(tempTable)
            End If
            Processor.Data.Size.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub


#End Region

#Region "Website eventhandlers"
        Private Sub m_maintenanceProcessor_WebsiteValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.WebsiteValidated

            Me.StatusMessage = String.Empty

        End Sub
        Private Sub m_maintenanceProcessor_LoadingWebsite(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.LoadingWebsite

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading list of page website. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_InsertingWebsite(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingWebsite
            Dim tempTable As MaintenanceDataSet.WebsitePageDownloadDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.WebsitePageDownloadDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Add)
                Processor.ValidateWebsiteInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Inserting new website(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_WebsiteInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.WebsiteInserted
            Dim tempTable As MaintenanceDataSet.WebsitePageDownloadDataTable


            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.WebsitePageDownloadDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.WebsitePageDownload.LoadingTable = True
            Processor.Data.WebsitePageDownload.Merge(tempTable, False)
            Processor.Data.WebsitePageDownload.LoadingTable = False
            Processor.Data.WebsitePageDownload.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.WebsitePageDownload.Merge(tempTable)
            Processor.Data.WebsitePageDownload.AcceptChanges()

            _InsertStatus = True
            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingWebsite(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingWebsite
            Dim tempTable As MaintenanceDataSet.WebsitePageDownloadDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.WebsitePageDownloadDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateWebsiteInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Updating websites(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_WebsiteUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.WebsiteUpdated
            Dim tempTable As MaintenanceDataSet.WebsitePageDownloadDataTable

            Try
                If e.Data.Contains("ModifiedRows") = False Then Exit Sub
                tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.WebsitePageDownloadDataTable)
                If tempTable.Rows.Count > 0 Then
                    RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
                    Processor.Data.WebsitePageDownload.LoadingTable = True
                    Processor.Data.WebsitePageDownload.Merge(tempTable, False)
                    Processor.Data.WebsitePageDownload.LoadingTable = False
                    Processor.Data.WebsitePageDownload.RejectChanges()
                    AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

                    Processor.Data.WebsitePageDownload.Merge(tempTable)
                    Processor.Data.WebsitePageDownload.AcceptChanges()
                End If

            Catch ex As Exception

                MsgBox(ex.Message.ToString)
            End Try
            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DeletingWebsites(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingWebsite

            Me.StatusMessage = "Deleting websites(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_WebsiteDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.WebsiteDeleted
            Dim tempTable As MaintenanceDataSet.WebsitePageDownloadDataTable


            If e.Data.Contains("DeletedWebsite") Then
                tempTable = CType(e.Data("DeletedWebsite"), MaintenanceDataSet.WebsitePageDownloadDataTable)
                Processor.Data.WebsitePageDownload.Merge(tempTable)
                Processor.Data.WebsitePageDownload.AcceptChanges()
            End If

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub
#End Region


#Region "Site eventhandlers"
        Private Sub m_maintenanceProcessor_SiteExceedsNonFilteredRowsLimit(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SiteExceedsNonFilteredRowsLimit

            PrepareGridForSiteTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()
            'Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

            messageLabel.Text = "There are too many sites. Please apply filter to load limited number of sites."
            m_isFiltered = True
            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_SiteLoaded(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SiteLoaded

            PrepareGridForSiteTable()

            ResizeDataGridViewColumns()
            'SetFieldsDropDownList()
            'ResetFilterControls()
            'Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

            Me.StatusMessage = String.Empty
        End Sub
        Private Sub m_maintenanceProcessor_SiteValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SiteValidated

            Me.StatusMessage = String.Empty

        End Sub
        Private Sub m_maintenanceProcessor_LoadingSite(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.LoadingSite

            messageLabel.Text = String.Empty
            Me.StatusMessage = "Loading list of site. This may take some time. Please wait..."

            Processor.LoadColumnConstraintsForTable(tableComboBox.Text)

        End Sub

        Private Sub m_maintenanceProcessor_InsertingSite(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.InsertingSite
            Dim tempTable As MaintenanceDataSet.SiteDataTable


            If e.Data.Contains("NewRows") = False Then Exit Sub

            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.SiteDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Add)
                Processor.ValidateSiteInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Inserting new site(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_SiteInserted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SiteInserted
            Dim tempTable As MaintenanceDataSet.SiteDataTable


            tempTable = CType(e.Data("NewRows"), MaintenanceDataSet.SiteDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Site.LoadingTable = True
            Processor.Data.Site.Merge(tempTable, False)
            Processor.Data.Site.LoadingTable = False
            Processor.Data.Site.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Site.Merge(tempTable)
            Processor.Data.Site.AcceptChanges()

            tempTable = Nothing
            _InsertStatus = True

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_UpdatingSite(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.UpdatingSite
            Dim tempTable As MaintenanceDataSet.SiteDataTable


            If e.Data.Contains("ModifiedRows") = False Then Exit Sub

            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.SiteDataTable)

            If tempTable.Rows.Count > 0 Then
                Processor.ValidateColumnValues(tempTable, DataRowAction.Change)
                Processor.ValidateSiteInformation(tempTable)
                e.Cancel = tempTable.HasErrors
            Else
                MessageBox.Show("Cannot detect any change to save. Reload this table to get latest values from database." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
            End If

            tempTable = Nothing

            If e.Cancel = False Then Me.StatusMessage = "Updating sites(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_SiteUpdated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SiteUpdated
            Dim tempTable As MaintenanceDataSet.SiteDataTable


            tempTable = CType(e.Data("ModifiedRows"), MaintenanceDataSet.SiteDataTable)

            RemoveHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated
            Processor.Data.Site.LoadingTable = True
            Processor.Data.Site.Merge(tempTable, False)
            Processor.Data.Site.LoadingTable = False
            Processor.Data.Site.RejectChanges()
            AddHandler maintenanceDataGridView.RowValidated, AddressOf maintenanceDataGridView_RowValidated

            Processor.Data.Site.Merge(tempTable)
            Processor.Data.Site.AcceptChanges()

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_maintenanceProcessor_DeletingSite(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_maintenanceProcessor.DeletingSite

            Me.StatusMessage = "Deleting Sites(s)..."

        End Sub

        Private Sub m_maintenanceProcessor_SiteDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_maintenanceProcessor.SiteDeleted
            Dim tempTable As MaintenanceDataSet.SiteDataTable


            If e.Data.Contains("DeletedSite") Then
                tempTable = CType(e.Data("DeletedSite"), MaintenanceDataSet.SiteDataTable)
                Processor.Data.Site.Merge(tempTable)
                Processor.Data.Site.AcceptChanges()
            End If

            tempTable = Nothing

            Me.StatusMessage = String.Empty

        End Sub
#End Region

        Private Sub SenderExpectationDataGridView_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SenderExpectationDataGridView.SelectionChanged

            With SenderExpectationDataGridView
                If SenderExpectationDataGridView.SelectedRows.Count > 0 And _IsLoading = False Then
                    If .Item(0, .SelectedRows.Item(0).Index).Value.ToString <> "" Then
                        _IsEdit = True
                        _oSenderId = CInt(.Item(0, .SelectedRows.Item(0).Index).Value.ToString)
                        _oExpectaionId = CInt(.Item(1, .SelectedRows.Item(0).Index).Value.ToString)
                        MediaComboBox.SelectedValue = CInt(.Item(6, .SelectedRows.Item(0).Index).Value.ToString)
                        MarketComboBox.SelectedValue = CInt(.Item(7, .SelectedRows.Item(0).Index).Value.ToString)
                        RetailerComboBox.SelectedValue = CInt(.Item(8, .SelectedRows.Item(0).Index).Value.ToString)
                        SenderComboBox.SelectedValue = _oSenderId
                        ExpectaionIdLabel.Text = _oExpectaionId.ToString
                    End If
                End If
            End With

        End Sub

        Private Sub MarketComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If MarketComboBox.SelectedValue Is Nothing Or MediaComboBox.SelectedValue Is Nothing Then Exit Sub
            Processor.loadFilteredRetailer(CInt(MediaComboBox.SelectedValue.ToString), CInt(MarketComboBox.SelectedValue.ToString))
            If _IsEdit = False Then RetailerComboBox.SelectedValue = -1

        End Sub

        Private Sub RetailerComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If MarketComboBox.SelectedValue Is Nothing Or MediaComboBox.SelectedValue Is Nothing Or RetailerComboBox.SelectedValue Is Nothing Then Exit Sub
            ExpectaionIdLabel.Text = Processor.GetExpectationID(CInt(MediaComboBox.SelectedValue.ToString), CInt(MarketComboBox.SelectedValue.ToString), CInt(RetailerComboBox.SelectedValue.ToString)).ToString

        End Sub

        Private Sub MediaComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            If MediaComboBox.SelectedValue Is Nothing Or _IsLoading = True Then Exit Sub
            Processor.LoadFilteredMarket(CInt(MediaComboBox.SelectedValue.ToString))
            If _IsEdit = False Then MarketComboBox.SelectedValue = -1
        End Sub

        Private Sub UpdateListButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateListButton.Click
            If SenderComboBox.SelectedValue Is Nothing Then
                MsgBox("Sender Information Needed", MsgBoxStyle.Exclamation, "MCAP")
                Exit Sub
            ElseIf MediaComboBox.SelectedValue Is Nothing Then
                MsgBox("Media Information Needed", MsgBoxStyle.Exclamation, "MCAP")
                Exit Sub
            ElseIf MarketComboBox.SelectedValue Is Nothing Then
                MsgBox("Market Information Needed", MsgBoxStyle.Exclamation, "MCAP")
                Exit Sub
            ElseIf RetailerComboBox.SelectedValue Is Nothing Then
                MsgBox("Retailer Information Needed", MsgBoxStyle.Exclamation, "MCAP")
                Exit Sub
            End If

            If _IsEdit = False Then
                ' Processor.InsertSenderExpectation(CInt(SenderComboBox.SelectedValue.ToString), CInt(ExpectaionIdLabel.Text))
            Else
                'Processor.UpdateSenderExpectation(CInt(SenderComboBox.SelectedValue.ToString), CInt(ExpectaionIdLabel.Text), _oSenderId, _oExpectaionId)
            End If
            Processor.LoadAllSenderExpectation()
            ClearSenderExpectationInfo()
            SenderExpectationDataGridView.ClearSelection()
            _IsEdit = False
        End Sub

        Private Sub SenderExpectationDataGridView_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles SenderExpectationDataGridView.UserDeletedRow
            ClearSenderExpectationInfo()
            _IsEdit = False
        End Sub

        Private Sub SenderExpectationDataGridView_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles SenderExpectationDataGridView.UserDeletingRow
            Dim messageText As String
            Dim userResponse As System.Windows.Forms.DialogResult


            messageText = "Once current row is deleted, it cannot be undone." + Environment.NewLine _
                          + "Are you sure, you want to delete current row from database?"
            userResponse = MessageBox.Show(messageText, ProductName, MessageBoxButtons.YesNo _
                                           , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            If userResponse = Windows.Forms.DialogResult.No Then e.Cancel = True

            If SenderExpectationDataGridView.SelectedRows.Count > 0 And e.Cancel <> True Then
                ' Processor.DeleteSenderExpectation(CInt(SenderExpectationDataGridView.SelectedRows.Item(0).Cells(0).Value), CInt(SenderExpectationDataGridView.SelectedRows.Item(0).Cells(1).Value))
            End If
        End Sub

        Private Sub RefreshButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshButton.Click
            Processor.LoadAllSenderExpectation()
            SenderExpectationDataGridView.ClearSelection()
            ClearSenderExpectationInfo()
            _IsEdit = False
        End Sub

        Private Sub FilterSEButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilterSEButton.Click
            Dim _Filter As String

            If FilterOneComboBox.SelectedIndex >= 0 And _ValueOneValueMember >= 0 Then
                _Filter = AssignedField(FilterOneComboBox.SelectedIndex) + " = " + _ValueOneValueMember.ToString
                If _ValueTwoValueMember > 0 Then
                    If FilterOneComboBox.SelectedIndex <> FilterTwoComboBox.SelectedIndex Then
                        _Filter = _Filter + " " + AndOrComboBox.Text + " " + AssignedField(FilterTwoComboBox.SelectedIndex) + " = " + _ValueTwoValueMember.ToString
                    Else
                        _Filter = AssignedField(FilterOneComboBox.SelectedIndex) + " in(" + _ValueOneValueMember.ToString + "," + _ValueTwoValueMember.ToString + ")"
                    End If
                End If
                Processor.LoadSenderExpectation(_Filter)
                _ValueOneValueMember = 0
                _ValueTwoValueMember = 0
                SetComboBoxDataSource(FilterOneComboBox.SelectedIndex, ValueOneComboBox)
                SetComboBoxDataSource(FilterTwoComboBox.SelectedIndex, ValueTwoComboBox)
                ClearCombo()

            End If
            SenderExpectationDataGridView.ClearSelection()
            ExpectaionIdLabel.Text = "0"
            IsFilter = False
        End Sub

        Private Sub RemoveSEFilterButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveSEFilterButton.Click
            Processor.LoadSenderExpectation()
            ClearCombo()
            ValueOneComboBox.Text = ""
            ValueTwoComboBox.Text = ""
            SenderExpectationDataGridView.ClearSelection()
            IsFilter = False
            ExpectaionIdLabel.Text = "0"
        End Sub

        Private Sub ClearCombo()
            FilterOneComboBox.SelectedIndex = -1
            FilterTwoComboBox.SelectedIndex = -1
            ValueOneComboBox.SelectedIndex = -1
            ValueTwoComboBox.SelectedIndex = -1
        End Sub

        Private Function AssignedField(ByVal _index As Integer) As String
            Dim _Val As String = Nothing
            Select Case _index
                Case 0 'Media
                    _Val = "c.MediaId"
                Case 1 'Market
                    _Val = "d.MktId"
                Case 2 'Retailer
                    _Val = "e.RetId"
            End Select

            Return _Val
        End Function

        Private Sub SetComboBoxDataSource(ByVal _Index As Integer, ByVal _Combo As ComboBox)
            With _Combo
                .DataSource = Nothing
                .ValueMember = Nothing
                .DisplayMember = Nothing
                Select Case _Index
                    Case 0
                        Processor.LoadMediaTypeList()
                        .ValueMember = "MediaId"
                        .DisplayMember = "Descrip"
                        .DataSource = Processor.Data.Media
                    Case 1
                        Processor.LoadAllMarkets()
                        .ValueMember = "MktId"
                        .DisplayMember = "Descrip"
                        .DataSource = Processor.Data.Mkt
                    Case 2
                        Processor.LoadRetailerList()
                        .ValueMember = "RetId"
                        .DisplayMember = "Descrip"
                        .DataSource = Processor.Data.RetailerList
                End Select
            End With
        End Sub

        Private Sub FilterOneComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilterOneComboBox.SelectedIndexChanged
            SetComboBoxDataSource(FilterOneComboBox.SelectedIndex, ValueOneComboBox)
            ValueOneComboBox.SelectedIndex = -1
            IsFilter = True
        End Sub

        Private Sub FilterTwoComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilterTwoComboBox.SelectedIndexChanged
            SetComboBoxDataSource(FilterTwoComboBox.SelectedIndex, ValueTwoComboBox)
            ValueTwoComboBox.SelectedIndex = -1
        End Sub

        Private Sub ValueOneComboBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValueOneComboBox.LostFocus
            With ValueOneComboBox
                _ValueOneValueMember = CInt(.SelectedValue)
                _ValueOneDisplay = .Text
                If _ValueOneValueMember > 0 Then
                    .DataSource = Nothing
                    .ValueMember = Nothing
                    .DisplayMember = Nothing
                    ValueOneComboBox.SelectedIndex = -1
                    .Text = _ValueOneDisplay
                End If
            End With
        End Sub

        Private Sub ValueOneComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValueOneComboBox.SelectedIndexChanged
            ClearSenderExpectationInfo()
        End Sub

        Private Sub ValueTwoComboBox_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ValueTwoComboBox.LostFocus
            With ValueTwoComboBox
                If _ValueTwoValueMember <> 0 Then Exit Sub
                _ValueTwoValueMember = CInt(.SelectedValue)
                _ValueTwoDisplay = .Text
                If _ValueTwoValueMember > 0 Then
                    .DataSource = Nothing
                    .ValueMember = Nothing
                    .DisplayMember = Nothing
                    ValueTwoComboBox.SelectedIndex = -1
                    .Text = _ValueTwoDisplay
                End If
            End With
        End Sub

        Private Sub ValueTwoComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValueTwoComboBox.SelectedIndexChanged
            ClearSenderExpectationInfo()
        End Sub

        Private Sub MediaComboBox_SelectedValueChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles MediaComboBox.SelectedValueChanged
            If IsFilter = True Then MediaComboBox.SelectedIndex = -1
            If MediaComboBox.SelectedValue Is Nothing Or _IsLoading = True Then Exit Sub
            Processor.LoadFilteredMarket(CInt(MediaComboBox.SelectedValue.ToString))
            MarketComboBox.SelectedIndex = -1
            RetailerComboBox.SelectedIndex = -1
            If _IsEdit = False Then MarketComboBox.SelectedValue = -1
        End Sub

        Private Sub MarketComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MarketComboBox.SelectedValueChanged
            If IsFilter = True Then MarketComboBox.SelectedIndex = -1
            If MarketComboBox.SelectedValue Is Nothing Or MediaComboBox.SelectedValue Is Nothing Then Exit Sub
            Processor.loadFilteredRetailer(CInt(MediaComboBox.SelectedValue.ToString), CInt(MarketComboBox.SelectedValue.ToString))
            RetailerComboBox.SelectedIndex = -1
            If _IsEdit = False Then RetailerComboBox.SelectedValue = -1
        End Sub

        Private Sub RetailerComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RetailerComboBox.SelectedValueChanged
            If IsFilter = True Then RetailerComboBox.SelectedIndex = -1
            If MarketComboBox.SelectedValue Is Nothing Or MediaComboBox.SelectedValue Is Nothing Or RetailerComboBox.SelectedValue Is Nothing Then Exit Sub
            ExpectaionIdLabel.Text = Processor.GetExpectationID(CInt(MediaComboBox.SelectedValue.ToString), CInt(MarketComboBox.SelectedValue.ToString), CInt(RetailerComboBox.SelectedValue.ToString)).ToString
        End Sub

        Private Function ProcessExpectationId() As Integer
            Dim _ExpectationId As Integer
            If _med <> 0 And _mkt <> 0 And _ret <> 0 Then
                _ExpectationId = Processor.GetExpectationID(_med, _mkt, _ret)
            Else
                _ExpectationId = -1
            End If
            Return _ExpectationId
        End Function

        Private Sub ProcessComboBox()
            Dim _media As DataGridViewComboBoxCell = New DataGridViewComboBoxCell
            Dim _market As DataGridViewComboBoxCell = New DataGridViewComboBoxCell
            Dim _retailer As DataGridViewComboBoxCell = New DataGridViewComboBoxCell
            Dim _sender As DataGridViewComboBoxCell = New DataGridViewComboBoxCell
            Dim _senderList As DataGridViewComboBoxCell = New DataGridViewComboBoxCell
            Dim _senderId As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
            Dim _ExpId As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
            Dim _markets As DataGridViewTextBoxCell = New DataGridViewTextBoxCell

            Try

                If _ExpId.Value Is Nothing Then
                    ' _sender.Value = -1
                    _senderId.Value = 0
                    _ExpId.Value = -1
                    _media.Value = -1
                End If

                currentIndex = maintenanceDataGridView.CurrentRow.Index

                If IsDBNull(maintenanceDataGridView.CurrentCell) = True Then
                    _sender.Value = -1
                End If

                With _sender
                    'Processor.LoadAllSenderList()
                    .DisplayMember = "Name"
                    .ValueMember = "SenderId"
                    .DataSource = Processor.Data.SenderList
                    maintenanceDataGridView(0, currentIndex) = _sender

                End With

                With _media
                    'Processor.LoadMediaTypeList()
                    .DisplayMember = "Descrip"
                    .ValueMember = "MediaId"
                    .DataSource = Processor.Data.Media
                    maintenanceDataGridView(1, currentIndex) = _media
                End With

                With _market
                    '    'Processor.LoadAllMarkets()
                    .DisplayMember = "Descrip"
                    .ValueMember = "MktId"
                    .DataSource = Processor.Data.Mkt
                    maintenanceDataGridView(2, maintenanceDataGridView.CurrentRow.Index) = _market
                End With

                With _retailer
                    'Processor.LoadRetailerList()
                    .DisplayMember = "Descrip"
                    .ValueMember = "RetId"
                    .DataSource = Processor.Data.Ret
                    maintenanceDataGridView(3, maintenanceDataGridView.CurrentRow.Index) = _retailer
                End With

                With _ExpId
                    maintenanceDataGridView(4, currentIndex) = _ExpId
                End With

                With _senderId
                    maintenanceDataGridView(5, currentIndex) = _senderId
                End With

                IsComboLoaded = True
            Catch ex As Exception
                IsComboLoaded = False
            End Try



        End Sub

        Private Function GetID(ByVal param As String, ByVal tab As String) As Integer
            Dim imgPathCommand As System.Data.SqlClient.SqlCommand
            Dim obj As Object
            Dim val As Integer


            imgPathCommand = New System.Data.SqlClient.SqlCommand
            Try
                With imgPathCommand
                    '.CommandText = "SELECT path, yearmonth FROM ImagePath WHERE LocationId=" + LocationId.ToString + " AND PathTypeid=" + PathType.ToString + " ORDER BY yearmonth desc"
                    If tab = "Media" Then
                        .CommandText = "SELECT MediaId FROM Media WHERE Descrip = '" + param + "'"
                    ElseIf tab = "Mkt" Then
                        .CommandText = "SELECT MktId FROM Mkt WHERE Descrip = '" + param + "'"
                    ElseIf tab = "Ret" Then
                        .CommandText = "SELECT RetId FROM Ret WHERE Descrip = '" + param + "'"
                    Else
                        .CommandText = "SELECT SenderId FROM Sender WHERE Name = '" + param + "'"
                    End If
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With
                If String.IsNullOrEmpty(CType(obj, String)) = True Then Exit Function
                val = CType(obj, Integer)

            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If imgPathCommand.Connection.State <> ConnectionState.Closed Then imgPathCommand.Connection.Close()
            End Try

            Return val
        End Function

        Private Function GetDescrip(ByVal param As String, ByVal tab As String) As String
            Dim imgPathCommand As System.Data.SqlClient.SqlCommand
            Dim obj As Object
            Dim val As String

            imgPathCommand = New System.Data.SqlClient.SqlCommand
            Try
                With imgPathCommand
                    '.CommandText = "SELECT path, yearmonth FROM ImagePath WHERE LocationId=" + LocationId.ToString + " AND PathTypeid=" + PathType.ToString + " ORDER BY yearmonth desc"
                    If tab = "Media" Then
                        .CommandText = "SELECT Descrip FROM Media WHERE MediaId = " + param
                    ElseIf tab = "Mkt" Then
                        .CommandText = "SELECT Descrip FROM Mkt WHERE MktId = " + param
                    ElseIf tab = "Ret" Then
                        .CommandText = "SELECT Descrip FROM Ret WHERE RetId = " + param
                    Else
                        .CommandText = "SELECT Name FROM Sender WHERE SenderId = " + param
                    End If
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With
                If String.IsNullOrEmpty(CType(obj, String)) = True Then Exit Function
                val = CType(obj, String)

            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If imgPathCommand.Connection.State <> ConnectionState.Closed Then imgPathCommand.Connection.Close()
            End Try

            Return val
        End Function

        Private Sub logicalOperatorsComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles logicalOperatorsComboBox.KeyDown
            e.SuppressKeyPress = True
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub filterValueComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles filterValueComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub filterValue2ComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles filterValue2ComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub MaintenanceForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

            Dim _media As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
            Dim _market As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
            Dim _retailer As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
            Dim _sender As DataGridViewTextBoxCell = New DataGridViewTextBoxCell
            Dim _expid As DataGridViewTextBoxCell = New DataGridViewTextBoxCell

            _media.Value = orig_media
            If orig_media IsNot Nothing Then maintenanceDataGridView(1, previousRow) = _media
            _market.Value = orig_mkt
            If orig_mkt IsNot Nothing Then maintenanceDataGridView(2, previousRow) = _market
            _retailer.Value = orig_ret
            If orig_ret IsNot Nothing Then maintenanceDataGridView(3, previousRow) = _retailer
            _sender.Value = orig_sender
            If orig_sender IsNot Nothing Then
                _expid.Value = -1
                maintenanceDataGridView(0, previousRow) = _sender
                maintenanceDataGridView(5, previousRow) = _expid
            End If
        End Sub

        Private Sub MaintenanceForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim appUser As UI.Processors.ApplicationUser = New UI.Processors.ApplicationUser
            Dim formListTable As MCAP.UserRolesDataSet.UserScreensFunctionalityViewDataTable
            Dim tempRow As MCAP.UserRolesDataSet.UserScreensFunctionalityViewRow

            appUser = New UI.Processors.ApplicationUser()
            appUser.Initialize()

            formListTable = appUser.GetFormListFor(appUser.UserID)

            appUser.Dispose()
            appUser = Nothing

            For ctr As Integer = 0 To formListTable.Rows.Count - 1
                tempRow = formListTable(ctr)

                If tempRow.FormName = "Publication Subscription Maintenance" Then
                    tableComboBox.Items.Add("PublicationSubscription")
                End If
            Next

            formListTable.Dispose()
            formListTable = Nothing


        End Sub
    End Class

End Namespace