using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Events.Queries.GetEventsList;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.FinancialYears.Queries.GetAllFinancialYears
{
    public class GetAllFinancialYearsQueryHandler : IRequestHandler<GetAllFinancialYearsQuery, Response<List<GetAllFinancialYearsVM>>>
    {
        private readonly IFinancialYearRepository _financialYearRepository;
        private readonly IMapper _mapper;

        public GetAllFinancialYearsQueryHandler(IFinancialYearRepository financialRepo,IMapper mapper)
        {
            _financialYearRepository = financialRepo;
            _mapper = mapper;
        }

        public async Task<Response<List<GetAllFinancialYearsVM>>> Handle(GetAllFinancialYearsQuery request, CancellationToken cancellationToken)
        {
            List<FinancialYear> years = await _financialYearRepository.GetAllFinancialYears();
            List<GetAllFinancialYearsVM> yearList = _mapper.Map<List<GetAllFinancialYearsVM>>(years);
            return new Response<List<GetAllFinancialYearsVM>>(yearList);
        }
    }
}
