namespace KlijentskaStrana
{
    partial class FrmGlavna
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
            menuStrip1 = new MenuStrip();
            gledalacToolStripMenuItem = new ToolStripMenuItem();
            računToolStripMenuItem = new ToolStripMenuItem();
            distributerToolStripMenuItem = new ToolStripMenuItem();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            pnlGledalac = new Panel();
            btnPretraži = new Button();
            label1 = new Label();
            txtIme = new TextBox();
            cmbMesta = new ComboBox();
            dgvGledaoci = new DataGridView();
            btnDetalji = new Button();
            btnObriši = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGledaoci).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { gledalacToolStripMenuItem, računToolStripMenuItem, distributerToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1461, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // gledalacToolStripMenuItem
            // 
            gledalacToolStripMenuItem.Name = "gledalacToolStripMenuItem";
            gledalacToolStripMenuItem.Size = new Size(81, 24);
            gledalacToolStripMenuItem.Text = "Gledalac";
            gledalacToolStripMenuItem.Click += gledalacToolStripMenuItem_Click;
            // 
            // računToolStripMenuItem
            // 
            računToolStripMenuItem.Name = "računToolStripMenuItem";
            računToolStripMenuItem.Size = new Size(63, 24);
            računToolStripMenuItem.Text = "Račun";
            // 
            // distributerToolStripMenuItem
            // 
            distributerToolStripMenuItem.Name = "distributerToolStripMenuItem";
            distributerToolStripMenuItem.Size = new Size(93, 24);
            distributerToolStripMenuItem.Text = "Distributer";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // pnlGledalac
            // 
            pnlGledalac.Location = new Point(27, 343);
            pnlGledalac.Name = "pnlGledalac";
            pnlGledalac.Size = new Size(436, 115);
            pnlGledalac.TabIndex = 1;
            // 
            // btnPretraži
            // 
            btnPretraži.Location = new Point(395, 65);
            btnPretraži.Name = "btnPretraži";
            btnPretraži.Size = new Size(88, 31);
            btnPretraži.TabIndex = 10;
            btnPretraži.Text = "Pretraži";
            btnPretraži.UseVisualStyleBackColor = true;
            btnPretraži.Click += btnPretraži_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 35);
            label1.Name = "label1";
            label1.Size = new Size(153, 20);
            label1.TabIndex = 9;
            label1.Text = "Unesite ime gledaoca";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(27, 69);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(125, 27);
            txtIme.TabIndex = 8;
            // 
            // cmbMesta
            // 
            cmbMesta.FormattingEnabled = true;
            cmbMesta.Location = new Point(221, 68);
            cmbMesta.Name = "cmbMesta";
            cmbMesta.Size = new Size(151, 28);
            cmbMesta.TabIndex = 7;
            // 
            // dgvGledaoci
            // 
            dgvGledaoci.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGledaoci.Location = new Point(11, 116);
            dgvGledaoci.Name = "dgvGledaoci";
            dgvGledaoci.RowHeadersWidth = 51;
            dgvGledaoci.Size = new Size(472, 221);
            dgvGledaoci.TabIndex = 6;
            // 
            // btnDetalji
            // 
            btnDetalji.Location = new Point(517, 116);
            btnDetalji.Name = "btnDetalji";
            btnDetalji.Size = new Size(94, 29);
            btnDetalji.TabIndex = 11;
            btnDetalji.Text = "Detalji";
            btnDetalji.UseVisualStyleBackColor = true;
            btnDetalji.Click += btnDetalji_Click;
            // 
            // btnObriši
            // 
            btnObriši.Location = new Point(517, 168);
            btnObriši.Name = "btnObriši";
            btnObriši.Size = new Size(94, 29);
            btnObriši.TabIndex = 12;
            btnObriši.Text = "Obriši";
            btnObriši.UseVisualStyleBackColor = true;
            // 
            // FrmGlavna
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1461, 470);
            Controls.Add(btnObriši);
            Controls.Add(btnDetalji);
            Controls.Add(dgvGledaoci);
            Controls.Add(btnPretraži);
            Controls.Add(label1);
            Controls.Add(txtIme);
            Controls.Add(cmbMesta);
            Controls.Add(pnlGledalac);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmGlavna";
            Text = "FrmGlavna";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGledaoci).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem gledalacToolStripMenuItem;
        private ToolStripMenuItem računToolStripMenuItem;
        private ToolStripMenuItem distributerToolStripMenuItem;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Panel pnlGledalac;
        private Button btnPretraži;
        private Label label1;
        private TextBox txtIme;
        private ComboBox cmbMesta;
        private DataGridView dgvGledaoci;
        private Button btnDetalji;
        private Button btnObriši;
    }
}