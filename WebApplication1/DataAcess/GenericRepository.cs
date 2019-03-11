//using Microsoft.EntityFrameworkCore;
//using OplogDataChartBackend.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace OplogDataChartBackend.DataAcess
//{
//    public interface IGenericRepository
//    {
//        IQueryable<MenuBarUser> GetAll();

//        IQueryable<MenuBarUser> GetAllAsNoTracking();

//    }

//    public class GenericRepository : IGenericRepository
//    {
//        protected readonly DbContext _baseDb;

//        public GenericRepository(DbContext baseDb)
//        {
//            _baseDb = baseDb;
//        }

//        public virtual IQueryable<MenuBarUser> GetAll()
//        {
//            return _baseDb.Set<MenuBarUser>();
//        }

//        public virtual IQueryable<MenuBarUser> GetAllAsNoTracking()
//        {
//            return GetAll().AsNoTracking();
//        }

//    }
//}
