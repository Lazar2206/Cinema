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
            dgvGledaoci = new DataGridView();
            btnPretraži = new Button();
            label1 = new Label();
            txtIme = new TextBox();
            cmbMesta = new ComboBox();
            btnGlavna = new Button();
            btnAžuriraj = new Button();
            btnObriši = new Button();
            btnDetalji = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvGledaoci).BeginInit();
            SuspendLayout();
            // 
            // btnKreiraj
            // 
            btnKreiraj.Location = new Point(981, 142);
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
            label2.Location = new Point(754, 71);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 31;
            label2.Text = "Mesto";
            label2.Click += label2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(409, 72);
            label4.Name = "label4";
            label4.Size = new Size(62, 20);
            label4.TabIndex = 30;
            label4.Text = "Prezime";
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(368, 95);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(154, 27);
            txtPrezime.TabIndex = 29;
            // 
            // txtKorisničkoIme
            // 
            txtKorisničkoIme.AutoSize = true;
            txtKorisničkoIme.Location = new Point(571, 72);
            txtKorisničkoIme.Name = "txtKorisničkoIme";
            txtKorisničkoIme.Size = new Size(42, 20);
            txtKorisničkoIme.TabIndex = 28;
            txtKorisničkoIme.Text = "Imejl";
            // 
            // txtMejl
            // 
            txtMejl.Location = new Point(535, 95);
            txtMejl.Name = "txtMejl";
            txtMejl.Size = new Size(154, 27);
            txtMejl.TabIndex = 27;
            // 
            // dgvGledaoci
            // 
            dgvGledaoci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGledaoci.Location = new Point(127, 142);
            dgvGledaoci.Name = "dgvGledaoci";
            dgvGledaoci.RowHeadersWidth = 51;
            dgvGledaoci.Size = new Size(828, 274);
            dgvGledaoci.TabIndex = 21;
            // 
            // btnPretraži
            // 
            btnPretraži.Location = new Point(981, 186);
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
            label1.Location = new Point(233, 72);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 24;
            label1.Text = "Ime";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(192, 95);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(154, 27);
            txtIme.TabIndex = 23;
            // 
            // cmbMesta
            // 
            cmbMesta.FormattingEnabled = true;
            cmbMesta.Location = new Point(693, 94);
            cmbMesta.Name = "cmbMesta";
            cmbMesta.Size = new Size(180, 28);
            cmbMesta.TabIndex = 22;
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
            // btnAžuriraj
            // 
            btnAžuriraj.Location = new Point(981, 258);
            btnAžuriraj.Name = "btnAžuriraj";
            btnAžuriraj.Size = new Size(94, 29);
            btnAžuriraj.TabIndex = 34;
            btnAžuriraj.Text = "Ažuriraj";
            btnAžuriraj.UseVisualStyleBackColor = true;
            btnAžuriraj.Click += btnAžuriraj_Click;
            // 
            // btnObriši
            // 
            btnObriši.Location = new Point(981, 303);
            btnObriši.Name = "btnObriši";
            btnObriši.Size = new Size(94, 29);
            btnObriši.TabIndex = 35;
            btnObriši.Text = "Obriši";
            btnObriši.UseVisualStyleBackColor = true;
            btnObriši.Click += btnObriši_Click;
            // 
            // btnDetalji
            // 
            btnDetalji.Location = new Point(981, 223);
            btnDetalji.Name = "btnDetalji";
            btnDetalji.Size = new Size(94, 29);
            btnDetalji.TabIndex = 36;
            btnDetalji.Text = "Detalji";
            btnDetalji.UseVisualStyleBackColor = true;
            btnDetalji.Click += btnDetalji_Click;
            // 
            // FrmGledalac
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1467, 526);
            Controls.Add(btnDetalji);
            Controls.Add(btnObriši);
            Controls.Add(btnAžuriraj);
            Controls.Add(btnGlavna);
            Controls.Add(btnKreiraj);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(txtPrezime);
            Controls.Add(txtKorisničkoIme);
            Controls.Add(txtMejl);
            Controls.Add(dgvGledaoci);
            Controls.Add(btnPretraži);
            Controls.Add(label1);
            Controls.Add(txtIme);
            Controls.Add(cmbMesta);
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
        private DataGridView dgvGledaoci;
        private Button btnPretraži;
        private Label label1;
        private TextBox txtIme;
        private ComboBox cmbMesta;
        private Button btnGlavna;
        private Button btnAžuriraj;
        private Button btnObriši;
        private Button btnDetalji;

        public Button BtnKreiraj { get => btnKreiraj; set => btnKreiraj = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label4 { get => label4; set => label4 = value; }
        public TextBox TxtPrezime { get => txtPrezime; set => txtPrezime = value; }
        public Label TxtKorisničkoIme { get => txtKorisničkoIme; set => txtKorisničkoIme = value; }
        public TextBox TxtMejl { get => txtMejl; set => txtMejl = value; }
      
        public DataGridView DgvGledaoci { get => dgvGledaoci; set => dgvGledaoci = value; }
        public Button BtnPretraži { get => btnPretraži; set => btnPretraži = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public TextBox TxtIme { get => txtIme; set => txtIme = value; }
        public ComboBox CmbMesta { get => cmbMesta; set => cmbMesta = value; }
       
        public Button BtnGlavna { get => btnGlavna; set => btnGlavna = value; }
    }
}