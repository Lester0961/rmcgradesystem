# 📚 RMC Grade Management System

![Visual Basic](https://img.shields.io/badge/Language-Visual%20Basic%20.NET-blue?style=flat-square)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-purple?style=flat-square)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server%20Express-red?style=flat-square)
![Visual Studio](https://img.shields.io/badge/IDE-Visual%20Studio%202022-blueviolet?style=flat-square)
![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)

A desktop-based **Student Grade Management System** built with **VB.NET (Windows Forms)** and **SQL Server Express (SSMS)**. Designed for academic institutions to manage student records, post term grades, and calculate GWA (General Weighted Average) with role-based access for Admins and Students.

---

## 📋 Table of Contents

- [Features](#-features)
- [System Requirements](#-system-requirements)
- [Tech Stack](#-tech-stack)
- [Database Schema](#-database-schema)
- [Project Structure](#-project-structure)
- [Getting Started](#-getting-started)
- [How to Clone and Run](#-how-to-clone-and-run-via-cmd)
- [Usage Guide](#-usage-guide)
- [Role Access Matrix](#-role-access-matrix)
- [Known Limitations](#-known-limitations)
- [Contributing](#-contributing)

---

## ✨ Features

- 🔐 **Role-Based Login** — Separate access for Admin and Student accounts
- 👨‍🎓 **Student Management** — Add, update, delete, and view student records (Admin only)
  - First and Last Name are forced **uppercase**
  - Section follows strict format: `XXXX-X0` (e.g. `BSCS-B1`)
  - Contact is limited to exactly **11 digits**
  - Password is **visible while typing** for easy verification
- 📝 **Grade Input** — Post term grades (Prelim, Midterm, Final) with weighted component calculation
  - Changing student clears all fields below
  - Changing subject clears term and grade components
  - Changing term clears grade components and calculated grade
- 📊 **GWA Calculator** — Automatically computes General Weighted Average using numerical grade conversion (complete subjects only)
- 📋 **Grade Viewer**
  - **Admin** — sees a full-screen grade records table for all students
  - **Student** — sees their own grade records, subject summary, GWA, and grading scale reference
- 🔄 **MDI Interface** — Multi-Document Interface dashboard with menu-based navigation
- ✅ **Input Validation** — Duplicate username detection, required field checks, and safe deletion with FK cascade handling

---

## 💻 System Requirements

| Requirement | Minimum Version |
|-------------|----------------|
| Operating System | Windows 10 / 11 |
| IDE | Visual Studio 2019 or later |
| .NET Framework | 4.7.2 or later |
| Database | SQL Server Express 2019+ |
| SSMS | SQL Server Management Studio 18+ |
| Git | Any recent version |
| RAM | 4GB minimum |

---

## 🛠 Tech Stack

- **Frontend / UI** — Windows Forms (VB.NET)
- **Backend Logic** — VB.NET (.NET Framework)
- **Database** — Microsoft SQL Server Express (`StudentGradesDB`)
- **ORM / Data Access** — ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`)
- **IDE** — Visual Studio 2022 Community

---

## 🗄 Database Schema

The system uses a database named `StudentGradesDB` with the following tables:

```
Students       → StudentID, FirstName, LastName, Section, Contact
Subjects       → SubjectID, SubjectCode, SubjectName, Units
Users          → UserID, Username, Password, Role, StudentID (FK)
Grades         → GradeID, StudentID (FK), SubjectID (FK), Term, Score, DatePosted
```

**Grade Term Options:** `Prelim`, `Midterm`, `Final`

**GWA Formula:**
```
Term Score   = (Quizzes × 30%) + (Assignments × 10%) + (Attendance × 10%) + (Projects × 20%) + (Exam × 30%)
Weighted Avg = (Prelim × 30%) + (Midterm × 30%) + (Final × 40%)
GWA          = Σ(NumericalGrade × Units) / Σ(Units)   ← complete subjects only
```

**Numerical Grade Conversion:**

| Percentage Range | Numerical Grade |
|-----------------|----------------|
| 98 – 100%       | 1.00 |
| 95 – 97%        | 1.25 |
| 93 – 94%        | 1.50 |
| 90 – 92%        | 1.75 |
| 87 – 89%        | 2.00 |
| 84 – 86%        | 2.25 |
| 81 – 83%        | 2.50 |
| 79 – 80%        | 2.75 |
| 75 – 78%        | 3.00 |
| Below 75%       | 5.00 (Failed) |

> **Note:** StudentIDs are permanently unique and never reused after deletion — this is intentional behavior matching real school ID systems.

---

## 📁 Project Structure

```
rmcsystem/
│
├── rmcsystem.sln                  # Solution file
├── rmcsystem/
│   ├── frmLogin.vb                # Login form
│   ├── frmLogin.Designer.vb
│   │
│   ├── FrmMDIParent.vb            # Main dashboard (MDI container)
│   ├── FrmMDIParent.Designer.vb
│   │
│   ├── frmStudentInput.vb         # Manage students (Admin only)
│   ├── frmStudentInput.Designer.vb
│   │
│   ├── FrmGradeInput.vb           # Post grades (Admin only)
│   ├── FrmGradeInput.Designer.vb
│   │
│   ├── FrmViewGrades.vb           # View grades + GWA calculator
│   ├── FrmViewGrades.Designer.vb
│   │
│   ├── DBHelper.vb                # Database helper module (ADO.NET)
│   ├── CurrentUser.vb             # Session/current user module
│   │
│   └── My Project/
│       ├── Application.Designer.vb
│       ├── Application.myapp
│       └── Settings.Designer.vb
│
└── README.md
```

---

## 🚀 Getting Started

### Step 1 — Set Up the Database

1. Open **SQL Server Management Studio (SSMS)**
2. Connect to your local instance (e.g., `.\SQLEXPRESS`)
3. Open a **New Query** window
4. Copy and run the full SQL script below:

```sql
CREATE DATABASE StudentGradesDB;
GO
USE StudentGradesDB;
GO

CREATE TABLE Students (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName  VARCHAR(50) NOT NULL,
    Section   VARCHAR(20) NOT NULL,
    Contact   VARCHAR(50)
);

CREATE TABLE Subjects (
    SubjectID   INT IDENTITY(1,1) PRIMARY KEY,
    SubjectCode VARCHAR(20) UNIQUE NOT NULL,
    SubjectName VARCHAR(100) NOT NULL,
    Units       INT NOT NULL CHECK (Units >= 1)
);

CREATE TABLE Users (
    UserID    INT IDENTITY(1,1) PRIMARY KEY,
    Username  VARCHAR(50)  UNIQUE NOT NULL,
    Password  VARCHAR(255) NOT NULL,
    Role      VARCHAR(10)  NOT NULL CHECK (Role IN ('Admin','Student')),
    StudentID INT NULL FOREIGN KEY REFERENCES Students(StudentID)
);

CREATE TABLE Grades (
    GradeID    INT IDENTITY(1,1) PRIMARY KEY,
    StudentID  INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
    SubjectID  INT NOT NULL FOREIGN KEY REFERENCES Subjects(SubjectID),
    Term       VARCHAR(20) NOT NULL CHECK (Term IN ('Prelim','Midterm','Final')),
    Score      DECIMAL(5,2) NOT NULL CHECK (Score BETWEEN 0 AND 100),
    DatePosted DATETIME DEFAULT GETDATE(),
    CONSTRAINT UQ_Grades_Student_Subject_Term UNIQUE (StudentID, SubjectID, Term)
);
GO

-- Sample Data
INSERT INTO Students VALUES ('JUAN','DELA CRUZ','BSIT-1A','09123456789'),
                             ('MARIA','SANTOS','BSIT-1B','09876543210');

INSERT INTO Subjects VALUES ('MATH101','Mathematics',3),
                             ('ENG101','English Communication',3),
                             ('PE101','Physical Education',2);

INSERT INTO Users VALUES ('admin','admin123','Admin',NULL),
                          ('juan','juan123','Student',1),
                          ('maria','maria123','Student',2);

INSERT INTO Grades (StudentID,SubjectID,Term,Score) VALUES
(1,1,'Prelim',87.50),(1,1,'Midterm',89.00),(1,1,'Final',91.25),
(1,2,'Prelim',82.00),(1,2,'Midterm',85.50),(1,2,'Final',88.00),
(1,3,'Prelim',90.00),(1,3,'Midterm',88.00),(1,3,'Final',92.00),
(2,1,'Prelim',78.00),(2,1,'Midterm',80.50),(2,1,'Final',83.00),
(2,2,'Prelim',80.00),(2,2,'Midterm',83.00),(2,2,'Final',85.00),
(2,3,'Prelim',88.00),(2,3,'Midterm',90.00),(2,3,'Final',91.00);
GO
```

---

## 💻 How to Clone and Run via CMD

### Step 1 — Open Command Prompt

Press `Win + R`, type `cmd`, press **Enter**.

---

### Step 2 — Navigate to your desired folder

```cmd
cd C:\Users\YourName\source\repos
```

> Replace `YourName` with your actual Windows username.

---

### Step 3 — Clone the repository

```cmd
git clone https://github.com/Lester0961/rmcgradesystem.git
```

---

### Step 4 — Navigate into the project folder

```cmd
cd rmcgradesystem
```

---

### Step 5 — Open the solution in Visual Studio

```cmd
start rmcsystem.sln
```

---

### Step 6 — Set up the database

Run the SQL script from the [Getting Started](#-getting-started) section in SSMS before running the app.

---

### Step 7 — Verify the database connection string

Open `DBHelper.vb` and confirm it matches your SQL Server instance:

```vb
Public Const ConnStr As String =
    "Data Source=.\SQLEXPRESS;Initial Catalog=StudentGradesDB;Integrated Security=True;TrustServerCertificate=True;"
```

> If your instance name differs (e.g., `SQLSERVER`), update `.\SQLEXPRESS` accordingly.

---

### Step 8 — Build and Run

Press `Ctrl + Shift + B` to build, then `F5` to run.

---

## 📖 Usage Guide

### Login Credentials (Sample)

| Role | Username | Password |
|------|----------|----------|
| Admin | `admin` | `admin123` |
| Student | `juan` | `juan123` |
| Student | `maria` | `maria123` |

---

### Admin Workflow

1. **Login** as `admin`
2. **Manage → Students** — add, update, or delete student records
   - Names are forced uppercase automatically
   - Section must follow `XXXX-X0` format (e.g. `BSCS-B1`)
   - Contact must be exactly 11 digits
   - Password is visible while typing
3. **Grades → Post Grades** — select student → subject → term → enter components → Calculate → Post
4. **Grades → View Grades** — full-screen table showing all student grade records
5. **File → Logout** to sign out

---

### Student Workflow

1. **Login** as a student (e.g., `juan`)
2. **Grades → View Grades** — view your own grade records, subject summary, GWA, and grading scale
3. **File → Logout** to sign out

---

## 🔐 Role Access Matrix

| Feature | Admin | Student |
|---------|:-----:|:-------:|
| Manage Students | ✅ | ❌ |
| Post Grades | ✅ | ❌ |
| View All Grades (full table) | ✅ | ❌ |
| View Own Grades + Summary | ❌ | ✅ |
| View GWA & Grading Scale | ❌ | ✅ |
| Logout / Exit | ✅ | ✅ |

---

## ⚠️ Known Limitations

- Passwords are stored in **plain text** — for production use, implement password hashing (e.g., bcrypt)
- No forgot password or password reset feature
- StudentIDs never reset after deletion — this is **by design** (permanent unique identifiers)
- Single-instance application (no multi-user concurrent access handling)
- No export to PDF/Excel feature for grade reports

---

## 🤝 Contributing

1. Fork the repository
2. Create a new branch: `git checkout -b feature/your-feature-name`
3. Commit your changes: `git commit -m "Add: your feature description"`
4. Push to the branch: `git push origin feature/your-feature-name`
5. Open a **Pull Request**

---

## 📄 License

This project is licensed under the **MIT License** 

---

> Built with ❤️ using VB.NET and SQL Server Express — RMC Grade Management System © 2026
