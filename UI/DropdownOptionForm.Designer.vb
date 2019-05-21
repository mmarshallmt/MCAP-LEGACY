<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DropdownOptionForm
    Inherits UI.BaseForm

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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DropdownOptionForm))
    Me.delayLabel = New System.Windows.Forms.Label
    Me.delayComboBox = New System.Windows.Forms.ComboBox
    Me.okButton = New System.Windows.Forms.Button
    Me.cancelButton = New System.Windows.Forms.Button
    Me.promptLabel = New System.Windows.Forms.Label
    CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'smalliconImageList
    '
    Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
    Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
    Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
    '
    'delayLabel
    '
    Me.delayLabel.AutoSize = True
    Me.delayLabel.Location = New System.Drawing.Point(13, 56)
    Me.delayLabel.Name = "delayLabel"
    Me.delayLabel.Size = New System.Drawing.Size(91, 13)
    Me.delayLabel.TabIndex = 0
    Me.delayLabel.Text = "&Delay (in Second)"
    '
    'delayComboBox
    '
    Me.delayComboBox.FormattingEnabled = True
    Me.delayComboBox.Location = New System.Drawing.Point(110, 53)
    Me.delayComboBox.Name = "delayComboBox"
    Me.delayComboBox.Size = New System.Drawing.Size(196, 21)
    Me.delayComboBox.TabIndex = 1
    '
    'okButton
    '
    Me.okButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.okButton.Location = New System.Drawing.Point(150, 96)
    Me.okButton.Name = "okButton"
    Me.okButton.Size = New System.Drawing.Size(75, 23)
    Me.okButton.TabIndex = 2
    Me.okButton.Text = "&OK"
    Me.okButton.UseVisualStyleBackColor = True
    '
    'cancelButton
    '
    Me.cancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cancelButton.Location = New System.Drawing.Point(231, 96)
    Me.cancelButton.Name = "cancelButton"
    Me.cancelButton.Size = New System.Drawing.Size(75, 23)
    Me.cancelButton.TabIndex = 3
    Me.cancelButton.Text = "&Cancel"
    Me.cancelButton.UseVisualStyleBackColor = True
    '
    'promptLabel
    '
    Me.promptLabel.AutoEllipsis = True
    Me.promptLabel.Location = New System.Drawing.Point(12, 9)
    Me.promptLabel.Name = "promptLabel"
    Me.promptLabel.Size = New System.Drawing.Size(294, 32)
    Me.promptLabel.TabIndex = 4
    Me.promptLabel.Text = "How long should the capture program waiting until capturing the image?"
    '
    'DropdownOptionForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.ClientSize = New System.Drawing.Size(318, 131)
    Me.Controls.Add(Me.promptLabel)
    Me.Controls.Add(Me.cancelButton)
    Me.Controls.Add(Me.okButton)
    Me.Controls.Add(Me.delayComboBox)
    Me.Controls.Add(Me.delayLabel)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "DropdownOptionForm"
    Me.Text = "Delay Selection"
    CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents delayLabel As System.Windows.Forms.Label
  Friend WithEvents delayComboBox As System.Windows.Forms.ComboBox
  Friend WithEvents okButton As System.Windows.Forms.Button
  Friend WithEvents cancelButton As System.Windows.Forms.Button
  Friend WithEvents promptLabel As System.Windows.Forms.Label

End Class
