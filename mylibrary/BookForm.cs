using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace MyLibrary
{
    public partial class BookForm : Form
    {
        private readonly string connString = Database.ConnectionString;
        private int selectedBookID = -1;

        public BookForm()
        {
            InitializeComponent();
            WireUpEvents();
            ConfigureGridView();
            this.Load += BookForm_Load;
        }

        private void WireUpEvents()
        {
            btnAddBook.Click += BtnAddBook_Click;
            btnEditbook.Click += BtnEditBook_Click;
            btndeletebook.Click += BtnDeleteBook_Click;
            btnClear.Click += BtnClear_Click;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
        }

        private void ConfigureGridView()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.DataBindingComplete += (sender, e) =>
            {
                if (dataGridView1.Columns.Contains("Quantity"))
                    dataGridView1.Columns["Quantity"].HeaderText = "Available Copies";
            };
        }

        private void BookForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            try
            {
                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    const string query = @"SELECT Id,Title, Author, Quantity FROM Books ORDER BY Title";
                    var dt = new DataTable();
                    new SQLiteDataAdapter(query, conn).Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading books: {ex.Message}");
            }
        }

        private void BtnAddBook_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    const string query = @"INSERT INTO Books (Title, Author, Quantity) VALUES (@Title, @Author, @Quantity)";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Author", txtAuthor.Text.Trim());
                        cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtCopies.Text));
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Book added successfully!");
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding book: {ex.Message}");
            }
        }

        private void BtnEditBook_Click(object sender, EventArgs e)
        {
            if (selectedBookID == -1)
            {
                MessageBox.Show("Please select a book to edit");
                return;
            }

            if (!ValidateInputs()) return;

            try
            {
                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    const string query = @"UPDATE Books SET Title = @Title, Author = @Author, Quantity = @Quantity WHERE Id = @Id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Author", txtAuthor.Text.Trim());
                        cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtCopies.Text));
                        cmd.Parameters.AddWithValue("@Id", selectedBookID);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Book updated successfully!");
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating book: {ex.Message}");
            }
        }

        private void BtnDeleteBook_Click(object sender, EventArgs e)
        {
            if (selectedBookID == -1)
            {
                MessageBox.Show("Please select a book to delete");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();
                    const string query = "DELETE FROM Books WHERE Id = @Id";
                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", selectedBookID);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Book deleted successfully!");
                LoadBooks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting book: {ex.Message}");
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                ClearFields();
                return;
            }

            var row = dataGridView1.SelectedRows[0];
            selectedBookID = Convert.ToInt32(row.Cells["Id"].Value);
            txtTitle.Text = row.Cells["Title"].Value?.ToString() ?? "";
            txtAuthor.Text = row.Cells["Author"].Value?.ToString() ?? "";
            
           txtCopies.Text = row.Cells["Quantity"].Value?.ToString() ?? "";
            
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title cannot be empty");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Author cannot be empty");
                return false;
            }

            if (!int.TryParse(txtCopies.Text, out int copies) || copies < 0)
            {
                MessageBox.Show("Please enter valid available copies");
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            selectedBookID = -1;
            txtTitle.Clear();
            txtAuthor.Clear();
            txtCopies.Clear();
            dataGridView1.ClearSelection();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
