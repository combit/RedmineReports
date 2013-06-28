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
            System.Windows.Forms.Button btnPrint;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedmineReportsForm));
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.btnDesign = new System.Windows.Forms.Button();
            this.lboxVersion = new System.Windows.Forms.ListBox();
            this.tbStartDate = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbAllProjects = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbTimespan = new System.Windows.Forms.RadioButton();
            this.rbDateRange = new System.Windows.Forms.RadioButton();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redmineDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            resources.ApplyResources(btnPrint, "btnPrint");
            btnPrint.Name = "btnPrint";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // Label2
            // 
            resources.ApplyResources(this.Label2, "Label2");
            this.Label2.Name = "Label2";
            // 
            // Label1
            // 
            resources.ApplyResources(this.Label1, "Label1");
            this.Label1.Name = "Label1";
            // 
            // cmbProject
            // 
            resources.ApplyResources(this.cmbProject, "cmbProject");
            this.cmbProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // btnDesign
            // 
            resources.ApplyResources(this.btnDesign, "btnDesign");
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.UseVisualStyleBackColor = true;
            this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
            // 
            // lboxVersion
            // 
            resources.ApplyResources(this.lboxVersion, "lboxVersion");
            this.lboxVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(220)))));
            this.lboxVersion.FormattingEnabled = true;
            this.lboxVersion.Name = "lboxVersion";
            this.lboxVersion.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // tbStartDate
            // 
            resources.ApplyResources(this.tbStartDate, "tbStartDate");
            this.tbStartDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(246)))), ((int)(((byte)(220)))));
            this.tbStartDate.Name = "tbStartDate";
            this.tbStartDate.TextChanged += new System.EventHandler(this.tbStartDate_TextChanged);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(233)))));
            this.pictureBox1.Image = global::combit.RedmineReports.Properties.Resources.Powered_by_LL;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbAllProjects);
            this.groupBox1.Controls.Add(this.cmbProject);
            this.groupBox1.Controls.Add(this.Label1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cbAllProjects
            // 
            resources.ApplyResources(this.cbAllProjects, "cbAllProjects");
            this.cbAllProjects.Name = "cbAllProjects";
            this.cbAllProjects.UseVisualStyleBackColor = true;
            this.cbAllProjects.CheckedChanged += new System.EventHandler(this.cbAllProjects_CheckedChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // rbTimespan
            // 
            resources.ApplyResources(this.rbTimespan, "rbTimespan");
            this.rbTimespan.Checked = true;
            this.rbTimespan.Name = "rbTimespan";
            this.rbTimespan.TabStop = true;
            this.rbTimespan.UseVisualStyleBackColor = true;
            this.rbTimespan.CheckedChanged += new System.EventHandler(this.rbTimespan_CheckedChanged);
            // 
            // rbDateRange
            // 
            resources.ApplyResources(this.rbDateRange, "rbDateRange");
            this.rbDateRange.Name = "rbDateRange";
            this.rbDateRange.UseVisualStyleBackColor = true;
            // 
            // dtpFromDate
            // 
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Name = "dtpFromDate";
            // 
            // dtpToDate
            // 
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Name = "dtpToDate";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configurationToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redmineDBToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            resources.ApplyResources(this.configurationToolStripMenuItem, "configurationToolStripMenuItem");
            // 
            // redmineDBToolStripMenuItem
            // 
            this.redmineDBToolStripMenuItem.Name = "redmineDBToolStripMenuItem";
            resources.ApplyResources(this.redmineDBToolStripMenuItem, "redmineDBToolStripMenuItem");
            this.redmineDBToolStripMenuItem.Click += new System.EventHandler(this.redmineDBToolStripMenuItem_Click);
            // 
            // RedmineReportsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.rbDateRange);
            this.Controls.Add(this.rbTimespan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(btnPrint);
            this.Controls.Add(this.tbStartDate);
            this.Controls.Add(this.lboxVersion);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.btnDesign);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RedmineReportsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbAllProjects;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbTimespan;
        private System.Windows.Forms.RadioButton rbDateRange;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redmineDBToolStripMenuItem;
    }
}

