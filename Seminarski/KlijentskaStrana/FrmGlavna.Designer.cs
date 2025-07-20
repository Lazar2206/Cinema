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
            dokumentiToolStripMenuItem = new ToolStripMenuItem();
            računToolStripMenuItem = new ToolStripMenuItem();
            pružalacUslugeToolStripMenuItem = new ToolStripMenuItem();
            bioskopToolStripMenuItem = new ToolStripMenuItem();
            primalacUslugeToolStripMenuItem = new ToolStripMenuItem();
            gledalacToolStripMenuItem = new ToolStripMenuItem();
            šToolStripMenuItem = new ToolStripMenuItem();
            distributerToolStripMenuItem = new ToolStripMenuItem();
            mestoToolStripMenuItem = new ToolStripMenuItem();
            filmToolStripMenuItem = new ToolStripMenuItem();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { dokumentiToolStripMenuItem, pružalacUslugeToolStripMenuItem, primalacUslugeToolStripMenuItem, šToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1461, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // dokumentiToolStripMenuItem
            // 
            dokumentiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { računToolStripMenuItem });
            dokumentiToolStripMenuItem.Name = "dokumentiToolStripMenuItem";
            dokumentiToolStripMenuItem.Size = new Size(96, 24);
            dokumentiToolStripMenuItem.Text = "Dokumenti";
            // 
            // računToolStripMenuItem
            // 
            računToolStripMenuItem.Name = "računToolStripMenuItem";
            računToolStripMenuItem.Size = new Size(132, 26);
            računToolStripMenuItem.Text = "Račun";
            // 
            // pružalacUslugeToolStripMenuItem
            // 
            pružalacUslugeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { bioskopToolStripMenuItem });
            pružalacUslugeToolStripMenuItem.Name = "pružalacUslugeToolStripMenuItem";
            pružalacUslugeToolStripMenuItem.Size = new Size(125, 24);
            pružalacUslugeToolStripMenuItem.Text = "Pružalac usluge";
            // 
            // bioskopToolStripMenuItem
            // 
            bioskopToolStripMenuItem.Name = "bioskopToolStripMenuItem";
            bioskopToolStripMenuItem.Size = new Size(145, 26);
            bioskopToolStripMenuItem.Text = "Bioskop";
            // 
            // primalacUslugeToolStripMenuItem
            // 
            primalacUslugeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gledalacToolStripMenuItem });
            primalacUslugeToolStripMenuItem.Name = "primalacUslugeToolStripMenuItem";
            primalacUslugeToolStripMenuItem.Size = new Size(127, 24);
            primalacUslugeToolStripMenuItem.Text = "Primalac usluge";
            // 
            // gledalacToolStripMenuItem
            // 
            gledalacToolStripMenuItem.Name = "gledalacToolStripMenuItem";
            gledalacToolStripMenuItem.Size = new Size(150, 26);
            gledalacToolStripMenuItem.Text = "Gledalac";
            gledalacToolStripMenuItem.Click += gledalacToolStripMenuItem_Click_1;
            // 
            // šToolStripMenuItem
            // 
            šToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { distributerToolStripMenuItem, mestoToolStripMenuItem, filmToolStripMenuItem });
            šToolStripMenuItem.Name = "šToolStripMenuItem";
            šToolStripMenuItem.Size = new Size(81, 24);
            šToolStripMenuItem.Text = "Šifrarnici";
            // 
            // distributerToolStripMenuItem
            // 
            distributerToolStripMenuItem.Name = "distributerToolStripMenuItem";
            distributerToolStripMenuItem.Size = new Size(224, 26);
            distributerToolStripMenuItem.Text = "Distributer";
            distributerToolStripMenuItem.Click += distributerToolStripMenuItem_Click;
            // 
            // mestoToolStripMenuItem
            // 
            mestoToolStripMenuItem.Name = "mestoToolStripMenuItem";
            mestoToolStripMenuItem.Size = new Size(224, 26);
            mestoToolStripMenuItem.Text = "Mesto";
            mestoToolStripMenuItem.Click += mestoToolStripMenuItem_Click;
            // 
            // filmToolStripMenuItem
            // 
            filmToolStripMenuItem.Name = "filmToolStripMenuItem";
            filmToolStripMenuItem.Size = new Size(224, 26);
            filmToolStripMenuItem.Text = "Film";
            filmToolStripMenuItem.Click += filmToolStripMenuItem_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // FrmGlavna
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1461, 526);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmGlavna";
            Text = "FrmGlavna";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private ToolStripMenuItem dokumentiToolStripMenuItem;
        private ToolStripMenuItem računToolStripMenuItem;
        private ToolStripMenuItem pružalacUslugeToolStripMenuItem;
        private ToolStripMenuItem bioskopToolStripMenuItem;
        private ToolStripMenuItem primalacUslugeToolStripMenuItem;
        private ToolStripMenuItem gledalacToolStripMenuItem;
        private ToolStripMenuItem šToolStripMenuItem;
        private ToolStripMenuItem distributerToolStripMenuItem;
        private ToolStripMenuItem mestoToolStripMenuItem;
        private ToolStripMenuItem filmToolStripMenuItem;
    }
}