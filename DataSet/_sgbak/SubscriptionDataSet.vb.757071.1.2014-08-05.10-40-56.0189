Partial Class SubscriptionDataSet
    Partial Class PublicationSubscriptionDataTable
        ''' <summary>
        ''' Flag variable, used to determine whether the table is being filled or not.
        ''' </summary>
        ''' <remarks></remarks>
        Private m_loadingTable As Boolean



        ''' <summary>
        ''' Gets or sets flag value, whether the rows are being filled in to the table by adapter or not.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>Row Changing and Changed events use this flag to determine whether the newly added row is being filled in by adapter or inserted by a user.</remarks>
        Public Property LoadingTable() As Boolean
            Get
                Return m_loadingTable
            End Get
            Set(ByVal value As Boolean)
                m_loadingTable = value
            End Set
        End Property



        Private Function ValidateColumnValues _
            (ByVal validateRow As SubscriptionDataSet.PublicationSubscriptionRow, ByVal action As DataRowAction) _
            As Boolean
            Dim areAllValid As Boolean


            areAllValid = True

            If validateRow.IsPublicationNull() AndAlso validateRow.Table.Columns("Publication").AllowDBNull = False Then
                validateRow.SetColumnError("Publication", "Publication is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Publication", String.Empty)
            End If

            If validateRow.IsStartDtNull() AndAlso validateRow.Table.Columns("StartDt").AllowDBNull = False Then
                validateRow.SetColumnError("StartDt", "Start Date is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("StartDt", String.Empty)
            End If

            If validateRow.IsAccountNoNull() AndAlso validateRow.Table.Columns("AccountNo").AllowDBNull = False Then
                validateRow.SetColumnError("AccountNo", "Account Number is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("AccountNo", String.Empty)
            End If

            Return areAllValid

        End Function

        Private Sub PublicationSubscriptionDataTable_PublicationSubscriptionRowChanging _
            (ByVal sender As Object, ByVal e As PublicationSubscriptionRowChangeEvent) _
            Handles Me.PublicationSubscriptionRowChanging
            Dim rowQuery As System.Collections.Generic.IEnumerable(Of PublicationSubscriptionRow)


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            If Not ((e.Action = DataRowAction.Change AndAlso e.Row.RowState = DataRowState.Unchanged) _
              OrElse (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Detached)) _
              OrElse Me.LoadingTable = True _
            Then Exit Sub

            If ValidateColumnValues(e.Row, e.Action) Then
                e.Row.RowError = String.Empty
            Else
                'e.Row.RowError = "Row contains invalid input. Please correct them to store into database."
                Throw New System.ApplicationException("Row contains invalid input. Cannot save changes.")
                Exit Sub
            End If

            rowQuery = From r In Me.Rows.Cast(Of SubscriptionDataSet.PublicationSubscriptionRow)() _
                       Select r _
                       Where r.AccountNo = e.Row.AccountNo And r.Publication = e.Row.Publication 'r.Descrip.ToUpper() = e.Row.Descrip.ToUpper()

            If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
                e.Row.RowError = "Subscription already exist. Provide another Account number and Publication."
                Throw New ApplicationException(e.Row.RowError)
                'ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
                '    e.Row.RowError = "Account number and Publication must be unique."
                '    Throw New ApplicationException(e.Row.RowError)
            Else
                e.Row.RowError = String.Empty
            End If

            rowQuery = Nothing

        End Sub
    End Class

End Class
