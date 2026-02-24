Module CurrentUser

    Public CurrentUsername As String = ""
    Public CurrentRole As String = ""
    Public CurrentStudentID As Integer = 0

    Public Sub ClearCurrent()
        CurrentUsername = ""
        CurrentRole = ""
        CurrentStudentID = 0
    End Sub

    Public ReadOnly Property IsAdmin As Boolean
        Get
            Return CurrentRole = "Admin"
        End Get
    End Property

    Public ReadOnly Property IsStudent As Boolean
        Get
            Return CurrentRole = "Student"
        End Get
    End Property

End Module