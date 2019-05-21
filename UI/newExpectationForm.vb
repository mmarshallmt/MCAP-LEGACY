﻿Imports MCAP.UI

Public Class newExpectationForm
    Inherits MDIChildFormBase
    Private mprocessor As New UI.Processors.Expectation
    Private objExpectation As New BusinessLayer.clsExpectationController

    Private ReadOnly Property Processor() As Processors.Expectation
        Get
            Return mprocessor
        End Get
    End Property

    Private Sub clearForm()
        mediaComboBox.SelectedValue = -1
        retailerComboBox.SelectedValue = -1
        marketComboBox.SelectedValue = -1
        priorityCombobox.SelectedValue = -1
        FrequencyComboBox.SelectedValue = -1
        DPICombobox.SelectedValue = -1
        commentsTextBox.Text = ""
        aDlertCheckBox.Checked = False
        fVCheckBox.Checked = False
    End Sub
    Private Function AreInputsValid() As Boolean


        Dim areAllValid As Boolean


        areAllValid = True


        If mediaComboBox.SelectedValue Is Nothing Then
            areAllValid = False
            SetErrorProvider(mediaComboBox, "Provide valid Media.")
        Else
            RemoveErrorProvider(mediaComboBox)
        End If
        If retailerComboBox.SelectedValue Is Nothing Then
            areAllValid = False
            SetErrorProvider(retailerComboBox, "Provide valid Retailer.")
        Else
            RemoveErrorProvider(retailerComboBox)
        End If
        If marketComboBox.SelectedValue Is Nothing Then
            areAllValid = False
            SetErrorProvider(marketComboBox, "Provide valid Market.")
        Else
            RemoveErrorProvider(marketComboBox)
        End If

        Return areAllValid

    End Function

    Private Sub loadComboboxValues()
        '1 - for Media
        '2 - for Market
        '3 - for retailer


        Processor.loadComboBox(mediaComboBox, "mediaID", "Descrip", 1)
        mediaComboBox.SelectedValue = -1
        Processor.loadComboBox(marketComboBox, "Mktid", "Descrip", 2)
        marketComboBox.SelectedValue = -1
        Processor.loadComboBox(retailerComboBox, "retid", "Descrip", 3)
        retailerComboBox.SelectedValue = -1
        Processor.loadComboBox(priorityCombobox, "priority", "Descrip", 4)
        priorityCombobox.SelectedValue = -1
        Processor.loadComboBox(DPICombobox, "codeid", "Descrip", 5)
        DPICombobox.SelectedValue = -1
        Processor.loadComboBox(FrequencyComboBox, "codeid", "Descrip", 6)
        FrequencyComboBox.SelectedValue = -1
    End Sub

    Private Sub newExpectationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call Me.loadComboboxValues()
    End Sub

   
    Private Sub btnCreateExpectation_Click(sender As Object, e As EventArgs) Handles btnCreateExpectation.Click
        If AreInputsValid() = False Then
            Exit Sub
        End If

        Dim priority As Integer

        If priorityCombobox.SelectedValue Is Nothing Then
            priority = 0
        Else
            priority = DirectCast(priorityCombobox.SelectedItem, DatabaseLayer.clsExpectation).Priority
        End If

        Dim retid As Integer = DirectCast(retailerComboBox.SelectedItem, DatabaseLayer.clsExpectation).RetId

        Dim mktid As Integer = DirectCast(marketComboBox.SelectedItem, DatabaseLayer.clsExpectation).MktId
        Dim mediaId As Integer = DirectCast(mediaComboBox.SelectedItem, DatabaseLayer.clsExpectation).MediaId
        Dim frequencyid As Integer = DirectCast(FrequencyComboBox.SelectedItem, DatabaseLayer.clsExpectation).codeID
        Dim scanDPI As Integer = CInt(DirectCast(DPICombobox.SelectedItem, DatabaseLayer.clsExpectation).Descrip)

        Dim expectationID As Integer = 0
        Dim FVReqInd As Byte = 0
        Dim ADReqInd As Byte = 0

        objExpectation = New BusinessLayer.clsExpectationController

        If fVCheckBox.Checked = True Then
            FVReqInd = 1
        End If
        If aDlertCheckBox.Checked = True Then
            ADReqInd = 1
        End If

        objExpectation.Comments = commentsTextBox.Text
        objExpectation.Priority = priority
        objExpectation.MediaId = mediaId
        objExpectation.RetId = retid
        objExpectation.MktId = mktid
        objExpectation.FVReqInd = FVReqInd
        objExpectation.ADReqInd = ADReqInd
        objExpectation.FrequencyID = frequencyid
        objExpectation.ScanDPI = scanDPI
        objExpectation.StartDt = Now()

        expectationID = Processor.ifExpectationExist(retid, mktid, mediaId)
        objExpectation.ExpectationID = expectationID
        If expectationID = 0 Then
            If objExpectation.Insert Then
                MessageBox.Show("New Expectation was created.", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                clearForm()
            End If
        Else
            If (MessageBox.Show("A matching record was found, do you want to update record ?", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                Exit Sub
            End If
            If Processor.isExpectationEnable(expectationID) = True Then
                If (MessageBox.Show("Do you want to activate this expectation", "MCAP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No) Then
                    MessageBox.Show("Data will not be processed.", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                Else
                    Processor.UpdateExpectation(expectationID)
                End If

            End If
            If objExpectation.Update Then
                MessageBox.Show("Expectation found was updated with new info.", "MCAP", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Me.clearForm()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Hide()
    End Sub
End Class
