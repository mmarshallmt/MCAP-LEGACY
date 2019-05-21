Namespace UI.Processors


  Public Class ScanTrackerEROP
    Inherits BaseClass


    Private m_dataSet As eropDataSet


    Public Event LoadingEROPLogEntries As EventHandler
    Public Event EROPLogEntriesLoaded As EventHandler
    Public Event QueuingSubfoldersForProcessing As EventHandler(Of UI.Processors.FileSystemEventArgs)
    Public Event SubfoldersQueuedForProcessing As EventHandler(Of UI.Processors.FileSystemEventArgs)
    Public Event QueuingFolder As EventHandler(Of UI.Processors.DirectoryEventArgs)
    Public Event FolderQueued As EventHandler(Of UI.Processors.DirectoryEventArgs)
    Public Event InvalidSubfolderForProcessingQueue As EventHandler(Of UI.Processors.DirectoryEventArgs)

    Public Event MarkingRowsForProcessing As EventHandler
    Public Event RowsMarkedForProcessing As EventHandler
    Public Event MarkingRow As EventHandler
    Public Event RowMarked As EventHandler

    Public Event UnmarkingRowsForProcessing As EventHandler
    Public Event RowsUnmarkedForProcessing As EventHandler
    Public Event UnmarkingRow As EventHandler
    Public Event RowUnmarked As EventHandler

    Public Event ValidatingMarkedPublications As EventHandler
    Public Event MarkedPublicationsValidated As EventHandler
    Public Event ValidatingPublication As EventHandler(Of EROPLogEventArgs)
    Public Event PublicationValidated As EventHandler(Of EROPLogEventArgs)


    Public Event UnzippingAllMarkedPublications As EventHandler(Of UnzipEventArgs)
    Public Event UnzippingMarkedPublication As EventHandler(Of UnzipEventArgs)
    Public Event ExtractingZipFile As EventHandler(Of UnzipFileEventArgs)
    Public Event ZipFileExtracted As EventHandler(Of UnzipFileEventArgs)
    Public Event MarkedPublicationUnzipped As EventHandler(Of UnzipEventArgs)
    Public Event AllMarkedPublicationsUnzipped As EventHandler(Of UnzipEventArgs)

    Public Event LoadingEROPFileLogEntriesForMarkedPublications As EventHandler
    Public Event EROPFileLogEntriesForMarkedPublicationsLoaded As EventHandler

    Public Event CrawlingFile As EventHandler(Of FileEventArgs)
    Public Event CrawledFile As EventHandler(Of FileEventArgs)
    Public Event CrawlingMarkedPublicationFolders As EventHandler(Of FileSystemEventArgs)
    Public Event CrawledMarkedPublicationFolders As EventHandler(Of FileSystemEventArgs)
    Public Event CrawlingMarkedPublicationFolder As EventHandler(Of DirectoryEventArgs)
    Public Event CrawledMarkedPublicationFolder As EventHandler(Of DirectoryEventArgs)

    Public Event ValidatingPDFFileForMarkedPublications As EventHandler(Of FileSystemEventArgs)
    Public Event PDFFileForMarkedPublicationsValidated As EventHandler(Of FileSystemEventArgs)
    Public Event ValidatingMarkedPublicationFiles As EventHandler(Of DirectoryEventArgs)
    Public Event MarkedPublicationFilesValidated As EventHandler(Of DirectoryEventArgs)
    Public Event ValidatingFile As EventHandler(Of FileEventArgs)
    Public Event InvalidFile As EventHandler(Of FileEventArgs)
    Public Event FileValidated As EventHandler(Of FileEventArgs)

    Public Event SynchronizingEROPFileLogEntriesForMarkedPublications As EventHandler
    Public Event EROPFileLogEntriesForMarkedPublicationsSynchronized As EventHandler


    Public Event ConvertingPublicationsToImages As EventHandler(Of ConversionEventArgs)
    Public Event ConvertedPublicationsToImages As EventHandler(Of ConversionEventArgs)

    Public Event ConvertingPDFFilesToImages As EventHandler(Of PublicationConversionEventArgs)
    Public Event ConvertedPDFFilesToImages As EventHandler(Of PublicationConversionEventArgs)
    Public Event ConvertingPDFFilePagesToImages As EventHandler(Of FileConversionEventArgs)
    Public Event ConvertedPDFFilePagesToImages As EventHandler(Of FileConversionEventArgs)
    Public Event ConvertingPDFFilePageToImage As EventHandler(Of PageConversionEventArgs)
    Public Event ConvertedPDFFilePageToImage As EventHandler(Of PageConversionEventArgs)

    Public Event ProcessingPublicationsForDoubleTruckAd As EventHandler(Of ConversionEventArgs)
    Public Event ProcessedPublicationsForDoubleTruckAd As EventHandler(Of ConversionEventArgs)
    Public Event ProcessingPublicationForDoubleTruckAd As EventHandler(Of PublicationConversionEventArgs)
    Public Event ProcessedPublicationForDoubleTruckAd As EventHandler(Of PublicationConversionEventArgs)
    Public Event IdentifyingPossibleDoubleTruckAds As EventHandler
    Public Event IdentifiedPossibleDoubleTruckAds As EventHandler
    Public Event ProcessingPageImageForDoubleTruckAd As EventHandler(Of DoubleTruckPageEventArgs)
    Public Event ProcessedPageImageForDoubleTruckAd As EventHandler(Of DoubleTruckPageEventArgs)

    Public Event SynchronizingEROPFilePageInformation As EventHandler
    Public Event EROPFilePageInformationSynchronized As EventHandler


    Public Event RecountingImages As EventHandler
    Public Event ImagesRecounted As EventHandler

    Public Event FetchingListOfAllImagesPath As EventHandler
    Public Event ListOfAllImagesPathFetched As EventHandler

    Public Event MovingAdImagesToVehicleFolder As EventHandler(Of MovePublicationImagesEventArgs)
    Public Event AdImagesMovedToVehicleFolder As EventHandler(Of MovePublicationImagesEventArgs)
    Public Event CopyingPageImage As EventHandler(Of MoveImageEventArgs)
    Public Event PageImageCopied As EventHandler(Of MoveImageEventArgs)


    Sub New()

      m_dataSet = New eropDataSet()

    End Sub



    ''' <summary>
    ''' Gets instance of EROPdataset.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Data() As eropDataSet
      Get
        Return m_dataSet
      End Get
    End Property


    Public Sub Initialize()
      'Do Nothing.
    End Sub

    ''' <summary>
    ''' Creates new row in Log datatable. Entries added to this row can be viewed by users at the end of wizard.
    ''' </summary>
    ''' <param name="logId"></param>
    ''' <param name="tableName"></param>
    ''' <param name="noteText"></param>
    ''' <remarks></remarks>
    Public Sub Log(ByVal logId As Integer, ByVal tableName As String, ByVal noteText As String)
      Dim tempRow As eropDataSet.LogRow


      tempRow = Me.Data.Log.NewLogRow()

      tempRow.BeginEdit()
      tempRow.LogId = logId
      tempRow.TableName = tableName
      tempRow.Note = noteText
      tempRow.TimeStamp = DateTime.Now
      tempRow.EndEdit()

      Me.Data.Log.AddLogRow(tempRow)
      tempRow = Nothing

    End Sub


#Region " Step 1 related methods "

    ''' <summary>
    ''' Adds two columns for Status and Note in EROPLog data table. These columns are just for 
    ''' in-memory data storage and it has nothing to do with database itself.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddColumnsForStatusAndNoteInEROPLogDataTable()
      Dim statusDataColumn, noteDataColumn, isMarkedDataColumn As System.Data.DataColumn


      statusDataColumn = New System.Data.DataColumn("Status")
      noteDataColumn = New System.Data.DataColumn("Note")
      isMarkedDataColumn = New System.Data.DataColumn("IsMarked")

      With statusDataColumn
        .AllowDBNull = True
        .AutoIncrement = False
        .Caption = "Status"
        .DataType = System.Type.GetType("System.String")
        .MaxLength = 25
        .ReadOnly = False
        .Unique = False
      End With

      With noteDataColumn
        .AllowDBNull = True
        .AutoIncrement = False
        .Caption = "Note"
        .DataType = System.Type.GetType("System.String")
        .MaxLength = 512
        .ReadOnly = False
        .Unique = False
      End With

      With isMarkedDataColumn
        .AllowDBNull = True
        .AutoIncrement = False
        .Caption = "Convert"
        .DataType = System.Type.GetType("System.Boolean")
        .ReadOnly = False
        .Unique = False
      End With

      m_dataSet.EROPLog.Columns.Add(statusDataColumn)
      m_dataSet.EROPLog.Columns.Add(noteDataColumn)
      m_dataSet.EROPLog.Columns.Add(isMarkedDataColumn)

    End Sub

    ''' <summary>
    ''' Returns boolean value, indicating whether supplied value of publication id exist in database or not.
    ''' </summary>
    ''' <param name="publicationId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <exception cref="System.Data.SqlClient.SqlException">Database related exception.</exception>
    ''' <exception cref="System.Exception">Unknown error has occurred.</exception>
    Protected Function IsValidPublicationId(ByVal publicationId As Integer) As Boolean
      Dim rowCount As Integer?
      Dim tempAdapter As eropDataSetTableAdapters.EROPLogTableAdapter


      tempAdapter = New eropDataSetTableAdapters.EROPLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      Try
        rowCount = tempAdapter.IsPublicationIdExist(publicationId)
      Catch ex As System.Data.SqlClient.SqlException
        Throw
      Catch ex As Exception
        Throw
      Finally
        tempAdapter.Dispose()
        tempAdapter = Nothing
      End Try

      If rowCount.HasValue AndAlso rowCount.Value > 0 Then
        rowCount = Nothing
        Return True
      Else
        rowCount = Nothing
        Return False
      End If

    End Function

    ''' <summary>
    ''' Inserts record into EROPLog data table.
    ''' </summary>
    ''' <param name="publicationId"></param>
    ''' <param name="downloadDate"></param>
    ''' <param name="statusText"></param>
    ''' <param name="noteText"></param>
    ''' <remarks></remarks>
    Protected Sub AddOrUpdatePublicationFolderInformation(ByVal publicationId As Integer, ByVal downloadDate As DateTime, ByVal statusText As String, ByVal noteText As String)
      Dim tempRow As eropDataSet.EROPLogRow
      Dim publicationQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPLogRow)


      publicationQuery = From r In Me.Data.EROPLog _
                         Where r.PublicationId = publicationId AndAlso r.DownloadDt = downloadDate _
                         Select r
      If publicationQuery.Count() = 1 Then
        publicationQuery(0).BeginEdit()
        publicationQuery(0).Status = "Processed"
        publicationQuery(0).Note = String.Format("This publication is already processed during previous execution on {0}.", publicationQuery(0).CreateDt.ToString("MM/dd/yyyy"))
        publicationQuery(0).EndEdit()
        publicationQuery(0).AcceptChanges()
      Else
        tempRow = Me.Data.EROPLog.NewEROPLogRow()
        tempRow.BeginEdit()
        tempRow.PublicationId = publicationId
        tempRow.DownloadDt = downloadDate
        tempRow.CreateDt = System.DateTime.Now  'Record creation date.
        tempRow.Status = statusText
        tempRow.Note = noteText
        tempRow.IsMarked = True
        tempRow.EndEdit()
        Me.Data.EROPLog.AddEROPLogRow(tempRow)
      End If

      publicationQuery = Nothing

    End Sub

    ''' <summary>
    ''' Checks whether the leaf directory name, of the supplied path, can converted into date. 
    ''' If it can be converted into date, date value is returned otherwise Nothing is returned.
    ''' </summary>
    ''' <param name="downloadDateFolderPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDownloadDate(ByVal downloadDateFolderPath As String) As DateTime?
      Dim downloadDateFolderName, downloadDateString As String
      Dim downloadDt As DateTime
      Dim downloadDate As Nullable(Of DateTime)


      downloadDateFolderName = System.IO.Path.GetFileName(downloadDateFolderPath)

      If downloadDateFolderName.Length <> 8 Then
        downloadDate = Nothing
      Else
        downloadDateString = downloadDateFolderName.Substring(4, 2) _
                      + "/" + downloadDateFolderName.Substring(6, 2) _
                      + "/" + downloadDateFolderName.Substring(0, 4)
        If DateTime.TryParse(downloadDateString, downloadDt) = True Then
          downloadDate = downloadDt
        End If
      End If

      downloadDateString = Nothing
      downloadDateFolderName = Nothing

      Return downloadDate

    End Function

    ''' <summary>
    ''' Valdiates supplied path for its existance and having leaf directory name as valid date in yyyyMMdd format.
    ''' </summary>
    ''' <param name="downloadDateFolderPath"></param>
    ''' <remarks></remarks>
    ''' <exception cref="System.IO.DirectoryNotFoundException">Supplied download path is invalid.</exception>
    ''' <exception cref="System.Exception">Supplied download folder name is not a valid date.</exception>
    Public Sub ValidateDownloadPath(ByVal downloadDateFolderPath As String)
      Dim isValidPath As Boolean
      Dim downloadDate As DateTime?


      isValidPath = System.IO.Directory.Exists(downloadDateFolderPath)
      If isValidPath = False Then
        Throw New System.IO.DirectoryNotFoundException("Invalid download path specified.")
      End If

      downloadDate = GetDownloadDate(downloadDateFolderPath)
      isValidPath = downloadDate.HasValue
      If isValidPath = False Then
        Throw New System.Exception("Invalid download folder specified.")
      End If

    End Sub

    ''' <summary>
    ''' Loads all rows having download date same as supplied parameter value.
    ''' </summary>
    ''' <param name="downloadDt"></param>
    ''' <remarks></remarks>
    Private Sub LoadAllEntriesPublishedOn(ByVal downloadDt As DateTime)
      Dim tempAdapter As eropDataSetTableAdapters.EROPLogTableAdapter


      tempAdapter = New eropDataSetTableAdapters.EROPLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      Try
        tempAdapter.Fill(Me.Data.EROPLog, downloadDt)
      Catch ex As System.Data.SqlClient.SqlException
        Throw
      Catch ex As Exception
        Throw
      Finally
        tempAdapter.Dispose()
        tempAdapter = Nothing
      End Try

      'Following for loop is to allow check all button to check processed folders.
      For i As Integer = 0 To Me.Data.EROPLog.Count - 1
        Me.Data.EROPLog(i).IsMarked = False
      Next
      Me.Data.EROPLog.AcceptChanges()

    End Sub

    ''' <summary>
    ''' Creates new record, in EROPLog DataTable, for each folder under specified path.
    ''' </summary>
    ''' <param name="downloadDateFolderPath"></param>
    ''' <remarks></remarks>
    ''' <exception cref="System.IO.IOException">Unable to identify download date from specified download path.</exception>
    ''' <exception cref="System.Exception">Specified path contains zero sub directory.</exception>
    Public Sub QueueSubfoldersForProcessing(ByVal downloadDateFolderPath As String)
      Dim publicationId As Integer
      Dim downloadDate As DateTime?
      Dim rootDir, subdirInfo() As System.IO.DirectoryInfo
      Dim directoryQuery As System.Collections.Generic.IEnumerable(Of System.IO.DirectoryInfo)


      rootDir = New System.IO.DirectoryInfo(downloadDateFolderPath)
      subdirInfo = rootDir.GetDirectories()

      downloadDate = GetDownloadDate(downloadDateFolderPath)
      If downloadDate.HasValue = False Then
        Throw New System.IO.IOException("Unable to identify download date from specified path.")
      End If

      If subdirInfo Is Nothing OrElse subdirInfo.Length = 0 Then
        Throw New System.Exception("Specified directory contain zero sub directory.")
      End If

      RaiseEvent LoadingEROPLogEntries(Me, New System.EventArgs())

      LoadAllEntriesPublishedOn(downloadDate.Value)

      RaiseEvent EROPLogEntriesLoaded(Me, New System.EventArgs())

      For i As Integer = Me.Data.EROPLog.Count - 1 To 0 Step -1
        directoryQuery = From d In subdirInfo _
                         Where d.Name = Me.Data.EROPLog(i).PublicationId.ToString() _
                         Select d
        If directoryQuery.Count() = 0 Then
          Me.Data.EROPLog(i).Delete()
          Me.Data.EROPLog.AcceptChanges()
        End If
      Next

      RaiseEvent QueuingSubfoldersForProcessing(Me, New FileSystemEventArgs(downloadDateFolderPath))

      For i As Integer = 0 To subdirInfo.Length - 1
        'Only insert folders with name as valid numeric value, because publication id is a numeric field in database.
        'Valid publication id folders can have numeric value as their name.
        If Integer.TryParse(subdirInfo(i).Name, publicationId) = False Then
          RaiseEvent InvalidSubfolderForProcessingQueue(Me, New DirectoryEventArgs(subdirInfo(i).Name, subdirInfo.Length, i + 1))
          Continue For
        End If

        RaiseEvent QueuingFolder(Me, New DirectoryEventArgs(subdirInfo(i).Name, subdirInfo.Length, i + 1))

        AddOrUpdatePublicationFolderInformation(publicationId, downloadDate.Value, "Unknown", String.Empty)

        RaiseEvent FolderQueued(Me, New DirectoryEventArgs(subdirInfo(i).Name, subdirInfo.Length, i + 1))
      Next

      RaiseEvent SubfoldersQueuedForProcessing(Me, New FileSystemEventArgs(downloadDateFolderPath))

    End Sub

    ''' <summary>
    ''' Marks all rows in EROPLog table for conversion.
    ''' </summary>
    ''' <remarks></remarks>
    ''' <exception cref="System.InvalidOperationException">Zero unmarked rows found with status "Pending".</exception>
    Public Sub MarkAllEROPLogRows()
      Dim markedRows As System.Data.EnumerableRowCollection(Of eropDataSet.EROPLogRow)


      markedRows = From r In Me.Data.EROPLog _
                   Where r.IsIsMarkedNull() = False AndAlso r.IsMarked = False AndAlso r.Status = "Pending" _
                   Select r

      If markedRows.Count() = 0 Then Throw New InvalidOperationException("There is no unmarked row with status as Pending.", Nothing)

      RaiseEvent MarkingRowsForProcessing(Me, New System.EventArgs())

      For i As Integer = markedRows.Count() - 1 To 0 Step -1
        RaiseEvent MarkingRow(Me, New System.EventArgs())
        markedRows(i).BeginEdit()
        markedRows(i).IsMarked = True
        markedRows(i).EndEdit()
        RaiseEvent RowMarked(Me, New System.EventArgs())
      Next

      RaiseEvent RowsMarkedForProcessing(Me, New System.EventArgs())

      markedRows = Nothing
    End Sub

    ''' <summary>
    ''' Unmarks all rows in EROPLog table for conversion.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UnmarkAllEROPLogRows()
      Dim markedRows As System.Data.EnumerableRowCollection(Of eropDataSet.EROPLogRow)


      markedRows = From r In Me.Data.EROPLog _
                   Where r.IsIsMarkedNull() = False AndAlso r.IsMarked = True _
                   Select r

      RaiseEvent UnmarkingRowsForProcessing(Me, New System.EventArgs())

      For i As Integer = markedRows.Count() - 1 To 0 Step -1
        RaiseEvent UnmarkingRow(Me, New System.EventArgs())
        markedRows(i).BeginEdit()
        markedRows(i).IsMarked = False
        markedRows(i).EndEdit()
        RaiseEvent RowUnmarked(Me, New System.EventArgs())
      Next

      RaiseEvent RowsUnmarkedForProcessing(Me, New System.EventArgs())

      markedRows = Nothing
    End Sub

    ''' <summary>
    ''' Gets number of rows marked by user for conversion.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetMarkedEROPLogRowCount() As Integer
      Dim returnValue As Integer
      Dim markedRows As System.Data.EnumerableRowCollection(Of eropDataSet.EROPLogRow)


      markedRows = From r In Me.Data.EROPLog _
                   Where r.IsIsMarkedNull() = False AndAlso r.IsMarked = True _
                   Select r

      returnValue = markedRows.Count()

      markedRows = Nothing

      Return returnValue
    End Function

    ''' <summary>
    ''' Returns boolean value indicating whether user has marked at least one row for processing or not.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function HasMarkedEROPLogRows() As Boolean
      Dim rowCount As Integer


      rowCount = GetMarkedEROPLogRowCount()

      Return (rowCount > 0)
    End Function

    ''' <summary>
    ''' Gets vehicle id based on supplied value for publication id and published on date(i.e. Ad date).
    ''' </summary>
    ''' <param name="publicationId"></param>
    ''' <param name="downloadDt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <exception cref="System.Data.SqlClient.SqlException">Database query related exception.</exception>
    ''' <exception cref="System.Exception">Unknown exception.</exception>
    Private Function GetAssociatedVehicleId(ByVal publicationId As Integer, ByVal downloadDt As DateTime) As Integer?
      Dim vehicleId As Integer?
      Dim tempAdapter As eropDataSetTableAdapters.EROPLogTableAdapter
      Dim returnValue As Object


      tempAdapter = New eropDataSetTableAdapters.EROPLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      Try
        returnValue = tempAdapter.GetAssociatedVehicleId(publicationId, downloadDt)
      Catch ex As System.Data.SqlClient.SqlException
        Throw
      Catch ex As Exception
        Throw
      Finally
        tempAdapter.Dispose()
        tempAdapter = Nothing
      End Try

      If returnValue Is Nothing OrElse returnValue Is DBNull.Value Then
        vehicleId = Nothing
      Else
        vehicleId = CType(returnValue, Integer?)
      End If

      Return vehicleId
    End Function

    ''' <summary>
    ''' Gets boolean value indicating whether the supplied associated vehicleid has valid status or not.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsAssociatedVehicleIdValid(ByVal vehicleId As Integer) As Boolean
      Dim isValid As Boolean
      Dim returnValue As Integer?
      Dim tempAdapter As eropDataSetTableAdapters.EROPLogTableAdapter


      isValid = False
      tempAdapter = New eropDataSetTableAdapters.EROPLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      Try
        returnValue = tempAdapter.IsAssociatedVehicleIdValid(vehicleId)
        isValid = (returnValue.HasValue AndAlso returnValue.Value = 1)
      Catch ex As System.Data.SqlClient.SqlException
        Throw
      Catch ex As Exception
        Throw
      Finally
        tempAdapter.Dispose()
        tempAdapter = Nothing
        returnValue = Nothing
      End Try

      Return isValid
    End Function

    ''' <summary>
    ''' Gets status text of the supplied associated vehicle.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <exception cref="System.Data.SqlClient.SqlException">Database related error.</exception>
    ''' <exception cref="System.Exception">Unknown error.</exception>
    Private Function GetVehicleStatusText(ByVal vehicleId As Integer) As String
      Dim vehicleStatus As Object
      Dim tempAdapter As eropDataSetTableAdapters.EROPLogTableAdapter


      tempAdapter = New eropDataSetTableAdapters.EROPLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      Try
        vehicleStatus = tempAdapter.GetVehicleStatusText(vehicleId)
      Catch ex As System.Data.SqlClient.SqlException
        Throw
      Catch ex As Exception
        Throw
      Finally
        tempAdapter.Dispose()
        tempAdapter = Nothing
      End Try

      If vehicleStatus Is Nothing Then
        Return String.Empty
      Else
        Return vehicleStatus.ToString()
      End If

    End Function

    ''' <summary>
    ''' Updates file count in publication folder, existance of zip files and note in DataRow.
    ''' </summary>
    ''' <param name="downloadPath"></param>
    ''' <param name="publicationFolderRow"></param>
    ''' <remarks></remarks>
    Private Sub UpdateFileSystemInformation(ByVal downloadPath As String, ByVal publicationFolderRow As eropDataSet.EROPLogRow)
      Dim isZipFile As Byte
      Dim fileCount As Integer
      Dim folderPath As System.Text.StringBuilder


      folderPath = New System.Text.StringBuilder()

      folderPath.Append(downloadPath)
      folderPath.Append(System.IO.Path.DirectorySeparatorChar)
      folderPath.Append(publicationFolderRow.PublicationId)

      isZipFile = 0
      fileCount = System.IO.Directory.GetFiles(folderPath.ToString(), "*.pdf").Length
      If fileCount < 1 Then
        fileCount = System.IO.Directory.GetFiles(folderPath.ToString(), "*.zip").Length
        isZipFile = 1
      End If

      publicationFolderRow.FileCount = fileCount
      publicationFolderRow.IsZip = isZipFile
      If fileCount = 0 Then publicationFolderRow.Note = "Zero file exist under publication folder."

    End Sub

    ''' <summary>
    ''' Updates note column value if there is any differences between file count and zip file status between database 
    ''' and filesystem.
    ''' </summary>
    ''' <param name="downloadPath"></param>
    ''' <param name="updateRow"></param>
    ''' <remarks></remarks>
    Private Sub UpdateNoteForDifferences(ByVal downloadPath As String, ByVal updateRow As eropDataSet.EROPLogRow)
      Dim noteText As String
      Dim tempRow As eropDataSet.EROPLogRow


      tempRow = Me.Data.EROPLog.NewEROPLogRow()
      tempRow.BeginEdit()
      tempRow.PublicationId = updateRow.PublicationId
      tempRow.DownloadDt = updateRow.DownloadDt
      tempRow.EndEdit()
      UpdateFileSystemInformation(downloadPath, tempRow)

      If (tempRow.IsZip <> updateRow.IsZip) AndAlso (tempRow.FileCount <> updateRow.FileCount) Then
        noteText = String.Format("File count & zip file status differs between database and filesystem. " _
                                 + "File count in database: {0}, File count in filesystem: {1} " _
                                 + "Zip status in database: {2}, Zip status in filesystem: {3}" _
                                 , updateRow.FileCount, tempRow.FileCount, updateRow.IsZip, tempRow.IsZip)
      ElseIf (tempRow.IsZip <> updateRow.IsZip) Then
        noteText = String.Format("Status about having Zip file differs between database and filesystem. " _
                                 + "Zip status in database: {0}, Zip status in filesystem: {1}" _
                                 , updateRow.IsZip, tempRow.IsZip)
      ElseIf (tempRow.FileCount <> updateRow.FileCount) Then
        noteText = String.Format("File count differs between database and filesystem. " _
                                 + "File count in database: {0}, File count in filesystem: {1}" _
                                 , updateRow.FileCount, tempRow.FileCount)
      End If

      If noteText IsNot Nothing Then updateRow.Note += noteText
      updateRow.AcceptChanges()

      noteText = Nothing
    End Sub

    ''' <summary>
    ''' Validates all of the marked publication folders and update their status accordingly.
    ''' </summary>
    ''' <param name="unmarkInvalidPublications"></param>
    ''' <remarks></remarks>
    Public Sub ValidateMarkedPublications(ByVal unmarkInvalidPublications As Boolean, ByVal downloadPath As String)
      Dim vehicleId As Integer?
      Dim statusText, noteText As String
      Dim markedPublications As System.Data.EnumerableRowCollection(Of eropDataSet.EROPLogRow)


      markedPublications = From r In Me.Data.EROPLog _
                           Where r.IsIsMarkedNull() = False AndAlso r.IsMarked = True _
                           Select r

      If markedPublications.Count() = 0 Then
        markedPublications = Nothing
        Exit Sub
      End If

      RaiseEvent ValidatingMarkedPublications(Me, New System.EventArgs())

      For i As Integer = markedPublications.Count() - 1 To 0 Step -1

        RaiseEvent ValidatingPublication(Me, New EROPLogEventArgs(markedPublications(i + 1)))

        If IsValidPublicationId(markedPublications(i).PublicationId) = False Then
          markedPublications(i).Status = "Invalid Publication Id"
          markedPublications(i).Note = "No such publication Id exist in database."
          markedPublications(i).IsMarked = False
          RaiseEvent PublicationValidated(Me, New EROPLogEventArgs(markedPublications(i + 1)))
          Continue For
        End If

        vehicleId = GetAssociatedVehicleId(markedPublications(i).PublicationId, markedPublications(i).DownloadDt)

        If vehicleId.HasValue = False Then
          statusText = "Not Received"
          noteText = "Associated vehicle not found in database."
        ElseIf IsAssociatedVehicleIdValid(vehicleId.Value) = False Then
          Dim vehicleStatusText As String = GetVehicleStatusText(vehicleId.Value)
          statusText = "Invalid Vehicle Status"
          noteText = String.Format("Associated vehicle has invalid status. Vehicle status: {0}", vehicleStatusText)
          vehicleStatusText = Nothing
        ElseIf markedPublications(i).Status = "Processed" AndAlso markedPublications(i).Note.Trim().Length > 0 Then
          statusText = markedPublications(i).Status
          UpdateNoteForDifferences(downloadPath, markedPublications(i))
          noteText = markedPublications(i).Note
          'markedPublications(i).CreateDt = System.DateTime.Now
        Else
          statusText = "Pending"
          noteText = String.Empty
          UpdateFileSystemInformation(downloadPath, markedPublications(i))
        End If

        If vehicleId.HasValue Then markedPublications(i).VehicleId = vehicleId.Value
        markedPublications(i).Status = statusText
        markedPublications(i).Note = noteText
        markedPublications(i).IsMarked = (noteText.Trim().Length = 0)

        'Following line is added to avoid conisidering the row while synchronizing with database.
        'If statusText <> "Pending" Then markedPublications(i).AcceptChanges()

        RaiseEvent PublicationValidated(Me, New EROPLogEventArgs(markedPublications(i + 1)))
      Next i

      RaiseEvent MarkedPublicationsValidated(Me, New System.EventArgs())

      vehicleId = Nothing
      markedPublications = Nothing
    End Sub

    ''' <summary>
    ''' Synchronize rows into EROPLog table, where publications are validated and record for the the publication
    ''' and download date does not exist in EROPLog table.
    ''' </summary>
    ''' <remarks></remarks>
    ''' <exception cref="System.Data.SqlClient.SqlException">Database related error has occurred.</exception>
    ''' <exception cref="System.Exception">Unknown error has occurred.</exception>
    Public Sub SynchronizeEROPLogDataTable()
      Dim eroplogQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPLogRow)
      Dim tempAdapter As eropDataSetTableAdapters.EROPLogTableAdapter


      eroplogQuery = From r In Me.Data.EROPLog _
                     Where r.Status <> "Invalid Publication Id" AndAlso (r.RowState = DataRowState.Added OrElse r.RowState = DataRowState.Modified) _
                     Select r

      tempAdapter = New eropDataSetTableAdapters.EROPLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      Try
        tempAdapter.Update(eroplogQuery.ToArray())
      Catch ex As System.Data.SqlClient.SqlException
        Throw
      Catch ex As Exception
        Throw
      Finally
        eroplogQuery = Nothing
        tempAdapter.Dispose()
        tempAdapter = Nothing
      End Try

    End Sub

    ''' <summary>
    ''' Returns boolean value, indicating whether there is any publication marked for conversion or not.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsAnyPublicationMarked() As Boolean
      Dim isMarked As Boolean
      Dim publicationFolderQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPLogRow)


      publicationFolderQuery = From r In Me.Data.EROPLog _
                               Where r.IsIsMarkedNull() = False AndAlso r.IsMarked = True _
                               Select r

      isMarked = (publicationFolderQuery.Count() > 0)

      publicationFolderQuery = Nothing

      Return isMarked
    End Function

    ''' <summary>
    ''' Returns boolean value, indicating whether all of the marked publications are processed(validated) or not.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsAllMarkedPublicationProcessed() As Boolean
      Dim isValid As Boolean
      Dim publicationFolderQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPLogRow)


      publicationFolderQuery = From r In Me.Data.EROPLog _
                                 Where r.IsIsMarkedNull() = False AndAlso r.IsMarked = True AndAlso r.IsVehicleIdNull() = True _
                                 Select r

      isValid = (publicationFolderQuery.Count() = 0)

      publicationFolderQuery = Nothing

      Return isValid
    End Function


#End Region


#Region " Step 2 related methods "


    ''' <summary>
    ''' Adds new row into EROPFileLog data table.
    ''' </summary>
    ''' <param name="eropLogId"></param>
    ''' <param name="fileName"></param>
    ''' <param name="noteText"></param>
    ''' <remarks></remarks>
    Protected Sub AddPublicationFileInformation(ByVal eropLogId As Integer, ByVal fileName As String, ByVal noteText As String)
      Dim tempRow As eropDataSet.EROPFileLogRow


      tempRow = Me.Data.EROPFileLog.NewEROPFileLogRow()

      tempRow.BeginEdit()
      tempRow.EROPLogId = eropLogId
      tempRow.FileName = fileName
      tempRow.CreateDt = System.DateTime.Now
      tempRow.Note = noteText
      tempRow.EndEdit()

      Me.Data.EROPFileLog.AddEROPFileLogRow(tempRow)

      tempRow = Nothing
    End Sub

    ''' <summary>
    ''' Gets list of PDF files in supplied directory and inserts information about each file into EROPFileLog data table.
    ''' </summary>
    ''' <param name="publicationFolderPath"></param>
    ''' <remarks></remarks>
    Private Sub AddorUpdateInformationAboutPublicationFiles(ByVal eropLogId As Integer, ByVal publicationFolderPath As String)
      Dim folderInfo As System.IO.DirectoryInfo
      Dim pdfFiles() As System.IO.FileInfo
      Dim fileQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPFileLogRow)


      folderInfo = New System.IO.DirectoryInfo(publicationFolderPath)
      pdfFiles = folderInfo.GetFiles("*.pdf", IO.SearchOption.TopDirectoryOnly)

      For i As Integer = 0 To pdfFiles.Length - 1
        RaiseEvent CrawlingFile(Me, New FileEventArgs(pdfFiles(i).Name, pdfFiles.Length, i + 1))

        fileQuery = From r In Me.Data.EROPFileLog _
                    Where r.EROPLogId = eropLogId AndAlso r.FileName = pdfFiles(i).Name _
                    Select r
        If fileQuery.Count() = 0 Then
          AddPublicationFileInformation(eropLogId, pdfFiles(i).Name, String.Empty)
        Else
          fileQuery(0).BeginEdit()
          fileQuery(0).CreateDt = System.DateTime.Now
          fileQuery(0).SetNoteNull()
          fileQuery(0).EndEdit()
        End If
        fileQuery = Nothing

        RaiseEvent CrawledFile(Me, New FileEventArgs(pdfFiles(i).Name, pdfFiles.Length, i + 1))
      Next

      System.Array.Clear(pdfFiles, 0, pdfFiles.Length)
      pdfFiles = Nothing
      folderInfo = Nothing
    End Sub

    ''' <summary>
    ''' Picks and and unzip all publication folders, one by one, marked for conversion and having IsZip set to 1.
    ''' </summary>
    ''' <param name="downloadFolderPath"></param>
    ''' <remarks></remarks>
    Public Sub UnzipMarkedPublications(ByVal downloadFolderPath As String)
      Dim zipFiles() As String
      Dim folderPath, unzipArgumentText As System.Text.StringBuilder
      Dim unzipQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPLogRow)
      Dim unzipProcess As System.Diagnostics.Process
      Dim unzipProcessInfo As System.Diagnostics.ProcessStartInfo


      folderPath = New System.Text.StringBuilder()
      unzipArgumentText = New System.Text.StringBuilder()
      unzipProcess = New System.Diagnostics.Process()
      unzipProcessInfo = New System.Diagnostics.ProcessStartInfo()

      unzipArgumentText.Append("""")
      unzipArgumentText.Append(WinZipInstallationPath)
      If unzipArgumentText.ToString().EndsWith(System.IO.Path.DirectorySeparatorChar) = False Then
        unzipArgumentText.Append(System.IO.Path.DirectorySeparatorChar)
      End If
      unzipArgumentText.Append("WZUNZIP.EXE")
      unzipArgumentText.Append("""")
      unzipProcessInfo.FileName = unzipArgumentText.ToString()
      unzipProcessInfo.CreateNoWindow = False
      unzipProcessInfo.ErrorDialog = False
      unzipProcessInfo.WindowStyle = ProcessWindowStyle.Hidden
      unzipArgumentText.Remove(0, unzipArgumentText.Length)

      unzipQuery = From r In Me.Data.EROPLog _
                   Where r.IsIsZipNull() = False AndAlso r.IsIsMarkedNull() = False AndAlso r.IsZip = 1 AndAlso r.IsMarked = True _
                   Select r

      RaiseEvent UnzippingAllMarkedPublications(Me, New UnzipEventArgs(downloadFolderPath, 0, unzipQuery.Count()))

      For i As Integer = 0 To unzipQuery.Count() - 1
        folderPath.Append(downloadFolderPath)
        folderPath.Append(System.IO.Path.DirectorySeparatorChar)
        folderPath.Append(unzipQuery(i).PublicationId)

        zipFiles = System.IO.Directory.GetFiles(folderPath.ToString(), "*.zip")
        folderPath.Insert(0, """", 1)
        folderPath.Append("""")

        RaiseEvent UnzippingMarkedPublication(Me, New UnzipEventArgs(downloadFolderPath, unzipQuery(i).PublicationId, zipFiles.Length))

        For j As Integer = 0 To zipFiles.Length - 1
          unzipArgumentText.Append(" -o ") 'For overwrite existing file. -o- for not to overwrite existing files.
          unzipArgumentText.Append("""")
          unzipArgumentText.Append(zipFiles(j))
          unzipArgumentText.Append("""")
          unzipArgumentText.Append(" *.pdf ")
          unzipArgumentText.Append(folderPath.ToString())

          RaiseEvent ExtractingZipFile(Me, New UnzipFileEventArgs(zipFiles(j), folderPath.ToString()))

          unzipProcessInfo.Arguments = unzipArgumentText.ToString()
          unzipProcess.StartInfo = unzipProcessInfo
          unzipProcess.Start()
          unzipProcess.WaitForExit()
          unzipArgumentText.Remove(0, unzipArgumentText.Length)

          RaiseEvent ZipFileExtracted(Me, New UnzipFileEventArgs(zipFiles(j), folderPath.ToString()))
        Next

        RaiseEvent MarkedPublicationUnzipped(Me, New UnzipEventArgs(downloadFolderPath, unzipQuery(i).PublicationId, zipFiles.Length))

        'AddInformationAboutPublicationFiles(unzipQuery(i).EROPLogId, folderPath.ToString())

        System.Array.Clear(zipFiles, 0, zipFiles.Length)
        folderPath.Remove(0, folderPath.Length)
      Next

      RaiseEvent AllMarkedPublicationsUnzipped(Me, New UnzipEventArgs(downloadFolderPath, 0, unzipQuery.Count()))

      folderPath.Remove(0, folderPath.Length)
      unzipArgumentText.Remove(0, unzipArgumentText.Length)
      zipFiles = Nothing
      unzipProcessInfo = Nothing
      unzipQuery = Nothing
      folderPath = Nothing
      unzipArgumentText = Nothing
    End Sub

    ''' <summary>
    ''' Loads EROPFileLog information for marked publications.
    ''' </summary>
    ''' <remarks></remarks>
    ''' <exception cref="System.Data.SqlClient.SqlException">Database related error has occurred.</exception>
    ''' <exception cref="System.Exception">Unknown error has occurred.</exception>
    Public Sub LoadEROPFileLogForMarkedPublications()
      Dim eropLogIdQuery As System.Collections.Generic.IEnumerable(Of Integer)
      Dim eropLogIdCSV As System.Text.StringBuilder
      Dim tempAdapter As eropDataSetTableAdapters.EROPFileLogTableAdapter


      eropLogIdQuery = From r In Me.Data.EROPLog _
                       Where r.IsIsMarkedNull() = False AndAlso r.IsMarked = True _
                       Select r.EROPLogId

      If eropLogIdQuery.Count() = 0 Then
        eropLogIdQuery = Nothing
        Exit Sub
      End If

      RaiseEvent LoadingEROPFileLogEntriesForMarkedPublications(Me, New System.EventArgs())

      eropLogIdCSV = New System.Text.StringBuilder()

      eropLogIdCSV.Append("(")
      For i As Integer = 0 To eropLogIdQuery.Count() - 1
        eropLogIdCSV.Append(eropLogIdQuery(i))
        If i < (eropLogIdQuery.Count() - 1) Then eropLogIdCSV.Append(", ")
      Next
      eropLogIdCSV.Append(")")

      tempAdapter = New eropDataSetTableAdapters.EROPFileLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      Try
        tempAdapter.FillByEROPLogId(Me.Data.EROPFileLog, eropLogIdCSV.ToString())
      Catch ex As System.Data.SqlClient.SqlException
        Throw
      Catch ex As System.Exception
        Throw
      Finally
        tempAdapter.Dispose()
        tempAdapter = Nothing
      End Try

      RaiseEvent EROPFileLogEntriesForMarkedPublicationsLoaded(Me, New System.EventArgs())

      eropLogIdCSV.Remove(0, eropLogIdCSV.Length)
      eropLogIdCSV = Nothing
    End Sub

    ''' <summary>
    ''' Moves through all subfolders(publication folders) and inserts record for each of the PDF file found under the publication folder.
    ''' </summary>
    ''' <param name="downloadFolderPath"></param>
    ''' <remarks></remarks>
    Public Sub CrawlToAddDownloadedPublicationFileInformation(ByVal downloadFolderPath As String)
      Dim folderPath As System.Text.StringBuilder
      Dim pubQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPLogRow)


      folderPath = New System.Text.StringBuilder()

      pubQuery = From r In Me.Data.EROPLog _
                 Where r.IsIsMarkedNull() = False AndAlso r.IsMarked = True _
                 Select r

      RaiseEvent CrawlingMarkedPublicationFolders(Me, New FileSystemEventArgs(downloadFolderPath))

      For i As Integer = 0 To pubQuery.Count() - 1
        folderPath.Append(downloadFolderPath)
        folderPath.Append(System.IO.Path.DirectorySeparatorChar)
        folderPath.Append(pubQuery(i).PublicationId)

        RaiseEvent CrawlingMarkedPublicationFolder(Me, New DirectoryEventArgs(folderPath.ToString(), pubQuery.Count(), i + 1))

        AddorUpdateInformationAboutPublicationFiles(pubQuery(i).EROPLogId, folderPath.ToString())

        RaiseEvent CrawledMarkedPublicationFolder(Me, New DirectoryEventArgs(folderPath.ToString(), pubQuery.Count(), i + 1))

        folderPath.Remove(0, folderPath.Length)
      Next

      RaiseEvent CrawledMarkedPublicationFolders(Me, New FileSystemEventArgs(downloadFolderPath))

      folderPath = Nothing
      pubQuery = Nothing
    End Sub

    ''' <summary>
    ''' Returns previous download date for supplied publication. If there is no record of previous download, null(Nothing) is returned.
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <param name="publicationId"></param>
    ''' <param name="downloadDt"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPreviousDownloadDate(ByVal fileName As String, ByVal publicationId As Integer, ByVal downloadDt As DateTime) As DateTime?
      Dim tempAdapter As eropDataSetTableAdapters.EROPFileLogTableAdapter


      tempAdapter = New eropDataSetTableAdapters.EROPFileLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

      tempAdapter.GetPreviousDownloadDt(fileName, publicationId, downloadDt)

      tempAdapter.Dispose()
      tempAdapter = Nothing
    End Function

    ''' <summary>
    ''' Checks current downloaded file for validity and compares it with previously published downloaded file.
    ''' </summary>
    ''' <param name="downloadPath"></param>
    ''' <param name="publicationId"></param>
    ''' <param name="downloadDt"></param>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' If current downloaded file size is less than 1 KB then the file is considered as invalid file.
    ''' If both the files are having same size and creation date and time then assumes both the file as same. Hence the file is considered as invalid.
    ''' </remarks>
    Private Function IsPDFFileValid(ByVal downloadPath As String, ByVal publicationId As Integer, ByVal downloadDt As DateTime, ByVal filePath As String) As Boolean
      Dim isValidFile As Boolean
      Dim previousdownloadDt As DateTime?
      Dim fileName, EROPRootFolderPath As String
      Dim previousDownloadedFilePath As System.Text.StringBuilder
      Dim currentDownloadFileInfo, previousDownloadFileInfo As System.IO.FileInfo


      currentDownloadFileInfo = New System.IO.FileInfo(filePath)

      'File size should be greater than 1 KB (1024 Bytes). 
      If currentDownloadFileInfo.Length < 1024 Then
        currentDownloadFileInfo = Nothing
        Return False
      End If

      fileName = System.IO.Path.GetFileName(filePath)
      previousdownloadDt = GetPreviousDownloadDate(fileName, publicationId, downloadDt)
      'There is no previous download record available.
      If previousdownloadDt.HasValue = False Then
        fileName = Nothing
        previousdownloadDt = Nothing
        currentDownloadFileInfo = Nothing
        Return True
      End If

      EROPRootFolderPath = System.IO.Path.GetDirectoryName(downloadPath)

      previousDownloadedFilePath = New System.Text.StringBuilder()
      previousDownloadedFilePath.Append(EROPRootFolderPath)
      If EROPRootFolderPath.EndsWith(System.IO.Path.DirectorySeparatorChar) = False Then previousDownloadedFilePath.Append(System.IO.Path.DirectorySeparatorChar)
      previousDownloadedFilePath.Append(previousdownloadDt.Value.ToString("yyyyMMdd"))
      previousDownloadedFilePath.Append(System.IO.Path.DirectorySeparatorChar)
      previousDownloadedFilePath.Append(fileName)

      previousDownloadFileInfo = New System.IO.FileInfo(previousDownloadedFilePath.ToString())

      If currentDownloadFileInfo.CreationTimeUtc = previousDownloadFileInfo.CreationTimeUtc _
        AndAlso currentDownloadFileInfo.Length = previousDownloadFileInfo.Length _
      Then
        isValidFile = True
      Else
        isValidFile = False
      End If

      fileName = Nothing
      previousdownloadDt = Nothing
      EROPRootFolderPath = Nothing
      currentDownloadFileInfo = Nothing
      currentDownloadFileInfo = Nothing
      previousDownloadFileInfo = Nothing
      previousDownloadedFilePath = Nothing

      Return isValidFile

    End Function

    ''' <summary>
    ''' Validates all PDF files stored under supplied file system path.
    ''' </summary>
    ''' <param name="downloadPath"></param>
    ''' <remarks></remarks>
    Public Sub ValidatePDFFiles(ByVal downloadPath As String)
      Dim counter As Integer
      Dim publicationQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPLogRow)
      Dim fileQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPFileLogRow)
      Dim publicationFolderPath, filePath As System.Text.StringBuilder


      publicationQuery = From r In Me.Data.EROPLog _
                         Where r.IsIsMarkedNull() = False And r.IsMarked = True _
                         Select r
      If publicationQuery.Count() = 0 Then Exit Sub

      RaiseEvent ValidatingPDFFileForMarkedPublications(Me, New FileSystemEventArgs(downloadPath))

      publicationFolderPath = New System.Text.StringBuilder()
      filePath = New System.Text.StringBuilder()

      For i As Integer = 0 To publicationQuery.Count() - 1
        fileQuery = From f In Me.Data.EROPFileLog _
                    Where f.EROPLogId = publicationQuery(i).EROPLogId _
                    Select f
        If fileQuery.Count() = 0 Then Continue For

        publicationFolderPath.Remove(0, publicationFolderPath.Length)
        publicationFolderPath.Append(downloadPath)
        publicationFolderPath.Append("\")
        publicationFolderPath.Append(publicationQuery(i).PublicationId)
        counter = -1

        RaiseEvent ValidatingMarkedPublicationFiles(Me, New DirectoryEventArgs(publicationFolderPath.ToString(), publicationQuery.Count(), i + 1))

        For j As Integer = 0 To fileQuery.Count() - 1
          filePath.Remove(0, filePath.Length)
          filePath.Append(publicationFolderPath.ToString())
          filePath.Append("\")
          filePath.Append(fileQuery(j).FileName)

          RaiseEvent ValidatingFile(Me, New FileEventArgs(fileQuery(j).FileName, fileQuery.Count(), j + 1))

          If IsPDFFileValid(downloadPath, publicationQuery(i).PublicationId, publicationQuery(i).DownloadDt, filePath.ToString()) = False Then
            counter = j
            RaiseEvent InvalidFile(Me, New FileEventArgs(filePath.ToString(), fileQuery.Count(), j + 1))
            Exit For
          End If

          RaiseEvent FileValidated(Me, New FileEventArgs(fileQuery(j).FileName, fileQuery.Count(), j + 1))

          fileQuery(j).ValidateDt = System.DateTime.Now
          fileQuery(j).SetNoteNull()
        Next j

        If counter > -1 AndAlso counter < fileQuery.Count() Then
          For j As Integer = 0 To fileQuery.Count() - 1
            fileQuery(j).ValidateDt = System.DateTime.Now
            fileQuery(j).Note = String.Format("Invalid file: {0}", fileQuery(counter).FileName)
          Next
        End If

        RaiseEvent MarkedPublicationFilesValidated(Me, New DirectoryEventArgs(publicationFolderPath.ToString(), publicationQuery.Count(), i + 1))

        fileQuery = Nothing
      Next i

      filePath.Remove(0, filePath.Length)
      publicationFolderPath.Remove(0, publicationFolderPath.Length)

      RaiseEvent PDFFileForMarkedPublicationsValidated(Me, New FileSystemEventArgs(downloadPath))

      fileQuery = Nothing
      publicationQuery = Nothing
      filePath = Nothing
      publicationFolderPath = Nothing
    End Sub

    ''' <summary>
    ''' Synchronize EROPFileLog data table with database.
    ''' </summary>
    ''' <remarks></remarks>
    ''' <exception cref="System.Data.SqlClient.SqlException">Database related error.</exception>
    ''' <exception cref="System.Exception">Unknown error.</exception>
    Public Sub SynchronizeEROPFileLogDataTable()
      Dim tempAdapter As eropDataSetTableAdapters.EROPFileLogTableAdapter


      RaiseEvent SynchronizingEROPFileLogEntriesForMarkedPublications(Me, New System.EventArgs)

      tempAdapter = New eropDataSetTableAdapters.EROPFileLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      Try
        tempAdapter.Update(Me.Data.EROPFileLog)
      Catch EX As System.Data.SqlClient.SqlException
        Throw
      Catch ex As Exception
        Throw
      Finally
        tempAdapter.Dispose()
        tempAdapter = Nothing
      End Try

      RaiseEvent EROPFileLogEntriesForMarkedPublicationsSynchronized(Me, New System.EventArgs)

    End Sub

    ''' <summary>
    ''' Returns boolean value, indicating whether all files of at least one publication is valid or not.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsAnyPublicationFilesValid() As Boolean
      Dim isValid As Boolean
      Dim fileQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPFileLogRow)


      fileQuery = From r In Me.Data.EROPFileLog _
                  Where r.IsNoteNull() OrElse r.Note.Length = 0 _
                  Select r

      isValid = (fileQuery.Count() > 0)

      fileQuery = Nothing

      Return isValid
    End Function


#End Region


#Region " Step 3 related methods "


    ''' <summary>
    ''' Generates EROPFileLogId CSV string and based on that loads EROPFilePageLog information from database.
    ''' </summary>
    ''' <remarks></remarks>
    ''' <exception cref="System.Data.SqlClient.SqlException">Database related error.</exception>
    ''' <exception cref="System.Exception">Unknown error.</exception>
    Public Sub LoadEROPFilePageLogForMarkedPublications()
      Dim eropFileLogIdCSV As System.Text.StringBuilder
      Dim fileQuery As System.Collections.Generic.IEnumerable(Of Integer)


      fileQuery = From r In Me.Data.EROPFileLog _
                  Select r.EROPFileLogId

      If fileQuery.Count() = 0 Then
        fileQuery = Nothing
        Exit Sub
      End If

      eropFileLogIdCSV = New System.Text.StringBuilder()
      eropFileLogIdCSV.Append("(")
      For i As Integer = 0 To fileQuery.Count() - 1
        eropFileLogIdCSV.Append(fileQuery(i))
        If i < (fileQuery.Count() - 1) Then eropFileLogIdCSV.Append(", ")
      Next
      eropFileLogIdCSV.Append(")")

      Dim tempAdapter As eropDataSetTableAdapters.EROPFilePageLogTableAdapter

      tempAdapter = New eropDataSetTableAdapters.EROPFilePageLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      Try
        tempAdapter.FillByEROPFileLogId(Me.Data.EROPFilePageLog, eropFileLogIdCSV.ToString())
      Catch ex As System.Data.SqlClient.SqlException
        Throw
      Catch ex As Exception
        Throw
      Finally
        tempAdapter.Dispose()
        tempAdapter = Nothing
      End Try

      eropFileLogIdCSV.Remove(0, eropFileLogIdCSV.Length)
      eropFileLogIdCSV = Nothing
    End Sub

    ''' <summary>
    ''' Add(if the record not found) or updates(if the record found) information about image that is converted from PDF file's pages.
    ''' </summary>
    ''' <param name="eropFileLogId"></param>
    ''' <param name="pageNumber"></param>
    ''' <remarks></remarks>
    Private Sub AddOrUpdatePublicationFilePageInformation(ByVal eropFileLogId As Integer, ByVal pageNumber As Integer, ByVal imageWidth As Integer, ByVal imageHeight As Integer, ByVal isDoubleTruck As Boolean?, ByVal noteText As String)
      Dim tempRow As eropDataSet.EROPFilePageLogRow
      Dim imageQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPFilePageLogRow)


      imageQuery = From r In Me.Data.EROPFilePageLog _
                   Where r.EROPFileLogId = eropFileLogId AndAlso r.Page = pageNumber

      If imageQuery.Count() = 0 Then
        tempRow = Me.Data.EROPFilePageLog.NewEROPFilePageLogRow()
        tempRow.BeginEdit()
        tempRow.EROPFileLogId = eropFileLogId
        tempRow.Page = pageNumber
        If isDoubleTruck.HasValue = False Then
          tempRow.SetIsDoubleTruckNull()
        ElseIf isDoubleTruck.Value Then
          tempRow.IsDoubleTruck = 1
        Else
          tempRow.IsDoubleTruck = 0
        End If
        tempRow.ImageName = pageNumber.ToString("000")
        tempRow.Width = imageWidth
        tempRow.Height = imageHeight
        tempRow.ConvertDt = System.DateTime.Now
        If noteText Is Nothing Then
          tempRow.SetNoteNull()
        Else
          tempRow.Note = noteText
        End If
        tempRow.EndEdit()
        Me.Data.EROPFilePageLog.AddEROPFilePageLogRow(tempRow)
        tempRow = Nothing
      Else
        imageQuery(0).BeginEdit()
        If isDoubleTruck.HasValue = False Then
          imageQuery(0).SetIsDoubleTruckNull()
        ElseIf isDoubleTruck.Value Then
          imageQuery(0).IsDoubleTruck = 1
        Else
          imageQuery(0).IsDoubleTruck = 0
        End If
        imageQuery(0).Width = imageWidth
        imageQuery(0).Height = imageHeight
        imageQuery(0).ConvertDt = System.DateTime.Now()
        If noteText Is Nothing Then
          imageQuery(0).SetNoteNull()
        Else
          imageQuery(0).Note = noteText
        End If
        imageQuery(0).EndEdit()
      End If

    End Sub

    ''' <summary>
    ''' Rollback all changes made while creating image files from PDF file pages for supplied EROPLogId.
    ''' </summary>
    ''' <param name="eropLogId"></param>
    ''' <remarks></remarks>
    Private Sub PDFToJpgErrorCleanup(ByVal eropLogId As Integer)
      Dim imageQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPFilePageLogRow)


      imageQuery = From r In Me.Data.EROPFilePageLog _
                   Where r.EROPLogId = eropLogId AndAlso (r.RowState = DataRowState.Added OrElse r.RowState = DataRowState.Modified)

      If imageQuery.Count() > 0 Then imageQuery(0).Table.RejectChanges()

    End Sub

    '''' <summary>
    '''' Converts each valid PDF file pages into JPG images. If auto split double truck Ads flag is 
    '''' true, splits double truck images into two.
    '''' </summary>
    '''' <param name="downloadPath"></param>
    '''' <remarks></remarks>
    'Public Sub ConvertPDFFilePagesToJpg(ByVal downloadPath As String)
    '  Dim pageCount, imageWidth, imageHeight As Integer
    '  Dim publicationFolderPath, filePath, imagePath As System.Text.StringBuilder
    '  Dim convertedImage As System.Drawing.Image
    '  Dim publicationQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPLogRow)
    '  Dim fileQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPFileLogRow)
    '  Dim Converter As ceTe.DynamicPDF.Rasterizer.PdfRasterizer
    '  Dim pdfFile As ceTe.DynamicPDF.Rasterizer.InputPdf
    '  Dim imageFormat As ceTe.DynamicPDF.Rasterizer.JpegImageFormat
    '  Dim imageDPI As ceTe.DynamicPDF.Rasterizer.DpiImageSize
    '  Dim cea As ConversionEventArgs, pcea As PublicationConversionEventArgs, fcea As FileConversionEventArgs, pgcea As PageConversionEventArgs


    '  imageFormat = New ceTe.DynamicPDF.Rasterizer.JpegImageFormat(80)
    '  imageDPI = New ceTe.DynamicPDF.Rasterizer.DpiImageSize(300, 300)
    '  publicationFolderPath = New System.Text.StringBuilder()
    '  filePath = New System.Text.StringBuilder()
    '  imagePath = New System.Text.StringBuilder()
    '  cea = New ConversionEventArgs()
    '  pcea = New PublicationConversionEventArgs()
    '  fcea = New FileConversionEventArgs()
    '  pgcea = New PageConversionEventArgs()

    '  publicationQuery = From r In Me.Data.EROPLog _
    '                     Where r.IsIsMarkedNull() = False AndAlso r.IsMarked = True _
    '                     Select r

    '  cea.TotalPublications = publicationQuery.Count()
    '  RaiseEvent ConvertingPublicationsToImages(Me, cea)

    '  For i As Integer = 0 To publicationQuery.Count() - 1
    '    pageCount = 0
    '    publicationFolderPath.Append(downloadPath)
    '    If publicationFolderPath.ToString().EndsWith(System.IO.Path.DirectorySeparatorChar) = False Then
    '      publicationFolderPath.Append(System.IO.Path.DirectorySeparatorChar)
    '    End If
    '    publicationFolderPath.Append(publicationQuery(i).PublicationId)

    '    fileQuery = From r In Me.Data.EROPFileLog _
    '                Where r.EROPLogId = publicationQuery(i).EROPLogId AndAlso (r.IsNoteNull() OrElse r.Note.Length = 0)

    '    pcea.TotalPublications = cea.TotalPublications : pcea.CurrentPublicationIndex = i + 1 : pcea.PublicationFolderPath = publicationFolderPath.ToString() : pcea.TotalFiles = fileQuery.Count()
    '    RaiseEvent ConvertingPDFFilesToImages(Me, pcea)

    '    For j As Integer = 0 To fileQuery.Count() - 1
    '      filePath.Append(publicationFolderPath.ToString())
    '      If filePath.ToString().EndsWith(System.IO.Path.DirectorySeparatorChar) = False Then filePath.Append(System.IO.Path.DirectorySeparatorChar)
    '      filePath.Append(fileQuery(j).FileName)
    '      pdfFile = New ceTe.DynamicPDF.Rasterizer.InputPdf(filePath.ToString())
    '      Converter = New ceTe.DynamicPDF.Rasterizer.PdfRasterizer(pdfFile)

    '      fcea.PCEA = pcea : fcea.CurrentFileIndex = j + 1 : fcea.FilePath = filePath.ToString() : fcea.TotalPages = Converter.Pages.Count
    '      RaiseEvent ConvertingPDFFilePagesToImages(Me, fcea)

    '      'Convert enqueued file(s) pages to JPG images.
    '      For pg As Integer = 0 To Converter.Pages.Count - 1
    '        pageCount += 1

    '        pgcea.PCEA = pcea : pgcea.CurrentFileIndex = fcea.CurrentFileIndex : pgcea.FilePath = fcea.FilePath : pgcea.TotalPages = fcea.TotalPages : pgcea.PageNumber = pg + 1 : pgcea.PublicationPageNumber = pageCount
    '        RaiseEvent ConvertingPDFFilePageToImage(Me, pgcea)

    '        imagePath.Append(publicationFolderPath.ToString())
    '        If imagePath.ToString().EndsWith(System.IO.Path.DirectorySeparatorChar) = False Then imagePath.Append(System.IO.Path.DirectorySeparatorChar)
    '        imagePath.Append(pageCount.ToString("000\.jpg"))

    '        If System.IO.File.Exists(imagePath.ToString()) Then System.IO.File.Delete(imagePath.ToString())
    '        Try
    '          Converter.Pages(pg).Draw(imagePath.ToString(), imageFormat, imageDPI)
    '        Catch ex As ceTe.DynamicPDF.Rasterizer.PdfRasterizerException
    '          Trace.TraceError(String.Format("ScanTrackerEROP.ConvertPDFFilePagesToJpg(): Rasterizer error. Message={0}", ex.Message), New Object() {"PublicationId=", publicationQuery(i).PublicationId, "EROPLogId=", publicationQuery(i).EROPLogId, "EROPFileLogId=", fileQuery(j).EROPFileLogId, "FileName=", fileQuery(j).FileName, "Page=", pg, "ImagePath=", imagePath.ToString(), "Source=", ex.Source})
    '          j = fileQuery.Count() : PDFToJpgErrorCleanup(publicationQuery(i).EROPLogId) : Exit For
    '        Catch ex As Exception
    '          Trace.TraceError(String.Format("ScanTrackerEROP.ConvertPDFFilePagesToJpg(): Unknown error. Message={0}", ex.Message), New Object() {"PublicationId=", publicationQuery(i).PublicationId, "EROPLogId=", publicationQuery(i).EROPLogId, "EROPFileLogId=", fileQuery(j).EROPFileLogId, "FileName=", fileQuery(j).FileName, "Page=", pg, "ImagePath=", imagePath.ToString(), "Source=", ex.Source})
    '          j = fileQuery.Count() : PDFToJpgErrorCleanup(publicationQuery(i).EROPLogId) : Exit For
    '        End Try
    '        convertedImage = System.Drawing.Bitmap.FromFile(imagePath.ToString())
    '        imageWidth = convertedImage.Width
    '        imageHeight = convertedImage.Height
    '        convertedImage.Dispose()
    '        convertedImage = Nothing

    '        RaiseEvent ConvertedPDFFilePageToImage(Me, pgcea)

    '        AddOrUpdatePublicationFilePageInformation(fileQuery(j).EROPFileLogId, pageCount, imageWidth, imageHeight, Nothing, Nothing)

    '        imagePath.Remove(0, imagePath.Length)
    '      Next pg 'End of loop for pages.

    '      RaiseEvent ConvertedPDFFilePagesToImages(Me, fcea)

    '      filePath.Remove(0, filePath.Length)
    '      pdfFile.Dispose()
    '      pdfFile = Nothing
    '      Converter = Nothing
    '    Next j  'End of loop for files.

    '    RaiseEvent ConvertedPDFFilesToImages(Me, pcea)

    '    publicationFolderPath.Remove(0, publicationFolderPath.Length)
    '    fileQuery = Nothing
    '  Next i  'End of loop for publications.

    '  RaiseEvent ConvertedPublicationsToImages(Me, cea)


    '  cea = Nothing
    '  pcea = Nothing
    '  fcea = Nothing
    '  pgcea = Nothing
    '  imagePath = Nothing
    '  filePath = Nothing
    '  publicationFolderPath = Nothing
    '  publicationQuery = Nothing
    '  imageFormat = Nothing
    '  imageDPI = Nothing
    'End Sub

    Public Sub ConvertPDFFilePagesToJpg(ByVal downloadPath As String)
      Dim pageCount, imageWidth, imageHeight, pageSlotSize, pageSlotCount, startPageNumber As Integer
      Dim publicationFolderPath, filePath, imagePath As System.Text.StringBuilder
      Dim convertedImage As System.Drawing.Image
      Dim publicationQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPLogRow)
      Dim fileQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPFileLogRow)
      Dim Converter As ceTe.DynamicPDF.Rasterizer.PdfRasterizer
      Dim pdfFile As ceTe.DynamicPDF.Rasterizer.InputPdf
      Dim imageFormat As ceTe.DynamicPDF.Rasterizer.JpegImageFormat
      Dim imageDPI As ceTe.DynamicPDF.Rasterizer.DpiImageSize
      Dim cea As ConversionEventArgs, pcea As PublicationConversionEventArgs, fcea As FileConversionEventArgs, pgcea As PageConversionEventArgs


      imageFormat = New ceTe.DynamicPDF.Rasterizer.JpegImageFormat(80)
      imageDPI = New ceTe.DynamicPDF.Rasterizer.DpiImageSize(300, 300)
      publicationFolderPath = New System.Text.StringBuilder()
      filePath = New System.Text.StringBuilder()
      imagePath = New System.Text.StringBuilder()
      cea = New ConversionEventArgs()
      pcea = New PublicationConversionEventArgs()
      fcea = New FileConversionEventArgs()
      pgcea = New PageConversionEventArgs()

      publicationQuery = From r In Me.Data.EROPLog _
                         Where r.IsIsMarkedNull() = False AndAlso r.IsMarked = True _
                         Select r

      cea.TotalPublications = publicationQuery.Count()
      RaiseEvent ConvertingPublicationsToImages(Me, cea)

      For i As Integer = 0 To publicationQuery.Count() - 1
        pageCount = 0
        publicationFolderPath.Append(downloadPath)
        If publicationFolderPath.ToString().EndsWith(System.IO.Path.DirectorySeparatorChar) = False Then
          publicationFolderPath.Append(System.IO.Path.DirectorySeparatorChar)
        End If
        publicationFolderPath.Append(publicationQuery(i).PublicationId)

        fileQuery = From r In Me.Data.EROPFileLog _
                    Where r.EROPLogId = publicationQuery(i).EROPLogId AndAlso (r.IsNoteNull() OrElse r.Note.Length = 0)

        pcea.TotalPublications = cea.TotalPublications : pcea.CurrentPublicationIndex = i + 1 : pcea.PublicationFolderPath = publicationFolderPath.ToString() : pcea.TotalFiles = fileQuery.Count()
        RaiseEvent ConvertingPDFFilesToImages(Me, pcea)

        For j As Integer = 0 To fileQuery.Count() - 1
          filePath.Append(publicationFolderPath.ToString())
          If filePath.ToString().EndsWith(System.IO.Path.DirectorySeparatorChar) = False Then filePath.Append(System.IO.Path.DirectorySeparatorChar)
          filePath.Append(fileQuery(j).FileName)
          pdfFile = New ceTe.DynamicPDF.Rasterizer.InputPdf(filePath.ToString())
          'Converter = New ceTe.DynamicPDF.Rasterizer.PdfRasterizer(pdfFile)

          fcea.PCEA = pcea : fcea.CurrentFileIndex = j + 1 : fcea.FilePath = filePath.ToString() : fcea.TotalPages = pdfFile.Pages.Count
          RaiseEvent ConvertingPDFFilePagesToImages(Me, fcea)

          pageSlotSize = 5
          pageSlotCount = CType(System.Math.Ceiling(pdfFile.Pages.Count / pageSlotSize), Integer)

          For x As Integer = 0 To pageSlotCount - 1
            startPageNumber = (pageSlotSize * x) + 1
            If (startPageNumber + pageSlotSize) > pdfFile.Pages.Count Then
              pageSlotSize = pdfFile.Pages.Count - startPageNumber + 1
            End If
            Converter = New ceTe.DynamicPDF.Rasterizer.PdfRasterizer(pdfFile, startPageNumber, pageSlotSize)

            'Convert enqueued file(s) pages to JPG images.
            For pg As Integer = 0 To Converter.Pages.Count - 1
              pageCount += 1

              pgcea.PCEA = pcea : pgcea.CurrentFileIndex = fcea.CurrentFileIndex : pgcea.FilePath = fcea.FilePath : pgcea.TotalPages = fcea.TotalPages : pgcea.PageNumber = startPageNumber + pg : pgcea.PublicationPageNumber = pageCount
              RaiseEvent ConvertingPDFFilePageToImage(Me, pgcea)

              imagePath.Append(publicationFolderPath.ToString())
              If imagePath.ToString().EndsWith(System.IO.Path.DirectorySeparatorChar) = False Then imagePath.Append(System.IO.Path.DirectorySeparatorChar)
              imagePath.Append(pageCount.ToString("000\.jpg"))

              If System.IO.File.Exists(imagePath.ToString()) Then System.IO.File.Delete(imagePath.ToString())
              Try
                Converter.Pages(pg).Draw(imagePath.ToString(), imageFormat, imageDPI)
              Catch ex As ceTe.DynamicPDF.Rasterizer.PdfRasterizerException
                Trace.TraceError(String.Format("ScanTrackerEROP.ConvertPDFFilePagesToJpg(): Rasterizer error. Message={0}", ex.Message), New Object() {"PublicationId=", publicationQuery(i).PublicationId, "EROPLogId=", publicationQuery(i).EROPLogId, "EROPFileLogId=", fileQuery(j).EROPFileLogId, "FileName=", fileQuery(j).FileName, "Page=", pg, "ImagePath=", imagePath.ToString(), "Source=", ex.Source})
                j = fileQuery.Count() : x = pageSlotCount : PDFToJpgErrorCleanup(publicationQuery(i).EROPLogId) : Exit For
              Catch ex As Exception
                Trace.TraceError(String.Format("ScanTrackerEROP.ConvertPDFFilePagesToJpg(): Unknown error. Message={0}", ex.Message), New Object() {"PublicationId=", publicationQuery(i).PublicationId, "EROPLogId=", publicationQuery(i).EROPLogId, "EROPFileLogId=", fileQuery(j).EROPFileLogId, "FileName=", fileQuery(j).FileName, "Page=", pg, "ImagePath=", imagePath.ToString(), "Source=", ex.Source})
                j = fileQuery.Count() : x = pageSlotCount : PDFToJpgErrorCleanup(publicationQuery(i).EROPLogId) : Exit For
              End Try
              convertedImage = System.Drawing.Bitmap.FromFile(imagePath.ToString())
              imageWidth = convertedImage.Width
              imageHeight = convertedImage.Height
              convertedImage.Dispose()
              convertedImage = Nothing

              RaiseEvent ConvertedPDFFilePageToImage(Me, pgcea)

              AddOrUpdatePublicationFilePageInformation(fileQuery(j).EROPFileLogId, pageCount, imageWidth, imageHeight, Nothing, Nothing)

              imagePath.Remove(0, imagePath.Length)
            Next pg 'End of loop for pages.

            Converter = Nothing
          Next x

          RaiseEvent ConvertedPDFFilePagesToImages(Me, fcea)

          filePath.Remove(0, filePath.Length)
          pdfFile.Dispose()
          pdfFile = Nothing
          Converter = Nothing
        Next j  'End of loop for files.

        RaiseEvent ConvertedPDFFilesToImages(Me, pcea)

        publicationFolderPath.Remove(0, publicationFolderPath.Length)
        fileQuery = Nothing
      Next i  'End of loop for publications.

      RaiseEvent ConvertedPublicationsToImages(Me, cea)


      cea = Nothing
      pcea = Nothing
      fcea = Nothing
      pgcea = Nothing
      imagePath = Nothing
      filePath = Nothing
      publicationFolderPath = Nothing
      publicationQuery = Nothing
      imageFormat = Nothing
      imageDPI = Nothing
    End Sub

    ''' <summary>
    ''' Update source image's width and insert row for the split image. Updates page image name for 
    ''' all page(s) from split image onwards to accomodate the split image and update page image 
    ''' name in file-system accordingly.
    ''' </summary>
    ''' <param name="sourceRow"></param>
    ''' <param name="sourceImageWidth"></param>
    ''' <param name="publicationFolderPath"></param>
    ''' <param name="splitImageNumber"></param>
    ''' <remarks></remarks>
    Private Sub UpdateEROPFilePageLogForSplitImage(ByVal sourceRow As eropDataSet.EROPFilePageLogRow, ByVal sourceImageWidth As Integer, ByVal publicationFolderPath As String, ByVal splitImageNumber As Integer)
      Dim splitPageNumber, pageImageNumber As Integer
      Dim sourceImagePath, destinationImagePath As System.Text.StringBuilder
      Dim tempRow As eropDataSet.EROPFilePageLogRow
      Dim pageRenameQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPFilePageLogRow)


      sourceImagePath = New System.Text.StringBuilder()
      destinationImagePath = New System.Text.StringBuilder()

      'Update source page image information.
      sourceRow.BeginEdit()
      sourceRow.IsDoubleTruck = 1
      sourceRow.Width = sourceImageWidth
      sourceRow.EndEdit()

      splitPageNumber = sourceRow.Page + 1

      'Update page image name in data table & file-system for pages after splitImagePageNumber.
      pageRenameQuery = From r In Me.Data.EROPFilePageLog _
                        Where r.Page >= splitPageNumber _
                        Order By r.Market, r.Publication, r.Page, r.ImageName _
                        Select r
      For i As Integer = (pageRenameQuery.Count() - 1) To 0 Step -1
        pageImageNumber = CType(pageRenameQuery(i).ImageName, Integer)
        pageImageNumber += 1

        destinationImagePath.Append(publicationFolderPath)
        If destinationImagePath.ToString().EndsWith(System.IO.Path.DirectorySeparatorChar) = False Then destinationImagePath.Append(System.IO.Path.DirectorySeparatorChar)
        destinationImagePath.Append(pageImageNumber.ToString("000\.jpg"))
        If System.IO.File.Exists(destinationImagePath.ToString()) Then
          Debug.Print(String.Format("Removing file {0}", destinationImagePath.ToString()))
          System.IO.File.Delete(destinationImagePath.ToString())
        End If

        sourceImagePath.Append(publicationFolderPath)
        If sourceImagePath.ToString().EndsWith(System.IO.Path.DirectorySeparatorChar) = False Then sourceImagePath.Append(System.IO.Path.DirectorySeparatorChar)
        sourceImagePath.Append(pageRenameQuery(i).ImageName)
        sourceImagePath.Append(".jpg")

        Debug.Print(String.Format("Moving file {0} to {1}", sourceImagePath.ToString(), destinationImagePath.ToString()))
        System.IO.File.Move(sourceImagePath.ToString(), destinationImagePath.ToString())
        pageRenameQuery(i).BeginEdit()
        pageRenameQuery(i).ImageName = pageImageNumber.ToString("000")
        pageRenameQuery(i).EndEdit()

        sourceImagePath.Remove(0, sourceImagePath.Length)
        destinationImagePath.Remove(0, destinationImagePath.Length)
      Next

      'Add split image information in data table.      
      tempRow = Me.Data.EROPFilePageLog.NewEROPFilePageLogRow()
      tempRow.BeginEdit()
      tempRow.EROPLogId = sourceRow.EROPLogId
      tempRow.Market = sourceRow.Market
      tempRow.Publication = sourceRow.Publication
      tempRow.EROPFileLogId = sourceRow.EROPFileLogId
      tempRow.FileName = sourceRow.FileName
      tempRow.Page = sourceRow.Page
      tempRow.IsDoubleTruck = 1
      tempRow.ImageName = splitImageNumber.ToString("000")
      tempRow.Width = sourceImageWidth
      tempRow.Height = sourceRow.Height
      tempRow.ConvertDt = DateTime.Now
      tempRow.EndEdit()
      Me.Data.EROPFilePageLog.AddEROPFilePageLogRow(tempRow)

      tempRow = Nothing

    End Sub

    ''' <summary>
    ''' Returns array containing EROPFilePageId of those pages having width identified as of double truck image.
    ''' </summary>
    ''' <param name="eropLogId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetDoubleTruckAdPageLogId(ByVal eropLogId As Integer) As Integer()
      Dim possibleCounts, percent90, doubletuckIds() As Integer
      Dim doubletruckList As System.Collections.Generic.List(Of Integer)
      Dim doubletruckQuery, outerQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPFilePageLogRow)


      RaiseEvent IdentifyingPossibleDoubleTruckAds(Me, New System.EventArgs())

      doubletruckList = New System.Collections.Generic.List(Of Integer)
      outerQuery = From r In Me.Data.EROPFilePageLog _
                   Where r.EROPLogId = eropLogId _
                   Order By r.EROPFileLogId, r.Page _
                   Select r

      percent90 = CType(System.Math.Ceiling(outerQuery.Count() * 0.7), Integer)

      For i As Integer = 0 To outerQuery.Count() - 1
        doubletruckQuery = From r In Me.Data.EROPFilePageLog _
                           Where (r.Width * 2) <= outerQuery(i).Width
        possibleCounts = doubletruckQuery.Count()
        If (possibleCounts > percent90) Then doubletruckList.Add(outerQuery(i).EROPFilePageLogId)
        doubletruckQuery = Nothing
      Next

      outerQuery = Nothing
      doubletuckIds = doubletruckList.ToArray()
      doubletruckList.Clear()
      doubletruckList = Nothing

      RaiseEvent IdentifiedPossibleDoubleTruckAds(Me, New System.EventArgs())

      Return doubletuckIds

    End Function

    ''' <summary>
    ''' Identifies and splits double truck ad images and updates IsDoubleTruck column value.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub IdentifyAndSplitDoubleTruckAds(ByVal downloadPath As String)
      Dim doubletruckPageId(), splitImageNumber, splitImageStartPixel As Integer
      Dim sourceImagePath, splitImagePath As System.Text.StringBuilder
      Dim doubletruckImage, sourceImage, splitImage As System.Drawing.Bitmap
      Dim splitImageRectangle As System.Drawing.Rectangle
      Dim publicationQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPLogRow)
      Dim doubletruckQuery As System.Collections.Generic.IEnumerable(Of eropDataSet.EROPFilePageLogRow)
      Dim cea As ConversionEventArgs, pcea As PublicationConversionEventArgs, pgcea As DoubleTruckPageEventArgs


      cea = New ConversionEventArgs()
      pcea = New PublicationConversionEventArgs()
      pgcea = New DoubleTruckPageEventArgs()

      publicationQuery = From r In Me.Data.EROPLog _
                         Where r.IsIsMarkedNull() = False AndAlso r.IsMarked = True _
                         Select r
      cea.TotalPublications = publicationQuery.Count()
      RaiseEvent ProcessingPublicationsForDoubleTruckAd(Me, cea)

      For i As Integer = 0 To publicationQuery.Count() - 1
        doubletruckPageId = GetDoubleTruckAdPageLogId(publicationQuery(i).EROPLogId)
        doubletruckQuery = From r In Me.Data.EROPFilePageLog _
                           Join id In doubletruckPageId On r.EROPFilePageLogId Equals id _
                           Select r
        pcea.TotalPublications = cea.TotalPublications : pcea.CurrentPublicationIndex = i + 1 : pcea.PublicationFolderPath = publicationQuery(i).PublicationId.ToString() : pcea.TotalFiles = doubletruckQuery.Count()
        RaiseEvent ProcessingPublicationForDoubleTruckAd(Me, pcea)

        sourceImagePath = New System.Text.StringBuilder()
        splitImagePath = New System.Text.StringBuilder()
        For j As Integer = 0 To doubletruckQuery.Count() - 1
          sourceImagePath.Append(downloadPath)
          If sourceImagePath.ToString().EndsWith(System.IO.Path.DirectorySeparatorChar) = False Then sourceImagePath.Append(System.IO.Path.DirectorySeparatorChar)
          sourceImagePath.Append(publicationQuery(i).PublicationId)
          sourceImagePath.Append(System.IO.Path.DirectorySeparatorChar)

          If Integer.TryParse(doubletruckQuery(j).ImageName, splitImageNumber) = False Then
            'TODO: Log this error and proceed with next publication.
            Exit For
          End If
          splitImageNumber += 1

          splitImagePath.Append(sourceImagePath.ToString())
          splitImagePath.Append(splitImageNumber.ToString("000\.jpg"))
          sourceImagePath.Append(doubletruckQuery(j).ImageName)
          sourceImagePath.Append(".jpg")

          doubletruckImage = New System.Drawing.Bitmap(sourceImagePath.ToString())
          splitImageStartPixel = (doubletruckImage.Width \ 2) + 1
          splitImageRectangle = New System.Drawing.Rectangle(splitImageStartPixel, 0, doubletruckImage.Width - splitImageStartPixel, doubletruckImage.Height)
          splitImage = doubletruckImage.Clone(splitImageRectangle, Imaging.PixelFormat.Format24bppRgb)
          splitImageRectangle = Nothing
          splitImageRectangle = New System.Drawing.Rectangle(0, 0, splitImageStartPixel - 1, doubletruckImage.Height)
          sourceImage = doubletruckImage.Clone(splitImageRectangle, Imaging.PixelFormat.Format24bppRgb)
          doubletruckImage.Dispose() : doubletruckImage = Nothing

          pgcea.SourceImagePath = sourceImagePath.ToString() : pgcea.SplitImagePath = splitImagePath.ToString() : pgcea.SplitImageAt = splitImageStartPixel
          RaiseEvent ProcessingPageImageForDoubleTruckAd(Me, pgcea)

          UpdateEROPFilePageLogForSplitImage(doubletruckQuery(j), splitImage.Width, System.IO.Path.GetDirectoryName(sourceImagePath.ToString()), splitImageNumber)

          Debug.Print(String.Format("Overwriting file {0}", sourceImagePath.ToString()))
          If System.IO.File.Exists(sourceImagePath.ToString()) Then System.IO.File.Delete(sourceImagePath.ToString())
          sourceImage.Save(sourceImagePath.ToString(), System.Drawing.Imaging.ImageFormat.Jpeg)

          Debug.Print(String.Format("Saving split file {0}", splitImagePath.ToString()))
          If System.IO.File.Exists(splitImagePath.ToString()) Then System.IO.File.Delete(splitImagePath.ToString())
          splitImage.Save(splitImagePath.ToString(), System.Drawing.Imaging.ImageFormat.Jpeg)

          RaiseEvent ProcessedPageImageForDoubleTruckAd(Me, pgcea)

          splitImageRectangle = Nothing
          splitImage.Dispose()
          splitImage = Nothing
          sourceImagePath.Remove(0, sourceImagePath.Length)
          splitImagePath.Remove(0, splitImagePath.Length)
        Next  'Loop for Page.

        RaiseEvent ProcessedPublicationForDoubleTruckAd(Me, pcea)

        splitImagePath = Nothing
        doubletruckQuery = Nothing
      Next  'Loop for Publication.

      RaiseEvent ProcessedPublicationsForDoubleTruckAd(Me, cea)

      publicationQuery = Nothing
    End Sub

    ''' <summary>
    ''' Synchronizes information in EROPFilePageLog data table with database.
    ''' </summary>
    ''' <remarks></remarks>
    ''' <exception cref="System.Data.SqlClient.SqlException">Database related error has occurred.</exception>
    ''' <exception cref="System.Exception">Unknown error has occurred.</exception>
    Public Sub SynchronizeEROPFilePageDataTable()
      Dim tempAdapter As eropDataSetTableAdapters.EROPFilePageLogTableAdapter


      RaiseEvent SynchronizingEROPFilePageInformation(Me, New System.EventArgs)

      tempAdapter = New eropDataSetTableAdapters.EROPFilePageLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      Try
        tempAdapter.Update(Me.Data.EROPFilePageLog)
      Catch ex As System.Data.SqlClient.SqlException
        Throw
      Catch ex As Exception
        Throw
      Finally
        tempAdapter.Dispose()
        tempAdapter = Nothing
      End Try

      RaiseEvent EROPFilePageInformationSynchronized(Me, New System.EventArgs)

    End Sub


#End Region


#Region " Step 4 related methods "


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="downloadFolderPath"></param>
    ''' <remarks></remarks>
    Public Function RecountImages(ByVal downloadFolderPath As String) As Long
      Dim imageCount As Long
      Dim imageFiles() As String


      RaiseEvent RecountingImages(Me, New System.EventArgs)

      imageFiles = GetListOfAllImagesPath(downloadFolderPath)
      imageCount = imageFiles.Length
      System.Array.Clear(imageFiles, 0, imageFiles.Length)
      imageFiles = Nothing

      RaiseEvent RecountingImages(Me, New System.EventArgs)

      Return imageCount
    End Function

    ''' <summary>
    ''' Gets array 
    ''' </summary>
    ''' <param name="downloadFolderPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetListOfAllImagesPath(ByVal downloadFolderPath As String) As String()
      Dim imageFileList As System.Collections.Generic.List(Of String)
      Dim publicationFolderPath As System.Text.StringBuilder
      Dim publicationQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPLogRow)


      RaiseEvent FetchingListOfAllImagesPath(Me, New System.EventArgs)

      publicationFolderPath = New System.Text.StringBuilder()
      imageFileList = New System.Collections.Generic.List(Of String)

      publicationQuery = From r In Me.Data.EROPLog _
                         Where r.IsIsMarkedNull() = False AndAlso r.IsMarked = True _
                         Select r

      For i As Integer = 0 To publicationQuery.Count() - 1
        publicationFolderPath.Append(downloadFolderPath)
        If publicationFolderPath.ToString().EndsWith(System.IO.Path.DirectorySeparatorChar) = False Then
          publicationFolderPath.Append(System.IO.Path.DirectorySeparatorChar)
        End If
        publicationFolderPath.Append(publicationQuery(i).PublicationId)

        imageFileList.AddRange(System.IO.Directory.GetFiles(publicationFolderPath.ToString(), "*.jpg"))

        publicationFolderPath.Remove(0, publicationFolderPath.Length)
      Next

      publicationQuery = Nothing
      publicationFolderPath = Nothing

      RaiseEvent ListOfAllImagesPathFetched(Me, New System.EventArgs)

      Return imageFileList.ToArray()
    End Function

    ''' <summary>
    ''' Returns Vehicle creation year and month, which is used to create parent folder for the vehicle folder.
    ''' </summary>
    ''' <param name="eropLogId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <exception cref="System.Data.SqlClient.SqlException">Database related error has occurred.</exception>
    ''' <exception cref="System.Exception">Unknown error has occurred.</exception>
    Private Function GetVehicleCreationYearMonth(ByVal eropLogId As Integer) As String
      Dim vehicleCreationMonthYear As String
      Dim tempAdapter As eropDataSetTableAdapters.EROPFilePageLogTableAdapter


      tempAdapter = New eropDataSetTableAdapters.EROPFilePageLogTableAdapter()
      tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()
      Try
        vehicleCreationMonthYear = tempAdapter.GetVehicleCreationYearMonth(eropLogId)
      Catch ex As System.Data.SqlClient.SqlException
        Throw
      Catch ex As System.Exception
        Throw
      Finally
        tempAdapter.Dispose()
        tempAdapter = Nothing
      End Try

      Return vehicleCreationMonthYear

    End Function

    ''' <summary>
    ''' Interchanges width and height of the image.
    ''' </summary>
    ''' <param name="eropFilePageLogId"></param>
    ''' <remarks></remarks>
    ''' <exception cref="System.Data.SqlClient.SqlException">Database related error has occurred.</exception>
    ''' <exception cref="System.Exception">Unknown error has occurred.</exception>
    Private Sub InterchangeImageWidthAndHeight(ByVal eropFilePageLogId As Integer)
      Dim tempAdapter As eropDataSetTableAdapters.EROPFilePageLogTableAdapter


      tempAdapter = New eropDataSetTableAdapters.EROPFilePageLogTableAdapter()

      Try
        tempAdapter.InterchangeWidthAndHeight(eropFilePageLogId)
      Catch ex As System.Data.SqlClient.SqlException
        Throw
      Catch ex As Exception
        Throw
      Finally
        tempAdapter.Dispose()
        tempAdapter = Nothing
      End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="publicationId"></param>
    ''' <param name="marketName"></param>
    ''' <param name="publicationName"></param>
    ''' <param name="fileName"></param>
    ''' <param name="pageNumber"></param>
    ''' <param name="isDoubleTruck"></param>
    ''' <param name="sourceImagePath"></param>
    ''' <param name="destinationImagePath"></param>
    ''' <param name="noteText"></param>
    ''' <remarks></remarks>
    Private Sub AddImageMovementLog(ByVal publicationId As Integer, ByVal marketName As String, ByVal publicationName As String, ByVal fileName As String, ByVal pageNumber As Integer, ByVal isDoubleTruck As Byte?, ByVal sourceImagePath As String, ByVal destinationImagePath As String, ByVal noteText As String)
      Dim tempRow As eropDataSet.ImageMovementRow


      tempRow = Me.Data.ImageMovement.NewImageMovementRow()
      tempRow.BeginEdit()
      tempRow.PublicationId = publicationId
      tempRow.Publication = publicationName
      tempRow.Market = marketName
      tempRow.FileName = fileName
      tempRow.Page = pageNumber
      If isDoubleTruck.HasValue Then tempRow.IsDoubleTruck = isDoubleTruck.Value
      tempRow.Source = sourceImagePath
      tempRow.Destination = destinationImagePath
      tempRow.Note = noteText
      tempRow.EndEdit()
      Me.Data.ImageMovement.AddImageMovementRow(tempRow)

      Me.Data.ImageMovement.AcceptChanges()


      tempRow = Nothing
    End Sub

    ''' <summary>
    ''' Moves page images from publication folder to vehicle's folder for unsized images.
    ''' </summary>
    ''' <param name="downloadFolderPath"></param>
    ''' <param name="vehicleRootFolderPath"></param>
    ''' <param name="rotationAngle"></param>
    ''' <remarks></remarks>
    Public Sub MoveImagesToVehicleFolder(ByVal downloadFolderPath As String, ByVal vehicleRootFolderPath As String, ByVal rotationAngle As Integer)
      Dim sourceFolderPath, destinationFolderPath, sourceFilePath, destinationFilePath, vehicleCreationYearMonth, noteText As System.Text.StringBuilder
      Dim rotateImage As System.Drawing.Image
      Dim publicationQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPLogRow)
      Dim imageQuery As System.Data.EnumerableRowCollection(Of eropDataSet.EROPFilePageLogRow)
      Dim mpiea As MovePublicationImagesEventArgs, miea As MoveImageEventArgs


      sourceFolderPath = New System.Text.StringBuilder()
      destinationFolderPath = New System.Text.StringBuilder()
      sourceFilePath = New System.Text.StringBuilder()
      destinationFilePath = New System.Text.StringBuilder()
      vehicleCreationYearMonth = New System.Text.StringBuilder()
      noteText = New System.Text.StringBuilder()
      mpiea = New MovePublicationImagesEventArgs()
      miea = New MoveImageEventArgs()

      Me.Data.ImageMovement.Rows.Clear()

      publicationQuery = From r In Me.Data.EROPLog _
                         Where r.IsIsMarkedNull() = False AndAlso r.IsMarked = True _
                         Select r

      For i As Integer = 0 To publicationQuery.Count() - 1
        vehicleCreationYearMonth.Append(GetVehicleCreationYearMonth(publicationQuery(i).EROPLogId))

        sourceFolderPath.Append(downloadFolderPath)
        If sourceFolderPath.ToString().EndsWith(System.IO.Path.DirectorySeparatorChar) = False Then sourceFolderPath.Append(System.IO.Path.DirectorySeparatorChar)
        sourceFolderPath.Append(publicationQuery(i).PublicationId)

        destinationFolderPath.Append(vehicleRootFolderPath)
        If destinationFolderPath.ToString().EndsWith(System.IO.Path.DirectorySeparatorChar) = False Then destinationFolderPath.Append(System.IO.Path.DirectorySeparatorChar)
        destinationFolderPath.Append(vehicleCreationYearMonth.ToString())
        destinationFolderPath.Append(System.IO.Path.DirectorySeparatorChar)
        destinationFolderPath.Append(publicationQuery(i).VehicleId)
        destinationFolderPath.Append(System.IO.Path.DirectorySeparatorChar)
        destinationFolderPath.Append(UnsizedPageImageFolderName)

        imageQuery = From r In Me.Data.EROPFilePageLog _
                     Where r.EROPLogId = publicationQuery(i).EROPLogId _
                     Order By r.EROPLogId, r.EROPFileLogId, r.Page, r.ImageName _
                     Select r

        mpiea.TotalDirectories = publicationQuery.Count() : mpiea.CurrentDirectoryIndex = i + 1 : mpiea.SourceFolderPath = sourceFolderPath.ToString() : mpiea.DestinationFolderPath = destinationFolderPath.ToString() : mpiea.TotalFiles = imageQuery.Count()
        RaiseEvent MovingAdImagesToVehicleFolder(Me, mpiea)

        If mpiea.TotalFiles > 0 AndAlso System.IO.Directory.Exists(destinationFolderPath.ToString()) = False Then
          System.IO.Directory.CreateDirectory(destinationFolderPath.ToString())
        End If

        For j As Integer = 0 To imageQuery.Count() - 1
          sourceFilePath.Append(sourceFolderPath.ToString())
          sourceFilePath.Append(System.IO.Path.DirectorySeparatorChar)
          sourceFilePath.Append(imageQuery(j).ImageName)
          sourceFilePath.Append(".jpg")

          destinationFilePath.Append(destinationFolderPath.ToString())
          destinationFilePath.Append(System.IO.Path.DirectorySeparatorChar)
          destinationFilePath.Append(imageQuery(j).ImageName)
          destinationFilePath.Append(".jpg")

          If System.IO.File.Exists(sourceFilePath.ToString()) = False Then
            noteText.Append("Source image file not found. Unable to copy this page image.")
          Else
            miea.SourceImagePath = sourceFilePath.ToString() : miea.RotationAngle = rotationAngle : miea.CurrentFileIndex = j + 1 : miea.DestinationPath = destinationFilePath.ToString()
            RaiseEvent CopyingPageImage(Me, miea)

            If rotationAngle = 0 Then
              System.IO.File.Copy(sourceFilePath.ToString(), destinationFilePath.ToString(), True)
            Else
              rotateImage = System.Drawing.Image.FromFile(sourceFilePath.ToString())
              Select Case rotationAngle
                Case 90
                  rotateImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
                Case 180
                  rotateImage.RotateFlip(RotateFlipType.Rotate180FlipNone)
                Case 270
                  rotateImage.RotateFlip(RotateFlipType.Rotate270FlipNone)
              End Select
              rotateImage.Save(destinationFilePath.ToString())
              rotateImage.Dispose()
              rotateImage = Nothing
            End If

            RaiseEvent PageImageCopied(Me, miea)

            If rotationAngle = 90 Or rotationAngle = 270 Then InterchangeImageWidthAndHeight(imageQuery(j).EROPFilePageLogId)
            If rotationAngle <> 0 Then noteText.AppendFormat("Rotated at {0} degree, while copying.", rotationAngle)
          End If

          If imageQuery(j).IsIsDoubleTruckNull() Then
                        AddImageMovementLog(publicationQuery(i).PublicationId, imageQuery(j).Market, imageQuery(j).Publication _
                                            , imageQuery(j).FileName, imageQuery(j).Page, Nothing _
                                            , sourceFilePath.ToString(), destinationFilePath.ToString(), noteText.ToString())
          Else
                        AddImageMovementLog(publicationQuery(i).PublicationId, imageQuery(j).Market, imageQuery(j).Publication _
                                            , imageQuery(j).FileName, imageQuery(j).Page, imageQuery(j).IsDoubleTruck _
                                            , sourceFilePath.ToString(), destinationFilePath.ToString(), noteText.ToString())
          End If

          noteText.Remove(0, noteText.Length)
          sourceFilePath.Remove(0, sourceFilePath.Length)
          destinationFilePath.Remove(0, destinationFilePath.Length)
        Next

        RaiseEvent AdImagesMovedToVehicleFolder(Me, mpiea)

        sourceFolderPath.Remove(0, sourceFolderPath.Length)
        destinationFolderPath.Remove(0, destinationFolderPath.Length)
        vehicleCreationYearMonth.Remove(0, vehicleCreationYearMonth.Length)
      Next


      mpiea = Nothing
      miea = Nothing
      noteText = Nothing
      sourceFilePath = Nothing
      destinationFilePath = Nothing
      sourceFolderPath = Nothing
      destinationFolderPath = Nothing
      vehicleCreationYearMonth = Nothing
      imageQuery = Nothing
      publicationQuery = Nothing
    End Sub


#End Region


  End Class


End Namespace