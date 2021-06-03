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
    public partial class FindBooks : Form
    {
        public Library MyLibrary = new Library();
        public FindBooks()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void FindBooks_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Book books in MyLibrary.getAllbook())
            {
                string s = books.ToString();
                listBox1.Items.Add(s);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "";
            if (radioButton1.Checked)
            {
                String Author = textBox6.Text;
                if (!Regex.Match(Author, "^[A-zА-я]+[ ]+[A-zА-я]+[ ]+[A-zА-я]+[ ]*$").Success)
                {
                    MessageBox.Show("ФИО автора книги некорректно");
                    return;
                }
                listBox1.Items.Clear();
                foreach (Book books in MyLibrary.getAllbook())
                { 
                    if(books.getAuthor() == Author)
                    {
                        s = books.ToString();
                        listBox1.Items.Add(s);
                    }
                }
            }
            else if (radioButton2.Checked)
            {
                String Bname = textBox7.Text;
                listBox1.Items.Clear();
                foreach (Book books in MyLibrary.getAllbook())
                {
                    if (books.getBname() == Bname)
                    {
                        s = books.ToString();
                        listBox1.Items.Add(s);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите способ поиска");
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Book books in MyLibrary.getAllbook())
            {
                string s = books.ToString();
                listBox1.Items.Add(s);
            }
        }

        private void FindBooks_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainform = new Form1();
            mainform.Show();
        }
    }
}
