using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeafoodProject.Models.group.util
{
    public class DBHelper
    {
        public static string getConnectionString()
        {
            string strConnection = "server=.;database=Seafood;uid=sa;pwd=123456;";
            return strConnection;
        }
    }
}
