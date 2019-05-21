Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Data
Namespace UI
    Public Class clsVehicleChildrenCreation

#Region "Private Variables"
        Private _parentVehicleId As Integer
        Private _retId As Integer
        Private _mktId As Integer
        Private _mediaId As Integer
        Private _descrip As Integer
        Private _tDLinkxNumber As Integer

        Private objclsVehicleChildrencreation As clsVehicleChildrenCreation
#End Region

#Region "Public Properties"

        Public Property ParentVehicleId() As Integer
            Get
                Return _parentVehicleId
            End Get
            Set(ByVal value As Integer)
                _parentVehicleId = value
            End Set
        End Property
        Public Property RetId() As Integer
            Get
                Return _retId
            End Get
            Set(ByVal value As Integer)
                _retId = value
            End Set
        End Property

        Public Property MktId() As Integer
            Get
                Return _mktId
            End Get
            Set(ByVal value As Integer)
                _mktId = value
            End Set
        End Property
        Public Property MediaId() As Integer
            Get
                Return _mediaId
            End Get
            Set(ByVal value As Integer)
                _mediaId = value
            End Set
        End Property
        Public Property Descrip() As Integer
            Get
                Return _descrip
            End Get
            Set(ByVal value As Integer)
                _descrip = value
            End Set
        End Property
        Public Property TDLinkxNumber() As Integer
            Get
                Return _tDLinkxNumber
            End Get
            Set(ByVal value As Integer)
                _tDLinkxNumber = value
            End Set
        End Property
#End Region
#Region "Public Methods"


        Public Function Insert() As Boolean

            Dim con As New SqlConnection
            Dim cmd As New SqlCommand

            Try

                con.ConnectionString = GetConnectionStringForAppDB()
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                'cmd.CommandText = "INSERT INTO [outOfMemoryLog]([userid],[dateError],[image]) VALUES (@userid,@dateError,@image); SELECT @newPkId = Pk FROM outOfMemoryLog WHERE Pk=SCOPE_IDENTITY()"
                'cmd.Parameters.AddWithValue("@userid", Me.userid)
                'cmd.Parameters.AddWithValue("@dateError", Me.dateError)
                'cmd.Parameters.AddWithValue("@image", Me.Image)
                'Dim param As New SqlParameter("@newPkId", SqlDbType.Int)
                'param.Direction = ParameterDirection.Output
                'cmd.Parameters.Add(param)
                'cmd.ExecuteNonQuery()
                'Me.pk = CInt(cmd.Parameters.Item("@newPkId").Value)

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

        Public Function tDlinksNotInList(ByVal criteria As String) As String
            Dim source As String
            Dim ValuesToReturn As String
            Dim intReturn As Integer

            source = SplitText(criteria)

            Dim result() As String = Split(source, ",")

            For Each item As String In result
                intReturn = CInt(GetFieldValue("Select TDLinkxNumber from ret where TDLinkxNumber='" + item + "'", "TDLinkxNumber")) + 0

                If intReturn = 0 And item <> " " Then
                    ValuesToReturn += item + vbNewLine
                End If

            Next
            Return ValuesToReturn
        End Function

        Public Function isValidTdLinks(ByVal criteria As String) As Boolean
            Dim source As String
            Dim intReturn As Integer

            source = CleanString(SplitText(criteria))

            Dim result() As String = Split(source, ",")

            For Each item As String In result
                intReturn = CInt(GetFieldValue("Select TDLinkxNumber from ret where TDLinkxNumber='" + item + "'", "TDLinkxNumber")) + 0
                If intReturn = 0 Then
                    Return False
                    Exit Function
                End If

            Next
            Return True
        End Function
#End Region
    End Class
End Namespace
