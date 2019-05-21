Partial Class FamilyExpectationReportDataSet
End Class

Namespace FamilyExpectationReportDataSetTableAdapters
    
    Partial Public Class FamilyExpectationTableAdapter
        Public Property CommandTimeout() As Integer

            Set(ByVal value As Integer)

                For Each DBCommand As SqlClient.SqlCommand In Me.CommandCollection
                    DBCommand.CommandTimeout = value
                Next
                ' Me.Adapter.SelectCommand.CommandTimeout = value
               
            End Set

            Get

            End Get
        End Property
    End Class
End Namespace
