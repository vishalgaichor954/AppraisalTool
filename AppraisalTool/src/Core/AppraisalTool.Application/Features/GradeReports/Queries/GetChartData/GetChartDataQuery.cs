using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.GradeReports.Queries.GetChartData
{
    public class GetChartDataQuery: IRequest<Response<GradeChartsData>>
    {
        public int UserId { get; set; }
        public int FinancialYearId { get; set; }
    }
}
