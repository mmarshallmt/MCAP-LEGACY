﻿Imports System.Drawing.Imaging
Imports System.Data.Linq
Imports System.Linq
Imports MCAP.UI
Imports System.Configuration

Public Class wishabi
    Implements IForm

    Public VehicleId As Int32
    Public ConfigAppName As String = My.Settings.appDatabaseName
    Public UnsizedFolder As String
    Public DbServerName As String
    Public TempFolder As String = "c:\temp"
    Public pageImageFolder As String
    Public TileFolder As String
    Public ActivePageColor As Color = Color.FromArgb(&H804169E1)
    Dim _overviewImage As Bitmap = Nothing
    Private Const overscanRatio As Double = 2.0
    ReadOnly overviewRatio As Dictionary(Of Integer, Double) = New Dictionary(Of Integer, Double)()
    ReadOnly InactiveColor As Color = Color.Salmon
    ReadOnly _activePen As Pen = New Pen(ActivePageColor, 3.0)
    ReadOnly _inactivePen As Pen = New Pen(InactiveColor, 1.0)
    ReadOnly _detailPen As Pen = New Pen(Color.Lime, 2.0)


    ReadOnly _db As New CHubDataContext
    'Dim _hugeImage As List(Of Bitmap) = New List(Of Bitmap)()
    ReadOnly sliceFiles As List(Of String) = New List(Of String)()
    ReadOnly idxCache As List(Of Integer) = New List(Of Integer)()
    Private Const maxCache As Integer = 3
    ReadOnly sliceCache As Dictionary(Of Integer, Bitmap) = New Dictionary(Of Integer, Bitmap)()
    Dim _sliceCount As Integer = 0
    Dim _fullHeight As Integer
    Dim _fullWidth As Integer
    Dim _ratio As Double
    Dim _pages() As Rectangle = {}
    Dim _srcRect As Rectangle = New Rectangle(0, 0, 100, 100)
    ReadOnly frameskip As Integer = 3
    Dim _mouseTrack As Boolean = False
    Dim _dragStart As Point
    ReadOnly DragZones As Dictionary(Of String, Rectangle) = New Dictionary(Of String, Rectangle)()
    Dim _dragType As String = String.Empty
    Dim _oldSrcDetail As Rectangle
    Dim _safeToRepage As Boolean = True
    Dim _safeToAddpage As Boolean = False
    Const MaxSliceWidth As Integer = 256 * 8
    Public CurrentPage As Integer = 0
    ReadOnly _callback As New Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)

    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

        RaiseEvent InitializingForm()

        RaiseEvent FormInitialized()

    End Sub

    Public Event FormInitialized() Implements IForm.FormInitialized
    Public Event InitializingForm() Implements IForm.InitializingForm

    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied


    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

        Dim appUser As Processors.ApplicationUser

        RaiseEvent ApplyingUserCredentials()

        appUser = New Processors.ApplicationUser
        appUser.Initialize()
        appUser.GetFunctionalityListFor(appUser.UserID, Me.Name)


        appUser = Nothing

        RaiseEvent UserCredentialsApplied()

    End Sub

    Private Sub VehicleId_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ToolStripTextBox1.Validating
        'send was passed 
        If (Not Int32.TryParse(ToolStripTextBox1.Text, VehicleId)) Then
            e.Cancel = True
        End If
    End Sub

    Public Function ThumbnailCallback() As Boolean
        Return False
    End Function

    Private Function GetSlice(idx As Integer) As Bitmap
        Dim slice As Bitmap = Nothing
        If sliceCache.TryGetValue(idx, slice) Then Return slice
        If idx >= _sliceCount Or idx < 0 Then Return Nothing
        If idxCache.Count >= maxCache Then
            Dim k As Integer = idxCache(0)
            sliceCache(k).Dispose()
            sliceCache.Remove(k)
            idxCache.RemoveAt(0)
        End If
        idxCache.Add(idx)
        sliceCache.Add(idx, New Bitmap(sliceFiles(idx)))
        If Not _overviewImage Is Nothing And overviewRatio.ContainsKey(idx) Then
            Dim r As Double = CDbl(_overviewImage.Width) / _fullWidth
            If overviewRatio(idx) < r Then
                Dim g As Graphics = Graphics.FromImage(_overviewImage)
                g.DrawImage(sliceCache(idx), New Rectangle(CInt(idx * MaxSliceWidth * r), 0, CInt(sliceCache(idx).Width * r), CInt(sliceCache(idx).Height * r)), New Rectangle(0, 0, sliceCache(idx).Width, sliceCache(idx).Height), GraphicsUnit.Pixel)
                Overview.BackgroundImage = _overviewImage.GetThumbnailImage(Overview.Width, Overview.Height, AddressOf ThumbnailCallback, IntPtr.Zero)
                g.Dispose()
            End If
        End If
        Return sliceCache(idx)
    End Function

    Private Function PagesAsTiles(flyer As chubFlyer) As IEnumerable(Of chubFlyerTile)
        Dim tiles As New List(Of chubFlyerTile)
        ReDim _pages(flyer.Pages)
        'Get the pages
        For Each o As chubFlyerPage In flyer.chubFlyerPages
            'page to tiles
            Dim pagePos As chubPageTile = o.Page.chubPageTiles.OrderBy(Function(k) k.PositionLeft).ThenBy(Function(k) k.PositionTop).First()
            Dim flyerPos As chubFlyerTile = flyer.chubFlyerTiles.First(Function(k) k.TileId = pagePos.TileId)
            Dim pageObj As Page = _db.Vehicles.Single(Function(k) k.VehicleId = VehicleId).Pages.Single(Function(k) CInt(k.ReceivedOrder) = CInt(o.PageNum))
            Dim t As New chubFlyerTile()
            t.PositionLeft = flyerPos.PositionLeft - pagePos.PositionLeft
            t.PositionTop = flyerPos.PositionTop - pagePos.PositionTop
          
            'tile object needs info to find the filepath
            t.chubTile = New chubTile()
            t.chubTile.RetrievedDt = CDate(pageObj.Vehicle.CreateDt)
            t.chubTile.Etag = String.Format("{0}\{1}\{2}\{3}\{4}.jpg", pageImageFolder, Format(pageObj.Vehicle.CreateDt, "yyyyMM"), pageObj.VehicleId, UnsizedFolder, pageObj.ImageName)
            If Not pageObj.PixelHieght.HasValue Then
                pageObj.PixelHieght = 0
            End If
            If Not pageObj.PixelWidth.HasValue Then
                pageObj.PixelWidth = 0
            End If
            t.chubTile.Height = CInt(pageObj.PixelHieght) + 0
            t.chubTile.Width = CInt(pageObj.PixelWidth) + 0
            tiles.Add(t)
            'Use the page images for page definition
            _pages(o.PageNum - 1) = New Rectangle(t.PositionLeft, t.PositionTop, CInt(pageObj.PixelWidth), CInt(pageObj.PixelHieght))
        Next
        Return tiles

    End Function

    Private Function TilePath(tile As chubTile) As String
        'Return the path of a tile from a tile
        If tile.TileId = 0 Then Return tile.Etag
        ' Return String.Format("{0}\{1}.jpg", TileFolder, tile.Sha1Hash)
    End Function

    Private Sub LoadVehicle(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click, ToolStripButton3.Click

        If ToolStripTextBox1.Text = "" Then
            MsgBox("Please provide a vehicleID", MsgBoxStyle.Information)
            ToolStripTextBox1.Focus()
            Exit Sub
        End If
        VehicleId = CInt(ToolStripTextBox1.Text.ToString) + 0

        loadVehiceId(VehicleId)
        Form1_Resize(sender, e)
        Redraw()

    End Sub

    Private Sub DeleteFiles(path As String)
        If IO.Directory.Exists(path) Then
            'Delete all files from the Directory
            For Each filepath As String In IO.Directory.GetFiles(path)
                Try
                    IO.File.Delete(filepath)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Next

        End If
    End Sub

    Private Sub clearForm()
        PagesTextBox.Text = ""
        PageLabel.Text = ""
        PageTop.Text = ""
        PageLeft.Text = ""
        PageWidth.Text = ""
        PageHeight.Text = ""
        ReDim _pages(-1)
        Overview.Dispose()
        Detail.Dispose()
        DeleteFiles(TempFolder)
    End Sub

    Private Sub loadVehiceId(ByVal vehileID As Integer)
        Dim PagesCount As Integer = 0

        If VehicleId = 0 Then Return

        Try

            PagesCount = Aggregate pages In _db.Pages
                          Where pages.VehicleId = CInt(VehicleId)
                          Into Count()
        Catch
            MessageBox.Show(String.Format("VehicleID {0} not found", VehicleId))
            Exit Sub
        End Try

        ReDim _pages(PagesCount - 1)

        Dim nWidth As Integer = 0
        Dim nHeight As Integer = 0
        Dim PositionLeft As Integer = 0
        Dim ImageName As String = ""
        'Get the pages
        _fullWidth = 0
        For i As Integer = 0 To PagesCount - 1

            Dim pageObj As Page = _db.Vehicles.Single(Function(k) k.VehicleId = VehicleId).Pages.Single(Function(k) CInt(k.ReceivedOrder) = CInt(i + 1))
            ImageName = pageObj.ImageName
            If String.IsNullOrEmpty(ImageName) Then
                ImageName = CInt(pageObj.PageName).ToString("000")
            End If

            Dim pageName As String = String.Format("{0}\{1}\{2}\{3}\{4}.jpg", pageImageFolder, Format(pageObj.Vehicle.CreateDt, "yyyyMM"), VehicleId, UnsizedFolder, ImageName)

            Dim pageImge As New Bitmap(pageName)

            PositionLeft += nWidth
          
            nWidth = CInt(pageImge.Width)
            nHeight = CInt(pageImge.Height)

            'Use the page images for page definition
            _pages(CInt(pageObj.ReceivedOrder - 1)) = New Rectangle(PositionLeft, 0, CInt(pageImge.Width), CInt(pageImge.Height))
            _fullWidth = _fullWidth + nWidth

            If i = 0 And nHeight <> 0 Then
                _fullHeight = nHeight
            End If
        Next

        Dim startX As Integer = 0
        ProgressBar1.Value = 0
        ProgressBar1.Visible = True
        Cursor = Cursors.WaitCursor
        ProgressBar1.Maximum = PagesCount

        'Reset cache
        _sliceCount = 0
        For Each kvp As KeyValuePair(Of Integer, Bitmap) In sliceCache
            kvp.Value.Dispose()
        Next
        sliceCache.Clear()
        idxCache.Clear()
        sliceFiles.Clear()
        DeleteFiles(TempFolder)
        If Not _overviewImage Is Nothing Then _overviewImage.Dispose()
        _overviewImage = Nothing
        _oldSrcDetail = Nothing
        _srcRect = New Rectangle(0, 0, _srcRect.Width, _srcRect.Height)

        While startX < _fullWidth
            Dim sliceWidth As Integer = Math.Min(MaxSliceWidth, _fullWidth - startX)
            Dim sliceFile As String = String.Format("{0}\s_{1}-{2}.jpg", TempFolder, VehicleId, _sliceCount)
            Dim currentSlice As Bitmap = New Bitmap(sliceWidth, _fullHeight)

            Dim v As Vehicle = _db.Vehicles.Single(Function(k) k.VehicleId = VehicleId)
            Dim sWidth As Integer = 0
            Dim sHeight As Integer = 0
            Dim sPositionLeft As Integer = 0


            For i As Integer = 0 To PagesCount - 1
                ImageName = ""
                'Locate the page record
                Dim pageRecord As Page = _db.Pages.FirstOrDefault(Function(k) CBool(k.VehicleId = VehicleId And k.ReceivedOrder = i + 1))

                ImageName = pageRecord.ImageName
                If String.IsNullOrEmpty(ImageName) Then
                    ImageName = CInt(pageRecord.PageName).ToString("000")
                End If

                Dim tileName As String = String.Format("{0}\{1}\{2}\{3}\{4}.jpg", pageImageFolder, Format(pageRecord.Vehicle.CreateDt, "yyyyMM"), VehicleId, UnsizedFolder, ImageName)

                If IO.File.Exists(tileName) Then
                    'do my work here'
                    Dim tileBitmap As Bitmap = New Bitmap(tileName.ToString())
                    sPositionLeft += sWidth
                    sWidth = CInt(tileBitmap.Width)
                    sHeight = CInt(tileBitmap.Height)
                    Dim r As Graphics = Graphics.FromImage(currentSlice)
                    r.DrawImage(tileBitmap, New Rectangle(New Point(sPositionLeft - startX, 0), New Size(sWidth, sHeight)))
                    ProgressBar1.Increment(1)
                    tileBitmap.Dispose()

                Else
                    MsgBox("Image " + tileName + " not available. ", MsgBoxStyle.Exclamation)

                End If

            Next


            If IO.File.Exists(sliceFile) Then
                IO.File.Delete(sliceFile)
            End If

            currentSlice.Save(sliceFile)
            currentSlice.Dispose()
            sliceFiles.Add(sliceFile)
            _sliceCount = _sliceCount + 1
            startX = startX + sliceWidth
        End While
        Cursor = Cursors.Default
        ProgressBar1.Visible = False

        PagesTextBox.Text = CStr(PagesCount)
        UpdateCurrentPage(CurrentPage)
        'Form1_Resize(sender, e)
        'Redraw()

    End Sub

    Private Sub LoadConfig(sender As Object, e As EventArgs) Handles MyBase.Load
        'Get the configuration
        Dim configDb As ConfigDataContext = New ConfigDataContext()
        'Dim test = configDb.AppParameters.ToList(Of AppParameter)()

        ' Get a typed table to run queries. 
        Dim parameterValues As Table(Of AppParameter) = configDb.AppParameters

        ' Query for parameter from Parameters. 
        Dim test As List(Of AppParameter) = _
            (From cust In parameterValues _
            Select cust).ToList()

        configDb.Dispose()

        test.RemoveAll(Function(x) x.AppName <> ConfigAppName)
        Dim configValues As Dictionary(Of String, String) = test.ToDictionary(
            Function(x As AppParameter) As String
                Return x.ParamName
            End Function,
            Function(x As AppParameter) As String
                Return x.ParamValue
            End Function)
        Try
            'TileFolder = configValues("TileFolder")
            pageImageFolder = configValues("VehicleImageFolder")
            UnsizedFolder = configValues("UnsizedPageImageFolder")
            DbServerName = My.Settings.ServerName
        Catch ec As KeyNotFoundException
            MessageBox.Show(ec.Message)
        End Try
    End Sub


    Private Sub Repage(pages As Integer)
        If _sliceCount = 0 Then Return
        Dim pWidth As Integer = CInt(_fullWidth / pages)
        Dim pHeight As Integer = _fullHeight
        ReDim _pages(pages - 1)
        For i As Integer = 0 To pages - 1
            _pages(i) = New Rectangle(i * pWidth, 0, pWidth, pHeight)
        Next
        _safeToRepage = True
    End Sub

    Private Sub Redraw()
        If _sliceCount = 0 Then Return

        If _pages.Count() = 0 Then
            Repage(CInt(PagesTextBox.Text))
        End If
        If Not Overview.Image Is Nothing Then
            Overview.Image.Dispose()
        End If
        Overview.Image = New Bitmap(Overview.Width, Overview.Height)
        Dim g As Graphics = Graphics.FromImage(Overview.Image)
        For i As Integer = 0 To _pages.Count() - 1
            g.DrawRectangle(_inactivePen, ReScale(_pages(i)))
        Next
        'Draw current page last so it will be on top
        g.DrawRectangle(_activePen, ReScale(_pages(CurrentPage)))
        g.DrawRectangle(_detailPen, ReScale(_srcRect))
        g.Dispose()
        RedrawDetail()
    End Sub

    Private Sub UpdateCurrentPage(pageIndex As Integer)
        If _pages.Count() = 0 Then Return
        CurrentPage = pageIndex
        PageLabel.Text = String.Format("Page {0}", pageIndex + 1)
        PageTop.Text = CStr(_pages(pageIndex).Top)
        PageLeft.Text = CStr(_pages(pageIndex).Left)
        PageWidth.Text = CStr(_pages(pageIndex).Width)
        PageHeight.Text = CStr(_pages(pageIndex).Height)
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize, SplitContainer1.Panel1.SizeChanged
        If _sliceCount = 0 Then Return
        ' Redraw picturebox image
        Dim maxHeight As Integer = Overview.Parent.Height - 20
        Overview.Height = maxHeight
        _ratio = maxHeight / _fullHeight
        Overview.Width = CInt(_ratio * _fullWidth)
        If _overviewImage Is Nothing Then
            _overviewImage = GetBitmap(New Rectangle(0, 0, _fullWidth, _fullHeight), overscanRatio * _ratio)
            overviewRatio.Clear()
            For i As Integer = 0 To _sliceCount - 1
                overviewRatio(i) = _ratio * overscanRatio
            Next
        End If
        Overview.BackgroundImage = _overviewImage.GetThumbnailImage(Overview.Width, Overview.Height, AddressOf ThumbnailCallback, IntPtr.Zero)
        'only redraw the cached slices for speed
        Dim g As Graphics = Graphics.FromImage(Overview.BackgroundImage)
        For Each kvp As KeyValuePair(Of Integer, Bitmap) In sliceCache
            If overviewRatio(kvp.Key) < _ratio Then
                g.DrawImage(kvp.Value, New Rectangle(CInt(kvp.Key * MaxSliceWidth * _ratio), 0, CInt(kvp.Value.Width * _ratio), CInt(kvp.Value.Height * _ratio)), New Rectangle(0, 0, kvp.Value.Width, kvp.Value.Height), GraphicsUnit.Pixel)
            End If
        Next
        If (_overviewImage.Height < Overview.BackgroundImage.Height) Then
            _overviewImage.Dispose()
            _overviewImage = CType(Overview.BackgroundImage, Bitmap)
        End If

        'Scroll the active area into view
        If SplitContainer1.Panel1.HorizontalScroll.Enabled Then
            'Midpoint of active area
            Dim m As Integer = CInt((_srcRect.X + _srcRect.Width * 0.5) * _ratio)
            'Midpoint of visible overview
            Dim n As Integer = CInt(Overview.Parent.Width / 2)
            Dim j As Integer = Math.Max(Math.Min(m - n, SplitContainer1.Panel1.HorizontalScroll.Maximum), SplitContainer1.Panel1.HorizontalScroll.Minimum)
            SplitContainer1.Panel1.HorizontalScroll.Value = j
        End If

        Redraw()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Dim numPages As Integer
        If Int32.TryParse(PagesTextBox.Text, numPages) And numPages <> _pages.Count() Then
            If Not _safeToRepage Then
                Dim dr As DialogResult = MessageBox.Show("You will lose any custom changes if you continue", "Repage", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
                If dr = DialogResult.Cancel Then
                    PagesTextBox.Text = CStr(_pages.Count())
                    Return
                End If
            End If
            Repage(numPages)
            Redraw()
        End If
        DeleteCurrentPageToolStripMenuItem.Enabled = (numPages > 1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If _sliceCount = 0 Then Return

        If _safeToAddpage = True And PageWidth.Text = "0" Then
            MessageBox.Show("Please add width for new image and update cordinates.", "MCAP", MessageBoxButtons.OK)
            PageWidth.Focus()
            Exit Sub
        End If

        ' Encoder parameter for image quality
        Dim qualityParam As New EncoderParameter(Encoder.Quality, 75)
        ' Jpeg image codec 
        Dim jpegCodec As ImageCodecInfo = GetEncoderInfo("image/jpeg")

        Dim encoderParams As New EncoderParameters(1)
        encoderParams.Param(0) = qualityParam
        Dim v As Vehicle = _db.Vehicles.Single(Function(k) k.VehicleId = VehicleId)
        Dim imageName As String = ""

        For i As Integer = 0 To _pages.Count() - 1
            'Locate the page record
            Dim pageRect As Rectangle = _pages(i)
            Dim pageRecord As Page = _db.Pages.FirstOrDefault(Function(k) CBool(k.VehicleId = VehicleId And k.ReceivedOrder = i + 1))
           
            If pageRecord Is Nothing Then
                'Create additional page
                pageRecord = New Page()

                If IsDBNull(pageRecord.ImageName) Then
                    _db.mt_proc_GetNewId(DbServerName, imageName)
                Else
                    imageName = (i + 1).ToString("000")
                End If

                pageRecord.PageName = CStr(i + 1)
                pageRecord.ReceivedOrder = i + 1
                pageRecord.Vehicle = v
                pageRecord.PageTypeId = "B"
                pageRecord.PixelHieght = pageRect.Height
                pageRecord.PixelWidth = pageRect.Width
                pageRecord.SizeID = 1
                _db.Pages.InsertOnSubmit(pageRecord)
            Else
                imageName = pageRecord.ImageName
                If String.IsNullOrEmpty(imageName) Then
                    imageName = CInt(pageRecord.PageName).ToString("000")
                End If
            End If
            Dim filename As String = String.Format("{0}\{1}\{2}\{3}\{4}.jpg", pageImageFolder, Format(pageRecord.Vehicle.CreateDt, "yyyyMM"), VehicleId, UnsizedFolder, imageName)
            If pageRect.IsEmpty Then
                Exit For
            End If
            Dim pageImage As Bitmap = GetBitmap(pageRect)
            pageImage.Save(filename, jpegCodec, encoderParams)
        Next
        'Remove Extra pages
        _db.Pages.DeleteAllOnSubmit(v.Pages.Where(Function(k) CBool(k.ReceivedOrder > _pages.Count())))

        _db.SubmitChanges()
        MessageBox.Show("Database changes committed")
        loadVehiceId(VehicleId)
        Form1_Resize(sender, e)
        Redraw()
        _safeToAddpage = False
    End Sub

    Private Function ReScale(rec As Rectangle) As Rectangle
        Return New Rectangle(CInt(rec.Left * _ratio), CInt(rec.Top * _ratio), CInt(rec.Width * _ratio), CInt(rec.Height * _ratio))
    End Function

    ' Returns the image codec with the given mime type 
    Private Shared Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
        ' Get image codecs for all image formats 
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()

        ' Find the correct image codec 
        For i As Integer = 0 To codecs.Length - 1
            If (codecs(i).MimeType = mimeType) Then
                Return codecs(i)
            End If
        Next i

        Return Nothing
    End Function



    Private Sub Overview_MouseMove(sender As Object, e As MouseEventArgs) Handles Overview.MouseMove
        Static skipper As Integer = 0
        If Not _mouseTrack Then Return
        If (Detail.Image Is Nothing) Then Return
        If (_ratio < 0.0001) Then Return
        'Show detail window
        _srcRect.X = CInt(e.X / _ratio) - (CInt(Detail.Width / 2))
        _srcRect.Y = CInt(e.Y / _ratio - (Detail.Height / 2))
        Dim center As Point = New Point(CInt(e.X / _ratio), CInt(e.Y / _ratio))
        If Not _pages(CurrentPage).Contains(center) Then
            'Update current page
            For i As Integer = 0 To _pages.Count() - 1
                If _pages(i).Contains(center) Then
                    UpdateCurrentPage(i)
                    Redraw()
                    Exit For
                End If
            Next
        End If
        If (skipper = 1) Then
            Redraw()
        End If
        skipper = (skipper + 1) Mod frameskip
    End Sub

    Private Function GetBitmap(area As Rectangle, Optional scale As Double = 1.0) As Bitmap
        Dim pageImage As Bitmap = New Bitmap(CInt(area.Width * scale), CInt(area.Height * scale))
        Dim g3 As Graphics = Graphics.FromImage(pageImage)
        Dim i As Integer = CInt(Math.Floor(area.X / MaxSliceWidth))
        Dim dX As Double = 0.0
        If area.X < 0 Then
            i = 0
            dX = -area.X
        End If
        Dim x As Integer = i * MaxSliceWidth
        For j As Integer = i To _sliceCount - 1
            Dim currentSlice As Bitmap = GetSlice(j)
            If currentSlice Is Nothing Then Continue For
            Dim w As Integer = currentSlice.Width
            'Adjust the rectangle to the huge image slice
            Dim sX As Double = area.X - x
            'If the start of the rectangle is beyond the slice then skip it (far right)
            If sX > w Then Continue For
            'The rectangle can be no wider than the remaining slice width
            Dim adjustedW As Double = area.Width
            If sX < 0 Then
                'The page rectangle starts before the current slice; modify the page rectangle
                adjustedW = area.Width + sX
                sX = 0
            End If
            'page rectangle is far left
            If adjustedW <= 0 Then Continue For
            'Shorten rectangle if too wide for the slice
            adjustedW = Math.Min(w - sX, adjustedW)
            'if we get this far draw the image
            g3.DrawImage(currentSlice, New Rectangle(CInt(dX), 0, CInt(adjustedW * scale), CInt(area.Height * scale)), New Rectangle(CInt(sX), area.Y, CInt(adjustedW), area.Height), GraphicsUnit.Pixel)
            dX = dX + adjustedW * scale
            x = x + w
            If x > area.Right Then Exit For
        Next
        Return pageImage
    End Function

    Private Sub RedrawDetail()
        If _srcRect.Width * _srcRect.Height = 0 Then Return
        Dim newBitmap As Bitmap = New Bitmap(_srcRect.Width, _srcRect.Height)
        Dim g3 As Graphics = Graphics.FromImage(newBitmap)
        'Draw previous and next pages
        For i As Integer = CurrentPage - 1 To CurrentPage + 1 Step 2
            If i >= 0 And i < _pages.Count() Then
                g3.DrawRectangle(_inactivePen, PageRectangle(i))
            End If
        Next
        g3.DrawRectangle(_activePen, PageRectangle(CurrentPage))
        'Setup resize zones
        SetupResizeZones(PageRectangle(CurrentPage))
        Detail.Image = newBitmap
        Detail.Width = _srcRect.Width
        Detail.Height = _srcRect.Height
        g3.Dispose()
        If (_oldSrcDetail <> _srcRect) Then
            'Redraw bg image
            Detail.BackgroundImage = GetBitmap(_srcRect)
            _oldSrcDetail = _srcRect
        End If
    End Sub

    Private Function PageRectangle(pageIdx As Integer) As Rectangle
        Return New Rectangle(_pages(pageIdx).X - _srcRect.X, _pages(pageIdx).Y - _srcRect.Y, _pages(pageIdx).Width, _pages(pageIdx).Height)
    End Function

    Private Sub SetupResizeZones(page As Rectangle)
        'page is already relative to the detail viewport
        'Reset all drag zones
        DragZones.Clear()
        If page.Left > 0 Then
            DragZones.Add("left", New Rectangle(page.Left - 5, page.Top + 5, 10, page.Height - 10))
        End If
        If page.Right < Detail.Width Then
            DragZones.Add("right", New Rectangle(page.Right - 5, page.Top + 5, 10, page.Height - 10))
        End If
        If page.Top > 0 Then
            DragZones.Add("top", New Rectangle(page.Left + 5, page.Top - 5, page.Width - 10, 10))
        End If
        If page.Bottom < Detail.Height Then
            DragZones.Add("bottom", New Rectangle(page.Left + 5, page.Bottom - 5, page.Width - 10, 10))
        End If
        If DragZones.ContainsKey("right") And DragZones.ContainsKey("top") Then
            DragZones.Add("topright", New Rectangle(page.Right - 5, page.Top - 10, 15, 15))
        End If
        If DragZones.ContainsKey("left") And DragZones.ContainsKey("top") Then
            DragZones.Add("topleft", New Rectangle(page.Left - 10, page.Top - 10, 15, 15))
        End If
        If DragZones.ContainsKey("right") And DragZones.ContainsKey("bottom") Then
            DragZones.Add("bottomright", New Rectangle(page.Right - 5, page.Bottom - 5, 15, 15))
        End If
        If DragZones.ContainsKey("left") And DragZones.ContainsKey("bottom") Then
            DragZones.Add("bottomleft", New Rectangle(page.Left - 10, page.Bottom - 5, 15, 15))
        End If
    End Sub

    Private Sub Detail_Resize(sender As Object, e As EventArgs) Handles Detail.Resize, SplitContainer1.Panel2.Resize
        If _sliceCount = 0 Then Return
        Dim maxHeight As Integer = Detail.Parent.Height
        Dim maxWidth As Integer = Detail.Parent.Width
        If Detail.Height = maxHeight And Detail.Width = maxWidth Then Return

        Try
            Dim newImage As Bitmap = New Bitmap(maxWidth, maxHeight)
            Dim g3 As Graphics = Graphics.FromImage(newImage)
            _srcRect = New Rectangle(_srcRect.X, _srcRect.Y, maxWidth, maxHeight)
            Detail.Width = maxWidth
            Detail.Height = maxHeight
        Catch
            'Always redraw in case of error
        End Try
        Redraw()
    End Sub

    Private Sub PageTop_TextChanged(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If VehicleId = 0 Then Exit Sub
        Dim x, y, w, h As Integer
        If Int32.TryParse(PageTop.Text, y) And Int32.TryParse(PageLeft.Text, x) And Int32.TryParse(PageWidth.Text, w) And Int32.TryParse(PageHeight.Text, h) Then
            _pages(CurrentPage) = New Rectangle(x, y, w, h)
            Redraw()
        End If
        _safeToRepage = False
    End Sub

    Private Sub Detail_MouseMove(sender As Object, e As MouseEventArgs) Handles Detail.MouseMove
        Dim position As Point = New Point(e.X, e.Y)
        'Dim page As Rectangle = _pages(CurrentPage)

        _dragType = String.Empty
        For Each dragZone As KeyValuePair(Of String, Rectangle) In DragZones
            If dragZone.Value.Contains(position) Then
                _dragType = dragZone.Key
                Exit For
            End If
        Next

        Select Case _dragType
            Case "left", "right"
                Detail.Cursor = Cursors.SizeWE
            Case "top", "bottom"
                Detail.Cursor = Cursors.SizeNS
            Case "topright", "bottomleft"
                Detail.Cursor = Cursors.SizeNESW
            Case "topleft", "bottomright"
                Detail.Cursor = Cursors.SizeNWSE
            Case Else
                Detail.Cursor = Cursors.Cross

        End Select

        ImagePosition.Text = String.Format("{0},{1}", e.X + _srcRect.X, e.Y + _srcRect.Y)
    End Sub

    Private Sub Overview_MouseDown(sender As Object, e As MouseEventArgs) Handles Overview.MouseDown
        _mouseTrack = True
        Overview_MouseMove(sender, e)
    End Sub

    Private Sub Overview_MouseUp(sender As Object, e As MouseEventArgs) Handles Overview.MouseUp
        _mouseTrack = False
        Redraw()
    End Sub

    Private Sub Detail_Drag(sender As Object, e As MouseEventArgs)
        Static skipper As Integer = 0
        If Not _pages.Any() Then Return
        Dim dX As Integer = e.X - _dragStart.X
        Dim dY As Integer = e.Y - _dragStart.Y
        Dim mousePoint As Point = New Point(e.X, e.Y)
        Dim oldPage As Rectangle = _pages(CurrentPage)

        Select Case _dragType
            Case "left"
                _pages(CurrentPage) = New Rectangle(oldPage.X + dX, oldPage.Y, oldPage.Width - dX, oldPage.Height)
            Case "right"
                _pages(CurrentPage) = New Rectangle(oldPage.X, oldPage.Y, oldPage.Width + dX, oldPage.Height)
            Case "top"
                _pages(CurrentPage) = New Rectangle(oldPage.X, oldPage.Y + dY, oldPage.Width, oldPage.Height - dY)
            Case "bottom"
                _pages(CurrentPage) = New Rectangle(oldPage.X, oldPage.Y, oldPage.Width, oldPage.Height + dY)
            Case "bottomright"
                _pages(CurrentPage) = New Rectangle(oldPage.X, oldPage.Y, oldPage.Width + dX, oldPage.Height + dY)
            Case "topleft"
                _pages(CurrentPage) = New Rectangle(oldPage.X + dX, oldPage.Y + dY, oldPage.Width - dX, oldPage.Height - dY)
            Case "bottomleft"
                _pages(CurrentPage) = New Rectangle(oldPage.X + dX, oldPage.Y, oldPage.Width - dX, oldPage.Height + dY)
            Case "topright"
                _pages(CurrentPage) = New Rectangle(oldPage.X, oldPage.Y + dY, oldPage.Width + dX, oldPage.Height - dY)

            Case Else
                'Move case
                _srcRect = New Rectangle(_srcRect.X + _dragStart.X - mousePoint.X, _srcRect.Y + _dragStart.Y - mousePoint.Y, _srcRect.Width, _srcRect.Height)
                skipper += 1
        End Select


        _dragStart = mousePoint
        If (_dragType <> String.Empty Or skipper Mod frameskip = 0) Then Redraw()
    End Sub

    Private Sub Detail_MouseDown(sender As Object, e As MouseEventArgs) Handles Detail.MouseDown
        'Start Drag
        _dragStart = New Point(e.X, e.Y)

        'Unbind normal mousemove event
        RemoveHandler Detail.MouseMove, AddressOf Detail_MouseMove
        AddHandler Detail.MouseMove, AddressOf Detail_Drag
    End Sub

    Private Sub Detail_MouseUp(sender As Object, e As MouseEventArgs) Handles Detail.MouseUp
        If _safeToRepage And _dragType <> String.Empty Then _safeToRepage = False
        UpdateCurrentPage(CurrentPage)
        RemoveHandler Detail.MouseMove, AddressOf Detail_Drag
        AddHandler Detail.MouseMove, AddressOf Detail_MouseMove
    End Sub

    Private Sub DeleteCurrentPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteCurrentPageToolStripMenuItem.Click
        If _pages.Count() <= 1 Then Return
        Dim newPageList As List(Of Rectangle) = _pages.ToList()
        newPageList.RemoveAt(CurrentPage)
        If CurrentPage >= newPageList.Count Then CurrentPage = newPageList.Count - 1
        _pages = newPageList.ToArray()
        PagesTextBox.Text = CStr(_pages.Count())
        UpdateCurrentPage(CurrentPage)
        Redraw()
        _safeToRepage = False
    End Sub

    Private Sub ViewCurrentPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewCurrentPageToolStripMenuItem.Click
        Dim chromeHeight As Integer = 38
        Dim chromeWidth As Integer = 16
        Dim thisPage As Rectangle = _pages(CurrentPage)
        Dim screenArea As Rectangle = Screen.PrimaryScreen.WorkingArea
        Dim scaleFactor As Double = Math.Min(CDbl(screenArea.Height - chromeHeight) / thisPage.Height, CDbl(screenArea.Width - chromeWidth) / thisPage.Width)
        Dim viewer As Form = New Form()
        viewer.Height = CInt(thisPage.Height * scaleFactor + chromeHeight)
        viewer.Width = CInt(thisPage.Width * scaleFactor + chromeWidth)
        Dim pb As PictureBox = New PictureBox()
        pb.Parent = viewer
        pb.Dock = DockStyle.Fill
        pb.Image = GetBitmap(_pages(CurrentPage), scaleFactor)

        viewer.Show()
    End Sub

    Private Sub AddPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddPageToolStripMenuItem.Click
        Dim newPage As Rectangle = GuessPageRect()
        Dim newPageList As List(Of Rectangle) = _pages.ToList()
        newPageList.Add(newPage)
        _pages = newPageList.OrderBy(Function(k) k.Left).ToArray()
        PagesTextBox.Text = CStr(_pages.Count())
        For i As Integer = 0 To _pages.Count() - 1
            If _pages(i) = newPage Then
                UpdateCurrentPage(i)
                Exit For
            End If
        Next
        Redraw()
        _safeToRepage = False
    End Sub

    Private Function GuessPageRect() As Rectangle
        'Let's try to make an educated guess about where the page should go
        Dim values As Dictionary(Of String, Integer()) = New Dictionary(Of String, Integer())()
        Dim properties As String() = {"Top", "Width", "Height"}
        For Each prop As String In properties
            values(prop) = _pages.Select(Function(k) CInt(CallByName(k, prop, CallType.Get, Nothing))).ToArray()
        Next
        Dim y As Integer = values("Top")(0)
        Dim h As Integer = values("Height")(0)
        Dim maxW As Integer = values("Width").Max(Of Integer)(Function(k) k)
        Dim x As Integer = _srcRect.X + 10
        Dim w As Integer = _srcRect.Width - 20
        If (values("Top").All(Function(k) k = y) And values("Height").All(Function(k) k = h)) Then
            'Top and height always same; just get w and x
            'Find a left-right gap 
            Dim maxGap As Integer = 0
            Dim sortedPages As Rectangle() = _pages.OrderBy(Function(k) k.Left).ToArray()
            Dim currentGap As Integer = 0
            Dim leftPosition As Integer = 0
            Dim gapStart As Integer = 0
            Dim pageIdx As Integer = 0
            While pageIdx <= sortedPages.Count()
                If pageIdx < sortedPages.Count() Then
                    currentGap = sortedPages(pageIdx).Left - leftPosition
                Else
                    currentGap = _fullWidth - leftPosition
                End If
                If currentGap > maxGap Then
                    maxGap = currentGap
                    gapStart = leftPosition
                End If
                If pageIdx >= sortedPages.Count() Then Exit While
                leftPosition = sortedPages(pageIdx).Right
                pageIdx += 1
            End While
            If maxGap > maxW Then
                w = maxW
                x = CInt(gapStart + (maxGap - maxW) / 2)
            Else
                w = maxGap
                x = gapStart
            End If
        Else
            ' Make box fit in Detail window
            y = _srcRect.Top - 10
            h = _srcRect.Height - 20
        End If
        Return New Rectangle(x, y, w, h)
    End Function

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click

        If SplitContainer1.Orientation = Orientation.Horizontal Then
            SplitContainer1.Orientation = Orientation.Vertical
        Else
            SplitContainer1.Orientation = Orientation.Horizontal
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click

        If VehicleId = 0 Then
            ToolStripTextBox1.Focus()
            Exit Sub
        End If

        If (MessageBox.Show("Image will be Added", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        End If

        Dim newPage As Rectangle = GuessPageRect()
        Dim newPageList As List(Of Rectangle) = _pages.ToList()
        newPageList.Add(newPage)
        '_pages = newPageList.OrderBy(Function(k) k.Left).ToArray()
        _pages = newPageList.ToArray()
        PagesTextBox.Text = CStr(_pages.Count())

        For i As Integer = 0 To _pages.Count() - 1
            If _pages(i) = newPage Then
                UpdateCurrentPage(i)
                Exit For
            End If
        Next
        PageLeft.Text = _fullWidth.ToString
        Redraw()
        _safeToRepage = False
        _safeToAddpage = True
        MessageBox.Show("Please Edit Cordinates and Save to create Image.", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
        PageWidth.Focus()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click

        If VehicleId = 0 Then Exit Sub

        If (MessageBox.Show("Image will be removed", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
            Exit Sub
        End If
        If _pages.Count() <= 1 Then Return
        Dim newPageList As List(Of Rectangle) = _pages.ToList()
        newPageList.RemoveAt(CurrentPage)
        If CurrentPage >= newPageList.Count Then CurrentPage = newPageList.Count - 1
        _pages = newPageList.ToArray()
        PagesTextBox.Text = CStr(_pages.Count())
        UpdateCurrentPage(CurrentPage)

        Dim v As Vehicle = _db.Vehicles.Single(Function(k) k.VehicleId = VehicleId)

        'Remove Extra pages
        _db.Pages.DeleteAllOnSubmit(v.Pages.Where(Function(k) CBool(k.ReceivedOrder > _pages.Count())))

        _db.SubmitChanges()

        loadVehiceId(VehicleId)
        Form1_Resize(sender, e)
        Redraw()
        _safeToRepage = False
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        If VehicleId = 0 Then Exit Sub

        If _safeToAddpage = True Then
            If (MessageBox.Show("New Image will be disregarded", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            End If
            Dim newPageList As List(Of Rectangle) = _pages.ToList()
            newPageList.RemoveAt(CurrentPage)
            If CurrentPage >= newPageList.Count Then CurrentPage = newPageList.Count - 1
            _pages = newPageList.ToArray()
            PagesTextBox.Text = CStr(_pages.Count())
            UpdateCurrentPage(CurrentPage)
        End If
        loadVehiceId(VehicleId)
        Form1_Resize(sender, e)
        Redraw()
    End Sub
End Class