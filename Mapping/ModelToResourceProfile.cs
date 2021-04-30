using AutoMapper;
using Users.API.Domain.Models;
using Users.API.Domain.Models.Queries;
using Users.API.Extensions;
using Users.API.Resources;

namespace Users.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();
        }
    }
}