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
    public partial class ChangeClient : Form
    {
        public Library MyLibrary = new Library();
        public ChangeClient()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ChangeClient_Load(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            foreach (LibraryClient client in MyLibrary.getClients())
            {
                string s = client.ToString();
                listBox.Items.Add(s);
            }
            listBox1.Items.Clear();
            foreach (Book book in MyLibrary.getAllbook())
            {
                string s = book.ToString();
                listBox1.Items.Add(s);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((MyLibrary.getClients().Exists(x => x.getPassport() == textBox5.Text)))
            {
                int i = MyLibrary.getClients().FindIndex(x => x.getPassport() == textBox5.Text);
                textBox1.Text = MyLibrary.getClients()[i].getFIO();
                if (textBox2.Text != "")
                {
                    int Age = Convert.ToInt32(textBox2.Text);
                    if ((Convert.ToInt32(textBox2.Text) < 14) || (Convert.ToInt32(textBox2.Text) > 110))
                    {
                        MessageBox.Show("Некорректный возраст клиента! " +
                        "Клиент должен быть старше 14 лет. И не старше 110");
                    }
                    else MyLibrary.getClients()[i].setAge(Age);
                }
                if (textBox3.Text != "")
                {
                    String Email = textBox3.Text;
                    if (!Regex.Match(Email, "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}").Success)
                    {
                        MessageBox.Show("Некорректная почта");
                        return;
                    }
                    else MyLibrary.getClients()[i].setEmail(Email);
                }
                if (textBox4.Text != "")
                {
                    String Phone = textBox4.Text;
                    if (!Regex.Match(Phone, @"(\+7|8|\b)[\(\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[)\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)").Success)
                    {
                        MessageBox.Show("Некорректный номер телефона");
                        return;
                    }
                    else MyLibrary.getClients()[i].setPhone(Phone);
                }
                if (radioButton1.Checked)
                {
                    MyLibrary.getClients()[i].setDebtor(true);
                }
                if (radioButton2.Checked)
                {
                    MyLibrary.getClients()[i].setDebtor(false);
                }
                label12.Text = "Изменения успешны";
                listBox.Items.Clear();
                foreach (LibraryClient client in MyLibrary.getClients())
                {
                    string s = client.ToString();
                    listBox.Items.Add(s);
                }
                listBox1.Items.Clear();
                foreach (Book book in MyLibrary.getAllbook())
                {
                    string s = book.ToString();
                    listBox1.Items.Add(s);
                }
            }
            else
            {
                MessageBox.Show("Пользователь с такими паспортными данными не найден");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((MyLibrary.getClients().Exists(x => x.getPassport() == textBox5.Text)))
            {
                int i = MyLibrary.getClients().FindIndex(x => x.getPassport() == textBox5.Text);
                String Author = textBox6.Text;
                if (!Regex.Match(Author, "^[A-zА-я]+[ ]+[A-zА-я]+[ ]+[A-zА-я]+[ ]*$").Success)
                {
                    MessageBox.Show("ФИО автора книги некорректно");
                    return;
                }
                String Bname = textBox7.Text;
                Book newBook = new Book(Bname, Author);
                if (!MyLibrary.getAllbook().Exists(x => (x.getAuthor() == newBook.getAuthor()) && (x.getBname() == newBook.getBname())))
                {
                    MessageBox.Show("Такой книги нет в библиотеке");
                    return;
                }
                MyLibrary.getClients()[i].addBook(newBook);
                label11.Text = "Книга добавлена успешно";
                listBox.Items.Clear();
                foreach (LibraryClient client in MyLibrary.getClients())
                {
                    string s = client.ToString();
                    listBox.Items.Add(s);
                }
                listBox1.Items.Clear();
                foreach (Book book in MyLibrary.getAllbook())
                {
                    string s = book.ToString();
                    listBox1.Items.Add(s);
                }
            }
            else
            {
                MessageBox.Show("Пользователь с такими паспортными данными не найден");
                return;
            }
        }

        private void ChangeClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if ((MyLibrary.getClients().Exists(x => x.getPassport() == textBox5.Text)))
            {
                int i = MyLibrary.getClients().FindIndex(x => x.getPassport() == textBox5.Text);
                MyLibrary.getClients().RemoveAt(i);
                label12.Text = "Удаление успешно";
                listBox.Items.Clear();
                foreach (LibraryClient client in MyLibrary.getClients())
                {
                    string s = client.ToString();
                    listBox.Items.Add(s);
                }
                listBox1.Items.Clear();
                foreach (Book book in MyLibrary.getAllbook())
                {
                    string s = book.ToString();
                    listBox1.Items.Add(s);
                }
            }
            else
            {
                MessageBox.Show("Пользователь с такими паспортными данными не найден");
                return;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainform = new Form1();
            mainform.Show();
        }
    }
}
