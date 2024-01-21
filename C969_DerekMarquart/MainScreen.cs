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
            conn.Close();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT customer.customerName AS Name, address.address AS Address, address.phone AS Phone, city.city AS City, country.country AS Country " +
                                        "FROM customer customer " +
                                        "JOIN address address ON customer.addressId = address.addressId " +
                                        "JOIN city city ON address.cityId = city.cityId " +
                                        "JOIN country country ON city.countryId = country.countryId", conn);
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
            if (dataGridMembers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridMembers.SelectedRows[0];
                string customerName = selectedRow.Cells["Name"].Value.ToString();
                string address = selectedRow.Cells["Address"].Value.ToString();
                string phone = selectedRow.Cells["Phone"].Value.ToString();
                string city = selectedRow.Cells["City"].Value.ToString();
                string country = selectedRow.Cells["Country"].Value.ToString();

                CreateUpdateCustomer updateCustomerForm = new CreateUpdateCustomer(customerName, address, phone, city, country);
                updateCustomerForm.ShowDialog();

                DisplayCustomers();
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
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
