using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointCommon.ModelInterfaces;

namespace CheckPointModel.DataLists
{
    public class UserNameList : IUserNameList<string>
    {
        public IList<string> userNameList = new List<string>();

        public IList<string> List
        {
            get { return userNameList; }
        }
        public void Add(string name)
        {
            userNameList.Add(name);
        }
        public string print()
        {
            return "Lambda!";
        }
    }
}
