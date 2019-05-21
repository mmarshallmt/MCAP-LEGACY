<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImagesViewForm
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Me.picCurrent = New System.Windows.Forms.PictureBox()
        Me.tmrShow = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picCurrent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picCurrent
        '
        Me.picCurrent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picCurrent.Location = New System.Drawing.Point(140, 24)
        Me.picCurrent.Name = "picCurrent"
        Me.picCurrent.Size = New System.Drawing.Size(425, 236)
        Me.picCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCurrent.TabIndex = 0
        Me.picCurrent.TabStop = False
        '
        'tmrShow
        '
        Me.tmrShow.Interval = 5000
        '
        'ImagesViewForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 302)
        Me.Controls.Add(Me.picCurrent)
        Me.ForeColor = System.Drawing.Color.White
        Me.Name = "ImagesViewForm"
        Me.Text = "MCAP Image Viewer"
        CType(Me.picCurrent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picCurrent As System.Windows.Forms.PictureBox
    Friend WithEvents tmrShow As System.Windows.Forms.Timer

End Class
