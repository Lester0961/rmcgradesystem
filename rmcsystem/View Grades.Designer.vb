<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmViewGrades
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
        Me.dgvGrades = New System.Windows.Forms.DataGridView()
        Me.pnlSummary = New System.Windows.Forms.Panel()
        Me.lblGWA = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnCalculateGWA = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.pnlSummary.SuspendLayout()
        CType(Me.dgvGrades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvGrades
        '
        Me.dgvGrades.AllowUserToAddRows = False
        Me.dgvGrades.AllowUserToDeleteRows = False
        Me.dgvGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGrades.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvGrades.Location = New System.Drawing.Point(0, 0)
        Me.dgvGrades.MultiSelect = False
        Me.dgvGrades.Name = "dgvGrades"
        Me.dgvGrades.ReadOnly = True
        Me.dgvGrades.RowHeadersWidth = 51
        Me.dgvGrades.RowTemplate.Height = 24
        Me.dgvGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGrades.Size = New System.Drawing.Size(1000, 450)
        Me.dgvGrades.TabIndex = 0
        '
        'pnlSummary
        '
        Me.pnlSummary.Controls.Add(Me.btnCalculateGWA)
        Me.pnlSummary.Controls.Add(Me.btnRefresh)
        Me.pnlSummary.Controls.Add(Me.lblGWA)
        Me.pnlSummary.Controls.Add(Me.ProgressBar1)
        Me.pnlSummary.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlSummary.Location = New System.Drawing.Point(0, 450)
        Me.pnlSummary.Name = "pnlSummary"
        Me.pnlSummary.Size = New System.Drawing.Size(1000, 220)
        Me.pnlSummary.TabIndex = 1
        '
        'lblGWA
        '
        Me.lblGWA.AutoSize = True
        Me.lblGWA.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblGWA.ForeColor = System.Drawing.Color.Navy
        Me.lblGWA.Location = New System.Drawing.Point(30, 30)
        Me.lblGWA.Name = "lblGWA"
        Me.lblGWA.Size = New System.Drawing.Size(120, 41)
        Me.lblGWA.TabIndex = 0
        Me.lblGWA.Text = "GWA: --"
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.DarkOrange
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(30, 90)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(150, 45)
        Me.btnRefresh.TabIndex = 1
        Me.btnRefresh.Text = "Refresh List"
        Me.btnRefresh.UseVisualStyleBackColor = False
        '
        'btnCalculateGWA
        '
        Me.btnCalculateGWA.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnCalculateGWA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalculateGWA.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnCalculateGWA.ForeColor = System.Drawing.Color.White
        Me.btnCalculateGWA.Location = New System.Drawing.Point(200, 90)
        Me.btnCalculateGWA.Name = "btnCalculateGWA"
        Me.btnCalculateGWA.Size = New System.Drawing.Size(180, 45)
        Me.btnCalculateGWA.TabIndex = 2
        Me.btnCalculateGWA.Text = "Calculate GWA"
        Me.btnCalculateGWA.UseVisualStyleBackColor = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(30, 150)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(900, 35)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 3
        Me.ProgressBar1.Visible = False
        '
        'frmViewGrades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 670)
        Me.Controls.Add(Me.dgvGrades)
        Me.Controls.Add(Me.pnlSummary)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmViewGrades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Grades & GWA"
        CType(Me.dgvGrades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSummary.ResumeLayout(False)
        Me.pnlSummary.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvGrades As DataGridView
    Friend WithEvents pnlSummary As Panel
    Friend WithEvents lblGWA As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnCalculateGWA As Button
    Friend WithEvents ProgressBar1 As ProgressBar
End Class