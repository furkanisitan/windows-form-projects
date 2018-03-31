using System;
using System.Data;
using System.Windows.Forms;

namespace YemekhaneOtomasyonu
{
    public partial class FormYemekEkleGuncelle : Form
    {
        public int idFood;
        public String category;
        DataTable categories = new DAO().kategoriGetir();

        public FormYemekEkleGuncelle()
        {
            InitializeComponent();
        }
        //
        // Getir
        private void YemekEkleGuncelle_Load(object sender, EventArgs e)
        {

            // Kategoriler combobox a aktarılıyor.
            for (int i = 0; i < categories.Rows.Count; i++)
                comboBox1.Items.Add(categories.Rows[i][1]);
            comboBox1.SelectedIndex = 0;    // Varsayılan olarak ilk kategori seçili

            // Güncelleme işlemi ise yemeğin kategorisi seçili gelir.
            if (!String.IsNullOrEmpty(category))
                comboBox1.SelectedItem = category;
        }
        //
        // Ekleme-Güncelleme
        private void button1_Click(object sender, EventArgs e)
        {
            // Yemek ve kalori kısımları dolduruldu mu?
            if (textBox1.Text.Length > 0 && maskedTextBox1.Text.Length > 0)
            {
                // DataTable dan seçilen kategorinin id si alınıyor.
                int id = Convert.ToInt32(categories.Select($"{categories.Columns[1].ColumnName}='{comboBox1.SelectedItem}'")[0][0]);
                if (button1.Text == "Ekle")       // Ekleme
                    new DAO().yemekEkle(textBox1.Text, Convert.ToInt32(maskedTextBox1.Text), id);
                else                            // Güncelleme
                    new DAO().yemekGuncelle(idFood, textBox1.Text, Convert.ToInt32(maskedTextBox1.Text), id);
                this.Close();
            }
            else
                MessageBox.Show("Lütfen tum alanları doldurun");
        }
        //
        // Güncelleme ekranı için bileşenlerin özellikleri tanımlandı.
        // Günceleme ekranına geçildiğinde yemek bilgileri bu bileşenlere doldurulacak.
        public String Button1Text { get { return button1.Text; } set { button1.Text = value; } }
        public String TextBox1Text { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public String MaskedTextBox1Text { get { return maskedTextBox1.Text; } set { maskedTextBox1.Text = value; } }
    }
}
