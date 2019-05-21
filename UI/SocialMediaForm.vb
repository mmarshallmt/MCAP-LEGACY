﻿Imports MCAP.UI
Imports System.Linq
Imports System.Data.SqlClient

Public Class SocialMediaForm
    Implements IForm

    Private dsFacebook As DataSet
    Private tempDataSet As DataSet
    Private userTable As DataTable
    Private sqlQuery As String
    Private connection As SqlConnection
    Private command As SqlCommand
    Private adapter As SqlDataAdapter
    Private builder As SqlCommandBuilder

    Private WithEvents m_maintenanceProcessor As Processors.SocialMedia
    Private m_isFiltered As Boolean
    Private mArray As New List(Of List(Of String))
    Private listObj As New BusinessLayer.clsExpectationController

    Private ReadOnly Property Processor() As Processors.SocialMedia
        Get
            Return m_maintenanceProcessor
        End Get
    End Property

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

        m_maintenanceProcessor = New Processors.SocialMedia
        

        editTableGroupBox.Text = String.Empty
        logicalOperatorsComboBox.SelectedIndex = 0

        RaiseEvent FormInitialized()

        Me.ResumeLayout()

    End Sub


#End Region

    Private Sub SetDataObjects()
        connection = New SqlConnection(GetConnectionStringForAppDB)
        command = New SqlCommand(sqlQuery, connection)
        adapter = New SqlDataAdapter(command)
        builder = New SqlCommandBuilder(adapter)
        dsFacebook = New DataSet("MainDataSet")
        tempDataSet = New DataSet("TempDataSet")
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

    Private Sub PrepareGridForFaceBookInputdataTable()
        'Dim fb As New clsFaceBook
        'sqlQuery = "SELECT retid,pageurl,cast(crawl as int) as crawl,cast(Enabled as int) as Enabled ,loginId ,cast(layoutType as int)"
        'sqlQuery = sqlQuery & " as layoutType, PostDate, LastProcessDatetime, FreqInMin, Priority FROM facebookinputdata"
        'If Not filterFieldComboBox.SelectedValue Is Nothing Then
        '    sqlQuery = sqlQuery & " where " & filterFieldComboBox.SelectedValue.ToString & " like '%" & filterValueTextBox.Text & "%'"
        'End If
        'If Not logicalOperatorsComboBox.SelectedValue Is Nothing And Not filterField2ComboBox.SelectedValue Is Nothing Then
        '    sqlQuery = sqlQuery & logicalOperatorsComboBox.SelectedValue.ToString & " " & filterField2ComboBox.SelectedValue.ToString & " = '" & filterValue2TextBox.Text & "'"
        'End If
        'SetDataObjects()
      
        
        dsFacebook = New DataSet("MainDataSet")
        Dim fb As New clsFaceBook
        dsFacebook = fb.GetFaceBooks()

        'adapter.Fill(dsFacebook, tableComboBox.Text.Trim())
        userTable = dsFacebook.Tables(tableComboBox.Text.Trim())

        Dim retIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Dim pageUrlTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Dim crawlComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Dim EnabledComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Dim loginIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Dim logoutTypeComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Dim PostDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
        Dim LastProcessDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
        Dim priorityTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Dim FeqInMinTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn


        maintenanceDataGridView.SuspendLayout()

        retIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        pageUrlTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        crawlComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        EnabledComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        loginIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        logoutTypeComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        PostDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
        LastProcessDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
        priorityTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        FeqInMinTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        maintenanceDataGridView.DataSource = Nothing
        maintenanceDataGridView.Columns.Clear()
        maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                 {retIdComboBoxColumn, pageUrlTextBoxColumn _
                                                  , crawlComboBoxColumn, EnabledComboBoxColumn _
                                                  , loginIdComboBoxColumn, logoutTypeComboBoxColumn _
                                                  , PostDtCalendarColumn, LastProcessDtCalendarColumn _
                                                  , FeqInMinTextBoxColumn, priorityTextBoxColumn})
        mArray = New List(Of List(Of String))
        For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
            mArray.Add(New List(Of String))
        Next
        Dim ctr As Integer = 0
       
      
        Dim fbObj As List(Of clsFaceBook) = Nothing
        Dim fbListObj As New clsFaceBookController

        fbObj = Nothing
        fbObj = fbListObj.fetch("retid")

        With retIdComboBoxColumn
            .HeaderText = "Retailer"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "RetIdComboBoxColumn"
            .DataPropertyName = "RetId"
            .DisplayMember = "descrip"
            .ValueMember = "RetId"
            .DataSource = fbObj
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With

        With pageUrlTextBoxColumn
            .HeaderText = "PageURl"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "pageUrlTextBoxColumn"
            .DataPropertyName = "PageUrl"
            '.MaxInputLength = Processor.Data.Ret.DescripColumn.MaxLength
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With

        fbObj = Nothing
        fbObj = fbListObj.fetch("crawl")
        With crawlComboBoxColumn
            .HeaderText = "Crawl"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "crawlComboBoxColumn"
            .DataPropertyName = "Crawl"
            .DisplayMember = "Descrip"
            .ValueMember = "crawlID"
            '.DefaultCellStyle.NullValue = "False"
            .DataSource = fbObj
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With

        fbObj = Nothing
        fbObj = fbListObj.fetch("enabled")
        With EnabledComboBoxColumn
            .HeaderText = "Enabled"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "EnabledComboBoxColumn"
            .DataPropertyName = "Enabled"
            .DisplayMember = "Descrip"
            .ValueMember = "priority"
            '.DefaultCellStyle.NullValue = "True"
            .DataSource = fbObj
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With
        fbObj = Nothing
        fbObj = fbListObj.fetch("loginid")
        With loginIdComboBoxColumn
            .HeaderText = "LoginId"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "loginIdComboBoxColumn"
            .DataPropertyName = "LoginId"
            .DisplayMember = "priority"
            .ValueMember = "priority"
            .DataSource = fbObj
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With
       
        fbObj = Nothing
        fbObj = fbListObj.fetch("layouttype")
        With logoutTypeComboBoxColumn
            .HeaderText = "LayoutType"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "logoutTypeComboBoxColumn"
            .DataPropertyName = "LayoutType"
            .DisplayMember = "Descrip"
            .ValueMember = "priority"
            .DefaultCellStyle.NullValue = "2"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DataSource = fbObj
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With

        With FeqInMinTextBoxColumn
            .HeaderText = "FreqInMin"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "FeqInMinTextBoxColumn"
            .DataPropertyName = "FreqInMin"
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.NullValue = "240"
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With

        With priorityTextBoxColumn
            .HeaderText = "Priority"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "priorityTextBoxColumn"
            .DataPropertyName = "Priority"
            .DefaultCellStyle.NullValue = "50"
            .MaxInputLength = 4
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With

        With PostDtCalendarColumn
            .HeaderText = "PostDate"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "PostDtCalendarColumn"
            .DataPropertyName = "PostDate"
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With

        With LastProcessDtCalendarColumn
            .HeaderText = "LastProcessDateTime"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "LastProcessDtCalendarColumn"
            .DataPropertyName = "LastProcessDateTime"
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With

        maintenanceDataGridView.DataSource = userTable
       
        retIdComboBoxColumn = Nothing
        pageUrlTextBoxColumn = Nothing
        crawlComboBoxColumn = Nothing
        EnabledComboBoxColumn = Nothing
        loginIdComboBoxColumn = Nothing
        logoutTypeComboBoxColumn = Nothing
        PostDtCalendarColumn = Nothing
        LastProcessDtCalendarColumn = Nothing
        priorityTextBoxColumn = Nothing

        maintenanceDataGridView.ResumeLayout(False)
        Me.maintenanceDataGridView.Columns("id").Visible = False
    End Sub

    ''Twitter
    Private Sub PrepareGridForTwitterInputdataTable()
        
        dsFacebook = New DataSet("MainDataSet")
        Dim fb As New clsFaceBook
        dsFacebook = fb.GetTwitters()

        userTable = dsFacebook.Tables(tableComboBox.Text.Trim())
        ' Dim dt As DataTable = dsFacebook.Tables.Add("FacebookInputData")

        Dim retIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Dim pageUrlTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Dim crawlComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Dim startUrlTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Dim EnabledComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Dim loginIdComboBoxColumn As System.Windows.Forms.DataGridViewComboBoxColumn
        Dim LastProcessDtCalendarColumn As MCAP.UI.Controls.CalendarColumn
        Dim priorityTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Dim FeqInMinTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn


        Dim constraintsRow As DataTable
        maintenanceDataGridView.SuspendLayout()

        retIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        pageUrlTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        crawlComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn()
        startUrlTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        EnabledComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        loginIdComboBoxColumn = New System.Windows.Forms.DataGridViewComboBoxColumn
        LastProcessDtCalendarColumn = New MCAP.UI.Controls.CalendarColumn()
        priorityTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        FeqInMinTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn

        maintenanceDataGridView.DataSource = Nothing
        maintenanceDataGridView.Columns.Clear()
        maintenanceDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() _
                                                 {retIdComboBoxColumn, pageUrlTextBoxColumn _
                                                  , crawlComboBoxColumn, startUrlTextBoxColumn, EnabledComboBoxColumn _
                                                  , loginIdComboBoxColumn _
                                                  , LastProcessDtCalendarColumn _
                                                  , FeqInMinTextBoxColumn, priorityTextBoxColumn})
        mArray = New List(Of List(Of String))
        For i As Integer = 0 To maintenanceDataGridView.Columns.Count - 1
            mArray.Add(New List(Of String))
        Next
        Dim ctr As Integer = 0

        Dim fbObj As List(Of clsFaceBook) = Nothing
        Dim fbListObj As New clsFaceBookController

        fbObj = Nothing
        fbObj = fbListObj.fetch("retid")

        With retIdComboBoxColumn
            .HeaderText = "Retailer"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "RetIdComboBoxColumn"
            .DataPropertyName = "RetId"
            .DisplayMember = "descrip"
            .ValueMember = "RetId"
            .DataSource = fbObj
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With


        With pageUrlTextBoxColumn
            .HeaderText = "PageURl"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "pageUrlTextBoxColumn"
            .DataPropertyName = "PageUrl"
            '.MaxInputLength = Processor.Data.Ret.DescripColumn.MaxLength
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With

        fbObj = Nothing
        fbObj = fbListObj.fetch("crawl")
        With crawlComboBoxColumn
            .HeaderText = "Crawl"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "crawlComboBoxColumn"
            .DataPropertyName = "Crawl"
            .DisplayMember = "Descrip"
            .ValueMember = "crawlID"
            '.DefaultCellStyle.NullValue = "False"
            .ValueType = System.Type.GetType("System.Bit")
            .DataSource = fbObj
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With

        With startUrlTextBoxColumn
            .HeaderText = "startURl"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "startUrlTextBoxColumn"
            .DataPropertyName = "StartUrl"
            '.MaxInputLength = Processor.Data.Ret.DescripColumn.MaxLength
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With

        fbObj = Nothing
        fbObj = fbListObj.fetch("enabled")
        With EnabledComboBoxColumn
            .HeaderText = "Enabled"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "EnabledComboBoxColumn"
            .DataPropertyName = "Enabled"
            .DisplayMember = "Descrip"
            .ValueMember = "priority"
            '.DefaultCellStyle.NullValue = "True"
            .ValueType = System.Type.GetType("System.Bit")
            .DataSource = fbObj
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With

        fbObj = Nothing
        fbObj = fbListObj.fetch("loginid")
        With loginIdComboBoxColumn
            .HeaderText = "LoginId"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "loginIdComboBoxColumn"
            .DataPropertyName = "LoginId"
            .DisplayMember = "priority"
            .ValueMember = "priority"
            .DataSource = fbObj
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With
        

        With FeqInMinTextBoxColumn
            .HeaderText = "FreqInMin"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "FeqInMinTextBoxColumn"
            .DataPropertyName = "FreqInMin"
            '.MaxInputLength = Processor.Data.Ret.DescripColumn.MaxLength
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .DefaultCellStyle.NullValue = "240"
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With


        With priorityTextBoxColumn
            .HeaderText = "Priority"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "priorityTextBoxColumn"
            .DataPropertyName = "Priority"
            .DefaultCellStyle.NullValue = "50"
            .MaxInputLength = 4
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With


        With LastProcessDtCalendarColumn
            .HeaderText = "LastProcessDateTime"
            .HeaderCell.Style.Font = New System.Drawing.Font(.HeaderCell.InheritedStyle.Font, FontStyle.Bold)
            .Name = "LastProcessDtCalendarColumn"
            .DataPropertyName = "LastProcessDateTime"
            mArray(ctr).Add(.HeaderText)
            mArray(ctr).Add(.DataPropertyName)
            ctr += 1
        End With

        maintenanceDataGridView.DataSource = userTable
        retIdComboBoxColumn = Nothing
        pageUrlTextBoxColumn = Nothing
        crawlComboBoxColumn = Nothing
        EnabledComboBoxColumn = Nothing
        loginIdComboBoxColumn = Nothing
        LastProcessDtCalendarColumn = Nothing
        priorityTextBoxColumn = Nothing


        maintenanceDataGridView.ResumeLayout(False)
        Me.maintenanceDataGridView.Columns("id").Visible = False
    End Sub
   

    Private Sub SetFieldsDropDownList()
        Dim index As Integer
        Dim columnQuery As System.Collections.Generic.IEnumerable(Of String)


        columnQuery = From col In maintenanceDataGridView.Columns.Cast(Of DataGridViewColumn)() _
                      Where col.Visible = True And col.HeaderText <> "Password" And col.HeaderText <> "WebsitePageDownloadId" And _
                      col.HeaderText.ToLower <> "Id".ToLower And col.HeaderText <> "Default Status Id" _
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

    Private Sub LoadFilteredTable(ByVal filterCondition As String)

        Select Case tableComboBox.Text
            Case "faceBookInputData"
                'Processor.LoadExpectations(filterCondition)

            Case "TwitterInputData"
                ' Processor.LoadRetailers(filterCondition)

            Case Else
                Throw New System.ApplicationException("Template not defined for this selection.")
        End Select

    End Sub

    Private Sub tableComboBox_DropDown(sender As Object, e As EventArgs) Handles tableComboBox.DropDown
      
        maintenanceDataGridView.DataSource = Nothing
    End Sub

    Private Sub tableComboBox_KeyDown(sender As Object, e As KeyEventArgs) Handles tableComboBox.KeyDown
        If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
            e.SuppressKeyPress = True
            Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
        End If
    End Sub

    Private Sub tableComboBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tableComboBox.KeyPress
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

    Private Sub tableComboBox_SelectedValueChanged(sender As Object, e As EventArgs) Handles tableComboBox.SelectedValueChanged
        If tableComboBox.SelectedIndex < 0 Then Exit Sub

        filterValueTextBox.Text = String.Empty
        filterValue2TextBox.Text = String.Empty

        'To reset filter controls.
        removeFilterButton.PerformClick()
        m_isFiltered = False

        editTableGroupBox.Text = "Edit Table " + tableComboBox.Text
        Select Case tableComboBox.Text
            Case "FacebookInputdata"
                PrepareGridForFaceBookInputdataTable()
            Case "TwitterInputdata"
                PrepareGridForTwitterInputdataTable()
            Case Else
                Throw New System.ApplicationException("Template not defined for this selection.")
        End Select
        SetFieldsDropDownList()
        ResetFilterControls()
    End Sub

    Private Sub filterButton_Click(sender As Object, e As EventArgs) Handles filterButton.Click

        Dim filterFieldIndex As Integer
        Dim filterColumnName As String
        Dim filterColumnDataType As System.Type
        Dim filterCondition As System.Text.StringBuilder
        Dim tempTable As System.Data.DataTable
        Dim tableAlias As String

        If filterFieldComboBox.SelectedIndex < 0 Then Exit Sub

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


        Dim _Filter As Object

        For Each l As List(Of String) In mArray
            If l.Contains(filterFieldComboBox.Text) Then
                _Filter = l(1)
                Exit For
            End If
        Next

        If CStr(_Filter) = "Market" Then _Filter = "Mkt"

        filterColumnName = CType(_Filter, String)
        If filterValueTextBox.Visible = True Then
            filterColumnDataType = GetType(System.String)
            If IsNumeric(filterValueTextBox.Text) Then filterColumnDataType = GetType(System.Int16)
        ElseIf filterValueTypeInDatePicker.Visible = True Then
            filterColumnDataType = GetType(System.DateTime)
        Else
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

            If CStr(_Filter2) = "Market" Then _Filter2 = "Mkt"

            filterColumnName = CType(_Filter2, String)
            filterColumnDataType = tempTable.Columns(filterColumnName).DataType

            AppendFilter2Criteria(filterCondition, filterColumnName, filterColumnDataType)


            tableAlias = Nothing
        End If
        Dim xtr As String = filterCondition.ToString()
        If Me.IsFilteredTable Then
            LoadFilteredTable(filterCondition.ToString())
        Else
            tempTable.DefaultView.RowFilter = filterCondition.ToString()
        End If
        removeFilterButton.Enabled = True
        filterCondition.Remove(0, filterCondition.Length)
        filterCondition = Nothing

    End Sub
 

    Private Sub filterFieldComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles filterFieldComboBox.SelectedIndexChanged
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

        SetFilterValueDropDownList(tempTable.TableName, CType(_Filter, String))
        Dim dt As New DataTable
        Dim rw As DataRow

        dt.Columns.Add(_Filter.ToString)

        SetFilterControl(dt.Columns(0))

        tempTable = Nothing

        filterFieldComboBox.Tag = filterFieldComboBox.SelectedIndex
    End Sub

    ''' <summary>
    ''' Fills in values into filter value drop down list. Values are filled 
    ''' based on selected table and column name.
    ''' </summary>
    ''' <param name="tableName">Name of the table for which preparing the drop down list.</param>
    ''' <param name="columnName">Name of the field of the table. Drop down list will contain values for this field.</param>
    ''' <remarks></remarks>
    Private Sub SetFilterValueDropDownList(ByVal tableName As String, ByVal columnName As String)

        filterValueComboBox.DataSource = Nothing
        Dim temp As String = columnName.ToUpper()
        Dim temp2 As String = tableName.ToUpper()
        Dim mdaObj As List(Of clsFaceBook) = Nothing
        Dim expObj As New clsFaceBookController



        Select Case columnName.ToUpper()
            Case "RETID"
                mdaObj = expObj.fetch("retid")
                filterValueComboBox.Enabled = True
                filterValueTextBox.Enabled = True

                filterValueComboBox.DisplayMember = "Descrip"
                filterValueComboBox.ValueMember = "retid"
                filterValueComboBox.DataSource = mdaObj
                mdaObj = Nothing
            Case "ENABLED"
                mdaObj = expObj.fetch("enabled")
                filterValueComboBox.Enabled = True
                filterValueTextBox.Enabled = True

                filterValueComboBox.DisplayMember = "Descrip"
                filterValueComboBox.ValueMember = "priority"
                filterValueComboBox.DataSource = mdaObj
                mdaObj = Nothing
            Case "CRAWL"
                mdaObj = expObj.fetch("crawl")
                filterValueComboBox.Enabled = True
                filterValueTextBox.Enabled = True

                filterValueComboBox.DisplayMember = "Descrip"
                filterValueComboBox.ValueMember = "priority"
                filterValueComboBox.DataSource = mdaObj
                mdaObj = Nothing

            Case "LOGINID"
                mdaObj = expObj.fetch("loginid")
                filterValueComboBox.Enabled = True
                filterValueTextBox.Enabled = True

                filterValueComboBox.DisplayMember = "priority"
                filterValueComboBox.ValueMember = "priority"
                filterValueComboBox.DataSource = mdaObj
                mdaObj = Nothing
            Case "LAYOUTTYPE"
                mdaObj = expObj.fetch("layouttype")
                filterValueComboBox.Enabled = True
                filterValueTextBox.Enabled = True

                filterValueComboBox.DisplayMember = "Descrip"
                filterValueComboBox.ValueMember = "priority"
                filterValueComboBox.DataSource = mdaObj
                mdaObj = Nothing

            Case Else
                filterValueComboBox.Items.Clear()
               
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
        Dim temp As String = columnName.ToUpper()
        Dim temp2 As String = tableName.ToUpper()
        Dim mdaObj As List(Of clsFaceBook) = Nothing
        Dim expObj As New clsFaceBookController



        Select Case columnName.ToUpper()
            Case "RETID"
                mdaObj = expObj.fetch("retid")
                filterValue2ComboBox.Enabled = True
                filterValue2TextBox.Enabled = True

                filterValue2ComboBox.DisplayMember = "Descrip"
                filterValue2ComboBox.ValueMember = "retid"
                filterValue2ComboBox.DataSource = mdaObj
                mdaObj = Nothing
            Case "CRAWL"
                mdaObj = expObj.fetch("crawl")
                filterValue2ComboBox.Enabled = True
                filterValue2TextBox.Enabled = True

                filterValue2ComboBox.DisplayMember = "Descrip"
                filterValue2ComboBox.ValueMember = "priority"
                filterValue2ComboBox.DataSource = mdaObj
                mdaObj = Nothing
            Case "ENABLED"
                mdaObj = expObj.fetch("enabled")
                filterValue2ComboBox.Enabled = True
                filterValue2TextBox.Enabled = True

                filterValue2ComboBox.DisplayMember = "Descrip"
                filterValue2ComboBox.ValueMember = "priority"
                filterValue2ComboBox.DataSource = mdaObj
                mdaObj = Nothing
            Case "LAYOUTTYPE"
                mdaObj = expObj.fetch("layouttype")
                filterValue2ComboBox.Enabled = True
                filterValue2TextBox.Enabled = True

                filterValue2ComboBox.DisplayMember = "PRIORITY"
                filterValue2ComboBox.ValueMember = "PRIORITY"
                filterValue2ComboBox.DataSource = mdaObj
                mdaObj = Nothing
            Case "LOGINID"
                mdaObj = expObj.fetch("loginid")
                filterValue2ComboBox.Enabled = True
                filterValue2TextBox.Enabled = True

                filterValue2ComboBox.DisplayMember = "PRIORITY"
                filterValue2ComboBox.ValueMember = "PRIORITY"
                filterValue2ComboBox.DataSource = mdaObj
                mdaObj = Nothing

            Case Else
                filterValue2ComboBox.Items.Clear()
                
        End Select

    End Sub

    ''' <summary>
    ''' Sets control to allow user to specify filter value. Filter control is 
    ''' set based on data type of the supplied data column.
    ''' </summary>
    ''' <param name="filterColumn"></param>
    ''' <remarks></remarks>
    Private Sub SetFilterControl(ByVal filterColumn As System.Data.DataColumn)

        If filterColumn.DataType.ToString() = "System.DateTime" _
        Or filterColumn.ColumnName.ToUpper() = "LASTPROCESSDATETIME" _
        Or filterColumn.ColumnName.ToUpper() = "POSTDATE" _
            Then
            filterValueComboBox.Visible = False
            filterValueTextBox.Visible = False
            filterValueTypeInDatePicker.Text = ""
            filterValueTypeInDatePicker.Value = Nothing
            filterValueTypeInDatePicker.Visible = True

        ElseIf filterColumn.ColumnName.ToUpper().EndsWith("ID") _
              OrElse filterColumn.ColumnName.ToUpper() = "RETID" _
              OrElse filterColumn.ColumnName.ToUpper() = "LOGINID" _
              OrElse filterColumn.ColumnName.ToUpper() = "CRAWL" _
              OrElse filterColumn.ColumnName.ToUpper() = "ENABLED" _
              OrElse filterColumn.ColumnName.ToUpper() = "LAYOUTTYPE" _
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
        Or filterColumn.ColumnName.ToUpper() = "LASTPROCESSDATETIME" _
        Or filterColumn.ColumnName.ToUpper() = "POSTDATE" _
        Then
            filterValue2ComboBox.Visible = False
            filterValue2TextBox.Visible = False
            filterValue2TypeInDatePicker.Text = ""
            filterValue2TypeInDatePicker.Value = Nothing
            filterValue2TypeInDatePicker.Visible = True

        ElseIf filterColumn.ColumnName.ToUpper().EndsWith("ID") _
              OrElse filterColumn.ColumnName.ToUpper() = "RETID" _
              OrElse filterColumn.ColumnName.ToUpper() = "LOGINID" _
              OrElse filterColumn.ColumnName.ToUpper() = "CRAWL" _
              OrElse filterColumn.ColumnName.ToUpper() = "ENABLED" _
              OrElse filterColumn.ColumnName.ToUpper() = "LAYOUTTYPE" _
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

    Private Sub maintenanceDataGridView_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles maintenanceDataGridView.CellMouseClick
        Dim tempTable As Data.DataTable
        tempTable = CType(maintenanceDataGridView.DataSource, Data.DataTable)
        tempTable = tempTable.GetChanges(DataRowState.Modified)
    End Sub

    Private Sub maintenanceDataGridView_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles maintenanceDataGridView.DataError
        Dim dg As New DataGridView

       
    End Sub

    Private Sub filterValue2ComboBox_KeyDown(sender As Object, e As KeyEventArgs) Handles filterValue2ComboBox.KeyDown
        If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
            e.SuppressKeyPress = True
            Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
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
                    If columnName.ToLower = "Retid".ToLower OrElse columnName.ToLower = "Loginid".ToLower Then
                        filterCondition.Append(filterValueComboBox.SelectedValue.ToString)
                    Else
                        filterCondition.Append(filterValueComboBox.Text)
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
                    filterCondition.Append(filterValue2ComboBox.SelectedValue.ToString())
                End If
            End If

            If applyWildCard Then filterCondition.Append("%")
            If applyQuote Then filterCondition.Append("'")
        End If

    End Sub

    Private Sub filterValue2TextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles filterValue2TextBox.KeyPress
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

    Private Sub filterField2ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles filterField2ComboBox.SelectedIndexChanged
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

        SetFilterValue2DropDownList(tempTable.TableName, CType(_Filter, String))
        Dim dt As New DataTable
        Dim rw As DataRow

        dt.Columns.Add(_Filter.ToString)

        SetFilter2Control(dt.Columns(0))

        'SetFilterValue2DropDownList(tempTable.TableName, tempTable.Columns(filterField2ComboBox.SelectedIndex).ColumnName)

        'SetFilter2Control(tempTable.Columns(filterField2ComboBox.SelectedIndex))

        tempTable = Nothing

        filterField2ComboBox.Tag = filterField2ComboBox.SelectedIndex
    End Sub

   
    Private Sub removeFilterButton_Click(sender As Object, e As EventArgs) Handles removeFilterButton.Click
        Dim tempTable As System.Data.DataTable

        If maintenanceDataGridView.DataSource Is Nothing Then Exit Sub

        tempTable = CType(maintenanceDataGridView.DataSource, System.Data.DataTable)
        tempTable.DefaultView.RowFilter = String.Empty
        tempTable = Nothing

        removeFilterButton.Enabled = False

        With filterFieldComboBox
            .SelectedIndex = -1
            filterValueComboBox.Visible = False
            filterValueTextBox.Visible = True
        End With
        With filterField2ComboBox
            .SelectedIndex = -1
            filterValue2ComboBox.Visible = False
            filterValue2TextBox.Visible = True
        End With

        filterValueTextBox.Text = ""
        filterValue2TextBox.Text = ""
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click
        Dim rowCounter As Integer
        Dim userResponse As System.Windows.Forms.DialogResult
        Dim rowsQuery As System.Collections.Generic.IEnumerable(Of System.Data.DataRow)
        Dim tempTable As Data.DataTable


        If maintenanceDataGridView.DataSource Is Nothing Then Exit Sub


        tempTable = CType(maintenanceDataGridView.DataSource, Data.DataTable)

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
        tempTable.RejectChanges()
        maintenanceDataGridView.ResumeLayout(True)
    End Sub

    Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
        Me.Hide()
    End Sub

    Private Sub applyButton_Click(sender As Object, e As EventArgs) Handles applyButton.Click
        Dim fb As New clsFaceBook

        BindingContext(dsFacebook, tableComboBox.Text.Trim()).EndCurrentEdit()
        If dsFacebook.HasChanges Then
            If MsgBox("Changes Made will be saved", CType(MsgBoxStyle.YesNo + MsgBoxStyle.Information, MsgBoxStyle)) = MsgBoxResult.No Then Exit Sub
        End If
        Select Case tableComboBox.Text
            Case "FacebookInputdata"

                fb.SaveFaceBooks(dsFacebook)
            Case "TwitterInputdata"

                fb.SaveTwitters(dsFacebook)
            Case Else
                Throw New System.ApplicationException("Template not defined for this selection.")
        End Select
        MessageBox.Show("Data Updated Successfully !", ProductName _
                           , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Select Case tableComboBox.Text
            Case "FacebookInputdata"
                PrepareGridForFaceBookInputdataTable()
            Case "TwitterInputdata"
                PrepareGridForTwitterInputdataTable()
            Case Else
                Throw New System.ApplicationException("Template not defined for this selection.")
        End Select
        maintenanceDataGridView.DataSource = userTable
    End Sub

    Private Sub maintenanceDataGridView_DefaultValuesNeeded(sender As Object, e As DataGridViewRowEventArgs) Handles maintenanceDataGridView.DefaultValuesNeeded
        'e.Row.Cells("Priority").Value = "50"
        'e.Row.Cells("FreqInMin").Value = "240"
        'e.Row.Cells("LayoutType").Value = "2"
        'e.Row.Cells("Enabled").Value = "1"
        'e.Row.Cells("Crawl").Value = "0"
    End Sub
End Class