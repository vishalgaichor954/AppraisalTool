using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Users.Query.GetUserList;
using AppraisalTool.Application.Profiles;
using AppraisalTool.Application.Response;
using AppraisalTool.Application.UnitTests.Mocks;
using AutoMapper;
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
    public class GetUserListQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        private readonly IMapper _mapper;

        public GetUserListQueryHandlerTests()
        {
            _userRepository = UserRepositoryMocks.UserRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }
        [Fact]
        public async Task Get_All_UserList()
        {
            var handler = new GetUserListQueryHandler(_userRepository.Object, _mapper);
            var result = await handler.Handle(new GetUserListQuery(), CancellationToken.None);
            result.ShouldBeOfType<Response<IEnumerable<GetUserListQueryVm>>>();
            result.Data.ShouldBeOfType<List<GetUserListQueryVm>>();
            result.Data.ShouldNotBeEmpty();
        }

    }
}
