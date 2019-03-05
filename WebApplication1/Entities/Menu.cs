namespace OplogDataChartBackend.Entities
{
    public class Menu
    {
        public int? menuID { get; set; }
        public string menuName { get; set; }
        public int? parentID { get; set; }
        public string menuType { get; set; }
        public string menuData { get; set; }
        public string connectionString { get; set; }

        public Menu(int? ID, string name,int? parent,string type,string data,string cString )
        {
            menuID = ID;
            menuName = name;
            parentID = parent;
            menuType = type;
            menuData = data;
            connectionString = cString;
        }

    }
}
