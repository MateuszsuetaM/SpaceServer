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
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email))
                //.ForMember(u => u.Email, opt => opt.MapFrom(x => x.Name));
                .ForMember(u => u.Address, opt => opt.MapFrom(x => x.Email))
                .ForMember(u => u.Name, opt => opt.MapFrom(x => x.Email));
                //.ForMember(u => u.Address, opt => opt.MapFrom(x => x.ad));
        }
    }
}
