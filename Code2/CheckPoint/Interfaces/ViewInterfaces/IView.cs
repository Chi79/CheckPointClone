using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ViewInterfaces
{
    public interface IView   //base interface for all other views to implement or extend
    {
        Uri Uri { get; }
    }
}
//Any attributes here will be global - Uri simply returns the Http.Context.Current.Request.URL
