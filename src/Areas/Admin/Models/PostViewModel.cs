using System;

namespace ZJBlog.Areas.Admin.Models
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Published { get; set; }
    }

    public class PostListViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime PostDate { get; set; } 
    }
}