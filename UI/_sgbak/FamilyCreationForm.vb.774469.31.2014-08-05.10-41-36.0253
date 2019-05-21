Namespace UI


  Public Class FamilyCreationForm
    Implements IForm


    ''' <summary>
    ''' This constant is used to assigning value to FormName column.
    ''' </summary>
    Private Const FORM_NAME As String = "Family Creation"


    Private m_IsNewFamily As Boolean
    Private m_dayDifference As Integer
    Private m_mediaId As Integer
    Private m_retailerId As Integer
    Private m_familyId As Integer
    Private m_pageCount As Integer
    Private m_breakDate As DateTime

    Private WithEvents m_familyCreationProcessor As Processors.FamilyCreation



    ''' <summary>
    ''' Gets day difference between ad dates.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property DayDifference() As Integer
      Get
        Return m_dayDifference
      End Get
    End Property

    ''' <summary>
    ''' Gets ad date.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property BreakDate() As DateTime
      Get
        Return m_breakDate
      End Get
    End Property

    ''' <summary>
    ''' Gets media id.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property MediaId() As Integer
      Get
        Return m_mediaId
      End Get
    End Property

    ''' <summary>
    ''' Gets retailer id.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property RetailerId() As Integer
      Get
        Return m_retailerId
      End Get
    End Property

    ''' <summary>
    ''' Gets page count.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property PageCount() As Integer
      Get
        Return m_pageCount
      End Get
    End Property

    ''' <summary>
    ''' Gets family Id.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property FamilyId() As Integer
      Get
        Return m_familyId
      End Get
    End Property

    ''' <summary>
    ''' Gets instance of FamilyCreation class.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property Processor() As Processors.FamilyCreation
      Get
        Return m_familyCreationProcessor
      End Get
    End Property

    ''' <summary>
    ''' Gets boolean value indicating whether user has selected new family radio button or not.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsNewFamily() As Boolean
      Get
        Return m_IsNewFamily
      End Get
    End Property

    ''' <summary>
    ''' Constructor accepts ad date, media id, retailer id and day difference 
    ''' as arguments. Form shows list of vehicles, satisfying ad date, media id,
    ''' retailer and day difference.
    ''' </summary>
    ''' <param name="breakDate"></param>
    ''' <param name="mediaId"></param>
    ''' <param name="retailerId"></param>
    ''' <param name="pageCount"></param>
    ''' <param name="dayDifference"></param>
    ''' <remarks></remarks>
    Sub New(ByVal breakDate As DateTime, ByVal mediaId As Integer, ByVal retailerId As Integer, ByVal pageCount As Integer, ByVal dayDifference As Integer)
      MyBase.new()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      m_breakDate = breakDate
      m_mediaId = mediaId
      m_retailerId = retailerId
      m_pageCount = pageCount
      m_familyId = -1
      m_dayDifference = dayDifference

    End Sub



    ''' <summary>
    ''' Loads potential families based on supplied values in constructor.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadPotentialFamilies()

      searchButton_Click(Me, New System.EventArgs())

    End Sub

    '''' <summary>
    '''' If image file path is correct, returns object containing resized image. 
    '''' This does not affect actual image file.
    '''' </summary>
    '''' <param name="filePath"></param>
    '''' <param name="imageWidth"></param>
    '''' <param name="imageHeight"></param>
    '''' <param name="resizeOnlyIfWider"></param>
    '''' <returns></returns>
    '''' <remarks>
    '''' If file does not exist, returns Nothing.
    '''' Reference URL = http://www.codeproject.com/KB/grid/ImagePreviewDataGridView.aspx
    '''' </remarks>
    'Public Function GetResizedImage(ByVal filePath As String, ByVal imageWidth As Integer, ByVal imageHeight As Integer, ByVal resizeOnlyIfWider As Boolean) As System.Drawing.Image

    '  If System.IO.File.Exists(filePath) = False Then Return Nothing

    '  Using image As System.Drawing.Image = System.Drawing.Image.FromFile(filePath)
    '    'Prevent using images internal thumbnail
    '    image.RotateFlip(RotateFlipType.Rotate180FlipNone)
    '    image.RotateFlip(RotateFlipType.Rotate180FlipNone)

    '    If resizeOnlyIfWider Then
    '      If image.Width <= imageWidth Then imageWidth = image.Width
    '    End If

    '    Dim resizedImage As System.Drawing.Image

    '    resizedImage = image.GetThumbnailImage(imageWidth, imageHeight, Nothing, IntPtr.Zero)

    '    Return resizedImage
    '  End Using

    'End Function

    ''' <summary>
    ''' Gets resized image object to display image in data grid. It takes care 
    ''' of maintaining image's width:height ratio based on application parameters.
    ''' </summary>
    ''' <param name="imagePath">Path to image file, which is to be displayed on grid.</param>
    ''' <returns></returns>
    ''' <remarks>If image file does not exist, returns Nothing.</remarks>
    Private Function GetResizedImageForGrid(ByVal imagePath As String) As System.Drawing.Image
      Dim resizeWidth, resizeHeight, widthDiff, heightDiff As Integer
      Dim displayImage As System.Drawing.Image


      If System.IO.File.Exists(imagePath) = False Then Return Nothing

      displayImage = System.Drawing.Image.FromFile(imagePath)

      If MaintainAspectRatioInGrid = False Then  'If resize with same scale
        resizeWidth = ImageWidthInGrid
        resizeHeight = ImageHeightInGrid
      Else
        widthDiff = Math.Abs(displayImage.Width - ImageWidthInGrid)
        heightDiff = Math.Abs(displayImage.Height - ImageHeightInGrid)

        If widthDiff > heightDiff Then
          resizeWidth = ImageWidthInGrid
          resizeHeight = CType(displayImage.Height * (resizeWidth / displayImage.Width), Integer)
        Else
          resizeHeight = ImageHeightInGrid
          resizeWidth = CType(displayImage.Width * (resizeHeight / displayImage.Height), Integer)
        End If
      End If

      displayImage.Dispose()

      displayImage = GetResizedImage(imagePath, resizeWidth, resizeHeight, Not MaintainAspectRatioInGrid)

      Return displayImage

    End Function

    Protected Overrides Function GetVehiclePageImageName(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As String
      Return Processor.GetImageFileName(vehicleId, pageNumber)
    End Function

    Protected Overrides Function AreVehiclePageImagesScanned(ByVal vehicleId As Integer) As Boolean
      Return Processor.AreVehiclePageImagesScanned(vehicleId)
    End Function

    Protected Overrides Function AreVehicleImagesTransferred(ByVal vehicleId As Integer, ByVal locationId As Integer) As Boolean
      Return Processor.AreVehicleImagesTransferred(vehicleId, locationId)
    End Function


#Region " IForm Implementation "

    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied

    Public Event InitializingForm() Implements IForm.InitializingForm
    Public Event FormInitialized() Implements IForm.FormInitialized


    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

    End Sub

    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

      RaiseEvent InitializingForm()

      Me.StatusMessage = "Loading information. This may take some time. Please wait..."

      Me.FormState = formStatus

      Me.dayRangeNumericUpDown.Value = DayDifference

      Me.DisplayFamilyInformationTableAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      m_familyCreationProcessor = New Processors.FamilyCreation
      Processor.Initialize()

      Processor.FamilyAdapter.Fill(Processor.Data.Family)
      'Processor.VehicleAdapter.Fill(Processor.Data.vwCircular)
      Processor.DisplayFamilyInformationAdapter.Fill _
          (Processor.Data.DisplayFamilyInformation _
           , RetailerId, MediaId, BreakDate, DayDifference)

      Me.StatusMessage = "Information loaded. Preparing to show information on window."

      familyDataGridView.DataSource = Processor.Data.DisplayFamilyInformation

      Me.StatusMessage = String.Empty

      RaiseEvent FormInitialized()

    End Sub

#End Region



    Private Sub FamilyCreationForm_Enter _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Enter

      If Me.DesignMode Then Exit Sub

      LoadPageImagesInDataGrid()

    End Sub

    Private Sub familyDataGridView_CellContentClick _
        (ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles familyDataGridView.CellContentClick
      Dim vehicleId, selectedRowIndex As Integer

      If Not (e.ColumnIndex = 2 And e.RowIndex >= 0) Then Exit Sub


      If familyDataGridView.SelectedRows.Count <> 1 Then
        MessageBox.Show("Can show only one Family at a time.", ProductName, _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      selectedRowIndex = familyDataGridView.SelectedRows(0).Index 'There can be only one selected row.

      vehicleId = CType(familyDataGridView.Rows(e.RowIndex).Cells("VehicleIdDataGridViewTextBoxColumn").Value, Integer)
      Dim showVehicles As FamilyViewForm
      showVehicles = New FamilyViewForm
      showVehicles.Init(FormStateEnum.View)
      showVehicles.HideReviewButtons()
      showVehicles.vehicleIdTextBox.Text = vehicleId.ToString()
      showVehicles.Show(Me)
      showVehicles.LoadVehicles()
      showVehicles.Hide()
      showVehicles.ShowDialog(Me)
      showVehicles.Dispose()
      showVehicles = Nothing

    End Sub

    Private Sub familyDataGridView_CellDoubleClick _
        (ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles familyDataGridView.CellDoubleClick
      Dim isThumbnailAvailable As Boolean = True
      Dim vehicleId, columnIndex, selectedRowIndex As Integer
      Dim VehiclePath As String
      Dim imageFolderPath As String
      Dim thumbnailQuery As System.Collections.Generic.IEnumerable(Of String)


      If Not ((e.ColumnIndex = 0 OrElse e.ColumnIndex = 1) AndAlso e.RowIndex >= 0) Then Exit Sub

      If familyDataGridView.SelectedRows.Count <> 1 Then
        MessageBox.Show("Can show only one Family at a time.", ProductName, _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      selectedRowIndex = familyDataGridView.SelectedRows(0).Index
      columnIndex = familyDataGridView.Columns("VehicleIdDataGridViewTextBoxColumn").Index
      vehicleId = CType(familyDataGridView.Rows(selectedRowIndex).Cells(columnIndex).Value, Integer)

      VehiclePath = Processor.RetrieveYearMonth(vehicleId)
      imageFolderPath = VehicleImageFolderPath + "\" + VehiclePath _
                        + "\" + vehicleId.ToString() + "\" + ThumbSizedPageImageFolderName
      If System.IO.Directory.Exists(imageFolderPath) = False Then
        isThumbnailAvailable = False
        imageFolderPath = VehicleImageFolderPath + "\" + VehiclePath _
                          + "\" + vehicleId.ToString() + "\" + UnsizedPageImageFolderName
      End If

      Application.DoEvents()

      Processor.LoadPagesInformation(vehicleId)
      thumbnailQuery = From pageRow In Processor.Data.Page _
                       Select imageFolderPath + "\" + pageRow.ImageName + ".jpg"

      Dim thumbnailForm As UI.Controls.ThumbnailBrowserForm = New UI.Controls.ThumbnailBrowserForm()
      thumbnailForm.LoadThumbnails(thumbnailQuery.ToArray(), isThumbnailAvailable)
      thumbnailForm.Text += " - Vehicle " + vehicleId.ToString()
      Application.DoEvents()
      thumbnailForm.ShowDialog(Me)
      thumbnailForm.Dispose()
      thumbnailForm = Nothing

      thumbnailQuery = Nothing

    End Sub

    Private Sub dayRangeNumericUpDown_ValueChanged _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles dayRangeNumericUpDown.ValueChanged

      m_dayDifference = CType(dayRangeNumericUpDown.Value, Integer)

    End Sub

    Private Sub cancelButton_Click _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles cancelButton.Click

      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()

    End Sub

    Private Sub okButton_Click _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles okButton.Click
      Dim userResponse As DialogResult


      If newFamilyRadioButton.Checked = True Then
        Dim newFamily As FamilyDataSet.FamilyRow

        newFamily = Processor.CreateNew()
        newFamily.FormName = FORM_NAME
        Processor.Add(newFamily)
        Processor.Save()
        m_familyId = newFamily.FamilyId
        newFamily = Nothing

        m_IsNewFamily = True
        userResponse = Windows.Forms.DialogResult.Yes

      ElseIf joinFamilyRadioButton.Checked = True Then
        Dim bmb As BindingManagerBase
        Dim currentFamily As FamilyDataSet.DisplayFamilyInformationRow

        bmb = Me.BindingContext(familyDataGridView.DataSource)
        currentFamily = CType(CType(bmb.Current, DataRowView).Row, FamilyDataSet.DisplayFamilyInformationRow)
        bmb = Nothing

        If (currentFamily.BreakDt.Subtract(BreakDate).Days > 3) Then
          userResponse = MessageBox.Show("Are you sure? Difference of Ad Date is more than 3 days.", _
                                         ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                         MessageBoxDefaultButton.Button2)
        Else
          userResponse = Windows.Forms.DialogResult.Yes
        End If

        If userResponse = Windows.Forms.DialogResult.Yes Then
          m_familyId = currentFamily.FamilyId
        End If

        m_IsNewFamily = False
        currentFamily = Nothing
      End If

      'Close form only if user has confirmed message shown to him/her, while in edit mode.
      If userResponse = Windows.Forms.DialogResult.Yes Then
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
      End If

    End Sub

    Private Sub searchButton_Click _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles searchButton.Click

      Processor.Load(BreakDate, MediaId, RetailerId, DayDifference)
      If Processor.Data.DisplayFamilyInformation.Count = 0 Then
        joinFamilyRadioButton.Enabled = False
        newFamilyRadioButton.Checked = True
      Else
        joinFamilyRadioButton.Enabled = True
        joinFamilyRadioButton.Checked = True
        LoadPageImagesInDataGrid()
        If familyDataGridView.Rows.Count > 0 Then familyDataGridView.Rows(0).Selected = True
      End If

    End Sub


  End Class


End Namespace