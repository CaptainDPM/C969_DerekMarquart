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
    public partial class CreateUpdateAppt : Form
    {
        private MainScreen mainScreenInstance;
        private bool isUpdateMode = false;
        MySqlConnection conn = new MySqlConnection("Host=localhost;Port=3306;Database=c969;Username=root;Password=abcABC123!@#");

        public CreateUpdateAppt(MainScreen mainScreen)
        {
            InitializeComponent();
            mainScreenInstance = mainScreen;

            int newApptID = GetLastApptID() + 1;
            textBoxApptID.Text = newApptID.ToString();

        }

        public CreateUpdateAppt(string appointmentID, string customerID, string userID, string startDate, string endDate)
        {
            InitializeComponent();
            isUpdateMode = true;

            textBoxApptID.Text = appointmentID;
            textBoxCustID.Text = customerID;
            textBoxUserID.Text = userID;
            textBoxStart.Text = startDate;
            textBoxEnd.Text = endDate;
            textBoxApptID.ReadOnly = true;
            textBoxApptID.Enabled = false;
        }

        public int GetLastApptID()
        {
            conn.Close();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT MAX(appointmentId) FROM appointment", conn);
            int lastID = 0;

            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value && result != null)
            {
                lastID = Convert.ToInt32(result);
            }

            return lastID;
        }
        /*public int GetLastCustID()
        {
            conn.Close();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT MAX(customerId) FROM customer", conn);
            int lastID = 0;

            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value && result != null)
            {
                lastID = Convert.ToInt32(result);
            }

            return lastID;
        }
        public int GetLastUserID()
        {
            conn.Close();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT MAX(userId) FROM user", conn);
            int lastID = 0;

            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value && result != null)
            {
                lastID = Convert.ToInt32(result);
            }

            return lastID;
        }*/

        private bool DoesCustomerExist(string customerID)
        {
            conn.Close();
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM customer WHERE customerId = @customerID", conn);
            cmd.Parameters.AddWithValue("@customerID", customerID);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            conn.Close();

            return count > 0;
        }

        private bool DoesUserExist(string userID)
        {
            conn.Close();
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user WHERE userId = @userID", conn);
            cmd.Parameters.AddWithValue("@userID", userID);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            conn.Close();

            return count > 0;
        }

        private bool IsValidBusinessHours(DateTime start, DateTime end)
        {
            TimeZoneInfo estTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime estStart = TimeZoneInfo.ConvertTimeToUtc(start, estTimeZone);
            DateTime estEnd = TimeZoneInfo.ConvertTimeToUtc(end, estTimeZone);

            return estStart.DayOfWeek >= DayOfWeek.Monday && estStart.DayOfWeek <= DayOfWeek.Friday &&
                   estStart.TimeOfDay >= new TimeSpan(9, 0, 0) && estEnd.TimeOfDay <= new TimeSpan(17, 0, 0);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();

                if (isUpdateMode)
                {
                    try
                    {
                        if (!DoesUserExist(textBoxUserID.Text))
                        {
                            MessageBox.Show("Invalid User ID.");
                            return;
                        }
                        if (!DoesCustomerExist(textBoxCustID.Text))
                        {
                            MessageBox.Show("Invalid Customer ID.");
                            return;
                        }
                        if (!IsValidBusinessHours(DateTime.Parse(textBoxStart.Text), DateTime.Parse(textBoxEnd.Text)))
                        {
                            MessageBox.Show("Appointments must be scheduled during business hours (9:00 a.m. to 5:00 p.m., Monday–Friday, Eastern Standard Time).");
                            return;
                        }

                        MySqlCommand cmd = new MySqlCommand("UPDATE appointment " +
                                                            "SET " +
                                                            "customerId = @newcustomerID, " +
                                                            "start = @newStart, " +
                                                            "end = @newEnd " +
                                                            "WHERE " +
                                                            "appointmentId = @appointmentID", conn);

                        cmd.Parameters.AddWithValue("@newcustomerID", textBoxCustID.Text);
                        cmd.Parameters.AddWithValue("@appointmentID", textBoxApptID.Text);
                        cmd.Parameters.AddWithValue("@newStart", DateTime.Parse(textBoxEnd.Text).ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@newEnd", DateTime.Parse(textBoxEnd.Text).ToString("yyyy-MM-dd HH:mm:ss"));
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Update complete.");

                        mainScreenInstance?.RefreshAppointmentData();
                        Console.WriteLine($"Executing SQL: {cmd.CommandText}");


                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message.ToString());
                        MessageBox.Show($"Error: {ex.Message}");
                    }

                }
                else
                {
                    try
                    {
                        conn.Close();
                        conn.Open();

                        if (!DoesUserExist(textBoxUserID.Text))
                        {
                            MessageBox.Show("Invalid User ID.");
                            return;
                        }
                        if (!DoesCustomerExist(textBoxCustID.Text))
                        {
                            MessageBox.Show("Invalid Customer ID.");
                            return;
                        }
                        if (!IsValidBusinessHours(DateTime.Parse(textBoxStart.Text), DateTime.Parse(textBoxEnd.Text)))
                        {
                            MessageBox.Show("Appointments must be scheduled during business hours (9:00 a.m. to 5:00 p.m., Monday–Friday, Eastern Standard Time).");
                            return;
                        }

                        MySqlCommand cmdInsertAppointment = new MySqlCommand("INSERT INTO appointment (appointmentId, customerId, userId, start, end) VALUES (@appoinmentID, @customerID, @userID, @startDate, @endDate);", conn);

                        cmdInsertAppointment.Parameters.AddWithValue("@userID", textBoxUserID.Text);
                        cmdInsertAppointment.Parameters.AddWithValue("@customerID", textBoxCustID.Text);
                        cmdInsertAppointment.Parameters.AddWithValue("@appoinmentID", textBoxApptID.Text);
                        cmdInsertAppointment.Parameters.AddWithValue("@startDate", DateTime.Parse(textBoxStart.Text).ToString("yyyy-MM-dd HH:mm:ss"));
                        cmdInsertAppointment.Parameters.AddWithValue("@endDate", DateTime.Parse(textBoxEnd.Text).ToString("yyyy-MM-dd HH:mm:ss"));


                        cmdInsertAppointment.ExecuteNonQuery();

                        long newAppointmentId = cmdInsertAppointment.LastInsertedId;

                        MessageBox.Show("Appointment created.");

                        mainScreenInstance.RefreshAppointmentData();

                        this.Close();
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
}
