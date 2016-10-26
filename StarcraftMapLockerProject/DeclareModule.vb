Module DeclareModule
#Region "업데이트" '삭제됨 (Deleted)
    Public Const UpdateURL As String = ""
    Public Const VersionURL As String = ""
    Public Const StormURL As String = ""
    Public Const SFmpqURL As String = ""
    Public Const Server As String = ""
#End Region

    Public Const Version As String = "2.0.00"
    Private Key As Microsoft.Win32.RegistryKey
    Public WebVersion As String
    Public AutoUpdate As Boolean = True
    Public OpenFolder As String = Application.StartupPath & "\"
    Public SaveFolder As String = Application.StartupPath & "\"
    Public LastFolder As String = Application.StartupPath & "\"
    Public SetFolder As Integer = 1
    Public WavCompression As Integer = 1
    Public FileBackup As Boolean = False
    Public PasswordBackup As Boolean = True
    Public Language As Integer = -1
    Public ChkProtect As Boolean = True
    Public MPQProtect As Boolean = True
    Public SaveUnprotectData As Boolean = False

    Public Sub LoadSettings()
        Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software").CreateSubKey("StarcraftMapLockerProject")
        AutoUpdate = Key.GetValue("AutoUpdate", AutoUpdate)
        OpenFolder = Key.GetValue("OpenFolder", OpenFolder)
        SaveFolder = Key.GetValue("SaveFolder", SaveFolder)
        LastFolder = Key.GetValue("LastFolder", LastFolder)
        SetFolder = Key.GetValue("SetFolder", SetFolder)
        WavCompression = Key.GetValue("WavCompression", WavCompression)
        FileBackup = Key.GetValue("FileBackup", FileBackup)
        PasswordBackup = Key.GetValue("PasswordBackup", PasswordBackup)
        Language = Key.GetValue("Language", GetLocaleLanguage)
        ChkProtect = Key.GetValue("ChkProtect", ChkProtect)
        MPQProtect = Key.GetValue("MPQProtect", MPQProtect)
        SaveUnprotectData = Key.GetValue("SaveUnprotectData", SaveUnprotectData)
    End Sub

    Public Sub SaveSettings()
        Key.SetValue("AutoUpdate", AutoUpdate)
        Key.SetValue("OpenFolder", OpenFolder)
        Key.SetValue("SaveFolder", SaveFolder)
        Key.SetValue("LastFolder", LastFolder)
        Key.SetValue("SetFolder", SetFolder)
        Key.SetValue("WavCompression", WavCompression)
        Key.SetValue("FileBackup", FileBackup)
        Key.SetValue("PasswordBackup", PasswordBackup)
        Key.SetValue("Language", Language)
        Key.SetValue("ChkProtect", ChkProtect)
        Key.SetValue("MPQProtect", MPQProtect)
        Key.SetValue("SaveUnprotectData", SaveUnprotectData)
    End Sub

    Private Function GetLocaleLanguage() As Integer
        Dim i As Integer
        For i = 0 To MaxLanguage - 1
            If UCase(GetLanguage(i, "Locale")) = UCase(System.Globalization.CultureInfo.InstalledUICulture.Name) Then Return i
        Next
        Return 0
    End Function
End Module
