using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderCommon.ViewInterfaces
{
    public interface IView
    {
        void HideView();
        void ShowView();

        event EventHandler<EventArgs> ClosePreviousView;

        
    }
}
