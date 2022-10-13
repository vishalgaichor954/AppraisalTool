using AppraisalTool.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace AppraisalTool.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery: IRequest<Response<IEnumerable<EventListVm>>>
    {

    }
}
