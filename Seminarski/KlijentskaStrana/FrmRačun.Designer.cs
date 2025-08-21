namespace KlijentskaStrana
{
    partial class FrmRačun
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
            cmbGledalac = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            dateTimePicker1 = new DateTimePicker();
            txtUkupnaCena = new TextBox();
            label4 = new Label();
            dgvRacunStavke = new DataGridView();
            btnDetalji = new Button();
            btnKreirajRačun = new Button();
            btnIzmeni = new Button();
            btnObriši = new Button();
            txtBioskop = new TextBox();
            btnGlavna = new Button();
            dgvRacuni = new DataGridView();
            btnPretraži = new Button();
            btnDetaljiStavke = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRacunStavke).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRacuni).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 98);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 0;
            label1.Text = "Gledalac";
            // 
            // cmbGledalac
            // 
            cmbGledalac.FormattingEnabled = true;
            cmbGledalac.Location = new Point(132, 95);
            cmbGledalac.Name = "cmbGledalac";
            cmbGledalac.Size = new Size(440, 28);
            cmbGledalac.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 149);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 2;
            label2.Text = "Bioskop";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 196);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 4;
            label3.Text = "Datum";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(132, 191);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(440, 27);
            dateTimePicker1.TabIndex = 5;
            // 
            // txtUkupnaCena
            // 
            txtUkupnaCena.Location = new Point(132, 236);
            txtUkupnaCena.Name = "txtUkupnaCena";
            txtUkupnaCena.Size = new Size(440, 27);
            txtUkupnaCena.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 239);
            label4.Name = "label4";
            label4.Size = new Size(94, 20);
            label4.TabIndex = 7;
            label4.Text = "Ukupna cena";
            // 
            // dgvRacunStavke
            // 
            dgvRacunStavke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRacunStavke.Location = new Point(32, 269);
            dgvRacunStavke.Name = "dgvRacunStavke";
            dgvRacunStavke.RowHeadersWidth = 51;
            dgvRacunStavke.Size = new Size(532, 138);
            dgvRacunStavke.TabIndex = 8;
            // 
            // btnDetalji
            // 
            btnDetalji.Location = new Point(1264, 190);
            btnDetalji.Name = "btnDetalji";
            btnDetalji.Size = new Size(111, 29);
            btnDetalji.TabIndex = 11;
            btnDetalji.Text = "Detalji";
            btnDetalji.UseVisualStyleBackColor = true;
            btnDetalji.Click += btnDetalji_Click;
            // 
            // btnKreirajRačun
            // 
            btnKreirajRačun.Location = new Point(1264, 145);
            btnKreirajRačun.Name = "btnKreirajRačun";
            btnKreirajRačun.Size = new Size(111, 29);
            btnKreirajRačun.TabIndex = 14;
            btnKreirajRačun.Text = "Kreiraj račun";
            btnKreirajRačun.UseVisualStyleBackColor = true;
            btnKreirajRačun.Click += btnKreirajRačun_Click;
            // 
            // btnIzmeni
            // 
            btnIzmeni.Location = new Point(1264, 236);
            btnIzmeni.Name = "btnIzmeni";
            btnIzmeni.Size = new Size(111, 29);
            btnIzmeni.TabIndex = 15;
            btnIzmeni.Text = "Izmeni račun";
            btnIzmeni.UseVisualStyleBackColor = true;
            btnIzmeni.Click += btnIzmeni_Click;
            // 
            // btnObriši
            // 
            btnObriši.Location = new Point(1264, 287);
            btnObriši.Name = "btnObriši";
            btnObriši.Size = new Size(111, 29);
            btnObriši.TabIndex = 16;
            btnObriši.Text = "Obriši račun";
            btnObriši.UseVisualStyleBackColor = true;
            btnObriši.Click += btnObriši_Click;
            // 
            // txtBioskop
            // 
            txtBioskop.Location = new Point(132, 146);
            txtBioskop.Name = "txtBioskop";
            txtBioskop.Size = new Size(440, 27);
            txtBioskop.TabIndex = 17;
            // 
            // btnGlavna
            // 
            btnGlavna.Location = new Point(1407, 495);
            btnGlavna.Name = "btnGlavna";
            btnGlavna.Size = new Size(94, 29);
            btnGlavna.TabIndex = 18;
            btnGlavna.Text = "Glavna";
            btnGlavna.UseVisualStyleBackColor = true;
            btnGlavna.Click += btnGlavna_Click;
            // 
            // dgvRacuni
            // 
            dgvRacuni.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRacuni.Location = new Point(698, 95);
            dgvRacuni.Name = "dgvRacuni";
            dgvRacuni.RowHeadersWidth = 51;
            dgvRacuni.Size = new Size(532, 312);
            dgvRacuni.TabIndex = 19;
            // 
            // btnPretraži
            // 
            btnPretraži.Location = new Point(1264, 99);
            btnPretraži.Name = "btnPretraži";
            btnPretraži.Size = new Size(111, 29);
            btnPretraži.TabIndex = 20;
            btnPretraži.Text = "Pretraži";
            btnPretraži.UseVisualStyleBackColor = true;
            btnPretraži.Click += btnPretraži_Click;
            // 
            // btnDetaljiStavke
            // 
            btnDetaljiStavke.Location = new Point(449, 428);
            btnDetaljiStavke.Name = "btnDetaljiStavke";
            btnDetaljiStavke.Size = new Size(115, 39);
            btnDetaljiStavke.TabIndex = 21;
            btnDetaljiStavke.Text = "DetaljiStavke";
            btnDetaljiStavke.UseVisualStyleBackColor = true;
            btnDetaljiStavke.Click += btnDetaljiStavke_Click;
            // 
            // FrmRačun
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1557, 536);
            Controls.Add(btnDetaljiStavke);
            Controls.Add(btnPretraži);
            Controls.Add(dgvRacuni);
            Controls.Add(btnGlavna);
            Controls.Add(txtBioskop);
            Controls.Add(btnObriši);
            Controls.Add(btnIzmeni);
            Controls.Add(btnKreirajRačun);
            Controls.Add(btnDetalji);
            Controls.Add(dgvRacunStavke);
            Controls.Add(label4);
            Controls.Add(txtUkupnaCena);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbGledalac);
            Controls.Add(label1);
            Name = "FrmRačun";
            Text = "FrmRačun";
            ((System.ComponentModel.ISupportInitialize)dgvRacunStavke).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRacuni).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbGledalac;
        private Label label2;
        private Label label3;
        private DateTimePicker dateTimePicker1;
        private TextBox txtUkupnaCena;
        private Label label4;
        private DataGridView dgvRacunStavke;
        private Button btnDetalji;
        private Button btnKreirajRačun;
        private Button btnIzmeni;
        private Button btnObriši;
        private TextBox txtBioskop;
        private Button btnGlavna;
        private DataGridView dgvRacuni;
        private Button btnPretraži;
        private Button btnDetaljiStavke;
    }
}