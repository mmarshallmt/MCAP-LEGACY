Imports System
Imports System.IO
Imports System.IO.IsolatedStorage
Imports System.Text
Imports System.Xml

Public Class ApplicationVariableStorage
    Private m_dictionary As Dictionary(Of String, String)
    ''' <summary>
    ''' Loads value using key from local storage.  Shows default if key not found.
    ''' </summary>
    Protected Friend Function LoadValue(ByVal name As String, Optional ByVal defaultValue As String = "") As String
        If m_dictionary.ContainsKey(name) Then
            Return m_dictionary(name)
        Else
            Return defaultValue
        End If
    End Function
    ''' <summary>
    ''' Save the value using the key into local storage.
    ''' </summary>
    Protected Friend Sub SaveValue(ByVal name As String, ByVal value As String)
        If m_dictionary.ContainsKey(name) Then
            m_dictionary.Remove(name)
        End If
        m_dictionary.Add(name, value)
    End Sub
    ''' <summary>
    ''' Reads the Users settings from XML File.
    ''' Stores key/value pairs in local variable
    ''' </summary>
    Protected Friend Sub ReadFromFile()
        Dim isoStorage As IsolatedStorageFile
        Dim fileNames As String()
        Dim fileName As String
        Dim stmReader As StreamReader
        Dim readString As String
        Dim readName As String
        isoStorage = IsolatedStorageFile.GetUserStoreForDomain

        fileNames = isoStorage.GetFileNames("MCAPUserSettingsXML.xml")
        m_dictionary = New Dictionary(Of String, String)

        For Each fileName In fileNames
            If fileName = "MCAPUserSettingsXML.xml" Then
                stmReader = New StreamReader(New IsolatedStorageFileStream("MCAPUserSettingsXML.xml", _
                   FileMode.Open, isoStorage))
                Dim xmlReader As New XmlTextReader(stmReader)
                While xmlReader.Read()
                    readName = xmlReader.Name
                    'Don't want to "ReadString" if one of these elements is the current one
                    If readName <> "xml" And readName <> "" And readName <> "MCAPUserSettings" Then
                        readString = xmlReader.ReadString
                        If Not m_dictionary.ContainsKey(readName) Then
                            m_dictionary.Add(readName, readString)
                        End If
                    End If
                End While
                xmlReader.Close()
                stmReader.Close()
            End If
        Next
        isoStorage.Close()

    End Sub
    ''' <summary>
    ''' Reads through the local key/value pairs.
    ''' Writes the data to an XML file for the user.
    ''' </summary>
    Protected Friend Sub WriteToFile()
        Dim isoStorage As IsolatedStorageFile
        isoStorage = IsolatedStorageFile.GetUserStoreForDomain
        Dim stmWriter As New IsolatedStorageFileStream("MCAPUserSettingsXML.xml", IO.FileMode.Create, isoStorage)
        Dim writer As New System.Xml.XmlTextWriter(stmWriter, System.Text.Encoding.UTF8)
        writer.Formatting = System.Xml.Formatting.Indented
        writer.WriteStartDocument()
        writer.WriteStartElement("MCAPUserSettings")
        For Each vKey As KeyValuePair(Of String, String) In m_dictionary
            If vKey.Key <> "" Then
                writer.WriteStartElement(vKey.Key)
                writer.WriteString(vKey.Value)
                writer.WriteEndElement()
            End If
        Next
        writer.WriteEndElement()
        writer.Flush()
        writer.Close()
        stmWriter.Close()
        isoStorage.Close()
    End Sub
End Class
