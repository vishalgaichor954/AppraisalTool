﻿using AutoMapper;
using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Events.Queries.GetEventDetail;
using AppraisalTool.Application.Features.Events.Queries.GetEventsList;
using AppraisalTool.Application.Profiles;
using AppraisalTool.Application.Responses;
using AppraisalTool.Application.UnitTests.Mocks;
using AppraisalTool.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AppraisalTool.Application.UnitTests.Event.Queries
{
    public class GetEventListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEventRepository> _mockEventRepository;

        public GetEventListQueryHandlerTests()
        {
            _mockEventRepository = EventRepositoryMocks.GetEventRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }

       
      //  [Fact]
        public async Task Handle_GetEventList_FromEventsRepo()
        {
            var handler = new GetEventsListQueryHandler(_mapper, _mockEventRepository.Object);

            var result = await handler.Handle(new GetEventsListQuery(), CancellationToken.None);

            result.ShouldBeOfType<Response<IEnumerable<EventListVm>>>();
            result.Data.ShouldNotBeEmpty();
        }
    }
}
