﻿'------------------------------------------------------------------------------
' <auto-generated>
'     이 코드는 도구를 사용하여 생성되었습니다.
'     런타임 버전:2.0.50727.5477
'
'     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
'     이러한 변경 내용이 손실됩니다.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    '이 클래스는 ResGen 또는 Visual Studio와 같은 도구를 통해 StronglyTypedResourceBuilder
    '클래스에서 자동으로 생성되었습니다.
    '멤버를 추가하거나 제거하려면 .ResX 파일을 편집한 다음 /str 옵션을 사용하여 ResGen을
    '다시 실행하거나 VS 프로젝트를 다시 빌드하십시오.
    '''<summary>
    '''  지역화된 문자열 등을 찾기 위한 강력한 형식의 리소스 클래스입니다.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  이 클래스에서 사용하는 캐시된 ResourceManager 인스턴스를 반환합니다.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("StarcraftMapLockerProject.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  이 강력한 형식의 리소스 클래스를 사용하여 모든 리소스 조회에 대한 현재 스레드의 CurrentUICulture
        '''  속성을 재정의합니다.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        Friend ReadOnly Property Icon() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("Icon", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  --English--
        '''0/Name/English
        '''0/Locale/en-US
        '''0/Open/Open Map
        '''0/Save/Save Map
        '''0/Protect/Protect
        '''0/Unprotect/Unprotect
        '''0/Setting/Setting
        '''0/About/About
        '''0/Password/Password
        '''0/PWWrite/password
        '''0/OpenFolder/Open Folder
        '''0/SaveFolder/Save Folder
        '''0/SMLPFolder/SMLP Folder
        '''0/LastFolder/Last Folder
        '''0/SettingFolder/Setting Folder
        '''0/Update/Update
        '''0/FileVer/File Version
        '''0/WebVer/Web Version
        '''0/AutoUpdate/AutoUpdate
        '''0/WavComp/Wav Compression
        '''0/WavHigh/High Compression
        '''0/WavMiddle/Middle Compression
        '''0/Wav[나머지 문자열은 잘림]&quot;;과(와) 유사한 지역화된 문자열을 찾습니다.
        '''</summary>
        Friend ReadOnly Property LanguageData() As String
            Get
                Return ResourceManager.GetString("LanguageData", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Name
        '''Locale
        '''
        '''Open
        '''Save
        '''Protect
        '''Unprotect
        '''Setting
        '''About
        '''
        '''Password
        '''PWWrite
        '''
        '''OpenFolder
        '''SaveFolder
        '''SMLPFolder
        '''LastFolder
        '''SettingFolder
        '''
        '''Update
        '''FileVer
        '''WebVer
        '''AutoUpdate
        '''
        '''WavComp
        '''WavHigh
        '''WavMiddle
        '''WavLow
        '''
        '''Backup
        '''BackupFile
        '''BackupPW
        '''
        '''Language
        '''
        '''ChkProtect
        '''MPQProtect
        '''SaveUnprotectData
        '''Notice
        '''
        '''Reset
        '''Cancel
        '''OK
        '''
        '''FilterOpen
        '''FilterSaveO
        '''FilterSaveE
        '''
        '''Msg_CheckUpdate
        '''Msg_NewUpdate
        '''Msg_CheckComplete
        '''Msg_InternetConnection
        '''
        '''Msg_MapOpen
        '''Msg_MapValid
        '''Msg_MPQReadStart
        '''Ms[나머지 문자열은 잘림]&quot;;과(와) 유사한 지역화된 문자열을 찾습니다.
        '''</summary>
        Friend ReadOnly Property LanguageName() As String
            Get
                Return ResourceManager.GetString("LanguageName", resourceCulture)
            End Get
        End Property
        
        Friend ReadOnly Property SFmpq() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("SFmpq", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
        
        Friend ReadOnly Property Storm() As Byte()
            Get
                Dim obj As Object = ResourceManager.GetObject("Storm", resourceCulture)
                Return CType(obj,Byte())
            End Get
        End Property
    End Module
End Namespace
