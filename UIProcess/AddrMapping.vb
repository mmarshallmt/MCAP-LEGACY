Imports System.ComponentModel
Imports System.Data.SqlTypes.SqlBoolean

Namespace UI.Processors
    Public Class AddrMapping
        Inherits BaseClass


#Region " Properties"
        ReadOnly dbo As New DAO()
        Public Property AC_Advertiser As String
        Public Property AC_RetID As Integer
        Public Property MT_Advertiser As String
        Public Property MT_RetID As Integer
        Public Property MT_Market As String
        Public Property MT_MktID As Integer
        Public Property Store_Address As String
        Public Property Store_City As String
        Public Property Store_State As String
        Public Property Store_Zip As String
        Public Property store_i As Integer
        Public Property StartDt As Nullable(Of Date)
        Public Property EndDt As Nullable(Of Date)
        Public Property hold_days As Integer
        Public Property PriorityCode As Integer
        Public Property ImportTypeID As Integer
        Public Property ImportMediaID As Integer
        Public Property FVRequired As Boolean
        Public Property IsMarketMap As Boolean
        Public Property Addr_ID As Integer
        Public Property comments As String
        Public Property celledit As Boolean
        Public Property AC_Market As String
        Public Property AC_MktID As Integer
#End Region

        Public Sub New()
            Initialize()
        End Sub
        Public Sub Initialize()

        End Sub

        Public Function PopulateAddrGrid(ByVal dt As Data.DataTable) As BindingList(Of AddrMapping)
            Dim AddrList As New BindingList(Of AddrMapping)
            Dim AddrObj As New AddrMapping

            If Not dt Is Nothing Then
                For Each dr As Data.DataRow In dt.Rows

                    AddrObj.AC_Advertiser = CStr(IIf(IsDBNull(dr("AC_Advertiser")), "", dr("AC_Advertiser")))
                    AddrObj.AC_RetID = CInt(IIf(IsDBNull(dr("AC_RetID")), 0, dr("AC_RetID")))
                    AddrObj.MT_Advertiser = CStr(IIf(IsDBNull(dr("MT_Advertiser")), "", dr("MT_Advertiser")))
                    AddrObj.MT_RetID = CInt(IIf(IsDBNull(dr("MT_RetID")), 0, dr("MT_RetID")))
                    AddrObj.MT_Market = CStr(IIf(IsDBNull(dr("MT_Market")), "", dr("MT_Market")))
                    AddrObj.MT_MktID = CInt(IIf(IsDBNull(dr("MT_MktID")), 0, dr("MT_MktID")))
                    AddrObj.Store_Address = CStr(IIf(IsDBNull(dr("Store_Address")), "", dr("Store_Address")))
                    AddrObj.Store_City = CStr(IIf(IsDBNull(dr("Store_City")), "", dr("Store_City")))
                    AddrObj.Store_State = CStr(IIf(IsDBNull(dr("Store_State")), "", dr("Store_State")))
                    AddrObj.Store_Zip = CStr(IIf(IsDBNull(dr("Store_Zip")), "0000", dr("Store_Zip")))
                    AddrObj.store_i = CInt(IIf(IsDBNull(dr("store_i")), 0, dr("store_i")))
                    If IsDBNull(dr("StartDt")) Then
                        AddrObj.StartDt = CType(Nothing, Date?)
                    Else
                        AddrObj.StartDt = CType(CStr(dr("StartDt")), Date?)

                    End If
                    If IsDBNull(dr("EndDt")) Then
                        AddrObj.EndDt = CType(Nothing, Date?)
                    Else
                        AddrObj.EndDt = CType(CStr(dr("EndDt")), Date?)

                    End If
                    AddrObj.hold_days = CInt(IIf(IsDBNull(dr("hold_days")), 0, dr("hold_days")))
                    AddrObj.PriorityCode = CInt(IIf(IsDBNull(dr("Priority")), 0, dr("Priority")))
                    AddrObj.ImportTypeID = CInt(IIf(IsDBNull(dr("ImportTypeID")), 0, dr("ImportTypeID")))
                    AddrObj.ImportMediaID = CInt(IIf(IsDBNull(dr("ImportMediaID")), 0, dr("ImportMediaID")))
                    AddrObj.FVRequired = CBool(IIf(IsDBNull(dr("FVRequired")), 0, dr("FVRequired")))
                    AddrObj.IsMarketMap = CBool(IIf(IsDBNull(dr("IsMarketMap")), 0, dr("IsMarketMap")))
                    AddrObj.Addr_ID = CInt(IIf(IsDBNull(dr("ImpID")), 0, dr("ImpID")))
                    AddrObj.comments = CStr(IIf(IsDBNull(dr("comments")), "", dr("comments")))

                    AddrObj.AC_Market = CStr(IIf(IsDBNull(dr("AC_Market")), "", dr("AC_Market")))
                    AddrObj.AC_MktID = CInt(IIf(IsDBNull(dr("AC_MktID")), 0, dr("AC_MktID")))

                    AddrList.Add(AddrObj.CopyObj)
                    AddrObj.Clear()
                Next
            End If

            Return AddrList
        End Function
        Public Function CopyObj() As AddrMapping
            Return CType(MemberwiseClone(), AddrMapping)
        End Function

        Public Sub Clear()
            AC_Advertiser = ""
            AC_RetID = 0
            MT_Advertiser = ""
            MT_RetID = 0
            MT_Market = ""
            MT_MktID = 0
            AC_MktID = 0
            AC_Market = ""
            Store_Address = ""
            Store_City = ""
            Store_State = ""
            Store_Zip = ""
            store_i = 0
            StartDt = Nothing
            EndDt = Nothing
            hold_days = 0
            PriorityCode = 0
            ImportTypeID = 0
            ImportMediaID = 0
            FVRequired = False
            IsMarketMap = False
            Addr_ID = 0
            comments = ""
        End Sub


#Region "Data Access Objects"
        Friend Function GetAddressFilters() As Data.DataSet
            Return dbo.GetAddressFilters
        End Function

        Friend Function GetMedia() As Data.DataSet
            Return dbo.GetMedia
        End Function

        Friend Function GetRetStores(ByVal ACRetID As Integer) As Data.DataSet
            Return dbo.GetRetStores(ACRetID)
        End Function

        Friend Function GetMappedAddress(ByVal ACRetID As Integer, ByVal MTRetID As Integer, ByVal Phase As Integer, ByVal MTMktID As Integer, ByVal StoreID As Integer) As Data.DataSet
            Return dbo.GetMappedAddress(ACRetID, MTRetID, Phase, MTMktID, StoreID)
        End Function

        Friend Function UpdateMappedAddress(ByVal a As Processors.AddrMapping, ByVal queryType As Integer) As Boolean
            Return dbo.UpdateMappedAddress(a.Addr_ID, a.AC_RetID, a.AC_Advertiser, a.MT_Advertiser, a.MT_RetID, a.MT_Market, a.MT_MktID, a.Store_Address,
                                        a.Store_City, a.Store_State, a.Store_Zip, a.store_i, a.StartDt, a.EndDt, a.hold_days, a.PriorityCode,
                                        CInt(a.ImportTypeID), a.ImportMediaID, Convert.ToInt32(a.FVRequired), Convert.ToInt32(a.IsMarketMap),
                                        queryType, Trim(a.comments), a.AC_Market, a.AC_MktID)
        End Function

        Friend Function DeleteMappedAddress(ByVal ImpIDlist As String) As Boolean
            Return dbo.DeleteMappedAddress(ImpIDlist)
        End Function

#End Region


    End Class
End Namespace
