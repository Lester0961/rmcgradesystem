<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGradeInput
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

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblStudentToGrade = New System.Windows.Forms.Label()
        Me.cboStudents = New System.Windows.Forms.ComboBox()
        Me.lblSubject = New System.Windows.Forms.Label()
        Me.cboSubjects = New System.Windows.Forms.ComboBox()
        Me.lblScore = New System.Windows.Forms.Label()
        Me.nudScore = New System.Windows.Forms.NumericUpDown()
        Me.lblDatePosted = New System.Windows.Forms.Label()
        Me.dtpDatePosted = New System.Windows.Forms.DateTimePicker()
        Me.pbSaving = New System.Windows.Forms.ProgressBar()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnPostGrade = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.nudScore, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(101, 14)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(230, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Post New Student Grade"
        '
        'lblStudentToGrade
        '
        Me.lblStudentToGrade.AutoSize = True
        Me.lblStudentToGrade.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStudentToGrade.Location = New System.Drawing.Point(25, 51)
        Me.lblStudentToGrade.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStudentToGrade.Name = "lblStudentToGrade"
        Me.lblStudentToGrade.Size = New System.Drawing.Size(184, 19)
        Me.lblStudentToGrade.TabIndex = 1
        Me.lblStudentToGrade.Text = "Select Student to be Graded:"
        '
        'cboStudents
        '
        Me.cboStudents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStudents.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboStudents.FormattingEnabled = True
        Me.cboStudents.Location = New System.Drawing.Point(29, 81)
        Me.cboStudents.Margin = New System.Windows.Forms.Padding(2)
        Me.cboStudents.Name = "cboStudents"
        Me.cboStudents.Size = New System.Drawing.Size(366, 25)
        Me.cboStudents.TabIndex = 2
        '
        'lblSubject
        '
        Me.lblSubject.AutoSize = True
        Me.lblSubject.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblSubject.Location = New System.Drawing.Point(25, 123)
        Me.lblSubject.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(56, 19)
        Me.lblSubject.TabIndex = 3
        Me.lblSubject.Text = "Subject:"
        '
        'cboSubjects
        '
        Me.cboSubjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSubjects.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSubjects.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboSubjects.FormattingEnabled = True
        Me.cboSubjects.Location = New System.Drawing.Point(140, 121)
        Me.cboSubjects.Margin = New System.Windows.Forms.Padding(2)
        Me.cboSubjects.Name = "cboSubjects"
        Me.cboSubjects.Size = New System.Drawing.Size(255, 25)
        Me.cboSubjects.TabIndex = 4
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblScore.Location = New System.Drawing.Point(25, 156)
        Me.lblScore.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(95, 19)
        Me.lblScore.TabIndex = 5
        Me.lblScore.Text = "Score (0-100):"
        '
        'nudScore
        '
        Me.nudScore.DecimalPlaces = 2
        Me.nudScore.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.nudScore.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.nudScore.Location = New System.Drawing.Point(140, 154)
        Me.nudScore.Margin = New System.Windows.Forms.Padding(2)
        Me.nudScore.Name = "nudScore"
        Me.nudScore.Size = New System.Drawing.Size(93, 25)
        Me.nudScore.TabIndex = 6
        Me.nudScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudScore.ThousandsSeparator = True
        '
        'lblDatePosted
        '
        Me.lblDatePosted.AutoSize = True
        Me.lblDatePosted.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblDatePosted.Location = New System.Drawing.Point(25, 188)
        Me.lblDatePosted.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDatePosted.Name = "lblDatePosted"
        Me.lblDatePosted.Size = New System.Drawing.Size(86, 19)
        Me.lblDatePosted.TabIndex = 7
        Me.lblDatePosted.Text = "Date Posted:"
        '
        'dtpDatePosted
        '
        Me.dtpDatePosted.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.dtpDatePosted.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDatePosted.Location = New System.Drawing.Point(140, 186)
        Me.dtpDatePosted.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpDatePosted.Name = "dtpDatePosted"
        Me.dtpDatePosted.Size = New System.Drawing.Size(121, 25)
        Me.dtpDatePosted.TabIndex = 8
        '
        'pbSaving
        '
        Me.pbSaving.Location = New System.Drawing.Point(25, 222)
        Me.pbSaving.Margin = New System.Windows.Forms.Padding(2)
        Me.pbSaving.MarqueeAnimationSpeed = 60
        Me.pbSaving.Name = "pbSaving"
        Me.pbSaving.Size = New System.Drawing.Size(368, 15)
        Me.pbSaving.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbSaving.TabIndex = 9
        Me.pbSaving.Visible = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblStatus.Location = New System.Drawing.Point(25, 205)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 19)
        Me.lblStatus.TabIndex = 10
        '
        'btnPostGrade
        '
        Me.btnPostGrade.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnPostGrade.FlatAppearance.BorderSize = 0
        Me.btnPostGrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPostGrade.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnPostGrade.ForeColor = System.Drawing.Color.White
        Me.btnPostGrade.Location = New System.Drawing.Point(140, 274)
        Me.btnPostGrade.Margin = New System.Windows.Forms.Padding(2)
        Me.btnPostGrade.Name = "btnPostGrade"
        Me.btnPostGrade.Size = New System.Drawing.Size(93, 29)
        Me.btnPostGrade.TabIndex = 11
        Me.btnPostGrade.Text = "Post Grade"
        Me.btnPostGrade.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnClear.Location = New System.Drawing.Point(247, 274)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(80, 29)
        Me.btnClear.TabIndex = 12
        Me.btnClear.Text = "Clear Form"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.btnClose.Location = New System.Drawing.Point(340, 274)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(67, 29)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmGradeInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(424, 323)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnPostGrade)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pbSaving)
        Me.Controls.Add(Me.dtpDatePosted)
        Me.Controls.Add(Me.lblDatePosted)
        Me.Controls.Add(Me.nudScore)
        Me.Controls.Add(Me.lblScore)
        Me.Controls.Add(Me.cboSubjects)
        Me.Controls.Add(Me.lblSubject)
        Me.Controls.Add(Me.cboStudents)
        Me.Controls.Add(Me.lblStudentToGrade)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "frmGradeInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Post / Enter Student Grade"
        CType(Me.nudScore, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblStudentToGrade As Label
    Friend WithEvents cboStudents As ComboBox
    Friend WithEvents lblSubject As Label
    Friend WithEvents cboSubjects As ComboBox
    Friend WithEvents lblScore As Label
    Friend WithEvents nudScore As NumericUpDown
    Friend WithEvents lblDatePosted As Label
    Friend WithEvents dtpDatePosted As DateTimePicker
    Friend WithEvents pbSaving As ProgressBar
    Friend WithEvents lblStatus As Label
    Friend WithEvents btnPostGrade As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents Timer1 As Timer
End Class