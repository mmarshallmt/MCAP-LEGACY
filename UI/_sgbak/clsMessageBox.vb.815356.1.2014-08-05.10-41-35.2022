Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Enum MessageBoxResult
    Yes
    YesToAll
    No
    NoToAll
    Cancel
End Enum
Public Class clsMessageBox

    ' Internal values
    Private lastResult As MessageBoxResult = MessageBoxResult.Cancel
    Private m_result As MessageBoxResult = MessageBoxResult.Cancel

#Region "Properties"

    Public Property LabelText() As [String]
        Get
            Return Me.labelBody.Text
        End Get
        Set(ByVal value As [String])
            Me.labelBody.Text = value
            UpdateSize()
        End Set
    End Property

    Public Property Result() As MessageBoxResult
        Get
            Return Me.m_result
        End Get
        Set(ByVal value As MessageBoxResult)
            Me.m_result = value
        End Set
    End Property

#End Region

#Region "Public Methods"
    ''' <summary>
    ''' Call this function instead of ShowDialog, to check for remembered
    ''' result.
    ''' </summary>
    ''' <returns></returns>
    Public Function ShowMessageDialog() As MessageBoxResult
        m_result = MessageBoxResult.Cancel
        If lastResult = MessageBoxResult.NoToAll Then
            m_result = MessageBoxResult.No
        ElseIf lastResult = MessageBoxResult.YesToAll Then
            m_result = MessageBoxResult.Yes
        Else
            MyBase.ShowDialog()
        End If
        Return m_result
    End Function

    Public Function ShowMessageDialog(ByVal label As [String], ByVal title As String) As MessageBoxResult
        Me.Text = title
        LabelText = label
        Return ShowMessageDialog()
    End Function
#End Region

#Region "Private Methods"

    ''' <summary>
    ''' This call updates the size of the window based on certain factors,
    ''' such as if an icon is present, and the size of label.
    ''' </summary>
    Private Sub UpdateSize()
        Dim newWidth As Integer = labelBody.Size.Width + 40

        ' Add the width of the icon, and some padding.
        If pictureBoxIcon.Image IsNot Nothing Then
            newWidth += pictureBoxIcon.Width + 20
            labelBody.Location = New Point(118, labelBody.Location.Y)
        Else
            labelBody.Location = New Point(12, labelBody.Location.Y)
        End If
        If newWidth >= 440 Then
            Me.Width = newWidth
        Else
            Me.Width = 440
        End If

        Dim newHeight As Integer = labelBody.Size.Height + 100
        If newHeight >= 200 Then
            Me.Height = newHeight
        Else
            Me.Height = 200
        End If
    End Sub

#End Region


    Private Sub buttonYes_Click(sender As Object, e As EventArgs) Handles buttonYes.Click
        m_result = MessageBoxResult.Yes
        lastResult = MessageBoxResult.Yes
        DialogResult = DialogResult.Yes
    End Sub

    Private Sub buttonYestoAll_Click(sender As Object, e As EventArgs) Handles buttonYestoAll.Click
        m_result = MessageBoxResult.Yes
        lastResult = MessageBoxResult.YesToAll
        DialogResult = DialogResult.Yes
    End Sub

    Private Sub buttonNo_Click(sender As Object, e As EventArgs) Handles buttonNo.Click
        m_result = MessageBoxResult.No
        lastResult = MessageBoxResult.No
        DialogResult = DialogResult.No
    End Sub

    Private Sub buttonNotoAll_Click(sender As Object, e As EventArgs) Handles buttonNotoAll.Click
        m_result = MessageBoxResult.No
        lastResult = MessageBoxResult.NoToAll
        DialogResult = DialogResult.No
    End Sub

    Private Sub buttonCancel_Click(sender As Object, e As EventArgs) Handles buttonCancel.Click
        m_result = MessageBoxResult.Cancel
        lastResult = MessageBoxResult.Cancel
        DialogResult = CType(MessageBoxResult.Cancel, Windows.Forms.DialogResult)
    End Sub
End Class
