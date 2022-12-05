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

namespace AppraisalTool.Application.Features.Branches.Command.AddBranchCommand
{
    public class AddBranchCommandHandler : IRequestHandler<AddBranchCommand, Response<AddBranchCommandDto>>
    {
        private readonly ILogger<AddBranchCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;

        public AddBranchCommandHandler(ILogger<AddBranchCommandHandler> logger, IMapper mapper, IBranchRepository branchRepository)
        {
            _logger = logger;
            _mapper = mapper;

            _branchRepository = branchRepository;
        }

        public async Task<Response<AddBranchCommandDto>> Handle(AddBranchCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("AddBranchCommandHandler Initiated");
            var branch = _mapper.Map<Branch>(request);
            var BranchResponse = await _branchRepository.AddBranch(branch);
            if (BranchResponse.Succeeded)
            {
                return new Response<AddBranchCommandDto>(BranchResponse, "Success");
            }
            else
            {
                var res = new Response<AddBranchCommandDto>(BranchResponse, "failed");
                res.Succeeded = false;
                return res;
            }



        }
    }
}

                
           
