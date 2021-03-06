﻿Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PublicationDigitalPullForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PublicationDigitalPullForm))
            Me.completeButton = New System.Windows.Forms.Button()
            Me.noAdsCheckBox = New System.Windows.Forms.CheckBox()
            Me.yesButton = New System.Windows.Forms.Button()
            Me.noButton = New System.Windows.Forms.Button()
            Me.pageImageRequireGroupBox = New System.Windows.Forms.GroupBox()
            Me.currentStatusValueLabel = New System.Windows.Forms.Label()
            Me.currentStatusLabel = New System.Windows.Forms.Label()
            Me.requiredRetailersGroupBox = New System.Windows.Forms.GroupBox()
            Me.requiredRetailersDataGridView = New System.Windows.Forms.DataGridView()
            Me.splitImageButton = New System.Windows.Forms.Button()
            Me.infoManipGroupBox.SuspendLayout()
            Me.rightPanel.SuspendLayout()
            Me.imageNavigationGroupBox.SuspendLayout()
            Me.leftPanel.SuspendLayout()
            Me.vehicleGroupBox.SuspendLayout()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pageImageRequireGroupBox.SuspendLayout()
            Me.requiredRetailersGroupBox.SuspendLayout()
            CType(Me.requiredRetailersDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'infoManipGroupBox
            '
            Me.infoManipGroupBox.Size = New System.Drawing.Size(194, 140)
            Me.infoManipGroupBox.Visible = False
            '
            'rightPanel
            '
            Me.rightPanel.Controls.Add(Me.splitImageButton)
            Me.rightPanel.Controls.Add(Me.pageImageRequireGroupBox)
            Me.rightPanel.Location = New System.Drawing.Point(898, 0)
            Me.rightPanel.Size = New System.Drawing.Size(167, 741)
            Me.rightPanel.Controls.SetChildIndex(Me.DrawRectangleButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.imageSearchGroupBox, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.imageRotationGroupBox, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.keepRectangleButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.zoomButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.removeRectangleButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.saveImageButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.refreshButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.deleteImageButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.resequenceButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.pageCropIdLabel, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.pageIdLabel, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.imageNavigationGroupBox, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.exitButton, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.pageImageRequireGroupBox, 0)
            Me.rightPanel.Controls.SetChildIndex(Me.splitImageButton, 0)
            '
            'indexStatusTextLabel
            '
            Me.indexStatusTextLabel.Location = New System.Drawing.Point(63, 181)
            Me.indexStatusTextLabel.Visible = False
            '
            'indexStatusLabel
            '
            Me.indexStatusLabel.Location = New System.Drawing.Point(7, 181)
            Me.indexStatusLabel.Visible = False
            '
            'qcStatusTextLabel
            '
            Me.qcStatusTextLabel.Location = New System.Drawing.Point(66, 220)
            '
            'qcStatusLabel
            '
            Me.qcStatusLabel.Location = New System.Drawing.Point(9, 220)
            '
            'exitButton
            '
            Me.exitButton.Location = New System.Drawing.Point(16, 649)
            '
            'imageRotationGroupBox
            '
            Me.imageRotationGroupBox.Location = New System.Drawing.Point(9, 305)
            '
            'deleteImageButton
            '
            Me.deleteImageButton.Location = New System.Drawing.Point(16, 591)
            '
            'refreshButton
            '
            Me.refreshButton.Location = New System.Drawing.Point(16, 562)
            '
            'saveImageButton
            '
            Me.saveImageButton.Location = New System.Drawing.Point(16, 533)
            '
            'removeRectangleButton
            '
            Me.removeRectangleButton.Location = New System.Drawing.Point(16, 476)
            '
            'zoomButton
            '
            Me.zoomButton.Location = New System.Drawing.Point(16, 447)
            '
            'keepRectangleButton
            '
            Me.keepRectangleButton.Location = New System.Drawing.Point(16, 418)
            '
            'resequenceButton
            '
            Me.resequenceButton.Location = New System.Drawing.Point(16, 621)
            '
            'pageCropIdLabel
            '
            Me.pageCropIdLabel.Location = New System.Drawing.Point(20, 684)
            '
            'pageIdLabel
            '
            Me.pageIdLabel.Location = New System.Drawing.Point(65, 684)
            '
            'DrawRectangleButton
            '
            Me.DrawRectangleButton.Location = New System.Drawing.Point(16, 505)
            '
            'leftPanel
            '
            Me.leftPanel.Controls.Add(Me.completeButton)
            Me.leftPanel.Controls.Add(Me.noAdsCheckBox)
            Me.leftPanel.Controls.Add(Me.requiredRetailersGroupBox)
            Me.leftPanel.Size = New System.Drawing.Size(248, 741)
            Me.leftPanel.Controls.SetChildIndex(Me.requiredRetailersGroupBox, 0)
            Me.leftPanel.Controls.SetChildIndex(Me.noAdsCheckBox, 0)
            Me.leftPanel.Controls.SetChildIndex(Me.completeButton, 0)
            Me.leftPanel.Controls.SetChildIndex(Me.vehicleGroupBox, 0)
            Me.leftPanel.Controls.SetChildIndex(Me.infoManipGroupBox, 0)
            '
            'vehicleGroupBox
            '
            Me.vehicleGroupBox.Size = New System.Drawing.Size(241, 153)
            '
            'definePagesButton
            '
            Me.definePagesButton.Visible = False
            '
            'languageComboBox
            '
            Me.languageComboBox.Location = New System.Drawing.Point(66, 101)
            Me.languageComboBox.TabIndex = 7
            '
            'languageLabel
            '
            Me.languageLabel.Location = New System.Drawing.Point(7, 104)
            Me.languageLabel.TabIndex = 6
            '
            'pagesLabel
            '
            Me.pagesLabel.Visible = False
            '
            'endDateTypeInDatePicker
            '
            Me.endDateTypeInDatePicker.Visible = False
            '
            'endDateLabel
            '
            Me.endDateLabel.Visible = False
            '
            'startDateTypeInDatePicker
            '
            Me.startDateTypeInDatePicker.Visible = False
            '
            'startDateLabel
            '
            Me.startDateLabel.Visible = False
            '
            'themeComboBox
            '
            Me.themeComboBox.Visible = False
            '
            'themeLabel
            '
            Me.themeLabel.Visible = False
            '
            'eventComboBox
            '
            Me.eventComboBox.Visible = False
            '
            'eventLabel
            '
            Me.eventLabel.Visible = False
            '
            'tradeclassValueLabel
            '
            Me.tradeclassValueLabel.Location = New System.Drawing.Point(65, 281)
            Me.tradeclassValueLabel.Visible = False
            '
            'tradeclassLabel
            '
            Me.tradeclassLabel.Location = New System.Drawing.Point(9, 281)
            Me.tradeclassLabel.Visible = False
            '
            'retailerComboBox
            '
            Me.retailerComboBox.Location = New System.Drawing.Point(68, 253)
            Me.retailerComboBox.Visible = False
            '
            'retailerLabel
            '
            Me.retailerLabel.Location = New System.Drawing.Point(9, 256)
            Me.retailerLabel.Visible = False
            '
            'publicationComboBox
            '
            Me.publicationComboBox.Location = New System.Drawing.Point(66, 74)
            Me.publicationComboBox.TabIndex = 5
            '
            'publicationLabel
            '
            Me.publicationLabel.Location = New System.Drawing.Point(7, 77)
            Me.publicationLabel.TabIndex = 4
            '
            'marketComboBox
            '
            Me.marketComboBox.Location = New System.Drawing.Point(66, 47)
            Me.marketComboBox.TabIndex = 3
            '
            'marketLabel
            '
            Me.marketLabel.Location = New System.Drawing.Point(7, 50)
            Me.marketLabel.TabIndex = 2
            '
            'mediaComboBox
            '
            Me.mediaComboBox.Location = New System.Drawing.Point(66, 155)
            Me.mediaComboBox.Visible = False
            '
            'mediaLabel
            '
            Me.mediaLabel.Location = New System.Drawing.Point(7, 158)
            Me.mediaLabel.Visible = False
            '
            'adDateTypeInDatePicker
            '
            Me.adDateTypeInDatePicker.Location = New System.Drawing.Point(66, 128)
            '
            'adDateLabel
            '
            Me.adDateLabel.Location = New System.Drawing.Point(7, 131)
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'completeButton
            '
            Me.completeButton.Location = New System.Drawing.Point(36, 661)
            Me.completeButton.Name = "completeButton"
            Me.completeButton.Size = New System.Drawing.Size(177, 23)
            Me.completeButton.TabIndex = 3
            Me.completeButton.Text = "Complete"
            Me.completeButton.UseVisualStyleBackColor = True
            '
            'noAdsCheckBox
            '
            Me.noAdsCheckBox.AutoSize = True
            Me.noAdsCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.noAdsCheckBox.Location = New System.Drawing.Point(14, 638)
            Me.noAdsCheckBox.Name = "noAdsCheckBox"
            Me.noAdsCheckBox.Size = New System.Drawing.Size(61, 17)
            Me.noAdsCheckBox.TabIndex = 4
            Me.noAdsCheckBox.Text = "No Ads"
            Me.noAdsCheckBox.UseVisualStyleBackColor = True
            '
            'yesButton
            '
            Me.yesButton.Location = New System.Drawing.Point(7, 29)
            Me.yesButton.Name = "yesButton"
            Me.yesButton.Size = New System.Drawing.Size(67, 23)
            Me.yesButton.TabIndex = 16
            Me.yesButton.Text = "&Yes"
            Me.yesButton.UseVisualStyleBackColor = True
            '
            'noButton
            '
            Me.noButton.Location = New System.Drawing.Point(81, 29)
            Me.noButton.Name = "noButton"
            Me.noButton.Size = New System.Drawing.Size(67, 23)
            Me.noButton.TabIndex = 17
            Me.noButton.Text = "&No"
            Me.noButton.UseVisualStyleBackColor = True
            '
            'pageImageRequireGroupBox
            '
            Me.pageImageRequireGroupBox.Controls.Add(Me.currentStatusValueLabel)
            Me.pageImageRequireGroupBox.Controls.Add(Me.currentStatusLabel)
            Me.pageImageRequireGroupBox.Controls.Add(Me.yesButton)
            Me.pageImageRequireGroupBox.Controls.Add(Me.noButton)
            Me.pageImageRequireGroupBox.Location = New System.Drawing.Point(6, 207)
            Me.pageImageRequireGroupBox.Name = "pageImageRequireGroupBox"
            Me.pageImageRequireGroupBox.Size = New System.Drawing.Size(155, 87)
            Me.pageImageRequireGroupBox.TabIndex = 18
            Me.pageImageRequireGroupBox.TabStop = False
            Me.pageImageRequireGroupBox.Text = "Page Image Required?"
            '
            'currentStatusValueLabel
            '
            Me.currentStatusValueLabel.AutoSize = True
            Me.currentStatusValueLabel.Location = New System.Drawing.Point(90, 62)
            Me.currentStatusValueLabel.Name = "currentStatusValueLabel"
            Me.currentStatusValueLabel.Size = New System.Drawing.Size(107, 13)
            Me.currentStatusValueLabel.TabIndex = 19
            Me.currentStatusValueLabel.Text = "<Yes/No/Unknown>"
            '
            'currentStatusLabel
            '
            Me.currentStatusLabel.AutoSize = True
            Me.currentStatusLabel.Location = New System.Drawing.Point(6, 62)
            Me.currentStatusLabel.Name = "currentStatusLabel"
            Me.currentStatusLabel.Size = New System.Drawing.Size(77, 13)
            Me.currentStatusLabel.TabIndex = 18
            Me.currentStatusLabel.Text = "Current Status:"
            '
            'requiredRetailersGroupBox
            '
            Me.requiredRetailersGroupBox.Controls.Add(Me.requiredRetailersDataGridView)
            Me.requiredRetailersGroupBox.Location = New System.Drawing.Point(4, 225)
            Me.requiredRetailersGroupBox.Name = "requiredRetailersGroupBox"
            Me.requiredRetailersGroupBox.Size = New System.Drawing.Size(241, 403)
            Me.requiredRetailersGroupBox.TabIndex = 5
            Me.requiredRetailersGroupBox.TabStop = False
            Me.requiredRetailersGroupBox.Text = "Required Retailers"
            '
            'requiredRetailersDataGridView
            '
            Me.requiredRetailersDataGridView.AllowUserToAddRows = False
            Me.requiredRetailersDataGridView.AllowUserToDeleteRows = False
            Me.requiredRetailersDataGridView.AllowUserToResizeColumns = False
            Me.requiredRetailersDataGridView.AllowUserToResizeRows = False
            Me.requiredRetailersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.requiredRetailersDataGridView.Location = New System.Drawing.Point(9, 23)
            Me.requiredRetailersDataGridView.Name = "requiredRetailersDataGridView"
            Me.requiredRetailersDataGridView.ReadOnly = True
            Me.requiredRetailersDataGridView.Size = New System.Drawing.Size(220, 374)
            Me.requiredRetailersDataGridView.TabIndex = 6
            Me.requiredRetailersDataGridView.TabStop = False
            '
            'splitImageButton
            '
            Me.splitImageButton.Location = New System.Drawing.Point(13, 528)
            Me.splitImageButton.Name = "splitImageButton"
            Me.splitImageButton.Size = New System.Drawing.Size(141, 23)
            Me.splitImageButton.TabIndex = 19
            Me.splitImageButton.Text = "Split Image"
            Me.splitImageButton.UseVisualStyleBackColor = True
            '
            'PublicationDigitalPullForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(1065, 741)
            Me.Name = "PublicationDigitalPullForm"
            Me.Text = "Digital Publication Pull"
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
            Me.pageImageRequireGroupBox.ResumeLayout(False)
            Me.pageImageRequireGroupBox.PerformLayout()
            Me.requiredRetailersGroupBox.ResumeLayout(False)
            CType(Me.requiredRetailersDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents completeButton As System.Windows.Forms.Button
        Friend WithEvents noAdsCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents yesButton As System.Windows.Forms.Button
        Friend WithEvents noButton As System.Windows.Forms.Button
        Friend WithEvents pageImageRequireGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents currentStatusLabel As System.Windows.Forms.Label
        Friend WithEvents currentStatusValueLabel As System.Windows.Forms.Label
        Friend WithEvents requiredRetailersGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents requiredRetailersDataGridView As System.Windows.Forms.DataGridView
        Friend WithEvents splitImageButton As System.Windows.Forms.Button

    End Class

End Namespace
