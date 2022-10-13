using AppraisalTool.Application.Responses;
using MediatR;

namespace AppraisalTool.Application.Features.Categories.Commands.StoredProcedure
{
    public class StoredProcedureCommand: IRequest<Response<StoredProcedureDto>>
    {
        public string Name { get; set; }
    }
}
