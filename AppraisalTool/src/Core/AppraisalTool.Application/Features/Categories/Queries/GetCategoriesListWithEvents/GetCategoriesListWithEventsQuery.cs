using AppraisalTool.Application.Response;
using MediatR;
using System.Collections.Generic;

namespace AppraisalTool.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQuery: IRequest<Response<IEnumerable<CategoryEventListVm>>>
    {
        public bool IncludeHistory { get; set; }
    }
}
