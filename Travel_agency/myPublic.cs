using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Добавляем для работы с ADO
using System.Data;
using System.Data.OleDb;


namespace Travel_agency
{
    class myPublic
    {
        //Строка соединения
        public static string connString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\travel_agency.accdb";
              
    }
}
