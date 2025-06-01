DONE BY Fitalew Abate    ID ...........1501210









# My-Library-project
it is about library management
Overview
The Library Management System is a comprehensive desktop application designed to streamline library operations. Built with C# .NET WinForms and SQLite, this solution enables librarians to efficiently manage books, borrowers, and lending operations through an intuitive interface
Key Features
Book Management: Add, edit, and delete books

Borrower Management: Maintain member records

Lending Operations: Issue and return books

Database Integration: Automatic SQLite database handling

User Authentication: Secure login system

Transaction Tracking: Monitor book lending history
echnology Stack
Frontend: C# .NET WinForms

Database: SQLite

Dependencies: System.Data.SQLite
Installation Guide
Prerequisites
.NET Framework 4.7.2 or higher

Visual Studio 2019/2022 (recommended)
Setup Instructions
Clone the repository:

bash
git clone https://github.com/yourusername/library-management-system.git
cd library-management-system
Open solution in Visual Studio:

Open MyLibrary.sln

Allow NuGet packages to restore automatically

Build the solution:

In Visual Studio: Build > Build Solution (Ctrl+Shift+B)

Or via command line:

bash
msbuild MyLibrary.sln
Run the application:

bin\Debug\MyLibrary.exe
Database Configuration
The application automatically creates library.db in bin\Debug on first run with this schema:
CREATE TABLE Books (
    BookID INTEGER PRIMARY KEY AUTOINCREMENT,
    Title TEXT NOT NULL,
    Author TEXT NOT NULL,
    Year INTEGER,
    AvailableCopies INTEGER DEFAULT 1
);

CREATE TABLE Borrowers (
    BorrowerID INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Email TEXT NOT NULL,
    Phone TEXT NOT NULL
);

CREATE TABLE IssuedBooks (
    IssueID INTEGER PRIMARY KEY AUTOINCREMENT,
    BookID INTEGER,
    BorrowerID INTEGER,
    IssueDate DATE,
    DueDate DATE,
    FOREIGN KEY(BookID) REFERENCES Books(BookID),
    FOREIGN KEY(BorrowerID) REFERENCES Borrowers(BorrowerID)
);
Usage Guide
Login


Username: ftalew

Password: 1234

Login Screen

Book Management
Add new books with details

Edit existing book information

Delete books (if no active loans)

Book Management

Borrower Management
Register new library members

Update borrower information

Delete borrower records

Borrower Management

Book Transactions
Issue Books:

Select borrower

Enter Book ID

System records issue date and sets due date (14 days)

Issue Book

Return Books:

Select borrower

Enter Book ID

System updates availability
Screenshots
More application screenshots available in the data folder
