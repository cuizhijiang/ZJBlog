using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using MarkdownSharp;
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
                        "select  * from post order by postdate limit {0},10",
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
                var posts = connection.Query<Post>("select * from post where id=@id",new{id}).ToList();
              
                if (!posts.Any())
                {
                   return NotFound();
                }
                var model = posts.First();
                return View(model);
            }
        }
    }
}