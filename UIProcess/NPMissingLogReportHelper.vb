Public Class NPMissingLogReportHelper


  Private m_data As System.Data.DataTable


  ''' <summary>
  ''' Default constructor.
  ''' </summary>
  ''' <remarks></remarks>
  Sub New()

    'Default constructor.

  End Sub



  ''' <summary>
  ''' Gets Data to prepare report.
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private ReadOnly Property Data() As System.Data.DataTable
    Get
      Return m_data
    End Get
  End Property



#Region " Using System.Web.UI.HTMLControls "


  Private m_htmlPage As System.Web.UI.Page


  Private ReadOnly Property Page() As System.Web.UI.Page
    Get
      Return m_htmlPage
    End Get
  End Property



  ''' <summary>
  ''' Adds html header tags, including atylesheets, to document.
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function AddHeader() As String
    Dim headerText As System.Text.StringBuilder


    headerText = New System.Text.StringBuilder()
    headerText.AppendLine("<html xmlns:o=""urn:schemas-microsoft-com:office:office""")
    headerText.AppendLine("xmlns:x=""urn:schemas-microsoft-com:office:excel""")
    headerText.AppendLine("xmlns=""http://www.w3.org/TR/REC-html40"">")

    headerText.AppendLine("<head>")
    headerText.AppendLine("<meta http-equiv=Content-Type content=""text/html; charset=windows-1252"">")
    headerText.AppendLine("<meta name=ProgId content=Excel.Sheet>")
    headerText.AppendLine("<meta name=Generator content=""Microsoft Excel 11"">")
    headerText.AppendLine("<link rel=File-List href=""Book1_files/filelist.xml"">")
    headerText.AppendLine("<style id=""Book1_12227_Styles"">")
    headerText.AppendLine("<!--table")
    headerText.AppendLine("{mso-displayed-decimal-separator:""\.""; mso-displayed-thousand-separator:""\,"";}")
    headerText.AppendLine(".BlankRow{padding-top:1px; padding-right:1px; padding-left:1px; mso-ignore:padding; color:windowtext; font-size:10.0pt;	font-weight:400; font-style:normal; text-decoration:none; font-family:Arial; mso-generic-font-family:auto; mso-font-charset:0; mso-number-format:General; text-align:general; vertical-align:bottom; mso-background-source:auto; mso-pattern:auto; white-space:nowrap;}")
    headerText.AppendLine(".PriorityTitleRow{padding-top:1px; padding-right:1px; padding-left:1px; mso-ignore:padding; color:windowtext; font-size:10.0pt; font-weight:700; font-style:normal; text-decoration:none; font-family:Arial, sans-serif; mso-font-charset:0; mso-number-format:General; text-align:general; vertical-align:bottom; mso-background-source:auto; mso-pattern:auto; white-space:nowrap; height:12.75pt; width:1846pt;}")
    headerText.AppendLine(".PriorityTableHeaderRow{padding-top:1px; padding-right:1px; padding-left:1px; mso-ignore:padding; color:windowtext; font-size:10.0pt; font-weight:700; font-style:normal; text-decoration:none; font-family:Arial, sans-serif; mso-font-charset:0; mso-number-format:General; text-align:general; vertical-align:bottom; mso-background-source:auto; mso-pattern:auto; white-space:nowrap; mso-height-source:userset; height:18.0pt;}")
    headerText.AppendLine(".NewspaperColumnHeader{padding-top:1px; padding-right:1px; padding-left:1px; mso-ignore:padding; color:maroon; font-size:10.0pt; font-weight:700; font-style:italic; text-decoration:none; font-family:Arial, sans-serif; mso-font-charset:0; mso-number-format:""\@""; text-align:center; vertical-align:middle; border:.5pt solid windowtext; mso-background-source:auto; mso-pattern:auto; white-space:nowrap; mso-width-source:userset; mso-width-alt:11520; width:236pt;}")
    headerText.AppendLine(".SenderColumnHeader{padding-top:1px; padding-right:1px; padding-left:1px; mso-ignore:padding; color:windowtext; font-size:14.0pt; font-weight:700; font-style:normal; text-decoration:none; font-family:Arial, sans-serif; mso-font-charset:0; mso-number-format:""\@""; text-align:center; vertical-align:middle; border:.5pt solid windowtext; mso-background-source:auto; mso-pattern:auto; white-space:nowrap; mso-width-source:userset; mso-width-alt:5924;width:122pt;}")
    headerText.AppendLine(".DateColumnHeader{padding-top:1px; padding-right:1px; padding-left:1px; mso-ignore:padding; color:windowtext; font-size:14.0pt; font-weight:700; font-style:normal; text-decoration:none; font-family:Arial, sans-serif; mso-font-charset:0; mso-number-format:""\@""; text-align:center; vertical-align:middle; border:.5pt solid windowtext; mso-background-source:auto; mso-pattern:auto; white-space:nowrap; border-left:none; width:850pt;}")
    headerText.AppendLine(".AlternateDataRow_NewspaperColumn{padding-top:1px; padding-right:1px; padding-left:1px; mso-ignore:padding; color:windowtext; font-size:10.0pt; font-weight:400; font-style:normal; text-decoration:none; font-family:Arial; mso-generic-font-family:auto; mso-font-charset:0; mso-number-format:""\@""; text-align:general; vertical-align:bottom; border:.5pt solid windowtext; background:silver; mso-pattern:auto none; white-space:nowrap; mso-width-source:userset; mso-width-alt:11520; width:236pt; border-top:none;}")
    headerText.AppendLine(".AlternateDataRow_SenderColumn{padding-top:1px; padding-right:1px; padding-left:1px; mso-ignore:padding; color:windowtext; font-size:10.0pt; font-weight:400; font-style:normal; text-decoration:none; font-family:Arial; mso-generic-font-family:auto; mso-font-charset:0; mso-number-format:""\@""; text-align:general; vertical-align:bottom; border:.5pt solid windowtext; background:silver; mso-pattern:auto none; white-space:nowrap; mso-width-source:userset; mso-width-alt:5924;width:122pt; border-top:none;}")
    headerText.AppendLine(".AlternateDataRow{padding-top:1px; padding-right:1px; padding-left:1px; mso-ignore:padding; color:windowtext; font-size:10.0pt; font-weight:400; font-style:normal; text-decoration:none; font-family:Arial; mso-generic-font-family:auto; mso-font-charset:0; mso-number-format:""\@""; text-align:general; vertical-align:bottom; border:.5pt solid windowtext; background:silver; mso-pattern:auto none; white-space:nowrap; border-top:none; border-left:none; width:850pt;}")
    headerText.AppendLine(".DataRow_NewspaperColumn{padding-top:1px; padding-right:1px; padding-left:1px; mso-ignore:padding; color:windowtext; font-size:10.0pt; font-weight:400; font-style:normal; text-decoration:none; font-family:Arial; mso-generic-font-family:auto; mso-font-charset:0; mso-number-format:""\@""; text-align:general; vertical-align:bottom; border:.5pt solid windowtext; mso-background-source:auto; mso-pattern:auto; white-space:nowrap; mso-width-source:userset; mso-width-alt:11520; width:236pt; border-top:none;}")
    headerText.AppendLine(".DataRow_SenderColumn{padding-top:1px; padding-right:1px; padding-left:1px; mso-ignore:padding; color:windowtext; font-size:10.0pt; font-weight:400; font-style:normal; text-decoration:none; font-family:Arial; mso-generic-font-family:auto; mso-font-charset:0; mso-number-format:""\@""; text-align:general; vertical-align:bottom; border:.5pt solid windowtext; background:silver; mso-pattern:auto none; white-space:nowrap; mso-width-source:userset; mso-width-alt:5924;width:122pt; border-top:none;}")
    headerText.AppendLine(".DataRow{padding-top:1px; padding-right:1px; padding-left:1px; mso-ignore:padding; color:windowtext; font-size:10.0pt; font-weight:400;  font-style:normal; text-decoration:none; font-family:Arial; mso-generic-font-family:auto; mso-font-charset:0; mso-number-format:""\@""; text-align:general; vertical-align:bottom; border:.5pt solid windowtext; mso-background-source:auto; mso-pattern:auto; white-space:nowrap; border-top:none; border-left:none; width:850pt;}")  'width:1610pt;
    headerText.AppendLine("-->")
    headerText.AppendLine("TABLE{BORDER-COLLAPSE: collapse; TABLE-LAYOUT: fixed; BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px; MARGIN: 0px; PADDING-RIGHT: 0px; PADDING-TOP: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; WIDTH: 1846pt;}")
    headerText.AppendLine("</style>")
    headerText.AppendLine("</head>")

    Return headerText.ToString()

  End Function

  ''' <summary>
  ''' Creates priority table for newspapers and fills it with supplied data.
  ''' </summary>
  ''' <param name="htmlDoc"></param>
  ''' <param name="priorityData"></param>
  ''' <remarks></remarks>
  Private Sub CreatePriorityTable(ByVal htmlDoc As System.Web.UI.Page, ByVal priorityTitle As String, ByVal priorityData As System.Data.DataView)
    Dim rowColor As Boolean
    Dim reportCols As Integer
    Dim stylesheetClass As String
    Dim priorityTable As System.Web.UI.HtmlControls.HtmlTable
    Dim tempRow As System.Web.UI.HtmlControls.HtmlTableRow
    Dim tempCell As System.Web.UI.HtmlControls.HtmlTableCell


    reportCols = priorityData.Table.Columns.Count
    priorityTable = CType(Page.FindControl("priorityTable"), System.Web.UI.HtmlControls.HtmlTable)

    If Page.FindControl("priorityTable") Is Nothing Then
      priorityTable = New System.Web.UI.HtmlControls.HtmlTable()
      priorityTable.ID = "priorityTable"
    End If

    tempRow = New System.Web.UI.HtmlControls.HtmlTableRow()
    tempRow.Attributes.Add("class", "PriorityTitleRow")
    priorityTable.Rows.Add(tempRow)

    tempCell = New System.Web.UI.HtmlControls.HtmlTableCell()
    tempRow.Cells.Add(tempCell)
    tempCell.Attributes.Add("colspan", (reportCols - 1).ToString())
    tempCell.InnerText = priorityTitle

    'Header Row
    tempRow = New System.Web.UI.HtmlControls.HtmlTableRow()
    tempRow.Attributes.Add("class", "PriorityTableHeaderRow")
    priorityTable.Rows.Add(tempRow)

    For i As Integer = 1 To reportCols - 1
      tempCell = New System.Web.UI.HtmlControls.HtmlTableCell()

      tempRow.Cells.Add(tempCell)
      tempCell.InnerText = priorityData.Table.Columns(i).ColumnName
      If i = 1 Then
                tempCell.Attributes.Add("class", "NewspaperColumnHeader")
            ElseIf i = 1 AndAlso tempCell.InnerText.ToUpper() = "Published On" Then
                tempCell.Attributes.Add("class", "PublishedOnColumnHeader")
      ElseIf i = 2 AndAlso tempCell.InnerText.ToUpper() = "SENDER" Then
        tempCell.Attributes.Add("class", "SenderColumnHeader")
      Else
        tempCell.Attributes.Add("class", "DateColumnHeader")
      End If

      tempCell = Nothing
    Next

    'Report Rows
    For j As Integer = 0 To priorityData.Count - 1
      tempRow = New System.Web.UI.HtmlControls.HtmlTableRow()
      priorityTable.Rows.Add(tempRow)

      If rowColor Then
        stylesheetClass = "DataRow"
      Else
        stylesheetClass = "AlternateDataRow"
      End If

      For i As Integer = 1 To reportCols - 1
        tempCell = New System.Web.UI.HtmlControls.HtmlTableCell()
        tempRow.Cells.Add(tempCell)

        If i = 1 Then
          tempCell.Attributes.Add("class", stylesheetClass + "_NewspaperColumn")
        ElseIf i = 2 AndAlso tempCell.InnerText.ToUpper() = "SENDER" Then
          tempCell.Attributes.Add("class", "_SenderColumn")
        Else
          tempCell.Attributes.Add("class", stylesheetClass)
        End If

        If priorityData(j).Item(i) Is DBNull.Value Then
          tempCell.InnerHtml = "&nbsp;"
        Else
          tempCell.InnerText = priorityData(j).Item(i).ToString()
          tempCell.InnerHtml = tempCell.InnerText.Replace("(R)", "<FONT color='blue'>(R)</FONT>")
          tempCell.InnerHtml = tempCell.InnerText.Replace("(P)", "<FONT color='brown'>(P)</FONT>")
        End If
      Next

      rowColor = Not rowColor
    Next

    'Blank Row
    tempRow = New System.Web.UI.HtmlControls.HtmlTableRow()
    priorityTable.Rows.Add(tempRow)
    tempRow.Attributes.Add("class", "BlankRow")
    For i As Integer = 1 To reportCols - 1
      tempCell = New System.Web.UI.HtmlControls.HtmlTableCell()
      tempRow.Cells.Add(tempCell)
      tempCell.InnerHtml = "&nbsp;"
      tempCell = Nothing
    Next

    Page.Controls.Add(priorityTable)

  End Sub

  ''' <summary>
  ''' Prepares report in HTML format and writes it to disk.
  ''' </summary>
  ''' <param name="reportData"></param>
  ''' <param name="reportFilePath">Absolute path of file.</param>
  ''' <remarks></remarks>
  Public Sub PrepareReport(ByVal reportData As System.Data.DataTable, ByVal priorityTitle As String, ByVal reportFilePath As String)
    Dim priorityHeader As String
    Dim priorityView As System.Data.DataView


    m_data = reportData
    m_htmlPage = New System.Web.UI.Page()
    priorityView = New System.Data.DataView(Me.Data)

    For i As Integer = 1 To 10
      priorityView.RowFilter = "Priority=" + i.ToString()
      priorityHeader = priorityTitle.Replace("#Priority#", i.ToString())
      CreatePriorityTable(Page, priorityHeader, priorityView)

      priorityHeader = Nothing
    Next

    priorityView.Dispose()
    priorityView = Nothing

    WriteToFile(Page, reportFilePath)

    Page.Dispose()
    m_htmlPage = Nothing
    m_data = Nothing

  End Sub

  ''' <summary>
  ''' Writes supplied document to specified file.
  ''' </summary>
  ''' <param name="reportDoc"></param>
  ''' <param name="filePath"></param>
  ''' <remarks></remarks>
  Private Sub WriteToFile(ByVal reportDoc As System.Web.UI.Page, ByVal filePath As String)
    Dim ws As System.IO.StreamWriter


    ws = New System.IO.StreamWriter(filePath, False)
    ws.WriteLine(AddHeader())
    Page.RenderControl(New System.Web.UI.HtmlTextWriter(ws))
    ws.Close()

    ws.Dispose()

  End Sub


#End Region



End Class
