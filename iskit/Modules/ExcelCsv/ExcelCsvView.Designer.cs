namespace iskit.Modules.ExcelCsv
{
    partial class ExcelCsvView
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnDosyaSec = new Button();
            lstDosyalar = new ListBox();
            btnBirlestir = new Button();
            lblDurum = new Label();
            lblFiltreBaslik = new Label();
            btnFiltreDosyaSec = new Button();
            lblFiltreDosya = new Label();
            clbSutunlar = new CheckedListBox();
            btnFiltrele = new Button();
            lblDonusturBaslik = new Label();
            btnDonusturDosyaSec = new Button();
            lblDonusturDosya = new Label();
            btnDonusturKaydet = new Button();
            btnDosyaKaldir = new Button();
            btnListeTemizle = new Button();
            lblSayac = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Margin = new Padding(6, 0, 6, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(246, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📊 Excel / CSV Aracı";
            // 
            // btnDosyaSec
            // 
            btnDosyaSec.FlatStyle = FlatStyle.Flat;
            btnDosyaSec.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnDosyaSec.Location = new Point(30, 80);
            btnDosyaSec.Name = "btnDosyaSec";
            btnDosyaSec.Size = new Size(160, 35);
            btnDosyaSec.TabIndex = 2;
            btnDosyaSec.Text = "📁 Dosya Seç";
            btnDosyaSec.UseVisualStyleBackColor = true;
            btnDosyaSec.Click += btnDosyaSec_Click;
            // 
            // lstDosyalar
            // 
            lstDosyalar.FormattingEnabled = true;
            lstDosyalar.Location = new Point(30, 130);
            lstDosyalar.Name = "lstDosyalar";
            lstDosyalar.SelectionMode = SelectionMode.MultiExtended;
            lstDosyalar.Size = new Size(500, 132);
            lstDosyalar.TabIndex = 3;
            // 
            // btnBirlestir
            // 
            btnBirlestir.FlatStyle = FlatStyle.Flat;
            btnBirlestir.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnBirlestir.Location = new Point(30, 300);
            btnBirlestir.Name = "btnBirlestir";
            btnBirlestir.Size = new Size(200, 40);
            btnBirlestir.TabIndex = 4;
            btnBirlestir.Text = "Birleştir ve Kaydet";
            btnBirlestir.UseVisualStyleBackColor = true;
            btnBirlestir.Click += btnBirlestir_Click;
            // 
            // lblDurum
            // 
            lblDurum.AutoSize = true;
            lblDurum.ForeColor = Color.Gray;
            lblDurum.Location = new Point(30, 350);
            lblDurum.Name = "lblDurum";
            lblDurum.Size = new Size(0, 32);
            lblDurum.TabIndex = 5;
            // 
            // lblFiltreBaslik
            // 
            lblFiltreBaslik.AutoSize = true;
            lblFiltreBaslik.Font = new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblFiltreBaslik.ForeColor = Color.FromArgb(30, 30, 46);
            lblFiltreBaslik.Location = new Point(30, 410);
            lblFiltreBaslik.Name = "lblFiltreBaslik";
            lblFiltreBaslik.Size = new Size(143, 23);
            lblFiltreBaslik.TabIndex = 6;
            lblFiltreBaslik.Text = "Sütun Filtreleme";
            // 
            // btnFiltreDosyaSec
            // 
            btnFiltreDosyaSec.FlatStyle = FlatStyle.Flat;
            btnFiltreDosyaSec.Location = new Point(30, 445);
            btnFiltreDosyaSec.Name = "btnFiltreDosyaSec";
            btnFiltreDosyaSec.Size = new Size(220, 35);
            btnFiltreDosyaSec.TabIndex = 7;
            btnFiltreDosyaSec.Text = "📁 Filtrelenecek Dosyayı Seç";
            btnFiltreDosyaSec.UseVisualStyleBackColor = true;
            btnFiltreDosyaSec.Click += btnFiltreDosyaSec_Click;
            // 
            // lblFiltreDosya
            // 
            lblFiltreDosya.AutoSize = true;
            lblFiltreDosya.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 162);
            lblFiltreDosya.ForeColor = Color.Gray;
            lblFiltreDosya.Location = new Point(265, 452);
            lblFiltreDosya.Name = "lblFiltreDosya";
            lblFiltreDosya.Size = new Size(0, 15);
            lblFiltreDosya.TabIndex = 8;
            // 
            // clbSutunlar
            // 
            clbSutunlar.BorderStyle = BorderStyle.FixedSingle;
            clbSutunlar.CheckOnClick = true;
            clbSutunlar.FormattingEnabled = true;
            clbSutunlar.Location = new Point(30, 490);
            clbSutunlar.Name = "clbSutunlar";
            clbSutunlar.Size = new Size(500, 104);
            clbSutunlar.TabIndex = 9;
            // 
            // btnFiltrele
            // 
            btnFiltrele.BackColor = Color.FromArgb(79, 124, 255);
            btnFiltrele.FlatStyle = FlatStyle.Flat;
            btnFiltrele.ForeColor = Color.White;
            btnFiltrele.Location = new Point(30, 630);
            btnFiltrele.Name = "btnFiltrele";
            btnFiltrele.Size = new Size(200, 40);
            btnFiltrele.TabIndex = 10;
            btnFiltrele.Text = "Filtrelenmiş Kaydet";
            btnFiltrele.UseVisualStyleBackColor = false;
            btnFiltrele.Click += btnFiltrele_Click;
            // 
            // lblDonusturBaslik
            // 
            lblDonusturBaslik.AutoSize = true;
            lblDonusturBaslik.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDonusturBaslik.Location = new Point(30, 690);
            lblDonusturBaslik.Name = "lblDonusturBaslik";
            lblDonusturBaslik.Size = new Size(182, 25);
            lblDonusturBaslik.TabIndex = 11;
            lblDonusturBaslik.Text = "Format Dönüştürme";
            // 
            // btnDonusturDosyaSec
            // 
            btnDonusturDosyaSec.Location = new Point(30, 725);
            btnDonusturDosyaSec.Name = "btnDonusturDosyaSec";
            btnDonusturDosyaSec.Size = new Size(220, 35);
            btnDonusturDosyaSec.TabIndex = 12;
            btnDonusturDosyaSec.Text = "📁 Dönüştürülecek Dosyayı Seç";
            btnDonusturDosyaSec.UseVisualStyleBackColor = true;
            btnDonusturDosyaSec.Click += btnDonusturDosyaSec_Click;
            // 
            // lblDonusturDosya
            // 
            lblDonusturDosya.AutoSize = true;
            lblDonusturDosya.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblDonusturDosya.ForeColor = Color.Gray;
            lblDonusturDosya.Location = new Point(265, 732);
            lblDonusturDosya.Name = "lblDonusturDosya";
            lblDonusturDosya.Size = new Size(0, 15);
            lblDonusturDosya.TabIndex = 13;
            // 
            // btnDonusturKaydet
            // 
            btnDonusturKaydet.BackColor = Color.FromArgb(79, 124, 255);
            btnDonusturKaydet.FlatStyle = FlatStyle.Flat;
            btnDonusturKaydet.ForeColor = Color.White;
            btnDonusturKaydet.Location = new Point(30, 770);
            btnDonusturKaydet.Name = "btnDonusturKaydet";
            btnDonusturKaydet.Size = new Size(200, 40);
            btnDonusturKaydet.TabIndex = 14;
            btnDonusturKaydet.Text = "Dönüştür ve Kaydet";
            btnDonusturKaydet.UseVisualStyleBackColor = false;
            btnDonusturKaydet.Click += btnDonusturKaydet_Click;
            // 
            // btnDosyaKaldir
            // 
            btnDosyaKaldir.FlatStyle = FlatStyle.Flat;
            btnDosyaKaldir.Location = new Point(587, 20);
            btnDosyaKaldir.Name = "btnDosyaKaldir";
            btnDosyaKaldir.Size = new Size(143, 159);
            btnDosyaKaldir.TabIndex = 15;
            btnDosyaKaldir.Text = "🗑 Seçileni Kaldır";
            btnDosyaKaldir.UseVisualStyleBackColor = true;
            btnDosyaKaldir.Click += btnDosyaKaldir_Click;
            // 
            // btnListeTemizle
            // 
            btnListeTemizle.FlatStyle = FlatStyle.Flat;
            btnListeTemizle.Location = new Point(736, 20);
            btnListeTemizle.Name = "btnListeTemizle";
            btnListeTemizle.Size = new Size(143, 159);
            btnListeTemizle.TabIndex = 16;
            btnListeTemizle.Text = "🗑 Listeyi Temizle";
            btnListeTemizle.UseVisualStyleBackColor = true;
            btnListeTemizle.Click += btnListeTemizle_Click;
            // 
            // lblSayac
            // 
            lblSayac.AutoSize = true;
            lblSayac.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSayac.ForeColor = Color.FromArgb(79, 124, 255);
            lblSayac.Location = new Point(196, 83);
            lblSayac.Name = "lblSayac";
            lblSayac.Size = new Size(0, 15);
            lblSayac.TabIndex = 17;
            // 
            // ExcelCsvView
            // 
            AutoScaleDimensions = new SizeF(14F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblSayac);
            Controls.Add(btnListeTemizle);
            Controls.Add(btnDosyaKaldir);
            Controls.Add(btnDonusturKaydet);
            Controls.Add(lblDonusturDosya);
            Controls.Add(btnDonusturDosyaSec);
            Controls.Add(lblDonusturBaslik);
            Controls.Add(btnFiltrele);
            Controls.Add(clbSutunlar);
            Controls.Add(lblFiltreDosya);
            Controls.Add(btnFiltreDosyaSec);
            Controls.Add(lblFiltreBaslik);
            Controls.Add(lblDurum);
            Controls.Add(btnBirlestir);
            Controls.Add(lstDosyalar);
            Controls.Add(btnDosyaSec);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            Location = new Point(20, 20);
            Margin = new Padding(6);
            Name = "ExcelCsvView";
            Size = new Size(1093, 850);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnDosyaSec;
        private ListBox lstDosyalar;
        private Button btnBirlestir;
        private Label lblDurum;
        private Label lblFiltreBaslik;
        private Button btnFiltreDosyaSec;
        private Label lblFiltreDosya;
        private CheckedListBox clbSutunlar;
        private Button btnFiltrele;
        private Label lblDonusturBaslik;
        private Button btnDonusturDosyaSec;
        private Label lblDonusturDosya;
        private Button btnDonusturKaydet;
        private Button btnDosyaKaldir;
        private Button btnListeTemizle;
        private Label lblSayac;
    }
}
