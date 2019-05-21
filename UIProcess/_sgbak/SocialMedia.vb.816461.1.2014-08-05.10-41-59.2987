Namespace UI.Processors

    Public Class SocialMedia
        Inherits BaseClass
        Private ExpectationObj As List(Of DatabaseLayer.clsExpectation) = Nothing
        Private expObj As BusinessLayer.clsExpectationController

        Public Sub New()
            ExpectationObj = New List(Of DatabaseLayer.clsExpectation)
            expObj = New BusinessLayer.clsExpectationController
        End Sub
        Public Function retIdList() As List(Of DatabaseLayer.clsExpectation)

            ExpectationObj = expObj.fetch(3)
            Return ExpectationObj

        End Function

        Public Function crawlOptions() As List(Of clsFaceBook)
            Dim mdaObj As List(Of clsFaceBook) = Nothing
            Dim expObj As New clsFaceBookController
            mdaObj = expObj.fetch("crawl")
            Return mdaObj
        End Function

        Public Function EnabledOptions() As List(Of clsFaceBook)
            Dim mdaObj As List(Of clsFaceBook) = Nothing
            Dim expObj As New clsFaceBookController
            mdaObj = expObj.fetch("enable")
            Return mdaObj
        End Function

        Public Function loginIdOptions() As List(Of clsFaceBook)
            Dim mdaObj As List(Of clsFaceBook) = Nothing
            Dim expObj As New clsFaceBookController
            mdaObj = expObj.fetch("loginId")
            Return mdaObj
        End Function
        Public Function loginOutTypeOptions() As List(Of clsFaceBook)
            Dim mdaObj As List(Of clsFaceBook) = Nothing
            Dim expObj As New clsFaceBookController
            mdaObj = expObj.fetch("logoutType")
            Return mdaObj
        End Function

    End Class
End Namespace
