Imports System.Data.SqlClient

Public Class frmGradeInput

    Private Sub frmGradeInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStudentsCombo()
        LoadSubjectsCombo()

        dtpDatePosted.Value = Date.Now
        nudScore.Value = 0
        pbSaving.Visible = False
        lblStatus.Text = ""
        lblStatus.ForeColor = Color.Black

        Me.ActiveControl = cboStudents
    End Sub

    Private Sub LoadStudentsCombo()
        Try
            Dim query As String =
                "SELECT StudentID, 
                        LastName + ', ' + FirstName + ' - ' + ISNULL(Section, 'No Section') AS DisplayName 
                 FROM Students 
                 ORDER BY LastName, FirstName"

            Dim dt As DataTable = DBHelper.GetDataTable(query)

            cboStudents.DataSource = dt
            cboStudents.DisplayMember = "DisplayName"
            cboStudents.ValueMember = "StudentID"
            cboStudents.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Failed to load student list." & vbCrLf & ex.Message,
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSubjectsCombo()
        Dim subjects As String() = {
            "Mathematics",
            "Science",
            "English",
            "Filipino",
            "Araling Panlipunan",
            "TLE",
            "MAPEH / Music",
            "Values Education"
        }

        cboSubjects.Items.AddRange(subjects)
        cboSubjects.SelectedIndex = -1
    End Sub

    Private Sub btnPostGrade_Click(sender As Object, e As EventArgs) Handles btnPostGrade.Click
        ' --- Validation ---
        If cboStudents.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a student.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboStudents.Focus()
            Exit Sub
        End If

        If cboSubjects.SelectedIndex = -1 Then
            MessageBox.Show("Please select a subject.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboSubjects.Focus()
            Exit Sub
        End If

        If nudScore.Value <= 0 OrElse nudScore.Value > 100 Then
            MessageBox.Show("Score must be between 0.01 and 100.00.", "Invalid Score", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            nudScore.Focus()
            Exit Sub
        End If

        ' --- UI: saving state ---
        lblStatus.Text = "Saving grade... Please wait."
        lblStatus.ForeColor = Color.Navy
        pbSaving.Visible = True
        btnPostGrade.Enabled = False
        btnClear.Enabled = False
        btnClose.Enabled = False
        Application.DoEvents()

        Try
            Dim sql As String =
                "INSERT INTO Grades (StudentID, Subject, Score, DatePosted) " &
                "VALUES (@StudentID, @Subject, @Score, @DatePosted)"

            ' Fix: use Dictionary(Of String, Object) to match DBHelper signature
            Dim params As New Dictionary(Of String, Object) From {
                {"@StudentID", Convert.ToInt32(cboStudents.SelectedValue)},
                {"@Subject", cboSubjects.Text.Trim()},
                {"@Score", nudScore.Value},
                {"@DatePosted", dtpDatePosted.Value}
            }

            Dim rowsAffected As Integer = DBHelper.ExecuteNonQuery(sql, params)

            If rowsAffected > 0 Then
                lblStatus.Text = "Grade successfully posted!"
                lblStatus.ForeColor = Color.DarkGreen
                MessageBox.Show("Grade has been recorded successfully.",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ClearForm()
            Else
                Throw New Exception("No rows were inserted. Please try again.")
            End If

        Catch ex As Exception
            lblStatus.Text = "Error: " & ex.Message
            lblStatus.ForeColor = Color.Red
            MessageBox.Show("Failed to save the grade." & vbCrLf & ex.Message,
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally   ' Fix: removed stray '=' character
            pbSaving.Visible = False
            btnPostGrade.Enabled = True
            btnClear.Enabled = True
            btnClose.Enabled = True
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub ClearForm()
        cboStudents.SelectedIndex = -1
        cboSubjects.SelectedIndex = -1
        nudScore.Value = 0
        dtpDatePosted.Value = Date.Now
        lblStatus.Text = ""
        lblStatus.ForeColor = Color.Black
        Me.ActiveControl = cboStudents
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class