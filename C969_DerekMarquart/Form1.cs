using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_DerekMarquart
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void UpdateTime()
        {
            TimeZoneInfo userTimeZone = TimeZoneInfo.Local;
            DateTime localTime = DateTime.Now;
            labelTimeZone.Text = localTime.ToString() + " " + userTimeZone.StandardName;
        }

        private void buttonTestConn_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(constr);

                conn.Open();
                MessageBox.Show("Connection has been established.", "Connection Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            MessageBox.Show("Connection has been established.", "Connection Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
