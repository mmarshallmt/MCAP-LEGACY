﻿Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class QCForm
        Inherits UI.VehicleImageFormBase

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QCForm))
            Me.familyTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
            Me.dgThumbnails = New System.Windows.Forms.DataGridView()
            Me.viewFamilyButton = New System.Windows.Forms.Button()
            Me.flashAdCheckBox = New System.Windows.Forms.CheckBox()
            Me.priorityLabel = New System.Windows.Forms.Label()
            Me.priorityValueLabel = New System.Windows.Forms.Label()
            Me.recaptureWebpageButton = New System.Windows.Forms.Button()
            Me.nationalCheckBox = New System.Windows.Forms.CheckBox()
            Me.detailEntryOptionGroupBox = New System.Windows.Forms.GroupBox()
            Me.parentVehicleIdTextBox = New System.Windows.Forms.TextBox()
            Me.parentVehicleIdLabel = New System.Windows.Forms.Label()
            Me.flagForDetailEntryCheckBox = New System.Windows.Forms.CheckBox()
            Me.showQcData = New System.Windows.Forms.Button()
            Me.ViewThumbnails = New System.Windows.Forms.Button()
            Me.CommentsTextBox = New System.Windows.Forms.RichTextBox()
            Me.infoQCInformation = New System.Windows.Forms.GroupBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.SubjectButton = New System.Windows.Forms.Button()
            Me.txtSubject = New System.Windows.Forms.TextBox()
            Me.lblSentBy = New System.Windows.Forms.Label()
            Me.lblSentFrom = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.simrButton = New System.Windows.Forms.Button()
            Me.scannerCheckBox = New System.Windows.Forms.CheckBox()
            Me.CrookedCheckBox = New System.Windows.Forms.CheckBox()
            Me.TearCheckBox = New System.Windows.Forms.CheckBox()
            Me.BleedCheckBox = New System.Windows.Forms.CheckBox()
            Me.BadCheckBox = New System.Windows.Forms.CheckBox()
            Me.CoverageValueLabel = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.CircularIdLabel = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.infoManipGroupBox.SuspendLayout()
            Me.rightPanel.SuspendLayout()
            Me.imageNavigationGroupBox.SuspendLayout()
            Me.leftPanel.SuspendLayout()
            Me.vehicleGroupBox.SuspendLayout()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.familyTableLayoutPanel.SuspendLayout()
            CType(Me.dgThumbnails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.detailEntryOptionGroupBox.SuspendLayout()
            Me.infoQCInformation.SuspendLayout()
            Me.SuspendLayout()
            '
            'infoManipGroupBox
            '
            Me.infoManipGroupBox.Location = New System.Drawing.Point(32, 693)
            Me.infoManipGroupBox.Size = New System.Drawing.Size(189, 183)
            Me.infoManipGroupBox.TabIndex = 3
            '
            'rightPanel
            '
            Me.rightPanel.Controls.Add(Me.BadCheckBox)
            Me.rightPanel.Controls.Add(Me.BleedCheckBox)
            Me.rightPanel.Controls.Add(Me.TearCheckBox)
            Me.rightPanel.Controls.Add(Me.CrookedCheckBox)
            Me.rightPanel.Controls.Add(Me.scannerCheckBox)
            Me.rightPanel.Controls.Add(Me.simrButton)
            Me.rightPanel.Controls.Add(Me.ViewThumbnails)
            Me.rightPanel.Controls.Add(Me.recaptureWebpageButton)
            Me.rightPanel.Controls.Add(Me.familyTableLayoutPanel)
            Me.rightPanel.Location = New System.Drawing.Point(787, 0)
            Me.rightPanel.Size = New System.Drawing.Size(326, 987)
            Me.rightPanel.Controls.SetChildIndex(Me.pageCropIdLabel, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.familyTableLayoutPanel, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.recaptureWebpageButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.ViewThumbnails, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.removeRectangleButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.imageSearchGroupBox, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.imageRotationGroupBox, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.keepRectangleButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.zoomButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.DrawRectangleButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.saveImageButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.refreshButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.deleteImageButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.pageIdLabel, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.imageNavigationGroupBox, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.exitButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.resequenceButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.simrButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.scannerCheckBox, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.CrookedCheckBox, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.TearCheckBox, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.BleedCheckBox, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.BadCheckBox, 0)
            '
            'pageTypeValueLabel
            '
            Me.pageTypeValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.pageTypeValueLabel.AutoSize = False
            Me.pageTypeValueLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pageTypeValueLabel.Location = New System.Drawing.Point(7, 33)
            Me.pageTypeValueLabel.Size = New System.Drawing.Size(141, 55)
            Me.pageTypeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'pageSizeLabel
            '
            Me.pageSizeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pageSizeLabel.Location = New System.Drawing.Point(22, 88)
            Me.pageSizeLabel.Size = New System.Drawing.Size(111, 18)
            '
            'indexStatusTextLabel
            '
            Me.indexStatusTextLabel.Location = New System.Drawing.Point(41, 102)
            Me.indexStatusTextLabel.Size = New System.Drawing.Size(10, 13)
            Me.indexStatusTextLabel.Text = "I"
            Me.indexStatusTextLabel.Visible = False
            '
            'indexStatusLabel
            '
            Me.indexStatusLabel.Location = New System.Drawing.Point(6, 81)
            Me.indexStatusLabel.Size = New System.Drawing.Size(10, 13)
            Me.indexStatusLabel.Text = "I"
            Me.indexStatusLabel.Visible = False
            '
            'qcStatusTextLabel
            '
            Me.qcStatusTextLabel.Location = New System.Drawing.Point(21, 100)
            Me.qcStatusTextLabel.Size = New System.Drawing.Size(13, 13)
            Me.qcStatusTextLabel.Text = "q"
            Me.qcStatusTextLabel.Visible = False
            '
            'qcStatusLabel
            '
            Me.qcStatusLabel.Location = New System.Drawing.Point(5, 68)
            Me.qcStatusLabel.Size = New System.Drawing.Size(56, 13)
            Me.qcStatusLabel.Text = "Comments"
            '
            'qcCompletedButton
            '
            Me.qcCompletedButton.Enabled = False
            Me.qcCompletedButton.Location = New System.Drawing.Point(6, 129)
            '
            'notpromotionalButton
            '
            Me.notpromotionalButton.Location = New System.Drawing.Point(6, 154)
            '
            'exitButton
            '
            Me.exitButton.Location = New System.Drawing.Point(12, 626)
            '
            'imageNavigationGroupBox
            '
            Me.imageNavigationGroupBox.Size = New System.Drawing.Size(155, 158)
            '
            'imageSearchGroupBox
            '
            Me.imageSearchGroupBox.Location = New System.Drawing.Point(6, 201)
            '
            'imageRotationGroupBox
            '
            Me.imageRotationGroupBox.Location = New System.Drawing.Point(6, 254)
            '
            'deleteImageButton
            '
            Me.deleteImageButton.Location = New System.Drawing.Point(13, 539)
            '
            'refreshButton
            '
            Me.refreshButton.Location = New System.Drawing.Point(13, 510)
            '
            'saveImageButton
            '
            Me.saveImageButton.Location = New System.Drawing.Point(13, 481)
            Me.saveImageButton.Text = "&Save"
            '
            'removeRectangleButton
            '
            Me.removeRectangleButton.Location = New System.Drawing.Point(13, 425)
            Me.removeRectangleButton.Text = "&Remove Rectangle"
            '
            'zoomButton
            '
            Me.zoomButton.Location = New System.Drawing.Point(13, 396)
            '
            'keepRectangleButton
            '
            Me.keepRectangleButton.Location = New System.Drawing.Point(13, 367)
            Me.keepRectangleButton.Text = "&Keep Rectangle"
            '
            'resequenceButton
            '
            Me.resequenceButton.Location = New System.Drawing.Point(13, 568)
            '
            'pageCropIdLabel
            '
            Me.pageCropIdLabel.Location = New System.Drawing.Point(17, 611)
            '
            'pageIdLabel
            '
            Me.pageIdLabel.Location = New System.Drawing.Point(66, 576)
            '
            'nextImageButton
            '
            Me.nextImageButton.Location = New System.Drawing.Point(81, 129)
            '
            'lastImageButton
            '
            Me.lastImageButton.Location = New System.Drawing.Point(118, 129)
            '
            'previousImageButton
            '
            Me.previousImageButton.Location = New System.Drawing.Point(43, 129)
            '
            'firstImageButton
            '
            Me.firstImageButton.Location = New System.Drawing.Point(6, 129)
            '
            'DrawRectangleButton
            '
            Me.DrawRectangleButton.Location = New System.Drawing.Point(13, 453)
            Me.DrawRectangleButton.Text = "Draw Rectan&gle"
            '
            'PageDateLabel
            '
            Me.PageDateLabel.Location = New System.Drawing.Point(17, 110)
            '
            'leftPanel
            '
            Me.leftPanel.Controls.Add(Me.infoQCInformation)
            Me.leftPanel.Controls.Add(Me.detailEntryOptionGroupBox)
            Me.leftPanel.Size = New System.Drawing.Size(248, 987)
            Me.leftPanel.TabIndex = 0
            Me.leftPanel.Controls.SetChildIndex(Me.detailEntryOptionGroupBox, 0)
            Me.leftPanel.Controls.SetChildIndex(Me.infoQCInformation, 0)
            Me.leftPanel.Controls.SetChildIndex(Me.vehicleGroupBox, 0)
            Me.leftPanel.Controls.SetChildIndex(Me.infoManipGroupBox, 0)
            '
            'vehicleGroupBox
            '
            Me.vehicleGroupBox.Controls.Add(Me.CircularIdLabel)
            Me.vehicleGroupBox.Controls.Add(Me.Label8)
            Me.vehicleGroupBox.Controls.Add(Me.CoverageValueLabel)
            Me.vehicleGroupBox.Controls.Add(Me.Label7)
            Me.vehicleGroupBox.Controls.Add(Me.CommentsTextBox)
            Me.vehicleGroupBox.Controls.Add(Me.nationalCheckBox)
            Me.vehicleGroupBox.Controls.Add(Me.flashAdCheckBox)
            Me.vehicleGroupBox.Controls.Add(Me.priorityValueLabel)
            Me.vehicleGroupBox.Controls.Add(Me.priorityLabel)
            Me.vehicleGroupBox.Controls.Add(Me.showQcData)
            Me.vehicleGroupBox.Location = New System.Drawing.Point(4, 147)
            Me.vehicleGroupBox.Size = New System.Drawing.Size(241, 555)
            Me.vehicleGroupBox.TabIndex = 2
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.DistDateLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.DistDateTypeInDatePicker, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.indexStatusTextLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.showQcData, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.priorityLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.priorityValueLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.flashAdCheckBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.nationalCheckBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.qcStatusTextLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.CommentsTextBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.indexStatusLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.couponCheckBox, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.vehicleIdLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.vehicleIdValueLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.adDateLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.adDateTypeInDatePicker, 0)
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
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.qcStatusLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.Label7, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.CoverageValueLabel, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.Label8, 0)
            Me.vehicleGroupBox.Controls.SetChildIndex(Me.CircularIdLabel, 0)
            '
            'definePagesButton
            '
            Me.definePagesButton.Location = New System.Drawing.Point(67, 474)
            '
            'languageComboBox
            '
            Me.languageComboBox.Location = New System.Drawing.Point(67, 336)
            '
            'languageLabel
            '
            Me.languageLabel.Location = New System.Drawing.Point(8, 339)
            '
            'pagesLabel
            '
            Me.pagesLabel.Location = New System.Drawing.Point(17, 480)
            '
            'endDateTypeInDatePicker
            '
            Me.endDateTypeInDatePicker.Location = New System.Drawing.Point(67, 444)
            '
            'endDateLabel
            '
            Me.endDateLabel.Location = New System.Drawing.Point(8, 447)
            '
            'startDateTypeInDatePicker
            '
            Me.startDateTypeInDatePicker.Location = New System.Drawing.Point(67, 418)
            '
            'startDateLabel
            '
            Me.startDateLabel.Location = New System.Drawing.Point(8, 421)
            '
            'themeComboBox
            '
            Me.themeComboBox.Location = New System.Drawing.Point(67, 390)
            '
            'themeLabel
            '
            Me.themeLabel.Location = New System.Drawing.Point(11, 402)
            '
            'eventComboBox
            '
            Me.eventComboBox.Location = New System.Drawing.Point(67, 363)
            '
            'eventLabel
            '
            Me.eventLabel.Location = New System.Drawing.Point(11, 375)
            '
            'tradeclassValueLabel
            '
            Me.tradeclassValueLabel.Location = New System.Drawing.Point(64, 297)
            '
            'tradeclassLabel
            '
            Me.tradeclassLabel.Location = New System.Drawing.Point(8, 297)
            '
            'retailerComboBox
            '
            Me.retailerComboBox.Location = New System.Drawing.Point(67, 269)
            '
            'retailerLabel
            '
            Me.retailerLabel.Location = New System.Drawing.Point(8, 272)
            '
            'publicationComboBox
            '
            Me.publicationComboBox.Location = New System.Drawing.Point(67, 190)
            '
            'publicationLabel
            '
            Me.publicationLabel.Location = New System.Drawing.Point(8, 193)
            '
            'marketComboBox
            '
            Me.marketComboBox.Location = New System.Drawing.Point(67, 163)
            '
            'marketLabel
            '
            Me.marketLabel.Location = New System.Drawing.Point(8, 166)
            '
            'mediaComboBox
            '
            Me.mediaComboBox.Location = New System.Drawing.Point(67, 136)
            '
            'mediaLabel
            '
            Me.mediaLabel.Location = New System.Drawing.Point(8, 139)
            '
            'vehicleIdValueLabel
            '
            Me.vehicleIdValueLabel.Location = New System.Drawing.Point(60, 22)
            '
            'adDateTypeInDatePicker
            '
            Me.adDateTypeInDatePicker.Location = New System.Drawing.Point(67, 241)
            '
            'adDateLabel
            '
            Me.adDateLabel.Location = New System.Drawing.Point(8, 244)
            '
            'couponCheckBox
            '
            Me.couponCheckBox.Location = New System.Drawing.Point(121, 520)
            '
            'DistDateTypeInDatePicker
            '
            Me.DistDateTypeInDatePicker.Location = New System.Drawing.Point(67, 217)
            '
            'DistDateLabel
            '
            Me.DistDateLabel.Location = New System.Drawing.Point(8, 221)
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'familyTableLayoutPanel
            '
            Me.familyTableLayoutPanel.ColumnCount = 1
            Me.familyTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.familyTableLayoutPanel.Controls.Add(Me.dgThumbnails, 0, 1)
            Me.familyTableLayoutPanel.Controls.Add(Me.viewFamilyButton, 0, 0)
            Me.familyTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Right
            Me.familyTableLayoutPanel.Location = New System.Drawing.Point(167, 0)
            Me.familyTableLayoutPanel.Name = "familyTableLayoutPanel"
            Me.familyTableLayoutPanel.RowCount = 2
            Me.familyTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
            Me.familyTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.familyTableLayoutPanel.Size = New System.Drawing.Size(159, 987)
            Me.familyTableLayoutPanel.TabIndex = 27
            '
            'dgThumbnails
            '
            Me.dgThumbnails.AllowUserToAddRows = False
            Me.dgThumbnails.AllowUserToDeleteRows = False
            Me.dgThumbnails.AllowUserToOrderColumns = True
            Me.dgThumbnails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
            Me.dgThumbnails.BackgroundColor = System.Drawing.Color.White
            Me.dgThumbnails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.dgThumbnails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgThumbnails.ColumnHeadersVisible = False
            Me.dgThumbnails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgThumbnails.GridColor = System.Drawing.Color.White
            Me.dgThumbnails.Location = New System.Drawing.Point(3, 35)
            Me.dgThumbnails.Name = "dgThumbnails"
            Me.dgThumbnails.RowHeadersVisible = False
            Me.dgThumbnails.ShowCellErrors = False
            Me.dgThumbnails.ShowEditingIcon = False
            Me.dgThumbnails.ShowRowErrors = False
            Me.dgThumbnails.Size = New System.Drawing.Size(153, 949)
            Me.dgThumbnails.TabIndex = 27
            '
            'viewFamilyButton
            '
            Me.viewFamilyButton.Location = New System.Drawing.Point(3, 3)
            Me.viewFamilyButton.Name = "viewFamilyButton"
            Me.viewFamilyButton.Size = New System.Drawing.Size(153, 26)
            Me.viewFamilyButton.TabIndex = 25
            Me.viewFamilyButton.Text = "View Family"
            '
            'flashAdCheckBox
            '
            Me.flashAdCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.flashAdCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.flashAdCheckBox.Location = New System.Drawing.Point(5, 503)
            Me.flashAdCheckBox.Name = "flashAdCheckBox"
            Me.flashAdCheckBox.Size = New System.Drawing.Size(78, 17)
            Me.flashAdCheckBox.TabIndex = 29
            Me.flashAdCheckBox.Text = "FLASH"
            Me.flashAdCheckBox.UseVisualStyleBackColor = True
            '
            'priorityLabel
            '
            Me.priorityLabel.AutoSize = True
            Me.priorityLabel.Location = New System.Drawing.Point(158, 290)
            Me.priorityLabel.Name = "priorityLabel"
            Me.priorityLabel.Size = New System.Drawing.Size(38, 13)
            Me.priorityLabel.TabIndex = 38
            Me.priorityLabel.Text = "Priority"
            '
            'priorityValueLabel
            '
            Me.priorityValueLabel.AutoSize = True
            Me.priorityValueLabel.Location = New System.Drawing.Point(202, 290)
            Me.priorityValueLabel.Name = "priorityValueLabel"
            Me.priorityValueLabel.Size = New System.Drawing.Size(25, 13)
            Me.priorityValueLabel.TabIndex = 39
            Me.priorityValueLabel.Text = "888"
            '
            'recaptureWebpageButton
            '
            Me.recaptureWebpageButton.Location = New System.Drawing.Point(12, 656)
            Me.recaptureWebpageButton.Name = "recaptureWebpageButton"
            Me.recaptureWebpageButton.Size = New System.Drawing.Size(141, 46)
            Me.recaptureWebpageButton.TabIndex = 28
            Me.recaptureWebpageButton.Text = "Recapture Current Webpage"
            Me.recaptureWebpageButton.UseVisualStyleBackColor = True
            Me.recaptureWebpageButton.Visible = False
            '
            'nationalCheckBox
            '
            Me.nationalCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.nationalCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.nationalCheckBox.Location = New System.Drawing.Point(5, 526)
            Me.nationalCheckBox.Name = "nationalCheckBox"
            Me.nationalCheckBox.Size = New System.Drawing.Size(78, 17)
            Me.nationalCheckBox.TabIndex = 40
            Me.nationalCheckBox.Text = "National"
            Me.nationalCheckBox.UseVisualStyleBackColor = True
            '
            'detailEntryOptionGroupBox
            '
            Me.detailEntryOptionGroupBox.Controls.Add(Me.parentVehicleIdTextBox)
            Me.detailEntryOptionGroupBox.Controls.Add(Me.parentVehicleIdLabel)
            Me.detailEntryOptionGroupBox.Controls.Add(Me.flagForDetailEntryCheckBox)
            Me.detailEntryOptionGroupBox.Location = New System.Drawing.Point(3, 66)
            Me.detailEntryOptionGroupBox.Name = "detailEntryOptionGroupBox"
            Me.detailEntryOptionGroupBox.Size = New System.Drawing.Size(241, 77)
            Me.detailEntryOptionGroupBox.TabIndex = 1
            Me.detailEntryOptionGroupBox.TabStop = False
            Me.detailEntryOptionGroupBox.Text = "Detail Entry Settings"
            '
            'parentVehicleIdTextBox
            '
            Me.parentVehicleIdTextBox.Location = New System.Drawing.Point(65, 42)
            Me.parentVehicleIdTextBox.MaxLength = 10
            Me.parentVehicleIdTextBox.Name = "parentVehicleIdTextBox"
            Me.parentVehicleIdTextBox.Size = New System.Drawing.Size(155, 20)
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
            'showQcData
            '
            Me.showQcData.Location = New System.Drawing.Point(125, 15)
            Me.showQcData.Name = "showQcData"
            Me.showQcData.Size = New System.Drawing.Size(106, 23)
            Me.showQcData.TabIndex = 3
            Me.showQcData.Text = "Process Info"
            Me.showQcData.UseVisualStyleBackColor = True
            '
            'ViewThumbnails
            '
            Me.ViewThumbnails.Location = New System.Drawing.Point(12, 598)
            Me.ViewThumbnails.Name = "ViewThumbnails"
            Me.ViewThumbnails.Size = New System.Drawing.Size(141, 23)
            Me.ViewThumbnails.TabIndex = 29
            Me.ViewThumbnails.Text = "View Thumbnails"
            Me.ViewThumbnails.UseVisualStyleBackColor = True
            '
            'CommentsTextBox
            '
            Me.CommentsTextBox.Location = New System.Drawing.Point(67, 68)
            Me.CommentsTextBox.Name = "CommentsTextBox"
            Me.CommentsTextBox.Size = New System.Drawing.Size(163, 59)
            Me.CommentsTextBox.TabIndex = 42
            Me.CommentsTextBox.Text = ""
            '
            'infoQCInformation
            '
            Me.infoQCInformation.Controls.Add(Me.Label5)
            Me.infoQCInformation.Controls.Add(Me.Label4)
            Me.infoQCInformation.Controls.Add(Me.SubjectButton)
            Me.infoQCInformation.Controls.Add(Me.txtSubject)
            Me.infoQCInformation.Controls.Add(Me.lblSentBy)
            Me.infoQCInformation.Controls.Add(Me.lblSentFrom)
            Me.infoQCInformation.Controls.Add(Me.Label3)
            Me.infoQCInformation.Location = New System.Drawing.Point(3, 876)
            Me.infoQCInformation.Name = "infoQCInformation"
            Me.infoQCInformation.Size = New System.Drawing.Size(239, 99)
            Me.infoQCInformation.TabIndex = 4
            Me.infoQCInformation.TabStop = False
            Me.infoQCInformation.Text = "Secondary Information"
            '
            'Label5
            '
            Me.Label5.AutoSize = True
            Me.Label5.Location = New System.Drawing.Point(10, 47)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(44, 13)
            Me.Label5.TabIndex = 10
            Me.Label5.Text = "Sent By"
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(10, 68)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(55, 13)
            Me.Label4.TabIndex = 9
            Me.Label4.Text = "Sent From"
            '
            'SubjectButton
            '
            Me.SubjectButton.Location = New System.Drawing.Point(207, 17)
            Me.SubjectButton.Name = "SubjectButton"
            Me.SubjectButton.Size = New System.Drawing.Size(24, 23)
            Me.SubjectButton.TabIndex = 8
            Me.SubjectButton.Text = "+"
            Me.SubjectButton.UseVisualStyleBackColor = True
            '
            'txtSubject
            '
            Me.txtSubject.Location = New System.Drawing.Point(75, 17)
            Me.txtSubject.Name = "txtSubject"
            Me.txtSubject.Size = New System.Drawing.Size(125, 20)
            Me.txtSubject.TabIndex = 7
            '
            'lblSentBy
            '
            Me.lblSentBy.AutoSize = True
            Me.lblSentBy.Location = New System.Drawing.Point(75, 45)
            Me.lblSentBy.Name = "lblSentBy"
            Me.lblSentBy.Size = New System.Drawing.Size(0, 13)
            Me.lblSentBy.TabIndex = 6
            '
            'lblSentFrom
            '
            Me.lblSentFrom.Location = New System.Drawing.Point(75, 67)
            Me.lblSentFrom.Name = "lblSentFrom"
            Me.lblSentFrom.Size = New System.Drawing.Size(156, 49)
            Me.lblSentFrom.TabIndex = 5
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(9, 23)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(43, 13)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Subject"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(9, 46)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(41, 13)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "SentBy"
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(9, 67)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(55, 13)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Sent From"
            '
            'simrButton
            '
            Me.simrButton.Location = New System.Drawing.Point(12, 707)
            Me.simrButton.Name = "simrButton"
            Me.simrButton.Size = New System.Drawing.Size(141, 46)
            Me.simrButton.TabIndex = 30
            Me.simrButton.Text = "SIMR"
            Me.simrButton.UseVisualStyleBackColor = True
            Me.simrButton.Visible = False
            '
            'scannerCheckBox
            '
            Me.scannerCheckBox.AutoSize = True
            Me.scannerCheckBox.Location = New System.Drawing.Point(13, 775)
            Me.scannerCheckBox.Name = "scannerCheckBox"
            Me.scannerCheckBox.Size = New System.Drawing.Size(94, 17)
            Me.scannerCheckBox.TabIndex = 32
            Me.scannerCheckBox.Text = "Scanner Lines"
            Me.scannerCheckBox.UseVisualStyleBackColor = True
            Me.scannerCheckBox.Visible = False
            '
            'CrookedCheckBox
            '
            Me.CrookedCheckBox.AutoSize = True
            Me.CrookedCheckBox.Location = New System.Drawing.Point(12, 798)
            Me.CrookedCheckBox.Name = "CrookedCheckBox"
            Me.CrookedCheckBox.Size = New System.Drawing.Size(66, 17)
            Me.CrookedCheckBox.TabIndex = 33
            Me.CrookedCheckBox.Text = "Crooked"
            Me.CrookedCheckBox.UseVisualStyleBackColor = True
            Me.CrookedCheckBox.Visible = False
            '
            'TearCheckBox
            '
            Me.TearCheckBox.AutoSize = True
            Me.TearCheckBox.Location = New System.Drawing.Point(12, 821)
            Me.TearCheckBox.Name = "TearCheckBox"
            Me.TearCheckBox.Size = New System.Drawing.Size(76, 17)
            Me.TearCheckBox.TabIndex = 34
            Me.TearCheckBox.Text = "Page Tear"
            Me.TearCheckBox.UseVisualStyleBackColor = True
            Me.TearCheckBox.Visible = False
            '
            'BleedCheckBox
            '
            Me.BleedCheckBox.AutoSize = True
            Me.BleedCheckBox.Location = New System.Drawing.Point(12, 844)
            Me.BleedCheckBox.Name = "BleedCheckBox"
            Me.BleedCheckBox.Size = New System.Drawing.Size(96, 17)
            Me.BleedCheckBox.TabIndex = 35
            Me.BleedCheckBox.Text = "Bleed Through"
            Me.BleedCheckBox.UseVisualStyleBackColor = True
            Me.BleedCheckBox.Visible = False
            '
            'BadCheckBox
            '
            Me.BadCheckBox.AutoSize = True
            Me.BadCheckBox.Location = New System.Drawing.Point(12, 867)
            Me.BadCheckBox.Name = "BadCheckBox"
            Me.BadCheckBox.Size = New System.Drawing.Size(73, 17)
            Me.BadCheckBox.TabIndex = 36
            Me.BadCheckBox.Text = "Bad Page"
            Me.BadCheckBox.UseVisualStyleBackColor = True
            Me.BadCheckBox.Visible = False
            '
            'CoverageValueLabel
            '
            Me.CoverageValueLabel.AutoSize = True
            Me.CoverageValueLabel.Location = New System.Drawing.Point(64, 316)
            Me.CoverageValueLabel.Name = "CoverageValueLabel"
            Me.CoverageValueLabel.Size = New System.Drawing.Size(25, 13)
            Me.CoverageValueLabel.TabIndex = 44
            Me.CoverageValueLabel.Text = "888"
            '
            'Label7
            '
            Me.Label7.AutoSize = True
            Me.Label7.Location = New System.Drawing.Point(10, 316)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(53, 13)
            Me.Label7.TabIndex = 43
            Me.Label7.Text = "Coverage"
            '
            'CircularIdLabel
            '
            Me.CircularIdLabel.AutoSize = True
            Me.CircularIdLabel.Location = New System.Drawing.Point(62, 44)
            Me.CircularIdLabel.Name = "CircularIdLabel"
            Me.CircularIdLabel.Size = New System.Drawing.Size(25, 13)
            Me.CircularIdLabel.TabIndex = 48
            Me.CircularIdLabel.Text = "888"
            '
            'Label8
            '
            Me.Label8.AutoSize = True
            Me.Label8.Location = New System.Drawing.Point(6, 44)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(54, 13)
            Me.Label8.TabIndex = 47
            Me.Label8.Text = "Circular Id"
            '
            'QCForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1113, 987)
            Me.Name = "QCForm"
            Me.infoManipGroupBox.ResumeLayout(False)
            Me.rightPanel.ResumeLayout(False)
            Me.rightPanel.PerformLayout()
            Me.imageNavigationGroupBox.ResumeLayout(False)
            Me.imageNavigationGroupBox.PerformLayout()
            Me.leftPanel.ResumeLayout(False)
            Me.leftPanel.PerformLayout()
            Me.vehicleGroupBox.ResumeLayout(False)
            Me.vehicleGroupBox.PerformLayout()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.familyTableLayoutPanel.ResumeLayout(False)
            CType(Me.dgThumbnails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.detailEntryOptionGroupBox.ResumeLayout(False)
            Me.detailEntryOptionGroupBox.PerformLayout()
            Me.infoQCInformation.ResumeLayout(False)
            Me.infoQCInformation.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents familyTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
        '' Friend WithEvents familyAxLEADImgList As AxLEADImgListLib.AxLEADImgList   \\ Comment By Denver : 168
        Friend WithEvents viewFamilyButton As System.Windows.Forms.Button
        Friend WithEvents flashAdCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents priorityValueLabel As System.Windows.Forms.Label
        Friend WithEvents priorityLabel As System.Windows.Forms.Label
        Friend WithEvents recaptureWebpageButton As System.Windows.Forms.Button
        Friend WithEvents nationalCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents detailEntryOptionGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents parentVehicleIdTextBox As System.Windows.Forms.TextBox
        Friend WithEvents parentVehicleIdLabel As System.Windows.Forms.Label
        Friend WithEvents flagForDetailEntryCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents showQcData As System.Windows.Forms.Button
        Friend WithEvents ViewThumbnails As System.Windows.Forms.Button
        Friend WithEvents CommentsTextBox As System.Windows.Forms.RichTextBox
        Friend WithEvents infoQCInformation As System.Windows.Forms.GroupBox
        Friend WithEvents txtSubject As System.Windows.Forms.TextBox
        Friend WithEvents lblSentBy As System.Windows.Forms.Label
        Friend WithEvents lblSentFrom As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents SubjectButton As System.Windows.Forms.Button
        Private WithEvents dgThumbnails As System.Windows.Forms.DataGridView
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents simrButton As System.Windows.Forms.Button
        Friend WithEvents BadCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents BleedCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents TearCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents CrookedCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents scannerCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents CoverageValueLabel As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents CircularIdLabel As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label

    End Class

End Namespace
