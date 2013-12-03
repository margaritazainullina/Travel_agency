using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Travel_agency
{
    class AppUtil
    {
        public static bool isDate(string str) {

            str += " 12:00:00 AM";
            DateTime dt = new DateTime();
            if(DateTime.TryParse(str, out dt))
            {
                return true;
            }
            else return false; 
        }
    }
}
