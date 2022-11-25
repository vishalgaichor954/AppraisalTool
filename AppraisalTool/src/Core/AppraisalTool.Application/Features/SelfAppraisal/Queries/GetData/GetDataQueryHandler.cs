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
            IQueryable<GetDataVM> appraisals = await _selfAppraisalRepository.GetDataById(request.UserId,request.FyId);


            Console.WriteLine("tt");

            var dataVM = _mapper.Map<List<GetDataVM>>(appraisals);
            
         
            
           
           
            _logger.LogInformation("GetDataQuery Completed");

            var response = new Response<IEnumerable<GetDataVM>>(dataVM);

            return response;


        }
    }
}
