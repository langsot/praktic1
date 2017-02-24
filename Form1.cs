using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "text|*.txt";
            openFileDialog1.Title = "opening file";
            saveFileDialog1.Filter = "text|*.txt";
            saveFileDialog1.Title = "opening file";
        }
        string fn = string.Empty; // global peremen file name
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Состояние: Открытие файла";
            openFileDialog1.FileName = String.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            // вызов диалогового окна открытия файла
            {
                fn = openFileDialog1.FileName;
                this.Text = fn; // выведем имя файла в заголовок формы
                try
                {
                    System.IO.StreamReader sr = new System.IO.StreamReader(fn, System.Text.Encoding.GetEncoding(1251));
                    // создание нового входного потока, установка кодировки
                    richTextBox2.Text = sr.ReadToEnd();
                    // вывод содержимого файла в текстовый редактор
                    sr.Close();	// закрытие входного потока
                }
                catch
                {
                    MessageBox.Show("Ошибка доступа к файлу!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e) // метод закрытия формы по горячей клавише закрыть
        {
            Close();
        }

        private void SaveDocument()
        {
            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fn, false, System.Text.Encoding.GetEncoding(1251));
                sw.Write(richTextBox2.Text);
                sw.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void показатьскрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (показатьскрытьToolStripMenuItem.Checked)
                toolStrip1.Visible = true;
            else
                toolStrip1.Visible = false;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e) // метод сохранения
        {
            toolStripStatusLabel3.Text = "Файл сохранен!";
            if (fn == string.Empty)
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fn = saveFileDialog1.FileName;
                }
            SaveDocument();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) // метод сохранения
        {
            toolStripStatusLabel3.Text = "Идет сохранение";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fn = saveFileDialog1.FileName;
                SaveDocument();
            }
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e) // метод выбора шрифта
        {
            fontDialog1.Font = richTextBox2.Font;
            try
            {
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    richTextBox2.Font = fontDialog1.Font;
                }
            }
            catch
            {
                MessageBox.Show("Повторите попытку еще раз", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e) // метод выбора цвета текста
        {
            colorDialog1.Color = richTextBox2.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox2.ForeColor = colorDialog1.Color;
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e) // метод работы принтера
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e) // информация по тексту 
        {
            toolStripStatusLabel1.Text = "Количество слов - " + richTextBox2.TextLength; // кол-во символов
            toolStripStatusLabel2.Text = "Количество строк - " + richTextBox2.Lines.Length; // кол-во строк
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void searchWord_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
            this.richTextBox1.Text = f.request;            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string request = textBox1.Text;  //Искомое слово
            string[] words = richTextBox2.Text.Split(new Char[] { ' ', '.', ',', '(', ')', '/', '\0', '|', '\n' });
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == request)
                {
                    richTextBox1.Text += "Слово найденно, его номер в тексте: " + (i + 1) + "\n";
                }
            }
        }
    }
}