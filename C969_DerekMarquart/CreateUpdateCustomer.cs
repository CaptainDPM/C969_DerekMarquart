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
        public MainScreen MainFormInstance { get; set; }
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
                    MySqlCommand cmd = new MySqlCommand("UPDATE customer " +
                                                "SET " +
                                                "customerName = @customerName " +
                                                "WHERE " +
                                                "customerName = @customerName", conn);

                    cmd.Parameters.AddWithValue("@customerName", textBoxName.Text);

                    cmd.ExecuteNonQuery();

                    MySqlCommand cmdTwo = new MySqlCommand("UPDATE address " +
                                                    "SET " +
                                                    "address = @address, " +
                                                    "phone = @phone " +
                                                    "WHERE " +
                                                    "address = @address " +
                                                    "AND " +
                                                    "phone = @phone", conn);

                    cmdTwo.Parameters.AddWithValue("@address", textBoxAddress.Text);
                    cmdTwo.Parameters.AddWithValue("@phone", textBoxPhone.Text);

                    cmdTwo.ExecuteNonQuery();

                    MySqlCommand cmdThree = new MySqlCommand("UPDATE city " +
                                                    "SET " +
                                                    "city = @city " +
                                                    "WHERE " +
                                                    "city = @city", conn);

                    cmdThree.Parameters.AddWithValue("@city", textBoxCity.Text);

                    cmdThree.ExecuteNonQuery();

                    MySqlCommand cmdFour = new MySqlCommand("UPDATE country " +
                                                    "SET " +
                                                    "country = @country " +
                                                    "WHERE " +
                                                    "country = @country", conn);

                    cmdFour.Parameters.AddWithValue("@country", textBoxCountry.Text);

                    cmdFour.ExecuteNonQuery();

                    MessageBox.Show("Update complete.");

                    MainFormInstance.RefreshCustomerData();

                    this.Close();
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
                        MainFormInstance.RefreshCustomerData();


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
