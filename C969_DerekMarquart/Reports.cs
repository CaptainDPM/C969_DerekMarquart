using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace C969_DerekMarquart
{
    public partial class Reports : Form
    {
        //MySqlConnection conn = new MySqlConnection("Host=localhost;Port=3306;Database=client_schedule;Username=sqlUser;Password=Passw0rd!");
        MySqlConnection conn = new MySqlConnection("Host=localhost;Port=3306;Database=c969;Username=root;Password=abcABC123!@#");

        public Reports()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadMonthlyAppointments()
        {
            try
            {
                MySqlCommand command = new MySqlCommand(
                    @"SELECT MONTH(start) AS Month, COUNT(*) AS AppointmentCount
                    FROM appointment
                    GROUP BY MONTH(start)", conn);

                conn.Open();
                DataTable dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());

                DataTable pivotedTable = new DataTable();
                pivotedTable.Columns.Add("Month");

                for (int i = 1; i <= 12; i++)
                {
                    pivotedTable.Columns.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i), typeof(int));
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    DataRow newRow = pivotedTable.NewRow();
                    int month = Convert.ToInt32(row["Month"]);
                    newRow["Month"] = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
                    newRow[month] = Convert.ToInt32(row["AppointmentCount"]);
                    pivotedTable.Rows.Add(newRow);
                }

                dataGridViewReport.DataSource = pivotedTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void LoadUserAppointments()
        {
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM appointment ORDER BY userId", conn);

                conn.Open();
                DataTable dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());

                dataGridViewReport.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void LoadCustomers()
        {
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM customer", conn);

                conn.Open();
                DataTable dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());
                dataGridViewReport.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void buttonMonthly_Click(object sender, EventArgs e)
        {
            LoadMonthlyAppointments();
        }

        private void buttonUser_Click(object sender, EventArgs e)
        {
            LoadUserAppointments();
        }

        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }
    }
}
