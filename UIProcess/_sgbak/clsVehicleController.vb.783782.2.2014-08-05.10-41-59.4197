
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.Data.SqlClient

Namespace BusinessLayer
    Public Class clsVehicleController


#Region "Constructor"
        Public Sub New()
        End Sub
#End Region

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
        Public Property BreakDt() As System.DateTime
            Get
                Return _BreakDt
            End Get
            Set(ByVal value As System.DateTime)
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
        Public Function [Select]() As Object


            Try
                'item = New clsVehicleController()
                objclsVehicle = New clsVehicle()
                objclsVehicle.VehicleId = VehicleId

                Return objclsVehicle.Fetch(VehicleId)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Public Function Insert() As Boolean
            Try
                objclsVehicle = New clsVehicle()
                objclsVehicle.VehicleId = VehicleId
                objclsVehicle.EnvelopeId = EnvelopeId
                objclsVehicle.RetId = RetId
                objclsVehicle.MktId = MktId
                objclsVehicle.BreakDt = BreakDt
                objclsVehicle.StartDt = StartDt
                objclsVehicle.EndDt = EndDt
                objclsVehicle.TypeId = TypeId
                objclsVehicle.LanguageId = LanguageId
                objclsVehicle.EventId = EventId
                objclsVehicle.ThemeId = ThemeId
                objclsVehicle.MediaId = MediaId
                objclsVehicle.PublicationId = PublicationId
                objclsVehicle.FlashInd = FlashInd
                objclsVehicle.CreateDt = CreateDt
                objclsVehicle.CreatedById = CreatedById
                objclsVehicle.ScanDt = ScanDt
                objclsVehicle.ScannedById = ScannedById
                objclsVehicle.QCedById = QCedById
                objclsVehicle.QCDt = QCDt
                objclsVehicle.FamilyId = FamilyId
                objclsVehicle.CouponInd = CouponInd
                objclsVehicle.CreateSizedDt = CreateSizedDt
                objclsVehicle.Priority = Priority
                objclsVehicle.CheckInPageCount = CheckInPageCount
                objclsVehicle.StatusID = StatusID
                objclsVehicle.SenderId = SenderId
                objclsVehicle.PullDt = PullDt
                objclsVehicle.PulledById = PulledById
                objclsVehicle.PullPageCount = PullPageCount
                objclsVehicle.Weight = Weight
                objclsVehicle.PullQCedById = PullQCedById
                objclsVehicle.PullQCDt = PullQCDt
                objclsVehicle.FormName = FormName
                objclsVehicle.CheckInOccurrences = CheckInOccurrences
                objclsVehicle.NationalInd = NationalInd
                objclsVehicle.ftpStatusId = ftpStatusId
                objclsVehicle.ftpDt = ftpDt
                objclsVehicle.IndexDt = IndexDt
                objclsVehicle.IndexedById = IndexedById
                objclsVehicle.RemoteEntryImageFTPStatusId = RemoteEntryImageFTPStatusId
                objclsVehicle.RemoteEntryImageFTPDt = RemoteEntryImageFTPDt
                objclsVehicle.RemoteEntryImageForceFTPRetransfer = RemoteEntryImageForceFTPRetransfer
                objclsVehicle.RemoteEntryImageFTPQueueInsertDt = RemoteEntryImageFTPQueueInsertDt
                objclsVehicle.SPReviewStatusId = SPReviewStatusId
                objclsVehicle.EntryInd = EntryInd
                objclsVehicle.ParentVehicleId = ParentVehicleId
                objclsVehicle.BodyText = BodyText
                objclsVehicle.BodyHTML = BodyHTML
                objclsVehicle.SiteId = SiteId
                objclsVehicle.Subject = Subject
                objclsVehicle.ReQCDt = ReQCDt
                objclsVehicle.ReQCedById = ReQCedById
                objclsVehicle.FilterMatches = FilterMatches
                objclsVehicle.isReviewed = isReviewed
                objclsVehicle.ReviewDt = ReviewDt
                objclsVehicle.ReviewedByUserId = ReviewedByUserId
                objclsVehicle.isQCed = isQCed
                objclsVehicle.QCDate = QCDate
                objclsVehicle.QCedByUserId = QCedByUserId
                objclsVehicle.QAComments = QAComments
                objclsVehicle.DistDt = DistDt
                objclsVehicle.IndReadyForExport = IndReadyForExport
                objclsVehicle.ParentVehicleId = ParentVehicleId

                If objclsVehicle.InsertVehicle(objclsVehicle) Then
                    Return True
                End If

                Return False
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
        'Public Function Update() As Boolean
        '    Try
        '        objclsVehicle = New clsVehicle()

        '        objclsVehicle.VehicleId = VehicleId
        '        objclsVehicle.EnvelopeId = EnvelopeId
        '        objclsVehicle.RetId = RetId
        '        objclsVehicle.MktId = MktId
        '        objclsVehicle.BreakDt = BreakDt
        '        objclsVehicle.StartDt = StartDt
        '        objclsVehicle.EndDt = EndDt
        '        objclsVehicle.TypeId = TypeId
        '        objclsVehicle.LanguageId = LanguageId
        '        objclsVehicle.EventId = EventId
        '        objclsVehicle.ThemeId = ThemeId
        '        objclsVehicle.MediaId = MediaId
        '        objclsVehicle.PublicationId = PublicationId
        '        objclsVehicle.FlashInd = FlashInd
        '        objclsVehicle.CreateDt = CreateDt
        '        objclsVehicle.CreatedById = CreatedById
        '        objclsVehicle.ScanDt = ScanDt
        '        objclsVehicle.ScannedById = ScannedById
        '        objclsVehicle.QCedById = QCedById
        '        objclsVehicle.QCDt = QCDt
        '        objclsVehicle.FamilyId = FamilyId
        '        objclsVehicle.CouponInd = CouponInd
        '        objclsVehicle.CreateSizedDt = CreateSizedDt
        '        objclsVehicle.Priority = Priority
        '        objclsVehicle.CheckInPageCount = CheckInPageCount
        '        objclsVehicle.StatusID = StatusID
        '        objclsVehicle.SenderId = SenderId
        '        objclsVehicle.PullDt = PullDt
        '        objclsVehicle.PulledById = PulledById
        '        objclsVehicle.PullPageCount = PullPageCount
        '        objclsVehicle.Weight = Weight
        '        objclsVehicle.PullQCedById = PullQCedById
        '        objclsVehicle.PullQCDt = PullQCDt
        '        objclsVehicle.FormName = FormName
        '        objclsVehicle.CheckInOccurrences = CheckInOccurrences
        '        objclsVehicle.NationalInd = NationalInd
        '        objclsVehicle.ftpStatusId = ftpStatusId
        '        objclsVehicle.ftpDt = ftpDt
        '        objclsVehicle.IndexDt = IndexDt
        '        objclsVehicle.IndexedById = IndexedById
        '        objclsVehicle.RemoteEntryImageFTPStatusId = RemoteEntryImageFTPStatusId
        '        objclsVehicle.RemoteEntryImageFTPDt = RemoteEntryImageFTPDt
        '        objclsVehicle.RemoteEntryImageForceFTPRetransfer = RemoteEntryImageForceFTPRetransfer
        '        objclsVehicle.RemoteEntryImageFTPQueueInsertDt = RemoteEntryImageFTPQueueInsertDt
        '        objclsVehicle.SPReviewStatusId = SPReviewStatusId
        '        objclsVehicle.EntryInd = EntryInd
        '        objclsVehicle.ParentVehicleId = ParentVehicleId
        '        objclsVehicle.BodyText = BodyText
        '        objclsVehicle.BodyHTML = BodyHTML
        '        objclsVehicle.SiteId = SiteId
        '        objclsVehicle.Subject = Subject
        '        objclsVehicle.ReQCDt = ReQCDt
        '        objclsVehicle.ReQCedById = ReQCedById
        '        objclsVehicle.FilterMatches = FilterMatches
        '        objclsVehicle.isReviewed = isReviewed
        '        objclsVehicle.ReviewDt = ReviewDt
        '        objclsVehicle.ReviewedByUserId = ReviewedByUserId
        '        objclsVehicle.isQCed = isQCed
        '        objclsVehicle.QCDate = QCDate
        '        objclsVehicle.QCedByUserId = QCedByUserId
        '        objclsVehicle.QAComments = QAComments
        '        objclsVehicle.DistDt = DistDt
        '        objclsVehicle.IndReadyForExport = IndReadyForExport

        '        If objclsVehicle.Update() Then
        '            Return True
        '        End If
        '        Return False
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message)
        '    End Try
        'End Function

        'Public Function Delete() As Boolean
        '    Try
        '        objclsVehicle = New clsVehicle()

        '        objclsVehicle.VehicleId = VehicleId

        '        If objclsVehicle.Delete() Then
        '            Return True
        '        End If
        '        Return False
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message)
        '    End Try
        'End Function
#End Region

    End Class
End Namespace
