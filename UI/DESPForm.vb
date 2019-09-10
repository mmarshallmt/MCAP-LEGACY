Namespace UI

  Public Class DESPForm
    Implements IForm


    Private WithEvents m_processor As UI.Processors.DESP


    Private ReadOnly Property Processor() As UI.Processors.DESP
      Get
        Return m_processor
      End Get
    End Property


#Region " IForm Implementation "


    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event FormInitialized() Implements IForm.FormInitialized
    Public Event InitializingForm() Implements IForm.InitializingForm
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied


    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

    End Sub

    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

      Me.SuspendLayout()

      RaiseEvent InitializingForm()

      m_processor = New UI.Processors.DESP()
            Processor.LoadStoredProcedureList(User.UserID)

      RemoveHandler storedprocedureComboBox.SelectedValueChanged, AddressOf storedprocedureComboBox_SelectedValueChanged
      storedprocedureComboBox.DisplayMember = "FriendlyName"
      storedprocedureComboBox.ValueMember = "StoredProcedureId"
      storedprocedureComboBox.DataSource = Me.Processor.Data.DESP_StoredProcedure
      storedprocedureComboBox.SelectedValue = DBNull.Value
      AddHandler storedprocedureComboBox.SelectedValueChanged, AddressOf storedprocedureComboBox_SelectedValueChanged

      RaiseEvent FormInitialized()

      Me.ResumeLayout()

    End Sub


#End Region


        Private Sub ResetDataGridView()

            parameterDataGridView.DataSource = Nothing
            parameterDataGridView.Columns.Clear()
            parameterDataGridView.DataSource = Me.Processor.Data.ParameterDetails

            For i As Integer = 0 To parameterDataGridView.Columns.Count - 1
                parameterDataGridView.Columns(i).Visible = False
            Next

            With parameterDataGridView.Columns("Parameter_Name")
                .HeaderText = "Parameter Name"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
                .Visible = True
            End With

            With parameterDataGridView.Columns("Parameter_Value")
                .HeaderText = "Value"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .ReadOnly = False
                .Visible = True
            End With

            With parameterDataGridView.Columns("Data_Type")
                .HeaderText = "Data Type"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
                .Visible = True
            End With

            With parameterDataGridView.Columns("Data_Length")
                .HeaderText = "Length"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .ReadOnly = True
                .Visible = True
            End With

            With parameterDataGridView.Columns("PropertyValue")
                .HeaderText = "Description"
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .ReadOnly = True
                .Visible = True
            End With

        End Sub


#Region " Methods for validating value based on data type of parameter "


    Private Function IsValidBoolean(ByVal value As Object) As Boolean
      Dim temp, isValid As Boolean


      If value Is Nothing Then Return False
      isValid = Boolean.TryParse(value.ToString(), temp)
      temp = Nothing

      Return isValid

    End Function

    Private Function IsValidByte(ByVal value As Object) As Boolean
      Dim isValid As Boolean
      Dim temp As Byte


      If value Is Nothing Then Return False
      isValid = Byte.TryParse(value.ToString(), temp)
      temp = Nothing

      Return isValid

    End Function

    Private Function IsValidSmallInteger(ByVal value As Object) As Boolean
      Dim isValid As Boolean
      Dim temp As Int16


      If value Is Nothing Then Return False
      isValid = Int16.TryParse(value.ToString(), temp)
      temp = Nothing

      Return isValid

    End Function

    Private Function IsValidInteger(ByVal value As Object) As Boolean
      Dim isValid As Boolean
      Dim temp As Integer


      If value Is Nothing Then Return False
      isValid = Integer.TryParse(value.ToString(), temp)
      temp = Nothing

      Return isValid

    End Function

    Private Function IsValidLong(ByVal value As Object) As Boolean
      Dim isValid As Boolean
      Dim temp As Long


      If value Is Nothing Then Return False
      isValid = Long.TryParse(value.ToString(), temp)
      temp = Nothing

      Return isValid

    End Function

    Private Function IsValidSingle(ByVal value As Object) As Boolean
      Dim isValid As Boolean
      Dim temp As Single


      If value Is Nothing Then Return False
      isValid = Single.TryParse(value.ToString(), temp)
      temp = Nothing

      Return isValid

    End Function

    Private Function IsValidDouble(ByVal value As Object) As Boolean
      Dim isValid As Boolean
      Dim temp As Double


      If value Is Nothing Then Return False
      isValid = Double.TryParse(value.ToString(), temp)
      temp = Nothing

      Return isValid

    End Function

    Private Function IsValidDecimal(ByVal value As Object) As Boolean
      Dim isValid As Boolean
      Dim temp As Decimal


      If value Is Nothing Then Return False
      isValid = Decimal.TryParse(value.ToString(), temp)
      temp = Nothing

      Return isValid

    End Function

    Private Function IsValidDateTime(ByVal value As Object) As Boolean
      Dim isValid As Boolean
      Dim temp As DateTime


      If value Is Nothing Then Return False
      isValid = DateTime.TryParse(value.ToString(), temp)
      temp = Nothing

      Return isValid

    End Function

    Private Function ValidateParameterValue() As Boolean

      For i As Integer = 0 To Me.Processor.Data.ParameterDetails.Rows.Count - 1
        Me.Processor.Data.ParameterDetails(i).ClearErrors()
        Me.Processor.Data.ParameterDetails(i).RowError = String.Empty

        Select Case Me.Processor.Data.ParameterDetails(i).Data_Type.ToString().ToLower()
          Case "bit"
            If Me.Processor.Data.ParameterDetails(i).IsParameter_ValueNull() = False Then
              If IsValidBoolean(Me.Processor.Data.ParameterDetails(i).Parameter_Value) = False Then
                Me.Processor.Data.ParameterDetails(i).RowError = "Parameter value should be a valid boolean value."
              End If
            End If
          Case "tinyint"
            If Me.Processor.Data.ParameterDetails(i).IsParameter_ValueNull() = False Then
              If IsValidByte(Me.Processor.Data.ParameterDetails(i).Parameter_Value) = False Then
                Me.Processor.Data.ParameterDetails(i).RowError = "Parameter value should be between 0 and 255."
              End If
            End If
          Case "smallint"
            If Me.Processor.Data.ParameterDetails(i).IsParameter_ValueNull() = False Then
              If IsValidSmallInteger(Me.Processor.Data.ParameterDetails(i).Parameter_Value) = False Then
                Me.Processor.Data.ParameterDetails(i).RowError = "Parameter value should be between -32768 and 32767."
              End If
            End If
          Case "int"
            If Me.Processor.Data.ParameterDetails(i).IsParameter_ValueNull() = False Then
              If IsValidInteger(Me.Processor.Data.ParameterDetails(i).Parameter_Value) = False Then
                Me.Processor.Data.ParameterDetails(i).RowError = "Parameter value should be valid integer value."
              End If
            End If
          Case "bigint"
            If Me.Processor.Data.ParameterDetails(i).IsParameter_ValueNull() = False Then
              If IsValidLong(Me.Processor.Data.ParameterDetails(i).Parameter_Value) = False Then
                Me.Processor.Data.ParameterDetails(i).RowError = "Parameter value should be a valid integer value."
              End If
            End If
          Case "smallmoney"
            If Me.Processor.Data.ParameterDetails(i).IsParameter_ValueNull() = False Then
              If IsValidSingle(Me.Processor.Data.ParameterDetails(i).Parameter_Value) = False Then
                Me.Processor.Data.ParameterDetails(i).RowError = "Parameter value should be a valid decimal value."
              End If
            End If
          Case "money"
            If Me.Processor.Data.ParameterDetails(i).IsParameter_ValueNull() = False Then
                            If IsValidDouble(Me.Processor.Data.ParameterDetails(i).Parameter_Value) = False Then
                                Me.Processor.Data.ParameterDetails(i).RowError = "Parameter value should be a valid decimal value."
                            End If
            End If
          Case "numeric", "decimal"
            If Me.Processor.Data.ParameterDetails(i).IsParameter_ValueNull() = False Then
              If Me.Processor.Data.ParameterDetails(i).Precision < 9 Then
                If IsValidDouble(Me.Processor.Data.ParameterDetails(i).Parameter_Value) = False Then
                  Me.Processor.Data.ParameterDetails(i).RowError = "Parameter value should be a valid decimal value."
                End If
              Else
                If IsValidDecimal(Me.Processor.Data.ParameterDetails(i).Parameter_Value) = False Then
                  Me.Processor.Data.ParameterDetails(i).RowError = "Parameter value should be a valid decimal value."
                End If
              End If
            End If
          Case "float"
            If Me.Processor.Data.ParameterDetails(i).IsParameter_ValueNull() = False Then
              If Me.Processor.Data.ParameterDetails(i).Precision < 24 Then
                If IsValidSingle(Me.Processor.Data.ParameterDetails(i).Parameter_Value) = False Then
                  Me.Processor.Data.ParameterDetails(i).RowError = "Parameter value should be a valid decimal value."
                End If
              Else
                If IsValidDouble(Me.Processor.Data.ParameterDetails(i).Parameter_Value) = False Then
                  Me.Processor.Data.ParameterDetails(i).RowError = "Parameter value should be a valid decimal value."
                End If
              End If
            End If
          Case "real"
            If Me.Processor.Data.ParameterDetails(i).IsParameter_ValueNull() = False Then
              If IsValidSingle(Me.Processor.Data.ParameterDetails(i).Parameter_Value) = False Then
                Me.Processor.Data.ParameterDetails(i).RowError = "Parameter value should be a valid decimal value."
              End If
            End If
          Case "datetime", "smalldatetime"
            If Me.Processor.Data.ParameterDetails(i).IsParameter_ValueNull() = False Then
              If IsValidDateTime(Me.Processor.Data.ParameterDetails(i).Parameter_Value) = False Then
                Me.Processor.Data.ParameterDetails(i).RowError = "Parameter value should be a valid date value."
              End If
            End If
          Case "char", "text", "varchar", "nchar", "ntext", "nvarchar"
            If Me.Processor.Data.ParameterDetails(i).IsParameter_ValueNull() = False _
              AndAlso Me.Processor.Data.ParameterDetails(i).IsData_LengthNull() = False _
            Then
              If Me.Processor.Data.ParameterDetails(i).Parameter_Value.Length > Me.Processor.Data.ParameterDetails(i).Data_Length Then
                                Me.Processor.Data.ParameterDetails(i).RowError = "String is longer than the number of characters allowed."
              End If
            End If
        End Select
      Next

      'Following statement is added to remove error provider from row header.
      Me.parameterDataGridView.Refresh()

      Return (Not Me.Processor.Data.ParameterDetails.HasErrors)

    End Function


#End Region


    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

      Me.Close()

        End Sub

        Private Sub storedprocedureComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles storedprocedureComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub storedprocedureComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles storedprocedureComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                storedprocedureComboBox.SelectedValue = -1
            End If
        End Sub


        Private Sub storedprocedureComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles storedprocedureComboBox.SelectedValueChanged
            Dim storedprocedureId As Integer
            Dim storedprocQuery As System.Data.EnumerableRowCollection(Of DESPDataSet.DESP_StoredProcedureRow)


            If storedprocedureComboBox.SelectedValue Is Nothing Then
                Exit Sub
            ElseIf Integer.TryParse(storedprocedureComboBox.SelectedValue.ToString(), storedprocedureId) = False Then
                MessageBox.Show("Unable to identify selected stored procedure.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            storedprocQuery = From r In Me.Processor.Data.DESP_StoredProcedure _
                              Where r.StoredProcedureId = storedprocedureId _
                              Select r
            If storedprocQuery.Count() = 0 Then
                MessageBox.Show("Unable to fetch stored procedure information.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                descriptionValueLabel.Text = storedprocQuery(0).Descrip '' Added by Gaurang 02/28/2013.. Asign storedprocedure Description value to the descriptionValueLabel.
            End If

           
            '''Commented by Gaurang 02/28/2013.. StoredProcedure Description Asign to descriptionValueLabel
            'If Me.Processor.Data.StoredProcedureDetails.Count > 0 Then
            '  ShowStoredProcedureDescription()
            '      End If

            Me.Processor.LoadStoredProcedureParameterDetails(storedprocQuery(0).ProcedureName)
            ResetDataGridView()
            AssignUserId()

        End Sub

        Private Sub executeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles executeButton.Click
            Dim storedprocedureId As Integer
            Dim storedprocQuery As System.Data.EnumerableRowCollection(Of DESPDataSet.DESP_StoredProcedureRow)


            If storedprocedureComboBox.SelectedValue Is Nothing Then
                MessageBox.Show("To execute any stored procedure you must select a stored procedure from drop down list." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            ElseIf Integer.TryParse(storedprocedureComboBox.SelectedValue.ToString(), storedprocedureId) = False Then
                MessageBox.Show("Can not execute stored procedure. Unable to identify selected stored procedure." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            storedprocQuery = From r In Me.Processor.Data.DESP_StoredProcedure _
                              Where r.StoredProcedureId = storedprocedureId _
                              Select r
            If storedprocQuery.Count() = 0 Then
                MessageBox.Show("Can not execute stored procedure. Unable to fetch stored procedure information." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If ValidateParameterValue() = False Then Exit Sub

            Try
                Processor.ExecuteStoredProcedure(storedprocedureId, storedprocQuery(0).ProcedureName)
            Catch ex As ApplicationException
                MessageBox.Show(ex.Message + Environment.NewLine + "Inform your Data Entry administrator about this." _
                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Unknown error has occurred while executing selected stored procedure." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            storedprocQuery = Nothing

        End Sub

    Private Sub m_processor_StoredProcedureExecutedSuccessfully(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_processor.StoredProcedureExecutedSuccessfully
      Dim result As System.Data.DataSet


      result = CType(e.Data("ResultsDataSet"), System.Data.DataSet)

      If result Is Nothing OrElse result.Tables.Count = 0 OrElse result.Tables(0).Rows.Count = 0 Then
        MessageBox.Show("Stored procedure executed successfully. Nothing is provided as result of the execution." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      Dim tempFrm As UI.DESPResultForm

      tempFrm = New UI.DESPResultForm()     
      tempFrm.ShowResult(result)
      tempFrm.ShowInTaskbar = False
      tempFrm.ShowDialog(Me)
      tempFrm.Close()
      tempFrm.Dispose()
      tempFrm = Nothing
      result = Nothing

    End Sub

        Private Sub storedprocedureComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles storedprocedureComboBox.SelectedIndexChanged
            
        End Sub


        Private Sub parameterDataGridView_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles parameterDataGridView.RowsAdded
            If parameterDataGridView.Rows(e.RowIndex).Cells("Parameter_Name").Value.ToString() = "@userid" Then
                parameterDataGridView.Rows(e.RowIndex).Cells("Parameter_Value").Value = User.UserID
                parameterDataGridView.Rows(e.RowIndex).Cells("Parameter_Value").ReadOnly = True
            Else
                parameterDataGridView.Rows(e.RowIndex).Cells("Parameter_Value").ReadOnly = False
            End If
        End Sub

        Private Sub AssignUserId()
            For i As Integer = 0 To parameterDataGridView.Rows.Count - 1
                ' Add the qty value of the current row to total
                If parameterDataGridView.Rows(i).Cells("Parameter_Name").Value.ToString() = "@userid" Then
                    parameterDataGridView.Rows(i).Cells("Parameter_Value").Value = User.UserID
                    parameterDataGridView.Rows(i).Cells("Parameter_Value").ReadOnly = True
                Else
                    parameterDataGridView.Rows(i).Cells("Parameter_Value").ReadOnly = False
                End If
            Next
        End Sub
     
       
    End Class

End Namespace