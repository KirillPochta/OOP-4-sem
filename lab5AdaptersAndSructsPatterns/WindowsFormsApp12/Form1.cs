using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Airplane> airplanes = new List<Airplane>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //агрегация
            Airplane airplane1 = new Airplane();
            Creator creator1 = new Creator();
            creator1.YearOfFoundation = 1337;
            creator1.CointOfTurbins = 2;
            airplane1.YearOfReales = creator1;
            airplane1.PowerOfTrubins = creator1;
            this.Text = "Lab2";

            numericUpDown1.Maximum = 2021;
            numericUpDown1.Minimum = 1990;
            pictureBox1.Image = Image.FromFile(@"D:\фоточки\043.jpg");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Добавить_Click(object sender, EventArgs e)
        {
            

            try
            {

               
                
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
                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Ошибочка");
                }
                else
                {
                    airplane1 = new Airplane(a, model, powerOfTurbins, countOfpassenger, countOfFreePlaces, yearOfRelease, loadCopasity, g, TypeOfFlight);

                    //git clown
                    //panel1.(airplane1.YearOfReales.YearOfFoundation, airplane1.PowerOfTrubins.CointOfTurbins);
                    dataGridView1.Rows.Add(a, model, airplane1.PowerOfTrubins.CointOfTurbins, countOfpassenger, countOfFreePlaces, airplane1.YearOfReales.YearOfFoundation, loadCopasity, g, TypeOfFlight);
                    
                    airplanes.Add(airplane1);
                }
            }
            catch 
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                comboBox1.Text = "";
                MessageBox.Show("Некорректный ввод");
            }
            

        }

        //серилизация
        private void button1_Click(object sender, EventArgs e)
        {
            
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

        private void ReTable(List<Airplane> airplanes)
        {
            DataTable table = new DataTable();//(DataTable)dataGridView1.DataSource;

            dataGridView1.Columns.Clear();

            var airboard = new Airplane();
            airboard.Fly(new TurbinsJob());
            airboard.Fly(new ChassisWork());

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

        private void button2_Click(object sender, EventArgs e)
        {
            
                string path = @"";

                path = textBox8.Text;

                airplanes = JsonConvert.DeserializeObject<List<Airplane>>(File.ReadAllText(path));
                ReTable(airplanes);
                MessageBox.Show("Объект прочтен!");
            
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
            numericUpDown1.Text = "1990";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
    [Serializable]
    public class Creator: Prototype<Creator>
    {
      
        public int YearOfFoundation { get; set; }
        public int CointOfTurbins { get; set; }
    }
    [Serializable]
    public class Airplane: Prototype<Airplane>
    {
        public int ID { get; set; }

        public Creator YearOfReales { get; set; }
        public string Model { get; set; }
        public Creator PowerOfTrubins { get; set; }
        public string TypeOfFlight { get; set; }
        public int CountOfpassenger { get; set; }
        public int CountOfFreePlaces { get; set; }
        public int LoadCapacity { get; set; }
        public int yearOfLastCheck { get; set; }
        //TypeOFFlight TypeOFFlight1;
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

        public void Fly(IFly fly) 
        {
            if (fly != null)
            {
                fly.DoFly();
            }
        }

    }
    // стратегия
    public interface IFly
    {
        void DoFly();
    }
    class TurbinsJob:IFly
    {
        public void DoFly()
        {
            Console.WriteLine("Turbins work");
        }
    }
    class ChassisWork:IFly
    {
        public void DoFly()
        {
            Console.WriteLine("Chassis's work");
        }
    }
    //static void Main(string[] args)
    //{
    //    var airboard = new Airplane();
    //    airboard.DoFly(new TurbinsJob());
    //    airboard.DoFly(new ChassisJob());
    //}
    public abstract class AirlaneBuilder
    {
        public Airplane airplane { get; set; }

        public void CreateAirplane()
        {
            airplane = new Airplane();
        }
        public abstract void SetCreator();
    }
    
    class CreateAirplane
    {
        public Airplane GetAirplane(AirlaneBuilder AB)
        {
            AB.CreateAirplane();
            AB.SetCreator();
            return AB.airplane;
        }
    }
    // строитель для airplane
    class Airplane1 : AirlaneBuilder
    {
        public override void SetCreator()
        {
            Creator forC = new Creator();
            this.airplane.PowerOfTrubins = forC;
        }
    }
    class Singleton
    {
        private static Singleton instance;

        private Singleton()
        { }

        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
        public Color Colors { get; set; }
        public FontFamily Font { get; set; }
        public float Size { get; set; }
    }
    class SaveChenge
    {
        Stack<List<Airplane>> DownStack = new Stack<List<Airplane>>();
        Stack<List<Airplane>> UpStack = new Stack<List<Airplane>>();

        public List<Airplane> DownСhanges(List<Airplane> Airplanes)
        {
            if (DownStack.Count > 0)
            {
                List<Airplane> Airplane = new List<Airplane>();
                foreach (Airplane air in Airplanes)
                    Airplane.Add(air.CopyMethod());
                UpStack.Push(Airplane);
                return DownStack.Pop();
            }
            return Airplanes;
        }
        public List<Airplane> UpСhanges(List<Airplane> Airplanes)
        {
            if (UpStack.Count > 0)
            {
                List<Airplane> Airplane = new List<Airplane>();
                foreach (Airplane air in Airplanes)
                    Airplane.Add(air.CopyMethod());
                DownStack.Push(Airplane);
                return UpStack.Pop();
            }
            return Airplanes;
        }
        public void SaveChenges(List<Airplane> Airplanes)
        {
            if (DownStack.Count < 10)
            {
                List<Airplane> Airplane = new List<Airplane>();
                foreach (Airplane air in Airplanes)
                    Airplane.Add(air.CopyMethod());
                DownStack.Push(Airplane);
            }
        }
    }
    [Serializable]
    public abstract class Prototype<T>
    {
        public  T CopyMethod()
        {
            using (var stream = new MemoryStream())
            {
                var ctx = new StreamingContext(StreamingContextStates.Clone);
                var f = new BinaryFormatter { Context = ctx };
                f.Serialize(stream, this);
                return (T)f.Deserialize(stream);
            }
        }
    }

    //static void Main(string[] args)
    //{
    //    // содаем объект CreateAirplane
    //    CreateAirplane creater = new CreateAirplane();
    //    // создаем билдер для airplane
    //    AirpalneBuilder NA = new AirpalneBuilder();
    //    // создаём samolet
    //    Airplane obj1 = creater.GetAirplane(NA);

    //    // создаем билдер для Aiplane2
    //    AirpalneBuilder NA2 = new Stud();
    //    // создаём airplane2
    //    obj1 = creater.GetAirplane(NA2);
    //}

    interface IAdapter
    {
        void GetInfo();
    }
    class Adaptee : Airplane, IAdapter
    {
        public void GetInfo()
        {
            Console.WriteLine(this.YearOfReales);
        }
    }
    class Adaptere1 : IAdapter
    {
        Airplane airplane = new Airplane();
        public void GetInfo()
        {
            Console.WriteLine(airplane.YearOfReales);
        }
    }
}
