Namespace UI


  Public Class FamilyReviewForm
    Implements IForm


    ''' <summary>
    ''' This constant is used to assigning value to FormName column.
    ''' </summary>
    Private Const FORM_NAME As String = "Family Review"


    Private m_previousSelection As SearchCriteria
    Private WithEvents m_familyReviewProcessor As Processors.FamilyReview


    ''' <summary>
    ''' Gets FamilyReview processor.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property Processor() As Processors.FamilyReview
      Get
        Return m_familyReviewProcessor
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

      Me.FormState = formStatus

      Me.DisplayFamilyInformationTableAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_familyReviewProcessor = New Processors.FamilyReview
      Processor.Initialize()

      Processor.PriorityAdapter.Fill(Processor.Data.vwPriority)
      Processor.TradeclassAdapter.Fill(Processor.Data.TradeClass)
      Processor.RetailerAdapter.Fill(Processor.Data.Ret)
      Processor.FillMedia()

      priorityComboBox.DisplayMember = "Priority"
      priorityComboBox.ValueMember = "Priority"
      priorityComboBox.DataSource = Processor.Data.vwPriority
      priorityComboBox.SelectedValue = DBNull.Value

      retailerComboBox.DisplayMember = "Descrip"
      retailerComboBox.ValueMember = "RetId"
      retailerComboBox.DataSource = Processor.Data.Ret
      retailerComboBox.SelectedValue = DBNull.Value

      tradeclassComboBox.DisplayMember = "Descrip"
      tradeclassComboBox.ValueMember = "TradeclassId"
      tradeclassComboBox.DataSource = Processor.Data.TradeClass
      tradeclassComboBox.SelectedValue = DBNull.Value

            Dim MediaView As DataView = New DataView(Processor.Data.Media)

            MediaView.Sort = "Descrip"
            MediaView.RowFilter = "descrip<>'Website' and descrip<>'Email' and descrip<>'Social'"

            mediaComboBox.DisplayMember = "Descrip"
            mediaComboBox.ValueMember = "MediaId"
            ' mediaComboBox.DataSource = Processor.Data.Media
            mediaComboBox.DataSource = MediaView
            mediaComboBox.SelectedValue = -2 '-2 is All Circulars



      familyDataGridView.DataSource = Processor.Data.DisplayFamilyInformation
            familyDataGridView.Columns("VehicleStatus").Visible = False
            familyDataGridView.Columns("FlashStatus").Visible = False
            familyDataGridView.Columns("HPStatus").Visible = False
            familyDataGridView.Columns("AltMasterIndRadioButtonColumn").Visible = False
      RaiseEvent FormInitialized()


    End Sub


#End Region

        Private Sub FamilyReviewForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
            gotoVehicleIdTextBox.Focus()
            RemoveErrorProvider(adDateTypeInDatePicker)
        End Sub

    Protected Overrides Function GetVehiclePageImageName(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As String
      Return Processor.GetVehicleImageFileName(vehicleId, pageNumber)
    End Function

    Protected Overrides Function AreVehiclePageImagesScanned(ByVal vehicleId As Integer) As Boolean
      Return Processor.AreVehiclePageImagesScanned(vehicleId)
    End Function

    Protected Overrides Function AreVehicleImagesTransferred(ByVal vehicleId As Integer, ByVal locationId As Integer) As Boolean
      Return Processor.AreVehicleImagesTransferred(vehicleId, locationId)
    End Function

    ''' <summary>
    ''' Reloads list of families in datagrid based on last search criteria
    ''' and selects supplied row if any row exist at that location.
    ''' </summary>
    ''' <param name="filterCriteria">Search criteria, which will be used to reload families.</param>
    ''' <param name="selectedRowIndex">Index of the row, which is to be selected once families are loaded.</param>
    ''' <remarks></remarks>
    Private Sub RefreshFamilies(ByVal filterCriteria As SearchCriteria, ByVal selectedRowIndex As Integer)

      With filterCriteria
        If .Priority <= 0 Then
          Processor.Load(.RetId, .MediaId, .AdDate, .DayRange, .IncludeReviewedFamilies)
        Else
          Processor.Load(.RetId, .MediaId, .AdDate, .Priority, .DayRange, .IncludeReviewedFamilies)
        End If
        LoadPageImagesInDataGrid()
      End With

      For i As Integer = 0 To familyDataGridView.SelectedRows.Count - 1
        familyDataGridView.SelectedRows(i).Selected = False
      Next

      If familyDataGridView.Rows.Count > selectedRowIndex Then
        familyDataGridView.Rows(selectedRowIndex).Selected = True
      End If

    End Sub


    Private Sub closeButton_Click _
        (ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles closeButton.Click

      Me.Close()

    End Sub


    Private Sub adDateTypeInDatePicker_Validated _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles adDateTypeInDatePicker.Validated


      If adDateTypeInDatePicker.Value.HasValue Then
        RemoveErrorProvider(adDateTypeInDatePicker)
      Else
        SetErrorProvider(adDateTypeInDatePicker, "Ad date is mandatory for search.")
      End If

        End Sub

        Private Sub tradeclassComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tradeclassComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub tradeclassComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tradeclassComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                tradeclassComboBox.SelectedValue = -1
            End If
        End Sub


    Private Sub tradeclassComboBox_Validated _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles tradeclassComboBox.Validated
      Dim tradeclassId As Integer


      If tradeclassComboBox.SelectedValue Is Nothing Then
        Processor.FillRetailers()
      Else
        tradeclassId = CType(tradeclassComboBox.SelectedValue, Integer)

        Processor.FilterRetailersByTradeclass(tradeclassId)
        retailerComboBox.SelectedValue = DBNull.Value
      End If

        End Sub

        Private Sub retailerComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles retailerComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub retailerComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles retailerComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                retailerComboBox.SelectedValue = -1
            End If
        End Sub


    Private Sub retailerComboBox_Validated _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles retailerComboBox.Validated

      If retailerComboBox.SelectedValue Is Nothing Then
        SetErrorProvider(retailerComboBox, "Retailer is mandatory for search.")
      Else
        RemoveErrorProvider(retailerComboBox)
      End If

      'Loading tradeclass if retailer is selected without selecting tradeclass.
      If tradeclassComboBox.SelectedValue Is Nothing Then
        Dim bmb As BindingManagerBase, tempRetRow As FamilyDataSet.RetRow

        bmb = Me.BindingContext(Me.retailerComboBox.DataSource)
        tempRetRow = CType(CType(bmb.Current, Data.DataRowView).Row, FamilyDataSet.RetRow)
        tradeclassComboBox.SelectedValue = tempRetRow.TradeClassId
        tempRetRow = Nothing
        bmb = Nothing
      End If

    End Sub


    Private Sub searchButton_Click _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles searchButton.Click
      Dim retId, priorityId, dayRange As Integer
            Dim mediaId As Integer
      Dim tempDate As DateTime

            SearchLabel.Text = "Searching..."
            If adDateTypeInDatePicker.Value.HasValue = False Then
                MessageBox.Show("Ad date is mandatory to initiate family search.", _
                                ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

      retId = CType(retailerComboBox.SelectedValue, Integer)
      dayRange = CType(daysNumericUpDown.Value, Integer)
      tempDate = adDateTypeInDatePicker.Value.Value
      If mediaComboBox.SelectedValue Is Nothing OrElse mediaComboBox.SelectedValue Is DBNull.Value Then
        mediaId = Nothing
      Else
                mediaId = CType(mediaComboBox.SelectedValue, Integer)
      End If

      If priorityComboBox.SelectedValue Is Nothing OrElse priorityComboBox.SelectedValue Is DBNull.Value Then
        Processor.Load(retId, mediaId, tempDate, dayRange, includeReviewedCheckBox.Checked)
        priorityId = -1
      Else
        priorityId = CType(priorityComboBox.SelectedValue, Integer)
        Processor.Load(retId, mediaId, tempDate, priorityId, dayRange, includeReviewedCheckBox.Checked)
      End If

      LoadPageImagesInDataGrid()

      m_previousSelection.RetId = retId
      m_previousSelection.MediaId = mediaId
      m_previousSelection.AdDate = tempDate
      m_previousSelection.Priority = priorityId
      m_previousSelection.DayRange = dayRange
      m_previousSelection.IncludeReviewedFamilies = includeReviewedCheckBox.Checked
            SearchLabel.Text = "Done"
        End Sub


        Private Sub familyDataGridView_CellContentClick _
            (ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles familyDataGridView.CellContentClick


            Dim vehicleId, selectedRowIndex As Integer
            Dim altMasterInd As Boolean
            selectedRowIndex = familyDataGridView.SelectedRows(0).Index 'There can be only one selected row.

            If e.ColumnIndex = 24 Then
                Dim drv As DataRowView
                Dim rowShutDownOption As FamilyDataSet.DisplayFamilyInformationRow
                ' in this event handler we know that which DataGridView's row is clicked
                ' so we are going to extract out the actual DataTable's row which is
                ' bind with this DataGridView's Row
                drv = CType(Me.familyDataGridView.Rows(e.RowIndex).DataBoundItem, DataRowView)
                ' get the DataTable's row
                rowShutDownOption = CType(drv.Row, FamilyDataSet.DisplayFamilyInformationRow)

                ' get the row which is currently selected
                Dim rowCurrentlySelected() As FamilyDataSet.DisplayFamilyInformationRow
                ' rowCurrentlySelected = Me.ShutdownOptionDataSet.ShutDownOptions.Select("IsSelected=True")

                altMasterInd = CType(familyDataGridView.Rows(e.RowIndex).Cells("AltMasterRadioButtonColumn").Value, Boolean)


                ' if some row found then make it de-selected
                If rowCurrentlySelected.Length > 0 Then
                    'rowCurrentlySelected(0).IsSelected = False
                End If
                ' ok now select the row which is clicked
                'rowShutDownOption.IsSelected = True
            End If

            If Not (e.ColumnIndex = 2 And e.RowIndex >= 0) Then Exit Sub

            If familyDataGridView.SelectedRows.Count <> 1 Then
                MessageBox.Show("Can show only one Family at a time.", ProductName, _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            vehicleId = CType(familyDataGridView.Rows(e.RowIndex).Cells("VehicleIdDataGridViewTextBoxColumn").Value, Integer)

            Dim showVehicles As FamilyViewForm
            showVehicles = New FamilyViewForm
            showVehicles.Init(FormStateEnum.View)
            showVehicles.vehicleIdTextBox.Text = vehicleId.ToString()
            'showVehicles.LoadVehicles()
            showVehicles.Show(Me)
            showVehicles.LoadVehicles()
            showVehicles.Hide()
            showVehicles.ShowDialog(Me)
            showVehicles.Dispose()
            showVehicles = Nothing

            RefreshFamilies(m_previousSelection, selectedRowIndex)

        End Sub

        Private Sub familyDataGridView_CellDoubleClick _
            (ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles familyDataGridView.CellDoubleClick

            Dim isThumbnailAvailable As Boolean = True
            Dim vehicleId, columnIndex, selectedRowIndex As Integer
            Dim createDt As DateTime
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
            columnIndex = 4 'familyDataGridView.Columns("VehicleCreateDtDataGridViewTextBoxColumn").Index
            createDt = CType(familyDataGridView.Rows(selectedRowIndex).Cells(columnIndex).Value, DateTime)

            imageFolderPath = VehicleImageFolderPath + "\" + createDt.ToString("yyyyMM") _
                              + "\" + vehicleId.ToString() + "\" + ThumbSizedPageImageFolderName
            If System.IO.Directory.Exists(imageFolderPath) Then
                isThumbnailAvailable = False
                imageFolderPath = VehicleImageFolderPath + "\" + createDt.ToString("yyyyMM") _
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


    Private Sub familyCorrectButton_Click _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles familyCorrectButton.Click
      Dim familyId, selectedRowIndex As Integer


      If familyDataGridView.SelectedRows.Count <> 1 Then
        MessageBox.Show("Select one Family to mark it as correct.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      familyId = CType(familyDataGridView.CurrentRow.Cells("FamilyIDDataGridViewTextBoxColumn").Value, Integer)
      selectedRowIndex = familyDataGridView.SelectedRows(0).Index 'There can be only one selected row.

      Processor.MarkFamilyAsReviewed(familyId, FORM_NAME)
      RefreshFamilies(m_previousSelection, selectedRowIndex)

      MessageBox.Show("Family has been marked as Reviewed.", ProductName _
                      , MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub


    Private Sub mergeButton_Click _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles mergeButton.Click
      Dim oldFamilyId, newFamilyId As Integer


      If familyDataGridView.SelectedRows.Count <> 2 Then
        MessageBox.Show("Select two Families to merge.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      oldFamilyId = CType(familyDataGridView.SelectedRows(0).Cells("FamilyIDDataGridViewTextBoxColumn").Value, Integer)
      newFamilyId = CType(familyDataGridView.SelectedRows(1).Cells("FamilyIDDataGridViewTextBoxColumn").Value, Integer)

      If oldFamilyId < newFamilyId Then
        Processor.MergeFamilies(oldFamilyId, newFamilyId, FORM_NAME)
      Else
        Processor.MergeFamilies(newFamilyId, oldFamilyId, FORM_NAME)
      End If

      'Once two families are merged, refresh list of families using last search criteria.
      If m_previousSelection.Priority < 0 Then
        Processor.Load(m_previousSelection.RetId, m_previousSelection.MediaId, m_previousSelection.AdDate _
                       , 0, m_previousSelection.IncludeReviewedFamilies)
      Else
        Dim priorityId As Integer = CType(priorityComboBox.SelectedValue, Integer)
        Processor.Load(m_previousSelection.RetId, m_previousSelection.MediaId, m_previousSelection.AdDate _
                       , m_previousSelection.Priority, 0, m_previousSelection.IncludeReviewedFamilies)
      End If

      LoadPageImagesInDataGrid()

        End Sub

        Private Sub mediaComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mediaComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub mediaComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mediaComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                mediaComboBox.SelectedValue = -1
            End If
        End Sub

        Private Sub priorityComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles priorityComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub priorityComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles priorityComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                priorityComboBox.SelectedValue = -1
            End If
        End Sub

        Private Sub searchButton_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchButton.GotFocus
            If SearchLabel.Text <> "Searching..." Then
                SearchLabel.Text = "Searching..."
            End If
        End Sub

        Private Sub searchButton_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchButton.LostFocus
            SearchLabel.Text = "Done"
        End Sub

        Private Sub searchButton_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles searchButton.MouseClick

        End Sub

        Private Sub searchButton_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles searchButton.MouseUp

        End Sub

        Private Sub gotoButton_Click(sender As Object, e As EventArgs) Handles gotoButton.Click
            Dim vehicleId As Integer
            Dim RetId As String = ""
            Dim AdDate As String = ""
            If gotoVehicleIdTextBox.Text.Trim().Length = 0 Then
                MessageBox.Show("Provide VehicleId to search for.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                gotoVehicleIdTextBox.Focus()
                Exit Sub

            ElseIf Integer.TryParse(gotoVehicleIdTextBox.Text, vehicleId) = False Then
                MessageBox.Show("Provide proper VehicleId to search for.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                gotoVehicleIdTextBox.Focus()
                gotoVehicleIdTextBox.SelectAll()
                Exit Sub
            End If

            Try
                Processor.FindVehicle(vehicleId, RetId, AdDate)
                If IsNumeric(RetId) Then retailerComboBox.SelectedValue = RetId

                retailerComboBox.Focus()

                If AdDate <> "" Then adDateTypeInDatePicker.Value = CType(AdDate, Date)
                adDateTypeInDatePicker.Focus()
                searchButton.Focus()

            Catch ex As System.Data.SqlClient.SqlException
                Trace.TraceError("gotoButton_Click(): FindVehicle. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, ex})
                MessageBox.Show("Unable to load information of vehicle " + vehicleId.ToString() + ". Error has occurred while saving information.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                Trace.TraceError("gotoButton_Click(): Unknown error. FindVehicle. Message=" + ex.Message, New Object() {"VehicleId=", vehicleId, ex})
                MessageBox.Show("Unable to load information of vehicle " + vehicleId.ToString() + ". Unknown error has occurred while loading information.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub
    End Class


  Structure SearchCriteria
    Private m_includeReview As Boolean
    Private m_retId, m_priorityId, m_dayRange As Integer
        Private m_mediaId As Integer
    Private m_adDate As DateTime


        Sub New(ByVal retId As Integer, ByVal adDate As DateTime, ByVal mediaId As Integer, ByVal priorityId As Integer, ByVal includeReview As Boolean)

            m_retId = retId
            m_adDate = adDate
            m_mediaId = mediaId
            m_priorityId = priorityId
            m_includeReview = includeReview

        End Sub


    Public Property AdDate() As DateTime
      Get
        Return m_adDate
      End Get
      Set(ByVal value As DateTime)
        m_adDate = value
      End Set
    End Property

    Public Property RetId() As Integer
      Get
        Return m_retId
      End Get
      Set(ByVal value As Integer)
        m_retId = value
      End Set
    End Property

        Public Property MediaId() As Integer
            Get
                Return m_mediaId
            End Get
            Set(ByVal value As Integer)
                m_mediaId = value
            End Set
        End Property

    Public Property Priority() As Integer
      Get
        Return m_priorityId
      End Get
      Set(ByVal value As Integer)
        m_priorityId = value
      End Set
    End Property

    Public Property DayRange() As Integer
      Get
        Return m_dayRange
      End Get
      Set(ByVal value As Integer)
        m_dayRange = value
      End Set
    End Property

    Public Property IncludeReviewedFamilies() As Boolean
      Get
        Return m_includeReview
      End Get
      Set(ByVal value As Boolean)
        m_includeReview = value
      End Set
    End Property

  End Structure


End Namespace