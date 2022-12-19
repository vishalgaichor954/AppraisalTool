using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AppraisalTool.Application.Features.Appraisals.Query.GetAppraisalById
{
    public class GetAppraisalByIdQueryHandler : IRequestHandler<GetAppraisalByIdQuery, Response<Appraisal>>
    {
        private readonly IAppraisalResultRepository _appraisalResultRepository;
        private readonly ILogger<GetAppraisalByIdQueryHandler> _logger;
        public GetAppraisalByIdQueryHandler(IAppraisalResultRepository appraisalResultRepository, ILogger<GetAppraisalByIdQueryHandler> logger)
        {
            _appraisalResultRepository=appraisalResultRepository;
            _logger=logger; 
        }

        public async Task<Response<Appraisal>> Handle(GetAppraisalByIdQuery request, CancellationToken cancellationToken)
        {

            Appraisal appraisal = await _appraisalResultRepository.GetAppraisalById(request.Id);
            return new Response<Appraisal>(appraisal, "success");
        }
    }
}
