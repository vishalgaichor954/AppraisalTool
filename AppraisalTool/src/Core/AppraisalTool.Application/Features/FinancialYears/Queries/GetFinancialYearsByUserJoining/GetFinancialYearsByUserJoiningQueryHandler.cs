using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.FinancialYears.Queries.GetAllFinancialYears;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.FinancialYears.Queries.GetFinancialYearsByUserJoining
{
    public class GetFinancialYearsByUserJoiningQueryHandler : IRequestHandler<GetFinancialYearsByUserJoiningQuery, Response<List<GetAllFinancialYearsVM>>>
    {
        private readonly IFinancialYearRepository _financialYearRepository;
        private readonly IMapper _mapper;

        public GetFinancialYearsByUserJoiningQueryHandler(IFinancialYearRepository financialYearRepository, IMapper mapper)
        {
            _financialYearRepository = financialYearRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<GetAllFinancialYearsVM>>> Handle(GetFinancialYearsByUserJoiningQuery request, CancellationToken cancellationToken)
        {
            List<FinancialYear> years = await _financialYearRepository.GetFinancialYearsByUserJoining(request.UserId);
            List<GetAllFinancialYearsVM> yearList = _mapper.Map<List<GetAllFinancialYearsVM>>(years);
            return new Response<List<GetAllFinancialYearsVM>>(yearList);
        }
    }
}
