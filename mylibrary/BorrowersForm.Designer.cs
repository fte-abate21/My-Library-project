namespace MyLibrary
{
    partial class BorrowersForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddBorrower = new System.Windows.Forms.Button();
            this.btnEditBorrower = new System.Windows.Forms.Button();
            this.btnDeleteBorrower = new System.Windows.Forms.Button();
            this.btnIssueBook = new System.Windows.Forms.Button();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.dgvBorrowers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowers)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Borrowers Management";
            // 
            // btnAddBorrower
            // 
            this.btnAddBorrower.BackColor = System.Drawing.Color.Red;
            this.btnAddBorrower.Location = new System.Drawing.Point(207, 19);
            this.btnAddBorrower.Name = "btnAddBorrower";
            this.btnAddBorrower.Size = new System.Drawing.Size(123, 31);
            this.btnAddBorrower.TabIndex = 1;
            this.btnAddBorrower.Text = "AddBorrower";
            this.btnAddBorrower.UseVisualStyleBackColor = false;
            this.btnAddBorrower.Click += new System.EventHandler(this.btnAddBorrower_Click);
            // 
            // btnEditBorrower
            // 
            this.btnEditBorrower.BackColor = System.Drawing.Color.Red;
            this.btnEditBorrower.Location = new System.Drawing.Point(349, 19);
            this.btnEditBorrower.Name = "btnEditBorrower";
            this.btnEditBorrower.Size = new System.Drawing.Size(123, 31);
            this.btnEditBorrower.TabIndex = 2;
            this.btnEditBorrower.Text = "EditBorrower";
            this.btnEditBorrower.UseVisualStyleBackColor = false;
            this.btnEditBorrower.Click += new System.EventHandler(this.btnEditBorrower_Click);
            // 
            // btnDeleteBorrower
            // 
            this.btnDeleteBorrower.BackColor = System.Drawing.Color.Red;
            this.btnDeleteBorrower.Location = new System.Drawing.Point(495, 19);
            this.btnDeleteBorrower.Name = "btnDeleteBorrower";
            this.btnDeleteBorrower.Size = new System.Drawing.Size(131, 31);
            this.btnDeleteBorrower.TabIndex = 3;
            this.btnDeleteBorrower.Text = "DeleteBorrower";
            this.btnDeleteBorrower.UseVisualStyleBackColor = false;
            this.btnDeleteBorrower.Click += new System.EventHandler(this.btnDeleteBorrower_Click);
            // 
            // btnIssueBook
            // 
            this.btnIssueBook.BackColor = System.Drawing.Color.Red;
            this.btnIssueBook.Location = new System.Drawing.Point(647, 19);
            this.btnIssueBook.Name = "btnIssueBook";
            this.btnIssueBook.Size = new System.Drawing.Size(131, 31);
            this.btnIssueBook.TabIndex = 4;
            this.btnIssueBook.Text = "IssueBook";
            this.btnIssueBook.UseVisualStyleBackColor = false;
            this.btnIssueBook.Click += new System.EventHandler(this.btnIssueBook_Click);
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.BackColor = System.Drawing.Color.Red;
            this.btnReturnBook.Location = new System.Drawing.Point(795, 19);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(131, 31);
            this.btnReturnBook.TabIndex = 5;
            this.btnReturnBook.Text = "ReturnBook";
            this.btnReturnBook.UseVisualStyleBackColor = false;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // dgvBorrowers
            // 
            this.dgvBorrowers.AllowUserToResizeColumns = false;
            this.dgvBorrowers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowers.Location = new System.Drawing.Point(45, 136);
            this.dgvBorrowers.MultiSelect = false;
            this.dgvBorrowers.Name = "dgvBorrowers";
            this.dgvBorrowers.RowHeadersWidth = 62;
            this.dgvBorrowers.RowTemplate.Height = 28;
            this.dgvBorrowers.Size = new System.Drawing.Size(740, 468);
            this.dgvBorrowers.TabIndex = 6;
            // 
            // BorrowersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.ClientSize = new System.Drawing.Size(970, 695);
            this.Controls.Add(this.dgvBorrowers);
            this.Controls.Add(this.btnReturnBook);
            this.Controls.Add(this.btnIssueBook);
            this.Controls.Add(this.btnDeleteBorrower);
            this.Controls.Add(this.btnEditBorrower);
            this.Controls.Add(this.btnAddBorrower);
            this.Controls.Add(this.label1);
            this.Name = "BorrowersForm";
            this.Text = "BorrowersForm";
            this.Load += new System.EventHandler(this.BorrowersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddBorrower;
        private System.Windows.Forms.Button btnEditBorrower;
        private System.Windows.Forms.Button btnDeleteBorrower;
        private System.Windows.Forms.Button btnIssueBook;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.DataGridView dgvBorrowers;
    }
}
