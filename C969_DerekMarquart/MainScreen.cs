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
    public partial class MainScreen : Form
    {
        public LoginForm loginForm = new LoginForm();

        public BindingList<Appointment> Appointments = new BindingList<Appointment>();

        public LoginForm LoginFormInstance { get; set; }
        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            dataGridAppt.ReadOnly = true;
            Appointment.PopulateAppt();
            var bindingAppt = new BindingSource();
            bindingAppt.DataSource = Appointment.Appointments;
            dataGridAppt.DataSource = bindingAppt;
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            LoginFormInstance.Show();

            this.Close();

        }
    }
}
