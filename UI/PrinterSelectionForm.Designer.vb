Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class PrinterSelectionForm
    Inherits UI.BaseForm

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrinterSelectionForm))
      Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Local Printer(s)", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Network Printer(s)", System.Windows.Forms.HorizontalAlignment.Left)
      Me.printerListView = New System.Windows.Forms.ListView
      Me.nameColumnHeader = New System.Windows.Forms.ColumnHeader
      Me.systemNameColumnHeader = New System.Windows.Forms.ColumnHeader
      Me.statusColumnHeader = New System.Windows.Forms.ColumnHeader
      Me.refreshButton = New System.Windows.Forms.Button
      Me.okButton = New System.Windows.Forms.Button
      Me.cancelButton = New System.Windows.Forms.Button
      Me.statusLabel = New System.Windows.Forms.Label
      Me.printerNameLabel = New System.Windows.Forms.Label
      Me.printerNameValueLabel = New System.Windows.Forms.Label
      CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'smalliconImageList
      '
      Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
      Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
      Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
      '
      'printerListView
      '
      Me.printerListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.nameColumnHeader, Me.systemNameColumnHeader, Me.statusColumnHeader})
      Me.printerListView.FullRowSelect = True
      ListViewGroup1.Header = "Local Printer(s)"
      ListViewGroup1.Name = "localListViewGroup"
      ListViewGroup2.Header = "Network Printer(s)"
      ListViewGroup2.Name = "networkListViewGroup"
      Me.printerListView.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2})
      Me.printerListView.Location = New System.Drawing.Point(12, 36)
      Me.printerListView.MultiSelect = False
      Me.printerListView.Name = "printerListView"
      Me.printerListView.ShowItemToolTips = True
      Me.printerListView.Size = New System.Drawing.Size(510, 349)
      Me.printerListView.SmallImageList = Me.smalliconImageList
      Me.printerListView.TabIndex = 0
      Me.printerListView.UseCompatibleStateImageBehavior = False
      Me.printerListView.View = System.Windows.Forms.View.Details
      '
      'nameColumnHeader
      '
      Me.nameColumnHeader.Text = "Name"
      Me.nameColumnHeader.Width = 249
      '
      'systemNameColumnHeader
      '
      Me.systemNameColumnHeader.Text = "Computer Name"
      Me.systemNameColumnHeader.Width = 172
      '
      'statusColumnHeader
      '
      Me.statusColumnHeader.Text = "Printer Status"
      Me.statusColumnHeader.Width = 85
      '
      'refreshButton
      '
      Me.refreshButton.Location = New System.Drawing.Point(12, 391)
      Me.refreshButton.Name = "refreshButton"
      Me.refreshButton.Size = New System.Drawing.Size(75, 23)
      Me.refreshButton.TabIndex = 1
      Me.refreshButton.Text = "&Refresh"
      Me.refreshButton.UseVisualStyleBackColor = True
      '
      'okButton
      '
      Me.okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.okButton.Location = New System.Drawing.Point(366, 391)
      Me.okButton.Name = "okButton"
      Me.okButton.Size = New System.Drawing.Size(75, 23)
      Me.okButton.TabIndex = 2
      Me.okButton.Text = "&OK"
      Me.okButton.UseVisualStyleBackColor = True
      '
      'cancelButton
      '
      Me.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cancelButton.Location = New System.Drawing.Point(447, 391)
      Me.cancelButton.Name = "cancelButton"
      Me.cancelButton.Size = New System.Drawing.Size(75, 23)
      Me.cancelButton.TabIndex = 3
      Me.cancelButton.Text = "&Cancel"
      Me.cancelButton.UseVisualStyleBackColor = True
      '
      'statusLabel
      '
      Me.statusLabel.Location = New System.Drawing.Point(171, 166)
      Me.statusLabel.Name = "statusLabel"
      Me.statusLabel.Size = New System.Drawing.Size(193, 94)
      Me.statusLabel.TabIndex = 4
      Me.statusLabel.Text = "Preparing list of available printers... Please wait..."
      Me.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.statusLabel.Visible = False
      '
      'printerNameLabel
      '
      Me.printerNameLabel.AutoSize = True
      Me.printerNameLabel.Location = New System.Drawing.Point(12, 9)
      Me.printerNameLabel.Name = "printerNameLabel"
      Me.printerNameLabel.Size = New System.Drawing.Size(90, 13)
      Me.printerNameLabel.TabIndex = 5
      Me.printerNameLabel.Text = "Existing Selection"
      '
      'printerNameValueLabel
      '
      Me.printerNameValueLabel.AutoSize = True
      Me.printerNameValueLabel.Location = New System.Drawing.Point(108, 9)
      Me.printerNameValueLabel.Name = "printerNameValueLabel"
      Me.printerNameValueLabel.Size = New System.Drawing.Size(53, 13)
      Me.printerNameValueLabel.TabIndex = 6
      Me.printerNameValueLabel.Text = "Unknown"
      '
      'PrinterSelectionForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(534, 426)
      Me.Controls.Add(Me.printerNameValueLabel)
      Me.Controls.Add(Me.printerNameLabel)
      Me.Controls.Add(Me.statusLabel)
      Me.Controls.Add(Me.cancelButton)
      Me.Controls.Add(Me.okButton)
      Me.Controls.Add(Me.refreshButton)
      Me.Controls.Add(Me.printerListView)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "PrinterSelectionForm"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Printer Selection"
      CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub
    Friend WithEvents printerListView As System.Windows.Forms.ListView
    Friend WithEvents refreshButton As System.Windows.Forms.Button
    Friend WithEvents nameColumnHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents systemNameColumnHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents statusColumnHeader As System.Windows.Forms.ColumnHeader
    Friend WithEvents okButton As System.Windows.Forms.Button
    Friend WithEvents cancelButton As System.Windows.Forms.Button
    Friend WithEvents statusLabel As System.Windows.Forms.Label
    Friend WithEvents printerNameLabel As System.Windows.Forms.Label
    Friend WithEvents printerNameValueLabel As System.Windows.Forms.Label

  End Class

End Namespace