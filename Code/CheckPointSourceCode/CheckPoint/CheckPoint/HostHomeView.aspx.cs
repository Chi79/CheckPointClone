﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CheckPointCommon.ViewInterfaces;
using CheckPointPresenters.Bases;
using CheckPointPresenters.Presenters;

namespace CheckPoint.Views
{
    public partial class HostHomeView : ViewBase<HostHomePresenter> , IHostHomeView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO
        }
    }
}