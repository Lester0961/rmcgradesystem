Module CurrentUser

    Public CurrentUserID As Integer = 0
    Public CurrentUsername As String = ""
    Public CurrentRole As String = ""
    Public CurrentStudentID As Integer = 0

    Public Sub ClearCurrentUser()
        CurrentUserID = 0
        CurrentUsername = ""
        CurrentRole = ""
        CurrentStudentID = 0
    End Sub

    Public Function IsAdmin() As Boolean
        Return CurrentRole = "Admin"
    End Function

    Public Function IsStudent() As Boolean
        Return CurrentRole = "Student"
    End Function

End Module