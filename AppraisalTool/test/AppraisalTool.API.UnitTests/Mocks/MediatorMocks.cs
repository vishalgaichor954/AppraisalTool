using AppraisalTool.Application.Features.AppraisalResults.Commands.AddAppraisalResult;
using AppraisalTool.Application.Features.AppraisalResults.Commands.UpdateAppraisalResult;
using AppraisalTool.Application.Features.AppraisalResults.Queries.GetAppraisalResultsByAppraisalId;
using AppraisalTool.Application.Features.AppraisalResults.Queries.GetAppraisalResultsByFidAndUserId;
using AppraisalTool.Application.Features.Appraisals.Query.GetAppraisalById;
using AppraisalTool.Application.Features.Categories.Commands.CreateCategory;
using AppraisalTool.Application.Features.Categories.Commands.StoredProcedure;
using AppraisalTool.Application.Features.Categories.Queries.GetCategoriesList;
using AppraisalTool.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using AppraisalTool.Application.Features.Events.Commands.CreateEvent;
using AppraisalTool.Application.Features.Events.Commands.DeleteEvent;
using AppraisalTool.Application.Features.Events.Commands.Transaction;
using AppraisalTool.Application.Features.Events.Commands.UpdateEvent;
using AppraisalTool.Application.Features.Events.Queries.GetEventDetail;
using AppraisalTool.Application.Features.Events.Queries.GetEventsExport;
using AppraisalTool.Application.Features.Events.Queries.GetEventsList;
using AppraisalTool.Application.Features.GradeReports.Queries.GetChartData;
using AppraisalTool.Application.Features.Metrics.Queries.GetAllMetricsList;
using AppraisalTool.Application.Features.Orders.GetOrdersForMonth;
using AppraisalTool.Application.Features.ReporteeAppraisals.Queries.GetReporteeAppraisalsByRevAuthority;
using AppraisalTool.Application.Features.ReviewAppraisals.Queries.GetReviewAppraisalsByRevAuthority;
using AppraisalTool.Application.Features.SelfAppraisal.Command.AddAppraisal;
using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Common;
using AppraisalTool.Domain.Entities;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AppraisalTool.API.UnitTests.Mocks
{
    public class MediatorMocks
    {
        public static Mock<IMediator> GetMediator()
        {
            var mockMediator = new Mock<IMediator>();

            mockMediator.Setup(m => m.Send(It.IsAny<GetCategoriesListQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<IEnumerable<CategoryListVm>>());
            mockMediator.Setup(m => m.Send(It.IsAny<GetCategoriesListWithEventsQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<IEnumerable<CategoryEventListVm>>());
            mockMediator.Setup(m => m.Send(It.IsAny<CreateCategoryCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<CreateCategoryDto>());
            mockMediator.Setup(m => m.Send(It.IsAny<StoredProcedureCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<StoredProcedureDto>());

            mockMediator.Setup(m => m.Send(It.IsAny<GetEventsListQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<IEnumerable<EventListVm>>());
            mockMediator.Setup(m => m.Send(It.IsAny<GetEventDetailQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<EventDetailVm>());
            mockMediator.Setup(m => m.Send(It.IsAny<GetEventsExportQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new EventExportFileVm() { Data = Encoding.UTF8.GetBytes(new string(' ', 100)), ContentType = "text/csv", EventExportFileName = "Filename"  });
            mockMediator.Setup(m => m.Send(It.IsAny<CreateEventCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<Guid>());
            mockMediator.Setup(m => m.Send(It.IsAny<UpdateEventCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<Guid>());
            mockMediator.Setup(m => m.Send(It.IsAny<DeleteEventCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Unit());
            mockMediator.Setup(m => m.Send(It.IsAny<TransactionCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<Guid>());

            mockMediator.Setup(m => m.Send(It.IsAny<GetOrdersForMonthQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new PagedResponse<IEnumerable<OrdersForMonthDto>>(null, 10, 1, 2));

            //apprisalhome page 
            mockMediator.Setup(m => m.Send(It.IsAny<GetDataQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<IEnumerable<GetDataVM>>());
            mockMediator.Setup(m => m.Send(It.IsAny<GetAppraisalResultsByFidAndUserIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<List<GetAppraisalsByUidAndFidDto>>());
            mockMediator.Setup(m => m.Send(It.IsAny<GetAllMetricsListQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<IEnumerable<ListOfMetrics>>());
            mockMediator.Setup(m => m.Send(It.IsAny<AddAppraisalCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<Appraisal>());

            mockMediator.Setup(m => m.Send(It.IsAny<AddAppraisalResultCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<string>());
            mockMediator.Setup(m => m.Send(It.IsAny<UpdateAppraisalResultCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<string>());

            mockMediator.Setup(m => m.Send(It.IsAny<GetReporteeAppraisalsByRepAuthorityQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<List<ReporteeAppraisalListVm>>());
            
            mockMediator.Setup(m => m.Send(It.IsAny<GetAppraisalByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<Appraisal>());
            
             mockMediator.Setup(m => m.Send(It.IsAny<GetApprasisalResultsByAppraisalIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<List<AppraisalResult>>());

            mockMediator.Setup(m => m.Send(It.IsAny<GetChartDataQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<GradeChartsData>());
            mockMediator.Setup(m => m.Send(It.IsAny<GetReviewAppraisalsByRevAuthorityQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new Response<List<ReviewAppraisalListVm>>());

            
            return mockMediator;
        }
    }
}
