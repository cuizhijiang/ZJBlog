using System.Data.SqlClient;
using System.Web.Mvc;

namespace ZJBlog.Framework.Controllers
{
    public class BaseController : Controller
    {
        private const string ConnectionString =
          @"Data Source=.\SQLEXPRESS;Initial Catalog=zjblog;Integrated Security=True";
        protected static SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}