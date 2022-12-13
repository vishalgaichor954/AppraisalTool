using AppraisalTool.Api.Controllers.v1;
using AppraisalTool.API.UnitTests.Mocks;
using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
using AppraisalTool.Application.Response;
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
    public class AppraisalHomePageControllerTest
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly Mock<ILogger<AppraisalHomeController>> _mockLogger;
        private readonly Mock<IUserRepository> _userRepository;

        public AppraisalHomePageControllerTest()
        {
            _mockLogger = new Mock<ILogger<AppraisalHomeController>>();
            _mockMediator = MediatorMocks.GetMediator();
            _userRepository= new Mock<IUserRepository>();
        }
        [Fact]
        public async Task Get_Data_ByYear()
        {
            var controller = new AppraisalHomeController(_mockMediator.Object,_mockLogger.Object,_userRepository.Object);
            var result = await controller.GetDataByYear(1, 2);
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<IEnumerable<GetDataVM>>>();

            
        }

    }
}
