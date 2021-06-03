using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anikin.KP
{
    public partial class ReturnAll : Form
    {
        public Library MyLibrary = new Library();
        public ReturnAll()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void ReturnAll_Load(object sender, EventArgs e)
        {
            foreach (LibraryClient client in MyLibrary.getClients())
            {
                dataGridView1.Rows.Add(client.getFIO(), client.getBookstr(), client.getAge(), client.getEmail(), client.getPhone(), client.getPassport(), client.getDebtor());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 mainform = new Form1();
            mainform.Show();
        }

        private void ReturnAll_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
