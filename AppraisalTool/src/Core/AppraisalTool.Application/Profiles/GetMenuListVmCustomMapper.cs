using AppraisalTool.Application.Features.Menu.Query.GetMenuList;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Profiles
{
    public class GetMenuListVmCustomMapper : ITypeConverter<MenuList, GetMenuListQueryVm>
    {

        public GetMenuListQueryVm Convert(MenuList source, GetMenuListQueryVm destination, ResolutionContext context)
        {
            GetMenuListQueryVm dest = new GetMenuListQueryVm()
            {
                Menu_Id = source.Menu_Id,
                MenuText = source.MenuText,
                MenuClass = source.MenuClass,
                MenuIcon = source.MenuIcon,
                MenuFlag = source.MenuFlag,
                MenuController = source.MenuController,
                MenuAction = source.MenuAction,
                MenuLink = source.MenuLink,
                //RoleName = source.RoleMapping.UserRole.Role

            };
            return dest;
        }
    }
}
