Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class PublicationPullForm
    Inherits UI.MDIChildFormBase

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PublicationPullForm))
            Me.publicationEditionIdTextBox = New System.Windows.Forms.TextBox()
            Me.checkedInByValueLabel = New System.Windows.Forms.Label()
            Me.checkedInByLabel = New System.Windows.Forms.Label()
            Me.newspaperComboBox = New System.Windows.Forms.ComboBox()
            Me.newspaperLabel = New System.Windows.Forms.Label()
            Me.marketComboBox = New System.Windows.Forms.ComboBox()
            Me.marketLabel = New System.Windows.Forms.Label()
            Me.breakDtMonthCalendar = New System.Windows.Forms.MonthCalendar()
            Me.pageCountLabel = New System.Windows.Forms.Label()
            Me.pageCountTextBox = New System.Windows.Forms.TextBox()
            Me.noAdsCheckBox = New System.Windows.Forms.CheckBox()
            Me.checkInButton = New System.Windows.Forms.Button()
            Me.adDateLabel = New System.Windows.Forms.Label()
            Me.languageComboBox = New System.Windows.Forms.ComboBox()
            Me.languageLabel = New System.Windows.Forms.Label()
            Me.closeButton = New System.Windows.Forms.Button()
            Me.loadButton = New System.Windows.Forms.Button()
            Me.commentsLabel = New System.Windows.Forms.Label()
            Me.commentsTextBox = New System.Windows.Forms.TextBox()
            Me.requiredRetailersDataGridView = New System.Windows.Forms.DataGridView()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.deleteButton = New System.Windows.Forms.Button()
            Me.requiredRetailersGroupBox = New System.Windows.Forms.GroupBox()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.requiredRetailersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.requiredRetailersGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'publicationEditionIdTextBox
            '
            Me.publicationEditionIdTextBox.Location = New System.Drawing.Point(6, 19)
            Me.publicationEditionIdTextBox.MaxLength = 9
            Me.publicationEditionIdTextBox.Name = "publicationEditionIdTextBox"
            Me.publicationEditionIdTextBox.Size = New System.Drawing.Size(154, 20)
            Me.publicationEditionIdTextBox.TabIndex = 0
            '
            'checkedInByValueLabel
            '
            Me.checkedInByValueLabel.AutoSize = True
            Me.checkedInByValueLabel.Location = New System.Drawing.Point(95, 59)
            Me.checkedInByValueLabel.Name = "checkedInByValueLabel"
            Me.checkedInByValueLabel.Size = New System.Drawing.Size(72, 13)
            Me.checkedInByValueLabel.TabIndex = 2
            Me.checkedInByValueLabel.Text = "<User Name>"
            '
            'checkedInByLabel
            '
            Me.checkedInByLabel.AutoSize = True
            Me.checkedInByLabel.Location = New System.Drawing.Point(12, 59)
            Me.checkedInByLabel.Name = "checkedInByLabel"
            Me.checkedInByLabel.Size = New System.Drawing.Size(77, 13)
            Me.checkedInByLabel.TabIndex = 1
            Me.checkedInByLabel.Text = "Checked In By"
            '
            'newspaperComboBox
            '
            Me.newspaperComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.newspaperComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.newspaperComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.newspaperComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.newspaperComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.newspaperComboBox.Location = New System.Drawing.Point(98, 111)
            Me.newspaperComboBox.Name = "newspaperComboBox"
            Me.newspaperComboBox.Size = New System.Drawing.Size(235, 21)
            Me.newspaperComboBox.TabIndex = 6
            '
            'newspaperLabel
            '
            Me.newspaperLabel.AutoSize = True
            Me.newspaperLabel.Location = New System.Drawing.Point(12, 114)
            Me.newspaperLabel.Name = "newspaperLabel"
            Me.newspaperLabel.Size = New System.Drawing.Size(61, 13)
            Me.newspaperLabel.TabIndex = 5
            Me.newspaperLabel.Text = "Ne&wspaper"
            '
            'marketComboBox
            '
            Me.marketComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.marketComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.marketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.marketComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.marketComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.marketComboBox.Location = New System.Drawing.Point(98, 84)
            Me.marketComboBox.Name = "marketComboBox"
            Me.marketComboBox.Size = New System.Drawing.Size(235, 21)
            Me.marketComboBox.TabIndex = 4
            '
            'marketLabel
            '
            Me.marketLabel.AutoSize = True
            Me.marketLabel.Location = New System.Drawing.Point(12, 87)
            Me.marketLabel.Name = "marketLabel"
            Me.marketLabel.Size = New System.Drawing.Size(40, 13)
            Me.marketLabel.TabIndex = 3
            Me.marketLabel.Text = "&Market"
            '
            'breakDtMonthCalendar
            '
            Me.breakDtMonthCalendar.Location = New System.Drawing.Point(97, 237)
            Me.breakDtMonthCalendar.MaxSelectionCount = 1
            Me.breakDtMonthCalendar.Name = "breakDtMonthCalendar"
            Me.breakDtMonthCalendar.TabIndex = 12
            '
            'pageCountLabel
            '
            Me.pageCountLabel.AutoSize = True
            Me.pageCountLabel.Location = New System.Drawing.Point(11, 407)
            Me.pageCountLabel.Name = "pageCountLabel"
            Me.pageCountLabel.Size = New System.Drawing.Size(63, 13)
            Me.pageCountLabel.TabIndex = 13
            Me.pageCountLabel.Text = "&Page Count"
            '
            'pageCountTextBox
            '
            Me.m_ErrorProvider.SetIconAlignment(Me.pageCountTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.pageCountTextBox.Location = New System.Drawing.Point(97, 404)
            Me.pageCountTextBox.MaxLength = 3
            Me.pageCountTextBox.Name = "pageCountTextBox"
            Me.pageCountTextBox.Size = New System.Drawing.Size(33, 20)
            Me.pageCountTextBox.TabIndex = 14
            '
            'noAdsCheckBox
            '
            Me.noAdsCheckBox.AutoSize = True
            Me.noAdsCheckBox.Location = New System.Drawing.Point(136, 406)
            Me.noAdsCheckBox.Name = "noAdsCheckBox"
            Me.noAdsCheckBox.Size = New System.Drawing.Size(170, 17)
            Me.noAdsCheckBox.TabIndex = 15
            Me.noAdsCheckBox.Text = "&No Ads - Have cover scanned"
            Me.noAdsCheckBox.UseVisualStyleBackColor = True
            '
            'checkInButton
            '
            Me.checkInButton.Location = New System.Drawing.Point(420, 401)
            Me.checkInButton.Name = "checkInButton"
            Me.checkInButton.Size = New System.Drawing.Size(75, 23)
            Me.checkInButton.TabIndex = 17
            Me.checkInButton.Text = "Chec&k In"
            Me.checkInButton.UseVisualStyleBackColor = True
            '
            'adDateLabel
            '
            Me.adDateLabel.AutoSize = True
            Me.adDateLabel.Location = New System.Drawing.Point(11, 237)
            Me.adDateLabel.Name = "adDateLabel"
            Me.adDateLabel.Size = New System.Drawing.Size(46, 13)
            Me.adDateLabel.TabIndex = 11
            Me.adDateLabel.Text = "&Ad Date"
            '
            'languageComboBox
            '
            Me.languageComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.languageComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.languageComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.languageComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.languageComboBox.Location = New System.Drawing.Point(98, 138)
            Me.languageComboBox.Name = "languageComboBox"
            Me.languageComboBox.Size = New System.Drawing.Size(235, 21)
            Me.languageComboBox.TabIndex = 8
            '
            'languageLabel
            '
            Me.languageLabel.AutoSize = True
            Me.languageLabel.Location = New System.Drawing.Point(12, 141)
            Me.languageLabel.Name = "languageLabel"
            Me.languageLabel.Size = New System.Drawing.Size(55, 13)
            Me.languageLabel.TabIndex = 7
            Me.languageLabel.Text = "Lang&uage"
            '
            'closeButton
            '
            Me.closeButton.Location = New System.Drawing.Point(501, 401)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(75, 23)
            Me.closeButton.TabIndex = 19
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'loadButton
            '
            Me.loadButton.Location = New System.Drawing.Point(166, 16)
            Me.loadButton.Name = "loadButton"
            Me.loadButton.Size = New System.Drawing.Size(75, 23)
            Me.loadButton.TabIndex = 1
            Me.loadButton.Text = "&Load"
            Me.loadButton.UseVisualStyleBackColor = True
            '
            'commentsLabel
            '
            Me.commentsLabel.AutoSize = True
            Me.commentsLabel.Location = New System.Drawing.Point(12, 167)
            Me.commentsLabel.Name = "commentsLabel"
            Me.commentsLabel.Size = New System.Drawing.Size(56, 13)
            Me.commentsLabel.TabIndex = 9
            Me.commentsLabel.Text = "Comments"
            '
            'commentsTextBox
            '
            Me.commentsTextBox.Location = New System.Drawing.Point(98, 167)
            Me.commentsTextBox.Multiline = True
            Me.commentsTextBox.Name = "commentsTextBox"
            Me.commentsTextBox.ReadOnly = True
            Me.commentsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.commentsTextBox.Size = New System.Drawing.Size(235, 58)
            Me.commentsTextBox.TabIndex = 10
            Me.commentsTextBox.TabStop = False
            '
            'requiredRetailersDataGridView
            '
            Me.requiredRetailersDataGridView.AllowUserToAddRows = False
            Me.requiredRetailersDataGridView.AllowUserToDeleteRows = False
            Me.requiredRetailersDataGridView.AllowUserToResizeColumns = False
            Me.requiredRetailersDataGridView.AllowUserToResizeRows = False
            Me.requiredRetailersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.requiredRetailersDataGridView.Location = New System.Drawing.Point(6, 19)
            Me.requiredRetailersDataGridView.Name = "requiredRetailersDataGridView"
            Me.requiredRetailersDataGridView.ReadOnly = True
            Me.requiredRetailersDataGridView.Size = New System.Drawing.Size(294, 356)
            Me.requiredRetailersDataGridView.TabIndex = 0
            Me.requiredRetailersDataGridView.TabStop = False
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.loadButton)
            Me.GroupBox1.Controls.Add(Me.publicationEditionIdTextBox)
            Me.GroupBox1.Location = New System.Drawing.Point(12, 4)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(247, 47)
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Load from VehicleId"
            '
            'deleteButton
            '
            Me.deleteButton.Location = New System.Drawing.Point(582, 402)
            Me.deleteButton.Name = "deleteButton"
            Me.deleteButton.Size = New System.Drawing.Size(75, 23)
            Me.deleteButton.TabIndex = 18
            Me.deleteButton.Text = "Delete"
            Me.deleteButton.UseVisualStyleBackColor = True
            Me.deleteButton.Visible = False
            '
            'requiredRetailersGroupBox
            '
            Me.requiredRetailersGroupBox.Controls.Add(Me.requiredRetailersDataGridView)
            Me.requiredRetailersGroupBox.Location = New System.Drawing.Point(339, 12)
            Me.requiredRetailersGroupBox.Name = "requiredRetailersGroupBox"
            Me.requiredRetailersGroupBox.Size = New System.Drawing.Size(306, 381)
            Me.requiredRetailersGroupBox.TabIndex = 16
            Me.requiredRetailersGroupBox.TabStop = False
            Me.requiredRetailersGroupBox.Text = "Required Retailers"
            '
            'PublicationPullForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(668, 437)
            Me.Controls.Add(Me.requiredRetailersGroupBox)
            Me.Controls.Add(Me.deleteButton)
            Me.Controls.Add(Me.commentsTextBox)
            Me.Controls.Add(Me.commentsLabel)
            Me.Controls.Add(Me.closeButton)
            Me.Controls.Add(Me.languageComboBox)
            Me.Controls.Add(Me.languageLabel)
            Me.Controls.Add(Me.adDateLabel)
            Me.Controls.Add(Me.checkInButton)
            Me.Controls.Add(Me.noAdsCheckBox)
            Me.Controls.Add(Me.pageCountTextBox)
            Me.Controls.Add(Me.pageCountLabel)
            Me.Controls.Add(Me.breakDtMonthCalendar)
            Me.Controls.Add(Me.newspaperComboBox)
            Me.Controls.Add(Me.newspaperLabel)
            Me.Controls.Add(Me.marketComboBox)
            Me.Controls.Add(Me.marketLabel)
            Me.Controls.Add(Me.checkedInByValueLabel)
            Me.Controls.Add(Me.checkedInByLabel)
            Me.Controls.Add(Me.GroupBox1)
            Me.MaximizeBox = False
            Me.Name = "PublicationPullForm"
            Me.StatusMessage = ""
            Me.Text = "Publication Pulling"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.requiredRetailersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.requiredRetailersGroupBox.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
    Friend WithEvents publicationEditionIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents checkedInByValueLabel As System.Windows.Forms.Label
    Friend WithEvents checkedInByLabel As System.Windows.Forms.Label
    Friend WithEvents newspaperComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents newspaperLabel As System.Windows.Forms.Label
    Friend WithEvents marketComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents marketLabel As System.Windows.Forms.Label
    Friend WithEvents breakDtMonthCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents pageCountLabel As System.Windows.Forms.Label
    Friend WithEvents pageCountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents noAdsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents checkInButton As System.Windows.Forms.Button
    Friend WithEvents adDateLabel As System.Windows.Forms.Label
    Friend WithEvents languageComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents languageLabel As System.Windows.Forms.Label
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents loadButton As System.Windows.Forms.Button
    Friend WithEvents commentsLabel As System.Windows.Forms.Label
    Friend WithEvents commentsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents requiredRetailersDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents deleteButton As System.Windows.Forms.Button
    Friend WithEvents requiredRetailersGroupBox As System.Windows.Forms.GroupBox

  End Class

End Namespace