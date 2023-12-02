namespace WarMan
{
    partial class scores
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
            panel2 = new Panel();
            skorTablosu = new TableLayoutPanel();
            button1 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(1, 0);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(197, 260);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(skorTablosu);
            panel2.Location = new Point(8, 10);
            panel2.Margin = new Padding(2, 3, 2, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(175, 186);
            panel2.TabIndex = 1;
            // 
            // skorTablosu
            // 
            skorTablosu.ColumnCount = 2;
            skorTablosu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            skorTablosu.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            skorTablosu.Location = new Point(3, 3);
            skorTablosu.Name = "skorTablosu";
            skorTablosu.RowCount = 5;
            skorTablosu.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            skorTablosu.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            skorTablosu.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            skorTablosu.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            skorTablosu.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            skorTablosu.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            skorTablosu.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            skorTablosu.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            skorTablosu.Size = new Size(167, 178);
            skorTablosu.TabIndex = 0;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(8, 211);
            button1.Margin = new Padding(2, 3, 2, 3);
            button1.Name = "button1";
            button1.Size = new Size(174, 33);
            button1.TabIndex = 0;
            button1.Text = "Tamam";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // scores
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.LightSeaGreen;
            ClientSize = new Size(198, 260);
            ControlBox = false;
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Margin = new Padding(2, 3, 2, 3);
            Name = "scores";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "scores";
            KeyDown += scores_KeyDown;
            KeyPress += scores_KeyPress;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button button1;
        private TableLayoutPanel skorTablosu;
    }
}