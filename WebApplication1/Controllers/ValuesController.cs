using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Controllers
{

    

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {


        private readonly IConfiguration configuration;




        public ValuesController(IConfiguration config)
        {
            this.configuration = config;

        }

        // GET api/values
        [HttpGet]
        [EnableCors("AllowSpecificOrigin")]
        public IEnumerable<string> Get()
        {


            return new string[] { "Ogan", "Dragonetti" };
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]Data value)
        {

          
      
            SqlConnection connection = new SqlConnection("Server =.\\SQLEXPRESS; Database = test; Trusted_Connection = True; MultipleActiveResultSets = true");
            connection.Open();

            string deneme;
            List<string> column;
            List<string> listacolumnas = new List<string>();
            List<List<string>> rows = new List<List<string>>();

            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "select c.name from sys.columns c inner join sys.tables t on t.object_id = c.object_id and t.name = 'salary' and t.type = 'U'";
  
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listacolumnas.Add(reader.GetString(0));
                    }
                }
            }

            SqlCommand com = new SqlCommand("select * from " + value.name, connection);
            SqlDataReader reader2 = com.ExecuteReader();
            while (reader2.Read())
            {    //Every new row will create a new dictionary that holds the columns
                column = new List< string>();

                for (int i = 0; i < listacolumnas.Count; i++)
                {
                    
                    deneme= reader2[listacolumnas[i]].ToString();
                    column.Add(deneme);
                }
     

                rows.Add(column); //Place the dictionary into the list
            }


            connection.Close();

            return Json(new { listacolumnas, rows});
 
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

           
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
