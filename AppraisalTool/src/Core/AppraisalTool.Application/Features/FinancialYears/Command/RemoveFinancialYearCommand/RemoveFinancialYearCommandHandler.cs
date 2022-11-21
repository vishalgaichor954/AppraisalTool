using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.FinancialYears.Command.RemoveFinancialYearCommand
{
    public class RemoveFinancialYearCommandHandler: IRequestHandler<RemoveFinancialYearCommand, Response<RemoveFinancialYearCommandDto>>
    {
        private readonly ILogger<RemoveFinancialYearCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IFinacialYearRepository _finacialYearRepository;

        public RemoveFinancialYearCommandHandler(ILogger<RemoveFinancialYearCommandHandler> logger, IMapper mapper, IFinacialYearRepository finacialYearRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _finacialYearRepository = finacialYearRepository;
        }
        public async Task<Response<RemoveFinancialYearCommandDto>> Handle(RemoveFinancialYearCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Intiated");
            var fydto = await _finacialYearRepository.RemoveFinancialYear(request.Id);
            _logger.LogInformation("Handle Completed");
            if (fydto.Succeeded)
            {
                return new Response<RemoveFinancialYearCommandDto>(fydto, "Success");
            }
            else
            {
                var res = new Response<RemoveFinancialYearCommandDto>(fydto, "Failed");
                res.Succeeded = false;
                return res;
            }
        }
    }
}
