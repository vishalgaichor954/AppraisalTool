using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Menu.Command.CreateMenuCommand;
using AppraisalTool.Application.Features.Menu.Command.RemoveMenuCommand;
using AppraisalTool.Application.Features.Menu.Command.UpdateMenuCommand;
using AppraisalTool.Application.Features.Menu.Query.GetMenuById;
using AppraisalTool.Application.Features.Menu.Query.GetMenuList;
using AppraisalTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Persistence.Repositories
{
    public class MenuRepository : BaseRepository<MenuList>, IMenuRepository
    {
        private readonly IUserRepository _userRepository;

        public MenuRepository(ApplicationDbContext dbContext, ILogger<MenuList> logger, IUserRepository userRepository) : base(dbContext, logger)
        {
            _userRepository=userRepository;
        }


        //@Author : Triveni patil
        public async Task<bool> AddmenuRole(List<MenuRoleMapping> menurolelist)
        {
            try
            {
                await _dbContext.MenuRoleMappings.AddRangeAsync(menurolelist);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        //@Author : Triveni patil
        public async Task<CreateMenuCommandDto> CreateMenu(MenuList menu)
        {
            var menuList=_dbContext.MenuLists.Where(x=>x.Menu_Id==menu.Menu_Id).FirstOrDefault();
            CreateMenuCommandDto response = new CreateMenuCommandDto();
            if(menuList != null)
            {
                response.Message = "Failed to add menu";
                response.Succeeded = false;
                return response;
            }
            var result=await _dbContext.MenuLists.AddAsync(menu);
            
            await _dbContext.SaveChangesAsync();
            response.Id = menu.Menu_Id;
            response.Message = "Menu Added Successfully";
            response.Succeeded = true;
            return response;
        }

        public async Task<UpdateMenuCommandDto> UpdateMenuAsync(int id, UpdateMenuCommand request)
        {
            var menuToUpdate = await _dbContext.MenuLists.Where(u => u.Menu_Id == id).FirstOrDefaultAsync();
            UpdateMenuCommandDto response = new UpdateMenuCommandDto();
            if(menuToUpdate != null)
            {
                menuToUpdate.Menu_Id = request.Menu_Id;
                menuToUpdate.MenuText = request.MenuText;
                menuToUpdate.MenuClass = request.MenuClass;
                menuToUpdate.MenuIcon = request.MenuIcon;
                menuToUpdate.MenuFlag = request.MenuFlag;
                menuToUpdate.MenuAction = request.MenuAction;
                menuToUpdate.MenuController = request.MenuController;
                menuToUpdate.MenuLink = request.MenuLink;
                List<MenuRoleMapping>  getmenurolemapping = await getMenuRolemapping(menuToUpdate.Menu_Id);
                _dbContext.MenuRoleMappings.RemoveRange(getmenurolemapping);
                for (int i = 0; i < request.RoleList.Count; i++)
                {
                    List<MenuRoleMapping> menurolelist = new List<MenuRoleMapping>()
                {
                    new MenuRoleMapping (){Menu_id=menuToUpdate.Menu_Id,Role_id=request.RoleList[i]}
                };
                    await AddmenuRole(menurolelist);
                }
                await _dbContext.SaveChangesAsync();
                response.Message = "Menu Details Update Successfully";
                response.Succeeded = true;
                response.Id = menuToUpdate.Menu_Id;
                return response;

            }
            else
            {
                response.Message = "Menu Not Exist";
                response.Succeeded = false;
                return response;
            }

        }
        public async Task<List<MenuRoleMapping>> getMenuRolemapping(int id)
        {
            List<MenuRoleMapping> menu = _dbContext.MenuRoleMappings.Where(x => x.Menu_id == id).ToList();
            return menu;
        }

        public async Task<GetMenuByIdDto> GetMenuById(int menu_Id)
        {
            var result = from A in _dbContext.MenuLists
                         join B in _dbContext.MenuRoleMappings on A.Menu_Id equals B.Menu_id
                         //join C in _dbContext.UserRole on B.Role_id equals C.Id
                         select new GetMenuByIdDto
                         {
                             Menu_id = A.Menu_Id,
                             MenuText = A.MenuText,
                             MenuClass = A.MenuClass,
                             MenuIcon = A.MenuIcon,
                             MenuFlag = A.MenuFlag,
                             MenuController = A.MenuController,
                             MenuAction = A.MenuAction,
                             MenuLink = A.MenuLink,
                             RoleId = B.Role_id
                         };

            var res = await result.Where(u => u.Menu_id == menu_Id).FirstOrDefaultAsync();
            return res;
            //List<MenuList> GetMenuById = await _dbContext.MenuLists.Include(x => x.RoleMapping).Where(u => u.Menu_Id == menu_Id && u.IsDeleted != true).ToListAsync();
            //return GetMenuById;
        }

        public async Task<IEnumerable<GetMenuListQueryVm>> GetAllMenuList()
        {
            //var menu = await _dbContext.MenuLists.Include(x => x.RoleMapping).ThenInclude(x => x.UserRole).Where(u => u.IsDeleted != true).ToListAsync();
            //return menu;

            var result = from A in _dbContext.MenuLists
                         join B in _dbContext.MenuRoleMappings on A.Menu_Id equals B.Menu_id
                         join C in _dbContext.UserRole on B.Role_id equals C.Id where A.IsDeleted !=true
                         select new GetMenuListQueryVm
                         {
                             Menu_Id = A.Menu_Id,
                             MenuText = A.MenuText,
                             MenuClass = A.MenuClass,
                             MenuIcon = A.MenuIcon,
                             MenuFlag = A.MenuFlag,
                             MenuController = A.MenuController,
                             MenuAction = A.MenuAction,
                             MenuLink = A.MenuLink,
                             RoleName = C.Role
                         };

            //var res = await result.Where(u=>u.i).FirstOrDefaultAsync();
            return result;
        }

        public async Task<RemoveMenuCommandDto> RemoveMenuAsync(int menu_Id)
        {
            var menu = await _dbContext.MenuLists.Where(u => u.Menu_Id == menu_Id).FirstOrDefaultAsync();

            RemoveMenuCommandDto response = new RemoveMenuCommandDto();


            if (menu != null)
            {
                menu.IsDeleted = true;
                //await DeleteAsync(user);
                await _dbContext.SaveChangesAsync();
                response.Menu_Id = menu_Id;
                response.Message = $"Menu of id:{menu_Id} has been removed successfully .";
                response.Succeeded = true;
                return response;
            }
            else
            {
                response.Menu_Id = menu_Id;
                response.Message = $"Menu of id:{menu_Id} does not exists .";
                response.Succeeded = false;
                return response;
            }
        }
    }
}
