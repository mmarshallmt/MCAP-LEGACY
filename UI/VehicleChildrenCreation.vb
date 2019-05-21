Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports MCAP.UI

Public Class VehicleChildrenCreation
    Implements IForm


#Region " Event "

    Public Event LoadingVehicle(ByVal vehicleId As Integer)
    Public Event VehicleLoaded(ByVal vehicleRow As PublicationPullDataSet.vwPublicationEditionRow)
    Public Event VehicleNotFound(ByVal vehicleId As Integer)
    Public Event InvalidVehicleStatus(ByVal vehicleId As Integer, ByVal statusText As String)

#End Region

    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

        RaiseEvent InitializingForm()

        RaiseEvent FormInitialized()

    End Sub

    Public Event FormInitialized() Implements IForm.FormInitialized
    Public Event InitializingForm() Implements IForm.InitializingForm

    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied


    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials
        Dim rowCounter As Integer
        Dim appUser As Processors.ApplicationUser


        RaiseEvent ApplyingUserCredentials()

        appUser = New Processors.ApplicationUser
        appUser.Initialize()
        appUser.GetFunctionalityListFor(appUser.UserID, Me.Name)


        appUser = Nothing

        RaiseEvent UserCredentialsApplied()

    End Sub

    Private WithEvents m_Processor As Processors.Index
    Private isClosedByButton As Boolean = False
    Dim sSql As String

    Public Sub FillListView(ByRef lvList As ListView, ByRef myData As SqlDataReader)
        Dim itmListItem As ListViewItem
        Dim strValue As Object
        Dim shtCntr As Integer

        Do While myData.Read
            itmListItem = New ListViewItem()
            strValue = IIf(myData.IsDBNull(0), "", myData.GetValue(0))
            'itmListItem.Text = strValue

            For shtCntr = 1 To myData.FieldCount() - 1
                If myData.IsDBNull(shtCntr) Then
                    itmListItem.SubItems.Add("")
                Else
                    itmListItem.SubItems.Add(myData.GetValue(shtCntr).ToString())
                End If
            Next shtCntr

            lvList.Items.Add(itmListItem)
        Loop
    End Sub
    Public Sub FillList()

        With lvResult
            .Clear()
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .Columns.Add("", 0, HorizontalAlignment.Right)
            .Columns.Add("ParentVehicleId", 90, HorizontalAlignment.Right)
            .Columns.Add("", 0, HorizontalAlignment.Right)
            .Columns.Add("", 0, HorizontalAlignment.Right)
            .Columns.Add("", 0, HorizontalAlignment.Right)
            .Columns.Add("Retailer", 110, HorizontalAlignment.Left)
            .Columns.Add("Market", 130, HorizontalAlignment.Left)
            .Columns.Add("TDLInkxNumber", 95, HorizontalAlignment.Right)
            .Columns.Add("Retailer Address", 250, HorizontalAlignment.Left)
            If Not sSql = "" Then
                FillListView(lvResult, GetData(sSql))

            End If
        End With
    End Sub
    Public Sub clearForm()
        sSql = ""
        Call FillList()
        rtbTDlinkxNo.Clear()
        txtVehicleID.Text = String.Empty
        btnCreateChildren.Enabled = False
        createdOnValueLabel.Text = String.Empty
        indexedOnValueLabel.Text = String.Empty
        scannedOnValueLabel.Text = String.Empty
        qcedOnValueLabel.Text = String.Empty
        startDtValueLabel.Text = String.Empty
        retailerValueLabel.Text = String.Empty
        marketValueLabel.Text = String.Empty
        startDtValueLabel.Text = String.Empty
    End Sub
    Public Sub resetOnError()
        sSql = ""
        Call FillList()
        btnCreateChildren.Enabled = False
    End Sub
    Public Sub LoadFilter()
        Dim vehicleId As Integer
        Int32.TryParse(txtVehicleID.Text, vehicleId)
        Dim TDLInkxNumber As String = CleanString(rtbTDlinkxNo.Text.ToString())

        sSql = "select distinct '',Vehicle.VehicleId as ParentVehicleID,AllRet.RetId, E.MktId, Vehicle.MediaId,AllRet.Descrip as Retailer, m.Descrip as Market, AllRet.TDLInkxNumber,( AllRet.RetAddress +', '+ AllRet.RetCity +', '+ AllRet.RetState+' '+ AllRet.RetZip)as Address from Vehicle inner join Ret VehicleRet on VehicleRet.RetId = Vehicle.RetId "
        sSql = sSql & "inner join Ret AllRet on AllRet.DisplayDescrip = VehicleRet.DisplayDescrip inner join Expectation E on E.RetId = AllRet.RetId  and E.MediaId = vehicle.MediaId inner join mkt m on m.mktid =vehicle.MktId where"
        sSql = sSql & " Vehicle.VehicleId =" & vehicleId

        If TDLInkxNumber <> " " Then
            sSql = sSql & " and AllRet.TDLInkxNumber in (" & TDLInkxNumber.ToString & ")"
        End If
        Call FillList()
    End Sub
    Private Sub createChildren()


        Dim vehicleId As Integer
        Int32.TryParse(txtVehicleID.Text, vehicleId)

        If MsgBox("Changes Made will be saved", CType(MsgBoxStyle.YesNo + MsgBoxStyle.Information, MsgBoxStyle)) = MsgBoxResult.No Then Exit Sub
        Dim objRecord As New Object()
        Dim objVehicle As BusinessLayer.clsVehicleController

        Try
            objVehicle = New BusinessLayer.clsVehicleController
            objVehicle.VehicleId = vehicleId
            objRecord = objVehicle.Select()
            
            Dim binding_object As clsVehicle = DirectCast(objRecord, clsVehicle)

            Dim sql As String
            For CNT As Integer = 0 To lvResult.Items.Count - 1

                objVehicle.ParentVehicleId = vehicleId
                objVehicle.RetId = CInt(lvResult.Items(CNT).SubItems(2).Text)
                objVehicle.MktId = CInt(lvResult.Items(CNT).SubItems(3).Text)

                objVehicle.EnvelopeId = CType(binding_object.EnvelopeId, Integer)
                objVehicle.BreakDt = CType(sqlDate(CStr(binding_object.BreakDt)), DateTime)
                objVehicle.StartDt = CType(sqlDate(CStr(binding_object.StartDt)), DateTime)
                objVehicle.EndDt = CType(sqlDate(CStr(binding_object.EndDt)), DateTime)
                objVehicle.TypeId = binding_object.TypeId
                objVehicle.LanguageId = binding_object.LanguageId
                objVehicle.EventId = binding_object.EventId
                objVehicle.ThemeId = binding_object.ThemeId
                objVehicle.MediaId = binding_object.MediaId
                objVehicle.ParentVehicleId = binding_object.VehicleId
                objVehicle.PublicationId = binding_object.PublicationId
                objVehicle.FlashInd = binding_object.FlashInd
                objVehicle.CreateDt = Now()
                objVehicle.CreatedById = User.UserID
                objVehicle.ScanDt = binding_object.ScanDt
                objVehicle.ScannedById = binding_object.ScannedById
                objVehicle.QCedById = binding_object.QCedById
                objVehicle.QCDt = binding_object.QCDt
                objVehicle.FamilyId = binding_object.FamilyId
                objVehicle.CouponInd = binding_object.CouponInd
                objVehicle.CreateSizedDt = binding_object.CreateSizedDt
                objVehicle.Priority = binding_object.Priority
                objVehicle.CheckInPageCount = binding_object.CheckInPageCount
                objVehicle.StatusID = binding_object.StatusID
                objVehicle.SenderId = binding_object.SenderId
                objVehicle.PullDt = binding_object.PullDt
                objVehicle.PulledById = binding_object.PulledById
                objVehicle.PullPageCount = binding_object.PullPageCount
                objVehicle.Weight = binding_object.Weight
                objVehicle.PullQCedById = binding_object.PullQCedById
                objVehicle.PullQCDt = binding_object.PullQCDt
                objVehicle.FormName = binding_object.FormName
                objVehicle.CheckInOccurrences = binding_object.CheckInOccurrences
                objVehicle.NationalInd = CByte(binding_object.NationalInd)
                objVehicle.ftpStatusId = CInt(binding_object.ftpStatusId)
                objVehicle.ftpDt = CDate(binding_object.ftpDt)
                objVehicle.IndexDt = CDate(binding_object.IndexDt)
                objVehicle.IndexedById = binding_object.IndexedById
                objVehicle.RemoteEntryImageFTPStatusId = binding_object.RemoteEntryImageFTPStatusId
                objVehicle.RemoteEntryImageFTPDt = binding_object.RemoteEntryImageFTPDt
                objVehicle.RemoteEntryImageForceFTPRetransfer = binding_object.RemoteEntryImageForceFTPRetransfer
                objVehicle.RemoteEntryImageFTPQueueInsertDt = binding_object.RemoteEntryImageFTPQueueInsertDt
                objVehicle.SPReviewStatusId = binding_object.SPReviewStatusId
                objVehicle.EntryInd = binding_object.EntryInd
                objVehicle.BodyText = binding_object.BodyText
                objVehicle.BodyHTML = binding_object.BodyHTML
                objVehicle.SiteId = binding_object.SiteId
                objVehicle.Subject = binding_object.Subject
                objVehicle.ReQCDt = binding_object.ReQCDt
                objVehicle.ReQCedById = binding_object.ReQCedById
                objVehicle.FilterMatches = binding_object.FilterMatches
                objVehicle.isReviewed = binding_object.isReviewed
                objVehicle.ReviewDt = binding_object.ReviewDt
                objVehicle.ReviewedByUserId = binding_object.ReviewedByUserId
                objVehicle.isQCed = binding_object.isQCed
                objVehicle.QCDate = binding_object.QCDate
                objVehicle.QCedByUserId = binding_object.QCedByUserId
                objVehicle.QAComments = binding_object.QAComments
                objVehicle.DistDt = binding_object.DistDt
                objVehicle.IndReadyForExport = binding_object.IndReadyForExport
                objVehicle.Insert()

            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.btnCreateChildren.Enabled = False
            Exit Sub
        End Try
        MessageBox.Show("New vehicles were created for records ", ProductName _
                            , MessageBoxButtons.OK, MessageBoxIcon.Information)
        btnCreateChildren.Enabled = False
    End Sub
    Private Sub loadDataInfo()

    End Sub

    Private Sub wrongVersionButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreateChildren.Click
        If lvResult.Items.Count = 0 Then
            MessageBox.Show("No records in list to be saved ", ProductName _
                            , MessageBoxButtons.OK, MessageBoxIcon.Stop)
            btnCreateChildren.Enabled = False
            txtVehicleID.Focus()
            Exit Sub
        End If
        createChildren()
    End Sub

    Private Sub rtbTDlinkxNo_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles rtbTDlinkxNo.GotFocus
        If rtbTDlinkxNo.Text <> " " Then

            Dim tempTxt As String = rtbTDlinkxNo.Text.ToString()
            rtbTDlinkxNo.Clear()
            rtbTDlinkxNo.Text = tempTxt
        End If
    End Sub

    Private Sub VehicleChildrenCreation_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If e.CloseReason = CloseReason.UserClosing And isClosedByButton = False Then
            If (MessageBox.Show("Are you sure you want to close this form?", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                e.Cancel = True
            End If
        End If
    End Sub



    Private Sub VehicleChildrenCreation_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.txtVehicleID.Focus()
        FillList()

    End Sub

    Private Sub loadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loadButton.Click
        Dim vehicleId As Integer
        Dim tdLinks As String

        If Integer.TryParse(txtVehicleID.Text, vehicleId) = False Then
            MessageBox.Show("Provide valid vehicle Id.", ProductName _
                            , MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        tdLinks = CleanString(rtbTDlinkxNo.Text.TrimEnd)

        If String.IsNullOrEmpty(tdLinks) Then
            MessageBox.Show("Provide TDLinkz No", ProductName _
                                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
            rtbTDlinkxNo.Focus()
            Exit Sub
        End If

        REM : To be install one code is live- remain for testin purpose
        If isVehicleQCed(vehicleId) = True Then

            Call showResult()
            LoadVehicleInformation(vehicleId)
        Else
            MessageBox.Show("VehicleID Provided has not been QCed", ProductName _
                                        , MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.txtVehicleID.Focus()
            Exit Sub
        End If
        Me.btnCreateChildren.Enabled = True
    End Sub

    Private Sub showResult()
        Dim isValid As Boolean
        Dim tdLinks As String = CleanString(Me.rtbTDlinkxNo.Text.ToString())
        Dim objVehicle As New UI.clsVehicleChildrenCreation
        Dim recordNotFound As String()
        isValid = objVehicle.isValidTdLinks((tdLinks))
        If isValid Then
            Call LoadFilter()
        Else
            Dim RecordNotFoundValue As String
            resetOnError()
            recordNotFound = Split(objVehicle.tDlinksNotInList(tdLinks), vbNewLine)

            For Each item As String In recordNotFound
                ColorWord(item, rtbTDlinkxNo, Color.Red, 12, FontStyle.Regular)

                RecordNotFoundValue += " " + item.TrimEnd

            Next
            MessageBox.Show("Cannot Locate TDLinks: " & RecordNotFoundValue.ToString & " please fix or remove", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

    End Sub

    Private Sub LoadVehicleInformation(ByVal vehicleId As Integer)
        Dim createDt As DateTime
        Dim vehicleAdapter As StatusReportDataSetTableAdapters.vwVehicleStatusReportTableAdapter
        Dim pageAdapter As StatusReportDataSetTableAdapters.PageTableAdapter
        Dim pagecropAdapter As StatusReportDataSetTableAdapters.PageCropTableAdapter

        vehicleAdapter = New StatusReportDataSetTableAdapters.vwVehicleStatusReportTableAdapter
        pageAdapter = New StatusReportDataSetTableAdapters.PageTableAdapter
        pagecropAdapter = New StatusReportDataSetTableAdapters.PageCropTableAdapter()

        vehicleAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        pageAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
        pagecropAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

        vehicleAdapter.FillByVehicleId(Me.StatusReportDataSet.vwVehicleStatusReport, vehicleId)
        If Me.StatusReportDataSet.PageCrop.Count > 0 Then Me.StatusReportDataSet.PageCrop.Rows.Clear()
        pageAdapter.Fill(Me.StatusReportDataSet.Page, vehicleId)
        pagecropAdapter.Fill(Me.StatusReportDataSet.PageCrop, vehicleId)
        If Me.StatusReportDataSet.vwVehicleStatusReport.Count > 0 Then
            With Me.StatusReportDataSet.vwVehicleStatusReport(0)

                If .IsCreateDtNull() OrElse .IsCreatedByNull() Then
                    createdOnValueLabel.Text = String.Empty
                Else
                    createdOnValueLabel.Text = .CreateDt.ToString("MM/dd/yyyy") + " by " + .CreatedBy
                    createDt = .CreateDt
                End If
                If .IsIndexDtNull() OrElse .IsIndexedByNull() Then
                    indexedOnValueLabel.Text = String.Empty
                Else
                    indexedOnValueLabel.Text = .IndexDt.ToString("MM/dd/yyyy ") + " by " + .IndexedBy
                End If
                If .IsScanDtNull() OrElse .IsScannedByNull() Then
                    scannedOnValueLabel.Text = String.Empty
                Else
                    scannedOnValueLabel.Text = .ScanDt.ToString("MM/dd/yyyy") + " by " + .ScannedBy
                End If
                If .IsQCDtNull() OrElse .IsQCedByNull() Then
                    qcedOnValueLabel.Text = String.Empty
                Else
                    qcedOnValueLabel.Text = .QCDt.ToString("MM/dd/yyyy") + " by " + .QCedBy
                End If
                
                If .IsStartDtNull() Then
                    startDtValueLabel.Text = String.Empty
                Else
                    startDtValueLabel.Text = .StartDt.ToString("MM/dd/yyyy")
                End If

            End With
        End If

        vehicleAdapter.Dispose()
        pageAdapter.Dispose()
        vehicleAdapter = Nothing
        pageAdapter = Nothing
        pagecropAdapter = Nothing


    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Call clearForm()
    End Sub
End Class