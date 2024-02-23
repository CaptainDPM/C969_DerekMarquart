using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_DerekMarquart
{
    public partial class CreateUpdateCustomer : Form
    {
        private MainScreen mainScreenInstance;
        private bool isUpdateMode = false;
        MySqlConnection conn = new MySqlConnection("Host=localhost;Port=3306;Database=client_schedule;Username=sqlUser;Password=Passw0rd!");
        //MySqlConnection conn = new MySqlConnection("Host=localhost;Port=3306;Database=c969;Username=root;Password=abcABC123!@#");

        public string loggedInUser;


        public CreateUpdateCustomer(MainScreen mainScreen, string loggedInUser)
        {
            InitializeComponent();
            this.loggedInUser = loggedInUser;

            int newCustID = GetLastCustID() + 1;
            int newAddID = GetLastAddID() + 1;
            int newCityID = GetLastCityID() + 1;
            int newCountID = GetLastCountID() + 1;
            mainScreenInstance = mainScreen;
            textBoxAddID.Hide();
            textBoxCityID.Hide();
            textBoxCountryID.Hide();
            textBoxCreateDate.Hide();
            textBoxCreatedBy.Hide();
            textBoxID.ReadOnly = true;
            textBoxID.Enabled = false;
            textBoxID.Text = newCustID.ToString();
            textBoxAddID.Text = newAddID.ToString();
            textBoxCityID.Text = newCityID.ToString();
            textBoxCountryID.Text = newCountID.ToString();
            textBoxCreateDate.Text = DateTime.Now.ToString();
            textBoxCreatedBy.Text = loggedInUser;
        }

        public CreateUpdateCustomer(string customerID, string customerName, string addressID ,string address, string phone, string cityID, string city, string countryID, string country)
        {
            InitializeComponent();
            isUpdateMode = true;

            textBoxID.Text = customerID;
            textBoxName.Text = customerName;
            textBoxAddress.Text = address;
            textBoxPhone.Text = phone;
            textBoxCity.Text = city;
            textBoxCountry.Text = country;
            textBoxAddID.Text = addressID;
            textBoxCityID.Text = cityID;
            textBoxCountryID.Text = countryID;
            textBoxAddID.Hide();
            textBoxCityID.Hide();
            textBoxCountryID.Hide();
            textBoxID.ReadOnly = true;
            textBoxID.Enabled = false;

        }

        public int GetLastCustID()
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
        public int GetLastAddID()
        {
            conn.Close();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT MAX(addressId) FROM address", conn);
            int lastID = 0;

            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value && result != null)
            {
                lastID = Convert.ToInt32(result);
            }

            return lastID;
        }
        public int GetLastCityID()
        {
            conn.Close();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT MAX(cityId) FROM city", conn);
            int lastID = 0;

            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value && result != null)
            {
                lastID = Convert.ToInt32(result);
            }

            return lastID;
        }
        public int GetLastCountID()
        {
            conn.Close();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT MAX(countryId) FROM country", conn);
            int lastID = 0;

            object result = cmd.ExecuteScalar();
            if (result != DBNull.Value && result != null)
            {
                lastID = Convert.ToInt32(result);
            }

            return lastID;
        }

        private bool ValidateCustomerFields()
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxAddress.Text) ||
                string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                MessageBox.Show("Please enter all required fields (name, address, phone number).",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string phonePattern = @"^\d{3}-\d{3}-\d{4}$";
            if (!Regex.IsMatch(textBoxPhone.Text, phonePattern))
            {
                MessageBox.Show("Please enter a valid phone number in the format XXX-XXX-XXXX.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {     
            this.Close();
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Close();
                conn.Open();
                
                if (!ValidateCustomerFields())
                {
                    return;
                }
                else
                {
                    if (isUpdateMode)
                    {
                        try
                        {
                            MySqlCommand cmd = new MySqlCommand("UPDATE customer " +
                                                                "SET " +
                                                                "customerName = @newcustomerName " +
                                                                "WHERE " +
                                                                "customerId = @customerID", conn);

                            cmd.Parameters.AddWithValue("@newcustomerName", textBoxName.Text);
                            cmd.Parameters.AddWithValue("@customerID", textBoxID.Text);
                            Console.WriteLine($"New Customer Name Parameter Value: {cmd.Parameters["@newcustomerName"].Value}");

                            cmd.ExecuteNonQuery();

                            MySqlCommand cmdTwo = new MySqlCommand("UPDATE address " +
                                                                    "SET " +
                                                                    "address = @newaddress, " +
                                                                    "phone = @newphone " +
                                                                    "WHERE " +
                                                                    "addressId = @addressID", conn);

                            cmdTwo.Parameters.AddWithValue("@newaddress", textBoxAddress.Text);
                            cmdTwo.Parameters.AddWithValue("@newphone", textBoxPhone.Text);
                            cmdTwo.Parameters.AddWithValue("@addressID", textBoxAddID.Text);

                            cmdTwo.ExecuteNonQuery();

                            MySqlCommand cmdThree = new MySqlCommand("UPDATE city " +
                                                            "SET " +
                                                            "city = @newcity " +
                                                            "WHERE " +
                                                            "cityId = @cityID", conn);

                            cmdThree.Parameters.AddWithValue("@newcity", textBoxCity.Text);
                            cmdThree.Parameters.AddWithValue("@cityID", textBoxCityID.Text);

                            cmdThree.ExecuteNonQuery();

                            MySqlCommand cmdFour = new MySqlCommand("UPDATE country " +
                                                            "SET " +
                                                            "country = @newcountry " +
                                                            "WHERE " +
                                                            "countryId = @countryID", conn);

                            cmdFour.Parameters.AddWithValue("@newcountry", textBoxCountry.Text);
                            cmdFour.Parameters.AddWithValue("@countryID", textBoxCountryID.Text);

                            cmdFour.ExecuteNonQuery();

                            MessageBox.Show("Update complete.");

                            mainScreenInstance?.RefreshCustomerData();
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
                            MySqlCommand cmdInsertCountry = new MySqlCommand("INSERT INTO country (countryId, country) VALUES (@countryId, @country);", conn);

                            cmdInsertCountry.Parameters.AddWithValue("@countryId", textBoxCountryID.Text);
                            cmdInsertCountry.Parameters.AddWithValue("@country", textBoxCountry.Text);

                            cmdInsertCountry.ExecuteNonQuery();

                            long newCountryId = cmdInsertCountry.LastInsertedId;

                            MySqlCommand cmdInsertCity = new MySqlCommand("INSERT INTO city (cityId, city, countryId) VALUES (@cityId, @city, @countryId);", conn);

                            cmdInsertCity.Parameters.AddWithValue("@cityId", textBoxCityID.Text);
                            cmdInsertCity.Parameters.AddWithValue("@city", textBoxCity.Text);
                            cmdInsertCity.Parameters.AddWithValue("@countryId", textBoxCountryID.Text);

                            cmdInsertCity.ExecuteNonQuery();

                            long newCityId = cmdInsertCity.LastInsertedId;

                            MySqlCommand cmdInsertAddress = new MySqlCommand("INSERT INTO address (addressId, address, phone, cityId) VALUES (@addressId, @address, @phone, @cityId);", conn);

                            cmdInsertAddress.Parameters.AddWithValue("@addressId", textBoxAddID.Text);
                            cmdInsertAddress.Parameters.AddWithValue("@address", textBoxAddress.Text);
                            cmdInsertAddress.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                            cmdInsertAddress.Parameters.AddWithValue("@cityId", textBoxCityID.Text);

                            cmdInsertAddress.ExecuteNonQuery();

                            long newAddressId = cmdInsertAddress.LastInsertedId;

                            MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO customer (customerId, customerName, addressId) VALUES (@customerId, @customerName, @addressId);", conn);

                            cmdInsert.Parameters.AddWithValue("@customerId", textBoxID.Text);
                            cmdInsert.Parameters.AddWithValue("@customerName", textBoxName.Text);
                            cmdInsert.Parameters.AddWithValue("@addressId", textBoxAddID.Text);

                            cmdInsert.ExecuteNonQuery();

                            long newCustomerId = cmdInsert.LastInsertedId;



                            MessageBox.Show("Customer created.");

                            mainScreenInstance.RefreshCustomerData();

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
    }
}
