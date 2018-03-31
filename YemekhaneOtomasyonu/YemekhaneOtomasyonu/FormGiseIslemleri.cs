using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace YemekhaneOtomasyonu
{
    public partial class FormGiseIslemleri : Form
    {
        public FormGiseIslemleri()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, System.EventArgs e)
        {
            // Sorgula
            if (((Button)sender).Name == btnQuery.Name)
                viewBalance();

            // Ekle
            else if (((Button)sender).Name == btnAdd.Name)
            {
                try
                {
                    new DAO().bakiyeGuncelle(maskedTextBox1.Text, float.Parse(textBox1.Text) + float.Parse(new DAO().bakiyeSorgula(maskedTextBox1.Text)));
                    viewBalance();
                }
                catch (Exception)
                {
                    MessageBox.Show("Bakiye Giriniz ve TC yi kontrol ediniz");
                }
                
            }
            // Güncelle
            else if (((Button)sender).Name == btnUpdate.Name)
            {
                try
                {
                    float.Parse(new DAO().bakiyeSorgula(maskedTextBox1.Text));
                    new DAO().bakiyeGuncelle(maskedTextBox1.Text, float.Parse(textBox1.Text));
                    viewBalance();
                }
                catch (SqlException)
                {
                    MessageBox.Show("Bakiye eksi olamaz.");
                }
                catch (Exception)
                {
                    MessageBox.Show("Bakiye Giriniz ve TC yi kontrol ediniz");
                }
            }
        }
        private void viewBalance()
        {
            string bakiye = new DAO().bakiyeSorgula(maskedTextBox1.Text);
            if (bakiye != null)
            {
                label1.Text = "Bakiye: " + bakiye + "TL";
                label1.Visible = true;
                textBox1.Clear();
            }
            else
                label1.Visible = false;
        }
    }
}
