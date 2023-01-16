using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using Timer = System.Windows.Forms.Timer;
using Amazon.DynamoDBv2.DocumentModel;

namespace WindowsFormsApp1
{
    

    public partial class Form1 : Form
    {
        List<Airplane> airplanes = new List<Airplane>();
        SaveChenge chenges = new SaveChenge();
        public Form1()
        {
            InitializeComponent();

            TextBox tb = new TextBox();

            ToolStripButton Instrument = new ToolStripButton();
            ToolStripButton Search = new ToolStripButton();
            ToolStripButton Sort = new ToolStripButton();

            ToolStripButton Back = new ToolStripButton();
            ToolStripButton Forward = new ToolStripButton();

            Instrument.Text = "Инструменты";
            Search.Text = "поиск";
            Sort.Text = "Сортировка";
            // устанавливаем обработчик нажатия
            Instrument.Click += btn_Click;
            Search.Click += найтиToolStripMenuItem;
            Sort.Click += сортировка;

            toolStrip1.Items.Add(Instrument);

            toolStrip1.Items.Add(Search);
            toolStrip1.Items.Add(Sort);
            toolStrip2.Items[0].Click += назад;
            toolStrip2.Items[1].Click += вперед;
            

        



            ToolStripMenuItem aboutitem = new ToolStripMenuItem("О программе");
            aboutitem.Click += aboutItem_Click;
            toolStrip1.Items.Add(aboutitem);
            MenuStrip ms;
            
            ToolStripLabel infoLabel = new ToolStripLabel();
            infoLabel.Text = "Текущие дата и время:";
            ToolStripLabel dateLabel = new ToolStripLabel();
            ToolStripLabel timeLabel = new ToolStripLabel();
            ToolStripLabel countOfObject = new ToolStripLabel();
            ToolStrip back = new ToolStrip();

            string path = @"C:\1.json";
            airplanes = JsonConvert.DeserializeObject<List<Airplane>>(File.ReadAllText(path));


            int countOfAirplanes = airplanes.Count;
            countOfObject.Text = "Количество объектов Airplane - ";

            statusStrip1.Items.Add(infoLabel);
            statusStrip1.Items.Add(dateLabel);
            statusStrip1.Items.Add(timeLabel);
            statusStrip1.Items.Add(countOfObject);
            statusStrip1.Items.Add(airplanes.Count.ToString());

            Timer timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();
            

            void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
            
        }
    }

        private void сортировка(object sender, EventArgs e)
        {
            groupBox4.Visible = !groupBox4.Visible;
            groupBox3.Visible = !groupBox3.Visible;
        }
        private void назад(object sender, EventArgs e)
        {
            airplanes = chenges.DownСhanges(airplanes);
            ReTable(airplanes);
        }
        private void вперед(object sender, EventArgs e)
        {
            airplanes = chenges.UpСhanges(airplanes);
            ReTable(airplanes);
        }
        private void найтиToolStripMenuItem(object sender, EventArgs e)
        {
            groupBox2.Visible = !groupBox2.Visible;
            groupBox4.Visible = !groupBox4.Visible;
            groupBox3.Visible = !groupBox3.Visible;


        }

        void aboutItem_Click(object sendet,EventArgs e)
        {
            MessageBox.Show("Разработал Почта Кирилл ИСИТ3-2");
        }
        void btn_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = !groupBox2.Visible;
            groupBox1.Visible = !groupBox1.Visible;
            groupBox3.Visible = !groupBox3.Visible;
            groupBox4.Visible = !groupBox4.Visible;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            airplanes.Clear();
            groupBox2.Visible = !groupBox2.Visible;
            groupBox1.Visible = !groupBox1.Visible;
            groupBox3.Visible = !groupBox3.Visible;
            groupBox4.Visible = !groupBox4.Visible;
            groupBox1.Text = null;
            groupBox2.Text = null;
            groupBox3.Text = null;
            groupBox4.Text = null;
            //агрегация
            Airplane airplane1 = new Airplane();
            Creator creator1 = new Creator
            {
                YearOfFoundation = 1337,
                CointOfTurbins = 2
            };
            airplane1.YearOfReales = creator1;
            airplane1.PowerOfTrubins = creator1;
            this.Text = "Lab2";

            numericUpDown1.Maximum = 2021;
            numericUpDown1.Minimum = 1990;
            pictureBox1.Image = Image.FromFile(@"D:\фоточки\043.jpg");

        }
        
        private void найтиToolStripMenuItem_CheckedOnClick(object sender, EventArgs e)
        {
            comboBox1.Visible = !comboBox1.Visible;
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

  
        private void Добавить_Click(object sender, EventArgs e)
        {


            //try
            //{



                int a, countOfpassenger, countOfFreePlaces, loadCopasity, g;
                string TypeOfFlight, model;
                model = textBox2.Text;
                TypeOfFlight = comboBox1.Text;
                a = Convert.ToInt32(textBox1.Text);

                countOfpassenger = Convert.ToInt32(textBox3.Text);
                countOfFreePlaces = Convert.ToInt32(textBox4.Text);


                Creator yearOfRelease = new Creator();
                Creator powerOfTurbins = new Creator();

                yearOfRelease.YearOfFoundation = Convert.ToInt32(numericUpDown1.Text);

                loadCopasity = Convert.ToInt32(textBox6.Text);

                g = Convert.ToInt32(textBox7.Text);
                powerOfTurbins.CointOfTurbins = Convert.ToInt32(textBox9.Text);
                Airplane airplane1 = new Airplane();
                var result = new List<ValidationResult>();

            var context = new ValidationContext<Airplane>(airplane1);

            if (!Validator.TryValidateObject(airplane1, context, result, true))
            {
                foreach (var error in result)
                {
                    MessageBox.Show(error.ErrorMessage);
                }

            }
            //else
            //{
            //    Regex regex = new Regex(search.Text);
            //    MatchCollection matches = regex.Matches(airplanes);

            //    if (matches.Count > 0)
            //    {
            //        return true;
            //    }
            //    else
            //        return false;
            //}

            if (comboBox1.Text == "")
                {
                    MessageBox.Show("");
                }
                else
                {

                    airplane1 = new Airplane(a, model, powerOfTurbins, countOfpassenger, countOfFreePlaces, yearOfRelease, loadCopasity, g, TypeOfFlight);
                    //if (!Validator.TryValidateObject(airplane1,context,result,true)

                    //git clown
                    //panel1.(airplane1.YearOfReales.YearOfFoundation, airplane1.PowerOfTrubins.CointOfTurbins);
                    dataGridView1.Rows.Add(a, model, airplane1.PowerOfTrubins.CointOfTurbins, countOfpassenger, countOfFreePlaces, airplane1.YearOfReales.YearOfFoundation, loadCopasity, g, TypeOfFlight);


                    airplanes.Add(airplane1);
                }
            //}
            //catch
            //{
            //    textBox1.Text = "";
            //    textBox2.Text = "";
            //    textBox3.Text = "";
            //    textBox4.Text = "";
            //    textBox6.Text = "";
            //    textBox7.Text = "";
            //    textBox8.Text = "";
            //    textBox9.Text = "";
            //    comboBox1.Text = "";
            //    MessageBox.Show("Некорректный ввод");
            //}


        }

        //серилизация
        private void button1_Click(object sender, EventArgs e)
        {
            chenges.SaveChenges(airplanes);

            string path = @"";

            path = textBox8.Text;

            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.Write(JsonConvert.SerializeObject(airplanes));
                    sw.Close();
                }
                MessageBox.Show("Объект записан!");
            }
            catch 
            {
                textBox8.Text = "Введите путь";
            }

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        //сортировка 
        void FuncForSortAirplanes(IOrderedEnumerable<Airplane> airplanes1)
        {
            chenges.SaveChenges(airplanes);

            List<Airplane> airpls = new List<Airplane>();

            foreach (Airplane item in airplanes1)
            {
                airpls.Add(item);
            }
            ReTable(airpls);
        }
        //функция сортировки
        void SortВescending()
        {
            IOrderedEnumerable<Airplane> airpls;
            
            switch (comboBox3.Text)
            {
                case "По году выпуска":
                    airpls = from planes in this.airplanes
                               orderby planes.YearOfReales.YearOfFoundation descending
                               select planes;
                    FuncForSortAirplanes(airpls);
                    break;
                case "Дата послднего тех.обсл":
                    airpls = from planes in this.airplanes
                               orderby planes.yearOfLastCheck descending
                               select planes;
                    FuncForSortAirplanes(airpls);
                    break;
            }
        }
        //кнопка запускающая сортировку
        private void button5_Click(object sender, EventArgs e)
        {
            chenges.SaveChenges(airplanes);

            if (comboBox3.Text == "")
            {
                MessageBox.Show("Выберите тип сортировки");
            }
            else
            {
                if(textBox8.Text == "" || dataGridView1.Rows.Count == 1)
                {
                    MessageBox.Show("Некорректный ввод для прочтения данных  или  таблица пустая");
                }
                SortВescending();
            }
        }
        //Кнопка сохранения результатов поиска или сортировки
        private void button6_Click(object sender, EventArgs e)
        {
            chenges.SaveChenges(airplanes);

            try
            {
                string path = @"";
                path = textBox12.Text;
                StreamWriter fs = new StreamWriter(path);
                if (comboBox4.Text == "")
                {
                    MessageBox.Show("Выберите какой результат сохранить");
                }
                else
                {
                    if (textBox12.Text == "" || dataGridView1.Rows.Count == 1)
                    {
                        MessageBox.Show("Некорректный ввод для записи данных  или  таблица пустая");
                    }
                    else
                    {
                        switch (comboBox4.Text)
                        {
                            case "сортировки":
                                fs.Write("Результат сортировки - ");
                                fs.Write(JsonConvert.SerializeObject(airplanes));
                                fs.Close();
                                MessageBox.Show($"Результат сохранен - " + textBox12.Text);
                                break;
                            case "поиска":
                                fs.Write("Результат поиска -");
                                fs.Write(JsonConvert.SerializeObject(airplanes));
                                fs.Close();
                                MessageBox.Show($"Результат сохранен - " + textBox12.Text);
                                break;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Некорректный ввод");
            }
        }
        //функция для заполнения таблицы при десереализации(прочтния)
        private void ReTable(List<Airplane> airplanes)
        {
            chenges.SaveChenges(airplanes);

            chenges.SaveChenges(airplanes);

            DataTable table = new DataTable();//(DataTable)dataGridView1.DataSource;

            dataGridView1.Columns.Clear();

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Модель", typeof(string));
            table.Columns.Add("Мощность турбин", typeof(string));
            table.Columns.Add("Кол.пассажиров", typeof(int));
            table.Columns.Add("Кол.свободных мест", typeof(int));
            table.Columns.Add("Год выпуска", typeof(int));
            table.Columns.Add("Грузоподъемность", typeof(int));
            table.Columns.Add("Год последней проверки", typeof(int));
            table.Columns.Add("Тип самолёта", typeof(int));
            

            for (int i = 0; i < airplanes.Count; i++)
                table.Rows.Add(airplanes[i].ID, airplanes[i].Model, airplanes[i].PowerOfTrubins.CointOfTurbins,
                    airplanes[i].CountOfpassenger.ToString(), airplanes[i].CountOfFreePlaces.ToString(), airplanes[i].YearOfReales.YearOfFoundation, airplanes[i].LoadCapacity,
                    airplanes[i].yearOfLastCheck,airplanes[i].yearOfLastCheck);
            dataGridView1.DataSource = table;

        }
        //Прочтение из файла
        private void button2_Click(object sender, EventArgs e)
        {
            chenges.SaveChenges(airplanes);

            string path = @"";

                path = textBox8.Text;
            if (textBox8.Text == "")
            {
                textBox8.Text = "Введите путь";
            }
            else
            {
                try
                {
                    airplanes = JsonConvert.DeserializeObject<List<Airplane>>(File.ReadAllText(path));
                    ReTable(airplanes);
                    MessageBox.Show("Объект прочтен!");
                }
                catch
                {
                    MessageBox.Show("В файле или ничего нет,или введен некорректный путь");
                }
            }
         
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            numericUpDown1.Text = "1990";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";

            DataTable table = new DataTable();//(DataTable)dataGridView1.DataSource;

            dataGridView1.Columns.Clear();

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Модель", typeof(string));
            table.Columns.Add("Мощность турбин", typeof(string));
            table.Columns.Add("Кол.пассажиров", typeof(int));
            table.Columns.Add("Кол.свободных мест", typeof(int));
            table.Columns.Add("Год выпуска", typeof(int));
            table.Columns.Add("Грузоподъемность", typeof(int));
            table.Columns.Add("Год последней проверки", typeof(int));
            table.Columns.Add("Тип самолёта", typeof(int));

            dataGridView1.DataSource = table;
        }

        //Поиск
        private void button4_Click(object sender, EventArgs e)
        {
            chenges.SaveChenges(airplanes);

            DataTable table = new DataTable();//(DataTable)dataGridView1.DataSource;

            dataGridView1.Columns.Clear();

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Модель", typeof(string));
            table.Columns.Add("Мощность турбин", typeof(string));
            table.Columns.Add("Кол.пассажиров", typeof(int));
            table.Columns.Add("Кол.свободных мест", typeof(int));
            table.Columns.Add("Год выпуска", typeof(int));
            table.Columns.Add("Грузоподъемность", typeof(int));
            table.Columns.Add("Год последней проверки", typeof(int));
            table.Columns.Add("Тип самолёта", typeof(int));
            dataGridView1.DataSource = table;

            string path = @"";
            int prikol = 0;
            path = textBox8.Text;
            try
            {
                if (comboBox2.Text == "")
                {
                    MessageBox.Show("Выберите тип поиска");

                }
                else
                {
                    if (textBox8.Text == "")
                    {
                        MessageBox.Show("Введите путь");

                    }
                    else
                    {
                        airplanes = JsonConvert.DeserializeObject<List<Airplane>>(File.ReadAllText(path));

                        switch (comboBox2.Text)
                        {
                            case "по модели":
                                try
                                {
                                    if (textBox5.Text == "")
                                    {
                                        MessageBox.Show("Введите данные");
                                    }
                                    else
                                    {
                                        foreach (Airplane item in airplanes)
                                        {
                                            if (item.Model == textBox5.Text)
                                            {
                                                for (int i = 0; i < airplanes.Count; i++)
                                                {


                                                    table.Rows.Add(item.ID, item.Model, item.PowerOfTrubins.CointOfTurbins,
                                                        item.CountOfpassenger.ToString(), item.CountOfFreePlaces.ToString(), item.YearOfReales.YearOfFoundation, item.LoadCapacity,
                                                        item.yearOfLastCheck, item.yearOfLastCheck);
                                                    dataGridView1.DataSource = table;
                                                }
                                                prikol++;
                                            }
                                            
                                        }
                                        if(prikol == 0)
                                        {
                                            MessageBox.Show("Такой модели нет");
                                        }
                                    }  
                                }
                                catch
                                {
                                    MessageBox.Show("Такой модели нет");
                                }
                                break;
                            case "по freeplac'es":
                                try
                                {
                                    prikol = 0;
                                    if (textBox10.Text == "")
                                    {
                                        MessageBox.Show("Введите данные");
                                    }
                                    else
                                    {
                                        foreach (Airplane item in airplanes)
                                        {
                                            if (item.CountOfFreePlaces.ToString() == textBox10.Text)
                                            {
                                                for (int i = 0; i < airplanes.Count; i++)
                                                    table.Rows.Add(item.ID, item.Model, item.PowerOfTrubins.CointOfTurbins,
                                                        item.CountOfpassenger.ToString(), item.CountOfFreePlaces.ToString(), item.YearOfReales.YearOfFoundation, item.LoadCapacity,
                                                        item.yearOfLastCheck, item.yearOfLastCheck);
                                                dataGridView1.DataSource = table;
                                                prikol++;
                                            }
                                        }
                                        if (prikol == 0)
                                        {
                                            MessageBox.Show("аким количеством свободных мест нет");
                                        }
                                    }

                                    break;
                                }
                                catch
                                {
                                    MessageBox.Show("Такого борта нет");
                                }
                                break;
                            case "по грузоподъемности":
                                try
                                {
                                    prikol = 0;
                                    if (textBox11.Text == "")
                                    {
                                        MessageBox.Show("Введите данные");
                                    }
                                    else
                                    {
                                        foreach (Airplane item in airplanes)
                                        {
                                            if (item.LoadCapacity.ToString() == textBox11.Text)
                                            {


                                                for (int i = 0; i < airplanes.Count; i++)
                                                    table.Rows.Add(item.ID, item.Model, item.PowerOfTrubins.CointOfTurbins,
                                                        item.CountOfpassenger.ToString(), item.CountOfFreePlaces.ToString(), item.YearOfReales.YearOfFoundation, item.LoadCapacity,
                                                        item.yearOfLastCheck, item.yearOfLastCheck);

                                                dataGridView1.DataSource = table;

                                                prikol++;
                                            }
                                        }
                                        if (prikol == 0)
                                        {
                                            MessageBox.Show("Борта с такой грузопдъемностью нет");
                                        }
                                    }

                                    break;
                                }
                                catch
                                {
                                    MessageBox.Show("Самолёта с такими данными нет");
                                }
                                break;
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Некорректный ввод");
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        
        
        private void label8_Click(object sender, EventArgs e)
        {

        }
        //удалить выбраную строку
        private void button7_Click(object sender, EventArgs e)
        {
            chenges.SaveChenges(airplanes);

            int vv = Convert.ToInt32(textBox13.Text);
            if (textBox13.Text == "")
            {
                MessageBox.Show("Не корректынй ввод");
            }
            if (vv <= airplanes.Count)
            {
                airplanes.RemoveAt(vv - 1);
                ReTable(airplanes);
            }
        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            comboBox2.Visible = !comboBox2.Visible;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            comboBox1.Visible = !comboBox1.Visible;
        }
    }
    public class Creator
    {
        public int YearOfFoundation { get; set; }
        public int CointOfTurbins { get; set; }
    }
   
    public class Airplane:ValidationAttribute,ICloneable
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                int id = (int)value;
                if (id.Equals(0))
                    ErrorMessage = "Идентификатор не может быть 0 ";
                else
                    return true;
            }
            return false;
        }

        public int ID { get; set; }

        public Creator YearOfReales { get; set; }
        [Required]
        [StringLength(10,MinimumLength =3)]
        public string Model { get; set; }

        public Creator PowerOfTrubins { get; set; }

        public string TypeOfFlight { get; set; }
        [Required]
        [Range(1,100)]
        public int CountOfpassenger { get; set; }
        [Required]
        [Range(1, 100)]
        public int CountOfFreePlaces { get; set; }
        [Required]
        [Range(100,300)]
        public int LoadCapacity { get; set; }
        [Required]
        [RegularExpression(@"^\{4}\-d{2}\-d{2}$",ErrorMessage ="Некорректный формат даты(хххх-хх-хх)")]
        public int yearOfLastCheck { get; set; }

        public Airplane(int ID,string Model, Creator PowerOfTrubins,int CountOfpassenger,int CountOfFreePlaces,Creator YearOfReales,int LoadCapacity,int yearOfLastCheck, string TypeOfFlight) 
        {
            this.ID = ID;
            this.Model = Model;
            this.PowerOfTrubins = PowerOfTrubins;
            this.CountOfpassenger = CountOfpassenger;
            this.CountOfFreePlaces = CountOfFreePlaces;
            this.YearOfReales = YearOfReales;
            this.LoadCapacity = LoadCapacity;
            this.yearOfLastCheck = yearOfLastCheck;
            //this.TypeOFFlight1 = TypeOFFlight1;
        }
        public Airplane() { }

        public object Clone()
        {
            Airplane airplane3 = new Airplane();
            airplane3.ID = this.ID;
            airplane3.Model = this.Model;
            airplane3.PowerOfTrubins = this.PowerOfTrubins;
            airplane3.CountOfpassenger = this.CountOfpassenger;
            airplane3.YearOfReales = this.YearOfReales;
            airplane3.LoadCapacity = this.LoadCapacity;
            airplane3.yearOfLastCheck = this.yearOfLastCheck;
            return airplane3;
        }
    }

    class SaveChenge
    {
        Stack<List<Airplane>> DownStack = new Stack<List<Airplane>>();
        Stack<List<Airplane>> UpStack = new Stack<List<Airplane>>();

        public List<Airplane> DownСhanges(List<Airplane> airplanes)
        {
            
            
                List<Airplane> airplanes2 = new List<Airplane>();
                foreach (Airplane air in airplanes)
                    airplanes2.Add((Airplane)air.Clone());
                UpStack.Push(airplanes2);
                return DownStack.Pop();
            
            return airplanes;
        }
        public List<Airplane> UpСhanges(List<Airplane> airplanes)
        {
            
           
                List<Airplane> airplanes2 = new List<Airplane>();
                foreach (Airplane air in airplanes)
                    airplanes2.Add((Airplane)air.Clone());
                DownStack.Push(airplanes2);
                return UpStack.Pop();
            
            return airplanes;
        }
        public void SaveChenges(List<Airplane> airplanes)
        {
            
                List<Airplane> airplanes2 = new List<Airplane>();
                foreach (Airplane air in airplanes)
                    airplanes2.Add((Airplane)air.Clone());
                DownStack.Push(airplanes2);
            
        }
    }
}
