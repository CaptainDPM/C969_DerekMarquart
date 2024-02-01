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
        MySqlConnection conn = new MySqlConnection("Host=localhost;Port=3306;Database=c969;Username=root;Password=abcABC123!@#");
        public CreateUpdateAppt(MainScreen mainScreen)
        {
            InitializeComponent();
            mainScreenInstance = mainScreen;

            int newApptID = GetLastApptID() + 1;
            int newCustID = GetLastCustID() + 1;
            int newUserID = GetLastUserID() + 1;
            textBoxApptID.Text = newApptID.ToString();
            textBoxCustID.Text = newCustID.ToString();
            textBoxUserID.Text = newUserID.ToString();

        }

        public CreateUpdateAppt(string appointmentID, string customerID, string userID, string startDate, string endDate)
        {
            InitializeComponent();

            textBoxApptID.Text = appointmentID;
            textBoxCustID.Text = customerID;
            textBoxUserID.Text = userID;
            textBoxStart.Text = startDate;
            textBoxEnd.Text = endDate;
            textBoxApptID.ReadOnly = true;
            textBoxCustID.ReadOnly = true;
            textBoxUserID.ReadOnly = true;
            textBoxApptID.Enabled = false;
            textBoxCustID.Enabled = false;
            textBoxUserID.Enabled = false;
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
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
