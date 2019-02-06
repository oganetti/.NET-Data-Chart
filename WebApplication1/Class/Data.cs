using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class Data
    {

        public string connectionString { get; set; }
        public string name { get; set; }


        public Data(string cString, string nameData )
        {
            name = nameData;
            connectionString = cString;
        }

    }
}
