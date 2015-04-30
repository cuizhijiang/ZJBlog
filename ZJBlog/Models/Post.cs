using System;

namespace ZJBlog.Models
{
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid();
            Author = "admin";
            PostDate = DateTime.Now;
            Subtitle = string.Empty;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Author { get; set; }
        public DateTime PostDate { get; set; } 
        public string Content { get; set; }
        public bool Published { get; set; }
    }
}