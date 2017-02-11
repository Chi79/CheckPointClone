using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViewPresenter.Core.Model
{
    public interface IModel
    {
        string GetHeading(string text);
        string GetMessage(string text);
    }
}
