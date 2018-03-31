using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace BilgiYarismasi
{
    public partial class QuizShow : Form
    {
        String connectionString = "Data Source=ASUS-X555LN;Initial Catalog=BilgiYarismasi;Integrated Security=True";
        Button buttonAnswer, buttonTrue;
        String[] data;              // Okunan sorunun içeriğini tutacak
        int time, questionTime = 30, questionCount = 10, index = 0;    // index => questionsId dizisinde dolaşmak için
        bool next = true;       // Sonraki soruya geçilsin mi?
        int[] questionsId;      // Soruların rastgele bulunan id numaralarını sakalr.

        public QuizShow()
        {
            InitializeComponent();
            lblLingeringQuestion.Text = questionCount.ToString();
            richTextBox1.BackColor = SystemColors.ButtonHighlight;
            int maxId = getMaxId();
            questionsId = setUnequalNumbers(questionCount, 1, maxId + 1);
        }

        private void btnMouseClick(object sender, MouseEventArgs e)
        {
            lblTime.Text = "";
            timerTime.Stop();
            enableAnswers(false);
            buttonAnswer = (Button)sender;
            findTrueButton();
            timerWait.Start();
        }

        private void QuizShow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && next)    // Enter a basıldı
            {
                nextQuestion(questionsId[index++]);
                next = false;
                enableAnswers(true);
                lblAnnotate.Text = "";
            }
        }
        //
        // Sıradaki soru
        private void nextQuestion(int id)
        {
            pictureBox1.Visible = false;
            lblTime.Text = "30";
            timerTime.Start();
            lblQuestionNum.Text = (Convert.ToInt16(lblQuestionNum.Text) + 1).ToString();
            lblLingeringQuestion.Text = (questionCount - Convert.ToInt16(lblQuestionNum.Text)).ToString();
            richTextBox1.Clear();
            defaultColor(SystemColors.ButtonHighlight);
            int[] answersIndex = setUnequalNumbers(4, 1, 5);    // [1,5) arası tam sayılar. 
            data = readData(id, 1, 5);                          // Soru okunda
            richTextBox1.Text = data[0];                          // Soru textbox a yazıldı

            // Cevaplar rastgele şekilde eklendi (Veritabanı sırasından bağımsız olarak)
            btnA.Text = data[answersIndex[0]];
            btnB.Text = data[answersIndex[1]];
            btnC.Text = data[answersIndex[2]];
            btnD.Text = data[answersIndex[3]];
        }
        //
        // verilen id ile eşleşen satırın [start,end] arasındaki sütunlarını diyiye aktarın ve döner.
        private string[] readData(int id, int start, int end)
        {
            try
            {
                string[] data;
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    data = new string[end - start + 1];
                    using (var command = new SqlCommand($"select * from TblSorular where Id={id}", connection))
                    {
                        SqlDataReader dataReader = command.ExecuteReader();
                        if (dataReader.Read())
                            for (int i = 0; i < end - start + 1; i++)
                                data[i] = dataReader[i + start].ToString();
                    }
                }
                return data;
            }
            catch (Exception err)
            {
                MessageBox.Show("Veritabanı hatası" + "\n" + err.ToString());
                return null;
            }
        }
        //
        // Database deki maximum id
        private int getMaxId()
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("select MAX(Id) from TblSorular", connection))
                    {
                        SqlDataReader dataReader = command.ExecuteReader();
                        if (dataReader.Read())
                            return Convert.ToInt32(dataReader[0]);
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Veritabanı hatası" + "\n" + err.ToString());
            }
            return 0;
        }
        //
        // Verilen size boyutundaki bir diziye, verilen aralıkta [minNum,MaxNum] birbirinden farklı tamsayılar atar.
        private int[] setUnequalNumbers(int size, int minNum, int maxNum)
        {
            Random rnd = new Random();
            int[] array = new int[size];
            int num;
            for (int i = 0; i < array.Length && i < maxNum - minNum;)
            {
                num = rnd.Next(minNum, maxNum);
                if (Array.IndexOf(array, num) < 0)
                    array[i++] = num;
            }
            return array;
        }
        //
        // Verilen butonu yeşil olarak yanıp söndürür ve en sonunda buton yeşil kalır.
        private void timerTrue_Tick(object sender, EventArgs e)
        {
            if (time > 6)
            {
                lblAnnotate.Text = "Sonraki soru için 'Enter' a basın";
                lblTrueNum.Text = (Convert.ToInt16(lblTrueNum.Text) + 1).ToString();
                timerTrue.Stop();
                next = true;
                time = 0;
                if (Convert.ToInt16(lblQuestionNum.Text) == questionCount)
                    end();
            }
            else if (time++ % 2 == 0)
                buttonAnswer.BackColor = Color.Lime;
            else
                buttonAnswer.BackColor = SystemColors.ButtonHighlight;
        }
        //
        // Verilen butonu kırmızı olarak yanıp söndürür (en son kırmızı kalır) ve doğru butonu yeşil yapar.
        private void timerFalse_Tick(object sender, EventArgs e)
        {
            if (sender == null)
            {
                timeUp();
            }
            else if (time > 6)
            {
                lblAnnotate.Text = "Sonraki soru için 'Enter' a basın";
                lblFalseNum.Text = (Convert.ToInt16(lblFalseNum.Text) + 1).ToString();
                timerFalse.Stop();
                buttonTrue.BackColor = Color.Lime;
                time = 0;
                next = true;
                if (Convert.ToInt16(lblQuestionNum.Text) == questionCount)
                    end();
            }
            else if (time++ % 2 == 0)
                buttonAnswer.BackColor = Color.Red;
            else
                buttonAnswer.BackColor = SystemColors.ButtonHighlight;
        }

       

        //
        // Belli bir miktar verilen butonu mavi yapar, sonra verilen cevaba göre diğer timerları çalıştırır.
        private void timerWait_Tick(object sender, EventArgs e)
        {
            buttonAnswer.BackColor = Color.FromArgb(0, 192, 192);
            if (time++ > 6)
            {
                timerWait.Stop();
                time = 0;
                if (buttonAnswer == buttonTrue)     // Cevap doğru
                    timerTrue.Start();
                else
                    timerFalse.Start();
            }
        }
        //
        // Soru süresi
        private void timerTime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = (Convert.ToInt16(lblTime.Text) - 1).ToString();

            if (lblTime.Text == "0")    // Yanlış cevap işlemlerini uygula
            {
                timerTime.Stop();
                findTrueButton();
                timeUp();
            }
        }
        //
        // Şıkların tıklanabilme durumu
        private void enableAnswers(bool enable)
        {
            Button[] buttons = { btnA, btnB, btnC, btnD };
            for (int i = 0; i < buttons.Length; i++)
                buttons[i].Enabled = enable;
        }

        //
        // Varsayılan arka plan rengi
        private void defaultColor(Color color)
        {
            Button[] buttons = { btnA, btnB, btnC, btnD };
            for (int i = 0; i < buttons.Length; i++)
                buttons[i].BackColor = color;
        }
        private void timeUp()
        {
            pictureBox1.Visible = true;
            lblTime.Text = "";
            lblAnnotate.Text = "Sonraki soru için 'Enter' a basın";
            lblFalseNum.Text = (Convert.ToInt16(lblFalseNum.Text) + 1).ToString();
            next = true;
            if (Convert.ToInt16(lblQuestionNum.Text) == questionCount)
                end();
            else
                buttonTrue.BackColor = Color.Lime;
        }

        private void findTrueButton()
        {
            Button[] buttons = { btnA, btnB, btnC, btnD };
            for (int i = 0; i < buttons.Length; i++)        // Doğru cevabın olduğu button bulunuyor
                if (data[1] == buttons[i].Text)             // Data[1] de doğru cevap kayıtlıdır.
                {                                           // Veritabanıda sorudan sonraki sutun doğru cevap olarak ayarlandı
                    buttonTrue = buttons[i];
                    break;
                }
        }

        private void end()
        {
            enableAnswers(false);
            next = false;
            lblAnnotate.Visible = false;
            richTextBox1.Text = "Yarışmamız bitti.\nToplam puanınız :" + (100.0 / questionCount * Convert.ToInt16(lblTrueNum.Text)).ToString("0.00");
            richTextBox1.Font = new Font("Segoe Print", 24f);
        }
    }
}