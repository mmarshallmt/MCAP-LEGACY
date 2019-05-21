Imports System.Net

Public Class ImageViewerForm
    Public Property cropX As Integer
    Public Property cropY As Integer
    Public Property cropWidth As Integer
    Public Property cropHeight As Integer
    Public Property cropBitmap As Bitmap
    Public Property BitmapImg As Bitmap
    Public Property SplitCrops As Boolean
    Public Property cropPenSize As Integer = 4
    Public Property cropPen As Pen = New Pen(Color.FromArgb(255, 0, 0), cropPenSize)
    Public Property cropPen_NewCrops As Pen = New Pen(Color.FromArgb(255, 0, 0), cropPenSize)
    Public Property cropDashStyle As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid
    Public Property cropPenColor As Color = Color.Teal
    Public Property GridCrops As New List(Of Rectangle) ' will store crops that were created using the grid method (in mouseup event)
    Public Property Scal As Single = 1
    Public Property HScal As Single = 1
    Public Property ClickBehaviour As Integer = 0
    Public Property CroppedImage As Boolean
    Public Property ImageLoaded As Boolean = False
    Public Property RemoteImageLoaded As Boolean = False
    Public Property CropOutsideImageBounds As Boolean = False
    Public Property CenterImage As Boolean = False

    Private Brush As Brush = New SolidBrush(Color.FromArgb(&H40, &H2D, &HCD, &H2D))
    Private startPoint As Point
    Private endPoint As Point
    Private boxes As New List(Of ImgRectangle)
    Private selectedBoxIndex As Integer
    Private drawMode As Boolean = True

    Private OldImage As Size
    Private prevScrollPoint As Point
    Private offset As Single
    Private pointX As Integer
    Private pointY As Integer
    Private offsetX As Integer
    Private offsetY As Integer
    Private _ZoomImage As Bitmap
    Private _img As Bitmap

    Public Event ImageControlClick(ByVal sender As Object, ByVal e As MouseEventArgs)
    Public Event ImageControlRightClick(ByVal sender As Object, ByVal e As MouseEventArgs)
    Public Event ImageControlMouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
    Public Event ImageControlMouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
    Public Event ImageControlDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs)
    Public Event ImageControlKeepFocus(ByRef sender As Object, ByRef sendere As System.Windows.Forms.PreviewKeyDownEventArgs)

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Public Sub SetBackgroundColor(ByVal _color As Color)
        pbxImage.BackColor = _color
    End Sub

    Public Sub CenterPicturebox()
        If CenterImage Then
            pbxImage.Location = New Point(CInt((pbxImage.Parent.ClientSize.Width / 2) - (pbxImage.Width / 2)),
                              CInt((pbxImage.Parent.ClientSize.Height / 2) - (pbxImage.Height / 2)))
        End If
    End Sub

    Public Sub CoerceGarbageCollection(Optional ByVal disposed As Object = Nothing)
        If Not IsNothing(disposed) Then
            GC.SuppressFinalize(disposed)
        End If
        GC.Collect(GC.MaxGeneration)
        GC.WaitForPendingFinalizers()
        GC.Collect()
    End Sub

    Public Function Image(ByVal path As String) As Boolean
        Try
            ImageLoaded = False
            'make sure image is disposed of to prevent memory leak
            If Not BitmapImg Is Nothing Then BitmapImg.Dispose()
            If Not pbxImage.Image Is Nothing Then pbxImage.Image.Dispose()
            pbxImage.Image = Nothing
            BitmapImg = Nothing
            GC.Collect()

            If (path.StartsWith("http")) Then
                RemoteImageLoaded = True
                Try
                    Dim request As WebRequest = WebRequest.Create(path)
                    Using response As WebResponse = request.GetResponse()
                        Using stream As System.IO.Stream = response.GetResponseStream()
                            BitmapImg = CType(Bitmap.FromStream(stream), Bitmap)
                        End Using
                        If BitmapImg Is Nothing Then
                            Throw New Exception("Image not found")
                        End If
                    End Using
                    request = Nothing
                Catch ex As Exception
                    Throw New Exception("Image not found")
                End Try
                'Dim wc As WebClient = New WebClient()
                'wc.Proxy = Nothing
                'Dim bFile As Byte() = wc.DownloadData(path)
                'Dim MS As MemoryStream = New MemoryStream(bFile)
                'BitmapImg = Bitmap.FromStream(MS)
            Else
                If Not FileIO.FileSystem.FileExists(path) Then
                    Throw New Exception("Image not found")
                    Exit Function
                End If
                RemoteImageLoaded = False
                BitmapImg = CType(Drawing.Image.FromFile(path), Bitmap)
            End If

            pbxImage.Image = CType(BitmapImg.Clone(), Drawing.Image)
            OldImage = pbxImage.Size

            CenterPicturebox()

            CroppedImage = False

            ImageLoaded = True

            Return ImageLoaded
        Catch ex As Exception
            MsgBox("Error Loading Image: " & ex.Message & Environment.NewLine & path)
            Return False
        End Try
    End Function

    Public Function LinkExists(ByVal imageUrlAddress As String) As Boolean
        Try
            Dim request As WebRequest = WebRequest.Create(imageUrlAddress)
            Using response As WebResponse = request.GetResponse()
                Using stream As System.IO.Stream = response.GetResponseStream()
                    Using tmpimg As Bitmap = CType(Bitmap.FromStream(CType(stream, IO.Stream)), Bitmap)

                    End Using
                End Using
            End Using

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub Image(ByVal img As System.Drawing.Bitmap)
        Try
            ImageLoaded = False
            'make sure image is disposed of to prevent memory leak
            If Not BitmapImg Is Nothing Then BitmapImg.Dispose()
            If Not pbxImage.Image Is Nothing Then pbxImage.Image.Dispose()
            pbxImage.Image = Nothing
            BitmapImg = Nothing
            GC.Collect()
            BitmapImg = CType(img.Clone(), Bitmap)
            pbxImage.Image = CType(BitmapImg.Clone(), Drawing.Image)
            OldImage = pbxImage.Size

            CenterPicturebox()

            CroppedImage = False
            img = Nothing

            ImageLoaded = True
        Catch ex As Exception
            MsgBox(String.Format("Error Loading Image: {0}", ex.Message))
        End Try
    End Sub
    Public Sub ClearImage()
        Try
            ImageLoaded = False
            CroppedImage = False
            CropOutsideImageBounds = False
            RemoteImageLoaded = False

            'make sure image is disposed of to prevent memory leak
            If Not BitmapImg Is Nothing Then BitmapImg.Dispose()
            If Not pbxImage.Image Is Nothing Then pbxImage.Image.Dispose()
            pbxImage.Image = Nothing
            BitmapImg = Nothing
            GC.Collect()
        Catch ex As Exception
            MsgBox(String.Format("clear Image: {0}", ex.Message))
        End Try
    End Sub

    Private Function SetImageWithoutBackup(ByRef img As System.Drawing.Bitmap) As Boolean
        Try
            ImageLoaded = False
            'make sure image is disposed of to prevent memory leak
            If Not pbxImage.Image Is Nothing Then pbxImage.Image.Dispose()
            pbxImage.Image = Nothing
            pbxImage.Image = CType(img.Clone(), Drawing.Image)

            CenterPicturebox()

            ImageLoaded = True
            Return ImageLoaded
        Catch ex As Exception
            MsgBox(String.Format("Error Loading Image: {2}", ex.Message))
        End Try
    End Function

    Private Sub pbxImage_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbxImage.MouseDoubleClick
        Try
            Dim location As Point = pbxImage.PointToClient(MousePosition) 'e.Location
            Me.selectedBoxIndex = Me.GetRectangleIndexAtPoint(location)
            RaiseEvent ImageControlDoubleClick(sender, e)
        Catch ex As Exception
            MsgBox("pbxImage_MouseDoubleClick: " & ex.Message)
        End Try

    End Sub

    Public Sub pbxImage_MouseClick(ByVal sender As Object,
                                       ByVal e As MouseEventArgs) Handles pbxImage.MouseClick
        Try
            Panel1.Select()
            'Only do work if the right mouse button was clicked and no other mouse buttons are depressed.
            If e.Button = Windows.Forms.MouseButtons.Right AndAlso
               Control.MouseButtons = Windows.Forms.MouseButtons.None Then
                Dim location As Point = pbxImage.PointToClient(MousePosition) 'e.Location

                'Remember which box was clicked.
                Me.selectedBoxIndex = Me.GetRectangleIndexAtPoint(location)

                RaiseEvent ImageControlRightClick(sender, e)
            End If
            If e.Button = Windows.Forms.MouseButtons.Left Then
                If ClickBehaviour = 1 Then
                    RaiseEvent ImageControlClick(sender, e)
                End If
            End If
        Catch ex As Exception
            MsgBox("pbxImage_MouseClick:" & ex.Message)
        End Try
    End Sub

    Private Sub ScaleRectangle()
        Try
            'find scale of change by comparing current size with size before zooming
            Scal = CSng(pbxImage.Width / OldImage.Width)
            HScal = CSng(pbxImage.Height / OldImage.Height)
        Catch ex As Exception
            MsgBox("ScaleRectangle: " & ex.Message)
        End Try
    End Sub

    Private Sub pbxImage_MouseDown(ByVal sender As Object,
                                      ByVal e As MouseEventArgs) Handles pbxImage.MouseDown
        Try
            'Only do work if the left mouse button was depressed and no other mouse buttons are depressed.
            If Control.MouseButtons = Windows.Forms.MouseButtons.Left Then
                Dim location As Point = pbxImage.PointToClient(MousePosition) ' e.Location

                'Remember where the draw or drag operation started.
                Me.startPoint = location
                'A draw operation ends at the current mouse location.
                Me.endPoint = location
                RaiseEvent ImageControlMouseDown(sender, e)
            End If
            If e.Button = MouseButtons.Middle Then
                prevScrollPoint = New Point(e.X, e.Y)
            End If
        Catch ex As Exception
            MsgBox("pbxImage_MouseDown: " & ex.Message)
        End Try
    End Sub

    Private Sub pbxImage_MouseMove(ByVal sender As Object,
                                      ByVal e As MouseEventArgs) Handles pbxImage.MouseMove
        Try

            'Only do work if the left mouse button is the one and only mouse button that is depressed.
            If Control.MouseButtons = Windows.Forms.MouseButtons.Left Then

                'The old box area must be repainted in case the box has shrunk.
                'Me.InvalidateRectangle(Me.GetRectangle(Me.startPoint, Me.endPoint))

                'A draw operation ends at the current mouse location.
                Me.endPoint = pbxImage.PointToClient(MousePosition) ' e.Location

                'The new box area must be repainted in case the box has grown.
                Me.InvalidateRectangle(Me.GetRectangle(Me.startPoint, New Point(Me.endPoint.X + 100, Me.endPoint.Y + 100)))
            End If
            If (e.Button = MouseButtons.Middle) Then

                offsetX = (prevScrollPoint.X - e.X)
                offsetY = (prevScrollPoint.Y - e.Y)
                pointX = offsetX - (Panel1.AutoScrollPosition.X)
                pointY = offsetY - (Panel1.AutoScrollPosition.Y)

                Panel1.AutoScrollPosition = New Point(pointX, pointY)

            End If
        Catch ex As Exception
            MsgBox("PictureBox1_MouseMove: " & ex.Message)
        End Try
    End Sub

    'Private Sub pbxImage_MouseUp(ByVal sender As Object,
    '                                ByVal e As MouseEventArgs) Handles pbxImage.MouseUp
    '    Try
    '        Dim box As ImgRectangle
    '        'Only do work if we are drawing, the left mouse button
    '        'was released and no other mouse buttons are depressed.
    '        If pbxImage.IsDisposed Then
    '            Exit Sub
    '        End If
    '        GridCrops.Clear()
    '        If Me.drawMode AndAlso e.Button = Windows.Forms.MouseButtons.Left AndAlso Control.MouseButtons = Windows.Forms.MouseButtons.None Then
    '            'The current mouse location is the final end of the drawing operation.
    '            Me.endPoint = pbxImage.PointToClient(MousePosition) 'e.Location

    '            'Create the new box.
    '            box = New ImgRectangle(Me.GetRectangle(Me.startPoint, Me.endPoint))

    '            'Add the new box to the list.
    '            cropX = CInt(box.X / Scal)
    '            cropY = CInt(box.Y / HScal)
    '            cropWidth = CInt(box.Width / Scal)
    '            cropHeight = CInt(box.Height / HScal)

    '            box.X = CLng(box.X / Scal)
    '            box.Y = CLng(box.Y / HScal)
    '            box.Width /= Scal
    '            box.Height /= HScal
    '            box.cropPen = cropPen_NewCrops

    '            If box.Width <= 0 And box.Height <= 0 Then
    '                Exit Sub
    '            End If
    '            'If SplitCrops Then
    '            '    Dim rowcount, columncount As Integer

    '            '    Using frmgrid As New frmGridValues() With {.StartPosition = FormStartPosition.CenterParent}
    '            '        frmgrid.ShowDialog()
    '            '        If frmgrid.DialogResult = DialogResult.OK Then
    '            '            rowcount = frmgrid.RowCount
    '            '            columncount = frmgrid.ColumnCount
    '            '        Else
    '            '            Exit Sub
    '            '        End If
    '            '    End Using

    '            'set 0,0 at margin bounds
    '            '    Dim Datum As Point = New Point(cropX, cropY)
    '            '    'get the size of 1/20 the rectangle from above
    '            '    Dim Bar As Size = New Size(CInt((box.Width / columncount)), CInt(box.Height / rowcount))

    '            '    'each time increase x by bar width 
    '            '    For barcount1 As Integer = 1 To columncount
    '            '        Me.boxes.Add(New ImgRectangle(Datum.X, Datum.Y, Bar.Width, Bar.Height, cropPen_NewCrops))
    '            '        Me.GridCrops.Add(New Rectangle(Datum.X, Datum.Y, Bar.Width, Bar.Height))
    '            '        For BarCount As Integer = 1 To rowcount - 1
    '            '            Datum.Y = Datum.Y + Bar.Height
    '            '            Me.boxes.Add(New ImgRectangle(Datum.X, Datum.Y, Bar.Width, Bar.Height, cropPen_NewCrops))
    '            '            Me.GridCrops.Add(New Rectangle(Datum.X, Datum.Y, Bar.Width, Bar.Height))
    '            '        Next
    '            '        Datum.Y = cropY
    '            '        Datum.X = Datum.X + Bar.Width
    '            '    Next
    '            'Else
    '            '    If box.X >= 0 And box.Y >= 0 And box.Width >= 0 And box.Height >= 0 Then
    '            '        Me.boxes.Add(box)
    '            '        Me.InvalidateRectangle(box.ToRectangle())

    '            '    End If
    '            'End If

    '            'RaiseEvent ImageControlMouseUp(sender, e)
    '            'End If

    '            box = Nothing

    '            If e.Button = MouseButtons.Middle Then
    '                prevScrollPoint = pbxImage.PointToClient(MousePosition) 'e.Location
    '            End If
    '    Catch ex As Exception
    '        MsgBox("PictureBox1_MouseUp: " & ex.Message)
    '    Finally
    '        'The new box area must be repainted.
    '        Me.pbxImage.Update()
    '        Me.Refresh()
    '    End Try
    'End Sub

    Public Sub AddCrop(ByVal LeftPos As Integer, ByVal TopPos As Integer, ByVal WidthPos As Integer, ByVal HeightPos As Integer, Optional _cropPen As Pen = Nothing)
        Try
            If _cropPen Is Nothing Then _cropPen = cropPen

            Dim box As New ImgRectangle(CLng(IIf((WidthPos - LeftPos) < 0, WidthPos, LeftPos)),
                                     CLng(IIf((HeightPos - TopPos) < 0, HeightPos, TopPos)),
                                     Math.Abs((WidthPos) - (LeftPos)),
                                     Math.Abs((HeightPos) - (TopPos)), _cropPen)

            If Not Me.boxes.Exists(Function(x) x.X = box.X And x.Y = box.Y And x.Width = box.Width And x.Height = box.Height) Then
                Me.boxes.Add(box)
                'The new box area must be repainted.
                Me.InvalidateRectangle(box.ToRectangle())
                pbxImage.Refresh()

                If ((WidthPos - BitmapImg.Width) / Math.Abs(WidthPos - LeftPos)) > 0.3 Then
                    CropOutsideImageBounds = True
                Else
                    CropOutsideImageBounds = False
                End If

            End If
            box = Nothing
        Catch ex As Exception
            MsgBox("Error adding crop:" + ex.Message)
        End Try
    End Sub

    Public Sub ClearCrops()
        Try
            Me.boxes.Clear()
            pbxImage.Refresh()

        Catch ex As Exception
            MsgBox("ClearCrops: " & ex.Message)
        End Try
    End Sub



    Public Sub resetCrop()
        Me.cropX = 0
        Me.cropY = 0
        Me.cropWidth = 0
        Me.cropHeight = 0
        CropOutsideImageBounds = False
    End Sub

    Public Sub resetScale()
        HScal = 1
        Scal = 1
    End Sub

    Public Function getimage() As Bitmap
        Try
            Return CType(pbxImage.Image, Bitmap)
        Catch ex As Exception
            MsgBox("getimage: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Sub FullScreen()
        Dim newsize As Size
        Try
            If BitmapImg Is Nothing Then Exit Sub
            _ZoomImage = Nothing
            newsize = Nothing
            _img = Nothing
            _img = CType(BitmapImg.Clone(), Bitmap) ' System.Drawing.Bitmap.FromFile(imagepath)
            CroppedImage = False
            OldImage = New Size(_img.Width, _img.Height)

            newsize = New Size((Convert.ToInt32(_img.Width * (Panel1.Height / OldImage.Height))),
            (Convert.ToInt32(_img.Height * (Panel1.Height / OldImage.Height))))
            Try
                If newsize.Height < 40000 Or newsize.Width < 40000 Then
                    _ZoomImage = New Bitmap(_img, newsize)
                Else
                    _ZoomImage = CType(_img.Clone(), Bitmap)
                End If
            Catch ex As OutOfMemoryException
                Exit Sub
            End Try
            _img = Nothing
            SetImageWithoutBackup(_ZoomImage)
            ScaleRectangle()
        Catch ex As Exception
            MsgBox("FullScreen: " & ex.Message)
        Finally
            _ZoomImage = Nothing
            newsize = Nothing
        End Try

    End Sub

    Public Sub FitSides()
        Dim newsize As Size
        Try
            _img = Nothing
            _ZoomImage = Nothing
            _img = CType(BitmapImg.Clone(), Bitmap)

            'If CroppedImage Then
            '    _img = Docrop(_img, cropX, cropY, cropWidth, cropHeight)
            'End If

            OldImage = New Size(_img.Width, _img.Height)

            ' newsize = New Size((Convert.ToInt32(_img.Width * IIf((Panel1.Width < OldImage.Width), (Panel1.Width / OldImage.Width), 1))),
            '(Convert.ToInt32(_img.Height * IIf((Panel1.Width < OldImage.Width), (Panel1.Width / OldImage.Width), 1))))
            Try
                If newsize.Height < 40000 Or newsize.Width < 40000 Then

                    _ZoomImage = New Bitmap(_img, newsize)

                Else

                    _ZoomImage = CType(_img.Clone(), Bitmap)

                End If
            Catch ex As OutOfMemoryException
                Exit Sub
            End Try
            SetImageWithoutBackup(_ZoomImage)
            ScaleRectangle()
        Catch ex As Exception
            MsgBox("FitSides: " & ex.Message)
        Finally
            _img = Nothing
            _ZoomImage = Nothing
            newsize = Nothing
            GC.Collect()
        End Try
    End Sub
    Public Sub FitHeight()
        Dim newsize As Size
        Try
            _img = Nothing
            _ZoomImage = Nothing
            newsize = Nothing
            _img = CType(BitmapImg.Clone(), Bitmap)

            'If CroppedImage Then
            '    _img = Docrop(_img, cropX, cropY, cropWidth, cropHeight)
            'End If

            OldImage = New Size(_img.Width, _img.Height)

            ' newsize = New Size((Convert.ToInt32(_img.Width * IIf((Panel1.Height < OldImage.Height), (Panel1.Height / OldImage.Height), 1))),
            '(Convert.ToInt32(_img.Height * IIf((Panel1.Height < OldImage.Height), (Panel1.Height / OldImage.Height), 1))))
            Try
                If newsize.Height < 40000 Or newsize.Width < 40000 Then

                    _ZoomImage = New Bitmap(_img, newsize)

                Else

                    _ZoomImage = CType(_img.Clone(), Bitmap)

                End If
            Catch ex As OutOfMemoryException
                Exit Sub
            End Try
            SetImageWithoutBackup(_ZoomImage)
            ScaleRectangle()
        Catch ex As Exception
            MsgBox("FitSides: " & ex.Message)
        Finally
            _img = Nothing
            _ZoomImage = Nothing
            newsize = Nothing
            GC.Collect()
        End Try
    End Sub
    Public Function getheight() As Integer
        Return pbxImage.Height
    End Function

    Public Function getwidth() As Integer
        Return pbxImage.Width
    End Function

    Public Sub ZoomImage(ByVal zoomvalue As Integer)
        Dim newsize As Size
        Try
            If BitmapImg Is Nothing Then Exit Sub
            _ZoomImage = Nothing
            newsize = Nothing
            _img = Nothing
            _img = CType(BitmapImg.Clone(), Bitmap)

            'If CroppedImage Then
            '    _img = Docrop(_img, cropX, cropY, cropWidth, cropHeight)
            'End If

            OldImage = New Size(_img.Width, _img.Height)
            Try
                newsize = New Size(CInt((_img.Width * zoomvalue) / 100),
                CInt((_img.Height * zoomvalue) / 100))

                If newsize.Height < 40000 And newsize.Width < 40000 Then

                    _ZoomImage = New Bitmap(_img, newsize)


                Else
                    _ZoomImage = CType(_img.Clone(), Bitmap)
                End If

                SetImageWithoutBackup(_ZoomImage)
                ScaleRectangle()
            Catch ex As OutOfMemoryException
                Exit Sub
            End Try
        Catch ex As Exception
            MsgBox("ZoomImage: " & ex.Message)
        Finally
            _img = Nothing
            _ZoomImage = Nothing
            newsize = Nothing
            GC.Collect()
        End Try
    End Sub
    Public Sub ZoomImage(ByVal zoomvalue As Integer, ByVal cropX As Single,
                         ByVal cropY As Single, ByVal cropWidth As Single, ByVal cropHeight As Single)
        Try
            _img = Nothing
            _ZoomImage = Nothing
            _img = CType(BitmapImg.Clone(), Bitmap) 'System.Drawing.Bitmap.FromFile(imagepath)

            'If CroppedImage Then
            '    _img = Docrop(_img, CInt(cropX), CInt(cropY), CInt(cropWidth), CInt(cropHeight))
            'End If

            OldImage = New Size(_img.Width, _img.Height)
            Try
                _ZoomImage = New Bitmap(_img, (Convert.ToInt32(_img.Width * (zoomvalue) / 100)),
                (Convert.ToInt32(_img.Height * (zoomvalue) / 100)))
            Catch ex As OutOfMemoryException
                Exit Sub
            End Try

            SetImageWithoutBackup(_ZoomImage)
            ScaleRectangle()

        Catch ex As Exception
            MsgBox("ZoomImage with crops: " & ex.Message)
        Finally
            _img = Nothing
            _ZoomImage = Nothing
            GC.Collect()
        End Try
    End Sub

    Private Sub pbxImage_Paint(ByVal sender As Object,
                                  ByVal e As PaintEventArgs) Handles pbxImage.Paint
        Try
            Dim index As Integer = 0

            With e.Graphics
                'Draw all the boxes one by one, from back-most to front-most.
                For Each box As ImgRectangle In Me.boxes

                    'If box.X >= 0 And box.Y >= 0 And box.Width >= 0 And box.Height >= 0 Then

                    If box.cropPen Is Nothing Then box.cropPen = cropPen

                    If isBoxDrawn(index, box) Then
                        .FillRectangle(Brushes.Transparent, box.X * Scal, box.Y * HScal, box.Width * Scal, box.Height * HScal)
                        .DrawRectangle(box.cropPen, box.X * Scal, box.Y * HScal, box.Width * Scal, box.Height * HScal)
                    Else
                        .FillRectangle(Brush, box.X * Scal, box.Y * HScal, box.Width * Scal, box.Height * HScal)
                        .DrawRectangle(box.cropPen, box.X * Scal, box.Y * HScal, box.Width * Scal, box.Height * HScal)
                    End If
                    'End If

                    index += 1
                Next

                'Only do work if a draw operation is in progress.
                If Me.drawMode AndAlso
                   Control.MouseButtons = Windows.Forms.MouseButtons.Left Then
                    'Get the box that is currently being drawn.
                    Dim box As Rectangle = Me.GetRectangle(Me.startPoint, Me.endPoint)

                    'Draw the new box.
                    .FillRectangle(Brush, box)
                    .DrawRectangle(cropPen_NewCrops, box)
                End If
            End With
        Catch ex As Exception
            MsgBox("Paint: " + ex.Message)
        End Try
    End Sub

    Public Function GetScale() As Integer
        Return CInt((Scal * 100))
    End Function

    Private Function isBoxDrawn(ByVal index As Integer, ByVal box As ImgRectangle) As Boolean
        Dim idx As Integer = 0
        For Each box1 As ImgRectangle In Me.boxes
            If idx = index Then
                Exit For
            End If
            If box1.Equals(box) Then
                Return True
            End If
            idx += 1
        Next
        Return False
    End Function

    Private Function GetRectangleIndexAtPoint(ByVal location As Point) As Integer
        Try
            Dim box As Rectangle

            'Assume no box by default.
            Dim result As Integer = -1

            'Loop backwards so we check front-most boxes first.
            For index As Integer = Me.boxes.Count - 1 To 0 Step -1
                box = Me.boxes(index).ToRectangle()

                If box.Contains(location) Then
                    'The current box contains the specified location.
                    result = index

                    'Look no further.
                    Exit For
                End If
            Next

            Return result
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function GetRectangle(ByVal startPoint As Point, _
                              ByVal endPoint As Point) As Rectangle
        Try
            'The top is the lesser of the two X coordinates.
            'The left is the lesser of the two Y coordinates.
            'The width is the absolute difference of the two X coordinates.
            'The height is the absolute difference of the two Y coordinates.
            Return New Rectangle(startPoint.X, _
                                startPoint.Y, _
                                 Math.Abs(startPoint.X - endPoint.X), _
                                 Math.Abs(startPoint.Y - endPoint.Y))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function CalculateImageArea() As Double
        Return BitmapImg.Height * BitmapImg.Width
    End Function

    ''' <summary>
    ''' Invalidates an area of the form containing the specified box.
    ''' </summary>
    ''' <param name="box">
    ''' A <see cref="Rectangle" /> that needs to be repainted.
    ''' </param>
    Private Sub InvalidateRectangle(ByVal box As Rectangle)
        Try
            'When invalidating a Rectangle the right-most
            'column and bottom-most row of pixels is excluded.
            'Inflate the box by 1 pixel in every direction to
            'ensure those excluded pixels are also repainted.
            box.Inflate(1, 1)

            Me.pbxImage.Invalidate(box)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SplitRectangle()
        ''draw large rectangle
        'Dim Pen1 As New Pen(Brushes.Black)
        'Dim rWidth, rHeight As Integer

        'rWidth = e.MarginBounds.Right - e.MarginBounds.Left
        'rHeight = e.MarginBounds.Bottom - e.MarginBounds.Top

        ''Dim r1 As New Rectangle(e.MarginBounds.Left, e.MarginBounds.Top, rWidth, rHeight)
        ''e.Graphics.DrawRectangle(Pen1, r1)

        ''set 0,0 at margin bounds
        'Dim Datum As Point = New Point(cropX, cropY)

        ''get the size of 1/20 the rectangle from above
        'Dim Bar As Size = New Size((rWidth / 5), rHeight)

        ''draw a rec, starting at 0, count up tp 20.
        ''each time increase x by bar width 

        'For BarCount As Integer = 0 To 4
        '    e.Graphics.DrawRectangle(Pens.Blue, Datum.X, Datum.Y, Bar.Width, Bar.Height)
        '    Datum.X = Datum.X + Bar.Width
        'Next



        'e.HasMorePages = False
    End Sub

    Private Sub ImgControl_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        CenterPicturebox()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class

''' <summary>
''' Custom rectangle class so we can have each crop with a specified colour
''' </summary>
''' <remarks></remarks>
Public Class ImgRectangle
    Public Property X As Long
    Public Property Y As Long
    Public Property Width As Long
    Public Property Height As Long
    Public Property cropPen As Pen
    Private DefaultcropPen As Pen = New Pen(Color.FromArgb(255, 0, 0), 4)

    Public Sub New()
        cropPen = DefaultcropPen 'default pen colour and size
    End Sub

    Public Sub New(ByVal _X As Long, ByVal _Y As Long, ByVal _Width As Long, ByVal _Height As Long, Optional _cropPen As Pen = Nothing)

        X = _X
        Y = _Y
        Width = _Width
        Height = _Height

        If _cropPen Is Nothing Then
            cropPen = DefaultcropPen 'default pen colour and size
        Else
            cropPen = _cropPen
        End If
    End Sub

    Public Sub New(ByVal rec As Rectangle)
        X = rec.X
        Y = rec.Y
        Width = rec.Width
        Height = rec.Height

        cropPen = DefaultcropPen 'default pen colour and size
    End Sub

    Public Function ToRectangle() As Rectangle
        Return New Rectangle(CInt(X), CInt(Y), CInt(Width), CInt(Height))
    End Function
End Class