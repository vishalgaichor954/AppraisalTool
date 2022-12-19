using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
using AppraisalTool.Domain.Common;
using AppraisalTool.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.UnitTests.Mocks
{
    public class SelfAppraisalRepositoryMocks
    {
        public static Mock<ISelfAppraisalRepository> GetSelfAppraisalRepositoryMocks()
        {
            #region ListOfUsers
            //var users = new List<User>
            //{
            //    new User
            //    {
            //        Id = 1,
            //        FirstName = "Ilyas",
            //        LastName = "dabholkar",
            //        Email = "ilyasdabholkar9@gmail.com",
            //        JoinDate = DateTime.Now,
            //        LastAppraisalDate = DateTime.Now.AddMonths(6),
            //        RoleId = 1,
            //        BranchId = 1,
            //        JobRoles = new List<UserJobRoles>
            //        {
            //            new UserJobRoles
            //            {
            //                Id = 26,
            //                UserId = 1,
            //                JobRoleId = 1,
            //                IsPrimary = true,
            //                IsSecondary = false,

            //            }
            //        }

            //    }
            //};
            #endregion

            var data = new List<GetDataVM>
            {
                new GetDataVM
                {
                   Id=1,
                   ReviewingAuthorityFirstName= "abhishek",
                   ReviewingAuthorityLastName=  "singh",
                   ReportingAuthorityFirstName= "Harikrishnan",
                   ReportingAuthorityLastName= "Nair",
                   Role= "Savings Account Officer",
                   AppraisalStatus= "Approved",
                   Date= null,
                   FinancialYearId= 2,
                   StartYear= 2020,
                   EndYear= 2021,
                   StartDate= "01 April 2020",
                   EndDate= "31 March 2021"
                }
            };
            var appraisals = new List<Appraisal>
            {
                new Appraisal
                {
                   Id=96,
                   FinancialYearId=2,
                   UserId=1,
                   StartDate=DateTime.Now,
                   EndDate=DateTime.Now,
                   StatusId=4,


                }
            };
            var reporteeAppraisal=new List<ReporteeAppraisalListVm>
            {
                new ReporteeAppraisalListVm
                {
                    StartDate=DateTime.Now,
                    EndDate=DateTime.Now,
                    AppraisalId=96,
                    EmployeeId=5,
                    FirstName="HariKrishanan",
                    LastName="Nair",
                    RevAuthorityId=2,
                    RevaName="abhishek",
                    AppraisalStatusId=2,
                    AppraisalStatus="Pending At Reporting Authority",
                    FinancialStartYear=2019,
                    FinancialEndYear=2020,
                    Status=2,

                }
            }
            var mockSelfAppraisalRepository = new Mock<ISelfAppraisalRepository>();
            mockSelfAppraisalRepository.Setup(repo => repo.GetDataById(1, 2)).ReturnsAsync(data.Where(x => x.Id == 1 && x.FinancialYearId == 2).AsQueryable());
            mockSelfAppraisalRepository.Setup(repo => repo.AddAppraisal(It.IsAny<Appraisal>())).ReturnsAsync(
            (Appraisal appraisal) =>
                {
                    appraisals.Add(appraisal);
                    return appraisal;
                }
            );
            return mockSelfAppraisalRepository;
        }
    }
}

