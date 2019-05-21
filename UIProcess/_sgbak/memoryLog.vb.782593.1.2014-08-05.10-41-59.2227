Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Data

Public Class memoryLog

#Region "Constructor"
    Public Sub New()
    End Sub
#End Region

#Region "Private Variables"
    Private _pk As Integer
    Private _userid As Integer
    Private _dateError As System.DateTime
    Private _Image As String
    Private objclsoutOfMemoryLog As memoryLog
#End Region

#Region "Public Properties"
    Public Property pk() As Integer
        Get
            Return _pk
        End Get
        Set(ByVal value As Integer)
            _pk = value
        End Set
    End Property
    Public Property userid() As Integer
        Get
            Return _userid
        End Get
        Set(ByVal value As Integer)
            _userid = value
        End Set
    End Property
    Public Property dateError() As System.DateTime
        Get
            Return _dateError
        End Get
        Set(ByVal value As System.DateTime)
            _dateError = value
        End Set
    End Property

    Public Property Image() As String
        Get
            Return _Image
        End Get
        Set(ByVal value As String)
            _Image = value
        End Set
    End Property
#End Region
#Region "Public Methods"
   
  

    Public Function Insert() As Boolean

        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim cm As New SqlCommand


        Try

            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()
            cmd.Connection = con
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "INSERT INTO [outOfMemoryLog]([userid],[dateError],[image]) VALUES (@userid,@dateError,@image); SELECT @newPkId = Pk FROM outOfMemoryLog WHERE Pk=SCOPE_IDENTITY()"
            cmd.Parameters.AddWithValue("@userid", Me.userid)
            cmd.Parameters.AddWithValue("@dateError", Me.dateError)
            cmd.Parameters.AddWithValue("@image", Me.Image)
            Dim param As New SqlParameter("@newPkId", SqlDbType.Int)
            param.Direction = ParameterDirection.Output
            cmd.Parameters.Add(param)
            cmd.ExecuteNonQuery()
            Me.pk = CInt(cmd.Parameters.Item("@newPkId").Value)

        Catch ex As SqlException
            Throw New Exception(ex.Message)
        End Try

        Return False
       
    End Function
    Public Function Update() As Boolean
        Try
            'Dim Params As SqlParameter() = {New SqlParameter("@pk", pk), New SqlParameter("@userid", userid), New SqlParameter("@dateError", dateError)}
            'Dim result As Integer = SqlHelper.ExecuteNonQuery(Transaction, CommandType.StoredProcedure, "SP_outOfMemoryLog_Update", Params)
            'If result > 0 Then
            '    Return True
            'End If
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
   
#End Region

End Class
