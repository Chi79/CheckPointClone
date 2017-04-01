using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Interfaces
{
    public interface IView  //  Base interface that all views must implement
    {
        Uri Uri { get; }
    }
}
//global view attributes can be placed here
