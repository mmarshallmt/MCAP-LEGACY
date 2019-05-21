
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports MCAP.DatabaseLayer

Namespace BusinessLayer
    Public Class clsRetController

#Region "Constructor"
        Public Sub New()
        End Sub
#End Region

#Region "Private Variables"
        Private _RetId As Integer
        Private _Descrip As String
        Private _TradeClassId As Integer
        Private _StartDt As System.DateTime
        Private _EndDt As System.DateTime
        Private _Priority As Integer
        Private _LanguageId As Integer
        Private _DisplayDescrip As String
        Private _RetAddress As String
        Private _RetCity As String
        Private _RetZip As String
        Private _TDLinkxNumber As String
        Private _RetState As String
        Private _BaseURL As String
        Private objclsRet As DatabaseLayer.clsRet
#End Region

#Region "Public Properties"
        Public Property RetId() As Integer
            Get
                Return _RetId
            End Get
            Set(value As Integer)
                _RetId = value
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
        Public Property TradeClassId() As Integer
            Get
                Return _TradeClassId
            End Get
            Set(value As Integer)
                _TradeClassId = value
            End Set
        End Property
        Public Property StartDt() As System.DateTime
            Get
                Return _StartDt
            End Get
            Set(value As System.DateTime)
                _StartDt = value
            End Set
        End Property
        Public Property EndDt() As System.DateTime
            Get
                Return _EndDt
            End Get
            Set(value As System.DateTime)
                _EndDt = value
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
        Public Property LanguageId() As Integer
            Get
                Return _LanguageId
            End Get
            Set(value As Integer)
                _LanguageId = value
            End Set
        End Property
        Public Property DisplayDescrip() As String
            Get
                Return _DisplayDescrip
            End Get
            Set(value As String)
                _DisplayDescrip = value
            End Set
        End Property
        Public Property RetAddress() As String
            Get
                Return _RetAddress
            End Get
            Set(value As String)
                _RetAddress = value
            End Set
        End Property
        Public Property RetCity() As String
            Get
                Return _RetCity
            End Get
            Set(value As String)
                _RetCity = value
            End Set
        End Property
        Public Property RetZip() As String
            Get
                Return _RetZip
            End Get
            Set(value As String)
                _RetZip = value
            End Set
        End Property
        Public Property TDLinkxNumber() As String
            Get
                Return _TDLinkxNumber
            End Get
            Set(value As String)
                _TDLinkxNumber = value
            End Set
        End Property
        Public Property RetState() As String
            Get
                Return _RetState
            End Get
            Set(value As String)
                _RetState = value
            End Set
        End Property
        Public Property BaseURL() As String
            Get
                Return _BaseURL
            End Get
            Set(value As String)
                _BaseURL = value
            End Set
        End Property
#End Region

#Region "Public Methods"
        'Public Function [Select]() As DataTable
        '    Dim dt As DataTable
        '    Try
        '        objclsRet = New clsRet()

        '        objclsRet.RetId = RetId

        '        dt = objclsRet.[Select]()
        '        Return dt
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message)
        '    End Try
        'End Function
        'Public Function Insert() As Boolean
        '    Try
        '        objclsRet = New clsRet()

        '        objclsRet.Descrip = Descrip
        '        objclsRet.TradeClassId = TradeClassId
        '        objclsRet.StartDt = StartDt
        '        objclsRet.EndDt = EndDt
        '        objclsRet.Priority = Priority
        '        objclsRet.LanguageId = LanguageId
        '        objclsRet.DisplayDescrip = DisplayDescrip
        '        objclsRet.RetAddress = RetAddress
        '        objclsRet.RetCity = RetCity
        '        objclsRet.RetZip = RetZip
        '        objclsRet.TDLinkxNumber = TDLinkxNumber
        '        objclsRet.RetState = RetState
        '        objclsRet.BaseURL = BaseURL

        '        If objclsRet.Insert() Then
        '            Return True
        '        End If
        '        Return False
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message)
        '    End Try
        'End Function
        'Public Function Update() As Boolean
        '    Try
        '        objclsRet = New clsRet()

        '        objclsRet.RetId = RetId
        '        objclsRet.Descrip = Descrip
        '        objclsRet.TradeClassId = TradeClassId
        '        objclsRet.StartDt = StartDt
        '        objclsRet.EndDt = EndDt
        '        objclsRet.Priority = Priority
        '        objclsRet.LanguageId = LanguageId
        '        objclsRet.DisplayDescrip = DisplayDescrip
        '        objclsRet.RetAddress = RetAddress
        '        objclsRet.RetCity = RetCity
        '        objclsRet.RetZip = RetZip
        '        objclsRet.TDLinkxNumber = TDLinkxNumber
        '        objclsRet.RetState = RetState
        '        objclsRet.BaseURL = BaseURL

        '        If objclsRet.Update() Then
        '            Return True
        '        End If
        '        Return False
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message)
        '    End Try
        'End Function
        'Public Function Delete() As Boolean
        '    Try
        '        objclsRet = New clsRet()

        '        objclsRet.RetId = RetId

        '        If objclsRet.Delete() Then
        '            Return True
        '        End If
        '        Return False
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message)
        '    End Try
        'End Function
#End Region

    End Class
End Namespace