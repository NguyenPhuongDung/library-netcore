using System.Net.Mime;
using AutoMapper;
using Library.Entities;
using Library.Models.Request.User;

namespace Library.Models.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, RegisterUserRequest>().ReverseMap();
        }
    }
}