namespace WarMan
{
    partial class SeviyeBilgiForm
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
            panel1 = new Panel();
            lblbitis = new Label();
            lblskor = new Label();
            lblKalanCan = new Label();
            lblGuncelSure = new Label();
            lblseviye = new Label();
            btnDevam = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSeaGreen;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(lblbitis);
            panel1.Controls.Add(lblskor);
            panel1.Controls.Add(lblKalanCan);
            panel1.Controls.Add(lblGuncelSure);
            panel1.Controls.Add(lblseviye);
            panel1.Controls.Add(btnDevam);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(798, 291);
            panel1.TabIndex = 0;
            // 
            // lblbitis
            // 
            lblbitis.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblbitis.AutoSize = true;
            lblbitis.BackColor = Color.Transparent;
            lblbitis.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblbitis.ForeColor = Color.White;
            lblbitis.ImeMode = ImeMode.NoControl;
            lblbitis.Location = new Point(246, 102);
            lblbitis.Name = "lblbitis";
            lblbitis.Size = new Size(58, 28);
            lblbitis.TabIndex = 37;
            lblbitis.Text = "bitis";
            // 
            // lblskor
            // 
            lblskor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblskor.AutoSize = true;
            lblskor.BackColor = Color.Transparent;
            lblskor.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblskor.ForeColor = Color.White;
            lblskor.ImeMode = ImeMode.NoControl;
            lblskor.Location = new Point(509, 185);
            lblskor.Name = "lblskor";
            lblskor.Size = new Size(60, 28);
            lblskor.TabIndex = 36;
            lblskor.Text = "skor";
            // 
            // lblKalanCan
            // 
            lblKalanCan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblKalanCan.AutoSize = true;
            lblKalanCan.BackColor = Color.Transparent;
            lblKalanCan.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblKalanCan.ForeColor = Color.White;
            lblKalanCan.ImeMode = ImeMode.NoControl;
            lblKalanCan.Location = new Point(6, 185);
            lblKalanCan.Name = "lblKalanCan";
            lblKalanCan.Size = new Size(135, 28);
            lblKalanCan.TabIndex = 35;
            lblKalanCan.Text = "Kalan Can";
            // 
            // lblGuncelSure
            // 
            lblGuncelSure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblGuncelSure.AutoSize = true;
            lblGuncelSure.BackColor = Color.Transparent;
            lblGuncelSure.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblGuncelSure.ForeColor = Color.White;
            lblGuncelSure.ImeMode = ImeMode.NoControl;
            lblGuncelSure.Location = new Point(256, 185);
            lblGuncelSure.Name = "lblGuncelSure";
            lblGuncelSure.Size = new Size(61, 28);
            lblGuncelSure.TabIndex = 34;
            lblGuncelSure.Text = "Sure";
            // 
            // lblseviye
            // 
            lblseviye.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblseviye.AutoSize = true;
            lblseviye.BackColor = Color.Transparent;
            lblseviye.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblseviye.ForeColor = Color.White;
            lblseviye.ImeMode = ImeMode.NoControl;
            lblseviye.Location = new Point(6, 24);
            lblseviye.Name = "lblseviye";
            lblseviye.Size = new Size(87, 28);
            lblseviye.TabIndex = 32;
            lblseviye.Text = "Seviye";
            lblseviye.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDevam
            // 
            btnDevam.FlatStyle = FlatStyle.Flat;
            btnDevam.Location = new Point(600, 227);
            btnDevam.Name = "btnDevam";
            btnDevam.Size = new Size(186, 50);
            btnDevam.TabIndex = 0;
            btnDevam.Text = "Tamam";
            btnDevam.UseVisualStyleBackColor = true;
            btnDevam.Click += btnDevam_Click;
            // 
            // SeviyeBilgiForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 290);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SeviyeBilgiForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SeviyeBilgiForm";
            Load += SeviyeBilgiForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnDevam;
        private Label lblGuncelSure;
        private Label lblseviye;
        private Label lblKalanCan;
        private Label lblskor;
        private Label lblbitis;
    }
}