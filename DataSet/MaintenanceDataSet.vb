﻿Partial Class MaintenanceDataSet


    Partial Class WebsitePageDownloadValuesDataTable

        Private Sub WebsitePageDownloadValuesDataTable_WebsitePageDownloadValuesRowChanging(ByVal sender As System.Object, ByVal e As WebsitePageDownloadValuesRowChangeEvent) Handles Me.WebsitePageDownloadValuesRowChanging

        End Sub

    End Class

    ''' <summary>
    ''' Validates column values based on database schema information.
    ''' </summary>
    ''' <param name="columnName">Name of column to validated.</param>
    ''' <param name="proposedValue"></param>
    ''' <param name="row"></param>
    ''' <param name="throwException">Flag that indicates when an invalid input found, raise an exception or set column error.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Friend Function ValidateColumnValueAgainstDatabaseSchema _
        (ByVal columnName As String, ByVal proposedValue As Object, ByVal row As System.Data.DataRow, ByVal throwException As Boolean) _
        As Boolean
        Dim returnValue As Boolean
        Dim columnQuery As System.Collections.Generic.IEnumerable(Of MaintenanceDataSet.COLUMNSRow)


        returnValue = True
        columnQuery = From cr In COLUMNS.Rows.Cast(Of MaintenanceDataSet.COLUMNSRow)() _
                  Select cr _
                  Where cr.Column_Name = columnName

        If columnQuery.Count = 0 Then
            columnQuery = Nothing
            Return returnValue
        End If

        If columnQuery(0).Is_Nullable.ToUpper() = "YES" AndAlso throwException = False _
          AndAlso (proposedValue Is Nothing OrElse (proposedValue IsNot DBNull.Value AndAlso proposedValue.ToString() = String.Empty)) _
        Then
            returnValue = False
            If throwException = False Then row(columnName) = DBNull.Value

        ElseIf columnQuery(0).Is_Nullable.ToUpper() = "NO" _
          AndAlso (proposedValue Is Nothing OrElse proposedValue Is DBNull.Value) _
        Then
            Dim columnCaption As String = row.Table.Columns(columnName).Caption
            returnValue = False
            If throwException Then
                Throw New System.ApplicationException(columnCaption + " cannot contain blank value.")
            Else
                row.SetColumnError(columnName, columnCaption + " cannot contain blank value.")
            End If
            columnCaption = Nothing
        End If


        Return returnValue

    End Function





    '**********************************************
    '
    ' EXPECTATION
    '
    '**********************************************
    Partial Class ExpectationDataTable

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

        ''' <summary>
        ''' Gets boolean value indicating whether specified retaler - market - media combination exist or not.
        ''' </summary>
        ''' <param name="retId"></param>
        ''' <param name="mktId"></param>
        ''' <param name="mediaId"></param>
        ''' <param name="expectationId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function IsRetailerMarketMediaCombinationUnique(ByVal retId As Integer, ByVal mktId As Integer, ByVal mediaId As Integer, ByVal expectationId As Integer) As Boolean
            Dim count As Integer?
            Dim tempAdapter As MaintenanceDataSetTableAdapters.ExpectationTableAdapter


            tempAdapter = New MaintenanceDataSetTableAdapters.ExpectationTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            count = tempAdapter.GetRetMktMediaCombinationCount(retId, mktId, mediaId, expectationId)
            tempAdapter.Dispose()

            Return (count.HasValue AndAlso count.Value = 0)

        End Function



        Private Function ValidateColumnValues _
            (ByVal validateRow As MaintenanceDataSet.ExpectationRow, ByVal action As DataRowAction) _
             As Boolean
            Dim areAllValid As Boolean


            areAllValid = True

            If validateRow.IsRetIdNull() AndAlso validateRow.Table.Columns("RetId").AllowDBNull = False Then
                validateRow.SetColumnError("RetId", "Retailer is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("RetId", String.Empty)
            End If

            If validateRow.IsMktIdNull() AndAlso validateRow.Table.Columns("MktId").AllowDBNull = False Then
                validateRow.SetColumnError("MktId", "Market is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("MktId", String.Empty)
            End If

            If validateRow.IsMediaIdNull() AndAlso validateRow.Table.Columns("MediaId").AllowDBNull = False Then
                validateRow.SetColumnError("MediaId", "Media is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("MediaId", String.Empty)
            End If

            If validateRow.IsFrequencyIdNull() AndAlso validateRow.Table.Columns("FrequencyId").AllowDBNull = False Then
                validateRow.SetColumnError("FrequencyId", "Frequency is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("FrequencyId", String.Empty)
            End If

            If validateRow.IsStartDtNull() AndAlso validateRow.Table.Columns("StartDt").AllowDBNull = False Then
                validateRow.SetColumnError("StartDt", "Start Date is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("StartDt", String.Empty)
            End If

            If validateRow.IsEndDtNull() AndAlso validateRow.Table.Columns("EndDt").AllowDBNull = False Then
                validateRow.SetColumnError("EndDt", "End Date is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("EndDt", String.Empty)
            End If

            If validateRow.IsPriorityNull() AndAlso validateRow.Table.Columns("Priority").AllowDBNull = False Then
                validateRow.SetColumnError("Priority", "Priority is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Priority", String.Empty)
            End If

            If validateRow.IsCommentsNull() AndAlso validateRow.Table.Columns("Comments").AllowDBNull = False Then
                validateRow.SetColumnError("Comments", "Comments is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Comments", String.Empty)
            End If

            If validateRow.IsFVReqIndNull() AndAlso validateRow.Table.Columns("FVReqInd").AllowDBNull = False Then
                validateRow.SetColumnError("FVReqInd", "FVReqInd is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("FVReqInd", String.Empty)
            End If

            If validateRow.IsADReqIndNull() AndAlso validateRow.Table.Columns("ADReqInd").AllowDBNull = False Then
                validateRow.SetColumnError("ADReqInd", "ADReqInd is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("ADReqInd", String.Empty)
            End If

            If validateRow.IsMissingAdCommentsNull() AndAlso validateRow.Table.Columns("MissingAdComments").AllowDBNull = False Then
                validateRow.SetColumnError("MissingAdComments", "Missing Ad Comments is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("MissingAdComments", String.Empty)
            End If

            Return areAllValid

        End Function


        Private Sub ExpectationDataTable_ColumnChanging _
            (ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) _
            Handles Me.ColumnChanging
            Dim columnName As String


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            columnName = e.Column.ColumnName
            CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

            Select Case e.Column.ColumnName.ToUpper()
                'Case "RETID"
                '  If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
                '    'e.Row.SetColumnError(e.Column, "Provide retailer.")
                '    Throw New System.ApplicationException("Provide retailer.")
                '  Else
                '    e.Row.SetColumnError(e.Column, String.Empty)
                '  End If

                'Case "MKTID"
                '  If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
                '    'e.Row.SetColumnError(e.Column, "Provide market.")
                '    Throw New System.ApplicationException("Provide market.")
                '  Else
                '    e.Row.SetColumnError(e.Column, String.Empty)
                '  End If

                'Case "MEDIAID"
                '  If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
                '    'e.Row.SetColumnError(e.Column, "Provide media.")
                '    Throw New System.ApplicationException("Provide media.")
                '  Else
                '    e.Row.SetColumnError(e.Column, String.Empty)
                '  End If

                'Case "FREQUENCY"
                '  If e.ProposedValue Is Nothing OrElse e.ProposedValue.ToString() = String.Empty Then
                '    e.ProposedValue = DBNull.Value
                '  End If

                'Case "STARTDT"
                '  If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
                '    'e.Row.SetColumnError(e.Column, "Provide start date. Every expectation must have start date.")
                '    Throw New System.ApplicationException("Provide start date. Every expectation must have start date.")
                '  Else
                '    e.Row.SetColumnError(e.Column, String.Empty)
                '  End If

                Case "PRIORITY"
                    Dim tempNumber As Integer

                    e.Row.SetColumnError(e.Column, String.Empty)
                    If e.Column.AllowDBNull = True AndAlso (e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value) Then
                        e.ProposedValue = DBNull.Value
                    ElseIf e.Column.AllowDBNull = False AndAlso (e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value) Then
                        Throw New System.ApplicationException("Priority must be specified and it has to be a valid numeric value.")
                    ElseIf Integer.TryParse(e.ProposedValue.ToString(), tempNumber) = False Then
                        Throw New System.ApplicationException("Priority has to be a valid numeric value.")
                    End If

                Case "COMMENTS"
                    e.Row.SetColumnError(e.Column, String.Empty)
                    If e.Column.AllowDBNull = False AndAlso (e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value) Then
                        Throw New System.ApplicationException("Comments cannot be blank.")
                    ElseIf e.Column.AllowDBNull = True AndAlso (e.ProposedValue Is Nothing OrElse e.ProposedValue.ToString() = String.Empty) Then
                        e.ProposedValue = DBNull.Value
                        'ElseIf e.ProposedValue.ToString().Length > e.Column.MaxLength Then
                        '  Throw New System.ApplicationException("Value specified for comments must be less than 251 characters.")
                    End If
                Case "FVREQIND"
                    Dim tempNumber As Integer

                    e.Row.SetColumnError(e.Column, String.Empty)
                    If e.Column.AllowDBNull = True AndAlso (e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value) Then
                        e.ProposedValue = DBNull.Value
                    ElseIf e.Column.AllowDBNull = False AndAlso (e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value) Then
                        Throw New System.ApplicationException("Priority must be specified and it has to be a valid numeric value.")
                    ElseIf Integer.TryParse(e.ProposedValue.ToString(), tempNumber) = False Then
                        Throw New System.ApplicationException("Priority has to be a valid numeric value.")
                    End If
                Case "ADREQIND"
                    Dim tempNumber As Integer

                    e.Row.SetColumnError(e.Column, String.Empty)
                    If e.Column.AllowDBNull = True AndAlso (e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value) Then
                        e.ProposedValue = DBNull.Value
                    ElseIf e.Column.AllowDBNull = False AndAlso (e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value) Then
                        Throw New System.ApplicationException("Priority must be specified and it has to be a valid numeric value.")
                    ElseIf Integer.TryParse(e.ProposedValue.ToString(), tempNumber) = False Then
                        Throw New System.ApplicationException("Priority has to be a valid numeric value.")
                    End If

            End Select

        End Sub

        'Private Sub ExpectationDataTable_ExpectationRowChanged _
        '    (ByVal sender As Object, ByVal e As ExpectationRowChangeEvent) _
        '    Handles Me.ExpectationRowChanged


        '  Debug.WriteLine("ExpectationDataTable_ExpectationRowChanged: Action=" + e.Action.ToString() + ", RowState=" + e.Row.RowState.ToString() + ", LoadingTable=" + Me.LoadingTable.ToString())

        '  If Not ((e.Action = DataRowAction.Change AndAlso e.Row.RowState = DataRowState.Unchanged) _
        '    OrElse (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Detached)) _
        '    OrElse Me.LoadingTable = True _
        '  Then Exit Sub

        '  If e.Row.IsPriorityNull() Then
        '    e.Row.Priority = 0
        '  End If

        '  If e.Row.IsCommentsNull() = False AndAlso e.Row.Comments.Length = 0 Then
        '    e.Row.SetCommentsNull()
        '  End If

        'End Sub

        Private Sub ExpectationDataTable_ExpectationRowChanging _
            (ByVal sender As Object, ByVal e As ExpectationRowChangeEvent) _
            Handles Me.ExpectationRowChanging
            Dim isUnique As Boolean


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            Debug.WriteLine(String.Format("ExpectationDataTable_ExpectationRowChanging: Action={0}, RowState={1}, LoadingTable={2}", e.Action, e.Row.RowState, Me.LoadingTable))

            If Not ((e.Action = DataRowAction.Change AndAlso e.Row.RowState = DataRowState.Unchanged) _
              OrElse (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Detached)) _
              OrElse Me.LoadingTable = True _
            Then Exit Sub

            If ValidateColumnValues(e.Row, e.Action) = False Then
                'e.Row.RowError = "Row contains invalid input. Please correct it to store into database."
                Throw New System.ApplicationException("Row contains invalid input. Cannot save changes.")
                Exit Sub
            End If

            isUnique = IsRetailerMarketMediaCombinationUnique(e.Row.RetId, e.Row.MktId, e.Row.MediaId, e.Row.ExpectationID)
            If isUnique = False Then
                'e.Row.RowError = "Retailer-Market-Media combination already exist. Provide unique combination."
                Throw New ApplicationException("Retailer-Market-Media combination already exist. Provide unique combination.")
            Else
                e.Row.RowError = String.Empty
            End If

        End Sub

    End Class



    '**********************************************
    '
    ' LANGUAGE
    '
    '**********************************************
    Partial Class LanguageDataTable

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
            (ByVal validateRow As MaintenanceDataSet.LanguageRow, ByVal action As DataRowAction) _
             As Boolean
            Dim areAllValid As Boolean


            areAllValid = True

            If validateRow.IsDescripNull() AndAlso validateRow.Table.Columns("Descrip").AllowDBNull = False Then
                validateRow.SetColumnError("Descrip", "Language name is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Descrip", String.Empty)
            End If

            Return areAllValid

        End Function


        Private Sub LanguageDataTable_ColumnChanging _
            (ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) _
            Handles Me.ColumnChanging
            Dim columnName As String


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            columnName = e.Column.ColumnName
            CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

            'Select Case e.Column.ColumnName.ToUpper()
            '  Case "DESCRIP"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      Throw New System.ApplicationException("Provide language name.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If
            'End Select

        End Sub

        'Private Sub LanguageDataTable_LanguageRowChanged _
        '    (ByVal sender As Object, ByVal e As LanguageRowChangeEvent) _
        '    Handles Me.LanguageRowChanged

        '  If Not ((e.Action = DataRowAction.Change AndAlso e.Row.RowState = DataRowState.Unchanged) _
        '    OrElse (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Detached)) _
        '    OrElse Me.LoadingTable = True _
        '  Then Exit Sub

        '  If e.Row.LanguageID < 0 Then
        '    Dim adapter As MaintenanceDataSetTableAdapters.LanguageTableAdapter
        '    Dim tempTable As MaintenanceDataSet.LanguageDataTable

        '    adapter = New MaintenanceDataSetTableAdapters.LanguageTableAdapter
        '    adapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '    tempTable = CType(Me.GetChanges(DataRowState.Added), MaintenanceDataSet.LanguageDataTable)
        '    adapter.Update(tempTable)
        '    Me.Merge(tempTable)

        '    adapter.Dispose()
        '    adapter = Nothing
        '    tempTable = Nothing
        '  End If

        'End Sub

        Private Sub LanguageDataTable_LanguageRowChanging _
            (ByVal sender As Object, ByVal e As LanguageRowChangeEvent) _
            Handles Me.LanguageRowChanging
            Dim rowQuery As System.Collections.Generic.IEnumerable(Of LanguageRow)


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

            rowQuery = From lr In Me.Rows.Cast(Of MaintenanceDataSet.LanguageRow)() _
                       Select lr _
                       Where lr.Descrip.ToUpper() = e.Row.Descrip.ToUpper()

            If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
                e.Row.RowError = "Language name already exist. Provide unique language name."
                Throw New ApplicationException(e.Row.RowError)
            ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
                e.Row.RowError = "Language name must be unique."
                Throw New ApplicationException(e.Row.RowError)
            Else
                e.Row.RowError = String.Empty
            End If

            rowQuery = Nothing

        End Sub

    End Class



    '**********************************************
    '
    ' MEDIA
    '
    '**********************************************
    Partial Class MediaDataTable

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
        (ByVal validateRow As MaintenanceDataSet.MediaRow, ByVal action As DataRowAction) _
         As Boolean
            Dim areAllValid As Boolean


            areAllValid = True

            If (validateRow.IsDescripNull() OrElse validateRow.Descrip.Trim().Length = 0) _
              AndAlso validateRow.Table.Columns("Descrip").AllowDBNull = False _
            Then
                validateRow.SetColumnError("Descrip", "Media name is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Descrip", String.Empty)
            End If

            Return areAllValid

        End Function


        Private Sub MediaDataTable_ColumnChanging _
            (ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) _
            Handles Me.ColumnChanging
            Dim columnName As String


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            columnName = e.Column.ColumnName
            CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

            'Select Case e.Column.ColumnName.ToUpper()
            '  Case "DESCRIP"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      Throw New System.ApplicationException("Provide Media name.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If
            'End Select

        End Sub

        'Private Sub MediaDataTable_MediaRowChanged _
        '    (ByVal sender As Object, ByVal e As MediaRowChangeEvent) _
        '    Handles Me.MediaRowChanged


        '  If Not ((e.Action = DataRowAction.Change AndAlso e.Row.RowState = DataRowState.Unchanged) _
        '    OrElse (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Detached)) _
        '    OrElse Me.LoadingTable = True _
        '  Then Exit Sub

        '  If e.Row.MediaID < 0 Then
        '    Dim adapter As MaintenanceDataSetTableAdapters.MediaTableAdapter
        '    Dim tempTable As MaintenanceDataSet.MediaDataTable


        '    adapter = New MaintenanceDataSetTableAdapters.MediaTableAdapter
        '    adapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '    tempTable = CType(Me.GetChanges(DataRowState.Added), MaintenanceDataSet.MediaDataTable)
        '    adapter.Update(tempTable)
        '    Me.Merge(tempTable)

        '    adapter.Dispose()
        '    adapter = Nothing
        '    tempTable = Nothing
        '  End If

        'End Sub

        Private Sub MediaDataTable_MediaRowChanging _
            (ByVal sender As Object, ByVal e As MediaRowChangeEvent) _
            Handles Me.MediaRowChanging
            Dim rowQuery As System.Collections.Generic.IEnumerable(Of MediaRow)


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

            rowQuery = From lr In Me.Rows.Cast(Of MaintenanceDataSet.MediaRow)() _
                       Select lr _
                       Where lr.Descrip.ToUpper() = e.Row.Descrip.ToUpper()

            If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
                e.Row.RowError = "Media name already exist. Provide unique Media name."
                Throw New ApplicationException(e.Row.RowError)
            ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
                e.Row.RowError = "Media name must be unique."
                Throw New ApplicationException(e.Row.RowError)
            Else
                e.Row.RowError = String.Empty
            End If

            rowQuery = Nothing

        End Sub


    End Class



    '**********************************************
    '
    ' TRADECLASS
    '
    '**********************************************
    Partial Class TradeclassDataTable

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
            (ByVal validateRow As MaintenanceDataSet.TradeClassRow, ByVal action As DataRowAction) _
            As Boolean
            Dim areAllValid As Boolean


            areAllValid = True

            If validateRow.IsDescripNull() AndAlso validateRow.Table.Columns("Descrip").AllowDBNull = False Then
                validateRow.SetColumnError("Descrip", "Tradeclass name is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Descrip", String.Empty)
            End If

            Return areAllValid

        End Function

        Private Sub TradeclassDataTable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            Dim columnName As String


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            columnName = e.Column.ColumnName
            CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

            'Select Case e.Column.ColumnName.ToUpper()
            '  Case "DESCRIP"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      Throw New System.ApplicationException("Provide tradeclass name.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If
            'End Select

        End Sub

        Private Sub TradeclassDataTable_TradeclassRowChanging(ByVal sender As Object, ByVal e As TradeClassRowChangeEvent) Handles Me.TradeClassRowChanging
            Dim rowQuery As System.Collections.Generic.IEnumerable(Of TradeClassRow)


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

            rowQuery = From s In Me.Rows.Cast(Of MaintenanceDataSet.TradeClassRow)() _
                       Select s _
                       Where s.Descrip = e.Row.Descrip

            If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
                e.Row.RowError = "Tradeclass must be unique. Provide unique Tradeclass."
                Throw New ApplicationException(e.Row.RowError)
            ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
                e.Row.RowError = "Tradeclass must be unique."
                Throw New ApplicationException(e.Row.RowError)
            Else
                e.Row.RowError = String.Empty
            End If

            rowQuery = Nothing

        End Sub

    End Class



    '**********************************************
    '
    ' RET
    '
    '**********************************************
    Partial Class RetDataTable

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
            (ByVal validateRow As MaintenanceDataSet.RetRow, ByVal action As DataRowAction) _
            As Boolean
            Dim areAllValid As Boolean


            areAllValid = True

            If validateRow.IsDescripNull() AndAlso validateRow.Table.Columns("Descrip").AllowDBNull = False Then
                validateRow.SetColumnError("Descrip", "Retailer name is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Descrip", String.Empty)
            End If

            If validateRow.IsTradeClassIdNull() AndAlso validateRow.Table.Columns("TradeclassId").AllowDBNull = False Then
                validateRow.SetColumnError("TradeclassId", "Tradeclass is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("TradeclassId", String.Empty)
            End If

            If validateRow.IsStartDtNull() AndAlso validateRow.Table.Columns("StartDt").AllowDBNull = False Then
                validateRow.SetColumnError("StartDt", "Start Date is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("StartDt", String.Empty)
            End If

            If validateRow.IsEndDtNull() AndAlso validateRow.Table.Columns("EndDt").AllowDBNull = False Then
                validateRow.SetColumnError("EndDt", "End Date is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("EndDt", String.Empty)
            End If

            If validateRow.IsPriorityNull() AndAlso validateRow.Table.Columns("Priority").AllowDBNull = False Then
                validateRow.SetColumnError("Priority", "Priority is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Priority", String.Empty)
            End If

            If validateRow.IsLanguageIdNull() AndAlso validateRow.Table.Columns("LanguageId").AllowDBNull = False Then
                validateRow.SetColumnError("LanguageId", "Language is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("LanguageId", String.Empty)
            End If

            Return areAllValid

        End Function


        Private Sub RetDataTable_ColumnChanging _
            (ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) _
            Handles Me.ColumnChanging
            Dim columnName As String


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            columnName = e.Column.ColumnName
            CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

            'Select Case e.Column.ColumnName.ToUpper()
            '  Case "DESCRIP"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      'e.Row.SetColumnError(e.Column, "Provide retailer.")
            '      Throw New System.ApplicationException("Provide retailer name.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If

            '  Case "TRADECLASSID"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      'e.Row.SetColumnError(e.Column, "Provide market.")
            '      Throw New System.ApplicationException("Provide tradeclass.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If

            '  Case "STARTDT"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      Throw New System.ApplicationException("Provide start date. Every retailer must have start date.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If

            'End Select

        End Sub

        'Private Sub RetDataTable_RetRowChanged _
        '    (ByVal sender As Object, ByVal e As RetRowChangeEvent) _
        '    Handles Me.RetRowChanged

        '  If (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Added) _
        '    AndAlso Me.LoadingTable = False AndAlso e.Row.RetId < 0 _
        '  Then
        '    Dim adapter As MaintenanceDataSetTableAdapters.RetTableAdapter
        '    Dim tempTable As MaintenanceDataSet.RetDataTable


        '    adapter = New MaintenanceDataSetTableAdapters.RetTableAdapter
        '    adapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '    tempTable = CType(Me.GetChanges(DataRowState.Added), MaintenanceDataSet.RetDataTable)
        '    adapter.Update(tempTable)
        '    Me.Merge(tempTable)

        '    adapter.Dispose()
        '    adapter = Nothing
        '    tempTable = Nothing
        '  End If

        'End Sub

        Private Sub RetDataTable_RetRowChanging _
            (ByVal sender As Object, ByVal e As RetRowChangeEvent) _
            Handles Me.RetRowChanging
            Dim rowQuery As System.Collections.Generic.IEnumerable(Of RetRow)


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

            rowQuery = From r In Me.Rows.Cast(Of MaintenanceDataSet.RetRow)() _
                       Select r _
                       Where r.Descrip.ToUpper() = e.Row.Descrip.ToUpper()

            If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
                e.Row.RowError = "Retailer name already exist. Provide unique Retailer name."
                Throw New ApplicationException(e.Row.RowError)
            ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
                e.Row.RowError = "Retailer name must be unique."
                Throw New ApplicationException(e.Row.RowError)
            Else
                e.Row.RowError = String.Empty
            End If

            rowQuery = Nothing

        End Sub

    End Class



    '**********************************************
    '
    ' MKT
    '
    '**********************************************
    Partial Class MktDataTable

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
            (ByVal validateRow As MaintenanceDataSet.MktRow, ByVal action As DataRowAction) _
            As Boolean
            Dim areAllValid As Boolean


            areAllValid = True

            If validateRow.IsDescripNull() AndAlso validateRow.Table.Columns("Descrip").AllowDBNull = False Then
                validateRow.SetColumnError("Descrip", "Market name is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Descrip", String.Empty)
            End If

            If validateRow.IsStartDtNull() AndAlso validateRow.Table.Columns("StartDt").AllowDBNull = False Then
                validateRow.SetColumnError("StartDt", "Start Date is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("StartDt", String.Empty)
            End If

            If validateRow.IsEndDtNull() AndAlso validateRow.Table.Columns("EndDt").AllowDBNull = False Then
                validateRow.SetColumnError("EndDt", "End Date is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("EndDt", String.Empty)
            End If


            Return areAllValid

        End Function


        Private Sub MktDataTable_ColumnChanging _
            (ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) _
            Handles Me.ColumnChanging
            Dim columnName As String


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            columnName = e.Column.ColumnName
            CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

            'Select Case e.Column.ColumnName.ToUpper()
            '  Case "DESCRIP"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      'e.Row.SetColumnError(e.Column, "Provide Market.")
            '      Throw New System.ApplicationException("Provide market name.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If

            '  Case "TRADECLASSID"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      'e.Row.SetColumnError(e.Column, "Provide market.")
            '      Throw New System.ApplicationException("Provide tradeclass.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If

            '  Case "STARTDT"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      Throw New System.ApplicationException("Provide start date. Every market must have start date.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If

            'End Select

        End Sub

        'Private Sub MktDataTable_MktRowChanged _
        '    (ByVal sender As Object, ByVal e As MktRowChangeEvent) _
        '    Handles Me.MktRowChanged

        '  If (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Added) _
        '    AndAlso Me.LoadingTable = False AndAlso e.Row.MktId < 0 _
        '  Then
        '    Dim adapter As MaintenanceDataSetTableAdapters.MktTableAdapter
        '    Dim tempTable As MaintenanceDataSet.MktDataTable


        '    adapter = New MaintenanceDataSetTableAdapters.MktTableAdapter
        '    adapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '    tempTable = CType(Me.GetChanges(DataRowState.Added), MaintenanceDataSet.MktDataTable)
        '    adapter.Update(tempTable)
        '    Me.Merge(tempTable)

        '    adapter.Dispose()
        '    adapter = Nothing
        '    tempTable = Nothing
        '  End If

        'End Sub

        Private Sub MktDataTable_MktRowChanging _
            (ByVal sender As Object, ByVal e As MktRowChangeEvent) _
            Handles Me.MktRowChanging
            Dim rowQuery As System.Collections.Generic.IEnumerable(Of MktRow)


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

            rowQuery = From r In Me.Rows.Cast(Of MaintenanceDataSet.MktRow)() _
                       Select r _
                       Where r.Descrip.ToUpper() = e.Row.Descrip.ToUpper()

            If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
                e.Row.RowError = "Market name already exist. Provide unique Market name."
                Throw New ApplicationException(e.Row.RowError)
            ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
                e.Row.RowError = "Market name must be unique."
                Throw New ApplicationException(e.Row.RowError)
            Else
                e.Row.RowError = String.Empty
            End If

            rowQuery = Nothing

        End Sub

    End Class



    '**********************************************
    '
    ' PUBLICATION
    '
    '**********************************************
    Partial Class PublicationDataTable

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
            (ByVal validateRow As MaintenanceDataSet.PublicationRow, ByVal action As DataRowAction) _
            As Boolean
            Dim areAllValid As Boolean


            areAllValid = True

            If validateRow.IsDescripNull() AndAlso validateRow.Table.Columns("Descrip").AllowDBNull = False Then
                validateRow.SetColumnError("Descrip", "Publication name is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Descrip", String.Empty)
            End If

            If validateRow.IsMktIdNull() AndAlso validateRow.Table.Columns("MktId").AllowDBNull = False Then
                validateRow.SetColumnError("MktId", "Market is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("MktId", String.Empty)
            End If

            If validateRow.IsStartDtNull() AndAlso validateRow.Table.Columns("StartDt").AllowDBNull = False Then
                validateRow.SetColumnError("StartDt", "Start date is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("StartDt", String.Empty)
            End If

            If validateRow.IsEndDtNull() AndAlso validateRow.Table.Columns("EndDt").AllowDBNull = False Then
                validateRow.SetColumnError("EndDt", "End date is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("EndDt", String.Empty)
            End If

            If validateRow.IsPriorityNull() AndAlso validateRow.Table.Columns("Priority").AllowDBNull = False Then
                validateRow.SetColumnError("Priority", "Priority is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Priority", String.Empty)
            End If

            If validateRow.IsPublishedOnNull() AndAlso validateRow.Table.Columns("PublishedOn").AllowDBNull = False Then
                validateRow.SetColumnError("PublishedOn", "Published on is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("PublishedOn", String.Empty)
            End If

            If validateRow.IsCommentsNull() AndAlso validateRow.Table.Columns("Comments").AllowDBNull = False Then
                validateRow.SetColumnError("Comments", "Comments is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Comments", String.Empty)
            End If

            Return areAllValid

        End Function


        Private Sub PublicationDataTable_ColumnChanging _
            (ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) _
            Handles Me.ColumnChanging
            Dim columnName As String


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            columnName = e.Column.ColumnName
            CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

            Select Case e.Column.ColumnName.ToUpper()
                '  Case "DESCRIP"
                '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
                '      'e.Row.SetColumnError(e.Column, "Provide Publication.")
                '      Throw New System.ApplicationException("Provide Publication name.")
                '    Else
                '      e.Row.SetColumnError(e.Column, String.Empty)
                '    End If

                '  Case "TRADECLASSID"
                '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
                '      'e.Row.SetColumnError(e.Column, "Provide publication.")
                '      Throw New System.ApplicationException("Provide tradeclass.")
                '    Else
                '      e.Row.SetColumnError(e.Column, String.Empty)
                '    End If

                '  Case "STARTDT"
                '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
                '      Throw New System.ApplicationException("Provide start date. Every publication must have start date.")
                '    Else
                '      e.Row.SetColumnError(e.Column, String.Empty)
                '    End If

                Case "PUBLISHEDON"
                    Dim publishedOn As Integer
                    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
                        Throw New System.ApplicationException("Provide Published On.")
                    ElseIf Integer.TryParse(e.ProposedValue.ToString(), publishedOn) = False Then
                        MessageBox.Show("Published On should be a numeric value and within range of 1 - 127" _
                                        , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf publishedOn < 1 OrElse publishedOn > 127 Then
                        MessageBox.Show("Published On should be within range of 1 - 127", Application.ProductName _
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        e.Row.SetColumnError(e.Column, String.Empty)
                    End If

            End Select

        End Sub

        'Private Sub PublicationDataTable_PublicationRowChanged _
        '    (ByVal sender As Object, ByVal e As PublicationRowChangeEvent) _
        '    Handles Me.PublicationRowChanged

        '  If (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Added) _
        '    AndAlso Me.LoadingTable = False AndAlso e.Row.PublicationId < 0 _
        '  Then
        '    Dim adapter As MaintenanceDataSetTableAdapters.PublicationTableAdapter
        '    Dim tempTable As MaintenanceDataSet.PublicationDataTable


        '    adapter = New MaintenanceDataSetTableAdapters.PublicationTableAdapter
        '    adapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '    tempTable = CType(Me.GetChanges(DataRowState.Added), MaintenanceDataSet.PublicationDataTable)
        '    adapter.Update(tempTable)
        '    Me.Merge(tempTable)

        '    adapter.Dispose()
        '    adapter = Nothing
        '    tempTable = Nothing
        '  End If

        'End Sub

        Private Sub PublicationDataTable_PublicationRowChanging _
            (ByVal sender As Object, ByVal e As PublicationRowChangeEvent) _
            Handles Me.PublicationRowChanging
            Dim rowQuery As System.Collections.Generic.IEnumerable(Of PublicationRow)


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

            rowQuery = From r In Me.Rows.Cast(Of MaintenanceDataSet.PublicationRow)() _
                       Select r _
                       Where r.Descrip.ToUpper() = e.Row.Descrip.ToUpper() AndAlso r.MktId = e.Row.MktId

            If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
                e.Row.RowError = "Publication name already exist. Provide unique Publication name."
                Throw New ApplicationException(e.Row.RowError)
            ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
                e.Row.RowError = "Publication name must be unique."
                Throw New ApplicationException(e.Row.RowError)
            Else
                e.Row.RowError = String.Empty
            End If

            rowQuery = Nothing

        End Sub

    End Class



    '**********************************************
    '
    ' RetMktCustomDescrip
    '
    '**********************************************
    Partial Class RetMktCustomDescripDataTable

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
            (ByVal validateRow As MaintenanceDataSet.RetMktCustomDescripRow, ByVal action As DataRowAction) _
            As Boolean
            Dim areAllValid As Boolean


            areAllValid = True

            If validateRow.IsCustomRetDescripNull() AndAlso validateRow.Table.Columns("CustomRetDescrip").AllowDBNull = False Then
                validateRow.SetColumnError("CustomRetDescrip", "Custom retailer name is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("CustomRetDescrip", String.Empty)
            End If

            If validateRow.IsCustomMktDescripNull() AndAlso validateRow.Table.Columns("CustomMktDescrip").AllowDBNull = False Then
                validateRow.SetColumnError("CustomMktDescrip", "Custom market name is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("CustomMktDescrip", String.Empty)
            End If

            'If validateRow.IsPriorityNull AndAlso validateRow.Table.Columns("Priority").AllowDBNull = False Then
            '  validateRow.SetColumnError("Priority", "Priority is required.")
            '  areAllValid = False
            'Else
            '  validateRow.SetColumnError("Priority", String.Empty)
            'End If

            If validateRow.IsApplicationNull() AndAlso validateRow.Table.Columns("Application").AllowDBNull = False Then
                validateRow.SetColumnError("Application", "Application required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Application", String.Empty)
            End If

            Return areAllValid

        End Function


        Private Sub RetMktCustomDescripDataTable_ColumnChanging _
            (ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) _
            Handles Me.ColumnChanging
            Dim columnName As String


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            columnName = e.Column.ColumnName
            CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

            'Select Case e.Column.ColumnName.ToUpper()
            '  Case "CUSTOMRETDESCRIP"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      'e.Row.SetColumnError(e.Column, "Provide retailer.")
            '      Throw New System.ApplicationException("Provide custom retailer name.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If

            '  Case "CUSTOMMKTDESCRIP"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      'e.Row.SetColumnError(e.Column, "Provide market.")
            '      Throw New System.ApplicationException("Provide custom market name.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If

            '  Case "APPLICATION"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      Throw New System.ApplicationException("Provide application name.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If

            'End Select

        End Sub

        'Private Sub RetMktCustomDescripDataTable_RetMktCustomDescripRowChanged _
        '    (ByVal sender As Object, ByVal e As RetMktCustomDescripRowChangeEvent) _
        '    Handles Me.RetMktCustomDescripRowChanged

        '  If (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Added) _
        '    AndAlso Me.LoadingTable = False AndAlso e.Row.RetId < 0 _
        '  Then
        '    Dim adapter As MaintenanceDataSetTableAdapters.RetMktCustomDescripTableAdapter
        '    Dim tempTable As MaintenanceDataSet.RetMktCustomDescripDataTable


        '    adapter = New MaintenanceDataSetTableAdapters.RetMktCustomDescripTableAdapter
        '    adapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '    tempTable = CType(Me.GetChanges(DataRowState.Added), MaintenanceDataSet.RetMktCustomDescripDataTable)
        '    adapter.Update(tempTable)
        '    Me.Merge(tempTable)

        '    adapter.Dispose()
        '    adapter = Nothing
        '    tempTable = Nothing
        '  End If

        'End Sub

        Private Sub RetMktCustomDescripDataTable_RetMktCustomDescripRowChanging _
            (ByVal sender As Object, ByVal e As RetMktCustomDescripRowChangeEvent) _
            Handles Me.RetMktCustomDescripRowChanging
            Dim rowQuery As System.Collections.Generic.IEnumerable(Of RetMktCustomDescripRow)


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            If Not ((e.Action = DataRowAction.Change AndAlso e.Row.RowState = DataRowState.Unchanged) _
              OrElse (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Detached)) _
              OrElse Me.LoadingTable = True _
            Then Exit Sub

            If ValidateColumnValues(e.Row, e.Action) Then
                e.Row.RowError = String.Empty
            Else
                'e.Row.RowError = "Row contains invalid inputs. Please correct them to store into database."
                Throw New System.ApplicationException("Row contains invalid inputs. Cannot save changes.")
                Exit Sub
            End If

            rowQuery = From r In Me.Rows.Cast(Of MaintenanceDataSet.RetMktCustomDescripRow)() _
                       Select r _
                       Where r.RetId = e.Row.RetId _
                          AndAlso r.MktId = e.Row.MktId _
                          AndAlso r.CustomRetDescrip = e.Row.CustomRetDescrip _
                          AndAlso r.CustomMktDescrip = e.Row.CustomMktDescrip _
                          AndAlso r.Application = e.Row.Application

            If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
                'e.Row.RowError = "Retailer-Market-Application combination must be unique. Provide custom retailer-market name for unique combination of retailer-market-application."
                Throw New ApplicationException(e.Row.RowError)
            ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
                'e.Row.RowError = "Retailer-Market-Application combination must be unique."
                Throw New ApplicationException(e.Row.RowError)
            Else
                e.Row.RowError = String.Empty
            End If

            rowQuery = Nothing

        End Sub

    End Class



    '**********************************************
    '
    ' RetPublicationCoverage
    '
    '**********************************************
    Partial Class RetPublicationCoverageDataTable

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
            (ByVal validateRow As MaintenanceDataSet.RetPublicationCoverageRow, ByVal action As DataRowAction) _
            As Boolean
            Dim areAllValid As Boolean


            areAllValid = True

            If validateRow.IsPriorityNull() AndAlso validateRow.Table.Columns("Priority").AllowDBNull = False Then
                validateRow.SetColumnError("Priority", "Priority is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Priority", String.Empty)
            End If

            If validateRow.IsStartDtNull() AndAlso validateRow.Table.Columns("StartDt").AllowDBNull = False Then
                validateRow.SetColumnError("StartDt", "Start date is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("StartDt", String.Empty)
            End If

            If validateRow.IsEndDtNull() AndAlso validateRow.Table.Columns("EndDt").AllowDBNull = False Then
                validateRow.SetColumnError("EndDt", "End date is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("EndDt", String.Empty)
            End If

            Return areAllValid

        End Function

        Private Sub RetPublicationCoverageDataTable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            Dim columnName As String


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            columnName = e.Column.ColumnName
            CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

            'Select Case e.Column.ColumnName.ToUpper()
            '  Case "RETID"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      Throw New System.ApplicationException("Provide retailer.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If

            '  Case "PUBLICATIONID"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      Throw New System.ApplicationException("Provide publication.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If

            '  Case "STARTDT"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      Throw New System.ApplicationException("Provide start date.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If
            'End Select

        End Sub

        'Private Sub RetPublicationCoverageDataTable_RetPublicationCoverageRowChanged(ByVal sender As Object, ByVal e As RetPublicationCoverageRowChangeEvent) Handles Me.RetPublicationCoverageRowChanged

        '  If (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Added) _
        '    AndAlso Me.LoadingTable = False AndAlso e.Row.RetId < 0 AndAlso e.Row.PublicationId < 0 _
        '  Then
        '    Dim adapter As MaintenanceDataSetTableAdapters.RetPublicationCoverageTableAdapter
        '    Dim tempTable As MaintenanceDataSet.RetPublicationCoverageDataTable


        '    adapter = New MaintenanceDataSetTableAdapters.RetPublicationCoverageTableAdapter
        '    adapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '    tempTable = CType(Me.GetChanges(DataRowState.Added), MaintenanceDataSet.RetPublicationCoverageDataTable)
        '    adapter.Update(tempTable)
        '    Me.Merge(tempTable)

        '    adapter.Dispose()
        '    adapter = Nothing
        '    tempTable = Nothing
        '  End If

        'End Sub

        Private Sub RetPublicationCoverageDataTable_RetPublicationCoverageRowChanging(ByVal sender As Object, ByVal e As RetPublicationCoverageRowChangeEvent) Handles Me.RetPublicationCoverageRowChanging
            Dim rowQuery As System.Collections.Generic.IEnumerable(Of RetPublicationCoverageRow)


            If Not ((e.Action = DataRowAction.Change AndAlso e.Row.RowState = DataRowState.Unchanged) _
              OrElse (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Detached)) _
              OrElse Me.LoadingTable = True _
            Then Exit Sub

            If ValidateColumnValues(e.Row, e.Action) Then
                e.Row.RowError = String.Empty
            Else
                'e.Row.RowError = "Row contains invalid inputs. Please correct them to store into database."
                Throw New System.ApplicationException("Row contains invalid inputs. Cannot save changes.")
                Exit Sub
            End If

            rowQuery = From rpc In Me.Rows.Cast(Of MaintenanceDataSet.RetPublicationCoverageRow)() _
                       Select rpc _
                       Where rpc.RetId = e.Row.RetId _
                          AndAlso rpc.PublicationId = e.Row.PublicationId

            If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
                'e.Row.RowError = "Retailer-Publication combination must be unique. Provide unique combination of retailer-Publication."
                Throw New ApplicationException(e.Row.RowError)
            ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
                'e.Row.RowError = "Retailer-Publication combination must be unique."
                Throw New ApplicationException(e.Row.RowError)
            Else
                e.Row.RowError = String.Empty
            End If

            rowQuery = Nothing

        End Sub


    End Class



    '**********************************************
    '
    ' Sender
    '
    '**********************************************
    Partial Class SenderDataTable

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
            (ByVal validateRow As MaintenanceDataSet.SenderRow, ByVal action As DataRowAction) _
            As Boolean
            Dim areAllValid As Boolean


            areAllValid = True

            If validateRow.IsNameNull() AndAlso validateRow.Table.Columns("Name").AllowDBNull = False Then
                validateRow.SetColumnError("Name", "Sender name is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Name", String.Empty)
            End If

            If validateRow.IsAddressNull() AndAlso validateRow.Table.Columns("Address").AllowDBNull = False Then
                validateRow.SetColumnError("Address", "Address is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Address", String.Empty)
            End If

            If validateRow.IsAddress2Null() AndAlso validateRow.Table.Columns("Address2").AllowDBNull = False Then
                validateRow.SetColumnError("Address2", "Address2 is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Address2", String.Empty)
            End If

            If validateRow.IsCityNull() AndAlso validateRow.Table.Columns("City").AllowDBNull = False Then
                validateRow.SetColumnError("City", "City is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("City", String.Empty)
            End If

            If validateRow.IsStateNull() AndAlso validateRow.Table.Columns("State").AllowDBNull = False Then
                validateRow.SetColumnError("State", "State is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("State", String.Empty)
            End If

            If validateRow.IsZipCodeNull() AndAlso validateRow.Table.Columns("ZipCode").AllowDBNull = False Then
                validateRow.SetColumnError("ZipCode", "ZipCode is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("ZipCode", String.Empty)
            End If

            If validateRow.IsCountryNull() AndAlso validateRow.Table.Columns("Country").AllowDBNull = False Then
                validateRow.SetColumnError("Country", "Country is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Country", String.Empty)
            End If

            If validateRow.IsPhoneNull() AndAlso validateRow.Table.Columns("Phone").AllowDBNull = False Then
                validateRow.SetColumnError("Phone", "Phone is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Phone", String.Empty)
            End If

            If validateRow.IsStartDtNull() AndAlso validateRow.Table.Columns("StartDt").AllowDBNull = False Then
                validateRow.SetColumnError("StartDt", "Start Date is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("StartDt", String.Empty)
            End If

            If validateRow.IsEndDtNull() AndAlso validateRow.Table.Columns("EndDt").AllowDBNull = False Then
                validateRow.SetColumnError("EndDt", "End Date is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("EndDt", String.Empty)
            End If

            If validateRow.IsPriorityNull() AndAlso validateRow.Table.Columns("Priority").AllowDBNull = False Then
                validateRow.SetColumnError("Priority", "Priority is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Priority", String.Empty)
            End If

            If validateRow.IsFrequencyIDNull() AndAlso validateRow.Table.Columns("FrequencyId").AllowDBNull = False Then
                validateRow.SetColumnError("FrequencyId", "Frequency is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("FrequencyId", String.Empty)
            End If

            If validateRow.IsExpectedReceiveDtNull() AndAlso validateRow.Table.Columns("ExpectedReceiveDt").AllowDBNull = False Then
                validateRow.SetColumnError("ExpectedReceiveDt", "Expected Weekday is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("ExpectedReceiveDt", String.Empty)
            End If

            If validateRow.IsTypeIdNull() AndAlso validateRow.Table.Columns("TypeId").AllowDBNull = False Then
                validateRow.SetColumnError("TypeId", "Specify sender type.")
                areAllValid = False
            Else
                validateRow.SetColumnError("TypeId", String.Empty)
            End If

            If validateRow.IsLocationIdNull() AndAlso validateRow.Table.Columns("TypeId").AllowDBNull = False Then
                validateRow.SetColumnError("LocationId", "Sender location is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("LocationId", String.Empty)
            End If

            If validateRow.IsIndNoShippingNull() AndAlso validateRow.Table.Columns("IndNoShipping").AllowDBNull = False Then
                validateRow.SetColumnError("IndNoShipping", "Specify whether shipping is available or not.")
                areAllValid = False
            Else
                validateRow.SetColumnError("IndNoShipping", String.Empty)
            End If

            If validateRow.IsIndNoPublicationsNull() AndAlso validateRow.Table.Columns("IndNoPublications").AllowDBNull = False Then
                validateRow.SetColumnError("IndNoPublications", "Specify whether publications are available or not.")
                areAllValid = False
            Else
                validateRow.SetColumnError("IndNoPublications", String.Empty)
            End If

            Return areAllValid

        End Function

        Private Sub SenderDataTable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            Dim columnName As String


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            columnName = e.Column.ColumnName
            CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

            Select Case e.Column.ColumnName.ToUpper()
                '  Case "NAME"
                '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
                '      Throw New System.ApplicationException("Provide Sender name.")
                '    Else
                '      e.Row.SetColumnError(e.Column, String.Empty)
                '    End If

                Case "PRIORITY"
                    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
                        e.ProposedValue = 0
                    End If

                    '  Case "STARTDT"
                    'If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
                    '  Throw New System.ApplicationException("Provide start date.")
                    'Else
                    '  e.Row.SetColumnError(e.Column, String.Empty)
                    'End If
            End Select

        End Sub

        'Private Sub SenderDataTable_SenderRowChanged(ByVal sender As Object, ByVal e As SenderRowChangeEvent) Handles Me.SenderRowChanged

        '  If (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Added) _
        '    AndAlso Me.LoadingTable = False AndAlso e.Row.RetId < 0 AndAlso e.Row.PublicationId < 0 _
        '  Then
        '    Dim adapter As MaintenanceDataSetTableAdapters.SenderTableAdapter
        '    Dim tempTable As MaintenanceDataSet.SenderDataTable


        '    adapter = New MaintenanceDataSetTableAdapters.SenderTableAdapter
        '    adapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '    tempTable = CType(Me.GetChanges(DataRowState.Added), MaintenanceDataSet.SenderDataTable)
        '    adapter.Update(tempTable)
        '    Me.Merge(tempTable)

        '    adapter.Dispose()
        '    adapter = Nothing
        '    tempTable = Nothing
        '  End If

        'End Sub

        Private Sub SenderDataTable_SenderRowChanging(ByVal sender As Object, ByVal e As SenderRowChangeEvent) Handles Me.SenderRowChanging
            Dim rowQuery As System.Collections.Generic.IEnumerable(Of SenderRow)


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

            rowQuery = From sr In Me.Rows.Cast(Of MaintenanceDataSet.SenderRow)() _
                       Where sr.Name = e.Row.Name AndAlso (sr.IsLocationIdNull() OrElse e.Row.IsLocationIdNull() OrElse sr.LocationId = e.Row.LocationId) _
                       Select sr

            If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
                'e.Row.RowError = "Sender name must be unique. Provide unique sender name."
                Throw New ApplicationException("Sender name must be unique. Provide unique sender name.")
            ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
                'e.Row.RowError = "Sender name must be unique."
                Throw New ApplicationException("Sender name must be unique.")
            Else
                e.Row.RowError = String.Empty
            End If

            rowQuery = Nothing

        End Sub


    End Class



    '**********************************************
    '
    ' SenderMktAssoc
    '
    '**********************************************
    Partial Class SenderMktAssocDataTable

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



        Private Sub SenderMktAssocDataTable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            Dim columnName As String


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            columnName = e.Column.ColumnName
            CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

            'Select Case e.Column.ColumnName.ToUpper()
            '  Case "SENDERID"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      Throw New System.ApplicationException("Provide Sender.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If

            '  Case "MKTID"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      Throw New System.ApplicationException("Provide Market.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If
            'End Select

        End Sub

        Private Sub SenderMktAssocDataTable_SenderMktAssocRowChanging(ByVal sender As Object, ByVal e As SenderMktAssocRowChangeEvent) Handles Me.SenderMktAssocRowChanging
            Dim rowQuery As System.Collections.Generic.IEnumerable(Of SenderMktAssocRow)


            If Not ((e.Action = DataRowAction.Change AndAlso e.Row.RowState = DataRowState.Unchanged) _
              OrElse (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Detached)) _
              OrElse Me.LoadingTable = True _
            Then Exit Sub

            rowQuery = From smar In Me.Rows.Cast(Of MaintenanceDataSet.SenderMktAssocRow)() _
                       Select smar _
                       Where smar.SenderId = e.Row.SenderId _
                          AndAlso smar.MktId = e.Row.MktId

            If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
                'e.Row.RowError = "Sender-Market association must be unique. Provide unique Sender-Market association."
                Throw New ApplicationException(e.Row.RowError)
            ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
                'e.Row.RowError = "Sender-Market association must be unique."
                Throw New ApplicationException(e.Row.RowError)
            Else
                e.Row.RowError = String.Empty
            End If

            rowQuery = Nothing

        End Sub

    End Class

    '**********************************************
    '
    ' SenderPublication
    '
    '**********************************************
    Partial Class SenderPublicationDataTable

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



        Private Sub SenderPublicationDataTable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            Dim columnName As String


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            columnName = e.Column.ColumnName
            CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

        End Sub

        Private Sub SenderPublicationDataTable_SenderPublicationRowChanging(ByVal sender As Object, ByVal e As SenderPublicationRowChangeEvent) Handles Me.SenderPublicationRowChanging
            Dim rowQuery As System.Collections.Generic.IEnumerable(Of SenderPublicationRow)


            If Not ((e.Action = DataRowAction.Change AndAlso e.Row.RowState = DataRowState.Unchanged) _
              OrElse (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Detached)) _
              OrElse Me.LoadingTable = True _
            Then Exit Sub

            rowQuery = From smar In Me.Rows.Cast(Of MaintenanceDataSet.SenderPublicationRow)() _
                       Select smar _
                       Where smar.SenderId = e.Row.SenderId _
                          AndAlso smar.PublicationId = e.Row.PublicationId

            If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
                'e.Row.RowError = "Sender-Market association must be unique. Provide unique Sender-Publication association."
                Throw New ApplicationException(e.Row.RowError)
            ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
                'e.Row.RowError = "Sender-Publication association must be unique."
                Throw New ApplicationException(e.Row.RowError)
            Else
                e.Row.RowError = String.Empty
            End If

            rowQuery = Nothing

        End Sub

    End Class

    '**********************************************
    '
    ' SenderExpection
    '
    '**********************************************
    Partial Class SenderExpectationDataTable

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



        Private Sub SenderExpectationDataTable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            Dim columnName As String


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            columnName = e.Column.ColumnName
            CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

        End Sub

        Private Sub SenderExpectationDataTable_SenderExpectationnRowChanging(ByVal sender As Object, ByVal e As SenderExpectationRowChangeEvent) Handles Me.SenderExpectationRowChanging
            Dim rowQuery As System.Collections.Generic.IEnumerable(Of SenderExpectationRow)


            If Not ((e.Action = DataRowAction.Change AndAlso e.Row.RowState = DataRowState.Unchanged) _
              OrElse (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Detached)) _
              OrElse Me.LoadingTable = True _
            Then Exit Sub

            rowQuery = From smar In Me.Rows.Cast(Of MaintenanceDataSet.SenderExpectationRow)() _
                       Select smar _
                       Where smar.SenderId = e.Row.SenderId _
                          AndAlso smar.ExpectationID = e.Row.ExpectationID

            If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
                'e.Row.RowError = "Sender-Expectation association must be unique. Provide unique Sender-Expectation association."
                Throw New ApplicationException(e.Row.RowError)
            ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
                'e.Row.RowError = "Sender-Expectation association must be unique."
                Throw New ApplicationException(e.Row.RowError)
            Else
                e.Row.RowError = String.Empty
            End If

            rowQuery = Nothing

        End Sub

    End Class


    '**********************************************
    '
    ' Shipper
    '
    '**********************************************
    Partial Class ShipperDataTable

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
            (ByVal validateRow As MaintenanceDataSet.ShipperRow, ByVal action As DataRowAction) _
            As Boolean
            Dim areAllValid As Boolean


            areAllValid = True

            If (validateRow.IsDescripNull() OrElse validateRow.Descrip.Trim().Length = 0) _
              AndAlso validateRow.Table.Columns("Descrip").AllowDBNull = False _
            Then
                validateRow.SetColumnError("Descrip", "Name is required.")
                areAllValid = False
            Else
                validateRow.SetColumnError("Descrip", String.Empty)
            End If

            If validateRow.IsIndNeedTrackingNoNull() _
              AndAlso validateRow.Table.Columns("IndNeedTrackingNo").AllowDBNull = False _
            Then
                validateRow.SetColumnError("IndNeedTrackingNo", "Specify whether Tracking number is required or not.")
                areAllValid = False
            Else
                validateRow.SetColumnError("IndNeedTrackingNo", String.Empty)
            End If

            Return areAllValid

        End Function

        Private Sub ShipperDataTable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            Dim columnName As String


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            columnName = e.Column.ColumnName
            CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

            'Select Case e.Column.ColumnName.ToUpper()
            '  Case "DESCRIP"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      Throw New System.ApplicationException("Provide Sender.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If
            'End Select

        End Sub

        Private Sub ShipperDataTable_ShipperRowChanging(ByVal sender As Object, ByVal e As ShipperRowChangeEvent) Handles Me.ShipperRowChanging
            Dim rowQuery As System.Collections.Generic.IEnumerable(Of ShipperRow)


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

            rowQuery = From s In Me.Rows.Cast(Of MaintenanceDataSet.ShipperRow)() _
                       Select s _
                       Where s.Descrip = e.Row.Descrip

            If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
                'e.Row.RowError = "Shipper must be unique. Provide unique Shipper."
                Throw New ApplicationException(e.Row.RowError)
            ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
                'e.Row.RowError = "Shipper must be unique."
                Throw New ApplicationException(e.Row.RowError)
            Else
                e.Row.RowError = String.Empty
            End If

            rowQuery = Nothing

        End Sub


    End Class



    '**********************************************
    '
    ' Size
    '
    '**********************************************
    Partial Class SizeDataTable

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
            (ByVal validateRow As MaintenanceDataSet.SizeRow, ByVal action As DataRowAction) _
            As Boolean
            Dim areAllValid As Boolean


            areAllValid = True

            'If validateRow.IsWidthNull() AndAlso validateRow.Table.Columns("Width").AllowDBNull = False Then
            '  validateRow.SetColumnError("Width", "Width is required.")
            '  areAllValid = False
            'Else
            '  validateRow.SetColumnError("Width", String.Empty)
            'End If

            'If validateRow.IsHeightNull() AndAlso validateRow.Table.Columns("Height").AllowDBNull = False Then
            '  validateRow.SetColumnError("Height", "Height is required.")
            '  areAllValid = False
            'Else
            '  validateRow.SetColumnError("Height", String.Empty)
            'End If

            Return areAllValid

        End Function

        Private Sub SizeDataTable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            Dim columnName As String


            'To avoid executing this event for tables created using GetChange method of DataTable.
            If Me.DataSet Is Nothing Then Exit Sub

            columnName = e.Column.ColumnName
            CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

            'Select Case e.Column.ColumnName.ToUpper()
            '  Case "WIDTH"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      Throw New System.ApplicationException("Provide width.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If

            '  Case "HEIGHT"
            '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
            '      Throw New System.ApplicationException("Provide height.")
            '    Else
            '      e.Row.SetColumnError(e.Column, String.Empty)
            '    End If
            'End Select

        End Sub

        Private Sub SizeDataTable_SizeRowChanging(ByVal sender As Object, ByVal e As SizeRowChangeEvent) Handles Me.SizeRowChanging
            Dim rowQuery As System.Collections.Generic.IEnumerable(Of SizeRow)


            'If Not ((e.Action = DataRowAction.Change AndAlso e.Row.RowState = DataRowState.Unchanged) _
            '  OrElse (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Detached)) _
            '  OrElse Me.LoadingTable = True _
            'Then Exit Sub

            'If ValidateColumnValues(e.Row, e.Action) Then
            '  e.Row.RowError = String.Empty
            'Else
            '  'e.Row.RowError = "Row contains invalid input. Please correct them to store into database."
            '  Throw New System.ApplicationException("Row contains invalid input. Cannot save changes.")
            '  Exit Sub
            'End If

            'rowQuery = From s In Me.Rows.Cast(Of MaintenanceDataSet.SizeRow)() _
            '           Select s _
            '           Where s.Width = e.Row.Width AndAlso s.Height = e.Row.Height

            'If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
            '  'e.Row.RowError = "Size must be unique. Provide unique Size."
            '  Throw New ApplicationException(e.Row.RowError)
            'ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
            '  'e.Row.RowError = "Size must be unique."
            '  Throw New ApplicationException(e.Row.RowError)
            'Else
            '  e.Row.RowError = String.Empty
            'End If

            rowQuery = Nothing

        End Sub

    End Class

    '**********************************************
    '
    ' Website
    '
    '**********************************************
    Partial Class WebsitePageDownloadDataTable

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
            (ByVal validateRow As MaintenanceDataSet.WebsitePageDownloadRow, ByVal action As DataRowAction) _
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

        'Private Sub SizeDataTable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
        '    Dim columnName As String


        '    'To avoid executing this event for tables created using GetChange method of DataTable.
        '    If Me.DataSet Is Nothing Then Exit Sub

        '    columnName = e.Column.ColumnName
        '    CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

        '    'Select Case e.Column.ColumnName.ToUpper()
        '    '  Case "WIDTH"
        '    '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
        '    '      Throw New System.ApplicationException("Provide width.")
        '    '    Else
        '    '      e.Row.SetColumnError(e.Column, String.Empty)
        '    '    End If

        '    '  Case "HEIGHT"
        '    '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
        '    '      Throw New System.ApplicationException("Provide height.")
        '    '    Else
        '    '      e.Row.SetColumnError(e.Column, String.Empty)
        '    '    End If
        '    'End Select

        'End Sub

        'Private Sub SizeDataTable_SizeRowChanging(ByVal sender As Object, ByVal e As SizeRowChangeEvent) Handles Me.SizeRowChanging
        '    Dim rowQuery As System.Collections.Generic.IEnumerable(Of SizeRow)


        '    If Not ((e.Action = DataRowAction.Change AndAlso e.Row.RowState = DataRowState.Unchanged) _
        '      OrElse (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Detached)) _
        '      OrElse Me.LoadingTable = True _
        '    Then Exit Sub

        '    If ValidateColumnValues(e.Row, e.Action) Then
        '        e.Row.RowError = String.Empty
        '    Else
        '        'e.Row.RowError = "Row contains invalid input. Please correct them to store into database."
        '        Throw New System.ApplicationException("Row contains invalid input. Cannot save changes.")
        '        Exit Sub
        '    End If

        '    rowQuery = From s In Me.Rows.Cast(Of MaintenanceDataSet.SizeRow)() _
        '               Select s _
        '               Where s.Width = e.Row.Width AndAlso s.Height = e.Row.Height

        '    If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
        '        'e.Row.RowError = "Size must be unique. Provide unique Size."
        '        Throw New ApplicationException(e.Row.RowError)
        '    ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
        '        'e.Row.RowError = "Size must be unique."
        '        Throw New ApplicationException(e.Row.RowError)
        '    Else
        '        e.Row.RowError = String.Empty
        '    End If

        '    rowQuery = Nothing

        'End Sub

        Private Sub WebsitePageDownloadDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            'If (e.Column.ColumnName = Me.ForceRunIndColumn.ColumnName) Then
            '    'Add user code here
            'End If

        End Sub

    End Class

    Partial Class SiteDataTable

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
            (ByVal validateRow As MaintenanceDataSet.SiteRow, ByVal action As DataRowAction) _
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

        'Private Sub SizeDataTable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
        '    Dim columnName As String


        '    'To avoid executing this event for tables created using GetChange method of DataTable.
        '    If Me.DataSet Is Nothing Then Exit Sub

        '    columnName = e.Column.ColumnName
        '    CType(Me.DataSet, MaintenanceDataSet).ValidateColumnValueAgainstDatabaseSchema(columnName, e.ProposedValue, e.Row, False)

        '    'Select Case e.Column.ColumnName.ToUpper()
        '    '  Case "WIDTH"
        '    '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
        '    '      Throw New System.ApplicationException("Provide width.")
        '    '    Else
        '    '      e.Row.SetColumnError(e.Column, String.Empty)
        '    '    End If

        '    '  Case "HEIGHT"
        '    '    If e.ProposedValue Is Nothing OrElse e.ProposedValue Is DBNull.Value Then
        '    '      Throw New System.ApplicationException("Provide height.")
        '    '    Else
        '    '      e.Row.SetColumnError(e.Column, String.Empty)
        '    '    End If
        '    'End Select

        'End Sub

        'Private Sub SizeDataTable_SizeRowChanging(ByVal sender As Object, ByVal e As SizeRowChangeEvent) Handles Me.SizeRowChanging
        '    Dim rowQuery As System.Collections.Generic.IEnumerable(Of SizeRow)


        '    If Not ((e.Action = DataRowAction.Change AndAlso e.Row.RowState = DataRowState.Unchanged) _
        '      OrElse (e.Action = DataRowAction.Add AndAlso e.Row.RowState = DataRowState.Detached)) _
        '      OrElse Me.LoadingTable = True _
        '    Then Exit Sub

        '    If ValidateColumnValues(e.Row, e.Action) Then
        '        e.Row.RowError = String.Empty
        '    Else
        '        'e.Row.RowError = "Row contains invalid input. Please correct them to store into database."
        '        Throw New System.ApplicationException("Row contains invalid input. Cannot save changes.")
        '        Exit Sub
        '    End If

        '    rowQuery = From s In Me.Rows.Cast(Of MaintenanceDataSet.SizeRow)() _
        '               Select s _
        '               Where s.Width = e.Row.Width AndAlso s.Height = e.Row.Height

        '    If e.Action = DataRowAction.Add AndAlso rowQuery.Count > 0 Then
        '        'e.Row.RowError = "Size must be unique. Provide unique Size."
        '        Throw New ApplicationException(e.Row.RowError)
        '    ElseIf e.Action = DataRowAction.Change AndAlso rowQuery.Count > 1 Then
        '        'e.Row.RowError = "Size must be unique."
        '        Throw New ApplicationException(e.Row.RowError)
        '    Else
        '        e.Row.RowError = String.Empty
        '    End If

        '    rowQuery = Nothing

        'End Sub

        Private Sub WebsitePageDownloadDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.NameColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class


End Class


Namespace MaintenanceDataSetTableAdapters


    Partial Class MarketListTableAdapter

    End Class

    Partial Public Class ExpectationTableAdapter

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, False)> _
        Public Overridable Overloads Function FillByWhereClause(ByVal dataTable As MaintenanceDataSet.ExpectationDataTable, ByVal whereClause As String) As Integer
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(2)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
            End With
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return returnValue
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Overridable Overloads Function GetDataByWhereClause(ByVal whereClause As String) As MaintenanceDataSet.ExpectationDataTable
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(1)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
            End With
            Dim dataTable As MaintenanceDataSet.ExpectationDataTable = New MaintenanceDataSet.ExpectationDataTable
            Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return dataTable
        End Function

    End Class


    Partial Public Class RetTableAdapter

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, False)> _
        Public Overridable Overloads Function FillByWhereClause(ByVal dataTable As MaintenanceDataSet.RetDataTable, ByVal whereClause As String) As Integer
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(2)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
            End With
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return returnValue
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Overridable Overloads Function GetDataByWhereClause(ByVal whereClause As String) As MaintenanceDataSet.RetDataTable
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(1)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
            End With
            Dim dataTable As MaintenanceDataSet.RetDataTable = New MaintenanceDataSet.RetDataTable
            Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return dataTable
        End Function

    End Class


    Partial Public Class MktTableAdapter

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, False)> _
        Public Overridable Overloads Function FillByWhereClause(ByVal dataTable As MaintenanceDataSet.MktDataTable, ByVal whereClause As String) As Integer
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(2)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
            End With
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return returnValue
        End Function

        '<Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
        ' Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
        ' Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        'Public Overridable Overloads Function GetDataByWhereClause(ByVal whereClause As String) As MaintenanceDataSet.MktDataTable
        '  Dim tempCmdText As String
        '  Me.Adapter.SelectCommand = Me.CommandCollection(1)
        '  With Me.Adapter.SelectCommand
        '    tempCmdText = .CommandText
        '    .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
        '  End With
        '  Dim dataTable As MaintenanceDataSet.MktDataTable = New MaintenanceDataSet.MktDataTable
        '  Me.Adapter.Fill(dataTable)
        '  Me.Adapter.SelectCommand.CommandText = tempCmdText
        '  Return dataTable
        'End Function

    End Class


    Partial Public Class PublicationTableAdapter

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, False)> _
        Public Overridable Overloads Function FillByWhereClause(ByVal dataTable As MaintenanceDataSet.PublicationDataTable, ByVal whereClause As String) As Integer
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(1)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
            End With
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return returnValue
        End Function

        '<Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
        ' Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
        ' Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        'Public Overridable Overloads Function GetDataByWhereClause(ByVal whereClause As String) As MaintenanceDataSet.PublicationDataTable
        '  Dim tempCmdText As String
        '  Me.Adapter.SelectCommand = Me.CommandCollection(1)
        '  With Me.Adapter.SelectCommand
        '    tempCmdText = .CommandText
        '    .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
        '  End With
        '  Dim dataTable As MaintenanceDataSet.PublicationDataTable = New MaintenanceDataSet.PublicationDataTable
        '  Me.Adapter.Fill(dataTable)
        '  Me.Adapter.SelectCommand.CommandText = tempCmdText
        '  Return dataTable
        'End Function

    End Class


    Partial Public Class RetMktCustomDescripTableAdapter

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, False)> _
        Public Overridable Overloads Function FillByWhereClause(ByVal dataTable As MaintenanceDataSet.RetMktCustomDescripDataTable, ByVal whereClause As String) As Integer
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(1)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
            End With
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return returnValue
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Overridable Overloads Function GetDataByWhereClause(ByVal whereClause As String) As MaintenanceDataSet.RetMktCustomDescripDataTable
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(1)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
            End With
            Dim dataTable As MaintenanceDataSet.RetMktCustomDescripDataTable = New MaintenanceDataSet.RetMktCustomDescripDataTable
            Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return dataTable
        End Function

    End Class


    Partial Public Class RetPublicationCoverageTableAdapter

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, False)> _
        Public Overridable Overloads Function FillByWhereClause(ByVal dataTable As MaintenanceDataSet.RetPublicationCoverageDataTable, ByVal whereClause As String) As Integer
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(1)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
            End With
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return returnValue
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Overridable Overloads Function GetDataByWhereClause(ByVal whereClause As String) As MaintenanceDataSet.RetPublicationCoverageDataTable
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(1)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
            End With
            Dim dataTable As MaintenanceDataSet.RetPublicationCoverageDataTable = New MaintenanceDataSet.RetPublicationCoverageDataTable
            Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return dataTable
        End Function

    End Class


    Partial Public Class SenderTableAdapter

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, False)> _
        Public Overridable Overloads Function FillByWhereClause(ByVal dataTable As MaintenanceDataSet.SenderDataTable, ByVal locationId As Integer, ByVal whereClause As String) As Integer
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(1)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
                'If .Parameters.Contains("@LocationId") = False Then
                '  .Parameters.Add("@LocationId", SqlDbType.Int)
                'End If
                '.Parameters("@LocationId").Value = locationId
            End With
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return returnValue
        End Function

        '<Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
        ' Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
        ' Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        'Public Overridable Overloads Function GetDataByWhereClause(ByVal whereClause As String) As MaintenanceDataSet.SenderDataTable
        '  Dim tempCmdText As String
        '  Me.Adapter.SelectCommand = Me.CommandCollection(1)
        '  With Me.Adapter.SelectCommand
        '    tempCmdText = .CommandText
        '    .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
        '  End With
        '  Dim dataTable As MaintenanceDataSet.SenderDataTable = New MaintenanceDataSet.SenderDataTable
        '  Me.Adapter.Fill(dataTable)
        '  Me.Adapter.SelectCommand.CommandText = tempCmdText
        '  Return dataTable
        'End Function

    End Class


    Partial Public Class SenderMktAssocTableAdapter

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, False)> _
        Public Overridable Overloads Function FillByWhereClause(ByVal dataTable As MaintenanceDataSet.SenderMktAssocDataTable, ByVal locationId As Integer, ByVal whereClause As String) As Integer
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(1)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
                'If .Parameters.Contains("@LocationId") = False Then
                '  .Parameters.Add("@LocationId", SqlDbType.Int)
                'End If
                '.Parameters("@LocationId").Value = locationId
            End With
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return returnValue
        End Function

        '<Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
        ' Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
        ' Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        'Public Overridable Overloads Function GetDataByWhereClause(ByVal whereClause As String) As MaintenanceDataSet.SenderMktAssocDataTable
        '  Dim tempCmdText As String
        '  Me.Adapter.SelectCommand = Me.CommandCollection(1)
        '  With Me.Adapter.SelectCommand
        '    tempCmdText = .CommandText
        '    .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
        '  End With
        '  Dim dataTable As MaintenanceDataSet.SenderMktAssocDataTable = New MaintenanceDataSet.SenderMktAssocDataTable
        '  Me.Adapter.Fill(dataTable)
        '  Me.Adapter.SelectCommand.CommandText = tempCmdText
        '  Return dataTable
        'End Function

    End Class


    Partial Public Class ShipperTableAdapter

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, False)> _
        Public Overridable Overloads Function FillByWhereClause(ByVal dataTable As MaintenanceDataSet.ShipperDataTable, ByVal whereClause As String) As Integer
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(1)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
            End With
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return returnValue
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Overridable Overloads Function GetDataByWhereClause(ByVal whereClause As String) As MaintenanceDataSet.ShipperDataTable
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(1)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
            End With
            Dim dataTable As MaintenanceDataSet.ShipperDataTable = New MaintenanceDataSet.ShipperDataTable
            Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return dataTable
        End Function

    End Class


    Partial Public Class SizeTableAdapter

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, False)> _
        Public Overridable Overloads Function FillByWhereClause(ByVal dataTable As MaintenanceDataSet.SizeDataTable, ByVal whereClause As String) As Integer
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(1)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
            End With
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return returnValue
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Overridable Overloads Function GetDataByWhereClause(ByVal whereClause As String) As MaintenanceDataSet.SizeDataTable
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(1)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
            End With
            Dim dataTable As MaintenanceDataSet.SizeDataTable = New MaintenanceDataSet.SizeDataTable
            Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return dataTable
        End Function

    End Class


    Partial Public Class TradeClassTableAdapter

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, False)> _
        Public Overridable Overloads Function FillByWhereClause(ByVal dataTable As MaintenanceDataSet.TradeClassDataTable, ByVal whereClause As String) As Integer
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(1)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
            End With
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return returnValue
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Overridable Overloads Function GetDataByWhereClause(ByVal whereClause As String) As MaintenanceDataSet.TradeClassDataTable
            Dim tempCmdText As String
            Me.Adapter.SelectCommand = Me.CommandCollection(1)
            With Me.Adapter.SelectCommand
                tempCmdText = .CommandText
                .CommandText = .CommandText.Replace("#WhereClause#", whereClause)
            End With
            Dim dataTable As MaintenanceDataSet.TradeClassDataTable = New MaintenanceDataSet.TradeClassDataTable
            Me.Adapter.Fill(dataTable)
            Me.Adapter.SelectCommand.CommandText = tempCmdText
            Return dataTable
        End Function

    End Class


End Namespace


Namespace MaintenanceDataSetTableAdapters

    Partial Public Class WebsitePageDownloadTableAdapter
    End Class
End Namespace

Namespace MaintenanceDataSetTableAdapters

    Partial Public Class SenderPublicationTableAdapter
    End Class
End Namespace

Namespace MaintenanceDataSetTableAdapters

    Partial Public Class SenderExpectationTableAdapter
    End Class
End Namespace

Namespace MaintenanceDataSetTableAdapters

    Partial Public Class RetailersTableAdapter
    End Class
End Namespace
