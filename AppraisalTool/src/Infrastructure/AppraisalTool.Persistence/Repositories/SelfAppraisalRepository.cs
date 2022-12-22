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
using AppraisalTool.Application.Models.Mail;
using AppraisalTool.Application.Contracts.Infrastructure;

namespace AppraisalTool.Persistence.Repositories
{
    public class SelfAppraisalRepository : ISelfAppraisalRepository
    {


        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailservice;


        public SelfAppraisalRepository(ApplicationDbContext dbContext, IMapper mapper, IUserRepository userRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _dbContext = dbContext;
            _emailservice = emailService;


        }



        public async Task<IQueryable<GetDataVM>> GetDataById(int userId, int fyId)
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
                                         where A.Id == userId && C.FinancialYear.Id == fyId




                                         select new GetDataVM
                                         {

                                             Id = A.Id,
                                             ReportingAuthorityFirstName = B.ReportingAuthority.FirstName,
                                             ReportingAuthorityLastName = B.ReportingAuthority.LastName,
                                             Role = primaryRole,
                                             ReviewingAuthorityFirstName = B.ReviewingAuthority.FirstName,
                                             ReviewingAuthorityLastName = B.ReviewingAuthority.LastName,
                                             AppraisalStatus = C.Status.StatusTitle,
                                             StartDate = DateTime.Parse(C.FinancialYear.StartDate).ToString("dd MMMM yyyy"),

                                             EndDate = DateTime.Parse(C.FinancialYear.EndDate).ToString("dd MMMM yyyy"),
                                             StartYear = C.FinancialYear.StartYear,
                                             EndYear = C.FinancialYear.EndYear,
                                             //Date= StartDate + " " + "to" + " " + C.FinancialYear.EndDate + " "+ C.FinancialYear.EndYear,
                                             FinancialYearId = C.FinancialYearId
                                         });


            Console.WriteLine(res);
            return res;
        }
        public async Task<Appraisal> AddAppraisal(Appraisal addAppraisal)
        {

            await _dbContext.Appraisal.AddAsync(addAppraisal);
            await _dbContext.SaveChangesAsync();
            try
            {
                UserAuthorityMapping mapping = await _dbContext.UserAuthorityMappings.Include(x => x.ReportingAuthority).FirstOrDefaultAsync(item => item.UserId == addAppraisal.UserId);
                User user = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == addAppraisal.UserId);
                if (mapping != null)
                {
                    var email = new Email()
                    {

                        To = mapping.ReportingAuthority.Email,
                        Body = $"Dear User, <br/>{user.FirstName} {user.LastName} filled their Appraisal. Login to view their form.",
                        Subject = $"{user.FirstName} {user.LastName} filled their appraisal !!"
                    };
                    await _emailservice.SendEmail(email);
                }
                else
                {
                    User admin = await _dbContext.User.Where(x => x.RoleId == 1).FirstOrDefaultAsync();
                    User employee = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == addAppraisal.UserId);
                    var email = new Email()
                    {

                        To = admin.Email,
                        Body = $"Dear User, <br/>{employee.FirstName} {employee.LastName} filled their Appraisal. Login to assign them authorities.",
                        Subject = $"Assignation of  Authorities for {employee.FirstName} {employee.LastName}  !!"
                    };
                    await _emailservice.SendEmail(email);
                }

            }
            catch (Exception ex)
            {
                User admin = await _dbContext.User.Where(x=>x.RoleId==1).FirstOrDefaultAsync();
                User employee = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == addAppraisal.UserId);
                var email = new Email()
                {

                    To = admin.Email,
                    Body = $"Dear User, <br/>{employee.FirstName} {employee.LastName} filled their Appraisal. Login to assign them authorities.",
                    Subject = $"Assignation of  Authorities for {employee.FirstName} {employee.LastName}  !!"
                };
                await _emailservice.SendEmail(email);


            }
            addAppraisal.User = null;
            return addAppraisal;
        }

        public async Task<bool> UpdateAppraisalStatus(int appraisalId, int status)
        {
            Appraisal data = await _dbContext.Appraisal.FirstOrDefaultAsync(x => x.Id == appraisalId);
            data.StatusId = status;
            await _dbContext.SaveChangesAsync();
            if(data.StatusId == 3)
            {
                UserAuthorityMapping mapping = await _dbContext.UserAuthorityMappings.Include(x => x.ReviewingAuthority).FirstOrDefaultAsync(item => item.UserId == data.UserId);
                User user = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == data.UserId);
                var email = new Email()
                {
                    To = mapping.ReviewingAuthority.Email,
                    Body = $"Dear User, <br/>{user.FirstName} {user.LastName} filled their Appraisal. Login to review their form.",
                    Subject = $"{user.FirstName} {user.LastName} filled their appraisal !!"
                };
                await _emailservice.SendEmail(email);
                    data.User = null;
               

            }

            if(data.StatusId==4)
            {
                User user = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == data.UserId);
                var email = new Email()
                {
                    To = user.Email,
                    Body = $"Dear User, <br/> Your appraisal has been approved. Login to view or download your grade letter.",
                    Subject = $"Appraisal Approved !!"
                };
                await _emailservice.SendEmail(email);
                data.User = null;
            }
            return true;
        }


        public async Task<List<Appraisal>> GetYear(int userId)
        {

            var years = await _dbContext.Appraisal.Include(x => x.FinancialYear).Where(x => x.UserId == userId && x.FinancialYear.IsDeleted == false)
                .Include(x => x.FinancialYear)
                .ToListAsync();

            return years;
        }


        //Author : Ilyas Dabholkar
        //returns list of all appraisals data 
        public async Task<List<ReporteeAppraisalListVm>> GetAllReporteeAppraisals()
        {
            List<UserAuthorityMapping> mappings = await _dbContext.UserAuthorityMappings.Include(x => x.ReviewingAuthority).Include(x => x.User).ToListAsync();
            List<Appraisal> appraisals = await _dbContext.Appraisal.Include(x => x.Status).Include(x => x.User).Include(x => x.FinancialYear).ToListAsync();


            var res = (from A in mappings
                       join B in appraisals on A.UserId equals B.UserId
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
                           Status = B.StatusId,

                       });
            return res.OrderByDescending(d => d.StartDate).ToList<ReporteeAppraisalListVm>();
        }

        //Author : Ilyas Dabholkar
        //Return Appraisal Object by financialayear and userid
        public async Task<Appraisal> GetAppraisalByUserAndFinancialYear(int fId, int userId)
        {
            //item => item.UserId == userId && item.FinancialYearId == fId
            Appraisal appraisal = await _dbContext.Appraisal.Include(item => item.FinancialYear).Where(item => item.UserId == userId && item.FinancialYearId == fId).FirstOrDefaultAsync();
            return appraisal;
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
