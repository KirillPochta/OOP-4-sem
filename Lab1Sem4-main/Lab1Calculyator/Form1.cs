using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1Calculyator
{
    public partial class Form1 : Form,IMethods
    {
        public Form1()
        {
            InitializeComponent();
            textBox4.Text = "0";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }   
        private void button1_Click(object sender, EventArgs e)
        {
            string a, b, c;
            int index,ForIndex;
            a = textBox1.Text;
            b = textBox3.Text;
            c = textBox2.Text;
            Calculator CalB = new Calculator();


            try
            {
                index = Convert.ToInt32(textBox4.Text);

            #region 1
            //switch (comboBox1.Text)
            //{
            //    case "Заменить подстраку на другую":
            //        textBox2.Text = a.Remove(index, 1).Insert(index, b);
            //        break;
            //    case "Удалить заданую подстраку":
            //        textBox2.Text = a.Remove(index, 1);
            //        break;
            //    case "Получить символ по индексу":

            //        textBox2.Text = a.Substring(index, 1);
            //        break;
            //    case "Длина строки":
            //        textBox2.Text = a.Length.ToString();
            //        break;
            //    case "Количество гласных":
            //        int count = Regex.Matches(a, @"[ауоыиэяюёе]", RegexOptions.IgnoreCase).Count;

            //        textBox2.Text = count.ToString();
            //        break;
            //    case "Количество согласных":
            //        int countt = Regex.Matches(a, @"[йцкнгшщзхфвпрлджчсмтб]", RegexOptions.IgnoreCase).Count;

            //        textBox2.Text = countt.ToString();
            //        break;
            //    case "Количество слов в строке":
            //        int counttt = a.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length;
            //        textBox2.Text = counttt.ToString();
            //        break;

            //    }4
            #endregion

            int fortext = textBox1.Text.Length;
            int forindex = Convert.ToInt32(textBox4.Text);

            if ( forindex < 0)
            {
                textBox1.Text = "";
                textBox4.Text = "";
                MessageBox.Show("Некорректный индекс");
            }

            textBox2.Text = CalB.ForSwtich(a,comboBox1.Text,index,b);

        }
            catch {
                textBox1.Text = "";
                textBox3.Text = "";
                textBox4.Text = "Error"; 
                textBox2.Text = "Error"; 
            }

}

        
    }
    class Calculator
    {
        public string ForSwtich(string a, string ForCombo,int index,string b)
        {
            string  c="";

            switch (ForCombo)
            {
                case "Заменить подстраку на другую":
                    c = a.Remove(index, 1).Insert(index, b);
                    break;
                case "Удалить заданую подстраку":
                    c = a.Remove(index, 1);
                    break;
                case "Получить символ по индексу":
                    c = a.Substring(index, 1);
                    break;
                case "Длина строки":
                    c = a.Length.ToString();
                    break;
                case "Количество гласных":
                    int count = Regex.Matches(a, @"[ауоыиэяюёе]", RegexOptions.IgnoreCase).Count;

                    c = count.ToString();
                    break;
                case "Количество согласных":
                    int countt = Regex.Matches(a, @"[йцкнгшщзхфвпрлджчсмтб]", RegexOptions.IgnoreCase).Count;

                    c = countt.ToString();
                    break;
                case "Количество слов в строке":
                    int counttt = a.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length;
                    c = counttt.ToString();
                    break;

            }
            return c;
        }
    }
}
