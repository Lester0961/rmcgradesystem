Imports System.Data.SqlClient

Public Class FrmGradeInput

    Private Sub FrmGradeInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim dtStudents As DataTable = DBHelper.GetDataTable(
                "SELECT StudentID, FirstName + ' ' + LastName AS FullName FROM Students ORDER BY LastName")

            If dtStudents IsNot Nothing AndAlso dtStudents.Rows.Count > 0 Then
                cboStudent.DataSource = dtStudents
                cboStudent.DisplayMember = "FullName"
                cboStudent.ValueMember = "StudentID"
            Else
                MessageBox.Show("No students found in the database.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnPostGrade.Enabled = False  '
            End If

            Dim dtSubjects As DataTable = DBHelper.GetDataTable(
                "SELECT SubjectID, SubjectCode + ' - ' + SubjectName AS Subject FROM Subjects ORDER BY SubjectCode")

            If dtSubjects IsNot Nothing AndAlso dtSubjects.Rows.Count > 0 Then
                cboSubject.DataSource = dtSubjects
                cboSubject.DisplayMember = "Subject"
                cboSubject.ValueMember = "SubjectID"
            Else
                MessageBox.Show("No subjects found in the database.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnPostGrade.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading form data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnCalculateTerm_Click(sender As Object, e As EventArgs) Handles btnCalculateTerm.Click
        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
        For i As Integer = 1 To 100 Step 10
            ProgressBar1.Value = i
            Application.DoEvents()
        Next

        Dim quizzes As Decimal = nudQuizzes.Value * 0.3D
        Dim assign As Decimal = nudAssignments.Value * 0.1D
        Dim attend As Decimal = nudAttendance.Value * 0.1D
        Dim proj As Decimal = nudProjects.Value * 0.2D
        Dim exam As Decimal = nudExam.Value * 0.3D
        Dim termPercent As Decimal = quizzes + assign + attend + proj + exam

        lblTermPercentage.Text = termPercent.ToString("F2") & "%"
        ProgressBar1.Value = 100
        ProgressBar1.Visible = False
        btnPostGrade.Enabled = True
    End Sub

    Private Sub BtnPostGrade_Click(sender As Object, e As EventArgs) Handles btnPostGrade.Click
        If cboStudent.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a student.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cboSubject.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a subject.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(cboTerm.Text) Then
            MessageBox.Show("Please select a term.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(lblTermPercentage.Text) OrElse
           Not lblTermPercentage.Text.Contains("%") Then
            MessageBox.Show("Please calculate the term grade first.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim score As Decimal
        If Not Decimal.TryParse(lblTermPercentage.Text.Replace("%", "").Trim(), score) Then
            MessageBox.Show("Invalid score value. Please recalculate.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Dim params() As SqlParameter = {
                New SqlParameter("@sid", cboStudent.SelectedValue),
                New SqlParameter("@subid", cboSubject.SelectedValue),
                New SqlParameter("@term", cboTerm.Text),
                New SqlParameter("@score", score)
            }

            DBHelper.ExecuteNonQuery(
                "INSERT INTO Grades (StudentID, SubjectID, Term, Score) " &
                "VALUES (@sid, @subid, @term, @score)", params)

            ProgressBar1.Visible = True
            ProgressBar1.Value = 0
            For i As Integer = 1 To 100 Step 20
                ProgressBar1.Value = i
                Application.DoEvents()
            Next

            MessageBox.Show("Grade posted successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            ProgressBar1.Visible = False

            lblTermPercentage.Text = ""
            btnPostGrade.Enabled = False

        Catch ex As Exception
            MessageBox.Show("Error posting grade: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cboStudent.SelectedIndex = -1
        cboSubject.SelectedIndex = -1
        cboTerm.SelectedIndex = -1
        nudQuizzes.Value = 0
        nudAssignments.Value = 0
        nudAttendance.Value = 0
        nudProjects.Value = 0
        nudExam.Value = 0
        lblTermPercentage.Text = ""
        btnPostGrade.Enabled = False
    End Sub

End Class