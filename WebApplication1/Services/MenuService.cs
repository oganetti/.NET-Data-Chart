using Microsoft.Extensions.Configuration;
using OplogDataChartBackend.Entities;
using OplogDataChartBackend.Helpers;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OplogDataChartBackend.Dtos;

namespace OplogDataChartBackend.Services
{


    public class MenuServices
    {

        private readonly IConfiguration configuration;

        protected readonly DbContext _baseDb;


        public MenuServices(DbContext context, IConfiguration config)
        {
            _baseDb = context;
            this.configuration = config;
        }



        public IQueryable<MenuBarUserDTO> GetMenu(string userId)
        {
            return _baseDb.Set<MenuBarUser>().Where(x => x.UserId == userId).Select(MenuBarUserDTO.Projection);
        }



    }
}