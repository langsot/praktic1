using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    public partial class Form2 : Form
    {

        //модальное окно - это когда нельзя перейти к 1 форме не завершив вторую
        public string request
        {
            get
            {
                return textBox1.Text;
            }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }       
    }
}
