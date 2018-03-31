using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace YemekhaneOtomasyonu
{
    public partial class FormYemekKategori : Form
    {
        public FormYemekKategori()
        {
            InitializeComponent();
        }
        //
        // Getir
        private void YemekKategori_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DAO().kategoriGetir();
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        //
        // Ekle
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String kategori = Interaction.InputBox("Kategori Adını Giriniz", "Kategori Ekleme");
            if (kategori.Length > 0)
            {
                DAO dao = new DAO();
                dao.kategoriEkle(kategori);
                dataGridView1.DataSource = dao.kategoriGetir();       // Tabloyu güncelle
            }

        }
        //
        // Sil
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) // Sil butonu
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Bu kategoriyi silerseniz, kategoriye ait olan tüm yemekler de silinir.\nYine de silmek istiyor musunuz?", "Kategori Silme", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialog == DialogResult.OK)
                {
                    DAO dao = new DAO();
                    dao.kategoriSil(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString()));
                    dataGridView1.DataSource = dao.kategoriGetir();
                }
            }
        }
        //
        // Güncelle
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2) // Kategori sütunu
            {
                String kategori = Interaction.InputBox("Kategori Adını Giriniz", "Kategori Güncelleme");
                if (kategori.Length > 0)
                {
                    DAO dao = new DAO();
                    dao.kategoriGuncelle(Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString()), kategori);             // Ekle
                    dataGridView1.DataSource = dao.kategoriGetir();
                }
            }
        }
    }
}
