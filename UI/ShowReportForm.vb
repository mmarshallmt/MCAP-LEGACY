﻿Imports Excel = Microsoft.Office.Interop.Excel


Namespace UI


  Public Class ShowReportForm



    Private Const TITLE_TEXT_TEMPLATE As String = "<Report Name> Report Viewer"



    'Private m_reportName, m_reportFilePath As String
    Private m_reportName, m_reportFileResourceName As String
    Private m_parameterCollection As System.Collections.Generic.Dictionary(Of String, String)
    Private m_dataSourceCollection As System.Collections.Generic.Dictionary(Of String, Object)



    Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      m_parameterCollection = New System.Collections.Generic.Dictionary(Of String, String)
      m_dataSourceCollection = New System.Collections.Generic.Dictionary(Of String, Object)

    End Sub



    ''' <summary>
    ''' Resource name for report file. Used when report is embeded as resource.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReportFileResourceName() As String
      Get
        Return m_reportFileResourceName
      End Get
      Set(ByVal value As String)
        m_reportFileResourceName = value
      End Set
    End Property

    '''' <summary>
    '''' Gets or sets report file path.
    '''' </summary>
    '''' <value></value>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Property ReportFilePath() As String
    '  Get
    '    Return m_reportFilePath
    '  End Get
    '  Set(ByVal value As String)
    '    m_reportFilePath = value
    '  End Set
    'End Property

    ''' <summary>
    ''' Gets or sets collection of report parameters.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Parameters() As System.Collections.Generic.Dictionary(Of String, String)
      Get
        Return m_parameterCollection
      End Get
      Set(ByVal value As System.Collections.Generic.Dictionary(Of String, String))
        m_parameterCollection = value
      End Set
    End Property

    ''' <summary>
    ''' Gets or sets collection of data sources for report.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DataSources() As System.Collections.Generic.Dictionary(Of String, Object)
      Get
        Return m_dataSourceCollection
      End Get
      Set(ByVal value As System.Collections.Generic.Dictionary(Of String, Object))
        m_dataSourceCollection = value
      End Set
    End Property

    ''' <summary>
    ''' User friendly name of the report.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReportName() As String
      Get
        Return m_reportName
      End Get
      Set(ByVal value As String)
        m_reportName = value
        UpdateTitle(value)
      End Set
    End Property



    ''' <summary>
    ''' Updates title of the form.
    ''' </summary>
    ''' <param name="titleText">Name of the report which is being displayed on form.</param>
    ''' <remarks></remarks>
    Private Sub UpdateTitle(ByVal titleText As String)

      If titleText Is Nothing Then
        Me.Text = TITLE_TEXT_TEMPLATE.Replace("<Report Name>", "")
      Else
        Me.Text = TITLE_TEXT_TEMPLATE.Replace("<Report Name>", titleText)
      End If

    End Sub

    ''' <summary>
    ''' Gets array of parameter based on ReportParameters collection.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetReportParameters() As Microsoft.Reporting.WinForms.ReportParameter()
      Dim keyArray() As String
      Dim tempParameter As Microsoft.Reporting.WinForms.ReportParameter
      Dim parameterList As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)


      parameterList = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)
      keyArray = Parameters.Keys.ToArray()

      For i As Integer = 0 To keyArray.Length - 1
        tempParameter = New Microsoft.Reporting.WinForms.ReportParameter()
        tempParameter.Name = keyArray(i)
        tempParameter.Values.Add(Parameters(keyArray(i)))
        tempParameter.Visible = False

        parameterList.Add(tempParameter)

        tempParameter = Nothing
      Next

      System.Array.Clear(keyArray, 0, keyArray.Length)
      keyArray = Nothing

      Return parameterList.ToArray()

    End Function

    ''' <summary>
    ''' Gets array of parameter based on DataSources collection.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetReportDataSourceArray() As Microsoft.Reporting.WinForms.ReportDataSource()
      Dim keyArray() As String
      Dim tempDataSource As Microsoft.Reporting.WinForms.ReportDataSource
      Dim dataSourceList As System.Collections.Generic.IList(Of Microsoft.Reporting.WinForms.ReportDataSource)


      dataSourceList = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportDataSource)
      keyArray = DataSources.Keys.ToArray()

      For i As Integer = 0 To keyArray.Length - 1
        tempDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        tempDataSource.Name = keyArray(i)
        tempDataSource.Value = DataSources(keyArray(i))

        dataSourceList.Add(tempDataSource)

        tempDataSource = Nothing
      Next

      System.Array.Clear(keyArray, 0, keyArray.Length)
      keyArray = Nothing

      Return dataSourceList.ToArray()

    End Function


    ''' <summary>
    ''' Loads report in memory and sets parameters and datasources. 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub PrepareReport()
      Dim parameterArray() As Microsoft.Reporting.WinForms.ReportParameter
      Dim datasourceArray() As Microsoft.Reporting.WinForms.ReportDataSource


      parameterArray = GetReportParameters()
      datasourceArray = GetReportDataSourceArray()

      With Me.commonReportViewer
                .LocalReport.ReportEmbeddedResource = ReportFileResourceName
                .LocalReport.EnableExternalImages = True
        '.LocalReport.ReportPath = ReportFilePath
                '.LocalReport.LoadReportDefinition(New System.IO.StreamReader(ReportFilePath))

                Try
                    If parameterArray.Length > 0 Then .LocalReport.SetParameters(parameterArray)
                Catch ex As System.Exception

                    Dim inner As Exception = ex.InnerException

                    While Not (inner Is Nothing)

                        MsgBox(inner.Message)

                        inner = inner.InnerException

                    End While

                End Try
                For i As Integer = 0 To datasourceArray.Length - 1
                    .LocalReport.DataSources.Add(datasourceArray(i))
                Next
            End With

      System.Array.Clear(parameterArray, 0, parameterArray.Length)
      System.Array.Clear(datasourceArray, 0, datasourceArray.Length)

      parameterArray = Nothing
      datasourceArray = Nothing

    End Sub

    ''' <summary>
    ''' Refresh report content on screen.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshReport()

            Me.commonReportViewer.LocalReport.Refresh()
            'Me.commonReportViewer.RefreshReport()

    End Sub

    ''' <summary>
    ''' Exports report output to excel file.
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <remarks>
    ''' Report file is created into temporary file folder with temporary file name.
    ''' </remarks>
    Public Sub ExportReportToExcel(ByVal fileName As String)
      Dim encoding, fileNameExtension, filePath, mimeType, streamIds() As String
      Dim bytes As Byte()
      Dim warnings As Microsoft.Reporting.WinForms.Warning()
      Dim pi As System.Diagnostics.ProcessStartInfo

            Try
                bytes = commonReportViewer.LocalReport.Render("Excel", Nothing, mimeType, encoding, fileNameExtension, streamIds, warnings)
            Catch ex As Exception
                MessageBox.Show(" Excpetion " + ex.ToString() + " PE " + ex.Message.ToString())
            End Try


            filePath = fileName
            filePath = filePath.Replace(System.IO.Path.GetExtension(fileName), "." + fileNameExtension)

            Using fs As New System.IO.FileStream(filePath, IO.FileMode.Create)
                fs.Write(bytes, 0, bytes.Length)
                fs.Close()
            End Using

            pi = New System.Diagnostics.ProcessStartInfo(filePath)

            Try
                If pi.Verbs.Contains("Open") Then
                    pi.Verb = "Open"
                    System.Diagnostics.Process.Start(pi)
                Else
                    'Opens windows standard "open with..." dialog box, allowing user to choose application 
                    'to open exported excel file.
                    Process.Start("rundll32.exe", "shell32.dll, OpenAs_RunDLL " & filePath)
                End If

            Catch ex As System.ComponentModel.Win32Exception
                MessageBox.Show("Following error has occurred while opening exported excel file." _
                                + Environment.NewLine + ex.Message + Environment.NewLine _
                                + "File is saved successfully at " + filePath _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As System.Exception
                MessageBox.Show("An unknown error has occurred while opening exported excel file." _
                                + Environment.NewLine + "File is saved successfully at " + filePath _
                                , ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Finally
                pi = Nothing
            End Try

            filePath = Nothing

        End Sub



    Private Sub ShowReportForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

      Me.commonReportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
      'Me.commonReportViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth
      'Me.commonReportViewer.RefreshReport()

    End Sub


  End Class


End Namespace