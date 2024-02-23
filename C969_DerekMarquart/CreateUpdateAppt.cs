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
        MySqlConnection conn = new MySqlConnection("Host=localhost;Port=3306;Database=client_schedule;Username=sqlUser;Password=Passw0rd!");
        //MySqlConnection conn = new MySqlConnection("Host=localhost;Port=3306;Database=c969;Username=root;Password=abcABC123!@#");


        public CreateUpdateAppt(MainScreen mainScreen)
        {
            InitializeComponent();
            mainScreenInstance = mainScreen;
            conn.Close();
            conn.Open();

            int newApptID = GetLastApptID() + 1;
            textBoxApptID.Text = newApptID.ToString();
            textBoxApptID.ReadOnly = true;
            textBoxApptID.Enabled = false;
            textBoxStart.ReadOnly = true;
            textBoxStart.Enabled = false;
            textBoxEnd.ReadOnly = true;
            textBoxEnd.Enabled = false;

        }

        public CreateUpdateAppt(string appointmentID, string customerID, string userID, string title, string description, string locationName, string contact, string apptType, string startDate, string endDate)
        {
            InitializeComponent();
            isUpdateMode = true;
            conn.Close();
            conn.Open();

            textBoxApptID.Text = appointmentID;
            textBoxCustID.Text = customerID;
            textBoxUserID.Text = userID;
            textBoxStart.Text = startDate;
            textBoxEnd.Text = endDate;
            textBoxTitle.Text = title;
            textBoxDescript.Text = description;
            textBoxLocation.Text = locationName;
            textBoxContact.Text = contact;
            textBoxType.Text = apptType;
            textBoxApptID.ReadOnly = true;
            textBoxApptID.Enabled = false;
            textBoxStart.ReadOnly = true;
            textBoxStart.Hide();
            textBoxEnd.ReadOnly = true;
            textBoxEnd.Hide();

        }

        private DateTime ConvertLocalToUtc(DateTime localTime)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            return TimeZoneInfo.ConvertTimeToUtc(localTime, localTimeZone);
        }

        private DateTime ConvertUtcToLocal(DateTime utcTime)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, localTimeZone);
        }

        private DateTime HandleDaylightSavingTime(DateTime time)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            if (localTimeZone.IsDaylightSavingTime(time))
            {
                time = time.Add(localTimeZone.GetUtcOffset(time).Duration());
            }
            return time;
        }

        private void AdjustAppointmentTimes()
        {
            DateTime startUtc = ConvertLocalToUtc(DateTime.Parse(textBoxStart.Text));
            DateTime endUtc = ConvertLocalToUtc(DateTime.Parse(textBoxEnd.Text));

            startUtc = HandleDaylightSavingTime(startUtc);
            endUtc = HandleDaylightSavingTime(endUtc);

            DateTime startLocal = ConvertUtcToLocal(startUtc);
            DateTime endLocal = ConvertUtcToLocal(endUtc);

            textBoxStart.Text = startLocal.ToString("yyyy-MM-dd HH:mm");
            textBoxEnd.Text = endLocal.ToString("yyyy-MM-dd HH:mm");
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

                AdjustAppointmentTimes();

                if (isUpdateMode)
                {
                    //using (MySqlConnection updateConn = new MySqlConnection("Host=localhost;Port=3306;Database=client_schedule;Username=sqlUser;Password=Passw0rd!"))
                    using (MySqlConnection updateConn = new MySqlConnection("Host=localhost;Port=3306;Database=c969;Username=root;Password=abcABC123!@#"))

                    {
                        updateConn.Open();

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
                                                                "end = @newEnd, " +
                                                                "title = @title, " +
                                                                "description = @description, " +
                                                                "location = @location, " +
                                                                "contact = @contact, " +
                                                                "type = @type " +
                                                                "WHERE " +
                                                                "appointmentId = @appointmentID", updateConn);

                            cmd.Parameters.AddWithValue("@newcustomerID", textBoxCustID.Text);
                            cmd.Parameters.AddWithValue("@appointmentID", textBoxApptID.Text);
                            cmd.Parameters.AddWithValue("@newStart", DateTime.Parse(textBoxEnd.Text).ToString("yyyy-MM-dd HH:mm"));
                            cmd.Parameters.AddWithValue("@newEnd", DateTime.Parse(textBoxEnd.Text).ToString("yyyy-MM-dd HH:mm"));
                            cmd.Parameters.AddWithValue("@title", textBoxTitle.Text);
                            cmd.Parameters.AddWithValue("@description", textBoxDescript.Text);
                            cmd.Parameters.AddWithValue("@location", textBoxLocation.Text);
                            cmd.Parameters.AddWithValue("@contact", textBoxContact.Text);
                            cmd.Parameters.AddWithValue("@type", textBoxType.Text);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Update complete.");

                            mainScreenInstance.SelectedDate = mainScreenInstance.SelectedDate;

                            mainScreenInstance.DisplayAppointments(mainScreenInstance.SelectedDate);
                            Console.WriteLine($"Executing SQL: {cmd.CommandText}");


                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message.ToString());
                            MessageBox.Show($"Error: {ex.Message}");
                        }
                    }

                }
                else
                {
                    //using (MySqlConnection insertConn = new MySqlConnection("Host=localhost;Port=3306;Database=client_schedule;Username=sqlUser;Password=Passw0rd!"))
                    using (MySqlConnection insertConn = new MySqlConnection("Host=localhost;Port=3306;Database=c969;Username=root;Password=abcABC123!@#"))

                    {
                        insertConn.Open();

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

                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand("SELECT start, end FROM appointment WHERE userId = @userId", conn);
                            cmd.Parameters.AddWithValue("@userId", textBoxUserID.Text);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                DateTime existingStart = reader.GetDateTime(0);
                                DateTime existingEnd = reader.GetDateTime(1);

                                if (DateTime.Parse(textBoxStart.Text) < existingEnd && DateTime.Parse(textBoxEnd.Text) > existingStart)
                                {
                                    MessageBox.Show("Cannot schedule overlapping appointments.");
                                    reader.Close();
                                    return;
                                }
                            }

                            reader.Close();

                            MySqlCommand cmdInsertAppointment = new MySqlCommand("INSERT INTO appointment (appointmentId, customerId, userId, start, end, title, description, location, contact, type) VALUES (@appoinmentID, @customerID, @userID, @startDate, @endDate, @title, @description, @location, @contact, @type);", insertConn);

                            cmdInsertAppointment.Parameters.AddWithValue("@userID", textBoxUserID.Text);
                            cmdInsertAppointment.Parameters.AddWithValue("@customerID", textBoxCustID.Text);
                            cmdInsertAppointment.Parameters.AddWithValue("@appoinmentID", textBoxApptID.Text);
                            cmdInsertAppointment.Parameters.AddWithValue("@startDate", DateTime.Parse(textBoxStart.Text).ToString("yyyy-MM-dd HH:mm"));
                            cmdInsertAppointment.Parameters.AddWithValue("@endDate", DateTime.Parse(textBoxEnd.Text).ToString("yyyy-MM-dd HH:mm"));
                            cmdInsertAppointment.Parameters.AddWithValue("@title", textBoxTitle.Text);
                            cmdInsertAppointment.Parameters.AddWithValue("@description", textBoxDescript.Text);
                            cmdInsertAppointment.Parameters.AddWithValue("@location", textBoxLocation.Text);
                            cmdInsertAppointment.Parameters.AddWithValue("@contact", textBoxContact.Text);
                            cmdInsertAppointment.Parameters.AddWithValue("@type", textBoxType.Text);

                            cmdInsertAppointment.ExecuteNonQuery();

                            long newAppointmentId = cmdInsertAppointment.LastInsertedId;

                            MessageBox.Show("Appointment created.");

                            mainScreenInstance.SelectedDate = mainScreenInstance.SelectedDate;

                            mainScreenInstance.DisplayAppointments(mainScreenInstance.SelectedDate);

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

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDateTime = dateTimePickerStart.Value;
            
            TimeZoneInfo estTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime estDateTime = TimeZoneInfo.ConvertTimeToUtc(selectedDateTime, estTimeZone);

            textBoxStart.Text = estDateTime.ToString("yyyy-MM-dd HH:mm");
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDateTime = dateTimePickerEnd.Value;

            TimeZoneInfo estTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime estDateTime = TimeZoneInfo.ConvertTimeToUtc(selectedDateTime, estTimeZone);

            textBoxEnd.Text = estDateTime.ToString("yyyy-MM-dd HH:mm");

        }
    }
}
