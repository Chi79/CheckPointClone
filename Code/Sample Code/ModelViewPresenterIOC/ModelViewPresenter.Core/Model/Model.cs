using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViewPresenter.Core.Model
{
    public class Model : IModel
    {
        public string GetHeading(string text)
        {
            return string.IsNullOrEmpty(text) ?  "Sad text.." :  string.Concat("Finally ", text);
        }
        public string GetMessage(string text)
        {
            return string.IsNullOrEmpty(text) ?  "SAD TEXT.." :  string.Concat("HOORAY ", text);
        }
    }
}
