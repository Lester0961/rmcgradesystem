Module MainModule

    Public IsExiting As Boolean = False  ' Add this flag

    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        Try
            Do
                Dim loginForm As New Login()
                loginForm.ShowDialog()

                If IsExiting Then Exit Do  ' Respect exit flag

                If CurrentUser.CurrentUserID > 0 Then
                    Application.Run(New frmMDIParent())
                Else
                    Exit Do
                End If
            Loop

        Catch ex As Exception
            MessageBox.Show("Startup error: " & ex.Message & vbCrLf & vbCrLf & ex.StackTrace,
                            "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module