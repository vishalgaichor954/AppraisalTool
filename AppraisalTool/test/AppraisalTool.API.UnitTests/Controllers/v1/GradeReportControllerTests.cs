using AppraisalTool.Api.Controllers.v1;
using AppraisalTool.API.UnitTests.Mocks;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Common;
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
    public class GradeReportControllerTests
    {
        private readonly Mock<ILogger<GradeReportController>> _mockLogger;
        private readonly Mock<IMediator> _mockMediator;

        public GradeReportControllerTests()
        {
            _mockLogger = new Mock<ILogger<GradeReportController>>();
            _mockMediator = MediatorMocks.GetMediator();

        }

        [Fact]

        public async Task GradeReport()
        {
            var controller = new GradeReportController(_mockMediator.Object, _mockLogger.Object);
            var result = await controller.GetChartsData(4,1);
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);

            okObjectResult.Value.ShouldBeOfType<Response<GradeChartsData>>();

        }



    }
}
