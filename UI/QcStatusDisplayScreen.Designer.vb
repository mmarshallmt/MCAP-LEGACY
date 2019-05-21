Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class QcStatusDisplayScreen
        Inherits UI.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                Me.DataSource.Dispose()
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QcStatusDisplayScreen))
            Me.btnCancel = New System.Windows.Forms.Button
            Me.DataGridView1 = New System.Windows.Forms.DataGridView
            Me.DesP_ExecutionLogTableAdapter1 = New MCAP.DESPDataSetTableAdapters.DESP_ExecutionLogTableAdapter
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(370, 221)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(75, 23)
            Me.btnCancel.TabIndex = 17
            Me.btnCancel.Text = "Cancel"
            Me.btnCancel.UseVisualStyleBackColor = True
            '
            'DataGridView1
            '
            Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridView1.Location = New System.Drawing.Point(1, 38)
            Me.DataGridView1.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
            Me.DataGridView1.Name = "DataGridView1"
            Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
            Me.DataGridView1.Size = New System.Drawing.Size(837, 155)
            Me.DataGridView1.TabIndex = 18
            '
            'DesP_ExecutionLogTableAdapter1
            '
            Me.DesP_ExecutionLogTableAdapter1.ClearBeforeFill = True
            '
            'QcStatusDisplayScreen
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(847, 277)
            Me.Controls.Add(Me.DataGridView1)
            Me.Controls.Add(Me.btnCancel)
            Me.Name = "QcStatusDisplayScreen"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents filterTextBox As System.Windows.Forms.TextBox
        Friend WithEvents okButton As System.Windows.Forms.Button
        Friend WithEvents cancelButton As System.Windows.Forms.Button
        Friend WithEvents QCDataSet As MCAP.QCDataSet
        Friend WithEvents VwCircularBindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents VwCircularTableAdapter As MCAP.QCDataSetTableAdapters.vwCircularTableAdapter
        Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
        Friend WithEvents IndexDt As System.Windows.Forms.Label
        Friend WithEvents IndBy As System.Windows.Forms.Label
        Friend WithEvents ScDt As System.Windows.Forms.Label
        Friend WithEvents ScannBy As System.Windows.Forms.Label
        Friend WithEvents QCD As System.Windows.Forms.Label
        Friend WithEvents QCBy As System.Windows.Forms.Label
        Friend WithEvents RQCDt As System.Windows.Forms.Label
        Friend WithEvents IndexDate As System.Windows.Forms.TextBox
        Friend WithEvents IndexBy As System.Windows.Forms.TextBox
        Friend WithEvents ScanDt As System.Windows.Forms.TextBox
        Friend WithEvents ScannedBy As System.Windows.Forms.TextBox
        Friend WithEvents QCDt As System.Windows.Forms.TextBox
        Friend WithEvents QcedBy As System.Windows.Forms.TextBox
        Friend WithEvents ReQcDt As System.Windows.Forms.TextBox
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents Rqcby As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
        Friend WithEvents DesP_ExecutionLogTableAdapter1 As MCAP.DESPDataSetTableAdapters.DESP_ExecutionLogTableAdapter

    End Class

End Namespace