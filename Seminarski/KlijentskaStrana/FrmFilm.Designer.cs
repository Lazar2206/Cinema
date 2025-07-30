namespace KlijentskaStrana
{
    partial class FrmFilm
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
            dgvFilmovi = new DataGridView();
            txtNaslov = new TextBox();
            btnGlavna = new Button();
            btnDodaj = new Button();
            cmbŽanr = new ComboBox();
            dateTimePickerPocetak = new DateTimePicker();
            dateTimePickerKraj = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFilmovi).BeginInit();
            SuspendLayout();
            // 
            // dgvFilmovi
            // 
            dgvFilmovi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFilmovi.Location = new Point(12, 164);
            dgvFilmovi.Name = "dgvFilmovi";
            dgvFilmovi.RowHeadersWidth = 51;
            dgvFilmovi.Size = new Size(517, 274);
            dgvFilmovi.TabIndex = 8;
            // 
            // txtNaslov
            // 
            txtNaslov.Location = new Point(27, 38);
            txtNaslov.Name = "txtNaslov";
            txtNaslov.Size = new Size(125, 27);
            txtNaslov.TabIndex = 7;
            // 
            // btnGlavna
            // 
            btnGlavna.Location = new Point(637, 385);
            btnGlavna.Name = "btnGlavna";
            btnGlavna.Size = new Size(94, 29);
            btnGlavna.TabIndex = 6;
            btnGlavna.Text = "Glavna";
            btnGlavna.UseVisualStyleBackColor = true;
            btnGlavna.Click += btnGlavna_Click;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(637, 68);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(94, 29);
            btnDodaj.TabIndex = 5;
            btnDodaj.Text = "Dodaj";
            btnDodaj.UseVisualStyleBackColor = true;
            btnDodaj.Click += btnDodaj_Click;
            // 
            // cmbŽanr
            // 
            cmbŽanr.FormattingEnabled = true;
            cmbŽanr.Location = new Point(27, 91);
            cmbŽanr.Name = "cmbŽanr";
            cmbŽanr.Size = new Size(125, 28);
            cmbŽanr.TabIndex = 9;
            // 
            // dateTimePickerPocetak
            // 
            dateTimePickerPocetak.Format = DateTimePickerFormat.Time;
            dateTimePickerPocetak.Location = new Point(279, 38);
            dateTimePickerPocetak.Name = "dateTimePickerPocetak";
            dateTimePickerPocetak.ShowUpDown = true;
            dateTimePickerPocetak.Size = new Size(250, 27);
            dateTimePickerPocetak.TabIndex = 10;
            // 
            // dateTimePickerKraj
            // 
            dateTimePickerKraj.Format = DateTimePickerFormat.Time;
            dateTimePickerKraj.Location = new Point(279, 91);
            dateTimePickerKraj.Name = "dateTimePickerKraj";
            dateTimePickerKraj.ShowUpDown = true;
            dateTimePickerKraj.Size = new Size(250, 27);
            dateTimePickerKraj.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(352, 9);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 12;
            label1.Text = "Početak";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(364, 68);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 13;
            label2.Text = "Kraj";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(61, 15);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 14;
            label3.Text = "Naslov";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(61, 68);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 15;
            label4.Text = "Žanr";
            // 
            // FrmFilm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePickerKraj);
            Controls.Add(dateTimePickerPocetak);
            Controls.Add(cmbŽanr);
            Controls.Add(dgvFilmovi);
            Controls.Add(txtNaslov);
            Controls.Add(btnGlavna);
            Controls.Add(btnDodaj);
            Name = "FrmFilm";
            Text = "FrmFilm";
            ((System.ComponentModel.ISupportInitialize)dgvFilmovi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFilmovi;
        private TextBox txtNaslov;
        private Button btnGlavna;
        private Button btnDodaj;
        private ComboBox cmbŽanr;
        private DateTimePicker dateTimePickerPocetak;
        private DateTimePicker dateTimePickerKraj;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;

        public DataGridView DgvFilmovi { get => dgvFilmovi; set => dgvFilmovi = value; }
        public TextBox TxtNaslov { get => txtNaslov; set => txtNaslov = value; }
        public Button BtnGlavna { get => btnGlavna; set => btnGlavna = value; }
        public Button BtnDodaj { get => btnDodaj; set => btnDodaj = value; }
        public ComboBox CmbŽanr { get => cmbŽanr; set => cmbŽanr = value; }
        public DateTimePicker DateTimePickerPocetak { get => dateTimePickerPocetak; set => dateTimePickerPocetak = value; }
        public DateTimePicker DateTimePickerKraj { get => dateTimePickerKraj; set => dateTimePickerKraj = value; }
        public Label Label1 { get => label1; set => label1 = value; }
        public Label Label2 { get => label2; set => label2 = value; }
        public Label Label3 { get => label3; set => label3 = value; }
        public Label Label4 { get => label4; set => label4 = value; }
    }
}