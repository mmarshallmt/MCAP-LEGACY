<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class newExpectationForm
    Inherits MCAP.UI.MDIChildFormBase

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(newExpectationForm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.FrequencyComboBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DPICombobox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.commentsTextBox = New System.Windows.Forms.TextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnCreateExpectation = New System.Windows.Forms.Button()
        Me.aDlertCheckBox = New System.Windows.Forms.CheckBox()
        Me.fVCheckBox = New System.Windows.Forms.CheckBox()
        Me.priorityCombobox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.commentsLabel = New System.Windows.Forms.Label()
        Me.mediaComboBox = New System.Windows.Forms.ComboBox()
        Me.mediaLabel = New System.Windows.Forms.Label()
        Me.retailerComboBox = New System.Windows.Forms.ComboBox()
        Me.retailerLabel = New System.Windows.Forms.Label()
        Me.marketComboBox = New System.Windows.Forms.ComboBox()
        Me.marketLabel = New System.Windows.Forms.Label()
        CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'smalliconImageList
        '
        Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
        Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
        Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FrequencyComboBox)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DPICombobox)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.commentsTextBox)
        Me.GroupBox1.Controls.Add(Me.btnClear)
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Controls.Add(Me.btnCreateExpectation)
        Me.GroupBox1.Controls.Add(Me.aDlertCheckBox)
        Me.GroupBox1.Controls.Add(Me.fVCheckBox)
        Me.GroupBox1.Controls.Add(Me.priorityCombobox)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.commentsLabel)
        Me.GroupBox1.Controls.Add(Me.mediaComboBox)
        Me.GroupBox1.Controls.Add(Me.mediaLabel)
        Me.GroupBox1.Controls.Add(Me.retailerComboBox)
        Me.GroupBox1.Controls.Add(Me.retailerLabel)
        Me.GroupBox1.Controls.Add(Me.marketComboBox)
        Me.GroupBox1.Controls.Add(Me.marketLabel)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(555, 390)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Create Expectation"
        '
        'FrequencyComboBox
        '
        Me.FrequencyComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.FrequencyComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.FrequencyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.FrequencyComboBox.FormattingEnabled = True
        Me.FrequencyComboBox.Location = New System.Drawing.Point(104, 173)
        Me.FrequencyComboBox.Name = "FrequencyComboBox"
        Me.FrequencyComboBox.Size = New System.Drawing.Size(289, 21)
        Me.FrequencyComboBox.TabIndex = 41
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(33, 171)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Frequency"
        '
        'DPICombobox
        '
        Me.DPICombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.DPICombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DPICombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DPICombobox.FormattingEnabled = True
        Me.DPICombobox.Location = New System.Drawing.Point(104, 146)
        Me.DPICombobox.Name = "DPICombobox"
        Me.DPICombobox.Size = New System.Drawing.Size(289, 21)
        Me.DPICombobox.TabIndex = 39
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Assign DPI"
        '
        'commentsTextBox
        '
        Me.commentsTextBox.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.commentsTextBox.Location = New System.Drawing.Point(106, 250)
        Me.commentsTextBox.Multiline = True
        Me.commentsTextBox.Name = "commentsTextBox"
        Me.commentsTextBox.Size = New System.Drawing.Size(289, 83)
        Me.commentsTextBox.TabIndex = 38
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(317, 349)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(101, 24)
        Me.btnClear.TabIndex = 9
        Me.btnClear.Text = "C&lear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(424, 349)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(101, 24)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "Cl&ose"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnCreateExpectation
        '
        Me.btnCreateExpectation.Location = New System.Drawing.Point(36, 349)
        Me.btnCreateExpectation.Name = "btnCreateExpectation"
        Me.btnCreateExpectation.Size = New System.Drawing.Size(162, 24)
        Me.btnCreateExpectation.TabIndex = 8
        Me.btnCreateExpectation.Text = "Create Expectation"
        Me.btnCreateExpectation.UseVisualStyleBackColor = True
        '
        'aDlertCheckBox
        '
        Me.aDlertCheckBox.AutoSize = True
        Me.aDlertCheckBox.Location = New System.Drawing.Point(104, 224)
        Me.aDlertCheckBox.Name = "aDlertCheckBox"
        Me.aDlertCheckBox.Size = New System.Drawing.Size(97, 17)
        Me.aDlertCheckBox.TabIndex = 6
        Me.aDlertCheckBox.Text = "Durable/ADlert"
        Me.aDlertCheckBox.UseVisualStyleBackColor = True
        '
        'fVCheckBox
        '
        Me.fVCheckBox.AutoSize = True
        Me.fVCheckBox.Location = New System.Drawing.Point(104, 201)
        Me.fVCheckBox.Name = "fVCheckBox"
        Me.fVCheckBox.Size = New System.Drawing.Size(102, 17)
        Me.fVCheckBox.TabIndex = 5
        Me.fVCheckBox.Text = "Consumable/FV"
        Me.fVCheckBox.UseVisualStyleBackColor = True
        '
        'priorityCombobox
        '
        Me.priorityCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.priorityCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.priorityCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.priorityCombobox.FormattingEnabled = True
        Me.priorityCombobox.Location = New System.Drawing.Point(104, 119)
        Me.priorityCombobox.Name = "priorityCombobox"
        Me.priorityCombobox.Size = New System.Drawing.Size(289, 21)
        Me.priorityCombobox.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(52, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "&Priority"
        '
        'commentsLabel
        '
        Me.commentsLabel.AutoSize = True
        Me.commentsLabel.Location = New System.Drawing.Point(34, 250)
        Me.commentsLabel.Name = "commentsLabel"
        Me.commentsLabel.Size = New System.Drawing.Size(56, 13)
        Me.commentsLabel.TabIndex = 35
        Me.commentsLabel.Text = "Comments"
        '
        'mediaComboBox
        '
        Me.mediaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.mediaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.mediaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.mediaComboBox.FormattingEnabled = True
        Me.mediaComboBox.Items.AddRange(New Object() {"--select--"})
        Me.mediaComboBox.Location = New System.Drawing.Point(104, 38)
        Me.mediaComboBox.Name = "mediaComboBox"
        Me.mediaComboBox.Size = New System.Drawing.Size(289, 21)
        Me.mediaComboBox.TabIndex = 1
        '
        'mediaLabel
        '
        Me.mediaLabel.AutoSize = True
        Me.mediaLabel.Location = New System.Drawing.Point(54, 41)
        Me.mediaLabel.Name = "mediaLabel"
        Me.mediaLabel.Size = New System.Drawing.Size(36, 13)
        Me.mediaLabel.TabIndex = 29
        Me.mediaLabel.Text = "Me&dia"
        '
        'retailerComboBox
        '
        Me.retailerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.retailerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.retailerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.retailerComboBox.FormattingEnabled = True
        Me.retailerComboBox.Location = New System.Drawing.Point(104, 92)
        Me.retailerComboBox.Name = "retailerComboBox"
        Me.retailerComboBox.Size = New System.Drawing.Size(289, 21)
        Me.retailerComboBox.TabIndex = 3
        '
        'retailerLabel
        '
        Me.retailerLabel.AutoSize = True
        Me.retailerLabel.Location = New System.Drawing.Point(47, 93)
        Me.retailerLabel.Name = "retailerLabel"
        Me.retailerLabel.Size = New System.Drawing.Size(43, 13)
        Me.retailerLabel.TabIndex = 33
        Me.retailerLabel.Text = "&Retailer"
        '
        'marketComboBox
        '
        Me.marketComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.marketComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.marketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.marketComboBox.FormattingEnabled = True
        Me.marketComboBox.Location = New System.Drawing.Point(104, 65)
        Me.marketComboBox.Name = "marketComboBox"
        Me.marketComboBox.Size = New System.Drawing.Size(289, 21)
        Me.marketComboBox.TabIndex = 2
        '
        'marketLabel
        '
        Me.marketLabel.AutoSize = True
        Me.marketLabel.Location = New System.Drawing.Point(50, 67)
        Me.marketLabel.Name = "marketLabel"
        Me.marketLabel.Size = New System.Drawing.Size(40, 13)
        Me.marketLabel.TabIndex = 31
        Me.marketLabel.Text = "&Market"
        '
        'newExpectationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 409)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "newExpectationForm"
        Me.StatusMessage = ""
        Me.Text = "New Expectation Form"
        CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents aDlertCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents fVCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents priorityCombobox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents commentsLabel As System.Windows.Forms.Label
    Friend WithEvents mediaComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents mediaLabel As System.Windows.Forms.Label
    Friend WithEvents retailerComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents retailerLabel As System.Windows.Forms.Label
    Friend WithEvents marketComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents marketLabel As System.Windows.Forms.Label
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnCreateExpectation As System.Windows.Forms.Button
    Friend WithEvents commentsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FrequencyComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DPICombobox As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
