using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_DerekMarquart
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(constr);

                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            Application.Run(new Form1());
        }
    }
}
