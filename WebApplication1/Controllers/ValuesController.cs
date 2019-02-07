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

<<<<<<< HEAD
       
      
            SqlConnection connection = new SqlConnection(value.connectionString);
=======
            string deneme = value.connectionString;
            deneme = deneme.Remove(9, 1);
      
            SqlConnection connection = new SqlConnection(deneme);
>>>>>>> 9b4dc2cffe091c40355f6622ad839bdf2014c412
            connection.Open();

            string getString;
            List<string> column;
            List<string> listacolumnas = new List<string>();
            Dictionary<string, string> column2;
            List<List<string>> rows = new List<List<string>>();
            List<Dictionary<string,string>> rows2 = new List<Dictionary<string,string>>();



<<<<<<< HEAD
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

          
=======
            //Get the column names frım the table

            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "select c.name from sys.columns c inner join sys.tables t on t.object_id = c.object_id and t.name = '"+value.name+"' and t.type = 'U'";
  
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listacolumnas.Add(reader.GetString(0));
                    }
                }
            }

            //Get the data from table

            SqlCommand com = new SqlCommand("select * from " + value.name, connection);
            SqlDataReader reader2 = com.ExecuteReader();
            while (reader2.Read())
            {    
                column = new List< string>();

                for (int i = 0; i < listacolumnas.Count; i++)
                {
                    
                    getString= reader2[listacolumnas[i]].ToString();
                    column.Add(getString);
                }
     

                rows.Add(column); 
            }

            SqlCommand com2 = new SqlCommand("select * from " + value.name, connection);
            SqlDataReader reader3 = com2.ExecuteReader();
            while (reader3.Read())
            {
                column2 = new Dictionary<string, string>();

                for (int i = 0; i < listacolumnas.Count; i++)
                {

                    column2[listacolumnas[i]] = reader3[listacolumnas[i]].ToString();
                  
                }


                rows2.Add(column2);
            }

>>>>>>> 9b4dc2cffe091c40355f6622ad839bdf2014c412

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
