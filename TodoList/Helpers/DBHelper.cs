using System.Data.SqlClient;

namespace TodoList.Helpers
{
    public class DbHelper
    {
        //quick helper function to keep connections clean and easy
        const string DBserver = @"(localdb)\MSSQLLocalDB";
        const string DBname = @"ToDoList";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=" + DBserver + ";Initial Catalog="+ DBname + ";");
        }
    }
}
