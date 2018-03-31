using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YemekhaneOtomasyonu
{
    public partial class FormGorus : Form
    {
        public FormGorus()
        {
            InitializeComponent();
        }

        private void FormGorus_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new DAO().gorusGetir();
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
    }
}
