using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_agency
{
    class CurrentOrder
    {
        //заказ
        public static int cl_id;
        public static string cl_name;
        public static int passp_n;
        public static string passp_s;
        public static string cur_date;
        public static int emp_id;
        public static string emp_name;
        public static int sch_id;
        public static int voucher_id;
        public static string b_date;
        public static string e_date;
        public static string transport;
        public static string mealtype;
        public static int price;
        public static List<string> cities = new List<string>();
        public static List<string> hotels = new List<string>();
        public static List<string> excursion = new List<string>();

        //страховой полис
        public static double fee=2.40;
        public static int days;
        public static int ins_amount=10000;

    }
}
