using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class ListType
    {
        public int? listID { get; set; }
        public string listName { get; set; }
        public int? parentID { get; set; }
        public string typeList { get; set; }

        public ListType(int? ID, string name,int? parent,string type)
        {
            listID = ID;
            listName = name;
            parentID = parent;
            typeList = type;
        }

    }
}
