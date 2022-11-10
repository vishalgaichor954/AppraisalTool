using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Menu.Command.CreateMenuCommand
{
    public class CreateMenuCommandHandlerl:IRequestHandler<CreateMenuCommand,Response<CreateMenuCommandDto>>
    {
        private readonly ILogger<CreateMenuCommandHandlerl> _logger;
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menurepository;
        private readonly IUserRoleRepository _userrepository;

        public CreateMenuCommandHandlerl(ILogger<CreateMenuCommandHandlerl> logger, IMapper mapper, IMenuRepository menu, IUserRoleRepository userrepository)
        {
            _logger = logger;
            _mapper = mapper;
            _menurepository = menu;
            _userrepository = userrepository;
        }

        public async Task<Response<CreateMenuCommandDto>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateMenuCommandHandlerl Initiated");
            var menu = _mapper.Map<MenuList>(request);
            var menuresponse = await _menurepository.CreateMenu(menu);
            if(menuresponse != null)
            {
                for(int i=0;i<request.RoleList.Count;i++)
                {
                    List<MenuRoleMapping> menurolelist = new List<MenuRoleMapping>()
                {
                    new MenuRoleMapping (){Menu_id=menuresponse.Id,Role_id=request.RoleList[i]}
                };
                    await _menurepository.AddmenuRole(menurolelist);
                }
               

            }
            if (menuresponse.Succeeded)
            {
                return new Response<CreateMenuCommandDto>(menuresponse,"Success");
            }
            else
            {
                var res = new Response<CreateMenuCommandDto>(menuresponse, "Failed");
                res.Succeeded = false;
                return res;
            }

        }
    }
}
