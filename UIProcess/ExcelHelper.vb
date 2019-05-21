''' <summary>
''' Class to help exporting data from data set to excel workbook. Separate 
''' worksheet is created for each table.
''' </summary>
''' <remarks>
''' Reference URL: http://www.codeproject.com/KB/office/ExportDataSetToExcel.aspx
''' If total number of rows(including header row) exceeds maximum number of rows 
''' allowed for excel, it creates separate worksheet and writes remaining data 
''' in it with header row. Name of such sheet is appended with count
''' , e.g. Customer, Customer1, Customer2.....
''' </remarks>
Public Class ExcelHelper


  'Row limits older Excel version per sheet
  Private Const rowLimit As Integer = 65000


  Private Shared Function getWorkbookTemplate() As String
    Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()


    sb.AppendLine("<xml version>")
    sb.AppendLine("<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"" ")
    sb.AppendLine(" xmlns:o=""urn:schemas-microsoft-com:office:office"" ")
    sb.AppendLine(" xmlns:x=""urn:schemas- microsoft-com:office:excel"" ")
    sb.AppendLine(" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet""> ")
    sb.AppendLine(" <Styles>")
    sb.AppendLine(" <Style ss:ID=""Default"" ss:Name=""Normal""> ")
    sb.AppendLine(" <Alignment ss:Vertical=""Bottom""/> ")
    sb.AppendLine(" <Borders/>")
    sb.AppendLine(" <Font/>")
    sb.AppendLine(" <Interior/>")
    sb.AppendLine(" <NumberFormat/>")
    sb.AppendLine(" <Protection/>")
    sb.AppendLine(" </Style>")
    sb.AppendLine(" <Style ss:ID=""ColumnHeader""> ")
    sb.AppendLine("    <Borders>")
    sb.AppendLine("     <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
    sb.AppendLine("     <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
    sb.AppendLine("     <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
    sb.AppendLine("     <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
    sb.AppendLine("    </Borders>")
    sb.AppendLine("    <Font x:Family=""Swiss"" ss:Bold=""1""/>")
    sb.AppendLine("    <Interior ss:Color=""#FFFF00"" ss:Pattern=""Solid""/>")
    sb.AppendLine(" </Style>")
    sb.AppendLine(" <Style ss:ID=""BoldColumn""> ")
    sb.AppendLine(" <Font x:Family=""Swiss"" ss:Bold=""1""/>")
    sb.AppendLine(" </Style>")
    sb.AppendLine(" <Style ss:ID=""s62"">")
    sb.AppendLine(" <NumberFormat ss:Format=""@""/>")
    sb.AppendLine(" </Style>")
    sb.AppendLine(" <Style ss:ID=""Decimal"">")
    sb.AppendLine(" <NumberFormat ss:Format=""0.0000""/>")
    sb.AppendLine(" </Style> ")
    sb.AppendLine(" <Style ss:ID=""Integer""> ")
    sb.AppendLine(" <NumberFormat ss:Format=""0""/> ")
    sb.AppendLine(" </Style>")
    sb.AppendLine(" <Style ss:ID=""DateLiteral""> ")
    sb.AppendLine(" <NumberFormat ss:Format=""mm/dd/yyyy;@"" /> ")
    sb.AppendLine(" </Style>")
    sb.AppendLine(" <Style ss:ID=""s28""> ")
    sb.AppendLine(" <Alignment ss:Horizontal=""Left"" ss:Vertical=""Top"" ")
    sb.AppendLine(" ss:ReadingOrder=""LeftToRight"" ss:WrapText=""1""/> ")
    sb.AppendLine(" <Font x:CharSet=""1"" ss:Size=""9"" ss:Color=""#808080"" ss:Underline=""Single""/>")
    sb.AppendLine(" <Interior ss:Color=""#FFFFFF"" ss:Pattern=""Solid""/> ")
    sb.AppendLine(" </Style>")
    sb.AppendLine(" </Styles>")
    sb.AppendLine(" {0} ")
    sb.AppendLine("</Workbook>")

    Return sb.ToString()

  End Function


  Private Shared Function replaceXmlChar(ByVal input As String) As String

    input = input.Replace("&", "&")
    input = input.Replace("<", "<")
    input = input.Replace(">", ">")
    input = input.Replace("\""", """")
    input = input.Replace("'", "&apos;")

    Return input

  End Function

  Private Shared Function getWorksheets(ByVal source As DataSet) As String
    Dim sw As System.IO.StringWriter = New System.IO.StringWriter()


    If (source Is Nothing OrElse source.Tables.Count = 0) Then
      sw.WriteLine("<Worksheet ss:Name=""Sheet1"">")
      sw.WriteLine("  <Table>")
      sw.WriteLine("    <Row>")
      sw.WriteLine("      <Cell  ss:StyleID=""s62""><Data ss:Type=""String""></Data></Cell>")
      sw.WriteLine("    </Row>")
      sw.WriteLine("  </Table>")
      sw.WriteLine("</Worksheet>")

      Return sw.ToString()
    End If

    For Each dt As DataTable In source.Tables

      If dt.Rows.Count = 0 Then
        sw.WriteLine("<Worksheet ss:Name=""" + replaceXmlChar(dt.TableName) + """>")
        sw.WriteLine("  <Table>")
        'write column name row
        sw.WriteLine("    <Row>")
        For Each dc As DataColumn In dt.Columns
          sw.WriteLine(String.Format("      <Cell ss:StyleID=""ColumnHeader""><Data ss:Type=""String"">{0}</Data></Cell>", replaceXmlChar(dc.ColumnName)))
        Next
        sw.WriteLine("    </Row>")
        sw.WriteLine("  </Table>")
        sw.WriteLine("</Worksheet>")

      Else
        'write each row data
        Dim sheetCount As Integer = 0

        For i As Integer = 0 To dt.Rows.Count - 1
          If (i Mod rowLimit) = 0 Then
            'add close tags for previous sheet of the same data table
            If (i / rowLimit) > sheetCount Then
              sw.Write("</Table></Worksheet>")
              sheetCount = i \ rowLimit
            End If
            sw.Write("<Worksheet ss:Name=""" + replaceXmlChar(dt.TableName) + IIf((i / rowLimit) = 0, "", Convert.ToString(i / rowLimit)).ToString() + """> <Table>")
            'write column name row
            sw.WriteLine("<Row>")
            For Each dc As DataColumn In dt.Columns
              sw.WriteLine(String.Format("<Cell ss:StyleID=""ColumnHeader""><Data ss:Type=""String"">{0}</Data></Cell>", replaceXmlChar(dc.ColumnName)))
            Next
            sw.WriteLine("</Row>")
          End If

          sw.WriteLine("<Row>")
          For Each dc As DataColumn In dt.Columns
            sw.WriteLine(String.Format("<Cell ss:StyleID=""s62""><Data ss:Type=""String"">{0}</Data></Cell>", replaceXmlChar(dt.Rows(i)(dc.ColumnName).ToString())))
          Next
          sw.WriteLine("</Row>")

        Next
        sw.WriteLine("</Table>")
        sw.WriteLine("  <WorksheetOptions xmlns=""urn:schemas-microsoft-com:office:excel"">")
        sw.WriteLine("    <FreezePanes/>")
        sw.WriteLine("    <FrozenNoSplit/>")
        sw.WriteLine("    <SplitHorizontal>1</SplitHorizontal>")
        sw.WriteLine("    <TopRowBottomPane>1</TopRowBottomPane>")
        sw.WriteLine("    <ActivePane>2</ActivePane>")
        sw.WriteLine("    <Panes>")
        sw.WriteLine("      <Pane>")
        sw.WriteLine("        <Number>3</Number>")
        sw.WriteLine("      </Pane>")
        sw.WriteLine("      <Pane>")
        sw.WriteLine("        <Number>2</Number>")
        sw.WriteLine("      </Pane>")
        sw.WriteLine("    </Panes>")
        sw.WriteLine("  </WorksheetOptions>")
        sw.WriteLine("</Worksheet>")
      End If

    Next

    Return sw.ToString()

  End Function


  Public Shared Function GetExcelXml(ByVal dtInput As DataTable, ByVal filename As String) As String
    Dim ds As System.Data.DataSet = New System.Data.DataSet()
    ds.Tables.Add(dtInput.Copy())

    Dim excelTemplate As String = getWorkbookTemplate()
    Dim worksheets As String = getWorksheets(ds)
    Dim excelXml As String = String.Format(excelTemplate, worksheets)

    Return excelXml
  End Function

  Public Shared Function GetExcelXml(ByVal dsInput As DataSet, ByVal filename As String) As String
    Dim excelTemplate As String = getWorkbookTemplate()
    Dim worksheets As String = getWorksheets(dsInput)
    Dim excelXml As String = String.Format(excelTemplate, worksheets)

    Return excelXml
  End Function

  'Public Shared Sub ToExcel(ByVal dsInput As DataSet, ByVal filename As String, ByVal response As System.Web.HttpResponse)
  '  Dim excelXml = GetExcelXml(dsInput, filename)


  '  response.Clear()
  '  response.AppendHeader("Content-Type", "application/vnd.ms-excel")
  '  response.AppendHeader("Content-disposition", "attachment; filename=" + filename)
  '  response.Write(excelXml)
  '  response.Flush()
  '  response.End()
  '  response.Close()

  'End Sub

  'Public Shared Sub ToExcel(ByVal dtInput As DataTable, ByVal filename As String, ByVal response As System.Web.HttpResponse)
  '  Dim ds = New DataSet()


  '  ds.Tables.Add(dtInput.Copy())
  '  ToExcel(ds, filename, response)

  'End Sub

  Public Shared Sub ToExcel(ByVal dsInput As DataSet, ByVal filename As String, ByVal response As System.IO.TextWriter)
    Dim excelXml As String = GetExcelXml(dsInput, filename)


    response.Flush()
    response.Write(excelXml)
    response.Flush()

  End Sub

  Public Shared Sub ToExcel(ByVal dtInput As DataTable, ByVal filename As String, ByVal response As System.IO.TextWriter)
    Dim ds As System.Data.DataSet = New System.Data.DataSet()


    ds.Tables.Add(dtInput.Copy())
    ToExcel(ds, filename, response)

  End Sub


End Class
