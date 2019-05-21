Namespace UI.Controls

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class StatusMessageForm
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
      Me.statusMessageLabel = New System.Windows.Forms.Label
      Me.SuspendLayout()
      '
      'statusMessageLabel
      '
      Me.statusMessageLabel.AutoEllipsis = True
      Me.statusMessageLabel.Location = New System.Drawing.Point(12, 9)
      Me.statusMessageLabel.Name = "statusMessageLabel"
      Me.statusMessageLabel.Size = New System.Drawing.Size(373, 29)
      Me.statusMessageLabel.TabIndex = 0
      Me.statusMessageLabel.Text = "<Status Message>"
      Me.statusMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'StatusMessageForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(397, 47)
      Me.ControlBox = False
      Me.Controls.Add(Me.statusMessageLabel)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Name = "StatusMessageForm"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.ResumeLayout(False)

    End Sub

    Friend WithEvents statusMessageLabel As System.Windows.Forms.Label

  End Class

End Namespace