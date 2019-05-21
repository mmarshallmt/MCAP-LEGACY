Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SIMRLogForm

        Inherits UI.MDIChildFormBase

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SIMRLogForm))
            Me.bgHeader = New System.Windows.Forms.Panel()
            Me.Label26 = New System.Windows.Forms.Label()
            Me.reviewDataGridView = New System.Windows.Forms.DataGridView()
            Me.mktidTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.VehicleId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.RetIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.publicationIdTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.endDateLabel = New System.Windows.Forms.Label()
            Me.startDateLabel = New System.Windows.Forms.Label()
            Me.resetButton = New System.Windows.Forms.Button()
            Me.searchButton = New System.Windows.Forms.Button()
            Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.enddateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.startdateTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.closeButton = New System.Windows.Forms.Button()
            Me.SenderComboBox = New System.Windows.Forms.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.marketComboBox = New System.Windows.Forms.ComboBox()
            Me.mediaLabel = New System.Windows.Forms.Label()
            Me.retailerComboBox = New System.Windows.Forms.ComboBox()
            Me.retailerLabel = New System.Windows.Forms.Label()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.bgHeader.SuspendLayout()
            CType(Me.reviewDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
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
            Me.bgHeader.Location = New System.Drawing.Point(1, 1)
            Me.bgHeader.Name = "bgHeader"
            Me.bgHeader.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.bgHeader.Size = New System.Drawing.Size(923, 42)
            Me.bgHeader.TabIndex = 116
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
            Me.Label26.Size = New System.Drawing.Size(166, 23)
            Me.Label26.TabIndex = 36
            Me.Label26.Text = "Simr Log Report"
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
            Me.reviewDataGridView.Location = New System.Drawing.Point(1, 220)
            Me.reviewDataGridView.MultiSelect = False
            Me.reviewDataGridView.Name = "reviewDataGridView"
            Me.reviewDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.reviewDataGridView.Size = New System.Drawing.Size(921, 330)
            Me.reviewDataGridView.TabIndex = 117
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
            'endDateLabel
            '
            Me.endDateLabel.AutoSize = True
            Me.endDateLabel.Location = New System.Drawing.Point(174, 65)
            Me.endDateLabel.Name = "endDateLabel"
            Me.endDateLabel.Size = New System.Drawing.Size(46, 13)
            Me.endDateLabel.TabIndex = 120
            Me.endDateLabel.Text = "To Date"
            '
            'startDateLabel
            '
            Me.startDateLabel.AutoSize = True
            Me.startDateLabel.Location = New System.Drawing.Point(3, 65)
            Me.startDateLabel.Name = "startDateLabel"
            Me.startDateLabel.Size = New System.Drawing.Size(56, 13)
            Me.startDateLabel.TabIndex = 118
            Me.startDateLabel.Text = "From Date"
            '
            'resetButton
            '
            Me.resetButton.Location = New System.Drawing.Point(167, 174)
            Me.resetButton.Name = "resetButton"
            Me.resetButton.Size = New System.Drawing.Size(80, 26)
            Me.resetButton.TabIndex = 123
            Me.resetButton.Text = "R&eset"
            Me.resetButton.UseVisualStyleBackColor = True
            '
            'searchButton
            '
            Me.searchButton.Location = New System.Drawing.Point(83, 174)
            Me.searchButton.Name = "searchButton"
            Me.searchButton.Size = New System.Drawing.Size(80, 26)
            Me.searchButton.TabIndex = 122
            Me.searchButton.Text = "Searc&h"
            Me.searchButton.UseVisualStyleBackColor = True
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
            Me.DataGridViewTextBoxColumn2.DataPropertyName = "Vehicleid"
            Me.DataGridViewTextBoxColumn2.HeaderText = "VehicleId"
            Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
            Me.DataGridViewTextBoxColumn2.Width = 76
            '
            'DataGridViewTextBoxColumn3
            '
            Me.DataGridViewTextBoxColumn3.DataPropertyName = "retid"
            Me.DataGridViewTextBoxColumn3.HeaderText = "RetId"
            Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
            Me.DataGridViewTextBoxColumn3.ReadOnly = True
            Me.DataGridViewTextBoxColumn3.Visible = False
            Me.DataGridViewTextBoxColumn3.Width = 58
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
            Me.enddateTypeInDatePicker.Location = New System.Drawing.Point(226, 60)
            Me.enddateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.enddateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.enddateTypeInDatePicker.Name = "enddateTypeInDatePicker"
            Me.enddateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.enddateTypeInDatePicker.TabIndex = 121
            Me.enddateTypeInDatePicker.Value = Nothing
            '
            'startdateTypeInDatePicker
            '
            Me.startdateTypeInDatePicker.Location = New System.Drawing.Point(61, 60)
            Me.startdateTypeInDatePicker.MaximumSize = New System.Drawing.Size(72, 22)
            Me.startdateTypeInDatePicker.MinimumSize = New System.Drawing.Size(72, 22)
            Me.startdateTypeInDatePicker.Name = "startdateTypeInDatePicker"
            Me.startdateTypeInDatePicker.Size = New System.Drawing.Size(72, 22)
            Me.startdateTypeInDatePicker.TabIndex = 119
            Me.startdateTypeInDatePicker.Value = Nothing
            '
            'Panel2
            '
            Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Panel2.Controls.Add(Me.closeButton)
            Me.Panel2.Location = New System.Drawing.Point(1, 556)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(923, 52)
            Me.Panel2.TabIndex = 127
            '
            'closeButton
            '
            Me.closeButton.Location = New System.Drawing.Point(820, 20)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(75, 23)
            Me.closeButton.TabIndex = 8
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'SenderComboBox
            '
            Me.SenderComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.SenderComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.SenderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.SenderComboBox.FormattingEnabled = True
            Me.SenderComboBox.Location = New System.Drawing.Point(61, 148)
            Me.SenderComboBox.Name = "SenderComboBox"
            Me.SenderComboBox.Size = New System.Drawing.Size(255, 21)
            Me.SenderComboBox.TabIndex = 133
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(18, 156)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(41, 13)
            Me.Label2.TabIndex = 132
            Me.Label2.Text = "&Sender"
            '
            'marketComboBox
            '
            Me.marketComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.marketComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.marketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.marketComboBox.FormattingEnabled = True
            Me.marketComboBox.Location = New System.Drawing.Point(61, 91)
            Me.marketComboBox.Name = "marketComboBox"
            Me.marketComboBox.Size = New System.Drawing.Size(255, 21)
            Me.marketComboBox.TabIndex = 129
            '
            'mediaLabel
            '
            Me.mediaLabel.AutoSize = True
            Me.mediaLabel.Location = New System.Drawing.Point(16, 99)
            Me.mediaLabel.Name = "mediaLabel"
            Me.mediaLabel.Size = New System.Drawing.Size(43, 13)
            Me.mediaLabel.TabIndex = 128
            Me.mediaLabel.Text = "Market "
            '
            'retailerComboBox
            '
            Me.retailerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.retailerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.retailerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.retailerComboBox.FormattingEnabled = True
            Me.retailerComboBox.Location = New System.Drawing.Point(61, 121)
            Me.retailerComboBox.Name = "retailerComboBox"
            Me.retailerComboBox.Size = New System.Drawing.Size(255, 21)
            Me.retailerComboBox.TabIndex = 131
            '
            'retailerLabel
            '
            Me.retailerLabel.AutoSize = True
            Me.retailerLabel.Location = New System.Drawing.Point(16, 129)
            Me.retailerLabel.Name = "retailerLabel"
            Me.retailerLabel.Size = New System.Drawing.Size(43, 13)
            Me.retailerLabel.TabIndex = 130
            Me.retailerLabel.Text = "&Retailer"
            '
            'SIMRLogForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(924, 620)
            Me.Controls.Add(Me.SenderComboBox)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.marketComboBox)
            Me.Controls.Add(Me.mediaLabel)
            Me.Controls.Add(Me.retailerComboBox)
            Me.Controls.Add(Me.retailerLabel)
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.resetButton)
            Me.Controls.Add(Me.searchButton)
            Me.Controls.Add(Me.enddateTypeInDatePicker)
            Me.Controls.Add(Me.startdateTypeInDatePicker)
            Me.Controls.Add(Me.endDateLabel)
            Me.Controls.Add(Me.startDateLabel)
            Me.Controls.Add(Me.reviewDataGridView)
            Me.Controls.Add(Me.bgHeader)
            Me.Name = "SIMRLogForm"
            Me.StatusMessage = ""
            Me.Text = "SIMR Log Form"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.bgHeader.ResumeLayout(False)
            Me.bgHeader.PerformLayout()
            CType(Me.reviewDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Public WithEvents bgHeader As System.Windows.Forms.Panel
        Public WithEvents Label26 As System.Windows.Forms.Label
        Protected WithEvents reviewDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents mktidTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents VehicleId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents RetIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents publicationIdTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents enddateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents startdateTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents endDateLabel As System.Windows.Forms.Label
        Friend WithEvents startDateLabel As System.Windows.Forms.Label
        Friend WithEvents resetButton As System.Windows.Forms.Button
        Friend WithEvents searchButton As System.Windows.Forms.Button
        Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents closeButton As System.Windows.Forms.Button
        Friend WithEvents SenderComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents marketComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents mediaLabel As System.Windows.Forms.Label
        Friend WithEvents retailerComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents retailerLabel As System.Windows.Forms.Label
    End Class

End Namespace