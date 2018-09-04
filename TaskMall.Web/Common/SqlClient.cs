using SqlSugar;

namespace TaskMall.Web
{
    public static class SqlClient
    {
        public readonly static SqlSugarClient Client;

        static SqlClient()
        {
            Client = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=taskmall;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
        }
    }
}