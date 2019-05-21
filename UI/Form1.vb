Public Class Form1

    'a collection to hold the paths to our pictures
    Dim myFiles As New Collection

    'index keeps track of where we are in the array.  It represents the location of the current image.
    Dim index As Integer

    Private Sub btnFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFolder.Click
        Dim myDir As New FolderBrowserDialog
        Dim result As DialogResult

        result = myDir.ShowDialog

        If result = Windows.Forms.DialogResult.OK Then
            Dim tmpFiles() As String = System.IO.Directory.GetFiles(myDir.SelectedPath)

            For Each curFile As String In tmpFiles
                Dim ext As String = System.IO.Path.GetExtension(curFile).ToLower

                If ext = ".jpg" Or ext = ".jpeg" Or ext = ".gif" Or ext = ".bmp" _
                Or ext = ".png" Or ext = ".tif" Or ext = ".tiff" Then
                    myFiles.Add(curFile)
                End If
                ext = Nothing
                curFile = Nothing
            Next

            tmpFiles = Nothing

            index = 1
            loadImages(index)
        End If

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If index + 1 > myFiles.Count Then
            'we're past the end of the array, so start over
            index = 1
        Else
            index += 1
        End If

        loadImages(index)
    End Sub

    Private Sub loadImages(ByVal curIndex As Integer)
        Dim lastIndex As Integer
        Dim nextIndex As Integer

        If curIndex > 1 Then
            lastIndex = curIndex - 1
        Else
            lastIndex = myFiles.Count
        End If

        If curIndex + 1 <= myFiles.Count Then
            nextIndex = curIndex + 1
        Else
            nextIndex = 1
        End If

        If Not picLast.Image Is Nothing Then
            picLast.Image.Dispose()
        End If
        picLast.Image = Image.FromFile(myFiles(lastIndex))

        If Not picCurrent.Image Is Nothing Then
            picCurrent.Image.Dispose()
        End If
        picCurrent.Image = Image.FromFile(myFiles(curIndex))

        If Not picNext.Image Is Nothing Then
            picNext.Image.Dispose()
        End If
        picNext.Image = Image.FromFile(myFiles(nextIndex))

        lastIndex = Nothing
        nextIndex = Nothing
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click

        If index > 1 Then
            index -= 1
        Else
            index = myFiles.Count
        End If

        loadImages(index)
    End Sub

    Private Sub picLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picLast.Click
        btnLast_Click(sender, e)
    End Sub

    Private Sub picNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picNext.Click
        btnNext_Click(sender, e)
    End Sub

    Private Sub btnSlideshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSlideshow.Click
        tmrShow.Enabled = Not tmrShow.Enabled

        If tmrShow.Enabled = True Then
            btnSlideshow.Text = "Stop Slideshow"
        Else
            btnSlideshow.Text = "Start Slideshow"
        End If
    End Sub

    Private Sub tmrShow_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrShow.Tick
        btnNext_Click(sender, e)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim CurFile As String = "\\mt4img1\mt4img1e\VehicleImage\201706\11936611\Unsized\001.jpg"
        myFiles.Add(CurFile)
        loadImages(1)
    End Sub
End Class
