using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Controllers


{

    [Route("api/[controller]")]
    public class ListController : Controller

    {
        private readonly IConfiguration configuration;




        public ListController(IConfiguration config)
        {
            this.configuration = config;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Get()
        {

            ArrayList myList = new ArrayList();
            string menuName,menuType,menuData,cString;
            int? menuID,parentID = null;
            ListType lt;
           
            
            string connectionstring = configuration.GetConnectionString("DefaultConnection");
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand com = new SqlCommand("select * from menu", connection);
            var count = com.ExecuteReader();
            while (count.Read())
            {
                menuID = Convert.ToInt32(count["ID"]);
                menuType = count["menuType"] as string;
                menuName = count["menuName"] as string;
                menuData = count["menuData"] as string;
                cString = count["connectionString"] as string;
                if(count["parentID"] != DBNull.Value)
                    parentID = Convert.ToInt32(count["parentID"]);

        
                lt = new ListType(menuID, menuName, parentID, menuType,menuData,cString);

                myList.Add(lt);

                parentID = null;

            }
            connection.Close();

            return Json( myList );
        }

        public IActionResult Welcome(string name,int totalTimes = 5)
        {
            ViewData["message"] = "Hi" + name;
            ViewData["totalTimes"] = totalTimes;
            return View();
        }
    }
}