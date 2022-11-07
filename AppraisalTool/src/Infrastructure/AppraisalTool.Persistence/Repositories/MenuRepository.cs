using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Menu.Command.CreateMenuCommand;
using AppraisalTool.Domain.Entities;
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

        public MenuRepository(ApplicationDbContext dbContext, ILogger<MenuList> logger) : base(dbContext, logger)
        {
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
    }
}
