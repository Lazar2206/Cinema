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
            dgvDistributeri = new DataGridView();
            btnPretraži = new Button();
            label1 = new Label();
            txtNazivDistributera = new TextBox();
            btnAžuriraj = new Button();
            btnObriši = new Button();
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
            btnKreiraj.Location = new Point(735, 104);
            btnKreiraj.Name = "btnKreiraj";
            btnKreiraj.Size = new Size(94, 29);
            btnKreiraj.TabIndex = 46;
            btnKreiraj.Text = "Kreiraj";
            btnKreiraj.UseVisualStyleBackColor = true;
            btnKreiraj.Click += btnKreiraj_Click;
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
            btnPretraži.Location = new Point(735, 152);
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
            label1.Location = new Point(22, 55);
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
            // btnAžuriraj
            // 
            btnAžuriraj.Location = new Point(735, 200);
            btnAžuriraj.Name = "btnAžuriraj";
            btnAžuriraj.Size = new Size(94, 29);
            btnAžuriraj.TabIndex = 48;
            btnAžuriraj.Text = "Ažuriraj";
            btnAžuriraj.UseVisualStyleBackColor = true;
            btnAžuriraj.Click += btnAžuriraj_Click;
            // 
            // btnObriši
            // 
            btnObriši.Location = new Point(735, 252);
            btnObriši.Name = "btnObriši";
            btnObriši.Size = new Size(94, 29);
            btnObriši.TabIndex = 49;
            btnObriši.Text = "Obriši";
            btnObriši.UseVisualStyleBackColor = true;
            btnObriši.Click += btnObriši_Click;
            // 
            // FrmDistributer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1542, 542);
            Controls.Add(btnObriši);
            Controls.Add(btnAžuriraj);
            Controls.Add(btnGlavna);
            Controls.Add(btnKreiraj);
            Controls.Add(dgvDistributeri);
            Controls.Add(btnPretraži);
            Controls.Add(label1);
            Controls.Add(txtNazivDistributera);
            Name = "FrmDistributer";
            Text = "FrmDistributer";
            ((System.ComponentModel.ISupportInitialize)dgvDistributeri).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGlavna;
        private Button btnKreiraj;
        private DataGridView dgvDistributeri;
        private Button btnPretraži;
        private Label label1;
        private TextBox txtNazivDistributera;
        private Button btnAžuriraj;
        private Button btnObriši;
    }
}