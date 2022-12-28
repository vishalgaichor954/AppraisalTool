using AppraisalTool.Api.Controllers.v1;
using AppraisalTool.API.UnitTests.Mocks;
using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Users.Command.CreateUserCommand;
using AppraisalTool.Application.Features.Users.Command.RemoveUserCommand;
using AppraisalTool.Application.Features.Users.Command.UpdateUserCommand;
using AppraisalTool.Application.Features.Users.Query.GetUserList;
using AppraisalTool.Application.Response;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
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
    public class UserControllerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<UserController>> _logger;
        private readonly Mock<IBranchRepository> _branchRepository;
        private readonly Mock<IDataProtector> _protector;



        public UserControllerTest()
        {
            _branchRepository = new Mock<IBranchRepository>();
            _mediator = MediatorMocks.GetMediator();
            _logger = new Mock<ILogger<UserController>>();
            _protector = new Mock<IDataProtector>();
        }
        [Fact]
        public async Task Get_All_User_List()
        {
            var controller = new UserController(_mediator.Object, _logger.Object, _branchRepository.Object, _protector.Object);
            var result = await controller.GetAllUserList();
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<IEnumerable<GetUserListQueryVm>>>();
        }

        [Fact]
        public async Task Get_User_By_Id()
        {
            var controller = new UserController(_mediator.Object, _logger.Object, _branchRepository.Object,_protector.Object);
            var result = await controller.GetUserById(1);
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<GetUserListQueryVm>>();
        }
        [Fact]
        public async Task Remove_Async()
        {
            var controller = new UserController(_mediator.Object, _logger.Object, _branchRepository.Object,_protector.Object);
            var result = await controller.RemoveAsync(65);
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<RemoveUserCommandDto>>();
        }
        [Fact]
        public async Task Update_User_Async()
        {
            var controller = new UserController(_mediator.Object, _logger.Object, _branchRepository.Object,_protector.Object);
            var testList = new UpdateUserCommand
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Email = "Test",
                Password = "Test",
                JoinDate = DateTime.Now,
                LastAppraisalDate = DateTime.Now,
                RoleId = 1,
                BranchId = 1,
                SecondaryJobProfileId=3,
                PrimaryJobProfileId=1,


            };
            var result = await controller.UpdateUserAsync(testList);
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<UpdateUserCommandDto>>();
        }
      
       
        [Fact]
        public async Task Register_Async()
        {
            var controller = new UserController(_mediator.Object, _logger.Object, _branchRepository.Object,_protector.Object);
            var testList = new CreateUserCommand
            {

                FirstName = "Test",
                LastName = "Test",
                Email = "Test",
                Password = "Test",
                JoinDate = DateTime.Now,
                LastAppraisalDate = DateTime.Now,
                RoleId = 1,
                BranchId = 1,
                SecondaryRole = 3,
                PrimaryRole = 1,
                RepaId = 1,
                RevaId = 1,
                AddedBy=1,


            };
            var result = await controller.RegisterAsync(testList);
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
            okObjectResult.Value.ShouldNotBeNull();
            okObjectResult.Value.ShouldBeOfType<Response<CreateUserDto>>();
        }

    }

}
