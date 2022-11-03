using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Metrics.Queries.GetMetricsByKraSubtype
{
    public class GetMetricsByKraSubtypeQuery: IRequest<Response<IEnumerable<ListOfMetrics>>>
    {
        public int Id { get; set; }
    }
}
