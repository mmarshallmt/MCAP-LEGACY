﻿Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class PublicationNotDroppedForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PublicationNotDroppedForm))
            Me.closeButton = New System.Windows.Forms.Button()
            Me.clearButton = New System.Windows.Forms.Button()
            Me.pubInfoGroupBox = New System.Windows.Forms.GroupBox()
            Me.checkedInByLabel = New System.Windows.Forms.Label()
            Me.checkedInByValueLabel = New System.Windows.Forms.Label()
            Me.marketLabel = New System.Windows.Forms.Label()
            Me.marketComboBox = New System.Windows.Forms.ComboBox()
            Me.newspaperLabel = New System.Windows.Forms.Label()
            Me.newspaperComboBox = New System.Windows.Forms.ComboBox()
            Me.checkInMonthCalendar = New System.Windows.Forms.MonthCalendar()
            Me.breakDateListBox = New System.Windows.Forms.ListBox()
            Me.clearDatesButton = New System.Windows.Forms.Button()
            Me.newButton = New System.Windows.Forms.Button()
            Me.deleteButton = New System.Windows.Forms.Button()
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
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
            'closeButton
            '
            Me.closeButton.Location = New System.Drawing.Point(314, 285)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(75, 23)
            Me.closeButton.TabIndex = 4
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'clearButton
            '
            Me.clearButton.Location = New System.Drawing.Point(152, 285)
            Me.clearButton.Name = "clearButton"
            Me.clearButton.Size = New System.Drawing.Size(75, 23)
            Me.clearButton.TabIndex = 3
            Me.clearButton.Text = "&Clear"
            Me.clearButton.UseVisualStyleBackColor = True
            '
            'pubInfoGroupBox
            '
            Me.pubInfoGroupBox.Controls.Add(Me.checkedInByLabel)
            Me.pubInfoGroupBox.Controls.Add(Me.checkedInByValueLabel)
            Me.pubInfoGroupBox.Controls.Add(Me.marketLabel)
            Me.pubInfoGroupBox.Controls.Add(Me.marketComboBox)
            Me.pubInfoGroupBox.Controls.Add(Me.newspaperLabel)
            Me.pubInfoGroupBox.Controls.Add(Me.newspaperComboBox)
            Me.pubInfoGroupBox.Controls.Add(Me.checkInMonthCalendar)
            Me.pubInfoGroupBox.Controls.Add(Me.breakDateListBox)
            Me.pubInfoGroupBox.Controls.Add(Me.clearDatesButton)
            Me.pubInfoGroupBox.Location = New System.Drawing.Point(12, 12)
            Me.pubInfoGroupBox.Name = "pubInfoGroupBox"
            Me.pubInfoGroupBox.Size = New System.Drawing.Size(398, 267)
            Me.pubInfoGroupBox.TabIndex = 0
            Me.pubInfoGroupBox.TabStop = False
            Me.pubInfoGroupBox.Text = "Publication Information"
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
            'marketLabel
            '
            Me.marketLabel.AutoSize = True
            Me.marketLabel.Location = New System.Drawing.Point(27, 53)
            Me.marketLabel.Name = "marketLabel"
            Me.marketLabel.Size = New System.Drawing.Size(40, 13)
            Me.marketLabel.TabIndex = 2
            Me.marketLabel.Text = "&Market"
            '
            'marketComboBox
            '
            Me.marketComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.marketComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.marketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.marketComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.marketComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.marketComboBox.Location = New System.Drawing.Point(73, 50)
            Me.marketComboBox.Name = "marketComboBox"
            Me.marketComboBox.Size = New System.Drawing.Size(279, 21)
            Me.marketComboBox.TabIndex = 3
            '
            'newspaperLabel
            '
            Me.newspaperLabel.AutoSize = True
            Me.newspaperLabel.Location = New System.Drawing.Point(6, 80)
            Me.newspaperLabel.Name = "newspaperLabel"
            Me.newspaperLabel.Size = New System.Drawing.Size(61, 13)
            Me.newspaperLabel.TabIndex = 4
            Me.newspaperLabel.Text = "Ne&wspaper"
            '
            'newspaperComboBox
            '
            Me.newspaperComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
            Me.newspaperComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.newspaperComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.newspaperComboBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.newspaperComboBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.newspaperComboBox.Location = New System.Drawing.Point(73, 77)
            Me.newspaperComboBox.Name = "newspaperComboBox"
            Me.newspaperComboBox.Size = New System.Drawing.Size(279, 21)
            Me.newspaperComboBox.TabIndex = 5
            '
            'checkInMonthCalendar
            '
            Me.checkInMonthCalendar.AllowDrop = True
            Me.checkInMonthCalendar.Location = New System.Drawing.Point(73, 102)
            Me.checkInMonthCalendar.Name = "checkInMonthCalendar"
            Me.checkInMonthCalendar.TabIndex = 6
            '
            'breakDateListBox
            '
            Me.breakDateListBox.FormattingEnabled = True
            Me.m_ErrorProvider.SetIconAlignment(Me.breakDateListBox, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.breakDateListBox.Location = New System.Drawing.Point(303, 104)
            Me.breakDateListBox.Name = "breakDateListBox"
            Me.breakDateListBox.Size = New System.Drawing.Size(86, 121)
            Me.breakDateListBox.TabIndex = 7
            '
            'clearDatesButton
            '
            Me.clearDatesButton.Location = New System.Drawing.Point(303, 236)
            Me.clearDatesButton.Name = "clearDatesButton"
            Me.clearDatesButton.Size = New System.Drawing.Size(86, 23)
            Me.clearDatesButton.TabIndex = 8
            Me.clearDatesButton.Text = "&Remove"
            Me.clearDatesButton.UseVisualStyleBackColor = True
            '
            'newButton
            '
            Me.newButton.Location = New System.Drawing.Point(12, 285)
            Me.newButton.Name = "newButton"
            Me.newButton.Size = New System.Drawing.Size(134, 23)
            Me.newButton.TabIndex = 1
            Me.newButton.Text = "Chec&k In - Not Dropped"
            Me.newButton.UseVisualStyleBackColor = True
            '
            'deleteButton
            '
            Me.deleteButton.Location = New System.Drawing.Point(233, 285)
            Me.deleteButton.Name = "deleteButton"
            Me.deleteButton.Size = New System.Drawing.Size(75, 23)
            Me.deleteButton.TabIndex = 2
            Me.deleteButton.Text = "Delete"
            Me.deleteButton.UseVisualStyleBackColor = True
            Me.deleteButton.Visible = False
            '
            'PublicationNotDroppedForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(415, 315)
            Me.Controls.Add(Me.deleteButton)
            Me.Controls.Add(Me.closeButton)
            Me.Controls.Add(Me.clearButton)
            Me.Controls.Add(Me.pubInfoGroupBox)
            Me.Controls.Add(Me.newButton)
            Me.MaximizeBox = False
            Me.Name = "PublicationNotDroppedForm"
            Me.StatusMessage = ""
            Me.Text = "Publication Not Dropped"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pubInfoGroupBox.ResumeLayout(False)
            Me.pubInfoGroupBox.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents clearButton As System.Windows.Forms.Button
    Friend WithEvents pubInfoGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents checkedInByLabel As System.Windows.Forms.Label
    Friend WithEvents checkedInByValueLabel As System.Windows.Forms.Label
    Friend WithEvents marketLabel As System.Windows.Forms.Label
    Friend WithEvents marketComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents newspaperLabel As System.Windows.Forms.Label
    Friend WithEvents newspaperComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents checkInMonthCalendar As System.Windows.Forms.MonthCalendar
    Friend WithEvents breakDateListBox As System.Windows.Forms.ListBox
    Friend WithEvents clearDatesButton As System.Windows.Forms.Button
    Friend WithEvents newButton As System.Windows.Forms.Button
    Friend WithEvents deleteButton As System.Windows.Forms.Button

  End Class

End Namespace