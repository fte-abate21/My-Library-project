namespace MyLibrary
{
    partial class BookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblcopies = new System.Windows.Forms.Label();
            this.txtCopies = new System.Windows.Forms.TextBox();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnEditbook = new System.Windows.Forms.Button();
            this.btndeletebook = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(29, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(38, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.ForeColor = System.Drawing.Color.White;
            this.txtTitle.Location = new System.Drawing.Point(106, 28);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(108, 26);
            this.txtTitle.TabIndex = 1;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(106, 87);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(108, 26);
            this.txtAuthor.TabIndex = 2;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.ForeColor = System.Drawing.Color.Red;
            this.lblAuthor.Location = new System.Drawing.Point(29, 87);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(57, 20);
            this.lblAuthor.TabIndex = 3;
            this.lblAuthor.Text = "Author";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.ForeColor = System.Drawing.Color.Red;
            this.lblYear.Location = new System.Drawing.Point(29, 149);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(43, 20);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "Year";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(106, 149);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(108, 26);
            this.txtYear.TabIndex = 5;
            // 
            // lblcopies
            // 
            this.lblcopies.AutoSize = true;
            this.lblcopies.ForeColor = System.Drawing.Color.Red;
            this.lblcopies.Location = new System.Drawing.Point(12, 188);
            this.lblcopies.Name = "lblcopies";
            this.lblcopies.Size = new System.Drawing.Size(122, 20);
            this.lblcopies.TabIndex = 6;
            this.lblcopies.Text = "Available copies";
            // 
            // txtCopies
            // 
            this.txtCopies.Location = new System.Drawing.Point(184, 188);
            this.txtCopies.Name = "txtCopies";
            this.txtCopies.Size = new System.Drawing.Size(108, 26);
            this.txtCopies.TabIndex = 7;
            // 
            // btnAddBook
            // 
            this.btnAddBook.ForeColor = System.Drawing.Color.Red;
            this.btnAddBook.Location = new System.Drawing.Point(440, 16);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(93, 44);
            this.btnAddBook.TabIndex = 8;
            this.btnAddBook.Text = "AddBook";
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.BtnAddBook_Click);
            // 
            // btnEditbook
            // 
            this.btnEditbook.ForeColor = System.Drawing.Color.Red;
            this.btnEditbook.Location = new System.Drawing.Point(550, 16);
            this.btnEditbook.Name = "btnEditbook";
            this.btnEditbook.Size = new System.Drawing.Size(89, 44);
            this.btnEditbook.TabIndex = 9;
            this.btnEditbook.Text = "Edit Book";
            this.btnEditbook.UseVisualStyleBackColor = true;
            this.btnEditbook.Click += new System.EventHandler(this.BtnEditBook_Click);
            // 
            // btndeletebook
            // 
            this.btndeletebook.ForeColor = System.Drawing.Color.Red;
            this.btndeletebook.Location = new System.Drawing.Point(663, 19);
            this.btndeletebook.Name = "btndeletebook";
            this.btndeletebook.Size = new System.Drawing.Size(89, 44);
            this.btndeletebook.TabIndex = 10;
            this.btndeletebook.Text = "Delete Book";
            this.btndeletebook.UseVisualStyleBackColor = true;
            this.btndeletebook.Click += new System.EventHandler(this.BtnDeleteBook_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(440, 176);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(652, 417);
            this.dataGridView1.TabIndex = 11;
            // 
            // btnClear
            // 
            this.btnClear.ForeColor = System.Drawing.Color.Red;
            this.btnClear.Location = new System.Drawing.Point(810, 19);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 44);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.ClientSize = new System.Drawing.Size(1146, 615);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btndeletebook);
            this.Controls.Add(this.btnEditbook);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.txtCopies);
            this.Controls.Add(this.lblcopies);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Name = "BookForm";
            this.Text = "BookForm";
            this.Load += new System.EventHandler(this.BookForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblcopies;
        private System.Windows.Forms.TextBox txtCopies;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnEditbook;
        private System.Windows.Forms.Button btndeletebook;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnClear;
    }
}