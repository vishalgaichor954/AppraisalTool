using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Users.Query.GetUserById;
using AppraisalTool.Application.Features.Users.Query.GetUserList;
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

namespace AppraisalTool.Application.UnitTests.Users.Queries
{
    public class GetUserByIdQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<GetUserByIdQueryHandler>> _logger;


        public GetUserByIdQueryHandlerTests()
        {
            _userRepository = UserRepositoryMocks.UserRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _logger=new Mock<ILogger<GetUserByIdQueryHandler>>() ;
        }
        [Fact]
        public async Task Get_User_By_Id()
        {
            var handler = new GetUserByIdQueryHandler(_userRepository.Object, _mapper, _logger.Object);
            var result = await handler.Handle(new GetUserByIdQuery() {Id=2}, CancellationToken.None);
            result.ShouldBeOfType<Response<GetUserListQueryVm>>();
            
            result.ShouldNotBeNull();
        }


    }
}
