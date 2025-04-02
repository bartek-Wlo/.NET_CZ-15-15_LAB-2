namespace StudentAPI
{
    partial class FormStudent
    {
        int buttonY = 356, move = 200;
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Button buttonId;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.TextBox listResponse;
        private System.Windows.Forms.ListBox listDeserializowany;
        private System.Windows.Forms.ListBox listDataBase;

        private System.Windows.Forms.Button buttonRemoveAll;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonGetTop;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Button buttonRemove;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.buttonId = new System.Windows.Forms.Button();
            this.textId = new System.Windows.Forms.TextBox();
            this.listResponse = new System.Windows.Forms.TextBox();
            this.listDeserializowany = new System.Windows.Forms.ListBox();

            this.buttonRemoveAll = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonGetTop = new System.Windows.Forms.Button();
            this.buttonSort = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.listDataBase = new System.Windows.Forms.ListBox();
            
            this.SuspendLayout();
            
            // buttonDownload
            this.buttonDownload.Location = new System.Drawing.Point(20, 12);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(480, 30);
            this.buttonDownload.TabIndex = 0;
            this.buttonDownload.Text = "Download Data";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_ClickAsync);

            // textId
            this.textId.Location = new System.Drawing.Point(520, 12);
            this.textId.Name = "textBoxId";
            this.textId.Size = new System.Drawing.Size(480, 30);
            this.textId.TabIndex = 1;
            this.textId.Text = "Podaj ID użytkownika do znalezienia";

            // buttonSearchById
            this.buttonId.Location = new System.Drawing.Point(1020, 12);
            this.buttonId.Name = "buttonSearchById";
            this.buttonId.Size = new System.Drawing.Size(460, 30);
            this.buttonId.TabIndex = 2;
            this.buttonId.Text = "Wyszukaj po ID";
            this.buttonId.UseVisualStyleBackColor = true;
            this.buttonId.Click += new System.EventHandler(this.buttonyId_ClickAsync);
            
            // listResponse
            this.listResponse.Multiline = true;
            this.listResponse.ReadOnly = true;
            this.listResponse.Location = new System.Drawing.Point(20, 48);
            this.listResponse.Name = "listResponse";
            this.listResponse.Size = new System.Drawing.Size(1460, 60);
            this.listResponse.TabIndex = 3;
            this.listResponse.BorderStyle = BorderStyle.FixedSingle;
            this.listResponse.MouseEnter += new System.EventHandler(this.listResponse_MauseEnter);
            this.listResponse.MouseLeave += new System.EventHandler(this.listResponse_MauseLeave);

            // listDeserializowany
            this.listDeserializowany.FormattingEnabled = true;
            this.listDeserializowany.ItemHeight = 16;
            this.listDeserializowany.Location = new System.Drawing.Point(20, 114);
            this.listDeserializowany.Name = "listDeserializowany";
            this.listDeserializowany.Size = new System.Drawing.Size(1460, 202);
            this.listDeserializowany.TabIndex = 4;
            this.listDeserializowany.Font = new System.Drawing.Font("Lucida Console", 10F);

            // buttonRemoveAll
            this.buttonRemoveAll.BackColor = System.Drawing.Color.Red;
            this.buttonRemoveAll.Location = new System.Drawing.Point(20, 322);
            this.buttonRemoveAll.Name = "buttonRemoveAll";
            this.buttonRemoveAll.Size = new System.Drawing.Size(730, 30);
            this.buttonRemoveAll.TabIndex = 5;
            this.buttonRemoveAll.Text = "USUŃ WSZYSTKIE REKORDY";
            this.buttonRemoveAll.UseVisualStyleBackColor = false;
            this.buttonRemoveAll.Click += new System.EventHandler(this.buttonRemoveAll_Click);

            this.buttonAdd.BackColor = System.Drawing.Color.Green;
            this.buttonAdd.Location = new System.Drawing.Point(750, 322); 
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(730, 30);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Dodaj";
            this.buttonAdd.ForeColor = System.Drawing.Color.White;
            this.buttonAdd.UseVisualStyleBackColor = false;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);

            this.buttonGetTop.Location = new System.Drawing.Point(20, buttonY);
            this.buttonGetTop.Name = "buttonGetTop";
            this.buttonGetTop.Size = new System.Drawing.Size(480, 30);
            this.buttonGetTop.TabIndex = 6;
            this.buttonGetTop.Text = "Pokaż ID więsze od <int>";
            this.buttonGetTop.UseVisualStyleBackColor = true;
            this.buttonGetTop.Click += new System.EventHandler(this.buttonGetTop_Click);

            this.buttonSort.Location = new System.Drawing.Point(520, buttonY);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(480, 30);
            this.buttonSort.TabIndex = 7;
            this.buttonSort.Text = "Sortuj malejąco po ID";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);

            this.buttonRemove.Location = new System.Drawing.Point(1020, buttonY);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(460, 30);
            this.buttonRemove.TabIndex = 8;
            this.buttonRemove.Text = "Usuń po ID, podaj <int>";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);

            // listDataBase
            this.listDataBase.FormattingEnabled = true;
            this.listDataBase.ItemHeight = 16;
            this.listDataBase.Location = new System.Drawing.Point(20, 390);
            this.listDataBase.Name = "listDataBase";
            this.listDataBase.Size = new System.Drawing.Size(1460, 292);
            this.listDataBase.TabIndex = 4;
            this.listDataBase.Font = new System.Drawing.Font("Lucida Console", 10F);

            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.buttonId);
            this.Controls.Add(this.listResponse);
            this.Controls.Add(this.listDeserializowany);
            this.Controls.Add(this.buttonRemoveAll);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonGetTop);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.listDataBase);

            // FormStudent
            this.ClientSize = new System.Drawing.Size(1500, 700);
            this.Name = "FormStudent";
            this.Text = "[.NET][CZ 15:15][LAB 2] \"API\"";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void listResponse_MauseEnter(object sender, EventArgs e) {
            listResponse.Height = 260;
            listDeserializowany.Location = new System.Drawing.Point(20, 114 + move);
            buttonRemoveAll.Location = new System.Drawing.Point(20, 322 + move);
            buttonAdd.Location = new System.Drawing.Point(750, 322 + move);
            buttonGetTop.Location = new System.Drawing.Point(20, buttonY + move);
            buttonSort.Location = new System.Drawing.Point(520, buttonY + move);
            buttonRemove.Location = new System.Drawing.Point(1020, buttonY + move);
            listDataBase.Location = new System.Drawing.Point(20, 390 + move);
        }
        private void listResponse_MauseLeave(object sender, EventArgs e) {
            listResponse.Height = 260 - move;
            listDeserializowany.Location = new System.Drawing.Point(20, 114);
            buttonRemoveAll.Location = new System.Drawing.Point(20, 322);
            buttonAdd.Location = new System.Drawing.Point(750, 322);
            buttonGetTop.Location = new System.Drawing.Point(20, buttonY);
            buttonSort.Location = new System.Drawing.Point(520, buttonY);
            buttonRemove.Location = new System.Drawing.Point(1020, buttonY);
            listDataBase.Location = new System.Drawing.Point(20, 390);
        }
    }
}
