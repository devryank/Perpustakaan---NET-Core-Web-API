using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Perpustakaan
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserForCreationDto, User>();

            CreateMap<UserForUpdateDto, User>();

            CreateMap<LoginRequestDto, User>();
        }
    }
}
