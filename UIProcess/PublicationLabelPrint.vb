
Public Class PublicationLabelPrint
  Inherits PrintBase


  Private m_isDuplicate As Boolean
  Private m_newspaperDate As DateTime
  Private m_publicationName As String
  Private m_scanDPI As Integer
    Private m_vehicleId As Integer
    Private m_priority As String


  ''' <summary>
  ''' Gets or sets vehicle Id.
  ''' </summary>
  Public Property VehicleId() As Integer
    Get
      Return m_vehicleId
    End Get
    Set(ByVal value As Integer)
      m_vehicleId = value
    End Set
    End Property
    ''' <summary>
    ''' Gets or sets Priority Id.
    ''' </summary>
    Public Property PriorityId() As String
        Get
            Return m_priority
        End Get
        Set(ByVal value As String)
            m_priority = value
        End Set
    End Property

  ''' <summary>
  ''' Gets or sets newspaper date.
  ''' </summary>
  Public Property NewspaperDate() As DateTime
    Get
      Return m_newspaperDate
    End Get
    Set(ByVal value As DateTime)
      m_newspaperDate = value
    End Set
  End Property

  ''' <summary>
  ''' Gets or sets publication name.
  ''' </summary>
  Public Property Publication() As String
    Get
      Return m_publicationName
    End Get
    Set(ByVal value As String)
      m_publicationName = value
    End Set
  End Property

  ''' <summary>
  ''' Gets or sets boolean value indicating whether the label should be printed for duplicate publication or not.
  ''' </summary>
  Public Property IsDuplicate() As Boolean
    Get
      Return m_isDuplicate
    End Get
    Set(ByVal value As Boolean)
      m_isDuplicate = value
    End Set
  End Property

  ''' <summary>
  ''' Gets or sets value of scan DPI.
  ''' </summary>
  Public Property ScanDPI() As Integer
    Get
      Return m_scanDPI
    End Get
    Set(ByVal value As Integer)
      m_scanDPI = value
    End Set
  End Property


  Protected Overrides Sub Finalize()
    m_isDuplicate = Nothing
    m_newspaperDate = Nothing
    m_publicationName = Nothing
    m_scanDPI = Nothing
    m_vehicleId = Nothing
    MyBase.Finalize()
  End Sub


  ''' <summary>
  ''' Prints label for new publication on Generic Text Only printer.
  ''' </summary>
    Private Sub ForNewPublicationOnGenericTextOnlyPrinter(ByVal page As System.Drawing.Printing.PrintPageEventArgs)
        Dim leftMargin, topMargin As Single
        Dim line As System.Text.StringBuilder
        Dim textFont As System.Drawing.Font
        Dim myBrush As New SolidBrush(Color.Black)


        line = New System.Text.StringBuilder()

        line.AppendLine("N")

        line.Append("B0,0,0,1,2,4,40,N,""")
        line.Append(Me.VehicleId)
        line.AppendLine("""")

        line.Append("A165,0,0,2,1,1,N,""")
        line.Append(Me.VehicleId)

        line.Append("")
        line.Append(" ")
        line.Append(Me.PriorityId)
        line.AppendLine("""")

        line.Append("A165,23,0,2,1,1,N,""")
        line.Append(Me.NewspaperDate.ToString("MM/dd/yy"))
        line.AppendLine("""")

        line.Append("A0,55,0,2,1,1,N,""")
        line.Append(Me.Publication)
        If Me.ScanDPI > 0 Then
            line.Append(", ")
            line.Append(Me.ScanDPI)
        End If
        line.AppendLine("""")

        line.AppendLine("P1")

        leftMargin = 0.0
        topMargin = 0.0
        textFont = New System.Drawing.Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point)

        page.Graphics.DrawString(line.ToString(), textFont, myBrush, leftMargin, topMargin, New System.Drawing.StringFormat())

        myBrush.Dispose()
        myBrush = Nothing

        textFont.Dispose()
        textFont = Nothing

        line.Remove(0, line.Length)
        line = Nothing
    End Sub

    ''' <summary>
    ''' Prints label for new publication on Non Generic Text Only printer.
    ''' </summary>

    Private Sub ForNewPublicationOnNonGenericTextOnlyPrinter(ByVal page As System.Drawing.Printing.PrintPageEventArgs)
        Dim leftMargin, topMargin, xPosition, yPosition As Single
        Dim line As System.Text.StringBuilder
        Dim stringSize As System.Drawing.SizeF
        Dim barcodeFont, textFont As System.Drawing.Font
        Dim myBrush As System.Drawing.Brush


        myBrush = New SolidBrush(Color.Black)
        line = New System.Text.StringBuilder()

        leftMargin = 5.0 : topMargin = 5.0 : xPosition = leftMargin : yPosition = topMargin + 4.5!

        barcodeFont = New System.Drawing.Font("Code 128AB", 24, FontStyle.Regular, GraphicsUnit.Point)

        line.Append(EncodeToBC128A(Me.VehicleId.ToString()))

        page.Graphics.DrawString(line.ToString(), barcodeFont, myBrush, xPosition, yPosition, New System.Drawing.StringFormat())

        stringSize = page.Graphics.MeasureString(line.ToString(), barcodeFont)
        barcodeFont.Dispose()
        barcodeFont = Nothing

        textFont = New System.Drawing.Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point)

        xPosition += stringSize.Width + 1
        stringSize = Nothing
        line.Remove(0, line.Length)
        line.Append(Me.VehicleId)

        page.Graphics.DrawString(line.ToString(), textFont, myBrush, xPosition, yPosition, New System.Drawing.StringFormat)

        yPosition += textFont.GetHeight(page.Graphics) + 0.25!
        line.Remove(0, line.Length)
        line.Append(Me.NewspaperDate.ToString("MM/dd/yy"))

        page.Graphics.DrawString(line.ToString(), textFont, myBrush, xPosition, yPosition, New System.Drawing.StringFormat)

        yPosition += textFont.GetHeight(page.Graphics) + 0.25!
        line.Remove(0, line.Length)
        line.Append(" ")  'A blank space is kept to left align with barcode.
        line.Append(Me.Publication)
        If Me.ScanDPI > 0 Then
            line.Append(", ")
            line.Append(Me.ScanDPI)
        End If
        line.Append(", ")
        line.Append(Me.PriorityId)

        page.Graphics.DrawString(line.ToString(), textFont, myBrush, leftMargin, yPosition, New System.Drawing.StringFormat)

        line.Remove(0, line.Length)
        line = Nothing

        myBrush.Dispose()
        myBrush = Nothing

        textFont.Dispose()
        textFont = Nothing
    End Sub

    ''' <summary>
    ''' Prints label for duplicate publication on Generic Text Only printer.
    ''' </summary>
    Private Sub ForDuplicatePublicationOnGenericTextOnlyPrinter(ByVal page As System.Drawing.Printing.PrintPageEventArgs)
        Dim leftMargin, topMargin As Single
        Dim line As System.Text.StringBuilder
        Dim textFont As System.Drawing.Font
        Dim myBrush As New SolidBrush(Color.Black)


        line = New System.Text.StringBuilder()

        line.AppendLine("N")

        line.Append("B0,0,0,1,2,4,40,N,""")
        line.Append(Me.VehicleId.ToString())
        line.AppendLine("""")

        line.Append("A165,0,0,2,1,1,N,""")
        line.Append(Me.VehicleId.ToString())
        line.Append(" - DUP")
        line.Append("")
        line.Append(" ")
        line.Append(Me.PriorityId)
        line.AppendLine("""")

        line.Append("A165,23,0,2,1,1,N,""")
        line.Append(Me.NewspaperDate.ToString("MM/dd/yy"))
        line.AppendLine("""")

        line.Append("A0,55,0,2,1,1,N,""")
        line.Append(Me.Publication)
        If Me.ScanDPI > 0 Then
            line.Append(", ")
            line.Append(Me.ScanDPI)
        End If
        line.AppendLine("""")


        line.AppendLine("P1")

        leftMargin = 0.0
        topMargin = 0.0
        textFont = New System.Drawing.Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point)

        page.Graphics.DrawString(line.ToString(), textFont, myBrush, leftMargin, topMargin, New System.Drawing.StringFormat())

        myBrush.Dispose()
        myBrush = Nothing

        textFont.Dispose()
        textFont = Nothing

        line.Remove(0, line.Length)
        line = Nothing
    End Sub

    ''' <summary>
    ''' Prints label for duplicate publication on Non Generic Text Only printer.
    ''' </summary>
    Private Sub ForDuplicatePublicationOnNonGenericTextOnlyPrinter(ByVal page As System.Drawing.Printing.PrintPageEventArgs)
        Dim leftMargin, topMargin, xPosition, yPosition As Single
        Dim line As System.Text.StringBuilder
        Dim stringSize As System.Drawing.SizeF
        Dim barcodeFont, textFont As System.Drawing.Font
        Dim myBrush As System.Drawing.Brush


        myBrush = New SolidBrush(Color.Black)
        line = New System.Text.StringBuilder()

        leftMargin = 5.0 : topMargin = 5.0 : xPosition = leftMargin : yPosition = topMargin + 4.5!

        barcodeFont = New System.Drawing.Font("Code 128AB", 24, FontStyle.Regular, GraphicsUnit.Point)

        line.Append(EncodeToBC128A(Me.VehicleId.ToString()))

        page.Graphics.DrawString(line.ToString(), barcodeFont, myBrush, xPosition, yPosition, New System.Drawing.StringFormat())

        stringSize = page.Graphics.MeasureString(line.ToString(), barcodeFont)
        barcodeFont.Dispose()
        barcodeFont = Nothing

        textFont = New System.Drawing.Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point)

        xPosition += stringSize.Width + 1
        stringSize = Nothing
        line.Remove(0, line.Length)
        line.Append(Me.VehicleId)
        line.Append(" - DUP")

        page.Graphics.DrawString(line.ToString(), textFont, myBrush, xPosition, yPosition, New System.Drawing.StringFormat)

        yPosition += textFont.GetHeight(page.Graphics) + 0.25!
        line.Remove(0, line.Length)
        line.Append(Me.NewspaperDate.ToString("MM/dd/yy"))

        page.Graphics.DrawString(line.ToString(), textFont, myBrush, xPosition, yPosition, New System.Drawing.StringFormat)

        yPosition += textFont.GetHeight(page.Graphics) + 0.25!
        line.Remove(0, line.Length)
        line.Append(" ")  'A blank space is kept to left align with barcode.
        line.Append(Me.Publication)
        If Me.ScanDPI > 0 Then
            line.Append(", ")
            line.Append(Me.ScanDPI)
        End If
        line.Append(", ")
        line.Append(Me.PriorityId)
        page.Graphics.DrawString(line.ToString(), textFont, myBrush, leftMargin, yPosition, New System.Drawing.StringFormat)

        line.Remove(0, line.Length)
        line = Nothing

        myBrush.Dispose()
        myBrush = Nothing

        textFont.Dispose()
        textFont = Nothing
    End Sub


    Protected Overrides Sub PrintOnGenericTextOnlyPrinter(ByVal printer As System.Drawing.Printing.PrintPageEventArgs)

        If Me.IsDuplicate Then
            ForDuplicatePublicationOnGenericTextOnlyPrinter(printer)
        Else
            ForNewPublicationOnGenericTextOnlyPrinter(printer)
        End If

    End Sub

    Protected Overrides Sub PrintOnNonGenericPrinter(ByVal printer As System.Drawing.Printing.PrintPageEventArgs)

        If Me.IsDuplicate Then
            ForDuplicatePublicationOnNonGenericTextOnlyPrinter(printer)
        Else
            ForNewPublicationOnNonGenericTextOnlyPrinter(printer)
        End If

    End Sub


End Class
