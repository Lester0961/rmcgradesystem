Imports System.Data.SqlClient

Public Class frmStudentInput

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FrmStudentInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStudents()
    End Sub

    Private Sub LoadStudents()
        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
        Application.DoEvents()
        dgvStudents.DataSource = DBHelper.GetDataTable(
            "SELECT StudentID, FirstName, LastName, Section, Contact FROM Students ORDER BY LastName")
        ProgressBar1.Value = 100
        ProgressBar1.Visible = False
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
       String.IsNullOrWhiteSpace(txtLastName.Text) OrElse
       String.IsNullOrWhiteSpace(txtSection.Text) Then
            MessageBox.Show("First Name, Last Name, and Section are required.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
       String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Username and Password are required to create an account.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim checkDT As DataTable = DBHelper.GetDataTable(
        "SELECT COUNT(*) AS cnt FROM Users WHERE Username = @u",
        {New SqlParameter("@u", txtUsername.Text.Trim())})

        If checkDT IsNot Nothing AndAlso CInt(checkDT.Rows(0)("cnt")) > 0 Then
            MessageBox.Show("Username '" & txtUsername.Text.Trim() & "' is already taken. Please choose a different username.",
                        "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            txtUsername.SelectAll()
            Return
        End If

        Try
            Dim paramsStudent() As SqlParameter = {
            New SqlParameter("@fn", txtFirstName.Text.Trim()),
            New SqlParameter("@ln", txtLastName.Text.Trim()),
            New SqlParameter("@sec", txtSection.Text.Trim()),
            New SqlParameter("@cont", txtContact.Text.Trim())
        }

            Dim newStudentID As Integer = DBHelper.ExecuteInsertGetID(
            "INSERT INTO Students (FirstName, LastName, Section, Contact) " &
            "VALUES (@fn, @ln, @sec, @cont)", paramsStudent)

            If newStudentID = 0 Then
                MessageBox.Show("Failed to create student record.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim paramsUser() As SqlParameter = {
            New SqlParameter("@u", txtUsername.Text.Trim()),
            New SqlParameter("@p", txtPassword.Text.Trim()),
            New SqlParameter("@sid", newStudentID)
        }

            Dim userInserted As Boolean = False
            Try
                DBHelper.ExecuteNonQuery(
                "INSERT INTO Users (Username, Password, Role, StudentID) " &
                "VALUES (@u, @p, 'Student', @sid)", paramsUser)
                userInserted = True
            Catch exUser As Exception
                DBHelper.ExecuteNonQuery(
                "DELETE FROM Students WHERE StudentID=@id",
                {New SqlParameter("@id", newStudentID)})

                MessageBox.Show("Failed to create user account: " & exUser.Message &
                            vbCrLf & "Student record has been rolled back.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            If userInserted Then
                MessageBox.Show("Student and account created successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadStudents()
                ClearFields()
            End If

        Catch ex As Exception
            MessageBox.Show("Error adding student: " & ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If String.IsNullOrWhiteSpace(lblStudentID.Text) Then
            MessageBox.Show("Please select a student from the list to update.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
           String.IsNullOrWhiteSpace(txtLastName.Text) OrElse
           String.IsNullOrWhiteSpace(txtSection.Text) Then
            MessageBox.Show("First Name, Last Name, and Section are required.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim params() As SqlParameter = {
                New SqlParameter("@fn", txtFirstName.Text.Trim()),
                New SqlParameter("@ln", txtLastName.Text.Trim()),
                New SqlParameter("@sec", txtSection.Text.Trim()),
                New SqlParameter("@cont", txtContact.Text.Trim()),
                New SqlParameter("@id", CInt(lblStudentID.Text))
            }

            DBHelper.ExecuteNonQuery(
                "UPDATE Students SET FirstName=@fn, LastName=@ln, Section=@sec, Contact=@cont " &
                "WHERE StudentID=@id", params)

            MessageBox.Show("Student updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadStudents()
            ClearFields()

        Catch ex As Exception
            MessageBox.Show("Error updating student: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If String.IsNullOrWhiteSpace(lblStudentID.Text) Then
            MessageBox.Show("Please select a student from the list to delete.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim confirm As DialogResult = MessageBox.Show(
        "Are you sure you want to delete this student and their account? This cannot be undone.",
        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If confirm = DialogResult.No Then Return

        Try
            Dim sid As Integer = CInt(lblStudentID.Text)

            DBHelper.ExecuteNonQuery("DELETE FROM Grades WHERE StudentID=@id",
            {New SqlParameter("@id", sid)})

            DBHelper.ExecuteNonQuery("DELETE FROM Users WHERE StudentID=@id",
            {New SqlParameter("@id", sid)})

            DBHelper.ExecuteNonQuery("DELETE FROM Students WHERE StudentID=@id",
            {New SqlParameter("@id", sid)})

            MessageBox.Show("Student deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadStudents()
            ClearFields()

        Catch ex As Exception
            MessageBox.Show("Error deleting student: " & ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadStudents()
        ClearFields()
    End Sub

    Private Sub DgvStudents_SelectionChanged(sender As Object, e As EventArgs) Handles dgvStudents.SelectionChanged
        If dgvStudents.SelectedRows.Count > 0 Then
            Dim row = dgvStudents.SelectedRows(0)
            lblStudentID.Text = row.Cells("StudentID").Value.ToString()
            txtFirstName.Text = row.Cells("FirstName").Value.ToString()
            txtLastName.Text = row.Cells("LastName").Value.ToString()
            txtSection.Text = row.Cells("Section").Value.ToString()
            txtContact.Text = If(IsDBNull(row.Cells("Contact").Value), "",
                                 row.Cells("Contact").Value.ToString())
            txtUsername.Clear()
            txtPassword.Clear()
        End If
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        CLearFields()
    End Sub

    Private Sub CLearFields()
        lblStudentID.Text = ""
        txtFirstName.Clear()
        txtLastName.Clear()
        txtSection.Clear()
        txtContact.Clear()
        txtUsername.Clear()
        txtPassword.Clear()
    End Sub


End Class