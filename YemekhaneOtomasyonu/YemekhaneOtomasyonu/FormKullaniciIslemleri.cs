using System;
using System.Windows.Forms;

namespace YemekhaneOtomasyonu
{
    public partial class FormKullaniciIslemleri : Form
    {

        public FormKullaniciIslemleri()
        {
            InitializeComponent();
        }

        private void KullaniciIslemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DAO().kullanicilariGoster();
            dataGridView1.Columns[0].HeaderText = "Kullacını ID";
            dataGridView1.Columns[1].HeaderText = "TC Kimlik No";
            dataGridView1.Columns[2].HeaderText = "Ad";
            dataGridView1.Columns[3].HeaderText = "Soyad";
            dataGridView1.Columns[4].HeaderText = "Bakiye";
            dataGridView1.Columns[5].HeaderText = "Kullanıcı Türü ID";

            comboBox1.DataSource = new DAO().kullaniciTuruGoster();
            comboBox1.DisplayMember = "ad";
            comboBox1.ValueMember = "kullanici_turu_id";

            comboBox2.DataSource = new DAO().kullaniciTuruGoster();
            comboBox2.DisplayMember = "ad";
            comboBox2.ValueMember = "kullanici_turu_id";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tbTC.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["tc"].Value.ToString();
            tbName.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ad"].Value.ToString();
            tbSurname.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["soyad"].Value.ToString();
            tbBalance.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["bakiye"].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["kullanici_turu_id"].Value.ToString();
        }

        // TC
        private void mtb_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "")
                dataGridView1.DataSource = new DAO().kullaniciBilgisiniGoster(maskedTextBox1.Text);
            else
                dataGridView1.DataSource = new DAO().kullanicilariGoster();
        }

        // Kullanıcı türleri
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedText.ToString() != "System.Data.DataRowView")
                tbUserType.Text = comboBox2.SelectedText;

            if (comboBox2.SelectedValue.ToString() != "System.Data.DataRowView")
                tbPrice.Text = new DAO().alinacakFiyatGoster(Convert.ToInt16(comboBox2.SelectedValue.ToString()));
        }

        private void btn_Click(object sender, EventArgs e)
        {
            // Kullanıcı ekle
            if (((Button)sender).Name == btnUserAdd.Name)
                new DAO().kullaniciEkle(tbTC.Text, tbName.Text.ToString(), tbSurname.Text.ToString(), float.Parse(tbBalance.Text), Convert.ToInt16(comboBox1.SelectedValue));
            
            // Kullanıcı sil
            else if (((Button)sender).Name == btnUserDel.Name)
                new DAO().kullaniciSil(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["tc"].Value.ToString());
            
            // Kullanıcı güncelle
            else if (((Button)sender).Name == btnUserUpdate.Name)
                new DAO().kullaniciGuncelle(Convert.ToInt16(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["kullanici_id"].Value.ToString()), tbTC.Text, tbName.Text.ToString(), tbSurname.Text.ToString(), float.Parse(tbBalance.Text), Convert.ToInt16(comboBox1.SelectedValue));
            
            // Tür ekle
            else if (((Button)sender).Name == btnAdd.Name)
                new DAO().kullaniciTuruEkle(tbUserType.Text.ToString(), float.Parse(tbPrice.Text));
            
            // Tür sil
            else if (((Button)sender).Name == btnDel.Name)
                new DAO().kullaniciTuruSil(Convert.ToInt16(comboBox2.SelectedValue));
            
            // Tür güncelle
            else if (((Button)sender).Name == btnUpdate.Name)
                new DAO().kullaniciTuruGuncelle(Convert.ToInt16(comboBox2.SelectedValue), tbUserType.Text.ToString(), float.Parse(tbPrice.Text));

            comboBox1.DataSource = new DAO().kullaniciTuruGoster();
            comboBox2.DataSource = new DAO().kullaniciTuruGoster();
            dataGridView1.DataSource = new DAO().kullanicilariGoster();
            clear();
        }

        private void clear()
        {
            tbTC.Clear();  tbName.Clear();  tbSurname.Clear();  tbPrice.Clear();  tbBalance.Clear();  tbUserType.Clear();  tbPrice.Clear();
        }
    }
}
