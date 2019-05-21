Imports MCAP.BackgroundThreading
Imports System.IO
Public Class ImageCountWorker
    Implements IWorker
#Region "Constant Literal Variables"
    Private Const m_INVALID_FILE_SIZE As String = _
      "Image {0} has a file size of zero and will not be moved. Rescan or delete the image."
#End Region
#Region "Private Member Variables"

    Private m_folder As String
    Private m_fileExtension As String
    Private m_controller As IController
    Private m_imageInfo As ArrayList
    Private m_imageCount As Integer

#End Region
    '''-----------------------------------------------------------------------------
    ''' <summary>
    ''' Constructor exposed to UI thread through controller for all set up.
    ''' </summary>
    ''' <param name="folder"> folder to count images in</param>
    ''' <param name="fileExtension">files matching this pattern are included in the 
    ''' count. Optional - the default is "*.jpg"</param>
    ''' <remarks></remarks>
    '''-----------------------------------------------------------------------------
    Public Sub New(ByVal folder As String, _
        Optional ByVal fileExtension As String = "*.jpg")
        m_folder = folder
        m_fileExtension = fileExtension
        m_imageInfo = New ArrayList
    End Sub

#Region "IWorker Methods"
    Public Sub Initialize(ByVal Controller As BackgroundThreading.IController) Implements BackgroundThreading.IWorker.Initialize
        m_controller = Controller
        m_controller.SetRunningTaskType(IController.TaskType.CountImages)
    End Sub

    Public Sub Start() Implements BackgroundThreading.IWorker.Start
        Dim cancelled As Boolean = False
        Try
            ScanForImageCount(cancelled, m_folder)
            m_controller.SetInfoList(m_imageInfo)
            m_controller.Completed(cancelled, True)
        Catch e As Exception
            m_controller.Failed(e)
        End Try
    End Sub
#End Region

  '''-----------------------------------------------------------------------------
  ''' <summary>
  '''   Scans specified path and all subdirectories for specified file extension
  '''   in this case jpgs.  The function recursively calls itself as each time
  '''   it locates a subdirectory.
  ''' </summary>
  ''' <remarks></remarks>
  '''-----------------------------------------------------------------------------
  ''' 
  Private Sub ScanForImageCount(ByRef cancelled As Boolean, ByVal folder As String)

    Dim sourceDirInfo As DirectoryInfo
    Dim directories() As FileSystemInfo
    Dim imageFileList() As FileSystemInfo
    Dim dirNext As DirectoryInfo
    Dim imageFileNext As FileInfo


    If m_controller.Running Then


      sourceDirInfo = New DirectoryInfo(folder)
      imageFileList = sourceDirInfo.GetFiles(m_fileExtension)
      ' Find number of files with the correct extension in the current directory
      m_imageCount += imageFileList.Length
      m_controller.Display("Counting images...")

      ' Store file information about each of the matching files
      For Each imageFileNext In imageFileList
        If imageFileNext.Length >= 1000L Then
          m_imageInfo.Add(imageFileNext)
        Else
          'Since we already got the number of files, just subtract the count by one
          'for each file that has a size of 0
          m_imageCount -= 1
          MessageBox.Show(String.Format(m_INVALID_FILE_SIZE, folder & "\" & imageFileNext.Name), _
                    "Zero Image File Size", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, _
                        MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
        End If
      Next

      ' Now report the count back to the UI
      m_controller.SetCount(m_imageCount)
      directories = sourceDirInfo.GetDirectories()
      For Each dirNext In directories
        ScanForImageCount(cancelled, dirNext.FullName)
      Next
    Else
      cancelled = True
      Exit Sub
    End If

  End Sub
End Class
