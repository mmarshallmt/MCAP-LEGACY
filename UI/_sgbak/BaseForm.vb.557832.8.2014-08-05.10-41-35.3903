Namespace UI


  Public Class BaseForm


    'Private m_uaLogger As UserActivityLogger
    'Private m_exLogger As ExceptionLogger
    Private m_formState As FormStateEnum



    Protected Property FormState() As FormStateEnum
      Get
        Return m_formState
      End Get
      Set(ByVal value As FormStateEnum)
        m_formState = value
      End Set
    End Property



    ''' <summary>
    ''' Sets error provider for supplied control with supplied message text.
    ''' </summary>
    ''' <param name="targetControl">Sets error provider for Control.</param>
    ''' <param name="messageText">Displays message when mouse pointer hovers over the error provider.</param>
    ''' <param name="iconAlignment">Location, where the error icon should be displayed, in relation to the control.</param>
    ''' <remarks></remarks>
    Protected Sub SetErrorProvider(ByVal targetControl As System.Windows.Forms.Control, ByVal messageText As String, Optional ByVal iconAlignment As ErrorIconAlignment = ErrorIconAlignment.MiddleRight)

      m_ErrorProvider.SetIconAlignment(targetControl, iconAlignment)
      m_ErrorProvider.SetError(targetControl, messageText)

    End Sub

    ''' <summary>
    ''' Removes error provider for supplied control.
    ''' </summary>
    ''' <param name="targetControl">Removes error provider for Control.</param>
    ''' <remarks></remarks>
    Protected Sub RemoveErrorProvider(ByVal targetControl As System.Windows.Forms.Control)

      m_ErrorProvider.SetError(targetControl, String.Empty)

    End Sub

    Protected Overridable Sub ClearAllInputs()

    End Sub

    Protected Overridable Sub EnableDisableControls(ByVal formStatus As FormStateEnum)

    End Sub

    Protected Overridable Sub ShowHideControls(ByVal formStatus As FormStateEnum)

    End Sub

    Protected Overridable Sub RemoveAllErrorProviders()

    End Sub


  End Class


End Namespace