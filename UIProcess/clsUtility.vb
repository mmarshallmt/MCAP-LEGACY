﻿Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.Reflection

Module clsUtility

    Dim sSql As String
    Public Sub FillListView(ByRef lvList As ListView, ByRef myData As SqlDataReader)
        Dim itmListItem As ListViewItem
        Dim strValue As Object
        Dim shtCntr As Integer

        Do While myData.Read
            itmListItem = New ListViewItem()
            strValue = IIf(myData.IsDBNull(0), "", myData.GetValue(0))
            'itmListItem.Text = strValue

            For shtCntr = 1 To myData.FieldCount() - 1
                If myData.IsDBNull(shtCntr) Then
                    itmListItem.SubItems.Add("")
                Else
                    'itmListItem.SubItems.Add(myData.GetValue(shtCntr))
                End If
            Next shtCntr

            lvList.Items.Add(itmListItem)
        Loop
    End Sub
    Public Function GetFieldValue(ByVal srcSQL As String, ByVal strField As String) As String
        'create connection
        Dim cnMcap As SqlConnection
        cnMcap = New SqlConnection

        With cnMcap
            If .State = ConnectionState.Open Then .Close()
            .ConnectionString = GetConnectionStringForAppDB()
            '.ConnectionString = "Data Source=mt4sql06;Initial Catalog=MarathonMCAPDEV;Integrated Security=SSPI"
            .Open()
        End With

        Try
            Dim cmd As SqlCommand = New SqlCommand(srcSQL, cnMcap)
            'create data reader
            Dim rdr As SqlDataReader = cmd.ExecuteReader

            'loop through result set
            While (rdr.Read)
                GetFieldValue = rdr(strField).ToString()
            End While
            'close data reader
            rdr.Close()
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing


        Catch e As Exception
            Console.WriteLine("Error Occurred:" & e.ToString)
        Finally
            ' Close connection
            cnMcap.Close()
        End Try
    End Function

    Public Function sqlDate(ByVal dtDate As String) As String
        Dim searchfrom As String = FormatDateTime(CDate(dtDate), DateFormat.GeneralDate) & " " & FormatDateTime(CDate(dtDate), DateFormat.LongTime)
        Return searchfrom
    End Function

    Public Sub ColorWord(ByVal WordSearch As String, ByVal objTextBox As RichTextBox, ByVal WordColor As Color, ByVal FontSize As Single, ByVal Style As FontStyle)
        ' Find WordSearch
        If WordSearch <> Nothing Then
            Dim FindPosition As Integer = objTextBox.Find(WordSearch, 0, RichTextBoxFinds.WholeWord)
            While FindPosition <> -1 ' continue if WordSearch found
                ' set color
                objTextBox.SelectionColor = WordColor
                ' set text
                objTextBox.SelectionFont = New Font(objTextBox.SelectionFont.FontFamily, FontSize, Style)
                ' find next WordSearch
                If FindPosition + WordSearch.Length < objTextBox.TextLength Then

                    FindPosition = objTextBox.Find(WordSearch, FindPosition + WordSearch.Length, objTextBox.TextLength, RichTextBoxFinds.WholeWord)
                Else
                    Exit While
                End If
            End While
        End If
    End Sub
    Public Function CleanString(ByVal criteria As String) As String
        Dim Regex As Regex
        While criteria.Contains("vbLf")
            criteria = criteria.Replace("vbLfvbLf", "vbLF")
        End While
        criteria = Regex.Replace(criteria, "(\s)+\r\n", ControlChars.CrLf)
        criteria = Regex.Replace(criteria, "[^A-Za-z0-9\-/]", " ")
        criteria = Regex.Replace(criteria, "\s{2,}", " ")

        Return SplitText(criteria.TrimEnd)
    End Function
    Public Function SplitText(ByVal criteria As String) As String
        Dim source As String

        source = criteria
        'Check For Comas in inputs
        If criteria.Contains(" ") = True Then

            source = Replace(criteria, " ", ",")
        ElseIf criteria.Contains("{\lf}") Then
            source = Replace(criteria, "{\lf}", ",")
        ElseIf criteria.Contains(ControlChars.CrLf.ToString()) Then
            source = Replace(criteria, vbCrLf, ",")
        ElseIf criteria.Contains("\r\n") Then
            source = Replace(criteria, "\r\n", ",")
        ElseIf criteria.Contains("\n") Then
            source = Replace(criteria, "\n", ",")
        ElseIf criteria.Contains("\par") Then
            source = Replace(criteria, "\par", ",")
        ElseIf criteria.Contains("CR") Then
            source = Replace(criteria, "CR", ",")
        ElseIf criteria.Contains(ControlChars.Lf) Then
            source = Replace(criteria, ControlChars.Lf, ",")
        ElseIf criteria.Contains(System.Environment.NewLine.ToString()) Then
            source = Replace(criteria, System.Environment.NewLine, ",")
        ElseIf criteria.Contains(",,") Then
            source = Replace(criteria, ",,", ",")
        ElseIf criteria.Contains(",") Then

            source = criteria

        End If
        'Get text input
        Return source
    End Function

    Public Function GetData(ByVal sSQL As String) As SqlDataReader
        Dim myData As SqlDataReader
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Try
            If Not sSQL = "" Then
                con.ConnectionString = GetConnectionStringForAppDB()
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.CommandText = sSQL
                cmd.ExecuteNonQuery()
                myData = cmd.ExecuteReader
            End If
            Return myData
        Catch ex As SqlException
            Console.WriteLine(ex.Message)
        End Try
        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        cmd = Nothing

    End Function

    Public Function GetSpData(ByVal sSQL As String) As SqlDataReader
        Dim CN As SqlConnection
        CN = New SqlConnection(GetConnectionStringForAppDB())
        Dim sqlCmd As SqlCommand = New SqlCommand(sSQL, CN)
        sqlCmd.CommandType = CommandType.StoredProcedure
        Dim myData As SqlDataReader
        Try
            CN.Open()
            myData = sqlCmd.ExecuteReader
            Return myData
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If sqlCmd.Connection.State = ConnectionState.Open Then
            sqlCmd.Connection.Close()
        End If
        sqlCmd = Nothing

    End Function

    Public Function isVehicleQCed(ByVal _vehicleid As Integer) As Boolean


        Dim cmd As System.Data.SqlClient.SqlCommand
        Dim con As System.Data.SqlClient.SqlConnection
        Dim obj As Object
        Dim stat As Integer

        cmd = New System.Data.SqlClient.SqlCommand
        con = New System.Data.SqlClient.SqlConnection

        con.ConnectionString = GetConnectionStringForAppDB()
        con.Open()

        cmd.Connection = con

        cmd.CommandType = CommandType.Text

        cmd.CommandText = "Select StatusId FROM vwcircular WHERE Vehicleid =" + _vehicleid.ToString

        obj = cmd.ExecuteScalar

        If IsDBNull(obj) Then obj = 0

        If CType(obj, Integer) = 22 Then
            isVehicleQCed = True
        ElseIf CType(obj, Integer) = 27 Or CType(obj, Integer) = 0 Then
            isVehicleQCed = False
        End If

        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        cmd = Nothing

    End Function

    'Execute Non Query
    Public Sub ExecNonQuery(ByVal strSQL As String)

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Try
            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()
            cmd.Connection = con
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Error while inserting record on table..." & ex.Message, "Insert Records")
        Finally
            con.Close()
        End Try

    End Sub

    Public Sub SetAllCommandTimeouts(adapter As Object, timeout As Integer)
        Dim commands As Object = adapter.[GetType]().InvokeMember("CommandCollection", BindingFlags.GetProperty Or BindingFlags.Instance Or BindingFlags.NonPublic, Nothing, adapter, New Object(-1) {})
        Dim sqlCommand As SqlCommand() = DirectCast(commands, SqlCommand())
        For Each cmd As SqlCommand In sqlCommand
            cmd.CommandTimeout = timeout
        Next
    End Sub

    Public Sub MoveColumn(theDataGrid As DataGrid, theMappingName As String, _
                          theOldColumn As Integer, theNewColumn As Integer)

        If theOldColumn = theNewColumn Then Return

        Dim oldTS As DataGridTableStyle = theDataGrid.TableStyles(theMappingName)
        Dim newTS As New DataGridTableStyle()
        Dim i As Integer = 0

        newTS.MappingName = theMappingName

        While i < oldTS.GridColumnStyles.Count
            If i <> theOldColumn And theOldColumn < theNewColumn Then
                newTS.GridColumnStyles.Add(oldTS.GridColumnStyles(i))
            End If

            If i = theNewColumn Then
                newTS.GridColumnStyles.Add(oldTS.GridColumnStyles(theOldColumn))
            End If

            If i <> theOldColumn And theOldColumn > theNewColumn Then
                newTS.GridColumnStyles.Add(oldTS.GridColumnStyles(i))
            End If

            i += 1
        End While

        theDataGrid.TableStyles.Remove(oldTS)
        theDataGrid.TableStyles.Add(newTS)
    End Sub

    Public Function GetColName(ByVal name As String, ByRef dgv As DataGridView) As Integer
        Dim retVal As Integer

        For Each col As DataGridViewColumn In dgv.Columns
            If col.HeaderText = name Then
                retVal = col.Index
                Exit For
            End If
        Next

        Return retVal

    End Function
    Public Function GetColByHeaderText(ByVal dgv As DataGridView, ByVal name As String) As DataGridViewColumn

        For Each col As DataGridViewColumn In dgv.Columns
            If col.HeaderText = name Then
                Return col
            End If
        Next

        Return Nothing

    End Function
    Public Function setDefaultZero(ByVal myString As String) As String
        Dim stringLength As Integer
        Dim StringValue As String
        stringLength = CInt(myString.Length)
        StringValue = "0"
        For i As Integer = 1 To stringLength - 1
            StringValue = StringValue + "0"
        Next
        Return StringValue
    End Function
    Private Sub getData(ByVal dataCollection As AutoCompleteStringCollection, ByVal Sql As String)
        Dim connetionString As String = Nothing
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()

        connection = New SqlConnection(GetConnectionStringForAppDB)
        Try
            connection.Open()
            command = New SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()
            For Each row As DataRow In ds.Tables(0).Rows
                dataCollection.Add(row(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show("Can not open connection ! ")
        End Try
    End Sub
    Public Sub TextBoxAutoComplete(ByVal text As TextBox, ByVal SqlQuery As String)
        text.AutoCompleteMode = AutoCompleteMode.Suggest
        text.AutoCompleteSource = AutoCompleteSource.CustomSource
        Dim DataCollection As New AutoCompleteStringCollection()
        GetData(DataCollection, SqlQuery)
        text.AutoCompleteCustomSource = DataCollection
    End Sub
    Public Sub AutoComplete(cb As ComboBox, e As System.Windows.Forms.KeyPressEventArgs, blnLimitToList As Boolean)
        Dim strFindStr As String = ""

        If e.KeyChar = ChrW(8) Then
            If cb.SelectionStart <= 1 Then
                cb.Text = ""
                Return
            End If

            If cb.SelectionLength = 0 Then
                strFindStr = cb.Text.Substring(0, cb.Text.Length - 1)
            Else
                strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1)
            End If
        Else
            If cb.SelectionLength = 0 Then
                strFindStr = cb.Text + e.KeyChar
            Else
                strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar
            End If
        End If

        Dim intIdx As Integer = -1

        ' Search the string in the ComboBox list.

        intIdx = cb.FindString(strFindStr)

        If intIdx <> -1 Then
            cb.SelectedText = ""
            cb.SelectedIndex = intIdx
            cb.SelectionStart = strFindStr.Length
            cb.SelectionLength = cb.Text.Length
            e.Handled = True
        Else
            e.Handled = blnLimitToList
        End If
    End Sub

    Public Function GetSubstringByString(a As String, b As String, c As String) As String
        Return c.Substring((c.IndexOf(a) + a.Length), (c.IndexOf(b) - c.IndexOf(a) - a.Length))
    End Function



End Module
