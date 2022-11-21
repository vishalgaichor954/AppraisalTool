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

namespace AppraisalTool.Application.Features.FinancialYears.Query.GetFinancialYearById
{
    public class GetFinancialYearByIdQueryHandler : IRequestHandler<GetFinancialYearByIdQuery, Response<GetFinancialYearByIdDto>>
    {
        private readonly IMapper _mapper;
        private readonly IFinacialYearRepository _finacialYearRepository;

        public GetFinancialYearByIdQueryHandler(IMapper mapper, IFinacialYearRepository finacialYearRepository)
        {
            _finacialYearRepository = finacialYearRepository;
            _mapper = mapper;
        }
        public async Task<Response<GetFinancialYearByIdDto>> Handle(GetFinancialYearByIdQuery request, CancellationToken cancellationToken)
        {
            //_logger.LogInformation("GetFinancialYearByIdQueryHandler Initiated");
            var financialYear = await _finacialYearRepository.GetFinancialYearById(request.Id);
            var FyResponse = _mapper.Map<GetFinancialYearByIdDto>(financialYear);
            return new Response<GetFinancialYearByIdDto>(FyResponse, "Success");

        }
    }
}
