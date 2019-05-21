<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Me.picCurrent = New System.Windows.Forms.PictureBox
        Me.picNext = New System.Windows.Forms.PictureBox
        Me.picLast = New System.Windows.Forms.PictureBox
        Me.btnFolder = New System.Windows.Forms.Button
        Me.btnLast = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnSlideshow = New System.Windows.Forms.Button
        Me.tmrShow = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picCurrent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picNext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLast, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picCurrent
        '
        Me.picCurrent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picCurrent.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.picCurrent.Location = New System.Drawing.Point(140, 24)
        Me.picCurrent.Name = "picCurrent"
        Me.picCurrent.Size = New System.Drawing.Size(425, 236)
        Me.picCurrent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picCurrent.TabIndex = 0
        Me.picCurrent.TabStop = False
        '
        'picNext
        '
        Me.picNext.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.picNext.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.picNext.Location = New System.Drawing.Point(589, 101)
        Me.picNext.Name = "picNext"
        Me.picNext.Size = New System.Drawing.Size(100, 100)
        Me.picNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picNext.TabIndex = 1
        Me.picNext.TabStop = False
        '
        'picLast
        '
        Me.picLast.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.picLast.BackColor = System.Drawing.Color.FromArgb(CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(12, Byte), Integer))
        Me.picLast.Location = New System.Drawing.Point(17, 101)
        Me.picLast.Name = "picLast"
        Me.picLast.Size = New System.Drawing.Size(100, 100)
        Me.picLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picLast.TabIndex = 2
        Me.picLast.TabStop = False
        '
        'btnFolder
        '
        Me.btnFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFolder.Location = New System.Drawing.Point(589, 237)
        Me.btnFolder.Name = "btnFolder"
        Me.btnFolder.Size = New System.Drawing.Size(100, 23)
        Me.btnFolder.TabIndex = 3
        Me.btnFolder.Text = "Select Folder"
        Me.btnFolder.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnLast.Location = New System.Drawing.Point(306, 268)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(45, 23)
        Me.btnLast.TabIndex = 4
        Me.btnLast.Text = "<<"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnNext.Location = New System.Drawing.Point(361, 268)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(45, 23)
        Me.btnNext.TabIndex = 5
        Me.btnNext.Text = ">>"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnSlideshow
        '
        Me.btnSlideshow.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSlideshow.Location = New System.Drawing.Point(430, 268)
        Me.btnSlideshow.Name = "btnSlideshow"
        Me.btnSlideshow.Size = New System.Drawing.Size(100, 23)
        Me.btnSlideshow.TabIndex = 6
        Me.btnSlideshow.Text = "Start Slideshow"
        Me.btnSlideshow.UseVisualStyleBackColor = True
        '
        'tmrShow
        '
        Me.tmrShow.Interval = 5000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(713, 302)
        Me.Controls.Add(Me.btnSlideshow)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnFolder)
        Me.Controls.Add(Me.picLast)
        Me.Controls.Add(Me.picNext)
        Me.Controls.Add(Me.picCurrent)
        Me.Name = "Form1"
        Me.Text = "Simplified Picture Viewer"
        CType(Me.picCurrent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picNext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLast, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picCurrent As System.Windows.Forms.PictureBox
    Friend WithEvents picNext As System.Windows.Forms.PictureBox
    Friend WithEvents picLast As System.Windows.Forms.PictureBox
    Friend WithEvents btnFolder As System.Windows.Forms.Button
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnSlideshow As System.Windows.Forms.Button
    Friend WithEvents tmrShow As System.Windows.Forms.Timer

End Class
