Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class DESPResultForm
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DESPResultForm))
      Me.resultLabel = New System.Windows.Forms.Label
      Me.resultComboBox = New System.Windows.Forms.ComboBox
      Me.resultDataGridView = New System.Windows.Forms.DataGridView
      Me.resultTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
      Me.totalresultsLabel = New System.Windows.Forms.Label
      Me.totalresultsValueLabel = New System.Windows.Forms.Label
      CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.resultDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.resultTableLayoutPanel.SuspendLayout()
      Me.SuspendLayout()
      '
      'smalliconImageList
      '
      Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
      Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
      Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
      '
      'resultLabel
      '
      Me.resultLabel.AutoSize = True
      Me.resultLabel.Location = New System.Drawing.Point(3, 7)
      Me.resultLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
      Me.resultLabel.Name = "resultLabel"
      Me.resultLabel.Size = New System.Drawing.Size(37, 13)
      Me.resultLabel.TabIndex = 0
      Me.resultLabel.Text = "Result"
      '
      'resultComboBox
      '
      Me.resultComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.resultComboBox.FormattingEnabled = True
      Me.resultComboBox.Location = New System.Drawing.Point(46, 3)
      Me.resultComboBox.Name = "resultComboBox"
      Me.resultComboBox.Size = New System.Drawing.Size(163, 21)
      Me.resultComboBox.TabIndex = 1
      '
      'resultDataGridView
      '
      Me.resultDataGridView.AllowUserToAddRows = False
      Me.resultDataGridView.AllowUserToDeleteRows = False
      Me.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.resultTableLayoutPanel.SetColumnSpan(Me.resultDataGridView, 4)
      Me.resultDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.resultDataGridView.Location = New System.Drawing.Point(3, 30)
      Me.resultDataGridView.Name = "resultDataGridView"
      Me.resultDataGridView.ReadOnly = True
      Me.resultDataGridView.Size = New System.Drawing.Size(766, 432)
      Me.resultDataGridView.TabIndex = 2
      '
      'resultTableLayoutPanel
      '
      Me.resultTableLayoutPanel.ColumnCount = 4
      Me.resultTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.resultTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.resultTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.resultTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
      Me.resultTableLayoutPanel.Controls.Add(Me.resultLabel, 0, 0)
      Me.resultTableLayoutPanel.Controls.Add(Me.resultComboBox, 1, 0)
      Me.resultTableLayoutPanel.Controls.Add(Me.resultDataGridView, 0, 1)
      Me.resultTableLayoutPanel.Controls.Add(Me.totalresultsLabel, 2, 0)
      Me.resultTableLayoutPanel.Controls.Add(Me.totalresultsValueLabel, 3, 0)
      Me.resultTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.resultTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
      Me.resultTableLayoutPanel.Name = "resultTableLayoutPanel"
      Me.resultTableLayoutPanel.RowCount = 2
      Me.resultTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.resultTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.resultTableLayoutPanel.Size = New System.Drawing.Size(772, 465)
      Me.resultTableLayoutPanel.TabIndex = 3
      '
      'totalresultsLabel
      '
      Me.totalresultsLabel.AutoSize = True
      Me.totalresultsLabel.Location = New System.Drawing.Point(371, 7)
      Me.totalresultsLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
      Me.totalresultsLabel.Name = "totalresultsLabel"
      Me.totalresultsLabel.Size = New System.Drawing.Size(72, 13)
      Me.totalresultsLabel.TabIndex = 3
      Me.totalresultsLabel.Text = "Total Results:"
      '
      'totalresultsValueLabel
      '
      Me.totalresultsValueLabel.AutoSize = True
      Me.totalresultsValueLabel.Location = New System.Drawing.Point(449, 7)
      Me.totalresultsValueLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
      Me.totalresultsValueLabel.Name = "totalresultsValueLabel"
      Me.totalresultsValueLabel.Size = New System.Drawing.Size(111, 13)
      Me.totalresultsValueLabel.TabIndex = 4
      Me.totalresultsValueLabel.Text = "<Total Results Value>"
      '
      'DESPResultForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.ClientSize = New System.Drawing.Size(772, 465)
      Me.Controls.Add(Me.resultTableLayoutPanel)
      Me.Name = "DESPResultForm"
      Me.StatusMessage = ""
      Me.Text = "DESP Result"
      CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.resultDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      Me.resultTableLayoutPanel.ResumeLayout(False)
      Me.resultTableLayoutPanel.PerformLayout()
      Me.ResumeLayout(False)

    End Sub
    Friend WithEvents resultLabel As System.Windows.Forms.Label
    Friend WithEvents resultComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents resultDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents resultTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents totalresultsLabel As System.Windows.Forms.Label
    Friend WithEvents totalresultsValueLabel As System.Windows.Forms.Label

  End Class

End Namespace