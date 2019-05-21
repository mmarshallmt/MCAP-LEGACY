

Partial Public Class PageDefinitionsDataSet
  Public Class PageTypes
    Public Const Base As Char = "B"c
    'Public Const Wrap As Char = "W"c
    'Public Const Insert As Char = "I"c
  End Class
  Partial Class PageDataTable
    Public Function GetRow(ByVal pageName As String) As PageRow
      Dim i As Integer
      Dim p As PageRow
      For i = 0 To Me.Rows.Count - 1
        p = CType(Me.Rows(i), PageRow)
        If p.PageName = pageName Then
          Return p
        End If
      Next
      Return Nothing
    End Function
  End Class
  Partial Class PagesDataTable
    Public Overloads Function AddPagesRow() As PagesRow
      Dim page As PagesRow = CType(Me.NewRow, PagesRow)
      page.PageTypeId = "B"c
      page.SetPageNameNull()
      page.SetPageNumberNull()
      page.SetReceivedOrderNull()
      page.SetInsertNumberNull()
      page.SetSizeIdNull()
      page.SetSizeNull()
      Try
        Me.Rows.Add(page)
      Catch ex As Exception
        Debug.Print("ERROR: " & ex.ToString)
      End Try
      Return page
    End Function

    Public Function GetRowIndex(ByVal pageName As String) As Integer
      Dim i As Integer
      Dim p As PagesRow
      For i = 0 To Me.Rows.Count - 1
        p = CType(Me.Rows(i), PagesRow)
        If p.PageName = pageName Then
          Return i
        End If
      Next
    End Function

    Public Function GetRow(ByVal pageName As String) As PagesRow
      Dim i As Integer
      Dim p As PagesRow
      For i = 0 To Me.Rows.Count - 1
        p = CType(Me.Rows(i), PagesRow)
        If p.PageName = pageName Then
          Return p
        End If
      Next
      Return Nothing
    End Function

    Public Function GetInsertPages(ByVal insertNumber As Integer) As PagesRowCollection
      Dim prc As New PagesRowCollection
      Dim page As PagesRow
      'For Each page In Me.Rows
      '  If Not page.IsInsertNumberNull Then
      '    If page.InsertNumber = insertNumber Then
      '      prc.Add(page)
      '    End If
      '  End If
      'Next
      For Each page In Me.Select("InsertNumber = '" & insertNumber.ToString & "'")
        prc.Add(page)
      Next
      Return prc
    End Function
    Public Function GetAllInsertPages() As PagesRowCollection
      Dim prc As New PagesRowCollection
      Dim page As PagesRow
      'For Each page In Me.Rows
      '  If page.PageTypeId = PageTypes.Insert Then
      '    prc.Add(page)
      '  End If
      'Next
      For Each page In Me.Select("PageTypeId <> '" & PageTypes.Base & "'")
        prc.Add(page)
      Next
      Return prc
    End Function
    Public Function GetBasePages() As PagesRowCollection
      Dim prc As New PagesRowCollection
      Dim page As PagesRow
      'For Each page In Me.Rows
      '  If page.PageTypeId = PageTypes.Base Then
      '    prc.Add(page)
      '  End If
      'Next
      For Each page In Me.Select("PageTypeId = '" & PageTypes.Base & "'")
        prc.Add(page)
      Next
      Return prc
    End Function
    'Public Function GetWrapPages() As PagesRowCollection
    '  Dim prc As New PagesRowCollection
    '  Dim page As PagesRow
    '  'For Each page In Me.Rows
    '  '  If page.PageTypeId = PageTypes.Wrap Then
    '  '    prc.Add(page)
    '  '  End If
    '  'Next
    '  For Each page In Me.Select("PageTypeId = '" & PageTypes.Wrap & "'")
    '    prc.Add(page)
    '  Next
    '  Return prc
    'End Function
  End Class

  Partial Class PagesRow
    Public Overrides Function ToString() As String
      Dim page As New ArrayList
      If Not IsPageNameNull() Then
        page.Add("Page: " & Me.PageName)
      End If
      If Not IsPageNumberNull() Then
        page.Add("PageNumber: " & PageNumber.ToString)
      End If
      If Not IsReceivedOrderNull() Then
        page.Add("ReceivedOrder: " & ReceivedOrder.ToString)
      End If
      If Not IsSizeIdNull() Then
        page.Add("SizeId: " & SizeId.ToString)
      End If
      If Not IsSizeNull() Then
        page.Add("Size: " & Size)
      End If
      If Not IsInsertNumberNull() Then
        page.Add("InsertNumber: " & InsertNumber.ToString)
      End If
      Return Join(page.ToArray, "|")
    End Function
  End Class

  Partial Class PagesRowCollection
    Implements ICollection(Of PagesRow)

    Private m_pages As New ArrayList

    Public Sub Add(ByVal item As PagesRow) Implements System.Collections.Generic.ICollection(Of PagesRow).Add
      m_pages.Add(item)
    End Sub

    Public Sub Clear() Implements System.Collections.Generic.ICollection(Of PagesRow).Clear
      m_pages.Clear()
    End Sub

    Public Function Contains(ByVal item As PagesRow) As Boolean Implements System.Collections.Generic.ICollection(Of PagesRow).Contains
      Return m_pages.Contains(item)
    End Function

    Public Sub CopyTo(ByVal array() As PagesRow, ByVal arrayIndex As Integer) Implements System.Collections.Generic.ICollection(Of PagesRow).CopyTo
      m_pages.CopyTo(array, arrayIndex)
    End Sub

    Public ReadOnly Property Count() As Integer Implements System.Collections.Generic.ICollection(Of PagesRow).Count
      Get
        Return m_pages.Count
      End Get
    End Property

    Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.Generic.ICollection(Of PagesRow).IsReadOnly
      Get
        Return m_pages.IsReadOnly
      End Get
    End Property

    Public Function Remove(ByVal item As PagesRow) As Boolean Implements System.Collections.Generic.ICollection(Of PagesRow).Remove
      m_pages.Remove(item)
      Return True
    End Function

    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of PagesRow) Implements System.Collections.Generic.IEnumerable(Of PagesRow).GetEnumerator
      Dim pages(m_pages.Count - 1) As PagesRow
      Dim i As Integer
      For i = 0 To m_pages.Count - 1
        pages(i) = CType(m_pages.Item(i), PagesRow)
      Next
      Return New PagesRowEnum(pages)
    End Function

    Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
      Dim pages(m_pages.Count - 1) As PagesRow
      Dim i As Integer
      For i = 0 To m_pages.Count - 1
        pages(i) = CType(m_pages.Item(i), PagesRow)
      Next
      Return New PagesRowEnum(pages)
    End Function
  End Class

  Partial Class PagesRowEnum
    Implements IEnumerator(Of PagesRow)

    Public _PagesRows() As PagesRow
    Private position As Integer = -1

    Public ReadOnly Property Current() As PagesRow Implements System.Collections.Generic.IEnumerator(Of PagesRow).Current
      Get
        Try
          Return _PagesRows(position)
        Catch ex As Exception
          Throw New InvalidOperationException
        End Try
      End Get
    End Property

    Public ReadOnly Property Current1() As Object Implements System.Collections.IEnumerator.Current
      Get
        Try
          Return _PagesRows(position)
        Catch ex As Exception
          Throw New InvalidOperationException
        End Try
      End Get
    End Property

    Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
      position += 1
      Return (position < _PagesRows.Length)
    End Function

    Public Sub Reset() Implements System.Collections.IEnumerator.Reset
      position = -1
    End Sub

    Private disposedValue As Boolean = False    ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: free other state (managed objects).
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

    Public Sub New()
    End Sub
    Public Sub New(ByVal list() As PagesRow)
      _PagesRows = list
    End Sub
  End Class

  Partial Class InsertsDataTable
    Public Overloads Function AddInsertsRow() As InsertsRow
      Dim insert As InsertsRow = CType(Me.NewRow, InsertsRow)
      insert.Number = 0
      insert.PageCount = 0
      insert.SetStartPageNull()
      Try
        Me.Rows.Add(insert)
      Catch ex As Exception
        Debug.Print("ERROR: " & ex.ToString)
      End Try
      Return insert
    End Function

    Public Overloads Function AddInsertsRow(ByVal Number As Integer, ByVal PageCount As Integer) As InsertsRow
      Dim insert As InsertsRow = CType(Me.NewRow, InsertsRow)
      insert.Number = Number
      insert.PageCount = PageCount
      insert.SetStartPageNull()
      Me.Rows.Add(insert)
      Return insert
    End Function

    Public Function GetRow(ByVal pagetypeId As String, ByVal insertNumber As Integer) As InsertsRow
      Dim i As InsertsRow
      For Each i In Me
        If (i.Number = insertNumber) AndAlso (i.PageTypeId = pagetypeId) Then
          Return i
        End If
      Next
      Return Nothing
    End Function
  End Class

  Partial Class InsertsRow
    Public Overrides Function ToString() As String
      Dim insert As New ArrayList
      insert.Add("Insert(Number: " & Number.ToString)
      insert.Add("PageCount: " & PageCount.ToString)
      If Not IsStartPageNull() Then
        insert.Add("StartPage: " & StartPage.ToString)
      End If
      insert.Add(")")
      Return Join(insert.ToArray, "|")
    End Function
  End Class
End Class
