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


        public LoginForm()
        {
            InitializeComponent();
            CheckLanguage();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            timer.Start();
        }


        private CultureInfo CheckLanguage()
        {
            CultureInfo userCulture = CultureInfo.CurrentUICulture ?? CultureInfo.CurrentCulture;

            CI = new CultureInfo(userCulture.Name);
            Console.WriteLine("Detected culture is: ", CI.Name);

            //Change the region to Spanish(Chile) for translation.

            if (CultureInfo.CurrentCulture.Name == "es-CL")
            {
                labelWelcome.Text = "¡Bienvenida!";
                label1.Text = "Por favor inicie sesión a continuación.";
                label2.Text = "Nombre de usuario:";
                label3.Text = "Contraseña:";
                buttonLogin.Text = "Acceso";
                buttonExit.Text = "Salida";
                buttonTestConn.Text = "Registro";
            }
            else
            {
                CI = new CultureInfo("en-EN");
            }
            return CI;
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
                if (CultureInfo.CurrentCulture.Name == "es-CL")
                {
                    MessageBox.Show("Se ha establecido la conexión.", "Confirmación de conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Connection has been established.", "Connection Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
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
                if (CultureInfo.CurrentCulture.Name == "es-CL")
                {
                    MessageBox.Show("Por favor ingrese un nombre de usuario y contraseña.", "Error de nombre de usuario/contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.Log("Failed to login.");
                }
                else
                {
                    MessageBox.Show("Please enter both a username and password.", "Username/Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.Log("Failed to login.");
                }
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
                            if (CultureInfo.CurrentCulture.Name == "es-CL")
                            {
                                MessageBox.Show("Inicio de sesión exitosa!");
                                Logger.Log("Logged in as: " + userName);
                            }
                            else
                            {
                                MessageBox.Show("Login successful!");
                                Logger.Log("Logged in as: " + userName);
                            }
                            MainScreen mainScreen = new MainScreen();
                            mainScreen.labelUsername.Text = "Logged in as: " + userName;
                            mainScreen.LoginFormInstance = this;

                            this.Hide();
                            mainScreen.ShowDialog();

                            this.Show();
                        }
                        else
                        {
                            if (CultureInfo.CurrentCulture.Name == "es-CL")
                            {
                                MessageBox.Show("Usuario o contraseña invalido. Inténtalo de nuevo.");
                                Logger.Log("Failed to login as: " + textBox1.Text);
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password. Please try again.");
                                Logger.Log("Failed to login: " + textBox1.Text);
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    Logger.Log("Error: " + ex.Message);
                }
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
