using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPointModel.Utilities
{
   public static class ValidateIntergerInput
    {
        //Not tested
        public static bool IsIntergerValid(int integer)
        {
            if(integer < 0)
            {
                return false;
            }              
                return true;
        }
        public static bool AreIntegersValid(List<int> integersList)

        {
            bool IsIntergerValid = false;         
            foreach (int x in integersList)
            {
                if (x < 0) // if one integer is negative, integersList is not valid
                {
                    return false;
                }

                else
                {
                    IsIntergerValid = true;
                }
            }
            return IsIntergerValid;                 
            
        }

    }
}
