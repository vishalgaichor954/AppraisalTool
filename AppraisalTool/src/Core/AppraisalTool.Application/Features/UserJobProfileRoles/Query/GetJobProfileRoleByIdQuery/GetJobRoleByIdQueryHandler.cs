using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Response;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.UserJobProfileRoles.Query.GetJobProfileRoleByIdQuery
{
    public class GetJobRoleByIdQueryHandler : IRequestHandler<GetJobRoleByIdQuery, Response<GetJobRoleByIdQueryDto>>
    {
        private readonly IMapper _mapper;
        private IRoleRepository _roleRepository;

        public GetJobRoleByIdQueryHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }
        public async Task<Response<GetJobRoleByIdQueryDto>> Handle(GetJobRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var res =await _roleRepository.GetJobProfileById(request.Id);
            var response=_mapper.Map<GetJobRoleByIdQueryDto>(res);
            return new Response<GetJobRoleByIdQueryDto>(response, "Success");

        }
    }
}
