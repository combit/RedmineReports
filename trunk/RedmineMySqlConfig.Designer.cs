namespace combit.RedmineReports
{
    partial class RedmineMySqlConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedmineMySqlConfig));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mySQLPasssTextBox = new System.Windows.Forms.TextBox();
            this.mySQLLogTextBox = new System.Windows.Forms.TextBox();
            this.dbNameTextBox = new System.Windows.Forms.TextBox();
            this.encryptData = new System.Windows.Forms.CheckBox();
            this.ipAddressTextBox = new System.Windows.Forms.TextBox();
            this.checkConfButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 169);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type Redmine MySQL configuration";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.mySQLPasssTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.mySQLLogTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dbNameTextBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.encryptData, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.ipAddressTextBox, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(454, 135);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 110);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Encrypt configuration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Database name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "MySQL Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "MySQL Login:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP Address:";
            // 
            // mySQLPasssTextBox
            // 
            this.mySQLPasssTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mySQLPasssTextBox.Location = new System.Drawing.Point(116, 55);
            this.mySQLPasssTextBox.Name = "mySQLPasssTextBox";
            this.mySQLPasssTextBox.PasswordChar = '*';
            this.mySQLPasssTextBox.ShortcutsEnabled = false;
            this.mySQLPasssTextBox.Size = new System.Drawing.Size(335, 20);
            this.mySQLPasssTextBox.TabIndex = 11;
            this.mySQLPasssTextBox.UseSystemPasswordChar = true;
            this.mySQLPasssTextBox.Enter += new System.EventHandler(this.DisableSaveButton);
            // 
            // mySQLLogTextBox
            // 
            this.mySQLLogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mySQLLogTextBox.Location = new System.Drawing.Point(116, 29);
            this.mySQLLogTextBox.Name = "mySQLLogTextBox";
            this.mySQLLogTextBox.Size = new System.Drawing.Size(335, 20);
            this.mySQLLogTextBox.TabIndex = 10;
            this.mySQLLogTextBox.Enter += new System.EventHandler(this.DisableSaveButton);
            // 
            // dbNameTextBox
            // 
            this.dbNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dbNameTextBox.Location = new System.Drawing.Point(116, 81);
            this.dbNameTextBox.Name = "dbNameTextBox";
            this.dbNameTextBox.Size = new System.Drawing.Size(335, 20);
            this.dbNameTextBox.TabIndex = 12;
            this.dbNameTextBox.Enter += new System.EventHandler(this.DisableSaveButton);
            // 
            // encryptData
            // 
            this.encryptData.AutoSize = true;
            this.encryptData.Location = new System.Drawing.Point(119, 110);
            this.encryptData.Margin = new System.Windows.Forms.Padding(6);
            this.encryptData.Name = "encryptData";
            this.encryptData.Size = new System.Drawing.Size(15, 14);
            this.encryptData.TabIndex = 14;
            this.encryptData.UseVisualStyleBackColor = true;
            this.encryptData.Enter += new System.EventHandler(this.DisableSaveButton);
            // 
            // ipAddressTextBox
            // 
            this.ipAddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ipAddressTextBox.Location = new System.Drawing.Point(116, 3);
            this.ipAddressTextBox.Name = "ipAddressTextBox";
            this.ipAddressTextBox.Size = new System.Drawing.Size(335, 20);
            this.ipAddressTextBox.TabIndex = 9;
            this.ipAddressTextBox.Enter += new System.EventHandler(this.DisableSaveButton);
            // 
            // checkConfButton
            // 
            this.checkConfButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkConfButton.Location = new System.Drawing.Point(246, 189);
            this.checkConfButton.Name = "checkConfButton";
            this.checkConfButton.Size = new System.Drawing.Size(91, 23);
            this.checkConfButton.TabIndex = 0;
            this.checkConfButton.Text = "Check config";
            this.checkConfButton.UseVisualStyleBackColor = true;
            this.checkConfButton.Click += new System.EventHandler(this.checkConfButton_Click);
            this.checkConfButton.Enter += new System.EventHandler(this.DisableSaveButton);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(218, 187);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(10, 15, 3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 25);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Enabled = false;
            this.saveButton.Location = new System.Drawing.Point(413, 189);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(67, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "OK";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(343, 189);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(66, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click_1);
            // 
            // RedmineMySqlConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(492, 227);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkConfButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RedmineMySqlConfig";
            this.Text = "RedmineMySqlConfig";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox mySQLPasssTextBox;
        private System.Windows.Forms.TextBox mySQLLogTextBox;
        private System.Windows.Forms.TextBox dbNameTextBox;
        private System.Windows.Forms.CheckBox encryptData;
        private System.Windows.Forms.Button checkConfButton;
        private System.Windows.Forms.TextBox ipAddressTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}