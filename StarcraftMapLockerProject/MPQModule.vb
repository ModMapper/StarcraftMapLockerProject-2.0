Module MPQModule
    'MPQ 읽기
    Private Declare Function SFileOpenArchive Lib "Storm.dll" Alias "#266" (ByVal lpFileName As String, ByVal dwPriority As Integer, ByVal dwFlags As Integer, ByRef hMPQ As Integer) As Boolean
    Private Declare Function SFileCloseArchive Lib "Storm.dll" Alias "#252" (ByVal hMPQ As Integer) As Boolean
    Private Declare Function SFileGetArchiveName Lib "Storm.dll" Alias "#275" (ByVal hMPQ As Integer, ByVal lpBuffer As String, ByVal dwBufferLength As Integer) As Boolean
    Private Declare Function SFileOpenFile Lib "Storm.dll" Alias "#267" (ByVal lpFileName As String, ByRef hFile As Integer) As Boolean
    Private Declare Function SFileOpenFileEx Lib "Storm.dll" Alias "#268" (ByVal hMPQ As Integer, ByVal lpFileName As String, ByVal dwSearchScope As Integer, ByRef hFile As Integer) As Boolean
    Private Declare Function SFileCloseFile Lib "Storm.dll" Alias "#253" (ByVal hFile As Integer) As Boolean
    Private Declare Function SFileGetFileSize Lib "Storm.dll" Alias "#265" (ByVal hFile As Integer, ByRef lpFileSizeHigh As Integer) As Integer
    Private Declare Function SFileGetFileArchive Lib "Storm.dll" Alias "#264" (ByVal hFile As Integer, ByRef hMPQ As Integer) As Boolean
    Private Declare Function SFileGetFileName Lib "Storm.dll" Alias "#276" (ByVal hMPQ As Integer, ByVal lpBuffer As String, ByVal dwBufferLength As Integer) As Boolean
    Private Declare Function SFileSetFilePointer Lib "Storm.dll" Alias "#271" (ByVal hFile As Integer, ByVal lDistanceToMove As Integer, ByRef lplDistanceToMoveHigh As Integer, ByVal dwMoveMethod As Integer) As Integer
    Private Declare Function SFileReadFile Lib "Storm.dll" Alias "#269" (ByVal hFile As Integer, ByRef lpBuffer As Byte, ByVal nNumberOfBytesToRead As Integer, ByRef lpNumberOfBytesRead As Integer, ByVal lpOverlapped As Integer) As Boolean
    Private Declare Function SFileSetLocale Lib "Storm.dll" Alias "#272" (ByVal nNewLocale As Integer) As Integer
    Private Declare Function SFileGetBasePath Lib "Storm.dll" Alias "#273" (ByVal lpBuffer As String, ByVal dwBufferLength As Integer) As Boolean
    Private Declare Function SFileSetBasePath Lib "Storm.dll" Alias "#270" (ByVal lpNewBasePath As String) As Boolean
    Private Declare Function SFileAuthenticateArchive Lib "Storm.dll" Alias "#251" (ByVal hMPQ As Integer, ByRef dwAuthenticationStatus As Integer) As Boolean
    Private Declare Function SFileDestroy Lib "Storm.dll" Alias "#262" () As Boolean

    'MPQ 쓰기
    Private Declare Function MpqOpenArchiveForUpdate Lib "SFmpq.dll" (ByVal lpFileName As String, ByVal dwFlags As Integer, ByVal dwMaximumFilesInArchive As Integer) As Integer
    Private Declare Function MpqCloseUpdatedArchive Lib "SFmpq.dll" (ByVal hMPQ As Integer, ByVal dwUnknown2 As Integer) As Integer
    Private Declare Function MpqAddFileToArchive Lib "SFmpq.dll" (ByVal hMPQ As Integer, ByVal lpSourceFileName As String, ByVal lpDestFileName As String, ByVal dwFlags As Integer) As Boolean
    Private Declare Function MpqAddWaveToArchive Lib "SFmpq.dll" (ByVal hMPQ As Integer, ByVal lpSourceFileName As String, ByVal lpDestFileName As String, ByVal dwFlags As Integer, ByVal dwQuality As Integer) As Boolean
    Private Declare Function MpqRenameFile Lib "SFmpq.dll" (ByVal hMPQ As Integer, ByVal lpcOldFileName As String, ByVal lpcNewFileName As String) As Boolean
    Private Declare Function MpqDeleteFile Lib "SFmpq.dll" (ByVal hMPQ As Integer, ByVal lpFileName As String) As Boolean
    Private Declare Function MpqCompactArchive Lib "SFmpq.dll" (ByVal hMPQ As Integer) As Boolean
    Private Declare Function MpqAddFileToArchiveEx Lib "SFmpq.dll" (ByVal hMPQ As Integer, ByVal lpSourceFileName As String, ByVal lpDestFileName As String, ByVal dwFlags As Integer, ByVal dwCompressionType As Integer, ByVal dwCompressLevel As Integer) As Boolean
    Private Declare Function MpqAddFileFromBufferEx Lib "SFmpq.dll" (ByVal hMPQ As Integer, ByRef lpBuffer As Byte, ByVal dwLength As Integer, ByVal lpFileName As String, ByVal dwFlags As Integer, ByVal dwCompressionType As Integer, ByVal dwCompressLevel As Integer) As Boolean
    Private Declare Function MpqAddFileFromBuffer Lib "SFmpq.dll" (ByVal hMPQ As Integer, ByRef lpBuffer As Byte, ByVal dwLength As Integer, ByVal lpFileName As String, ByVal dwFlags As Integer) As Boolean
    Private Declare Function MpqAddWaveFromBuffer Lib "SFmpq.dll" (ByVal hMPQ As Integer, ByRef lpBuffer As Byte, ByVal dwLength As Integer, ByVal lpFileName As String, ByVal dwFlags As Integer, ByVal dwQuality As Integer) As Boolean
    Private Declare Function MpqSetFileLocale Lib "SFmpq.dll" (ByVal hMPQ As Integer, ByVal lpFileName As String, ByVal nOldLocale As Integer, ByVal nNewLocale As Integer) As Boolean
    Private Declare Sub StormDestroy Lib "SFmpq.dll" ()

    Public Const ChunkPath As String = "staredit\scenario.chk"

    Public Structure MPQFIle
        Dim FileName As String
        Dim FileData() As Byte
    End Structure

    Public Enum MPQ_OpenType As Integer
        Create = &H0
        Open = &H4
    End Enum

    Public Enum MPQ_FileFlags As Integer
        None = &H0
        Encrypt = &H10000
        Implode = &H200
    End Enum

    Public Enum MPQ_WaveLevel As Integer
        Low = 2
        Medium = 0
        High = 1
    End Enum

    Public Enum MPQ_Locale As Short
        Neutral = 0
        Chinese = &H404
        Czech = &H405
        German = &H407
        English = &H409
        Spanish = &H40A
        French = &H40C
        Italian = &H410
        Japanese = &H411
        Korean = &H412
        Polish = &H415
        Portuguese = &H416
        Russsuan = &H419
        EnglishUK = &H809
    End Enum

    Public Sub MPQ_Init()
        Call StormDestroy()
        Call SFileDestroy()
    End Sub

    Public Function MPQ_ReadFile(MPQ As String, File As String, Optional Locale As MPQ_Locale = MPQ_Locale.English) As Byte()
        Dim hMPQ As IntPtr
        hMPQ = MPQRead_OpenMPQ(MPQ)
        MPQ_ReadFile = MPQRead_ReadFile(hMPQ, File, Locale)
        MPQRead_CloseMPQ(hMPQ)
    End Function

    Public Sub MPQ_ExtractFile(MPQ As String, File As String, ExtractPath As String, Optional Locale As MPQ_Locale = MPQ_Locale.English)
        Dim hMPQ As IntPtr
        hMPQ = MPQRead_OpenMPQ(MPQ)
        MPQRead_ExtractFile(hMPQ, File, ExtractPath, Locale)
        MPQRead_CloseMPQ(hMPQ)
    End Sub

    Public Sub MPQ_WriteFile(MPQ As String, File As String, ByteData() As Byte, Optional Flags As MPQ_FileFlags = MPQ_FileFlags.Implode, Optional Locale As MPQ_Locale = MPQ_Locale.Neutral)
        Dim hMPQ As IntPtr
        hMPQ = MPQWrite_OpenMPQ(MPQ)
        MPQWrite_WriteFile(hMPQ, File, ByteData, Flags, Locale)
        MPQWrite_CloseMPQ(hMPQ)
    End Sub

    Public Sub MPQ_PutFile(MPQ As String, File As String, FilePath As String, Optional Flags As MPQ_FileFlags = MPQ_FileFlags.Implode, Optional Locale As MPQ_Locale = MPQ_Locale.Neutral)
        Dim hMPQ As IntPtr
        hMPQ = MPQWrite_OpenMPQ(MPQ)
        MPQWrite_PutFile(hMPQ, File, FilePath, Flags, Locale)
        MPQWrite_CloseMPQ(hMPQ)
    End Sub

    Public Sub MPQ_WriteWavFile(MPQ As String, File As String, ByteData() As Byte, Optional CompressLevel As MPQ_WaveLevel = MPQ_WaveLevel.High, Optional Flags As MPQ_FileFlags = MPQ_FileFlags.Implode, Optional Locale As MPQ_Locale = MPQ_Locale.Neutral)
        Dim hMPQ As IntPtr
        hMPQ = MPQWrite_OpenMPQ(MPQ)
        MPQWrite_WriteWavFile(hMPQ, File, ByteData, CompressLevel, Flags, Locale)
        MPQWrite_CloseMPQ(hMPQ)
    End Sub

    Public Sub MPQ_PutWavFile(MPQ As String, File As String, FilePath As String, Optional CompressLevel As MPQ_WaveLevel = MPQ_WaveLevel.High, Optional Flags As MPQ_FileFlags = MPQ_FileFlags.Implode, Optional Locale As MPQ_Locale = MPQ_Locale.Neutral)
        Dim hMPQ As IntPtr
        hMPQ = MPQWrite_OpenMPQ(MPQ)
        MPQWrite_PutWavFile(hMPQ, File, FilePath, CompressLevel, Flags, Locale)
        MPQWrite_CloseMPQ(hMPQ)
    End Sub

    Public Function MPQRead_OpenMPQ(MPQ As String) As IntPtr
        Dim hMPQ As IntPtr
        SFileDestroy()
        SFileOpenArchive(MPQ, 0, 0, hMPQ)
        Return hMPQ
    End Function

    Public Sub MPQRead_CloseMPQ(MPQ As IntPtr)
        SFileCloseArchive(MPQ)
    End Sub

    Public Function MPQRead_ReadFile(MPQ As IntPtr, File As String, Optional Locale As MPQ_Locale = MPQ_Locale.English) As Byte()
        Dim ByteData() As Byte, hFile As IntPtr, Size As Integer, Read As Integer
        SFileSetLocale(Locale)
        If SFileOpenFileEx(MPQ, File, 0, hFile) = False Then Return Nothing
        Size = SFileGetFileSize(hFile, 0)
        ByteData = Nothing
        If Size > 0 Then
            ReDim ByteData(Size - 1)
            Do Until Size = 0
                If SFileReadFile(hFile, ByteData(0), Size, Read, 0&) = False Then Return Nothing
                Size -= Read
            Loop
        End If
        SFileCloseFile(hFile)
        Return ByteData
    End Function

    Public Sub MPQRead_ExtractFile(MPQ As IntPtr, File As String, ExtractPath As String, Optional Locale As MPQ_Locale = MPQ_Locale.English)
        Dim ByteData() As Byte
        ByteData = MPQRead_ReadFile(MPQ, File, Locale)
        IO.File.WriteAllBytes(ExtractPath, ByteData)
    End Sub

    Public Function MPQWrite_OpenMPQ(MPQ As String, Optional OpenType As MPQ_OpenType = MPQ_OpenType.Open, Optional HashTableSize As Integer = &H400) As IntPtr
        MPQWrite_OpenMPQ = MpqOpenArchiveForUpdate(MPQ, OpenType, HashTableSize)
    End Function

    Public Sub MPQWrite_CloseMPQ(MPQ As IntPtr)
        MpqCloseUpdatedArchive(MPQ, 0)
    End Sub

    Public Sub MPQWrite_WriteFile(MPQ As IntPtr, File As String, ByteData() As Byte, Optional Flags As MPQ_FileFlags = MPQ_FileFlags.Implode, Optional Locale As MPQ_Locale = MPQ_Locale.Neutral)
        If ByteData Is Nothing Then
            MpqAddFileFromBufferEx(MPQ, 0, 0, File, Flags, &H8, 0)
        Else
            MpqAddFileFromBufferEx(MPQ, ByteData(0), ByteData.Length, File, Flags, &H8, 0)
        End If
        If Not Locale = 0 Then MpqSetFileLocale(MPQ, File, 0, Locale)
    End Sub

    Public Sub MPQWrite_PutFile(MPQ As IntPtr, File As String, FilePath As String, Optional Flags As MPQ_FileFlags = MPQ_FileFlags.Implode, Optional Locale As MPQ_Locale = MPQ_Locale.Neutral)
        MpqAddFileToArchiveEx(MPQ, FilePath, File, Flags, &H8, 0)
        If Not Locale = 0 Then MpqSetFileLocale(MPQ, File, 0, Locale)
    End Sub

    Public Sub MPQWrite_WriteWavFile(MPQ As IntPtr, File As String, ByteData() As Byte, Optional CompressLevel As MPQ_WaveLevel = MPQ_WaveLevel.High, Optional Flags As MPQ_FileFlags = MPQ_FileFlags.Implode, Optional Locale As MPQ_Locale = MPQ_Locale.Neutral)
        If ByteData Is Nothing Then
            MpqAddWaveFromBuffer(MPQ, 0, 0, File, Flags, CompressLevel)
        Else
            MpqAddWaveFromBuffer(MPQ, ByteData(0), ByteData.Length, File, Flags, CompressLevel)
        End If
        If Not Locale = 0 Then MpqSetFileLocale(MPQ, File, 0, Locale)
    End Sub

    Public Sub MPQWrite_PutWavFile(MPQ As IntPtr, File As String, FilePath As String, Optional CompressLevel As MPQ_WaveLevel = MPQ_WaveLevel.High, Optional Flags As MPQ_FileFlags = MPQ_FileFlags.Implode, Optional Locale As MPQ_Locale = MPQ_Locale.Neutral)
        MpqAddWaveToArchive(MPQ, FilePath, File, Flags, CompressLevel)
        If Not Locale = 0 Then MpqSetFileLocale(MPQ, File, 0, Locale)
    End Sub
End Module
