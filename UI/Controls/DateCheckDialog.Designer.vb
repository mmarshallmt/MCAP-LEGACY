Namespace UI


  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class DateCheckDialog
    Inherits BaseForm

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
      Me.messageLabel = New System.Windows.Forms.Label
      Me.ignoreButton = New System.Windows.Forms.Button
      Me.okButton = New System.Windows.Forms.Button
      Me.PictureBox1 = New System.Windows.Forms.PictureBox
      CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'messageLabel
      '
      Me.messageLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.messageLabel.AutoEllipsis = True
      Me.messageLabel.Location = New System.Drawing.Point(66, 9)
      Me.messageLabel.Name = "messageLabel"
      Me.messageLabel.Size = New System.Drawing.Size(293, 56)
      Me.messageLabel.TabIndex = 0
      '
      'ignoreButton
      '
      Me.ignoreButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ignoreButton.Location = New System.Drawing.Point(203, 78)
      Me.ignoreButton.Name = "ignoreButton"
      Me.ignoreButton.Size = New System.Drawing.Size(75, 23)
      Me.ignoreButton.TabIndex = 1
      Me.ignoreButton.Text = "&Ignore"
      Me.ignoreButton.UseVisualStyleBackColor = True
      Me.ignoreButton.Visible = False
      '
      'okButton
      '
      Me.okButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.okButton.Location = New System.Drawing.Point(284, 78)
      Me.okButton.Name = "okButton"
      Me.okButton.Size = New System.Drawing.Size(75, 23)
      Me.okButton.TabIndex = 2
      Me.okButton.Text = "&OK"
      Me.okButton.UseVisualStyleBackColor = True
      '
      'PictureBox1
      '
      Me.PictureBox1.Image = Nothing
      Me.PictureBox1.InitialImage = Nothing
      Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
      Me.PictureBox1.TabIndex = 3
      Me.PictureBox1.TabStop = False
      '
      'DateCheckDialog
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(371, 113)
      Me.Controls.Add(Me.PictureBox1)
      Me.Controls.Add(Me.okButton)
      Me.Controls.Add(Me.ignoreButton)
      Me.Controls.Add(Me.messageLabel)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.KeyPreview = True
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.MinimumSize = New System.Drawing.Size(186, 145)
      Me.Name = "DateCheckDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Date Check"
      CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub
    Protected WithEvents messageLabel As System.Windows.Forms.Label
    Protected WithEvents ignoreButton As System.Windows.Forms.Button
    Protected WithEvents okButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  End Class


End Namespace