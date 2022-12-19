using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.ReporteeAppraisals.Queries.GetReporteeAppraisalsByRevAuthority;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Common;
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

namespace AppraisalTool.Application.UnitTests.ReporteeAppraisal.GetReporteeByRepAuthority
{
    public class GetReporteeAppraisalsByRepAuthorityQueryHandlerTest
    {
        private readonly Mock<ISelfAppraisalRepository> _selfAppraisalRepository;
        private readonly Mock<ILogger<GetReporteeAppraisalsByRepAuthorityQueryHandler>> _logger;

        public GetReporteeAppraisalsByRepAuthorityQueryHandlerTest()
        {
            _selfAppraisalRepository = new Mock<ISelfAppraisalRepository>();
            _logger = new Mock<ILogger<GetReporteeAppraisalsByRepAuthorityQueryHandler>>();

        }
        [Fact]
        public async Task Get_Reportee_Appraisal_ByRep()
        {
            var handler = new GetReporteeAppraisalsByRepAuthorityQueryHandler(_selfAppraisalRepository.Object, _logger.Object);
            var result = await handler.Handle(new GetReporteeAppraisalsByRepAuthorityQuery() { Id=5 }, CancellationToken.None);

            result.ShouldBeOfType<Response<List<ReporteeAppraisalListVm>>>();
            result.Data.ShouldBeOfType<List<ReporteeAppraisalListVm>>();
            result.Data.ShouldNotBeEmpty();
        }
    }
}
