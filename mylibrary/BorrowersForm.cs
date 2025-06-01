using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace MyLibrary
{
    public partial class BorrowersForm : Form
    {
        public BorrowersForm()
        {
            InitializeComponent();
        }

        private void BorrowersForm_Load(object sender, EventArgs e)
        {
            ConfigureDataGridView();
            LoadBorrowers();
        }

        private void ConfigureDataGridView()
        {
            dgvBorrowers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBorrowers.MultiSelect = false;
            dgvBorrowers.ReadOnly = true;
            dgvBorrowers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBorrowers.AllowUserToAddRows = false;
            dgvBorrowers.AllowUserToDeleteRows = false;
        }

        private void LoadBorrowers()
        {
            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Id, Name, Email, Phone FROM Borrowers";
                    var adapter = new SQLiteDataAdapter(query, conn);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvBorrowers.DataSource = dt;

                 
                    if (dgvBorrowers.Columns.Contains("Id"))
                        dgvBorrowers.Columns["Id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load error: " + ex.Message);
            }
        }

        private string GetInput(string title, string prompt, string defaultValue = "")
        {
            using (var inputForm = new Form())
            using (var lblPrompt = new Label())
            using (var txtInput = new TextBox())
            using (var btnOk = new Button())
            {
                inputForm.Text = title;
                lblPrompt.Text = prompt;
                txtInput.Text = defaultValue;

                btnOk.Text = "OK";
                btnOk.DialogResult = DialogResult.OK;

                lblPrompt.SetBounds(10, 10, 280, 20);
                txtInput.SetBounds(10, 40, 280, 30);
                btnOk.SetBounds(220, 80, 70, 30);

                inputForm.ClientSize = new Size(300, 120);
                inputForm.Controls.AddRange(new Control[] { lblPrompt, txtInput, btnOk });
                inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                inputForm.StartPosition = FormStartPosition.CenterParent;
                inputForm.AcceptButton = btnOk;

                return inputForm.ShowDialog() == DialogResult.OK ? txtInput.Text.Trim() : "";
            }
        }

        private void btnAddBorrower_Click(object sender, EventArgs e)
        {
            string name = GetInput("Add Borrower", "Name:");
            string email = GetInput("Add Borrower", "Email:");
            string phone = GetInput("Add Borrower", "Phone:");

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name is required!");
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Borrowers (Name, Email, Phone) VALUES (@name, @email, @phone)";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@phone", phone);

                        cmd.ExecuteNonQuery();
                        LoadBorrowers();
                        MessageBox.Show("Borrower added successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add error: " + ex.Message);
            }
        }

        private void btnEditBorrower_Click(object sender, EventArgs e)
        {
            if (dgvBorrowers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a borrower first!");
                return;
            }

            var row = dgvBorrowers.SelectedRows[0];
            int borrowerId = Convert.ToInt32(row.Cells["Id"].Value);
            string currentName = row.Cells["Name"].Value.ToString();
            string currentEmail = row.Cells["Email"].Value?.ToString() ?? "";
            string currentPhone = row.Cells["Phone"].Value?.ToString() ?? "";

            string newName = GetInput("Edit Borrower", "Name:", currentName);
            string newEmail = GetInput("Edit Borrower", "Email:", currentEmail);
            string newPhone = GetInput("Edit Borrower", "Phone:", currentPhone);

            if (string.IsNullOrWhiteSpace(newName))
            {
                MessageBox.Show("Name is required!");
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Borrowers SET Name = @name, Email = @email, Phone = @phone WHERE Id = @id";

                    using (var cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", newName);
                        cmd.Parameters.AddWithValue("@email", newEmail);
                        cmd.Parameters.AddWithValue("@phone", newPhone);
                        cmd.Parameters.AddWithValue("@id", borrowerId);

                        cmd.ExecuteNonQuery();
                        LoadBorrowers();
                        MessageBox.Show("Borrower updated successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update error: " + ex.Message);
            }
        }

        private void btnDeleteBorrower_Click(object sender, EventArgs e)
        {
            if (dgvBorrowers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a borrower first!");
                return;
            }

            var row = dgvBorrowers.SelectedRows[0];
            int borrowerId = Convert.ToInt32(row.Cells["Id"].Value);
            string name = row.Cells["Name"].Value.ToString();

            if (MessageBox.Show($"Delete {name}?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = Database.GetConnection())
                    {
                        conn.Open();

                        // Check for issued books
                        string checkQuery = "SELECT COUNT(*) FROM IssuedBooks WHERE BorrowerId = @id";
                        using (var checkCmd = new SQLiteCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@id", borrowerId);
                            int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                            if (count > 0)
                            {
                                MessageBox.Show("Cannot delete borrower with issued books!");
                                return;
                            }
                        }

                        // Delete borrower
                        string deleteQuery = "DELETE FROM Borrowers WHERE Id = @id";
                        using (var cmd = new SQLiteCommand(deleteQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", borrowerId);
                            cmd.ExecuteNonQuery();
                            LoadBorrowers();
                            MessageBox.Show("Borrower deleted successfully!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete error: " + ex.Message);
                }
            }
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (dgvBorrowers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a borrower first!");
                return;
            }

            int borrowerId = Convert.ToInt32(dgvBorrowers.SelectedRows[0].Cells["Id"].Value);
            string bookId = GetInput("Issue Book", "Enter Book ID:");

            if (string.IsNullOrWhiteSpace(bookId) || !int.TryParse(bookId, out int bookIdInt))
            {
                MessageBox.Show("Valid book ID required!");
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // Check book availability
                    string checkQuery = "SELECT Quantity FROM Books WHERE Id = @bookId";
                    using (var checkCmd = new SQLiteCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@bookId", bookIdInt);
                        object result = checkCmd.ExecuteScalar();

                        if (result == null || Convert.ToInt32(result) < 1)
                        {
                            MessageBox.Show("Book not available!");
                            return;
                        }
                    }

                    // Issue book
                    string issueQuery = "INSERT INTO IssuedBooks (BookId, BorrowerId, IssueDate) " +
                                        "VALUES (@bookId, @borrowerId, date('now'))";

                    using (var issueCmd = new SQLiteCommand(issueQuery, conn))
                    {
                        issueCmd.Parameters.AddWithValue("@bookId", bookIdInt);
                        issueCmd.Parameters.AddWithValue("@borrowerId", borrowerId);
                        issueCmd.ExecuteNonQuery();
                    }

                    // Update book quantity
                    string updateQuery = "UPDATE Books SET Quantity = Quantity - 1 WHERE Id = @bookId";
                    using (var updateCmd = new SQLiteCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@bookId", bookIdInt);
                        updateCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Book issued successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Issue error: " + ex.Message);
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (dgvBorrowers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a borrower first!");
                return;
            }

            int borrowerId = Convert.ToInt32(dgvBorrowers.SelectedRows[0].Cells["Id"].Value);
            string bookId = GetInput("Return Book", "Enter Book ID:");

            if (string.IsNullOrWhiteSpace(bookId) || !int.TryParse(bookId, out int bookIdInt))
            {
                MessageBox.Show("Valid book ID required!");
                return;
            }

            try
            {
                using (var conn = Database.GetConnection())
                {
                    conn.Open();

                    // Check if book is issued to this borrower
                    string checkQuery = "SELECT Id FROM IssuedBooks WHERE BookId = @bookId AND BorrowerId = @borrowerId";
                    using (var checkCmd = new SQLiteCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@bookId", bookIdInt);
                        checkCmd.Parameters.AddWithValue("@borrowerId", borrowerId);
                        object result = checkCmd.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("No record found for this book!");
                            return;
                        }
                    }

                    // Return book (delete issued record)
                    string returnQuery = "DELETE FROM IssuedBooks WHERE BookId = @bookId AND BorrowerId = @borrowerId";
                    using (var returnCmd = new SQLiteCommand(returnQuery, conn))
                    {
                        returnCmd.Parameters.AddWithValue("@bookId", bookIdInt);
                        returnCmd.Parameters.AddWithValue("@borrowerId", borrowerId);
                        returnCmd.ExecuteNonQuery();
                    }

                    // Update book quantity
                    string updateQuery = "UPDATE Books SET Quantity = Quantity + 1 WHERE Id = @bookId";
                    using (var updateCmd = new SQLiteCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@bookId", bookIdInt);
                        updateCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Book returned successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Return error: " + ex.Message);
            }
        }

        private void dgvBorrowers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cell click handler if needed
        }
    }
}