Namespace UI.Controls

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class ProgressInformationForm
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
      Me.progressTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
      Me.messageLabel = New System.Windows.Forms.Label
      Me.progressProgressBar = New System.Windows.Forms.ProgressBar
      Me.progressLabel = New System.Windows.Forms.Label
      Me.progressTableLayoutPanel.SuspendLayout()
      Me.SuspendLayout()
      '
      'progressTableLayoutPanel
      '
      Me.progressTableLayoutPanel.ColumnCount = 1
      Me.progressTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.progressTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.progressTableLayoutPanel.Controls.Add(Me.messageLabel, 0, 0)
      Me.progressTableLayoutPanel.Controls.Add(Me.progressProgressBar, 0, 1)
      Me.progressTableLayoutPanel.Controls.Add(Me.progressLabel, 0, 2)
      Me.progressTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.progressTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
      Me.progressTableLayoutPanel.Name = "progressTableLayoutPanel"
      Me.progressTableLayoutPanel.RowCount = 3
      Me.progressTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.progressTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.progressTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.progressTableLayoutPanel.Size = New System.Drawing.Size(447, 88)
      Me.progressTableLayoutPanel.TabIndex = 0
      '
      'messageLabel
      '
      Me.messageLabel.AutoSize = True
      Me.messageLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.messageLabel.Location = New System.Drawing.Point(3, 0)
      Me.messageLabel.Name = "messageLabel"
      Me.messageLabel.Size = New System.Drawing.Size(441, 34)
      Me.messageLabel.TabIndex = 0
      Me.messageLabel.Text = "Label1"
      Me.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'progressProgressBar
      '
      Me.progressProgressBar.Dock = System.Windows.Forms.DockStyle.Fill
      Me.progressProgressBar.Location = New System.Drawing.Point(3, 37)
      Me.progressProgressBar.Name = "progressProgressBar"
      Me.progressProgressBar.Size = New System.Drawing.Size(441, 14)
      Me.progressProgressBar.TabIndex = 1
      '
      'progressLabel
      '
      Me.progressLabel.AutoSize = True
      Me.progressLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.progressLabel.Location = New System.Drawing.Point(3, 54)
      Me.progressLabel.Name = "progressLabel"
      Me.progressLabel.Size = New System.Drawing.Size(441, 34)
      Me.progressLabel.TabIndex = 2
      Me.progressLabel.Text = "Label2"
      '
      'ProgressInformationForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(447, 88)
      Me.ControlBox = False
      Me.Controls.Add(Me.progressTableLayoutPanel)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Name = "ProgressInformationForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Progress Information"
      Me.progressTableLayoutPanel.ResumeLayout(False)
      Me.progressTableLayoutPanel.PerformLayout()
      Me.ResumeLayout(False)

    End Sub
    Friend WithEvents progressTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents progressProgressBar As System.Windows.Forms.ProgressBar
    Private WithEvents messageLabel As System.Windows.Forms.Label
    Private WithEvents progressLabel As System.Windows.Forms.Label
  End Class

End Namespace