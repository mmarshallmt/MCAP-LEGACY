<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class clsMessageBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(clsMessageBox))
        Me.labelBody = New System.Windows.Forms.Label()
        Me.buttonCancel = New System.Windows.Forms.Button()
        Me.buttonNotoAll = New System.Windows.Forms.Button()
        Me.buttonNo = New System.Windows.Forms.Button()
        Me.buttonYestoAll = New System.Windows.Forms.Button()
        Me.buttonYes = New System.Windows.Forms.Button()
        Me.pictureBoxIcon = New System.Windows.Forms.PictureBox()
        CType(Me.pictureBoxIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelBody
        '
        Me.labelBody.AutoSize = True
        Me.labelBody.Location = New System.Drawing.Point(118, 12)
        Me.labelBody.Name = "labelBody"
        Me.labelBody.Size = New System.Drawing.Size(0, 13)
        Me.labelBody.TabIndex = 13
        '
        'buttonCancel
        '
        Me.buttonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonCancel.Location = New System.Drawing.Point(347, 194)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
        Me.buttonCancel.TabIndex = 12
        Me.buttonCancel.Text = "Cancel"
        Me.buttonCancel.UseVisualStyleBackColor = True
        '
        'buttonNotoAll
        '
        Me.buttonNotoAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonNotoAll.Location = New System.Drawing.Point(266, 194)
        Me.buttonNotoAll.Name = "buttonNotoAll"
        Me.buttonNotoAll.Size = New System.Drawing.Size(75, 23)
        Me.buttonNotoAll.TabIndex = 11
        Me.buttonNotoAll.Text = "Not to All"
        Me.buttonNotoAll.UseVisualStyleBackColor = True
        '
        'buttonNo
        '
        Me.buttonNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonNo.Location = New System.Drawing.Point(185, 194)
        Me.buttonNo.Name = "buttonNo"
        Me.buttonNo.Size = New System.Drawing.Size(75, 23)
        Me.buttonNo.TabIndex = 10
        Me.buttonNo.Text = "No"
        Me.buttonNo.UseVisualStyleBackColor = True
        '
        'buttonYestoAll
        '
        Me.buttonYestoAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonYestoAll.Location = New System.Drawing.Point(104, 194)
        Me.buttonYestoAll.Name = "buttonYestoAll"
        Me.buttonYestoAll.Size = New System.Drawing.Size(75, 23)
        Me.buttonYestoAll.TabIndex = 9
        Me.buttonYestoAll.Text = "Yes to All"
        Me.buttonYestoAll.UseVisualStyleBackColor = True
        '
        'buttonYes
        '
        Me.buttonYes.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonYes.Location = New System.Drawing.Point(23, 194)
        Me.buttonYes.Name = "buttonYes"
        Me.buttonYes.Size = New System.Drawing.Size(75, 23)
        Me.buttonYes.TabIndex = 8
        Me.buttonYes.Text = "Yes"
        Me.buttonYes.UseVisualStyleBackColor = True
        '
        'pictureBoxIcon
        '
        Me.pictureBoxIcon.Location = New System.Drawing.Point(12, 12)
        Me.pictureBoxIcon.Name = "pictureBoxIcon"
        Me.pictureBoxIcon.Size = New System.Drawing.Size(100, 100)
        Me.pictureBoxIcon.TabIndex = 7
        Me.pictureBoxIcon.TabStop = False
        '
        'clsMessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 229)
        Me.Controls.Add(Me.labelBody)
        Me.Controls.Add(Me.buttonCancel)
        Me.Controls.Add(Me.buttonNotoAll)
        Me.Controls.Add(Me.buttonNo)
        Me.Controls.Add(Me.buttonYestoAll)
        Me.Controls.Add(Me.buttonYes)
        Me.Controls.Add(Me.pictureBoxIcon)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "clsMessageBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MCAP"
        CType(Me.pictureBoxIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents labelBody As System.Windows.Forms.Label
    Private WithEvents buttonCancel As System.Windows.Forms.Button
    Private WithEvents buttonNotoAll As System.Windows.Forms.Button
    Private WithEvents buttonNo As System.Windows.Forms.Button
    Private WithEvents buttonYestoAll As System.Windows.Forms.Button
    Private WithEvents buttonYes As System.Windows.Forms.Button
    Private WithEvents pictureBoxIcon As System.Windows.Forms.PictureBox

End Class
