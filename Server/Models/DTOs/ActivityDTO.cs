using AutoMapper;
using MyBoost.Server.Mapper;
using MyBoost.Shared.Data;

namespace MyBoost.Server.Models.DTOs
{
    public class ActivityDTO : IMapFrom<Activity>
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public int CommentId { get; set; }
        public int WorklogId { get; set; }
        public int AsigneeId { get; set; }
        public int ReporterId { get; set; }
        public int LabelId { get; set; }
        public int Priority { get; set; }
        public int Estimate { get; set; }
        public string Version { get; set; }
        public int StateId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Activity, ActivityDTO>();
        }
    }
}
