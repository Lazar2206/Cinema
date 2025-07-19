namespace KlijentskaStrana
{
    partial class FrmPočetna
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
            btnBioskop = new Button();
            btnGledalac = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnBioskop
            // 
            btnBioskop.Location = new Point(242, 142);
            btnBioskop.Name = "btnBioskop";
            btnBioskop.Size = new Size(94, 29);
            btnBioskop.TabIndex = 0;
            btnBioskop.Text = "Bioskop";
            btnBioskop.UseVisualStyleBackColor = true;
            btnBioskop.Click += btnBioskop_Click;
            // 
            // btnGledalac
            // 
            btnGledalac.Location = new Point(242, 234);
            btnGledalac.Name = "btnGledalac";
            btnGledalac.Size = new Size(94, 29);
            btnGledalac.TabIndex = 1;
            btnGledalac.Text = "Gledalac";
            btnGledalac.UseVisualStyleBackColor = true;
            btnGledalac.Click += btnGledalac_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(260, 64);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 2;
            label1.Text = "Vi ste?";
            // 
            // FrmPočetna
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnGledalac);
            Controls.Add(btnBioskop);
            Name = "FrmPočetna";
            Text = "FrmPočetna";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBioskop;
        private Button btnGledalac;
        private Label label1;
    }
}