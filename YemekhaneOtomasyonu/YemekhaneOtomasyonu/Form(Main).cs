using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace YemekhaneOtomasyonu
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            // Giriş
            if (((Button)sender).Name == btnLogin.Name)
            {
                DataTable dt = new DAO().personelBilgisiniGoster(maskedTextBox1.Text);
                if (dt != null)
                {
                    FormPersonel form = new FormPersonel();
                    form.tc = maskedTextBox1.Text;
                    form.ShowDialog();
                }
                else
                    MessageBox.Show("Kullanıcı Adı ya da Şifre hatalı");
            }
            // Yemek al
            else if (((Button)sender).Name == btnEat.Name)
            {
                String TC = Interaction.InputBox("TC", "Yemek Alma İşlemi");
                new DAO().bakiyeDusur(TC);
            }
            // Görüş bildir
            else if (((Button)sender).Name == btnOpinionSend.Name)
            {
                String konu = Interaction.InputBox("Konu", "Görüş Bildir");
                if (konu.Length > 0)
                    new DAO().gorusEkle(DateTime.Now, konu);
            }
            // Görüşler
            else
                new FormGorus().ShowDialog();
        }
    }
}
