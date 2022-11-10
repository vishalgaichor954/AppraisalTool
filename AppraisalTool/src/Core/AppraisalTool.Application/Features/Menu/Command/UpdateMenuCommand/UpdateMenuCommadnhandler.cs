using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Menu.Command.UpdateMenuCommand
{
    public class UpdateMenuCommadnhandler : IRequestHandler<UpdateMenuCommand, Response<UpdateMenuCommandDto>>
    {
        private readonly ILogger<UpdateMenuCommadnhandler> _logger;
        private readonly IMenuRepository _menuRepository;

        public UpdateMenuCommadnhandler(ILogger<UpdateMenuCommadnhandler> logger, IMenuRepository menuRepository)
        {
            _logger = logger;
            _menuRepository = menuRepository;
        }
        public async Task<Response<UpdateMenuCommandDto>> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("UpdateMenuCommadnhandler Initaited");
            var menuDto = await _menuRepository.UpdateMenuAsync(request.Menu_Id, request);
            _logger.LogInformation("UpdateMenuCommadnhandler Completed");
            if (menuDto.Succeeded)
            {
                return new Response<UpdateMenuCommandDto>(menuDto, "Success");
            }
            else
            {
                var res = new Response<UpdateMenuCommandDto>(menuDto, "Failed");
                res.Succeeded = false;
                return res;

            }
        }
    }
}
