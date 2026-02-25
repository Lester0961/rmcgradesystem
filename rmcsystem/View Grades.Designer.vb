<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmViewGrades
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
        Me.dgvGrades = New System.Windows.Forms.DataGridView()
        Me.lblGradesTitle = New System.Windows.Forms.Label()
        Me.dgvSummary = New System.Windows.Forms.DataGridView()
        Me.lblSummaryTitle = New System.Windows.Forms.Label()
        Me.pnlGWA = New System.Windows.Forms.Panel()
        Me.lblGWADesc = New System.Windows.Forms.Label()
        Me.lblGWA = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblGradingScale = New System.Windows.Forms.Label()
        CType(Me.dgvGrades, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGWA.SuspendLayout()
        Me.SuspendLayout()

        ' lblGradesTitle
        Me.lblGradesTitle.AutoSize = True
        Me.lblGradesTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblGradesTitle.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblGradesTitle.Location = New System.Drawing.Point(10, 10)
        Me.lblGradesTitle.Name = "lblGradesTitle"
        Me.lblGradesTitle.Text = "📋 Grade Records"

        ' dgvGrades
        Me.dgvGrades.AllowUserToAddRows = False
        Me.dgvGrades.AllowUserToDeleteRows = False
        Me.dgvGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGrades.Location = New System.Drawing.Point(10, 35)
        Me.dgvGrades.MultiSelect = False
        Me.dgvGrades.Name = "dgvGrades"
        Me.dgvGrades.ReadOnly = True
        Me.dgvGrades.RowHeadersWidth = 51
        Me.dgvGrades.RowTemplate.Height = 24
        Me.dgvGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGrades.Size = New System.Drawing.Size(1160, 220)
        Me.dgvGrades.TabIndex = 0

        ' lblSummaryTitle
        Me.lblSummaryTitle.AutoSize = True
        Me.lblSummaryTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblSummaryTitle.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.lblSummaryTitle.Location = New System.Drawing.Point(10, 270)
        Me.lblSummaryTitle.Name = "lblSummaryTitle"
        Me.lblSummaryTitle.Text = "📊 Subject Grade Summary"

        ' dgvSummary
        Me.dgvSummary.AllowUserToAddRows = False
        Me.dgvSummary.AllowUserToDeleteRows = False
        Me.dgvSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSummary.Location = New System.Drawing.Point(10, 295)
        Me.dgvSummary.MultiSelect = False
        Me.dgvSummary.Name = "dgvSummary"
        Me.dgvSummary.ReadOnly = True
        Me.dgvSummary.RowHeadersWidth = 51
        Me.dgvSummary.RowTemplate.Height = 28
        Me.dgvSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSummary.Size = New System.Drawing.Size(870, 200)
        Me.dgvSummary.TabIndex = 1

        ' pnlGWA
        Me.pnlGWA.BackColor = System.Drawing.Color.FromArgb(240, 248, 255)
        Me.pnlGWA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlGWA.Controls.Add(Me.lblGWA)
        Me.pnlGWA.Controls.Add(Me.lblGWADesc)
        Me.pnlGWA.Controls.Add(Me.btnRefresh)
        Me.pnlGWA.Location = New System.Drawing.Point(895, 295)
        Me.pnlGWA.Name = "pnlGWA"
        Me.pnlGWA.Size = New System.Drawing.Size(275, 200)
        Me.pnlGWA.TabIndex = 2

        ' lblGWA
        Me.lblGWA.AutoSize = False
        Me.lblGWA.Font = New System.Drawing.Font("Segoe UI", 26.0!, System.Drawing.FontStyle.Bold)
        Me.lblGWA.ForeColor = System.Drawing.Color.Navy
        Me.lblGWA.Location = New System.Drawing.Point(10, 20)
        Me.lblGWA.Name = "lblGWA"
        Me.lblGWA.Size = New System.Drawing.Size(255, 60)
        Me.lblGWA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblGWA.Text = "--"

        ' lblGWADesc
        Me.lblGWADesc.AutoSize = False
        Me.lblGWADesc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.lblGWADesc.ForeColor = System.Drawing.Color.Gray
        Me.lblGWADesc.Location = New System.Drawing.Point(10, 80)
        Me.lblGWADesc.Name = "lblGWADesc"
        Me.lblGWADesc.Size = New System.Drawing.Size(255, 25)
        Me.lblGWADesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblGWADesc.Text = "General Weighted Average"

        ' btnRefresh
        Me.btnRefresh.BackColor = System.Drawing.Color.DarkOrange
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(37, 130)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(200, 45)
        Me.btnRefresh.TabIndex = 0
        Me.btnRefresh.Text = "🔄 Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False

        ' lblGradingScale  ── Student view only, shown below the summary table ──
        Me.lblGradingScale.AutoSize = False
        Me.lblGradingScale.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular)
        Me.lblGradingScale.ForeColor = System.Drawing.Color.DimGray
        Me.lblGradingScale.Location = New System.Drawing.Point(10, 505)
        Me.lblGradingScale.Name = "lblGradingScale"
        Me.lblGradingScale.Size = New System.Drawing.Size(870, 95)
        Me.lblGradingScale.Text =
            "📘 Grading Scale:" & vbCrLf &
            "98–100% = 1.00   |   95–97% = 1.25   |   93–94% = 1.50   |   90–92% = 1.75   |   87–89% = 2.00" & vbCrLf &
            "84–86% = 2.25   |   81–83% = 2.50   |   79–80% = 2.75   |   75–78% = 3.00   |   Below 75% = 5.00 (Failed)" & vbCrLf &
            "Weighted Formula: (Prelim × 30%) + (Midterm × 30%) + (Final × 40%)" & vbCrLf &
            "GWA = Σ(Numerical Grade × Units) ÷ Σ(Units)  —  Complete subjects only  —  1.00 is highest"
        Me.lblGradingScale.TabIndex = 4

        ' ProgressBar1
        Me.ProgressBar1.Location = New System.Drawing.Point(10, 610)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(1160, 20)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 3
        Me.ProgressBar1.Visible = False

        ' FrmViewGrades
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 645)
        Me.Controls.Add(Me.lblGradesTitle)
        Me.Controls.Add(Me.dgvGrades)
        Me.Controls.Add(Me.lblSummaryTitle)
        Me.Controls.Add(Me.dgvSummary)
        Me.Controls.Add(Me.pnlGWA)
        Me.Controls.Add(Me.lblGradingScale)
        Me.Controls.Add(Me.ProgressBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FrmViewGrades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Grades & GWA"
        CType(Me.dgvGrades, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGWA.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents dgvGrades As DataGridView
    Friend WithEvents lblGradesTitle As Label
    Friend WithEvents dgvSummary As DataGridView
    Friend WithEvents lblSummaryTitle As Label
    Friend WithEvents pnlGWA As Panel
    Friend WithEvents lblGWA As Label
    Friend WithEvents lblGWADesc As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents lblGradingScale As Label

End Class