namespace combit.RedmineReports
{
    partial class RedmineReportsForm
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
            if (disposing && (_dataAccess != null))
            {
                _dataAccess.Dispose();
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedmineReportsForm));
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.btnDesign = new System.Windows.Forms.Button();
            this.lboxVersion = new System.Windows.Forms.ListBox();
            this.tbStartDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(14, 59);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(94, 13);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "Choose version(s):";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(14, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(81, 13);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "Choose project:";
            // 
            // cmbProject
            // 
            this.cmbProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(11, 27);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(237, 21);
            this.cmbProject.TabIndex = 8;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // btnDesign
            // 
            this.btnDesign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDesign.Location = new System.Drawing.Point(11, 201);
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.Size = new System.Drawing.Size(100, 23);
            this.btnDesign.TabIndex = 7;
            this.btnDesign.Text = "&Design";
            this.btnDesign.UseVisualStyleBackColor = true;
            this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
            // 
            // lboxVersion
            // 
            this.lboxVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lboxVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(220)))));
            this.lboxVersion.FormattingEnabled = true;
            this.lboxVersion.Location = new System.Drawing.Point(11, 75);
            this.lboxVersion.Name = "lboxVersion";
            this.lboxVersion.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lboxVersion.Size = new System.Drawing.Size(237, 121);
            this.lboxVersion.TabIndex = 11;
            // 
            // tbStartDate
            // 
            this.tbStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbStartDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(220)))));
            this.tbStartDate.Location = new System.Drawing.Point(217, 202);
            this.tbStartDate.Name = "tbStartDate";
            this.tbStartDate.Size = new System.Drawing.Size(31, 20);
            this.tbStartDate.TabIndex = 12;
            this.tbStartDate.Text = "7";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Timespan (days):";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Location = new System.Drawing.Point(11, 230);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 23);
            this.btnPrint.TabIndex = 16;
            this.btnPrint.Text = "Create &Report";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.pictureBox1.Image = global::combit.RedmineReports.Properties.Resources.Powered_by_LL;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 272);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(261, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // RedmineReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(258, 347);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbStartDate);
            this.Controls.Add(this.lboxVersion);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.btnDesign);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RedmineReportsForm";
            this.Text = "RedmineReports";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox cmbProject;
        internal System.Windows.Forms.Button btnDesign;
        private System.Windows.Forms.ListBox lboxVersion;
        private System.Windows.Forms.TextBox tbStartDate;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

