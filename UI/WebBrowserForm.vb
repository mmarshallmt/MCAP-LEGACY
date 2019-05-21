Namespace UI


  Public Class WebBrowserForm

    ''' <summary>
    ''' Gets domain name URL including username and password.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Protected Function GetDomainURL() As String
      Dim domainURL As System.Text.StringBuilder


      domainURL = New System.Text.StringBuilder()
      domainURL.Append("http://")
      domainURL.Append(WebDomainUser)
      domainURL.Append(":")
      domainURL.Append(WebDomainPassword)
      domainURL.Append("@")
      domainURL.Append(WebDomainName)
      domainURL.Append("/")

      Return domainURL.ToString()

    End Function

    ''' <summary>
    ''' Navigates to specified target URL string.
    ''' </summary>
    ''' <param name="targetURL"></param>
    ''' <remarks></remarks>
    Public Sub Navigate(ByVal targetURL As String)
      Dim navigateURL As System.Uri


      targetURL = GetDomainURL() + targetURL
      navigateURL = New System.Uri(targetURL)
      vehicleWebBrowser.Navigate(navigateURL)

      navigateURL = Nothing

    End Sub


    Private Sub vehicleWebBrowser_Navigated _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs) _
        Handles vehicleWebBrowser.Navigated

      StatusBarStrip.Items("progressToolStripProgressBar").Visible = False

    End Sub

    Private Sub vehicleWebBrowser_Navigating _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs) _
        Handles vehicleWebBrowser.Navigating

      StatusBarStrip.Items("progressToolStripProgressBar").Visible = True

    End Sub

    Private Sub vehicleWebBrowser_ProgressChanged _
        (ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs) _
        Handles vehicleWebBrowser.ProgressChanged
      Dim progressStatus As ToolStripProgressBar


      progressStatus = CType(StatusBarStrip.Items("progressToolStripProgressBar"), ToolStripProgressBar)
      If e.MaximumProgress >= Integer.MaxValue Then
        progressStatus.Maximum = Integer.MaxValue - 1
      Else
        progressStatus.Maximum = CType(e.MaximumProgress, Integer)
      End If

      If e.CurrentProgress >= Integer.MaxValue - 1 Then
        progressStatus.Value = Integer.MaxValue - 1
            Else
                If e.CurrentProgress <> -1 Then
                    progressStatus.Value = CType(e.CurrentProgress, Integer)
                Else
                    progressStatus.Value = 0
                End If
            End If
        End Sub

    Private Sub vehicleWebBrowser_StatusTextChanged _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles vehicleWebBrowser.StatusTextChanged
      Dim startIndex, endIndex As Integer
      Dim statusMessage As String


      statusMessage = vehicleWebBrowser.StatusText
      startIndex = statusMessage.IndexOf("//") + 2
      endIndex = statusMessage.IndexOf("@") + 1
      If startIndex < endIndex Then
        statusMessage = statusMessage.Remove(startIndex, endIndex - startIndex)
      End If

      StatusBarStrip.Items("messageToolStripStatusLabel").Text = vehicleWebBrowser.StatusText
    End Sub


  End Class


End Namespace