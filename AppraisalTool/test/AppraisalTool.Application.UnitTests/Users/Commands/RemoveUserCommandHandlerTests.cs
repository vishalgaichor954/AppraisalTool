using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Users.Command.RemoveUserCommand;
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
    public class RemoveUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepository;

        private readonly IMapper _mapper;
        private readonly Mock<ILogger<RemoveUserCommandHandler>> _logger;


        public RemoveUserCommandHandlerTests()
        {
            _userRepository = UserRepositoryMocks.UserRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _logger = new Mock<ILogger<RemoveUserCommandHandler>>();
        }
        [Fact]
        public async Task Remove_User()
        {
            var handler = new RemoveUserCommandHandler(_logger.Object, _mapper, _userRepository.Object);
            var result = await handler.Handle(new RemoveUserCommand() { Id=1}, CancellationToken.None);
            result.ShouldBeOfType<Response<RemoveUserCommandDto>>();
            result.Data.ShouldBeOfType<RemoveUserCommandDto>();
            result.Data.ShouldNotBeNull();
        }


    }
}
