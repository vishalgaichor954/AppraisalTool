using AppraisalTool.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace AppraisalTool.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<Response<IEnumerable<CategoryListVm>>>
    {
    }
}
