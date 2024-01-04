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
            skorlarGV = new DataGridView();
            button1 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)skorlarGV).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(skorlarGV);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(1, 0);
            panel1.Margin = new Padding(2, 3, 2, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(470, 260);
            panel1.TabIndex = 0;
            // 
            // skorlarGV
            // 
            skorlarGV.AllowUserToAddRows = false;
            skorlarGV.AllowUserToDeleteRows = false;
            skorlarGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            skorlarGV.Location = new Point(9, 10);
            skorlarGV.Name = "skorlarGV";
            skorlarGV.ReadOnly = true;
            skorlarGV.RowTemplate.Height = 25;
            skorlarGV.Size = new Size(447, 185);
            skorlarGV.TabIndex = 0;
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
            ClientSize = new Size(471, 260);
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
            ((System.ComponentModel.ISupportInitialize)skorlarGV).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private DataGridView skorlarGV;
    }
}