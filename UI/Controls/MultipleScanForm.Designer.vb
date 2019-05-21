Namespace UI.Controls

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class MultipleScanForm
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultipleScanForm))
      Me.vehicleIdTextBox = New System.Windows.Forms.TextBox
      Me.okButton = New System.Windows.Forms.Button
      Me.cancelButton = New System.Windows.Forms.Button
      Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
      CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.FlowLayoutPanel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'smalliconImageList
      '
      Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
      Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
      Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
      '
      'vehicleIdTextBox
      '
      Me.vehicleIdTextBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.vehicleIdTextBox.Location = New System.Drawing.Point(0, 0)
      Me.vehicleIdTextBox.Multiline = True
      Me.vehicleIdTextBox.Name = "vehicleIdTextBox"
      Me.vehicleIdTextBox.Size = New System.Drawing.Size(251, 194)
      Me.vehicleIdTextBox.TabIndex = 0
      '
      'okButton
      '
      Me.okButton.Location = New System.Drawing.Point(92, 3)
      Me.okButton.Name = "okButton"
      Me.okButton.Size = New System.Drawing.Size(75, 23)
      Me.okButton.TabIndex = 1
      Me.okButton.Text = "OK"
      Me.okButton.UseVisualStyleBackColor = True
      '
      'cancelButton
      '
      Me.cancelButton.Location = New System.Drawing.Point(173, 3)
      Me.cancelButton.Name = "cancelButton"
      Me.cancelButton.Size = New System.Drawing.Size(75, 23)
      Me.cancelButton.TabIndex = 2
      Me.cancelButton.Text = "Cancel"
      Me.cancelButton.UseVisualStyleBackColor = True
      '
      'FlowLayoutPanel1
      '
      Me.FlowLayoutPanel1.Controls.Add(Me.cancelButton)
      Me.FlowLayoutPanel1.Controls.Add(Me.okButton)
      Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
      Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 194)
      Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
      Me.FlowLayoutPanel1.Size = New System.Drawing.Size(251, 29)
      Me.FlowLayoutPanel1.TabIndex = 3
      '
      'MultipleScanForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(251, 223)
      Me.Controls.Add(Me.vehicleIdTextBox)
      Me.Controls.Add(Me.FlowLayoutPanel1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "MultipleScanForm"
      Me.Text = "Multiple Scan"
      CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
      Me.FlowLayoutPanel1.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub
    Friend WithEvents vehicleIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents okButton As System.Windows.Forms.Button
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel

  End Class

End Namespace