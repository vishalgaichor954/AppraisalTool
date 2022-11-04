using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Events.Queries.GetEventsList;
using AppraisalTool.Application.Features.Users.Command.CreateRoleCommand;
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

namespace AppraisalTool.Application.Features.AppraisalResults.Commands.AddAppraisalResult
{
    public class AddAppraisalResultCommandHandler : IRequestHandler<AddAppraisalResultCommand, Response<string>>
    {
        private readonly IAppraisalResultRepository _appraisalResultRepository;
        private readonly ILogger<AddAppraisalResultCommandHandler> _logger;
        private readonly IMapper _mapper;

        public AddAppraisalResultCommandHandler(IAppraisalResultRepository appraisalResultRepository, ILogger<AddAppraisalResultCommandHandler> logger,IMapper mapper)
        {
            _appraisalResultRepository = appraisalResultRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddAppraisalResultCommand request, CancellationToken cancellationToken)
        {
            List<AppraisalResult> resultList = _mapper.Map<List<AppraisalResult>>(request.DataList);
            var response = await _appraisalResultRepository.AddAprraisalResultData(resultList);
            return new Response<string>() { Data = null, Message = "Added Successfully", Succeeded = true, Errors = null };
        }
    }
}
