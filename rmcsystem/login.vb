Imports System.Data.SqlClient

Public Class Login

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Clear()
        txtPassword.Clear()
        txtUsername.Focus()
        lblMessage.Text = ""
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "Please enter both username and password."
            txtUsername.Focus()
            Return
        End If

        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        Try
            Using conn As SqlConnection = DBHelper.GetOpenConnection()
                If conn Is Nothing Then Return

                Dim query As String = "
                    SELECT UserID, Username, Role, ISNULL(StudentID, 0) AS StudentID
                    FROM Users
                    WHERE Username = @Username AND Password = @Password"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Username", username)
                    cmd.Parameters.AddWithValue("@Password", password)

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            CurrentUser.CurrentUserID = Convert.ToInt32(reader("UserID"))
                            CurrentUser.CurrentUsername = reader("Username").ToString()
                            CurrentUser.CurrentRole = reader("Role").ToString()
                            CurrentUser.CurrentStudentID = Convert.ToInt32(reader("StudentID"))

                            lblMessage.ForeColor = Color.Green
                            lblMessage.Text = "Login successful! Loading dashboard..."
                            System.Threading.Thread.Sleep(800)

                            Me.Close()

                            txtPassword.Clear()
                        Else
                            lblMessage.ForeColor = Color.Red
                            lblMessage.Text = "Invalid username or password. Please try again."
                            txtPassword.Clear()
                            txtPassword.Focus()
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Database error during login: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            lblMessage.Text = "An error occurred. Please try again later."
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

End Class