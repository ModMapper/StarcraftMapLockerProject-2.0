Public Class MainForm
    Private ChkProtected As Boolean
    Private MPQProtected As Boolean
    Private OpenCommand As Boolean
    Private MPQFile As Boolean
    Private Protect As Boolean
    Private Chunk As ChunkData
    Private Wav() As MPQFIle
    Private DH As Integer

    Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        DH = Me.Height
        Me.Height = DH - 46
        Call MPQ_Init()
        Call InitLanguage()
        Call LoadSettings()
        Me.Icon = My.Resources.Icon
        OpenC.Text = GetLanguage(Language, "Open")
        SaveC.Text = GetLanguage(Language, "Save")
        ProtectC.Text = GetLanguage(Language, "Protect")
        UnprotectC.Text = GetLanguage(Language, "Unprotect")
        SettingC.Text = GetLanguage(Language, "Setting")
        AboutC.Text = GetLanguage(Language, "About")
        PasswordF.Text = GetLanguage(Language, "Password")
        PasswordC.Text = GetLanguage(Language, "Password")
        PasswordT.Text = GetLanguage(Language, "PWWrite")
        AddMessage("SMLP Ver. " & Version & " Loaded")
        Dim WebClient As New Net.WebClient
        If My.Computer.Network.IsAvailable AndAlso My.Computer.Network.Ping(Server) Then
            WebVersion = WebClient.DownloadString(VersionURL)
            If AutoUpdate Then
                AddMessage(GetLanguage(Language, "Msg_CheckUpdate"))
                If WebVersion <> Version Then
                    Dim FileChange As System.IO.StreamWriter
                    AddMessage(GetLanguage(Language, "Msg_NewUpdate"))
                    WebClient.DownloadFile(UpdateURL, "UD.exe")
                    FileChange = New System.IO.StreamWriter("UD.cmd", False, System.Text.Encoding.Default)
                    FileChange.WriteLine("copy /y /b UD.exe /b """ & Application.ExecutablePath & """")
                    FileChange.WriteLine("erase SFmpq.dll")
                    FileChange.WriteLine("erase Storm.dll")
                    FileChange.WriteLine("start """ & Application.ExecutablePath & """" & Command())
                    FileChange.WriteLine("erase UD.exe")
                    FileChange.WriteLine("erase UD.cmd")
                    FileChange.Close()
                    Shell("cmd /c " & Application.StartupPath & "\ud.cmd", AppWinStyle.Hide)
                    End
                End If
                AddMessage(GetLanguage(Language, "Msg_CheckComplete"))
            End If
        Else
            AddMessage(GetLanguage(Language, "Msg_InternetConnection"))
            WebVersion = "Connection Error"
        End If
        If Not Command() = "" Then
            OpenCommand = True
            OpenC_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub AboutC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AboutC.Click
        AboutForm.Show()
        AddMessage(GetLanguage(Language, "Msg_AboutOn"))
        Me.Enabled = False
    End Sub

    Private Sub SettingC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SettingC.Click
        SettingForm.Show()
        AddMessage(GetLanguage(Language, "Msg_SettingOn"))
        Me.Enabled = False
    End Sub

    Private Sub PasswordC_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PasswordC.CheckedChanged
        PasswordT.Enabled = PasswordC.Checked
    End Sub

    Public Sub AddMessage(ByVal Msg As String)
        MassageL.Items.Add(Msg)
        If MassageL.Items.Count = 14 Then MassageL.Items.RemoveAt(0)
    End Sub

    Private Function CompareByteArray(ByVal Data1() As Byte, ByVal Data2() As Byte) As Boolean
        Dim i As Integer
        If Data1 Is Nothing And Data2 Is Nothing Then Return True
        If Not Data1.Length = Data2.Length Then Return False
        For i = 0 To Data1.Length - 1
            If Not Data1(i) = Data2(i) Then Return False
        Next
        Return True
    End Function

    Private Sub OpenC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OpenC.Click
        Dim ByteData() As Byte, MPQ As IntPtr, index As Integer
        If Not OpenCommand Then
            If SetFolder = 1 Then OpenFile.InitialDirectory = Application.StartupPath & "\"
            If SetFolder = 2 Then OpenFile.InitialDirectory = LastFolder
            If SetFolder = 3 Then OpenFile.InitialDirectory = OpenFolder
            AddMessage(GetLanguage(Language, "Msg_MapOpen"))
            OpenFile.Filter = GetLanguage(Language, "FilterOpen")
            OpenFile.Title = GetLanguage(Language, "Msg_MapOpen")
            OpenFile.FileName = ""
            OpenFile.ShowDialog()
            If OpenFile.FileName = "" Then Exit Sub
        Else
            OpenFile.FileName = Command()
        End If
        LastFolder = Mid(OpenFile.FileName, 1, InStrRev(OpenFile.FileName, "\"))
        Call SaveSettings()
        If Not LCase(Microsoft.VisualBasic.Right(OpenFile.FileName, 4)) = ".chk" Then
            AddMessage(GetLanguage(Language, "Msg_MPQReadStart"))
            MPQ = MPQRead_OpenMPQ(OpenFile.FileName)
            AddMessage(GetLanguage(Language, "Msg_MPQReadEnd"))
            ByteData = MPQRead_ReadFile(MPQ, ChunkPath)
            If ByteData Is Nothing Then
            End If
            MPQFile = True
        Else
            ByteData = System.IO.File.ReadAllBytes(OpenFile.FileName)
            AddMessage(GetLanguage(Language, "Msg_ChunkReadStart"))
            MPQFile = False
        End If
        Chunk = New ChunkData(ByteData)
        If MPQFile Then
            Dim WavPath() As UShort, Str As String, i As Integer
            WavPath = Chunk.GetWavList()
            If Not WavPath Is Nothing Then
                ReDim Wav(WavPath.Length - 1)
                For i = 0 To WavPath.Length - 1
                    Str = Chunk.GetString(WavPath(i))
                    Wav(i).FileName = Str
                    Wav(i).FileData = MPQRead_ReadFile(MPQ, Str)
                Next
            End If
        End If
        AddMessage(GetLanguage(Language, "Msg_ChunkReadEnd"))
        MPQRead_CloseMPQ(MPQ)
        '패스워드 사용 체크 루틴
        index = Chunk.GetSectionIndex("DATA")
        Protect = False
        If 0 <= index Then
            Select Case Chunk.SectionReader(index).ReadByte
                Case &H0, &H3, &H5
                    AddMessage(GetLanguage(Language, "Msg_ReadP"))
                    Exit Sub
                Case &H1, &H2, &H4, &H6, &H7
                    Protect = True
                Case &HFF
                    AboutForm.Show()
                    AddMessage(GetLanguage(Language, "Msg_AboutOn"))
                    Me.Enabled = False
                    Exit Sub
                Case Else
                    AddMessage(GetLanguage(Language, "Msg_MapValid"))
                    Exit Sub
            End Select
        End If
        If FileBackup Then '파일 백업 루틴
            IO.File.Copy(OpenFile.FileName, Application.StartupPath & "\MapBackup\" & _
                Now.ToString("yyyy-MM-dd hh-mm-ss") & StrReverse(Split(StrReverse(OpenFile.FileName), ".")(0)))
        End If
        PasswordC.Enabled = Not Protect
        PasswordC.Checked = Protect
        ProtectC.Enabled = Not Protect
        UnprotectC.Enabled = Protect
        SaveC.Enabled = Not Protect
        MPQProtected = False
        ChkProtected = False
        OpenCommand = False
        Me.Height = DH
        AddMessage(IIf(Protect, GetLanguage(Language, "Msg_ReadP"), GetLanguage(Language, "Msg_ReadNP")))
    End Sub

    Private Sub SaveC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveC.Click
        Dim ByteData() As Byte, MPQ As IntPtr, i As Integer
        If SetFolder = 1 Then SaveFile.InitialDirectory = Application.StartupPath & "\"
        If SetFolder = 2 Then SaveFile.InitialDirectory = LastFolder
        If SetFolder = 3 Then SaveFile.InitialDirectory = SaveFolder
        AddMessage(GetLanguage(Language, "Msg_MapSave"))
        If Chunk.SectionReader("VER ").ReadUInt16 = &HCD Then
            SaveFile.Filter = GetLanguage(Language, "FilterSaveE")
        Else
            SaveFile.Filter = GetLanguage(Language, "FilterSaveO")
        End If
        SaveFile.Title = GetLanguage(Language, "Msg_MapSave")
        SaveFile.FileName = ""
        SaveFile.ShowDialog()
        If SaveFile.FileName = "" Then Exit Sub
        If IO.File.Exists(SaveFile.FileName) Then IO.File.Delete(SaveFile.FileName)
        LastFolder = Mid(SaveFile.FileName, 1, InStrRev(SaveFile.FileName, "\"))
        Call SaveSettings()
        AddMessage(GetLanguage(Language, "Msg_MapPath"))
        ByteData = Chunk.ChunkByte
        'Chunk 쓰기 루틴
        If Not LCase(Microsoft.VisualBasic.Right(SaveFile.FileName, 4)) = ".chk" Then
            If Protect And MPQProtected Then
                AddMessage(GetLanguage(Language, "Msg_MPQProtectStart"))
                ProtectMPQ(ByteData, Wav, SaveFile.FileName)
                AddMessage(GetLanguage(Language, "Msg_MPQProtectEnd"))
            Else
                AddMessage(GetLanguage(Language, "Msg_WriteMPQ"))
                MPQ = MPQWrite_OpenMPQ(SaveFile.FileName, MPQ_OpenType.Create)
                If MPQ = -1 Then Exit Sub
                MPQWrite_WriteFile(MPQ, ChunkPath, ByteData)
                If Not Wav Is Nothing Then
                    For i = 0 To UBound(Wav)
                        MPQWrite_WriteWavFile(MPQ, Wav(i).FileName, Wav(i).FileData, WavCompression)
                    Next
                End If
                MPQWrite_CloseMPQ(MPQ)
            End If
            AddMessage(GetLanguage(Language, "Msg_MPQEnd"))
        Else
            System.IO.File.WriteAllBytes(SaveFile.FileName, ByteData)
            AddMessage(GetLanguage(Language, "Msg_ChunkEnd"))
        End If
    End Sub

    Private Sub ProtectC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ProtectC.Click
        If Not ChkProtect And Not MPQProtect Then
            AddMessage(GetLanguage(Language, "Msg_SelectProtect"))
            Exit Sub
        End If
        AddMessage(GetLanguage(Language, "Msg_ProtectStart"))
        If PasswordC.Checked Then
            AddMessage(GetLanguage(Language, "Msg_WritePW"))
            If PasswordBackup Then _
                IO.File.AppendAllText("Password.txt", OpenFile.FileName & vbCrLf & Now.ToString() & vbCrLf & PasswordT.Text & vbCrLf & vbCrLf)
        End If
        SettingData(Chunk, ChkProtect, MPQProtect, SaveUnprotectData, PasswordC.Checked, PasswordT.Text)
        If ChkProtect Then Chunk = ProtectChunk(Chunk)
        ChkProtected = ChkProtect
        MPQProtected = MPQProtect
        AddMessage(GetLanguage(Language, "Msg_ProtectEnd"))
        Me.Height = DH - 46
        Protect = True
        ProtectC.Enabled = False
    End Sub

    Private Sub UnprotectC_Click(ByVal sender As Object, ByVal e As EventArgs) Handles UnprotectC.Click
        Dim Reader As IO.BinaryReader, ProtectType As Byte, i As Integer, Index As Integer
        Dim SHash1() As Byte, SHash2() As Byte, CHash1() As Byte, CHash2() As Byte
        Dim SHA256 As New Security.Cryptography.SHA256Managed
        AddMessage(GetLanguage(Language, "Msg_ReadPW"))
        Index = Chunk.GetSectionIndex("VCOD")
        Reader = Chunk.SectionReader("DATA")
        ProtectType = Reader.ReadBytes(2)(0)
        SHash1 = Reader.ReadBytes(32)
        SHash2 = Reader.ReadBytes(32)
        CHash1 = SHA256.ComputeHash(System.Text.Encoding.Default.GetBytes(PasswordT.Text))
        CHash2 = SHA256.ComputeHash(Chunk.SectionReader(Index).ReadBytes(Chunk.SectionSize(Index)))
        If Not (CompareByteArray(SHash1, CHash1) AndAlso CompareByteArray(SHash2, CHash2)) Then
            AddMessage(GetLanguage(Language, "Msg_NotMatch"))
            Exit Sub
        End If
        AddMessage(GetLanguage(Language, "Msg_UnprotectStart"))
        Select Case ProtectType   '&H4 MPQ 프로텍트 경우 필요 없음
            Case &H1, &H6   '데이터로 복구
                Dim WavPath() As UShort
                Index = Chunk.GetSectionIndex("PRCD")
                Chunk = New ChunkData(Chunk.SectionReader(Index).ReadBytes(Chunk.SectionSize(Index)))
                WavPath = Chunk.GetWavList()
                For i = 0 To Wav.Length - 1
                    Wav(i).FileName = Chunk.GetString(WavPath(i))
                Next
            Case &H2, &H7   '프로그램으로 복구
                Chunk = UnprotectChunk(Chunk)
        End Select
        AddMessage(GetLanguage(Language, "Msg_UnprotectEnd"))
        Protect = False
        SaveC.Enabled = True
        ProtectC.Enabled = True
        UnprotectC.Enabled = False
    End Sub
End Class
