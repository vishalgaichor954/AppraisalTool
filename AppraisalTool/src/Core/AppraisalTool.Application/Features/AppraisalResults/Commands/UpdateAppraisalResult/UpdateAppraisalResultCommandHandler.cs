using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.AppraisalResults.Commands.AddAppraisalResult;
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

namespace AppraisalTool.Application.Features.AppraisalResults.Commands.UpdateAppraisalResult
{
    public class UpdateAppraisalResultCommandHandler : IRequestHandler<UpdateAppraisalResultCommand, Response<string>>
    {
        private readonly IAppraisalResultRepository _appraisalResultRepository;
        private readonly ISelfAppraisalRepository _selfAppraisalRepository;
        private readonly ILogger<UpdateAppraisalResultCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateAppraisalResultCommandHandler(IAppraisalResultRepository appraisalResultRepository, ILogger<UpdateAppraisalResultCommandHandler> logger, IMapper mapper,ISelfAppraisalRepository selfRepo)
        {
            _appraisalResultRepository = appraisalResultRepository;
            _logger = logger;
            _mapper = mapper;
            _selfAppraisalRepository = selfRepo;
        }

        public async Task<Response<string>> Handle(UpdateAppraisalResultCommand request, CancellationToken cancellationToken)
        {
            List<AppraisalResult> resultList = _mapper.Map<List<AppraisalResult>>(request.DataList);
            var response = await _appraisalResultRepository.UpdateAprraisalResultData(resultList);
            if (response == true)
            {
                await _selfAppraisalRepository.UpdateAppraisalStatus(request.AppraisalId, request.StatusId);
                return new Response<string>() { Data = response.ToString(), Message = "Updated Successfully", Succeeded = true, Errors = null };
            }
            return new Response<string>() { Data = response.ToString(), Message = "Failed to update", Succeeded = false, Errors = new List<string> { "Failed To Update" } };
        }
    }
}
