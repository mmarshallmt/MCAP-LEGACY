Option Strict Off
Imports ceTe.DynamicPDF.Rasterizer
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.Security.Permissions

Namespace UI.Processors
    Public Class canadaLoad
        Inherits BaseClass

        Public Function ImportDataProcess(ByVal _vehicleId As Object, ByVal _FlyerId As Object, ByVal _IssueComment As Object, ByVal _entryPlatForm As Object, ByVal _reportDueDate As Object, ByVal _market As Object, ByVal _retailer As Object) As String
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object
            Dim msg As String



            cmd = New System.Data.SqlClient.SqlCommand

            Try
                'ImportDataProcess = ValidateRequiredKey(_market, _Page, _advertiser)
                'If ImportDataProcess = "Valid" Then
                With cmd
                    If CStr(_FlyerId.ToString) = "" Then Exit Function
                    .CommandText = "INSERT INTO canadaFR(VehicleId,FlyerId, issueComment, entryPlatform, reportDueDate, Market, REtailer) VALUES('" + _vehicleId.ToString() + "'," + _FlyerId.ToString() + "'," + _IssueComment.ToString + "," + _entryPlatForm.ToString + "," + _reportDueDate.ToString + ",'" + _market.ToString + "','" + _retailer.ToString + "')"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With
                'Else
                'ImportDataProcess = ImportDataProcess.Replace("@FlyerID", _FlyerId.ToString)
                'Exit Function
                'End If
            Catch ex As SqlException
                My.Application.Log.WriteException(ex)

            End Try

        End Function
        Public Function ValidateDate(ByVal dateValue As Date) As String
            Dim isValid As String
            isValid = "yes"
            If dateValue <= Now() Then
                isValid = "no"
            End If
            Return isValid
        End Function

        Private Function ValidateRequiredKey(ByVal _market As Object, ByVal _page As Object, ByVal advertiser As Object) As String
            If _page.ToString = "NULL" Then
                ValidateRequiredKey = "Flyer @FlyerID contains empty Page Count."
            ElseIf advertiser.ToString = "NULL" Then
                ValidateRequiredKey = "Flyer @FlyerID contains an invalid Advertiser."
            ElseIf _market.ToString = "NULL" Then
                ValidateRequiredKey = "Flyer @FlyerID contains an invalid Market."
            Else
                ValidateRequiredKey = "Valid"
            End If
        End Function

        Public Sub UpdateMidWeekData(ByVal _FlyerId As Object)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "UPDATE MidWeekFlash SET isValid = 1 where FlyerId = '" + _FlyerId.ToString + "'"
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

        Public Sub ClearCanadaData()
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "DELETE FROM canadaFR"
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


        Public Function GetMarket(ByVal _descrip As String) As Object
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "Select MktId from Mkt where Descrip = '" + _descrip + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With

                If obj Is Nothing Then
                    obj = "NULL"
                End If

            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return obj
        End Function

        Public Function GetMedia(ByVal _descrip As String) As Object
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "Select MediaId from Media where Descrip = '" + _descrip + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With

                If obj Is Nothing Then
                    obj = "NULL"
                End If
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return obj
        End Function


        Public Function ValidateFlyerIfImported(ByVal _flyer As String) As Object
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "Select count(*) from Vehicle where [Subject] = '" + _flyer + "'"
                    '.CommandText = "update vehicle set subject='' where [Subject]= '" + _flyer + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With

                If obj Is Nothing Then
                    obj = 0
                End If
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return obj
        End Function

        Public Function LoadMidWeekData() As DataSet
            Dim ds As New DataSet
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim adpt As System.Data.SqlClient.SqlDataAdapter
            Try
                cmd = New System.Data.SqlClient.SqlCommand
                With cmd
                    .CommandText = "Select FlyerId,Pages from MidWeekFlash "
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())

                    adpt = New System.Data.SqlClient.SqlDataAdapter(cmd)

                    adpt.Fill(ds)
                End With
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            Return ds
        End Function

        Public Function LoadValidMidWeekData() As DataSet
            Dim ds As New DataSet
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim adpt As System.Data.SqlClient.SqlDataAdapter
            Try
                cmd = New System.Data.SqlClient.SqlCommand
                With cmd
                    .CommandText = "Select FlyerId,Pages,Advertiser,Market,adDate from MidWeekFlash where isValid = 1 "
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())

                    adpt = New System.Data.SqlClient.SqlDataAdapter(cmd)

                    adpt.Fill(ds)
                End With
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            Return ds
        End Function


        Public Function LoadMidWeekDataWithError() As DataSet
            Dim ds As New DataSet
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim adpt As System.Data.SqlClient.SqlDataAdapter
            Try
                cmd = New System.Data.SqlClient.SqlCommand
                With cmd
                    .CommandText = "Select FlyerId,Pages from MidWeekFlash where IsValid = 0"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())

                    adpt = New System.Data.SqlClient.SqlDataAdapter(cmd)

                    adpt.Fill(ds)
                End With
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            Return ds
        End Function

        Public Function CreatEnvelope() As Integer
            Dim obj As Object
            Dim val As Integer
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim cn As System.Data.SqlClient.SqlConnection

            cn = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
            cmd = New System.Data.SqlClient.SqlCommand

            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "mt_proc_GetMidWeekEnvelopeId"
            cmd.Parameters.Add("@EnvelopeId", SqlDbType.Int).Direction = ParameterDirection.Output
            cmd.Parameters.AddWithValue("@LocationId", UserLocationId)
            Dim newRow As Object = cmd.ExecuteScalar()
            Dim envelopId As Integer = Convert.ToInt32(cmd.Parameters("@EnvelopeId").Value)
            If newRow IsNot Nothing Then
                newRow = Convert.ToInt32(newRow)
            End If

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return envelopId
        End Function

        Public Function CreatefamilyId(ByVal retid As Integer) As Integer
            Dim obj As Object
            Dim val As Integer
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim cn As System.Data.SqlClient.SqlConnection

            cn = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
            cmd = New System.Data.SqlClient.SqlCommand

            cn.Open()

            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "mt_proc_GetMidWeekFamilyId"
            cmd.Parameters.Add("@familyId", SqlDbType.Int).Direction = ParameterDirection.Output
            cmd.Parameters.AddWithValue("@retid", retid)
            Dim newRow As Object = cmd.ExecuteScalar()
            Dim familyid As Integer = Convert.ToInt32(cmd.Parameters("@familyId").Value)
            If newRow IsNot Nothing Then
                newRow = Convert.ToInt32(newRow)
            End If

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return familyid
        End Function

        Public Function CreateVehicle(ByVal retid As Integer, ByVal envelopeid As Integer, ByVal mktid As Integer, ByVal flyer As String, ByVal addate As String, ByVal familyid As Integer) As Integer
            Dim obj As Object
            Dim val As Integer

            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim cn As System.Data.SqlClient.SqlConnection

            cn = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
            cmd = New System.Data.SqlClient.SqlCommand
            cn.Open()
            cmd.Connection = cn
            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = "mt_proc_GetMidWeekVehicleId"
            cmd.Parameters.Add("@VehicleId", SqlDbType.Int).Direction = ParameterDirection.Output

            cmd.Parameters.AddWithValue("@RetId", retid)
            cmd.Parameters.AddWithValue("@EnvelopeId", envelopeid)
            cmd.Parameters.AddWithValue("@Location", UserLocationId)
            cmd.Parameters.AddWithValue("@defaultStatusId", retid)
            cmd.Parameters.AddWithValue("@MktId", mktid)
            cmd.Parameters.AddWithValue("@FlyerID", flyer)
            cmd.Parameters.AddWithValue("@addate", addate)
            cmd.Parameters.AddWithValue("@familyid", familyid)

            obj = cmd.ExecuteScalar()

            val = CType(obj, Integer)

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return val
        End Function


        Public Sub CreatPage(ByVal vehicleid As Integer, ByVal page As String, ByVal imagename As String)
            Dim obj As Object
            Dim val As Integer
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim cn As System.Data.SqlClient.SqlConnection

            cn = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
            cmd = New System.Data.SqlClient.SqlCommand

            cn.Open()

            cmd.Connection = cn

            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = "mt_proc_GetMidWeekPageId"

            cmd.Parameters.Add(New SqlParameter("@VehicleId", SqlDbType.Int))
            cmd.Parameters.Add(New SqlParameter("@Page", SqlDbType.VarChar, 7))
            cmd.Parameters.Add(New SqlParameter("@imagename", SqlDbType.VarChar, 50))

            cmd.Parameters(0).Value = vehicleid
            cmd.Parameters(1).Value = page
            cmd.Parameters(2).Value = imagename

            cmd.ExecuteNonQuery()


            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

        End Sub

        Public Sub RemoveExcessPage(ByVal _PageCount As Integer, ByVal _vehicleid As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As New Object
            Dim _val As Integer
            Dim DBPageCount As Integer = GetPagesCount(_vehicleid.ToString)

            For i As Integer = 1 To DBPageCount + 1

                If i >= _PageCount Then
                    cmd = New System.Data.SqlClient.SqlCommand

                    Try
                        With cmd
                            .CommandText = "DELETE FROM PAGE Where VehicleId = " & _vehicleid & " and PageName = '" + i.ToString + "'"
                            .CommandType = CommandType.Text
                            .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                            .Connection.Open()
                            .ExecuteNonQuery()
                        End With
                    Catch ex As Exception
                        ' Throw New ApplicationException("Unable to get the Path Type Id.", ex)
                    Finally
                        If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
                    End Try
                End If
            Next
        End Sub

        Public Function GetPagesCount(ByVal _VehicleId As String) As Integer
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As New Object
            Dim _val As Integer = 0

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "Select Count(*) from Page where VehicleId=" + _VehicleId + ""
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With
                If String.IsNullOrEmpty(CType(obj, String)) = False Then _val = CType(obj, Integer)
            Catch ex As Exception
                'Throw New ApplicationException("Unable to get the Path Type Id.", ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return _val
        End Function

        Public Function CopyToFlashAds() As String
            Dim obj As Object
            Dim val As String
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim cn As System.Data.SqlClient.SqlConnection

            cn = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
            cmd = New System.Data.SqlClient.SqlCommand

            cn.Open()
            cmd.Connection = cn

            cmd.CommandType = CommandType.StoredProcedure

            cmd.CommandText = "sp_MidWeekProcess"

            cmd.Parameters.Add(New SqlParameter("@Status", SqlDbType.VarChar, 1000))

            cmd.Parameters(0).Direction = ParameterDirection.Output

            obj = cmd.ExecuteScalar()

            val = CType(obj, String)

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing


            Return val
        End Function

        Public Function ExportDataToExcel(ByVal ds As DataSet, ByVal originalExcelPath As String) As String

            Dim cnn As SqlConnection
            Dim connectionString As String
            Dim sql As String
            Dim _row As Integer
            Dim x As String = "VehicleId"

            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xlApp = New Excel.ApplicationClass
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = CType(xlWorkBook.Sheets("sheet1"), Worksheet)

            With xlApp
                Dim i As Integer = 1
                For col As Integer = 0 To ds.Tables(0).Columns.Count - 1
                    .Cells(1, i).value = ds.Tables(0).Columns(col).ColumnName
                    .Cells(1, i).EntireRow.Font.Bold = True
                    i += 1
                Next
                i = 2
                Dim j As Integer = 1
                For col As Integer = 0 To ds.Tables(0).Columns.Count - 1
                    i = 2
                    For row As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        .Cells(i, j).Value = ds.Tables(0).Rows(row).ItemArray(col)
                        i += 1
                    Next
                    j += 1
                Next
            End With

            Dim dt As Date = Date.Now

            Dim str As String = Format(dt, "yyyyMMdd")
            Dim xlFileName As String = "MidWeek_Flash_" + str + "_Imported.xlsx"

            Dim fp As New FileIOPermission(FileIOPermissionAccess.AllAccess, originalExcelPath.ToString)
            fp.Assert()

            If Not IO.Directory.Exists(originalExcelPath.ToString) Then
                IO.Directory.CreateDirectory(originalExcelPath.ToString())
            End If
            ' xlWorkSheet.SaveAs(Global.MCAP.My.MySettings.Default.ExportedExcelPath.ToString + xlFileName)

            xlWorkSheet.SaveAs(originalExcelPath.ToString + "\" + xlFileName)
            'xlWorkSheet.SaveAs("C:\midweek\" + xlFileName) '--> this is just for testing

            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)

            'ExportDataToExcel = originalExcelPath.ToString + "\MidWeek_Flash_" + str + "_Imported.xlsx"
            Return originalExcelPath.ToString + "\MidWeek_Flash_" + str + "_Imported.xlsx"

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

        Public Function vehicleIdByFlyerID(ByVal _flyerID As String) As String
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As New Object
            Dim _val As String = ""

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "Select vehicleid from vehicle where subject='" + _flyerID + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With
                If String.IsNullOrEmpty(CType(obj, String)) = False Then _val = CType(obj, String)
            Catch ex As Exception
                'Throw New ApplicationException("Unable to get the Path Type Id.", ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return _val
        End Function

    End Class
End Namespace
