Namespace UI.Processors

  Public Class PageDefinitions
    Inherits BaseClass

#Region "Member Variables"
    Private m_pageDefinitionsForm As PageDefinitionsForm
    Private m_vehicleId As Integer
    Private m_insertsDataTable As PageDefinitionsDataSet.InsertsDataTable
    Private m_pagesDataTable As New PageDefinitionsDataSet.PagesDataTable
    Private m_pageDataTable As New PageDefinitionsDataSet.PageDataTable
    Private m_pagesDBDataTable As PageDefinitionsDataSet.PagesDBDataTable
    Private m_insertsDBDataTable As PageDefinitionsDataSet.InsertsDBDataTable
        Private m_errorText As String
        Private isPreviousClicked As Boolean = False
#End Region

#Region "Constants"
        Public Const WARNING_COPYTOALL As String = "This will copy the currently selected size and Date(s) to all pages, " & _
                                                   "erasing any existing page size and Date(s) settings.  Do you want to continue?"
#End Region

#Region "Properties"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ParentForm() As PageDefinitionsForm
      Get
        Return m_pageDefinitionsForm
      End Get
      Set(ByVal value As PageDefinitionsForm)
        m_pageDefinitionsForm = value
      End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property VehicleId() As Integer
      Get
        Return m_vehicleId
      End Get
      Set(ByVal value As Integer)
        m_vehicleId = value
      End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property InsertsDataTable() As PageDefinitionsDataSet.InsertsDataTable
      Get
        Return m_insertsDataTable
      End Get
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PagesDataTable() As PageDefinitionsDataSet.PagesDataTable
      Get
        Return m_pagesDataTable
      End Get
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property InsertsDBDataTable() As PageDefinitionsDataSet.InsertsDBDataTable
      Get
        Return m_insertsDBDataTable
      End Get
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PagesDBDataTable() As PageDefinitionsDataSet.PagesDBDataTable
      Get
        Return m_pagesDBDataTable
      End Get
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsInsertsDataTableNothing() As Boolean
      Get
        Return (m_insertsDataTable Is Nothing)
      End Get
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property DataChanged() As Boolean
      Get
        Dim changed As Boolean
        changed = False
        Dim changes As DataTable
        changes = Me.PagesDataTable.GetChanges
        If Not changes Is Nothing Then
          If changes.Rows.Count > 0 Then
            changed = True
          End If
        End If
        Return changed
      End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ErrorText() As String
      Get
        Return m_errorText
      End Get
    End Property
#End Region

#Region "Class Functions"
    Public Sub New(ByRef parentForm As PageDefinitionsForm)
      m_pageDefinitionsForm = parentForm
      m_insertsDataTable = New PageDefinitionsDataSet.InsertsDataTable
      m_pagesDataTable = New PageDefinitionsDataSet.PagesDataTable
      m_pagesDBDataTable = New PageDefinitionsDataSet.PagesDBDataTable
      m_insertsDBDataTable = New PageDefinitionsDataSet.InsertsDBDataTable
    End Sub

    Public Sub Initialize()

    End Sub
#End Region

#Region "Subs"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ChangePage()
      'Debug.Print(Now.ToString & " FUNCTION BEGIN: ChangePage")
      Me.ParentForm.InChangePage = True
      If Me.ParentForm.PageNameComboBox.SelectedIndex > -1 Then
        LoadPage(Me.ParentForm.PageNameComboBox.SelectedIndex)
      End If
      'EnableControls()
      Me.ParentForm.InChangePage = False
      'Debug.Print(Now.ToString & " FUNCTION END: ChangePage")
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ChangePageOrder()
      'Debug.Print(Now.ToString & " FUNCTION BEGIN: ChangePageOrder")
      Me.ParentForm.InChangePageOrder = True
      Dim page As PageDefinitionsDataSet.PagesRow
      Dim pageName As String
      Dim insert As PageDefinitionsDataSet.InsertsRow
      Dim pageOrder As Integer
      If Not Me.ParentForm.PageOrderComboBox.Enabled Then
        'Debug.Print(Now.ToString & " PageOrderComboBox not Enabled")
        'Debug.Print(Now.ToString & " FUNCTION END: ChangePageOrder")
        Me.ParentForm.InChangePageOrder = False
        Exit Sub
      End If
      If Me.ParentForm.PageOrderComboBox.SelectedIndex > -1 Then
        pageOrder = CType(Me.ParentForm.PageOrderComboBox.Text, Integer)
        page = Me.PagesDataTable(Me.PagesDataTable.GetRowIndex(Me.ParentForm.PageNameComboBox.Text))
        pageName = page.PageName
        If page.PageTypeId <> PageDefinitionsDataSet.PageTypes.Base Then
          insert = Me.InsertsDataTable.GetRow(page.PageTypeId, page.InsertNumber)
          If Not page.IsReceivedOrderNull Then
            If page.ReceivedOrder <> pageOrder Then
              insert.StartPage = pageOrder
              Me.RedoPageOrder()
              Me.ParentForm.PagesDataGridView.Sort(Me.ParentForm.PagesDataGridView.Columns(Me.PagesDataTable.ReceivedOrderColumn.Ordinal), System.ComponentModel.ListSortDirection.Ascending)
              'Debug.Print(Now.ToString & " Setting selected page to " & pageName)
              Me.ParentForm.PageNameComboBox.SelectedIndex = GetPagesIndex(pageName)
            End If
          Else
            insert.StartPage = pageOrder
            Me.RedoPageOrder()
            Me.ParentForm.PagesDataGridView.Sort(Me.ParentForm.PagesDataGridView.Columns(Me.PagesDataTable.ReceivedOrderColumn.Ordinal), System.ComponentModel.ListSortDirection.Ascending)
            'Debug.Print(Now.ToString & " Setting selected page to " & pageName)
            Me.ParentForm.PageNameComboBox.SelectedIndex = GetPagesIndex(pageName)
          End If
        End If
      End If
      Me.ParentForm.InChangePageOrder = False
      'Debug.Print(Now.ToString & " FUNCTION END: ChangePageOrder")
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ChangePageSize()
      'Debug.Print(Now.ToString & " FUNCTION BEGIN: ChangePageSize")
      Me.ParentForm.InChangePageSize = True
      Dim page As PageDefinitionsDataSet.PagesRow
      'Debug.Print(Now.ToString & " SizeComboBox.SelectedIndex = " & SizeComboBox.SelectedIndex.ToString)
      If Me.ParentForm.SizeComboBox.SelectedIndex > -1 Then
        page = CType(Me.PagesDataTable.Rows(Me.PagesDataTable.GetRowIndex(Me.ParentForm.PageNameComboBox.Text)), PageDefinitionsDataSet.PagesRow)
        'Debug.Print(Now.ToString & " Saving size for page: " & page.PageName)
        page.SizeId = CType(Me.ParentForm.SizeComboBox.SelectedValue, Integer)
        page.Size = Me.ParentForm.SizeComboBox.Text
      End If
      Me.ParentForm.InChangePageSize = False
      'Debug.Print(Now.ToString & " FUNCTION END: ChangePageSize")
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ChangePageStart()
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: ChangePageSize")
            Me.ParentForm.InChangePageSize = True
            Dim page As PageDefinitionsDataSet.PagesRow
            'Debug.Print(Now.ToString & " SizeComboBox.SelectedIndex = " & SizeComboBox.SelectedIndex.ToString)
            If String.IsNullOrEmpty(Me.ParentForm.StartDatePicker.Value.ToString) = False Then
                page = CType(Me.PagesDataTable.Rows(Me.PagesDataTable.GetRowIndex(Me.ParentForm.PageNameComboBox.Text)), PageDefinitionsDataSet.PagesRow)
                'Debug.Print(Now.ToString & " Saving size for page: " & page.PageName)
                page.PageStartDt = CType(Me.ParentForm.StartDatePicker.Value, Date)
            Else
                page = CType(Me.PagesDataTable.Rows(Me.PagesDataTable.GetRowIndex(Me.ParentForm.PageNameComboBox.Text)), PageDefinitionsDataSet.PagesRow)
                'Debug.Print(Now.ToString & " Saving size for page: " & page.PageName)
                page.PageStartDt = CDate("#01/01/1900#")
            End If
            Me.ParentForm.InChangePageSize = False
            'Debug.Print(Now.ToString & " FUNCTION END: ChangePageSize")
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub ChangePageEnd()
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: ChangePageSize")
            Me.ParentForm.InChangePageSize = True
            Dim page As PageDefinitionsDataSet.PagesRow
            'Debug.Print(Now.ToString & " SizeComboBox.SelectedIndex = " & SizeComboBox.SelectedIndex.ToString)
            If String.IsNullOrEmpty(Me.ParentForm.EndDatePicker.Value.ToString) = False Then
                page = CType(Me.PagesDataTable.Rows(Me.PagesDataTable.GetRowIndex(Me.ParentForm.PageNameComboBox.Text)), PageDefinitionsDataSet.PagesRow)
                'Debug.Print(Now.ToString & " Saving size for page: " & page.PageName)
                page.PageEndDt = CType(Me.ParentForm.EndDatePicker.Value, Date)
            Else
                page = CType(Me.PagesDataTable.Rows(Me.PagesDataTable.GetRowIndex(Me.ParentForm.PageNameComboBox.Text)), PageDefinitionsDataSet.PagesRow)
                'Debug.Print(Now.ToString & " Saving size for page: " & page.PageName)
                page.PageEndDt = CDate("#01/01/1900#")
            End If
            Me.ParentForm.InChangePageSize = False
            'Debug.Print(Now.ToString & " FUNCTION END: ChangePageSize")
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CopyToAll()
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: CopyToAll")
            Dim page As PageDefinitionsDataSet.PagesRow
            If MessageBox.Show(WARNING_COPYTOALL, Application.ProductName, MessageBoxButtons.YesNo, _
                                  MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
                For Each page In m_pagesDataTable
                    page.SizeId = CType(Me.ParentForm.SizeComboBox.SelectedValue, Integer)
                    page.Size = Me.ParentForm.SizeComboBox.Text
                    If String.IsNullOrEmpty(Me.ParentForm.StartDatePicker.Value.ToString) = False Then page.PageStartDt = CType(Me.ParentForm.StartDatePicker.Value, Date)
                    If String.IsNullOrEmpty(Me.ParentForm.EndDatePicker.Value.ToString) = False Then page.PageEndDt = CType(Me.ParentForm.EndDatePicker.Value, Date)
                Next
            End If
            'Debug.Print(Now.ToString & " FUNCTION END: CopyToAll")
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CopyToNext()
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: CopyToNext")
            'Dim page As PageDefinitionsDataSet.PagesRow
            'Dim rowIndex As Integer
            'rowIndex = Me.ParentForm.PagesDataGridView.CurrentRow.Index
            'page = CType(Me.PagesDataTable.GetRow(CType(Me.ParentForm.PagesDataGridView.Rows(rowIndex).Cells(Me.PagesDataTable.PageNameColumn.Ordinal).Value, String)), PageDefinitionsDataSet.PagesRow)
            'If String.IsNullOrEmpty(Me.ParentForm.StartDatePicker.Value.ToString) = False Then page.PageStartDt = CType(Me.ParentForm.StartDatePicker.Value, Date)
            'If String.IsNullOrEmpty(Me.ParentForm.EndDatePicker.Value.ToString) = False Then page.PageEndDt = CType(Me.ParentForm.EndDatePicker.Value, Date)

            Dim prevSizeId As Integer
            prevSizeId = CType(Me.ParentForm.SizeComboBox.SelectedValue, Integer)
            MoveNext()
            Me.ParentForm.SizeComboBox.SelectedValue = prevSizeId
            'Debug.Print(Now.ToString & " FUNCTION END: CopyToNext")
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CopyStartDateToNext()
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: CopyToNext")
            Dim prevStartDate As Date
            prevStartDate = CType(Me.ParentForm.StartDatePicker.Value, Date)
            MoveNextStartDate()
            Me.ParentForm.StartDatePicker.Value = prevStartDate
            'Debug.Print(Now.ToString & " FUNCTION END: CopyToNext")
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub CopyEndDateToNext()
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: CopyToNext")
            Dim prevEndDate As Date
            prevEndDate = CType(Me.ParentForm.EndDatePicker.Value, Date)
            MoveNextEndDate()
            Me.ParentForm.EndDatePicker.Value = prevEndDate
            'Debug.Print(Now.ToString & " FUNCTION END: CopyToNext")
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub EnableControls()
            If Me.ParentForm.PageNameComboBox.SelectedIndex > -1 Then
                Dim maxIndex As Integer
                Dim currIndex As Integer
                currIndex = Me.ParentForm.PageNameComboBox.SelectedIndex
                maxIndex = Me.ParentForm.PageNameComboBox.Items.Count - 1
                Me.ParentForm.PrevButton.Enabled = Not (currIndex = 0)
                Me.ParentForm.NextButton.Enabled = Not (currIndex = maxIndex)
                Me.ParentForm.CopyToNextButton.Enabled = Not (currIndex = maxIndex)
                Me.ParentForm.StartDatePicker.Enabled = Not (currIndex = maxIndex)
                Me.ParentForm.EndDatePicker.Enabled = Not (currIndex = maxIndex)
                If Me.ParentForm.PagesDataGridView.CurrentRow Is Nothing Then
                    'Debug.Print(Now.ToString & " Current row is nothing")
                    Exit Sub
                End If
                If Me.ParentForm.PageNameComboBox.SelectedIndex <> Me.ParentForm.PagesDataGridView.CurrentRow.Index Then
                    LoadPage(Me.ParentForm.PageNameComboBox.SelectedIndex)
                End If
            End If
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="rowIndex"></param>
        ''' <remarks></remarks>
        Public Sub LoadPage(ByVal rowIndex As Integer)
            Dim page As PageDefinitionsDataSet.PagesRow
           
            page = CType(Me.PagesDataTable.GetRow(CType(Me.ParentForm.PagesDataGridView.Rows(rowIndex).Cells(Me.PagesDataTable.PageNameColumn.Ordinal).Value, String)), PageDefinitionsDataSet.PagesRow)
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: LoadPage(" & page.PageName & ")")
            PopulatePageOrder(page)
            If (page.PageTypeId <> PageDefinitionsDataSet.PageTypes.Base) And page.PageNumber = 1 Then
                Me.ParentForm.PageOrderComboBox.Enabled = True
            Else
                Me.ParentForm.PageOrderComboBox.Enabled = False
            End If
            If page.IsReceivedOrderNull Then
                Me.ParentForm.PageOrderComboBox.SelectedIndex = -1
            Else
                Me.ParentForm.PageOrderComboBox.SelectedIndex = Me.ParentForm.PageOrderComboBox.Items.IndexOf(page.ReceivedOrder)
            End If

            If page.IsSizeIdNull Then
                Me.ParentForm.SizeComboBox.SelectedIndex = -1
            Else
                Me.ParentForm.SizeComboBox.SelectedValue = page.SizeId
            End If
            If isPreviousClicked = True And page.IsPageStartDtNull = True Then
                page.PageStartDt = CDate("1/1/0001")
                page.PageEndDt = CDate("1/1/0001")
            Else

                If page.IsPageStartDtNull Then
                    page.PageStartDt = CDate("1/1/0001")
                End If
                If page.IsPageEndDtNull Then
                    page.PageEndDt = CDate("1/1/0001")
                End If

                If (page.PageStartDt = CDate("1/1/0001") And isPreviousClicked <> True) Then
                    page.SetPageStartDtNull()
                End If
                If (page.PageEndDt = CDate("1/1/0001") And isPreviousClicked <> True) Then
                    page.SetPageEndDtNull()
                End If

            End If


            If page.IsPageStartDtNull = False Then
                Me.ParentForm.StartDatePicker.Value = page.PageStartDt
                'Else
                '    Me.ParentForm.StartDatePicker.Text = ""
            End If

            If page.IsPageEndDtNull = False Then
                Me.ParentForm.EndDatePicker.Value = page.PageEndDt
                'Else
                '    Me.ParentForm.EndDatePicker.Text = ""
            End If
            'Debug.Print(Now.ToString & " FUNCTION END: LoadPage(" & page.PageName & ")")
            isPreviousClicked = False
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <remarks></remarks>
        Public Sub LoadVehiclePages(ByVal vehicleId As Integer)
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: LoadVehiclePages(" & vehicleId.ToString & ")")
            Dim dbPage As PageDefinitionsDataSet.PagesDBRow
            Dim dbInsert As PageDefinitionsDataSet.InsertsDBRow
            Dim page As PageDefinitionsDataSet.PagesRow
            Dim insert As PageDefinitionsDataSet.InsertsRow
            Dim pageAdapter As New PageDefinitionsDataSetTableAdapters.PageTableAdapter
            Dim pagesAdapter As New PageDefinitionsDataSetTableAdapters.PagesDBTableAdapter
            Dim insertsAdapter As New PageDefinitionsDataSetTableAdapters.InsertsDBTableAdapter


            'Ritesh (17 Jul 2008)
            'Reset connection string before filling datatables.
            pageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            pagesAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            insertsAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            pagesAdapter.FillBy(m_pagesDBDataTable, vehicleId)
            pageAdapter.FillBy(m_pageDataTable, vehicleId)
            insertsAdapter.Fill(m_insertsDBDataTable, CType(vehicleId, Integer))

            m_pageDefinitionsForm.BaseTextBox.Text = pagesAdapter.GetBasePageCount(vehicleId).ToString()
            'm_pageDefinitionsForm.WrapsTextBox.Text = pagesAdapter.GetWrapPageCount(vehicleId).ToString

            If m_pagesDBDataTable.Rows.Count > 0 Then
                m_insertsDataTable.Clear()
                For Each dbInsert In m_insertsDBDataTable
                    insert = m_insertsDataTable.AddInsertsRow(dbInsert.Number, dbInsert.PageCount)
                    If dbInsert.IsStartPageNull Then
                        insert.SetStartPageNull()
                    Else
                        insert.StartPage = dbInsert.StartPage
                    End If
                    If dbInsert.IsPageTypeIdNull() Then
                        insert.SetPageTypeIdNull()
                    Else
                        insert.PageTypeId = dbInsert.PageTypeId
                    End If
                Next
                m_pagesDataTable.Clear()
                For Each dbPage In m_pagesDBDataTable
                    page = m_pagesDataTable.AddPagesRow

                    page.PageId = dbPage.PageId
                    page.PageTypeId = dbPage.PageTypeId

                    If dbPage.IsReceivedOrderNull Then
                        page.SetReceivedOrderNull()
                    Else
                        page.ReceivedOrder = dbPage.ReceivedOrder
                    End If
                    If dbPage.IsSizeIDNull Then
                        'page.SetSizeIdNull()
                        page.SizeId = Nothing
                    Else
                        page.SizeId = dbPage.SizeID
                    End If
                    page.PageName = dbPage.PageName

                    If dbPage.IsImageNameNull Then
                        page.SetImageNameNull()
                    Else
                        page.ImageName = dbPage.ImageName
                    End If

                    If dbPage.IsSizeNull Then
                        page.SetSizeNull()
                    Else
                        page.Size = dbPage.Size
                    End If
                    If dbPage.IsInsertNumberNull Then
                        page.SetInsertNumberNull()
                    Else
                        page.InsertNumber = dbPage.InsertNumber
                    End If
                    If dbPage.IsPageNumberNull Then
                        page.SetPageNumberNull()
                    Else
                        page.PageNumber = dbPage.PageNumber
                    End If
                    If dbPage.IsPageStartDtNull OrElse dbPage.PageStartDt = CDate("01/01/1900") OrElse dbPage.PageStartDt = CDate("1/1/0001") Then
                        page.SetPageStartDtNull()
                        page.PageStartDt = Nothing
                    Else
                        page.PageStartDt = dbPage.PageStartDt
                    End If
                    If dbPage.IsPageEndDtNull OrElse dbPage.PageEndDt = CDate("01/01/1900") OrElse dbPage.PageEndDt = CDate("1/1/0001") Then
                        page.SetPageEndDtNull()
                        page.PageEndDt = Nothing
                    Else
                        page.PageEndDt = dbPage.PageEndDt
                    End If
                Next
                m_pagesDataTable.AcceptChanges()
                If Me.ParentForm.PageNameComboBox.Items.Count >= 0 Then Me.ParentForm.PageNameComboBox.SelectedIndex = -1
                Me.ParentForm.PageNameComboBox.Focus()
            End If
            'Debug.Print(Now.ToString & " FUNCTION END: LoadVehiclePages")
            Me.ParentForm.VehicleStartEndLabel.Text = GetVehicleStartEndDt()
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub MoveNext()
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: MoveNext")
            If Me.ParentForm.PageNameComboBox.SelectedIndex < Me.ParentForm.PageNameComboBox.Items.Count - 1 And Me.ParentForm.PageNameComboBox.SelectedIndex > -1 Then
                Me.ParentForm.PageNameComboBox.SelectedIndex = Me.ParentForm.PageNameComboBox.SelectedIndex + 1
            End If
            'Debug.Print(Now.ToString & " FUNCTION END: MoveNext")
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub MoveNextStartDate()
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: MoveNext")
            If String.IsNullOrEmpty(Me.ParentForm.StartDatePicker.Value.ToString) = False Then
                Me.ParentForm.StartDatePicker.Value = Me.ParentForm.StartDatePicker.Value
            End If
            'Debug.Print(Now.ToString & " FUNCTION END: MoveNext")
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub MoveNextEndDate()
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: MoveNext")
            If String.IsNullOrEmpty(Me.ParentForm.EndDatePicker.Value.ToString) = False Then
                Me.ParentForm.EndDatePicker.Value = Me.ParentForm.EndDatePicker.Value
            End If
            'Debug.Print(Now.ToString & " FUNCTION END: MoveNext")
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub MovePrevious()
            isPreviousClicked = True
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: MovePrevious")
            If Me.ParentForm.PageNameComboBox.SelectedIndex > 0 Then
                Me.ParentForm.PageNameComboBox.SelectedIndex = Me.ParentForm.PageNameComboBox.SelectedIndex - 1
            End If

            'Debug.Print(Now.ToString & " FUNCTION END: MovePrevious")
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="startval"></param>
        ''' <param name="endVal"></param>
        ''' <param name="cmb"></param>
        ''' <remarks></remarks>
        Public Sub PopulateComboBoxInteger(ByVal startval As Integer, ByVal endVal As Integer, ByRef cmb As ComboBox)
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: PopulateComboBoxInteger")
            Dim i As Integer
            If startval > endVal Then
                Exit Sub
            End If
            cmb.Items.Clear()
            For i = startval To endVal
                cmb.Items.Add(i)
            Next
            'Debug.Print(Now.ToString & " FUNCTION END: PopulateComboBoxInteger")
        End Sub
        ''' <summary>
        ''' Pull page information for the vehicle ID, 
        ''' pull page size information for drop down
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub PopulateForm()
            Dim tempAdapter As PageDefinitionsDataSetTableAdapters.PageTypeTableAdapter


            'Debug.Print(Now.ToString & " FUNCTION BEGIN: PopulateForm")
            'Ritesh (17 Jul 2008)
            'Reset connection string before filling datatable.
            Me.ParentForm.SizeTableAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            Me.ParentForm.SizeTableAdapter.Fill(Me.ParentForm.PageDefinitionsDataSet.Size)

            tempAdapter = New PageDefinitionsDataSetTableAdapters.PageTypeTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
            tempAdapter.Fill(Me.ParentForm.PageDefinitionsDataSet.PageType)
            tempAdapter.Dispose()
            tempAdapter = Nothing
            'Debug.Print(Now.ToString & " FUNCTION END: PopulateForm")
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="page"></param>
        ''' <remarks></remarks>
        Public Sub PopulatePageOrder(ByRef page As PageDefinitionsDataSet.PagesRow)
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: PopulatePageOrder")
            Dim i As Integer
            Dim disallowedPages As New ArrayList
            Dim insertNumber As Integer = 0
            Dim insertPageCount As Integer = 0
            Dim insert As PageDefinitionsDataSet.InsertsRow

            If (page.PageTypeId <> PageDefinitionsDataSet.PageTypes.Base) And page.PageNumber = 1 Then
                insert = Me.InsertsDataTable.GetRow(page.PageTypeId, page.InsertNumber)
                insertNumber = insert.Number
                insertPageCount = insert.PageCount

                For i = Me.PagesDataTable.Count - (insert.PageCount - 2) To Me.PagesDataTable.Count
                    'Debug.Print(Now.ToString & " Disallowing " & i.ToString & " because of this inserts Page Count of " & insert.PageCount.ToString)
                    If Not disallowedPages.Contains(i) Then
                        disallowedPages.Add(i)
                    End If
                Next
            End If
            insert = Nothing
            Me.ParentForm.PageOrderComboBox.Items.Clear()
            For i = 1 To Me.PagesDataTable.Count
                If Not disallowedPages.Contains(i) Then
                    Me.ParentForm.PageOrderComboBox.Items.Add(i)
                End If
            Next
            'Debug.Print(Now.ToString & " FUNCTION END: PopulatePageOrder")
        End Sub
        ''' <summary>
        ''' Populate page data table, just deleting or adding new pages
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub FastPopulatePageDataTable()
            Dim basePages As PageDefinitionsDataSet.PagesRowCollection
            Dim wrapPages As PageDefinitionsDataSet.PagesRowCollection
            Dim insertPages As PageDefinitionsDataSet.PagesRowCollection
            basePages = Me.PagesDataTable.GetBasePages
            'wrapPages = Me.PagesDataTable.GetWrapPages
            insertPages = Me.PagesDataTable.GetAllInsertPages

            If Me.GetBasePageCount > basePages.Count Then
                ' add pages
            ElseIf Me.GetBasePageCount < basePages.Count Then
                ' remove pages
            End If

            If Me.GetInsertTotalPageCount > insertPages.Count Then
                ' add inserts
            ElseIf Me.GetInsertTotalPageCount < insertPages.Count Then
                ' remove inserts
            End If
        End Sub

        ''' <summary>
        ''' Gets abbrivation for supplied PageTypeId.
        ''' </summary>
        ''' <param name="pageTypeId"></param>
        ''' <remarks></remarks>
        Private Function GetAbbrivationForPageTypeId(ByVal pageTypeId As String) As String
            Dim abbrivation As String
            Dim abbrQuery As System.Data.EnumerableRowCollection(Of PageDefinitionsDataSet.PageTypeRow)


            abbrQuery = From abbr In Me.ParentForm.PageDefinitionsDataSet.PageType _
                        Where abbr.PageTypeId = pageTypeId _
                        Select abbr

            If abbrQuery.Count() = 0 Then
                abbrivation = ""
            Else
                abbrivation = abbrQuery(0).Abbr
            End If

            abbrQuery = Nothing

            Return abbrivation
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub PopulatePageDataTable()
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: PopulatePageDataTable")
            Dim i As Integer
            Dim insert As PageDefinitionsDataSet.InsertsRow
            Dim page As PageDefinitionsDataSet.PagesRow
            Dim pageOrder As Integer
            Dim oldPages As PageDefinitionsDataSet.PagesDataTable
            Dim oldPage As PageDefinitionsDataSet.PagesRow

            oldPages = CType(Me.PagesDataTable.Copy, PageDefinitionsDataSet.PagesDataTable)

            Me.PagesDataTable.Clear()

            pageOrder = 1

            For i = 1 To GetBasePageCount()
                page = Me.PagesDataTable.NewPagesRow
                page.PageName = i.ToString()
                page.PageTypeId = CType(PageDefinitionsDataSet.PageTypes.Base, Char)
                page.ReceivedOrder = pageOrder
                page.PageNumber = i
                pageOrder += 1
                'Debug.Print(Now.ToString & " Adding page: " & page.ToString)
                Me.PagesDataTable.AddPagesRow(page)
            Next

            If Not Me.IsInsertsDataTableNothing Then
                For Each insert In Me.InsertsDataTable.Rows
                    Try
                        For i = 1 To insert.PageCount
                            page = Me.PagesDataTable.NewPagesRow
                            'page.PageTypeId = CType(PageDefinitionsDataSet.PageTypes.Insert, Char)
                            page.PageTypeId = insert.PageTypeId
                            page.InsertNumber = insert.Number
                            page.ReceivedOrder = insert.StartPage + (i - 1)
                            page.PageNumber = i
                            page.PageName = GetAbbrivationForPageTypeId(page.PageTypeId) & page.InsertNumber.ToString & "-" & page.PageNumber.ToString
                            'Debug.Print(Now.ToString & " Adding page: " & page.ToString)
                            Me.PagesDataTable.AddPagesRow(page)
                        Next
                    Catch rnitex As System.Data.RowNotInTableException
                        'Debug.Print(Now.ToString & " EXCEPTION:" & rnitex.ToString)
                    End Try
                Next
            End If

            Me.RedoPageOrder()

            If oldPages.Rows.Count > 0 Then
                For Each oldPage In oldPages
                    page = Me.PagesDataTable.GetRow(oldPage.PageName)
                    If Not page Is Nothing Then
                        If Not oldPage.IsSizeIdNull Then
                            page.SizeId = oldPage.SizeId
                            page.Size = oldPage.Size
                        End If
                        If Not oldPage.IsPageStartDtNull Then
                            page.PageStartDt = CDate(oldPage.PageStartDt)
                        End If

                        If Not oldPage.IsPageEndDtNull Then
                            page.PageEndDt = CDate(oldPage.PageEndDt)
                       
                        End If

                        
                    End If
                Next
            End If
            Me.ParentForm.PagesDataGridView.Sort(Me.ParentForm.PagesDataGridView.Columns(Me.PagesDataTable.ReceivedOrderColumn.Ordinal), System.ComponentModel.ListSortDirection.Ascending)
            'Debug.Print(Now.ToString & " FUNCTION END: PopulatePageDataTable")
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub RedoPageOrder()
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: RedoPageOrder")
            Dim pages As New ArrayList
            Dim page As PageDefinitionsDataSet.PagesRow
            Dim pageType As PageDefinitionsDataSet.PageTypeRow
            Dim insert As PageDefinitionsDataSet.InsertsRow
            Dim insertPoint As Integer
            Dim i As Integer

            Dim dummyPage As PageDefinitionsDataSet.PagesRow
            dummyPage = Me.PagesDataTable.NewPagesRow
            dummyPage.PageName = "dummy"


            For Each page In m_pagesDataTable.Select("PageTypeId = '" & PageDefinitionsDataSet.PageTypes.Base & "'", "PageNumber ASC")
                pages.Add(page)
            Next

            ''Add dummy pages to help preserve location
            For Each pageType In Me.ParentForm.PageDefinitionsDataSet.PageType

                For Each insert In m_insertsDataTable.Select("PageTypeId = '" & pageType.PageTypeId & "' AND StartPage IS NOT NULL", "StartPage ASC")
                    Debug.Print(insert.ToString)
                    insertPoint = insert.StartPage - 1
                    'fill Table with DummyPages if we haven't expanded the Pages table yet.  Will run through and delete these at the end
                    If pages.Count < insertPoint Then
                        Dim countDiff As Integer
                        countDiff = insertPoint - pages.Count
                        Dim k As Integer
                        For k = 1 To countDiff
                            pages.Add(dummyPage)
                        Next k
                    End If
                    For Each page In m_pagesDataTable.Select("PageTypeId = '" & pageType.PageTypeId & "' AND InsertNumber = " & insert.Number.ToString(), "PageNumber ASC")
                        Try
                            'Remove Dummy if we are replacing it now so we don't push other records down too far
                            If pages.Count > insertPoint Then
                                If CType(pages(insertPoint), PageDefinitionsDataSet.PagesRow).PageName = "dummy" Then
                                    pages.RemoveAt(insertPoint)
                                End If
                            End If
                            pages.Insert(insertPoint, page)

                        Catch ex As Exception
                            'Debug.Print(Now.ToString & " Can't insert " & page.ToString & " at " & insertPoint.ToString)
                            'Debug.Print(Now.ToString & " EXCEPTION: " & ex.ToString)
                        End Try
                        insertPoint += 1
                    Next
                Next

            Next

            'Step through and delete the dummy pages
            Dim dummyFound As Boolean
            dummyFound = True
            While dummyFound
                dummyFound = False
                For Each page In pages
                    If page.PageName = "dummy" Then
                        dummyFound = True
                        pages.Remove(page)
                        Exit For
                    End If
                Next
            End While

            ''Debug.Print(Now.ToString & " PageOrder = ")
            i = 1
            For Each page In pages
                'Debug.Print(Now.ToString & " Setting Page:" & page.PageName & ".ReceivedOrder to " & i.ToString)
                page.ReceivedOrder = i
                i += 1
                ''Debug.Print(page.ToString)
            Next
            'Debug.Print(Now.ToString & " FUNCTION END: RedoPageOrder")
        End Sub
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="enabled"></param>
        ''' <remarks></remarks>
        Public Sub SetControlsEnabled(ByVal enabled As Boolean)
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: SetControlsEnabled")
            Me.ParentForm.PageNameComboBox.Enabled = enabled
            Me.ParentForm.sizeMaskedTextBox.Enabled = enabled
            Me.ParentForm.SizeComboBox.Enabled = enabled
            Me.ParentForm.NextButton.Enabled = enabled
            Me.ParentForm.PrevButton.Enabled = enabled
            Me.ParentForm.CopyToAllButton.Enabled = enabled
            Me.ParentForm.CopyToNextButton.Enabled = enabled
            If isPageDtEnable() Then
                Me.ParentForm.StartDatePicker.Enabled = enabled
                Me.ParentForm.EndDatePicker.Enabled = enabled
            Else
                Me.ParentForm.StartDatePicker.Enabled = False
                Me.ParentForm.EndDatePicker.Enabled = False
            End If
            'Debug.Print(Now.ToString & " FUNCTION END: SetControlsEnabled")
        End Sub
#End Region

#Region "Functions"
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetBasePageCount() As Integer
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: GetBasePageCount")
            Dim baseCount As Integer
            Integer.TryParse(Me.ParentForm.BaseTextBox.Text, baseCount)
            'Debug.Print(Now.ToString & " FUNCTION END: GetBasePageCount")
            Return baseCount
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetInsertTotalPageCount() As Integer
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: GetInsertTotalPageCount")
            Dim insertCount As Integer
            Dim ir As PageDefinitionsDataSet.InsertsRow
            insertCount = 0
            For Each ir In Me.InsertsDataTable.Rows
                insertCount += ir.PageCount
            Next
            'Debug.Print(Now.ToString & " FUNCTION END: GetInsertTotalPageCount")
            Return insertCount
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPageCount() As Integer
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: GetPageCount")
            Dim pageCount As Integer
            'pageCount = GetBasePageCount() + GetWrapPageCount() + GetInsertTotalPageCount()
            pageCount = GetBasePageCount() + GetInsertTotalPageCount()
            'Debug.Print(Now.ToString & " FUNCTION END: GetPageCount")
            Return pageCount
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="pageName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPagesIndex(ByVal pageName As String) As Integer
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: GetPagesIndex")
            Dim i As Integer
            For i = 0 To Me.ParentForm.PagesDataGridView.RowCount - 1
                If CType(Me.ParentForm.PagesDataGridView.Rows(i).Cells(Me.PagesDataTable.PageNameColumn.Ordinal).Value, String) = pageName Then
                    'Debug.Print(Now.ToString & " FUNCTION END: GetPagesIndex")
                    Return i
                End If
            Next
            'Debug.Print(Now.ToString & " FUNCTION END: GetPagesIndex")
            Return -1
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsPageCountDifferent() As Boolean
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: IsPageCountDifferent")
            Dim diff As Boolean
            diff = (GetPageCount() <> Me.PagesDataTable.Rows.Count)
            'Debug.Print(Now.ToString & " FUNCTION END: IsPageCountDifferent")
            Return diff
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsValid() As Boolean
            Dim valid As Boolean
            valid = True
            ' make sure all pages have defined spaces
            Dim pagesRow As PageDefinitionsDataSet.PagesRow
            Dim pagesWithNoSize As New ArrayList
            Dim pagesWithNoOrder As New ArrayList
            Dim page As String
            m_errorText = ""
            For Each pagesRow In Me.PagesDataTable
                If pagesRow.IsSizeIdNull Or pagesRow.SizeId = 0 Then
                    pagesWithNoSize.Add(pagesRow.PageName)
                End If
                If pagesRow.IsReceivedOrderNull Then
                    pagesWithNoOrder.Add(pagesRow.PageName)
                End If
            Next
            If pagesWithNoSize.Count > 0 Then
                If pagesWithNoSize.Count = 1 Then
                    m_errorText &= "Page "
                Else
                    m_errorText &= "Pages "
                End If
                For Each page In pagesWithNoSize
                    m_errorText &= page & ","
                Next
                m_errorText = Left(m_errorText, Len(m_errorText) - 1) & " "
                If pagesWithNoSize.Count = 1 Then
                    m_errorText &= "does "
                Else
                    m_errorText &= "do "
                End If
                m_errorText &= "not have size defined." & vbCrLf
            End If
            If pagesWithNoOrder.Count > 0 Then
                If pagesWithNoOrder.Count = 1 Then
                    m_errorText &= "Page "
                Else
                    m_errorText &= "Pages "
                End If
                For Each page In pagesWithNoOrder
                    m_errorText &= page & ","
                Next
                m_errorText = Left(m_errorText, Len(m_errorText) - 1) & " "
                If pagesWithNoOrder.Count = 1 Then
                    m_errorText &= "does "
                Else
                    m_errorText &= "do "
                End If
                m_errorText &= "not have received order defined." & vbCrLf
            End If
            valid = (m_errorText = "")
            Return valid
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function PageCountDefined() As Boolean
            'Debug.Print(Now.ToString & " FUNCTION BEGIN: PageCountDefinied")
            Dim defined As Boolean
            defined = (GetPageCount() > 0)
            'Debug.Print(Now.ToString & " FUNCTION END: PageCountDefinied")
            Return defined
        End Function
        Public Function hasImageName(ByVal _vehicleid As Integer) As Boolean


            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim obj As Object
            Dim stat As Integer

            cmd = New System.Data.SqlClient.SqlCommand
            con = New System.Data.SqlClient.SqlConnection

            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()

            cmd.Connection = con

            cmd.CommandType = CommandType.Text

            cmd.CommandText = "select Vehicleid from page where Vehicleid =" + _vehicleid.ToString + " and ImageName is not null"

            obj = cmd.ExecuteScalar

            If IsDBNull(obj) Then
                hasImageName = False
            Else
                hasImageName = True

            End If

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing


        End Function


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Public Function SavePages() As Boolean
            Dim pagesRow As PageDefinitionsDataSet.PagesRow
            Dim pageRow As PageDefinitionsDataSet.PageRow
            Dim pageAdapter As New PageDefinitionsDataSetTableAdapters.PageTableAdapter
            Dim vehicleHasImageName As Boolean
            Dim ImageNames As Dictionary(Of Integer, String)
            m_pageDataTable = New PageDefinitionsDataSet.PageDataTable
            pageAdapter.FillBy(m_pageDataTable, VehicleId)

            pageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

            ''Build Array of ReceivedOrder/ImageNames for this vehicle
            If m_pagesDataTable.Count > 0 Then
                FillImageArray(Me.VehicleId, ImageNames)
            End If

            vehicleHasImageName = hasImageName(VehicleId)
            For Each pagesRow In m_pagesDataTable
                pageRow = m_pageDataTable.GetRow(pagesRow.PageName)
                If pageRow Is Nothing Then
                    pageRow = m_pageDataTable.NewPageRow
                    pageRow.SetImageNameNull()
                End If
                pageRow.VehicleId = Me.VehicleId
                pageRow.SizeID = pagesRow.SizeId
                pageRow.PageTypeId = pagesRow.PageTypeId
                pageRow.ReceivedOrder = pagesRow.ReceivedOrder
                pageRow.PageName = pagesRow.PageName

                'If pageRow.IsPageStartDtNull OrElse pagesRow.PageStartDt = CDate("12:00:00 AM") Then
                '    pagesRow.PageStartDt = CDate("01/01/1900")
                'ElseIf IsDBNull(pagesRow.PageStartDt) Then
                '    pagesRow.PageStartDt = CDate("01/01/1900")
                'ElseIf pagesRow.PageStartDt = CDate("12:00:00 AM") Then
                '    pagesRow.PageStartDt = CDate("01/01/1900")
                'End If


                If pagesRow.IsPageStartDtNull() OrElse pagesRow.PageStartDt = CDate("12:00:00 AM") Then 'pagesRow.PageStartDt = CDate("01/01/1900")
                    'If pagesRow.PageStartDt = CDate("12:00:00 AM") Then
                    pageRow.SetPageStartDtNull() 'pagesRow.PageStartDt = CDate("01/01/1900")
                Else
                    pageRow.PageStartDt = pagesRow.PageStartDt
                End If

                If pagesRow.IsPageEndDtNull OrElse pagesRow.PageEndDt = CDate("12:00:00 AM") Then
                    pageRow.SetPageEndDtNull()
                Else
                    pageRow.PageEndDt = pagesRow.PageEndDt
                End If

                'Ritesh (17 Jul 2008)
                'If NewPageRow then add it in datatable.
                If pageRow.RowState = DataRowState.Detached Then m_pageDataTable.AddPageRow(pageRow)
            Next

            'Removing rows from Page table.
            For Each pageRow In m_pageDataTable.Rows
                pagesRow = m_pagesDataTable.GetRow(pageRow.PageName)
                If pagesRow Is Nothing Then pageRow.Delete()

            Next

            pageAdapter.Update(m_pageDataTable)

            'Make sure that ImageNames are updated per the ImageArray
            Dim rOrderPair As KeyValuePair(Of Integer, String)
            If vehicleHasImageName Then
                For Each rOrderPair In ImageNames
                    UpdatePageInfo(Me.VehicleId, rOrderPair.Key, rOrderPair.Value)
                Next rOrderPair
            End If
            Return True

        End Function
        'Pulls the imageName into Array
        Public Sub FillImageArray(ByVal VehicleId As Integer, ByRef ImageNames As Dictionary(Of Integer, String))
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim rdr As System.Data.SqlClient.SqlDataReader

            cmd = New System.Data.SqlClient.SqlCommand
            con = New System.Data.SqlClient.SqlConnection

            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()

            cmd.Connection = con

            cmd.CommandType = CommandType.Text

            cmd.CommandText = "select ReceivedOrder, ImageName from Page where VehicleId = " + VehicleId.ToString + " Order by ReceivedOrder"


            rdr = cmd.ExecuteReader()
            ImageNames = New Dictionary(Of Integer, String)
            Do While (rdr.Read())
                ImageNames.Add(CType(rdr.Item("ReceivedOrder").ToString, Integer), rdr.Item("ImageName").ToString)
            Loop

            If Not rdr.IsClosed Then
                rdr.Close()
            End If
            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing
        End Sub

        Public Function CapturePage(ByVal _vehicleid As Integer) As DataSet


            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim adpt As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet

            cmd = New System.Data.SqlClient.SqlCommand
            con = New System.Data.SqlClient.SqlConnection

            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()

            cmd.Connection = con

            cmd.CommandType = CommandType.Text

            cmd.CommandText = "Select * FROM page WHERE Vehicleid =" + _vehicleid.ToString

            adpt = New System.Data.SqlClient.SqlDataAdapter(cmd)

            adpt.Fill(ds)

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

            Return ds
        End Function

        Public Sub UpdatePageInfo(ByVal vehicleid As Integer, ByVal receivedorder As Integer, ByVal imagename As String)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection


            cmd = New System.Data.SqlClient.SqlCommand
            con = New System.Data.SqlClient.SqlConnection

            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()

            cmd.Connection = con

            cmd.CommandType = CommandType.Text

            cmd.CommandText = "Update Page set ImageName = '" + imagename + "' where VehicleId = " + vehicleid.ToString + " and ReceivedOrder = " + receivedorder.ToString + " and isnull(ImageName,'') <> '" + imagename + "' "

            If imagename <> "NULL" Then
                cmd.ExecuteNonQuery()
            End If

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing
        End Sub

        Public Sub RenameVehiclePageImageFilesByPageName(ByVal vehicleId As Integer, ByVal ReceivedOrder As Integer, ByVal ImageName As String)
            Dim pageImageFolderCounter, pageImageFileCounter As Integer
            Dim pageImageFolderPath As String
            Dim pageImageFilePath As System.Text.StringBuilder


            pageImageFilePath = New System.Text.StringBuilder()

            For pageImageFolderCounter = 1 To 4
                pageImageFolderPath = Nothing
                If pageImageFolderCounter = 1 Then
                    pageImageFolderPath = GetVehicleImageFolderPath(vehicleId, VehicleImageSizeEnum.Unsized)
                ElseIf pageImageFolderCounter = 2 Then
                    pageImageFolderPath = GetVehicleImageFolderPath(vehicleId, VehicleImageSizeEnum.Large)
                ElseIf pageImageFolderCounter = 3 Then
                    pageImageFolderPath = GetVehicleImageFolderPath(vehicleId, VehicleImageSizeEnum.Normal)
                Else
                    pageImageFolderPath = GetVehicleImageFolderPath(vehicleId, VehicleImageSizeEnum.Thumbnail)
                End If

                If My.Computer.FileSystem.DirectoryExists(pageImageFolderPath) = False Then
                    'MessageBox.Show("Unable to find page image folder for vehicle " + vehicleId.ToString() _
                    '                + " at " + Environment.NewLine + pageImageFolderPath _
                    '                , My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Continue For
                End If

                ' For pageImageFileCounter = 0 To Data.Page.Count - 1
                pageImageFilePath.Append(pageImageFolderPath)
                pageImageFilePath.Append("\")
                pageImageFilePath.Append(ImageName)
                pageImageFilePath.Append(ImageFileExtension)

                'rename image files
                If My.Computer.FileSystem.FileExists(pageImageFilePath.ToString()) Then
                    Dim newImageFileName As String
                    newImageFileName = ReceivedOrder.ToString("000") + ImageFileExtension
                    My.Computer.FileSystem.RenameFile(pageImageFilePath.ToString(), newImageFileName)
                    newImageFileName = Nothing
                End If

                pageImageFilePath.Remove(0, pageImageFilePath.Length)
                'Next
            Next

        End Sub

        Protected Function GetVehicleImageFolderPath _
    (ByVal vehicleId As Integer, ByVal imageSize As VehicleImageSizeEnum) _
    As String
            Dim vehicleFolder As String
            Dim imagePath As System.Text.StringBuilder


            imagePath = New System.Text.StringBuilder

            vehicleFolder = GetVehicleFolderPath(vehicleId, UserLocationId, GetPathType("Master"))      ' new logic that will retrieve data in the image path table
            If String.IsNullOrEmpty(vehicleFolder) = True Then vehicleFolder = GetVehicleFolderPath(vehicleId)
            imagePath.Append(vehicleFolder)
            imagePath.Append("\")
            If imageSize = VehicleImageSizeEnum.Unsized Then
                imagePath.Append(UnsizedPageImageFolderName)
            ElseIf imageSize = VehicleImageSizeEnum.Large Then
                imagePath.Append(FullSizedPageImageFolderName)
            ElseIf imageSize = VehicleImageSizeEnum.Normal Then
                imagePath.Append(MidSizedPageImageFolderName)
            ElseIf imageSize = VehicleImageSizeEnum.Thumbnail Then
                imagePath.Append(ThumbSizedPageImageFolderName)
            End If

            vehicleFolder = Nothing

            Return imagePath.ToString()

        End Function

        Protected Function GetVehicleFolderPath(ByVal vehicleId As Integer, ByVal LocationId As Integer, ByVal PathType As Integer) As String
            Dim createDt As DateTime
            Dim ImageCommand As System.Data.SqlClient.SqlCommand
            Dim ImageFolderPath As System.Text.StringBuilder
            Dim vehicleCreateDt As Object
            Dim path As String


            ImageCommand = New System.Data.SqlClient.SqlCommand
            ImageFolderPath = New System.Text.StringBuilder

            Try
                With ImageCommand
                    .CommandText = "SELECT CreateDt FROM Vehicle WHERE VehicleId=" + vehicleId.ToString()
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    vehicleCreateDt = .ExecuteScalar()
                End With

            Catch ex As System.Data.SqlClient.SqlException
                My.Application.Log.WriteException(ex)

            Finally
                If ImageCommand.Connection.State <> ConnectionState.Closed Then ImageCommand.Connection.Close()
            End Try


            If (vehicleCreateDt Is Nothing OrElse vehicleCreateDt Is DBNull.Value) Then
                Throw New System.ApplicationException("Invalid vehicle creation date found.")

            Else
                createDt = CType(vehicleCreateDt, DateTime)
                'change 2 
                path = GetImagePath(createDt.ToString("yyyyMM"), LocationId, PathType)
                If String.IsNullOrEmpty(path) = False Then
                    ImageFolderPath.Append(path)
                    ImageFolderPath.Append(vehicleId.ToString())
                Else
                    path = VehicleImageFolderPath
                    With ImageFolderPath
                        .Append(path)
                        .Append("\")
                        .Append(createDt.ToString("yyyyMM"))
                        .Append("\")
                        .Append(vehicleId.ToString)
                    End With
                End If
            End If

            ImageCommand.Dispose()
            ImageCommand = Nothing
            vehicleCreateDt = Nothing

            Return ImageFolderPath.ToString()

        End Function
        Protected Function GetVehicleFolderPath(ByVal vehicleId As Integer) As String
            Dim createDt As DateTime
            Dim vehicleCommand As System.Data.SqlClient.SqlCommand
            Dim vehicleFolderPath As System.Text.StringBuilder
            Dim vehicleCreateDt As Object


            vehicleCommand = New System.Data.SqlClient.SqlCommand
            vehicleFolderPath = New System.Text.StringBuilder

            Try
                With vehicleCommand
                    .CommandText = "SELECT CreateDt FROM Vehicle WHERE VehicleId=" + vehicleId.ToString()
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    vehicleCreateDt = .ExecuteScalar()
                End With

            Catch ex As System.Data.SqlClient.SqlException
                My.Application.Log.WriteException(ex)

            Finally
                If vehicleCommand.Connection.State <> ConnectionState.Closed Then vehicleCommand.Connection.Close()
            End Try


            If (vehicleCreateDt Is Nothing OrElse vehicleCreateDt Is DBNull.Value) Then
                Throw New System.ApplicationException("Invalid vehicle creation date found.")

            Else
                createDt = CType(vehicleCreateDt, DateTime)
                vehicleFolderPath.Append(VehicleImageFolderPath)
                vehicleFolderPath.Append("\")
                vehicleFolderPath.Append(createDt.ToString("yyyyMM"))
                vehicleFolderPath.Append("\")
                vehicleFolderPath.Append(vehicleId.ToString())
            End If

            vehicleCommand.Dispose()
            vehicleCommand = Nothing
            vehicleCreateDt = Nothing

            Return vehicleFolderPath.ToString()

        End Function
        Private Function GetPathType(ByVal _Type As String) As Integer
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As New Object
            Dim _val As Integer

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "Select codeid from vwCode where codedescrip='" + _Type + "'"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With
                If String.IsNullOrEmpty(CType(obj, String)) = False Then _val = CType(obj, Integer)
            Catch ex As Exception
                Throw New ApplicationException("Unable to get the Path Type Id.", ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return _val
        End Function


        Private Function GetImagePath(ByVal YearMonth As String, ByVal LocationId As Integer, ByVal PathType As Integer) As String
            Dim imgPathCommand As System.Data.SqlClient.SqlCommand
            Dim obj As Object
            Dim Path As System.Text.StringBuilder


            imgPathCommand = New System.Data.SqlClient.SqlCommand
            Path = New System.Text.StringBuilder

            Try
                With imgPathCommand
                    .CommandText = "SELECT path FROM ImagePath WHERE yearmonth=" + YearMonth + " AND LocationId=" + LocationId.ToString + " AND PathTypeid=" + PathType.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With
                If String.IsNullOrEmpty(CType(obj, String)) = True Then Exit Function
                Path.Append(CType(obj, String))
                Path.Append("\")
                Path.Append(YearMonth)
                Path.Append("\")
            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If imgPathCommand.Connection.State <> ConnectionState.Closed Then imgPathCommand.Connection.Close()
            End Try

            Return Path.ToString()
        End Function

      
        Public Sub UpdateAllBlankImageName(ByVal _vehicleid As Integer)


            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim adpt As System.Data.SqlClient.SqlDataAdapter
            Dim ds As New DataSet

            cmd = New System.Data.SqlClient.SqlCommand
            con = New System.Data.SqlClient.SqlConnection

            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()

            cmd.Connection = con

            cmd.CommandType = CommandType.Text

            cmd.CommandText = "Update page Set ImageName = null where ImageName = '' AND VehicleId=" + _vehicleid.ToString

            cmd.ExecuteNonQuery()

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing

        End Sub


        Private Function isPageDtEnable() As Boolean
            Dim ImageCommand As System.Data.SqlClient.SqlCommand
            Dim ImageFolderPath As System.Text.StringBuilder
            Dim isValid As Object


            ImageCommand = New System.Data.SqlClient.SqlCommand
            ImageFolderPath = New System.Text.StringBuilder

            Try
                With ImageCommand
                    .CommandText = "select indPagedt from tradeclass where tradeclassid = (select TradeClassId from Ret where RetId = (select RetId from Vehicle where VehicleId = " + VehicleId.ToString + "))"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    isValid = .ExecuteScalar()
                End With

                If String.IsNullOrEmpty(isValid.ToString) = False Then
                    Return CType(isValid, Boolean)
                Else
                    Return False
                End If
            Catch ex As System.Data.SqlClient.SqlException
                My.Application.Log.WriteException(ex)

            Finally
                If ImageCommand.Connection.State <> ConnectionState.Closed Then ImageCommand.Connection.Close()
            End Try
        End Function

        Private Function GetVehicleStartEndDt() As String
            Dim ImageCommand As System.Data.SqlClient.SqlCommand
            Dim ImageFolderPath As System.Text.StringBuilder
            Dim Val As Object
            Dim rVal As String


            ImageCommand = New System.Data.SqlClient.SqlCommand
            ImageFolderPath = New System.Text.StringBuilder

            Try
                With ImageCommand
                    .CommandText = "select ' Start Date : '+ cast(CONVERT(VARCHAR(8), StartDt, 1) as varchar(15)) +'    End Date : '+ cast(CONVERT(VARCHAR(8), EndDt, 1) as varchar(15))  as VehicleDate from Vehicle where VehicleId = " + VehicleId.ToString + ""
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    Val = .ExecuteScalar()
                End With

                If String.IsNullOrEmpty(Val.ToString) = False Then
                    rVal = CType(Val, String)
                Else
                    rVal = ""
                End If

            Catch ex As System.Data.SqlClient.SqlException
                My.Application.Log.WriteException(ex)

            Finally
                If ImageCommand.Connection.State <> ConnectionState.Closed Then ImageCommand.Connection.Close()
            End Try

            Return rVal
        End Function

#End Region

  End Class

End Namespace

