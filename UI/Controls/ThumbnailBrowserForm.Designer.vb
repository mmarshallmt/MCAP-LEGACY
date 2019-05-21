Namespace UI.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ThumbnailBrowserForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ThumbnailBrowserForm))
            Me.imageNotAvailableLabel = New System.Windows.Forms.Label
            Me.dgThumbnails = New System.Windows.Forms.DataGridView
            Me.DataGridView1 = New System.Windows.Forms.DataGridView
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgThumbnails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'smalliconImageList
            '
            Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
            Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
            Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
            '
            'imageNotAvailableLabel
            '
            Me.imageNotAvailableLabel.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.imageNotAvailableLabel.BackColor = System.Drawing.Color.White
            Me.imageNotAvailableLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.imageNotAvailableLabel.Location = New System.Drawing.Point(340, 218)
            Me.imageNotAvailableLabel.Name = "imageNotAvailableLabel"
            Me.imageNotAvailableLabel.Size = New System.Drawing.Size(159, 30)
            Me.imageNotAvailableLabel.TabIndex = 1
            Me.imageNotAvailableLabel.Text = "Image Not Available"
            Me.imageNotAvailableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.imageNotAvailableLabel.Visible = False
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
            Me.dgThumbnails.Location = New System.Drawing.Point(0, 0)
            Me.dgThumbnails.Name = "dgThumbnails"
            Me.dgThumbnails.RowHeadersVisible = False
            Me.dgThumbnails.ShowCellErrors = False
            Me.dgThumbnails.ShowEditingIcon = False
            Me.dgThumbnails.ShowRowErrors = False
            Me.dgThumbnails.Size = New System.Drawing.Size(838, 476)
            Me.dgThumbnails.TabIndex = 8
            '
            'DataGridView1
            '
            Me.DataGridView1.AllowUserToAddRows = False
            Me.DataGridView1.AllowUserToDeleteRows = False
            Me.DataGridView1.AllowUserToOrderColumns = True
            Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
            Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
            Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.DataGridView1.ColumnHeadersVisible = False
            Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridView1.GridColor = System.Drawing.Color.White
            Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
            Me.DataGridView1.Name = "DataGridView1"
            Me.DataGridView1.RowHeadersVisible = False
            Me.DataGridView1.ShowCellErrors = False
            Me.DataGridView1.ShowEditingIcon = False
            Me.DataGridView1.ShowRowErrors = False
            Me.DataGridView1.Size = New System.Drawing.Size(838, 476)
            Me.DataGridView1.TabIndex = 9
            '
            'ThumbnailBrowserForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(838, 476)
            Me.Controls.Add(Me.imageNotAvailableLabel)
            Me.Controls.Add(Me.dgThumbnails)
            Me.Controls.Add(Me.DataGridView1)
            Me.Name = "ThumbnailBrowserForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Thumbnail Browser"
            CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgThumbnails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents imageNotAvailableLabel As System.Windows.Forms.Label
        Private WithEvents dgThumbnails As System.Windows.Forms.DataGridView
        Private WithEvents DataGridView1 As System.Windows.Forms.DataGridView
        ''Private WithEvents vehicleLEADImgList As AxLEADImgListLib.AxLEADImgList

    End Class

End Namespace