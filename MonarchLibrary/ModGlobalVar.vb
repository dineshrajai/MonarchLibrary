Imports System.IO
Public Class ModGlobalVar
    Public Shared gv_userID As Long
    Public Shared gv_username As String
    Public Shared gv_fileno As String
    Public Shared gv_AssesseeId As Long
    Public Shared gv_AssesseeName As String
    Public Shared gv_statusId As Long
    Public Shared gv_asstYearId As Long
    Public Shared gv_fromYear As Integer
    Public Shared gv_toYear As Integer
    Public Shared gv_fromDate As Date
    Public Shared gv_todate As Date
    Public Shared gv_FirmID As Long
    Public Shared gv_FirmName As String
    Public Shared gv_Version As Double
    Public Shared gv_FormTag As String
    Public Shared gv_ReStatus As Long
    Public Shared gv_ITR As String
    Public Shared gv_PrintFirm As Boolean
    Public Shared gv_FirmContact As String
    Public Shared gv_SoftwareBy As String = "www.i-tax.in - (0261) 2418983/84/85/86"
    Public Shared gv_ApplyDTAA As Boolean
    Public Shared gv_PreparationDate As Date
    Public Shared gv_DueDate As Date
    Public Shared gv_IsExtended As Boolean
    'TDS
    Public Shared gv_FyfromYear As Integer
    Public Shared gv_FytoYear As Integer
    Public Shared _writer As New StreamWriter(Application.StartupPath & "\log\userlog" & Format(Now(), "ddMMyyhhmmsstt") & ".txt")
End Class
