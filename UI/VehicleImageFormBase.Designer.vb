Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class VehicleImageFormBase
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VehicleImageFormBase))
            Me.pageTypeValueLabel = New System.Windows.Forms.Label()
            Me.infoManipGroupBox = New System.Windows.Forms.GroupBox()
            Me.wrongVersionButton = New System.Windows.Forms.Button()
            Me.notpromotionalButton = New System.Windows.Forms.Button()
            Me.qcCompletedButton = New System.Windows.Forms.Button()
            Me.saveButton = New System.Windows.Forms.Button()
            Me.resetButton = New System.Windows.Forms.Button()
            Me.prvalButton = New System.Windows.Forms.Button()
            Me.addButton = New System.Windows.Forms.Button()
            Me.deleteButton = New System.Windows.Forms.Button()
            Me.printButton = New System.Windows.Forms.Button()
            Me.newButton = New System.Windows.Forms.Button()
            Me.sameButton = New System.Windows.Forms.Button()
            Me.cancelButton = New System.Windows.Forms.Button()
            Me.editButton = New System.Windows.Forms.Button()
            Me.rightPanel = New System.Windows.Forms.Panel()
            Me.DrawRectangleButton = New System.Windows.Forms.Button()
            Me.pageIdLabel = New System.Windows.Forms.Label()
            Me.pageCropIdLabel = New System.Windows.Forms.Label()
            Me.exitButton = New System.Windows.Forms.Button()
            Me.resequenceButton = New System.Windows.Forms.Button()
            Me.deleteImageButton = New System.Windows.Forms.Button()
            Me.refreshButton = New System.Windows.Forms.Button()
            Me.saveImageButton = New System.Windows.Forms.Button()
            Me.removeRectangleButton = New System.Windows.Forms.Button()
            Me.zoomButton = New System.Windows.Forms.Button()
            Me.keepRectangleButton = New System.Windows.Forms.Button()
            Me.imageRotationGroupBox = New System.Windows.Forms.GroupBox()
            Me.rotateByButton = New System.Windows.Forms.Button()
            Me.rotate180AllButton = New System.Windows.Forms.Button()
            Me.rotateRButton = New System.Windows.Forms.Button()
            Me.rotateLButton = New System.Windows.Forms.Button()
            Me.rotate90AllButton = New System.Windows.Forms.Button()
            Me.rotate270Button = New System.Windows.Forms.Button()
            Me.rotate180Button = New System.Windows.Forms.Button()
            Me.rotate90Button = New System.Windows.Forms.Button()
            Me.imageSearchGroupBox = New System.Windows.Forms.GroupBox()
            Me.findImageButton = New System.Windows.Forms.Button()
            Me.findImageTextBox = New System.Windows.Forms.TextBox()
            Me.imageNavigationGroupBox = New System.Windows.Forms.GroupBox()
            Me.PageDateLabel = New System.Windows.Forms.Label()
            Me.pageSizeLabel = New System.Windows.Forms.Label()
            Me.nextImageButton = New System.Windows.Forms.Button()
            Me.lastImageButton = New System.Windows.Forms.Button()
            Me.previousImageButton = New System.Windows.Forms.Button()
            Me.firstImageButton = New System.Windows.Forms.Button()
            Me.totalPagesLabel = New System.Windows.Forms.Label()
            Me.ofLabel = New System.Windows.Forms.Label()
            Me.currentPageLabel = New System.Windows.Forms.Label()
            Me.vehiclePageCropButton = New System.Windows.Forms.Button()
            Me.isRotationLabel = New System.Windows.Forms.Label()
            Me.indexStatusTextLabel = New System.Windows.Forms.Label()
            Me.indexStatusLabel = New System.Windows.Forms.Label()
            Me.qcStatusTextLabel = New System.Windows.Forms.Label()
            Me.qcStatusLabel = New System.Windows.Forms.Label()
            Me.ImagePanel = New System.Windows.Forms.Panel()
            Me.RotatePanel = New System.Windows.Forms.Panel()
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
            Me.BeforePictureBox = New System.Windows.Forms.PictureBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.AfterPictureBox = New System.Windows.Forms.PictureBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.ControlPanel = New System.Windows.Forms.Panel()
            Me.DegreeTextBox = New System.Windows.Forms.NumericUpDown()
            Me.DegreesTrackBar = New System.Windows.Forms.TrackBar()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.CancelRotateButton = New System.Windows.Forms.Button()
            Me.OkRotateButton = New System.Windows.Forms.Button()
            Me.ImageDisplay = New System.Windows.Forms.PictureBox()
            Me.OutputPictureBox = New System.Windows.Forms.PictureBox()
            Me.lblisRotatedBy = New System.Windows.Forms.Label()
            Me.leftPanel.SuspendLayout()
            Me.vehicleGroupBox.SuspendLayout()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.infoManipGroupBox.SuspendLayout()
            Me.rightPanel.SuspendLayout()
            Me.imageRotationGroupBox.SuspendLayout()
            Me.imageSearchGroupBox.SuspendLayout()
            Me.imageNavigationGroupBox.SuspendLayout()
            Me.ImagePanel.SuspendLayout()
            Me.RotatePanel.SuspendLayout()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            CType(Me.BeforePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AfterPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ControlPanel.SuspendLayout()
            CType(Me.DegreeTextBox, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DegreesTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            CType(Me.ImageDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.OutputPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'leftPanel
            '
            Me.leftPanel.Controls.Add(Me.infoManipGroupBox)
            Me.leftPanel.Controls.Add(Me.lblisRotatedBy)
            Me.leftPanel.Controls.Add(Me.isRotationLabel)
            Me.leftPanel.Size = New System.Drawing.Size(248, 710)
            Me.leftPanel.Controls.SetChildIndex(Me.isRotationLabel, 0)
            Me.leftPanel.Controls.SetChildIndex(Me.lblisRotatedBy, 0)
            Me.leftPanel.Controls.SetChildIndex(Me.vehicleGroupBox, 0)
            Me.leftPanel.Controls.SetChildIndex(Me.infoManipGroupBox, 0)
            '
            'vehicleGroupBox
            '
            Me.vehicleGroupBox.Controls.Add(Me.qcStatusTextLabel)
            Me.vehicleGroupBox.Controls.Add(Me.qcStatusLabel)
            Me.vehicleGroupBox.Controls.Add(Me.indexStatusTextLabel)
            Me.vehicleGroupBox.Controls.Add(Me.indexStatusLabel)
            Me.vehicleGroupBox.Size = New System.Drawing.Size(241, 439)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.DistDateLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.DistDateTypeInDatePicker, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.couponCheckBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.adDateTypeInDatePicker, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.adDateLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.languageComboBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.languageLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.pagesLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.endDateTypeInDatePicker, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.endDateLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.startDateTypeInDatePicker, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.startDateLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.themeComboBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.themeLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.eventComboBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.eventLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.tradeclassValueLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.tradeclassLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.retailerComboBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.retailerLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.publicationComboBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.publicationLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.marketComboBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.marketLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.mediaComboBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.mediaLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.definePagesButton, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.vehicleIdLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.vehicleIdValueLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.indexStatusLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.indexStatusTextLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.qcStatusLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.qcStatusTextLabel, 0)
            '
            'definePagesButton
            '
            Me.definePagesButton.Location = New System.Drawing.Point(66, 401)
            '
            'languageComboBox
            '
            Me.languageComboBox.Location = New System.Drawing.Point(66, 265)
            '
            'languageLabel
            '
            Me.languageLabel.Location = New System.Drawing.Point(7, 268)
            '
            'pagesLabel
            '
            Me.pagesLabel.Location = New System.Drawing.Point(7, 406)
            '
            'endDateTypeInDatePicker
            '
            Me.endDateTypeInDatePicker.Location = New System.Drawing.Point(66, 373)
            '
            'endDateLabel
            '
            Me.endDateLabel.Location = New System.Drawing.Point(7, 376)
            '
            'startDateTypeInDatePicker
            '
            Me.startDateTypeInDatePicker.Location = New System.Drawing.Point(66, 347)
            '
            'startDateLabel
            '
            Me.startDateLabel.Location = New System.Drawing.Point(7, 350)
            '
            'themeComboBox
            '
            Me.themeComboBox.Location = New System.Drawing.Point(66, 319)
            '
            'themeLabel
            '
            Me.themeLabel.Location = New System.Drawing.Point(7, 322)
            '
            'eventComboBox
            '
            Me.eventComboBox.Location = New System.Drawing.Point(66, 292)
            '
            'eventLabel
            '
            Me.eventLabel.Location = New System.Drawing.Point(7, 295)
            '
            'tradeclassValueLabel
            '
            Me.tradeclassValueLabel.Location = New System.Drawing.Point(65, 249)
            '
            'tradeclassLabel
            '
            Me.tradeclassLabel.Location = New System.Drawing.Point(9, 249)
            '
            'retailerComboBox
            '
            Me.retailerComboBox.Location = New System.Drawing.Point(68, 221)
            '
            'retailerLabel
            '
            Me.retailerLabel.Location = New System.Drawing.Point(9, 224)
            '
            'publicationComboBox
            '
            Me.publicationComboBox.Location = New System.Drawing.Point(68, 166)
            '
            'publicationLabel
            '
            Me.publicationLabel.Location = New System.Drawing.Point(9, 169)
            '
            'marketComboBox
            '
            Me.marketComboBox.Location = New System.Drawing.Point(68, 139)
            '
            'marketLabel
            '
            Me.marketLabel.Location = New System.Drawing.Point(9, 142)
            '
            'mediaComboBox
            '
            Me.mediaComboBox.Location = New System.Drawing.Point(68, 112)
            '
            'mediaLabel
            '
            Me.mediaLabel.Location = New System.Drawing.Point(9, 115)
            '
            'adDateTypeInDatePicker
            '
            Me.adDateTypeInDatePicker.Location = New System.Drawing.Point(68, 193)
            '
            'adDateLabel
            '
            Me.adDateLabel.Location = New System.Drawing.Point(9, 196)
            '
            'couponCheckBox
            '
            Me.couponCheckBox.Location = New System.Drawing.Point(6, 401)
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'pageTypeValueLabel
            '
            Me.pageTypeValueLabel.AutoSize = True
            Me.pageTypeValueLabel.Location = New System.Drawing.Point(7, 42)
            Me.pageTypeValueLabel.Name = "pageTypeValueLabel"
            Me.pageTypeValueLabel.Size = New System.Drawing.Size(33, 13)
            Me.pageTypeValueLabel.TabIndex = 27
            Me.pageTypeValueLabel.Text = "Insert"
            '
            'infoManipGroupBox
            '
            Me.infoManipGroupBox.Controls.Add(Me.wrongVersionButton)
            Me.infoManipGroupBox.Controls.Add(Me.notpromotionalButton)
            Me.infoManipGroupBox.Controls.Add(Me.qcCompletedButton)
            Me.infoManipGroupBox.Controls.Add(Me.saveButton)
            Me.infoManipGroupBox.Controls.Add(Me.resetButton)
            Me.infoManipGroupBox.Controls.Add(Me.prvalButton)
            Me.infoManipGroupBox.Controls.Add(Me.addButton)
            Me.infoManipGroupBox.Controls.Add(Me.deleteButton)
            Me.infoManipGroupBox.Controls.Add(Me.printButton)
            Me.infoManipGroupBox.Controls.Add(Me.newButton)
            Me.infoManipGroupBox.Controls.Add(Me.sameButton)
            Me.infoManipGroupBox.Controls.Add(Me.cancelButton)
            Me.infoManipGroupBox.Controls.Add(Me.editButton)
            Me.infoManipGroupBox.Location = New System.Drawing.Point(27, 511)
            Me.infoManipGroupBox.Name = "infoManipGroupBox"
            Me.infoManipGroupBox.Size = New System.Drawing.Size(189, 188)
            Me.infoManipGroupBox.TabIndex = 2
            Me.infoManipGroupBox.TabStop = False
            '
            'wrongVersionButton
            '
            Me.wrongVersionButton.Enabled = False
            Me.wrongVersionButton.Location = New System.Drawing.Point(6, 15)
            Me.wrongVersionButton.Name = "wrongVersionButton"
            Me.wrongVersionButton.Size = New System.Drawing.Size(177, 23)
            Me.wrongVersionButton.TabIndex = 0
            Me.wrongVersionButton.Text = "&Wrong Version"
            Me.wrongVersionButton.UseVisualStyleBackColor = True
            '
            'notpromotionalButton
            '
            Me.notpromotionalButton.Location = New System.Drawing.Point(6, 155)
            Me.notpromotionalButton.Name = "notpromotionalButton"
            Me.notpromotionalButton.Size = New System.Drawing.Size(177, 23)
            Me.notpromotionalButton.TabIndex = 11
            Me.notpromotionalButton.Text = "&Not Promotional"
            Me.notpromotionalButton.UseVisualStyleBackColor = True
            Me.notpromotionalButton.Visible = False
            '
            'qcCompletedButton
            '
            Me.qcCompletedButton.Location = New System.Drawing.Point(6, 128)
            Me.qcCompletedButton.Name = "qcCompletedButton"
            Me.qcCompletedButton.Size = New System.Drawing.Size(177, 23)
            Me.qcCompletedButton.TabIndex = 10
            Me.qcCompletedButton.Text = "&QC Completed"
            Me.qcCompletedButton.UseVisualStyleBackColor = True
            '
            'saveButton
            '
            Me.saveButton.Location = New System.Drawing.Point(128, 100)
            Me.saveButton.Name = "saveButton"
            Me.saveButton.Size = New System.Drawing.Size(55, 23)
            Me.saveButton.TabIndex = 8
            Me.saveButton.Text = "Save"
            Me.saveButton.UseVisualStyleBackColor = True
            '
            'resetButton
            '
            Me.resetButton.Location = New System.Drawing.Point(67, 100)
            Me.resetButton.Name = "resetButton"
            Me.resetButton.Size = New System.Drawing.Size(55, 23)
            Me.resetButton.TabIndex = 7
            Me.resetButton.Text = "Reset"
            Me.resetButton.UseVisualStyleBackColor = True
            '
            'prvalButton
            '
            Me.prvalButton.Location = New System.Drawing.Point(6, 100)
            Me.prvalButton.Name = "prvalButton"
            Me.prvalButton.Size = New System.Drawing.Size(55, 23)
            Me.prvalButton.TabIndex = 6
            Me.prvalButton.Text = "Prv. Val."
            Me.prvalButton.UseVisualStyleBackColor = True
            '
            'addButton
            '
            Me.addButton.Location = New System.Drawing.Point(128, 71)
            Me.addButton.Name = "addButton"
            Me.addButton.Size = New System.Drawing.Size(55, 23)
            Me.addButton.TabIndex = 5
            Me.addButton.Text = "Add"
            Me.addButton.UseVisualStyleBackColor = True
            '
            'deleteButton
            '
            Me.deleteButton.Location = New System.Drawing.Point(6, 71)
            Me.deleteButton.Name = "deleteButton"
            Me.deleteButton.Size = New System.Drawing.Size(55, 23)
            Me.deleteButton.TabIndex = 3
            Me.deleteButton.Text = "Delete"
            Me.deleteButton.UseVisualStyleBackColor = True
            '
            'printButton
            '
            Me.printButton.Location = New System.Drawing.Point(128, 42)
            Me.printButton.Name = "printButton"
            Me.printButton.Size = New System.Drawing.Size(55, 23)
            Me.printButton.TabIndex = 2
            Me.printButton.Text = "Print"
            Me.printButton.UseVisualStyleBackColor = True
            '
            'newButton
            '
            Me.newButton.Location = New System.Drawing.Point(67, 42)
            Me.newButton.Name = "newButton"
            Me.newButton.Size = New System.Drawing.Size(55, 23)
            Me.newButton.TabIndex = 1
            Me.newButton.Text = "New"
            Me.newButton.UseVisualStyleBackColor = True
            '
            'sameButton
            '
            Me.sameButton.Location = New System.Drawing.Point(6, 42)
            Me.sameButton.Name = "sameButton"
            Me.sameButton.Size = New System.Drawing.Size(55, 23)
            Me.sameButton.TabIndex = 0
            Me.sameButton.Text = "Same"
            Me.sameButton.UseVisualStyleBackColor = True
            '
            'cancelButton
            '
            Me.cancelButton.Location = New System.Drawing.Point(67, 71)
            Me.cancelButton.Name = "cancelButton"
            Me.cancelButton.Size = New System.Drawing.Size(55, 23)
            Me.cancelButton.TabIndex = 9
            Me.cancelButton.Text = "Cancel"
            Me.cancelButton.UseVisualStyleBackColor = True
            Me.cancelButton.Visible = False
            '
            'editButton
            '
            Me.editButton.Location = New System.Drawing.Point(67, 71)
            Me.editButton.Name = "editButton"
            Me.editButton.Size = New System.Drawing.Size(55, 23)
            Me.editButton.TabIndex = 4
            Me.editButton.Text = "Edit"
            Me.editButton.UseVisualStyleBackColor = True
            '
            'rightPanel
            '
            Me.rightPanel.Controls.Add(Me.DrawRectangleButton)
            Me.rightPanel.Controls.Add(Me.pageIdLabel)
            Me.rightPanel.Controls.Add(Me.pageCropIdLabel)
            Me.rightPanel.Controls.Add(Me.exitButton)
            Me.rightPanel.Controls.Add(Me.resequenceButton)
            Me.rightPanel.Controls.Add(Me.deleteImageButton)
            Me.rightPanel.Controls.Add(Me.refreshButton)
            Me.rightPanel.Controls.Add(Me.saveImageButton)
            Me.rightPanel.Controls.Add(Me.removeRectangleButton)
            Me.rightPanel.Controls.Add(Me.zoomButton)
            Me.rightPanel.Controls.Add(Me.keepRectangleButton)
            Me.rightPanel.Controls.Add(Me.imageRotationGroupBox)
            Me.rightPanel.Controls.Add(Me.imageSearchGroupBox)
            Me.rightPanel.Controls.Add(Me.imageNavigationGroupBox)
            Me.rightPanel.Controls.Add(Me.vehiclePageCropButton)
            Me.rightPanel.Dock = System.Windows.Forms.DockStyle.Right
            Me.rightPanel.Location = New System.Drawing.Point(853, 0)
            Me.rightPanel.Name = "rightPanel"
            Me.rightPanel.Size = New System.Drawing.Size(167, 710)
            Me.rightPanel.TabIndex = 3
            '
            'DrawRectangleButton
            '
            Me.DrawRectangleButton.Location = New System.Drawing.Point(13, 413)
            Me.DrawRectangleButton.Name = "DrawRectangleButton"
            Me.DrawRectangleButton.Size = New System.Drawing.Size(141, 23)
            Me.DrawRectangleButton.TabIndex = 7
            Me.DrawRectangleButton.Text = "Draw Rectangle"
            Me.DrawRectangleButton.UseVisualStyleBackColor = True
            '
            'pageIdLabel
            '
            Me.pageIdLabel.AutoSize = True
            Me.pageIdLabel.Location = New System.Drawing.Point(62, 592)
            Me.pageIdLabel.Name = "pageIdLabel"
            Me.pageIdLabel.Size = New System.Drawing.Size(39, 13)
            Me.pageIdLabel.TabIndex = 15
            Me.pageIdLabel.Text = "Label1"
            Me.pageIdLabel.Visible = False
            '
            'pageCropIdLabel
            '
            Me.pageCropIdLabel.AutoSize = True
            Me.pageCropIdLabel.Location = New System.Drawing.Point(17, 592)
            Me.pageCropIdLabel.Name = "pageCropIdLabel"
            Me.pageCropIdLabel.Size = New System.Drawing.Size(39, 13)
            Me.pageCropIdLabel.TabIndex = 14
            Me.pageCropIdLabel.Text = "Label1"
            Me.pageCropIdLabel.Visible = False
            '
            'exitButton
            '
            Me.exitButton.Location = New System.Drawing.Point(13, 557)
            Me.exitButton.Name = "exitButton"
            Me.exitButton.Size = New System.Drawing.Size(141, 23)
            Me.exitButton.TabIndex = 13
            Me.exitButton.Text = "Exit"
            Me.exitButton.UseVisualStyleBackColor = True
            '
            'resequenceButton
            '
            Me.resequenceButton.Location = New System.Drawing.Point(13, 529)
            Me.resequenceButton.Name = "resequenceButton"
            Me.resequenceButton.Size = New System.Drawing.Size(141, 23)
            Me.resequenceButton.TabIndex = 10
            Me.resequenceButton.Text = "Resequence"
            Me.resequenceButton.UseVisualStyleBackColor = True
            '
            'deleteImageButton
            '
            Me.deleteImageButton.Location = New System.Drawing.Point(13, 499)
            Me.deleteImageButton.Name = "deleteImageButton"
            Me.deleteImageButton.Size = New System.Drawing.Size(141, 23)
            Me.deleteImageButton.TabIndex = 9
            Me.deleteImageButton.Text = "Delete Image"
            Me.deleteImageButton.UseVisualStyleBackColor = True
            '
            'refreshButton
            '
            Me.refreshButton.Location = New System.Drawing.Point(13, 470)
            Me.refreshButton.Name = "refreshButton"
            Me.refreshButton.Size = New System.Drawing.Size(141, 23)
            Me.refreshButton.TabIndex = 8
            Me.refreshButton.Text = "Refresh"
            Me.refreshButton.UseVisualStyleBackColor = True
            '
            'saveImageButton
            '
            Me.saveImageButton.BackColor = System.Drawing.SystemColors.Control
            Me.saveImageButton.Location = New System.Drawing.Point(13, 441)
            Me.saveImageButton.Name = "saveImageButton"
            Me.saveImageButton.Size = New System.Drawing.Size(141, 23)
            Me.saveImageButton.TabIndex = 7
            Me.saveImageButton.Text = "Save"
            Me.saveImageButton.UseVisualStyleBackColor = False
            '
            'removeRectangleButton
            '
            Me.removeRectangleButton.Location = New System.Drawing.Point(13, 384)
            Me.removeRectangleButton.Name = "removeRectangleButton"
            Me.removeRectangleButton.Size = New System.Drawing.Size(141, 23)
            Me.removeRectangleButton.TabIndex = 6
            Me.removeRectangleButton.Text = "Remove Rectangle"
            Me.removeRectangleButton.UseVisualStyleBackColor = True
            '
            'zoomButton
            '
            Me.zoomButton.BackColor = System.Drawing.SystemColors.Control
            Me.zoomButton.Location = New System.Drawing.Point(13, 355)
            Me.zoomButton.Name = "zoomButton"
            Me.zoomButton.Size = New System.Drawing.Size(141, 23)
            Me.zoomButton.TabIndex = 5
            Me.zoomButton.Text = "Zoom"
            Me.zoomButton.UseVisualStyleBackColor = False
            '
            'keepRectangleButton
            '
            Me.keepRectangleButton.BackColor = System.Drawing.SystemColors.Control
            Me.keepRectangleButton.Location = New System.Drawing.Point(13, 326)
            Me.keepRectangleButton.Name = "keepRectangleButton"
            Me.keepRectangleButton.Size = New System.Drawing.Size(141, 23)
            Me.keepRectangleButton.TabIndex = 4
            Me.keepRectangleButton.Text = "Keep Rectangle"
            Me.keepRectangleButton.UseVisualStyleBackColor = False
            '
            'imageRotationGroupBox
            '
            Me.imageRotationGroupBox.Controls.Add(Me.rotateByButton)
            Me.imageRotationGroupBox.Controls.Add(Me.rotate180AllButton)
            Me.imageRotationGroupBox.Controls.Add(Me.rotateRButton)
            Me.imageRotationGroupBox.Controls.Add(Me.rotateLButton)
            Me.imageRotationGroupBox.Controls.Add(Me.rotate90AllButton)
            Me.imageRotationGroupBox.Controls.Add(Me.rotate270Button)
            Me.imageRotationGroupBox.Controls.Add(Me.rotate180Button)
            Me.imageRotationGroupBox.Controls.Add(Me.rotate90Button)
            Me.imageRotationGroupBox.Location = New System.Drawing.Point(6, 213)
            Me.imageRotationGroupBox.Name = "imageRotationGroupBox"
            Me.imageRotationGroupBox.Size = New System.Drawing.Size(155, 107)
            Me.imageRotationGroupBox.TabIndex = 3
            Me.imageRotationGroupBox.TabStop = False
            Me.imageRotationGroupBox.Text = "Image Rotation"
            '
            'rotateByButton
            '
            Me.rotateByButton.Location = New System.Drawing.Point(56, 78)
            Me.rotateByButton.Name = "rotateByButton"
            Me.rotateByButton.Size = New System.Drawing.Size(43, 23)
            Me.rotateByButton.TabIndex = 7
            Me.rotateByButton.Text = "By"
            Me.rotateByButton.UseVisualStyleBackColor = True
            '
            'rotate180AllButton
            '
            Me.rotate180AllButton.Location = New System.Drawing.Point(7, 78)
            Me.rotate180AllButton.Name = "rotate180AllButton"
            Me.rotate180AllButton.Size = New System.Drawing.Size(43, 23)
            Me.rotate180AllButton.TabIndex = 6
            Me.rotate180AllButton.Text = "ADF"
            Me.rotate180AllButton.UseVisualStyleBackColor = True
            '
            'rotateRButton
            '
            Me.rotateRButton.Location = New System.Drawing.Point(105, 49)
            Me.rotateRButton.Name = "rotateRButton"
            Me.rotateRButton.Size = New System.Drawing.Size(43, 23)
            Me.rotateRButton.TabIndex = 5
            Me.rotateRButton.Text = "R"
            Me.rotateRButton.UseVisualStyleBackColor = True
            '
            'rotateLButton
            '
            Me.rotateLButton.Location = New System.Drawing.Point(56, 49)
            Me.rotateLButton.Name = "rotateLButton"
            Me.rotateLButton.Size = New System.Drawing.Size(43, 23)
            Me.rotateLButton.TabIndex = 4
            Me.rotateLButton.Text = "L"
            Me.rotateLButton.UseVisualStyleBackColor = True
            '
            'rotate90AllButton
            '
            Me.rotate90AllButton.Location = New System.Drawing.Point(7, 49)
            Me.rotate90AllButton.Name = "rotate90AllButton"
            Me.rotate90AllButton.Size = New System.Drawing.Size(43, 23)
            Me.rotate90AllButton.TabIndex = 3
            Me.rotate90AllButton.Text = "90 All"
            Me.rotate90AllButton.UseVisualStyleBackColor = True
            '
            'rotate270Button
            '
            Me.rotate270Button.Location = New System.Drawing.Point(105, 19)
            Me.rotate270Button.Name = "rotate270Button"
            Me.rotate270Button.Size = New System.Drawing.Size(43, 23)
            Me.rotate270Button.TabIndex = 2
            Me.rotate270Button.Text = "270"
            Me.rotate270Button.UseVisualStyleBackColor = True
            '
            'rotate180Button
            '
            Me.rotate180Button.Location = New System.Drawing.Point(56, 20)
            Me.rotate180Button.Name = "rotate180Button"
            Me.rotate180Button.Size = New System.Drawing.Size(43, 23)
            Me.rotate180Button.TabIndex = 1
            Me.rotate180Button.Text = "180"
            Me.rotate180Button.UseVisualStyleBackColor = True
            '
            'rotate90Button
            '
            Me.rotate90Button.Location = New System.Drawing.Point(7, 20)
            Me.rotate90Button.Name = "rotate90Button"
            Me.rotate90Button.Size = New System.Drawing.Size(43, 23)
            Me.rotate90Button.TabIndex = 0
            Me.rotate90Button.Text = "90"
            Me.rotate90Button.UseVisualStyleBackColor = True
            '
            'imageSearchGroupBox
            '
            Me.imageSearchGroupBox.Controls.Add(Me.findImageButton)
            Me.imageSearchGroupBox.Controls.Add(Me.findImageTextBox)
            Me.imageSearchGroupBox.Location = New System.Drawing.Point(6, 160)
            Me.imageSearchGroupBox.Name = "imageSearchGroupBox"
            Me.imageSearchGroupBox.Size = New System.Drawing.Size(155, 47)
            Me.imageSearchGroupBox.TabIndex = 2
            Me.imageSearchGroupBox.TabStop = False
            Me.imageSearchGroupBox.Text = "Image Search"
            '
            'findImageButton
            '
            Me.findImageButton.Location = New System.Drawing.Point(83, 18)
            Me.findImageButton.Name = "findImageButton"
            Me.findImageButton.Size = New System.Drawing.Size(66, 23)
            Me.findImageButton.TabIndex = 1
            Me.findImageButton.Text = "Search"
            Me.findImageButton.UseVisualStyleBackColor = True
            '
            'findImageTextBox
            '
            Me.findImageTextBox.Location = New System.Drawing.Point(7, 20)
            Me.findImageTextBox.MaxLength = 3
            Me.findImageTextBox.Name = "findImageTextBox"
            Me.findImageTextBox.Size = New System.Drawing.Size(70, 20)
            Me.findImageTextBox.TabIndex = 0
            '
            'imageNavigationGroupBox
            '
            Me.imageNavigationGroupBox.Controls.Add(Me.PageDateLabel)
            Me.imageNavigationGroupBox.Controls.Add(Me.pageTypeValueLabel)
            Me.imageNavigationGroupBox.Controls.Add(Me.pageSizeLabel)
            Me.imageNavigationGroupBox.Controls.Add(Me.nextImageButton)
            Me.imageNavigationGroupBox.Controls.Add(Me.lastImageButton)
            Me.imageNavigationGroupBox.Controls.Add(Me.previousImageButton)
            Me.imageNavigationGroupBox.Controls.Add(Me.firstImageButton)
            Me.imageNavigationGroupBox.Controls.Add(Me.totalPagesLabel)
            Me.imageNavigationGroupBox.Controls.Add(Me.ofLabel)
            Me.imageNavigationGroupBox.Controls.Add(Me.currentPageLabel)
            Me.imageNavigationGroupBox.Location = New System.Drawing.Point(6, 37)
            Me.imageNavigationGroupBox.Name = "imageNavigationGroupBox"
            Me.imageNavigationGroupBox.Size = New System.Drawing.Size(155, 117)
            Me.imageNavigationGroupBox.TabIndex = 1
            Me.imageNavigationGroupBox.TabStop = False
            Me.imageNavigationGroupBox.Text = "Image Navigation"
            '
            'PageDateLabel
            '
            Me.PageDateLabel.AutoSize = True
            Me.PageDateLabel.Location = New System.Drawing.Point(9, 64)
            Me.PageDateLabel.Name = "PageDateLabel"
            Me.PageDateLabel.Size = New System.Drawing.Size(65, 13)
            Me.PageDateLabel.TabIndex = 29
            Me.PageDateLabel.Text = "01/01/1900"
            Me.PageDateLabel.Visible = False
            '
            'pageSizeLabel
            '
            Me.pageSizeLabel.AutoSize = True
            Me.pageSizeLabel.Location = New System.Drawing.Point(40, 42)
            Me.pageSizeLabel.Name = "pageSizeLabel"
            Me.pageSizeLabel.Size = New System.Drawing.Size(74, 13)
            Me.pageSizeLabel.TabIndex = 8
            Me.pageSizeLabel.Text = "00.00 X 00.00"
            '
            'nextImageButton
            '
            Me.nextImageButton.Location = New System.Drawing.Point(81, 87)
            Me.nextImageButton.Name = "nextImageButton"
            Me.nextImageButton.Size = New System.Drawing.Size(31, 23)
            Me.nextImageButton.TabIndex = 5
            Me.nextImageButton.Text = ">"
            Me.nextImageButton.UseVisualStyleBackColor = True
            '
            'lastImageButton
            '
            Me.lastImageButton.Location = New System.Drawing.Point(118, 87)
            Me.lastImageButton.Name = "lastImageButton"
            Me.lastImageButton.Size = New System.Drawing.Size(31, 23)
            Me.lastImageButton.TabIndex = 6
            Me.lastImageButton.Text = ">>"
            Me.lastImageButton.UseVisualStyleBackColor = True
            '
            'previousImageButton
            '
            Me.previousImageButton.Location = New System.Drawing.Point(43, 87)
            Me.previousImageButton.Name = "previousImageButton"
            Me.previousImageButton.Size = New System.Drawing.Size(31, 23)
            Me.previousImageButton.TabIndex = 4
            Me.previousImageButton.Text = "<"
            Me.previousImageButton.UseVisualStyleBackColor = True
            '
            'firstImageButton
            '
            Me.firstImageButton.Location = New System.Drawing.Point(6, 87)
            Me.firstImageButton.Name = "firstImageButton"
            Me.firstImageButton.Size = New System.Drawing.Size(31, 23)
            Me.firstImageButton.TabIndex = 3
            Me.firstImageButton.Text = "<<"
            Me.firstImageButton.UseVisualStyleBackColor = True
            '
            'totalPagesLabel
            '
            Me.totalPagesLabel.AutoSize = True
            Me.totalPagesLabel.Location = New System.Drawing.Point(117, 20)
            Me.totalPagesLabel.Name = "totalPagesLabel"
            Me.totalPagesLabel.Size = New System.Drawing.Size(31, 13)
            Me.totalPagesLabel.TabIndex = 2
            Me.totalPagesLabel.Text = "8888"
            '
            'ofLabel
            '
            Me.ofLabel.AutoSize = True
            Me.ofLabel.Location = New System.Drawing.Point(65, 20)
            Me.ofLabel.Name = "ofLabel"
            Me.ofLabel.Size = New System.Drawing.Size(16, 13)
            Me.ofLabel.TabIndex = 1
            Me.ofLabel.Text = "of"
            '
            'currentPageLabel
            '
            Me.currentPageLabel.AutoSize = True
            Me.currentPageLabel.Location = New System.Drawing.Point(7, 20)
            Me.currentPageLabel.Name = "currentPageLabel"
            Me.currentPageLabel.Size = New System.Drawing.Size(31, 13)
            Me.currentPageLabel.TabIndex = 0
            Me.currentPageLabel.Text = "8888"
            '
            'vehiclePageCropButton
            '
            Me.vehiclePageCropButton.Location = New System.Drawing.Point(13, 8)
            Me.vehiclePageCropButton.Name = "vehiclePageCropButton"
            Me.vehiclePageCropButton.Size = New System.Drawing.Size(141, 23)
            Me.vehiclePageCropButton.TabIndex = 0
            Me.vehiclePageCropButton.Text = "Vehicle / Page Crop"
            Me.vehiclePageCropButton.UseVisualStyleBackColor = True
            '
            'isRotationLabel
            '
            Me.isRotationLabel.AutoSize = True
            Me.isRotationLabel.Location = New System.Drawing.Point(123, 671)
            Me.isRotationLabel.Name = "isRotationLabel"
            Me.isRotationLabel.Size = New System.Drawing.Size(29, 13)
            Me.isRotationLabel.TabIndex = 16
            Me.isRotationLabel.Text = "false"
            Me.isRotationLabel.Visible = False
            '
            'indexStatusTextLabel
            '
            Me.indexStatusTextLabel.AutoSize = True
            Me.indexStatusTextLabel.Location = New System.Drawing.Point(63, 78)
            Me.indexStatusTextLabel.Name = "indexStatusTextLabel"
            Me.indexStatusTextLabel.Size = New System.Drawing.Size(78, 26)
            Me.indexStatusTextLabel.TabIndex = 35
            Me.indexStatusTextLabel.Text = "<Status Line1>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<Status Line2>"
            '
            'indexStatusLabel
            '
            Me.indexStatusLabel.AutoSize = True
            Me.indexStatusLabel.Location = New System.Drawing.Point(6, 78)
            Me.indexStatusLabel.Name = "indexStatusLabel"
            Me.indexStatusLabel.Size = New System.Drawing.Size(39, 26)
            Me.indexStatusLabel.TabIndex = 34
            Me.indexStatusLabel.Text = "Index -" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Status"
            '
            'qcStatusTextLabel
            '
            Me.qcStatusTextLabel.AutoSize = True
            Me.qcStatusTextLabel.Location = New System.Drawing.Point(63, 44)
            Me.qcStatusTextLabel.Name = "qcStatusTextLabel"
            Me.qcStatusTextLabel.Size = New System.Drawing.Size(78, 26)
            Me.qcStatusTextLabel.TabIndex = 37
            Me.qcStatusTextLabel.Text = "<Status Line1>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<Status Line2>"
            '
            'qcStatusLabel
            '
            Me.qcStatusLabel.AutoSize = True
            Me.qcStatusLabel.Location = New System.Drawing.Point(6, 44)
            Me.qcStatusLabel.Name = "qcStatusLabel"
            Me.qcStatusLabel.Size = New System.Drawing.Size(55, 13)
            Me.qcStatusLabel.TabIndex = 36
            Me.qcStatusLabel.Text = "QC Status"
            '
            'ImagePanel
            '
            Me.ImagePanel.Controls.Add(Me.RotatePanel)
            Me.ImagePanel.Controls.Add(Me.ImageDisplay)
            Me.ImagePanel.Controls.Add(Me.OutputPictureBox)
            Me.ImagePanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ImagePanel.Location = New System.Drawing.Point(248, 0)
            Me.ImagePanel.Name = "ImagePanel"
            Me.ImagePanel.Size = New System.Drawing.Size(605, 710)
            Me.ImagePanel.TabIndex = 4
            '
            'RotatePanel
            '
            Me.RotatePanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RotatePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.RotatePanel.Controls.Add(Me.SplitContainer1)
            Me.RotatePanel.Controls.Add(Me.ControlPanel)
            Me.RotatePanel.Location = New System.Drawing.Point(-26, 2)
            Me.RotatePanel.Name = "RotatePanel"
            Me.RotatePanel.Size = New System.Drawing.Size(631, 584)
            Me.RotatePanel.TabIndex = 3
            Me.RotatePanel.Visible = False
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
            Me.SplitContainer1.Name = "SplitContainer1"
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.Controls.Add(Me.BeforePictureBox)
            Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.AfterPictureBox)
            Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
            Me.SplitContainer1.Size = New System.Drawing.Size(629, 545)
            Me.SplitContainer1.SplitterDistance = 312
            Me.SplitContainer1.TabIndex = 1
            '
            'BeforePictureBox
            '
            Me.BeforePictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.BeforePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.BeforePictureBox.Location = New System.Drawing.Point(0, -1)
            Me.BeforePictureBox.Name = "BeforePictureBox"
            Me.BeforePictureBox.Size = New System.Drawing.Size(312, 531)
            Me.BeforePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.BeforePictureBox.TabIndex = 2
            Me.BeforePictureBox.TabStop = False
            '
            'Label1
            '
            Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label1.BackColor = System.Drawing.Color.Silver
            Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label1.Location = New System.Drawing.Point(0, 530)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(312, 14)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "BEFORE"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'AfterPictureBox
            '
            Me.AfterPictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AfterPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.AfterPictureBox.Location = New System.Drawing.Point(0, -1)
            Me.AfterPictureBox.Name = "AfterPictureBox"
            Me.AfterPictureBox.Size = New System.Drawing.Size(313, 531)
            Me.AfterPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.AfterPictureBox.TabIndex = 3
            Me.AfterPictureBox.TabStop = False
            '
            'Label2
            '
            Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Label2.BackColor = System.Drawing.Color.Silver
            Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label2.Location = New System.Drawing.Point(0, 530)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(313, 14)
            Me.Label2.TabIndex = 2
            Me.Label2.Text = "AFTER"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'ControlPanel
            '
            Me.ControlPanel.Controls.Add(Me.DegreeTextBox)
            Me.ControlPanel.Controls.Add(Me.DegreesTrackBar)
            Me.ControlPanel.Controls.Add(Me.Panel1)
            Me.ControlPanel.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.ControlPanel.Location = New System.Drawing.Point(0, 545)
            Me.ControlPanel.Name = "ControlPanel"
            Me.ControlPanel.Size = New System.Drawing.Size(629, 37)
            Me.ControlPanel.TabIndex = 0
            '
            'DegreeTextBox
            '
            Me.DegreeTextBox.DecimalPlaces = 1
            Me.DegreeTextBox.Location = New System.Drawing.Point(3, 7)
            Me.DegreeTextBox.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
            Me.DegreeTextBox.Minimum = New Decimal(New Integer() {360, 0, 0, -2147483648})
            Me.DegreeTextBox.Name = "DegreeTextBox"
            Me.DegreeTextBox.Size = New System.Drawing.Size(57, 20)
            Me.DegreeTextBox.TabIndex = 3
            '
            'DegreesTrackBar
            '
            Me.DegreesTrackBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DegreesTrackBar.AutoSize = False
            Me.DegreesTrackBar.Location = New System.Drawing.Point(62, 1)
            Me.DegreesTrackBar.Maximum = 360
            Me.DegreesTrackBar.Minimum = -360
            Me.DegreesTrackBar.Name = "DegreesTrackBar"
            Me.DegreesTrackBar.Size = New System.Drawing.Size(397, 33)
            Me.DegreesTrackBar.TabIndex = 2
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.CancelRotateButton)
            Me.Panel1.Controls.Add(Me.OkRotateButton)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
            Me.Panel1.Location = New System.Drawing.Point(463, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(166, 37)
            Me.Panel1.TabIndex = 0
            '
            'CancelRotateButton
            '
            Me.CancelRotateButton.Location = New System.Drawing.Point(84, 7)
            Me.CancelRotateButton.Name = "CancelRotateButton"
            Me.CancelRotateButton.Size = New System.Drawing.Size(75, 23)
            Me.CancelRotateButton.TabIndex = 1
            Me.CancelRotateButton.Text = "Cancel"
            Me.CancelRotateButton.UseVisualStyleBackColor = True
            '
            'OkRotateButton
            '
            Me.OkRotateButton.Location = New System.Drawing.Point(6, 7)
            Me.OkRotateButton.Name = "OkRotateButton"
            Me.OkRotateButton.Size = New System.Drawing.Size(75, 23)
            Me.OkRotateButton.TabIndex = 0
            Me.OkRotateButton.Text = "&Ok"
            Me.OkRotateButton.UseVisualStyleBackColor = True
            '
            'ImageDisplay
            '
            Me.ImageDisplay.Location = New System.Drawing.Point(0, 0)
            Me.ImageDisplay.Name = "ImageDisplay"
            Me.ImageDisplay.Size = New System.Drawing.Size(414, 377)
            Me.ImageDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.ImageDisplay.TabIndex = 0
            Me.ImageDisplay.TabStop = False
            '
            'OutputPictureBox
            '
            Me.OutputPictureBox.Location = New System.Drawing.Point(0, 0)
            Me.OutputPictureBox.Name = "OutputPictureBox"
            Me.OutputPictureBox.Size = New System.Drawing.Size(414, 377)
            Me.OutputPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.OutputPictureBox.TabIndex = 1
            Me.OutputPictureBox.TabStop = False
            Me.OutputPictureBox.Visible = False
            '
            'lblisRotatedBy
            '
            Me.lblisRotatedBy.AutoSize = True
            Me.lblisRotatedBy.Location = New System.Drawing.Point(36, 672)
            Me.lblisRotatedBy.Name = "lblisRotatedBy"
            Me.lblisRotatedBy.Size = New System.Drawing.Size(29, 13)
            Me.lblisRotatedBy.TabIndex = 3
            Me.lblisRotatedBy.Text = "false"
            '
            'VehicleImageFormBase
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1020, 710)
            Me.Controls.Add(Me.ImagePanel)
            Me.Controls.Add(Me.rightPanel)
            Me.Name = "VehicleImageFormBase"
            Me.Text = "Vehicle QC"
            Me.Controls.SetChildIndex(Me.rightPanel, 0)
            Me.Controls.SetChildIndex(Me.leftPanel, 0)
            Me.Controls.SetChildIndex(Me.ImagePanel, 0)
            Me.leftPanel.ResumeLayout(False)
            Me.leftPanel.PerformLayout()
            Me.vehicleGroupBox.ResumeLayout(False)
            Me.vehicleGroupBox.PerformLayout()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.infoManipGroupBox.ResumeLayout(False)
            Me.rightPanel.ResumeLayout(False)
            Me.rightPanel.PerformLayout()
            Me.imageRotationGroupBox.ResumeLayout(False)
            Me.imageSearchGroupBox.ResumeLayout(False)
            Me.imageSearchGroupBox.PerformLayout()
            Me.imageNavigationGroupBox.ResumeLayout(False)
            Me.imageNavigationGroupBox.PerformLayout()
            Me.ImagePanel.ResumeLayout(False)
            Me.ImagePanel.PerformLayout()
            Me.RotatePanel.ResumeLayout(False)
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            Me.SplitContainer1.ResumeLayout(False)
            CType(Me.BeforePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AfterPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ControlPanel.ResumeLayout(False)
            CType(Me.DegreeTextBox, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DegreesTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            CType(Me.ImageDisplay, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.OutputPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents sameButton As System.Windows.Forms.Button
        Friend WithEvents printButton As System.Windows.Forms.Button
        Friend WithEvents newButton As System.Windows.Forms.Button
        Friend WithEvents saveButton As System.Windows.Forms.Button
        Friend WithEvents resetButton As System.Windows.Forms.Button
        Friend WithEvents prvalButton As System.Windows.Forms.Button
        Friend WithEvents addButton As System.Windows.Forms.Button
        Friend WithEvents editButton As System.Windows.Forms.Button
        Friend WithEvents deleteButton As System.Windows.Forms.Button
        Friend WithEvents vehiclePageCropButton As System.Windows.Forms.Button
        Friend WithEvents totalPagesLabel As System.Windows.Forms.Label
        Friend WithEvents ofLabel As System.Windows.Forms.Label
        Friend WithEvents currentPageLabel As System.Windows.Forms.Label
        Friend WithEvents findImageButton As System.Windows.Forms.Button
        Friend WithEvents findImageTextBox As System.Windows.Forms.TextBox
        Friend WithEvents rotateRButton As System.Windows.Forms.Button
        Friend WithEvents rotateLButton As System.Windows.Forms.Button
        Friend WithEvents rotate90AllButton As System.Windows.Forms.Button
        Friend WithEvents rotate270Button As System.Windows.Forms.Button
        Friend WithEvents rotate180Button As System.Windows.Forms.Button
        Friend WithEvents rotate90Button As System.Windows.Forms.Button
        Friend WithEvents rotateByButton As System.Windows.Forms.Button
        Friend WithEvents rotate180AllButton As System.Windows.Forms.Button
        Protected WithEvents infoManipGroupBox As System.Windows.Forms.GroupBox
        Protected WithEvents rightPanel As System.Windows.Forms.Panel
        Protected WithEvents pageTypeValueLabel As System.Windows.Forms.Label
        Friend WithEvents cancelButton As System.Windows.Forms.Button
        Protected WithEvents pageSizeLabel As System.Windows.Forms.Label
        Protected WithEvents indexStatusTextLabel As System.Windows.Forms.Label
        Protected WithEvents indexStatusLabel As System.Windows.Forms.Label
        Protected WithEvents qcStatusTextLabel As System.Windows.Forms.Label
        Protected WithEvents qcStatusLabel As System.Windows.Forms.Label
        Protected WithEvents qcCompletedButton As System.Windows.Forms.Button
        Protected WithEvents notpromotionalButton As System.Windows.Forms.Button
        'Protected WithEvents DrawRectangleButton As System.Windows.Forms.Button
        Protected WithEvents exitButton As System.Windows.Forms.Button
        Protected WithEvents imageNavigationGroupBox As System.Windows.Forms.GroupBox
        Protected WithEvents imageSearchGroupBox As System.Windows.Forms.GroupBox
        Protected WithEvents imageRotationGroupBox As System.Windows.Forms.GroupBox
        Protected WithEvents deleteImageButton As System.Windows.Forms.Button
        Protected WithEvents refreshButton As System.Windows.Forms.Button
        Protected WithEvents saveImageButton As System.Windows.Forms.Button
        Protected WithEvents removeRectangleButton As System.Windows.Forms.Button
        Protected WithEvents zoomButton As System.Windows.Forms.Button
        Protected WithEvents keepRectangleButton As System.Windows.Forms.Button
        Protected WithEvents resequenceButton As System.Windows.Forms.Button
        Protected WithEvents pageCropIdLabel As System.Windows.Forms.Label
        Protected WithEvents pageIdLabel As System.Windows.Forms.Label
        Protected WithEvents nextImageButton As System.Windows.Forms.Button
        Protected WithEvents lastImageButton As System.Windows.Forms.Button
        Protected WithEvents previousImageButton As System.Windows.Forms.Button
        Protected WithEvents firstImageButton As System.Windows.Forms.Button
        Protected WithEvents DrawRectangleButton As System.Windows.Forms.Button
        '' Private WithEvents imgAxLEAD As AxLEADImgListLib.AxLEADImgList
        Friend WithEvents ImagePanel As System.Windows.Forms.Panel
        Friend WithEvents ImageDisplay As System.Windows.Forms.PictureBox
        Friend WithEvents OutputPictureBox As System.Windows.Forms.PictureBox
        Friend WithEvents isRotationLabel As System.Windows.Forms.Label
        Friend WithEvents RotatePanel As System.Windows.Forms.Panel
        Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
        Friend WithEvents BeforePictureBox As System.Windows.Forms.PictureBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents AfterPictureBox As System.Windows.Forms.PictureBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents ControlPanel As System.Windows.Forms.Panel
        Friend WithEvents DegreeTextBox As System.Windows.Forms.NumericUpDown
        Friend WithEvents DegreesTrackBar As System.Windows.Forms.TrackBar
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents CancelRotateButton As System.Windows.Forms.Button
        Friend WithEvents OkRotateButton As System.Windows.Forms.Button
        Friend WithEvents lblisRotatedBy As System.Windows.Forms.Label
        Protected WithEvents PageDateLabel As System.Windows.Forms.Label
        Protected WithEvents wrongVersionButton As System.Windows.Forms.Button
        ''Private WithEvents AxLEADDlg1 As AxLEADDlgLib.AxLEADDlg   \\ Comment By Denver : 161
        ''Private WithEvents mainAxLEAD As AxLEADLib.AxLEAD \\ Comment By Denver : 162

    End Class

End Namespace
