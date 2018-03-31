using System;
using System.Data;
using System.Windows.Forms;

namespace YemekhaneOtomasyonu
{
    public partial class FormYemek : Form
    {
        public FormYemek()
        {
            InitializeComponent();
        }
        //
        // Getir
        private void Yemek_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DAO().yemekGetir();
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        //
        // Ekle
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable categories = new DAO().kategoriGetir();
            if (categories.Rows.Count > 0)
            {
                new FormYemekEkleGuncelle().ShowDialog();
                dataGridView1.DataSource = new DAO().yemekGetir();  // Tabloyu güncelle
            }
            else
                MessageBox.Show("Önce kategori ekleyin");

        }
        //
        // Sil-Güncelle
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DAO dao = new DAO();
            if (e.ColumnIndex == 0)       // Güncelle
            {
                FormYemekEkleGuncelle form = new FormYemekEkleGuncelle();
                form.Text = "Yemek Güncelle";
                form.Button1Text = "Güncelle";
                form.TextBox1Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                form.MaskedTextBox1Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                form.idFood = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                form.category = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                form.ShowDialog();
            }
            else if (e.ColumnIndex == 1)  // Sil
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Silmek istiyor musunuz?", "Yemek Silme", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                    dao.yemekSil(Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString()));
            }
            dataGridView1.DataSource = dao.yemekGetir();    // Tablo güncelle
        }
    }
}
