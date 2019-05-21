
Partial Public Class QCDataSet

    

  Partial Class QcStatusDisplayDataTable

  End Class

  Partial Class vwPublicationEditionDataTable

    Private Sub vwPublicationEditionDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
      If (e.Column.ColumnName = Me.VehicleIdColumn.ColumnName) Then
        'Add user code here
      End If

    End Sub

  End Class

    Partial Class vwCircularDataTable


        Private Sub vwCircularDataTable_vwCircularRowChanging _
            (ByVal sender As Object, ByVal e As vwCircularRowChangeEvent) _
            Handles Me.vwCircularRowChanging

            If e.Action = DataRowAction.Commit And e.Row.RowState = DataRowState.Deleted Then Exit Sub

            If e.Row.IsBreakDtNull() Then
                e.Row.SetColumnError("BreakDt", "Ad date cannot have blank value.")
            End If

            If e.Row.IsStartDtNull() = False AndAlso e.Row.StartDt < e.Row.BreakDt Then
                e.Row.SetColumnError("StartDt", "Sale end date cannot have values prior to ad date.")
            End If

            If e.Row.IsEndDtNull() = False AndAlso e.Row.EndDt < e.Row.BreakDt Then
                e.Row.SetColumnError("EndDt", "Sale end date cannot have values prior to ad date.")
            End If

            'Validate start date.
            If e.Row.IsStartDtNull() Then
                e.Row.SetColumnError("StartDt", String.Empty)
            ElseIf e.Row.IsStartDtNull() = False AndAlso e.Row.IsEndDtNull() = False Then
                If e.Row.StartDt > e.Row.EndDt Then
                    e.Row.SetColumnError("StartDt", "Start date cannot be after end date.")
                Else
                    e.Row.SetColumnError("StartDt", String.Empty)
                End If
            End If

            'Validate end date.
            If e.Row.IsEndDtNull() Then
                e.Row.SetColumnError("EndDt", String.Empty)
            ElseIf e.Row.IsStartDtNull() = False AndAlso e.Row.IsEndDtNull() Then
                If e.Row.EndDt > e.Row.BreakDt.AddDays(40) _
                  OrElse e.Row.EndDt > e.Row.StartDt.AddDays(40) _
                Then
                    e.Row.SetColumnError("EndDt", "End date seems too far from ad date or sale date.")
                End If
            End If

        End Sub

    End Class

    Protected Friend Function ValidateColumnValueAgainstDatabaseSchema _
                      (ByVal columnName As String, ByVal proposedValue As Object, ByVal row As System.Data.DataRow, ByVal throwException As Boolean) _
                      As Boolean
        Dim returnValue As Boolean
        Dim columnQuery As System.Collections.Generic.IEnumerable(Of QCDataSet.COLUMNSRow)


        returnValue = True
        'columnQuery = From cr In Columns.Rows.Cast(Of QCDataSet.COLUMNSRow)() _
        '              Select cr _
        '              Where cr.Column_Name = columnName

        'If columnQuery.Count = 0 Then
        '    columnQuery = Nothing
        '    Return returnValue
        'End If

        'If columnQuery(0).Is_Nullable.ToUpper() = "YES" AndAlso throwException = False _
        '  AndAlso (proposedValue Is Nothing OrElse (proposedValue IsNot DBNull.Value AndAlso proposedValue.ToString() = String.Empty)) _
        'Then
        '    returnValue = False
        '    If throwException = False Then row(columnName) = DBNull.Value

        'ElseIf columnQuery(0).Is_Nullable.ToUpper() = "NO" _
        '  AndAlso (proposedValue Is Nothing OrElse proposedValue Is DBNull.Value) _
        'Then
        '    Dim columnCaption As String = row.Table.Columns(columnName).Caption
        '    returnValue = False
        '    If throwException Then
        '        Throw New System.ApplicationException(columnCaption + " cannot contain blank value.")
        '    Else
        '        row.SetColumnError(columnName, columnCaption + " cannot contain blank value.")
        '    End If
        '    columnCaption = Nothing
        'End If


        Return returnValue

    End Function

    Partial Class PageCropDataTable

        Private Sub PageCropDataTable_PageCropRowChanging _
            (ByVal sender As System.Object, ByVal e As PageCropRowChangeEvent) _
            Handles Me.PageCropRowChanging

            If e.Row.RowState = DataRowState.Deleted Then Exit Sub

            'Validate start date.
            If e.Row.IsStartDtNull() = False AndAlso e.Row.IsEndDtNull() = False Then
                If e.Row.StartDt > e.Row.EndDt Then
                    e.Row.SetColumnError("StartDt", "Start date cannot be less than end date.")
                Else
                    e.Row.SetColumnError("StartDt", String.Empty)
                End If
            Else
                e.Row.SetColumnError("StartDt", String.Empty)
            End If

        End Sub

    End Class


    Partial Class AdditionalQcInformationDataTable
        ''' <summary>
        ''' Flag variable, used to determine whether the table is being filled or not.
        ''' </summary>
        ''' <remarks></remarks>
        Private m_loadingTable As Boolean

        Public Property LoadingTable() As Boolean
            Get
                Return m_loadingTable
            End Get
            Set(ByVal value As Boolean)
                m_loadingTable = value
            End Set
        End Property

        Private Sub AdditionalQcInformationDataTable_ColumnChanging _
            (ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) _
            Handles Me.ColumnChanging
            Dim columnName As String


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            columnName = e.Column.ColumnName
            CType(Me.DataSet, QCDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

        End Sub



        Private Function ValidateColumnValues _
            (ByVal validateRow As QCDataSet.AdditionalQcInformationRow, ByVal action As DataRowAction) _
            As Boolean
            Dim areAllValid As Boolean


            areAllValid = True

            'If validateRow.IsWidthNull() AndAlso validateRow.Table.Columns("Width").AllowDBNull = False Then
            '    validateRow.SetColumnError("Width", "Width is required.")
            '    areAllValid = False
            'Else
            '    validateRow.SetColumnError("Width", String.Empty)
            'End If

            'If validateRow.IsHeightNull() AndAlso validateRow.Table.Columns("Height").AllowDBNull = False Then
            '    validateRow.SetColumnError("Height", "Height is required.")
            '    areAllValid = False
            'Else
            '    validateRow.SetColumnError("Height", String.Empty)
            'End If

            Return areAllValid

        End Function


        Private Sub AdditionalQcInformationDataTable_AdditionalQcInformationRowChanging _
                (ByVal sender As Object, ByVal e As AdditionalQcInformationRowChangeEvent) _
                Handles Me.AdditionalQcInformationRowChanging
            Dim rowQuery As System.Collections.Generic.IEnumerable(Of AdditionalQcInformationRow)


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

            rowQuery = From lr In Me.Rows.Cast(Of QCDataSet.AdditionalQcInformationRow)() _
                       Select lr _
                       Where lr.Subject.ToUpper() = e.Row.Subject.ToUpper()

            If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
                e.Row.RowError = "AdditionalQcInformation name already exist. Provide unique language name."
                Throw New ApplicationException(e.Row.RowError)
            ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
                e.Row.RowError = "AdditionalQcInformation name must be unique."
                Throw New ApplicationException(e.Row.RowError)
            Else
                e.Row.RowError = String.Empty
            End If

            rowQuery = Nothing

        End Sub

    End Class






End Class

'Protected Friend Function ValidateColumnValueAgainstDatabaseSchema _
'                  (ByVal columnName As String, ByVal proposedValue As Object, ByVal row As System.Data.DataRow, ByVal throwException As Boolean) _
'                  As Boolean
'    Dim returnValue As Boolean
'    Dim columnQuery As System.Collections.Generic.IEnumerable(Of QCDataSet.COLUMNSRow)


'    returnValue = True
'    'columnQuery = From cr In Columns.Rows.Cast(Of QCDataSet.COLUMNSRow)() _
'    '              Select cr _
'    '              Where cr.Column_Name = columnName

'    'If columnQuery.Count = 0 Then
'    '    columnQuery = Nothing
'    '    Return returnValue
'    'End If

'    'If columnQuery(0).Is_Nullable.ToUpper() = "YES" AndAlso throwException = False _
'    '  AndAlso (proposedValue Is Nothing OrElse (proposedValue IsNot DBNull.Value AndAlso proposedValue.ToString() = String.Empty)) _
'    'Then
'    '    returnValue = False
'    '    If throwException = False Then row(columnName) = DBNull.Value

'    'ElseIf columnQuery(0).Is_Nullable.ToUpper() = "NO" _
'    '  AndAlso (proposedValue Is Nothing OrElse proposedValue Is DBNull.Value) _
'    'Then
'    '    Dim columnCaption As String = row.Table.Columns(columnName).Caption
'    '    returnValue = False
'    '    If throwException Then
'    '        Throw New System.ApplicationException(columnCaption + " cannot contain blank value.")
'    '    Else
'    '        row.SetColumnError(columnName, columnCaption + " cannot contain blank value.")
'    '    End If
'    '    columnCaption = Nothing
'    'End If


'    Return returnValue

'End Function


Namespace QCDataSetTableAdapters
    
    Partial Public Class vwCircularTableAdapter
    End Class
End Namespace

Namespace QCDataSetTableAdapters
    
    Partial Public Class PageTableAdapter
    End Class
End Namespace

Namespace QCDataSetTableAdapters
    
    Partial Public Class EventTableAdapter
    End Class
End Namespace

Namespace QCDataSetTableAdapters
    
    Partial Public Class RetTableAdapter
    End Class
End Namespace

Namespace QCDataSetTableAdapters
    
    Partial Public Class ImageLogTableAdapter
    End Class
End Namespace

Namespace QCDataSetTableAdapters
    
    Partial Public Class MktTableAdapter
    End Class
End Namespace
