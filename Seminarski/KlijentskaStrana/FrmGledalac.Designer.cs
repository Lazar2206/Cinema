namespace KlijentskaStrana
{
    partial class FrmGledalac
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
            btnKreiraj = new Button();
            label2 = new Label();
            label4 = new Label();
            txtPrezime = new TextBox();
            txtKorisničkoIme = new Label();
            txtMejl = new TextBox();
            btnDetalji = new Button();
            dgvGledaoci = new DataGridView();
            btnPretraži = new Button();
            label1 = new Label();
            txtIme = new TextBox();
            cmbMesta = new ComboBox();
            pnlGledalac = new Panel();
            btnGlavna = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGledaoci).BeginInit();
            SuspendLayout();
            // 
            // btnKreiraj
            // 
            btnKreiraj.Location = new Point(715, 110);
            btnKreiraj.Name = "btnKreiraj";
            btnKreiraj.Size = new Size(94, 29);
            btnKreiraj.TabIndex = 32;
            btnKreiraj.Text = "Kreiraj";
            btnKreiraj.UseVisualStyleBackColor = true;
            btnKreiraj.Click += btnKreiraj_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(561, 39);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 31;
            label2.Text = "Mesto";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(216, 40);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 30;
            label4.Text = "Prezime";
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(204, 63);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(125, 27);
            txtPrezime.TabIndex = 29;
            // 
            // txtKorisničkoIme
            // 
            txtKorisničkoIme.AutoSize = true;
            txtKorisničkoIme.Location = new Point(378, 40);
            txtKorisničkoIme.Name = "txtKorisničkoIme";
            txtKorisničkoIme.Size = new Size(42, 20);
            txtKorisničkoIme.TabIndex = 28;
            txtKorisničkoIme.Text = "Imejl";
            // 
            // txtMejl
            // 
            txtMejl.Location = new Point(371, 63);
            txtMejl.Name = "txtMejl";
            txtMejl.Size = new Size(125, 27);
            txtMejl.TabIndex = 27;
            // 
            // btnDetalji
            // 
            btnDetalji.Location = new Point(715, 201);
            btnDetalji.Name = "btnDetalji";
            btnDetalji.Size = new Size(94, 29);
            btnDetalji.TabIndex = 26;
            btnDetalji.Text = "Detalji";
            btnDetalji.UseVisualStyleBackColor = true;
            btnDetalji.Click += btnDetalji_Click_1;
            // 
            // dgvGledaoci
            // 
            dgvGledaoci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGledaoci.Location = new Point(12, 110);
            dgvGledaoci.Name = "dgvGledaoci";
            dgvGledaoci.RowHeadersWidth = 51;
            dgvGledaoci.Size = new Size(681, 177);
            dgvGledaoci.TabIndex = 21;
            // 
            // btnPretraži
            // 
            btnPretraži.Location = new Point(715, 154);
            btnPretraži.Name = "btnPretraži";
            btnPretraži.Size = new Size(94, 31);
            btnPretraži.TabIndex = 25;
            btnPretraži.Text = "Pretraži";
            btnPretraži.UseVisualStyleBackColor = true;
            btnPretraži.Click += btnPretraži_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 40);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 24;
            label1.Text = "Ime";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(28, 63);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(125, 27);
            txtIme.TabIndex = 23;
            // 
            // cmbMesta
            // 
            cmbMesta.FormattingEnabled = true;
            cmbMesta.Location = new Point(529, 62);
            cmbMesta.Name = "cmbMesta";
            cmbMesta.Size = new Size(151, 28);
            cmbMesta.TabIndex = 22;
            // 
            // pnlGledalac
            // 
            pnlGledalac.Location = new Point(13, 293);
            pnlGledalac.Name = "pnlGledalac";
            pnlGledalac.Size = new Size(471, 215);
            pnlGledalac.TabIndex = 20;
            // 
            // btnGlavna
            // 
            btnGlavna.Location = new Point(1341, 479);
            btnGlavna.Name = "btnGlavna";
            btnGlavna.Size = new Size(94, 29);
            btnGlavna.TabIndex = 33;
            btnGlavna.Text = "Glavna";
            btnGlavna.UseVisualStyleBackColor = true;
            btnGlavna.Click += btnGlavna_Click;
            // 
            // FrmGledalac
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1467, 526);
            Controls.Add(btnGlavna);
            Controls.Add(btnKreiraj);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(txtPrezime);
            Controls.Add(txtKorisničkoIme);
            Controls.Add(txtMejl);
            Controls.Add(btnDetalji);
            Controls.Add(dgvGledaoci);
            Controls.Add(btnPretraži);
            Controls.Add(label1);
            Controls.Add(txtIme);
            Controls.Add(cmbMesta);
            Controls.Add(pnlGledalac);
            Name = "FrmGledalac";
            Text = "FrmGledalac";
            ((System.ComponentModel.ISupportInitialize)dgvGledaoci).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnKreiraj;
        private Label label2;
        private Label label4;
        private TextBox txtPrezime;
        private Label txtKorisničkoIme;
        private TextBox txtMejl;
        private Button btnDetalji;
        private DataGridView dgvGledaoci;
        private Button btnPretraži;
        private Label label1;
        private TextBox txtIme;
        private ComboBox cmbMesta;
        private Panel pnlGledalac;
        private Button btnGlavna;
    }
}