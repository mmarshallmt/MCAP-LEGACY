Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ScanTrackerRemoteQCForm
        Inherits UI.MDIChildFormBase

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScanTrackerRemoteQCForm))
            Me.Label1 = New System.Windows.Forms.Label
            Me.SourceTextBox = New System.Windows.Forms.TextBox
            Me.BrowseButton = New System.Windows.Forms.Button
            Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
            Me.Label2 = New System.Windows.Forms.Label
            Me.DestinationLabel = New System.Windows.Forms.Label
            Me.Label6 = New System.Windows.Forms.Label
            Me.ImageCountLabel = New System.Windows.Forms.Label
            Me.Label5 = New System.Windows.Forms.Label
            Me.VehicleCountLabel = New System.Windows.Forms.Label
            Me.PostButton = New System.Windows.Forms.Button
            Me.ReviewButton = New System.Windows.Forms.Button
            Me.ProgressPanel = New System.Windows.Forms.Panel
            Me.progressLabel = New System.Windows.Forms.Label
            Me.imageProgressBar = New System.Windows.Forms.ProgressBar
            Me.RotateComboBox = New System.Windows.Forms.ComboBox
            Me.Label3 = New System.Windows.Forms.Label
            Me.RecountButton = New System.Windows.Forms.Button
            Me.LocationComboBox = New System.Windows.Forms.ComboBox
            Me.Label4 = New System.Windows.Forms.Label
            Me.BatchPostButton = New System.Windows.Forms.Button
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ProgressPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(10, 9)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(41, 13)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Source"
            '
            'SourceTextBox
            '
            Me.SourceTextBox.Location = New System.Drawing.Point(92, 6)
            Me.SourceTextBox.Name = "SourceTextBox"
            Me.SourceTextBox.Size = New System.Drawing.Size(233, 20)
            Me.SourceTextBox.TabIndex = 1
            '
            'BrowseButton
            '
            Me.BrowseButton.Location = New System.Drawing.Point(331, 6)
            Me.BrowseButton.Name = "BrowseButton"
            Me.BrowseButton.Size = New System.Drawing.Size(50, 19)
            Me.BrowseButton.TabIndex = 2
            Me.BrowseButton.Text = "Browse"
            Me.BrowseButton.UseVisualStyleBackColor = True
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(10, 30)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(60, 13)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "Destination"
            '
            'DestinationLabel
            '
            Me.DestinationLabel.AutoSize = True
            Me.DestinationLabel.Location = New System.Drawing.Point(89, 30)
            Me.DestinationLabel.Name = "DestinationLabel"
            Me.DestinationLabel.Size = New System.Drawing.Size(70, 13)
            Me.DestinationLabel.TabIndex = 4
            Me.DestinationLabel.Text = "<destination>"
            '
            'Label6
            '
            Me.Label6.AutoSize = True
            Me.Label6.Location = New System.Drawing.Point(11, 53)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(70, 13)
            Me.Label6.TabIndex = 10
            Me.Label6.Text = "Image Count:"
            '
            'ImageCountLabel
            '
            Me.ImageCountLabel.AutoSize = True
            Me.ImageCountLabel.Location = New System.Drawing.Point(89, 53)
            Me.ImageCountLabel.Name = "ImageCountLabel"
            Me.ImageCountLabel.Size = New System.Drawing.Size(14, 13)
            Me.ImageCountLabel.TabIndex = 11
            Me.ImageCountLabel.Text = "#"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(10, 77)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(76, 13)
            Me.Label5.TabIndex = 12
            Me.Label5.Text = "Vehicle Count:"
            '
            'VehicleCountLabel
            '
            Me.VehicleCountLabel.AutoSize = True
            Me.VehicleCountLabel.Location = New System.Drawing.Point(89, 77)
            Me.VehicleCountLabel.Name = "VehicleCountLabel"
            Me.VehicleCountLabel.Size = New System.Drawing.Size(14, 13)
            Me.VehicleCountLabel.TabIndex = 13
            Me.VehicleCountLabel.Text = "#"
            '
            'PostButton
            '
            Me.PostButton.Location = New System.Drawing.Point(331, 96)
            Me.PostButton.Name = "PostButton"
            Me.PostButton.Size = New System.Drawing.Size(77, 21)
            Me.PostButton.TabIndex = 14
            Me.PostButton.Text = "Post Images"
            Me.PostButton.UseVisualStyleBackColor = True
            '
            'ReviewButton
            '
            Me.ReviewButton.Location = New System.Drawing.Point(109, 96)
            Me.ReviewButton.Name = "ReviewButton"
            Me.ReviewButton.Size = New System.Drawing.Size(89, 20)
            Me.ReviewButton.TabIndex = 15
            Me.ReviewButton.Text = "Review Images"
            Me.ReviewButton.UseVisualStyleBackColor = True
            '
            'ProgressPanel
            '
            Me.ProgressPanel.Controls.Add(Me.progressLabel)
            Me.ProgressPanel.Controls.Add(Me.imageProgressBar)
            Me.ProgressPanel.Location = New System.Drawing.Point(6, 122)
            Me.ProgressPanel.Name = "ProgressPanel"
            Me.ProgressPanel.Size = New System.Drawing.Size(402, 27)
            Me.ProgressPanel.TabIndex = 16
            '
            'progressLabel
            '
            Me.progressLabel.AutoSize = True
            Me.progressLabel.Location = New System.Drawing.Point(2, 9)
            Me.progressLabel.Name = "progressLabel"
            Me.progressLabel.Size = New System.Drawing.Size(105, 13)
            Me.progressLabel.TabIndex = 11
            Me.progressLabel.Text = "Processing Images..."
            '
            'imageProgressBar
            '
            Me.imageProgressBar.Location = New System.Drawing.Point(113, 9)
            Me.imageProgressBar.Name = "imageProgressBar"
            Me.imageProgressBar.Size = New System.Drawing.Size(285, 13)
            Me.imageProgressBar.TabIndex = 10
            '
            'RotateComboBox
            '
            Me.RotateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.RotateComboBox.FormattingEnabled = True
            Me.RotateComboBox.Location = New System.Drawing.Point(252, 97)
            Me.RotateComboBox.Name = "RotateComboBox"
            Me.RotateComboBox.Size = New System.Drawing.Size(68, 21)
            Me.RotateComboBox.TabIndex = 17
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(204, 100)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(42, 13)
            Me.Label3.TabIndex = 18
            Me.Label3.Text = "Rotate:"
            '
            'RecountButton
            '
            Me.RecountButton.Enabled = False
            Me.RecountButton.Location = New System.Drawing.Point(13, 96)
            Me.RecountButton.Name = "RecountButton"
            Me.RecountButton.Size = New System.Drawing.Size(89, 20)
            Me.RecountButton.TabIndex = 19
            Me.RecountButton.Text = "Recount"
            Me.RecountButton.UseVisualStyleBackColor = True
            '
            'LocationComboBox
            '
            Me.LocationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.LocationComboBox.FormattingEnabled = True
            Me.LocationComboBox.Location = New System.Drawing.Point(252, 66)
            Me.LocationComboBox.Name = "LocationComboBox"
            Me.LocationComboBox.Size = New System.Drawing.Size(69, 21)
            Me.LocationComboBox.TabIndex = 20
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(198, 74)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(51, 13)
            Me.Label4.TabIndex = 21
            Me.Label4.Text = "Location:"
            '
            'BatchPostButton
            '
            Me.BatchPostButton.Location = New System.Drawing.Point(331, 66)
            Me.BatchPostButton.Name = "BatchPostButton"
            Me.BatchPostButton.Size = New System.Drawing.Size(75, 23)
            Me.BatchPostButton.TabIndex = 22
            Me.BatchPostButton.Text = "Batch Post"
            Me.BatchPostButton.UseVisualStyleBackColor = True
            '
            'ScanTrackerRemoteQCForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(420, 155)
            Me.Controls.Add(Me.BatchPostButton)
            Me.Controls.Add(Me.Label4)
            Me.Controls.Add(Me.LocationComboBox)
            Me.Controls.Add(Me.RecountButton)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.RotateComboBox)
            Me.Controls.Add(Me.ReviewButton)
            Me.Controls.Add(Me.PostButton)
            Me.Controls.Add(Me.VehicleCountLabel)
            Me.Controls.Add(Me.Label5)
            Me.Controls.Add(Me.ImageCountLabel)
            Me.Controls.Add(Me.Label6)
            Me.Controls.Add(Me.DestinationLabel)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.BrowseButton)
            Me.Controls.Add(Me.SourceTextBox)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.ProgressPanel)
            Me.Name = "ScanTrackerRemoteQCForm"
            Me.StatusMessage = ""
            Me.Text = "ScanTracker Remote QC"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ProgressPanel.ResumeLayout(False)
            Me.ProgressPanel.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SourceTextBox As System.Windows.Forms.TextBox
    Friend WithEvents BrowseButton As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DestinationLabel As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ImageCountLabel As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents VehicleCountLabel As System.Windows.Forms.Label
    Friend WithEvents PostButton As System.Windows.Forms.Button
    Friend WithEvents ReviewButton As System.Windows.Forms.Button
    Friend WithEvents ProgressPanel As System.Windows.Forms.Panel
    Friend WithEvents progressLabel As System.Windows.Forms.Label
    Friend WithEvents imageProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents RotateComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RecountButton As System.Windows.Forms.Button
    Friend WithEvents LocationComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BatchPostButton As System.Windows.Forms.Button
    End Class
End Namespace