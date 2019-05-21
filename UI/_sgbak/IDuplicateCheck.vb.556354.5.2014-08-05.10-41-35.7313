Namespace UI

  Public Enum DuplicateCheckUserResponse
    ''' <summary>
    ''' Value not set.
    ''' </summary>
    ''' <remarks></remarks>
    Unknown = 0

    ''' <summary>
    ''' User has clicked on override button.
    ''' </summary>
    ''' <remarks></remarks>
    Override = 1

    ''' <summary>
    ''' User has clicked on review button.
    ''' </summary>
    ''' <remarks></remarks>
    Review = 2

    ''' <summary>
    ''' User has clicked on duplicate button.
    ''' </summary>
    ''' <remarks></remarks>
    Duplicate = 4

    ''' <summary>
    ''' User has clicked on cross(X) button in forms control buttons.
    ''' </summary>
    ''' <remarks></remarks>
    Closed = 8

    ''' <summary>
    ''' Query returned zero possible duplidate vehicles.
    ''' </summary>
    ''' <remarks></remarks>
    NoPossibleDuplidates = 16
  End Enum


  Public Interface IDuplicateCheck
    ''' <summary>
    ''' Checks for possible duplicate records. If found, shows them.
    ''' </summary>
    ''' <param name="marketId"></param>
    ''' <param name="publicationId"></param> 
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function CheckForDuplication(ByVal marketId As Integer, ByVal publicationId As Integer, ByVal applyOverrideRestriction As Boolean, ByVal formName As String) As DuplicateCheckUserResponse


    '
    'Following properties, if not used in any of the forms, will be removed later on.
    '
    ''' <summary>
    ''' Gets or set to true, if at least one possible duplicate record is found. False otherwise.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property IsAnyPossibleDuplicateRecordFound() As Boolean

    ''' <summary>
    ''' Gets or set to true, if user has selected to override. False otherwise.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Override() As Boolean

    ''' <summary>
    ''' Gets or set to true, if user has selected to review. False otherwise.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property MarkForReview() As Boolean

    ''' <summary>
    ''' Gets or set to true, if user has selected to duplicate information. False otherwise.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property MarkAsDuplicate() As Boolean


  End Interface

End Namespace