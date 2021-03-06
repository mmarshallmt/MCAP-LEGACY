﻿Imports System.Data.SqlClient
Imports System.Configuration
Public Class clsFaceBook
#Region "Private Variables"
    Private _Priority As Integer
    Private _Descrip As String
    Private _crawlId As Integer
    Private _retid As Integer
    Private _cnString As String
    Private _cnSocialString As String
    Private objclsExpectation As clsFaceBook
#End Region

#Region "Constructor"
    Public Sub New()
        _Priority = 0
        _crawlId = 0
        _retid = 0
        '_cnString = ConfigurationManager.ConnectionStrings("MySettings.QSCSConnectionString").ConnectionString
        '_cnString = My.Settings.socialMediaConnectionString
        _cnString = GetConnectionStringForAppDB()
        _cnSocialString = GetConnectionStringForSocialDB()
    End Sub
#End Region

#Region "Public Properties"
    Public Property RetId() As Integer
        Get
            Return _retid
        End Get
        Set(value As Integer)
            _retid = value
        End Set
    End Property

    Public Property Priority() As Integer
        Get
            Return _Priority
        End Get
        Set(value As Integer)
            _Priority = value
        End Set
    End Property

    Public Property CrawlId() As Integer
        Get
            Return _crawlId
        End Get
        Set(value As Integer)
            _crawlId = value
        End Set
    End Property

    Public Property Descrip() As String
        Get
            Return _Descrip
        End Get
        Set(value As String)
            _Descrip = value
        End Set
    End Property

    Public Property cnString() As String
        Get
            Return _cnString
        End Get
        Set(value As String)
            _cnString = value
        End Set
    End Property

#End Region

    Public Overloads Function GetFaceBooks() As DataSet
        Return GetFaceBooks("retid")
    End Function
    Public Overloads Function GetTwitters() As DataSet
        Return GetTwitters("retid")
    End Function

    Public Overloads Function GetFaceBooks(ByVal sortfield As String) As DataSet
        Dim conn As New SqlConnection
        conn = New SqlConnection(_cnSocialString)
        Try
            Dim ds As New DataSet
            'sqlQuery = 
            '
            Dim sql As String = "SELECT retid,pageurl,cast(crawl as int) as crawl,cast(Enabled as int) as Enabled ,loginId ,cast(layoutType as int)"
            sql = sql & " as layoutType, PostDate, LastProcessDatetime, FreqInMin, Priority,id FROM facebookinputdata order by " + sortfield
            Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)

            Try
                da.Fill(ds, "facebookInputdata")
            Finally
                da.Dispose()
            End Try

            Return ds
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Function
    Public Overloads Function GetTwitters(ByVal sortfield As String) As DataSet
        Dim conn As New SqlConnection
        conn = New SqlConnection(_cnSocialString)
        Try
            Dim ds As New DataSet
            'Dim Sql As String = "SELECT * FROM Twitterinputdata order by " + sortfield
            Dim sql As String = "SELECT retid,pageurl,cast(crawl as int) as crawl,StartUrl,cast(Enabled as int) as Enabled ,loginId ,"
            sql = sql & "LastProcessDatetime, FreqInMin, Priority,id FROM Twitterinputdata order by " + sortfield
            Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)

            Try
                da.Fill(ds, "twitterInputdata")
            Finally
                da.Dispose()
            End Try

            Return ds
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Function

    Public Function GetFaceBook(ByVal id As Integer) As DataSet
        'Return a dataset representing a single Currency
        Dim conn As New SqlConnection
        conn = New SqlConnection(_cnSocialString)

        Try
            Dim sSql As String = "Select * from facebookInputdata where id = " & id.ToString
            Dim sa As SqlDataAdapter = New SqlDataAdapter(sSql, conn)
            Dim ds As New DataSet

            Try
                sa.Fill(ds, "facebookInputdata")
            Finally
                sa.Dispose()
            End Try
            Return ds

        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Function


    Public Sub SaveFaceBooks(ByVal ds As DataSet)

        Dim conn As New SqlConnection
        conn = New SqlConnection(_cnSocialString)

        Try
            Dim sql As String = "SELECT retid,pageurl,cast(crawl as Bit) as crawl,cast(Enabled as Bit) as Enabled ,loginId ,cast(layoutType as int)"
            sql = sql & " as layoutType, PostDate, LastProcessDatetime, FreqInMin, Priority,id FROM facebookinputdata"
            Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)

            Try
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                If ds.HasChanges Then
                    da.Update(ds, "facebookInputdata")
                    ds.AcceptChanges()
                End If
            Finally
                da.Dispose()
            End Try

        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

    Public Sub SaveTwitters(ByVal ds As DataSet)

        Dim conn As New SqlConnection
        conn = New SqlConnection(_cnSocialString)

        Try
            Dim sql As String = "SELECT retid,pageurl,cast(crawl as Bit) as crawl,cast(Enabled as Bit) as Enabled,loginId, LastProcessDatetime, FreqInMin, Priority,id   from twitterInputdata"
            'Dim sql As String = "SELECT * from twitterInputdata"
            Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)

            Try
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                If ds.HasChanges Then

                    da.Update(ds, "twitterInputdata")
                    ds.AcceptChanges()
                End If
            Finally
                da.Dispose()
            End Try

        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub

    'Public Sub SaveFaceBook(ByVal ds As DataSet)
    '    'Update a dataset representing Currencys
    '    Dim conn As New SqlConnection
    '    conn = New SqlConnection(_cnSocialString)

    '    Try
    '        'Dim sql As String = "SELECT retid,pageurl,cast(crawl as int) as crawl,cast(Enabled as int) as Enabled ,loginId ,cast(layoutType as int)"
    '        'sql = sql & " as layoutType, PostDate, LastProcessDatetime, FreqInMin, Priority,id FROM facebookinputdata"
    '        Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)

    '        Try
    '            Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
    '            If ds.HasChanges Then
    '                da.Update(ds, "facebookInputdata")
    '                ds.AcceptChanges()
    '            End If
    '        Finally
    '            da.Dispose()
    '        End Try

    '    Finally
    '        conn.Close()
    '        conn.Dispose()
    '    End Try

    'End Sub

    Public Function LoadCrawlOptions() As List(Of clsFaceBook)
        Dim optionsArray(2) As String
        Dim objRet As New List(Of clsFaceBook)()
        optionsArray = New String() {"False", "True"}

        For i As Integer = 0 To optionsArray.Length - 1
            Dim objRec As New clsFaceBook()
            objRec.CrawlId = CByte(i)
            objRec.Descrip = optionsArray(i)
            objRet.Add(objRec)
        Next

        Return objRet
    End Function

    Public Function LoadYesNoForMediaOptions() As List(Of clsFaceBook)
        Dim optionsArray(2) As String
        Dim objRet As New List(Of clsFaceBook)()
        optionsArray = New String() {"Yes", "No"}

        For i As Integer = 0 To optionsArray.Length - 1
            Dim objRec As New clsFaceBook()
            objRec.CrawlId = i
            objRec.Descrip = optionsArray(i)
            objRet.Add(objRec)
        Next

        Return objRet
    End Function

    Public Function LoadEnabledOptions() As List(Of clsFaceBook)
        Dim optionsArray(2) As String
        Dim objRet As New List(Of clsFaceBook)()
        optionsArray = New String() {"False", "True"}

        For i As Integer = 0 To optionsArray.Length - 1
            Dim objRec As New clsFaceBook()
            objRec.Priority = i

            objRec.Descrip = optionsArray(i)
            objRet.Add(objRec)
        Next

        Return objRet
    End Function

    Public Function LoadLayoutTypeOptions() As List(Of clsFaceBook)

        Dim objRet As New List(Of clsFaceBook)()


        For i As Integer = 1 To 2
            Dim objRec As New clsFaceBook()
            objRec.Priority = i
            objRec.Descrip = i.ToString
            objRet.Add(objRec)
        Next

        Return objRet
    End Function

    Public Function GetLoginId() As List(Of clsFaceBook)
        Dim objRet As New List(Of clsFaceBook)()
        Using objCnn As New SqlConnection(_cnSocialString)
            objCnn.Open()
            Using objCmd As SqlCommand = objCnn.CreateCommand()
                objCmd.CommandType = System.Data.CommandType.Text
                objCmd.CommandText = "Select DISTINCT loginid,userName from SocialMediaLoginInfo order by username asc"
                Using objDR As SqlDataReader = objCmd.ExecuteReader()
                    While objDR.Read()
                        Dim objRec As New clsFaceBook()

                        If objDR.IsDBNull(objDR.GetOrdinal("loginid")) Then
                            objRec.Priority = 0
                        Else
                            objRec.Priority = objDR.GetInt32(objDR.GetOrdinal("loginid"))
                        End If

                        If objDR.IsDBNull(objDR.GetOrdinal("userName")) Then
                            objRec.Descrip = ""
                        Else
                            objRec.Descrip = objDR.GetString(objDR.GetOrdinal("userName"))
                        End If
                        objRet.Add(objRec)
                    End While
                End Using
            End Using
        End Using
        Return objRet
    End Function

    Public Function GetRetailer() As List(Of clsFaceBook)
        Dim objRet As New List(Of clsFaceBook)()
        Using objCnn As New SqlConnection(_cnString)
            objCnn.Open()
            Using objCmd As SqlCommand = objCnn.CreateCommand()
                objCmd.CommandType = System.Data.CommandType.Text
                objCmd.CommandText = "Select retid,descrip from Ret where Ret.EndDt is Null order by descrip asc"
                Using objDR As SqlDataReader = objCmd.ExecuteReader()
                    While objDR.Read()
                        Dim objRec As New clsFaceBook()

                        If objDR.IsDBNull(objDR.GetOrdinal("RetId")) Then
                            objRec.RetId = 0
                        Else
                            objRec.RetId = objDR.GetInt32(objDR.GetOrdinal("RetId"))
                        End If

                        If objDR.IsDBNull(objDR.GetOrdinal("Descrip")) Then
                            objRec.Descrip = ""
                        Else
                            objRec.Descrip = objDR.GetString(objDR.GetOrdinal("Descrip"))
                        End If
                        objRet.Add(objRec)
                    End While
                End Using
            End Using
        End Using
        Return objRet
    End Function

End Class
