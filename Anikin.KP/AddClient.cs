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

namespace Anikin.KP
{
    public partial class AddClient : Form
    {
        public Library MyLibrary = new Library();
        public AddClient()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") ||
                textBox3.Text.Equals("") || textBox4.Text.Equals("")
                || textBox5.Text.Equals("") || textBox6.Text.Equals("") || textBox7.Text.Equals(""))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            String FIO = textBox1.Text;
            if (!Regex.Match(FIO, "^[A-zА-я]+[ ]+[A-zА-я]+[ ]+[A-zА-я]+[ ]*$").Success)
            {
                MessageBox.Show("ФИО некорректно");
                return;
            }
            int Age = Convert.ToInt32(textBox2.Text);
            if ((Convert.ToInt32(textBox2.Text) < 14) || (Convert.ToInt32(textBox2.Text) > 110))
            {
                MessageBox.Show("Некорректный возраст клиента! " +
                "Клиент должен быть старше 14 лет. И не старше 110");
                return;
            }
            String Email = textBox3.Text;
            if (!Regex.Match(Email, "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}").Success)
            {
                MessageBox.Show("Некорректная почта");
                return;
            }
            String Phone = textBox4.Text;
            if (!Regex.Match(Phone, @"(\+7|8|\b)[\(\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[)\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)").Success)
            {
                MessageBox.Show("Некорректный номер телефона");
                return;
            }
            String Passport = textBox5.Text;
            if (!Regex.Match(Passport, "^(([0-9]){10})$").Success)
            {
                MessageBox.Show("Некорректные паспортные данные");
                return;
            }
            String Author = textBox6.Text;
            if (!Regex.Match(Author, "^[A-zА-я]+[ ]+[A-zА-я]+[ ]+[A-zА-я]+[ ]*$").Success)
            {
                MessageBox.Show("ФИО автора книги некорректно");
                return;
            }
            String Bname = textBox7.Text;
            Book newBook = new Book(Bname, Author);
            if (!MyLibrary.getAllbook().Exists(x => (x.getAuthor() == newBook.getAuthor())&&(x.getBname() == newBook.getBname())))
            {
                MessageBox.Show("Такой книги нет в библиотеке");
                return;
            }
            LibraryClient newClient = new LibraryClient(FIO, newBook, Age, Email, Phone, Passport);
            if (MyLibrary.getClients() != null) {
                if ((MyLibrary.getClients().Exists(x => x.getPassport() == newClient.getPassport())))
            {
                    MessageBox.Show("Такой клиент уже существует, данный паспорт уже использован для регистрации");
                    return;
                } else MyLibrary.addClient(newClient);
            }
            else MyLibrary.addClient(newClient);
            textBox8.Text = "Добавление прошло успешно";
        }
        private void AddClient_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Book book in MyLibrary.getAllbook())
            {
                string s = book.ToString();
                listBox1.Items.Add(s);
            }
        }
        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainform = new Form1();
            mainform.Show();
        }

        private void AddClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
