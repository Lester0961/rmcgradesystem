Imports System.Data.SqlClient
Imports System.Data
Imports System.Threading

Public Class Form1

    ' ══════════════════════════════════════════
    '           CONNECTION STRING
    ' ══════════════════════════════════════════
    Private ReadOnly ConnectionString As String =
        "Data Source=DESKTOP-PJ0O59M\SQLEXPRESS;" &
        "Initial Catalog=RMC_GRADES_RECORDS;" &
        "Integrated Security=True;" &
        "TrustServerCertificate=True;"

    Private currentMode As String = ""
    Private isClearingFields As Boolean = False

    ' ══════════════════════════════════════════
    '           FORM LOAD
    ' ══════════════════════════════════════════
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConfigureGrid()
        ConfigureProgressBar()
        LoadStudents()
        LoadSearchOptions()
        LoadActionOptions()     ' loads Add / Edit / Delete into cmbAction
        UpdateStatusLabel()
    End Sub

    ' ══════════════════════════════════════════
    '           GRID CONFIGURATION (RUNS ONCE)
    ' ══════════════════════════════════════════
    Private Sub ConfigureGrid()
        dgvStudents.ReadOnly = True
        dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvStudents.MultiSelect = False
        dgvStudents.AllowUserToAddRows = False
        dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    ' ══════════════════════════════════════════
    '           PROGRESS BAR SETUP (RUNS ONCE)
    ' ══════════════════════════════════════════
    Private Sub ConfigureProgressBar()
        pgbLoading.Minimum = 0
        pgbLoading.Maximum = 100
        pgbLoading.Value = 0
        pgbLoading.Style = ProgressBarStyle.Continuous
        pgbLoading.Visible = False
        lblLoading.Visible = False
        lblLoading.Text = ""
    End Sub

    ' ══════════════════════════════════════════
    '           ACTION COMBOBOX SETUP
    '  Replaces the 3 separate Add/Edit/Delete buttons
    '  Controls: cmbAction (ComboBox), btnGo (Button labeled "Go" or "Apply")
    ' ══════════════════════════════════════════
    Private Sub LoadActionOptions()
        If cmbAction.Items.Count > 0 Then Return
        cmbAction.Items.Add("View")           ' default — index 0
        cmbAction.Items.Add("Add Student")
        cmbAction.Items.Add("Edit Student")
        cmbAction.Items.Add("Delete Student")
        cmbAction.SelectedIndex = 0           ' starts on View
    End Sub

    ' Fires when admin changes the selection in cmbAction
    Private Sub cmbAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAction.SelectedIndexChanged
        Select Case cmbAction.SelectedItem.ToString()

            Case "View"
                currentMode = ""
                ClearFields()

            Case "Add Student"
                currentMode = "ADD"
                ClearFields()
                txtFirstName.Focus()

            Case "Edit Student"
                If dgvStudents.SelectedRows.Count = 0 Then
                    MessageBox.Show("Please select a student from the table first, then choose Edit.",
                                    "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmbAction.SelectedIndex = 0  ' fall back to View
                    Return
                End If
                currentMode = "EDIT"
                FillFieldsFromGrid()

            Case "Delete Student"
                If dgvStudents.SelectedRows.Count = 0 Then
                    MessageBox.Show("Please select a student from the table first, then choose Delete.",
                                    "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmbAction.SelectedIndex = 0  ' fall back to View
                    Return
                End If
                currentMode = "DELETE"

        End Select

        UpdateStatusLabel()
    End Sub

    ' ══════════════════════════════════════════
    '           SAVE BUTTON
    '  Routes to correct handler based on cmbAction selection
    ' ══════════════════════════════════════════
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Select Case currentMode
            Case "ADD"
                HandleAdd()
            Case "EDIT"
                HandleEdit()
            Case "DELETE"
                HandleDelete()
            Case Else
                MessageBox.Show("Please select an action from the dropdown first.", "Notice",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Select
    End Sub

    ' ══════════════════════════════════════════
    '           HANDLE ADD
    ' ══════════════════════════════════════════
    Private Sub HandleAdd()
        ' Validate fields
        If String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
           String.IsNullOrWhiteSpace(txtLastName.Text) OrElse
           String.IsNullOrWhiteSpace(txtSection.Text) OrElse
           String.IsNullOrWhiteSpace(txtContact.Text) Then
            MessageBox.Show("First Name, Last Name, Section, and Contact are all required.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Snapshot values before form disables
        Dim snapFirst As String = txtFirstName.Text.Trim()
        Dim snapLast As String = txtLastName.Text.Trim()
        Dim snapSection As String = txtSection.Text.Trim()
        Dim snapContact As String = txtContact.Text.Trim()

        ' Confirm BEFORE progress bar
        Dim confirm = MessageBox.Show(
            $"Are you sure you want to add '{snapFirst} {snapLast}' as a new student?",
            "Confirm Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm = DialogResult.No Then Return

        ' Progress bar starts AFTER confirmation
        RunWithLoading(
            Sub()
                Using conn As New SqlConnection(ConnectionString)
                    conn.Open()
                    Dim cmd As New SqlCommand(
                        "INSERT INTO dbo.Students (FirstName, LastName, Section, Contact) " &
                        "VALUES (@fn, @ln, @sec, @con)", conn)
                    cmd.Parameters.AddWithValue("@fn", snapFirst)
                    cmd.Parameters.AddWithValue("@ln", snapLast)
                    cmd.Parameters.AddWithValue("@sec", snapSection)
                    cmd.Parameters.AddWithValue("@con", snapContact)
                    cmd.ExecuteNonQuery()
                End Using
            End Sub,
            $"✓ Student '{snapFirst} {snapLast}' added successfully!",
            "Adding student...")
    End Sub

    ' ══════════════════════════════════════════
    '           HANDLE EDIT
    ' ══════════════════════════════════════════
    Private Sub HandleEdit()
        ' Validate fields
        If String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
           String.IsNullOrWhiteSpace(txtLastName.Text) OrElse
           String.IsNullOrWhiteSpace(txtSection.Text) OrElse
           String.IsNullOrWhiteSpace(txtContact.Text) Then
            MessageBox.Show("First Name, Last Name, Section, and Contact are all required.", "Validation",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Snapshot values before form disables
        Dim snapFirst As String = txtFirstName.Text.Trim()
        Dim snapLast As String = txtLastName.Text.Trim()
        Dim snapSection As String = txtSection.Text.Trim()
        Dim snapContact As String = txtContact.Text.Trim()
        Dim snapID As String = txtStudentID.Text.Trim()

        ' Confirm BEFORE progress bar
        Dim confirm = MessageBox.Show(
            $"Are you sure you want to save changes to '{snapFirst} {snapLast}'?",
            "Confirm Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm = DialogResult.No Then Return

        ' Progress bar starts AFTER confirmation
        RunWithLoading(
            Sub()
                Using conn As New SqlConnection(ConnectionString)
                    conn.Open()
                    Dim cmd As New SqlCommand(
                        "UPDATE dbo.Students SET " &
                        "FirstName=@fn, LastName=@ln, Section=@sec, Contact=@con " &
                        "WHERE StudentID=@id", conn)
                    cmd.Parameters.AddWithValue("@fn", snapFirst)
                    cmd.Parameters.AddWithValue("@ln", snapLast)
                    cmd.Parameters.AddWithValue("@sec", snapSection)
                    cmd.Parameters.AddWithValue("@con", snapContact)
                    cmd.Parameters.AddWithValue("@id", Integer.Parse(snapID))
                    cmd.ExecuteNonQuery()
                End Using
            End Sub,
            $"✓ Student '{snapFirst} {snapLast}' updated successfully!",
            "Updating student...")
    End Sub

    ' ══════════════════════════════════════════
    '           HANDLE DELETE
    ' ══════════════════════════════════════════
    Private Sub HandleDelete()
        If dgvStudents.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a student to delete.", "Notice",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim studentID As String = dgvStudents.SelectedRows(0).Cells("StudentID").Value.ToString()
        Dim fullName As String = dgvStudents.SelectedRows(0).Cells("FirstName").Value.ToString() & " " &
                                  dgvStudents.SelectedRows(0).Cells("LastName").Value.ToString()

        ' Confirm BEFORE progress bar
        Dim confirm = MessageBox.Show(
            $"Are you sure you want to delete student '{fullName}' (ID: {studentID})?",
            "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If confirm = DialogResult.No Then Return

        ' Progress bar starts AFTER confirmation
        RunWithLoading(
            Sub()
                Using conn As New SqlConnection(ConnectionString)
                    conn.Open()
                    Dim cmd As New SqlCommand(
                        "DELETE FROM dbo.Students WHERE StudentID = @id", conn)
                    cmd.Parameters.AddWithValue("@id", Integer.Parse(studentID))
                    cmd.ExecuteNonQuery()
                End Using
            End Sub,
            $"✓ Student '{fullName}' deleted successfully!",
            "Deleting student...")
    End Sub

    ' ══════════════════════════════════════════
    '           LOADING SEQUENCE
    '
    '  EXACT FLOW:
    '  1. Select action from cmbAction
    '  2. Fill fields (if Add/Edit)
    '  3. Click Go button
    '  4. Validation (if Add/Edit)
    '  5. Confirm dialog  ← user still in control
    '  6. Click YES
    '  7. Progress bar appears + form disables
    '  8. DB action runs
    '  9. Grid reloads
    ' 10. Bar reaches 100%, shows "Done!"
    ' 11. Form re-enables, fields + combobox reset
    ' 12. Success message appears
    ' ══════════════════════════════════════════
    Private Sub RunWithLoading(action As Action, successMessage As String, loadingMessage As String)

        ' Phase 1: Show bar, disable form
        SetFormEnabled(False)
        pgbLoading.Value = 0
        pgbLoading.Visible = True
        lblLoading.Text = loadingMessage
        lblLoading.Visible = True
        Application.DoEvents()

        Try
            ' Phase 2: Animate 0% → 40%
            AnimateProgressBar(0, 40, 350)

            ' Phase 3: Run DB action
            action.Invoke()

            ' Phase 4: Animate 40% → 75%
            AnimateProgressBar(40, 75, 250)
            lblLoading.Text = "Refreshing data..."
            Application.DoEvents()

            ' Phase 5: Reload grid
            LoadStudents()

            ' Phase 6: Animate 75% → 100%
            AnimateProgressBar(75, 100, 200)
            lblLoading.Text = "Done!"
            Application.DoEvents()
            Thread.Sleep(350)

        Catch ex As Exception
            ShowError("Operation failed", ex)
            Return

        Finally
            ' Always re-enable form and hide bar
            pgbLoading.Visible = False
            lblLoading.Visible = False
            pgbLoading.Value = 0
            SetFormEnabled(True)
            ResetFormState()
        End Try

        ' Phase 7: Success message AFTER bar is gone and form is re-enabled
        MessageBox.Show(successMessage, "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Smoothly steps progress bar between two values
    Private Sub AnimateProgressBar(fromVal As Integer, toVal As Integer, durationMs As Integer)
        Dim steps As Integer = toVal - fromVal
        If steps <= 0 Then Return
        Dim delay As Integer = Math.Max(1, durationMs \ steps)
        For i As Integer = fromVal To toVal
            pgbLoading.Value = i
            Application.DoEvents()
            Thread.Sleep(delay)
        Next
    End Sub

    ' Disable/enable all controls except loading bar and label
    Private Sub SetFormEnabled(enabled As Boolean)
        For Each ctrl As Control In Me.Controls
            If ctrl.Name = "pgbLoading" OrElse ctrl.Name = "lblLoading" Then Continue For
            ctrl.Enabled = enabled
        Next
    End Sub

    ' ══════════════════════════════════════════
    '           LOAD STUDENTS INTO GRID
    ' ══════════════════════════════════════════
    Private Sub LoadStudents()
        Try
            Using conn As New SqlConnection(ConnectionString)
                conn.Open()
                Dim cmd As New SqlCommand("SELECT * FROM dbo.Students", conn)
                Dim adapter As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)
                dgvStudents.DataSource = dt
            End Using
        Catch ex As Exception
            ShowError("Error loading students", ex)
        End Try
    End Sub

    ' ══════════════════════════════════════════
    '           LOAD SEARCH OPTIONS
    ' ══════════════════════════════════════════
    Private Sub LoadSearchOptions()
        If cmbSearchBy.Items.Count > 0 Then Return
        cmbSearchBy.Items.Add("StudentID")
        cmbSearchBy.Items.Add("FirstName")
        cmbSearchBy.Items.Add("LastName")
        cmbSearchBy.Items.Add("Section")
        cmbSearchBy.Items.Add("Contact")
        cmbSearchBy.SelectedIndex = 1
    End Sub

    ' ══════════════════════════════════════════
    '           SEARCH
    ' ══════════════════════════════════════════
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim keyword As String = txtSearch.Text.Trim()

        If String.IsNullOrWhiteSpace(keyword) Then
            LoadStudents()
            Return
        End If

        Dim column As String = cmbSearchBy.SelectedItem.ToString()

        Try
            Using conn As New SqlConnection(ConnectionString)
                conn.Open()
                Dim cmd As New SqlCommand(
                    $"SELECT * FROM dbo.Students WHERE CAST({column} AS NVARCHAR(100)) LIKE @keyword", conn)
                cmd.Parameters.AddWithValue("@keyword", "%" & keyword & "%")

                Dim adapter As New SqlDataAdapter(cmd)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No students found matching your search.", "Search",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadStudents()
                Else
                    dgvStudents.DataSource = dt
                End If
            End Using
        Catch ex As Exception
            ShowError("Search error", ex)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If isClearingFields Then Return
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then LoadStudents()
    End Sub

    ' ══════════════════════════════════════════
    '           CLEAR BUTTON
    ' ══════════════════════════════════════════
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        currentMode = ""
        ClearFields()
        cmbAction.SelectedIndex = 0
        UpdateStatusLabel()
    End Sub

    ' ══════════════════════════════════════════
    '           CLICK ROW → AUTO FILL FIELDS
    ' ══════════════════════════════════════════
    Private Sub dgvStudents_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudents.CellClick
        If e.RowIndex >= 0 Then FillFieldsFromGrid()
    End Sub

    ' ══════════════════════════════════════════
    '           SHARED HELPERS
    ' ══════════════════════════════════════════

    Private Sub FillFieldsFromGrid()
        If dgvStudents.SelectedRows.Count = 0 Then Return
        Try
            Dim row = dgvStudents.SelectedRows(0)
            txtStudentID.Text = row.Cells("StudentID").Value.ToString()
            txtFirstName.Text = row.Cells("FirstName").Value.ToString()
            txtLastName.Text = row.Cells("LastName").Value.ToString()
            txtSection.Text = row.Cells("Section").Value.ToString()
            txtContact.Text = row.Cells("Contact").Value.ToString()
        Catch
            ' silently ignore incomplete row data
        End Try
    End Sub

    Private Sub ResetFormState()
        currentMode = ""
        ClearFields()
        cmbAction.SelectedIndex = 0  ' reset dropdown back to placeholder
        UpdateStatusLabel()
    End Sub

    Private Sub ClearFields()
        isClearingFields = True
        txtStudentID.Text = ""
        txtFirstName.Text = ""
        txtLastName.Text = ""
        txtSection.Text = ""
        txtContact.Text = ""
        txtSearch.Text = ""
        isClearingFields = False
    End Sub

    Private Sub UpdateStatusLabel()
        Select Case currentMode
            Case "ADD"
                lblStatus.Text = "● Mode: Adding New Student"
                lblStatus.ForeColor = Color.Green
            Case "EDIT"
                lblStatus.Text = "● Mode: Editing Student"
                lblStatus.ForeColor = Color.DarkOrange
            Case "DELETE"
                lblStatus.Text = "● Mode: Deleting Student"
                lblStatus.ForeColor = Color.Red
            Case Else
                lblStatus.Text = "● Mode: Viewing"
                lblStatus.ForeColor = Color.Gray
        End Select
    End Sub

    Private Sub ShowError(context As String, ex As Exception)
        MessageBox.Show($"{context}: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

End Class