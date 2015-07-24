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
            this.lboxVersion = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBox_All_Trackers = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpBoxTimespan = new System.Windows.Forms.GroupBox();
            this.numUpDoStartDate = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.rbDays = new System.Windows.Forms.RadioButton();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.rbDateRange = new System.Windows.Forms.RadioButton();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lstbProjects = new System.Windows.Forms.ListBox();
            this.lstbTrackers = new System.Windows.Forms.ListBox();
            this.chkBox_SelectAll = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbAllProjects = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redmineDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnDesign = new System.Windows.Forms.Button();
            btnPrint = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.grpBoxTimespan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDoStartDate)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            resources.ApplyResources(btnPrint, "btnPrint");
            btnPrint.Image = global::combit.RedmineReports.Properties.Resources.report;
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
            // lboxVersion
            // 
            this.lboxVersion.BackColor = System.Drawing.Color.White;
            this.lboxVersion.FormattingEnabled = true;
            resources.ApplyResources(this.lboxVersion, "lboxVersion");
            this.lboxVersion.Name = "lboxVersion";
            this.lboxVersion.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBox_All_Trackers);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.grpBoxTimespan);
            this.groupBox1.Controls.Add(this.lstbProjects);
            this.groupBox1.Controls.Add(this.lstbTrackers);
            this.groupBox1.Controls.Add(this.chkBox_SelectAll);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbAllProjects);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Controls.Add(this.lboxVersion);
            this.groupBox1.Controls.Add(this.Label2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // chkBox_All_Trackers
            // 
            resources.ApplyResources(this.chkBox_All_Trackers, "chkBox_All_Trackers");
            this.chkBox_All_Trackers.Name = "chkBox_All_Trackers";
            this.chkBox_All_Trackers.UseVisualStyleBackColor = true;
            this.chkBox_All_Trackers.CheckedChanged += new System.EventHandler(this.chkBox_All_Trackers_CheckedChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Name = "label4";
            // 
            // grpBoxTimespan
            // 
            this.grpBoxTimespan.Controls.Add(this.numUpDoStartDate);
            this.grpBoxTimespan.Controls.Add(this.label6);
            this.grpBoxTimespan.Controls.Add(this.rbDays);
            this.grpBoxTimespan.Controls.Add(this.dtpFromDate);
            this.grpBoxTimespan.Controls.Add(this.label5);
            this.grpBoxTimespan.Controls.Add(this.rbDateRange);
            this.grpBoxTimespan.Controls.Add(this.dtpToDate);
            resources.ApplyResources(this.grpBoxTimespan, "grpBoxTimespan");
            this.grpBoxTimespan.Name = "grpBoxTimespan";
            this.grpBoxTimespan.TabStop = false;
            // 
            // numUpDoStartDate
            // 
            this.numUpDoStartDate.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.numUpDoStartDate, "numUpDoStartDate");
            this.numUpDoStartDate.Name = "numUpDoStartDate";
            this.numUpDoStartDate.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label6.Name = "label6";
            // 
            // rbDays
            // 
            resources.ApplyResources(this.rbDays, "rbDays");
            this.rbDays.Checked = true;
            this.rbDays.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbDays.Name = "rbDays";
            this.rbDays.TabStop = true;
            this.rbDays.UseVisualStyleBackColor = true;
            this.rbDays.CheckedChanged += new System.EventHandler(this.rbDays_CheckedChanged);
            // 
            // dtpFromDate
            // 
            resources.ApplyResources(this.dtpFromDate, "dtpFromDate");
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Name = "dtpFromDate";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Name = "label5";
            // 
            // rbDateRange
            // 
            resources.ApplyResources(this.rbDateRange, "rbDateRange");
            this.rbDateRange.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rbDateRange.Name = "rbDateRange";
            this.rbDateRange.UseVisualStyleBackColor = true;
            // 
            // dtpToDate
            // 
            resources.ApplyResources(this.dtpToDate, "dtpToDate");
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Name = "dtpToDate";
            // 
            // lstbProjects
            // 
            this.lstbProjects.FormattingEnabled = true;
            resources.ApplyResources(this.lstbProjects, "lstbProjects");
            this.lstbProjects.Name = "lstbProjects";
            this.lstbProjects.SelectedIndexChanged += new System.EventHandler(this.lstbProjects_SelectedIndexChanged);
            // 
            // lstbTrackers
            // 
            this.lstbTrackers.FormattingEnabled = true;
            resources.ApplyResources(this.lstbTrackers, "lstbTrackers");
            this.lstbTrackers.Name = "lstbTrackers";
            this.lstbTrackers.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            // 
            // chkBox_SelectAll
            // 
            resources.ApplyResources(this.chkBox_SelectAll, "chkBox_SelectAll");
            this.chkBox_SelectAll.Name = "chkBox_SelectAll";
            this.chkBox_SelectAll.UseVisualStyleBackColor = true;
            this.chkBox_SelectAll.CheckedChanged += new System.EventHandler(this.chkBox_SelectAll_CheckedChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cbAllProjects
            // 
            resources.ApplyResources(this.cbAllProjects, "cbAllProjects");
            this.cbAllProjects.Name = "cbAllProjects";
            this.cbAllProjects.UseVisualStyleBackColor = true;
            this.cbAllProjects.CheckedChanged += new System.EventHandler(this.cbAllProjects_CheckedChanged);
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::combit.RedmineReports.Properties.Resources.RR_Logo;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::combit.RedmineReports.Properties.Resources.RR_LL_Logo;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // btnDesign
            // 
            resources.ApplyResources(this.btnDesign, "btnDesign");
            this.btnDesign.Image = global::combit.RedmineReports.Properties.Resources.design;
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.UseVisualStyleBackColor = true;
            this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
            // 
            // RedmineReportsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(btnPrint);
            this.Controls.Add(this.btnDesign);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RedmineReportsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RedmineReportsForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpBoxTimespan.ResumeLayout(false);
            this.grpBoxTimespan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDoStartDate)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnDesign;
        private System.Windows.Forms.ListBox lboxVersion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbAllProjects;
        private System.Windows.Forms.RadioButton rbDateRange;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redmineDBToolStripMenuItem;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstbTrackers;
        private System.Windows.Forms.CheckBox chkBox_SelectAll;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ListBox lstbProjects;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grpBoxTimespan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkBox_All_Trackers;
        private System.Windows.Forms.RadioButton rbDays;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.NumericUpDown numUpDoStartDate;
    }

}

