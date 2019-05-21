﻿Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports Scripting
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.Security.Permissions

Namespace UI.Processors
    Public Class RequiredProcess
        Inherits BaseClass

        Public Event Initializing()
        Public Event Initialized()
        Public Event LoadingvehicleInformation()
        Public Event vehicleInformationLoaded()

        Private m_ReportDataSet As ReportsDataSet
        Private m_retailerAdapter As ReportsDataSetTableAdapters.RetTableAdapter
        Private m_marketAdapter As ReportsDataSetTableAdapters.MktTableAdapter
        Private m_codeAdapter As ReportsDataSetTableAdapters.CodeTableAdapter
        Private m_NewRetailerCodeTableAdapter As ReportsDataSetTableAdapters.NewRetailerCodeTableAdapter
        Private m_reviewStatus As ReportsDataSetTableAdapters.reviewStatusTableAdapter
        Private m_mediaAdapter As ReportsDataSetTableAdapters.MediaTableAdapter
        Private m_tradeclassAdapter As ReportsDataSetTableAdapters.TradeClassListTableAdapter
        Private m_languageAdapter As ReportsDataSetTableAdapters.LanguageTableAdapter
        Private m_TempRetAdapter As ReportsDataSetTableAdapters.TempRetTableAdapter
        Private m_displayVehicleAdapter As ReportsDataSetTableAdapters.VehicleTableAdapter
        Private m_VehicleTable As ReportsDataset.VehicleDataTable
        Private m_UnregisteredRetTableAdapter As ReportsDataSetTableAdapters.UnregisteredRetTableAdapter
        Private m_UnregisteredRetMktTableAdapter As ReportsDataSetTableAdapters.unRegisteredRetMktTableAdapter
        Private m_simrSenderAdapter As ReportsDataSetTableAdapters.SimrSenderTableAdapter

        Private m_NewRetailersTableAdapter As ReportsDataSetTableAdapters.NewRetailersTableAdapter

        Sub New()
            m_ReportDataSet = New ReportsDataSet
            m_retailerAdapter = New ReportsDataSetTableAdapters.RetTableAdapter
            m_marketAdapter = New ReportsDataSetTableAdapters.MktTableAdapter
            m_mediaAdapter = New ReportsDataSetTableAdapters.MediaTableAdapter
            m_tradeclassAdapter = New ReportsDataSetTableAdapters.TradeClassListTableAdapter
            m_languageAdapter = New ReportsDataSetTableAdapters.LanguageTableAdapter
            m_TempRetAdapter = New ReportsDataSetTableAdapters.TempRetTableAdapter
            m_displayVehicleAdapter = New ReportsDataSetTableAdapters.VehicleTableAdapter
            m_codeAdapter = New ReportsDataSetTableAdapters.CodeTableAdapter
            m_NewRetailerCodeTableAdapter = New ReportsDataSetTableAdapters.NewRetailerCodeTableAdapter
            m_reviewStatus = New ReportsDataSetTableAdapters.reviewStatusTableAdapter
            m_NewRetailersTableAdapter = New ReportsDataSetTableAdapters.NewRetailersTableAdapter
            m_VehicleTable = New ReportsDataSet.VehicleDataTable
            m_UnregisteredRetTableAdapter = New ReportsDataSetTableAdapters.UnregisteredRetTableAdapter
            m_UnregisteredRetMktTableAdapter = New ReportsDataSetTableAdapters.unRegisteredRetMktTableAdapter
            m_simrSenderAdapter = New ReportsDataSetTableAdapters.SimrSenderTableAdapter
        End Sub

        Public ReadOnly Property Data() As ReportsDataSet
            Get
                Return m_ReportDataSet
            End Get
        End Property

        Public ReadOnly Property MediaAdapter() As ReportsDataSetTableAdapters.MediaTableAdapter
            Get
                Return m_mediaAdapter
            End Get
        End Property
        Public ReadOnly Property TradeClassAdapter() As ReportsDataSetTableAdapters.TradeClassListTableAdapter
            Get
                Return m_tradeclassAdapter
            End Get
        End Property

        Public ReadOnly Property LanguageAdapter() As ReportsDataSetTableAdapters.LanguageTableAdapter
            Get
                Return m_languageAdapter
            End Get
        End Property

        Public ReadOnly Property CodeAdapter() As ReportsDataSetTableAdapters.CodeTableAdapter
            Get
                Return m_codeAdapter
            End Get
        End Property
        Public ReadOnly Property NewRetailerCodeAdapter() As ReportsDataSetTableAdapters.NewRetailerCodeTableAdapter
            Get
                Return m_NewRetailerCodeTableAdapter
            End Get
        End Property
        Public ReadOnly Property ReviewStatus() As ReportsDataSetTableAdapters.reviewStatusTableAdapter
            Get
                Return m_reviewStatus
            End Get
        End Property

        Public ReadOnly Property RetailerAdapter() As ReportsDataSetTableAdapters.RetTableAdapter
            Get
                Return m_retailerAdapter
            End Get
        End Property
        Public ReadOnly Property MarketAdapter() As ReportsDataSetTableAdapters.MktTableAdapter
            Get
                Return m_marketAdapter
            End Get
        End Property

        Public ReadOnly Property TempRetAdapter() As ReportsDataSetTableAdapters.TempRetTableAdapter
            Get
                Return m_TempRetAdapter
            End Get
        End Property
        Public ReadOnly Property UnregisteredRetTableAdapter() As ReportsDatasetTableAdapters.UnregisteredRetTableAdapter
            Get
                Return m_UnregisteredRetTableAdapter
            End Get
        End Property

        Public ReadOnly Property UnregisteredRetMktTableAdapter() As ReportsDataSetTableAdapters.unRegisteredRetMktTableAdapter
            Get
                Return m_UnregisteredRetMktTableAdapter
            End Get
        End Property

        Public ReadOnly Property NewRetailersTableAdapter() As ReportsDataSetTableAdapters.NewRetailersTableAdapter
            Get
                Return m_NewRetailersTableAdapter
            End Get
        End Property

        Public ReadOnly Property DisplayVehicleAdapter() As ReportsDataSetTableAdapters.VehicleTableAdapter
            Get
                Return m_displayVehicleAdapter
            End Get
        End Property

        Public ReadOnly Property VehicleTable() As ReportsDataSet.VehicleDataTable
            Get
                Return m_VehicleTable
            End Get
        End Property

        Public ReadOnly Property SimrSenderAdapter() As ReportsDataSetTableAdapters.SimrSenderTableAdapter
            Get
                Return m_simrSenderAdapter
            End Get
        End Property

        ''' <summary>
        ''' Initializes object of this class.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub Initialize()

            RaiseEvent Initializing()

            UnregisteredRetTableAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            UnregisteredRetMktTableAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            MediaAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            TempRetAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            LanguageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            TradeClassAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            TempRetAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            CodeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            NewRetailerCodeAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            RetailerAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            MarketAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            DisplayVehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            RaiseEvent Initialized()

        End Sub

        Public Sub FillMedia()
            Dim tempRow As ReportsDataSet.MediaRow

            MediaAdapter.Fill(Data.Media)

            tempRow = Data.Media.NewMediaRow()
            tempRow.SetMediaIDNull()
            tempRow.Descrip = "All"

            Data.Media.AddMediaRow(tempRow)
            Data.Media.AcceptChanges()

            tempRow = Nothing
        End Sub

        Public Sub FillStatus()
            Dim tempRow As ReportsDataSet.CodeRow

            CodeAdapter.FillByVehicleStatus(Data.Code)

            'tempRow = Data.Code.NewCodeRow
            'tempRow.codeid = Nothing
            'tempRow.descrip = ""

            'Data.Code.AddCodeRow(tempRow)
            'Data.NewRetailerCode.AcceptChanges()

            tempRow = Nothing
        End Sub

        Public Sub FillMarket()
            Dim tempRow As ReportsDataSet.MktRow

            MarketAdapter.FillAllData(Data.Mkt)

            tempRow = Data.Mkt.NewMktRow()
            tempRow.MktId = Nothing
            tempRow.Descrip = "All"

            Data.Mkt.AddMktRow(tempRow)
            Data.Mkt.AcceptChanges()

            tempRow = Nothing
        End Sub

        ''' <summary>
        ''' Clears Ret DataTable and fills in retailer records having NULL in EndDt column.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub FillRetailers()

            RetailerAdapter.Fill(Data.Ret)

        End Sub
        Public Sub FillTradeClass()
            TradeClassAdapter.Fill(Data.TradeClassList)
        End Sub

        Public Sub FillTempRet()
            TempRetAdapter.Fill(Data.TempRet)
        End Sub

        Public Sub FillSimrSender()

            SimrSenderAdapter.Fill(Data.SimrSender)

        End Sub

        ''' <summary>
        ''' Loads records satisfying supplied parameters.
        ''' </summary>
        ''' <param name="retId"></param>
        ''' <param name="mediaId"></param>
        ''' <param name="breakDate"></param>
        ''' <param name="dayRange"></param>
        ''' <param name="showReviewed"></param>
        ''' <remarks></remarks>
        Public Sub Load(ByVal envelopeId As Integer, ByVal retId As Integer, ByVal mktid As Integer, ByVal statusid As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal IDType As Integer)

            RaiseEvent LoadingvehicleInformation()

            If envelopeId > 0 Then
                DisplayVehicleAdapter.GetTableVehicleDatabySearch(Data.Vehicle, StartDate, EndDate, envelopeId, statusid, retId, mktid, IDType)

            Else 'go through old process
                If retId = 0 And mktid = 0 Then
                    DisplayVehicleAdapter.GetTableVehicleData(Data.Vehicle, StartDate, EndDate, envelopeId, statusid)
                ElseIf retId = 0 And mktid > 0 Then
                    DisplayVehicleAdapter.GetTableVehicleDataByMktid(Data.Vehicle, StartDate, EndDate, envelopeId, statusid, mktid)
                ElseIf retId > 0 And mktid = 0 Then
                    DisplayVehicleAdapter.GetTableVehicleDataByRetId(Data.Vehicle, StartDate, EndDate, envelopeId, statusid, retId)
                Else
                    DisplayVehicleAdapter.GetTableVehicleDataByAll(Data.Vehicle, StartDate, EndDate, envelopeId, statusid, mktid, retId)
                End If
            End If





            RaiseEvent vehicleInformationLoaded()

        End Sub



        Public Sub UpdateVehicleRetailer(ByVal vehicleId As Object, ByVal retid As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "UPDATE Vehicle SET Retid = " + retid.ToString + " where Vehicleid = '" + vehicleId.ToString + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub
        Public Sub UpdateVehicleStatus(ByVal vehicleId As Object, ByVal statusid As Integer, ByVal Userid As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "UPDATE Vehicle SET statusid = " + statusid.ToString + ",statusChangedByID=" + Userid.ToString + "  where Vehicleid = '" + vehicleId.ToString + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub
        Public Sub UpdateVehicleStatusforIndex(ByVal vehicleId As Object)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "UPDATE Vehicle SET statusid = Null where Vehicleid = '" + vehicleId.ToString + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub

        Public Sub UpdateUnregisterRetailerStatus(ByVal status As Object, ByVal retid As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "UPDATE RetStatus SET statusid = " + status.ToString + " where retid = '" + retid.ToString + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub

        Public Sub InsertUnregisterRetailerStatus(ByVal status As Object, ByVal retid As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "insert into RetStatus (retid,statusid) values(" + retid.ToString + "," + status.ToString + ")"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub
        Public Function ifRetailerExist(ByVal retid As Integer) As Boolean
            Dim stringvalue As String
            Dim exist As Boolean = True

            stringvalue = GetFieldValue("select retid from retStatus where retid=" + retid.ToString, "retid")
            If String.IsNullOrEmpty(stringvalue) Then
                exist = False
            End If
            Return exist
        End Function

        Public Function getStatusId(ByVal status As String) As Integer
            Return CInt(GetFieldValue("select codeid from code where descrip='" + status.ToString + "' and codetypeid=4", "codeid"))
        End Function
        Public Function GetStatusIdForBackupSender() As Integer
            Return getStatusId("Backup Sender")
        End Function

        Public Function GetStatusIdForReview() As Integer
            Return getStatusId("Review")
        End Function

        Public Function GetStatusIdForDuplicate() As Integer
            Return getStatusId("Duplicate")
        End Function

        Public Function GetStatusIdForUnregisteredRetMkt() As Integer
            Return getStatusId("Unregistered RetMkt")
        End Function

        Public Function GetStatusIdForWrongVersion() As Integer
            Return getStatusId("Wrong Version")
        End Function

        Public Function GetStatusIdForUnregisteredRetMktMedia() As Integer
            Return getStatusId("Unregistered RetMktMedia")
        End Function

        Public Sub UpdateVehicleStatusReview(ByVal status As Object, ByVal vehicleid As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "UPDATE Vehicle SET CheckinOccurence = Null, statusid = " + status.ToString + " where vehicleid = '" + vehicleid.ToString + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub

        Public Sub UpdateVehicleStatusIfReviewed(ByVal ReviewStatus As Integer, ByVal Vehicleid As Integer, ByVal Senderid As Integer, ByVal media As Integer, ByVal mktid As Integer, ByVal retid As Integer)
            Dim status As Integer = 0
            If ReviewStatus = 2214 Then
                If isBackupSender(Senderid, media, mktid, retid) = True Then
                    MessageBox.Show("Vehicle Marked as Backup Sender .", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    status = GetStatusIdForBackupSender()

                Else
                    If (isUnregisteredRetMktExists(media, mktid, retid) = True) OrElse (isUnregisteredRetMkt(mktid, retid) = True) Then
                        MessageBox.Show("Vehicle Marked as Unregistered RetMkt .", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        status = GetStatusIdForUnregisteredRetMkt()


                    End If
                    If (isUnregisteredRetMktMediaExists(media, mktid, retid) = True) OrElse (isUnregisteredRetMktMedia(media, mktid, retid) = True) Then
                        MessageBox.Show("Vehicle Marked as Unregistered RetMktMedia .", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        status = GetStatusIdForUnregisteredRetMktMedia()

                    End If

                End If
                Me.UpdateVehicleStatusReview(status, Vehicleid)
            End If
        End Sub

        Public Sub UpdateNewRetailerStatus(ByVal status As Object, ByVal vehicleid As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "UPDATE UnRegisteredRetailers SET statusid = " + status.ToString + " where vehicleid = '" + vehicleid.ToString + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub

        Public Sub UpdateUnregisterRetailerStatus(ByVal status As Object, ByVal retid As Integer, ByVal mktid As Integer, ByVal mediaid As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "UPDATE RetMktStatus SET statusid = " + status.ToString + " where retid = '" + retid.ToString + "' and mktid='" + mktid.ToString() + "' and mediaid='" + mediaid.ToString() + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub

        Public Sub InsertUnregisterRetailerStatus(ByVal status As Object, ByVal retid As Integer, ByVal mktid As Integer, ByVal mediaid As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "insert into RetMktStatus (retid,mktid,statusid,mediaid) values(" + retid.ToString + "," + mktid.ToString + "," + status.ToString + "," + mediaid.ToString + ")"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub

        Public Sub InsertBypassSenderVehicleHistory(ByVal vehicleId As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "insert into BypassSenderVehicleIndex (vehicleId,SentDt) values(" + vehicleId.ToString + ",'" + Now().ToString + "')"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub

        Public Function ifRetailerExist(ByVal retid As Integer, ByVal mktid As Integer, ByVal mediaid As Integer) As Boolean
            Dim stringvalues As String
            Dim exist As Boolean = True

            stringvalues = GetFieldValue("select retid from retMktStatus where retid=" + retid.ToString + " and mktid=" + mktid.ToString + " and mediaid=" + mediaid.ToString, "retid")
            If String.IsNullOrEmpty(stringvalues) = True Then
                exist = False
            End If
            Return exist
        End Function

        Public Function ifNewRetailerExist(ByVal descrip As String) As Boolean
            Dim sql As String
            Dim retid As String
            Dim isvalid As Boolean = False
            sql = "Select distinct retid from ret where descrip like '%" & descrip & "%' and endDt is not Null"

            retid = GetFieldValue(sql, "retid")
            If String.IsNullOrEmpty(retid) = True Then
                isvalid = False
            Else
                isvalid = True
            End If
            Return isvalid
        End Function

        Private Function existingRetid(ByVal descrip As String) As Integer
            Dim sql As String
            Dim retid As String
            Dim isvalid As Boolean = False
            sql = "Select distinct retid from ret where descrip='" & descrip & "'"
            retid = GetFieldValue(sql, "retid")
            Return CInt(retid)

        End Function


        Public Sub DeleteTempRetailer(ByVal vehicleId As Object)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "delete from UnRegisteredRetailers where Vehicleid = '" + vehicleId.ToString + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub

        Public Function InsertRetailer(ByVal Descrip As String, ByVal tradeclass As Integer) As Integer

            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim cm As New SqlCommand
            Dim insQry As String = ""
            Dim retid As Integer

            Try

                insQry = "INSERT INTO [Ret]([Descrip],tradeclassid,startdt,priority,languageid)"
                insQry = insQry & "VALUES (@Descrip,@tradeclassid,@StartDt,@Priority,@Languageid);"
                insQry = insQry & "SELECT @newPkId = retid FROM [Ret] WHERE retid=SCOPE_IDENTITY()"
                con.ConnectionString = GetConnectionStringForAppDB()
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.CommandText = insQry
                cmd.Parameters.AddWithValue("@Descrip", Descrip)
                cmd.Parameters.AddWithValue("@tradeclassid", tradeclass)
                cmd.Parameters.AddWithValue("@StartDt", Now())
                cmd.Parameters.AddWithValue("@Priority", 1)
                cmd.Parameters.AddWithValue("@Languageid", 1)
                Dim param As New SqlParameter("@newPkId", SqlDbType.Int)
                param.Direction = ParameterDirection.Output
                cmd.Parameters.Add(param)
                cmd.ExecuteNonQuery()
                retid = CInt(cmd.Parameters.Item("@newPkId").Value)

            Catch ex As SqlException
                Throw New Exception(ex.Message)
            End Try

            Return retid

        End Function

        Public Function isRequiredRetailers(ByVal senderid As Integer, ByVal mediaid As Integer, ByVal mktid As Integer, ByVal retid As Integer) As Boolean
            Dim isValid As Boolean = False

            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim reader As System.Data.SqlClient.SqlDataReader
            Dim obj As Object
            Dim val As Boolean

            Try
                con = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                cmd = New System.Data.SqlClient.SqlCommand
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "mt_proc_isRequiredRetailer"
                cmd.Parameters.AddWithValue("@Senderid", senderid)
                cmd.Parameters.AddWithValue("@retid", retid)
                cmd.Parameters.AddWithValue("@mktid", mktid)
                cmd.Parameters.AddWithValue("@mediaid", mediaid)
                cmd.Parameters.Add("@isvalid", SqlDbType.Bit).Direction = ParameterDirection.Output

                obj = cmd.ExecuteScalar()

                val = CType(obj, Boolean)
                If val = True Then
                    isValid = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return isValid
        End Function

        Public Function isBackupSender(ByVal senderid As Integer, ByVal mediaid As Integer, ByVal mktid As Integer, ByVal retid As Integer) As Boolean
            Dim isValid As Boolean = False

            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim reader As System.Data.SqlClient.SqlDataReader
            Dim obj As Object
            Dim val As Boolean

            Try
                con = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                cmd = New System.Data.SqlClient.SqlCommand
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "mt_proc_isBackupSender"
                cmd.Parameters.AddWithValue("@Senderid", senderid)
                cmd.Parameters.AddWithValue("@retid", retid)
                cmd.Parameters.AddWithValue("@mktid", mktid)
                cmd.Parameters.AddWithValue("@mediaid", mediaid)
                cmd.Parameters.Add("@isvalid", SqlDbType.Bit).Direction = ParameterDirection.Output

                obj = cmd.ExecuteScalar()

                val = CType(obj, Boolean)
                If val = True Then
                    isValid = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return isValid
        End Function


        Public Function isUnregisteredRetMktMedia(ByVal mediaid As Integer, ByVal mktid As Integer, ByVal retid As Integer) As Boolean
            Dim isValid As Boolean = False

            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim reader As System.Data.SqlClient.SqlDataReader
            Dim obj As Object
            Dim val As Boolean

            Try
                con = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                cmd = New System.Data.SqlClient.SqlCommand
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "mt_proc_GetUnRegisteredRetMktMedia"

                cmd.Parameters.AddWithValue("@retid", retid)
                cmd.Parameters.AddWithValue("@mktid", mktid)
                cmd.Parameters.AddWithValue("@mediaid", mediaid)
                cmd.Parameters.Add("@isvalid", SqlDbType.Bit).Direction = ParameterDirection.Output

                obj = cmd.ExecuteScalar()

                val = CType(obj, Boolean)
                If val = True Then
                    isValid = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return isValid
        End Function

        Public Function isUnregisteredRetMkt(ByVal mktid As Integer, ByVal retid As Integer) As Boolean
            Dim isValid As Boolean = False

            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim reader As System.Data.SqlClient.SqlDataReader
            Dim obj As Object
            Dim val As Boolean

            Try
                con = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                cmd = New System.Data.SqlClient.SqlCommand
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "mt_proc_GetUnRegisteredRetMkt"
                cmd.Parameters.AddWithValue("@retid", retid)
                cmd.Parameters.AddWithValue("@mktid", mktid)
                cmd.Parameters.Add("@isvalid", SqlDbType.Bit).Direction = ParameterDirection.Output

                obj = cmd.ExecuteScalar()

                val = CType(obj, Boolean)
                If val = True Then
                    isValid = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return isValid
        End Function
        Public Function isUnregisteredRetMktExists(ByVal MediaId As Integer, ByVal mktid As Integer, ByVal retid As Integer) As Boolean
            Dim isValid As Boolean = False

            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim reader As System.Data.SqlClient.SqlDataReader
            Dim obj As Object
            Dim val As Boolean

            Try
                con = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                cmd = New System.Data.SqlClient.SqlCommand
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "mt_proc_GetUnRegisteredRetMktExists"
                cmd.Parameters.AddWithValue("@mediaid", MediaId)
                cmd.Parameters.AddWithValue("@retid", retid)
                cmd.Parameters.AddWithValue("@mktid", mktid)
                cmd.Parameters.Add("@isvalid", SqlDbType.Bit).Direction = ParameterDirection.Output

                obj = cmd.ExecuteScalar()

                val = CType(obj, Boolean)
                If val = True Then
                    isValid = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return isValid
        End Function

        Public Function isUnregisteredRetMktMediaExists(ByVal MediaId As Integer, ByVal mktid As Integer, ByVal retid As Integer) As Boolean
            Dim isValid As Boolean = False

            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim reader As System.Data.SqlClient.SqlDataReader
            Dim obj As Object
            Dim val As Boolean

            Try
                con = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                cmd = New System.Data.SqlClient.SqlCommand
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "mt_proc_GetUnRegisteredRetMktMediaExists"
                cmd.Parameters.AddWithValue("@mediaid", MediaId)
                cmd.Parameters.AddWithValue("@retid", retid)
                cmd.Parameters.AddWithValue("@mktid", mktid)
                cmd.Parameters.Add("@isvalid", SqlDbType.Bit).Direction = ParameterDirection.Output

                obj = cmd.ExecuteScalar()

                val = CType(obj, Boolean)
                If val = True Then
                    isValid = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return isValid
        End Function

        Public Function DataGridViewToExcel(ByVal Datagrid As DataGridView) As String
            Dim isValid As Boolean = False
            Try
                Dim xlApp As Excel.Application
                Dim xlWorkBook As Excel.Workbook
                Dim xlWorkSheet As Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value

                Dim i As Int16, j As Int16

                xlApp = New Excel.ApplicationClass
                xlWorkBook = xlApp.Workbooks.Add(misValue)
                xlWorkSheet = CType(xlWorkBook.Sheets("sheet1"), Worksheet)

                For Each col As DataGridViewColumn In Datagrid.Columns
                    xlWorkSheet.Cells(1, col.Index + 1) = col.HeaderText.ToString
                Next

                For i = 0 To CShort(Datagrid.RowCount - 1)
                    For j = 0 To CShort(Datagrid.ColumnCount - 1)
                        xlWorkSheet.Cells(i + 2, j + 1) = Datagrid(j, i).Value.ToString()
                    Next
                Next

                Dim originalExcelPath As String = "C:\UnregisteredReport"
                Dim xlFileName As String = "UnregisteredReport.xls"


                Dim fp As New FileIOPermission(FileIOPermissionAccess.AllAccess, originalExcelPath.ToString)
                fp.Assert()

                If Not IO.Directory.Exists(originalExcelPath.ToString) Then
                    IO.Directory.CreateDirectory(originalExcelPath.ToString())
                End If

                If System.IO.File.Exists(originalExcelPath.ToString + "\" + xlFileName) = True Then

                    System.IO.File.Delete(originalExcelPath.ToString + "\" + xlFileName)

                End If

                xlWorkBook.SaveAs(originalExcelPath.ToString + "\" + xlFileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, _
                 Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue)
                xlWorkBook.Close(True, misValue, misValue)
                xlApp.Quit()

                releaseObject(xlWorkSheet)
                releaseObject(xlWorkBook)
                releaseObject(xlApp)
                isValid = True
                Return originalExcelPath.ToString + "\" + xlFileName
            Catch ex As Exception
                isValid = False
            End Try

        End Function

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


        Public Function vehicleData(ByVal vehicleid As Integer) As Data.DataTable
            Dim conn As SqlConnection = New SqlConnection(GetConnectionStringForAppDB())

            Dim myDataAdapter As New SqlDataAdapter
            Dim cmd As New SqlCommand("select envelope.senderid,mediaid,mktid from vehicle inner join envelope on vehicle.EnvelopeId=Envelope.EnvelopeId where vehicleid=" + vehicleid.ToString, conn)
            Dim myDataTable As New Data.DataTable

            'Set the select command on the DataAdapter
            myDataAdapter.SelectCommand = cmd

            'Fill the DataTable
            myDataAdapter.Fill(myDataTable)

            Return myDataTable

        End Function

        Public Function retailerData(ByVal descrip As String) As Data.DataTable
            Dim conn As SqlConnection = New SqlConnection(GetConnectionStringForAppDB())

            Dim myDataAdapter As New SqlDataAdapter
            Dim cmd As New SqlCommand("select retid,descrip from ret where descrip like '%" + descrip + "%'", conn)
            Dim myDataTable As New Data.DataTable

            'Set the select command on the DataAdapter
            myDataAdapter.SelectCommand = cmd

            'Fill the DataTable
            myDataAdapter.Fill(myDataTable)

            Return myDataTable

        End Function

        Public Sub ActivateCloseRetailers(ByVal retid As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "UPDATE ret SET endDt=null  where retid = " + retid.ToString + ""
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub

        Public Sub UpdateReOpenRetailer(ByVal RetId As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "UPDATE ReOpenRetailer SET reopendt = '" + Now().ToString + "' where retid = '" + RetId.ToString + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub

        Public Sub InsertReOpenRetailer(ByVal retid As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "insert into reOpenRetailer (retid,reopendt) values(" + retid.ToString + ",'" + Now.ToString + "')"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub

        Public Function ifreOpenRetailerExist(ByVal retid As Integer) As Boolean
            Dim stringvalue As String
            Dim exist As Boolean = True

            stringvalue = GetFieldValue("select retid from reOpenRetailer where retid=" + retid.ToString, "retid")
            If String.IsNullOrEmpty(stringvalue) Then
                exist = False
            End If
            Return exist
        End Function

        Public Function ifExpectationExist(ByVal mediaid As Integer, ByVal mktid As Integer, ByVal retid As Integer) As String
            Dim stringvalue As String
            Dim exist As Boolean = True

            stringvalue = GetFieldValue("select expectationid from Expectation where enddt is null and mediaid=" + mediaid.ToString + " and mktid=" + mktid.ToString + "and retid=" + retid.ToString, "expectationid")
           
            Return stringvalue
        End Function

        Public Function ifExpectationClosedExist(ByVal mediaid As Integer, ByVal mktid As Integer, ByVal retid As Integer) As String
            Dim stringvalue As String
            Dim exist As Boolean = True

            stringvalue = GetFieldValue("select retid from Expectation where enddt is not null and mediaid=" + mediaid.ToString + " and mktid=" + mktid.ToString + "and retid=" + retid.ToString, "retid")

            Return stringvalue
        End Function


        Public Function InsertExpectation(ByVal mediaid As Integer, ByVal mktid As Integer, ByVal retid As Integer) As Integer

            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim cm As New SqlCommand
            Dim insQry As String = ""
            Dim Expectationid As Integer

            Try

                insQry = "INSERT INTO [Expectation](mediaid,mktid,retid)"
                insQry = insQry & "VALUES (@Mediaid,@Mktid,@Retid);"
                insQry = insQry & "SELECT @newPkId = Expectationid FROM [Expectation] WHERE Expectationid=SCOPE_IDENTITY()"
                con.ConnectionString = GetConnectionStringForAppDB()
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.CommandText = insQry
                cmd.Parameters.AddWithValue("@Mediaid", mediaid)
                cmd.Parameters.AddWithValue("@Mktid", mktid)
                cmd.Parameters.AddWithValue("@Retid", retid)
                cmd.Parameters.AddWithValue("@StartDt", Now())
                cmd.Parameters.AddWithValue("@Priority", 1)
                cmd.Parameters.AddWithValue("@frequencyid", 2078)
                cmd.Parameters.AddWithValue("@ScanDPI", 200)
                Dim param As New SqlParameter("@newPkId", SqlDbType.Int)
                param.Direction = ParameterDirection.Output
                cmd.Parameters.Add(param)
                cmd.ExecuteNonQuery()
                Expectationid = CInt(cmd.Parameters.Item("@newPkId").Value)

            Catch ex As SqlException
                Throw New Exception(ex.Message)
            End Try

            Return Expectationid

        End Function

        Public Function ifSenderExpectationExist(ByVal SenderId As Integer, ByVal Expectationid As Integer) As Boolean
            Dim stringvalue As String
            Dim exist As Boolean = True

            stringvalue = GetFieldValue("select expectationid from SenderExpectation where senderid =" + SenderId.ToString + " and expectationid=" + Expectationid.ToString, "expectationid")
            If String.IsNullOrEmpty(stringvalue) = True Then
                exist = False
            End If
            Return exist
        End Function

        Public Sub InsertSenderExpectation(ByVal SenderId As Integer, ByVal Expectationid As Integer)

            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim cm As New SqlCommand
            Dim insQry As String = ""


            Try

                insQry = "INSERT INTO [SenderExpectation](Senderid,Expectationid)"
                insQry = insQry & "VALUES (@Senderid,@ExpectationID)"
                con.ConnectionString = GetConnectionStringForAppDB()
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.CommandText = insQry
                cmd.Parameters.AddWithValue("@SenderId", SenderId)
                cmd.Parameters.AddWithValue("@ExpectationId", Expectationid)
                'Dim param As New SqlParameter("@newPkId", SqlDbType.Int)
                'param.Direction = ParameterDirection.Output
                'cmd.Parameters.Add(param)
                cmd.ExecuteNonQuery()


            Catch ex As SqlException
                Throw New Exception(ex.Message)
            End Try

        End Sub


    End Class

End Namespace
