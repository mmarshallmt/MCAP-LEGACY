
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient

Namespace DatabaseLayer
    Public Class clsRet

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
        Private objclsRet As clsRet
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
        '    Dim ds As DataSet
        '    Try
        '        Dim Params As SqlParameter() = {New SqlParameter("@RetId", SqlDbType.Int), New SqlParameter("@Descrip", SqlDbType.VarChar), New SqlParameter("@TradeClassId", SqlDbType.Int), New SqlParameter("@StartDt", SqlDbType.System.DateTime.DateTime), New SqlParameter("@EndDt", SqlDbType.System.DateTime.DateTime), New SqlParameter("@Priority", SqlDbType.Int), _
        '            New SqlParameter("@LanguageId", SqlDbType.Int), New SqlParameter("@DisplayDescrip", SqlDbType.VarChar), New SqlParameter("@RetAddress", SqlDbType.VarChar), New SqlParameter("@RetCity", SqlDbType.VarChar), New SqlParameter("@RetZip", SqlDbType.VarChar), New SqlParameter("@TDLinkxNumber", SqlDbType.VarChar), _
        '            New SqlParameter("@RetState", SqlDbType.VarChar), New SqlParameter("@BaseURL", SqlDbType.VarChar)}


        '        If RetId IsNot Nothing Then
        '            Params(0).Value = RetId
        '        Else
        '            Params(0).Value = DBNull.Value
        '        End If

        '        If Descrip IsNot Nothing Then
        '            Params(1).Value = Descrip
        '        Else
        '            Params(1).Value = DBNull.Value
        '        End If

        '        If TradeClassId IsNot Nothing Then
        '            Params(2).Value = TradeClassId
        '        Else
        '            Params(2).Value = DBNull.Value
        '        End If

        '        If StartDt IsNot Nothing Then
        '            Params(3).Value = StartDt
        '        Else
        '            Params(3).Value = DBNull.Value
        '        End If

        '        If EndDt IsNot Nothing Then
        '            Params(4).Value = EndDt
        '        Else
        '            Params(4).Value = DBNull.Value
        '        End If

        '        If Priority IsNot Nothing Then
        '            Params(5).Value = Priority
        '        Else
        '            Params(5).Value = DBNull.Value
        '        End If

        '        If LanguageId IsNot Nothing Then
        '            Params(6).Value = LanguageId
        '        Else
        '            Params(6).Value = DBNull.Value
        '        End If

        '        If DisplayDescrip IsNot Nothing Then
        '            Params(7).Value = DisplayDescrip
        '        Else
        '            Params(7).Value = DBNull.Value
        '        End If

        '        If RetAddress IsNot Nothing Then
        '            Params(8).Value = RetAddress
        '        Else
        '            Params(8).Value = DBNull.Value
        '        End If

        '        If RetCity IsNot Nothing Then
        '            Params(9).Value = RetCity
        '        Else
        '            Params(9).Value = DBNull.Value
        '        End If

        '        If RetZip IsNot Nothing Then
        '            Params(10).Value = RetZip
        '        Else
        '            Params(10).Value = DBNull.Value
        '        End If

        '        If TDLinkxNumber IsNot Nothing Then
        '            Params(11).Value = TDLinkxNumber
        '        Else
        '            Params(11).Value = DBNull.Value
        '        End If

        '        If RetState IsNot Nothing Then
        '            Params(12).Value = RetState
        '        Else
        '            Params(12).Value = DBNull.Value
        '        End If

        '        If BaseURL IsNot Nothing Then
        '            Params(13).Value = BaseURL
        '        Else
        '            Params(13).Value = DBNull.Value
        '        End If


        '        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "SP_Ret_Select", Params)
        '        Return ds.Tables(0)
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message)
        '    End Try
        'End Function
        'Public Function Insert() As Boolean
        '    Try
        '        Dim Params As SqlParameter() = {New SqlParameter("@Descrip", Descrip), New SqlParameter("@TradeClassId", TradeClassId), New SqlParameter("@StartDt", StartDt), New SqlParameter("@EndDt", EndDt), New SqlParameter("@Priority", Priority), New SqlParameter("@LanguageId", LanguageId), _
        '            New SqlParameter("@DisplayDescrip", DisplayDescrip), New SqlParameter("@RetAddress", RetAddress), New SqlParameter("@RetCity", RetCity), New SqlParameter("@RetZip", RetZip), New SqlParameter("@TDLinkxNumber", TDLinkxNumber), New SqlParameter("@RetState", RetState), _
        '            New SqlParameter("@BaseURL", BaseURL)}
        '        Dim result As Integer = SqlHelper.ExecuteNonQuery(Transaction, CommandType.StoredProcedure, "SP_Ret_Insert", Params)
        '        If result > 0 Then
        '            Return True
        '        End If
        '        Return False
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message)
        '    End Try
        'End Function
        'Public Function Update() As Boolean
        '    Try
        '        Dim Params As SqlParameter() = {New SqlParameter("@RetId", RetId), New SqlParameter("@Descrip", Descrip), New SqlParameter("@TradeClassId", TradeClassId), New SqlParameter("@StartDt", StartDt), New SqlParameter("@EndDt", EndDt), New SqlParameter("@Priority", Priority), _
        '            New SqlParameter("@LanguageId", LanguageId), New SqlParameter("@DisplayDescrip", DisplayDescrip), New SqlParameter("@RetAddress", RetAddress), New SqlParameter("@RetCity", RetCity), New SqlParameter("@RetZip", RetZip), New SqlParameter("@TDLinkxNumber", TDLinkxNumber), _
        '            New SqlParameter("@RetState", RetState), New SqlParameter("@BaseURL", BaseURL)}
        '        Dim result As Integer = SqlHelper.ExecuteNonQuery(Transaction, CommandType.StoredProcedure, "SP_Ret_Update", Params)
        '        If result > 0 Then
        '            Return True
        '        End If
        '        Return False
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message)
        '    End Try
        'End Function
        'Public Function Delete() As Boolean
        '    Try
        '        Dim Params As SqlParameter() = {New SqlParameter("@RetId", RetId)}
        '        Dim result As Integer = SqlHelper.ExecuteNonQuery(Transaction, CommandType.StoredProcedure, "SP_Ret_Delete", Params)
        '        If result > 0 Then
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