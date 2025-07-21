namespace KlijentskaStrana
{
    partial class UcStavkaRacunacs
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmbFilm = new ComboBox();
            label7 = new Label();
            txtCena = new TextBox();
            label6 = new Label();
            txtOpis = new TextBox();
            label5 = new Label();
            btnDodaj = new Button();
            button1 = new Button();
            btnIzmeniStavku = new Button();
            SuspendLayout();
            // 
            // cmbFilm
            // 
            cmbFilm.FormattingEnabled = true;
            cmbFilm.Location = new Point(379, 79);
            cmbFilm.Name = "cmbFilm";
            cmbFilm.Size = new Size(128, 28);
            cmbFilm.TabIndex = 28;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(413, 56);
            label7.Name = "label7";
            label7.Size = new Size(37, 20);
            label7.TabIndex = 27;
            label7.Text = "Film";
            // 
            // txtCena
            // 
            txtCena.Location = new Point(207, 80);
            txtCena.Name = "txtCena";
            txtCena.Size = new Size(92, 27);
            txtCena.TabIndex = 26;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(226, 57);
            label6.Name = "label6";
            label6.Size = new Size(42, 20);
            label6.TabIndex = 25;
            label6.Text = "Cena";
            // 
            // txtOpis
            // 
            txtOpis.Location = new Point(25, 80);
            txtOpis.Name = "txtOpis";
            txtOpis.Size = new Size(92, 27);
            txtOpis.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 57);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 23;
            label5.Text = "Opis";
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(25, 133);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(110, 29);
            btnDodaj.TabIndex = 29;
            btnDodaj.Text = "Dodaj stavku";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // button1
            // 
            button1.Location = new Point(189, 135);
            button1.Name = "button1";
            button1.Size = new Size(110, 27);
            button1.TabIndex = 30;
            button1.Text = "Obriši stavku";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnIzmeniStavku
            // 
            btnIzmeniStavku.Location = new Point(379, 135);
            btnIzmeniStavku.Name = "btnIzmeniStavku";
            btnIzmeniStavku.Size = new Size(128, 29);
            btnIzmeniStavku.TabIndex = 31;
            btnIzmeniStavku.Text = "Izmeni Stavku";
            btnIzmeniStavku.UseVisualStyleBackColor = true;
            btnIzmeniStavku.Click += btnIzmeniStavku_Click;
            // 
            // UcStavkaRacunacs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnIzmeniStavku);
            Controls.Add(button1);
            Controls.Add(btnDodaj);
            Controls.Add(cmbFilm);
            Controls.Add(label7);
            Controls.Add(txtCena);
            Controls.Add(label6);
            Controls.Add(txtOpis);
            Controls.Add(label5);
            Name = "UcStavkaRacunacs";
            Size = new Size(619, 505);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbFilm;
        private Label label7;
        private TextBox txtCena;
        private Label label6;
        private TextBox txtOpis;
        private Label label5;
        private Button btnDodaj;
        private Button button1;
        private Button btnIzmeniStavku;
    }
}
