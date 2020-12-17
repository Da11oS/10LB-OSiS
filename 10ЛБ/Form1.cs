using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace _10ЛБ
{
    public partial class Form1 : Form
    {
        public delegate void M();
        public Form1()
        {
            InitializeComponent();
        }
        public void m1()
        {
                BeginInvoke(new M(E));
        }
        public void E()
        {
            for (float i = 0; i < 10000; i++)
            {
                Application.DoEvents();
                toolStripStatusLabel1.Text = i.ToString();
                statusStrip1.Refresh();
                Thread.Sleep(1000);
                if (checkBox1.Checked)
                {
                    Thread.CurrentThread.Abort();
                }
            }
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            List<Thread> threads = null;
            for(int i =0; i < 10; i++)
            {
                threads.Add(new Thread(m1));
                threads[i].IsBackground = true;
                threads[i].Priority = ThreadPriority.Normal;
                threads[i].Start();
            }
 
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.Abort();
        }
    }
}
