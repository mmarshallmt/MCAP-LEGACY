<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VehicleChildrenCreation
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
        Me.components = New System.ComponentModel.Container
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtVehicleID = New System.Windows.Forms.TextBox
        Me.loadButton = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rtbTDlinkxNo = New System.Windows.Forms.RichTextBox
        Me.txtTDLinksNo = New System.Windows.Forms.TextBox
        Me.btnCreateChildren = New System.Windows.Forms.Button
        Me.lvResult = New System.Windows.Forms.ListView
        Me.createdOnValueLabel = New System.Windows.Forms.Label
        Me.createdOnLabel = New System.Windows.Forms.Label
        Me.indexedOnValueLabel = New System.Windows.Forms.Label
        Me.indexedOnLabel = New System.Windows.Forms.Label
        Me.scannedOnValueLabel = New System.Windows.Forms.Label
        Me.scannedOnLabel = New System.Windows.Forms.Label
        Me.qcedOnValueLabel = New System.Windows.Forms.Label
        Me.StatusReportDataSet = New MCAP.StatusReportDataSet
        Me.qcedOnLabel = New System.Windows.Forms.Label
        Me.StatusReportDataSetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnReset = New System.Windows.Forms.Button
        Me.retailerValueLabel = New System.Windows.Forms.Label
        Me.retailerLabel = New System.Windows.Forms.Label
        Me.marketLabel = New System.Windows.Forms.Label
        Me.marketValueLabel = New System.Windows.Forms.Label
        Me.startDtLabel = New System.Windows.Forms.Label
        Me.startDtValueLabel = New System.Windows.Forms.Label
        Me.ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.copyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.pasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.undoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.redoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.clearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectAllCtrlAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.StatusReportDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatusReportDataSetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtVehicleID)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(272, 47)
        Me.GroupBox1.TabIndex = 44
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Load from VehicleId"
        '
        'txtVehicleID
        '
        Me.txtVehicleID.Location = New System.Drawing.Point(6, 18)
        Me.txtVehicleID.Name = "txtVehicleID"
        Me.txtVehicleID.Size = New System.Drawing.Size(179, 20)
        Me.txtVehicleID.TabIndex = 1
        '
        'loadButton
        '
        Me.loadButton.Location = New System.Drawing.Point(471, 172)
        Me.loadButton.Name = "loadButton"
        Me.loadButton.Size = New System.Drawing.Size(215, 23)
        Me.loadButton.TabIndex = 3
        Me.loadButton.Text = "Loa&d"
        Me.loadButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rtbTDlinkxNo)
        Me.GroupBox2.Controls.Add(Me.txtTDLinksNo)
        Me.GroupBox2.Location = New System.Drawing.Point(1, 54)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(272, 131)
        Me.GroupBox2.TabIndex = 45
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Enter  TDLinkx number"
        '
        'rtbTDlinkxNo
        '
        Me.rtbTDlinkxNo.ContextMenuStrip = Me.ContextMenuStrip
        Me.rtbTDlinkxNo.Location = New System.Drawing.Point(6, 12)
        Me.rtbTDlinkxNo.Name = "rtbTDlinkxNo"
        Me.rtbTDlinkxNo.Size = New System.Drawing.Size(179, 109)
        Me.rtbTDlinkxNo.TabIndex = 2
        Me.rtbTDlinkxNo.Text = ""
        '
        'txtTDLinksNo
        '
        Me.txtTDLinksNo.Location = New System.Drawing.Point(103, 18)
        Me.txtTDLinksNo.Multiline = True
        Me.txtTDLinksNo.Name = "txtTDLinksNo"
        Me.txtTDLinksNo.Size = New System.Drawing.Size(145, 97)
        Me.txtTDLinksNo.TabIndex = 59
        Me.txtTDLinksNo.Visible = False
        '
        'btnCreateChildren
        '
        Me.btnCreateChildren.Enabled = False
        Me.btnCreateChildren.Location = New System.Drawing.Point(471, 395)
        Me.btnCreateChildren.Name = "btnCreateChildren"
        Me.btnCreateChildren.Size = New System.Drawing.Size(215, 23)
        Me.btnCreateChildren.TabIndex = 4
        Me.btnCreateChildren.Text = "Create Children"
        Me.btnCreateChildren.UseVisualStyleBackColor = True
        '
        'lvResult
        '
        Me.lvResult.Location = New System.Drawing.Point(7, 201)
        Me.lvResult.Name = "lvResult"
        Me.lvResult.Size = New System.Drawing.Size(679, 182)
        Me.lvResult.TabIndex = 0
        Me.lvResult.TabStop = False
        Me.lvResult.UseCompatibleStateImageBehavior = False
        '
        'createdOnValueLabel
        '
        Me.createdOnValueLabel.AutoSize = True
        Me.createdOnValueLabel.Location = New System.Drawing.Point(411, 57)
        Me.createdOnValueLabel.Name = "createdOnValueLabel"
        Me.createdOnValueLabel.Size = New System.Drawing.Size(0, 13)
        Me.createdOnValueLabel.TabIndex = 60
        Me.createdOnValueLabel.UseMnemonic = False
        '
        'createdOnLabel
        '
        Me.createdOnLabel.AutoSize = True
        Me.createdOnLabel.Location = New System.Drawing.Point(344, 57)
        Me.createdOnLabel.Name = "createdOnLabel"
        Me.createdOnLabel.Size = New System.Drawing.Size(67, 13)
        Me.createdOnLabel.TabIndex = 59
        Me.createdOnLabel.Text = "Created On :"
        Me.createdOnLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'indexedOnValueLabel
        '
        Me.indexedOnValueLabel.AutoSize = True
        Me.indexedOnValueLabel.Location = New System.Drawing.Point(411, 73)
        Me.indexedOnValueLabel.Name = "indexedOnValueLabel"
        Me.indexedOnValueLabel.Size = New System.Drawing.Size(0, 13)
        Me.indexedOnValueLabel.TabIndex = 62
        Me.indexedOnValueLabel.UseMnemonic = False
        '
        'indexedOnLabel
        '
        Me.indexedOnLabel.AutoSize = True
        Me.indexedOnLabel.Location = New System.Drawing.Point(343, 73)
        Me.indexedOnLabel.Name = "indexedOnLabel"
        Me.indexedOnLabel.Size = New System.Drawing.Size(68, 13)
        Me.indexedOnLabel.TabIndex = 61
        Me.indexedOnLabel.Text = "Indexed On :"
        Me.indexedOnLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'scannedOnValueLabel
        '
        Me.scannedOnValueLabel.AutoSize = True
        Me.scannedOnValueLabel.Location = New System.Drawing.Point(411, 89)
        Me.scannedOnValueLabel.Name = "scannedOnValueLabel"
        Me.scannedOnValueLabel.Size = New System.Drawing.Size(0, 13)
        Me.scannedOnValueLabel.TabIndex = 64
        Me.scannedOnValueLabel.UseMnemonic = False
        '
        'scannedOnLabel
        '
        Me.scannedOnLabel.AutoSize = True
        Me.scannedOnLabel.Location = New System.Drawing.Point(338, 89)
        Me.scannedOnLabel.Name = "scannedOnLabel"
        Me.scannedOnLabel.Size = New System.Drawing.Size(73, 13)
        Me.scannedOnLabel.TabIndex = 63
        Me.scannedOnLabel.Text = "Scanned On :"
        Me.scannedOnLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'qcedOnValueLabel
        '
        Me.qcedOnValueLabel.AutoSize = True
        Me.qcedOnValueLabel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StatusReportDataSet, "vwVehicleStatusReport.QcDt", True))
        Me.qcedOnValueLabel.Location = New System.Drawing.Point(411, 105)
        Me.qcedOnValueLabel.Name = "qcedOnValueLabel"
        Me.qcedOnValueLabel.Size = New System.Drawing.Size(0, 13)
        Me.qcedOnValueLabel.TabIndex = 66
        Me.qcedOnValueLabel.UseMnemonic = False
        '
        'StatusReportDataSet
        '
        Me.StatusReportDataSet.DataSetName = "StatusReportDataSet"
        Me.StatusReportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'qcedOnLabel
        '
        Me.qcedOnLabel.AutoSize = True
        Me.qcedOnLabel.Location = New System.Drawing.Point(354, 105)
        Me.qcedOnLabel.Name = "qcedOnLabel"
        Me.qcedOnLabel.Size = New System.Drawing.Size(57, 13)
        Me.qcedOnLabel.TabIndex = 65
        Me.qcedOnLabel.Text = "QCed On :"
        Me.qcedOnLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'StatusReportDataSetBindingSource
        '
        Me.StatusReportDataSetBindingSource.DataSource = Me.StatusReportDataSet
        Me.StatusReportDataSetBindingSource.Position = 0
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(471, 424)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(215, 23)
        Me.btnReset.TabIndex = 5
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'retailerValueLabel
        '
        Me.retailerValueLabel.AutoSize = True
        Me.retailerValueLabel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StatusReportDataSet, "vwVehicleStatusReport.Retailer", True))
        Me.retailerValueLabel.Location = New System.Drawing.Point(411, 9)
        Me.retailerValueLabel.Name = "retailerValueLabel"
        Me.retailerValueLabel.Size = New System.Drawing.Size(0, 13)
        Me.retailerValueLabel.TabIndex = 72
        Me.retailerValueLabel.UseMnemonic = False
        '
        'retailerLabel
        '
        Me.retailerLabel.AutoSize = True
        Me.retailerLabel.Location = New System.Drawing.Point(362, 9)
        Me.retailerLabel.Name = "retailerLabel"
        Me.retailerLabel.Size = New System.Drawing.Size(49, 13)
        Me.retailerLabel.TabIndex = 71
        Me.retailerLabel.Text = "Retailer :"
        Me.retailerLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'marketLabel
        '
        Me.marketLabel.AutoSize = True
        Me.marketLabel.Location = New System.Drawing.Point(365, 25)
        Me.marketLabel.Name = "marketLabel"
        Me.marketLabel.Size = New System.Drawing.Size(46, 13)
        Me.marketLabel.TabIndex = 73
        Me.marketLabel.Text = "Market :"
        Me.marketLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'marketValueLabel
        '
        Me.marketValueLabel.AutoSize = True
        Me.marketValueLabel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StatusReportDataSet, "vwVehicleStatusReport.Market", True))
        Me.marketValueLabel.Location = New System.Drawing.Point(411, 25)
        Me.marketValueLabel.Name = "marketValueLabel"
        Me.marketValueLabel.Size = New System.Drawing.Size(0, 13)
        Me.marketValueLabel.TabIndex = 74
        Me.marketValueLabel.UseMnemonic = False
        '
        'startDtLabel
        '
        Me.startDtLabel.AutoSize = True
        Me.startDtLabel.Location = New System.Drawing.Point(350, 41)
        Me.startDtLabel.Name = "startDtLabel"
        Me.startDtLabel.Size = New System.Drawing.Size(61, 13)
        Me.startDtLabel.TabIndex = 75
        Me.startDtLabel.Text = "Start Date :"
        Me.startDtLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'startDtValueLabel
        '
        Me.startDtValueLabel.AutoSize = True
        Me.startDtValueLabel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StatusReportDataSet, "vwVehicleStatusReport.StartDt", True))
        Me.startDtValueLabel.Location = New System.Drawing.Point(411, 41)
        Me.startDtValueLabel.Name = "startDtValueLabel"
        Me.startDtValueLabel.Size = New System.Drawing.Size(0, 13)
        Me.startDtValueLabel.TabIndex = 76
        Me.startDtValueLabel.UseMnemonic = False
        '
        'ContextMenuStrip
        '
        Me.ContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cutToolStripMenuItem, Me.copyToolStripMenuItem, Me.pasteToolStripMenuItem, Me.ToolStripMenuItem1, Me.undoToolStripMenuItem, Me.redoToolStripMenuItem, Me.clearToolStripMenuItem, Me.SelectAllCtrlAToolStripMenuItem})
        Me.ContextMenuStrip.Name = "ContextMenuStrip"
        Me.ContextMenuStrip.Size = New System.Drawing.Size(260, 202)
        '
        'cutToolStripMenuItem
        '
        Me.cutToolStripMenuItem.Name = "cutToolStripMenuItem"
        Me.cutToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
        Me.cutToolStripMenuItem.Text = "C&ut                                        Ctrl + X"
        '
        'copyToolStripMenuItem
        '
        Me.copyToolStripMenuItem.Name = "copyToolStripMenuItem"
        Me.copyToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
        Me.copyToolStripMenuItem.Text = "&Copy                                     Ctrl + C"
        '
        'pasteToolStripMenuItem
        '
        Me.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem"
        Me.pasteToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
        Me.pasteToolStripMenuItem.Text = "&Paste                                     Ctrl + V"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Enabled = False
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(259, 22)
        Me.ToolStripMenuItem1.Text = "_____________________________________"
        '
        'undoToolStripMenuItem
        '
        Me.undoToolStripMenuItem.Name = "undoToolStripMenuItem"
        Me.undoToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.undoToolStripMenuItem.Text = "&Undo"
        '
        'redoToolStripMenuItem
        '
        Me.redoToolStripMenuItem.Name = "redoToolStripMenuItem"
        Me.redoToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.redoToolStripMenuItem.Text = "Redo"
        '
        'clearToolStripMenuItem
        '
        Me.clearToolStripMenuItem.Name = "clearToolStripMenuItem"
        Me.clearToolStripMenuItem.Size = New System.Drawing.Size(309, 22)
        Me.clearToolStripMenuItem.Text = "Clear"
        '
        'SelectAllCtrlAToolStripMenuItem
        '
        Me.SelectAllCtrlAToolStripMenuItem.Name = "SelectAllCtrlAToolStripMenuItem"
        Me.SelectAllCtrlAToolStripMenuItem.Size = New System.Drawing.Size(259, 22)
        Me.SelectAllCtrlAToolStripMenuItem.Text = "Select All                              Ctrl + A"
        '
        'VehicleChildrenCreation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 459)
        Me.Controls.Add(Me.startDtLabel)
        Me.Controls.Add(Me.startDtValueLabel)
        Me.Controls.Add(Me.marketLabel)
        Me.Controls.Add(Me.marketValueLabel)
        Me.Controls.Add(Me.retailerValueLabel)
        Me.Controls.Add(Me.retailerLabel)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.qcedOnValueLabel)
        Me.Controls.Add(Me.loadButton)
        Me.Controls.Add(Me.qcedOnLabel)
        Me.Controls.Add(Me.indexedOnValueLabel)
        Me.Controls.Add(Me.indexedOnLabel)
        Me.Controls.Add(Me.scannedOnValueLabel)
        Me.Controls.Add(Me.scannedOnLabel)
        Me.Controls.Add(Me.createdOnValueLabel)
        Me.Controls.Add(Me.createdOnLabel)
        Me.Controls.Add(Me.lvResult)
        Me.Controls.Add(Me.btnCreateChildren)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "VehicleChildrenCreation"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vehicle Children Creation"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.StatusReportDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatusReportDataSetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtVehicleID As System.Windows.Forms.TextBox
    Friend WithEvents loadButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCreateChildren As System.Windows.Forms.Button
    Friend WithEvents lvResult As System.Windows.Forms.ListView
    Friend WithEvents rtbTDlinkxNo As System.Windows.Forms.RichTextBox
    Friend WithEvents txtTDLinksNo As System.Windows.Forms.TextBox
    Friend WithEvents createdOnValueLabel As System.Windows.Forms.Label
    Friend WithEvents createdOnLabel As System.Windows.Forms.Label
    Friend WithEvents indexedOnValueLabel As System.Windows.Forms.Label
    Friend WithEvents indexedOnLabel As System.Windows.Forms.Label
    Friend WithEvents scannedOnValueLabel As System.Windows.Forms.Label
    Friend WithEvents scannedOnLabel As System.Windows.Forms.Label
    Friend WithEvents qcedOnValueLabel As System.Windows.Forms.Label
    Friend WithEvents qcedOnLabel As System.Windows.Forms.Label
    Friend WithEvents StatusReportDataSet As MCAP.StatusReportDataSet
    Friend WithEvents StatusReportDataSetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents retailerValueLabel As System.Windows.Forms.Label
    Friend WithEvents retailerLabel As System.Windows.Forms.Label
    Friend WithEvents marketLabel As System.Windows.Forms.Label
    Friend WithEvents marketValueLabel As System.Windows.Forms.Label
    Friend WithEvents startDtLabel As System.Windows.Forms.Label
    Friend WithEvents startDtValueLabel As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents copyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents undoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents redoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents clearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectAllCtrlAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
