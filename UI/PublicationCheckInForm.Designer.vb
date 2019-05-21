Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class PublicationCheckInForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PublicationCheckInForm))
            Me.checkedInByLabel = New System.Windows.Forms.Label()
            Me.checkedInByValueLabel = New System.Windows.Forms.Label()
            Me.senderLabel = New System.Windows.Forms.Label()
            Me.senderComboBox = New System.Windows.Forms.ComboBox()
            Me.marketComboBox = New System.Windows.Forms.ComboBox()
            Me.marketLabel = New System.Windows.Forms.Label()
            Me.newspaperComboBox = New System.Windows.Forms.ComboBox()
            Me.newspaperLabel = New System.Windows.Forms.Label()
            Me.checkInMonthCalendar = New System.Windows.Forms.MonthCalendar()
            Me.breakDateListBox = New System.Windows.Forms.ListBox()
            Me.clearDatesButton = New System.Windows.Forms.Button()
            Me.weightLabel = New System.Windows.Forms.Label()
            Me.weightTextBox = New System.Windows.Forms.TextBox()
            Me.sameButton = New System.Windows.Forms.Button()
            Me.newButton = New System.Windows.Forms.Button()
            Me.searchGroupBox = New System.Windows.Forms.GroupBox()
            Me.gotoButton = New System.Windows.Forms.Button()
            Me.searchTextBox = New System.Windows.Forms.TextBox()
            Me.reprintButton = New System.Windows.Forms.Button()
            Me.lbsLabel = New System.Windows.Forms.Label()
            Me.languageComboBox = New System.Windows.Forms.ComboBox()
            Me.languageLabel = New System.Windows.Forms.Label()
            Me.pubInfoGroupBox = New System.Windows.Forms.GroupBox()
            Me.senderFilterButton = New System.Windows.Forms.Button()
            Me.clearButton = New System.Windows.Forms.Button()
            Me.closeButton = New System.Windows.Forms.Button()
            Me.envelopeCheckInButton = New System.Windows.Forms.Button()
            Me.wrongVersionButton = New System.Windows.Forms.Button()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.searchGroupBox.SuspendLayout()
            Me.pubInfoGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'checkedInByLabel
            '
            Me.checkedInByLabel.AutoSize = True
            Me.checkedInByLabel.Location = New System.Drawing.Point(6, 25)
            Me.checkedInByLabel.Name = "checkedInByLabel"
            Me.checkedInByLabel.Size = New System.Drawing.Size(77, 13)
            Me.checkedInByLabel.TabIndex = 0
            Me.checkedInByLabel.Text = "Checked In By"
            '
            'checkedInByValueLabel
            '
            Me.checkedInByValueLabel.AutoSize = True
            Me.checkedInByValueLabel.Location = New System.Drawing.Point(89, 25)
            Me.checkedInByValueLabel.Name = "checkedInByValueLabel"
            Me.checkedInByValueLabel.Size = New System.Drawing.Size(72, 13)
            Me.checkedInByValueLabel.TabIndex = 1
            Me.checkedInByValueLabel.Text = "<User Name>"
            '
            'senderLabel
            '
            Me.senderLabel.AutoSize = True
            Me.senderLabel.Location = New System.Drawing.Point(6, 53)
            Me.senderLabel.Name = "senderLabel"
            Me.senderLabel.Size = New System.Drawing.Size(41, 13)
            Me.senderLabel.TabIndex = 2
            Me.senderLabel.Text = "&Sender"
            '
            'senderComboBox
            '
            Me.senderComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.senderComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.senderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.senderComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.senderComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.senderComboBox.Location = New System.Drawing.Point(92, 50)
            Me.senderComboBox.Name = "senderComboBox"
            Me.senderComboBox.Size = New System.Drawing.Size(279, 21)
            Me.senderComboBox.TabIndex = 3
            '
            'marketComboBox
            '
            Me.marketComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.marketComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.marketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.marketComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.marketComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.marketComboBox.Location = New System.Drawing.Point(92, 77)
            Me.marketComboBox.Name = "marketComboBox"
            Me.marketComboBox.Size = New System.Drawing.Size(279, 21)
            Me.marketComboBox.TabIndex = 6
            '
            'marketLabel
            '
            Me.marketLabel.AutoSize = True
            Me.marketLabel.Location = New System.Drawing.Point(6, 80)
            Me.marketLabel.Name = "marketLabel"
            Me.marketLabel.Size = New System.Drawing.Size(40, 13)
            Me.marketLabel.TabIndex = 5
            Me.marketLabel.Text = "&Market"
            '
            'newspaperComboBox
            '
            Me.newspaperComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.newspaperComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.newspaperComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.newspaperComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.newspaperComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.newspaperComboBox.Location = New System.Drawing.Point(92, 104)
            Me.newspaperComboBox.Name = "newspaperComboBox"
            Me.newspaperComboBox.Size = New System.Drawing.Size(279, 21)
            Me.newspaperComboBox.TabIndex = 8
            '
            'newspaperLabel
            '
            Me.newspaperLabel.AutoSize = True
            Me.newspaperLabel.Location = New System.Drawing.Point(6, 107)
            Me.newspaperLabel.Name = "newspaperLabel"
            Me.newspaperLabel.Size = New System.Drawing.Size(61, 13)
            Me.newspaperLabel.TabIndex = 7
            Me.newspaperLabel.Text = "Ne&wspaper"
            '
            'checkInMonthCalendar
            '
            Me.checkInMonthCalendar.Location = New System.Drawing.Point(67, 157)
            Me.checkInMonthCalendar.Name = "checkInMonthCalendar"
            Me.checkInMonthCalendar.TabIndex = 11
            '
            'breakDateListBox
            '
            Me.breakDateListBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.breakDateListBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.breakDateListBox.Location = New System.Drawing.Point(306, 158)
            Me.breakDateListBox.Name = "breakDateListBox"
            Me.breakDateListBox.Size = New System.Drawing.Size(90, 121)
            Me.breakDateListBox.TabIndex = 12
            '
            'clearDatesButton
            '
            Me.clearDatesButton.Location = New System.Drawing.Point(305, 290)
            Me.clearDatesButton.Name = "clearDatesButton"
            Me.clearDatesButton.Size = New System.Drawing.Size(90, 23)
            Me.clearDatesButton.TabIndex = 13
            Me.clearDatesButton.Text = "&Remove"
            Me.clearDatesButton.UseVisualStyleBackColor = True
            '
            'weightLabel
            '
            Me.weightLabel.AutoSize = True
            Me.weightLabel.Location = New System.Drawing.Point(6, 328)
            Me.weightLabel.Name = "weightLabel"
            Me.weightLabel.Size = New System.Drawing.Size(41, 13)
            Me.weightLabel.TabIndex = 14
            Me.weightLabel.Text = "Weigh&t"
            '
            'weightTextBox
            '
            Me.m_ErrorProvider.SetIconAlignment(Me.weightTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.weightTextBox.Location = New System.Drawing.Point(92, 325)
            Me.weightTextBox.MaxLength = 7
            Me.weightTextBox.Name = "weightTextBox"
            Me.weightTextBox.Size = New System.Drawing.Size(87, 20)
            Me.weightTextBox.TabIndex = 15
            Me.weightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'sameButton
            '
            Me.sameButton.Location = New System.Drawing.Point(12, 382)
            Me.sameButton.Name = "sameButton"
            Me.sameButton.Size = New System.Drawing.Size(107, 23)
            Me.sameButton.TabIndex = 1
            Me.sameButton.Text = "Check In - S&ame"
            Me.sameButton.UseVisualStyleBackColor = True
            '
            'newButton
            '
            Me.newButton.Location = New System.Drawing.Point(125, 382)
            Me.newButton.Name = "newButton"
            Me.newButton.Size = New System.Drawing.Size(102, 23)
            Me.newButton.TabIndex = 2
            Me.newButton.Text = "Chec&k In - New"
            Me.newButton.UseVisualStyleBackColor = True
            '
            'searchGroupBox
            '
            Me.searchGroupBox.Controls.Add(Me.gotoButton)
            Me.searchGroupBox.Controls.Add(Me.searchTextBox)
            Me.searchGroupBox.Location = New System.Drawing.Point(12, 444)
            Me.searchGroupBox.Name = "searchGroupBox"
            Me.searchGroupBox.Size = New System.Drawing.Size(263, 48)
            Me.searchGroupBox.TabIndex = 6
            Me.searchGroupBox.TabStop = False
            Me.searchGroupBox.Text = "Search on &Vehicle Id"
            '
            'gotoButton
            '
            Me.gotoButton.Location = New System.Drawing.Point(182, 18)
            Me.gotoButton.Name = "gotoButton"
            Me.gotoButton.Size = New System.Drawing.Size(75, 23)
            Me.gotoButton.TabIndex = 1
            Me.gotoButton.Text = "Search"
            Me.gotoButton.UseVisualStyleBackColor = True
            '
            'searchTextBox
            '
            Me.searchTextBox.Location = New System.Drawing.Point(7, 20)
            Me.searchTextBox.MaxLength = 9
            Me.searchTextBox.Name = "searchTextBox"
            Me.searchTextBox.Size = New System.Drawing.Size(169, 20)
            Me.searchTextBox.TabIndex = 0
            '
            'reprintButton
            '
            Me.reprintButton.Enabled = False
            Me.reprintButton.Location = New System.Drawing.Point(292, 462)
            Me.reprintButton.Name = "reprintButton"
            Me.reprintButton.Size = New System.Drawing.Size(97, 23)
            Me.reprintButton.TabIndex = 7
            Me.reprintButton.Text = "Re&print Label"
            Me.reprintButton.UseVisualStyleBackColor = True
            '
            'lbsLabel
            '
            Me.lbsLabel.AutoSize = True
            Me.lbsLabel.Location = New System.Drawing.Point(185, 328)
            Me.lbsLabel.Name = "lbsLabel"
            Me.lbsLabel.Size = New System.Drawing.Size(20, 13)
            Me.lbsLabel.TabIndex = 16
            Me.lbsLabel.Text = "lbs"
            '
            'languageComboBox
            '
            Me.languageComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.languageComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.languageComboBox.CausesValidation = False
            Me.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.languageComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.languageComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.languageComboBox.Location = New System.Drawing.Point(92, 131)
            Me.languageComboBox.Name = "languageComboBox"
            Me.languageComboBox.Size = New System.Drawing.Size(279, 21)
            Me.languageComboBox.TabIndex = 10
            '
            'languageLabel
            '
            Me.languageLabel.AutoSize = True
            Me.languageLabel.Location = New System.Drawing.Point(6, 134)
            Me.languageLabel.Name = "languageLabel"
            Me.languageLabel.Size = New System.Drawing.Size(55, 13)
            Me.languageLabel.TabIndex = 9
            Me.languageLabel.Text = "Lang&uage"
            '
            'pubInfoGroupBox
            '
            Me.pubInfoGroupBox.Controls.Add(Me.senderFilterButton)
            Me.pubInfoGroupBox.Controls.Add(Me.senderLabel)
            Me.pubInfoGroupBox.Controls.Add(Me.languageComboBox)
            Me.pubInfoGroupBox.Controls.Add(Me.checkedInByLabel)
            Me.pubInfoGroupBox.Controls.Add(Me.languageLabel)
            Me.pubInfoGroupBox.Controls.Add(Me.checkedInByValueLabel)
            Me.pubInfoGroupBox.Controls.Add(Me.lbsLabel)
            Me.pubInfoGroupBox.Controls.Add(Me.senderComboBox)
            Me.pubInfoGroupBox.Controls.Add(Me.marketLabel)
            Me.pubInfoGroupBox.Controls.Add(Me.marketComboBox)
            Me.pubInfoGroupBox.Controls.Add(Me.newspaperLabel)
            Me.pubInfoGroupBox.Controls.Add(Me.newspaperComboBox)
            Me.pubInfoGroupBox.Controls.Add(Me.weightTextBox)
            Me.pubInfoGroupBox.Controls.Add(Me.checkInMonthCalendar)
            Me.pubInfoGroupBox.Controls.Add(Me.weightLabel)
            Me.pubInfoGroupBox.Controls.Add(Me.breakDateListBox)
            Me.pubInfoGroupBox.Controls.Add(Me.clearDatesButton)
            Me.pubInfoGroupBox.Location = New System.Drawing.Point(12, 12)
            Me.pubInfoGroupBox.Name = "pubInfoGroupBox"
            Me.pubInfoGroupBox.Size = New System.Drawing.Size(418, 357)
            Me.pubInfoGroupBox.TabIndex = 0
            Me.pubInfoGroupBox.TabStop = False
            Me.pubInfoGroupBox.Text = "Publication Information"
            '
            'senderFilterButton
            '
            Me.senderFilterButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.senderFilterButton.ImageIndex = 0
            Me.senderFilterButton.ImageList = Me.smalliconImageList
            Me.senderFilterButton.Location = New System.Drawing.Point(386, 48)
            Me.senderFilterButton.Name = "senderFilterButton"
            Me.senderFilterButton.Size = New System.Drawing.Size(26, 23)
            Me.senderFilterButton.TabIndex = 4
            Me.senderFilterButton.TabStop = False
            Me.senderFilterButton.UseVisualStyleBackColor = True
            '
            'clearButton
            '
            Me.clearButton.Location = New System.Drawing.Point(233, 382)
            Me.clearButton.Name = "clearButton"
            Me.clearButton.Size = New System.Drawing.Size(75, 23)
            Me.clearButton.TabIndex = 3
            Me.clearButton.Text = "&Clear"
            Me.clearButton.UseVisualStyleBackColor = True
            '
            'closeButton
            '
            Me.closeButton.Location = New System.Drawing.Point(314, 382)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(75, 23)
            Me.closeButton.TabIndex = 4
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'envelopeCheckInButton
            '
            Me.envelopeCheckInButton.Location = New System.Drawing.Point(233, 411)
            Me.envelopeCheckInButton.Name = "envelopeCheckInButton"
            Me.envelopeCheckInButton.Size = New System.Drawing.Size(156, 23)
            Me.envelopeCheckInButton.TabIndex = 5
            Me.envelopeCheckInButton.Text = "Envelope Check-In"
            Me.envelopeCheckInButton.UseVisualStyleBackColor = True
            '
            'wrongVersionButton
            '
            Me.wrongVersionButton.Location = New System.Drawing.Point(12, 410)
            Me.wrongVersionButton.Name = "wrongVersionButton"
            Me.wrongVersionButton.Size = New System.Drawing.Size(215, 23)
            Me.wrongVersionButton.TabIndex = 8
            Me.wrongVersionButton.Text = "Check-in; Wrong Version"
            Me.wrongVersionButton.UseVisualStyleBackColor = True
            '
            'PublicationCheckInForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(434, 504)
            Me.Controls.Add(Me.wrongVersionButton)
            Me.Controls.Add(Me.envelopeCheckInButton)
            Me.Controls.Add(Me.closeButton)
            Me.Controls.Add(Me.clearButton)
            Me.Controls.Add(Me.pubInfoGroupBox)
            Me.Controls.Add(Me.reprintButton)
            Me.Controls.Add(Me.searchGroupBox)
            Me.Controls.Add(Me.newButton)
            Me.Controls.Add(Me.sameButton)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "PublicationCheckInForm"
            Me.StatusMessage = ""
            Me.Text = "Publication Check-In"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.searchGroupBox.ResumeLayout(False)
            Me.searchGroupBox.PerformLayout()
            Me.pubInfoGroupBox.ResumeLayout(False)
            Me.pubInfoGroupBox.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents checkedInByLabel As System.Windows.Forms.Label
        Friend WithEvents checkedInByValueLabel As System.Windows.Forms.Label
        Friend WithEvents senderLabel As System.Windows.Forms.Label
        Friend WithEvents senderComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents marketComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents marketLabel As System.Windows.Forms.Label
        Friend WithEvents newspaperComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents newspaperLabel As System.Windows.Forms.Label
        Friend WithEvents checkInMonthCalendar As System.Windows.Forms.MonthCalendar
        Friend WithEvents breakDateListBox As System.Windows.Forms.ListBox
        Friend WithEvents clearDatesButton As System.Windows.Forms.Button
        Friend WithEvents weightLabel As System.Windows.Forms.Label
        Friend WithEvents weightTextBox As System.Windows.Forms.TextBox
        Friend WithEvents sameButton As System.Windows.Forms.Button
        Friend WithEvents newButton As System.Windows.Forms.Button
        Friend WithEvents searchGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents gotoButton As System.Windows.Forms.Button
        Friend WithEvents searchTextBox As System.Windows.Forms.TextBox
        Friend WithEvents reprintButton As System.Windows.Forms.Button
        Friend WithEvents lbsLabel As System.Windows.Forms.Label
        Friend WithEvents languageComboBox As System.Windows.Forms.ComboBox
        Friend WithEvents languageLabel As System.Windows.Forms.Label
        Friend WithEvents pubInfoGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents clearButton As System.Windows.Forms.Button
        Friend WithEvents closeButton As System.Windows.Forms.Button
        Friend WithEvents envelopeCheckInButton As System.Windows.Forms.Button
        Friend WithEvents senderFilterButton As System.Windows.Forms.Button
        Friend WithEvents wrongVersionButton As System.Windows.Forms.Button

  End Class

End Namespace