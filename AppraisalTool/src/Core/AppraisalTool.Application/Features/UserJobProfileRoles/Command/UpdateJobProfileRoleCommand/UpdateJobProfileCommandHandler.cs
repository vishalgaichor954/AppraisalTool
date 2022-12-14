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

namespace AppraisalTool.Application.Features.UserJobProfileRoles.Command.UpdateJobProfileRoleCommand
{
    public class UpdateJobProfileCommandHandler : IRequestHandler<UpdateJobProfileCommand, Response<UpdateJobProfileCommandDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _rolerepository;

        public UpdateJobProfileCommandHandler(IMapper mapper , IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _rolerepository = roleRepository;
        }
        public async Task<Response<UpdateJobProfileCommandDto>> Handle(UpdateJobProfileCommand request, CancellationToken cancellationToken)
        {
            
            var Response = await _rolerepository.UpdatejobProfileRole(request,request.Id);
            if (Response.Succeeded)
            {
                return new Response<UpdateJobProfileCommandDto>(Response, "Success");
            }
            else
            {
                return new Response<UpdateJobProfileCommandDto>(Response, "Failed");
            }

        }
    }
}
