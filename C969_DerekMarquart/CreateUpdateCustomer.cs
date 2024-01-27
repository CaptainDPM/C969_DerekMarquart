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
        private MainScreen mainScreenInstance;
        private bool isUpdateMode = false;
        MySqlConnection conn = new MySqlConnection("Host=localhost;Port=3306;Database=c969;Username=root;Password=abcABC123!@#");

        

        public CreateUpdateCustomer(MainScreen mainScreen)
        {
            InitializeComponent();
            mainScreenInstance = mainScreen;
            textBoxAddID.Visible = false;
            textBoxCityID.Visible = false;
            textBoxCountryID.Visible = false;
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

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {     
            this.Close();
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                
                if (isUpdateMode)
                {
                   try
                    {
                        MySqlCommand cmd = new MySqlCommand("UPDATE customer " +
                                                            "SET " +
                                                            "customerName = @newcustomerName " +
                                                            "WHERE " +
                                                            "customerId = @customerID", conn) ;

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
                        MySqlCommand cmdInsert = new MySqlCommand("INSERT INTO customer (customerName) VALUES (@customerName);", conn);

                        cmdInsert.Parameters.AddWithValue("@customerName", textBoxName.Text);

                        cmdInsert.ExecuteNonQuery();

                        long newCustomerId = cmdInsert.LastInsertedId;

                        MySqlCommand cmdInsertAddress = new MySqlCommand("INSERT INTO address (address, phone) VALUES (@address, @phone);", conn);

                        cmdInsertAddress.Parameters.AddWithValue("@address", textBoxAddress.Text);
                        cmdInsertAddress.Parameters.AddWithValue("@phone", textBoxPhone.Text);

                        cmdInsertAddress.ExecuteNonQuery();

                        long newAddressId = cmdInsertAddress.LastInsertedId;

                        MySqlCommand cmdInsertCity = new MySqlCommand("INSERT INTO city (city) VALUES (@city);", conn);

                        cmdInsertCity.Parameters.AddWithValue("@city", textBoxCity.Text);

                        cmdInsertCity.ExecuteNonQuery();

                        long newCityId = cmdInsertCity.LastInsertedId;

                        MySqlCommand cmdInsertCountry = new MySqlCommand("INSERT INTO country (country) VALUES (@country);", conn);

                        cmdInsertCountry.Parameters.AddWithValue("@country", textBoxCountry.Text);

                        cmdInsertCountry.ExecuteNonQuery();

                        long newCountryId = cmdInsertCountry.LastInsertedId;

                        MessageBox.Show("Customer created.");

                        mainScreenInstance?.RefreshCustomerData();

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
