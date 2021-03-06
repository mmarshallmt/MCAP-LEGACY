﻿Namespace UI

    Public Class RequiredForm
        Implements IForm

        ''' <summary>
        ''' This constant is used to assigning value to FormName column.
        ''' </summary>
        Private Const FORM_NAME As String = "Required Form"


        Private m_previousSelection As SearchCriteria
        Private WithEvents m_RequiredProcessor As Processors.RequiredProcess


        ''' <summary>
        ''' Gets FamilyReview processor.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property Processor() As Processors.RequiredProcess
            Get
                Return m_RequiredProcessor
            End Get
        End Property


#Region " IForm Implementation "


        Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
        Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied

        Public Event InitializingForm() Implements IForm.InitializingForm
        Public Event FormInitialized() Implements IForm.FormInitialized


        Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

        End Sub

        Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

            RaiseEvent InitializingForm()

            ' Me.FormState = formStatus
            m_RequiredProcessor = New Processors.RequiredProcess
            Processor.Initialize()


            Processor.RetailerAdapter.Fill(Processor.Data.Ret)

            Processor.FillMedia()
            Processor.FillMarket()
            Processor.FillStatus()

            retailerComboBox.DisplayMember = "Descrip"
            retailerComboBox.ValueMember = "RetId"
            retailerComboBox.DataSource = Processor.Data.Ret
            retailerComboBox.SelectedValue = DBNull.Value

             startdateTypeInDatePicker.Value = System.DateTime.Today.AddMonths(-1)
            enddateTypeInDatePicker.Value = System.DateTime.Today.AddDays(1)

            Dim MediaView As DataView = New DataView(Processor.Data.Mkt)
            '
            'MediaView.Sort = "Descrip"
            ' MediaView.RowFilter = "descrip<>'Website' and descrip<>'Email' and descrip<>'Social'"

            'marketComboBox.DisplayMember = "Descrip"
            'marketComboBox.ValueMember = "MediaId"
            'marketComboBox.DataSource = MediaView
            'marketComboBox.SelectedValue = DBNull.Value
            With marketComboBox
                .DisplayMember = "Descrip"
                .ValueMember = "mktid"
                .DataSource = Processor.Data.Mkt
                .SelectedValue = -1
            End With

            With StatusComboBox
                .DisplayMember = "descrip"
                .ValueMember = "codeid"
                .SelectedIndex = -1
                .DataSource = Processor.Data.Code

            End With

            With CmbLabel
                .SelectedIndex = 0
            End With

            reviewDataGridView.DataSource = Processor.Data.Vehicle
            With reviewDataGridView
                .Columns("senderID").Visible = False
            End With

            RaiseEvent FormInitialized()

        End Sub


#End Region

        Private Sub clearForm()

            startdateTypeInDatePicker.Value = System.DateTime.Today.AddMonths(-1)
            enddateTypeInDatePicker.Value = System.DateTime.Today.AddDays(1)
            retailerComboBox.SelectedValue = -1
            marketComboBox.SelectedValue = -1
            EnvelopIdTextBox.Text = ""
            reviewDataGridView.DataSource = Processor.Data.Vehicle
        End Sub


        Private Sub searchButton_Click(sender As Object, e As EventArgs) Handles searchButton.Click
            Dim EnvelopId As Integer
            Dim retId As Integer
            Dim mktid As Integer
            Dim StatusId As Integer
            Dim startDate As DateTime
            Dim endDate As DateTime

            SearchLabel.Text = "Searching..."
            If startdateTypeInDatePicker.Value.HasValue = False Then
                MessageBox.Show("Start date is mandatory to initiate search.", _
                                ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            startDate = startdateTypeInDatePicker.Value.Value
            endDate = enddateTypeInDatePicker.Value.Value

            If String.IsNullOrEmpty(EnvelopIdTextBox.Text) Then
                EnvelopId = Nothing
            Else
                EnvelopId = CType(EnvelopIdTextBox.Text, Integer)
            End If

            If marketComboBox.SelectedValue Is Nothing OrElse marketComboBox.SelectedValue Is DBNull.Value Then
                mktid = Nothing
            Else
                mktid = CType(marketComboBox.SelectedValue, Integer)
            End If

            If retailerComboBox.SelectedValue Is Nothing OrElse retailerComboBox.SelectedValue Is DBNull.Value Then
                retId = Nothing
            Else
                retId = CType(retailerComboBox.SelectedValue, Integer)
            End If

            If StatusComboBox.SelectedValue Is Nothing OrElse StatusComboBox.SelectedValue Is DBNull.Value Then
                StatusId = Nothing
            Else
                StatusId = CType(StatusComboBox.SelectedValue, Integer)
            End If

            Processor.Load(EnvelopId, retId, mktid, StatusId, startDate, endDate, CmbLabel.SelectedIndex)
            SearchLabel.Text = "Done"

        End Sub

        ''' <summary>
        ''' Marks vehicles in array with status as Checked In. Removes DataRows from DataTable.
        ''' </summary>
        ''' <param name="vehicleIdArray"></param>
        ''' <remarks></remarks>
        Private Sub MarkVehiclesAsCheckIn(ByVal vehicleIdArray() As Integer)
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.VehicleTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.VehicleDataTable
            Dim tempRow As MCAP.ReportsDataSet.VehicleRow

            tempAdapter = New MCAP.ReportsDataSetTableAdapters.VehicleTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempTable = CType(reviewDataGridView.DataSource, ReportsDataSet.VehicleDataTable)
         

            For i As Integer = 0 To vehicleIdArray.Length - 1
                tempAdapter.UpdateVehicleStatus(FORM_NAME, vehicleIdArray(i), Nothing, User.UserID)
                tempRow = tempTable.FindByVehicleId(vehicleIdArray(i))
                tempRow.Delete()
            Next
            tempTable.AcceptChanges()

            tempAdapter.Dispose()
            tempAdapter = Nothing
            tempTable = Nothing
            tempRow = Nothing

        End Sub

        Private Sub splitFamilyButton_Click(sender As Object, e As EventArgs) Handles vehicletoIndexButton.Click

            Dim vehicleId, selectedRowIndex As Integer
            Dim myIndexForm As New IndexForm
            Dim userResponse As DialogResult
            Dim selectedVehicleQuery As System.Collections.Generic.IEnumerable(Of Integer)
            Dim dupcheckResponse As DuplicateCheckUserResponse
            Dim EnvelopeContent As UI.Processors.EnvelopeContent
            Dim mktid As Integer
            Dim PublicationId As Integer
            Dim retid As Integer
            Dim StatusId As Integer
            Dim MediaValue As String
            Dim adDate As DateTime
            Dim objDupCheck As UI.Processors.DupCheckProcess


            selectedRowIndex = reviewDataGridView.CurrentCell.RowIndex
            EnvelopeContent = New UI.Processors.EnvelopeContent

            EnvelopeContent.Initialize()
            EnvelopeContent.LoadDataSet()
            mktid = CType(reviewDataGridView.Rows(selectedRowIndex).Cells("mktidTextBoxColumn").Value, Integer)
            PublicationId = CType(reviewDataGridView.Rows(selectedRowIndex).Cells("PublicationIdTextBoxColumn").Value, Integer)
            vehicleId = CType(reviewDataGridView.Rows(selectedRowIndex).Cells("VehicleId").Value, Integer)
            MediaValue = reviewDataGridView.Rows(selectedRowIndex).Cells("Media").Value.ToString
            adDate = CType(reviewDataGridView.Rows(selectedRowIndex).Cells("ad_Date").Value, DateTime)
            retid = CType(reviewDataGridView.Rows(selectedRowIndex).Cells("RetIdTextBoxColumn").Value, Integer)

            objDupCheck = New UI.Processors.DupCheckProcess
            objDupCheck.VehicleID = CStr(vehicleId)
            objDupCheck.FormState = FormStateEnum.Edit
            objDupCheck.Form = Me
            objDupCheck.MediaText = MediaValue.ToUpper()
            objDupCheck.adVehicleDate = adDate
            objDupCheck.RetId = retid


            If Me.reviewDataGridView.SelectedRows.Count <> 1 Then
                MessageBox.Show("Select a row to mark vehicle as Check-In.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                userResponse = MessageBox.Show("Are you sure, you want to mark selected vehicle as Check-In?" _
                                               , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End If

            If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

            dupcheckResponse = objDupCheck.CheckForDuplication(mktid _
                                                               , PublicationId, True, FORM_NAME)
            If dupcheckResponse = DuplicateCheckUserResponse.Closed Then Exit Sub

            'If vehicle status is created, keep statusId as null,
            'if its not required, status id is set while validating row in processor.
            '
            If dupcheckResponse = DuplicateCheckUserResponse.Review Then
                StatusId = EnvelopeContent.GetStatusIdForReview()
                Processor.UpdateVehicleStatus(vehicleId, StatusId, Nothing)
            ElseIf dupcheckResponse = DuplicateCheckUserResponse.Duplicate Then
                StatusId = EnvelopeContent.GetStatusIdForDuplicate()
                Processor.UpdateVehicleStatus(vehicleId, StatusId, User.UserID)
            Else


                Processor.InsertBypassSenderVehicleHistory(vehicleId)

                selectedVehicleQuery = From r In reviewDataGridView.SelectedRows.Cast(Of DataGridViewRow)() _
                                       Select CType(r.Cells("VehicleId").Value, Integer)


                MarkVehiclesAsCheckIn(selectedVehicleQuery.ToArray())

                selectedVehicleQuery = Nothing
            End If

            '  ' If vehicleIdTextBox.Text <> "" Then
            '       myIndexForm = New UI.IndexForm
            '       myIndexForm.Init(FormStateEnum.View)
            '       myIndexForm.ApplyUserCredentials()
            '       myIndexForm.Show()
            '       myIndexForm.Hide()
            '       myIndexForm.findVehicleIdTextBox.Text = vehicleId.ToString
            '       myIndexForm.LoadVehicle()
            '       myIndexForm.Show()
            '       myIndexForm.SetInputFocus()
            '       myIndexForm.Hide()
            '       myIndexForm.ShowDialog(Me)
            '       myIndexForm.Dispose()
            '       myIndexForm = Nothing
            ''End If

        End Sub

      
        Private Sub pushToIndexButton_Click(sender As Object, e As EventArgs)


        End Sub

        Private Sub processRetButton_Click(sender As Object, e As EventArgs)
            Dim processForm As New ReviewRetailerForm
            processForm = New UI.ReviewRetailerForm
            processForm.Init(FormStateEnum.View)
            processForm.ApplyUserCredentials()
            processForm.ShowDialog(Me)
        End Sub

        Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
            Me.Hide()
        End Sub

        Private Sub resetButton_Click(sender As Object, e As EventArgs) Handles resetButton.Click
            clearForm()
        End Sub

        Private Sub EnvelopIdTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles EnvelopIdTextBox.KeyPress
            '3 - Copy, 22 - Paste and 24 - Cut, 8 - Backspace
            If Microsoft.VisualBasic.AscW(e.KeyChar) = 3 _
              OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 22 _
              OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 24 _
              OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 8 _
            Then
                Exit Sub 'Process as it should.
            End If

            If Not (e.KeyChar = Microsoft.VisualBasic.ChrW(8)) _
              AndAlso (Not (e.KeyChar > Microsoft.VisualBasic.ChrW(47) _
                And e.KeyChar < Microsoft.VisualBasic.ChrW(58))) _
            Then
                e.Handled = True
            End If
        End Sub
    End Class

End Namespace