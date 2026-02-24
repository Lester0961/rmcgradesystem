Public Class frmMDIParent

    Private Sub frmMDIParent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyRoleBasedVisibility()
    End Sub

    Private Sub ApplyRoleBasedVisibility()
        If CurrentUser.IsAdmin() Then
            mnuStudents.Visible = True
            mnuPostGRades.Visible = True
            mnuView.Text = "&View"
            mnuViewGrades.Text = "&View All Grades"
        ElseIf CurrentUser.IsStudent() Then
            mnuStudents.Visible = False
            mnuPostGRades.Visible = False
            mnuView.Text = "&My Profile"
            mnuViewGrades.Text = "&My Grades"
        Else
            mnuStudents.Visible = False
            mnuPostGRades.Visible = False
        End If

        mnuFile.Visible = True
    End Sub

    Private Sub mnuManageStudents_Click(sender As Object, e As EventArgs) Handles mnuManageStudents.Click
        'Dim frm As New frmStudentInput()
        'frm.MdiParent = Me
        'frm.Show()
        MessageBox.Show("Student management coming soon.", "Info")
    End Sub

    Private Sub mnuPostGrade_Click(sender As Object, e As EventArgs) Handles mnuPostGrade.Click
        Dim frm As New frmGradeInput()
        frm.MdiParent = Me
        frm.Show()
    End Sub

    Private Sub mnuViewGrades_Click(sender As Object, e As EventArgs) Handles mnuViewGrades.Click
        'Dim frm As New frmViewGrades()
        'frm.MdiParent = Me
        'frm.Show()
        MessageBox.Show("View grades coming soon.", "Info")
    End Sub

    Private Sub mnuLogout_Click(sender As Object, e As EventArgs) Handles mnuLogout.Click
        CurrentUser.ClearCurrentUser()

        For Each child As Form In Me.MdiChildren
            child.Close()
        Next

        Me.Close() ' Loop will reopen Login
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Dim confirm As DialogResult = MessageBox.Show(
        "Are you sure you want to exit the application?",
        "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If confirm = DialogResult.Yes Then
            MainModule.IsExiting = True  ' Set flag BEFORE closing
            Application.Exit()
        End If
    End Sub

End Class