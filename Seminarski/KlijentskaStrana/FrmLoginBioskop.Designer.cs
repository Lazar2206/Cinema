namespace KlijentskaStrana
{
    partial class FrmLoginBioskop
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
            label2 = new Label();
            txtKorisničkoIme = new TextBox();
            txtLozinka = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(88, 52);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 0;
            label1.Text = "Korisničko ime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(122, 98);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 1;
            label2.Text = "Lozinka:";
            // 
            // txtKorisničkoIme
            // 
            txtKorisničkoIme.Location = new Point(207, 45);
            txtKorisničkoIme.Name = "txtKorisničkoIme";
            txtKorisničkoIme.Size = new Size(125, 27);
            txtKorisničkoIme.TabIndex = 2;
            // 
            // txtLozinka
            // 
            txtLozinka.Location = new Point(207, 95);
            txtLozinka.Name = "txtLozinka";
            txtLozinka.Size = new Size(125, 27);
            txtLozinka.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(207, 148);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // FrmLoginBioskop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogin);
            Controls.Add(txtLozinka);
            Controls.Add(txtKorisničkoIme);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmLoginBioskop";
            Text = "FrmLoginBioskop";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtKorisničkoIme;
        private TextBox txtLozinka;
        private Button btnLogin;
    }
}