using AppraisalTool.Application.Response;
using MediatR;

namespace AppraisalTool.Application.Features.Categories.Commands.StoredProcedure
{
    public class StoredProcedureCommand: IRequest<Response<StoredProcedureDto>>
    {
        public string Name { get; set; }
    }
}
