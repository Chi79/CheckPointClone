using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViewPresenter.Core.Presentation.StartPage
{
    public interface IStartPageView
    {
        string Heading { get; set; }
        string Message { get; set; }
    }
}
