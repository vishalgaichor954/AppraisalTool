using AppraisalTool.App.Dtos;
using AppraisalTool.App.Models;
using AutoMapper;

namespace AppraisalTool.App.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserViewModel, UserEncodeDto>().ConvertUsing<EncodeUserListVm>();
        }
    }
}

