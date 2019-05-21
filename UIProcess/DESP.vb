Imports System.Data.SqlClient
Imports System.IO
Namespace UI.Processors

    Public Class DESP
        Inherits BaseClass


        Public Event StoredProcedureExecutedSuccessfully As MCAPEventHandler


        Private _Data As DESPDataSet


        ''' <summary>
        ''' Gets instance of DESPDataSet.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property Data() As DESPDataSet
            Get
                Return _Data
            End Get
        End Property


        Sub New()

            _Data = New DESPDataSet()

        End Sub



#Region " Methods for loading data in DataSet "


        ''' <summary>
        ''' Loads list of stored procedure and its description.
        ''' </summary>
        ''' <param name="userId"></param>
        ''' <remarks></remarks>
        Public Sub LoadStoredProcedureList(ByVal userId As Integer)
            Dim tempAdapter As DESPDataSetTableAdapters.DESP_StoredProcedureTableAdapter


            tempAdapter = New DESPDataSetTableAdapters.DESP_StoredProcedureTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.FillByUserId(_Data.DESP_StoredProcedure, userId)
            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub

        'Private Sub LoadExtendedProperties(ByVal storedprocedureName As String)
        '  Dim tempAdapter As DESPDataSetTableAdapters.ExtendedPropertyListTableAdapter


        '  tempAdapter = New DESPDataSetTableAdapters.ExtendedPropertyListTableAdapter()
        '  tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '  tempAdapter.Fill(_Data.ExtendedPropertyList, storedprocedureName)
        '  tempAdapter.Dispose()
        '  tempAdapter = Nothing
        'End Sub

        'Private Sub LoadParameters(ByVal storedprocedureName As String)
        '  Dim tempAdapter As DESPDataSetTableAdapters.PARAMETERSTableAdapter


        '  tempAdapter = New DESPDataSetTableAdapters.PARAMETERSTableAdapter()
        '  tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '  tempAdapter.Fill(_Data.PARAMETERS, storedprocedureName)
        '  tempAdapter.Dispose()
        '  tempAdapter = Nothing
        'End Sub

        ''' <summary>
        ''' Loads information about extended properties associated with stored procedure.
        ''' </summary>
        ''' <param name="storedprocedureName"></param>
        ''' <remarks></remarks>
        Public Sub LoadStoredProcedureDetails(ByVal storedprocedureName As String)
            Dim tempAdapter As DESPDataSetTableAdapters.StoredProcedureDetailsTableAdapter


            tempAdapter = New DESPDataSetTableAdapters.StoredProcedureDetailsTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.FillForStoredProcedureOnly(_Data.StoredProcedureDetails, storedprocedureName)
            tempAdapter.Dispose()
            tempAdapter = Nothing
        End Sub

        ''' <summary>
        ''' Loads information for parameters of supplied stored procedure.
        ''' </summary>
        ''' <param name="storedprocedureName"></param>
        ''' <remarks></remarks>
        Public Sub LoadStoredProcedureParameterDetails(ByVal storedprocedureName As String)
            Dim tempAdapter As DESPDataSetTableAdapters.ParameterDetailsTableAdapter


            tempAdapter = New DESPDataSetTableAdapters.ParameterDetailsTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(_Data.ParameterDetails, storedprocedureName)
            tempAdapter.Dispose()
            tempAdapter = Nothing

            _Data.ParameterDetails.Parameter_ValueColumn.SetOrdinal(_Data.ParameterDetails.Columns("Parameter_Name").Ordinal + 1)

        End Sub


#End Region


        ''' <summary>
        ''' Prepares sql command for executing stored procedure.
        ''' </summary>
        ''' <param name="sqlCommand"></param>
        ''' <remarks></remarks>
        Private Sub PrepareSQLCommand(ByVal sqlCommand As System.Data.SqlClient.SqlCommand)
            Dim tempParam As System.Data.SqlClient.SqlParameter
            Dim paramType As System.Data.SqlDbType


            For i As Integer = 0 To _Data.ParameterDetails.Rows.Count - 1
                tempParam = New System.Data.SqlClient.SqlParameter()

                tempParam.ParameterName = _Data.ParameterDetails(i).Parameter_Name
                If (_Data.ParameterDetails(i).Mode = "Input") Then
                    tempParam.Direction = ParameterDirection.Input
                ElseIf (_Data.ParameterDetails(i).Mode = "Output") Then
                    tempParam.Direction = ParameterDirection.InputOutput
                End If

                If System.Enum.IsDefined(paramType.GetType(), _Data.ParameterDetails(i).Data_Type) Then
                    paramType = CType(System.Enum.Parse(paramType.GetType(), _Data.ParameterDetails(i).Data_Type, True), SqlDbType)
                Else
                    Select Case _Data.ParameterDetails(i).Data_Type.ToString().ToLower()
                        Case "bit"
                            paramType = SqlDbType.Bit
                        Case "bigint"
                            paramType = SqlDbType.BigInt
                        Case "int"
                            paramType = SqlDbType.Int
                        Case "smallint"
                            paramType = SqlDbType.SmallInt
                        Case "tinyint"
                            paramType = SqlDbType.TinyInt
                        Case "decimal"
                            paramType = SqlDbType.Decimal
                        Case "numeric"
                            paramType = SqlDbType.Variant
                        Case "money"
                            paramType = SqlDbType.Money
                        Case "smallmoney"
                            paramType = SqlDbType.SmallMoney
                        Case "float"
                            paramType = SqlDbType.Float
                        Case "real"
                            paramType = SqlDbType.Real
                        Case "datetime"
                            paramType = SqlDbType.DateTime
                        Case "smalldatetime"
                            paramType = SqlDbType.SmallDateTime
                        Case "char"
                            paramType = SqlDbType.Char
                        Case "text"
                            paramType = SqlDbType.Text
                        Case "varchar"
                            paramType = SqlDbType.VarChar
                        Case "nchar"
                            paramType = SqlDbType.NChar
                        Case "ntext"
                            paramType = SqlDbType.NText
                        Case "nvarchar"
                            paramType = SqlDbType.NVarChar
                        Case Else
                            paramType = SqlDbType.Variant
                    End Select
                End If

                tempParam.SqlDbType = paramType
                If _Data.ParameterDetails(i).IsData_LengthNull() = False Then
                    tempParam.Size = _Data.ParameterDetails(i).Data_Length
                End If
                If _Data.ParameterDetails(i).IsParameter_ValueNull() Then
                    tempParam.Value = DBNull.Value
                Else
                    tempParam.Value = _Data.ParameterDetails(i).Parameter_Value
                End If

                sqlCommand.Parameters.Add(tempParam)

                tempParam = Nothing
            Next

            paramType = Nothing

        End Sub

        ''' <summary>
        ''' Logs execution of stored procedure in DESP_ExecutionLog table.
        ''' </summary>
        ''' <param name="storedprocedureId"></param>
        ''' <param name="parameters"></param>
        ''' <remarks></remarks>
        Private Sub LogDESPExecution(ByVal storedprocedureId As Integer, ByVal parameters As System.Data.SqlClient.SqlParameterCollection)
            Dim paramText As System.Text.StringBuilder
            Dim tempAdapter As DESPDataSetTableAdapters.DESP_ExecutionLogTableAdapter
            Dim tempRow As DESPDataSet.DESP_ExecutionLogRow


            paramText = New System.Text.StringBuilder()
            For i As Integer = 0 To parameters.Count - 1
                paramText.Append(parameters(i).ParameterName)
                paramText.Append("=")
                paramText.Append(parameters(i).Value)
                paramText.Append(";")
            Next

            If paramText.Length > 1000 Then
                paramText.Remove(997, paramText.Length - 997)
                paramText.Append("...")
            End If

            tempRow = Me.Data.DESP_ExecutionLog.NewDESP_ExecutionLogRow()
            tempRow.StoredProcedureId = storedprocedureId
            tempRow.RunDt = DateTime.Now  'This value is set while inserting row using GETDATE().
            tempRow.UserName = Username
            tempRow.Parameters = paramText.ToString()
            Me.Data.DESP_ExecutionLog.AddDESP_ExecutionLogRow(tempRow)
            tempRow = Nothing
            paramText = Nothing

            tempAdapter = New DESPDataSetTableAdapters.DESP_ExecutionLogTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Update(Me.Data.DESP_ExecutionLog)
            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub

        ''' <summary>
        ''' Prepares and executes sql command for supplied stored procedure.
        ''' </summary>
        ''' <param name="storedprocedureId"></param>
        ''' <param name="storedprocedureName"></param>
        ''' <remarks></remarks>
        Public Sub ExecuteStoredProcedure(ByVal storedprocedureId As Integer, ByVal storedprocedureName As String)
            Dim tempConn As System.Data.SqlClient.SqlConnection
            Dim tempAdapter As System.Data.SqlClient.SqlDataAdapter
            Dim tempCmd As System.Data.SqlClient.SqlCommand
            Dim resultDataSet As System.Data.DataSet


            tempConn = New System.Data.SqlClient.SqlConnection()
            tempAdapter = New System.Data.SqlClient.SqlDataAdapter()
            tempCmd = New System.Data.SqlClient.SqlCommand()
            resultDataSet = New System.Data.DataSet("ResultsDataSet")

            tempConn.ConnectionString = GetConnectionStringForAppDB()
            tempCmd.Connection = tempConn
            tempCmd.CommandText = storedprocedureName
            tempCmd.CommandType = CommandType.StoredProcedure
            PrepareSQLCommand(tempCmd)

            tempAdapter.SelectCommand = tempCmd

            Try
                tempAdapter.Fill(resultDataSet)
                LogDESPExecution(storedprocedureId, tempCmd.Parameters)
            Catch ex As SqlClient.SqlException When tempConn.State <> ConnectionState.Open
                Throw New ApplicationException("Unable to connect with database.", ex)
            Catch ex As SqlClient.SqlException
                Throw New ApplicationException("Error has occurred while executing stored procedure.", ex)
            Catch ex As Exception
                Throw
            Finally
                If tempConn.State <> ConnectionState.Closed Then tempConn.Close()
                tempConn.Dispose()
                tempCmd.Dispose()
                tempAdapter.Dispose()
                If storedprocedureName = "mt_proc_DESP_Prep_Vehicle_for_Image_Change" Then
                    RenameImage()
                End If
            End Try

            tempCmd = Nothing
            tempAdapter = Nothing
            tempConn = Nothing


            Using e As New MCAP.UI.Processors.EventArgs
                e.Data.Add("ResultsDataSet", resultDataSet)
                RaiseEvent StoredProcedureExecutedSuccessfully(Me, e)
            End Using

            resultDataSet.Dispose()
            resultDataSet = Nothing

        End Sub

#Region "Image Renaming"
        Private Function GetPreviousPageList() As DataSet
            Dim cmd As SqlCommand
            Dim adpt As SqlDataAdapter
            Dim ds As New DataSet()
            Dim strCommand As String = "Select * from tmp_page"
            Dim strcon As New SqlConnection
            Try
                cmd = New SqlCommand
                strcon = New SqlConnection
                strcon.ConnectionString = GetConnectionStringForAppDB()
                cmd.Connection = strcon
                cmd.Connection.Open()
                If cmd.Connection.State = ConnectionState.Closed Then
                    cmd.Connection.Open()
                End If
                cmd.CommandType = CommandType.Text

                cmd.CommandText = strCommand

                adpt = New SqlDataAdapter(cmd)

                adpt.Fill(ds)

                If cmd.Connection.State = ConnectionState.Open Then
                    cmd.Connection.Close()
                End If
                cmd = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Return ds
        End Function
        Private Function GetImagePath(ByVal YearMonth As String, ByVal LocationId As Integer, ByVal PathType As Integer) As String
            Dim imgPathCommand As System.Data.SqlClient.SqlCommand
            Dim obj As Object
            Dim Path As System.Text.StringBuilder


            imgPathCommand = New System.Data.SqlClient.SqlCommand
            Path = New System.Text.StringBuilder

            Try
                With imgPathCommand
                    .CommandText = "SELECT path FROM ImagePath WHERE yearmonth=" + YearMonth + " AND LocationId=" + LocationId.ToString + " AND PathTypeid=" + PathType.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With
                If String.IsNullOrEmpty(CType(obj, String)) = True Then Exit Function
                Path.Append(CType(obj, String))
                Path.Append("\")
                Path.Append(YearMonth)
                Path.Append("\")
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If imgPathCommand.Connection.State <> ConnectionState.Closed Then imgPathCommand.Connection.Close()
            End Try

            Return Path.ToString()
        End Function
        Private Function GetCreateDtByVehicleId(ByVal vehicleId As Integer) As String
            Dim imgPathCommand As System.Data.SqlClient.SqlCommand
            Dim obj As Object
            Dim _date As String


            imgPathCommand = New System.Data.SqlClient.SqlCommand


            Try
                With imgPathCommand
                    .CommandText = "SELECT      vwCircular.CreateDt " + _
                                       "FROM vwCircular LEFT OUTER JOIN " + _
                                       "vwVehicleStatus ON vwCircular.StatusID = vwVehicleStatus.CodeId LEFT OUTER JOIN " + _
                                       "vwSPReviewStatus AS SPRS ON vwCircular.SPReviewStatusId = SPRS.CodeId " + _
                                       "WHERE     (vwCircular.VehicleId = " + vehicleId.ToString + ") AND (vwVehicleStatus.Descrip IS NULL OR " + _
                                       "vwVehicleStatus.Descrip IN ('Review', 'Indexed', 'QC Completed'))"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With
                If String.IsNullOrEmpty(CType(obj, String)) = True Then Exit Function

                _date = CType(obj, String)

            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If imgPathCommand.Connection.State <> ConnectionState.Closed Then imgPathCommand.Connection.Close()
            End Try

            Return _date
        End Function
        Private Function GetPathType(ByVal _Type As String) As Integer
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As New Object
            Dim _val As Integer

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "Select codeid from vwCode where codedescrip='" + _Type + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With
                If String.IsNullOrEmpty(CType(obj, String)) = False Then _val = CType(obj, Integer)
            Catch ex As Exception
                Throw New ApplicationException("Unable to get the Path Type Id.", ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return _val
        End Function
        Private Sub RenameImage()
            Dim localDS As DataSet = GetPreviousPageList()
            Dim CreatedDt As Date
            Dim _path As String
            Dim pgOrder As Integer
            Dim _newname As String

            If localDS.Tables(0).Rows.Count > 0 Then
                For ctr As Integer = 0 To localDS.Tables(0).Rows.Count - 1
                    pgOrder = CType(localDS.Tables(0).Rows(ctr).Item(2), Integer)
                    _newname = Format(pgOrder, "000")

                    CreatedDt = CDate(GetCreateDtByVehicleId(CType(localDS.Tables(0).Rows(ctr).Item(0), Integer)))
                    _path = GetImagePath(CreatedDt.ToString("yyyyMM"), UserLocationId, GetPathType("Master"))
                    _path = _path + CType(localDS.Tables(0).Rows(ctr).Item(0), String) + "\Unsized\" + localDS.Tables(0).Rows(ctr).Item(1).ToString + ".jpg"
                    If File.Exists(_path) Then
                        My.Computer.FileSystem.RenameFile(_path, _newname + ".jpg")
                    End If
                Next
            End If
        End Sub
#End Region
    End Class

End Namespace