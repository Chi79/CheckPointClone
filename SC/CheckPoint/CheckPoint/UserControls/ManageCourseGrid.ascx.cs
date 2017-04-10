using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPoint.Views.UserControls
{
    public partial class ManageCourseGrid : System.Web.UI.UserControl
    {

        public IEnumerable<object> SetDataSource
        {
            set { gvHostTable.DataSource = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

    }
}