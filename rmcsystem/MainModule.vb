Module MainModule

    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        Try
            Do
                Dim loginForm As New Login()
                loginForm.ShowDialog()

                If CurrentUser.CurrentUserID > 0 Then
                    Application.Run(New frmMDIParent())
                Else
                    Exit Do ' User closed login without logging in
                End If
            Loop

        Catch ex As Exception
            MessageBox.Show("Startup error: " & ex.Message & vbCrLf & vbCrLf & ex.StackTrace,
                            "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module