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
    public partial class CreateUpdateCustomer : Form
    {
        private bool isUpdateMode = false;
        MySqlConnection conn = new MySqlConnection("Host=localhost;Port=3306;Database=c969;Username=root;Password=abcABC123!@#");

        public CreateUpdateCustomer()
        {
            InitializeComponent();
        }

        public CreateUpdateCustomer(string customerName, string address, string phone, string city, string country)
        {
            InitializeComponent();
            isUpdateMode = true;

            textBoxName.Text = customerName;
            textBoxAddress.Text = address;
            textBoxPhone.Text = phone;
            textBoxCity.Text = city;
            textBoxCountry.Text = country;

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                if (isUpdateMode)
                {
            // Update customer table
                    MySqlCommand cmd = new MySqlCommand("UPDATE customer " +
                                                "SET " +
                                                "customerName = @customerName " +
                                                "WHERE " +
                                                "customerId = @customerId", conn);

            // Add parameters
                    cmd.Parameters.AddWithValue("@customerName", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@customerId", "SELECT customerId FROM customer WHERE customerName = @customerName;");

            // Execute the update command for the customer table
                    cmd.ExecuteNonQuery();

            // Update address table
                    MySqlCommand cmdTwo = new MySqlCommand("UPDATE address " +
                                                    "SET " +
                                                    "address = @address, " +
                                                    "phone = @phone " +
                                                    "WHERE " +
                                                    "addressId = @addressId", conn);

            // Add parameters
                    cmdTwo.Parameters.AddWithValue("@address", textBoxAddress.Text);
                    cmdTwo.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                    cmdTwo.Parameters.AddWithValue("@addressId", "SELECT addressId FROM address WHERE address = @address;");

            // Execute the update command for the address table
                    cmdTwo.ExecuteNonQuery();

            // Update city table
                    MySqlCommand cmdThree = new MySqlCommand("UPDATE city " +
                                                    "SET " +
                                                    "city = @city " +
                                                    "WHERE " +
                                                    "cityId = @cityId", conn);

            // Add parameters
                    cmdThree.Parameters.AddWithValue("@city", textBoxCity.Text);
                    cmdThree.Parameters.AddWithValue("@cityId", "SELECT cityId FROM city WHERE city = @city;");

            // Execute the update command for the city table
                    cmdThree.ExecuteNonQuery();

            // Update country table
                    MySqlCommand cmdFour = new MySqlCommand("UPDATE country " +
                                                    "SET " +
                                                    "country = @country " +
                                                    "WHERE " +
                                                    "countryId = @countryId", conn);

            // Add parameters
                    cmdFour.Parameters.AddWithValue("@country", textBoxCountry.Text);
                    cmdFour.Parameters.AddWithValue("@countryId", "SELECT countryId FROM country WHERE country = @country;");

            // Execute the update command for the country table
                    cmdFour.ExecuteNonQuery();

                    this.Close();
                }
                else
                {
            // Handle insert logic for new customer
                }
            }
            catch (Exception ex)
            {
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
        private void buttonExit_Click(object sender, EventArgs e)
        {     
            this.Close();
        }
    }
}
