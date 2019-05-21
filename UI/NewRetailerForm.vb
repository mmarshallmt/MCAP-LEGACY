Imports System.Collections.Generic
Imports System.Windows.Controls

Namespace UI

    Public Class NewRetailerForm


        Inherits MDIChildFormBase
        Implements IForm

        ''' <summary>
        ''' This constant is used to assigning value to FormName column.
        ''' </summary>
        Private Const FORM_NAME As String = "Required Form"


        Private m_previousSelection As SearchCriteria

        Private WithEvents m_RequiredProcessor As Processors.RequiredProcess

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


            Processor.TempRetAdapter.Fill(Processor.Data.TempRet)
            Dim MediaView As DataView = New DataView(Processor.Data.TempRet)
            newRetailerListBox.DisplayMember = "Descrip"
            newRetailerListBox.ValueMember = "vehicleid"
            newRetailerListBox.DataSource = MediaView
            Processor.RetailerAdapter.Fill(Processor.Data.Ret)
            Processor.TradeClassAdapter.Fill(Processor.Data.TradeClassList)

            With tradeClassComboBox
                .DisplayMember = "descrip"
                .ValueMember = "tradeclassid"
                .DataSource = Processor.Data.TradeClassList
                .SelectedValue = -1
            End With


            RaiseEvent FormInitialized()

        End Sub

       

#End Region

        Private Function AreInputsValid() As Boolean

            If selectRetailerListbox.SelectedIndex = -1 Then
                SetErrorProvider(selectRetailerListbox, "Select Unregistered Retailers to Process")
                Return False
            Else
                RemoveErrorProvider(selectRetailerListbox)
            End If

            If String.IsNullOrEmpty(searchRetailTextBox.Text) = True Then
                SetErrorProvider(searchRetailTextBox, "Provide New Retailer Name.")
                Return False
            Else
                RemoveErrorProvider(searchRetailTextBox)
            End If

            If similarRetailerListBox.SelectedIndex = -1 And tradeClassComboBox.SelectedIndex = -1 Then
                SetErrorProvider(tradeClassComboBox, "Select Unregistered Retailers to Process")
                Return False
            Else
                RemoveErrorProvider(tradeClassComboBox)
            End If


            Return True

        End Function
        Public Sub AddDefaultSelectValueToListBox(ByVal newRetailer As String)
            selectRetailerListbox.Items.Add(newRetailer)
            Me.selectRetailerListbox.SetSelected(0, True)

            Dim i As Integer = newRetailerListBox.FindString(newRetailer)
            newRetailerListBox.SelectedIndex = i


        End Sub

        Private Sub clearAllInput()
            selectRetailerListbox.Items.Clear()
            searchTextBox.Text = ""
            searchRetailTextBox.Text = ""
            Processor.FillTempRet()
            newRetailerListBox.Refresh()
            similarRetailerListBox.Visible = False
            closeSimilarRetailerListBox.Visible = False
            closeSimilatLabel.Visible = False
            RetailerLabel.Visible = False
            activeRetCheckBox.Checked = False
            activeRetCheckBox.Visible = False
        End Sub

        Private Sub loadCloseRetailers(ByVal descrip As String)
            closeSimilatLabel.Visible = True
            closeSimilarRetailerListBox.DisplayMember = "Descrip"
            closeSimilarRetailerListBox.ValueMember = "retid"
            closeSimilarRetailerListBox.DataSource = Processor.retailerData(descrip)
        End Sub

        Public Function getTempText() As String()
            Dim VehicleIDArray As String() = New String(selectRetailerListbox.Items.Count - 1) {}
            selectRetailerListbox.Items.CopyTo(VehicleIDArray, 0)

            Return VehicleIDArray
        End Function
        Public Function getVehicleIdList() As String()
            Dim vehicleIdArray() As String
            Dim desc As String
            Dim vehicleIdArrayProcess() As String
            vehicleIdArray = getTempText()
            ReDim vehicleIdArrayProcess(vehicleIdArray.Length - 1)
            For i As Integer = 0 To vehicleIdArray.Length - 1
                desc = GetFieldValue("select vehicleid from UnregisteredRetailers where descrip ='" + vehicleIdArray(i).ToString.Replace("'", "''") + "'", "vehicleid")
                vehicleIdArrayProcess(i) = desc
            Next
            Return vehicleIdArrayProcess
        End Function

        Public Sub selectAllListBoxITem()

            selectRetailerListbox.SelectionMode = Windows.Forms.SelectionMode.MultiSimple
            For i As Integer = 0 To selectRetailerListbox.Items.Count - 1
                selectRetailerListbox.SetSelected(i, True)
            Next
        End Sub

        Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click
            If AreInputsValid() = False Then Exit Sub

            Dim Retid As Integer = 0
            Dim descrip As String
            Dim tradeclass As Integer
            Dim retailerExist As Boolean = False
            Dim vehicleRecord As DataTable

            Dim vehicleIdArray() As String

            descrip = searchRetailTextBox.Text

            tradeclass = CInt(tradeClassComboBox.SelectedValue)

            similarRetailerListBox.GetItemText(similarRetailerListBox.SelectedValue)
            vehicleIdArray = getVehicleIdList()
            If Not similarRetailerListBox.SelectedValue Is Nothing Then
                retailerExist = True
                Dim text As String = TryCast(similarRetailerListBox.SelectedItem, DataRowView)("retid").ToString()
                Retid = CInt(text)
            End If


            If Retid = 0 Then
              
                If Processor.ifNewRetailerExist(searchRetailTextBox.Text) = True Then
                    Dim userResponse As DialogResult

                    If activeRetCheckBox.Checked = False Then

                        userResponse = MessageBox.Show("Retailer Already Exist, but is closed in the ret table.  Handle Existing Retailer ?" _
                                                          , "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If userResponse = Windows.Forms.DialogResult.Yes Then
                            loadCloseRetailers(searchRetailTextBox.Text)
                            closeSimilarRetailerListBox.Visible = True
                            activeRetCheckBox.Visible = True
                        End If
                    Else
                        'update ret and get 
                        If Not closeSimilarRetailerListBox.SelectedValue Is Nothing Then
                            retailerExist = True
                            Dim text As String = TryCast(closeSimilarRetailerListBox.SelectedItem, DataRowView)("retid").ToString()
                            Retid = CInt(text)
                            Processor.ActivateCloseRetailers(Retid)
                            addUpdateReOpenRetailer(Retid)
                            
                        End If
                    End If
                    If userResponse = Windows.Forms.DialogResult.No Then

                        'If (MessageBox.Show("Continue processing as new retailer ?", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then

                        '    Exit Sub
                        'End If

                        'Retid = Processor.InsertRetailer(descrip, tradeclass)

                        MessageBox.Show("Please choose from a similar retailer and re-open or change Master Retailer name.")
                        Exit Sub
                    End If

                Else
                    If (MessageBox.Show("New Retailer will be created. All values in the merge retailers list will be Removed. Continue ?", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then

                        Exit Sub
                    End If

                    Retid = Processor.InsertRetailer(descrip, tradeclass)
                End If
            Else
                If (MessageBox.Show("Existing Retailer found, Current RetId will be used. All values in the merge retailers list will be Removed. Continue ?", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then

                    Exit Sub
                End If
            End If
            If Not Retid = 0 Then
                For i As Integer = 0 To vehicleIdArray.Length - 1
                    If retailerExist = True Then
                        Dim senderid As Integer = 0
                        Dim media As Integer = 0
                        Dim mktid As Integer = 0
                        Dim isRequiredRetailer As Boolean = False
                        Dim statusid As Integer
                        vehicleRecord = Processor.vehicleData(CInt(vehicleIdArray(i)))
                        senderid = CInt(vehicleRecord.Rows(0).Item("senderid"))
                        media = CInt(vehicleRecord.Rows(0).Item("mediaid"))
                        mktid = CInt(vehicleRecord.Rows(0).Item("mktid"))

                        If activeRetCheckBox.Checked = True Then
                            statusid = Processor.GetStatusIdForUnregisteredRetMkt
                            Processor.UpdateVehicleStatus(vehicleIdArray(i), statusid, Nothing)
                        End If
                        If Processor.isRequiredRetailers(senderid, media, mktid, Retid) = True Then
                            MessageBox.Show("Vehicle Marked as Required .", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Processor.UpdateVehicleStatusforIndex(vehicleIdArray(i))
                        Else
                            If Processor.isBackupSender(senderid, media, mktid, Retid) = True Then
                                MessageBox.Show("Vehicle Marked as Backup Sender .", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                statusid = Processor.GetStatusIdForBackupSender
                                Processor.UpdateVehicleStatus(vehicleIdArray(i), statusid, Nothing)
                            Else
                                If (Processor.isUnregisteredRetMktExists(media, mktid, Retid) = True) OrElse (Processor.isUnregisteredRetMkt(mktid, Retid) = True) Then
                                    MessageBox.Show("Vehicle Marked as Unregistered RetMkt .", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    statusid = Processor.GetStatusIdForUnregisteredRetMkt
                                    Processor.UpdateVehicleStatus(vehicleIdArray(i), statusid, Nothing)

                                End If
                                If (Processor.isUnregisteredRetMktMediaExists(media, mktid, Retid) = True) OrElse (Processor.isUnregisteredRetMktMedia(media, mktid, Retid) = True) Then
                                    MessageBox.Show("Vehicle Marked as Unregistered RetMktMedia .", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    statusid = Processor.GetStatusIdForUnregisteredRetMktMedia
                                    Processor.UpdateVehicleStatus(vehicleIdArray(i), statusid, Nothing)

                                End If

                            End If

                        End If
                    Else
                        Dim statusid As Integer
                        MessageBox.Show("Vehicle has been placed in the unregistered report .", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'Status of Unregistered RetMkt
                        statusid = Processor.GetStatusIdForUnregisteredRetMkt
                        Processor.UpdateVehicleStatus(vehicleIdArray(i), statusid, Nothing)
                    End If
                    Processor.UpdateVehicleRetailer(vehicleIdArray(i), Retid)
                    Processor.DeleteTempRetailer(vehicleIdArray(i))
                Next
                clearAllInput()
                MessageBox.Show("All Records were Updated", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Sub

        Private Sub clearButton_Click(sender As Object, e As EventArgs) Handles clearButton.Click
            clearAllInput()
        End Sub

        Private Sub searchRetailTextBox_KeyUp(sender As Object, e As KeyEventArgs) Handles searchRetailTextBox.KeyUp
            If searchRetailTextBox.Text = "" Then
                similarRetailerListBox.Visible = False
                RetailerLabel.Visible = False
            End If
        End Sub

        Private Sub MoveAllLeftButton_Click(sender As Object, e As EventArgs) Handles MoveAllLeftButton.Click
            selectRetailerListbox.Items.Clear()
        End Sub

        Private Sub MoveRightButton_Click(sender As Object, e As EventArgs) Handles MoveRightButton.Click

            For Each Item As DataRowView In newRetailerListBox.SelectedItems
                selectRetailerListbox.Items.Add(Item.Item("Descrip"))
            Next

        End Sub

        Private Sub MoveLeftButton_Click(sender As Object, e As EventArgs) Handles MoveLeftButton.Click

            For i As Integer = 0 To selectRetailerListbox.SelectedIndices.Count - 1
                selectRetailerListbox.Items.RemoveAt(selectRetailerListbox.SelectedIndex)
            Next
            'searchRetMktTextBox.Text = ""
            similarRetailerListBox.Visible = False
            RetailerLabel.Visible = False

        End Sub

        Private Sub MoveAllRightButton_Click(sender As Object, e As EventArgs) Handles MoveAllRightButton.Click
            selectRetailerListbox.Items.AddRange(newRetailerListBox.Items)
        End Sub

        Private Sub searchRetailTextBox_TextChanged(sender As Object, e As EventArgs) Handles searchRetailTextBox.TextChanged
            Dim MediaView As DataView = New DataView(Processor.Data.Ret)

            MediaView.Sort = "Descrip"
            MediaView.RowFilter = "descrip like '%" + searchRetailTextBox.Text.Replace("'", "''") + "%'"
            If MediaView.Count > 0 Then
                similarRetailerListBox.Visible = True
                RetailerLabel.Visible = True
                similarRetailerListBox.DisplayMember = "Descrip"
                similarRetailerListBox.ValueMember = "retid"
                similarRetailerListBox.DataSource = MediaView
                similarRetailerListBox.SelectedValue = DBNull.Value
            ElseIf searchRetailTextBox.Text = "" Then
                similarRetailerListBox.Visible = False
                RetailerLabel.Visible = False
            Else
                similarRetailerListBox.Visible = False
                RetailerLabel.Visible = False
            End If

            closeSimilarRetailerListBox.Visible = False
            closeSimilatLabel.Visible = False
            activeRetCheckBox.Checked = False
            activeRetCheckBox.Visible = False

        End Sub

        Private Sub searchTextBox_TextChanged(sender As Object, e As EventArgs) Handles searchTextBox.TextChanged
            Dim MediaView As DataView = New DataView(Processor.Data.TempRet)

            MediaView.Sort = "Descrip"
            MediaView.RowFilter = "descrip like '%" + searchTextBox.Text + "%'"

            newRetailerListBox.DisplayMember = "Descrip"
            newRetailerListBox.ValueMember = "vehicleId"
            newRetailerListBox.DataSource = MediaView
            newRetailerListBox.SelectedValue = DBNull.Value

        End Sub

        Private Sub selectRetailerListbox_SelectedValueChanged(sender As Object, e As EventArgs) Handles selectRetailerListbox.SelectedValueChanged
            If selectRetailerListbox.SelectedIndex >= 0 Then
                searchRetailTextBox.Text = selectRetailerListbox.SelectedItem.ToString
            Else
                searchRetailTextBox.Text = ""
            End If
        End Sub

        Private Sub closeButton_Click(sender As Object, e As EventArgs) Handles closeButton.Click
            Me.Hide()
        End Sub

        Private Sub addUpdateReOpenRetailer(ByVal RetId As Integer)
            If Processor.ifreOpenRetailerExist(RetId) = True Then
                Processor.UpdateReOpenRetailer(RetId)
            Else
                Processor.InsertReOpenRetailer(RetId)
            End If
        End Sub
    End Class

End Namespace