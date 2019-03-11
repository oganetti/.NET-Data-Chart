using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using OplogDataChartBackend.Entities;

namespace OplogDataChartBackend.Dtos
{
    public class MenuDTO
    {
        public static Expression<Func<MenuBar, MenuDTO>> Projection
        {
            get
            {
                return x => new MenuDTO
                {
                    menuID = x.Id,
                    menuName = x.MenuName,
                    parentID = x.ParentID,
                    menuType = x.MenuType,
                    menuData = x.MenuData,
                    connectionString =x.ConnectionString

                };
            }
        }

        public Guid menuID { get; set; }

        public string menuName { get; set; }

        public Guid? parentID { get; set; }

        public string menuType { get; set; }

        public string menuData { get; set; }

        public string connectionString { get; set; }

    }
}