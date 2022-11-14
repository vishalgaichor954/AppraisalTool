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

namespace AppraisalTool.Application.Features.SelfAppraisal.Queries.GetYear
{
    public class GetYearQueryHandler : IRequestHandler<GetYearQuery, Response<IEnumerable<GetYearVm>>>
    {
    
        private readonly ILogger<GetYearQuery> _logger;
        private IMapper _mapper;
        private readonly ISelfAppraisalRepository _selfAppraisalRepository;
        public GetYearQueryHandler(ILogger<GetYearQuery> logger, IMapper mapper, ISelfAppraisalRepository selfAppraisalRepository)

        {
            _logger = logger;
            _mapper = mapper;
            _selfAppraisalRepository = selfAppraisalRepository;
        }

        public async Task<Response<IEnumerable<GetYearVm>>> Handle(GetYearQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetDataQuery Initiated");
            List<Appraisal> appraisals = await _selfAppraisalRepository.GetYear(request.UserId);

            var dataVM = appraisals.Select(x => new GetYearVm()
            {
                Id =x.FinancialYear.Id,
                StartYear = x.FinancialYear.StartYear,
                EndYear = x.FinancialYear.EndYear,
            });
            _logger.LogInformation("GetDataQuery Completed");

            var response = new Response<IEnumerable<GetYearVm>>(dataVM);

            return response;
        }
    }
}
