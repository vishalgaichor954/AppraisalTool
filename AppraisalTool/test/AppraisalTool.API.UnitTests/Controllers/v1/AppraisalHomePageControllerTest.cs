using AppraisalTool.Api.Controllers.v1;
using AppraisalTool.API.UnitTests.Mocks;
using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.AppraisalResults.Commands.AddAppraisalResult;
using AppraisalTool.Application.Features.AppraisalResults.Commands.UpdateAppraisalResult;
using AppraisalTool.Application.Features.AppraisalResults.Queries.GetAppraisalResultsByFidAndUserId;
using AppraisalTool.Application.Features.SelfAppraisal.Command.AddAppraisal;
using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Common;
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
        #region Self Appraisal Process
        [Fact]
        public async Task Get_Data_ByYear()
        {
            var controller = new AppraisalHomeController(_mockMediator.Object,_mockLogger.Object,_userRepository.Object);
            var result = await controller.GetDataByYear(1, 5);
            
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.ShouldNotBeNull();
            okObjectResult.ShouldBeOfType<Response<IEnumerable<GetDataVM>>>();

            
        }
        [Fact]
        public async Task Get_Appraisal_Results_ByFidAndUserId()
        {
            var controller = new AppraisalHomeController(_mockMediator.Object, _mockLogger.Object, _userRepository.Object);
            var result = await controller.GetAppraisalResultsByFidAndUserId(2,1);
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<List<GetAppraisalsByUidAndFidDto>>>();
        }
        [Fact]
        public async Task Get_Appraisal_ByFidAndUserId()
        {
            var controller = new AppraisalHomeController(_mockMediator.Object, _mockLogger.Object, _userRepository.Object);
            var result = await controller.GetAppraisalByFidAndUserId(2, 1);
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            result.ShouldNotBeNull(); 
            //okObjectResult.Value.ShouldNotBeNull();
            
        }
        [Fact]
        public async Task Add_Appraisal()
        {
            var controller = new AppraisalHomeController(_mockMediator.Object, _mockLogger.Object, _userRepository.Object);
            var result = await controller.AddAppraisal(new AddAppraisalVM());
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<Appraisal>>();
        }
        [Fact]
        public async Task Add_AppraisalResult()
        {
            var controller = new AppraisalHomeController(_mockMediator.Object, _mockLogger.Object, _userRepository.Object);
            var appraisalResultDtoList = new List<AddAppraisalResultDto>
            {
                new AddAppraisalResultDto
                {
                    ID=1,
                    UserId=1,
                    KraListId=1,
                    AppraisalId=2,
                    MetricId=1,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=1,
                    SelfScore=4,
                    SelfComment="test@rishi",
                    SelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="Test",
                    RevaSelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=5,
                    RepaSelfComment="test",
                    RepaSelfCreatatedDate=DateTime.Now
                }
            };
            var result = await controller.AddAppraisalResults(appraisalResultDtoList);
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<string>>();
        }
        [Fact]
        public async Task Update_AppraisalResults()
        {
            var controller = new AppraisalHomeController(_mockMediator.Object, _mockLogger.Object, _userRepository.Object);
            var UpdateAppraisalResultDtoList = new List<UpdateAppraisalResultDto>
            {
                new UpdateAppraisalResultDto
                {
                    ID=1,
                    UserId=1,
                    KraListId=1,
                    AppraisalId=2,
                    MetricId=1,
                    MetricDescription="Ability to handle autonomy",
                    MetricWeightage=1,
                    SelfScore=4,
                    SelfComment="test@rishi",
                    SelfCreatatedDate=DateTime.Now,
                    RevaSelfScore=4,
                    RevaSelfComment="Test",
                    RevaSelfCreatatedDate=DateTime.Now,
                    RepaSelfScore=5,
                    RepaSelfComment="test",
                    RepaSelfCreatatedDate=DateTime.Now
                }
            };
            var result = await controller.UpdateAppraisalResults(UpdateAppraisalResultDtoList, 1);
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<string>>();
        }
        [Fact]
        public async Task Request_ToEdit()
        {
            var controller = new AppraisalHomeController(_mockMediator.Object, _mockLogger.Object, _userRepository.Object);
            var result = await controller.RequestToEdit(7, 1);
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            result.ShouldNotBeNull();
        }
        #endregion

        [Fact]
        #region Reportee Appraisal Process
        public async Task Get_Reportee_Appraisal_ByRepAuthority()
        {
            var controller = new AppraisalHomeController(_mockMediator.Object, _mockLogger.Object, _userRepository.Object);
            var result = await controller.GetReporteeAppraisalByRepAuthority(5);
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<List<ReporteeAppraisalListVm>>>();
            
        }

        #endregion

    }
}
