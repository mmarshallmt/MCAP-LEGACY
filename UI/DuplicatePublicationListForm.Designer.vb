<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DuplicatePublicationListForm
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DuplicatePublicationListForm))
    Me.duplicateDataGridView = New System.Windows.Forms.DataGridView
    Me.closeButton = New System.Windows.Forms.Button
    CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.duplicateDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'smalliconImageList
    '
    Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
    Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
    Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
    '
    'duplicateDataGridView
    '
    Me.duplicateDataGridView.AllowUserToAddRows = False
    Me.duplicateDataGridView.AllowUserToDeleteRows = False
    Me.duplicateDataGridView.AllowUserToOrderColumns = True
    Me.duplicateDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.duplicateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.duplicateDataGridView.Location = New System.Drawing.Point(1, 1)
    Me.duplicateDataGridView.Name = "duplicateDataGridView"
    Me.duplicateDataGridView.ReadOnly = True
    Me.duplicateDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.duplicateDataGridView.Size = New System.Drawing.Size(598, 321)
    Me.duplicateDataGridView.TabIndex = 0
    '
    'closeButton
    '
    Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.closeButton.Location = New System.Drawing.Point(513, 328)
    Me.closeButton.Name = "closeButton"
    Me.closeButton.Size = New System.Drawing.Size(75, 23)
    Me.closeButton.TabIndex = 1
    Me.closeButton.Text = "Cl&ose"
    Me.closeButton.UseVisualStyleBackColor = True
    '
    'DuplicatePublicationListForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.ClientSize = New System.Drawing.Size(600, 357)
    Me.Controls.Add(Me.closeButton)
    Me.Controls.Add(Me.duplicateDataGridView)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "DuplicatePublicationListForm"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.StatusMessage = ""
    Me.Text = "Possible Duplicate Publications"
    CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.duplicateDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents duplicateDataGridView As System.Windows.Forms.DataGridView
  Friend WithEvents closeButton As System.Windows.Forms.Button

End Class
