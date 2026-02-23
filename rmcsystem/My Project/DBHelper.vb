Imports System.Data.SqlClient
Imports System.Windows.Forms

Module DBHelper

    Public ReadOnly Property ConnectionString As String
        Get
            Return "Data Source=LESTER\SQLEXPRESS;Initial Catalog=rmcdb;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name="
        End Get
    End Property

    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(ConnectionString)
    End Function

    Public Function GetOpenConnection() As SqlConnection
        Dim conn As New SqlConnection(ConnectionString)
        Try
            conn.Open()
            Return conn
        Catch ex As Exception
            MessageBox.Show("Database connection failed!" & vbCrLf & vbCrLf & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Public Function GetDataTable(query As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As DataTable
        Dim dt As New DataTable()

        Using conn As SqlConnection = GetOpenConnection()
            If conn Is Nothing Then Return dt

            Using cmd As New SqlCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each param In parameters
                        cmd.Parameters.AddWithValue(param.Key, param.Value)
                    Next
                End If

                Try
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading data:" & vbCrLf & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        Return dt
    End Function

    Public Function ExecuteNonQuery(query As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As Integer
        Dim rowsAffected As Integer = 0

        Using conn As SqlConnection = GetOpenConnection()
            If conn Is Nothing Then Return -1

            Using cmd As New SqlCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each param In parameters
                        cmd.Parameters.AddWithValue(param.Key, param.Value)
                    Next
                End If

                Try
                    rowsAffected = cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MessageBox.Show("Error executing command:" & vbCrLf & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        Return rowsAffected
    End Function

    Public Function ExecuteScalar(query As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As Object
        Dim result As Object = Nothing

        Using conn As SqlConnection = GetOpenConnection()
            If conn Is Nothing Then Return -1

            Using cmd As New SqlCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each param In parameters
                        cmd.Parameters.AddWithValue(param.Key, param.Value)
                    Next
                End If

                Try
                    result = cmd.ExecuteScalar()
                Catch ex As Exception
                    MessageBox.Show("Scalar query failed:" & vbCrLf & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        Return result
    End Function

    Public Function UsernameExists(username As String) As Boolean
        Dim query As String = "SELECT COUNT(*) FROM Users WHERE Username = @user"
        Dim param As New Dictionary(Of String, Object) From {{"@user", username}}
        Dim count As Integer = Convert.ToInt32(ExecuteScalar(query, param))
        Return count > 0
    End Function

End Module