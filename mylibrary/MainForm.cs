using System;
using System.Windows.Forms;

namespace MyLibrary
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent(); 
            this.Load += MainForm_Load; 
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            TestConnectionForm form = new TestConnectionForm();
            form.ShowDialog();
        }

        private void btnBooksManagement_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm();
            bookForm.ShowDialog();
        }

        private void btnBorrowersManagement_Click(object sender, EventArgs e)
        {
            BorrowersForm borrowersForm = new BorrowersForm();
            borrowersForm.ShowDialog();
        }
    }
}
