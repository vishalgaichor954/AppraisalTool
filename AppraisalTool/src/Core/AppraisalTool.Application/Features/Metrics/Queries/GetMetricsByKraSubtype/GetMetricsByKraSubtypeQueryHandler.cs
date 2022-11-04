using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Metrics.Queries.GetAllMetricsList;
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

namespace AppraisalTool.Application.Features.Metrics.Queries.GetMetricsByKraSubtype
{
    public class GetMetricsByKraSubtypeQueryHandler : IRequestHandler<GetMetricsByKraSubtypeQuery, Response<IEnumerable<ListOfMetrics>>>
    {
        private readonly IMetricRepository _metricRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetMetricsByKraSubtypeQueryHandler(IMetricRepository metricRepository, IMapper mapper, ILogger<GetMetricsByKraSubtypeQueryHandler> logger)
        {
            _metricRepository = metricRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<ListOfMetrics>>> Handle(GetMetricsByKraSubtypeQuery request, CancellationToken cancellationToken)
        {
            var allMetrics = await _metricRepository.GetListOfMetricsByKraSubType(request.Id);
            var response = new Response<IEnumerable<ListOfMetrics>>(allMetrics);
            return response;
        }
    }
}
