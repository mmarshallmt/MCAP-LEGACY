'test update
Namespace UI

    Public Class AdSearchForm
        Implements IForm


        Private _data As AdSearchDataSet
        Private _dataROP As ROPVehicleSearch    'Dataset for "ROP" Media type 
        Private sldMedia As Integer
        Private dateType As Byte = 1


        Protected Overrides Sub ClearAllInputs()

            'RemoveHandlerMarket()
            'RemoveHandlerNewspaper()

            retailerComboBox.SelectedValue = DBNull.Value
            retailerComboBox.SelectedIndex = -1
            retailerComboBox.Text = String.Empty

            marketComboBox.SelectedValue = DBNull.Value
            marketComboBox.SelectedIndex = -1
            marketComboBox.Text = String.Empty

            mediaComboBox.SelectedValue = DBNull.Value
            mediaComboBox.SelectedIndex = -1
            mediaComboBox.Text = String.Empty

            newspaperComboBox.SelectedValue = DBNull.Value
            newspaperComboBox.SelectedIndex = -1
            newspaperComboBox.Text = String.Empty

            SenderComboBox.SelectedValue = DBNull.Value
            SenderComboBox.SelectedIndex = -1
            SenderComboBox.Text = String.Empty

            StatusComboBox.SelectedValue = DBNull.Value
            StatusComboBox.SelectedIndex = -1
            StatusComboBox.Text = String.Empty

            languageComboBox.SelectedValue = DBNull.Value
            LanguageComboBox.SelectedIndex = -1
            LanguageComboBox.Text = String.Empty

            fromTypeInDatePicker.Value = System.DateTime.Today.AddMonths(-1)
            toTypeInDatePicker.Value = System.DateTime.Today

            addateRadioButton.Checked = True
            createDateRadioButton.Checked = False
            'vehicleDataGridView.DataSource = Nothing

            'AddHandlerMarket()
            'AddHandlerNewspaper()
        End Sub


        Private Sub LoadRetailers()
            Dim tempAdapter As AdSearchDataSetTableAdapters.RetTableAdapter


            tempAdapter = New AdSearchDataSetTableAdapters.RetTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(_data.Ret)
            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub


        Private Sub LoadMarkets()
            Dim tempAdapter As AdSearchDataSetTableAdapters.MktTableAdapter
            tempAdapter = New AdSearchDataSetTableAdapters.MktTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(_data.Mkt)
            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub


        Private Sub LoadMedia()
            Dim tempAdapter As AdSearchDataSetTableAdapters.MediaTableAdapter


            tempAdapter = New AdSearchDataSetTableAdapters.MediaTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(_data.Media)
            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub

        Private Sub LoadSender()
            Dim tempAdapter As AdSearchDataSetTableAdapters.SenderTableAdapter


            tempAdapter = New AdSearchDataSetTableAdapters.SenderTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(_data.Sender)
            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub

        Private Sub LoadStatus()
            Dim tempAdapter As AdSearchDataSetTableAdapters.StatusTableAdapter


            tempAdapter = New AdSearchDataSetTableAdapters.StatusTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(_data.Status)
            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub

        Private Sub LoadNewspaper()
            Dim tempAdapter As AdSearchDataSetTableAdapters.PublicationTableAdapter
            tempAdapter = New AdSearchDataSetTableAdapters.PublicationTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(_data.Publication)
            tempAdapter.Dispose()
            tempAdapter = Nothing
        End Sub

        Private Sub LoadLanguage()
            Dim tempAdapter As AdSearchDataSetTableAdapters.LanguageTableAdapter


            tempAdapter = New AdSearchDataSetTableAdapters.LanguageTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(_data.Language)
            tempAdapter.Dispose()
            tempAdapter = Nothing

        End Sub

        Private Sub LoadVehicleList()
            Dim retId, mktId, mediaId, publicationId, SenderId, Statusid, languageId As Integer
            Dim fromDt, toDt As DateTime
            Dim tempAdapter As AdSearchDataSetTableAdapters.VehicleListTableAdapter
            Dim dataView As DataView


            fromDt = fromTypeInDatePicker.Value.Value
            toDt = toTypeInDatePicker.Value.Value

            If retailerComboBox.SelectedValue Is Nothing OrElse retailerComboBox.SelectedValue Is DBNull.Value Then
                retId = Nothing
            Else
                retId = CType(retailerComboBox.SelectedValue, Integer)
            End If

            If marketComboBox.SelectedValue Is Nothing OrElse marketComboBox.SelectedValue Is DBNull.Value Then
                mktId = Nothing
            Else
                mktId = CType(marketComboBox.SelectedValue, Integer)
            End If

            If mediaComboBox.SelectedValue Is Nothing OrElse mediaComboBox.SelectedValue Is DBNull.Value Then
                mediaId = Nothing
            Else
                mediaId = CType(mediaComboBox.SelectedValue, Integer)
            End If

            If newspaperComboBox.SelectedValue Is Nothing OrElse newspaperComboBox.SelectedValue Is DBNull.Value Then
                publicationId = Nothing
            Else
                publicationId = CType(newspaperComboBox.SelectedValue, Integer)
            End If

            If SenderComboBox.SelectedValue Is Nothing OrElse SenderComboBox.SelectedValue Is DBNull.Value Then
                SenderId = Nothing
            Else
                SenderId = CType(SenderComboBox.SelectedValue, Integer)
            End If


            If StatusComboBox.SelectedValue Is Nothing OrElse StatusComboBox.SelectedValue Is DBNull.Value Then
                Statusid = Nothing
            Else
                Statusid = CType(StatusComboBox.SelectedValue, Integer)
            End If

            If LanguageComboBox.SelectedValue Is Nothing OrElse LanguageComboBox.SelectedValue Is DBNull.Value Then
                languageId = Nothing
            Else
                languageId = CType(LanguageComboBox.SelectedValue, Integer)
            End If


            If sldCheckBox.Checked = True Then
                sldMedia = 1
            Else
                sldMedia = 0
            End If
            If addateRadioButton.Checked = True Then
                dateType = 0
            Else
                dateType = 1
            End If

            ' If Media type "ROP" then it will fetch records from dataset file "ROPVechicleSearch.xsd"   (By Kapil) 
            If CType(mediaComboBox.SelectedValue, Int32) = 7 Then

                Dim tempRopAdapter As New ROPVehicleSearchTableAdapters.DsROPTableAdapter()
                tempRopAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
                SetAllCommandTimeouts(tempRopAdapter, 3000)
                tempRopAdapter.FillByROPVehicleSearch(_dataROP.DsROP, fromDt, toDt, mktId, publicationId, retId)

                PrepareRetailerForGrid()
                vehicleDataGridView.DataSource = _dataROP.DsROP

                tempRopAdapter.Dispose()
                tempRopAdapter = Nothing

                ' If Media type not "ROP" the Fetch records from View "VwCircular" (By Kapil)
            Else

                tempAdapter = New AdSearchDataSetTableAdapters.VehicleListTableAdapter()
                tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
                SetAllCommandTimeouts(tempAdapter, 3000)
                If flashCheckBox.Checked And CanadaFlashCheckBox.Checked Then
                    tempAdapter.FillByMixFlash(_data.VehicleList, fromDt, toDt, retId, mktId, mediaId, publicationId, Statusid, SenderId, languageId, dateType)
                ElseIf flashCheckBox.Checked Then
                    tempAdapter.FillByBreakDtRetMktMediaForFlashOrNational(_data.VehicleList, fromDt, toDt, retId, mktId, mediaId, publicationId, Statusid, SenderId, languageId, dateType)
                ElseIf CanadaFlashCheckBox.Checked Then
                    tempAdapter.FillByCanadaFlash(_data.VehicleList, fromDt, toDt, retId, mktId, mediaId, publicationId, Statusid, SenderId, languageId, dateType)
                Else
                    tempAdapter.FillByBreakDtRetMktMedia(_data.VehicleList, fromDt, toDt, retId, mktId, mediaId, publicationId, Statusid, SenderId, languageId, dateType)
                    'tempAdapter.FillByMixFlash(_data.VehicleList, retId, fromDt, toDt, mktId, mediaId, publicationId)
                End If

                dataView = New DataView(_data.VehicleList)
                PrepareRetailerForGrid()
                If sldCheckBox.Checked = False Then
                    dataView.RowFilter = "MediaId <> 24"
                End If
                vehicleDataGridView.DataSource = dataView
                'vehicleDataGridView.Columns(19).Visible = False

                tempAdapter.Dispose()
                tempAdapter = Nothing
                End If



        End Sub

        Private Sub LoadDataSet()

            LoadRetailers()
            LoadMarkets()
            LoadMedia()
            LoadNewspaper()
            LoadSender()
            LoadStatus()
            LoadLanguage()
        End Sub

        Private Sub PrepareDataGridView()

            vehicleDataGridView.DataSource = _data.VehicleList

            For i As Integer = 0 To vehicleDataGridView.ColumnCount - 1
                vehicleDataGridView.Columns(i).Visible = True
            Next

            If vehicleDataGridView.Columns.Contains("RetId") Then
                vehicleDataGridView.Columns("RetId").Visible = False
            End If
            If vehicleDataGridView.Columns.Contains("MktId") Then
                vehicleDataGridView.Columns("MktId").Visible = False
            End If
            If vehicleDataGridView.Columns.Contains("MediaId") Then
                vehicleDataGridView.Columns("MediaId").Visible = False
            End If
            If vehicleDataGridView.Columns.Contains("PublicationId") Then
                vehicleDataGridView.Columns("PublicationId").Visible = False
            End If

            'If vehicleDataGridView.Columns.Contains("Details") Then
            '    vehicleDataGridView.Columns.Remove(vehicleDataGridView.Columns("Details"))
            'End If

            If vehicleDataGridView.Columns.Contains("NewsPaper") Then
                vehicleDataGridView.Columns("Newspaper").DisplayIndex = 5
            End If
            vehicleDataGridView.ScrollBars = ScrollBars.Both
        End Sub

        'IF "ROP" Media type Then hide "Retailer" Column from Gridview (By Kapil) 
        Private Sub PrepareRetailerForGrid()
            If Convert.ToInt32(mediaComboBox.SelectedValue) = 7 Then
                If vehicleDataGridView.Columns.Contains("Retailer") Then
                    vehicleDataGridView.Columns("Retailer").Visible = False
                End If
            Else
                If vehicleDataGridView.Columns.Contains("Retailer") Then
                    vehicleDataGridView.Columns("Retailer").Visible = True
                End If
            End If
        End Sub

        Private Function AreInputsValid() As Boolean

            Return (fromTypeInDatePicker.Value.HasValue AndAlso toTypeInDatePicker.Value.HasValue)

        End Function


#Region " IForm Implementation "


        Public Event FormInitialized() Implements IForm.FormInitialized
        Public Event InitializingForm() Implements IForm.InitializingForm

        Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
        Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied

        Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

        End Sub

        Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

            Me.SuspendLayout()

            RaiseEvent InitializingForm()

            _data = New AdSearchDataSet()
            _dataROP = New ROPVehicleSearch()

            LoadDataSet()

            retailerComboBox.DisplayMember = "Descrip"
            retailerComboBox.ValueMember = "RetId"
            retailerComboBox.DataSource = _data.Ret

            marketComboBox.DisplayMember = "Descrip"
            marketComboBox.ValueMember = "MktId"
            marketComboBox.DataSource = _data.Mkt

            mediaComboBox.DisplayMember = "Descrip"
            mediaComboBox.ValueMember = "MediaId"
            mediaComboBox.DataSource = _data.Media

            newspaperComboBox.DisplayMember = "Descrip"
            newspaperComboBox.ValueMember = "PublicationId"
            newspaperComboBox.DataSource = _data.Publication

            SenderComboBox.DisplayMember = "Name"
            SenderComboBox.ValueMember = "SENDERID"
            SenderComboBox.DataSource = _data.Sender

            StatusComboBox.DisplayMember = "Descrip"
            StatusComboBox.ValueMember = "codeid"
            StatusComboBox.DataSource = _data.Status

            LanguageComboBox.DisplayMember = "Descrip"
            LanguageComboBox.ValueMember = "Languageid"
            LanguageComboBox.DataSource = _data.Language

            ClearAllInputs()
            PrepareDataGridView()

            RaiseEvent FormInitialized()

            Me.ResumeLayout()

        End Sub


#End Region

#Region "Private function"

        Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

            Me.Close()

        End Sub

        Private Sub resetButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles resetButton.Click
            'RemoveHandlerMarket()
            'RemoveHandlerNewspaper()

            LoadMarkets()
            LoadNewspaper()

            ClearAllInputs()

        End Sub

        Private Sub searchButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchButton.Click

            If AreInputsValid() = False Then Exit Sub

            LoadVehicleList()

            'Dim buttonColumn As System.Windows.Forms.DataGridViewButtonColumn

            'If vehicleDataGridView.ColumnCount < 21 Then
            '    buttonColumn = New System.Windows.Forms.DataGridViewButtonColumn()
            '    buttonColumn.Visible = True
            '    buttonColumn.DataPropertyName = "Details"
            '    vehicleDataGridView.Columns.Add(buttonColumn)
            'End If

            SearchLabel.Text = "Search Completed."
        End Sub

        'Private Sub vehicleDataGridView_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles vehicleDataGridView.CellContentClick
        'Dim vehicleId As Integer

        '        Dim vehicleStatusForm As UI.VehicleStatusReportForm


        '     If vehicleDataGridView.Columns(e.ColumnIndex).HeaderText <> String.Empty Then Exit Sub

        '    If e.RowIndex < 0 OrElse e.RowIndex >= vehicleDataGridView.RowCount Then Exit Sub

        '   If Integer.TryParse(vehicleDataGridView.Rows(e.RowIndex).Cells(vehicleDataGridView.Columns(0).Index).Value.ToString(), vehicleId) = False Then
        '    vehicleId = -1
        ' End If

        'vehicleStatusForm = New UI.VehicleStatusReportForm()
        'vehicleStatusForm.Init(FormStateEnum.View)
        'vehicleStatusForm.ApplyUserCredentials()
        '      vehicleStatusForm.Show(Me)
        'vehicleStatusForm.ShowVehicleInformation(vehicleId) ' inform
        'vehicleStatusForm.Hide()
        'vehicleStatusForm.ShowDialog(Me)
        'vehicleStatusForm.Dispose()
        'vehicleStatusForm = Nothing

        '    End Sub

        Private Sub newspaperComboBox_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newspaperComboBox.SelectedValueChanged
            RemoveHandlerMarket()
            Dim tempAdapter As AdSearchDataSetTableAdapters.MktTableAdapter
            tempAdapter = New AdSearchDataSetTableAdapters.MktTableAdapter
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            'If Convert.ToInt32(newspaperComboBox.SelectedValue) > 0 Then
            '    tempAdapter.FillByPublication(_data.Mkt, Convert.ToInt32(newspaperComboBox.SelectedValue))
            'Else
            '    tempAdapter.Fill(_data.Mkt)
            '    marketComboBox.SelectedIndex = -1
            '    mediaComboBox.SelectedIndex = -1
            'End If
            tempAdapter.Dispose()
            tempAdapter = Nothing
            AddHandlerMarket()
        End Sub


        Private Sub marketComboBox_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles marketComboBox.SelectedValueChanged
            RemoveHandlerNewspaper()
            Dim tempAdapter As AdSearchDataSetTableAdapters.PublicationTableAdapter
            tempAdapter = New AdSearchDataSetTableAdapters.PublicationTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            If Convert.ToInt32(marketComboBox.SelectedValue) > 0 Then
                tempAdapter.FillByMarket(_data.Publication, Convert.ToInt32(marketComboBox.SelectedValue))
                newspaperComboBox.SelectedIndex = -1
            Else
                tempAdapter.Fill(_data.Publication)
                marketComboBox.SelectedIndex = -1
                mediaComboBox.SelectedIndex = -1
            End If
            tempAdapter.Dispose()
            tempAdapter = Nothing
            AddHandlerNewspaper()
        End Sub
        'Private Sub newspaperComboBox_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    RemoveHandlerMarket()
        '    Dim tempAdapter As AdSearchDataSetTableAdapters.MktTableAdapter
        '    tempAdapter = New AdSearchDataSetTableAdapters.MktTableAdapter
        '    tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '    If Convert.ToInt32(newspaperComboBox.SelectedValue) > 0 Then
        '        tempAdapter.FillByPublication(_data.Mkt, Convert.ToInt32(newspaperComboBox.SelectedValue))
        '    Else
        '        tempAdapter.Fill(_data.Mkt)
        '    End If
        '    tempAdapter.Dispose()
        '    tempAdapter = Nothing
        '    AddHandlerMarket()
        'End Sub


        'Private Sub marketComboBox_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    RemoveHandlerNewspaper()
        '    Dim tempAdapter As AdSearchDataSetTableAdapters.PublicationTableAdapter
        '    tempAdapter = New AdSearchDataSetTableAdapters.PublicationTableAdapter()
        '    tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        '    If Convert.ToInt32(marketComboBox.SelectedValue) > 0 Then
        '        tempAdapter.FillByMarket(_data.Publication, Convert.ToInt32(marketComboBox.SelectedValue))
        '    Else
        '        tempAdapter.Fill(_data.Publication)
        '    End If
        '    tempAdapter.Dispose()
        '    tempAdapter = Nothing
        '    AddHandlerNewspaper()
        'End Sub

        'Private Sub marketComboBox_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles marketComboBox.KeyUp
        '    If Convert.ToInt32(marketComboBox.SelectedValue) = 0 Then
        '        RemoveHandlerMarket()
        '        RemoveHandlerNewspaper()
        '        LoadMarkets()
        '        LoadNewspaper()
        '        AddHandlerMarket()
        '        AddHandlerNewspaper()
        '    End If
        'End Sub

        'Private Sub newspaperComboBox_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles newspaperComboBox.KeyUp
        '    If Convert.ToInt32(newspaperComboBox.SelectedValue) = 0 Then
        '        RemoveHandlerMarket()
        '        RemoveHandlerNewspaper()
        '        LoadMarkets()
        '        LoadNewspaper()
        '        AddHandlerMarket()
        '        AddHandlerNewspaper()
        '    End If
        'End Sub

        Private Sub AddHandlerMarket()
            AddHandler marketComboBox.SelectedValueChanged, AddressOf marketComboBox_SelectedValueChanged
        End Sub

        Private Sub RemoveHandlerMarket()
            RemoveHandler marketComboBox.SelectedValueChanged, AddressOf marketComboBox_SelectedValueChanged
        End Sub

        Private Sub AddHandlerNewspaper()
            AddHandler newspaperComboBox.SelectedValueChanged, AddressOf newspaperComboBox_SelectedValueChanged
        End Sub

        Private Sub RemoveHandlerNewspaper()
            RemoveHandler newspaperComboBox.SelectedValueChanged, AddressOf newspaperComboBox_SelectedValueChanged
        End Sub
#End Region

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

        Private Sub marketComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles marketComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub marketComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles marketComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                marketComboBox.SelectedValue = -1
                retailerComboBox.SelectedValue = -1
            End If
        End Sub

        Private Sub newspaperComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles newspaperComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub newspaperComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles newspaperComboBox.KeyPress
            If e.KeyChar = Chr(Keys.Back) Then
                newspaperComboBox.SelectedValue = -1
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

        Private Sub searchButton_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchButton.GotFocus
            SearchLabel.Text = "Searching..."
        End Sub


        Private Sub AdSearchForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            'vehicleDataGridView.Columns("RetId").Visible = False
            ' vehicleDataGridView.Columns("MktId").Visible = False
            'vehicleDataGridView.Columns("MediaId").Visible = False
            'vehicleDataGridView.Columns("PublicationId").Visible = False
        End Sub



        Private Sub vehicleDataGridView_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles vehicleDataGridView.CellMouseDoubleClick
            Dim vehicleId As Integer

            Dim vehicleStatusForm As UI.VehicleStatusReportForm


            'If vehicleDataGridView.Columns(e.ColumnIndex).HeaderText <> String.Empty Then Exit Sub

            If e.RowIndex < 0 OrElse e.RowIndex >= vehicleDataGridView.RowCount Then Exit Sub

            If Integer.TryParse(vehicleDataGridView.Rows(e.RowIndex).Cells(vehicleDataGridView.Columns(0).Index).Value.ToString(), vehicleId) = False Then
                vehicleId = -1
            End If

            vehicleStatusForm = New UI.VehicleStatusReportForm()
            vehicleStatusForm.Init(FormStateEnum.View)
            vehicleStatusForm.ApplyUserCredentials()
            vehicleStatusForm.Show(Me)
            vehicleStatusForm.ShowVehicleInformation(vehicleId) ' inform
            vehicleStatusForm.Hide()
            vehicleStatusForm.ShowDialog(Me)
            vehicleStatusForm.Dispose()
            vehicleStatusForm = Nothing
        End Sub

        Private Sub sldCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles sldCheckBox.CheckedChanged
            If _data.VehicleList.Count > 0 Then
                LoadVehicleList()
            End If
        End Sub
    End Class

End Namespace
