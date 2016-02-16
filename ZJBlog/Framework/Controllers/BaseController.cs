using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ZJBlog.Framework.Controllers
{
    public class BaseController : Controller
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["zjblog"].ConnectionString;
        protected static DbConnection GetOpenConnection()
        {
            var connection = new MySql.Data.MySqlClient.MySqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
        public ActionResult NotFound()
        {
            return Content("404");
        }
    }
}