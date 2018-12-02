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
            string listName,typeList;
            int? listID,parentID = null;
            ListType lt;
           
            
            string connectionstring = configuration.GetConnectionString("DefaultConnection");
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand com = new SqlCommand("select * from list", connection);
            var count = com.ExecuteReader();
            while (count.Read())
            {
                listID = Convert.ToInt32(count["listID"]);
                typeList = count["typeList"] as string;
                listName = count["listName"] as string;
                if(count["parentID"] != DBNull.Value)
                    parentID = Convert.ToInt32(count["parentID"]);

        
                lt = new ListType(listID, listName, parentID, typeList);

                myList.Add(lt);
                


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