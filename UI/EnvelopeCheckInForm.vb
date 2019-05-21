Imports System.Text.RegularExpressions
Namespace UI


    Public Class EnvelopeCheckInForm
        Implements IForm


        ''' <summary>
        ''' This constant is used to assigning value to FormName column.
        ''' </summary>
        ''' <remarks></remarks>
        Private Const FORM_NAME As String = "Envelope Check-In"


        Private m_shippingNotRequired As Boolean
        Private m_NeedTrackingNo As Boolean
        Private m_barcodePrinter As String
        Private WithEvents m_envelopeProcessor As UI.Processors.Envelope
        Private isClosedByButton As Boolean = False



        Private ReadOnly Property Processor() As UI.Processors.Envelope
            Get
                Return m_envelopeProcessor
            End Get
        End Property

        Private ReadOnly Property IsShippingNotRequired() As Boolean
            Get
                Return m_shippingNotRequired
            End Get
        End Property



        ''' <summary>
        ''' Clears all inputs on form.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub ClearAllInputs()

            envelopeIDValueLabel.Text = String.Empty
            senderComboBox.SelectedValue = DBNull.Value
            senderComboBox.Text = String.Empty
            shippingCompanyComboBox.SelectedValue = DBNull.Value
            shippingCompanyComboBox.Text = String.Empty
            shippingMethodComboBox.SelectedValue = DBNull.Value
            shippingMethodComboBox.Text = String.Empty
            trackNumberTextBox.Clear()
            printedWeightTextBox.Clear()
            actualWeightTextBox.Clear()
            packageTypeComboBox.SelectedValue = DBNull.Value
            packageTypeComboBox.Text = String.Empty
            packageAssignmentComboBox.SelectedValue = DBNull.Value
            packageAssignmentComboBox.Text = String.Empty
            receivedDateValueLabel.Text = System.DateTime.Today.ToString("MM/dd/yy")
            receivedByValueLabel.Text = Processor.UserFirstName + " " + Processor.UserLastName
            searchEnvelopeIDTextBox.Clear()

            m_shippingNotRequired = False

        End Sub

        ''' <summary>
        ''' EnableDisables input controls based on supplied value of formStatus.
        ''' </summary>
        ''' <param name="formStatus"></param>
        Protected Overrides Sub EnableDisableControls(ByVal formStatus As FormStateEnum)
            MyBase.EnableDisableControls(formStatus)

            Select Case formStatus
                Case FormStateEnum.View
                    Me.senderComboBox.Enabled = False
                    Me.shippingCompanyComboBox.Enabled = False And (Not Me.IsShippingNotRequired)
                    Me.shippingMethodComboBox.Enabled = False And (Not Me.IsShippingNotRequired)
                    Me.trackNumberTextBox.Enabled = False And (Not Me.IsShippingNotRequired)
                    Me.printedWeightTextBox.Enabled = False And (Not Me.IsShippingNotRequired)
                    Me.actualWeightTextBox.Enabled = False And (Not Me.IsShippingNotRequired)
                    Me.packageTypeComboBox.Enabled = False And (Not Me.IsShippingNotRequired)
                    Me.packageAssignmentComboBox.Enabled = False
                    Me.printLabelButton.Enabled = True
                    Me.checkInButton.Enabled = False
                    Me.deleteButton.Enabled = False

                Case FormStateEnum.Insert
                    Me.senderComboBox.Enabled = True
                    Me.shippingCompanyComboBox.Enabled = True And (Not Me.IsShippingNotRequired)
                    Me.shippingMethodComboBox.Enabled = True And (Not Me.IsShippingNotRequired)
                    Me.trackNumberTextBox.Enabled = True And (Not Me.IsShippingNotRequired)
                    Me.printedWeightTextBox.Enabled = True And (Not Me.IsShippingNotRequired)
                    Me.actualWeightTextBox.Enabled = True And (Not Me.IsShippingNotRequired)
                    Me.packageTypeComboBox.Enabled = True And (Not Me.IsShippingNotRequired)
                    Me.packageAssignmentComboBox.Enabled = True
                    Me.printLabelButton.Enabled = False
                    Me.checkInButton.Enabled = True
                    Me.deleteButton.Enabled = False

                Case FormStateEnum.Edit
                    Me.senderComboBox.Enabled = True
                    Me.shippingCompanyComboBox.Enabled = True And (Not Me.IsShippingNotRequired)
                    Me.shippingMethodComboBox.Enabled = True And (Not Me.IsShippingNotRequired)
                    Me.trackNumberTextBox.Enabled = True And (Not Me.IsShippingNotRequired)
                    Me.printedWeightTextBox.Enabled = True And (Not Me.IsShippingNotRequired)
                    Me.actualWeightTextBox.Enabled = True And (Not Me.IsShippingNotRequired)
                    Me.packageTypeComboBox.Enabled = True And (Not Me.IsShippingNotRequired)
                    Me.packageAssignmentComboBox.Enabled = True
                    Me.printLabelButton.Enabled = True
                    Me.checkInButton.Enabled = True
                    Me.deleteButton.Enabled = True
            End Select

        End Sub

        ''' <summary>
        ''' Clears all inputs on form.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Overrides Sub RemoveAllErrorProviders()
            MyBase.RemoveAllErrorProviders()

            Me.RemoveErrorProvider(senderComboBox)
            Me.RemoveErrorProvider(shippingCompanyComboBox)
            Me.RemoveErrorProvider(shippingMethodComboBox)
            Me.RemoveErrorProvider(trackNumberTextBox)
            Me.RemoveErrorProvider(printedWeightTextBox)
            Me.RemoveErrorProvider(actualWeightTextBox)
            Me.RemoveErrorProvider(packageTypeComboBox)
            Me.RemoveErrorProvider(packageAssignmentComboBox)

        End Sub


#Region " IForm Implementation "


        Public Event FormInitialized() Implements IForm.FormInitialized
        Public Event InitializingForm() Implements IForm.InitializingForm

        Public Event ApplyingUserCredentials() Implements IForm.ApplyingUserCredentials
        Public Event UserCredentialsApplied() Implements IForm.UserCredentialsApplied


        Public Sub ApplyUserCredentials() Implements IForm.ApplyUserCredentials
            Dim rowCounter As Integer
            Dim appUser As Processors.ApplicationUser


            RaiseEvent ApplyingUserCredentials()

            appUser = New Processors.ApplicationUser
            appUser.Initialize()
            appUser.GetFunctionalityListFor(appUser.UserID, Me.Name)

            With appUser.UserDataSet.UserScreensFunctionalityView
                For rowCounter = 0 To .Rows.Count - 1
                    If .Item(rowCounter).IsNull("Functionality") Then
                        checkInButton.Visible = True
                        searchEnvelopeIDGroupBox.Visible = True
                    ElseIf .Item(rowCounter).Functionality.ToUpper() = "VIEWONLY" Then
                        checkInButton.Visible = False
                    ElseIf .Item(rowCounter).Functionality.ToUpper() = "EDITONLY" Then
                        checkInButton.Visible = True
                        searchEnvelopeIDGroupBox.Visible = True
                    ElseIf .Item(rowCounter).Functionality.ToUpper() = "NEWONLY" Then
                        searchEnvelopeIDGroupBox.Visible = False
                    End If
                Next
            End With

            appUser = Nothing

            RaiseEvent UserCredentialsApplied()

        End Sub

        Public Sub Init(ByVal formStatus As FormStateEnum) Implements IForm.Init

            RaiseEvent InitializingForm()

            Me.SuspendLayout()

            Me.FormState = formStatus

            m_envelopeProcessor = New Processors.Envelope
            Processor.Initialize()
            Processor.PrepareForNew()

            Me.StatusMessage = "Information loaded, preparing to show loaded information on window."

            senderComboBox.DisplayMember = "Name"
            senderComboBox.ValueMember = "SenderId"
            senderComboBox.DataSource = Processor.Data.Sender
            senderComboBox.AutoCompleteSource = AutoCompleteSource.ListItems

            shippingCompanyComboBox.DisplayMember = "Descrip"
            shippingCompanyComboBox.ValueMember = "ShipperId"
            shippingCompanyComboBox.DataSource = Processor.Data.Shipper

            shippingMethodComboBox.DisplayMember = "Descrip"
            shippingMethodComboBox.ValueMember = "CodeId"
            shippingMethodComboBox.DataSource = Processor.Data.vwShippingMethod

            packageTypeComboBox.DisplayMember = "Descrip"
            packageTypeComboBox.ValueMember = "CodeId"
            packageTypeComboBox.DataSource = Processor.Data.vwPackageType

            packageAssignmentComboBox.DisplayMember = "FullName"
            packageAssignmentComboBox.ValueMember = "UserId"
            packageAssignmentComboBox.DataSource = Processor.Data.User

            ClearAllInputs()
            EnableDisableControls(formStatus)
            ShowHideControls(formStatus)

            Me.ResumeLayout(False)

            RaiseEvent FormInitialized()

        End Sub


#End Region


        Private Sub PrintBarcodeLabel(ByVal barcodeRow As MCAP.EnvelopeDataSet.EnvelopeRow)

#If DEBUG Then

            If MessageBox.Show("Do you want to print?", Application.ProductName, MessageBoxButtons.YesNo _
                               , MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No _
            Then
                Exit Sub
            End If

#End If

            Try
                Processor.PrintBarcodeLabel(barcodeRow)
            Catch ex As Exception
                Trace.TraceError("EnvelopeCheckInForm.PrintBarcodeLabel():Printing barcode label for envelope. Message=" + ex.Message _
                                 , New Object() {"Barcode label printer=", BarcodePrinterName, "DataRow=", barcodeRow})
            End Try

        End Sub


        ''' <summary>
        ''' Showing error popup to user based on error texts assigned to each column.
        ''' </summary>
        ''' <param name="envelopeRow"></param>
        ''' <remarks></remarks>
        Private Sub ShowErrors(ByVal envelopeRow As MCAP.EnvelopeDataSet.EnvelopeRow)
            Dim columnCounter As Integer
            Dim errorMessage As System.Text.StringBuilder
            Dim errorCols() As Data.DataColumn


            If envelopeRow.HasErrors = False Then Exit Sub

            errorMessage = New System.Text.StringBuilder

            If String.IsNullOrEmpty(envelopeRow.RowError) = False Then
                errorMessage.Append(envelopeRow.RowError)
            Else
                errorCols = envelopeRow.GetColumnsInError()

                errorMessage.Append("Invalid inputs found.")
                errorMessage.Append(Environment.NewLine)
                For columnCounter = 0 To errorCols.Length - 1
                    errorMessage.Append(Environment.NewLine)
                    errorMessage.Append(errorCols(columnCounter).Caption)
                    errorMessage.Append(" - ")
                    errorMessage.Append(envelopeRow.GetColumnError(errorCols(columnCounter)))
                Next

                System.Array.Clear(errorCols, 0, errorCols.Length)
            End If

            MessageBox.Show(errorMessage.ToString(), Application.ProductName, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)

            errorMessage = Nothing
            errorCols = Nothing

        End Sub


        ''' <summary>
        ''' Validates user inputs. 
        ''' </summary>
        ''' <returns>True if all inputs are valid, false otherwise.</returns>
        ''' <remarks>
        ''' This method validates user inputs for its values only and not against 
        ''' any kind of business rules or anything else. For example, if date
        ''' value is expected, it checks whether its valid date or not. But does 
        ''' not check whether its within valid range or not.
        ''' </remarks>
        Private Function AreInputsValid() As Boolean
            Dim areAllValid As Boolean
            Dim tempWeight As Double


            areAllValid = True

            If senderComboBox.SelectedValue Is Nothing _
              OrElse senderComboBox.SelectedIndex < 0 _
              OrElse senderComboBox.Text.Length = 0 _
            Then
                SetErrorProvider(senderComboBox, "Select sender.")
                areAllValid = False
            Else
                RemoveErrorProvider(senderComboBox)
            End If

            If shippingCompanyComboBox.Enabled _
              AndAlso (shippingCompanyComboBox.SelectedValue Is Nothing _
              OrElse shippingCompanyComboBox.SelectedIndex < 0 _
              OrElse shippingCompanyComboBox.Text.Length = 0) _
            Then
                SetErrorProvider(shippingCompanyComboBox, "Select shipping company.")
                areAllValid = False
            Else
                RemoveErrorProvider(shippingCompanyComboBox)
            End If

            If shippingMethodComboBox.Enabled _
              AndAlso (shippingMethodComboBox.SelectedValue Is Nothing _
              OrElse shippingMethodComboBox.SelectedIndex < 0 _
              OrElse shippingMethodComboBox.Text.Length = 0) _
            Then
                SetErrorProvider(shippingMethodComboBox, "Select shipping method.")
                areAllValid = False
            Else
                RemoveErrorProvider(shippingMethodComboBox)
            End If

            If printedWeightTextBox.Enabled _
                AndAlso Double.TryParse("0" + printedWeightTextBox.Text.Trim(), tempWeight) = False _
            Then
                SetErrorProvider(printedWeightTextBox, "Provide printed weight in required format.")
                areAllValid = False
            ElseIf printedWeightTextBox.Enabled AndAlso tempWeight < 0.1 Then
                SetErrorProvider(printedWeightTextBox, "Printed weight cannot be zero.")
                areAllValid = False
            ElseIf tempWeight > 999.9 Then
                SetErrorProvider(printedWeightTextBox, "Maximum allowed value is 999.9.")
                areAllValid = False
            Else
                RemoveErrorProvider(printedWeightTextBox)
            End If

            'If actualWeightTextBox.Enabled _
            '    AndAlso Double.TryParse("0" + actualWeightTextBox.Text.Trim(), tempWeight) = False _
            'Then
            '    SetErrorProvider(actualWeightTextBox, "Provide actual weight in required format.")
            '    areAllValid = False
            'ElseIf actualWeightTextBox.Enabled AndAlso tempWeight < 0.1 Then
            '    SetErrorProvider(actualWeightTextBox, "Actual weight cannot be zero.")
            '    areAllValid = False
            'ElseIf tempWeight > 999.9 Then
            '    SetErrorProvider(actualWeightTextBox, "Maximum allowed value is 999.9.")
            '    areAllValid = False
            'Else
            '    RemoveErrorProvider(actualWeightTextBox)
            'End If

            If packageTypeComboBox.Enabled _
              AndAlso (packageTypeComboBox.SelectedValue Is Nothing _
              OrElse packageTypeComboBox.SelectedIndex < 0 _
              OrElse packageTypeComboBox.Text.Length = 0) _
            Then
                SetErrorProvider(packageTypeComboBox, "Select package type.")
                areAllValid = False
            Else
                RemoveErrorProvider(packageTypeComboBox)
            End If

            'If packageAssignmentComboBox.SelectedValue Is Nothing _
            '  OrElse packageAssignmentComboBox.SelectedIndex < 0 _
            '  OrElse packageAssignmentComboBox.Text.Length = 0 _
            'Then
            '    SetErrorProvider(packageAssignmentComboBox, "Select package assignment.")
            '    areAllValid = False
            'Else
            '    RemoveErrorProvider(packageAssignmentComboBox)
            'End If

            If trackNumberTextBox.Text Is Nothing _
          OrElse trackNumberTextBox.Text.Length = 0 _
          And m_shippingNotRequired = False _
          And m_NeedTrackingNo = True _
            Then
                SetErrorProvider(trackNumberTextBox, "Enter a Tracking Number.")
                areAllValid = False
            Else
                RemoveErrorProvider(trackNumberTextBox)
            End If

            Return areAllValid

        End Function

        ''' <summary>
        ''' Sets column values of supplied row.
        ''' </summary>
        ''' <param name="tempRow"></param>
        ''' <remarks></remarks>
        Private Sub SetColumnValues(ByVal tempRow As EnvelopeDataSet.EnvelopeRow)

            tempRow.BeginEdit()
            tempRow.SenderId = CType(senderComboBox.SelectedValue, Integer)
            If shippingCompanyComboBox.SelectedValue Is Nothing Then
                tempRow.SetShipperIdNull()
            Else
                tempRow.ShipperId = CType(shippingCompanyComboBox.SelectedValue, Integer)
            End If
            If shippingMethodComboBox.SelectedValue Is Nothing Then
                tempRow.SetShippingMethodIdNull()
            Else
                tempRow.ShippingMethodId = CType(shippingMethodComboBox.SelectedValue, Integer)
            End If
            If trackNumberTextBox.Text.Trim().Length = 0 Then
                tempRow.SetTrackingNoNull()
            Else
                tempRow.TrackingNo = trackNumberTextBox.Text
            End If
            If printedWeightTextBox.Text.Trim().Length = 0 Then
                tempRow.SetListedWeightNull()
            Else
                tempRow.ListedWeight = CType(printedWeightTextBox.Text, Double)
            End If
            If actualWeightTextBox.Text.Trim().Length = 0 Then
                tempRow.SetActualWeightNull()
            Else
                tempRow.ActualWeight = CType(actualWeightTextBox.Text, Double)
            End If
            If packageTypeComboBox.SelectedValue Is Nothing Then
                tempRow.IsPackageTypeIdNull()
            Else
                tempRow.PackageTypeId = CType(packageTypeComboBox.SelectedValue, Integer)
            End If
            tempRow.PackageAssignmentId = CType(packageAssignmentComboBox.SelectedValue, Integer)
            tempRow.FormName = FORM_NAME
            If Me.FormState = FormStateEnum.Insert Then
                'All such dates are going to be system date on database server and not 
                'the system date of user's machine.
                'tempRow.ReceivedDt = CType(receivedDateValueLabel.Text, DateTime)
                tempRow.ReceivedById = Processor.UserID
            End If
            tempRow.EndEdit()

        End Sub



        Private Sub closeButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles closeButton.Click
            isClosedByButton = True
            Me.Close()

        End Sub

        Private Sub clearButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles clearButton.Click

            Processor.PrepareForNew()

            ClearAllInputs()
            RemoveAllErrorProviders()

            Me.FormState = FormStateEnum.Insert

            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

        End Sub

        Private Sub senderFilterButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles senderFilterButton.Click
            Dim userResponse As DialogResult
            Dim filterHelp As UI.SenderSelectionHelpForm


            filterHelp = New SenderSelectionHelpForm()

            filterHelp.Text = "Sender Selection Help"
            filterHelp.Initialize(New System.Data.DataView(Processor.Data.Sender.Copy()) _
                                  , senderComboBox.DisplayMember, senderComboBox.ValueMember)
            userResponse = filterHelp.ShowDialog(Me)

            If userResponse = Windows.Forms.DialogResult.OK Then
                If CType(filterHelp.filterComboBox.SelectedValue, Integer) > 0 Then
                    senderComboBox.SelectedValue = filterHelp.filterComboBox.SelectedValue
                Else
                    MsgBox("Invalid Sender, Record not Found.", MsgBoxStyle.Information, "MCAP")
                    senderComboBox.SelectedValue = -1
                End If
            End If

            filterHelp.Dispose()
            filterHelp = Nothing

            If senderComboBox.Enabled Then
                senderComboBox.Focus()
            Else
                searchEnvelopeIDTextBox.Focus()
            End If

        End Sub

        Private Sub senderComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles senderComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub senderComboBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles senderComboBox.KeyUp

            If e.KeyCode = Keys.F12 AndAlso e.Alt = False AndAlso e.Shift = False AndAlso e.Control = False Then
                senderFilterButton.PerformClick()
            End If

        End Sub

        Private Sub senderComboBox_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles senderComboBox.SelectedIndexChanged
            Dim senderId As Integer, defaultPkgAssignee As Integer?


            If senderComboBox.SelectedValue Is Nothing Then
                commentsTextBox.Clear()
                Exit Sub
            End If

            If Integer.TryParse(senderComboBox.SelectedValue.ToString(), senderId) = False Then
                senderId = 0
            End If

            m_shippingNotRequired = Not Processor.IsShippingInformationNeeded(senderId)
            commentsTextBox.Text = Processor.GetCommentsForSender(senderId)
            defaultPkgAssignee = Processor.GetDefaultPackageAssignee(senderId)
            If defaultPkgAssignee.HasValue Then
                packageAssignmentComboBox.SelectedValue = defaultPkgAssignee.Value
            Else
                packageAssignmentComboBox.SelectedValue = DBNull.Value
            End If

            If m_shippingNotRequired = False Then
                shippingCompanyComboBox.Enabled = True
                shippingMethodComboBox.Enabled = True
                trackNumberTextBox.Enabled = True
                printedWeightTextBox.Enabled = True
                actualWeightTextBox.Enabled = True
                packageTypeComboBox.Enabled = True
            Else
                shippingCompanyComboBox.Text = String.Empty
                shippingCompanyComboBox.SelectedIndex = -1
                shippingCompanyComboBox.SelectedValue = DBNull.Value
                shippingCompanyComboBox.Enabled = False

                shippingMethodComboBox.Text = String.Empty
                shippingMethodComboBox.SelectedIndex = -1
                shippingMethodComboBox.SelectedValue = DBNull.Value
                shippingMethodComboBox.Enabled = False

                trackNumberTextBox.Text = String.Empty
                trackNumberTextBox.Enabled = False
                printedWeightTextBox.Text = String.Empty
                printedWeightTextBox.Enabled = False
                actualWeightTextBox.Text = String.Empty
                actualWeightTextBox.Enabled = False

                packageTypeComboBox.Text = String.Empty
                packageTypeComboBox.SelectedIndex = -1
                packageTypeComboBox.SelectedValue = DBNull.Value
                packageTypeComboBox.Enabled = False
            End If

        End Sub

        Private Sub shippingCompanyComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles shippingCompanyComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub shippingCompanyComboBox_SelectedValueChanged _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles shippingCompanyComboBox.SelectedValueChanged
            Dim shipperId As Integer


            If shippingCompanyComboBox.SelectedValue IsNot Nothing Then
                If Integer.TryParse(shippingCompanyComboBox.SelectedValue.ToString(), shipperId) = False Then
                    shipperId = 0
                End If

                Try
                    Processor.LoadShippingMethodList(shipperId)
                Catch ex As Exception
                    Trace.TraceError("EnvelopeCheckInForm.shippingCompanyComboBox_SelectedValueChanged():Loading shipping methods. Message=" + ex.Message _
                                     , New Object() {"ShipperId=", shipperId})
                End Try
            End If

            m_NeedTrackingNo = Processor.InNeedTrackingNo(shipperId)

            If shippingMethodComboBox.Items.Count = 1 Then
                shippingMethodComboBox.Text = String.Empty
                shippingMethodComboBox.SelectedIndex = -1
                shippingMethodComboBox.SelectedValue = DBNull.Value
                shippingMethodComboBox.SelectedItem = shippingMethodComboBox.Items(0)
            Else
                shippingMethodComboBox.Text = String.Empty
                shippingMethodComboBox.SelectedIndex = -1
                shippingMethodComboBox.SelectedValue = DBNull.Value
            End If

        End Sub

        Private Sub shippingMethodComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles shippingMethodComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub shippingMethodComboBox_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles shippingMethodComboBox.KeyPress

        End Sub

        Private Sub shippingMethodComboBox_SelectedValueChanged _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles shippingMethodComboBox.SelectedValueChanged
            Dim shipperId, shippingMethodId As Integer


            If shippingCompanyComboBox.SelectedValue IsNot Nothing _
              AndAlso shippingMethodComboBox.SelectedValue IsNot Nothing _
            Then
                If Integer.TryParse(shippingCompanyComboBox.SelectedValue.ToString(), shipperId) = False Then
                    shipperId = 0
                End If

                If Integer.TryParse(shippingMethodComboBox.SelectedValue.ToString(), shippingMethodId) = False Then
                    shipperId = 0
                End If

                Try
                    Processor.LoadPackageTypes(shipperId, shippingMethodId)
                Catch ex As Exception
                    Trace.TraceError("EnvelopeCheckInForm.shippingMethodComboBox_SelectedValueChanged():Loading package types. Message=" + ex.Message _
                                     , New Object() {"ShipperId=", shipperId, "ShippingMethodId=", shippingMethodId})
                End Try
            End If

            If shippingMethodComboBox.SelectedValue IsNot Nothing AndAlso packageTypeComboBox.Items.Count = 1 Then
                packageTypeComboBox.Text = String.Empty
                packageTypeComboBox.SelectedIndex = -1
                packageTypeComboBox.SelectedValue = DBNull.Value
                packageTypeComboBox.SelectedItem = packageTypeComboBox.Items(0)
            Else
                packageTypeComboBox.Text = String.Empty
                packageTypeComboBox.SelectedIndex = -1
                packageTypeComboBox.SelectedValue = DBNull.Value
            End If

        End Sub

        Private Sub trackNumberTextBox_Validating _
            (ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
            Handles trackNumberTextBox.Validating
            Dim messageText As System.Text.StringBuilder
            Dim trackNumberRow As EnvelopeDataSet.EnvelopeRow


            If String.IsNullOrEmpty(trackNumberTextBox.Text) Then Exit Sub

            If Regex.IsMatch(trackNumberTextBox.Text, "^[a-zA-Z]*$") Then
                MessageBox.Show("Please enter a numeric or alphanumeric value.", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                trackNumberTextBox.Text = String.Empty
                trackNumberTextBox.Focus()
            End If

            Try
                If Me.FormState = FormStateEnum.Insert Then
                    trackNumberRow = Processor.LoadByTrackNumber(trackNumberTextBox.Text)
                Else
                    Dim envelopeId As Integer = CType("0" + envelopeIDValueLabel.Text, Integer)
                    trackNumberRow = Processor.LoadByTrackNumber(trackNumberTextBox.Text, envelopeId)
                End If

            Catch ex As System.ApplicationException
                Dim userResponse As DialogResult

                userResponse = MessageBox.Show(ex.Message + Environment.NewLine + "Do you want to continue?" _
                                                , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If userResponse = Windows.Forms.DialogResult.No Then
                    e.Cancel = True
                    Exit Sub
                End If


            Catch ex As Exception
                Trace.TraceError("EnvelopeCheckInForm.trackNumberTextBox_Validating():Validating Tracking number. Message=" + ex.Message _
                                 , New Object() {"Tracking number=", trackNumberTextBox.Text, "FormState=", Me.FormState.ToString(), "EnvelopeId=", envelopeIDValueLabel.Text})
                MessageBox.Show("Unknown error has occurred while checking for Tracking Number in database." _
                                , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            End Try

            If trackNumberRow IsNot Nothing Then
                messageText = New System.Text.StringBuilder

                messageText.Append("Tracking Number ")
                messageText.Append(trackNumberTextBox.Text)
                messageText.Append(" was used previously for envelope ")
                messageText.Append(trackNumberRow.EnvelopeId.ToString())
                messageText.Append(" on ")
                messageText.Append(trackNumberRow.ReceivedDt.ToString("MM/dd/yy"))
                messageText.Append(". Please double check the Tracking Number.")

                MessageBox.Show(messageText.ToString(), ProductName, _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)

                messageText = Nothing

                trackNumberTextBox.SelectAll()
                e.Cancel = True
            End If

        End Sub

        Private Sub weightTextBox_Validated _
            (ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles printedWeightTextBox.Validated, actualWeightTextBox.Validated
            Dim weight As Double
            Dim regExp As String = "^\d{0,3}\.\d$" 'Format: 999.9
            Dim regExpression As System.Text.RegularExpressions.Regex
            Dim tempTextbox As TextBox


            tempTextbox = CType(sender, TextBox)
            RemoveErrorProvider(tempTextbox)

            If tempTextbox.Text.Trim().Length = 0 Then Exit Sub

            regExpression = New System.Text.RegularExpressions.Regex(regExp)

            If Double.TryParse(tempTextbox.Text, weight) = False Then
                SetErrorProvider(tempTextbox, "Provide valid weight.")
            ElseIf weight < 0.0 Then
                SetErrorProvider(tempTextbox, "Weight cannot be negative.")
            ElseIf weight > 999.9 Then
                SetErrorProvider(tempTextbox, "Maximum allowed value is 999.9.")
            Else
                tempTextbox.Text = weight.ToString("0.0")

                If regExpression.IsMatch(tempTextbox.Text) = False Then
                    SetErrorProvider(tempTextbox, "Provide weight in valid format(###.#).")
                End If
            End If

            If m_ErrorProvider.GetError(tempTextbox).Length > 0 Then
                tempTextbox.Focus()
                tempTextbox.SelectAll()
            End If

            tempTextbox = Nothing
            regExpression = Nothing
            regExp = Nothing

        End Sub

        Private Sub checkInButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkInButton.Click
            Dim envelopeID As Integer
            Dim tempRow As EnvelopeDataSet.EnvelopeRow


            If AreInputsValid() = False Then Exit Sub

            If FormState = FormStateEnum.Insert Then
                tempRow = Processor.CreateNew()
            Else
                envelopeID = CType(envelopeIDValueLabel.Text, Integer)
                tempRow = Processor.Data.Envelope(0)
            End If

            SetColumnValues(tempRow)

            Try
                If Me.FormState = FormStateEnum.Insert Then Processor.Add(tempRow)
                Processor.Save()
            Catch ex As System.ApplicationException
                Trace.TraceError("EnvelopeCheckInForm.checkInButton_Click():Saving Envelope. Message=" + ex.Message, New Object() {"FormState=", Me.FormState.ToString(), "DataRow=", tempRow})
                ShowErrors(tempRow)
            Catch ex As System.Exception
                Trace.TraceError("EnvelopeCheckInForm.checkInButton_Click():Saving Envelope. Message=" + ex.Message, New Object() {"FormState=", Me.FormState.ToString(), "DataRow=", tempRow})
                If Me.FormState = FormStateEnum.Insert Then
                    MessageBox.Show("Envelope record not created. Unknown error has occurred while checking-in new Envelope." + ex.Message _
                          , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Changes not saved. Unknown error has occurred while saving changes." + ex.Message _
                          , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End Try

        End Sub

        Private Sub searchEnvelopeIDTextBox_KeyPress _
            (ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
            Handles searchEnvelopeIDTextBox.KeyPress

            If Microsoft.VisualBasic.AscW(e.KeyChar) = 13 Then
                gotoButton.PerformClick()
            End If

        End Sub

        Private Sub gotoButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gotoButton.Click
            Dim envelopeID As Integer


            If Me.searchEnvelopeIDTextBox.Text.Length = 0 Then
                MessageBox.Show("Please enter an Envelope Id before searching", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If IsNumeric(searchEnvelopeIDTextBox.Text) = False Then
                MessageBox.Show("Invalid Envelope ID format. Please enter a numeric values.", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                searchEnvelopeIDTextBox.Text = String.Empty
                searchEnvelopeIDTextBox.Focus()
                Exit Sub
            End If

            envelopeID = CType(searchEnvelopeIDTextBox.Text, Integer)

            Try
                Processor.Load(envelopeID)
            Catch ex As ApplicationException
                Trace.TraceError("EnvelopeCheckInForm.gotoButton_Click():Load Envelope. Message=" + ex.Message, New Object() {"FormState=", Me.FormState.ToString(), "EnvelopeId=", envelopeID})
                MessageBox.Show(ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                Trace.TraceError("EnvelopeCheckInForm.gotoButton_Click():Load Envelope. Message=" + ex.Message, New Object() {"FormState=", Me.FormState.ToString(), "EnvelopeId=", envelopeID})
                MessageBox.Show("Cannot load Envelope. Unknown error has occurred. " _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        Private Sub printLabelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles printLabelButton.Click
            Dim envelopeId As Integer
            Dim envelopeRow As EnvelopeDataSet.EnvelopeRow


            envelopeId = CType("0" + envelopeIDValueLabel.Text, Integer)
            If envelopeId < 1 Then
                MessageBox.Show("Please load Envelope information.", ProductName, _
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If Processor.Data.Envelope.Count = 0 Then
                MessageBox.Show("Unable to find information about Envelope " + envelopeId.ToString(), _
                                ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            envelopeRow = Processor.Data.Envelope(0)
            PrintBarcodeLabel(envelopeRow)
            envelopeRow = Nothing

        End Sub

        Private Sub deleteButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles deleteButton.Click
            Dim envelopeId As Integer
            Dim userResponse As DialogResult


            If Integer.TryParse(envelopeIDValueLabel.Text, envelopeId) = False Then
                MessageBox.Show("Load Envelope to remove it.", ProductName _
                                , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            userResponse = MessageBox.Show("Are you sure you want to remove Envelope " + envelopeId.ToString() + "?" _
                                          , ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                          , MessageBoxDefaultButton.Button2)
            If userResponse = Windows.Forms.DialogResult.No Then Exit Sub

            Try
                Processor.Delete(envelopeId)
            Catch ex As Exception
                Trace.TraceError("EnvelopeCheckInForm.deleteButton_Click():Deleting envelope. Message=" + ex.Message, New Object() {"EnvelopeId=", envelopeId})
                MessageBox.Show("Unknown error has occurred while removing envelope.", _
                                ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            Me.FormState = FormStateEnum.Insert
            ClearAllInputs()
            ShowHideControls(Me.FormState)
            EnableDisableControls(Me.FormState)

        End Sub

        Private Sub EnvelopeCheckInForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If e.CloseReason = CloseReason.UserClosing And isClosedByButton = False Then
                If (MessageBox.Show("Are you sure you want to close this form?", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                    e.Cancel = True
                End If
            End If
        End Sub


        Private Sub EnvelopeCheckInForm_FormInitialized() Handles Me.FormInitialized

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub EnvelopeCheckInForm_InitializingForm() Handles Me.InitializingForm

            Me.StatusMessage = "Loading information, this may take some time. Please wait..."

        End Sub


#Region " Processor event handlers "


        Private Sub m_envelopeProcessor_BarcodePrinted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeProcessor.BarcodePrinted

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_envelopeProcessor_PrintingBarcode(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_envelopeProcessor.PrintingBarcode

            Me.StatusMessage = "Printing barcode label for envelope."

        End Sub

        Private Sub m_envelopeProcessor_FindingEnvelope(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_envelopeProcessor.FindingEnvelope

            If e.Data.Contains("EnvelopeId") Then
                Me.StatusMessage = "Finding Envelope " + e.Data("EnvelopeId").ToString() + "..."
            Else
                Me.StatusMessage = "Finding Envelope..."
            End If

        End Sub

        Private Sub m_envelopeProcessor_EnvelopeNotFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeProcessor.EnvelopeNotFound

            If e.Data.Contains("EnvelopeId") Then
                MessageBox.Show("Envelope " + e.Data("EnvelopeId").ToString() + " not found." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Envelope not found.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            searchEnvelopeIDTextBox.Focus()
            searchEnvelopeIDTextBox.SelectAll()
        End Sub

        Private Sub m_envelopeProcessor_EnvelopeFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeProcessor.EnvelopeFound
            Dim tempRow As EnvelopeDataSet.EnvelopeRow


            If e.Data.Contains("EnvelopeRow") = False Then
                MessageBox.Show("Envelope found but unable to load envelope information.", _
                                ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Me.StatusMessage = "Envelope found. Loading envelope information..."

            tempRow = CType(e.Data("EnvelopeRow"), EnvelopeDataSet.EnvelopeRow)

            ClearAllInputs()
            RemoveAllErrorProviders()

            Me.SuspendLayout()
            envelopeIDValueLabel.Text = tempRow.EnvelopeId.ToString()
            senderComboBox.SelectedValue = tempRow.SenderId
            If tempRow.IsShipperIdNull() Then
                shippingCompanyComboBox.SelectedValue = DBNull.Value
            Else
                shippingCompanyComboBox.SelectedValue = tempRow.ShipperId
                Processor.LoadShippingMethodList(tempRow.ShipperId)
            End If
            If tempRow.IsShippingMethodIdNull() Then
                shippingMethodComboBox.SelectedValue = DBNull.Value
            Else
                shippingMethodComboBox.SelectedValue = tempRow.ShippingMethodId
            End If
            If tempRow.IsTrackingNoNull() Then
                trackNumberTextBox.Clear()
            Else
                trackNumberTextBox.Text = tempRow.TrackingNo
            End If
            If tempRow.IsListedWeightNull() Then
                printedWeightTextBox.Clear()
            Else
                printedWeightTextBox.Text = tempRow.ListedWeight.ToString("0.0")
            End If
            If tempRow.IsActualWeightNull() Then
                actualWeightTextBox.Clear()
            Else
                actualWeightTextBox.Text = tempRow.ActualWeight.ToString("0.0")
            End If
            If tempRow.IsPackageTypeIdNull() Then
                packageTypeComboBox.SelectedValue = DBNull.Value
            Else
                Processor.LoadPackageTypes(tempRow.ShipperId, tempRow.ShippingMethodId)
                packageTypeComboBox.SelectedValue = tempRow.PackageTypeId
            End If
            packageAssignmentComboBox.SelectedValue = tempRow.PackageAssignmentId
            receivedDateValueLabel.Text = tempRow.ReceivedDt.ToString("MM/dd/yy hh:mm:ss tt")
            receivedByValueLabel.Text = Processor.GetUserFullName(tempRow.ReceivedById)
            Me.ResumeLayout(False)

            tempRow = Nothing

            If e.Data("EnvelopeReceiverLocation").ToString() = Processor.UserLocation Then
                Me.FormState = FormStateEnum.Edit
            Else
                Me.FormState = FormStateEnum.View
                MessageBox.Show("Envelope was checked-in at " + e.Data("EnvelopeReceiverLocation").ToString() _
                                + ". Please have an operator from " + e.Data("EnvelopeReceiverLocation").ToString() _
                                + " make any changes necessary.", ProductName, MessageBoxButtons.OK _
                                , MessageBoxIcon.Information)
            End If

            EnableDisableControls(Me.FormState)
            ShowHideControls(Me.FormState)

            If e.Data("IsVehiclesCreated").ToString() = "True" OrElse Me.FormState = FormStateEnum.View Then
                senderComboBox.Enabled = False
            Else
                senderComboBox.Enabled = True
            End If

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_envelopeProcessor_NoChangesToSynchronize(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeProcessor.NoChangesToSynchronize

            Me.StatusMessage = String.Empty

            MessageBox.Show("Did not detect any changes to save.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Sub

        Private Sub m_envelopeProcessor_SynchronizingEnvelope(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_envelopeProcessor.SynchronizingEnvelope
            Dim userResponse As DialogResult
            Dim changesDataTable As Data.DataTable


            If e.Data.Contains("Changes") Then
                changesDataTable = CType(e.Data("Changes"), System.Data.DataTable)

                If changesDataTable.Rows.Count > 0 AndAlso Me.FormState = FormStateEnum.Insert Then
                    userResponse = Windows.Forms.DialogResult.Yes
                ElseIf changesDataTable.Rows.Count > 0 AndAlso Me.FormState = FormStateEnum.Edit Then
                    userResponse = MessageBox.Show("Are you sure you want to update Envelope information?", ProductName _
                                                   , MessageBoxButtons.YesNo, MessageBoxIcon.Question _
                                                   , MessageBoxDefaultButton.Button2)
                End If
            End If

            If userResponse = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            Else
                Me.StatusMessage = "Saving envelope information. Please wait..."
            End If

        End Sub

        Private Sub m_envelopeProcessor_EnvelopeSynchronized(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeProcessor.EnvelopeSynchronized
            Dim envelopeId As String
            Dim changesDataTable As Data.DataTable


            Me.StatusMessage = String.Empty

            If e.Data.Contains("Changes") Then
                changesDataTable = CType(e.Data("Changes"), System.Data.DataTable)

                If changesDataTable.Rows.Count > 0 AndAlso Me.FormState = FormStateEnum.Edit Then
                    MessageBox.Show("Envelope " + changesDataTable.Rows(0).Item("EnvelopeId").ToString() _
                                    + " updated successfully.", ProductName, MessageBoxButtons.OK _
                                    , MessageBoxIcon.Information)
                    envelopeId = changesDataTable.Rows(0).Item("EnvelopeId").ToString()

                ElseIf changesDataTable.Rows.Count > 0 AndAlso Me.FormState = FormStateEnum.Insert Then
                    Dim tempRow As EnvelopeDataSet.EnvelopeRow = CType(changesDataTable.Rows(0), EnvelopeDataSet.EnvelopeRow)

                    envelopeId = tempRow.EnvelopeId.ToString()
                    envelopeIDValueLabel.Text = envelopeId
                    PrintBarcodeLabel(tempRow)
                    tempRow = Nothing
                End If

                ClearAllInputs()
                Me.FormState = FormStateEnum.Insert
                EnableDisableControls(Me.FormState)
                Processor.Data.Envelope.Rows.Clear()
                searchEnvelopeIDTextBox.Text = envelopeId
                senderComboBox.Focus()
                changesDataTable = Nothing
            End If

        End Sub

        Private Sub m_envelopeProcessor_ValidatingInputs(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_envelopeProcessor.ValidatingColumnValues

            Me.StatusMessage = "Validating inputs..."

        End Sub

        Private Sub m_envelopeProcessor_InvalidInputFound(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeProcessor.InvalidColumnValueFound
            Dim tempRow As EnvelopeDataSet.EnvelopeRow


            Me.StatusMessage = String.Empty

            tempRow = CType(e.Data("ValidateRow"), EnvelopeDataSet.EnvelopeRow)

            ShowErrors(tempRow)

            tempRow = Nothing
        End Sub

        Private Sub m_envelopeProcessor_InputsValidated(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeProcessor.ColumnValuesValidated

            Me.StatusMessage = String.Empty

        End Sub

        Private Sub m_envelopeProcessor_DeletingEnvelope(ByVal sender As Object, ByVal e As Processors.CancellableEventArgs) Handles m_envelopeProcessor.DeletingEnvelope
            Dim isVehicleCreated As Boolean
            Dim locationName As String


            isVehicleCreated = CType(e.Data("IsVehicleCreated"), Boolean)
            locationName = e.Data("EnvelopeReceiverLocation").ToString()

            If User.Location <> locationName Then
                MessageBox.Show("Envelope was received in " + locationName + ". Cannot remove envelope." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
                Exit Sub
            End If

            If isVehicleCreated Then
                MessageBox.Show("Cannot remove envelope. There exists vehicles created from this envelope." _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
                Exit Sub
            End If

        End Sub

        Private Sub m_envelopeProcessor_EnvelopeDeleted(ByVal sender As Object, ByVal e As Processors.EventArgs) Handles m_envelopeProcessor.EnvelopeDeleted

            MessageBox.Show("Envelope " + e.Data("EnvelopeId").ToString() + " removed successfully." _
                            , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Sub


#End Region



        Private Sub trackNumberTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackNumberTextBox.TextChanged

        End Sub

        Private Sub shippingCompanyComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles shippingCompanyComboBox.SelectedIndexChanged

        End Sub

        Private Sub shippingMethodComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles shippingMethodComboBox.SelectedIndexChanged

        End Sub

        Private Sub packageTypeComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles packageTypeComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub packageTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles packageTypeComboBox.SelectedIndexChanged

        End Sub

        Private Sub packageAssignmentComboBox_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles packageAssignmentComboBox.KeyDown
            If e.Modifiers = Keys.Control And e.KeyCode = Keys.C Then
                e.SuppressKeyPress = True
                Clipboard.SetDataObject(CType(ActiveControl, ComboBox).Text)
            End If
        End Sub

        Private Sub packageAssignmentComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles packageAssignmentComboBox.SelectedIndexChanged

        End Sub

        Private Sub EnvelopeCheckInForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub
    End Class


End Namespace