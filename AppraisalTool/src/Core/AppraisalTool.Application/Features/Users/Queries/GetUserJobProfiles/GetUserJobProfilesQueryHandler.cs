using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Users.Command.CreateUserCommand;
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

namespace AppraisalTool.Application.Features.Users.Queries.GetUserJobProfiles
{
    public class GetUserJobProfilesQueryHandler : IRequestHandler<GetUserJobProfilesQuery, Response<UserJobProfilesDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserJobProfilesQueryHandler(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<Response<UserJobProfilesDto>> Handle(GetUserJobProfilesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id);
            var data = user.JobRoles;
            UserJobProfilesDto responseDto = new UserJobProfilesDto();
            List<string> additionalRoles = new List<string>();
            foreach (var item in data)
            {
                if (item.IsPrimary == true)
                {
                    responseDto.PrimaryRole = item.JobRole.Name;
                }
                else if (item.IsSecondary == true)
                {
                    responseDto.SecondaryRole = item.JobRole.Name;
                }
                else
                {
                    additionalRoles.Add(item.JobRole.Name);
                }
            }
            responseDto.Roles = additionalRoles;
            var response = new Response<UserJobProfilesDto>(responseDto);
            return response;
        }
    }
}
