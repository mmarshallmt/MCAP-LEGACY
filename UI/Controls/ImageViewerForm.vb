Namespace UI.Controls

    Public Class ImageViewerForm

        Public Sub LoadImage(ByVal imagePath As String)

            Try
                ''imageAxLEAD.Load(imagePath, BITsPerPixel, 0, 1)
                imgViewer.ImageLocation = imagePath
            Catch ex As Exception
                Trace.TraceError("ImageViewerForm.LoadImage. Message=" + ex.Message, New Object() {"AxLeadLib.AxLead", "Image=", imagePath})
                MessageBox.Show("Unable to load image - " + imagePath, ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ''        imageAxLEAD.RubberBandVisible = False
            imagePathTextBox.Text = imagePath
            Me.Text = "Image Viewer - " + System.IO.Path.GetFileName(imagePath)

        End Sub


    End Class

End Namespace