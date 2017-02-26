using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using POCOClassLibrary;
using InterfaceLibrary;
using AppointmentModel;
using AppointmentsPresenter;
using WebFormMVP;

namespace WebDriver
{
    public partial class WebDriver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLaunch_Click(object sender, EventArgs e)
        {
            //IAppointmentView view = new frmAppointmentView();
            IAppointmentView view = new frmAppointmentView();
            IAppointmentModel<Appointment> model = new AppointmentsModel();
            new AppointmentPresenter(view, model);

            view.Show();
        }
    }
}