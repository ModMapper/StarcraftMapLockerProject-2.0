Public Class AboutForm
    Private Sub BlogL_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles BlogL.LinkClicked
        Shell("explorer http://blog.tkyuki.kr")
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles HomepageL.LinkClicked
        Shell("explorer http://tkyuki.kr")
    End Sub

    Private Sub CafeL_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles CafeL.LinkClicked
        Shell("explorer http://cafe.naver.com/scts")
    End Sub

    Private Sub MailL_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles MailL.LinkClicked
        Shell("explorer mailto:modmapper@tkyuki.kr")
    End Sub

    Private Sub AboutForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        MainForm.AddMessage(GetLanguage(Language, "Msg_AboutOff"))
        MainForm.Enabled = True
    End Sub

    Private Sub AboutForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IconP.Image = My.Resources.Icon.ToBitmap
        VersionL.Text = "Version. " & Version
    End Sub
End Class