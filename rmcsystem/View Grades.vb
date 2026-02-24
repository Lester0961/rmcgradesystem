Imports System.Data.SqlClient

Public Class FrmViewGrades

    Private Sub FrmViewGrades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadGrades()
    End Sub

    Private Sub LoadGrades()
        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
        Application.DoEvents()

        Dim sql As String = "SELECT s.FirstName + ' ' + s.LastName AS Student, " &
                            "sub.SubjectCode + ' - ' + sub.SubjectName AS Subject, " &
                            "g.Term, g.Score, g.DatePosted " &
                            "FROM Grades g " &
                            "INNER JOIN Students s ON g.StudentID = s.StudentID " &
                            "INNER JOIN Subjects sub ON g.SubjectID = sub.SubjectID "

        If CurrentUser.CurrentRole = "Student" Then
            sql &= "WHERE g.StudentID = @sid "
        End If

        sql &= "ORDER BY s.LastName, sub.SubjectCode, g.Term"

        Dim params As SqlParameter() = If(CurrentUser.CurrentRole = "Student",
                                          {New SqlParameter("@sid", CurrentUser.CurrentStudentID)},
                                          Nothing)

        Try
            dgvGrades.DataSource = DBHelper.GetDataTable(sql, params)
            ProgressBar1.Value = 100
        Catch ex As Exception
            MessageBox.Show("Error loading grades: " & ex.Message)
        Finally
            ProgressBar1.Visible = False
        End Try
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadGrades()
        lblGWA.Text = "GWA: --"
    End Sub

    Private Sub BtnCalculateGWA_Click(sender As Object, e As EventArgs) Handles btnCalculateGWA.Click
        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
        Application.DoEvents()

        Dim studentID As Integer = If(CurrentUser.CurrentRole = "Student", CurrentUser.CurrentStudentID, 0)
        If studentID = 0 Then
            MessageBox.Show("GWA calculation is student-specific. Select a student or login as one.")
            ProgressBar1.Visible = False
            Return
        End If

        Dim dt As DataTable = DBHelper.GetDataTable(
            "SELECT g.SubjectID, g.Term, g.Score, sub.Units " &
            "FROM Grades g INNER JOIN Subjects sub ON g.SubjectID = sub.SubjectID " &
            "WHERE g.StudentID = @sid ORDER BY g.SubjectID, g.Term",
            {New SqlParameter("@sid", studentID)})

        Dim subjectScores As New Dictionary(Of Integer, List(Of Decimal))()
        Dim subjectUnits As New Dictionary(Of Integer, Integer)()

        For Each row As DataRow In dt.Rows
            Dim sid As Integer = CInt(row("SubjectID"))
            If Not subjectScores.ContainsKey(sid) Then subjectScores(sid) = New List(Of Decimal)()
            subjectScores(sid).Add(CDec(row("Score")))
            subjectUnits(sid) = CInt(row("Units"))
        Next

        Dim totalWeighted As Decimal = 0
        Dim totalUnits As Integer = 0
        Dim stepValue As Integer = If(subjectScores.Count > 0, 100 \ subjectScores.Count, 100)

        For Each kvp In subjectScores
            If kvp.Value.Count = 3 Then
                Dim prelim As Decimal = kvp.Value(0)
                Dim midterm As Decimal = kvp.Value(1)
                Dim final As Decimal = kvp.Value(2)
                Dim weightedTermAvg As Decimal = (prelim * 0.3D) + (midterm * 0.3D) + (final * 0.4D)
                Dim numericalGrade As Decimal = PercentageToNumerical(weightedTermAvg)
                totalWeighted += numericalGrade * subjectUnits(kvp.Key)
                totalUnits += subjectUnits(kvp.Key)
            End If

            ProgressBar1.Value += stepValue
            Application.DoEvents()
            Threading.Thread.Sleep(100)
        Next

        Dim gwa As Decimal = If(totalUnits > 0, totalWeighted / totalUnits, 0)
        lblGWA.Text = $"GWA: {gwa:F2} (1.00 is highest)"

        ProgressBar1.Value = 100
        ProgressBar1.Visible = False
    End Sub

    Private Function PercentageToNumerical(percentage As Decimal) As Decimal
        Select Case True
            Case percentage >= 96 : Return 1.0
            Case percentage >= 90 : Return 1.25
            Case percentage >= 85 : Return 1.5
            Case percentage >= 80 : Return 1.75
            Case percentage >= 75 : Return 2.0
            Case Else : Return 5.0
        End Select
    End Function
End Class