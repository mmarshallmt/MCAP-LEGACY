Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class ReviewWVNNVehicleForm
    Inherits UI.MDIChildFormBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
      MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReviewWVNNVehicleForm))
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Me.reviewDataGridView = New System.Windows.Forms.DataGridView
            Me.reviewTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
            Me.checkInButton = New System.Windows.Forms.Button
            Me.filterFlowLayoutPanel = New System.Windows.Forms.FlowLayoutPanel
            Me.statusLabel = New System.Windows.Forms.Label
            Me.wrongVersionRadioButton = New System.Windows.Forms.RadioButton
            Me.WrongVerPublicationButton = New System.Windows.Forms.RadioButton
            Me.notrequiredRadioButton = New System.Windows.Forms.RadioButton
            Me.checkinDtLabel = New System.Windows.Forms.Label
            Me.fromLabel = New System.Windows.Forms.Label
            Me.fromTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
            Me.toLabel = New System.Windows.Forms.Label
            Me.toTypeInDatePicker = New MCAP.UI.Controls.TypeInDatePicker
            Me.refreshButton = New System.Windows.Forms.Button
            Me.findFlowLayoutPanel = New System.Windows.Forms.Panel
            Me.vehicleIdTextBox = New System.Windows.Forms.TextBox
            Me.findButton = New System.Windows.Forms.Button
            Me.vehicleIdLabel = New System.Windows.Forms.Label
            Me.closeButton = New System.Windows.Forms.Button
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.reviewDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.reviewTableLayoutPanel.SuspendLayout()
            Me.filterFlowLayoutPanel.SuspendLayout()
            Me.findFlowLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'reviewDataGridView
            '
            Me.reviewDataGridView.AllowUserToAddRows = False
            Me.reviewDataGridView.AllowUserToDeleteRows = False
            Me.reviewDataGridView.AllowUserToOrderColumns = True
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
            Me.reviewDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.reviewDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
            Me.reviewDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.reviewTableLayoutPanel.SetColumnSpan(Me.reviewDataGridView, 8)
            Me.reviewDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.reviewDataGridView.Location = New System.Drawing.Point(3, 73)
            Me.reviewDataGridView.Name = "reviewDataGridView"
            Me.reviewDataGridView.ReadOnly = True
            Me.reviewDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.reviewDataGridView.Size = New System.Drawing.Size(916, 498)
            Me.reviewDataGridView.TabIndex = 2
            '
            'reviewTableLayoutPanel
            '
            Me.reviewTableLayoutPanel.ColumnCount = 8
            Me.reviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.reviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
            Me.reviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
            Me.reviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
            Me.reviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
            Me.reviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
            Me.reviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
            Me.reviewTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.reviewTableLayoutPanel.Controls.Add(Me.reviewDataGridView, 0, 2)
            Me.reviewTableLayoutPanel.Controls.Add(Me.checkInButton, 3, 3)
            Me.reviewTableLayoutPanel.Controls.Add(Me.filterFlowLayoutPanel, 0, 0)
            Me.reviewTableLayoutPanel.Controls.Add(Me.findFlowLayoutPanel, 0, 1)
            Me.reviewTableLayoutPanel.Controls.Add(Me.closeButton, 6, 3)
            Me.reviewTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.reviewTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.reviewTableLayoutPanel.Name = "reviewTableLayoutPanel"
            Me.reviewTableLayoutPanel.RowCount = 4
            Me.reviewTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
            Me.reviewTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
            Me.reviewTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.reviewTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
            Me.reviewTableLayoutPanel.Size = New System.Drawing.Size(922, 603)
            Me.reviewTableLayoutPanel.TabIndex = 0
            '
            'checkInButton
            '
            Me.checkInButton.Location = New System.Drawing.Point(339, 577)
            Me.checkInButton.Name = "checkInButton"
            Me.checkInButton.Size = New System.Drawing.Size(162, 23)
            Me.checkInButton.TabIndex = 3
            Me.checkInButton.Text = "Load in Vehicle &Check In"
            Me.checkInButton.UseVisualStyleBackColor = True
            '
            'filterFlowLayoutPanel
            '
            Me.reviewTableLayoutPanel.SetColumnSpan(Me.filterFlowLayoutPanel, 8)
            Me.filterFlowLayoutPanel.Controls.Add(Me.statusLabel)
            Me.filterFlowLayoutPanel.Controls.Add(Me.wrongVersionRadioButton)
            Me.filterFlowLayoutPanel.Controls.Add(Me.WrongVerPublicationButton)
            Me.filterFlowLayoutPanel.Controls.Add(Me.notrequiredRadioButton)
            Me.filterFlowLayoutPanel.Controls.Add(Me.checkinDtLabel)
            Me.filterFlowLayoutPanel.Controls.Add(Me.fromLabel)
            Me.filterFlowLayoutPanel.Controls.Add(Me.fromTypeInDatePicker)
            Me.filterFlowLayoutPanel.Controls.Add(Me.toLabel)
            Me.filterFlowLayoutPanel.Controls.Add(Me.toTypeInDatePicker)
            Me.filterFlowLayoutPanel.Controls.Add(Me.refreshButton)
            Me.filterFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.filterFlowLayoutPanel.Location = New System.Drawing.Point(3, 3)
            Me.filterFlowLayoutPanel.Name = "filterFlowLayoutPanel"
            Me.filterFlowLayoutPanel.Size = New System.Drawing.Size(916, 29)
            Me.filterFlowLayoutPanel.TabIndex = 0
            '
            'statusLabel
            '
            Me.statusLabel.AutoSize = True
            Me.statusLabel.Location = New System.Drawing.Point(3, 7)
            Me.statusLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
            Me.statusLabel.Name = "statusLabel"
            Me.statusLabel.Size = New System.Drawing.Size(40, 13)
            Me.statusLabel.TabIndex = 0
            Me.statusLabel.Text = "Status:"
            '
            'wrongVersionRadioButton
            '
            Me.wrongVersionRadioButton.AutoSize = True
            Me.wrongVersionRadioButton.Checked = True
            Me.wrongVersionRadioButton.Location = New System.Drawing.Point(49, 5)
            Me.wrongVersionRadioButton.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
            Me.wrongVersionRadioButton.Name = "wrongVersionRadioButton"
            Me.wrongVersionRadioButton.Size = New System.Drawing.Size(139, 17)
            Me.wrongVersionRadioButton.TabIndex = 1
            Me.wrongVersionRadioButton.TabStop = True
            Me.wrongVersionRadioButton.Text = "&Wrong Version - Circular"
            Me.wrongVersionRadioButton.UseVisualStyleBackColor = True
            '
            'WrongVerPublicationButton
            '
            Me.WrongVerPublicationButton.AutoSize = True
            Me.WrongVerPublicationButton.Location = New System.Drawing.Point(194, 3)
            Me.WrongVerPublicationButton.Name = "WrongVerPublicationButton"
            Me.WrongVerPublicationButton.Size = New System.Drawing.Size(156, 17)
            Me.WrongVerPublicationButton.TabIndex = 9
            Me.WrongVerPublicationButton.TabStop = True
            Me.WrongVerPublicationButton.Text = "Wrong Version - Publication"
            Me.WrongVerPublicationButton.UseVisualStyleBackColor = True
            '
            'notrequiredRadioButton
            '
            Me.notrequiredRadioButton.AutoSize = True
            Me.notrequiredRadioButton.Location = New System.Drawing.Point(356, 5)
            Me.notrequiredRadioButton.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
            Me.notrequiredRadioButton.Name = "notrequiredRadioButton"
            Me.notrequiredRadioButton.Size = New System.Drawing.Size(157, 17)
            Me.notrequiredRadioButton.TabIndex = 2
            Me.notrequiredRadioButton.Text = "&Not Required (Not Tracked)"
            Me.notrequiredRadioButton.UseVisualStyleBackColor = True
            '
            'checkinDtLabel
            '
            Me.checkinDtLabel.AutoSize = True
            Me.checkinDtLabel.Location = New System.Drawing.Point(519, 7)
            Me.checkinDtLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
            Me.checkinDtLabel.Name = "checkinDtLabel"
            Me.checkinDtLabel.Size = New System.Drawing.Size(78, 13)
            Me.checkinDtLabel.TabIndex = 3
            Me.checkinDtLabel.Text = "Check-in Date:"
            '
            'fromLabel
            '
            Me.fromLabel.AutoSize = True
            Me.fromLabel.Location = New System.Drawing.Point(603, 7)
            Me.fromLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
            Me.fromLabel.Name = "fromLabel"
            Me.fromLabel.Size = New System.Drawing.Size(33, 13)
            Me.fromLabel.TabIndex = 4
            Me.fromLabel.Text = "&From:"
            '
            'fromTypeInDatePicker
            '
            Me.fromTypeInDatePicker.Location = New System.Drawing.Point(642, 3)
            Me.fromTypeInDatePicker.Name = "fromTypeInDatePicker"
            Me.fromTypeInDatePicker.Size = New System.Drawing.Size(72, 20)
            Me.fromTypeInDatePicker.TabIndex = 5
            Me.fromTypeInDatePicker.Value = Nothing
            '
            'toLabel
            '
            Me.toLabel.AutoSize = True
            Me.toLabel.Location = New System.Drawing.Point(720, 7)
            Me.toLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
            Me.toLabel.Name = "toLabel"
            Me.toLabel.Size = New System.Drawing.Size(23, 13)
            Me.toLabel.TabIndex = 6
            Me.toLabel.Text = "&To:"
            '
            'toTypeInDatePicker
            '
            Me.toTypeInDatePicker.Location = New System.Drawing.Point(749, 3)
            Me.toTypeInDatePicker.Name = "toTypeInDatePicker"
            Me.toTypeInDatePicker.Size = New System.Drawing.Size(72, 20)
            Me.toTypeInDatePicker.TabIndex = 7
            Me.toTypeInDatePicker.Value = Nothing
            '
            'refreshButton
            '
            Me.refreshButton.Location = New System.Drawing.Point(827, 3)
            Me.refreshButton.Name = "refreshButton"
            Me.refreshButton.Size = New System.Drawing.Size(75, 23)
            Me.refreshButton.TabIndex = 8
            Me.refreshButton.Text = "&Refresh"
            Me.refreshButton.UseVisualStyleBackColor = True
            '
            'findFlowLayoutPanel
            '
            Me.reviewTableLayoutPanel.SetColumnSpan(Me.findFlowLayoutPanel, 8)
            Me.findFlowLayoutPanel.Controls.Add(Me.vehicleIdTextBox)
            Me.findFlowLayoutPanel.Controls.Add(Me.findButton)
            Me.findFlowLayoutPanel.Controls.Add(Me.vehicleIdLabel)
            Me.findFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.findFlowLayoutPanel.Location = New System.Drawing.Point(3, 38)
            Me.findFlowLayoutPanel.Name = "findFlowLayoutPanel"
            Me.findFlowLayoutPanel.Size = New System.Drawing.Size(916, 29)
            Me.findFlowLayoutPanel.TabIndex = 1
            '
            'vehicleIdTextBox
            '
            Me.vehicleIdTextBox.Location = New System.Drawing.Point(72, 4)
            Me.vehicleIdTextBox.Name = "vehicleIdTextBox"
            Me.vehicleIdTextBox.Size = New System.Drawing.Size(100, 20)
            Me.vehicleIdTextBox.TabIndex = 1
            '
            'findButton
            '
            Me.findButton.Location = New System.Drawing.Point(178, 2)
            Me.findButton.Name = "findButton"
            Me.findButton.Size = New System.Drawing.Size(75, 23)
            Me.findButton.TabIndex = 2
            Me.findButton.Text = "F&ind"
            Me.findButton.UseVisualStyleBackColor = True
            '
            'vehicleIdLabel
            '
            Me.vehicleIdLabel.AutoSize = True
            Me.vehicleIdLabel.Location = New System.Drawing.Point(9, 7)
            Me.vehicleIdLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
            Me.vehicleIdLabel.Name = "vehicleIdLabel"
            Me.vehicleIdLabel.Size = New System.Drawing.Size(57, 13)
            Me.vehicleIdLabel.TabIndex = 0
            Me.vehicleIdLabel.Text = "&Vehicle Id:"
            '
            'closeButton
            '
            Me.closeButton.Location = New System.Drawing.Point(731, 577)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(75, 23)
            Me.closeButton.TabIndex = 4
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'ReviewWVNNVehicleForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(922, 603)
            Me.Controls.Add(Me.reviewTableLayoutPanel)
            Me.Name = "ReviewWVNNVehicleForm"
            Me.StatusMessage = ""
            Me.Text = "Vehicles Marked as Wrong Version/Not Required"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.reviewDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.reviewTableLayoutPanel.ResumeLayout(False)
            Me.filterFlowLayoutPanel.ResumeLayout(False)
            Me.filterFlowLayoutPanel.PerformLayout()
            Me.findFlowLayoutPanel.ResumeLayout(False)
            Me.findFlowLayoutPanel.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents reviewDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents reviewTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents checkInButton As System.Windows.Forms.Button
        Friend WithEvents closeButton As System.Windows.Forms.Button
        Friend WithEvents refreshButton As System.Windows.Forms.Button
        Friend WithEvents statusLabel As System.Windows.Forms.Label
        Friend WithEvents wrongVersionRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents notrequiredRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents fromLabel As System.Windows.Forms.Label
        Friend WithEvents fromTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents toLabel As System.Windows.Forms.Label
        Friend WithEvents toTypeInDatePicker As MCAP.UI.Controls.TypeInDatePicker
        Friend WithEvents checkinDtLabel As System.Windows.Forms.Label
        Friend WithEvents vehicleIdLabel As System.Windows.Forms.Label
        Friend WithEvents findButton As System.Windows.Forms.Button
        Friend WithEvents filterFlowLayoutPanel As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents findFlowLayoutPanel As System.Windows.Forms.Panel
        Friend WithEvents vehicleIdTextBox As System.Windows.Forms.TextBox
        Friend WithEvents WrongVerPublicationButton As System.Windows.Forms.RadioButton

  End Class

End Namespace