Imports System.Data.SqlClient

Public Class FrmGradeInput

    Private _loading As Boolean = False   ' flag to suppress events during data load

    Private Sub FrmGradeInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _loading = True
        Try
            Dim dtStudents As DataTable = DBHelper.GetDataTable(
                "SELECT StudentID, FirstName + ' ' + LastName AS FullName FROM Students ORDER BY LastName")

            If dtStudents IsNot Nothing AndAlso dtStudents.Rows.Count > 0 Then
                cboStudent.DataSource = dtStudents
                cboStudent.DisplayMember = "FullName"
                cboStudent.ValueMember = "StudentID"
                cboStudent.SelectedIndex = -1
            Else
                MessageBox.Show("No students found in the database.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnPostGrade.Enabled = False
            End If

            Dim dtSubjects As DataTable = DBHelper.GetDataTable(
                "SELECT SubjectID, SubjectCode + ' - ' + SubjectName AS Subject FROM Subjects ORDER BY SubjectCode")

            If dtSubjects IsNot Nothing AndAlso dtSubjects.Rows.Count > 0 Then
                cboSubject.DataSource = dtSubjects
                cboSubject.DisplayMember = "Subject"
                cboSubject.ValueMember = "SubjectID"
                cboSubject.SelectedIndex = -1
            Else
                MessageBox.Show("No subjects found in the database.", "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
                btnPostGrade.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show("Error loading form data: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            _loading = False
        End Try
    End Sub

    ' ── Student changed → clear everything below (subject, term, components, result) ──
    Private Sub CboStudent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStudent.SelectedIndexChanged
        If _loading Then Return
        _loading = True
        cboSubject.SelectedIndex = -1
        cboTerm.SelectedIndex = -1
        _loading = False
        ClearComponents()
        ClearCalculatedGrade()
    End Sub

    ' ── Subject changed → clear term, components, and calculated grade ────────
    Private Sub CboSubject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSubject.SelectedIndexChanged
        If _loading Then Return
        _loading = True
        cboTerm.SelectedIndex = -1
        _loading = False
        ClearComponents()
        ClearCalculatedGrade()
    End Sub

    ' ── Term changed → clear only components and calculated grade ─────────────
    Private Sub CboTerm_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTerm.SelectedIndexChanged
        If _loading Then Return
        ClearComponents()
        ClearCalculatedGrade()
    End Sub

    ' ── Helpers ───────────────────────────────────────────────────────────────
    Private Sub ClearComponents()
        nudQuizzes.Value = 0
        nudAssignments.Value = 0
        nudAttendance.Value = 0
        nudProjects.Value = 0
        nudExam.Value = 0
    End Sub

    Private Sub ClearCalculatedGrade()
        lblTermPercentage.Text = ""
        btnPostGrade.Enabled = False
    End Sub

    ' ─────────────────────────────────────────────────────────────────────────
    Private Sub BtnCalculateTerm_Click(sender As Object, e As EventArgs) Handles btnCalculateTerm.Click
        ' Guard: student, subject, and term must be selected first
        If cboStudent.SelectedIndex < 0 Then
            MessageBox.Show("Please select a student first.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If cboSubject.SelectedIndex < 0 Then
            MessageBox.Show("Please select a subject first.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If cboTerm.SelectedIndex < 0 Then
            MessageBox.Show("Please select a term first.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

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
        If cboStudent.SelectedValue Is Nothing OrElse cboStudent.SelectedIndex < 0 Then
            MessageBox.Show("Please select a student.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cboSubject.SelectedValue Is Nothing OrElse cboSubject.SelectedIndex < 0 Then
            MessageBox.Show("Please select a subject.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(cboTerm.Text) OrElse cboTerm.SelectedIndex < 0 Then
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

            ' Clear only term-level and below; keep student & subject selected
            _loading = True
            cboTerm.SelectedIndex = -1
            _loading = False
            ClearComponents()
            ClearCalculatedGrade()

        Catch ex As Exception
            MessageBox.Show("Error posting grade: " & ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        _loading = True
        cboStudent.SelectedIndex = -1
        cboSubject.SelectedIndex = -1
        cboTerm.SelectedIndex = -1
        _loading = False
        ClearComponents()
        ClearCalculatedGrade()
    End Sub

End Class