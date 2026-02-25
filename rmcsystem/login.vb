Imports System.Data.SqlClient

Public Class FrmLogin

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            lblMessage.Text = "Username and password required!"
            Return
        End If

        Dim params() As SqlParameter = {
            New SqlParameter("@u", txtUsername.Text.Trim()),
            New SqlParameter("@p", txtPassword.Text.Trim())
        }

        Dim dt As DataTable = DBHelper.GetDataTable(
            "SELECT Role, StudentID FROM Users WHERE Username=@u AND Password=@p", params)

        If dt.Rows.Count > 0 Then
            CurrentUser.CurrentUsername = txtUsername.Text.Trim()
            CurrentUser.CurrentRole = dt.Rows(0)("Role").ToString()
            If Not IsDBNull(dt.Rows(0)("StudentID")) Then
                CurrentUser.CurrentStudentID = CInt(dt.Rows(0)("StudentID"))
            End If

            Dim mdi As New FrmMDIParent()
            mdi.Show()
            Me.Hide()
        Else
            lblMessage.Text = "Invalid credentials!"
        End If
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

End Class