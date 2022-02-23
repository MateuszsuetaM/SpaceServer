using UploadFilesServer.DTO;
using UploadFilesServer.Models;
using AutoMapper;

namespace UploadFilesServer.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
