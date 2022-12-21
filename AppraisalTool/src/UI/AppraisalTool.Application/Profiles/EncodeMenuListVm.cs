using AppraisalTool.App.Dtos;
using AppraisalTool.App.Models.Menu;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;
using System.ComponentModel.DataAnnotations;

namespace AppraisalTool.App.Profiles
{
    public class EncodeMenuListVm : ITypeConverter<MenuModel, MenuEncodeDto>
    {
        private readonly IDataProtector _protector;
        public EncodeMenuListVm(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }

        public MenuEncodeDto Convert(MenuModel source, MenuEncodeDto destination, ResolutionContext context)
        {

            MenuEncodeDto dest = new MenuEncodeDto()
            {
                menu_Id = _protector.Protect(source.menu_Id.ToString()),
                MenuText = source.MenuText,
                MenuClass = source.MenuClass,
                MenuIcon = source.MenuIcon,
                MenuFlag = source.MenuFlag,
                MenuController = source.MenuController,
                MenuAction = source.MenuAction,
                MenuLink = source.MenuLink,
                AddedBy = source.AddedBy,
                DeletedBy = source.DeletedBy,
                UpdatedBy = source.UpdatedBy,
                //RoleList = source.RoleList,
                RoleId = source.RoleId,
                RoleName = source.RoleName
    };
            return dest;
        }
    }
}
