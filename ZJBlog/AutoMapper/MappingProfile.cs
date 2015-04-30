using AutoMapper;
using ZJBlog.Areas.Admin.Models;
using ZJBlog.Models;

namespace ZJBlog.AutoMapper
{
    public class MappingProfile:Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<PostViewModel, Post>();
        }
    }
}