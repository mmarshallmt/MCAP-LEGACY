Imports System.Data.SqlClient

Public Class URLInputBox

    Dim dsOnlineURL As DataSet
    Public RefreshGrid As Boolean = False

    Public Sub LoadData(ByVal ds As DataSet)
        Me.dsOnlineURL = ds
        TextBoxURL.DataBindings.Add(New Binding("Text", ds, "WebsitePageDownload.URL"))

    End Sub

    Public Sub SaveOnlineWebsite(ByVal ds As DataSet)
        'Update a dataset representing Currencys
        Dim conn As New SqlConnection
        conn = New SqlConnection(GetConnectionStringForAppDB)

        Try
            Dim sql As String = "Select * from WebsitePageDownload"
            Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)

            Try
                Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
                If ds.HasChanges Then
                    da.Update(ds, "WebsitePageDownload")
                    ds.AcceptChanges()
                End If
            Finally
                da.Dispose()
            End Try

        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Sub
    Private Sub addActor()
        If MsgBox("Save Record ?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.Information, MsgBoxStyle)) = MsgBoxResult.No Then Exit Sub

        BindingContext(dsOnlineURL, "WebsitePageDownload").EndCurrentEdit()
        SaveOnlineWebsite(dsOnlineURL)
    End Sub

    Private Sub ButtonOK_Click(sender As Object, e As EventArgs) Handles ButtonOK.Click
        Me.addActor()
        Me.Hide()
        RefreshGrid = True
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Hide()
        RefreshGrid = False
    End Sub
End Class