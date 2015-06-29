namespace MyUseWizardsLib
{
    partial class ConnectionWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.cbServer = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbInitialCatalog = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkSetDefault = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAuthType = new System.Windows.Forms.ComboBox();
            this.labAuth = new System.Windows.Forms.Label();
            this.chkUseLocalDB = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "伺服器名稱：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "使用者名稱：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密碼：";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(97, 120);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(191, 22);
            this.txtPassword.TabIndex = 5;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(97, 83);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(191, 22);
            this.txtUserID.TabIndex = 4;
            // 
            // cbServer
            // 
            this.cbServer.FormattingEnabled = true;
            this.cbServer.Location = new System.Drawing.Point(97, 12);
            this.cbServer.Name = "cbServer";
            this.cbServer.Size = new System.Drawing.Size(191, 20);
            this.cbServer.TabIndex = 6;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(43, 226);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(92, 36);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "確定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(154, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 36);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbInitialCatalog
            // 
            this.cbInitialCatalog.FormattingEnabled = true;
            this.cbInitialCatalog.Location = new System.Drawing.Point(97, 159);
            this.cbInitialCatalog.Name = "cbInitialCatalog";
            this.cbInitialCatalog.Size = new System.Drawing.Size(191, 20);
            this.cbInitialCatalog.TabIndex = 9;
            this.cbInitialCatalog.DropDown += new System.EventHandler(this.cbInitialCatalog_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "資料庫名稱：";
            // 
            // chkSetDefault
            // 
            this.chkSetDefault.AutoSize = true;
            this.chkSetDefault.Location = new System.Drawing.Point(97, 195);
            this.chkSetDefault.Name = "chkSetDefault";
            this.chkSetDefault.Size = new System.Drawing.Size(96, 16);
            this.chkSetDefault.TabIndex = 11;
            this.chkSetDefault.Text = "設為預設連線";
            this.chkSetDefault.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "為預設";
            // 
            // cbAuthType
            // 
            this.cbAuthType.FormattingEnabled = true;
            this.cbAuthType.Items.AddRange(new object[] {
            "SQL Server 驗證",
            "Windows 驗證"});
            this.cbAuthType.Location = new System.Drawing.Point(97, 48);
            this.cbAuthType.Name = "cbAuthType";
            this.cbAuthType.Size = new System.Drawing.Size(191, 20);
            this.cbAuthType.TabIndex = 13;
            this.cbAuthType.SelectedIndexChanged += new System.EventHandler(this.cbAuthType_SelectedIndexChanged);
            // 
            // labAuth
            // 
            this.labAuth.AutoSize = true;
            this.labAuth.Location = new System.Drawing.Point(10, 51);
            this.labAuth.Name = "labAuth";
            this.labAuth.Size = new System.Drawing.Size(65, 12);
            this.labAuth.TabIndex = 14;
            this.labAuth.Text = "驗證方式：";
            // 
            // chkUseLocalDB
            // 
            this.chkUseLocalDB.AutoSize = true;
            this.chkUseLocalDB.Location = new System.Drawing.Point(200, 194);
            this.chkUseLocalDB.Name = "chkUseLocalDB";
            this.chkUseLocalDB.Size = new System.Drawing.Size(93, 16);
            this.chkUseLocalDB.TabIndex = 15;
            this.chkUseLocalDB.Text = "使用 LocalDB";
            this.chkUseLocalDB.UseVisualStyleBackColor = true;
            this.chkUseLocalDB.CheckedChanged += new System.EventHandler(this.chkUseLocalDB_CheckedChanged);
            // 
            // ConnectionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 285);
            this.Controls.Add(this.chkUseLocalDB);
            this.Controls.Add(this.labAuth);
            this.Controls.Add(this.cbAuthType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkSetDefault);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbInitialCatalog);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbServer);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConnectionWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "連線視窗";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.ComboBox cbServer;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbInitialCatalog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkSetDefault;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbAuthType;
        private System.Windows.Forms.Label labAuth;
        private System.Windows.Forms.CheckBox chkUseLocalDB;
    }
}