﻿
Public MustInherit Class PrintBase
  Implements IDisposable


  Private m_printerName As String
  Private WithEvents m_document As System.Drawing.Printing.PrintDocument


  ''' <summary>
  ''' Gets or sets printer name. Print operation redirects output to this printer.
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property PrinterName() As String
    Get
      Return m_printerName
    End Get
    Set(ByVal value As String)
      m_printerName = value
    End Set
  End Property


#Region " Constructor and Destructor "

  Sub New()

    m_document = New System.Drawing.Printing.PrintDocument()

  End Sub

#Region " IDispose Implementation "


  Private disposedValue As Boolean = False    ' To detect redundant calls


  ' IDisposable
  Protected Overridable Sub Dispose(ByVal disposing As Boolean)
    If Not Me.disposedValue Then
      If disposing Then
        ' TODO: free other state (managed objects).
        m_document.Dispose()
        m_document = Nothing
      End If

      ' TODO: free your own state (unmanaged objects).
      ' TODO: set large fields to null.
    End If
    Me.disposedValue = True
  End Sub


#Region " IDisposable Support "

  ' This code added by Visual Basic to correctly implement the disposable pattern.
  Public Sub Dispose() Implements IDisposable.Dispose
    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    Dispose(True)
    GC.SuppressFinalize(Me)
  End Sub

#End Region


#End Region

  Protected Overrides Sub Finalize()

    m_printerName = Nothing
    m_document = Nothing

  End Sub

#End Region


  ''' <summary>
  ''' Prints on non Generic Text Only printer.
  ''' </summary>
  ''' <param name="printer">Provides properties and methods to deal with printing process.</param>
  Protected MustOverride Sub PrintOnNonGenericPrinter(ByVal printer As System.Drawing.Printing.PrintPageEventArgs)

  ''' <summary>
  ''' Prints on Generic Text Only printer.
  ''' </summary>
  ''' <param name="printer">Provides properties and methods to deal with printing process.</param>
  Protected MustOverride Sub PrintOnGenericTextOnlyPrinter(ByVal printer As System.Drawing.Printing.PrintPageEventArgs)


  ''' <summary>
  ''' Sets barcode printer for m_printDocument. If the printer found but if
  ''' it is not a valid printer, printer name is reset to default printer.
  ''' </summary>
  ''' <remarks></remarks>
  Protected Sub SetPrinter()
    Dim printerCounter As Integer
    Dim printerName, defaultPrinter As String


    printerName = String.Empty

    With System.Drawing.Printing.PrinterSettings.InstalledPrinters
      For printerCounter = 0 To .Count - 1
        If .Item(printerCounter).ToUpper().IndexOf(Me.PrinterName.ToUpper()) >= 0 Then
          printerName = .Item(printerCounter)
          Exit For
        End If
      Next
    End With

    With m_document.PrinterSettings
      If printerName.Length > 0 Then
        defaultPrinter = .PrinterName
        .PrinterName = printerName
        If .IsValid = False Then .PrinterName = defaultPrinter
      End If
    End With

  End Sub


  Public Sub Print()

    SetPrinter()
    m_document.Print()

  End Sub


  Private Sub m_document_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles m_document.PrintPage

    If PrinterName.IndexOf("Generic / Text Only") >= 0 Then
      PrintOnGenericTextOnlyPrinter(e)
    Else
      PrintOnNonGenericPrinter(e)
    End If

  End Sub


End Class