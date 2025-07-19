namespace KlijentskaStrana
{
    partial class UcGledalac
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
            txtIme = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtPrezime = new TextBox();
            label3 = new Label();
            txtMejl = new TextBox();
            label4 = new Label();
            btnUredi = new Button();
            cmbGledalac = new ComboBox();
            SuspendLayout();
            // 
            // txtIme
            // 
            txtIme.Location = new Point(20, 93);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(125, 27);
            txtIme.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 59);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 4;
            label1.Text = "Ime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(235, 69);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 6;
            label2.Text = "Prezime";
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(205, 92);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(125, 27);
            txtPrezime.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 139);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 8;
            label3.Text = "Gledalac";
            // 
            // txtMejl
            // 
            txtMejl.Location = new Point(20, 162);
            txtMejl.Name = "txtMejl";
            txtMejl.Size = new Size(125, 27);
            txtMejl.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(245, 138);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 10;
            label4.Text = "Grad";
            // 
            // btnUredi
            // 
            btnUredi.Location = new Point(383, 90);
            btnUredi.Name = "btnUredi";
            btnUredi.Size = new Size(94, 29);
            btnUredi.TabIndex = 11;
            btnUredi.Text = "Uredi";
            btnUredi.UseVisualStyleBackColor = true;
            btnUredi.Click += btnUredi_Click;
            // 
            // cmbGledalac
            // 
            cmbGledalac.FormattingEnabled = true;
            cmbGledalac.Location = new Point(205, 161);
            cmbGledalac.Name = "cmbGledalac";
            cmbGledalac.Size = new Size(125, 28);
            cmbGledalac.TabIndex = 13;
            // 
            // UcGledalac
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cmbGledalac);
            Controls.Add(btnUredi);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtMejl);
            Controls.Add(label2);
            Controls.Add(txtPrezime);
            Controls.Add(label1);
            Controls.Add(txtIme);
            Name = "UcGledalac";
            Size = new Size(639, 537);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtIme;
        private Label label1;
        private Label label2;
        private TextBox txtPrezime;
        private Label label3;
        private TextBox txtMejl;
        private Label label4;
        private Button btnUredi;
        private ComboBox cmbGledalac;
    }
}
