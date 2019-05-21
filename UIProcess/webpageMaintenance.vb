Option Strict Off
Imports ceTe.DynamicPDF.Rasterizer
Imports System.Data.SqlClient
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.Security.Permissions

Namespace UI.Processors
    Public Class webpageMaintenance
        Inherits BaseClass

        Public Function ImportDataProcess(ByVal _Retailer As Object, ByVal _PageName As Object, ByVal _OrderValue As Object, ByVal _URL As Object, ByVal _DAYRUN As Object, ByVal _DefaultPageType As Object, ByVal _FrequencyID As Object) As String
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object
            Dim msg As String

            If _Retailer.ToString <> "" Then
                ImportDataProcess = "Valid"
            End If

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                ' ImportDataProcess = ValidateRequiredKey(_market, _Page, _advertiser)
                If ImportDataProcess = "Valid" Then
                    With cmd

                        .CommandText = "INSERT INTO WebsitePageDownload(Retid,PageName, OrderValue, URL, DayRun, DefaultPageTypeid, frequencyId,ActiveInd) VALUES(" + _Retailer.ToString() + ",'" + _PageName.ToString + "'," + _OrderValue.ToString + ",'" + _URL.ToString + "'," + _DAYRUN.ToString + ",'" + _DefaultPageType.ToString + "'," + _FrequencyID.ToString + ",1)"
                        .CommandType = CommandType.Text
                        .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                        .Connection.Open()
                        .ExecuteNonQuery()
                    End With
                Else
                    ImportDataProcess = "Error on Retailer"
                    Exit Function
                End If
            Catch ex As SqlException
                My.Application.Log.WriteException(ex)

            End Try

        End Function

        Public Function GetRetailerID(ByVal _descrip As String) As Object
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "Select RetId from Ret where Descrip = '" + _descrip + " '"
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

        Public Function GetFrequencyID(ByVal _descrip As String) As Object
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = " Select C.CodeId from Code C INNER JOIN CodeType CT ON CT.CodeTypeId = C.CodeTypeId where C.Descrip = '" + _descrip + "'"
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


        Public Function GetPageTypeId(ByVal _descrip As String) As Object
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = " SELECT PageTypeId FROM PageType where Descrip = '" + _descrip + "'"
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

        Public Function GetPagePositions(ByVal _descrip As String) As Object
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = " SELECT abbr FROM PageType where abbr = '" + _descrip + "'"
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

        Public Function GetPagePageTypeidAbbr(ByVal _descrip As String) As Object
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = " SELECT pagetypeid FROM PageType where descrip like 'Online%' and abbr = '" + _descrip + "'"
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
        Public Sub removeRetailer(ByVal _retid As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "DELETE FROM WebsitePageDownload where ActiveInd=1 and retid=" + _retid.ToString
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

    End Class
End Namespace
