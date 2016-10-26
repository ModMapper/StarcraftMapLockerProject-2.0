<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.MenuF = New System.Windows.Forms.GroupBox()
        Me.AboutC = New System.Windows.Forms.Button()
        Me.SettingC = New System.Windows.Forms.Button()
        Me.UnprotectC = New System.Windows.Forms.Button()
        Me.ProtectC = New System.Windows.Forms.Button()
        Me.SaveC = New System.Windows.Forms.Button()
        Me.OpenC = New System.Windows.Forms.Button()
        Me.PasswordF = New System.Windows.Forms.GroupBox()
        Me.PasswordT = New System.Windows.Forms.TextBox()
        Me.PasswordC = New System.Windows.Forms.CheckBox()
        Me.MassageL = New System.Windows.Forms.ListBox()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.MenuF.SuspendLayout()
        Me.PasswordF.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuF
        '
        Me.MenuF.Controls.Add(Me.AboutC)
        Me.MenuF.Controls.Add(Me.SettingC)
        Me.MenuF.Controls.Add(Me.UnprotectC)
        Me.MenuF.Controls.Add(Me.ProtectC)
        Me.MenuF.Controls.Add(Me.SaveC)
        Me.MenuF.Controls.Add(Me.OpenC)
        Me.MenuF.Location = New System.Drawing.Point(0, 0)
        Me.MenuF.Name = "MenuF"
        Me.MenuF.Size = New System.Drawing.Size(112, 208)
        Me.MenuF.TabIndex = 0
        Me.MenuF.TabStop = False
        Me.MenuF.Text = "Menu"
        '
        'AboutC
        '
        Me.AboutC.Location = New System.Drawing.Point(8, 176)
        Me.AboutC.Name = "AboutC"
        Me.AboutC.Size = New System.Drawing.Size(96, 24)
        Me.AboutC.TabIndex = 5
        Me.AboutC.Text = "About"
        Me.AboutC.UseVisualStyleBackColor = True
        '
        'SettingC
        '
        Me.SettingC.Location = New System.Drawing.Point(8, 144)
        Me.SettingC.Name = "SettingC"
        Me.SettingC.Size = New System.Drawing.Size(96, 24)
        Me.SettingC.TabIndex = 4
        Me.SettingC.Text = "Setting"
        Me.SettingC.UseVisualStyleBackColor = True
        '
        'UnprotectC
        '
        Me.UnprotectC.Enabled = False
        Me.UnprotectC.Location = New System.Drawing.Point(8, 112)
        Me.UnprotectC.Name = "UnprotectC"
        Me.UnprotectC.Size = New System.Drawing.Size(96, 24)
        Me.UnprotectC.TabIndex = 3
        Me.UnprotectC.Text = "Unprotect"
        Me.UnprotectC.UseVisualStyleBackColor = True
        '
        'ProtectC
        '
        Me.ProtectC.Enabled = False
        Me.ProtectC.Location = New System.Drawing.Point(8, 80)
        Me.ProtectC.Name = "ProtectC"
        Me.ProtectC.Size = New System.Drawing.Size(96, 24)
        Me.ProtectC.TabIndex = 2
        Me.ProtectC.Text = "Protect"
        Me.ProtectC.UseVisualStyleBackColor = True
        '
        'SaveC
        '
        Me.SaveC.Enabled = False
        Me.SaveC.Location = New System.Drawing.Point(8, 48)
        Me.SaveC.Name = "SaveC"
        Me.SaveC.Size = New System.Drawing.Size(96, 24)
        Me.SaveC.TabIndex = 1
        Me.SaveC.Text = "Save Map"
        Me.SaveC.UseVisualStyleBackColor = True
        '
        'OpenC
        '
        Me.OpenC.Location = New System.Drawing.Point(8, 16)
        Me.OpenC.Name = "OpenC"
        Me.OpenC.Size = New System.Drawing.Size(96, 24)
        Me.OpenC.TabIndex = 0
        Me.OpenC.Text = "Open Map"
        Me.OpenC.UseVisualStyleBackColor = True
        '
        'PasswordF
        '
        Me.PasswordF.Controls.Add(Me.PasswordT)
        Me.PasswordF.Controls.Add(Me.PasswordC)
        Me.PasswordF.Location = New System.Drawing.Point(0, 212)
        Me.PasswordF.Name = "PasswordF"
        Me.PasswordF.Size = New System.Drawing.Size(392, 44)
        Me.PasswordF.TabIndex = 1
        Me.PasswordF.TabStop = False
        Me.PasswordF.Text = "Password"
        '
        'PasswordT
        '
        Me.PasswordT.Enabled = False
        Me.PasswordT.Location = New System.Drawing.Point(96, 17)
        Me.PasswordT.Name = "PasswordT"
        Me.PasswordT.Size = New System.Drawing.Size(288, 21)
        Me.PasswordT.TabIndex = 2
        Me.PasswordT.Text = "password"
        '
        'PasswordC
        '
        Me.PasswordC.AutoSize = True
        Me.PasswordC.Location = New System.Drawing.Point(8, 20)
        Me.PasswordC.Name = "PasswordC"
        Me.PasswordC.Size = New System.Drawing.Size(93, 16)
        Me.PasswordC.TabIndex = 1
        Me.PasswordC.Text = "Password : "
        Me.PasswordC.UseVisualStyleBackColor = True
        '
        'MassageL
        '
        Me.MassageL.Font = New System.Drawing.Font("맑은 고딕", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.MassageL.FormattingEnabled = True
        Me.MassageL.ItemHeight = 15
        Me.MassageL.Location = New System.Drawing.Point(112, 8)
        Me.MassageL.Name = "MassageL"
        Me.MassageL.Size = New System.Drawing.Size(280, 199)
        Me.MassageL.TabIndex = 2
        '
        'OpenFile
        '
        Me.OpenFile.Filter = "Starcraft Map Files|*.scm;*.scx;*.chk|Starcraft Map|*.scm|Starcraft Expansion|*.s" & _
    "cx|Chunk File|*.chk|MoPaQ File|*.mpq|All Files|*.*"
        Me.OpenFile.Title = "Open Map"
        '
        'SaveFile
        '
        Me.SaveFile.Filter = "Starcraft Map Files|*.scm;*.scx;*.chk|Starcraft Map|*.scm|Starcraft Expansion|*.s" & _
    "cx|Chunk File|*.chk|MoPaQ File|*.mpq|All Files|*.*"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 258)
        Me.Controls.Add(Me.MassageL)
        Me.Controls.Add(Me.PasswordF)
        Me.Controls.Add(Me.MenuF)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MainForm"
        Me.Text = "StarcraftMapLockerProject"
        Me.MenuF.ResumeLayout(False)
        Me.PasswordF.ResumeLayout(False)
        Me.PasswordF.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MenuF As System.Windows.Forms.GroupBox
    Friend WithEvents AboutC As System.Windows.Forms.Button
    Friend WithEvents SettingC As System.Windows.Forms.Button
    Friend WithEvents UnprotectC As System.Windows.Forms.Button
    Friend WithEvents ProtectC As System.Windows.Forms.Button
    Friend WithEvents SaveC As System.Windows.Forms.Button
    Friend WithEvents OpenC As System.Windows.Forms.Button
    Friend WithEvents PasswordF As System.Windows.Forms.GroupBox
    Friend WithEvents PasswordT As System.Windows.Forms.TextBox
    Friend WithEvents PasswordC As System.Windows.Forms.CheckBox
    Friend WithEvents MassageL As System.Windows.Forms.ListBox
    Friend WithEvents OpenFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFile As System.Windows.Forms.SaveFileDialog

End Class
