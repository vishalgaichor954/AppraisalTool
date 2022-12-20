using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.UnitTests.Mocks
{
    public class RoleRepositoryMocks
    {
        public static Mock<IRoleRepository> GetAllRole()
        {
            var jobrole = new List<UserJobRoles>
            {
                new UserJobRoles
                {
                      Id=1,
                      JobRoleId=1,
                      IsPrimary=true,
                      IsSecondary=false
                       
                }
            };
            var mockrepository= new Mock<IRoleRepository>();
            mockrepository.Setup(repo => repo.AddJobRoles(jobrole)).ReturnsAsync(true);
            return mockrepository;
        }
    }
}
