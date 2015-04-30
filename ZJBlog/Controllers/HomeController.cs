using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using ZJBlog.Framework.Controllers;
using ZJBlog.Models;

namespace ZJBlog.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(int page=1)
        {
            using (var connection = GetOpenConnection())
            {
                var sql =
                    string.Format(
                        "select top 10 * from post where id not in(select top {0} id from post order by postdate) order by postdate",
                        10*(page - 1));
                var posts = connection.Query<Post>(sql);
                return View(posts);
            }
        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Post(Guid id)
        {
            using (var connection = GetOpenConnection())
            {
                var posts = connection.Query<Post>("select * from post where id=@id",new{id});
                if (!posts.Any())
                {
                   return NotFound();
                }
                return View(posts.First());
            }
        }

        public ActionResult NotFound()
        {
            return Content("404");
        }
    }
}