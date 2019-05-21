Namespace UI


  Public Interface IForm

    Event InitializingForm()
    Event FormInitialized()

    Event ApplyingUserCredentials()
    Event UserCredentialsApplied()


    Sub Init(ByVal formStatus As FormStateEnum)

    Sub ApplyUserCredentials()

  End Interface


End Namespace