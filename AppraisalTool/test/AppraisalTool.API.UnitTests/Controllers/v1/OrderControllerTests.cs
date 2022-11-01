using AppraisalTool.Api.Controllers.v1;
using AppraisalTool.API.UnitTests.Mocks;
using AppraisalTool.Application.Features.Orders.GetOrdersForMonth;
using AppraisalTool.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AppraisalTool.API.UnitTests.Controllers.v1
{
    public class OrderControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        public OrderControllerTests()
        {
            _mockMediator = MediatorMocks.GetMediator();
        }

        [Fact]
        public async Task Get_PagedOrders_ForMonth()
        {
            var controller = new OrderController(_mockMediator.Object);

            var result = await controller.GetPagedOrdersForMonth(DateTime.Now, 1, 2);

            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<PagedResponse<IEnumerable<OrdersForMonthDto>>>();
        }
    }
}
