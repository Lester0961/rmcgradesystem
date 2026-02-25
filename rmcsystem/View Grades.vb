Imports System.Data.SqlClient

Public Class FrmViewGrades

    Private Sub FrmViewGrades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If CurrentUser.CurrentRole = "Admin" Then
            SetupAdminLayout()
        Else
            SetupStudentLayout()
        End If
        LoadGrades()
    End Sub

    ' ── Admin layout: hide summary/GWA, stretch grade records grid to fill form ──
    Private Sub SetupAdminLayout()
        dgvSummary.Visible = False
        lblSummaryTitle.Visible = False
        pnlGWA.Visible = False
        lblGradingScale.Visible = False

        ' Stretch dgvGrades to fill the whole client area (minus title label and progress bar)
        dgvGrades.Location = New System.Drawing.Point(10, 35)
        dgvGrades.Size = New System.Drawing.Size(Me.ClientSize.Width - 20,
                                                   Me.ClientSize.Height - 70)
        ProgressBar1.Location = New System.Drawing.Point(10, Me.ClientSize.Height - 25)
        ProgressBar1.Size = New System.Drawing.Size(Me.ClientSize.Width - 20, 20)
    End Sub

    ' ── Student layout: everything visible (summary, GWA, grading scale) ──────
    Private Sub SetupStudentLayout()
        dgvSummary.Visible = True
        lblSummaryTitle.Visible = True
        pnlGWA.Visible = True
        lblGradingScale.Visible = True
    End Sub

    Private Sub LoadGrades()
        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
        Application.DoEvents()

        Dim sql As String =
            "SELECT s.FirstName + ' ' + s.LastName AS Student, " &
            "sub.SubjectCode + ' - ' + sub.SubjectName AS Subject, " &
            "g.Term, g.Score, g.DatePosted " &
            "FROM Grades g " &
            "INNER JOIN Students s ON g.StudentID = s.StudentID " &
            "INNER JOIN Subjects sub ON g.SubjectID = sub.SubjectID "

        If CurrentUser.CurrentRole = "Student" Then
            sql &= "WHERE g.StudentID = @sid "
        End If

        sql &= "ORDER BY s.LastName, sub.SubjectCode, " &
               "CASE g.Term WHEN 'Prelim' THEN 1 WHEN 'Midterm' THEN 2 WHEN 'Final' THEN 3 END"

        Dim params As SqlParameter() = If(CurrentUser.CurrentRole = "Student",
                                          {New SqlParameter("@sid", CurrentUser.CurrentStudentID)},
                                          Nothing)
        Try
            dgvGrades.DataSource = DBHelper.GetDataTable(sql, params)
            ProgressBar1.Value = 50
        Catch ex As Exception
            MessageBox.Show("Error loading grades: " & ex.Message)
        End Try

        If CurrentUser.CurrentRole = "Student" Then
            CalculateSummary()
        End If

        ProgressBar1.Value = 100
        ProgressBar1.Visible = False
    End Sub

    Private Sub CalculateSummary()
        Dim studentID As Integer = CurrentUser.CurrentStudentID

        Dim dt As DataTable = DBHelper.GetDataTable(
            "SELECT g.SubjectID, " &
            "sub.SubjectCode + ' - ' + sub.SubjectName AS SubjectName, " &
            "g.Term, g.Score, sub.Units " &
            "FROM Grades g " &
            "INNER JOIN Subjects sub ON g.SubjectID = sub.SubjectID " &
            "WHERE g.StudentID = @sid " &
            "ORDER BY g.SubjectID, " &
            "CASE g.Term WHEN 'Prelim' THEN 1 WHEN 'Midterm' THEN 2 WHEN 'Final' THEN 3 END",
            {New SqlParameter("@sid", studentID)})

        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            lblGWA.Text = "--"
            lblGWADesc.Text = "No grades found"
            dgvSummary.DataSource = Nothing
            Return
        End If

        Dim subjectData As New Dictionary(Of Integer, (Name As String, Scores As Dictionary(Of String, Decimal), Units As Integer))()

        For Each row As DataRow In dt.Rows
            Dim sid As Integer = CInt(row("SubjectID"))
            If Not subjectData.ContainsKey(sid) Then
                subjectData(sid) = (row("SubjectName").ToString(),
                                    New Dictionary(Of String, Decimal)(),
                                    CInt(row("Units")))
            End If
            subjectData(sid).Scores(row("Term").ToString()) = CDec(row("Score"))
        Next

        Dim summaryTable As New DataTable()
        summaryTable.Columns.Add("Subject")
        summaryTable.Columns.Add("Prelim")
        summaryTable.Columns.Add("Midterm")
        summaryTable.Columns.Add("Final")
        summaryTable.Columns.Add("Weighted Avg %")
        summaryTable.Columns.Add("Numerical Grade")
        summaryTable.Columns.Add("Units")
        summaryTable.Columns.Add("Status")

        Dim totalWeighted As Decimal = 0
        Dim totalUnits As Integer = 0

        For Each kvp In subjectData
            Dim scores = kvp.Value.Scores
            Dim units As Integer = kvp.Value.Units
            Dim name As String = kvp.Value.Name

            Dim prelimVal As Decimal = If(scores.ContainsKey("Prelim"), scores("Prelim"), -1)
            Dim midtermVal As Decimal = If(scores.ContainsKey("Midterm"), scores("Midterm"), -1)
            Dim finalVal As Decimal = If(scores.ContainsKey("Final"), scores("Final"), -1)

            Dim prelimStr As String = If(prelimVal >= 0, prelimVal.ToString("F2"), "--")
            Dim midtermStr As String = If(midtermVal >= 0, midtermVal.ToString("F2"), "--")
            Dim finalStr As String = If(finalVal >= 0, finalVal.ToString("F2"), "--")

            Dim weightedAvgStr As String = "--"
            Dim numericalStr As String = "--"
            Dim status As String = "Incomplete"

            If prelimVal >= 0 AndAlso midtermVal >= 0 AndAlso finalVal >= 0 Then
                Dim avg As Decimal = (prelimVal * 0.3D) + (midtermVal * 0.3D) + (finalVal * 0.4D)
                Dim numGrade As Decimal = PercentageToNumerical(avg)
                weightedAvgStr = avg.ToString("F2") & "%"
                numericalStr = numGrade.ToString("F2")
                status = "Complete"
                totalWeighted += numGrade * units
                totalUnits += units
            End If

            summaryTable.Rows.Add(name, prelimStr, midtermStr, finalStr,
                                  weightedAvgStr, numericalStr,
                                  units.ToString(), status)
        Next

        dgvSummary.DataSource = summaryTable
        dgvSummary.Refresh()

        For Each dgvRow As DataGridViewRow In dgvSummary.Rows
            If dgvRow.Index < 0 Then Continue For
            Try
                Dim statusVal As String = If(dgvRow.Cells("Status").Value?.ToString(), "")
                If statusVal = "Complete" Then
                    dgvRow.DefaultCellStyle.BackColor = Drawing.Color.FromArgb(220, 255, 220)
                    dgvRow.DefaultCellStyle.ForeColor = Drawing.Color.DarkGreen
                Else
                    dgvRow.DefaultCellStyle.BackColor = Drawing.Color.FromArgb(255, 240, 200)
                    dgvRow.DefaultCellStyle.ForeColor = Drawing.Color.DarkOrange
                End If
            Catch
                Continue For
            End Try
        Next

        If totalUnits > 0 Then
            Dim gwa As Decimal = Math.Round(totalWeighted / totalUnits, 2)
            lblGWA.Text = gwa.ToString("F2")
            lblGWADesc.Text = "General Weighted Average"
        Else
            lblGWA.Text = "--"
            lblGWADesc.Text = "General Weighted Average"
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadGrades()
    End Sub

    Private Function PercentageToNumerical(percentage As Decimal) As Decimal
        Select Case True
            Case percentage >= 98 : Return 1D
            Case percentage >= 95 : Return 1.25D
            Case percentage >= 93 : Return 1.5D
            Case percentage >= 90 : Return 1.75D
            Case percentage >= 87 : Return 2D
            Case percentage >= 84 : Return 2.25D
            Case percentage >= 81 : Return 2.5D
            Case percentage >= 79 : Return 2.75D
            Case percentage >= 75 : Return 3D
            Case Else : Return 5D
        End Select
    End Function

End Class