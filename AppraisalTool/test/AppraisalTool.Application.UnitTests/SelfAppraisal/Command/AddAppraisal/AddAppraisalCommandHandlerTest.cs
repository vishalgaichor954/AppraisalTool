using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.SelfAppraisal.Command.AddAppraisal;
using AppraisalTool.Application.Profiles;
using AppraisalTool.Application.Response;
using AppraisalTool.Application.UnitTests.Mocks;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Configuration;
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

namespace AppraisalTool.Application.UnitTests.SelfAppraisal.Command.AddAppraisal
{
    public class AddAppraisalCommandHandlerTest
    {
        private readonly Mock<ISelfAppraisalRepository> _mocksselfAppraisalRepository;
        private readonly Mock<ILogger<AddAppraisalCommandHandler>> _mockslogger;
        private readonly IMapper _mapper;

    public AddAppraisalCommandHandlerTest()
        {
            _mocksselfAppraisalRepository = SelfAppraisalRepositoryMocks.GetSelfAppraisalRepositoryMocks();
            _mockslogger = new Mock<ILogger<AddAppraisalCommandHandler>>();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();

        }
        [Fact]
        public async Task Add_Appraisal_Command_test()
        {
            var handler =new  AddAppraisalCommandHandler(_mocksselfAppraisalRepository.Object, _mockslogger.Object, _mapper);
            var appraisal = new AddAppraisalVM
            {
                Id = 1,
                FinancialYearId = 2,
                UserId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                StatusId = 4,
                KraId = 1,
                ReviewedOn = DateTime.Now,
                ApprovedOn = DateTime.Now
            };

            var result = await handler.Handle(new AddAppraisalCommand(appraisal), CancellationToken.None);
            result.ShouldBeOfType<Response<Appraisal>>();
           
           

        }
    }
}
