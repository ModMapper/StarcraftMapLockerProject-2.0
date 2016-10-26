Public Class ChunkData
    Private Sections As List(Of ChunkSection)

    Public Structure ChunkSection
        Dim Name() As Char
        Dim Size As Integer
        Dim Data As IO.Stream
        Dim Reader As IO.BinaryReader
        Dim Writer As IO.BinaryWriter
    End Structure

    Public Structure Unit
        Dim ClassInstance As UInteger
        Dim X As UShort
        Dim Y As UShort
        Dim UnitID As UShort
        Dim LinkType As UnitLink
        Dim StateValid As UnitState
        Dim DataValid As UnitData
        Dim Player As Byte
        Dim HitPoint As Byte
        Dim ShieldPoint As Byte
        Dim EnergyPoint As Byte
        Dim Resource As UInteger
        Dim Hangar As UShort
        Dim State As UnitState
        Dim Unused As UInteger
        Dim Link As UInteger
    End Structure

    Public Enum UnitLink As UShort
        Flag1 = 1
        Flag2 = 2
        Flag3 = 4
        Flag4 = 8
        Flag5 = 16
        Flag6 = 32
        Flag7 = 64
        Flag8 = 128
        Nydus = 256
        Addon = 512
        Flag11 = 1024
        Flag12 = 2048
        Flag13 = 4096
        Flag14 = 8192
        Flag15 = 16384
        Flag16 = 32768
    End Enum

    Public Enum UnitState As UShort
        Clock = 1
        Burrow = 2
        InTransit = 4
        Hallucinated = 8
        Invincible = 16
        Flag6 = 32
        Flag7 = 64
        Flag8 = 128
        Flag9 = 256
        Flag10 = 512
        Flag11 = 1024
        Flag12 = 2048
        Flag13 = 4096
        Flag14 = 8192
        Flag15 = 16384
        Flag16 = 32768
    End Enum

    Public Enum UnitData As UShort
        Player = 1
        HitPoint = 2
        ShieldPoint = 4
        EnergyPoint = 8
        Resource = 16
        Hangar = 32
        Flag7 = 64
        Flag8 = 128
        Flag9 = 256
        Flag10 = 512
        Flag11 = 1024
        Flag12 = 2048
        Flag13 = 4096
        Flag14 = 8192
        Flag15 = 16384
        Flag16 = 32768
    End Enum

    Public Structure Trigger
        Public Conditions() As TConditions
        Public Actions() As TActions
        Public Unused As UInteger
        Public Players() As Byte

        Public Sub Init()
            ReDim Conditions(15)
            ReDim Actions(63)
            ReDim Players(27)
        End Sub

        Public Structure TConditions
            Dim Location As UInteger
            Dim PlayerGroup As PlayerGroup
            Dim Number As UInteger
            Dim Unit As UShort
            Dim Type1 As Byte
            Dim Condition As TCondition
            Dim Type2 As Byte
            Dim Flags As TFlags
            Dim Unused As UShort
        End Structure

        Public Structure TActions
            Dim Location As UInteger
            Dim DataString As UInteger
            Dim WavString As UInteger
            Dim Time As UInteger
            Dim PlayerGroup As PlayerGroup
            Dim Data1 As UInteger
            Dim Data2 As UShort
            Dim Action As TAction
            Dim Number As Byte
            Dim Flags As TFlags
            Dim Unused1 As Byte
            Dim Unused2 As UShort
        End Structure

        Public Enum PlayerGroup As UInteger
            Player1 = 0
            Player2 = 1
            Player3 = 2
            Player4 = 3
            Player5 = 4
            Player6 = 5
            Player7 = 6
            Player8 = 7
            Player9 = 8
            Player10 = 9
            Player11 = 10
            Player12 = 11
            Overflow = 12
            CurrentPlayer = 13
            Foes = 14
            Allies = 15
            NeutralPlayers = 15
            AllPlayers = 17
            Force1 = 18
            Force2 = 19
            Force3 = 20
            Force4 = 21
            NonAlliedVictoryPlayers = 26
        End Enum

        Public Enum TFlags As Byte
            Unknown = 1
            Enabled = 2
            AlwaysDisplay = 4
            UnitProperties = 8
            UnitType = 16
            UnitUsed = 32
            Flag6 = 64
            Flag7 = 128
        End Enum

        Public Enum TCondition As Byte
            NoCondition = 0
            CountdownTimer = 1
            Command = 2
            Bring = 3
            Accumulate = 4
            Kill = 5
            CommandMost = 6
            CommandMostAt = 7
            MoskKills = 8
            HighestScore = 9
            MostResources = 10
            Switch = 11
            ElapsedTime = 12
            MissionBriefing = 13
            Opponents = 14
            Deaths = 15
            CommandLeast = 16
            CommandLeastAt = 17
            LeastKills = 18
            LowestScore = 19
            LeastResources = 20
            Score = 21
            Always = 22
            Never = 23
        End Enum

        Public Enum TAction As Byte
            NoAction = 0
            Victory = 1
            Defeat = 2
            PreserveTrigger = 3
            Wait = 4
            PauseGame = 5
            UnpauseGame = 6
            Transmission = 7
            PlayWav = 8
            DesplayTextMessage = 9
            CenterView = 10
            CreateUnitwithProperties = 11
            SetMissionObjectives = 12
            SetSwitch = 13
            SetCountdownTimer = 14
            RunAIScript = 15
            RunAIScriptAtLocation = 16
            LeaderBoradControl = 17
            LeaderBoradControlAtLocation = 18
            LeaderBoradResources = 19
            LeaderBoradKills = 20
            LeaderBoradPoints = 21
            KillUnit = 22
            KillUnitAtLocation = 23
            RemoveUnit = 24
            RemoveUnitAtLocation = 25
            SetResources = 26
            SetScore = 27
            MinimapPing = 28
            TalkingPortrait = 29
            MuteUnitSpeech = 30
            UnmuteUnitSpeech = 31
            LeaderBoradComputerPlayers = 32
            LeaderBoradGoalControl = 33
            LeaderBoradGoalControlAtLocation = 34
            LeaderBoradGoalResources = 35
            LeaderBoradGoalKills = 36
            LeaderBoradGoalPoints = 37
            MoveLocation = 28
            MoveUnit = 29
            LeaderBoradGreed = 40
            SetNextScenario = 41
            SerDoodadState = 42
            SetInvincibility = 43
            CreateUnit = 44
            SetDeaths = 45
            Order = 46
            Comment = 47
            GiveUnit = 48
            ModifyUnitHitPoints = 49
            ModifyUnitEnergy = 50
            ModifyUnitShieldPoints = 51
            ModifyUnitResourceAmount = 52
            ModifyUnitHangerCount = 53
            PauseTimer = 54
            UnpauseTimer = 55
            Draw = 56
            SetAllianceStatus = 57
            DisableDebug = 58
            EnableDebug = 59
            MB_NoAction = 0
            MB_Wait = 1
            MB_PlayWav = 2
            MB_TextMessage = 3
            MB_MissionObjectives = 4
            MB_ShowPortrait = 5
            MB_HidePortrait = 6
            MB_DisplaySpeakingPortrait = 7
            MB_Transmission = 8
            MB_SkipTutorialEnabled = 9
        End Enum
    End Structure

    Public Sub New()
    End Sub

    Public Sub New(ByRef ByteData() As Byte)
        ChunkByte = ByteData
    End Sub

    Public Property ChunkByte() As Byte()
        Get
            Dim ByteData() As Byte, Size As Integer, i As Integer
            Dim Writer As IO.BinaryWriter, Stream As IO.Stream
            Stream = New IO.MemoryStream()
            Writer = New IO.BinaryWriter(Stream)
            For i = 0 To Sections.Count - 1
                Writer.Write(Sections(i).Name)
                Size = Sections(i).Data.Length
                If Size = 0 Then
                    Writer.Write(Sections(i).Size)
                Else
                    Writer.Write(Size)
                    Sections(i).Data.Position = 0
                    Writer.Write(Sections(i).Reader.ReadBytes(Size))
                End If
            Next
            ReDim ByteData(Stream.Length - 1)
            Stream.Position = 0
            Stream.Read(ByteData, 0, Stream.Length)
            Return ByteData
        End Get
        Set(ByVal ByteData As Byte())
            Dim Reader As IO.BinaryReader, Stream As IO.Stream
            Dim Section As ChunkSection
            Sections = New List(Of ChunkSection)
            Stream = New IO.MemoryStream(ByteData)
            Reader = New IO.BinaryReader(Stream)
            Do Until Stream.Position = Stream.Length
                Section.Name = Reader.ReadChars(4)
                Section.Size = Reader.ReadInt32
                Section.Data = New IO.MemoryStream()
                Section.Reader = New IO.BinaryReader(Section.Data)
                Section.Writer = New IO.BinaryWriter(Section.Data)
                If Section.Size > 0 Then
                    Section.Writer.Write(Reader.ReadBytes(Section.Size))
                End If
                Sections.Add(Section)
            Loop
        End Set
    End Property

    Public Function AddSection(ByVal Name As String) As Integer
        Return AddSection(Sections.Count, Name)
    End Function

    Public Function AddSection(ByVal Index As Integer, ByVal Name As String) As Integer
        Dim Section As ChunkSection
        Section.Name = Name
        Section.Size = 0
        Section.Data = New IO.MemoryStream()
        Section.Reader = New IO.BinaryReader(Section.Data)
        Section.Writer = New IO.BinaryWriter(Section.Data)
        Sections.Insert(Index, Section)
        Return Index
    End Function

    Public Sub DeleteSection(ByVal Index As Integer)
        Sections.RemoveAt(Index)
    End Sub

    Public Sub DeleteSection(ByVal Name As String)
        Sections.RemoveAt(GetSectionIndex(Name))
    End Sub

    Public ReadOnly Property SectionLength() As Integer
        Get
            Return Sections.Count
        End Get
    End Property

    Default Public Property SectionSize(ByVal Index As Integer) As Integer
        Get
            SectionSize = Sections(Index).Data.Length
            If SectionSize = 0 Then Return Sections(Index).Size
        End Get
        Set(ByVal Size As Integer)
            Dim Section As ChunkSection
            Section = Sections(Index)
            Section.Size = Size
            If Size > 0 Then
                Section.Data.SetLength(Size)
            Else
                Section.Data = New IO.MemoryStream()
                Section.Reader = New IO.BinaryReader(Section.Data)
                Section.Writer = New IO.BinaryWriter(Section.Data)
            End If
            Sections(Index) = Section
        End Set
    End Property

    Default Public Property SectionSize(ByVal Name As String) As Integer
        Get
            Dim Index As Integer
            Index = GetSectionIndex(Name)
            SectionSize = Sections(Index).Data.Length
            If SectionSize = 0 Then Return Sections(Index).Size
        End Get
        Set(ByVal Size As Integer)
            Dim Section As ChunkSection, Index As Integer
            Index = GetSectionIndex(Name)
            Section = Sections(Index)
            Section.Size = Size
            If Size > 0 Then
                Section.Data.SetLength(Size)
            Else
                Section.Data.Close()
                Section.Data = New IO.MemoryStream()
                Section.Reader = New IO.BinaryReader(Section.Data)
                Section.Writer = New IO.BinaryWriter(Section.Data)
            End If
            Sections(Index) = Section
        End Set
    End Property

    Public ReadOnly Property SectionReader(ByVal Index As Integer) As IO.BinaryReader
        Get
            Sections(Index).Data.Position = 0
            Return Sections(Index).Reader
        End Get
    End Property

    Public ReadOnly Property SectionReader(ByVal Name As String) As IO.BinaryReader
        Get
            Dim Index As Integer
            Index = GetSectionIndex(Name)
            Sections(Index).Data.Position = 0
            Return Sections(Index).Reader
        End Get
    End Property

    Public ReadOnly Property SectionWriter(ByVal Index As Integer) As IO.BinaryWriter
        Get
            Sections(Index).Data.Position = 0
            Return Sections(Index).Writer
        End Get
    End Property

    Public ReadOnly Property SectionWriter(ByVal Name As String) As IO.BinaryWriter
        Get
            Dim Index As Integer
            Index = GetSectionIndex(Name)
            Sections(Index).Data.Position = 0
            Return Sections(Index).Writer
        End Get
    End Property

    Public Function GetSectionIndex(ByVal Name As String) As Integer
        Dim i As Integer
        For i = 0 To Sections.Count - 1
            If Sections(i).Name = Name Then Return i
        Next
        Return -1
    End Function

    '//사용자 지정 소스
    Public Function GetString(ByVal Offset As UShort) As String
        Dim Reader As IO.BinaryReader, Data As Char
        Reader = SectionReader("STR ")
        Reader.BaseStream.Position = Offset * 2
        Reader.BaseStream.Position = Reader.ReadUInt16()
        GetString = vbNullString
        Data = Reader.ReadChar()
        Do Until Data = vbNullChar
            GetString &= Data
            Data = Reader.ReadChar()
        Loop
    End Function

    Public Function GetPlayers() As Boolean()
        Dim Reader As IO.BinaryReader, Players() As Boolean
        Reader = SectionReader("OWNR")
        ReDim Players(7)
        For i = 0 To 7
            Select Case Reader.ReadByte()
                Case &H3, &H5, &H6, &H7
                    Players(i) = True
                Case Else
                    Players(i) = False
            End Select
        Next
        Return Players
    End Function

    Public Function GetWavList() As UShort()
        Dim Trigger() As Trigger, Wav As New List(Of UShort), List As New List(Of String)
        Dim Str As String, i As Integer, n As Integer
        Trigger = TriggerList()
        If Not Trigger Is Nothing Then
            For i = 0 To Trigger.Length - 1
                For n = 0 To 63
                    Select Case Trigger(i).Actions(n).Action
                        Case ChunkData.Trigger.TAction.Transmission, ChunkData.Trigger.TAction.PlayWav
                            Str = GetString(Trigger(i).Actions(n).WavString)
                            If List.IndexOf(Str) < 0 Then
                                Wav.Add(Trigger(i).Actions(n).WavString)
                                List.Add(Str)
                            End If
                    End Select
                Next
            Next
        End If
        Trigger = TriggerList(True)
        If Not Trigger Is Nothing Then
            For i = 0 To Trigger.Length - 1
                For n = 0 To 63
                    Select Case Trigger(i).Actions(n).Action
                        Case ChunkData.Trigger.TAction.Transmission, ChunkData.Trigger.TAction.PlayWav
                            Str = GetString(Trigger(i).Actions(n).WavString)
                            If List.IndexOf(Str) < 0 Then
                                Wav.Add(Trigger(i).Actions(n).WavString)
                                List.Add(Str)
                            End If
                    End Select
                Next
            Next
        End If
        Return Wav.ToArray()
    End Function

    Public Property UnitList() As Unit()
        Get
            Dim Units() As Unit, Reader As IO.BinaryReader
            Dim Index As Integer, i As Integer
            Index = GetSectionIndex("UNIT")
            Reader = SectionReader(Index)
            If Reader.BaseStream.Length = 0 Then Return Nothing
            ReDim Units(Reader.BaseStream.Length / 36 - 1)
            For i = 0 To Units.Length - 1
                Units(i).ClassInstance = Reader.ReadUInt32()
                Units(i).X = Reader.ReadUInt16()
                Units(i).Y = Reader.ReadUInt16()
                Units(i).UnitID = Reader.ReadUInt16()
                Units(i).LinkType = Reader.ReadUInt16()
                Units(i).StateValid = Reader.ReadUInt16()
                Units(i).DataValid = Reader.ReadUInt16()
                Units(i).Player = Reader.ReadByte()
                Units(i).HitPoint = Reader.ReadByte()
                Units(i).ShieldPoint = Reader.ReadByte()
                Units(i).EnergyPoint = Reader.ReadByte()
                Units(i).Resource = Reader.ReadUInt32()
                Units(i).Hangar = Reader.ReadUInt16()
                Units(i).State = Reader.ReadUInt16()
                Units(i).Unused = Reader.ReadUInt32()
                Units(i).Link = Reader.ReadUInt32()
            Next
            Return Units
        End Get
        Set(ByVal Units As Unit())
            Dim Writer As IO.BinaryWriter
            Dim Index As Integer, i As Integer
            Index = GetSectionIndex("UNIT")
            SectionSize(Index) = 0
            Writer = SectionWriter(Index)
            For i = 0 To Units.Length - 1
                Writer.Write(Units(i).ClassInstance)
                Writer.Write(Units(i).X)
                Writer.Write(Units(i).Y)
                Writer.Write(Units(i).UnitID)
                Writer.Write(Units(i).LinkType)
                Writer.Write(Units(i).StateValid)
                Writer.Write(Units(i).DataValid)
                Writer.Write(Units(i).Player)
                Writer.Write(Units(i).HitPoint)
                Writer.Write(Units(i).ShieldPoint)
                Writer.Write(Units(i).EnergyPoint)
                Writer.Write(Units(i).Resource)
                Writer.Write(Units(i).Hangar)
                Writer.Write(Units(i).State)
                Writer.Write(Units(i).Unused)
                Writer.Write(Units(i).Link)
            Next
        End Set
    End Property

    Public Property TriggerList(Optional ByVal MissionBrifing As Boolean = False) As Trigger()
        Get
            Dim Triggers() As Trigger, Reader As IO.BinaryReader
            Dim Index As Integer, i As Integer, n As Integer
            Index = GetSectionIndex(IIf(MissionBrifing, "MBRF", "TRIG"))
            Reader = SectionReader(Index)
            If Reader.BaseStream.Length = 0 Then Return Nothing
            ReDim Triggers(Reader.BaseStream.Length / 2400 - 1)
            For i = 0 To Triggers.Length - 1
                Triggers(i).Init()
                For n = 0 To 15
                    Triggers(i).Conditions(n).Location = Reader.ReadUInt32()
                    Triggers(i).Conditions(n).PlayerGroup = Reader.ReadUInt32()
                    Triggers(i).Conditions(n).Number = Reader.ReadUInt32()
                    Triggers(i).Conditions(n).Unit = Reader.ReadUInt16()
                    Triggers(i).Conditions(n).Type1 = Reader.ReadByte()
                    Triggers(i).Conditions(n).Condition = Reader.ReadByte()
                    Triggers(i).Conditions(n).Type2 = Reader.ReadByte()
                    Triggers(i).Conditions(n).Flags = Reader.ReadByte()
                    Triggers(i).Conditions(n).Unused = Reader.ReadUInt16()
                Next
                For n = 0 To 63
                    Triggers(i).Actions(n).Location = Reader.ReadUInt32()
                    Triggers(i).Actions(n).DataString = Reader.ReadUInt32()
                    Triggers(i).Actions(n).WavString = Reader.ReadUInt32()
                    Triggers(i).Actions(n).Time = Reader.ReadUInt32()
                    Triggers(i).Actions(n).PlayerGroup = Reader.ReadUInt32()
                    Triggers(i).Actions(n).Data1 = Reader.ReadUInt32()
                    Triggers(i).Actions(n).Data2 = Reader.ReadUInt16()
                    Triggers(i).Actions(n).Action = Reader.ReadByte()
                    Triggers(i).Actions(n).Number = Reader.ReadByte()
                    Triggers(i).Actions(n).Flags = Reader.ReadByte()
                    Triggers(i).Actions(n).Unused1 = Reader.ReadByte()
                    Triggers(i).Actions(n).Unused2 = Reader.ReadUInt16()
                Next
                Triggers(i).Unused = Reader.ReadUInt32()
                Triggers(i).Players = Reader.ReadBytes(28)
            Next
            Return Triggers
        End Get
        Set(ByVal Triggers As Trigger())
            Dim Index As Integer, i As Integer, n As Integer
            Dim Writer As IO.BinaryWriter
            Index = GetSectionIndex(IIf(MissionBrifing, "MBRF", "TRIG"))
            SectionSize(Index) = 0
            Writer = SectionWriter(Index)
            For i = 0 To Triggers.Length - 1
                For n = 0 To 15
                    Writer.Write(Triggers(i).Conditions(n).Location)
                    Writer.Write(Triggers(i).Conditions(n).PlayerGroup)
                    Writer.Write(Triggers(i).Conditions(n).Number)
                    Writer.Write(Triggers(i).Conditions(n).Unit)
                    Writer.Write(Triggers(i).Conditions(n).Type1)
                    Writer.Write(Triggers(i).Conditions(n).Condition)
                    Writer.Write(Triggers(i).Conditions(n).Type2)
                    Writer.Write(Triggers(i).Conditions(n).Flags)
                    Writer.Write(Triggers(i).Conditions(n).Unused)
                Next
                For n = 0 To 63
                    Writer.Write(Triggers(i).Actions(n).Location)
                    Writer.Write(Triggers(i).Actions(n).DataString)
                    Writer.Write(Triggers(i).Actions(n).WavString)
                    Writer.Write(Triggers(i).Actions(n).Time)
                    Writer.Write(Triggers(i).Actions(n).PlayerGroup)
                    Writer.Write(Triggers(i).Actions(n).Data1)
                    Writer.Write(Triggers(i).Actions(n).Data2)
                    Writer.Write(Triggers(i).Actions(n).Action)
                    Writer.Write(Triggers(i).Actions(n).Number)
                    Writer.Write(Triggers(i).Actions(n).Flags)
                    Writer.Write(Triggers(i).Actions(n).Unused1)
                    Writer.Write(Triggers(i).Actions(n).Unused2)
                Next
                Writer.Write(Triggers(i).Unused)
                Writer.Write(Triggers(i).Players)
            Next
        End Set
    End Property
End Class
