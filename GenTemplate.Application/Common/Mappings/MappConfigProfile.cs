using AutoMapper;
using GenTemplate.Domain.Models;
using static GenTemplate.Application.Features.Post.GetPost.GetPostContract;

namespace GenTemplate.Application.Common.Mappings
{
    public class MappConfigProfile : Profile
    {
        public MappConfigProfile()
        {

            CreateMap<Post, PostResponse>()
                .ForMember(dest => dest.Content, act => act.MapFrom(src => src.Body))
                .ForMember(dest => dest.PostIdentify, act => act.MapFrom(src => src.Id));
                
        }
    }
}
