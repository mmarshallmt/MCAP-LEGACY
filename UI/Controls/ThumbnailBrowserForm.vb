Namespace UI.Controls

    Public Class ThumbnailBrowserForm



        Private m_selectedIndex As Integer
        Private m_thumbnailList As System.Collections.Generic.List(Of String)

        'Thumbnails Browser
        Private numRows As Integer = 0
        Private columnIndex As Integer = 0
        Private rowIndex As Integer = 0
        Private _imageSize As Integer = 50


        ''' <summary>
        ''' List containing path to thumbnails displayed on list.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property ThumbnailList() As System.Collections.Generic.List(Of String)
            Get
                Return m_thumbnailList
            End Get
        End Property

        ''' <summary>
        ''' Holds index of currently selected item in image list.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Property SelectedIndex() As Integer
            Get
                Return m_selectedIndex
            End Get
            Set(ByVal value As Integer)
                m_selectedIndex = value
            End Set
        End Property



        ''' <summary>
        ''' Loads image files in thumbnail image list.
        ''' </summary>
        ''' <param name="filePathArray">String array, containing path to thumbnail page images.</param>
        ''' <param name="thumbnails">True if array contains path of thumbnails, false otherwise.</param>
        ''' <remarks></remarks>
        Private Sub ShowThumbnails(ByVal filePathArray() As String, ByVal thumbnails As Boolean)
            Dim notFound, noThumbnail As String
            Dim filePath As System.Text.StringBuilder


            filePath = New System.Text.StringBuilder()
            notFound = System.IO.Path.GetTempFileName() '.Replace(".tmp", ".png")
            noThumbnail = System.IO.Path.GetTempFileName() '.Replace(".tmp", ".png")
            My.Resources.notfound.Save(notFound)
            My.Resources.nothumbnail.Save(noThumbnail)

            'count total rows needed
            If ((filePathArray.Length) / 5) < 1 Then
                numRows = 1
            Else
                numRows = CInt((filePathArray.Length) / 5) + 1
            End If

            'add columns
            For index As Integer = 0 To 4
                Dim dataGridViewColumn As New DataGridViewImageColumn()

                dgThumbnails.Columns.Add(dataGridViewColumn)
                dgThumbnails.Columns(index).Width = _imageSize + 200
            Next

            'add rows
            For index As Integer = 0 To numRows - 1
                dgThumbnails.Rows.Add()
                dgThumbnails.Rows(index).Height = _imageSize + 1000
            Next

            For i As Integer = 0 To filePathArray.Length - 1
                If System.IO.File.Exists(filePathArray(i)) = False Then
                    filePath.Append(notFound)
                ElseIf thumbnails = False AndAlso i > 0 Then  'Display first unsized page image.
                    filePath.Append(noThumbnail)
                Else
                    filePath.Append(filePathArray(i))
                End If

                LoadThumbnailImages(filePath.ToString())

                ThumbnailList.Add(filePathArray(i))

                Application.DoEvents()
                Me.Tag = CType(Me.Tag, Integer) + 1
                filePath.Remove(0, filePath.Length)
            Next


            'clear the columns with empty image
            If rowIndex <= numRows - 1 Then
                For ictr As Integer = columnIndex To 4
                    Dim dataGridViewCellStyle As New DataGridViewCellStyle()
                    dataGridViewCellStyle.NullValue = Nothing
                    dataGridViewCellStyle.Tag = "BLANK"
                    dgThumbnails.Rows(rowIndex).Cells(ictr).Style = dataGridViewCellStyle
                Next
            End If
            If System.IO.File.Exists(notFound) Then System.IO.File.Delete(notFound)
            If System.IO.File.Exists(noThumbnail) Then System.IO.File.Delete(noThumbnail)

            notFound = Nothing
            noThumbnail = Nothing
            filePath = Nothing

        End Sub

#Region "Load Thumbnails"
        Private Sub LoadThumbnailImages(ByVal _file As String)
            Dim _numberPreviewImages As Integer = 100

            Dim numColumnsForWidth As Integer = (dgThumbnails.Width - 50) \ (_imageSize + 100)


            Dim numImagesRequired As Integer = 0
            Try

                'add image in the datagrid
                Dim image As Image = image.FromFile(_file)
                Dim newImage As Image = image.GetThumbnailImage(100, 200, Nothing, IntPtr.Zero)

                dgThumbnails.Rows(rowIndex).Cells(columnIndex).Value = newImage
                dgThumbnails.Rows(rowIndex).Cells(columnIndex).ToolTipText = _file ''GetFileName(_file(index))

                If columnIndex = 4 Then
                    rowIndex += 1
                    columnIndex = 0
                Else
                    columnIndex += 1
                End If
                image.Dispose()
            Catch ex As Exception
                MsgBox(Err.Description)
                Console.WriteLine(ex)
            End Try
        End Sub
#End Region

        ''' <summary>
        ''' Loads all files with .jpg extention within the folder.
        ''' </summary>
        ''' <param name="imageFolderPath">Path of folder containing page images.</param>
        ''' <param name="thumbnail"></param>
        ''' <remarks></remarks>
        Public Sub LoadThumbnails(ByVal imageFolderPath As String, ByVal thumbnail As Boolean)
            Dim filesArray() As String
            Dim statusForm As StatusMessageForm = New StatusMessageForm()


            ThumbnailList.Clear()

            If System.IO.Directory.Exists(imageFolderPath) = False Then
                MessageBox.Show(imageFolderPath + " folder not found.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                imageNotAvailableLabel.Show()
                Exit Sub
            End If

            statusForm.MessageText = "Loading thumbnails... Please wait."
            statusForm.Show(Me)

            If m_thumbnailList Is Nothing Then m_thumbnailList = New System.Collections.Generic.List(Of String)
            filesArray = System.IO.Directory.GetFiles(imageFolderPath, "*.jpg")

            ShowThumbnails(filesArray, thumbnail)
            filesArray = Nothing

            statusForm.Hide()
            statusForm.Dispose()
            statusForm = Nothing

        End Sub

        ''' <summary>
        ''' Loads all files with .jpg extention within the folder.
        ''' </summary>
        ''' <param name="imagePathArray">String array, containing path to page images.</param>
        ''' <param name="thumbnail">True if array contains path of thumbnails, false otherwise.</param>
        ''' <remarks></remarks>
        Public Sub LoadThumbnails(ByVal imagePathArray() As String, ByVal thumbnail As Boolean)
            Dim statusForm As StatusMessageForm = New StatusMessageForm()


            statusForm.MessageText = "Loading thumbnails... Please wait."
            statusForm.Show(Me)
            statusForm.Refresh()

            If m_thumbnailList Is Nothing Then m_thumbnailList = New System.Collections.Generic.List(Of String)

            ThumbnailList.Clear()

            ShowThumbnails(imagePathArray, thumbnail)

            statusForm.Hide()
            statusForm.Dispose()
            statusForm = Nothing

        End Sub

        Private Sub dgThumbnails_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgThumbnails.CellContentDoubleClick
            Dim xPath As String = dgThumbnails.SelectedCells(0).ToolTipText.ToString
            Dim iViewer As New UI.Controls.ImageViewerForm()
            If dgThumbnails.SelectedCells.Count > 0 Then
                xPath = xPath.Replace("Thumb", "Unsized")
                iViewer.LoadImage(xPath)
                iViewer.Show()
            End If
        End Sub
    End Class

End Namespace