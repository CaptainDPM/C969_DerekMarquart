using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_DerekMarquart
{
    public partial class MainScreen : Form
    {
        public LoginForm loginForm = new LoginForm();
        MySqlConnection conn = new MySqlConnection("Host=localhost;Port=3306;Database=c969;Username=root;Password=abcABC123!@#");
        public LoginForm LoginFormInstance { get; set; }

        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            DisplayCustomers();
            DisplayAppointments();
            dataGridMembers.ReadOnly = true;
            dataGridAppts.ReadOnly = true;

        }

        private void DisplayCustomers()
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM customer", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridMembers.DataSource = dataTable;
        }

        private void DisplayAppointments()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT appointmentId as AppointmentID, customerId as CustomerID, userId as UserID, start as StartDate, end as EndDate FROM appointment;", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridAppts.DataSource = dataTable;


        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            LoginFormInstance.Show();
            this.Close();

        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            CreateUpdateCustomer createUpdateCustomer = new CreateUpdateCustomer();
            createUpdateCustomer.Show();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            CreateUpdateCustomer createUpdateCustomer = new CreateUpdateCustomer();
            createUpdateCustomer.Show();
        }

        private void buttonCreateAppt_Click(object sender, EventArgs e)
        {
            CreateUpdateAppt createUpdateAppt = new CreateUpdateAppt();
            createUpdateAppt.Show();
        }

        private void buttonModAppt_Click(object sender, EventArgs e)
        {
            CreateUpdateAppt createUpdateAppt = new CreateUpdateAppt();
            createUpdateAppt.Show();
        }
    }
}
