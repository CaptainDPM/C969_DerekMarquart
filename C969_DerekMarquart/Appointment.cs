using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_DerekMarquart
{
    public class Appointment
    {

        private string startDate;
        private string endDate;
        private int appointmentId;
        private int customerId;
        private int userId;


        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public int AppointmentID
        {
            get { return appointmentId; }
            set { appointmentId = value; }
        }

        public int CustomerID
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public int UserID
        {
            get { return userId; }
            set { userId = value; }
        }

        public static object Appointments { get; internal set; }

        public Appointment(int appointmentId, int customerId, int userId, string startDate, string endDate)
        {
            AppointmentID = appointmentId;
            CustomerID = customerId;
            UserID = userId;
            StartDate = startDate;
            EndDate = endDate;
        }

        public static void PopulateAppt()
        {
            Appointment testStartDate = new Appointment(1, 1, 1, "01-20-2024", "01-21-2024");
        }
    }
}
