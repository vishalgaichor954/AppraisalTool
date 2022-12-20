using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Users.Query.GetUserList;
using AppraisalTool.Application.Response;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Query.GetUserById
{

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Response<GetUserListQueryVm>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserByIdQueryHandler> _logger;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper, ILogger<GetUserByIdQueryHandler> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger= logger;

        }
        public async Task<Response<GetUserListQueryVm>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetUserByIdQueryHandler Initiated");
            var user = await _userRepository.GetUserbyid(request.Id);
            
           // var mappeduser = _mapper.Map<GetUserListQueryVm>(user);
            _logger.LogInformation("GetUserByIdQueryHandler completed");
            var test = new Response<GetUserListQueryVm>(user);
            Console.WriteLine(test.Data);
            return new Response<GetUserListQueryVm>(user, "success");


        }
    }
}
