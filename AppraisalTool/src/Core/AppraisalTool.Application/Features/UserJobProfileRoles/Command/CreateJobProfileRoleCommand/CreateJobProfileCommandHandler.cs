using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.UserJobProfileRoles.Command.CreateJobProfileRoleCommand
{
    public class CreateJobProfileCommandHandler : IRequestHandler<CreateJobProfileCommand, Response<CreateJobProfileCommandDto>>

    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public CreateJobProfileCommandHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<Response<CreateJobProfileCommandDto>> Handle(CreateJobProfileCommand request, CancellationToken cancellationToken)
        {
            var Result = _mapper.Map<JobRoles>(request);
            var response = await _roleRepository.AddJobProfileRole(Result);
            if (response.Succeeded)
            {
                return new Response<CreateJobProfileCommandDto>(response, "Success");
            }
            else
            {
                return new Response<CreateJobProfileCommandDto>(response, "Failed");
            }
        }
    }
}
