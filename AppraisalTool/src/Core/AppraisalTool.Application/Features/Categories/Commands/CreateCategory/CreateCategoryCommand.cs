using AppraisalTool.Application.Response;
using MediatR;

namespace AppraisalTool.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand: IRequest<Response<CreateCategoryDto>>
    {
        public string Name { get; set; }
    }
}
