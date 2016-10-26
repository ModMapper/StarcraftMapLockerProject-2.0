<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutForm
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutForm))
        Me.NameL = New System.Windows.Forms.Label()
        Me.MadeByL = New System.Windows.Forms.Label()
        Me.BlogL = New System.Windows.Forms.LinkLabel()
        Me.HomepageL = New System.Windows.Forms.LinkLabel()
        Me.CafeL = New System.Windows.Forms.LinkLabel()
        Me.IconP = New System.Windows.Forms.PictureBox()
        Me.HelpL = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.MailL = New System.Windows.Forms.LinkLabel()
        Me.VersionL = New System.Windows.Forms.Label()
        CType(Me.IconP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NameL
        '
        Me.NameL.AutoSize = True
        Me.NameL.Location = New System.Drawing.Point(48, 8)
        Me.NameL.Name = "NameL"
        Me.NameL.Size = New System.Drawing.Size(165, 12)
        Me.NameL.TabIndex = 1
        Me.NameL.Text = "Starcraft Map Locker Porject"
        '
        'MadeByL
        '
        Me.MadeByL.AutoSize = True
        Me.MadeByL.Location = New System.Drawing.Point(48, 24)
        Me.MadeByL.Name = "MadeByL"
        Me.MadeByL.Size = New System.Drawing.Size(128, 12)
        Me.MadeByL.TabIndex = 2
        Me.MadeByL.Text = "Made By ModMapper"
        '
        'BlogL
        '
        Me.BlogL.AutoSize = True
        Me.BlogL.Location = New System.Drawing.Point(216, 48)
        Me.BlogL.Name = "BlogL"
        Me.BlogL.Size = New System.Drawing.Size(158, 12)
        Me.BlogL.TabIndex = 4
        Me.BlogL.TabStop = True
        Me.BlogL.Text = "Blog : http://blog.tkyuki.kr/"
        '
        'HomepageL
        '
        Me.HomepageL.AutoSize = True
        Me.HomepageL.Location = New System.Drawing.Point(8, 48)
        Me.HomepageL.Name = "HomepageL"
        Me.HomepageL.Size = New System.Drawing.Size(160, 12)
        Me.HomepageL.TabIndex = 5
        Me.HomepageL.TabStop = True
        Me.HomepageL.Text = "Homepage : http://tkyuki.kr"
        '
        'CafeL
        '
        Me.CafeL.AutoSize = True
        Me.CafeL.Location = New System.Drawing.Point(8, 64)
        Me.CafeL.Name = "CafeL"
        Me.CafeL.Size = New System.Drawing.Size(197, 12)
        Me.CafeL.TabIndex = 6
        Me.CafeL.TabStop = True
        Me.CafeL.Text = "Cafe : http://cafe.naver.com/scts"
        '
        'IconP
        '
        Me.IconP.Location = New System.Drawing.Point(8, 8)
        Me.IconP.Name = "IconP"
        Me.IconP.Size = New System.Drawing.Size(32, 32)
        Me.IconP.TabIndex = 0
        Me.IconP.TabStop = False
        '
        'HelpL
        '
        Me.HelpL.AutoSize = True
        Me.HelpL.Location = New System.Drawing.Point(216, 24)
        Me.HelpL.Name = "HelpL"
        Me.HelpL.Size = New System.Drawing.Size(115, 12)
        Me.HelpL.TabIndex = 7
        Me.HelpL.Text = "Helped By 양과늑대"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBox1.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(4, 80)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(420, 160)
        Me.TextBox1.TabIndex = 8
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'MailL
        '
        Me.MailL.AutoSize = True
        Me.MailL.Location = New System.Drawing.Point(216, 64)
        Me.MailL.Name = "MailL"
        Me.MailL.Size = New System.Drawing.Size(167, 12)
        Me.MailL.TabIndex = 9
        Me.MailL.TabStop = True
        Me.MailL.Text = "Mail : modmapper@tkyuki.kr"
        '
        'VersionL
        '
        Me.VersionL.AutoSize = True
        Me.VersionL.Location = New System.Drawing.Point(216, 8)
        Me.VersionL.Name = "VersionL"
        Me.VersionL.Size = New System.Drawing.Size(48, 12)
        Me.VersionL.TabIndex = 10
        Me.VersionL.Text = "Version"
        '
        'AboutForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(427, 242)
        Me.Controls.Add(Me.VersionL)
        Me.Controls.Add(Me.MailL)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.HelpL)
        Me.Controls.Add(Me.CafeL)
        Me.Controls.Add(Me.HomepageL)
        Me.Controls.Add(Me.BlogL)
        Me.Controls.Add(Me.MadeByL)
        Me.Controls.Add(Me.NameL)
        Me.Controls.Add(Me.IconP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimizeBox = False
        Me.Name = "AboutForm"
        Me.Text = "About"
        CType(Me.IconP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents IconP As System.Windows.Forms.PictureBox
    Friend WithEvents NameL As System.Windows.Forms.Label
    Friend WithEvents MadeByL As System.Windows.Forms.Label
    Friend WithEvents BlogL As System.Windows.Forms.LinkLabel
    Friend WithEvents HomepageL As System.Windows.Forms.LinkLabel
    Friend WithEvents CafeL As System.Windows.Forms.LinkLabel
    Friend WithEvents HelpL As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents MailL As System.Windows.Forms.LinkLabel
    Friend WithEvents VersionL As System.Windows.Forms.Label
End Class
