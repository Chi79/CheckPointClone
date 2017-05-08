using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckPoint.Views.UserControls
{
    public partial class ApplyToCourseHeader : System.Web.UI.UserControl
    {

        public IEnumerable<object> SetDataSource2
        {
            set { gvHostTable1.DataSource = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void BindData()
        {
            gvHostTable1.DataBind();
        }
    }
}