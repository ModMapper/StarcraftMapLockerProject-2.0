Public Class SettingForm
    Private Loading As Boolean = True

    Private Sub SettingForm_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If Loading Then
            AboutForm.Text = GetLanguage(Language, "About")
            OpenFolderL.Text = GetLanguage(Language, "OpenFolder")
            SaveFolderL.Text = GetLanguage(Language, "SaveFolder")
            UseSMLPO.Text = GetLanguage(Language, "SMLPFolder")
            UseLastFolderO.Text = GetLanguage(Language, "LastFolder")
            UseSettingO.Text = GetLanguage(Language, "SettingFolder")
            UpdateF.Text = GetLanguage(Language, "Update")
            UpdateC.Text = GetLanguage(Language, "Update")
            FileVersionL.Text = GetLanguage(Language, "FileVer") & " : " & Version
            WebVersionL.Text = GetLanguage(Language, "WebVer") & " : " & WebVersion
            AutoUpdateC.Text = GetLanguage(Language, "AutoUpdate")
            WavCompF.Text = GetLanguage(Language, "WavComp")
            WavCompHO.Text = GetLanguage(Language, "WavHigh")
            WavCompMO.Text = GetLanguage(Language, "WavMiddle")
            WavCompLO.Text = GetLanguage(Language, "WavLow")
            BackupF.Text = GetLanguage(Language, "Backup")
            FileBackupC.Text = GetLanguage(Language, "BackupFile")
            PasswordBackupC.Text = GetLanguage(Language, "BackupPW")
            ProtectF.Text = GetLanguage(Language, "Protect")
            ChkProtectC.Text = GetLanguage(Language, "ChkProtect")
            MPQProtectC.Text = GetLanguage(Language, "MPQProtect")
            UnprotectC.Text = GetLanguage(Language, "SaveUnprotectData")
            Notice.Text = GetLanguage(Language, "Notice")
            LanguageF.Text = GetLanguage(Language, "Language")
            ResetAll.Text = GetLanguage(Language, "Reset")
            CancelC.Text = GetLanguage(Language, "Cancel")
            OKC.Text = GetLanguage(Language, "OK")
            OpenForlderT.Text = OpenFolder
            SaveFolderT.Text = SaveFolder
            UseSMLPO.Checked = (SetFolder = 1)
            UseLastFolderO.Checked = (SetFolder = 2)
            UseSettingO.Checked = (SetFolder = 3)
            AutoUpdateC.Checked = AutoUpdate
            WavCompHO.Checked = (WavCompression = 1)
            WavCompMO.Checked = (WavCompression = 0)
            WavCompLO.Checked = (WavCompression = 2)
            FileBackupC.Checked = FileBackup
            PasswordBackupC.Checked = PasswordBackup
            ChkProtectC.Checked = ChkProtect
            MPQProtectC.Checked = MPQProtect
            UnprotectC.Checked = SaveUnprotectData
            LanguageC.SelectedIndex = Language
            Loading = False
        End If
    End Sub

    Private Sub SettingForm_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        MainForm.AddMessage(GetLanguage(Language, "Msg_SettingOff"))
        MainForm.Enabled = True
    End Sub

    Private Sub SettingForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        For i = 0 To MaxLanguage - 1
            LanguageC.Items.Add(GetLanguage(i, "Name"))
        Next
    End Sub

    Private Sub UpdateC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles UpdateC.Click
        If My.Computer.Network.IsAvailable AndAlso My.Computer.Network.Ping(Server) Then
            Dim WebClient As New Net.WebClient
            Dim FileChange As System.IO.StreamWriter
            WebClient.DownloadFile(UpdateURL, "UD.exe")
            FileChange = New System.IO.StreamWriter("UD.cmd", False, System.Text.Encoding.Default)
            FileChange.WriteLine("copy /y /b UD.exe /b " & Application.ExecutablePath)
            FileChange.WriteLine("erase SFmpq.dll")
            FileChange.WriteLine("erase Storm.dll")
            FileChange.WriteLine("start " & Application.ExecutablePath)
            FileChange.WriteLine("erase UD.exe")
            FileChange.WriteLine("erase UD.cmd")
            FileChange.Close()
            Shell("cmd /c " & Application.StartupPath & "\ud.cmd", AppWinStyle.Hide)
            End
        Else
            MainForm.AddMessage(GetLanguage(Language, "Msg_InternetConnection"))
        End If
    End Sub

    Private Sub ResetAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ResetAll.Click
        OpenForlderT.Text = Application.StartupPath & "\"
        SaveFolderT.Text = Application.StartupPath & "\"
        UseSMLPO.Checked = True
        UseLastFolderO.Checked = False
        UseSettingO.Checked = False
        AutoUpdateC.Checked = AutoUpdate
        WavCompHO.Checked = True
        WavCompMO.Checked = False
        WavCompLO.Checked = False
        FileBackupC.Checked = True
        PasswordBackupC.Checked = True
        ChkProtectC.Checked = True
        MPQProtectC.Checked = True
        UnprotectC.Checked = True
        LanguageC.SelectedIndex = 0
    End Sub

    Private Sub CancelC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CancelC.Click
        Me.Close()
    End Sub

    Private Sub OKC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OKC.Click
        OpenFolder = OpenForlderT.Text
        SaveFolder = SaveFolderT.Text
        If UseSMLPO.Checked Then SetFolder = 1
        If UseLastFolderO.Checked Then SetFolder = 2
        If UseSettingO.Checked Then SetFolder = 3
        AutoUpdate = AutoUpdateC.Checked
        If WavCompHO.Checked Then WavCompression = 1
        If WavCompMO.Checked Then WavCompression = 0
        If WavCompLO.Checked Then WavCompression = 2
        FileBackup = FileBackupC.Checked
        PasswordBackup = PasswordBackupC.Checked
        Language = LanguageC.SelectedIndex
        ChkProtect = ChkProtectC.Checked
        MPQProtect = MPQProtectC.Checked
        SaveUnprotectData = UnprotectC.Checked
        MainForm.OpenC.Text = GetLanguage(Language, "Open")
        MainForm.SaveC.Text = GetLanguage(Language, "Save")
        MainForm.ProtectC.Text = GetLanguage(Language, "Protect")
        MainForm.UnprotectC.Text = GetLanguage(Language, "Unprotect")
        MainForm.SettingC.Text = GetLanguage(Language, "Setting")
        MainForm.AboutC.Text = GetLanguage(Language, "About")
        MainForm.PasswordF.Text = GetLanguage(Language, "Password")
        MainForm.PasswordC.Text = GetLanguage(Language, "Password")
        MainForm.PasswordT.Text = GetLanguage(Language, "PWWrite")
        Call SaveSettings()
        Me.Close()
    End Sub

    Private Sub OpenFolderC_Click(sender As Object, e As EventArgs) Handles OpenFolderC.Click
        FolderBrowser.SelectedPath = OpenForlderT.Text
        FolderBrowser.ShowDialog()
        OpenForlderT.Text = FolderBrowser.SelectedPath
    End Sub

    Private Sub SaveFolderC_Click(sender As Object, e As EventArgs) Handles SaveFolderC.Click
        FolderBrowser.SelectedPath = SaveFolderT.Text
        FolderBrowser.ShowDialog()
        SaveFolderT.Text = FolderBrowser.SelectedPath
    End Sub
End Class