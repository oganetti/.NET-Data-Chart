using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Data.SqlClient;
using OplogDataChartBackend.Entities;
using OplogDataChartBackend.Helpers;
using OplogDataChartBackend.DataAcess;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OplogDataChartBackend.Dtos;

namespace OplogDataChartBackend.Services
{


    public class MenuServices
    {
        private DataContext _context;

        private readonly IConfiguration configuration;

        protected readonly DbContext _baseDb;


        public MenuServices(DbContext context, IConfiguration config)
        {
            _baseDb = context;
            this.configuration = config;
        }

        //public Object ReturnMenuList()
        //{

        //    ArrayList myList = new ArrayList();
        //    string menuName, menuType, menuData, cString;
        //    int? menuID, parentID = null;
        //    Menu lt;

        //    //Get the data from the specific connection string

        //    string connectionstring = configuration.GetConnectionString("DefaultConnection2");
        //    SqlConnection connection = new SqlConnection(connectionstring);
        //    connection.Open();
        //    SqlCommand com = new SqlCommand("select * from menu", connection);
        //    var count = com.ExecuteReader();
        //    while (count.Read())
        //    {
        //        menuID = Convert.ToInt32(count["ID"]);
        //        menuType = count["menuType"] as string;
        //        menuName = count["menuName"] as string;
        //        menuData = count["menuData"] as string;
        //        cString = count["connectionString"] as string;
        //        if (count["parentID"] != DBNull.Value)
        //            parentID = Convert.ToInt32(count["parentID"]);


        //        lt = new Menu(menuID, menuName, parentID, menuType, menuData, cString);

        //        myList.Add(lt);

        //        parentID = null;

        //    }
        //    connection.Close();

        //    return myList;

        //}


        public IQueryable<MenuBarUserDTO> GetMenu(string userId)
        {
            return _baseDb.Set<MenuBarUser>().Where(x => x.UserId == userId).Select(MenuBarUserDTO.Projection);
        }



    }
}