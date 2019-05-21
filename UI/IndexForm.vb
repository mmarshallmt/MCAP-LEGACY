﻿Namespace UI


  Public Class IndexForm
    Implements IForm

        Private _SenderID As Integer
        Private isAssociated As Boolean
        'page definitions
        Private arrPageName As New List(Of String)
        Private dsPage As New DataSet
        Private ctr As Integer
        Private m_isWrongVersion As Boolean
        Private isClosedByButton As Boolean = False
        Private WithEvents m_envelopeContentProcessor As UI.Processors.EnvelopeContent

#Region "Constants"
    ''' <summary>
    ''' This constant is used to assigning value to FormName column.
    ''' </summary>
    Private Const FORM_NAME As String = "Index"
#End Region

#Region " Member Variables "
        Private WithEvents m_Processor As Processors.Index
        Private m_expectedPageCount As Integer
        Private m_IsNAPublicationsOnly, m_IsFSI As Boolean
        Private _sender As Integer = 0
#End Region


#Region " Properties "

        ''' <summary>
        ''' Instance of class QCVehicleImages
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property Processor() As Processors.Index
            Get
                Return m_Processor
            End Get
        End Property

        ''' <summary>
        ''' Gets value indicating whether to load all valid publications or just NA only.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property IsNAPublicationsOnly() As Boolean
            Get
                Return m_IsNAPublicationsOnly
            End Get
        End Property

        ''' <summary>
        ''' Gets boolean value indicating whether current vehicle is created for FSI or not.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private ReadOnly Property IsFSI() As Boolean
            Get
                Return m_IsFSI
            End Get
        End Property

        Private Property IsWrongVersion() As Boolean
            Get
                Return m_isWrongVersion
            End Get
            Set(ByVal value As Boolean)
                m_isWrongVersion = value
            End Set
        End Property

#End Region


        ''' <summary>
        ''' Loads vehicle based on vehicle id set in Search textbox.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub LoadVehicle()

            loadButton_Click(Me, New System.EventArgs)
            enterandcloseButton.Visible = True

        End Sub

        ''' <summary>
        ''' Sets focus on appropriate control on form.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub SetInputFocus()

            If eventComboBox.SelectedValue Is Nothing Then
                eventComboBox.Focus()
            ElseIf enterButton.Visible Then
                enterButton.Focus()
            Else
                exitButton.Focus()
            End If

        End Sub

        ''' <summary>
        ''' Validate retailer market combination against FRControl table in database and enable/disable
        ''' Flash checkbox control accordingly.
        ''' </summary>
        ''' <param name="retailerId"></param>
        ''' <param name="marketId"></param>
        ''' <remarks></remarks>
        Private Sub ValidateForFRControl(ByVal retailerId As Integer, ByVal marketId As Integer)
            Dim isValidFlashRetMkt As Boolean


            isValidFlashRetMkt = Processor.IsValidFlashRetMkt(retailerId, marketId)
            If isValidFlashRetMkt = False Then flashCheckBox.Checked = isValidFlashRetMkt
            flashCheckBox.Enabled = isValidFlashRetMkt
        End Sub

        Private Function IsValidFRRetMkt() As Boolean
            Dim isValidFlashRetMkt As Boolean
            Dim retailerId, marketId As Integer


            If marketComboBox.SelectedValue Is Nothing _
              OrElse Integer.TryParse(marketComboBox.SelectedValue.ToString(), marketId) = False _
            Then
                marketId = -1
            End If

            If retailerComboBox.SelectedValue Is Nothing Then
                retailerId = -1
            Else
                retailerId = CType(retailerComboBox.SelectedValue, Integer)
            End If

            isValidFlashRetMkt = Processor.IsValidFlashRetMkt(retailerId, marketId)

            Return isValidFlashRetMkt

        End Function


        Protected Overrides Sub ShowHideControls(ByVal formStatus As FormStateEnum)

            enterandcloseButton.Visible = False

            Select Case formStatus
                Case FormStateEnum.Insert
                    printButton.Visible = False
                    editButton.Visible = False
                    enterButton.Enabled = True
                    exitButton.Enabled = True

                Case FormStateEnum.Edit
                    printButton.Visible = True
                    editButton.Visible = False
                    enterButton.Enabled = True
                    exitButton.Enabled = True

                Case FormStateEnum.View
                    printButton.Visible = True
                    editButton.Visible = True
                    enterButton.Enabled = False
                    exitButton.Enabled = True
                    editButton.Focus()
            End Select

        End Sub

        Protected Overrides Sub EnableDisableControls(ByVal formStatus As FormStateEnum)

            Select Case FormState
                Case FormStateEnum.Insert
                    flagForDetailEntryCheckBox.Enabled = True
                    parentVehicleIdTextBox.Enabled = True
                    adDateTypeInDatePicker.Enabled = True
                    DistDateTypeInDatePicker.Enabled = True
                    mediaComboBox.Enabled = True
                    marketComboBox.Enabled = True
                    publicationComboBox.Enabled = True
                    retailerComboBox.Enabled = True
                    languageComboBox.Enabled = True
                    eventComboBox.Enabled = True
                    themeComboBox.Enabled = True
                    startDateTypeInDatePicker.Enabled = True
                    endDateTypeInDatePicker.Enabled = True
                    definePagesButton.Enabled = True
                    CommentsTextBox.Enabled = False
                    flashCheckBox.Enabled = True And IsValidFRRetMkt()
                    nationalCheckBox.Enabled = flashCheckBox.Checked
                    couponCheckBox.Enabled = True
                    enterButton.Enabled = True
                    deleteButton.Enabled = True
                    exitButton.Enabled = True
                    WrongVersionButton.Enabled = True
                    If eventComboBox.SelectedItem Is Nothing Then
                        eventComboBox.Focus()
                    Else
                        enterButton.Focus()
                    End If

                Case FormStateEnum.Edit
                    flagForDetailEntryCheckBox.Enabled = True
                    parentVehicleIdTextBox.Enabled = Not flagForDetailEntryCheckBox.Checked
                    adDateTypeInDatePicker.Enabled = True
                    DistDateTypeInDatePicker.Enabled = True
                    mediaComboBox.Enabled = True
                    marketComboBox.Enabled = True
                    publicationComboBox.Enabled = True
                    retailerComboBox.Enabled = True
                    languageComboBox.Enabled = True
                    eventComboBox.Enabled = True
                    themeComboBox.Enabled = True
                    startDateTypeInDatePicker.Enabled = True
                    endDateTypeInDatePicker.Enabled = True
                    definePagesButton.Enabled = True
                    flashCheckBox.Enabled = True And IsValidFRRetMkt()
                    nationalCheckBox.Enabled = flashCheckBox.Checked
                    couponCheckBox.Enabled = True
                    CommentsTextBox.Enabled = False
                    printButton.Enabled = True
                    enterButton.Enabled = True
                    deleteButton.Enabled = True
                    exitButton.Enabled = True
                    WrongVersionButton.Enabled = True

                Case FormStateEnum.View
                    flagForDetailEntryCheckBox.Enabled = False
                    parentVehicleIdTextBox.Enabled = False
                    adDateTypeInDatePicker.Enabled = False
                    DistDateTypeInDatePicker.Enabled = False
                    mediaComboBox.Enabled = False
                    marketComboBox.Enabled = False
                    publicationComboBox.Enabled = False
                    retailerComboBox.Enabled = False
                    languageComboBox.Enabled = False
                    eventComboBox.Enabled = False
                    themeComboBox.Enabled = False
                    startDateTypeInDatePicker.Enabled = False
                    endDateTypeInDatePicker.Enabled = False
                    definePagesButton.Enabled = False
                    flashCheckBox.Enabled = False
                    nationalCheckBox.Enabled = False
                    couponCheckBox.Enabled = False
                    CommentsTextBox.Enabled = False
                    enterButton.Enabled = False
                    deleteButton.Enabled = True
                    exitButton.Enabled = True
            End Select

        End Sub

        Protected Overrides Sub ClearAllInputs()
            findVehicleIdTextBox.Clear()
            vehicleIdValueLabel.Text = String.Empty
            adDateTypeInDatePicker.Clear()
            DistDateTypeInDatePicker.Clear()
            mediaComboBox.SelectedValue = DBNull.Value
            marketComboBox.SelectedValue = DBNull.Value
            publicationComboBox.SelectedValue = DBNull.Value
            retailerComboBox.SelectedValue = DBNull.Value
            languageComboBox.SelectedValue = DBNull.Value
            eventComboBox.SelectedValue = DBNull.Value
            themeComboBox.SelectedValue = DBNull.Value
            couponCheckBox.Checked = False
            startDateTypeInDatePicker.Clear()
            endDateTypeInDatePicker.Clear()
            flashCheckBox.Checked = False
            m_isWrongVersion = False
        End Sub

        Protected Overrides Sub RemoveAllErrorProviders()
            RemoveErrorProvider(findVehicleIdTextBox)
            RemoveErrorProvider(vehicleIdValueLabel)
            RemoveErrorProvider(adDateTypeInDatePicker)
            RemoveErrorProvider(DistDateTypeInDatePicker)
            RemoveErrorProvider(mediaComboBox)
            RemoveErrorProvider(marketComboBox)
            RemoveErrorProvider(publicationComboBox)
            RemoveErrorProvider(retailerComboBox)
            RemoveErrorProvider(eventComboBox)
            RemoveErrorProvider(themeComboBox)
            RemoveErrorProvider(startDateTypeInDatePicker)
            RemoveErrorProvider(endDateTypeInDatePicker)
            RemoveErrorProvider(couponCheckBox)
        End Sub


        Private Sub UpdatePageImageName(ByVal _ImageName As String, ByVal _receivedorder As Integer, ByVal _vehicle As Integer)
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As New Object

            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    If _ImageName = "" Then
                        _ImageName = "Null"
                    Else
                        _ImageName = "'" + _ImageName + "'"
                    End If
                    .CommandText = "UPDATE Page SET ImageName = '" + _ImageName + "' where VehicleId = " + _vehicle.ToString + " AND ReceivedOrder = " + _receivedorder.ToString + " and ImageName is null"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    .ExecuteNonQuery()
                End With

            Catch ex As Exception
                Throw New ApplicationException("Failed to restore Page Details.", ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

        End Sub

        Private Function isVehicleQCed(ByVal _vehicleid As Integer) As Boolean


            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim con As System.Data.SqlClient.SqlConnection
            Dim obj As Object
            Dim stat As Integer

            cmd = New System.Data.SqlClient.SqlCommand
            con = New System.Data.SqlClient.SqlConnection

            con.ConnectionString = GetConnectionStringForAppDB()
            con.Open()

            cmd.Connection = con

            cmd.CommandType = CommandType.Text

            cmd.CommandText = "Select StatusId FROM vwcircular WHERE Vehicleid =" + _vehicleid.ToString

            obj = cmd.ExecuteScalar

            If IsDBNull(obj) Then obj = 0

            If CType(obj, Integer) = 22 Then
                isVehicleQCed = True
            ElseIf CType(obj, Integer) = 27 Or CType(obj, Integer) = 0 Then
                isVehicleQCed = False
            End If

            If cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
            cmd = Nothing


        End Function


        Private Function LoadVehiclePageDetails(ByVal _vehicleid As Integer) As DataSet
            Dim ds As New DataSet
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim adpt As System.Data.SqlClient.SqlDataAdapter
            Try
                cmd = New System.Data.SqlClient.SqlCommand
                With cmd
                    .CommandText = "Select VehicleId,ImageName from page where VehicleId = " + _vehicleid.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())

                    adpt = New System.Data.SqlClient.SqlDataAdapter(cmd)

                    adpt.Fill(ds)
                End With
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            Return ds
        End Function

        Protected Overrides Sub OnMediaChanged(ByVal mediaId As Integer, ByVal marketId As Integer, ByVal naPubOnly As Boolean, ByVal IsFSI As Boolean)

            If mediaComboBox.Text.ToUpper() = "CATALOG" Then
                Processor.LoadMarketsForCatalog()
                If marketComboBox.Items.Count = 1 Then marketComboBox.SelectedIndex = 0
                adDateTypeInDatePicker.Focus()
            ElseIf Processor.Data.vwCircular.Count > 0 AndAlso mediaComboBox.SelectedValue IsNot Nothing Then
                isAssociated = HasMarketAssoc(_SenderID, Processor.Data.vwCircular.Item(0).MktId)
                'If Processor.LoadMarketsPerSenderExpectation(_SenderID, CInt(mediaComboBox.SelectedValue.ToString)) = 0 Then

                If isAssociated Then
                    Processor.LoadMarket(Processor.Data.vwCircular(0).EnvelopeId)
                Else
                    Processor.LoadMarket(_SenderID, Processor.Data.vwCircular(0).VehicleId)
                End If
                'End If
                If marketComboBox.Items.Count = 1 Then
                    marketComboBox.SelectedIndex = 0
                Else
                    marketComboBox.Text = String.Empty
                    marketComboBox.SelectedValue = DBNull.Value
                    marketComboBox.SelectedIndex = -1
                End If
            End If

            If marketComboBox.SelectedValue IsNot Nothing _
              AndAlso Integer.TryParse(marketComboBox.SelectedValue.ToString(), marketId) = False _
            Then
                marketId = -1
            End If

            m_IsNAPublicationsOnly = naPubOnly
            m_IsFSI = IsFSI

            OnMarketChanged(marketId, mediaId, naPubOnly)

            If IsFSI Then
                themeComboBox.SelectedIndex = themeComboBox.FindStringExact("None")
                eventComboBox.SelectedIndex = eventComboBox.FindStringExact("None")
                startDateTypeInDatePicker.Value = Nothing
                endDateTypeInDatePicker.Value = Nothing
                couponCheckBox.Checked = True
            End If

        End Sub

        Private Function HasMarketAssoc(ByVal _sender As Integer, ByVal _mktid As Integer) As Boolean
            Dim ReturnVal As Boolean
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "select * from SenderMktAssoc where endDt is null and SenderId=" + _sender.ToString + " and MktId=" + _mktid.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With

                If obj IsNot Nothing Then
                    ReturnVal = True
                Else
                    ReturnVal = False
                End If

            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return ReturnVal
        End Function


        Protected Overrides Sub OnMarketChanged(ByVal marketId As Integer, ByVal mediaId As Integer, ByVal naPubOnly As Boolean)
            Dim retailerId As Integer


            If marketId < 1 Then
                Exit Sub
            End If

            If naPubOnly Then
                Processor.LoadNAPublicationIndex()
            Else
                Processor.LoadPublication(marketId, Processor.Data.vwCircular.Item(0).PublicationId)
            End If

            If retailerComboBox.SelectedValue Is Nothing Then
                retailerId = -1
            Else
                retailerId = CType(retailerComboBox.SelectedValue, Integer)
            End If
            'If Processor.LoadRetailersSenderExpectation(_SenderID, marketId, mediaId, _SenderID) = 0 Then
            Processor.LoadRetailer(mediaId, marketId)
            'End If

            retailerComboBox.SelectedValue = retailerId

            ValidateForFRControl(retailerId, marketId)

        End Sub

        ''' <summary>
        ''' Displays supplied row information in corresponding inputs.
        ''' </summary>
        ''' <param name="vehicleRow"></param>
        ''' <remarks></remarks>
        Private Sub ShowVehicleInformation(ByVal vehicleRow As QCDataSet.vwCircularRow)
            _SenderID = Processor.LoadEnvelopeSenderInfo(vehicleRow.EnvelopeId)
            vehicleIdValueLabel.Text = vehicleRow.VehicleId.ToString()

            If vehicleRow.IsMediaIdNull() Then
                mediaComboBox.SelectedValue = DBNull.Value
            Else
                mediaComboBox.SelectedValue = vehicleRow.MediaId
            End If

            marketComboBox.SelectedValue = DBNull.Value 'Required to load publications & retailers.
            If vehicleRow.IsMktIdNull() Then
                marketComboBox.SelectedValue = DBNull.Value
            Else
                marketComboBox.SelectedValue = vehicleRow.MktId
                If isAssociated = False AndAlso marketComboBox.Text IsNot "" Then MessageBox.Show("Sender '" + GetSenderName(vehicleRow.VehicleId) + "' is not associated with market '" + GetMarketName(vehicleRow.MktId) + "', however you are able to continue.", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            'If Me.IsNAPublicationsOnly Then
            '  Processor.LoadNAPublicationIndex()
            'Else
            '  Processor.LoadPublication(vehicleRow.MktId)
            'End If
            If vehicleRow.IsPublicationIdNull() Then
                publicationComboBox.SelectedValue = DBNull.Value
            Else
                publicationComboBox.SelectedValue = vehicleRow.PublicationId
            End If

            If vehicleRow.IsBreakDtNull() Then
                adDateTypeInDatePicker.Clear()
            Else
                adDateTypeInDatePicker.Text = vehicleRow.BreakDt.ToString("MM/dd/yy")
            End If

            If vehicleRow.IsDistDtNull Then
                DistDateTypeInDatePicker.Clear()
            Else
                DistDateTypeInDatePicker.Text = vehicleRow.DistDt.ToString("MM/dd/yy")
            End If

            retailerComboBox.SelectedValue = DBNull.Value 'Required to load tradeclass.
            If vehicleRow.IsRetIdNull() Then
                retailerComboBox.SelectedIndex = -1
                detailEntryOptionGroupBox.Enabled = False
            Else
                retailerComboBox.SelectedValue = vehicleRow.RetId
                If Me.Processor.IsTradeclassMarkedForLimitedEntry(vehicleRow.RetId) Then
                    detailEntryOptionGroupBox.Enabled = True
                End If
            End If

            'Keep this blocks after retailer is set in retailer combobox.
            If vehicleRow.IsEntryIndNull() OrElse vehicleRow.EntryInd = 0 Then
                flagForDetailEntryCheckBox.Checked = False
            Else
                flagForDetailEntryCheckBox.Checked = True
            End If

            If vehicleRow.IsParentVehicleIdNull() Then
                parentVehicleIdTextBox.Clear()
            Else
                parentVehicleIdTextBox.Text = vehicleRow.ParentVehicleId.ToString()
            End If

            'Keeping default from Ret unless it's set in DB
            If Not vehicleRow.IsLanguageIdNull() Then
                languageComboBox.SelectedValue = vehicleRow.LanguageId
            End If

            If vehicleRow.IsEventIdNull() Then
                eventComboBox.SelectedValue = DBNull.Value
            Else
                eventComboBox.SelectedValue = vehicleRow.EventId
            End If

            If vehicleRow.IsThemeIdNull() Then
                themeComboBox.SelectedValue = DBNull.Value
            Else
                themeComboBox.SelectedValue = vehicleRow.ThemeId
            End If

            If vehicleRow.IsStartDtNull() Then
                startDateTypeInDatePicker.Clear()
            Else
                startDateTypeInDatePicker.Text = vehicleRow.StartDt.ToString("MM/dd/yy")
            End If

            If vehicleRow.IsEndDtNull() Then
                endDateTypeInDatePicker.Clear()
            Else
                endDateTypeInDatePicker.Text = vehicleRow.EndDt.ToString("MM/dd/yy")
            End If

            If vehicleRow.IsCouponIndNull Then
                couponCheckBox.Checked = False
            Else
                couponCheckBox.Checked = (vehicleRow.CouponInd = 1)
            End If

            If vehicleRow.ActualPageCount = 0 Then
                definePagesButton.Text = "Define Pages"
            Else
                definePagesButton.Text = "Define Pages (" + vehicleRow.ActualPageCount.ToString() + ")"
            End If

            If vehicleRow.IsFlashIndNull() OrElse vehicleRow.FlashInd = 0 Then
                flashCheckBox.Checked = False
            Else
                flashCheckBox.Checked = True
            End If

            If vehicleRow.IsNationalIndNull() OrElse vehicleRow.NationalInd = 0 Then
                nationalCheckBox.Checked = False
            Else
                nationalCheckBox.Checked = True
            End If

            If Me.IsFSI Then
                If vehicleRow.IsThemeIdNull() Then
                    themeComboBox.SelectedIndex = themeComboBox.FindStringExact("None")
                Else
                    themeComboBox.SelectedValue = vehicleRow.ThemeId
                End If
                If vehicleRow.IsEventIdNull() Then
                    eventComboBox.SelectedIndex = eventComboBox.FindStringExact("None")
                Else
                    eventComboBox.SelectedValue = vehicleRow.EventId
                End If
                If vehicleRow.IsStartDtNull() Then
                    startDateTypeInDatePicker.Value = Nothing
                Else
                    startDateTypeInDatePicker.Value = vehicleRow.StartDt
                End If
                If vehicleRow.IsEndDtNull() Then
                    endDateTypeInDatePicker.Value = Nothing
                Else
                    endDateTypeInDatePicker.Value = vehicleRow.EndDt
                End If
                
                couponCheckBox.Checked = True
            End If
            'CommentsLbl = Processor.getExpectationComments(vehicleRow.VehicleId, vehicleRow.RetId, vehicleRow.MktId, vehicleRow.MediaId)
            CommentsTextBox.Text = Processor.getExpectationComments(vehicleRow.VehicleId, vehicleRow.RetId, vehicleRow.MktId, vehicleRow.MediaId)

        End Sub

        Private Function GetMarketName(ByVal _mktid As Integer) As String
            Dim ReturnVal As String
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "select Descrip from Mkt where MktId=" + _mktid.ToString
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With

                If obj IsNot Nothing Then
                    ReturnVal = CType(obj, String)
                Else
                    ReturnVal = "Anonymous"
                End If

            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return ReturnVal
        End Function

        Private Function GetSenderName(ByVal _vehicleid As Integer) As String
            Dim ReturnVal As String
            Dim cmd As System.Data.SqlClient.SqlCommand
            Dim obj As Object


            cmd = New System.Data.SqlClient.SqlCommand

            Try
                With cmd
                    .CommandText = "select a.Name from [sender] as a inner join Envelope as b " + _
                                    "ON a.SenderId = b.SenderId where b.EnvelopeId =(select EnvelopeId from Vehicle where VehicleId = " + _vehicleid.ToString + ")"
                    .CommandType = CommandType.Text
                    .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                    .Connection.Open()
                    obj = .ExecuteScalar()
                End With

                If obj IsNot Nothing Then
                    ReturnVal = CType(obj, String)
                Else
                    ReturnVal = "Anonymous"
                End If

            Catch ex As Exception
                My.Application.Log.WriteException(ex)
            Finally
                If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
            End Try

            Return ReturnVal
        End Function
        ''' <summary>
        ''' Validates inputs as per business rules.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function ValidateBusinessRules() As Boolean
            Dim showMsg As Boolean
            Dim dateDifference As Integer
            Dim dateMsg As DateCheckDialog


            dateMsg = New DateCheckDialog()
            dateMsg.AllowIgnoreKey = True 'Processor.IsUserSupervisorOrAdministrator(Processor.UserID)

            If adDateTypeInDatePicker.Value.HasValue = True _
                AndAlso startDateTypeInDatePicker.Value.HasValue = True _
            Then
                showMsg = False
                dateDifference = adDateTypeInDatePicker.Value.Value.Subtract(startDateTypeInDatePicker.Value.Value).Days

                If (dateDifference < -7 OrElse dateDifference > 7) _
                  AndAlso (mediaComboBox.Text.ToUpper() = "MAILER" OrElse mediaComboBox.Text.ToUpper() = "CATALOG") _
                Then
                    showMsg = True
                ElseIf (dateDifference < -14 OrElse dateDifference > 14) _
                  AndAlso (tradeclassValueLabel.Text.ToUpper() = "DEPT") _
                Then
                    showMsg = True
                ElseIf (dateDifference < -28 OrElse dateDifference > 28) Then
                    showMsg = True
                End If

                If showMsg Then
                    dateMsg.MessageText = "Sale Start date is not close enough to Ad date to permit entry." _
                                          + " Correct one of the dates, or if they are correct set aside for" _
                                          + " supervisor."
                    If dateMsg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        dateMsg.Dispose()
                        dateMsg = Nothing
                        Return False
                    End If
                End If
            End If


            showMsg = False

            If endDateTypeInDatePicker.Value.HasValue Then
                showMsg = False

                If adDateTypeInDatePicker.Value.HasValue Then
                    If adDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days < -40 Then _
                      showMsg = True
                End If
            End If

            If showMsg = False AndAlso startDateTypeInDatePicker.Value.HasValue _
                AndAlso endDateTypeInDatePicker.Value.HasValue _
            Then
                If startDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days < -40 Then _
                    showMsg = True
            End If

            If showMsg Then
                dateMsg.MessageText = "Sale End date is not close enough to Ad date or Start date to permit" _
                                      + " entry. Correct one or more dates, or if they are correct set aside" _
                                      + " for supervisor."
                If dateMsg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    dateMsg.Dispose()
                    dateMsg = Nothing
                    Return False
                End If
            End If

            showMsg = False

            dateMsg.Dispose()
            dateMsg = Nothing


            Return Not showMsg

        End Function

        Private Function AreInputsValid() As Boolean
            Dim areAllValid As Boolean
            Dim tempDate As DateTime
            Dim Media As Integer = CType(mediaComboBox.SelectedValue, Integer)


            areAllValid = True

            If detailEntryOptionGroupBox.Enabled Then
                If flagForDetailEntryCheckBox.Checked = False AndAlso parentVehicleIdTextBox.Text.Trim().Length = 0 Then
                    areAllValid = False
                    SetErrorProvider(parentVehicleIdTextBox, "Parent Vehicle Id is required.")
                Else
                    RemoveErrorProvider(parentVehicleIdTextBox)
                End If
            End If

            If mediaComboBox.SelectedValue Is Nothing Then
                areAllValid = False
                SetErrorProvider(mediaComboBox, "Select media from drop down list.")
            Else
                RemoveErrorProvider(mediaComboBox)
            End If

            If marketComboBox.SelectedValue Is Nothing Then
                areAllValid = False
                SetErrorProvider(marketComboBox, "Select market from drop down list.")
            Else
                RemoveErrorProvider(marketComboBox)
            End If

            If publicationComboBox.SelectedValue Is Nothing Then
                areAllValid = False
                SetErrorProvider(publicationComboBox, "Select publication from drop down list.")
            Else
                RemoveErrorProvider(publicationComboBox)
            End If

            If adDateTypeInDatePicker.Text = "  /  /" _
              OrElse DateTime.TryParse(adDateTypeInDatePicker.Text, tempDate) = False _
            Then
                areAllValid = False
                SetErrorProvider(adDateTypeInDatePicker, "Provide valid ad date.")
            Else
                RemoveErrorProvider(adDateTypeInDatePicker)
            End If

            If DistDateTypeInDatePicker.Text = "  /  /" _
              OrElse DateTime.TryParse(DistDateTypeInDatePicker.Text, tempDate) = False _
            Then
                areAllValid = False
                SetErrorProvider(DistDateTypeInDatePicker, "Provide valid dist date.")
            Else
                RemoveErrorProvider(DistDateTypeInDatePicker)
            End If


            If retailerComboBox.SelectedValue Is Nothing Then
                areAllValid = False
                SetErrorProvider(retailerComboBox, "Select retailer from drop down list.")
            Else
                RemoveErrorProvider(retailerComboBox)
            End If

            If tradeclassValueLabel.Text.ToUpper() = "FSI" _
                AndAlso adDateTypeInDatePicker.Value.Value.DayOfWeek <> DayOfWeek.Sunday _
            Then
                Dim userResponse As DialogResult
                userResponse = MessageBox.Show("Are you sure this date is correct?", ProductName _
                                               , MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                               , MessageBoxDefaultButton.Button2)
                If userResponse = Windows.Forms.DialogResult.Yes Then
                    RemoveErrorProvider(adDateTypeInDatePicker)
                Else
                    areAllValid = False
                    adDateTypeInDatePicker.Focus()
                End If
            End If

            If languageComboBox.SelectedValue Is Nothing Then
                areAllValid = False
                SetErrorProvider(languageComboBox, "Select language from drop down list.")
            Else
                RemoveErrorProvider(languageComboBox)
            End If

            If eventComboBox.SelectedValue Is Nothing Then
                areAllValid = False
                SetErrorProvider(eventComboBox, "Select event from drop down list.")
            Else
                RemoveErrorProvider(eventComboBox)
            End If

            If themeComboBox.SelectedValue Is Nothing Then
                areAllValid = False
                SetErrorProvider(themeComboBox, "Select theme from drop down list.")
            Else
                RemoveErrorProvider(themeComboBox)
            End If
            If Media = 9 OrElse Media = 12 OrElse Media = 16 Then
                RemoveErrorProvider(startDateTypeInDatePicker)
            Else
                If startDateTypeInDatePicker.Text = "  /  /" _
                 And endDateTypeInDatePicker.Text <> "  /  /" _
               Then
                    areAllValid = False
                    SetErrorProvider(startDateTypeInDatePicker, "Provide valid start date.")
                Else
                    RemoveErrorProvider(startDateTypeInDatePicker)
                End If
            End If

            If startDateTypeInDatePicker.Text <> "  /  /" _
                And endDateTypeInDatePicker.Text = "  /  /" _
              Then
                'areAllValid = False
                SetErrorProvider(endDateTypeInDatePicker, "Provide valid end date.")
            Else
                RemoveErrorProvider(endDateTypeInDatePicker)
            End If
            If Media = 9 OrElse Media = 12 OrElse Media = 16 Then
                RemoveErrorProvider(startDateTypeInDatePicker)
            Else
                If startDateTypeInDatePicker.Text = "  /  /" _
                  OrElse DateTime.TryParse(startDateTypeInDatePicker.Text, tempDate) = False _
                Then
                    SetErrorProvider(startDateTypeInDatePicker, "Provide valid start date.")
                    areAllValid = False
                ElseIf startDateTypeInDatePicker.Value.HasValue = False Then
                    RemoveErrorProvider(startDateTypeInDatePicker)
                End If
            End If

            If endDateTypeInDatePicker.Text <> "  /  /" _
              AndAlso DateTime.TryParse(endDateTypeInDatePicker.Text, tempDate) = False _
            Then
                SetErrorProvider(endDateTypeInDatePicker, "Provide valid end date.")
                areAllValid = False
            ElseIf endDateTypeInDatePicker.Value.HasValue = False Then
                RemoveErrorProvider(endDateTypeInDatePicker)
            ElseIf adDateTypeInDatePicker.Value.HasValue _
              AndAlso adDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days > 0 _
            Then
                MessageBox.Show("End Date cannot be before Ad Date.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                areAllValid = False
            ElseIf startDateTypeInDatePicker.Value.HasValue _
              AndAlso startDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days > 0 _
            Then
                MessageBox.Show("End Date cannot be before Start Date.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                areAllValid = False
            ElseIf (adDateTypeInDatePicker.Value.HasValue _
                    AndAlso adDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days < -35) _
              OrElse (startDateTypeInDatePicker.Value.HasValue _
                    AndAlso startDateTypeInDatePicker.Value.Value.Subtract(endDateTypeInDatePicker.Value.Value).Days < -30) _
            Then
                Dim userResponse As DialogResult
                userResponse = MessageBox.Show("Sale End Date is unusual compared to Sale Start Date or Ad Date." _
                                               + " Check all values. Is the Sale End Date correct?", ProductName _
                                               , MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If userResponse = Windows.Forms.DialogResult.No Then areAllValid = False
            End If



            'Validate Start date and end date 
            Dim Cancel As Boolean

            OnStartDateValidating(adDateTypeInDatePicker.Value, startDateTypeInDatePicker.Value, Cancel)


            If areAllValid Then areAllValid = ValidateBusinessRules()

            Return areAllValid

        End Function

        Private Sub SetVehicleRowColumnValues(ByVal vehicleRow As QCDataSet.vwCircularRow, ByVal dupcheckResponse As UI.DuplicateCheckUserResponse)

            vehicleRow.BeginEdit()

            If flagForDetailEntryCheckBox.Checked Then
                vehicleRow.EntryInd = 1
            Else
                vehicleRow.SetEntryIndNull()
            End If

            If parentVehicleIdTextBox.Text.Trim().Length = 0 Then
                vehicleRow.SetParentVehicleIdNull()
            Else
                vehicleRow.ParentVehicleId = CType(parentVehicleIdTextBox.Text, Integer)
            End If

            If adDateTypeInDatePicker.Text = "  /  /" Then
                vehicleRow.SetBreakDtNull()
            Else
                vehicleRow.BreakDt = CType(adDateTypeInDatePicker.Text, DateTime)
            End If

            If DistDateTypeInDatePicker.Text = "  /  /" Then
                vehicleRow.SetDistDtNull()
            Else
                vehicleRow.DistDt = CType(DistDateTypeInDatePicker.Text, DateTime)
            End If

            If mediaComboBox.SelectedValue Is Nothing Then
                vehicleRow.SetMediaIdNull()
            Else
                vehicleRow.MediaId = CType(mediaComboBox.SelectedValue, Integer)
            End If
            If marketComboBox.SelectedValue Is Nothing Then
                vehicleRow.SetMktIdNull()
            Else
                vehicleRow.MktId = CType(marketComboBox.SelectedValue, Integer)
            End If
            If publicationComboBox.SelectedValue Is Nothing Then
                vehicleRow.SetPublicationIdNull()
            Else
                vehicleRow.PublicationId = CType(publicationComboBox.SelectedValue, Integer)
            End If
            If retailerComboBox.SelectedValue Is Nothing Then
                vehicleRow.SetRetIdNull()
            Else
                vehicleRow.RetId = CType(retailerComboBox.SelectedValue, Integer)
            End If
            If languageComboBox.SelectedValue Is Nothing Then
                vehicleRow.SetLanguageIdNull()
            Else
                vehicleRow.LanguageId = CType(languageComboBox.SelectedValue, Integer)
            End If
            If eventComboBox.SelectedValue Is Nothing Then
                vehicleRow.SetEventIdNull()
            Else
                vehicleRow.EventId = CType(eventComboBox.SelectedValue, Integer)
            End If
            If couponCheckBox.Checked Then
                vehicleRow.CouponInd = 1
            Else
                vehicleRow.CouponInd = 0
            End If
            If themeComboBox.SelectedValue Is Nothing Then
                vehicleRow.SetThemeIdNull()
            Else
                vehicleRow.ThemeId = CType(themeComboBox.SelectedValue, Integer)
            End If
            If startDateTypeInDatePicker.Text = "  /  /" Then
                vehicleRow.SetStartDtNull()
            Else
                vehicleRow.StartDt = CType(startDateTypeInDatePicker.Text, DateTime)
            End If
            If endDateTypeInDatePicker.Text = "  /  /" Then
                vehicleRow.SetEndDtNull()
            Else
                vehicleRow.EndDt = CType(endDateTypeInDatePicker.Text, DateTime)
            End If
            If flashCheckBox.Checked Then
                vehicleRow.FlashInd = 1
            Else
                vehicleRow.FlashInd = 0
            End If
            If nationalCheckBox.Checked Then
                vehicleRow.NationalInd = 1
            Else
                vehicleRow.NationalInd = 0
            End If

            If dupcheckResponse = DuplicateCheckUserResponse.Review Then
                Processor.SetVehicleStatusAsReviewed(vehicleRow)
            ElseIf dupcheckResponse = DuplicateCheckUserResponse.Duplicate Then
                Processor.SetVehicleStatusAsDuplicate(vehicleRow)
            ElseIf dupcheckResponse = DuplicateCheckUserResponse.NoPossibleDuplidates _
              OrElse dupcheckResponse = DuplicateCheckUserResponse.Override _
            Then
                Processor.SetVehicleStatusAsIndexed(vehicleRow)
            End If
            vehicleRow.FormName = FORM_NAME
            vehicleRow.EndEdit()

        End Sub

        Private Function ShowFamilyCreationScreen(ByVal tempVehicleRow As QCDataSet.vwCircularRow, ByVal copyFamilyValues As Boolean) As Integer
            Dim familyId As Integer
            Dim userResponse As DialogResult
            Dim checkFamily As FamilyCreationForm


            '
            'While editing vehicle, if retailer is not changed then family creation screen should not to be displayed.
            '
            If Me.FormState = FormStateEnum.Edit AndAlso tempVehicleRow.HasVersion(DataRowVersion.Original) Then
                If tempVehicleRow("RetId", DataRowVersion.Original) Is tempVehicleRow("RetId", DataRowVersion.Current) Then
                    Return -1
                End If
            End If

            checkFamily = New FamilyCreationForm(tempVehicleRow.BreakDt, tempVehicleRow.MediaId _
                                           , tempVehicleRow.RetId, 0, 3)
            checkFamily.Init(FormStateEnum.View)
            checkFamily.ApplyUserCredentials()

            checkFamily.addateValueLabel.Text = tempVehicleRow.BreakDt.ToString("MM/dd/yy")
            checkFamily.retailerNameLabel.Text = tempVehicleRow.RetRow.Descrip
            checkFamily.marketNameLabel.Text = tempVehicleRow.MktRow.Descrip
            'checkFamily.pagesValueLabel.Text = tempVehicleRow.CheckInPageCount.ToString()
            checkFamily.pagesValueLabel.Text = ""
            If tempVehicleRow.IsEventIdNull() Then
                checkFamily.eventNameLabel.Text = String.Empty
            Else
                checkFamily.eventNameLabel.Text = tempVehicleRow.EventRow.Descrip
            End If
            If tempVehicleRow.IsThemeIdNull() Then
                checkFamily.themeNameLabel.Text = String.Empty
            Else
                checkFamily.themeNameLabel.Text = tempVehicleRow.ThemeRow.Descrip
            End If
            If tempVehicleRow.IsStartDtNull() Then
                checkFamily.startDateValueLabel.Text = String.Empty
            Else
                checkFamily.startDateValueLabel.Text = startDateTypeInDatePicker.Text
            End If
            If tempVehicleRow.IsEndDtNull() Then
                checkFamily.endDateValueLabel.Text = String.Empty
            Else
                checkFamily.endDateValueLabel.Text = endDateTypeInDatePicker.Text
            End If

            checkFamily.Show()
            checkFamily.Hide()
            checkFamily.LoadPotentialFamilies()
            userResponse = checkFamily.ShowDialog(Me)
            If Not (userResponse = Windows.Forms.DialogResult.OK AndAlso checkFamily.FamilyId > 0) Then
                familyId = -1
            Else
                familyId = checkFamily.FamilyId

                If copyFamilyValues AndAlso checkFamily.IsNewFamily = False Then
                    Dim tempRow As FamilyDataSet.DisplayFamilyInformationRow


                    tempRow = checkFamily.CurrentRow
                    tempVehicleRow.EventId = tempRow.EventId
                    eventComboBox.SelectedValue = tempRow.EventId
                    tempVehicleRow.ThemeId = tempRow.ThemeId
                    themeComboBox.SelectedValue = tempRow.ThemeId
                    If Not tempRow.IsStartDtNull Then
                        tempVehicleRow.StartDt = tempRow.StartDt
                        startDateTypeInDatePicker.Value = tempRow.StartDt
                    End If
                    If Not tempRow.IsEndDtNull Then
                        tempVehicleRow.EndDt = tempRow.EndDt
                        endDateTypeInDatePicker.Value = tempRow.EndDt
                    End If
                    tempVehicleRow.LanguageId = tempRow.LanguageId
                    languageComboBox.SelectedValue = tempRow.LanguageId
                    Processor.CopyPageInformation(tempRow.VehicleId, tempVehicleRow.VehicleId, FORM_NAME)
                End If
            End If

            checkFamily.Dispose()
            checkFamily = Nothing

            Return familyId

        End Function

#Region " IForm Implementation "


        Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
        Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied

        Public Event FormInitialized() Implements IForm.FormInitialized
        Public Event InitializingForm() Implements IForm.InitializingForm


        Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials

        End Sub

        Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

            RaiseEvent InitializingForm()

            Me.SuspendLayout()

            Me.FormState = formStatus

            m_Processor = New Processors.Index
            Processor.Initialize()
            Processor.LoadDataSet(_sender)

            Me.StatusMessage = "Information loaded. Preparing to show information on window."

            mediaComboBox.ValueMember = "MediaId"
            mediaComboBox.DisplayMember = "Descrip"
            mediaComboBox.DataSource = Processor.Data.Media

            marketComboBox.ValueMember = "MktId"
            marketComboBox.DisplayMember = "Descrip"
            marketComboBox.DataSource = Processor.Data.Mkt

            publicationComboBox.ValueMember = "PublicationId"
            publicationComboBox.DisplayMember = "Descrip"
            publicationComboBox.DataSource = Processor.Data.Publication

            languageComboBox.ValueMember = "LanguageId"
            languageComboBox.DisplayMember = "Descrip"
            languageComboBox.DataSource = Processor.Data.Language

            retailerComboBox.ValueMember = "RetId"
            retailerComboBox.DisplayMember = "Descrip"
            retailerComboBox.DataSource = Processor.Data.Ret

            eventComboBox.ValueMember = "EventId"
            eventComboBox.DisplayMember = "Descrip"
            eventComboBox.DataSource = Processor.Data._Event

            themeComboBox.ValueMember = "ThemeId"
            themeComboBox.DisplayMember = "Descrip"
            themeComboBox.DataSource = Processor.Data.Theme

            ClearAllInputs()
            RemoveAllErrorProviders()
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

            printButton.Visible = False
            editButton.Visible = False
            enterButton.Visible = True
            enterButton.Enabled = False

            Me.ResumeLayout(False)

            RaiseEvent FormInitialized()

        End Sub


#End Region


        Protected Overrides Sub OnFindVehicle(ByVal vehicleId As Integer, ByVal eventInitiator As EventInitiatorEnum)
            Dim _EnvelopeID As Integer
            Me.FormState = FormStateEnum.View

            ClearAllInputs()
            RemoveAllErrorProviders()
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

            printButton.Visible = False
            editButton.Visible = False
            enterButton.Visible = True
            enterButton.Enabled = False

            With Processor
                .LoadVehicle(vehicleId, FORM_NAME)
                If .Data.vwCircular.Rows.Count > 0 Then
                    _EnvelopeID = CInt(Processor.Data.vwCircular.Rows(0).Item(1).ToString)
                    If _SenderID = 0 Then _SenderID = .LoadEnvelopeSenderInfo(_EnvelopeID)
                    If .Data.Media.Rows.Count = 0 Then .LoadDataSet(_SenderID)
                    mediaComboBox.SelectedValue = CInt(Processor.Data.vwCircular.Rows(0).Item("MediaId").ToString)
                    marketComboBox.SelectedValue = CInt(Processor.Data.vwCircular.Rows(0).Item("MktId").ToString)
                    parentVehicleIdTextBox.Text = Processor.Data.vwCircular.Rows(0).Item("ParentVehicleId").ToString
                    If String.IsNullOrEmpty(Processor.Data.vwCircular.Rows(0).Item("EventId").ToString) = True Then
                        eventComboBox.SelectedIndex = -1
                    Else
                        eventComboBox.SelectedValue = CInt(Processor.Data.vwCircular.Rows(0).Item("EventId").ToString)
                    End If
                    If String.IsNullOrEmpty(Processor.Data.vwCircular.Rows(0).Item("ThemeId").ToString) = True Then
                        themeComboBox.SelectedIndex = -1
                    Else
                        themeComboBox.SelectedValue = CInt(Processor.Data.vwCircular.Rows(0).Item("ThemeId").ToString)
                    End If
                End If
            End With

        End Sub

        Protected Overrides Sub OnAdDateValidating(ByVal adDate As Date?, ByRef Cancel As Boolean)
            Dim dateDifference As Integer
            Dim userResponse As DialogResult

            RemoveErrorProvider(adDateTypeInDatePicker)
            If adDate Is Nothing Then
                Cancel = False
                Exit Sub
            End If

            dateDifference = adDate.Value.Subtract(System.DateTime.Today).Days

            If dateDifference < -365 OrElse dateDifference > 365 Then
                userResponse = MessageBox.Show("Is Ad Date correct?", ProductName, MessageBoxButtons.YesNo _
                                               , MessageBoxIcon.Question)
                Cancel = (userResponse = Windows.Forms.DialogResult.No)
            ElseIf dateDifference < -28 Or dateDifference > 28 Then
                SetErrorProvider(adDateTypeInDatePicker, "Ad Date needs to be within 28 days from today's date.")
            End If

        End Sub

        Protected Sub OnDistDateValidating(ByVal DistDate As Date?, ByRef Cancel As Boolean)
            Dim dateDifference As Integer
            Dim userResponse As DialogResult

            RemoveErrorProvider(DistDateTypeInDatePicker)
            If DistDate Is Nothing Then
                Cancel = False
                Exit Sub
            End If

            dateDifference = DistDate.Value.Subtract(System.DateTime.Today).Days

            If dateDifference < -365 OrElse dateDifference > 365 Then
                userResponse = MessageBox.Show("Is Dist Date correct?", ProductName, MessageBoxButtons.YesNo _
                                               , MessageBoxIcon.Question)
                Cancel = (userResponse = Windows.Forms.DialogResult.No)
            ElseIf dateDifference < -28 Or dateDifference > 28 Then
                SetErrorProvider(DistDateTypeInDatePicker, "Dist Date needs to be within 28 days from today's date.")
            End If

        End Sub

        Protected Overrides Sub OnRetailerChanged(ByVal retailerId As Integer, ByVal tradeclassId As Integer, ByVal tradeclass As String)
            Dim marketId As Integer
            Dim retInfo As System.Data.EnumerableRowCollection(Of QCDataSet.RetRow)


            retInfo = From r In Processor.Data.Ret _
                      Where r.RetId = retailerId AndAlso r.IsLanguageIdNull() = False _
                      Select r

            If retInfo.Count() < 1 Then
                languageComboBox.SelectedValue = DBNull.Value
            Else
                languageComboBox.SelectedValue = retInfo(0).LanguageId
            End If

            retInfo = Nothing

            If retailerId < 1 Then
                detailEntryOptionGroupBox.Enabled = False
            Else
                flagForDetailEntryCheckBox.Checked = False
                parentVehicleIdTextBox.Clear()
                If Me.Processor.IsTradeclassMarkedForLimitedEntry(retailerId) Then
                    detailEntryOptionGroupBox.Enabled = True
                Else
                    detailEntryOptionGroupBox.Enabled = False
                End If
            End If

            If marketComboBox.SelectedValue Is Nothing _
              OrElse Integer.TryParse(marketComboBox.SelectedValue.ToString(), marketId) = False _
            Then
                marketId = -1
            End If

            ValidateForFRControl(retailerId, marketId)

        End Sub

        Protected Overrides Sub OnRetailerValidated()

            If Me.IsFSI Then flashCheckBox.Focus()

        End Sub

        Protected Overrides Sub OnStartDateValidating(ByVal adDate As Date?, ByVal startDate As Date?, ByRef Cancel As Boolean)
            Dim dateDifference As Integer


            If adDate.HasValue = False OrElse startDate.HasValue = False Then
                Cancel = False
                Exit Sub
            End If

            dateDifference = startDate.Value.Subtract(adDate.Value).Days

            If (dateDifference < -7 Or dateDifference > 7) _
              AndAlso (mediaComboBox.Text.ToUpper() = "MAILER" OrElse mediaComboBox.Text.ToUpper() = "CATALOG") _
            Then
                SetErrorProvider(startDateTypeInDatePicker, "Start Date needs to be within 7 days of Ad Date.")

            ElseIf tradeclassValueLabel.Text.ToUpper() = "DEPT" _
              AndAlso (dateDifference < -14 Or dateDifference > 14) _
            Then
                SetErrorProvider(startDateTypeInDatePicker, "Start Date needs to be within 14 days of Ad Date.")

            ElseIf dateDifference < -28 Or dateDifference > 28 Then
                SetErrorProvider(startDateTypeInDatePicker, "Start Date needs to be within 28 days of Ad Date.")

            Else
                RemoveErrorProvider(startDateTypeInDatePicker)

                If (dateDifference < -3 OrElse dateDifference > 3) Then
                    Dim userResponse As DialogResult
                    userResponse = MessageBox.Show("Difference between Sale Start Date and Ad Date should not be more than 3 days." _
                                         + " Is Sale Start Date correct?", ProductName _
                                         , MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                         , MessageBoxDefaultButton.Button2)
                    If userResponse = Windows.Forms.DialogResult.No Then
                        startDateTypeInDatePicker.Focus()
                        Exit Sub
                    Else
                        RemoveErrorProvider(startDateTypeInDatePicker)
                        RemoveErrorProvider(endDateTypeInDatePicker)
                    End If
                End If
            End If

        End Sub

        Protected Overrides Sub OnEndDateValidating(ByVal adDate As Date?, ByVal startDate As Date?, ByVal endDate As Date?, ByRef Cancel As Boolean)
            Dim dateDifference As Integer


            'If endDate.HasValue = False Then
            '  RemoveErrorProvider(endDateTypeInDatePicker)
            '  Exit Sub
            'End If

            'If adDate.HasValue Then
            '  dateDifference = adDate.Value.Subtract(endDate.Value).Days
            '  If adDate.Value.Subtract(endDate.Value).Days > 0 Then
            '    SetErrorProvider(endDateTypeInDatePicker, "End date cannot prior to Ad date.")
            '  ElseIf adDate.Value.Subtract(endDate.Value).Days < -35 Then 'i.e. adDt - endDt
            '    SetErrorProvider(endDateTypeInDatePicker, "End date is not within 35 days of Ad date.")
            '  Else
            '    RemoveErrorProvider(endDateTypeInDatePicker)
            '  End If
            'End If

            'If startDate.HasValue AndAlso m_ErrorProvider.GetError(endDateTypeInDatePicker) = String.Empty Then
            '  dateDifference = startDate.Value.Subtract(endDate.Value).Days
            '  If startDate.Value.Subtract(endDate.Value).Days > 0 Then 'i.e. StartDt - endDt
            '    SetErrorProvider(endDateTypeInDatePicker, "End date cannot be prior to Start Date.")
            '  ElseIf startDate.Value.Subtract(endDate.Value).Days < -30 Then  'i.e. StartDt - endDt
            '    SetErrorProvider(endDateTypeInDatePicker, "End date is not within 30 days of Start Date.")
            '  Else
            '    RemoveErrorProvider(endDateTypeInDatePicker)
            '  End If
            'End If

            'If dateDifference < -30 OrElse dateDifference > 30 Then
            '  Dim userResponse As DialogResult
            '  userResponse = MessageBox.Show("Sale End Date is unusual compared to Sale Start Date or Ad Date." _
            '                                 + " Check these values. Is Sale End Date correct?", ProductName _
            '                                 , MessageBoxButtons.YesNo, MessageBoxIcon.Question _
            '                                 , MessageBoxDefaultButton.Button2)
            '  If userResponse = Windows.Forms.DialogResult.No Then
            '    startDateTypeInDatePicker.Focus()
            '    Exit Sub
            '  Else
            '    RemoveErrorProvider(endDateTypeInDatePicker)
            '  End If
            'End If

        End Sub

        Protected Overrides Sub OnDefinePages(ByVal vehicleId As Integer)
            Dim pageDefine As PageDefinitionsForm

            If parentVehicleIdTextBox.Text.Trim().Length > 0 AndAlso Processor.IsPageInformationAvailable(vehicleId) = False Then
                Dim parentVehicleId As Integer

                If Integer.TryParse(parentVehicleIdTextBox.Text, parentVehicleId) Then
                    'Dim userResponse As DialogResult

                    'userResponse = MessageBox.Show(Me, "Do you want to copy page definitions from Parent Vehicle?", ProductName _
                    '                               , MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    'If userResponse = Windows.Forms.DialogResult.Yes Then Processor.CopyPageInformation(parentVehicleId, vehicleId, FORM_NAME)
                    Processor.CopyPageInformation(parentVehicleId, vehicleId, FORM_NAME)
                End If
            End If

            pageDefine = New PageDefinitionsForm
            pageDefine.Init(FormStateEnum.View)
            pageDefine.ApplyUserCredentials()
            pageDefine.VehicleID = vehicleId
            'pageDefine.ExpectedPageCount = m_expectedPageCount

            dsPage = New DataSet
            If dsPage.Tables.Count = 0 Then
                dsPage = LoadVehiclePageDetails(vehicleId)
                ctr = dsPage.Tables(0).Rows.Count
            End If

            If pageDefine.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                'Set CheckInPageCount here. User may have changed it in pagedefinition screen.
                definePagesButton.Text = "Define Pages (" + pageDefine.PageDefinitionsProcessor.GetPageCount.ToString() + ")"
                If arrPageName.Count > 0 Then
                    If vehicleId <> CType(arrPageName.Item(0).ToString, Integer) Then arrPageName.Clear()
                End If
                If arrPageName.Count = 0 And ctr > 0 Then

                    For i As Integer = 0 To ctr

                        If i = 0 Then
                            arrPageName.Add(dsPage.Tables(0).Rows(i).Item(0).ToString)
                            Continue For
                        End If
                        Dim str As String = dsPage.Tables(0).Rows(i - 1).Item(1).ToString
                        arrPageName.Add(str)
                    Next
                Else
                    If isVehicleQCed(vehicleId) Then
                        For c As Integer = 1 To arrPageName.Count - 1
                            UpdatePageImageName(arrPageName.Item(c), c, vehicleId)
                        Next
                    End If

                    dsPage = Nothing
                End If
                m_expectedPageCount = pageDefine.ExpectedPageCount
                If Processor.Data.vwCircular.Count > 0 AndAlso Processor.Data.vwCircular(0).VehicleId = vehicleId Then
                    Processor.Data.vwCircular(0).CheckInPageCount = m_expectedPageCount
                End If
            End If

            pageDefine.Dispose()
            pageDefine = Nothing

        End Sub

        Private Sub exitButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles exitButton.Click
            isClosedByButton = True
            Me.Close()

        End Sub

        Private Sub flagForDetailEntryCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles flagForDetailEntryCheckBox.CheckedChanged

            If flagForDetailEntryCheckBox.Checked Then
                parentVehicleIdTextBox.Clear()
                parentVehicleIdTextBox.Enabled = False
            Else
                parentVehicleIdTextBox.Enabled = True
            End If

        End Sub

        Private Sub parentVehicleIdTextBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles parentVehicleIdTextBox.KeyPress

            If Not (Char.IsDigit(e.KeyChar) _
              OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 8 _
              OrElse Microsoft.VisualBasic.AscW(e.KeyChar) = 22) _
            Then
                e.Handled = True
            End If

        End Sub

        Private Sub flashCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles flashCheckBox.CheckedChanged
            Dim retailerId As Integer

            If retailerComboBox.SelectedValue Is Nothing Then
                retailerId = -1
            Else
                retailerId = CType(retailerComboBox.SelectedValue, Integer)
            End If
            nationalCheckBox.Enabled = flashCheckBox.Checked And Processor.IsValidFlashNational(retailerId)
            If flashCheckBox.Checked = False Then nationalCheckBox.Checked = False

        End Sub

        Private Sub enterandcloseButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles enterandcloseButton.Click

            enterButton_Click(sender, e)
            If Me.FormState = FormStateEnum.View Then exitButton_Click(sender, e)

        End Sub

        Private Sub enterButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles enterButton.Click
            Dim saleDatesAreChanged, isFamilyRequired As Boolean
            Dim mediaId As Integer
            Dim dupcheckResponse As UI.DuplicateCheckUserResponse
            Dim tempRow As QCDataSet.vwCircularRow


            If AreInputsValid() = False Then Exit Sub

            If Integer.TryParse(mediaComboBox.SelectedValue.ToString(), mediaId) = False Then
                MessageBox.Show("Unable to identify selected media. Can not proceed with indexing.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            RemoveAllErrorProviders()
            saleDatesAreChanged = True
            tempRow = Processor.Data.vwCircular(0)
            If tempRow.RetRow IsNot Nothing Then
                isFamilyRequired = Processor.IsTradeclassRequireFamily(tempRow.RetRow.TradeClassId)
            End If

            If tempRow.MediaId <> mediaId Then
                tempRow.MediaId = mediaId
                tempRow.SetFamilyIdNull()
            End If

            '
            'While showing create/join family screen, information provided on screen should be used.
            '
            'If tempRow.IsFamilyIdNull() AndAlso isFamilyRequired Then
            '  Dim familyId As Integer

            '  MessageBox.Show("To finish indexing, vehicle must belong to a family.", ProductName _
            '                  , MessageBoxButtons.OK, MessageBoxIcon.Information)
            '  familyId = ShowFamilyCreationScreen(tempRow, False)
            '  If familyId > 0 Then tempRow.FamilyId = familyId
            'End If

            If Processor.IsPageInformationAvailable(tempRow.VehicleId) = False Then
                MessageBox.Show("Cannot index vehicle without page information. Please define pages for Vehicle." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            dupcheckResponse = CheckForDuplication(CType(marketComboBox.SelectedValue, Integer) _
                                                   , CType(publicationComboBox.SelectedValue, Integer), True, FORM_NAME)

            If dupcheckResponse = DuplicateCheckUserResponse.Closed Then Exit Sub

            SetVehicleRowColumnValues(tempRow, dupcheckResponse)

            If tempRow.IsFamilyIdNull() AndAlso isFamilyRequired Then
                Dim familyId As Integer

                MessageBox.Show("To finish indexing, vehicle must belong to a family.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                familyId = ShowFamilyCreationScreen(tempRow, False)
                If familyId > 0 Then tempRow.FamilyId = familyId
            End If

            If Processor.AreInputsValid(tempRow) = False Then
                If Processor.Data.Errors.Count > 0 Then
                    ShowErrors(Processor.Data.Errors)
                    Processor.Data.Errors.Clear()
                    Exit Sub
                ElseIf Processor.Data.Warnings.Count > 0 Then
                    If ShowWarnings(Processor.Data.Warnings) = Windows.Forms.DialogResult.Cancel Then
                        Processor.Data.Warnings.Clear()
                        Exit Sub
                    End If
                End If
            End If

            If IsWrongVersion Then

                tempRow.StatusID = 2063
            End If

            'Processor.SynchronizeVehicleInformation()
            Processor.SynchronizeVehicleInformation(tempRow)

            UpdateVehicleIdForDupCheckFormLogId(tempRow.VehicleId, Me.DupcheckFormLogId)

            Me.enterButton.Text = "Enter"
            Me.FormState = FormStateEnum.View
            Me.ShowHideControls(Me.FormState)
            Me.EnableDisableControls(Me.FormState)
            findVehicleIdTextBox.Focus()


        End Sub

        Private Sub printButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles printButton.Click
            Dim vehicleId As Integer


            If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
                vehicleId = -1
            End If

            If vehicleId < 0 Then
                MessageBox.Show("Load Vehicle to print barcode label.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If


#If DEBUG Then

            If MessageBox.Show("Do you want to print?", Application.ProductName, MessageBoxButtons.YesNo _
                               , MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No _
            Then
                Exit Sub
            End If

#End If

            Processor.PrintBarcodeLabel(Processor.Data.vwCircular(0))

        End Sub

        Private Sub editButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles editButton.Click

            Me.editButton.Visible = False
            Me.enterButton.Text = "&Save"
            Me.enterButton.Visible = True

            Me.FormState = FormStateEnum.Edit
            EnableDisableControls(Me.FormState)
            ShowHideControls(Me.FormState)

        End Sub

        Private Sub deleteButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles deleteButton.Click
            Dim vehicleId As Integer
            Dim userResponse As DialogResult


            If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
                MessageBox.Show("Load Vehicle to delete it.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            userResponse = MessageBox.Show("Are you sure you want to delete Vehicle " + vehicleId.ToString() + "?" _
                                           , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                           , MessageBoxDefaultButton.Button2)

            If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

            Processor.Delete(vehicleId)

            Me.FormState = FormStateEnum.Insert
            ClearAllInputs()
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)
            Me.findVehicleIdTextBox.Focus()

        End Sub

        Private Sub IndexForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If e.CloseReason = CloseReason.UserClosing And isClosedByButton = False Then
                If (MessageBox.Show("Are you sure you want to close this form?", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                    e.Cancel = True
                End If
            End If
        End Sub

        Private Sub IndexForm_FormInitialized() Handles Me.FormInitialized

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub IndexForm_InitializingForm() Handles Me.InitializingForm

            Me.StatusMessage = "Loading information. This may take some time. Please wait..."

        End Sub

        Private Sub m_Processor_BarcodePrinted(ByVal sender As Object, ByVal e As MCAP.UI.Processors.EventArgs) Handles m_Processor.BarcodePrinted

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_DataLoaded() Handles m_Processor.DataLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_Initialized() Handles m_Processor.Initialized

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_InvalidVehicleStatus(ByVal statusText As String) Handles m_Processor.InvalidVehicleStatus

            Me.StatusMessage = String.Empty

            MessageBox.Show("Vehicle cannot be loaded because it has the Status of: " + statusText _
                            , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Sub

        Private Sub m_Processor_LoadingMarkets() Handles m_Processor.LoadingMarkets

            Me.StatusMessage = "Loading Markets..."

        End Sub

        Private Sub m_Processor_LoadingPublications() Handles m_Processor.LoadingPublications

            Me.StatusMessage = "Loading Publications..."

        End Sub

        Private Sub m_Processor_LoadingRetailers() Handles m_Processor.LoadingRetailers

            Me.StatusMessage = "Loading Retailers..."

        End Sub

        Private Sub m_Processor_LoadingVehicle() Handles m_Processor.LoadingVehicle

            Me.StatusMessage = "Loading Vehicle information. This may take some time. Please wait..."

        End Sub

        Private Sub m_Processor_MarketsLoaded() Handles m_Processor.MarketsLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_PublicationsLoaded() Handles m_Processor.PublicationsLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_RetailersLoaded() Handles m_Processor.RetailersLoaded

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_VehicleLoaded(ByVal vehicleRow As QCDataSet.vwCircularRow) Handles m_Processor.VehicleLoaded
            Dim isFamilyRequired As Boolean


            ClearAllInputs()
            RemoveAllErrorProviders()

            vehicleRow = Processor.Data.vwCircular(0)
            'Processor.LoadMarket(vehicleRow.EnvelopeId)
            'Processor.LoadRetailer(vehicleRow.MediaId, vehicleRow.MktId)

            ShowVehicleInformation(vehicleRow)
            If vehicleRow.RetRow IsNot Nothing Then
                isFamilyRequired = Processor.IsTradeclassRequireFamily(vehicleRow.RetRow.TradeClassId)
            End If

            If vehicleRow.IsFamilyIdNull() AndAlso isFamilyRequired Then
                Dim familyId As Integer

                familyId = ShowFamilyCreationScreen(vehicleRow, True)
                If familyId > 0 Then vehicleRow.FamilyId = familyId
            End If

            If Processor.IsVehicleIndexed(vehicleRow.VehicleId) Then
                Me.FormState = FormStateEnum.View
            Else
                Me.FormState = FormStateEnum.Insert
            End If

            ' Omar
            'If Processor.IsVehicleQCed(vehicleRow.VehicleId) Then
            '    Me.FormState = FormStateEnum.View
            'Else
            '    Me.FormState = FormStateEnum.Insert
            'End If

            vehicleRow = Nothing

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_VehicleNotFound(ByVal vehicleId As Integer) Handles m_Processor.VehicleNotFound

            Me.StatusMessage = String.Empty

            MessageBox.Show("Vehicle " & CType(vehicleId, String) & " not found.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Sub

        Private Sub m_Processor_SynchronizingVehicle() Handles m_Processor.SynchronizingVehicleInformation

            Me.StatusMessage = "Synchronizing Vehicle information with database..."

        End Sub

        Private Sub m_Processor_VehicleSynchronized() Handles m_Processor.VehicleInformationSynchronized

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_Processor_Initializing() Handles m_Processor.Initializing

            Me.StatusMessage = "Initializing process..."

        End Sub

        Private Sub m_Processor_LoadingData() Handles m_Processor.LoadingData

            Me.StatusMessage = "Loading initial information from database. This may take some time. Please wait..."

        End Sub

        Private Sub m_Processor_PrintingBarcode(ByVal sender As Object, ByVal e As MCAP.UI.Processors.CancellableEventArgs) Handles m_Processor.PrintingBarcode

            Me.StatusMessage = "Printing barcode label..."

        End Sub

        Private Sub m_Processor_VehicleDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_Processor.VehicleDeleted

            MessageBox.Show("Vehicle " + e.Data("VehicleId").ToString() + " removed successfully." _
                            , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Sub


        Private Sub IndexForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

        ''' <summary>
        ''' Marks vehicles in array with status as Review. Removes DataRows from DataTable.
        ''' </summary>
        ''' <param name="vehicleIdArray"></param>
        ''' <remarks></remarks>
        Private Sub MarkVehiclesForWrongVersion(ByVal vehicleIdArray() As Integer)
            Dim tempAdapter As MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter
            Dim tempTable As MCAP.ReportsDataSet.VehiclesDataTable
            Dim tempRow As MCAP.ReportsDataSet.VehiclesRow


            tempAdapter = New MCAP.ReportsDataSetTableAdapters.VehiclesTableAdapter()
            tempAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()


            For i As Integer = 0 To vehicleIdArray.Length - 1
                tempAdapter.UpdateVehicleStatus(FORM_NAME, vehicleIdArray(i), "Wrong Version", User.UserID)

                'tempRow.Delete()
            Next
            '  tempTable.AcceptChanges()

            tempAdapter.Dispose()
            tempAdapter = Nothing
            tempTable = Nothing
            tempRow = Nothing
        End Sub

        Private Sub WrongVersionButton_Click(sender As Object, e As EventArgs) Handles WrongVersionButton.Click
            Dim vehicleId As Integer
            Dim userResponse As DialogResult

            If Integer.TryParse(vehicleIdValueLabel.Text, vehicleId) = False Then
                MessageBox.Show("Load Vehicle to delete it.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            userResponse = MessageBox.Show("Are you sure you want to mark as wrong version " + vehicleId.ToString() + "?" _
                                           , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                           , MessageBoxDefaultButton.Button2)

            If userResponse = Windows.Forms.DialogResult.No Then Exit Sub
            IsWrongVersion = True

            MarkVehiclesForWrongVersion(New Integer() {vehicleId})
            'enterButton.PerformClick()
            ClearAllInputs()
        End Sub
    End Class


End Namespace