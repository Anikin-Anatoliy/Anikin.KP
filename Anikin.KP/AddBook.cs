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
    public partial class AddBook : Form
    {
        public Library MyLibrary = new Library();
        public AddBook()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
private void button1_Click(object sender, EventArgs e)
        {
            String Author = textBox6.Text;
            if (!Regex.Match(Author, "^[A-zА-я]+[ ]+[A-zА-я]+[ ]+[A-zА-я]+[ ]*$").Success)
            {
                MessageBox.Show("ФИО автора книги некорректно");
                return;
            }
            String Bname = textBox7.Text;
            Book newBook = new Book(Bname, Author);
            if (MyLibrary.getAllbook().Exists(x => (x.getAuthor() == newBook.getAuthor()) && (x.getBname() == newBook.getBname())))
            {
                MessageBox.Show("Такая книга уже существует");
                return;
            }
            else MyLibrary.addBook(newBook);
            textBox8.Text = "Добавление прошло успешно";
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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AddBook_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Book book in MyLibrary.getAllbook())
            {
                string s = book.ToString();
                listBox1.Items.Add(s);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Author = textBox6.Text;
            if (!Regex.Match(Author, "^[A-zА-я]+[ ]+[A-zА-я]+[ ]+[A-zА-я]+[ ]*$").Success)
            {
                MessageBox.Show("ФИО автора книги некорректно");
                return;
            }
            String Bname = textBox7.Text;
            Book newBook = new Book(Bname, Author);
            if (MyLibrary.getAllbook().Exists(x => (x.getAuthor() == newBook.getAuthor())&&(x.getBname() == newBook.getBname())))
            {
                int i = MyLibrary.getAllbook().FindIndex(x => (x.getAuthor() == newBook.getAuthor()) && (x.getBname() == newBook.getBname()));
                MyLibrary.getAllbook().RemoveAt(i);
            }
            else
            {
                MessageBox.Show("Такая книга не существует");
                return;
            }
            textBox8.Text = "Удаление прошло успешно";
            listBox1.Items.Clear();
            foreach (Book book in MyLibrary.getAllbook())
            {
                string s = book.ToString();
                listBox1.Items.Add(s);
            }
        }
    }
}
