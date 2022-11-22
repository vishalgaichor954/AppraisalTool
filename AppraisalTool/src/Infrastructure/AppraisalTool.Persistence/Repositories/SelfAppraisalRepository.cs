using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
using AutoMapper;
using AppraisalTool.Domain.Common;
using AppraisalTool.Application.Features.SelfAppraisal.Command.AddAppraisal;

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


       
        public async Task<IQueryable<GetDataVM>> GetDataById(int userId)
        {
            var primaryRole = "";

            //var user = await _dbContext.User.Include(x => x.Role).Include(x => x.Appraisals).ThenInclude(x=>x.FinancialYear).FirstOrDefaultAsync(u => u.Id == userId );

            //var appraisals = await _dbContext.Appraisal.Include(x => x.FinancialYear).Where(x => x.UserId == userId && x.FinancialYearId == financialYearId).Include(x=>x.User).ThenInclude(x=>x.Role).ToListAsync();
            User user = await _userRepository.GetUserById(userId);

            if (user.JobRoles[0].IsPrimary = true)
            {
                primaryRole = user.JobRoles[0].JobRole.Name;
            }
            else
            {
                primaryRole = user.JobRoles[1].JobRole.Name;
            }


            IQueryable<GetDataVM> res = (from A in _dbContext.User
                                         join B in _dbContext.UserAuthorityMappings on A.Id equals B.UserId
                                         join C in _dbContext.Appraisal on B.UserId equals C.UserId

                                         where A.Id == userId

                                         select new GetDataVM
                                         {

                                             Id = A.Id,
                                             ReportingAuthorityFirstName = B.ReportingAuthority.FirstName,
                                             ReportingAuthorityLastName = B.ReportingAuthority.LastName,
                                             Role = primaryRole,
                                             ReviewingAuthorityFirstName = B.ReviewingAuthority.FirstName,
                                             ReviewingAuthorityLastName = B.ReviewingAuthority.LastName,
                                             AppraisalStatus = C.Status.StatusTitle,
                                             FinancialYearId  = C.FinancialYear.Id,
                                         }) ;   

            Console.WriteLine(res);
            return res;
        }
        public async Task<Appraisal> AddAppraisal(Appraisal addAppraisal)
        {
            await _dbContext.Appraisal.AddAsync(addAppraisal);
            await _dbContext.SaveChangesAsync();
            return addAppraisal;
        }

        public async Task<bool> UpdateAppraisalStatus(int appraisalId,int status)
        {
            Appraisal data = await _dbContext.Appraisal.FirstOrDefaultAsync(x => x.Id == appraisalId);
            data.StatusId = status;
            await _dbContext.SaveChangesAsync();
            return true;
        }


        public async Task<List<Appraisal>> GetYear(int userId)
        {
            
            var years = await _dbContext.Appraisal.Include(x => x.FinancialYear).Where(x => x.UserId == userId)
                .Include(x => x.FinancialYear)
                .ToListAsync();

            return years;
        }


        //Author : Ilyas Dabholkar
        //returns list of all appraisals data 
        public async Task<List<ReporteeAppraisalListVm>> GetAllReporteeAppraisals()
        {
            List<UserAuthorityMapping> mappings = await _dbContext.UserAuthorityMappings.Include(x=>x.ReviewingAuthority).Include(x=>x.User).ToListAsync();
            List<Appraisal> appraisals = await _dbContext.Appraisal.Include(x=>x.Status).Include(x=>x.User).Include(x=>x.FinancialYear).ToListAsync();

           
            var res = (from A in mappings join B in appraisals on A.UserId equals B.UserId
                                         select new ReporteeAppraisalListVm
                                         {
                                             AppraisalId = B.Id,
                                             StartDate =B.StartDate,
                                             EndDate = B.EndDate,
                                             FirstName = B.User.FirstName,
                                             EmployeeId = B.User.Id,
                                             LastName = B.User.LastName,
                                             RevaName = A.ReviewingAuthority.FirstName +" "+ A.ReviewingAuthority.LastName,
                                             AppraisalStatusId = B.Status.Id,
                                             RevAuthorityId = A.ReviewingAuthorityId,
                                             AppraisalStatus = B.Status.StatusTitle,
                                             FinancialYearId = B.FinancialYear.Id,
                                             FinancialStartYear = B.FinancialYear.StartYear,
                                             FinancialEndYear = B.FinancialYear.EndYear
                                         });
            return res.ToList<ReporteeAppraisalListVm>();
        }


        //Author : Ilyas Dabholkar
        //Endpoint takes id of reporting autority and return list of appraisals data belonging to that reporting authority
        //Joins UserAuthorityMapping,User,Appraisal,Status,FinancialYear
        public async Task<List<ReporteeAppraisalListVm>> GetReporteeAppraisalsByRepAuthority(int id)
        {
            List<UserAuthorityMapping> mappings = await _dbContext.UserAuthorityMappings.Include(x => x.ReviewingAuthority).ToListAsync();
            List<Appraisal> appraisals = await _dbContext.Appraisal.Include(x => x.Status).Include(x => x.User).Include(x => x.FinancialYear).ToListAsync();
            

            var res = (from A in mappings
                       join B in appraisals on A.UserId equals B.UserId
                       where A.ReportingAuthorityId == id
                       select new ReporteeAppraisalListVm
                       {
                           AppraisalId = B.Id,
                           StartDate = B.StartDate,
                           EndDate = B.EndDate,
                           FirstName = B.User.FirstName,
                           EmployeeId = B.User.Id,
                           LastName = B.User.LastName,
                           RevaName = A.ReviewingAuthority.FirstName + " " + A.ReviewingAuthority.LastName,
                           AppraisalStatusId = B.Status.Id,
                           RevAuthorityId = A.ReviewingAuthorityId,
                           AppraisalStatus = B.Status.StatusTitle,
                           FinancialYearId = B.FinancialYear.Id,
                           FinancialStartYear = B.FinancialYear.StartYear,
                           FinancialEndYear = B.FinancialYear.EndYear,
                           Status=B.StatusId,
                           
                       });
            return res.OrderByDescending(d => d.StartDate).ToList<ReporteeAppraisalListVm>();
        }

        public async Task<List<ReviewAppraisalListVm>> GetReviewAppraisalsByRevAuthority(int id)
        {
            List<UserAuthorityMapping> mappings = await _dbContext.UserAuthorityMappings.Include(x => x.ReportingAuthority).ToListAsync();
            List<Appraisal> appraisals = await _dbContext.Appraisal.Include(x => x.Status).Include(x => x.User).Include(x => x.FinancialYear).ToListAsync();


            var res = (from A in mappings
                       join B in appraisals on A.UserId equals B.UserId
                       where A.ReviewingAuthorityId == id
                       select new ReviewAppraisalListVm
                       {
                           AppraisalId = B.Id,
                           StartDate = B.StartDate,
                           EndDate = B.EndDate,
                           FirstName = B.User.FirstName,
                           EmployeeId = B.User.Id,
                           LastName = B.User.LastName,
                           RepaName = A.ReportingAuthority.FirstName + " " + A.ReportingAuthority.LastName,
                           AppraisalStatusId = B.Status.Id,
                           RepAuthorityId = A.ReportingAuthorityId,
                           AppraisalStatus = B.Status.StatusTitle,
                           FinancialYearId = B.FinancialYear.Id,
                           FinancialStartYear = B.FinancialYear.StartYear,
                           FinancialEndYear = B.FinancialYear.EndYear,
                            Status = B.StatusId,
                       });
            return res.OrderByDescending(d => d.StartDate).ToList<ReviewAppraisalListVm>();
        }

        public async Task<bool> UpdateAppraisalStatusByReva(int appraisalId, int statusId)
        {
            Appraisal data = await _dbContext.Appraisal.FirstOrDefaultAsync(x => x.Id == appraisalId);
            data.StatusId = statusId;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
