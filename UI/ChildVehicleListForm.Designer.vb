<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChildVehicleListForm
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChildVehicleListForm))
    Me.mainTextBox = New System.Windows.Forms.TextBox
    Me.vehicleListView = New System.Windows.Forms.ListView
    Me.vehicleIdColumnHeader = New System.Windows.Forms.ColumnHeader
    Me.noteColumnHeader = New System.Windows.Forms.ColumnHeader
    Me.bottomTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
    Me.closeButton = New System.Windows.Forms.Button
    CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.bottomTableLayoutPanel.SuspendLayout()
    Me.SuspendLayout()
    '
    'smalliconImageList
    '
    Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
    Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
    Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
    '
    'mainTextBox
    '
    Me.mainTextBox.Dock = System.Windows.Forms.DockStyle.Top
    Me.mainTextBox.Location = New System.Drawing.Point(0, 0)
    Me.mainTextBox.Multiline = True
    Me.mainTextBox.Name = "mainTextBox"
    Me.mainTextBox.ReadOnly = True
    Me.mainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.mainTextBox.Size = New System.Drawing.Size(760, 47)
    Me.mainTextBox.TabIndex = 0
    Me.mainTextBox.TabStop = False
    '
    'vehicleListView
    '
    Me.vehicleListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.vehicleIdColumnHeader, Me.noteColumnHeader})
    Me.vehicleListView.Dock = System.Windows.Forms.DockStyle.Fill
    Me.vehicleListView.Location = New System.Drawing.Point(0, 47)
    Me.vehicleListView.Name = "vehicleListView"
    Me.vehicleListView.Size = New System.Drawing.Size(760, 285)
    Me.vehicleListView.TabIndex = 1
    Me.vehicleListView.UseCompatibleStateImageBehavior = False
    Me.vehicleListView.View = System.Windows.Forms.View.Details
    '
    'vehicleIdColumnHeader
    '
    Me.vehicleIdColumnHeader.Text = "Vehicle Id"
    Me.vehicleIdColumnHeader.Width = 100
    '
    'noteColumnHeader
    '
    Me.noteColumnHeader.Text = "Note"
    Me.noteColumnHeader.Width = 650
    '
    'bottomTableLayoutPanel
    '
    Me.bottomTableLayoutPanel.ColumnCount = 2
    Me.bottomTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
    Me.bottomTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
    Me.bottomTableLayoutPanel.Controls.Add(Me.closeButton, 1, 0)
    Me.bottomTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom
    Me.bottomTableLayoutPanel.Location = New System.Drawing.Point(0, 332)
    Me.bottomTableLayoutPanel.Name = "bottomTableLayoutPanel"
    Me.bottomTableLayoutPanel.RowCount = 1
    Me.bottomTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
    Me.bottomTableLayoutPanel.Size = New System.Drawing.Size(760, 29)
    Me.bottomTableLayoutPanel.TabIndex = 2
    '
    'closeButton
    '
    Me.closeButton.Location = New System.Drawing.Point(682, 3)
    Me.closeButton.Name = "closeButton"
    Me.closeButton.Size = New System.Drawing.Size(75, 23)
    Me.closeButton.TabIndex = 0
    Me.closeButton.Text = "&Close"
    Me.closeButton.UseVisualStyleBackColor = True
    '
    'ChildVehicleListForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.ClientSize = New System.Drawing.Size(760, 361)
    Me.Controls.Add(Me.vehicleListView)
    Me.Controls.Add(Me.mainTextBox)
    Me.Controls.Add(Me.bottomTableLayoutPanel)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "ChildVehicleListForm"
    Me.Text = "List of Child Vehicles"
    CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
    Me.bottomTableLayoutPanel.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents mainTextBox As System.Windows.Forms.TextBox
  Friend WithEvents vehicleListView As System.Windows.Forms.ListView
  Friend WithEvents bottomTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
  Friend WithEvents closeButton As System.Windows.Forms.Button
  Friend WithEvents vehicleIdColumnHeader As System.Windows.Forms.ColumnHeader
  Friend WithEvents noteColumnHeader As System.Windows.Forms.ColumnHeader

End Class
