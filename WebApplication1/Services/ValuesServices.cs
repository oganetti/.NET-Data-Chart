using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using OplogDataChartBackend.Entities;
using OplogDataChartBackend.Helpers;

namespace OplogDataChartBackend.Services
{


    public class ValuesServices 
    {
        private DataContext _context;

        public ValuesServices(DataContext context)
        {
            _context = context;
        }

        public Object ReturnValues(Data value)
        {

            SqlConnection connection = new SqlConnection(value.connectionString);
            connection.Open();

            string getString;
            List<string> column;
            List<string> listacolumnas = new List<string>();
            Dictionary<string, string> column2;
            List<List<string>> rows = new List<List<string>>();
            List<Dictionary<string, string>> rows2 = new List<Dictionary<string, string>>();

            //Get the data from table

            SqlCommand com = new SqlCommand(value.name, connection);
            SqlDataReader reader2 = com.ExecuteReader();

            while (reader2.Read())
            {
                column = new List<string>();
                column2 = new Dictionary<string, string>();

                for (int i = 0; i < reader2.FieldCount; i++)
                {

                    string test = reader2.GetName(i);
                    getString = reader2[test].ToString();
                    column.Add(getString);
                    column2[test] = reader2[test].ToString();

                }

                rows.Add(column);
                rows2.Add(column2);

            }

            for (int i = 0; i < reader2.FieldCount; i++)
            {
                string test2 = reader2.GetName(i);
                listacolumnas.Add(test2);
            }

            connection.Close();

            var result = new { listacolumnas, rows, rows2 };

            return result;

        }


    }
}