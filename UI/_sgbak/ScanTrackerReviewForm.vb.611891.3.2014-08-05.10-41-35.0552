Imports System.IO
Namespace UI

  Public Class ScanTrackerReviewForm
    Inherits MDIChildFormBase
    Implements IForm


    Public Sub PopulateListBox(ByVal imageList() As FileInfo)
      SetListBoxSize()
      reviewListBox.DataSource = imageList
      reviewListBox.DisplayMember = "FullName"

      imageCountLabel.Text = CType(reviewListBox.Items.Count, String)
    End Sub

    Public Sub PopulateListBox(ByVal imageList() As String)
      SetListBoxSize()
      reviewListBox.Items.AddRange(imageList)

      imageCountLabel.Text = CType(reviewListBox.Items.Count, String)
    End Sub

    Private Sub ScanTrackerReviewForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
      SetListBoxSize()
    End Sub

    Private Sub SetListBoxSize()
      reviewListBox.Width = Me.Width - 40
      reviewListBox.Height = Me.Height - 70
    End Sub

    Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials

    Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials
      'Apply User credentials here.
      Dim appUser As Processors.ApplicationUser
      Dim userScreen As UserRolesDataSet.UserScreensFunctionalityViewRow

      RaiseEvent ApplyingUserCredentials()

      appUser = New Processors.ApplicationUser
      appUser.Initialize()
      appUser.GetFunctionalityListFor(appUser.UserID, Me.Name)

      For Each userScreen In appUser.UserDataSet.UserScreensFunctionalityView
        If userScreen.IsFunctionalityNull Then
        Else
          Select Case userScreen.Functionality.ToUpper
            Case Processors.ApplicationUser.Functionality.EditOnly
            Case Processors.ApplicationUser.Functionality.ViewOnly
            Case Processors.ApplicationUser.Functionality.NewOnly
          End Select
        End If
      Next

      appUser = Nothing

      RaiseEvent UserCredentialsApplied()

    End Sub

    Public Event FormInitialized() Implements IForm.FormInitialized

    Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init
      RaiseEvent InitializingForm()

      Me.FormState = formStatus

      Me.StatusMessage = "Loading..."

      Me.StatusMessage = ""

      RaiseEvent FormInitialized()
    End Sub

    Public Event InitializingForm() Implements IForm.InitializingForm

    Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied
  End Class
End Namespace
