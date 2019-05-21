Namespace UI.Controls


  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class TypeInDatePicker
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
      Me.dateMaskedTextBox = New System.Windows.Forms.MaskedTextBox
      Me.DTPicker = New System.Windows.Forms.DateTimePicker
      Me.SuspendLayout()
      '
      'dateMaskedTextBox
      '
      Me.dateMaskedTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dateMaskedTextBox.Location = New System.Drawing.Point(0, 0)
      Me.dateMaskedTextBox.Mask = "00/00/00"
      Me.dateMaskedTextBox.Name = "dateMaskedTextBox"
      Me.dateMaskedTextBox.Size = New System.Drawing.Size(52, 20)
      Me.dateMaskedTextBox.TabIndex = 0
      '
      'DTPicker
      '
      Me.DTPicker.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DTPicker.CustomFormat = "MM/dd/yy"
      Me.DTPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.DTPicker.Location = New System.Drawing.Point(0, 0)
      Me.DTPicker.Name = "DTPicker"
      Me.DTPicker.Size = New System.Drawing.Size(72, 20)
      Me.DTPicker.TabIndex = 1
      Me.DTPicker.TabStop = False
      '
      'TypeInDatePicker
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.dateMaskedTextBox)
      Me.Controls.Add(Me.DTPicker)
      Me.Name = "TypeInDatePicker"
      Me.Size = New System.Drawing.Size(72, 20)
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub
    Friend WithEvents dateMaskedTextBox As System.Windows.Forms.MaskedTextBox
    Friend WithEvents DTPicker As System.Windows.Forms.DateTimePicker

  End Class


End Namespace