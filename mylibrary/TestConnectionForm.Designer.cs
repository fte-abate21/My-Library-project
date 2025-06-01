namespace MyLibrary
{
    partial class TestConnectionForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(45, 46);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(180, 35);
            this.btnTestConnection.TabIndex = 0;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(45, 108);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 20);
            this.lblStatus.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 248);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnTestConnection);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TestConnectionForm"; // ✅ match the class name
            this.Text = "Database Connection Test";
            this.Load += new System.EventHandler(this.TestConnectionForm_Load); // ✅ match your load method

            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}