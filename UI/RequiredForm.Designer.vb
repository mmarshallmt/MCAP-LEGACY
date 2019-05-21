Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class RequiredForm
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.marketComboBox = New System.Windows.Forms.ComboBox()
            Me.mediaLabel = New System.Windows.Forms.Label()
            Me.searchButton = New System.Windows.Forms.Button()
            Me.retailerComboBox = New System.Windows.Forms.ComboBox()
            Me.retailerLabel = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.SearchLabel = New System.Windows.Forms.Label()
            Me.reviewDataGridView = New System.Windows.Forms.DataGridView()
            Me.closeButton = New System.Windows.Forms.Button()
            Me.vehicletoIndexButton = New System.Windows.Forms.Button()
            Me.endDateLabel = New System.Windows.Forms.Label()
            Me.startDateLabel = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.bgHeader = New System.Windows.Forms.Panel()
            Me.Label26 = New System.Windows.Forms.Label()
            Me.EnvelopIdTextBox = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.resetButton = New System.Windows.Forms.Button()
            Me.StatusComboBox = New System.Windows.Forms.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.CmbLabel = New System.Windows.Forms.ComboBox()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.enddateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.startdateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.mktidTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.VehicleId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.RetIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.publicationIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.Panel1.SuspendLayout()
            CType(Me.reviewDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel3.SuspendLayout()
            Me.bgHeader.SuspendLayout()
            Me.SuspendLayout()
            '
            'marketComboBox
            '
            Me.marketComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.marketComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.marketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.marketComboBox.FormattingEnabled = True
            Me.marketComboBox.Location = New System.Drawing.Point(83, 126)
            Me.marketComboBox.Name = "marketComboBox"
            Me.marketComboBox.Size = New System.Drawing.Size(255, 21)
            Me.marketComboBox.TabIndex = 21
            '
            'mediaLabel
            '
            Me.mediaLabel.AutoSize = True
            Me.mediaLabel.Location = New System.Drawing.Point(38, 134)
            Me.mediaLabel.Name = "mediaLabel"
            Me.mediaLabel.Size = New System.Drawing.Size(43, 13)
            Me.mediaLabel.TabIndex = 20
            Me.mediaLabel.Text = "Market "
            '
            'searchButton
            '
            Me.searchButton.Location = New System.Drawing.Point(83, 210)
            Me.searchButton.Name = "searchButton"
            Me.searchButton.Size = New System.Drawing.Size(80, 26)
            Me.searchButton.TabIndex = 29
            Me.searchButton.Text = "Searc&h"
            Me.searchButton.UseVisualStyleBackColor = True
            '
            'retailerComboBox
            '
            Me.retailerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.retailerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.retailerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.retailerComboBox.FormattingEnabled = True
            Me.retailerComboBox.Location = New System.Drawing.Point(83, 156)
            Me.retailerComboBox.Name = "retailerComboBox"
            Me.retailerComboBox.Size = New System.Drawing.Size(255, 21)
            Me.retailerComboBox.TabIndex = 25
            '
            'retailerLabel
            '
            Me.retailerLabel.AutoSize = True
            Me.retailerLabel.Location = New System.Drawing.Point(38, 164)
            Me.retailerLabel.Name = "retailerLabel"
            Me.retailerLabel.Size = New System.Drawing.Size(43, 13)
            Me.retailerLabel.TabIndex = 24
            Me.retailerLabel.Text = "&Retailer"
            '
            'Panel1
            '
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.SearchLabel)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 687)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(953, 23)
            Me.Panel1.TabIndex = 30
            '
            'SearchLabel
            '
            Me.SearchLabel.AutoSize = True
            Me.SearchLabel.Location = New System.Drawing.Point(5, 5)
            Me.SearchLabel.Name = "SearchLabel"
            Me.SearchLabel.Size = New System.Drawing.Size(33, 13)
            Me.SearchLabel.TabIndex = 14
            Me.SearchLabel.Text = "Done"
            '
            'reviewDataGridView
            '
            Me.reviewDataGridView.AllowUserToAddRows = False
            Me.reviewDataGridView.AllowUserToDeleteRows = False
            Me.reviewDataGridView.AllowUserToOrderColumns = True
            Me.reviewDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.reviewDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.reviewDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
            Me.reviewDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.reviewDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.mktidTextBoxColumn, Me.VehicleId, Me.RetIdTextBoxColumn, Me.publicationIdTextBoxColumn})
            Me.reviewDataGridView.Location = New System.Drawing.Point(20, 261)
            Me.reviewDataGridView.MultiSelect = False
            Me.reviewDataGridView.Name = "reviewDataGridView"
            Me.reviewDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.reviewDataGridView.Size = New System.Drawing.Size(921, 366)
            Me.reviewDataGridView.TabIndex = 31
            '
            'closeButton
            '
            Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.closeButton.Location = New System.Drawing.Point(769, 6)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(137, 23)
            Me.closeButton.TabIndex = 9
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'vehicletoIndexButton
            '
            Me.vehicletoIndexButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.vehicletoIndexButton.Location = New System.Drawing.Point(15, 6)
            Me.vehicletoIndexButton.Name = "vehicletoIndexButton"
            Me.vehicletoIndexButton.Size = New System.Drawing.Size(115, 45)
            Me.vehicletoIndexButton.TabIndex = 7
            Me.vehicletoIndexButton.Text = "Push to Index"
            Me.vehicletoIndexButton.UseVisualStyleBackColor = True
            '
            'endDateLabel
            '
            Me.endDateLabel.AutoSize = True
            Me.endDateLabel.Location = New System.Drawing.Point(196, 76)
            Me.endDateLabel.Name = "endDateLabel"
            Me.endDateLabel.Size = New System.Drawing.Size(46, 13)
            Me.endDateLabel.TabIndex = 35
            Me.endDateLabel.Text = "To Date"
            '
            'startDateLabel
            '
            Me.startDateLabel.AutoSize = True
            Me.startDateLabel.Location = New System.Drawing.Point(25, 76)
            Me.startDateLabel.Name = "startDateLabel"
            Me.startDateLabel.Size = New System.Drawing.Size(56, 13)
            Me.startDateLabel.TabIndex = 33
            Me.startDateLabel.Text = "From Date"
            '
            'Panel3
            '
            Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel3.Controls.Add(Me.vehicletoIndexButton)
            Me.Panel3.Controls.Add(Me.closeButton)
            Me.Panel3.Location = New System.Drawing.Point(0, 633)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(953, 54)
            Me.Panel3.TabIndex = 37
            '
            'bgHeader
            '
            Me.bgHeader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.bgHeader.BackColor = System.Drawing.SystemColors.InactiveBorder
            Me.bgHeader.Controls.Add(Me.Label26)
            Me.bgHeader.Cursor = System.Windows.Forms.Cursors.Default
            Me.bgHeader.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.bgHeader.ForeColor = System.Drawing.SystemColors.WindowText
            Me.bgHeader.Location = New System.Drawing.Point(1, -2)
            Me.bgHeader.Name = "bgHeader"
            Me.bgHeader.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.bgHeader.Size = New System.Drawing.Size(952, 49)
            Me.bgHeader.TabIndex = 115
            Me.bgHeader.TabStop = True
            '
            'Label26
            '
            Me.Label26.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label26.AutoSize = True
            Me.Label26.BackColor = System.Drawing.Color.Transparent
            Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
            Me.Label26.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer), CType(CType(146, Byte), Integer))
            Me.Label26.Location = New System.Drawing.Point(347, 11)
            Me.Label26.Name = "Label26"
            Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.Label26.Size = New System.Drawing.Size(222, 23)
            Me.Label26.TabIndex = 36
            Me.Label26.Text = "Backup Sender Report"
            '
            'EnvelopIdTextBox
            '
            Me.EnvelopIdTextBox.Location = New System.Drawing.Point(83, 100)
            Me.EnvelopIdTextBox.Name = "EnvelopIdTextBox"
            Me.EnvelopIdTextBox.Size = New System.Drawing.Size(255, 20)
            Me.EnvelopIdTextBox.TabIndex = 116
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(6, 50)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(97, 13)
            Me.Label1.TabIndex = 118
            Me.Label1.Text = "Ad Date Search"
            '
            'resetButton
            '
            Me.resetButton.Location = New System.Drawing.Point(167, 210)
            Me.resetButton.Name = "resetButton"
            Me.resetButton.Size = New System.Drawing.Size(80, 26)
            Me.resetButton.TabIndex = 119
            Me.resetButton.Text = "R&eset"
            Me.resetButton.UseVisualStyleBackColor = True
            '
            'StatusComboBox
            '
            Me.StatusComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.StatusComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.StatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.StatusComboBox.FormattingEnabled = True
            Me.StatusComboBox.Location = New System.Drawing.Point(83, 183)
            Me.StatusComboBox.Name = "StatusComboBox"
            Me.StatusComboBox.Size = New System.Drawing.Size(255, 21)
            Me.StatusComboBox.TabIndex = 121
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(40, 191)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(37, 13)
            Me.Label2.TabIndex = 120
            Me.Label2.Text = "&Status"
            '
            'CmbLabel
            '
            Me.CmbLabel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.CmbLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CmbLabel.FormattingEnabled = True
            Me.CmbLabel.Items.AddRange(New Object() {"Envelop ID:", "Vehicle ID:"})
            Me.CmbLabel.Location = New System.Drawing.Point(1, 99)
            Me.CmbLabel.Name = "CmbLabel"
            Me.CmbLabel.Size = New System.Drawing.Size(76, 21)
            Me.CmbLabel.TabIndex = 122
            '
            'DataGridViewTextBoxColumn1
            '
            Me.DataGridViewTextBoxColumn1.DataPropertyName = "mktid"
            Me.DataGridViewTextBoxColumn1.HeaderText = "MktId"
            Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
            Me.DataGridViewTextBoxColumn1.ReadOnly = True
            Me.DataGridViewTextBoxColumn1.Visible = False
            Me.DataGridViewTextBoxColumn1.Width = 59
            '
            'DataGridViewTextBoxColumn2
            '
            Me.DataGridViewTextBoxColumn2.DataPropertyName = "publicationid"
            Me.DataGridViewTextBoxColumn2.HeaderText = "PublicationId"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.ReadOnly = True
            Me.DataGridViewTextBoxColumn2.Visible = False
            Me.DataGridViewTextBoxColumn2.Width = 93
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.DataPropertyName = "publicationid"
            Me.DataGridViewTextBoxColumn3.HeaderText = "PublicationId"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.ReadOnly = True
            Me.DataGridViewTextBoxColumn3.Visible = False
            Me.DataGridViewTextBoxColumn3.Width = 93
            '
            'DataGridViewTextBoxColumn4
            '
            Me.DataGridViewTextBoxColumn4.DataPropertyName = "publicationid"
            Me.DataGridViewTextBoxColumn4.HeaderText = "PublicationId"
            Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
            Me.DataGridViewTextBoxColumn4.ReadOnly = True
            Me.DataGridViewTextBoxColumn4.Visible = False
            Me.DataGridViewTextBoxColumn4.Width = 93
            '
            'enddateTypeInDatePicker
            '
            Me.enddateTypeInDatePicker.Location = New System.Drawing.Point(248, 71)
            Me.enddateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.enddateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.enddateTypeInDatePicker.Name = "enddateTypeInDatePicker"
            Me.enddateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.enddateTypeInDatePicker.TabIndex = 36
            Me.enddateTypeInDatePicker.Value = Nothing
            '
            'startdateTypeInDatePicker
            '
            Me.startdateTypeInDatePicker.Location = New System.Drawing.Point(83, 71)
            Me.startdateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.startdateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.startdateTypeInDatePicker.Name = "startdateTypeInDatePicker"
            Me.startdateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.startdateTypeInDatePicker.TabIndex = 34
            Me.startdateTypeInDatePicker.Value = Nothing
            '
            'mktidTextBoxColumn
            '
            Me.mktidTextBoxColumn.DataPropertyName = "mktid"
            Me.mktidTextBoxColumn.HeaderText = "MktId"
            Me.mktidTextBoxColumn.Name = "mktidTextBoxColumn"
            Me.mktidTextBoxColumn.ReadOnly = True
            Me.mktidTextBoxColumn.Visible = False
            Me.mktidTextBoxColumn.Width = 59
            '
            'VehicleId
            '
            Me.VehicleId.DataPropertyName = "Vehicleid"
            Me.VehicleId.HeaderText = "VehicleId"
            Me.VehicleId.Name = "VehicleId"
            Me.VehicleId.Width = 76
            '
            'RetIdTextBoxColumn
            '
            Me.RetIdTextBoxColumn.DataPropertyName = "retid"
            Me.RetIdTextBoxColumn.HeaderText = "RetId"
            Me.RetIdTextBoxColumn.Name = "RetIdTextBoxColumn"
            Me.RetIdTextBoxColumn.ReadOnly = True
            Me.RetIdTextBoxColumn.Visible = False
            Me.RetIdTextBoxColumn.Width = 58
            '
            'publicationIdTextBoxColumn
            '
            Me.publicationIdTextBoxColumn.DataPropertyName = "publicationid"
            Me.publicationIdTextBoxColumn.HeaderText = "PublicationId"
            Me.publicationIdTextBoxColumn.Name = "publicationIdTextBoxColumn"
            Me.publicationIdTextBoxColumn.ReadOnly = True
            Me.publicationIdTextBoxColumn.Visible = False
            Me.publicationIdTextBoxColumn.Width = 93
            '
            'RequiredForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(953, 710)
            Me.Controls.Add(Me.CmbLabel)
            Me.Controls.Add(Me.StatusComboBox)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.resetButton)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.EnvelopIdTextBox)
            Me.Controls.Add(Me.bgHeader)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.enddateTypeInDatePicker)
            Me.Controls.Add(Me.startdateTypeInDatePicker)
            Me.Controls.Add(Me.endDateLabel)
            Me.Controls.Add(Me.startDateLabel)
            Me.Controls.Add(Me.reviewDataGridView)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.marketComboBox)
            Me.Controls.Add(Me.mediaLabel)
            Me.Controls.Add(Me.searchButton)
            Me.Controls.Add(Me.retailerComboBox)
            Me.Controls.Add(Me.retailerLabel)
            Me.Name = "RequiredForm"
            Me.Text = "Backup Sender Report"
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            CType(Me.reviewDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel3.ResumeLayout(False)
            Me.bgHeader.ResumeLayout(False)
            Me.bgHeader.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents marketComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents mediaLabel As System.Windows.Forms.Label
        Friend WithEvents searchButton As System.Windows.Forms.Button
        Friend WithEvents retailerComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents retailerLabel As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents SearchLabel As System.Windows.Forms.Label
        Protected WithEvents reviewDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents closeButton As System.Windows.Forms.Button
        Friend WithEvents vehicletoIndexButton As System.Windows.Forms.Button
        Friend WithEvents enddateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents startdateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents endDateLabel As System.Windows.Forms.Label
        Friend WithEvents startDateLabel As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Public WithEvents bgHeader As System.Windows.Forms.Panel
        Public WithEvents Label26 As System.Windows.Forms.Label
        Friend WithEvents EnvelopIdTextBox As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents resetButton As System.Windows.Forms.Button
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents mktidTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents VehicleId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RetIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents publicationIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents StatusComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents CmbLabel As ComboBox
    End Class
End Namespace