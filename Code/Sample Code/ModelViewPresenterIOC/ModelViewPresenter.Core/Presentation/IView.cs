using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViewPresenter.Core.Presentation
{
    public interface IView   //base interface for all other interfaces to extend
    {
        Uri Uri { get; }
    }
}
//Any attributes here will be global - Uri simply returns the Http.Context.Current.Request.URL
