namespace WarMan
{
    partial class StartScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartScreen));
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            panel1 = new Panel();
            label7 = new Label();
            label6 = new Label();
            label3 = new Label();
            PBBestScores = new PictureBox();
            label2 = new Label();
            PBinfo = new PictureBox();
            label1 = new Label();
            lblwarning = new Label();
            label5 = new Label();
            label4 = new Label();
            txtGamerName = new TextBox();
            btnCikis = new Button();
            btnPlay = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PBBestScores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PBinfo).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            resources.ApplyResources(pictureBox2, "pictureBox2");
            pictureBox2.Name = "pictureBox2";
            pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(panel1, "panel1");
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(PBBestScores);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(PBinfo);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox2);
            panel1.ForeColor = Color.White;
            panel1.Name = "panel1";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // PBBestScores
            // 
            PBBestScores.Cursor = Cursors.Hand;
            resources.ApplyResources(PBBestScores, "PBBestScores");
            PBBestScores.Name = "PBBestScores";
            PBBestScores.TabStop = false;
            PBBestScores.Click += PBBestScores_Click;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // PBinfo
            // 
            PBinfo.Cursor = Cursors.Hand;
            resources.ApplyResources(PBinfo, "PBinfo");
            PBinfo.Name = "PBinfo";
            PBinfo.TabStop = false;
            PBinfo.MouseClick += PBinfo_MouseClick;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // lblwarning
            // 
            resources.ApplyResources(lblwarning, "lblwarning");
            lblwarning.BackColor = Color.Transparent;
            lblwarning.ForeColor = Color.Red;
            lblwarning.Name = "lblwarning";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.BackColor = Color.Transparent;
            label5.ForeColor = Color.White;
            label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.White;
            label4.Name = "label4";
            // 
            // txtGamerName
            // 
            resources.ApplyResources(txtGamerName, "txtGamerName");
            txtGamerName.Name = "txtGamerName";
            txtGamerName.Enter += txtGamerName_Enter;
            txtGamerName.Leave += txtGamerName_Leave;
            // 
            // btnCikis
            // 
            btnCikis.BackColor = Color.Gray;
            btnCikis.FlatAppearance.BorderSize = 2;
            btnCikis.FlatAppearance.MouseOverBackColor = Color.Silver;
            resources.ApplyResources(btnCikis, "btnCikis");
            btnCikis.ForeColor = Color.White;
            btnCikis.Name = "btnCikis";
            btnCikis.UseVisualStyleBackColor = false;
            btnCikis.Click += btnCikis_Click;
            // 
            // btnPlay
            // 
            btnPlay.BackColor = Color.Gray;
            btnPlay.FlatAppearance.BorderSize = 2;
            btnPlay.FlatAppearance.MouseOverBackColor = Color.Silver;
            resources.ApplyResources(btnPlay, "btnPlay");
            btnPlay.ForeColor = Color.White;
            btnPlay.Name = "btnPlay";
            btnPlay.UseVisualStyleBackColor = false;
            btnPlay.Click += btnPlay_Click;
            // 
            // StartScreen
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.MidnightBlue;
            resources.ApplyResources(this, "$this");
            CausesValidation = false;
            Controls.Add(btnPlay);
            Controls.Add(btnCikis);
            Controls.Add(txtGamerName);
            Controls.Add(panel1);
            Controls.Add(label5);
            Controls.Add(pictureBox1);
            Controls.Add(lblwarning);
            Controls.Add(label4);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "StartScreen";
            FormClosed += StartScreen_FormClosed;
            Load += StartScreen_Load;
            KeyDown += StartScreen_KeyDown;
            KeyPress += StartScreen_KeyPress;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PBBestScores).EndInit();
            ((System.ComponentModel.ISupportInitialize)PBinfo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Panel panel1;
        private PictureBox PBinfo;
        private Label label1;
        private Label label2;
        private PictureBox PBBestScores;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label lblwarning;
        private Label label6;
        private Label label7;
        private TextBox txtGamerName;
        private Button btnCikis;
        private Button btnPlay;
    }
}