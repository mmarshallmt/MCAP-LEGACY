Namespace UI

  Public Class ScanTrackerEROPForm
    Implements UI.IForm


#Region " Enumerators "

    ''' <summary>
    ''' Enum for steps in Wizard.
    ''' </summary>
    ''' <remarks></remarks>
    Enum WizardStepEnum
      Welcome = 1
      Step1
      Step2
      Step3
      Step4
      Finish
    End Enum

#End Region


    Private m_wizardStep As WizardStepEnum
    Private m_progressForm As UI.Controls.ProgressInformationForm
    Private WithEvents m_processor As UI.Processors.ScanTrackerEROP


    ''' <summary>
    ''' Gets processor for E - ROP Scan Tracker processor.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Processor() As UI.Processors.ScanTrackerEROP
      Get
        Return m_processor
      End Get
    End Property

    ''' <summary>
    ''' Gets or sets current step for wizard.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property WizardStep() As WizardStepEnum
      Get
        Return m_wizardStep
      End Get
      Set(ByVal value As WizardStepEnum)
        m_wizardStep = value
        EnableDisableControls(m_wizardStep)
      End Set
    End Property


#Region "IForm Implementation "

    Public Event ApplyingUserCredentials() Implements UI.IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements UI.IForm.UserCredentialsApplied

    Public Event FormInitialized() Implements UI.IForm.FormInitialized
    Public Event InitializingForm() Implements UI.IForm.InitializingForm

    Public Sub ApplyUserCredentials() Implements UI.IForm.ApplyUserCredentials

    End Sub

    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

      RaiseEvent InitializingForm()
      Me.SuspendLayout()
      Me.FormState = formStatus

      m_processor = New Processors.ScanTrackerEROP()
      Processor.Initialize()

      Me.ResumeLayout(False)

      EnableDisableControls(WizardStepEnum.Welcome)

      RaiseEvent FormInitialized()

    End Sub

#End Region


    Private Shadows Sub EnableDisableControls(ByVal wizardStep As WizardStepEnum)
      Select Case WizardStep
        Case WizardStepEnum.Welcome
          Me.backButton.Enabled = False
          Me.nextButton.Enabled = True
          Me.closeButton.Enabled = True
        Case WizardStepEnum.Step1
          Me.backButton.Enabled = True
          Me.nextButton.Enabled = True
          Me.closeButton.Enabled = True
        Case WizardStepEnum.Step2
          Me.backButton.Enabled = True
          Me.nextButton.Enabled = True
          Me.closeButton.Enabled = True
        Case WizardStepEnum.Step3
          Me.backButton.Enabled = True
          Me.nextButton.Enabled = True
          Me.closeButton.Enabled = True
        Case WizardStepEnum.Finish
          Me.backButton.Enabled = False
          Me.nextButton.Enabled = False
          Me.closeButton.Enabled = True
      End Select
    End Sub

    Private Sub SetUIForProcessing(ByVal currentStep As WizardStepEnum, ByVal isProcessed As Boolean)

      backButton.Enabled = isProcessed
      nextButton.Enabled = isProcessed
      closeButton.Enabled = isProcessed

      Select Case currentStep
        Case WizardStepEnum.Step1
          browseButton.Enabled = isProcessed
          checkAllFoldersButton.Enabled = isProcessed
          uncheckAllFoldersButton.Enabled = isProcessed
          processPublicationFolderButton.Enabled = isProcessed
        Case WizardStepEnum.Step2
          processFilesButton.Enabled = isProcessed
        Case WizardStepEnum.Step3
          processFilePagesButton.Enabled = isProcessed
        Case WizardStepEnum.Step4
          recountImagesButton.Enabled = isProcessed
          previewImagesButton.Enabled = isProcessed
          postImagesButton.Enabled = isProcessed
      End Select

    End Sub


    Private Sub wizardTestForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

      Me.WizardStep = WizardStepEnum.Welcome
      m_processor = New UI.Processors.ScanTrackerEROP()
      Me.publicationFolderDataGridView.DataSource = Me.Processor.Data.EROPLog
      PreparePublicationFolderDataGridView()
      Me.pdfFileDataGridView.DataSource = Me.Processor.Data.EROPFileLog
      PreparePDFFileDataGridView()
      Me.pageImagesDataGridView.DataSource = Me.Processor.Data.EROPFilePageLog
      PreparePageImagesDataGridViewDataGridView()
      Me.scantrackDataGridView.DataSource = Me.Processor.Data.ImageMovement
      PrepareScanTrackDataGridViewDataGridView()

    End Sub

    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click
      Me.Close()
    End Sub

    Private Sub backButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles backButton.Click
      Select Case Me.WizardStep
        Case WizardStepEnum.Step1
          Me.Wizard1.SelectTab(0)
          Me.WizardStep = WizardStepEnum.Welcome
        Case WizardStepEnum.Step2
          Me.Wizard1.SelectTab(1)
          Me.WizardStep = WizardStepEnum.Step1
        Case WizardStepEnum.Step3
          Me.Wizard1.SelectTab(2)
          Me.WizardStep = WizardStepEnum.Step2
        Case WizardStepEnum.Step4
          Me.Wizard1.SelectTab(3)
          Me.WizardStep = WizardStepEnum.Step3
        Case WizardStepEnum.Finish
          Me.Wizard1.SelectTab(4)
          Me.WizardStep = WizardStepEnum.Step4
      End Select
    End Sub

    Private Sub nextButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles nextButton.Click
      Select Case Me.WizardStep
        Case WizardStepEnum.Welcome
          Me.Wizard1.SelectTab(1)
          Me.WizardStep = WizardStepEnum.Step1
        Case WizardStepEnum.Step1
          If ValidateStep1() Then
            Me.Wizard1.SelectTab(2)
            Me.WizardStep = WizardStepEnum.Step2
          End If
        Case WizardStepEnum.Step2
          If ValidateStep2() Then
            Me.Wizard1.SelectTab(3)
            Me.WizardStep = WizardStepEnum.Step3
          End If
        Case WizardStepEnum.Step3
          If ValidateStep3() Then
            Me.Wizard1.SelectTab(4)
            Me.WizardStep = WizardStepEnum.Step4
          End If
        Case WizardStepEnum.Step4
          Me.Wizard1.SelectTab(5)
          Me.WizardStep = WizardStepEnum.Finish
      End Select
    End Sub


#Region " Step 1 related methods and events "


    ''' <summary>
    ''' Checks for existance of status and note columns and if not found, add them to publicationFolderDataGridView.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PreparePublicationFolderDataGridView()

      With Me.publicationFolderDataGridView
        .Columns("EROPLogId").Visible = False
        .Columns("PublicationId").HeaderText = "Publication Id"
        .Columns("PublicationId").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("DownloadDt").HeaderText = "Download Date"
        .Columns("DownloadDt").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("FileCount").HeaderText = "File Count"
        .Columns("FileCount").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("IsZip").HeaderText = "Is Zip?"
        .Columns("IsZip").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("VehicleId").HeaderText = "Vehicle Id"
        .Columns("VehicleId").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("CreateDt").HeaderText = "Creation Date"
        .Columns("CreateDt").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("UserId").Visible = False
        If .Columns.Contains("Status") Then .Columns("Status").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        If .Columns.Contains("Note") Then
          .Columns("Note").MinimumWidth = .Columns("Note").Width
          .Columns("Note").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If
        If .Columns.Contains("IsMarked") Then
          .Columns("IsMarked").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
          .Columns("IsMarked").DisplayIndex = 0
          .Columns("IsMarked").HeaderText = "Convert"
        End If

        .ReadOnly = False

        For i As Integer = 1 To .Columns.Count - 1
          .Columns(i).ReadOnly = True
        Next

        If .Columns.Contains("IsMarked") Then .Columns("IsMarked").ReadOnly = False
      End With

    End Sub

    ''' <summary>
    ''' Marks rows of DataGridView as read only if the publication status is not "Pending" or "Processed"
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MakeInvalidPublicationRowsReadOnly()

      For i As Integer = 0 To publicationFolderDataGridView.RowCount - 1
        With publicationFolderDataGridView.Rows(i)
          .ReadOnly = Not (.Cells("Status").Value.ToString().ToUpper() = "PENDING" _
                           OrElse .Cells("Status").Value.ToString().ToUpper() = "PROCESSED")
        End With
      Next

    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles browseButton.Click
      Dim downloadPath As String
      Dim userResponse As System.Windows.Forms.DialogResult


      With Me.downloadFolderBrowserDialog
        .Description = "Select download folder, where all E - ROPs are downloaded."
        userResponse = .ShowDialog(Me)
        If userResponse = Windows.Forms.DialogResult.Cancel Then
          Exit Sub
        End If
        downloadPath = .SelectedPath
      End With

      Me.Processor.Data.EROPLog.Rows.Clear()
      Me.downloadPathTextBox.Text = downloadPath

      Me.Cursor = Cursors.WaitCursor
      m_progressForm = New UI.Controls.ProgressInformationForm()
      m_progressForm.MessageText = String.Empty
      m_progressForm.ProgressText = String.Empty
      m_progressForm.TopLevel = True
      m_progressForm.Show(Me)

      Try
        Me.Processor.ValidateDownloadPath(downloadPath)
        Me.Processor.QueueSubfoldersForProcessing(downloadPath)
        m_progressForm.Close()
      Catch ex As System.IO.DirectoryNotFoundException
        m_progressForm.Close()
        Me.Processor.Log(0, String.Empty, ex.Message)
        MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch ex As System.IO.IOException
        m_progressForm.Close()
        Me.Processor.Log(0, String.Empty, ex.Message)
        MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch ex As Exception
        m_progressForm.Close()
        Me.Processor.Log(0, String.Empty, ex.Message)
        MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      m_progressForm.Dispose()
      m_progressForm = Nothing
      Me.Cursor = Cursors.Default

      Me.Processor.Data.EROPLog.DefaultView.Sort = "PublicationId"

    End Sub

    Private Sub checkAllFolderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkAllFoldersButton.Click

      SetUIForProcessing(WizardStepEnum.Step1, False)

      Me.Cursor = Cursors.WaitCursor
      m_progressForm = New UI.Controls.ProgressInformationForm()
      m_progressForm.progressProgressBar.Minimum = 0
      m_progressForm.progressProgressBar.Value = 0
      m_progressForm.progressProgressBar.Maximum = Me.Processor.Data.EROPLog.Count
      m_progressForm.TopLevel = True
      m_progressForm.Show(Me)

      Try
        Me.Processor.MarkAllEROPLogRows()
      Catch ex As InvalidOperationException
        m_progressForm.Hide()
        MessageBox.Show("There is no unmarked row with status as Pending", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Catch ex As Exception
        m_progressForm.Hide()
        MessageBox.Show("Unknown error has occurred.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try    

      m_progressForm.progressProgressBar.Value = m_progressForm.progressProgressBar.Maximum
      m_progressForm.Close()
      m_progressForm.Dispose()
      m_progressForm = Nothing
      Me.Cursor = Cursors.Default

      SetUIForProcessing(WizardStepEnum.Step1, True)

    End Sub

    Private Sub uncheckAllFolderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles uncheckAllFoldersButton.Click

      SetUIForProcessing(WizardStepEnum.Step1, False)

      Me.Cursor = Cursors.WaitCursor
      m_progressForm = New UI.Controls.ProgressInformationForm()
      m_progressForm.progressProgressBar.Minimum = 0
      m_progressForm.progressProgressBar.Value = 0
      m_progressForm.progressProgressBar.Maximum = Me.Processor.Data.EROPLog.Count
      m_progressForm.TopLevel = True
      m_progressForm.Show(Me)

      Me.Processor.UnmarkAllEROPLogRows()     

      m_progressForm.progressProgressBar.Value = m_progressForm.progressProgressBar.Maximum
      m_progressForm.Close()
      m_progressForm.Dispose()
      m_progressForm = Nothing
      Me.Cursor = Cursors.Default

      SetUIForProcessing(WizardStepEnum.Step1, True)

    End Sub

    Private Sub processPublicationFolderButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles processPublicationFolderButton.Click
      Dim errorOccurred As Boolean = False


      If Me.Processor.HasMarkedEROPLogRows() = False Then
        MessageBox.Show("Mark at least one publication for processing." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      SetUIForProcessing(WizardStepEnum.Step1, False)

      m_progressForm = New UI.Controls.ProgressInformationForm()
      With m_progressForm
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = Me.Processor.GetMarkedEROPLogRowCount()
        .MessageText = String.Empty
        .ProgressText = String.Empty
        .StartPosition = FormStartPosition.CenterScreen
        .ShowInTaskbar = False
        .TopLevel = True
        .Show(Me)
        Application.DoEvents()
      End With

      Try
        Me.Processor.ValidateMarkedPublications(True, Me.downloadPathTextBox.Text)
        Me.Processor.SynchronizeEROPLogDataTable()
        MakeInvalidPublicationRowsReadOnly()
        m_progressForm.Close()
      Catch ex As System.IO.DirectoryNotFoundException
        errorOccurred = True
        m_progressForm.Close()
        Me.Processor.Log(0, String.Empty, ex.Message)
        MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch ex As Exception
        errorOccurred = True
        m_progressForm.Close()
        Me.Processor.Log(0, String.Empty, ex.Message)
        MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      m_progressForm.Dispose()
      m_progressForm = Nothing
      Me.Cursor = Cursors.Default

      SetUIForProcessing(WizardStepEnum.Step1, True)      
      If errorOccurred Then
        nextButton.Enabled = False
      Else
        MessageBox.Show("Only new publications are marked for processing. Change, if required.", _
                        ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End If

    End Sub

    Private Function ValidateStep1() As Boolean

      If Processor.IsAnyPublicationMarked() = False Then
        MessageBox.Show("Mark at least one publication to proceed." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return False
      ElseIf Processor.IsAllMarkedPublicationProcessed() = False Then
        MessageBox.Show("All marked publication should be processed before proceeding. Click Process button before clicking on Next." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return False
      Else
        Return True
      End If

    End Function


    Private Sub m_processor_EROPLogEntriesLoaded(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_processor.EROPLogEntriesLoaded

      If m_progressForm Is Nothing Then Exit Sub

      m_progressForm.MessageText = "Existing entries, for publications, downloaded on same date are loaded."

    End Sub

    Private Sub m_processor_LoadingEROPLogEntries(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_processor.LoadingEROPLogEntries

      If m_progressForm Is Nothing Then Exit Sub

      m_progressForm.MessageText = "Loading existing entries for publications downloaded on same date."

    End Sub

    Private Sub m_processor_QueuingSubfoldersForProcessing(ByVal sender As Object, ByVal e As UI.Processors.FileSystemEventArgs) Handles m_processor.QueuingSubfoldersForProcessing

      If m_progressForm Is Nothing Then Exit Sub

      m_progressForm.MessageText = String.Format("Queuing subfolders under {0} for processing...", e.Path)

    End Sub

    Private Sub m_processor_QueuingFolder(ByVal sender As Object, ByVal e As UI.Processors.DirectoryEventArgs) Handles m_processor.QueuingFolder

      If m_progressForm Is Nothing Then Exit Sub

      m_progressForm.ProgressText = String.Format("Queuing subfolder {0} of {1}, subfolder: {2} for processing...", e.CurrentSubdirectoryIndex, e.TotalSubdirectories, e.DirectoryPath)

    End Sub

    Private Sub m_processor_InvalidSubfolderForProcessingQueue(ByVal sender As Object, ByVal e As UI.Processors.DirectoryEventArgs) Handles m_processor.InvalidSubfolderForProcessingQueue

      If m_progressForm Is Nothing Then Exit Sub

      m_progressForm.ProgressText = String.Format("Subfolder {0} is not queued. It is invalid for processing...", e.DirectoryPath)
      Me.Processor.Log(0, String.Empty, String.Format("Subfolder {0} is not queued. It is invalid for processing...", e.DirectoryPath))

    End Sub

    Private Sub m_processor_FolderQueued(ByVal sender As Object, ByVal e As UI.Processors.DirectoryEventArgs) Handles m_processor.FolderQueued

      If m_progressForm Is Nothing Then Exit Sub

      m_progressForm.ProgressText = String.Format("Queued subfolder {0} of {1}, subfolder: {2} for processing...", e.CurrentSubdirectoryIndex, e.TotalSubdirectories, e.DirectoryPath)

    End Sub

    Private Sub m_processor_SubfoldersQueuedForProcessing(ByVal sender As Object, ByVal e As UI.Processors.FileSystemEventArgs) Handles m_processor.SubfoldersQueuedForProcessing

      If m_progressForm Is Nothing Then Exit Sub

      m_progressForm.MessageText = String.Format("Subfolders under {0} are queued for processing...", e.Path)

    End Sub

    Private Sub m_processor_MarkingRow(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_processor.MarkingRow

      If m_progressForm Is Nothing Then Exit Sub

      m_progressForm.MessageText = "Marking rows for processing..."
      m_progressForm.progressProgressBar.Value += 1
      m_progressForm.ProgressText = String.Format("Marking publication {0} of {1}", m_progressForm.progressProgressBar.Value, Me.Processor.Data.EROPLog.Count)

    End Sub

    Private Sub m_processor_UnmarkingRow(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_processor.UnmarkingRow

      If m_progressForm Is Nothing Then Exit Sub

      m_progressForm.MessageText = "Unmarking rows for processing..."
      m_progressForm.progressProgressBar.Value += 1
      m_progressForm.ProgressText = String.Format("Unmarking publication {0} of {1}", m_progressForm.progressProgressBar.Value, Me.Processor.Data.EROPLog.Count)

    End Sub

    Private Sub m_processor_ValidatingMarkedPublications(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_processor.ValidatingMarkedPublications

      If m_progressForm Is Nothing Then Exit Sub

      m_progressForm.MessageText = "Validating marked publications....."
      m_progressForm.progressProgressBar.Visible = False
      m_progressForm.ProgressText = "This may take some time. Please wait..."

    End Sub

    Private Sub m_processor_MarkedPublicationsValidated(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_processor.MarkedPublicationsValidated

    End Sub

    Private Sub m_processor_PublicationValidated(ByVal sender As Object, ByVal e As UI.Processors.EROPLogEventArgs) Handles m_processor.PublicationValidated

      With m_progressForm
        .progressProgressBar.Value += 1
        .MessageText = String.Format("Processing {0} of {1}.", .progressProgressBar.Value, .progressProgressBar.Maximum)
      End With
      Application.DoEvents()

    End Sub


#End Region


#Region " Step 2 related methods and events "


    ''' <summary>
    ''' Checks for existance of status and note columns and if not found, add them to publicationFolderDataGridView.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PreparePDFFileDataGridView()

      With Me.pdfFileDataGridView
        .Columns("EROPFileLogId").Visible = False
        .Columns("EROPLogId").Visible = False
        .Columns("FileName").HeaderText = "File Name"
        .Columns("FileName").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("CreateDt").HeaderText = "Creation Date"
        .Columns("CreateDt").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("ValidateDt").HeaderText = "Validated On"
        .Columns("ValidateDt").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("Note").MinimumWidth = .Columns("Note").Width
        .Columns("Note").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        .Columns("UserId").Visible = False
        .ReadOnly = True
      End With

    End Sub

    Private Sub step2TabPage_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles step2TabPage.Enter

      Processor.LoadEROPFileLogForMarkedPublications()
      PreparePDFFileDataGridView()

    End Sub

    Private Sub processFilesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles processFilesButton.Click
      Dim errorOccurred As Boolean = False


      SetUIForProcessing(WizardStepEnum.Step2, False)

      Me.Cursor = Cursors.WaitCursor
      m_progressForm = New UI.Controls.ProgressInformationForm()
      With m_progressForm
        .MessageText = String.Empty
        .ProgressText = String.Empty
        .TopLevel = True
        .Show(Me)
      End With

      Try
        Me.Processor.UnzipMarkedPublications(Me.downloadPathTextBox.Text)
        Me.Processor.LoadEROPFileLogForMarkedPublications()
        Me.Processor.CrawlToAddDownloadedPublicationFileInformation(Me.downloadPathTextBox.Text)
        Me.Processor.ValidatePDFFiles(Me.downloadPathTextBox.Text)
        Me.Processor.SynchronizeEROPFileLogDataTable()
        m_progressForm.Close()
      Catch ex As System.Data.SqlClient.SqlException
        errorOccurred = True
        m_progressForm.Close()
        Me.Processor.Log(0, String.Empty, ex.Message)
        MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch ex As Exception
        errorOccurred = True
        m_progressForm.Close()
        Me.Processor.Log(0, String.Empty, ex.Message)
        MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      m_progressForm.Dispose()
      m_progressForm = Nothing
      Me.Cursor = Cursors.Default

      SetUIForProcessing(WizardStepEnum.Step2, True)
      nextButton.Enabled = Not errorOccurred

    End Sub

    Private Function ValidateStep2() As Boolean

      If Processor.IsAnyPublicationFilesValid() Then
        Return True
      Else
        MessageBox.Show("There is no valid PDF file. There has to be at least one valid PDF file to proceed." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return False
      End If

    End Function


    Private Sub m_processor_UnzippingAllMarkedPublications(ByVal sender As Object, ByVal e As UI.Processors.UnzipEventArgs) Handles m_processor.UnzippingAllMarkedPublications

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = "Unzipping zip files in marked publication(s) folder."
        .ProgressText = String.Empty
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = e.Count
      End With

    End Sub

    Private Sub m_processor_UnzippingMarkedPublication(ByVal sender As Object, ByVal e As UI.Processors.UnzipEventArgs) Handles m_processor.UnzippingMarkedPublication

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        If e.Count = 1 Then
          .MessageText = String.Format("Unzipping {0} zip file under folder for publication {1}", e.Count, e.PublicationId)
        Else
          .MessageText = String.Format("Unzipping {0} zip files under folder for publication {1}", e.Count, e.PublicationId)
        End If
        .ProgressText = String.Empty
      End With

    End Sub

    Private Sub m_processor_ExtractingZipFile(ByVal sender As Object, ByVal e As UI.Processors.UnzipFileEventArgs) Handles m_processor.ExtractingZipFile

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .ProgressText = String.Format("Unzipping zip file: {0}", e.ZipFilePath)
      End With

    End Sub

    Private Sub m_processor_MarkedPublicationUnzipped(ByVal sender As Object, ByVal e As UI.Processors.UnzipEventArgs) Handles m_processor.MarkedPublicationUnzipped

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        If e.Count = 1 Then
          .MessageText = String.Format("{0} zip file under folder for publication {1} are processed.", e.Count, e.PublicationId)
        Else
          .MessageText = String.Format("{0} zip files under folder for publication {1} are processed.", e.Count, e.PublicationId)
        End If
        .ProgressText = String.Empty
        .progressProgressBar.Value += 1
      End With

    End Sub

    Private Sub m_processor_AllMarkedPublicationsUnzipped(ByVal sender As Object, ByVal e As UI.Processors.UnzipEventArgs) Handles m_processor.AllMarkedPublicationsUnzipped

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = "Zip files in all marked publication(s) folders are unzipped."
        .ProgressText = String.Empty
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = .progressProgressBar.Maximum
      End With

    End Sub

    Private Sub m_processor_LoadingEROPFileLogEntriesForMarkedPublications(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_processor.LoadingEROPFileLogEntriesForMarkedPublications

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = 0
        .MessageText = "Loading information about files for marked publications from database."
        .ProgressText = "Please wait, this may take some time..."
      End With

    End Sub

    Private Sub m_processor_EROPFileLogEntriesForMarkedPublicationsLoaded(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_processor.EROPFileLogEntriesForMarkedPublicationsLoaded

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = 0
        .MessageText = "Information about files for marked publications loaded from database."
        .ProgressText = String.Empty
      End With

    End Sub

    Private Sub m_processor_CrawlingMarkedPublicationFolders(ByVal sender As Object, ByVal e As UI.Processors.FileSystemEventArgs) Handles m_processor.CrawlingMarkedPublicationFolders

      Me.StatusMessage = String.Format("Checking files in file-system against entries in database. This may take some time. Processing Directory: {0}.", e.Path)

    End Sub

    Private Sub m_processor_CrawlingMarkedPublicationFolder(ByVal sender As Object, ByVal e As UI.Processors.DirectoryEventArgs) Handles m_processor.CrawlingMarkedPublicationFolder

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = 0 'e.TotalSubdirectories
        .MessageText = String.Format("Checking files in file-system against entries in database. Processing directory({0}/{1}): {2}.", e.CurrentSubdirectoryIndex, e.TotalSubdirectories, e.DirectoryPath)
      End With

    End Sub

    Private Sub m_processor_CrawlingFile(ByVal sender As Object, ByVal e As UI.Processors.FileEventArgs) Handles m_processor.CrawlingFile

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .progressProgressBar.Maximum = e.TotalFiles
        .ProgressText = String.Format("Processing file({0}/{1}): {2}.", e.CurrentFileIndex, e.TotalFiles, e.FilePath)
      End With

    End Sub

    Private Sub m_processor_CrawledFile(ByVal sender As Object, ByVal e As UI.Processors.FileEventArgs) Handles m_processor.CrawledFile

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .progressProgressBar.Value = e.CurrentFileIndex
        .ProgressText = String.Format("Processed file({0}/{1}): {2}.", e.CurrentFileIndex, e.TotalFiles, e.FilePath)
      End With

    End Sub

    Private Sub m_processor_CrawledMarkedPublicationFolder(ByVal sender As Object, ByVal e As UI.Processors.DirectoryEventArgs) Handles m_processor.CrawledMarkedPublicationFolder

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        '.progressProgressBar.Value = e.CurrentSubdirectoryIndex
        .MessageText = String.Format("Checked files in file-system against entries in database. Processed directory ({0}/{1}): {2}.", e.CurrentSubdirectoryIndex, e.TotalSubdirectories, e.DirectoryPath)
      End With

    End Sub

    Private Sub m_processor_CrawledMarkedPublicationFolders(ByVal sender As Object, ByVal e As UI.Processors.FileSystemEventArgs) Handles m_processor.CrawledMarkedPublicationFolders

      Me.StatusMessage = String.Format("Checked files in file-system against entries in database. Processed directory: {0}", e.Path)

    End Sub

    Private Sub m_processor_ValidatingPDFFileForMarkedPublications(ByVal sender As Object, ByVal e As UI.Processors.FileSystemEventArgs) Handles m_processor.ValidatingPDFFileForMarkedPublications

      Me.StatusMessage = "Validating PDF files for marked publications. This may take some time."

    End Sub

    Private Sub m_processor_PDFFileForMarkedPublicationsValidated(ByVal sender As Object, ByVal e As UI.Processors.FileSystemEventArgs) Handles m_processor.PDFFileForMarkedPublicationsValidated

      Me.StatusMessage = String.Empty '"PDF files for marked publications validated."

    End Sub

    Private Sub m_processor_ValidatingMarkedPublicationFiles(ByVal sender As Object, ByVal e As UI.Processors.DirectoryEventArgs) Handles m_processor.ValidatingMarkedPublicationFiles

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = 0 'e.TotalSubdirectories
        .MessageText = String.Format("Validating PDF files in directory ({0}/{1}): {2}.", e.CurrentSubdirectoryIndex, e.TotalSubdirectories, e.DirectoryPath)
      End With

    End Sub

    Private Sub m_processor_MarkedPublicationFilesValidated(ByVal sender As Object, ByVal e As UI.Processors.DirectoryEventArgs) Handles m_processor.MarkedPublicationFilesValidated

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        '.progressProgressBar.Value = e.CurrentSubdirectoryIndex
        .MessageText = String.Format("Validated PDF files in directory ({0}/{1}): {2}.", e.CurrentSubdirectoryIndex, e.TotalSubdirectories, e.DirectoryPath)
      End With

    End Sub

    Private Sub m_processor_ValidatingFile(ByVal sender As Object, ByVal e As UI.Processors.FileEventArgs) Handles m_processor.ValidatingFile

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .progressProgressBar.Maximum = e.TotalFiles
        .ProgressText = String.Format("Validating PDF files in directory ({0}/{1}): {2}.", e.CurrentFileIndex, e.TotalFiles, e.FilePath)
      End With

    End Sub

    Private Sub m_processor_InvalidFile(ByVal sender As Object, ByVal e As UI.Processors.FileEventArgs) Handles m_processor.InvalidFile

    End Sub

    Private Sub m_processor_FileValidated(ByVal sender As Object, ByVal e As UI.Processors.FileEventArgs) Handles m_processor.FileValidated

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .progressProgressBar.Value = e.CurrentFileIndex
        .ProgressText = String.Format("Validated PDF files in directory ({0}/{1}): {2}.", e.CurrentFileIndex, e.TotalFiles, e.FilePath)
      End With

    End Sub

    Private Sub m_processor_SynchronizingEROPFileLogEntriesForMarkedPublications(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_processor.SynchronizingEROPFileLogEntriesForMarkedPublications

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = "Saving file information in database."
        .progressProgressBar.Visible = False
        .ProgressText = String.Empty
      End With

    End Sub

    Private Sub m_processor_EROPFileLogEntriesForMarkedPublicationsSynchronized(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_processor.EROPFileLogEntriesForMarkedPublicationsSynchronized

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = "File information saved in database."
        .progressProgressBar.Visible = False
        .ProgressText = String.Empty
      End With

    End Sub


#End Region


#Region " Step 3 related methods and events "


    ''' <summary>
    ''' Prepares data grid view to display PDF file page image information.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PreparePageImagesDataGridViewDataGridView()

      With Me.pageImagesDataGridView
        .Columns("EROPLogId").Visible = False
        .Columns("EROPFileLogId").Visible = False
        .Columns("EROPFilePageLogId").Visible = False
        .Columns("Market").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("Publication").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("FileName").HeaderText = "File Name"
        .Columns("FileName").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("Page").HeaderText = "Page Number"
        .Columns("Page").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("IsDoubleTruck").HeaderText = "Double Truck"
        .Columns("IsDoubleTruck").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("ImageName").HeaderText = "Image Name"
        .Columns("ImageName").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("ConvertDt").HeaderText = "Created On"
        .Columns("ConvertDt").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("Note").MinimumWidth = .Columns("Note").Width
        .Columns("Note").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        .Columns("UserId").Visible = False
        .ReadOnly = True
      End With

    End Sub

    Private Sub step3TabPage_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles step3TabPage.Enter

      Processor.LoadEROPFilePageLogForMarkedPublications()
      Processor.Data.EROPFilePageLog.DefaultView.Sort = "Market, Publication, Page, ImageName"
      PreparePageImagesDataGridViewDataGridView()

    End Sub

    Private Sub processFilePagesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles processFilePagesButton.Click
      Dim errorOccurred As Boolean = False


      SetUIForProcessing(WizardStepEnum.Step3, False)

      Me.Cursor = Cursors.WaitCursor
      m_progressForm = New UI.Controls.ProgressInformationForm()
      With m_progressForm
        .MessageText = String.Empty
        .ProgressText = String.Empty
        .TopLevel = True
        .Show(Me)
      End With

      Try
                'Processor.LogFile(3001, String.Format("Converting PDF files to JPG. Download Folder:{0}", Me.downloadPathTextBox.Text))
        Processor.ConvertPDFFilePagesToJpg(Me.downloadPathTextBox.Text)
        If splitDoubleTruckAdsCheckBox.Checked Then Processor.IdentifyAndSplitDoubleTruckAds(Me.downloadPathTextBox.Text)
        Processor.SynchronizeEROPFilePageDataTable()
        m_progressForm.Close()
                'Processor.LogFile(3002, String.Format("Converted PDF files to JPG. Download Folder:{0}", Me.downloadPathTextBox.Text))
      Catch ex As System.Data.SqlClient.SqlException
        errorOccurred = True
        m_progressForm.Close()
        Me.Processor.Log(0, String.Empty, ex.Message)
                ' Processor.LogFile(3006, String.Format("Message{0}. Info{1}.", ex.Message, ex.StackTrace))
        MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch ex As System.IO.IOException
        errorOccurred = True
        m_progressForm.Close()
        Me.Processor.Log(0, String.Empty, ex.Message)
                'Processor.LogFile(3007, String.Format("Message{0}. Info{1}.", ex.Message, ex.StackTrace))
        MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch ex As Exception
        errorOccurred = True
        m_progressForm.Close()
        Me.Processor.Log(0, String.Empty, ex.Message)
                'Processor.LogFile(3008, String.Format("Message{0}. Info{1}.", ex.Message, ex.StackTrace))
        MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      m_progressForm.Dispose()
      m_progressForm = Nothing
      Me.Cursor = Cursors.Default

      SetUIForProcessing(WizardStepEnum.Step3, True)
      nextButton.Enabled = Not errorOccurred

    End Sub

    Private Function ValidateStep3() As Boolean

      If Processor.IsAnyPublicationFilesValid() Then
        Return True
      Else
        MessageBox.Show("There is no valid PDF file. There has to be at least one valid PDF file to proceed." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return False
      End If

    End Function


    Private Sub m_processor_ConvertingPublicationsToImages(ByVal sender As Object, ByVal e As UI.Processors.ConversionEventArgs) Handles m_processor.ConvertingPublicationsToImages

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = "Converting publication files into images. This may take some time."
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = 0
        .ProgressText = String.Empty
      End With

    End Sub

    Private Sub m_processor_ConvertedPublicationsToImages(ByVal sender As Object, ByVal e As UI.Processors.ConversionEventArgs) Handles m_processor.ConvertedPublicationsToImages

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = String.Empty
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = 0
        .ProgressText = String.Empty
      End With

    End Sub

    Private Sub m_processor_ConvertingPDFFilesToImages(ByVal sender As Object, ByVal e As UI.Processors.PublicationConversionEventArgs) Handles m_processor.ConvertingPDFFilesToImages

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = String.Format("Converting PDF file pages to images for publication({0}/{1}): {2}", e.CurrentPublicationIndex, e.TotalPublications, e.PublicationFolderPath)
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = 0
        .ProgressText = String.Empty
      End With

    End Sub

    Private Sub m_processor_ConvertedPDFFilesToImages(ByVal sender As Object, ByVal e As UI.Processors.PublicationConversionEventArgs) Handles m_processor.ConvertedPDFFilesToImages

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = String.Empty
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = 0
        .ProgressText = String.Empty
      End With

    End Sub

    Private Sub m_processor_ConvertingPDFFilePagesToImages(ByVal sender As Object, ByVal e As UI.Processors.FileConversionEventArgs) Handles m_processor.ConvertingPDFFilePagesToImages

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = e.TotalPages
        .ProgressText = String.Format("Converting file({0}/{1}).", e.CurrentFileIndex, e.TotalFiles)
      End With

    End Sub

    Private Sub m_processor_ConvertedPDFFilePagesToImages(ByVal sender As Object, ByVal e As UI.Processors.FileConversionEventArgs) Handles m_processor.ConvertedPDFFilePagesToImages

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = 0
        .ProgressText = String.Format("Converted file({0}/{1}).", e.CurrentFileIndex, e.TotalFiles)
      End With

    End Sub

    Private Sub m_processor_ConvertingPDFFilePageToImage(ByVal sender As Object, ByVal e As UI.Processors.PageConversionEventArgs) Handles m_processor.ConvertingPDFFilePageToImage

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .ProgressText = String.Format("Converting page {0}/{1}, file({2}/{3}): {4}.", e.PageNumber, e.TotalPages, e.CurrentFileIndex, e.TotalFiles, e.FilePath)
      End With

    End Sub

    Private Sub m_processor_ConvertedPDFFilePageToImage(ByVal sender As Object, ByVal e As UI.Processors.PageConversionEventArgs) Handles m_processor.ConvertedPDFFilePageToImage

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .progressProgressBar.Value = e.PageNumber
        .ProgressText = String.Format("Converted page {0}/{1}, file({2}/{3}): {4}.", e.PageNumber, e.TotalPages, e.CurrentFileIndex, e.TotalFiles, e.FilePath)
      End With

    End Sub

    Private Sub m_processor_ProcessingPublicationsForDoubleTruckAd(ByVal sender As Object, ByVal e As UI.Processors.ConversionEventArgs) Handles m_processor.ProcessingPublicationsForDoubleTruckAd

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = "Processing marked publications to identify and split double truck ad images."
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = 0
        .ProgressText = String.Empty
      End With

    End Sub

    Private Sub m_processor_ProcessedPublicationsForDoubleTruckAd(ByVal sender As Object, ByVal e As UI.Processors.ConversionEventArgs) Handles m_processor.ProcessedPublicationsForDoubleTruckAd

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = String.Empty
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = 0
        .ProgressText = String.Empty
      End With

    End Sub

    Private Sub m_processor_ProcessingPublicationForDoubleTruckAd(ByVal sender As Object, ByVal e As UI.Processors.PublicationConversionEventArgs) Handles m_processor.ProcessingPublicationForDoubleTruckAd

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = String.Format("Processing publication ({0}/{1}): {2}", e.CurrentPublicationIndex, e.TotalPublications, e.PublicationFolderPath)
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = e.TotalFiles
        .ProgressText = String.Empty
      End With

    End Sub

    Private Sub m_processor_ProcessedPublicationForDoubleTruckAd(ByVal sender As Object, ByVal e As UI.Processors.PublicationConversionEventArgs) Handles m_processor.ProcessedPublicationForDoubleTruckAd

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = String.Format("Processed publication ({0}/{1}): {2}", e.CurrentPublicationIndex, e.TotalPublications, e.PublicationFolderPath)
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = 0
        .ProgressText = String.Empty
      End With

    End Sub

    Private Sub m_processor_IdentifyingPossibleDoubleTruckAds(ByVal sender As Object, ByVal e As EventArgs) Handles m_processor.IdentifyingPossibleDoubleTruckAds

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .ProgressText = "Identifying possible double-truck ads. This may take some time."
      End With

    End Sub

    Private Sub m_processor_IdentifiedPossibleDoubleTruckAds(ByVal sender As Object, ByVal e As EventArgs) Handles m_processor.IdentifiedPossibleDoubleTruckAds

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .ProgressText = "Identifyied possible double-truck ads."
      End With

    End Sub

    Private Sub m_processor_ProcessingPageImageForDoubleTruckAd(ByVal sender As Object, ByVal e As UI.Processors.DoubleTruckPageEventArgs) Handles m_processor.ProcessingPageImageForDoubleTruckAd

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .ProgressText = String.Format("Processing page image {0}", e.SourceImagePath)
      End With

    End Sub

    Private Sub m_processor_ProcessedPageImageForDoubleTruckAd(ByVal sender As Object, ByVal e As UI.Processors.DoubleTruckPageEventArgs) Handles m_processor.ProcessedPageImageForDoubleTruckAd

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .progressProgressBar.Value += 1
        .ProgressText = String.Format("Processed page image {0}", e.SourceImagePath)
      End With

    End Sub

    Private Sub m_processor_SynchronizingEROPFilePageInformation(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_processor.SynchronizingEROPFilePageInformation

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = "Saving page information in database....."
        .progressProgressBar.Visible = False
        .ProgressText = "This may take some time. Please wait..."
      End With

    End Sub

    Private Sub m_processor_EROPFilePageInformationSynchronized(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_processor.EROPFilePageInformationSynchronized

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = "Page information saved successfully in database."
        .progressProgressBar.Visible = True
        .ProgressText = String.Empty
      End With

    End Sub


#End Region


#Region " Step 4 related methods and events "


    Private Sub PrepareScanTrackDataGridViewDataGridView()

      With Me.scantrackDataGridView
        .Columns("PublicationId").HeaderText = "Publication Id"
        .Columns("PublicationId").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("Market").HeaderText = "Market"
        .Columns("Market").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("Publication").HeaderText = "Publication"
        .Columns("Publication").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("FileName").HeaderText = "File Name"
        .Columns("FileName").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("Page").HeaderText = "Page Number"
        .Columns("Page").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("IsDoubleTruck").HeaderText = "Double Truck"
        .Columns("IsDoubleTruck").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells        
        .Columns("Source").HeaderText = "Source Path"
        .Columns("Source").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("Destination").HeaderText = "Destination Path"
        .Columns("Destination").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        .Columns("Note").MinimumWidth = .Columns("Note").Width
        .Columns("Note").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        '.Columns("UserId").Visible = False
        .ReadOnly = True
      End With

    End Sub


    Private Sub recountImagesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles recountImagesButton.Click

      SetUIForProcessing(WizardStepEnum.Step4, False)

      Me.Cursor = Cursors.WaitCursor
      m_progressForm = New UI.Controls.ProgressInformationForm()
      m_progressForm.TopLevel = True
      m_progressForm.Show(Me)

      Processor.RecountImages(Me.downloadPathTextBox.Text)

      m_progressForm.progressProgressBar.Value = m_progressForm.progressProgressBar.Maximum
      m_progressForm.Close()
      m_progressForm.Dispose()
      m_progressForm = Nothing
      Me.Cursor = Cursors.Default

      SetUIForProcessing(WizardStepEnum.Step4, True)

    End Sub

    Private Sub previewImagesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles previewImagesButton.Click
      Dim imagePathArray() As String
      Dim viewImagePath As ScanTrackerReviewForm


      SetUIForProcessing(WizardStepEnum.Step4, False)

      Me.Cursor = Cursors.WaitCursor
      m_progressForm = New UI.Controls.ProgressInformationForm()
      m_progressForm.TopLevel = True
      m_progressForm.Show(Me)

      imagePathArray = Processor.GetListOfAllImagesPath(Me.downloadPathTextBox.Text)

      m_progressForm.progressProgressBar.Value = m_progressForm.progressProgressBar.Maximum
      m_progressForm.Close()
      m_progressForm.Dispose()
      m_progressForm = Nothing
      Me.Cursor = Cursors.Default

      viewImagePath = New ScanTrackerReviewForm()
      viewImagePath.PopulateListBox(imagePathArray)
      viewImagePath.TopLevel = True
      viewImagePath.ShowDialog(Me)
      viewImagePath.Dispose()
      viewImagePath = Nothing

      SetUIForProcessing(WizardStepEnum.Step4, True)

      System.Array.Clear(imagePathArray, 0, imagePathArray.Length)
      imagePathArray = Nothing
    End Sub

    Private Sub postImagesButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles postImagesButton.Click
      Dim errorOccurred As Boolean = False
      Dim rotateAngle As Integer


      SetUIForProcessing(WizardStepEnum.Step4, False)

      Me.Cursor = Cursors.WaitCursor
      m_progressForm = New UI.Controls.ProgressInformationForm()
      With m_progressForm
        .MessageText = String.Empty
        .ProgressText = String.Empty
        .TopLevel = True
        .Show(Me)
      End With

      Try
        If Integer.TryParse(Me.rotateComboBox.Text, rotateAngle) = False Then rotateAngle = 0
        Processor.MoveImagesToVehicleFolder(Me.downloadPathTextBox.Text, VehicleImageFolderPath, rotateAngle)
        m_progressForm.Close()
      Catch ex As System.IO.IOException
        errorOccurred = True
        m_progressForm.Close()
        Me.Processor.Log(0, String.Empty, ex.Message)
        MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch ex As Exception
        errorOccurred = True
        m_progressForm.Close()
        Me.Processor.Log(0, String.Empty, ex.Message)
        MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

      m_progressForm.Dispose()
      m_progressForm = Nothing
      Me.Cursor = Cursors.Default

      SetUIForProcessing(WizardStepEnum.Step4, True)
      nextButton.Enabled = Not errorOccurred

    End Sub


    Private Sub m_processor_RecountingImages(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_processor.RecountingImages

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .progressProgressBar.Visible = False
        .MessageText = "Recounting images..."
        .ProgressText = "This may take some time. Please wait..."
      End With

    End Sub

    Private Sub m_processor_ImagesRecounted(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_processor.ImagesRecounted

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = "Finished recounting images."
        .ProgressText = String.Empty
      End With

    End Sub

    Private Sub m_processor_FetchingListOfAllImagesPath(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_processor.FetchingListOfAllImagesPath

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .progressProgressBar.Visible = False
        .MessageText = "Fetching path of all the images to be moved to vehicle folder..."
        .ProgressText = "This may take some time. Please wait..."
      End With

    End Sub

    Private Sub m_processor_ListOfAllImagesPathFetched(ByVal sender As Object, ByVal e As System.EventArgs) Handles m_processor.ListOfAllImagesPathFetched

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = "Finished fetching path of all the images to be moved to vehicle folder."
        .ProgressText = String.Empty
      End With

    End Sub

    Private Sub m_processor_MovingAdImagesToVehicleFolder(ByVal sender As Object, ByVal e As UI.Processors.MovePublicationImagesEventArgs) Handles m_processor.MovingAdImagesToVehicleFolder

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = String.Format("Moving page images from ({0}/{1}) publication folder to vehicle folder.", e.CurrentDirectoryIndex, e.TotalDirectories)
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = e.TotalFiles
        .ProgressText = String.Empty
      End With

    End Sub

    Private Sub m_processor_AdImagesMovedToVehicleFolder(ByVal sender As Object, ByVal e As UI.Processors.MovePublicationImagesEventArgs) Handles m_processor.AdImagesMovedToVehicleFolder

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .MessageText = String.Empty
        .progressProgressBar.Minimum = 0
        .progressProgressBar.Value = 0
        .progressProgressBar.Maximum = 0
        .ProgressText = String.Empty
      End With

    End Sub

    Private Sub m_processor_CopyingPageImage(ByVal sender As Object, ByVal e As UI.Processors.MoveImageEventArgs) Handles m_processor.CopyingPageImage

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .ProgressText = String.Format("Moving page image ({0}/{1}): {2}", e.CurrentFileIndex, .progressProgressBar.Maximum, e.SourceImagePath)
      End With

    End Sub

    Private Sub m_processor_PageImageCopied(ByVal sender As Object, ByVal e As UI.Processors.MoveImageEventArgs) Handles m_processor.PageImageCopied

      If m_progressForm Is Nothing Then Exit Sub

      With m_progressForm
        .progressProgressBar.Value += 1
        .ProgressText = String.Format("Moved page image ({0}/{1}): {2}", e.CurrentFileIndex, .progressProgressBar.Maximum, e.SourceImagePath)
      End With

    End Sub


#End Region


  End Class

End Namespace