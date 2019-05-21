<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class testdb
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Me.lblTotRecords = New System.Windows.Forms.Label()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.prgProgress = New System.Windows.Forms.ProgressBar()
        Me.cmbTables = New System.Windows.Forms.ComboBox()
        Me.btnGetAllTables = New System.Windows.Forms.Button()
        Me.btnNoOfPages = New System.Windows.Forms.Button()
        Me.lblNoOfPages = New System.Windows.Forms.Label()
        Me.cmbNoOfRecords = New System.Windows.Forms.ComboBox()
        Me.cmbAllDataBases = New System.Windows.Forms.ComboBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.lblLoadedTable = New System.Windows.Forms.Label()
        Me.grpLogo = New System.Windows.Forms.GroupBox()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.btnGetAllDataBases = New System.Windows.Forms.Button()
        Me.grpDataManipulate = New System.Windows.Forms.GroupBox()
        Me.lblPageNums = New System.Windows.Forms.Label()
        Me.userDataGridView = New System.Windows.Forms.DataGridView()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnLoadSqlServers = New System.Windows.Forms.Button()
        Me.cmbSqlServers = New System.Windows.Forms.ComboBox()
        Me.grpSqlServers = New System.Windows.Forms.GroupBox()
        Me.notifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.grpDataManipulate.SuspendLayout()
        CType(Me.userDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSqlServers.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTotRecords
        '
        Me.lblTotRecords.AutoSize = True
        Me.lblTotRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotRecords.Location = New System.Drawing.Point(234, 16)
        Me.lblTotRecords.Name = "lblTotRecords"
        Me.lblTotRecords.Size = New System.Drawing.Size(0, 13)
        Me.lblTotRecords.TabIndex = 10
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(346, 70)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(50, 23)
        Me.btnLast.TabIndex = 14
        Me.btnLast.Text = "L&ast"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(234, 70)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(50, 23)
        Me.btnNext.TabIndex = 13
        Me.btnNext.Text = ">>"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Location = New System.Drawing.Point(122, 70)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(50, 23)
        Me.btnPrevious.TabIndex = 12
        Me.btnPrevious.Text = "<<"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'prgProgress
        '
        Me.prgProgress.Location = New System.Drawing.Point(6, 259)
        Me.prgProgress.Name = "prgProgress"
        Me.prgProgress.Size = New System.Drawing.Size(217, 23)
        Me.prgProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prgProgress.TabIndex = 8
        '
        'cmbTables
        '
        Me.cmbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTables.FormattingEnabled = True
        Me.cmbTables.Items.AddRange(New Object() {"facebookInputdata"})
        Me.cmbTables.Location = New System.Drawing.Point(6, 232)
        Me.cmbTables.Name = "cmbTables"
        Me.cmbTables.Size = New System.Drawing.Size(217, 21)
        Me.cmbTables.TabIndex = 7
        '
        'btnGetAllTables
        '
        Me.btnGetAllTables.Location = New System.Drawing.Point(6, 199)
        Me.btnGetAllTables.Name = "btnGetAllTables"
        Me.btnGetAllTables.Size = New System.Drawing.Size(217, 23)
        Me.btnGetAllTables.TabIndex = 6
        Me.btnGetAllTables.Text = "Get All &Tables"
        Me.btnGetAllTables.UseVisualStyleBackColor = True
        '
        'btnNoOfPages
        '
        Me.btnNoOfPages.Location = New System.Drawing.Point(357, 41)
        Me.btnNoOfPages.Name = "btnNoOfPages"
        Me.btnNoOfPages.Size = New System.Drawing.Size(40, 23)
        Me.btnNoOfPages.TabIndex = 10
        Me.btnNoOfPages.Text = "&Set"
        Me.btnNoOfPages.UseVisualStyleBackColor = True
        '
        'lblNoOfPages
        '
        Me.lblNoOfPages.AutoSize = True
        Me.lblNoOfPages.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoOfPages.Location = New System.Drawing.Point(125, 46)
        Me.lblNoOfPages.Name = "lblNoOfPages"
        Me.lblNoOfPages.Size = New System.Drawing.Size(150, 13)
        Me.lblNoOfPages.TabIndex = 7
        Me.lblNoOfPages.Text = "No. of records per page: "
        '
        'cmbNoOfRecords
        '
        Me.cmbNoOfRecords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNoOfRecords.FormatString = "N2"
        Me.cmbNoOfRecords.FormattingEnabled = True
        Me.cmbNoOfRecords.Items.AddRange(New Object() {"15", "25", "35", "45", "55"})
        Me.cmbNoOfRecords.Location = New System.Drawing.Point(284, 43)
        Me.cmbNoOfRecords.Name = "cmbNoOfRecords"
        Me.cmbNoOfRecords.Size = New System.Drawing.Size(57, 21)
        Me.cmbNoOfRecords.TabIndex = 9
        '
        'cmbAllDataBases
        '
        Me.cmbAllDataBases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAllDataBases.FormattingEnabled = True
        Me.cmbAllDataBases.Location = New System.Drawing.Point(6, 170)
        Me.cmbAllDataBases.Name = "cmbAllDataBases"
        Me.cmbAllDataBases.Size = New System.Drawing.Size(217, 21)
        Me.cmbAllDataBases.TabIndex = 5
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(6, 115)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(59, 13)
        Me.lblPassword.TabIndex = 11
        Me.lblPassword.Text = "Password: "
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Location = New System.Drawing.Point(6, 89)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(64, 13)
        Me.lblUserName.TabIndex = 10
        Me.lblUserName.Text = "User name: "
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(123, 112)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 3
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(123, 85)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(100, 20)
        Me.txtUserName.TabIndex = 2
        '
        'lblLoadedTable
        '
        Me.lblLoadedTable.AutoSize = True
        Me.lblLoadedTable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadedTable.Location = New System.Drawing.Point(7, 16)
        Me.lblLoadedTable.Name = "lblLoadedTable"
        Me.lblLoadedTable.Size = New System.Drawing.Size(0, 13)
        Me.lblLoadedTable.TabIndex = 5
        '
        'grpLogo
        '
        Me.grpLogo.Location = New System.Drawing.Point(10, 306)
        Me.grpLogo.Name = "grpLogo"
        Me.grpLogo.Size = New System.Drawing.Size(230, 193)
        Me.grpLogo.TabIndex = 10
        Me.grpLogo.TabStop = False
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(10, 70)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(50, 23)
        Me.btnFirst.TabIndex = 11
        Me.btnFirst.Text = "&First"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'btnGetAllDataBases
        '
        Me.btnGetAllDataBases.Location = New System.Drawing.Point(6, 138)
        Me.btnGetAllDataBases.Name = "btnGetAllDataBases"
        Me.btnGetAllDataBases.Size = New System.Drawing.Size(217, 23)
        Me.btnGetAllDataBases.TabIndex = 4
        Me.btnGetAllDataBases.Text = "Get All &Databases"
        Me.btnGetAllDataBases.UseVisualStyleBackColor = True
        '
        'grpDataManipulate
        '
        Me.grpDataManipulate.Controls.Add(Me.lblPageNums)
        Me.grpDataManipulate.Controls.Add(Me.lblTotRecords)
        Me.grpDataManipulate.Controls.Add(Me.btnLast)
        Me.grpDataManipulate.Controls.Add(Me.btnNext)
        Me.grpDataManipulate.Controls.Add(Me.btnPrevious)
        Me.grpDataManipulate.Controls.Add(Me.btnFirst)
        Me.grpDataManipulate.Controls.Add(Me.btnNoOfPages)
        Me.grpDataManipulate.Controls.Add(Me.lblNoOfPages)
        Me.grpDataManipulate.Controls.Add(Me.cmbNoOfRecords)
        Me.grpDataManipulate.Controls.Add(Me.lblLoadedTable)
        Me.grpDataManipulate.Controls.Add(Me.userDataGridView)
        Me.grpDataManipulate.Controls.Add(Me.btnLoad)
        Me.grpDataManipulate.Controls.Add(Me.btnDelete)
        Me.grpDataManipulate.Controls.Add(Me.btnAdd)
        Me.grpDataManipulate.Controls.Add(Me.btnUpdate)
        Me.grpDataManipulate.Location = New System.Drawing.Point(258, 11)
        Me.grpDataManipulate.Name = "grpDataManipulate"
        Me.grpDataManipulate.Size = New System.Drawing.Size(403, 488)
        Me.grpDataManipulate.TabIndex = 9
        Me.grpDataManipulate.TabStop = False
        Me.grpDataManipulate.Text = "Add, edit, delete data"
        '
        'lblPageNums
        '
        Me.lblPageNums.AutoSize = True
        Me.lblPageNums.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPageNums.Location = New System.Drawing.Point(261, 459)
        Me.lblPageNums.Name = "lblPageNums"
        Me.lblPageNums.Size = New System.Drawing.Size(0, 13)
        Me.lblPageNums.TabIndex = 18
        '
        'userDataGridView
        '
        Me.userDataGridView.AllowUserToOrderColumns = True
        Me.userDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.userDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.userDataGridView.Location = New System.Drawing.Point(6, 99)
        Me.userDataGridView.Name = "userDataGridView"
        Me.userDataGridView.ReadOnly = True
        Me.userDataGridView.Size = New System.Drawing.Size(391, 349)
        Me.userDataGridView.TabIndex = 0
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(10, 41)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.TabIndex = 8
        Me.btnLoad.Text = "&Load data"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(168, 454)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 17
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(6, 454)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 15
        Me.btnAdd.Text = "&Add/Update"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(87, 454)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 16
        Me.btnUpdate.Text = "&Commit"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'btnLoadSqlServers
        '
        Me.btnLoadSqlServers.Location = New System.Drawing.Point(6, 29)
        Me.btnLoadSqlServers.Name = "btnLoadSqlServers"
        Me.btnLoadSqlServers.Size = New System.Drawing.Size(217, 23)
        Me.btnLoadSqlServers.TabIndex = 0
        Me.btnLoadSqlServers.Text = "Get all &Sql servers  on network"
        Me.btnLoadSqlServers.UseVisualStyleBackColor = True
        '
        'cmbSqlServers
        '
        Me.cmbSqlServers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSqlServers.FormattingEnabled = True
        Me.cmbSqlServers.Location = New System.Drawing.Point(6, 58)
        Me.cmbSqlServers.Name = "cmbSqlServers"
        Me.cmbSqlServers.Size = New System.Drawing.Size(217, 21)
        Me.cmbSqlServers.TabIndex = 1
        '
        'grpSqlServers
        '
        Me.grpSqlServers.Controls.Add(Me.prgProgress)
        Me.grpSqlServers.Controls.Add(Me.cmbTables)
        Me.grpSqlServers.Controls.Add(Me.btnGetAllTables)
        Me.grpSqlServers.Controls.Add(Me.cmbAllDataBases)
        Me.grpSqlServers.Controls.Add(Me.lblPassword)
        Me.grpSqlServers.Controls.Add(Me.lblUserName)
        Me.grpSqlServers.Controls.Add(Me.txtPassword)
        Me.grpSqlServers.Controls.Add(Me.txtUserName)
        Me.grpSqlServers.Controls.Add(Me.btnGetAllDataBases)
        Me.grpSqlServers.Controls.Add(Me.btnLoadSqlServers)
        Me.grpSqlServers.Controls.Add(Me.cmbSqlServers)
        Me.grpSqlServers.Location = New System.Drawing.Point(10, 12)
        Me.grpSqlServers.Name = "grpSqlServers"
        Me.grpSqlServers.Size = New System.Drawing.Size(230, 288)
        Me.grpSqlServers.TabIndex = 8
        Me.grpSqlServers.TabStop = False
        Me.grpSqlServers.Text = "Load and login to SQL server"
        '
        'notifyIcon1
        '
        Me.notifyIcon1.Text = "notifyIcon1"
        Me.notifyIcon1.Visible = True
        '
        'testdb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 511)
        Me.Controls.Add(Me.grpLogo)
        Me.Controls.Add(Me.grpDataManipulate)
        Me.Controls.Add(Me.grpSqlServers)
        Me.Name = "testdb"
        Me.Text = "testdb"
        Me.grpDataManipulate.ResumeLayout(False)
        Me.grpDataManipulate.PerformLayout()
        CType(Me.userDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSqlServers.ResumeLayout(False)
        Me.grpSqlServers.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents lblTotRecords As System.Windows.Forms.Label
    Private WithEvents btnLast As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnPrevious As System.Windows.Forms.Button
    Private WithEvents prgProgress As System.Windows.Forms.ProgressBar
    Private WithEvents cmbTables As System.Windows.Forms.ComboBox
    Private WithEvents btnGetAllTables As System.Windows.Forms.Button
    Private WithEvents btnNoOfPages As System.Windows.Forms.Button
    Private WithEvents lblNoOfPages As System.Windows.Forms.Label
    Private WithEvents cmbNoOfRecords As System.Windows.Forms.ComboBox
    Private WithEvents cmbAllDataBases As System.Windows.Forms.ComboBox
    Private WithEvents lblPassword As System.Windows.Forms.Label
    Private WithEvents lblUserName As System.Windows.Forms.Label
    Private WithEvents txtPassword As System.Windows.Forms.TextBox
    Private WithEvents txtUserName As System.Windows.Forms.TextBox
    Private WithEvents lblLoadedTable As System.Windows.Forms.Label
    Private WithEvents grpLogo As System.Windows.Forms.GroupBox
    Private WithEvents btnFirst As System.Windows.Forms.Button
    Private WithEvents btnGetAllDataBases As System.Windows.Forms.Button
    Private WithEvents grpDataManipulate As System.Windows.Forms.GroupBox
    Private WithEvents lblPageNums As System.Windows.Forms.Label
    Private WithEvents userDataGridView As System.Windows.Forms.DataGridView
    Private WithEvents btnLoad As System.Windows.Forms.Button
    Private WithEvents btnDelete As System.Windows.Forms.Button
    Private WithEvents btnAdd As System.Windows.Forms.Button
    Private WithEvents btnUpdate As System.Windows.Forms.Button
    Private WithEvents btnLoadSqlServers As System.Windows.Forms.Button
    Private WithEvents cmbSqlServers As System.Windows.Forms.ComboBox
    Private WithEvents grpSqlServers As System.Windows.Forms.GroupBox
    Private WithEvents notifyIcon1 As System.Windows.Forms.NotifyIcon
End Class
