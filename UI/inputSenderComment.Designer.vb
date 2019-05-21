<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class inputSenderComment
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
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonOK = New System.Windows.Forms.Button()
        Me.TextBoxURL = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(399, 131)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(91, 40)
        Me.ButtonCancel.TabIndex = 7
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonOK
        '
        Me.ButtonOK.Location = New System.Drawing.Point(290, 131)
        Me.ButtonOK.Name = "ButtonOK"
        Me.ButtonOK.Size = New System.Drawing.Size(91, 40)
        Me.ButtonOK.TabIndex = 6
        Me.ButtonOK.Text = "Update"
        Me.ButtonOK.UseVisualStyleBackColor = True
        '
        'TextBoxURL
        '
        Me.TextBoxURL.Location = New System.Drawing.Point(10, 9)
        Me.TextBoxURL.Multiline = True
        Me.TextBoxURL.Name = "TextBoxURL"
        Me.TextBoxURL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxURL.Size = New System.Drawing.Size(483, 116)
        Me.TextBoxURL.TabIndex = 5
        '
        'inputSenderComment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 187)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOK)
        Me.Controls.Add(Me.TextBoxURL)
        Me.Name = "inputSenderComment"
        Me.Text = "inputSenderComment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonOK As System.Windows.Forms.Button
    Friend WithEvents TextBoxURL As System.Windows.Forms.TextBox
End Class
