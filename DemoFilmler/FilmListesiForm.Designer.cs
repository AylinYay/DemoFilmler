namespace DemoFilmler
{
    partial class FilmListesiForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvFilmler = new DataGridView();
            lFilmSayisi = new Label();
            menuStrip1 = new MenuStrip();
            filmİşlemleriToolStripMenuItem = new ToolStripMenuItem();
            listeleToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            ekleToolStripMenuItem = new ToolStripMenuItem();
            bDetay = new Button();
            bDuzenle = new Button();
            bSil = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFilmler).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvFilmler
            // 
            dgvFilmler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFilmler.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvFilmler.Location = new Point(12, 57);
            dgvFilmler.MultiSelect = false;
            dgvFilmler.Name = "dgvFilmler";
            dgvFilmler.RowTemplate.Height = 25;
            dgvFilmler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFilmler.Size = new Size(776, 320);
            dgvFilmler.TabIndex = 0;
            // 
            // lFilmSayisi
            // 
            lFilmSayisi.AutoSize = true;
            lFilmSayisi.Location = new Point(12, 35);
            lFilmSayisi.Name = "lFilmSayisi";
            lFilmSayisi.Size = new Size(62, 15);
            lFilmSayisi.TabIndex = 1;
            lFilmSayisi.Text = "lFilmSayisi";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { filmİşlemleriToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // filmİşlemleriToolStripMenuItem
            // 
            filmİşlemleriToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { listeleToolStripMenuItem, toolStripMenuItem1, ekleToolStripMenuItem });
            filmİşlemleriToolStripMenuItem.Name = "filmİşlemleriToolStripMenuItem";
            filmİşlemleriToolStripMenuItem.Size = new Size(89, 20);
            filmİşlemleriToolStripMenuItem.Text = "Film İşlemleri";
            // 
            // listeleToolStripMenuItem
            // 
            listeleToolStripMenuItem.Name = "listeleToolStripMenuItem";
            listeleToolStripMenuItem.Size = new Size(107, 22);
            listeleToolStripMenuItem.Text = "Listele";
            listeleToolStripMenuItem.Click += listeleToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(104, 6);
            // 
            // ekleToolStripMenuItem
            // 
            ekleToolStripMenuItem.Name = "ekleToolStripMenuItem";
            ekleToolStripMenuItem.Size = new Size(107, 22);
            ekleToolStripMenuItem.Text = "Ekle";
            ekleToolStripMenuItem.Click += ekleToolStripMenuItem_Click;
            // 
            // bDetay
            // 
            bDetay.Location = new Point(12, 394);
            bDetay.Name = "bDetay";
            bDetay.Size = new Size(75, 23);
            bDetay.TabIndex = 3;
            bDetay.Text = "Detay";
            bDetay.UseVisualStyleBackColor = true;
            bDetay.Click += bDetay_Click;
            // 
            // bDuzenle
            // 
            bDuzenle.Location = new Point(103, 394);
            bDuzenle.Name = "bDuzenle";
            bDuzenle.Size = new Size(75, 23);
            bDuzenle.TabIndex = 4;
            bDuzenle.Text = "Düzenle";
            bDuzenle.UseVisualStyleBackColor = true;
            bDuzenle.Click += bDuzenle_Click;
            // 
            // bSil
            // 
            bSil.Location = new Point(200, 394);
            bSil.Name = "bSil";
            bSil.Size = new Size(75, 23);
            bSil.TabIndex = 5;
            bSil.Text = "Sil";
            bSil.UseVisualStyleBackColor = true;
            bSil.Click += bSil_Click;
            // 
            // FilmListesiForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 448);
            Controls.Add(bSil);
            Controls.Add(bDuzenle);
            Controls.Add(bDetay);
            Controls.Add(lFilmSayisi);
            Controls.Add(dgvFilmler);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FilmListesiForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Film Listesi";
            Load += FilmlerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFilmler).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFilmler;
        private Label lFilmSayisi;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem filmİşlemleriToolStripMenuItem;
        private ToolStripMenuItem listeleToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem ekleToolStripMenuItem;
        private Button bDetay;
        private Button bDuzenle;
        private Button bSil;
    }
}