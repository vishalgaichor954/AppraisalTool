using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.FinancialYears.Query.GetFinancialYearList
{
    public class GetFinancialYearQueryHander:IRequestHandler<GetFinancialYearListQuery,Response<IEnumerable<FinancialYear>>>
    {
        private readonly IFinacialYearRepository _finacialYearRepository;
        private readonly IMapper _mapper;

        public GetFinancialYearQueryHander(IFinacialYearRepository finacialYearRepository,IMapper mapper)
        {

            _mapper = mapper;
            _finacialYearRepository=finacialYearRepository;
        }

        public async Task<Response<IEnumerable<FinancialYear>>> Handle(GetFinancialYearListQuery request, CancellationToken cancellationToken)
        {
            var Finanicialyear = await _finacialYearRepository.ListFinancialYear();
            return new Response<IEnumerable<FinancialYear>>(Finanicialyear);

        }
    }
}
