Public Class clsFaceBookController

#Region "Private Variables"
    Private _Priority As Integer
    Private _Descrip As String
    Private objMda As clsFaceBook
#End Region

#Region "Constructor"
    Public Sub New()
        _Priority = 0

    End Sub
#End Region

#Region "Public Properties"


    Public Property Priority() As Integer
        Get
            Return _Priority
        End Get
        Set(value As Integer)
            _Priority = value
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



#End Region
    Public Function fetch(ByVal value As String) As List(Of clsFaceBook)

        Dim objRet As List(Of clsFaceBook)
        objMda = New clsFaceBook
        objRet = New List(Of clsFaceBook)
        Select Case value
            Case "loginid"
                objRet = objMda.GetLoginId
            Case "crawl"
                objRet = objMda.LoadCrawlOptions
            Case "enabled"
                objRet = objMda.LoadEnabledOptions
            Case "layouttype"
                objRet = objMda.LoadLayoutTypeOptions
            Case "retid"
                objRet = objMda.GetRetailer
            Case "YesNo"
                objRet = objMda.LoadYesNoForMediaOptions
            Case Else
                Console.WriteLine("You typed something else")
        End Select

        Return objRet

    End Function

    Public Function LoadTableColumn(ByVal dt As DataTable) As List(Of clsFaceBookController)
        Dim objRet As New List(Of clsFaceBookController)()

        For Each column As DataColumn In dt.Columns
            Dim objRec As New clsFaceBookController()

            objRec.Descrip = column.ColumnName
            objRet.Add(objRec)
        Next

        Return objRet
    End Function
End Class
