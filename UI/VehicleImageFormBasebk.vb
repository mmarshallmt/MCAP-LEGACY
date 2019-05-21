﻿Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Object
Imports System.Math
Namespace UI

    Public Class VehicleImageFormBase


        Private m_isZoomedIn As Boolean = True
        Private m_RetainZoom As Boolean
        Private m_askForSave As Boolean
        Private m_isPageCropNavigation As Boolean
        Private m_leftRotationCounter As Integer
        Private m_rightRotationCounter As Integer
        Private m_imageScale As Single
        Private m_adSizeRectangle As System.Drawing.RectangleF
        Private m_adSize As System.Drawing.SizeF

        Private cropWidth As Integer
        Public myGraphics As Graphics
        Private cropHeight As Integer
        Private cropX As Integer
        Private cropY As Integer
        Private cropPen As Pen
        Private cropPenSize As Integer = 2 '2
        Private cropDashStyle As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid
        Private cropPenColor As Color = Color.Black
        Private cropBitmap As Bitmap
        Private ctrCrop As Integer
        Private SelectionBoxObj As New SelectionBox()
        Private SelectedObjPoint As Point
        Private DrawRectEnable As Boolean = False
        Private doesRectangleExist As Boolean

        Private Temp_img As Bitmap
        Private oWidth As Integer
        Private oHeight As Integer
        Private _RegPic As Bitmap
        Private _CurrentImage As Bitmap
        Private _Path As String

        Private CurrentWidth As Integer
        Private CurrentHeight As Integer
        Private NewWidth As Integer
        Private NewHeight As Integer
        Private actualHeight As Integer
        Private actualWidth As Integer
        Private _AddedWidth As Integer
        Private _AddedHeight As Integer

        Private DeductedHeight As Integer
        Private _scale As Integer
        Private keepRectangle As Boolean = False
        Private isRectRemoved As Boolean = False
        Private isRectDrawn As Boolean = False
        ''' <summary>
        ''' Gets or sets flag indicating whether displayed image is zoomed in or not.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property IsZoomedIn() As Boolean
            Get
                Return m_isZoomedIn
            End Get
            Set(ByVal value As Boolean)
                m_isZoomedIn = value
            End Set
        End Property

        Protected Property RetainZoom() As Boolean
            Get
                Return m_RetainZoom
            End Get
            Set(ByVal value As Boolean)
                m_RetainZoom = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets flag indicating whether to ask user for saving displayed image or not.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks>This flag is set to true in mainAxLead control's change event. 
        ''' So, when any change is made to the displayed image, the flag becomes true.</remarks>
        Protected Property AskToSaveImage() As Boolean
            Get
                Return m_askForSave
            End Get
            Set(ByVal value As Boolean)
                m_askForSave = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets flag indicating whether to navigate vehicle images or PageCrop table records.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property IsPageCropNavigation() As Boolean
            Get
                Return m_isPageCropNavigation
            End Get
            Set(ByVal value As Boolean)
                m_isPageCropNavigation = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets number of times image has been rotated anticlock wise.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property AnticlockWiseRotationCounter() As Integer
            Get
                Return m_leftRotationCounter
            End Get
            Set(ByVal value As Integer)
                m_leftRotationCounter = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets number of times image has been rotated clock wise.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property ClockWiseRotationCounter() As Integer
            Get
                Return m_rightRotationCounter
            End Get
            Set(ByVal value As Integer)
                m_rightRotationCounter = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets scale for image currently displayed on control.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Protected Property ImageScale() As Single
            Get
                Return m_imageScale
            End Get
            Set(ByVal value As Single)
                m_imageScale = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets rectangle area of the ad image. Size is later recorced into co-ordinate columns in 
        ''' PageCrop table.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Property AdRectangle() As System.Drawing.RectangleF
            Get
                Return m_adSizeRectangle
            End Get
            Set(ByVal value As System.Drawing.RectangleF)
                m_adSizeRectangle = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets size, in inches, of cropped image. Size is later used for sizeId column in PageCrop table.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Property AdSize() As System.Drawing.SizeF
            Get
                Return m_adSize
            End Get
            Set(ByVal value As System.Drawing.SizeF)
                m_adSize = value
            End Set
        End Property



#Region " Functions to show image "

        ''' <summary>
        ''' Loads specified image file.
        ''' </summary>
        ''' <param name="imageFilePath"></param>
        ''' <remarks>
        ''' This method is created specifically to allow loading image on control 
        ''' without displaying on screen. For example, QC Completed button.
        ''' </remarks>
        Protected Sub LoadImage(ByVal imageFilePath As String)
      ImageDisplay.ImageLocation = imageFilePath '"C:\28565562\Unsized\001.jpg"
        End Sub

        ''' <summary>
        ''' Displays specified image file on screen.
        ''' </summary>
        ''' <param name="imageFilePath"></param>
        ''' <remarks></remarks>
        Protected Overloads Sub ShowImage(ByVal imageFilePath As String)
            LoadImage(imageFilePath)
        End Sub

        ''' <summary>
        ''' Displays image on screen based on supplied image folder path and image file name.
        ''' </summary>
        ''' <param name="imageFolderPath"></param>
        ''' <param name="imageName"></param>
        ''' <exception cref="System.ApplicationException">
        ''' When image file is not found at specified location, raises exception with message - "Image file not found."
        ''' </exception>
        ''' <remarks></remarks>
        Protected Overloads Sub ShowImage(ByVal imageFolderPath As String, ByVal imageName As String)
            Dim imagePath As String

            ImageDisplay.Image = Nothing
            imagePath = imageFolderPath + "\" + imageName + ImageFileExtension

            If System.IO.File.Exists(imagePath) = False Then
                'Throw New System.ApplicationException("Image file not found: " + Environment.NewLine + imagePath)
                MessageBox.Show("Image file not found: " + Environment.NewLine + imagePath, _
        "Important Note", _
        MessageBoxButtons.OK, _
        MessageBoxIcon.Error, _
        MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            ShowImage(imagePath)

            imagePath = Nothing

        End Sub

#End Region



        Private Function SaveImage(ByVal img As Image, ByVal FName As String) As String
            Try
                If lblisRotatedBy.Text = "false" Then
                    Dim FileToSave As Bitmap = New Bitmap(img)
                    Dim ImgC As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
                    Dim MyEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
                    Dim myEncoderParameters As New EncoderParameters(1)
                    Dim myEncoderParameter As EncoderParameter = New EncoderParameter(MyEncoder, 97L)

                    myEncoderParameters.Param(0) = myEncoderParameter
                    FileToSave.Save(FName, ImgC, myEncoderParameters)
                    FileToSave.Dispose()
                Else
                    img.Save(FName)
                    lblisRotatedBy.Text = "false"
                End If
            Catch ex As Exception
                MsgBox(Err.Description)
            End Try
        End Function


        Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo

            Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()

            Dim codec As ImageCodecInfo
            For Each codec In codecs
                If codec.FormatID = format.Guid Then
                    Return codec
                End If
            Next codec
            Return Nothing

        End Function

        Private Function Sharpen(ByVal ImageToSharpen As Bitmap) As Bitmap

            Dim fpixel, secpixel As Color
            Dim NewImg As Bitmap = New Bitmap(ImageToSharpen)
            Dim CR, CB, CG As Integer
            Dim x, y As Integer

            For x = 0 To NewImg.Width - 2
                For y = 0 To NewImg.Height - 2
                    fpixel = NewImg.GetPixel(x, y)
                    secpixel = NewImg.GetPixel(x + 1, y)
                    Dim newR, newB, newG As Integer
                    newR = CInt(fpixel.R) - CInt(secpixel.R)
                    newB = CInt(fpixel.B) - CInt(secpixel.B)
                    newG = CInt(fpixel.G) - CInt(secpixel.G)
                    Dim strength As Double = -1.4
                    CR = (CInt(newR * strength) + fpixel.R)
                    CG = (CInt(newG * strength) + fpixel.G)
                    CB = (CInt(newB * strength) + fpixel.B)

                    If CR > 255 Then
                        CR = 255
                    End If
                    If CR < 0 Then
                        CR = 0

                    End If
                    If CB > 255 Then
                        CB = 255
                    End If
                    If CB < 0 Then
                        CB = 0
                    End If

                    If CG > 255 Then
                        CG = 255
                    End If

                    If CG < 0 Then
                        CG = 0
                    End If

                    NewImg.SetPixel(x, y, Color.FromArgb(CR, CG, CB))
                    NewImg.SetResolution(1600, 1200)
                Next
            Next

            Return NewImg
        End Function
    Private Sub RecalculateScale()
      Dim ScaleInt As Integer
      Dim widthRatio As Double
      Dim heightRatio As Double


      widthRatio = OutputPictureBox.Width / ImagePanel.Width
      heightRatio = OutputPictureBox.Height / ImagePanel.Height


      If widthRatio > heightRatio Then
        ScaleInt = CType((100 / widthRatio) - 0.5, Integer)
        ' If lblisRotatedBy.Text = "false" Then ScaleInt = CType(100 / widthRatio, Integer)
      Else
        ScaleInt = CType((100 / heightRatio) - 0.5, Integer)
        ' If lblisRotatedBy.Text = "false" Then ScaleInt = CType(100 / widthRatio, Integer)
      End If


      _scale = ScaleInt
    End Sub
    Private Function AdjustImageToRetainRatio() As Bitmap
      Dim _GenImage As Bitmap '= New Bitmap(ImageDisplay.Image)
      RecalculateScale()
      _GenImage = ZoomImage(OutputPictureBox.Image, _scale)

            Return _GenImage
        End Function


    'If Me.Width < actualWidth Or Me.Width > actualWidth Then
    '  If Me.Name.ToString = "QCForm" Then
    '    If Me.Height < 400 Then
    '      _GenImage = CheckHeight(Me.Name.ToString)
    '    ElseIf Me.Width >= 1081 Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 50)
    '    ElseIf (Me.Width < 1081 And Me.Width >= 1031) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 45)
    '    ElseIf (Me.Width < 1031 And Me.Width >= 981) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 40)
    '    ElseIf (Me.Width < 981 And Me.Width >= 931) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 35)
    '    ElseIf (Me.Width < 931 And Me.Width >= 881) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 30)
    '    ElseIf (Me.Width < 881 And Me.Width >= 831) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 25)
    '    ElseIf (Me.Width < 831 And Me.Width >= 781) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 20)
    '    ElseIf (Me.Width < 781 And Me.Width >= 731) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 15)
    '    ElseIf (Me.Width < 731 And Me.Width >= 681) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 10)
    '    ElseIf (Me.Width < 681 And Me.Width >= 631) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 5)
    '    ElseIf (Me.Width < 631) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 3)
    '    End If
    '  Else
    '    If Me.Height < 400 Then
    '      _GenImage = CheckHeight(Me.Name.ToString)
    '    ElseIf Me.Width >= 1081 Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 50)
    '    ElseIf (Me.Width < 1081 And Me.Width >= 1011) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 45)
    '    ElseIf (Me.Width < 1011 And Me.Width >= 941) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 40)
    '    ElseIf (Me.Width < 941 And Me.Width >= 871) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 35)
    '    ElseIf (Me.Width < 871 And Me.Width >= 801) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 30)
    '    ElseIf (Me.Width < 801 And Me.Width >= 731) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 28)
    '    ElseIf (Me.Width < 731 And Me.Width >= 661) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 20)
    '    ElseIf (Me.Width < 661 And Me.Width >= 591) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 16)
    '    ElseIf (Me.Width < 591 And Me.Width >= 521) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 13)
    '    ElseIf (Me.Width < 521 And Me.Width >= 451) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 5)
    '    ElseIf (Me.Width < 451) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 3)
    '    End If
    '  End If
    'ElseIf Me.Height < actualHeight Or Me.Height > actualHeight Then
    '  If Me.Name.ToString = "QCForm" Then
    '    If Me.Width < 800 Then
    '      _GenImage = CheckWidth(Me.Name.ToString)
    '    ElseIf Me.Height >= 816 Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 50)
    '    ElseIf (Me.Height <= 816 And Me.Height > 800) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 45)
    '    ElseIf (Me.Height <= 800 And Me.Height > 700) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 40)
    '    ElseIf (Me.Height <= 700 And Me.Height > 600) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 35)
    '    ElseIf (Me.Height <= 600 And Me.Height > 500) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 30)
    '    ElseIf (Me.Height <= 500 And Me.Height > 400) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 25)
    '    ElseIf (Me.Height <= 400 And Me.Height > 300) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 20)
    '    ElseIf (Me.Height <= 300 And Me.Height > 200) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 15)
    '    ElseIf (Me.Height <= 200 And Me.Height > 100) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 10)
    '    ElseIf (NewHeight <= 100) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 5)
    '    End If
    '  Else
    '    If Me.Width < 800 Then
    '      _GenImage = CheckWidth(Me.Name.ToString)
    '    ElseIf Me.Height >= 816 Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 50)
    '    ElseIf (Me.Height <= 816 And Me.Height > 800) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 45)
    '    ElseIf (Me.Height <= 800 And Me.Height > 700) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 40)
    '    ElseIf (Me.Height <= 700 And Me.Height > 600) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 35)
    '    ElseIf (Me.Height <= 600 And Me.Height > 500) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 30)
    '    ElseIf (Me.Height <= 500 And Me.Height > 400) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 25)
    '    ElseIf (Me.Height <= 400 And Me.Height > 300) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 20)
    '    ElseIf (Me.Height <= 300 And Me.Height > 200) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 15)
    '    ElseIf (Me.Height <= 200 And Me.Height > 100) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 10)
    '    ElseIf (NewHeight <= 100) Then
    '      If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 5)
    '    End If
    '  End If
    'End If
    'Return _GenImage
    ' End Function

    'Public Function CheckHeight(ByVal _form As String) As Bitmap
    '    Dim _GenImage As Bitmap
    '    If Me.Width < 1081 And OutputPictureBox.Height > 2000 And Me.Height < 600 Then
    '        _GenImage = ZoomImage(OutputPictureBox.Image, 8)
    '    ElseIf (Me.Height >= 816 And Me.Width >= 1081) Or (Me.Height >= 816 And (Me.Width < 1081 And Me.Width >= 1031)) Or _
    '       (Me.Height >= 816 And (Me.Width < 1031 And Me.Width >= 981)) Or (Me.Height >= 816 And (Me.Width < 981 And Me.Width >= 931)) Or _
    '       (Me.Height >= 816 And (Me.Width < 931 And Me.Width >= 881)) Or (Me.Height >= 816 And (Me.Width < 881 And Me.Width >= 831)) Or _
    '       (Me.Height >= 816 And (Me.Width < 831 And Me.Width >= 781)) Or (Me.Height >= 816 And (Me.Width < 781 And Me.Width >= 731)) Or _
    '       (Me.Height >= 816 And (Me.Width < 731 And Me.Width >= 681)) Or (Me.Height >= 816 And (Me.Width < 681 And Me.Width >= 631)) Or _
    '       (Me.Height >= 816 And (Me.Width < 631)) Then
    '        _GenImage = ZoomImage(OutputPictureBox.Image, 50)
    '    ElseIf ((Me.Height <= 816 And Me.Height > 800) And Me.Width >= 1081) Or ((Me.Height <= 816 And Me.Height > 800) And (Me.Width < 1081 And Me.Width >= 1031)) Or ((Me.Height <= 816 And Me.Height > 800) And (Me.Width < 1031 And Me.Width >= 981)) Or _
    '           ((Me.Height <= 816 And Me.Height > 800) And (Me.Width < 981 And Me.Width >= 931)) Or ((Me.Height <= 816 And Me.Height > 800) And (Me.Width < 931 And Me.Width >= 881)) Or _
    '           ((Me.Height <= 816 And Me.Height > 800) And (Me.Width < 881 And Me.Width >= 831)) Or ((Me.Height <= 816 And Me.Height > 800) And (Me.Width < 831 And Me.Width >= 781)) Or _
    '           ((Me.Height <= 816 And Me.Height > 800) And (Me.Width < 781 And Me.Width >= 731)) Or ((Me.Height <= 816 And Me.Height > 800) And (Me.Width < 731 And Me.Width >= 681)) Or _
    '           ((Me.Height <= 816 And Me.Height > 800) And (Me.Width < 681 And Me.Width >= 631)) Or ((Me.Height <= 816 And Me.Height > 800) And (Me.Width < 631)) Then
    '        _GenImage = ZoomImage(OutputPictureBox.Image, 45)
    '    ElseIf ((Me.Height <= 800 And Me.Height > 700) And Me.Width >= 1081) Or ((Me.Height <= 800 And Me.Height > 700) And (Me.Width < 1081 And Me.Width >= 1031)) Or ((Me.Height <= 800 And Me.Height > 700) And (Me.Width < 1031 And Me.Width >= 981)) Or _
    '           ((Me.Height <= 800 And Me.Height > 700) And (Me.Width < 981 And Me.Width >= 931)) Or ((Me.Height <= 800 And Me.Height > 700) And (Me.Width < 931 And Me.Width >= 881) Or _
    '           ((Me.Height <= 800 And Me.Height > 700) And (Me.Width < 881 And Me.Width >= 831)) Or ((Me.Height <= 800 And Me.Height > 700) And (Me.Width < 831 And Me.Width >= 781)) Or _
    '           ((Me.Height <= 800 And Me.Height > 700) And (Me.Width < 781 And Me.Width >= 731)) Or (Me.Height <= 800 And Me.Height > 700) And (Me.Width < 731 And Me.Width >= 681)) Or _
    '           ((Me.Height <= 800 And Me.Height > 700) And (Me.Width < 681 And Me.Width >= 631)) Or ((Me.Height <= 800 And Me.Height > 700) And (Me.Width < 631)) Then
    '        _GenImage = ZoomImage(OutputPictureBox.Image, 40)
    '    ElseIf ((Me.Height <= 700 And Me.Height > 600) And Me.Width >= 1081) Or ((Me.Height <= 700 And Me.Height > 600) And (Me.Width < 1081 And Me.Width >= 1031)) Or ((Me.Height <= 700 And Me.Height > 600) And (Me.Width < 1031 And Me.Width >= 981)) Or _
    '           ((Me.Height <= 700 And Me.Height > 600) And (Me.Width < 981 And Me.Width >= 931)) Or ((Me.Height <= 700 And Me.Height > 600) And (Me.Width < 931 And Me.Width >= 881)) Or _
    '           ((Me.Height <= 700 And Me.Height > 600) And (Me.Width < 881 And Me.Width >= 831)) Or ((Me.Height <= 700 And Me.Height > 600) And (Me.Width < 831 And Me.Width >= 781)) Or _
    '           ((Me.Height <= 700 And Me.Height > 600) And (Me.Width < 781 And Me.Width >= 731)) Or ((Me.Height <= 700 And Me.Height > 600) And (Me.Width < 731 And Me.Width >= 681)) Or _
    '           ((Me.Height <= 700 And Me.Height > 600) And (Me.Width < 681 And Me.Width >= 631)) Or ((Me.Height <= 700 And Me.Height > 600) And (Me.Width < 631)) Then
    '        _GenImage = ZoomImage(OutputPictureBox.Image, 35)
    '    ElseIf ((Me.Height <= 600 And Me.Height > 500) And Me.Width >= 1081) Or ((Me.Height <= 600 And Me.Height > 500) And (Me.Width < 1081 And Me.Width >= 1031)) Or ((Me.Height <= 600 And Me.Height > 500) And (Me.Width < 1031 And Me.Width >= 981)) Or _
    '           ((Me.Height <= 600 And Me.Height > 500) And (Me.Width < 981 And Me.Width >= 931)) Or ((Me.Height <= 600 And Me.Height > 500) And (Me.Width < 931 And Me.Width >= 881)) Or _
    '           ((Me.Height <= 600 And Me.Height > 500) And (Me.Width < 881 And Me.Width >= 831)) Or ((Me.Height <= 600 And Me.Height > 500) And (Me.Width < 831 And Me.Width >= 781)) Or _
    '           ((Me.Height <= 600 And Me.Height > 500) And (Me.Width < 781 And Me.Width >= 731)) Or ((Me.Height <= 600 And Me.Height > 500) And (Me.Width < 731 And Me.Width >= 681)) Or _
    '           ((Me.Height <= 600 And Me.Height > 500) And (Me.Width < 681 And Me.Width >= 631)) Or ((Me.Height <= 600 And Me.Height > 500) And (Me.Width < 631)) Then
    '        _GenImage = ZoomImage(OutputPictureBox.Image, 30)
    '    ElseIf ((Me.Height <= 500 And Me.Height > 400) And Me.Width >= 1081) Or ((Me.Height <= 500 And Me.Height > 400) And (Me.Width < 1081 And Me.Width >= 1031)) Or ((Me.Height <= 500 And Me.Height > 400) And (Me.Width < 1031 And Me.Width >= 981)) Or _
    '           ((Me.Height <= 500 And Me.Height > 400) And (Me.Width < 981 And Me.Width >= 931)) Or ((Me.Height <= 500 And Me.Height > 400) And (Me.Width < 931 And Me.Width >= 881)) Or _
    '           ((Me.Height <= 500 And Me.Height > 400) And (Me.Width < 881 And Me.Width >= 831)) Or ((Me.Height <= 500 And Me.Height > 400) And (Me.Width < 831 And Me.Width >= 781)) Or _
    '           ((Me.Height <= 500 And Me.Height > 400) And (Me.Width < 781 And Me.Width >= 731)) Or ((Me.Height <= 500 And Me.Height > 400) And (Me.Width < 731 And Me.Width >= 681)) Or _
    '           ((Me.Height <= 500 And Me.Height > 400) And (Me.Width < 681 And Me.Width >= 631)) Or ((Me.Height <= 500 And Me.Height > 400) And (Me.Width < 631)) Then
    '        _GenImage = ZoomImage(OutputPictureBox.Image, 25)
    '    ElseIf ((Me.Height <= 400 And Me.Height > 300) And Me.Width >= 1081) Or ((Me.Height <= 400 And Me.Height > 300) And (Me.Width < 1081 And Me.Width >= 1031)) Or ((Me.Height <= 400 And Me.Height > 300) And (Me.Width < 1031 And Me.Width >= 981)) Or _
    '           ((Me.Height <= 400 And Me.Height > 300) And (Me.Width < 981 And Me.Width >= 931)) Or ((Me.Height <= 400 And Me.Height > 300) And (Me.Width < 931 And Me.Width >= 881)) Or _
    '           ((Me.Height <= 400 And Me.Height > 300) And (Me.Width < 881 And Me.Width >= 831)) Or ((Me.Height <= 400 And Me.Height > 300) And (Me.Width < 831 And Me.Width >= 781)) Or _
    '           ((Me.Height <= 400 And Me.Height > 300) And (Me.Width < 781 And Me.Width >= 731)) Or ((Me.Height <= 400 And Me.Height > 300) And (Me.Width < 731 And Me.Width >= 681)) Or _
    '           ((Me.Height <= 400 And Me.Height > 300) And (Me.Width < 681 And Me.Width >= 631)) Or ((Me.Height <= 400 And Me.Height > 300) And (Me.Width < 631)) Then
    '        _GenImage = ZoomImage(OutputPictureBox.Image, 20)

    '    ElseIf ((Me.Height <= 300 And Me.Height > 200) And Me.Width >= 1081) Or ((Me.Height <= 300 And Me.Height > 200) And (Me.Width < 1081 And Me.Width >= 1031)) Or ((Me.Height <= 300 And Me.Height > 200) And (Me.Width < 1031 And Me.Width >= 981)) Or _
    '           ((Me.Height <= 300 And Me.Height > 200) And (Me.Width < 981 And Me.Width >= 931)) Or ((Me.Height <= 300 And Me.Height > 200) And (Me.Width < 931 And Me.Width >= 881)) Or _
    '           ((Me.Height <= 300 And Me.Height > 200) And (Me.Width < 881 And Me.Width >= 831)) Or ((Me.Height <= 300 And Me.Height > 200) And (Me.Width < 831 And Me.Width >= 781)) Or _
    '           ((Me.Height <= 300 And Me.Height > 200) And (Me.Width < 781 And Me.Width >= 731)) Or ((Me.Height <= 300 And Me.Height > 200) And (Me.Width < 731 And Me.Width >= 681)) Or _
    '           ((Me.Height <= 300 And Me.Height > 200) And (Me.Width < 681 And Me.Width >= 631)) Or ((Me.Height <= 300 And Me.Height > 200) And (Me.Width < 631)) Then
    '        _GenImage = ZoomImage(OutputPictureBox.Image, 15)
    '    ElseIf ((Me.Height <= 200 And Me.Height > 100) And Me.Width >= 1081) Or ((Me.Height <= 200 And Me.Height > 100) And (Me.Width < 1081 And Me.Width >= 1031)) Or ((Me.Height <= 200 And Me.Height > 100) And (Me.Width < 1031 And Me.Width >= 981)) Or _
    '           ((Me.Height <= 200 And Me.Height > 100) And (Me.Width < 981 And Me.Width >= 931)) Or ((Me.Height <= 200 And Me.Height > 100) And (Me.Width < 931 And Me.Width >= 881)) Or _
    '           ((Me.Height <= 200 And Me.Height > 100) And (Me.Width < 881 And Me.Width >= 831)) Or ((Me.Height <= 200 And Me.Height > 100) And (Me.Width < 831 And Me.Width >= 781)) Or _
    '           ((Me.Height <= 200 And Me.Height > 100) And (Me.Width < 781 And Me.Width >= 731)) Or ((Me.Height <= 200 And Me.Height > 100) And (Me.Width < 731 And Me.Width >= 681)) Or _
    '           ((Me.Height <= 200 And Me.Height > 100) And (Me.Width < 681 And Me.Width >= 631)) Or ((Me.Height <= 200 And Me.Height > 100) And (Me.Width < 631)) Then
    '        _GenImage = ZoomImage(OutputPictureBox.Image, 10)
    '    ElseIf ((Me.Height <= 100) And Me.Width >= 1081) Or ((Me.Height <= 100) And (Me.Width < 1081 And Me.Width >= 1031)) Or ((Me.Height <= 100) And (Me.Width < 1031 And Me.Width >= 981)) Or _
    '           ((Me.Height <= 100) And (Me.Width < 981 And Me.Width >= 931)) Or ((Me.Height <= 100) And (Me.Width < 931 And Me.Width >= 881)) Or _
    '           ((Me.Height <= 100) And (Me.Width < 881 And Me.Width >= 831)) Or ((Me.Height <= 100) And (Me.Width < 831 And Me.Width >= 781)) Or _
    '           ((Me.Height <= 100) And (Me.Width < 781 And Me.Width >= 731)) Or ((Me.Height <= 100) And (Me.Width < 731 And Me.Width >= 681)) Or _
    '           ((Me.Height <= 100) And (Me.Width < 681 And Me.Width >= 631)) Or ((Me.Height <= 100) And (Me.Width < 631)) Then
    '        _GenImage = ZoomImage(OutputPictureBox.Image, 5)
    '    End If
    '    Return _GenImage
    'End Function

    'Public Function CheckWidth(ByVal _form As String) As Bitmap
    '    Dim _GenImage As Bitmap
    '    If _form = "QCForm" Then
    '        If Me.Width >= 1081 Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 50)
    '        ElseIf (Me.Width < 1081 And Me.Width >= 1031) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 45)
    '        ElseIf (Me.Width < 1031 And Me.Width >= 981) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 40)
    '        ElseIf (Me.Width < 981 And Me.Width >= 931) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 35)
    '        ElseIf (Me.Width < 931 And Me.Width >= 881) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 30)
    '        ElseIf (Me.Width < 881 And Me.Width >= 831) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 25)
    '        ElseIf (Me.Width < 831 And Me.Width >= 781) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 20)
    '        ElseIf (Me.Width < 781 And Me.Width >= 731) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 15)
    '        ElseIf (Me.Width < 731 And Me.Width >= 681) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 10)
    '        ElseIf (Me.Width < 681 And Me.Width >= 631) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 5)
    '        ElseIf (Me.Width < 631) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 3)
    '        End If
    '    Else
    '        If Me.Height < 400 Then
    '            _GenImage = CheckHeight(Me.Name.ToString)
    '        ElseIf Me.Width >= 1081 Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 50)
    '        ElseIf (Me.Width < 1081 And Me.Width >= 1011) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 45)
    '        ElseIf (Me.Width < 1011 And Me.Width >= 941) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 40)
    '        ElseIf (Me.Width < 941 And Me.Width >= 871) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 35)
    '        ElseIf (Me.Width < 871 And Me.Width >= 801) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 30)
    '        ElseIf (Me.Width < 801 And Me.Width >= 731) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 28)
    '        ElseIf (Me.Width < 731 And Me.Width >= 661) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 20)
    '        ElseIf (Me.Width < 661 And Me.Width >= 591) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 16)
    '        ElseIf (Me.Width < 591 And Me.Width >= 521) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 13)
    '        ElseIf (Me.Width < 521 And Me.Width >= 451) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 5)
    '        ElseIf (Me.Width < 451) Then
    '            If ImageDisplay.Image IsNot Nothing Then _GenImage = ZoomImage(OutputPictureBox.Image, 3)
    '        End If
    '    End If
    '    Return _GenImage
    'End Function

    'Protected Function ZoomImage(ByVal imgPhoto As Image, ByVal Percent As Integer) As Bitmap
    '    Dim nPercent As Single = (CSng(Percent) / 100)

    '    Dim sourceWidth As Integer = imgPhoto.Width
    '    Dim sourceHeight As Integer = imgPhoto.Height
    '    Dim sourceX As Integer = 0
    '    Dim sourceY As Integer = 0

    '    Dim destX As Integer = 0
    '    Dim destY As Integer = 0
    '    Dim destWidth As Integer = CInt(Math.Truncate(sourceWidth * nPercent))
    '    Dim destHeight As Integer = CInt(Math.Truncate(sourceHeight * nPercent))

    '    If sourceWidth > 1000 And (CurrentWidth < NewWidth Or CurrentHeight < NewHeight) Then

    '        While destHeight >= ImagePanel.Height - 2
    '            destHeight = destHeight - 1
    '            'destWidth = destWidth - 1
    '            DeductedHeight = destHeight + 1
    '        End While

    '        If (CInt(sourceHeight / 2) = sourceWidth) Or (sourceWidth <= CInt(sourceHeight / 2)) Then destWidth = CInt(destWidth / 2)

    '        If sourceWidth > 2000 Then
    '            destWidth = CInt(sourceWidth / 5)
    '            If destWidth > ImagePanel.Width Then
    '                destWidth = CInt(sourceWidth / 10)
    '            End If
    '        ElseIf destHeight >= ImagePanel.Height Or destWidth >= ImagePanel.Width Then
    '            While destHeight >= ImagePanel.Height - 2
    '                destHeight = destHeight - 1
    '                DeductedHeight = destHeight + 1
    '            End While

    '            While destWidth >= ImagePanel.Width - 2
    '                destWidth = destWidth - 1
    '            End While
    '        End If
    '    Else
    '        While destHeight >= ImagePanel.Height - 2
    '            destHeight = destHeight - 1
    '            DeductedHeight = destHeight + 1
    '        End While

    '        While destWidth >= ImagePanel.Width - 2
    '            destWidth = destWidth - 1
    '        End While
    '    End If

    '    Dim bmPhoto As New Bitmap(destWidth, destHeight, PixelFormat.Format64bppArgb)
    '    bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution)

    '    Dim grPhoto As Graphics = Graphics.FromImage(bmPhoto)
    '    grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic

    '    grPhoto.DrawImage(imgPhoto, New Rectangle(destX, destY, destWidth, destHeight), New Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel)

    '    grPhoto.Dispose()
    '    Return bmPhoto
    'End Function

    'Protected Function ZoomImage(ByVal imgPhoto As Image, ByVal Percent As Integer) As Bitmap
    '    _AddedHeight = 0
    '    _AddedWidth = 0
    '    Dim nPercent As Single = (CSng(Percent) / 100)

    '    Dim sourceWidth As Integer = imgPhoto.Width
    '    Dim sourceHeight As Integer = imgPhoto.Height
    '    Dim sourceX As Integer = 0
    '    Dim sourceY As Integer = 0

    '    Dim destX As Integer = 0
    '    Dim destY As Integer = 0
    '    Dim destWidth As Integer = CInt(Math.Truncate(sourceWidth * nPercent))
    '    Dim destHeight As Integer = CInt(Math.Truncate(sourceHeight * nPercent))


    '    If sourceWidth > 1000 And (CurrentWidth <= NewWidth Or CurrentHeight <= NewHeight) Then

    '        While destHeight >= ImagePanel.Height - 2
    '            destHeight = destHeight - 1
    '            'destWidth = destWidth - 1
    '            DeductedHeight = destHeight + 1
    '        End While

    '        If (CInt(sourceHeight / 2) = sourceWidth) Or (sourceWidth <= CInt(sourceHeight / 2)) Then destWidth = CInt(destWidth / 2)

    '        If sourceWidth > 2000 Then
    '            destWidth = CInt(sourceWidth / 5)
    '            If destWidth > ImagePanel.Width Then
    '                destWidth = CInt(sourceWidth / 10)
    '            End If
    '        ElseIf destHeight >= ImagePanel.Height Or destWidth >= ImagePanel.Width Then
    '            While destHeight >= ImagePanel.Height - 2
    '                destHeight = destHeight - 1
    '                DeductedHeight = destHeight + 1
    '            End While

    '            While destWidth >= ImagePanel.Width - 2
    '                destWidth = destWidth - 1
    '            End While
    '        End If
    '    Else
    '        While destHeight >= ImagePanel.Height - 2
    '            destHeight = destHeight - 1
    '            DeductedHeight = destHeight + 1
    '        End While

    '        While destWidth >= ImagePanel.Width - 2
    '            destWidth = destWidth - 1
    '        End While
    '    End If

    '    If destWidth < 0 Then destWidth = destWidth * -1
    '    If destHeight < 0 Then destHeight = destHeight * -1

    '    Dim bmPhoto As New Bitmap(destWidth, destHeight, PixelFormat.Format64bppPArgb)
    '    bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution)

    '    Dim grPhoto As Graphics = Graphics.FromImage(bmPhoto)
    '    grPhoto.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
    '    grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic
    '    grPhoto.SmoothingMode = SmoothingMode.HighQuality
    '    grPhoto.DrawImage(imgPhoto, New Rectangle(destX, destY, destWidth, destHeight), New Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel)

    '    grPhoto.Dispose()
    '    Return bmPhoto
    'End Function

    Protected Function ZoomImage(ByVal imgPhoto As Image, ByVal Percent As Double) As Bitmap
            If imgPhoto IsNot Nothing Then
                Dim nPercent As Single = (CSng(Percent) / 100)
                Dim basePercent As Double = Percent
                Dim sourceWidth As Integer = imgPhoto.Width
                Dim sourceHeight As Integer = imgPhoto.Height
                Dim sourceX As Integer = 0
                Dim sourceY As Integer = 0
                Dim exWidth As Integer
                Dim exHeight As Integer

                Dim destX As Integer = 0
                Dim destY As Integer = 0
                Dim destWidth As Integer = CInt(Math.Truncate(sourceWidth * nPercent))
                Dim destHeight As Integer = CInt(Math.Truncate(sourceHeight * nPercent))

                'Test: reset values
                destWidth = CInt(Math.Truncate(sourceWidth * nPercent))
                destHeight = CInt(Math.Truncate(sourceHeight * nPercent))

                If destWidth < 0 Then destWidth = destWidth * -1
                If destHeight < 0 Then destHeight = destHeight * -1

                Dim bmPhoto As New Bitmap(destWidth, destHeight, PixelFormat.Format64bppPArgb)
                bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution)

                Dim grPhoto As Graphics = Graphics.FromImage(bmPhoto)
                grPhoto.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic
                grPhoto.SmoothingMode = SmoothingMode.HighQuality
                grPhoto.DrawImage(imgPhoto, New Rectangle(destX, destY, destWidth, destHeight), New Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel)

                grPhoto.Dispose()
                Return bmPhoto
            End If
        End Function

    Protected Sub ReturnFitImageSize()
      With ImageDisplay
        .SizeMode = PictureBoxSizeMode.Zoom
        .Dock = DockStyle.Fill
      End With
    End Sub

    ''' <summary>
    ''' Prompts users whether to save unsaved changes made to displayed image or not. If users want 
    ''' to save changes made to image and any exception occurrs a prompt is displayed to users with
    ''' 3 options, 
    ''' Abort - abort the navigaion. 
    ''' Retry - retry to save image. 
    ''' Ignore - ignore unsaved image changes and move ahead with navigation.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    '        Protected Function PromptToSaveImage(ByVal _path As String) As System.Windows.Forms.DialogResult
    '            Dim userResponse As System.Windows.Forms.DialogResult


    '            userResponse = MessageBox.Show("Do you want to save changes made to the image?", ProductName _
    '                                            , MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '            If userResponse = DialogResult.Yes Then
    'SaveCroppedImage:
    '                Try
    '                    ''SaveImage(mainAxLEAD, mainAxLEAD.Tag.ToString(), ImageFileFormat, BITsPerPixel, ImageCompression, 1) \\ Comment By Denver : 35
    '                    If isRotationLabel.Text = "false" Then
    '                        SaveImage(OutputPictureBox.Image, _Path)
    '                    Else
    '                        Dim bmp As Bitmap = New Bitmap(OutputPictureBox.Image)
    '                        bmp.Save(_Path)
    '                    End If
    '                    isRotationLabel.Text = "false"
    '                Catch ex As System.ApplicationException
    '                    Dim exceptionMessage As String

    '                    exceptionMessage = My.Resources.PageNavigationImageSaveExceptionPrompt.Replace("#ExceptionMessage#", ex.Message + Environment.NewLine)
    '                    userResponse = MessageBox.Show(exceptionMessage, ProductName, MessageBoxButtons.AbortRetryIgnore _
    '                                                   , MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    '                    exceptionMessage = Nothing

    '                Catch ex As System.Exception
    '                    Dim exceptionMessage As String

    '                    exceptionMessage = My.Resources.PageNavigationImageSaveExceptionPrompt.Replace("#ExceptionMessage#", "Unknown error has occurred. ")
    '                    userResponse = MessageBox.Show(exceptionMessage, ProductName, MessageBoxButtons.AbortRetryIgnore _
    '                                                   , MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    '                    exceptionMessage = Nothing
    '                End Try

    '                If userResponse = Windows.Forms.DialogResult.Retry Then GoTo SaveCroppedImage
    '            End If

    '            Return userResponse

    '        End Function


    '    ''' <summary>
    '    ''' For ad image(cropped page image), prompts users whether to save unsaved changes made to 
    '    ''' displayed image or not. The prompt has 3 options, 
    '    ''' Yes - Overwrites page image with the cropped image. 
    '    ''' No - Ignores changes made to page image and move ahead with navigation. 
    '    ''' Cancel - abort navigation and stay there.
    '    ''' If an exception occurrs while saving cropped page image, a prompt is displayed with 3 options,
    '    ''' Abort - abort the navigaion. 
    '    ''' Retry - retry to save image. 
    '    ''' Ignore - ignore unsaved image changes and move ahead with navigation.
    '    ''' </summary>
    '    ''' <returns></returns>
    '    ''' <remarks></remarks>

    Protected Function PromptToSaveImage(ByVal _path As String) As System.Windows.Forms.DialogResult
      Dim userResponse As System.Windows.Forms.DialogResult
            Dim bmp As Bitmap = New Bitmap(OutputPictureBox.Image, OutputPictureBox.Width, OutputPictureBox.Height)

            userResponse = MessageBox.Show("Do you want to save changes made to the image?", ProductName _
                                            , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
      If userResponse = DialogResult.Yes Then
SaveCroppedImage:
        Try
          SaveImage(bmp, _path)
          isRotationLabel.Text = "false"
        Catch ex As System.ApplicationException
          Dim exceptionMessage As String

          exceptionMessage = My.Resources.PageNavigationImageSaveExceptionPrompt.Replace("#ExceptionMessage#", ex.Message + Environment.NewLine)
          userResponse = MessageBox.Show(exceptionMessage, ProductName, MessageBoxButtons.AbortRetryIgnore _
                                         , MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
          exceptionMessage = Nothing

        Catch ex As System.Exception
          Dim exceptionMessage As String

          exceptionMessage = My.Resources.PageNavigationImageSaveExceptionPrompt.Replace("#ExceptionMessage#", "Unknown error has occurred. ")
          userResponse = MessageBox.Show(exceptionMessage, ProductName, MessageBoxButtons.AbortRetryIgnore _
                                         , MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
          exceptionMessage = Nothing
        End Try

        If userResponse = Windows.Forms.DialogResult.Retry Then GoTo SaveCroppedImage
      End If

      Return userResponse

    End Function

    Protected Function PromptToSaveCroppedPageImage() As System.Windows.Forms.DialogResult
      Dim userResponse As System.Windows.Forms.DialogResult


      userResponse = MessageBox.Show("Do you want to save changes made to image file?", ProductName _
                                     , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question _
                                     , MessageBoxDefaultButton.Button3)
      If userResponse = DialogResult.Yes Then
        userResponse = MessageBox.Show("This will overwrite the page image with this cropped image." _
                                       , ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
        If userResponse = Windows.Forms.DialogResult.Cancel Then Return userResponse
        userResponse = Windows.Forms.DialogResult.Yes

RetrySaveCroppedPageImage:
        Try
          ''SaveImage(mainAxLEAD, mainAxLEAD.Tag.ToString(), ImageFileFormat, BITsPerPixel, ImageCompression, 1)
          SaveImage(ImageDisplay.Image, ImageDisplay.ImageLocation)
        Catch ex As System.ApplicationException
          Dim exceptionMessage As String

          exceptionMessage = My.Resources.PageNavigationImageSaveExceptionPrompt.Replace("#ExceptionMessage#", ex.Message + Environment.NewLine)
          userResponse = MessageBox.Show(exceptionMessage, ProductName, MessageBoxButtons.AbortRetryIgnore _
                                         , MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
          exceptionMessage = Nothing

        Catch ex As System.Exception
          Dim exceptionMessage As String

          exceptionMessage = My.Resources.PageNavigationImageSaveExceptionPrompt.Replace("#ExceptionMessage#", "Unknown error has occurred. ")
          userResponse = MessageBox.Show(exceptionMessage, ProductName, MessageBoxButtons.AbortRetryIgnore _
                                         , MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
          exceptionMessage = Nothing
        End Try

        If userResponse = Windows.Forms.DialogResult.Retry Then GoTo RetrySaveCroppedPageImage
      End If

      Return userResponse

    End Function


    ''' <summary>
    ''' Gets scale value for cropping image or removing rectangle selection from image file.
    ''' </summary>
    ''' <param name="actualSize"></param>
    ''' <param name="bitmapSize"></param>
    ''' <param name="scaleSize"></param>
    ''' <param name="destinationSize"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function GetScale _
        (ByVal actualSize As Single, ByVal bitmapSize As Single, ByVal scaleSize As Single, _
        ByVal destinationSize As Single) _
        As Single
      Dim scaleValue As Single


      If bitmapSize > scaleSize Then
        If bitmapSize > destinationSize Then
          If actualSize <> destinationSize Then
            scaleValue = bitmapSize / destinationSize
          Else
            scaleValue = bitmapSize / scaleSize
          End If
        Else
          scaleValue = 1
        End If

      Else
        If bitmapSize > destinationSize Then
          scaleValue = 1
        Else
          If actualSize <> destinationSize Then
            scaleValue = bitmapSize / destinationSize
          Else
            scaleValue = bitmapSize / scaleSize
          End If
        End If
      End If

      Return scaleValue

    End Function

    ''' <summary>
    ''' Roundup supplied number at 0.25th part. e.g. if fractional part is less than 12 it becomes 0, if its between 
    ''' 12 and 25 it becomes 25.
    ''' </summary>
    ''' <param name="size"></param>
    ''' <returns></returns>
    ''' <remarks>Newer version of the functionality.</remarks>
    Protected Function RoundoffAdvertisementSize(ByVal size As Single) As Single
      Dim decimalPart As Integer
      Dim fractionalPart As Single, remainder As Single


      If size < 0.0 Then Return 0.0

      decimalPart = CType(Math.Truncate(size), Integer)
      If decimalPart < 1 Then
        fractionalPart = size Mod 1
      Else
        fractionalPart = size Mod decimalPart
      End If

      remainder = (fractionalPart * 100) Mod 25
      If remainder > 12.5 Then
        fractionalPart -= CType(fractionalPart Mod 0.25, Single)
        fractionalPart += CType(0.25, Single)
      Else
        fractionalPart -= CType((fractionalPart Mod 0.25), Single)
      End If

      size = decimalPart + fractionalPart
      RoundoffAdvertisementSize = size

    End Function

    ''' <summary>
    ''' This function is called when FindVehicle, PageNavigation and FindPage methods are called, to allow 
    ''' derived classes to update page information on screen.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub RefreshPageInformation()

    End Sub

    ''' <summary>
    ''' This function is called when PageCropNavigation and FindPageCrop methods are called, to allow 
    ''' derived classes to update page information on screen.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub RefreshPageCropInformation()

    End Sub

    ''' <summary>
    ''' Calculates cropped ad size in inches.
    ''' </summary>
    ''' <param name="pageCropId"></param>
    ''' <param name="recroppedRectangle"></param>
    ''' <remarks></remarks>
    Protected Overridable Function CalculateReCroppedImageSize(ByVal pageCropId As Integer, ByVal recroppedRectangle As System.Drawing.RectangleF) As System.Drawing.SizeF

    End Function

    ''' <summary>
    ''' Derived class should override this method and boolean status indicating whether supplied vehicle 
    ''' is having records in PageCrop table or not.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Protected Overridable Function HasCroppedPageImages(ByVal vehicleId As Integer) As Boolean

    End Function


    ''' <summary>
    ''' Allows derived classes to write process to be executed when same button is clicked.
    ''' </summary>
    ''' <remarks></remarks>
        Protected Overridable Sub OnSame(ByVal vehicleId As Integer, ByVal pageNumber As Integer, ByVal adSize As System.Drawing.SizeF, ByVal adRectangle As System.Drawing.RectangleF, Optional ByVal isRectKept As Boolean = False, Optional ByVal isRectRemoved As Boolean = False, _
                                       Optional ByVal isRectDrawn As Boolean = False)

        End Sub

    ''' <summary>
    ''' Allows derived classes to write process to be executed when new button is clicked.
    ''' </summary>
    ''' <remarks></remarks>
        Protected Overridable Sub OnNew(ByVal vehicleId As Integer, ByVal pageNumber As Integer, ByVal adSize As System.Drawing.SizeF, ByVal adRectangle As System.Drawing.RectangleF, Optional ByVal isRectKept As Boolean = False, Optional ByVal isRectRemoved As Boolean = False, _
                                       Optional ByVal isRectDrawn As Boolean = False)

        End Sub

    ''' <summary>
    ''' Allows derived classes to write process to remove vehicle.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnDelete(ByVal vehicleId As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process to remove PageCrop record.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="pageCropId"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnDeletePageCrop(ByVal vehicleId As Integer, ByVal pageCropId As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process to prepare form to edit vehicle.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnEdit(ByVal vehicleId As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process to prepare form for undo editing of vehicle.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnCancel(ByVal vehicleId As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process for clearing all inputs and 
    ''' preparing form for entering vehicle information.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub OnAdd()

      '
      'This is necessary to recognize that user has not cropped image and hence 
      'applicatoin should consider page image as Ad.
      '
      Me.AdSize = System.Drawing.SizeF.Empty
      Me.AdRectangle = System.Drawing.RectangleF.Empty

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process to load latest record from PageCrop table.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="retailerId"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnShowPreviousPageCrop(ByVal vehicleId As Integer, ByVal retailerId As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process to clear all inputs.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub OnClear()

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process to save vehicle information.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnSave(ByVal vehicleId As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process to save cropped page image information.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="pageNumber"></param>
    ''' <param name="adSize"></param>
    ''' <param name="adRectangle"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnSavePageCrop(ByVal vehicleId As Integer, ByVal pageNumber As Integer, ByVal adSize As System.Drawing.SizeF, ByVal adRectangle As System.Drawing.RectangleF)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process to load rows from PageCrop table.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnPageCropInformation(ByVal vehicleId As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process for loading first image for vehicleId.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnNavigateToFirstImage(ByVal vehicleId As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process for loading first image for vehicleId.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="pageNumber"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnNavigateToPreviousImage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process for loading next image for vehicleId.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="pageNumber"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnNavigateToNextImage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process for loading last image for vehicleId.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnNavigateToLastImage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process for searching and loading specified page image.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="pageNumber"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnFindPage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process for loading first page crop record for vehicleId.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnNavigateToFirstPageCrop(ByVal vehicleId As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process for loading first page crop record for vehicleId.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="pageNumber"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnNavigateToPreviousPageCrop(ByVal vehicleId As Integer, ByVal pageNumber As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process for loading next page crop record for vehicleId.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="pageNumber"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnNavigateToNextPageCrop(ByVal vehicleId As Integer, ByVal pageNumber As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process for loading last page crop record for vehicleId.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnNavigateToLastPageCrop(ByVal vehicleId As Integer, ByVal pageNumber As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived classes to write process for searching and loading specified page crop record.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="pageNumber"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnFindCroppedPage(ByVal vehicleId As Integer, ByVal pageNumber As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived class to write process to rotate image at 90 degree.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub OnRotateAt90()

    End Sub

    ''' <summary>
    ''' Allows derived class to write process to rotate image at 180 degree.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub OnRotatePagesAt180()

    End Sub

    ''' <summary>
    ''' Allows derived class to write process to rotate image at 270 degree.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub OnRotatePagesAt270()

    End Sub

    ''' <summary>
    ''' Allows derived class to write process to rotate image anti-clock wise at predefined degree.
    ''' </summary>
    ''' <param name="rotationCounter">Number of times displayed image has been rotated anti-clock wise.</param>
    ''' <remarks></remarks>
    Protected Overridable Function OnRotatePageAnticlockWise(ByVal rotationCounter As Integer) As Integer

    End Function

    ''' <summary>
    ''' Allows derived class to write process to rotate image clock wise at predefined degree.
    ''' </summary>
    ''' <param name="rotationCounter">Number of times displayed image has been rotated clock wise.</param>
    ''' <remarks></remarks>
    Protected Overridable Function OnRotatePageClockWise(ByVal rotationCounter As Integer) As Integer

    End Function

    ''' <summary>
    ''' Allows derived class to write process to rotate all images at specified degree.
    ''' </summary>
    ''' <param name="rotationAngle">All page images should be rotated at specified degree.</param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnRotateAllPages(ByVal rotationAngle As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived class to write process to rotate image by selected degree.
    ''' </summary>
    ''' <param name="rotationAngle">Image is supposed to be rotated at specified degree.</param>
    ''' <remarks></remarks>
        Protected Overridable Sub OnRotatePageBy(ByVal rotationAngle As Integer, ByVal isAccepted As Boolean)

        End Sub

    ''' <summary>
    ''' Returns true if page is having size assigned to it, false otherwise.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="pageNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Overridable Function IsPageHasSizeAssigned(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As Boolean

    End Function

    ''' <summary>
    ''' Allows derived class to search and return size of the supplied page of vehicle Id.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="pageNumber"></param>
    ''' <returns></returns>
    ''' <remarks>This function is used while calculating cropped image size.</remarks>
    Protected Overridable Function GetPageImageSize(ByVal vehicleId As Integer, ByVal pageNumber As Integer) As SizeF

    End Function

    ''' <summary>
    ''' Allows derived class to search and return size of the supplied page id.
    ''' </summary>
    ''' <param name="pageId"></param>
    ''' <returns></returns>
    ''' <remarks>This function is used while calculating cropped image size.</remarks>
    Protected Overridable Function GetPageImageSize(ByVal pageId As Integer) As SizeF

    End Function

    ''' <summary>
    ''' Allows derived class to write process to crop displayed image.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <param name="pageNumber"></param>
    ''' <param name="cropRectangle">Location and size of the ad area to be cropped, in pixels. This depends on 
    ''' scanned page image size and size of the control displaying the page image. If size of the page image is
    ''' smaller or same as of control, cropRectangle is same as adSizeRectangle. Otherwise, cropRectangle will be
    ''' smaller than adSizeRectangle.</param>
    ''' <param name="adSizeRectangle">Location and Size of the ad in pixels.</param>
    ''' <param name="adSize">Size of the ad in inches. This can further be used to get sizeId.</param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnPageImageCrop(ByVal img As Image, ByVal xAxis As Integer, ByVal yAxis As Integer, ByVal xWidth As Integer, ByVal xHeight As Integer)

    End Sub

        ''' <summary>
        ''' Allows derived class to write process to crop displayed image.
        ''' </summary>
        ''' <param name="vehicleId"></param>
        ''' <param name="pageNumber"></param>
        ''' <param name="cropRectangle">Location and size of the ad area to be cropped, in pixels. This depends on 
        ''' scanned page image size and size of the control displaying the page image. If size of the page image is
        ''' smaller or same as of control, cropRectangle is same as adSizeRectangle. Otherwise, cropRectangle will be
        ''' smaller than adSizeRectangle.</param>
        ''' <param name="adSizeRectangle">Location and Size of the ad in pixels.</param>
        ''' <param name="adSize">Size of the ad in inches. This can further be used to get sizeId.</param>
        ''' <remarks></remarks>
        Protected Overridable Sub OnPageImageCrop_original(ByVal img As Image, ByVal xAxis As Integer, ByVal yAxis As Integer, ByVal xWidth As Integer, ByVal xHeight As Integer)

        End Sub
    ''' <summary>
    ''' Allows derived class to write process to clear selection from displayed image.
    ''' </summary>
    ''' <param name="cropRectangle"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnPageImageClearSelection(ByVal img As Image, ByVal xAxis As Integer, ByVal yAxis As Integer, ByVal xWidth As Integer, ByVal xHeight As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived class to write process to clear selection from displayed image.
    ''' </summary>
    ''' <param name="cropRectangle"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnPageImageClearSelection_Original(ByVal img As Image, ByVal xAxis As Integer, ByVal yAxis As Integer, ByVal xWidth As Integer, ByVal xHeight As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived class to write process to save(overwrite) displayed image to image file.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub OnPageImageSave()

    End Sub

    ''' <summary>
    ''' Allows derived class to write process to refresh vehicle information and images.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnRefreshVehicleInformation(ByVal vehicleId As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived class to write process to remove displayed image.
    ''' </summary>
    ''' <param name="currentPage"></param>
    ''' <param name="totalPages"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnPageImageDelete(ByVal currentPage As Integer, ByVal totalPages As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived class to write process to resequence vehicle page images.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnResequencePageImages(ByVal vehicleId As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived class to write process .
    ''' </summary>
    ''' <remarks></remarks>
    '''                                      
    Protected Overridable Sub OnDrawRectangle(ByVal img As Image, ByVal xAxis As Integer, ByVal yAxis As Integer, ByVal xWidth As Integer, ByVal xHeight As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived class to write process .
    ''' </summary>
    ''' <remarks></remarks>
    '''                                      
    Protected Overridable Sub OnDrawRectangle_Original(ByVal img As Image, ByVal xAxis As Integer, ByVal yAxis As Integer, ByVal xWidth As Integer, ByVal xHeight As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived class to write process .
    ''' </summary>
    ''' <param name="VehicleId"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnNotpromotional(ByVal VehicleId As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived class to write process to mark vehicle as QC Complete.
    ''' </summary>
    ''' <param name="VehicleId"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnQCComplete(ByVal VehicleId As Integer)

    End Sub

    ''' <summary>
    ''' Allows derived class to write process when exit button is clicked.
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub OnExitClicked()

    End Sub



    Private Sub sameButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sameButton.Click
      Dim vehicleId, pageNumber As Integer


      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        vehicleId = -1
      End If

      If vehicleId < 1 Then
        MessageBox.Show("You have to load vehicle.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
        pageNumber = -1
      End If

            '
      'If user has not cropped ad image out of page image, page image will get considered as ad 
      'image and page size will be considered as cropped ad size.
      '
      If Me.AdSize = System.Drawing.SizeF.Empty _
        AndAlso Me.AdRectangle = System.Drawing.RectangleF.Empty _
      Then
        Dim userResponse As System.Windows.Forms.DialogResult
        userResponse = MessageBox.Show("You have not cropped Ad out of page image. New Ad will be created " _
                                       + "considering page image as cropped Ad image." + Environment.NewLine _
                                       + "Do you want to continue creation of new Ad with above consideration?" _
                                       , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                       , MessageBoxDefaultButton.Button2)
        If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

        Me.AdSize = GetPageImageSize(vehicleId, pageNumber)
      End If

            OnSame(vehicleId, pageNumber, Me.AdSize, Me.AdRectangle, keepRectangle, isRectRemoved, isRectDrawn)
            keepRectangle = False
    End Sub

    Private Sub newButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles newButton.Click
      Dim vehicleId, pageNumber As Integer


      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        vehicleId = -1
      End If

      If vehicleId < 1 Then
        MessageBox.Show("You have to load vehicle.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
        pageNumber = -1
      End If

      '
      'If user has not cropped ad image out of page image, page image will get considered as ad 
      'image and page size will be considered as cropped ad size.
      '
      If Me.AdSize = System.Drawing.SizeF.Empty _
        AndAlso Me.AdRectangle = System.Drawing.RectangleF.Empty _
      Then
        Dim userResponse As System.Windows.Forms.DialogResult
        userResponse = MessageBox.Show("You have not cropped Ad out of page image. New Ad will be created " _
                                       + "considering page image as cropped Ad image." + Environment.NewLine _
                                       + "Do you want to continue creation of new Ad with above consideration?" _
                                       , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                       , MessageBoxDefaultButton.Button2)
        If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

        Me.AdSize = GetPageImageSize(vehicleId, pageNumber)
      End If

            OnNew(vehicleId, pageNumber, Me.AdSize, Me.AdRectangle, keepRectangle, isRectRemoved, isRectDrawn)
            keepRectangle = False
    End Sub

    Private Sub printButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles printButton.Click
      Dim vehicleId As Integer


      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        vehicleId = -1
      End If

      If vehicleId < 1 Then
        MessageBox.Show("Please load vehicle to print label.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      OnPrintLabel(vehicleId)

    End Sub

    Private Sub deleteButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles deleteButton.Click
      Dim vehicleId As Integer
      Dim userResponse As DialogResult


      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        vehicleId = -1
      End If

      If vehicleId < 1 Then
        MessageBox.Show("Load vehicle to remove it.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      If Me.IsPageCropNavigation = False Then
        userResponse = MessageBox.Show("Are you sure, you want to delete vehicie " + vehicleId.ToString() + "?" _
                                       , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                       , MessageBoxDefaultButton.Button2)
        If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

        userResponse = MessageBox.Show("All information for vehicle " + vehicleId.ToString() _
                                       + " including images will be deleted.", ProductName _
                                       , MessageBoxButtons.OKCancel, MessageBoxIcon.Warning _
                                       , MessageBoxDefaultButton.Button2)
        If userResponse = Windows.Forms.DialogResult.Cancel Then Exit Sub

        OnDelete(vehicleId)

      Else
        Dim pageCropId As Integer

        If Integer.TryParse(pageCropIdLabel.Text, pageCropId) = False Then
          pageCropId = -1
        End If

        userResponse = MessageBox.Show("Are you sure, you want to delete this Ad?", ProductName _
                                       , MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                       , MessageBoxDefaultButton.Button2)
        If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

        userResponse = MessageBox.Show("All information for Ad including image will be deleted." _
                                       , ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning _
                                       , MessageBoxDefaultButton.Button2)
        If userResponse = Windows.Forms.DialogResult.Cancel Then Exit Sub

        OnDeletePageCrop(vehicleId, pageCropId)
      End If

    End Sub

    Private Sub editButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editButton.Click
      Dim vehicleId As Integer


      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        vehicleId = -1
      End If

      If vehicleId < 1 Then
        MessageBox.Show("Load vehicle to edit.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      OnEdit(vehicleId)
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

    End Sub

    Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancelButton.Click
      Dim vehicleId As Integer


      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        vehicleId = -1
      End If

      If vehicleId < 1 Then
        MessageBox.Show("No vehicle is load.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      OnCancel(vehicleId)
      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

    End Sub

    Private Sub addButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles addButton.Click

      OnAdd()

    End Sub

    Private Sub prvalButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles prvalButton.Click
      Dim vehicleId, retailerId As Integer


      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        vehicleId = -1
      ElseIf retailerComboBox.SelectedValue Is Nothing Then
        retailerId = -1
      ElseIf Integer.TryParse(retailerComboBox.SelectedValue.ToString(), retailerId) = False Then
        retailerId = -1
      End If

      If vehicleId < 1 Then
        MessageBox.Show("Load vehicle to see it's latest cropped page information." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
        'ElseIf retailerId < 1 Then
        '  MessageBox.Show("Select retailer, to load previous cropped page image for the retailer." _
        '                  , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '  Exit Sub
      ElseIf HasCroppedPageImages(vehicleId) = False Then
        MessageBox.Show("Cropped page information not found for Vehicle.", ProductName _
                          , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.IsPageCropNavigation = False
        Exit Sub
      End If

      OnShowPreviousPageCrop(vehicleId, retailerId)

    End Sub

    Private Sub clearButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles resetButton.Click

      OnClear()

    End Sub

    Private Sub saveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles saveButton.Click
      Dim vehicleId, pageNumber As Integer


      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        vehicleId = -1
      End If

      If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
        pageNumber = -1
      End If

      If vehicleId < 1 Then
        MessageBox.Show("Load vehicle to see its page images or cropped page images." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      If Me.IsPageCropNavigation = False Then
        OnSave(vehicleId)
      Else
        OnSavePageCrop(vehicleId, pageNumber, Me.AdSize, Me.AdRectangle)
      End If

    End Sub


    Private Sub vehiclePageCropButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles vehiclePageCropButton.Click
      Dim vehicleId As Integer


      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        vehicleId = -1
      End If

      If vehicleId < 1 Then
        MessageBox.Show("Load vehicle to see its page images or cropped page images." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.IsPageCropNavigation = False
        Exit Sub
      ElseIf Me.IsPageCropNavigation = False AndAlso HasCroppedPageImages(vehicleId) = False Then
        'If PageCrop does not exist and having Me.IsPageCropNavigation=True, that means, this event 
        'is initiated, by vehiclePageCropButton.PerformClick(), while removing last PageCrop record 
        'for this vehicle.
        MessageBox.Show("Cropped page image information not found for Vehicle.", ProductName _
                          , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.IsPageCropNavigation = False
        Exit Sub
      End If

      Me.IsPageCropNavigation = Not Me.IsPageCropNavigation

      If Me.IsPageCropNavigation Then
        OnPageCropInformation(vehicleId)
        vehiclePageCropButton.Text = "Page Crop"
        RefreshPageCropInformation()
      Else
        OnFindVehicle(vehicleId, EventInitiatorEnum.VehiclePageCropButton)
        vehiclePageCropButton.Text = "Vehicle"
        RefreshPageInformation()
      End If

      ShowHideControls(Me.FormState)
      EnableDisableControls(Me.FormState)

    End Sub


    Private Sub firstImageButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles firstImageButton.Click
      Dim vehicleId As Integer
            OutputPictureBox.Image.Dispose()
            ImageDisplay.Image.Dispose()
      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        vehicleId = -1
      End If

      If vehicleId < 1 AndAlso Me.IsPageCropNavigation Then
        MessageBox.Show("Load vehicle to see its cropped page images.", ProductName _
                         , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      ElseIf vehicleId < 1 Then
        MessageBox.Show("Load vehicle to see its page images.", ProductName _
                         , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

            CoerceGarbageCollection(ImageDisplay)
            CoerceGarbageCollection(OutputPictureBox)
      If Me.IsPageCropNavigation Then
        OnNavigateToFirstPageCrop(vehicleId)
        RefreshPageCropInformation()
      Else
        OnNavigateToFirstImage(vehicleId)
        RefreshPageInformation()
      End If
            'IsZoomedIn = True
      'ReturnNormalImageSize()
            AnticlockWiseRotationCounter = 0
            ClockWiseRotationCounter = 0
    End Sub


    Private Sub previousImageButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles previousImageButton.Click
      Dim vehicleId, pageNumber, totalPages As Integer
            ' MsgBox(ImageDisplay.ImageLocation)
            OutputPictureBox.Image.Dispose()
            ImageDisplay.Image.Dispose()
      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        vehicleId = -1
      End If

      If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
        pageNumber = -1
      End If

      If Integer.TryParse(totalPagesLabel.Text, totalPages) = False Then
        totalPages = 0
      End If

      If vehicleId < 1 AndAlso Me.IsPageCropNavigation Then
        MessageBox.Show("Load vehicle to see its cropped page images.", ProductName _
                         , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      ElseIf vehicleId < 1 Then
        MessageBox.Show("Load vehicle to see its page images.", ProductName _
                         , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      pageNumber -= 1
      If pageNumber < 1 Then pageNumber = 1
      If pageNumber > totalPages Then pageNumber = totalPages

            CoerceGarbageCollection(ImageDisplay)
            CoerceGarbageCollection(OutputPictureBox)
      If Me.IsPageCropNavigation Then
        OnNavigateToPreviousPageCrop(vehicleId, pageNumber)
        RefreshPageCropInformation()
      Else
        OnNavigateToPreviousImage(vehicleId, pageNumber)
        RefreshPageInformation()
      End If
            'IsZoomedIn = True
            'ReturnNormalImageSize()
            AnticlockWiseRotationCounter = 0
            ClockWiseRotationCounter = 0
    End Sub


    Private Sub nextImageButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles nextImageButton.Click
      Dim vehicleId, pageNumber, totalPages As Integer
            ' MsgBox(ImageDisplay.ImageLocation)
            OutputPictureBox.Image.Dispose()
            ImageDisplay.Image.Dispose()
      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        vehicleId = -1
      End If

      If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
        pageNumber = -1
      End If

      If Integer.TryParse(totalPagesLabel.Text, totalPages) = False Then
        totalPages = 0
      End If

      If vehicleId < 1 AndAlso Me.IsPageCropNavigation Then
        MessageBox.Show("Load vehicle to see its cropped page images.", ProductName _
                         , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      ElseIf vehicleId < 1 Then
        MessageBox.Show("Load vehicle to see its page images.", ProductName _
                         , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      pageNumber += 1
      If pageNumber > totalPages Then pageNumber = totalPages

            CoerceGarbageCollection(ImageDisplay)
            CoerceGarbageCollection(OutputPictureBox)
      If Me.IsPageCropNavigation Then
        OnNavigateToNextPageCrop(vehicleId, pageNumber)
        RefreshPageCropInformation()
      Else
        OnNavigateToNextImage(vehicleId, pageNumber)
        RefreshPageInformation()
      End If
            'IsZoomedIn = True
      'ReturnNormalImageSize()
            AnticlockWiseRotationCounter = 0
            ClockWiseRotationCounter = 0
    End Sub


    Private Sub lastImageButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lastImageButton.Click
      Dim vehicleId, totalPages As Integer

      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        vehicleId = -1
      End If

      If Integer.TryParse(totalPagesLabel.Text, totalPages) = False Then
        totalPages = 0
      End If

      If vehicleId < 1 AndAlso Me.IsPageCropNavigation Then
        MessageBox.Show("Load vehicle to see its cropped page images.", ProductName _
                         , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      ElseIf vehicleId < 1 Then
        MessageBox.Show("Load vehicle to see its page images.", ProductName _
                         , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
            End If

            CoerceGarbageCollection(ImageDisplay)
            CoerceGarbageCollection(OutputPictureBox)
      If Me.IsPageCropNavigation Then
        OnNavigateToLastPageCrop(vehicleId, totalPages)
        RefreshPageCropInformation()
      Else
        OnNavigateToLastImage(vehicleId, totalPages)
        RefreshPageInformation()
      End If
            'IsZoomedIn = True
            'ReturnNormalImageSize()
            AnticlockWiseRotationCounter = 0
            ClockWiseRotationCounter = 0
    End Sub


    Private Sub findImageButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles findImageButton.Click
      Dim vehicleId, pageNumber, totalPages As Integer


      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        vehicleId = -1
            End If
            Dim PageSearch As Double = Double.Parse(findImageTextBox.Text)
            PageSearch = Round(PageSearch, 0)
            If Integer.TryParse(PageSearch.ToString, pageNumber) = False Then
                pageNumber = -1
            End If

      If Integer.TryParse(totalPagesLabel.Text, totalPages) = False Then
        totalPages = 0
      End If

      If vehicleId < 1 Then
        MessageBox.Show("Load vehicle to see its page images.", ProductName _
                         , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      If pageNumber < 1 Then
        MessageBox.Show("Specify valid page number. Page number cannot be less than 1.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      ElseIf pageNumber > totalPages Then
        MessageBox.Show("Specified page number is beyond total number of pages. Specify valid page number." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

            CoerceGarbageCollection(ImageDisplay)
            CoerceGarbageCollection(OutputPictureBox)
      If Me.IsPageCropNavigation Then
        OnFindCroppedPage(vehicleId, pageNumber)
        RefreshPageCropInformation()
      Else
        OnFindPage(vehicleId, pageNumber)
        RefreshPageInformation()
      End If
            AnticlockWiseRotationCounter = 0
            ClockWiseRotationCounter = 0
    End Sub



    Private Sub zoomButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles zoomButton.Click
      'ImageDisplay.Image = ZoomImage(ImageDisplay.Image)
      AnticlockWiseRotationCounter = 0
      ClockWiseRotationCounter = 0
            If IsZoomedIn = False Then
                OutputPictureBox.Image = _RegPic
                ImageDisplay.Image = AdjustImageToRetainRatio() 'ZoomImage(ImageDisplay.Image, 50)
                ImagePanel.AutoScroll = False
                IsZoomedIn = True
                RetainZoom = False
            Else
                ImagePanel.AutoScroll = True
                ImageDisplay.Image = _RegPic
                IsZoomedIn = False
                RetainZoom = True
            End If
      _Path = Nothing
    End Sub



    Private Sub rotateButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rotate90Button.Click, rotate180Button.Click, rotate270Button.Click _
        , rotateLButton.Click, rotateRButton.Click
            If ImageDisplay.Image IsNot Nothing Then
                isRotationLabel.Text = "true"
                ''Once images is rotated successfully, if rotation is initiated by 
                ''90/180/270 then auto save the image after rotation is done.
                If sender Is rotate90Button Then
                    OnRotateAt90()
                ElseIf sender Is rotate180Button Then
                    OnRotatePagesAt180()
                ElseIf sender Is rotate270Button Then
                    OnRotatePagesAt270()
                ElseIf sender Is rotateLButton Then
                    Me.AnticlockWiseRotationCounter += 1
                    If OnRotatePageAnticlockWise(Me.AnticlockWiseRotationCounter) = 0 Then
                        Me.AnticlockWiseRotationCounter = 0
                    End If
                ElseIf sender Is rotateRButton Then
                    Me.ClockWiseRotationCounter += 1
                    If OnRotatePageClockWise(Me.ClockWiseRotationCounter) = 0 Then
                        ClockWiseRotationCounter = 0
                    End If
                End If
            Else
                MessageBox.Show("No image is loaded to rotate.", ProductName _
                           , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

        End Sub

    Private Sub rotateAllButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rotate90AllButton.Click, rotate180AllButton.Click
      Dim rotationAngle As Integer

            If ImageDisplay.Image IsNot Nothing Then
                If sender Is rotate90AllButton Then
                    rotationAngle = 9000
                ElseIf sender Is rotate180AllButton Then
                    rotationAngle = 18000
                End If

                OnRotateAllPages(rotationAngle)
            Else
                MessageBox.Show("No image is loaded to rotate.", ProductName _
            , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End Sub

    Private Sub rotateByButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rotateByButton.Click
            If RotatePanel.Width > ImagePanel.Width Then RotatePanel.Width = ImagePanel.Width - 15
            If DegreesTrackBar.Value > 0 Then DegreesTrackBar.Value = 0
            BeforePictureBox.Image = New Bitmap(OutputPictureBox.Image)
            AfterPictureBox.Image = New Bitmap(OutputPictureBox.Image)
            DegreeTextBox.Text = DegreesTrackBar.Value.ToString
            RotatePanel.Visible = True
            DegreeTextBox.Focus()
    End Sub

    Private Sub keepRectangleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles keepRectangleButton.Click

      If mediaComboBox.Text = "Preprints" AndAlso tradeclassValueLabel.Text <> "FSI" Then
        MessageBox.Show("Keep rectangle functionality is not applicable for Preprints." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      ElseIf ImageDisplay.ImageLocation = "" Then
        MessageBox.Show("No image is loaded to crop.", ProductName _
                            , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      ElseIf doesRectangleExist = False Then
        MessageBox.Show("Select area to crop the image.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      OnPageImageCrop(ImageDisplay.Image, cropX, cropY, cropWidth, cropHeight)
      ImageDisplay.Image = cropBitmap
            If IsZoomedIn = True Then
                OnPageImageCrop_original(OutputPictureBox.Image, CInt(cropX * (100 / _scale)), CInt(cropY * (100 / _scale)), CInt(cropWidth * (100 / _scale)), CInt(cropHeight * (100 / _scale)))
            Else
                ImageDisplay.Image = cropBitmap
                OutputPictureBox.Image = ImageDisplay.Image
      End If

      RecalculateScale()
      Me.AskToSaveImage = True
      keepRectangle = True
    End Sub

    Private Sub removeRectangleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles removeRectangleButton.Click

      If mediaComboBox.Text = "Preprints" AndAlso tradeclassValueLabel.Text <> "FSI" Then
        MessageBox.Show("Remove rectangle functionality is not applicable for Preprints." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      ElseIf doesRectangleExist = False Then
        MessageBox.Show("Select area to clear selection from the image.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      OnPageImageClearSelection(ImageDisplay.Image, cropX, cropY, cropWidth, cropHeight)
            If IsZoomedIn = True Then
                OnPageImageClearSelection_Original(OutputPictureBox.Image, CInt(cropX * (100 / _scale)), CInt(cropY * (100 / _scale)), CInt(cropWidth * (100 / _scale)), CInt(cropHeight * (100 / _scale)))
            Else
                OutputPictureBox.Image = ImageDisplay.Image
            End If
            isRectRemoved = True
    End Sub

    Private Sub saveImageButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles saveImageButton.Click
            If ImageDisplay.Image IsNot Nothing Then
                OnPageImageSave()
                AnticlockWiseRotationCounter = 0
                ClockWiseRotationCounter = 0
            Else
                MessageBox.Show("No image is loaded to save.", ProductName _
            , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End Sub

    Private Sub refreshButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles refreshButton.Click
      Dim vehicleId As Integer


      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        vehicleId = -1
      End If

      If vehicleId < 1 Then
        MessageBox.Show("There is no vehicle loaded to refresh it's information.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      OnRefreshVehicleInformation(vehicleId)

    End Sub

    Private Sub deleteImageButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles deleteImageButton.Click
      Dim pageNumber, totalPages As Integer
      Dim userResponse As System.Windows.Forms.DialogResult

      If Integer.TryParse(currentPageLabel.Text, pageNumber) = False Then
        pageNumber = -1
      End If

      If Integer.TryParse(totalPagesLabel.Text, totalPages) = False Then
        totalPages = -1
      End If

      If pageNumber < 1 OrElse totalPages < 1 Then
        MessageBox.Show("Cannot remove page image." + Environment.NewLine _
                        + "Unable to identify current page number or total number of pages." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If

      userResponse = MessageBox.Show("Are you sure, you want to remove Page image of page " + pageNumber.ToString() _
                                     + " of " + totalPages.ToString() + "?", ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

      OnPageImageDelete(pageNumber, totalPages)

    End Sub

    Private Sub resequenceButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles resequenceButton.Click
      Dim vehicleId As Integer


      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        vehicleId = -1
      End If

      If vehicleId < 1 Then
        MessageBox.Show("Load vehicle to resequence it's pages.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      OnResequencePageImages(vehicleId)

    End Sub

    Private Sub exitButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles exitButton.Click

      OnExitClicked()

    End Sub

    Private Sub qcCompletedButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles qcCompletedButton.Click
      Dim vehicleId As Integer


      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        MessageBox.Show("Load Vehicle to finish it's QC.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If


      OnQCComplete(vehicleId)

    End Sub

    Private Sub notpromotionalButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles notpromotionalButton.Click
      Dim vehicleId As Integer


      If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
        MessageBox.Show("Load Vehicle to see the Social Status", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If


      OnNotpromotional(vehicleId)

    End Sub

    Private Sub DrawRectangleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrawRectangleButton.Click


      If doesRectangleExist = False Then
        MessageBox.Show("Select area to change the image border.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

      OnDrawRectangle(ImageDisplay.Image, cropX, cropY, cropWidth, cropHeight)
            If IsZoomedIn = True Then
                OnDrawRectangle_Original(OutputPictureBox.Image, CInt(cropX * (100 / _scale)), CInt(cropY * (100 / _scale)), CInt(cropWidth * (100 / _scale)), CInt(cropHeight * (100 / _scale)))
            Else
                OutputPictureBox.Image = ImageDisplay.Image
            End If
            isRectDrawn = True
    End Sub

    Private Sub ImageDisplay_LoadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles ImageDisplay.LoadCompleted
      _RegPic = New Bitmap(ImageDisplay.Image)
      OutputPictureBox.Image = _RegPic
            If RetainZoom = False Then
                ImageDisplay.Image = AdjustImageToRetainRatio()
            End If
    End Sub
    Private Sub ImageDisplay_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ImageDisplay.MouseDown
            If ImageDisplay.Image Is Nothing Then
                Exit Sub
            End If
            If ImageDisplay.SizeMode = PictureBoxSizeMode.Zoom = False Then
                Try
                    Cursor = Cursors.Cross
                    If e.Button = Windows.Forms.MouseButtons.Left Then

                        cropX = e.X
                        cropY = e.Y

                        cropPen = New Pen(cropPenColor, cropPenSize)
                        cropPen.DashStyle = DashStyle.Solid

                    End If
                    ImageDisplay.Refresh()
                Catch
                    MsgBox(Err.Description)
                End Try
            End If
    End Sub

    Private Sub ImageDisplay_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ImageDisplay.MouseMove
      If ImageDisplay.SizeMode = PictureBoxSizeMode.Zoom = False Then
        Try
          If ImageDisplay.Image Is Nothing Then Exit Sub

          If e.Button = Windows.Forms.MouseButtons.Left Then

            ImageDisplay.Refresh()
                        cropWidth = e.X - cropX
                        cropHeight = e.Y - cropY
                        If cropWidth < 0 And cropHeight > 0 Then
                            ImageDisplay.CreateGraphics.DrawRectangle(cropPen, e.X, cropY, cropWidth * -1, cropHeight)
                        ElseIf cropHeight < 0 And cropWidth < 0 Then
                            ImageDisplay.CreateGraphics.DrawRectangle(cropPen, e.X, e.Y, cropWidth * -1, cropHeight * -1)
                        ElseIf cropHeight < 0 And cropWidth > 0 Then
                            ImageDisplay.CreateGraphics.DrawRectangle(cropPen, cropX, e.Y, cropWidth, cropHeight * -1)
                        Else
                            ImageDisplay.CreateGraphics.DrawRectangle(cropPen, cropX, cropY, cropWidth, cropHeight)
                        End If
          End If
        Catch
          MsgBox(Err.Description)
        End Try
      End If
    End Sub

    Private Sub ImageDisplay_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ImageDisplay.MouseUp
      Dim iWidth As Integer = 0
      Dim iHeight As Integer = 0
            If ImageDisplay.Image Is Nothing Then Exit Sub
      If ImageDisplay.SizeMode = PictureBoxSizeMode.Zoom = False Then
                Try
                    If cropWidth = 0 Or cropHeight = 0 Then
                        Exit Sub
                    End If
                    If cropWidth < 0 And cropHeight > 0 Then
                        cropX = e.X
                        cropWidth = cropWidth * -1
                    ElseIf cropHeight < 0 And cropWidth < 0 Then
                        cropX = e.X
                        cropY = e.Y
                        cropWidth = cropWidth * -1
                        cropHeight = cropHeight * -1
                    ElseIf cropHeight < 0 And cropWidth > 0 Then
                        cropY = e.Y
                        cropHeight = cropHeight * -1
                    End If

                    If cropX > 0 And cropY > 0 Then
                        If (cropWidth + cropX) > ImageDisplay.Width Then cropWidth = (ImageDisplay.Width - cropX) - 2
                        If (cropHeight + cropY) > ImageDisplay.Height Then cropHeight = (ImageDisplay.Height - cropY) - 2
                    ElseIf cropX < 0 And cropY < 0 Then
                        cropWidth = (cropWidth - (cropX * -1))
                        cropHeight = (cropHeight - (cropY * -1))
                    ElseIf cropX < 0 And cropY > 0 Then
                        cropWidth = (cropWidth - (cropX * -1))
                    ElseIf cropX > 0 And cropY < 0 Then
                        cropHeight = (cropHeight - (cropY * -1))
                    End If

                    If cropX < 0 Then cropX = 0
                    If cropY < 0 Then cropY = 0

                    Dim rect As Rectangle = New Rectangle(cropX, cropY, cropWidth, cropHeight)
                    Dim bit As Bitmap = New Bitmap(ImageDisplay.Image, ImageDisplay.Width, ImageDisplay.Height)

                    If rect.Width <> 0 And rect.Height <> 0 Then
                        doesRectangleExist = True
                    Else
                        doesRectangleExist = False
                    End If

                    If (cropWidth + cropX) > ImageDisplay.Width Then cropWidth = (ImageDisplay.Width - cropX) - 2
                    If (cropHeight + cropY) > ImageDisplay.Height Then cropHeight = (ImageDisplay.Height - cropY) - 2

                    cropBitmap = New Bitmap(cropWidth, cropHeight)
                    Dim g As Graphics = Graphics.FromImage(cropBitmap)

                    'Page Crop
                    Dim _adRect As Rectangle = New Rectangle(CInt(cropX * (100 / _scale)), CInt(cropY * (100 / _scale)), CInt(cropWidth * (100 / _scale)), CInt(cropHeight * (100 / _scale)))
                    If IsZoomedIn = False Then _adRect = New Rectangle(cropX, cropY, cropWidth, cropHeight)
                    AdRectangle = _adRect


                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                    g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                    g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                    g.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel)
                    bit.Dispose()
                Catch ex As Exception
                    MsgBox(Err.Description)
                Finally
                    Cursor = Cursors.Default
                End Try
      End If
    End Sub

    Private Sub ImageDisplay_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ImageDisplay.Paint
      If ImageDisplay.SizeMode = PictureBoxSizeMode.Zoom = False Then
        Try
          If SelectionBoxObj.Width > 0 And SelectionBoxObj.Height > 0 Then
            Dim oGradientBrush As Brush = New Drawing.Drawing2D.LinearGradientBrush(SelectionBoxObj.RectangleF, SelectionBoxObj.FillColor, SelectionBoxObj.FillColor, Drawing.Drawing2D.LinearGradientMode.Vertical)

            e.Graphics.FillRectangle(oGradientBrush, SelectionBoxObj.RectangleF)

            Dim TempPen As New Pen(SelectionBoxObj.BorderLineColor, SelectionBoxObj.BorderLineWidth)
            TempPen.DashStyle = SelectionBoxObj.BorderLineType
            e.Graphics.DrawRectangle(TempPen, SelectionBoxObj.RectangleF.X, SelectionBoxObj.RectangleF.Y, SelectionBoxObj.RectangleF.Width, SelectionBoxObj.RectangleF.Height)
          End If
        Catch
          MsgBox(Err.Description)
        End Try
      End If
    End Sub

    Private Sub ImageDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageDisplay.Click

    End Sub

    Private Sub VehicleImageFormBase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      CurrentHeight = Me.Height
      CurrentWidth = Me.Width
    End Sub

    Private Sub VehicleImageFormBase_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
      NewHeight = Me.Height
      NewWidth = Me.Width
    End Sub

    Private Sub VehicleImageFormBase_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
      actualHeight = Me.Height
      actualWidth = Me.Width
    End Sub

    Private Sub VehicleImageFormBase_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
            ImageDisplay.Image = AdjustImageToRetainRatio()
        End Sub
        Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
            If e.Delta < 0 Then

                REM: edited by Mark Marshall, only scroll if panel not equal to zero
                Try
                    If CInt(ImagePanel.VerticalScroll.Value) <> 0 Then
                        ImagePanel.VerticalScroll.Value = ImagePanel.VerticalScroll.Value + 50
                    End If
                Catch ex As ObjectDisposedException
                    MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            ElseIf e.Delta > 0 Then
                If ImagePanel.VerticalScroll.Value >= 50 Then
                    ImagePanel.VerticalScroll.Value = ImagePanel.VerticalScroll.Value - 50
                Else
                    ImagePanel.VerticalScroll.Value = 0
                End If
            End If

        End Sub

        Private Sub DegreeTextBox_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DegreeTextBox.GotFocus
            DegreeTextBox.Select(0, DegreeTextBox.Value.ToString.Length + 2)
        End Sub

        Private Sub DegreeTextBox_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DegreeTextBox.ValueChanged
            If IsNumeric(DegreeTextBox.Text) = False Then Exit Sub
            DegreesTrackBar.Value = CType(DegreeTextBox.Text, Integer)
        End Sub

        Private Sub OkRotateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkRotateButton.Click
            OnRotatePageBy(CType(DegreeTextBox.Text, Integer), True)
            lblisRotatedBy.Text = "true"
            Me.AskToSaveImage = True
            RotatePanel.Visible = False
            ImageDisplay.Image = AdjustImageToRetainRatio()
        End Sub

        Private Sub CancelRotateButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelRotateButton.Click
            RotatePanel.Visible = False
        End Sub

        Private Sub DegreesTrackBar_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DegreesTrackBar.ValueChanged
            DegreeTextBox.Text = DegreesTrackBar.Value.ToString
            OnRotatePageBy(DegreesTrackBar.Value, False)
        End Sub

        Public Sub CoerceGarbageCollection(Optional ByVal disposed As Object = Nothing)
            If Not IsNothing(disposed) Then
                GC.SuppressFinalize(disposed)
            End If
            GC.Collect(GC.MaxGeneration)
            GC.WaitForPendingFinalizers()
        End Sub
    End Class

    Public Class SelectionBox
        '' this is used for drawing a line while creating rectangle in the image
        Private m_Name As String = "SelectionBox"
        Private m_BorderLineColor As Color = Drawing.Color.FromArgb(255, 51, 153, 255)
        Private m_FillColor As Color = Drawing.Color.FromArgb(40, 51, 153, 255)
        Private m_BorderLineType As Drawing2D.DashStyle = Drawing2D.DashStyle.Dash
        Private m_BorderLineWidth As Integer = 5
        Private m_X As Single
        Private m_Y As Single
        Private m_Width As Single
        Private m_Height As Single
        Private m_RectangleF As RectangleF
        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = value
            End Set
        End Property
        Public Property BorderLineWidth() As Integer
            Get
                Return m_BorderLineWidth
            End Get
            Set(ByVal value As Integer)
                m_BorderLineWidth = value
            End Set
        End Property
        Public Property BorderLineType() As Drawing2D.DashStyle
            Get
                Return m_BorderLineType
            End Get
            Set(ByVal value As Drawing2D.DashStyle)
                m_BorderLineType = value
            End Set
        End Property
        Public Property BorderLineColor() As Color
            Get
                Return m_BorderLineColor
            End Get
            Set(ByVal value As Color)
                m_BorderLineColor = value
            End Set
        End Property
        Public Property FillColor() As Color
            Get
                Return m_FillColor
            End Get
            Set(ByVal value As Color)
                m_FillColor = value
            End Set
        End Property
        Public Property X() As Single
            Get
                Return m_RectangleF.X
            End Get
            Set(ByVal value As Single)
                m_RectangleF.X = value
            End Set
        End Property
        Public Property Y() As Single
            Get
                Return m_RectangleF.Y
            End Get
            Set(ByVal value As Single)
                m_RectangleF.Y = value
            End Set
        End Property
        Public Property Width() As Single
            Get
                Return m_RectangleF.Width
            End Get
            Set(ByVal value As Single)
                m_RectangleF.Width = value
            End Set
        End Property
        Public Property Height() As Single
            Get
                Return m_RectangleF.Height
            End Get
            Set(ByVal value As Single)
                m_RectangleF.Height = value
            End Set
        End Property
        Public Property RectangleF() As RectangleF
            Get
                Return m_RectangleF
            End Get
            Set(ByVal value As RectangleF)
                m_RectangleF = value
            End Set
        End Property
    End Class
End Namespace