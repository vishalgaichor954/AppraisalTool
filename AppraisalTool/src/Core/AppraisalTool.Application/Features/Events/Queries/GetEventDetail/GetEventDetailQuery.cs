using AppraisalTool.Application.Response;
using MediatR;
using System;

namespace AppraisalTool.Application.Features.Events.Queries.GetEventDetail
{
    public class GetEventDetailQuery: IRequest<Response<EventDetailVm>>
    {
        public string Id { get; set; }
    }
}
