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

namespace AppraisalTool.Application.Features.SelfAppraisal.Command.AddAppraisal
{
    public class AddAppraisalCommandHandler : IRequestHandler<AddAppraisalCommand, Response<Appraisal>>
    {
        private readonly ISelfAppraisalRepository _selfAppraisalRepository;
        private readonly ILogger<AddAppraisalCommandHandler> _logger;
        private readonly IMapper _mapper;
        public AddAppraisalCommandHandler(ISelfAppraisalRepository selfAppraisalRepository, ILogger<AddAppraisalCommandHandler> logger, IMapper mapper)
        {
            _selfAppraisalRepository = selfAppraisalRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<Appraisal>> Handle(AddAppraisalCommand request, CancellationToken cancellationToken)
        {
            Appraisal apraisalData = _mapper.Map<Appraisal>(request.addAppraisal);
            var response= await _selfAppraisalRepository.AddAppraisal(apraisalData);

            return new Response<Appraisal>() { Data = response, Message = "Added Successfully", Succeeded = true, Errors = null };
        }
    }
}
