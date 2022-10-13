using AppraisalTool.Application.Responses;
using MediatR;

namespace AppraisalTool.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand: IRequest<Response<CreateCategoryDto>>
    {
        public string Name { get; set; }
    }
}
