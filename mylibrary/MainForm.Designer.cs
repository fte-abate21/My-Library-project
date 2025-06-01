namespace MyLibrary
{
    partial class MainForm
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
            this.btnBooksManagement = new System.Windows.Forms.Button();
            this.btnBorrowersManagement = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBooksManagement
            // 
            this.btnBooksManagement.BackColor = System.Drawing.Color.Red;
            this.btnBooksManagement.Location = new System.Drawing.Point(270, 51);
            this.btnBooksManagement.Name = "btnBooksManagement";
            this.btnBooksManagement.Size = new System.Drawing.Size(209, 60);
            this.btnBooksManagement.TabIndex = 0;
            this.btnBooksManagement.Text = "BooksManagement";
            this.btnBooksManagement.UseVisualStyleBackColor = false;
            this.btnBooksManagement.Click += new System.EventHandler(this.btnBooksManagement_Click);
            // 
            // btnBorrowersManagement
            // 
            this.btnBorrowersManagement.BackColor = System.Drawing.Color.Red;
            this.btnBorrowersManagement.Location = new System.Drawing.Point(281, 201);
            this.btnBorrowersManagement.Name = "btnBorrowersManagement";
            this.btnBorrowersManagement.Size = new System.Drawing.Size(198, 48);
            this.btnBorrowersManagement.TabIndex = 1;
            this.btnBorrowersManagement.Text = "BorrowersManagement";
            this.btnBorrowersManagement.UseVisualStyleBackColor = false;
            this.btnBorrowersManagement.Click += new System.EventHandler(this.btnBorrowersManagement_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBorrowersManagement);
            this.Controls.Add(this.btnBooksManagement);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBooksManagement;
        private System.Windows.Forms.Button btnBorrowersManagement;
    }
}