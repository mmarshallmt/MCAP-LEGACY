Namespace UI

  <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
  Partial Class ScanTrackerEROPForm
    Inherits UI.MDIChildFormBase

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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ScanTrackerEROPForm))
      Me.wizardTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
      Me.Wizard1 = New MCAP.UI.Controls.Wizard
      Me.welcomeTabPage = New System.Windows.Forms.TabPage
      Me.welcomeTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
      Me.splitDoubleTruckAdsCheckBox = New System.Windows.Forms.CheckBox
      Me.welcomeLeftPictureBox = New System.Windows.Forms.PictureBox
      Me.welcomeTitleLabel = New System.Windows.Forms.Label
      Me.welcomeDescripLabel = New System.Windows.Forms.Label
      Me.step1TabPage = New System.Windows.Forms.TabPage
      Me.step1TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
      Me.processPublicationFolderButton = New System.Windows.Forms.Button
      Me.step1TitleLabel = New System.Windows.Forms.Label
      Me.uncheckAllFoldersButton = New System.Windows.Forms.Button
      Me.checkAllFoldersButton = New System.Windows.Forms.Button
      Me.browseButton = New System.Windows.Forms.Button
      Me.downloadPathTextBox = New System.Windows.Forms.TextBox
      Me.downloadPathLabel = New System.Windows.Forms.Label
      Me.publicationFolderDataGridView = New System.Windows.Forms.DataGridView
      Me.step2TabPage = New System.Windows.Forms.TabPage
      Me.step2TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
      Me.step2TitleLabel = New System.Windows.Forms.Label
      Me.pdfFileDataGridView = New System.Windows.Forms.DataGridView
      Me.processFilesButton = New System.Windows.Forms.Button
      Me.step3TabPage = New System.Windows.Forms.TabPage
      Me.step3TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
      Me.step3TitleLabel = New System.Windows.Forms.Label
      Me.processFilePagesButton = New System.Windows.Forms.Button
      Me.pageImagesDataGridView = New System.Windows.Forms.DataGridView
      Me.step4TabPage = New System.Windows.Forms.TabPage
      Me.step4TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel
      Me.step4TitleLabel = New System.Windows.Forms.Label
      Me.rotateLabel = New System.Windows.Forms.Label
      Me.rotateComboBox = New System.Windows.Forms.ComboBox
      Me.postImagesButton = New System.Windows.Forms.Button
      Me.scantrackDataGridView = New System.Windows.Forms.DataGridView
      Me.recountImagesButton = New System.Windows.Forms.Button
      Me.previewImagesButton = New System.Windows.Forms.Button
      Me.finishTabPage = New System.Windows.Forms.TabPage
      Me.backButton = New System.Windows.Forms.Button
      Me.nextButton = New System.Windows.Forms.Button
      Me.closeButton = New System.Windows.Forms.Button
      Me.blackLineLabel = New System.Windows.Forms.Label
      Me.downloadFolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
      CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.wizardTableLayoutPanel.SuspendLayout()
      Me.Wizard1.SuspendLayout()
      Me.welcomeTabPage.SuspendLayout()
      Me.welcomeTableLayoutPanel.SuspendLayout()
      CType(Me.welcomeLeftPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.step1TabPage.SuspendLayout()
      Me.step1TableLayoutPanel.SuspendLayout()
      CType(Me.publicationFolderDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.step2TabPage.SuspendLayout()
      Me.step2TableLayoutPanel.SuspendLayout()
      CType(Me.pdfFileDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.step3TabPage.SuspendLayout()
      Me.step3TableLayoutPanel.SuspendLayout()
      CType(Me.pageImagesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.step4TabPage.SuspendLayout()
      Me.step4TableLayoutPanel.SuspendLayout()
      CType(Me.scantrackDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'smalliconImageList
      '
      Me.smalliconImageList.ImageStream = CType(resources.GetObject("smalliconImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.smalliconImageList.Images.SetKeyName(0, "Filter.ico")
      Me.smalliconImageList.Images.SetKeyName(1, "Printer.ico")
      Me.smalliconImageList.Images.SetKeyName(2, "DefaultPrinter.ico")
      '
      'wizardTableLayoutPanel
      '
      Me.wizardTableLayoutPanel.ColumnCount = 4
      Me.wizardTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.wizardTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.wizardTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.wizardTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.wizardTableLayoutPanel.Controls.Add(Me.Wizard1, 0, 0)
      Me.wizardTableLayoutPanel.Controls.Add(Me.backButton, 1, 2)
      Me.wizardTableLayoutPanel.Controls.Add(Me.nextButton, 2, 2)
      Me.wizardTableLayoutPanel.Controls.Add(Me.closeButton, 3, 2)
      Me.wizardTableLayoutPanel.Controls.Add(Me.blackLineLabel, 0, 1)
      Me.wizardTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.wizardTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
      Me.wizardTableLayoutPanel.Name = "wizardTableLayoutPanel"
      Me.wizardTableLayoutPanel.RowCount = 3
      Me.wizardTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.wizardTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.wizardTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.wizardTableLayoutPanel.Size = New System.Drawing.Size(742, 416)
      Me.wizardTableLayoutPanel.TabIndex = 0
      '
      'Wizard1
      '
      Me.wizardTableLayoutPanel.SetColumnSpan(Me.Wizard1, 4)
      Me.Wizard1.Controls.Add(Me.welcomeTabPage)
      Me.Wizard1.Controls.Add(Me.step1TabPage)
      Me.Wizard1.Controls.Add(Me.step2TabPage)
      Me.Wizard1.Controls.Add(Me.step3TabPage)
      Me.Wizard1.Controls.Add(Me.step4TabPage)
      Me.Wizard1.Controls.Add(Me.finishTabPage)
      Me.Wizard1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.Wizard1.Location = New System.Drawing.Point(3, 3)
      Me.Wizard1.Name = "Wizard1"
      Me.Wizard1.SelectedIndex = 0
      Me.Wizard1.Size = New System.Drawing.Size(736, 379)
      Me.Wizard1.TabIndex = 0
      '
      'welcomeTabPage
      '
      Me.welcomeTabPage.Controls.Add(Me.welcomeTableLayoutPanel)
      Me.welcomeTabPage.Location = New System.Drawing.Point(4, 22)
      Me.welcomeTabPage.Name = "welcomeTabPage"
      Me.welcomeTabPage.Size = New System.Drawing.Size(728, 353)
      Me.welcomeTabPage.TabIndex = 2
      Me.welcomeTabPage.Text = "Welcome"
      Me.welcomeTabPage.UseVisualStyleBackColor = True
      '
      'welcomeTableLayoutPanel
      '
      Me.welcomeTableLayoutPanel.ColumnCount = 2
      Me.welcomeTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
      Me.welcomeTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
      Me.welcomeTableLayoutPanel.Controls.Add(Me.splitDoubleTruckAdsCheckBox, 0, 2)
      Me.welcomeTableLayoutPanel.Controls.Add(Me.welcomeLeftPictureBox, 0, 0)
      Me.welcomeTableLayoutPanel.Controls.Add(Me.welcomeTitleLabel, 1, 0)
      Me.welcomeTableLayoutPanel.Controls.Add(Me.welcomeDescripLabel, 1, 1)
      Me.welcomeTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.welcomeTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
      Me.welcomeTableLayoutPanel.Name = "welcomeTableLayoutPanel"
      Me.welcomeTableLayoutPanel.RowCount = 3
      Me.welcomeTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
      Me.welcomeTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.welcomeTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.welcomeTableLayoutPanel.Size = New System.Drawing.Size(728, 353)
      Me.welcomeTableLayoutPanel.TabIndex = 0
      '
      'splitDoubleTruckAdsCheckBox
      '
      Me.splitDoubleTruckAdsCheckBox.AutoSize = True
      Me.splitDoubleTruckAdsCheckBox.Location = New System.Drawing.Point(185, 333)
      Me.splitDoubleTruckAdsCheckBox.Name = "splitDoubleTruckAdsCheckBox"
      Me.splitDoubleTruckAdsCheckBox.Size = New System.Drawing.Size(163, 17)
      Me.splitDoubleTruckAdsCheckBox.TabIndex = 2
      Me.splitDoubleTruckAdsCheckBox.Text = "Auto Split &Double Truck Ads."
      Me.splitDoubleTruckAdsCheckBox.UseVisualStyleBackColor = True
      '
      'welcomeLeftPictureBox
      '
      Me.welcomeLeftPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.welcomeLeftPictureBox.Image = Global.MCAP.My.Resources.Resources.MT_logo_RGB_web90
      Me.welcomeLeftPictureBox.Location = New System.Drawing.Point(3, 3)
      Me.welcomeLeftPictureBox.Name = "welcomeLeftPictureBox"
      Me.welcomeTableLayoutPanel.SetRowSpan(Me.welcomeLeftPictureBox, 3)
      Me.welcomeLeftPictureBox.Size = New System.Drawing.Size(176, 347)
      Me.welcomeLeftPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
      Me.welcomeLeftPictureBox.TabIndex = 0
      Me.welcomeLeftPictureBox.TabStop = False
      '
      'welcomeTitleLabel
      '
      Me.welcomeTitleLabel.AutoSize = True
      Me.welcomeTitleLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.welcomeTitleLabel.Location = New System.Drawing.Point(185, 0)
      Me.welcomeTitleLabel.Name = "welcomeTitleLabel"
      Me.welcomeTitleLabel.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
      Me.welcomeTitleLabel.Size = New System.Drawing.Size(540, 50)
      Me.welcomeTitleLabel.TabIndex = 0
      Me.welcomeTitleLabel.Text = "Welcome to E - ROP Scan Tracker Wizard"
      Me.welcomeTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'welcomeDescripLabel
      '
      Me.welcomeDescripLabel.AutoSize = True
      Me.welcomeDescripLabel.Location = New System.Drawing.Point(185, 55)
      Me.welcomeDescripLabel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
      Me.welcomeDescripLabel.Name = "welcomeDescripLabel"
      Me.welcomeDescripLabel.Size = New System.Drawing.Size(312, 234)
      Me.welcomeDescripLabel.TabIndex = 1
      Me.welcomeDescripLabel.Text = resources.GetString("welcomeDescripLabel.Text")
      '
      'step1TabPage
      '
      Me.step1TabPage.Controls.Add(Me.step1TableLayoutPanel)
      Me.step1TabPage.Location = New System.Drawing.Point(4, 22)
      Me.step1TabPage.Name = "step1TabPage"
      Me.step1TabPage.Size = New System.Drawing.Size(728, 353)
      Me.step1TabPage.TabIndex = 7
      Me.step1TabPage.Text = "Step 1"
      Me.step1TabPage.UseVisualStyleBackColor = True
      '
      'step1TableLayoutPanel
      '
      Me.step1TableLayoutPanel.ColumnCount = 6
      Me.step1TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.step1TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.step1TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.step1TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.step1TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.step1TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.step1TableLayoutPanel.Controls.Add(Me.processPublicationFolderButton, 4, 3)
      Me.step1TableLayoutPanel.Controls.Add(Me.step1TitleLabel, 0, 0)
      Me.step1TableLayoutPanel.Controls.Add(Me.uncheckAllFoldersButton, 2, 3)
      Me.step1TableLayoutPanel.Controls.Add(Me.checkAllFoldersButton, 0, 3)
      Me.step1TableLayoutPanel.Controls.Add(Me.browseButton, 5, 1)
      Me.step1TableLayoutPanel.Controls.Add(Me.downloadPathTextBox, 1, 1)
      Me.step1TableLayoutPanel.Controls.Add(Me.downloadPathLabel, 0, 1)
      Me.step1TableLayoutPanel.Controls.Add(Me.publicationFolderDataGridView, 0, 2)
      Me.step1TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.step1TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
      Me.step1TableLayoutPanel.Name = "step1TableLayoutPanel"
      Me.step1TableLayoutPanel.RowCount = 4
      Me.step1TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
      Me.step1TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.step1TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.step1TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.step1TableLayoutPanel.Size = New System.Drawing.Size(728, 353)
      Me.step1TableLayoutPanel.TabIndex = 6
      '
      'processPublicationFolderButton
      '
      Me.step1TableLayoutPanel.SetColumnSpan(Me.processPublicationFolderButton, 2)
      Me.processPublicationFolderButton.Location = New System.Drawing.Point(650, 327)
      Me.processPublicationFolderButton.Name = "processPublicationFolderButton"
      Me.processPublicationFolderButton.Size = New System.Drawing.Size(75, 23)
      Me.processPublicationFolderButton.TabIndex = 3
      Me.processPublicationFolderButton.Text = "P&rocess"
      Me.processPublicationFolderButton.UseVisualStyleBackColor = True
      '
      'step1TitleLabel
      '
      Me.step1TitleLabel.AutoSize = True
      Me.step1TableLayoutPanel.SetColumnSpan(Me.step1TitleLabel, 6)
      Me.step1TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.step1TitleLabel.Location = New System.Drawing.Point(3, 0)
      Me.step1TitleLabel.Name = "step1TitleLabel"
      Me.step1TitleLabel.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
      Me.step1TitleLabel.Size = New System.Drawing.Size(722, 50)
      Me.step1TitleLabel.TabIndex = 3
      Me.step1TitleLabel.Text = "Validate Publication Id folders"
      Me.step1TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'uncheckAllFoldersButton
      '
      Me.uncheckAllFoldersButton.Location = New System.Drawing.Point(84, 327)
      Me.uncheckAllFoldersButton.Name = "uncheckAllFoldersButton"
      Me.uncheckAllFoldersButton.Size = New System.Drawing.Size(75, 23)
      Me.uncheckAllFoldersButton.TabIndex = 5
      Me.uncheckAllFoldersButton.Text = "&Uncheck All"
      Me.uncheckAllFoldersButton.UseVisualStyleBackColor = True
      '
      'checkAllFoldersButton
      '
      Me.step1TableLayoutPanel.SetColumnSpan(Me.checkAllFoldersButton, 2)
      Me.checkAllFoldersButton.Location = New System.Drawing.Point(3, 327)
      Me.checkAllFoldersButton.Name = "checkAllFoldersButton"
      Me.checkAllFoldersButton.Size = New System.Drawing.Size(75, 23)
      Me.checkAllFoldersButton.TabIndex = 4
      Me.checkAllFoldersButton.Text = "&Check All"
      Me.checkAllFoldersButton.UseVisualStyleBackColor = True
      '
      'browseButton
      '
      Me.browseButton.Location = New System.Drawing.Point(697, 53)
      Me.browseButton.Name = "browseButton"
      Me.browseButton.Size = New System.Drawing.Size(28, 23)
      Me.browseButton.TabIndex = 2
      Me.browseButton.Text = "&..."
      Me.browseButton.UseVisualStyleBackColor = True
      '
      'downloadPathTextBox
      '
      Me.step1TableLayoutPanel.SetColumnSpan(Me.downloadPathTextBox, 4)
      Me.downloadPathTextBox.Dock = System.Windows.Forms.DockStyle.Fill
      Me.downloadPathTextBox.Location = New System.Drawing.Point(41, 53)
      Me.downloadPathTextBox.Name = "downloadPathTextBox"
      Me.downloadPathTextBox.ReadOnly = True
      Me.downloadPathTextBox.Size = New System.Drawing.Size(650, 20)
      Me.downloadPathTextBox.TabIndex = 1
      '
      'downloadPathLabel
      '
      Me.downloadPathLabel.AutoSize = True
      Me.downloadPathLabel.Location = New System.Drawing.Point(3, 55)
      Me.downloadPathLabel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
      Me.downloadPathLabel.Name = "downloadPathLabel"
      Me.downloadPathLabel.Size = New System.Drawing.Size(32, 13)
      Me.downloadPathLabel.TabIndex = 0
      Me.downloadPathLabel.Text = "&Path:"
      '
      'publicationFolderDataGridView
      '
      Me.publicationFolderDataGridView.AllowUserToAddRows = False
      Me.publicationFolderDataGridView.AllowUserToDeleteRows = False
      Me.step1TableLayoutPanel.SetColumnSpan(Me.publicationFolderDataGridView, 6)
      Me.publicationFolderDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.publicationFolderDataGridView.Location = New System.Drawing.Point(3, 82)
      Me.publicationFolderDataGridView.Name = "publicationFolderDataGridView"
      Me.publicationFolderDataGridView.ReadOnly = True
      Me.publicationFolderDataGridView.Size = New System.Drawing.Size(722, 239)
      Me.publicationFolderDataGridView.TabIndex = 8
      '
      'step2TabPage
      '
      Me.step2TabPage.Controls.Add(Me.step2TableLayoutPanel)
      Me.step2TabPage.Location = New System.Drawing.Point(4, 22)
      Me.step2TabPage.Name = "step2TabPage"
      Me.step2TabPage.Size = New System.Drawing.Size(728, 353)
      Me.step2TabPage.TabIndex = 6
      Me.step2TabPage.Text = "Step 2"
      Me.step2TabPage.UseVisualStyleBackColor = True
      '
      'step2TableLayoutPanel
      '
      Me.step2TableLayoutPanel.ColumnCount = 2
      Me.step2TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.step2TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.step2TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.step2TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.step2TableLayoutPanel.Controls.Add(Me.step2TitleLabel, 0, 0)
      Me.step2TableLayoutPanel.Controls.Add(Me.pdfFileDataGridView, 0, 1)
      Me.step2TableLayoutPanel.Controls.Add(Me.processFilesButton, 1, 2)
      Me.step2TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.step2TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
      Me.step2TableLayoutPanel.Name = "step2TableLayoutPanel"
      Me.step2TableLayoutPanel.RowCount = 3
      Me.step2TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
      Me.step2TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.step2TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.step2TableLayoutPanel.Size = New System.Drawing.Size(728, 353)
      Me.step2TableLayoutPanel.TabIndex = 7
      '
      'step2TitleLabel
      '
      Me.step2TitleLabel.AutoSize = True
      Me.step2TableLayoutPanel.SetColumnSpan(Me.step2TitleLabel, 2)
      Me.step2TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.step2TitleLabel.Location = New System.Drawing.Point(3, 0)
      Me.step2TitleLabel.Name = "step2TitleLabel"
      Me.step2TitleLabel.Padding = New System.Windows.Forms.Padding(0, 1, 0, 0)
      Me.step2TitleLabel.Size = New System.Drawing.Size(722, 50)
      Me.step2TitleLabel.TabIndex = 3
      Me.step2TitleLabel.Text = "Unzip and Validate Downloaded PDF file(s)"
      Me.step2TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'pdfFileDataGridView
      '
      Me.pdfFileDataGridView.AllowUserToAddRows = False
      Me.pdfFileDataGridView.AllowUserToDeleteRows = False
      Me.step2TableLayoutPanel.SetColumnSpan(Me.pdfFileDataGridView, 2)
      Me.pdfFileDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pdfFileDataGridView.Location = New System.Drawing.Point(3, 53)
      Me.pdfFileDataGridView.Name = "pdfFileDataGridView"
      Me.pdfFileDataGridView.ReadOnly = True
      Me.pdfFileDataGridView.RowHeadersVisible = False
      Me.pdfFileDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.pdfFileDataGridView.Size = New System.Drawing.Size(722, 268)
      Me.pdfFileDataGridView.TabIndex = 8
      '
      'processFilesButton
      '
      Me.processFilesButton.Location = New System.Drawing.Point(650, 327)
      Me.processFilesButton.Name = "processFilesButton"
      Me.processFilesButton.Size = New System.Drawing.Size(75, 23)
      Me.processFilesButton.TabIndex = 9
      Me.processFilesButton.Text = "P&rocess"
      Me.processFilesButton.UseVisualStyleBackColor = True
      '
      'step3TabPage
      '
      Me.step3TabPage.Controls.Add(Me.step3TableLayoutPanel)
      Me.step3TabPage.Location = New System.Drawing.Point(4, 22)
      Me.step3TabPage.Name = "step3TabPage"
      Me.step3TabPage.Size = New System.Drawing.Size(728, 353)
      Me.step3TabPage.TabIndex = 4
      Me.step3TabPage.Text = "Step 3"
      Me.step3TabPage.UseVisualStyleBackColor = True
      '
      'step3TableLayoutPanel
      '
      Me.step3TableLayoutPanel.ColumnCount = 2
      Me.step3TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.step3TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.step3TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.step3TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
      Me.step3TableLayoutPanel.Controls.Add(Me.step3TitleLabel, 0, 0)
      Me.step3TableLayoutPanel.Controls.Add(Me.processFilePagesButton, 1, 2)
      Me.step3TableLayoutPanel.Controls.Add(Me.pageImagesDataGridView, 0, 1)
      Me.step3TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.step3TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
      Me.step3TableLayoutPanel.Name = "step3TableLayoutPanel"
      Me.step3TableLayoutPanel.RowCount = 3
      Me.step3TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
      Me.step3TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.step3TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.step3TableLayoutPanel.Size = New System.Drawing.Size(728, 353)
      Me.step3TableLayoutPanel.TabIndex = 0
      '
      'step3TitleLabel
      '
      Me.step3TitleLabel.AutoSize = True
      Me.step3TableLayoutPanel.SetColumnSpan(Me.step3TitleLabel, 2)
      Me.step3TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.step3TitleLabel.Location = New System.Drawing.Point(3, 0)
      Me.step3TitleLabel.Name = "step3TitleLabel"
      Me.step3TitleLabel.Size = New System.Drawing.Size(722, 50)
      Me.step3TitleLabel.TabIndex = 0
      Me.step3TitleLabel.Text = "Convert PDF File Pages Into Page Images"
      Me.step3TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'processFilePagesButton
      '
      Me.processFilePagesButton.Location = New System.Drawing.Point(650, 327)
      Me.processFilePagesButton.Name = "processFilePagesButton"
      Me.processFilePagesButton.Size = New System.Drawing.Size(75, 23)
      Me.processFilePagesButton.TabIndex = 5
      Me.processFilePagesButton.Text = "P&rocess"
      Me.processFilePagesButton.UseVisualStyleBackColor = True
      '
      'pageImagesDataGridView
      '
      Me.pageImagesDataGridView.AllowUserToAddRows = False
      Me.pageImagesDataGridView.AllowUserToDeleteRows = False
      Me.step3TableLayoutPanel.SetColumnSpan(Me.pageImagesDataGridView, 2)
      Me.pageImagesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.pageImagesDataGridView.Location = New System.Drawing.Point(3, 53)
      Me.pageImagesDataGridView.Name = "pageImagesDataGridView"
      Me.pageImagesDataGridView.ReadOnly = True
      Me.pageImagesDataGridView.RowHeadersVisible = False
      Me.pageImagesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.pageImagesDataGridView.Size = New System.Drawing.Size(722, 268)
      Me.pageImagesDataGridView.TabIndex = 6
      '
      'step4TabPage
      '
      Me.step4TabPage.Controls.Add(Me.step4TableLayoutPanel)
      Me.step4TabPage.Location = New System.Drawing.Point(4, 22)
      Me.step4TabPage.Name = "step4TabPage"
      Me.step4TabPage.Size = New System.Drawing.Size(728, 353)
      Me.step4TabPage.TabIndex = 5
      Me.step4TabPage.Text = "Step 4"
      Me.step4TabPage.UseVisualStyleBackColor = True
      '
      'step4TableLayoutPanel
      '
      Me.step4TableLayoutPanel.ColumnCount = 6
      Me.step4TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.step4TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.step4TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.step4TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.step4TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.step4TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
      Me.step4TableLayoutPanel.Controls.Add(Me.step4TitleLabel, 0, 0)
      Me.step4TableLayoutPanel.Controls.Add(Me.rotateLabel, 3, 2)
      Me.step4TableLayoutPanel.Controls.Add(Me.rotateComboBox, 4, 2)
      Me.step4TableLayoutPanel.Controls.Add(Me.postImagesButton, 5, 2)
      Me.step4TableLayoutPanel.Controls.Add(Me.scantrackDataGridView, 0, 1)
      Me.step4TableLayoutPanel.Controls.Add(Me.recountImagesButton, 0, 2)
      Me.step4TableLayoutPanel.Controls.Add(Me.previewImagesButton, 1, 2)
      Me.step4TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.step4TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
      Me.step4TableLayoutPanel.Name = "step4TableLayoutPanel"
      Me.step4TableLayoutPanel.RowCount = 3
      Me.step4TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
      Me.step4TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
      Me.step4TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle)
      Me.step4TableLayoutPanel.Size = New System.Drawing.Size(728, 353)
      Me.step4TableLayoutPanel.TabIndex = 1
      '
      'step4TitleLabel
      '
      Me.step4TitleLabel.AutoSize = True
      Me.step4TableLayoutPanel.SetColumnSpan(Me.step4TitleLabel, 6)
      Me.step4TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.step4TitleLabel.Location = New System.Drawing.Point(3, 0)
      Me.step4TitleLabel.Name = "step4TitleLabel"
      Me.step4TitleLabel.Size = New System.Drawing.Size(722, 50)
      Me.step4TitleLabel.TabIndex = 0
      Me.step4TitleLabel.Text = "Post Converted Images into Vehicle Folders"
      Me.step4TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'rotateLabel
      '
      Me.rotateLabel.AutoSize = True
      Me.rotateLabel.Location = New System.Drawing.Point(552, 331)
      Me.rotateLabel.Margin = New System.Windows.Forms.Padding(3, 7, 3, 0)
      Me.rotateLabel.Name = "rotateLabel"
      Me.rotateLabel.Size = New System.Drawing.Size(42, 13)
      Me.rotateLabel.TabIndex = 3
      Me.rotateLabel.Text = "&Rotate:"
      '
      'rotateComboBox
      '
      Me.rotateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.rotateComboBox.FormattingEnabled = True
      Me.rotateComboBox.Items.AddRange(New Object() {"0", "90", "180", "270"})
      Me.rotateComboBox.Location = New System.Drawing.Point(600, 327)
      Me.rotateComboBox.Name = "rotateComboBox"
      Me.rotateComboBox.Size = New System.Drawing.Size(44, 21)
      Me.rotateComboBox.TabIndex = 4
      '
      'postImagesButton
      '
      Me.postImagesButton.Location = New System.Drawing.Point(650, 327)
      Me.postImagesButton.Name = "postImagesButton"
      Me.postImagesButton.Size = New System.Drawing.Size(75, 23)
      Me.postImagesButton.TabIndex = 5
      Me.postImagesButton.Text = "Po&st"
      Me.postImagesButton.UseVisualStyleBackColor = True
      '
      'scantrackDataGridView
      '
      Me.scantrackDataGridView.AllowUserToAddRows = False
      Me.scantrackDataGridView.AllowUserToDeleteRows = False
      Me.step4TableLayoutPanel.SetColumnSpan(Me.scantrackDataGridView, 6)
      Me.scantrackDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
      Me.scantrackDataGridView.Location = New System.Drawing.Point(3, 53)
      Me.scantrackDataGridView.Name = "scantrackDataGridView"
      Me.scantrackDataGridView.ReadOnly = True
      Me.scantrackDataGridView.RowHeadersVisible = False
      Me.scantrackDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.scantrackDataGridView.Size = New System.Drawing.Size(722, 268)
      Me.scantrackDataGridView.TabIndex = 6
      '
      'recountImagesButton
      '
      Me.recountImagesButton.Location = New System.Drawing.Point(3, 327)
      Me.recountImagesButton.Name = "recountImagesButton"
      Me.recountImagesButton.Size = New System.Drawing.Size(119, 23)
      Me.recountImagesButton.TabIndex = 1
      Me.recountImagesButton.Text = "&Recount Images"
      Me.recountImagesButton.UseVisualStyleBackColor = True
      '
      'previewImagesButton
      '
      Me.previewImagesButton.Location = New System.Drawing.Point(128, 327)
      Me.previewImagesButton.Name = "previewImagesButton"
      Me.previewImagesButton.Size = New System.Drawing.Size(111, 23)
      Me.previewImagesButton.TabIndex = 2
      Me.previewImagesButton.Text = "&Preview Images"
      Me.previewImagesButton.UseVisualStyleBackColor = True
      '
      'finishTabPage
      '
      Me.finishTabPage.Location = New System.Drawing.Point(4, 22)
      Me.finishTabPage.Name = "finishTabPage"
      Me.finishTabPage.Padding = New System.Windows.Forms.Padding(3)
      Me.finishTabPage.Size = New System.Drawing.Size(728, 353)
      Me.finishTabPage.TabIndex = 8
      Me.finishTabPage.Text = "Finish"
      Me.finishTabPage.UseVisualStyleBackColor = True
      '
      'backButton
      '
      Me.backButton.Location = New System.Drawing.Point(502, 390)
      Me.backButton.Name = "backButton"
      Me.backButton.Size = New System.Drawing.Size(75, 23)
      Me.backButton.TabIndex = 2
      Me.backButton.Text = "&Back"
      Me.backButton.UseVisualStyleBackColor = True
      '
      'nextButton
      '
      Me.nextButton.Location = New System.Drawing.Point(583, 390)
      Me.nextButton.Name = "nextButton"
      Me.nextButton.Size = New System.Drawing.Size(75, 23)
      Me.nextButton.TabIndex = 3
      Me.nextButton.Text = "&Next"
      Me.nextButton.UseVisualStyleBackColor = True
      '
      'closeButton
      '
      Me.closeButton.Location = New System.Drawing.Point(664, 390)
      Me.closeButton.Name = "closeButton"
      Me.closeButton.Size = New System.Drawing.Size(75, 23)
      Me.closeButton.TabIndex = 4
      Me.closeButton.Text = "Cl&ose"
      Me.closeButton.UseVisualStyleBackColor = True
      '
      'blackLineLabel
      '
      Me.blackLineLabel.BackColor = System.Drawing.SystemColors.ControlText
      Me.wizardTableLayoutPanel.SetColumnSpan(Me.blackLineLabel, 4)
      Me.blackLineLabel.Dock = System.Windows.Forms.DockStyle.Fill
      Me.blackLineLabel.Location = New System.Drawing.Point(3, 385)
      Me.blackLineLabel.Name = "blackLineLabel"
      Me.blackLineLabel.Size = New System.Drawing.Size(736, 2)
      Me.blackLineLabel.TabIndex = 1
      Me.blackLineLabel.Text = "Label1"
      '
      'downloadFolderBrowserDialog
      '
      Me.downloadFolderBrowserDialog.ShowNewFolderButton = False
      '
      'ScanTrackerEROPForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(742, 416)
      Me.Controls.Add(Me.wizardTableLayoutPanel)
      Me.MinimumSize = New System.Drawing.Size(750, 450)
      Me.Name = "ScanTrackerEROPForm"
      Me.StatusMessage = ""
      Me.Text = "E - ROP Scan Tracker Wizard"
      CType(Me.m_ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
      Me.wizardTableLayoutPanel.ResumeLayout(False)
      Me.Wizard1.ResumeLayout(False)
      Me.welcomeTabPage.ResumeLayout(False)
      Me.welcomeTableLayoutPanel.ResumeLayout(False)
      Me.welcomeTableLayoutPanel.PerformLayout()
      CType(Me.welcomeLeftPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
      Me.step1TabPage.ResumeLayout(False)
      Me.step1TableLayoutPanel.ResumeLayout(False)
      Me.step1TableLayoutPanel.PerformLayout()
      CType(Me.publicationFolderDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      Me.step2TabPage.ResumeLayout(False)
      Me.step2TableLayoutPanel.ResumeLayout(False)
      Me.step2TableLayoutPanel.PerformLayout()
      CType(Me.pdfFileDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      Me.step3TabPage.ResumeLayout(False)
      Me.step3TableLayoutPanel.ResumeLayout(False)
      Me.step3TableLayoutPanel.PerformLayout()
      CType(Me.pageImagesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      Me.step4TabPage.ResumeLayout(False)
      Me.step4TableLayoutPanel.ResumeLayout(False)
      Me.step4TableLayoutPanel.PerformLayout()
      CType(Me.scantrackDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wizardTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Wizard1 As UI.Controls.Wizard 'Wizard.Wizard
    Friend WithEvents backButton As System.Windows.Forms.Button
    Friend WithEvents nextButton As System.Windows.Forms.Button
    Friend WithEvents closeButton As System.Windows.Forms.Button
    Friend WithEvents blackLineLabel As System.Windows.Forms.Label
    Friend WithEvents downloadFolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents welcomeTabPage As System.Windows.Forms.TabPage
    Friend WithEvents welcomeTableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents welcomeLeftPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents welcomeTitleLabel As System.Windows.Forms.Label
    Friend WithEvents welcomeDescripLabel As System.Windows.Forms.Label
    Friend WithEvents step3TabPage As System.Windows.Forms.TabPage
    Friend WithEvents step3TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents step4TabPage As System.Windows.Forms.TabPage
    Friend WithEvents processFilePagesButton As System.Windows.Forms.Button
    Friend WithEvents step2TabPage As System.Windows.Forms.TabPage
    Friend WithEvents step2TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents step2TitleLabel As System.Windows.Forms.Label
    Friend WithEvents pdfFileDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents processFilesButton As System.Windows.Forms.Button
    Friend WithEvents step1TabPage As System.Windows.Forms.TabPage
    Friend WithEvents step1TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents processPublicationFolderButton As System.Windows.Forms.Button
    Friend WithEvents step1TitleLabel As System.Windows.Forms.Label
    Friend WithEvents uncheckAllFoldersButton As System.Windows.Forms.Button
    Friend WithEvents checkAllFoldersButton As System.Windows.Forms.Button
    Friend WithEvents browseButton As System.Windows.Forms.Button
    Friend WithEvents downloadPathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents downloadPathLabel As System.Windows.Forms.Label
    Friend WithEvents publicationFolderDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents splitDoubleTruckAdsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents finishTabPage As System.Windows.Forms.TabPage
    Friend WithEvents step4TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents step4TitleLabel As System.Windows.Forms.Label
    Friend WithEvents rotateLabel As System.Windows.Forms.Label
    Friend WithEvents rotateComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents postImagesButton As System.Windows.Forms.Button
    Friend WithEvents scantrackDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents recountImagesButton As System.Windows.Forms.Button
    Friend WithEvents previewImagesButton As System.Windows.Forms.Button
    Friend WithEvents step3TitleLabel As System.Windows.Forms.Label
    Friend WithEvents pageImagesDataGridView As System.Windows.Forms.DataGridView
  End Class

End Namespace