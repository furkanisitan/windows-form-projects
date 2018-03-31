using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GanoOlasilik
{
    public class Gano
    {
        // Harf notları
        public static Dictionary<string, double> successLetterGrades = new Dictionary<string, double>()
        {
            ["AA"] = 4,
            ["BA"] = 3.5,
            ["BB"] = 3,
            ["CB"] = 2.5,
            ["CC"] = 2
        };

        public static Dictionary<string, double> unSuccessLetterGrades = new Dictionary<string, double>()
        {
            ["DC"] = 1.5,
            ["DD"] = 1.0,
            ["FF"] = 0,
        };

        private int getCellCredit(int rowIndex)
        {
            return int.Parse(dgv[1, rowIndex].Value.ToString());
        }

        private double getCellPoint(int rowIndex)
        {
            if (string.IsNullOrEmpty(dgv[2, rowIndex].Value?.ToString()))
                return -1;
            return unSuccessLetterGrades[dgv[2, rowIndex].Value.ToString()];
        }

        private DataGridView dgv = null;
        double totalPoint = 0;
        int totalCredit = 0;

        private List<string> row = new List<string>();
        private DataTable dt = new DataTable();

        public Gano(DataGridView dgv, double totalPoint = 0, int totalCredit = 0)
        {
            this.dgv = dgv;
            this.totalPoint = totalPoint;
            this.totalCredit = totalCredit;

            // DataTable sütunları
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                int credit = getCellCredit(i);
                double point = getCellPoint(i);

                this.totalCredit += credit;
                if (point >= 0)
                {
                    this.totalPoint -= point * credit;
                    this.totalCredit -= credit;
                }
                dt.Columns.Add(dgv[0, i].Value.ToString(), typeof(string));
            }
            dt.Columns.Add("Top. Puan", typeof(string));
            dt.Columns.Add("Gano", typeof(string));
        }

        // Satırın dataTable' a eklenme işlemleri
        private void endRow(double point, int credit)
        {
            row.Add(totalPoint.ToString());
            row.Add((Math.Round(totalPoint / totalCredit, 2)).ToString());
            dt.Rows.Add(dt.NewRow().ItemArray = row.ToArray());

            // Son ders ve topPuan, alınan kredi, gano silinir
            row.RemoveRange(row.Count - 3, 3);
            totalPoint -= point * credit;
        }

        // ForEach döngüsü bittiğinde, bir önceki ForEach de eklenen derste silinmelidir.
        private void endForeach()
        {
            if (row.Count > 0)
            {
                int lastIndex = row.Count - 1;
                totalPoint -= successLetterGrades[row[lastIndex]] * getCellCredit(lastIndex);
                row.RemoveAt(lastIndex);
            }
        }

        private void run()
        {
            foreach (var item in successLetterGrades)
            {
                row.Add(item.Key);
                totalPoint += item.Value * getCellCredit(row.Count - 1);

                if (row.Count == dgv.RowCount - 1)
                    endRow(item.Value, getCellCredit(row.Count - 1));
                else
                    run();
            }
            endForeach();
        }

        public DataTable exec()
        {
            run();
            return dt;
        }
    }
}
