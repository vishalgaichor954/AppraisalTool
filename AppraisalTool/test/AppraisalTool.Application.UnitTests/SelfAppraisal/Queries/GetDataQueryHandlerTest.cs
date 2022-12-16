using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
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

namespace AppraisalTool.Application.UnitTests.SelfAppraisal.Queries
{
    public class GetDataQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ISelfAppraisalRepository> _mockselfAppraisalRepository;

        public GetDataQueryHandlerTest()
        {
            _mockselfAppraisalRepository = SelfAppraisalRepositoryMocks.GetSelfAppraisalRepositoryMocks();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Get_Data_Query_Test()
        {
            var handler = new GetDataQueryHandler(_mapper,_mockselfAppraisalRepository.Object);

            var result = await handler.Handle(new GetDataQuery() { UserId =1, FyId =2}, CancellationToken.None);

            result.ShouldBeOfType<Response<IEnumerable<GetDataVM>>>();
            result.Data.ShouldBeOfType<List<GetDataVM>>();
            result.Data.ShouldNotBeEmpty();
        }
    }
}
