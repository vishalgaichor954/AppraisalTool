﻿using AppraisalTool.Application.Contracts.Persistence;
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

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Response<GetUserByIdDto>>
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
        public async Task<Response<GetUserByIdDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetUserByIdQueryHandler Initiated");
            var user = await _userRepository.GetUserById(request.Id);
            var mappeduser = _mapper.Map<GetUserByIdDto>(user);
            _logger.LogInformation("GetUserByIdQueryHandler completed");
            return new Response<GetUserByIdDto>(mappeduser,"success");


        }
    }
}
