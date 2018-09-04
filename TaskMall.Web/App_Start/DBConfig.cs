using TaskMall.Web.Models;

namespace TaskMall.Web
{
    public class DBConfig
    {
        public static void InitDataTables()
        {
            SqlClient.Client.CodeFirst
                .InitTables(
                typeof(Users),
                typeof(UserBalance),
                typeof(BalanceLog),
                typeof(Tasks),
                typeof(UserTask),
                typeof(UserAdmin)

                );
        }
    }
}