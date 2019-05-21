Namespace UI


  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class IndexForm
    Inherits UI.IndexBaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IndexForm))
            Me.infoManipGroupBox = New System.Windows.Forms.GroupBox()
            Me.WrongVersionButton = New System.Windows.Forms.Button()
            Me.enterandcloseButton = New System.Windows.Forms.Button()
            Me.exitButton = New System.Windows.Forms.Button()
            Me.editButton = New System.Windows.Forms.Button()
            Me.printButton = New System.Windows.Forms.Button()
            Me.enterButton = New System.Windows.Forms.Button()
            Me.deleteButton = New System.Windows.Forms.Button()
            Me.flashCheckBox = New System.Windows.Forms.CheckBox()
            Me.nationalCheckBox = New System.Windows.Forms.CheckBox()
            Me.detailEntryOptionGroupBox = New System.Windows.Forms.GroupBox()
            Me.parentVehicleIdTextBox = New System.Windows.Forms.TextBox()
            Me.parentVehicleIdLabel = New System.Windows.Forms.Label()
            Me.flagForDetailEntryCheckBox = New System.Windows.Forms.CheckBox()
            Me.CommentsLabel = New System.Windows.Forms.Label()
            Me.CommentsTextBox = New System.Windows.Forms.TextBox()
            Me.leftPanel.SuspendLayout()
            Me.vehicleGroupBox.SuspendLayout()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.infoManipGroupBox.SuspendLayout()
            Me.detailEntryOptionGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'leftPanel
            '
            Me.leftPanel.Controls.Add(Me.detailEntryOptionGroupBox)
            Me.leftPanel.Controls.Add(Me.infoManipGroupBox)
            Me.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.leftPanel.Size = New System.Drawing.Size(272, 739)
            Me.leftPanel.TabIndex = 0
            Me.leftPanel.Controls.SetChildIndex(Me.vehicleGroupBox, 0)
            Me.leftPanel.Controls.SetChildIndex(Me.infoManipGroupBox, 0)
            Me.leftPanel.Controls.SetChildIndex(Me.detailEntryOptionGroupBox, 0)
            '
            'vehicleGroupBox
            '
            Me.vehicleGroupBox.Controls.Add(Me.nationalCheckBox)
            Me.vehicleGroupBox.Controls.Add(Me.flashCheckBox)
            Me.vehicleGroupBox.Controls.Add(Me.CommentsTextBox)
            Me.vehicleGroupBox.Controls.Add(Me.CommentsLabel)
            Me.vehicleGroupBox.Location = New System.Drawing.Point(4, 146)
            Me.vehicleGroupBox.Size = New System.Drawing.Size(249, 527)
            Me.vehicleGroupBox.TabIndex = 2
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.DistDateLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.DistDateTypeInDatePicker, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.CommentsLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.CommentsTextBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.flashCheckBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.nationalCheckBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.couponCheckBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.vehicleIdLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.vehicleIdValueLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.mediaLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.mediaComboBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.marketLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.marketComboBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.publicationLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.publicationComboBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.retailerLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.retailerComboBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.tradeclassLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.tradeclassValueLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.eventLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.eventComboBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.themeLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.themeComboBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.startDateLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.startDateTypeInDatePicker, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.endDateLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.endDateTypeInDatePicker, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.pagesLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.languageLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.languageComboBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.definePagesButton, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.adDateLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.adDateTypeInDatePicker, 0)
            '
            'definePagesButton
            '
            Me.definePagesButton.TabIndex = 25
            '
            'languageComboBox
            '
            Me.languageComboBox.TabIndex = 15
            '
            'languageLabel
            '
            Me.languageLabel.TabIndex = 14
            '
            'pagesLabel
            '
            Me.pagesLabel.TabIndex = 24
            '
            'endDateTypeInDatePicker
            '
            Me.endDateTypeInDatePicker.TabIndex = 23
            '
            'endDateLabel
            '
            Me.endDateLabel.TabIndex = 22
            '
            'startDateTypeInDatePicker
            '
            Me.startDateTypeInDatePicker.TabIndex = 21
            '
            'startDateLabel
            '
            Me.startDateLabel.TabIndex = 20
            '
            'themeComboBox
            '
            Me.themeComboBox.TabIndex = 19
            '
            'themeLabel
            '
            Me.themeLabel.TabIndex = 18
            '
            'eventComboBox
            '
            Me.eventComboBox.TabIndex = 17
            '
            'eventLabel
            '
            Me.eventLabel.TabIndex = 16
            '
            'adDateTypeInDatePicker
            '
            Me.adDateTypeInDatePicker.Location = New System.Drawing.Point(65, 155)
            '
            'adDateLabel
            '
            Me.adDateLabel.Location = New System.Drawing.Point(6, 158)
            '
            'couponCheckBox
            '
            Me.couponCheckBox.Location = New System.Drawing.Point(0, 522)
            Me.couponCheckBox.TabIndex = 24
            '
            'DistDateTypeInDatePicker
            '
            Me.DistDateTypeInDatePicker.Location = New System.Drawing.Point(66, 128)
            '
            'DistDateLabel
            '
            Me.DistDateLabel.Location = New System.Drawing.Point(7, 132)
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'infoManipGroupBox
            '
            Me.infoManipGroupBox.Controls.Add(Me.WrongVersionButton)
            Me.infoManipGroupBox.Controls.Add(Me.enterandcloseButton)
            Me.infoManipGroupBox.Controls.Add(Me.exitButton)
            Me.infoManipGroupBox.Controls.Add(Me.editButton)
            Me.infoManipGroupBox.Controls.Add(Me.printButton)
            Me.infoManipGroupBox.Controls.Add(Me.enterButton)
            Me.infoManipGroupBox.Controls.Add(Me.deleteButton)
            Me.infoManipGroupBox.Location = New System.Drawing.Point(4, 679)
            Me.infoManipGroupBox.Name = "infoManipGroupBox"
            Me.infoManipGroupBox.Size = New System.Drawing.Size(249, 49)
            Me.infoManipGroupBox.TabIndex = 3
            Me.infoManipGroupBox.TabStop = False
            '
            'WrongVersionButton
            '
            Me.WrongVersionButton.Enabled = False
            Me.WrongVersionButton.Location = New System.Drawing.Point(190, 9)
            Me.WrongVersionButton.Name = "WrongVersionButton"
            Me.WrongVersionButton.Size = New System.Drawing.Size(55, 39)
            Me.WrongVersionButton.TabIndex = 6
            Me.WrongVersionButton.Text = "Wrong Version"
            Me.WrongVersionButton.UseVisualStyleBackColor = True
            '
            'enterandcloseButton
            '
            Me.enterandcloseButton.Location = New System.Drawing.Point(66, 8)
            Me.enterandcloseButton.Name = "enterandcloseButton"
            Me.enterandcloseButton.Size = New System.Drawing.Size(55, 39)
            Me.enterandcloseButton.TabIndex = 2
            Me.enterandcloseButton.Text = "Enter & Close"
            Me.enterandcloseButton.UseMnemonic = False
            Me.enterandcloseButton.UseVisualStyleBackColor = True
            Me.enterandcloseButton.Visible = False
            '
            'exitButton
            '
            Me.exitButton.Location = New System.Drawing.Point(127, 19)
            Me.exitButton.Name = "exitButton"
            Me.exitButton.Size = New System.Drawing.Size(55, 23)
            Me.exitButton.TabIndex = 4
            Me.exitButton.Text = "Exit"
            Me.exitButton.UseVisualStyleBackColor = True
            '
            'editButton
            '
            Me.editButton.Location = New System.Drawing.Point(67, 19)
            Me.editButton.Name = "editButton"
            Me.editButton.Size = New System.Drawing.Size(55, 23)
            Me.editButton.TabIndex = 3
            Me.editButton.Text = "Edit"
            Me.editButton.UseVisualStyleBackColor = True
            '
            'printButton
            '
            Me.printButton.Location = New System.Drawing.Point(6, 19)
            Me.printButton.Name = "printButton"
            Me.printButton.Size = New System.Drawing.Size(55, 23)
            Me.printButton.TabIndex = 1
            Me.printButton.Text = "Print"
            Me.printButton.UseVisualStyleBackColor = True
            '
            'enterButton
            '
            Me.enterButton.Location = New System.Drawing.Point(67, 19)
            Me.enterButton.Name = "enterButton"
            Me.enterButton.Size = New System.Drawing.Size(55, 23)
            Me.enterButton.TabIndex = 2
            Me.enterButton.Text = "Enter"
            Me.enterButton.UseVisualStyleBackColor = True
            '
            'deleteButton
            '
            Me.deleteButton.Location = New System.Drawing.Point(128, 19)
            Me.deleteButton.Name = "deleteButton"
            Me.deleteButton.Size = New System.Drawing.Size(55, 23)
            Me.deleteButton.TabIndex = 5
            Me.deleteButton.Text = "Delete"
            Me.deleteButton.UseVisualStyleBackColor = True
            Me.deleteButton.Visible = False
            '
            'flashCheckBox
            '
            Me.flashCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.flashCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.flashCheckBox.Location = New System.Drawing.Point(6, 408)
            Me.flashCheckBox.Name = "flashCheckBox"
            Me.flashCheckBox.Size = New System.Drawing.Size(75, 17)
            Me.flashCheckBox.TabIndex = 26
            Me.flashCheckBox.Text = "&FLASH"
            Me.flashCheckBox.UseVisualStyleBackColor = True
            '
            'nationalCheckBox
            '
            Me.nationalCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.nationalCheckBox.Enabled = False
            Me.nationalCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.nationalCheckBox.Location = New System.Drawing.Point(6, 428)
            Me.nationalCheckBox.Name = "nationalCheckBox"
            Me.nationalCheckBox.Size = New System.Drawing.Size(75, 17)
            Me.nationalCheckBox.TabIndex = 27
            Me.nationalCheckBox.Text = "&National"
            Me.nationalCheckBox.UseVisualStyleBackColor = True
            '
            'detailEntryOptionGroupBox
            '
            Me.detailEntryOptionGroupBox.Controls.Add(Me.parentVehicleIdTextBox)
            Me.detailEntryOptionGroupBox.Controls.Add(Me.parentVehicleIdLabel)
            Me.detailEntryOptionGroupBox.Controls.Add(Me.flagForDetailEntryCheckBox)
            Me.detailEntryOptionGroupBox.Location = New System.Drawing.Point(4, 66)
            Me.detailEntryOptionGroupBox.Name = "detailEntryOptionGroupBox"
            Me.detailEntryOptionGroupBox.Size = New System.Drawing.Size(249, 74)
            Me.detailEntryOptionGroupBox.TabIndex = 1
            Me.detailEntryOptionGroupBox.TabStop = False
            Me.detailEntryOptionGroupBox.Text = "Detail Entry Settings"
            '
            'parentVehicleIdTextBox
            '
            Me.parentVehicleIdTextBox.Location = New System.Drawing.Point(65, 42)
            Me.parentVehicleIdTextBox.MaxLength = 10
            Me.parentVehicleIdTextBox.Name = "parentVehicleIdTextBox"
            Me.parentVehicleIdTextBox.Size = New System.Drawing.Size(163, 20)
            Me.parentVehicleIdTextBox.TabIndex = 2
            '
            'parentVehicleIdLabel
            '
            Me.parentVehicleIdLabel.Location = New System.Drawing.Point(6, 39)
            Me.parentVehicleIdLabel.Name = "parentVehicleIdLabel"
            Me.parentVehicleIdLabel.Size = New System.Drawing.Size(53, 29)
            Me.parentVehicleIdLabel.TabIndex = 1
            Me.parentVehicleIdLabel.Text = "Parent VehicleId"
            '
            'flagForDetailEntryCheckBox
            '
            Me.flagForDetailEntryCheckBox.AutoSize = True
            Me.flagForDetailEntryCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.flagForDetailEntryCheckBox.Location = New System.Drawing.Point(6, 19)
            Me.flagForDetailEntryCheckBox.Name = "flagForDetailEntryCheckBox"
            Me.flagForDetailEntryCheckBox.Size = New System.Drawing.Size(118, 17)
            Me.flagForDetailEntryCheckBox.TabIndex = 0
            Me.flagForDetailEntryCheckBox.Text = "Flag for Detail Entry"
            Me.flagForDetailEntryCheckBox.UseVisualStyleBackColor = True
            '
            'CommentsLabel
            '
            Me.CommentsLabel.AutoSize = True
            Me.CommentsLabel.Location = New System.Drawing.Point(6, 455)
            Me.CommentsLabel.Name = "CommentsLabel"
            Me.CommentsLabel.Size = New System.Drawing.Size(56, 13)
            Me.CommentsLabel.TabIndex = 28
            Me.CommentsLabel.Text = "Comments"
            '
            'CommentsTextBox
            '
            Me.CommentsTextBox.Location = New System.Drawing.Point(68, 452)
            Me.CommentsTextBox.Multiline = True
            Me.CommentsTextBox.Name = "CommentsTextBox"
            Me.CommentsTextBox.Size = New System.Drawing.Size(160, 59)
            Me.CommentsTextBox.TabIndex = 29
            '
            'IndexForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(272, 739)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "IndexForm"
            Me.Text = "Index"
            Me.leftPanel.ResumeLayout(False)
            Me.vehicleGroupBox.ResumeLayout(False)
            Me.vehicleGroupBox.PerformLayout()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.infoManipGroupBox.ResumeLayout(False)
            Me.detailEntryOptionGroupBox.ResumeLayout(False)
            Me.detailEntryOptionGroupBox.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Protected WithEvents infoManipGroupBox As System.Windows.Forms.GroupBox
        Private WithEvents exitButton As System.Windows.Forms.Button
        Private WithEvents editButton As System.Windows.Forms.Button
        Private WithEvents printButton As System.Windows.Forms.Button
        Private WithEvents enterButton As System.Windows.Forms.Button
        Friend WithEvents flashCheckBox As System.Windows.Forms.CheckBox
        Private WithEvents deleteButton As System.Windows.Forms.Button
        Friend WithEvents enterandcloseButton As System.Windows.Forms.Button
        Friend WithEvents nationalCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents detailEntryOptionGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents parentVehicleIdTextBox As System.Windows.Forms.TextBox
        Friend WithEvents parentVehicleIdLabel As System.Windows.Forms.Label
        Friend WithEvents flagForDetailEntryCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents CommentsLabel As System.Windows.Forms.Label
        Friend WithEvents CommentsTextBox As System.Windows.Forms.TextBox
        Private WithEvents WrongVersionButton As System.Windows.Forms.Button

  End Class


End Namespace