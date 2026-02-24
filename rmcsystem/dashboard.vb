Public Class FrmMDIParent
    Private Sub FrmMDIParent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim isAdmin As Boolean = (CurrentUser.CurrentRole = "Admin")
        mnuManage.Visible = isAdmin
        mnuPostGrades.Visible = isAdmin
        mnuGrades.Visible = True
    End Sub

    Private Sub MnuStudents_Click(sender As Object, e As EventArgs) Handles mnuManageStudents.Click
        Dim f As New frmStudentInput() With {.MdiParent = Me}
        f.Show()
    End Sub

    Private Sub MnuPostGrades_Click(sender As Object, e As EventArgs) Handles mnuPostGrades.Click
        Dim f As New FrmGradeInput() With {.MdiParent = Me}
        f.Show()
    End Sub

    Private Sub MnuViewGrades_Click(sender As Object, e As EventArgs) Handles mnuViewGrades.Click
        Dim f As New FrmViewGrades() With {.MdiParent = Me}
        f.Show()
    End Sub

    Private Sub MnuLogout_Click(sender As Object, e As EventArgs) Handles mnuLogout.Click
        CurrentUser.ClearCurrent()
        For Each frm As Form In Me.MdiChildren
            frm.Close()
        Next
        Dim login As New frmLogin()
        login.Show()
        Me.Close()
    End Sub
End Class