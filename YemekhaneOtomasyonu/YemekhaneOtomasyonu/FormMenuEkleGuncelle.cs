using System;
using System.Data;
using System.Windows.Forms;

namespace YemekhaneOtomasyonu
{
    public partial class FormMenuEkleGuncelle : Form
    {
        DataTable categories = new DAO().kategoriGetir();
        DataTable food;

        public FormMenuEkleGuncelle()
        {
            InitializeComponent();
        }

        //
        // Getir (Kategori)
        private void MenuEkleGuncelle_Load(object sender, EventArgs e)
        {
            // Kategoriler ComBobax a ekleniyor
            for (int i = 0; i < categories.Rows.Count; i++)
                cbCategory.Items.Add(categories.Rows[i][1]);
            cbCategory.SelectedIndex = 0;    // Varsayılan olarak ilk kategori seçili
        }

        private void _Click(object sender, EventArgs e)
        {
            if (((Button)sender).Name == btnAddFood.Name)           // ListBox'a yemek ekleme
            {
                if (cbFood.Items.Count > 0)
                {
                    String text = cbFood.SelectedItem.ToString() + "(" + (food.Select($"{food.Columns[1].ColumnName}='{cbFood.SelectedItem}'")[0][2]) + " kal)";
                    listBox1.Items.Add(text);
                }
            }
            else if (((Button)sender).Name == btnClearMenu.Name)    // ListBox temizleme
                listBox1.Items.Clear();

            else if (((Button)sender).Name == btnDeleteMenu.Name)   // ListBox'tan yemek silme
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);

            else if (((Button)sender).Name == btnSaveMenu.Name)     // Kaydet
            {
                if (maskedTextBox1.Text.IndexOf('_') < 0 && listBox1.Items.Count > 0)
                {
                    String text = "";
                    for (int i = 0; i < listBox1.Items.Count; i++)
                        text += listBox1.Items[i].ToString() + (listBox1.Items.Count != i + 1 ? ", " : "");

                    if (maskedTextBox1.Enabled == true)     // Ekleme
                        new DAO().menuEkle(DateTime.Parse(maskedTextBox1.Text), text);
                    else                                    // Güncelleme
                        new DAO().menuGuncelle(DateTime.Parse(maskedTextBox1.Text), text);
                    this.Close();
                }
                else { MessageBox.Show("Yemek eklemediniz veya tarihi eksik girdiniz!"); }
            }
        }

        //
        // Getir (Yemek)
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbFood.ResetText();
            cbFood.Items.Clear();
            food = new DAO().yemekGetir(Convert.ToInt32(categories.Select($"{categories.Columns[1].ColumnName}='{cbCategory.SelectedItem}'")[0][0]));
            for (int i = 0; i < food.Rows.Count; i++)
                cbFood.Items.Add(food.Rows[i][1]);
            if (cbFood.Items.Count > 0)
                cbFood.SelectedIndex = 0;          // Varsayılan olarak ilk yemek seçili
        }

        //
        // Güncelleme ekranı için bileşenlerin özellikleri tanımlandı.
        // Günceleme ekranına geçildiğinde yemek bilgileri bu bileşenlere doldurulacak.
        public ListBox ListBox1 { get { return listBox1; } set { listBox1 = value; } }
        public MaskedTextBox MaskedTextBox1 { get { return maskedTextBox1; } set { maskedTextBox1 = value; } }
    }
}
