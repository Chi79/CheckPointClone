using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointCommon.ValidationInterfaces
{
    public interface IValidator<T> where T:class
    {
        bool IsValid(T entity);
        void CheckForBrokenRules(T entity);
        void ClearCollectionOfBrokenRules();
        IEnumerable<string> GetBrokenBusinessRules();
        void AddBrokenRule(string brokenRule);
    }
}
