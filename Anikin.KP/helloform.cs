using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace Anikin.KP
{
    public partial class helloform : Form
    {
        private static System.Timers.Timer aTimer;
        public helloform()
        {
            TopMost = true;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        bool check = true;
        private void helloform_Load(object sender, EventArgs e)
        {
            if (check == true)
            {
                aTimer = new System.Timers.Timer(10000);
                // Hook up the Elapsed event for the timer. 
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = false;
                aTimer.Enabled = true;
                check = false;
            } 
        }

        private void helloform_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                aTimer.Stop();
                this.Close();
            }));
            aTimer.Stop();
            aTimer.Enabled = false;
        }
    }
}
