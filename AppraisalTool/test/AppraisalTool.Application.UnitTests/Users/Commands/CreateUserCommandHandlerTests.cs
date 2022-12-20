using AppraisalTool.Application.Contracts.Infrastructure;
using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Users.Command.CreateUserCommand;
using AppraisalTool.Application.Profiles;
using AppraisalTool.Application.Response;
using AppraisalTool.Application.UnitTests.Mocks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AppraisalTool.Application.UnitTests.Users.Commands
{
    public class CreateUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IRoleRepository> _roleRepository;
        private readonly Mock<IEmailService> _emailservice;
        private readonly Mock<IAuthenticationService> _authService;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<CreateUserCommandHandler>> _logger;


        public CreateUserCommandHandlerTests()
        {

            _userRepository = UserRepositoryMocks.UserRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _logger = new Mock<ILogger<CreateUserCommandHandler>>();
            _emailservice = EmailServiceMocks.Emailservice();
            _authService = new Mock<IAuthenticationService>();
            _roleRepository = RoleRepositoryMocks.GetAllRole();
        }
        [Fact]
        public async Task Create_User()
        {
            var handler = new CreateUserCommandHandler(_authService.Object,_userRepository.Object, _logger.Object, _mapper,_emailservice.Object,_roleRepository.Object);
            var command = new CreateUserCommand
            {
                
                FirstName = "test",
                LastName = "test",
                Email = "test",
                Password = "test",
                JoinDate = DateTime.Now,
                LastAppraisalDate = DateTime.Now,
                RoleId = 1,
                BranchId = 1,
                PrimaryRole = 1,
                SecondaryRole = 1,
                RevaId = 1,
                RepaId = 1,
                AddedBy = 1
            };
            var result = await handler.Handle(command, CancellationToken.None);
            //{FirstName = "test",LastName = "test",Email = "test",Password = "test",JoinDate = DateTime.Now,LastAppraisalDate = DateTime.Now,RoleId = 1,BranchId = 1,PrimaryRole=1,SecondaryRole=1,RevaId=1,RepaId=1,AddedBy=1 }, CancellationToken.None);

            result.ShouldBeOfType<Response<CreateUserDto>>();
            result.Data.ShouldBeOfType<CreateUserDto>();
            result.Data.ShouldNotBeNull();
        }


    }
}
