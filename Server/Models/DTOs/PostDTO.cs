using AutoMapper;
using MyBoost.Server.Mapper;
using MyBoost.Shared.Data;

namespace MyBoost.Server.Models.DTOs
{
    public class PostDTO : IMapFrom<Post>
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, PostDTO>();
        }
    }
}
