namespace KlijentskaStrana
{
    partial class FrmMesto
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
            btnDodaj = new Button();
            btnGlavna = new Button();
            txtNazivMesta = new TextBox();
            dgvMesta = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMesta).BeginInit();
            SuspendLayout();
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(264, 50);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(94, 29);
            btnDodaj.TabIndex = 0;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // btnGlavna
            // 
            btnGlavna.Location = new Point(658, 399);
            btnGlavna.Name = "btnGlavna";
            btnGlavna.Size = new Size(94, 29);
            btnGlavna.TabIndex = 2;
            btnGlavna.Text = "Glavna";
            btnGlavna.UseVisualStyleBackColor = true;
            btnGlavna.Click += btnGlavna_Click;
            // 
            // txtNazivMesta
            // 
            txtNazivMesta.Location = new Point(90, 52);
            txtNazivMesta.Name = "txtNazivMesta";
            txtNazivMesta.Size = new Size(125, 27);
            txtNazivMesta.TabIndex = 3;
            // 
            // dgvMesta
            // 
            dgvMesta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMesta.Location = new Point(90, 102);
            dgvMesta.Name = "dgvMesta";
            dgvMesta.RowHeadersWidth = 51;
            dgvMesta.Size = new Size(468, 274);
            dgvMesta.TabIndex = 4;
            // 
            // FrmMesto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvMesta);
            Controls.Add(txtNazivMesta);
            Controls.Add(btnGlavna);
            Controls.Add(btnDodaj);
            Name = "FrmMesto";
            Text = "FrmMesto";
            ((System.ComponentModel.ISupportInitialize)dgvMesta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDodaj;
        private Button btnGlavna;
        private TextBox txtNazivMesta;
        private DataGridView dgvMesta;

        public Button BtnDodaj { get => btnDodaj; set => btnDodaj = value; }
        public Button BtnGlavna { get => btnGlavna; set => btnGlavna = value; }
        public TextBox TxtNazivMesta { get => txtNazivMesta; set => txtNazivMesta = value; }
        public DataGridView DgvMesta { get => dgvMesta; set => dgvMesta = value; }
    }
}