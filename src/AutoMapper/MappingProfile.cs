using AutoMapper;
using ZJBlog.Areas.Admin.Models;
using ZJBlog.Models;

namespace ZJBlog.AutoMapper
{
    public class MappingProfile:Profile
    {
        protected override void Configure()
        {
            CreateMap<Post, PostViewModel>();
            CreateMap<PostViewModel, Post>();
        }
    }
}