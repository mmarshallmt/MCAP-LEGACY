Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization

Public Class clsVehicle
    Inherits EditableBase(Of clsVehicle)

#Region "Private Variables"
    Private _VehicleId As Integer
    Private _EnvelopeId As Integer
    Private _RetId As Integer
    Private _MktId As Integer
    Private _BreakDt As System.DateTime
    Private _StartDt As System.DateTime
    Private _EndDt As System.DateTime
    Private _TypeId As Integer
    Private _LanguageId As Integer
    Private _EventId As Integer
    Private _ThemeId As Integer
    Private _MediaId As Integer
    Private _PublicationId As Integer
    Private _FlashInd As Byte
    Private _CreateDt As System.DateTime
    Private _CreatedById As Integer
    Private _ScanDt As System.DateTime
    Private _ScannedById As Integer
    Private _QCedById As Integer
    Private _QCDt As System.DateTime
    Private _FamilyId As Integer
    Private _CouponInd As Byte
    Private _CreateSizedDt As System.DateTime
    Private _Priority As Integer
    Private _CheckInPageCount As Integer
    Private _StatusID As Integer
    Private _SenderId As Integer
    Private _PullDt As System.DateTime
    Private _PulledById As Integer
    Private _PullPageCount As Integer
    Private _Weight As Decimal
    Private _PullQCedById As Integer
    Private _PullQCDt As System.DateTime
    Private _FormName As String
    Private _CheckInOccurrences As Integer
    Private _NationalInd As Byte
    Private _ftpStatusId As Integer
    Private _ftpDt As System.DateTime
    Private _IndexDt As System.DateTime
    Private _IndexedById As Integer
    Private _RemoteEntryImageFTPStatusId As Integer
    Private _RemoteEntryImageFTPDt As System.DateTime
    Private _RemoteEntryImageForceFTPRetransfer As Byte
    Private _RemoteEntryImageFTPQueueInsertDt As System.DateTime
    Private _SPReviewStatusId As Integer
    Private _EntryInd As Byte
    Private _ParentVehicleId As Integer
    Private _BodyText As String
    Private _BodyHTML As String
    Private _SiteId As Integer
    Private _Subject As String
    Private _ReQCDt As System.DateTime
    Private _ReQCedById As Integer
    Private _FilterMatches As String
    Private _isReviewed As Boolean
    Private _ReviewDt As System.DateTime
    Private _ReviewedByUserId As Guid
    Private _isQCed As Boolean
    Private _QCDate As System.DateTime
    Private _QCedByUserId As Guid
    Private _QAComments As String
    Private _DistDt As System.DateTime
    Private _IndReadyForExport As Byte
    Private objclsVehicle As clsVehicle

#End Region

    Public Sub New()
        Me.VehicleId = 0
        Me.EnvelopeId = 0
        Me.RetId = 0
        Me.MktId = 0
        Me.BreakDt = Now()
        Me.StartDt = Now()
        Me.EndDt = Now()
        Me.TypeId = 0
        Me.LanguageId = 0
        Me.EventId = 0
        Me.ThemeId = 0
        Me.MediaId = 0
        Me.ParentVehicleId = 0
        Me.PublicationId = 0
        Me.FlashInd = 0
        Me.CreateDt = Now()
        Me.CreatedById = 0
        Me.ScanDt = Now()
        Me.ScannedById = 0
        Me.QCedById = 0
        Me.QCDt = Now()
        Me.FamilyId = 0
        Me.CouponInd = 0
        Me.CreateSizedDt = Now()
        Me.Priority = 0
        Me.CheckInPageCount = 0
        Me.StatusID = 0
        Me.SenderId = 0
        Me.PullDt = Now()
        Me.PulledById = 0
        Me.PullPageCount = 0
        Me.Weight = CDec(0.0)
        Me.PullQCedById = 0
        Me.PullQCDt = Now
        Me.FormName = ""
        Me.CheckInOccurrences = 0
        Me.NationalInd = 0
        Me.ftpStatusId = 0
        Me.ftpDt = Now()
        Me.IndexDt = Now()
        Me.IndexedById = 0
        Me.RemoteEntryImageFTPStatusId = 0
        Me.RemoteEntryImageFTPDt = Now()
        Me.RemoteEntryImageForceFTPRetransfer = 0
        Me.RemoteEntryImageFTPQueueInsertDt = Now()
        Me.SPReviewStatusId = 0
        Me.EntryInd = 0
        Me.BodyText = ""
        Me.BodyHTML = ""
        Me.SiteId = 0
        Me.Subject = ""
        Me.ReQCDt = Now()
        Me.ReQCedById = 0
        Me.FilterMatches = ""
        Me.isReviewed = False
        Me.ReviewDt = Now()
        Me.ReviewedByUserId = Guid.Empty
        Me.isQCed = False
        Me.QCDate = Now()
        Me.QCedByUserId = Guid.Empty
        Me.QAComments = ""
        Me.DistDt = Now
        Me.IndReadyForExport = 0

    End Sub

    Public Sub New(ByVal dr As SafeDataReader)

        Me.VehicleId = CInt(dr.GetInt32(dr.GetOrdinal("vehicleID")))
        Me.EnvelopeId = dr.GetInt32(dr.GetOrdinal("EnvelopeId"))
        Me.RetId = dr.GetInt32(dr.GetOrdinal("RetId"))
        Me.MktId = dr.GetInt32(dr.GetOrdinal("MktId"))
        Me.BreakDt = dr.GetDateTime(dr.GetOrdinal("BreakDt"))
        Me.StartDt = dr.GetDateTime(dr.GetOrdinal("StartDt"))
        Me.EndDt = dr.GetDateTime(dr.GetOrdinal("EndDt"))
        Me.TypeId = dr.GetInt32(dr.GetOrdinal("TypeId"))
        Me.LanguageId = dr.GetInt32(dr.GetOrdinal("LanguageId"))
        Me.EventId = dr.GetInt32(dr.GetOrdinal("EventId"))
        Me.ThemeId = dr.GetInt32(dr.GetOrdinal("ThemeId"))
        Me.MediaId = dr.GetInt32(dr.GetOrdinal("MediaId"))
        Me.ParentVehicleId = dr.GetInt32(dr.GetOrdinal("ParentVehicleId"))
        Me.PublicationId = dr.GetInt32(dr.GetOrdinal("PublicationId"))
        Me.FlashInd = dr.GetByte(dr.GetOrdinal("FlashInd"))
        Me.CreateDt = dr.GetDateTime(dr.GetOrdinal("CreateDt"))
        Me.CreatedById = dr.GetInt32(dr.GetOrdinal("CreatedById"))
        Me.ScanDt = dr.GetDateTime(dr.GetOrdinal("ScanDt"))
        Me.ScannedById = dr.GetInt32(dr.GetOrdinal("ScannedById"))
        Me.QCedById = dr.GetInt32(dr.GetOrdinal("QCedById"))
        Me.QCDt = dr.GetDateTime(dr.GetOrdinal("QCDt"))
        Me.FamilyId = dr.GetInt32(dr.GetOrdinal("FamilyId"))
        Me.CouponInd = dr.GetByte(dr.GetOrdinal("CouponInd"))
        Me.CreateSizedDt = dr.GetDateTime(dr.GetOrdinal("CreateSizedDt"))
        Me.Priority = dr.GetInt32(dr.GetOrdinal("Priority"))
        Me.CheckInPageCount = dr.GetInt32(dr.GetOrdinal("CheckInPageCount"))
        Me.StatusID = dr.GetInt32(dr.GetOrdinal("StatusID"))
        Me.SenderId = dr.GetInt32(dr.GetOrdinal("SenderId"))
        Me.PullDt = dr.GetDateTime(dr.GetOrdinal("PullDt"))
        Me.PulledById = dr.GetInt32(dr.GetOrdinal("PulledById"))
        Me.PullPageCount = dr.GetInt32(dr.GetOrdinal("PullPageCount"))
        Me.Weight = dr.GetDecimal(dr.GetOrdinal("Weight"))
        Me.PullQCedById = dr.GetInt32(dr.GetOrdinal("PullQCedById"))
        Me.PullQCDt = dr.GetDateTime(dr.GetOrdinal("PullQCDt"))
        Me.FormName = dr.GetString(dr.GetOrdinal("FormName"))
        Me.CheckInOccurrences = dr.GetInt32(dr.GetOrdinal("CheckInOccurrences"))
        Me.NationalInd = dr.GetByte(dr.GetOrdinal("NationalInd"))
        Me.ftpStatusId = dr.GetInt32(dr.GetOrdinal("ftpStatusId"))
        Me.ftpDt = dr.GetDateTime(dr.GetOrdinal("ftpDt"))
        Me.IndexDt = dr.GetDateTime(dr.GetOrdinal("IndexDt"))
        Me.IndexedById = dr.GetInt32(dr.GetOrdinal("IndexedById"))
        Me.RemoteEntryImageFTPStatusId = dr.GetInt32(dr.GetOrdinal("RemoteEntryImageFTPStatusId"))
        Me.RemoteEntryImageFTPDt = dr.GetDateTime(dr.GetOrdinal("RemoteEntryImageFTPDt"))
        Me.RemoteEntryImageForceFTPRetransfer = dr.GetByte(dr.GetOrdinal("RemoteEntryImageForceFTPRetransfer"))
        Me.RemoteEntryImageFTPQueueInsertDt = dr.GetDateTime(dr.GetOrdinal("RemoteEntryImageFTPQueueInsertDt"))
        Me.SPReviewStatusId = dr.GetInt32(dr.GetOrdinal("SPReviewStatusId"))
        Me.EntryInd = dr.GetByte(dr.GetOrdinal("EntryInd"))
        Me.BodyText = dr.GetString(dr.GetOrdinal("BodyText"))
        Me.BodyHTML = dr.GetString(dr.GetOrdinal("BodyHTML"))
        Me.SiteId = dr.GetInt32(dr.GetOrdinal("SiteId"))
        Me.Subject = dr.GetString(dr.GetOrdinal("Subject"))
        Me.ReQCDt = dr.GetDateTime(dr.GetOrdinal("ReQCDt"))
        Me.ReQCedById = dr.GetInt32(dr.GetOrdinal("ReQCedById"))
        Me.FilterMatches = dr.GetString(dr.GetOrdinal("FilterMatches"))
        Me.isReviewed = dr.GetBoolean(dr.GetOrdinal("isReviewed"))
        Me.ReviewDt = dr.GetDateTime(dr.GetOrdinal("ReviewDt"))
        Me.ReviewedByUserId = dr.GetGuid(dr.GetOrdinal("ReviewedByUserId"))
        Me.isQCed = dr.GetBoolean(dr.GetOrdinal("isQCed"))
        Me.QCDate = dr.GetDateTime(dr.GetOrdinal("QCDate"))
        Me.QCedByUserId = dr.GetGuid(dr.GetOrdinal("QCedByUserId"))
        Me.QAComments = dr.GetString(dr.GetOrdinal("QAComments"))
        Me.DistDt = dr.GetDateTime(dr.GetOrdinal("DistDt"))
        Me.IndReadyForExport = dr.GetByte(dr.GetOrdinal("IndReadyForExport"))

    End Sub

#Region "Public Properties"
    Public Property VehicleId() As Integer
        Get
            Return _VehicleId
        End Get
        Set(ByVal value As Integer)
            _VehicleId = value
        End Set
    End Property
    Public Property EnvelopeId() As Integer
        Get
            Return _EnvelopeId
        End Get
        Set(ByVal value As Integer)
            _EnvelopeId = value
        End Set
    End Property
    Public Property RetId() As Integer
        Get
            Return _RetId
        End Get
        Set(ByVal value As Integer)
            _RetId = value
        End Set
    End Property
    Public Property MktId() As Integer
        Get
            Return _MktId
        End Get
        Set(ByVal value As Integer)
            _MktId = value
        End Set
    End Property
    Public Property BreakDt() As DateTime
        Get
            Return _BreakDt
        End Get
        Set(ByVal value As DateTime)
            _BreakDt = value
        End Set
    End Property
    Public Property StartDt() As System.DateTime
        Get
            Return _StartDt
        End Get
        Set(ByVal value As System.DateTime)
            _StartDt = value
        End Set
    End Property
    Public Property EndDt() As System.DateTime
        Get
            Return _EndDt
        End Get
        Set(ByVal value As System.DateTime)
            _EndDt = value
        End Set
    End Property
    Public Property TypeId() As Integer
        Get
            Return _TypeId
        End Get
        Set(ByVal value As Integer)
            _TypeId = value
        End Set
    End Property
    Public Property LanguageId() As Integer
        Get
            Return _LanguageId
        End Get
        Set(ByVal value As Integer)
            _LanguageId = value
        End Set
    End Property
    Public Property EventId() As Integer
        Get
            Return _EventId
        End Get
        Set(ByVal value As Integer)
            _EventId = value
        End Set
    End Property
    Public Property ThemeId() As Integer
        Get
            Return _ThemeId
        End Get
        Set(ByVal value As Integer)
            _ThemeId = value
        End Set
    End Property
    Public Property MediaId() As Integer
        Get
            Return _MediaId
        End Get
        Set(ByVal value As Integer)
            _MediaId = value
        End Set
    End Property
    Public Property PublicationId() As Integer
        Get
            Return _PublicationId
        End Get
        Set(ByVal value As Integer)
            _PublicationId = value
        End Set
    End Property
    Public Property FlashInd() As Byte
        Get
            Return _FlashInd
        End Get
        Set(ByVal value As Byte)
            _FlashInd = value
        End Set
    End Property
    Public Property CreateDt() As System.DateTime
        Get
            Return _CreateDt
        End Get
        Set(ByVal value As System.DateTime)
            _CreateDt = value
        End Set
    End Property
    Public Property CreatedById() As Integer
        Get
            Return _CreatedById
        End Get
        Set(ByVal value As Integer)
            _CreatedById = value
        End Set
    End Property
    Public Property ScanDt() As System.DateTime
        Get
            Return _ScanDt
        End Get
        Set(ByVal value As System.DateTime)
            _ScanDt = value
        End Set
    End Property
    Public Property ScannedById() As Integer
        Get
            Return _ScannedById
        End Get
        Set(ByVal value As Integer)
            _ScannedById = value
        End Set
    End Property
    Public Property QCedById() As Integer
        Get
            Return _QCedById
        End Get
        Set(ByVal value As Integer)
            _QCedById = value
        End Set
    End Property
    Public Property QCDt() As System.DateTime
        Get
            Return _QCDt
        End Get
        Set(ByVal value As System.DateTime)
            _QCDt = value
        End Set
    End Property
    Public Property FamilyId() As Integer
        Get
            Return _FamilyId
        End Get
        Set(ByVal value As Integer)
            _FamilyId = value
        End Set
    End Property
    Public Property CouponInd() As Byte
        Get
            Return _CouponInd
        End Get
        Set(ByVal value As Byte)
            _CouponInd = value
        End Set
    End Property
    Public Property CreateSizedDt() As System.DateTime
        Get
            Return _CreateSizedDt
        End Get
        Set(ByVal value As System.DateTime)
            _CreateSizedDt = value
        End Set
    End Property
    Public Property Priority() As Integer
        Get
            Return _Priority
        End Get
        Set(ByVal value As Integer)
            _Priority = value
        End Set
    End Property
    Public Property CheckInPageCount() As Integer
        Get
            Return _CheckInPageCount
        End Get
        Set(ByVal value As Integer)
            _CheckInPageCount = value
        End Set
    End Property
    Public Property StatusID() As Integer
        Get
            Return _StatusID
        End Get
        Set(ByVal value As Integer)
            _StatusID = value
        End Set
    End Property
    Public Property SenderId() As Integer
        Get
            Return _SenderId
        End Get
        Set(ByVal value As Integer)
            _SenderId = value
        End Set
    End Property
    Public Property PullDt() As System.DateTime
        Get
            Return _PullDt
        End Get
        Set(ByVal value As System.DateTime)
            _PullDt = value
        End Set
    End Property
    Public Property PulledById() As Integer
        Get
            Return _PulledById
        End Get
        Set(ByVal value As Integer)
            _PulledById = value
        End Set
    End Property
    Public Property PullPageCount() As Integer
        Get
            Return _PullPageCount
        End Get
        Set(ByVal value As Integer)
            _PullPageCount = value
        End Set
    End Property
    Public Property Weight() As Decimal
        Get
            Return _Weight
        End Get
        Set(ByVal value As Decimal)
            _Weight = value
        End Set
    End Property
    Public Property PullQCedById() As Integer
        Get
            Return _PullQCedById
        End Get
        Set(ByVal value As Integer)
            _PullQCedById = value
        End Set
    End Property
    Public Property PullQCDt() As System.DateTime
        Get
            Return _PullQCDt
        End Get
        Set(ByVal value As System.DateTime)
            _PullQCDt = value
        End Set
    End Property
    Public Property FormName() As String
        Get
            Return _FormName
        End Get
        Set(ByVal value As String)
            _FormName = value
        End Set
    End Property
    Public Property CheckInOccurrences() As Integer
        Get
            Return _CheckInOccurrences
        End Get
        Set(ByVal value As Integer)
            _CheckInOccurrences = value
        End Set
    End Property
    Public Property NationalInd() As Byte
        Get
            Return _NationalInd
        End Get
        Set(ByVal value As Byte)
            _NationalInd = value
        End Set
    End Property
    Public Property ftpStatusId() As Integer
        Get
            Return _ftpStatusId
        End Get
        Set(ByVal value As Integer)
            _ftpStatusId = value
        End Set
    End Property
    Public Property ftpDt() As System.DateTime
        Get
            Return _ftpDt
        End Get
        Set(ByVal value As System.DateTime)
            _ftpDt = value
        End Set
    End Property
    Public Property IndexDt() As System.DateTime
        Get
            Return _IndexDt
        End Get
        Set(ByVal value As System.DateTime)
            _IndexDt = value
        End Set
    End Property
    Public Property IndexedById() As Integer
        Get
            Return _IndexedById
        End Get
        Set(ByVal value As Integer)
            _IndexedById = value
        End Set
    End Property
    Public Property RemoteEntryImageFTPStatusId() As Integer
        Get
            Return _RemoteEntryImageFTPStatusId
        End Get
        Set(ByVal value As Integer)
            _RemoteEntryImageFTPStatusId = value
        End Set
    End Property
    Public Property RemoteEntryImageFTPDt() As System.DateTime
        Get
            Return _RemoteEntryImageFTPDt
        End Get
        Set(ByVal value As System.DateTime)
            _RemoteEntryImageFTPDt = value
        End Set
    End Property
    Public Property RemoteEntryImageForceFTPRetransfer() As Byte
        Get
            Return _RemoteEntryImageForceFTPRetransfer
        End Get
        Set(ByVal value As Byte)
            _RemoteEntryImageForceFTPRetransfer = value
        End Set
    End Property
    Public Property RemoteEntryImageFTPQueueInsertDt() As System.DateTime
        Get
            Return _RemoteEntryImageFTPQueueInsertDt
        End Get
        Set(ByVal value As System.DateTime)
            _RemoteEntryImageFTPQueueInsertDt = value
        End Set
    End Property
    Public Property SPReviewStatusId() As Integer
        Get
            Return _SPReviewStatusId
        End Get
        Set(ByVal value As Integer)
            _SPReviewStatusId = value
        End Set
    End Property
    Public Property EntryInd() As Byte
        Get
            Return _EntryInd
        End Get
        Set(ByVal value As Byte)
            _EntryInd = value
        End Set
    End Property
    Public Property ParentVehicleId() As Integer
        Get
            Return _ParentVehicleId
        End Get
        Set(ByVal value As Integer)
            _ParentVehicleId = value
        End Set
    End Property
    Public Property BodyText() As String
        Get
            Return _BodyText
        End Get
        Set(ByVal value As String)
            _BodyText = value
        End Set
    End Property
    Public Property BodyHTML() As String
        Get
            Return _BodyHTML
        End Get
        Set(ByVal value As String)
            _BodyHTML = value
        End Set
    End Property
    Public Property SiteId() As Integer
        Get
            Return _SiteId
        End Get
        Set(ByVal value As Integer)
            _SiteId = value
        End Set
    End Property
    Public Property Subject() As String
        Get
            Return _Subject
        End Get
        Set(ByVal value As String)
            _Subject = value
        End Set
    End Property
    Public Property ReQCDt() As System.DateTime
        Get
            Return _ReQCDt
        End Get
        Set(ByVal value As System.DateTime)
            _ReQCDt = value
        End Set
    End Property
    Public Property ReQCedById() As Integer
        Get
            Return _ReQCedById
        End Get
        Set(ByVal value As Integer)
            _ReQCedById = value
        End Set
    End Property
    Public Property FilterMatches() As String
        Get
            Return _FilterMatches
        End Get
        Set(ByVal value As String)
            _FilterMatches = value
        End Set
    End Property
    Public Property isReviewed() As Boolean
        Get
            Return _isReviewed
        End Get
        Set(ByVal value As Boolean)
            _isReviewed = value
        End Set
    End Property
    Public Property ReviewDt() As System.DateTime
        Get
            Return _ReviewDt
        End Get
        Set(ByVal value As System.DateTime)
            _ReviewDt = value
        End Set
    End Property
    Public Property ReviewedByUserId() As Guid
        Get
            Return _ReviewedByUserId
        End Get
        Set(ByVal value As Guid)
            _ReviewedByUserId = value
        End Set
    End Property
    Public Property isQCed() As Boolean
        Get
            Return _isQCed
        End Get
        Set(ByVal value As Boolean)
            _isQCed = value
        End Set
    End Property
    Public Property QCDate() As System.DateTime
        Get
            Return _QCDate
        End Get
        Set(ByVal value As System.DateTime)
            _QCDate = value
        End Set
    End Property
    Public Property QCedByUserId() As Guid
        Get
            Return _QCedByUserId
        End Get
        Set(ByVal value As Guid)
            _QCedByUserId = value
        End Set
    End Property
    Public Property QAComments() As String
        Get
            Return _QAComments
        End Get
        Set(ByVal value As String)
            _QAComments = value
        End Set
    End Property
    Public Property DistDt() As System.DateTime
        Get
            Return _DistDt
        End Get
        Set(ByVal value As System.DateTime)
            _DistDt = value
        End Set
    End Property
    Public Property IndReadyForExport() As Byte
        Get
            Return _IndReadyForExport
        End Get
        Set(ByVal value As Byte)
            _IndReadyForExport = value
        End Set
    End Property
#End Region

#Region "Public Methods"

    Public Function Fetch(ByVal criteria As Integer) As Object

        Dim item As New clsVehicle

        Using objCnn As New SqlConnection(GetConnectionStringForAppDB)
            objCnn.Open()
            Using objCmd As SqlCommand = objCnn.CreateCommand()
                objCmd.CommandType = System.Data.CommandType.StoredProcedure
                objCmd.CommandText = "[mt_proc_getAllVehicleByID]"
                objCmd.Parameters.AddWithValue("@VehicleID", criteria)
                'objCmd.Parameters.AddWithValue("@pFormName", "")
                'objCmd.Parameters.AddWithValue("@pErrorMessage", "")


                Using dr As SqlDataReader = objCmd.ExecuteReader()
                    If dr.Read Then

                        item.VehicleId = CInt(dr.GetInt32(dr.GetOrdinal("vehicleID")))
                        item.EnvelopeId = dr.GetInt32(dr.GetOrdinal("EnvelopeId"))
                        item.RetId = dr.GetInt32(dr.GetOrdinal("RetId"))
                        item.MktId = dr.GetInt32(dr.GetOrdinal("MktId"))
                        item.BreakDt = dr.GetDateTime(dr.GetOrdinal("BreakDt"))
                        item.StartDt = dr.GetDateTime(dr.GetOrdinal("StartDt"))
                        item.EndDt = dr.GetDateTime(dr.GetOrdinal("EndDt"))

                        'If dr.IsDBNull(dr.GetInt32(dr.GetOrdinal("TypeId"))) Then
                        '    item.TypeId = 0
                        'Else
                        'item.TypeId = dr.GetInt32(dr.GetOrdinal("TypeId"))
                        'End If

                        item.LanguageId = dr.GetInt32(dr.GetOrdinal("LanguageId"))
                        item.EventId = dr.GetInt32(dr.GetOrdinal("EventId"))
                        item.ThemeId = dr.GetInt32(dr.GetOrdinal("ThemeId"))
                        item.MediaId = dr.GetInt32(dr.GetOrdinal("MediaId"))
                        If dr.IsDBNull(dr.GetOrdinal("ParentVehicleId")) Then
                            item.ParentVehicleId = 0
                        Else
                            item.ParentVehicleId = dr.GetInt32(dr.GetOrdinal("ParentVehicleId"))
                        End If

                        If dr.IsDBNull(dr.GetOrdinal("PublicationId")) Then
                            item.PublicationId = 0
                        Else
                            item.PublicationId = dr.GetInt32(dr.GetOrdinal("PublicationId"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("FlashInd")) Then
                            item.FlashInd = 0
                        Else
                            item.FlashInd = dr.GetByte(dr.GetOrdinal("FlashInd"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("CreateDt")) Then
                            item.CreateDt = CDate(System.Data.SqlTypes.SqlDateTime.Null)
                        Else
                            item.CreateDt = dr.GetDateTime(dr.GetOrdinal("CreateDt"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("CreatedById")) Then
                            item.CreatedById = 0
                        Else
                            item.CreatedById = dr.GetInt32(dr.GetOrdinal("CreatedById"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("ScanDt")) Then
                            item.ScanDt = CDate(System.Data.SqlTypes.SqlDateTime.Null)
                        Else
                            item.ScanDt = dr.GetDateTime(dr.GetOrdinal("ScanDt"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("ScannedById")) Then
                            item.ScannedById = 0
                        Else
                            item.ScannedById = dr.GetInt32(dr.GetOrdinal("ScannedById"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("QCedById")) Then
                            item.QCedById = 0
                        Else
                            item.QCedById = dr.GetInt32(dr.GetOrdinal("QCedById"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("QCDt")) Then
                            item.QCDt = CDate(System.Data.SqlTypes.SqlDateTime.Null)
                        Else
                            item.QCDt = dr.GetDateTime(dr.GetOrdinal("QCDt"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("FamilyId")) Then
                            item.FamilyId = 0
                        Else
                            item.FamilyId = dr.GetInt32(dr.GetOrdinal("FamilyId"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("CouponInd")) Then
                            item.CouponInd = 0
                        Else
                            item.CouponInd = dr.GetByte(dr.GetOrdinal("CouponInd"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("CreateSizedDt")) Then
                            item.CreateSizedDt = CDate(System.Data.SqlTypes.SqlDateTime.Null)
                        Else
                            item.CreateSizedDt = dr.GetDateTime(dr.GetOrdinal("CreateSizedDt"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("Priority")) Then
                            item.Priority = 0
                        Else
                            item.Priority = dr.GetInt32(dr.GetOrdinal("Priority"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("CheckInPageCount")) Then
                            item.CheckInPageCount = 0
                        Else
                            item.CheckInPageCount = dr.GetInt32(dr.GetOrdinal("CheckInPageCount"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("StatusID")) Then
                            item.StatusID = 0
                        Else
                            item.StatusID = dr.GetInt32(dr.GetOrdinal("StatusID"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("SenderId")) Then
                            item.SenderId = 0
                        Else
                            item.SenderId = dr.GetInt32(dr.GetOrdinal("SenderId"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("PullDt")) Then
                            item.PullDt = CDate(System.Data.SqlTypes.SqlDateTime.Null)
                        Else
                            item.PullDt = dr.GetDateTime(dr.GetOrdinal("PullDt"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("PulledById")) Then
                            item.PulledById = 0
                        Else
                            item.PulledById = dr.GetInt32(dr.GetOrdinal("PulledById"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("PullPageCount")) Then
                            item.PullPageCount = 0
                        Else
                            item.PullPageCount = dr.GetInt32(dr.GetOrdinal("PullPageCount"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("Weight")) Then
                            item.Weight = CDec(0.0)
                        Else
                            item.Weight = dr.GetDecimal(dr.GetOrdinal("Weight"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("PullQCedById")) Then
                            item.PullQCedById = 0
                        Else
                            item.PullQCedById = dr.GetInt32(dr.GetOrdinal("PullQCedById"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("PullQCDt")) Then
                            item.PullQCDt = CDate(System.Data.SqlTypes.SqlDateTime.Null)
                        Else
                            item.PullQCDt = dr.GetDateTime(dr.GetOrdinal("PullQCDt"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("FormName")) Then
                            item.FormName = ""
                        Else
                            item.FormName = dr.GetString(dr.GetOrdinal("FormName"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("CheckInOccurrences")) Then
                            item.CheckInOccurrences = 0
                        Else
                            item.CheckInOccurrences = dr.GetInt32(dr.GetOrdinal("CheckInOccurrences"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("NationalInd")) Then
                            item.NationalInd = 0
                        Else
                            item.NationalInd = dr.GetByte(dr.GetOrdinal("NationalInd"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("ftpStatusId")) Then
                            item.ftpStatusId = 0
                        Else
                            item.ftpStatusId = dr.GetInt32(dr.GetOrdinal("ftpStatusId"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("ftpDt")) Then
                            item.ftpDt = CDate(System.Data.SqlTypes.SqlDateTime.Null)
                        Else
                            item.ftpDt = dr.GetDateTime(dr.GetOrdinal("ftpDt"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("IndexDt")) Then
                            item.IndexDt = CDate(System.Data.SqlTypes.SqlDateTime.Null)
                        Else
                            item.IndexDt = dr.GetDateTime(dr.GetOrdinal("IndexDt"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("IndexedById")) Then
                            item.IndexedById = 0
                        Else
                            item.IndexedById = dr.GetInt32(dr.GetOrdinal("IndexedById"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("RemoteEntryImageFTPStatusId")) Then
                            item.RemoteEntryImageFTPStatusId = 0
                        Else
                            item.RemoteEntryImageFTPStatusId = dr.GetInt32(dr.GetOrdinal("RemoteEntryImageFTPStatusId"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("RemoteEntryImageFTPDt")) Then
                            item.RemoteEntryImageFTPDt = CDate(System.Data.SqlTypes.SqlDateTime.Null)
                        Else
                            item.RemoteEntryImageFTPDt = dr.GetDateTime(dr.GetOrdinal("RemoteEntryImageFTPDt"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("RemoteEntryImageForceFTPRetransfer")) Then
                            item.RemoteEntryImageForceFTPRetransfer = 0
                        Else
                            item.RemoteEntryImageForceFTPRetransfer = dr.GetByte(dr.GetOrdinal("RemoteEntryImageForceFTPRetransfer"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("RemoteEntryImageFTPQueueInsertDt")) Then
                            item.RemoteEntryImageFTPQueueInsertDt = CDate(System.Data.SqlTypes.SqlDateTime.Null)
                        Else
                            item.RemoteEntryImageFTPQueueInsertDt = dr.GetDateTime(dr.GetOrdinal("RemoteEntryImageFTPQueueInsertDt"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("SPReviewStatusId")) Then
                            item.SPReviewStatusId = 0
                        Else
                            item.SPReviewStatusId = dr.GetInt32(dr.GetOrdinal("SPReviewStatusId"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("EntryInd")) Then
                            item.EntryInd = 0
                        Else
                            item.EntryInd = dr.GetByte(dr.GetOrdinal("EntryInd"))
                        End If

                        If dr.IsDBNull(dr.GetOrdinal("BodyText")) Then
                            item.BodyText = ""
                        Else
                            item.BodyText = dr.GetString(dr.GetOrdinal("BodyText"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("BodyHTML")) Then
                            item.BodyHTML = ""
                        Else
                            item.BodyHTML = dr.GetString(dr.GetOrdinal("BodyHTML"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("SiteId")) Then
                            item.SiteId = 0
                        Else
                            item.SiteId = dr.GetInt32(dr.GetOrdinal("SiteId"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("Subject")) Then
                            item.Subject = ""
                        Else
                            item.Subject = dr.GetString(dr.GetOrdinal("Subject"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("ReQCDt")) Then
                            item.ReQCDt = CDate(System.Data.SqlTypes.SqlDateTime.Null)
                        Else
                            item.ReQCDt = dr.GetDateTime(dr.GetOrdinal("ReQCDt"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("ReQCedById")) Then
                            item.ReQCedById = 0
                        Else
                            item.ReQCedById = dr.GetInt32(dr.GetOrdinal("ReQCedById"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("FilterMatches")) Then
                            item.FilterMatches = ""
                        Else
                            item.FilterMatches = dr.GetString(dr.GetOrdinal("FilterMatches"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("isReviewed")) Then
                            item.isReviewed = False
                        Else
                            item.isReviewed = dr.GetBoolean(dr.GetOrdinal("isReviewed"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("ReviewDt")) Then
                            item.ReviewDt = CDate(System.Data.SqlTypes.SqlDateTime.Null)
                        Else
                            item.ReviewDt = dr.GetDateTime(dr.GetOrdinal("ReviewDt"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("ReviewedByUserId")) Then
                            item.ReviewedByUserId = Guid.Empty
                        Else
                            item.ReviewedByUserId = dr.GetGuid(dr.GetOrdinal("ReviewedByUserId"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("isQCed")) Then
                            item.isQCed = False
                        Else
                            item.isQCed = dr.GetBoolean(dr.GetOrdinal("isQCed"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("QCDate")) Then
                            item.QCDate = CDate(System.Data.SqlTypes.SqlDateTime.Null)
                        Else
                            item.QCDate = dr.GetDateTime(dr.GetOrdinal("QCDate"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("QCedByUserId")) Then
                            item.QCedByUserId = Guid.Empty
                        Else
                            item.QCedByUserId = dr.GetGuid(dr.GetOrdinal("QCedByUserId"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("QAComments")) Then
                            item.QAComments = ""
                        Else
                            item.QAComments = dr.GetString(dr.GetOrdinal("QAComments"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("DistDt")) Then
                            item.DistDt = CDate(System.Data.SqlTypes.SqlDateTime.Null)
                        Else
                            item.DistDt = dr.GetDateTime(dr.GetOrdinal("DistDt"))
                        End If
                        If dr.IsDBNull(dr.GetOrdinal("IndReadyForExport")) Then
                            item.IndReadyForExport = 0
                        Else
                            item.IndReadyForExport = dr.GetByte(dr.GetOrdinal("IndReadyForExport"))
                        End If



                    End If
                End Using
            End Using
        End Using
        'item.MarkClean()
        'item.MarkOld()
        Return item
    End Function

    Public Function GetVehicles() As List(Of clsVehicle)
        Dim objRet As New List(Of clsVehicle)()
        ' Dim objCSS As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("ProvString")
        Using objCnn As New SqlConnection(GetConnectionStringForAppDB)
            objCnn.Open()
            Using objCmd As SqlCommand = objCnn.CreateCommand()
                objCmd.CommandType = System.Data.CommandType.StoredProcedure
                objCmd.CommandText = "[mt_proc_AddVehicle]"
                Using objDR As SqlDataReader = objCmd.ExecuteReader()
                    While objDR.Read()
                        Dim objRec As New clsVehicle()
                        If objDR.IsDBNull(objDR.GetOrdinal("VehicleId")) Then
                            objRec.VehicleId = 0
                        Else
                            objRec.VehicleId = objDR.GetInt32(objDR.GetOrdinal("VehicleId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("EnvelopeId")) Then
                            objRec.EnvelopeId = 0
                        Else
                            objRec.EnvelopeId = objDR.GetInt32(objDR.GetOrdinal("EnvelopeId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("RetId")) Then
                            objRec.RetId = 0
                        Else
                            objRec.RetId = objDR.GetInt32(objDR.GetOrdinal("RetId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("MktId")) Then
                            objRec.MktId = 0
                        Else
                            objRec.MktId = objDR.GetInt32(objDR.GetOrdinal("MktId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("BreakDt")) Then
                            objRec.BreakDt = DateTime.Now
                        Else
                            objRec.BreakDt = objDR.GetDateTime(objDR.GetOrdinal("BreakDt"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("StartDt")) Then
                            objRec.StartDt = CDate("")
                        Else
                            objRec.StartDt = objDR.GetDateTime(objDR.GetOrdinal("StartDt"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("EndDt")) Then
                            objRec.EndDt = DateTime.Now
                        Else
                            objRec.EndDt = objDR.GetDateTime(objDR.GetOrdinal("EndDt"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("TypeId")) Then
                            objRec.TypeId = 0
                        Else
                            objRec.TypeId = objDR.GetInt32(objDR.GetOrdinal("TypeId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("LanguageId")) Then
                            objRec.LanguageId = 0
                        Else
                            objRec.LanguageId = objDR.GetInt32(objDR.GetOrdinal("LanguageId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("EventId")) Then
                            objRec.EventId = 0
                        Else
                            objRec.EventId = objDR.GetInt32(objDR.GetOrdinal("EventId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("ThemeId")) Then
                            objRec.ThemeId = 0
                        Else
                            objRec.ThemeId = objDR.GetInt32(objDR.GetOrdinal("ThemeId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("MediaId")) Then
                            objRec.MediaId = 0
                        Else
                            objRec.MediaId = objDR.GetInt32(objDR.GetOrdinal("MediaId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("PublicationId")) Then
                            objRec.PublicationId = 0
                        Else
                            objRec.PublicationId = objDR.GetInt32(objDR.GetOrdinal("PublicationId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("FlashInd")) Then
                            objRec.FlashInd = 0
                        Else
                            objRec.FlashInd = objDR.GetByte(objDR.GetOrdinal("FlashInd"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("CreateDt")) Then
                            objRec.CreateDt = DateTime.Now
                        Else
                            objRec.CreateDt = objDR.GetDateTime(objDR.GetOrdinal("CreateDt"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("CreatedById")) Then
                            objRec.CreatedById = 0
                        Else
                            objRec.CreatedById = objDR.GetInt32(objDR.GetOrdinal("CreatedById"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("ScanDt")) Then
                            objRec.ScanDt = CDate("")
                        Else
                            objRec.ScanDt = objDR.GetDateTime(objDR.GetOrdinal("ScanDt"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("ScannedById")) Then
                            objRec.ScannedById = 0
                        Else
                            objRec.ScannedById = objDR.GetInt32(objDR.GetOrdinal("ScannedById"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("QCedById")) Then
                            objRec.QCedById = 0
                        Else
                            objRec.QCedById = objDR.GetInt32(objDR.GetOrdinal("QCedById"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("QCDt")) Then
                            objRec.QCDt = CDate("")
                        Else
                            objRec.QCDt = objDR.GetDateTime(objDR.GetOrdinal("QCDt"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("FamilyId")) Then
                            objRec.FamilyId = 0
                        Else
                            objRec.FamilyId = objDR.GetInt32(objDR.GetOrdinal("FamilyId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("CouponInd")) Then
                            objRec.CouponInd = 0
                        Else
                            objRec.CouponInd = objDR.GetByte(objDR.GetOrdinal("CouponInd"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("CreateSizedDt")) Then
                            objRec.CreateSizedDt = CDate("")
                        Else
                            objRec.CreateSizedDt = objDR.GetDateTime(objDR.GetOrdinal("CreateSizedDt"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("Priority")) Then
                            objRec.Priority = 0
                        Else
                            objRec.Priority = objDR.GetInt32(objDR.GetOrdinal("Priority"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("CheckInPageCount")) Then
                            objRec.CheckInPageCount = 0
                        Else
                            objRec.CheckInPageCount = objDR.GetInt32(objDR.GetOrdinal("CheckInPageCount"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("StatusID")) Then
                            objRec.StatusID = 0
                        Else
                            objRec.StatusID = objDR.GetInt32(objDR.GetOrdinal("StatusID"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("SenderId")) Then
                            objRec.SenderId = 0
                        Else
                            objRec.SenderId = objDR.GetInt32(objDR.GetOrdinal("SenderId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("PullDt")) Then
                            objRec.PullDt = DateTime.Now
                        Else
                            objRec.PullDt = objDR.GetDateTime(objDR.GetOrdinal("PullDt"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("PulledById")) Then
                            objRec.PulledById = 0
                        Else
                            objRec.PulledById = objDR.GetInt32(objDR.GetOrdinal("PulledById"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("PullPageCount")) Then
                            objRec.PullPageCount = 0
                        Else
                            objRec.PullPageCount = objDR.GetInt32(objDR.GetOrdinal("PullPageCount"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("Weight")) Then
                            objRec.Weight = CDec(0.0)
                        Else
                            objRec.Weight = objDR.GetDecimal(objDR.GetOrdinal("Weight"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("PullQCedById")) Then
                            objRec.PullQCedById = 0
                        Else
                            objRec.PullQCedById = objDR.GetInt32(objDR.GetOrdinal("PullQCedById"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("PullQCDt")) Then
                            objRec.PullQCDt = DateTime.Now
                        Else
                            objRec.PullQCDt = objDR.GetDateTime(objDR.GetOrdinal("PullQCDt"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("FormName")) Then
                            objRec.FormName = ""
                        Else
                            objRec.FormName = objDR.GetString(objDR.GetOrdinal("FormName"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("CheckInOccurrences")) Then
                            objRec.CheckInOccurrences = 0
                        Else
                            objRec.CheckInOccurrences = objDR.GetInt32(objDR.GetOrdinal("CheckInOccurrences"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("NationalInd")) Then
                            objRec.NationalInd = 0
                        Else
                            objRec.NationalInd = objDR.GetByte(objDR.GetOrdinal("NationalInd"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("ftpStatusId")) Then
                            objRec.ftpStatusId = 0
                        Else
                            objRec.ftpStatusId = objDR.GetInt32(objDR.GetOrdinal("ftpStatusId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("ftpDt")) Then
                            objRec.ftpDt = CDate("")
                        Else
                            objRec.ftpDt = objDR.GetDateTime(objDR.GetOrdinal("ftpDt"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("IndexDt")) Then
                            objRec.IndexDt = CDate("")
                        Else
                            objRec.IndexDt = objDR.GetDateTime(objDR.GetOrdinal("IndexDt"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("IndexedById")) Then
                            objRec.IndexedById = 0
                        Else
                            objRec.IndexedById = objDR.GetInt32(objDR.GetOrdinal("IndexedById"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("RemoteEntryImageFTPStatusId")) Then
                            objRec.RemoteEntryImageFTPStatusId = 0
                        Else
                            objRec.RemoteEntryImageFTPStatusId = objDR.GetInt32(objDR.GetOrdinal("RemoteEntryImageFTPStatusId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("RemoteEntryImageFTPDt")) Then
                            objRec.RemoteEntryImageFTPDt = CDate("")
                        Else
                            objRec.RemoteEntryImageFTPDt = objDR.GetDateTime(objDR.GetOrdinal("RemoteEntryImageFTPDt"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("RemoteEntryImageForceFTPRetransfer")) Then
                            objRec.RemoteEntryImageForceFTPRetransfer = 0
                        Else
                            objRec.RemoteEntryImageForceFTPRetransfer = objDR.GetByte(objDR.GetOrdinal("RemoteEntryImageForceFTPRetransfer"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("RemoteEntryImageFTPQueueInsertDt")) Then
                            objRec.RemoteEntryImageFTPQueueInsertDt = CDate("")
                        Else
                            objRec.RemoteEntryImageFTPQueueInsertDt = objDR.GetDateTime(objDR.GetOrdinal("RemoteEntryImageFTPQueueInsertDt"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("SPReviewStatusId")) Then
                            objRec.SPReviewStatusId = 0
                        Else
                            objRec.SPReviewStatusId = objDR.GetInt32(objDR.GetOrdinal("SPReviewStatusId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("EntryInd")) Then
                            objRec.EntryInd = 0
                        Else
                            objRec.EntryInd = objDR.GetByte(objDR.GetOrdinal("EntryInd"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("ParentVehicleId")) Then
                            objRec.ParentVehicleId = 0
                        Else
                            objRec.ParentVehicleId = objDR.GetInt32(objDR.GetOrdinal("ParentVehicleId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("BodyText")) Then
                            objRec.BodyText = ""
                        Else
                            objRec.BodyText = objDR.GetString(objDR.GetOrdinal("BodyText"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("BodyHTML")) Then
                            objRec.BodyHTML = ""
                        Else
                            objRec.BodyHTML = objDR.GetString(objDR.GetOrdinal("BodyHTML"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("SiteId")) Then
                            objRec.SiteId = 0
                        Else
                            objRec.SiteId = objDR.GetInt32(objDR.GetOrdinal("SiteId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("Subject")) Then
                            objRec.Subject = ""
                        Else
                            objRec.Subject = objDR.GetString(objDR.GetOrdinal("Subject"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("ReQCDt")) Then
                            objRec.ReQCDt = CDate("")
                        Else
                            objRec.ReQCDt = objDR.GetDateTime(objDR.GetOrdinal("ReQCDt"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("ReQCedById")) Then
                            objRec.ReQCedById = 0
                        Else
                            objRec.ReQCedById = objDR.GetInt32(objDR.GetOrdinal("ReQCedById"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("FilterMatches")) Then
                            objRec.FilterMatches = ""
                        Else
                            objRec.FilterMatches = objDR.GetString(objDR.GetOrdinal("FilterMatches"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("isReviewed")) Then
                            objRec.isReviewed = False
                        Else
                            objRec.isReviewed = objDR.GetBoolean(objDR.GetOrdinal("isReviewed"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("ReviewDt")) Then
                            objRec.ReviewDt = CDate("")
                        Else
                            objRec.ReviewDt = objDR.GetDateTime(objDR.GetOrdinal("ReviewDt"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("ReviewedByUserId")) Then
                            objRec.ReviewedByUserId = Guid.Empty
                        Else
                            objRec.ReviewedByUserId = objDR.GetGuid(objDR.GetOrdinal("ReviewedByUserId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("isQCed")) Then
                            objRec.isQCed = False
                        Else
                            objRec.isQCed = objDR.GetBoolean(objDR.GetOrdinal("isQCed"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("QCDate")) Then
                            objRec.QCDate = CDate("")
                        Else
                            objRec.QCDate = objDR.GetDateTime(objDR.GetOrdinal("QCDate"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("QCedByUserId")) Then
                            objRec.QCedByUserId = Guid.Empty
                        Else
                            objRec.QCedByUserId = objDR.GetGuid(objDR.GetOrdinal("QCedByUserId"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("QAComments")) Then
                            objRec.QAComments = ""
                        Else
                            objRec.QAComments = objDR.GetString(objDR.GetOrdinal("QAComments"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("DistDt")) Then
                            objRec.DistDt = CDate("")
                        Else
                            objRec.DistDt = objDR.GetDateTime(objDR.GetOrdinal("DistDt"))
                        End If
                        If objDR.IsDBNull(objDR.GetOrdinal("IndReadyForExport")) Then
                            objRec.IndReadyForExport = 0
                        Else
                            objRec.IndReadyForExport = objDR.GetByte(objDR.GetOrdinal("IndReadyForExport"))
                        End If
                        objRet.Add(objRec)
                    End While
                End Using
            End Using
        End Using
        Return objRet
    End Function

    Public Function InsertVehicle(ByVal objRecord As clsVehicle) As Boolean
        Dim objRet As Int32 = 0
        Try
            Using objCnn As New SqlConnection(GetConnectionStringForAppDB())
                objCnn.Open()
                Using objCmd As SqlCommand = objCnn.CreateCommand()
                    objCmd.CommandType = System.Data.CommandType.StoredProcedure
                    objCmd.CommandText = "[mt_proc_AddVehicle]"
                    objCmd.Parameters.Add("@VehicleId", SqlDbType.Int).Direction = ParameterDirection.Output
                    objCmd.Parameters.AddWithValue("@ParentVehicleId", objRecord.VehicleId)
                    objCmd.Parameters.AddWithValue("@EnvelopeId", objRecord.EnvelopeId)
                    objCmd.Parameters.AddWithValue("@RetId", objRecord.RetId)
                    objCmd.Parameters.AddWithValue("@MktId", objRecord.MktId)
                    objCmd.Parameters.AddWithValue("@BreakDt", objRecord.BreakDt)
                    objCmd.Parameters.AddWithValue("@StartDt", objRecord.StartDt)
                    objCmd.Parameters.AddWithValue("@EndDt", objRecord.EndDt)
                    objCmd.Parameters.AddWithValue("@TypeId", objRecord.TypeId)
                    objCmd.Parameters.AddWithValue("@LanguageId", objRecord.LanguageId)
                    objCmd.Parameters.AddWithValue("@EventId", objRecord.EventId)
                    objCmd.Parameters.AddWithValue("@ThemeId", objRecord.ThemeId)
                    objCmd.Parameters.AddWithValue("@MediaId", objRecord.MediaId)
                    objCmd.Parameters.AddWithValue("@PublicationId", objRecord.PublicationId)
                    objCmd.Parameters.AddWithValue("@FlashInd", objRecord.FlashInd)
                    objCmd.Parameters.AddWithValue("@CreateDt", objRecord.CreateDt)
                    objCmd.Parameters.AddWithValue("@CreatedById", objRecord.CreatedById)
                    objCmd.Parameters.AddWithValue("@ScanDt", objRecord.ScanDt)
                    objCmd.Parameters.AddWithValue("@ScannedById", objRecord.ScannedById)
                    objCmd.Parameters.AddWithValue("@QCedById", objRecord.QCedById)
                    objCmd.Parameters.AddWithValue("@QCDt", objRecord.QCDt)
                    objCmd.Parameters.AddWithValue("@FamilyId", objRecord.FamilyId)
                    objCmd.Parameters.AddWithValue("@CouponInd", objRecord.CouponInd)
                    objCmd.Parameters.AddWithValue("@CreateSizedDt", objRecord.CreateSizedDt)
                    objCmd.Parameters.AddWithValue("@Priority", objRecord.Priority)
                    objCmd.Parameters.AddWithValue("@CheckInPageCount", objRecord.CheckInPageCount)
                    objCmd.Parameters.AddWithValue("@StatusID", objRecord.StatusID)
                    objCmd.Parameters.AddWithValue("@SenderId", objRecord.SenderId)
                    objCmd.Parameters.AddWithValue("@PullDt", objRecord.PullDt)
                    objCmd.Parameters.AddWithValue("@PulledById", objRecord.PulledById)
                    objCmd.Parameters.AddWithValue("@PullPageCount", objRecord.PullPageCount)
                    objCmd.Parameters.AddWithValue("@Weight", objRecord.Weight)
                    objCmd.Parameters.AddWithValue("@PullQCedById", objRecord.PullQCedById)
                    objCmd.Parameters.AddWithValue("@PullQCDt", objRecord.PullQCDt)
                    objCmd.Parameters.AddWithValue("@FormName", objRecord.FormName)
                    objCmd.Parameters.AddWithValue("@CheckInOccurrences", objRecord.CheckInOccurrences)
                    objCmd.Parameters.AddWithValue("@NationalInd", objRecord.NationalInd)
                    objCmd.Parameters.AddWithValue("@ftpStatusId", objRecord.ftpStatusId)
                    objCmd.Parameters.AddWithValue("@ftpDt", objRecord.ftpDt)
                    objCmd.Parameters.AddWithValue("@IndexDt", objRecord.IndexDt)
                    objCmd.Parameters.AddWithValue("@IndexedById", objRecord.IndexedById)
                    objCmd.Parameters.AddWithValue("@RemoteEntryImageFTPStatusId", objRecord.RemoteEntryImageFTPStatusId)
                    objCmd.Parameters.AddWithValue("@RemoteEntryImageFTPDt", objRecord.RemoteEntryImageFTPDt)
                    objCmd.Parameters.AddWithValue("@RemoteEntryImageForceFTPRetransfer", objRecord.RemoteEntryImageForceFTPRetransfer)
                    objCmd.Parameters.AddWithValue("@RemoteEntryImageFTPQueueInsertDt", objRecord.RemoteEntryImageFTPQueueInsertDt)
                    objCmd.Parameters.AddWithValue("@SPReviewStatusId", objRecord.SPReviewStatusId)
                    objCmd.Parameters.AddWithValue("@EntryInd", objRecord.EntryInd)

                    objCmd.Parameters.AddWithValue("@BodyText", objRecord.BodyText)
                    objCmd.Parameters.AddWithValue("@BodyHTML", objRecord.BodyHTML)
                    objCmd.Parameters.AddWithValue("@SiteId", objRecord.SiteId)
                    objCmd.Parameters.AddWithValue("@Subject", objRecord.Subject)
                    objCmd.Parameters.AddWithValue("@ReQCDt", objRecord.ReQCDt)
                    objCmd.Parameters.AddWithValue("@ReQCedById", objRecord.ReQCedById)
                    objCmd.Parameters.AddWithValue("@FilterMatches", objRecord.FilterMatches)
                    objCmd.Parameters.AddWithValue("@isReviewed", objRecord.isReviewed)
                    objCmd.Parameters.AddWithValue("@ReviewDt", objRecord.ReviewDt)
                    objCmd.Parameters.AddWithValue("@ReviewedByUserId", ReviewedByUserId)
                    objCmd.Parameters.AddWithValue("@isQCed", objRecord.isQCed)
                    objCmd.Parameters.AddWithValue("@QCDate", objRecord.QCDate)
                    objCmd.Parameters.AddWithValue("@QCedByUserId", objRecord.QCedByUserId)
                    objCmd.Parameters.AddWithValue("@QAComments", objRecord.QAComments)
                    objCmd.Parameters.AddWithValue("@DistDt", objRecord.DistDt)
                    objCmd.Parameters.AddWithValue("@IndReadyForExport", objRecord.IndReadyForExport)

                    Dim newRow As Object = objCmd.ExecuteNonQuery()
                    Dim vehicleid As Integer = Convert.ToInt32(objCmd.Parameters("@vehicleid").Value)
                    If newRow IsNot Nothing Then
                        objRet = Convert.ToInt32(newRow)
                    End If
                End Using
            End Using
        Catch ex As SqlException
            MsgBox(ex.Message)
        End Try
        Return True
    End Function



    Private Function GetImagePath(ByVal YearMonth As String, ByVal LocationId As Integer, ByVal PathType As Integer) As String
        Dim imgPathCommand As System.Data.SqlClient.SqlCommand
        Dim obj As Object
        Dim Path As System.Text.StringBuilder


        imgPathCommand = New System.Data.SqlClient.SqlCommand
        Path = New System.Text.StringBuilder

        Try
            With imgPathCommand
                .CommandText = "SELECT path FROM ImagePath WHERE yearmonth=" + YearMonth + " AND LocationId=" + LocationId.ToString + " AND PathTypeid=" + PathType.ToString
                .CommandType = CommandType.Text
                .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                .Connection.Open()
                obj = .ExecuteScalar()
            End With
            If String.IsNullOrEmpty(CType(obj, String)) = True Then Exit Function
            Path.Append(CType(obj, String))
            Path.Append("\")
            Path.Append(YearMonth)
            Path.Append("\")
        Catch ex As Exception
            My.Application.Log.WriteException(ex)
        Finally
            If imgPathCommand.Connection.State <> ConnectionState.Closed Then imgPathCommand.Connection.Close()
        End Try

        Return Path.ToString()
    End Function

    Private Function GetPathType(ByVal _Type As String) As Integer
        Dim cmd As System.Data.SqlClient.SqlCommand
        Dim obj As New Object
        Dim _val As Integer

        cmd = New System.Data.SqlClient.SqlCommand

        Try
            With cmd
                .CommandText = "Select codeid from vwCode where codedescrip='" + _Type + "'"
                .CommandType = CommandType.Text
                .Connection = New System.Data.SqlClient.SqlConnection(GetConnectionStringForAppDB())
                .Connection.Open()
                obj = .ExecuteScalar()
            End With
            If String.IsNullOrEmpty(CType(obj, String)) = False Then _val = CType(obj, Integer)
        Catch ex As Exception
            Throw New ApplicationException("Unable to get the Path Type Id.", ex)
        Finally
            If cmd.Connection.State <> ConnectionState.Closed Then cmd.Connection.Close()
        End Try

        Return _val
    End Function

#End Region

End Class
