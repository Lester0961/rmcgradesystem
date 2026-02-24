Imports System.Data.SqlClient

Module DBHelper
    Public Const ConnStr As String = "Data Source=.\SQLEXPRESS;Initial Catalog=StudentGradesDB;Integrated Security=True;TrustServerCertificate=True;"

    Public Function GetConnection() As SqlConnection
        Return New SqlConnection(ConnStr)
    End Function
    Public Function GetDataTable(query As String, Optional params As SqlParameter() = Nothing) As DataTable
        Dim dt As New DataTable()

        Try
            Using conn As SqlConnection = GetConnection()
                Using cmd As New SqlCommand(query, conn)
                    If params IsNot Nothing Then
                        cmd.Parameters.AddRange(params)
                    End If

                    Using da As New SqlDataAdapter(cmd)
                        conn.Open()
                        da.Fill(dt)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error (GetDataTable): " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dt
    End Function

    Public Sub ExecuteNonQuery(query As String, Optional params As SqlParameter() = Nothing)
        Try
            Using conn As SqlConnection = GetConnection()
                conn.Open()
                Using cmd As New SqlCommand(query, conn)
                    If params IsNot Nothing Then
                        cmd.Parameters.AddRange(params)
                    End If
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error (ExecuteNonQuery): " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function GetLastIdentity() As Integer
        Dim dt As DataTable = GetDataTable("SELECT SCOPE_IDENTITY() AS LastID")
        If dt.Rows.Count > 0 AndAlso Not IsDBNull(dt.Rows(0)("LastID")) Then
            Return Convert.ToInt32(dt.Rows(0)("LastID"))
        End If
        Return 0
    End Function
    Public Function ExecuteInsertGetID(query As String, Optional params As SqlParameter() = Nothing) As Integer
        Try
            Using conn As SqlConnection = GetConnection()
                conn.Open()
                Using cmd As New SqlCommand(query & "; SELECT SCOPE_IDENTITY();", conn)
                    If params IsNot Nothing Then
                        cmd.Parameters.AddRange(params)
                    End If
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        Return Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error (ExecuteInsertGetID): " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return 0
    End Function

End Module