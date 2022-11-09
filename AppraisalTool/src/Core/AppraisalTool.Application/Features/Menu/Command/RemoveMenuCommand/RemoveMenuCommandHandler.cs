using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Menu.Command.RemoveMenuCommand
{
    public class RemoveMenuCommandHandler : IRequestHandler<RemoveMenuCommand, Response<RemoveMenuCommandDto>>
    {
        private readonly ILogger<RemoveMenuCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menuRepository;

        public RemoveMenuCommandHandler(ILogger<RemoveMenuCommandHandler> logger, IMapper mapper, IMenuRepository menuRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _menuRepository = menuRepository;
        }

        public async Task<Response<RemoveMenuCommandDto>> Handle(RemoveMenuCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Intiated");
            var menuDto = await _menuRepository.RemoveMenuAsync(request.Menu_Id);
            _logger.LogInformation("Handle Completed");
            if (menuDto.Succeeded)
            {
                return new Response<RemoveMenuCommandDto>(menuDto, "Success");
            }
            else
            {
                var res = new Response<RemoveMenuCommandDto>(menuDto, "Failed");
                res.Succeeded = false;
                return res;
            }
        }
    }
}
