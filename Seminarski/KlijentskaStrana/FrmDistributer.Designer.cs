namespace KlijentskaStrana
{
    partial class FrmDistributer
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
            btnGlavna = new Button();
            btnKreiraj = new Button();
            btnDetalji = new Button();
            dgvDistributeri = new DataGridView();
            btnPretraži = new Button();
            label1 = new Label();
            txtNazivDistributera = new TextBox();
            pnlDistributer = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvDistributeri).BeginInit();
            SuspendLayout();
            // 
            // btnGlavna
            // 
            btnGlavna.Location = new Point(1351, 473);
            btnGlavna.Name = "btnGlavna";
            btnGlavna.Size = new Size(94, 29);
            btnGlavna.TabIndex = 47;
            btnGlavna.Text = "Glavna";
            btnGlavna.UseVisualStyleBackColor = true;
            btnGlavna.Click += btnGlavna_Click;
            // 
            // btnKreiraj
            // 
            btnKreiraj.Location = new Point(725, 104);
            btnKreiraj.Name = "btnKreiraj";
            btnKreiraj.Size = new Size(94, 29);
            btnKreiraj.TabIndex = 46;
            btnKreiraj.Text = "Kreiraj";
            btnKreiraj.UseVisualStyleBackColor = true;
            btnKreiraj.Click += btnKreiraj_Click;
            // 
            // btnDetalji
            // 
            btnDetalji.Location = new Point(725, 195);
            btnDetalji.Name = "btnDetalji";
            btnDetalji.Size = new Size(94, 29);
            btnDetalji.TabIndex = 40;
            btnDetalji.Text = "Detalji";
            btnDetalji.UseVisualStyleBackColor = true;
            btnDetalji.Click += btnDetalji_Click;
            // 
            // dgvDistributeri
            // 
            dgvDistributeri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDistributeri.Location = new Point(22, 104);
            dgvDistributeri.Name = "dgvDistributeri";
            dgvDistributeri.RowHeadersWidth = 51;
            dgvDistributeri.Size = new Size(681, 177);
            dgvDistributeri.TabIndex = 35;
            // 
            // btnPretraži
            // 
            btnPretraži.Location = new Point(725, 148);
            btnPretraži.Name = "btnPretraži";
            btnPretraži.Size = new Size(94, 31);
            btnPretraži.TabIndex = 39;
            btnPretraži.Text = "Pretraži";
            btnPretraži.UseVisualStyleBackColor = true;
            btnPretraži.Click += btnPretraži_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 62);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 38;
            label1.Text = "Ime";
            // 
            // txtNazivDistributera
            // 
            txtNazivDistributera.Location = new Point(89, 55);
            txtNazivDistributera.Name = "txtNazivDistributera";
            txtNazivDistributera.Size = new Size(125, 27);
            txtNazivDistributera.TabIndex = 37;
            // 
            // pnlDistributer
            // 
            pnlDistributer.Location = new Point(22, 297);
            pnlDistributer.Name = "pnlDistributer";
            pnlDistributer.Size = new Size(471, 215);
            pnlDistributer.TabIndex = 34;
            // 
            // FrmDistributer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1542, 542);
            Controls.Add(btnGlavna);
            Controls.Add(btnKreiraj);
            Controls.Add(btnDetalji);
            Controls.Add(dgvDistributeri);
            Controls.Add(btnPretraži);
            Controls.Add(label1);
            Controls.Add(txtNazivDistributera);
            Controls.Add(pnlDistributer);
            Name = "FrmDistributer";
            Text = "FrmDistributer";
            ((System.ComponentModel.ISupportInitialize)dgvDistributeri).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGlavna;
        private Button btnKreiraj;
        private Button btnDetalji;
        private DataGridView dgvDistributeri;
        private Button btnPretraži;
        private Label label1;
        private TextBox txtNazivDistributera;
        private Panel pnlDistributer;
    }
}