using AppraisalTool.Application.Features.FinancialYears.Queries.GetAllFinancialYears;
using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.FinancialYears.Queries.GetFinancialYearsByUserJoining
{
    public class GetFinancialYearsByUserJoiningQuery : IRequest<Response<List<GetAllFinancialYearsVM>>>
    {
        public int UserId { get; set; }
    }
}
