Namespace UI.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ImageViewerForm
        Inherits UI.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImageViewerForm))
            Me.imagePathLabel = New System.Windows.Forms.Label
            Me.imagePathTextBox = New System.Windows.Forms.TextBox
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
            Me.imgViewer = New System.Windows.Forms.PictureBox
            Me.Panel1 = New System.Windows.Forms.Panel
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TableLayoutPanel1.SuspendLayout()
            CType(Me.imgViewer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'imagePathLabel
            '
            Me.imagePathLabel.AutoSize = True
            Me.imagePathLabel.Location = New System.Drawing.Point(3, 7)
            Me.imagePathLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
            Me.imagePathLabel.Name = "imagePathLabel"
            Me.imagePathLabel.Size = New System.Drawing.Size(64, 13)
            Me.imagePathLabel.TabIndex = 3
            Me.imagePathLabel.Text = "Image Path:"
            '
            'imagePathTextBox
            '
            Me.imagePathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.imagePathTextBox.Location = New System.Drawing.Point(73, 3)
            Me.imagePathTextBox.Name = "imagePathTextBox"
            Me.imagePathTextBox.ReadOnly = True
            Me.imagePathTextBox.Size = New System.Drawing.Size(520, 20)
            Me.imagePathTextBox.TabIndex = 4
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.AutoScroll = True
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.imagePathTextBox, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.imagePathLabel, 0, 0)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 1
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(596, 28)
            Me.TableLayoutPanel1.TabIndex = 2
            '
            'imgViewer
            '
            Me.imgViewer.Location = New System.Drawing.Point(0, 0)
            Me.imgViewer.Name = "imgViewer"
            Me.imgViewer.Size = New System.Drawing.Size(596, 559)
            Me.imgViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            Me.imgViewer.TabIndex = 3
            Me.imgViewer.TabStop = False
            '
            'Panel1
            '
            Me.Panel1.AutoScroll = True
            Me.Panel1.Controls.Add(Me.imgViewer)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 28)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(596, 559)
            Me.Panel1.TabIndex = 4
            '
            'ImageViewerForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(596, 587)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.TableLayoutPanel1)
            Me.Name = "ImageViewerForm"
            Me.Text = "Image Viewer"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TableLayoutPanel1.PerformLayout()
            CType(Me.imgViewer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        ''     Friend WithEvents imageAxLEAD As AxLEADLib.AxLEAD
        Friend WithEvents imagePathLabel As System.Windows.Forms.Label
        Friend WithEvents imagePathTextBox As System.Windows.Forms.TextBox
        Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents imgViewer As System.Windows.Forms.PictureBox
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
    End Class

End Namespace