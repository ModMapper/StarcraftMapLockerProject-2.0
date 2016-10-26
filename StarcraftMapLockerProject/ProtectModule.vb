Module ProtectModule
    Private Structure MPQ_HashTable
        Dim Name1 As UInteger
        Dim Name2 As UInteger
        Dim Locale As MPQ_Locale
        Dim Platform As UShort
        Dim BlockTable As Integer
    End Structure

    Private Structure MPQ_BlockTable
        Dim FileOffset As Integer
        Dim FileSize As UInteger
        Dim CompressedSize As UInteger
        Dim Flags As UInteger
    End Structure

    Private Enum HashType As UInteger
        Hash_TableOffset = 0
        Hash_Name_A = 1
        Hash_Name_B = 2
        Hash_FileKey = 3
    End Enum

    Private Const HashTableKey As UInteger = &HC3AF3770&
    Private Const BlockTableKey As UInteger = &HEC83B3A3&
    Private Const ChunkHash1 As UInteger = &HB701656E&
    Private Const ChunkHash2 As UInteger = &HFCFB1EED&
    Private dwCryptTable(&H500) As UInteger

    Public Function ProtectChunk(ByVal Original As ChunkData) As ChunkData
        Dim Writer As IO.BinaryWriter, Reader As IO.BinaryReader
        Dim Result As ChunkData = New ChunkData()
        Dim SectionName As String

        '스타크래프트 버전 정보
        '프로텍션 : 없음
        SectionName = "VER "
        If Original.GetSectionIndex(SectionName) > 0 Then
            Writer = Result.SectionWriter(Result.AddSection(SectionName))
            Reader = Original.SectionReader(SectionName)
            Writer.Write(Reader.ReadUInt16)
        End If

        '스타크래프트 맵 인증코드
        '프로텍션 : 없음
        SectionName = "VCOD"
        If Original.GetSectionIndex(SectionName) > 0 Then
            Writer = Result.SectionWriter(Result.AddSection(SectionName))
            Reader = Original.SectionReader(SectionName)
            Writer.Write(Reader.ReadBytes(Reader.BaseStream.Length))
        End If

        '스타크래프트 맵 지형정보
        '프로텍션 : 없음
        SectionName = "MTXM"
        If Original.GetSectionIndex(SectionName) > 0 Then
            Writer = Result.SectionWriter(Result.AddSection(SectionName))
            Reader = Original.SectionReader(SectionName)
            Writer.Write(Reader.ReadBytes(Reader.BaseStream.Length))
        End If

        '스타크래프트 유닛 사용 여부
        '프로텍션 : 사용값 0xFF로 바꿈, 사용하지 않는 값 0x00으로 바꿈, 중복 데이터 제거
        SectionName = "PUNI"
        If Original.GetSectionIndex(SectionName) > 0 Then
            Dim Data() As Byte, i As Integer, n As Integer
            Writer = Result.SectionWriter(Result.AddSection(SectionName))
            Reader = Original.SectionReader(SectionName)
            Data = Reader.ReadBytes(Reader.BaseStream.Length)
            For i = 0 To 227
                Data(&HAB0 + i) = CInt(Data(&HAB0 + i) > 0) And &HFF
                For n = 0 To 7
                    Data(i * 12 + n) = CInt(Data(i * 12 + n) > 0) And &HFF
                    Data(&HB94 + (i * 12 + n)) = CInt(Data(&HB94 + (i * 12 + n)) > 0) And &HFF
                    If Data(i * 12 + n) = Data(&HAB0 + i) Or Data(&HB94 + (i * 12 + n)) = 0 Then
                        Data(i * 12 + n) = 0
                        Data(&HB94 + (i * 12 + n)) = 0
                    End If
                Next
                Data(i * 12 + 8) = 0
                Data(&HB94 + (i * 12 + 8)) = 0
                Data(i * 12 + 9) = 0
                Data(&HB94 + (i * 12 + 9)) = 0
                Data(i * 12 + 10) = 0
                Data(&HB94 + (i * 12 + 10)) = 0
                Data(i * 12 + 11) = 0
                Data(&HB94 + (i * 12 + 11)) = 0
            Next
            Writer.Write(Data)
        End If

        '스타크래프트 업그레이드 값
        '프로텍션 : 사용값 0xFF로 바꿈, 사용하지 않는 값 0x00으로 바꿈, 중복 데이터 제거
        SectionName = "UPGR"
        If Original.GetSectionIndex(SectionName) > 0 And Original.GetSectionIndex("PUPx") = -1 Then
            Dim Data() As Byte, i As Integer, n As Integer
            Writer = Result.SectionWriter(Result.AddSection(SectionName))
            Reader = Original.SectionReader(SectionName)
            Data = Reader.ReadBytes(Reader.BaseStream.Length)
            For i = 0 To 44
                For n = 0 To 7
                    Data(&H492 + (i * 12 + n)) = CInt(Data(&H492 + (i * 12 + n)) > 0) And &HFF
                    If (Data(i * 12 + n) = Data(&H438 + i) And Data(&H21C + (i * 12 + n)) = Data(&H465 + i)) Or Data(&H492 + (i * 12 + n)) = 0 Then
                        Data(i * 12 + n) = 0
                        Data(&H21C + (i * 12 + n)) = 0
                        Data(&H492 + (i * 12 + n)) = 0
                    End If
                Next
                Data(i * 12 + 8) = 0
                Data(&H21C + (i * 12 + 8)) = 0
                Data(&H492 + (i * 12 + 8)) = 0
                Data(i * 12 + 9) = 0
                Data(&H21C + (i * 12 + 9)) = 0
                Data(&H492 + (i * 12 + 9)) = 0
                Data(i * 12 + 10) = 0
                Data(&H21C + (i * 12 + 10)) = 0
                Data(&H492 + (i * 12 + 10)) = 0
                Data(i * 12 + 11) = 0
                Data(&H21C + (i * 12 + 11)) = 0
                Data(&H492 + (i * 12 + 11)) = 0
            Next
            Writer.Write(Data)
        End If

        '스타크래프트 기술, 마법 값
        '프로텍션 : 사용값 0xFF로 바꿈, 사용하지 않는 값 0x00으로 바꿈, 중복 데이터 제거
        SectionName = "PTEC"
        If Original.GetSectionIndex(SectionName) > 0 And Original.GetSectionIndex("PTEx") = -1 Then
            Dim Data() As Byte, i As Integer, n As Integer
            Writer = Result.SectionWriter(Result.AddSection(SectionName))
            Reader = Original.SectionReader(SectionName)
            Data = Reader.ReadBytes(Reader.BaseStream.Length)
            For i = 0 To 23
                Data(&H240 + i) = CInt(Data(&H240 + i) > 0) And &HFF
                Data(&H258 + i) = CInt(Data(&H258 + i) > 0) And &HFF
                For n = 0 To 7
                    Data(i * 12 + n) = CInt(Data(i * 12 + n) > 0) And &HFF
                    Data(&H120 + (i * 12 + n)) = CInt(Data(&H120 + (i * 12 + n)) > 0) And &HFF
                    Data(&H270 + (i * 12 + n)) = CInt(Data(&H270 + (i * 12 + n)) > 0) And &HFF
                    If (Data(i * 12 + n) = Data(&H240 + i) And Data(&H120 + (i * 12 + n)) = Data(&H258 + i)) Or Data(&H270 + (i * 12 + n)) = 0 Then
                        Data(i * 12 + n) = 0
                        Data(&H120 + (i * 12 + n)) = 0
                        Data(&H270 + (i * 12 + n)) = 0
                    End If
                Next
                Data(i * 12 + 8) = 0
                Data(&H120 + (i * 12 + 8)) = 0
                Data(&H270 + (i * 12 + 8)) = 0
                Data(i * 12 + 9) = 0
                Data(&H120 + (i * 12 + 9)) = 0
                Data(&H270 + (i * 12 + 9)) = 0
                Data(i * 12 + 10) = 0
                Data(&H120 + (i * 12 + 10)) = 0
                Data(&H270 + (i * 12 + 10)) = 0
                Data(i * 12 + 11) = 0
                Data(&H120 + (i * 12 + 11)) = 0
                Data(&H270 + (i * 12 + 11)) = 0
            Next
            Writer.Write(Data)
        End If

        '스타크래프트 유닛 정보
        '프로텍션 : 0xFF 36개 추가, 
        SectionName = "UNIT"
        If Original.GetSectionIndex(SectionName) > 0 Then
            Dim i As Integer
            Writer = Result.SectionWriter(Result.AddSection(SectionName))
            Reader = Original.SectionReader(SectionName)
            For i = 0 To 8
                Writer.Write(-1%)
            Next
            Writer.Write(Reader.ReadBytes(Reader.BaseStream.Length))
        End If

        '스타크래프트 맵 장식
        '프로텍션 : 크기 0일시 삭제
        SectionName = "DD2 "
        If Original.GetSectionIndex(SectionName) > 0 And Original.SectionReader(SectionName).BaseStream.Length > 0 Then
            Writer = Result.SectionWriter(Result.AddSection(SectionName))
            Reader = Original.SectionReader(SectionName)
            Writer.Write(Reader.ReadBytes(Reader.BaseStream.Length))
        End If

        '스타크래프트 스프라이트 정보
        '프로텍션 : 없음
        SectionName = "THG2"
        If Original.GetSectionIndex(SectionName) > 0 Then
            Writer = Result.SectionWriter(Result.AddSection(SectionName))
            Reader = Original.SectionReader(SectionName)
            Writer.Write(Reader.ReadBytes(Reader.BaseStream.Length))
        End If

        '스타크래프트 전장의 안개
        '프로텍션 : 없음
        SectionName = "MASK"
        If Original.GetSectionIndex(SectionName) > 0 Then
            Writer = Result.SectionWriter(Result.AddSection(SectionName))
            Reader = Original.SectionReader(SectionName)
            Writer.Write(Reader.ReadBytes(Reader.BaseStream.Length))
        End If

        'OWER, SIDE, DIM, ERA는 TRIG 안에
        Return Result
    End Function

    Public Function UnprotectChunk(ByVal Original As ChunkData) As ChunkData
        Dim Result As ChunkData = New ChunkData()
        '구현되지 않음
        Return Nothing
    End Function

    Public Sub ProtectMPQ(ByRef Chunk() As Byte, ByVal Wav() As MPQFIle, ByVal SavePath As String)
        Dim ByteData() As Byte, Replacement() As Byte, Data() As UInteger
        Dim HashTable() As MPQ_HashTable, BlockTable() As MPQ_BlockTable
        Dim Offset As Integer, Size As Integer = 2
        Dim MPQ As IntPtr, i As Integer
        If Not Wav Is Nothing Then Size += Wav.Length - 1
        MPQ = MPQWrite_OpenMPQ(SavePath, MPQ_OpenType.Create, Size)
        MPQWrite_WriteFile(MPQ, "(listfile)", Nothing, MPQ_FileFlags.None)
        MPQWrite_WriteFile(MPQ, ChunkPath, Chunk, MPQ_FileFlags.Implode Or MPQ_FileFlags.Encrypt, MPQ_Locale.English)
        If Not Wav Is Nothing Then
            For i = 0 To Wav.Length - 1
                MPQWrite_WriteWavFile(MPQ, Hex(i), Wav(i).FileData, WavCompression, MPQ_FileFlags.Implode Or MPQ_FileFlags.Encrypt, MPQ_Locale.English)
            Next
        End If
        MPQWrite_CloseMPQ(MPQ)
        ByteData = IO.File.ReadAllBytes(SavePath)
        IO.File.Delete(SavePath)
        Call InitializeCryptTable()

        Size = BitConverter.ToUInt32(ByteData, 24)
        ReDim Data(Size * 4 - 1)
        ReDim HashTable(Size - 1)
        Offset = BitConverter.ToInt32(ByteData, 16)
        System.Runtime.InteropServices.Marshal.Copy(ByteData, Offset, _
                System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(Data, 0), Size * 16)
        DecryptData(Data, HashTableKey)
        For i = 0 To Size - 1
            HashTable(i).Name1 = Data(i * 4)
            HashTable(i).Name2 = Data(i * 4 + 1)
            HashTable(i).Locale = Data(i * 4 + 2) And &HFFFF
            HashTable(i).Platform = Data(i * 4 + 2) >> 4
            HashTable(i).BlockTable = Data(i * 4 + 3)
        Next
        Size = BitConverter.ToUInt32(ByteData, 28)
        ReDim Data(Size * 4 - 1)
        ReDim BlockTable(Size - 1)
        System.Runtime.InteropServices.Marshal.Copy(ByteData, BitConverter.ToInt32(ByteData, 20), _
                System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(Data, 0), Size * 16)
        DecryptData(Data, BlockTableKey)
        For i = 0 To Size - 1
            BlockTable(i).FileOffset = Data(i * 4)
            BlockTable(i).CompressedSize = Data(i * 4 + 1)
            BlockTable(i).FileSize = Data(i * 4 + 2)
            BlockTable(i).Flags = Data(i * 4 + 3)
        Next
        '프로텍션 시작
        BlockTable(0).FileSize = &HFFFFFFFF
        For i = 1 To BlockTable.Length - 1
            BlockTable(i).CompressedSize = &HFFFFFFFF
            BlockTable(i).Flags = BlockTable(i).Flags Or &H1000000
        Next
        '프로텍션 종료
        Size = (BlockTable.Length * 16) + (HashTable.Length * 16) + &H20
        Size += (&H200 - (Size Mod &H200))
        ReDim Replacement(Size + Offset - 1)
        ReDim Data(HashTable.Length * 4 - 1)
        For i = 0 To HashTable.Length - 1
            Data(i * 4) = HashTable(i).Name1
            Data(i * 4 + 1) = HashTable(i).Name2
            Data(i * 4 + 2) = HashTable(i).Locale Or (HashTable(i).Platform << 4)
            Data(i * 4 + 3) = HashTable(i).BlockTable
        Next
        EncryptData(Data, HashTableKey)
        System.Runtime.InteropServices.Marshal.Copy( _
            System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(Data, 0), Replacement, &H20, HashTable.Length * 16)
        For i = 0 To BlockTable.Length - 1
            Data(i * 4) = BlockTable(i).FileOffset
            Data(i * 4 + 1) = BlockTable(i).CompressedSize
            Data(i * 4 + 2) = BlockTable(i).FileSize
            Data(i * 4 + 3) = BlockTable(i).Flags
        Next
        EncryptData(Data, BlockTableKey)
        System.Runtime.InteropServices.Marshal.Copy( _
            System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(Data, 0), Replacement, &H20 + (HashTable.Length * 16), BlockTable.Length * 16)
        Array.Copy(BitConverter.GetBytes((Size * -1) + &H20), 0, ByteData, 16, 4)                           '해시 테이블 위치
        Array.Copy(BitConverter.GetBytes((Size * -1) + &H20 + (HashTable.Length * 16)), 0, ByteData, 20, 4) '블럭 테이블 위치
        Array.Copy(BitConverter.GetBytes(HashTable.Length), 0, ByteData, 24, 4)                             '해시 테이블 크기
        Array.Copy(BitConverter.GetBytes(BlockTable.Length), 0, ByteData, 28, 4)                            '블럭 테이블 크기
        ByteData(8) = &HFF
        ByteData(9) = &HFF
        ByteData(10) = &HFF
        ByteData(11) = &HFF
        ByteData(12) = &HFF
        ByteData(13) = &HFF
        ByteData(14) = &HE3
        ByteData(15) = &HFF
        ByteData(27) = &H10     '프로텍팅
        Replacement(0) = &H4D
        Replacement(1) = &H50
        Replacement(2) = &H51
        Replacement(3) = &H1A   'MPQ0x1A
        Replacement(4) = &H10   '10 00 00 00    헤더 크기
        Replacement(13) = &H1   '00 01          버전
        Replacement(14) = &H3   '03 00          블럭 크기
        Replacement(16) = &H20  '20 00 00 00    해시 테이블 위치
        Array.Copy(BitConverter.GetBytes(HashTable.Length * 16 + &H20), 0, Replacement, 20, 4) '블럭 테이블 위치
        Replacement(24) = &HFF
        Replacement(25) = &HFF
        Replacement(27) = &H10  '해시 테이블 크기
        Array.Copy(ByteData, 0, Replacement, Size, Offset)  '나머지 파일 복사
        IO.File.WriteAllBytes(SavePath, Replacement)
    End Sub

    Public Sub SettingData(ByRef Chunk As ChunkData, ByVal ChkProtect As Boolean, ByVal MPQProtect As Boolean, ByVal SaveData As Boolean, ByVal UsePassword As Boolean, ByVal Password As String)
        Dim Writer As IO.BinaryWriter, PRCD() As Byte, Index As Integer
        Dim SHA256 As New Security.Cryptography.SHA256Managed
        PRCD = Chunk.ChunkByte
        Writer = Chunk.SectionWriter(Chunk.AddSection("DATA"))
        Index = Chunk.GetSectionIndex("VCOD")
        If Not UsePassword Then Password = "Protect By SMLP"
        '&H00 X Chk프로텍션
        '&H01 O Chk프로텍션 '데이터'
        '&H02 O Chk프로텍션 '프로그램'
        '&H03 X MPQ프로텍션
        '&H04 O MPQ프로텍션
        '&H05 X MPQ프로텍션 + Chk프로텍션
        '&H06 O MPQ프로텍션 + Chunk프로텍션 '데이터'
        '&H07 O MPQ프로텍션 + Chunk프로텍션 '프로그램'
        '&HFF 제작자 특수 프로텍트 파일
        If UsePassword Then
            If MPQProtect Then
                If ChkProtect Then
                    If SaveData Then
                        Writer.Write(CByte(&H6))
                    Else
                        Writer.Write(CByte(&H7))
                    End If
                Else
                    Writer.Write(CByte(&H4))
                End If
            Else
                If SaveData Then
                    Writer.Write(CByte(&H1))
                Else
                    Writer.Write(CByte(&H2))
                End If
            End If
            Writer.Write(CByte(&H0))
            Writer.Write(SHA256.ComputeHash(System.Text.Encoding.Default.GetBytes(Password)))
            Writer.Write(SHA256.ComputeHash(Chunk.SectionReader(Index).ReadBytes(Chunk.SectionSize(Index))))
            If ChkProtect And SaveData Then
                '데이터 저장 루틴 넣기
                Writer = Chunk.SectionWriter(Chunk.AddSection("PRCD"))
                Writer.Write(XORCrypt(PRCD, Password))
            End If
        Else
            If MPQProtect Then
                If ChkProtect Then
                    Writer.Write(CByte(&H5))
                Else
                    Writer.Write(CByte(&H3))
                End If
            Else
                Writer.Write(CByte(&H0))
            End If
        End If
    End Sub

    Private Function XORCrypt(ByVal Data() As Byte, ByVal KeyString As String) As Byte()
        Dim Crypt() As Byte, Key() As Byte, i As Integer
        Key = System.Text.Encoding.Default.GetBytes("XOR" & KeyString)
        ReDim Crypt(Data.Length - 1)
        For i = 0 To Data.Length - 1
            Crypt(i) = Data(i) Xor Key(i Mod Key.Length)
        Next
        Return Crypt
    End Function

    Private Sub InitializeCryptTable()
        Dim seed As UInteger = &H100001, i As Integer
        Dim index1 As UInteger, index2 As UInteger
        Dim temp1 As UInteger, temp2 As UInteger
        For index1 = 0 To &H100
            index2 = index1
            For i = 0 To 4
                seed = (seed * 125 + 3) Mod &H2AAAAB
                temp1 = (seed And &HFFFF) << &H10

                seed = (seed * 125 + 3) Mod &H2AAAAB
                temp2 = (seed And &HFFFF)

                dwCryptTable(index2) = (temp1 Or temp2)
                index2 += &H100
            Next
        Next
    End Sub

    Private Sub EncryptData(ByRef lpdwBuffer() As UInteger, ByVal dwKey As UInteger)
        Dim seed As UInteger = &HEEEEEEEE&
        Dim ch As UInteger, i As Integer
        For i = 0 To UBound(lpdwBuffer)
            seed += dwCryptTable(&H400 + (dwKey And &HFF))
            ch = lpdwBuffer(i) Xor (dwKey + seed)

            dwKey = (((Not dwKey) << &H15) + &H11111111) Or (dwKey >> &HB)
            seed = lpdwBuffer(i) + seed + (seed << 5) + 3

            lpdwBuffer(i) = ch
        Next
    End Sub

    Private Sub DecryptData(ByRef lpdwBuffer() As UInteger, ByVal dwKey As UInteger)
        Dim seed As UInteger = &HEEEEEEEE&
        Dim ch As UInteger, i As Integer
        For i = 0 To UBound(lpdwBuffer)
            seed += dwCryptTable(&H400 + (dwKey And &HFF))
            ch = lpdwBuffer(i) Xor (dwKey + seed)

            dwKey = (((Not dwKey) << &H15) + &H11111111&) Or (dwKey >> &HB)
            seed = ch + seed + (seed << 5) + 3

            lpdwBuffer(i) = ch
        Next
    End Sub
End Module
