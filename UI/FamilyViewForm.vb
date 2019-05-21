Namespace UI

  Public Class FamilyViewForm
    Implements IForm


    ''' <summary>
    ''' This constant is used to assigning value to FormName column.
    ''' </summary>
    Private Const FORM_NAME As String = "Family View"


    ''' <summary>
    ''' Stores vehicleId, which was loaded successfully.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_lastLoadedVehicleId As Integer
    Private WithEvents m_familyViewProcessor As Processors.FamilyView


    Public ReadOnly Property Processor() As Processors.FamilyView
      Get
        Return m_familyViewProcessor
      End Get
    End Property


    Public Sub LoadVehicles()

      loadButton_Click(Me, New System.EventArgs)

        End Sub

        Public Sub loadVehicle(ByVal vehicleID As Integer)
            vehicleIdTextBox.Text = vehicleID.ToString()
            Processor.Load(vehicleID)

        End Sub

    Public Sub HideReviewButtons()
      splitFamilyButton.Visible = False
      familyButton.Visible = False
      closeButton.Text = "Close"
    End Sub


#Region " IForm Implementation "

    Public Event InitializingForm() Implements IForm.InitializingForm
    Public Event FormInitialized() Implements IForm.FormInitialized

    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied

    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

    End Sub

    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

      RaiseEvent InitializingForm()

      Me.FormState = formStatus

      Me.DisplayFamilyInformationTableAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_familyViewProcessor = New Processors.FamilyView
      Processor.Initialize()

      familyDataGridView.DataSource = Processor.Data.DisplayFamilyInformation
            'familyDataGridView.Columns("VehicleStatus").Visible = False
            'familyDataGridView.Columns("FlashStatus").Visible = False
      RaiseEvent FormInitialized()

    End Sub

#End Region


    Protected Overrides Function GetVehiclePageImageName(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As String
      Return Processor.GetVehicleImageFileName(vehicleId, pageNumber)
    End Function

    Protected Overrides Function AreVehiclePageImagesScanned(ByVal vehicleId As Integer) As Boolean
      Return Processor.AreVehiclePageImagesScanned(vehicleId)
    End Function

    Protected Overrides Function AreVehicleImagesTransferred(ByVal vehicleId As Integer, ByVal locationId As Integer) As Boolean
      Return Processor.AreVehicleImagesTransferred(vehicleId, locationId)
    End Function

    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

      Me.Close()

    End Sub

    Private Sub loadButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles loadButton.Click
            Dim vehicleId As Integer

            SearchLabel.Text = "Searching..."
      If vehicleIdTextBox.Text.Trim().Length = 0 Then
        MessageBox.Show("Specify a Vehicle Id to see all the Vehicles in its Family.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        vehicleIdTextBox.Focus()
        Exit Sub

      ElseIf Integer.TryParse(vehicleIdTextBox.Text, vehicleId) = False Then
        MessageBox.Show("Vehicle Id should be numeric value.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        vehicleIdTextBox.Focus()
        vehicleIdTextBox.SelectAll()
        Exit Sub
      End If

      Processor.Load(vehicleId)

            If Processor.Data.DisplayFamilyInformation.Count = 0 Then
                MessageBox.Show("Vehicle Id " & CType(vehicleId, String) & " not found or Vehicle does not have Family assigned to it." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                vehicleIdTextBox.SelectAll()
                vehicleIdTextBox.Focus()
                Exit Sub
            Else
                familyDataGridView.Refresh()
                familyDataGridView.Columns("ViewFamily").Visible = False
                If Processor.Data.DisplayFamilyInformation.Count > 0 Then
                    'retailerNameLabel.Text = Processor.GetRetailerName(vehicleId)
                    retailerNameLabel.Text = Processor.Data.DisplayFamilyInformation(0).Retailer
                End If
                LoadPageImagesInDataGrid()
                m_lastLoadedVehicleId = vehicleId
            End If

            'if flashInd = 1 then 
            If Processor.GetFlashInd(vehicleId.ToString) = 1 Then
                LabelFlash.Visible = True
                RadioButtonComparison.Enabled = False
            Else
                LabelFlash.Visible = False
                RadioButtonComparison.Enabled = True
            End If


            If Processor.Data.DisplayFamilyInformation.Rows.Count > 0 Then
                'Ad Type
                If Processor.Data.DisplayFamilyInformation(0).IsAdTypeIdNull = False Then

                    If Processor.Data.DisplayFamilyInformation(0).AdTypeId = 1 Then
                        WeeklyRadioButton.Checked = True
                    ElseIf Processor.Data.DisplayFamilyInformation(0).AdTypeId = 2 Then
                        SupplementalRadioButton.Checked = True
                    Else
                        WeeklyRadioButton.Checked = False
                        SupplementalRadioButton.Checked = False
                    End If
                End If

                'reviewed

                If Processor.Data.DisplayFamilyInformation(0).IsReviewDtNull = True Then
                    LockButton.Enabled = False
                Else
                    LockButton.Enabled = True

                End If

                'Ad Distribution
                If Processor.Data.DisplayFamilyInformation(0).IsAdDistIdNull = False Then
                    If Processor.Data.DisplayFamilyInformation(0).AdDistId = 1 Then
                        LocalRadioButton.Checked = True
                    ElseIf Processor.Data.DisplayFamilyInformation(0).AdDistId = 2 Then
                        RegionalRadioButton.Checked = True
                    ElseIf Processor.Data.DisplayFamilyInformation(0).AdDistId = 3 Then
                        NationalRadioButton.Checked = True
                    Else
                        LocalRadioButton.Checked = False
                        RegionalRadioButton.Checked = False
                        NationalRadioButton.Checked = False
                    End If
                End If

                'Durables Entry
                If Processor.Data.DisplayFamilyInformation(0).IsDurEntryIndNull = False Then
                    If Processor.Data.DisplayFamilyInformation(0).DurEntryInd = 1 Then
                        DurablesCheckBox.Checked = True
                    Else
                        DurablesCheckBox.Checked = False
                    End If
                End If
                'Consumables Entry
                If Processor.Data.DisplayFamilyInformation(0).IsConEntryIndNull = False Then
                    If Processor.Data.DisplayFamilyInformation(0).ConEntryInd = 1 Then
                        ConsumablesCheckBox.Checked = True
                    Else
                        ConsumablesCheckBox.Checked = False
                    End If
                End If

                'Comparison Entry
                If Processor.Data.DisplayFamilyInformation(0).IsCompareIndNull = False Then
                    If Processor.Data.DisplayFamilyInformation(0).CompareInd = 1 Then
                        ' ComparisonCheckBox.Checked = True
                        RadioButtonComparison.Checked = True
                    Else
                        ' ComparisonCheckBox.Checked = False
                        RadioButtonComparison.Checked = False
                    End If
                End If

                ' is locked
                If Processor.Data.DisplayFamilyInformation(0).IsLockIndNull = False Then
                    If Processor.Data.DisplayFamilyInformation(0).LockInd = 1 Then
                        AdTypeGroupBox.Enabled = False
                        AdDistGroupBox.Enabled = False
                        OthersGroupBox.Enabled = False
                        LockButton.Enabled = False
                        SaveButton.Enabled = False
                    Else
                        AdTypeGroupBox.Enabled = True
                        AdDistGroupBox.Enabled = True
                        OthersGroupBox.Enabled = True
                        LockButton.Enabled = True
                        SaveButton.Enabled = True
                    End If
                End If



                'validate if the user can unlock a family
                Dim appUser As UI.Processors.ApplicationUser = New UI.Processors.ApplicationUser
                Dim formListTable As MCAP.UserRolesDataSet.UserScreensFunctionalityViewDataTable
                Dim tempRow As MCAP.UserRolesDataSet.UserScreensFunctionalityViewRow

                appUser = New UI.Processors.ApplicationUser()
                appUser.Initialize()

                formListTable = appUser.GetFormListFor(appUser.UserID)

                appUser.Dispose()
                appUser = Nothing

                For ctr As Integer = 0 To formListTable.Rows.Count - 1
                    tempRow = formListTable(ctr)

                    If tempRow.FormName = "Unlock Family" Then
                        'tableComboBox.Items.Add("PublicationSubscription")
                        LockButton.Enabled = True
                        If Processor.Data.DisplayFamilyInformation(0).LockInd = 1 Then
                            LockButton.Text = "Unlock"
                        End If
                    End If
                Next

                formListTable.Dispose()
                formListTable = Nothing

            End If
            SearchLabel.Text = "Search Completed."
        End Sub

    Private Sub vehicleIdTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles vehicleIdTextBox.KeyPress

      '3 - Copy, 22 - Paste and 24 - Cut, 8 - Backspace
      If Microsoft.VisualBasic.AscW(e.KeyChar) = 3 _
        OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 22 _
        OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 24 _
        OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 8 _
      Then
        Exit Sub 'Process as it should.
      End If

      If Microsoft.VisualBasic.AscW(e.KeyChar) = 13 Then loadButton.PerformClick()

    End Sub

    Private Sub familyButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles familyButton.Click
      Dim familyId As Integer


      If familyDataGridView.RowCount = 0 Then Exit Sub

      familyId = CType(familyDataGridView.Rows(0).Cells("FamilyIDDataGridViewTextBoxColumn").Value, Integer)
      Processor.MarkFamilyAsReviewed(familyId, FORM_NAME)

      MessageBox.Show("Family has been marked as Reviewed.", ProductName _
                      , MessageBoxButtons.OK, MessageBoxIcon.Information)

      Me.Close()

    End Sub

    Private Sub splitFamilyButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles splitFamilyButton.Click
      Dim rowCounter, familyId, vehicleId() As Integer


      If familyDataGridView.RowCount < 2 Then
        MessageBox.Show("There should be at least 2 Vehicles to split them into separate families." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      ElseIf familyDataGridView.SelectedRows.Count = familyDataGridView.RowCount Then
        MessageBox.Show("All Vehicles are selected. Please unselected at least one Vehicle that will remain in the current Family." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      familyId = Processor.GetNewFamily(FORM_NAME)

      ReDim vehicleId(familyDataGridView.SelectedRows.Count - 1)

      For rowCounter = 0 To familyDataGridView.SelectedRows.Count - 1
        vehicleId(rowCounter) = CType(familyDataGridView.SelectedRows(rowCounter).Cells("VehicleIdDataGridViewTextBoxColumn").Value, Integer)
      Next

      Processor.SplitFamily(familyId, FORM_NAME, vehicleId)

      'Once family is splited successfully, refresh list of families.
      Processor.Load(m_lastLoadedVehicleId)
      If Processor.Data.DisplayFamilyInformation.Count > 0 Then
        LoadPageImagesInDataGrid()
      End If

        End Sub

        Private Sub familyDataGridView_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
            If e.ColumnIndex = 25 AndAlso _
                     e.RowIndex >= 0 Then
                e.PaintBackground(e.ClipBounds, True)

                Dim rectRadioButton As Rectangle

                rectRadioButton.Width = 14
                rectRadioButton.Height = 14
                rectRadioButton.X = CInt(e.CellBounds.X + (e.CellBounds.Width - rectRadioButton.Width) / 2)
                rectRadioButton.Y = CInt(e.CellBounds.Y + (e.CellBounds.Height - rectRadioButton.Height) / 2)

                If IsDBNull(e.Value) OrElse CByte(e.Value) = 0 Then
                    ControlPaint.DrawRadioButton(e.Graphics, rectRadioButton, ButtonState.Normal)
                Else
                    ControlPaint.DrawRadioButton(e.Graphics, rectRadioButton, ButtonState.Checked)
                End If

                e.Paint(e.ClipBounds, DataGridViewPaintParts.Focus)

                e.Handled = True
            End If
        End Sub

        Private Sub familyDataGridView_CellContentClick _
       (ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)


            Dim vehicleId, selectedRowIndex As Integer

            selectedRowIndex = familyDataGridView.SelectedRows(0).Index 'There can be only one selected row.

            If e.ColumnIndex = 25 Then
                Dim drv As DataRowView
                Dim rowFamilyView As FamilyDataSet.DisplayFamilyInformationRow
                ' in this event handler we know that which DataGridView's row is clicked
                ' so we are going to extract out the actual DataTable's row which is
                ' bind with this DataGridView's Row
                drv = CType(Me.familyDataGridView.Rows(e.RowIndex).DataBoundItem, DataRowView)
                ' get the DataTable's row
                rowFamilyView = CType(drv.Row, FamilyDataSet.DisplayFamilyInformationRow)

                ' get the row which is currently selected
                Dim rowCurrentlySelected() As FamilyDataSet.DisplayFamilyInformationRow
                rowCurrentlySelected = CType(Processor.Data.DisplayFamilyInformation.Select("AltMasterInd=1"), FamilyDataSet.DisplayFamilyInformationRow())


                ' if some row found then make it de-selected

                If rowCurrentlySelected.Length > 0 Then
                    rowCurrentlySelected(0).AltMasterInd = 0

                End If
                ' ok now select the row which is clicked
                rowFamilyView.AltMasterInd = 1

            End If

        End Sub

        Private Sub familyDataGridView_CellDoubleClick _
            (ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

            Dim isThumbnailAvailable As Boolean = True
            Dim vehicleId, columnIndex, selectedRowIndex As Integer
            Dim VehiclePath As String
            Dim imageFolderPath As String
            Dim thumbnailQuery As System.Collections.Generic.IEnumerable(Of String)


            If Not (e.RowIndex >= 0 AndAlso (e.ColumnIndex = 0 OrElse e.ColumnIndex = 1)) Then Exit Sub

            If familyDataGridView.SelectedRows.Count <> 1 Then
                MessageBox.Show("Can show only one Family at a time.", ProductName, _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            selectedRowIndex = familyDataGridView.SelectedRows(0).Index
            columnIndex = familyDataGridView.Columns("VehicleIdDataGridViewTextBoxColumn").Index
            vehicleId = CType(familyDataGridView.Rows(selectedRowIndex).Cells(columnIndex).Value, Integer)

            VehiclePath = Processor.RetrieveYearMonth(vehicleId)

            imageFolderPath = VehicleImageFolderPath + "\" + VehiclePath _
                              + "\" + vehicleId.ToString() + "\" + ThumbSizedPageImageFolderName
            If System.IO.Directory.Exists(imageFolderPath) = False Then
                isThumbnailAvailable = False
                imageFolderPath = VehicleImageFolderPath + "\" + VehiclePath _
                                  + "\" + vehicleId.ToString() + "\" + UnsizedPageImageFolderName
            End If

            Application.DoEvents()

            Processor.LoadPagesInformation(vehicleId)
            thumbnailQuery = From pageRow In Processor.Data.Page _
                             Select imageFolderPath + "\" + pageRow.ImageName + ".jpg"

            Dim thumbnailForm As UI.Controls.ThumbnailBrowserForm = New UI.Controls.ThumbnailBrowserForm()
            thumbnailForm.LoadThumbnails(thumbnailQuery.ToArray(), isThumbnailAvailable)
            thumbnailForm.Text += " - Vehicle " + vehicleId.ToString()
            Application.DoEvents()
            thumbnailForm.ShowDialog(Me)
            thumbnailForm.Dispose()
            thumbnailForm = Nothing

            thumbnailQuery = Nothing


        End Sub

        Private Function ValidateForm(ByVal oDurEntryInd As Integer, ByVal oConEntryId As Integer, ByVal oCompareInd As Integer) As Boolean

            Dim valid As Boolean = True

            If oDurEntryInd = 0 And oConEntryId = 0 And oCompareInd = 0 Then
                valid = False
            End If

            Return valid
        End Function


        Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
            If Processor.Data.DisplayFamilyInformation.Rows.Count > 0 Then
                Dim oAdTypeId, oAdDistInd, oDurEntryInd, oConEntryId, oCompareInd As Integer

                If WeeklyRadioButton.Checked Then
                    oAdTypeId = 1
                ElseIf SupplementalRadioButton.Checked Then
                    oAdTypeId = 2
                End If

                If LocalRadioButton.Checked Then
                    oAdDistInd = 1
                ElseIf RegionalRadioButton.Checked Then
                    oAdDistInd = 2
                ElseIf NationalRadioButton.Checked Then
                    oAdDistInd = 3
                End If

                If DurablesCheckBox.Checked Then oDurEntryInd = 1

                If ConsumablesCheckBox.Checked Then oConEntryId = 1

                'If ComparisonCheckBox.Checked Then oCompareInd = 1
                If RadioButtonComparison.Checked Then oCompareInd = 1

                Dim row As DataGridViewRow
                For i As Integer = 0 To familyDataGridView.Rows.Count - 1
                    row = familyDataGridView.Rows(i)

                    If IsDBNull(row.Cells("AltMasterIndRadioButtonColumn").Value) = True Then
                        row.Cells("AltMasterIndRadioButtonColumn").Value = 0
                    End If
                    If CType(row.Cells("AltMasterIndRadioButtonColumn").Value, Integer) = 0 Then
                        Processor.setAltMasterId(CType(familyDataGridView.Rows(i).Cells("vehicleIDDataGridViewTextBoxColumn").Value, Integer), 0)
                    ElseIf CType(row.Cells("AltMasterIndRadioButtonColumn").Value, Integer) = 1 Then
                        Processor.setAltMasterId(CType(familyDataGridView.Rows(i).Cells("vehicleIDDataGridViewTextBoxColumn").Value, Integer), 1)
                    End If

                Next

                If ValidateForm(oDurEntryInd, oConEntryId, oCompareInd) = False Then
                    MsgBox("Please select entry routing.")
                    Exit Sub
                End If

                If Processor.UpdateFamily(Processor.Data.DisplayFamilyInformation(0).FamilyId, oAdTypeId, oAdDistInd, oDurEntryInd, oConEntryId, oCompareInd) = 1 Then

                    Dim familyId As Integer


                    If familyDataGridView.RowCount = 0 Then Exit Sub

                    familyId = CType(familyDataGridView.Rows(0).Cells("FamilyIDDataGridViewTextBoxColumn").Value, Integer)
                    Processor.MarkFamilyAsReviewed(familyId, FORM_NAME)

                    MessageBox.Show("Family updated and marked as Reviewed.", "Family View", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LockButton.Enabled = True
                End If
            End If
        End Sub

        Private Sub LockButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LockButton.Click
            Dim oLock As Integer

            If LockButton.Text = "Lock" Then
                oLock = 1
            Else
                oLock = 0
                LockButton.Text = "Lock"
            End If

            If Processor.Data.DisplayFamilyInformation.Rows.Count > 0 Then
                Processor.LockFamily(Processor.Data.DisplayFamilyInformation(0).FamilyId, oLock)
                loadButton.PerformClick()
            End If
        End Sub

        Private Sub loadButton_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles loadButton.GotFocus
            SearchLabel.Text = "Searching..."
        End Sub

        Private Sub RadioButtonEntry_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonEntry.CheckedChanged
            If RadioButtonEntry.Checked = True Then
                ConsumablesCheckBox.Enabled = True
                DurablesCheckBox.Enabled = True
            Else
                ConsumablesCheckBox.Enabled = False
                DurablesCheckBox.Enabled = False

            End If
        End Sub

        Private Sub RadioButtonComparison_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonComparison.CheckedChanged
            If RadioButtonComparison.Checked = True Then
                ConsumablesCheckBox.Checked = False
                DurablesCheckBox.Checked = False

            End If
        End Sub
    End Class

End Namespace