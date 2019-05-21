Namespace UI.Controls

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class MessageBoxForm
    Inherits UI.BaseForm

    Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      m_buttonCollection = New System.Collections.Generic.Dictionary(Of String, System.Windows.Forms.DialogResult)
    End Sub

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
      Me.messageboxTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
      Me.iconPictureBox = New System.Windows.Forms.PictureBox
      Me.buttonPanel = New System.Windows.Forms.Panel
      Me.sampleButton = New System.Windows.Forms.Button
      Me.messageLabel = New System.Windows.Forms.Label
      Me.messageboxTableLayoutPanel.SuspendLayout()
      CType(Me.iconPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.buttonPanel.SuspendLayout()
      Me.SuspendLayout()
      '
      'messageboxTableLayoutPanel
      '
      Me.messageboxTableLayoutPanel.ColumnCount = 2
      Me.messageboxTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
      Me.messageboxTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.messageboxTableLayoutPanel.Controls.Add(Me.iconPictureBox, 0, 0)
      Me.messageboxTableLayoutPanel.Controls.Add(Me.buttonPanel, 1, 1)
      Me.messageboxTableLayoutPanel.Controls.Add(Me.messageLabel, 1, 0)
      Me.messageboxTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.messageboxTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
      Me.messageboxTableLayoutPanel.Name = "messageboxTableLayoutPanel"
      Me.messageboxTableLayoutPanel.RowCount = 2
      Me.messageboxTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.messageboxTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.messageboxTableLayoutPanel.Size = New System.Drawing.Size(373, 112)
      Me.messageboxTableLayoutPanel.TabIndex = 0
      '
      'iconPictureBox
      '
      Me.iconPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.iconPictureBox.Location = New System.Drawing.Point(3, 3)
      Me.iconPictureBox.Name = "iconPictureBox"
      Me.iconPictureBox.Size = New System.Drawing.Size(69, 66)
      Me.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
      Me.iconPictureBox.TabIndex = 0
      Me.iconPictureBox.TabStop = False
      '
      'buttonPanel
      '
      Me.buttonPanel.Controls.Add(Me.sampleButton)
      Me.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.buttonPanel.Location = New System.Drawing.Point(78, 75)
      Me.buttonPanel.Name = "buttonPanel"
      Me.buttonPanel.Size = New System.Drawing.Size(292, 34)
      Me.buttonPanel.TabIndex = 2
      '
      'sampleButton
      '
      Me.sampleButton.Location = New System.Drawing.Point(3, 3)
      Me.sampleButton.Name = "sampleButton"
      Me.sampleButton.Size = New System.Drawing.Size(75, 23)
      Me.sampleButton.TabIndex = 0
      Me.sampleButton.Text = "Button1"
      Me.sampleButton.UseVisualStyleBackColor = True
      Me.sampleButton.Visible = False
      '
      'messageLabel
      '
      Me.messageLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.messageLabel.Location = New System.Drawing.Point(78, 0)
      Me.messageLabel.Name = "messageLabel"
      Me.messageLabel.Size = New System.Drawing.Size(292, 72)
      Me.messageLabel.TabIndex = 3
      Me.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'MessageBoxForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(373, 112)
      Me.Controls.Add(Me.messageboxTableLayoutPanel)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "MessageBoxForm"
      Me.Text = "MessageBoxForm"
      Me.messageboxTableLayoutPanel.ResumeLayout(False)
      CType(Me.iconPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
      Me.buttonPanel.ResumeLayout(False)
      Me.ResumeLayout(False)

    End Sub
    Friend WithEvents messageboxTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents iconPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents buttonPanel As System.Windows.Forms.Panel
    Friend WithEvents sampleButton As System.Windows.Forms.Button
    Friend WithEvents messageLabel As System.Windows.Forms.Label
  End Class

End Namespace