<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingForm
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
        Me.UpdateF = New System.Windows.Forms.GroupBox()
        Me.UpdateC = New System.Windows.Forms.Button()
        Me.AutoUpdateC = New System.Windows.Forms.CheckBox()
        Me.WebVersionL = New System.Windows.Forms.Label()
        Me.FileVersionL = New System.Windows.Forms.Label()
        Me.WavCompF = New System.Windows.Forms.GroupBox()
        Me.WavCompLO = New System.Windows.Forms.RadioButton()
        Me.WavCompMO = New System.Windows.Forms.RadioButton()
        Me.WavCompHO = New System.Windows.Forms.RadioButton()
        Me.ForderOpenF = New System.Windows.Forms.GroupBox()
        Me.UseSettingO = New System.Windows.Forms.RadioButton()
        Me.UseLastFolderO = New System.Windows.Forms.RadioButton()
        Me.UseSMLPO = New System.Windows.Forms.RadioButton()
        Me.SaveFolderC = New System.Windows.Forms.Button()
        Me.SaveFolderT = New System.Windows.Forms.TextBox()
        Me.SaveFolderL = New System.Windows.Forms.Label()
        Me.OpenFolderC = New System.Windows.Forms.Button()
        Me.OpenForlderT = New System.Windows.Forms.TextBox()
        Me.OpenFolderL = New System.Windows.Forms.Label()
        Me.OKC = New System.Windows.Forms.Button()
        Me.CancelC = New System.Windows.Forms.Button()
        Me.BackupF = New System.Windows.Forms.GroupBox()
        Me.PasswordBackupC = New System.Windows.Forms.CheckBox()
        Me.FileBackupC = New System.Windows.Forms.CheckBox()
        Me.ResetAll = New System.Windows.Forms.Button()
        Me.FolderBrowser = New System.Windows.Forms.FolderBrowserDialog()
        Me.LanguageF = New System.Windows.Forms.GroupBox()
        Me.LanguageC = New System.Windows.Forms.ComboBox()
        Me.ProtectF = New System.Windows.Forms.GroupBox()
        Me.MPQProtectC = New System.Windows.Forms.CheckBox()
        Me.ChkProtectC = New System.Windows.Forms.CheckBox()
        Me.UnprotectC = New System.Windows.Forms.CheckBox()
        Me.Notice = New System.Windows.Forms.Label()
        Me.UpdateF.SuspendLayout()
        Me.WavCompF.SuspendLayout()
        Me.ForderOpenF.SuspendLayout()
        Me.BackupF.SuspendLayout()
        Me.LanguageF.SuspendLayout()
        Me.ProtectF.SuspendLayout()
        Me.SuspendLayout()
        '
        'UpdateF
        '
        Me.UpdateF.Controls.Add(Me.UpdateC)
        Me.UpdateF.Controls.Add(Me.AutoUpdateC)
        Me.UpdateF.Controls.Add(Me.WebVersionL)
        Me.UpdateF.Controls.Add(Me.FileVersionL)
        Me.UpdateF.Location = New System.Drawing.Point(0, 136)
        Me.UpdateF.Name = "UpdateF"
        Me.UpdateF.Size = New System.Drawing.Size(152, 104)
        Me.UpdateF.TabIndex = 0
        Me.UpdateF.TabStop = False
        Me.UpdateF.Text = "Update"
        '
        'UpdateC
        '
        Me.UpdateC.Location = New System.Drawing.Point(8, 72)
        Me.UpdateC.Name = "UpdateC"
        Me.UpdateC.Size = New System.Drawing.Size(136, 24)
        Me.UpdateC.TabIndex = 2
        Me.UpdateC.Text = "Update"
        Me.UpdateC.UseVisualStyleBackColor = True
        '
        'AutoUpdateC
        '
        Me.AutoUpdateC.AutoSize = True
        Me.AutoUpdateC.Location = New System.Drawing.Point(8, 48)
        Me.AutoUpdateC.Name = "AutoUpdateC"
        Me.AutoUpdateC.Size = New System.Drawing.Size(88, 16)
        Me.AutoUpdateC.TabIndex = 1
        Me.AutoUpdateC.Text = "AutoUpdate"
        Me.AutoUpdateC.UseVisualStyleBackColor = True
        '
        'WebVersionL
        '
        Me.WebVersionL.AutoSize = True
        Me.WebVersionL.Location = New System.Drawing.Point(8, 32)
        Me.WebVersionL.Name = "WebVersionL"
        Me.WebVersionL.Size = New System.Drawing.Size(80, 12)
        Me.WebVersionL.TabIndex = 1
        Me.WebVersionL.Text = "WebVersion :"
        '
        'FileVersionL
        '
        Me.FileVersionL.AutoSize = True
        Me.FileVersionL.Location = New System.Drawing.Point(8, 16)
        Me.FileVersionL.Name = "FileVersionL"
        Me.FileVersionL.Size = New System.Drawing.Size(76, 12)
        Me.FileVersionL.TabIndex = 0
        Me.FileVersionL.Text = "FileVersion :"
        '
        'WavCompF
        '
        Me.WavCompF.Controls.Add(Me.WavCompLO)
        Me.WavCompF.Controls.Add(Me.WavCompMO)
        Me.WavCompF.Controls.Add(Me.WavCompHO)
        Me.WavCompF.Location = New System.Drawing.Point(152, 88)
        Me.WavCompF.Name = "WavCompF"
        Me.WavCompF.Size = New System.Drawing.Size(152, 72)
        Me.WavCompF.TabIndex = 1
        Me.WavCompF.TabStop = False
        Me.WavCompF.Text = "Wav Compression"
        '
        'WavCompLO
        '
        Me.WavCompLO.AutoSize = True
        Me.WavCompLO.Location = New System.Drawing.Point(8, 48)
        Me.WavCompLO.Name = "WavCompLO"
        Me.WavCompLO.Size = New System.Drawing.Size(127, 16)
        Me.WavCompLO.TabIndex = 2
        Me.WavCompLO.TabStop = True
        Me.WavCompLO.Text = "Low Compression"
        Me.WavCompLO.UseVisualStyleBackColor = True
        '
        'WavCompMO
        '
        Me.WavCompMO.AutoSize = True
        Me.WavCompMO.Location = New System.Drawing.Point(8, 32)
        Me.WavCompMO.Name = "WavCompMO"
        Me.WavCompMO.Size = New System.Drawing.Size(141, 16)
        Me.WavCompMO.TabIndex = 1
        Me.WavCompMO.TabStop = True
        Me.WavCompMO.Text = "Middle Compression"
        Me.WavCompMO.UseVisualStyleBackColor = True
        '
        'WavCompHO
        '
        Me.WavCompHO.AutoSize = True
        Me.WavCompHO.Location = New System.Drawing.Point(8, 16)
        Me.WavCompHO.Name = "WavCompHO"
        Me.WavCompHO.Size = New System.Drawing.Size(128, 16)
        Me.WavCompHO.TabIndex = 0
        Me.WavCompHO.TabStop = True
        Me.WavCompHO.Text = "High Compression"
        Me.WavCompHO.UseVisualStyleBackColor = True
        '
        'ForderOpenF
        '
        Me.ForderOpenF.Controls.Add(Me.UseSettingO)
        Me.ForderOpenF.Controls.Add(Me.UseLastFolderO)
        Me.ForderOpenF.Controls.Add(Me.UseSMLPO)
        Me.ForderOpenF.Controls.Add(Me.SaveFolderC)
        Me.ForderOpenF.Controls.Add(Me.SaveFolderT)
        Me.ForderOpenF.Controls.Add(Me.SaveFolderL)
        Me.ForderOpenF.Controls.Add(Me.OpenFolderC)
        Me.ForderOpenF.Controls.Add(Me.OpenForlderT)
        Me.ForderOpenF.Controls.Add(Me.OpenFolderL)
        Me.ForderOpenF.Location = New System.Drawing.Point(0, 0)
        Me.ForderOpenF.Name = "ForderOpenF"
        Me.ForderOpenF.Size = New System.Drawing.Size(456, 88)
        Me.ForderOpenF.TabIndex = 2
        Me.ForderOpenF.TabStop = False
        Me.ForderOpenF.Text = "Forder Open"
        '
        'UseSettingO
        '
        Me.UseSettingO.AutoSize = True
        Me.UseSettingO.Location = New System.Drawing.Point(304, 68)
        Me.UseSettingO.Name = "UseSettingO"
        Me.UseSettingO.Size = New System.Drawing.Size(100, 16)
        Me.UseSettingO.TabIndex = 7
        Me.UseSettingO.TabStop = True
        Me.UseSettingO.Text = "Setting Folder"
        Me.UseSettingO.UseVisualStyleBackColor = True
        '
        'UseLastFolderO
        '
        Me.UseLastFolderO.AutoSize = True
        Me.UseLastFolderO.Location = New System.Drawing.Point(152, 68)
        Me.UseLastFolderO.Name = "UseLastFolderO"
        Me.UseLastFolderO.Size = New System.Drawing.Size(86, 16)
        Me.UseLastFolderO.TabIndex = 8
        Me.UseLastFolderO.TabStop = True
        Me.UseLastFolderO.Text = "Last Folder"
        Me.UseLastFolderO.UseVisualStyleBackColor = True
        '
        'UseSMLPO
        '
        Me.UseSMLPO.AutoSize = True
        Me.UseSMLPO.Location = New System.Drawing.Point(8, 68)
        Me.UseSMLPO.Name = "UseSMLPO"
        Me.UseSMLPO.Size = New System.Drawing.Size(96, 16)
        Me.UseSMLPO.TabIndex = 6
        Me.UseSMLPO.TabStop = True
        Me.UseSMLPO.Text = "SMLP Folder"
        Me.UseSMLPO.UseVisualStyleBackColor = True
        '
        'SaveFolderC
        '
        Me.SaveFolderC.Location = New System.Drawing.Point(416, 40)
        Me.SaveFolderC.Name = "SaveFolderC"
        Me.SaveFolderC.Size = New System.Drawing.Size(32, 21)
        Me.SaveFolderC.TabIndex = 4
        Me.SaveFolderC.Text = "..."
        Me.SaveFolderC.UseVisualStyleBackColor = True
        '
        'SaveFolderT
        '
        Me.SaveFolderT.Location = New System.Drawing.Point(96, 40)
        Me.SaveFolderT.Name = "SaveFolderT"
        Me.SaveFolderT.Size = New System.Drawing.Size(328, 21)
        Me.SaveFolderT.TabIndex = 5
        '
        'SaveFolderL
        '
        Me.SaveFolderL.AutoSize = True
        Me.SaveFolderL.Location = New System.Drawing.Point(8, 44)
        Me.SaveFolderL.Name = "SaveFolderL"
        Me.SaveFolderL.Size = New System.Drawing.Size(88, 12)
        Me.SaveFolderL.TabIndex = 3
        Me.SaveFolderL.Text = "Save Forlder : "
        '
        'OpenFolderC
        '
        Me.OpenFolderC.Location = New System.Drawing.Point(416, 16)
        Me.OpenFolderC.Name = "OpenFolderC"
        Me.OpenFolderC.Size = New System.Drawing.Size(32, 21)
        Me.OpenFolderC.TabIndex = 2
        Me.OpenFolderC.Text = "..."
        Me.OpenFolderC.UseVisualStyleBackColor = True
        '
        'OpenForlderT
        '
        Me.OpenForlderT.Location = New System.Drawing.Point(96, 16)
        Me.OpenForlderT.Name = "OpenForlderT"
        Me.OpenForlderT.Size = New System.Drawing.Size(328, 21)
        Me.OpenForlderT.TabIndex = 0
        '
        'OpenFolderL
        '
        Me.OpenFolderL.AutoSize = True
        Me.OpenFolderL.Location = New System.Drawing.Point(8, 20)
        Me.OpenFolderL.Name = "OpenFolderL"
        Me.OpenFolderL.Size = New System.Drawing.Size(90, 12)
        Me.OpenFolderL.TabIndex = 1
        Me.OpenFolderL.Text = "Open Forlder : "
        '
        'OKC
        '
        Me.OKC.Location = New System.Drawing.Point(352, 216)
        Me.OKC.Name = "OKC"
        Me.OKC.Size = New System.Drawing.Size(96, 20)
        Me.OKC.TabIndex = 3
        Me.OKC.Text = "OK"
        Me.OKC.UseVisualStyleBackColor = True
        '
        'CancelC
        '
        Me.CancelC.Location = New System.Drawing.Point(240, 216)
        Me.CancelC.Name = "CancelC"
        Me.CancelC.Size = New System.Drawing.Size(96, 20)
        Me.CancelC.TabIndex = 4
        Me.CancelC.Text = "Cancel"
        Me.CancelC.UseVisualStyleBackColor = True
        '
        'BackupF
        '
        Me.BackupF.Controls.Add(Me.PasswordBackupC)
        Me.BackupF.Controls.Add(Me.FileBackupC)
        Me.BackupF.Location = New System.Drawing.Point(152, 160)
        Me.BackupF.Name = "BackupF"
        Me.BackupF.Size = New System.Drawing.Size(152, 52)
        Me.BackupF.TabIndex = 5
        Me.BackupF.TabStop = False
        Me.BackupF.Text = "Backup"
        '
        'PasswordBackupC
        '
        Me.PasswordBackupC.AutoSize = True
        Me.PasswordBackupC.Location = New System.Drawing.Point(8, 32)
        Me.PasswordBackupC.Name = "PasswordBackupC"
        Me.PasswordBackupC.Size = New System.Drawing.Size(127, 16)
        Me.PasswordBackupC.TabIndex = 1
        Me.PasswordBackupC.Text = "Password Backup"
        Me.PasswordBackupC.UseVisualStyleBackColor = True
        '
        'FileBackupC
        '
        Me.FileBackupC.AutoSize = True
        Me.FileBackupC.Location = New System.Drawing.Point(8, 16)
        Me.FileBackupC.Name = "FileBackupC"
        Me.FileBackupC.Size = New System.Drawing.Size(90, 16)
        Me.FileBackupC.TabIndex = 0
        Me.FileBackupC.Text = "File Backup"
        Me.FileBackupC.UseVisualStyleBackColor = True
        '
        'ResetAll
        '
        Me.ResetAll.Location = New System.Drawing.Point(352, 192)
        Me.ResetAll.Name = "ResetAll"
        Me.ResetAll.Size = New System.Drawing.Size(96, 20)
        Me.ResetAll.TabIndex = 6
        Me.ResetAll.Text = "Reset All"
        Me.ResetAll.UseVisualStyleBackColor = True
        '
        'FolderBrowser
        '
        Me.FolderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'LanguageF
        '
        Me.LanguageF.Controls.Add(Me.LanguageC)
        Me.LanguageF.Location = New System.Drawing.Point(0, 88)
        Me.LanguageF.Name = "LanguageF"
        Me.LanguageF.Size = New System.Drawing.Size(152, 44)
        Me.LanguageF.TabIndex = 7
        Me.LanguageF.TabStop = False
        Me.LanguageF.Text = "Language"
        '
        'LanguageC
        '
        Me.LanguageC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LanguageC.Location = New System.Drawing.Point(8, 16)
        Me.LanguageC.Name = "LanguageC"
        Me.LanguageC.Size = New System.Drawing.Size(136, 20)
        Me.LanguageC.TabIndex = 0
        '
        'ProtectF
        '
        Me.ProtectF.Controls.Add(Me.Notice)
        Me.ProtectF.Controls.Add(Me.UnprotectC)
        Me.ProtectF.Controls.Add(Me.ChkProtectC)
        Me.ProtectF.Controls.Add(Me.MPQProtectC)
        Me.ProtectF.Location = New System.Drawing.Point(304, 88)
        Me.ProtectF.Name = "ProtectF"
        Me.ProtectF.Size = New System.Drawing.Size(152, 100)
        Me.ProtectF.TabIndex = 8
        Me.ProtectF.TabStop = False
        Me.ProtectF.Text = "Protect"
        '
        'MPQProtectC
        '
        Me.MPQProtectC.AutoSize = True
        Me.MPQProtectC.Location = New System.Drawing.Point(8, 32)
        Me.MPQProtectC.Name = "MPQProtectC"
        Me.MPQProtectC.Size = New System.Drawing.Size(95, 16)
        Me.MPQProtectC.TabIndex = 0
        Me.MPQProtectC.Text = "MPQ Protect"
        Me.MPQProtectC.UseVisualStyleBackColor = True
        '
        'ChkProtectC
        '
        Me.ChkProtectC.AutoSize = True
        Me.ChkProtectC.Location = New System.Drawing.Point(8, 16)
        Me.ChkProtectC.Name = "ChkProtectC"
        Me.ChkProtectC.Size = New System.Drawing.Size(89, 16)
        Me.ChkProtectC.TabIndex = 1
        Me.ChkProtectC.Text = "Chk Protect"
        Me.ChkProtectC.UseVisualStyleBackColor = True
        '
        'UnprotectC
        '
        Me.UnprotectC.AutoSize = True
        Me.UnprotectC.Location = New System.Drawing.Point(8, 56)
        Me.UnprotectC.Name = "UnprotectC"
        Me.UnprotectC.Size = New System.Drawing.Size(138, 16)
        Me.UnprotectC.TabIndex = 2
        Me.UnprotectC.Text = "Save Unprotect Data"
        Me.UnprotectC.UseVisualStyleBackColor = True
        '
        'Notice
        '
        Me.Notice.AutoSize = True
        Me.Notice.Location = New System.Drawing.Point(8, 72)
        Me.Notice.Name = "Notice"
        Me.Notice.Size = New System.Drawing.Size(141, 24)
        Me.Notice.TabIndex = 3
        Me.Notice.Text = "Notice! This Settting" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Makes Map Size Bigger"
        '
        'SettingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 242)
        Me.Controls.Add(Me.ProtectF)
        Me.Controls.Add(Me.LanguageF)
        Me.Controls.Add(Me.ResetAll)
        Me.Controls.Add(Me.BackupF)
        Me.Controls.Add(Me.CancelC)
        Me.Controls.Add(Me.UpdateF)
        Me.Controls.Add(Me.OKC)
        Me.Controls.Add(Me.ForderOpenF)
        Me.Controls.Add(Me.WavCompF)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "SettingForm"
        Me.Text = "Setting"
        Me.UpdateF.ResumeLayout(False)
        Me.UpdateF.PerformLayout()
        Me.WavCompF.ResumeLayout(False)
        Me.WavCompF.PerformLayout()
        Me.ForderOpenF.ResumeLayout(False)
        Me.ForderOpenF.PerformLayout()
        Me.BackupF.ResumeLayout(False)
        Me.BackupF.PerformLayout()
        Me.LanguageF.ResumeLayout(False)
        Me.ProtectF.ResumeLayout(False)
        Me.ProtectF.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UpdateF As System.Windows.Forms.GroupBox
    Friend WithEvents UpdateC As System.Windows.Forms.Button
    Friend WithEvents AutoUpdateC As System.Windows.Forms.CheckBox
    Friend WithEvents WebVersionL As System.Windows.Forms.Label
    Friend WithEvents FileVersionL As System.Windows.Forms.Label
    Friend WithEvents WavCompF As System.Windows.Forms.GroupBox
    Friend WithEvents WavCompMO As System.Windows.Forms.RadioButton
    Friend WithEvents WavCompHO As System.Windows.Forms.RadioButton
    Friend WithEvents WavCompLO As System.Windows.Forms.RadioButton
    Friend WithEvents ForderOpenF As System.Windows.Forms.GroupBox
    Friend WithEvents UseSettingO As System.Windows.Forms.RadioButton
    Friend WithEvents UseLastFolderO As System.Windows.Forms.RadioButton
    Friend WithEvents UseSMLPO As System.Windows.Forms.RadioButton
    Friend WithEvents SaveFolderC As System.Windows.Forms.Button
    Friend WithEvents SaveFolderT As System.Windows.Forms.TextBox
    Friend WithEvents SaveFolderL As System.Windows.Forms.Label
    Friend WithEvents OpenFolderC As System.Windows.Forms.Button
    Friend WithEvents OpenForlderT As System.Windows.Forms.TextBox
    Friend WithEvents OpenFolderL As System.Windows.Forms.Label
    Friend WithEvents OKC As System.Windows.Forms.Button
    Friend WithEvents CancelC As System.Windows.Forms.Button
    Friend WithEvents BackupF As System.Windows.Forms.GroupBox
    Friend WithEvents PasswordBackupC As System.Windows.Forms.CheckBox
    Friend WithEvents FileBackupC As System.Windows.Forms.CheckBox
    Friend WithEvents ResetAll As System.Windows.Forms.Button
    Friend WithEvents FolderBrowser As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents LanguageF As System.Windows.Forms.GroupBox
    Private WithEvents LanguageC As System.Windows.Forms.ComboBox
    Friend WithEvents ProtectF As System.Windows.Forms.GroupBox
    Friend WithEvents UnprotectC As System.Windows.Forms.CheckBox
    Friend WithEvents ChkProtectC As System.Windows.Forms.CheckBox
    Friend WithEvents MPQProtectC As System.Windows.Forms.CheckBox
    Friend WithEvents Notice As System.Windows.Forms.Label
End Class
