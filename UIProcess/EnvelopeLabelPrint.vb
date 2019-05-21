
Public Class EnvelopeLabelPrint
  Inherits PrintBase


  Private m_envelopeId As Integer
  Private m_senderName As String
    Private m_comment As String
    Private m_priority As String


  ''' <summary>
  ''' Gets or sets Envelope Id.
  ''' </summary>
  Public Property EnvelopeId() As Integer
    Get
      Return m_envelopeId
    End Get
    Set(ByVal value As Integer)
      m_envelopeId = value
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
  ''' Gets or sets envelope sender name.
  ''' </summary>
  Public Property SenderName() As String
    Get
      Return m_senderName
    End Get
    Set(ByVal value As String)
      m_senderName = value
    End Set
  End Property

  ''' <summary>
  ''' Gets or sets comment text.
  ''' </summary>
  Public Property Comment() As String
    Get
      Return m_comment
    End Get
    Set(ByVal value As String)
      m_comment = value
    End Set
  End Property


  Protected Overrides Sub Finalize()
    m_comment = Nothing
    m_senderName = Nothing
    m_envelopeId = Nothing
    MyBase.Finalize()
  End Sub


  ''' <summary>
  ''' Prints label for new Envelope on Generic Text Only printer.
  ''' </summary>
    Private Sub ForNewEnvelopeOnGenericTextOnlyPrinter(ByVal printer As System.Drawing.Printing.PrintPageEventArgs)

        Dim leftMargin, topMargin As Single
        Dim line As System.Text.StringBuilder
        Dim textFont As System.Drawing.Font
        Dim myBrush As New SolidBrush(Color.Black)


        line = New System.Text.StringBuilder()

        line.AppendLine("N")

        line.Append("B0,0,0,1,2,4,40,N,""")
        line.Append(Me.EnvelopeId)
        line.AppendLine("""")

        line.Append("A165,0,0,2,1,1,N,""")
        line.Append(Me.EnvelopeId)
        line.Append("")
        line.Append(" ")
        line.Append(Me.PriorityId)

        line.AppendLine("""")

        line.Append("A0,55,0,2,1,1,N,""")
        line.Append(Me.SenderName)
        line.AppendLine("""")
        line.AppendLine("P1")

        leftMargin = 0.0
        topMargin = 0.0
        textFont = New System.Drawing.Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point)

        printer.Graphics.DrawString(line.ToString(), textFont, myBrush, leftMargin, topMargin, New System.Drawing.StringFormat())


        myBrush.Dispose()
        myBrush = Nothing

        textFont.Dispose()
        textFont = Nothing

        line.Remove(0, line.Length)
        line = Nothing
    End Sub

    ''' <summary>
    ''' Prints label for new Envelope on Non Generic Text Only printer.
    ''' </summary>

    Private Sub ForNewEnvelopeOnNonGenericTextOnlyPrinter(ByVal printer As System.Drawing.Printing.PrintPageEventArgs)

        Dim leftMargin, topMargin, xPosition, yPosition As Single
        Dim line As System.Text.StringBuilder
        Dim stringSize As System.Drawing.SizeF
        Dim barcodeFont, textFont As System.Drawing.Font
        Dim myBrush As System.Drawing.Brush


        myBrush = New SolidBrush(Color.Black)
        line = New System.Text.StringBuilder()

        leftMargin = 5.0 : topMargin = 3.0 : xPosition = leftMargin : yPosition = topMargin + 4.5!

        barcodeFont = New System.Drawing.Font("Code 128AB", 20, FontStyle.Regular, GraphicsUnit.Point)

        line.Append(EncodeToBC128A(Me.EnvelopeId.ToString()))
        ' calculate the next line position based on the height of the font according to the printing device 
        ' yPosition = topMargin + (count * textFont.GetHeight(ev.Graphics)); // draw the next line in the 
        ' rich edit control
        printer.Graphics.DrawString(line.ToString(), barcodeFont, myBrush, xPosition, yPosition, New System.Drawing.StringFormat())

        stringSize = printer.Graphics.MeasureString(line.ToString(), barcodeFont)
        barcodeFont.Dispose()
        barcodeFont = Nothing

        textFont = New System.Drawing.Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point)

        xPosition += stringSize.Width + 1
        line.Remove(0, line.Length)
        line.Append(Me.EnvelopeId)

        printer.Graphics.DrawString(line.ToString(), textFont, myBrush, xPosition, yPosition, New System.Drawing.StringFormat)

        'yPosition += barcodeFont.GetHeight(printer.Graphics) + 0.25!
        yPosition += stringSize.Height + 0.25!
        stringSize = Nothing
        line.Remove(0, line.Length)
        line.Append(" ")  'A blank space is kept to left align with barcode.
        line.Append(Me.SenderName)
        line.Append(" ")  'A blank space is kept to left align with barcode.
        line.Append(Me.PriorityId)


        ' calculate the next line position based on the height of the font according to the printing device 
        'yPosition = topMargin + (count * textFont.GetHeight(ev.Graphics));// draw the next line in the 
        'rich edit control
        printer.Graphics.DrawString(line.ToString(), textFont, myBrush, leftMargin, yPosition, New System.Drawing.StringFormat)

        line.Remove(0, line.Length)
        line = Nothing

        myBrush.Dispose()
        myBrush = Nothing

        textFont.Dispose()
        textFont = Nothing

    End Sub

    ''' <summary>
    ''' Prints label for new Retailer on Generic Text Only printer.
    ''' </summary>
    Private Sub ForNewRetailerOnGenericTextOnlyPrinter(ByVal printer As System.Drawing.Printing.PrintPageEventArgs)
        Dim leftMargin, topMargin As Single
        Dim line As System.Text.StringBuilder
        Dim textFont As System.Drawing.Font
        Dim myBrush As New SolidBrush(Color.Black)

        line = New System.Text.StringBuilder()

        line.AppendLine("N")

        line.Append("B0,0,0,1,2,4,40,N,""")
        line.Append(Me.EnvelopeId)
        line.AppendLine("""")

        line.Append("A165,0,0,2,1,1,N,""")
        line.Append(Me.EnvelopeId)
        'line.Append("")
        'line.Append(" ")
        'line.Append(Me.PriorityId)
        line.AppendLine("""")


        line.Append("A0,55,0,2,1,1,N,""")
        line.Append(Me.SenderName)
        line.AppendLine("""")

        line.Append("A175,55,0,2,1,1,N,""")
        line.Append(Me.Comment)
        line.AppendLine("""")

        line.AppendLine("P1")

        leftMargin = 0.0
        topMargin = 0.0
        textFont = New System.Drawing.Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point)

        printer.Graphics.DrawString(line.ToString(), textFont, myBrush, leftMargin, topMargin, New System.Drawing.StringFormat())

        myBrush.Dispose()
        myBrush = Nothing

        textFont.Dispose()
        textFont = Nothing

        line.Remove(0, line.Length)
        line = Nothing
    End Sub

    ''' <summary>
    ''' Prints label for new Retailer on Non Generic Text Only printer.
    ''' </summary>
    Private Sub ForNewRetailerOnNonGenericTextOnlyPrinter(ByVal printer As System.Drawing.Printing.PrintPageEventArgs)
        Dim leftMargin, topMargin, xPosition, yPosition As Single
        Dim line As System.Text.StringBuilder
        Dim stringSize As System.Drawing.SizeF
        Dim barcodeFont, textFont As System.Drawing.Font
        Dim myBrush As System.Drawing.Brush


        myBrush = New SolidBrush(Color.Black)
        line = New System.Text.StringBuilder()

        leftMargin = 5.0 : topMargin = 5.0 : xPosition = leftMargin : yPosition = topMargin + 4.5!

        barcodeFont = New System.Drawing.Font("Code 128AB", 24, FontStyle.Regular, GraphicsUnit.Point)

        line.Append(EncodeToBC128A(Me.EnvelopeId.ToString()))
        ' calculate the next line position based on the height of the font according to the printing device 
        ' yPosition = topMargin + (count * textFont.GetHeight(ev.Graphics)); // draw the next line in the 
        ' rich edit control
        printer.Graphics.DrawString(line.ToString(), barcodeFont, myBrush, xPosition, yPosition, New System.Drawing.StringFormat())

        stringSize = printer.Graphics.MeasureString(line.ToString(), barcodeFont)
        barcodeFont.Dispose()
        barcodeFont = Nothing

        textFont = New System.Drawing.Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point)

        xPosition += stringSize.Width + 1
        line.Remove(0, line.Length)
        line.Append(Me.EnvelopeId.ToString())

        printer.Graphics.DrawString(line.ToString(), textFont, myBrush, xPosition, yPosition, New System.Drawing.StringFormat)

        'yPosition += barcodeFont.GetHeight(printer.Graphics) + 0.25!
        yPosition += stringSize.Height + 0.25!
        stringSize = Nothing
        line.Remove(0, line.Length)
        line.Append(" ")  'A blank space is kept to left align with barcode.
        line.Append(Me.SenderName)
        line.Append(", ")
        line.Append(Me.Comment)
        'line.Append(", ")
        'line.Append(" ") '
        'line.Append(Me.PriorityId)

        'Calculate the next line position based on the height of the font according to the printing device 
        'yPosition = topMargin + (count * textFont.GetHeight(ev.Graphics));// draw the next line in the 
        'rich edit control
        printer.Graphics.DrawString(line.ToString(), textFont, myBrush, leftMargin, yPosition, New System.Drawing.StringFormat)

        line.Remove(0, line.Length)
        line = Nothing

        myBrush.Dispose()
        myBrush = Nothing

        textFont.Dispose()
        textFont = Nothing

    End Sub


    Protected Overrides Sub PrintOnGenericTextOnlyPrinter(ByVal printer As System.Drawing.Printing.PrintPageEventArgs)

        If Me.Comment Is Nothing Then
            ForNewEnvelopeOnGenericTextOnlyPrinter(printer)
        Else
            ForNewRetailerOnGenericTextOnlyPrinter(printer)
        End If

    End Sub

    Protected Overrides Sub PrintOnNonGenericPrinter(ByVal printer As System.Drawing.Printing.PrintPageEventArgs)

        If Me.Comment Is Nothing Then
            ForNewEnvelopeOnNonGenericTextOnlyPrinter(printer)
        Else
            ForNewRetailerOnNonGenericTextOnlyPrinter(printer)
        End If

    End Sub


End Class