<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmGradeInput
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblStudent = New System.Windows.Forms.Label()
        Me.cboStudent = New System.Windows.Forms.ComboBox()
        Me.lblSubject = New System.Windows.Forms.Label()
        Me.cboSubject = New System.Windows.Forms.ComboBox()
        Me.lblTerm = New System.Windows.Forms.Label()
        Me.cboTerm = New System.Windows.Forms.ComboBox()
        Me.grpComponents = New System.Windows.Forms.GroupBox()
        Me.lblQuizzes = New System.Windows.Forms.Label()
        Me.nudQuizzes = New System.Windows.Forms.NumericUpDown()
        Me.lblAssignments = New System.Windows.Forms.Label()
        Me.nudAssignments = New System.Windows.Forms.NumericUpDown()
        Me.lblAttendance = New System.Windows.Forms.Label()
        Me.nudAttendance = New System.Windows.Forms.NumericUpDown()
        Me.lblProjects = New System.Windows.Forms.Label()
        Me.nudProjects = New System.Windows.Forms.NumericUpDown()
        Me.lblExam = New System.Windows.Forms.Label()
        Me.nudExam = New System.Windows.Forms.NumericUpDown()
        Me.btnCalculateTerm = New System.Windows.Forms.Button()
        Me.lblTermPercentage = New System.Windows.Forms.Label()
        Me.btnPostGrade = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.grpComponents.SuspendLayout()
        CType(Me.nudQuizzes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAssignments, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudProjects, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudExam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        ' lblStudent
        Me.lblStudent.AutoSize = True
        Me.lblStudent.Location = New System.Drawing.Point(20, 20)
        Me.lblStudent.Name = "lblStudent"
        Me.lblStudent.Text = "Student:"

        ' cboStudent
        Me.cboStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStudent.FormattingEnabled = True
        Me.cboStudent.Location = New System.Drawing.Point(120, 17)
        Me.cboStudent.Name = "cboStudent"
        Me.cboStudent.Size = New System.Drawing.Size(380, 21)
        Me.cboStudent.TabIndex = 1

        ' lblSubject
        Me.lblSubject.AutoSize = True
        Me.lblSubject.Location = New System.Drawing.Point(20, 55)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Text = "Subject:"

        ' cboSubject
        Me.cboSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubject.FormattingEnabled = True
        Me.cboSubject.Location = New System.Drawing.Point(120, 52)
        Me.cboSubject.Name = "cboSubject"
        Me.cboSubject.Size = New System.Drawing.Size(380, 21)
        Me.cboSubject.TabIndex = 2

        ' lblTerm
        Me.lblTerm.AutoSize = True
        Me.lblTerm.Location = New System.Drawing.Point(20, 90)
        Me.lblTerm.Name = "lblTerm"
        Me.lblTerm.Text = "Term:"

        ' cboTerm
        Me.cboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTerm.FormattingEnabled = True
        Me.cboTerm.Location = New System.Drawing.Point(120, 87)
        Me.cboTerm.Name = "cboTerm"
        Me.cboTerm.Size = New System.Drawing.Size(150, 21)
        Me.cboTerm.TabIndex = 3
        Me.cboTerm.Items.AddRange(New Object() {"Prelim", "Midterm", "Final"})

        ' grpComponents
        Me.grpComponents.Location = New System.Drawing.Point(20, 125)
        Me.grpComponents.Name = "grpComponents"
        Me.grpComponents.Size = New System.Drawing.Size(480, 180)
        Me.grpComponents.TabIndex = 4
        Me.grpComponents.Text = "Grade Components (0-100)"
        Me.grpComponents.Controls.Add(Me.lblQuizzes)
        Me.grpComponents.Controls.Add(Me.nudQuizzes)
        Me.grpComponents.Controls.Add(Me.lblAssignments)
        Me.grpComponents.Controls.Add(Me.nudAssignments)
        Me.grpComponents.Controls.Add(Me.lblAttendance)
        Me.grpComponents.Controls.Add(Me.nudAttendance)
        Me.grpComponents.Controls.Add(Me.lblProjects)
        Me.grpComponents.Controls.Add(Me.nudProjects)
        Me.grpComponents.Controls.Add(Me.lblExam)
        Me.grpComponents.Controls.Add(Me.nudExam)

        ' lblQuizzes
        Me.lblQuizzes.AutoSize = True
        Me.lblQuizzes.Location = New System.Drawing.Point(15, 25)
        Me.lblQuizzes.Name = "lblQuizzes"
        Me.lblQuizzes.Text = "Quizzes (30%):"

        ' nudQuizzes
        Me.nudQuizzes.DecimalPlaces = 2
        Me.nudQuizzes.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nudQuizzes.Location = New System.Drawing.Point(160, 23)
        Me.nudQuizzes.Name = "nudQuizzes"
        Me.nudQuizzes.Size = New System.Drawing.Size(80, 20)
        Me.nudQuizzes.TabIndex = 0

        ' lblAssignments
        Me.lblAssignments.AutoSize = True
        Me.lblAssignments.Location = New System.Drawing.Point(15, 55)
        Me.lblAssignments.Name = "lblAssignments"
        Me.lblAssignments.Text = "Assignments (10%):"

        ' nudAssignments
        Me.nudAssignments.DecimalPlaces = 2
        Me.nudAssignments.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nudAssignments.Location = New System.Drawing.Point(160, 53)
        Me.nudAssignments.Name = "nudAssignments"
        Me.nudAssignments.Size = New System.Drawing.Size(80, 20)
        Me.nudAssignments.TabIndex = 1

        ' lblAttendance
        Me.lblAttendance.AutoSize = True
        Me.lblAttendance.Location = New System.Drawing.Point(15, 85)
        Me.lblAttendance.Name = "lblAttendance"
        Me.lblAttendance.Text = "Attendance (10%):"

        ' nudAttendance
        Me.nudAttendance.DecimalPlaces = 2
        Me.nudAttendance.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nudAttendance.Location = New System.Drawing.Point(160, 83)
        Me.nudAttendance.Name = "nudAttendance"
        Me.nudAttendance.Size = New System.Drawing.Size(80, 20)
        Me.nudAttendance.TabIndex = 2

        ' lblProjects
        Me.lblProjects.AutoSize = True
        Me.lblProjects.Location = New System.Drawing.Point(15, 115)
        Me.lblProjects.Name = "lblProjects"
        Me.lblProjects.Text = "Projects (20%):"

        ' nudProjects
        Me.nudProjects.DecimalPlaces = 2
        Me.nudProjects.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nudProjects.Location = New System.Drawing.Point(160, 113)
        Me.nudProjects.Name = "nudProjects"
        Me.nudProjects.Size = New System.Drawing.Size(80, 20)
        Me.nudProjects.TabIndex = 3

        ' lblExam
        Me.lblExam.AutoSize = True
        Me.lblExam.Location = New System.Drawing.Point(15, 145)
        Me.lblExam.Name = "lblExam"
        Me.lblExam.Text = "Exam (30%):"

        ' nudExam
        Me.nudExam.DecimalPlaces = 2
        Me.nudExam.Maximum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.nudExam.Location = New System.Drawing.Point(160, 143)
        Me.nudExam.Name = "nudExam"
        Me.nudExam.Size = New System.Drawing.Size(80, 20)
        Me.nudExam.TabIndex = 4

        ' btnCalculateTerm
        Me.btnCalculateTerm.Location = New System.Drawing.Point(20, 320)
        Me.btnCalculateTerm.Name = "btnCalculateTerm"
        Me.btnCalculateTerm.Size = New System.Drawing.Size(130, 30)
        Me.btnCalculateTerm.TabIndex = 5
        Me.btnCalculateTerm.Text = "Calculate Term"

        ' lblTermPercentage
        Me.lblTermPercentage.AutoSize = True
        Me.lblTermPercentage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold)
        Me.lblTermPercentage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTermPercentage.Location = New System.Drawing.Point(165, 326)
        Me.lblTermPercentage.Name = "lblTermPercentage"
        Me.lblTermPercentage.Text = ""

        ' btnPostGrade
        Me.btnPostGrade.Enabled = False
        Me.btnPostGrade.Location = New System.Drawing.Point(20, 365)
        Me.btnPostGrade.Name = "btnPostGrade"
        Me.btnPostGrade.Size = New System.Drawing.Size(130, 30)
        Me.btnPostGrade.TabIndex = 6
        Me.btnPostGrade.Text = "Post Grade"

        ' btnClear
        Me.btnClear.Location = New System.Drawing.Point(165, 365)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(80, 30)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "Clear"

        ' ProgressBar1
        Me.ProgressBar1.Location = New System.Drawing.Point(20, 410)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(480, 20)
        Me.ProgressBar1.TabIndex = 8
        Me.ProgressBar1.Visible = False

        ' FrmGradeInput
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 450)
        Me.Controls.Add(Me.lblStudent)
        Me.Controls.Add(Me.cboStudent)
        Me.Controls.Add(Me.lblSubject)
        Me.Controls.Add(Me.cboSubject)
        Me.Controls.Add(Me.lblTerm)
        Me.Controls.Add(Me.cboTerm)
        Me.Controls.Add(Me.grpComponents)
        Me.Controls.Add(Me.btnCalculateTerm)
        Me.Controls.Add(Me.lblTermPercentage)
        Me.Controls.Add(Me.btnPostGrade)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.ProgressBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmGradeInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Post Grades - Admin Only"
        Me.grpComponents.ResumeLayout(False)
        Me.grpComponents.PerformLayout()
        CType(Me.nudQuizzes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAssignments, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAttendance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudProjects, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudExam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents lblStudent As Label
    Friend WithEvents cboStudent As ComboBox
    Friend WithEvents lblSubject As Label
    Friend WithEvents cboSubject As ComboBox
    Friend WithEvents lblTerm As Label
    Friend WithEvents cboTerm As ComboBox
    Friend WithEvents grpComponents As GroupBox
    Friend WithEvents lblQuizzes As Label
    Friend WithEvents nudQuizzes As NumericUpDown
    Friend WithEvents lblAssignments As Label
    Friend WithEvents nudAssignments As NumericUpDown
    Friend WithEvents lblAttendance As Label
    Friend WithEvents nudAttendance As NumericUpDown
    Friend WithEvents lblProjects As Label
    Friend WithEvents nudProjects As NumericUpDown
    Friend WithEvents lblExam As Label
    Friend WithEvents nudExam As NumericUpDown
    Friend WithEvents btnCalculateTerm As Button
    Friend WithEvents lblTermPercentage As Label
    Friend WithEvents btnPostGrade As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents btnClear As Button

End Class