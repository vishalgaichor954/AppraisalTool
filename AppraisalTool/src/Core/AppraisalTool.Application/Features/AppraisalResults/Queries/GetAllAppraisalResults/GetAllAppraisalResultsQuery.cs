using AppraisalTool.Application.Features.Categories.Queries.GetCategoriesList;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.AppraisalResults.Queries.GetAllAppraisalResults
{
    public class GetAllAppraisalResultsQuery : IRequest<Response<IEnumerable<AppraisalResult>>>
    {
    }
}
