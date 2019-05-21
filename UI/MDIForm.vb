Imports System.Windows.Forms


Namespace UI


    Public Class MDIForm
        Implements IForm


#Region " Member variables "

        Private m_ApplicationVariableStorage As ApplicationVariableStorage

#End Region


#Region " Properties "

        ''' <summary>
        ''' Access method for the application variables stored on the user's local computer.
        ''' </summary>
        Public Property AppVar() As ApplicationVariableStorage
            Get
                Return m_ApplicationVariableStorage
            End Get
            Set(ByVal value As ApplicationVariableStorage)
                m_ApplicationVariableStorage = value
            End Set
        End Property

#End Region


#Region " IForm Implementation "


        Public Event InitializingForm() Implements IForm.InitializingForm
        Public Event FormInitialized() Implements IForm.FormInitialized

        Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
        Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied


        Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials
            Dim appUser As UI.Processors.ApplicationUser = New UI.Processors.ApplicationUser
            Dim formListTable As MCAP.UserRolesDataSet.UserScreensFunctionalityViewDataTable


            appUser = New UI.Processors.ApplicationUser()
            appUser.Initialize()

            formListTable = appUser.GetFormListFor(appUser.UserID)

            appUser.Dispose()
            appUser = Nothing

            ShowMenus(formListTable)

            formListTable.Dispose()
            formListTable = Nothing
            'LP-65 L.E.3.2.17
            Me.CheckinMidweekFlashToolStripMenuItem.Visible = False
            Me.VehicleQCRemoteToolStripMenuItem.Visible = False

        End Sub

        Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

            Me.ToolStripDBServerLabel.Text = Main.AppDatabaseServer
            Me.ToolStripDBNameLabel.Text = Main.AppDatabaseName

            AppVar = New ApplicationVariableStorage
            AppVar.ReadFromFile()

        End Sub


#End Region


#Region " Methods "


        Private Sub ShowMenus(ByVal formListTable As MCAP.UserRolesDataSet.UserScreensFunctionalityViewDataTable)
            Dim rowCounter, menuCounter As Integer
            Dim menuQuery As IEnumerable(Of ToolStripItem)
            Dim searchMenuItem As System.Windows.Forms.ToolStripMenuItem
            Dim tempRow As MCAP.UserRolesDataSet.UserScreensFunctionalityViewRow


            For rowCounter = 0 To formListTable.Rows.Count - 1
                If formListTable(rowCounter).IsObjectNameNull() Then Continue For
                tempRow = formListTable(rowCounter)

                'Search in all drop down menus.
                For menuCounter = 0 To Me.MenuStrip.Items.Count - 1
                    searchMenuItem = DirectCast(MenuStrip.Items(menuCounter), ToolStripMenuItem)
                    If searchMenuItem.DropDownItems.ContainsKey(tempRow.ObjectName) Then
                        searchMenuItem.DropDownItems(tempRow.ObjectName).Visible = True
                        searchMenuItem.Visible = True
                        Exit For
                    End If
                Next
            Next

            searchMenuItem = Nothing
            tempRow = Nothing

        End Sub

        Protected Sub Prepare(ByVal childForm As MCAP.UI.IForm, ByVal formState As MCAP.UI.FormStateEnum)

            childForm.Init(formState)
            childForm.ApplyUserCredentials()

        End Sub

#End Region


#Region " Form Events "

        'Private Sub MDIForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        '  Dim menuCounter As Integer
        '  Dim menuQuery As IEnumerable(Of ToolStripItem)
        '  Dim searchMenuItem As System.Windows.Forms.ToolStripMenuItem


        '  'Loop to hide drop down menu if none of the sub-menus are visible.
        '  For menuCounter = 0 To Me.MenuStrip.Items.Count - 1
        '    searchMenuItem = DirectCast(MenuStrip.Items(menuCounter), ToolStripMenuItem)
        '    menuQuery = From mi In searchMenuItem.DropDownItems.Cast(Of ToolStripItem)() _
        '                Where mi.Visible = True _
        '                Select mi
        '    If menuQuery.Count = 0 Then searchMenuItem.Visible = False

        '    Debug.WriteLine("Menu: " + searchMenuItem.Text + ", Visible Count: " + menuQuery.Count.ToString())

        '    menuQuery = Nothing
        '  Next

        '  searchMenuItem = Nothing
        'End Sub


        Private Sub MDIForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Dim productWindowTitle As String


            productWindowTitle = My.Application.Info.Title
            productWindowTitle += " (" + My.Application.Info.Version.ToString + ")"
            Me.Text = productWindowTitle
            productWindowTitle = Nothing
            ToolStripUserNameLabel.Text = String.Format("{0} {1}", User.FName, User.LName)
            ToolStripLocationLabel.Text = User.Location

            Init(FormStateEnum.View)
            ApplyUserCredentials()

        End Sub

        Private Sub MDIForm_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
            AppVar.WriteToFile()
        End Sub


#End Region


#Region " File Menu Items "

        Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
            Dim OpenFileDialog As New OpenFileDialog
            OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
                Dim FileName As String = OpenFileDialog.FileName
                ' TODO: Add code here to open the file.
            End If
        End Sub

        Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim SaveFileDialog As New SaveFileDialog
            SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

            If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
                Dim FileName As String = SaveFileDialog.FileName
                ' TODO: Add code here to save the current contents of the form to a file.
            End If
        End Sub

        Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Me.Close()
        End Sub

#End Region


#Region " Scrapped Menu Items "


        Private Sub NewVehicleIDToolStripMenuItem_Click _
            (ByVal sender As System.Object, ByVal e As System.EventArgs)


            Dim o As MCAP.UI.PageDefinitionsForm
            o = New MCAP.UI.PageDefinitionsForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.VehicleID = 100003
            o.Show()
        End Sub

        Private Sub ExistingVehicleIDToolStripMenuItem_Click _
            (ByVal sender As System.Object, ByVal e As System.EventArgs)

            Dim o As MCAP.UI.PageDefinitionsForm
            o = New MCAP.UI.PageDefinitionsForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.VehicleID = 1
            o.Show()
        End Sub


#End Region


#Region " Check-In Menu Items "


        Private Sub EnvelopeCheckInToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles EnvelopeCheckInToolStripMenuItem.Click
            Dim o As MCAP.UI.EnvelopeCheckInForm


            o = New MCAP.UI.EnvelopeCheckInForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.Insert)
            o.Show()

        End Sub

        Private Sub EnvelopeContentCheckInToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles EnvelopeContentCheckInToolStripMenuItem.Click
            Dim o As MCAP.UI.EnvelopeContentCheckInForm


            o = New MCAP.UI.EnvelopeContentCheckInForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub IndexToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles IndexToolStripMenuItem.Click
            Dim o As MCAP.UI.IndexForm


            o = New MCAP.UI.IndexForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub VehicleQCToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles VehicleQCToolStripMenuItem.Click
            Dim o As MCAP.UI.QCForm


            o = New MCAP.UI.QCForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()
            o.findVehicleIdTextBox.Focus()

        End Sub


#End Region


#Region " Family Menu Items "


        Private Sub FamilyCheckInToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles FamilyCheckInToolStripMenuItem.Click
            Dim o As MCAP.UI.FamilyCheckInForm


            o = New MCAP.UI.FamilyCheckInForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.Insert)
            o.Show()

        End Sub

        Private Sub ReviewFamilyToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles ReviewFamilyToolStripMenuItem.Click
            Dim o As MCAP.UI.FamilyReviewForm


            o = New MCAP.UI.FamilyReviewForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.Insert)
            o.Show()

        End Sub

        Private Sub ViewFamilyToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles ViewFamilyToolStripMenuItem.Click
            Dim o As MCAP.UI.FamilyViewForm


            o = New MCAP.UI.FamilyViewForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.Insert)
            o.Show()

        End Sub


#End Region


#Region " Publication/Pull Menu Items "


        Private Sub PublicationCheckInToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles PublicationCheckInToolStripMenuItem.Click
            Dim o As MCAP.UI.PublicationCheckInForm


            o = New MCAP.UI.PublicationCheckInForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.Insert)
            o.Show()

        End Sub

        Private Sub PublicationPullToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles PublicationPullToolStripMenuItem.Click
            Dim o As MCAP.UI.PublicationPullForm


            o = New MCAP.UI.PublicationPullForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub PublicationPullQCToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles PublicationPullQCToolStripMenuItem.Click
            Dim o As MCAP.UI.PublicationPullQCForm


            o = New MCAP.UI.PublicationPullQCForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub PublicationScanQCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PublicationDigitalPullToolStripMenuItem.Click
            Dim o As MCAP.UI.PublicationDigitalPullForm


            o = New MCAP.UI.PublicationDigitalPullForm()
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub PublicationIndexQCToolStripMenuItemItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles PublicationIndexQCToolStripMenuItem.Click
            Dim o As MCAP.UI.PublicationIndexQCForm


            o = New MCAP.UI.PublicationIndexQCForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub PublicationNoDropToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles PublicationNoDropToolStripMenuItem.Click
            Dim o As MCAP.UI.PublicationNotDroppedForm


            o = New MCAP.UI.PublicationNotDroppedForm()
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

#End Region


#Region " Reports Menu Items "


        Private Sub ErrorsCorrectedReportToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles ErrorsCorrectedReportToolStripMenuItem.Click
            Dim o As MCAP.UI.ErrorsCorrectedReportForm


            o = New MCAP.UI.ErrorsCorrectedReportForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub FamilyExpectationDropExpectationReportToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles FamilyExpectationDropExpectationReportToolStripMenuItem.Click
            Dim o As MCAP.UI.FamilyExpectationReportForm


            o = New MCAP.UI.FamilyExpectationReportForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub NewspaperLogReportToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles NewspaperLogReportToolStripMenuItem.Click
            Dim o As MCAP.UI.NewspaperLogReportForm


            o = New MCAP.UI.NewspaperLogReportForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub PackageExpectationReportToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles PackageExpectationReportToolStripMenuItem.Click
            Dim o As MCAP.UI.PackageExpectationReportForm


            o = New MCAP.UI.PackageExpectationReportForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub FlashReportToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles FlashReportToolStripMenuItem.Click
            Dim o As MCAP.UI.FlashReportForm


            o = New MCAP.UI.FlashReportForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub WorkToBeCompletedToolStripMenuItem_Click _
            (ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles WorkToBeCompletedToolStripMenuItem.Click
            Dim o As MCAP.UI.WorkToBeCompletedReportForm


            o = New MCAP.UI.WorkToBeCompletedReportForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub AdExpectationReportToolStripMenuItem_Click _
            (ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles AdExpectationReportToolStripMenuItem.Click
            Dim o As MCAP.UI.AdExpectationReportForm


            o = New MCAP.UI.AdExpectationReportForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub VehicleInclusionToolStripMenuItem_Click _
            (ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles VehicleInclusionToolStripMenuItem.Click
            Dim o As MCAP.UI.VehicleInclusionForm


            o = New MCAP.UI.VehicleInclusionForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub


#End Region


#Region " Maintenance Menu Items "


        Private Sub MaintenanceToolStripMenuItem1_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles MaintenanceToolStripMenuItem1.Click
            Dim o As MCAP.UI.MaintenanceForm


            o = New MCAP.UI.MaintenanceForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.Insert)
            o.Show()

        End Sub

        Private Sub OptionsToolStripMenuItem_Click _
            (ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles PrinterToolStripMenuItem.Click
            Dim printerList As PrinterSelectionForm


            printerList = New PrinterSelectionForm()
            printerList.Show()
            printerList.Owner = Me
            printerList.LoadPrinterList()
            printerList.Hide()
            printerList.ShowDialog(Me)
            printerList.Dispose()
            printerList = Nothing

        End Sub

        Private Sub PermissionsToolStripMenuItem_Click _
            (ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles PermissionsToolStripMenuItem.Click
            Dim o As PermissionForm


            o = New PermissionForm()
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub DESPToolStripMenuItem_Click _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles DESPToolStripMenuItem.Click
            Dim o As DESPForm


            o = New DESPForm()
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub AddrMappingToolStripMenuItem_Click _
       (ByVal sender As Object, ByVal e As System.EventArgs) _
       Handles AddrMappingToolStripMenuItem.Click
            Dim o As MCAP.UI.AddressMappingForm

            o = New AddressMappingForm()
            o.MdiParent = Me
            o.StartPosition = FormStartPosition.CenterScreen
            o.WindowState = FormWindowState.Maximized
            Prepare(o, UI.FormStateEnum.Insert)
            o.Show()

        End Sub


#End Region


#Region " Scanning Menu Items "

        Private Sub ScanTrackerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanTrackerToolStripMenuItem.Click
            Dim o As MCAP.UI.ScanTrackerForm
            o = New MCAP.UI.ScanTrackerForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.Insert)
            o.Show()
        End Sub


        Private Sub ScanTrackerRemoteQcToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanTrackerRemoteQcToolStripMenuItem.Click
            Dim o As MCAP.UI.ScanTrackerRemoteQCForm
            o = New MCAP.UI.ScanTrackerRemoteQCForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.Insert)
            o.Show()
        End Sub

        Private Sub ScanTrackerEROPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScanTrackerEROPToolStripMenuItem.Click
            Dim o As MCAP.UI.ScanTrackerEROPForm
            o = New MCAP.UI.ScanTrackerEROPForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.Insert)
            o.Show()
        End Sub

        Private Sub RetrieveImagesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RetrieveImagesToolStripMenuItem.Click
            Dim o As MCAP.UI.RetrieveImagesForm
            o = New MCAP.UI.RetrieveImagesForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.Insert)
            o.Show()
        End Sub



#End Region


#Region " Status Menu Items "


        Private Sub EnvelopeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnvelopeStatusToolStripMenuItem.Click
            Dim o As UI.EnvelopeStatusReportForm

            o = New EnvelopeStatusReportForm()
            o.MdiParent = Me
            Prepare(o, FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub VehicleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VehicleStatusToolStripMenuItem.Click
            Dim o As UI.VehicleStatusReportForm

            o = New VehicleStatusReportForm()
            o.MdiParent = Me
            Prepare(o, FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub AdSearchToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AdSearchToolStripMenuItem.Click
            Dim o As AdSearchForm


            o = New AdSearchForm()
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub ROPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PublicationToolStripMenuItem.Click
            Dim o As UI.ROPStatusReportForm

            o = New UI.ROPStatusReportForm()
            o.MdiParent = Me
            Prepare(o, FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub VehiclesMarkedForReviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VehiclesToBeReviewedAndDuplicatesToolStripMenuItem.Click
            Dim o As UI.ReviewVehicleForm

            o = New UI.ReviewVehicleForm()
            o.MdiParent = Me
            Prepare(o, FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub SPReviewToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SPReviewToolStripMenuItem.Click
            Dim o As UI.SPReviewForm

            o = New UI.SPReviewForm()
            o.MdiParent = Me
            Prepare(o, FormStateEnum.View)
            o.Show()

        End Sub

        Private Sub VehiclesMarkedAsWrongVersionNotRequiredToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VehiclesMarkedAsWrongVersionNotRequiredToolStripMenuItem.Click
            Dim o As UI.ReviewWVNNVehicleForm

            o = New UI.ReviewWVNNVehicleForm()
            o.MdiParent = Me
            Prepare(o, FormStateEnum.View)
            o.Show()

        End Sub


#End Region

#Region "Coverage and Collections"

        Private Sub CCTaskLogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaskLogFormToolStripMenuItem.Click
            Dim o As MCAP.UI.CCTasksLogForm
            o = New MCAP.UI.CCTasksLogForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.Insert)
            o.Show()
        End Sub

        Private Sub MissingAdMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MissingAdToolStripMenuItem.Click
            Dim o As MCAP.UI.MissingAdLogForm
            o = New MCAP.UI.MissingAdLogForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.Insert)
            o.Show()
        End Sub

        Private Sub CCSearchFormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CCSearchFormToolStripMenuItem.Click
            Dim o As MCAP.UI.CCSearchForm
            o = New MCAP.UI.CCSearchForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.Insert)
            o.Show()
        End Sub


#End Region


        Private Sub CheckinMidweekFlashToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckinMidweekFlashToolStripMenuItem.Click
            Dim o As MCAP.MidWeekForm
            o = New MCAP.MidWeekForm
            o.MdiParent = Me
            o.Show()
        End Sub

        Private Sub MenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

        End Sub

        Private Sub VehicleQCRemoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VehicleQCRemoteToolStripMenuItem.Click
            Dim o As MCAP.UI.QCForm

            o = New MCAP.UI.QCForm
            o.MdiParent = Me
            Prepare(o, UI.FormStateEnum.Remote)
            o.Text = "Vehicle QC - Remote"
            o.Show()
            o.findVehicleIdTextBox.Focus()
        End Sub

        Private Sub VehicleChildrenCreateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VehicleChildrenCreateToolStripMenuItem.Click
            Dim o As MCAP.VehicleChildrenCreation

            o = New MCAP.VehicleChildrenCreation
            o.MdiParent = Me
            o.StartPosition = FormStartPosition.CenterScreen
            Prepare(o, UI.FormStateEnum.View)
            o.Show()
            o.txtVehicleID.Focus()
        End Sub

        Private Sub WishabiImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WishabiImageToolStripMenuItem.Click
            Dim o As MCAP.wishabi

            o = New MCAP.wishabi
            o.MdiParent = Me
            o.StartPosition = FormStartPosition.CenterScreen
            o.WindowState = FormWindowState.Maximized
            'Prepare(o, UI.FormStateEnum.View)
            o.Show()
            o.ToolStripTextBox1.Focus()
            'o.txtVehicleID.Focus()
        End Sub

        Private Sub ResetQcImagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetQcImagesToolStripMenuItem.Click
            Dim o As MCAP.qcImageMaintenance

            o = New MCAP.qcImageMaintenance
            o.MdiParent = Me
            o.StartPosition = FormStartPosition.CenterScreen
            o.WindowState = FormWindowState.Normal
            Prepare(o, UI.FormStateEnum.View)
            o.Show()
            o.txtVehicleID.Focus()
        End Sub

        Private Sub NewExpectationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewExpectationToolStripMenuItem.Click
            Dim o As MCAP.newExpectationForm

            o = New MCAP.newExpectationForm
            o.MdiParent = Me
            o.StartPosition = FormStartPosition.CenterScreen
            o.WindowState = FormWindowState.Normal
            'Prepare(o, UI.FormStateEnum.View)
            o.Show()
        End Sub

        Private Sub SocialMediaMaintenanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SocialMediaMaintenanceToolStripMenuItem.Click
            Dim o As MCAP.SocialMediaForm

            o = New MCAP.SocialMediaForm
            o.MdiParent = Me
            o.StartPosition = FormStartPosition.CenterScreen
            o.WindowState = FormWindowState.Normal
            'Prepare(o, UI.FormStateEnum.View)
            o.Show()
        End Sub

        'Private Sub LoadCanadaFRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadCanadaFRToolStripMenuItem.Click
        '    Dim o As MCAP.canadaFrLoadForm

        '    o = New MCAP.canadaFrLoadForm
        '    o.MdiParent = Me
        '    o.StartPosition = FormStartPosition.CenterScreen
        '    o.WindowState = FormWindowState.Normal
        '    Prepare(o, UI.FormStateEnum.View)
        '    o.Show()
        'End Sub

        Private Sub BypassVehiclesReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BypassVehiclesReportToolStripMenuItem.Click
            Dim o As BypassVehicleForm

            o = New BypassVehicleForm
            o.MdiParent = Me
            o.StartPosition = FormStartPosition.CenterScreen
            o.WindowState = FormWindowState.Normal
            'Prepare(o, UI.FormStateEnum.View)
            o.Show()
        End Sub

        Private Sub RequiredNonRequiredReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RequiredNonRequiredReportToolStripMenuItem.Click
            Dim o As RequiredForm

            o = New RequiredForm
            o.MdiParent = Me
            o.StartPosition = FormStartPosition.CenterScreen
            o.WindowState = FormWindowState.Normal
            Prepare(o, UI.FormStateEnum.Insert)
            o.Show()
        End Sub

        Private Sub ReviewRetailerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReviewRetailerToolStripMenuItem.Click
            Dim o As ReviewRetailerForm

            o = New ReviewRetailerForm
            o.MdiParent = Me
            o.StartPosition = FormStartPosition.CenterScreen
            o.WindowState = FormWindowState.Normal
            Prepare(o, UI.FormStateEnum.Insert)
            o.Show()
        End Sub

        Private Sub WebsiteUploadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebsiteUploadToolStripMenuItem.Click
            Dim o As WebsiteMaintenanceForm

            o = New WebsiteMaintenanceForm
            o.MdiParent = Me
            o.StartPosition = FormStartPosition.CenterScreen
            o.WindowState = FormWindowState.Normal
            ' Prepare(o, UI.FormStateEnum.Insert)
            o.Show()

        End Sub

        Private Sub PushToIndexHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PushToIndexHistoryToolStripMenuItem.Click
            Dim myIndexForm As New sentToIndex
            myIndexForm = New UI.sentToIndex
            myIndexForm.Init(FormStateEnum.View)
            myIndexForm.ApplyUserCredentials()
            myIndexForm.ShowDialog(Me)
        End Sub

        Private Sub SIMRLogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SIMRLogToolStripMenuItem.Click
            Dim o As SIMRLogForm

            o = New SIMRLogForm
            o.MdiParent = Me
            o.StartPosition = FormStartPosition.CenterScreen
            o.WindowState = FormWindowState.Normal
            Prepare(o, UI.FormStateEnum.View)
            o.Show()
        End Sub

        Private Sub CompareACImportTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompareACImportTypeToolStripMenuItem.Click
            Dim o As SendernotmatchingImport
            o = New SendernotmatchingImport
            o.MdiParent = Me
            o.StartPosition = FormStartPosition.CenterScreen
            o.WindowState = FormWindowState.Normal
            'Prepare(o, UI.FormStateEnum.Insert)
            o.Show()
        End Sub
    End Class

End Namespace
