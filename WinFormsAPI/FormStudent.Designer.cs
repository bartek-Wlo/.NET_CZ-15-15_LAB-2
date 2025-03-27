namespace StudentAPI
{
    partial class FormStudent
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.TextBox textBoxResponse;
        private System.Windows.Forms.ListBox listBox1;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.textBoxResponse = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            
            this.SuspendLayout();
            
            // buttonDownload
            this.buttonDownload.Location = new System.Drawing.Point(20, 12);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(1160, 30);
            this.buttonDownload.TabIndex = 0;
            this.buttonDownload.Text = "Download Data";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_ClickAsync);

            // textBoxResponse
            this.textBoxResponse.Location = new System.Drawing.Point(20, 41);
            this.textBoxResponse.Multiline = true;
            this.textBoxResponse.Name = "textBoxResponse";
            this.textBoxResponse.Size = new System.Drawing.Size(1160, 350);
            this.textBoxResponse.TabIndex = 1;

            // listBox1
            this.listBox1.Location = new System.Drawing.Point(20, 391);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1160, 300);
            this.listBox1.TabIndex = 2;
            this.listBox1.Font = new System.Drawing.Font("Consolas", 12F);

            this.Controls.Add(this.listBox1);

            // FormStudent
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.textBoxResponse);
            this.Controls.Add(this.buttonDownload);
            this.Name = "FormStudent";
            this.Text = "FormStudent";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
