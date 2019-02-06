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

       
      
            SqlConnection connection = new SqlConnection(value.connectionString);
            connection.Open();

            string getString;
            List<string> column;
            List<string> listacolumnas = new List<string>();
            Dictionary<string, string> column2;
            List<List<string>> rows = new List<List<string>>();
            List<Dictionary<string,string>> rows2 = new List<Dictionary<string,string>>();



            //Get the data from table

            SqlCommand com = new SqlCommand(value.name, connection);
            SqlDataReader reader2 = com.ExecuteReader();
            int k = 0;
            while (reader2.Read())
            {    
                column = new List< string>();
                column2 = new Dictionary<string, string>();
                


                for (int i = 0; i < reader2.FieldCount; i++)
                {
                    
                    string test = reader2.GetName(i);
                    getString= reader2[test].ToString();
                    column.Add(getString);
                    column2[test] = reader2[test].ToString();

                }

                string test2 = reader2.GetName(k);
                k++;
                listacolumnas.Add(test2);


                rows.Add(column);
                rows2.Add(column2);

            }

          

            connection.Close();

            return Json(new { listacolumnas, rows,rows2});
 
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
