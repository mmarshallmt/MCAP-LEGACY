
Public Class CCTasksLogSenderDetailsForm
    'Namespace UI
    ' Private WithEvents m_Processor As Processors.QCVehicleImages
    Private m_lastMouseClickTimeStamp As DateTime
    Private m_dataSource As System.Data.DataView
    Private m_senderAdapter As CoverageDataSetTableAdapters.SenderTableAdapter

    Private ReadOnly Property SenderAdapter() As CoverageDataSetTableAdapters.SenderTableAdapter
        Get
            Return m_senderAdapter
        End Get
    End Property



    ''' <summary>
    ''' Source of Data that will be used to display values for selection help.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Property DataSource() As System.Data.DataView
        Get
            Return m_dataSource
        End Get
        Set(ByVal value As System.Data.DataView)
            m_dataSource = value
        End Set
    End Property



    Public Sub Initialize(ByVal senderId As Integer)

        m_senderAdapter = New CoverageDataSetTableAdapters.SenderTableAdapter
        SenderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

        NameLabel.Text = getNameLabelId(senderId)
        AddressLabel.Text = getAddressLabelId(senderId)
        PhoneLabel.Text = getPhoneLabelId(senderId)




    End Sub


    Private Sub loadVehicleData()
        


    End Sub

    ''' <summary>
    ''' Gets image folder for supplied vehicle Id.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <exception cref="System.ApplicationException">Raises exception when CreateDt column value is null.</exception>
    ''' <remarks></remarks>
    Public Function getNameLabelId(ByVal senderId As Integer) As String

        Return getNameLabelIdValue(senderId)

    End Function



    ''' <summary>
    ''' Gets number of records for missing ad id.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getNameLabelIdValue(ByVal senderId As Integer) As String

        Dim SenderAdapter As CoverageDataSetTableAdapters.SenderTableAdapter
        SenderAdapter = New CoverageDataSetTableAdapters.SenderTableAdapter
        SenderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

        Dim senderName As String ' Nullable(Of Integer)

        Try
            senderName = SenderAdapter.GetNameBySender(senderId).ToString() 'getSenderNameBySenderId(senderId).ToString()
        Catch ex As Exception
            'senderName = ex.Message
        End Try



        If senderName Is Nothing Then
            Return String.Empty
        Else
            Return CType(senderName, String)
        End If

    End Function


    ''' <summary>
    ''' Gets image folder for supplied vehicle Id.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <exception cref="System.ApplicationException">Raises exception when CreateDt column value is null.</exception>
    ''' <remarks></remarks>
    Public Function getAddressLabelId(ByVal senderId As Integer) As String

        Return getAddressLabelIdValue(senderId)

    End Function



    ''' <summary>
    ''' Gets number of records for missing ad id.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getAddressLabelIdValue(ByVal senderId As Integer) As String
        Dim missingAdId As String 'Nullable(Of Integer)
        Dim SenderAdapter As CoverageDataSetTableAdapters.SenderTableAdapter
        SenderAdapter = New CoverageDataSetTableAdapters.SenderTableAdapter
        SenderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

        missingAdId = SenderAdapter.getAddressBySenderId(senderId)

        If missingAdId Is Nothing Then
            Return String.Empty
        Else
            Return CType(missingAdId, String)
        End If

    End Function

    ''' <summary>
    ''' Gets image folder for supplied vehicle Id.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <exception cref="System.ApplicationException">Raises exception when CreateDt column value is null.</exception>
    ''' <remarks></remarks>
    Public Function getPhoneLabelId(ByVal senderId As Integer) As String

        Return getPhoneLabelIdValue(senderId)

    End Function



    ''' <summary>
    ''' Gets number of records for missing ad id.
    ''' </summary>
    ''' <param name="vehicleId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getPhoneLabelIdValue(ByVal senderId As Integer) As String
        Dim missingAdId As String 'Nullable(Of Integer)
        Dim SenderAdapter As CoverageDataSetTableAdapters.SenderTableAdapter
        SenderAdapter = New CoverageDataSetTableAdapters.SenderTableAdapter
        SenderAdapter.Connection.ConnectionString = GetConnectionStringForAppDB()

        missingAdId = SenderAdapter.GetPhoneBySenderId(senderId)

        If missingAdId Is Nothing Then
            Return String.Empty
        Else
            Return CType(missingAdId, String)
        End If

    End Function


End Class

