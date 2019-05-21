<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CCTasksLogSenderDetailsForm
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.NameLabel = New System.Windows.Forms.Label
        Me.AddressLabel = New System.Windows.Forms.Label
        Me.PhoneLabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Address"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Phone"
        '
        'NameLabel
        '
        Me.NameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NameLabel.Location = New System.Drawing.Point(91, 9)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(527, 25)
        Me.NameLabel.TabIndex = 6
        Me.NameLabel.Text = "*"
        '
        'AddressLabel
        '
        Me.AddressLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AddressLabel.Location = New System.Drawing.Point(91, 38)
        Me.AddressLabel.Name = "AddressLabel"
        Me.AddressLabel.Size = New System.Drawing.Size(527, 72)
        Me.AddressLabel.TabIndex = 7
        Me.AddressLabel.Text = "*"
        '
        'PhoneLabel
        '
        Me.PhoneLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PhoneLabel.Location = New System.Drawing.Point(91, 113)
        Me.PhoneLabel.Name = "PhoneLabel"
        Me.PhoneLabel.Size = New System.Drawing.Size(527, 22)
        Me.PhoneLabel.TabIndex = 8
        Me.PhoneLabel.Text = "*"
        '
        'CCTasksLogSenderDetailsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 146)
        Me.Controls.Add(Me.PhoneLabel)
        Me.Controls.Add(Me.AddressLabel)
        Me.Controls.Add(Me.NameLabel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "CCTasksLogSenderDetailsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SenderDetailsForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents AddressLabel As System.Windows.Forms.Label
    Friend WithEvents PhoneLabel As System.Windows.Forms.Label
End Class
