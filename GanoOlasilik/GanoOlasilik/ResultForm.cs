using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace GanoOlasilik
{
    public partial class ResultForm : Form
    {
        BindingSource bs = new BindingSource();

        public ResultForm(DataTable table)
        {
            InitializeComponent();
            bs.ListChanged += new ListChangedEventHandler(bindingSource_ListChanged);
            bs.DataSource = table;
            advancedDataGridView.DataSource = bs;
        }

        private void advancedDataGridView_FilterStringChanged(object sender, EventArgs e)
        {
            bs.Filter = advancedDataGridView.FilterString;
        }

        private void advancedDataGridView_SortStringChanged(object sender, EventArgs e)
        {
            bs.Sort = advancedDataGridView.SortString;
        }

        private void bindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            lblTotal.Text = $"Toplam Satır : {bs.Count}";
        }
    }
}
