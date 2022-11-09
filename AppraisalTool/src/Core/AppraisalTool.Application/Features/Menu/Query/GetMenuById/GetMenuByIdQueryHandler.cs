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

namespace AppraisalTool.Application.Features.Menu.Query.GetMenuById
{
    public class GetMenuByIdQueryHandler : IRequestHandler<GetMenuByIdQuery,Response<GetMenuByIdDto>>
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetMenuByIdQueryHandler> _logger;

        public GetMenuByIdQueryHandler(IMenuRepository menuRepository, IMapper mapper, ILogger<GetMenuByIdQueryHandler> logger)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
            _logger = logger;
        }
        
        public async Task<Response<GetMenuByIdDto>> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetMenuByIdQueryHandler Initiated");
            var menuresponse = await _menuRepository.GetMenuById(request.Menu_Id);
            //var mappedmenu = _mapper.Map<GetMenuByIdDto>(menuresponse);
            _logger.LogInformation("GetUserByIdQueryHandler completed");
            return new Response<GetMenuByIdDto>(menuresponse, "success");
            //return new Response<IEknkumerable<GetMenuByIdDto>>(menuresponse, "success");

        }
    }
}
