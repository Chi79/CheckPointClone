using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POCOLibrary;
using InterfaceLibrary;
using AppointmentsPresenter;
using AppointmentsView;
using AppointmentModel;


namespace Driver
{
    public partial class Driver : Form
    {
        public Driver()
        {
            InitializeComponent();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            IAppointmentView view = new frmAppointmentView();
            IAppointmentModel<Appointment> model = new AppointmentsModel();
            new AppointmentPresenter(view, model);

            view.Show();            
        }
    }
}
