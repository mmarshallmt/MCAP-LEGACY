Namespace UI
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class NewRetailerForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewRetailerForm))
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.tradeClassComboBox = New System.Windows.Forms.ComboBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.MoveAllRightButton = New System.Windows.Forms.Button()
            Me.MoveLeftButton = New System.Windows.Forms.Button()
            Me.MoveRightButton = New System.Windows.Forms.Button()
            Me.MoveAllLeftButton = New System.Windows.Forms.Button()
            Me.RetailerLabel = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.searchRetailTextBox = New System.Windows.Forms.TextBox()
            Me.searchTextBox = New System.Windows.Forms.TextBox()
            Me.similarRetailerListBox = New System.Windows.Forms.ListBox()
            Me.selectRetailerListbox = New System.Windows.Forms.ListBox()
            Me.newRetailerListBox = New System.Windows.Forms.ListBox()
            Me.saveButton = New System.Windows.Forms.Button()
            Me.clearButton = New System.Windows.Forms.Button()
            Me.closeButton = New System.Windows.Forms.Button()
            Me.activeRetCheckBox = New System.Windows.Forms.CheckBox()
            Me.closeSimilarRetailerListBox = New System.Windows.Forms.ListBox()
            Me.closeSimilatLabel = New System.Windows.Forms.Label()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'TextBox1
            '
            Me.TextBox1.Enabled = False
            Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TextBox1.ForeColor = System.Drawing.Color.Red
            Me.TextBox1.Location = New System.Drawing.Point(392, 305)
            Me.TextBox1.Multiline = True
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(252, 173)
            Me.TextBox1.TabIndex = 35
            Me.TextBox1.Text = resources.GetString("TextBox1.Text")
            '
            'Label12
            '
            Me.Label12.AutoSize = True
            Me.Label12.Location = New System.Drawing.Point(321, 273)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(65, 13)
            Me.Label12.TabIndex = 34
            Me.Label12.Text = "Tradeclass :"
            '
            'tradeClassComboBox
            '
            Me.tradeClassComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.tradeClassComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.tradeClassComboBox.DisplayMember = "Descrip"
            Me.tradeClassComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.tradeClassComboBox.FormattingEnabled = True
            Me.tradeClassComboBox.Location = New System.Drawing.Point(392, 265)
            Me.tradeClassComboBox.Name = "tradeClassComboBox"
            Me.tradeClassComboBox.Size = New System.Drawing.Size(260, 21)
            Me.tradeClassComboBox.TabIndex = 33
            Me.tradeClassComboBox.ValueMember = "RetID"
            '
            'Label11
            '
            Me.Label11.AutoSize = True
            Me.Label11.Location = New System.Drawing.Point(32, 250)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(218, 13)
            Me.Label11.TabIndex = 32
            Me.Label11.Text = "Master Retailer to be entered in retailer table "
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(32, 28)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(111, 13)
            Me.Label3.TabIndex = 31
            Me.Label3.Text = "Unregistered Retailers"
            '
            'MoveAllRightButton
            '
            Me.MoveAllRightButton.Enabled = False
            Me.MoveAllRightButton.Location = New System.Drawing.Point(300, 152)
            Me.MoveAllRightButton.Name = "MoveAllRightButton"
            Me.MoveAllRightButton.Size = New System.Drawing.Size(86, 23)
            Me.MoveAllRightButton.TabIndex = 30
            Me.MoveAllRightButton.Text = "<<"
            Me.MoveAllRightButton.UseVisualStyleBackColor = True
            '
            'MoveLeftButton
            '
            Me.MoveLeftButton.Location = New System.Drawing.Point(300, 123)
            Me.MoveLeftButton.Name = "MoveLeftButton"
            Me.MoveLeftButton.Size = New System.Drawing.Size(86, 23)
            Me.MoveLeftButton.TabIndex = 29
            Me.MoveLeftButton.Text = "<"
            Me.MoveLeftButton.UseVisualStyleBackColor = True
            '
            'MoveRightButton
            '
            Me.MoveRightButton.Location = New System.Drawing.Point(300, 94)
            Me.MoveRightButton.Name = "MoveRightButton"
            Me.MoveRightButton.Size = New System.Drawing.Size(86, 23)
            Me.MoveRightButton.TabIndex = 28
            Me.MoveRightButton.Text = ">"
            Me.MoveRightButton.UseVisualStyleBackColor = True
            '
            'MoveAllLeftButton
            '
            Me.MoveAllLeftButton.Enabled = False
            Me.MoveAllLeftButton.Location = New System.Drawing.Point(300, 65)
            Me.MoveAllLeftButton.Name = "MoveAllLeftButton"
            Me.MoveAllLeftButton.Size = New System.Drawing.Size(86, 23)
            Me.MoveAllLeftButton.TabIndex = 27
            Me.MoveAllLeftButton.Text = ">>"
            Me.MoveAllLeftButton.UseVisualStyleBackColor = True
            '
            'RetailerLabel
            '
            Me.RetailerLabel.AutoSize = True
            Me.RetailerLabel.ForeColor = System.Drawing.Color.Red
            Me.RetailerLabel.Location = New System.Drawing.Point(32, 289)
            Me.RetailerLabel.Name = "RetailerLabel"
            Me.RetailerLabel.Size = New System.Drawing.Size(129, 13)
            Me.RetailerLabel.TabIndex = 26
            Me.RetailerLabel.Text = "Similar retailer was found. "
            Me.RetailerLabel.Visible = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.ForeColor = System.Drawing.Color.Red
            Me.Label1.Location = New System.Drawing.Point(389, 220)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(147, 13)
            Me.Label1.TabIndex = 25
            Me.Label1.Text = "Please select a master retailer"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(389, 28)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(99, 13)
            Me.Label2.TabIndex = 24
            Me.Label2.Text = "Selected Retailer(s)"
            '
            'searchRetailTextBox
            '
            Me.searchRetailTextBox.Location = New System.Drawing.Point(35, 266)
            Me.searchRetailTextBox.Name = "searchRetailTextBox"
            Me.searchRetailTextBox.Size = New System.Drawing.Size(252, 20)
            Me.searchRetailTextBox.TabIndex = 23
            '
            'searchTextBox
            '
            Me.searchTextBox.Location = New System.Drawing.Point(35, 5)
            Me.searchTextBox.Name = "searchTextBox"
            Me.searchTextBox.Size = New System.Drawing.Size(252, 20)
            Me.searchTextBox.TabIndex = 22
            '
            'similarRetailerListBox
            '
            Me.similarRetailerListBox.FormattingEnabled = True
            Me.similarRetailerListBox.Location = New System.Drawing.Point(35, 305)
            Me.similarRetailerListBox.Name = "similarRetailerListBox"
            Me.similarRetailerListBox.Size = New System.Drawing.Size(252, 173)
            Me.similarRetailerListBox.TabIndex = 21
            Me.similarRetailerListBox.Visible = False
            '
            'selectRetailerListbox
            '
            Me.selectRetailerListbox.FormattingEnabled = True
            Me.selectRetailerListbox.Location = New System.Drawing.Point(392, 44)
            Me.selectRetailerListbox.Name = "selectRetailerListbox"
            Me.selectRetailerListbox.Size = New System.Drawing.Size(252, 173)
            Me.selectRetailerListbox.TabIndex = 20
            '
            'newRetailerListBox
            '
            Me.newRetailerListBox.FormattingEnabled = True
            Me.newRetailerListBox.Location = New System.Drawing.Point(35, 44)
            Me.newRetailerListBox.Name = "newRetailerListBox"
            Me.newRetailerListBox.Size = New System.Drawing.Size(252, 173)
            Me.newRetailerListBox.TabIndex = 19
            '
            'saveButton
            '
            Me.saveButton.Location = New System.Drawing.Point(436, 495)
            Me.saveButton.Name = "saveButton"
            Me.saveButton.Size = New System.Drawing.Size(86, 23)
            Me.saveButton.TabIndex = 37
            Me.saveButton.Text = "Save"
            Me.saveButton.UseVisualStyleBackColor = True
            '
            'clearButton
            '
            Me.clearButton.Location = New System.Drawing.Point(344, 494)
            Me.clearButton.Name = "clearButton"
            Me.clearButton.Size = New System.Drawing.Size(86, 23)
            Me.clearButton.TabIndex = 36
            Me.clearButton.Text = "Clear"
            Me.clearButton.UseVisualStyleBackColor = True
            '
            'closeButton
            '
            Me.closeButton.Location = New System.Drawing.Point(566, 495)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(86, 23)
            Me.closeButton.TabIndex = 38
            Me.closeButton.Text = "Close"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'activeRetCheckBox
            '
            Me.activeRetCheckBox.AutoSize = True
            Me.activeRetCheckBox.Location = New System.Drawing.Point(35, 484)
            Me.activeRetCheckBox.Name = "activeRetCheckBox"
            Me.activeRetCheckBox.Size = New System.Drawing.Size(104, 17)
            Me.activeRetCheckBox.TabIndex = 40
            Me.activeRetCheckBox.Text = "Activate Retailer"
            Me.activeRetCheckBox.UseVisualStyleBackColor = True
            Me.activeRetCheckBox.Visible = False
            '
            'closeSimilarRetailerListBox
            '
            Me.closeSimilarRetailerListBox.FormattingEnabled = True
            Me.closeSimilarRetailerListBox.Location = New System.Drawing.Point(35, 305)
            Me.closeSimilarRetailerListBox.Name = "closeSimilarRetailerListBox"
            Me.closeSimilarRetailerListBox.Size = New System.Drawing.Size(252, 173)
            Me.closeSimilarRetailerListBox.TabIndex = 41
            Me.closeSimilarRetailerListBox.Visible = False
            '
            'closeSimilatLabel
            '
            Me.closeSimilatLabel.AutoSize = True
            Me.closeSimilatLabel.ForeColor = System.Drawing.Color.Red
            Me.closeSimilatLabel.Location = New System.Drawing.Point(32, 289)
            Me.closeSimilatLabel.Name = "closeSimilatLabel"
            Me.closeSimilatLabel.Size = New System.Drawing.Size(252, 13)
            Me.closeSimilatLabel.TabIndex = 42
            Me.closeSimilatLabel.Text = "Similar retailer(s) was found, and close in Ret table . "
            Me.closeSimilatLabel.Visible = False
            '
            'NewRetailerForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(685, 530)
            Me.Controls.Add(Me.closeSimilatLabel)
            Me.Controls.Add(Me.closeSimilarRetailerListBox)
            Me.Controls.Add(Me.activeRetCheckBox)
            Me.Controls.Add(Me.closeButton)
            Me.Controls.Add(Me.saveButton)
            Me.Controls.Add(Me.clearButton)
            Me.Controls.Add(Me.TextBox1)
            Me.Controls.Add(Me.Label12)
            Me.Controls.Add(Me.tradeClassComboBox)
            Me.Controls.Add(Me.Label11)
            Me.Controls.Add(Me.Label3)
            Me.Controls.Add(Me.MoveAllRightButton)
            Me.Controls.Add(Me.MoveLeftButton)
            Me.Controls.Add(Me.MoveRightButton)
            Me.Controls.Add(Me.MoveAllLeftButton)
            Me.Controls.Add(Me.RetailerLabel)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.searchRetailTextBox)
            Me.Controls.Add(Me.searchTextBox)
            Me.Controls.Add(Me.similarRetailerListBox)
            Me.Controls.Add(Me.selectRetailerListbox)
            Me.Controls.Add(Me.newRetailerListBox)
            Me.Name = "NewRetailerForm"
            Me.StatusMessage = ""
            Me.Text = "New Retailer"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents tradeClassComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents MoveAllRightButton As System.Windows.Forms.Button
        Friend WithEvents MoveLeftButton As System.Windows.Forms.Button
        Friend WithEvents MoveRightButton As System.Windows.Forms.Button
        Friend WithEvents MoveAllLeftButton As System.Windows.Forms.Button
        Friend WithEvents RetailerLabel As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents searchRetailTextBox As System.Windows.Forms.TextBox
        Friend WithEvents searchTextBox As System.Windows.Forms.TextBox
        Friend WithEvents similarRetailerListBox As System.Windows.Forms.ListBox
        Friend WithEvents selectRetailerListbox As System.Windows.Forms.ListBox
        Friend WithEvents newRetailerListBox As System.Windows.Forms.ListBox
        Friend WithEvents saveButton As System.Windows.Forms.Button
        Friend WithEvents clearButton As System.Windows.Forms.Button
        Friend WithEvents closeButton As System.Windows.Forms.Button
        Friend WithEvents activeRetCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents closeSimilarRetailerListBox As System.Windows.Forms.ListBox
        Friend WithEvents closeSimilatLabel As System.Windows.Forms.Label
    End Class
End Namespace
