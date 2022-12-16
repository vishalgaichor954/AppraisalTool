using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Metrics.Queries.GetAllMetricsList;
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

namespace AppraisalTool.Application.UnitTests.Metrics.Queries
{
    public class GetAllMetricsListQueryHandlerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMetricRepository> _mocksMetricRepository;
        private readonly Mock<ILogger<GetAllMetricsListQueryHandler>> _logger;
        public GetAllMetricsListQueryHandlerTest()
        {
            _mocksMetricRepository=MetricRepositoryMocks.GetAllListOfMetircs();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
           _logger=new Mock<ILogger<GetAllMetricsListQueryHandler>>();
        }
        [Fact]
        public async Task Get_All_ListOfMetric()
        {
            var handler = new GetAllMetricsListQueryHandler(_mapper,_mocksMetricRepository.Object,_logger.Object);
            var result = await handler.Handle(new GetAllMetricsListQuery(), CancellationToken.None);

            result.ShouldBeOfType<Response<IEnumerable<ListOfMetrics>>>();
            result.Data.ShouldNotBeEmpty();
            
        }
    }
}
