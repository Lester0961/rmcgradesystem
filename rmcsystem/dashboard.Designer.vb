<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMDIParent
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuManage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuManageStudents = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuGrades = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPostGrades = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuViewGrades = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuManage, Me.mnuGrades})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.mnuMain.Size = New System.Drawing.Size(900, 24)
        Me.mnuMain.TabIndex = 0
        Me.mnuMain.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLogout})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(37, 20)
        Me.mnuFile.Text = "&File"
        '
        'mnuLogout
        '
        Me.mnuLogout.Name = "mnuLogout"
        Me.mnuLogout.Size = New System.Drawing.Size(180, 22)
        Me.mnuLogout.Text = "&Logout"
        '
        'mnuManage
        '
        Me.mnuManage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuManageStudents})
        Me.mnuManage.Name = "mnuManage"
        Me.mnuManage.Size = New System.Drawing.Size(62, 20)
        Me.mnuManage.Text = "&Manage"
        '
        'mnuManageStudents
        '
        Me.mnuManageStudents.Name = "mnuManageStudents"
        Me.mnuManageStudents.Size = New System.Drawing.Size(120, 22)
        Me.mnuManageStudents.Text = "&Students"
        '
        'mnuGrades
        '
        Me.mnuGrades.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPostGrades, Me.mnuViewGrades})
        Me.mnuGrades.Name = "mnuGrades"
        Me.mnuGrades.Size = New System.Drawing.Size(55, 20)
        Me.mnuGrades.Text = "&Grades"
        '
        'mnuPostGrades
        '
        Me.mnuPostGrades.Name = "mnuPostGrades"
        Me.mnuPostGrades.Size = New System.Drawing.Size(138, 22)
        Me.mnuPostGrades.Text = "&Post Grades"
        '
        'mnuViewGrades
        '
        Me.mnuViewGrades.Name = "mnuViewGrades"
        Me.mnuViewGrades.Size = New System.Drawing.Size(138, 22)
        Me.mnuViewGrades.Text = "&View Grades"
        '
        'FrmMDIParent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 650)
        Me.Controls.Add(Me.mnuMain)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnuMain
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "FrmMDIParent"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard"
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mnuMain As MenuStrip
    Friend WithEvents mnuFile As ToolStripMenuItem
    Friend WithEvents mnuLogout As ToolStripMenuItem
    Friend WithEvents mnuManage As ToolStripMenuItem
    Friend WithEvents mnuManageStudents As ToolStripMenuItem
    Friend WithEvents mnuGrades As ToolStripMenuItem
    Friend WithEvents mnuPostGrades As ToolStripMenuItem
    Friend WithEvents mnuViewGrades As ToolStripMenuItem
End Class