using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Users.Command.UpdateUserCommand;
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
    public class UpdateUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Mock<IRoleRepository> _roleRepository;
        private readonly Mock<IAuthenticationService> _authService;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<UpdateUserCommandHandler>> _logger;


        public UpdateUserCommandHandlerTests()
        {
            _userRepository = UserRepositoryMocks.UserRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _logger = new Mock<ILogger<UpdateUserCommandHandler>>();
            _authService = new Mock<IAuthenticationService>();
            _roleRepository = new Mock<IRoleRepository>();
        }

        [Fact]
        public async Task Update_User()
        {
            var handler = new UpdateUserCommandHandler(_roleRepository.Object,_authService.Object, _logger.Object, _mapper, _userRepository.Object);
            var result = await handler.Handle(new UpdateUserCommand()
            { FirstName = "test",
              LastName = "test",
              Email = "test", 
              Password = "test", 
              JoinDate = DateTime.Now,
              LastAppraisalDate = DateTime.Now, 
              RoleId = 1, BranchId = 1 
            }, CancellationToken.None);
            result.ShouldBeOfType<Response<UpdateUserCommandDto>>();
            result.Data.ShouldBeOfType<UpdateUserCommandDto>();
            result.Data.ShouldNotBeNull();
        }


    }
}
