Imports System.Guid

Public Class SimrPopupForm
    Public m_Vehicledid As Integer

    Public Property VehicleId() As Integer
        Get
            Return m_Vehicledid
        End Get
        Set(ByVal value As Integer)
            m_Vehicledid = value
        End Set
    End Property

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click
        Me.Hide()
    End Sub

    Private Sub sendButton_Click(sender As Object, e As EventArgs) Handles sendButton.Click
        Dim userResponse As DialogResult
        Dim userid As Guid
        Dim VTaskAssignedtoId As Guid
        Dim RetId As Integer
        Dim priority As String
        Dim vTask As String
        Dim descrip As String
        Dim taskTypeId As Integer

        If questionTextBox.Text = "" And reScanTextBox.Text = "" Then

            MsgBox("Both Testbox must not be empty !")
            Exit Sub

        End If


        RetId = getRetailerID(VehicleId)
        userResponse = MessageBox.Show("Message will be sent to SIMR, all Checkbox will be disabled until a response is sent, Continue ?" _
                                               , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

        VTaskAssignedtoId = New Guid(userSender(AssignedToID(VehicleId).ToString))

        If questionTextBox.Text <> "" And reScanTextBox.Text = "" Then
            taskTypeId = 11
            vTask = "Question on VID " + VehicleId.ToString + "&nbsp;" + RetailerName(RetId)
            descrip = questionTextBox.Text
        ElseIf questionTextBox.Text = "" And reScanTextBox.Text <> "" Then
            taskTypeId = 5
            vTask = "Rescan Images" + vbNewLine + "&nbsp;" + RetailerName(RetId)
            descrip = reScanTextBox.Text
        ElseIf questionTextBox.Text <> "" And reScanTextBox.Text <> "" Then
            taskTypeId = 5
            vTask = "Rescan" + vbNewLine + "&nbsp;" + RetailerName(RetId)
            descrip = questionTextBox.Text + vbNewLine + reScanTextBox.Text
        End If
        priority = "P1"

        If String.IsNullOrEmpty(userSender(GetSenderid(VehicleId.ToString))) = False Then
            userid = New Guid(userSender(GetSenderid(VehicleId.ToString)))
        Else
            userid = Guid.Empty
        End If
        'Change createdbyid

        CreateSupervisorTask(taskTypeId, VTaskAssignedtoId, VehicleId, VTaskAssignedtoId, RetId, priority, vTask, descrip)

        UpdateVehicleStatus(VehicleId)
        UpdateVehiclePageStatus(VehicleId)
        MsgBox("Message was successful sent.")
        Dim frm As New UI.QCForm
        frm.findVehicleIdTextBox.Text = CStr(VehicleId)
        frm.loadButton.PerformClick()

        Me.Hide()

    End Sub

    Public Shared Function ToGuid(value As Integer) As Guid
        Dim bytes As Byte() = New Byte(15) {}
        BitConverter.GetBytes(value).CopyTo(bytes, 0)
        Return New Guid(bytes)
    End Function

    'Private Sub QuestionCheckBox_CheckedChanged(sender As Object, e As EventArgs)
    '    If QuestionCheckBox.Checked = True Then

    '    Else
    '        questionTextBox.Text = ""
    '    End If
    'End Sub

    'Private Sub rescanCheckBox_CheckedChanged(sender As Object, e As EventArgs)
    '    Dim PageString As String

    '    If rescanCheckBox.Checked = True Then
    '        PageString = errorPages(VehicleId)
    '        reScanTextBox.Text = PageString
    '    Else
    '        reScanTextBox.Tex0t = ""
    '    End If


    'End Sub

    Private Function errorPages(ByVal _vehicleid As Integer) As String
        Dim RescanContent As String

        Dim loadErrorPage As DataView
        loadErrorPage = New DataView(getPageStatusRecords(_vehicleid))
        For i As Integer = 0 To loadErrorPage.Count - 1
            If CInt(loadErrorPage(i)("indScannerLines")) = 1 OrElse CInt(loadErrorPage(i)("indCrooked")) = 1 OrElse CInt(loadErrorPage(i)("IndPageTear")) = 1 OrElse CInt(loadErrorPage(i)("IndBleedThrough")) = 1 OrElse CInt(loadErrorPage(i)("IndBadPages")) = 1 Then
                If i = 0 Then
                    RescanContent = "Page " + CInt(loadErrorPage(i)("ReceivedOrder")).ToString("000")
                Else
                    RescanContent = RescanContent + "Page " + CInt(loadErrorPage(i)("ReceivedOrder")).ToString("000")
                End If


                If CInt(loadErrorPage(i)("indScannerLines")) = 1 Then
                    RescanContent = RescanContent + " Scanner Lines"
                Else

                End If

                If CInt(loadErrorPage(i)("indCrooked")) = 1 Then
                    RescanContent = RescanContent + ", Crooked"

                End If

                If CInt(loadErrorPage(i)("IndPageTear")) = 1 Then
                    RescanContent = RescanContent + ", Page Tear"
                End If

                If CInt(loadErrorPage(i)("IndBleedThrough")) = 1 Then
                    RescanContent = RescanContent + ", Bleed Through"
                End If

                If CInt(loadErrorPage(i)("IndBadPages")) = 1 Then
                    RescanContent = RescanContent + ", Bad Pages"
                End If
                RescanContent = RescanContent + vbNewLine
            End If
        Next

        Return RescanContent
    End Function

    Public Function CreateSupervisorTask(ByVal TaskTypeID As Integer, ByVal UserID As Guid, ByVal VehicleID As Integer, ByVal AssignedToIdGuid As Guid, ByVal RetailerID As Integer, ByVal Priority As String, ByVal TaskName As String, ByVal Description As String) As Integer
        Dim obj As Object
        Dim val As Integer

        Dim cmd As System.Data.SqlClient.SqlCommand
        Dim cn As System.Data.SqlClient.SqlConnection

        cn = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
        cmd = New System.Data.SqlClient.SqlCommand
        cn.Open()
        cmd.Connection = cn
        cmd.CommandType = CommandType.StoredProcedure

        cmd.CommandText = "mt_proc_VTaskInsert_SupervisorFromMcap"
        cmd.Parameters.Add("@vTaskIDOutput", SqlDbType.Int).Direction = ParameterDirection.Output

        cmd.Parameters.AddWithValue("@vTaskTypeID", TaskTypeID)
        cmd.Parameters.AddWithValue("@userID", UserID)
        cmd.Parameters.AddWithValue("@createdDT", Now())
        cmd.Parameters.AddWithValue("@vehicleID", VehicleID)
        cmd.Parameters.AddWithValue("@assignedToIdGuid", AssignedToIdGuid)
        cmd.Parameters.AddWithValue("@retailerID", RetailerID)
        'cmd.Parameters.AddWithValue("@priority", Priority)
        cmd.Parameters.AddWithValue("@vTaskName", TaskName)
        cmd.Parameters.AddWithValue("@description", Description)

        obj = cmd.ExecuteScalar()

        val = CType(obj, Integer)

        If cmd.Connection.State = ConnectionState.Open Then
            cmd.Connection.Close()
        End If
        cmd = Nothing

        Return val
    End Function

    Private Function getPageStatusRecords(ByVal _VehicleId As Integer) As DataTable

        Dim connection As System.Data.SqlClient.SqlConnection
        Dim command As System.Data.SqlClient.SqlCommand
        Dim adapter As New System.Data.SqlClient.SqlDataAdapter
        Dim ds As New DataSet
        Dim sql As String

        ' sql = "Select  * from vehiclePageStatus vs inner join page p on vs.VehicleId=p.vehicleid WHERE vs.vehicleid =" + _VehicleId.ToString + " order by p.receivedOrder"
        sql = "Select  * from vehiclePageStatus where vehicleid =" + _VehicleId.ToString + " order by receivedOrder"
        connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
        Try
            connection.Open()
            command = New System.Data.SqlClient.SqlCommand(sql, connection)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            connection.Close()

            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Private Function AssignedToID(ByVal _VehicleId As Integer) As Integer
        Dim assignid As String
        assignid = GetFieldValue("select AssignedToId from vtask where vehicleid=" + _VehicleId.ToString, "AssignedToId")
        Return CInt(assignid)
    End Function

    Private Function getRetailerID(ByVal _VehicleId As Integer) As Integer
        Dim retid As Integer
        retid = CInt(GetFieldValue("select retid from vehicle where vehicleid=" + _VehicleId.ToString, "retid"))
        Return CInt(retid)
    End Function

    Private Function userSender(ByVal userid As String) As String
        Dim senderid As String
        senderid = GetFieldValue("select userid from aspnet_UserSenderAssoc where senderid=" + userid.ToString, "userid")
        If String.IsNullOrEmpty(senderid) = True Then
            senderid = Guid.Empty.ToString
        End If
        Return senderid
    End Function
    Private Function GetSenderid(ByVal Vehicleid As String) As String
        Dim senderid As String
        senderid = GetFieldValue("select distinct e.senderid from envelope e inner join vehicle v on e.envelopeid=v.envelopeid where vehicleid=" + Vehicleid.ToString, "userid")
        If String.IsNullOrEmpty(senderid) = True Then
            senderid = Guid.Empty.ToString
        End If
        Return senderid
    End Function

    Private Function RetailerName(ByVal _retId As Integer) As String
        Dim descrip As String
        descrip = GetFieldValue("select descrip from ret where retid=" + _retId.ToString, "descrip")
        Return descrip
    End Function

    Private Sub UpdateVehicleStatus(ByVal _vehicleID As Integer)
        Dim cmd As System.Data.SqlClient.SqlCommand
        Dim obj As New Object

        cmd = New System.Data.SqlClient.SqlCommand

        Try
            With cmd

                .CommandText = "UPDATE vehicle SET statusid = 2221 where vehicleid = " + _vehicleID.ToString
                .CommandType = CommandType.Text
                .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                .Connection.Open()
                .ExecuteNonQuery()
            End With

        Catch ex As Exception
            Throw New ApplicationException("Failed to restore Page Details.", ex)
        Finally
            If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
        End Try

    End Sub
    Private Sub UpdateVehiclePageStatus(ByVal _vehicleID As Integer)
        Dim cmd As System.Data.SqlClient.SqlCommand
        Dim obj As New Object

        cmd = New System.Data.SqlClient.SqlCommand

        Try
            With cmd

                .CommandText = "UPDATE VehiclePageStatus SET simrResponse = 1 where vehicleid = " + _vehicleID.ToString
                .CommandType = CommandType.Text
                .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                .Connection.Open()
                .ExecuteNonQuery()
            End With

        Catch ex As Exception
            Throw New ApplicationException("Failed to restore Page Details.", ex)
        Finally
            If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
        End Try

    End Sub

    Private Sub SimrPopupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim PageString As String
        PageString = errorPages(VehicleId)
        reScanTextBox.Text = PageString
    End Sub
End Class
