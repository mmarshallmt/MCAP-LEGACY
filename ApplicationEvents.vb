Namespace My

  ' The following events are available for MyApplication:
  ' 
  ' Startup: Raised when the application starts, before the startup form is created.
  ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
  ' UnhandledException: Raised if the application encounters an unhandled exception.
  ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
  ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
  Partial Friend Class MyApplication

    Private Sub MyApplication_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged

      Trace.WriteLine("Network Availablity Changed. IsNetworkAvailable=" + e.IsNetworkAvailable.ToString())

    End Sub

    Private Sub MyApplication_Shutdown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shutdown

      Trace.WriteLine("Application Closed.")
      Trace.Flush()

    End Sub

    Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) Handles Me.Startup
      Dim splashWin As splashWindow


      Trace.WriteLine("Application Started.")
      splashWin = New splashWindow()
      splashWin.Show()
      Application.DoEvents()

      ' Probably a good place to check for database availability.

      If PrepareAppParamsCollection() = False Then
        e.Cancel = True
      Else
        Dim isValid As Boolean
        Dim appUser As UI.Processors.ApplicationUser = New UI.Processors.ApplicationUser


        appUser.Initialize()
        isValid = appUser.IsValidUser(System.Security.Principal.WindowsIdentity.GetCurrent().Name)

        If isValid = False Then
          MessageBox.Show("Invalid user.", My.Application.Info.ProductName, _
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
          e.Cancel = True
        Else
          SetApplicationUserInformation(appUser.UserDataSet.User(0))
          LoadUserSettings()
        End If

        appUser.Dispose()
        appUser = Nothing
      End If

      Application.DoEvents()
      splashWin.Close()
      splashWin = Nothing

      If e.Cancel = False AndAlso BarcodePrinterName Is Nothing Then
        MessageBox.Show("You must select barcode printer to continue. Closing application." _
                        , Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        e.Cancel = True
      End If

    End Sub

    Private Sub MyApplication_StartupNextInstance(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.StartupNextInstanceEventArgs) Handles Me.StartupNextInstance

      MessageBox.Show("Application already running.", Application.ToString _
                      , MessageBoxButtons.OK, MessageBoxIcon.Hand)

    End Sub

    Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException

      MessageBox.Show("Unexpected error has occurred. Please inform your entry administrator regarding this." _
                      + Environment.NewLine + e.Exception.Message, My.Application.Info.ProductName _
                      , MessageBoxButtons.OK, MessageBoxIcon.Error)
      Trace.Fail("Unhandled Exception. Message=" + e.Exception.Message)

    End Sub

  End Class

End Namespace