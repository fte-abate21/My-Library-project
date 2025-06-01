using System;
using System.Windows.Forms;

namespace MyLibrary
{
    public partial class TestConnectionForm : Form  // Proper Form inheritance
    {
        public TestConnectionForm()
        {
            InitializeComponent();  // Essential for designer-generated code
            this.Load += new EventHandler(TestConnectionForm_Load);  // Optional: attach Load event handler
        }

        private void TestConnectionForm_Load(object sender, EventArgs e)
        {
            // Optional logic when the form loads (e.g., reset status label)
            lblStatus.Text = "";
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            bool isConnected = Database.TestConnection();
            lblStatus.Text = isConnected ? "✅ Connected!" : "❌ Connection failed!";
            lblStatus.ForeColor = isConnected ? System.Drawing.Color.Green : System.Drawing.Color.Red;
        }
    }
}
