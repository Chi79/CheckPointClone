using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPoint.Views.UserControls
{
    public partial class CourseCreator : System.Web.UI.UserControl
    {

        public string CourseName
        {
            get { return txtCourseName.Text; }
            set { txtCourseName.Text = value; }
        }

        public string Description
        {
            get { return txtDescription.Text; }
            set { txtDescription.Text = value; }
        }

        public string IsPrivate
        {
            get { return ddlIsPrivate.SelectedValue; }
            set { ddlIsPrivate.Text = value;  }
        }

        public string IsObligatory
        {
            get { return ddlIsObligatory.SelectedValue; }
            set { ddlIsObligatory.Text = value; }
        }

        public string Message
        {
            get { return lblMessage.Text; }

            set { lblMessage.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}