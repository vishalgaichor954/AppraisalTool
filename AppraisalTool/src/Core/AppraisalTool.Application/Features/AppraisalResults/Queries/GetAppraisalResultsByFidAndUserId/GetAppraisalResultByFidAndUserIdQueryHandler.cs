using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.AppraisalResults.Queries.GetAppraisalResultsByAppraisalId;
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

namespace AppraisalTool.Application.Features.AppraisalResults.Queries.GetAppraisalResultsByFidAndUserId
{
    public class GetAppraisalResultByFidAndUserIdQueryHandler : IRequestHandler<GetAppraisalResultsByFidAndUserIdQuery, Response<List<GetAppraisalsByUidAndFidDto>>>
    {
        private readonly IAppraisalResultRepository _appraisalResultRepository;
        private readonly ILogger<GetAppraisalResultByFidAndUserIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetAppraisalResultByFidAndUserIdQueryHandler(IAppraisalResultRepository appraisalResultRepository, ILogger<GetAppraisalResultByFidAndUserIdQueryHandler> logger,IMapper mapper)
        {
            _appraisalResultRepository = appraisalResultRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Response<List<GetAppraisalsByUidAndFidDto>>> Handle(GetAppraisalResultsByFidAndUserIdQuery request, CancellationToken cancellationToken)
        {
            List<AppraisalResult> appraisalResults = await _appraisalResultRepository.GetAprraisalResultData(request.FinancialYearid,request.UserId);
            if(appraisalResults == null)
            {
                return new Response<List<GetAppraisalsByUidAndFidDto>>(null, "success");
            }
            else
            {
                List<GetAppraisalsByUidAndFidDto> resultList = _mapper.Map<List<GetAppraisalsByUidAndFidDto>>(appraisalResults);
                return new Response<List<GetAppraisalsByUidAndFidDto>>(resultList, "success");
            }
        }
    }
}
