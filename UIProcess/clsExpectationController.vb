Option Strict Off
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient

Namespace BusinessLayer
    Public Class clsMediaObj
#Region "Constructor"
        Public Sub New()
        End Sub
#End Region
        Private _MktId As Integer
        Private _Media As String
        Public Property MktId() As Integer
            Get
                Return _MktId
            End Get
            Set(value As Integer)
                _MktId = value
            End Set
        End Property
        Public Property Media() As String
            Get
                Return _Media
            End Get
            Set(value As String)
                _Media = value
            End Set
        End Property
    End Class
    Public Class clsExpectationController

#Region "Constructor"
        Public Sub New()
        End Sub
#End Region

#Region "Private Variables"
        Private _ExpectationID As Integer
        Private _RetId As Integer
        Private _codeId As Integer
        Private _MktId As Integer
        Private _MediaId As Integer
        Private _FrequencyId As Integer
        Private _StartDt As System.DateTime
        Private _EndDt As System.DateTime
        Private _Priority As Integer
        Private _Comments As String
        Private _FVReqInd As Byte
        Private _ADReqInd As Byte
        Private _Descrip As String
        Private _ScanDPI As Integer
        Private _PublicationId As Integer
        Private objMda As New DatabaseLayer.clsExpectation
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
        Public Property CodeID() As Integer
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

        Public Property Descrip() As String
            Get
                Return _Descrip
            End Get
            Set(value As String)
                _Descrip = value
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
       
        Public Function fetch(ByVal value As Integer) As List(Of DatabaseLayer.clsExpectation)

            Dim objRet As List(Of DatabaseLayer.clsExpectation)
            objMda = New DatabaseLayer.clsExpectation
            objRet = New List(Of DatabaseLayer.clsExpectation)
            Select Case value
                Case 1
                    objRet = objMda.GetMedia()
                Case 2
                    objRet = objMda.GetMarket()
                Case 3
                    objRet = objMda.GetREtailer()
                Case 4
                    objRet = objMda.GetPriority
                Case 5
                    objRet = objMda.GetDPI
                Case 6
                    objRet = objMda.GetFrequency
                Case 7 'List of PUblication
                    objRet = objMda.GetPublicationList
                Case Else
                    Console.WriteLine("You typed something else")
            End Select

            Return objRet

        End Function

        Public Function Insert() As Boolean
            Try
                objMda = New DatabaseLayer.clsExpectation

                objMda.MediaId = MediaId
                objMda.RetId = RetId
                objMda.MktId = MktId

                objMda.StartDt = StartDt
                objMda.Priority = Priority
                objMda.Comments = Comments

                objMda.FVReqInd = FVReqInd
                objMda.ADReqInd = ADReqInd

                objMda.FrequencyID = FrequencyID
                objMda.ScanDPI = ScanDPI

                If objMda.Insert() Then
                    Return True
                End If
                Return False
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
        Public Function Update() As Boolean
            Try
                objMda = New DatabaseLayer.clsExpectation

                objMda.ExpectationID = ExpectationID
                objMda.Comments = Comments
                objMda.Priority = Priority
                objMda.FVReqInd = FVReqInd
                objMda.ADReqInd = ADReqInd
                objMda.FrequencyID = FrequencyID
                objMda.ScanDPI = ScanDPI
                If objMda.Update() Then
                    Return True
                End If
                Return False
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
#End Region

    End Class
End Namespace
