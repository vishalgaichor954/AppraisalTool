using AppraisalTool.App.Dtos;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.FinancialYear;
using AppraisalTool.App.Models.Menu;
using AutoMapper;

namespace AppraisalTool.App.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserViewModel, UserEncodeDto>().ConvertUsing<EncodeUserListVm>();
            CreateMap<MenuModel, MenuEncodeDto>().ConvertUsing<EncodeMenuListVm>();
            CreateMap<FinancialYear, FinancialYearEncodeDto>().ConvertUsing<EncodeFinancialYearListVm>();
        }
    }
}

