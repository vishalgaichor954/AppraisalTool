using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Responses;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData
{
    public class GetDataQueryHandler : IRequestHandler<GetDataQuery, Response<IEnumerable<GetDataVM>>>
    {
        private readonly ILogger<GetDataQuery> _logger;
        private IMapper _mapper;
        private readonly ISelfAppraisalRepository _selfAppraisalRepository;
        public GetDataQueryHandler(ILogger<GetDataQuery> logger, IMapper mapper, ISelfAppraisalRepository selfAppraisalRepository)

        {
            _logger = logger;
            _mapper = mapper;
            _selfAppraisalRepository = selfAppraisalRepository;
        }

        public async Task<Response<IEnumerable<GetDataVM>>> Handle(GetDataQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetDataQuery Initiated");
            List<Appraisal> appraisals = await _selfAppraisalRepository.GetDataById(request.UserId,request.FinancialYearId);
           

            Console.WriteLine(appraisals[0].FinancialYear.StartYear);

            var dataVM = _mapper.Map<List<GetDataVM>>(appraisals);
            Console.WriteLine(appraisals[0].FinancialYear.EndYear);
            _logger.LogError(dataVM.ToString());
            
           
           
            _logger.LogInformation("GetDataQuery Completed");

            var response = new Response<IEnumerable<GetDataVM>>(dataVM);

            return response;


        }
    }
}
