using AutoMapper;
using EntityChallenger.Data.Dtos;
using EntityChallenger.Model;

namespace EntityChallenger.Profiles;

public class AdminProfile : Profile
{
    public AdminProfile()
    {
        CreateMap<CreateAdminDto,Admin>();
    }
}
