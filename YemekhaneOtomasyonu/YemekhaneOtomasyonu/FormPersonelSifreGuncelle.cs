using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace YemekhaneOtomasyonu
{
    public partial class FormPersonelSifreGuncelle : Form
    {
        public string pass, TC;

        public void metod()
        {

        }

        public FormPersonelSifreGuncelle()
        {
            InitializeComponent();
        }

        private void btnUpdatePass_Click(object sender, EventArgs e)
        {
            if (tbPass.Text == pass)
            {
                if (tbPassNew.Text == tbPassAgain.Text)
                {
                    new DAO().sifreGuncelle(TC, tbPassNew.Text);
                    MessageBox.Show("Şifreniz Güncellenmiştir.");
                    this.Close();
                }
                else
                    MessageBox.Show("Şifreler Eşleşmiyor");
            }
            else
                MessageBox.Show("Şifreniz Yanlış");
        }
    }
}
