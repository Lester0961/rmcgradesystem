<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStudentInput
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
        Me.dgvStudents = New System.Windows.Forms.DataGridView()
        Me.lblStudentID = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.lblSection = New System.Windows.Forms.Label()
        Me.txtSection = New System.Windows.Forms.TextBox()
        Me.lblContact = New System.Windows.Forms.Label()
        Me.txtContact = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.pnlInputs = New System.Windows.Forms.Panel()
        CType(Me.dgvStudents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInputs.SuspendLayout()
        Me.SuspendLayout()

        ' dgvStudents
        Me.dgvStudents.AllowUserToAddRows = False
        Me.dgvStudents.AllowUserToDeleteRows = False
        Me.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStudents.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvStudents.Location = New System.Drawing.Point(0, 0)
        Me.dgvStudents.MultiSelect = False
        Me.dgvStudents.Name = "dgvStudents"
        Me.dgvStudents.ReadOnly = True
        Me.dgvStudents.RowHeadersWidth = 51
        Me.dgvStudents.RowTemplate.Height = 24
        Me.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStudents.Size = New System.Drawing.Size(900, 350)
        Me.dgvStudents.TabIndex = 0

        ' lblStudentID
        Me.lblStudentID.AutoSize = True
        Me.lblStudentID.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.lblStudentID.ForeColor = System.Drawing.Color.Gray
        Me.lblStudentID.Location = New System.Drawing.Point(430, 90)
        Me.lblStudentID.Name = "lblStudentID"
        Me.lblStudentID.Size = New System.Drawing.Size(100, 20)
        Me.lblStudentID.TabIndex = 1
        Me.lblStudentID.Visible = True
        Me.lblStudentID.Text = "ID: (none selected)"

        ' lblFirstName
        Me.lblFirstName.AutoSize = True
        Me.lblFirstName.Location = New System.Drawing.Point(20, 20)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(75, 17)
        Me.lblFirstName.TabIndex = 2
        Me.lblFirstName.Text = "First Name:"

        ' txtFirstName
        Me.txtFirstName.Location = New System.Drawing.Point(110, 17)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(200, 22)
        Me.txtFirstName.TabIndex = 3

        ' lblLastName
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(20, 55)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(78, 17)
        Me.lblLastName.TabIndex = 4
        Me.lblLastName.Text = "Last Name:"

        ' txtLastName
        Me.txtLastName.Location = New System.Drawing.Point(110, 52)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(200, 22)
        Me.txtLastName.TabIndex = 5

        ' lblSection
        Me.lblSection.AutoSize = True
        Me.lblSection.Location = New System.Drawing.Point(20, 90)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Size = New System.Drawing.Size(60, 17)
        Me.lblSection.TabIndex = 6
        Me.lblSection.Text = "Section:"

        ' txtSection
        Me.txtSection.Location = New System.Drawing.Point(110, 87)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Size = New System.Drawing.Size(200, 22)
        Me.txtSection.TabIndex = 7

        ' lblContact
        Me.lblContact.AutoSize = True
        Me.lblContact.Location = New System.Drawing.Point(20, 125)
        Me.lblContact.Name = "lblContact"
        Me.lblContact.Size = New System.Drawing.Size(60, 17)
        Me.lblContact.TabIndex = 8
        Me.lblContact.Text = "Contact:"

        ' txtContact
        Me.txtContact.Location = New System.Drawing.Point(110, 122)
        Me.txtContact.Name = "txtContact"
        Me.txtContact.Size = New System.Drawing.Size(200, 22)
        Me.txtContact.TabIndex = 9

        ' lblUsername
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(340, 20)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(80, 17)
        Me.lblUsername.TabIndex = 10
        Me.lblUsername.Text = "Username:"

        ' txtUsername
        Me.txtUsername.Location = New System.Drawing.Point(430, 17)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(200, 22)
        Me.txtUsername.TabIndex = 11

        ' lblPassword
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(340, 55)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(78, 17)
        Me.lblPassword.TabIndex = 12
        Me.lblPassword.Text = "Password:"

        ' txtPassword
        Me.txtPassword.Location = New System.Drawing.Point(430, 52)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(200, 22)
        Me.txtPassword.TabIndex = 13

        ' btnAdd
        Me.btnAdd.BackColor = System.Drawing.Color.ForestGreen
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(20, 170)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(100, 40)
        Me.btnAdd.TabIndex = 14
        Me.btnAdd.Text = "Add New"
        Me.btnAdd.UseVisualStyleBackColor = False

        ' btnUpdate
        Me.btnUpdate.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnUpdate.ForeColor = System.Drawing.Color.White
        Me.btnUpdate.Location = New System.Drawing.Point(130, 170)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(100, 40)
        Me.btnUpdate.TabIndex = 15
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = False

        ' btnDelete
        Me.btnDelete.BackColor = System.Drawing.Color.IndianRed
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(240, 170)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(100, 40)
        Me.btnDelete.TabIndex = 16
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False

        ' btnRefresh
        Me.btnRefresh.BackColor = System.Drawing.Color.DarkOrange
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(350, 170)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(100, 40)
        Me.btnRefresh.TabIndex = 17
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False

        ' btnClear
        Me.btnClear.BackColor = System.Drawing.Color.Gray
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(460, 170)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(100, 40)
        Me.btnClear.TabIndex = 20
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False

        ' ProgressBar1
        Me.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar1.Location = New System.Drawing.Point(0, 650)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(900, 23)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 18
        Me.ProgressBar1.Visible = False

        ' pnlInputs
        Me.pnlInputs.Controls.Add(Me.btnClear)
        Me.pnlInputs.Controls.Add(Me.btnRefresh)
        Me.pnlInputs.Controls.Add(Me.btnDelete)
        Me.pnlInputs.Controls.Add(Me.btnUpdate)
        Me.pnlInputs.Controls.Add(Me.btnAdd)
        Me.pnlInputs.Controls.Add(Me.txtPassword)
        Me.pnlInputs.Controls.Add(Me.lblPassword)
        Me.pnlInputs.Controls.Add(Me.txtUsername)
        Me.pnlInputs.Controls.Add(Me.lblUsername)
        Me.pnlInputs.Controls.Add(Me.txtContact)
        Me.pnlInputs.Controls.Add(Me.lblContact)
        Me.pnlInputs.Controls.Add(Me.txtSection)
        Me.pnlInputs.Controls.Add(Me.lblSection)
        Me.pnlInputs.Controls.Add(Me.txtLastName)
        Me.pnlInputs.Controls.Add(Me.lblLastName)
        Me.pnlInputs.Controls.Add(Me.txtFirstName)
        Me.pnlInputs.Controls.Add(Me.lblFirstName)
        Me.pnlInputs.Controls.Add(Me.lblStudentID)
        Me.pnlInputs.Location = New System.Drawing.Point(0, 350)
        Me.pnlInputs.Name = "pnlInputs"
        Me.pnlInputs.Size = New System.Drawing.Size(900, 300)
        Me.pnlInputs.TabIndex = 19

        ' frmStudentInput
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 673)
        Me.Controls.Add(Me.pnlInputs)
        Me.Controls.Add(Me.dgvStudents)
        Me.Controls.Add(Me.ProgressBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmStudentInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Students (Admin Only)"
        CType(Me.dgvStudents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInputs.ResumeLayout(False)
        Me.pnlInputs.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvStudents As DataGridView
    Friend WithEvents lblStudentID As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents lblLastName As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents lblSection As Label
    Friend WithEvents txtSection As TextBox
    Friend WithEvents lblContact As Label
    Friend WithEvents txtContact As TextBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents pnlInputs As Panel

End Class