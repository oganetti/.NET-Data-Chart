namespace OplogDataChartBackend.Entities
{
    public class Data
    {

        public string connectionString { get; set; }
        public string name { get; set; }

        public Data(string cString, string nameData )
        {
            name = nameData;
            connectionString = cString;
        }

    }
}
