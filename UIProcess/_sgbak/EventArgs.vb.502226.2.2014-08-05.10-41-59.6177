Namespace UI.Processors

  Public Class EventArgs
    Inherits System.EventArgs
    Implements IDisposable


    Private _information As System.Collections.Hashtable


    Sub New()
      MyBase.New()

      _information = New System.Collections.Hashtable
    End Sub


#Region " IDisposable Implementation "


    Private disposedValue As Boolean = False    ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: free other state (managed objects).
          _information.Clear()
        End If

        ' TODO: free your own state (unmanaged objects).
        ' TODO: set large fields to null.
        _information = Nothing
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
      _information.Clear()
      _information = Nothing
      MyBase.Finalize()
    End Sub


    ''' <summary>
    ''' Gets or sets additional information about event.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Data() As System.Collections.IDictionary
      Get
        Return _information
      End Get
    End Property

  End Class

End Namespace