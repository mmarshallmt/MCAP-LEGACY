Namespace UI


  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class EnvelopeCheckInForm
    Inherits MDIChildFormBase

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EnvelopeCheckInForm))
            Me.envelopGroupBox = New System.Windows.Forms.GroupBox()
            Me.commentsTextBox = New System.Windows.Forms.TextBox()
            Me.commentsLabel = New System.Windows.Forms.Label()
            Me.senderFilterButton = New System.Windows.Forms.Button()
            Me.envelopeIDValueLabel = New System.Windows.Forms.Label()
            Me.envelopeIDLabel = New System.Windows.Forms.Label()
            Me.receivedByValueLabel = New System.Windows.Forms.Label()
            Me.receivedByLabel = New System.Windows.Forms.Label()
            Me.receivedDateValueLabel = New System.Windows.Forms.Label()
            Me.receivedDateLabel = New System.Windows.Forms.Label()
            Me.packageTypeComboBox = New System.Windows.Forms.ComboBox()
            Me.packageTypeLabel = New System.Windows.Forms.Label()
            Me.packageAssignmentComboBox = New System.Windows.Forms.ComboBox()
            Me.packageAssignmentLabel = New System.Windows.Forms.Label()
            Me.actualWeightLBSLabel = New System.Windows.Forms.Label()
            Me.actualWeightTextBox = New System.Windows.Forms.TextBox()
            Me.actualWeightLabel = New System.Windows.Forms.Label()
            Me.printedWeightLBSLabel = New System.Windows.Forms.Label()
            Me.printedWeightTextBox = New System.Windows.Forms.TextBox()
            Me.printedWeightLabel = New System.Windows.Forms.Label()
            Me.trackNumberTextBox = New System.Windows.Forms.TextBox()
            Me.trackNumberLabel = New System.Windows.Forms.Label()
            Me.shippingMethodComboBox = New System.Windows.Forms.ComboBox()
            Me.shippingMethodLabel = New System.Windows.Forms.Label()
            Me.shippingCompanyComboBox = New System.Windows.Forms.ComboBox()
            Me.shippingCompanyLabel = New System.Windows.Forms.Label()
            Me.senderComboBox = New System.Windows.Forms.ComboBox()
            Me.senderLabel = New System.Windows.Forms.Label()
            Me.checkInButton = New System.Windows.Forms.Button()
            Me.printLabelButton = New System.Windows.Forms.Button()
            Me.clearButton = New System.Windows.Forms.Button()
            Me.searchEnvelopeIDGroupBox = New System.Windows.Forms.GroupBox()
            Me.gotoButton = New System.Windows.Forms.Button()
            Me.searchEnvelopeIDTextBox = New System.Windows.Forms.TextBox()
            Me.closeButton = New System.Windows.Forms.Button()
            Me.deleteButton = New System.Windows.Forms.Button()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.envelopGroupBox.SuspendLayout()
            Me.searchEnvelopeIDGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            '
            'envelopGroupBox
            '
            Me.envelopGroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.envelopGroupBox.Controls.Add(Me.commentsTextBox)
            Me.envelopGroupBox.Controls.Add(Me.commentsLabel)
            Me.envelopGroupBox.Controls.Add(Me.senderFilterButton)
            Me.envelopGroupBox.Controls.Add(Me.envelopeIDValueLabel)
            Me.envelopGroupBox.Controls.Add(Me.envelopeIDLabel)
            Me.envelopGroupBox.Controls.Add(Me.receivedByValueLabel)
            Me.envelopGroupBox.Controls.Add(Me.receivedByLabel)
            Me.envelopGroupBox.Controls.Add(Me.receivedDateValueLabel)
            Me.envelopGroupBox.Controls.Add(Me.receivedDateLabel)
            Me.envelopGroupBox.Controls.Add(Me.packageTypeComboBox)
            Me.envelopGroupBox.Controls.Add(Me.packageTypeLabel)
            Me.envelopGroupBox.Controls.Add(Me.printedWeightLBSLabel)
            Me.envelopGroupBox.Controls.Add(Me.printedWeightTextBox)
            Me.envelopGroupBox.Controls.Add(Me.printedWeightLabel)
            Me.envelopGroupBox.Controls.Add(Me.trackNumberTextBox)
            Me.envelopGroupBox.Controls.Add(Me.trackNumberLabel)
            Me.envelopGroupBox.Controls.Add(Me.shippingMethodComboBox)
            Me.envelopGroupBox.Controls.Add(Me.shippingMethodLabel)
            Me.envelopGroupBox.Controls.Add(Me.shippingCompanyComboBox)
            Me.envelopGroupBox.Controls.Add(Me.shippingCompanyLabel)
            Me.envelopGroupBox.Controls.Add(Me.senderComboBox)
            Me.envelopGroupBox.Controls.Add(Me.senderLabel)
            Me.envelopGroupBox.Controls.Add(Me.actualWeightLBSLabel)
            Me.envelopGroupBox.Controls.Add(Me.actualWeightTextBox)
            Me.envelopGroupBox.Controls.Add(Me.actualWeightLabel)
            Me.envelopGroupBox.Controls.Add(Me.packageAssignmentComboBox)
            Me.envelopGroupBox.Controls.Add(Me.packageAssignmentLabel)
            Me.envelopGroupBox.Location = New System.Drawing.Point(12, 12)
            Me.envelopGroupBox.Name = "envelopGroupBox"
            Me.envelopGroupBox.Size = New System.Drawing.Size(370, 320)
            Me.envelopGroupBox.TabIndex = 0
            Me.envelopGroupBox.TabStop = False
            Me.envelopGroupBox.Text = "Envelope Information"
            '
            'commentsTextBox
            '
            Me.commentsTextBox.Location = New System.Drawing.Point(119, 69)
            Me.commentsTextBox.Multiline = True
            Me.commentsTextBox.Name = "commentsTextBox"
            Me.commentsTextBox.ReadOnly = True
            Me.commentsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.commentsTextBox.Size = New System.Drawing.Size(227, 55)
            Me.commentsTextBox.TabIndex = 26
            Me.commentsTextBox.TabStop = False
            '
            'commentsLabel
            '
            Me.commentsLabel.AutoSize = True
            Me.commentsLabel.Location = New System.Drawing.Point(6, 69)
            Me.commentsLabel.Name = "commentsLabel"
            Me.commentsLabel.Size = New System.Drawing.Size(56, 13)
            Me.commentsLabel.TabIndex = 25
            Me.commentsLabel.Text = "Comments"
            '
            'senderFilterButton
            '
            Me.senderFilterButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.senderFilterButton.ImageIndex = 0
            Me.senderFilterButton.ImageList = Me.smalliconImageList
            Me.senderFilterButton.Location = New System.Drawing.Point(329, 40)
            Me.senderFilterButton.Name = "senderFilterButton"
            Me.senderFilterButton.Size = New System.Drawing.Size(26, 23)
            Me.senderFilterButton.TabIndex = 4
            Me.senderFilterButton.TabStop = False
            Me.senderFilterButton.UseVisualStyleBackColor = True
            '
            'envelopeIDValueLabel
            '
            Me.envelopeIDValueLabel.AutoSize = True
            Me.envelopeIDValueLabel.Location = New System.Drawing.Point(118, 21)
            Me.envelopeIDValueLabel.Name = "envelopeIDValueLabel"
            Me.envelopeIDValueLabel.Size = New System.Drawing.Size(78, 13)
            Me.envelopeIDValueLabel.TabIndex = 1
            Me.envelopeIDValueLabel.Text = "<Envelope ID>"
            '
            'envelopeIDLabel
            '
            Me.envelopeIDLabel.AutoSize = True
            Me.envelopeIDLabel.Location = New System.Drawing.Point(6, 21)
            Me.envelopeIDLabel.Name = "envelopeIDLabel"
            Me.envelopeIDLabel.Size = New System.Drawing.Size(66, 13)
            Me.envelopeIDLabel.TabIndex = 0
            Me.envelopeIDLabel.Text = "Envelope ID"
            '
            'receivedByValueLabel
            '
            Me.receivedByValueLabel.AutoSize = True
            Me.receivedByValueLabel.Location = New System.Drawing.Point(116, 291)
            Me.receivedByValueLabel.Name = "receivedByValueLabel"
            Me.receivedByValueLabel.Size = New System.Drawing.Size(80, 13)
            Me.receivedByValueLabel.TabIndex = 24
            Me.receivedByValueLabel.Text = "<Received By>"
            '
            'receivedByLabel
            '
            Me.receivedByLabel.AutoSize = True
            Me.receivedByLabel.Location = New System.Drawing.Point(6, 291)
            Me.receivedByLabel.Name = "receivedByLabel"
            Me.receivedByLabel.Size = New System.Drawing.Size(68, 13)
            Me.receivedByLabel.TabIndex = 23
            Me.receivedByLabel.Text = "Received By"
            '
            'receivedDateValueLabel
            '
            Me.receivedDateValueLabel.AutoSize = True
            Me.receivedDateValueLabel.Location = New System.Drawing.Point(116, 267)
            Me.receivedDateValueLabel.Name = "receivedDateValueLabel"
            Me.receivedDateValueLabel.Size = New System.Drawing.Size(91, 13)
            Me.receivedDateValueLabel.TabIndex = 22
            Me.receivedDateValueLabel.Text = "<Received Date>"
            '
            'receivedDateLabel
            '
            Me.receivedDateLabel.AutoSize = True
            Me.receivedDateLabel.Location = New System.Drawing.Point(6, 267)
            Me.receivedDateLabel.Name = "receivedDateLabel"
            Me.receivedDateLabel.Size = New System.Drawing.Size(79, 13)
            Me.receivedDateLabel.TabIndex = 21
            Me.receivedDateLabel.Text = "Received Date"
            '
            'packageTypeComboBox
            '
            Me.packageTypeComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.packageTypeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.packageTypeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.packageTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.packageTypeComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.packageTypeComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.packageTypeComboBox.Location = New System.Drawing.Point(117, 237)
            Me.packageTypeComboBox.Name = "packageTypeComboBox"
            Me.packageTypeComboBox.Size = New System.Drawing.Size(227, 21)
            Me.packageTypeComboBox.TabIndex = 18
            '
            'packageTypeLabel
            '
            Me.packageTypeLabel.AutoSize = True
            Me.packageTypeLabel.Location = New System.Drawing.Point(4, 240)
            Me.packageTypeLabel.Name = "packageTypeLabel"
            Me.packageTypeLabel.Size = New System.Drawing.Size(77, 13)
            Me.packageTypeLabel.TabIndex = 17
            Me.packageTypeLabel.Text = "Package &Type"
            '
            'packageAssignmentComboBox
            '
            Me.packageAssignmentComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.packageAssignmentComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.packageAssignmentComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.packageAssignmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.packageAssignmentComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.packageAssignmentComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.packageAssignmentComboBox.Location = New System.Drawing.Point(117, 237)
            Me.packageAssignmentComboBox.Name = "packageAssignmentComboBox"
            Me.packageAssignmentComboBox.Size = New System.Drawing.Size(227, 21)
            Me.packageAssignmentComboBox.TabIndex = 20
            Me.packageAssignmentComboBox.Visible = False
            '
            'packageAssignmentLabel
            '
            Me.packageAssignmentLabel.AutoSize = True
            Me.packageAssignmentLabel.Location = New System.Drawing.Point(4, 240)
            Me.packageAssignmentLabel.Name = "packageAssignmentLabel"
            Me.packageAssignmentLabel.Size = New System.Drawing.Size(107, 13)
            Me.packageAssignmentLabel.TabIndex = 19
            Me.packageAssignmentLabel.Text = "Package &Assignment"
            Me.packageAssignmentLabel.Visible = False
            '
            'actualWeightLBSLabel
            '
            Me.actualWeightLBSLabel.AutoSize = True
            Me.actualWeightLBSLabel.Location = New System.Drawing.Point(171, 215)
            Me.actualWeightLBSLabel.Name = "actualWeightLBSLabel"
            Me.actualWeightLBSLabel.Size = New System.Drawing.Size(20, 13)
            Me.actualWeightLBSLabel.TabIndex = 16
            Me.actualWeightLBSLabel.Text = "lbs"
            Me.actualWeightLBSLabel.Visible = False
            '
            'actualWeightTextBox
            '
            Me.m_ErrorProvider.SetIconAlignment(Me.actualWeightTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.actualWeightTextBox.Location = New System.Drawing.Point(119, 211)
            Me.actualWeightTextBox.MaxLength = 5
            Me.actualWeightTextBox.Name = "actualWeightTextBox"
            Me.actualWeightTextBox.Size = New System.Drawing.Size(46, 20)
            Me.actualWeightTextBox.TabIndex = 15
            Me.actualWeightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            Me.actualWeightTextBox.Visible = False
            '
            'actualWeightLabel
            '
            Me.actualWeightLabel.AutoSize = True
            Me.actualWeightLabel.Location = New System.Drawing.Point(6, 215)
            Me.actualWeightLabel.Name = "actualWeightLabel"
            Me.actualWeightLabel.Size = New System.Drawing.Size(74, 13)
            Me.actualWeightLabel.TabIndex = 14
            Me.actualWeightLabel.Text = "Actual W&eight"
            Me.actualWeightLabel.Visible = False
            '
            'printedWeightLBSLabel
            '
            Me.printedWeightLBSLabel.AutoSize = True
            Me.printedWeightLBSLabel.Location = New System.Drawing.Point(171, 214)
            Me.printedWeightLBSLabel.Name = "printedWeightLBSLabel"
            Me.printedWeightLBSLabel.Size = New System.Drawing.Size(20, 13)
            Me.printedWeightLBSLabel.TabIndex = 13
            Me.printedWeightLBSLabel.Text = "lbs"
            '
            'printedWeightTextBox
            '
            Me.m_ErrorProvider.SetIconAlignment(Me.printedWeightTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.printedWeightTextBox.Location = New System.Drawing.Point(119, 211)
            Me.printedWeightTextBox.MaxLength = 5
            Me.printedWeightTextBox.Name = "printedWeightTextBox"
            Me.printedWeightTextBox.Size = New System.Drawing.Size(46, 20)
            Me.printedWeightTextBox.TabIndex = 12
            Me.printedWeightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'printedWeightLabel
            '
            Me.printedWeightLabel.AutoSize = True
            Me.printedWeightLabel.Location = New System.Drawing.Point(6, 214)
            Me.printedWeightLabel.Name = "printedWeightLabel"
            Me.printedWeightLabel.Size = New System.Drawing.Size(77, 13)
            Me.printedWeightLabel.TabIndex = 11
            Me.printedWeightLabel.Text = "Printed &Weight"
            '
            'trackNumberTextBox
            '
            Me.trackNumberTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.m_ErrorProvider.SetIconAlignment(Me.trackNumberTextBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.trackNumberTextBox.Location = New System.Drawing.Point(119, 185)
            Me.trackNumberTextBox.MaxLength = 100
            Me.trackNumberTextBox.Name = "trackNumberTextBox"
            Me.trackNumberTextBox.Size = New System.Drawing.Size(227, 20)
            Me.trackNumberTextBox.TabIndex = 10
            '
            'trackNumberLabel
            '
            Me.trackNumberLabel.AutoSize = True
            Me.trackNumberLabel.Location = New System.Drawing.Point(6, 188)
            Me.trackNumberLabel.Name = "trackNumberLabel"
            Me.trackNumberLabel.Size = New System.Drawing.Size(89, 13)
            Me.trackNumberLabel.TabIndex = 9
            Me.trackNumberLabel.Text = "&Tracking Number"
            '
            'shippingMethodComboBox
            '
            Me.shippingMethodComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.shippingMethodComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.shippingMethodComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.shippingMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.shippingMethodComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.shippingMethodComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.shippingMethodComboBox.Location = New System.Drawing.Point(119, 157)
            Me.shippingMethodComboBox.Name = "shippingMethodComboBox"
            Me.shippingMethodComboBox.Size = New System.Drawing.Size(227, 21)
            Me.shippingMethodComboBox.TabIndex = 8
            '
            'shippingMethodLabel
            '
            Me.shippingMethodLabel.AutoSize = True
            Me.shippingMethodLabel.Location = New System.Drawing.Point(6, 160)
            Me.shippingMethodLabel.Name = "shippingMethodLabel"
            Me.shippingMethodLabel.Size = New System.Drawing.Size(87, 13)
            Me.shippingMethodLabel.TabIndex = 7
            Me.shippingMethodLabel.Text = "Shipping &Method"
            '
            'shippingCompanyComboBox
            '
            Me.shippingCompanyComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.shippingCompanyComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.shippingCompanyComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.shippingCompanyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.shippingCompanyComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.shippingCompanyComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.shippingCompanyComboBox.Location = New System.Drawing.Point(119, 130)
            Me.shippingCompanyComboBox.Name = "shippingCompanyComboBox"
            Me.shippingCompanyComboBox.Size = New System.Drawing.Size(227, 21)
            Me.shippingCompanyComboBox.TabIndex = 6
            '
            'shippingCompanyLabel
            '
            Me.shippingCompanyLabel.AutoSize = True
            Me.shippingCompanyLabel.Location = New System.Drawing.Point(6, 133)
            Me.shippingCompanyLabel.Name = "shippingCompanyLabel"
            Me.shippingCompanyLabel.Size = New System.Drawing.Size(95, 13)
            Me.shippingCompanyLabel.TabIndex = 5
            Me.shippingCompanyLabel.Text = "Shipping &Company"
            '
            'senderComboBox
            '
            Me.senderComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.senderComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.senderComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.senderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.senderComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.senderComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.senderComboBox.Location = New System.Drawing.Point(119, 42)
            Me.senderComboBox.Name = "senderComboBox"
            Me.senderComboBox.Size = New System.Drawing.Size(204, 21)
            Me.senderComboBox.TabIndex = 3
            '
            'senderLabel
            '
            Me.senderLabel.AutoSize = True
            Me.senderLabel.Location = New System.Drawing.Point(6, 45)
            Me.senderLabel.Name = "senderLabel"
            Me.senderLabel.Size = New System.Drawing.Size(41, 13)
            Me.senderLabel.TabIndex = 2
            Me.senderLabel.Text = "&Sender"
            '
            'checkInButton
            '
            Me.checkInButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.checkInButton.Location = New System.Drawing.Point(38, 338)
            Me.checkInButton.Name = "checkInButton"
            Me.checkInButton.Size = New System.Drawing.Size(75, 23)
            Me.checkInButton.TabIndex = 1
            Me.checkInButton.Text = "Chec&k In"
            Me.checkInButton.UseVisualStyleBackColor = True
            '
            'printLabelButton
            '
            Me.printLabelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.printLabelButton.Location = New System.Drawing.Point(119, 338)
            Me.printLabelButton.Name = "printLabelButton"
            Me.printLabelButton.Size = New System.Drawing.Size(75, 23)
            Me.printLabelButton.TabIndex = 2
            Me.printLabelButton.Text = "&Print Label"
            Me.printLabelButton.UseVisualStyleBackColor = True
            '
            'clearButton
            '
            Me.clearButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.clearButton.Location = New System.Drawing.Point(200, 338)
            Me.clearButton.Name = "clearButton"
            Me.clearButton.Size = New System.Drawing.Size(75, 23)
            Me.clearButton.TabIndex = 3
            Me.clearButton.Text = "&Clear"
            Me.clearButton.UseVisualStyleBackColor = True
            '
            'searchEnvelopeIDGroupBox
            '
            Me.searchEnvelopeIDGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.searchEnvelopeIDGroupBox.Controls.Add(Me.gotoButton)
            Me.searchEnvelopeIDGroupBox.Controls.Add(Me.searchEnvelopeIDTextBox)
            Me.searchEnvelopeIDGroupBox.Location = New System.Drawing.Point(12, 367)
            Me.searchEnvelopeIDGroupBox.Name = "searchEnvelopeIDGroupBox"
            Me.searchEnvelopeIDGroupBox.Size = New System.Drawing.Size(271, 49)
            Me.searchEnvelopeIDGroupBox.TabIndex = 5
            Me.searchEnvelopeIDGroupBox.TabStop = False
            Me.searchEnvelopeIDGroupBox.Text = "Searc&h on Envelope ID"
            '
            'gotoButton
            '
            Me.gotoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.gotoButton.Location = New System.Drawing.Point(190, 17)
            Me.gotoButton.Name = "gotoButton"
            Me.gotoButton.Size = New System.Drawing.Size(75, 23)
            Me.gotoButton.TabIndex = 1
            Me.gotoButton.Text = "&Search"
            Me.gotoButton.UseVisualStyleBackColor = True
            '
            'searchEnvelopeIDTextBox
            '
            Me.searchEnvelopeIDTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.searchEnvelopeIDTextBox.Location = New System.Drawing.Point(6, 19)
            Me.searchEnvelopeIDTextBox.MaxLength = 9
            Me.searchEnvelopeIDTextBox.Name = "searchEnvelopeIDTextBox"
            Me.searchEnvelopeIDTextBox.Size = New System.Drawing.Size(178, 20)
            Me.searchEnvelopeIDTextBox.TabIndex = 0
            '
            'closeButton
            '
            Me.closeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.closeButton.Location = New System.Drawing.Point(298, 384)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(75, 23)
            Me.closeButton.TabIndex = 6
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'deleteButton
            '
            Me.deleteButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.deleteButton.Location = New System.Drawing.Point(281, 338)
            Me.deleteButton.Name = "deleteButton"
            Me.deleteButton.Size = New System.Drawing.Size(75, 23)
            Me.deleteButton.TabIndex = 4
            Me.deleteButton.Text = "Delete"
            Me.deleteButton.UseVisualStyleBackColor = True
            Me.deleteButton.Visible = False
            '
            'EnvelopeCheckInForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(394, 429)
            Me.Controls.Add(Me.deleteButton)
            Me.Controls.Add(Me.closeButton)
            Me.Controls.Add(Me.searchEnvelopeIDGroupBox)
            Me.Controls.Add(Me.clearButton)
            Me.Controls.Add(Me.printLabelButton)
            Me.Controls.Add(Me.checkInButton)
            Me.Controls.Add(Me.envelopGroupBox)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.Name = "EnvelopeCheckInForm"
            Me.StatusMessage = ""
            Me.Text = "Envelope Check-In"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.envelopGroupBox.ResumeLayout(False)
            Me.envelopGroupBox.PerformLayout()
            Me.searchEnvelopeIDGroupBox.ResumeLayout(False)
            Me.searchEnvelopeIDGroupBox.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
    Friend WithEvents envelopGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents printedWeightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents printedWeightLabel As System.Windows.Forms.Label
    Friend WithEvents trackNumberTextBox As System.Windows.Forms.TextBox
    Friend WithEvents trackNumberLabel As System.Windows.Forms.Label
    Friend WithEvents shippingMethodComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents shippingMethodLabel As System.Windows.Forms.Label
    Friend WithEvents shippingCompanyComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents shippingCompanyLabel As System.Windows.Forms.Label
    Friend WithEvents senderComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents senderLabel As System.Windows.Forms.Label
    Friend WithEvents receivedByValueLabel As System.Windows.Forms.Label
    Friend WithEvents receivedByLabel As System.Windows.Forms.Label
    Friend WithEvents receivedDateValueLabel As System.Windows.Forms.Label
    Friend WithEvents receivedDateLabel As System.Windows.Forms.Label
    Friend WithEvents packageTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents packageTypeLabel As System.Windows.Forms.Label
    Friend WithEvents packageAssignmentComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents packageAssignmentLabel As System.Windows.Forms.Label
    Friend WithEvents actualWeightLBSLabel As System.Windows.Forms.Label
    Friend WithEvents actualWeightTextBox As System.Windows.Forms.TextBox
    Friend WithEvents actualWeightLabel As System.Windows.Forms.Label
    Friend WithEvents printedWeightLBSLabel As System.Windows.Forms.Label
    Friend WithEvents checkInButton As System.Windows.Forms.Button
    Friend WithEvents printLabelButton As System.Windows.Forms.Button
    Friend WithEvents clearButton As System.Windows.Forms.Button
    Friend WithEvents searchEnvelopeIDGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents gotoButton As System.Windows.Forms.Button
    Friend WithEvents searchEnvelopeIDTextBox As System.Windows.Forms.TextBox
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents envelopeIDValueLabel As System.Windows.Forms.Label
    Friend WithEvents envelopeIDLabel As System.Windows.Forms.Label
    Friend WithEvents senderFilterButton As System.Windows.Forms.Button
    Friend WithEvents deleteButton As System.Windows.Forms.Button
    Friend WithEvents commentsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents commentsLabel As System.Windows.Forms.Label

  End Class


End Namespace