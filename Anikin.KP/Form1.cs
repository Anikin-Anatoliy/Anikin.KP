using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anikin.KP
{
    public partial class Form1 : Form
    {
        public Library MyLibrary = new Library();
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddClient addform = new AddClient();
            addform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddBook addbookform = new AddBook();
            addbookform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeClient changeclientform = new ChangeClient();
            changeclientform.Show();
        }
        bool check = true;
        private void Form1_Load(object sender, EventArgs e)
        {
            if(check == true)
            {
                helloform helloForm = new helloform();
                helloForm.Show();
                check = false;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FindBooks findbooksform = new FindBooks();
            findbooksform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ReturnAll returnallform = new ReturnAll();
            returnallform.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String str1 = "";
            for (int i = 0; i < MyLibrary.getClients().Count; i++)
            {
                str1 = str1 + MyLibrary.getClients()[i].Save() + "\n";
            }
            System.IO.File.WriteAllText("outputC.txt", str1);

            String str2 = "";
            for (int i = 0; i < MyLibrary.getAllbook().Count; i++)
            {
                str2 = str2 + MyLibrary.getAllbook()[i].Save() + "\n";
            }
            System.IO.File.WriteAllText("outputB.txt", str2);
            MessageBox.Show("Сохранено");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MyLibrary.getAllbook().Clear();
            string s;
            StreamReader f = new StreamReader("outputB.txt");
            while ((s = f.ReadLine()) != null)
            {
                string[] words = s.Split(new char[] { ',' });
                Book newBook = new Book(words[0], words[1]);
                MyLibrary.getAllbook().Add(newBook);
            }
            f.Close();
            MyLibrary.getClients().Clear();
            string s1;
            StreamReader f1 = new StreamReader("outputC.txt");
            while ((s1 = f1.ReadLine()) != null)
            {
                string[] words = s1.Split(new char[] { ',' });
                Book newBook = new Book(words[1], words[2]);
                LibraryClient newClient = new LibraryClient(words[0], newBook, Int32.Parse(words[3]), words[4], words[5], words[6]);
                MyLibrary.getClients().Add(newClient);
            }
            f1.Close();
            MessageBox.Show("Загружено");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MyLibrary.getClients().Clear();
            MyLibrary.getAllbook().Clear();
        }
    }
}
