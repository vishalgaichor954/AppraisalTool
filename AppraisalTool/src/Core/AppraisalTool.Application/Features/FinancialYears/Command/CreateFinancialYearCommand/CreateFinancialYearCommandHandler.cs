using AppraisalTool.Application.Contracts.Persistence;
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

namespace AppraisalTool.Application.Features.FinancialYears.Command.CreateFinancialYearCommand
{
    public class CreateFinancialYearCommandHandler : IRequestHandler<CreateFinancialYearCommand, Response<CreateFinancialYearDto>>
    {
        private readonly ILogger<CreateFinancialYearCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IFinacialYearRepository _finacialYearRepository;

        public CreateFinancialYearCommandHandler(ILogger<CreateFinancialYearCommandHandler> logger,IMapper mapper, IFinacialYearRepository finacialYearRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _finacialYearRepository = finacialYearRepository;
        }
        public async Task<Response<CreateFinancialYearDto>> Handle(CreateFinancialYearCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("CreateFinancialYearCommandHandler Initiated");
            var FY = _mapper.Map<FinancialYear>(request);
            var FYResponse = await _finacialYearRepository.AddFY(FY);
            if (FYResponse.Succeeded)
            {
                return new Response<CreateFinancialYearDto>(FYResponse, "Success");
            }
            else
            {
                var res=new Response<CreateFinancialYearDto>(FYResponse,"failed");
                res.Succeeded = false;
                return res;
            }
            

            
        }
    }
}
