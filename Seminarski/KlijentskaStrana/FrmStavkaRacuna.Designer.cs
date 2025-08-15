namespace KlijentskaStrana
{
    partial class FrmStavkaRacuna
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
            btnIzmeniStavku = new Button();
            btnObrisi = new Button();
            btnDodaj = new Button();
            cmbFilm = new ComboBox();
            label7 = new Label();
            txtCena = new TextBox();
            label6 = new Label();
            txtOpis = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // btnIzmeniStavku
            // 
            btnIzmeniStavku.Location = new Point(387, 123);
            btnIzmeniStavku.Name = "btnIzmeniStavku";
            btnIzmeniStavku.Size = new Size(128, 29);
            btnIzmeniStavku.TabIndex = 40;
            btnIzmeniStavku.Text = "Izmeni Stavku";
            btnIzmeniStavku.UseVisualStyleBackColor = true;
            btnIzmeniStavku.Click += btnIzmeniStavku_Click;
            // 
            // btnObrisi
            // 
            btnObrisi.Location = new Point(197, 123);
            btnObrisi.Name = "btnObrisi";
            btnObrisi.Size = new Size(110, 27);
            btnObrisi.TabIndex = 39;
            btnObrisi.Text = "Obriši stavku";
            btnObrisi.UseVisualStyleBackColor = true;
            btnObrisi.Click += btnObrisi_Click;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(33, 121);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(110, 29);
            btnDodaj.TabIndex = 38;
            btnDodaj.Text = "Dodaj stavku";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // cmbFilm
            // 
            cmbFilm.FormattingEnabled = true;
            cmbFilm.Location = new Point(387, 67);
            cmbFilm.Name = "cmbFilm";
            cmbFilm.Size = new Size(128, 28);
            cmbFilm.TabIndex = 37;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(421, 44);
            label7.Name = "label7";
            label7.Size = new Size(37, 20);
            label7.TabIndex = 36;
            label7.Text = "Film";
            // 
            // txtCena
            // 
            txtCena.Location = new Point(215, 68);
            txtCena.Name = "txtCena";
            txtCena.Size = new Size(92, 27);
            txtCena.TabIndex = 35;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(234, 45);
            label6.Name = "label6";
            label6.Size = new Size(42, 20);
            label6.TabIndex = 34;
            label6.Text = "Cena";
            // 
            // txtOpis
            // 
            txtOpis.Location = new Point(33, 68);
            txtOpis.Name = "txtOpis";
            txtOpis.Size = new Size(92, 27);
            txtOpis.TabIndex = 33;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(52, 45);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 32;
            label5.Text = "Opis";
            // 
            // FrmStavkaRacuna
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnIzmeniStavku);
            Controls.Add(btnObrisi);
            Controls.Add(btnDodaj);
            Controls.Add(cmbFilm);
            Controls.Add(label7);
            Controls.Add(txtCena);
            Controls.Add(label6);
            Controls.Add(txtOpis);
            Controls.Add(label5);
            Name = "FrmStavkaRacuna";
            Text = "FrmStavkaRacuna";
            
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIzmeniStavku;
        private Button btnObrisi;
        private Button btnDodaj;
        private ComboBox cmbFilm;
        private Label label7;
        private TextBox txtCena;
        private Label label6;
        private TextBox txtOpis;
        private Label label5;
    }
}