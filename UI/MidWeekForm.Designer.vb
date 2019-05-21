<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MidWeekForm
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
        Me.SelectOpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.PreviousButton = New System.Windows.Forms.Button()
        Me.NextButton = New System.Windows.Forms.Button()
        Me.MidWeekTabControl = New System.Windows.Forms.TabControl()
        Me.PathTabPage = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SelectButton = New System.Windows.Forms.Button()
        Me.PathTextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LoadTabPage = New System.Windows.Forms.TabPage()
        Me.MWDataGridView = New System.Windows.Forms.DataGridView()
        Me.ErrorPanel = New System.Windows.Forms.Panel()
        Me.btnRemovRow = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.ErrorTextBox = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.ReloadButton = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ValidationResultTextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ValidationButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ImagePathButton = New System.Windows.Forms.Button()
        Me.ImagePathTextBox = New System.Windows.Forms.TextBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ResultTextBox = New System.Windows.Forms.TextBox()
        Me.ProcessButton = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ResultTextBoxFad = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CopyMWAdsButton = New System.Windows.Forms.Button()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PathFolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.Panel1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.MidWeekTabControl.SuspendLayout()
        Me.PathTabPage.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.LoadTabPage.SuspendLayout()
        CType(Me.MWDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ErrorPanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'SelectOpenFileDialog
        '
        Me.SelectOpenFileDialog.FileName = "OpenFileDialog1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 615)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(946, 32)
        Me.Panel1.TabIndex = 4
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.PreviousButton)
        Me.Panel8.Controls.Add(Me.NextButton)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel8.Location = New System.Drawing.Point(759, 0)
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
        'MidWeekTabControl
        '
        Me.MidWeekTabControl.Controls.Add(Me.PathTabPage)
        Me.MidWeekTabControl.Controls.Add(Me.LoadTabPage)
        Me.MidWeekTabControl.Controls.Add(Me.TabPage2)
        Me.MidWeekTabControl.Controls.Add(Me.TabPage1)
        Me.MidWeekTabControl.Controls.Add(Me.TabPage3)
        Me.MidWeekTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MidWeekTabControl.Location = New System.Drawing.Point(0, 0)
        Me.MidWeekTabControl.Name = "MidWeekTabControl"
        Me.MidWeekTabControl.SelectedIndex = 0
        Me.MidWeekTabControl.Size = New System.Drawing.Size(946, 615)
        Me.MidWeekTabControl.TabIndex = 5
        '
        'PathTabPage
        '
        Me.PathTabPage.Controls.Add(Me.Panel3)
        Me.PathTabPage.Controls.Add(Me.Label4)
        Me.PathTabPage.Location = New System.Drawing.Point(4, 22)
        Me.PathTabPage.Name = "PathTabPage"
        Me.PathTabPage.Size = New System.Drawing.Size(938, 589)
        Me.PathTabPage.TabIndex = 3
        Me.PathTabPage.Text = "Step 1"
        Me.PathTabPage.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.SelectButton)
        Me.Panel3.Controls.Add(Me.PathTextBox)
        Me.Panel3.Location = New System.Drawing.Point(64, 233)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(820, 153)
        Me.Panel3.TabIndex = 9
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
        Me.Label4.Size = New System.Drawing.Size(239, 31)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Mid - Week Flash"
        '
        'LoadTabPage
        '
        Me.LoadTabPage.Controls.Add(Me.MWDataGridView)
        Me.LoadTabPage.Controls.Add(Me.ErrorPanel)
        Me.LoadTabPage.Controls.Add(Me.Panel2)
        Me.LoadTabPage.Location = New System.Drawing.Point(4, 22)
        Me.LoadTabPage.Name = "LoadTabPage"
        Me.LoadTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.LoadTabPage.Size = New System.Drawing.Size(938, 589)
        Me.LoadTabPage.TabIndex = 0
        Me.LoadTabPage.Text = "Step 2"
        Me.LoadTabPage.UseVisualStyleBackColor = True
        '
        'MWDataGridView
        '
        Me.MWDataGridView.AllowUserToAddRows = False
        Me.MWDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MWDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MWDataGridView.Location = New System.Drawing.Point(3, 40)
        Me.MWDataGridView.Name = "MWDataGridView"
        Me.MWDataGridView.Size = New System.Drawing.Size(932, 424)
        Me.MWDataGridView.TabIndex = 5
        '
        'ErrorPanel
        '
        Me.ErrorPanel.Controls.Add(Me.btnRemovRow)
        Me.ErrorPanel.Controls.Add(Me.Label8)
        Me.ErrorPanel.Controls.Add(Me.CloseButton)
        Me.ErrorPanel.Controls.Add(Me.ErrorTextBox)
        Me.ErrorPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ErrorPanel.Location = New System.Drawing.Point(3, 464)
        Me.ErrorPanel.Name = "ErrorPanel"
        Me.ErrorPanel.Size = New System.Drawing.Size(932, 122)
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
        Me.ErrorTextBox.Size = New System.Drawing.Size(920, 89)
        Me.ErrorTextBox.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(932, 37)
        Me.Panel2.TabIndex = 2
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.ReloadButton)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(834, 0)
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
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ValidationResultTextBox)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Panel4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(938, 589)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Step 3"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ValidationResultTextBox
        '
        Me.ValidationResultTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ValidationResultTextBox.Location = New System.Drawing.Point(54, 197)
        Me.ValidationResultTextBox.Multiline = True
        Me.ValidationResultTextBox.Name = "ValidationResultTextBox"
        Me.ValidationResultTextBox.ReadOnly = True
        Me.ValidationResultTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ValidationResultTextBox.Size = New System.Drawing.Size(820, 368)
        Me.ValidationResultTextBox.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(51, 181)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Output :"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.ValidationButton)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.ImagePathButton)
        Me.Panel4.Controls.Add(Me.ImagePathTextBox)
        Me.Panel4.Location = New System.Drawing.Point(54, 15)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(820, 155)
        Me.Panel4.TabIndex = 10
        '
        'ValidationButton
        '
        Me.ValidationButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ValidationButton.Enabled = False
        Me.ValidationButton.Location = New System.Drawing.Point(673, 116)
        Me.ValidationButton.Name = "ValidationButton"
        Me.ValidationButton.Size = New System.Drawing.Size(115, 23)
        Me.ValidationButton.TabIndex = 13
        Me.ValidationButton.Text = "Validate"
        Me.ValidationButton.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(158, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Please select the path of image."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(36, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Image Path :"
        '
        'ImagePathButton
        '
        Me.ImagePathButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImagePathButton.Location = New System.Drawing.Point(713, 76)
        Me.ImagePathButton.Name = "ImagePathButton"
        Me.ImagePathButton.Size = New System.Drawing.Size(75, 23)
        Me.ImagePathButton.TabIndex = 10
        Me.ImagePathButton.Text = "Select File"
        Me.ImagePathButton.UseVisualStyleBackColor = True
        '
        'ImagePathTextBox
        '
        Me.ImagePathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ImagePathTextBox.Enabled = False
        Me.ImagePathTextBox.Location = New System.Drawing.Point(39, 77)
        Me.ImagePathTextBox.Name = "ImagePathTextBox"
        Me.ImagePathTextBox.Size = New System.Drawing.Size(674, 20)
        Me.ImagePathTextBox.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Panel5)
        Me.TabPage1.Controls.Add(Me.ProcessButton)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(938, 589)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Step 4"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 569)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(298, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Click ""Start Process"" to Create Envelope, Vehicle and Pages."
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
        'ProcessButton
        '
        Me.ProcessButton.Location = New System.Drawing.Point(782, 559)
        Me.ProcessButton.Name = "ProcessButton"
        Me.ProcessButton.Size = New System.Drawing.Size(139, 23)
        Me.ProcessButton.TabIndex = 3
        Me.ProcessButton.Text = "Start Process"
        Me.ProcessButton.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel7)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(938, 589)
        Me.TabPage3.TabIndex = 4
        Me.TabPage3.Text = "Final"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.ResultTextBoxFad)
        Me.Panel7.Controls.Add(Me.Label11)
        Me.Panel7.Controls.Add(Me.CopyMWAdsButton)
        Me.Panel7.Controls.Add(Me.StatusLabel)
        Me.Panel7.Controls.Add(Me.Label10)
        Me.Panel7.Location = New System.Drawing.Point(17, 30)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(904, 537)
        Me.Panel7.TabIndex = 19
        '
        'ResultTextBoxFad
        '
        Me.ResultTextBoxFad.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ResultTextBoxFad.Location = New System.Drawing.Point(43, 91)
        Me.ResultTextBoxFad.Multiline = True
        Me.ResultTextBoxFad.Name = "ResultTextBoxFad"
        Me.ResultTextBoxFad.ReadOnly = True
        Me.ResultTextBoxFad.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ResultTextBoxFad.Size = New System.Drawing.Size(820, 356)
        Me.ResultTextBoxFad.TabIndex = 21
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(40, 75)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Output :"
        '
        'CopyMWAdsButton
        '
        Me.CopyMWAdsButton.Location = New System.Drawing.Point(606, 453)
        Me.CopyMWAdsButton.Name = "CopyMWAdsButton"
        Me.CopyMWAdsButton.Size = New System.Drawing.Size(257, 58)
        Me.CopyMWAdsButton.TabIndex = 19
        Me.CopyMWAdsButton.Text = "Copy to MW Flash Ads"
        Me.CopyMWAdsButton.UseVisualStyleBackColor = True
        '
        'StatusLabel
        '
        Me.StatusLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusLabel.Location = New System.Drawing.Point(-1, 514)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(904, 21)
        Me.StatusLabel.TabIndex = 19
        Me.StatusLabel.Text = "[Status]"
        Me.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.StatusLabel.Visible = False
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(9, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(903, 21)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Click ""Copy to MW Flash Ads"" to  copy the data going into FlashAdsMW table."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MidWeekForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 647)
        Me.Controls.Add(Me.MidWeekTabControl)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "MidWeekForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MidWeekForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.MidWeekTabControl.ResumeLayout(False)
        Me.PathTabPage.ResumeLayout(False)
        Me.PathTabPage.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.LoadTabPage.ResumeLayout(False)
        CType(Me.MWDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ErrorPanel.ResumeLayout(False)
        Me.ErrorPanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SelectOpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MidWeekTabControl As System.Windows.Forms.TabControl
    Friend WithEvents LoadTabPage As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PathTabPage As System.Windows.Forms.TabPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SelectButton As System.Windows.Forms.Button
    Friend WithEvents PathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ImagePathButton As System.Windows.Forms.Button
    Friend WithEvents ImagePathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ValidationButton As System.Windows.Forms.Button
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents NextButton As System.Windows.Forms.Button
    Friend WithEvents PathFolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ValidationResultTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ProcessButton As System.Windows.Forms.Button
    Friend WithEvents ResultTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ErrorPanel As System.Windows.Forms.Panel
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents ErrorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents MWDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents PreviousButton As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents ReloadButton As System.Windows.Forms.Button
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents CopyMWAdsButton As System.Windows.Forms.Button
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ResultTextBoxFad As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnRemovRow As System.Windows.Forms.Button
End Class
