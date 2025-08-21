namespace ServerskaStrana
{
    partial class FrmServer
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
            btnPokreni = new Button();
            dgvKorisnici = new DataGridView();
            btnZaustavi = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKorisnici).BeginInit();
            SuspendLayout();
            // 
            // btnPokreni
            // 
            btnPokreni.Location = new Point(66, 87);
            btnPokreni.Name = "btnPokreni";
            btnPokreni.Size = new Size(139, 42);
            btnPokreni.TabIndex = 0;
            btnPokreni.Text = "Pokreni";
            btnPokreni.UseVisualStyleBackColor = true;
            btnPokreni.Click += btnPokreni_Click;
            // 
            // dgvKorisnici
            // 
            dgvKorisnici.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKorisnici.Location = new Point(66, 162);
            dgvKorisnici.Name = "dgvKorisnici";
            dgvKorisnici.RowHeadersWidth = 51;
            dgvKorisnici.Size = new Size(678, 244);
            dgvKorisnici.TabIndex = 1;
            // 
            // btnZaustavi
            // 
            btnZaustavi.Location = new Point(618, 87);
            btnZaustavi.Name = "btnZaustavi";
            btnZaustavi.Size = new Size(126, 42);
            btnZaustavi.TabIndex = 2;
            btnZaustavi.Text = "Zaustavi";
            btnZaustavi.UseVisualStyleBackColor = true;
            btnZaustavi.Click += btnZaustavi_Click;
            // 
            // FrmServer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 501);
            Controls.Add(btnZaustavi);
            Controls.Add(dgvKorisnici);
            Controls.Add(btnPokreni);
            Name = "FrmServer";
            Text = "FrmServer";
            ((System.ComponentModel.ISupportInitialize)dgvKorisnici).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnPokreni;
        private DataGridView dgvKorisnici;
        private Button btnZaustavi;
    }
}