using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckPointDataTables.Tables;

namespace LinQ
{
    class LinqExpressions
    {
        private List<CLIENT> people = new List<CLIENT>();

        private void lol()
        {
            var peopleInSkien = people.Select(person => person.PostalCode == 3715);
        }

        private bool anyPeopleFromSkien()
        {
            return people.Any(person => person.PostalCode == 3715);
        }

        private bool userExist(string username)
        {
            return people.Any(person => person.UserName.Equals(username));
        }

        private CLIENT getUserInfo(string username)
        {
            return people.FirstOrDefault(client => client.UserName.Equals(username));
        }
    }
}
