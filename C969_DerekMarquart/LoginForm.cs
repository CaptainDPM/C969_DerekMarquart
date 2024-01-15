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
using C969_DerekMarquart.Properties;
using System.Globalization;
using System.Resources;

namespace C969_DerekMarquart
{
    public partial class LoginForm : Form
    {
        private Timer timer = new Timer();
        public string loggedInUsername = null;
        private CultureInfo CI { get; set; }
        ResourceManager locrm = new ResourceManager("C969_DerekMarquart.Resources.Resource", typeof(LoginForm).Assembly);

        private CultureInfo CheckLanguage()
        {
            string currentCultureName = CultureInfo.CurrentCulture.Name;
            CI = new CultureInfo(currentCultureName);

            if (CultureInfo.CurrentCulture.Name == "es-Es")
            {
                CI = new CultureInfo("es-ES");
                labelWelcome.Text = locrm.GetString("Welcome", CI);
                label1.Text = locrm.GetString("label1", CI);
                label2.Text = locrm.GetString("label2", CI);
                label3.Text = locrm.GetString("label3", CI);
                labelTimeZone.Text = locrm.GetString("labelTimeZone", CI);
                textBox1.Text = locrm.GetString("textBox1", CI);
                textBox2.Text = locrm.GetString("textBox2", CI);
                buttonLogin.Text = locrm.GetString("buttonLogin", CI);
                buttonExit.Text = locrm.GetString("buttonExit", CI);
                buttonTestConn.Text = locrm.GetString("buttonTestConn", CI);

                return CI;
            }
            else
            {
                CI = new CultureInfo("en-EN");
                labelWelcome.Text = locrm.GetString("Welcome", CI);
                label1.Text = locrm.GetString("label1", CI);
                label2.Text = locrm.GetString("label2", CI);
                label3.Text = locrm.GetString("label3", CI);
                labelTimeZone.Text = locrm.GetString("labelTimeZone", CI);
                textBox1.Text = locrm.GetString("textBox1", CI);
                textBox2.Text = locrm.GetString("textBox2", CI);
                buttonLogin.Text = locrm.GetString("buttonLogin", CI);
                buttonExit.Text = locrm.GetString("buttonExit", CI);
                buttonTestConn.Text = locrm.GetString("buttonTestConn", CI);

                return CI;
            }
        }

        public LoginForm()
        {
            InitializeComponent();

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            timer.Start();
            CheckLanguage();
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
            textBox2.PasswordChar = '*';
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text.Trim();
            string userPass = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userPass))
            {
                MessageBox.Show("Please enter both a username and password.", "Username/Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string query = "SELECT COUNT(*) FROM user WHERE userName = @Username AND password = @Password";

                string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

                MySqlConnection conn = null;
                try
                {
                    conn = new MySqlConnection(constr);

                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", userName);
                        cmd.Parameters.AddWithValue("@Password", userPass);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            loggedInUsername = userName;
                            MessageBox.Show("Login successful!");
                            MainScreen mainScreen = new MainScreen();
                            mainScreen.labelUsername.Text = "Logged in as: " + userName;
                            mainScreen.LoginFormInstance = this;

                            this.Hide();
                            mainScreen.ShowDialog();

                            this.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password. Please try again.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
