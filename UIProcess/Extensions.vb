Imports System.Runtime.CompilerServices
Imports System.IO
Module Extensions


    Public Sub MoveAllItemsTo(ByVal fromPathInfo As DirectoryInfo, ByVal toPath As String)

        ''Create the target directory if necessary

        Dim toPathInfo As New DirectoryInfo(toPath)

        If (Not toPathInfo.Exists) Then

            toPathInfo.Create()

        End If

        ''move all files

        For Each file As FileInfo In fromPathInfo.GetFiles()

            file.MoveTo(Path.Combine(toPath, file.Name))

        Next

        ''move all folders

        For Each dir As DirectoryInfo In fromPathInfo.GetDirectories()

            dir.MoveTo(Path.Combine(toPath, dir.Name))

        Next

    End Sub


End Module
