using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_agency
{
    class AppSettings
    {
        public static bool isAuthorised = false;
        public static bool isAdmin = false;
        public static string userName;
        public static int userId = -1;
        public static int currentTourId = -1;
        public static string currentTourName;
        public static int currentHotelId = -1;
        public static string currentHotelName;
        public static int currentScheduleId = -1;
    }
}
