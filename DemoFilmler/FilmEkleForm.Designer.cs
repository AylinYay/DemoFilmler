namespace DemoFilmler
{
    partial class FilmEkleForm
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
            groupBox3 = new GroupBox();
            lbTurler = new ListBox();
            groupBox2 = new GroupBox();
            ddlYonetmenAdiSoyadi = new ComboBox();
            groupBox1 = new GroupBox();
            tbAciklamasi = new TextBox();
            tbMaliyeti = new TextBox();
            tbGisesi = new TextBox();
            ddlYapimYili = new ComboBox();
            tbAdi = new TextBox();
            label7 = new Label();
            label3 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            bEkle = new Button();
            lMesaj = new Label();
            bTemizle = new Button();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lbTurler);
            groupBox3.Location = new Point(12, 245);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(776, 125);
            groupBox3.TabIndex = 5;
            groupBox3.TabStop = false;
            groupBox3.Text = "Tür Bilgileri";
            // 
            // lbTurler
            // 
            lbTurler.FormattingEnabled = true;
            lbTurler.ItemHeight = 15;
            lbTurler.Location = new Point(93, 22);
            lbTurler.Name = "lbTurler";
            lbTurler.SelectionMode = SelectionMode.MultiSimple;
            lbTurler.Size = new Size(246, 94);
            lbTurler.TabIndex = 13;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ddlYonetmenAdiSoyadi);
            groupBox2.Location = new Point(12, 177);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(776, 65);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Yönetmen Bilgileri";
            // 
            // ddlYonetmenAdiSoyadi
            // 
            ddlYonetmenAdiSoyadi.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlYonetmenAdiSoyadi.FormattingEnabled = true;
            ddlYonetmenAdiSoyadi.Location = new Point(93, 24);
            ddlYonetmenAdiSoyadi.Name = "ddlYonetmenAdiSoyadi";
            ddlYonetmenAdiSoyadi.Size = new Size(246, 23);
            ddlYonetmenAdiSoyadi.TabIndex = 11;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbAciklamasi);
            groupBox1.Controls.Add(tbMaliyeti);
            groupBox1.Controls.Add(tbGisesi);
            groupBox1.Controls.Add(ddlYapimYili);
            groupBox1.Controls.Add(tbAdi);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 166);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Film Bilgileri";
            // 
            // tbAciklamasi
            // 
            tbAciklamasi.Location = new Point(504, 26);
            tbAciklamasi.Multiline = true;
            tbAciklamasi.Name = "tbAciklamasi";
            tbAciklamasi.Size = new Size(252, 121);
            tbAciklamasi.TabIndex = 14;
            // 
            // tbMaliyeti
            // 
            tbMaliyeti.Location = new Point(93, 124);
            tbMaliyeti.Name = "tbMaliyeti";
            tbMaliyeti.Size = new Size(246, 23);
            tbMaliyeti.TabIndex = 13;
            // 
            // tbGisesi
            // 
            tbGisesi.Location = new Point(93, 89);
            tbGisesi.Name = "tbGisesi";
            tbGisesi.Size = new Size(246, 23);
            tbGisesi.TabIndex = 12;
            // 
            // ddlYapimYili
            // 
            ddlYapimYili.DropDownStyle = ComboBoxStyle.DropDownList;
            ddlYapimYili.FormattingEnabled = true;
            ddlYapimYili.Location = new Point(93, 53);
            ddlYapimYili.Name = "ddlYapimYili";
            ddlYapimYili.Size = new Size(246, 23);
            ddlYapimYili.TabIndex = 11;
            // 
            // tbAdi
            // 
            tbAdi.Location = new Point(93, 19);
            tbAdi.Name = "tbAdi";
            tbAdi.Size = new Size(246, 23);
            tbAdi.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 132);
            label7.Name = "label7";
            label7.Size = new Size(52, 15);
            label7.TabIndex = 7;
            label7.Text = "Maliyeti:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(431, 27);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 6;
            label3.Text = "Açıklaması:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 96);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 4;
            label5.Text = "Gişesi:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 58);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 2;
            label4.Text = "Yapım Yılı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 27);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 0;
            label2.Text = "Adı:";
            // 
            // bEkle
            // 
            bEkle.Location = new Point(105, 408);
            bEkle.Name = "bEkle";
            bEkle.Size = new Size(124, 23);
            bEkle.TabIndex = 6;
            bEkle.Text = "Ekle";
            bEkle.UseVisualStyleBackColor = true;
            bEkle.Click += bEkle_Click;
            // 
            // lMesaj
            // 
            lMesaj.AutoSize = true;
            lMesaj.Location = new Point(105, 382);
            lMesaj.Name = "lMesaj";
            lMesaj.Size = new Size(41, 15);
            lMesaj.TabIndex = 7;
            lMesaj.Text = "lMesaj";
            // 
            // bTemizle
            // 
            bTemizle.Location = new Point(235, 408);
            bTemizle.Name = "bTemizle";
            bTemizle.Size = new Size(116, 23);
            bTemizle.TabIndex = 8;
            bTemizle.Text = "Temizle";
            bTemizle.UseVisualStyleBackColor = true;
            bTemizle.Click += bTemizle_Click;
            // 
            // FilmEkleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bTemizle);
            Controls.Add(lMesaj);
            Controls.Add(bEkle);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FilmEkleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yeni Film";
            Load += FilmEkleForm_Load;
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private ComboBox ddlYapimYili;
        private TextBox tbAdi;
        private Label label7;
        private Label label3;
        private Label label5;
        private Label label4;
        private Label label2;
        private ComboBox ddlYonetmenAdiSoyadi;
        private TextBox tbAciklamasi;
        private TextBox tbMaliyeti;
        private TextBox tbGisesi;
        private ListBox lbTurler;
        private Button bEkle;
        private Label lMesaj;
        private Button bTemizle;
    }
}