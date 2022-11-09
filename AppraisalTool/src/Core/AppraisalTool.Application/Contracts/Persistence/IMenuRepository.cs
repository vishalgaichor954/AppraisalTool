using AppraisalTool.Application.Features.Menu.Command.CreateMenuCommand;
using AppraisalTool.Application.Features.Menu.Command.RemoveMenuCommand;
using AppraisalTool.Application.Features.Menu.Command.UpdateMenuCommand;
using AppraisalTool.Application.Features.Menu.Query.GetMenuById;
using AppraisalTool.Application.Features.Menu.Query.GetMenuList;
using AppraisalTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Contracts.Persistence
{
    public interface IMenuRepository
    {
       public  Task<CreateMenuCommandDto> CreateMenu(MenuList menu);
       public Task<bool> AddmenuRole(List<MenuRoleMapping> menurolelist);
        public Task<UpdateMenuCommandDto> UpdateMenuAsync(int id, UpdateMenuCommand request);
        //public Task<List<MenuList>> GetMenuById(int menu_Id);
        public Task<GetMenuByIdDto> GetMenuById(int menu_Id);

        public Task<IEnumerable<GetMenuListQueryVm>> GetAllMenuList();
        public Task<RemoveMenuCommandDto> RemoveMenuAsync(int menu_Id);
    }
}
