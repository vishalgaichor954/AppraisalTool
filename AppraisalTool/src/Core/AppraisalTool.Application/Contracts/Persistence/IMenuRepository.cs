using AppraisalTool.Application.Features.Menu.Command.CreateMenuCommand;
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
    }
}
