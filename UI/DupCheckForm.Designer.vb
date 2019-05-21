Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DupCheckForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DupCheckForm))
            Me.descriptionLabel = New System.Windows.Forms.Label()
            Me.dupCheckDataGridView = New System.Windows.Forms.DataGridView()
            Me.buttonsPanel = New System.Windows.Forms.Panel()
            Me.dateWindowLabel = New System.Windows.Forms.Label()
            Me.printButton = New System.Windows.Forms.Button()
            Me.duplicateButton = New System.Windows.Forms.Button()
            Me.reviewButton = New System.Windows.Forms.Button()
            Me.overrideButton = New System.Windows.Forms.Button()
            Me.refreshButton = New System.Windows.Forms.Button()
            Me.dateRangeNumericUpDown = New System.Windows.Forms.NumericUpDown()
            Me.dupCheckTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
            Me.dupcheckConditionLabel = New System.Windows.Forms.Label()
            Me.thumbnailPanel = New System.Windows.Forms.Panel()
            Me.imageNotAvailableLabel = New System.Windows.Forms.Label()
            Me.dgThumbnails = New System.Windows.Forms.DataGridView()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dupCheckDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.buttonsPanel.SuspendLayout()
            CType(Me.dateRangeNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.dupCheckTableLayoutPanel.SuspendLayout()
            Me.thumbnailPanel.SuspendLayout()
            CType(Me.dgThumbnails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'descriptionLabel
            '
            Me.descriptionLabel.AutoSize = True
            Me.descriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.descriptionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.descriptionLabel.Location = New System.Drawing.Point(3, 0)
            Me.descriptionLabel.Name = "descriptionLabel"
            Me.descriptionLabel.Size = New System.Drawing.Size(870, 16)
            Me.descriptionLabel.TabIndex = 0
            Me.descriptionLabel.Text = "You have entered a possible duplicate.  Please review these previously entered Ve" & _
        "hicles."
            '
            'dupCheckDataGridView
            '
            Me.dupCheckDataGridView.AllowUserToAddRows = False
            Me.dupCheckDataGridView.AllowUserToDeleteRows = False
            Me.dupCheckDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dupCheckDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dupCheckDataGridView.Location = New System.Drawing.Point(3, 32)
            Me.dupCheckDataGridView.Name = "dupCheckDataGridView"
            Me.dupCheckDataGridView.ReadOnly = True
            Me.dupCheckDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dupCheckDataGridView.Size = New System.Drawing.Size(870, 240)
            Me.dupCheckDataGridView.TabIndex = 1
            '
            'buttonsPanel
            '
            Me.buttonsPanel.Controls.Add(Me.dateWindowLabel)
            Me.buttonsPanel.Controls.Add(Me.printButton)
            Me.buttonsPanel.Controls.Add(Me.duplicateButton)
            Me.buttonsPanel.Controls.Add(Me.reviewButton)
            Me.buttonsPanel.Controls.Add(Me.overrideButton)
            Me.buttonsPanel.Controls.Add(Me.refreshButton)
            Me.buttonsPanel.Controls.Add(Me.dateRangeNumericUpDown)
            Me.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.buttonsPanel.Location = New System.Drawing.Point(3, 278)
            Me.buttonsPanel.Name = "buttonsPanel"
            Me.buttonsPanel.Size = New System.Drawing.Size(870, 28)
            Me.buttonsPanel.TabIndex = 2
            '
            'dateWindowLabel
            '
            Me.dateWindowLabel.AutoSize = True
            Me.dateWindowLabel.Location = New System.Drawing.Point(9, 7)
            Me.dateWindowLabel.Name = "dateWindowLabel"
            Me.dateWindowLabel.Size = New System.Drawing.Size(81, 13)
            Me.dateWindowLabel.TabIndex = 7
            Me.dateWindowLabel.Text = "Number of days"
            '
            'printButton
            '
            Me.printButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.printButton.Location = New System.Drawing.Point(792, 3)
            Me.printButton.Name = "printButton"
            Me.printButton.Size = New System.Drawing.Size(75, 23)
            Me.printButton.TabIndex = 6
            Me.printButton.Text = "&Print"
            Me.printButton.UseVisualStyleBackColor = True
            '
            'duplicateButton
            '
            Me.duplicateButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.duplicateButton.Location = New System.Drawing.Point(601, 3)
            Me.duplicateButton.Name = "duplicateButton"
            Me.duplicateButton.Size = New System.Drawing.Size(77, 23)
            Me.duplicateButton.TabIndex = 4
            Me.duplicateButton.Text = "&Duplicate"
            Me.duplicateButton.UseVisualStyleBackColor = True
            '
            'reviewButton
            '
            Me.reviewButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.reviewButton.Location = New System.Drawing.Point(520, 3)
            Me.reviewButton.Name = "reviewButton"
            Me.reviewButton.Size = New System.Drawing.Size(75, 23)
            Me.reviewButton.TabIndex = 3
            Me.reviewButton.Text = "R&eview"
            Me.reviewButton.UseVisualStyleBackColor = True
            '
            'overrideButton
            '
            Me.overrideButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.overrideButton.Location = New System.Drawing.Point(364, 3)
            Me.overrideButton.Name = "overrideButton"
            Me.overrideButton.Size = New System.Drawing.Size(150, 23)
            Me.overrideButton.TabIndex = 2
            Me.overrideButton.Text = "&Override, Not a Duplicate"
            Me.overrideButton.UseVisualStyleBackColor = True
            '
            'refreshButton
            '
            Me.refreshButton.Location = New System.Drawing.Point(148, 3)
            Me.refreshButton.Name = "refreshButton"
            Me.refreshButton.Size = New System.Drawing.Size(75, 23)
            Me.refreshButton.TabIndex = 1
            Me.refreshButton.Text = "&Refresh"
            Me.refreshButton.UseVisualStyleBackColor = True
            '
            'dateRangeNumericUpDown
            '
            Me.dateRangeNumericUpDown.Location = New System.Drawing.Point(96, 3)
            Me.dateRangeNumericUpDown.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
            Me.dateRangeNumericUpDown.Minimum = New Decimal(New Integer() {3, 0, 0, 0})
            Me.dateRangeNumericUpDown.Name = "dateRangeNumericUpDown"
            Me.dateRangeNumericUpDown.Size = New System.Drawing.Size(46, 20)
            Me.dateRangeNumericUpDown.TabIndex = 0
            Me.dateRangeNumericUpDown.Value = New Decimal(New Integer() {3, 0, 0, 0})
            '
            'dupCheckTableLayoutPanel
            '
            Me.dupCheckTableLayoutPanel.ColumnCount = 1
            Me.dupCheckTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.dupCheckTableLayoutPanel.Controls.Add(Me.buttonsPanel, 0, 3)
            Me.dupCheckTableLayoutPanel.Controls.Add(Me.dupCheckDataGridView, 0, 2)
            Me.dupCheckTableLayoutPanel.Controls.Add(Me.descriptionLabel, 0, 0)
            Me.dupCheckTableLayoutPanel.Controls.Add(Me.dupcheckConditionLabel, 0, 1)
            Me.dupCheckTableLayoutPanel.Controls.Add(Me.thumbnailPanel, 0, 4)
            Me.dupCheckTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dupCheckTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.dupCheckTableLayoutPanel.Name = "dupCheckTableLayoutPanel"
            Me.dupCheckTableLayoutPanel.RowCount = 5
            Me.dupCheckTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.dupCheckTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.dupCheckTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.dupCheckTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.dupCheckTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.dupCheckTableLayoutPanel.Size = New System.Drawing.Size(876, 556)
            Me.dupCheckTableLayoutPanel.TabIndex = 5
            '
            'dupcheckConditionLabel
            '
            Me.dupcheckConditionLabel.AutoSize = True
            Me.dupcheckConditionLabel.Location = New System.Drawing.Point(3, 16)
            Me.dupcheckConditionLabel.Name = "dupcheckConditionLabel"
            Me.dupcheckConditionLabel.Size = New System.Drawing.Size(183, 13)
            Me.dupcheckConditionLabel.TabIndex = 4
            Me.dupcheckConditionLabel.Text = "<Possible duplicate check condition>"
            '
            'thumbnailPanel
            '
            Me.thumbnailPanel.Controls.Add(Me.imageNotAvailableLabel)
            Me.thumbnailPanel.Controls.Add(Me.dgThumbnails)
            Me.thumbnailPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.thumbnailPanel.Location = New System.Drawing.Point(3, 312)
            Me.thumbnailPanel.Name = "thumbnailPanel"
            Me.thumbnailPanel.Size = New System.Drawing.Size(870, 241)
            Me.thumbnailPanel.TabIndex = 5
            '
            'imageNotAvailableLabel
            '
            Me.imageNotAvailableLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.imageNotAvailableLabel.BackColor = System.Drawing.Color.White
            Me.imageNotAvailableLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.imageNotAvailableLabel.Location = New System.Drawing.Point(356, 95)
            Me.imageNotAvailableLabel.Name = "imageNotAvailableLabel"
            Me.imageNotAvailableLabel.Size = New System.Drawing.Size(159, 30)
            Me.imageNotAvailableLabel.TabIndex = 0
            Me.imageNotAvailableLabel.Text = "Image Not Available"
            Me.imageNotAvailableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.imageNotAvailableLabel.Visible = False
            '
            'dgThumbnails
            '
            Me.dgThumbnails.BackgroundColor = System.Drawing.Color.White
            Me.dgThumbnails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgThumbnails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgThumbnails.Location = New System.Drawing.Point(0, 0)
            Me.dgThumbnails.Name = "dgThumbnails"
            Me.dgThumbnails.Size = New System.Drawing.Size(870, 241)
            Me.dgThumbnails.TabIndex = 2
            '
            'DupCheckForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(876, 556)
            Me.Controls.Add(Me.dupCheckTableLayoutPanel)
            Me.Name = "DupCheckForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.StatusMessage = ""
            Me.Text = "Possible Duplicate Vehicle Check"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dupCheckDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.buttonsPanel.ResumeLayout(False)
            Me.buttonsPanel.PerformLayout()
            CType(Me.dateRangeNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
            Me.dupCheckTableLayoutPanel.ResumeLayout(False)
            Me.dupCheckTableLayoutPanel.PerformLayout()
            Me.thumbnailPanel.ResumeLayout(False)
            CType(Me.dgThumbnails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents descriptionLabel As System.Windows.Forms.Label
        Friend WithEvents dupCheckDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents buttonsPanel As System.Windows.Forms.Panel
        Friend WithEvents printButton As System.Windows.Forms.Button
        Friend WithEvents duplicateButton As System.Windows.Forms.Button
        Friend WithEvents reviewButton As System.Windows.Forms.Button
        Friend WithEvents overrideButton As System.Windows.Forms.Button
        Friend WithEvents refreshButton As System.Windows.Forms.Button
        Friend WithEvents dateRangeNumericUpDown As System.Windows.Forms.NumericUpDown
        Friend WithEvents dateWindowLabel As System.Windows.Forms.Label
        Friend WithEvents dupCheckTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents dupcheckConditionLabel As System.Windows.Forms.Label
        Friend WithEvents thumbnailPanel As System.Windows.Forms.Panel
        '' Friend WithEvents dupCheckThumbnailBrowser As AxLEADImgListLib.AxLEADImgList  ''\\ Comment by Denver : 2
        Friend WithEvents imageNotAvailableLabel As System.Windows.Forms.Label
        Friend WithEvents dgThumbnails As System.Windows.Forms.DataGridView

    End Class

End Namespace