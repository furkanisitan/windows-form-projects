using System;
using System.Data;
using System.Windows.Forms;

namespace YemekhaneOtomasyonu
{
    public partial class FormPersonel : Form
    {
        public string tc;
        public string[] values;

        public FormPersonel()
        {
            InitializeComponent();
        }

        private void FormPersonel_Load(object sender, EventArgs e)
        {
            DataTable dt = new DAO().personelBilgisiniGoster(tc);
            values = new string[dt.Columns.Count];
            for (int i = 0; i < dt.Columns.Count; i++)
                values[i] = dt.Rows[0][i].ToString();
            lblId.Text = values[0];
            lblTC.Text = values[1];
            lblName.Text = values[2];
            lblSurname.Text = values[3];
            lblSalary.Text = values[4];
            lblJob.Text = new DAO().unvanGoster(tc);

            // values[6] => unvan_id
            switch (values[6])
            {
                case "1":       // Bilgi İşlem
                    setVisible(true, true, false);
                    button1.Text = "Kullanıcı İşlemleri";
                    button2.Text = "Personel İşlemleri";
                    break;
                case "2":       // Gıda Mühendisi
                    setVisible(true, true, true);
                    button1.Text = "Yemek İşlemleri";
                    button2.Text = "Kategori İşlemleri";
                    button3.Text = "Menü İşlemleri";
                    break;
                case "3":       // Gişe Memuru
                    setVisible(true, false, false);
                    button1.Text = "Gişe İşlemleri";
                    break;
            }
        }
        private void setVisible(bool b1, bool b2, bool b3)
        {
            button1.Visible = b1;
            button2.Visible = b2;
            button3.Visible = b3;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            // buton1
            if (sender is Button)
            {
                if (((Button)sender).Name == button1.Name)
                    switch (values[6])
                    {
                        case "1":
                            new FormKullaniciIslemleri().ShowDialog();
                            break;
                        case "2":
                            new FormYemek().ShowDialog();
                            break;
                        case "3":
                            new FormGiseIslemleri().ShowDialog();
                            break;
                    }
                // buton2
                else if (((Button)sender).Name == button2.Name)
                    switch (values[6])
                    {
                        case "1":
                            new FormPersonelIslemleri().ShowDialog();
                            break;
                        case "2":
                            new FormYemekKategori().ShowDialog();
                            break;
                    }

                // buton3
                else if (((Button)sender).Name == button3.Name)
                    new FormMenu().ShowDialog();
            }
            // Şife GÜncelle
            else
            {
                FormPersonelSifreGuncelle form = new FormPersonelSifreGuncelle();
                form.TC = lblTC.Text;
                form.pass = values[5];
                form.ShowDialog();
            }
        }
        
    }
}
