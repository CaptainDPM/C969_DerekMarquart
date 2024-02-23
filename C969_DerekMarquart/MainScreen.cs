using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_DerekMarquart
{
    public partial class MainScreen : Form
    {
        public LoginForm loginForm = new LoginForm();
        //MySqlConnection conn = new MySqlConnection("Host=localhost;Port=3306;Database=client_schedule;Username=sqlUser;Password=Passw0rd!");
        MySqlConnection conn = new MySqlConnection("Host=localhost;Port=3306;Database=c969;Username=root;Password=abcABC123!@#");

        public DateTime SelectedDate { get; set; }
        public int LoggedInUserId { get; set; }

        public LoginForm LoginFormInstance { get; set; }
        public string loggedInUser;

        public MainScreen()
        {
            InitializeComponent();
            this.loggedInUser = loggedInUser;
        }

        public MainScreen(int loggedInUserId)
        {
            InitializeComponent();
            LoggedInUserId = loggedInUserId;
        }
        public void RefreshCustomerData()
        {
            DisplayCustomers();
        }
        public void RefreshAppointmentData()
        {
            DisplayAppointments(SelectedDate);
        }


        private void MainScreen_Load(object sender, EventArgs e)
        {
            DisplayCustomers();
            DisplayAppointments(SelectedDate);
            if (dataGridAppts != null && dataGridAppts.Rows.Count > 0)
            {
                CheckForAppointmentsToday();
            }
            dataGridMembers.ReadOnly = true;
            dataGridAppts.ReadOnly = true;
            comboBoxReports.Hide();

        }

        private void CheckForAppointmentsToday()
        {
            DateTime today = DateTime.Today;

            try
            {
                /*string query = "SELECT COUNT(*) FROM appointment WHERE Day(start) = Day(@today)";

                string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@today", today.Date);

                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("You have appointments scheduled for today!");
                        }
                        else
                        {
                            MessageBox.Show("No appointments scheduled for today.");
                        }
                    }
                }*/
                conn.Open();
                DateTime currentTime = DateTime.Now;
                DateTime currentTimePlus15Minutes = currentTime.AddMinutes(15);

                string query = "SELECT * FROM appointment WHERE start BETWEEN @currentTime AND @currentTimePlus15Minutes AND userId = @userId";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@currentTime", currentTime);
                cmd.Parameters.AddWithValue("@currentTimePlus15Minutes", currentTimePlus15Minutes);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("You have appointments scheduled within the next 15 minutes!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        public void DisplayCustomers()
        {
            conn.Close();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT customer.customerId AS CustomerID, customer.customerName AS Name, address.addressId AS AddressID, address.address AS Address, address.phone AS Phone, city.cityID AS CityID, city.city AS City, country.countryId AS CountryID, country.country AS Country " +
                                        "FROM customer customer " +
                                        "JOIN address address ON customer.addressId = address.addressId " +
                                        "JOIN city city ON address.cityId = city.cityId " +
                                        "JOIN country country ON city.countryId = country.countryId", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridMembers.DataSource = dataTable;
            dataGridMembers.Refresh();
        }

        public void DisplayAppointments(DateTime selectedDate)
        {
            conn.Close();
            conn.Open();
            string query = "SELECT appointmentId as AppointmentID, customerId as CustomerID, userId as UserID, title as Title, description as Description, location as Location, contact as Contact, type as Type, start as StartDate, end as EndDate FROM appointment WHERE DATE(start) = @selectedDate;";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@selectedDate", selectedDate.ToString("yyyy-MM-dd"));
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridAppts.DataSource = dataTable;
            dataGridAppts.Refresh();

        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            LoginFormInstance.Show();
            this.Close();

        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            CreateUpdateCustomer createUpdateCustomer = new CreateUpdateCustomer(this, loggedInUser);
            createUpdateCustomer.Show();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridMembers.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridMembers.SelectedRows[0];
                string customerID = selectedRow.Cells["CustomerID"].Value.ToString();
                string customerName = selectedRow.Cells["Name"].Value.ToString();
                string addressID = selectedRow.Cells["AddressID"].Value.ToString();
                string address = selectedRow.Cells["Address"].Value.ToString();
                string phone = selectedRow.Cells["Phone"].Value.ToString();
                string cityID = selectedRow.Cells["CityID"].Value.ToString();
                string city = selectedRow.Cells["City"].Value.ToString();
                string countryID = selectedRow.Cells["CountryID"].Value.ToString();
                string country = selectedRow.Cells["Country"].Value.ToString();

                CreateUpdateCustomer updateCustomerForm = new CreateUpdateCustomer(customerID, customerName, addressID, address, phone, cityID, city, countryID, country);
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
            CreateUpdateAppt createUpdateAppt = new CreateUpdateAppt(this);
            createUpdateAppt.Show();
        }

        private void buttonModAppt_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridAppts.SelectedRows[0];
            string appointmentID = selectedRow.Cells["AppointmentID"].Value.ToString();
            string customerID = selectedRow.Cells["CustomerID"].Value.ToString();
            string userID = selectedRow.Cells["UserID"].Value.ToString();
            string startDate = selectedRow.Cells["StartDate"].Value.ToString();
            string endDate = selectedRow.Cells["EndDate"].Value.ToString();
            string title = selectedRow.Cells["Title"].Value.ToString();
            string description = selectedRow.Cells["Description"].Value.ToString();
            string locationName = selectedRow.Cells["Location"].Value.ToString();
            string contact = selectedRow.Cells["Contact"].Value.ToString();
            string apptType = selectedRow.Cells["Type"].Value.ToString();


            CreateUpdateAppt createUpdateAppt = new CreateUpdateAppt( appointmentID,  customerID,  userID,  title,  description,  locationName,  contact,  apptType,  startDate,  endDate);
            createUpdateAppt.Show();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridMembers.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DataGridViewRow selectedRow = dataGridMembers.SelectedRows[0];
                        string customerID = selectedRow.Cells["CustomerID"].Value.ToString();
                        string addressID = selectedRow.Cells["AddressID"].Value.ToString();
                        string cityID = selectedRow.Cells["CityID"].Value.ToString();
                        string countryID = selectedRow.Cells["CountryID"].Value.ToString();



                        MySqlCommand cmdDeleteCustomer = new MySqlCommand("DELETE FROM customer WHERE customerId = @customerID", conn);
                        cmdDeleteCustomer.Parameters.AddWithValue("@customerID", customerID);
                        cmdDeleteCustomer.ExecuteNonQuery();

                        MySqlCommand cmdDeleteAddress = new MySqlCommand("DELETE FROM address WHERE addressId = @addressID", conn);
                        cmdDeleteAddress.Parameters.AddWithValue("@addressID", addressID);
                        cmdDeleteAddress.ExecuteNonQuery();

                        MySqlCommand cmdDeleteCity = new MySqlCommand("DELETE FROM city WHERE cityId = @cityID", conn);
                        cmdDeleteCity.Parameters.AddWithValue("@cityID", cityID);
                        cmdDeleteCity.ExecuteNonQuery();

                        MySqlCommand cmdDeleteCountry = new MySqlCommand("DELETE FROM country WHERE countryId = @countryID", conn);
                        cmdDeleteCountry.Parameters.AddWithValue("@countryID", countryID);
                        cmdDeleteCountry.ExecuteNonQuery();


                        MessageBox.Show("Customer deleted.");

                        RefreshCustomerData();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }

        }

        private void buttonDelAppt_Click(object sender, EventArgs e)
        {
            if (dataGridAppts.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DataGridViewRow selectedRow = dataGridAppts.SelectedRows[0];
                        string appointmentID = selectedRow.Cells["AppointmentID"].Value.ToString();
                        string customerID = selectedRow.Cells["CustomerID"].Value.ToString();
                        string userID = selectedRow.Cells["UserID"].Value.ToString();
                        string startDate = selectedRow.Cells["StartDate"].Value.ToString();
                        string endDate = selectedRow.Cells["EndDate"].Value.ToString();



                        MySqlCommand cmdDeleteAppointment = new MySqlCommand("DELETE FROM appointment WHERE appointmentId = @appointmentID", conn);
                        cmdDeleteAppointment.Parameters.AddWithValue("@appointmentID", appointmentID);
                        cmdDeleteAppointment.ExecuteNonQuery();

                        /*MySqlCommand cmdDeleteCustomer = new MySqlCommand("DELETE FROM customer WHERE customerId = @customerID", conn);
                        cmdDeleteCustomer.Parameters.AddWithValue("@customerID", customerID);
                        cmdDeleteCustomer.ExecuteNonQuery();

                        MySqlCommand cmdDeleteUser = new MySqlCommand("DELETE FROM user WHERE userId = @userID", conn);
                        cmdDeleteUser.Parameters.AddWithValue("@userID", userID);
                        cmdDeleteUser.ExecuteNonQuery();*/

                        MySqlCommand cmdDeleteStartDate = new MySqlCommand("DELETE FROM appointment WHERE start = @startDate", conn);
                        cmdDeleteStartDate.Parameters.AddWithValue("@startDate", startDate);
                        cmdDeleteStartDate.ExecuteNonQuery();

                        MySqlCommand cmdDeleteEndDate = new MySqlCommand("DELETE FROM appointment WHERE end = @endDate", conn);
                        cmdDeleteEndDate.Parameters.AddWithValue("@endDate", endDate);
                        cmdDeleteEndDate.ExecuteNonQuery();


                        MessageBox.Show("Appointment deleted.");

                        RefreshAppointmentData();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            SelectedDate = monthCalendar1.SelectionStart.Date;
            DisplayAppointments(SelectedDate);
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.ShowDialog();
        }
        private void comboBoxReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
