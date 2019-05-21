Public Class ImagesViewForm

    Public Property ImageFilePath As String
    'a collection to hold the paths to our pictures
    Dim myFiles As New Collection

    'index keeps track of where we are in the array.  It represents the location of the current image.
    Dim index As Integer


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


        If Not picCurrent.Image Is Nothing Then
            picCurrent.Image.Dispose()
        End If
        picCurrent.Image = Image.FromFile(myFiles(curIndex).ToString)

        
        lastIndex = Nothing
        nextIndex = Nothing
    End Sub

   
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim CurFile As String = ImageFilePath
        myFiles.Add(CurFile)
        loadImages(1)
    End Sub
End Class
