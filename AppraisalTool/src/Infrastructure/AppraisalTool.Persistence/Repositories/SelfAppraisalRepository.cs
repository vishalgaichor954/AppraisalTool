﻿using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
using AutoMapper;

namespace AppraisalTool.Persistence.Repositories
{
    public class SelfAppraisalRepository : ISelfAppraisalRepository
    {


        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public SelfAppraisalRepository(ApplicationDbContext dbContext,IMapper mapper,IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _dbContext = dbContext;

        }


        //public async Task<List<User>> GetDataById(int userId, int financialYearId)
        public async Task<IQueryable<GetDataVM>> GetDataById(int userId)
        {

            //var user = await _dbContext.User.Include(x => x.Role).Include(x => x.Appraisals).ThenInclude(x=>x.FinancialYear).FirstOrDefaultAsync(u => u.Id == userId );

            //var appraisals = await _dbContext.Appraisal.Include(x => x.FinancialYear).Where(x => x.UserId == userId && x.FinancialYearId == financialYearId).Include(x=>x.User).ThenInclude(x=>x.Role).ToListAsync();
            User u = await _userRepository.GetUserById(userId);

            IQueryable<GetDataVM> res = (from A in _dbContext.User
                          join B in _dbContext.UserAuthorityMappings on A.Id equals B.UserId
                          where A.Id == userId
                          select new GetDataVM
                          {
                              //Role=A.JobRoles.,
                              Role = A.Role.Role,
                              Id = A.Id,
                              ReportingAuthorityFirstName = B.ReportingAuthority.FirstName,
                              ReportingAuthorityLastName = B.ReportingAuthority.LastName,

                              ReviewingAuthorityFirstName = B.ReviewingAuthority.FirstName,
                              ReviewingAuthorityLastName = B.ReviewingAuthority.LastName,
                          });

            Console.WriteLine(res);

            





            return res;
        }

        public async Task<List<Appraisal>> GetYear(int userId)
        {
            var years = await _dbContext.Appraisal.Include(x => x.FinancialYear).Where(x => x.UserId == userId)
                .Include(x => x.FinancialYear)
                .ToListAsync();
            return years;
        }
    }
}
