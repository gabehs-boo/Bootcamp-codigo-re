using AutoMapper;
using Users.API.Domain.Models;
using Users.API.Domain.Models.Queries;
using Users.API.Resources;

namespace Users.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
        }
    }
}