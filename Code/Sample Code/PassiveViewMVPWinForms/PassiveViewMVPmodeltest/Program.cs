using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PassiveViewMVPmodeltest;

namespace PassiveViewMVPmodeltest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ///Model, View and Presenter intantiated and Dependencies injected to each object on loading;
            //frmAppointmentView view = new frmAppointmentView();
            //IAppointmentModel<Appointment> model = new AppointmentsModel();
            //AppointmentPresenter presenter = new AppointmentPresenter(view, model);

            Application.Run(new frmAppointmentView());
        }
    }
}
