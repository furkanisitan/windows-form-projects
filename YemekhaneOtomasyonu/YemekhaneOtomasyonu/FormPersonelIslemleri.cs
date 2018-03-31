using System;
using System.Windows.Forms;

namespace YemekhaneOtomasyonu
{
    public partial class FormPersonelIslemleri : Form
    {

        public FormPersonelIslemleri()
        {
            InitializeComponent();
        }

        private void PersonelIslemleri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DAO().personelleriGoster();
            dataGridView1.Columns[0].HeaderText = "Personel ID";
            dataGridView1.Columns[1].HeaderText = "TC Kimlik No";
            dataGridView1.Columns[2].HeaderText = "Ad;";
            dataGridView1.Columns[3].HeaderText = "Soyad";
            dataGridView1.Columns[4].HeaderText = "Maaş";
            dataGridView1.Columns[5].HeaderText = "Şifre";
            dataGridView1.Columns[6].HeaderText = "Ünvan ID";
            dataGridView1.Columns[7].HeaderText = "Şube ID";

            // Ünvan
            comboBox1.DataSource = new DAO().unvanlariGoster();
            comboBox1.DisplayMember = "ad";
            comboBox1.ValueMember = "unvan_id";

            // Şube
            comboBox2.DataSource = new DAO().subeleriGoster();
            comboBox2.DisplayMember = "ad";
            comboBox2.ValueMember = "sube_id";

            // Ünvanlar
            comboBox3.DataSource = new DAO().unvanlariGoster();
            comboBox3.DisplayMember = "ad";
            comboBox3.ValueMember = "unvan_id";

            // Şubeler
            comboBox4.DataSource = new DAO().subeleriGoster();
            comboBox4.DisplayMember = "ad";
            comboBox4.ValueMember = "sube_id";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["tc"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ad"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["soyad"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["maas"].Value.ToString();
            textBox1.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["sifre"].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["unvan_id"].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["sube_id"].Value.ToString();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "")
                dataGridView1.DataSource = new DAO().personelBilgisiniGoster(maskedTextBox1.Text);
            else
                dataGridView1.DataSource = new DAO().personelleriGoster();
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).Name == comboBox3.Name)
                textBox7.Text = comboBox3.SelectedText;
            else if (((ComboBox)sender).Name == comboBox4.Name)
                textBox8.Text = comboBox4.SelectedText;
        }

        // Personel
        private void btnPer_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Name == btnPerAdd.Name)
                new DAO().personelEkle(textBox5.Text, textBox2.Text.ToString(), textBox3.Text.ToString(), float.Parse(textBox4.Text), textBox1.Text.ToString(), Convert.ToInt16(comboBox1.SelectedValue), Convert.ToInt16(comboBox2.SelectedValue));
            else if (((Button)sender).Name == btnPerDel.Name)
                new DAO().personelSil((dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["tc"].Value.ToString()));
            else if (((Button)sender).Name == btnPerUpdate.Name)
                new DAO().personelGuncelle(Convert.ToInt16(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["personel_id"].Value.ToString()), textBox5.Text, textBox2.Text.ToString(), textBox3.Text.ToString(), float.Parse(textBox4.Text), textBox1.Text.ToString(), Convert.ToInt16(comboBox1.SelectedValue), Convert.ToInt16(comboBox2.SelectedValue));
            dataGridView1.DataSource = new DAO().personelleriGoster();
            clear();
        }

        // Ünvan
        private void btnJob_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Name == btnJobAdd.Name)
                new DAO().unvanEkle(textBox7.Text.ToString());
            else if (((Button)sender).Name == btnJobDel.Name)
                new DAO().unvanSil(Convert.ToInt16(comboBox3.SelectedValue));
            else if (((Button)sender).Name == btnJobUpdate.Name)
                new DAO().unvanGuncelle(Convert.ToInt16(comboBox3.SelectedValue), textBox7.Text.ToString());
            comboBox1.DataSource = new DAO().unvanlariGoster();
            comboBox3.DataSource = new DAO().unvanlariGoster();
            clear();
        }

        // Şube
        private void btnBranch_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Name == btnBranchAdd.Name)
                new DAO().subeEkle(textBox8.Text.ToString());
            else if (((Button)sender).Name == btnBranchDel.Name)
                new DAO().subeSil(Convert.ToInt16(comboBox4.SelectedValue));
            else if (((Button)sender).Name == btnBranchUpdate.Name)
                new DAO().subeGuncelle(Convert.ToInt16(comboBox4.SelectedValue), textBox8.Text.ToString());
            comboBox2.DataSource = new DAO().subeleriGoster();
            comboBox4.DataSource = new DAO().subeleriGoster();
            clear();
        }
        private void clear()
        {
            textBox1.Clear();  textBox2.Clear();  textBox3.Clear();  textBox4.Clear();  textBox5.Clear();  textBox7.Clear();  textBox8.Clear();
        }
    }
}