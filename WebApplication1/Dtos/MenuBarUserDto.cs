using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using OplogDataChartBackend.Entities;

namespace OplogDataChartBackend.Dtos
{
    public class MenuBarUserDTO
    {
        public static Expression<Func<MenuBarUser, MenuBarUserDTO>> Projection
        {
            get
            {
                return x => new MenuBarUserDTO
                {
                    menuID = x.MenuBar.Id,
                    menuName = x.MenuBar.MenuName,
                    parentID = x.MenuBar.ParentID,
                    menuType = x.MenuBar.MenuType,
                    menuData = x.MenuBar.MenuData,
                    connectionString = x.MenuBar.ConnectionString

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