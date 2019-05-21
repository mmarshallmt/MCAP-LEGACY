
Public Class VehicleLabelPrint
  Inherits PrintBase


  Private m_adDate As DateTime
  Private m_createdBy As String
  Private m_marketName As String
  Private m_priority As Integer
  Private m_retailerName As String
  Private m_scanDPI As Integer
  Private m_vehicleId As Integer


  ''' <summary>
  ''' Gets or sets retailer name.
  ''' </summary>
  Public Property Retailer() As String
    Get
      Return m_retailerName
    End Get
    Set(ByVal value As String)
      m_retailerName = value
    End Set
  End Property

  ''' <summary>
  ''' Gets or sets market name.
  ''' </summary>
  Public Property Market() As String
    Get
      Return m_marketName
    End Get
    Set(ByVal value As String)
      m_marketName = value
    End Set
  End Property

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
  ''' Gets or sets priority.
  ''' </summary>
  Public Property Priority() As Integer
    Get
      Return m_priority
    End Get
    Set(ByVal value As Integer)
      m_priority = value
    End Set
  End Property

  ''' <summary>
  ''' Gets or sets Ad date.
  ''' </summary>
  Public Property AdDate() As DateTime
    Get
      Return m_adDate
    End Get
    Set(ByVal value As DateTime)
      m_adDate = value
    End Set
  End Property

  ''' <summary>
  ''' Gets or sets vehicle creator name.
  ''' </summary>
  Public Property CreatedBy() As String
    Get
      Return m_createdBy
    End Get
    Set(ByVal value As String)
      m_createdBy = value
    End Set
  End Property

  ''' <summary>
  ''' Gets or sets scan DPI.
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
    m_adDate = Nothing
    m_createdBy = Nothing
    m_marketName = Nothing
    m_priority = Nothing
    m_retailerName = Nothing
    m_scanDPI = Nothing
    m_vehicleId = Nothing
    MyBase.Finalize()
  End Sub


  ''' <summary>
  ''' Prints label for new Vehicle on Generic Text Only printer.
  ''' </summary>
  Private Sub ForNewVehicleOnGenericTextOnlyPrinter(ByVal page As System.Drawing.Printing.PrintPageEventArgs)
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
    line.Append(Me.Retailer)
    line.AppendLine("""")

    line.Append("A165,23,0,2,1,1,N,""")
    line.Append(Me.Market)
    line.AppendLine("""")

    line.Append("A0,55,0,2,1,1,N,""")
    line.Append(Me.VehicleId)
    line.Append(", ")
    line.Append(Me.Priority)
    If Me.ScanDPI > 0 Then
      line.Append(", ")
      line.Append(Me.ScanDPI)
    End If
    line.Append(", ")
    line.Append(Me.AdDate.ToString("MM/dd/yy"))
    line.Append(", ")
    line.Append(Me.CreatedBy)
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
  ''' Prints label for new Vehicle on Non Generic Text Only printer.
  ''' </summary>
  Private Sub ForNewVehicleOnNonGenericTextOnlyPrinter(ByVal page As System.Drawing.Printing.PrintPageEventArgs)
    Dim leftMargin, topMargin, xPosition, yPosition As Single
    Dim line As System.Text.StringBuilder
    Dim stringSize As System.Drawing.SizeF
    Dim barcodeFont, textFont As System.Drawing.Font
    Dim myBrush As System.Drawing.Brush


    myBrush = New SolidBrush(Color.Black)
    line = New System.Text.StringBuilder()

    leftMargin = 5.0 : topMargin = 5.0 : xPosition = leftMargin : yPosition = topMargin + 4.5!

        barcodeFont = New System.Drawing.Font("Code 128AB", 20, FontStyle.Regular, GraphicsUnit.Point)

        line.Append(EncodeToBC128A(Me.VehicleId.ToString()))

    page.Graphics.DrawString(line.ToString(), barcodeFont, myBrush, xPosition, yPosition, New System.Drawing.StringFormat())

    stringSize = page.Graphics.MeasureString(line.ToString(), barcodeFont)
    barcodeFont.Dispose()
    barcodeFont = Nothing

    textFont = New System.Drawing.Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point)

    xPosition += stringSize.Width + 1
    stringSize = Nothing
        line.Remove(0, line.Length)
    line.Append(Me.Retailer)

    page.Graphics.DrawString(line.ToString(), textFont, myBrush, xPosition, yPosition, New System.Drawing.StringFormat)

    yPosition += textFont.GetHeight(page.Graphics) + 0.25!
        'line.Remove(0, line.Length)
        line.Append(Me.Market)

    page.Graphics.DrawString(line.ToString(), textFont, myBrush, xPosition, yPosition, New System.Drawing.StringFormat)

    yPosition += textFont.GetHeight(page.Graphics) + 0.25!
        'line.Remove(0, line.Length)
    line.Append(" ")  'A blank space is kept to left align with barcode.
        'line.Append(Me.VehicleId)
    line.Append(", ")
        line.Append(Me.Priority)
    If Me.ScanDPI > 0 Then
      line.Append(", ")
      line.Append(Me.ScanDPI)
    End If
    line.Append(", ")
    line.Append(Me.AdDate.ToString("MM/dd/yy"))
    line.Append(", ")
    line.Append(Me.CreatedBy)

    page.Graphics.DrawString(line.ToString(), textFont, myBrush, leftMargin, yPosition, New System.Drawing.StringFormat)

    line.Remove(0, line.Length)
    line = Nothing

    myBrush.Dispose()
    myBrush = Nothing

    textFont.Dispose()
    textFont = Nothing
  End Sub


  Protected Overrides Sub PrintOnGenericTextOnlyPrinter(ByVal printer As System.Drawing.Printing.PrintPageEventArgs)

    ForNewVehicleOnGenericTextOnlyPrinter(printer)

  End Sub

  Protected Overrides Sub PrintOnNonGenericPrinter(ByVal printer As System.Drawing.Printing.PrintPageEventArgs)

    ForNewVehicleOnNonGenericTextOnlyPrinter(printer)

  End Sub


End Class
