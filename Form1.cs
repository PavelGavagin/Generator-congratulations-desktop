using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Generator_congratulations
{
    public partial class Form1 : Form
    {
        string name = "Дорогой";
        string bt = "я желаю";
        string tr = "будь";
        string che = "и пусть";

        string Expensive = null;
        int RondomExpensive = 5;
        string sqlQueryExpensive = "SELECT Expensive FROM Man WHERE Id = ";

        string Wish = null;
        int RondomWish = 5;
        string sqlQueryWish = "SELECT Wish FROM Man WHERE Id = ";

        string Be = null;
        int RondomBe = 5;
        string sqlQueryBe = "SELECT Be FROM Man WHERE Id = ";

        string Let = null;
        int RondomLet = 5;
        string sqlQueryLet = "SELECT Let FROM Man WHERE Id = ";

        private SqlConnection sqlConnection = null;  // Переменная подключения к базе данных
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CongratulationsDB"].ConnectionString); // Подключение к базе данных
            sqlConnection.Open(); // Открытие базы данных

          
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (radioButton1.Checked) 
            {

                sqlBackMan(); // Если вытран мужчина, то запросы делаем из таблицы Man
            }
             else

            {
                sqlBackWoman();  //  Если вытрана женщина, то запросы делаем из таблицы Woman
            }



            name = textBox1.Text;
            
            
            
            
            Random random = new Random();

            RondomExpensive = random.Next(1, 13);
            sqlQueryExpensive += RondomExpensive;
            SqlCommand command = new SqlCommand(sqlQueryExpensive, sqlConnection); // Выполняем запрос
            Expensive = (string)command.ExecuteScalar();   // записываем результат запроса в переменную

            RondomWish = random.Next(1, 13);
            sqlQueryWish += RondomWish;
            command = new SqlCommand(sqlQueryWish, sqlConnection); // Выполняем запрос
            Wish = (string)command.ExecuteScalar();   // записываем результат запроса в переменную

            RondomBe = random.Next(1, 13);
            sqlQueryBe += RondomBe;
            command = new SqlCommand(sqlQueryBe, sqlConnection); // Выполняем запрос
            Be = (string)command.ExecuteScalar();   // записываем результат запроса в переменную

            RondomLet = random.Next(1, 13);
            sqlQueryLet += RondomLet;
            command = new SqlCommand(sqlQueryLet, sqlConnection); // Выполняем запрос
            Let = (string)command.ExecuteScalar();   // записываем результат запроса в переменную


            richTextBox1.Text = name + Expensive + bt+ Wish + tr + Be +che+Let; // Выводим на экран

            sqlBackMan();
           

        }

        private void sqlBackMan() // меняет напросы для мужчин
        {
            sqlQueryExpensive = "SELECT Expensive FROM Man WHERE Id = ";
            sqlQueryWish = "SELECT Wish FROM Man WHERE Id = ";
            sqlQueryBe = "SELECT Be FROM Man WHERE Id = ";
            sqlQueryLet = "SELECT Let FROM Man WHERE Id = ";
        }

        private void sqlBackWoman() // меняет напросы для женщин
        {
            sqlQueryExpensive = "SELECT Expensive FROM Woman WHERE Id = ";
            sqlQueryWish = "SELECT Wish FROM Woman WHERE Id = ";
            sqlQueryBe = "SELECT Be FROM Woman WHERE Id = ";
            sqlQueryLet = "SELECT Let FROM Woman WHERE Id = ";
        }


        /* private int RandomChislo() 
             {
             Random random = new Random();

             int chislo = random.Next(1, 13);
             return chislo;
         }*/



        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(richTextBox1.Text); // Скопировать текс в буфер обмена

        }
    }
}
