namespace KlijentskaStrana
{
    partial class UcDistributer
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
            btnZapamti = new Button();
            btnObriši = new Button();
            btnUredi = new Button();
            label1 = new Label();
            txtNazivDistributera = new TextBox();
            SuspendLayout();
            // 
            // btnZapamti
            // 
            btnZapamti.Location = new Point(106, 112);
            btnZapamti.Name = "btnZapamti";
            btnZapamti.Size = new Size(94, 29);
            btnZapamti.TabIndex = 26;
            btnZapamti.Text = "Zapamti";
            btnZapamti.UseVisualStyleBackColor = true;
            btnZapamti.Click += btnZapamti_Click;
            // 
            // btnObriši
            // 
            btnObriši.Location = new Point(306, 112);
            btnObriši.Name = "btnObriši";
            btnObriši.Size = new Size(94, 31);
            btnObriši.TabIndex = 25;
            btnObriši.Text = "Obriši";
            btnObriši.UseVisualStyleBackColor = true;
            btnObriši.Click += btnObriši_Click;
            // 
            // btnUredi
            // 
            btnUredi.Location = new Point(206, 112);
            btnUredi.Name = "btnUredi";
            btnUredi.Size = new Size(94, 29);
            btnUredi.TabIndex = 23;
            btnUredi.Text = "Ažuriraj";
            btnUredi.UseVisualStyleBackColor = true;
            btnUredi.Click += btnUredi_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(48, 77);
            label1.Name = "label1";
            label1.Size = new Size(34, 20);
            label1.TabIndex = 17;
            label1.Text = "Ime";
            // 
            // txtNazivDistributera
            // 
            txtNazivDistributera.Location = new Point(106, 74);
            txtNazivDistributera.Name = "txtNazivDistributera";
            txtNazivDistributera.Size = new Size(308, 27);
            txtNazivDistributera.TabIndex = 16;
            // 
            // UcDistributer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnZapamti);
            Controls.Add(btnObriši);
            Controls.Add(btnUredi);
            Controls.Add(label1);
            Controls.Add(txtNazivDistributera);
            Name = "UcDistributer";
            Size = new Size(642, 462);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnZapamti;
        private Button btnObriši;
        private Button btnUredi;
        private Label label1;
        private TextBox txtNazivDistributera;
    }
}
