
# RMC Grade Management System

A complete **Student Grade Management System** built as a final-year university project using **VB.NET Windows Forms** (.NET Framework 4.8) and **Microsoft SQL Server Express 2022**.  

This is the **starting point repository** for our group. It includes full login/logout, role-based access (Admin & Student), MDI dashboard, student CRUD with auto user account creation, grade posting, and read-only grade viewing with average calculation.

## Professor Requirements Implemented
- Separate **Login/Logout** functionality
- **ProgressBar** used twice (data loading & average calculation)
- **MDI Parent** form as main dashboard
- **DataGridView** for student list and grades view
- Dedicated input forms for adding/editing students and posting grades
- Two roles: **Admin** (full access) | **Student** (view own grades only)
- ADO.NET for database access (no Entity Framework)
- Reusable **DBHelper** module for queries

**Note**: Passwords are stored in plain text for academic simplicity (real apps should use hashing like BCrypt).

## Tech Stack
- **Language**: Visual Basic .NET
- **Framework**: .NET Framework 4.8
- **UI**: Windows Forms (MDI, DataGridView, ProgressBar, etc.)
- **Database**: Microsoft SQL Server Express 2022
- **Data Access**: ADO.NET (SqlConnection, SqlCommand, SqlDataAdapter, DataTable)

## Prerequisites
Before running:
1. **Visual Studio 2026** (Community edition is fine) with VB.NET Windows Forms workload installed.
2. **SQL Server Express 2022** installed and running (default instance: `.\SQLEXPRESS`).
   - Download: https://www.microsoft.com/en-us/sql-server/sql-server-downloads
3. **SQL Server Management Studio (SSMS)** to run the database script (optional but recommended).

## Setup Instructions (Step-by-Step for Team Members)

1. **Clone the Repository**
   ```bash
   git clone https://github.com/Lester0961/rmcgradesystem.git
   cd rmcgradesystem
   ```

2. **Open the Project**
   - Double-click `RMCGradeSystem.sln` (or open via Visual Studio → File → Open → Project/Solution).

3. **Create and Populate the Database**
   - Open **SSMS** → Connect to `.\SQLEXPRESS` (Windows Authentication).
   - Create a new query window and run the following script **in order** (copy from DBSetup.sql if we add it, or from below):

     ```sql
     CREATE DATABASE StudentGradesDB;
     GO
     USE StudentGradesDB;
     GO

     CREATE TABLE Students (
         StudentID INT IDENTITY(1,1) PRIMARY KEY,
         FirstName VARCHAR(50) NOT NULL,
         LastName VARCHAR(50) NOT NULL,
         Section VARCHAR(20),
         Contact VARCHAR(50)
     );

     CREATE TABLE Users (
         UserID INT IDENTITY(1,1) PRIMARY KEY,
         Username VARCHAR(50) UNIQUE NOT NULL,
         Password VARCHAR(50) NOT NULL,
         Role VARCHAR(10) CHECK (Role IN ('Admin','Student')) NOT NULL,
         StudentID INT NULL FOREIGN KEY REFERENCES Students(StudentID)
     );

     CREATE TABLE Grades (
         GradeID INT IDENTITY(1,1) PRIMARY KEY,
         StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
         Subject VARCHAR(50) NOT NULL,
         Score DECIMAL(5,2) NOT NULL,
         DatePosted DATETIME DEFAULT GETDATE()
     );
     GO

     -- Sample Data
     INSERT INTO Students (FirstName, LastName, Section, Contact) VALUES 
     ('Juan', 'Dela Cruz', 'A-101', '09123456789'),
     ('Maria', 'Santos', 'A-102', '09234567890');

     INSERT INTO Users (Username, Password, Role, StudentID) VALUES 
     ('admin', 'admin123', 'Admin', NULL),
     ('juan', 'juan123', 'Student', 1),
     ('maria', 'maria123', 'Student', 2);

     INSERT INTO Grades (StudentID, Subject, Score) VALUES 
     (1, 'Mathematics', 92.50), (1, 'English', 88.00),
     (2, 'Mathematics', 95.75), (2, 'Science', 90.25);
     ```

4. **Check / Update Connection String**
   - Open **DBHelper.vb**
   - Verify the constant:
     ```vbnet
     Public Const ConnString As String = "Data Source=.\SQLEXPRESS;Initial Catalog=StudentGradesDB;Integrated Security=True"
     ```
   - Change `Data Source` if your SQL instance is different (e.g. `(localdb)\MSSQLLocalDB` or server name).

5. **Build and Run**
   - Press **F5** or click Start (Debug).
   - Login credentials (from sample data):
     - **Admin**: username `admin` / password `admin123` → full access
     - **Student**: username `juan` / password `juan123` → view own grades only

## Project Structure
- `frmLogin.vb` → Login screen
- `frmMDIParent.vb` → Main dashboard (MDI container)
- `frmStudentInput.vb` → Admin: Manage students + create accounts
- `frmGradeInput.vb` → Admin: Post grades
- `frmViewGrades.vb` → View grades (role-based)
- `DBHelper.vb` → All database operations
- `Globals.vb` → Current user/role storage

## How to Contribute
1. Create a new branch for your feature:
   ```bash
   git checkout -b yourname-feature-description   # e.g. juan-add-grade-edit
   ```
2. Make changes, commit:
   ```bash
   git add .
   git commit -m "Add grade editing functionality"
   ```
3. Push your branch:
   ```bash
   git push origin yourname-feature-description
   ```
4. Open a **Pull Request** on GitHub → assign to John/Lester for review.

## Common Issues & Fixes
- **Login fails** → Check connection string, run SQL script again, ensure SQL Server service is running.
- **ProgressBar not visible** → Ensure `Application.DoEvents()` is called in loops.
- **No students in ComboBox** → Run sample INSERTs.
- Debug tip: Put breakpoints in DBHelper functions.

Happy coding, team! Let's make this project shine for defense. Questions? Message the group chat.

