Namespace UI.Processors

    Public Class Expectation
        Sub loadComboBox(ByVal objCombo As ComboBox, ByVal id As String, ByVal desc As String, ByVal value As Integer)
            Dim mdaObj As List(Of DatabaseLayer.clsExpectation) = Nothing
            Dim expObj As New BusinessLayer.clsExpectationController


            mdaObj = expObj.fetch(value)

            If mdaObj IsNot Nothing Then
                objCombo.DataSource = mdaObj
                objCombo.DisplayMember = desc
                objCombo.ValueMember = id

            End If
        End Sub

        Public Function isExpectationEnable(ByVal id As Integer) As Boolean
            Dim cmdExp As System.Data.SqlClient.SqlCommand
            Dim isValid As Object

            cmdExp = New System.Data.SqlClient.SqlCommand

            Try
                With cmdExp
                    .CommandText = "select endDt from Expectation where expectationID =  " + id.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    isValid = .ExecuteScalar()
                End With

                If String.IsNullOrEmpty(isValid.ToString) = False Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As System.Data.SqlClient.SqlException
                My.Application.Log.WriteException(ex)

            Finally
                If cmdExp.Connection.State <> ConnectionState.Closed Then cmdExp.Connection.Close()
            End Try
        End Function

        Public Function ifExpectationExist(ByVal RetId As Integer, ByVal mktId As Integer, ByVal MediaId As Integer) As Integer
            Dim returnValue As Integer
            returnValue = CInt(GetFieldValue("Select Expectationid From Expectation where retid=" & RetId & " and MktId=" & mktId & " and mediaid=" & MediaId, "expectationID"))
            Return returnValue
        End Function

        Public Sub UpdateExpectation(ByVal expectationId As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As New Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd

                    .CommandText = "UPDATE Expectation SET endDt = Null where expectationID = " + expectationId.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With

            Catch ex As Exception
                Throw New ApplicationException("Failed to restore expectation Details.", ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub

    End Class

End Namespace
