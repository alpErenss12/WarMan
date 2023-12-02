namespace WarMan
{
    partial class Duraklat
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
            label1 = new Label();
            btnDevamet = new Button();
            btnRestart = new Button();
            btnAnamenu = new Button();
            btnOyundancik = new Button();
            btnshowcontrols = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(73, 22);
            label1.Name = "label1";
            label1.Size = new Size(179, 30);
            label1.TabIndex = 0;
            label1.Text = "Oyun Duraklatıldı";
            // 
            // btnDevamet
            // 
            btnDevamet.FlatAppearance.BorderColor = Color.White;
            btnDevamet.FlatAppearance.BorderSize = 2;
            btnDevamet.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnDevamet.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnDevamet.FlatStyle = FlatStyle.Flat;
            btnDevamet.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnDevamet.ForeColor = Color.White;
            btnDevamet.Location = new Point(30, 84);
            btnDevamet.Name = "btnDevamet";
            btnDevamet.Size = new Size(265, 51);
            btnDevamet.TabIndex = 1;
            btnDevamet.Text = "Devam Et";
            btnDevamet.UseVisualStyleBackColor = true;
            btnDevamet.Click += btnDevamet_Click;
            // 
            // btnRestart
            // 
            btnRestart.FlatAppearance.BorderColor = Color.White;
            btnRestart.FlatAppearance.BorderSize = 2;
            btnRestart.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnRestart.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnRestart.FlatStyle = FlatStyle.Flat;
            btnRestart.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRestart.ForeColor = Color.White;
            btnRestart.Location = new Point(30, 141);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(265, 51);
            btnRestart.TabIndex = 2;
            btnRestart.Text = "Yeniden Başlat";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // btnAnamenu
            // 
            btnAnamenu.FlatAppearance.BorderColor = Color.White;
            btnAnamenu.FlatAppearance.BorderSize = 2;
            btnAnamenu.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnAnamenu.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnAnamenu.FlatStyle = FlatStyle.Flat;
            btnAnamenu.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAnamenu.ForeColor = Color.White;
            btnAnamenu.Location = new Point(30, 198);
            btnAnamenu.Name = "btnAnamenu";
            btnAnamenu.Size = new Size(265, 51);
            btnAnamenu.TabIndex = 3;
            btnAnamenu.Text = "Ana menüye dön";
            btnAnamenu.UseVisualStyleBackColor = true;
            btnAnamenu.Click += btnAnamenu_Click;
            // 
            // btnOyundancik
            // 
            btnOyundancik.FlatAppearance.BorderColor = Color.White;
            btnOyundancik.FlatAppearance.BorderSize = 2;
            btnOyundancik.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnOyundancik.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnOyundancik.FlatStyle = FlatStyle.Flat;
            btnOyundancik.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnOyundancik.ForeColor = Color.White;
            btnOyundancik.Location = new Point(30, 312);
            btnOyundancik.Name = "btnOyundancik";
            btnOyundancik.Size = new Size(265, 51);
            btnOyundancik.TabIndex = 4;
            btnOyundancik.Text = "Oyundan Çık";
            btnOyundancik.UseVisualStyleBackColor = true;
            btnOyundancik.Click += btnOyundancik_Click;
            // 
            // btnshowcontrols
            // 
            btnshowcontrols.FlatAppearance.BorderColor = Color.White;
            btnshowcontrols.FlatAppearance.BorderSize = 2;
            btnshowcontrols.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnshowcontrols.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnshowcontrols.FlatStyle = FlatStyle.Flat;
            btnshowcontrols.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnshowcontrols.ForeColor = Color.White;
            btnshowcontrols.Location = new Point(30, 255);
            btnshowcontrols.Name = "btnshowcontrols";
            btnshowcontrols.Size = new Size(265, 51);
            btnshowcontrols.TabIndex = 5;
            btnshowcontrols.Text = "Kontrolleri gör";
            btnshowcontrols.UseVisualStyleBackColor = true;
            btnshowcontrols.Click += btnshowcontrols_Click;
            // 
            // Duraklat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(323, 393);
            Controls.Add(btnshowcontrols);
            Controls.Add(btnOyundancik);
            Controls.Add(btnAnamenu);
            Controls.Add(btnRestart);
            Controls.Add(btnDevamet);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Duraklat";
            Opacity = 0.8D;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Duraklat";
            KeyDown += Duraklat_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnDevamet;
        private Button btnRestart;
        private Button btnAnamenu;
        private Button btnOyundancik;
        private Button btnshowcontrols;
    }
}