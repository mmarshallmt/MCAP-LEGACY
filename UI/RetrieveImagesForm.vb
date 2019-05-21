﻿Namespace UI

  Public Class RetrieveImagesForm
    Implements IForm


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private ReadOnly Property AppVarStorage() As ApplicationVariableStorage
      Get
        Return CType(Me.MdiParent, MCAP.UI.MDIForm).AppVar
      End Get
    End Property



#Region " IForm Implementation "


    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied

    Public Event InitializingForm() Implements IForm.InitializingForm
    Public Event FormInitialized() Implements IForm.FormInitialized


    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

    End Sub


    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

      RaiseEvent InitializingForm()

      AppVarStorage.ReadFromFile()
      pathTextBox.Text = AppVarStorage.LoadValue("VehicalImageRetrievalFolder")

      RaiseEvent FormInitialized()

    End Sub


#End Region



    Protected Overrides Sub ClearAllInputs()

      vehicleIdTextBox.Clear()
      pathTextBox.Clear()

    End Sub

    Protected Overrides Sub RemoveAllErrorProviders()

      RemoveErrorProvider(vehicleIdTextBox)
      RemoveErrorProvider(pathTextBox)

    End Sub

    Protected Overrides Sub EnableDisableControls(ByVal formStatus As FormStateEnum)

    End Sub

    Protected Overrides Sub ShowHideControls(ByVal formStatus As FormStateEnum)

    End Sub



    Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click

      Me.Close()

    End Sub

    Private Sub browseButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles browseButton.Click

      With pathFolderBrowserDialog
        .Description = "Select or create folder to copy vehicle images."
        .RootFolder = Environment.SpecialFolder.MyComputer
        If pathTextBox.Text.Length > 0 Then .SelectedPath = pathTextBox.Text
        .ShowNewFolderButton = True
        If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
          pathTextBox.Text = .SelectedPath
          'Save selected path in user's selection file.
          AppVarStorage.ReadFromFile()
          AppVarStorage.SaveValue("VehicalImageRetrievalFolder", pathTextBox.Text)
          AppVarStorage.WriteToFile()
        End If

      End With

    End Sub


    Private Sub retrieveButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles retrieveButton.Click
      Dim vehicleId As Integer


      If Integer.TryParse(vehicleIdTextBox.Text, vehicleId) = False Then
        MessageBox.Show("Specify valid Vehicle Id to copy its image files.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        vehicleIdTextBox.Focus()
        vehicleIdTextBox.SelectAll()
        Exit Sub
      End If

      If pathTextBox.Text.Length = 0 Then
                MessageBox.Show("Cannot retrieve Vehicle images. Specify path to copy Vehicle image files." _
                        + Environment.NewLine + "" _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        browseButton.Focus()
        Exit Sub

      ElseIf System.IO.Directory.Exists(pathTextBox.Text) = False Then
        MessageBox.Show("Cannot retrieve Vehicle images. Specified path does not exists." _
                        + Environment.NewLine + "Please select a valid path to retrive images." _
                        , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        browseButton.Focus()
        Exit Sub
      End If

      statusLabel.Text = "Copying..."
      Cursor.Current = Cursors.WaitCursor
      Application.DoEvents()

      Dim processor As Processors.RetrieveImages = New Processors.RetrieveImages()

      If processor.FindVehicle(vehicleId) = False Then
        MessageBox.Show("Vehicle " & CType(vehicleId, String) & " not found.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)
        Exit Sub
      End If

            If processor.CopyImageFiles(pathTextBox.Text) = True Then

                processor.Dispose()
                processor = Nothing

                Cursor.Current = Cursors.Arrow
                statusLabel.Text = "Idle"

                MessageBox.Show("Images copied successfully.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        End Sub


  End Class

End Namespace