
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Threading
Imports System.Diagnostics
Imports System.Data.Common
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Timers


Enum CallFor
    SqlServerList
    SqlDataBases
    SqlTables
End Enum

Public Class testdb

    Private connectionString As String
    Private sqlQuery As String
    Private connection As SqlConnection
    Private command As SqlCommand
    Private adapter As SqlDataAdapter
    Private builder As SqlCommandBuilder
    Private ds As DataSet
    Private tempDataSet As DataSet
    Private userTable As DataTable
    Private sqlInfo As SQLInfoEnumerator
    Private reader As SqlDataReader
    Private Delegate Function InternalDelegate() As String()
    Private intlDelg As InternalDelegate
    Private Delegate Sub AsyncDelegate(result As IAsyncResult)
    Private Delegate Sub TimerDelegate(sender As Object, e As ElapsedEventArgs)
    Private ticker As System.Timers.Timer
    Private called As CallFor
    Private currentIndex As Integer
    Private isLastPage As Boolean
    Private totalRecords As Integer
    Private currentPageStartRecord As Integer
    Private currentPageEndRecord As Integer
    Private Const getTablesFromDataBase As String = "SELECT NAME FROM SYSOBJECTS WHERE TYPE = 'U'"

    Public Sub New()
        InitializeComponent()
        btnUpdate.Enabled = False
        sqlInfo = New SQLInfoEnumerator()
        grpDataManipulate.Enabled = True
        btnLoadSqlServers.[Select]()
        btnLoadSqlServers.Focus()
        prgProgress.Minimum = 0
        prgProgress.Maximum = 200
        ticker = New System.Timers.Timer()
        intlDelg = New InternalDelegate(AddressOf sqlInfo.EnumerateSQLServers)
        '.Elapsed += New ElapsedEventHandler(AddressOf ticker_Elapsed)
        ticker.Interval = 250
        cmbNoOfRecords.SelectedIndex = 0
        btnFirst.Enabled = False
        btnPrevious.Enabled = False
        btnNext.Enabled = False
        btnLast.Enabled = False
        btnAdd.Enabled = False
        btnUpdate.Enabled = False
        btnDelete.Enabled = False
        cmbNoOfRecords.Enabled = False
        btnLoad.Enabled = True
    End Sub

    Private Sub SetDataObjects()
        connection = New SqlConnection(GetConnectionStringForAppDB)
        command = New SqlCommand(sqlQuery, connection)
        adapter = New SqlDataAdapter(command)
        builder = New SqlCommandBuilder(adapter)
        ds = New DataSet("MainDataSet")
        tempDataSet = New DataSet("TempDataSet")
    End Sub


    Private Sub CreateTempTable(startRecord As Integer, noOfRecords As Integer)
        If startRecord = 0 OrElse startRecord < 0 Then
            btnPrevious.Enabled = False
            startRecord = 0
        End If
        Dim endRecord As Integer = startRecord + noOfRecords
        If endRecord >= totalRecords Then
            btnNext.Enabled = False
            isLastPage = True
            endRecord = totalRecords
        End If
        currentPageStartRecord = startRecord
        currentPageEndRecord = endRecord
        lblPageNums.Text = "Records from " & startRecord.ToString & " to " & endRecord & " of " + totalRecords.ToString
        currentIndex = endRecord

        Try
            userTable.Rows.Clear()
            If connection.State = ConnectionState.Closed Then
                connection.Open()
            End If
            adapter.Fill(ds, startRecord, noOfRecords, cmbTables.Text.Trim())
            userTable = ds.Tables(cmbTables.Text.Trim())
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            connection.Close()
        End Try

        userDataGridView.DataSource = userTable.DefaultView
        userDataGridView.AllowUserToResizeColumns = True
    End Sub


    Private Sub ticker_Elapsed(sender As Object, e As ElapsedEventArgs)
        If Me.InvokeRequired Then
            Me.Invoke(New TimerDelegate(AddressOf ticker_Elapsed), sender, e)
        Else
            If prgProgress.Value = prgProgress.Maximum Then
                prgProgress.Value = 0
            Else
                prgProgress.Value += 20
            End If
        End If
    End Sub


    Private Sub CallBackMethod(result As IAsyncResult)
        If Me.InvokeRequired Then
            Me.Invoke(New AsyncDelegate(AddressOf CallBackMethod), result)
        Else
            Try
                prgProgress.Value = prgProgress.Maximum
                Select Case called
                    Case CallFor.SqlServerList
                        Dim sqlServers As String() = intlDelg.EndInvoke(result)
                        cmbSqlServers.Items.AddRange(sqlServers)
                        If cmbSqlServers.Items.Count > 0 Then
                            cmbSqlServers.Sorted = True
                            cmbSqlServers.SelectedIndex = 0
                        End If
                        Me.Cursor = Cursors.[Default]
                        btnLoadSqlServers.Enabled = True
                        txtUserName.[Select]()
                        txtUserName.Focus()
                        Exit Select
                    Case CallFor.SqlDataBases
                        Dim sqlDatabases As String() = intlDelg.EndInvoke(result)
                        cmbAllDataBases.Items.AddRange(sqlDatabases)
                        If cmbAllDataBases.Items.Count > 0 Then
                            cmbAllDataBases.Sorted = True
                            cmbAllDataBases.SelectedIndex = 0
                        End If
                        Me.Cursor = Cursors.[Default]
                        btnGetAllDataBases.Enabled = True
                        Exit Select
                    Case CallFor.SqlTables
                        reader = command.EndExecuteReader(result)
                        cmbTables.Items.Clear()
                        While reader.Read()
                            cmbTables.Items.Add(reader(0).ToString())
                        End While
                        If cmbTables.Items.Count > 0 Then
                            cmbTables.Sorted = True
                            cmbTables.SelectedIndex = 0
                            grpDataManipulate.Enabled = True
                        Else
                            grpDataManipulate.Enabled = False
                        End If
                        Exit Select
                End Select
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            Finally
                If called = CallFor.SqlTables Then
                    btnGetAllTables.Enabled = True
                    Me.Cursor = Cursors.[Default]
                End If
                prgProgress.Value = 0
                prgProgress.Refresh()
                ticker.[Stop]()
            End Try
        End If
    End Sub

 

    Private Function FindLastPageRecords() As Integer
        Return (totalRecords Mod Integer.Parse(cmbNoOfRecords.Text))
    End Function



    Private Sub btnGetAllDataBases_Click(sender As Object, e As EventArgs) Handles btnGetAllDataBases.Click


        'If cmbSqlServers.Items.Count > 0 AndAlso txtPassword.Text.Trim().CompareTo(String.Empty) <> 0 AndAlso txtUserName.Text.Trim().CompareTo(String.Empty) <> 0 Then
        ticker.Start()
        btnGetAllDataBases.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        cmbAllDataBases.Items.Clear()
        sqlInfo.SQLServer = "mt4Sql06"
        sqlInfo.Username = txtUserName.Text.Trim()
        sqlInfo.Password = txtPassword.Text.Trim()
        MessageBox.Show("You may get the list sql servers if user name and password are not correct.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, 0, _
            False)
        intlDelg = New InternalDelegate(AddressOf sqlInfo.EnumerateSQLServersDatabases)
        called = CallFor.SqlDataBases
        intlDelg.BeginInvoke(New AsyncCallback(AddressOf CallBackMethod), intlDelg)
        'Else
        '    MessageBox.Show("No sql servers loaded or user name or password empty...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0, _
        '        False)
        'End If

    End Sub

  
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click

        lblLoadedTable.Text = "Loading data from table " & cmbTables.Text.Trim()
        btnLoad.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        Try
            If userTable IsNot Nothing Then
                userTable.Clear()
            End If
            userDataGridView.DataSource = Nothing
            userDataGridView.Rows.Clear()
            userDataGridView.Refresh()
            ' sqlQuery = "SELECT * FROM [" & cmbTables.Text.Trim() & "]"
            sqlQuery = "SELECT * FROM facebookinputdata "
            SetDataObjects()
            connection.Open()
            ticker.Start()
            adapter.Fill(tempDataSet)
            totalRecords = tempDataSet.Tables(0).Rows.Count
            tempDataSet.Clear()
            tempDataSet.Dispose()
            adapter.Fill(ds, 0, 5, cmbTables.Text.Trim())
            userTable = ds.Tables(cmbTables.Text.Trim())

            For Each dc As DataColumn In userTable.Columns
                Dim column As New DataGridViewTextBoxColumn()
                column.DataPropertyName = dc.ColumnName
                column.HeaderText = dc.ColumnName
                column.Name = dc.ColumnName
                column.SortMode = DataGridViewColumnSortMode.Automatic
                column.ValueType = dc.DataType
                userDataGridView.Columns.Add(column)
            Next
            lblLoadedTable.Text = "Data loaded from table: " + userTable.TableName
            lblTotRecords.Text = "Total records: " & totalRecords
            CreateTempTable(0, Integer.Parse(cmbNoOfRecords.Text.Trim()))

            btnPrevious.Enabled = True
            btnFirst.Enabled = True
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnLast.Enabled = True
            btnAdd.Enabled = True
            btnUpdate.Enabled = True
            btnDelete.Enabled = True
            cmbNoOfRecords.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        Finally
            connection.Close()
            btnLoad.Enabled = True
            Me.Cursor = Cursors.[Default]
            prgProgress.Value = 0
            prgProgress.Update()
            prgProgress.Refresh()
            ticker.[Stop]()
        End Try
    End Sub

    
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            userDataGridView.[ReadOnly] = False
            btnAdd.Enabled = False
            btnUpdate.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            connection.Open()
            adapter.Update(userTable)
            userDataGridView.[ReadOnly] = True
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
            btnUpdate.Enabled = True
        Finally
            btnAdd.Enabled = True
            btnLoad.Enabled = True
            connection.Close()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("Do you really want to delete selected record(s)?", "Delete Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, _
    False) = DialogResult.Yes Then
            Try
                connection.Open()
                Dim cnt As Integer = userDataGridView.SelectedRows.Count
                For i As Integer = 0 To cnt - 1
                    If Me.userDataGridView.SelectedRows.Count > 0 AndAlso Me.userDataGridView.SelectedRows(0).Index <> Me.userDataGridView.Rows.Count - 1 Then
                        Me.userDataGridView.Rows.RemoveAt(Me.userDataGridView.SelectedRows(0).Index)
                    End If
                Next

                adapter.Update(userTable)
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            Finally
                connection.Close()
                btnLoad.Enabled = True
            End Try
        End If

    End Sub

    Private Sub btnLoadSqlServers_Click(sender As Object, e As EventArgs) Handles btnLoadSqlServers.Click
        ticker.Start()
        btnLoadSqlServers.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        cmbSqlServers.Items.Clear()
        called = CallFor.SqlServerList
        intlDelg.BeginInvoke(New AsyncCallback(AddressOf CallBackMethod), intlDelg)
    End Sub

    Private Sub btnGetAllTables_Click(sender As Object, e As EventArgs) Handles btnGetAllTables.Click

        If cmbAllDataBases.Text.Trim().CompareTo(String.Empty) <> 0 Then
            btnGetAllTables.Enabled = False
            Me.Cursor = Cursors.WaitCursor
            'Dim connStr As New StringBuilder()
            'connStr.Append("Database=")
            'connStr.Append(cmbAllDataBases.Text)
            'connStr.Append(";Server=")
            'connStr.Append(cmbSqlServers.Text)
            'connStr.Append(";User=")
            'connStr.Append(txtUserName.Text.Trim())
            'connStr.Append(";Password=")
            'connStr.Append(txtPassword.Text.Trim())
            'connStr.Append(";Enlist=false; Asynchronous Processing=true")
            connectionString = GetConnectionStringForAppDB()
            sqlQuery = "FaceBookInputData" 'getTablesFromDataBase
            SetDataObjects()
            'Try
            '    ticker.Start()
            '    connection.Open()
            '    command.BeginExecuteReader(New AsyncCallback(AddressOf CallBackMethod), command, CommandBehavior.CloseConnection)
            '    called = CallFor.SqlTables
            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString())
            '    ticker.[Stop]()
            'Finally
            '    btnGetAllTables.Enabled = True
            '    Me.Cursor = Cursors.[Default]
            'End Try
        Else
            MessageBox.Show("Please select database first.", "No database", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, 0, _
                False)
        End If


    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        CreateTempTable(0, Integer.Parse(cmbNoOfRecords.Text))
        btnPrevious.Enabled = False
        btnNext.Enabled = True
        btnLast.Enabled = True
        isLastPage = False
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If isLastPage Then
            Dim noc As Integer = FindLastPageRecords()
            CreateTempTable((totalRecords - noc - Integer.Parse(cmbNoOfRecords.Text)), Integer.Parse(cmbNoOfRecords.Text))
        Else
            CreateTempTable((currentIndex - 2 * (Integer.Parse(cmbNoOfRecords.Text))), Integer.Parse(cmbNoOfRecords.Text))
        End If
        btnNext.Enabled = True
        btnLast.Enabled = True
        isLastPage = False
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        CreateTempTable(currentIndex, Integer.Parse(cmbNoOfRecords.Text))
        btnPrevious.Enabled = True

    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Dim totPages As Integer = CInt(totalRecords / Integer.Parse(cmbNoOfRecords.Text))
        Dim remainingRecs As Integer = FindLastPageRecords()

        CreateTempTable(totalRecords - remainingRecs, Integer.Parse(cmbNoOfRecords.Text))
        btnPrevious.Enabled = True
        btnNext.Enabled = False
        isLastPage = True
    End Sub

    Private Sub btnNoOfPages_Click(sender As Object, e As EventArgs) Handles btnNoOfPages.Click
        If Integer.Parse(cmbNoOfRecords.Text.Trim()) >= totalRecords Then
            btnFirst.Enabled = False
            btnPrevious.Enabled = False
            btnNext.Enabled = False
            btnLast.Enabled = False
        Else
            btnFirst.Enabled = True
            btnPrevious.Enabled = True
            btnNext.Enabled = True
            btnLast.Enabled = True
        End If
    End Sub

  
End Class