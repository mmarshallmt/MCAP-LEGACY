Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class PublicationPullQCForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PublicationPullQCForm))
            Me.publicationEditionIdTextBox = New System.Windows.Forms.TextBox
            Me.checkedInByValueLabel = New System.Windows.Forms.Label
            Me.checkedInByLabel = New System.Windows.Forms.Label
            Me.checkedInDtValueLabel = New System.Windows.Forms.Label
            Me.checkedInDtLabel = New System.Windows.Forms.Label
            Me.pulledDtValueLabel = New System.Windows.Forms.Label
            Me.pulledDtLabel = New System.Windows.Forms.Label
            Me.pulledByValueLabel = New System.Windows.Forms.Label
            Me.pulledByLabel = New System.Windows.Forms.Label
            Me.QCByValueLabel = New System.Windows.Forms.Label
            Me.QCByLabel = New System.Windows.Forms.Label
            Me.languageComboBox = New System.Windows.Forms.ComboBox
            Me.languageLabel = New System.Windows.Forms.Label
            Me.adDateLabel = New System.Windows.Forms.Label
            Me.noAdsCheckBox = New System.Windows.Forms.CheckBox
            Me.pageCountTextBox = New System.Windows.Forms.TextBox
            Me.pageCountLabel = New System.Windows.Forms.Label
            Me.breakDtMonthCalendar = New System.Windows.Forms.MonthCalendar
            Me.newspaperComboBox = New System.Windows.Forms.ComboBox
            Me.newspaperLabel = New System.Windows.Forms.Label
            Me.marketComboBox = New System.Windows.Forms.ComboBox
            Me.marketLabel = New System.Windows.Forms.Label
            Me.missingRetGroupBox = New System.Windows.Forms.GroupBox
            Me.missingRetCheckedListBox = New System.Windows.Forms.CheckedListBox
            Me.closeButton = New System.Windows.Forms.Button
            Me.QCCompletedButton = New System.Windows.Forms.Button
            Me.loadButton = New System.Windows.Forms.Button
            Me.commentsTextBox = New System.Windows.Forms.TextBox
            Me.commentsLabel = New System.Windows.Forms.Label
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.missingRetGroupBox.SuspendLayout()
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
            'publicationEditionIdTextBox
            '
            Me.publicationEditionIdTextBox.Location = New System.Drawing.Point(6, 18)
            Me.publicationEditionIdTextBox.Name = "publicationEditionIdTextBox"
            Me.publicationEditionIdTextBox.Size = New System.Drawing.Size(154, 20)
            Me.publicationEditionIdTextBox.TabIndex = 3
            '
            'checkedInByValueLabel
            '
            Me.checkedInByValueLabel.AutoSize = True
            Me.checkedInByValueLabel.Location = New System.Drawing.Point(95, 62)
            Me.checkedInByValueLabel.Name = "checkedInByValueLabel"
            Me.checkedInByValueLabel.Size = New System.Drawing.Size(72, 13)
            Me.checkedInByValueLabel.TabIndex = 5
            Me.checkedInByValueLabel.Text = "<User Name>"
            '
            'checkedInByLabel
            '
            Me.checkedInByLabel.AutoSize = True
            Me.checkedInByLabel.Location = New System.Drawing.Point(12, 62)
            Me.checkedInByLabel.Name = "checkedInByLabel"
            Me.checkedInByLabel.Size = New System.Drawing.Size(77, 13)
            Me.checkedInByLabel.TabIndex = 4
            Me.checkedInByLabel.Text = "Checked In By"
            '
            'checkedInDtValueLabel
            '
            Me.checkedInDtValueLabel.AutoSize = True
            Me.checkedInDtValueLabel.Location = New System.Drawing.Point(95, 84)
            Me.checkedInDtValueLabel.Name = "checkedInDtValueLabel"
            Me.checkedInDtValueLabel.Size = New System.Drawing.Size(72, 13)
            Me.checkedInDtValueLabel.TabIndex = 7
            Me.checkedInDtValueLabel.Text = "<User Name>"
            '
            'checkedInDtLabel
            '
            Me.checkedInDtLabel.AutoSize = True
            Me.checkedInDtLabel.Location = New System.Drawing.Point(12, 84)
            Me.checkedInDtLabel.Name = "checkedInDtLabel"
            Me.checkedInDtLabel.Size = New System.Drawing.Size(76, 13)
            Me.checkedInDtLabel.TabIndex = 6
            Me.checkedInDtLabel.Text = "Checked In Dt"
            '
            'pulledDtValueLabel
            '
            Me.pulledDtValueLabel.AutoSize = True
            Me.pulledDtValueLabel.Location = New System.Drawing.Point(95, 128)
            Me.pulledDtValueLabel.Name = "pulledDtValueLabel"
            Me.pulledDtValueLabel.Size = New System.Drawing.Size(72, 13)
            Me.pulledDtValueLabel.TabIndex = 11
            Me.pulledDtValueLabel.Text = "<User Name>"
            '
            'pulledDtLabel
            '
            Me.pulledDtLabel.AutoSize = True
            Me.pulledDtLabel.Location = New System.Drawing.Point(12, 128)
            Me.pulledDtLabel.Name = "pulledDtLabel"
            Me.pulledDtLabel.Size = New System.Drawing.Size(50, 13)
            Me.pulledDtLabel.TabIndex = 10
            Me.pulledDtLabel.Text = "Pulled Dt"
            '
            'pulledByValueLabel
            '
            Me.pulledByValueLabel.AutoSize = True
            Me.pulledByValueLabel.Location = New System.Drawing.Point(95, 106)
            Me.pulledByValueLabel.Name = "pulledByValueLabel"
            Me.pulledByValueLabel.Size = New System.Drawing.Size(72, 13)
            Me.pulledByValueLabel.TabIndex = 9
            Me.pulledByValueLabel.Text = "<User Name>"
            '
            'pulledByLabel
            '
            Me.pulledByLabel.AutoSize = True
            Me.pulledByLabel.Location = New System.Drawing.Point(12, 106)
            Me.pulledByLabel.Name = "pulledByLabel"
            Me.pulledByLabel.Size = New System.Drawing.Size(51, 13)
            Me.pulledByLabel.TabIndex = 8
            Me.pulledByLabel.Text = "Pulled By"
            '
            'QCByValueLabel
            '
            Me.QCByValueLabel.AutoSize = True
            Me.QCByValueLabel.Location = New System.Drawing.Point(95, 150)
            Me.QCByValueLabel.Name = "QCByValueLabel"
            Me.QCByValueLabel.Size = New System.Drawing.Size(72, 13)
            Me.QCByValueLabel.TabIndex = 13
            Me.QCByValueLabel.Text = "<User Name>"
            '
            'QCByLabel
            '
            Me.QCByLabel.AutoSize = True
            Me.QCByLabel.Location = New System.Drawing.Point(12, 150)
            Me.QCByLabel.Name = "QCByLabel"
            Me.QCByLabel.Size = New System.Drawing.Size(31, 13)
            Me.QCByLabel.TabIndex = 12
            Me.QCByLabel.Text = "QCer"
            '
            'languageComboBox
            '
            Me.languageComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.languageComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.languageComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.languageComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.languageComboBox.Location = New System.Drawing.Point(97, 229)
            Me.languageComboBox.Name = "languageComboBox"
            Me.languageComboBox.Size = New System.Drawing.Size(235, 21)
            Me.languageComboBox.TabIndex = 20
            '
            'languageLabel
            '
            Me.languageLabel.AutoSize = True
            Me.languageLabel.Location = New System.Drawing.Point(12, 232)
            Me.languageLabel.Name = "languageLabel"
            Me.languageLabel.Size = New System.Drawing.Size(55, 13)
            Me.languageLabel.TabIndex = 19
            Me.languageLabel.Text = "Lang&uage"
            '
            'adDateLabel
            '
            Me.adDateLabel.AutoSize = True
            Me.adDateLabel.Location = New System.Drawing.Point(12, 320)
            Me.adDateLabel.Name = "adDateLabel"
            Me.adDateLabel.Size = New System.Drawing.Size(46, 13)
            Me.adDateLabel.TabIndex = 21
            Me.adDateLabel.Text = "&Ad Date"
            '
            'noAdsCheckBox
            '
            Me.noAdsCheckBox.AutoSize = True
            Me.noAdsCheckBox.Location = New System.Drawing.Point(136, 490)
            Me.noAdsCheckBox.Name = "noAdsCheckBox"
            Me.noAdsCheckBox.Size = New System.Drawing.Size(170, 17)
            Me.noAdsCheckBox.TabIndex = 25
            Me.noAdsCheckBox.Text = "&No Ads - Have cover scanned"
            Me.noAdsCheckBox.UseVisualStyleBackColor = True
            '
            'pageCountTextBox
            '
            Me.m_ErrorProvider.SetIconAlignment(Me.pageCountTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.pageCountTextBox.Location = New System.Drawing.Point(97, 488)
            Me.pageCountTextBox.MaxLength = 3
            Me.pageCountTextBox.Name = "pageCountTextBox"
            Me.pageCountTextBox.Size = New System.Drawing.Size(33, 20)
            Me.pageCountTextBox.TabIndex = 24
            '
            'pageCountLabel
            '
            Me.pageCountLabel.AutoSize = True
            Me.pageCountLabel.Location = New System.Drawing.Point(12, 491)
            Me.pageCountLabel.Name = "pageCountLabel"
            Me.pageCountLabel.Size = New System.Drawing.Size(63, 13)
            Me.pageCountLabel.TabIndex = 23
            Me.pageCountLabel.Text = "&Page Count"
            '
            'breakDtMonthCalendar
            '
            Me.breakDtMonthCalendar.Location = New System.Drawing.Point(97, 320)
            Me.breakDtMonthCalendar.MaxSelectionCount = 1
            Me.breakDtMonthCalendar.Name = "breakDtMonthCalendar"
            Me.breakDtMonthCalendar.TabIndex = 22
            '
            'newspaperComboBox
            '
            Me.newspaperComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.newspaperComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.newspaperComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.newspaperComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.newspaperComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.newspaperComboBox.Location = New System.Drawing.Point(97, 202)
            Me.newspaperComboBox.Name = "newspaperComboBox"
            Me.newspaperComboBox.Size = New System.Drawing.Size(235, 21)
            Me.newspaperComboBox.TabIndex = 18
            '
            'newspaperLabel
            '
            Me.newspaperLabel.AutoSize = True
            Me.newspaperLabel.Location = New System.Drawing.Point(12, 205)
            Me.newspaperLabel.Name = "newspaperLabel"
            Me.newspaperLabel.Size = New System.Drawing.Size(61, 13)
            Me.newspaperLabel.TabIndex = 17
            Me.newspaperLabel.Text = "Ne&wspaper"
            '
            'marketComboBox
            '
            Me.marketComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.marketComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.marketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.marketComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.marketComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.marketComboBox.Location = New System.Drawing.Point(97, 175)
            Me.marketComboBox.Name = "marketComboBox"
            Me.marketComboBox.Size = New System.Drawing.Size(235, 21)
            Me.marketComboBox.TabIndex = 16
            '
            'marketLabel
            '
            Me.marketLabel.AutoSize = True
            Me.marketLabel.Location = New System.Drawing.Point(12, 178)
            Me.marketLabel.Name = "marketLabel"
            Me.marketLabel.Size = New System.Drawing.Size(40, 13)
            Me.marketLabel.TabIndex = 15
            Me.marketLabel.Text = "&Market"
            '
            'missingRetGroupBox
            '
            Me.missingRetGroupBox.Controls.Add(Me.missingRetCheckedListBox)
            Me.missingRetGroupBox.Location = New System.Drawing.Point(338, 12)
            Me.missingRetGroupBox.Name = "missingRetGroupBox"
            Me.missingRetGroupBox.Size = New System.Drawing.Size(321, 468)
            Me.missingRetGroupBox.TabIndex = 26
            Me.missingRetGroupBox.TabStop = False
            Me.missingRetGroupBox.Text = "Missing Retailers"
            '
            'missingRetCheckedListBox
            '
            Me.missingRetCheckedListBox.FormattingEnabled = True
            Me.missingRetCheckedListBox.Location = New System.Drawing.Point(7, 23)
            Me.missingRetCheckedListBox.Name = "missingRetCheckedListBox"
            Me.missingRetCheckedListBox.Size = New System.Drawing.Size(308, 439)
            Me.missingRetCheckedListBox.TabIndex = 0
            '
            'closeButton
            '
            Me.closeButton.Location = New System.Drawing.Point(493, 486)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(75, 23)
            Me.closeButton.TabIndex = 28
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'QCCompletedButton
            '
            Me.QCCompletedButton.Location = New System.Drawing.Point(338, 486)
            Me.QCCompletedButton.Name = "QCCompletedButton"
            Me.QCCompletedButton.Size = New System.Drawing.Size(149, 23)
            Me.QCCompletedButton.TabIndex = 27
            Me.QCCompletedButton.Text = "&QC Completed"
            Me.QCCompletedButton.UseVisualStyleBackColor = True
            '
            'loadButton
            '
            Me.loadButton.Location = New System.Drawing.Point(185, 15)
            Me.loadButton.Name = "loadButton"
            Me.loadButton.Size = New System.Drawing.Size(75, 23)
            Me.loadButton.TabIndex = 29
            Me.loadButton.Text = "Loa&d"
            Me.loadButton.UseVisualStyleBackColor = True
            '
            'commentsTextBox
            '
            Me.commentsTextBox.Location = New System.Drawing.Point(98, 256)
            Me.commentsTextBox.Multiline = True
            Me.commentsTextBox.Name = "commentsTextBox"
            Me.commentsTextBox.ReadOnly = True
            Me.commentsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.commentsTextBox.Size = New System.Drawing.Size(235, 58)
            Me.commentsTextBox.TabIndex = 42
            Me.commentsTextBox.TabStop = False
            '
            'commentsLabel
            '
            Me.commentsLabel.AutoSize = True
            Me.commentsLabel.Location = New System.Drawing.Point(12, 256)
            Me.commentsLabel.Name = "commentsLabel"
            Me.commentsLabel.Size = New System.Drawing.Size(56, 13)
            Me.commentsLabel.TabIndex = 41
            Me.commentsLabel.Text = "Comments"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.Add(Me.publicationEditionIdTextBox)
            Me.GroupBox1.Controls.Add(Me.loadButton)
            Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(272, 47)
            Me.GroupBox1.TabIndex = 43
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Load from VehicleId"
            '
            'PublicationPullQCForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(671, 525)
            Me.Controls.Add(Me.checkedInByValueLabel)
            Me.Controls.Add(Me.GroupBox1)
            Me.Controls.Add(Me.commentsTextBox)
            Me.Controls.Add(Me.commentsLabel)
            Me.Controls.Add(Me.closeButton)
            Me.Controls.Add(Me.QCCompletedButton)
            Me.Controls.Add(Me.missingRetGroupBox)
            Me.Controls.Add(Me.languageComboBox)
            Me.Controls.Add(Me.languageLabel)
            Me.Controls.Add(Me.adDateLabel)
            Me.Controls.Add(Me.noAdsCheckBox)
            Me.Controls.Add(Me.pageCountTextBox)
            Me.Controls.Add(Me.pageCountLabel)
            Me.Controls.Add(Me.breakDtMonthCalendar)
            Me.Controls.Add(Me.newspaperComboBox)
            Me.Controls.Add(Me.newspaperLabel)
            Me.Controls.Add(Me.marketComboBox)
            Me.Controls.Add(Me.marketLabel)
            Me.Controls.Add(Me.QCByValueLabel)
            Me.Controls.Add(Me.QCByLabel)
            Me.Controls.Add(Me.pulledDtValueLabel)
            Me.Controls.Add(Me.pulledDtLabel)
            Me.Controls.Add(Me.pulledByValueLabel)
            Me.Controls.Add(Me.pulledByLabel)
            Me.Controls.Add(Me.checkedInDtValueLabel)
            Me.Controls.Add(Me.checkedInDtLabel)
            Me.Controls.Add(Me.checkedInByLabel)
            Me.MaximizeBox = False
            Me.Name = "PublicationPullQCForm"
            Me.StatusMessage = ""
            Me.Text = "Publication Pull QC"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.missingRetGroupBox.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
    Friend WithEvents publicationEditionIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents checkedInByValueLabel As System.Windows.Forms.Label
    Friend WithEvents checkedInByLabel As System.Windows.Forms.Label
    Friend WithEvents checkedInDtValueLabel As System.Windows.Forms.Label
    Friend WithEvents checkedInDtLabel As System.Windows.Forms.Label
    Friend WithEvents pulledDtValueLabel As System.Windows.Forms.Label
    Friend WithEvents pulledDtLabel As System.Windows.Forms.Label
    Friend WithEvents pulledByValueLabel As System.Windows.Forms.Label
    Friend WithEvents pulledByLabel As System.Windows.Forms.Label
    Friend WithEvents QCByValueLabel As System.Windows.Forms.Label
    Friend WithEvents QCByLabel As System.Windows.Forms.Label
    Friend WithEvents languageComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents languageLabel As System.Windows.Forms.Label
    Friend WithEvents adDateLabel As System.Windows.Forms.Label
    Friend WithEvents noAdsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents pageCountTextBox As System.Windows.Forms.TextBox
    Friend WithEvents pageCountLabel As System.Windows.Forms.Label
    Friend WithEvents breakDtMonthCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents newspaperComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents newspaperLabel As System.Windows.Forms.Label
    Friend WithEvents marketComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents marketLabel As System.Windows.Forms.Label
    Friend WithEvents missingRetGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents QCCompletedButton As System.Windows.Forms.Button
    Friend WithEvents missingRetCheckedListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents loadButton As System.Windows.Forms.Button
    Friend WithEvents commentsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents commentsLabel As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

  End Class

End Namespace