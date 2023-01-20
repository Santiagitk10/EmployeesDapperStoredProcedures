namespace EmployeesDapper
{
    public class DBConnection: IDBConnection
    {

        private readonly IConfiguration _config;
        

        public DBConnection(IConfiguration config)
        {
            _config= config;
        }

        public string GetConnectionString()
        {
           return _config.GetConnectionString("EmployeeDapperConnection");
        }

    }
}
