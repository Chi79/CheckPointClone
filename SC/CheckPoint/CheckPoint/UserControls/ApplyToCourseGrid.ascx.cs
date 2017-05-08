using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPoint.Views.UserControls
{
    public partial class ApplyToCourseGrid : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IEnumerable<object> SetDataSource
        {
            set { gvHostTable.DataSource = value; }
        }

    }
}