using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace MyLibrary
{
    public static class Database
    {
      
        private static readonly string dbPath = Path.Combine(Application.StartupPath, "library.db");
        private static readonly string connString = $"Data Source={dbPath};Version=3;";
        public static string ConnectionString => connString;
        public static bool TestConnection()
        {
            try
            {
                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    const string testQuery = "SELECT 1 FROM sqlite_master WHERE type='table' AND name='Books'";
                    using (var cmd = new SQLiteCommand(testQuery, conn))
                    {
                        return cmd.ExecuteScalar() != null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}");
                return false;
            }
        }
        public static void InitializeDatabase()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();

                string createTables = @"
                    CREATE TABLE IF NOT EXISTS Books (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Author TEXT NOT NULL,
                        Year TEXT NOT NULL,
                        Quantity INTEGER NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS Borrowers (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Email TEXT,
                        Phone TEXT
                    );

                    CREATE TABLE IF NOT EXISTS IssuedBooks (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        BookId INTEGER NOT NULL,
                        BorrowerId INTEGER NOT NULL,
                        IssueDate TEXT NOT NULL,
                        FOREIGN KEY(BookId) REFERENCES Books(Id),
                        FOREIGN KEY(BorrowerId) REFERENCES Borrowers(Id)
                    );

                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        Password TEXT NOT NULL
                    );
                ";

                using (var cmd = new SQLiteCommand(createTables, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connString);
        }
    }
}
