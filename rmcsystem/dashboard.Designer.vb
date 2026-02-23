<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMDIParent
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuStudents = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuManageStudents = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPostGRades = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPostGrade = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewGrades = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuStudents, Me.mnuPostGRades, Me.mnuView})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(632, 24)
        Me.mnuMain.TabIndex = 9
        Me.mnuMain.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLogout, Me.mnuExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "&File"
        '
        'mnuLogout
        '
        Me.mnuLogout.Name = "mnuLogout"
        Me.mnuLogout.Size = New System.Drawing.Size(112, 22)
        Me.mnuLogout.Text = "&Logout"
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(112, 22)
        Me.mnuExit.Text = "E&xit"
        '
        'mnuStudents
        '
        Me.mnuStudents.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuManageStudents})
        Me.mnuStudents.Name = "mnuStudents"
        Me.mnuStudents.Size = New System.Drawing.Size(65, 20)
        Me.mnuStudents.Text = "&Students"
        '
        'mnuManageStudents
        '
        Me.mnuManageStudents.Name = "mnuManageStudents"
        Me.mnuManageStudents.Size = New System.Drawing.Size(180, 22)
        Me.mnuManageStudents.Text = "Manage &Students"
        '
        'mnuPostGRades
        '
        Me.mnuPostGRades.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPostGrade})
        Me.mnuPostGRades.Name = "mnuPostGRades"
        Me.mnuPostGRades.Size = New System.Drawing.Size(55, 20)
        Me.mnuPostGRades.Text = "&Grades"
        '
        'mnuPostGrade
        '
        Me.mnuPostGrade.Name = "mnuPostGrade"
        Me.mnuPostGrade.Size = New System.Drawing.Size(136, 22)
        Me.mnuPostGrade.Text = "&Post Grades"
        '
        'mnuView
        '
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuViewGrades})
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(44, 20)
        Me.mnuView.Text = "&View"
        '
        'mnuViewGrades
        '
        Me.mnuViewGrades.Name = "mnuViewGrades"
        Me.mnuViewGrades.Size = New System.Drawing.Size(130, 22)
        Me.mnuViewGrades.Text = "My &Grades"
        '
        'frmMDIParent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.Controls.Add(Me.mnuMain)
        Me.IsMdiContainer = True
        Me.Name = "frmMDIParent"
        Me.Text = "Student Grade Management System - Dashboard"
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mnuMain As MenuStrip
    Friend WithEvents mnuFile As ToolStripMenuItem
    Friend WithEvents mnuStudents As ToolStripMenuItem
    Friend WithEvents mnuPostGRades As ToolStripMenuItem
    Friend WithEvents mnuView As ToolStripMenuItem
    Friend WithEvents mnuLogout As ToolStripMenuItem
    Friend WithEvents mnuExit As ToolStripMenuItem
    Friend WithEvents mnuManageStudents As ToolStripMenuItem
    Friend WithEvents mnuPostGrade As ToolStripMenuItem
    Friend WithEvents mnuViewGrades As ToolStripMenuItem
End Class
