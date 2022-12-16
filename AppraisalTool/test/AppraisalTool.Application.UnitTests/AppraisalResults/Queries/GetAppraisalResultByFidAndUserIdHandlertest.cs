using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.AppraisalResults.Queries.GetAppraisalResultsByFidAndUserId;
using AppraisalTool.Application.Profiles;
using AppraisalTool.Application.Response;
using AppraisalTool.Application.UnitTests.Mocks;
using AppraisalTool.Domain.Entities;
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

namespace AppraisalTool.Application.UnitTests.AppraisalResults.Queries
{
    public class GetAppraisalResultByFidAndUserIdHandlertest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAppraisalResultRepository> _mockAppraisalRepository;
        private readonly Mock<ILogger<GetAppraisalResultByFidAndUserIdQueryHandler>> _mockLogger;
        public GetAppraisalResultByFidAndUserIdHandlertest()
        {
            _mockAppraisalRepository = AppraiasalResultRepositoryMocks.GetAppraisalResultByFidUid();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _mockLogger = new Mock<ILogger<GetAppraisalResultByFidAndUserIdQueryHandler>>();
        }
        [Fact]
        public async Task Get_Appraisal_ByFidAndUid_Test()
        {
            var handler = new GetAppraisalResultByFidAndUserIdQueryHandler(_mockAppraisalRepository.Object,_mockLogger.Object,_mapper);

            var result = await handler.Handle(new GetAppraisalResultsByFidAndUserIdQuery() { FinancialYearid = 2, UserId = 1 }, CancellationToken.None);

            result.ShouldBeOfType<Response<List<GetAppraisalsByUidAndFidDto>>>();
            result.Data.ShouldBeOfType<List<GetAppraisalsByUidAndFidDto>>();
            result.Data.ShouldNotBeEmpty();
        }

    }
}
