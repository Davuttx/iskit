using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace iskit.Modules.ExcelCsv
{
    public partial class ExcelCsvView : UserControl
    {
        private List<string> _secilenDosyalar = new();
        private string? _filtreDosyaYolu;
        private string? _donusturDosyaYolu;

        public ExcelCsvView()
        {
            InitializeComponent();
        }

        // ---------- Ortak yardımcılar ----------

        private void DurumGoster(string mesaj, bool basarili)
        {
            lblDurum.Text = mesaj;
            lblDurum.ForeColor = basarili ? Color.FromArgb(46, 125, 50) : Color.FromArgb(198, 40, 40);
        }

        private void SayaciGuncelle()
        {
            lblSayac.Text = _secilenDosyalar.Count > 0 ? $"{_secilenDosyalar.Count} dosya seçili" : "";
        }

        private void ButonlariKilitle(bool kilitli)
        {
            btnDosyaSec.Enabled = !kilitli;
            btnDosyaKaldir.Enabled = !kilitli;
            btnListeTemizle.Enabled = !kilitli;
            btnBirlestir.Enabled = !kilitli;
            btnFiltreDosyaSec.Enabled = !kilitli;
            btnFiltrele.Enabled = !kilitli;
            btnDonusturDosyaSec.Enabled = !kilitli;
            btnDonusturKaydet.Enabled = !kilitli;
        }

        private List<List<string>> DosyayiOku(string dosyaYolu)
        {
            var sonuc = new List<List<string>>();
            string uzanti = Path.GetExtension(dosyaYolu).ToLower();

            if (uzanti != ".csv" && uzanti != ".xlsx")
            {
                throw new Exception($"'{Path.GetFileName(dosyaYolu)}' desteklenmeyen bir dosya türü. Sadece .xlsx ve .csv dosyaları kullanılabilir.");
            }

            if (uzanti == ".csv")
            {
                foreach (var satir in File.ReadAllLines(dosyaYolu))
                {
                    sonuc.Add(satir.Split(',').ToList());
                }
            }
            else if (uzanti == ".xlsx")
            {
                using var kitap = new XLWorkbook(dosyaYolu);
                var sayfa = kitap.Worksheet(1);
                var kullanilanAlan = sayfa.RangeUsed();

                foreach (var satir in kullanilanAlan.RowsUsed())
                {
                    var hucreler = satir.Cells().Select(c => c.GetString()).ToList();
                    sonuc.Add(hucreler);
                }
            }

            return sonuc;
        }

        // ---------- Dosya seçme / liste yönetimi ----------

        private void btnDosyaSec_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Excel/CSV Dosyaları|*.xlsx;*.csv",
                Multiselect = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _secilenDosyalar.AddRange(dialog.FileNames);
                lstDosyalar.Items.Clear();
                foreach (var dosya in _secilenDosyalar)
                {
                    lstDosyalar.Items.Add(Path.GetFileName(dosya));
                }
                SayaciGuncelle();
                DurumGoster($"{_secilenDosyalar.Count} dosya seçildi.", basarili: true);
            }
        }

        private void btnDosyaKaldir_Click(object sender, EventArgs e)
        {
            if (lstDosyalar.SelectedIndex == -1)
            {
                DurumGoster("Kaldırmak için listeden bir dosya seç.", basarili: false);
                return;
            }

            int index = lstDosyalar.SelectedIndex;
            _secilenDosyalar.RemoveAt(index);
            lstDosyalar.Items.RemoveAt(index);
            SayaciGuncelle();
            DurumGoster($"{_secilenDosyalar.Count} dosya kaldı.", basarili: true);
        }

        private void btnListeTemizle_Click(object sender, EventArgs e)
        {
            _secilenDosyalar.Clear();
            lstDosyalar.Items.Clear();
            SayaciGuncelle();
            DurumGoster("Liste temizlendi.", basarili: true);
        }

        // ---------- Birleştirme ----------

        private void btnBirlestir_Click(object sender, EventArgs e)
        {
            if (_secilenDosyalar.Count == 0)
            {
                DurumGoster("Önce dosya seçmelisin.", basarili: false);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "Excel Dosyası|*.xlsx",
                FileName = "birlesik_dosya.xlsx"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK) return;

            ButonlariKilitle(true);
            try
            {
                using var sonucKitap = new XLWorkbook();
                var sonucSayfa = sonucKitap.Worksheets.Add("Birleşik");
                int satirNo = 1;
                bool basliklarYazildi = false;

                foreach (var dosyaYolu in _secilenDosyalar)
                {
                    var satirlar = DosyayiOku(dosyaYolu);

                    foreach (var satir in satirlar)
                    {
                        if (satir == satirlar[0] && basliklarYazildi)
                            continue;

                        for (int i = 0; i < satir.Count; i++)
                        {
                            sonucSayfa.Cell(satirNo, i + 1).Value = satir[i];
                        }
                        satirNo++;
                    }

                    basliklarYazildi = true;
                }

                sonucKitap.SaveAs(saveDialog.FileName);
                DurumGoster($"Başarılı! {_secilenDosyalar.Count} dosya birleştirildi → {Path.GetFileName(saveDialog.FileName)}", basarili: true);
            }
            catch (Exception ex)
            {
                DurumGoster($"Hata: {ex.Message}", basarili: false);
            }
            finally
            {
                ButonlariKilitle(false);
            }
        }

        // ---------- Sütun filtreleme ----------

        private void btnFiltreDosyaSec_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Excel/CSV Dosyaları|*.xlsx;*.csv"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                _filtreDosyaYolu = dialog.FileName;
                lblFiltreDosya.Text = Path.GetFileName(_filtreDosyaYolu);

                var satirlar = DosyayiOku(_filtreDosyaYolu);
                clbSutunlar.Items.Clear();

                if (satirlar.Count > 0)
                {
                    foreach (var baslik in satirlar[0])
                    {
                        clbSutunlar.Items.Add(baslik, true);
                    }
                }

                DurumGoster($"'{Path.GetFileName(_filtreDosyaYolu)}' yüklendi, sütunları seç.", basarili: true);
            }
            catch (Exception ex)
            {
                DurumGoster($"Hata: {ex.Message}", basarili: false);
            }
        }

        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            if (_filtreDosyaYolu == null)
            {
                DurumGoster("Önce filtrelenecek dosyayı seçmelisin.", basarili: false);
                return;
            }

            var secilenIndeksler = new List<int>();
            for (int i = 0; i < clbSutunlar.Items.Count; i++)
            {
                if (clbSutunlar.GetItemChecked(i))
                    secilenIndeksler.Add(i);
            }

            if (secilenIndeksler.Count == 0)
            {
                DurumGoster("En az bir sütun seçmelisin.", basarili: false);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "Excel Dosyası|*.xlsx",
                FileName = "filtrelenmis_dosya.xlsx"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK) return;

            ButonlariKilitle(true);
            try
            {
                var satirlar = DosyayiOku(_filtreDosyaYolu);

                using var sonucKitap = new XLWorkbook();
                var sonucSayfa = sonucKitap.Worksheets.Add("Filtrelenmiş");

                for (int satirNo = 0; satirNo < satirlar.Count; satirNo++)
                {
                    var satir = satirlar[satirNo];
                    for (int sutunNo = 0; sutunNo < secilenIndeksler.Count; sutunNo++)
                    {
                        int kaynakIndeks = secilenIndeksler[sutunNo];
                        if (kaynakIndeks < satir.Count)
                        {
                            sonucSayfa.Cell(satirNo + 1, sutunNo + 1).Value = satir[kaynakIndeks];
                        }
                    }
                }

                sonucKitap.SaveAs(saveDialog.FileName);
                DurumGoster($"Başarılı! Filtrelenmiş dosya kaydedildi → {Path.GetFileName(saveDialog.FileName)}", basarili: true);
            }
            catch (Exception ex)
            {
                DurumGoster($"Hata: {ex.Message}", basarili: false);
            }
            finally
            {
                ButonlariKilitle(false);
            }
        }

        // ---------- Format dönüştürme ----------

        private void btnDonusturDosyaSec_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Excel/CSV Dosyaları|*.xlsx;*.csv"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            _donusturDosyaYolu = dialog.FileName;
            lblDonusturDosya.Text = Path.GetFileName(_donusturDosyaYolu);
            DurumGoster($"'{Path.GetFileName(_donusturDosyaYolu)}' seçildi.", basarili: true);
        }

        private void btnDonusturKaydet_Click(object sender, EventArgs e)
        {
            if (_donusturDosyaYolu == null)
            {
                DurumGoster("Önce dönüştürülecek dosyayı seçmelisin.", basarili: false);
                return;
            }

            string kaynakUzanti = Path.GetExtension(_donusturDosyaYolu).ToLower();
            bool xlsxdenCsvE = kaynakUzanti == ".xlsx";

            using var saveDialog = new SaveFileDialog
            {
                Filter = xlsxdenCsvE ? "CSV Dosyası|*.csv" : "Excel Dosyası|*.xlsx",
                FileName = xlsxdenCsvE ? "donusturulmus.csv" : "donusturulmus.xlsx"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK) return;

            ButonlariKilitle(true);
            try
            {
                var satirlar = DosyayiOku(_donusturDosyaYolu);

                if (xlsxdenCsvE)
                {
                    var csvSatirlari = satirlar.Select(satir => string.Join(",", satir));
                    File.WriteAllLines(saveDialog.FileName, csvSatirlari);
                }
                else
                {
                    using var kitap = new XLWorkbook();
                    var sayfa = kitap.Worksheets.Add("Dönüştürülmüş");

                    for (int satirNo = 0; satirNo < satirlar.Count; satirNo++)
                    {
                        for (int sutunNo = 0; sutunNo < satirlar[satirNo].Count; sutunNo++)
                        {
                            sayfa.Cell(satirNo + 1, sutunNo + 1).Value = satirlar[satirNo][sutunNo];
                        }
                    }

                    kitap.SaveAs(saveDialog.FileName);
                }

                DurumGoster($"Başarılı! Dönüştürüldü → {Path.GetFileName(saveDialog.FileName)}", basarili: true);
            }
            catch (Exception ex)
            {
                DurumGoster($"Hata: {ex.Message}", basarili: false);
            }
            finally
            {
                ButonlariKilitle(false);
            }
        }
    }
}