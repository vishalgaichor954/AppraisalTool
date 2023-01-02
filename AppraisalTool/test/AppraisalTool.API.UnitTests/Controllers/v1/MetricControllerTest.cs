using AppraisalTool.Api.Controllers.v1;
using AppraisalTool.API.UnitTests.Mocks;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppraisalTool.API.UnitTests.Controllers.v1
{
    public class MetricControllerTest
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly Mock<ILogger<MetricController>> _mockLogger;
        public MetricControllerTest()
        {
            _mockLogger = new Mock<ILogger<MetricController>>();
            _mockMediator = MediatorMocks.GetMediator();
           
        }
        [Fact]
        public async Task Get_All_ListOfMetric()
        {
            var controller = new MetricController(_mockMediator.Object, _mockLogger.Object);
            var result = await controller.GetAllListOfMetric();
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<IEnumerable<ListOfMetrics>>>();


        }
    }
}
