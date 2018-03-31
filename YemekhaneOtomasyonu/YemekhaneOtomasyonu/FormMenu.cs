using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace YemekhaneOtomasyonu
{
    public partial class FormMenu : Form
    {
        DateTime date;
        bool prev = false;

        public FormMenu()
        {
            InitializeComponent();
        }

        //
        // Getir
        private void Menu_Load(object sender, EventArgs e)
        {
            date = DateTime.Now;
            label1.Text = "Tarih :" + date.ToString("dd/MM/yyyy");
            dataGridView1.Columns.Add(getButtonColumn());
            dataGridView1.DataSource = new DAO().menuGetir(DateTime.Now);
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //
        // Sil
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DateTime dateTime = DateTime.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                if (dateTime > DateTime.Now)
                {
                    DialogResult dialog = new DialogResult();
                    dialog = MessageBox.Show("Silmek istediğinize emin misiniz?", "Menü Silme", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialog == DialogResult.OK)
                    {
                        DAO dao = new DAO();
                        dao.menuSil(dateTime);
                        dataGridView1.DataSource = dao.menuGetir(date);       // Tabloyu güncelle
                    }
                }
                else
                    viewWarning();
            }
        }

        //
        // İleri/Geri  -  Ekle
        private void _Click(object sender, EventArgs e)
        {
            if (sender is PictureBox)   // ileri/geri
            {
                int months = ((PictureBox)sender).Name == pbNext.Name ? 1 : -1;
                DataTable dataTable = new DAO().menuGetir(date.AddMonths(months));
                if (dataTable.Rows.Count > 0)
                {
                    date = date.AddMonths(months);
                    editDataGridView();
                    dataGridView1.DataSource = dataTable;
                }
            }
            else if (sender is LinkLabel)   // Ekle
            {
                new FormMenuEkleGuncelle().ShowDialog();
                dataGridView1.DataSource = new DAO().menuGetir(date);
            }
        }

        //
        // Güncelle
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                DateTime dateTime = DateTime.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                if (dateTime > DateTime.Now)
                {
                    FormMenuEkleGuncelle form = new FormMenuEkleGuncelle();
                    form.Text = "Menü Güncelle";
                    form.MaskedTextBox1.Text = dateTime.ToString("dd.MM.yyyy");
                    form.MaskedTextBox1.Enabled = false;
                    String menu = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    String[] foods = Regex.Split(menu, ",");
                    foreach (string str in foods)
                        form.ListBox1.Items.Add(str.Trim());
                    form.ShowDialog();
                    dataGridView1.DataSource = new DAO().menuGetir(date);
                }
                else
                    viewWarning();
            }
        }

        //
        // Uyarı göster
        private void viewWarning()
        {
            label2.Visible = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Visible = false;
            timer1.Stop();
        }

        //
        // Sil butonu geçmiş aylarda görünmeyecek
        private void editDataGridView()
        {
            if ((date < DateTime.Now && date.Month != DateTime.Now.Month) && !prev)
            {
                prev = true;
                dataGridView1.Columns.RemoveAt(0);
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else if ((date >= DateTime.Now || date.Month == DateTime.Now.Month) && prev)
            {
                prev = false;
                dataGridView1.Columns.Insert(0, getButtonColumn());
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        //
        // DataGridView için sil butonu döner
        private DataGridViewButtonColumn getButtonColumn()
        {
            DataGridViewButtonColumn dataGridViewButton = new DataGridViewButtonColumn();
            dataGridViewButton.HeaderText = "Sil";
            dataGridViewButton.Text = "Sil";
            dataGridViewButton.UseColumnTextForButtonValue = true;
            dataGridViewButton.Frozen = true;
            dataGridViewButton.Width = 30;
            dataGridViewButton.Resizable = DataGridViewTriState.False;
            return dataGridViewButton;
        }

        //
        // Mouse odaklandığında tooltip göster
        private void _mouseHover(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Name == pbNext.Name)
                new ToolTip().SetToolTip(pbNext, "Sonraki Ay");
            else
                new ToolTip().SetToolTip(pbPrev, "Önceki Ay");
        }
    }
}
