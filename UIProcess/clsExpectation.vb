
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient

Namespace DatabaseLayer
   
  
    Public Class clsExpectation
#Region "Private Variables"
        Private _ExpectationID As Integer
        Private _RetId As Integer
        Private _codeId As Integer
        Private _MktId As Integer
        Private _MediaId As Integer
        Private _StartDt As System.DateTime
        Private _EndDt As System.DateTime
        Private _Priority As Integer
        Private _Comments As String
        Private _FVReqInd As Byte
        Private _ADReqInd As Byte
        Private _Descrip As String
        Private _FrequencyId As Integer
        Private _ScanDPI As Integer
        Private _PublicationId As Integer
        Private objclsExpectation As clsExpectation
#End Region


#Region "Constructor"
        Public Sub New()
            _Priority = 0

        End Sub
#End Region


#Region "Public Properties"
        Public Property ExpectationID() As Integer
            Get
                Return _ExpectationID
            End Get
            Set(value As Integer)
                _ExpectationID = value
            End Set
        End Property
        Public Property codeID() As Integer
            Get
                Return _codeId
            End Get
            Set(value As Integer)
                _codeId = value
            End Set
        End Property
        Public Property RetId() As Integer
            Get
                Return _RetId
            End Get
            Set(value As Integer)
                _RetId = value
            End Set
        End Property
        Public Property MktId() As Integer
            Get
                Return _MktId
            End Get
            Set(value As Integer)
                _MktId = value
            End Set
        End Property
        Public Property MediaId() As Integer
            Get
                Return _MediaId
            End Get
            Set(value As Integer)
                _MediaId = value
            End Set
        End Property
        Public Property PublicationId() As Integer
            Get
                Return _PublicationId
            End Get
            Set(value As Integer)
                _PublicationId = value
            End Set
        End Property
        Public Property StartDt() As System.DateTime
            Get
                Return _StartDt
            End Get
            Set(ByVal value As System.DateTime)
                _StartDt = value
            End Set
        End Property
        Public Property EndDt() As System.DateTime
            Get
                Return _EndDt
            End Get
            Set(ByVal value As System.DateTime)
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
        Public Property Comments() As String
            Get
                Return _Comments
            End Get
            Set(value As String)
                _Comments = value
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

        Public Property FVReqInd() As Byte
            Get
                Return _FVReqInd
            End Get
            Set(ByVal value As Byte)
                _FVReqInd = value
            End Set
        End Property
        Public Property ADReqInd() As Byte
            Get
                Return _ADReqInd
            End Get
            Set(ByVal value As Byte)
                _ADReqInd = value
            End Set
        End Property

        Public Property FrequencyID() As Integer
            Get
                Return _FrequencyId
            End Get
            Set(value As Integer)
                _FrequencyId = value
            End Set
        End Property
        Public Property ScanDPI() As Integer
            Get
                Return _ScanDPI
            End Get
            Set(value As Integer)
                _ScanDPI = value
            End Set
        End Property

#End Region

#Region "Public Methods"
      
        Public Function GetMedia() As List(Of clsExpectation)
            Dim objRet As New List(Of clsExpectation)
            Using objCnn As New SqlConnection(GetConnectionStringForAppDB)
                objCnn.Open()
                Using objCmd As SqlCommand = objCnn.CreateCommand()
                    objCmd.CommandType = System.Data.CommandType.Text
                    objCmd.CommandText = "Select mediaid,descrip from Media where (inddisplayvalue=1 or inddisplayvalue is null) and endDT is null order by descrip asc"
                    Using objDR As SqlDataReader = objCmd.ExecuteReader()
                        While objDR.Read()
                            Dim objRec As New clsExpectation()

                            If objDR.IsDBNull(objDR.GetOrdinal("mediaId")) Then
                                objRec.MediaId = 0
                            Else
                                objRec.MediaId = objDR.GetInt32(objDR.GetOrdinal("mediaId"))
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

        Public Function GetMarket() As List(Of clsExpectation)
            Dim MktQry As String = ""
            Dim objRet As New List(Of clsExpectation)()
            Using objCnn As New SqlConnection(GetConnectionStringForAppDB)
                objCnn.Open()
                Using objCmd As SqlCommand = objCnn.CreateCommand()
                    objCmd.CommandType = System.Data.CommandType.Text

                    If LCase(User.Location) = LCase("canada") Then
                        MktQry = "select mktid,descrip from mkt inner join cufpmkt on mkt.mktid=cufpmkt.mktid where enddt is null order by descrip asc"
                    Else
                        MktQry = "Select mktid,descrip from mkt where mkt.EndDt is Null order by descrip asc"
                    End If

                    objCmd.CommandText = MktQry
                    Using objDR As SqlDataReader = objCmd.ExecuteReader()
                        While objDR.Read()
                            Dim objRec As New clsExpectation()

                            If objDR.IsDBNull(objDR.GetOrdinal("MktId")) Then
                                objRec.MktId = 0
                            Else
                                objRec.MktId = objDR.GetInt32(objDR.GetOrdinal("MktId"))
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

        Public Function GetRetailer() As List(Of clsExpectation)
            Dim objRet As New List(Of clsExpectation)()
            Using objCnn As New SqlConnection(GetConnectionStringForAppDB)
                objCnn.Open()
                Using objCmd As SqlCommand = objCnn.CreateCommand()
                    objCmd.CommandType = System.Data.CommandType.Text
                    objCmd.CommandText = "Select retid,descrip from Ret where Ret.EndDt is Null order by descrip,retid asc"
                    Using objDR As SqlDataReader = objCmd.ExecuteReader()
                        While objDR.Read()
                            Dim objRec As New clsExpectation()

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

        Public Function GetDPI() As List(Of clsExpectation)
            Dim objRet As New List(Of clsExpectation)()
            Using objCnn As New SqlConnection(GetConnectionStringForAppDB)
                objCnn.Open()
                Using objCmd As SqlCommand = objCnn.CreateCommand()
                    objCmd.CommandType = System.Data.CommandType.Text
                    objCmd.CommandText = "select c.codeid, c.descrip from code c inner join codetype ct on c.CodeTypeId=ct.CodeTypeId where ct.CodeTypeId=12 order by c.CodeId desc"
                    Using objDR As SqlDataReader = objCmd.ExecuteReader()
                        While objDR.Read()
                            Dim objRec As New clsExpectation()

                            If objDR.IsDBNull(objDR.GetOrdinal("codeid")) Then
                                objRec.codeid = 0
                            Else
                                objRec.codeid = objDR.GetInt32(objDR.GetOrdinal("codeid"))
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

        Public Function GetFrequency() As List(Of clsExpectation)
            Dim objRet As New List(Of clsExpectation)()
            Using objCnn As New SqlConnection(GetConnectionStringForAppDB)
                objCnn.Open()
                Using objCmd As SqlCommand = objCnn.CreateCommand()
                    objCmd.CommandType = System.Data.CommandType.Text
                    objCmd.CommandText = "select c.codeid, c.descrip from code c inner join codetype ct on c.CodeTypeId=ct.CodeTypeId where ct.CodeTypeId=9 order by c.CodeId desc"
                    Using objDR As SqlDataReader = objCmd.ExecuteReader()
                        While objDR.Read()
                            Dim objRec As New clsExpectation()

                            If objDR.IsDBNull(objDR.GetOrdinal("codeid")) Then
                                objRec.codeid = 0
                            Else
                                objRec.codeid = objDR.GetInt32(objDR.GetOrdinal("codeid"))
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

        Public Function GetPublicationList() As List(Of clsExpectation)
            Dim objRet As New List(Of clsExpectation)()
            Using objCnn As New SqlConnection(GetConnectionStringForAppDB)
                objCnn.Open()
                Using objCmd As SqlCommand = objCnn.CreateCommand()
                    objCmd.CommandType = System.Data.CommandType.Text
                    objCmd.CommandText = "SELECT P.PublicationId, P.Descrip + ' (' + M.Descrip + ') ' Descrip, CASE WHEN P.EndDt IS NULL THEN 1 ELSE 0 END IsActive FROM Publication P INNER JOIN Mkt M ON P.MktId = M.MktId ORDER BY P.Descrip"

                    Using objDR As SqlDataReader = objCmd.ExecuteReader()
                        While objDR.Read()
                            Dim objRec As New clsExpectation()

                            If objDR.IsDBNull(objDR.GetOrdinal("PublicationId")) Then
                                objRec.codeID = 0
                            Else
                                objRec.codeID = objDR.GetInt32(objDR.GetOrdinal("PublicationId"))
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

        Public Function GetPriority() As List(Of clsExpectation)
            Dim objRet As New List(Of clsExpectation)()
            For i As Integer = 1 To 20
                Dim objRec As New clsExpectation()
                objRec.Priority = i
                objRec.Descrip = CStr(i)
                objRet.Add(objRec)
            Next
            Return objRet
        End Function
        


         Public Function Insert() As Boolean

            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim cm As New SqlCommand
            Dim insQry As String = ""

            Try

                insQry = "INSERT INTO [Expectation]([MediaId],[RetId],[MktId],StartDt,priority,comments,FVReqInd,ADReqInd,frequencyid,scanDPI)"
                insQry = insQry & " VALUES (@MediaID,@retid,@MktID,@StartDt,@Priority,@Comments,@FVReqInd,@AdReqInd,@FrequencyID,@ScanDPI); "
                insQry = insQry & "SELECT @newPkId = expectationid FROM [Expectation] WHERE expectationid=SCOPE_IDENTITY()"
                con.ConnectionString = GetConnectionStringForAppDB()
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.CommandText = insQry
                cmd.Parameters.AddWithValue("@mediaid", Me.MediaId)
                cmd.Parameters.AddWithValue("@mktID", Me.MktId)
                cmd.Parameters.AddWithValue("@retId", Me.RetId)
                cmd.Parameters.AddWithValue("@StartDt", Me.StartDt)
                'cmd.Parameters.AddWithValue("@EndDt", Me.EndDt)
                cmd.Parameters.AddWithValue("@Priority", Me.Priority)
                cmd.Parameters.AddWithValue("@Comments", Me.Comments)
                cmd.Parameters.AddWithValue("@FVReqInd", Me.FVReqInd)
                cmd.Parameters.AddWithValue("@ADReqInd", Me.ADReqInd)
                cmd.Parameters.AddWithValue("@FrequencyID", Me.FrequencyID)
                cmd.Parameters.AddWithValue("@ScanDPI", Me.ScanDPI)
                Dim param As New SqlParameter("@newPkId", SqlDbType.Int)
                param.Direction = ParameterDirection.Output
                cmd.Parameters.Add(param)
                cmd.ExecuteNonQuery()
                Me.ExpectationID = CInt(cmd.Parameters.Item("@newPkId").Value)

            Catch ex As SqlException
                Throw New Exception(ex.Message)
            End Try

            Return True

        End Function
        Public Function Update() As Boolean

            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Dim cm As New SqlCommand
            Dim insQry As String = ""

            Try
                   insQry = "UPDATE [expectation] SET" _
                       & " [priority] = @priority," _
                       & " [comments] = @comments," _
                       & " [FVReqInd] = @FVReqInd," _
                       & " [ADReqInd] = @ADReqInd" _
                       & " WHERE [expectationid] = @expectationid"
                con.ConnectionString = GetConnectionStringForAppDB()
                con.Open()
                cmd.Connection = con
                cmd.CommandType = CommandType.Text
                cmd.CommandText = insQry
                cmd.Parameters.AddWithValue("@expectationid", Me.ExpectationID)
                cmd.Parameters.AddWithValue("@Priority", Me.Priority)
                cmd.Parameters.AddWithValue("@Comments", Me.Comments)
                cmd.Parameters.AddWithValue("@FVReqInd", Me.FVReqInd)
                cmd.Parameters.AddWithValue("@ADReqInd", Me.ADReqInd)
                cmd.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
#End Region

    End Class
End Namespace


