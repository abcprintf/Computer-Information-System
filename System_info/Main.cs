using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;

namespace System_info
{
    public partial class Main : Form
    {
        private PerformanceCounter ramCounter;

        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            textBox1.Enabled = true;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            const string messages = "Please confirm closing the System";
            const string title = "Form Closing";
            var results = MessageBox.Show(messages, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the no button was pressed....
            if (results == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const string messages = "Would you loke to close the form? ";
            const string title = "System Information Closing";
            var results = MessageBox.Show(messages, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the no button was pressed....
            if (results == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String computerName = Environment.MachineName;
            textBox1.Text = computerName;

            String userName = Environment.UserName;
            textBox2.Text = userName;

            int numberProcess = Environment.ProcessorCount;
            textBox3.Text = numberProcess.ToString();

            String version = Environment.OSVersion.ToString();
            textBox4.Text = version;

            string flatform = Environment.OSVersion.Platform.ToString();
            textBox5.Text = flatform;

            ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);
            textBox7.Text = ramCounter.NextValue().ToString() + " Mb";

            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList) {
                if (ip.AddressFamily.ToString() == "InterNetwork") {
                    localIP = ip.ToString();
                    textBox6.Text = localIP;
                }
            }
        }
    }
}
