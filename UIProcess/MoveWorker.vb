Imports MCAP.BackgroundThreading
Imports System.Drawing.Imaging
Imports System.Data.SqlClient
Imports System.IO

Public Class MoveWorker
  Implements IWorker

#Region "Private Member Variables"
  Private m_folder As String
  Private m_fileExtension As String
  Private m_controller As IController
  Private m_imageInfo As ArrayList
  Private m_imageCount As Integer
  Private m_source As String
  Private m_destination As String
  Private m_bOverWrite As Boolean
#End Region

#Region "Properties"
  Property OverWrite() As Boolean
    Get
      Return m_bOverWrite
    End Get
    Set(ByVal value As Boolean)
      m_bOverWrite = value
    End Set
  End Property
#End Region

#Region "Class Functions"
  Public Sub New(ByVal src As String, ByVal dest As String)
    m_source = src
    m_destination = dest
    m_imageInfo = New ArrayList
  End Sub
#End Region

#Region "IWorker Implementation"
  Public Sub Initialize(ByVal Controller As BackgroundThreading.IController) Implements BackgroundThreading.IWorker.Initialize
    m_controller = Controller
    m_controller.SetRunningTaskType(IController.TaskType.MoveImages)
  End Sub

  Public Sub Start() Implements BackgroundThreading.IWorker.Start
    Dim cancelled As Boolean = False
    Try
      'ScanForImageCount(cancelled, m_folder)
      'm_controller.SetInfoList(m_imageInfo)
      MoveImages()
      Debug.WriteLine(Now.ToString & ": Worker.Controller.Completed.")
      m_controller.Completed(cancelled, True)
    Catch e As Exception
      Debug.WriteLine(Now.ToString & ": Start failed with " & e.ToString)
      m_controller.Failed(e)
    End Try
  End Sub
#End Region

#Region "Functions"
  Private Sub MoveImages()
    Dim srcDirInfo As DirectoryInfo
    Dim destDirInfo As DirectoryInfo

    Dim vehicleFolder As DirectoryInfo

    If Not Directory.Exists(m_source) Then
      m_controller.ErrorList.Add("Source folder: " & m_source & " does not exist.")
      Exit Sub
    End If

    If Not Directory.Exists(m_destination) Then
      m_controller.ErrorList.Add("Destination folder: " & m_destination & " does not exist.")
      Exit Sub
    End If

    srcDirInfo = New DirectoryInfo(m_source)
    destDirInfo = New DirectoryInfo(m_destination)

    If Not m_controller.Running Then
      m_controller.ErrorList.Add("Cancelled.")
      Debug.WriteLine(Now.ToString & ": MoveWorker.MoveImages(82) thinks controller is not running.")
      Exit Sub
    End If
    Debug.WriteLine(Now.ToString & ": Looping through " & srcDirInfo.GetDirectories.Count.ToString & " subfolders")
    For Each vehicleFolder In srcDirInfo.GetDirectories
      If Not m_controller.Running Then
        m_controller.ErrorList.Add("Cancelled.")
        Debug.WriteLine(Now.ToString & ": MoveWorker.MoveImages(89) thinks controller is not running.")
        Exit Sub
      End If
      Debug.WriteLine(Now.ToString & ": Checking " & vehicleFolder.Name)
      If ValidVehicleId(vehicleFolder.Name) Then
        If Not m_controller.Running Then
          m_controller.ErrorList.Add("Cancelled.")
          Debug.WriteLine(Now.ToString & ": MoveWorker.MoveImages(96) thinks controller is not running.")
          Exit Sub
        End If
        Debug.WriteLine(Now.ToString & ": Checking page count of " & vehicleFolder.Name)
        If ValidVehiclePageCount(vehicleFolder.Name, vehicleFolder.GetFiles) Then
          If Not m_controller.Running Then
            m_controller.ErrorList.Add("Cancelled.")
            Debug.WriteLine(Now.ToString & ": MoveWorker.MoveImages(103) thinks controller is not running.")
            Exit Sub
          End If
          MoveVehicleImages(vehicleFolder.Name, m_source, m_destination)
        End If
      End If
    Next

    ' Loop through vehicle folders
    ' Verify each vehicle as a valid ID
    ' Verify each vehicle page count
    ' Move image

  End Sub

  Private Sub MoveVehicleImages(ByVal vehicleIdStr As String, ByVal src As String, ByVal dest As String)
    Dim vehicleId As Integer
    If Not Integer.TryParse(vehicleIdStr, vehicleId) Then
      m_controller.ErrorList.Add(Now.ToString & " " & vehicleIdStr & " is not an integer.")
      Exit Sub
    End If
    Dim vehicleAdapter As New QCDataSetTableAdapters.vwCircularTableAdapter
    Dim vehicleDataTable As QCDataSet.vwCircularDataTable
    Dim vehicle As QCDataSet.vwCircularRow
    vehicleAdapter.Fill(vehicleDataTable, vehicleId)
    If vehicleDataTable.Count <> 1 Then
      m_controller.ErrorList.Add(Now.ToString & " " & vehicleIdStr & " does not exist in the database")
      Exit Sub
    End If
    vehicle = CType(vehicleDataTable.Rows(0), QCDataSet.vwCircularRow)
    Dim i As Integer
    Dim image As FileInfo
    If Not m_controller.Running Then
      m_controller.ErrorList.Add("Cancelled.")
      Exit Sub
    End If
    Dim destFolder As String = dest & Path.DirectorySeparatorChar & vehicleIdStr
    If Not Directory.Exists(destFolder) Then
      Directory.CreateDirectory(destFolder)
    End If
    For i = 1 To vehicle.ActualPageCount
      If Not m_controller.Running Then
        m_controller.ErrorList.Add("Cancelled.")
        Exit Sub
      End If
      image = New FileInfo(m_source & Path.DirectorySeparatorChar & vehicleIdStr & Path.DirectorySeparatorChar & Right("000" & i.ToString, 3) & ".jpg")
      MoveImage(image, destFolder)
    Next
  End Sub

  Private Sub LogImageMove()

  End Sub

  Private Function MoveImage(ByRef img As FileInfo, ByVal destFolder As String) As Boolean
    ' Move image
    ' check if exists
    ' make sure destination exists
    ' Overwrite if flagged?

  End Function

  Private Function ValidVehicleId(ByVal vehicleIdStr As String) As Boolean
    Dim vehicleId As Integer
    If Not Integer.TryParse(vehicleIdStr, vehicleId) Then
      m_controller.ErrorList.Add(Now.ToString & " " & vehicleIdStr & " is not an integer.")
      Return False
    End If
    ' check database
    Dim vehicleAdapter As New QCDataSetTableAdapters.vwCircularTableAdapter
    Dim vehicleDataTable As QCDataSet.vwCircularDataTable
    vehicleAdapter.Fill(vehicleDataTable, vehicleId)
    Return (vehicleDataTable.Count = 1)
  End Function

  Private Function ValidVehiclePageCount(ByVal vehicleIdStr As String, ByRef images() As FileInfo) As Boolean
    Dim vehicleId As Integer
    If Not Integer.TryParse(vehicleIdStr, vehicleId) Then
      m_controller.ErrorList.Add(Now.ToString & " " & vehicleIdStr & " is not an integer.")
      Return False
    End If
    Dim vehicleAdapter As New QCDataSetTableAdapters.vwCircularTableAdapter
    Dim vehicleDataTable As QCDataSet.vwCircularDataTable
    Dim vehicle As QCDataSet.vwCircularRow
    vehicleAdapter.Fill(vehicleDataTable, vehicleId)
    If vehicleDataTable.Count <> 1 Then
      m_controller.ErrorList.Add(Now.ToString & " " & vehicleIdStr & " does not exist in the database")
      Return False
    End If
    vehicle = CType(vehicleDataTable.Rows(0), QCDataSet.vwCircularRow)
    Dim i As Integer
    Dim image As FileInfo
    Debug.WriteLine(Now.ToString & ": Vehicle " & vehicleIdStr & " should have " & vehicle.ActualPageCount.ToString & " pages.")
    If Not m_controller.Running Then
      m_controller.ErrorList.Add("Cancelled.")
      Return False
    End If
    For i = 1 To vehicle.ActualPageCount
      If Not m_controller.Running Then
        m_controller.ErrorList.Add("Cancelled.")
        Return False
      End If
      image = New FileInfo(m_source & Path.DirectorySeparatorChar & vehicleIdStr & Path.DirectorySeparatorChar & Right("000" & i.ToString, 3) & ".jpg")
      Debug.WriteLine(Now.ToString & ": Checking if " & vehicleIdStr & " page: " & i.ToString & " exists.")
      If Not image.Exists Then
        m_controller.ErrorList.Add("Page " & i.ToString & " does not exist.")
        Return False
      End If
    Next
    Return True
  End Function

#End Region

End Class
