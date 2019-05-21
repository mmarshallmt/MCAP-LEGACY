Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class ResequenceForm
    Inherits UI.BaseForm

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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResequenceForm))
            Me.resequenceListBox = New System.Windows.Forms.ListBox()
            Me.moveToTopButton = New System.Windows.Forms.Button()
            Me.resequenceImageList = New System.Windows.Forms.ImageList(Me.components)
            Me.moveUpwardsButton = New System.Windows.Forms.Button()
            Me.moveDownwardsButton = New System.Windows.Forms.Button()
            Me.moveToBottomButton = New System.Windows.Forms.Button()
            Me.okButton = New System.Windows.Forms.Button()
            Me.cancelButton = New System.Windows.Forms.Button()
            Me.resequenceContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.moveToTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.moveUpwardsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.moveDownwardsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.moveToBottomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.pageInfoListBox = New System.Windows.Forms.ListBox()
            Me.pageSizeLabel = New System.Windows.Forms.Label()
            Me.pageSizeValueLabel = New System.Windows.Forms.Label()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.resequenceContextMenuStrip.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'resequenceListBox
            '
            Me.resequenceListBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.resequenceListBox.FormattingEnabled = True
            Me.resequenceListBox.Location = New System.Drawing.Point(159, 12)
            Me.resequenceListBox.Name = "resequenceListBox"
            Me.resequenceListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
            Me.resequenceListBox.Size = New System.Drawing.Size(402, 498)
            Me.resequenceListBox.TabIndex = 1
            '
            'moveToTopButton
            '
            Me.moveToTopButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.moveToTopButton.ImageIndex = 0
            Me.moveToTopButton.ImageList = Me.resequenceImageList
            Me.moveToTopButton.Location = New System.Drawing.Point(567, 188)
            Me.moveToTopButton.Name = "moveToTopButton"
            Me.moveToTopButton.Size = New System.Drawing.Size(31, 32)
            Me.moveToTopButton.TabIndex = 2
            Me.moveToTopButton.UseVisualStyleBackColor = True
            '
            'resequenceImageList
            '
            Me.resequenceImageList.ImageStream = CType(resources.GetObject("resequenceImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.resequenceImageList.TransparentColor = System.Drawing.Color.Transparent
            Me.resequenceImageList.Images.SetKeyName(0, "GoTop.ico")
            Me.resequenceImageList.Images.SetKeyName(1, "GoUpwards.ico")
            Me.resequenceImageList.Images.SetKeyName(2, "GoDownwards.ico")
            Me.resequenceImageList.Images.SetKeyName(3, "GoBottom.ico")
            '
            'moveUpwardsButton
            '
            Me.moveUpwardsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.moveUpwardsButton.ImageIndex = 1
            Me.moveUpwardsButton.ImageList = Me.resequenceImageList
            Me.moveUpwardsButton.Location = New System.Drawing.Point(567, 226)
            Me.moveUpwardsButton.Name = "moveUpwardsButton"
            Me.moveUpwardsButton.Size = New System.Drawing.Size(31, 32)
            Me.moveUpwardsButton.TabIndex = 3
            Me.moveUpwardsButton.UseVisualStyleBackColor = True
            '
            'moveDownwardsButton
            '
            Me.moveDownwardsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.moveDownwardsButton.ImageIndex = 2
            Me.moveDownwardsButton.ImageList = Me.resequenceImageList
            Me.moveDownwardsButton.Location = New System.Drawing.Point(567, 265)
            Me.moveDownwardsButton.Name = "moveDownwardsButton"
            Me.moveDownwardsButton.Size = New System.Drawing.Size(31, 32)
            Me.moveDownwardsButton.TabIndex = 4
            Me.moveDownwardsButton.UseVisualStyleBackColor = True
            '
            'moveToBottomButton
            '
            Me.moveToBottomButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.moveToBottomButton.ImageIndex = 3
            Me.moveToBottomButton.ImageList = Me.resequenceImageList
            Me.moveToBottomButton.Location = New System.Drawing.Point(567, 303)
            Me.moveToBottomButton.Name = "moveToBottomButton"
            Me.moveToBottomButton.Size = New System.Drawing.Size(31, 32)
            Me.moveToBottomButton.TabIndex = 5
            Me.moveToBottomButton.UseVisualStyleBackColor = True
            '
            'okButton
            '
            Me.okButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.okButton.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.okButton.Location = New System.Drawing.Point(442, 516)
            Me.okButton.Name = "okButton"
            Me.okButton.Size = New System.Drawing.Size(75, 23)
            Me.okButton.TabIndex = 13
            Me.okButton.Text = "O&K"
            Me.okButton.UseVisualStyleBackColor = True
            '
            'cancelButton
            '
            Me.cancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.cancelButton.Location = New System.Drawing.Point(523, 516)
            Me.cancelButton.Name = "cancelButton"
            Me.cancelButton.Size = New System.Drawing.Size(75, 23)
            Me.cancelButton.TabIndex = 14
            Me.cancelButton.Text = "&Cancel"
            Me.cancelButton.UseVisualStyleBackColor = True
            '
            'resequenceContextMenuStrip
            '
            Me.resequenceContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.moveToTopToolStripMenuItem, Me.moveUpwardsToolStripMenuItem, Me.moveDownwardsToolStripMenuItem, Me.moveToBottomToolStripMenuItem})
            Me.resequenceContextMenuStrip.Name = "resequenceContextMenuStrip"
            Me.resequenceContextMenuStrip.Size = New System.Drawing.Size(170, 92)
            '
            'moveToTopToolStripMenuItem
            '
            Me.moveToTopToolStripMenuItem.Name = "moveToTopToolStripMenuItem"
            Me.moveToTopToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
            Me.moveToTopToolStripMenuItem.Text = "Move To &Top"
            '
            'moveUpwardsToolStripMenuItem
            '
            Me.moveUpwardsToolStripMenuItem.Name = "moveUpwardsToolStripMenuItem"
            Me.moveUpwardsToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
            Me.moveUpwardsToolStripMenuItem.Text = "Move &Upwards"
            '
            'moveDownwardsToolStripMenuItem
            '
            Me.moveDownwardsToolStripMenuItem.Name = "moveDownwardsToolStripMenuItem"
            Me.moveDownwardsToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
            Me.moveDownwardsToolStripMenuItem.Text = "Move &Downwards"
            '
            'moveToBottomToolStripMenuItem
            '
            Me.moveToBottomToolStripMenuItem.Name = "moveToBottomToolStripMenuItem"
            Me.moveToBottomToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
            Me.moveToBottomToolStripMenuItem.Text = "Move To &Bottom"
            '
            'pageInfoListBox
            '
            Me.pageInfoListBox.FormattingEnabled = True
            Me.pageInfoListBox.Location = New System.Drawing.Point(12, 12)
            Me.pageInfoListBox.Name = "pageInfoListBox"
            Me.pageInfoListBox.Size = New System.Drawing.Size(141, 498)
            Me.pageInfoListBox.TabIndex = 0
            '
            'pageSizeLabel
            '
            Me.pageSizeLabel.AutoSize = True
            Me.pageSizeLabel.Location = New System.Drawing.Point(12, 521)
            Me.pageSizeLabel.Name = "pageSizeLabel"
            Me.pageSizeLabel.Size = New System.Drawing.Size(55, 13)
            Me.pageSizeLabel.TabIndex = 15
            Me.pageSizeLabel.Text = "Page Size"
            '
            'pageSizeValueLabel
            '
            Me.pageSizeValueLabel.AutoSize = True
            Me.pageSizeValueLabel.Location = New System.Drawing.Point(73, 521)
            Me.pageSizeValueLabel.Name = "pageSizeValueLabel"
            Me.pageSizeValueLabel.Size = New System.Drawing.Size(67, 13)
            Me.pageSizeValueLabel.TabIndex = 16
            Me.pageSizeValueLabel.Text = "<Page Size>"
            '
            'ResequenceForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(610, 551)
            Me.Controls.Add(Me.pageSizeValueLabel)
            Me.Controls.Add(Me.pageSizeLabel)
            Me.Controls.Add(Me.pageInfoListBox)
            Me.Controls.Add(Me.okButton)
            Me.Controls.Add(Me.resequenceListBox)
            Me.Controls.Add(Me.cancelButton)
            Me.Controls.Add(Me.moveDownwardsButton)
            Me.Controls.Add(Me.moveToBottomButton)
            Me.Controls.Add(Me.moveToTopButton)
            Me.Controls.Add(Me.moveUpwardsButton)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ResequenceForm"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Resequence Vehicle Page Images"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.resequenceContextMenuStrip.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
    Friend WithEvents resequenceListBox As System.Windows.Forms.ListBox
    Friend WithEvents moveToTopButton As System.Windows.Forms.Button
    Friend WithEvents moveUpwardsButton As System.Windows.Forms.Button
    Friend WithEvents moveDownwardsButton As System.Windows.Forms.Button
    Friend WithEvents moveToBottomButton As System.Windows.Forms.Button
    Friend WithEvents okButton As System.Windows.Forms.Button
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents resequenceContextMenuStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents moveToTopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents moveUpwardsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents moveDownwardsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents moveToBottomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents resequenceImageList As System.Windows.Forms.ImageList
    Friend WithEvents pageInfoListBox As System.Windows.Forms.ListBox
    Friend WithEvents pageSizeLabel As System.Windows.Forms.Label
    Friend WithEvents pageSizeValueLabel As System.Windows.Forms.Label
  End Class

End Namespace