namespace KlijentskaStrana
{
    partial class FrmBioskop
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
            label3 = new Label();
            dgvBioskopi = new DataGridView();
            txtNazivBioskopa = new TextBox();
            btnGlavna = new Button();
            btnDodaj = new Button();
            label1 = new Label();
            txtAdresaBioskopa = new TextBox();
            label2 = new Label();
            txtKorisničkoIme = new TextBox();
            label4 = new Label();
            txtŠifra = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvBioskopi).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 17);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 25;
            label3.Text = "Naziv ";
            // 
            // dgvBioskopi
            // 
            dgvBioskopi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBioskopi.Location = new Point(41, 166);
            dgvBioskopi.Name = "dgvBioskopi";
            dgvBioskopi.RowHeadersWidth = 51;
            dgvBioskopi.Size = new Size(517, 274);
            dgvBioskopi.TabIndex = 19;
            // 
            // txtNazivBioskopa
            // 
            txtNazivBioskopa.Location = new Point(56, 40);
            txtNazivBioskopa.Name = "txtNazivBioskopa";
            txtNazivBioskopa.Size = new Size(125, 27);
            txtNazivBioskopa.TabIndex = 18;
            // 
            // btnGlavna
            // 
            btnGlavna.Location = new Point(666, 387);
            btnGlavna.Name = "btnGlavna";
            btnGlavna.Size = new Size(94, 29);
            btnGlavna.TabIndex = 17;
            btnGlavna.Text = "Glavna";
            btnGlavna.UseVisualStyleBackColor = true;
            btnGlavna.Click += btnGlavna_Click;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(666, 70);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(94, 29);
            btnDodaj.TabIndex = 16;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(354, 17);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 27;
            label1.Text = "Adresa";
            // 
            // txtAdresaBioskopa
            // 
            txtAdresaBioskopa.Location = new Point(320, 40);
            txtAdresaBioskopa.Name = "txtAdresaBioskopa";
            txtAdresaBioskopa.Size = new Size(125, 27);
            txtAdresaBioskopa.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 87);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 29;
            label2.Text = "Korisničko ime";
            // 
            // txtKorisničkoIme
            // 
            txtKorisničkoIme.Location = new Point(56, 110);
            txtKorisničkoIme.Name = "txtKorisničkoIme";
            txtKorisničkoIme.Size = new Size(125, 27);
            txtKorisničkoIme.TabIndex = 28;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(354, 87);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 31;
            label4.Text = "Šifra ";
            // 
            // txtŠifra
            // 
            txtŠifra.Location = new Point(320, 110);
            txtŠifra.Name = "txtŠifra";
            txtŠifra.Size = new Size(125, 27);
            txtŠifra.TabIndex = 30;
            // 
            // FrmBioskop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(txtŠifra);
            Controls.Add(label2);
            Controls.Add(txtKorisničkoIme);
            Controls.Add(label1);
            Controls.Add(txtAdresaBioskopa);
            Controls.Add(label3);
            Controls.Add(dgvBioskopi);
            Controls.Add(txtNazivBioskopa);
            Controls.Add(btnGlavna);
            Controls.Add(btnDodaj);
            Name = "FrmBioskop";
            Text = "FrmBioskop";
            ((System.ComponentModel.ISupportInitialize)dgvBioskopi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private DataGridView dgvBioskopi;
        private TextBox txtNazivBioskopa;
        private Button btnGlavna;
        private Button btnDodaj;
        private Label label1;
        private TextBox txtAdresaBioskopa;
        private Label label2;
        private TextBox txtKorisničkoIme;
        private Label label4;
        private TextBox txtŠifra;
    }
}