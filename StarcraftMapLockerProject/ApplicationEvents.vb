Namespace My

    ' MyApplication에 대해 다음 이벤트를 사용할 수 있습니다.
    ' 
    ' Startup: 응용 프로그램이 시작되고 시작 폼이 만들어지기 전에 발생합니다.
    ' Shutdown: 모든 응용 프로그램 폼이 닫힌 후에 발생합니다. 이 이벤트는 응용 프로그램이 비정상적으로 종료되는 경우에는 발생하지 않습니다.
    ' UnhandledException: 응용 프로그램에서 처리되지 않은 예외가 발생하는 경우 이 이벤트가 발생합니다.
    ' StartupNextInstance: 단일 인스턴스 응용 프로그램을 시작할 때 해당 응용 프로그램이 이미 활성 상태인 경우 발생합니다. 
    ' NetworkAvailabilityChanged: 네트워크가 연결되거나 연결이 끊어질 때 발생합니다.
    Partial Friend Class MyApplication
        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            Dim Storm As Boolean, SFmpq As Boolean
            Storm = IO.File.Exists("Storm.dll")
            SFmpq = IO.File.Exists("SFmpq.dll")
            If Not (Storm And SFmpq) Then
                If My.Computer.Network.IsAvailable AndAlso My.Computer.Network.Ping(Server) Then
                    If Not Storm Then My.Computer.Network.DownloadFile(StormURL, "Storm.dll")
                    If Not SFmpq Then My.Computer.Network.DownloadFile(SFmpqURL, "SFmpq.dll")
                Else
                    If Not Storm Then System.IO.File.WriteAllBytes("Storm.dll", My.Resources.Storm)
                    If Not SFmpq Then System.IO.File.WriteAllBytes("SFmpq.dll", My.Resources.SFmpq)
                End If
            End If
        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Dim Print As New IO.StreamWriter("ErrorLog " & Now.ToString("yyyy-MM-dd hh-mm-ss") & ".log")
            Print.WriteLine("StarcraftMapLockerProject Error Log")
            Print.WriteLine("Send log to file Email : modmapper@tkyuki.kr")
            Print.WriteLine("---Error Message---")
            Print.WriteLine(e.Exception.Message)
            Print.WriteLine()
            Print.WriteLine("Source : " & e.Exception.Source)
            Print.WriteLine("Methood : " & e.Exception.TargetSite.ToString())
            Print.WriteLine()
            Print.WriteLine(e.Exception.StackTrace)
            Print.Close()
            e.ExitApplication = (MsgBox("Runtime Error Detected! Retry?", MsgBoxStyle.Critical Or MsgBoxStyle.RetryCancel) = MsgBoxResult.Cancel)
        End Sub
    End Class

End Namespace

