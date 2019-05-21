Namespace UI.Controls

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class thumbnailToolTipForm
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
      Me.closeButton = New System.Windows.Forms.Button
      Me.tooltipLabel = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'closeButton
      '
      Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.closeButton.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.closeButton.Location = New System.Drawing.Point(245, 3)
      Me.closeButton.Name = "closeButton"
      Me.closeButton.Size = New System.Drawing.Size(23, 24)
      Me.closeButton.TabIndex = 0
      Me.closeButton.Text = "X"
      Me.closeButton.TextAlign = System.Drawing.ContentAlignment.TopLeft
      Me.closeButton.UseVisualStyleBackColor = True
      '
      'tooltipLabel
      '
      Me.tooltipLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tooltipLabel.AutoEllipsis = True
      Me.tooltipLabel.Location = New System.Drawing.Point(1, 31)
      Me.tooltipLabel.Name = "tooltipLabel"
      Me.tooltipLabel.Size = New System.Drawing.Size(267, 54)
      Me.tooltipLabel.TabIndex = 1
      '
      'thumbnailToolTipForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
      Me.CancelButton = Me.closeButton
      Me.ClientSize = New System.Drawing.Size(270, 87)
      Me.ControlBox = False
      Me.Controls.Add(Me.tooltipLabel)
      Me.Controls.Add(Me.closeButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
      Me.Name = "thumbnailToolTipForm"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
      Me.ResumeLayout(False)

    End Sub
    Protected WithEvents closeButton As System.Windows.Forms.Button
    Protected WithEvents tooltipLabel As System.Windows.Forms.Label
  End Class

End Namespace