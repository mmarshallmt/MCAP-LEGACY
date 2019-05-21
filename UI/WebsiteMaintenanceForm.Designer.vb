Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class WebsiteMaintenanceForm
        Inherits MDIChildFormBase

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WebsiteMaintenanceForm))
            Me.PathFolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Panel8 = New System.Windows.Forms.Panel()
            Me.PreviousButton = New System.Windows.Forms.Button()
            Me.NextButton = New System.Windows.Forms.Button()
            Me.SelectOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.Panel5 = New System.Windows.Forms.Panel()
            Me.ResultTextBox = New System.Windows.Forms.TextBox()
            Me.LoadTabPage = New System.Windows.Forms.TabPage()
            Me.websiteDataGridView = New System.Windows.Forms.DataGridView()
            Me.ErrorPanel = New System.Windows.Forms.Panel()
            Me.btnRemovRow = New System.Windows.Forms.Button()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.CloseButton = New System.Windows.Forms.Button()
            Me.ErrorTextBox = New System.Windows.Forms.TextBox()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.Panel6 = New System.Windows.Forms.Panel()
            Me.ReloadButton = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.PathTabPage = New System.Windows.Forms.TabPage()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.wkLabel = New System.Windows.Forms.Label()
            Me.workSheetComboBox = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.SelectButton = New System.Windows.Forms.Button()
            Me.PathTextBox = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.WebsiteTabControl = New System.Windows.Forms.TabControl()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.Panel8.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.Panel5.SuspendLayout()
            Me.LoadTabPage.SuspendLayout()
            CType(Me.websiteDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ErrorPanel.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.Panel6.SuspendLayout()
            Me.PathTabPage.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.WebsiteTabControl.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.Panel8)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 628)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(1000, 32)
            Me.Panel1.TabIndex = 8
            '
            'Panel8
            '
            Me.Panel8.Controls.Add(Me.PreviousButton)
            Me.Panel8.Controls.Add(Me.NextButton)
            Me.Panel8.Dock = System.Windows.Forms.DockStyle.Right
            Me.Panel8.Location = New System.Drawing.Point(813, 0)
            Me.Panel8.Name = "Panel8"
            Me.Panel8.Size = New System.Drawing.Size(187, 32)
            Me.Panel8.TabIndex = 1
            '
            'PreviousButton
            '
            Me.PreviousButton.Enabled = False
            Me.PreviousButton.Location = New System.Drawing.Point(5, 6)
            Me.PreviousButton.Name = "PreviousButton"
            Me.PreviousButton.Size = New System.Drawing.Size(86, 23)
            Me.PreviousButton.TabIndex = 2
            Me.PreviousButton.Text = "Previous"
            Me.PreviousButton.UseVisualStyleBackColor = True
            '
            'NextButton
            '
            Me.NextButton.Enabled = False
            Me.NextButton.Location = New System.Drawing.Point(96, 6)
            Me.NextButton.Name = "NextButton"
            Me.NextButton.Size = New System.Drawing.Size(86, 23)
            Me.NextButton.TabIndex = 1
            Me.NextButton.Text = "Next"
            Me.NextButton.UseVisualStyleBackColor = True
            '
            'SelectOpenFileDialog
            '
            Me.SelectOpenFileDialog.FileName = "OpenFileDialog1"
            '
            'TabPage1
            '
            Me.TabPage1.Controls.Add(Me.Panel5)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.TabPage1.Size = New System.Drawing.Size(992, 634)
            Me.TabPage1.TabIndex = 2
            Me.TabPage1.Text = "Step 3"
            Me.TabPage1.UseVisualStyleBackColor = True
            '
            'Panel5
            '
            Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel5.Controls.Add(Me.ResultTextBox)
            Me.Panel5.Location = New System.Drawing.Point(17, 16)
            Me.Panel5.Name = "Panel5"
            Me.Panel5.Size = New System.Drawing.Size(904, 537)
            Me.Panel5.TabIndex = 17
            '
            'ResultTextBox
            '
            Me.ResultTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
            Me.ResultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.ResultTextBox.Location = New System.Drawing.Point(15, 16)
            Me.ResultTextBox.Multiline = True
            Me.ResultTextBox.Name = "ResultTextBox"
            Me.ResultTextBox.ReadOnly = True
            Me.ResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.ResultTextBox.Size = New System.Drawing.Size(875, 507)
            Me.ResultTextBox.TabIndex = 16
            '
            'LoadTabPage
            '
            Me.LoadTabPage.Controls.Add(Me.websiteDataGridView)
            Me.LoadTabPage.Controls.Add(Me.ErrorPanel)
            Me.LoadTabPage.Controls.Add(Me.Panel2)
            Me.LoadTabPage.Location = New System.Drawing.Point(4, 22)
            Me.LoadTabPage.Name = "LoadTabPage"
            Me.LoadTabPage.Padding = New System.Windows.Forms.Padding(3)
            Me.LoadTabPage.Size = New System.Drawing.Size(992, 634)
            Me.LoadTabPage.TabIndex = 0
            Me.LoadTabPage.Text = "Step 2"
            Me.LoadTabPage.UseVisualStyleBackColor = True
            '
            'websiteDataGridView
            '
            Me.websiteDataGridView.AllowUserToAddRows = False
            Me.websiteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.websiteDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.websiteDataGridView.Location = New System.Drawing.Point(3, 40)
            Me.websiteDataGridView.Name = "websiteDataGridView"
            Me.websiteDataGridView.Size = New System.Drawing.Size(986, 469)
            Me.websiteDataGridView.TabIndex = 5
            '
            'ErrorPanel
            '
            Me.ErrorPanel.Controls.Add(Me.btnRemovRow)
            Me.ErrorPanel.Controls.Add(Me.Label8)
            Me.ErrorPanel.Controls.Add(Me.CloseButton)
            Me.ErrorPanel.Controls.Add(Me.ErrorTextBox)
            Me.ErrorPanel.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.ErrorPanel.Location = New System.Drawing.Point(3, 509)
            Me.ErrorPanel.Name = "ErrorPanel"
            Me.ErrorPanel.Size = New System.Drawing.Size(986, 122)
            Me.ErrorPanel.TabIndex = 4
            '
            'btnRemovRow
            '
            Me.btnRemovRow.Location = New System.Drawing.Point(757, 3)
            Me.btnRemovRow.Name = "btnRemovRow"
            Me.btnRemovRow.Size = New System.Drawing.Size(169, 23)
            Me.btnRemovRow.TabIndex = 16
            Me.btnRemovRow.Text = "Remove Selected Row"
            Me.btnRemovRow.UseVisualStyleBackColor = True
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(7, 8)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(46, 13)
            Me.Label8.TabIndex = 15
            Me.Label8.Text = "Error(s) :"
            '
            'CloseButton
            '
            Me.CloseButton.Location = New System.Drawing.Point(364, 349)
            Me.CloseButton.Name = "CloseButton"
            Me.CloseButton.Size = New System.Drawing.Size(75, 23)
            Me.CloseButton.TabIndex = 1
            Me.CloseButton.Text = "Close"
            Me.CloseButton.UseVisualStyleBackColor = True
            '
            'ErrorTextBox
            '
            Me.ErrorTextBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ErrorTextBox.Location = New System.Drawing.Point(7, 29)
            Me.ErrorTextBox.MaxLength = 1000000
            Me.ErrorTextBox.Multiline = True
            Me.ErrorTextBox.Name = "ErrorTextBox"
            Me.ErrorTextBox.ReadOnly = True
            Me.ErrorTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.ErrorTextBox.Size = New System.Drawing.Size(974, 62)
            Me.ErrorTextBox.TabIndex = 0
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.Panel6)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel2.Location = New System.Drawing.Point(3, 3)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(986, 37)
            Me.Panel2.TabIndex = 2
            '
            'Panel6
            '
            Me.Panel6.Controls.Add(Me.ReloadButton)
            Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
            Me.Panel6.Location = New System.Drawing.Point(888, 0)
            Me.Panel6.Name = "Panel6"
            Me.Panel6.Size = New System.Drawing.Size(98, 37)
            Me.Panel6.TabIndex = 1
            '
            'ReloadButton
            '
            Me.ReloadButton.Location = New System.Drawing.Point(6, 7)
            Me.ReloadButton.Name = "ReloadButton"
            Me.ReloadButton.Size = New System.Drawing.Size(86, 23)
            Me.ReloadButton.TabIndex = 2
            Me.ReloadButton.Text = "Reload"
            Me.ReloadButton.UseVisualStyleBackColor = True
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(13, 13)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(226, 13)
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "Click next to import the data into the database."
            '
            'PathTabPage
            '
            Me.PathTabPage.Controls.Add(Me.Panel3)
            Me.PathTabPage.Controls.Add(Me.Label4)
            Me.PathTabPage.Location = New System.Drawing.Point(4, 22)
            Me.PathTabPage.Name = "PathTabPage"
            Me.PathTabPage.Size = New System.Drawing.Size(992, 634)
            Me.PathTabPage.TabIndex = 3
            Me.PathTabPage.Text = "Step 1"
            Me.PathTabPage.UseVisualStyleBackColor = True
            '
            'Panel3
            '
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel3.Controls.Add(Me.wkLabel)
            Me.Panel3.Controls.Add(Me.workSheetComboBox)
            Me.Panel3.Controls.Add(Me.Label1)
            Me.Panel3.Controls.Add(Me.Label5)
            Me.Panel3.Controls.Add(Me.SelectButton)
            Me.Panel3.Controls.Add(Me.PathTextBox)
            Me.Panel3.Location = New System.Drawing.Point(64, 233)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(820, 267)
            Me.Panel3.TabIndex = 9
            '
            'wkLabel
            '
            Me.wkLabel.AutoSize = True
            Me.wkLabel.Location = New System.Drawing.Point(36, 146)
            Me.wkLabel.Name = "wkLabel"
            Me.wkLabel.Size = New System.Drawing.Size(101, 13)
            Me.wkLabel.TabIndex = 14
            Me.wkLabel.Text = "Select  Worksheet :"
            Me.wkLabel.Visible = False
            '
            'workSheetComboBox
            '
            Me.workSheetComboBox.FormattingEnabled = True
            Me.workSheetComboBox.Location = New System.Drawing.Point(39, 162)
            Me.workSheetComboBox.Name = "workSheetComboBox"
            Me.workSheetComboBox.Size = New System.Drawing.Size(385, 21)
            Me.workSheetComboBox.TabIndex = 13
            Me.workSheetComboBox.Visible = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(36, 24)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(245, 13)
            Me.Label1.TabIndex = 12
            Me.Label1.Text = "Please select the excel path that you want to load."
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(36, 62)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(83, 13)
            Me.Label5.TabIndex = 11
            Me.Label5.Text = "Excel File Path :"
            '
            'SelectButton
            '
            Me.SelectButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SelectButton.Location = New System.Drawing.Point(713, 76)
            Me.SelectButton.Name = "SelectButton"
            Me.SelectButton.Size = New System.Drawing.Size(75, 23)
            Me.SelectButton.TabIndex = 10
            Me.SelectButton.Text = "Select File"
            Me.SelectButton.UseVisualStyleBackColor = True
            '
            'PathTextBox
            '
            Me.PathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PathTextBox.Enabled = False
            Me.PathTextBox.Location = New System.Drawing.Point(39, 77)
            Me.PathTextBox.Name = "PathTextBox"
            Me.PathTextBox.Size = New System.Drawing.Size(674, 20)
            Me.PathTextBox.TabIndex = 9
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(340, 126)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(203, 31)
            Me.Label4.TabIndex = 6
            Me.Label4.Text = "Load Retailers"
            '
            'WebsiteTabControl
            '
            Me.WebsiteTabControl.Controls.Add(Me.PathTabPage)
            Me.WebsiteTabControl.Controls.Add(Me.LoadTabPage)
            Me.WebsiteTabControl.Controls.Add(Me.TabPage1)
            Me.WebsiteTabControl.Dock = System.Windows.Forms.DockStyle.Fill
            Me.WebsiteTabControl.Location = New System.Drawing.Point(0, 0)
            Me.WebsiteTabControl.Name = "WebsiteTabControl"
            Me.WebsiteTabControl.SelectedIndex = 0
            Me.WebsiteTabControl.Size = New System.Drawing.Size(1000, 660)
            Me.WebsiteTabControl.TabIndex = 9
            '
            'WebsiteMaintenanceForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1000, 660)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.WebsiteTabControl)
            Me.Name = "WebsiteMaintenanceForm"
            Me.StatusMessage = ""
            Me.Text = "WebsiteMaintenanceForm"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel8.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.Panel5.ResumeLayout(False)
            Me.Panel5.PerformLayout()
            Me.LoadTabPage.ResumeLayout(False)
            CType(Me.websiteDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ErrorPanel.ResumeLayout(False)
            Me.ErrorPanel.PerformLayout()
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            Me.Panel6.ResumeLayout(False)
            Me.PathTabPage.ResumeLayout(False)
            Me.PathTabPage.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.Panel3.PerformLayout()
            Me.WebsiteTabControl.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PathFolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel8 As System.Windows.Forms.Panel
        Friend WithEvents PreviousButton As System.Windows.Forms.Button
        Friend WithEvents NextButton As System.Windows.Forms.Button
        Friend WithEvents SelectOpenFileDialog As System.Windows.Forms.OpenFileDialog
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents Panel5 As System.Windows.Forms.Panel
        Friend WithEvents ResultTextBox As System.Windows.Forms.TextBox
        Friend WithEvents LoadTabPage As System.Windows.Forms.TabPage
        Friend WithEvents websiteDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents ErrorPanel As System.Windows.Forms.Panel
        Friend WithEvents btnRemovRow As System.Windows.Forms.Button
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents CloseButton As System.Windows.Forms.Button
        Friend WithEvents ErrorTextBox As System.Windows.Forms.TextBox
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Panel6 As System.Windows.Forms.Panel
        Friend WithEvents ReloadButton As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents PathTabPage As System.Windows.Forms.TabPage
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents SelectButton As System.Windows.Forms.Button
        Friend WithEvents PathTextBox As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents WebsiteTabControl As System.Windows.Forms.TabControl
        Friend WithEvents wkLabel As System.Windows.Forms.Label
        Friend WithEvents workSheetComboBox As System.Windows.Forms.ComboBox
    End Class
End Namespace
