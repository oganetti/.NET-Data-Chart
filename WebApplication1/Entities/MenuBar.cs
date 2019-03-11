using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OplogDataChartBackend.Entities
{
    public class MenuBar
    {
        internal HashSet<MenuBarUser> _menubaruser = new HashSet<MenuBarUser>();

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public string MenuName { get; set; }

        public Guid? ParentID { get; set; }

        public string MenuType { get; set; }

        public string MenuData { get; set; }

        public string ConnectionString { get; set; }

        public IReadOnlyCollection<MenuBarUser> MenuBarUsers { get => _menubaruser.ToList(); }


        protected MenuBar() { }

        public MenuBar(Guid id, string name, Guid? parent, string type, string data, string cString)

        {
            Id = id;
            MenuName = name;
            ParentID = parent;
            MenuType = type;
            MenuData = data;
            ConnectionString = cString;
        }
    }
}
