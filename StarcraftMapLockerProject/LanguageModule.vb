Module LanguageModule
    Public Const MaxLanguage As Integer = 2
    Private DataLanguage(,) As String
    Private DataName() As String

    Public Sub InitLanguage()
        Dim Line() As String, Data() As String, i As Integer
        DataName = Split(My.Resources.LanguageName, vbCrLf)
        Line = Split(My.Resources.LanguageData, vbCrLf)
        ReDim DataLanguage(MaxLanguage, UBound(DataName))
        For i = 0 To Line.Length - 1
            Data = Split(Line(i), "/")
            If Data.Length = 1 Then Continue For
            SetData(CInt(Data(0)), Data(1), Data(2))
        Next
    End Sub

    Public Function GetLanguage(ByVal Lang As Integer, ByVal Name As String) As String
        Dim i As Integer
        For i = 0 To DataName.Length - 1
            If DataName(i).ToUpper = Name.ToUpper Then Return DataLanguage(Lang, i)
        Next
        Return ""
    End Function

    Private Sub SetData(ByVal Lang As Integer, ByVal Name As String, ByVal Data As String)
        Dim i As Integer
        For i = 0 To DataName.Length - 1
            If DataName(i).ToUpper = Name.ToUpper Then DataLanguage(Lang, i) = Data.Replace("%nl%", vbCrLf)
        Next
    End Sub
End Module
