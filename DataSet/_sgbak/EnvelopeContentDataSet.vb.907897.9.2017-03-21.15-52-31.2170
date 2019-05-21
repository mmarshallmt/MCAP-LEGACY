

Partial Public Class EnvelopeContentDataSet


    Partial Class SenderExpectationDataTable

        Private Sub SenderExpectationDataTable_SenderExpectationRowChanging(sender As Object, e As SenderExpectationRowChangeEvent) Handles Me.SenderExpectationRowChanging

        End Sub

    End Class

    Partial Class MktDataTable

        Private Sub MktDataTable_MktRowChanging(ByVal sender As System.Object, ByVal e As MktRowChangeEvent) Handles Me.MktRowChanging

        End Sub

    End Class

    Partial Class vwCircularDataTable


        '''' <summary>
        '''' Returns valid date interval between ad date and sale start date.
        '''' </summary>
        '''' <param name="vehicleRow"></param>
        '''' <returns></returns>
        '''' <remarks></remarks>
        'Private Function GetAllowedIntervalInDays(ByVal vehicleRow As vwCircularRow) As Integer
        '  Dim dateInterval As Integer


        '  If vehicleRow.MediaRow IsNot Nothing AndAlso vehicleRow.MediaRow.IsDescripNull() = False _
        '    AndAlso (vehicleRow.MediaRow.Descrip.ToUpper() = "CATALOG" _
        '             OrElse vehicleRow.MediaRow.Descrip.ToUpper() = "MAILER") _
        '  Then
        '    dateInterval = 7
        '  ElseIf vehicleRow.RetRow IsNot Nothing AndAlso vehicleRow.RetRow.TradeClassRow IsNot Nothing _
        '    AndAlso vehicleRow.RetRow.TradeClassRow.IsDescripNull() = False _
        '    AndAlso vehicleRow.RetRow.TradeClassRow.Descrip.ToUpper = "DEPARTMENT" _
        '  Then
        '    dateInterval = 14
        '  Else
        '    dateInterval = 28
        '  End If

        '  Return dateInterval

        'End Function


        'Private Sub vwCircularDataTable_vwCircularRowChanging _
        '    (ByVal sender As Object, ByVal e As vwCircularRowChangeEvent) _
        '    Handles Me.vwCircularRowChanging

        '  If e.Action <> DataRowAction.Change Then Exit Sub

        '  If e.Row.IsBreakDtNull() Then
        '    e.Row.SetColumnError("BreakDt", "Ad date cannot be blank.")
        '  End If

        '  If e.Row.IsBreakDtNull() = False AndAlso e.Row.IsStartDtNull() = False Then
        '    Dim dateInterval As Integer
        '    Dim dayDiff As TimeSpan


        '    dateInterval = GetAllowedIntervalInDays(e.Row)
        '    dayDiff = e.Row.StartDt.Subtract(e.Row.BreakDt)

        '    If dayDiff.Days < -dateInterval Or dayDiff.Days > dateInterval Then
        '      e.Row.SetColumnError("StartDt", "Start Date is not close enough to Ad Date to permit Entry." _
        '                           + " Correct one of the dates or if they are correct set aside for supervisor.")
        '    ElseIf dayDiff.Days < -3 Or dayDiff.Days > 3 Then
        '      e.Row.SetColumnError("StartDt", "QUESTION:Difference between Start Date and Ad Date is " _
        '                           + "unusually large. Check these values. Is sale start date correct?")
        '    End If
        '  End If

        '  If e.Row.IsEndDtNull() = False AndAlso e.Row.IsStartDtNull() = False Then
        '    Dim startdateDayDiff, addateDayDiff As TimeSpan


        '    addateDayDiff = e.Row.EndDt.Subtract(e.Row.BreakDt)
        '    startdateDayDiff = e.Row.EndDt.Subtract(e.Row.StartDt)

        '    If addateDayDiff.Days < -35 Or addateDayDiff.Days > 35 Then
        '      e.Row.SetColumnError("EndDt", "End Date is not close enough to Ad Date to permit Entry." _
        '                           + " Correct one of the dates or if they are correct set aside for supervisor.")
        '    ElseIf startdateDayDiff.Days < -30 Or startdateDayDiff.Days > 30 Then
        '      e.Row.SetColumnError("EndDt", "End Date is not close enough to Start Date to permit Entry." _
        '                           + " Correct one of the dates or if they are correct set aside for supervisor.")
        '    End If
        '  End If

        'End Sub


    End Class


End Class
'Namespace EnvelopeContentDataSetTableAdapters

'    Partial Public Class RetTableAdapter
'    End Class
'End Namespace
