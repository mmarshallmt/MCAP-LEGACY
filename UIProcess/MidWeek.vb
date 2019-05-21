﻿Option Strict Off
Imports ceTe.DynamicPDF.Rasterizer
Imports System.Data.SqlClient
Imports Scripting
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.Security.Permissions

Namespace UI.Processors

    Public Class MidWeek
        Inherits BaseClass
        Public Function ImportDataProcess(ByVal _FlyerId As Object, ByVal _Page As Object, ByVal _tradeClass As Object, ByVal _advertiser As Object, ByVal _addate As Object, ByVal _weekof As Object, ByVal _market As Object, ByVal _media As Object, ByVal _retmkitid As Object) As String
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object
            Dim msg As String



            cmd = New System.Data.SqlClient.SqlCommand

            Try
                ImportDataProcess = ValidateRequiredKey(_market, _Page, _advertiser)
                If ImportDataProcess = "Valid" Then
                    With cmd
                        If CStr(_FlyerId.ToString) = "" Then Exit Function
                        .CommandText = "INSERT INTO MidWeekFlash(FlyerId, Pages, TradeClass, Advertiser, AdDate, WeekOf,Market, Media,RetMktId) VALUES('" + _FlyerId.ToString() + "'," + _Page.ToString + "," + _tradeClass.ToString + "," + _advertiser.ToString + ",'" + _addate.ToString + "','" + _weekof.ToString + "'," + _market.ToString + "," + _media.ToString + "," + _retmkitid.ToString + ")"
                        .CommandType = CommandType.Text
                        .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                        .Connection.Open()
                        .ExecuteNonQuery()
                    End With
                Else
                    ImportDataProcess = ImportDataProcess.Replace("@FlyerID", _FlyerId.ToString)
                    Exit Function
                End If
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

        Public Sub ClearMidWeekData()
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "DELETE FROM MidWeekFlash"
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

        Public Function GetAdvertiserID(ByVal _descrip As String) As Object
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "Select RetId from Ret where Descrip = '" + _descrip + " - MW'"
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

        Public Function GetTradeClass(ByVal _descrip As String) As Object
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "Select TradeClassId from TradeClass where Descrip = '" + _descrip + "'"
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

        'validate the total count of images in the folder path
        Public Function ValidatePageCount(ByVal _path As String, ByVal _expectedcount As Integer) As Boolean
            Dim Files() As String

            Files = IO.Directory.GetFiles(_path, "*.jpg", IO.SearchOption.AllDirectories)

            If Files.Length = _expectedcount Then
                Return True
            Else
                Return False
            End If

        End Function

        'validate if images are standardized in the path
        Public Function ValidateImagePagesExist(ByVal _path As String, ByVal _expectedcount As Integer) As String
            Dim i As Integer
            Dim returnImages As String
            If IO.Directory.Exists(_path) Then
                For i = 1 To JPGExist(_path)
                    If IO.File.Exists(_path + "\" + i.ToString("000") + ".jpg") = False Then
                        returnImages = returnImages + i.ToString("000") + ".jpg" + ", "
                    End If
                Next
            End If
            Return returnImages
        End Function

        'validate if images are existing in the path
        Public Function ValidateImage(ByVal _path As String) As Boolean

            If IO.File.Exists(_path) Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function PDFExist(ByVal _path As String) As Boolean
            Dim Files() As String

            Files = IO.Directory.GetFiles(_path, "*.pdf", IO.SearchOption.AllDirectories)

            If Files.Length > 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function GIFExist(ByVal _path As String) As Integer
            Dim Files() As String

            Files = IO.Directory.GetFiles(_path, "*.gif", IO.SearchOption.AllDirectories)

            Return Files.Length
        End Function

        Public Function BMPExist(ByVal _path As String) As Integer
            Dim Files() As String

            Files = IO.Directory.GetFiles(_path, "*.bmp", IO.SearchOption.AllDirectories)

            Return Files.Length
        End Function

        Public Function PNGExist(ByVal _path As String) As Integer
            Dim Files() As String

            Files = IO.Directory.GetFiles(_path, "*.png", IO.SearchOption.AllDirectories)

            Return Files.Length
        End Function

        Public Function JPGExist(ByVal _path As String) As Integer
            Dim Files() As String

            Files = IO.Directory.GetFiles(_path, "*.jpg", IO.SearchOption.AllDirectories)

            Return Files.Length
        End Function

        Public Function PDFConvertion(ByVal filename As String, ByVal _path As String, ByVal _expectedcount As Integer) As Boolean
            Try
                Dim myPDFConvert As PdfRasterizer = New PdfRasterizer(filename)
                myPDFConvert.Draw(_path + "\0.jpg", ImageFormat.Jpeg, ImageSize.Dpi72)

                For i As Integer = 1 To _expectedcount
                    If i = 1 Then
                        My.Computer.FileSystem.RenameFile(_path + "\0.jpg", i.ToString("000") + ".jpg")
                    ElseIf i < 10 Then
                        My.Computer.FileSystem.RenameFile(_path + "\" + i.ToString("00") + ".jpg", i.ToString("000") + ".jpg")
                    End If
                Next
                PDFConvertion = True
                CoerceGarbageCollection(myPDFConvert)
            Catch ex As PdfRasterizerException
                'Console.WriteLine(ex.Message)
                MsgBox(ex.Message)
                PDFConvertion = False
            End Try
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


        Public Function ConvertToJPG(ByVal ExeFile As String, ByVal gifDestImage As String, ByVal ratio As String, ByVal DestImage As String) As Boolean
            Dim p As New ProcessStartInfo
            Try
                p.FileName = ExeFile
                Dim x As String = """" + gifDestImage + """ """ + ratio + """ """ + DestImage + """"
                p.Arguments = x

                Dim pr As Process = Process.Start(p)

                pr.WaitForExit()
                ConvertToJPG = True
            Catch
                ConvertToJPG = False
            End Try
        End Function

        Public Function CopyImageToServer(ByVal _path As String, ByVal _source As String) As Integer
            Dim i As Integer
            If IO.Directory.Exists(_path) Then
                For i = 1 To JPGExist(_source)
                    If IO.File.Exists(_path + "\" + i.ToString("000") + ".jpg") = False Then
                        IO.File.Copy(_source + "\" + i.ToString("000") + ".jpg", _path + "\" + i.ToString("000") + ".jpg")
                    End If
                Next
            Else

                IO.Directory.CreateDirectory(_path)

                For i = 1 To JPGExist(_source)
                    IO.File.Copy(_source + "\" + i.ToString("000") + ".jpg", _path + "\" + i.ToString("000") + ".jpg")
                Next
            End If

            CopyImageToServer = i - 1
        End Function

        Public Function RetrieveYearMonth(ByVal _vehicleid As Integer) As String
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object
            Dim dt As Date
            Dim FVal As String

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "Select CreateDt from Vehicle where VehicleId = " & _vehicleid
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With

                If obj Is Nothing Then
                    obj = "NULL"
                Else
                    dt = CType(obj, Date)
                    FVal = dt.ToString("yyyyMM")
                End If
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return FVal
        End Function

        Public Function GetImagePath(ByVal YearMonth As String, ByVal PathType As Integer) As String
            Dim imgPathCommand As System.Data.SqlClient.SqlCommand
            Dim obj As Object
            Dim Path As System.Text.StringBuilder


            imgPathCommand = New System.Data.SqlClient.SqlCommand
            Path = New System.Text.StringBuilder

            Try
                With imgPathCommand
                    .CommandText = "SELECT path FROM ImagePath WHERE yearmonth=" + YearMonth + " AND LocationId=" & CDbl(UserLocationId) & " AND PathTypeid=" + PathType.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With

                Path.Append(CType(obj, String))

            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If imgPathCommand.Connection.State <> ConnectionState.Closed Then imgPathCommand.Connection.Close()
            End Try

            Return Path.ToString()
        End Function

        Public Function GetPathType(ByVal _Type As String) As Integer
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
                'Throw New ApplicationException("Unable to get the Path Type Id.", ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return _val
        End Function

        Public Sub CoerceGarbageCollection(Optional ByVal disposed As Object = Nothing)
            If Not IsNothing(disposed) Then
                GC.SuppressFinalize(disposed)
            End If
            GC.Collect(GC.MaxGeneration)
            GC.WaitForPendingFinalizers()
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

        Public Function LoadCreatedVehicle(ByVal _valuecondition As String) As DataSet
            Dim ds As New DataSet
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim adpt As System.Data.SqlClient.SqlDataAdapter
            Try
                cmd = New System.Data.SqlClient.SqlCommand
                With cmd
                    .CommandText = "select v.vehicleid as VehicleID, v.Subject as FlyerId, r.descrip as Advertiser, m.descrip as Market, v.breakdt as AdDate, C.Descrip AS VehicleStatus from Vehicle as v INNER JOIN Ret as r ON v.RetId = r.RetId INNER JOIN Mkt as m ON v.MktId = m.MktId inner join Code AS C ON v.StatusID = C.CodeId WHERE v.VehicleId in(" + _valuecondition + ")"
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
    End Class

End Namespace