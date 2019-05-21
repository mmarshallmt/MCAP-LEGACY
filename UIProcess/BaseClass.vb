Imports System.Drawing.Printing


Namespace UI.Processors

  Public Class BaseClass
    Implements IDisposable


#Region " Deletages "

    Public Delegate Sub MCAPEventHandler(ByVal sender As Object, ByVal e As UI.Processors.EventArgs)
    Public Delegate Sub MCAPCancellableEventHandler(ByVal sender As Object, ByVal e As UI.Processors.CancellableEventArgs)

#End Region


    ''' <summary>
    ''' DataRow holding information about logged on user.
    ''' </summary>
    Protected Shared m_currentUser As UserRolesDataSet.UserRow


#Region " Constructor & Destructor "

    ''' <summary>
    ''' Default constructor.
    ''' </summary>
    ''' <remarks></remarks>
    Sub New()

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


#End Region


    ''' <summary>
    ''' Gets user Id of currently logged on application user.
    ''' </summary>
    ''' <value>Integer</value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <exception cref="NullReferenceException">
    ''' When logged on user information is not loaded.
    ''' </exception>
    Public ReadOnly Property UserID() As Integer
      Get
        Return m_currentUser.UserID
      End Get
    End Property

    ''' <summary>
    ''' Gets user name of currently logged on application user.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <exception cref="NullReferenceException">
    ''' When logged on user information is not loaded.
    ''' </exception>
    Public ReadOnly Property Username() As String
      Get
        Return m_currentUser.Username
      End Get
    End Property

    ''' <summary>
    ''' Gets first name of currently logged on application user.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <exception cref="NullReferenceException">
    ''' When logged on user information is not loaded.
    ''' </exception>
    Public ReadOnly Property UserFirstName() As String
      Get
        Return m_currentUser.FName
      End Get
    End Property

    ''' <summary>
    ''' Gets last name of currently logged on application user.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Returns zero length string, if LName contains Null.</remarks>
    ''' <exception cref="NullReferenceException">
    ''' When logged on user information is not loaded.
    ''' </exception>
    Public ReadOnly Property UserLastName() As String
      Get
        If m_currentUser.IsNull("LName") Then
          Return ""
        Else
          Return m_currentUser.LName
        End If
      End Get
    End Property

    ''' <summary>
    ''' Gets user name by concatenating user's first and last name.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property UserFullName() As String
      Get
        Return UserFirstName + " " + UserLastName
      End Get
    End Property

    ''' <summary>
    ''' Gets user locationId of currently logged on application user.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <exception cref="NullReferenceException">
    ''' When logged on user information is not loaded.
    ''' </exception>
    Public ReadOnly Property UserLocationId() As Integer
      Get
        Return m_currentUser.LocationId
      End Get
    End Property

    ''' <summary>
    ''' Gets user location of currently logged on application user.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <exception cref="NullReferenceException">
    ''' When logged on user information is not loaded.
    ''' </exception>
    Public ReadOnly Property UserLocation() As String
      Get
        Return m_currentUser.Location
      End Get
    End Property


    ''' <summary>
    ''' Inserts a row into supplied error table.
    ''' </summary>
    ''' <param name="errTable"></param>
    ''' <param name="columnName"></param>
    ''' <param name="columnCaption"></param>
    ''' <param name="errorMessage"></param>
    ''' <remarks></remarks>
    Protected Sub AddErrorInformation _
        (ByVal errTable As System.Data.DataTable, ByVal columnName As String, ByVal columnCaption As String _
         , ByVal errorMessage As String)
      Dim tempRow As Data.DataRow


      tempRow = errTable.NewRow()
      tempRow("ColumnName") = columnName
      tempRow("ColumnCaption") = columnCaption
      tempRow("Message") = errorMessage

      errTable.Rows.Add(tempRow)
      errTable.AcceptChanges()

    End Sub

    ''' <summary>
    ''' Removes row with supplied column name from supplied data table.
    ''' </summary>
    ''' <param name="errTable"></param>
    ''' <param name="columnName"></param>
    ''' <remarks></remarks>
    Protected Sub RemoveErrorInformation _
        (ByVal errTable As System.Data.DataTable, ByVal columnName As String)
      Dim deleteQuery As System.Collections.Generic.IEnumerable(Of Data.DataRow)


      deleteQuery = From deleteRow In errTable _
                    Select deleteRow _
                    Where deleteRow("ColumnName") Is columnName


      If deleteQuery.Count > 0 Then
        deleteQuery(0).Delete()
        errTable.AcceptChanges()
      End If

      deleteQuery = Nothing

    End Sub


    ''' <summary>
    ''' Inserts a row into supplied warning table.
    ''' </summary>
    ''' <param name="warningTable"></param>
    ''' <param name="columnName"></param>
    ''' <param name="columnCaption"></param>
    ''' <param name="warningMessage"></param>
    ''' <remarks></remarks>
    Protected Sub AddWarningInformation _
        (ByVal warningTable As System.Data.DataTable, ByVal columnName As String, ByVal columnCaption As String _
         , ByVal warningMessage As String)
      Dim tempRow As Data.DataRow


      tempRow = warningTable.NewRow()
      tempRow("ColumnName") = columnName
      tempRow("ColumnCaption") = columnCaption
      tempRow("Message") = warningMessage

      warningTable.Rows.Add(tempRow)
      warningTable.AcceptChanges()

    End Sub

    ''' <summary>
    ''' Removes row with supplied column name from supplied data table.
    ''' </summary>
    ''' <param name="warningTable"></param>
    ''' <param name="columnName"></param>
    ''' <remarks></remarks>
    Protected Sub RemoveWarningInformation _
        (ByVal warningTable As System.Data.DataTable, ByVal columnName As String)
      Dim deleteQuery As System.Collections.Generic.IEnumerable(Of Data.DataRow)


      deleteQuery = From deleteRow In warningTable _
                    Select deleteRow _
                    Where deleteRow("ColumnName") Is columnName


      If deleteQuery.Count > 0 Then
        deleteQuery(0).Delete()
        warningTable.AcceptChanges()
      End If

      deleteQuery = Nothing

    End Sub


  End Class

End Namespace