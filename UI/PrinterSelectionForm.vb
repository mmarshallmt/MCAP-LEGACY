Namespace UI


  Public Class PrinterSelectionForm


    Private ReadOnly Property AppVarStorage() As ApplicationVariableStorage
      Get
        Return CType(Me.Owner, MCAP.UI.MDIForm).AppVar
      End Get
    End Property


    Private Function GetPrinterStatusText(ByVal printerStatus As Integer) As String
      Dim statusText As String


      Select Case printerStatus
        Case 1
          statusText = "Other"
        Case 2
          statusText = "Unknown"
        Case 3
          statusText = "Idle"
        Case 4
          statusText = "Printing"
        Case 5
          statusText = "Warming Up"
        Case 6
          statusText = "Stopped Printing"
        Case 7
          statusText = "Offline"
        Case Else
          statusText = "Unknown"
      End Select

      Return statusText

    End Function

    ''' <summary>
    ''' Refreshes list of available printers. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadPrinterList()

      Application.DoEvents()
      refreshButton.PerformClick()
      Application.DoEvents()

    End Sub

    ''' <summary>
    ''' Loads user selection from isolated storage.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadUserSelection()
      Dim printerName As String = "Unknown"


      appVarStorage.ReadFromFile()
      printerName = appVarStorage.LoadValue("BarcodePrinterName", printerName)
      Me.printerNameValueLabel.Text = printerName

      printerName = Nothing
    End Sub

    ''' <summary>
    ''' Saves user selection in isolated storage.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveUserSelection(ByVal printerName As String)

      appVarStorage.ReadFromFile()
      appVarStorage.SaveValue("BarcodePrinterName", printerName)
      appVarStorage.WriteToFile()

      SetBarcodePrinterName(printerName)
      Me.printerNameValueLabel.Text = printerName

      printerName = Nothing
    End Sub


    Private Sub refreshButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles refreshButton.Click
      Dim strComputer, printerStatus As String
      Dim tempListViewItem As ListViewItem
      Dim subItem As ListViewItem.ListViewSubItem


      statusLabel.Visible = True
      printerListView.Items.Clear()
      Me.SuspendLayout()
      LoadUserSelection()
      Application.DoEvents()

      strComputer = "."
      Dim searcher As New System.Management.ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_Printer")

      For Each queryObj As System.Management.ManagementObject In searcher.Get()
        tempListViewItem = New ListViewItem()


        tempListViewItem.Text = queryObj("Name").ToString()
        If queryObj("Default").ToString() = "True" _
            OrElse tempListViewItem.Text = Me.printerNameValueLabel.Text _
            OrElse tempListViewItem.Text = BarcodePrinterName _
        Then
          tempListViewItem.ImageKey = "DefaultPrinter.ico"
        Else
          tempListViewItem.ImageKey = "Printer.ico"
        End If

        subItem = New ListViewItem.ListViewSubItem()
        subItem.Text = queryObj("SystemName").ToString()
        tempListViewItem.SubItems.Add(subItem)
        subItem = Nothing

        If queryObj("PrinterStatus") Is Nothing Then
          printerStatus = GetPrinterStatusText(0)
        Else
          printerStatus = GetPrinterStatusText(CType("0" + queryObj("PrinterStatus").ToString(), Integer))
        End If

        subItem = New ListViewItem.ListViewSubItem()
        subItem.Text = printerStatus
        tempListViewItem.SubItems.Add(subItem)
        subItem = Nothing

        printerListView.Items.Add(tempListViewItem)

        If queryObj("Network").ToString() = "True" Then
          printerListView.Groups(1).Items.Add(tempListViewItem)
        Else
          printerListView.Groups(0).Items.Add(tempListViewItem)
        End If

        tempListViewItem = Nothing
      Next

      searcher.Dispose()
      searcher = Nothing

      statusLabel.Visible = False
      Me.ResumeLayout()
      Application.DoEvents()

    End Sub

    Private Sub okButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles okButton.Click

      If printerListView.SelectedItems.Count = 0 Then
        MessageBox.Show("You must select printer from list.", ProductName _
                        , MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.DialogResult = Windows.Forms.DialogResult.None
        Exit Sub
      End If

      Dim printerName As String = printerListView.SelectedItems(0).Text

      SaveUserSelection(printerName)
      Me.Close()

      printerName = Nothing
    End Sub

    Private Sub cancelButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cancelButton.Click

      Me.Close()

    End Sub


    Private Sub PrinterSelectionForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

  End Class


End Namespace