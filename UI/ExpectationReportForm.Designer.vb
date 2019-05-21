﻿Namespace UI

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ExpectationReportForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExpectationReportForm))
            Me.selfRadioButton = New System.Windows.Forms.RadioButton
            Me.pickfromlistRadioButton = New System.Windows.Forms.RadioButton
            Me.emailGroupBox = New System.Windows.Forms.GroupBox
            Me.userListView = New System.Windows.Forms.ListView
            Me.usernameColumnHeader = New System.Windows.Forms.ColumnHeader
            Me.emailColumnHeader = New System.Windows.Forms.ColumnHeader
            Me.Label1 = New System.Windows.Forms.Label
            Me.requestButton = New System.Windows.Forms.Button
            Me.closeButton = New System.Windows.Forms.Button
            Me.priorityGroupBox = New System.Windows.Forms.GroupBox
            Me.priorityotherCheckBox = New System.Windows.Forms.CheckBox
            Me.prioritytwoCheckBox = New System.Windows.Forms.CheckBox
            Me.priorityoneCheckBox = New System.Windows.Forms.CheckBox
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.emailGroupBox.SuspendLayout()
            Me.priorityGroupBox.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'selfRadioButton
            '
            Me.selfRadioButton.AutoSize = True
            Me.selfRadioButton.Checked = True
            Me.selfRadioButton.Location = New System.Drawing.Point(89, 69)
            Me.selfRadioButton.Name = "selfRadioButton"
            Me.selfRadioButton.Size = New System.Drawing.Size(43, 17)
            Me.selfRadioButton.TabIndex = 3
            Me.selfRadioButton.TabStop = True
            Me.selfRadioButton.Text = "&Self"
            Me.selfRadioButton.UseVisualStyleBackColor = True
            '
            'pickfromlistRadioButton
            '
            Me.pickfromlistRadioButton.AutoSize = True
            Me.pickfromlistRadioButton.Location = New System.Drawing.Point(89, 92)
            Me.pickfromlistRadioButton.Name = "pickfromlistRadioButton"
            Me.pickfromlistRadioButton.Size = New System.Drawing.Size(84, 17)
            Me.pickfromlistRadioButton.TabIndex = 4
            Me.pickfromlistRadioButton.TabStop = True
            Me.pickfromlistRadioButton.Text = "Pick from &list"
            Me.pickfromlistRadioButton.UseVisualStyleBackColor = True
            '
            'emailGroupBox
            '
            Me.emailGroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.emailGroupBox.Controls.Add(Me.userListView)
            Me.emailGroupBox.Enabled = False
            Me.emailGroupBox.Location = New System.Drawing.Point(74, 94)
            Me.emailGroupBox.Name = "emailGroupBox"
            Me.emailGroupBox.Size = New System.Drawing.Size(518, 316)
            Me.emailGroupBox.TabIndex = 5
            Me.emailGroupBox.TabStop = False
            '
            'userListView
            '
            Me.userListView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.userListView.CheckBoxes = True
            Me.userListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.usernameColumnHeader, Me.emailColumnHeader})
            Me.userListView.FullRowSelect = True
            Me.userListView.Location = New System.Drawing.Point(6, 21)
            Me.userListView.MultiSelect = False
            Me.userListView.Name = "userListView"
            Me.userListView.Size = New System.Drawing.Size(506, 289)
            Me.userListView.TabIndex = 0
            Me.userListView.UseCompatibleStateImageBehavior = False
            Me.userListView.View = System.Windows.Forms.View.Details
            '
            'usernameColumnHeader
            '
            Me.usernameColumnHeader.Text = "User name"
            Me.usernameColumnHeader.Width = 250
            '
            'emailColumnHeader
            '
            Me.emailColumnHeader.Text = "Email Address"
            Me.emailColumnHeader.Width = 250
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(12, 73)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(55, 13)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Recipient:"
            '
            'requestButton
            '
            Me.requestButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.requestButton.Location = New System.Drawing.Point(436, 416)
            Me.requestButton.Name = "requestButton"
            Me.requestButton.Size = New System.Drawing.Size(75, 23)
            Me.requestButton.TabIndex = 6
            Me.requestButton.Text = "&Request"
            Me.requestButton.UseVisualStyleBackColor = True
            '
            'closeButton
            '
            Me.closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.closeButton.Location = New System.Drawing.Point(517, 416)
            Me.closeButton.Name = "closeButton"
            Me.closeButton.Size = New System.Drawing.Size(75, 23)
            Me.closeButton.TabIndex = 7
            Me.closeButton.Text = "Cl&ose"
            Me.closeButton.UseVisualStyleBackColor = True
            '
            'priorityGroupBox
            '
            Me.priorityGroupBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.priorityGroupBox.Controls.Add(Me.priorityotherCheckBox)
            Me.priorityGroupBox.Controls.Add(Me.prioritytwoCheckBox)
            Me.priorityGroupBox.Controls.Add(Me.priorityoneCheckBox)
            Me.priorityGroupBox.Location = New System.Drawing.Point(12, 12)
            Me.priorityGroupBox.Name = "priorityGroupBox"
            Me.priorityGroupBox.Size = New System.Drawing.Size(580, 44)
            Me.priorityGroupBox.TabIndex = 8
            Me.priorityGroupBox.TabStop = False
            Me.priorityGroupBox.Text = "Priority"
            '
            'priorityotherCheckBox
            '
            Me.priorityotherCheckBox.AutoSize = True
            Me.priorityotherCheckBox.Location = New System.Drawing.Point(197, 19)
            Me.priorityotherCheckBox.Name = "priorityotherCheckBox"
            Me.priorityotherCheckBox.Size = New System.Drawing.Size(178, 17)
            Me.priorityotherCheckBox.TabIndex = 2
            Me.priorityotherCheckBox.Text = "Pr&iorities other than one and two"
            Me.priorityotherCheckBox.UseVisualStyleBackColor = True
            '
            'prioritytwoCheckBox
            '
            Me.prioritytwoCheckBox.AutoSize = True
            Me.prioritytwoCheckBox.Location = New System.Drawing.Point(101, 19)
            Me.prioritytwoCheckBox.Name = "prioritytwoCheckBox"
            Me.prioritytwoCheckBox.Size = New System.Drawing.Size(81, 17)
            Me.prioritytwoCheckBox.TabIndex = 1
            Me.prioritytwoCheckBox.Text = "Priority T&wo"
            Me.prioritytwoCheckBox.UseVisualStyleBackColor = True
            '
            'priorityoneCheckBox
            '
            Me.priorityoneCheckBox.AutoSize = True
            Me.priorityoneCheckBox.Location = New System.Drawing.Point(6, 19)
            Me.priorityoneCheckBox.Name = "priorityoneCheckBox"
            Me.priorityoneCheckBox.Size = New System.Drawing.Size(80, 17)
            Me.priorityoneCheckBox.TabIndex = 0
            Me.priorityoneCheckBox.Text = "Priority O&ne"
            Me.priorityoneCheckBox.UseVisualStyleBackColor = True
            '
            'ExpectationReportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(604, 451)
            Me.Controls.Add(Me.priorityGroupBox)
            Me.Controls.Add(Me.pickfromlistRadioButton)
            Me.Controls.Add(Me.closeButton)
            Me.Controls.Add(Me.requestButton)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.selfRadioButton)
            Me.Controls.Add(Me.emailGroupBox)
            Me.Name = "ExpectationReportForm"
            Me.StatusMessage = ""
            Me.Text = "Expectation Report"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.emailGroupBox.ResumeLayout(False)
            Me.priorityGroupBox.ResumeLayout(False)
            Me.priorityGroupBox.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents selfRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents pickfromlistRadioButton As System.Windows.Forms.RadioButton
        Friend WithEvents emailGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents requestButton As System.Windows.Forms.Button
        Friend WithEvents closeButton As System.Windows.Forms.Button
        Friend WithEvents userListView As System.Windows.Forms.ListView
        Friend WithEvents usernameColumnHeader As System.Windows.Forms.ColumnHeader
        Friend WithEvents emailColumnHeader As System.Windows.Forms.ColumnHeader
        Friend WithEvents priorityGroupBox As System.Windows.Forms.GroupBox
        Friend WithEvents priorityotherCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents prioritytwoCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents priorityoneCheckBox As System.Windows.Forms.CheckBox
    End Class

End Namespace