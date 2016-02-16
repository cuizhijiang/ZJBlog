using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Dapper;
using ZJBlog.Areas.Admin.Models;
using ZJBlog.Framework.Controllers;
using ZJBlog.Models;

namespace ZJBlog.Areas.Admin.Controllers
{
    public class PostController : BaseController
    {
        // GET: Admin/Post
        public ActionResult Index()
        {
            using (var connection = GetOpenConnection())
            {
                IEnumerable<PostListViewModel> list = connection.Query<PostListViewModel>("select id,Title,PostDate from post");
               return View(list);
            }
            
        }

        // GET: Admin/Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Post/Create
        public ActionResult Create()
        {
            return View(new PostViewModel(){Id = Guid.NewGuid()});
        }

        // POST: Admin/Post/Create
        [HttpPost]
        public ActionResult Create(PostViewModel model) 
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = Mapper.Map<PostViewModel, Post>(model);
                    using (var connection = GetOpenConnection())
                    {
                        var result = connection.Execute(
                             "insert into post values(@id,@Title,@Subtitle,@Author,@PostDate,@Content,@Published)", entity);
                        if (result > 0)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                return View(model);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Post/Edit/5
        public ActionResult Edit(Guid id)
        {
            using (var connection = GetOpenConnection())
            {
               var model= connection.Query<PostViewModel>("select Id,Title,Content,Published from post where id=@id",new{id});
               return View("Create", model.First());
            }
            
        }

        // POST: Admin/Post/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, PostViewModel model) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var connection = GetOpenConnection())
                    {
                        var result = connection.Execute(
                             "update post set title=@title,Content=@Content,Published=@Published where id=@id", model);
                        if (result > 0)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                return View("Create", model);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Post/Delete/5
        public ActionResult Delete(Guid id)
        {
            using (var connection = GetOpenConnection())
            {
                var result = connection.Execute(
                             "delete from post where id= @id", new { id });
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
