Namespace UI.Processors
    ''' <summary>
    ''' Class Created to check for possible duplicates in vehicles.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>

    Public Class DupCheckProcess
        Implements IDuplicateCheck


        Private m_override As Boolean
        Private m_forReview As Boolean
        Private m_isDuplicate As Boolean
        Private m_isPossibleDupFound As Boolean
        Private m_dupcheckFormId As Integer
        Private m_MediaText As String
        Private m_VehicleId As String
        Private m_RetId As Integer
        Private m_Form As Form
        Private m_adDate As DateTime
        Private m_FormState As FormStateEnum

#Region " IDuplicateCheck Implementation "


        Public ReadOnly Property MarkAsDuplicate() As Boolean Implements IDuplicateCheck.MarkAsDuplicate
            Get
                Return m_isDuplicate
            End Get
        End Property

        Public ReadOnly Property MarkForReview() As Boolean Implements IDuplicateCheck.MarkForReview
            Get
                Return m_forReview
            End Get
        End Property

        Public ReadOnly Property IsAnyPossibleDuplicateRecordFound() As Boolean Implements IDuplicateCheck.IsAnyPossibleDuplicateRecordFound
            Get
                Return m_isPossibleDupFound
            End Get
        End Property

        Public ReadOnly Property Override() As Boolean Implements IDuplicateCheck.Override
            Get
                Return m_override
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets DupCheckForId to update vehicleId for new vehicles.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Property DupcheckFormLogId() As Integer
            Get
                Return m_dupcheckFormId
            End Get
            Set(ByVal value As Integer)
                m_dupcheckFormId = value
            End Set
        End Property

        Public Property MediaText() As String
            Get
                Return m_MediaText
            End Get
            Set(ByVal value As String)
                m_MediaText = value
            End Set
        End Property

        Public Property VehicleID() As String
            Get
                Return m_VehicleId
            End Get
            Set(ByVal value As String)
                m_VehicleId = value
            End Set
        End Property

        Public Property RetId() As Integer
            Get
                Return m_RetId
            End Get
            Set(ByVal value As Integer)
                m_RetId = value
            End Set
        End Property

        Public Property Form() As Form
            Get
                Return m_Form
            End Get
            Set(ByVal value As Form)
                m_Form = value
            End Set
        End Property
        Public Property FormState() As FormStateEnum
            Get
                Return m_FormState
            End Get
            Set(ByVal value As FormStateEnum)
                m_FormState = value
            End Set
        End Property

        Public Property adVehicleDate() As DateTime
            Get
                Return m_adDate
            End Get
            Set(ByVal value As DateTime)
                m_adDate = value
            End Set
        End Property


        ''' <summary>
        ''' Checks for possible duplicate records in Vehicle table. If found shows records to user 
        ''' for further action.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckForDuplication _
            (ByVal marketId As Integer, ByVal publicationId As Integer, ByVal applyOverrideRestriction As Boolean, ByVal formName As String) _
            As DuplicateCheckUserResponse _
            Implements IDuplicateCheck.CheckForDuplication
            Dim userResponse As DialogResult
            Dim retailerId As Integer
            Dim languageId As Nullable(Of Integer)
            Dim adDate As DateTime
            Dim mediaList As System.Collections.Generic.List(Of String)
            Dim possibleDupVehicles As UI.DupCheckForm


            mediaList = New System.Collections.Generic.List(Of String)
            retailerId = RetId
            adDate = adVehicleDate
            languageId = Nothing  'Users can't specify language on this screen.

            Select Case MediaText
                Case "FSI"
                    mediaList.Clear()
                    mediaList.Add("FSI")
                    possibleDupVehicles = New UI.DupCheckForm(retailerId, marketId, adDate, mediaList, languageId, applyOverrideRestriction, formName)

                Case "ROP"
                    mediaList.Clear()
                    mediaList.Add("ROP")
                    possibleDupVehicles = New UI.DupCheckForm(retailerId, marketId, publicationId, adDate, mediaList, languageId, applyOverrideRestriction, formName)

                Case "CATALOG", "IN-STORE", "INSERT", "MAILER", "ROP - CIRCULAR", "MONTHLY BOOKLET", "PICK-UP IN-STORE", "INTERNET", "INSERT-DIGITAL", "IN-STORE-DIGITAL", "MAILER-DIGITAL", "INSERT-AC PAPER", "INSERT-AC DIGITAL", "IN-STORE-AC DIGITAL"
                    mediaList.Clear()
                    mediaList.Add("Catalog")
                    mediaList.Add("In-Store")
                    mediaList.Add("Insert")
                    mediaList.Add("Mailer")
                    mediaList.Add("Internet")
                    mediaList.Add("ROP - Circular") 'Circular ROP
                    mediaList.Add("Monthly Booklet")
                    mediaList.Add("Pick-Up In-Store")
                    mediaList.Add("Insert-Digital")
                    mediaList.Add("In-Store-Digital")
                    mediaList.Add("Mailer-Digital")
                    mediaList.Add("Insert-AC Paper")
                    mediaList.Add("Insert-AC Digital")
                    mediaList.Add("In-Store-AC Digital")

                    possibleDupVehicles = New UI.DupCheckForm(retailerId, marketId, adDate, mediaList, Nothing, Nothing, languageId, applyOverrideRestriction, formName)
                    If MediaText.ToUpper() = "CATALOG" Then
                        possibleDupVehicles.dateRangeNumericUpDown.Value = 14
                    Else
                        possibleDupVehicles.dateRangeNumericUpDown.Value = 5
                    End If
                Case Else
                    mediaList.Clear()
                    mediaList.Add(MediaText.ToUpper())
                    possibleDupVehicles = New UI.DupCheckForm(retailerId, marketId, adDate, mediaList, Nothing, Nothing, languageId, applyOverrideRestriction, formName)
                    possibleDupVehicles.dateRangeNumericUpDown.Value = 5

            End Select

            mediaList.Clear()
            mediaList = Nothing

            If FormState = FormStateEnum.Edit Then
                possibleDupVehicles.RemoveVehicle = CType(VehicleID, Integer)
            End If
            possibleDupVehicles.Init(FormStateEnum.View)
            If possibleDupVehicles.IsPossibleDuplicateRecordsFound Then
                possibleDupVehicles.ApplyUserCredentials()
                userResponse = possibleDupVehicles.ShowDialog(Form)
                m_isPossibleDupFound = True
            Else
                m_isPossibleDupFound = False
                userResponse = Windows.Forms.DialogResult.OK
                CheckForDuplication = DuplicateCheckUserResponse.NoPossibleDuplidates
            End If

            If userResponse = Windows.Forms.DialogResult.Cancel Then
                CheckForDuplication = DuplicateCheckUserResponse.Closed
            ElseIf possibleDupVehicles.IsOverride And userResponse = Windows.Forms.DialogResult.OK Then
                CheckForDuplication = DuplicateCheckUserResponse.Override
            ElseIf possibleDupVehicles.IsReview And userResponse = Windows.Forms.DialogResult.OK Then
                CheckForDuplication = DuplicateCheckUserResponse.Review
            ElseIf possibleDupVehicles.IsDuplicate And userResponse = Windows.Forms.DialogResult.OK Then
                CheckForDuplication = DuplicateCheckUserResponse.Duplicate
            End If

            m_override = possibleDupVehicles.IsOverride
            m_forReview = possibleDupVehicles.IsReview
            m_isDuplicate = possibleDupVehicles.IsDuplicate
            Me.DupcheckFormLogId = possibleDupVehicles.DupcheckFormLogId

            possibleDupVehicles.Dispose()
            possibleDupVehicles = Nothing

        End Function


#End Region
    End Class
End Namespace
