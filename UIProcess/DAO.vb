Imports System.Data.SqlClient
Imports System.Data
Imports System.Xml
Imports System.Collections

Public Class DAO
    'Class Data Access Object 

    Public Function GetAddressFilters() As Data.DataSet
        Try
            Using objCnn As New SqlConnection(GetConnectionStringForAppDB)
                Using ds As DataSet = SqlHelper.ExecuteDataset(objCnn, "MT_proc_GetAddressFilters")
                    Return ds
                End Using
            End Using
        Catch ex As Exception
            MsgBox("An exception occurred:" & vbCrLf & ex.Message)
        End Try

    End Function
    Function GetMappedAddress(ByVal ACRetID As Integer, ByVal MTRetID As Integer, ByVal Phase As Integer, ByVal MTMktID As Integer, ByVal StoreID As Integer) As DataSet 'load recods based on filters 
        Try
            Using objCnn As New SqlConnection(GetConnectionStringForAppDB)
                Using ds As DataSet = SqlHelper.ExecuteDataset(objCnn, CommandType.StoredProcedure, "MT_proc_GetMasterACFVAddress",
                                                               New SqlParameter("@ACRetailer_i", ACRetID),
                                                               New SqlParameter("@MTRetid", MTRetID),
                                                               New SqlParameter("@Mktid", MTMktID),
                                                               New SqlParameter("@phase", Phase),
                                                               New SqlParameter("@store_i", StoreID),
                                                               New SqlParameter("@debug", 1))
                    Return ds
                End Using
            End Using
        Catch ex As Exception
            MsgBox("An exception occurred:" & vbCrLf & ex.Message)
        End Try

    End Function

    Public Function GetMedia() As Data.DataSet
        Try
            Using objCnn As New SqlConnection(GetConnectionStringForAppDB)
                Using ds As DataSet = SqlHelper.ExecuteDataset(objCnn, "MT_proc_GetMediaforMappedAddress")
                    Return ds
                End Using
            End Using
        Catch ex As Exception
            MsgBox("An exception occurred:" & vbCrLf & ex.Message)
        End Try

    End Function

    Function GetRetStores(ByVal ACRetID As Integer) As DataSet 'load stores based on the current retailers 
        Try
            Using objCnn As New SqlConnection(GetConnectionStringForAppDB)
                Using ds As DataSet = SqlHelper.ExecuteDataset(objCnn, CommandType.StoredProcedure, "MT_proc_GetRetStores", _
                                                               New SqlParameter("@ACRetailer_i", ACRetID))
                    Return ds
                End Using
            End Using
        Catch ex As Exception
            MsgBox("An exception occurred:" & vbCrLf & ex.Message)
        End Try

    End Function


    Public Function UpdateMappedAddress(ByVal ImpID As Integer, ByVal AC_RetID As Integer, ByVal AC_Advertiser As String, ByVal MT_Advertiser As String,
                                        ByVal MT_RetID As Integer, ByVal MT_Market As String, ByVal MT_MktID As Integer, ByVal Store_Address As String,
                                        ByVal Store_City As String, ByVal Store_State As String, ByVal Store_Zip As String, ByVal store_i As Integer,
                                        ByVal StartDt As Nullable(Of Date), ByVal EndDt As Nullable(Of Date), ByVal hold_days As Integer, ByVal PriorityCode As Integer,
                                        ByVal ImportType As Integer, ByVal ImportMediaID As Integer, ByVal FVRequired As Integer, ByVal IsMarketMap As Integer,
                                        ByVal queryType As Integer, ByVal comments As String, ByVal AC_Market As String, ByVal AC_MktID As Integer) As Boolean

        Using objCnn As New SqlConnection(GetConnectionStringForAppDB)
            SqlHelper.ExecuteNonQuery(
                objCnn, CommandType.StoredProcedure, "MT_proc_UpdateMappedAddress",
                                                    New SqlParameter("@ImpID", ImpID),
                                                    New SqlParameter("@AC_RetID", AC_RetID),
                                                    New SqlParameter("@AC_Advertiser", AC_Advertiser),
                                                    New SqlParameter("@MT_Advertiser", MT_Advertiser),
                                                    New SqlParameter("@MT_RetID", MT_RetID),
                                                    New SqlParameter("@MT_Market", MT_Market),
                                                    New SqlParameter("@MT_MktID", MT_MktID),
                                                    New SqlParameter("@Store_Address", Store_Address),
                                                    New SqlParameter("@Store_City", Store_City),
                                                    New SqlParameter("@Store_State", Store_State),
                                                    New SqlParameter("@Store_Zip", Store_Zip),
                                                    New SqlParameter("@store_i", store_i),
                                                    New SqlParameter("@StartDt", StartDt),
                                                    New SqlParameter("@EndDt", EndDt),
                                                    New SqlParameter("@hold_days", hold_days),
                                                    New SqlParameter("@PriorityCode", PriorityCode),
                                                    New SqlParameter("@ImportType", ImportType),
                                                    New SqlParameter("@ImportMediaID", ImportMediaID),
                                                    New SqlParameter("@FVRequired", FVRequired),
                                                    New SqlParameter("@IsMarketMap", IsMarketMap),
                                                    New SqlParameter("@queryType", queryType),
                                                    New SqlParameter("@Comment", comments),
                                                    New SqlParameter("@AC_Market", AC_Market),
                                                    New SqlParameter("@AC_MktID", AC_MktID))
            Return CBool(1)
        End Using
    End Function

    Public Function DeleteMappedAddress(ByVal ImpIDList As String) As Boolean

        Using objCnn As New SqlConnection(GetConnectionStringForAppDB)
            SqlHelper.ExecuteNonQuery(
                objCnn, CommandType.StoredProcedure, "MT_proc_DeleteRecordFromMappedAddress",
                                                    New SqlParameter("@ImpID", ImpIDList))
            Return CBool(1)
        End Using

    End Function




End Class

