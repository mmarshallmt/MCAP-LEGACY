Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Data


Public Class clsoutOfMemoryLogController

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
        Try
            objclsoutOfMemoryLog = New memoryLog()

            objclsoutOfMemoryLog.userid = userid
            objclsoutOfMemoryLog.dateError = dateError
            objclsoutOfMemoryLog.Image = Image

            If objclsoutOfMemoryLog.Insert() Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function Update() As Boolean
        Try
            objclsoutOfMemoryLog = New memoryLog()

            objclsoutOfMemoryLog.pk = pk
            objclsoutOfMemoryLog.userid = userid
            objclsoutOfMemoryLog.dateError = dateError

            If objclsoutOfMemoryLog.Update() Then
                Return True
            End If
            Return False
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    
#End Region


End Class
