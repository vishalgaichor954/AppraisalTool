
using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Events.Queries.GetEventsList;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Metrics.Queries.GetAllMetricsList
{
    public class GetAllMetricsListQueryHandler : IRequestHandler<GetAllMetricsListQuery, Response<IEnumerable<ListOfMetrics>>>
    {
        private readonly IMetricRepository _metricRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public GetAllMetricsListQueryHandler(IMapper mapper, IMetricRepository metricRepository, ILogger<GetAllMetricsListQueryHandler> logger)
        {
            _mapper = mapper;
            _metricRepository = metricRepository;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<ListOfMetrics>>> Handle(GetAllMetricsListQuery request, CancellationToken cancellationToken)
        {
            var allMetrics = (await _metricRepository.ListAllAsync());
            var response = new Response<IEnumerable<ListOfMetrics>>(allMetrics);
            return response;
        }
    }
}
