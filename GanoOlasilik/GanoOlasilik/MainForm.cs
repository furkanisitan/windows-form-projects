using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GanoOlasilik
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)dgvMain.Columns[2];
            column.Items.Add("");
            column.Items.AddRange(Gano.unSuccessLetterGrades.Keys.ToArray());
        }

        private void dgvMain_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            dgvMain.Rows[e.RowIndex].ErrorText = "";
            // TODO Value? => Eğer Value null ise o anda null döner.
            if (dgvMain.Rows[e.RowIndex].IsNewRow || (e.ColumnIndex != 0 && e.ColumnIndex != 1)) { return; }

            if (string.IsNullOrWhiteSpace(dgvMain[0, e.RowIndex].Value?.ToString()) ||
                string.IsNullOrWhiteSpace(dgvMain[1, e.RowIndex].Value?.ToString()))
            {
                e.Cancel = true;
                dgvMain.Rows[e.RowIndex].ErrorText = Warning.warnings[Warning.Warnings.LessonNameorCredit_NullorEmpty];
                return;
            }
            else
            {
                int newInteger;
                if (!int.TryParse(dgvMain[1, e.RowIndex].Value?.ToString(), out newInteger) || newInteger < 0)
                {
                    e.Cancel = true;
                    dgvMain.Rows[e.RowIndex].ErrorText = Warning.warnings[Warning.Warnings.LessonCreditIsNotPositiveInt];
                    return;
                }
            }

            // Aynı dersten sadece bir tane olmalıdır
            DataGridViewRow row = dgvMain.Rows.Cast<DataGridViewRow>().FirstOrDefault(x => x.Cells[0].Value?.ToString() == dgvMain[0, e.RowIndex].Value?.ToString());
            int index = row?.Index ?? -1;
            if (index != e.RowIndex)
            {
                e.Cancel = true;
                dgvMain.Rows[e.RowIndex].ErrorText = Warning.warnings[Warning.Warnings.LessonNameIsNotUnique];
            }
        }

        // Sil
        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && !dgvMain.Rows[e.RowIndex].IsNewRow)
                dgvMain.Rows.RemoveAt(e.RowIndex);
        }

        // Başla
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvMain.RowCount < 2)
                showWarning(Warning.warnings[Warning.Warnings.LessonNotEnter]);
            else if (isAnyNotEmptyPointCell())
            {
                if (string.IsNullOrEmpty(tbPoint.Text) || string.IsNullOrEmpty(tbCredit.Text))
                    showWarning(Warning.warnings[Warning.Warnings.EmptyPointorCredit]);
                else if (!(isPositiveInt(tbCredit.Text) && isPositiveDouble(tbPoint.Text)))
                    showWarning(Warning.warnings[Warning.Warnings.WrongPointorCredit]);
                else
                    exec();
            }
            else
                exec();
        }

        ResultForm resultForm;

        private void exec()
        {
            using (FormWait frm = new FormWait(run))
            {
                frm.ShowDialog(this);
            }
            resultForm.Show();
        }

        private void run()
        {
            Gano gano;
            if (string.IsNullOrEmpty(tbPoint.Text))
                gano = new Gano(dgvMain);
            else
                gano = new Gano(dgvMain, double.Parse(tbPoint.Text), int.Parse(tbCredit.Text));
            resultForm = new ResultForm(gano.exec());
        }

        // Hiç not girilmiş ders var mı?
        private bool isAnyNotEmptyPointCell()
        {
            return dgvMain.Rows.Cast<DataGridViewRow>().Any(x => !string.IsNullOrEmpty(x.Cells[2].Value?.ToString()));
        }

        private bool isPositiveDouble(string text)
        {
            double tmp;
            return double.TryParse(text, out tmp) && tmp > 0;
        }

        private bool isPositiveInt(string text)
        {
            int tmp;
            return int.TryParse(text, out tmp) && tmp > 0;
        }

        private void showWarning(string textWarning)
        {
            lblWarning.Text = textWarning;
            lblWarning.Visible = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblWarning.Visible = false;
            timer1.Stop();
        }
    }
}
